<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesPlanningFPInventory
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
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmbPartNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgSel = New System.Windows.Forms.DataGridView
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyToShip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalcStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeptMPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeptPer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtFPStock = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgMatlPref = New System.Windows.Forms.DataGridView
        Me.PartMatlID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MatlPrefPartID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LinkCombKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MatlID = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.MatlDetIDPref = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.MatlForm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MatlDia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmdShowRM = New System.Windows.Forms.Button
        Me.CmdRmAnalize = New System.Windows.Forms.Button
        Me.SwFPPrev = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMatlPref, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbPartNumber
        '
        Me.CmbPartNumber.DropDownHeight = 700
        Me.CmbPartNumber.DropDownWidth = 200
        Me.CmbPartNumber.FormattingEnabled = True
        Me.CmbPartNumber.IntegralHeight = False
        Me.CmbPartNumber.Location = New System.Drawing.Point(132, 27)
        Me.CmbPartNumber.Name = "CmbPartNumber"
        Me.CmbPartNumber.Size = New System.Drawing.Size(270, 21)
        Me.CmbPartNumber.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number"
        '
        'dgSel
        '
        Me.dgSel.AllowUserToAddRows = False
        Me.dgSel.AllowUserToDeleteRows = False
        Me.dgSel.AllowUserToResizeRows = False
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dgSel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgSel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgSel.ColumnHeadersHeight = 45
        Me.dgSel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerShort, Me.OrdNumber, Me.MpoPartRev, Me.DelivDate, Me.QtyToShip, Me.CalcStock, Me.DeptMPO, Me.DeptPer, Me.MpoType, Me.SwOrder})
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSel.DefaultCellStyle = DataGridViewCellStyle29
        Me.dgSel.Location = New System.Drawing.Point(1, 129)
        Me.dgSel.Name = "dgSel"
        Me.dgSel.ReadOnly = True
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSel.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgSel.RowHeadersWidth = 25
        Me.dgSel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle31.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSel.RowsDefaultCellStyle = DataGridViewCellStyle31
        Me.dgSel.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSel.RowTemplate.Height = 25
        Me.dgSel.Size = New System.Drawing.Size(692, 594)
        Me.dgSel.TabIndex = 28
        Me.dgSel.Text = "DataGridView1"
        '
        'CustomerShort
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CustomerShort.DefaultCellStyle = DataGridViewCellStyle22
        Me.CustomerShort.HeaderText = "CustomerShort"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.ReadOnly = True
        Me.CustomerShort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CustomerShort.Width = 70
        '
        'OrdNumber
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.OrdNumber.DefaultCellStyle = DataGridViewCellStyle23
        Me.OrdNumber.HeaderText = "Order / MPO"
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.ReadOnly = True
        Me.OrdNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OrdNumber.Width = 90
        '
        'MpoPartRev
        '
        Me.MpoPartRev.HeaderText = "Part Rev."
        Me.MpoPartRev.Name = "MpoPartRev"
        Me.MpoPartRev.ReadOnly = True
        Me.MpoPartRev.Width = 60
        '
        'DelivDate
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DelivDate.DefaultCellStyle = DataGridViewCellStyle24
        Me.DelivDate.HeaderText = "Order Deliv. Date / Prod End Date"
        Me.DelivDate.Name = "DelivDate"
        Me.DelivDate.ReadOnly = True
        Me.DelivDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DelivDate.Width = 80
        '
        'QtyToShip
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N0"
        DataGridViewCellStyle25.NullValue = Nothing
        Me.QtyToShip.DefaultCellStyle = DataGridViewCellStyle25
        Me.QtyToShip.HeaderText = "Qty Trans"
        Me.QtyToShip.Name = "QtyToShip"
        Me.QtyToShip.ReadOnly = True
        Me.QtyToShip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.QtyToShip.Width = 70
        '
        'CalcStock
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CalcStock.DefaultCellStyle = DataGridViewCellStyle26
        Me.CalcStock.HeaderText = "Stock"
        Me.CalcStock.Name = "CalcStock"
        Me.CalcStock.ReadOnly = True
        Me.CalcStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CalcStock.Width = 70
        '
        'DeptMPO
        '
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeptMPO.DefaultCellStyle = DataGridViewCellStyle27
        Me.DeptMPO.HeaderText = "Department"
        Me.DeptMPO.Name = "DeptMPO"
        Me.DeptMPO.ReadOnly = True
        Me.DeptMPO.Width = 90
        '
        'DeptPer
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeptPer.DefaultCellStyle = DataGridViewCellStyle28
        Me.DeptPer.HeaderText = "%"
        Me.DeptPer.Name = "DeptPer"
        Me.DeptPer.ReadOnly = True
        Me.DeptPer.Width = 50
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "Mpo Type"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.ReadOnly = True
        Me.MpoType.Width = 65
        '
        'SwOrder
        '
        Me.SwOrder.HeaderText = "SwOrder"
        Me.SwOrder.MinimumWidth = 2
        Me.SwOrder.Name = "SwOrder"
        Me.SwOrder.ReadOnly = True
        Me.SwOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SwOrder.Visible = False
        Me.SwOrder.Width = 2
        '
        'txtFPStock
        '
        Me.txtFPStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPStock.Location = New System.Drawing.Point(287, 68)
        Me.txtFPStock.Name = "txtFPStock"
        Me.txtFPStock.Size = New System.Drawing.Size(115, 24)
        Me.txtFPStock.TabIndex = 29
        Me.txtFPStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(263, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Stock FP (Without RND/Qualification)"
        '
        'dgMatlPref
        '
        Me.dgMatlPref.AllowUserToAddRows = False
        Me.dgMatlPref.AllowUserToDeleteRows = False
        Me.dgMatlPref.AllowUserToResizeRows = False
        DataGridViewCellStyle32.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMatlPref.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle32
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMatlPref.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.dgMatlPref.ColumnHeadersHeight = 35
        Me.dgMatlPref.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMatlPref.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartMatlID, Me.MatlPrefPartID, Me.LinkCombKey, Me.MatlID, Me.MatlDetIDPref, Me.MatlForm, Me.MatlDia})
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle36.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMatlPref.DefaultCellStyle = DataGridViewCellStyle36
        Me.dgMatlPref.Location = New System.Drawing.Point(699, 129)
        Me.dgMatlPref.Name = "dgMatlPref"
        Me.dgMatlPref.ReadOnly = True
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMatlPref.RowHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgMatlPref.RowHeadersWidth = 25
        Me.dgMatlPref.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle38.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMatlPref.RowsDefaultCellStyle = DataGridViewCellStyle38
        Me.dgMatlPref.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMatlPref.RowTemplate.Height = 18
        Me.dgMatlPref.Size = New System.Drawing.Size(406, 131)
        Me.dgMatlPref.TabIndex = 40
        Me.dgMatlPref.Text = "DataGridView1"
        '
        'PartMatlID
        '
        Me.PartMatlID.HeaderText = "PartMatlID"
        Me.PartMatlID.MinimumWidth = 2
        Me.PartMatlID.Name = "PartMatlID"
        Me.PartMatlID.ReadOnly = True
        Me.PartMatlID.Visible = False
        Me.PartMatlID.Width = 2
        '
        'MatlPrefPartID
        '
        Me.MatlPrefPartID.HeaderText = "MatlPrefPartID"
        Me.MatlPrefPartID.MinimumWidth = 2
        Me.MatlPrefPartID.Name = "MatlPrefPartID"
        Me.MatlPrefPartID.ReadOnly = True
        Me.MatlPrefPartID.Visible = False
        Me.MatlPrefPartID.Width = 2
        '
        'LinkCombKey
        '
        Me.LinkCombKey.HeaderText = "LinkCombKey"
        Me.LinkCombKey.MinimumWidth = 2
        Me.LinkCombKey.Name = "LinkCombKey"
        Me.LinkCombKey.ReadOnly = True
        Me.LinkCombKey.Visible = False
        Me.LinkCombKey.Width = 2
        '
        'MatlID
        '
        Me.MatlID.HeaderText = "Preferred Material"
        Me.MatlID.Name = "MatlID"
        Me.MatlID.ReadOnly = True
        Me.MatlID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MatlID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MatlID.Width = 200
        '
        'MatlDetIDPref
        '
        Me.MatlDetIDPref.HeaderText = "Matl Type"
        Me.MatlDetIDPref.Name = "MatlDetIDPref"
        Me.MatlDetIDPref.ReadOnly = True
        Me.MatlDetIDPref.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MatlDetIDPref.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MatlDetIDPref.Width = 80
        '
        'MatlForm
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatlForm.DefaultCellStyle = DataGridViewCellStyle34
        Me.MatlForm.HeaderText = "Matl Form"
        Me.MatlForm.Name = "MatlForm"
        Me.MatlForm.ReadOnly = True
        Me.MatlForm.Width = 45
        '
        'MatlDia
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatlDia.DefaultCellStyle = DataGridViewCellStyle35
        Me.MatlDia.HeaderText = "Matl Dia"
        Me.MatlDia.Name = "MatlDia"
        Me.MatlDia.ReadOnly = True
        Me.MatlDia.Width = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(696, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Part Number  --  Preferred Material"
        '
        'CmdShowRM
        '
        Me.CmdShowRM.BackColor = System.Drawing.Color.Khaki
        Me.CmdShowRM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdShowRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdShowRM.Location = New System.Drawing.Point(866, 303)
        Me.CmdShowRM.Name = "CmdShowRM"
        Me.CmdShowRM.Size = New System.Drawing.Size(69, 41)
        Me.CmdShowRM.TabIndex = 75
        Me.CmdShowRM.Text = "RM  Inventory"
        Me.CmdShowRM.UseVisualStyleBackColor = False
        '
        'CmdRmAnalize
        '
        Me.CmdRmAnalize.BackColor = System.Drawing.Color.Khaki
        Me.CmdRmAnalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdRmAnalize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdRmAnalize.Location = New System.Drawing.Point(741, 303)
        Me.CmdRmAnalize.Name = "CmdRmAnalize"
        Me.CmdRmAnalize.Size = New System.Drawing.Size(69, 41)
        Me.CmdRmAnalize.TabIndex = 76
        Me.CmdRmAnalize.Text = "RM  Analyze"
        Me.CmdRmAnalize.UseVisualStyleBackColor = False
        '
        'SwFPPrev
        '
        Me.SwFPPrev.BackColor = System.Drawing.Color.Red
        Me.SwFPPrev.ForeColor = System.Drawing.Color.Black
        Me.SwFPPrev.Location = New System.Drawing.Point(963, 12)
        Me.SwFPPrev.Name = "SwFPPrev"
        Me.SwFPPrev.Size = New System.Drawing.Size(16, 20)
        Me.SwFPPrev.TabIndex = 222
        Me.SwFPPrev.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Khaki
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1009, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 41)
        Me.Button1.TabIndex = 223
        Me.Button1.Text = "Shop Floor Control"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmSalesPlanningFPInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1112, 735)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SwFPPrev)
        Me.Controls.Add(Me.CmdRmAnalize)
        Me.Controls.Add(Me.CmdShowRM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgMatlPref)
        Me.Controls.Add(Me.txtFPStock)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgSel)
        Me.Controls.Add(Me.CmbPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSalesPlanningFPInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada - Forecast By Item"
        CType(Me.dgSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgMatlPref, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgSel As System.Windows.Forms.DataGridView
    Friend WithEvents txtFPStock As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgMatlPref As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdShowRM As System.Windows.Forms.Button
    Friend WithEvents CmdRmAnalize As System.Windows.Forms.Button
    Friend WithEvents PartMatlID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlPrefPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkCombKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MatlDetIDPref As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MatlForm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlDia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwFPPrev As System.Windows.Forms.TextBox
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyToShip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalcStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptMPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
