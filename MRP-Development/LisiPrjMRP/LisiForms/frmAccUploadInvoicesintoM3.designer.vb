<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccUploadInvoicesintoM3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgMPO = New System.Windows.Forms.DataGridView()
        Me.LACData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2ShipShortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipORDRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2MMITDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2InvDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2StDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2StStockClasification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2InvPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2CoCPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2ShipVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2InvFOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2DelivStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PslipCustPoContr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2InvPosted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2TextNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2MpoRMCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I2StPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipORDRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5ShipShortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvCodeM3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvM3TwoCust = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5MMITDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5StDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5StStockClasification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvAccpacGL1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvAccpacGL2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvAccpacGL3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvValCh1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvValCh2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvValCh3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5CoCPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5ShipVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvFOB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5TextNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PoNoDeliv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5DelivStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5InvPosted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PslipInterCoPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5MpoRMCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I5StPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6CONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6WHLO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6MMITDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6STAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6StDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6WHSL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6StPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6MpoPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6StStockClasification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I6MpoRMCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9OrderLineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9OrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9Currency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9LineStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9AlliasNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9DeliveryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9PlannedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9CustCodeM3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9MMITDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9OrdItemQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I9CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99DONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99DOLineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99DODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99Devise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99LineStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99PartITDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99PlanDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99WHSE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.I99ITNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.txtCOBatch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.RdI2 = New System.Windows.Forms.RadioButton()
        Me.RdI6 = New System.Windows.Forms.RadioButton()
        Me.RdI5 = New System.Windows.Forms.RadioButton()
        Me.RdI9 = New System.Windows.Forms.RadioButton()
        Me.RdI99 = New System.Windows.Forms.RadioButton()
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgMPO
        '
        Me.dgMPO.AllowUserToAddRows = False
        Me.dgMPO.AllowUserToDeleteRows = False
        Me.dgMPO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMPO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMPO.ColumnHeadersHeight = 45
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LACData, Me.I2ShipShortName, Me.I2PslipORDRefNo, Me.I2PslipItem, Me.I2MMITDS, Me.I2InvDate, Me.I2MpoNo, Me.I2StDate, Me.I2DelivDate, Me.I2StStockClasification, Me.I2PslipQty, Me.I2PslipNo, Me.I2PslipType, Me.I2InvPrice, Me.I2CoCPartRev, Me.I2ShipVia, Me.I2InvFOB, Me.I2DelivStatus, Me.I2PslipCustPoContr, Me.I2PartNumber, Me.I2InvPosted, Me.I2TextNotes, Me.I2DelivQty, Me.I2MpoRMCostCDN, Me.I2StPrice, Me.I5PslipORDRefNo, Me.I5ShipShortName, Me.I5InvCodeM3, Me.I5InvM3TwoCust, Me.I5PslipItem, Me.I5MMITDS, Me.I5MpoNo, Me.I5StDate, Me.I5DelivDate, Me.I5StStockClasification, Me.I5PslipQty, Me.I5PslipNo, Me.I5InvAccpacGL1, Me.I5InvAccpacGL2, Me.I5InvAccpacGL3, Me.I5InvValCh1, Me.I5InvValCh2, Me.I5InvValCh3, Me.I5PslipType, Me.I5InvPrice, Me.I5CoCPartRev, Me.I5ShipVia, Me.I5InvFOB, Me.I5TextNotes, Me.I5PoNoDeliv, Me.I5DelivStatus, Me.I5InvPosted, Me.I5PslipInterCoPrefix, Me.I5PartNumber, Me.I5MpoRMCostCDN, Me.I5StPrice, Me.I6CONO, Me.I6WHLO, Me.I6MMITDS, Me.I6Stock, Me.I6STAG, Me.I6MpoNo, Me.I6StDate, Me.I6WHSL, Me.I6StPrice, Me.I6MpoPartRev, Me.I6PartNumber, Me.I6StStockClasification, Me.I6MpoRMCostCDN, Me.I9OrderNumber, Me.I9OrderLineNumber, Me.I9OrderDate, Me.I9Quantity, Me.I9Price, Me.I9Currency, Me.I9LineStatus, Me.I9AlliasNumber, Me.I9Name, Me.I9DeliveryDate, Me.I9PlannedDate, Me.I9OrdNumber, Me.I9CustCodeM3, Me.I9CustomerShort, Me.I9MMITDS, Me.I9OrdItemQty, Me.I9CustomerName, Me.I99DONumber, Me.I99DOLineNumber, Me.I99DODate, Me.I99DelivQty, Me.I99Price, Me.I99Devise, Me.I99LineStatus, Me.I99PartITDS, Me.I99PlanDate, Me.I99WHSE, Me.I99ITNO})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMPO.Location = New System.Drawing.Point(12, 230)
        Me.dgMPO.Name = "dgMPO"
        Me.dgMPO.ReadOnly = True
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgMPO.RowHeadersWidth = 25
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.Size = New System.Drawing.Size(1572, 631)
        Me.dgMPO.TabIndex = 55
        Me.dgMPO.Text = "DataGridView1"
        '
        'LACData
        '
        Me.LACData.HeaderText = "LAC Data"
        Me.LACData.Name = "LACData"
        Me.LACData.ReadOnly = True
        Me.LACData.Width = 2000
        '
        'I2ShipShortName
        '
        Me.I2ShipShortName.HeaderText = "I2ShipShortName"
        Me.I2ShipShortName.MinimumWidth = 2
        Me.I2ShipShortName.Name = "I2ShipShortName"
        Me.I2ShipShortName.ReadOnly = True
        Me.I2ShipShortName.Visible = False
        Me.I2ShipShortName.Width = 2
        '
        'I2PslipORDRefNo
        '
        Me.I2PslipORDRefNo.HeaderText = "I2PslipORDRefNo"
        Me.I2PslipORDRefNo.MinimumWidth = 2
        Me.I2PslipORDRefNo.Name = "I2PslipORDRefNo"
        Me.I2PslipORDRefNo.ReadOnly = True
        Me.I2PslipORDRefNo.Visible = False
        Me.I2PslipORDRefNo.Width = 2
        '
        'I2PslipItem
        '
        Me.I2PslipItem.HeaderText = "I2PslipItem"
        Me.I2PslipItem.MinimumWidth = 2
        Me.I2PslipItem.Name = "I2PslipItem"
        Me.I2PslipItem.ReadOnly = True
        Me.I2PslipItem.Visible = False
        Me.I2PslipItem.Width = 2
        '
        'I2MMITDS
        '
        Me.I2MMITDS.HeaderText = "I2MMITDS"
        Me.I2MMITDS.MinimumWidth = 2
        Me.I2MMITDS.Name = "I2MMITDS"
        Me.I2MMITDS.ReadOnly = True
        Me.I2MMITDS.Visible = False
        Me.I2MMITDS.Width = 2
        '
        'I2InvDate
        '
        Me.I2InvDate.HeaderText = "I2InvDate"
        Me.I2InvDate.MinimumWidth = 2
        Me.I2InvDate.Name = "I2InvDate"
        Me.I2InvDate.ReadOnly = True
        Me.I2InvDate.Visible = False
        Me.I2InvDate.Width = 2
        '
        'I2MpoNo
        '
        Me.I2MpoNo.HeaderText = "I2MpoNo"
        Me.I2MpoNo.MinimumWidth = 2
        Me.I2MpoNo.Name = "I2MpoNo"
        Me.I2MpoNo.ReadOnly = True
        Me.I2MpoNo.Visible = False
        Me.I2MpoNo.Width = 2
        '
        'I2StDate
        '
        Me.I2StDate.HeaderText = "I2StDate"
        Me.I2StDate.MinimumWidth = 2
        Me.I2StDate.Name = "I2StDate"
        Me.I2StDate.ReadOnly = True
        Me.I2StDate.Visible = False
        Me.I2StDate.Width = 2
        '
        'I2DelivDate
        '
        Me.I2DelivDate.HeaderText = "I2DelivDate"
        Me.I2DelivDate.MinimumWidth = 2
        Me.I2DelivDate.Name = "I2DelivDate"
        Me.I2DelivDate.ReadOnly = True
        Me.I2DelivDate.Visible = False
        Me.I2DelivDate.Width = 2
        '
        'I2StStockClasification
        '
        Me.I2StStockClasification.HeaderText = "I2StStockClasification"
        Me.I2StStockClasification.MinimumWidth = 2
        Me.I2StStockClasification.Name = "I2StStockClasification"
        Me.I2StStockClasification.ReadOnly = True
        Me.I2StStockClasification.Visible = False
        Me.I2StStockClasification.Width = 2
        '
        'I2PslipQty
        '
        Me.I2PslipQty.HeaderText = "I2PslipQty"
        Me.I2PslipQty.MinimumWidth = 2
        Me.I2PslipQty.Name = "I2PslipQty"
        Me.I2PslipQty.ReadOnly = True
        Me.I2PslipQty.Visible = False
        Me.I2PslipQty.Width = 2
        '
        'I2PslipNo
        '
        Me.I2PslipNo.HeaderText = "I2PslipNo"
        Me.I2PslipNo.MinimumWidth = 2
        Me.I2PslipNo.Name = "I2PslipNo"
        Me.I2PslipNo.ReadOnly = True
        Me.I2PslipNo.Visible = False
        Me.I2PslipNo.Width = 2
        '
        'I2PslipType
        '
        Me.I2PslipType.HeaderText = "I2PslipType"
        Me.I2PslipType.MinimumWidth = 2
        Me.I2PslipType.Name = "I2PslipType"
        Me.I2PslipType.ReadOnly = True
        Me.I2PslipType.Visible = False
        Me.I2PslipType.Width = 2
        '
        'I2InvPrice
        '
        Me.I2InvPrice.HeaderText = "I2InvPrice"
        Me.I2InvPrice.Name = "I2InvPrice"
        Me.I2InvPrice.ReadOnly = True
        Me.I2InvPrice.Visible = False
        '
        'I2CoCPartRev
        '
        Me.I2CoCPartRev.HeaderText = "I2CoCPartRev"
        Me.I2CoCPartRev.MinimumWidth = 2
        Me.I2CoCPartRev.Name = "I2CoCPartRev"
        Me.I2CoCPartRev.ReadOnly = True
        Me.I2CoCPartRev.Visible = False
        Me.I2CoCPartRev.Width = 2
        '
        'I2ShipVia
        '
        Me.I2ShipVia.HeaderText = "I2ShipVia"
        Me.I2ShipVia.MinimumWidth = 2
        Me.I2ShipVia.Name = "I2ShipVia"
        Me.I2ShipVia.ReadOnly = True
        Me.I2ShipVia.Visible = False
        Me.I2ShipVia.Width = 2
        '
        'I2InvFOB
        '
        Me.I2InvFOB.HeaderText = "I2InvFOB"
        Me.I2InvFOB.MinimumWidth = 2
        Me.I2InvFOB.Name = "I2InvFOB"
        Me.I2InvFOB.ReadOnly = True
        Me.I2InvFOB.Visible = False
        Me.I2InvFOB.Width = 2
        '
        'I2DelivStatus
        '
        Me.I2DelivStatus.HeaderText = "I2DelivStatus"
        Me.I2DelivStatus.MinimumWidth = 2
        Me.I2DelivStatus.Name = "I2DelivStatus"
        Me.I2DelivStatus.ReadOnly = True
        Me.I2DelivStatus.Visible = False
        Me.I2DelivStatus.Width = 2
        '
        'I2PslipCustPoContr
        '
        Me.I2PslipCustPoContr.HeaderText = "I2PslipCustPoContr"
        Me.I2PslipCustPoContr.MinimumWidth = 2
        Me.I2PslipCustPoContr.Name = "I2PslipCustPoContr"
        Me.I2PslipCustPoContr.ReadOnly = True
        Me.I2PslipCustPoContr.Visible = False
        Me.I2PslipCustPoContr.Width = 2
        '
        'I2PartNumber
        '
        Me.I2PartNumber.HeaderText = "I2PartNumber"
        Me.I2PartNumber.MinimumWidth = 2
        Me.I2PartNumber.Name = "I2PartNumber"
        Me.I2PartNumber.ReadOnly = True
        Me.I2PartNumber.Visible = False
        Me.I2PartNumber.Width = 2
        '
        'I2InvPosted
        '
        Me.I2InvPosted.HeaderText = "I2InvPosted"
        Me.I2InvPosted.MinimumWidth = 2
        Me.I2InvPosted.Name = "I2InvPosted"
        Me.I2InvPosted.ReadOnly = True
        Me.I2InvPosted.Visible = False
        Me.I2InvPosted.Width = 2
        '
        'I2TextNotes
        '
        Me.I2TextNotes.FillWeight = 2.0!
        Me.I2TextNotes.HeaderText = "I2TextNotes"
        Me.I2TextNotes.Name = "I2TextNotes"
        Me.I2TextNotes.ReadOnly = True
        Me.I2TextNotes.Visible = False
        Me.I2TextNotes.Width = 5
        '
        'I2DelivQty
        '
        Me.I2DelivQty.HeaderText = "I2DelivQty"
        Me.I2DelivQty.MinimumWidth = 2
        Me.I2DelivQty.Name = "I2DelivQty"
        Me.I2DelivQty.ReadOnly = True
        Me.I2DelivQty.Visible = False
        Me.I2DelivQty.Width = 2
        '
        'I2MpoRMCostCDN
        '
        Me.I2MpoRMCostCDN.HeaderText = "I2MpoRMCostCDN"
        Me.I2MpoRMCostCDN.MinimumWidth = 2
        Me.I2MpoRMCostCDN.Name = "I2MpoRMCostCDN"
        Me.I2MpoRMCostCDN.ReadOnly = True
        Me.I2MpoRMCostCDN.Visible = False
        Me.I2MpoRMCostCDN.Width = 2
        '
        'I2StPrice
        '
        Me.I2StPrice.HeaderText = "I2StPrice"
        Me.I2StPrice.MinimumWidth = 2
        Me.I2StPrice.Name = "I2StPrice"
        Me.I2StPrice.ReadOnly = True
        Me.I2StPrice.Visible = False
        Me.I2StPrice.Width = 2
        '
        'I5PslipORDRefNo
        '
        Me.I5PslipORDRefNo.HeaderText = "I5PslipORDRefNo"
        Me.I5PslipORDRefNo.MinimumWidth = 2
        Me.I5PslipORDRefNo.Name = "I5PslipORDRefNo"
        Me.I5PslipORDRefNo.ReadOnly = True
        Me.I5PslipORDRefNo.Visible = False
        Me.I5PslipORDRefNo.Width = 2
        '
        'I5ShipShortName
        '
        Me.I5ShipShortName.HeaderText = "I5ShipShortName"
        Me.I5ShipShortName.MinimumWidth = 2
        Me.I5ShipShortName.Name = "I5ShipShortName"
        Me.I5ShipShortName.ReadOnly = True
        Me.I5ShipShortName.Visible = False
        Me.I5ShipShortName.Width = 2
        '
        'I5InvCodeM3
        '
        Me.I5InvCodeM3.HeaderText = "I5InvCodeM3"
        Me.I5InvCodeM3.MinimumWidth = 2
        Me.I5InvCodeM3.Name = "I5InvCodeM3"
        Me.I5InvCodeM3.ReadOnly = True
        Me.I5InvCodeM3.Visible = False
        Me.I5InvCodeM3.Width = 2
        '
        'I5InvM3TwoCust
        '
        Me.I5InvM3TwoCust.HeaderText = "I5InvM3TwoCust"
        Me.I5InvM3TwoCust.MinimumWidth = 2
        Me.I5InvM3TwoCust.Name = "I5InvM3TwoCust"
        Me.I5InvM3TwoCust.ReadOnly = True
        Me.I5InvM3TwoCust.Visible = False
        Me.I5InvM3TwoCust.Width = 2
        '
        'I5PslipItem
        '
        Me.I5PslipItem.HeaderText = "I5PslipItem"
        Me.I5PslipItem.MinimumWidth = 2
        Me.I5PslipItem.Name = "I5PslipItem"
        Me.I5PslipItem.ReadOnly = True
        Me.I5PslipItem.Visible = False
        Me.I5PslipItem.Width = 2
        '
        'I5MMITDS
        '
        Me.I5MMITDS.HeaderText = "I5MMITDS"
        Me.I5MMITDS.MinimumWidth = 2
        Me.I5MMITDS.Name = "I5MMITDS"
        Me.I5MMITDS.ReadOnly = True
        Me.I5MMITDS.Visible = False
        Me.I5MMITDS.Width = 2
        '
        'I5MpoNo
        '
        Me.I5MpoNo.HeaderText = "I5MpoNo"
        Me.I5MpoNo.MinimumWidth = 2
        Me.I5MpoNo.Name = "I5MpoNo"
        Me.I5MpoNo.ReadOnly = True
        Me.I5MpoNo.Visible = False
        Me.I5MpoNo.Width = 2
        '
        'I5StDate
        '
        Me.I5StDate.HeaderText = "I5StDate"
        Me.I5StDate.MinimumWidth = 2
        Me.I5StDate.Name = "I5StDate"
        Me.I5StDate.ReadOnly = True
        Me.I5StDate.Visible = False
        Me.I5StDate.Width = 2
        '
        'I5DelivDate
        '
        Me.I5DelivDate.HeaderText = "I5DelivDate"
        Me.I5DelivDate.MinimumWidth = 2
        Me.I5DelivDate.Name = "I5DelivDate"
        Me.I5DelivDate.ReadOnly = True
        Me.I5DelivDate.Visible = False
        Me.I5DelivDate.Width = 2
        '
        'I5StStockClasification
        '
        Me.I5StStockClasification.HeaderText = "I5StStockClasification"
        Me.I5StStockClasification.MinimumWidth = 2
        Me.I5StStockClasification.Name = "I5StStockClasification"
        Me.I5StStockClasification.ReadOnly = True
        Me.I5StStockClasification.Visible = False
        Me.I5StStockClasification.Width = 2
        '
        'I5PslipQty
        '
        Me.I5PslipQty.HeaderText = "I5PslipQty"
        Me.I5PslipQty.MinimumWidth = 2
        Me.I5PslipQty.Name = "I5PslipQty"
        Me.I5PslipQty.ReadOnly = True
        Me.I5PslipQty.Visible = False
        Me.I5PslipQty.Width = 2
        '
        'I5PslipNo
        '
        Me.I5PslipNo.HeaderText = "I5PslipNo"
        Me.I5PslipNo.MinimumWidth = 2
        Me.I5PslipNo.Name = "I5PslipNo"
        Me.I5PslipNo.ReadOnly = True
        Me.I5PslipNo.Visible = False
        Me.I5PslipNo.Width = 2
        '
        'I5InvAccpacGL1
        '
        Me.I5InvAccpacGL1.HeaderText = "I5InvAccpacGL1"
        Me.I5InvAccpacGL1.MinimumWidth = 2
        Me.I5InvAccpacGL1.Name = "I5InvAccpacGL1"
        Me.I5InvAccpacGL1.ReadOnly = True
        Me.I5InvAccpacGL1.Visible = False
        Me.I5InvAccpacGL1.Width = 2
        '
        'I5InvAccpacGL2
        '
        Me.I5InvAccpacGL2.HeaderText = "I5InvAccpacGL2"
        Me.I5InvAccpacGL2.MinimumWidth = 2
        Me.I5InvAccpacGL2.Name = "I5InvAccpacGL2"
        Me.I5InvAccpacGL2.ReadOnly = True
        Me.I5InvAccpacGL2.Visible = False
        Me.I5InvAccpacGL2.Width = 2
        '
        'I5InvAccpacGL3
        '
        Me.I5InvAccpacGL3.HeaderText = "I5InvAccpacGL3"
        Me.I5InvAccpacGL3.MinimumWidth = 2
        Me.I5InvAccpacGL3.Name = "I5InvAccpacGL3"
        Me.I5InvAccpacGL3.ReadOnly = True
        Me.I5InvAccpacGL3.Visible = False
        Me.I5InvAccpacGL3.Width = 2
        '
        'I5InvValCh1
        '
        Me.I5InvValCh1.HeaderText = "I5InvValCh1"
        Me.I5InvValCh1.MinimumWidth = 2
        Me.I5InvValCh1.Name = "I5InvValCh1"
        Me.I5InvValCh1.ReadOnly = True
        Me.I5InvValCh1.Visible = False
        Me.I5InvValCh1.Width = 2
        '
        'I5InvValCh2
        '
        Me.I5InvValCh2.HeaderText = "I5InvValCh2"
        Me.I5InvValCh2.MinimumWidth = 2
        Me.I5InvValCh2.Name = "I5InvValCh2"
        Me.I5InvValCh2.ReadOnly = True
        Me.I5InvValCh2.Visible = False
        Me.I5InvValCh2.Width = 2
        '
        'I5InvValCh3
        '
        Me.I5InvValCh3.HeaderText = "I5InvValCh3"
        Me.I5InvValCh3.MinimumWidth = 2
        Me.I5InvValCh3.Name = "I5InvValCh3"
        Me.I5InvValCh3.ReadOnly = True
        Me.I5InvValCh3.Visible = False
        Me.I5InvValCh3.Width = 2
        '
        'I5PslipType
        '
        Me.I5PslipType.HeaderText = "I5PslipType"
        Me.I5PslipType.MinimumWidth = 2
        Me.I5PslipType.Name = "I5PslipType"
        Me.I5PslipType.ReadOnly = True
        Me.I5PslipType.Visible = False
        Me.I5PslipType.Width = 2
        '
        'I5InvPrice
        '
        Me.I5InvPrice.HeaderText = "I5InvPrice"
        Me.I5InvPrice.MinimumWidth = 2
        Me.I5InvPrice.Name = "I5InvPrice"
        Me.I5InvPrice.ReadOnly = True
        Me.I5InvPrice.Visible = False
        Me.I5InvPrice.Width = 2
        '
        'I5CoCPartRev
        '
        Me.I5CoCPartRev.HeaderText = "I5CoCPartRev"
        Me.I5CoCPartRev.MinimumWidth = 2
        Me.I5CoCPartRev.Name = "I5CoCPartRev"
        Me.I5CoCPartRev.ReadOnly = True
        Me.I5CoCPartRev.Visible = False
        Me.I5CoCPartRev.Width = 2
        '
        'I5ShipVia
        '
        Me.I5ShipVia.HeaderText = "I5ShipVia"
        Me.I5ShipVia.MinimumWidth = 2
        Me.I5ShipVia.Name = "I5ShipVia"
        Me.I5ShipVia.ReadOnly = True
        Me.I5ShipVia.Visible = False
        Me.I5ShipVia.Width = 2
        '
        'I5InvFOB
        '
        Me.I5InvFOB.HeaderText = "I5InvFOB"
        Me.I5InvFOB.MinimumWidth = 2
        Me.I5InvFOB.Name = "I5InvFOB"
        Me.I5InvFOB.ReadOnly = True
        Me.I5InvFOB.Visible = False
        Me.I5InvFOB.Width = 2
        '
        'I5TextNotes
        '
        Me.I5TextNotes.HeaderText = "I5TextNotes"
        Me.I5TextNotes.MinimumWidth = 2
        Me.I5TextNotes.Name = "I5TextNotes"
        Me.I5TextNotes.ReadOnly = True
        Me.I5TextNotes.Visible = False
        Me.I5TextNotes.Width = 2
        '
        'I5PoNoDeliv
        '
        Me.I5PoNoDeliv.HeaderText = "I5PoNoDeliv"
        Me.I5PoNoDeliv.MinimumWidth = 2
        Me.I5PoNoDeliv.Name = "I5PoNoDeliv"
        Me.I5PoNoDeliv.ReadOnly = True
        Me.I5PoNoDeliv.Visible = False
        Me.I5PoNoDeliv.Width = 2
        '
        'I5DelivStatus
        '
        Me.I5DelivStatus.HeaderText = "I5DelivStatus"
        Me.I5DelivStatus.MinimumWidth = 2
        Me.I5DelivStatus.Name = "I5DelivStatus"
        Me.I5DelivStatus.ReadOnly = True
        Me.I5DelivStatus.Visible = False
        Me.I5DelivStatus.Width = 2
        '
        'I5InvPosted
        '
        Me.I5InvPosted.HeaderText = "I5InvPosted"
        Me.I5InvPosted.MinimumWidth = 2
        Me.I5InvPosted.Name = "I5InvPosted"
        Me.I5InvPosted.ReadOnly = True
        Me.I5InvPosted.Visible = False
        Me.I5InvPosted.Width = 2
        '
        'I5PslipInterCoPrefix
        '
        Me.I5PslipInterCoPrefix.HeaderText = "I5PslipInterCoPrefix"
        Me.I5PslipInterCoPrefix.MinimumWidth = 2
        Me.I5PslipInterCoPrefix.Name = "I5PslipInterCoPrefix"
        Me.I5PslipInterCoPrefix.ReadOnly = True
        Me.I5PslipInterCoPrefix.Visible = False
        Me.I5PslipInterCoPrefix.Width = 2
        '
        'I5PartNumber
        '
        Me.I5PartNumber.HeaderText = "I5PartNumber"
        Me.I5PartNumber.MinimumWidth = 2
        Me.I5PartNumber.Name = "I5PartNumber"
        Me.I5PartNumber.ReadOnly = True
        Me.I5PartNumber.Visible = False
        Me.I5PartNumber.Width = 2
        '
        'I5MpoRMCostCDN
        '
        Me.I5MpoRMCostCDN.HeaderText = "I5MpoRMCostCDN"
        Me.I5MpoRMCostCDN.MinimumWidth = 2
        Me.I5MpoRMCostCDN.Name = "I5MpoRMCostCDN"
        Me.I5MpoRMCostCDN.ReadOnly = True
        Me.I5MpoRMCostCDN.Visible = False
        Me.I5MpoRMCostCDN.Width = 2
        '
        'I5StPrice
        '
        Me.I5StPrice.HeaderText = "I5StPrice"
        Me.I5StPrice.MinimumWidth = 2
        Me.I5StPrice.Name = "I5StPrice"
        Me.I5StPrice.ReadOnly = True
        Me.I5StPrice.Visible = False
        Me.I5StPrice.Width = 2
        '
        'I6CONO
        '
        Me.I6CONO.HeaderText = "I6CONO"
        Me.I6CONO.MinimumWidth = 2
        Me.I6CONO.Name = "I6CONO"
        Me.I6CONO.ReadOnly = True
        Me.I6CONO.Visible = False
        Me.I6CONO.Width = 2
        '
        'I6WHLO
        '
        Me.I6WHLO.HeaderText = "I6WHLO"
        Me.I6WHLO.MinimumWidth = 2
        Me.I6WHLO.Name = "I6WHLO"
        Me.I6WHLO.ReadOnly = True
        Me.I6WHLO.Visible = False
        Me.I6WHLO.Width = 2
        '
        'I6MMITDS
        '
        Me.I6MMITDS.HeaderText = "I6MMITDS"
        Me.I6MMITDS.MinimumWidth = 2
        Me.I6MMITDS.Name = "I6MMITDS"
        Me.I6MMITDS.ReadOnly = True
        Me.I6MMITDS.Visible = False
        Me.I6MMITDS.Width = 2
        '
        'I6Stock
        '
        Me.I6Stock.HeaderText = "I6Stock"
        Me.I6Stock.MinimumWidth = 2
        Me.I6Stock.Name = "I6Stock"
        Me.I6Stock.ReadOnly = True
        Me.I6Stock.Visible = False
        Me.I6Stock.Width = 2
        '
        'I6STAG
        '
        Me.I6STAG.HeaderText = "I6STAG"
        Me.I6STAG.MinimumWidth = 2
        Me.I6STAG.Name = "I6STAG"
        Me.I6STAG.ReadOnly = True
        Me.I6STAG.Visible = False
        Me.I6STAG.Width = 2
        '
        'I6MpoNo
        '
        Me.I6MpoNo.HeaderText = "I6MpoNo"
        Me.I6MpoNo.MinimumWidth = 2
        Me.I6MpoNo.Name = "I6MpoNo"
        Me.I6MpoNo.ReadOnly = True
        Me.I6MpoNo.Visible = False
        Me.I6MpoNo.Width = 2
        '
        'I6StDate
        '
        Me.I6StDate.HeaderText = "I6StDate"
        Me.I6StDate.MinimumWidth = 2
        Me.I6StDate.Name = "I6StDate"
        Me.I6StDate.ReadOnly = True
        Me.I6StDate.Visible = False
        Me.I6StDate.Width = 2
        '
        'I6WHSL
        '
        Me.I6WHSL.HeaderText = "I6WHSL"
        Me.I6WHSL.MinimumWidth = 2
        Me.I6WHSL.Name = "I6WHSL"
        Me.I6WHSL.ReadOnly = True
        Me.I6WHSL.Visible = False
        Me.I6WHSL.Width = 2
        '
        'I6StPrice
        '
        Me.I6StPrice.HeaderText = "I6StPrice"
        Me.I6StPrice.MinimumWidth = 2
        Me.I6StPrice.Name = "I6StPrice"
        Me.I6StPrice.ReadOnly = True
        Me.I6StPrice.Visible = False
        Me.I6StPrice.Width = 2
        '
        'I6MpoPartRev
        '
        Me.I6MpoPartRev.HeaderText = "I6MpoPartRev"
        Me.I6MpoPartRev.MinimumWidth = 2
        Me.I6MpoPartRev.Name = "I6MpoPartRev"
        Me.I6MpoPartRev.ReadOnly = True
        Me.I6MpoPartRev.Visible = False
        Me.I6MpoPartRev.Width = 2
        '
        'I6PartNumber
        '
        Me.I6PartNumber.HeaderText = "I6PartNumber"
        Me.I6PartNumber.MinimumWidth = 2
        Me.I6PartNumber.Name = "I6PartNumber"
        Me.I6PartNumber.ReadOnly = True
        Me.I6PartNumber.Visible = False
        Me.I6PartNumber.Width = 2
        '
        'I6StStockClasification
        '
        Me.I6StStockClasification.HeaderText = "I6StStockClasification"
        Me.I6StStockClasification.MinimumWidth = 2
        Me.I6StStockClasification.Name = "I6StStockClasification"
        Me.I6StStockClasification.ReadOnly = True
        Me.I6StStockClasification.Visible = False
        Me.I6StStockClasification.Width = 2
        '
        'I6MpoRMCostCDN
        '
        Me.I6MpoRMCostCDN.HeaderText = "I6MpoRMCostCDN"
        Me.I6MpoRMCostCDN.MinimumWidth = 2
        Me.I6MpoRMCostCDN.Name = "I6MpoRMCostCDN"
        Me.I6MpoRMCostCDN.ReadOnly = True
        Me.I6MpoRMCostCDN.Visible = False
        Me.I6MpoRMCostCDN.Width = 2
        '
        'I9OrderNumber
        '
        Me.I9OrderNumber.HeaderText = "I9OrderNumber"
        Me.I9OrderNumber.MinimumWidth = 2
        Me.I9OrderNumber.Name = "I9OrderNumber"
        Me.I9OrderNumber.ReadOnly = True
        Me.I9OrderNumber.Visible = False
        Me.I9OrderNumber.Width = 2
        '
        'I9OrderLineNumber
        '
        Me.I9OrderLineNumber.HeaderText = "I9OrderLineNumber"
        Me.I9OrderLineNumber.MinimumWidth = 2
        Me.I9OrderLineNumber.Name = "I9OrderLineNumber"
        Me.I9OrderLineNumber.ReadOnly = True
        Me.I9OrderLineNumber.Visible = False
        Me.I9OrderLineNumber.Width = 2
        '
        'I9OrderDate
        '
        Me.I9OrderDate.HeaderText = "I9OrderDate"
        Me.I9OrderDate.MinimumWidth = 2
        Me.I9OrderDate.Name = "I9OrderDate"
        Me.I9OrderDate.ReadOnly = True
        Me.I9OrderDate.Visible = False
        Me.I9OrderDate.Width = 2
        '
        'I9Quantity
        '
        Me.I9Quantity.HeaderText = "I9Quantity"
        Me.I9Quantity.MinimumWidth = 2
        Me.I9Quantity.Name = "I9Quantity"
        Me.I9Quantity.ReadOnly = True
        Me.I9Quantity.Visible = False
        Me.I9Quantity.Width = 2
        '
        'I9Price
        '
        Me.I9Price.HeaderText = "I9Price"
        Me.I9Price.MinimumWidth = 2
        Me.I9Price.Name = "I9Price"
        Me.I9Price.ReadOnly = True
        Me.I9Price.Visible = False
        Me.I9Price.Width = 2
        '
        'I9Currency
        '
        Me.I9Currency.HeaderText = "I9Currency"
        Me.I9Currency.MinimumWidth = 2
        Me.I9Currency.Name = "I9Currency"
        Me.I9Currency.ReadOnly = True
        Me.I9Currency.Visible = False
        Me.I9Currency.Width = 2
        '
        'I9LineStatus
        '
        Me.I9LineStatus.HeaderText = "I9LineStatus"
        Me.I9LineStatus.MinimumWidth = 2
        Me.I9LineStatus.Name = "I9LineStatus"
        Me.I9LineStatus.ReadOnly = True
        Me.I9LineStatus.Visible = False
        Me.I9LineStatus.Width = 2
        '
        'I9AlliasNumber
        '
        Me.I9AlliasNumber.HeaderText = "I9AlliasNumber"
        Me.I9AlliasNumber.MinimumWidth = 2
        Me.I9AlliasNumber.Name = "I9AlliasNumber"
        Me.I9AlliasNumber.ReadOnly = True
        Me.I9AlliasNumber.Visible = False
        Me.I9AlliasNumber.Width = 2
        '
        'I9Name
        '
        Me.I9Name.HeaderText = "I9Name"
        Me.I9Name.MinimumWidth = 2
        Me.I9Name.Name = "I9Name"
        Me.I9Name.ReadOnly = True
        Me.I9Name.Visible = False
        Me.I9Name.Width = 2
        '
        'I9DeliveryDate
        '
        Me.I9DeliveryDate.HeaderText = "I9DeliveryDate"
        Me.I9DeliveryDate.MinimumWidth = 2
        Me.I9DeliveryDate.Name = "I9DeliveryDate"
        Me.I9DeliveryDate.ReadOnly = True
        Me.I9DeliveryDate.Visible = False
        Me.I9DeliveryDate.Width = 2
        '
        'I9PlannedDate
        '
        Me.I9PlannedDate.HeaderText = "I9PlannedDate"
        Me.I9PlannedDate.MinimumWidth = 2
        Me.I9PlannedDate.Name = "I9PlannedDate"
        Me.I9PlannedDate.ReadOnly = True
        Me.I9PlannedDate.Visible = False
        Me.I9PlannedDate.Width = 2
        '
        'I9OrdNumber
        '
        Me.I9OrdNumber.HeaderText = "I9OrdNumber"
        Me.I9OrdNumber.MinimumWidth = 2
        Me.I9OrdNumber.Name = "I9OrdNumber"
        Me.I9OrdNumber.ReadOnly = True
        Me.I9OrdNumber.Visible = False
        Me.I9OrdNumber.Width = 2
        '
        'I9CustCodeM3
        '
        Me.I9CustCodeM3.HeaderText = "I9CustCodeM3"
        Me.I9CustCodeM3.MinimumWidth = 2
        Me.I9CustCodeM3.Name = "I9CustCodeM3"
        Me.I9CustCodeM3.ReadOnly = True
        Me.I9CustCodeM3.Visible = False
        Me.I9CustCodeM3.Width = 2
        '
        'I9CustomerShort
        '
        Me.I9CustomerShort.HeaderText = "I9CustomerShort"
        Me.I9CustomerShort.MinimumWidth = 2
        Me.I9CustomerShort.Name = "I9CustomerShort"
        Me.I9CustomerShort.ReadOnly = True
        Me.I9CustomerShort.Visible = False
        Me.I9CustomerShort.Width = 2
        '
        'I9MMITDS
        '
        Me.I9MMITDS.HeaderText = "I9MMITDS"
        Me.I9MMITDS.MinimumWidth = 2
        Me.I9MMITDS.Name = "I9MMITDS"
        Me.I9MMITDS.ReadOnly = True
        Me.I9MMITDS.Visible = False
        Me.I9MMITDS.Width = 2
        '
        'I9OrdItemQty
        '
        Me.I9OrdItemQty.HeaderText = "I9OrdItemQty"
        Me.I9OrdItemQty.MinimumWidth = 2
        Me.I9OrdItemQty.Name = "I9OrdItemQty"
        Me.I9OrdItemQty.ReadOnly = True
        Me.I9OrdItemQty.Visible = False
        Me.I9OrdItemQty.Width = 2
        '
        'I9CustomerName
        '
        Me.I9CustomerName.HeaderText = "I9CustomerName"
        Me.I9CustomerName.MinimumWidth = 2
        Me.I9CustomerName.Name = "I9CustomerName"
        Me.I9CustomerName.ReadOnly = True
        Me.I9CustomerName.Visible = False
        Me.I9CustomerName.Width = 2
        '
        'I99DONumber
        '
        Me.I99DONumber.HeaderText = "I99DONumber"
        Me.I99DONumber.MinimumWidth = 2
        Me.I99DONumber.Name = "I99DONumber"
        Me.I99DONumber.ReadOnly = True
        Me.I99DONumber.Visible = False
        Me.I99DONumber.Width = 2
        '
        'I99DOLineNumber
        '
        Me.I99DOLineNumber.HeaderText = "I99DOLineNumber"
        Me.I99DOLineNumber.MinimumWidth = 2
        Me.I99DOLineNumber.Name = "I99DOLineNumber"
        Me.I99DOLineNumber.ReadOnly = True
        Me.I99DOLineNumber.Visible = False
        Me.I99DOLineNumber.Width = 2
        '
        'I99DODate
        '
        Me.I99DODate.HeaderText = "I99DODate"
        Me.I99DODate.MinimumWidth = 2
        Me.I99DODate.Name = "I99DODate"
        Me.I99DODate.ReadOnly = True
        Me.I99DODate.Visible = False
        Me.I99DODate.Width = 2
        '
        'I99DelivQty
        '
        Me.I99DelivQty.HeaderText = "I99DelivQty"
        Me.I99DelivQty.MinimumWidth = 2
        Me.I99DelivQty.Name = "I99DelivQty"
        Me.I99DelivQty.ReadOnly = True
        Me.I99DelivQty.Visible = False
        Me.I99DelivQty.Width = 2
        '
        'I99Price
        '
        Me.I99Price.HeaderText = "I99Price"
        Me.I99Price.MinimumWidth = 2
        Me.I99Price.Name = "I99Price"
        Me.I99Price.ReadOnly = True
        Me.I99Price.Visible = False
        Me.I99Price.Width = 2
        '
        'I99Devise
        '
        Me.I99Devise.HeaderText = "I99Devise"
        Me.I99Devise.MinimumWidth = 2
        Me.I99Devise.Name = "I99Devise"
        Me.I99Devise.ReadOnly = True
        Me.I99Devise.Visible = False
        Me.I99Devise.Width = 2
        '
        'I99LineStatus
        '
        Me.I99LineStatus.HeaderText = "I99LineStatus"
        Me.I99LineStatus.MinimumWidth = 2
        Me.I99LineStatus.Name = "I99LineStatus"
        Me.I99LineStatus.ReadOnly = True
        Me.I99LineStatus.Visible = False
        Me.I99LineStatus.Width = 2
        '
        'I99PartITDS
        '
        Me.I99PartITDS.HeaderText = "I99PartITDS"
        Me.I99PartITDS.MinimumWidth = 2
        Me.I99PartITDS.Name = "I99PartITDS"
        Me.I99PartITDS.ReadOnly = True
        Me.I99PartITDS.Visible = False
        Me.I99PartITDS.Width = 2
        '
        'I99PlanDate
        '
        Me.I99PlanDate.HeaderText = "I99PlanDate"
        Me.I99PlanDate.MinimumWidth = 2
        Me.I99PlanDate.Name = "I99PlanDate"
        Me.I99PlanDate.ReadOnly = True
        Me.I99PlanDate.Visible = False
        Me.I99PlanDate.Width = 2
        '
        'I99WHSE
        '
        Me.I99WHSE.HeaderText = "I99WHSE"
        Me.I99WHSE.MinimumWidth = 2
        Me.I99WHSE.Name = "I99WHSE"
        Me.I99WHSE.ReadOnly = True
        Me.I99WHSE.Visible = False
        Me.I99WHSE.Width = 2
        '
        'I99ITNO
        '
        Me.I99ITNO.HeaderText = "I99ITNO"
        Me.I99ITNO.MinimumWidth = 2
        Me.I99ITNO.Name = "I99ITNO"
        Me.I99ITNO.ReadOnly = True
        Me.I99ITNO.Visible = False
        Me.I99ITNO.Width = 2
        '
        'CmdSearch
        '
        Me.CmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearch.Location = New System.Drawing.Point(504, 48)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 44)
        Me.CmdSearch.TabIndex = 64
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.Location = New System.Drawing.Point(960, 50)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 44)
        Me.CmdClear.TabIndex = 69
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'txtCOBatch
        '
        Me.txtCOBatch.AcceptsReturn = True
        Me.txtCOBatch.Location = New System.Drawing.Point(336, 48)
        Me.txtCOBatch.Name = "txtCOBatch"
        Me.txtCOBatch.ReadOnly = True
        Me.txtCOBatch.Size = New System.Drawing.Size(116, 20)
        Me.txtCOBatch.TabIndex = 72
        Me.txtCOBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Batch Counter (RNNO):"
        '
        'CmdExport
        '
        Me.CmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExport.Location = New System.Drawing.Point(1436, 48)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(210, 44)
        Me.CmdExport.TabIndex = 74
        Me.CmdExport.Text = "EXPORT INTO M3"
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'RdI2
        '
        Me.RdI2.AutoSize = True
        Me.RdI2.BackColor = System.Drawing.Color.Red
        Me.RdI2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdI2.ForeColor = System.Drawing.Color.Black
        Me.RdI2.Location = New System.Drawing.Point(12, 14)
        Me.RdI2.Name = "RdI2"
        Me.RdI2.Size = New System.Drawing.Size(266, 20)
        Me.RdI2.TabIndex = 78
        Me.RdI2.TabStop = True
        Me.RdI2.Text = "I2 --- LAC DOs Trannsfer into M3     "
        Me.RdI2.UseVisualStyleBackColor = False
        '
        'RdI6
        '
        Me.RdI6.AutoSize = True
        Me.RdI6.BackColor = System.Drawing.Color.CornflowerBlue
        Me.RdI6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdI6.Location = New System.Drawing.Point(12, 99)
        Me.RdI6.Name = "RdI6"
        Me.RdI6.Size = New System.Drawing.Size(268, 20)
        Me.RdI6.TabIndex = 79
        Me.RdI6.TabStop = True
        Me.RdI6.Text = "I6 --- LAC FP stock Transfer into M3"
        Me.RdI6.UseVisualStyleBackColor = False
        '
        'RdI5
        '
        Me.RdI5.AutoSize = True
        Me.RdI5.BackColor = System.Drawing.Color.Yellow
        Me.RdI5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdI5.Location = New System.Drawing.Point(12, 56)
        Me.RdI5.Name = "RdI5"
        Me.RdI5.Size = New System.Drawing.Size(266, 20)
        Me.RdI5.TabIndex = 80
        Me.RdI5.TabStop = True
        Me.RdI5.Text = "I5 --- LAC Invoices Transfer into M3"
        Me.RdI5.UseVisualStyleBackColor = False
        '
        'RdI9
        '
        Me.RdI9.AutoSize = True
        Me.RdI9.BackColor = System.Drawing.Color.Lime
        Me.RdI9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdI9.Location = New System.Drawing.Point(12, 141)
        Me.RdI9.Name = "RdI9"
        Me.RdI9.Size = New System.Drawing.Size(344, 20)
        Me.RdI9.TabIndex = 81
        Me.RdI9.TabStop = True
        Me.RdI9.Text = "I9 --- LAC COs Transfer into M3 - DATA Control"
        Me.RdI9.UseVisualStyleBackColor = False
        '
        'RdI99
        '
        Me.RdI99.AutoSize = True
        Me.RdI99.BackColor = System.Drawing.Color.PaleVioletRed
        Me.RdI99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdI99.Location = New System.Drawing.Point(12, 184)
        Me.RdI99.Name = "RdI99"
        Me.RdI99.Size = New System.Drawing.Size(353, 20)
        Me.RdI99.TabIndex = 82
        Me.RdI99.TabStop = True
        Me.RdI99.Text = "I99 --- LAC DOs Transfer into M3 - DATA Control"
        Me.RdI99.UseVisualStyleBackColor = False
        '
        'frmAccUploadInvoicesintoM3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1596, 873)
        Me.Controls.Add(Me.RdI99)
        Me.Controls.Add(Me.RdI9)
        Me.Controls.Add(Me.RdI5)
        Me.Controls.Add(Me.RdI6)
        Me.Controls.Add(Me.RdI2)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCOBatch)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.dgMPO)
        Me.Name = "frmAccUploadInvoicesintoM3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAccUploadInvoicesintoM3"
        CType(Me.dgMPO,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents txtCOBatch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents RdI2 As System.Windows.Forms.RadioButton
    Friend WithEvents RdI6 As System.Windows.Forms.RadioButton
    Friend WithEvents RdI5 As System.Windows.Forms.RadioButton
    Friend WithEvents RdI9 As System.Windows.Forms.RadioButton
    Friend WithEvents RdI99 As System.Windows.Forms.RadioButton
    Friend WithEvents LACData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2ShipShortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipORDRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2MMITDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2InvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2StDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2StStockClasification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2InvPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2CoCPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2ShipVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2InvFOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2DelivStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PslipCustPoContr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2InvPosted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2TextNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2MpoRMCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I2StPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipORDRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5ShipShortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvCodeM3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvM3TwoCust As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5MMITDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5StDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5StStockClasification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvAccpacGL1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvAccpacGL2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvAccpacGL3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvValCh1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvValCh2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvValCh3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5CoCPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5ShipVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvFOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5TextNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PoNoDeliv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5DelivStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5InvPosted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PslipInterCoPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5MpoRMCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I5StPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6CONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6WHLO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6MMITDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6STAG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6StDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6WHSL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6StPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6MpoPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6StStockClasification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I6MpoRMCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9OrderLineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9OrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9LineStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9AlliasNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9DeliveryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9PlannedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9CustCodeM3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9MMITDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9OrdItemQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I9CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99DONumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99DOLineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99DODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99Devise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99LineStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99PartITDS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99PlanDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99WHSE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I99ITNO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
