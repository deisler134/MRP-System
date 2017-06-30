<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarCodeMBO
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgMPO = New System.Windows.Forms.DataGridView()
        Me.DeptPlant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptNode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyEngReleased = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwQtyProduced = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwQtyToProduce = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrOperDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiffTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdDevise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwRateMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteRoughFinish = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteComments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InfoQtyOkuma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InfoQtyRomi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InfoQtyMarked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteQtyAcc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteQtyInsp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteQtyRej = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteQtySetup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SetupCycleOther = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SetupCycleOkuma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SetupCycleRomi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.CmdMBO = New System.Windows.Forms.Button()
        Me.CmdOther = New System.Windows.Forms.Button()
        Me.PnlMBO = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.PnlQuery = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDateFromQuery = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateToQuery = New System.Windows.Forms.TextBox()
        Me.CmbEmp = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbDept = New System.Windows.Forms.ComboBox()
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMBO.SuspendLayout()
        Me.PnlQuery.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgMPO
        '
        Me.dgMPO.AllowUserToAddRows = False
        Me.dgMPO.AllowUserToDeleteRows = False
        Me.dgMPO.AllowUserToResizeRows = False
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgMPO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgMPO.ColumnHeadersHeight = 35
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DeptPlant, Me.DeptBarCode, Me.DeptNode, Me.MpoNo, Me.PartNumber, Me.QtyEngReleased, Me.QtyActual, Me.SwQtyProduced, Me.SwQtyToProduce, Me.OperNo, Me.TrOperDescr, Me.EmpName, Me.DiffTime, Me.OrdItemPrice, Me.OrdDevise, Me.SwRateMonth, Me.RouteRoughFinish, Me.RouteComments, Me.InfoQtyOkuma, Me.InfoQtyRomi, Me.InfoQtyMarked, Me.RouteQtyAcc, Me.RouteQtyInsp, Me.RouteQtyRej, Me.RouteQtySetup, Me.SetupCycleOther, Me.SetupCycleOkuma, Me.SetupCycleRomi, Me.RouteStart, Me.RouteEnd, Me.PartDescCode})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgMPO.Location = New System.Drawing.Point(12, 164)
        Me.dgMPO.Name = "dgMPO"
        Me.dgMPO.ReadOnly = True
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgMPO.RowHeadersWidth = 25
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.Size = New System.Drawing.Size(1768, 696)
        Me.dgMPO.TabIndex = 54
        Me.dgMPO.Text = "DataGridView1"
        '
        'DeptPlant
        '
        Me.DeptPlant.HeaderText = "Plant"
        Me.DeptPlant.Name = "DeptPlant"
        Me.DeptPlant.ReadOnly = True
        Me.DeptPlant.Width = 50
        '
        'DeptBarCode
        '
        Me.DeptBarCode.HeaderText = "Dept."
        Me.DeptBarCode.Name = "DeptBarCode"
        Me.DeptBarCode.ReadOnly = True
        Me.DeptBarCode.Width = 60
        '
        'DeptNode
        '
        Me.DeptNode.HeaderText = "Machine"
        Me.DeptNode.Name = "DeptNode"
        Me.DeptNode.ReadOnly = True
        Me.DeptNode.Width = 60
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "Mpo No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.ReadOnly = True
        Me.MpoNo.Width = 60
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 60
        '
        'QtyEngReleased
        '
        Me.QtyEngReleased.HeaderText = "Qty Start"
        Me.QtyEngReleased.Name = "QtyEngReleased"
        Me.QtyEngReleased.ReadOnly = True
        Me.QtyEngReleased.Width = 60
        '
        'QtyActual
        '
        Me.QtyActual.HeaderText = "Qty Actual"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.ReadOnly = True
        Me.QtyActual.Width = 60
        '
        'SwQtyProduced
        '
        Me.SwQtyProduced.HeaderText = "Qty Produced"
        Me.SwQtyProduced.Name = "SwQtyProduced"
        Me.SwQtyProduced.ReadOnly = True
        Me.SwQtyProduced.Width = 60
        '
        'SwQtyToProduce
        '
        Me.SwQtyToProduce.HeaderText = "Qty to Produce"
        Me.SwQtyToProduce.Name = "SwQtyToProduce"
        Me.SwQtyToProduce.ReadOnly = True
        Me.SwQtyToProduce.Width = 60
        '
        'OperNo
        '
        Me.OperNo.HeaderText = "Oper No"
        Me.OperNo.Name = "OperNo"
        Me.OperNo.ReadOnly = True
        Me.OperNo.Width = 60
        '
        'TrOperDescr
        '
        Me.TrOperDescr.HeaderText = "Oper Descr."
        Me.TrOperDescr.Name = "TrOperDescr"
        Me.TrOperDescr.ReadOnly = True
        Me.TrOperDescr.Width = 70
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "Operator"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 60
        '
        'DiffTime
        '
        Me.DiffTime.HeaderText = "Oper Time"
        Me.DiffTime.Name = "DiffTime"
        Me.DiffTime.ReadOnly = True
        Me.DiffTime.Width = 60
        '
        'OrdItemPrice
        '
        Me.OrdItemPrice.HeaderText = "Price"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.ReadOnly = True
        Me.OrdItemPrice.Width = 60
        '
        'OrdDevise
        '
        Me.OrdDevise.HeaderText = "Currency"
        Me.OrdDevise.Name = "OrdDevise"
        Me.OrdDevise.ReadOnly = True
        Me.OrdDevise.Width = 60
        '
        'SwRateMonth
        '
        Me.SwRateMonth.HeaderText = "Exch. Rate"
        Me.SwRateMonth.Name = "SwRateMonth"
        Me.SwRateMonth.ReadOnly = True
        Me.SwRateMonth.Width = 60
        '
        'RouteRoughFinish
        '
        Me.RouteRoughFinish.HeaderText = "Rough/Finish"
        Me.RouteRoughFinish.Name = "RouteRoughFinish"
        Me.RouteRoughFinish.ReadOnly = True
        Me.RouteRoughFinish.Width = 70
        '
        'RouteComments
        '
        Me.RouteComments.HeaderText = "Comments"
        Me.RouteComments.Name = "RouteComments"
        Me.RouteComments.ReadOnly = True
        '
        'InfoQtyOkuma
        '
        Me.InfoQtyOkuma.HeaderText = "Qty Okuma"
        Me.InfoQtyOkuma.Name = "InfoQtyOkuma"
        Me.InfoQtyOkuma.ReadOnly = True
        Me.InfoQtyOkuma.Width = 60
        '
        'InfoQtyRomi
        '
        Me.InfoQtyRomi.HeaderText = "Qty Romi"
        Me.InfoQtyRomi.Name = "InfoQtyRomi"
        Me.InfoQtyRomi.ReadOnly = True
        Me.InfoQtyRomi.Width = 60
        '
        'InfoQtyMarked
        '
        Me.InfoQtyMarked.HeaderText = "Qty Marked"
        Me.InfoQtyMarked.Name = "InfoQtyMarked"
        Me.InfoQtyMarked.ReadOnly = True
        Me.InfoQtyMarked.Width = 60
        '
        'RouteQtyAcc
        '
        Me.RouteQtyAcc.HeaderText = "Qty Acc"
        Me.RouteQtyAcc.Name = "RouteQtyAcc"
        Me.RouteQtyAcc.ReadOnly = True
        Me.RouteQtyAcc.Width = 60
        '
        'RouteQtyInsp
        '
        Me.RouteQtyInsp.HeaderText = "Qtry Insp"
        Me.RouteQtyInsp.Name = "RouteQtyInsp"
        Me.RouteQtyInsp.ReadOnly = True
        Me.RouteQtyInsp.Width = 60
        '
        'RouteQtyRej
        '
        Me.RouteQtyRej.HeaderText = "Qty Rej"
        Me.RouteQtyRej.Name = "RouteQtyRej"
        Me.RouteQtyRej.ReadOnly = True
        Me.RouteQtyRej.Width = 60
        '
        'RouteQtySetup
        '
        Me.RouteQtySetup.HeaderText = "Qty Setup"
        Me.RouteQtySetup.Name = "RouteQtySetup"
        Me.RouteQtySetup.ReadOnly = True
        Me.RouteQtySetup.Width = 60
        '
        'SetupCycleOther
        '
        Me.SetupCycleOther.HeaderText = "Cycle Run Mach"
        Me.SetupCycleOther.Name = "SetupCycleOther"
        Me.SetupCycleOther.ReadOnly = True
        Me.SetupCycleOther.Width = 60
        '
        'SetupCycleOkuma
        '
        Me.SetupCycleOkuma.HeaderText = "Cycle Run Okuma"
        Me.SetupCycleOkuma.Name = "SetupCycleOkuma"
        Me.SetupCycleOkuma.ReadOnly = True
        Me.SetupCycleOkuma.Width = 60
        '
        'SetupCycleRomi
        '
        Me.SetupCycleRomi.HeaderText = "Cycle Run Romi"
        Me.SetupCycleRomi.Name = "SetupCycleRomi"
        Me.SetupCycleRomi.ReadOnly = True
        Me.SetupCycleRomi.Width = 60
        '
        'RouteStart
        '
        Me.RouteStart.HeaderText = "Route Start"
        Me.RouteStart.Name = "RouteStart"
        Me.RouteStart.ReadOnly = True
        Me.RouteStart.Width = 60
        '
        'RouteEnd
        '
        Me.RouteEnd.HeaderText = "Route End"
        Me.RouteEnd.Name = "RouteEnd"
        Me.RouteEnd.ReadOnly = True
        Me.RouteEnd.Width = 60
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "Descr. Code"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.ReadOnly = True
        Me.PartDescCode.Width = 70
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(992, 63)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 37)
        Me.CmdSearch.TabIndex = 55
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(1308, 63)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 37)
        Me.CmdClear.TabIndex = 60
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1625, 63)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 67
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'CmdMBO
        '
        Me.CmdMBO.Location = New System.Drawing.Point(12, 16)
        Me.CmdMBO.Name = "CmdMBO"
        Me.CmdMBO.Size = New System.Drawing.Size(131, 36)
        Me.CmdMBO.TabIndex = 68
        Me.CmdMBO.Text = "MBO Query"
        Me.CmdMBO.UseVisualStyleBackColor = True
        '
        'CmdOther
        '
        Me.CmdOther.Location = New System.Drawing.Point(12, 94)
        Me.CmdOther.Name = "CmdOther"
        Me.CmdOther.Size = New System.Drawing.Size(131, 36)
        Me.CmdOther.TabIndex = 69
        Me.CmdOther.Text = "Query"
        Me.CmdOther.UseVisualStyleBackColor = True
        '
        'PnlMBO
        '
        Me.PnlMBO.Controls.Add(Me.Label4)
        Me.PnlMBO.Controls.Add(Me.txtDateFrom)
        Me.PnlMBO.Location = New System.Drawing.Point(168, 12)
        Me.PnlMBO.Name = "PnlMBO"
        Me.PnlMBO.Size = New System.Drawing.Size(252, 39)
        Me.PnlMBO.TabIndex = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Date (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(120, 10)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtDateFrom.TabIndex = 58
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PnlQuery
        '
        Me.PnlQuery.Controls.Add(Me.Label5)
        Me.PnlQuery.Controls.Add(Me.CmbDept)
        Me.PnlQuery.Controls.Add(Me.Label3)
        Me.PnlQuery.Controls.Add(Me.CmbEmp)
        Me.PnlQuery.Controls.Add(Me.Label2)
        Me.PnlQuery.Controls.Add(Me.txtDateToQuery)
        Me.PnlQuery.Controls.Add(Me.Label1)
        Me.PnlQuery.Controls.Add(Me.txtDateFromQuery)
        Me.PnlQuery.Location = New System.Drawing.Point(168, 71)
        Me.PnlQuery.Name = "PnlQuery"
        Me.PnlQuery.Size = New System.Drawing.Size(647, 75)
        Me.PnlQuery.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFromQuery
        '
        Me.txtDateFromQuery.Location = New System.Drawing.Point(141, 13)
        Me.txtDateFromQuery.Name = "txtDateFromQuery"
        Me.txtDateFromQuery.Size = New System.Drawing.Size(121, 20)
        Me.txtDateFromQuery.TabIndex = 60
        Me.txtDateFromQuery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Date TO (mm/dd/yyyy)"
        '
        'txtDateToQuery
        '
        Me.txtDateToQuery.Location = New System.Drawing.Point(141, 39)
        Me.txtDateToQuery.Name = "txtDateToQuery"
        Me.txtDateToQuery.Size = New System.Drawing.Size(121, 20)
        Me.txtDateToQuery.TabIndex = 62
        Me.txtDateToQuery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbEmp
        '
        Me.CmbEmp.FormattingEnabled = True
        Me.CmbEmp.Location = New System.Drawing.Point(365, 8)
        Me.CmbEmp.Name = "CmbEmp"
        Me.CmbEmp.Size = New System.Drawing.Size(264, 21)
        Me.CmbEmp.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Employee"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(297, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Department"
        '
        'CmbDept
        '
        Me.CmbDept.FormattingEnabled = True
        Me.CmbDept.Location = New System.Drawing.Point(365, 43)
        Me.CmbDept.Name = "CmbDept"
        Me.CmbDept.Size = New System.Drawing.Size(264, 21)
        Me.CmbDept.TabIndex = 66
        '
        'frmBarCodeMBO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1803, 872)
        Me.Controls.Add(Me.PnlQuery)
        Me.Controls.Add(Me.PnlMBO)
        Me.Controls.Add(Me.CmdOther)
        Me.Controls.Add(Me.CmdMBO)
        Me.Controls.Add(Me.dgMPO)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Name = "frmBarCodeMBO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Bar Code Production MBO Value"
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMBO.ResumeLayout(False)
        Me.PnlMBO.PerformLayout()
        Me.PnlQuery.ResumeLayout(False)
        Me.PnlQuery.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents DeptPlant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyEngReleased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwQtyProduced As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwQtyToProduce As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrOperDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiffTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRateMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteRoughFinish As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteComments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoQtyOkuma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoQtyRomi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoQtyMarked As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteQtyAcc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteQtyInsp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteQtyRej As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteQtySetup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupCycleOther As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupCycleOkuma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SetupCycleRomi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RouteEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdMBO As System.Windows.Forms.Button
    Friend WithEvents CmdOther As System.Windows.Forms.Button
    Friend WithEvents PnlMBO As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents PnlQuery As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDateToQuery As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateFromQuery As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbEmp As System.Windows.Forms.ComboBox
End Class
