Namespace LvS.objects.documents

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class RTFDocumentView
  Inherits LvS.objects.documents.BaseDocumentView

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
   Me.rtfText = New LvS.objects.rtf.RTFEditor
   Me.SuspendLayout()
   '
   'rtfText
   '
   Me.rtfText.Dock = System.Windows.Forms.DockStyle.Fill
   Me.rtfText.EnableAutoDragDrop = True
   Me.rtfText.Location = New System.Drawing.Point(0, 0)
   Me.rtfText.Modified = False
   Me.rtfText.Name = "rtfText"
   Me.rtfText.ReadOnly = False
   Me.rtfText.SelectionEnd = -1
   Me.rtfText.SelectionLength = 0
   Me.rtfText.SelectionProtected = False
   Me.rtfText.SelectionStart = 0
   Me.rtfText.ShowSelectionMargin = True
   Me.rtfText.Size = New System.Drawing.Size(617, 314)
   Me.rtfText.TabIndex = 0
   Me.rtfText.WordWrap = False
   '
   'RTFDocumentView
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.Controls.Add(Me.rtfText)
   Me.Name = "RTFDocumentView"
   Me.Size = New System.Drawing.Size(617, 314)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents rtfText As LvS.objects.rtf.RTFEditor

 End Class

End Namespace
