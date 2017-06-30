<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccInterCoInvoices
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgMPO = New System.Windows.Forms.DataGridView()
        Me.LACData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PslipInterCoPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PslipNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvDevise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACDT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PslipCustPoContr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParInv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvTerms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwInvDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmbComp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCOBatch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.CmdFTP = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccDate = New System.Windows.Forms.TextBox()
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgMPO.ColumnHeadersHeight = 45
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LACData, Me.PslipInterCoPrefix, Me.PslipNo, Me.InvDate, Me.DelivDate, Me.IVAM, Me.InvDevise, Me.ACDT, Me.PslipCustPoContr, Me.ParInv, Me.InvTerms, Me.SwInvDate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgMPO.Location = New System.Drawing.Point(12, 82)
        Me.dgMPO.Name = "dgMPO"
        Me.dgMPO.ReadOnly = True
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgMPO.RowHeadersWidth = 25
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.Size = New System.Drawing.Size(1148, 808)
        Me.dgMPO.TabIndex = 55
        Me.dgMPO.Text = "DataGridView1"
        '
        'LACData
        '
        DataGridViewCellStyle3.Format = "##"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.LACData.DefaultCellStyle = DataGridViewCellStyle3
        Me.LACData.Frozen = True
        Me.LACData.HeaderText = "LAC Data"
        Me.LACData.Name = "LACData"
        Me.LACData.ReadOnly = True
        Me.LACData.Width = 1100
        '
        'PslipInterCoPrefix
        '
        Me.PslipInterCoPrefix.HeaderText = "DIVI"
        Me.PslipInterCoPrefix.MinimumWidth = 2
        Me.PslipInterCoPrefix.Name = "PslipInterCoPrefix"
        Me.PslipInterCoPrefix.ReadOnly = True
        Me.PslipInterCoPrefix.Visible = False
        Me.PslipInterCoPrefix.Width = 2
        '
        'PslipNo
        '
        Me.PslipNo.HeaderText = "SINO"
        Me.PslipNo.MinimumWidth = 2
        Me.PslipNo.Name = "PslipNo"
        Me.PslipNo.ReadOnly = True
        Me.PslipNo.Visible = False
        Me.PslipNo.Width = 2
        '
        'InvDate
        '
        Me.InvDate.HeaderText = "IVDT"
        Me.InvDate.MinimumWidth = 2
        Me.InvDate.Name = "InvDate"
        Me.InvDate.ReadOnly = True
        Me.InvDate.Visible = False
        Me.InvDate.Width = 2
        '
        'DelivDate
        '
        Me.DelivDate.HeaderText = "DUDT"
        Me.DelivDate.MinimumWidth = 2
        Me.DelivDate.Name = "DelivDate"
        Me.DelivDate.ReadOnly = True
        Me.DelivDate.Visible = False
        Me.DelivDate.Width = 2
        '
        'IVAM
        '
        Me.IVAM.HeaderText = "IVAM"
        Me.IVAM.MinimumWidth = 2
        Me.IVAM.Name = "IVAM"
        Me.IVAM.ReadOnly = True
        Me.IVAM.Visible = False
        Me.IVAM.Width = 2
        '
        'InvDevise
        '
        Me.InvDevise.HeaderText = "CUCD"
        Me.InvDevise.MinimumWidth = 2
        Me.InvDevise.Name = "InvDevise"
        Me.InvDevise.ReadOnly = True
        Me.InvDevise.Visible = False
        Me.InvDevise.Width = 2
        '
        'ACDT
        '
        Me.ACDT.HeaderText = "ACDT"
        Me.ACDT.MinimumWidth = 2
        Me.ACDT.Name = "ACDT"
        Me.ACDT.ReadOnly = True
        Me.ACDT.Visible = False
        Me.ACDT.Width = 2
        '
        'PslipCustPoContr
        '
        Me.PslipCustPoContr.HeaderText = "PUNO"
        Me.PslipCustPoContr.MinimumWidth = 2
        Me.PslipCustPoContr.Name = "PslipCustPoContr"
        Me.PslipCustPoContr.ReadOnly = True
        Me.PslipCustPoContr.Visible = False
        Me.PslipCustPoContr.Width = 2
        '
        'ParInv
        '
        Me.ParInv.HeaderText = "ParInv"
        Me.ParInv.MinimumWidth = 2
        Me.ParInv.Name = "ParInv"
        Me.ParInv.ReadOnly = True
        Me.ParInv.Visible = False
        Me.ParInv.Width = 2
        '
        'InvTerms
        '
        Me.InvTerms.HeaderText = "InvTerms"
        Me.InvTerms.MinimumWidth = 2
        Me.InvTerms.Name = "InvTerms"
        Me.InvTerms.ReadOnly = True
        Me.InvTerms.Visible = False
        Me.InvTerms.Width = 2
        '
        'SwInvDate
        '
        Me.SwInvDate.HeaderText = "SwInvDate"
        Me.SwInvDate.MinimumWidth = 2
        Me.SwInvDate.Name = "SwInvDate"
        Me.SwInvDate.ReadOnly = True
        Me.SwInvDate.Visible = False
        Me.SwInvDate.Width = 2
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(544, 27)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 64
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(725, 27)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 69
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmbComp
        '
        Me.CmbComp.FormattingEnabled = True
        Me.CmbComp.Location = New System.Drawing.Point(80, 29)
        Me.CmbComp.Name = "CmbComp"
        Me.CmbComp.Size = New System.Drawing.Size(121, 21)
        Me.CmbComp.Sorted = True
        Me.CmbComp.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Companies:"
        '
        'txtCOBatch
        '
        Me.txtCOBatch.AcceptsReturn = True
        Me.txtCOBatch.Location = New System.Drawing.Point(351, 29)
        Me.txtCOBatch.Name = "txtCOBatch"
        Me.txtCOBatch.ReadOnly = True
        Me.txtCOBatch.Size = New System.Drawing.Size(100, 20)
        Me.txtCOBatch.TabIndex = 72
        Me.txtCOBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Batch Counter (RNNO):"
        '
        'CmdExport
        '
        Me.CmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExport.Location = New System.Drawing.Point(870, 14)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(112, 44)
        Me.CmdExport.TabIndex = 74
        Me.CmdExport.Text = "EXPORT "
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'CmdFTP
        '
        Me.CmdFTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFTP.Location = New System.Drawing.Point(1048, 4)
        Me.CmdFTP.Name = "CmdFTP"
        Me.CmdFTP.Size = New System.Drawing.Size(112, 64)
        Me.CmdFTP.TabIndex = 75
        Me.CmdFTP.Text = "FTP Upload"
        Me.CmdFTP.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(223, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Accounting Date:"
        '
        'txtAccDate
        '
        Me.txtAccDate.AcceptsReturn = True
        Me.txtAccDate.BackColor = System.Drawing.Color.Orange
        Me.txtAccDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccDate.Location = New System.Drawing.Point(351, 53)
        Me.txtAccDate.Name = "txtAccDate"
        Me.txtAccDate.Size = New System.Drawing.Size(100, 20)
        Me.txtAccDate.TabIndex = 76
        Me.txtAccDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmAccInterCoInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 902)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAccDate)
        Me.Controls.Add(Me.CmdFTP)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCOBatch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbComp)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.dgMPO)
        Me.Name = "frmAccInterCoInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAccInterCoInvoices"
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmbComp As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCOBatch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents CmdFTP As System.Windows.Forms.Button
    Friend WithEvents LACData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PslipInterCoPrefix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PslipNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACDT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PslipCustPoContr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParInv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvTerms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwInvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccDate As System.Windows.Forms.TextBox
End Class
