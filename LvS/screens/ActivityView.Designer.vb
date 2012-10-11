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
      Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
      Me.viewSubtitles = New LvS.objects.subtitles.SubtitlesGrid()
      Me.toolstripSubtitles = New System.Windows.Forms.ToolStrip()
      Me.btnAddSubtitle = New System.Windows.Forms.ToolStripButton()
      Me.btnRemoveSubtitle = New System.Windows.Forms.ToolStripButton()
      Me.btnSetSubtitleStart = New System.Windows.Forms.ToolStripButton()
      Me.btnSetSubtitleEnd = New System.Windows.Forms.ToolStripButton()
      Me.splitLeftVertically = New System.Windows.Forms.SplitContainer()
      Me.viewPlayer = New LvS.objects.players.WMP()
      Me.splitHorizontally = New System.Windows.Forms.SplitContainer()
      Me.splitRightVertically = New System.Windows.Forms.SplitContainer()
      Me.viewDocuments = New LvS.objects.documents.DocumentsView()
      Me.imgLogo = New System.Windows.Forms.PictureBox()
      Me.tabNotes = New System.Windows.Forms.TabControl()
      Me.tabNotesTeacher = New System.Windows.Forms.TabPage()
      Me.viewTeacherNotes = New LvS.objects.notes.Notes()
      Me.tabNotesStudent = New System.Windows.Forms.TabPage()
      Me.viewStudentNotes = New LvS.objects.notes.Notes()
      Me.ToolStripContainer1.ContentPanel.SuspendLayout()
      Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
      Me.ToolStripContainer1.SuspendLayout()
      Me.toolstripSubtitles.SuspendLayout()
      CType(Me.splitLeftVertically, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.splitLeftVertically.Panel1.SuspendLayout()
      Me.splitLeftVertically.Panel2.SuspendLayout()
      Me.splitLeftVertically.SuspendLayout()
      CType(Me.splitHorizontally, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.splitHorizontally.Panel1.SuspendLayout()
      Me.splitHorizontally.Panel2.SuspendLayout()
      Me.splitHorizontally.SuspendLayout()
      CType(Me.splitRightVertically, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.splitRightVertically.Panel1.SuspendLayout()
      Me.splitRightVertically.Panel2.SuspendLayout()
      Me.splitRightVertically.SuspendLayout()
      CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabNotes.SuspendLayout()
      Me.tabNotesTeacher.SuspendLayout()
      Me.tabNotesStudent.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolStripContainer1
      '
      Me.ToolStripContainer1.BottomToolStripPanelVisible = False
      '
      'ToolStripContainer1.ContentPanel
      '
      Me.ToolStripContainer1.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.viewSubtitles)
      Me.ToolStripContainer1.ContentPanel.ForeColor = System.Drawing.SystemColors.ControlText
      resources.ApplyResources(Me.ToolStripContainer1.ContentPanel, "ToolStripContainer1.ContentPanel")
      resources.ApplyResources(Me.ToolStripContainer1, "ToolStripContainer1")
      Me.ToolStripContainer1.LeftToolStripPanelVisible = False
      Me.ToolStripContainer1.Name = "ToolStripContainer1"
      Me.ToolStripContainer1.RightToolStripPanelVisible = False
      '
      'ToolStripContainer1.TopToolStripPanel
      '
      Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.toolstripSubtitles)
      '
      'viewSubtitles
      '
      Me.viewSubtitles.BackColor = System.Drawing.Color.White
      Me.viewSubtitles.ColumnEndTimeVisible = False
      resources.ApplyResources(Me.viewSubtitles, "viewSubtitles")
      Me.viewSubtitles.Encoding = Nothing
      Me.viewSubtitles.EndTime = 0.0R
      Me.viewSubtitles.FocusedColumn = LvS.models.subtitles.ISubtitlesGrid.Columns.colNone
      Me.viewSubtitles.Name = "viewSubtitles"
      Me.viewSubtitles.StartTime = 0.0R
      Me.viewSubtitles.Time = 0.0R
      '
      'toolstripSubtitles
      '
      Me.toolstripSubtitles.AllowItemReorder = True
      resources.ApplyResources(Me.toolstripSubtitles, "toolstripSubtitles")
      Me.toolstripSubtitles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddSubtitle, Me.btnRemoveSubtitle, Me.btnSetSubtitleStart, Me.btnSetSubtitleEnd})
      Me.toolstripSubtitles.Name = "toolstripSubtitles"
      Me.toolstripSubtitles.Stretch = True
      Me.toolstripSubtitles.TabStop = True
      '
      'btnAddSubtitle
      '
      Me.btnAddSubtitle.Image = Global.My.Resources.Resources.comment_new
      resources.ApplyResources(Me.btnAddSubtitle, "btnAddSubtitle")
      Me.btnAddSubtitle.Name = "btnAddSubtitle"
      '
      'btnRemoveSubtitle
      '
      Me.btnRemoveSubtitle.Image = Global.My.Resources.Resources.comment_delete
      resources.ApplyResources(Me.btnRemoveSubtitle, "btnRemoveSubtitle")
      Me.btnRemoveSubtitle.Name = "btnRemoveSubtitle"
      '
      'btnSetSubtitleStart
      '
      Me.btnSetSubtitleStart.Image = Global.My.Resources.Resources.comment_blue
      resources.ApplyResources(Me.btnSetSubtitleStart, "btnSetSubtitleStart")
      Me.btnSetSubtitleStart.Name = "btnSetSubtitleStart"
      '
      'btnSetSubtitleEnd
      '
      Me.btnSetSubtitleEnd.Image = Global.My.Resources.Resources.comment_edit
      resources.ApplyResources(Me.btnSetSubtitleEnd, "btnSetSubtitleEnd")
      Me.btnSetSubtitleEnd.Name = "btnSetSubtitleEnd"
      '
      'splitLeftVertically
      '
      Me.splitLeftVertically.BackColor = System.Drawing.Color.Transparent
      resources.ApplyResources(Me.splitLeftVertically, "splitLeftVertically")
      Me.splitLeftVertically.Name = "splitLeftVertically"
      '
      'splitLeftVertically.Panel1
      '
      Me.splitLeftVertically.Panel1.Controls.Add(Me.viewPlayer)
      '
      'splitLeftVertically.Panel2
      '
      Me.splitLeftVertically.Panel2.Controls.Add(Me.ToolStripContainer1)
      '
      'viewPlayer
      '
      Me.viewPlayer.AudioOn = True
      Me.viewPlayer.AudioVolume = 1.0R
      Me.viewPlayer.BackColor = System.Drawing.Color.Black
      Me.viewPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me.viewPlayer, "viewPlayer")
      Me.viewPlayer.FullScreen = False
      Me.viewPlayer.Name = "viewPlayer"
      Me.viewPlayer.Paused = True
      Me.viewPlayer.Rate = 0.0R
      Me.viewPlayer.SelectionEndTime = 0.0R
      Me.viewPlayer.SelectionStartTime = 0.0R
      Me.viewPlayer.SpeedControlsVisible = False
      Me.viewPlayer.Subtitle1 = ""
      Me.viewPlayer.Subtitle2 = ""
      Me.viewPlayer.SubtitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
      Me.viewPlayer.SubtitlesOn = True
      Me.viewPlayer.Time = 0.0R
      Me.viewPlayer.VideoOn = True
      '
      'splitHorizontally
      '
      resources.ApplyResources(Me.splitHorizontally, "splitHorizontally")
      Me.splitHorizontally.Name = "splitHorizontally"
      '
      'splitHorizontally.Panel1
      '
      Me.splitHorizontally.Panel1.Controls.Add(Me.splitLeftVertically)
      '
      'splitHorizontally.Panel2
      '
      Me.splitHorizontally.Panel2.BackColor = System.Drawing.Color.Transparent
      Me.splitHorizontally.Panel2.Controls.Add(Me.splitRightVertically)
      '
      'splitRightVertically
      '
      resources.ApplyResources(Me.splitRightVertically, "splitRightVertically")
      Me.splitRightVertically.Name = "splitRightVertically"
      '
      'splitRightVertically.Panel1
      '
      Me.splitRightVertically.Panel1.Controls.Add(Me.viewDocuments)
      Me.splitRightVertically.Panel1.Controls.Add(Me.imgLogo)
      '
      'splitRightVertically.Panel2
      '
      Me.splitRightVertically.Panel2.Controls.Add(Me.tabNotes)
      '
      'viewDocuments
      '
      Me.viewDocuments.AuthoringMode = False
      Me.viewDocuments.BackColor = System.Drawing.Color.Transparent
      Me.viewDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me.viewDocuments, "viewDocuments")
      Me.viewDocuments.Modified = False
      Me.viewDocuments.Name = "viewDocuments"
      Me.viewDocuments.SelectedIndex = -1
      '
      'imgLogo
      '
      Me.imgLogo.BackColor = System.Drawing.Color.OldLace
      resources.ApplyResources(Me.imgLogo, "imgLogo")
      Me.imgLogo.Image = Global.My.Resources.Resources.logonew01_800x600_outline
      Me.imgLogo.Name = "imgLogo"
      Me.imgLogo.TabStop = False
      '
      'tabNotes
      '
      Me.tabNotes.Controls.Add(Me.tabNotesTeacher)
      Me.tabNotes.Controls.Add(Me.tabNotesStudent)
      resources.ApplyResources(Me.tabNotes, "tabNotes")
      Me.tabNotes.HotTrack = True
      Me.tabNotes.Name = "tabNotes"
      Me.tabNotes.SelectedIndex = 0
      '
      'tabNotesTeacher
      '
      Me.tabNotesTeacher.Controls.Add(Me.viewTeacherNotes)
      resources.ApplyResources(Me.tabNotesTeacher, "tabNotesTeacher")
      Me.tabNotesTeacher.Name = "tabNotesTeacher"
      Me.tabNotesTeacher.UseVisualStyleBackColor = True
      '
      'viewTeacherNotes
      '
      resources.ApplyResources(Me.viewTeacherNotes, "viewTeacherNotes")
      Me.viewTeacherNotes.Name = "viewTeacherNotes"
      Me.viewTeacherNotes.TeacherNotes = True
      '
      'tabNotesStudent
      '
      Me.tabNotesStudent.Controls.Add(Me.viewStudentNotes)
      resources.ApplyResources(Me.tabNotesStudent, "tabNotesStudent")
      Me.tabNotesStudent.Name = "tabNotesStudent"
      Me.tabNotesStudent.UseVisualStyleBackColor = True
      '
      'viewStudentNotes
      '
      resources.ApplyResources(Me.viewStudentNotes, "viewStudentNotes")
      Me.viewStudentNotes.Name = "viewStudentNotes"
      '
      'ActivityView
      '
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.splitHorizontally)
      Me.Name = "ActivityView"
      Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
      Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
      Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
      Me.ToolStripContainer1.ResumeLayout(False)
      Me.ToolStripContainer1.PerformLayout()
      Me.toolstripSubtitles.ResumeLayout(False)
      Me.toolstripSubtitles.PerformLayout()
      Me.splitLeftVertically.Panel1.ResumeLayout(False)
      Me.splitLeftVertically.Panel2.ResumeLayout(False)
      CType(Me.splitLeftVertically, System.ComponentModel.ISupportInitialize).EndInit()
      Me.splitLeftVertically.ResumeLayout(False)
      Me.splitHorizontally.Panel1.ResumeLayout(False)
      Me.splitHorizontally.Panel2.ResumeLayout(False)
      CType(Me.splitHorizontally, System.ComponentModel.ISupportInitialize).EndInit()
      Me.splitHorizontally.ResumeLayout(False)
      Me.splitRightVertically.Panel1.ResumeLayout(False)
      Me.splitRightVertically.Panel2.ResumeLayout(False)
      CType(Me.splitRightVertically, System.ComponentModel.ISupportInitialize).EndInit()
      Me.splitRightVertically.ResumeLayout(False)
      CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabNotes.ResumeLayout(False)
      Me.tabNotesTeacher.ResumeLayout(False)
      Me.tabNotesStudent.ResumeLayout(False)
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
