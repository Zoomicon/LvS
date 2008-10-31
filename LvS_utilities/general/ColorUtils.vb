'Description: ColorUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070315

Imports System.Drawing

Namespace LvS.utilities

 Public NotInheritable Class ColorUtils

  Public Shared Function stripColorAlpha(ByVal theColor As Color) As Color
   With theColor
    Return Color.FromArgb(255, .R, .G, .B)
   End With
  End Function

 End Class

End Namespace
