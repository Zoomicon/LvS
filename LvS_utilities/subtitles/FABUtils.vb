'Description: FABUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070410

Imports LvS.utilities.DateTimeUtils

Namespace LvS.utilities.subtitles

 Public NotInheritable Class FABUtils

  Public Const FABtimeFormat As String = "HH:mm:ss:ff"
  Public Const SignificantDigits As Integer = 2

  Public Shared BaseTime As DateTime = DATETIMEZERO

  Public Shared Function SecondsToFABtime(ByVal seconds As Double) As String
   Return SecondsToDateTimeStr(seconds, BaseTime, FABtimeFormat, SignificantDigits)
  End Function

  Public Shared Function FABtimeToSeconds(ByVal FABTime As String) As Double
   Return DateTimeStrToSeconds(FABTime, BaseTime, FABtimeFormat, SignificantDigits)
  End Function

 End Class

End Namespace
