'Description: FormUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070329

Imports System.Windows.Forms

Namespace LvS.utilities

 Public NotInheritable Class FormUtils

  Public Shared Function findTabSortPosition(ByVal tabs As TabControl.TabPageCollection, ByVal title As String) As Integer
   With tabs
    For i As Integer = 0 To tabs.Count - 1
     If title < .Item(i).Text Then Return i
    Next i
    Return .Count
   End With
  End Function

 End Class

End Namespace
