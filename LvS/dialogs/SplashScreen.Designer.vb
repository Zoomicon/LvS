<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
 Inherits System.Windows.Forms.Form

 'Form overrides dispose to clean up the component list.
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
 Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
 Friend WithEvents Version As System.Windows.Forms.Label
 Friend WithEvents Copyright As System.Windows.Forms.Label
 Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
 Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

 'Required by the Windows Form Designer
 Private components As System.ComponentModel.IContainer

 'NOTE: The following procedure is required by the Windows Form Designer
 'It can be modified using the Windows Form Designer.  
 'Do not modify it using the code editor.
 <System.Diagnostics.DebuggerStepThrough()> _
 Private Sub InitializeComponent()
  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
  Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel
  Me.ApplicationTitle = New System.Windows.Forms.Label
  Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel
  Me.Copyright = New System.Windows.Forms.Label
  Me.Version = New System.Windows.Forms.Label
  Me.MainLayoutPanel.SuspendLayout()
  Me.DetailsLayoutPanel.SuspendLayout()
  Me.SuspendLayout()
  '
  'MainLayoutPanel
  '
  Me.MainLayoutPanel.BackgroundImage = Global.My.Resources.Resources.logonew01_800x600_outline
  resources.ApplyResources(Me.MainLayoutPanel, "MainLayoutPanel")
  Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 1, 0)
  Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
  Me.MainLayoutPanel.Name = "MainLayoutPanel"
  '
  'ApplicationTitle
  '
  Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
  resources.ApplyResources(Me.ApplicationTitle, "ApplicationTitle")
  Me.ApplicationTitle.Name = "ApplicationTitle"
  '
  'DetailsLayoutPanel
  '
  resources.ApplyResources(Me.DetailsLayoutPanel, "DetailsLayoutPanel")
  Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
  Me.MainLayoutPanel.SetColumnSpan(Me.DetailsLayoutPanel, 2)
  Me.DetailsLayoutPanel.Controls.Add(Me.Copyright, 0, 1)
  Me.DetailsLayoutPanel.Controls.Add(Me.Version, 0, 0)
  Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
  '
  'Copyright
  '
  Me.Copyright.BackColor = System.Drawing.Color.Transparent
  resources.ApplyResources(Me.Copyright, "Copyright")
  Me.Copyright.Name = "Copyright"
  '
  'Version
  '
  Me.Version.BackColor = System.Drawing.Color.Transparent
  resources.ApplyResources(Me.Version, "Version")
  Me.Version.Name = "Version"
  '
  'SplashScreen
  '
  resources.ApplyResources(Me, "$this")
  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
  Me.BackColor = System.Drawing.Color.White
  Me.ControlBox = False
  Me.Controls.Add(Me.MainLayoutPanel)
  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
  Me.MaximizeBox = False
  Me.MinimizeBox = False
  Me.Name = "SplashScreen"
  Me.ShowInTaskbar = False
  Me.MainLayoutPanel.ResumeLayout(False)
  Me.DetailsLayoutPanel.ResumeLayout(False)
  Me.ResumeLayout(False)

 End Sub

End Class
