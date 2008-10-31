'Description: ITimeSelection interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070402

Namespace LvS.models.player

 Public Interface ITimeSelection
  Inherits ITimePosition

#Region "Properties"

  Property SelectionStartTime() As Double 'in sec
  Property SelectionEndTime() As Double

#End Region

#Region "Events"

  Event SelectionStartTimeChanged(ByVal source As ITimeSelection, ByVal newStartTime As Double)
  Event SelectionEndTimeChanged(ByVal source As ITimeSelection, ByVal newEndTime As Double)

#End Region

 End Interface

End Namespace
