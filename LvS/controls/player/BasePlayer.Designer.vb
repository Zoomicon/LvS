Namespace LvS.objects.players

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class BasePlayer
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
   Me.components = New System.ComponentModel.Container
   Me.tableSubtitles = New System.Windows.Forms.TableLayoutPanel
   Me.txtSubtitle1 = New System.Windows.Forms.TextBox
   Me.txtSubtitle2 = New System.Windows.Forms.TextBox
   Me.timerPlay = New System.Windows.Forms.Timer(Me.components)
   Me.ControllerBar = New LvS.objects.controllers.Controller
   Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
   Me.tableSubtitles.SuspendLayout()
   Me.SuspendLayout()
   '
   'tableSubtitles
   '
   Me.tableSubtitles.BackColor = System.Drawing.Color.Transparent
   Me.tableSubtitles.ColumnCount = 1
   Me.tableSubtitles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
   Me.tableSubtitles.Controls.Add(Me.txtSubtitle1, 0, 0)
   Me.tableSubtitles.Controls.Add(Me.txtSubtitle2, 0, 1)
   Me.tableSubtitles.Dock = System.Windows.Forms.DockStyle.Bottom
   Me.tableSubtitles.Location = New System.Drawing.Point(0, 336)
   Me.tableSubtitles.Name = "tableSubtitles"
   Me.tableSubtitles.RowCount = 2
   Me.tableSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
   Me.tableSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
   Me.tableSubtitles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
   Me.tableSubtitles.Size = New System.Drawing.Size(534, 49)
   Me.tableSubtitles.TabIndex = 0
   '
   'txtSubtitle1
   '
   Me.txtSubtitle1.BackColor = System.Drawing.Color.Black
   Me.txtSubtitle1.BorderStyle = System.Windows.Forms.BorderStyle.None
   Me.txtSubtitle1.Dock = System.Windows.Forms.DockStyle.Bottom
   Me.txtSubtitle1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
   Me.txtSubtitle1.ForeColor = System.Drawing.Color.White
   Me.txtSubtitle1.Location = New System.Drawing.Point(3, 3)
   Me.txtSubtitle1.Name = "txtSubtitle1"
   Me.txtSubtitle1.Size = New System.Drawing.Size(528, 20)
   Me.txtSubtitle1.TabIndex = 0
   Me.txtSubtitle1.Text = "Subtitle1"
   Me.txtSubtitle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
   '
   'txtSubtitle2
   '
   Me.txtSubtitle2.BackColor = System.Drawing.Color.Black
   Me.txtSubtitle2.BorderStyle = System.Windows.Forms.BorderStyle.None
   Me.txtSubtitle2.Dock = System.Windows.Forms.DockStyle.Top
   Me.txtSubtitle2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
   Me.txtSubtitle2.ForeColor = System.Drawing.Color.White
   Me.txtSubtitle2.Location = New System.Drawing.Point(3, 27)
   Me.txtSubtitle2.Name = "txtSubtitle2"
   Me.txtSubtitle2.Size = New System.Drawing.Size(528, 20)
   Me.txtSubtitle2.TabIndex = 1
   Me.txtSubtitle2.Text = "Subtitle2"
   Me.txtSubtitle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
   '
   'timerPlay
   '
   Me.timerPlay.Interval = 10
   '
   'ControllerBar
   '
   Me.ControllerBar.BackColor = System.Drawing.SystemColors.Control
   Me.ControllerBar.Dock = System.Windows.Forms.DockStyle.Bottom
   Me.ControllerBar.Duration = 0
   Me.ControllerBar.Location = New System.Drawing.Point(0, 385)
   Me.ControllerBar.Name = "ControllerBar"
   Me.ControllerBar.Player = Nothing
   Me.ControllerBar.SelectionEndTime = 0
   Me.ControllerBar.SelectionStartTime = 0
   Me.ControllerBar.Size = New System.Drawing.Size(534, 76)
   Me.ControllerBar.TabIndex = 0
   Me.ControllerBar.Time = 0
   '
   'ToolTips
   '
   Me.ToolTips.Active = False
   Me.ToolTips.IsBalloon = True
   '
   'BasePlayer
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.BackColor = System.Drawing.Color.Black
   Me.Controls.Add(Me.tableSubtitles)
   Me.Controls.Add(Me.ControllerBar)
   Me.Name = "BasePlayer"
   Me.Size = New System.Drawing.Size(534, 461)
   Me.tableSubtitles.ResumeLayout(False)
   Me.tableSubtitles.PerformLayout()
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tableSubtitles As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents txtSubtitle1 As System.Windows.Forms.TextBox
  Friend WithEvents txtSubtitle2 As System.Windows.Forms.TextBox
  Protected Friend WithEvents timerPlay As System.Windows.Forms.Timer
  Friend WithEvents ControllerBar As LvS.objects.controllers.Controller
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

 End Class

End Namespace
