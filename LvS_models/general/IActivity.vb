'Description: IActivity interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070421

Imports System.Text
Imports LvS.models.player
Imports LvS.models.subtitles
Imports LvS.models.documents
Imports LvS.models.notes

Namespace LvS.models

 Public Interface IActivity
  Inherits IModifiable

#Region "Properties"


  ReadOnly Property Player() As IPlayer
  ReadOnly Property Subtitles() As ISubtitlesGrid
  ReadOnly Property Documents() As IDocuments
  ReadOnly Property TeacherNotes() As INotes
  ReadOnly Property StudentNotes() As INotes

  Property AuthoringMode() As Boolean
  ReadOnly Property Path() As String

#End Region

#Region "Methods"

  Function Close() As Boolean
  Sub LoadDocuments()
  Sub CloseDocuments()
  Sub TogglePlayPause()
  Sub SetSubtitleStart()
  Sub SetSubtitleEnd()
  Sub AddSubtitle()
  Sub RemoveSubtitle()

#Region "Import"

  Sub ImportVideo(ByVal thePath As String)
  Sub ImportAudio(ByVal thePath As String)
  Sub ImportSubtitles(ByVal thePath As String, ByVal encoding As Encoding)
  Sub ImportDocument(ByVal thePath As String, ByVal encoding As Encoding)

#End Region

#Region "Export"

  Function ExportPackedActivity(ByVal thePath As String, ByVal packMultimedia As Boolean) As Boolean
  'Function ExportVideo(ByVal thePath As String) As Boolean
  'Function ExportAudio(ByVal thePath As String) As Boolean
  Function ExportSubtitles(ByVal thePath As String, ByVal encoding As Encoding) As Boolean
  Function ExportDocument(ByVal thePath As String) As Boolean 'add encoding param???

#End Region

#Region "Load"

  Sub LoadActivity(ByVal thePath As String)
  Sub LoadVideo(ByVal thePath As String)
  Sub LoadAudio(ByVal thePath As String)
  Sub LoadSubtitles(ByVal thePath As String, ByVal encoding As Encoding)
  Sub LoadDocument(ByVal thePath As String, ByVal theTitle As String, ByVal encoding As Encoding)

#End Region

#Region "Save"

  Sub Save()
  Sub SaveSubtitles()

#End Region

#End Region

 End Interface

End Namespace
