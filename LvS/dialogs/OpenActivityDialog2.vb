'Description: OpenActivityDialog2 class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20120119

Imports System.IO
Imports System.Windows.Forms
Imports LvS.models
Imports LvS.models.IOpenActivityDialog.FolderSelectionModes

Namespace LvS.dialogs

	Public Class OpenActivityDialog2
		Inherits FolderBrowser.ExtendedFolderBrowser
		Implements IOpenActivityDialog

#Region "Fields"

		Protected fFolderSelectionMode As IOpenActivityDialog.FolderSelectionModes = modeActivityFolder

#End Region

#Region "Properties"

		Public Property Text() As String Implements IOpenActivityDialog.Text
			Get
				Return MyBase.Description
			End Get
			Set(ByVal value As String)
				MyBase.Description = value
			End Set
		End Property

		Public Property Path() As String Implements IOpenActivityDialog.Path
			Get
				Return SelectedPath
			End Get
			Set(ByVal value As String)
				Try
					'SelectedPath=value 'this is READONLY!!!
					CheckForActivityPath()
					'txtPath.Text = Path
				Catch
					'ignore exceptions
				End Try
			End Set
		End Property

		Public ReadOnly Property PathIsActivity() As Boolean Implements IOpenActivityDialog.PathIsActivity
			Get
				Dim p As String = Path
				If p Is Nothing Then Return False Else Return File.Exists(IO.Path.Combine(p, My.Settings.ActivityMarker))
			End Get
		End Property

		Public Property FolderSelectionMode() As IOpenActivityDialog.FolderSelectionModes Implements IOpenActivityDialog.FolderSelectionMode
			Get
				Return fFolderSelectionMode
			End Get
			Set(ByVal value As IOpenActivityDialog.FolderSelectionModes)
				fFolderSelectionMode = value
				'EnableMakeNewFolder(fFolderSelectionMode = modeNonActivityFolder) 'doesn't work (stack overflow)
				CheckForActivityPath()
			End Set
		End Property

		Public ReadOnly Property LegalPath() As Boolean Implements IOpenActivityDialog.LegalPath
			Get
				If (Path Is Nothing) OrElse (Path = "") Then Return False
				Return PathIsActivity Xor (FolderSelectionMode = modeNonActivityFolder)
			End Get
		End Property

#End Region

#Region "Methods"

		Private Sub CheckForActivityPath()
      'TODO 'EnableOK(LegalPath) 'doesn't work (stack overflow)
		End Sub

#End Region

#Region "Event handlers"

		Private Sub OpenActivityDialog2_SelectedFolderChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedFolderChanged
			CheckForActivityPath()
			'MyBase.Description = Path 'this is the dialog's title, don't change it (maybe set a tooltip or something?)
		End Sub

#End Region

	End Class

End Namespace
