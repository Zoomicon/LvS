Namespace LvS.objects.players

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class WMP
  Inherits LvS.objects.players.BasePlayer

  'Form overrides dispose to clean up the component list.
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
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WMP))
   Me.playerWMP = New AxWMPLib.AxWindowsMediaPlayer
   CType(Me.playerWMP, System.ComponentModel.ISupportInitialize).BeginInit()
   Me.SuspendLayout()
   '
   'playerWMP
   '
   Me.playerWMP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
   Me.playerWMP.Enabled = True
   Me.playerWMP.Location = New System.Drawing.Point(0, 1)
   Me.playerWMP.Name = "playerWMP"
   Me.playerWMP.OcxState = CType(resources.GetObject("playerWMP.OcxState"), System.Windows.Forms.AxHost.State)
   Me.playerWMP.Size = New System.Drawing.Size(534, 358)
   Me.playerWMP.TabIndex = 1
   '
   'WMP
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.Controls.Add(Me.playerWMP)
   Me.Name = "WMP"
   Me.Subtitle1 = ""
   Me.Subtitle2 = ""
   Me.Controls.SetChildIndex(Me.playerWMP, 0)
   CType(Me.playerWMP, System.ComponentModel.ISupportInitialize).EndInit()
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents playerWMP As AxWMPLib.AxWindowsMediaPlayer

 End Class

End Namespace
