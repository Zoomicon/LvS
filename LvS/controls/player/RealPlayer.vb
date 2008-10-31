'Description: RealPlayer class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070413

Imports LvS.utilities.DebugUtils
Imports LvS.models.player

Namespace LvS.objects.players

 Public Class RealPlayer
  Inherits BasePlayer 'not needed since the *.Design partial class inherits BasePlayer anyway (use "Show All Files" button of Solution Explorer to see those files grouped as children items of each control/form)
  Implements IPlayer

#Region "Fields"

  Protected fMaxInternalVolume As Double = 100 'must not be 0 (don't change this value, needed so that resulting audio values are between 0 and 1)
  Protected fPlaySelectionOnly As Boolean
  Protected fSelectionStartTime As Double
  Protected fSelectionEndTime As Double

#End Region

#Region "Properties"

  <DefaultValue("")> _
  Public Overrides Property Source() As String Implements IPlayer.Source
   Get
    Return playerReal.Source
   End Get
   Set(ByVal value As String)
    If value Is Nothing Then value = ""
    timerPlay.Enabled = (value <> "") '!!! must do this, else it starts playing when activity is closed
    playerReal.Source = value
    RaiseDurationChanged() 'inform that the movie duration has changed
   End Set
  End Property

  Public Overrides Property VideoOn() As Boolean Implements IPlayer.VideoOn
   Get
    Return playerReal.Visible
   End Get
   Set(ByVal value As Boolean)
    playerReal.Visible = value 'could use setShowVideo(value), but there's no getShowVideo()
   End Set
  End Property

  Public Overrides Property AudioOn() As Boolean Implements IPlayer.AudioOn
   Get
    NotImplemented()
   End Get
   Set(ByVal value As Boolean)
    NotImplemented()
   End Set
  End Property

  Public Overrides Property AudioVolume() As Double Implements IPlayer.AudioVolume
   Get
    Return playerReal.GetVolume() / fMaxInternalVolume
   End Get
   Set(ByVal value As Double)
    playerReal.SetVolume(CShort(value * fMaxInternalVolume))
   End Set
  End Property

  Public Overrides Property Time() As Double Implements IPlayer.Time
   Get
    Dim result As Double = playerReal.GetPosition() / 1000 'RealPlayer uses milliseconds
    If SignificantDigits <> -1 Then Return Math.Round(result, SignificantDigits)
    Return result
   End Get
   Set(ByVal value As Double)
    If SignificantDigits <> -1 Then value = Math.Round(value, SignificantDigits)
    playerReal.SetPosition(CInt(value * 1000))
   End Set
  End Property

  Public Overrides ReadOnly Property Duration() As Double Implements IPlayer.Duration
   Get
    Return playerReal.GetLength / 1000 'RealPlayer uses milliseconds
   End Get
  End Property

  Public Overrides Property Rate() As Double Implements IPlayer.Rate
   Get
    NotImplemented()
   End Get
   Set(ByVal value As Double)
    Dim changed As Boolean = (value <> Rate)
    CheckStartStopTimer(value) 'must be done before setting the new rate (necessery if we weren't playing already)
    NotImplemented()
    If changed Then RaiseRateChanged()
   End Set
  End Property

  Public Overrides Property SelectionStartTime() As Double Implements IPlayer.SelectionStartTime
   Get
    Return fSelectionStartTime
   End Get
   Set(ByVal value As Double)
    If value > Duration Then value = Duration - 0.01
    If value <> fSelectionStartTime Then
     fSelectionStartTime = value
     RaiseSelectionStartTimeChanged()
    End If
   End Set
  End Property

  Public Overrides Property SelectionEndTime() As Double Implements IPlayer.SelectionEndTime
   Get
    Return fSelectionEndTime
   End Get
   Set(ByVal value As Double)
    If value > Duration Then value = Duration - 0.01
    If value <> fSelectionEndTime Then
     fSelectionEndTime = value
     RaiseSelectionEndTimeChanged()
    End If
   End Set
  End Property

  Public Overrides Property PlaySelectionOnly() As Boolean Implements IPlayer.PlaySelectionOnly
   Get
    Return fPlaySelectionOnly
   End Get
   Set(ByVal value As Boolean)
    fPlaySelectionOnly = value
   End Set
  End Property

#End Region

#Region "Methods"

  Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()
   ' Add any initialization after the InitializeComponent() call.
   ' Must do the following here, instead of at "Load" event, cause that event does not occur if object is instantiated outside of a form
   With playerReal
    .SendToBack()
    .SetNoLogo(True)
    .SetMaintainAspect(True) 'stretch to fit window, maintaining aspect ratio (this setting can't coexist with "setCenter(true)")
   End With
  End Sub

  Protected Overrides Sub RaiseTimeChanged()
   If fPlaySelectionOnly Then
    If Time < SelectionStartTime Then
     Time = SelectionStartTime
     Pause()
     Exit Sub
    ElseIf Time > SelectionEndTime Then
     Time = SelectionEndTime
     Pause()
     Exit Sub
    End If
   End If
   MyBase.RaiseTimeChanged()
  End Sub

#End Region

#Region "Event handlers"

  Private Sub playerReal_OnPositionChange(ByVal sender As System.Object, ByVal e As AxRealAudioObjects.DRealAudioEvents_OnPositionChangeEvent) Handles playerReal.OnPositionChange
   RaiseTimeChanged() 'this event handler executes only at explicit events like position property setting or interaction with the user controls
  End Sub

  '...

#End Region

 End Class

End Namespace
