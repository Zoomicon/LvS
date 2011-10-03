'Description: ISubtitlesWriter interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.Text

Namespace LvS.models.subtitles

 Public Interface ISubtitlesWriter

#Region "Methods"

		Sub WriteSubtitles(ByVal subtitles As ISubtitles, ByVal path As String, ByVal theEncoding As Encoding)

#End Region

 End Interface

End Namespace
