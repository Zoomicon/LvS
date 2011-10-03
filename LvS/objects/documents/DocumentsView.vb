'Description: DocumentsView class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.Text
Imports System.ComponentModel
Imports LvS.models
Imports LvS.models.documents
Imports LvS.utilities.documents
Imports LvS.utilities.FileUtils
Imports LvS.utilities.FormUtils

Namespace LvS.objects.documents

 Public Class DocumentsView
  Implements IDocuments

#Region "Fields"

  Protected fDocuments As New List(Of IDocument)
		Protected fAuthoringMode As Boolean	'= False

#End Region

#Region "Properties"

  Public Property AuthoringMode() As Boolean Implements IDocuments.AuthoringMode
   Get
    Return fAuthoringMode
   End Get
   Set(ByVal value As Boolean)
    If value <> fAuthoringMode Then
     For Each d As IDocument In fDocuments
      CType(d, BaseDocumentView).AuthoringMode = value
     Next
    End If
    fAuthoringMode = value
   End Set
  End Property

  Public Property Modified() As Boolean Implements IDocuments.Modified
   Get
    Dim result As Boolean = False
    For Each d As IDocument In Me
     result = result OrElse d.Modified
    Next
    Return result
   End Get
   Set(ByVal value As Boolean)
    For Each d As IDocument In Me
     d.Modified = value
    Next
   End Set
  End Property

  Public Property SelectedIndex() As Integer Implements IDocuments.SelectedIndex
   Get
    Return tabDocuments.SelectedIndex
   End Get
   Set(ByVal value As Integer)
    tabDocuments.SelectedIndex = value
   End Set
  End Property

  Public ReadOnly Property CurrentDocument() As IDocument Implements IDocuments.CurrentDocument
   Get
    If tabDocuments.SelectedIndex > -1 Then Return fDocuments.Item(tabDocuments.SelectedIndex) 'the tabs and the documents are kept at the same order at "Add" method
    Return Nothing 'if no selection
   End Get
  End Property

#End Region

#Region "Methods"

  Public Sub SelectFirstdocument() Implements IDocuments.SelectFirstDocument
   If tabDocuments.TabCount <> 0 Then tabDocuments.SelectedIndex = 0
  End Sub

  Public Function IsDocumentLoaded(ByVal source As String) As Boolean Implements IDocuments.IsDocumentLoaded
   Return tabDocuments.TabPages.ContainsKey(source)
  End Function

		Public Function LoadDocument(ByVal source As String, ByVal theTitle As String, ByVal theEncoding As Encoding) As IDocument Implements IDocuments.LoadDocument
			If IsDocumentLoaded(source) Then Return Nothing
			Dim d As IDocument = DocumentUtils.getDocumentView(source, theEncoding)
			If d IsNot Nothing Then
				With d
					.AuthoringMode = AuthoringMode
					.Title = theTitle
				End With
				Add(d)	'do not add directly to fDocuments since we want a tab to be added too
			End If
			Return d
		End Function

  Public Sub LoadDocuments(ByVal folder As String, ByVal searchPattern As String) Implements IDocuments.LoadDocuments
   For Each f As String In GetDirectoryFiles(folder, searchPattern, IO.SearchOption.TopDirectoryOnly) 'do not load documents from subfolders, they may be sub-documents used by a master document (say an HTML page)
    Try
     Dim s As String = IO.Path.GetFileName(f)
     If s <> "TeacherNotes.rtf" AndAlso s <> "TeacherNotes.txt" AndAlso s <> "StudentNotes.rtf" AndAlso s <> "StudentNotes.txt" Then
      LoadDocument(f, IO.Path.GetFileNameWithoutExtension(f), Encoding.Unicode) 'all files saved internally are saved with Unicode (UTF-16, little endian)
     End If
    Catch e As Exception
					MessageBox.Show(Me, My.Resources.STR_LOAD_FILE_FAILED & " " & f & " (" & e.Message & ")")
    End Try
   Next f
  End Sub

  Public Sub SaveAll() Implements IDocuments.SaveAll
   For Each d As IDocument In Me
    Try
     d.Save() 'do not check if document was modified, the document will judge for itself if it really needs to save or not
    Catch e As Exception
					MessageBox.Show(Me, My.Resources.STR_SAVE_FILE_FAILED & " " & d.Source & " (" & e.Message & ")")
    End Try
   Next
  End Sub

  Public Sub ExportCurrentDocument(ByVal path As String) Implements IDocuments.ExportCurrentDocument
   Dim d As IDocument = CurrentDocument
   If d IsNot Nothing Then d.Export(path)
  End Sub

#Region "Collection"

  Public Sub Add(ByVal item As IDocument) Implements System.Collections.Generic.ICollection(Of IDocument).Add
   With item
    If IsDocumentLoaded(.Source) Then Exit Sub 'do not load the same document multiple times (we're using its filename as a key)
    Visible = True 'show the component if it has tabs
    Dim insertIndex As Integer = findTabSortPosition(tabDocuments.TabPages, .Source)
    tabDocuments.TabPages.Insert(insertIndex, .Source, .Title)
    Dim page As TabPage = tabDocuments.TabPages.Item(.Source)
    tabDocuments.SelectedTab = page 'select the newly created tab
    page.ToolTipText = IO.Path.GetFileName(.Source)
    Dim dc As Control = CType(item, Control)
    dc.Dock = DockStyle.Fill
    page.Controls.Add(dc)
    fDocuments.Insert(insertIndex, item)
   End With
  End Sub

  Public Sub Clear() Implements System.Collections.Generic.ICollection(Of IDocument).Clear, IDocuments.CloseAll
   For i As Integer = Count - 1 To 0 Step -1
    Me.Remove(fDocuments.Item(i)) 'this will make sure the tab is removed as well (don't call fDocuments.Remove)
   Next
  End Sub

  Public Function ContainsIDocument(ByVal item As IDocument) As Boolean Implements System.Collections.Generic.ICollection(Of IDocument).Contains
   Return fDocuments.Contains(item)
  End Function

  Public Sub CopyTo(ByVal array() As IDocument, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of IDocument).CopyTo
   fDocuments.CopyTo(array, arrayIndex)
  End Sub

  Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of IDocument).Count
   Get
    Return fDocuments.Count
   End Get
  End Property

  Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of IDocument).IsReadOnly
   Get
    Return False
   End Get
  End Property

  Public Function Remove(ByVal item As IDocument) As Boolean Implements System.Collections.Generic.ICollection(Of IDocument).Remove
   tabDocuments.TabPages.RemoveByKey(item.Source) 'must go before "Close"
   item.Close()
   Return fDocuments.Remove(item)
  End Function

  Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of IDocument) Implements System.Collections.Generic.IEnumerable(Of IDocument).GetEnumerator
   Return fDocuments.GetEnumerator
  End Function

  Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
   Return fDocuments.GetEnumerator
  End Function

#End Region

#End Region

#Region "Events"

  Public Event ModifiedChanged(ByVal source As IModifiable, ByVal newModifiedFlag As Boolean) Implements IDocuments.ModifiedChanged

#End Region

 End Class

End Namespace
