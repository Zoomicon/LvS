'Description: AboutDialog class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Namespace LvS.dialogs

	Public NotInheritable Class AboutDialog

		Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' Set the title of the form.
			Dim ApplicationTitle As String
			If My.Application.Info.Title <> "" Then
				ApplicationTitle = My.Application.Info.Title
			Else
				ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
			End If
			Me.Text = ApplicationTitle & " - " & My.Resources.STR_ABOUT
			' Initialize all of the text displayed on the About Box.
			' TODO: Customize the application's assembly information in the "Application" pane of the project 
			'    properties dialog (under the "Project" menu).
			Me.LabelProductName.Text = My.Application.Info.ProductName
			Me.LabelVersion.Text = String.Format(My.Resources.STR_VERSION & " {0}", My.Application.Info.Version.ToString)
			Me.LabelCopyright.Text = My.Application.Info.Copyright
			Me.LabelCompanyName.Text = My.Application.Info.CompanyName
			Me.TextBoxDescription.Text = My.Application.Info.Description
		End Sub

		Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
			Me.Close()
		End Sub

	End Class

End Namespace
