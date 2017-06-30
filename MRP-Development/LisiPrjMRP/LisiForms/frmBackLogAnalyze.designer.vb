<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackLogAnalyze
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
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.CmbSelCust = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOrder = New System.Windows.Forms.TextBox
        Me.CmdExport = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RdCorp = New System.Windows.Forms.RadioButton
        Me.RDBooking = New System.Windows.Forms.RadioButton
        Me.RdBacklogActive = New System.Windows.Forms.RadioButton
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PlDgOrder = New System.Windows.Forms.Panel
        Me.dgOrder = New System.Windows.Forms.DataGridView
        Me.year = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivFermDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Country = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDevise = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwShipedQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeptNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NotesOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoTechNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PlCorp = New System.Windows.Forms.Panel
        Me.dgCorp = New System.Windows.Forms.DataGridView
        Me.DelivFermDatecor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShortCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNumberCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDateCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNameCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwDia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwMatlType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemNoCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivDateCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivQtyCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwShipedQtyCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemPriceCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDeviseCor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwWIPQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwStPart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdPartNoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.PlDgOrder.SuspendLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlCorp.SuspendLayout()
        CType(Me.dgCorp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(914, 7)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 43
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(914, 37)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 42
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(310, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Date To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(439, 36)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(88, 20)
        Me.txtDateTo.TabIndex = 40
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(745, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Part No."
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(797, 19)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(98, 20)
        Me.txtPart.TabIndex = 38
        Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbSelCust
        '
        Me.CmbSelCust.DropDownHeight = 600
        Me.CmbSelCust.DropDownWidth = 200
        Me.CmbSelCust.FormattingEnabled = True
        Me.CmbSelCust.IntegralHeight = False
        Me.CmbSelCust.Location = New System.Drawing.Point(635, 8)
        Me.CmbSelCust.Name = "CmbSelCust"
        Me.CmbSelCust.Size = New System.Drawing.Size(98, 21)
        Me.CmbSelCust.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(579, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(310, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(439, 7)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(88, 20)
        Me.txtDateFrom.TabIndex = 34
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(579, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Order No."
        '
        'txtOrder
        '
        Me.txtOrder.Location = New System.Drawing.Point(635, 38)
        Me.txtOrder.Name = "txtOrder"
        Me.txtOrder.Size = New System.Drawing.Size(98, 20)
        Me.txtOrder.TabIndex = 44
        Me.txtOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1047, 10)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 46
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.RdCorp)
        Me.Panel1.Controls.Add(Me.RDBooking)
        Me.Panel1.Controls.Add(Me.RdBacklogActive)
        Me.Panel1.Location = New System.Drawing.Point(12, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 72)
        Me.Panel1.TabIndex = 49
        '
        'RdCorp
        '
        Me.RdCorp.AutoSize = True
        Me.RdCorp.Location = New System.Drawing.Point(14, 6)
        Me.RdCorp.Name = "RdCorp"
        Me.RdCorp.Size = New System.Drawing.Size(224, 17)
        Me.RdCorp.TabIndex = 51
        Me.RdCorp.TabStop = True
        Me.RdCorp.Text = "BackLog (Active Orders) Format Corporatif"
        Me.RdCorp.UseVisualStyleBackColor = True
        '
        'RDBooking
        '
        Me.RDBooking.AutoSize = True
        Me.RDBooking.Location = New System.Drawing.Point(14, 47)
        Me.RDBooking.Name = "RDBooking"
        Me.RDBooking.Size = New System.Drawing.Size(209, 17)
        Me.RDBooking.TabIndex = 50
        Me.RDBooking.TabStop = True
        Me.RDBooking.Text = "All Orders - Confirmed By Booking Date"
        Me.RDBooking.UseVisualStyleBackColor = True
        '
        'RdBacklogActive
        '
        Me.RdBacklogActive.AutoSize = True
        Me.RdBacklogActive.Location = New System.Drawing.Point(14, 26)
        Me.RdBacklogActive.Name = "RdBacklogActive"
        Me.RdBacklogActive.Size = New System.Drawing.Size(223, 17)
        Me.RdBacklogActive.TabIndex = 49
        Me.RdBacklogActive.TabStop = True
        Me.RdBacklogActive.Text = "BackLog (Active Orders) By Delivery Date"
        Me.RdBacklogActive.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(822, 721)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(112, 20)
        Me.txtValue.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(752, 718)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 26)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Total Value" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "!!! Devise !!!"
        '
        'PlDgOrder
        '
        Me.PlDgOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlDgOrder.Controls.Add(Me.dgOrder)
        Me.PlDgOrder.Location = New System.Drawing.Point(12, 84)
        Me.PlDgOrder.Name = "PlDgOrder"
        Me.PlDgOrder.Size = New System.Drawing.Size(1099, 616)
        Me.PlDgOrder.TabIndex = 52
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.AllowUserToResizeRows = False
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOrder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle27
        Me.dgOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dgOrder.ColumnHeadersHeight = 45
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.year, Me.month, Me.DelivFermDate, Me.CustomerShort, Me.Country, Me.MpoType, Me.OrdNumber, Me.OrdItemNo, Me.PartNumber, Me.OrdDate, Me.DelivDate, Me.PartName, Me.DelivQty, Me.OrdValue, Me.OrdItemPrice, Me.OrdDevise, Me.DelivType, Me.SwShipedQty, Me.MpoNo, Me.QtyActual, Me.DeptNode, Me.DelivNotes, Me.NotesOrder, Me.MpoNotes, Me.MpoTechNotes, Me.OrdStatus, Me.OrdItemStatus, Me.DelivStatus})
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOrder.DefaultCellStyle = DataGridViewCellStyle33
        Me.dgOrder.Location = New System.Drawing.Point(3, 3)
        Me.dgOrder.Name = "dgOrder"
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgOrder.RowHeadersWidth = 25
        Me.dgOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle35.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOrder.RowsDefaultCellStyle = DataGridViewCellStyle35
        Me.dgOrder.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOrder.RowTemplate.Height = 18
        Me.dgOrder.Size = New System.Drawing.Size(1093, 610)
        Me.dgOrder.TabIndex = 26
        Me.dgOrder.Text = "DataGridView1"
        '
        'year
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.year.DefaultCellStyle = DataGridViewCellStyle29
        Me.year.HeaderText = "Year"
        Me.year.Name = "year"
        Me.year.Width = 40
        '
        'month
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.month.DefaultCellStyle = DataGridViewCellStyle30
        Me.month.HeaderText = "Month"
        Me.month.Name = "month"
        Me.month.Width = 40
        '
        'DelivFermDate
        '
        Me.DelivFermDate.HeaderText = "Booking Date"
        Me.DelivFermDate.Name = "DelivFermDate"
        Me.DelivFermDate.Width = 70
        '
        'CustomerShort
        '
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 60
        '
        'Country
        '
        Me.Country.HeaderText = "Country"
        Me.Country.Name = "Country"
        Me.Country.Width = 50
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "MPO Type"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 50
        '
        'OrdNumber
        '
        Me.OrdNumber.HeaderText = "Order Number"
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.Width = 60
        '
        'OrdItemNo
        '
        Me.OrdItemNo.HeaderText = "Item No"
        Me.OrdItemNo.Name = "OrdItemNo"
        Me.OrdItemNo.Width = 40
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Width = 60
        '
        'OrdDate
        '
        Me.OrdDate.HeaderText = "Order Date"
        Me.OrdDate.Name = "OrdDate"
        Me.OrdDate.Width = 70
        '
        'DelivDate
        '
        Me.DelivDate.HeaderText = "Deliv. Date"
        Me.DelivDate.Name = "DelivDate"
        Me.DelivDate.Width = 70
        '
        'PartName
        '
        Me.PartName.HeaderText = "PartName"
        Me.PartName.Name = "PartName"
        Me.PartName.Width = 50
        '
        'DelivQty
        '
        Me.DelivQty.HeaderText = "Deliv. Qty"
        Me.DelivQty.Name = "DelivQty"
        Me.DelivQty.Width = 60
        '
        'OrdValue
        '
        DataGridViewCellStyle31.Format = "C2"
        Me.OrdValue.DefaultCellStyle = DataGridViewCellStyle31
        Me.OrdValue.HeaderText = "OrdValue"
        Me.OrdValue.Name = "OrdValue"
        Me.OrdValue.Width = 70
        '
        'OrdItemPrice
        '
        DataGridViewCellStyle32.Format = "C2"
        Me.OrdItemPrice.DefaultCellStyle = DataGridViewCellStyle32
        Me.OrdItemPrice.HeaderText = "Price"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.Width = 50
        '
        'OrdDevise
        '
        Me.OrdDevise.HeaderText = "Devise"
        Me.OrdDevise.Name = "OrdDevise"
        Me.OrdDevise.Width = 40
        '
        'DelivType
        '
        Me.DelivType.HeaderText = "Order Type"
        Me.DelivType.Name = "DelivType"
        Me.DelivType.Width = 60
        '
        'SwShipedQty
        '
        Me.SwShipedQty.HeaderText = "Shipped Qty"
        Me.SwShipedQty.Name = "SwShipedQty"
        Me.SwShipedQty.Width = 60
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "MPO No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.Width = 60
        '
        'QtyActual
        '
        Me.QtyActual.HeaderText = "Actual Qty."
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.Width = 60
        '
        'DeptNode
        '
        Me.DeptNode.HeaderText = "Dept."
        Me.DeptNode.Name = "DeptNode"
        Me.DeptNode.Width = 60
        '
        'DelivNotes
        '
        Me.DelivNotes.HeaderText = "Deliv. Notes"
        Me.DelivNotes.Name = "DelivNotes"
        Me.DelivNotes.Width = 70
        '
        'NotesOrder
        '
        Me.NotesOrder.HeaderText = "Order Notes"
        Me.NotesOrder.Name = "NotesOrder"
        Me.NotesOrder.Width = 70
        '
        'MpoNotes
        '
        Me.MpoNotes.HeaderText = "MPO Notes"
        Me.MpoNotes.Name = "MpoNotes"
        Me.MpoNotes.Width = 70
        '
        'MpoTechNotes
        '
        Me.MpoTechNotes.HeaderText = "MPO Tech. Notes"
        Me.MpoTechNotes.Name = "MpoTechNotes"
        Me.MpoTechNotes.Width = 70
        '
        'OrdStatus
        '
        Me.OrdStatus.HeaderText = "OrdStatus"
        Me.OrdStatus.Name = "OrdStatus"
        Me.OrdStatus.Width = 50
        '
        'OrdItemStatus
        '
        Me.OrdItemStatus.HeaderText = "OrdItemStatus"
        Me.OrdItemStatus.Name = "OrdItemStatus"
        Me.OrdItemStatus.Width = 50
        '
        'DelivStatus
        '
        Me.DelivStatus.HeaderText = "DelivStatus"
        Me.DelivStatus.Name = "DelivStatus"
        Me.DelivStatus.Width = 50
        '
        'PlCorp
        '
        Me.PlCorp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlCorp.Controls.Add(Me.dgCorp)
        Me.PlCorp.Location = New System.Drawing.Point(15, 84)
        Me.PlCorp.Name = "PlCorp"
        Me.PlCorp.Size = New System.Drawing.Size(1104, 629)
        Me.PlCorp.TabIndex = 53
        '
        'dgCorp
        '
        Me.dgCorp.AllowUserToAddRows = False
        Me.dgCorp.AllowUserToResizeRows = False
        DataGridViewCellStyle36.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgCorp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle36
        Me.dgCorp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCorp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgCorp.ColumnHeadersHeight = 45
        Me.dgCorp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgCorp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DelivFermDatecor, Me.CustomerID, Me.CustomerShortCor, Me.OrdNumberCor, Me.OrdDateCor, Me.PartNumberCor, Me.PartDescCode, Me.PartNameCor, Me.SwDia, Me.SwMatlType, Me.OrdItemNoCor, Me.DelivDateCor, Me.DelivQtyCor, Me.SwShipedQtyCor, Me.SwBalance, Me.OrdItemPriceCor, Me.SwValue, Me.OrdDeviseCor, Me.SwWIPQty, Me.SwStPart, Me.SwDate, Me.OrdPartNoID})
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle50.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCorp.DefaultCellStyle = DataGridViewCellStyle50
        Me.dgCorp.Location = New System.Drawing.Point(3, 3)
        Me.dgCorp.Name = "dgCorp"
        Me.dgCorp.ReadOnly = True
        DataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle51.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCorp.RowHeadersDefaultCellStyle = DataGridViewCellStyle51
        Me.dgCorp.RowHeadersWidth = 25
        Me.dgCorp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle52.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgCorp.RowsDefaultCellStyle = DataGridViewCellStyle52
        Me.dgCorp.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgCorp.RowTemplate.Height = 18
        Me.dgCorp.Size = New System.Drawing.Size(1098, 623)
        Me.dgCorp.TabIndex = 27
        Me.dgCorp.Text = "DataGridView1"
        '
        'DelivFermDatecor
        '
        Me.DelivFermDatecor.HeaderText = "Booking Date"
        Me.DelivFermDatecor.Name = "DelivFermDatecor"
        Me.DelivFermDatecor.ReadOnly = True
        Me.DelivFermDatecor.Width = 70
        '
        'CustomerID
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CustomerID.DefaultCellStyle = DataGridViewCellStyle38
        Me.CustomerID.HeaderText = "Customer ID"
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.ReadOnly = True
        Me.CustomerID.Width = 50
        '
        'CustomerShortCor
        '
        Me.CustomerShortCor.HeaderText = "Customer"
        Me.CustomerShortCor.Name = "CustomerShortCor"
        Me.CustomerShortCor.ReadOnly = True
        Me.CustomerShortCor.Width = 60
        '
        'OrdNumberCor
        '
        Me.OrdNumberCor.HeaderText = "Order Number"
        Me.OrdNumberCor.Name = "OrdNumberCor"
        Me.OrdNumberCor.ReadOnly = True
        Me.OrdNumberCor.Width = 60
        '
        'OrdDateCor
        '
        Me.OrdDateCor.HeaderText = "Order Date"
        Me.OrdDateCor.Name = "OrdDateCor"
        Me.OrdDateCor.ReadOnly = True
        Me.OrdDateCor.Width = 70
        '
        'PartNumberCor
        '
        Me.PartNumberCor.HeaderText = "Part Number"
        Me.PartNumberCor.Name = "PartNumberCor"
        Me.PartNumberCor.ReadOnly = True
        Me.PartNumberCor.Width = 60
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "Desc Code"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.ReadOnly = True
        Me.PartDescCode.Width = 70
        '
        'PartNameCor
        '
        Me.PartNameCor.HeaderText = "Part Name"
        Me.PartNameCor.Name = "PartNameCor"
        Me.PartNameCor.ReadOnly = True
        Me.PartNameCor.Width = 50
        '
        'SwDia
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.Moccasin
        Me.SwDia.DefaultCellStyle = DataGridViewCellStyle39
        Me.SwDia.HeaderText = "Dia"
        Me.SwDia.Name = "SwDia"
        Me.SwDia.ReadOnly = True
        Me.SwDia.Width = 50
        '
        'SwMatlType
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.Moccasin
        Me.SwMatlType.DefaultCellStyle = DataGridViewCellStyle40
        Me.SwMatlType.HeaderText = "Material"
        Me.SwMatlType.Name = "SwMatlType"
        Me.SwMatlType.ReadOnly = True
        Me.SwMatlType.Width = 60
        '
        'OrdItemNoCor
        '
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.OrdItemNoCor.DefaultCellStyle = DataGridViewCellStyle41
        Me.OrdItemNoCor.HeaderText = "Item No"
        Me.OrdItemNoCor.Name = "OrdItemNoCor"
        Me.OrdItemNoCor.ReadOnly = True
        Me.OrdItemNoCor.Width = 40
        '
        'DelivDateCor
        '
        Me.DelivDateCor.HeaderText = "Deliv. Date"
        Me.DelivDateCor.Name = "DelivDateCor"
        Me.DelivDateCor.ReadOnly = True
        Me.DelivDateCor.Width = 70
        '
        'DelivQtyCor
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N0"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.DelivQtyCor.DefaultCellStyle = DataGridViewCellStyle42
        Me.DelivQtyCor.HeaderText = "Deliv. Qty"
        Me.DelivQtyCor.Name = "DelivQtyCor"
        Me.DelivQtyCor.ReadOnly = True
        Me.DelivQtyCor.Width = 50
        '
        'SwShipedQtyCor
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle43.Format = "N0"
        DataGridViewCellStyle43.NullValue = Nothing
        Me.SwShipedQtyCor.DefaultCellStyle = DataGridViewCellStyle43
        Me.SwShipedQtyCor.HeaderText = "Shipped Qty"
        Me.SwShipedQtyCor.Name = "SwShipedQtyCor"
        Me.SwShipedQtyCor.ReadOnly = True
        Me.SwShipedQtyCor.Width = 50
        '
        'SwBalance
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle44.Format = "N0"
        DataGridViewCellStyle44.NullValue = Nothing
        Me.SwBalance.DefaultCellStyle = DataGridViewCellStyle44
        Me.SwBalance.HeaderText = "Balance"
        Me.SwBalance.Name = "SwBalance"
        Me.SwBalance.ReadOnly = True
        Me.SwBalance.Width = 50
        '
        'OrdItemPriceCor
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle45.Format = "C2"
        Me.OrdItemPriceCor.DefaultCellStyle = DataGridViewCellStyle45
        Me.OrdItemPriceCor.HeaderText = "Price"
        Me.OrdItemPriceCor.Name = "OrdItemPriceCor"
        Me.OrdItemPriceCor.ReadOnly = True
        Me.OrdItemPriceCor.Width = 50
        '
        'SwValue
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle46.Format = "C2"
        DataGridViewCellStyle46.NullValue = Nothing
        Me.SwValue.DefaultCellStyle = DataGridViewCellStyle46
        Me.SwValue.HeaderText = "Value Orig. Devise"
        Me.SwValue.Name = "SwValue"
        Me.SwValue.ReadOnly = True
        Me.SwValue.Width = 70
        '
        'OrdDeviseCor
        '
        Me.OrdDeviseCor.HeaderText = "Devise"
        Me.OrdDeviseCor.Name = "OrdDeviseCor"
        Me.OrdDeviseCor.ReadOnly = True
        Me.OrdDeviseCor.Width = 40
        '
        'SwWIPQty
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle47.Format = "N0"
        DataGridViewCellStyle47.NullValue = Nothing
        Me.SwWIPQty.DefaultCellStyle = DataGridViewCellStyle47
        Me.SwWIPQty.HeaderText = "WIP Qty"
        Me.SwWIPQty.Name = "SwWIPQty"
        Me.SwWIPQty.ReadOnly = True
        Me.SwWIPQty.Width = 50
        '
        'SwStPart
        '
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle48.Format = "N0"
        DataGridViewCellStyle48.NullValue = Nothing
        Me.SwStPart.DefaultCellStyle = DataGridViewCellStyle48
        Me.SwStPart.HeaderText = " Stock Qty"
        Me.SwStPart.Name = "SwStPart"
        Me.SwStPart.ReadOnly = True
        Me.SwStPart.Width = 50
        '
        'SwDate
        '
        DataGridViewCellStyle49.Format = "d"
        DataGridViewCellStyle49.NullValue = Nothing
        Me.SwDate.DefaultCellStyle = DataGridViewCellStyle49
        Me.SwDate.HeaderText = "Doc Date"
        Me.SwDate.Name = "SwDate"
        Me.SwDate.ReadOnly = True
        Me.SwDate.Width = 60
        '
        'OrdPartNoID
        '
        Me.OrdPartNoID.HeaderText = "OrdPartNoID"
        Me.OrdPartNoID.MinimumWidth = 2
        Me.OrdPartNoID.Name = "OrdPartNoID"
        Me.OrdPartNoID.ReadOnly = True
        Me.OrdPartNoID.Visible = False
        Me.OrdPartNoID.Width = 2
        '
        'frmBackLogAnalyze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 751)
        Me.Controls.Add(Me.PlCorp)
        Me.Controls.Add(Me.PlDgOrder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOrder)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.CmbSelCust)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Name = "frmBackLogAnalyze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Sales Analyze Module"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PlDgOrder.ResumeLayout(False)
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlCorp.ResumeLayout(False)
        CType(Me.dgCorp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents CmbSelCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrder As System.Windows.Forms.TextBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RDBooking As System.Windows.Forms.RadioButton
    Friend WithEvents RdBacklogActive As System.Windows.Forms.RadioButton
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PlDgOrder As System.Windows.Forms.Panel
    Friend WithEvents RdCorp As System.Windows.Forms.RadioButton
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents year As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivFermDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Country As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwShipedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NotesOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoTechNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlCorp As System.Windows.Forms.Panel
    Friend WithEvents dgCorp As System.Windows.Forms.DataGridView
    Friend WithEvents DelivFermDatecor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShortCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumberCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDateCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNameCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMatlType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemNoCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDateCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQtyCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwShipedQtyCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPriceCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDeviseCor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwWIPQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwStPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdPartNoID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
