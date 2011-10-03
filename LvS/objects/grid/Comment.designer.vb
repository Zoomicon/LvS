Namespace LvS.objects.grid

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class Comment
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
			Me.txtComment1 = New System.Windows.Forms.TextBox
			Me.txtComment2 = New System.Windows.Forms.TextBox
			Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
			Me.TableLayoutPanel1.SuspendLayout()
			Me.SuspendLayout()
			'
			'TableLayoutPanel1
			'
			Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
			Me.TableLayoutPanel1.ColumnCount = 1
			Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.Controls.Add(Me.txtComment1, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.txtComment2, 0, 1)
			Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 2
			Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
			Me.TableLayoutPanel1.Size = New System.Drawing.Size(423, 52)
			Me.TableLayoutPanel1.TabIndex = 0
			'
			'txtComment1
			'
			Me.txtComment1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
															Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.txtComment1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtComment1.Location = New System.Drawing.Point(3, 10)
			Me.txtComment1.Name = "txtComment1"
			Me.txtComment1.Size = New System.Drawing.Size(417, 20)
			Me.txtComment1.TabIndex = 0
			'
			'txtComment2
			'
			Me.txtComment2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
															Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.txtComment2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtComment2.Location = New System.Drawing.Point(3, 29)
			Me.txtComment2.Name = "txtComment2"
			Me.txtComment2.Size = New System.Drawing.Size(417, 20)
			Me.txtComment2.TabIndex = 1
			'
			'ToolTips
			'
			Me.ToolTips.IsBalloon = False
			'
			'Comment
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.Transparent
			Me.Controls.Add(Me.TableLayoutPanel1)
			Me.Name = "Comment"
			Me.Size = New System.Drawing.Size(423, 52)
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents txtComment1 As System.Windows.Forms.TextBox
  Friend WithEvents txtComment2 As System.Windows.Forms.TextBox
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

 End Class

End Namespace

