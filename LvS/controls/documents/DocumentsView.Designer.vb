Namespace LvS.objects.documents

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class DocumentsView
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
   Me.tabDocuments = New System.Windows.Forms.TabControl
   Me.SuspendLayout()
   '
   'tabDocuments
   '
   Me.tabDocuments.AllowDrop = True
   Me.tabDocuments.Dock = System.Windows.Forms.DockStyle.Fill
   Me.tabDocuments.HotTrack = True
   Me.tabDocuments.Location = New System.Drawing.Point(0, 0)
   Me.tabDocuments.Name = "tabDocuments"
   Me.tabDocuments.SelectedIndex = 0
   Me.tabDocuments.ShowToolTips = True
   Me.tabDocuments.Size = New System.Drawing.Size(417, 452)
   Me.tabDocuments.TabIndex = 0
   '
   'DocumentsView
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.BackColor = System.Drawing.Color.Transparent
   Me.Controls.Add(Me.tabDocuments)
   Me.Name = "DocumentsView"
   Me.Size = New System.Drawing.Size(417, 452)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tabDocuments As System.Windows.Forms.TabControl

 End Class

End Namespace
