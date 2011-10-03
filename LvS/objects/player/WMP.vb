'Description: WMP (Windows Media Player) class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.ComponentModel
Imports LvS.models.player
Imports LvS.objects.players.WMP.UIModes
Imports WMPLib

Namespace LvS.objects.players

 Public Class WMP
  Inherits BasePlayer 'not needed since the *.Design partial class inherits BasePlayer anyway (use "Show All Files" button of Solution Explorer to see those files grouped as children items of each control/form)
  Implements IPlayer

#Region "Enums"

  Public Enum UIModes As Integer
   uiInvisible = 0
   uiNoControls = 1
   uiMini = 2
   uiFull = 3
   uiCustom = 4
  End Enum

#End Region

#Region "Fields"

  Protected fMaxInternalVolume As Double = 100 'must not be 0 (don't change this value, needed so that resulting audio values are between 0 and 1)
		Protected fPlaySelectionOnly As Boolean
		Protected fSelectionStartTime As Double
		Protected fSelectionEndTime As Double

#End Region

#Region "Properties"

  Public ReadOnly UIModeStrings As String() = {"invisible", "none", "mini", "full", "custom"}

  <DefaultValue("")> _
  Public Overrides Property Source() As String Implements IPlayer.Source 'ignore the warning: "'IPlayer.Source' is already implemented by the base class 'BasePlayer'. Re-implementation of property assumed."
   Get
    Return playerWMP.URL
   End Get
   Set(ByVal value As String)
    If value Is Nothing Then value = ""
    timerPlay.Enabled = (value <> "") '!!! must do this, else it starts playing when activity is closed
    playerWMP.URL = value
    Time = 0
    RaiseDurationChanged()

    'With playerWMP.Ctlcontrols
    ' Dim m As WMPLib.IWMPMedia = .currentItem
    ' If m IsNot Nothing Then .playItem(m)
    'End With

   End Set
  End Property

  Public Overrides Property VideoOn() As Boolean Implements IPlayer.VideoOn
   Get
    Return playerWMP.Visible
   End Get
   Set(ByVal value As Boolean)
    playerWMP.Visible = value 'could also set uiMode="invisible", but better not do it, cause that property adjusts visibility of player controls too (invisible, none, mini, full, custom)
   End Set
  End Property

  Public Overrides Property AudioOn() As Boolean Implements IPlayer.AudioOn
   Get
    Return Not playerWMP.settings.mute
   End Get
   Set(ByVal value As Boolean)
    playerWMP.settings.mute = Not value
   End Set
  End Property

  Public Overrides Property AudioVolume() As Double Implements IPlayer.AudioVolume
   Get
    Return playerWMP.settings.volume / fMaxInternalVolume
   End Get
   Set(ByVal value As Double)
    playerWMP.settings.volume = CInt(value * fMaxInternalVolume)
   End Set
  End Property

  Public Overrides Property Time() As Double Implements IPlayer.Time
   Get
    Dim result As Double = playerWMP.Ctlcontrols.currentPosition
    If SignificantDigits <> -1 Then Return Math.Round(result, SignificantDigits)
    Return result
   End Get
   Set(ByVal value As Double)
    If SignificantDigits <> -1 Then value = Math.Round(value, SignificantDigits)
    playerWMP.Ctlcontrols.currentPosition = value
   End Set
  End Property

  Public Overrides ReadOnly Property Duration() As Double Implements IPlayer.Duration
   Get
    Dim media As WMPLib.IWMPMedia = playerWMP.currentMedia '=playerWMP.Ctlcontrols.currentItem
    If media IsNot Nothing Then
     Return media.duration 'this won't work if we use collections, in that case get the total duration of the collection or calculate
    Else
     Return 0
    End If
   End Get
  End Property

  Public Overrides Property Rate() As Double Implements IPlayer.Rate
   Get
    With playerWMP
     If .playState = WMPPlayState.wmppsPlaying Then Return .settings.rate Else Return 0 'WMP never returns rate=0 (don't compare against WMPPlayState.wmppsPaused because we do FastBackwards at start to trick WMP to give us the duration, so MediaPlayer will return state WMPPlayState.wmppsMediaEnded after startup)
    End With
   End Get
   Set(ByVal value As Double)
    Dim changed As Boolean = (value <> Rate)
    CheckStartStopTimer(value) 'must be done before setting the new rate (necessery if we weren't playing already)
    With playerWMP
     If (value <> IPlayer.Rates.ratePaused) Then
      .settings.rate = value 'cannot set rate=IPlayer.Rates.ratePaused [=0] to WMP, just call pause instead '!!! may throw ArgumentException
      .Ctlcontrols.play()
     Else
      .Ctlcontrols.pause()
     End If
    End With
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

  <DefaultValue(False)> _
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
   With playerWMP
    .SendToBack()
    .uiMode = UIModeStrings(uiNoControls) 'must do here, cannot do in forms designer (may need to load movie first!)
    .settings.autoStart = False
    '.settings.enableErrorDialogs = False
   End With
  End Sub

  Protected Overrides Sub RaiseTimeChanged()
   If fPlaySelectionOnly Then
    If Time < SelectionStartTime Then
     gotoTime = SelectionStartTime
     If Rate < 0 Then pausePlayer = True 'cannot talk to WMP from the event handler (it's not reentrant), so notifying the timer to pause and jump to a certain time
     Exit Sub
    ElseIf (Time > SelectionEndTime) Then
     gotoTime = SelectionEndTime 'cannot talk to WMP from the event handler (it's not reentrant), so notifying the timer to pause and jump to a certain time
     If Rate > 0 Then pausePlayer = True
     Exit Sub
    End If
   End If
   MyBase.RaiseTimeChanged()
  End Sub

#End Region

#Region "Event handlers"

  Private Sub playerWMP_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles playerWMP.ErrorEvent
   With playerWMP.Error
				MessageBox.Show(Me, .Item(.errorCount - 1).errorDescription, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
   End With
  End Sub

  Private Sub playerWMP_OpenStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_OpenStateChangeEvent) Handles playerWMP.OpenStateChange
   'Debug.WriteLine(String.Format("OpenStateChange: state={0}, duration={1}", e.newState, Duration))
   If e.newState = WMPOpenState.wmposMediaOpen Then
    gotoTime = 0
    pausePlayer = True 'must do this after we found out the duration to avoid having some codecs autoplay the video (they don't support fast-backwards which we do to make WMP give us the duration of the movie and they start playback instead)
    RaiseDurationChanged()
   End If
  End Sub

  Private Sub playerWMP_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles playerWMP.PlayStateChange
   'Debug.WriteLine(String.Format("PlayStateChange: state={0}, duration={1}", e.newState, Duration))
   If e.newState = WMPPlayState.wmppsReady Then startPlayer = True 'must do this trick to have the timer force the player to go backwards and thus update the duration value which is 0 initially [cannot talk to WMP from the event handler (it's not reentrant)]
  End Sub

  Private Sub playerWMP_PositionChange(ByVal sender As System.Object, ByVal e As AxWMPLib._WMPOCXEvents_PositionChangeEvent) Handles playerWMP.PositionChange
   'RaiseTimeChanged() 'this event handler executes only at explicit events like position property setting or interaction with the user controls
  End Sub

#End Region

 End Class

End Namespace
