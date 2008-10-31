'Description: ITimeSelectionController interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070404

Namespace LvS.models.player

 Public Interface ITimeSelectionController

#Region "Properties"

  Property TimePosition() As ITimePosition
  Property TimeSelection() As ITimeSelection

  Property Time() As Double
  Property Duration() As Double
  Property StartTime() As Double
  Property EndTime() As Double
  Property SelectionStartTime() As Double
  Property SelectionEndTime() As Double

#End Region

 End Interface

End Namespace
