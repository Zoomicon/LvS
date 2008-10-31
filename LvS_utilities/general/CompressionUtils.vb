'Description: CompressionUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070220

Imports CabLib

Namespace LvS.utilities

 Public NotInheritable Class CompressionUtils

  Public Shared Sub CompressCAB(ByVal sourcePath As String, ByVal targetCAB As String, Optional ByVal filter As String = "*.*", Optional ByVal splitSize As Integer = 0, Optional ByVal encryptionKey As String = "")
   Dim c As New Compress
   If encryptionKey <> "" Then c.SetEncryptionKey(encryptionKey)
   c.CompressFolder(sourcePath, targetCAB, filter, splitSize)
  End Sub

  Public Shared Sub DecompressCAB(ByVal sourceCAB As String, ByVal targetFolder As String)
   Dim e As New Extract
   e.ExtractFile(sourceCAB, targetFolder)
  End Sub

 End Class

End Namespace
