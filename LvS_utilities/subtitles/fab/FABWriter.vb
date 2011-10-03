'Description: FABWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.IO
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.fab.FABUtils

Namespace LvS.utilities.subtitles.fab

	Public Class FABWriter
		Inherits BaseSubtitleWriter

#Region "Methods"

		Protected Overrides Sub WriteSubtitle(ByVal subtitle As models.subtitles.ISubtitle, ByVal writer As System.IO.TextWriter)
			With subtitle
				writer.WriteLine(SecondsToFABtime(.StartTime) + "  " + SecondsToFABtime(.EndTime))	'separator is double space
				writer.WriteLine(.Subtitle1)
				If (.Subtitle2 <> "") Then writer.WriteLine(.Subtitle2) 'write 2nd subtitle line only if non-empty
				writer.WriteLine()	'FAB format has an empty line AFTER each subtitle, resuling to the file ending up at two empty lines (maybe done so that more subtitles can be easily appended later on to the file)
			End With
		End Sub

#End Region

	End Class

End Namespace
