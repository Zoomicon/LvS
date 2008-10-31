'Description: ISubtitle interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080422

Namespace LvS.models.subtitles

 Public Interface ISubtitle

#Region "Properties"

		Property StartTime() As Double	'see SetTimes method
		Property EndTime() As Double	'see SetTimes method
  Property Duration() As Double
  Property Subtitle1() As String
  Property Subtitle2() As String

  Property TeacherCommentIcon() As Integer
  Property TeacherComment() As String
  Property StudentCommentIcon() As Integer
  Property StudentComment() As String

#End Region

#Region "Methods"

  Sub SetTimes(ByVal theStartTime As Double, ByVal theEndTime As Double) 'set StartTime and EndTime at a single step (setting the times separately can raise time constraint exceptions)
  Function IsTimeIncluded(ByVal theTime As Double) As Boolean

#End Region

#Region "Events"

  Event StartTimeChanged(ByVal source As ISubtitle, ByVal newTime As Double)
  Event EndTimeChanged(ByVal source As ISubtitle, ByVal newTime As Double)
  Event DurationChanged(ByVal source As ISubtitle, ByVal newDuration As Double)
  Event Subtitle1Changed(ByVal source As ISubtitle, ByVal newLine As String)
  Event Subtitle2Changed(ByVal source As ISubtitle, ByVal newLine As String)

#End Region

 End Interface

End Namespace
