'Description: TimeSelectionController class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070410

'NOTE: make sure SmallChange=00:00:00.0001000 is used at the slider, else accuracy errors will eventually occur

Imports System.ComponentModel
Imports LvS.models.player
Imports LvS.utilities.DateTimeUtils

Namespace LvS.objects.controllers

 Public Class TimeSelectionController
  Implements ITimeSelectionController

#Region "Constants"

  Public Const SignificantDigits As Integer = 2

#End Region

#Region "Fields"

  Protected timeUpdating As Boolean = False
  Protected fTimePosition As ITimePosition
  Protected fTimeSelection As ITimeSelection

#End Region

#Region "Properties"

  Property TimePosition() As ITimePosition Implements ITimeSelectionController.TimePosition
   Get
    Return fTimePosition
   End Get
   Set(ByVal value As ITimePosition)
    fTimePosition = value
    If fTimePosition IsNot Nothing Then
     sliderTime.Value = SecondsToDateTime(fTimePosition.Time, DATETIMEZERO, SignificantDigits)
     Duration = fTimePosition.Duration 'this doesn't talk back to fTimePosition, since it's duration field is readonly (so no fear for infinite loop)
    End If
   End Set
  End Property

  Property TimeSelection() As ITimeSelection Implements ITimeSelectionController.TimeSelection
   Get
    Return fTimeSelection
   End Get
   Set(ByVal value As ITimeSelection)
    fTimeSelection = value
    If fTimeSelection IsNot Nothing Then
     sliderTime.SegmentStart = SecondsToDateTime(fTimeSelection.SelectionStartTime, DATETIMEZERO, SignificantDigits)
     sliderTime.SegmentEnd = SecondsToDateTime(fTimeSelection.SelectionEndTime, DATETIMEZERO, SignificantDigits)
    End If
   End Set
  End Property

  Public Property Time() As Double Implements ITimeSelectionController.Time
   Get
    Return DateTimeToSeconds(sliderTime.Value, DATETIMEZERO, SignificantDigits)
   End Get
   Set(ByVal newValue As Double)
    If timeUpdating Then Exit Property
    timeUpdating = True
    sliderTime.Value = SecondsToDateTime(newValue, DATETIMEZERO, SignificantDigits) 'SecondsToDateTime will handle exceptions, returning the base datetime passed to it in that case
    'If fTimePosition IsNot Nothing Then fTimePosition.Time = newValue 'do not call, chokes the video
    timeUpdating = False
   End Set
  End Property

  Public Property Duration() As Double Implements ITimeSelectionController.Duration
   Get
    With sliderTime
     Return TimeSpanToSeconds(.Minimum, .Maximum)
    End With
   End Get
   Set(ByVal value As Double)
    EndTime = StartTime + value
   End Set
  End Property

  <DefaultValue(0)> _
  Public Property StartTime() As Double Implements ITimeSelectionController.StartTime
   Get
    Return DateTimeToSeconds(sliderTime.Minimum, DATETIMEZERO, SignificantDigits)
   End Get
   Set(ByVal newValue As Double)
    EndTime = newValue + Duration 'must do before setting "Minimum" in order to get the previous duration
    sliderTime.Minimum = SecondsToDateTime(newValue, DATETIMEZERO, SignificantDigits) 'SecondsToDateTime will handle exceptions, returning the base datetime passed to it in that case
   End Set
  End Property

  Public Property EndTime() As Double Implements ITimeSelectionController.EndTime
   Get
    Return DateTimeToSeconds(sliderTime.Maximum, DATETIMEZERO, SignificantDigits)
   End Get
   Set(ByVal newValue As Double)
    sliderTime.Maximum = SecondsToDateTime(newValue, DATETIMEZERO, SignificantDigits) 'SecondsToDateTime will handle exceptions, returning the base datetime passed to it in that case
   End Set
  End Property

  Public Property SelectionStartTime() As Double Implements ITimeSelectionController.SelectionStartTime
   Get
    Return DateTimeToSeconds(sliderTime.SegmentStart, DATETIMEZERO, SignificantDigits)
   End Get
   Set(ByVal newValue As Double)
    sliderTime.SegmentStart = SecondsToDateTime(newValue, DATETIMEZERO, SignificantDigits) 'SecondsToDateTime will handle exceptions, returning the base datetime passed to it in that case
    'If fTimeSelection IsNot Nothing Then fTimeSelection.SelectionStartTime = newValue 'do not call, will do infinite loop
   End Set
  End Property

  Public Property SelectionEndTime() As Double Implements ITimeSelectionController.SelectionEndTime
   Get
    Return DateTimeToSeconds(sliderTime.SegmentEnd, DATETIMEZERO, SignificantDigits)
   End Get
   Set(ByVal newValue As Double)
    sliderTime.SegmentEnd = SecondsToDateTime(newValue, DATETIMEZERO, SignificantDigits) 'SecondsToDateTime will handle exceptions, returning the base datetime passed to it in that case
    'If fTimeSelection IsNot Nothing Then fTimeSelection.SelectionEndTime = newValue 'do not call, will do infinite loop
   End Set
  End Property

#End Region

#Region "Methods"

  Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()
   ' Add any initialization after the InitializeComponent() call.
   StartTime = 0 'init slider's start time using our own time conversion routines
  End Sub

#End Region

#Region "Events"

  Private Sub sliderTime_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sliderTime.Scroll 'must use this event instead of ValueChanged
   If timeUpdating Then Exit Sub
   timeUpdating = True
   If fTimePosition IsNot Nothing Then fTimePosition.Time = DateTimeToSeconds(sliderTime.Value, DATETIMEZERO, SignificantDigits)
   timeUpdating = False
  End Sub

  'add way to change selection on the time slider using mouse and/or keys

#End Region

 End Class

End Namespace
