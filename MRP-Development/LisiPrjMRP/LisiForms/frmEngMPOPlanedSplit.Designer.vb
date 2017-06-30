<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngMPOPlanedSplit
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanTool = New System.Windows.Forms.Panel
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmdReset = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSplitNo = New System.Windows.Forms.TextBox
        Me.CmdExec = New System.Windows.Forms.Button
        Me.dgMPO = New System.Windows.Forms.DataGridView
        Me.CmbMPO = New System.Windows.Forms.ComboBox
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoParent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoChild = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoPartID = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.MpoPartRev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyEngReleased = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderItemsID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDelivID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndProdDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoTechNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChNewOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChWFM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChWFT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoMatlWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoPartType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoLotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoRMCostCDN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPORMValueUsedCDN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPOProcessingCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDaysINMFG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoPriority = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PanTool.SuspendLayout()
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanTool
        '
        Me.PanTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanTool.Controls.Add(Me.CmdSave)
        Me.PanTool.Controls.Add(Me.CmdReset)
        Me.PanTool.Location = New System.Drawing.Point(12, 12)
        Me.PanTool.Name = "PanTool"
        Me.PanTool.Size = New System.Drawing.Size(769, 51)
        Me.PanTool.TabIndex = 182
        '
        'CmdSave
        '
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(645, 14)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 177
        Me.CmdSave.Text = "Save"
        '
        'CmdReset
        '
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(13, 14)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(84, 23)
        Me.CmdReset.TabIndex = 178
        Me.CmdReset.Text = "Reset Form"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 24)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Mpo No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LemonChiffon
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(391, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 187
        Me.Label3.Text = "Spilts#:"
        '
        'txtSplitNo
        '
        Me.txtSplitNo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtSplitNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSplitNo.Location = New System.Drawing.Point(466, 101)
        Me.txtSplitNo.Name = "txtSplitNo"
        Me.txtSplitNo.Size = New System.Drawing.Size(64, 26)
        Me.txtSplitNo.TabIndex = 188
        Me.txtSplitNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExec
        '
        Me.CmdExec.BackColor = System.Drawing.Color.LemonChiffon
        Me.CmdExec.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExec.Location = New System.Drawing.Point(596, 92)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(185, 45)
        Me.CmdExec.TabIndex = 189
        Me.CmdExec.Text = "Execute"
        Me.CmdExec.UseVisualStyleBackColor = False
        '
        'dgMPO
        '
        Me.dgMPO.AllowUserToAddRows = False
        Me.dgMPO.AllowUserToOrderColumns = True
        Me.dgMPO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMPO.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMPO.ColumnHeadersHeight = 35
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoNo, Me.MpoParent, Me.MpoChild, Me.MpoPartID, Me.MpoPartRev, Me.QtyActual, Me.QtyEngReleased, Me.QtyOrder, Me.MpoID, Me.OrderItemsID, Me.OrdDelivID, Me.MpoDate, Me.DeptID, Me.StartProdDate, Me.EndProdDate, Me.MpoNotes, Me.MpoTechNotes, Me.ChNewOrder, Me.ChWFM, Me.ChWFT, Me.MpoStatus, Me.MpoType, Me.MpoMatlWeight, Me.MpoPartType, Me.MpoLotNo, Me.MpoRMCostCDN, Me.MPORMValueUsedCDN, Me.MPOProcessingCost, Me.TotalDaysINMFG, Me.MpoPriority})
        Me.dgMPO.Cursor = System.Windows.Forms.Cursors.SizeAll
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgMPO.EnableHeadersVisualStyles = False
        Me.dgMPO.Location = New System.Drawing.Point(12, 171)
        Me.dgMPO.Name = "dgMPO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgMPO.RowHeadersWidth = 20
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgMPO.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgMPO.Size = New System.Drawing.Size(769, 300)
        Me.dgMPO.TabIndex = 190
        Me.dgMPO.Text = "DataGridView1"
        '
        'CmbMPO
        '
        Me.CmbMPO.DropDownHeight = 500
        Me.CmbMPO.DropDownWidth = 200
        Me.CmbMPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMPO.FormattingEnabled = True
        Me.CmbMPO.IntegralHeight = False
        Me.CmbMPO.Location = New System.Drawing.Point(111, 100)
        Me.CmbMPO.Name = "CmbMPO"
        Me.CmbMPO.Size = New System.Drawing.Size(125, 24)
        Me.CmbMPO.TabIndex = 191
        '
        'MpoNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.MpoNo.HeaderText = "Mpo No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.ReadOnly = True
        Me.MpoNo.Width = 80
        '
        'MpoParent
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoParent.DefaultCellStyle = DataGridViewCellStyle4
        Me.MpoParent.HeaderText = "Mpo Parent"
        Me.MpoParent.Name = "MpoParent"
        Me.MpoParent.ReadOnly = True
        Me.MpoParent.Width = 80
        '
        'MpoChild
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoChild.DefaultCellStyle = DataGridViewCellStyle5
        Me.MpoChild.HeaderText = "Mpo Child"
        Me.MpoChild.Name = "MpoChild"
        Me.MpoChild.ReadOnly = True
        Me.MpoChild.Width = 80
        '
        'MpoPartID
        '
        Me.MpoPartID.HeaderText = "Part Number"
        Me.MpoPartID.MinimumWidth = 2
        Me.MpoPartID.Name = "MpoPartID"
        Me.MpoPartID.ReadOnly = True
        Me.MpoPartID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MpoPartID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MpoPartID.Width = 160
        '
        'MpoPartRev
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoPartRev.DefaultCellStyle = DataGridViewCellStyle6
        Me.MpoPartRev.HeaderText = "Mpo Part Rev"
        Me.MpoPartRev.Name = "MpoPartRev"
        Me.MpoPartRev.ReadOnly = True
        Me.MpoPartRev.Width = 80
        '
        'QtyActual
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QtyActual.DefaultCellStyle = DataGridViewCellStyle7
        Me.QtyActual.HeaderText = "Actual Qty"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.ReadOnly = True
        Me.QtyActual.Width = 80
        '
        'QtyEngReleased
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LemonChiffon
        Me.QtyEngReleased.DefaultCellStyle = DataGridViewCellStyle8
        Me.QtyEngReleased.HeaderText = "Released Qty"
        Me.QtyEngReleased.Name = "QtyEngReleased"
        Me.QtyEngReleased.Width = 80
        '
        'QtyOrder
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LemonChiffon
        Me.QtyOrder.DefaultCellStyle = DataGridViewCellStyle9
        Me.QtyOrder.HeaderText = "Sales Qty"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.Width = 80
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
        'OrderItemsID
        '
        Me.OrderItemsID.HeaderText = "OrderItemsID"
        Me.OrderItemsID.MinimumWidth = 2
        Me.OrderItemsID.Name = "OrderItemsID"
        Me.OrderItemsID.ReadOnly = True
        Me.OrderItemsID.Visible = False
        Me.OrderItemsID.Width = 2
        '
        'OrdDelivID
        '
        Me.OrdDelivID.HeaderText = "OrdDelivID"
        Me.OrdDelivID.MinimumWidth = 2
        Me.OrdDelivID.Name = "OrdDelivID"
        Me.OrdDelivID.ReadOnly = True
        Me.OrdDelivID.Visible = False
        Me.OrdDelivID.Width = 2
        '
        'MpoDate
        '
        Me.MpoDate.HeaderText = "MpoDate"
        Me.MpoDate.MinimumWidth = 2
        Me.MpoDate.Name = "MpoDate"
        Me.MpoDate.ReadOnly = True
        Me.MpoDate.Visible = False
        Me.MpoDate.Width = 2
        '
        'DeptID
        '
        Me.DeptID.HeaderText = "DeptID"
        Me.DeptID.MinimumWidth = 2
        Me.DeptID.Name = "DeptID"
        Me.DeptID.ReadOnly = True
        Me.DeptID.Visible = False
        Me.DeptID.Width = 2
        '
        'StartProdDate
        '
        Me.StartProdDate.HeaderText = "StartProdDate"
        Me.StartProdDate.MinimumWidth = 2
        Me.StartProdDate.Name = "StartProdDate"
        Me.StartProdDate.ReadOnly = True
        Me.StartProdDate.Visible = False
        Me.StartProdDate.Width = 2
        '
        'EndProdDate
        '
        Me.EndProdDate.HeaderText = "EndProdDate"
        Me.EndProdDate.MinimumWidth = 2
        Me.EndProdDate.Name = "EndProdDate"
        Me.EndProdDate.ReadOnly = True
        Me.EndProdDate.Visible = False
        Me.EndProdDate.Width = 2
        '
        'MpoNotes
        '
        Me.MpoNotes.HeaderText = "MpoNotes"
        Me.MpoNotes.MinimumWidth = 2
        Me.MpoNotes.Name = "MpoNotes"
        Me.MpoNotes.ReadOnly = True
        Me.MpoNotes.Visible = False
        Me.MpoNotes.Width = 2
        '
        'MpoTechNotes
        '
        Me.MpoTechNotes.HeaderText = "MpoTechNotes"
        Me.MpoTechNotes.MinimumWidth = 2
        Me.MpoTechNotes.Name = "MpoTechNotes"
        Me.MpoTechNotes.ReadOnly = True
        Me.MpoTechNotes.Visible = False
        Me.MpoTechNotes.Width = 2
        '
        'ChNewOrder
        '
        Me.ChNewOrder.HeaderText = "ChNewOrder"
        Me.ChNewOrder.MinimumWidth = 2
        Me.ChNewOrder.Name = "ChNewOrder"
        Me.ChNewOrder.ReadOnly = True
        Me.ChNewOrder.Visible = False
        Me.ChNewOrder.Width = 2
        '
        'ChWFM
        '
        Me.ChWFM.HeaderText = "ChWFM"
        Me.ChWFM.MinimumWidth = 2
        Me.ChWFM.Name = "ChWFM"
        Me.ChWFM.ReadOnly = True
        Me.ChWFM.Visible = False
        Me.ChWFM.Width = 2
        '
        'ChWFT
        '
        Me.ChWFT.HeaderText = "ChWFT"
        Me.ChWFT.MinimumWidth = 2
        Me.ChWFT.Name = "ChWFT"
        Me.ChWFT.ReadOnly = True
        Me.ChWFT.Visible = False
        Me.ChWFT.Width = 2
        '
        'MpoStatus
        '
        Me.MpoStatus.HeaderText = "Mpo Status"
        Me.MpoStatus.MinimumWidth = 2
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.ReadOnly = True
        Me.MpoStatus.Visible = False
        Me.MpoStatus.Width = 2
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "MpoType"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.ReadOnly = True
        Me.MpoType.Visible = False
        '
        'MpoMatlWeight
        '
        Me.MpoMatlWeight.HeaderText = "MpoMatlWeight"
        Me.MpoMatlWeight.Name = "MpoMatlWeight"
        Me.MpoMatlWeight.ReadOnly = True
        Me.MpoMatlWeight.Visible = False
        '
        'MpoPartType
        '
        Me.MpoPartType.HeaderText = "MpoPartType"
        Me.MpoPartType.MinimumWidth = 2
        Me.MpoPartType.Name = "MpoPartType"
        Me.MpoPartType.Visible = False
        Me.MpoPartType.Width = 2
        '
        'MpoLotNo
        '
        Me.MpoLotNo.HeaderText = "MpoLotNo"
        Me.MpoLotNo.MinimumWidth = 2
        Me.MpoLotNo.Name = "MpoLotNo"
        Me.MpoLotNo.Visible = False
        Me.MpoLotNo.Width = 2
        '
        'MpoRMCostCDN
        '
        Me.MpoRMCostCDN.HeaderText = "MpoRMCostCDN"
        Me.MpoRMCostCDN.MinimumWidth = 2
        Me.MpoRMCostCDN.Name = "MpoRMCostCDN"
        Me.MpoRMCostCDN.Visible = False
        Me.MpoRMCostCDN.Width = 2
        '
        'MPORMValueUsedCDN
        '
        Me.MPORMValueUsedCDN.HeaderText = "MPORMValueUsedCDN"
        Me.MPORMValueUsedCDN.MinimumWidth = 2
        Me.MPORMValueUsedCDN.Name = "MPORMValueUsedCDN"
        Me.MPORMValueUsedCDN.Visible = False
        Me.MPORMValueUsedCDN.Width = 2
        '
        'MPOProcessingCost
        '
        Me.MPOProcessingCost.HeaderText = "MPOProcessingCost"
        Me.MPOProcessingCost.MinimumWidth = 2
        Me.MPOProcessingCost.Name = "MPOProcessingCost"
        Me.MPOProcessingCost.Visible = False
        Me.MPOProcessingCost.Width = 2
        '
        'TotalDaysINMFG
        '
        Me.TotalDaysINMFG.HeaderText = "TotalDaysINMFG"
        Me.TotalDaysINMFG.MinimumWidth = 2
        Me.TotalDaysINMFG.Name = "TotalDaysINMFG"
        Me.TotalDaysINMFG.Visible = False
        Me.TotalDaysINMFG.Width = 2
        '
        'MpoPriority
        '
        Me.MpoPriority.HeaderText = "MpoPriority"
        Me.MpoPriority.MinimumWidth = 2
        Me.MpoPriority.Name = "MpoPriority"
        Me.MpoPriority.Visible = False
        Me.MpoPriority.Width = 2
        '
        'frmEngMPOPlanedSplit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 483)
        Me.Controls.Add(Me.CmbMPO)
        Me.Controls.Add(Me.dgMPO)
        Me.Controls.Add(Me.CmdExec)
        Me.Controls.Add(Me.txtSplitNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PanTool)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEngMPOPlanedSplit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -  MPO Planned Split"
        Me.PanTool.ResumeLayout(False)
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanTool As System.Windows.Forms.Panel
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSplitNo As System.Windows.Forms.TextBox
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmbMPO As System.Windows.Forms.ComboBox
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoParent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoChild As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MpoPartRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyEngReleased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderItemsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDelivID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndProdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoTechNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChNewOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChWFM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChWFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoMatlWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPartType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoLotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoRMCostCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPORMValueUsedCDN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOProcessingCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDaysINMFG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoPriority As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
