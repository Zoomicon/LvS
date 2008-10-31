'Description: BaseFileDialogWithEncoding class
'Authors: George Birbilis (birbilis@kagi.com)
'Version: 20080117

Imports System.ComponentModel
Imports System.Text
Imports System.Windows.Forms

<Localizable(True)> _
Public Class BaseFileDialogWithEncoding
 Inherits Component

#Region "Fields"

 Protected fCheckFileExists As Boolean = True
 Protected fCheckPathExists As Boolean = True
	Protected fEncodingLabel As String = My.Resources.STR_ENCODING
	Protected fTitle As String = My.Resources.STR_SAVEAS
 Protected fLabelHandle As Integer = 0
 Protected fComboHandle As Integer = 0
 Protected fFilter As String = ""
 Protected fDefaultExt As String = ""
 Protected fFileName As String = ""
 Protected fEncoding As Encoding = Encoding.Default 'preselect the default system encoding if not told otherwise
 Protected fActiveScreen As Screen

#End Region

#Region "Properties"

 Public Property DefaultExt() As String
  Get
   Return fDefaultExt
  End Get
  Set(ByVal value As String)
   fDefaultExt = value
  End Set
 End Property

 <Localizable(True)> _
 Public Property Filter() As String
  Get
   Return fFilter
  End Get
  Set(ByVal value As String)
   fFilter = value
  End Set
 End Property

 Public Property FileName() As String
  Get
   Return fFileName
  End Get
  Set(ByVal value As String)
   fFileName = value
  End Set
 End Property

 Public Property Encoding() As Encoding
  Get
   Return fEncoding
  End Get
  Set(ByVal value As Encoding)
   fEncoding = value
  End Set
 End Property

 <Localizable(True)> _
 Public Property Title() As String
  Get
   Return fTitle
  End Get
  Set(ByVal value As String)
   fTitle = value
  End Set
 End Property

 <Localizable(True)> _
 Public Property EncodingLabel() As String
  Get
   Return fEncodingLabel
  End Get
  Set(ByVal value As String)
   fEncodingLabel = value
  End Set
 End Property

 <DefaultValue(True)> _
 Public Property CheckFileExists() As Boolean
  Get
   Return fCheckFileExists
  End Get
  Set(ByVal value As Boolean)
   fCheckFileExists = value
  End Set
 End Property

 <DefaultValue(True)> _
 Public Property CheckPathExists() As Boolean
  Get
   Return fCheckPathExists
  End Get
  Set(ByVal value As Boolean)
   fCheckPathExists = value
  End Set
 End Property

#End Region

End Class
