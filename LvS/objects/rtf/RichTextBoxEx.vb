'Description: RichTextBoxEx class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

'Printing support adapted from Microsoft VB.net sample at http://support.microsoft.com/kb/811401/EN-US/
'Selection styling, font family and size change etc. adapted from C# sample at http://www.codeproject.com/cs/miscctrl/richtextboxextended.asp

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Namespace LvS.objects.rtf

 Public Class RichTextBoxEx
  Inherits RichTextBox

#Region "Properties"

  Public Property SelectionEnd() As Integer
   Get
    If SelectionLength > 0 Then
     Return SelectionStart + SelectionLength - 1
    Else
     Return -1
    End If
   End Get
   Set(ByVal value As Integer)
    If value >= SelectionStart Then
     SelectionLength = value - SelectionStart + 1
    Else
     SelectionLength = 0
    End If
   End Set
  End Property

#End Region

#Region "Printing"

  ' Convert the unit that is used by the .NET framework (1/100 inch) 
  ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
  Private Const AnInch As Double = 14.4

  <StructLayout(LayoutKind.Sequential)> _
   Private Structure RECT
   Public Left As Integer
   Public Top As Integer
   Public Right As Integer
   Public Bottom As Integer
  End Structure

  <StructLayout(LayoutKind.Sequential)> _
  Private Structure CHARRANGE
   Public cpMin As Integer          ' First character of range (0 for start of doc)
   Public cpMax As Integer          ' Last character of range (-1 for end of doc)
  End Structure

  <StructLayout(LayoutKind.Sequential)> _
  Private Structure FORMATRANGE
   Public hdc As IntPtr             ' Actual DC to draw on
   Public hdcTarget As IntPtr       ' Target DC for determining text formatting
   Public rc As RECT                ' Region of the DC to draw to (in twips)
   Public rcPage As RECT            ' Region of the whole DC (page size) (in twips)
   Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
  End Structure

  Private Const WM_USER As Integer = &H400
  Private Const EM_FORMATRANGE As Integer = WM_USER + 57

  Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

  ' Render the contents of the RichTextBox for printing
  '	Return the last character printed + 1 (printing start from this point for next page)
  Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

   ' Mark starting and ending character 
   Dim cRange As CHARRANGE
   cRange.cpMin = charFrom
   cRange.cpMax = charTo

   ' Calculate the area to render and print
   Dim rectToPrint As RECT
   rectToPrint.Top = CInt(e.MarginBounds.Top * AnInch)
   rectToPrint.Bottom = CInt(e.MarginBounds.Bottom * AnInch)
   rectToPrint.Left = CInt(e.MarginBounds.Left * AnInch)
   rectToPrint.Right = CInt(e.MarginBounds.Right * AnInch)

   ' Calculate the size of the page
   Dim rectPage As RECT
   rectPage.Top = CInt(e.PageBounds.Top * AnInch)
   rectPage.Bottom = CInt(e.PageBounds.Bottom * AnInch)
   rectPage.Left = CInt(e.PageBounds.Left * AnInch)
   rectPage.Right = CInt(e.PageBounds.Right * AnInch)

   Dim hdc As IntPtr = e.Graphics.GetHdc()

   Dim fmtRange As FORMATRANGE
   fmtRange.chrg = cRange                 ' Indicate character from to character to 
   fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
   fmtRange.hdcTarget = hdc               ' Point at printer hDC
   fmtRange.rc = rectToPrint              ' Indicate the area on page to print
   fmtRange.rcPage = rectPage             ' Indicate whole size of page

   Dim res As IntPtr = IntPtr.Zero

   Dim wparam As IntPtr = IntPtr.Zero
   wparam = New IntPtr(1)

   ' Move the pointer to the FORMATRANGE structure in memory
   Dim lparam As IntPtr = IntPtr.Zero
   lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
   Marshal.StructureToPtr(fmtRange, lparam, False)

   ' Send the rendered data for printing 
   res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

   ' Free the block of memory allocated
   Marshal.FreeCoTaskMem(lparam)

   ' Release the device context handle obtained by a previous call
   e.Graphics.ReleaseHdc(hdc)

   ' Return last + 1 character printer
   Return res.ToInt32()
  End Function

#End Region

#Region "Change font family"

  Public Sub SetSelectionFontFamily(ByVal fontFamily As String)

   'This method should handle cases that occur when multiple fonts/styles are selected
   ' Parameters:-
   ' fontFamily - the font to be applied, eg "Courier New"

   ' Reason: The reason this method and the others exist is because
   ' setting these items via the selection font doen't work because
   ' a null selection font is returned for a selection with more 
   ' than one font!

   Dim rtb1start As Integer = SelectionStart
   Dim len As Integer = SelectionLength
   Dim rtbTempStart As Integer = 0

   ' If len <= 1 and there is a selection font, amend and return
   If (len <= 1 AndAlso SelectionFont IsNot Nothing) Then
    SelectionFont = New Font(fontFamily, SelectionFont.Size, SelectionFont.Style)
    Exit Sub
   End If

   ' Step through the selected text one char at a time
   Dim rtbTemp As New RichTextBox()
   rtbTemp.Rtf = SelectedRtf
   For i As Integer = 0 To len - 1
    rtbTemp.Select(rtbTempStart + i, 1)
    rtbTemp.SelectionFont = New Font(fontFamily, rtbTemp.SelectionFont.Size, rtbTemp.SelectionFont.Style)
   Next i

   ' Replace & reselect
   rtbTemp.Select(rtbTempStart, len)
   SelectedRtf = rtbTemp.SelectedRtf
			Me.Select(rtb1start, len)
		End Sub

#End Region

#Region "Change font size"

		Public Sub SetSelectionFontSize(ByVal fontSize As Single)

			'This method should handle cases that occur when multiple fonts/styles are selected
			' Parameters:-
			' fontSize - the fontsize to be applied, eg 33.5

			If (fontSize <= 0.0) Then Throw New System.InvalidProgramException("Invalid font size parameter to ChangeFontSize")

			Dim rtb1start As Integer = SelectionStart
			Dim len As Integer = SelectionLength
			Dim rtbTempStart As Integer = 0

			' If len <= 1 and there is a selection font, amend and return
			If (len <= 1 AndAlso SelectionFont IsNot Nothing) Then
				SelectionFont = New Font(SelectionFont.FontFamily, fontSize, SelectionFont.Style)
				Exit Sub
			End If

			' Step through the selected text one char at a time
			Dim rtbTemp As New RichTextBox()
			rtbTemp.Rtf = SelectedRtf
			For i As Integer = 0 To len - 1
				rtbTemp.Select(rtbTempStart + i, 1)
				rtbTemp.SelectionFont = New Font(rtbTemp.SelectionFont.FontFamily, fontSize, rtbTemp.SelectionFont.Style)
			Next i

			' Replace & reselect
			rtbTemp.Select(rtbTempStart, len)
			SelectedRtf = rtbTemp.SelectedRtf
			Me.Select(rtb1start, len)
		End Sub

#End Region

#Region "Change font style"

		Public Sub ChangeFontStyle(ByVal style As FontStyle, ByVal add As Boolean)
			'This method should handle cases that occur when multiple fonts/styles are selected
			' Parameters:-
			'    style - eg FontStyle.Bold
			'    add - IF true then add else remove
			' throw error if style isn't: bold, italic, strikeout or underline
			If ((style <> FontStyle.Bold) _
															AndAlso ((style <> FontStyle.Italic) _
															AndAlso ((style <> FontStyle.Strikeout) _
															AndAlso (style <> FontStyle.Underline)))) Then
				Throw New System.InvalidProgramException(My.Resources.STR_INVALID_CHANGEFONTSTYLE_PARAM)
			End If
			Dim rtb1start As Integer = SelectionStart
			Dim len As Integer = SelectionLength
			Dim rtbTempStart As Integer = 0
			'if len <= 1 and there is a selection font then just handle and return
			If ((len <= 1) _
															AndAlso (Not (SelectionFont) Is Nothing)) Then
				'add or remove style 
				If add Then
					SelectionFont = New Font(SelectionFont, (SelectionFont.Style Or style))
				Else
					SelectionFont = New Font(SelectionFont, SelectionFont.Style And Not style)
				End If
				Return
			End If
			' Step through the selected text one char at a time    
			Dim rtbTemp As New RichTextBox
			rtbTemp.Rtf = SelectedRtf
			For i As Integer = 0 To len - 1
				rtbTemp.Select((rtbTempStart + i), 1)
				'add or remove style 
				If add Then
					rtbTemp.SelectionFont = New Font(rtbTemp.SelectionFont, (rtbTemp.SelectionFont.Style Or style))
				Else
					rtbTemp.SelectionFont = New Font(rtbTemp.SelectionFont, rtbTemp.SelectionFont.Style And Not style)
				End If
			Next i

			' Replace & reselect
			rtbTemp.Select(rtbTempStart, len)
			SelectedRtf = rtbTemp.SelectedRtf
			[Select](rtb1start, len)
		End Sub

#End Region

#Region "Get font details"

		Public Function GetFontDetails() As Font
			'This method should handle cases that occur when multiple fonts/styles are selected
			Dim len As Integer = SelectionLength
			Dim rtbTempStart As Integer = 0
			If (len <= 1) _
						OrElse (len > 500) Then	'Birb: added for safety cause it takes too long if users does "Select all" at a large document
				' Return the selection or default font
				If (Not (SelectionFont) Is Nothing) Then
					Return SelectionFont
				Else
					Return Font
				End If
			End If
			' Step through the selected text one char at a time    
			' after setting defaults from first char
			Dim rtbTemp As New RichTextBox
			rtbTemp.Rtf = SelectedRtf
			'Turn everything on so we can turn it off one by one
			Dim replystyle As FontStyle = (FontStyle.Bold _
															Or (FontStyle.Italic _
															Or (FontStyle.Strikeout Or FontStyle.Underline)))
			' Set reply font, size and style to that of first char in selection.
			rtbTemp.Select(rtbTempStart, 1)
			Dim replyfont As String = rtbTemp.SelectionFont.Name
			Dim replyfontsize As Single = rtbTemp.SelectionFont.Size
			replystyle = (replystyle And rtbTemp.SelectionFont.Style)
			' Search the rest of the selection
			For i As Integer = 1 To len - 1
				rtbTemp.Select((rtbTempStart + i), 1)
				' Check reply for different style
				replystyle = (replystyle And rtbTemp.SelectionFont.Style)
				' Check font
				If (replyfont <> rtbTemp.SelectionFont.FontFamily.Name) Then
					replyfont = ""
				End If
				' Check font size
				If (replyfontsize <> rtbTemp.SelectionFont.Size) Then
					replyfontsize = CType(0, Single)
				End If

			Next i

			' Now set font and size if more than one font or font size was selected
			If (replyfont = "") Then
				replyfont = rtbTemp.Font.FontFamily.Name
			End If
			If (replyfontsize = 0) Then
				replyfontsize = rtbTemp.Font.Size
			End If
			' generate reply font
			Dim reply As Font = New Font(replyfont, replyfontsize, replystyle)
			Return reply
		End Function

#End Region

	End Class

End Namespace
