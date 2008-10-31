'Description: LanguageSelection class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080127

Imports System.Globalization
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Runtime.Serialization
Imports System.Threading

Public Class LanguageSelectionView

 Protected Const FILE_LANGUAGESELECTION As String = "LanguageSelection"

#Region "Enums"

	Public Enum LanguageSelectionEnum	'add more languages here
		langEnglish = 0
		langGreek = 1
		langSpanish = 2
		langHungarian = 3
		langPortuguese = 4
		langRomanian = 5
	End Enum

#End Region

#Region "Properties"

 Public ReadOnly Property SelectedLanguage() As String
  Get
   Return cbLanguages.SelectedItem.ToString 'use a hidden checkbox with EL, EN etc. strings, or use an enumeration if .NET has numbers for the languages
  End Get
 End Property

#End Region

#Region "Event handlers"

 Private Sub LanguageSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  cbLanguages.SelectedIndex = My.Settings.LanguageIndex
 End Sub

 Private Sub cbLanguages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLanguages.SelectedIndexChanged
  Dim selection As Integer = cbLanguages.SelectedIndex
  If My.Settings.LanguageIndex <> selection Then
   My.Settings.LanguageIndex = selection
   'My.Settings.Save() 'saving immediately in case the application fails to shutdown proprely and save settings (as told at project settings)
   RaiseEvent LanguageSelectionChanged(Me)
  End If
 End Sub

 Private Sub cbLanguages_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbLanguages.KeyDown
  If e.KeyCode = Keys.Space Then cbLanguages.DroppedDown = Not cbLanguages.DroppedDown
 End Sub

#End Region

#Region "Events"

 Public Event LanguageSelectionChanged(ByVal source As LanguageSelectionView)

#End Region

End Class
