'Description: TimeEditor class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

Imports LvS.utilities
Imports SourceGrid
Imports SourceGrid.Cells.Editors
Imports SourceGrid.Cells.Models

Namespace LvS.objects.grid

 Public Class TimeEditor
  Inherits BaseCellEditor

#Region "Properties"

  Public Overloads ReadOnly Property Control() As UpDownTimeCentered
   Get
    Return CType(MyBase.Control, UpDownTimeCentered)
   End Get
  End Property

#End Region

#Region "Methods"

  Public Sub New()
   MyBase.New(GetType(System.DateTime))
   TypeConverter = New DevAge.ComponentModel.Converter.DateTimeTypeConverter(UpDownTime.DEFAULT_FORMAT, New String() {UpDownTime.DEFAULT_FORMAT})
  End Sub

  Protected Overrides Function CreateControl() As System.Windows.Forms.Control
   Return New UpDownTimeCentered
  End Function

  Public Overrides Function GetEditedValue() As Object
   Return Control.Time
  End Function

  Public Overrides Sub SetEditValue(ByVal editValue As Object)
   If TypeOf editValue Is DateTime Then
    Control.Time = CType(editValue, DateTime)
   ElseIf editValue Is Nothing Then
    Control.Time = DateTimeUtils.DATETIMEZERO
   Else
				Throw New SourceGridException(My.Resources.STR_INVALID_VALUE)
   End If
  End Sub

  Protected Overrides Sub OnValidated(ByVal e As SourceGrid.CellContextEventArgs)
   CType(e.CellContext.Cell.Model.FindModel(GetType(ToolTip)), ToolTip).ToolTipText = Control.Time.ToString(UpDownTime.DEFAULT_FORMAT)
   MyBase.OnValidated(e) 'must call last for the grid to be able to cancel any changes done by the editor
  End Sub

#End Region

 End Class

End Namespace
