<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOrderEntryPutBCAYearPrice
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgGrid = New System.Windows.Forms.DataGridView()
        Me.txtSW = New System.Windows.Forms.TextBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.YearNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartPriceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgGrid
        '
        Me.dgGrid.AllowUserToAddRows = False
        Me.dgGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.YearNo, Me.PriceValue, Me.PartNumber, Me.PartPriceID})
        Me.dgGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgGrid.Location = New System.Drawing.Point(0, 0)
        Me.dgGrid.Name = "dgGrid"
        Me.dgGrid.ReadOnly = True
        Me.dgGrid.Size = New System.Drawing.Size(464, 266)
        Me.dgGrid.TabIndex = 0
        Me.dgGrid.Text = "DataGridView1"
        '
        'txtSW
        '
        Me.txtSW.Location = New System.Drawing.Point(33, 124)
        Me.txtSW.Name = "txtSW"
        Me.txtSW.Size = New System.Drawing.Size(63, 20)
        Me.txtSW.TabIndex = 2
        Me.txtSW.Visible = False
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(292, 123)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(63, 20)
        Me.txtRow.TabIndex = 3
        Me.txtRow.Visible = False
        '
        'YearNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.YearNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.YearNo.HeaderText = "Year"
        Me.YearNo.Name = "YearNo"
        Me.YearNo.ReadOnly = True
        '
        'PriceValue
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PriceValue.DefaultCellStyle = DataGridViewCellStyle3
        Me.PriceValue.HeaderText = "Price-Year"
        Me.PriceValue.Name = "PriceValue"
        Me.PriceValue.ReadOnly = True
        '
        'PartNumber
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PartNumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.PartNumber.HeaderText = "PartNumber"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.Width = 200
        '
        'PartPriceID
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PartPriceID.DefaultCellStyle = DataGridViewCellStyle5
        Me.PartPriceID.HeaderText = "PartPriceID"
        Me.PartPriceID.Name = "PartPriceID"
        Me.PartPriceID.ReadOnly = True
        Me.PartPriceID.Visible = False
        '
        'frmOrderEntryPutBCAYearPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 266)
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.txtSW)
        Me.Controls.Add(Me.dgGrid)
        Me.Name = "frmOrderEntryPutBCAYearPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrderEntryPutBCAYearPrice.vb"
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgGrid As System.Windows.Forms.DataGridView
    Friend WithEvents txtSW As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
    Friend WithEvents YearNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartPriceID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
