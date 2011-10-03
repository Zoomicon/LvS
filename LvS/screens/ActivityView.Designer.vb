Namespace LvS.screens

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ActivityView
		Inherits System.Windows.Forms.UserControl

		'UserControl overrides dispose to clean up the component list.
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivityView))
			Me.splitLeftVertically = New System.Windows.Forms.SplitContainer
			Me.viewPlayer = New LvS.objects.players.WMP
			Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
			Me.viewSubtitles = New LvS.objects.subtitles.SubtitlesGrid
			Me.toolstripSubtitles = New System.Windows.Forms.ToolStrip
			Me.btnAddSubtitle = New System.Windows.Forms.ToolStripButton
			Me.btnRemoveSubtitle = New System.Windows.Forms.ToolStripButton
			Me.btnSetSubtitleStart = New System.Windows.Forms.ToolStripButton
			Me.btnSetSubtitleEnd = New System.Windows.Forms.ToolStripButton
			Me.splitRightVertically = New System.Windows.Forms.SplitContainer
			Me.viewDocuments = New LvS.objects.documents.DocumentsView
			Me.imgLogo = New System.Windows.Forms.PictureBox
			Me.tabNotes = New System.Windows.Forms.TabControl
			Me.tabNotesTeacher = New System.Windows.Forms.TabPage
			Me.viewTeacherNotes = New LvS.objects.notes.Notes
			Me.tabNotesStudent = New System.Windows.Forms.TabPage
			Me.viewStudentNotes = New LvS.objects.notes.Notes
			Me.splitHorizontally = New System.Windows.Forms.SplitContainer
			Me.splitLeftVertically.Panel1.SuspendLayout()
			Me.splitLeftVertically.Panel2.SuspendLayout()
			Me.splitLeftVertically.SuspendLayout()
			Me.ToolStripContainer1.ContentPanel.SuspendLayout()
			Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
			Me.ToolStripContainer1.SuspendLayout()
			Me.toolstripSubtitles.SuspendLayout()
			Me.splitRightVertically.Panel1.SuspendLayout()
			Me.splitRightVertically.Panel2.SuspendLayout()
			Me.splitRightVertically.SuspendLayout()
			CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabNotes.SuspendLayout()
			Me.tabNotesTeacher.SuspendLayout()
			Me.tabNotesStudent.SuspendLayout()
			Me.splitHorizontally.Panel1.SuspendLayout()
			Me.splitHorizontally.Panel2.SuspendLayout()
			Me.splitHorizontally.SuspendLayout()
			Me.SuspendLayout()
			'
			'splitLeftVertically
			'
			Me.splitLeftVertically.AccessibleDescription = Nothing
			Me.splitLeftVertically.AccessibleName = Nothing
			resources.ApplyResources(Me.splitLeftVertically, "splitLeftVertically")
			Me.splitLeftVertically.BackColor = System.Drawing.Color.Transparent
			Me.splitLeftVertically.BackgroundImage = Nothing
			Me.splitLeftVertically.Font = Nothing
			Me.splitLeftVertically.Name = "splitLeftVertically"
			'
			'splitLeftVertically.Panel1
			'
			Me.splitLeftVertically.Panel1.AccessibleDescription = Nothing
			Me.splitLeftVertically.Panel1.AccessibleName = Nothing
			resources.ApplyResources(Me.splitLeftVertically.Panel1, "splitLeftVertically.Panel1")
			Me.splitLeftVertically.Panel1.BackgroundImage = Nothing
			Me.splitLeftVertically.Panel1.Controls.Add(Me.viewPlayer)
			Me.splitLeftVertically.Panel1.Font = Nothing
			'
			'splitLeftVertically.Panel2
			'
			Me.splitLeftVertically.Panel2.AccessibleDescription = Nothing
			Me.splitLeftVertically.Panel2.AccessibleName = Nothing
			resources.ApplyResources(Me.splitLeftVertically.Panel2, "splitLeftVertically.Panel2")
			Me.splitLeftVertically.Panel2.BackgroundImage = Nothing
			Me.splitLeftVertically.Panel2.Controls.Add(Me.ToolStripContainer1)
			Me.splitLeftVertically.Panel2.Font = Nothing
			'
			'viewPlayer
			'
			Me.viewPlayer.AccessibleDescription = Nothing
			Me.viewPlayer.AccessibleName = Nothing
			resources.ApplyResources(Me.viewPlayer, "viewPlayer")
			Me.viewPlayer.AudioOn = True
			Me.viewPlayer.AudioVolume = 1
			Me.viewPlayer.BackColor = System.Drawing.Color.Black
			Me.viewPlayer.BackgroundImage = Nothing
			Me.viewPlayer.Font = Nothing
			Me.viewPlayer.Name = "viewPlayer"
			Me.viewPlayer.Paused = True
			Me.viewPlayer.Rate = 0
			Me.viewPlayer.SelectionEndTime = 0
			Me.viewPlayer.SelectionStartTime = 0
			Me.viewPlayer.SpeedControlsVisible = False
			Me.viewPlayer.Subtitle1 = ""
			Me.viewPlayer.Subtitle2 = ""
			Me.viewPlayer.SubtitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
			Me.viewPlayer.SubtitlesOn = True
			Me.viewPlayer.Time = 0
			Me.viewPlayer.VideoOn = True
			'
			'ToolStripContainer1
			'
			Me.ToolStripContainer1.AccessibleDescription = Nothing
			Me.ToolStripContainer1.AccessibleName = Nothing
			resources.ApplyResources(Me.ToolStripContainer1, "ToolStripContainer1")
			'
			'ToolStripContainer1.BottomToolStripPanel
			'
			Me.ToolStripContainer1.BottomToolStripPanel.AccessibleDescription = Nothing
			Me.ToolStripContainer1.BottomToolStripPanel.AccessibleName = Nothing
			Me.ToolStripContainer1.BottomToolStripPanel.BackgroundImage = Nothing
			resources.ApplyResources(Me.ToolStripContainer1.BottomToolStripPanel, "ToolStripContainer1.BottomToolStripPanel")
			Me.ToolStripContainer1.BottomToolStripPanel.Font = Nothing
			Me.ToolStripContainer1.BottomToolStripPanelVisible = False
			'
			'ToolStripContainer1.ContentPanel
			'
			Me.ToolStripContainer1.ContentPanel.AccessibleDescription = Nothing
			Me.ToolStripContainer1.ContentPanel.AccessibleName = Nothing
			resources.ApplyResources(Me.ToolStripContainer1.ContentPanel, "ToolStripContainer1.ContentPanel")
			Me.ToolStripContainer1.ContentPanel.BackgroundImage = Nothing
			Me.ToolStripContainer1.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.viewSubtitles)
			Me.ToolStripContainer1.ContentPanel.Font = Nothing
			Me.ToolStripContainer1.ContentPanel.ForeColor = System.Drawing.SystemColors.ControlText
			Me.ToolStripContainer1.Font = Nothing
			'
			'ToolStripContainer1.LeftToolStripPanel
			'
			Me.ToolStripContainer1.LeftToolStripPanel.AccessibleDescription = Nothing
			Me.ToolStripContainer1.LeftToolStripPanel.AccessibleName = Nothing
			Me.ToolStripContainer1.LeftToolStripPanel.BackgroundImage = Nothing
			resources.ApplyResources(Me.ToolStripContainer1.LeftToolStripPanel, "ToolStripContainer1.LeftToolStripPanel")
			Me.ToolStripContainer1.LeftToolStripPanel.Font = Nothing
			Me.ToolStripContainer1.LeftToolStripPanelVisible = False
			Me.ToolStripContainer1.Name = "ToolStripContainer1"
			'
			'ToolStripContainer1.RightToolStripPanel
			'
			Me.ToolStripContainer1.RightToolStripPanel.AccessibleDescription = Nothing
			Me.ToolStripContainer1.RightToolStripPanel.AccessibleName = Nothing
			Me.ToolStripContainer1.RightToolStripPanel.BackgroundImage = Nothing
			resources.ApplyResources(Me.ToolStripContainer1.RightToolStripPanel, "ToolStripContainer1.RightToolStripPanel")
			Me.ToolStripContainer1.RightToolStripPanel.Font = Nothing
			Me.ToolStripContainer1.RightToolStripPanelVisible = False
			'
			'ToolStripContainer1.TopToolStripPanel
			'
			Me.ToolStripContainer1.TopToolStripPanel.AccessibleDescription = Nothing
			Me.ToolStripContainer1.TopToolStripPanel.AccessibleName = Nothing
			Me.ToolStripContainer1.TopToolStripPanel.BackgroundImage = Nothing
			resources.ApplyResources(Me.ToolStripContainer1.TopToolStripPanel, "ToolStripContainer1.TopToolStripPanel")
			Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolstripSubtitles)
			Me.ToolStripContainer1.TopToolStripPanel.Font = Nothing
			'
			'viewSubtitles
			'
			Me.viewSubtitles.AccessibleDescription = Nothing
			Me.viewSubtitles.AccessibleName = Nothing
			resources.ApplyResources(Me.viewSubtitles, "viewSubtitles")
			Me.viewSubtitles.BackgroundImage = Nothing
			Me.viewSubtitles.ColumnEndTimeVisible = False
			Me.viewSubtitles.Encoding = Nothing
			Me.viewSubtitles.EndTime = 0
			Me.viewSubtitles.FocusedColumn = LvS.models.subtitles.ISubtitlesGrid.Columns.colNone
			Me.viewSubtitles.Font = Nothing
			Me.viewSubtitles.Name = "viewSubtitles"
			Me.viewSubtitles.StartTime = 0
			Me.viewSubtitles.Time = 0
			'
			'toolstripSubtitles
			'
			Me.toolstripSubtitles.AccessibleDescription = Nothing
			Me.toolstripSubtitles.AccessibleName = Nothing
			Me.toolstripSubtitles.AllowItemReorder = True
			resources.ApplyResources(Me.toolstripSubtitles, "toolstripSubtitles")
			Me.toolstripSubtitles.BackgroundImage = Nothing
			Me.toolstripSubtitles.Font = Nothing
			Me.toolstripSubtitles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddSubtitle, Me.btnRemoveSubtitle, Me.btnSetSubtitleStart, Me.btnSetSubtitleEnd})
			Me.toolstripSubtitles.Name = "toolstripSubtitles"
			Me.toolstripSubtitles.Stretch = True
			Me.toolstripSubtitles.TabStop = True
			'
			'btnAddSubtitle
			'
			Me.btnAddSubtitle.AccessibleDescription = Nothing
			Me.btnAddSubtitle.AccessibleName = Nothing
			resources.ApplyResources(Me.btnAddSubtitle, "btnAddSubtitle")
			Me.btnAddSubtitle.BackgroundImage = Nothing
			Me.btnAddSubtitle.Image = Global.My.Resources.Resources.comment_new
			Me.btnAddSubtitle.Name = "btnAddSubtitle"
			'
			'btnRemoveSubtitle
			'
			Me.btnRemoveSubtitle.AccessibleDescription = Nothing
			Me.btnRemoveSubtitle.AccessibleName = Nothing
			resources.ApplyResources(Me.btnRemoveSubtitle, "btnRemoveSubtitle")
			Me.btnRemoveSubtitle.BackgroundImage = Nothing
			Me.btnRemoveSubtitle.Image = Global.My.Resources.Resources.comment_delete
			Me.btnRemoveSubtitle.Name = "btnRemoveSubtitle"
			'
			'btnSetSubtitleStart
			'
			Me.btnSetSubtitleStart.AccessibleDescription = Nothing
			Me.btnSetSubtitleStart.AccessibleName = Nothing
			resources.ApplyResources(Me.btnSetSubtitleStart, "btnSetSubtitleStart")
			Me.btnSetSubtitleStart.BackgroundImage = Nothing
			Me.btnSetSubtitleStart.Image = Global.My.Resources.Resources.comment_blue
			Me.btnSetSubtitleStart.Name = "btnSetSubtitleStart"
			'
			'btnSetSubtitleEnd
			'
			Me.btnSetSubtitleEnd.AccessibleDescription = Nothing
			Me.btnSetSubtitleEnd.AccessibleName = Nothing
			resources.ApplyResources(Me.btnSetSubtitleEnd, "btnSetSubtitleEnd")
			Me.btnSetSubtitleEnd.BackgroundImage = Nothing
			Me.btnSetSubtitleEnd.Image = Global.My.Resources.Resources.comment_edit
			Me.btnSetSubtitleEnd.Name = "btnSetSubtitleEnd"
			'
			'splitRightVertically
			'
			Me.splitRightVertically.AccessibleDescription = Nothing
			Me.splitRightVertically.AccessibleName = Nothing
			resources.ApplyResources(Me.splitRightVertically, "splitRightVertically")
			Me.splitRightVertically.BackgroundImage = Nothing
			Me.splitRightVertically.Font = Nothing
			Me.splitRightVertically.Name = "splitRightVertically"
			'
			'splitRightVertically.Panel1
			'
			Me.splitRightVertically.Panel1.AccessibleDescription = Nothing
			Me.splitRightVertically.Panel1.AccessibleName = Nothing
			resources.ApplyResources(Me.splitRightVertically.Panel1, "splitRightVertically.Panel1")
			Me.splitRightVertically.Panel1.BackgroundImage = Nothing
			Me.splitRightVertically.Panel1.Controls.Add(Me.viewDocuments)
			Me.splitRightVertically.Panel1.Controls.Add(Me.imgLogo)
			Me.splitRightVertically.Panel1.Font = Nothing
			'
			'splitRightVertically.Panel2
			'
			Me.splitRightVertically.Panel2.AccessibleDescription = Nothing
			Me.splitRightVertically.Panel2.AccessibleName = Nothing
			resources.ApplyResources(Me.splitRightVertically.Panel2, "splitRightVertically.Panel2")
			Me.splitRightVertically.Panel2.BackgroundImage = Nothing
			Me.splitRightVertically.Panel2.Controls.Add(Me.tabNotes)
			Me.splitRightVertically.Panel2.Font = Nothing
			'
			'viewDocuments
			'
			Me.viewDocuments.AccessibleDescription = Nothing
			Me.viewDocuments.AccessibleName = Nothing
			resources.ApplyResources(Me.viewDocuments, "viewDocuments")
			Me.viewDocuments.AuthoringMode = False
			Me.viewDocuments.BackColor = System.Drawing.Color.Transparent
			Me.viewDocuments.BackgroundImage = Nothing
			Me.viewDocuments.Font = Nothing
			Me.viewDocuments.Modified = False
			Me.viewDocuments.Name = "viewDocuments"
			Me.viewDocuments.SelectedIndex = -1
			'
			'imgLogo
			'
			Me.imgLogo.AccessibleDescription = Nothing
			Me.imgLogo.AccessibleName = Nothing
			resources.ApplyResources(Me.imgLogo, "imgLogo")
			Me.imgLogo.BackgroundImage = Nothing
			Me.imgLogo.Font = Nothing
			Me.imgLogo.Image = Global.My.Resources.Resources.logonew01_800x600_outline
			Me.imgLogo.ImageLocation = Nothing
			Me.imgLogo.InitialImage = Nothing
			Me.imgLogo.Name = "imgLogo"
			Me.imgLogo.TabStop = False
			'
			'tabNotes
			'
			Me.tabNotes.AccessibleDescription = Nothing
			Me.tabNotes.AccessibleName = Nothing
			resources.ApplyResources(Me.tabNotes, "tabNotes")
			Me.tabNotes.BackgroundImage = Nothing
			Me.tabNotes.Controls.Add(Me.tabNotesTeacher)
			Me.tabNotes.Controls.Add(Me.tabNotesStudent)
			Me.tabNotes.Font = Nothing
			Me.tabNotes.HotTrack = True
			Me.tabNotes.Name = "tabNotes"
			Me.tabNotes.SelectedIndex = 0
			'
			'tabNotesTeacher
			'
			Me.tabNotesTeacher.AccessibleDescription = Nothing
			Me.tabNotesTeacher.AccessibleName = Nothing
			resources.ApplyResources(Me.tabNotesTeacher, "tabNotesTeacher")
			Me.tabNotesTeacher.BackgroundImage = Nothing
			Me.tabNotesTeacher.Controls.Add(Me.viewTeacherNotes)
			Me.tabNotesTeacher.Font = Nothing
			Me.tabNotesTeacher.Name = "tabNotesTeacher"
			Me.tabNotesTeacher.UseVisualStyleBackColor = True
			'
			'viewTeacherNotes
			'
			Me.viewTeacherNotes.AccessibleDescription = Nothing
			Me.viewTeacherNotes.AccessibleName = Nothing
			resources.ApplyResources(Me.viewTeacherNotes, "viewTeacherNotes")
			Me.viewTeacherNotes.BackgroundImage = Nothing
			Me.viewTeacherNotes.Font = Nothing
			Me.viewTeacherNotes.Name = "viewTeacherNotes"
			Me.viewTeacherNotes.TeacherNotes = True
			'
			'tabNotesStudent
			'
			Me.tabNotesStudent.AccessibleDescription = Nothing
			Me.tabNotesStudent.AccessibleName = Nothing
			resources.ApplyResources(Me.tabNotesStudent, "tabNotesStudent")
			Me.tabNotesStudent.BackgroundImage = Nothing
			Me.tabNotesStudent.Controls.Add(Me.viewStudentNotes)
			Me.tabNotesStudent.Font = Nothing
			Me.tabNotesStudent.Name = "tabNotesStudent"
			Me.tabNotesStudent.UseVisualStyleBackColor = True
			'
			'viewStudentNotes
			'
			Me.viewStudentNotes.AccessibleDescription = Nothing
			Me.viewStudentNotes.AccessibleName = Nothing
			resources.ApplyResources(Me.viewStudentNotes, "viewStudentNotes")
			Me.viewStudentNotes.BackgroundImage = Nothing
			Me.viewStudentNotes.Font = Nothing
			Me.viewStudentNotes.Name = "viewStudentNotes"
			'
			'splitHorizontally
			'
			Me.splitHorizontally.AccessibleDescription = Nothing
			Me.splitHorizontally.AccessibleName = Nothing
			resources.ApplyResources(Me.splitHorizontally, "splitHorizontally")
			Me.splitHorizontally.BackColor = System.Drawing.Color.Transparent
			Me.splitHorizontally.BackgroundImage = Nothing
			Me.splitHorizontally.Font = Nothing
			Me.splitHorizontally.Name = "splitHorizontally"
			'
			'splitHorizontally.Panel1
			'
			Me.splitHorizontally.Panel1.AccessibleDescription = Nothing
			Me.splitHorizontally.Panel1.AccessibleName = Nothing
			resources.ApplyResources(Me.splitHorizontally.Panel1, "splitHorizontally.Panel1")
			Me.splitHorizontally.Panel1.BackgroundImage = Nothing
			Me.splitHorizontally.Panel1.Controls.Add(Me.splitLeftVertically)
			Me.splitHorizontally.Panel1.Font = Nothing
			'
			'splitHorizontally.Panel2
			'
			Me.splitHorizontally.Panel2.AccessibleDescription = Nothing
			Me.splitHorizontally.Panel2.AccessibleName = Nothing
			resources.ApplyResources(Me.splitHorizontally.Panel2, "splitHorizontally.Panel2")
			Me.splitHorizontally.Panel2.BackColor = System.Drawing.Color.Transparent
			Me.splitHorizontally.Panel2.BackgroundImage = Nothing
			Me.splitHorizontally.Panel2.Controls.Add(Me.splitRightVertically)
			Me.splitHorizontally.Panel2.Font = Nothing
			'
			'ActivityView
			'
			Me.AccessibleDescription = Nothing
			Me.AccessibleName = Nothing
			resources.ApplyResources(Me, "$this")
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.Transparent
			Me.BackgroundImage = Nothing
			Me.Controls.Add(Me.splitHorizontally)
			Me.Font = Nothing
			Me.Name = "ActivityView"
			Me.splitLeftVertically.Panel1.ResumeLayout(False)
			Me.splitLeftVertically.Panel2.ResumeLayout(False)
			Me.splitLeftVertically.ResumeLayout(False)
			Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
			Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
			Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
			Me.ToolStripContainer1.ResumeLayout(False)
			Me.ToolStripContainer1.PerformLayout()
			Me.toolstripSubtitles.ResumeLayout(False)
			Me.toolstripSubtitles.PerformLayout()
			Me.splitRightVertically.Panel1.ResumeLayout(False)
			Me.splitRightVertically.Panel2.ResumeLayout(False)
			Me.splitRightVertically.ResumeLayout(False)
			CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabNotes.ResumeLayout(False)
			Me.tabNotesTeacher.ResumeLayout(False)
			Me.tabNotesStudent.ResumeLayout(False)
			Me.splitHorizontally.Panel1.ResumeLayout(False)
			Me.splitHorizontally.Panel2.ResumeLayout(False)
			Me.splitHorizontally.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents viewPlayer As LvS.objects.players.WMP
		Friend WithEvents splitHorizontally As System.Windows.Forms.SplitContainer
		Friend WithEvents splitLeftVertically As System.Windows.Forms.SplitContainer
		Friend WithEvents splitRightVertically As System.Windows.Forms.SplitContainer
		Friend WithEvents tabNotes As System.Windows.Forms.TabControl
		Friend WithEvents tabNotesTeacher As System.Windows.Forms.TabPage
		Friend WithEvents tabNotesStudent As System.Windows.Forms.TabPage
		Friend WithEvents viewTeacherNotes As LvS.objects.notes.Notes
		Friend WithEvents viewStudentNotes As LvS.objects.notes.Notes
		Friend WithEvents viewDocuments As LvS.objects.documents.DocumentsView
		Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
		Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
		Friend WithEvents viewSubtitles As LvS.objects.subtitles.SubtitlesGrid
		Friend WithEvents toolstripSubtitles As System.Windows.Forms.ToolStrip
		Friend WithEvents btnAddSubtitle As System.Windows.Forms.ToolStripButton
		Friend WithEvents btnSetSubtitleEnd As System.Windows.Forms.ToolStripButton
		Friend WithEvents btnRemoveSubtitle As System.Windows.Forms.ToolStripButton
		Friend WithEvents btnSetSubtitleStart As System.Windows.Forms.ToolStripButton

	End Class

End Namespace
