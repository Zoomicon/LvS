'Description: ActivityView class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20111206

#Region "Imports"

Imports System.IO
Imports System.Text

Imports LvS.models
Imports LvS.models.player
Imports LvS.models.subtitles
Imports LvS.models.documents
Imports LvS.models.notes

Imports LvS.objects.players
Imports LvS.objects.subtitles
Imports LvS.objects.documents
Imports LvS.objects.notes

Imports LvS.utilities
Imports LvS.utilities.FileUtils
Imports LvS.utilities.documents

#End Region

Namespace LvS.screens

  Public Class ActivityView
    Implements IActivity

#Region "Constants"

    Public Const FILENAME_SUBTITLES As String = "Subtitles.srt"
    Public Const FILENAME_TEACHER_NOTES As String = "TeacherNotes"  'do not add extension here
    Public Const FILENAME_STUDENT_NOTES As String = "StudentNotes"  'do not add extension here

#End Region

#Region "Fields"

    Protected updatingFocusRow As Boolean
    Protected fAuthoringMode As Boolean '= False
    Protected fPath As String

#End Region

#Region "Properties"

#Region "Views"

    Public ReadOnly Property Player() As IPlayer Implements IActivity.Player
      Get
        Return viewPlayer
      End Get
    End Property

    Public ReadOnly Property Subtitles() As ISubtitlesGrid Implements IActivity.Subtitles
      Get
        Return viewSubtitles
      End Get
    End Property

    Public ReadOnly Property Documents() As IDocuments Implements IActivity.Documents
      Get
        Return viewDocuments
      End Get
    End Property

    Public ReadOnly Property TeacherNotes() As INotes Implements IActivity.TeacherNotes
      Get
        Return viewTeacherNotes
      End Get
    End Property


    Public ReadOnly Property StudentNotes() As INotes Implements IActivity.StudentNotes
      Get
        Return viewStudentNotes
      End Get
    End Property

#End Region

    Public Property AuthoringMode() As Boolean Implements IActivity.AuthoringMode
      Get
        Return fAuthoringMode
      End Get
      Set(ByVal value As Boolean)
        fAuthoringMode = value
        toolstripSubtitles.Visible = value  'show/hide the subtitles toolbar (has only buttons related to authoring there)
        Player.AuthoringMode = value
        Subtitles.AuthoringMode = value
        Documents.AuthoringMode = value
        TeacherNotes.AuthoringMode = value
        StudentNotes.AuthoringMode = True 'student notes are always editable
      End Set
    End Property

    ReadOnly Property Path() As String Implements IActivity.Path
      Get
        Return fPath
      End Get
    End Property

    Property Modified() As Boolean Implements IActivity.Modified
      Get
        Return _
         Subtitles.Modified() OrElse _
         Documents.Modified OrElse _
         TeacherNotes.Modified OrElse _
         StudentNotes.Modified
      End Get
      Set(ByVal value As Boolean)
        If value <> Modified Then
          Subtitles.Modified = value
          Documents.Modified = value
          TeacherNotes.Modified = value
          StudentNotes.Modified = value
          RaiseEvent ModifiedChanged(Me, value)
        End If
      End Set
    End Property

    Protected ReadOnly Property ActiveNotesView() As Notes
      Get
        Dim p As TabPage = tabNotes.SelectedTab
        If p Is tabNotesTeacher Then Return viewTeacherNotes
        If p Is tabNotesStudent Then Return viewStudentNotes
        Return Nothing
      End Get
    End Property

    Protected ReadOnly Property ActiveNotesViewSelected() As Boolean
      Get
        Dim n As Notes = ActiveNotesView
        If n IsNot Nothing Then Return n.Focused Else Return False
      End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ' Must do the following at the constructor, not at "Load" event handler, cause when item is constructed outside of a form, the "Load" event handler is not called
      Player.SubtitleFont = New Font(My.Settings.SubtitlesFontFamily, My.Settings.SubtitlesFontSize, CType(My.Settings.SubtitlesFontStyle, FontStyle))
      CheckSubtitleButtonsEnabled()
      SetNotesSubtitles()
    End Sub

    Public Sub New(ByVal theActivityPath As String)
      Me.New()  'must call this first
      fPath = theActivityPath 'must set this before proceeding
      LoadActivity(theActivityPath)
    End Sub

    Protected Sub SetNotesSubtitles()
      TeacherNotes.SetSubtitles(Subtitles.Subtitles)
      StudentNotes.SetSubtitles(Subtitles.Subtitles)
    End Sub

    Public Sub LoadDocuments() Implements IActivity.LoadDocuments
      With Documents
        .LoadDocuments(Path, DocumentUtils.GetDocumentsFilter)
        .SelectFirstDocument()
      End With
    End Sub

    Function Close() As Boolean Implements IActivity.Close
      If Modified Then
        Dim result As DialogResult = MessageBox.Show(Me, My.Resources.STR_ACTIVITY_MODIFIED, My.Resources.STR_QUESTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Select Case result
          Case DialogResult.Yes
            Save()
          Case DialogResult.Cancel
            Return False
        End Select
      End If
      ClosePlayer()
      CloseDocuments()  'must close the documents, cause WebBrowserDocumentView will else leave any ActiveDocument servers it uses running in the background and the respective files locked (plus won't delete the temp files)
      Return True
    End Function

    Public Sub ClosePlayer()
      Player.Source = ""
      Controls.Remove(viewPlayer)
      viewPlayer.Dispose()  'disposing the player will dispose its children too and free any resources they hold immediately
      viewPlayer = Nothing
    End Sub

    Public Sub CloseDocuments() Implements IActivity.CloseDocuments
      Documents.CloseAll()
    End Sub

    Protected Sub SelectActiveNotesView()
      Dim p As Notes = ActiveNotesView
      If p IsNot Nothing Then p.Select() 'must use "Select", not "Focus"
    End Sub

    Public Sub TogglePlayPause() Implements IActivity.TogglePlayPause
      If Player IsNot Nothing Then
        With Player
          .Paused = Not .Paused
        End With
      End If
    End Sub

    Private Sub CheckSubtitleButtonsEnabled()
      Dim hasSubtitles As Boolean = Subtitles.Subtitles.Count <> 0
      btnSetSubtitleStart.Enabled = hasSubtitles
      btnSetSubtitleEnd.Enabled = hasSubtitles
      btnRemoveSubtitle.Enabled = hasSubtitles
    End Sub

    Public Sub SetSubtitleStart() Implements IActivity.SetSubtitleStart
      Subtitles.StartTime = Player.Time
    End Sub

    Public Sub SetSubtitleEnd() Implements IActivity.SetSubtitleEnd
      Subtitles.EndTime = Player.Time
    End Sub

    Public Sub AddSubtitle() Implements IActivity.AddSubtitle
      Dim time As Double = Player.Time
      Subtitles.InsertSubtitle(time, time + SubtitlesGrid.DEFAULT_NEW_SUBTITLE_DURATION, "", "")
    End Sub

    Public Sub RemoveSubtitle() Implements IActivity.RemoveSubtitle
      Subtitles.RemoveSelected()
    End Sub

#Region "Import"

    Protected Function ImportFile(ByVal thePath As String) As String  'throws IOException
      Try
        Dim targetPath As String = IO.Path.Combine(Path, IO.Path.GetFileName(thePath))
        My.Computer.FileSystem.CopyFile(thePath, targetPath, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
        Return targetPath
      Catch 'user cancel or copy failure
        Return Nothing
      End Try
    End Function

    Protected Sub DeleteVideos()
      DeleteFiles(GetDirectoryFiles(Path, MediaUtils.getVideoFilter, IO.SearchOption.AllDirectories)) 'delete any video files found in the activity folder (recurse subfolders)
    End Sub

    Protected Sub DeleteMultimedia()
      DeleteFiles(GetDirectoryFiles(Path, MediaUtils.getMultimediaFilter, IO.SearchOption.AllDirectories))  'delete any multimedia files found in the activity folder (recurse subfolders)
    End Sub

    Public Sub ImportVideo(ByVal thePath As String) Implements IActivity.ImportVideo
      If Not IO.File.Exists(thePath) Then Throw New FileNotFoundException(My.Resources.STR_FILE_NOT_FOUND & ": " & thePath)
      DeleteVideos()  '!!! maybe use DeleteMultimedia() here?
      LoadVideo(ImportFile(thePath))
    End Sub

    Public Sub ImportAudio(ByVal thePath As String) Implements IActivity.ImportAudio
      If Not IO.File.Exists(thePath) Then Throw New FileNotFoundException(My.Resources.STR_FILE_NOT_FOUND & ": " & thePath)
      '!!! maybe use DeleteMultimedia() here?
      LoadAudio(ImportFile(thePath))
    End Sub

    Public Sub ImportSubtitles(ByVal thePath As String, ByVal theEncoding As Encoding) Implements IActivity.ImportSubtitles
      If Not IO.File.Exists(thePath) Then Throw New FileNotFoundException(My.Resources.STR_FILE_NOT_FOUND & ": " & thePath)
      LoadSubtitles(thePath, theEncoding) 'not copying the subtitles file into the activity, we're storing subtitles into a single format
      Save()  'save the subtitles internally right after importing
    End Sub

    Public Sub ImportDocument(ByVal thePath As String, ByVal theEncoding As Encoding) Implements IActivity.ImportDocument
      If Not IO.File.Exists(thePath) Then Throw New FileNotFoundException(My.Resources.STR_FILE_NOT_FOUND & ": " & thePath)
      Dim document As IDocument = LoadDocument(ImportFile(thePath), IO.Path.GetFileNameWithoutExtension(thePath), theEncoding)
      If TypeOf document Is RTFDocumentView Then
        With document
          .Encoding = Encoding.UTF8
          .Export(thePath)  'save using internal encoding (UTF8), else at next activity loading they'll show up as garbage !!!should have encoding detection routine since user may drop text files directly in the activity folder (even when the app isn't running)
        End With
      End If
    End Sub

#End Region

#Region "Export"

    Public Function ExportPackedActivity(ByVal thePath As String, ByVal packMultimedia As Boolean) As Boolean Implements IActivity.ExportPackedActivity
      Try
        Save()  'save the activity before exporting

        Player.Source = ""  'close video (to unlock its file)

        Dim tempMediaFolder As String = ""  'assigning dummy value to avoid compiler warning later on
        If Not packMultimedia Then
          tempMediaFolder = IO.Path.Combine(IO.Path.GetTempPath, IO.Path.GetRandomFileName())
          IO.Directory.CreateDirectory(tempMediaFolder)
          CopyFiles(GetDirectoryFiles(Path, MediaUtils.getMultimediaFilter, IO.SearchOption.TopDirectoryOnly), tempMediaFolder) 'do not recurse subfolders, cause would lose subfolder path info anyway (multimedia in activity's subfolders will just be deleted/lost)
          DeleteMultimedia()  'this will recurse subfolders
        End If

        Dim selectedDocumentIndex As Integer = Documents.SelectedIndex  'remember document selection
        CloseDocuments()  'close documents to unlock them

        CompressionUtils.CompressCAB(Path, thePath)

        If Not packMultimedia Then
          CopyFiles(GetDirectoryFiles(tempMediaFolder, MediaUtils.getMultimediaFilter, IO.SearchOption.TopDirectoryOnly), Path) 'do not recurse subfolders, cause would lose subfolder path info anyway (multimedia in activity's subfolders have been deleted/lost at the copy/delete step above)
          IO.Directory.Delete(tempMediaFolder, True)  'must do recursive delete here to delete folder contents too, else it will fail since the folder will not be empty it multimedia files had been found in the activity folder
        End If

        LoadVideo() 'reload the video
        LoadDocuments() 'reload the documents
        Try
          Documents.SelectedIndex = selectedDocumentIndex 'restore document selection
        Catch
          'ignore error if one or more document failed to load again
        End Try

        Return True
      Catch e As Exception
        DevAge.Windows.Forms.ErrorDialog.Show(MainForm, e, My.Resources.STR_PACK_ACTIVITY_FOLDER_FAILED)
        Return False
      End Try
    End Function

    'Public Function ExportVideo(ByVal thePath As String) As Boolean
    '...
    'End Function

    'Public Function ExportAudio(ByVal thePath As String) As Boolean
    '...
    'End Function

    Public Function ExportSubtitles(ByVal thePath As String, ByVal theEncoding As Encoding) As Boolean Implements IActivity.ExportSubtitles
      Subtitles.Export(thePath, theEncoding)
    End Function

    Public Function ExportDocument(ByVal thePath As String) As Boolean Implements IActivity.ExportDocument
      Documents.ExportCurrentDocument(thePath)
    End Function

#End Region

#Region "Load"

    Public Shared Function IsActivityPath(ByVal thePath As String) As Boolean
      Return (CheckExtension(thePath, My.Settings.ActivityMarker) IsNot Nothing)
    End Function

    Public Shared Function IsPackedActivityFile(ByVal thePath As String) As Boolean
      Return (CheckExtension(thePath, My.Settings.PackedActivityExtension) IsNot Nothing)
    End Function

    Public Sub LoadActivity(ByVal thePath As String) Implements IActivity.LoadActivity
      If IsActivityPath(thePath) Then
        thePath = thePath.Remove(thePath.Length - My.Settings.ActivityMarker.Length)  'remove the activity folder marker to get the folder path
      Else
        thePath = RemoveTrailingDirectorySeparator(thePath) 'remove any trailing directory separator char that would cause wrong parsing of the activity folder path
      End If
      If Not IO.Directory.Exists(thePath) Then Throw New IO.DirectoryNotFoundException(My.Resources.STR_FOLDER_NOT_FOUND & ": " & thePath)
      My.Computer.FileSystem.CurrentDirectory = thePath 'set current directory to that of the activity
      fPath = thePath
      Try
        LoadVideo()
      Catch
        'ignore video not found case
      End Try
      'loadAudio (if any) (many?)
      Try
        LoadSubtitles(IO.Path.Combine(Path, FILENAME_SUBTITLES), Encoding.Unicode)  'always saving with Unicode (UTF-16, little endian) encoding internally
        Subtitles.Modified = False  'after loading the activity's subtitles, must clear their modified flag
      Catch
        'ignore subtitles not found case
      End Try
      LoadDocuments()

      TeacherNotes.Source = IO.Path.Combine(Path, FILENAME_TEACHER_NOTES)
      TeacherNotes.Modified = False 'after loading the activity's teacher notes, must clear their modified flag

      StudentNotes.Source = IO.Path.Combine(Path, FILENAME_STUDENT_NOTES)
      StudentNotes.Modified = False 'after loading the activity's student notes, must clear their modified flag

      Subtitles.UpdateComments()  'since the notes controls may have loaded per-subtitle comments, must show their icons/tootlips at the subtitles grid
    End Sub

    Public Sub LoadVideo()
      Dim videoFiles As String() = GetDirectoryFiles(fPath, MediaUtils.getVideoFilter, IO.SearchOption.TopDirectoryOnly)
      If videoFiles.Length > 0 Then LoadVideo(videoFiles(0)) 'try to load the first video found (ignore subfolders)
    End Sub

    Public Sub LoadVideo(ByVal thePath As String) Implements IActivity.LoadVideo
      Player.Source = thePath
    End Sub

    Public Sub LoadAudio(ByVal thePath As String) Implements IActivity.LoadAudio
      'AudioPlayer.Source = thePath
    End Sub

    Public Sub LoadSubtitles(ByVal thePath As String, ByVal theEncoding As Encoding) Implements IActivity.LoadSubtitles
      Subtitles.Encoding = theEncoding
      Subtitles.Source = thePath  'do not talk to the "Subtitles" inner object directly
      CheckSubtitleButtonsEnabled()
    End Sub

    Public Function LoadDocument(ByVal thePath As String, ByVal theTitle As String, ByVal theEncoding As Encoding) As IDocument Implements IActivity.LoadDocument
      Return Documents.LoadDocument(thePath, theTitle, theEncoding)
    End Function

#End Region

#Region "Save"

    Public Sub Save() Implements IActivity.Save
      SaveActivityMarker()
      SaveSubtitles()
      TeacherNotes.Save()
      StudentNotes.Save()
      Documents.SaveAll() 'save documents last (just in case they fail)
      Modified = False  'must do this, because Subtitles.Export won't set Subtitles.Modified=false
    End Sub

    Public Sub SaveActivityMarker()
      SaveActivityMarker(Path)
    End Sub

    Public Shared Sub SaveActivityMarker(ByVal thePath As String)
      CreateTextFile(IO.Path.Combine(thePath, My.Settings.ActivityMarker), My.Settings.PortalURL) 'make sure the activity marker file isn't empty so that archivers like WinZip do include the marker file if user pack the activity folder themselves
    End Sub

    Public Sub SaveSubtitles() Implements IActivity.SaveSubtitles
      Subtitles.Export(IO.Path.Combine(Path, FILENAME_SUBTITLES), Encoding.Unicode) 'always saving with Unicode (UTF-16, little endian) encoding internally
    End Sub

#End Region

#Region "Print"

    Public Sub Print(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
      TeacherNotes.Print(e) 'test
    End Sub

#End Region

#End Region

#Region "Events"

    Public Event ModifiedChanged(ByVal source As IModifiable, ByVal newModifiedFlag As Boolean) Implements IModifiable.ModifiedChanged

#Region "Splitter double-click"

    Protected splitHorizontally_DoubleClickToUp As Boolean
    Protected splitLeftVertically_DoubleClickToLeft As Boolean
    Protected splitRightVertically_DoubleClickToLeft As Boolean

    Private Sub ResetSplitDoubleClickCycles()
      splitHorizontally_DoubleClickToUp = False
      splitLeftVertically_DoubleClickToLeft = False
      splitRightVertically_DoubleClickToLeft = False
    End Sub
	
	Private Sub DoSplitHorizontalCycle
      splitCycle(splitHorizontally, splitHorizontally.ClientSize.Width, splitHorizontally_DoubleClickToUp)
	End Sub
	
	Private Sub DoSplitLeftVerticalCycle
	  splitCycle(splitLeftVertically, splitLeftVertically.ClientSize.Height, splitLeftVertically_DoubleClickToLeft)
	End Sub

	Private Sub DoSplitRightVerticalCycle
	  splitCycle(splitRightVertically, splitRightVertically.ClientSize.Height, splitRightVertically_DoubleClickToLeft)
	End Sub
	
    Private Sub splitHorizontal_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitHorizontally.MouseDoubleClick
      DoSplitHorizontalCycle()
    End Sub

    Private Sub splitLeftVertical_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitLeftVertically.MouseDoubleClick
	  DoSplitLeftVerticalCycle()
    End Sub

    Private Sub splitRightVertically_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitRightVertically.MouseDoubleClick
      DoSplitRightVerticalCycle()
    End Sub

    Protected Const SPLITTER_MARGIN As Integer = 10 'need an accuracy margin >0 since the user can never move with the mouse the splitter exactly to its bounds

    Private Shared Sub splitCycle(ByVal splitter As SplitContainer, ByVal max As Integer, ByRef direction As Boolean)
      With splitter
        If .SplitterDistance <= .Panel1MinSize + SPLITTER_MARGIN Then
          .SplitterDistance = CInt(max / 2)
          direction = False
        ElseIf .SplitterDistance >= max - .Panel2MinSize - .SplitterWidth - SPLITTER_MARGIN Then
          .SplitterDistance = CInt(max / 2)
          direction = True
        ElseIf direction Then
          .SplitterDistance = .Panel1MinSize
          direction = False
        Else
          .SplitterDistance = max - .Panel2MinSize - .SplitterWidth
          direction = True
        End If
      End With
    End Sub

#End Region

    Private Sub viewPlayer_FullScreenChanged(source As LvS.models.player.IPlayer, fullscreen As System.Boolean) Handles viewPlayer.FullScreenChanged
      ResetSplitDoubleClickCycles()
	  DoSplitHorizontalCycle()
	  DoSplitLeftVerticalCycle()
	  DoSplitRightVerticalCycle()
    End Sub

#Region "Subtitles toolbar"

    Private Sub btnSetSubtitleStart_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSetSubtitleStart.MouseDown
      SetSubtitleStart()
    End Sub

    Private Sub btnSetSubtitleEnd_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSetSubtitleEnd.MouseDown
      SetSubtitleEnd()
    End Sub

    Private Sub btnAddSubtitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAddSubtitle.MouseDown
      Select Case e.Button
        Case Windows.Forms.MouseButtons.Left
          AddSubtitle()
        Case Else
          SetSubtitleEnd()
      End Select
    End Sub

    Private Sub btnRemoveSubtitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRemoveSubtitle.MouseDown
      RemoveSubtitle()
    End Sub

#End Region

    Private updating As Boolean

    Private Sub viewPlayer_SubtitleChanged(ByVal source As LvS.models.player.IPlayer, ByVal subtitle1 As String, ByVal subtitle2 As String) Handles viewPlayer.SubtitleChanged
      Dim time As Double = Player.Time
      Subtitles.Subtitle1(time) = subtitle1 'this will insert new subtitle at "time" if needed
      Subtitles.Subtitle2(time) = subtitle2
    End Sub

    Private Sub viewPlayer_TimeChanged(ByVal source As LvS.models.player.ITimePosition, ByVal newTime As System.Double) Handles viewPlayer.TimeChanged
      If updating Then Exit Sub
      If updatingFocusRow Then Exit Sub 'when a subtitles row gets focused, the player time is changed. At that point we must stop the event propagation, else if there's time overlap between subtitles the 1st one will get selected, changing the focused row
      updating = True
      Subtitles.Time = newTime
      Player.SelectionStartTime = Subtitles.StartTime
      Player.SelectionEndTime = Subtitles.EndTime
      If Not Player.EditingSubtitles Then 'ignore subtitle change events while we're editing subtitles directly on the player
        Player.Subtitle1 = Subtitles.Subtitle1(newTime)
        Player.Subtitle2 = Subtitles.Subtitle2(newTime)
        'If viewPlayer.Focused Then viewSubtitles.Select() 'if not editing subtitles and viewPlayer is focused, give the focus to Subtitles grid (must use "Select", not "Focus") 'DO NOT USE THIS, SEEMS TO CAUSE ROW JUMPS WHEN TRYING TO SELECT ROWS AT THE SUBTITLES GRID
      End If
      updating = False
    End Sub

    Private Sub viewSubtitles_SubtitleInserted(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.SubtitleInserted
      CheckSubtitleButtonsEnabled()
      SetNotesSubtitles()
    End Sub

    Private Sub viewSubtitles_SubtitleRemoved(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.SubtitleRemoved
      CheckSubtitleButtonsEnabled()
      SetNotesSubtitles()
    End Sub

    Private Sub viewSubtitles_TimeChanged(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal newTime As System.Double) Handles viewSubtitles.TimeChanged
      If updating Then Exit Sub
      updating = True
      Player.Time = newTime
      Player.SelectionStartTime = Subtitles.StartTime
      Player.SelectionEndTime = Subtitles.EndTime
      Player.Subtitle1 = Subtitles.Subtitle1
      Player.Subtitle2 = Subtitles.Subtitle2
      updating = False
    End Sub

    Private Sub viewSubtitles_TeacherCommentChanged(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.TeacherCommentChanged
      TeacherNotes.ChangeComment(theRow)
    End Sub

    Private Sub viewSubtitles_TeacherCommentRemoved(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.TeacherCommentRemoved
      TeacherNotes.RemoveComment(theRow)
    End Sub

    Private Sub viewSubtitles_StudentCommentChanged(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.StudentCommentChanged
      StudentNotes.ChangeComment(theRow)
    End Sub

    Private Sub viewSubtitles_StudentCommentRemoved(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.StudentCommentRemoved
      StudentNotes.RemoveComment(theRow)
    End Sub

    Private Sub viewTeacherNotes_CommentChanged(ByVal source As LvS.models.notes.INotes, ByVal theRow As Integer) Handles viewTeacherNotes.CommentChanged
      Subtitles.ChangeTeacherComment(theRow)
    End Sub

    Private Sub viewStudentNotes_CommentChanged(ByVal source As LvS.models.notes.INotes, ByVal theRow As Integer) Handles viewStudentNotes.CommentChanged
      Subtitles.ChangeStudentComment(theRow)
    End Sub

    Private Sub viewTeacherNotes_FocusedRowChanged(ByVal source As LvS.models.notes.INotes, ByVal theRow As Integer) Handles viewTeacherNotes.FocusedRowChanged
      If updatingFocusRow Then Exit Sub
      updatingFocusRow = True
      Subtitles.FocusedRow = theRow 'this will steal the focus from the selected notes view
      SelectActiveNotesView() 'give back the focus to the selected notes view
      updatingFocusRow = False
    End Sub

    Private Sub viewStudentNotes_FocusedRowChanged(ByVal source As LvS.models.notes.INotes, ByVal theRow As Integer) Handles viewStudentNotes.FocusedRowChanged
      If updatingFocusRow Then Exit Sub
      updatingFocusRow = True
      Subtitles.FocusedRow = theRow 'this will steal the focus from the selected notes view
      SelectActiveNotesView() 'give back the focus to the selected notes view
      updatingFocusRow = False
    End Sub

    Private Sub viewSubtitles_FocusedRowChanged(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theRow As Integer) Handles viewSubtitles.FocusedRowChanged
      If updatingFocusRow Then Exit Sub
      updatingFocusRow = True
      btnRemoveSubtitle.Enabled = (Subtitles.FocusedRow <> -1)
      TeacherNotes.FocusedRow = theRow  'this will steal the focus from the subtitles grid
      StudentNotes.FocusedRow = theRow
      viewSubtitles.Select()  'give back the focus to the subtitles grid (must use "Select", not "Focus")
      updatingFocusRow = False
    End Sub

    Private Sub viewSubtitles_FocusedColumnChanged(ByVal source As LvS.models.subtitles.ISubtitlesGrid, ByVal theColumn As ISubtitlesGrid.Columns) Handles viewSubtitles.FocusedColumnChanged
      Select Case theColumn
        Case ISubtitlesGrid.Columns.colTeacherComment
          tabNotes.SelectedTab = tabNotesTeacher
        Case ISubtitlesGrid.Columns.colStudentComment
          tabNotes.SelectedTab = tabNotesStudent
      End Select
    End Sub

#End Region

  End Class

End Namespace
