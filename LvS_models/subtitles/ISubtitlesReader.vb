'Description: ISubtitlesReader interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.IO
Imports System.Text

Namespace LvS.models.subtitles

 Public Interface ISubtitlesReader

#Region "Methods"

		Sub ReadSubtitles(ByVal subtitles As ISubtitles, ByVal path As String, ByVal theEncoding As Encoding)	'not clearing any existing subtitles, just appending to the end (the ISubtitles object can choose whether it will sort the subtitles by start time or not after the appending)

#End Region

 End Interface

End Namespace
