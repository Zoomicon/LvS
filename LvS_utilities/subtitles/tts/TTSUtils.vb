'Description: TTSUtils class
'Authors: George Birbilis (birbilis@kagi.com), Kostas Mitropoulos (kosmitr@eap.gr)
'Version: 20090310

Imports LvS.models.subtitles
Imports LvS.utilities.DateTimeUtils

Namespace LvS.utilities.subtitles.tts

	Public NotInheritable Class TTSUtils

		Public Const TTStimeFormat As String = "H:mm:ss.ff"	'do not use HH since TTS doesn't require two digits for the hour
		Public Const SignificantDigits As Integer = 2
		Public Const TTS_TIME_END As String = ",NTP "

		Public Shared BaseTime As DateTime = DATETIMEZERO

		Public Shared Function SecondsToTTStime(ByVal seconds As Double) As String
			Return SecondsToDateTimeStr(seconds, BaseTime, TTStimeFormat, SignificantDigits)
		End Function

		Public Shared Function TTStimeToSeconds(ByVal ttsTime As String) As Double
			Return TimeStrToSeconds(ttsTime, BaseTime, TTStimeFormat, SignificantDigits)
		End Function

		Public Shared Function SubtitleToTTSString(ByVal subtitle As ISubtitle) As String
			With subtitle
				Dim result As String = SecondsToTTStime(.StartTime) + "," + SecondsToTTStime(.EndTime) + TTS_TIME_END + .Subtitle1
				If (.Subtitle2 <> "") Then result += "|" + .Subtitle2 'write 2nd subtitle line only if non-empty
				Return result
			End With
		End Function

		Public Shared Sub TTSStringToSubtitle(ByVal ttsString As String, ByVal subtitle As ISubtitle)
			Try
				With subtitle
					Dim TimesAndSubtitles() As String = Split(ttsString, TTS_TIME_END)
					Dim TimesOnly() As String = Split(TimesAndSubtitles(0), ",")
					.SetTimes(TTStimeToSeconds(TimesOnly(0)), TTStimeToSeconds(TimesOnly(1)))
					Dim SubtitlesOnly() As String = Split(TimesAndSubtitles(1), "|")
					.Subtitle1 = SubtitlesOnly(0)
					If SubtitlesOnly.Length > 1 Then .Subtitle2 = SubtitlesOnly(1) Else .Subtitle2 = "" 'if more than 2 lines per subtitle, ignore the rest
				End With
			Catch
				Throw New ApplicationException(My.Resources.STR_INVALID_TTS)
			End Try
		End Sub

	End Class

End Namespace
