'Description: TextUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070413

Imports System.Text

Namespace LvS.utilities

 Public NotInheritable Class TextUtils

  Public Shared Function IsUnicode(ByVal encoding As Encoding) As Boolean
   Return encoding.Equals(encoding.Unicode) OrElse _
          encoding.Equals(encoding.UTF32) OrElse _
          encoding.Equals(encoding.UTF7) OrElse _
          encoding.Equals(encoding.UTF8)
  End Function

  Public Shared Function ContainsChars(ByVal s As String, ByVal chars As Char()) As Boolean
   Return (s.IndexOfAny(chars) <> -1)
  End Function

  Public Shared Function CharsString(ByVal chars As Char()) As String
   Dim result As String = ""
   For Each c As Char In chars
    If c <> Chr(0) Then result &= c & " " 'if Chr(0) is added to the string the messageboxes stop the string display a that point
   Next
   Return Trim(result)
  End Function

 End Class

End Namespace
