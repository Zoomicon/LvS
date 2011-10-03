'Description: TTSReader class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.IO
Imports System.Text
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.tts.TTSUtils

Namespace LvS.utilities.subtitles.tts

	Public Class TTSReader
		Implements ISubtitlesReader

		Public Overloads Sub ReadSubtitles(ByVal subtitles As models.subtitles.ISubtitles, ByVal path As String, ByVal theEncoding As Encoding) Implements models.subtitles.ISubtitlesReader.ReadSubtitles
			'not clearing any existing subtitles, just appending to the end (the ISubtitles object can choose whether it will sort the subtitles by start time or not after the appending)
			Using reader As New StreamReader(path, theEncoding, True)	'"Using" makes sure the resource is immediately deallocated at "End Using"
				ReadSubtitles(subtitles, reader)
			End Using
		End Sub

		Public Overloads Sub ReadSubtitles(ByVal subtitles As ISubtitles, ByVal reader As TextReader)
			Try
				Dim line As String = reader.ReadLine()
				While (line IsNot Nothing) AndAlso (line <> "")
					Dim subtitle As ISubtitle = subtitles.NewSubtitle
					subtitles.Add(subtitle)
					ReadSubtitle(subtitle, line)
					line = reader.ReadLine()
				End While
			Finally
				reader.Close()
			End Try
		End Sub

		Protected Shared Sub ReadSubtitle(ByVal subtitle As ISubtitle, ByVal line As String)
			TTSStringToSubtitle(line, subtitle)
		End Sub

	End Class

End Namespace
