Namespace LvS.screens

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LanguageSelectionView
		Inherits System.Windows.Forms.UserControl

		'UserControl overrides dispose to clean up the component list.
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

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Me.cbLanguages = New System.Windows.Forms.ComboBox
			Me.PictureBox1 = New System.Windows.Forms.PictureBox
			CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'cbLanguages
			'
			Me.cbLanguages.Anchor = System.Windows.Forms.AnchorStyles.Bottom
			Me.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbLanguages.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
			Me.cbLanguages.FormattingEnabled = True
			Me.cbLanguages.Items.AddRange(New Object() {" Welcome!", " Καλώς ήλθατε!", " ¡Bienvenidos!", " Üdvözöljük!", " Bem-vindo!", " Bun venit!"})
			Me.cbLanguages.Location = New System.Drawing.Point(169, 439)
			Me.cbLanguages.Name = "cbLanguages"
			Me.cbLanguages.Size = New System.Drawing.Size(317, 32)
			Me.cbLanguages.TabIndex = 1
			'
			'PictureBox1
			'
			Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
															Or System.Windows.Forms.AnchorStyles.Left) _
															Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
			Me.PictureBox1.Image = Global.My.Resources.Resources.logonew01_800x600
			Me.PictureBox1.Location = New System.Drawing.Point(0, 20)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New System.Drawing.Size(660, 400)
			Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 3
			Me.PictureBox1.TabStop = False
			'
			'LanguageSelectionView
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.Transparent
			Me.Controls.Add(Me.cbLanguages)
			Me.Controls.Add(Me.PictureBox1)
			Me.Name = "LanguageSelectionView"
			Me.Size = New System.Drawing.Size(663, 488)
			CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents cbLanguages As System.Windows.Forms.ComboBox
		Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

	End Class

End Namespace
