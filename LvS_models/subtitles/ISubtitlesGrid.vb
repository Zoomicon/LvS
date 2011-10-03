'Description: ISubtitlesGrid interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.Text
Imports LvS.models

Namespace LvS.models.subtitles

 Public Interface ISubtitlesGrid
  Inherits IModifiable

#Region "Enums"

  Enum Columns
   colNone = -1
   colIndex = 0
   colStartTime = 1
   colEndTime = 2
   colDuration = 3
   colSubtitles = 4
   colTeacherComment = 5
   colStudentComment = 6
  End Enum

#End Region

#Region "Properties"

  Property Source() As String
  Property Encoding() As Encoding
  Property AuthoringMode() As Boolean

  Property FocusedRow() As Integer
  Property FocusedColumn() As Columns

  Property ColumnIndexVisible() As Boolean
  Property ColumnStartTimeVisible() As Boolean
  Property ColumnEndTimeVisible() As Boolean
  Property ColumnDurationVisible() As Boolean

  Property Time() As Double
  Property StartTime() As Double
  Property EndTime() As Double

  ReadOnly Property Subtitles() As ISubtitles 'avoid talking to this object directly, the implementation may not be synchronizing with its internal subtitles object in two-way fashion

  Overloads Property Subtitle1() As String
  Overloads Property Subtitle1(ByVal theTime As Double) As String
  Overloads Property Subtitle2() As String
  Overloads Property Subtitle2(ByVal theTime As Double) As String

#End Region

#Region "Methods"

  Sub Save()
		Sub Export(ByVal path As String, ByVal theEncoding As Encoding)
  Sub InsertSubtitle(ByVal theStartTime As Double, ByVal theEndTime As Double, ByVal theSubtitle1 As String, ByVal theSubtitle2 As String)
  Sub RemoveSelected()

  Sub ChangeTeacherComment(ByVal theRow As Integer)
  Sub ChangeStudentComment(ByVal theRow As Integer)
  Sub UpdateComments()

#End Region

#Region "Events"

  Event TimeChanged(ByVal source As ISubtitlesGrid, ByVal newTime As Double)
  Event FocusedRowChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)
  Event FocusedColumnChanged(ByVal source As ISubtitlesGrid, ByVal theColumn As Columns)

  Event SubtitleInserted(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)
  Event SubtitleRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)

  Event TeacherCommentChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)
  Event TeacherCommentRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)

  Event StudentCommentChanged(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)
  Event StudentCommentRemoved(ByVal source As ISubtitlesGrid, ByVal theRow As Integer)

#End Region

 End Interface

End Namespace
