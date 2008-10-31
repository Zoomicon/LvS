'Description: BaseSubtitleWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070326

Imports System.IO
Imports System.Text
Imports LvS.models.subtitles

Namespace LvS.utilities.subtitles

 Public MustInherit Class BaseSubtitleWriter
  Implements ISubtitlesWriter

#Region "Methods"

  Public Overloads Sub WriteSubtitles(ByVal subtitles As models.subtitles.ISubtitles, ByVal path As String, ByVal encoding As Encoding) Implements models.subtitles.ISubtitlesWriter.WriteSubtitles
   Using writer As New StreamWriter(path, False, encoding)
    WriteSubtitles(subtitles, writer)
   End Using
  End Sub

  Public Overloads Sub WriteSubtitles(ByVal subtitles As models.subtitles.ISubtitles, ByVal writer As TextWriter)
   For Each s As ISubtitle In subtitles
    WriteSubtitle(s, writer)
   Next
  End Sub

  Protected Overridable Sub WriteHeader()
   'can override at descendents
  End Sub

  Protected Overridable Sub WriteFooter()
   'can override at descendents
  End Sub

  Protected MustOverride Sub WriteSubtitle(ByVal subtitle As ISubtitle, ByVal writer As TextWriter)

#End Region

 End Class

End Namespace
