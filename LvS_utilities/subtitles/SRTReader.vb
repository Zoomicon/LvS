'Description: SRTReader class
'Authors: George Birbilis (birbilis@kagi.com), Kostas Mitropoulos (kosmitr@eap.gr)
'Version: 20080421

Imports System.IO
Imports System.Text
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.SRTUtils

Namespace LvS.utilities.subtitles

 Public Class SRTReader
  Implements ISubtitlesReader

  Public Overloads Sub ReadSubtitles(ByVal subtitles As models.subtitles.ISubtitles, ByVal path As String, ByVal encoding As Encoding) Implements models.subtitles.ISubtitlesReader.ReadSubtitles
   'not clearing any existing subtitles, just appending to the end (the ISubtitles object can choose whether it will sort the subtitles by start time or not after the appending)
   Using reader As New StreamReader(path, encoding, True) '"Using" makes sure the resource is immediately deallocated at "End Using"
    ReadSubtitles(subtitles, reader)
   End Using
  End Sub

  Public Overloads Sub ReadSubtitles(ByVal subtitles As ISubtitles, ByVal reader As TextReader)
   Try
				Dim subline As String = ""
    Dim line As String = reader.ReadLine()
    While (line IsNot Nothing)
     If line <> "" Then
      subline = subline & "|" & line
     Else
      Dim subtitle As ISubtitle = subtitles.NewSubtitle
      ReadSubtitle(subtitle, subline)
      subtitles.Add(subtitle)
      subline = ""
     End If
     line = reader.ReadLine()
    End While
   Finally
    reader.Close()
   End Try
  End Sub

  Protected Sub ReadSubtitle(ByVal subtitle As ISubtitle, ByVal subline As String)
			SRTStringToSubtitle(subline, subtitle)
  End Sub

 End Class

End Namespace
