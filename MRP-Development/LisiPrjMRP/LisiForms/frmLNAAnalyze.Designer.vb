<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLNAAnalyze
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgProd = New System.Windows.Forms.DataGridView
        Me.CmdLocation = New System.Windows.Forms.Button
        Me.txtFileLocation = New System.Windows.Forms.TextBox
        Me.CmdLoad = New System.Windows.Forms.Button
        Me.CmdExport = New System.Windows.Forms.Button
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwRel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwPriority = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwMPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwDept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwDelivery = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwMPODelivery = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwInvDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToDeleteRows = False
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
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumber, Me.PartID, Me.OrdNumber, Me.OrdDate, Me.SwRel, Me.SwPriority, Me.SwMPO, Me.SwDept, Me.SwDelivery, Me.SwMPODelivery, Me.SwInvDate})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgProd.Location = New System.Drawing.Point(23, 98)
        Me.dgProd.Name = "dgProd"
        Me.dgProd.ReadOnly = True
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgProd.RowHeadersWidth = 25
        Me.dgProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgProd.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgProd.RowTemplate.Height = 18
        Me.dgProd.Size = New System.Drawing.Size(1170, 763)
        Me.dgProd.TabIndex = 48
        Me.dgProd.Text = "DataGridView1"
        '
        'CmdLocation
        '
        Me.CmdLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLocation.Location = New System.Drawing.Point(23, 23)
        Me.CmdLocation.Name = "CmdLocation"
        Me.CmdLocation.Size = New System.Drawing.Size(75, 51)
        Me.CmdLocation.TabIndex = 49
        Me.CmdLocation.Text = "File Location"
        Me.CmdLocation.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Location = New System.Drawing.Point(128, 39)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(435, 20)
        Me.txtFileLocation.TabIndex = 50
        '
        'CmdLoad
        '
        Me.CmdLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLoad.Location = New System.Drawing.Point(673, 23)
        Me.CmdLoad.Name = "CmdLoad"
        Me.CmdLoad.Size = New System.Drawing.Size(110, 51)
        Me.CmdLoad.TabIndex = 51
        Me.CmdLoad.Text = "Load Data"
        Me.CmdLoad.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1101, 23)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 68
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'PartNumber
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.PartNumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 150
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.MinimumWidth = 2
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        Me.PartID.Visible = False
        Me.PartID.Width = 2
        '
        'OrdNumber
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.OrdNumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.OrdNumber.HeaderText = "Order Number (Active)"
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.ReadOnly = True
        '
        'OrdDate
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.NullValue = Nothing
        Me.OrdDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.OrdDate.HeaderText = "Order Date"
        Me.OrdDate.Name = "OrdDate"
        Me.OrdDate.ReadOnly = True
        '
        'SwRel
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SwRel.DefaultCellStyle = DataGridViewCellStyle6
        Me.SwRel.HeaderText = "# Release to Prod"
        Me.SwRel.Name = "SwRel"
        Me.SwRel.ReadOnly = True
        Me.SwRel.Width = 70
        '
        'SwPriority
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SwPriority.DefaultCellStyle = DataGridViewCellStyle7
        Me.SwPriority.HeaderText = "MPO Priority"
        Me.SwPriority.Name = "SwPriority"
        Me.SwPriority.ReadOnly = True
        Me.SwPriority.Width = 70
        '
        'SwMPO
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SwMPO.DefaultCellStyle = DataGridViewCellStyle8
        Me.SwMPO.HeaderText = "MPO No."
        Me.SwMPO.Name = "SwMPO"
        Me.SwMPO.ReadOnly = True
        Me.SwMPO.Width = 80
        '
        'SwDept
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SwDept.DefaultCellStyle = DataGridViewCellStyle9
        Me.SwDept.HeaderText = "MPO Dept."
        Me.SwDept.Name = "SwDept"
        Me.SwDept.ReadOnly = True
        Me.SwDept.Width = 250
        '
        'SwDelivery
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.MediumAquamarine
        Me.SwDelivery.DefaultCellStyle = DataGridViewCellStyle10
        Me.SwDelivery.HeaderText = "Delivery Date (Based on PO Date)"
        Me.SwDelivery.Name = "SwDelivery"
        Me.SwDelivery.ReadOnly = True
        '
        'SwMPODelivery
        '
        Me.SwMPODelivery.HeaderText = "MPO Delivery Date"
        Me.SwMPODelivery.Name = "SwMPODelivery"
        Me.SwMPODelivery.ReadOnly = True
        '
        'SwInvDate
        '
        Me.SwInvDate.HeaderText = "Latest Inv. Date"
        Me.SwInvDate.Name = "SwInvDate"
        Me.SwInvDate.ReadOnly = True
        '
        'frmLNAAnalyze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1218, 873)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdLoad)
        Me.Controls.Add(Me.txtFileLocation)
        Me.Controls.Add(Me.CmdLocation)
        Me.Controls.Add(Me.dgProd)
        Me.Name = "frmLNAAnalyze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  LNA  Excel Imported Data and Extracted Data from LAC MR" & _
            "P System"
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents CmdLocation As System.Windows.Forms.Button
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents CmdLoad As System.Windows.Forms.Button
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwPriority As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDelivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwMPODelivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwInvDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
