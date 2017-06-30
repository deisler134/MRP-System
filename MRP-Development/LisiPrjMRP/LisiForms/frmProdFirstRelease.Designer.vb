<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdFirstRelease
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDateFrom = New System.Windows.Forms.TextBox()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        Me.dgMPO = New System.Windows.Forms.DataGridView()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptRoot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoReleasedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MpoStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Date To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(140, 37)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(121, 20)
        Me.txtDateTo.TabIndex = 62
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(140, 11)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtDateFrom.TabIndex = 60
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(747, 29)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 69
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(423, 29)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 68
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1044, 21)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 70
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMPO.ColumnHeadersHeight = 35
        Me.dgMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumber, Me.PartDescCode, Me.PartName, Me.MpoNo, Me.QtyActual, Me.DeptRoot, Me.MpoDate, Me.MpoReleasedNo, Me.MpoStatus})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMPO.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMPO.Location = New System.Drawing.Point(14, 81)
        Me.dgMPO.Name = "dgMPO"
        Me.dgMPO.ReadOnly = True
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgMPO.RowHeadersWidth = 25
        Me.dgMPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgMPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMPO.RowTemplate.Height = 18
        Me.dgMPO.Size = New System.Drawing.Size(1097, 599)
        Me.dgMPO.TabIndex = 71
        Me.dgMPO.Text = "DataGridView1"
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "PartNumber"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 120
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "PartDescCode"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.ReadOnly = True
        Me.PartDescCode.Width = 120
        '
        'PartName
        '
        Me.PartName.HeaderText = "PartName"
        Me.PartName.Name = "PartName"
        Me.PartName.ReadOnly = True
        Me.PartName.Width = 160
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "MpoNo"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.ReadOnly = True
        '
        'QtyActual
        '
        Me.QtyActual.HeaderText = "QtyActual"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.ReadOnly = True
        '
        'DeptRoot
        '
        Me.DeptRoot.HeaderText = "DeptRoot"
        Me.DeptRoot.Name = "DeptRoot"
        Me.DeptRoot.ReadOnly = True
        Me.DeptRoot.Width = 160
        '
        'MpoDate
        '
        Me.MpoDate.HeaderText = "MpoDate"
        Me.MpoDate.Name = "MpoDate"
        Me.MpoDate.ReadOnly = True
        '
        'MpoReleasedNo
        '
        Me.MpoReleasedNo.HeaderText = "MpoReleasedNo"
        Me.MpoReleasedNo.Name = "MpoReleasedNo"
        Me.MpoReleasedNo.ReadOnly = True
        '
        'MpoStatus
        '
        Me.MpoStatus.HeaderText = "MpoStatus"
        Me.MpoStatus.Name = "MpoStatus"
        Me.MpoStatus.ReadOnly = True
        '
        'frmProdFirstRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 692)
        Me.Controls.Add(Me.dgMPO)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Name = "frmProdFirstRelease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProdFirstRelease"
        CType(Me.dgMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents dgMPO As System.Windows.Forms.DataGridView
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptRoot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoReleasedNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
