'Description: UpDownTime class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20090310

Imports System.ComponentModel
Imports LvS.utilities.DateTimeUtils

Namespace LvS.objects.grid

 Public Class UpDownTime
  Inherits UpDownBase

#Region "Constants"

  Public Const DEFAULT_FORMAT As String = "HH:mm:ss.ff"

#End Region

#Region "Fields"

  Protected fStep As Integer = 10 'in msec
  Protected fCustomFormat As String = DEFAULT_FORMAT

#End Region

#Region "Methods"

  Public Sub New()
   MyBase.New()
   Time = DATETIMEZERO
  End Sub

  Public Property Time() As DateTime
   Get
				Return TimeStrToDateTime(Text, DATETIMEZERO, fCustomFormat)	'do not use Parse directly
   End Get
   Set(ByVal value As DateTime)
    Text = value.ToString(fCustomFormat)
   End Set
  End Property

  Public Property CustomFormat() As String
   Get
    Return fCustomFormat
   End Get
   Set(ByVal value As String)
    fCustomFormat = value
   End Set
  End Property

  Public Overrides Sub DownButton()
   Try
    Time = Time.AddMilliseconds(-fStep)
   Catch
    Time = DATETIMEZERO
   End Try
  End Sub

  Public Overrides Sub UpButton()
   Try
    Time = Time.AddMilliseconds(fStep)
   Catch
    Time = DATETIMEZERO
   End Try
  End Sub

  Protected Overrides Sub UpdateEditText()
   'do nothing
  End Sub

#End Region

 End Class

End Namespace
