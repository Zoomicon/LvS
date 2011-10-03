Namespace LvS.objects.controllers

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class TimeSelectionController
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
   Me.sliderTime = New BC.Controls.TimeSlider
   CType(Me.sliderTime, System.ComponentModel.ISupportInitialize).BeginInit()
   Me.SuspendLayout()
   '
   'sliderTime
   '
   Me.sliderTime.AllowSlidingMaximum = False
   Me.sliderTime.CustomFormat = "HH:mm:ss.ff"
   Me.sliderTime.Dock = System.Windows.Forms.DockStyle.Fill
   Me.sliderTime.Format = BC.Controls.DateFormatEnum.Custom
   Me.sliderTime.LargeChange = System.TimeSpan.Parse("00:00:01")
   Me.sliderTime.Location = New System.Drawing.Point(0, 0)
   Me.sliderTime.Maximum = New Date(2007, 4, 5, 18, 48, 49, 78)
   Me.sliderTime.Minimum = New Date(2007, 3, 13, 0, 0, 0, 0)
   Me.sliderTime.Name = "sliderTime"
   Me.sliderTime.SegmentColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
   Me.sliderTime.SegmentEnd = New Date(CType(0, Long))
   Me.sliderTime.SegmentStart = New Date(CType(0, Long))
   Me.sliderTime.ShowLabelsAsDuration = False
   Me.sliderTime.ShowMaximumLabel = True
   Me.sliderTime.ShowMinimumLabel = False
   Me.sliderTime.ShowSegment = False
   Me.sliderTime.ShowValueLabel = True
   Me.sliderTime.Size = New System.Drawing.Size(352, 50)
   Me.sliderTime.SmallChange = System.TimeSpan.Parse("00:00:00.0001000")
   Me.sliderTime.TabIndex = 0
   Me.sliderTime.TickFrequency = System.TimeSpan.Parse("00:00:01")
   Me.sliderTime.Value = New Date(2007, 3, 13, 0, 0, 0, 0)
   '
   'TimeSelectionController
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.sliderTime)
   Me.Name = "TimeSelectionController"
   Me.Size = New System.Drawing.Size(352, 50)
   CType(Me.sliderTime, System.ComponentModel.ISupportInitialize).EndInit()
   Me.ResumeLayout(False)
   Me.PerformLayout()

  End Sub

  Friend WithEvents sliderTime As BC.Controls.TimeSlider

 End Class

End Namespace
