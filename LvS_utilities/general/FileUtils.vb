'Description: FileUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080422

Imports System.Environment
Imports System.IO
Imports System.Text

Namespace LvS.utilities

 Public NotInheritable Class FileUtils

  'CSIDL values from http://msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/Shell/reference/enums/csidl.asp
  Public Const CSIDL_COMMON_VIDEO As Integer = &H37

  Public Shared SpecialFolder_MyVideos As SpecialFolder = CType(CSIDL_COMMON_VIDEO, SpecialFolder)

  Public Overloads Shared Function CheckExtension(ByVal filename As String, ByVal extension As String) As String
   If (filename IsNot Nothing) AndAlso filename.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase) Then Return extension Else Return Nothing
  End Function

  Public Overloads Shared Function CheckExtension(ByVal filename As String, ByVal extensions As String()) As String
   If filename IsNot Nothing Then
    For Each s As String In extensions
     If filename.EndsWith(s, StringComparison.InvariantCultureIgnoreCase) Then Return s
    Next s
   End If
   Return Nothing
  End Function

  'Note on "IO.Directory.GetFiles" (which is used below) from .NET documentation (MUST MAKE MY OWN VERSION TO NOT DO THIS!!!):
  '
  'When using the asterisk wildcard character in a searchPattern, such as "*.txt", the matching behavior when the extension 
  'is exactly three characters long is different than when the extension is more or less than three characters long. A 
  'searchPattern with a file extension of exactly three characters returns files having an extension of three or more 
  'characters, where the first three characters match the file extension specified in the searchPattern. A searchPattern 
  'with a file extension of one, two, or more than three characters returns only files having extensions of exactly that 
  'length that match the file extension specified in the searchPattern. When using the question mark wildcard character, 
  'this method returns only files that match the specified file extension. For example, given two files, "file1.txt" and 
  '"file1.txtother", in a directory, a search pattern of "file?.txt" returns just the first file, while a search pattern 
  'of "file*.txt" returns both files.

  Public Shared Function GetDirectoryFiles(ByVal folder As String, ByVal searchPattern As String, ByVal searchOption As SearchOption) As String() 'replacement for .NET 2.0's IO.Directory.GetFiles which doesn't support multiple filters (separated with path separators [semicolon on Windows])
			If Not IO.Directory.Exists(folder) Then Throw New DirectoryNotFoundException(My.Resources.STR_FOLDER_NOT_FOUND & ": " & folder)

   Dim searchPatternParts As New List(Of String)
   Dim searchPatternPart As String

   Dim strStart As Integer = 0
   Do
    Dim strEnd As Integer = searchPattern.IndexOf(IO.Path.PathSeparator, strStart)
    If strEnd < 0 Then strEnd = searchPattern.Length
    searchPatternPart = searchPattern.Substring(strStart, strEnd - strStart)
    If searchPatternPart = "" Then Exit Do
    searchPatternParts.Add(searchPatternPart)
    strStart = strEnd + 1
   Loop Until strStart >= searchPattern.Length

   Dim result As New List(Of String)

   Dim searchPatternPartsArray As String() = searchPatternParts.ToArray
   For Each searchPatternPart In searchPatternPartsArray
    Dim files As String() = IO.Directory.GetFiles(folder, searchPatternPart, searchOption)
    For Each f As String In files
     result.Add(f)
    Next f
   Next searchPatternPart

   Dim resultArray As String() = result.ToArray
   Array.Sort(resultArray)
   Return resultArray
  End Function

  Public Shared Sub DeleteFiles(ByVal files As String())
   For Each f As String In files
    IO.File.Delete(f)
   Next f
  End Sub

  Public Shared Sub CopyFiles(ByVal files As String(), ByVal destinationFolder As String) 'can throw IOException if user cancels
   For Each f As String In files
    My.Computer.FileSystem.CopyFile(f, IO.Path.Combine(destinationFolder, IO.Path.GetFileName(f)), FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.ThrowException)
   Next f
  End Sub

  Public Shared Function getNonExistentFilename(ByVal filename As String) As String 'maybe better search filename end for a number and increase that one
   Dim result As String = filename
   Dim i As Integer = 1
   While IO.File.Exists(result)
    result = filename & CStr(i)
    i += 1
   End While
   Return result
  End Function

  Public Shared Function getNonExistentFolderName(ByVal folder As String) As String 'maybe better search foldername end for a number and increase that one
   Dim result As String = folder
   Dim i As Integer = 1
   While IO.Directory.Exists(result)
    result = folder & CStr(i)
    i += 1
   End While
   Return result
  End Function

  Public Shared Function getFilter(ByVal extensionSets As String()()) As String
   Dim result As New StringBuilder()
   For Each extensions As String() In extensionSets
    For Each s As String In extensions
     result.Append("*" + s)
     result.Append(Path.PathSeparator)
    Next
   Next
   If result.Length > 0 Then Return result.ToString(0, result.Length - 1) Else Return "" 'skip ending path separator
  End Function

  Public Shared Sub CreateTextFile(ByVal theFilename As String, ByVal theText As String)
   Dim s As StreamWriter = File.CreateText(theFilename)
   s.Write(theText)
   s.Close()
  End Sub

  Public Shared Function RemoveTrailingDirectorySeparator(ByVal thePath As String) As String
   If thePath.EndsWith(IO.Path.DirectorySeparatorChar) Then
    Return thePath.Substring(0, thePath.Length - 1)
   Else
    Return thePath
   End If
  End Function

 End Class

End Namespace
