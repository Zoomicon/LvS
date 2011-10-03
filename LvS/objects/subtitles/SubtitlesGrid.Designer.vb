Namespace LvS.objects.subtitles

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class SubtitlesGrid
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
   If disposing AndAlso components IsNot Nothing Then
    components.Dispose()
   End If
   MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
   Me.gridSubtitles = New SourceGrid.Grid
   Me.SuspendLayout()
   '
   'gridSubtitles
   '
   Me.gridSubtitles.Dock = System.Windows.Forms.DockStyle.Fill
   Me.gridSubtitles.FixedColumns = 1
   Me.gridSubtitles.FixedRows = 1
   Me.gridSubtitles.Location = New System.Drawing.Point(0, 0)
   Me.gridSubtitles.Name = "gridSubtitles"
   Me.gridSubtitles.Size = New System.Drawing.Size(556, 440)
   Me.gridSubtitles.StyleGrid = Nothing
   Me.gridSubtitles.TabIndex = 2
   '
   'SubtitlesGrid
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.gridSubtitles)
   Me.Name = "SubtitlesGrid"
   Me.Size = New System.Drawing.Size(556, 440)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gridSubtitles As SourceGrid.Grid


 End Class

End Namespace
