Namespace LvS.objects.controllers

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class Controller
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
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Controller))
   Me.panelSpeedControls = New System.Windows.Forms.FlowLayoutPanel
   Me.btnSlower = New System.Windows.Forms.Button
   Me.btnFaster = New System.Windows.Forms.Button
   Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
   Me.btnReplaySelection = New System.Windows.Forms.Button
   Me.btnFastForward = New System.Windows.Forms.Button
   Me.btnFastBackwards = New System.Windows.Forms.Button
   Me.btnPause = New System.Windows.Forms.Button
   Me.btnPlay = New System.Windows.Forms.Button
   Me.cbSubtitlesOn = New System.Windows.Forms.CheckBox
   Me.Images = New System.Windows.Forms.ImageList(Me.components)
   Me.sliderTime = New LvS.objects.controllers.TimeSelectionController
   Me.AudioVolumeController1 = New LvS.objects.controllers.AudioVolumeController
   Me.panelSpeedControls.SuspendLayout()
   Me.SuspendLayout()
   '
   'panelSpeedControls
   '
   Me.panelSpeedControls.Controls.Add(Me.btnSlower)
   Me.panelSpeedControls.Controls.Add(Me.btnFaster)
   resources.ApplyResources(Me.panelSpeedControls, "panelSpeedControls")
   Me.panelSpeedControls.Name = "panelSpeedControls"
   '
   'btnSlower
   '
   Me.btnSlower.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnSlower, "btnSlower")
   Me.btnSlower.Image = Global.My.Resources.Resources.bullet_arrow_down
   Me.btnSlower.Name = "btnSlower"
   Me.ToolTips.SetToolTip(Me.btnSlower, resources.GetString("btnSlower.ToolTip"))
   Me.btnSlower.UseVisualStyleBackColor = True
   '
   'btnFaster
   '
   Me.btnFaster.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnFaster, "btnFaster")
   Me.btnFaster.Image = Global.My.Resources.Resources.bullet_arrow_up
   Me.btnFaster.Name = "btnFaster"
   Me.ToolTips.SetToolTip(Me.btnFaster, resources.GetString("btnFaster.ToolTip"))
   Me.btnFaster.UseVisualStyleBackColor = True
   '
   'ToolTips
   '
			Me.ToolTips.IsBalloon = False
   '
   'btnReplaySelection
   '
   Me.btnReplaySelection.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnReplaySelection, "btnReplaySelection")
   Me.btnReplaySelection.Image = Global.My.Resources.Resources.control_repeat_blue
   Me.btnReplaySelection.Name = "btnReplaySelection"
   Me.ToolTips.SetToolTip(Me.btnReplaySelection, resources.GetString("btnReplaySelection.ToolTip"))
   Me.btnReplaySelection.UseVisualStyleBackColor = True
   '
   'btnFastForward
   '
   Me.btnFastForward.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnFastForward, "btnFastForward")
   Me.btnFastForward.Image = Global.My.Resources.Resources.control_fastforward_blue
   Me.btnFastForward.Name = "btnFastForward"
   Me.ToolTips.SetToolTip(Me.btnFastForward, resources.GetString("btnFastForward.ToolTip"))
   Me.btnFastForward.UseVisualStyleBackColor = True
   '
   'btnFastBackwards
   '
   Me.btnFastBackwards.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnFastBackwards, "btnFastBackwards")
   Me.btnFastBackwards.Image = Global.My.Resources.Resources.control_rewind_blue
   Me.btnFastBackwards.Name = "btnFastBackwards"
   Me.ToolTips.SetToolTip(Me.btnFastBackwards, resources.GetString("btnFastBackwards.ToolTip"))
   Me.btnFastBackwards.UseVisualStyleBackColor = True
   '
   'btnPause
   '
   Me.btnPause.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnPause, "btnPause")
   Me.btnPause.Image = Global.My.Resources.Resources.control_pause_blue
   Me.btnPause.Name = "btnPause"
   Me.ToolTips.SetToolTip(Me.btnPause, resources.GetString("btnPause.ToolTip"))
   Me.btnPause.UseVisualStyleBackColor = True
   '
   'btnPlay
   '
   Me.btnPlay.FlatAppearance.BorderSize = 0
   resources.ApplyResources(Me.btnPlay, "btnPlay")
   Me.btnPlay.Image = Global.My.Resources.Resources.control_play_blue
   Me.btnPlay.Name = "btnPlay"
   Me.ToolTips.SetToolTip(Me.btnPlay, resources.GetString("btnPlay.ToolTip"))
   Me.btnPlay.UseVisualStyleBackColor = True
   '
   'cbSubtitlesOn
   '
   resources.ApplyResources(Me.cbSubtitlesOn, "cbSubtitlesOn")
   Me.cbSubtitlesOn.Checked = True
   Me.cbSubtitlesOn.CheckState = System.Windows.Forms.CheckState.Checked
   Me.cbSubtitlesOn.FlatAppearance.BorderSize = 0
   Me.cbSubtitlesOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
   Me.cbSubtitlesOn.ImageList = Me.Images
   Me.cbSubtitlesOn.Name = "cbSubtitlesOn"
   Me.ToolTips.SetToolTip(Me.cbSubtitlesOn, resources.GetString("cbSubtitlesOn.ToolTip"))
   Me.cbSubtitlesOn.UseVisualStyleBackColor = True
   '
   'Images
   '
   Me.Images.ImageStream = CType(resources.GetObject("Images.ImageStream"), System.Windows.Forms.ImageListStreamer)
   Me.Images.TransparentColor = System.Drawing.Color.Transparent
   Me.Images.Images.SetKeyName(0, "comments.png")
   Me.Images.Images.SetKeyName(1, "no comments.png")
   '
   'sliderTime
   '
   resources.ApplyResources(Me.sliderTime, "sliderTime")
   Me.sliderTime.Duration = 0
   Me.sliderTime.EndTime = 0
   Me.sliderTime.Name = "sliderTime"
   Me.sliderTime.SelectionEndTime = 0
   Me.sliderTime.SelectionStartTime = 0
   Me.sliderTime.StartTime = 0
   Me.sliderTime.Time = 0
   Me.sliderTime.TimePosition = Nothing
   Me.sliderTime.TimeSelection = Nothing
   '
   'AudioVolumeController1
   '
   resources.ApplyResources(Me.AudioVolumeController1, "AudioVolumeController1")
   Me.AudioVolumeController1.AudioVolume = Nothing
   Me.AudioVolumeController1.Name = "AudioVolumeController1"
   '
   'Controller
   '
   resources.ApplyResources(Me, "$this")
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.cbSubtitlesOn)
   Me.Controls.Add(Me.panelSpeedControls)
   Me.Controls.Add(Me.btnReplaySelection)
   Me.Controls.Add(Me.btnFastForward)
   Me.Controls.Add(Me.btnFastBackwards)
   Me.Controls.Add(Me.btnPause)
   Me.Controls.Add(Me.btnPlay)
   Me.Controls.Add(Me.AudioVolumeController1)
   Me.Controls.Add(Me.sliderTime)
   Me.Name = "Controller"
   Me.panelSpeedControls.ResumeLayout(False)
   Me.ResumeLayout(False)
   Me.PerformLayout()

  End Sub
  Friend WithEvents sliderTime As LvS.objects.controllers.TimeSelectionController
  Friend WithEvents AudioVolumeController1 As LvS.objects.controllers.AudioVolumeController
  Friend WithEvents btnPlay As System.Windows.Forms.Button
  Friend WithEvents btnPause As System.Windows.Forms.Button
  Friend WithEvents btnFastBackwards As System.Windows.Forms.Button
  Friend WithEvents btnFastForward As System.Windows.Forms.Button
  Friend WithEvents btnReplaySelection As System.Windows.Forms.Button
  Friend WithEvents panelSpeedControls As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents btnSlower As System.Windows.Forms.Button
  Friend WithEvents btnFaster As System.Windows.Forms.Button
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip
  Friend WithEvents Images As System.Windows.Forms.ImageList
  Friend WithEvents cbSubtitlesOn As System.Windows.Forms.CheckBox

 End Class

End Namespace
