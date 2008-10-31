'Description: SubtitleUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070326

Imports System.Text
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles
Imports LvS.utilities.FileUtils

Namespace LvS.utilities.subtitles

 Public NotInheritable Class SubtitleUtils

  Public Const EXTENSION_TTS As String = ".TTS"
  Public Const EXTENSION_SRT As String = ".SRT"
  Public Const EXTENSION_FAB As String = ".FAB"
  Public Const EXTENSION_ENCORE As String = ".ENC"

  Public Shared ReadOnly EXTENSIONS_TTS As String() = {EXTENSION_TTS}
  Public Shared ReadOnly EXTENSIONS_SRT As String() = {EXTENSION_SRT}
  Public Shared ReadOnly EXTENSIONS_FAB As String() = {EXTENSION_FAB}
  Public Shared ReadOnly EXTENSIONS_ENCORE As String() = {EXTENSION_ENCORE}

  Public Shared Function GetSubtitlesReader(ByVal path As String) As ISubtitlesReader
   If CheckExtension(path, EXTENSIONS_TTS) IsNot Nothing Then
    Return New TTSReader
   ElseIf CheckExtension(path, EXTENSIONS_SRT) IsNot Nothing Then
    Return New SRTReader
   End If
   Return Nothing
  End Function

  Public Shared Function GetSubtitlesWriter(ByVal path As String) As ISubtitlesWriter
   If CheckExtension(path, EXTENSIONS_TTS) IsNot Nothing Then
    Return New TTSUnicodeWriter
   ElseIf CheckExtension(path, EXTENSIONS_SRT) IsNot Nothing Then
    Return New SRTWriter
   ElseIf CheckExtension(path, EXTENSIONS_FAB) IsNot Nothing Then
    Return New FABWriter
   ElseIf CheckExtension(path, EXTENSIONS_ENCORE) IsNot Nothing Then
    Return New EncoreWriter
   End If
   Return Nothing
  End Function

  Public Shared Sub ReadSubtitles(ByVal subtitles As ISubtitles, ByVal path As String, ByVal encoding As Encoding)
   Dim reader As ISubtitlesReader = GetSubtitlesReader(path)
   If reader IsNot Nothing Then reader.ReadSubtitles(subtitles, path, encoding)
  End Sub

  Public Shared Sub WriteSubtitles(ByVal subtitles As ISubtitles, ByVal path As String, ByVal encoding As Encoding)
   Dim writer As ISubtitlesWriter = GetSubtitlesWriter(path)
   If writer IsNot Nothing Then writer.WriteSubtitles(subtitles, path, encoding)
  End Sub

 End Class

End Namespace
