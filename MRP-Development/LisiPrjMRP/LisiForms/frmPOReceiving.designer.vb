<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPOReceiving
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPSlipNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPODate = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.cmbBuyer = New System.Windows.Forms.ComboBox()
        Me.cmbUser = New System.Windows.Forms.ComboBox()
        Me.cmbPOStatus = New System.Windows.Forms.ComboBox()
        Me.cmbPOType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtPSlipDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtRecDate = New System.Windows.Forms.DateTimePicker()
        Me.btnAccAll = New System.Windows.Forms.Button()
        Me.pnlPORecv = New System.Windows.Forms.Panel()
        Me.dgAlusta = New System.Windows.Forms.DataGridView()
        Me.LACDATA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTLAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTSUPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTDEVISE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTCODETAXE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwENTHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTTTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POReqBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTRequester = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTBuyer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTPOStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTPODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENTPOModDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINPOType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINPOItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINPOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINPOUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINTotPriceConf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINRemise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINProdID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINGLCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINEtablissement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINCostCenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINFamille = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINSUPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINCommande = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINCapexNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINCapexDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINSolde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECPONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECNET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ARECDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECSTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADocRecvNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ARecvMatlWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AAccpToPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ARecQtyAccp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AApprInsp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AApprRecvToPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APayInvDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwPrice = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelRecv = New System.Windows.Forms.Button()
        Me.dgPODetails = New System.Windows.Forms.DataGridView()
        Me.PODetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POItemDet = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ProdDesc = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.POMpoNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.POQtyDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POUM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.POPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PODiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPOReceivings = New System.Windows.Forms.DataGridView()
        Me.POItemRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POMpoNoRecv = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PSlipNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PSlipDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PSlipQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PSlipUM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PSlipPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PSlipDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccpToPay = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AlustaBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalValueRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoRecvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprRecvToPay = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtTotalPOQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalPOValue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalRecQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalRecValue = New System.Windows.Forms.TextBox()
        Me.btnRecAll = New System.Windows.Forms.Button()
        Me.btnFindPO = New System.Windows.Forms.Button()
        Me.pnlPOMas = New System.Windows.Forms.Panel()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CustToolBar.SuspendLayout()
        Me.pnlPORecv.SuspendLayout()
        CType(Me.dgAlusta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPOReceivings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPOMas.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustToolBar
        '
        CustToolBar.AddNewItem = Nothing
        CustToolBar.CountItem = Nothing
        CustToolBar.DeleteItem = Nothing
        CustToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.CmdCancel, Me.ToolStripSeparator5})
        CustToolBar.Location = New System.Drawing.Point(0, 0)
        CustToolBar.MoveFirstItem = Nothing
        CustToolBar.MoveLastItem = Nothing
        CustToolBar.MoveNextItem = Nothing
        CustToolBar.MovePreviousItem = Nothing
        CustToolBar.Name = "CustToolBar"
        CustToolBar.PositionItem = Nothing
        CustToolBar.Size = New System.Drawing.Size(913, 25)
        CustToolBar.TabIndex = 1
        CustToolBar.Text = "BindingNavigator1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'CmdCancel
        '
        Me.CmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(44, 22)
        Me.CmdCancel.Text = "Reset"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'txtPSlipNumber
        '
        Me.txtPSlipNumber.Location = New System.Drawing.Point(97, 33)
        Me.txtPSlipNumber.Name = "txtPSlipNumber"
        Me.txtPSlipNumber.Size = New System.Drawing.Size(137, 20)
        Me.txtPSlipNumber.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PSlip Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PSlip Date:"
        '
        'txtPONumber
        '
        Me.txtPONumber.Location = New System.Drawing.Point(97, 102)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(137, 20)
        Me.txtPONumber.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PO Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Supplier:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Buyer:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "PO Date:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(364, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "User Name:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(364, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "PO Status:"
        '
        'txtPODate
        '
        Me.txtPODate.Location = New System.Drawing.Point(58, 57)
        Me.txtPODate.Name = "txtPODate"
        Me.txtPODate.Size = New System.Drawing.Size(222, 20)
        Me.txtPODate.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(464, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(58, 6)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(222, 21)
        Me.cmbSupplier.TabIndex = 21
        '
        'cmbBuyer
        '
        Me.cmbBuyer.FormattingEnabled = True
        Me.cmbBuyer.Location = New System.Drawing.Point(58, 31)
        Me.cmbBuyer.Name = "cmbBuyer"
        Me.cmbBuyer.Size = New System.Drawing.Size(222, 21)
        Me.cmbBuyer.TabIndex = 22
        '
        'cmbUser
        '
        Me.cmbUser.FormattingEnabled = True
        Me.cmbUser.Location = New System.Drawing.Point(430, 5)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(211, 21)
        Me.cmbUser.TabIndex = 23
        '
        'cmbPOStatus
        '
        Me.cmbPOStatus.FormattingEnabled = True
        Me.cmbPOStatus.Items.AddRange(New Object() {"Open", "Cancelled", "Accepted", "Amendment"})
        Me.cmbPOStatus.Location = New System.Drawing.Point(431, 31)
        Me.cmbPOStatus.Name = "cmbPOStatus"
        Me.cmbPOStatus.Size = New System.Drawing.Size(211, 21)
        Me.cmbPOStatus.TabIndex = 24
        '
        'cmbPOType
        '
        Me.cmbPOType.FormattingEnabled = True
        Me.cmbPOType.Items.AddRange(New Object() {"Calibration/Testing", "Components", "General", "Grinding", "Lab Supplies (Matl/Product)", "Processing", "Raw Material", "Sub-Contracting", "Tooling"})
        Me.cmbPOType.Location = New System.Drawing.Point(431, 57)
        Me.cmbPOType.Name = "cmbPOType"
        Me.cmbPOType.Size = New System.Drawing.Size(211, 21)
        Me.cmbPOType.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(364, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "PO Type:"
        '
        'dtPSlipDate
        '
        Me.dtPSlipDate.Checked = False
        Me.dtPSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPSlipDate.Location = New System.Drawing.Point(97, 57)
        Me.dtPSlipDate.Name = "dtPSlipDate"
        Me.dtPSlipDate.Size = New System.Drawing.Size(137, 20)
        Me.dtPSlipDate.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Rec. Date"
        '
        'dtRecDate
        '
        Me.dtRecDate.Checked = False
        Me.dtRecDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtRecDate.Location = New System.Drawing.Point(97, 80)
        Me.dtRecDate.Name = "dtRecDate"
        Me.dtRecDate.Size = New System.Drawing.Size(137, 20)
        Me.dtRecDate.TabIndex = 29
        '
        'btnAccAll
        '
        Me.btnAccAll.Location = New System.Drawing.Point(626, 2)
        Me.btnAccAll.Name = "btnAccAll"
        Me.btnAccAll.Size = New System.Drawing.Size(75, 23)
        Me.btnAccAll.TabIndex = 31
        Me.btnAccAll.Text = "Accept All"
        '
        'pnlPORecv
        '
        Me.pnlPORecv.Controls.Add(Me.dgAlusta)
        Me.pnlPORecv.Controls.Add(Me.SwPrice)
        Me.pnlPORecv.Controls.Add(Me.Panel1)
        Me.pnlPORecv.Controls.Add(Me.btnDelRecv)
        Me.pnlPORecv.Controls.Add(Me.dgPODetails)
        Me.pnlPORecv.Controls.Add(Me.dgPOReceivings)
        Me.pnlPORecv.Controls.Add(Me.txtTotalPOQty)
        Me.pnlPORecv.Controls.Add(Me.Label10)
        Me.pnlPORecv.Controls.Add(Me.Label13)
        Me.pnlPORecv.Controls.Add(Me.txtTotalPOValue)
        Me.pnlPORecv.Controls.Add(Me.Label12)
        Me.pnlPORecv.Controls.Add(Me.txtTotalRecQty)
        Me.pnlPORecv.Controls.Add(Me.Label11)
        Me.pnlPORecv.Controls.Add(Me.txtTotalRecValue)
        Me.pnlPORecv.Location = New System.Drawing.Point(12, 134)
        Me.pnlPORecv.Name = "pnlPORecv"
        Me.pnlPORecv.Size = New System.Drawing.Size(892, 441)
        Me.pnlPORecv.TabIndex = 30
        '
        'dgAlusta
        '
        Me.dgAlusta.AllowUserToAddRows = False
        Me.dgAlusta.AllowUserToDeleteRows = False
        Me.dgAlusta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAlusta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LACDATA, Me.ENTPONo, Me.ENTLAC, Me.ENTDOR, Me.ENTSUPP, Me.ENTDEVISE, Me.ENTCODETAXE, Me.SwENTHT, Me.ENTTTC, Me.POReqBy, Me.ENTRequester, Me.ENTBuyer, Me.ENTPOStatus, Me.ENTPODate, Me.ENTPOModDate, Me.LINPONo, Me.LINPOType, Me.LINPOItem, Me.LINPOQty, Me.LINPOUM, Me.LINTotalPrice, Me.LINTotPriceConf, Me.LINHT, Me.LINRemise, Me.LINProdID, Me.LINProdDescr, Me.LINGLCode, Me.LINEtablissement, Me.LINCostCenter, Me.LINFamille, Me.LINSUPP, Me.LINCommande, Me.LINCapexNo, Me.LINCapexDescr, Me.LINStatus, Me.LINSolde, Me.RECPONo, Me.RECLine, Me.RECNo, Me.RECQty, Me.RECNET, Me.ARECDate, Me.RECBarCode, Me.RECSTATUS, Me.ADocRecvNo, Me.ARecvMatlWeight, Me.AAccpToPay, Me.ARecQtyAccp, Me.AApprInsp, Me.AApprRecvToPay, Me.APayInvDate})
        Me.dgAlusta.Location = New System.Drawing.Point(20, 52)
        Me.dgAlusta.Name = "dgAlusta"
        Me.dgAlusta.ReadOnly = True
        Me.dgAlusta.Size = New System.Drawing.Size(832, 90)
        Me.dgAlusta.TabIndex = 207
        Me.dgAlusta.Visible = False
        '
        'LACDATA
        '
        Me.LACDATA.HeaderText = "LACDATA"
        Me.LACDATA.Name = "LACDATA"
        Me.LACDATA.ReadOnly = True
        Me.LACDATA.Width = 2000
        '
        'ENTPONo
        '
        Me.ENTPONo.HeaderText = "ENTPONo"
        Me.ENTPONo.MinimumWidth = 2
        Me.ENTPONo.Name = "ENTPONo"
        Me.ENTPONo.ReadOnly = True
        Me.ENTPONo.Visible = False
        Me.ENTPONo.Width = 5
        '
        'ENTLAC
        '
        Me.ENTLAC.HeaderText = "ENTLAC"
        Me.ENTLAC.Name = "ENTLAC"
        Me.ENTLAC.ReadOnly = True
        Me.ENTLAC.Visible = False
        '
        'ENTDOR
        '
        Me.ENTDOR.HeaderText = "ENTDOR"
        Me.ENTDOR.Name = "ENTDOR"
        Me.ENTDOR.ReadOnly = True
        Me.ENTDOR.Visible = False
        '
        'ENTSUPP
        '
        Me.ENTSUPP.HeaderText = "ENTSUPP"
        Me.ENTSUPP.Name = "ENTSUPP"
        Me.ENTSUPP.ReadOnly = True
        Me.ENTSUPP.Visible = False
        '
        'ENTDEVISE
        '
        Me.ENTDEVISE.HeaderText = "ENTDEVISE"
        Me.ENTDEVISE.Name = "ENTDEVISE"
        Me.ENTDEVISE.ReadOnly = True
        Me.ENTDEVISE.Visible = False
        '
        'ENTCODETAXE
        '
        Me.ENTCODETAXE.HeaderText = "ENTCODETAXE"
        Me.ENTCODETAXE.Name = "ENTCODETAXE"
        Me.ENTCODETAXE.ReadOnly = True
        Me.ENTCODETAXE.Visible = False
        '
        'SwENTHT
        '
        Me.SwENTHT.HeaderText = "SwENTHT"
        Me.SwENTHT.Name = "SwENTHT"
        Me.SwENTHT.ReadOnly = True
        Me.SwENTHT.Visible = False
        '
        'ENTTTC
        '
        Me.ENTTTC.HeaderText = "ENTTTC"
        Me.ENTTTC.Name = "ENTTTC"
        Me.ENTTTC.ReadOnly = True
        Me.ENTTTC.Visible = False
        '
        'POReqBy
        '
        Me.POReqBy.HeaderText = "POReqBy"
        Me.POReqBy.Name = "POReqBy"
        Me.POReqBy.ReadOnly = True
        Me.POReqBy.Visible = False
        '
        'ENTRequester
        '
        Me.ENTRequester.HeaderText = "ENTRequester"
        Me.ENTRequester.Name = "ENTRequester"
        Me.ENTRequester.ReadOnly = True
        Me.ENTRequester.Visible = False
        '
        'ENTBuyer
        '
        Me.ENTBuyer.HeaderText = "ENTBuyer"
        Me.ENTBuyer.Name = "ENTBuyer"
        Me.ENTBuyer.ReadOnly = True
        Me.ENTBuyer.Visible = False
        '
        'ENTPOStatus
        '
        Me.ENTPOStatus.HeaderText = "ENTPOStatus"
        Me.ENTPOStatus.Name = "ENTPOStatus"
        Me.ENTPOStatus.ReadOnly = True
        Me.ENTPOStatus.Visible = False
        '
        'ENTPODate
        '
        Me.ENTPODate.HeaderText = "ENTPODate"
        Me.ENTPODate.Name = "ENTPODate"
        Me.ENTPODate.ReadOnly = True
        Me.ENTPODate.Visible = False
        '
        'ENTPOModDate
        '
        Me.ENTPOModDate.HeaderText = "ENTPOModDate"
        Me.ENTPOModDate.Name = "ENTPOModDate"
        Me.ENTPOModDate.ReadOnly = True
        Me.ENTPOModDate.Visible = False
        '
        'LINPONo
        '
        Me.LINPONo.HeaderText = "LINPONo"
        Me.LINPONo.Name = "LINPONo"
        Me.LINPONo.ReadOnly = True
        Me.LINPONo.Visible = False
        '
        'LINPOType
        '
        Me.LINPOType.HeaderText = "LINPOType"
        Me.LINPOType.Name = "LINPOType"
        Me.LINPOType.ReadOnly = True
        Me.LINPOType.Visible = False
        '
        'LINPOItem
        '
        Me.LINPOItem.HeaderText = "LINPOItem"
        Me.LINPOItem.Name = "LINPOItem"
        Me.LINPOItem.ReadOnly = True
        Me.LINPOItem.Visible = False
        '
        'LINPOQty
        '
        Me.LINPOQty.HeaderText = "LINPOQty"
        Me.LINPOQty.Name = "LINPOQty"
        Me.LINPOQty.ReadOnly = True
        Me.LINPOQty.Visible = False
        '
        'LINPOUM
        '
        Me.LINPOUM.HeaderText = "LINPOUM"
        Me.LINPOUM.Name = "LINPOUM"
        Me.LINPOUM.ReadOnly = True
        Me.LINPOUM.Visible = False
        '
        'LINTotalPrice
        '
        Me.LINTotalPrice.HeaderText = "LINTotalPrice"
        Me.LINTotalPrice.Name = "LINTotalPrice"
        Me.LINTotalPrice.ReadOnly = True
        Me.LINTotalPrice.Visible = False
        '
        'LINTotPriceConf
        '
        Me.LINTotPriceConf.HeaderText = "LINTotPriceConf"
        Me.LINTotPriceConf.Name = "LINTotPriceConf"
        Me.LINTotPriceConf.ReadOnly = True
        Me.LINTotPriceConf.Visible = False
        '
        'LINHT
        '
        Me.LINHT.HeaderText = "LINHT"
        Me.LINHT.Name = "LINHT"
        Me.LINHT.ReadOnly = True
        Me.LINHT.Visible = False
        '
        'LINRemise
        '
        Me.LINRemise.HeaderText = "LINRemise"
        Me.LINRemise.Name = "LINRemise"
        Me.LINRemise.ReadOnly = True
        Me.LINRemise.Visible = False
        '
        'LINProdID
        '
        Me.LINProdID.HeaderText = "LINProdID"
        Me.LINProdID.Name = "LINProdID"
        Me.LINProdID.ReadOnly = True
        Me.LINProdID.Visible = False
        '
        'LINProdDescr
        '
        Me.LINProdDescr.HeaderText = "LINProdDescr"
        Me.LINProdDescr.Name = "LINProdDescr"
        Me.LINProdDescr.ReadOnly = True
        Me.LINProdDescr.Visible = False
        '
        'LINGLCode
        '
        Me.LINGLCode.HeaderText = "LINGLCode"
        Me.LINGLCode.Name = "LINGLCode"
        Me.LINGLCode.ReadOnly = True
        Me.LINGLCode.Visible = False
        '
        'LINEtablissement
        '
        Me.LINEtablissement.HeaderText = "LINEtablissement"
        Me.LINEtablissement.Name = "LINEtablissement"
        Me.LINEtablissement.ReadOnly = True
        Me.LINEtablissement.Visible = False
        '
        'LINCostCenter
        '
        Me.LINCostCenter.HeaderText = "LINCostCenter"
        Me.LINCostCenter.Name = "LINCostCenter"
        Me.LINCostCenter.ReadOnly = True
        Me.LINCostCenter.Visible = False
        '
        'LINFamille
        '
        Me.LINFamille.HeaderText = "LINFamille"
        Me.LINFamille.Name = "LINFamille"
        Me.LINFamille.ReadOnly = True
        Me.LINFamille.Visible = False
        '
        'LINSUPP
        '
        Me.LINSUPP.HeaderText = "LINSUPP"
        Me.LINSUPP.Name = "LINSUPP"
        Me.LINSUPP.ReadOnly = True
        Me.LINSUPP.Visible = False
        '
        'LINCommande
        '
        Me.LINCommande.HeaderText = "LINCommande"
        Me.LINCommande.Name = "LINCommande"
        Me.LINCommande.ReadOnly = True
        Me.LINCommande.Visible = False
        '
        'LINCapexNo
        '
        Me.LINCapexNo.HeaderText = "LINCapexNo"
        Me.LINCapexNo.Name = "LINCapexNo"
        Me.LINCapexNo.ReadOnly = True
        Me.LINCapexNo.Visible = False
        '
        'LINCapexDescr
        '
        Me.LINCapexDescr.HeaderText = "LINCapexDescr"
        Me.LINCapexDescr.Name = "LINCapexDescr"
        Me.LINCapexDescr.ReadOnly = True
        Me.LINCapexDescr.Visible = False
        '
        'LINStatus
        '
        Me.LINStatus.HeaderText = "LINStatus"
        Me.LINStatus.Name = "LINStatus"
        Me.LINStatus.ReadOnly = True
        Me.LINStatus.Visible = False
        '
        'LINSolde
        '
        Me.LINSolde.HeaderText = "LINSolde"
        Me.LINSolde.Name = "LINSolde"
        Me.LINSolde.ReadOnly = True
        Me.LINSolde.Visible = False
        '
        'RECPONo
        '
        Me.RECPONo.HeaderText = "RECPONo"
        Me.RECPONo.Name = "RECPONo"
        Me.RECPONo.ReadOnly = True
        Me.RECPONo.Visible = False
        '
        'RECLine
        '
        Me.RECLine.HeaderText = "RECLine"
        Me.RECLine.Name = "RECLine"
        Me.RECLine.ReadOnly = True
        Me.RECLine.Visible = False
        '
        'RECNo
        '
        Me.RECNo.HeaderText = "RECNo"
        Me.RECNo.Name = "RECNo"
        Me.RECNo.ReadOnly = True
        Me.RECNo.Visible = False
        '
        'RECQty
        '
        Me.RECQty.HeaderText = "RECQty"
        Me.RECQty.Name = "RECQty"
        Me.RECQty.ReadOnly = True
        Me.RECQty.Visible = False
        '
        'RECNET
        '
        Me.RECNET.HeaderText = "RECNET"
        Me.RECNET.Name = "RECNET"
        Me.RECNET.ReadOnly = True
        Me.RECNET.Visible = False
        '
        'ARECDate
        '
        Me.ARECDate.HeaderText = "ARECDate"
        Me.ARECDate.Name = "ARECDate"
        Me.ARECDate.ReadOnly = True
        Me.ARECDate.Visible = False
        '
        'RECBarCode
        '
        Me.RECBarCode.HeaderText = "RECBarCode"
        Me.RECBarCode.Name = "RECBarCode"
        Me.RECBarCode.ReadOnly = True
        Me.RECBarCode.Visible = False
        '
        'RECSTATUS
        '
        Me.RECSTATUS.HeaderText = "RECSTATUS"
        Me.RECSTATUS.Name = "RECSTATUS"
        Me.RECSTATUS.ReadOnly = True
        '
        'ADocRecvNo
        '
        Me.ADocRecvNo.HeaderText = "ADocRecvNo"
        Me.ADocRecvNo.Name = "ADocRecvNo"
        Me.ADocRecvNo.ReadOnly = True
        '
        'ARecvMatlWeight
        '
        Me.ARecvMatlWeight.HeaderText = "ARecvMatlWeight"
        Me.ARecvMatlWeight.Name = "ARecvMatlWeight"
        Me.ARecvMatlWeight.ReadOnly = True
        '
        'AAccpToPay
        '
        Me.AAccpToPay.HeaderText = "AAccpToPay"
        Me.AAccpToPay.Name = "AAccpToPay"
        Me.AAccpToPay.ReadOnly = True
        Me.AAccpToPay.Visible = False
        '
        'ARecQtyAccp
        '
        Me.ARecQtyAccp.HeaderText = "ARecQtyAccp"
        Me.ARecQtyAccp.Name = "ARecQtyAccp"
        Me.ARecQtyAccp.ReadOnly = True
        Me.ARecQtyAccp.Visible = False
        '
        'AApprInsp
        '
        Me.AApprInsp.HeaderText = "AApprInsp"
        Me.AApprInsp.Name = "AApprInsp"
        Me.AApprInsp.ReadOnly = True
        Me.AApprInsp.Visible = False
        '
        'AApprRecvToPay
        '
        Me.AApprRecvToPay.HeaderText = "AApprRecvToPay"
        Me.AApprRecvToPay.Name = "AApprRecvToPay"
        Me.AApprRecvToPay.ReadOnly = True
        Me.AApprRecvToPay.Visible = False
        '
        'APayInvDate
        '
        Me.APayInvDate.HeaderText = "APayInvDate"
        Me.APayInvDate.Name = "APayInvDate"
        Me.APayInvDate.ReadOnly = True
        Me.APayInvDate.Visible = False
        '
        'SwPrice
        '
        Me.SwPrice.BackColor = System.Drawing.Color.Red
        Me.SwPrice.Enabled = False
        Me.SwPrice.ForeColor = System.Drawing.Color.Black
        Me.SwPrice.Location = New System.Drawing.Point(345, 215)
        Me.SwPrice.Name = "SwPrice"
        Me.SwPrice.ReadOnly = True
        Me.SwPrice.Size = New System.Drawing.Size(74, 20)
        Me.SwPrice.TabIndex = 41
        Me.SwPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SwPrice.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(3, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 10)
        Me.Panel1.TabIndex = 30
        '
        'btnDelRecv
        '
        Me.btnDelRecv.Location = New System.Drawing.Point(3, 215)
        Me.btnDelRecv.Name = "btnDelRecv"
        Me.btnDelRecv.Size = New System.Drawing.Size(75, 23)
        Me.btnDelRecv.TabIndex = 29
        Me.btnDelRecv.Text = "Delete"
        '
        'dgPODetails
        '
        Me.dgPODetails.AllowUserToAddRows = False
        Me.dgPODetails.AllowUserToDeleteRows = False
        Me.dgPODetails.AllowUserToResizeColumns = False
        Me.dgPODetails.AllowUserToResizeRows = False
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPODetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgPODetails.ColumnHeadersHeight = 20
        Me.dgPODetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPODetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PODetails, Me.POItemDet, Me.ProdDesc, Me.POMpoNo, Me.POQtyDet, Me.POUM, Me.POPrice, Me.PODiscount, Me.TotalValue})
        Me.dgPODetails.Location = New System.Drawing.Point(3, 3)
        Me.dgPODetails.Name = "dgPODetails"
        Me.dgPODetails.ReadOnly = True
        Me.dgPODetails.RowHeadersWidth = 20
        Me.dgPODetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgPODetails.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPODetails.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPODetails.RowTemplate.Height = 17
        Me.dgPODetails.Size = New System.Drawing.Size(885, 165)
        Me.dgPODetails.TabIndex = 18
        Me.dgPODetails.Text = "dgPODetails"
        '
        'PODetails
        '
        Me.PODetails.HeaderText = "PODetails"
        Me.PODetails.MinimumWidth = 2
        Me.PODetails.Name = "PODetails"
        Me.PODetails.ReadOnly = True
        Me.PODetails.Visible = False
        Me.PODetails.Width = 2
        '
        'POItemDet
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.POItemDet.DefaultCellStyle = DataGridViewCellStyle38
        Me.POItemDet.HeaderText = "PO Item"
        Me.POItemDet.Name = "POItemDet"
        Me.POItemDet.ReadOnly = True
        Me.POItemDet.Width = 60
        '
        'ProdDesc
        '
        Me.ProdDesc.HeaderText = "Prod Desc"
        Me.ProdDesc.Name = "ProdDesc"
        Me.ProdDesc.ReadOnly = True
        Me.ProdDesc.Width = 240
        '
        'POMpoNo
        '
        Me.POMpoNo.HeaderText = "PO MpoNo"
        Me.POMpoNo.Name = "POMpoNo"
        Me.POMpoNo.ReadOnly = True
        Me.POMpoNo.Width = 110
        '
        'POQtyDet
        '
        Me.POQtyDet.HeaderText = "PO Qty"
        Me.POQtyDet.Name = "POQtyDet"
        Me.POQtyDet.ReadOnly = True
        Me.POQtyDet.Width = 90
        '
        'POUM
        '
        Me.POUM.FillWeight = 70.0!
        Me.POUM.HeaderText = "PO UM"
        Me.POUM.Name = "POUM"
        Me.POUM.ReadOnly = True
        Me.POUM.Width = 70
        '
        'POPrice
        '
        DataGridViewCellStyle39.Format = "C2"
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle39.NullValue = Nothing
        Me.POPrice.DefaultCellStyle = DataGridViewCellStyle39
        Me.POPrice.HeaderText = "PO Price"
        Me.POPrice.Name = "POPrice"
        Me.POPrice.ReadOnly = True
        Me.POPrice.Width = 90
        '
        'PODiscount
        '
        Me.PODiscount.HeaderText = "PO Discount"
        Me.PODiscount.Name = "PODiscount"
        Me.PODiscount.ReadOnly = True
        Me.PODiscount.Width = 70
        '
        'TotalValue
        '
        DataGridViewCellStyle40.Format = "C2"
        DataGridViewCellStyle40.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle40.NullValue = Nothing
        Me.TotalValue.DefaultCellStyle = DataGridViewCellStyle40
        Me.TotalValue.HeaderText = "Total Value"
        Me.TotalValue.Name = "TotalValue"
        Me.TotalValue.ReadOnly = True
        Me.TotalValue.Width = 110
        '
        'dgPOReceivings
        '
        Me.dgPOReceivings.AllowUserToDeleteRows = False
        Me.dgPOReceivings.AllowUserToResizeColumns = False
        Me.dgPOReceivings.AllowUserToResizeRows = False
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPOReceivings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle41
        Me.dgPOReceivings.ColumnHeadersHeight = 20
        Me.dgPOReceivings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPOReceivings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.POItemRecv, Me.RecDate, Me.POMpoNoRecv, Me.PSlipNum, Me.PSlipDate, Me.PSlipQty, Me.PSlipUM, Me.PSlipPrice, Me.PSlipDiscount, Me.AccpToPay, Me.AlustaBarCode, Me.TotalValueRecv, Me.PoRecvID, Me.ApprRecvToPay})
        Me.dgPOReceivings.Location = New System.Drawing.Point(3, 244)
        Me.dgPOReceivings.Name = "dgPOReceivings"
        Me.dgPOReceivings.RowHeadersWidth = 20
        Me.dgPOReceivings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgPOReceivings.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgPOReceivings.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPOReceivings.RowTemplate.Height = 20
        Me.dgPOReceivings.Size = New System.Drawing.Size(886, 161)
        Me.dgPOReceivings.TabIndex = 20
        Me.dgPOReceivings.Text = "dgPORecDetails"
        '
        'POItemRecv
        '
        Me.POItemRecv.Frozen = True
        Me.POItemRecv.HeaderText = "PO Item"
        Me.POItemRecv.Name = "POItemRecv"
        Me.POItemRecv.Width = 50
        '
        'RecDate
        '
        DataGridViewCellStyle42.Format = "d"
        DataGridViewCellStyle42.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle42.NullValue = Nothing
        Me.RecDate.DefaultCellStyle = DataGridViewCellStyle42
        Me.RecDate.Frozen = True
        Me.RecDate.HeaderText = "Rec. Date"
        Me.RecDate.Name = "RecDate"
        Me.RecDate.ReadOnly = True
        Me.RecDate.Width = 70
        '
        'POMpoNoRecv
        '
        Me.POMpoNoRecv.Frozen = True
        Me.POMpoNoRecv.HeaderText = "PO MpoNo"
        Me.POMpoNoRecv.Name = "POMpoNoRecv"
        Me.POMpoNoRecv.Width = 80
        '
        'PSlipNum
        '
        Me.PSlipNum.Frozen = True
        Me.PSlipNum.HeaderText = "PSlip Num"
        Me.PSlipNum.Name = "PSlipNum"
        Me.PSlipNum.ReadOnly = True
        Me.PSlipNum.Width = 70
        '
        'PSlipDate
        '
        DataGridViewCellStyle43.Format = "d"
        DataGridViewCellStyle43.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle43.NullValue = Nothing
        Me.PSlipDate.DefaultCellStyle = DataGridViewCellStyle43
        Me.PSlipDate.Frozen = True
        Me.PSlipDate.HeaderText = "PSlip Date"
        Me.PSlipDate.Name = "PSlipDate"
        Me.PSlipDate.ReadOnly = True
        Me.PSlipDate.Width = 70
        '
        'PSlipQty
        '
        DataGridViewCellStyle44.Format = "N2"
        DataGridViewCellStyle44.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle44.NullValue = Nothing
        Me.PSlipQty.DefaultCellStyle = DataGridViewCellStyle44
        Me.PSlipQty.Frozen = True
        Me.PSlipQty.HeaderText = "PSlip Qty"
        Me.PSlipQty.Name = "PSlipQty"
        Me.PSlipQty.Width = 60
        '
        'PSlipUM
        '
        Me.PSlipUM.Frozen = True
        Me.PSlipUM.HeaderText = "PSlip UM"
        Me.PSlipUM.Name = "PSlipUM"
        Me.PSlipUM.Width = 60
        '
        'PSlipPrice
        '
        DataGridViewCellStyle45.Format = "C2"
        DataGridViewCellStyle45.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle45.NullValue = Nothing
        Me.PSlipPrice.DefaultCellStyle = DataGridViewCellStyle45
        Me.PSlipPrice.Frozen = True
        Me.PSlipPrice.HeaderText = "PSlip Price"
        Me.PSlipPrice.Name = "PSlipPrice"
        Me.PSlipPrice.Width = 60
        '
        'PSlipDiscount
        '
        Me.PSlipDiscount.Frozen = True
        Me.PSlipDiscount.HeaderText = "Discount"
        Me.PSlipDiscount.Name = "PSlipDiscount"
        Me.PSlipDiscount.Width = 60
        '
        'AccpToPay
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle46.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle46.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle46.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle46.SelectionForeColor = System.Drawing.Color.Black
        Me.AccpToPay.DefaultCellStyle = DataGridViewCellStyle46
        Me.AccpToPay.Frozen = True
        Me.AccpToPay.HeaderText = "Acc. Recv."
        Me.AccpToPay.Name = "AccpToPay"
        Me.AccpToPay.Width = 60
        '
        'AlustaBarCode
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlustaBarCode.DefaultCellStyle = DataGridViewCellStyle47
        Me.AlustaBarCode.HeaderText = "PSlip BarCode"
        Me.AlustaBarCode.Name = "AlustaBarCode"
        Me.AlustaBarCode.Width = 120
        '
        'TotalValueRecv
        '
        DataGridViewCellStyle48.Format = "C2"
        DataGridViewCellStyle48.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle48.NullValue = Nothing
        Me.TotalValueRecv.DefaultCellStyle = DataGridViewCellStyle48
        Me.TotalValueRecv.HeaderText = "Total Value"
        Me.TotalValueRecv.Name = "TotalValueRecv"
        Me.TotalValueRecv.Width = 90
        '
        'PoRecvID
        '
        Me.PoRecvID.HeaderText = "PoRecvID"
        Me.PoRecvID.MinimumWidth = 2
        Me.PoRecvID.Name = "PoRecvID"
        Me.PoRecvID.Visible = False
        Me.PoRecvID.Width = 2
        '
        'ApprRecvToPay
        '
        Me.ApprRecvToPay.HeaderText = "ApprRecvToPay"
        Me.ApprRecvToPay.Name = "ApprRecvToPay"
        Me.ApprRecvToPay.Visible = False
        '
        'txtTotalPOQty
        '
        Me.txtTotalPOQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPOQty.Location = New System.Drawing.Point(435, 174)
        Me.txtTotalPOQty.Name = "txtTotalPOQty"
        Me.txtTotalPOQty.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPOQty.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(653, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "TOTAL PO VALUE:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(331, 177)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "TOTAL PO QTY:"
        '
        'txtTotalPOValue
        '
        Me.txtTotalPOValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPOValue.Location = New System.Drawing.Point(771, 174)
        Me.txtTotalPOValue.Name = "txtTotalPOValue"
        Me.txtTotalPOValue.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPOValue.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(645, 417)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "TOTAL REC VALUE:"
        '
        'txtTotalRecQty
        '
        Me.txtTotalRecQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRecQty.Location = New System.Drawing.Point(435, 414)
        Me.txtTotalRecQty.Name = "txtTotalRecQty"
        Me.txtTotalRecQty.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalRecQty.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(324, 417)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "TOTAL REC QTY:"
        '
        'txtTotalRecValue
        '
        Me.txtTotalRecValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRecValue.Location = New System.Drawing.Point(771, 414)
        Me.txtTotalRecValue.Name = "txtTotalRecValue"
        Me.txtTotalRecValue.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalRecValue.TabIndex = 24
        '
        'btnRecAll
        '
        Me.btnRecAll.Location = New System.Drawing.Point(813, 0)
        Me.btnRecAll.Name = "btnRecAll"
        Me.btnRecAll.Size = New System.Drawing.Size(91, 23)
        Me.btnRecAll.TabIndex = 32
        Me.btnRecAll.Text = "Recv. Matl/Proc"
        '
        'btnFindPO
        '
        Me.btnFindPO.Location = New System.Drawing.Point(259, 0)
        Me.btnFindPO.Name = "btnFindPO"
        Me.btnFindPO.Size = New System.Drawing.Size(75, 23)
        Me.btnFindPO.TabIndex = 33
        Me.btnFindPO.Text = "Find PO."
        '
        'pnlPOMas
        '
        Me.pnlPOMas.Controls.Add(Me.Label4)
        Me.pnlPOMas.Controls.Add(Me.Label7)
        Me.pnlPOMas.Controls.Add(Me.cmbSupplier)
        Me.pnlPOMas.Controls.Add(Me.cmbPOType)
        Me.pnlPOMas.Controls.Add(Me.Label5)
        Me.pnlPOMas.Controls.Add(Me.Label8)
        Me.pnlPOMas.Controls.Add(Me.Label14)
        Me.pnlPOMas.Controls.Add(Me.cmbUser)
        Me.pnlPOMas.Controls.Add(Me.cmbBuyer)
        Me.pnlPOMas.Controls.Add(Me.txtPODate)
        Me.pnlPOMas.Controls.Add(Me.cmbPOStatus)
        Me.pnlPOMas.Controls.Add(Me.Label6)
        Me.pnlPOMas.Location = New System.Drawing.Point(259, 30)
        Me.pnlPOMas.Name = "pnlPOMas"
        Me.pnlPOMas.Size = New System.Drawing.Size(645, 92)
        Me.pnlPOMas.TabIndex = 34
        '
        'frmPOReceiving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 587)
        Me.Controls.Add(Me.pnlPOMas)
        Me.Controls.Add(Me.btnFindPO)
        Me.Controls.Add(Me.btnRecAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtRecDate)
        Me.Controls.Add(Me.pnlPORecv)
        Me.Controls.Add(Me.txtPONumber)
        Me.Controls.Add(Me.btnAccAll)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtPSlipDate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(CustToolBar)
        Me.Controls.Add(Me.txtPSlipNumber)
        Me.Name = "frmPOReceiving"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Receiving Purchase Order"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CustToolBar.ResumeLayout(False)
        CustToolBar.PerformLayout()
        Me.pnlPORecv.ResumeLayout(False)
        Me.pnlPORecv.PerformLayout()
        CType(Me.dgAlusta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPOReceivings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPOMas.ResumeLayout(False)
        Me.pnlPOMas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CmdCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPSlipNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPODate As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBuyer As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUser As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dtPSlipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtRecDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAccAll As System.Windows.Forms.Button
    Friend WithEvents cmbPOType As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlPORecv As System.Windows.Forms.Panel
    Friend WithEvents dgPODetails As System.Windows.Forms.DataGridView
    Friend WithEvents dgPOReceivings As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalPOQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPOValue As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalRecQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTotalRecValue As System.Windows.Forms.TextBox
    Friend WithEvents btnDelRecv As System.Windows.Forms.Button
    Friend WithEvents btnRecAll As System.Windows.Forms.Button
    Friend WithEvents btnFindPO As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPOMas As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPrice As System.Windows.Forms.TextBox
    Friend WithEvents PODetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POItemDet As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ProdDesc As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents POMpoNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents POQtyDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POUM As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents POPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POItemRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POMpoNoRecv As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents PSlipNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PSlipDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PSlipQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PSlipUM As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents PSlipPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PSlipDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccpToPay As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AlustaBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValueRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoRecvID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprRecvToPay As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgAlusta As System.Windows.Forms.DataGridView
    Friend WithEvents LACDATA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTLAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTSUPP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTDEVISE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTCODETAXE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwENTHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTTTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POReqBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTRequester As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTBuyer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTPOStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENTPOModDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINPOType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINPOItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINPOQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINPOUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINTotalPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINTotPriceConf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINRemise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINProdID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINGLCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINEtablissement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINCostCenter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINFamille As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINSUPP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINCommande As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINCapexNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINCapexDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LINSolde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECPONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECNET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARECDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECSTATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADocRecvNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARecvMatlWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AAccpToPay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ARecQtyAccp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AApprInsp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AApprRecvToPay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APayInvDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
