'Description: SaveFileDialogWithEncoding class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

'Converted sample at http://www.codeproject.com/csharp/GetSaveFileName.asp from C# to VB.net 
'Added "Encoding" property
'Fixed filter to use "Chr" instead of "ChrW" and convert "|" [Chr(124)] to Chr(0) instead of ChrW(92)
'Automatically adding all encodings (removed "EncodingTypes" enum) and preselecting the given Encoding
'Moved reusable code to BaseFileDialogWithEncoding and descending from it (also made OpenFileDialogWithEncoding)
'Added Localizable attribute and set to true

' Example of use:
'
'  Dim ofd As New SaveFileDialogWithEncoding
'  ofd.DefaultExt = "sql"
'  ofd.Encoding = Encoding.UTF8 'Encoding.getEncoding("utf-8")
'  ofd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*"
'  If (ofd.ShowDialog = DialogResult.OK) Then
'   MessageBox.Show(Me, String.Format("Name={0}, Encoding={1}", ofd.FileName, ofd.EncodingType))
'  End If

Imports System.Text
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports LvS.utilities.dialogs.FileDialogUtils

Namespace LvS.utilities.dialogs

 <Localizable(True)> _
 Public Class SaveFileDialogWithEncoding
  Inherits BaseFileDialogWithEncoding

#Region "Fields"

  Protected fOverwritePrompt As Boolean = True
		Protected fCreatePrompt As Boolean

#End Region

#Region "Properties"

  <DefaultValue(True)> _
  Property OverwritePrompt() As Boolean
   Get
    Return fOverwritePrompt
   End Get
   Set(ByVal value As Boolean)
    fOverwritePrompt = value
   End Set
  End Property

  <DefaultValue(False)> _
  Property CreatePrompt() As Boolean
   Get
    Return fCreatePrompt
   End Get
   Set(ByVal value As Boolean)
    fCreatePrompt = value
   End Set
  End Property

#End Region

#Region "Methods"

		Private Function HookProc(ByVal hdlg As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
			Select Case (msg)

				Case WfINITDIALOG
					'we need to centre the dialog
					Dim sr As Rectangle = fActiveScreen.Bounds
					Dim cr As RECT = New RECT
					Dim parent As IntPtr = GetParent(hdlg)
					GetWindowRect(parent, cr)
					Dim x As Integer = CInt((sr.Right + (sr.Left - (cr.Right - cr.Left))) / 2)
					Dim y As Integer = CInt((sr.Bottom + (sr.Top - (cr.Bottom - cr.Top))) / 2)
					SetWindowPos(parent, 0, x, y, (cr.Right - cr.Left), ((cr.Bottom - cr.Top) + 32), SWP_NOZORDER)
					'we need to find the label to position our new label under
					Dim fileTypeWindow As IntPtr = GetDlgItem(parent, 1089)
					Dim aboveRect As RECT = New RECT
					GetWindowRect(fileTypeWindow, aboveRect)
					'now convert the label's screen co-ordinates to client co-ordinates
					Dim point As FileDialogUtils.POINT = New FileDialogUtils.POINT
					point.X = aboveRect.Left
					point.Y = aboveRect.Bottom
					ScreenToClient(parent, point)
					'create the label
					Dim labelHandle As IntPtr = CreateWindowEx(0, "STATIC", "mylabel", (WS_VISIBLE _
																					Or (WS_CHILD Or WS_TABSTOP)), point.X, (point.Y + 12), 200, 100, parent, New IntPtr(0), New IntPtr(0), New IntPtr(0))
					SetWindowText(labelHandle, EncodingLabel)
					Dim fontHandle As IntPtr = SendMessage(fileTypeWindow, WfGETFONT, New IntPtr(0), New IntPtr(0))
					SendMessage(labelHandle, WfSETFONT, fontHandle, New IntPtr(0))
					'we now need to find the combo-box to position the new combo-box under
					Dim fileComboWindow As IntPtr = GetDlgItem(parent, 1136)
					aboveRect = New RECT
					GetWindowRect(fileComboWindow, aboveRect)
					point = New FileDialogUtils.POINT
					point.X = aboveRect.Left
					point.Y = aboveRect.Bottom
					ScreenToClient(parent, point)
					Dim rightPoint As FileDialogUtils.POINT = New FileDialogUtils.POINT
					rightPoint.X = aboveRect.Right
					rightPoint.Y = aboveRect.Top
					ScreenToClient(parent, rightPoint)
					'we create the new combobox
					Dim comboHandle As IntPtr = CreateWindowEx(0, "ComboBox", "mycombobox", (WS_VISIBLE _
																					Or (WS_CHILD _
																					Or (CBS_HASSTRINGS _
																					Or (CBS_DROPDOWNLIST Or WS_TABSTOP)))), point.X, (point.Y + 8), (rightPoint.X - point.X), 100, parent, New IntPtr(0), New IntPtr(0), New IntPtr(0))
					SendMessage(comboHandle, WfSETFONT, fontHandle, New IntPtr(0))
					'and add the encodings we want to offer 'Birb
					Dim i As Integer = 0
					For Each e As EncodingInfo In Encoding.GetEncodings
						SendMessage(comboHandle, CB_ADDSTRING, New IntPtr(0), e.DisplayName)
						If e.GetEncoding.Equals(Encoding) Then SendMessage(comboHandle, CB_SETCURSEL, CType(i, IntPtr), New IntPtr(0)) 'preselect the given encoding
						i += 1
					Next e
					'remember the handles of the controls we have created so we can destroy them after
					fLabelHandle = labelHandle
					fComboHandle = comboHandle

				Case WfDESTROY
					'destroy the handles we have created
					If (fComboHandle.ToInt64 <> 0) Then	'do not use "ToInt32" here
						DestroyWindow(fComboHandle)
					End If
					If (fLabelHandle.ToInt64 <> 0) Then	'do not use "ToInt32" here
						DestroyWindow(fLabelHandle)
					End If

				Case WfNOTIFY
					'we need to intercept the CDN_FILEOK message
					'which is sent when the user selects a filename
					Dim nmhdr As NMHDR = CType(Marshal.PtrToStructure(lParam, GetType(NMHDR)), NMHDR)
					If (nmhdr.Code = CDN_FILEOK) Then
						'a file has been selected
						'we need to get the encoding
						fEncoding = Encoding.GetEncodings(SendMessage(fComboHandle, CB_GETCURSEL, New IntPtr(0), New IntPtr(0)).ToInt32).GetEncoding	'Birb
					End If

			End Select

			Return New IntPtr(0)
		End Function

  Public Function ShowDialog() As DialogResult
   'set up the struct and populate it
   Dim ofn As OPENFILENAME = New OPENFILENAME
   ofn.lStructSize = Marshal.SizeOf(ofn)
   ofn.lpstrFilter = (fFilter.Replace("|", Microsoft.VisualBasic.Chr(0)) + Microsoft.VisualBasic.Chr(0))
   ofn.lpstrFile = (fFileName + New String(Microsoft.VisualBasic.Chr(32), 512))
   ofn.nMaxFile = ofn.lpstrFile.Length
   ofn.lpstrFileTitle = (System.IO.Path.GetFileName(fFileName) + New String(Microsoft.VisualBasic.Chr(32), 512))
   ofn.nMaxFileTitle = ofn.lpstrFileTitle.Length
   ofn.lpstrTitle = fTitle
   ofn.lpstrDefExt = fDefaultExt
   If Form.ActiveForm IsNot Nothing Then
    'position the dialog above the active window
    ofn.hwndOwner = Form.ActiveForm.Handle
    'we need to find out the active screen so the dialog box is
    'centred on the correct display
    fActiveScreen = Screen.FromControl(Form.ActiveForm)
   End If
   'set up some sensible flags
   ofn.Flags = OFN_EXPLORER _
               Or OFN_ENABLEHOOK
   If fCheckFileExists Then ofn.Flags = ofn.Flags Or OFN_FILEMUSTEXIST
   If fCheckPathExists Then ofn.Flags = ofn.Flags Or OFN_PATHMUSTEXIST
   If fOverwritePrompt Then ofn.Flags = ofn.Flags Or OFN_OVERWRITEPROMPT
   If fCreatePrompt Then ofn.Flags = ofn.Flags Or OFN_CREATEPROMPT Else ofn.Flags = ofn.Flags Or OFN_NOTESTFILECREATE
   'this is where the hook is set. Note that we can use a C# delegate in place of a C function pointer
   ofn.lpfnHook = New OFNHookProcDelegate(AddressOf HookProc)
   'if we're running on Windows 98/ME then the struct is smaller
   If (System.Environment.OSVersion.Platform <> PlatformID.Win32NT) Then
    ofn.lStructSize = (ofn.lStructSize - 12)
   End If
   'show the dialog
   If Not GetSaveFileName(ofn) Then
    Dim ret As Integer = CommDlgExtendedError()
    If (ret <> 0) Then
					Throw New ApplicationException(My.Resources.STR_FILE_SAVE_DIALOG_FAILED & " (" & ret.ToString & ")")	'Birb
    End If
    Return DialogResult.Cancel
   End If

   'Birb-start
   Dim oldFilename As String = fFileName
   fFileName = ofn.lpstrFile
   Dim cancelCheck As New CancelEventArgs()
   RaiseEvent FileOK(Me, cancelCheck)
   If cancelCheck.Cancel Then
    fFileName = oldFilename 'restore filename since dialog was canceled
    Return DialogResult.Cancel
   Else
    Return DialogResult.OK
   End If
   'Birb-end
  End Function

#End Region

#Region "Events"

  Public Event FileOK(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) 'Birb

#End Region

 End Class

End Namespace
