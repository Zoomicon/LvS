'Description: BasePlayer class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20111206

Imports System.ComponentModel
Imports LvS.models.player
Imports LvS.models.player.IPlayer.Rates
Imports LvS.utilities.DebugUtils

Namespace LvS.objects.players

  Public Class BasePlayer
    Implements IPlayer

#Region "Constants"

    Public Const SignificantDigits As Integer = 2

#End Region

#Region "Fields"

    Protected fAuthoringMode As Boolean 'set to False at constructor

    Protected startPlayer As Boolean
    Protected pausePlayer As Boolean
    Protected gotoTime As Double = -1

#End Region

#Region "Properties"

    Public Property Paused() As Boolean Implements IPlayer.Paused
      Get
        Return (Rate = IPlayer.Rates.ratePaused)
      End Get
      Set(ByVal value As Boolean)
        If value <> Paused Then
          If value Then Pause() Else Play()
        End If
      End Set
    End Property

    <DefaultValue(True)> _
    Public Property ControlsVisible() As Boolean Implements IPlayer.ControlsVisible
      Get
        Return ControllerBar.Visible
      End Get
      Set(ByVal value As Boolean)
        ControllerBar.Visible = value
      End Set
    End Property

    <DefaultValue(False)> _
    Public Property AuthoringMode() As Boolean Implements IPlayer.AuthoringMode
      Get
        Return fAuthoringMode
      End Get
      Set(ByVal value As Boolean)
        fAuthoringMode = value
        SpeedControlsVisible = value
      End Set
    End Property

    <DefaultValue("")> _
    Public Overridable Property Source() As String Implements IPlayer.Source
      Get
        NotImplemented()
        Return ""
      End Get
      Set(ByVal value As String)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property VideoOn() As Boolean Implements IPlayer.VideoOn
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Boolean)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property AudioOn() As Boolean Implements IPlayer.AudioOn
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Boolean)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property SubtitlesOn() As Boolean Implements IPlayer.SubtitlesOn
      Get
        Return tableSubtitles.Visible
      End Get
      Set(ByVal value As Boolean)
        If tableSubtitles IsNot Nothing Then tableSubtitles.Visible = value
      End Set
    End Property

    Public Overridable Property FullScreen As Boolean Implements IPlayer.FullScreen
      Get
        Return ControllerBar.FullScreen
      End Get
      Set(value As Boolean)
        ControllerBar.FullScreen = True 'that one checks internally if set to same value and doesn't throw change event again (which would cause spurious loop here)
        RaiseEvent FullScreenChanged(Me, value) 'always raise the event, don't compare value with FullScreen property since it calls ControllerBar and would always be equal when this is called due to ControllerBar's FullScreenChanged event firing
      End Set
    End Property

    Public Overridable Property AudioVolume() As Double Implements IPlayer.AudioVolume
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Double)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property Time() As Double Implements IPlayer.Time
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Double)
        NotImplemented()
      End Set
    End Property

    Public Overridable ReadOnly Property Duration() As Double Implements IPlayer.Duration
      Get
        NotImplemented()
      End Get
    End Property

    Public Overridable Property SelectionStartTime() As Double Implements IPlayer.SelectionStartTime
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Double)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property SelectionEndTime() As Double Implements IPlayer.SelectionEndTime
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Double)
        NotImplemented()
      End Set
    End Property

    <DefaultValue(False)> _
    Public Overridable Property PlaySelectionOnly() As Boolean Implements IPlayer.PlaySelectionOnly
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Boolean)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property Rate() As Double Implements IPlayer.Rate
      Get
        NotImplemented()
      End Get
      Set(ByVal value As Double)
        NotImplemented()
      End Set
    End Property

    Public Overridable Property SpeedControlsVisible() As Boolean Implements IPlayer.SpeedControlsVisible
      Get
        Return ControllerBar.SpeedControlsVisible
      End Get
      Set(ByVal value As Boolean)
        ControllerBar.SpeedControlsVisible = value
      End Set
    End Property

    Public Property Subtitle1() As String Implements IPlayer.Subtitle1
      Get
        Return txtSubtitle1.Text
      End Get
      Set(ByVal value As String)
        txtSubtitle1.Text = value
        txtSubtitle1.Modified = False
        ToolTips.SetToolTip(txtSubtitle1, value)
      End Set
    End Property

    Public Property Subtitle2() As String Implements IPlayer.Subtitle2
      Get
        Return txtSubtitle2.Text
      End Get
      Set(ByVal value As String)
        txtSubtitle2.Text = value
        txtSubtitle2.Modified = False
        ToolTips.SetToolTip(txtSubtitle2, value)
      End Set
    End Property

    Public Property SubtitleFont() As Font Implements IPlayer.SubtitleFont
      Get
        Return txtSubtitle1.Font
      End Get
      Set(ByVal value As Font)
        txtSubtitle1.Font = value
        txtSubtitle2.Font = value
      End Set
    End Property

    Public ReadOnly Property EditingSubtitles() As Boolean Implements IPlayer.EditingSubtitles
      Get
        Return txtSubtitle1.Focused OrElse txtSubtitle2.Focused
      End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ' Must do the following here, instead of at "Load" event, cause that event does not occur if object is instantiated outside of a form
      AuthoringMode = False
      Subtitle1 = ""
      Subtitle2 = ""
    End Sub

    Protected Sub CheckStartStopTimer(ByVal newRate As Double)
      'KEEP THE TIMER AS IT WAS HERE, DO NOT CHANGE ITS STATE (NEEDED FOR INITIAL DURATION TO BE CALCULATED BY WMP)
      'timerPlay.Enabled = (newRate <> ratePaused) 'start/stop timer depending on playback or not 'must be done before setting the new rate (necessery if we weren't playing already)
    End Sub

    Public Overloads Sub Play() Implements IPlayer.Play
      Rate = rateNormal
    End Sub

    Public Overloads Sub Play(ByVal startTime As Double) Implements IPlayer.Play
      Pause() 'must pause first
      Time = startTime
      Rate = rateNormal
    End Sub

    Public Sub Faster() Implements IPlayer.Faster
      If Rate() = 0 Then
        Rate = rateFaster
      Else
        Rate = rateFaster * Math.Sign(Rate)
      End If
    End Sub

    Public Sub Slower() Implements IPlayer.Slower
      If Rate() = 0 Then
        Rate = rateSlower
      Else
        Rate = rateSlower * Math.Sign(Rate)
      End If
    End Sub

    Public Sub FastForward() Implements IPlayer.FastForward
      Rate = rateFastForward
    End Sub

    Public Sub FastBackwards() Implements IPlayer.FastBackwards
      Rate = rateFastBackwards
    End Sub

    Public Sub Pause() Implements IPlayer.Pause
      Rate = ratePaused
    End Sub

    Public Sub Finish() Implements IPlayer.Finish
      Pause()
      GotoStart()
    End Sub

    Public Sub GotoStart() Implements IPlayer.GotoStart
      Time = 0
    End Sub

    Public Sub GotoEnd() Implements IPlayer.GotoEnd
      Time = Duration
    End Sub

    Protected Sub BringSubtitlesToFront()
      tableSubtitles.BringToFront()
    End Sub

    Protected Overridable Sub RaiseTimeChanged()
      'Debug.WriteLine("New time: " & CStr(Time))
      RaiseEvent TimeChanged(Me, Time)
    End Sub

    Protected Overridable Sub RaiseDurationChanged()
      'Debug.WriteLine("New duration: " & CStr(Duration))
      ControllerBar.Duration = Duration
      RaiseEvent DurationChanged(Me, Duration)
    End Sub

    Protected Sub RaiseSelectionStartTimeChanged()
      ControllerBar.SelectionStartTime = SelectionStartTime
      RaiseEvent SelectionStartTimeChanged(Me, SelectionStartTime)
    End Sub

    Protected Sub RaiseSelectionEndTimeChanged()
      ControllerBar.SelectionEndTime = SelectionEndTime
      RaiseEvent SelectionEndTimeChanged(Me, SelectionEndTime)
    End Sub

    Protected Sub RaiseRateChanged()
      RaiseEvent RateChanged(Me, Rate)
    End Sub

#End Region

#Region "Events"

    Public Event TimeChanged(ByVal source As ITimePosition, ByVal newTime As Double) Implements IPlayer.TimeChanged
    Public Event DurationChanged(ByVal source As ITimePosition, ByVal newDuration As Double) Implements IPlayer.DurationChanged
    Public Event SelectionStartTimeChanged(ByVal source As ITimeSelection, ByVal newStartTime As Double) Implements IPlayer.SelectionStartTimeChanged
    Public Event SelectionEndTimeChanged(ByVal source As ITimeSelection, ByVal newEndTime As Double) Implements IPlayer.SelectionEndTimeChanged
    Public Event RateChanged(ByVal source As IPlayer, ByVal newRate As Double) Implements IPlayer.RateChanged
    Public Event SubtitleChanged(ByVal source As IPlayer, ByVal subtitle1 As String, ByVal subtitle2 As String) Implements IPlayer.SubtitleChanged
    Public Event FullScreenChanged(ByVal source As IPlayer, ByVal fullscreen As Boolean) Implements IPlayer.FullScreenChanged

    Private Sub BasePlayer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      ControllerBar.Player = Me 'must do this at "Load" event handler, not at constructor
    End Sub

    Protected Sub timerPlay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPlay.Tick
      ControllerBar.Time = Time
      If startPlayer Then
        startPlayer = False
        FastBackwards()
      ElseIf pausePlayer Then
        pausePlayer = False
        Time = gotoTime
        gotoTime = -1
        Pause()
      Else
        RaiseTimeChanged()
      End If
    End Sub

    Private Sub txtSubtitle_Change()
      Dim s1 As String = txtSubtitle1.Text
      Dim s2 As String = txtSubtitle2.Text
      ToolTips.SetToolTip(txtSubtitle1, s1)
      ToolTips.SetToolTip(txtSubtitle2, s2)
      RaiseEvent SubtitleChanged(Me, s1, s2)
    End Sub

    Private Sub txtSubtitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubtitle1.KeyDown, txtSubtitle2.KeyDown
      If e.KeyCode = Keys.Enter Then txtSubtitle_Change()
    End Sub

    'removed: keep tooltips disabled, they were flashing with certain video players (also at the designer we now use Tooltips.Active=False)
    'Private Sub txtSubtitle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtitle1.Enter, txtSubtitle2.Enter
    'ToolTips.Active = False 'do not show tooltip for either subtitle textbox when either of them is being edited
    'End Sub

    Private Sub txtSubtitle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubtitle1.Leave, txtSubtitle2.Leave
      If txtSubtitle1.Modified OrElse txtSubtitle2.Modified Then txtSubtitle_Change()
      'ToolTips.Active = True 're-enable tooltips 'removed: keep tooltips disabled, they were flashing with certain video players (also at the designer we now use Tooltips.Active=False)
    End Sub

    Private Sub ControllerBar_SubtitlesOnChanged(ByVal source As IController, ByVal subtitlesOn As Boolean) Handles ControllerBar.SubtitlesOnChanged
      Me.SubtitlesOn = subtitlesOn
    End Sub

    Private Sub ControllerBar_FullScreenChanged(ByVal source As IController, ByVal fullscreen As Boolean) Handles ControllerBar.FullScreenChanged
      Me.FullScreen = fullscreen
    End Sub

#End Region

  End Class

End Namespace
