'Description: TTSWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070326

Imports System.IO
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.TTSUtils

Namespace LvS.utilities.subtitles

 Public Class TTSUnicodeWriter
  Inherits BaseSubtitleWriter

#Region "Methods"

  Protected Overrides Sub WriteSubtitle(ByVal subtitle As ISubtitle, ByVal writer As TextWriter)
   writer.WriteLine(SubtitleToTTSString(subtitle))
  End Sub

#End Region

 End Class

End Namespace
