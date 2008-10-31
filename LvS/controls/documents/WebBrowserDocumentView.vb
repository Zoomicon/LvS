'Description: WebBrowserDocumentView class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070413

Imports System.ComponentModel
Imports LvS.models.documents

Namespace LvS.objects.documents

 Public Class WebBrowserDocumentView
  Implements IDocument

#Region "Constants"

  'list of browser commands: http://msdn.microsoft.com/library/default.asp?url=/workshop/author/dhtml/reference/commandids.asp (http://msdn.microsoft.com/library/default.asp?url=/workshop/author/dhtml/reference/commandids.asp
  Private COMMAND_SAVEAS As String = "SaveAs"
#End Region

#Region "Fields"

  Protected fModified As Boolean = False

#End Region

#Region "Properties"

  <DefaultValue("")> _
  Public Overrides Property Source() As String Implements models.documents.IDocument.Source
   Get
    Return fSource
   End Get
   Set(ByVal value As String)
    If value = "" Then value = "about:blank" 'can't create a Uri using an empty string, and using =Nothing when closing (where we do Source="") seems to not close ActiveDocument servers used by IE to show any Word, Excel etc. documents
    browser.Url = New Uri(value)
    fSource = value
    Modified = False
   End Set
  End Property

  <DefaultValue(False)> _
  Public Overrides Property Modified() As Boolean Implements models.documents.IDocument.Modified
   Get
    Return fModified
   End Get
   Set(ByVal value As Boolean)
    fModified = value
   End Set
  End Property

#End Region

#Region "Methods"

  Public Overrides Sub Save() Implements IDocument.Save
   Try
    'browser.Document.ExecCommand(COMMAND_SAVEAS, False, fSource) 'do not show dialog 'disabled cause it always shows the dialog!!!
    Modified = False
   Catch 'will throw exception if had opened Word etc. document in external window and have closed that window
    'ignore
   End Try
  End Sub

  Public Overrides Sub Export(ByVal path As String) Implements IDocument.Export
   If browser.Document IsNot Nothing Then
    browser.Document.ExecCommand(COMMAND_SAVEAS, True, path) 'this doesn't affect the Modified flag
   Else 'document may have been opened outside of the browser
    '...try copying the file from the activity folder? (it may be locked though)
   End If
  End Sub

  Public Overrides Sub Close() Implements IDocument.Close 'must close else the browser will leave any ActiveDocument servers it uses running in the background and the respective files locked (plus won't delete the temp files)
   browser.Stop() 'stop any current page loading
   Source = "" 'must do this for IE to close ActiveDocument servers for any Word, Excel, etc. documents it shows
   browser.Dispose() 'dispose the control for it to close Activedocument servers it uses immediately
  End Sub

#End Region

 End Class

End Namespace
