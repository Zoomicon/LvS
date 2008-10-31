'Description: CommentEditor class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

Imports LvS.utilities
Imports SourceGrid
Imports SourceGrid.Cells.Editors
Imports SourceGrid.Cells.Models

Namespace LvS.objects.grid

 Public Class CommentEditor
  Inherits BaseCellEditor

#Region "Properties"

  Public Overloads ReadOnly Property Control() As Comment
   Get
    Return CType(MyBase.Control, Comment)
   End Get
  End Property

#End Region

#Region "Methods"

  Public Sub New()
   MyBase.New(GetType(System.String))
  End Sub

  Protected Overrides Function CreateControl() As System.Windows.Forms.Control
   Return New Comment
  End Function

  Public Overrides Function GetEditedValue() As Object
   Return Control.Value
  End Function

  Public Overrides Sub SetEditValue(ByVal editValue As Object)
   If TypeOf editValue Is String Then
    Control.Value = CType(editValue, String)
   ElseIf editValue Is Nothing Then
    Control.Value = ""
   Else
				Throw New SourceGridException(My.Resources.STR_INVALID_VALUE)
   End If
  End Sub

  Protected Overrides Sub OnValidated(ByVal e As SourceGrid.CellContextEventArgs)
   CType(e.CellContext.Cell.Model.FindModel(GetType(ToolTip)), ToolTip).ToolTipText = Control.Value
   MyBase.OnValidated(e) 'must call last for the grid to be able to cancel any changes done by the editor
  End Sub

#End Region

 End Class

End Namespace
