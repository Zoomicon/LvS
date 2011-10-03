'Description: UpDownTime class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20070328

Namespace LvS.objects.grid

 Public Class UpDownTimeCentered

#Region "Properties"

  Public Property Time() As DateTime
   Get
    Return TimeControl.Time
   End Get
   Set(ByVal value As DateTime)
    TimeControl.Time = value
   End Set
  End Property

  Public ReadOnly Property TimeControl() As UpDownTime
   Get
    Return timeUpDown
   End Get
  End Property

  Private Sub timeUpDown_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeUpDown.TextChanged
   Dim tim As UpDownTime = CType(sender, UpDownTime)
   ToolTips.SetToolTip(tim, tim.Text)
  End Sub

#End Region

 End Class

End Namespace
