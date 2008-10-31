'Description: TextLinePair class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080413

Namespace LvS.objects.grid

	Public Class TextLinePair

#Region "Constants"

		Public Const MAX_CHARS As Integer = 39	'!!! make this a property and add appropriate constructor

#End Region

#Region "Properties"

		Public Property Value() As String
			Get
				Return TextLine1 & vbCrLf & TextLine2
			End Get
			Set(ByVal value As String)
				Dim values As String() = Split(value, vbCrLf)
				TextLine1 = values(0)
				If value.Length > 1 Then
					TextLine2 = values(1)
				Else
					TextLine2 = ""
				End If
			End Set
		End Property

		Public Property TextLine1() As String
			Get
				Return txtLine1.Text
			End Get
			Set(ByVal value As String)
				txtLine1.Text = value
			End Set
		End Property

		Public Property TextLine2() As String
			Get
				Return txtLine2.Text
			End Get
			Set(ByVal value As String)
				txtLine2.Text = value
			End Set
		End Property

#End Region

#Region "Events"

		Private Sub txtLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLine2.TextChanged, txtLine1.TextChanged
			Dim txt As TextBox = CType(sender, TextBox)
			Dim text As String = txt.Text
			ToolTips.SetToolTip(txt, text)

			If text.Length > MAX_CHARS Then
				txt.ForeColor = Color.Red
			Else
				txt.ForeColor = Color.Black
			End If

			'use RTF text box and underline the chars with >=MAX_CHARS location (char index base is 0)
		End Sub

		Private Sub txtLine1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLine1.KeyDown
			If e.KeyCode = Keys.Control Then
				SelectNextControl(txtLine2, True, True, False, True)	'doesn't work, neither txtLine2.Select()
				e.SuppressKeyPress = True
			End If
		End Sub

		Private Sub txtLine2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLine2.KeyDown
			If e.KeyCode = Keys.Control Then
				SelectNextControl(txtLine1, True, True, False, True)	'doesn't work, neither txtLine1.Select()
				e.SuppressKeyPress = True
			End If
		End Sub

#End Region

	End Class

End Namespace