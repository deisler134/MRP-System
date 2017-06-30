<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderAssignDellivToMPO
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgMpo = New System.Windows.Forms.DataGridView()
        Me.dgDel = New System.Windows.Forms.DataGridView()
        Me.OrdDelivID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderItemsIDDeliv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SwShipedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivQtyToShip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivWhat = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DelivNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwMpoQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgOrd = New System.Windows.Forms.DataGridView()
        Me.OrderItemsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NotesOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdAssg = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SrcMPO = New System.Windows.Forms.TextBox()
        Me.CmdReset = New System.Windows.Forms.Button()
        Me.CmbPart = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgSelMPO = New System.Windows.Forms.DataGridView()
        Me.OrdDelivIDSel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNoSel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RdYes = New System.Windows.Forms.RadioButton()
        Me.RdNo = New System.Windows.Forms.RadioButton()
        Me.MpoId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderItemsIDMpo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdDelivIDMpo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoDelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPromDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoPartID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyEngReleased = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DeptID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MpoNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMpo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSelMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgMpo
        '
        Me.dgMpo.AllowUserToAddRows = False
        Me.dgMpo.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMpo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMpo.ColumnHeadersHeight = 30
        Me.dgMpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMpo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoId, Me.OrderItemsIDMpo, Me.OrdDelivIDMpo, Me.MpoType, Me.MpoNo, Me.MpoDelivDate, Me.MpoPromDate, Me.StartProdDate, Me.EndProdDate, Me.MpoPartID, Me.QtyActual, Me.QtyEngReleased, Me.QtyOrder, Me.MpoStatus, Me.DeptID, Me.MpoNotes})
        Me.dgMpo.Location = New System.Drawing.Point(6, 436)
        Me.dgMpo.Name = "dgMpo"
        Me.dgMpo.RowHeadersWidth = 25
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMpo.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgMpo.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgMpo.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMpo.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMpo.RowTemplate.Height = 18
        Me.dgMpo.Size = New System.Drawing.Size(1097, 332)
        Me.dgMpo.TabIndex = 7
        Me.dgMpo.Text = "DataGridView3"
        '
        'dgDel
        '
        Me.dgDel.AllowUserToAddRows = False
        Me.dgDel.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgDel.ColumnHeadersHeight = 20
        Me.dgDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrdDelivID, Me.OrderItemsIDDeliv, Me.DelivDate, Me.DelivQty, Me.DelivStatus, Me.SwShipedQty, Me.DelivQtyToShip, Me.DelivWhat, Me.DelivNotes, Me.SwMpoQty})
        Me.dgDel.Location = New System.Drawing.Point(242, 96)
        Me.dgDel.Name = "dgDel"
        Me.dgDel.RowHeadersWidth = 25
        Me.dgDel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgDel.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgDel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgDel.Size = New System.Drawing.Size(747, 334)
        Me.dgDel.TabIndex = 8
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
        Me.DelivQty.HeaderText = "DelivQty"
        Me.DelivQty.Name = "DelivQty"
        Me.DelivQty.Width = 70
        '
        'DelivStatus
        '
        Me.DelivStatus.HeaderText = "DelivStatus"
        Me.DelivStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Closed"})
        Me.DelivStatus.Name = "DelivStatus"
        Me.DelivStatus.Width = 70
        '
        'SwShipedQty
        '
        Me.SwShipedQty.HeaderText = "Qty Shipped"
        Me.SwShipedQty.Name = "SwShipedQty"
        Me.SwShipedQty.Width = 70
        '
        'DelivQtyToShip
        '
        Me.DelivQtyToShip.HeaderText = "Qty To Ship"
        Me.DelivQtyToShip.Name = "DelivQtyToShip"
        Me.DelivQtyToShip.Width = 70
        '
        'DelivWhat
        '
        Me.DelivWhat.HeaderText = "Select"
        Me.DelivWhat.Name = "DelivWhat"
        Me.DelivWhat.Width = 60
        '
        'DelivNotes
        '
        Me.DelivNotes.HeaderText = "DelivNotes"
        Me.DelivNotes.Name = "DelivNotes"
        Me.DelivNotes.Width = 230
        '
        'SwMpoQty
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightCyan
        Me.SwMpoQty.DefaultCellStyle = DataGridViewCellStyle9
        Me.SwMpoQty.HeaderText = "MPOs Qty. Coverd"
        Me.SwMpoQty.Name = "SwMpoQty"
        Me.SwMpoQty.Width = 60
        '
        'dgOrd
        '
        Me.dgOrd.AllowUserToAddRows = False
        Me.dgOrd.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgOrd.ColumnHeadersHeight = 20
        Me.dgOrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgOrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderItemsID, Me.OrderID, Me.OrdItemNo, Me.CustomerShort, Me.OrdNumber, Me.PartNumber, Me.OrdItemQty, Me.OrdItemUM, Me.OrdItemPrice, Me.OrdItemStatus, Me.NotesOrder, Me.OrdItemNotes})
        Me.dgOrd.Location = New System.Drawing.Point(242, 12)
        Me.dgOrd.Name = "dgOrd"
        Me.dgOrd.ReadOnly = True
        Me.dgOrd.RowHeadersWidth = 25
        Me.dgOrd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOrd.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgOrd.RowTemplate.Height = 17
        Me.dgOrd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgOrd.Size = New System.Drawing.Size(747, 78)
        Me.dgOrd.TabIndex = 9
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
        'CustomerShort
        '
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.ReadOnly = True
        Me.CustomerShort.Width = 60
        '
        'OrdNumber
        '
        Me.OrdNumber.HeaderText = "Order No."
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.ReadOnly = True
        Me.OrdNumber.Width = 60
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part No."
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartNumber.Width = 80
        '
        'OrdItemQty
        '
        Me.OrdItemQty.HeaderText = "QtyItem"
        Me.OrdItemQty.Name = "OrdItemQty"
        Me.OrdItemQty.ReadOnly = True
        Me.OrdItemQty.Width = 60
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
        Me.OrdItemPrice.Width = 60
        '
        'OrdItemStatus
        '
        Me.OrdItemStatus.HeaderText = "ItemStatus"
        Me.OrdItemStatus.Items.AddRange(New Object() {"Active", "Cancelled", "Closed"})
        Me.OrdItemStatus.MinimumWidth = 2
        Me.OrdItemStatus.Name = "OrdItemStatus"
        Me.OrdItemStatus.ReadOnly = True
        Me.OrdItemStatus.Width = 60
        '
        'NotesOrder
        '
        Me.NotesOrder.HeaderText = "Order Notes"
        Me.NotesOrder.Name = "NotesOrder"
        Me.NotesOrder.ReadOnly = True
        '
        'OrdItemNotes
        '
        Me.OrdItemNotes.HeaderText = "Item Notes"
        Me.OrdItemNotes.Name = "OrdItemNotes"
        Me.OrdItemNotes.ReadOnly = True
        Me.OrdItemNotes.Width = 140
        '
        'cmdAssg
        '
        Me.cmdAssg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAssg.Location = New System.Drawing.Point(50, 381)
        Me.cmdAssg.Name = "cmdAssg"
        Me.cmdAssg.Size = New System.Drawing.Size(128, 49)
        Me.cmdAssg.TabIndex = 53
        Me.cmdAssg.Text = "Assign Delivery Date to Mpo Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Active MPOs"
        Me.Label1.Visible = False
        '
        'SrcMPO
        '
        Me.SrcMPO.Location = New System.Drawing.Point(64, 118)
        Me.SrcMPO.Name = "SrcMPO"
        Me.SrcMPO.Size = New System.Drawing.Size(99, 20)
        Me.SrcMPO.TabIndex = 55
        Me.SrcMPO.Visible = False
        '
        'CmdReset
        '
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(52, 203)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(128, 49)
        Me.CmdReset.TabIndex = 56
        Me.CmdReset.Text = "Reset"
        '
        'CmbPart
        '
        Me.CmbPart.DropDownHeight = 600
        Me.CmbPart.DropDownWidth = 200
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.IntegralHeight = False
        Me.CmbPart.Location = New System.Drawing.Point(22, 38)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.Size = New System.Drawing.Size(189, 21)
        Me.CmbPart.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Part Number"
        '
        'dgSelMPO
        '
        Me.dgSelMPO.AllowUserToAddRows = False
        Me.dgSelMPO.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSelMPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgSelMPO.ColumnHeadersHeight = 20
        Me.dgSelMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSelMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrdDelivIDSel, Me.MpoNoSel})
        Me.dgSelMPO.Location = New System.Drawing.Point(995, 96)
        Me.dgSelMPO.Name = "dgSelMPO"
        Me.dgSelMPO.ReadOnly = True
        Me.dgSelMPO.RowHeadersWidth = 25
        Me.dgSelMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSelMPO.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgSelMPO.RowTemplate.Height = 17
        Me.dgSelMPO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSelMPO.Size = New System.Drawing.Size(108, 334)
        Me.dgSelMPO.TabIndex = 59
        Me.dgSelMPO.Text = "DataGridView1"
        '
        'OrdDelivIDSel
        '
        Me.OrdDelivIDSel.HeaderText = "OrdDelivID"
        Me.OrdDelivIDSel.MinimumWidth = 2
        Me.OrdDelivIDSel.Name = "OrdDelivIDSel"
        Me.OrdDelivIDSel.ReadOnly = True
        Me.OrdDelivIDSel.Visible = False
        Me.OrdDelivIDSel.Width = 2
        '
        'MpoNoSel
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoNoSel.DefaultCellStyle = DataGridViewCellStyle14
        Me.MpoNoSel.HeaderText = "Mpo No"
        Me.MpoNoSel.Name = "MpoNoSel"
        Me.MpoNoSel.ReadOnly = True
        Me.MpoNoSel.Width = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(1004, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Assign PO#"
        '
        'RdYes
        '
        Me.RdYes.AutoSize = True
        Me.RdYes.Location = New System.Drawing.Point(1007, 38)
        Me.RdYes.Name = "RdYes"
        Me.RdYes.Size = New System.Drawing.Size(43, 17)
        Me.RdYes.TabIndex = 61
        Me.RdYes.TabStop = True
        Me.RdYes.Text = "Yes"
        Me.RdYes.UseVisualStyleBackColor = True
        '
        'RdNo
        '
        Me.RdNo.AutoSize = True
        Me.RdNo.Location = New System.Drawing.Point(1007, 61)
        Me.RdNo.Name = "RdNo"
        Me.RdNo.Size = New System.Drawing.Size(39, 17)
        Me.RdNo.TabIndex = 62
        Me.RdNo.TabStop = True
        Me.RdNo.Text = "No"
        Me.RdNo.UseVisualStyleBackColor = True
        '
        'MpoId
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MpoId.DefaultCellStyle = DataGridViewCellStyle2
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
        'OrdDelivIDMpo
        '
        Me.OrdDelivIDMpo.HeaderText = "OrdDelivID"
        Me.OrdDelivIDMpo.MinimumWidth = 2
        Me.OrdDelivIDMpo.Name = "OrdDelivIDMpo"
        Me.OrdDelivIDMpo.Visible = False
        Me.OrdDelivIDMpo.Width = 2
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "Mpo Classification"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 70
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "Mpo No."
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.Width = 60
        '
        'MpoDelivDate
        '
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue
        Me.MpoDelivDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.MpoDelivDate.HeaderText = "Order Delivery Date"
        Me.MpoDelivDate.Name = "MpoDelivDate"
        Me.MpoDelivDate.Width = 70
        '
        'MpoPromDate
        '
        Me.MpoPromDate.HeaderText = "Promised Date"
        Me.MpoPromDate.Name = "MpoPromDate"
        Me.MpoPromDate.Width = 70
        '
        'StartProdDate
        '
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.StartProdDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.StartProdDate.HeaderText = "Start Prod Date"
        Me.StartProdDate.Name = "StartProdDate"
        Me.StartProdDate.Width = 60
        '
        'EndProdDate
        '
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.EndProdDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.EndProdDate.HeaderText = "End Prod Date"
        Me.EndProdDate.Name = "EndProdDate"
        Me.EndProdDate.Width = 60
        '
        'MpoPartID
        '
        Me.MpoPartID.HeaderText = "Part Number"
        Me.MpoPartID.Name = "MpoPartID"
        Me.MpoPartID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MpoPartID.Width = 80
        '
        'QtyActual
        '
        Me.QtyActual.HeaderText = "Qty Actual"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.Width = 60
        '
        'QtyEngReleased
        '
        Me.QtyEngReleased.HeaderText = "Start Qty"
        Me.QtyEngReleased.Name = "QtyEngReleased"
        Me.QtyEngReleased.Width = 60
        '
        'QtyOrder
        '
        Me.QtyOrder.HeaderText = "Sales Qty. Requested"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.Width = 60
        '
        'MpoStatus
        '
        Me.MpoStatus.HeaderText = "Mpo Status"
        Me.MpoStatus.Items.AddRange(New Object() {"Active", "Closed", "Cancelled"})
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MpoStatus.Width = 60
        '
        'DeptID
        '
        Me.DeptID.HeaderText = "Dept."
        Me.DeptID.Name = "DeptID"
        Me.DeptID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'MpoNotes
        '
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MpoNotes.DefaultCellStyle = DataGridViewCellStyle6
        Me.MpoNotes.HeaderText = "Notes"
        Me.MpoNotes.Name = "MpoNotes"
        Me.MpoNotes.Width = 200
        '
        'frmOrderAssignDellivToMPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 772)
        Me.Controls.Add(Me.RdNo)
        Me.Controls.Add(Me.RdYes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgSelMPO)
        Me.Controls.Add(Me.CmbPart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.SrcMPO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdAssg)
        Me.Controls.Add(Me.dgOrd)
        Me.Controls.Add(Me.dgDel)
        Me.Controls.Add(Me.dgMpo)
        Me.Name = "frmOrderAssignDellivToMPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  MPO Delivery Date"
        CType(Me.dgMpo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSelMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgMpo As System.Windows.Forms.DataGridView
    Friend WithEvents dgDel As System.Windows.Forms.DataGridView
    Friend WithEvents dgOrd As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAssg As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SrcMPO As System.Windows.Forms.TextBox
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OrderItemsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NotesOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDelivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsIDDeliv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SwShipedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQtyToShip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivWhat As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DelivNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMpoQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSelMPO As System.Windows.Forms.DataGridView
    Friend WithEvents OrdDelivIDSel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNoSel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RdYes As System.Windows.Forms.RadioButton
    Friend WithEvents RdNo As System.Windows.Forms.RadioButton
    Friend WithEvents MpoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsIDMpo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDelivIDMpo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoDelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPromDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyEngReleased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MpoNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
