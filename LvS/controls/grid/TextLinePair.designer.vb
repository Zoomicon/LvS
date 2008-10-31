Namespace LvS.objects.grid

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextLinePair
		Inherits System.Windows.Forms.UserControl

		'UserControl overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
			Me.txtLine1 = New System.Windows.Forms.TextBox
			Me.txtLine2 = New System.Windows.Forms.TextBox
			Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
			Me.TableLayoutPanel1.SuspendLayout()
			Me.SuspendLayout()
			'
			'TableLayoutPanel1
			'
			Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
			Me.TableLayoutPanel1.ColumnCount = 1
			Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.Controls.Add(Me.txtLine1, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.txtLine2, 0, 1)
			Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 2
			Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.Size = New System.Drawing.Size(419, 54)
			Me.TableLayoutPanel1.TabIndex = 0
			'
			'txtLine1
			'
			Me.txtLine1.AcceptsTab = True
			Me.txtLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtLine1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.txtLine1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
			Me.txtLine1.Location = New System.Drawing.Point(3, 6)
			Me.txtLine1.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
			Me.txtLine1.Multiline = True
			Me.txtLine1.Name = "txtLine1"
			Me.txtLine1.Size = New System.Drawing.Size(413, 20)
			Me.txtLine1.TabIndex = 0
			'
			'txtLine2
			'
			Me.txtLine2.AcceptsTab = True
			Me.txtLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtLine2.Dock = System.Windows.Forms.DockStyle.Top
			Me.txtLine2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
			Me.txtLine2.Location = New System.Drawing.Point(3, 28)
			Me.txtLine2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 1)
			Me.txtLine2.Multiline = True
			Me.txtLine2.Name = "txtLine2"
			Me.txtLine2.Size = New System.Drawing.Size(413, 20)
			Me.txtLine2.TabIndex = 1
			'
			'ToolTips
			'
			Me.ToolTips.IsBalloon = True
			'
			'SubtitlePair
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.Transparent
			Me.Controls.Add(Me.TableLayoutPanel1)
			Me.Name = "SubtitlePair"
			Me.Size = New System.Drawing.Size(419, 54)
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
		Friend WithEvents txtLine1 As System.Windows.Forms.TextBox
		Friend WithEvents txtLine2 As System.Windows.Forms.TextBox
		Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

	End Class

End Namespace
