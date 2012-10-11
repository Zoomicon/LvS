'Project: LvS (http://LvS.codeplex.com)
'Description: MainForm class
'Authors: George Birbilis (http://zoomicon.com)
'Version: 20121011

#Region "imports"

Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Globalization

Imports LvS.models.IOpenActivityDialog.FolderSelectionModes

Imports LvS.utilities
Imports LvS.utilities.FileUtils
Imports LvS.utilities.TextUtils

Imports LvS.dialogs

Imports LvS.screens.LanguageSelectionView

#End Region

Namespace LvS.screens

  Public Class MainForm

#Region "Constants"

    Public Const FILTER_PACKMULTIMEDIA As Integer = 2 'filter index is 1-based
    Public Const PARAM_HELP As String = "-help"

#End Region

#Region "Fields"

    Protected WithEvents Activity As ActivityView
    Protected dlgFolderSelection As New OpenActivityDialog2()
    Protected InvalidPathChars As Char() = {"/"c, "\"c, """"c, "<"c, ">"c, "|"c}

#End Region

#Region "Properties"

    Public Shared ReadOnly Property HelpFolder() As String
      Get
        Return IO.Path.Combine(Application.StartupPath, "help")
      End Get
    End Property

    Public Property AuthoringMode() As Boolean
      Get
        Return My.Settings.AuthoringMode
      End Get
      Set(ByVal value As Boolean)
        My.Settings.AuthoringMode = value
        mnuAuthoringMode.Checked = value
        If Activity IsNot Nothing Then Activity.AuthoringMode = value
        UpdateApplicationTitle()
      End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New()
      ' Add any initialization after the InitializeComponent() call.
      Try
        With Thread.CurrentThread 'add more languages here
          Select Case My.Settings.LanguageIndex
            Case LanguageSelectionEnum.langEnglish
              .CurrentUICulture = CultureInfo.GetCultureInfo("en")
            Case LanguageSelectionEnum.langGreek
              .CurrentUICulture = CultureInfo.GetCultureInfo("el")
            Case LanguageSelectionEnum.langSpanish
              .CurrentUICulture = CultureInfo.GetCultureInfo("es")
            Case LanguageSelectionEnum.langHungarian
              .CurrentUICulture = CultureInfo.GetCultureInfo("hu")
            Case LanguageSelectionEnum.langPortuguese
              .CurrentUICulture = CultureInfo.GetCultureInfo("pt")
            Case LanguageSelectionEnum.langRomanian
              .CurrentUICulture = CultureInfo.GetCultureInfo("ro")
            Case Else
              .CurrentUICulture = .CurrentCulture 'Set the user interface to display in the same culture as that set in Control Panel.
          End Select
          'My.Resources.Culture = .CurrentUICulture 'not needed: set message strings to use same culture as the GUI forms
        End With
      Catch
        'ignore exception thrown if UI resources are missing for that language (will fallback to the default language)
      End Try
      ' This call is required by the Windows Form Designer.
      InitializeComponent() 'must do after setting the UI culture
      'PLACE ALL OTHER INITIALIZATION AT "MainForm_Load" EVENT HANDLER
    End Sub

    Protected Sub setActivityMenusVisible(ByVal flag As Boolean)
      mnuSaveActivity.Visible = flag
      mnuCloseActivity.Visible = flag

      'always showing mnuImport and mnuImportPackedActivity
      mnuImportSeparator.Visible = flag
      mnuImportVideo.Visible = flag
      'mnuImportAudio.Visible=flag
      mnuImportSubtitles.Visible = flag
      mnuImportDocument.Visible = flag

      mnuExport.Visible = flag

      mnuPrintSeparator.Visible = False ' flag 'KEEP INVISIBLE TILL CORRECTED
      mnuPageSetup.Visible = False  'flag       '>>
      mnuPrint.Visible = False  'flag           '>>
      mnuPrintPreview.Visible = False 'flag    '>>
    End Sub

    Protected Sub NewActivity(ByVal thePath As String)
      If Not CloseActivity() Then Exit Sub 'will try to close any open activity (must do this first, before creating the new activity folder)
      My.Settings.ActivityParentFolder = IO.Path.GetDirectoryName(thePath)
      Directory.CreateDirectory(thePath)
      ActivityView.SaveActivityMarker(thePath)  'make sure the activity marker file isn't empty so that archivers like WinZip do include the marker file if user pack the activity folder themselves
      CreateTextFile(IO.Path.Combine(thePath, ActivityView.FILENAME_SUBTITLES), "") 'must create a subtitles file, as LoadActivity called below will show a dialog that subtitles weren't found
      LoadActivity(thePath)
    End Sub

    Protected Sub UpdateApplicationTitle()
      Text = System.String.Format(My.Settings.Title, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
      If AuthoringMode Then Text = Text & " [" & My.Resources.STR_AUTHORING & "] "
      If Activity IsNot Nothing Then Text &= " - " & IO.Path.GetFileName(Activity.Path)
    End Sub

    Public Sub LoadActivity(ByVal thePath As String)
      Try
        If ActivityView.IsActivityPath(thePath) Then
          thePath = thePath.Remove(thePath.Length - My.Settings.ActivityMarker.Length)  'remove the activity folder marker to get the folder path
        Else
          thePath = RemoveTrailingDirectorySeparator(thePath) 'remove any trailing directory separator char that would cause wrong parsing of the activity folder path
        End If
        If Not IO.Directory.Exists(thePath) Then Throw New DirectoryNotFoundException(My.Resources.STR_FOLDER_NOT_FOUND & ": " & thePath) 'check here before closing the current activity and trying to instantiate a new activity object
        If Not CloseActivity() Then Exit Sub 'will try to close any open activity
        My.Settings.ActivityParentFolder = IO.Path.GetDirectoryName(thePath)
        Activity = New ActivityView(thePath)
        mruActivity.AddRecentlyUsedFile(thePath)
        Activity.AuthoringMode = AuthoringMode
        Activity.Dock = DockStyle.Fill
        panelMain.Controls.Clear()
        panelMain.Controls.Add(Activity)
        setActivityMenusVisible(True)
        UpdateApplicationTitle()
      Catch e As Exception  'DirectoryNotFoundException (catching all exceptions)
        MessageBox.Show(Me, e.Message)
        'Exit Sub
      End Try
    End Sub

    Public Sub OpenActivity()
      With dlgFolderSelection
        .Text = My.Resources.STR_SELECT_ACTIVITY_FOLDER
        .FolderSelectionMode = modeActivityFolder
retry:
        If (.ShowDialog <> Windows.Forms.DialogResult.OK) Then Exit Sub
        If .LegalPath Then LoadActivity(.Path) Else If MessageBox.Show(Me, My.Resources.STR_NOT_ACTIVITY_FOLDER, My.Resources.STR_ERROR, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then GoTo retry
      End With
    End Sub

    Public Sub SaveActivity()
      If Activity IsNot Nothing Then Activity.Save()
    End Sub

    Public Function CloseActivity() As Boolean
      If Activity IsNot Nothing Then
        If Not Activity.Close() Then Return False
        setActivityMenusVisible(False)
        panelMain.Controls.Remove(Activity)
        Activity = Nothing
        ShowLanguageSelection()
        UpdateApplicationTitle()
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath 'set current directory to the application folder
      End If
      Return True
    End Function

    Public Sub PlayPause()
      If Activity IsNot Nothing Then Activity.TogglePlayPause()
    End Sub

    Public Sub ShowHelp()
      Dim helpFile As String = IO.Path.Combine(HelpFolder, "index.html")
      Try
        DevAge.Shell.Utilities.OpenFile(helpFile)
      Catch
        MessageBox.Show(Me, My.Resources.STR_HELP_NOT_FOUND & ": " & helpFile, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

#Region "Import"

    Protected Sub ImportPackedActivity(ByVal thePath As String)
      If Not IO.File.Exists(thePath) Then Throw New FileNotFoundException(My.Resources.STR_FILE_NOT_FOUND & ": " & thePath)
      My.Settings.PackedActivityFolder = IO.Path.GetDirectoryName(thePath)
      mruPackedActivity.AddRecentlyUsedFile(thePath)
      With dlgFolderSelection
        .FolderSelectionMode = modeNonActivityFolder
        .Text = My.Resources.STR_SELECT_PARENT_FOLDER_UNPACK_ACTIVITY
retry:
        If (.ShowDialog <> Windows.Forms.DialogResult.OK) Then Exit Sub
        If Not .LegalPath Then If MessageBox.Show(Me, My.Resources.STR_PARENT_FOLDER_IS_ACTIVITY, My.Resources.STR_ERROR, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then GoTo retry Else Exit Sub
        My.Settings.ActivityParentFolder = .Path
        Try
          Dim newFolder As String = getNonExistentFolderName(IO.Path.Combine(.Path, IO.Path.GetFileNameWithoutExtension(thePath)))
          IO.Directory.CreateDirectory(newFolder) 'must create the folder ourselves
          CompressionUtils.DecompressCAB(thePath, newFolder)
          LoadActivity(newFolder)
        Catch
          MessageBox.Show(Me, My.Resources.STR_UNPACK_FAILED & ": " + IO.Path.GetFileName(thePath), My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
      End With
    End Sub

    Protected Sub ImportVideo(ByVal thePath As String)  'throws IOException
      My.Settings.VideoFolder = IO.Path.GetDirectoryName(thePath)
      mruVideo.AddRecentlyUsedFile(thePath)
      Activity.ImportVideo(thePath)
    End Sub

    Protected Sub ImportAudio(ByVal thePath As String)
      My.Settings.AudioFolder = IO.Path.GetDirectoryName(thePath)
      mruAudio.AddRecentlyUsedFile(thePath)
      Activity.ImportAudio(thePath)
    End Sub

    Protected Sub ImportSubtitles(ByVal thePath As String, ByVal theEncoding As Encoding)
      My.Settings.SubtitlesFolder = IO.Path.GetDirectoryName(thePath)
      mruSubtitles.AddRecentlyUsedFile(thePath)
      Activity.ImportSubtitles(thePath, theEncoding)
    End Sub

    Protected Sub ImportDocument(ByVal thePath As String, ByVal theEncoding As Encoding)
      My.Settings.DocumentFolder = IO.Path.GetDirectoryName(thePath)
      mruDocument.AddRecentlyUsedFile(thePath)
      Activity.ImportDocument(thePath, theEncoding)
    End Sub

#End Region

#Region "Export"

    Protected Sub ExportPackedActivity(ByVal thePath As String, ByVal packMultimedia As Boolean)
      My.Settings.PackedActivityFolder = IO.Path.GetDirectoryName(thePath)
      My.Settings.ActivityParentFolder = IO.Path.GetDirectoryName(thePath)  'for open activity dialog
      mruPackedActivity.AddRecentlyUsedFile(thePath)
      Activity.ExportPackedActivity(thePath, packMultimedia)
    End Sub

    'Protected Sub ExportVideo(ByVal thePath As String)
    ' My.Settings.VideoFolder = IO.Path.GetDirectoryName(thePath)
    ' mruVideo.AddRecentlyUsedFile(thePath)
    ' Activity.ExportVideo(thePath)
    'End Sub

    'Protected Sub ExportAudio(ByVal thePath As String)
    ' My.Settings.AudioFolder = IO.Path.GetDirectoryName(thePath)
    ' mruAudio.AddRecentlyUsedFile(thePath)
    ' Activity.ExportAudio(thePath)
    'End Sub

    Protected Sub ExportSubtitles(ByVal thePath As String, ByVal theEncoding As Encoding)
      My.Settings.SubtitlesFolder = IO.Path.GetDirectoryName(thePath)
      mruSubtitles.AddRecentlyUsedFile(thePath)
      Activity.ExportSubtitles(thePath, theEncoding)
    End Sub

    Protected Sub ExportDocument(ByVal thePath As String)
      My.Settings.DocumentFolder = IO.Path.GetDirectoryName(thePath)
      mruDocument.AddRecentlyUsedFile(thePath)
      Activity.ExportDocument(thePath)  'allow multiple documents exporting or just currently visible one? (should also add notes exporting?)
    End Sub

#End Region

#Region "MRU"

    Public Sub ClearMRU(ByVal mru As MostRecentlyUsedHandler.MRUHandler)
      'add mru.Clear() method
    End Sub

#End Region

#End Region

#Region "Actions"

    Private Sub actionNewActivity_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionNewActivity.Execute
retryActivityName:
      Dim str As String = InputBox(My.Resources.STR_NEW_ACTIVITY_FOLDER_NAME, My.Resources.STR_ENTER_FOLDER_NAME)
      If (str Is Nothing) OrElse (str = "") Then Exit Sub
      If ContainsChars(str, InvalidPathChars) OrElse ContainsChars(str, IO.Path.GetInvalidPathChars) Then 'also checking IO.Path.GetInvalidPathChars, but not printing those at the error message
        MessageBox.Show(Me, My.Resources.STR_INVALID_FOLDER_NAME_CHARS & ": " & CharsString(InvalidPathChars))
        GoTo retryActivityName
      End If
      With dlgFolderSelection
        .Text = My.Resources.STR_SELECT_PARENT_FOLDER_NEW_ACTIVITY
        .FolderSelectionMode = modeNonActivityFolder
retryParentFolder:
        If (.ShowDialog <> Windows.Forms.DialogResult.OK) Then Exit Sub
        If Not .LegalPath Then If MessageBox.Show(Me, My.Resources.STR_PARENT_FOLDER_IS_ACTIVITY, My.Resources.STR_ERROR, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then GoTo retryParentFolder Else Exit Sub
        My.Settings.ActivityParentFolder = .Path
        Dim activityPath As String = Path.Combine(.Path, str)
        If Directory.Exists(activityPath) Then
          If MessageBox.Show(Me, My.Resources.STR_ACTIVITY_FOLDER_EXISTS & ": " & activityPath, My.Resources.STR_ERROR, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Retry Then GoTo retryActivityName
        Else
          NewActivity(activityPath)
        End If
      End With
    End Sub

    Private Sub actionOpenActivityBrowse_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionOpenActivityBrowse.Execute
      OpenActivity()
    End Sub

    Private Sub actionSaveActivity_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionSaveActivity.Execute
      SaveActivity()
    End Sub

    Private Sub actionCloseActivity_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionCloseActivity.Execute
      CloseActivity()
    End Sub

    '-----------------------

    Private Sub actionImportPackedActivity_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionImportPackedActivity.Execute
      dlgImportPackedActivity.ShowDialog()
    End Sub

    Private Sub actionImportVideoBrowse_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionImportVideoBrowse.Execute
      dlgImportVideo.ShowDialog()
    End Sub

    Private Sub actionImportAudioBrowse_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionImportAudioBrowse.Execute
      dlgImportAudio.ShowDialog()
    End Sub

    Private Sub actionImportSubtitlesBrowse_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionImportSubtitlesBrowse.Execute
      dlgImportSubtitles.ShowDialog()
    End Sub

    Private Sub actionImportDocumentBrowse_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionImportDocumentBrowse.Execute
      dlgImportDocument.ShowDialog()
    End Sub

    '-----------------------

    Private Sub actionExportPackedActivity_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionExportPackedActivity.Execute
      dlgExportPackedActivity.ShowDialog()
    End Sub

    Private Sub actionExportSubtitles_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionExportSubtitles.Execute
      dlgExportSubtitles.ShowDialog()
    End Sub

    Private Sub actionExportDocument_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionExportDocument.Execute
      dlgExportDocument.DefaultExt = IO.Path.GetExtension(Activity.Documents.CurrentDocument.Source)  'DefaultExt doesn't return a dot prefix if you get its value, but you can set an extension with a dot prefix to it
      dlgExportDocument.ShowDialog()
    End Sub

    '-----------------------

    Private Sub actionPageSetup_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionPageSetup.Execute
      dlgPageSetup.ShowDialog()
    End Sub

    Private Sub actionPrint_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionPrint.Execute
      '...should show here a dialog to select what stuff to print (subtitles, notes etc.)
      If dlgPrint.ShowDialog() = DialogResult.OK Then
        PrintDocument.Print()
      End If
    End Sub

    Private Sub actionPrintPreview_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionPrintPreview.Execute
      dlgPrintPreview.ShowDialog()
    End Sub

    '-----------------------

    Private Sub actionExit_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionExit.Execute
      Close() 'close the form (this will also execute "MainForm_FormClosing" event handler that will allow user to save activity [if any modified one is loaded] or cancel closing)
    End Sub

    '-----------------------

    Private Sub actionAuthoringMode_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionAuthoringMode.Execute
      AuthoringMode = mnuAuthoringMode.Checked
    End Sub

    '-----------------------

    Private Sub actionHelp_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionHelp.Execute
      ShowHelp()
    End Sub

    Private Sub actionPortal_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionPortal.Execute
      Try
        DevAge.Shell.Utilities.OpenFile(My.Settings.PortalURL)
      Catch
        MessageBox.Show(Me, My.Resources.STR_OPEN_URL_FAILED & ": " & My.Settings.PortalURL, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub actionSendFeedback_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionSendFeedback.Execute
      Try
        DevAge.Shell.Utilities.OpenFile(My.Settings.FeedbackURL & My.Resources.STR_ENTER_FEEDBACK)
      Catch
        MessageBox.Show(Me, My.Resources.STR_OPEN_URL_FAILED & ": " & My.Settings.FeedbackURL & My.Resources.STR_ENTER_FEEDBACK, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub actionClearMRU_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionClearMRU.Execute
      ClearMRU(mruActivity)
      ClearMRU(mruPackedActivity)
      ClearMRU(mruVideo)
      ClearMRU(mruAudio)
      ClearMRU(mruSubtitles)
      ClearMRU(mruDocument)
    End Sub

    Private Sub actionShowAbout_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actionShowAbout.Execute
      AboutDialog.ShowDialog()
    End Sub

#End Region

#Region "Dialogs"

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
      If CloseActivity() Then
        'Threading.Thread.Sleep(My.Settings.ShutdownDelay_msec) 'give some time to webbrowser to close any ActiveDocument servers for documents it was hosting
      Else
        e.Cancel = True
      End If
    End Sub

    '-----------------------

    Private Sub dlgImportPackedActivity_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgImportPackedActivity.FileOk
      ImportPackedActivity(dlgImportPackedActivity.FileName)  'unfortunately this event is called before the dialog has closed so since ImportPackedActivity will show another dialog it will show above this one
    End Sub

    Private Sub dlgImportVideo_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgImportVideo.FileOk
      ImportVideo(dlgImportVideo.FileName)  '!!! allow multiple video selection
    End Sub

    Private Sub dlgImportAudio_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgImportAudio.FileOk
      ImportAudio(dlgImportAudio.FileName)
    End Sub

    Private Sub dlgImportSubtitles_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgImportSubtitles.FileOK
      ImportSubtitles(dlgImportSubtitles.FileName, dlgImportSubtitles.Encoding)
    End Sub

    Private Sub dlgImportDocument_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgImportDocument.FileOK
      With dlgImportDocument
        ImportDocument(.FileName, .Encoding)  '!!! allow multiple document selection
      End With
    End Sub

    '-----------------------

    Private Sub dlgExportPackedActivity_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgExportPackedActivity.FileOk
      With dlgExportPackedActivity
        ExportPackedActivity(.FileName, (.FilterIndex = FILTER_PACKMULTIMEDIA))
      End With
    End Sub

    Private Sub dlgExportSubtitles_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgExportSubtitles.FileOK
      ExportSubtitles(dlgExportSubtitles.FileName, dlgExportSubtitles.Encoding)
    End Sub

    Private Sub dlgExportDocument_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dlgExportDocument.FileOk
      ExportDocument(IO.Path.ChangeExtension(dlgExportDocument.FileName, dlgExportDocument.DefaultExt)) 'force exported document to use same file extension as its source (using dlgExportDocument.AddExtension=False because it always seems to add the 1st extension of the 1st filefilter instead of using the value of DefaultExt property)
    End Sub

#End Region

#Region "MRU"

    Private Sub mruActivity_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruActivity.MRUItemClicked
      Try
        LoadActivity(e.File)
        PrintDocument.DocumentName = IO.Path.GetFileNameWithoutExtension(e.File)
      Catch ex As DirectoryNotFoundException
        MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub mruPackedActivity_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruPackedActivity.MRUItemClicked
      Try
        ImportPackedActivity(e.File)
      Catch ex As FileNotFoundException
        MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub mruVideo_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruVideo.MRUItemClicked
      Try
        ImportVideo(e.File)
      Catch ex As FileNotFoundException
        MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub mruSubtitles_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruSubtitles.MRUItemClicked
      'Try 'do not use this, show the subtitles import dialog instead with the filename preselected, since the user has to select an encoding
      ' ImportSubtitles(e.File,Encoding.Default)
      'Catch ex As FileNotFoundException
      ' MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      'End Try

      With dlgImportSubtitles
        .FileName = e.File
        .ShowDialog()
      End With
    End Sub

    Private Sub mruAudio_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruAudio.MRUItemClicked
      Try
        ImportAudio(e.File)
      Catch ex As FileNotFoundException
        MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub mruDocument_MRUItemClicked(ByVal sender As System.Object, ByVal e As MostRecentlyUsedHandler.MRUItemClickedEventArgs) Handles mruDocument.MRUItemClicked
      'try 'do not use this, show the document import dialog instead with the filename preselected, since the user has to select an encoding
      ' ImportDocument(e.File, Encoding.Default)
      'Catch ex As FileNotFoundException
      ' MessageBox.Show(Me, ex.Message, My.Resources.STR_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
      'End Try

      With dlgImportDocument
        .FileName = e.File
        .ShowDialog()
      End With
    End Sub

#End Region

#Region "Screens"

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      My.Computer.FileSystem.CurrentDirectory = Application.StartupPath 'set current directory to the application folder

      AuthoringMode = My.Settings.AuthoringMode 'this will call UpdateApplicationTitle

      If My.Settings.ActivityParentFolder <> "" Then
        dlgFolderSelection.Path = My.Settings.ActivityParentFolder
      Else
        Dim myActivityParentFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        dlgFolderSelection.Path = myActivityParentFolder
        My.Settings.ActivityParentFolder = myActivityParentFolder
      End If

      If My.Settings.PackedActivityFolder <> "" Then
        dlgImportPackedActivity.InitialDirectory = My.Settings.PackedActivityFolder
      Else
        Dim myPackedActivityFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        dlgImportPackedActivity.InitialDirectory = myPackedActivityFolder
        dlgExportPackedActivity.InitialDirectory = myPackedActivityFolder
        My.Settings.PackedActivityFolder = myPackedActivityFolder
      End If

      If My.Settings.VideoFolder <> "" Then
        dlgImportVideo.InitialDirectory = My.Settings.VideoFolder
      Else
        Dim myVideoFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)  'SpecialFolder_MyVideos (make my own GetFolderPath, this doesn't allow other values)
        dlgImportVideo.InitialDirectory = myVideoFolder
        'dlgExportVideo.InitialDirectory = myVideoFolder
        My.Settings.VideoFolder = myVideoFolder
      End If

      If My.Settings.AudioFolder <> "" Then
        dlgImportAudio.InitialDirectory = My.Settings.AudioFolder
      Else
        Dim myAudioFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
        dlgImportAudio.InitialDirectory = myAudioFolder
        'dlgExportAudio.InitialDirectory = myAudioFolder
        My.Settings.AudioFolder = myAudioFolder
      End If

      If My.Settings.SubtitlesFolder <> "" Then
        'dlgImportSubtitles.InitialDirectory = My.Settings.SubtitlesFolder
      Else
        Dim mySubtitlesFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'dlgImportSubtitles.InitialDirectory = mySubtitlesFolder
        'dlgExportSubtitles.InitialDirectory = mySubtitlesFolder
        My.Settings.SubtitlesFolder = mySubtitlesFolder
      End If

      If My.Settings.DocumentFolder <> "" Then
        'dlgImportDocument.InitialDirectory = My.Settings.DocumentFolder
      Else
        Dim myDocumentFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        'dlgImportDocument.InitialDirectory = myDocumentFolder
        'dlgExportDocument.InitialDirectory = myDocumentFolder
        My.Settings.DocumentFolder = myDocumentFolder
      End If

      'preselect default encoding (system's ANSI codepage) at import/export dialogs that have encoding option
      dlgImportSubtitles.Encoding = Encoding.Default
      dlgExportSubtitles.Encoding = Encoding.Default
      dlgImportDocument.Encoding = Encoding.Default

      setActivityMenusVisible(False)  'do at startup to avoid setting one by one the activity menus to not-visible at the form designer

      ShowLanguageSelection() 'always show before trying to load any .LvS passed to the command-line
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      ParseCommandLine()  'don't do this at "MainForm_Load" event handler since it shows a modal dialog that will else go behind the main form (btw, good thing is that .NET brings to front any hidden modal dialogs when you click their parent form) 'must do after ShowLanguageSelection (so that if this fails, the normal startup screen remains)
    End Sub

    Public Overloads Sub ParseCommandLine()
      ParseCommandLine(My.Application.CommandLineArgs)
    End Sub

    Public Overloads Sub ParseCommandLine(ByVal arguments As ReadOnlyCollection(Of String))
      With arguments
        If .Count > 0 Then
          Dim param0 As String = .Item(0)
          If param0.Equals(PARAM_HELP, StringComparison.InvariantCultureIgnoreCase) Then
            ShowHelp()
          ElseIf ActivityView.IsPackedActivityFile(param0) Then
            ImportPackedActivity(param0)  'treat first command-line parameter as a packed activity file
          Else
            LoadActivity(param0)  'treat first command-line parameter as an activity folder
          End If
        End If
      End With
    End Sub

    Private Sub ShowLanguageSelection()
      If Not CloseActivity() Then Exit Sub 'will try to close any open activity
      Dim LanguageSelection As New LanguageSelectionView
      AddHandler LanguageSelection.LanguageSelectionChanged, AddressOf LanguageSelection_LanguageSelectionChanged
      panelMain.Controls.Add(LanguageSelection)
      LanguageSelection.BringToFront()
      LanguageSelection.Dock = DockStyle.Fill
    End Sub

    Private Sub LanguageSelection_LanguageSelectionChanged(ByVal source As LanguageSelectionView)
      'RemoveHandler source.LanguageSelectionChanged, AddressOf LanguageSelection_LanguageSelectionChanged
      Application.Restart()
    End Sub

#End Region

#Region "Printing"

    Private Sub PrintDocument_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument.BeginPrint
      '...
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
      Activity.Print(e)
    End Sub

#End Region

#Region "HotKeys"

    Private Sub MainForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
        'Case Keys.F1 'not needed, using menu shortcut for this one
        'ShowHelp()
        'Case Keys.F2 'not needed, using menu shortcut for this one
        'SaveActivity()
        'Case Keys.F3 'not needed, using menu shortcut for this one
        'OpenActivity()
        Case Keys.F5
          PlayPause()
        Case Keys.F6
          If Activity IsNot Nothing Then Activity.SetSubtitleStart()
        Case Keys.F7
          If Activity IsNot Nothing Then Activity.SetSubtitleEnd()
        Case Keys.F8
          If Activity IsNot Nothing Then Activity.AddSubtitle()
        Case Keys.F9
          If Activity IsNot Nothing Then Activity.RemoveSubtitle()
      End Select
    End Sub

#End Region

  End Class

End Namespace
