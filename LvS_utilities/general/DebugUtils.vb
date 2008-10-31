'Description: DebugUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

Namespace LvS.utilities

 Public NotInheritable Class DebugUtils

  Public Shared Sub NotImplemented()
   'Throw New NotImplementedException 'do not use exception throwing when designing the application cause WinForms designers have problems with it
   'MessageBox.Show("Not implemented!") 'do not use when designing the application with WinForms designers cause will show many dialog prompts
			Debug.Print(My.Resources.STR_NOT_IMPLEMENTED)
  End Sub

 End Class

End Namespace
