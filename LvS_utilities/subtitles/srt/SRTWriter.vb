'Description: SRTWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.IO
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.srt.SRTUtils

Namespace LvS.utilities.subtitles.srt

	Public Class SRTWriter
		Inherits BaseSubtitleWriter

#Region "Fields"

		Protected fLineNumber As Integer

#End Region

#Region "Properties"

		Public ReadOnly Property LineNumber() As Integer
			Get
				Return fLineNumber
			End Get
		End Property

#End Region

#Region "Methods"

		Protected Overrides Sub WriteHeader()
			fLineNumber = 0
		End Sub

		Protected Overrides Sub WriteSubtitle(ByVal subtitle As models.subtitles.ISubtitle, ByVal writer As System.IO.TextWriter)
			fLineNumber += 1
			writer.WriteLine(LineNumber)
			With subtitle
				writer.WriteLine(SecondsToSRTtime(.StartTime) + SRT_TIME_SEPARATOR + SecondsToSRTtime(.EndTime))
				If (.Subtitle1 <> "") Then writer.WriteLine(.Subtitle1) 'if 1st line is missing, 2nd will become 1st (SRT doesn't support otherwise)
				If (.Subtitle2 <> "") Then writer.WriteLine(.Subtitle2) 'write 2nd subtitle line only if non-empty
				writer.WriteLine()	'SRT format has an empty line AFTER each subtitle, resuling to the file ending up at two empty lines (maybe done so that more subtitles can be easily appended later on to the file)
			End With
		End Sub

#End Region

	End Class

End Namespace
