<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionFollowUpProgress
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
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgProd = New System.Windows.Forms.DataGridView()
        Me.CmbDept = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.CmbPart = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbSelCust = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtQANotes = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTechNotes = New System.Windows.Forms.TextBox()
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPriority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPromDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwRouteStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwNoDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptNode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwSalesValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPOExpediteValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSeeMemo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CmdViewMethod = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DeptSalesFr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecvMatlSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoTechNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoQANotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwSuppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwPODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwPromisedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwReceiveDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwPslipQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwPOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToResizeRows = False
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle47
        Me.dgProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgProd.ColumnHeadersHeight = 45
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerShort, Me.OrdNumber, Me.OrdDate, Me.PartNumber, Me.PartDescCode, Me.MpoPriority, Me.MpoType, Me.MpoNo, Me.DelivDate, Me.MpoPromDate, Me.QtyActual, Me.QtyOrder, Me.SwRouteStart, Me.SwNoDays, Me.DeptNode, Me.OrdItemPrice, Me.SwSalesValue, Me.MPOExpediteValue, Me.MatlType, Me.MemoNo, Me.CmdSeeMemo, Me.CmdViewMethod, Me.DeptSalesFr, Me.RecvMatlSize, Me.MpoTechNotes, Me.MpoQANotes, Me.MPOID, Me.MpoPartID, Me.MemoID, Me.SwSuppName, Me.SwPODate, Me.SwPromisedDate, Me.SwReceiveDate, Me.SwPslipQty, Me.SwPOQty})
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle67.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle67
        Me.dgProd.Location = New System.Drawing.Point(4, 84)
        Me.dgProd.Name = "dgProd"
        DataGridViewCellStyle68.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle68.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle68.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle68.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle68.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowHeadersDefaultCellStyle = DataGridViewCellStyle68
        Me.dgProd.RowHeadersWidth = 25
        Me.dgProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle69.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle69.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowsDefaultCellStyle = DataGridViewCellStyle69
        Me.dgProd.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgProd.RowTemplate.Height = 18
        Me.dgProd.Size = New System.Drawing.Size(1283, 532)
        Me.dgProd.TabIndex = 47
        Me.dgProd.Text = "DataGridView1"
        '
        'CmbDept
        '
        Me.CmbDept.DropDownHeight = 600
        Me.CmbDept.DropDownWidth = 200
        Me.CmbDept.FormattingEnabled = True
        Me.CmbDept.IntegralHeight = False
        Me.CmbDept.Location = New System.Drawing.Point(69, 38)
        Me.CmbDept.Name = "CmbDept"
        Me.CmbDept.Size = New System.Drawing.Size(241, 21)
        Me.CmbDept.TabIndex = 81
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Dept."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(343, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 30)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "MPO Delivery Date To:  (mm/dd/yyyy)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(482, 38)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(163, 20)
        Me.txtDateTo.TabIndex = 78
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbPart
        '
        Me.CmbPart.DropDownHeight = 600
        Me.CmbPart.DropDownWidth = 200
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.IntegralHeight = False
        Me.CmbPart.Location = New System.Drawing.Point(482, 7)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.Size = New System.Drawing.Size(163, 21)
        Me.CmbPart.TabIndex = 77
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(343, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Part No."
        '
        'CmbSelCust
        '
        Me.CmbSelCust.DropDownHeight = 600
        Me.CmbSelCust.DropDownWidth = 200
        Me.CmbSelCust.FormattingEnabled = True
        Me.CmbSelCust.IntegralHeight = False
        Me.CmbSelCust.Location = New System.Drawing.Point(69, 7)
        Me.CmbSelCust.Name = "CmbSelCust"
        Me.CmbSelCust.Size = New System.Drawing.Size(241, 21)
        Me.CmbSelCust.TabIndex = 73
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Customer"
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(759, 21)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(97, 21)
        Me.CmdClear.TabIndex = 83
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(935, 21)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(97, 21)
        Me.CmdSearch.TabIndex = 82
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(862, 619)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(136, 13)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "QA (F.A.I./D.V.I. etc..)"
        '
        'txtQANotes
        '
        Me.txtQANotes.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtQANotes.Location = New System.Drawing.Point(865, 635)
        Me.txtQANotes.Multiline = True
        Me.txtQANotes.Name = "txtQANotes"
        Me.txtQANotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQANotes.Size = New System.Drawing.Size(422, 49)
        Me.txtQANotes.TabIndex = 86
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 619)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Mpo Notes"
        '
        'txtTechNotes
        '
        Me.txtTechNotes.BackColor = System.Drawing.Color.LightBlue
        Me.txtTechNotes.Location = New System.Drawing.Point(4, 635)
        Me.txtTechNotes.Multiline = True
        Me.txtTechNotes.Name = "txtTechNotes"
        Me.txtTechNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTechNotes.Size = New System.Drawing.Size(422, 49)
        Me.txtTechNotes.TabIndex = 84
        '
        'CustomerShort
        '
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerShort.DefaultCellStyle = DataGridViewCellStyle49
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 50
        '
        'OrdNumber
        '
        Me.OrdNumber.HeaderText = "Cust. Order"
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.Width = 50
        '
        'OrdDate
        '
        Me.OrdDate.HeaderText = "Order Date"
        Me.OrdDate.Name = "OrdDate"
        Me.OrdDate.Width = 65
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Width = 70
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "Descr. Code"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.Width = 70
        '
        'MpoPriority
        '
        Me.MpoPriority.HeaderText = "MPO Priority"
        Me.MpoPriority.Name = "MpoPriority"
        Me.MpoPriority.Width = 60
        '
        'MpoType
        '
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MpoType.DefaultCellStyle = DataGridViewCellStyle50
        Me.MpoType.HeaderText = "Mpo Type"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 60
        '
        'MpoNo
        '
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoNo.DefaultCellStyle = DataGridViewCellStyle51
        Me.MpoNo.HeaderText = "Mpo No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.Width = 55
        '
        'DelivDate
        '
        Me.DelivDate.HeaderText = "MPO Deliv Date"
        Me.DelivDate.Name = "DelivDate"
        Me.DelivDate.Width = 70
        '
        'MpoPromDate
        '
        Me.MpoPromDate.HeaderText = "MPO Promised Date"
        Me.MpoPromDate.Name = "MpoPromDate"
        Me.MpoPromDate.Width = 70
        '
        'QtyActual
        '
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyActual.DefaultCellStyle = DataGridViewCellStyle52
        Me.QtyActual.HeaderText = "Actual   Qty"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.Width = 50
        '
        'QtyOrder
        '
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyOrder.DefaultCellStyle = DataGridViewCellStyle53
        Me.QtyOrder.HeaderText = "Sales Qty"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.Width = 50
        '
        'SwRouteStart
        '
        DataGridViewCellStyle54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle54.Format = "d"
        DataGridViewCellStyle54.NullValue = Nothing
        Me.SwRouteStart.DefaultCellStyle = DataGridViewCellStyle54
        Me.SwRouteStart.HeaderText = "Dept. Start Date"
        Me.SwRouteStart.Name = "SwRouteStart"
        Me.SwRouteStart.Width = 70
        '
        'SwNoDays
        '
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle55.Format = "N0"
        DataGridViewCellStyle55.NullValue = Nothing
        Me.SwNoDays.DefaultCellStyle = DataGridViewCellStyle55
        Me.SwNoDays.HeaderText = "#Days in Dept "
        Me.SwNoDays.Name = "SwNoDays"
        Me.SwNoDays.Width = 50
        '
        'DeptNode
        '
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle56.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeptNode.DefaultCellStyle = DataGridViewCellStyle56
        Me.DeptNode.HeaderText = "Dept."
        Me.DeptNode.Name = "DeptNode"
        Me.DeptNode.Width = 70
        '
        'OrdItemPrice
        '
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle57.Format = "C2"
        DataGridViewCellStyle57.NullValue = Nothing
        Me.OrdItemPrice.DefaultCellStyle = DataGridViewCellStyle57
        Me.OrdItemPrice.HeaderText = "Unit Price"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.Width = 60
        '
        'SwSalesValue
        '
        DataGridViewCellStyle58.Format = "C2"
        DataGridViewCellStyle58.NullValue = Nothing
        Me.SwSalesValue.DefaultCellStyle = DataGridViewCellStyle58
        Me.SwSalesValue.HeaderText = "Sales Value"
        Me.SwSalesValue.Name = "SwSalesValue"
        Me.SwSalesValue.Width = 70
        '
        'MPOExpediteValue
        '
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle59.Format = "C0"
        DataGridViewCellStyle59.NullValue = Nothing
        Me.MPOExpediteValue.DefaultCellStyle = DataGridViewCellStyle59
        Me.MPOExpediteValue.HeaderText = "Expedite Value"
        Me.MPOExpediteValue.Name = "MPOExpediteValue"
        Me.MPOExpediteValue.Width = 60
        '
        'MatlType
        '
        Me.MatlType.HeaderText = "Mat'l Type"
        Me.MatlType.Name = "MatlType"
        Me.MatlType.Width = 50
        '
        'MemoNo
        '
        DataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoNo.DefaultCellStyle = DataGridViewCellStyle60
        Me.MemoNo.HeaderText = "Memo No."
        Me.MemoNo.Name = "MemoNo"
        Me.MemoNo.Width = 45
        '
        'CmdSeeMemo
        '
        DataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle61.BackColor = System.Drawing.Color.LightBlue
        Me.CmdSeeMemo.DefaultCellStyle = DataGridViewCellStyle61
        Me.CmdSeeMemo.HeaderText = "View MEMO"
        Me.CmdSeeMemo.Name = "CmdSeeMemo"
        Me.CmdSeeMemo.Text = "View "
        Me.CmdSeeMemo.UseColumnTextForButtonValue = True
        Me.CmdSeeMemo.Width = 60
        '
        'CmdViewMethod
        '
        DataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle62.BackColor = System.Drawing.Color.SkyBlue
        Me.CmdViewMethod.DefaultCellStyle = DataGridViewCellStyle62
        Me.CmdViewMethod.HeaderText = "View MPO Traveler"
        Me.CmdViewMethod.Name = "CmdViewMethod"
        Me.CmdViewMethod.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CmdViewMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CmdViewMethod.Text = "View"
        Me.CmdViewMethod.UseColumnTextForButtonValue = True
        Me.CmdViewMethod.Width = 60
        '
        'DeptSalesFr
        '
        DataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeptSalesFr.DefaultCellStyle = DataGridViewCellStyle63
        Me.DeptSalesFr.HeaderText = "Dept Code"
        Me.DeptSalesFr.Name = "DeptSalesFr"
        Me.DeptSalesFr.Width = 35
        '
        'RecvMatlSize
        '
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle64.Format = "N4"
        DataGridViewCellStyle64.NullValue = Nothing
        Me.RecvMatlSize.DefaultCellStyle = DataGridViewCellStyle64
        Me.RecvMatlSize.HeaderText = "Mat'l Dia"
        Me.RecvMatlSize.Name = "RecvMatlSize"
        Me.RecvMatlSize.Width = 50
        '
        'MpoTechNotes
        '
        Me.MpoTechNotes.HeaderText = "MpoTechNotes"
        Me.MpoTechNotes.MinimumWidth = 2
        Me.MpoTechNotes.Name = "MpoTechNotes"
        Me.MpoTechNotes.Visible = False
        Me.MpoTechNotes.Width = 2
        '
        'MpoQANotes
        '
        Me.MpoQANotes.HeaderText = "MpoQANotes"
        Me.MpoQANotes.MinimumWidth = 2
        Me.MpoQANotes.Name = "MpoQANotes"
        Me.MpoQANotes.Visible = False
        Me.MpoQANotes.Width = 2
        '
        'MPOID
        '
        Me.MPOID.HeaderText = "MPOID"
        Me.MPOID.MinimumWidth = 2
        Me.MPOID.Name = "MPOID"
        Me.MPOID.Visible = False
        Me.MPOID.Width = 2
        '
        'MpoPartID
        '
        Me.MpoPartID.HeaderText = "MpoPartID"
        Me.MpoPartID.MinimumWidth = 2
        Me.MpoPartID.Name = "MpoPartID"
        Me.MpoPartID.Visible = False
        Me.MpoPartID.Width = 2
        '
        'MemoID
        '
        Me.MemoID.HeaderText = "MemoID"
        Me.MemoID.MinimumWidth = 2
        Me.MemoID.Name = "MemoID"
        Me.MemoID.Visible = False
        Me.MemoID.Width = 2
        '
        'SwSuppName
        '
        Me.SwSuppName.HeaderText = "SwSuppName"
        Me.SwSuppName.MinimumWidth = 2
        Me.SwSuppName.Name = "SwSuppName"
        Me.SwSuppName.Visible = False
        Me.SwSuppName.Width = 2
        '
        'SwPODate
        '
        Me.SwPODate.HeaderText = "SwPODate"
        Me.SwPODate.MinimumWidth = 2
        Me.SwPODate.Name = "SwPODate"
        Me.SwPODate.Visible = False
        Me.SwPODate.Width = 2
        '
        'SwPromisedDate
        '
        Me.SwPromisedDate.HeaderText = "SwPromisedDate"
        Me.SwPromisedDate.MinimumWidth = 2
        Me.SwPromisedDate.Name = "SwPromisedDate"
        Me.SwPromisedDate.Visible = False
        Me.SwPromisedDate.Width = 2
        '
        'SwReceiveDate
        '
        Me.SwReceiveDate.HeaderText = "SwReceiveDate"
        Me.SwReceiveDate.MinimumWidth = 2
        Me.SwReceiveDate.Name = "SwReceiveDate"
        Me.SwReceiveDate.Visible = False
        Me.SwReceiveDate.Width = 2
        '
        'SwPslipQty
        '
        DataGridViewCellStyle65.Format = "N0"
        DataGridViewCellStyle65.NullValue = Nothing
        Me.SwPslipQty.DefaultCellStyle = DataGridViewCellStyle65
        Me.SwPslipQty.HeaderText = "SwPslipQty"
        Me.SwPslipQty.MinimumWidth = 2
        Me.SwPslipQty.Name = "SwPslipQty"
        Me.SwPslipQty.Visible = False
        Me.SwPslipQty.Width = 2
        '
        'SwPOQty
        '
        DataGridViewCellStyle66.Format = "N0"
        DataGridViewCellStyle66.NullValue = Nothing
        Me.SwPOQty.DefaultCellStyle = DataGridViewCellStyle66
        Me.SwPOQty.HeaderText = "SwPOQty"
        Me.SwPOQty.MinimumWidth = 2
        Me.SwPOQty.Name = "SwPOQty"
        Me.SwPOQty.Visible = False
        Me.SwPOQty.Width = 2
        '
        'frmProductionFollowUpProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1291, 696)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtQANotes)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTechNotes)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.CmbDept)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.CmbPart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbSelCust)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dgProd)
        Me.Name = "frmProductionFollowUpProgress"
        Me.Text = "Lisi Aerospace Canada  -  Follow Up Production Progress"
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents CmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbSelCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQANotes As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTechNotes As System.Windows.Forms.TextBox
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPriority As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPromDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRouteStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwNoDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwSalesValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOExpediteValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSeeMemo As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CmdViewMethod As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DeptSalesFr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecvMatlSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoTechNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoQANotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwSuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPromisedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwReceiveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPslipQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPOQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
