'Description: EncoreWriter class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.IO
Imports LvS.models.subtitles
Imports LvS.utilities.subtitles.encore.EncoreUtils

Namespace LvS.utilities.subtitles.encore

	Public Class EncoreWriter
		Inherits BaseSubtitleWriter

#Region "Methods"

		Protected Overrides Sub WriteSubtitle(ByVal subtitle As models.subtitles.ISubtitle, ByVal writer As System.IO.TextWriter)
			With subtitle
				writer.WriteLine(SecondsToEncoreTime(.StartTime) + " " + SecondsToEncoreTime(.EndTime) + " " + .Subtitle1)
				If (.Subtitle2 <> "") Then writer.WriteLine(.Subtitle2) 'write 2nd subtitle line only if non-empty
			End With
		End Sub

#End Region

	End Class

End Namespace
