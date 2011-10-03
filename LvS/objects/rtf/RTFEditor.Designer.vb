Namespace LvS.objects.rtf

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class RTFEditor
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
   Me.Toolstrip = New LvS.objects.rtf.RTFToolStrip(Me.components)
   Me.rtfText = New LvS.objects.rtf.RichTextBoxEx
   Me.SuspendLayout()
   '
   'Toolstrip
   '
   Me.Toolstrip.AllowItemReorder = True
   Me.Toolstrip.Location = New System.Drawing.Point(0, 0)
   Me.Toolstrip.Name = "Toolstrip"
   Me.Toolstrip.RTFTextBox = Me.rtfText
   Me.Toolstrip.Size = New System.Drawing.Size(356, 25)
   Me.Toolstrip.TabIndex = 0
   Me.Toolstrip.Text = "RtfToolStrip1"
   '
   'rtfText
   '
   Me.rtfText.Dock = System.Windows.Forms.DockStyle.Fill
   Me.rtfText.HideSelection = False
   Me.rtfText.Location = New System.Drawing.Point(0, 25)
   Me.rtfText.Name = "rtfText"
   Me.rtfText.SelectionEnd = -1
   Me.rtfText.Size = New System.Drawing.Size(356, 175)
   Me.rtfText.TabIndex = 1
   Me.rtfText.Text = ""
   '
   'RTFEditor
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.rtfText)
   Me.Controls.Add(Me.Toolstrip)
   Me.Name = "RTFEditor"
   Me.Size = New System.Drawing.Size(356, 200)
   Me.ResumeLayout(False)
   Me.PerformLayout()

  End Sub
  Friend WithEvents Toolstrip As RTFToolStrip
  Friend WithEvents rtfText As LvS.objects.rtf.RichTextBoxEx

 End Class

End Namespace
