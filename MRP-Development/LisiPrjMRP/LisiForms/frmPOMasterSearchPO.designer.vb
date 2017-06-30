<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPOMasterSearchPO
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgSearch = New System.Windows.Forms.DataGridView()
        Me.SelPO = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSW = New System.Windows.Forms.TextBox()
        Me.CmdSearchPO = New System.Windows.Forms.Button()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.CmbPOSupp = New System.Windows.Forms.ComboBox()
        Me.CmdListAll = New System.Windows.Forms.Button()
        Me.CmdSearchSupp = New System.Windows.Forms.Button()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        Me.dgSearch.AllowUserToResizeColumns = False
        Me.dgSearch.AllowUserToResizeRows = False
        Me.dgSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgSearch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSearch.ColumnHeadersHeight = 30
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelPO, Me.PONo, Me.PODate, Me.POStatus, Me.SuppName, Me.ProdDescr, Me.PoType, Me.EmpName})
        Me.dgSearch.Location = New System.Drawing.Point(9, 119)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.ReadOnly = True
        Me.dgSearch.RowHeadersWidth = 25
        Me.dgSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSearch.Size = New System.Drawing.Size(1217, 750)
        Me.dgSearch.TabIndex = 0
        Me.dgSearch.Text = "DataGridView1"
        '
        'SelPO
        '
        Me.SelPO.Frozen = True
        Me.SelPO.HeaderText = ""
        Me.SelPO.Name = "SelPO"
        Me.SelPO.ReadOnly = True
        Me.SelPO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SelPO.Text = "Select"
        Me.SelPO.UseColumnTextForButtonValue = True
        Me.SelPO.Width = 60
        '
        'PONo
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PONo.DefaultCellStyle = DataGridViewCellStyle4
        Me.PONo.Frozen = True
        Me.PONo.HeaderText = "PO No."
        Me.PONo.Name = "PONo"
        Me.PONo.ReadOnly = True
        Me.PONo.Width = 60
        '
        'PODate
        '
        Me.PODate.Frozen = True
        Me.PODate.HeaderText = "PO Date"
        Me.PODate.Name = "PODate"
        Me.PODate.ReadOnly = True
        Me.PODate.Width = 80
        '
        'POStatus
        '
        Me.POStatus.Frozen = True
        Me.POStatus.HeaderText = "PO Status"
        Me.POStatus.Name = "POStatus"
        Me.POStatus.ReadOnly = True
        Me.POStatus.Width = 60
        '
        'SuppName
        '
        Me.SuppName.HeaderText = "Supplier Name"
        Me.SuppName.Name = "SuppName"
        Me.SuppName.ReadOnly = True
        Me.SuppName.Width = 200
        '
        'ProdDescr
        '
        Me.ProdDescr.HeaderText = "Line Description"
        Me.ProdDescr.Name = "ProdDescr"
        Me.ProdDescr.ReadOnly = True
        Me.ProdDescr.Width = 400
        '
        'PoType
        '
        Me.PoType.HeaderText = "PO Type"
        Me.PoType.Name = "PoType"
        Me.PoType.ReadOnly = True
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "Buyer Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 200
        '
        'txtSW
        '
        Me.txtSW.Location = New System.Drawing.Point(873, 12)
        Me.txtSW.Name = "txtSW"
        Me.txtSW.Size = New System.Drawing.Size(63, 20)
        Me.txtSW.TabIndex = 1
        Me.txtSW.Visible = False
        '
        'CmdSearchPO
        '
        Me.CmdSearchPO.BackColor = System.Drawing.Color.LightGreen
        Me.CmdSearchPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearchPO.Location = New System.Drawing.Point(42, 12)
        Me.CmdSearchPO.Name = "CmdSearchPO"
        Me.CmdSearchPO.Size = New System.Drawing.Size(257, 32)
        Me.CmdSearchPO.TabIndex = 2
        Me.CmdSearchPO.Text = "SEARCH By PO Number:"
        Me.CmdSearchPO.UseVisualStyleBackColor = False
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(323, 15)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(391, 26)
        Me.txtPONo.TabIndex = 3
        Me.txtPONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbPOSupp
        '
        Me.CmbPOSupp.DropDownHeight = 500
        Me.CmbPOSupp.DropDownWidth = 300
        Me.CmbPOSupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPOSupp.FormattingEnabled = True
        Me.CmbPOSupp.IntegralHeight = False
        Me.CmbPOSupp.Location = New System.Drawing.Point(323, 67)
        Me.CmbPOSupp.Name = "CmbPOSupp"
        Me.CmbPOSupp.Size = New System.Drawing.Size(391, 28)
        Me.CmbPOSupp.TabIndex = 5
        '
        'CmdListAll
        '
        Me.CmdListAll.BackColor = System.Drawing.Color.Transparent
        Me.CmdListAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdListAll.Location = New System.Drawing.Point(1043, 39)
        Me.CmdListAll.Name = "CmdListAll"
        Me.CmdListAll.Size = New System.Drawing.Size(183, 32)
        Me.CmdListAll.TabIndex = 9
        Me.CmdListAll.Text = "LIST All POs"
        Me.CmdListAll.UseVisualStyleBackColor = False
        '
        'CmdSearchSupp
        '
        Me.CmdSearchSupp.BackColor = System.Drawing.Color.LightGreen
        Me.CmdSearchSupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearchSupp.Location = New System.Drawing.Point(42, 63)
        Me.CmdSearchSupp.Name = "CmdSearchSupp"
        Me.CmdSearchSupp.Size = New System.Drawing.Size(257, 32)
        Me.CmdSearchSupp.TabIndex = 10
        Me.CmdSearchSupp.Text = "SEARCH By Supplier:"
        Me.CmdSearchSupp.UseVisualStyleBackColor = False
        '
        'frmPOMasterSearchPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 881)
        Me.Controls.Add(Me.CmdSearchSupp)
        Me.Controls.Add(Me.CmdListAll)
        Me.Controls.Add(Me.CmbPOSupp)
        Me.Controls.Add(Me.txtPONo)
        Me.Controls.Add(Me.CmdSearchPO)
        Me.Controls.Add(Me.txtSW)
        Me.Controls.Add(Me.dgSearch)
        Me.Name = "frmPOMasterSearchPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Search Purchase Orders"
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents txtSW As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelPO As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents PONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSearchPO As System.Windows.Forms.Button
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents CmbPOSupp As System.Windows.Forms.ComboBox
    Friend WithEvents CmdListAll As System.Windows.Forms.Button
    Friend WithEvents CmdSearchSupp As System.Windows.Forms.Button
End Class
