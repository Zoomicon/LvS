'Description: Notes class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

#Region "Imports"

Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports LvS.models
Imports LvS.models.subtitles
Imports LvS.models.notes
Imports LvS.models.notes.INotes.Columns
Imports LvS.objects.grid
Imports LvS.utilities
Imports LvS.utilities.documents
Imports SourceGrid.Cells

#End Region

Namespace LvS.objects.notes

 Public Class Notes
  Implements INotes

#Region "Constants"

  Protected Const HEADER_ROW As Integer = 0
  Protected Const ROW_HEIGHT As Integer = 43

#End Region

#Region "Fields"

  Protected cellView As New Views.Cell()
  Protected WithEvents editorComment As New CommentEditor 'New SourceGrid.Cells.Editors.TextBox(GetType(String))
  Protected toolTipController As New SourceGrid.Cells.Controllers.ToolTipText
  Protected fSubtitles As ISubtitles

  Protected fSource As String = ""
  Protected fAuthoringMode As Boolean = False
  Protected fTeacherNotes As Boolean = False
  Protected WithEvents fSelection As SourceGrid.Selection

#End Region

#Region "Properties"

  <DefaultValue(-1)> _
  Public Property FocusedRow() As Integer Implements INotes.FocusedRow
   Get
    If fSelection Is Nothing Then Return -1
    Dim row As Integer = fSelection.ActivePosition.Row
    If row < 1 Then Return -1 'skip header row
    Return CInt(gridSubtitleNotes(row, colIndex).Value)
   End Get
   Set(ByVal value As Integer)
    value = FindCommentRow(value)
    If value < 1 Then 'skip header row
     gridSubtitleNotes.SetFocusCell(Nothing)
     fSelection.Clear() 'must do this too!
     RaiseEvent FocusedRowChanged(Me, -1) 'raise this event only in case we clear the focus - in other cases the grid will throw FocusedRowEntered event which we catch and throw FocusRowChanged
    Else
     If fSelection IsNot Nothing Then fSelection.FocusRow(value)
    End If
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property TeacherNotes() As Boolean Implements INotes.TeacherNotes
   Get
    Return fTeacherNotes
   End Get
   Set(ByVal value As Boolean)
    fTeacherNotes = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Overloads Property Text() As String Implements INotes.Text
   Get
    Return MyBase.Text
   End Get
   Set(ByVal value As String)
    MyBase.Text = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Source() As String Implements models.notes.INotes.Source
   Get
    Return fSource
   End Get
   Set(ByVal value As String)
    LoadNotes(value)
    fSource = value 'do not check if loaded ok, always set the fSource value (for later save action)
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property AuthoringMode() As Boolean Implements models.notes.INotes.AuthoringMode
   Get
    Return fAuthoringMode
   End Get
   Set(ByVal value As Boolean)
    FocusedRow = -1 'must unfocus first!
    fAuthoringMode = value
    rtfNotes.ReadOnly = Not fAuthoringMode
    editorComment.EnableEdit = fAuthoringMode
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property Modified() As Boolean Implements models.notes.INotes.Modified
   Get
    Return rtfNotes.Modified
   End Get
   Set(ByVal value As Boolean) 'using the richtextbox to keep the modified flag value for the per-subtitle comments grid too
    If value <> Modified Then
     rtfNotes.Modified = value
     RaiseEvent ModifiedChanged(Me, value)
    End If
   End Set
  End Property

#End Region

#Region "Methods"

#Region "Constructor"

  Public Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()

   ' Add any initialization after the InitializeComponent() call.
   fSelection = gridSubtitleNotes.Selection

   With editorComment
    .EnableEdit = fAuthoringMode
    '.EnableCellDrawOnEdit = False 'do not draw the cell when editing (since the editor control is shown above it)
    '.EditableMode = SourceGrid.EditableMode.AnyKey Or SourceGrid.EditableMode.SingleClick
   End With

   Dim b As New DevAge.Drawing.Border(Color.Black, 1)
   Dim b2 As New DevAge.Drawing.Border(Color.Black, 2)
   Dim rb As New DevAge.Drawing.RectangleBorder(b, b)

   cellView.Border = rb
   cellView.AnchorArea = New DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.MiddleCenter, True)

   With gridSubtitleNotes
    .SuspendLayout()
    .Selection.SelectionMode = SourceGrid.GridSelectionMode.Row
    .Selection.FocusStyle = SourceGrid.FocusStyle.None 'must do this so that grid keeps on drawing the selection when it has lost focus
    .Selection.FocusBackColor = Color.FromArgb(CInt(.Selection.BackColor.A * 2), .Selection.BackColor) 'drawing focused cell a bit darker than seleced ones (must always use a semi-transparent color)
    .Selection.BorderMode = SourceGrid.SelectionBorderMode.FocusCell 'draw border arround focused cell
    .Selection.Border = New DevAge.Drawing.RectangleBorder(b, b2, b, b2)

    .ColumnsCount = 2

    .Rows.Insert(0)
    .Item(HEADER_ROW, colIndex) = New ColumnHeaderNoSort("#")
				.Item(HEADER_ROW, colComment) = New ColumnHeaderNoSort(My.Resources.STR_COMMENT)

    .ResumeLayout(False)
   End With
  End Sub

#End Region

#Region "Load"

  Protected Function LoadNotes(ByVal path As String) As Boolean
   With gridSubtitleNotes.Rows
    If .Count > 1 Then .RemoveRange(1, .Count - 1) 'preserve the header row
   End With

   If path Is Nothing Then
    rtfNotes.Text = ""
    Return True
   End If

   Dim result As Boolean = False
   Try
				rtfNotes.LoadFile(path & DocumentUtils.EXTENSION_RTF, RichTextBoxStreamType.RichText)
    result = True
   Catch
    'ignore errors
   End Try
   Try
				LoadPerSubtitleComments(fSubtitles, path & DocumentUtils.EXTENSION_TXT)
    result = True
   Catch
    'ignore errors
   End Try
   Return result
  End Function

  Public Overloads Sub LoadPerSubtitleComments(ByVal subtitles As models.subtitles.ISubtitles, ByVal path As String)
   If subtitles Is Nothing Then Exit Sub
   'not clearing any existing subtitles, just appending to the end (the ISubtitles object can choose whether it will sort the subtitles by start time or not after the appending)
   Using reader As New StreamReader(path, Encoding.Unicode, True) '"Using" makes sure the resource is immediately deallocated at "End Using"
    LoadPerSubtitleComments(subtitles, reader)
   End Using
  End Sub

  Protected Overloads Sub LoadPerSubtitleComments(ByVal subtitles As ISubtitles, ByVal reader As TextReader)
   If subtitles Is Nothing Then Exit Sub
   Try
    Dim line As String = reader.ReadLine()
    Dim en As IEnumerator(Of ISubtitle) = subtitles.GetEnumerator
    While (line IsNot Nothing) AndAlso (line <> "")
     en.MoveNext() 'must do this first, before querying for en.Current
     ReadSubtitleComment(en.Current, line)
     line = reader.ReadLine()
    End While
   Finally
    reader.Close()
   End Try
   CopySubtitleCommentsToGrid()
  End Sub

  Protected Sub ReadSubtitleComment(ByVal subtitle As ISubtitle, ByVal line As String)
   Dim parts As String() = Split(line, " | ")

   Dim commentIcon As Integer = CInt(parts(0))

   Dim comment As String = ""
   If parts.Length > 1 Then comment = parts(1).Replace(vbTab, vbCrLf)

   With subtitle
    If TeacherNotes Then
     .TeacherCommentIcon = commentIcon
     .TeacherComment = comment
    Else
     .StudentCommentIcon = commentIcon
     .StudentComment = comment
    End If
   End With
  End Sub

#End Region

#Region "Save"

  Public Sub Save() Implements models.notes.INotes.Save
   If fSource Is Nothing Then Exit Sub
			rtfNotes.SaveFile(fSource & DocumentUtils.EXTENSION_RTF, RichTextBoxStreamType.RichText)
			SavePerSubtitleComments(fSubtitles, fSource & DocumentUtils.EXTENSION_TXT)
   Modified = False
  End Sub

  Public Overloads Sub SavePerSubtitleComments(ByVal subtitles As models.subtitles.ISubtitles, ByVal path As String)
   If subtitles Is Nothing Then Exit Sub
   Using writer As New StreamWriter(path, False, Encoding.Unicode)
    SavePerSubtitleComments(subtitles, writer)
   End Using
  End Sub

  Public Overloads Sub SavePerSubtitleComments(ByVal subtitles As models.subtitles.ISubtitles, ByVal writer As TextWriter)
   If subtitles Is Nothing Then Exit Sub
   For Each s As ISubtitle In subtitles
    WriteSubtitleComment(s, writer)
   Next
  End Sub

  Protected Sub WriteSubtitleComment(ByVal subtitle As models.subtitles.ISubtitle, ByVal writer As System.IO.TextWriter)
   With subtitle
    Dim line As String
    If TeacherNotes Then
     line = CStr(.TeacherCommentIcon) + " | " + .TeacherComment.Replace(vbCrLf, vbTab)
    Else
     line = CStr(.StudentCommentIcon) + " | " + .StudentComment.Replace(vbCrLf, vbTab)
    End If
    writer.WriteLine(line)
   End With
  End Sub

#End Region

#Region "Print"

  Protected checkPrint As Integer = 0

  Public Sub Print(ByVal e As System.Drawing.Printing.PrintPageEventArgs) Implements INotes.Print
   'Print the content of the RichTextBox. Store the last character printed.
   checkPrint = rtfNotes.RTFTextBox.Print(checkPrint, rtfNotes.RTFTextBox.TextLength, e)

   ' Look for more pages
   If checkPrint < rtfNotes.TextLength Then
    e.HasMorePages = True
   Else
    e.HasMorePages = False
    checkPrint = 0 '!!! may also need to reset it at EndPrint (if user cancels)
   End If
  End Sub

#End Region

  Protected Sub SetSubtitles(ByVal theSubtitles As ISubtitles) Implements INotes.SetSubtitles
   fSubtitles = theSubtitles
   CopySubtitleCommentsToGrid()
  End Sub

  Protected Sub CopySubtitleCommentsToGrid()
   If fSubtitles Is Nothing Then Exit Sub
   With gridSubtitleNotes
    Try
     If .Rows.Count > 1 Then .Rows.RemoveRange(1, .Rows.Count - 1) 'preserve the header row
    Catch
     'ignore?
    End Try
    Dim i As Integer = 0 'skip header row (don't use -1)
    Dim si As Integer = 0
    For Each subtitle As ISubtitle In fSubtitles
     si += 1
     If TeacherNotes Then
      If (subtitle.TeacherCommentIcon = -1) AndAlso (subtitle.TeacherComment = "") Then Continue For 'skip empty comments
     Else
      If (subtitle.StudentCommentIcon = -1) AndAlso (subtitle.StudentComment = "") Then Continue For 'skip empty comments
     End If
     i += 1

     InsertNewRow()
     SetIndex(si, i, colIndex)
     If TeacherNotes Then
      SetComment(fSubtitles.Item(si - 1).TeacherComment, i, colComment)
     Else
      SetComment(fSubtitles.Item(si - 1).StudentComment, i, colComment)
     End If
    Next subtitle
   End With
  End Sub

  Protected Sub SetIndex(ByVal theIndex As Integer, ByVal theRow As Integer, ByVal theColumn As Integer)
   With gridSubtitleNotes.Item(theRow, theColumn)
    .Value = theIndex
    .ToolTipText = "#" & theIndex
   End With
  End Sub

  Protected Sub SetComment(ByVal theComment As String, ByVal theRow As Integer, ByVal theColumn As Integer)
   With gridSubtitleNotes.Item(theRow, theColumn)
    .Value = theComment
    If theComment = vbCrLf Then .ToolTipText = "" Else .ToolTipText = theComment
   End With
  End Sub

  Protected Overloads Sub InsertNewRow(ByVal row As Integer) 'does not update the index, must update separately
   With gridSubtitleNotes
    .Rows.Insert(row)

    .Rows(row).Height = ROW_HEIGHT

    Dim cell As ICell

    cell = New RowHeader
    .Item(row, colIndex) = cell
    cell.AddController(toolTipController)

    cell = New Cell("")
    .Item(row, colComment) = cell
    cell.View = cellView
    cell.Editor = editorComment
    cell.ToolTipText = ""
    cell.AddController(toolTipController)
   End With
   Modified = True
  End Sub

  Protected Overloads Sub InsertNewRow() 'does not update the index, must update separately
   With gridSubtitleNotes
    Dim pos As SourceGrid.Position = .Selection.ActivePosition
    Dim row As Integer
    If (pos.Row < 0) Then row = .Rows.Count Else row = pos.Row + 1
    InsertNewRow(row)
   End With
  End Sub

  Private Sub resizeColumns()
   With gridSubtitleNotes
    If .ColumnsCount = 0 Then Exit Sub
    .Columns(colIndex).Width = 35
    .Columns(colComment).Width = .ClientSize.Width - .Columns(colIndex).Width - SystemInformation.VerticalScrollBarWidth
   End With
  End Sub

  Protected Function FindCommentRow(ByVal theSubtitlesGridRow As Integer) As Integer
   Dim indexStr As String = CStr(theSubtitlesGridRow)
   With gridSubtitleNotes
    For i As Integer = 1 To .Rows.Count - 1
     If CStr(.Item(i, colIndex).Value) = indexStr Then Return i
    Next i
    Return -1
   End With
  End Function

  Public Sub AddComment(ByVal theSubtitlesRow As Integer) Implements INotes.AddComment
   With gridSubtitleNotes
    Dim count As Integer = .Rows.Count
    For i As Integer = 1 To count - 1
     Dim subtitlesGridRow As Integer = CInt(gridSubtitleNotes(i, colIndex).Value)
     Debug.Assert(subtitlesGridRow <> theSubtitlesRow)
     If subtitlesGridRow > theSubtitlesRow Then
      InsertNewRow(i) 'this will set Modified=true
      SetIndex(theSubtitlesRow, i, colIndex)

      ChangeComment(theSubtitlesRow)
      Exit Sub
     End If
    Next i
    InsertNewRow(count) 'this will set Modified=true
    SetIndex(theSubtitlesRow, count, colIndex)
   End With
  End Sub

  Public Sub ChangeComment(ByVal theSubtitlesRow As Integer) Implements INotes.ChangeComment
   Dim i As Integer = FindCommentRow(theSubtitlesRow)
   If i <= 0 Then
    AddComment(theSubtitlesRow) 'we're only interested in adding new rows for comments (change of the comment icon is ignored)
   End If
  End Sub

  Public Sub RemoveComment(ByVal theSubtitlesRow As Integer) Implements INotes.RemoveComment
   Dim i As Integer = FindCommentRow(theSubtitlesRow)
   If i < 0 Then Exit Sub
   If TeacherNotes Then
    fSubtitles.Item(theSubtitlesRow - 1).TeacherComment = ""
   Else
    fSubtitles.Item(theSubtitlesRow - 1).StudentComment = ""
   End If
   gridSubtitleNotes.Rows.Remove(i)
   RaiseEvent CommentChanged(Me, theSubtitlesRow) 'raise this event so that the respective comment tooltip at the subtitles grid is cleared too
   Modified = True
  End Sub

#End Region

#Region "Events"

  Private Sub gridSubtitleNotes_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles gridSubtitleNotes.Layout
   resizeColumns()
  End Sub

  Private Sub rtfNotes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtfNotes.LinkClicked
   Try
    DevAge.Shell.Utilities.OpenFile(e.LinkText)
   Catch
				MessageBox.Show(My.Resources.STR_OPEN_URL_FAILED & " " & e.LinkText, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try
  End Sub

  Private Sub fSelection_FocusRowEntered(ByVal sender As Object, ByVal e As SourceGrid.RowEventArgs) Handles fSelection.FocusRowEntered
   RaiseEvent FocusedRowChanged(Me, FocusedRow) 'do not use e.Row here
  End Sub

  Private Sub editorComment_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorComment.Validated
   With e.CellContext.Position
    Try
     Dim subtitlesGridRow As Integer = CInt(gridSubtitleNotes(.Row, colIndex).Value) 'seems to throw error here (the cell is Nothing), which is caught below
     Dim comment As String = CStr(gridSubtitleNotes(.Row, colComment).Value)
     If TeacherNotes Then
      If (comment <> fSubtitles.Item(subtitlesGridRow - 1).TeacherComment) Then
       fSubtitles.Item(subtitlesGridRow - 1).TeacherComment = comment
       RaiseEvent CommentChanged(Me, subtitlesGridRow)
       Modified = True 'mark document as modified if changed succesfully
      End If
     Else
      If (comment <> fSubtitles.Item(subtitlesGridRow - 1).StudentComment) Then
       fSubtitles.Item(subtitlesGridRow - 1).StudentComment = comment
       RaiseEvent CommentChanged(Me, subtitlesGridRow)
       Modified = True 'mark document as modified if changed succesfully
      End If
     End If
    Catch
     'ignore errors
    End Try
   End With
  End Sub

  Public Event ModifiedChanged(ByVal source As IModifiable, ByVal newModifiedFlag As Boolean) Implements INotes.ModifiedChanged
  Public Event CommentChanged(ByVal source As INotes, ByVal theRow As Integer) Implements INotes.CommentChanged
  Public Event FocusedRowChanged(ByVal source As INotes, ByVal theRow As Integer) Implements INotes.FocusedRowChanged

#End Region

 End Class

End Namespace
