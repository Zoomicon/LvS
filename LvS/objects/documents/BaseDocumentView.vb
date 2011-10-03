'Description: BaseDocumentView class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.Text
Imports LvS.models
Imports LvS.models.documents
Imports LvS.utilities.DebugUtils

Namespace LvS.objects.documents

 Public Class BaseDocumentView
  Implements IDocument

#Region "Fields"

		Protected fAuthoringMode As Boolean	'= False
  Protected fSource As String
  Protected fEncoding As Encoding = Encoding.Unicode
  Protected fTitle As String

#End Region

#Region "Properties"

  Public Property AuthoringMode() As Boolean Implements IDocument.AuthoringMode
   Get
    Return fAuthoringMode
   End Get
   Set(ByVal value As Boolean)
    If value <> fAuthoringMode Then
     fAuthoringMode = value
     OnAuthoringModeChanged()
    End If
   End Set
  End Property

  Public Overridable Property Modified() As Boolean Implements models.documents.IDocument.Modified
   Get
    NotImplemented()
    Return False
   End Get
   Set(ByVal value As Boolean)
    NotImplemented()
   End Set
  End Property

  Public Overridable Property Source() As String Implements models.documents.IDocument.Source
   Get
    NotImplemented()
    Return ""
   End Get
   Set(ByVal value As String)
    NotImplemented()
   End Set
  End Property

  Public Overridable Property Encoding() As Encoding Implements IDocument.Encoding
   Get
    Return fEncoding
   End Get
   Set(ByVal value As Encoding)
    fEncoding = value
   End Set
  End Property

  Public Overridable Property Title() As String Implements models.documents.IDocument.Title
   Get
    Return fTitle
   End Get
   Set(ByVal value As String)
    If value <> fTitle Then
     fTitle = value
     RaiseEvent TitleChanged(Me, value)
    End If
    fTitle = value
   End Set
  End Property

#End Region

#Region "Methods"

  Public Overridable Sub OnAuthoringModeChanged()
   'do nothing (can override at descendents)
  End Sub

  Public Overridable Sub Save() Implements IDocument.Save
   NotImplemented()
  End Sub

  Public Overridable Sub Export(ByVal path As String) Implements IDocument.Export
   NotImplemented()
  End Sub

  Public Overridable Sub Close() Implements IDocument.Close
   NotImplemented()
  End Sub

  Public Sub RaiseTitleChanged()
   RaiseEvent TitleChanged(Me, Title)
  End Sub

  Public Sub RaiseModifiedChanged()
   RaiseEvent ModifiedChanged(Me, Modified)
  End Sub

#End Region

#Region "Events"

  Public Event TitleChanged(ByVal source As models.documents.IDocument, ByVal newTitle As String) Implements IDocument.TitleChanged
  Public Event ModifiedChanged(ByVal source As IModifiable, ByVal newModifiedFlag As Boolean) Implements IDocument.ModifiedChanged

#End Region

 End Class

End Namespace
