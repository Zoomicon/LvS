'Description: SubtitlePair class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080414

Namespace LvS.objects.grid

 Public Class Comment

#Region "Properties"

  Public Property Value() As String
   Get
    Return Comment1 & vbCrLf & Comment2
   End Get
   Set(ByVal value As String)
    Dim values As String() = Split(value, vbCrLf)
    Comment1 = values(0)
    If value.Length > 1 Then
     Comment2 = values(1)
    Else
     Comment2 = ""
    End If
   End Set
  End Property

  Public Property Comment1() As String
   Get
    Return txtComment1.Text
   End Get
   Set(ByVal value As String)
    txtComment1.Text = value
   End Set
  End Property

  Public Property Comment2() As String
   Get
    Return txtComment2.Text
   End Get
   Set(ByVal value As String)
    txtComment2.Text = value
   End Set
  End Property

#End Region

#Region "Events"

  Private Sub txtSubtitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComment2.TextChanged, txtComment1.TextChanged
   Dim txt As TextBox = CType(sender, TextBox)
   ToolTips.SetToolTip(txt, txt.Text)
  End Sub

#End Region

 End Class

End Namespace
