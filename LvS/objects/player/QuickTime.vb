'Description: QuickTime class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070413

Imports LvS.utilities.DebugUtils
Imports LvS.models.player

Namespace LvS.objects.players

 Public Class QuickTime
  Inherits BasePlayer 'not needed since the *.Design partial class inherits BasePlayer anyway (use "Show All Files" button of Solution Explorer to see those files grouped as children items of each control/form)
  Implements IPlayer

#Region "Fields"

  Protected fMaxInternalVolume As Double = 100 'must not be 0 'check if the new QT7 ActiveX Control has max volume = 100

#End Region

#Region "Properties"

  <DefaultValue("")> _
  Public Overrides Property Source() As String Implements IPlayer.Source
   Get
    Return playerQT.URL
   End Get
   Set(ByVal value As String)
    If value Is Nothing Then value = ""
    timerPlay.Enabled = (value <> "") '!!! must do this, else it starts playing when activity is closed
    playerQT.URL = value
    'we may need to set MovieControllerVisible=false again after loading a movie
    RaiseDurationChanged() 'inform that the movie duration has changed
   End Set
  End Property

  Public Overrides Property VideoOn() As Boolean Implements IPlayer.VideoOn
   Get
    Return playerQT.Visible
   End Get
   Set(ByVal value As Boolean)
    playerQT.Visible = value
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
    Return playerQT.Movie.PreferredAudioVolume / fMaxInternalVolume
   End Get
   Set(ByVal value As Double)
    playerQT.Movie.PreferredAudioVolume = CSng(value * fMaxInternalVolume)
   End Set
  End Property

  Public Overrides Property Time() As Double Implements IPlayer.Time
   Get
    With playerQT.Movie
     Dim result As Double = .Time / .TimeScale
     If SignificantDigits <> -1 Then Return Math.Round(result, SignificantDigits)
     Return result
    End With
   End Get
   Set(ByVal value As Double)
    If SignificantDigits <> -1 Then value = Math.Round(value, SignificantDigits)
    With playerQT.Movie
     .Time = CInt(value * .TimeScale)
    End With
   End Set
  End Property

  Public Overrides ReadOnly Property Duration() As Double Implements IPlayer.Duration
   Get
    Return playerQT.Movie.Duration
   End Get
  End Property

  Public Overrides Property Rate() As Double Implements IPlayer.Rate
   Get
    Return playerQT.Movie.Rate
   End Get
   Set(ByVal value As Double)
    Dim changed As Boolean = (value <> Rate)
    CheckStartStopTimer(value) 'must be done before setting the new rate (necessery if we weren't playing already)
    playerQT.Movie.Rate = CSng(value)
    If changed Then RaiseRateChanged()
   End Set
  End Property

  Public Overrides Property SelectionStartTime() As Double Implements IPlayer.SelectionStartTime
   Get
    With playerQT.Movie
     Return .SelectionStart / .TimeScale
    End With
   End Get
   Set(ByVal value As Double)
    If value > Duration Then value = Duration - 0.01
    If value <> SelectionStartTime Then
     With playerQT.Movie
      .SelectionStart = CInt(value * .TimeScale)
     End With
     RaiseSelectionStartTimeChanged()
    End If
   End Set
  End Property

  Public Overrides Property SelectionEndTime() As Double Implements IPlayer.SelectionEndTime
   Get
    With playerQT.Movie
     Return .SelectionEnd / .TimeScale
    End With
   End Get
   Set(ByVal value As Double)
    If value > Duration Then value = Duration - 0.01
    If value <> SelectionEndTime Then
     With playerQT.Movie
      .SelectionEnd = CInt(value * .TimeScale)
     End With
     RaiseSelectionEndTimeChanged()
    End If
   End Set
  End Property

  Public Overrides Property PlaySelectionOnly() As Boolean Implements IPlayer.PlaySelectionOnly
   Get
    Return playerQT.Movie.PlaySelectionOnly
   End Get
   Set(ByVal value As Boolean)
    playerQT.Movie.PlaySelectionOnly = value
   End Set
  End Property

#End Region

#Region "Methods"

  Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()
   ' Add any initialization after the InitializeComponent() call.
   ' Must do the following here, instead of at "Load" event, cause that event does not occur if object is instantiated outside of a form
   playerQT.SendToBack()
  End Sub

#End Region

 End Class

End Namespace
