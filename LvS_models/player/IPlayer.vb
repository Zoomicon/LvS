'Description: IPlayer interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070411

Imports System.Drawing
Imports LvS.models.subtitles

Namespace LvS.models.player

 Public Interface IPlayer
  Inherits IAudioVolume, ITimePosition, ITimeSelection

#Region "Classes"

  NotInheritable Class Rates
   Public Const ratePaused As Double = 0
   Public Const rateNormal As Double = 1
   Public Const rateFaster As Double = 1.3
   Public Const rateSlower As Double = 0.7
   Public Const rateFastForward As Double = 5.0
   Public Const rateFastBackwards As Double = -rateFastForward
  End Class

#End Region

#Region "Properties"

  Property AuthoringMode() As Boolean
  Property Source() As String 'allow URLs too if player supports them 'throws EFileNotFound exception
  Property VideoOn() As Boolean
  Property AudioOn() As Boolean
  Property SubtitlesOn() As Boolean
  Property Rate() As Double
  Property Paused() As Boolean
  Property SpeedControlsVisible() As Boolean
  Property ControlsVisible() As Boolean
  Property PlaySelectionOnly() As Boolean
  Property Subtitle1() As String
  Property Subtitle2() As String
  Property SubtitleFont() As Font
  ReadOnly Property EditingSubtitles() As Boolean

#End Region

#Region "Methods"

  Overloads Sub Play() 'set Rate=rateNormal
  Overloads Sub Play(ByVal startTime As Double) 'set Time, then set Rate=1
  Sub FastForward() 'set Rate=rateFastForward
  Sub FastBackwards() 'set Rate=rateFastBackwards
  Sub Faster() 'set Rate=rateFaster if rate=0, else =rateFaster*sgn(rate)
  Sub Slower() 'set Rate=rateSlower if rate =0. else =rateSlower*sgn(rate)
  Sub Pause() 'set Rate=ratePaused
  Sub Finish() 'set Rate=ratePaused, Time=0
  Sub GotoStart() 'set Time=0
  Sub GotoEnd() 'set Time=Length

#End Region

#Region "Events"

  Event RateChanged(ByVal source As IPlayer, ByVal newRate As Double)
  Event SubtitleChanged(ByVal source As IPlayer, ByVal subtitle1 As String, ByVal subtitle2 As String)

#End Region

 End Interface

End Namespace
