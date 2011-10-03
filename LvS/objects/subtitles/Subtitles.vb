'Description: Subtitles class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.ComponentModel
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles
Imports LvS.utilities.subtitles.SubtitleUtils

Namespace LvS.objects.subtitles

 Public Class Subtitles
  Inherits List(Of ISubtitle)
  Implements ISubtitles

#Region "Fields"

  Protected fSource As String = ""
  Protected fEncoding As System.Text.Encoding
  Protected fGrid As SourceGrid.Grid

#End Region

#Region "Properties"

  Public Property CurrentIndex() As Integer Implements ISubtitles.CurrentIndex
			Get
				If (fGrid Is Nothing) Then Return -1
				Dim sel As Integer() = fGrid.Selection.GetRowsIndex
				If (sel.Length > 0) Then Return sel(0) Else Return -1
			End Get
   Set(ByVal value As Integer)
				If (value <> CurrentIndex) Then
					If (fGrid IsNot Nothing) Then fGrid.Selection.FocusRow(value)
					RaiseEvent CurrentIndexChanged(Me, value)
					RaiseEvent TimeChanged(Me, CurrentTime)
				End If
   End Set
  End Property

  Public Property CurrentTime() As Double Implements ISubtitles.CurrentTime
   Get
    Return FindStartTimeByIndex(CurrentIndex) 'if asked for time, returning the start time of current row (lookout for spurious event loops cause that time is <= the time that was set)
   End Get
   Set(ByVal value As Double)
    CurrentIndex = FindIndexByTime(value)
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Source() As String Implements ISubtitles.Source
   Get
    Return fSource
   End Get
   Set(ByVal value As String)
    ReadSubtitles(Me, value, Encoding)
    fSource = value
   End Set
  End Property

  Public Property Encoding() As System.Text.Encoding Implements ISubtitles.Encoding
   Get
    Return fEncoding
   End Get
   Set(ByVal value As System.Text.Encoding)
    fEncoding = value
   End Set
  End Property

#End Region

#Region "Methods"

		Public Sub New()
			'NOP
		End Sub

		Public Sub New(ByVal grid As SourceGrid.Grid)
			fGrid = grid
		End Sub

		Public Overloads Function NewSubtitle() As ISubtitle Implements ISubtitles.NewSubtitle
			Return New Subtitle
		End Function

		Public Overloads Function NewSubtitle(ByVal theStartTime As Double, ByVal theEndTime As Double) As ISubtitle Implements ISubtitles.NewSubtitle
			Return New Subtitle(theStartTime, theEndTime)
		End Function

		Public Sub Save() Implements ISubtitles.Save
			SubtitleUtils.WriteSubtitles(Me, fSource, Encoding)
		End Sub

		Public Function FindIndexByTime(ByVal theTime As Double) As Integer Implements ISubtitles.FindIndexByTime
			Dim index As Integer = 0
			For Each s As ISubtitle In Me
				If (theTime >= s.StartTime) AndAlso (theTime <= s.EndTime) Then Return index
				index += 1
			Next s
			Return -1
		End Function

		Public Function FindCurrentOrPreviousIndexByTime(ByVal theTime As Double) As Integer Implements ISubtitles.FindCurrentOrPreviousIndexByTime
			For index As Integer = Count - 1 To 0 Step -1	'scanning backwards
				Dim s As ISubtitle = Item(index)
				If (s.StartTime <= theTime) Then Return index
			Next index
			Return -1
		End Function

		Public Function FindCurrentOrNextIndexByTime(ByVal theTime As Double) As Integer Implements ISubtitles.FindCurrentOrNextIndexByTime
			For index As Integer = 0 To Count - 1	'scanning forward
				Dim s As ISubtitle = Item(index)
				If (s.EndTime >= theTime) Then Return index
			Next index
			Return -1
		End Function

		Public Function FindStartTimeByIndex(ByVal theIndex As Integer) As Double Implements ISubtitles.FindStartTimeByIndex
			Return Item(theIndex).StartTime
		End Function

		Public Function FindStartTimeByTime(ByVal theTime As Double) As Double Implements ISubtitles.FindStartTimeByTime
			Return FindStartTimeByIndex(FindIndexByTime(theTime))
		End Function

#End Region

#Region "Events"

  Public Event CurrentIndexChanged(ByVal source As ISubtitles, ByVal newIndex As Integer) Implements ISubtitles.CurrentIndexChanged
  Public Event SubtitleChanged(ByVal source As ISubtitles, ByVal theIndex As Integer, ByVal theSubtitle As ISubtitle) Implements ISubtitles.SubtitleChanged
  Public Event TimeChanged(ByVal source As ISubtitles, ByVal newTime As Double) Implements ISubtitles.TimeChanged

#End Region

 End Class

End Namespace
