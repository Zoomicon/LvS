'Description: RTFToolStrip class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Namespace LvS.objects.rtf

 Public Class RTFToolStrip
  Inherits ToolStrip

#Region "Fields"

  Protected WithEvents rtfText As RichTextBoxEx

#End Region

#Region "Properties"

  Public Property RTFTextBox() As RichTextBoxEx
   Get
    Return rtfText
   End Get
   Set(ByVal Value As RichTextBoxEx)
    rtfText = Value
    Value.HideSelection = False 'must set this to false for font family and size comboboxes to work correctly
   End Set
  End Property

  Protected ReadOnly Property SelectionFont() As Font
   Get
    Dim result As Font
    If rtfText Is Nothing Then result = Nothing Else result = rtfText.SelectionFont
    If result Is Nothing Then result = New Font(comboFontFamily.Text, CInt(comboFontSize.Text))
    Return result
   End Get
  End Property

#End Region

#Region "Events"

  Private Sub btnCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCut.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.Cut()
  End Sub

  Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.Copy()
  End Sub

  Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.Paste()
  End Sub

  '-----

  Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.Undo()
  End Sub

  Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.Redo()
  End Sub

  '-----

  Private Sub btnBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBold.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.ChangeFontStyle(FontStyle.Bold, btnBold.Checked)
  End Sub

  Private Sub btnItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItalic.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.ChangeFontStyle(FontStyle.Italic, btnItalic.Checked)
  End Sub

  Private Sub btnUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnderline.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.ChangeFontStyle(FontStyle.Underline, btnUnderline.Checked)
  End Sub

  Private Sub btnStrikeout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStrikeout.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.ChangeFontStyle(FontStyle.Strikeout, btnStrikeout.Checked)
  End Sub

  Private Sub btnBullet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBullet.Click
   If rtfText Is Nothing Then Exit Sub
   rtfText.SelectionBullet = btnBullet.Checked
  End Sub

  '-----

  Private Sub btnLeftAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftAlign.Click
   If rtfText Is Nothing Then Exit Sub
   If btnLeftAlign.Checked Then
    rtfText.SelectionAlignment = HorizontalAlignment.Left
    btnCenterAlign.Checked = False
   Else
    btnCenterAlign.Checked = True 'this should apply center alignment
   End If
   btnRightAlign.Checked = False
  End Sub

  Private Sub btnCenterAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenterAlign.Click
   If rtfText Is Nothing Then Exit Sub
   If btnCenterAlign.Checked Then
    rtfText.SelectionAlignment = HorizontalAlignment.Center
    btnLeftAlign.Checked = False
   Else
    btnLeftAlign.Checked = True 'this should apply left alignment
   End If
   btnRightAlign.Checked = False
  End Sub

  Private Sub btnRightAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightAlign.Click
   If rtfText Is Nothing Then Exit Sub
   If btnRightAlign.Checked Then
    rtfText.SelectionAlignment = HorizontalAlignment.Right
    btnLeftAlign.Checked = False
   Else
    btnLeftAlign.Checked = True 'this should apply left alignment
   End If
   btnCenterAlign.Checked = False
  End Sub

  '-----

  Private Sub btnForegroundColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForegroundColor.Click
   If rtfText Is Nothing Then Exit Sub
   With ColorDialog
    .Color = rtfText.SelectionColor
    If .ShowDialog = DialogResult.OK Then
     rtfText.SelectionColor = .Color
    End If
   End With
  End Sub

  Private Sub btnBackgroundColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackgroundColor.Click
   If rtfText Is Nothing Then Exit Sub
   With ColorDialog
    .Color = rtfText.SelectionBackColor
    If .ShowDialog = DialogResult.OK Then
     rtfText.SelectionBackColor = .Color
    End If
   End With
  End Sub

  '-----

  Private Sub comboFontFamily_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles comboFontFamily.KeyDown
   If e.KeyCode = Keys.Enter Then comboFontFamily_SelectedIndexChanged(Me, e)
  End Sub

  Private Sub comboFontFamily_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFontFamily.SelectedIndexChanged
   If rtfText Is Nothing Then Exit Sub
   Try
    rtfText.SetSelectionFontFamily(comboFontFamily.Text)
   Catch
    comboFontFamily.Text = "Arial"
   End Try
  End Sub

  Private Sub comboFontSize_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles comboFontSize.KeyDown
   If e.KeyCode = Keys.Enter Then comboFontSize_SelectedIndexChanged(Me, e)
  End Sub

  Private Sub comboFontSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFontSize.SelectedIndexChanged
   If rtfText Is Nothing Then Exit Sub
   Dim newSize As String = comboFontSize.Text
   Dim newSizeF As Single
   If (Not Single.TryParse(newSize, newSizeF)) Or (newSizeF < 0 OrElse newSizeF > 100) Then 'must use Or before the "(" to force VB.net compiler to not use short-circuit boolean evaluation and evaluate the 2nd part too '???
    comboFontSize.Text = "8"
    newSizeF = 8
   End If
   rtfText.SetSelectionFontSize(newSizeF)
  End Sub

  Protected Sub rtfText_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtfText.SelectionChanged
   Dim fnt As Font = rtfText.GetFontDetails()

   'Set font style buttons to the styles applying to the entire selection
			btnBold.Checked = fnt.Bold
   btnItalic.Checked = fnt.Italic
   btnUnderline.Checked = fnt.Underline
   btnStrikeout.Checked = fnt.Strikeout

   btnBullet.Checked = rtfText.SelectionBullet
   btnLeftAlign.Checked = (rtfText.SelectionAlignment = HorizontalAlignment.Left)
   btnRightAlign.Checked = (rtfText.SelectionAlignment = HorizontalAlignment.Right)
   btnCenterAlign.Checked = (rtfText.SelectionAlignment = HorizontalAlignment.Center)

   Dim f As Font = SelectionFont
   comboFontFamily.Text = f.FontFamily.Name
   comboFontSize.Text = CStr(f.Size)
  End Sub

#End Region

 End Class

End Namespace
