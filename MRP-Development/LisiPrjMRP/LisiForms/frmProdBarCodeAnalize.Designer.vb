<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdBarCodeAnalize
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.dgProd = New System.Windows.Forms.DataGridView()
        Me.MpoPriority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwRouteStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwNoDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptNode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwSalesValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPOExpediteValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSeeMemo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CmdViewMethod = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.RdPlant = New System.Windows.Forms.RadioButton()
        Me.CmbPlant = New System.Windows.Forms.ComboBox()
        Me.RdOperator = New System.Windows.Forms.RadioButton()
        Me.CmbEmp = New System.Windows.Forms.ComboBox()
        Me.RdWC = New System.Windows.Forms.RadioButton()
        Me.CmbDept = New System.Windows.Forms.ComboBox()
        Me.RdPart = New System.Windows.Forms.RadioButton()
        Me.CmbPart = New System.Windows.Forms.ComboBox()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(1064, 13)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(97, 21)
        Me.CmdClear.TabIndex = 45
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(1064, 45)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(97, 21)
        Me.CmdSearch.TabIndex = 44
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgProd.ColumnHeadersHeight = 45
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoPriority, Me.CustomerShort, Me.MpoType, Me.MpoNo, Me.DelivDate, Me.PartNumber, Me.QtyActual, Me.QtyOrder, Me.SwRouteStart, Me.SwNoDays, Me.DeptNode, Me.OrdItemPrice, Me.SwSalesValue, Me.MPOExpediteValue, Me.MemoNo, Me.CmdSeeMemo, Me.CmdViewMethod})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgProd.Location = New System.Drawing.Point(13, 153)
        Me.dgProd.Name = "dgProd"
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgProd.RowHeadersWidth = 25
        Me.dgProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dgProd.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgProd.RowTemplate.Height = 18
        Me.dgProd.Size = New System.Drawing.Size(1250, 543)
        Me.dgProd.TabIndex = 46
        Me.dgProd.Text = "DataGridView1"
        '
        'MpoPriority
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.MpoPriority.DefaultCellStyle = DataGridViewCellStyle3
        Me.MpoPriority.HeaderText = "MPO Priority"
        Me.MpoPriority.Name = "MpoPriority"
        Me.MpoPriority.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MpoPriority.Width = 40
        '
        'CustomerShort
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerShort.DefaultCellStyle = DataGridViewCellStyle4
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 50
        '
        'MpoType
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MpoType.DefaultCellStyle = DataGridViewCellStyle5
        Me.MpoType.HeaderText = "Mpo Type"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 60
        '
        'MpoNo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoNo.DefaultCellStyle = DataGridViewCellStyle6
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
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        '
        'QtyActual
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyActual.DefaultCellStyle = DataGridViewCellStyle7
        Me.QtyActual.HeaderText = "Actual   Qty"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.Width = 50
        '
        'QtyOrder
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyOrder.DefaultCellStyle = DataGridViewCellStyle8
        Me.QtyOrder.HeaderText = "Sales Qty"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.Width = 50
        '
        'SwRouteStart
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.SwRouteStart.DefaultCellStyle = DataGridViewCellStyle9
        Me.SwRouteStart.HeaderText = "Dept. Start Date"
        Me.SwRouteStart.Name = "SwRouteStart"
        Me.SwRouteStart.Width = 70
        '
        'SwNoDays
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.SwNoDays.DefaultCellStyle = DataGridViewCellStyle10
        Me.SwNoDays.HeaderText = "#Days in Dept "
        Me.SwNoDays.Name = "SwNoDays"
        Me.SwNoDays.Width = 50
        '
        'DeptNode
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeptNode.DefaultCellStyle = DataGridViewCellStyle11
        Me.DeptNode.HeaderText = "Dept."
        Me.DeptNode.Name = "DeptNode"
        '
        'OrdItemPrice
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.OrdItemPrice.DefaultCellStyle = DataGridViewCellStyle12
        Me.OrdItemPrice.HeaderText = "Unit Price"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.Width = 60
        '
        'SwSalesValue
        '
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.SwSalesValue.DefaultCellStyle = DataGridViewCellStyle13
        Me.SwSalesValue.HeaderText = "Sales Value"
        Me.SwSalesValue.Name = "SwSalesValue"
        Me.SwSalesValue.Width = 70
        '
        'MPOExpediteValue
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Format = "C0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.MPOExpediteValue.DefaultCellStyle = DataGridViewCellStyle14
        Me.MPOExpediteValue.HeaderText = "Expedite Value"
        Me.MPOExpediteValue.Name = "MPOExpediteValue"
        Me.MPOExpediteValue.Width = 60
        '
        'MemoNo
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.MemoNo.HeaderText = "Memo No."
        Me.MemoNo.Name = "MemoNo"
        Me.MemoNo.Width = 45
        '
        'CmdSeeMemo
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightBlue
        Me.CmdSeeMemo.DefaultCellStyle = DataGridViewCellStyle16
        Me.CmdSeeMemo.HeaderText = "View MEMO"
        Me.CmdSeeMemo.Name = "CmdSeeMemo"
        Me.CmdSeeMemo.Text = "View "
        Me.CmdSeeMemo.UseColumnTextForButtonValue = True
        Me.CmdSeeMemo.Width = 60
        '
        'CmdViewMethod
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.SkyBlue
        Me.CmdViewMethod.DefaultCellStyle = DataGridViewCellStyle17
        Me.CmdViewMethod.HeaderText = "View MPO Traveler"
        Me.CmdViewMethod.Name = "CmdViewMethod"
        Me.CmdViewMethod.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CmdViewMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CmdViewMethod.Text = "View"
        Me.CmdViewMethod.UseColumnTextForButtonValue = True
        Me.CmdViewMethod.Width = 60
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 36)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Delivery Date To:  (mm/dd/yyyy)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(117, 90)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(103, 20)
        Me.txtDateTo.TabIndex = 56
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1186, 20)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(36, 36)
        Me.CmdExport.TabIndex = 83
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 36)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Delivery Date From:  (mm/dd/yyyy)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(117, 37)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(103, 20)
        Me.txtDateFrom.TabIndex = 84
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RdPlant
        '
        Me.RdPlant.AutoSize = True
        Me.RdPlant.Location = New System.Drawing.Point(339, 19)
        Me.RdPlant.Name = "RdPlant"
        Me.RdPlant.Size = New System.Drawing.Size(91, 17)
        Me.RdPlant.TabIndex = 86
        Me.RdPlant.TabStop = True
        Me.RdPlant.Text = "Plant 1/2/3/4"
        Me.RdPlant.UseVisualStyleBackColor = True
        '
        'CmbPlant
        '
        Me.CmbPlant.FormattingEnabled = True
        Me.CmbPlant.Items.AddRange(New Object() {"PL1", "PL2", "PL3", "PL4"})
        Me.CmbPlant.Location = New System.Drawing.Point(448, 15)
        Me.CmbPlant.Name = "CmbPlant"
        Me.CmbPlant.Size = New System.Drawing.Size(215, 21)
        Me.CmbPlant.TabIndex = 87
        '
        'RdOperator
        '
        Me.RdOperator.AutoSize = True
        Me.RdOperator.Location = New System.Drawing.Point(339, 48)
        Me.RdOperator.Name = "RdOperator"
        Me.RdOperator.Size = New System.Drawing.Size(97, 17)
        Me.RdOperator.TabIndex = 88
        Me.RdOperator.TabStop = True
        Me.RdOperator.Text = "Operator Name"
        Me.RdOperator.UseVisualStyleBackColor = True
        '
        'CmbEmp
        '
        Me.CmbEmp.FormattingEnabled = True
        Me.CmbEmp.Location = New System.Drawing.Point(448, 48)
        Me.CmbEmp.Name = "CmbEmp"
        Me.CmbEmp.Size = New System.Drawing.Size(215, 21)
        Me.CmbEmp.TabIndex = 89
        '
        'RdWC
        '
        Me.RdWC.AutoSize = True
        Me.RdWC.Location = New System.Drawing.Point(339, 85)
        Me.RdWC.Name = "RdWC"
        Me.RdWC.Size = New System.Drawing.Size(85, 17)
        Me.RdWC.TabIndex = 90
        Me.RdWC.TabStop = True
        Me.RdWC.Text = "Work Center"
        Me.RdWC.UseVisualStyleBackColor = True
        '
        'CmbDept
        '
        Me.CmbDept.FormattingEnabled = True
        Me.CmbDept.Location = New System.Drawing.Point(448, 84)
        Me.CmbDept.Name = "CmbDept"
        Me.CmbDept.Size = New System.Drawing.Size(215, 21)
        Me.CmbDept.TabIndex = 91
        '
        'RdPart
        '
        Me.RdPart.AutoSize = True
        Me.RdPart.Location = New System.Drawing.Point(339, 119)
        Me.RdPart.Name = "RdPart"
        Me.RdPart.Size = New System.Drawing.Size(81, 17)
        Me.RdPart.TabIndex = 92
        Me.RdPart.TabStop = True
        Me.RdPart.Text = "PartNumber"
        Me.RdPart.UseVisualStyleBackColor = True
        '
        'CmbPart
        '
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.Location = New System.Drawing.Point(448, 118)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.Size = New System.Drawing.Size(215, 21)
        Me.CmbPart.TabIndex = 93
        '
        'frmProdBarCodeAnalize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 713)
        Me.Controls.Add(Me.CmbPart)
        Me.Controls.Add(Me.RdPart)
        Me.Controls.Add(Me.CmbDept)
        Me.Controls.Add(Me.RdWC)
        Me.Controls.Add(Me.CmbEmp)
        Me.Controls.Add(Me.RdOperator)
        Me.Controls.Add(Me.CmbPlant)
        Me.Controls.Add(Me.RdPlant)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.dgProd)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Name = "frmProdBarCodeAnalize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Bar Code  Query Screen"
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents MpoPriority As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRouteStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwNoDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwSalesValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOExpediteValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSeeMemo As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CmdViewMethod As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents RdPlant As System.Windows.Forms.RadioButton
    Friend WithEvents CmbPlant As System.Windows.Forms.ComboBox
    Friend WithEvents RdOperator As System.Windows.Forms.RadioButton
    Friend WithEvents CmbEmp As System.Windows.Forms.ComboBox
    Friend WithEvents RdWC As System.Windows.Forms.RadioButton
    Friend WithEvents CmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents RdPart As System.Windows.Forms.RadioButton
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
End Class
