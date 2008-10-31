'Description: DocumentUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080328

Imports System.IO
Imports System.Text
Imports LvS.models.documents
Imports LvS.objects.documents
Imports LvS.utilities.FileUtils

Namespace LvS.utilities.documents

 Public NotInheritable Class DocumentUtils

#Region "File extensions"

  Public Const EXTENSION_TXT As String = ".TXT"
  Public Const EXTENSION_RTF As String = ".RTF"

  Public Const EXTENSION_URL As String = ".URL"

  Public Const EXTENSION_DOC As String = ".DOC"

  Public Const EXTENSION_CSV As String = ".CSV"
  Public Const EXTENSION_XLS As String = ".XLS"
  Public Const EXTENSION_PPT As String = ".PPT"

  Public Const EXTENSION_MHT As String = ".MHT"
  Public Const EXTENSION_HTM As String = ".HTM"
  Public Const EXTENSION_HTML As String = ".HTML"

  Public Const EXTENSION_FLV As String = ".FLV" '!!! add to dlg filters too and localize '??? FLA and FLC too?
  Public Const EXTENSION_SWF As String = ".SWF" '!!! add to dlg filters too and localize
  Public Const EXTENSION_PDF As String = ".PDF"

  Public Shared ReadOnly EXTENSIONS_RTFVIEWER As String() = {EXTENSION_TXT, EXTENSION_RTF}
  Public Shared ReadOnly EXTENSIONS_WEBVIEWER As String() = {EXTENSION_URL, EXTENSION_DOC, EXTENSION_XLS, EXTENSION_CSV, EXTENSION_PPT, EXTENSION_MHT, EXTENSION_HTM, EXTENSION_HTML, EXTENSION_FLV, EXTENSION_SWF, EXTENSION_PDF}
  Public Shared ReadOnly EXTENSIONS_DOCUMENTS As String()() = {EXTENSIONS_RTFVIEWER, EXTENSIONS_WEBVIEWER}

#End Region

  Public Shared Function getDocumentsFilter() As String
   Return FileUtils.getFilter(EXTENSIONS_DOCUMENTS)
  End Function

  Public Shared Function getDocumentView(ByVal source As String, ByVal encoding As Encoding) As IDocument
   Dim result As IDocument = Nothing

   Try
    If CheckExtension(source, EXTENSIONS_RTFVIEWER) IsNot Nothing Then
     result = New RTFDocumentView
    ElseIf CheckExtension(source, EXTENSIONS_WEBVIEWER) IsNot Nothing Then
     result = New WebBrowserDocumentView
    End If

    If result IsNot Nothing Then
     result.Encoding = encoding
     result.Source = source 'try to load the document
    End If
   Catch
    result = Nothing
   End Try

   Return result
  End Function

  Public Shared Function IsWmpInstalled() As Boolean
   Return True '!!! dummy
  End Function

  Public Shared Function IsRealPlayerInstalled() As Boolean
   Return True '!!! dummy
  End Function

  Public Shared Function IsQuickTimeInstalled() As Boolean
   Return True '!!! dummy
  End Function

 End Class

End Namespace
