'Description: INotes interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070410

Imports LvS.models.subtitles

Namespace LvS.models.notes

 Public Interface INotes
  Inherits IModifiable, IPrintable

#Region "Enums"

  Enum Columns
   colNone = -1
   colIndex = 0
   colComment = 1
  End Enum

#End Region

#Region "Properties"

  Property AuthoringMode() As Boolean
  Property Source() As String
  Property Text() As String
  Property TeacherNotes() As Boolean
  Property FocusedRow() As Integer

#End Region

#Region "Methods"

  Sub Save()
  Sub SetSubtitles(ByVal theSubtitles As ISubtitles)

  Sub AddComment(ByVal theSubtitlesRow As Integer)
  Sub ChangeComment(ByVal theSubtitlesRow As Integer)
  Sub RemoveComment(ByVal theSubtitlesRow As Integer)

#End Region

#Region "Events"

  Event CommentChanged(ByVal source As INotes, ByVal theRow As Integer)
  'Event CommentRemoved(ByVal source As INotes, ByVal theRow As Integer)
  Event FocusedRowChanged(ByVal source As INotes, ByVal theRow As Integer)

#End Region

 End Interface

End Namespace
