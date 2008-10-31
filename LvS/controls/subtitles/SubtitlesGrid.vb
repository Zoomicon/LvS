'Description: SubtitlesGrid class
'Authors: George Birbilis (birbilis@kagi.com), Kostas Mitropoulos (kosmitr@eap.gr)
'Version: 20080422

#Region "Imports"

Imports System.ComponentModel
Imports System.Text
Imports LvS.models
Imports LvS.models.subtitles
Imports LvS.models.subtitles.ISubtitlesGrid.Columns
Imports LvS.objects.grid
Imports LvS.utilities
Imports LvS.utilities.subtitles
Imports LvS.utilities.documents
Imports LvS.utilities.DateTimeUtils
Imports SourceGrid.Cells

#End Region

Namespace LvS.objects.subtitles

 Public Class SubtitlesGrid
  Implements ISubtitlesGrid

#Region "Constants"

  Public Const SignificantDigits As Integer = 2 'must use 2 as done at other LvS controls like the TimeSelectionController

  Public Const DEFAULT_NEW_SUBTITLE_DURATION As Integer = 2 '2sec default new subtitle duration

  Protected Const MIN_SUBTITLES_COLUMN_WIDTH As Integer = 100
  Protected Const DEFAULT_INDEX_COLUMN_WIDTH As Integer = 35
  Protected Const DEFAULT_TIME_COLUMN_WIDTH As Integer = 85
  Protected Const HEADER_ROW As Integer = 0
  Protected Const ROW_HEIGHT As Integer = 43

#End Region

#Region "Fields"

  Protected iconDropDown As New LvS.objects.grid.IconDropDown
  Protected cellView As New Views.Cell()
  Protected cellViewAuthoring As New Views.Cell()
  Protected WithEvents editorStartTime As New TimeEditor
  Protected WithEvents editorEndTime As New TimeEditor
  Protected WithEvents editorDuration As New TimeEditor
		Protected WithEvents editorSubtitlePair As New TextLinePairEditor
  Protected WithEvents editorTeacherComment As New IconEditor()
  Protected WithEvents editorStudentComment As New IconEditor()
  Protected toolTipController As New SourceGrid.Cells.Controllers.ToolTipText

  Protected fTime As Double = 0
  Protected fAuthoringMode As Boolean = False
  Protected fModified As Boolean = False
  Protected fSubtitles As ISubtitles = New Subtitles(gridSubtitles)
  Protected WithEvents fSelection As SourceGrid.Selection

  Protected updatingTime As Boolean = False

#End Region

#Region "Properties"

  <DefaultValue(False)> _
  Public Property Modified() As Boolean Implements ISubtitlesGrid.Modified
   Get
    Return fModified
   End Get
   Set(ByVal value As Boolean)
    If value <> fModified Then
     fModified = value
     RaiseEvent ModifiedChanged(Me, value)
    End If
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Source() As String Implements ISubtitlesGrid.Source
   Get
    Return fSubtitles.Source
   End Get
   Set(ByVal value As String)
    LoadSubtitles(value) 'do not talk to fSubtitles.Source directly here, call LoadSubtitles instead that also updates the grid
   End Set
  End Property

  Public Property Encoding() As System.Text.Encoding Implements ISubtitlesGrid.Encoding
   Get
    Return fSubtitles.Encoding
   End Get
   Set(ByVal value As System.Text.Encoding)
    fSubtitles.Encoding = value
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property AuthoringMode() As Boolean Implements ISubtitlesGrid.AuthoringMode
   Get
    Return fAuthoringMode
   End Get
   Set(ByVal value As Boolean)
    FocusedRow = -1 'must unfocus first!
    fAuthoringMode = value
    editorStartTime.EnableEdit = value
    editorEndTime.EnableEdit = value
    editorDuration.EnableEdit = value
    editorTeacherComment.EnableEdit = value
    'editorStudentComment.EnableEdit = True 'always enable editing student comments
    ColumnEndTimeVisible = value 'show EndTime column only at authoring mode
    resizeColumns()
   End Set
  End Property

  <DefaultValue(-1)> _
  Public Property FocusedRow() As Integer Implements ISubtitlesGrid.FocusedRow
   Get
    If fSelection Is Nothing Then Return -1
    Return fSelection.ActivePosition.Row
   End Get
   Set(ByVal value As Integer)
    fSelection.Clear() 'always clear the selection, don't rely on the grid clearing it when changing focus (cause it forgets to do it sometimes)
    If value < 1 Then 'ignore header cell
     gridSubtitles.SetFocusCell(Nothing)
     RaiseEvent FocusedRowChanged(Me, -1) 'raise this event only in case we clear the focus - in other cases the grid will throw FocusedRowEntered event which we catch and throw FocusRowChanged
    Else
     If fSelection IsNot Nothing Then fSelection.FocusRow(value)
    End If
   End Set
  End Property

  <DefaultValue(colNone)> _
  Public Property FocusedColumn() As ISubtitlesGrid.Columns Implements ISubtitlesGrid.FocusedColumn
   Get
    If fSelection Is Nothing Then Return colNone
    Return CType(fSelection.ActivePosition.Column, ISubtitlesGrid.Columns)
   End Get
   Set(ByVal value As ISubtitlesGrid.Columns)
    If fSelection IsNot Nothing Then fSelection.Focus(New SourceGrid.Position(FocusedRow, value))
   End Set
  End Property

  <DefaultValue(0)> _
  Public Overloads Property StartTime() As Double Implements models.subtitles.ISubtitlesGrid.StartTime
   Get
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     Return fSubtitles.Item(row - 1).StartTime
    Else
     Return fTime 'return current time if no subtitle entry at this time
    End If
   End Get
   Set(ByVal value As Double)
    Dim row As Integer = FocusedRow
    If row <= 0 Then 'skip header row
     Dim index As Integer = fSubtitles.FindCurrentOrNextIndexByTime(value)
     If index <> -1 Then row = index + 1 Else Exit Property
    End If
    fSubtitles.Item(row - 1).StartTime = value
    SetTime(value, row, colStartTime)
    SetTime(fSubtitles.Item(row - 1).Duration, row, colDuration)
    Modified = True
   End Set
  End Property

  <DefaultValue(0)> _
  Public Overloads Property EndTime() As Double Implements models.subtitles.ISubtitlesGrid.EndTime
   Get
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     Return fSubtitles.Item(row - 1).EndTime
    Else
     Return fTime 'return current time if no subtitle entry at this time
    End If
   End Get
   Set(ByVal value As Double)
    Dim row As Integer = FocusedRow
    If row <= 0 Then 'skip header row
     Dim index As Integer = fSubtitles.FindCurrentOrPreviousIndexByTime(value)
     If index <> -1 Then row = index + 1 Else Exit Property
    End If
    fSubtitles.Item(row - 1).EndTime = value
    SetTime(value, row, colEndTime)
    SetTime(fSubtitles.Item(row - 1).Duration, row, colDuration)
    Modified = True
   End Set
  End Property

  <DefaultValue(0)> _
  Public Property Time() As Double Implements ISubtitlesGrid.Time
   Get
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     Return fSubtitles.Item(row - 1).StartTime
    Else
     Return fTime
    End If
   End Get
   Set(ByVal value As Double) 'do not check if value<>Time, else the current row wouldn't be selected when we start playing
    fTime = value
    If fSelection Is Nothing Then Exit Property

    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     If fSubtitles.Item(row - 1).IsTimeIncluded(value) Then Exit Property 'currently focused row already contains the given time (must check this in case there are multiple rows that have overlap so that we don't change the focused row)
    End If

    Dim index As Integer = fSubtitles.FindIndexByTime(value)
    If (index <> -1) Then
     If fSelection.ActivePosition.Row <> index + 1 Then
      updatingTime = True
      FocusedRow = index + 1 'setting the focus only if it isn't currently set at the same line, so that we can see the editors if needed
      updatingTime = False
     End If
    Else
     FocusedRow = -1 'unfocus
    End If
   End Set
  End Property

  Public ReadOnly Property Subtitles() As ISubtitles Implements ISubtitlesGrid.Subtitles
   Get
    Return fSubtitles
   End Get
  End Property

  Protected ReadOnly Property CurrentSubtitle() As ISubtitle
   Get
    If fSelection Is Nothing Then Return Nothing
    Dim pos As Integer = fSelection.ActivePosition.Row
    If pos < 1 Then Return Nothing 'ignore header
    Return Subtitles.Item(pos - 1)
   End Get
  End Property

  <DefaultValue("")> _
  Public Overloads Property Subtitle1() As String Implements ISubtitlesGrid.Subtitle1
   Get
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     Return fSubtitles.Item(row - 1).Subtitle1
    Else
     Return ""
    End If
   End Get
   Set(ByVal value As String)
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     fSubtitles.Item(row - 1).Subtitle1 = value
     SetSubtitles(value, Subtitle2, row, colSubtitles)
    End If
   End Set
  End Property

  <DefaultValue("")> _
  Public Overloads Property Subtitle1(ByVal theTime As Double) As String Implements ISubtitlesGrid.Subtitle1
   Get
    Dim index As Integer = fSubtitles.FindIndexByTime(theTime)
    If index <> -1 Then
     Return fSubtitles.Item(index).Subtitle1
    Else
     Return ""
    End If
   End Get
   Set(ByVal value As String)
    Dim index As Integer = fSubtitles.FindIndexByTime(theTime)
    If index <> -1 Then
     fSubtitles.Item(index).Subtitle1 = value
     SetSubtitles(value, Subtitle2, index + 1, colSubtitles)
    Else
     InsertSubtitle(theTime, theTime + DEFAULT_NEW_SUBTITLE_DURATION, value, "")
    End If
   End Set
  End Property

  <DefaultValue("")> _
  Public Overloads Property Subtitle2() As String Implements ISubtitlesGrid.Subtitle2
   Get
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     Return fSubtitles.Item(row - 1).Subtitle2
    Else
     Return ""
    End If
   End Get
   Set(ByVal value As String)
    Dim row As Integer = FocusedRow
    If row > 0 Then 'skip header row
     fSubtitles.Item(row - 1).Subtitle2 = value
     SetSubtitles(Subtitle1, value, row, colSubtitles)
    End If
   End Set
  End Property

  <DefaultValue("")> _
  Public Overloads Property Subtitle2(ByVal theTime As Double) As String Implements ISubtitlesGrid.Subtitle2
   Get
    Dim index As Integer = fSubtitles.FindIndexByTime(theTime)
    If index <> -1 Then
     Return fSubtitles.Item(index).Subtitle2
    Else
     Return ""
    End If
   End Get
   Set(ByVal value As String)
    Dim index As Integer = fSubtitles.FindIndexByTime(theTime)
    If index <> -1 Then
     fSubtitles.Item(index).Subtitle2 = value
     SetSubtitles(Subtitle1, value, index + 1, colSubtitles)
    Else
     InsertSubtitle(theTime, theTime + DEFAULT_NEW_SUBTITLE_DURATION, "", value)
    End If
   End Set
  End Property

  <DefaultValue(True)> _
  Public Property ColumnIndexVisible() As Boolean Implements ISubtitlesGrid.ColumnIndexVisible
   Get
    Return gridSubtitles.Columns(colIndex).Width <> 0
   End Get
   Set(ByVal value As Boolean)
    If value Then gridSubtitles.Columns(colIndex).Width = DEFAULT_INDEX_COLUMN_WIDTH
   End Set
  End Property

  <DefaultValue(True)> _
  Public Property ColumnStartTimeVisible() As Boolean Implements ISubtitlesGrid.ColumnStartTimeVisible
   Get
    Return gridSubtitles.Columns(colStartTime).Width <> 0
   End Get
   Set(ByVal value As Boolean)
    If value Then gridSubtitles.Columns(colStartTime).Width = DEFAULT_TIME_COLUMN_WIDTH
   End Set
  End Property

  <DefaultValue(True)> _
  Public Property ColumnEndTimeVisible() As Boolean Implements ISubtitlesGrid.ColumnEndTimeVisible
   Get
    Return gridSubtitles.Columns(colEndTime).Width <> 0
   End Get
   Set(ByVal value As Boolean)
    If value Then gridSubtitles.Columns(colEndTime).Width = DEFAULT_TIME_COLUMN_WIDTH
   End Set
  End Property

  <DefaultValue(True)> _
  Public Property ColumnDurationVisible() As Boolean Implements ISubtitlesGrid.ColumnDurationVisible
   Get
    Return gridSubtitles.Columns(colDuration).Width <> 0
   End Get
   Set(ByVal value As Boolean)
    If value Then gridSubtitles.Columns(colDuration).Width = DEFAULT_TIME_COLUMN_WIDTH
   End Set
  End Property

#End Region

#Region "Methods"

#Region "Constructor"

  Protected Sub InitColumnHeader(ByVal columnIndex As Integer, ByVal columnTitle As String)
   Dim Cell As ColumnHeader
   Cell = New ColumnHeaderNoSort(columnTitle)
   Cell.ToolTipText = columnTitle
   Cell.AddController(toolTipController)
   gridSubtitles.Item(HEADER_ROW, columnIndex) = Cell
  End Sub

  Public Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()

   ' Add any initialization after the InitializeComponent() call.
   fSelection = gridSubtitles.Selection

   editorStartTime.EnableEdit = fAuthoringMode
   editorEndTime.EnableEdit = fAuthoringMode
   editorDuration.EnableEdit = fAuthoringMode
   editorTeacherComment.EnableEdit = fAuthoringMode
   'editorStudentComment.EnableEdit = True 'always enable editing student comments

   Dim b As New DevAge.Drawing.Border(Color.Black, 1)
   Dim b2 As New DevAge.Drawing.Border(Color.Black, 2)
   Dim rb As New DevAge.Drawing.RectangleBorder(b, b)

   cellView.Border = rb
   cellView.AnchorArea = New DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.MiddleCenter, True)

   cellViewAuthoring.Border = rb
   cellViewAuthoring.AnchorArea = New DevAge.Drawing.AnchorArea(DevAge.Drawing.ContentAlignment.MiddleCenter, True)

   'toolTipController.ToolTipTitle = ""
   'toolTipController.ToolTipIcon = ToolTipIcon.None
   toolTipController.IsBalloon = True

   With gridSubtitles
    .SuspendLayout()
    .Selection.SelectionMode = SourceGrid.GridSelectionMode.Row
    .Selection.FocusStyle = SourceGrid.FocusStyle.None 'must do this so that grid keeps on drawing the selection when it has lost focus
    .Selection.FocusBackColor = Color.FromArgb(CInt(.Selection.BackColor.A * 2), .Selection.BackColor) 'drawing focused cell a bit darker than seleced ones (must always use a semi-transparent color)
    .Selection.BorderMode = SourceGrid.SelectionBorderMode.FocusCell 'draw border arround focused cell
    .Selection.Border = New DevAge.Drawing.RectangleBorder(b, b2, b, b2)

    .ColumnsCount = 7

    .Rows.Insert(0)
    InitColumnHeader(colIndex,"#")
    InitColumnHeader(colStartTime, My.Resources.STR_START_TIME)
    InitColumnHeader(colEndTime, My.Resources.STR_END_TIME)
    InitColumnHeader(colDuration, My.Resources.STR_DURATION)
    InitColumnHeader(colSubtitles, My.Resources.STR_SUBTITLE)
    InitColumnHeader(colTeacherComment, My.Resources.STR_TEACHER_COMMENT)
    InitColumnHeader(colStudentComment, My.Resources.STR_STUDENT_COMMENT)

    UpdateIndex()

    .ResumeLayout(False)
   End With
  End Sub

#End Region

#Region "Load"

		Protected Function LoadSubtitles(ByVal path As String) As Boolean
			fSubtitles.Clear()	'the above should be done automatically if using a virtual grid (may need just repaint) or vice-versa if using events to sync with grid
			Try
				fSubtitles.Source = path
				CopySubtitlesToGrid()
				Return True
			Catch e As Exception
    DevAge.Windows.Forms.ErrorDialog.Show(e, My.Resources.STR_ERROR) 'show error dialog with exception details
				Return False
			End Try
		End Function

#End Region

#Region "Save"

  Public Sub Save() Implements ISubtitlesGrid.Save
   Export(Source, Encoding.Unicode) 'always saving with Unicode (UTF-16, little endian) encoding internally
   Modified = False
  End Sub

#End Region

#Region "Export"

  Public Sub Export(ByVal path As String, ByVal encoding As Encoding) Implements ISubtitlesGrid.Export
   If FileUtils.CheckExtension(path, DocumentUtils.EXTENSION_CSV) IsNot Nothing Then
    ExportCSV(path, encoding.Default)
   ElseIf FileUtils.CheckExtension(path, New String() {DocumentUtils.EXTENSION_HTML, DocumentUtils.EXTENSION_HTM}) IsNot Nothing Then
    ExportHTML(path)
   Else
    SubtitleUtils.WriteSubtitles(Subtitles, path, encoding)
   End If
  End Sub

  Protected Sub ExportCSV(ByVal path As String, ByVal encoding As Encoding)
   Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(path, False, encoding)
    Dim csv As New SourceGrid.Exporter.CSV()
    csv.Export(gridSubtitles, writer)
    writer.Close()
   End Using
  End Sub

  Protected Sub ExportHTML(ByVal path As String)
   Using l_Stream As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write)
    Dim html As New SourceGrid.Exporter.HTML(SourceGrid.Exporter.ExportHTMLMode.Default, IO.Path.GetDirectoryName(path), "", l_Stream) 'save images?
    html.Export(gridSubtitles)
    l_Stream.Close()
   End Using
  End Sub

#End Region

#Region "Misc"

  Protected Sub CopySubtitlesToGrid()
   If fSubtitles Is Nothing Then Exit Sub
   With gridSubtitles
    Try
     If .Rows.Count > 1 Then .Rows.RemoveRange(1, .Rows.Count - 1) 'preserve the header row
    Catch
     'ignore?
    End Try
    Dim i As Integer = 1 'skip header row
    For Each subtitle As ISubtitle In fSubtitles
     InsertNewRow()

     SetIndex(i, i, colIndex)
     With subtitle
      SetTime(.StartTime, i, colStartTime) 'could use other basetime at SetTime if wish to offset times
      SetTime(.EndTime, i, colEndTime)
      SetTime(.Duration, i, colDuration)
      SetSubtitles(.Subtitle1, .Subtitle2, i, colSubtitles)
      SetComment(.TeacherCommentIcon, .TeacherComment, i, colTeacherComment)
      SetComment(.StudentCommentIcon, .StudentComment, i, colStudentComment)
     End With

     i += 1
    Next
   End With
  End Sub

  Protected Sub UpdateIndex()
   With gridSubtitles
    For i As Integer = 1 To .Rows.Count - 1 'do not change text at row 0
     SetIndex(i, i, colIndex)
    Next i
   End With
  End Sub

  Protected Overloads Function InsertNewRow() As Integer 'does not update the index, must update separately
   With gridSubtitles
    Dim pos As SourceGrid.Position = .Selection.ActivePosition
    Dim row As Integer
    If (pos.Row < 0) Then row = .Rows.Count Else row = pos.Row + 1
    Return InsertNewRow(row)
   End With
  End Function

  Protected Overloads Function InsertNewRow(ByVal row As Integer) As Integer 'does not update the index, must update separately
   With gridSubtitles
    .Rows.Insert(row)

    .Rows(row).Height = ROW_HEIGHT

    Dim cell As ICell

    cell = New RowHeader
    'cell.ToolTipText = "" 'will set tooltip to "#index" later using "SetIndex"
    cell.AddController(toolTipController)
    .Item(row, colIndex) = cell

    cell = New Cell(DATETIMEZERO)
    cell.View = cellView
    cell.Editor = editorStartTime
    cell.ToolTipText = DATETIMEZERO.ToString(UpDownTime.DEFAULT_FORMAT)
    cell.AddController(toolTipController)
    .Item(row, colStartTime) = cell

    cell = New Cell(DATETIMEZERO)
    cell.View = cellViewAuthoring
    cell.Editor = editorEndTime
    cell.ToolTipText = DATETIMEZERO.ToString(UpDownTime.DEFAULT_FORMAT)
    cell.AddController(toolTipController)
    .Item(row, colEndTime) = cell

    cell = New Cell(DATETIMEZERO)
    cell.View = cellView
    cell.Editor = editorDuration
    cell.ToolTipText = DATETIMEZERO.ToString(UpDownTime.DEFAULT_FORMAT)
    cell.AddController(toolTipController)
    .Item(row, colDuration) = cell

				Dim SubtitlesCol As New TextLinePair
    SubtitlesCol.BorderStyle = BorderStyle.None
    cell = New Cell("")
    cell.View = cellView
    cell.Editor = editorSubtitlePair
    'cell.ToolTipText = ""
    cell.AddController(toolTipController)
    .Item(row, colSubtitles) = cell

    cell = New Cell("")
    cell.View = cellView
    cell.Editor = editorTeacherComment
    'cell.ToolTipText = ""
    cell.AddController(toolTipController)
    .Item(row, colTeacherComment) = cell

    cell = New Cell("")
    cell.View = cellView
    cell.Editor = editorStudentComment
    'cell.ToolTipText = ""
    cell.AddController(toolTipController)
    .Item(row, colStudentComment) = cell

    Return row
   End With
  End Function

  Private Sub resizeColumns()
   With gridSubtitles
    If .ColumnsCount = 0 Then Exit Sub
    .Columns(colIndex).Width = DEFAULT_INDEX_COLUMN_WIDTH
    .Columns(colStartTime).Width = DEFAULT_TIME_COLUMN_WIDTH
    Dim endTimeColumnWidth As Integer = 0
    If AuthoringMode Then endTimeColumnWidth = DEFAULT_TIME_COLUMN_WIDTH
    .Columns(colEndTime).Width = endTimeColumnWidth
    .Columns(colDuration).Width = DEFAULT_TIME_COLUMN_WIDTH
    .Columns(colTeacherComment).Width = iconDropDown.Width
    .Columns(colStudentComment).Width = iconDropDown.Width
    Dim timesWidth As Integer = 2 * DEFAULT_TIME_COLUMN_WIDTH + endTimeColumnWidth
    .Columns(colSubtitles).Width = Math.Max(MIN_SUBTITLES_COLUMN_WIDTH, .ClientSize.Width - .Columns(colIndex).Width - timesWidth - .Columns(colTeacherComment).Width - .Columns(colStudentComment).Width - SystemInformation.VerticalScrollBarWidth) 'don't count any hidden columns
   End With
  End Sub

#End Region

#Region "Grid cell update helpers"

  Protected Sub SetIndex(ByVal theIndex As Integer, ByVal theRow As Integer, ByVal theColumn As Integer)
   With gridSubtitles.Item(theRow, theColumn)
    .Value = theIndex
    .ToolTipText = "#" & theIndex
   End With
  End Sub

  Protected Sub SetTime(ByVal theTime As DateTime, ByVal theRow As Integer, ByVal theColumn As Integer)
   With gridSubtitles.Item(theRow, theColumn)
    .Value = theTime
    .ToolTipText = theTime.ToString(UpDownTime.DEFAULT_FORMAT)
   End With
  End Sub

  Protected Sub SetTime(ByVal theTime As Double, ByVal theRow As Integer, ByVal theColumn As Integer)
   SetTime(DateTimeUtils.SecondsToDateTime(theTime, DATETIMEZERO, SignificantDigits), theRow, theColumn) 'could use other basetime if wish to offset times
  End Sub

  Protected Sub SetSubtitles(ByVal theSubtitle1 As String, ByVal theSubtitle2 As String, ByVal theRow As Integer, ByVal theColumn As Integer)
   With gridSubtitles.Item(theRow, theColumn)
    Dim s As String = theSubtitle1 & vbCrLf & theSubtitle2
    .Value = s
    If s = vbCrLf Then .ToolTipText = "" Else .ToolTipText = s 'the tooltip shows cropped at the right side sometimes (tried using either vbCrLf and vbCr, but both show the same problem)
   End With
  End Sub

  Protected Sub SetComment(ByVal theCommentIconIndex As Integer, ByVal theComment As String, ByVal theRow As Integer, ByVal theColumn As Integer)
   iconDropDown.Value = theCommentIconIndex
   With gridSubtitles.Item(theRow, theColumn)
    .Image = iconDropDown.SelectedImage
    If theComment = vbCrLf Then .ToolTipText = "" Else .ToolTipText = theComment
   End With
  End Sub

#End Region

#Region "ISubtitlesGrid methods"

  Sub InsertSubtitle(ByVal theStartTime As Double, ByVal theEndTime As Double, ByVal theSubtitle1 As String, ByVal theSubtitle2 As String) Implements ISubtitlesGrid.InsertSubtitle
   Dim index As Integer = fSubtitles.FindCurrentOrPreviousIndexByTime(theStartTime) 'find nearest previous row for given start time
   Dim row As Integer
   If (fSubtitles.Count > 0) AndAlso (theStartTime < fSubtitles.Item(0).StartTime) Then 'if want to insert at time before the 1st subtitle (if any)
    row = 1 'ignore header row
   ElseIf index = -1 Then
    row = gridSubtitles.Rows.Count 'if not found then append row
   ElseIf theStartTime = fSubtitles.Item(index).StartTime Then
    row = index + 1 'if exactly at start time of a subtitle then insert row before it...
   Else
    row = index + 2 '...else insert row after it
   End If
   InsertNewRow(row) 'if not found add a new row
   Dim subtitle As ISubtitle = fSubtitles.NewSubtitle(theStartTime, theEndTime)
   With subtitle
    .Subtitle1 = theSubtitle1
    .Subtitle2 = theSubtitle2
   End With
   fSubtitles.Insert(row - 1, subtitle)
   With gridSubtitles
    SetTime(theStartTime, row, colStartTime)
    SetTime(theEndTime, row, colEndTime)
    SetTime(subtitle.Duration, row, colDuration) 'duration is autocalculated by subtitle object
    SetSubtitles(theSubtitle1, theSubtitle2, row, colSubtitles)
    SetComment(-1, "", row, colTeacherComment)
    SetComment(-1, "", row, colStudentComment)
   End With
   UpdateIndex()
   Modified = True
   RaiseEvent SubtitleInserted(Me, row)
   FocusedRow = row 'select the row after inserting subtitle
  End Sub

  Public Sub RemoveSelected() Implements ISubtitlesGrid.RemoveSelected
   With gridSubtitles
    Dim topSelectedRow As Integer = 1 'used to find the 1st selected row
    For row As Integer = .RowsCount - 1 To 1 Step -1 'ignore header
     If .Selection.ContainsRow(row) Then
      topSelectedRow = row
      gridSubtitles.Rows.Remove(row) 'first remove from the grid...
      fSubtitles.RemoveAt(row - 1) '...then remove from the subtitles else the cell focus lost event will cause errors
      UpdateIndex()
      Modified = True
      RaiseEvent SubtitleRemoved(Me, row)
     End If
    Next
    .Selection.SelectRow(topSelectedRow - 1, True) 'move to the line before the selection's start (there's always 1: the header) 'hope header can be selected, if not handle with try/catch
   End With
  End Sub

  Public Sub ChangeTeacherComment(ByVal theRow As Integer) Implements ISubtitlesGrid.ChangeTeacherComment
   gridSubtitles.Item(theRow, colTeacherComment).ToolTipText = fSubtitles.Item(theRow - 1).TeacherComment
   'no need to talk to fSubtitles too (it's already been updated), just update the grid
  End Sub

  Public Sub ChangeStudentComment(ByVal theRow As Integer) Implements ISubtitlesGrid.ChangeStudentComment
   gridSubtitles.Item(theRow, colStudentComment).ToolTipText = fSubtitles.Item(theRow - 1).StudentComment
   'no need to talk to fSubtitles too (it's already been updated), just update the grid
  End Sub

  Public Sub UpdateComments() Implements ISubtitlesGrid.UpdateComments
   With gridSubtitles
    For i As Integer = 1 To .Rows.Count - 1 'do not change text at row 0
     With fSubtitles.Item(i - 1)
      SetComment(.TeacherCommentIcon, .TeacherComment, i, colTeacherComment)
      SetComment(.StudentCommentIcon, .StudentComment, i, colStudentComment)
     End With
    Next i
   End With
  End Sub

#End Region

#End Region

#Region "Events"

  Private Sub gridSubtitles_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles gridSubtitles.Layout
   resizeColumns()
		End Sub

#Region "Selection events"

		Private Sub fSelection_CellGotFocus(ByVal sender As SourceGrid.Selection, ByVal e As SourceGrid.ChangeActivePositionEventArgs) Handles fSelection.CellGotFocus
			With e.NewFocusPosition
				If (.Row < 1) OrElse (.Row > gridSubtitles.Rows.Count - 1) Then Exit Sub 'ignore header row 'check the upper bound too just in case
				Select Case .Column
					Case colStartTime
						If Not updatingTime Then RaiseEvent TimeChanged(Me, DateTimeToSeconds(CType(gridSubtitles(.Row, .Column).Value, DateTime), DATETIMEZERO, SignificantDigits))
					Case colEndTime
						If Not updatingTime Then RaiseEvent TimeChanged(Me, DateTimeToSeconds(CType(gridSubtitles(.Row, .Column).Value, DateTime), DATETIMEZERO, SignificantDigits))
					Case colTeacherComment
						gridSubtitles(.Row, .Column).Value = fSubtitles.Item(.Row - 1).TeacherCommentIcon	'using -1 cause grid also has a header row
						RaiseEvent FocusedColumnChanged(Me, colTeacherComment)
					Case colStudentComment
						gridSubtitles(.Row, .Column).Value = fSubtitles.Item(.Row - 1).StudentCommentIcon	'using -1 cause grid also has a header row
						RaiseEvent FocusedColumnChanged(Me, colStudentComment)
				End Select
			End With
		End Sub

		Private Sub fSelection_CellLostFocus(ByVal sender As SourceGrid.Selection, ByVal e As SourceGrid.ChangeActivePositionEventArgs) Handles fSelection.CellLostFocus
			With e.OldFocusPosition
				Select Case .Column
					Case colTeacherComment, colStudentComment
						gridSubtitles(.Row, .Column).Value = ""	'needed for any comment columns that are read-only
				End Select
			End With
		End Sub

		Private Sub fSelection_FocusRowEntered(ByVal sender As Object, ByVal e As SourceGrid.RowEventArgs) Handles fSelection.FocusRowEntered
			If Not updatingTime Then RaiseEvent TimeChanged(Me, fSubtitles.Item(e.Row - 1).StartTime)
			RaiseEvent FocusedRowChanged(Me, e.Row)
		End Sub

#End Region

#Region "Validation events"

		Private Sub editorStartTime_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorStartTime.Validated
			With e.CellContext.Position
				Try
					Dim newValue As Double = DateTimeToSeconds(CType(gridSubtitles(.Row, .Column).Value, DateTime), DATETIMEZERO, SignificantDigits)
					If (newValue <> fSubtitles.Item(.Row - 1).StartTime) Then
						fSubtitles.Item(.Row - 1).StartTime = newValue
						SetTime(fSubtitles.Item(.Row - 1).Duration, .Row, colDuration)	'since we changed StartTime, we must autoupdate Duration
						Modified = True	'mark document as modified if changed succesfully
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, My.Resources.STR_INVALID_VALUE)
					SetTime(fSubtitles.Item(.Row - 1).StartTime, .Row, colStartTime)	'restore StartTime value if it was not accepted
				End Try
			End With
		End Sub

		Private Sub editorEndTime_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorEndTime.Validated
			With e.CellContext.Position
				Try
					Dim newValue As Double = DateTimeToSeconds(CType(gridSubtitles(.Row, .Column).Value, DateTime), DATETIMEZERO, SignificantDigits)
					If (newValue <> fSubtitles.Item(.Row - 1).EndTime) Then
						fSubtitles.Item(.Row - 1).EndTime = newValue
						SetTime(fSubtitles.Item(.Row - 1).Duration, .Row, colDuration)	'since we changed StartTime, we must autoupdate Duration
						Modified = True	'mark document as modified if changed succesfully
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, My.Resources.STR_INVALID_VALUE)
					SetTime(fSubtitles.Item(.Row - 1).EndTime, .Row, colEndTime)	'restore EndTime value if it was not accepted
				End Try
			End With
		End Sub

		Private Sub editorDuration_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorDuration.Validated
			With e.CellContext.Position
				Try
					Dim newValue As Double = DateTimeToSeconds(CType(gridSubtitles(.Row, .Column).Value, DateTime), DATETIMEZERO, SignificantDigits)
					If (newValue <> fSubtitles.Item(.Row - 1).Duration) Then
						fSubtitles.Item(.Row - 1).Duration = newValue
						SetTime(fSubtitles.Item(.Row - 1).EndTime, .Row, colEndTime)	'since we changed Duration, we must autoupdate the EndTime
						Modified = True	'mark document as modified if changed succesfully
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, My.Resources.STR_INVALID_VALUE)
					SetTime(fSubtitles.Item(.Row - 1).Duration, .Row, colDuration)	'restore Duration value if it was not accepted
				End Try
			End With
		End Sub

		Private Sub editorSubtitlePair_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorSubtitlePair.Validated
			With e.CellContext.Position
				Dim subtitles As String() = Split(CStr(gridSubtitles(.Row, .Column).Value), vbCrLf)

				Dim newSubtitle1 As String = subtitles(0)
				If newSubtitle1 <> fSubtitles.Item(.Row - 1).Subtitle1 Then
					fSubtitles.Item(.Row - 1).Subtitle1 = newSubtitle1
					Modified = True	'mark document as modified if changed succesfully
				End If

				Dim newSubtitle2 As String = ""
				If subtitles.Length > 1 Then newSubtitle2 = subtitles(1)
				If (newSubtitle2 <> fSubtitles.Item(.Row - 1).Subtitle2) Then
					fSubtitles.Item(.Row - 1).Subtitle2 = newSubtitle2
					Modified = True	'mark document as modified if changed succesfully
				End If

			End With
		End Sub

		Private Sub editorTeacherComment_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorTeacherComment.Validated
			With e.CellContext.Position
				Dim commentIcon As Integer = CInt(gridSubtitles(.Row, .Column).Value)	'using -1 cause grid also has a header row
				If (commentIcon <> fSubtitles.Item(.Row - 1).TeacherCommentIcon) Then
					If commentIcon > 0 Then	'check for both -1 and 0
						fSubtitles.Item(.Row - 1).TeacherCommentIcon = commentIcon	'keep this command inside the "if" block
						Modified = True	'mark document as modified if changed succesfully
						RaiseEvent TeacherCommentChanged(Me, .Row)
					ElseIf (fSubtitles.Item(.Row - 1).TeacherCommentIcon > 0) Then
						If MessageBox.Show(My.Resources.STR_REMOVE_SUBTITLE_TEACHER_COMMENT, My.Resources.STR_WARNING, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.OK Then	'using short-circuit boolean evaluation ("AndAlso" instead of "And") here so that the dialog isn't shown if comment icon was already empty
							fSubtitles.Item(.Row - 1).TeacherCommentIcon = commentIcon	'keep this command inside the "if" block
							Modified = True	'mark document as modified if changed succesfully
							RaiseEvent TeacherCommentRemoved(Me, .Row)
						Else
							SetComment(fSubtitles.Item(.Row - 1).TeacherCommentIcon, fSubtitles.Item(.Row - 1).TeacherComment, .Row, colTeacherComment)	'restore comment icon (assuming at CommentEditor's OnValidated method, MyBase.OnValidated is called last)
						End If
					End If
				End If
				gridSubtitles(.Row, .Column).Value = ""
			End With
		End Sub

		Private Sub editorStudentComment_Validated(ByVal sender As Object, ByVal e As SourceGrid.CellContextEventArgs) Handles editorStudentComment.Validated
			With e.CellContext.Position
				Dim commentIcon As Integer = CInt(gridSubtitles(.Row, .Column).Value)	'using -1 cause grid also has a header row
				If (commentIcon <> fSubtitles.Item(.Row - 1).StudentCommentIcon) Then
					If commentIcon > 0 Then	'check for both -1 and 0
						fSubtitles.Item(.Row - 1).StudentCommentIcon = commentIcon	'keep this command inside the "if" block
						Modified = True	'mark document as modified if changed succesfully
						RaiseEvent StudentCommentChanged(Me, .Row)
					ElseIf (fSubtitles.Item(.Row - 1).StudentCommentIcon > 0) Then
						If MessageBox.Show(My.Resources.STR_REMOVE_SUBTITLE_STUDENT_COMMENT, My.Resources.STR_WARNING, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.OK Then	'using short-circuit boolean evaluation ("AndAlso" instead of "And") here so that the dialog isn't shown if comment icon was already empty
							fSubtitles.Item(.Row - 1).StudentCommentIcon = commentIcon	'keep this command inside the "if" block
							Modified = True	'mark document as modified if changed succesfully
							RaiseEvent StudentCommentRemoved(Me, .Row)
						Else
							SetComment(fSubtitles.Item(.Row - 1).StudentCommentIcon, fSubtitles.Item(.Row - 1).StudentComment, .Row, colStudentComment)	'restore comment icon (assuming at CommentEditor's OnValidated method, MyBase.OnValidated is called last)
						End If
					End If
				End If
				gridSubtitles(.Row, .Column).Value = ""
			End With
		End Sub

#End Region

		Public Event ModifiedChanged(ByVal source As models.IModifiable, ByVal newModifiedFlag As Boolean) Implements models.IModifiable.ModifiedChanged
		Public Event TimeChanged(ByVal source As ISubtitlesGrid, ByVal newTime As Double) Implements ISubtitlesGrid.TimeChanged
		Public Event FocusedRowChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.FocusedRowChanged
		Public Event FocusedColumnChanged(ByVal source As ISubtitlesGrid, ByVal theColumn As ISubtitlesGrid.Columns) Implements ISubtitlesGrid.FocusedColumnChanged

		Public Event SubtitleInserted(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.SubtitleInserted
		Public Event SubtitleRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.SubtitleRemoved
		Public Event TeacherCommentChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.TeacherCommentChanged
		Public Event TeacherCommentRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.TeacherCommentRemoved
		Public Event StudentCommentChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.StudentCommentChanged
		Public Event StudentCommentRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer) Implements ISubtitlesGrid.StudentCommentRemoved

#End Region

 End Class

End Namespace
