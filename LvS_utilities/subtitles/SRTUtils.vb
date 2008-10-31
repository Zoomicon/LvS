'Description: SRTUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080421

Imports LvS.models.subtitles
Imports LvS.utilities.DateTimeUtils

Namespace LvS.utilities.subtitles

 Public NotInheritable Class SRTUtils

  Public Const SRTtimeFormat As String = "HH:mm:ss,fff"
  Public Const SignificantDigits As Integer = 2 'Must use 2 instead of 3 as done at all the LvS controls
  Public Const SRT_TIME_SEPARATOR As String = " --> "

  Public Shared BaseTime As DateTime = DATETIMEZERO

  Public Shared Function SecondsToSRTtime(ByVal seconds As Double) As String
   Return SecondsToDateTimeStr(seconds, BaseTime, SRTtimeFormat, SignificantDigits)
  End Function

  Public Shared Function SRTtimeToSeconds(ByVal srtTime As String) As Double
   Return DateTimeStrToSeconds(srtTime, BaseTime, SRTtimeFormat, SignificantDigits)
		End Function

		Public Shared Sub SRTStringToSubtitle(ByVal srtString As String, ByVal subtitle As ISubtitle)
			Try
				If srtString IsNot Nothing Then
					With subtitle
						Dim TimesAndSubtitles() As String = Split(srtString, "|")
						Dim TimesOnly() As String = Split(TimesAndSubtitles(2), SRT_TIME_SEPARATOR)
						.SetTimes(SRTtimeToSeconds(TimesOnly(0)), SRTtimeToSeconds(TimesOnly(1)))
						If TimesAndSubtitles.Length > 3 Then	'if more than 2 lines per subtitle, ignore the rest
							.Subtitle1 = TimesAndSubtitles(3)
							If TimesAndSubtitles.Length > 4 Then	'if more than 2 lines per subtitle, ignore the rest
								.Subtitle2 = TimesAndSubtitles(4)
							Else
								.Subtitle2 = ""
							End If
						Else
							.Subtitle1 = ""
						End If
					End With
				End If
			Catch
				Throw New ApplicationException(My.Resources.STR_INVALID_SRT)
			End Try
		End Sub

	End Class

End Namespace
