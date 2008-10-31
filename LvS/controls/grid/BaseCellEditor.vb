'Description: BaseCellEditor class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070326

Imports LvS.utilities
Imports SourceGrid
Imports SourceGrid.Cells.Editors

Namespace LvS.objects.grid

 Public MustInherit Class BaseCellEditor
  Inherits EditorControlBase

#Region "Methods"

  Public Sub New(ByVal p_Type As System.Type)
   MyBase.New(p_Type)
   EnableCellDrawOnEdit = False 'do not draw the cell when editing (since the editor control is shown above it)
   EditableMode = SourceGrid.EditableMode.AnyKey Or SourceGrid.EditableMode.SingleClick
  End Sub

  Protected Overrides Sub OnStartingEdit(ByVal cellContext As CellContext, ByVal editorControl As Control) 'This method is called just before the edit start. You can use this method to customize the editor with the cell information
   MyBase.OnStartingEdit(cellContext, editorControl)
   Dim control As Control = CType(editorControl, Control)
   control.Font = cellContext.Cell.View.Font
   control.ForeColor = cellContext.Cell.View.ForeColor
   control.BackColor = cellContext.Grid.Selection.FocusBackColor
  End Sub

#End Region

 End Class

End Namespace
