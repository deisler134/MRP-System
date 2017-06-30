<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMPOGenfromOrder
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmbOrder = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgOrd = New System.Windows.Forms.DataGridView()
        Me.OrderItemsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdPartNoID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OrdPartCross99ID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OrdItemQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OrdItemNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDel = New System.Windows.Forms.DataGridView()
        Me.OrdDelivID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderItemsIDDeliv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SwShipedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivWhat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DelivType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMpo = New System.Windows.Forms.DataGridView()
        Me.MpoId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderItemsIDMpo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MpoPartID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MpoPartType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ChNewOrder = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MpoNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtOrd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOrdDate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrdDevise = New System.Windows.Forms.TextBox()
        Me.cmbCust = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOrdNotes = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQtySelected = New System.Windows.Forms.TextBox()
        Me.cmdVerify = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MpoMaster = New System.Windows.Forms.TextBox()
        Me.CmdAssign = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.txtDelDate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OrdQty = New System.Windows.Forms.TextBox()
        Me.txtDelivQty = New System.Windows.Forms.TextBox()
        Me.MpoQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbMpoType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtOrdDelivID = New System.Windows.Forms.TextBox()
        Me.txtExpediteValue = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.MPOChild = New System.Windows.Forms.TextBox()
        CType(Me.dgOrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMpo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbOrder
        '
        Me.CmbOrder.DropDownHeight = 500
        Me.CmbOrder.DropDownWidth = 171
        Me.CmbOrder.FormattingEnabled = True
        Me.CmbOrder.IntegralHeight = False
        Me.CmbOrder.Location = New System.Drawing.Point(174, 8)
        Me.CmbOrder.MaxDropDownItems = 40
        Me.CmbOrder.Name = "CmbOrder"
        Me.CmbOrder.Size = New System.Drawing.Size(333, 21)
        Me.CmbOrder.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PURCHASE  ORDER"
        '
        'dgOrd
        '
        Me.dgOrd.AllowUserToAddRows = False
        Me.dgOrd.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOrd.ColumnHeadersHeight = 40
        Me.dgOrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgOrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderItemsID, Me.OrderID, Me.OrdItemNo, Me.OrdPartNoID, Me.OrdPartCross99ID, Me.OrdItemQty, Me.OrdItemUM, Me.OrdItemPrice, Me.OrdItemStatus, Me.OrdItemNotes})
        Me.dgOrd.Location = New System.Drawing.Point(12, 178)
        Me.dgOrd.Name = "dgOrd"
        Me.dgOrd.ReadOnly = True
        Me.dgOrd.RowHeadersWidth = 25
        Me.dgOrd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOrd.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgOrd.RowTemplate.Height = 17
        Me.dgOrd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgOrd.Size = New System.Drawing.Size(807, 296)
        Me.dgOrd.TabIndex = 4
        Me.dgOrd.Text = "DataGridView1"
        '
        'OrderItemsID
        '
        Me.OrderItemsID.HeaderText = "OrderItemsID"
        Me.OrderItemsID.MinimumWidth = 2
        Me.OrderItemsID.Name = "OrderItemsID"
        Me.OrderItemsID.ReadOnly = True
        Me.OrderItemsID.Visible = False
        Me.OrderItemsID.Width = 2
        '
        'OrderID
        '
        Me.OrderID.HeaderText = "OrderID"
        Me.OrderID.MinimumWidth = 2
        Me.OrderID.Name = "OrderID"
        Me.OrderID.ReadOnly = True
        Me.OrderID.Visible = False
        Me.OrderID.Width = 2
        '
        'OrdItemNo
        '
        Me.OrdItemNo.HeaderText = "Item"
        Me.OrdItemNo.Name = "OrdItemNo"
        Me.OrdItemNo.ReadOnly = True
        Me.OrdItemNo.Width = 40
        '
        'OrdPartNoID
        '
        Me.OrdPartNoID.HeaderText = "Cust. PO Part Number"
        Me.OrdPartNoID.Name = "OrdPartNoID"
        Me.OrdPartNoID.ReadOnly = True
        Me.OrdPartNoID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.OrdPartNoID.Width = 160
        '
        'OrdPartCross99ID
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrdPartCross99ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.OrdPartCross99ID.HeaderText = "LAC MFR Part Number (status = 20)"
        Me.OrdPartCross99ID.Name = "OrdPartCross99ID"
        Me.OrdPartCross99ID.ReadOnly = True
        Me.OrdPartCross99ID.Width = 140
        '
        'OrdItemQty
        '
        Me.OrdItemQty.HeaderText = "QtyItem"
        Me.OrdItemQty.Name = "OrdItemQty"
        Me.OrdItemQty.ReadOnly = True
        Me.OrdItemQty.Width = 80
        '
        'OrdItemUM
        '
        Me.OrdItemUM.HeaderText = "UM"
        Me.OrdItemUM.Name = "OrdItemUM"
        Me.OrdItemUM.ReadOnly = True
        Me.OrdItemUM.Width = 40
        '
        'OrdItemPrice
        '
        Me.OrdItemPrice.HeaderText = "ItemPrice"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.ReadOnly = True
        Me.OrdItemPrice.Width = 80
        '
        'OrdItemStatus
        '
        Me.OrdItemStatus.HeaderText = "ItemStatus"
        Me.OrdItemStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Closed"})
        Me.OrdItemStatus.MinimumWidth = 2
        Me.OrdItemStatus.Name = "OrdItemStatus"
        Me.OrdItemStatus.ReadOnly = True
        Me.OrdItemStatus.Width = 70
        '
        'OrdItemNotes
        '
        Me.OrdItemNotes.HeaderText = "Notes"
        Me.OrdItemNotes.Name = "OrdItemNotes"
        Me.OrdItemNotes.ReadOnly = True
        Me.OrdItemNotes.Width = 150
        '
        'dgDel
        '
        Me.dgDel.AllowUserToAddRows = False
        Me.dgDel.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDel.ColumnHeadersHeight = 30
        Me.dgDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrdDelivID, Me.OrderItemsIDDeliv, Me.DelivDate, Me.DelivQty, Me.DelivStatus, Me.SwShipedQty, Me.DelivWhat, Me.DelivType, Me.DelivNotes})
        Me.dgDel.Location = New System.Drawing.Point(833, 8)
        Me.dgDel.Name = "dgDel"
        Me.dgDel.RowHeadersWidth = 25
        Me.dgDel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgDel.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgDel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgDel.Size = New System.Drawing.Size(739, 464)
        Me.dgDel.TabIndex = 5
        Me.dgDel.Text = "DataGridView2"
        '
        'OrdDelivID
        '
        Me.OrdDelivID.HeaderText = "OrdDelivID"
        Me.OrdDelivID.MinimumWidth = 2
        Me.OrdDelivID.Name = "OrdDelivID"
        Me.OrdDelivID.Visible = False
        Me.OrdDelivID.Width = 2
        '
        'OrderItemsIDDeliv
        '
        Me.OrderItemsIDDeliv.HeaderText = "OrderItemsID"
        Me.OrderItemsIDDeliv.MinimumWidth = 2
        Me.OrderItemsIDDeliv.Name = "OrderItemsIDDeliv"
        Me.OrderItemsIDDeliv.Visible = False
        Me.OrderItemsIDDeliv.Width = 2
        '
        'DelivDate
        '
        Me.DelivDate.HeaderText = "DelivDate"
        Me.DelivDate.Name = "DelivDate"
        Me.DelivDate.Width = 80
        '
        'DelivQty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue
        Me.DelivQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.DelivQty.HeaderText = "DelivQty"
        Me.DelivQty.Name = "DelivQty"
        Me.DelivQty.Width = 70
        '
        'DelivStatus
        '
        Me.DelivStatus.HeaderText = "DelivStatus"
        Me.DelivStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Closed"})
        Me.DelivStatus.Name = "DelivStatus"
        Me.DelivStatus.Width = 80
        '
        'SwShipedQty
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue
        Me.SwShipedQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.SwShipedQty.HeaderText = "Shipped Qty"
        Me.SwShipedQty.Name = "SwShipedQty"
        Me.SwShipedQty.Width = 80
        '
        'DelivWhat
        '
        Me.DelivWhat.HeaderText = "Select"
        Me.DelivWhat.Name = "DelivWhat"
        Me.DelivWhat.Width = 70
        '
        'DelivType
        '
        Me.DelivType.HeaderText = "Deliv Type"
        Me.DelivType.Name = "DelivType"
        '
        'DelivNotes
        '
        Me.DelivNotes.HeaderText = "DelivNotes"
        Me.DelivNotes.Name = "DelivNotes"
        Me.DelivNotes.Width = 200
        '
        'dgMpo
        '
        Me.dgMpo.AllowUserToAddRows = False
        Me.dgMpo.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMpo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgMpo.ColumnHeadersHeight = 50
        Me.dgMpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoId, Me.OrderItemsIDMpo, Me.MpoType, Me.MpoNo, Me.MpoDate, Me.StartProdDate, Me.EndProdDate, Me.MpoStatus, Me.MpoPartID, Me.MpoPartType, Me.MpoPartRev, Me.QtyOrder, Me.DeptID, Me.ChNewOrder, Me.MpoNotes})
        Me.dgMpo.Location = New System.Drawing.Point(193, 577)
        Me.dgMpo.Name = "dgMpo"
        Me.dgMpo.RowHeadersWidth = 25
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMpo.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgMpo.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgMpo.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMpo.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMpo.RowTemplate.Height = 18
        Me.dgMpo.Size = New System.Drawing.Size(1044, 217)
        Me.dgMpo.TabIndex = 6
        Me.dgMpo.Text = "DataGridView3"
        '
        'MpoId
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MpoId.DefaultCellStyle = DataGridViewCellStyle9
        Me.MpoId.HeaderText = "MpoId"
        Me.MpoId.MinimumWidth = 2
        Me.MpoId.Name = "MpoId"
        Me.MpoId.Visible = False
        Me.MpoId.Width = 2
        '
        'OrderItemsIDMpo
        '
        Me.OrderItemsIDMpo.HeaderText = "OrderItemsID"
        Me.OrderItemsIDMpo.MinimumWidth = 2
        Me.OrderItemsIDMpo.Name = "OrderItemsIDMpo"
        Me.OrderItemsIDMpo.Visible = False
        Me.OrderItemsIDMpo.Width = 2
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "Mpo Classification"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 80
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "Mpo No."
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.Width = 80
        '
        'MpoDate
        '
        Me.MpoDate.HeaderText = "Mpo Date"
        Me.MpoDate.Name = "MpoDate"
        Me.MpoDate.Width = 70
        '
        'StartProdDate
        '
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.StartProdDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.StartProdDate.HeaderText = "Start Prod Date"
        Me.StartProdDate.Name = "StartProdDate"
        Me.StartProdDate.Width = 70
        '
        'EndProdDate
        '
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.EndProdDate.DefaultCellStyle = DataGridViewCellStyle11
        Me.EndProdDate.HeaderText = "End Prod Date"
        Me.EndProdDate.Name = "EndProdDate"
        Me.EndProdDate.Width = 70
        '
        'MpoStatus
        '
        Me.MpoStatus.HeaderText = "Mpo Status"
        Me.MpoStatus.Items.AddRange(New Object() {"Active", "Closed", "Cancelled"})
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MpoStatus.Width = 70
        '
        'MpoPartID
        '
        Me.MpoPartID.HeaderText = "Part Number"
        Me.MpoPartID.Name = "MpoPartID"
        Me.MpoPartID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'MpoPartType
        '
        Me.MpoPartType.HeaderText = "Part Control"
        Me.MpoPartType.Name = "MpoPartType"
        Me.MpoPartType.Width = 70
        '
        'MpoPartRev
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MpoPartRev.DefaultCellStyle = DataGridViewCellStyle12
        Me.MpoPartRev.HeaderText = "Part Number Revision"
        Me.MpoPartRev.Name = "MpoPartRev"
        Me.MpoPartRev.Width = 60
        '
        'QtyOrder
        '
        Me.QtyOrder.HeaderText = "Sales Qty. Requested"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.Width = 70
        '
        'DeptID
        '
        Me.DeptID.HeaderText = "Dept."
        Me.DeptID.Name = "DeptID"
        Me.DeptID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DeptID.Width = 80
        '
        'ChNewOrder
        '
        Me.ChNewOrder.HeaderText = "New Order"
        Me.ChNewOrder.Name = "ChNewOrder"
        Me.ChNewOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChNewOrder.Width = 50
        '
        'MpoNotes
        '
        Me.MpoNotes.HeaderText = "Notes"
        Me.MpoNotes.Name = "MpoNotes"
        Me.MpoNotes.Width = 120
        '
        'txtOrd
        '
        Me.txtOrd.Location = New System.Drawing.Point(91, 86)
        Me.txtOrd.Name = "txtOrd"
        Me.txtOrd.Size = New System.Drawing.Size(164, 20)
        Me.txtOrd.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Order Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Order Date"
        '
        'txtOrdDate
        '
        Me.txtOrdDate.Location = New System.Drawing.Point(91, 112)
        Me.txtOrdDate.Name = "txtOrdDate"
        Me.txtOrdDate.Size = New System.Drawing.Size(164, 20)
        Me.txtOrdDate.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Order Devise"
        '
        'txtOrdDevise
        '
        Me.txtOrdDevise.Location = New System.Drawing.Point(91, 138)
        Me.txtOrdDevise.Name = "txtOrdDevise"
        Me.txtOrdDevise.Size = New System.Drawing.Size(164, 20)
        Me.txtOrdDevise.TabIndex = 44
        '
        'cmbCust
        '
        Me.cmbCust.FormattingEnabled = True
        Me.cmbCust.Location = New System.Drawing.Point(91, 56)
        Me.cmbCust.Name = "cmbCust"
        Me.cmbCust.Size = New System.Drawing.Size(164, 21)
        Me.cmbCust.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Customer"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(268, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Order Notes"
        '
        'txtOrdNotes
        '
        Me.txtOrdNotes.Location = New System.Drawing.Point(266, 86)
        Me.txtOrdNotes.Multiline = True
        Me.txtOrdNotes.Name = "txtOrdNotes"
        Me.txtOrdNotes.Size = New System.Drawing.Size(553, 72)
        Me.txtOrdNotes.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1290, 479)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Qty Selected"
        '
        'txtQtySelected
        '
        Me.txtQtySelected.AcceptsReturn = True
        Me.txtQtySelected.Location = New System.Drawing.Point(1294, 498)
        Me.txtQtySelected.Name = "txtQtySelected"
        Me.txtQtySelected.ReadOnly = True
        Me.txtQtySelected.Size = New System.Drawing.Size(76, 20)
        Me.txtQtySelected.TabIndex = 50
        '
        'cmdVerify
        '
        Me.cmdVerify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerify.Location = New System.Drawing.Point(13, 624)
        Me.cmdVerify.Name = "cmdVerify"
        Me.cmdVerify.Size = New System.Drawing.Size(75, 49)
        Me.cmdVerify.TabIndex = 52
        Me.cmdVerify.Text = "Generate Next Mpo Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(100, 637)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Mpo No."
        '
        'MpoMaster
        '
        Me.MpoMaster.AcceptsReturn = True
        Me.MpoMaster.Location = New System.Drawing.Point(101, 653)
        Me.MpoMaster.Name = "MpoMaster"
        Me.MpoMaster.Size = New System.Drawing.Size(72, 20)
        Me.MpoMaster.TabIndex = 53
        '
        'CmdAssign
        '
        Me.CmdAssign.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAssign.ForeColor = System.Drawing.Color.Brown
        Me.CmdAssign.Location = New System.Drawing.Point(15, 699)
        Me.CmdAssign.Name = "CmdAssign"
        Me.CmdAssign.Size = New System.Drawing.Size(160, 38)
        Me.CmdAssign.TabIndex = 55
        Me.CmdAssign.Text = "Assign Mpo No. to the Customer Order"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdDelete.Location = New System.Drawing.Point(14, 758)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(160, 36)
        Me.cmdDelete.TabIndex = 56
        Me.cmdDelete.Text = "Remove Mpo No. from the Customer Order"
        '
        'txtDelDate
        '
        Me.txtDelDate.AcceptsReturn = True
        Me.txtDelDate.Location = New System.Drawing.Point(1182, 498)
        Me.txtDelDate.Name = "txtDelDate"
        Me.txtDelDate.Size = New System.Drawing.Size(80, 20)
        Me.txtDelDate.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1162, 479)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "First Delivery Date"
        '
        'OrdQty
        '
        Me.OrdQty.AcceptsReturn = True
        Me.OrdQty.ForeColor = System.Drawing.Color.DarkRed
        Me.OrdQty.Location = New System.Drawing.Point(167, 479)
        Me.OrdQty.Name = "OrdQty"
        Me.OrdQty.Size = New System.Drawing.Size(72, 20)
        Me.OrdQty.TabIndex = 60
        '
        'txtDelivQty
        '
        Me.txtDelivQty.AcceptsReturn = True
        Me.txtDelivQty.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDelivQty.Location = New System.Drawing.Point(1034, 479)
        Me.txtDelivQty.Name = "txtDelivQty"
        Me.txtDelivQty.Size = New System.Drawing.Size(72, 20)
        Me.txtDelivQty.TabIndex = 61
        '
        'MpoQty
        '
        Me.MpoQty.AcceptsReturn = True
        Me.MpoQty.Location = New System.Drawing.Point(884, 800)
        Me.MpoQty.Name = "MpoQty"
        Me.MpoQty.Size = New System.Drawing.Size(84, 20)
        Me.MpoQty.TabIndex = 62
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(56, 477)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 22)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Total Order Qty (Active)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(951, 479)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 27)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Total Delivery Qty (Active)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(770, 797)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 23)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Total Mpo Qty (Active)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbMpoType
        '
        Me.CmbMpoType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CmbMpoType.DropDownHeight = 500
        Me.CmbMpoType.DropDownWidth = 171
        Me.CmbMpoType.FormattingEnabled = True
        Me.CmbMpoType.IntegralHeight = False
        Me.CmbMpoType.Items.AddRange(New Object() {"Assembly", "Blanks", "Component", "Expedite", "F.A.I.", "Grinding", "ITAR / EAR", "Min/Max", "Qualification", "Remake", "RND", "RWK", "Standard", "Testing"})
        Me.CmbMpoType.Location = New System.Drawing.Point(16, 548)
        Me.CmbMpoType.MaxDropDownItems = 40
        Me.CmbMpoType.Name = "CmbMpoType"
        Me.CmbMpoType.Size = New System.Drawing.Size(160, 21)
        Me.CmbMpoType.Sorted = True
        Me.CmbMpoType.TabIndex = 66
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(39, 532)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 13)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Mpo Classification"
        '
        'txtOrdDelivID
        '
        Me.txtOrdDelivID.AcceptsReturn = True
        Me.txtOrdDelivID.BackColor = System.Drawing.Color.Red
        Me.txtOrdDelivID.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOrdDelivID.Location = New System.Drawing.Point(484, 485)
        Me.txtOrdDelivID.Name = "txtOrdDelivID"
        Me.txtOrdDelivID.Size = New System.Drawing.Size(72, 20)
        Me.txtOrdDelivID.TabIndex = 68
        Me.txtOrdDelivID.Visible = False
        '
        'txtExpediteValue
        '
        Me.txtExpediteValue.AcceptsReturn = True
        Me.txtExpediteValue.ForeColor = System.Drawing.Color.DarkRed
        Me.txtExpediteValue.Location = New System.Drawing.Point(245, 548)
        Me.txtExpediteValue.Name = "txtExpediteValue"
        Me.txtExpediteValue.Size = New System.Drawing.Size(88, 20)
        Me.txtExpediteValue.TabIndex = 69
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(242, 532)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Expedite Value"
        '
        'MPOChild
        '
        Me.MPOChild.AcceptsReturn = True
        Me.MPOChild.BackColor = System.Drawing.Color.Red
        Me.MPOChild.Location = New System.Drawing.Point(101, 604)
        Me.MPOChild.Name = "MPOChild"
        Me.MPOChild.Size = New System.Drawing.Size(72, 20)
        Me.MPOChild.TabIndex = 71
        Me.MPOChild.Visible = False
        '
        'frmMPOGenfromOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1581, 836)
        Me.Controls.Add(Me.MPOChild)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtExpediteValue)
        Me.Controls.Add(Me.txtOrdDelivID)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CmbMpoType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.MpoQty)
        Me.Controls.Add(Me.txtDelivQty)
        Me.Controls.Add(Me.OrdQty)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDelDate)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.CmdAssign)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MpoMaster)
        Me.Controls.Add(Me.cmdVerify)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtQtySelected)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtOrdNotes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCust)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOrdDevise)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOrdDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOrd)
        Me.Controls.Add(Me.dgMpo)
        Me.Controls.Add(Me.dgDel)
        Me.Controls.Add(Me.dgOrd)
        Me.Controls.Add(Me.CmbOrder)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMPOGenfromOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Generate Next Mpo Number"
        CType(Me.dgOrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMpo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgOrd As System.Windows.Forms.DataGridView
    Friend WithEvents dgDel As System.Windows.Forms.DataGridView
    Friend WithEvents dgMpo As System.Windows.Forms.DataGridView
    Friend WithEvents txtOrd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOrdDate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOrdDevise As System.Windows.Forms.TextBox
    Friend WithEvents cmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOrdNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtySelected As System.Windows.Forms.TextBox
    Friend WithEvents cmdVerify As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MpoMaster As System.Windows.Forms.TextBox
    Friend WithEvents CmdAssign As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents txtDelDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdQty As System.Windows.Forms.TextBox
    Friend WithEvents txtDelivQty As System.Windows.Forms.TextBox
    Friend WithEvents MpoQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmbMpoType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtOrdDelivID As System.Windows.Forms.TextBox
    Friend WithEvents txtExpediteValue As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MPOChild As System.Windows.Forms.TextBox
    Friend WithEvents MpoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsIDMpo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MpoPartID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MpoPartType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ChNewOrder As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MpoNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDelivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsIDDeliv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SwShipedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivWhat As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DelivType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdPartNoID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OrdPartCross99ID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OrdItemQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OrdItemNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
