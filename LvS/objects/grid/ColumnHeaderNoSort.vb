'Description: ColumnHeaderNoSort class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070318

Imports SourceGrid.Cells

Namespace LvS.objects.grid

 Public Class ColumnHeaderNoSort
  Inherits ColumnHeader

  Protected Sub Init()
   AutomaticSortEnabled = False
  End Sub

  Public Sub New()
   MyBase.New() 'think this is optional, since this is the default constructor
   Init()
  End Sub

  Public Sub New(ByVal cellValue As Object)
   MyBase.New(cellValue)
   Init()
  End Sub

 End Class

End Namespace
