'Description: IController interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070404

Namespace LvS.models.player

 Public Interface IController

#Region "Properties"

  Property Player() As IPlayer

  Property Time() As Double
  Property Duration() As Double
  Property SelectionStartTime() As Double
  Property SelectionEndTime() As Double

  Property SpeedControlsVisible() As Boolean
  Property SubtitlesOn() As Boolean

#End Region

#Region "Methods"

  Sub Play()
  Sub Pause()
  Sub FastBackwards()
  Sub FastForward()
  Sub Slower()
  Sub Faster()
  Sub ReplaySelection()

#End Region

 End Interface

End Namespace
