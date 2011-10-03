'Description: IconDropDown class
'Authors: Kostas Mitropoulos (kosmitr@eap.gr), George Birbilis (birbilis@kagi.com)
'Version: 20070404

Namespace LvS.objects.grid

 Public Class IconDropDown

#Region "Properties"

  Public ReadOnly Property SelectedImage() As Image
   Get
    Dim index As Integer = dropImages.SelectedIndex
    If index < 0 Then Return Nothing Else Return ImageList.Images(index)
   End Get
  End Property

  Public Property Value() As Integer
   Get
    Return dropImages.SelectedIndex
   End Get
   Set(ByVal value As Integer)
    dropImages.SelectedIndex = value
   End Set
  End Property

#End Region

#Region "Methods"

  Public Sub New()
   ' This call is required by the Windows Form Designer.
   InitializeComponent()
   ' Add any initialization after the InitializeComponent() call.
   ' Must do the following at the constructor, not at "Load" event handler, cause when item is constructed outside of a form, the "Load" event handler is not called
   Dim items(ImageList.Images.Count - 1) As String
   For i As Integer = 0 To ImageList.Images.Count - 1
    items(i) = CStr(i) 'use the number as the text (not shown) to allow user to press 0, 1, 2, etc. to select an icon
   Next
   With dropImages
    .Items.AddRange(items)
    .DropDownStyle = ComboBoxStyle.DropDownList
    .DrawMode = DrawMode.OwnerDrawVariable
    .ItemHeight = ImageList.ImageSize.Height
    .Height = .ItemHeight
    .Width = ImageList.ImageSize.Width
    .MinimumSize = New Size(Width, Height)
    .MaxDropDownItems = ImageList.Images.Count - 1
   End With
  End Sub

#End Region

#Region "Events"

  Private Sub Images_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles dropImages.DrawItem
   If (e.Index <> -1) AndAlso (e.Index < ImageList.Images.Count) Then
    e.DrawBackground() ' Draw the background of the item
    e.Graphics.DrawImage(ImageList.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
    e.DrawFocusRectangle() ' Draw the focus rectangle if the mouse hovers over an item
   End If
  End Sub

  Private Sub Images_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles dropImages.MeasureItem
   If (e.Index < ImageList.Images.Count) Then
    e.ItemHeight = ImageList.ImageSize.Height
    e.ItemWidth = ImageList.ImageSize.Width
   End If
  End Sub

#End Region

 End Class

End Namespace
