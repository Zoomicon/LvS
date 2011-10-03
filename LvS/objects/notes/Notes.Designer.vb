Namespace LvS.objects.notes

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class Notes
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
   Me.components = New System.ComponentModel.Container
   Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
   Me.rtfNotes = New LvS.objects.rtf.RTFEditor
   Me.gridSubtitleNotes = New SourceGrid.Grid
   Me.SplitContainer1.Panel1.SuspendLayout()
   Me.SplitContainer1.Panel2.SuspendLayout()
   Me.SplitContainer1.SuspendLayout()
   Me.SuspendLayout()
   '
   'SplitContainer1
   '
   Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
   Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
   Me.SplitContainer1.Name = "SplitContainer1"
   Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
   '
   'SplitContainer1.Panel1
   '
   Me.SplitContainer1.Panel1.Controls.Add(Me.rtfNotes)
   '
   'SplitContainer1.Panel2
   '
   Me.SplitContainer1.Panel2.Controls.Add(Me.gridSubtitleNotes)
   Me.SplitContainer1.Size = New System.Drawing.Size(455, 384)
   Me.SplitContainer1.SplitterDistance = 210
   Me.SplitContainer1.TabIndex = 0
   '
   'rtfNotes
   '
   Me.rtfNotes.Dock = System.Windows.Forms.DockStyle.Fill
   Me.rtfNotes.EnableAutoDragDrop = False
   Me.rtfNotes.Location = New System.Drawing.Point(0, 0)
   Me.rtfNotes.Modified = False
   Me.rtfNotes.Name = "rtfNotes"
   Me.rtfNotes.ReadOnly = False
   Me.rtfNotes.SelectionEnd = -1
   Me.rtfNotes.SelectionLength = 0
   Me.rtfNotes.SelectionProtected = False
   Me.rtfNotes.SelectionStart = 0
   Me.rtfNotes.ShowSelectionMargin = False
   Me.rtfNotes.Size = New System.Drawing.Size(455, 210)
   Me.rtfNotes.TabIndex = 0
   Me.rtfNotes.WordWrap = True
   '
   'gridSubtitleNotes
   '
   Me.gridSubtitleNotes.Dock = System.Windows.Forms.DockStyle.Fill
   Me.gridSubtitleNotes.FixedColumns = 1
   Me.gridSubtitleNotes.FixedRows = 1
   Me.gridSubtitleNotes.Location = New System.Drawing.Point(0, 0)
   Me.gridSubtitleNotes.Name = "gridSubtitleNotes"
   Me.gridSubtitleNotes.Size = New System.Drawing.Size(455, 170)
   Me.gridSubtitleNotes.StyleGrid = Nothing
   Me.gridSubtitleNotes.TabIndex = 0
   '
   'Notes
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.SplitContainer1)
   Me.Name = "Notes"
   Me.Size = New System.Drawing.Size(455, 384)
   Me.SplitContainer1.Panel1.ResumeLayout(False)
   Me.SplitContainer1.Panel2.ResumeLayout(False)
   Me.SplitContainer1.ResumeLayout(False)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents rtfNotes As LvS.objects.rtf.RTFEditor
  Friend WithEvents gridSubtitleNotes As SourceGrid.Grid

 End Class

End Namespace
