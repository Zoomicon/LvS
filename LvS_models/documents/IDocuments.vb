'Description: IDocuments interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.Text

Namespace LvS.models.documents

 Public Interface IDocuments
  Inherits ICollection(Of IDocument), IModifiable

#Region "Properties"

  Property AuthoringMode() As Boolean
  Property SelectedIndex() As Integer
  ReadOnly Property CurrentDocument() As IDocument

#End Region

#Region "Methods"

		Function IsDocumentLoaded(ByVal source As String) As Boolean
		Function LoadDocument(ByVal source As String, ByVal theTitle As String, ByVal theEncoding As Encoding) As IDocument	'returns Nothing if document already loaded
  Sub LoadDocuments(ByVal folder As String, ByVal searchPattern As String)
  Sub SaveAll()
  Sub ExportCurrentDocument(ByVal path As String)
  Sub CloseAll()
  Sub SelectFirstDocument()

#End Region

 End Interface

End Namespace
