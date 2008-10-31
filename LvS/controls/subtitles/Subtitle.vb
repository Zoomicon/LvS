'Description: Subtitle class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080422

Imports System.ComponentModel
Imports LvS.models.subtitles
Imports LvS.utilities

Namespace LvS.objects.subtitles

 Public Class Subtitle
  Implements ISubtitle

#Region "Constants"

  Public Const MIN_DURATION As Double = 1
  Public Const MAX_DURATION As Double = 6

#End Region

#Region "Fields"

  Protected fStartTime As Double = 0
  Protected fEndTime As Double = 0
  Protected fSubtitle1 As String = ""
  Protected fSubtitle2 As String = ""

  Protected fTeacherCommentIcon As Integer = -1
  Protected fTeacherComment As String = ""
  Protected fStudentCommentIcon As Integer = -1
  Protected fStudentComment As String = ""

#End Region

#Region "Properties"

		<DefaultValue(0)> _
		Public Property StartTime() As Double Implements ISubtitle.StartTime	'see SetTimes method
			Get
				Return fStartTime
			End Get
			Set(ByVal value As Double)
				If (value > fEndTime) Then Throw New ArgumentOutOfRangeException(My.Resources.STR_ENDTIME_GREATEREQUAL_STARTTIME)
				fStartTime = value
				RaiseEvent StartTimeChanged(Me, value)	'raise event after setting the new value
			End Set
		End Property

		<DefaultValue(0)> _
		Public Property EndTime() As Double Implements ISubtitle.EndTime	'see SetTimes method
			Get
				Return fEndTime
			End Get
			Set(ByVal value As Double)
				If (fStartTime > value) Then Throw New ArgumentOutOfRangeException(My.Resources.STR_ENDTIME_GREATEREQUAL_STARTTIME)
				fEndTime = value
				RaiseEvent EndTimeChanged(Me, value)	'raise event after setting the new value
			End Set
		End Property

  <DefaultValue(0)> _
  Public Property Duration() As Double Implements ISubtitle.Duration
   Get
    Return fEndTime - fStartTime 'the subtitle period is [fStartTime, fEndTime), that is it doesn't include fEndTime
   End Get
   Set(ByVal value As Double)
    If (value < MIN_DURATION) OrElse (value > MAX_DURATION) Then Throw New ArgumentOutOfRangeException(My.Resources.STR_DURATION_POSITIVE)
    EndTime = fStartTime + value 'do not set fEndTime directly, want change event to be raised
    RaiseEvent DurationChanged(Me, value) 'raise event after setting the new value
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Subtitle1() As String Implements ISubtitle.Subtitle1
   Get
    Return fSubtitle1
   End Get
   Set(ByVal value As String)
    fSubtitle1 = value
    RaiseEvent Subtitle1Changed(Me, value)
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Subtitle2() As String Implements ISubtitle.Subtitle2
   Get
    Return fSubtitle2
   End Get
   Set(ByVal value As String)
    fSubtitle2 = value
    RaiseEvent Subtitle2Changed(Me, value)
   End Set
  End Property

  <DefaultValue(-1)> _
  Public Property TeacherCommentIcon() As Integer Implements ISubtitle.TeacherCommentIcon
   Get
    Return fTeacherCommentIcon
   End Get
   Set(ByVal value As Integer)
    fTeacherCommentIcon = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Property TeacherComment() As String Implements ISubtitle.TeacherComment
   Get
    Return fTeacherComment
   End Get
   Set(ByVal value As String)
    fTeacherComment = value
   End Set
  End Property

  <DefaultValue(-1)> _
  Public Property StudentCommentIcon() As Integer Implements ISubtitle.StudentCommentIcon
   Get
    Return fStudentCommentIcon
   End Get
   Set(ByVal value As Integer)
    fStudentCommentIcon = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Property StudentComment() As String Implements ISubtitle.StudentComment
   Get
    Return fStudentComment
   End Get
   Set(ByVal value As String)
    fStudentComment = value
   End Set
  End Property

#End Region

#Region "Methods"

#Region "Constructor"

		Public Sub New()
			'SetTimes(0,0) 'assuming times are initialized to 0 by default
		End Sub

		Public Sub New(ByVal theStartTime As Double, ByVal theEndTime As Double)
			SetTimes(theStartTime, theEndTime)
		End Sub

#End Region

		Public Sub SetTimes(ByVal theStartTime As Double, ByVal theEndTime As Double) Implements ISubtitle.SetTimes
			If (theStartTime > theEndTime) Then Throw New ArgumentOutOfRangeException(My.Resources.STR_ENDTIME_GREATEREQUAL_STARTTIME)
			fStartTime = theStartTime
			fEndTime = theEndTime
			RaiseEvent StartTimeChanged(Me, theStartTime)	'raise event after setting the new value
			RaiseEvent EndTimeChanged(Me, theEndTime)	'raise event after setting the new value
  End Sub

  Public Function IsTimeIncluded(ByVal theTime As Double) As Boolean Implements ISubtitle.IsTimeIncluded
   Return ((StartTime <= theTime) AndAlso (theTime <= EndTime))
  End Function

#End Region

#Region "Events"

		Public Event StartTimeChanged(ByVal source As ISubtitle, ByVal newTime As Double) Implements ISubtitle.StartTimeChanged
		Public Event EndTimeChanged(ByVal source As ISubtitle, ByVal newTime As Double) Implements ISubtitle.EndTimeChanged
		Public Event DurationChanged(ByVal source As ISubtitle, ByVal newDuration As Double) Implements ISubtitle.DurationChanged
		Public Event Subtitle1Changed(ByVal source As ISubtitle, ByVal newLine As String) Implements ISubtitle.Subtitle1Changed
		Public Event Subtitle2Changed(ByVal source As ISubtitle, ByVal newLine As String) Implements ISubtitle.Subtitle2Changed

#End Region

	End Class

End Namespace
