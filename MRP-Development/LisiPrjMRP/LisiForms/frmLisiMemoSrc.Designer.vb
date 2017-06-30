<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLisiMemoSrc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgSearch = New System.Windows.Forms.DataGridView()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.MemoId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InternalSource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.MemoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPOType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApprSystem = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalQuality = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalMfg = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ApprHSE = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalHelth = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalSafety = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalEnvironment = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InternalTraining = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MemoNoPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoIR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoRMA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwInternal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoQtyRwk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoQtyScrap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptRejectedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwMPORevCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwHourRwk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SNCRNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeeMemoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedUser = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgSearch,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = false
        Me.dgSearch.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearch.ColumnHeadersHeight = 50
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MemoId, Me.InternalSource, Me.Column1, Me.MemoNo, Me.MemoStatus, Me.MPONO, Me.MpoStatus, Me.MPOType, Me.ApprSystem, Me.InternalQuality, Me.InternalMfg, Me.ApprHSE, Me.InternalHelth, Me.InternalSafety, Me.InternalEnvironment, Me.InternalTraining, Me.MemoNoPrefix, Me.SwDescr, Me.MemoIR, Me.MemoRMA, Me.SwInternal, Me.SuppName, Me.CustomerName, Me.MpoQty, Me.MemoQtyRwk, Me.MemoQtyScrap, Me.DeptRejectedQty, Me.SwMPORevCost, Me.SwHourRwk, Me.NCRNo, Me.SNCRNo, Me.SeeMemoNo, Me.CreatedUser, Me.CreatedDate, Me.PartNumber})
        Me.dgSearch.Location = New System.Drawing.Point(12, 62)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.ReadOnly = true
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgSearch.RowHeadersWidth = 21
        Me.dgSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSearch.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dgSearch.Size = New System.Drawing.Size(1721, 812)
        Me.dgSearch.TabIndex = 0
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(225, 12)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(107, 36)
        Me.CmdExport.TabIndex = 68
        Me.CmdExport.UseVisualStyleBackColor = true
        '
        'MemoId
        '
        Me.MemoId.HeaderText = "MemoId"
        Me.MemoId.MinimumWidth = 2
        Me.MemoId.Name = "MemoId"
        Me.MemoId.ReadOnly = true
        Me.MemoId.Visible = false
        Me.MemoId.Width = 2
        '
        'InternalSource
        '
        Me.InternalSource.HeaderText = "InternalSource"
        Me.InternalSource.MinimumWidth = 2
        Me.InternalSource.Name = "InternalSource"
        Me.InternalSource.ReadOnly = true
        Me.InternalSource.Visible = false
        Me.InternalSource.Width = 2
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Select"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = true
        Me.Column1.Text = "<<---"
        Me.Column1.UseColumnTextForButtonValue = true
        Me.Column1.Width = 60
        '
        'MemoNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleTurquoise
        Me.MemoNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.MemoNo.HeaderText = "Memo No"
        Me.MemoNo.Name = "MemoNo"
        Me.MemoNo.ReadOnly = true
        Me.MemoNo.Width = 55
        '
        'MemoStatus
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise
        Me.MemoStatus.DefaultCellStyle = DataGridViewCellStyle4
        Me.MemoStatus.HeaderText = "Memo Status"
        Me.MemoStatus.Name = "MemoStatus"
        Me.MemoStatus.ReadOnly = true
        Me.MemoStatus.Width = 55
        '
        'MPONO
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon
        Me.MPONO.DefaultCellStyle = DataGridViewCellStyle5
        Me.MPONO.HeaderText = "MPO No"
        Me.MPONO.Name = "MPONO"
        Me.MPONO.ReadOnly = true
        Me.MPONO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MPONO.Width = 60
        '
        'MpoStatus
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon
        Me.MpoStatus.DefaultCellStyle = DataGridViewCellStyle6
        Me.MpoStatus.HeaderText = "MPO Status"
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.ReadOnly = true
        Me.MpoStatus.Width = 60
        '
        'MPOType
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon
        Me.MPOType.DefaultCellStyle = DataGridViewCellStyle7
        Me.MPOType.HeaderText = "MPO Type"
        Me.MPOType.Name = "MPOType"
        Me.MPOType.ReadOnly = true
        Me.MPOType.Width = 55
        '
        'ApprSystem
        '
        Me.ApprSystem.HeaderText = "System"
        Me.ApprSystem.Name = "ApprSystem"
        Me.ApprSystem.ReadOnly = true
        Me.ApprSystem.Width = 50
        '
        'InternalQuality
        '
        Me.InternalQuality.HeaderText = "Final"
        Me.InternalQuality.Name = "InternalQuality"
        Me.InternalQuality.ReadOnly = true
        Me.InternalQuality.Width = 50
        '
        'InternalMfg
        '
        Me.InternalMfg.HeaderText = "InProcess"
        Me.InternalMfg.Name = "InternalMfg"
        Me.InternalMfg.ReadOnly = true
        Me.InternalMfg.Width = 50
        '
        'ApprHSE
        '
        Me.ApprHSE.HeaderText = "HSE"
        Me.ApprHSE.Name = "ApprHSE"
        Me.ApprHSE.ReadOnly = true
        Me.ApprHSE.Width = 50
        '
        'InternalHelth
        '
        Me.InternalHelth.HeaderText = "Health"
        Me.InternalHelth.Name = "InternalHelth"
        Me.InternalHelth.ReadOnly = true
        Me.InternalHelth.Width = 50
        '
        'InternalSafety
        '
        Me.InternalSafety.HeaderText = "Safety"
        Me.InternalSafety.Name = "InternalSafety"
        Me.InternalSafety.ReadOnly = true
        Me.InternalSafety.Width = 50
        '
        'InternalEnvironment
        '
        Me.InternalEnvironment.HeaderText = "Environment"
        Me.InternalEnvironment.Name = "InternalEnvironment"
        Me.InternalEnvironment.ReadOnly = true
        Me.InternalEnvironment.Width = 60
        '
        'InternalTraining
        '
        Me.InternalTraining.HeaderText = "Training"
        Me.InternalTraining.Name = "InternalTraining"
        Me.InternalTraining.ReadOnly = true
        Me.InternalTraining.Width = 60
        '
        'MemoNoPrefix
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoNoPrefix.DefaultCellStyle = DataGridViewCellStyle8
        Me.MemoNoPrefix.HeaderText = "Memo Deparment"
        Me.MemoNoPrefix.Name = "MemoNoPrefix"
        Me.MemoNoPrefix.ReadOnly = true
        Me.MemoNoPrefix.Width = 60
        '
        'SwDescr
        '
        Me.SwDescr.HeaderText = "Requirements"
        Me.SwDescr.Name = "SwDescr"
        Me.SwDescr.ReadOnly = true
        '
        'MemoIR
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoIR.DefaultCellStyle = DataGridViewCellStyle9
        Me.MemoIR.HeaderText = "IR No."
        Me.MemoIR.Name = "MemoIR"
        Me.MemoIR.ReadOnly = true
        Me.MemoIR.Width = 55
        '
        'MemoRMA
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoRMA.DefaultCellStyle = DataGridViewCellStyle10
        Me.MemoRMA.HeaderText = "RMA No."
        Me.MemoRMA.Name = "MemoRMA"
        Me.MemoRMA.ReadOnly = true
        Me.MemoRMA.Width = 55
        '
        'SwInternal
        '
        Me.SwInternal.HeaderText = "Lisi Memo Internal"
        Me.SwInternal.Name = "SwInternal"
        Me.SwInternal.ReadOnly = true
        Me.SwInternal.Width = 60
        '
        'SuppName
        '
        Me.SuppName.HeaderText = "Supplier Memo"
        Me.SuppName.Name = "SuppName"
        Me.SuppName.ReadOnly = true
        Me.SuppName.Width = 60
        '
        'CustomerName
        '
        Me.CustomerName.HeaderText = "Customer Memo"
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.ReadOnly = true
        Me.CustomerName.Width = 60
        '
        'MpoQty
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MpoQty.DefaultCellStyle = DataGridViewCellStyle11
        Me.MpoQty.HeaderText = "MEMO Mpo Qty"
        Me.MpoQty.Name = "MpoQty"
        Me.MpoQty.ReadOnly = true
        Me.MpoQty.Width = 50
        '
        'MemoQtyRwk
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoQtyRwk.DefaultCellStyle = DataGridViewCellStyle12
        Me.MemoQtyRwk.HeaderText = "Memo Qty Rwk"
        Me.MemoQtyRwk.Name = "MemoQtyRwk"
        Me.MemoQtyRwk.ReadOnly = true
        Me.MemoQtyRwk.Width = 50
        '
        'MemoQtyScrap
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MemoQtyScrap.DefaultCellStyle = DataGridViewCellStyle13
        Me.MemoQtyScrap.HeaderText = "Memo Qty Scrap"
        Me.MemoQtyScrap.Name = "MemoQtyScrap"
        Me.MemoQtyScrap.ReadOnly = true
        Me.MemoQtyScrap.Width = 50
        '
        'DeptRejectedQty
        '
        Me.DeptRejectedQty.HeaderText = "Dept Qty Rej"
        Me.DeptRejectedQty.Name = "DeptRejectedQty"
        Me.DeptRejectedQty.ReadOnly = true
        Me.DeptRejectedQty.Width = 60
        '
        'SwMPORevCost
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.SwMPORevCost.DefaultCellStyle = DataGridViewCellStyle14
        Me.SwMPORevCost.HeaderText = "MPO Rev. Cost"
        Me.SwMPORevCost.Name = "SwMPORevCost"
        Me.SwMPORevCost.ReadOnly = true
        Me.SwMPORevCost.Width = 60
        '
        'SwHourRwk
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.SwHourRwk.DefaultCellStyle = DataGridViewCellStyle15
        Me.SwHourRwk.HeaderText = "Total Rwk Hours"
        Me.SwHourRwk.Name = "SwHourRwk"
        Me.SwHourRwk.ReadOnly = true
        Me.SwHourRwk.Width = 50
        '
        'NCRNo
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NCRNo.DefaultCellStyle = DataGridViewCellStyle16
        Me.NCRNo.HeaderText = "See NCR"
        Me.NCRNo.Name = "NCRNo"
        Me.NCRNo.ReadOnly = true
        Me.NCRNo.Width = 50
        '
        'SNCRNo
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SNCRNo.DefaultCellStyle = DataGridViewCellStyle17
        Me.SNCRNo.HeaderText = "See SNCR No"
        Me.SNCRNo.Name = "SNCRNo"
        Me.SNCRNo.ReadOnly = true
        Me.SNCRNo.Width = 50
        '
        'SeeMemoNo
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SeeMemoNo.DefaultCellStyle = DataGridViewCellStyle18
        Me.SeeMemoNo.HeaderText = "See Memo No"
        Me.SeeMemoNo.Name = "SeeMemoNo"
        Me.SeeMemoNo.ReadOnly = true
        Me.SeeMemoNo.Width = 50
        '
        'CreatedUser
        '
        Me.CreatedUser.HeaderText = "Created By"
        Me.CreatedUser.Name = "CreatedUser"
        Me.CreatedUser.ReadOnly = true
        Me.CreatedUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CreatedUser.Width = 70
        '
        'CreatedDate
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CreatedDate.DefaultCellStyle = DataGridViewCellStyle19
        Me.CreatedDate.HeaderText = "Created Date"
        Me.CreatedDate.Name = "CreatedDate"
        Me.CreatedDate.ReadOnly = true
        Me.CreatedDate.Width = 60
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = true
        Me.PartNumber.Width = 80
        '
        'frmLisiMemoSrc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1745, 886)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.dgSearch)
        Me.Name = "frmLisiMemoSrc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Select MEMO Number"
        CType(Me.dgSearch,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents MemoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InternalSource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents MemoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApprSystem As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalQuality As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalMfg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ApprHSE As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalHelth As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalSafety As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalEnvironment As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InternalTraining As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MemoNoPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoIR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoRMA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwInternal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoQtyRwk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemoQtyScrap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptRejectedQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMPORevCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwHourRwk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NCRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SNCRNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeeMemoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedUser As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CreatedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
