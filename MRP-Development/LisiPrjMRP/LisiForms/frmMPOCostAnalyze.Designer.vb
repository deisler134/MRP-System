<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMPOCostAnalyze
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateYear = New System.Windows.Forms.TextBox
        Me.CmdExport = New System.Windows.Forms.Button
        Me.dgMPO = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.CmbMpoType = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.CmbSelCust = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyEngReleased = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoLotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MatlWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPORMValueUsedCDN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoRMCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoMachCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwMachCostYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPOProcessingCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwMPOCostValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDaysINMFG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(810, 27)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 43
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(633, 27)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 42
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Year Selection (yyyy)"
        '
        'txtDateYear
        '
        Me.txtDateYear.BackColor = System.Drawing.Color.NavajoWhite
        Me.txtDateYear.Location = New System.Drawing.Point(148, 47)
        Me.txtDateYear.Name = "txtDateYear"
        Me.txtDateYear.Size = New System.Drawing.Size(131, 20)
        Me.txtDateYear.TabIndex = 34
        Me.txtDateYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1031, 19)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 46
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'dgMPO
        '
        Me.dgMPO.AllowUserToAddRows = False
        Me.dgMPO.AllowUserToDeleteRows = False
        Me.dgMPO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMPO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.dgMPO.ColumnHeadersHeight = 55
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoType, Me.MpoNo, Me.MpoStatus, Me.PartNumber, Me.QtyActual, Me.QtyEngReleased, Me.MpoDate, Me.MpoLotNo, Me.MatlWeight, Me.MPORMValueUsedCDN, Me.MpoRMCostCDN, Me.MpoMachCostCDN, Me.SwMachCostYear, Me.MPOProcessingCost, Me.SwTotalCost, Me.SwMPOCostValue, Me.TotalDaysINMFG, Me.MpoID})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgMPO.Location = New System.Drawing.Point(23, 78)
        Me.dgMPO.Name = "dgMPO"
        Me.dgMPO.ReadOnly = True
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgMPO.RowHeadersWidth = 25
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.Size = New System.Drawing.Size(1081, 569)
        Me.dgMPO.TabIndex = 53
        Me.dgMPO.Text = "DataGridView1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(909, 650)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 26)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Used Start Qty)"
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(997, 653)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(98, 20)
        Me.txtValue.TabIndex = 54
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbMpoType
        '
        Me.CmbMpoType.DropDownHeight = 600
        Me.CmbMpoType.DropDownWidth = 200
        Me.CmbMpoType.FormattingEnabled = True
        Me.CmbMpoType.IntegralHeight = False
        Me.CmbMpoType.Items.AddRange(New Object() {"Assembly", "Blanks", "Component", "Expedite", "F.A.I.", "Grinding", "ITAR / EAR", "Min/Max", "Qualification", "Remake", "RND", "RWK", "Standard", "Standard (RM NULL)", "Testing"})
        Me.CmbMpoType.Location = New System.Drawing.Point(148, 13)
        Me.CmbMpoType.Name = "CmbMpoType"
        Me.CmbMpoType.Size = New System.Drawing.Size(131, 21)
        Me.CmbMpoType.Sorted = True
        Me.CmbMpoType.TabIndex = 57
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(20, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(92, 13)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "Mpo Classification"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Part No."
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(378, 13)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(136, 20)
        Me.txtPart.TabIndex = 58
        Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbSelCust
        '
        Me.CmbSelCust.DropDownHeight = 600
        Me.CmbSelCust.DropDownWidth = 200
        Me.CmbSelCust.FormattingEnabled = True
        Me.CmbSelCust.IntegralHeight = False
        Me.CmbSelCust.Location = New System.Drawing.Point(378, 46)
        Me.CmbSelCust.Name = "CmbSelCust"
        Me.CmbSelCust.Size = New System.Drawing.Size(136, 21)
        Me.CmbSelCust.TabIndex = 61
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(322, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Customer"
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "Mpo Type"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.ReadOnly = True
        Me.MpoType.Width = 70
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "Mpo No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.ReadOnly = True
        Me.MpoNo.Width = 60
        '
        'MpoStatus
        '
        Me.MpoStatus.HeaderText = "Mpo Status"
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.ReadOnly = True
        Me.MpoStatus.Width = 60
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 120
        '
        'QtyActual
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyActual.DefaultCellStyle = DataGridViewCellStyle3
        Me.QtyActual.HeaderText = "Actual Qty"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.ReadOnly = True
        Me.QtyActual.Width = 60
        '
        'QtyEngReleased
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyEngReleased.DefaultCellStyle = DataGridViewCellStyle4
        Me.QtyEngReleased.HeaderText = "Start Qty"
        Me.QtyEngReleased.Name = "QtyEngReleased"
        Me.QtyEngReleased.ReadOnly = True
        Me.QtyEngReleased.Width = 60
        '
        'MpoDate
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.MpoDate.HeaderText = "Mpo Date"
        Me.MpoDate.Name = "MpoDate"
        Me.MpoDate.ReadOnly = True
        Me.MpoDate.Width = 70
        '
        'MpoLotNo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoLotNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.MpoLotNo.HeaderText = "Matl LotNo"
        Me.MpoLotNo.Name = "MpoLotNo"
        Me.MpoLotNo.ReadOnly = True
        Me.MpoLotNo.Width = 60
        '
        'MatlWeight
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatlWeight.DefaultCellStyle = DataGridViewCellStyle7
        Me.MatlWeight.HeaderText = "Matl Weight"
        Me.MatlWeight.Name = "MatlWeight"
        Me.MatlWeight.ReadOnly = True
        Me.MatlWeight.Width = 60
        '
        'MPORMValueUsedCDN
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.MPORMValueUsedCDN.DefaultCellStyle = DataGridViewCellStyle8
        Me.MPORMValueUsedCDN.HeaderText = "Matl Value Used (CDN)"
        Me.MPORMValueUsedCDN.Name = "MPORMValueUsedCDN"
        Me.MPORMValueUsedCDN.ReadOnly = True
        Me.MPORMValueUsedCDN.Width = 70
        '
        'MpoRMCostCDN
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.MpoRMCostCDN.DefaultCellStyle = DataGridViewCellStyle9
        Me.MpoRMCostCDN.HeaderText = "RM Unit Cost (CDN)"
        Me.MpoRMCostCDN.Name = "MpoRMCostCDN"
        Me.MpoRMCostCDN.ReadOnly = True
        Me.MpoRMCostCDN.Width = 70
        '
        'MpoMachCostCDN
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.MpoMachCostCDN.DefaultCellStyle = DataGridViewCellStyle10
        Me.MpoMachCostCDN.HeaderText = "Mach Cost (CDN)"
        Me.MpoMachCostCDN.Name = "MpoMachCostCDN"
        Me.MpoMachCostCDN.ReadOnly = True
        Me.MpoMachCostCDN.Width = 70
        '
        'SwMachCostYear
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.NavajoWhite
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.SwMachCostYear.DefaultCellStyle = DataGridViewCellStyle11
        Me.SwMachCostYear.HeaderText = "Mach Cost Year Selection"
        Me.SwMachCostYear.Name = "SwMachCostYear"
        Me.SwMachCostYear.ReadOnly = True
        Me.SwMachCostYear.Width = 70
        '
        'MPOProcessingCost
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.MPOProcessingCost.DefaultCellStyle = DataGridViewCellStyle12
        Me.MPOProcessingCost.HeaderText = "Processing Cost (CDN)"
        Me.MPOProcessingCost.Name = "MPOProcessingCost"
        Me.MPOProcessingCost.ReadOnly = True
        Me.MPOProcessingCost.Width = 70
        '
        'SwTotalCost
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.SwTotalCost.DefaultCellStyle = DataGridViewCellStyle13
        Me.SwTotalCost.HeaderText = "MFG Unit cost      (RM Unit Cost + Mach Cost Year Selection + Processing Cost)"
        Me.SwTotalCost.Name = "SwTotalCost"
        Me.SwTotalCost.ReadOnly = True
        Me.SwTotalCost.Width = 120
        '
        'SwMPOCostValue
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.SwMPOCostValue.DefaultCellStyle = DataGridViewCellStyle14
        Me.SwMPOCostValue.HeaderText = "Total MPO Cost (CDN)"
        Me.SwMPOCostValue.Name = "SwMPOCostValue"
        Me.SwMPOCostValue.ReadOnly = True
        Me.SwMPOCostValue.Width = 80
        '
        'TotalDaysINMFG
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotalDaysINMFG.DefaultCellStyle = DataGridViewCellStyle15
        Me.TotalDaysINMFG.HeaderText = "Total Days IN MFG"
        Me.TotalDaysINMFG.Name = "TotalDaysINMFG"
        Me.TotalDaysINMFG.ReadOnly = True
        Me.TotalDaysINMFG.Width = 50
        '
        'MpoID
        '
        Me.MpoID.HeaderText = "MpoID"
        Me.MpoID.MinimumWidth = 2
        Me.MpoID.Name = "MpoID"
        Me.MpoID.ReadOnly = True
        Me.MpoID.Visible = False
        Me.MpoID.Width = 2
        '
        'frmMPOCostAnalyze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 696)
        Me.Controls.Add(Me.CmbSelCust)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.CmbMpoType)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.dgMPO)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateYear)
        Me.Name = "frmMPOCostAnalyze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  MPO Cost Analyze Module"
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateYear As System.Windows.Forms.TextBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents CmbMpoType As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents CmbSelCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyEngReleased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoLotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPORMValueUsedCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoRMCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoMachCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMachCostYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOProcessingCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMPOCostValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDaysINMFG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
