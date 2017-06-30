<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReleasePerishable
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgPer = New System.Windows.Forms.DataGridView()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.ProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockLoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinalStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwFinalSold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StDevise = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockPerishableID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwRateMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgPer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgPer
        '
        Me.dgPer.AllowUserToAddRows = False
        Me.dgPer.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPer.ColumnHeadersHeight = 30
        Me.dgPer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProdDescr, Me.ProdSpec, Me.StockLoc, Me.FinalStock, Me.StUM, Me.StPrice, Me.SwFinalSold, Me.StDevise, Me.StDate, Me.StNotes, Me.StockPerishableID, Me.ProdStockID, Me.SwRateMonth})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPer.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgPer.Location = New System.Drawing.Point(12, 81)
        Me.dgPer.Name = "dgPer"
        Me.dgPer.RowHeadersWidth = 25
        Me.dgPer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPer.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgPer.RowTemplate.Height = 20
        Me.dgPer.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPer.Size = New System.Drawing.Size(1477, 546)
        Me.dgPer.TabIndex = 1
        Me.dgPer.Text = "DataGridView1"
        '
        'cmdReset
        '
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(846, 19)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(112, 27)
        Me.cmdReset.TabIndex = 30
        Me.cmdReset.Text = "Reset"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.LightYellow
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(1128, 19)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(80, 27)
        Me.cmdSave.TabIndex = 29
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(8, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Perishable Product"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(110, 24)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(246, 20)
        Me.txtSearch.TabIndex = 31
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(480, 19)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(112, 27)
        Me.cmdSearch.TabIndex = 33
        Me.cmdSearch.Text = "Search"
        '
        'ProdDescr
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProdDescr.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProdDescr.HeaderText = "Product Descr."
        Me.ProdDescr.Name = "ProdDescr"
        Me.ProdDescr.Width = 300
        '
        'ProdSpec
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ProdSpec.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProdSpec.HeaderText = "Product Spec."
        Me.ProdSpec.Name = "ProdSpec"
        Me.ProdSpec.Width = 200
        '
        'StockLoc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.StockLoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockLoc.HeaderText = "Stock Loc."
        Me.StockLoc.Name = "StockLoc"
        '
        'FinalStock
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.FinalStock.DefaultCellStyle = DataGridViewCellStyle5
        Me.FinalStock.HeaderText = "Final Stock"
        Me.FinalStock.Name = "FinalStock"
        Me.FinalStock.Width = 80
        '
        'StUM
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StUM.DefaultCellStyle = DataGridViewCellStyle6
        Me.StUM.HeaderText = "UM"
        Me.StUM.Name = "StUM"
        Me.StUM.Width = 60
        '
        'StPrice
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.StPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.StPrice.HeaderText = "Stock Price"
        Me.StPrice.Name = "StPrice"
        Me.StPrice.Width = 80
        '
        'SwFinalSold
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.SwFinalSold.DefaultCellStyle = DataGridViewCellStyle8
        Me.SwFinalSold.HeaderText = "Value"
        Me.SwFinalSold.Name = "SwFinalSold"
        '
        'StDevise
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StDevise.DefaultCellStyle = DataGridViewCellStyle9
        Me.StDevise.HeaderText = "Devise"
        Me.StDevise.Name = "StDevise"
        Me.StDevise.Width = 60
        '
        'StDate
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "d"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.StDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.StDate.HeaderText = "Latest Date Stock"
        Me.StDate.Name = "StDate"
        Me.StDate.Width = 80
        '
        'StNotes
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.StNotes.DefaultCellStyle = DataGridViewCellStyle11
        Me.StNotes.HeaderText = "Notes"
        Me.StNotes.Name = "StNotes"
        '
        'StockPerishableID
        '
        Me.StockPerishableID.HeaderText = "StockPerishableID"
        Me.StockPerishableID.MinimumWidth = 2
        Me.StockPerishableID.Name = "StockPerishableID"
        Me.StockPerishableID.Visible = False
        Me.StockPerishableID.Width = 2
        '
        'ProdStockID
        '
        Me.ProdStockID.HeaderText = "ProdStockID"
        Me.ProdStockID.MinimumWidth = 2
        Me.ProdStockID.Name = "ProdStockID"
        Me.ProdStockID.Visible = False
        Me.ProdStockID.Width = 2
        '
        'SwRateMonth
        '
        Me.SwRateMonth.HeaderText = "SwRateMonth "
        Me.SwRateMonth.MinimumWidth = 2
        Me.SwRateMonth.Name = "SwRateMonth"
        Me.SwRateMonth.Visible = False
        Me.SwRateMonth.Width = 2
        '
        'frmReleasePerishable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1501, 641)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgPer)
        Me.Name = "frmReleasePerishable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lisi Aerospace Canada  -  Perishable Products Release to Production"
        CType(Me.dgPer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgPer As System.Windows.Forms.DataGridView
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents ProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockLoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinalStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwFinalSold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockPerishableID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRateMonth As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
