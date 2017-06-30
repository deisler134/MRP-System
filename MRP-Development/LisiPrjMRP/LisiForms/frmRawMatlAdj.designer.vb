<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRawMatlAdj
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmbLot = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgLot = New System.Windows.Forms.DataGridView
        Me.MpoId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoLotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoMatlWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyAdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyEngReleased = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartQtyAdj = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RawWeight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WeightValidation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdjNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmdSave = New System.Windows.Forms.DataGridViewButtonColumn
        Me.MpoPartID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtStock = New System.Windows.Forms.TextBox
        Me.txtReleased = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbLot
        '
        Me.CmbLot.DropDownHeight = 300
        Me.CmbLot.FormattingEnabled = True
        Me.CmbLot.IntegralHeight = False
        Me.CmbLot.Location = New System.Drawing.Point(12, 37)
        Me.CmbLot.Name = "CmbLot"
        Me.CmbLot.Size = New System.Drawing.Size(110, 21)
        Me.CmbLot.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Raw Matl Lot Number"
        '
        'dgLot
        '
        Me.dgLot.AllowUserToAddRows = False
        Me.dgLot.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLot.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLot.ColumnHeadersHeight = 35
        Me.dgLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MpoId, Me.MpoNo, Me.MpoLotNo, Me.MpoMatlWeight, Me.QtyAdj, Me.QtyEngReleased, Me.StartQtyAdj, Me.RawWeight, Me.WeightValidation, Me.AdjNotes, Me.CmdSave, Me.MpoPartID})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLot.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgLot.Location = New System.Drawing.Point(12, 75)
        Me.dgLot.Name = "dgLot"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLot.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgLot.RowHeadersWidth = 25
        Me.dgLot.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgLot.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgLot.RowTemplate.Height = 25
        Me.dgLot.Size = New System.Drawing.Size(967, 271)
        Me.dgLot.TabIndex = 4
        Me.dgLot.Text = "DataGridView1"
        '
        'MpoId
        '
        Me.MpoId.HeaderText = "MpoId"
        Me.MpoId.MinimumWidth = 2
        Me.MpoId.Name = "MpoId"
        Me.MpoId.Visible = False
        Me.MpoId.Width = 2
        '
        'MpoNo
        '
        Me.MpoNo.HeaderText = "Mpo No"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MpoNo.Width = 80
        '
        'MpoLotNo
        '
        Me.MpoLotNo.HeaderText = "Mpo Lot No"
        Me.MpoLotNo.Name = "MpoLotNo"
        Me.MpoLotNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MpoLotNo.Width = 80
        '
        'MpoMatlWeight
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.MpoMatlWeight.DefaultCellStyle = DataGridViewCellStyle2
        Me.MpoMatlWeight.FillWeight = 80.0!
        Me.MpoMatlWeight.HeaderText = "Mpo Matl Weight"
        Me.MpoMatlWeight.Name = "MpoMatlWeight"
        Me.MpoMatlWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MpoMatlWeight.Width = 80
        '
        'QtyAdj
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.QtyAdj.DefaultCellStyle = DataGridViewCellStyle3
        Me.QtyAdj.FillWeight = 90.0!
        Me.QtyAdj.HeaderText = "Inventory Adj. (+ /-)"
        Me.QtyAdj.Name = "QtyAdj"
        Me.QtyAdj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.QtyAdj.Width = 110
        '
        'QtyEngReleased
        '
        Me.QtyEngReleased.FillWeight = 90.0!
        Me.QtyEngReleased.HeaderText = "Eng Qty"
        Me.QtyEngReleased.Name = "QtyEngReleased"
        Me.QtyEngReleased.Width = 80
        '
        'StartQtyAdj
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "N0"
        Me.StartQtyAdj.DefaultCellStyle = DataGridViewCellStyle4
        Me.StartQtyAdj.FillWeight = 90.0!
        Me.StartQtyAdj.HeaderText = "Actual Qty Cut"
        Me.StartQtyAdj.Name = "StartQtyAdj"
        Me.StartQtyAdj.Width = 80
        '
        'RawWeight
        '
        DataGridViewCellStyle5.Format = "N4"
        Me.RawWeight.DefaultCellStyle = DataGridViewCellStyle5
        Me.RawWeight.FillWeight = 90.0!
        Me.RawWeight.HeaderText = "Raw Weight"
        Me.RawWeight.Name = "RawWeight"
        Me.RawWeight.Width = 80
        '
        'WeightValidation
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle6.Format = "N0"
        Me.WeightValidation.DefaultCellStyle = DataGridViewCellStyle6
        Me.WeightValidation.FillWeight = 90.0!
        Me.WeightValidation.HeaderText = "Weight Validation"
        Me.WeightValidation.Name = "WeightValidation"
        Me.WeightValidation.Width = 80
        '
        'AdjNotes
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightBlue
        Me.AdjNotes.DefaultCellStyle = DataGridViewCellStyle7
        Me.AdjNotes.HeaderText = "Notes"
        Me.AdjNotes.Name = "AdjNotes"
        Me.AdjNotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AdjNotes.Width = 180
        '
        'CmdSave
        '
        Me.CmdSave.HeaderText = "Save Data"
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseColumnTextForButtonValue = True
        Me.CmdSave.Width = 80
        '
        'MpoPartID
        '
        Me.MpoPartID.HeaderText = "MpoPartID"
        Me.MpoPartID.MinimumWidth = 2
        Me.MpoPartID.Name = "MpoPartID"
        Me.MpoPartID.Visible = False
        Me.MpoPartID.Width = 2
        '
        'txtStock
        '
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStock.Location = New System.Drawing.Point(237, 37)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(100, 20)
        Me.txtStock.TabIndex = 6
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtReleased
        '
        Me.txtReleased.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReleased.ForeColor = System.Drawing.Color.DarkRed
        Me.txtReleased.Location = New System.Drawing.Point(237, 378)
        Me.txtReleased.Name = "txtReleased"
        Me.txtReleased.Size = New System.Drawing.Size(113, 20)
        Me.txtReleased.TabIndex = 7
        Me.txtReleased.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(234, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "RM Actual Stock"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(234, 359)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Total RM Released"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(378, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(380, 58)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Inv. Adj(+/-)  Explanation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-----------------------------------" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " +    Return the" & _
            " Qty in Inventory and Released the Qty from MPO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  -    Released the Qty from In" & _
            "ventory and Add the Qty to MPO"
        '
        'frmRawMatlAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 409)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtReleased)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.dgLot)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbLot)
        Me.Name = "frmRawMatlAdj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Raw Material Adjustments"
        CType(Me.dgLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbLot As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgLot As System.Windows.Forms.DataGridView
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents txtReleased As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents MpoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoLotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoMatlWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyAdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyEngReleased As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartQtyAdj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RawWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightValidation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSave As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents MpoPartID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
