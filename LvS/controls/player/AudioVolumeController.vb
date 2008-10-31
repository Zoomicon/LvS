'Description: AudioVolumeController class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

Imports System.ComponentModel
Imports LvS.models.player

Namespace LvS.objects.controllers

 Public Class AudioVolumeController

#Region "Fields"

  Protected fAudioVolume As IAudioVolume

#End Region

#Region "Properties"

  <DefaultValue(False)> _
  Property Mute() As Boolean
   Get
    Return cbMute.Checked
   End Get
   Set(ByVal value As Boolean)
    cbMute.Checked = value
   End Set
  End Property

  Property AudioVolume() As IAudioVolume
   Get
    Return fAudioVolume
   End Get
   Set(ByVal value As IAudioVolume)
    fAudioVolume = value
    updateSliderFromAudioVolume()
   End Set
  End Property

#End Region

#Region "Methods"

  Protected Sub UpdateVolumeTooltip(ByVal newVolume As Double)
			ToolTips.SetToolTip(sliderVolume, My.Resources.STR_VOLUME & ": " & CStr(CInt(newVolume * 100)) & "%")
  End Sub

  Protected Sub updateSliderFromAudioVolume()
   If fAudioVolume IsNot Nothing Then
    Dim newVolume As Double = fAudioVolume.AudioVolume
    sliderVolume.Value = CInt(newVolume * sliderVolume.Maximum)
    UpdateVolumeTooltip(newVolume)
   End If
  End Sub

  Protected Sub updateAudioVolumeFromSlider()
   Dim newVolume As Double = CDbl((sliderVolume.Value) / (sliderVolume.Maximum))
   If fAudioVolume IsNot Nothing Then fAudioVolume.AudioVolume = newVolume
   UpdateVolumeTooltip(newVolume)
  End Sub

  Protected Sub updateAudioVolumeFromMuteCheckbox()
   If fAudioVolume IsNot Nothing Then
    With fAudioVolume
     If Mute Then
      .AudioVolume = 0
     Else
      updateAudioVolumeFromSlider()
     End If
    End With
   End If
  End Sub

#End Region

#Region "Event handlers"

  Private Sub cbMute_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMute.CheckedChanged
   With cbMute
    If .Checked Then
     .ImageIndex = 1
    Else
     .ImageIndex = 0
    End If
   End With
   updateAudioVolumeFromMuteCheckbox()
  End Sub

  Private Sub sliderVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sliderVolume.Scroll 'must use this event instead of ValueChanged
   updateAudioVolumeFromSlider()
   Mute = False 'dragging volume slider unmutes automatically
  End Sub

#End Region

 End Class

End Namespace
