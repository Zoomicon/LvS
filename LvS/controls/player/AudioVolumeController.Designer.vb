Namespace LvS.objects.controllers

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class AudioVolumeController
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
			Me.components = New System.ComponentModel.Container
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudioVolumeController))
			Me.sliderVolume = New System.Windows.Forms.TrackBar
			Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
			Me.cbMute = New System.Windows.Forms.CheckBox
			Me.Images = New System.Windows.Forms.ImageList(Me.components)
			CType(Me.sliderVolume, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'sliderVolume
			'
			Me.sliderVolume.AccessibleDescription = Nothing
			Me.sliderVolume.AccessibleName = Nothing
			resources.ApplyResources(Me.sliderVolume, "sliderVolume")
			Me.sliderVolume.BackgroundImage = Nothing
			Me.sliderVolume.Font = Nothing
			Me.sliderVolume.Maximum = 100
			Me.sliderVolume.Name = "sliderVolume"
			Me.sliderVolume.TickFrequency = 10
			Me.ToolTips.SetToolTip(Me.sliderVolume, resources.GetString("sliderVolume.ToolTip"))
			'
			'ToolTips
			'
			Me.ToolTips.IsBalloon = True
			'
			'cbMute
			'
			Me.cbMute.AccessibleDescription = Nothing
			Me.cbMute.AccessibleName = Nothing
			resources.ApplyResources(Me.cbMute, "cbMute")
			Me.cbMute.BackgroundImage = Nothing
			Me.cbMute.FlatAppearance.BorderSize = 0
			Me.cbMute.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
			Me.cbMute.Font = Nothing
			Me.cbMute.ImageList = Me.Images
			Me.cbMute.Name = "cbMute"
			Me.ToolTips.SetToolTip(Me.cbMute, resources.GetString("cbMute.ToolTip"))
			Me.cbMute.UseVisualStyleBackColor = True
			'
			'Images
			'
			Me.Images.ImageStream = CType(resources.GetObject("Images.ImageStream"), System.Windows.Forms.ImageListStreamer)
			Me.Images.TransparentColor = System.Drawing.Color.Transparent
			Me.Images.Images.SetKeyName(0, "")
			Me.Images.Images.SetKeyName(1, "NoAudioHS.png")
			'
			'AudioVolumeController
			'
			Me.AccessibleDescription = Nothing
			Me.AccessibleName = Nothing
			resources.ApplyResources(Me, "$this")
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackgroundImage = Nothing
			Me.Controls.Add(Me.cbMute)
			Me.Controls.Add(Me.sliderVolume)
			Me.Font = Nothing
			Me.Name = "AudioVolumeController"
			Me.ToolTips.SetToolTip(Me, resources.GetString("$this.ToolTip"))
			CType(Me.sliderVolume, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
  Friend WithEvents sliderVolume As System.Windows.Forms.TrackBar
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
  Friend WithEvents cbMute As System.Windows.Forms.CheckBox
  Friend WithEvents Images As System.Windows.Forms.ImageList

 End Class

End Namespace
