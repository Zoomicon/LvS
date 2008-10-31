<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
 Inherits System.Windows.Forms.Form

 'Form overrides dispose to clean up the component list.
 <System.Diagnostics.DebuggerNonUserCode()> _
 Protected Overrides Sub Dispose(ByVal disposing As Boolean)
  Try
   If disposing AndAlso components IsNot Nothing Then
    components.Dispose()
   End If
  Finally
   MyBase.Dispose(disposing)
  End Try
 End Sub

 'Required by the Windows Form Designer
 Private components As System.ComponentModel.IContainer

 'NOTE: The following procedure is required by the Windows Form Designer
 'It can be modified using the Windows Form Designer.  
 'Do not modify it using the code editor.
 <System.Diagnostics.DebuggerStepThrough()> _
 Private Sub InitializeComponent()
  Me.components = New System.ComponentModel.Container
  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
  Me.ActionsImageList = New System.Windows.Forms.ImageList(Me.components)
  Me.actionsApplication = New CDiese.Actions.ActionList(Me.components)
  Me.actionShowAbout = New CDiese.Actions.Action(Me.components)
  Me.actionExit = New CDiese.Actions.Action(Me.components)
  Me.actionOpenActivityBrowse = New CDiese.Actions.Action(Me.components)
  Me.actionImportVideoBrowse = New CDiese.Actions.Action(Me.components)
  Me.actionImportAudioBrowse = New CDiese.Actions.Action(Me.components)
  Me.actionImportSubtitlesBrowse = New CDiese.Actions.Action(Me.components)
  Me.actionImportDocumentBrowse = New CDiese.Actions.Action(Me.components)
  Me.actionImportPackedActivity = New CDiese.Actions.Action(Me.components)
  Me.actionExportPackedActivity = New CDiese.Actions.Action(Me.components)
  Me.actionPageSetup = New CDiese.Actions.Action(Me.components)
  Me.actionPrintPreview = New CDiese.Actions.Action(Me.components)
  Me.actionSaveActivity = New CDiese.Actions.Action(Me.components)
  Me.actionPrint = New CDiese.Actions.Action(Me.components)
  Me.actionExportSubtitles = New CDiese.Actions.Action(Me.components)
  Me.actionExportDocument = New CDiese.Actions.Action(Me.components)
  Me.actionNewActivity = New CDiese.Actions.Action(Me.components)
  Me.actionCloseActivity = New CDiese.Actions.Action(Me.components)
  Me.actionAuthoringMode = New CDiese.Actions.Action(Me.components)
  Me.actionSendFeedback = New CDiese.Actions.Action(Me.components)
  Me.actionClearMRU = New CDiese.Actions.Action(Me.components)
  Me.actionHelp = New CDiese.Actions.Action(Me.components)
  Me.actionPortal = New CDiese.Actions.Action(Me.components)
  Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
  Me.BrowseToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
  Me.BrowseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.BrowseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
  Me.BrowseToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
  Me.BrowseToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
  Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
  Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuPageSetup = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuPrintPreview = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuSaveActivity = New System.Windows.Forms.ToolStripMenuItem
  Me.SubtitlesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
  Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuNewActivity = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuCloseActivity = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuAuthoringMode = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuSendFeedback = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuClearMRU = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuShowHelp = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuPortal = New System.Windows.Forms.ToolStripMenuItem
  Me.MenuStrip = New System.Windows.Forms.MenuStrip
  Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuOpenActivity = New System.Windows.Forms.ToolStripMenuItem
  Me.MruActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
  Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuImportPackedActivity = New System.Windows.Forms.ToolStripMenuItem
  Me.MruPackedActivityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuImportSeparator = New System.Windows.Forms.ToolStripSeparator
  Me.mnuImportVideo = New System.Windows.Forms.ToolStripMenuItem
  Me.MruVideoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuImportAudio = New System.Windows.Forms.ToolStripMenuItem
  Me.MruAudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuImportSubtitles = New System.Windows.Forms.ToolStripMenuItem
  Me.MruSubtitlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuImportDocument = New System.Windows.Forms.ToolStripMenuItem
  Me.MruDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem
  Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
  Me.VideoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
  Me.AudioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuPrintSeparator = New System.Windows.Forms.ToolStripSeparator
  Me.FileMenuSeparator3 = New System.Windows.Forms.ToolStripSeparator
  Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
  Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
  Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
  Me.StatusStrip = New System.Windows.Forms.StatusStrip
  Me.statusMessage = New System.Windows.Forms.ToolStripStatusLabel
  Me.dlgImportVideo = New System.Windows.Forms.OpenFileDialog
  Me.mruVideo = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.mruActivity = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.dlgImportAudio = New System.Windows.Forms.OpenFileDialog
  Me.mruAudio = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.mruSubtitles = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.mruDocument = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.dlgImportDocument = New LvS.utilities.dialogs.OpenFileDialogWithEncoding
  Me.dlgImportPackedActivity = New System.Windows.Forms.OpenFileDialog
  Me.mruPackedActivity = New MostRecentlyUsedHandler.MRUHandler(Me.components)
  Me.dlgExportPackedActivity = New System.Windows.Forms.SaveFileDialog
  Me.dlgPageSetup = New System.Windows.Forms.PageSetupDialog
  Me.PrintDocument = New System.Drawing.Printing.PrintDocument
  Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog
  Me.dlgPrint = New System.Windows.Forms.PrintDialog
  Me.dlgExportDocument = New System.Windows.Forms.SaveFileDialog
  Me.panelMain = New System.Windows.Forms.Panel
  Me.dlgImportSubtitles = New LvS.utilities.dialogs.OpenFileDialogWithEncoding
  Me.dlgExportSubtitles = New LvS.utilities.dialogs.SaveFileDialogWithEncoding
  Me.MenuStrip.SuspendLayout()
  Me.StatusStrip.SuspendLayout()
  CType(Me.mruVideo, System.ComponentModel.ISupportInitialize).BeginInit()
  CType(Me.mruActivity, System.ComponentModel.ISupportInitialize).BeginInit()
  CType(Me.mruAudio, System.ComponentModel.ISupportInitialize).BeginInit()
  CType(Me.mruSubtitles, System.ComponentModel.ISupportInitialize).BeginInit()
  CType(Me.mruDocument, System.ComponentModel.ISupportInitialize).BeginInit()
  CType(Me.mruPackedActivity, System.ComponentModel.ISupportInitialize).BeginInit()
  Me.SuspendLayout()
  '
  'ActionsImageList
  '
  Me.ActionsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
  resources.ApplyResources(Me.ActionsImageList, "ActionsImageList")
  Me.ActionsImageList.TransparentColor = System.Drawing.Color.Transparent
  '
  'actionsApplication
  '
  Me.actionsApplication.Actions.AddRange(New CDiese.Actions.Action() {Me.actionShowAbout, Me.actionExit, Me.actionOpenActivityBrowse, Me.actionImportVideoBrowse, Me.actionImportAudioBrowse, Me.actionImportSubtitlesBrowse, Me.actionImportDocumentBrowse, Me.actionImportPackedActivity, Me.actionExportPackedActivity, Me.actionPageSetup, Me.actionPrintPreview, Me.actionSaveActivity, Me.actionPrint, Me.actionExportSubtitles, Me.actionExportDocument, Me.actionNewActivity, Me.actionCloseActivity, Me.actionAuthoringMode, Me.actionSendFeedback, Me.actionClearMRU, Me.actionHelp, Me.actionPortal})
  Me.actionsApplication.ImageList = Nothing
  Me.actionsApplication.ShowTextOnToolBar = False
  Me.actionsApplication.Tag = Nothing
  '
  'actionShowAbout
  '
  Me.actionShowAbout.Checked = False
  Me.actionShowAbout.Enabled = True
  resources.ApplyResources(Me.actionShowAbout, "actionShowAbout")
  Me.actionShowAbout.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionShowAbout.Tag = Nothing
  Me.actionShowAbout.Visible = True
  '
  'actionExit
  '
  Me.actionExit.Checked = False
  Me.actionExit.Enabled = True
  resources.ApplyResources(Me.actionExit, "actionExit")
  Me.actionExit.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionExit.Tag = Nothing
  Me.actionExit.Visible = True
  '
  'actionOpenActivityBrowse
  '
  Me.actionOpenActivityBrowse.Checked = False
  Me.actionOpenActivityBrowse.Enabled = True
  resources.ApplyResources(Me.actionOpenActivityBrowse, "actionOpenActivityBrowse")
  Me.actionOpenActivityBrowse.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionOpenActivityBrowse.Tag = Nothing
  Me.actionOpenActivityBrowse.Visible = True
  '
  'actionImportVideoBrowse
  '
  Me.actionImportVideoBrowse.Checked = False
  Me.actionImportVideoBrowse.Enabled = True
  resources.ApplyResources(Me.actionImportVideoBrowse, "actionImportVideoBrowse")
  Me.actionImportVideoBrowse.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionImportVideoBrowse.Tag = Nothing
  Me.actionImportVideoBrowse.Visible = True
  '
  'actionImportAudioBrowse
  '
  Me.actionImportAudioBrowse.Checked = False
  Me.actionImportAudioBrowse.Enabled = True
  resources.ApplyResources(Me.actionImportAudioBrowse, "actionImportAudioBrowse")
  Me.actionImportAudioBrowse.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionImportAudioBrowse.Tag = Nothing
  Me.actionImportAudioBrowse.Visible = True
  '
  'actionImportSubtitlesBrowse
  '
  Me.actionImportSubtitlesBrowse.Checked = False
  Me.actionImportSubtitlesBrowse.Enabled = True
  resources.ApplyResources(Me.actionImportSubtitlesBrowse, "actionImportSubtitlesBrowse")
  Me.actionImportSubtitlesBrowse.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionImportSubtitlesBrowse.Tag = Nothing
  Me.actionImportSubtitlesBrowse.Visible = True
  '
  'actionImportDocumentBrowse
  '
  Me.actionImportDocumentBrowse.Checked = False
  Me.actionImportDocumentBrowse.Enabled = True
  resources.ApplyResources(Me.actionImportDocumentBrowse, "actionImportDocumentBrowse")
  Me.actionImportDocumentBrowse.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionImportDocumentBrowse.Tag = Nothing
  Me.actionImportDocumentBrowse.Visible = True
  '
  'actionImportPackedActivity
  '
  Me.actionImportPackedActivity.Checked = False
  Me.actionImportPackedActivity.Enabled = True
  resources.ApplyResources(Me.actionImportPackedActivity, "actionImportPackedActivity")
  Me.actionImportPackedActivity.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionImportPackedActivity.Tag = Nothing
  Me.actionImportPackedActivity.Visible = True
  '
  'actionExportPackedActivity
  '
  Me.actionExportPackedActivity.Checked = False
  Me.actionExportPackedActivity.Enabled = True
  resources.ApplyResources(Me.actionExportPackedActivity, "actionExportPackedActivity")
  Me.actionExportPackedActivity.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionExportPackedActivity.Tag = Nothing
  Me.actionExportPackedActivity.Visible = True
  '
  'actionPageSetup
  '
  Me.actionPageSetup.Checked = False
  Me.actionPageSetup.Enabled = True
  resources.ApplyResources(Me.actionPageSetup, "actionPageSetup")
  Me.actionPageSetup.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionPageSetup.Tag = Nothing
  Me.actionPageSetup.Visible = True
  '
  'actionPrintPreview
  '
  Me.actionPrintPreview.Checked = False
  Me.actionPrintPreview.Enabled = True
  resources.ApplyResources(Me.actionPrintPreview, "actionPrintPreview")
  Me.actionPrintPreview.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionPrintPreview.Tag = Nothing
  Me.actionPrintPreview.Visible = True
  '
  'actionSaveActivity
  '
  Me.actionSaveActivity.Checked = False
  Me.actionSaveActivity.Enabled = True
  resources.ApplyResources(Me.actionSaveActivity, "actionSaveActivity")
  Me.actionSaveActivity.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionSaveActivity.Tag = Nothing
  Me.actionSaveActivity.Visible = True
  '
  'actionPrint
  '
  Me.actionPrint.Checked = False
  Me.actionPrint.Enabled = True
  resources.ApplyResources(Me.actionPrint, "actionPrint")
  Me.actionPrint.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionPrint.Tag = Nothing
  Me.actionPrint.Visible = True
  '
  'actionExportSubtitles
  '
  Me.actionExportSubtitles.Checked = False
  Me.actionExportSubtitles.Enabled = True
  resources.ApplyResources(Me.actionExportSubtitles, "actionExportSubtitles")
  Me.actionExportSubtitles.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionExportSubtitles.Tag = Nothing
  Me.actionExportSubtitles.Visible = True
  '
  'actionExportDocument
  '
  Me.actionExportDocument.Checked = False
  Me.actionExportDocument.Enabled = True
  resources.ApplyResources(Me.actionExportDocument, "actionExportDocument")
  Me.actionExportDocument.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionExportDocument.Tag = Nothing
  Me.actionExportDocument.Visible = True
  '
  'actionNewActivity
  '
  Me.actionNewActivity.Checked = False
  Me.actionNewActivity.Enabled = True
  resources.ApplyResources(Me.actionNewActivity, "actionNewActivity")
  Me.actionNewActivity.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionNewActivity.Tag = Nothing
  Me.actionNewActivity.Visible = True
  '
  'actionCloseActivity
  '
  Me.actionCloseActivity.Checked = False
  Me.actionCloseActivity.Enabled = True
  resources.ApplyResources(Me.actionCloseActivity, "actionCloseActivity")
  Me.actionCloseActivity.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionCloseActivity.Tag = Nothing
  Me.actionCloseActivity.Visible = True
  '
  'actionAuthoringMode
  '
  Me.actionAuthoringMode.Checked = False
  Me.actionAuthoringMode.Enabled = True
  resources.ApplyResources(Me.actionAuthoringMode, "actionAuthoringMode")
  Me.actionAuthoringMode.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionAuthoringMode.Tag = Nothing
  Me.actionAuthoringMode.Visible = True
  '
  'actionSendFeedback
  '
  Me.actionSendFeedback.Checked = False
  Me.actionSendFeedback.Enabled = True
  resources.ApplyResources(Me.actionSendFeedback, "actionSendFeedback")
  Me.actionSendFeedback.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionSendFeedback.Tag = Nothing
  Me.actionSendFeedback.Visible = True
  '
  'actionClearMRU
  '
  Me.actionClearMRU.Checked = False
  Me.actionClearMRU.Enabled = True
  resources.ApplyResources(Me.actionClearMRU, "actionClearMRU")
  Me.actionClearMRU.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionClearMRU.Tag = Nothing
  Me.actionClearMRU.Visible = True
  '
  'actionHelp
  '
  Me.actionHelp.Checked = False
  Me.actionHelp.Enabled = True
  resources.ApplyResources(Me.actionHelp, "actionHelp")
  Me.actionHelp.Shortcut = System.Windows.Forms.Shortcut.F1
  Me.actionHelp.Tag = Nothing
  Me.actionHelp.Visible = True
  '
  'actionPortal
  '
  Me.actionPortal.Checked = False
  Me.actionPortal.Enabled = True
  resources.ApplyResources(Me.actionPortal, "actionPortal")
  Me.actionPortal.Shortcut = System.Windows.Forms.Shortcut.None
  Me.actionPortal.Tag = Nothing
  Me.actionPortal.Visible = True
  '
  'mnuAbout
  '
  Me.actionsApplication.SetAction(Me.mnuAbout, Me.actionShowAbout)
  Me.mnuAbout.Image = Global.My.Resources.Resources.information
  Me.mnuAbout.Name = "mnuAbout"
  resources.ApplyResources(Me.mnuAbout, "mnuAbout")
  '
  'mnuExit
  '
  Me.actionsApplication.SetAction(Me.mnuExit, Me.actionExit)
  Me.mnuExit.Name = "mnuExit"
  resources.ApplyResources(Me.mnuExit, "mnuExit")
  '
  'BrowseToolStripMenuItem4
  '
  Me.actionsApplication.SetAction(Me.BrowseToolStripMenuItem4, Me.actionOpenActivityBrowse)
  Me.BrowseToolStripMenuItem4.Name = "BrowseToolStripMenuItem4"
  resources.ApplyResources(Me.BrowseToolStripMenuItem4, "BrowseToolStripMenuItem4")
  '
  'BrowseToolStripMenuItem
  '
  Me.actionsApplication.SetAction(Me.BrowseToolStripMenuItem, Me.actionImportVideoBrowse)
  Me.BrowseToolStripMenuItem.Name = "BrowseToolStripMenuItem"
  resources.ApplyResources(Me.BrowseToolStripMenuItem, "BrowseToolStripMenuItem")
  '
  'BrowseToolStripMenuItem1
  '
  Me.actionsApplication.SetAction(Me.BrowseToolStripMenuItem1, Me.actionImportAudioBrowse)
  Me.BrowseToolStripMenuItem1.Name = "BrowseToolStripMenuItem1"
  resources.ApplyResources(Me.BrowseToolStripMenuItem1, "BrowseToolStripMenuItem1")
  '
  'BrowseToolStripMenuItem2
  '
  Me.actionsApplication.SetAction(Me.BrowseToolStripMenuItem2, Me.actionImportSubtitlesBrowse)
  Me.BrowseToolStripMenuItem2.Name = "BrowseToolStripMenuItem2"
  resources.ApplyResources(Me.BrowseToolStripMenuItem2, "BrowseToolStripMenuItem2")
  '
  'BrowseToolStripMenuItem3
  '
  Me.actionsApplication.SetAction(Me.BrowseToolStripMenuItem3, Me.actionImportDocumentBrowse)
  Me.BrowseToolStripMenuItem3.Name = "BrowseToolStripMenuItem3"
  resources.ApplyResources(Me.BrowseToolStripMenuItem3, "BrowseToolStripMenuItem3")
  '
  'ToolStripMenuItem4
  '
  Me.actionsApplication.SetAction(Me.ToolStripMenuItem4, Me.actionImportPackedActivity)
  Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
  resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
  '
  'ToolStripMenuItem2
  '
  Me.actionsApplication.SetAction(Me.ToolStripMenuItem2, Me.actionExportPackedActivity)
  Me.ToolStripMenuItem2.Image = Global.My.Resources.Resources.page_white_compressed
  Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
  resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
  '
  'mnuPageSetup
  '
  Me.actionsApplication.SetAction(Me.mnuPageSetup, Me.actionPageSetup)
  Me.mnuPageSetup.Image = Global.My.Resources.Resources.Control_PageSetupDialog
  resources.ApplyResources(Me.mnuPageSetup, "mnuPageSetup")
  Me.mnuPageSetup.Name = "mnuPageSetup"
  '
  'mnuPrintPreview
  '
  Me.actionsApplication.SetAction(Me.mnuPrintPreview, Me.actionPrintPreview)
  Me.mnuPrintPreview.Image = Global.My.Resources.Resources.Control_PrintPreviewControl
  resources.ApplyResources(Me.mnuPrintPreview, "mnuPrintPreview")
  Me.mnuPrintPreview.Name = "mnuPrintPreview"
  '
  'mnuPrint
  '
  Me.actionsApplication.SetAction(Me.mnuPrint, Me.actionPrint)
  Me.mnuPrint.Image = Global.My.Resources.Resources.printer
  Me.mnuPrint.Name = "mnuPrint"
  resources.ApplyResources(Me.mnuPrint, "mnuPrint")
  '
  'mnuSaveActivity
  '
  Me.actionsApplication.SetAction(Me.mnuSaveActivity, Me.actionSaveActivity)
  Me.mnuSaveActivity.Image = Global.My.Resources.Resources.action_save1
  Me.mnuSaveActivity.Name = "mnuSaveActivity"
  resources.ApplyResources(Me.mnuSaveActivity, "mnuSaveActivity")
  '
  'SubtitlesToolStripMenuItem1
  '
  Me.actionsApplication.SetAction(Me.SubtitlesToolStripMenuItem1, Me.actionExportSubtitles)
  Me.SubtitlesToolStripMenuItem1.Image = Global.My.Resources.Resources.comments
  Me.SubtitlesToolStripMenuItem1.Name = "SubtitlesToolStripMenuItem1"
  resources.ApplyResources(Me.SubtitlesToolStripMenuItem1, "SubtitlesToolStripMenuItem1")
  '
  'DocumentToolStripMenuItem
  '
  Me.actionsApplication.SetAction(Me.DocumentToolStripMenuItem, Me.actionExportDocument)
  Me.DocumentToolStripMenuItem.Image = Global.My.Resources.Resources.page_white_text
  Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
  resources.ApplyResources(Me.DocumentToolStripMenuItem, "DocumentToolStripMenuItem")
  '
  'mnuNewActivity
  '
  Me.actionsApplication.SetAction(Me.mnuNewActivity, Me.actionNewActivity)
  Me.mnuNewActivity.Image = Global.My.Resources.Resources.DOC
  resources.ApplyResources(Me.mnuNewActivity, "mnuNewActivity")
  Me.mnuNewActivity.Name = "mnuNewActivity"
  '
  'mnuCloseActivity
  '
  Me.actionsApplication.SetAction(Me.mnuCloseActivity, Me.actionCloseActivity)
  Me.mnuCloseActivity.Name = "mnuCloseActivity"
  resources.ApplyResources(Me.mnuCloseActivity, "mnuCloseActivity")
  '
  'mnuAuthoringMode
  '
  Me.actionsApplication.SetAction(Me.mnuAuthoringMode, Me.actionAuthoringMode)
  Me.mnuAuthoringMode.CheckOnClick = True
  Me.mnuAuthoringMode.Name = "mnuAuthoringMode"
  resources.ApplyResources(Me.mnuAuthoringMode, "mnuAuthoringMode")
  '
  'mnuSendFeedback
  '
  Me.actionsApplication.SetAction(Me.mnuSendFeedback, Me.actionSendFeedback)
  Me.mnuSendFeedback.Image = Global.My.Resources.Resources.email
  Me.mnuSendFeedback.Name = "mnuSendFeedback"
  resources.ApplyResources(Me.mnuSendFeedback, "mnuSendFeedback")
  '
  'mnuClearMRU
  '
  Me.actionsApplication.SetAction(Me.mnuClearMRU, Me.actionClearMRU)
  Me.mnuClearMRU.Name = "mnuClearMRU"
  resources.ApplyResources(Me.mnuClearMRU, "mnuClearMRU")
  '
  'mnuShowHelp
  '
  Me.actionsApplication.SetAction(Me.mnuShowHelp, Me.actionHelp)
  Me.mnuShowHelp.Image = Global.My.Resources.Resources.help
  Me.mnuShowHelp.Name = "mnuShowHelp"
  resources.ApplyResources(Me.mnuShowHelp, "mnuShowHelp")
  '
  'mnuPortal
  '
  Me.actionsApplication.SetAction(Me.mnuPortal, Me.actionPortal)
  Me.mnuPortal.Image = Global.My.Resources.Resources.world_go
  Me.mnuPortal.Name = "mnuPortal"
  resources.ApplyResources(Me.mnuPortal, "mnuPortal")
  '
  'MenuStrip
  '
  Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuOptions, Me.mnuHelp})
  resources.ApplyResources(Me.MenuStrip, "MenuStrip")
  Me.MenuStrip.Name = "MenuStrip"
  Me.MenuStrip.ShowItemToolTips = True
  '
  'mnuFile
  '
  Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewActivity, Me.mnuOpenActivity, Me.mnuSaveActivity, Me.mnuCloseActivity, Me.ToolStripSeparator2, Me.mnuImport, Me.mnuExport, Me.mnuPrintSeparator, Me.mnuPageSetup, Me.mnuPrint, Me.mnuPrintPreview, Me.FileMenuSeparator3, Me.mnuExit})
  Me.mnuFile.Name = "mnuFile"
  resources.ApplyResources(Me.mnuFile, "mnuFile")
  '
  'mnuOpenActivity
  '
  Me.mnuOpenActivity.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem4, Me.MruActivityToolStripMenuItem})
  Me.mnuOpenActivity.Image = Global.My.Resources.Resources.OPENFOLD
  resources.ApplyResources(Me.mnuOpenActivity, "mnuOpenActivity")
  Me.mnuOpenActivity.Name = "mnuOpenActivity"
  '
  'MruActivityToolStripMenuItem
  '
  Me.MruActivityToolStripMenuItem.Name = "MruActivityToolStripMenuItem"
  resources.ApplyResources(Me.MruActivityToolStripMenuItem, "MruActivityToolStripMenuItem")
  '
  'ToolStripSeparator2
  '
  Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
  resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
  '
  'mnuImport
  '
  Me.mnuImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImportPackedActivity, Me.mnuImportSeparator, Me.mnuImportVideo, Me.mnuImportAudio, Me.mnuImportSubtitles, Me.mnuImportDocument})
  Me.mnuImport.Name = "mnuImport"
  resources.ApplyResources(Me.mnuImport, "mnuImport")
  '
  'mnuImportPackedActivity
  '
  Me.mnuImportPackedActivity.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.MruPackedActivityToolStripMenuItem})
  Me.mnuImportPackedActivity.Image = Global.My.Resources.Resources.page_white_compressed
  Me.mnuImportPackedActivity.Name = "mnuImportPackedActivity"
  resources.ApplyResources(Me.mnuImportPackedActivity, "mnuImportPackedActivity")
  '
  'MruPackedActivityToolStripMenuItem
  '
  Me.MruPackedActivityToolStripMenuItem.Name = "MruPackedActivityToolStripMenuItem"
  resources.ApplyResources(Me.MruPackedActivityToolStripMenuItem, "MruPackedActivityToolStripMenuItem")
  '
  'mnuImportSeparator
  '
  Me.mnuImportSeparator.Name = "mnuImportSeparator"
  resources.ApplyResources(Me.mnuImportSeparator, "mnuImportSeparator")
  '
  'mnuImportVideo
  '
  Me.mnuImportVideo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem, Me.MruVideoToolStripMenuItem})
  Me.mnuImportVideo.Image = Global.My.Resources.Resources.page_video
  Me.mnuImportVideo.Name = "mnuImportVideo"
  resources.ApplyResources(Me.mnuImportVideo, "mnuImportVideo")
  '
  'MruVideoToolStripMenuItem
  '
  Me.MruVideoToolStripMenuItem.Name = "MruVideoToolStripMenuItem"
  resources.ApplyResources(Me.MruVideoToolStripMenuItem, "MruVideoToolStripMenuItem")
  '
  'mnuImportAudio
  '
  Me.mnuImportAudio.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem1, Me.MruAudioToolStripMenuItem})
  Me.mnuImportAudio.Name = "mnuImportAudio"
  resources.ApplyResources(Me.mnuImportAudio, "mnuImportAudio")
  '
  'MruAudioToolStripMenuItem
  '
  Me.MruAudioToolStripMenuItem.Name = "MruAudioToolStripMenuItem"
  resources.ApplyResources(Me.MruAudioToolStripMenuItem, "MruAudioToolStripMenuItem")
  '
  'mnuImportSubtitles
  '
  Me.mnuImportSubtitles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem2, Me.MruSubtitlesToolStripMenuItem})
  Me.mnuImportSubtitles.Image = Global.My.Resources.Resources.comments
  Me.mnuImportSubtitles.Name = "mnuImportSubtitles"
  resources.ApplyResources(Me.mnuImportSubtitles, "mnuImportSubtitles")
  '
  'MruSubtitlesToolStripMenuItem
  '
  Me.MruSubtitlesToolStripMenuItem.Name = "MruSubtitlesToolStripMenuItem"
  resources.ApplyResources(Me.MruSubtitlesToolStripMenuItem, "MruSubtitlesToolStripMenuItem")
  '
  'mnuImportDocument
  '
  Me.mnuImportDocument.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem3, Me.MruDocumentToolStripMenuItem})
  Me.mnuImportDocument.Image = Global.My.Resources.Resources.page_white_text
  Me.mnuImportDocument.Name = "mnuImportDocument"
  resources.ApplyResources(Me.mnuImportDocument, "mnuImportDocument")
  '
  'MruDocumentToolStripMenuItem
  '
  Me.MruDocumentToolStripMenuItem.Name = "MruDocumentToolStripMenuItem"
  resources.ApplyResources(Me.MruDocumentToolStripMenuItem, "MruDocumentToolStripMenuItem")
  '
  'mnuExport
  '
  Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripSeparator5, Me.VideoToolStripMenuItem1, Me.AudioToolStripMenuItem1, Me.SubtitlesToolStripMenuItem1, Me.DocumentToolStripMenuItem})
  Me.mnuExport.Name = "mnuExport"
  resources.ApplyResources(Me.mnuExport, "mnuExport")
  '
  'ToolStripSeparator5
  '
  Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
  resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
  '
  'VideoToolStripMenuItem1
  '
  Me.VideoToolStripMenuItem1.Image = Global.My.Resources.Resources.page_video
  Me.VideoToolStripMenuItem1.Name = "VideoToolStripMenuItem1"
  resources.ApplyResources(Me.VideoToolStripMenuItem1, "VideoToolStripMenuItem1")
  '
  'AudioToolStripMenuItem1
  '
  Me.AudioToolStripMenuItem1.Name = "AudioToolStripMenuItem1"
  resources.ApplyResources(Me.AudioToolStripMenuItem1, "AudioToolStripMenuItem1")
  '
  'mnuPrintSeparator
  '
  Me.mnuPrintSeparator.Name = "mnuPrintSeparator"
  resources.ApplyResources(Me.mnuPrintSeparator, "mnuPrintSeparator")
  '
  'FileMenuSeparator3
  '
  Me.FileMenuSeparator3.Name = "FileMenuSeparator3"
  resources.ApplyResources(Me.FileMenuSeparator3, "FileMenuSeparator3")
  '
  'mnuOptions
  '
  Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAuthoringMode})
  Me.mnuOptions.Name = "mnuOptions"
  resources.ApplyResources(Me.mnuOptions, "mnuOptions")
  '
  'mnuHelp
  '
  Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowHelp, Me.mnuPortal, Me.mnuSendFeedback, Me.mnuClearMRU, Me.ToolStripSeparator1, Me.mnuAbout})
  Me.mnuHelp.Name = "mnuHelp"
  resources.ApplyResources(Me.mnuHelp, "mnuHelp")
  '
  'ToolStripSeparator1
  '
  Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
  resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
  '
  'StatusStrip
  '
  Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusMessage})
  resources.ApplyResources(Me.StatusStrip, "StatusStrip")
  Me.StatusStrip.Name = "StatusStrip"
  '
  'statusMessage
  '
  Me.statusMessage.BackColor = System.Drawing.Color.Transparent
  Me.statusMessage.Name = "statusMessage"
  resources.ApplyResources(Me.statusMessage, "statusMessage")
  '
  'dlgImportVideo
  '
  Me.dlgImportVideo.DefaultExt = "wmv"
  resources.ApplyResources(Me.dlgImportVideo, "dlgImportVideo")
  '
  'mruVideo
  '
  Me.mruVideo.AutoSeparators = True
  Me.mruVideo.MruItem = Me.MruVideoToolStripMenuItem
  Me.mruVideo.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruVideo.StorageName = "videomru"
  '
  'mruActivity
  '
  Me.mruActivity.AutoSeparators = True
  Me.mruActivity.MruItem = Me.MruActivityToolStripMenuItem
  Me.mruActivity.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruActivity.StorageName = "activitymru"
  '
  'dlgImportAudio
  '
  Me.dlgImportAudio.DefaultExt = "wav"
  resources.ApplyResources(Me.dlgImportAudio, "dlgImportAudio")
  '
  'mruAudio
  '
  Me.mruAudio.AutoSeparators = True
  Me.mruAudio.MruItem = Me.MruAudioToolStripMenuItem
  Me.mruAudio.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruAudio.StorageName = "audiomru"
  '
  'mruSubtitles
  '
  Me.mruSubtitles.AutoSeparators = True
  Me.mruSubtitles.MruItem = Me.MruSubtitlesToolStripMenuItem
  Me.mruSubtitles.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruSubtitles.StorageName = "subtitlesmru"
  '
  'mruDocument
  '
  Me.mruDocument.AutoSeparators = True
  Me.mruDocument.MruItem = Me.MruDocumentToolStripMenuItem
  Me.mruDocument.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruDocument.StorageName = "documentmru"
  '
  'dlgImportDocument
  '
  Me.dlgImportDocument.DefaultExt = "mht"
  Me.dlgImportDocument.Encoding = CType(resources.GetObject("dlgImportDocument.Encoding"), System.Text.Encoding)
  resources.ApplyResources(Me.dlgImportDocument, "dlgImportDocument")
  Me.dlgImportDocument.FileName = ""
  '
  'dlgImportPackedActivity
  '
  Me.dlgImportPackedActivity.DefaultExt = "lvs"
  resources.ApplyResources(Me.dlgImportPackedActivity, "dlgImportPackedActivity")
  '
  'mruPackedActivity
  '
  Me.mruPackedActivity.AutoSeparators = True
  Me.mruPackedActivity.MruItem = Me.MruPackedActivityToolStripMenuItem
  Me.mruPackedActivity.MRUStyle = MostRecentlyUsedHandler.MRUStyle.Inline
  Me.mruPackedActivity.StorageName = "packedactivitymru"
  '
  'dlgExportPackedActivity
  '
  Me.dlgExportPackedActivity.DefaultExt = "lvs"
  resources.ApplyResources(Me.dlgExportPackedActivity, "dlgExportPackedActivity")
  '
  'dlgPageSetup
  '
  Me.dlgPageSetup.Document = Me.PrintDocument
  '
  'PrintDocument
  '
  Me.PrintDocument.DocumentName = ""
  Me.PrintDocument.OriginAtMargins = True
  '
  'dlgPrintPreview
  '
  resources.ApplyResources(Me.dlgPrintPreview, "dlgPrintPreview")
  Me.dlgPrintPreview.Document = Me.PrintDocument
  Me.dlgPrintPreview.Name = "dlgPrintPreview"
  '
  'dlgPrint
  '
  Me.dlgPrint.AllowSomePages = True
  Me.dlgPrint.Document = Me.PrintDocument
  Me.dlgPrint.UseEXDialog = True
  '
  'dlgExportDocument
  '
  Me.dlgExportDocument.AddExtension = False
  resources.ApplyResources(Me.dlgExportDocument, "dlgExportDocument")
  '
  'panelMain
  '
  resources.ApplyResources(Me.panelMain, "panelMain")
  Me.panelMain.Name = "panelMain"
  '
  'dlgImportSubtitles
  '
  Me.dlgImportSubtitles.DefaultExt = "srt"
  Me.dlgImportSubtitles.Encoding = CType(resources.GetObject("dlgImportSubtitles.Encoding"), System.Text.Encoding)
  resources.ApplyResources(Me.dlgImportSubtitles, "dlgImportSubtitles")
  Me.dlgImportSubtitles.FileName = ""
  Me.dlgImportSubtitles.ShowReadOnly = True
  '
  'dlgExportSubtitles
  '
  Me.dlgExportSubtitles.DefaultExt = "srt"
  Me.dlgExportSubtitles.Encoding = CType(resources.GetObject("dlgExportSubtitles.Encoding"), System.Text.Encoding)
  resources.ApplyResources(Me.dlgExportSubtitles, "dlgExportSubtitles")
  Me.dlgExportSubtitles.FileName = ""
  '
  'MainForm
  '
  resources.ApplyResources(Me, "$this")
  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
  Me.BackColor = System.Drawing.Color.OldLace
  Me.Controls.Add(Me.panelMain)
  Me.Controls.Add(Me.StatusStrip)
  Me.Controls.Add(Me.MenuStrip)
  Me.KeyPreview = True
  Me.MainMenuStrip = Me.MenuStrip
  Me.Name = "MainForm"
  Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
  Me.MenuStrip.ResumeLayout(False)
  Me.MenuStrip.PerformLayout()
  Me.StatusStrip.ResumeLayout(False)
  Me.StatusStrip.PerformLayout()
  CType(Me.mruVideo, System.ComponentModel.ISupportInitialize).EndInit()
  CType(Me.mruActivity, System.ComponentModel.ISupportInitialize).EndInit()
  CType(Me.mruAudio, System.ComponentModel.ISupportInitialize).EndInit()
  CType(Me.mruSubtitles, System.ComponentModel.ISupportInitialize).EndInit()
  CType(Me.mruDocument, System.ComponentModel.ISupportInitialize).EndInit()
  CType(Me.mruPackedActivity, System.ComponentModel.ISupportInitialize).EndInit()
  Me.ResumeLayout(False)
  Me.PerformLayout()

 End Sub

 Friend WithEvents ActionsImageList As System.Windows.Forms.ImageList
 Friend WithEvents actionsApplication As CDiese.Actions.ActionList
 Friend WithEvents actionShowAbout As CDiese.Actions.Action
 Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
 Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionExit As CDiese.Actions.Action
 Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImportVideo As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImportSubtitles As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImportDocument As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents VideoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents SubtitlesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents DocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents mnuPrintSeparator As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents mnuPageSetup As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionOpenActivityBrowse As CDiese.Actions.Action
 Friend WithEvents FileMenuSeparator3 As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
 Friend WithEvents statusMessage As System.Windows.Forms.ToolStripStatusLabel
 Friend WithEvents BrowseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents BrowseToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents BrowseToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents dlgImportVideo As System.Windows.Forms.OpenFileDialog
 Friend WithEvents mnuOpenActivity As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents BrowseToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mruVideo As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents MruVideoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents MruSubtitlesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents MruDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionImportVideoBrowse As CDiese.Actions.Action
 Friend WithEvents mruActivity As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents MruActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImportAudio As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents BrowseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents MruAudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents dlgImportAudio As System.Windows.Forms.OpenFileDialog
 Friend WithEvents mruAudio As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents actionImportAudioBrowse As CDiese.Actions.Action
 Friend WithEvents actionImportSubtitlesBrowse As CDiese.Actions.Action
 Friend WithEvents actionImportDocumentBrowse As CDiese.Actions.Action
 Friend WithEvents mruSubtitles As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents mruDocument As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents dlgImportSubtitles As LvS.utilities.dialogs.OpenFileDialogWithEncoding
 Friend WithEvents dlgImportDocument As LvS.utilities.dialogs.OpenFileDialogWithEncoding
 Friend WithEvents dlgImportPackedActivity As System.Windows.Forms.OpenFileDialog
 Friend WithEvents mnuImportPackedActivity As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuImportSeparator As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents mruPackedActivity As MostRecentlyUsedHandler.MRUHandler
 Friend WithEvents actionImportPackedActivity As CDiese.Actions.Action
 Friend WithEvents MruPackedActivityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents dlgExportPackedActivity As System.Windows.Forms.SaveFileDialog
 Friend WithEvents actionExportPackedActivity As CDiese.Actions.Action
 Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents dlgPageSetup As System.Windows.Forms.PageSetupDialog
 Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
 Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
 Friend WithEvents actionPageSetup As CDiese.Actions.Action
 Friend WithEvents actionPrintPreview As CDiese.Actions.Action
 Friend WithEvents mnuPrintPreview As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionSaveActivity As CDiese.Actions.Action
 Friend WithEvents mnuSaveActivity As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionPrint As CDiese.Actions.Action
 Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
 Friend WithEvents actionExportSubtitles As CDiese.Actions.Action
 Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents AudioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionExportDocument As CDiese.Actions.Action
 Friend WithEvents dlgExportDocument As System.Windows.Forms.SaveFileDialog
 Friend WithEvents actionNewActivity As CDiese.Actions.Action
 Friend WithEvents mnuNewActivity As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionCloseActivity As CDiese.Actions.Action
 Friend WithEvents mnuCloseActivity As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents panelMain As System.Windows.Forms.Panel
 Friend WithEvents actionAuthoringMode As CDiese.Actions.Action
 Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents mnuAuthoringMode As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionSendFeedback As CDiese.Actions.Action
 Friend WithEvents mnuSendFeedback As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents dlgExportSubtitles As LvS.utilities.dialogs.SaveFileDialogWithEncoding
 Friend WithEvents actionClearMRU As CDiese.Actions.Action
 Friend WithEvents mnuClearMRU As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents actionHelp As CDiese.Actions.Action
 Friend WithEvents mnuShowHelp As System.Windows.Forms.ToolStripMenuItem
 Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
 Friend WithEvents actionPortal As CDiese.Actions.Action
 Friend WithEvents mnuPortal As System.Windows.Forms.ToolStripMenuItem

End Class
