'Description: RTFDocumentView class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070416

#Region "Imports"

Imports System.ComponentModel
Imports System.Text
Imports LvS.models.documents
Imports LvS.utilities.FileUtils
Imports LvS.utilities.documents
Imports LvS.utilities.TextUtils

#End Region

Namespace LvS.objects.documents

 Public Class RTFDocumentView
  Inherits BaseDocumentView
  Implements IDocument

#Region "Constants"

  Const PROTECTED_START As Char = "["c 'c suffix marks the literal as being a char - could have used CChar instead, but this may be more efficient
  Const PROTECTED_END As Char = "]"c
  Const PROTECTED_START_CODE As Keys = Keys.OemOpenBrackets
  Const PROTECTED_END_CODE As Keys = Keys.OemCloseBrackets

#End Region

#Region "Properties"

  <DefaultValue("")> _
  Public Overrides Property Source() As String Implements IDocument.Source
   Get
    Return fSource
   End Get
   Set(ByVal value As String)
    If CheckExtension(value, DocumentUtils.EXTENSION_RTF) IsNot Nothing Then
     rtfText.LoadFile(value, RichTextBoxStreamType.RichText) 'this sets Modified=false
     RaiseModifiedChanged()
    Else
     Dim streamType As RichTextBoxStreamType
     If IsUnicode(Encoding) Then streamType = RichTextBoxStreamType.UnicodePlainText Else streamType = RichTextBoxStreamType.PlainText
     rtfText.LoadFile(New IO.StreamReader(value, Encoding, True).BaseStream, streamType) 'this sets Modified=false
     RaiseModifiedChanged()
    End If
    MarkProtectedParts()
    fSource = value
   End Set
  End Property

  <DefaultValue(False)> _
  Public Overrides Property Modified() As Boolean Implements IDocument.Modified
   Get
    Return rtfText.Modified
   End Get
   Set(ByVal value As Boolean)
    If value <> Modified Then
     rtfText.Modified = value
     RaiseModifiedChanged()
    End If
   End Set
  End Property

#End Region

#Region "Methods"

  Public Overrides Sub OnAuthoringModeChanged()
   MyBase.OnAuthoringModeChanged()
   MarkProtectedParts() 'this will check if not at AuthoringMode state and protect document parts not editable by non-authors
  End Sub

  Public Overrides Sub Save() Implements models.documents.IDocument.Save
   If Modified Then 'avoid saving file again (and raising ModifiedChanged event) if not modified

    If CheckExtension(fSource, DocumentUtils.EXTENSION_RTF) IsNot Nothing Then
     rtfText.SaveFile(fSource, RichTextBoxStreamType.RichText) 'this won't affect the Modified flag
    Else
     Dim streamType As RichTextBoxStreamType
     If IsUnicode(Encoding) Then streamType = RichTextBoxStreamType.UnicodePlainText Else streamType = RichTextBoxStreamType.PlainText
     rtfText.SaveFile(fSource, streamType) 'this won't affect the Modified flag
    End If

    Modified = False 'the save command doesn't change the modified state, we must change it ourselves
   End If
  End Sub

  Public Overrides Sub Export(ByVal path As String) Implements models.documents.IDocument.Export
   If CheckExtension(path, DocumentUtils.EXTENSION_RTF) IsNot Nothing Then
    rtfText.SaveFile(path, RichTextBoxStreamType.RichText) 'this won't affect the Modified flag
   Else
    Dim streamType As RichTextBoxStreamType
    If IsUnicode(Encoding) Then streamType = RichTextBoxStreamType.UnicodePlainText Else streamType = RichTextBoxStreamType.PlainText
    rtfText.SaveFile(path, streamType) 'this won't affect the Modified flag
   End If
  End Sub

  Public Overrides Sub Close() Implements IDocument.Close
   rtfText.Text = ""
   RaiseModifiedChanged()
  End Sub

  Public Sub MarkProtectedParts()
   With rtfText
    If AuthoringMode Then
     .SelectAll()
     .SelectionProtected = False 'unprotect all text
    Else
     .SelectAll()
     .SelectionProtected = True 'protect all text
     Dim txt As String = .Text
     For i As Integer = 0 To txt.Length - 1
      Select Case txt.Chars(i)
       Case PROTECTED_START
        .SelectionStart = i + 1
       Case PROTECTED_END
        .SelectionLength = i - .SelectionStart
        .SelectionProtected = False 'unprotect the selected part
        .SelectionLength = 0 'undo selection 
      End Select
     Next i
    End If
    .SelectionLength = 0 'undo selection
   End With
  End Sub

#End Region

#Region "Events"

  Private Sub rtfText_ModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtfText.ModifiedChanged 'this isn't called if the text is set programmatically
   RaiseModifiedChanged()
  End Sub

  'SHOULD HANDLE THE CASE WHERE USER IN NON-AUTHORING MODE DELETES ALL TEXT INSIDE THE []. In that case should insert a space char automatically again, else they won't be able to write again inside those brackets
  Private Sub rtfText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtfText.KeyDown
   If (Not AuthoringMode) AndAlso (Not e.Shift) AndAlso (e.KeyCode = PROTECTED_START_CODE OrElse e.KeyCode = PROTECTED_END_CODE) Then e.SuppressKeyPress = True
  End Sub

  Private Sub rtfText_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtfText.LinkClicked
   Try
    DevAge.Shell.Utilities.OpenFile(e.LinkText)
   Catch
				MessageBox.Show(My.Resources.STR_OPEN_URL_FAILED & " " & e.LinkText, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try
  End Sub

#End Region

 End Class

End Namespace
