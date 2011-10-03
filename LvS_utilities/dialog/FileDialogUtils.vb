'Description: FileDialogUtils class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports System.Runtime.InteropServices

Namespace LvS.utilities.dialogs

 Public Class FileDialogUtils

#Region "Constants"

  Public Const OFN_READONLY As Integer = 1 'check the readonly checkbox
  Public Const OFN_OVERWRITEPROMPT As Integer = 2
  Public Const OFN_HIDEREADONLY As Integer = 4 'hide the readonly checkbox
  Public Const OFN_ENABLEHOOK As Integer = 32
  Public Const OFN_EXPLORER As Integer = 524288
  Public Const OFN_FILEMUSTEXIST As Integer = 4096
  Public Const OFN_CREATEPROMPT As Integer = 8192
  Public Const OFN_NOTESTFILECREATE As Integer = 65536
  Public Const OFN_PATHMUSTEXIST As Integer = 2048

  Public Const SWP_NOSIZE As Integer = 1
  Public Const SWP_NOMOVE As Integer = 2
  Public Const SWP_NOZORDER As Integer = 4

  Public Const WfINITDIALOG As Integer = 272
  Public Const WfDESTROY As Integer = 2
		Public Const WfSETFONT As Integer = 48
  Public Const WfGETFONT As Integer = 49
  Public Const WfNOTIFY As Integer = 78

  Public Const CBS_DROPDOWNLIST As Integer = 3
  Public Const CBS_HASSTRINGS As Integer = 512

  Public Const CB_ADDSTRING As Integer = 323
  Public Const CB_SETCURSEL As Integer = 334
  Public Const CB_GETCURSEL As Integer = 327

  Public Const WS_VISIBLE As UInteger = 268435456
  Public Const WS_CHILD As UInteger = 1073741824
  Public Const WS_TABSTOP As UInteger = 65536

  Public Const CDN_FILEOK As Integer = -606

#End Region

#Region "Delegates"

		Public Delegate Function OFNHookProcDelegate(ByVal hDlg As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

#End Region

#Region "Imports"

		<DllImport("Comdlg32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
		Public Shared Function GetOpenFileName(ByRef lpofn As OPENFILENAME) As Boolean
		End Function

		<DllImport("Comdlg32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
		Public Shared Function GetSaveFileName(ByRef lpofn As OPENFILENAME) As Boolean
		End Function

		<DllImport("Comdlg32.dll")> _
		Public Shared Function CommDlgExtendedError() As Integer
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
		Public Shared Function SetWindowText(ByVal hWnd As IntPtr, ByVal lpString As String) As Boolean
		End Function

		<DllImport("user32.dll")> _
		Public Overloads Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
		Public Overloads Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function DestroyWindow(ByVal hWnd As IntPtr) As Boolean
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
		Public Shared Function GetDlgItem(ByVal hDlg As IntPtr, ByVal nIDDlgItem As Integer) As IntPtr
		End Function

		<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
		Public Shared Function CreateWindowEx(ByVal dwExStyle As Integer, ByVal lpClassName As String, ByVal lpWindowName As String, ByVal dwStyle As UInteger, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hWndParent As IntPtr, ByVal hMenu As IntPtr, ByVal hInstance As IntPtr, ByVal lpParam As IntPtr) As IntPtr
		End Function

		<DllImport("user32.dll")> _
		Public Shared Function ScreenToClient(ByVal hWnd As IntPtr, ByRef lpPoint As POINT) As Boolean
		End Function

#End Region

#Region "Structures"

		<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
		Public Structure OPENFILENAME
			Public lStructSize As Integer
			Public hwndOwner As IntPtr
			Public hInstance As IntPtr
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrFilter As String
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrCustomFilter As String
			Public nMaxCustFilter As Integer
			Public nFilterIndex As Integer
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrFile As String
			Public nMaxFile As Integer
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrFileTitle As String
			Public nMaxFileTitle As Integer
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrInitialDir As String
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrTitle As String
			Public Flags As Integer
			Public nFileOffset As Short
			Public nFileExtension As Short
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpstrDefExt As String
			Public lCustData As Integer
			Public lpfnHook As OFNHookProcDelegate
			<MarshalAs(UnmanagedType.LPTStr)> _
		Public lpTemplateName As String
			'only if on nt 5.0 or higher
			Public pvReserved As Integer
			Public dwReserved As Integer
			Public FlagsEx As Integer
		End Structure

		Public Structure RECT
			Public Left As Integer
			Public Top As Integer
			Public Right As Integer
			Public Bottom As Integer
		End Structure

		Public Structure POINT
			Public X As Integer
			Public Y As Integer
		End Structure

		Public Structure NMHDR
			Public HwndFrom As Integer
			Public IdFrom As Integer
			Public Code As Integer
		End Structure

#End Region

 End Class

End Namespace
