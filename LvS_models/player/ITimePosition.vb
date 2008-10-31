'Description: ITimePosition interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070402

Namespace LvS.models.player

 Public Interface ITimePosition

#Region "Properties"

  Property Time() As Double 'in sec
  ReadOnly Property Duration() As Double

#End Region

#Region "Events"

  Event TimeChanged(ByVal source As ITimePosition, ByVal newTime As Double)
  Event DurationChanged(ByVal source As ITimePosition, ByVal newDuration As Double)

#End Region

 End Interface

End Namespace
