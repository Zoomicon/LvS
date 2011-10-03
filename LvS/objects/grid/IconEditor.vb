'Description: IconCommentEditor class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090309

Imports LvS.models.notes
Imports LvS.utilities
Imports SourceGrid
Imports SourceGrid.Cells.Editors
Imports SourceGrid.Cells.Models

Namespace LvS.objects.grid

 Public Class IconEditor
  Inherits BaseCellEditor

#Region "Fields"

		Protected fCommentVisible As Boolean

#End Region

#Region "Properties"

  Public Overloads ReadOnly Property Control() As IconDropDown
   Get
    Return CType(MyBase.Control, IconDropDown)
   End Get
  End Property

#End Region

#Region "Methods"

  Public Sub New()
   MyBase.New(GetType(String))
  End Sub

  Protected Overrides Function CreateControl() As System.Windows.Forms.Control
   Return New IconDropDown
  End Function

  Public Overrides Function GetEditedValue() As Object
   Dim value As Integer = Control.Value
   If value = 0 Then value = -1 'special check for image index 0, to avoid setting the blank image to the grid cell (cause it shows a line border at bottom and right sides). Must also do this check here too apart from at "OnValidated" method, cause else at next load it would show the blank images with the border instead of no image (and would also consume more resources and spend more at reload and at repaints in such case)
   Return CStr(value)
  End Function

  Public Overrides Sub SetEditValue(ByVal editValue As Object)
   If TypeOf editValue Is Integer Then
    Control.Value = CInt(editValue)
   ElseIf TypeOf editValue Is String Then
    If CStr(editValue) <> "" Then Control.Value = CInt(editValue) Else Control.Value = -1
   ElseIf editValue Is Nothing Then
    Control.Value = -1
   Else
				Throw New SourceGridException(My.Resources.STR_INVALID_VALUE)
   End If
  End Sub

  Protected Overrides Sub OnValidated(ByVal e As SourceGrid.CellContextEventArgs)
   Dim cell As SourceGrid.Cells.ICell = CType(e.CellContext.Cell, SourceGrid.Cells.ICell)
   If Control.Value = 0 Then Control.Value = -1 'special check for image index 0, to avoid Control.SelectedImage return the blank image to set at the grid cell (cause it shows a line border at bottom and right sides)
   cell.Image = Control.SelectedImage
   MyBase.OnValidated(e) 'must call last for the grid to be able to cancel any changes done by the editor
  End Sub

#End Region

 End Class

End Namespace
