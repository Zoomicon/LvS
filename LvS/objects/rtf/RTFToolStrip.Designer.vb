Namespace LvS.objects.rtf

 Partial Class RTFToolStrip
  Inherits ToolStrip

  <System.Diagnostics.DebuggerNonUserCode()> _
  Public Sub New(ByVal container As System.ComponentModel.IContainer)
   MyClass.New()

   'Required for Windows.Forms Class Composition Designer support
   If (container IsNot Nothing) Then
    container.Add(Me)
   End If

  End Sub

  <System.Diagnostics.DebuggerNonUserCode()> _
  Public Sub New()
   MyBase.New()

   'This call is required by the Component Designer.
   InitializeComponent()

  End Sub

  'Component overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
   Try
    If disposing AndAlso components IsNot Nothing Then
     components.Dispose()
    End If
   Finally
    MyBase.Dispose(disposing)
   End Try
  End Sub

  'Required by the Component Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Component Designer
  'It can be modified using the Component Designer.
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RTFToolStrip))
   Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
   Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
   Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
   Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
   Me.comboFontFamily = New ToolStripFontComboBox
   Me.comboFontSize = New System.Windows.Forms.ToolStripComboBox
   Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
   Me.ColorDialog = New System.Windows.Forms.ColorDialog
   Me.btnCut = New System.Windows.Forms.ToolStripButton
   Me.btnCopy = New System.Windows.Forms.ToolStripButton
   Me.btnPaste = New System.Windows.Forms.ToolStripButton
   Me.btnUndo = New System.Windows.Forms.ToolStripButton
   Me.btnRedo = New System.Windows.Forms.ToolStripButton
   Me.btnBold = New System.Windows.Forms.ToolStripButton
   Me.btnItalic = New System.Windows.Forms.ToolStripButton
   Me.btnUnderline = New System.Windows.Forms.ToolStripButton
   Me.btnStrikeout = New System.Windows.Forms.ToolStripButton
   Me.btnBullet = New System.Windows.Forms.ToolStripButton
   Me.btnLeftAlign = New System.Windows.Forms.ToolStripButton
   Me.btnCenterAlign = New System.Windows.Forms.ToolStripButton
   Me.btnRightAlign = New System.Windows.Forms.ToolStripButton
   Me.btnForegroundColor = New System.Windows.Forms.ToolStripButton
   Me.btnBackgroundColor = New System.Windows.Forms.ToolStripButton
   Me.SuspendLayout()
   '
   'ToolStripSeparator1
   '
   Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
   resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
   '
   'ToolStripSeparator2
   '
   Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
   resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
   '
   'ToolStripSeparator3
   '
   Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
   resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
   '
   'ToolStripSeparator4
   '
   Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
   resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
   '
   'comboFontFamily
   '
   Me.comboFontFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
   Me.comboFontFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
   Me.comboFontFamily.DropDownWidth = 190
   Me.comboFontFamily.Items.AddRange(New Object() {resources.GetString("comboFontFamily.Items"), resources.GetString("comboFontFamily.Items1"), resources.GetString("comboFontFamily.Items2"), resources.GetString("comboFontFamily.Items3"), resources.GetString("comboFontFamily.Items4"), resources.GetString("comboFontFamily.Items5"), resources.GetString("comboFontFamily.Items6"), resources.GetString("comboFontFamily.Items7"), resources.GetString("comboFontFamily.Items8"), resources.GetString("comboFontFamily.Items9"), resources.GetString("comboFontFamily.Items10"), resources.GetString("comboFontFamily.Items11"), resources.GetString("comboFontFamily.Items12"), resources.GetString("comboFontFamily.Items13"), resources.GetString("comboFontFamily.Items14"), resources.GetString("comboFontFamily.Items15"), resources.GetString("comboFontFamily.Items16"), resources.GetString("comboFontFamily.Items17"), resources.GetString("comboFontFamily.Items18"), resources.GetString("comboFontFamily.Items19"), resources.GetString("comboFontFamily.Items20"), resources.GetString("comboFontFamily.Items21"), resources.GetString("comboFontFamily.Items22"), resources.GetString("comboFontFamily.Items23"), resources.GetString("comboFontFamily.Items24"), resources.GetString("comboFontFamily.Items25"), resources.GetString("comboFontFamily.Items26"), resources.GetString("comboFontFamily.Items27"), resources.GetString("comboFontFamily.Items28"), resources.GetString("comboFontFamily.Items29"), resources.GetString("comboFontFamily.Items30"), resources.GetString("comboFontFamily.Items31"), resources.GetString("comboFontFamily.Items32"), resources.GetString("comboFontFamily.Items33"), resources.GetString("comboFontFamily.Items34"), resources.GetString("comboFontFamily.Items35"), resources.GetString("comboFontFamily.Items36"), resources.GetString("comboFontFamily.Items37"), resources.GetString("comboFontFamily.Items38"), resources.GetString("comboFontFamily.Items39"), resources.GetString("comboFontFamily.Items40"), resources.GetString("comboFontFamily.Items41"), resources.GetString("comboFontFamily.Items42"), resources.GetString("comboFontFamily.Items43"), resources.GetString("comboFontFamily.Items44"), resources.GetString("comboFontFamily.Items45"), resources.GetString("comboFontFamily.Items46"), resources.GetString("comboFontFamily.Items47"), resources.GetString("comboFontFamily.Items48"), resources.GetString("comboFontFamily.Items49"), resources.GetString("comboFontFamily.Items50"), resources.GetString("comboFontFamily.Items51"), resources.GetString("comboFontFamily.Items52"), resources.GetString("comboFontFamily.Items53"), resources.GetString("comboFontFamily.Items54"), resources.GetString("comboFontFamily.Items55"), resources.GetString("comboFontFamily.Items56"), resources.GetString("comboFontFamily.Items57"), resources.GetString("comboFontFamily.Items58"), resources.GetString("comboFontFamily.Items59"), resources.GetString("comboFontFamily.Items60"), resources.GetString("comboFontFamily.Items61"), resources.GetString("comboFontFamily.Items62"), resources.GetString("comboFontFamily.Items63"), resources.GetString("comboFontFamily.Items64"), resources.GetString("comboFontFamily.Items65"), resources.GetString("comboFontFamily.Items66"), resources.GetString("comboFontFamily.Items67"), resources.GetString("comboFontFamily.Items68"), resources.GetString("comboFontFamily.Items69"), resources.GetString("comboFontFamily.Items70"), resources.GetString("comboFontFamily.Items71"), resources.GetString("comboFontFamily.Items72"), resources.GetString("comboFontFamily.Items73"), resources.GetString("comboFontFamily.Items74"), resources.GetString("comboFontFamily.Items75"), resources.GetString("comboFontFamily.Items76"), resources.GetString("comboFontFamily.Items77"), resources.GetString("comboFontFamily.Items78"), resources.GetString("comboFontFamily.Items79"), resources.GetString("comboFontFamily.Items80"), resources.GetString("comboFontFamily.Items81"), resources.GetString("comboFontFamily.Items82"), resources.GetString("comboFontFamily.Items83"), resources.GetString("comboFontFamily.Items84"), resources.GetString("comboFontFamily.Items85"), resources.GetString("comboFontFamily.Items86"), resources.GetString("comboFontFamily.Items87"), resources.GetString("comboFontFamily.Items88"), resources.GetString("comboFontFamily.Items89"), resources.GetString("comboFontFamily.Items90"), resources.GetString("comboFontFamily.Items91"), resources.GetString("comboFontFamily.Items92"), resources.GetString("comboFontFamily.Items93"), resources.GetString("comboFontFamily.Items94"), resources.GetString("comboFontFamily.Items95"), resources.GetString("comboFontFamily.Items96"), resources.GetString("comboFontFamily.Items97"), resources.GetString("comboFontFamily.Items98"), resources.GetString("comboFontFamily.Items99"), resources.GetString("comboFontFamily.Items100"), resources.GetString("comboFontFamily.Items101"), resources.GetString("comboFontFamily.Items102"), resources.GetString("comboFontFamily.Items103"), resources.GetString("comboFontFamily.Items104"), resources.GetString("comboFontFamily.Items105"), resources.GetString("comboFontFamily.Items106"), resources.GetString("comboFontFamily.Items107"), resources.GetString("comboFontFamily.Items108"), resources.GetString("comboFontFamily.Items109"), resources.GetString("comboFontFamily.Items110"), resources.GetString("comboFontFamily.Items111"), resources.GetString("comboFontFamily.Items112"), resources.GetString("comboFontFamily.Items113"), resources.GetString("comboFontFamily.Items114"), resources.GetString("comboFontFamily.Items115"), resources.GetString("comboFontFamily.Items116"), resources.GetString("comboFontFamily.Items117"), resources.GetString("comboFontFamily.Items118"), resources.GetString("comboFontFamily.Items119"), resources.GetString("comboFontFamily.Items120"), resources.GetString("comboFontFamily.Items121"), resources.GetString("comboFontFamily.Items122"), resources.GetString("comboFontFamily.Items123"), resources.GetString("comboFontFamily.Items124"), resources.GetString("comboFontFamily.Items125"), resources.GetString("comboFontFamily.Items126"), resources.GetString("comboFontFamily.Items127"), resources.GetString("comboFontFamily.Items128"), resources.GetString("comboFontFamily.Items129"), resources.GetString("comboFontFamily.Items130"), resources.GetString("comboFontFamily.Items131"), resources.GetString("comboFontFamily.Items132"), resources.GetString("comboFontFamily.Items133"), resources.GetString("comboFontFamily.Items134"), resources.GetString("comboFontFamily.Items135"), resources.GetString("comboFontFamily.Items136"), resources.GetString("comboFontFamily.Items137"), resources.GetString("comboFontFamily.Items138"), resources.GetString("comboFontFamily.Items139"), resources.GetString("comboFontFamily.Items140"), resources.GetString("comboFontFamily.Items141"), resources.GetString("comboFontFamily.Items142"), resources.GetString("comboFontFamily.Items143"), resources.GetString("comboFontFamily.Items144"), resources.GetString("comboFontFamily.Items145"), resources.GetString("comboFontFamily.Items146"), resources.GetString("comboFontFamily.Items147"), resources.GetString("comboFontFamily.Items148"), resources.GetString("comboFontFamily.Items149"), resources.GetString("comboFontFamily.Items150"), resources.GetString("comboFontFamily.Items151"), resources.GetString("comboFontFamily.Items152"), resources.GetString("comboFontFamily.Items153"), resources.GetString("comboFontFamily.Items154"), resources.GetString("comboFontFamily.Items155"), resources.GetString("comboFontFamily.Items156"), resources.GetString("comboFontFamily.Items157"), resources.GetString("comboFontFamily.Items158"), resources.GetString("comboFontFamily.Items159"), resources.GetString("comboFontFamily.Items160"), resources.GetString("comboFontFamily.Items161"), resources.GetString("comboFontFamily.Items162"), resources.GetString("comboFontFamily.Items163"), resources.GetString("comboFontFamily.Items164"), resources.GetString("comboFontFamily.Items165"), resources.GetString("comboFontFamily.Items166"), resources.GetString("comboFontFamily.Items167"), resources.GetString("comboFontFamily.Items168"), resources.GetString("comboFontFamily.Items169"), resources.GetString("comboFontFamily.Items170"), resources.GetString("comboFontFamily.Items171"), resources.GetString("comboFontFamily.Items172"), resources.GetString("comboFontFamily.Items173"), resources.GetString("comboFontFamily.Items174"), resources.GetString("comboFontFamily.Items175"), resources.GetString("comboFontFamily.Items176"), resources.GetString("comboFontFamily.Items177"), resources.GetString("comboFontFamily.Items178"), resources.GetString("comboFontFamily.Items179"), resources.GetString("comboFontFamily.Items180"), resources.GetString("comboFontFamily.Items181"), resources.GetString("comboFontFamily.Items182"), resources.GetString("comboFontFamily.Items183"), resources.GetString("comboFontFamily.Items184"), resources.GetString("comboFontFamily.Items185"), resources.GetString("comboFontFamily.Items186"), resources.GetString("comboFontFamily.Items187"), resources.GetString("comboFontFamily.Items188"), resources.GetString("comboFontFamily.Items189"), resources.GetString("comboFontFamily.Items190"), resources.GetString("comboFontFamily.Items191"), resources.GetString("comboFontFamily.Items192"), resources.GetString("comboFontFamily.Items193"), resources.GetString("comboFontFamily.Items194"), resources.GetString("comboFontFamily.Items195"), resources.GetString("comboFontFamily.Items196"), resources.GetString("comboFontFamily.Items197"), resources.GetString("comboFontFamily.Items198"), resources.GetString("comboFontFamily.Items199"), resources.GetString("comboFontFamily.Items200"), resources.GetString("comboFontFamily.Items201"), resources.GetString("comboFontFamily.Items202"), resources.GetString("comboFontFamily.Items203"), resources.GetString("comboFontFamily.Items204"), resources.GetString("comboFontFamily.Items205"), resources.GetString("comboFontFamily.Items206"), resources.GetString("comboFontFamily.Items207"), resources.GetString("comboFontFamily.Items208"), resources.GetString("comboFontFamily.Items209"), resources.GetString("comboFontFamily.Items210"), resources.GetString("comboFontFamily.Items211"), resources.GetString("comboFontFamily.Items212"), resources.GetString("comboFontFamily.Items213"), resources.GetString("comboFontFamily.Items214"), resources.GetString("comboFontFamily.Items215"), resources.GetString("comboFontFamily.Items216"), resources.GetString("comboFontFamily.Items217"), resources.GetString("comboFontFamily.Items218"), resources.GetString("comboFontFamily.Items219"), resources.GetString("comboFontFamily.Items220"), resources.GetString("comboFontFamily.Items221"), resources.GetString("comboFontFamily.Items222"), resources.GetString("comboFontFamily.Items223"), resources.GetString("comboFontFamily.Items224"), resources.GetString("comboFontFamily.Items225"), resources.GetString("comboFontFamily.Items226"), resources.GetString("comboFontFamily.Items227"), resources.GetString("comboFontFamily.Items228"), resources.GetString("comboFontFamily.Items229"), resources.GetString("comboFontFamily.Items230"), resources.GetString("comboFontFamily.Items231"), resources.GetString("comboFontFamily.Items232"), resources.GetString("comboFontFamily.Items233"), resources.GetString("comboFontFamily.Items234"), resources.GetString("comboFontFamily.Items235"), resources.GetString("comboFontFamily.Items236"), resources.GetString("comboFontFamily.Items237"), resources.GetString("comboFontFamily.Items238"), resources.GetString("comboFontFamily.Items239"), resources.GetString("comboFontFamily.Items240"), resources.GetString("comboFontFamily.Items241"), resources.GetString("comboFontFamily.Items242"), resources.GetString("comboFontFamily.Items243"), resources.GetString("comboFontFamily.Items244"), resources.GetString("comboFontFamily.Items245"), resources.GetString("comboFontFamily.Items246"), resources.GetString("comboFontFamily.Items247"), resources.GetString("comboFontFamily.Items248"), resources.GetString("comboFontFamily.Items249"), resources.GetString("comboFontFamily.Items250"), resources.GetString("comboFontFamily.Items251"), resources.GetString("comboFontFamily.Items252"), resources.GetString("comboFontFamily.Items253"), resources.GetString("comboFontFamily.Items254"), resources.GetString("comboFontFamily.Items255"), resources.GetString("comboFontFamily.Items256"), resources.GetString("comboFontFamily.Items257"), resources.GetString("comboFontFamily.Items258"), resources.GetString("comboFontFamily.Items259"), resources.GetString("comboFontFamily.Items260"), resources.GetString("comboFontFamily.Items261"), resources.GetString("comboFontFamily.Items262"), resources.GetString("comboFontFamily.Items263"), resources.GetString("comboFontFamily.Items264"), resources.GetString("comboFontFamily.Items265"), resources.GetString("comboFontFamily.Items266"), resources.GetString("comboFontFamily.Items267"), resources.GetString("comboFontFamily.Items268"), resources.GetString("comboFontFamily.Items269"), resources.GetString("comboFontFamily.Items270"), resources.GetString("comboFontFamily.Items271"), resources.GetString("comboFontFamily.Items272"), resources.GetString("comboFontFamily.Items273"), resources.GetString("comboFontFamily.Items274"), resources.GetString("comboFontFamily.Items275"), resources.GetString("comboFontFamily.Items276"), resources.GetString("comboFontFamily.Items277"), resources.GetString("comboFontFamily.Items278"), resources.GetString("comboFontFamily.Items279"), resources.GetString("comboFontFamily.Items280"), resources.GetString("comboFontFamily.Items281"), resources.GetString("comboFontFamily.Items282"), resources.GetString("comboFontFamily.Items283"), resources.GetString("comboFontFamily.Items284"), resources.GetString("comboFontFamily.Items285"), resources.GetString("comboFontFamily.Items286"), resources.GetString("comboFontFamily.Items287"), resources.GetString("comboFontFamily.Items288"), resources.GetString("comboFontFamily.Items289"), resources.GetString("comboFontFamily.Items290"), resources.GetString("comboFontFamily.Items291"), resources.GetString("comboFontFamily.Items292"), resources.GetString("comboFontFamily.Items293"), resources.GetString("comboFontFamily.Items294"), resources.GetString("comboFontFamily.Items295"), resources.GetString("comboFontFamily.Items296"), resources.GetString("comboFontFamily.Items297"), resources.GetString("comboFontFamily.Items298"), resources.GetString("comboFontFamily.Items299"), resources.GetString("comboFontFamily.Items300"), resources.GetString("comboFontFamily.Items301"), resources.GetString("comboFontFamily.Items302"), resources.GetString("comboFontFamily.Items303"), resources.GetString("comboFontFamily.Items304"), resources.GetString("comboFontFamily.Items305"), resources.GetString("comboFontFamily.Items306"), resources.GetString("comboFontFamily.Items307"), resources.GetString("comboFontFamily.Items308"), resources.GetString("comboFontFamily.Items309"), resources.GetString("comboFontFamily.Items310"), resources.GetString("comboFontFamily.Items311"), resources.GetString("comboFontFamily.Items312"), resources.GetString("comboFontFamily.Items313"), resources.GetString("comboFontFamily.Items314"), resources.GetString("comboFontFamily.Items315"), resources.GetString("comboFontFamily.Items316"), resources.GetString("comboFontFamily.Items317"), resources.GetString("comboFontFamily.Items318"), resources.GetString("comboFontFamily.Items319"), resources.GetString("comboFontFamily.Items320"), resources.GetString("comboFontFamily.Items321"), resources.GetString("comboFontFamily.Items322"), resources.GetString("comboFontFamily.Items323"), resources.GetString("comboFontFamily.Items324"), resources.GetString("comboFontFamily.Items325"), resources.GetString("comboFontFamily.Items326"), resources.GetString("comboFontFamily.Items327"), resources.GetString("comboFontFamily.Items328"), resources.GetString("comboFontFamily.Items329"), resources.GetString("comboFontFamily.Items330"), resources.GetString("comboFontFamily.Items331"), resources.GetString("comboFontFamily.Items332"), resources.GetString("comboFontFamily.Items333"), resources.GetString("comboFontFamily.Items334"), resources.GetString("comboFontFamily.Items335"), resources.GetString("comboFontFamily.Items336"), resources.GetString("comboFontFamily.Items337"), resources.GetString("comboFontFamily.Items338"), resources.GetString("comboFontFamily.Items339"), resources.GetString("comboFontFamily.Items340"), resources.GetString("comboFontFamily.Items341"), resources.GetString("comboFontFamily.Items342"), resources.GetString("comboFontFamily.Items343"), resources.GetString("comboFontFamily.Items344"), resources.GetString("comboFontFamily.Items345"), resources.GetString("comboFontFamily.Items346"), resources.GetString("comboFontFamily.Items347"), resources.GetString("comboFontFamily.Items348"), resources.GetString("comboFontFamily.Items349"), resources.GetString("comboFontFamily.Items350"), resources.GetString("comboFontFamily.Items351"), resources.GetString("comboFontFamily.Items352"), resources.GetString("comboFontFamily.Items353"), resources.GetString("comboFontFamily.Items354"), resources.GetString("comboFontFamily.Items355"), resources.GetString("comboFontFamily.Items356"), resources.GetString("comboFontFamily.Items357"), resources.GetString("comboFontFamily.Items358"), resources.GetString("comboFontFamily.Items359"), resources.GetString("comboFontFamily.Items360"), resources.GetString("comboFontFamily.Items361"), resources.GetString("comboFontFamily.Items362"), resources.GetString("comboFontFamily.Items363"), resources.GetString("comboFontFamily.Items364"), resources.GetString("comboFontFamily.Items365"), resources.GetString("comboFontFamily.Items366"), resources.GetString("comboFontFamily.Items367"), resources.GetString("comboFontFamily.Items368"), resources.GetString("comboFontFamily.Items369"), resources.GetString("comboFontFamily.Items370"), resources.GetString("comboFontFamily.Items371"), resources.GetString("comboFontFamily.Items372"), resources.GetString("comboFontFamily.Items373"), resources.GetString("comboFontFamily.Items374"), resources.GetString("comboFontFamily.Items375"), resources.GetString("comboFontFamily.Items376"), resources.GetString("comboFontFamily.Items377"), resources.GetString("comboFontFamily.Items378"), resources.GetString("comboFontFamily.Items379"), resources.GetString("comboFontFamily.Items380"), resources.GetString("comboFontFamily.Items381"), resources.GetString("comboFontFamily.Items382"), resources.GetString("comboFontFamily.Items383"), resources.GetString("comboFontFamily.Items384"), resources.GetString("comboFontFamily.Items385"), resources.GetString("comboFontFamily.Items386"), resources.GetString("comboFontFamily.Items387"), resources.GetString("comboFontFamily.Items388"), resources.GetString("comboFontFamily.Items389"), resources.GetString("comboFontFamily.Items390"), resources.GetString("comboFontFamily.Items391"), resources.GetString("comboFontFamily.Items392"), resources.GetString("comboFontFamily.Items393"), resources.GetString("comboFontFamily.Items394"), resources.GetString("comboFontFamily.Items395"), resources.GetString("comboFontFamily.Items396"), resources.GetString("comboFontFamily.Items397"), resources.GetString("comboFontFamily.Items398"), resources.GetString("comboFontFamily.Items399"), resources.GetString("comboFontFamily.Items400"), resources.GetString("comboFontFamily.Items401"), resources.GetString("comboFontFamily.Items402"), resources.GetString("comboFontFamily.Items403"), resources.GetString("comboFontFamily.Items404"), resources.GetString("comboFontFamily.Items405"), resources.GetString("comboFontFamily.Items406"), resources.GetString("comboFontFamily.Items407"), resources.GetString("comboFontFamily.Items408"), resources.GetString("comboFontFamily.Items409"), resources.GetString("comboFontFamily.Items410"), resources.GetString("comboFontFamily.Items411"), resources.GetString("comboFontFamily.Items412"), resources.GetString("comboFontFamily.Items413"), resources.GetString("comboFontFamily.Items414"), resources.GetString("comboFontFamily.Items415"), resources.GetString("comboFontFamily.Items416"), resources.GetString("comboFontFamily.Items417"), resources.GetString("comboFontFamily.Items418"), resources.GetString("comboFontFamily.Items419"), resources.GetString("comboFontFamily.Items420"), resources.GetString("comboFontFamily.Items421"), resources.GetString("comboFontFamily.Items422")})
   Me.comboFontFamily.Name = "comboFontFamily"
   resources.ApplyResources(Me.comboFontFamily, "comboFontFamily")
   '
   'comboFontSize
   '
   Me.comboFontSize.Items.AddRange(New Object() {resources.GetString("comboFontSize.Items"), resources.GetString("comboFontSize.Items1"), resources.GetString("comboFontSize.Items2"), resources.GetString("comboFontSize.Items3"), resources.GetString("comboFontSize.Items4"), resources.GetString("comboFontSize.Items5"), resources.GetString("comboFontSize.Items6"), resources.GetString("comboFontSize.Items7"), resources.GetString("comboFontSize.Items8"), resources.GetString("comboFontSize.Items9"), resources.GetString("comboFontSize.Items10"), resources.GetString("comboFontSize.Items11"), resources.GetString("comboFontSize.Items12"), resources.GetString("comboFontSize.Items13"), resources.GetString("comboFontSize.Items14"), resources.GetString("comboFontSize.Items15")})
   Me.comboFontSize.Name = "comboFontSize"
   resources.ApplyResources(Me.comboFontSize, "comboFontSize")
   '
   'ToolStripSeparator5
   '
   Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
   resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
   '
   'ColorDialog
   '
   Me.ColorDialog.AnyColor = True
   '
   'btnCut
   '
   Me.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnCut.Image = Global.My.Resources.Resources.cutAction1_Image
   resources.ApplyResources(Me.btnCut, "btnCut")
   Me.btnCut.Name = "btnCut"
   '
   'btnCopy
   '
   Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnCopy.Image = Global.My.Resources.Resources.copyAction1_Image
   resources.ApplyResources(Me.btnCopy, "btnCopy")
   Me.btnCopy.Name = "btnCopy"
   '
   'btnPaste
   '
   Me.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnPaste.Image = Global.My.Resources.Resources.pasteAction1_Image
   resources.ApplyResources(Me.btnPaste, "btnPaste")
   Me.btnPaste.Name = "btnPaste"
   '
   'btnUndo
   '
   Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnUndo.Image = Global.My.Resources.Resources.undoAction1_Image
   resources.ApplyResources(Me.btnUndo, "btnUndo")
   Me.btnUndo.Name = "btnUndo"
   '
   'btnRedo
   '
   Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnRedo.Image = Global.My.Resources.Resources.redoAction1_Image
   resources.ApplyResources(Me.btnRedo, "btnRedo")
   Me.btnRedo.Name = "btnRedo"
   '
   'btnBold
   '
   Me.btnBold.CheckOnClick = True
   Me.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnBold.Image = Global.My.Resources.Resources.boldAction1_Image
   resources.ApplyResources(Me.btnBold, "btnBold")
   Me.btnBold.Name = "btnBold"
   '
   'btnItalic
   '
   Me.btnItalic.CheckOnClick = True
   Me.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnItalic.Image = Global.My.Resources.Resources.italicAction1_Image
   resources.ApplyResources(Me.btnItalic, "btnItalic")
   Me.btnItalic.Name = "btnItalic"
   '
   'btnUnderline
   '
   Me.btnUnderline.CheckOnClick = True
   Me.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnUnderline.Image = Global.My.Resources.Resources.underlineAction1_Image
   resources.ApplyResources(Me.btnUnderline, "btnUnderline")
   Me.btnUnderline.Name = "btnUnderline"
   '
   'btnStrikeout
   '
   Me.btnStrikeout.CheckOnClick = True
   Me.btnStrikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnStrikeout.Image = Global.My.Resources.Resources.text_strikethrough
   resources.ApplyResources(Me.btnStrikeout, "btnStrikeout")
   Me.btnStrikeout.Name = "btnStrikeout"
   '
   'btnBullet
   '
   Me.btnBullet.CheckOnClick = True
   Me.btnBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnBullet.Image = Global.My.Resources.Resources.text_list_bullets
   resources.ApplyResources(Me.btnBullet, "btnBullet")
   Me.btnBullet.Name = "btnBullet"
   '
   'btnLeftAlign
   '
   Me.btnLeftAlign.CheckOnClick = True
   Me.btnLeftAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnLeftAlign.Image = Global.My.Resources.Resources.text_align_left
   resources.ApplyResources(Me.btnLeftAlign, "btnLeftAlign")
   Me.btnLeftAlign.Name = "btnLeftAlign"
   '
   'btnCenterAlign
   '
   Me.btnCenterAlign.CheckOnClick = True
   Me.btnCenterAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnCenterAlign.Image = Global.My.Resources.Resources.text_align_center
   resources.ApplyResources(Me.btnCenterAlign, "btnCenterAlign")
   Me.btnCenterAlign.Name = "btnCenterAlign"
   '
   'btnRightAlign
   '
   Me.btnRightAlign.CheckOnClick = True
   Me.btnRightAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnRightAlign.Image = Global.My.Resources.Resources.text_align_right
   resources.ApplyResources(Me.btnRightAlign, "btnRightAlign")
   Me.btnRightAlign.Name = "btnRightAlign"
   '
   'btnForegroundColor
   '
   Me.btnForegroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnForegroundColor.Image = Global.My.Resources.Resources.Forecolor
   resources.ApplyResources(Me.btnForegroundColor, "btnForegroundColor")
   Me.btnForegroundColor.Name = "btnForegroundColor"
   '
   'btnBackgroundColor
   '
   Me.btnBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
   Me.btnBackgroundColor.Image = Global.My.Resources.Resources.Color_linecolor
   resources.ApplyResources(Me.btnBackgroundColor, "btnBackgroundColor")
   Me.btnBackgroundColor.Name = "btnBackgroundColor"
   '
   'RTFToolStrip
   '
   Me.AllowItemReorder = True
   Me.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCut, Me.btnCopy, Me.btnPaste, Me.ToolStripSeparator1, Me.btnUndo, Me.btnRedo, Me.ToolStripSeparator2, Me.btnBold, Me.btnItalic, Me.btnUnderline, Me.btnStrikeout, Me.btnBullet, Me.ToolStripSeparator3, Me.btnLeftAlign, Me.btnCenterAlign, Me.btnRightAlign, Me.ToolStripSeparator5, Me.btnForegroundColor, Me.btnBackgroundColor, Me.ToolStripSeparator4, Me.comboFontFamily, Me.comboFontSize})
   Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnCut As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnCopy As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnPaste As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnBold As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents btnItalic As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnUnderline As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnForegroundColor As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnBackgroundColor As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents comboFontFamily As ToolStripFontComboBox
  Friend WithEvents comboFontSize As System.Windows.Forms.ToolStripComboBox
  Friend WithEvents btnLeftAlign As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnCenterAlign As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnRightAlign As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
  Friend WithEvents btnBullet As System.Windows.Forms.ToolStripButton
  Friend WithEvents btnStrikeout As System.Windows.Forms.ToolStripButton

 End Class

End Namespace
