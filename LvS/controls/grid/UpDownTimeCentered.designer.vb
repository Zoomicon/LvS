Namespace LvS.objects.grid

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class UpDownTimeCentered
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
   Me.timeUpDown = New LvS.objects.grid.UpDownTime
   Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
   Me.SuspendLayout()
   '
   'timeUpDown
   '
   Me.timeUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
   Me.timeUpDown.BackColor = System.Drawing.SystemColors.Window
   Me.timeUpDown.CustomFormat = "HH:mm:ss.ff"
   Me.timeUpDown.Location = New System.Drawing.Point(2, 0)
   Me.timeUpDown.Name = "timeUpDown"
   Me.timeUpDown.Size = New System.Drawing.Size(116, 20)
   Me.timeUpDown.TabIndex = 0
   Me.timeUpDown.Text = "00:00:00.00"
   Me.timeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
   Me.timeUpDown.Time = New Date(2007, 3, 26, 0, 0, 0, 0)
   '
   'ToolTips
   '
   Me.ToolTips.IsBalloon = True
   '
   'UpDownTimeCentered
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.BackColor = System.Drawing.Color.Transparent
   Me.Controls.Add(Me.timeUpDown)
   Me.Name = "UpDownTimeCentered"
   Me.Size = New System.Drawing.Size(120, 20)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents timeUpDown As UpDownTime
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

 End Class

End Namespace
