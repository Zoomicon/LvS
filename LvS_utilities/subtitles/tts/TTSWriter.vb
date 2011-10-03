'Description: TTSWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.IO
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.tts.TTSUtils

Namespace LvS.utilities.subtitles.tts

	Public Class TTSUnicodeWriter
		Inherits BaseSubtitleWriter

#Region "Methods"

		Protected Overrides Sub WriteSubtitle(ByVal subtitle As ISubtitle, ByVal writer As TextWriter)
			writer.WriteLine(SubtitleToTTSString(subtitle))
		End Sub

#End Region

	End Class

End Namespace
