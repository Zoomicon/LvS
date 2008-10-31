'Description: IDocument interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070329

Imports System.Text

Namespace LvS.models.documents

 Public Interface IDocument
  Inherits IModifiable

#Region "Properties"

  Property AuthoringMode() As Boolean
  Property Source() As String
  Property Encoding() As Encoding
  Property Title() As String

#End Region

#Region "Methods"

  Sub Save()
  Sub Export(ByVal path As String)
  Sub Close()

#End Region

#Region "Events"

  Event TitleChanged(ByVal source As IDocument, ByVal newTitle As String)

#End Region

 End Interface

End Namespace
