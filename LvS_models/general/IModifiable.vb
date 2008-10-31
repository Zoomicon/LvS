'Description: IModifiable interface
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070402

Namespace LvS.models

 Public Interface IModifiable

#Region "Properties"

  Property Modified() As Boolean

#End Region

#Region "Events"

  Event ModifiedChanged(ByVal source As IModifiable, ByVal newModifiedFlag As Boolean)

#End Region

 End Interface

End Namespace
