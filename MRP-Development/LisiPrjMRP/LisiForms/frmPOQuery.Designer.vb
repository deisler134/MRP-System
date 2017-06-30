<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOQuery
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbSupplier = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbBuyer = New System.Windows.Forms.ComboBox()
        Me.dgPO = New System.Windows.Forms.DataGridView()
        Me.PODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuppName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PORMSPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DolarSign = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONotesItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompteDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasterPODueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        CType(Me.dgPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Date To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(209, 46)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(109, 20)
        Me.txtDateTo.TabIndex = 57
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(80, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(209, 17)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(109, 20)
        Me.txtDateFrom.TabIndex = 55
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 39)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "PO Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSupplier
        '
        Me.CmbSupplier.DropDownWidth = 287
        Me.CmbSupplier.FormattingEnabled = True
        Me.CmbSupplier.Location = New System.Drawing.Point(454, 28)
        Me.CmbSupplier.MaxDropDownItems = 40
        Me.CmbSupplier.Name = "CmbSupplier"
        Me.CmbSupplier.Size = New System.Drawing.Size(234, 21)
        Me.CmbSupplier.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(364, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 39)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "PO Supplier:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(757, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 39)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "PO Buyer:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbBuyer
        '
        Me.CmbBuyer.DropDownHeight = 300
        Me.CmbBuyer.DropDownWidth = 200
        Me.CmbBuyer.FormattingEnabled = True
        Me.CmbBuyer.IntegralHeight = False
        Me.CmbBuyer.Location = New System.Drawing.Point(847, 28)
        Me.CmbBuyer.Name = "CmbBuyer"
        Me.CmbBuyer.Size = New System.Drawing.Size(234, 21)
        Me.CmbBuyer.TabIndex = 82
        '
        'dgPO
        '
        Me.dgPO.AllowUserToAddRows = False
        Me.dgPO.AllowUserToDeleteRows = False
        Me.dgPO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgPO.ColumnHeadersHeight = 45
        Me.dgPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PODate, Me.PONo, Me.POType, Me.EmpName, Me.SuppName, Me.POItem, Me.ProdDescr, Me.PONotes, Me.POQty, Me.POPrice, Me.PORMSPrice, Me.POUM, Me.DolarSign, Me.PONotesItem, Me.CompteDescr, Me.POStatus, Me.MasterPODueDate, Me.Rate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPO.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgPO.Location = New System.Drawing.Point(12, 91)
        Me.dgPO.Name = "dgPO"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgPO.RowHeadersWidth = 25
        Me.dgPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.RowTemplate.Height = 18
        Me.dgPO.Size = New System.Drawing.Size(1591, 750)
        Me.dgPO.TabIndex = 84
        Me.dgPO.Text = "DataGridView1"
        '
        'PODate
        '
        Me.PODate.HeaderText = "PO Date"
        Me.PODate.Name = "PODate"
        Me.PODate.Width = 70
        '
        'PONo
        '
        Me.PONo.HeaderText = "PO No"
        Me.PONo.Name = "PONo"
        Me.PONo.Width = 80
        '
        'POType
        '
        Me.POType.HeaderText = "PO Type"
        Me.POType.Name = "POType"
        Me.POType.Width = 70
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'SuppName
        '
        Me.SuppName.HeaderText = "Supplier Name"
        Me.SuppName.Name = "SuppName"
        Me.SuppName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SuppName.Width = 120
        '
        'POItem
        '
        Me.POItem.HeaderText = "PO Item"
        Me.POItem.Name = "POItem"
        Me.POItem.Width = 60
        '
        'ProdDescr
        '
        Me.ProdDescr.HeaderText = "Product Description"
        Me.ProdDescr.Name = "ProdDescr"
        Me.ProdDescr.Width = 140
        '
        'PONotes
        '
        Me.PONotes.HeaderText = "Notes"
        Me.PONotes.Name = "PONotes"
        Me.PONotes.Width = 140
        '
        'POQty
        '
        Me.POQty.HeaderText = "Qty"
        Me.POQty.Name = "POQty"
        Me.POQty.Width = 70
        '
        'POPrice
        '
        Me.POPrice.HeaderText = "Price"
        Me.POPrice.Name = "POPrice"
        Me.POPrice.Width = 70
        '
        'PORMSPrice
        '
        Me.PORMSPrice.HeaderText = "RM Surcharge"
        Me.PORMSPrice.Name = "PORMSPrice"
        Me.PORMSPrice.Width = 70
        '
        'POUM
        '
        Me.POUM.HeaderText = "UM"
        Me.POUM.Name = "POUM"
        Me.POUM.Width = 60
        '
        'DolarSign
        '
        Me.DolarSign.HeaderText = "Currency"
        Me.DolarSign.Name = "DolarSign"
        Me.DolarSign.Width = 60
        '
        'PONotesItem
        '
        Me.PONotesItem.HeaderText = "Item Notes"
        Me.PONotesItem.Name = "PONotesItem"
        Me.PONotesItem.Width = 120
        '
        'CompteDescr
        '
        Me.CompteDescr.HeaderText = "GL"
        Me.CompteDescr.Name = "CompteDescr"
        '
        'POStatus
        '
        Me.POStatus.HeaderText = "Status"
        Me.POStatus.Name = "POStatus"
        Me.POStatus.Width = 70
        '
        'MasterPODueDate
        '
        Me.MasterPODueDate.HeaderText = "Due Date"
        Me.MasterPODueDate.Name = "MasterPODueDate"
        Me.MasterPODueDate.Width = 70
        '
        'Rate
        '
        Me.Rate.HeaderText = "Month Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.Width = 70
        '
        'CmdSearch
        '
        Me.CmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearch.Location = New System.Drawing.Point(1155, 18)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(71, 36)
        Me.CmdSearch.TabIndex = 85
        Me.CmdSearch.Text = "Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.Location = New System.Drawing.Point(1316, 18)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(88, 36)
        Me.CmdClear.TabIndex = 86
        Me.CmdClear.Text = "Clear"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1489, 20)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(85, 36)
        Me.CmdExport.TabIndex = 87
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'frmPOQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1624, 853)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.dgPO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbBuyer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbSupplier)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Name = "frmPOQuery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPOQuery"
        CType(Me.dgPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbBuyer As System.Windows.Forms.ComboBox
    Friend WithEvents dgPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents PODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORMSPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DolarSign As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONotesItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompteDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MasterPODueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
