'Description: Application events
'Author: George Birbilis (birbilis@kagi.com)
'Version: 20070416

Imports DevAge.Windows.Forms

Namespace My

 ' The following events are also available for MyApplication:
 ' 
 ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
 ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
 Partial Friend Class MyApplication

  ' Startup: Raised when the application starts, before the startup form is created.
  Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
   'My.Forms.MainForm.Show() 'do not do this: leaves the splash screen open
  End Sub

  ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
  Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
   'e.BringToForeground = True 'do not do this: keeps the app minimized after start
   My.Forms.MainForm.ParseCommandLine(e.CommandLine) 'pass the command-line of the newly launched instance to the already active application instance (then the newly launched instance will be closed automatically)
  End Sub

  ' UnhandledException: Raised if the application encounters an unhandled exception.
  Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
			DevAge.Windows.Forms.ErrorDialog.Show(My.Application.MainForm, e.Exception, My.Resources.STR_ERROR)	'show error dialog with exception details
			e.ExitApplication = (MessageBox.Show(My.Resources.STR_EXCEPTION_EXIT & vbCrLf & My.Resources.STR_EXCEPTION_FEEDBACK, My.Resources.STR_QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes)	'ask the user if they want to exit or ignore the error and continue (the 2nd option is the default)
  End Sub

 End Class

End Namespace

