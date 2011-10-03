Namespace LvS.dialogs

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LoginDialog
		Inherits System.Windows.Forms.Form

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub
		Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
		Friend WithEvents UsernameLabel As System.Windows.Forms.Label
		Friend WithEvents PasswordLabel As System.Windows.Forms.Label
		Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
		Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
		Friend WithEvents OK As System.Windows.Forms.Button
		Friend WithEvents Cancel As System.Windows.Forms.Button

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginDialog))
			Me.LogoPictureBox = New System.Windows.Forms.PictureBox
			Me.UsernameLabel = New System.Windows.Forms.Label
			Me.PasswordLabel = New System.Windows.Forms.Label
			Me.UsernameTextBox = New System.Windows.Forms.TextBox
			Me.PasswordTextBox = New System.Windows.Forms.TextBox
			Me.OK = New System.Windows.Forms.Button
			Me.Cancel = New System.Windows.Forms.Button
			CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'LogoPictureBox
			'
			Me.LogoPictureBox.Image = Global.My.Resources.Resources.logonew01_800x600
			resources.ApplyResources(Me.LogoPictureBox, "LogoPictureBox")
			Me.LogoPictureBox.Name = "LogoPictureBox"
			Me.LogoPictureBox.TabStop = False
			'
			'UsernameLabel
			'
			resources.ApplyResources(Me.UsernameLabel, "UsernameLabel")
			Me.UsernameLabel.Name = "UsernameLabel"
			'
			'PasswordLabel
			'
			resources.ApplyResources(Me.PasswordLabel, "PasswordLabel")
			Me.PasswordLabel.Name = "PasswordLabel"
			'
			'UsernameTextBox
			'
			resources.ApplyResources(Me.UsernameTextBox, "UsernameTextBox")
			Me.UsernameTextBox.Name = "UsernameTextBox"
			'
			'PasswordTextBox
			'
			resources.ApplyResources(Me.PasswordTextBox, "PasswordTextBox")
			Me.PasswordTextBox.Name = "PasswordTextBox"
			'
			'OK
			'
			resources.ApplyResources(Me.OK, "OK")
			Me.OK.Name = "OK"
			'
			'Cancel
			'
			Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			resources.ApplyResources(Me.Cancel, "Cancel")
			Me.Cancel.Name = "Cancel"
			'
			'LoginDialog
			'
			Me.AcceptButton = Me.OK
			resources.ApplyResources(Me, "$this")
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.Cancel
			Me.Controls.Add(Me.Cancel)
			Me.Controls.Add(Me.OK)
			Me.Controls.Add(Me.PasswordTextBox)
			Me.Controls.Add(Me.UsernameTextBox)
			Me.Controls.Add(Me.PasswordLabel)
			Me.Controls.Add(Me.UsernameLabel)
			Me.Controls.Add(Me.LogoPictureBox)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "LoginDialog"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

	End Class

End Namespace
