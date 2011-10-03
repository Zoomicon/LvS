'Description: MediaUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080328

Imports LvS.models.player
Imports LvS.objects.players
Imports LvS.utilities.FileUtils

Namespace LvS.utilities

 Public NotInheritable Class MediaUtils

#Region "File extensions"

  Public Const EXTENSION_WAV As String = ".WAV"
  Public Const EXTENSION_AU As String = ".AU"
  Public Const EXTENSION_MP3 As String = ".MP3"

  Public Const EXTENSION_AVI As String = ".AVI"

  Public Const EXTENSION_WMV As String = ".WMV"

  Public Const EXTENSION_MPEG As String = ".MPEG"
  Public Const EXTENSION_MPG As String = ".MPG"
  Public Const EXTENSION_MP4 As String = ".MP4"
  Public Const EXTENSION_VOB As String = ".VOB"

  Public Const EXTENSION_DIVX As String = ".DIVX"
  Public Const EXTENSION_DIV As String = ".DIV"
  Public Const EXTENSION_TIX As String = ".TIX"

  Public Const EXTENSION_MOV As String = ".MOV"
  Public Const EXTENSION_QT As String = ".QT"

  Public Shared ReadOnly EXTENSIONS_AUDIO As String() = {EXTENSION_WAV, EXTENSION_AU, EXTENSION_MP3}
  Public Shared ReadOnly EXTENSIONS_VIDEO As String() = {EXTENSION_AVI, EXTENSION_WMV, EXTENSION_MPEG, EXTENSION_MPG, EXTENSION_MP4, EXTENSION_VOB, EXTENSION_DIVX, EXTENSION_DIV, EXTENSION_TIX, EXTENSION_MOV, EXTENSION_QT}

  Public Shared ReadOnly EXTENSIONS_WMP As String() = {EXTENSION_WAV, EXTENSION_AU, EXTENSION_MP3, EXTENSION_AVI, EXTENSION_WMV, EXTENSION_MPEG, EXTENSION_MPG, EXTENSION_MP4, EXTENSION_VOB, EXTENSION_DIVX, EXTENSION_DIV, EXTENSION_TIX _
, EXTENSION_MOV, EXTENSION_QT, EXTENSION_WAV, EXTENSION_AU, EXTENSION_AVI, EXTENSION_WMV, EXTENSION_MPEG, EXTENSION_MPG, EXTENSION_MP4, EXTENSION_VOB, EXTENSION_DIVX, EXTENSION_DIV, EXTENSION_TIX _
, EXTENSION_MOV, EXTENSION_QT, EXTENSION_WAV, EXTENSION_AU, EXTENSION_AVI, EXTENSION_MPEG, EXTENSION_MPG, EXTENSION_MP4, EXTENSION_VOB _
} 'temporarily added all extensions to Media Player till plugin-style architecture is used and detection routines (assuming use of QuickTimeAlternative and RealAlternative directshow filters for now)
  'Public Shared ReadOnly EXTENSIONS_RealPlayer As String() = {EXTENSION_MOV, EXTENSION_QT, EXTENSION_WAV, EXTENSION_AU, EXTENSION_VOB, EXTENSION_AVI, EXTENSION_WMV, EXTENSION_MPEG, EXTENSION_MPG, EXTENSION_DIVX, EXTENSION_DIV, EXTENSION_TIX}
  'Public Shared ReadOnly EXTENSIONS_QuickTime As String() = {EXTENSION_MOV, EXTENSION_QT, EXTENSION_WAV, EXTENSION_AU, EXTENSION_VOB, EXTENSION_AVI, EXTENSION_MPEG, EXTENSION_MPG}

  Public Shared ReadOnly EXTENSIONS_MULTIMEDIA As String()() = {EXTENSIONS_AUDIO, EXTENSIONS_VIDEO}

#End Region

  Public Shared Function getVideoFilter() As String
   Return FileUtils.getFilter(New String()() {EXTENSIONS_VIDEO})
  End Function

  Public Shared Function getAudioFilter() As String
   Return FileUtils.getFilter(New String()() {EXTENSIONS_AUDIO})
  End Function

  Public Shared Function getMultimediaFilter() As String
   Return FileUtils.getFilter(EXTENSIONS_MULTIMEDIA)
  End Function

  Public Shared Function getPlayer(ByVal media As String) As IPlayer
   'player preference order (in case of a media file supported by multiple players) is from top to bottom, rearrange to change preferred player
   Dim result As IPlayer = Nothing

   Try
    If IsWmpInstalled() AndAlso CheckExtension(media, EXTENSIONS_WMP) IsNot Nothing Then
     result = New WMP
     result.Source = media 'try to load the media
     Return result
    End If
   Catch
    result = Nothing
   End Try

   'Try
   ' If IsRealPlayerInstalled() AndAlso CheckExtension(media, EXTENSIONS_RealPlayer) IsNot Nothing Then
   '  result = New RealPlayer
   '  result.Source = media 'try to load the media
   '  Return result
   ' End If
   'Catch
   ' result = Nothing
   'End Try

   'Try
   ' If IsQuickTimeInstalled() AndAlso CheckExtension(media, EXTENSIONS_QuickTime) IsNot Nothing Then
   '  result = New QuickTime
   '  result.Source = media 'try to load the media
   '  Return result
   ' End If
   'Catch
   ' result = Nothing
   'End Try

   Return result
  End Function

  Public Shared Function IsWmpInstalled() As Boolean
   Return True '!!! dummy
  End Function

  Public Shared Function IsRealPlayerInstalled() As Boolean
   Return True '!!! dummy
  End Function

  Public Shared Function IsQuickTimeInstalled() As Boolean
   Return True '!!! dummy
  End Function

 End Class

End Namespace
