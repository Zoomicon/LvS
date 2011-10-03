'Description: RTFEditor class (RichTextBoxEx + RTFToolStrip)
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070415

Imports System.ComponentModel

Namespace LvS.objects.rtf

 Public Class RTFEditor

#Region "Properties"

  Public ReadOnly Property RTFTextBox() As RichTextBoxEx
   Get
    Return rtfText
   End Get
  End Property

  <DefaultValue(False)> _
  Public Property [ReadOnly]() As Boolean
   Get
    Return rtfText.ReadOnly
   End Get
   Set(ByVal value As Boolean)
    rtfText.ReadOnly = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Overloads Property Text() As String
   Get
    Return rtfText.Text
   End Get
   Set(ByVal value As String)
    rtfText.Text = value
   End Set
  End Property

  <DefaultValue("")> _
  Public Property Rtf() As String
   Get
    Return rtfText.Rtf
   End Get
   Set(ByVal value As String)
    rtfText.Rtf = value
   End Set
  End Property

  <DefaultValue(0)> _
  Public ReadOnly Property TextLength() As Integer
   Get
    Return rtfText.TextLength
   End Get
  End Property

  <DefaultValue(True)> _
  Public Property WordWrap() As Boolean
   Get
    Return rtfText.WordWrap
   End Get
   Set(ByVal value As Boolean)
    rtfText.WordWrap = value
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property EnableAutoDragDrop() As Boolean
   Get
    Return rtfText.EnableAutoDragDrop
   End Get
   Set(ByVal value As Boolean)
    rtfText.EnableAutoDragDrop = value
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property ShowSelectionMargin() As Boolean
   Get
    Return rtfText.ShowSelectionMargin
   End Get
   Set(ByVal value As Boolean)
    rtfText.ShowSelectionMargin = value
   End Set
  End Property

  <DefaultValue(False)> _
  Public Property Modified() As Boolean
   Get
    Return rtfText.Modified
   End Get
   Set(ByVal value As Boolean)
    rtfText.Modified = value
   End Set
  End Property

  Public Property SelectionStart() As Integer
   Get
    Return rtfText.SelectionStart
   End Get
   Set(ByVal value As Integer)
    rtfText.SelectionStart = value
   End Set
  End Property

  Public Property SelectionEnd() As Integer
   Get
    Return rtfText.SelectionEnd
   End Get
   Set(ByVal value As Integer)
    rtfText.SelectionEnd = value
   End Set
  End Property

  Public Property SelectionLength() As Integer
   Get
    Return rtfText.SelectionLength
   End Get
   Set(ByVal value As Integer)
    rtfText.SelectionLength = value
   End Set
  End Property

  Public Property SelectionProtected() As Boolean
   Get
    Return rtfText.SelectionProtected
   End Get
   Set(ByVal value As Boolean)
    rtfText.SelectionProtected = value
   End Set
  End Property

#End Region

#Region "Methods"

  Public Sub SelectAll()
   rtfText.SelectAll()
  End Sub

  Public Overloads Sub LoadFile(ByVal path As String)
   rtfText.LoadFile(path)
  End Sub

  Public Overloads Sub LoadFile(ByVal path As String, ByVal fileType As RichTextBoxStreamType)
   rtfText.LoadFile(path, fileType)
  End Sub

  Public Overloads Sub LoadFile(ByVal data As System.IO.Stream, ByVal fileType As RichTextBoxStreamType)
   rtfText.LoadFile(data, fileType)
  End Sub

  Public Overloads Sub SaveFile(ByVal path As String)
   rtfText.SaveFile(path)
  End Sub

  Public Overloads Sub SaveFile(ByVal path As String, ByVal fileType As RichTextBoxStreamType)
   rtfText.SaveFile(path, fileType)
  End Sub

#End Region

#Region "Events"

  Public Event ModifiedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'this isn't raised if the text is set programmatically
  Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
  Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) 'expose the KeyDown event of the RichTextBoxEx as our own's
  Public Event LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs)

  Private Sub rtfText_ModifiedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtfText.ModifiedChanged 'this isn't called if the text is set programmatically
   RaiseEvent ModifiedChanged(Me, e)
  End Sub

  Private Sub rtfText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtfText.TextChanged
   RaiseEvent TextChanged(Me, e)
  End Sub

  Private Sub rtfText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtfText.KeyDown
   RaiseEvent KeyDown(Me, e)
  End Sub

  Private Sub rtfText_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtfText.LinkClicked
   RaiseEvent LinkClicked(Me, e)
  End Sub

#End Region

 End Class

End Namespace
