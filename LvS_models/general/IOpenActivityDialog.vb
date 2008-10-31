'Description: IOpenActivityDialog interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070413

Imports System.Text
Imports LvS.models.player
Imports LvS.models.subtitles
Imports LvS.models.documents
Imports LvS.models.notes

Namespace LvS.models

 Public Interface IOpenActivityDialog

#Region "Enums"

  Enum FolderSelectionModes
   modeActivityFolder = 0
   modeNonActivityFolder = 1
  End Enum

#End Region

#Region "Properties"

  Property Text() As String
  Property Path() As String
  ReadOnly Property PathIsActivity() As Boolean
  ReadOnly Property LegalPath() As Boolean
  Property FolderSelectionMode() As IOpenActivityDialog.FolderSelectionModes

#End Region

 End Interface

End Namespace
