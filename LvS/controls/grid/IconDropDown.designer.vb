Namespace LvS.objects.grid

 <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class IconDropDown
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
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IconDropDown))
   Me.dropImages = New System.Windows.Forms.ComboBox
   Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
   Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
   Me.SuspendLayout()
   '
   'dropImages
   '
   Me.dropImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
   Me.dropImages.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
   Me.dropImages.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
   Me.dropImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
   Me.dropImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
   Me.dropImages.FormattingEnabled = True
   Me.dropImages.Location = New System.Drawing.Point(0, -1)
   Me.dropImages.MaxDropDownItems = 10
   Me.dropImages.MaxLength = 1
   Me.dropImages.Name = "dropImages"
   Me.dropImages.Size = New System.Drawing.Size(38, 21)
   Me.dropImages.TabIndex = 0
   '
   'ImageList
   '
   Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
   Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
   Me.ImageList.Images.SetKeyName(0, "blank.png")
   Me.ImageList.Images.SetKeyName(1, "tick.png")
   Me.ImageList.Images.SetKeyName(2, "star.png")
   Me.ImageList.Images.SetKeyName(3, "comment.gif")
   Me.ImageList.Images.SetKeyName(4, "information.png")
   Me.ImageList.Images.SetKeyName(5, "bell.png")
   Me.ImageList.Images.SetKeyName(6, "attention.png")
   Me.ImageList.Images.SetKeyName(7, "note.png")
   Me.ImageList.Images.SetKeyName(8, "time.png")
   Me.ImageList.Images.SetKeyName(9, "lightbulb.png")
   '
   'ToolTips
   '
   Me.ToolTips.IsBalloon = True
   '
   'IconDropDown
   '
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.BackColor = System.Drawing.Color.Transparent
   Me.Controls.Add(Me.dropImages)
   Me.Name = "IconDropDown"
   Me.Size = New System.Drawing.Size(41, 20)
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents dropImages As System.Windows.Forms.ComboBox
  Friend WithEvents ImageList As System.Windows.Forms.ImageList
  Friend WithEvents ToolTips As System.Windows.Forms.ToolTip

 End Class

End Namespace
