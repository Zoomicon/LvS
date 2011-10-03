Namespace LvS.objects.players

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class RealPlayer
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
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RealPlayer))
   Me.playerReal = New AxRealAudioObjects.AxRealAudio
   CType(Me.playerReal, System.ComponentModel.ISupportInitialize).BeginInit()
   Me.SuspendLayout()
   '
   'playerReal
   '
   Me.playerReal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
   Me.playerReal.Enabled = True
   Me.playerReal.Location = New System.Drawing.Point(0, 1)
   Me.playerReal.Name = "playerReal"
   Me.playerReal.OcxState = CType(resources.GetObject("playerReal.OcxState"), System.Windows.Forms.AxHost.State)
   Me.playerReal.Size = New System.Drawing.Size(531, 358)
   Me.playerReal.TabIndex = 1
   '
   'RealPlayer
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.Controls.Add(Me.playerReal)
   Me.Name = "RealPlayer"
   Me.Subtitle1 = ""
   Me.Subtitle2 = ""
   Me.Controls.SetChildIndex(Me.playerReal, 0)
   CType(Me.playerReal, System.ComponentModel.ISupportInitialize).EndInit()
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents playerReal As AxRealAudioObjects.AxRealAudio

 End Class

End Namespace
