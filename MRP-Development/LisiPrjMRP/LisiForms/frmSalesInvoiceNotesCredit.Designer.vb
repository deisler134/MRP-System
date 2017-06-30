<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesInvoiceNotesCredit
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInv = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbMPO = New System.Windows.Forms.ComboBox
        Me.CmdExec = New System.Windows.Forms.Button
        Me.RdSales = New System.Windows.Forms.RadioButton
        Me.RdCustReturn = New System.Windows.Forms.RadioButton
        Me.RdIR = New System.Windows.Forms.RadioButton
        Me.LblCredit = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.LblRMA = New System.Windows.Forms.Label
        Me.txtRMA = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCreditAmount = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtIR = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(29, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Invoice No."
        '
        'txtInv
        '
        Me.txtInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInv.Location = New System.Drawing.Point(158, 32)
        Me.txtInv.Name = "txtInv"
        Me.txtInv.ReadOnly = True
        Me.txtInv.Size = New System.Drawing.Size(156, 29)
        Me.txtInv.TabIndex = 24
        Me.txtInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(29, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "MPO Inventory"
        '
        'CmbMPO
        '
        Me.CmbMPO.DropDownHeight = 300
        Me.CmbMPO.DropDownWidth = 200
        Me.CmbMPO.Enabled = False
        Me.CmbMPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMPO.FormattingEnabled = True
        Me.CmbMPO.IntegralHeight = False
        Me.CmbMPO.Location = New System.Drawing.Point(158, 85)
        Me.CmbMPO.Name = "CmbMPO"
        Me.CmbMPO.Size = New System.Drawing.Size(156, 32)
        Me.CmbMPO.TabIndex = 89
        '
        'CmdExec
        '
        Me.CmdExec.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExec.Location = New System.Drawing.Point(26, 483)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(221, 31)
        Me.CmdExec.TabIndex = 90
        Me.CmdExec.Text = "Execute"
        Me.CmdExec.UseVisualStyleBackColor = True
        '
        'RdSales
        '
        Me.RdSales.AutoSize = True
        Me.RdSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdSales.ForeColor = System.Drawing.Color.Blue
        Me.RdSales.Location = New System.Drawing.Point(26, 190)
        Me.RdSales.Name = "RdSales"
        Me.RdSales.Size = New System.Drawing.Size(111, 17)
        Me.RdSales.TabIndex = 91
        Me.RdSales.TabStop = True
        Me.RdSales.Text = "Sales - Internal"
        Me.RdSales.UseVisualStyleBackColor = True
        '
        'RdCustReturn
        '
        Me.RdCustReturn.AutoSize = True
        Me.RdCustReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdCustReturn.ForeColor = System.Drawing.Color.Blue
        Me.RdCustReturn.Location = New System.Drawing.Point(26, 233)
        Me.RdCustReturn.Name = "RdCustReturn"
        Me.RdCustReturn.Size = New System.Drawing.Size(186, 17)
        Me.RdCustReturn.TabIndex = 92
        Me.RdCustReturn.TabStop = True
        Me.RdCustReturn.Text = "Return from Customer (RMA)"
        Me.RdCustReturn.UseVisualStyleBackColor = True
        '
        'RdIR
        '
        Me.RdIR.AutoSize = True
        Me.RdIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdIR.ForeColor = System.Drawing.Color.Blue
        Me.RdIR.Location = New System.Drawing.Point(26, 273)
        Me.RdIR.Name = "RdIR"
        Me.RdIR.Size = New System.Drawing.Size(131, 17)
        Me.RdIR.TabIndex = 93
        Me.RdIR.TabStop = True
        Me.RdIR.Text = "Inter Company (IR)"
        Me.RdIR.UseVisualStyleBackColor = True
        '
        'LblCredit
        '
        Me.LblCredit.AutoSize = True
        Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCredit.ForeColor = System.Drawing.Color.SaddleBrown
        Me.LblCredit.Location = New System.Drawing.Point(245, 328)
        Me.LblCredit.Name = "LblCredit"
        Me.LblCredit.Size = New System.Drawing.Size(94, 16)
        Me.LblCredit.TabIndex = 95
        Me.LblCredit.Text = "Credit Notes"
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(248, 347)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(422, 73)
        Me.txtNotes.TabIndex = 94
        '
        'LblRMA
        '
        Me.LblRMA.AutoSize = True
        Me.LblRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRMA.ForeColor = System.Drawing.Color.SaddleBrown
        Me.LblRMA.Location = New System.Drawing.Point(245, 233)
        Me.LblRMA.Name = "LblRMA"
        Me.LblRMA.Size = New System.Drawing.Size(69, 16)
        Me.LblRMA.TabIndex = 97
        Me.LblRMA.Text = "RMA No."
        '
        'txtRMA
        '
        Me.txtRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRMA.Location = New System.Drawing.Point(322, 225)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(93, 29)
        Me.txtRMA.TabIndex = 96
        Me.txtRMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(434, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Invoice Price"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(544, 32)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(126, 29)
        Me.txtPrice.TabIndex = 98
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(434, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Credit Qty"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(544, 85)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(126, 29)
        Me.txtQty.TabIndex = 100
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(434, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Credit Amount"
        '
        'txtCreditAmount
        '
        Me.txtCreditAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditAmount.Location = New System.Drawing.Point(544, 140)
        Me.txtCreditAmount.Name = "txtCreditAmount"
        Me.txtCreditAmount.ReadOnly = True
        Me.txtCreditAmount.Size = New System.Drawing.Size(126, 29)
        Me.txtCreditAmount.TabIndex = 102
        Me.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label5.Location = New System.Drawing.Point(245, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "IR No."
        '
        'txtIR
        '
        Me.txtIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIR.Location = New System.Drawing.Point(322, 273)
        Me.txtIR.Name = "txtIR"
        Me.txtIR.Size = New System.Drawing.Size(93, 29)
        Me.txtIR.TabIndex = 104
        Me.txtIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmSalesInvoiceNotesCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 529)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCreditAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.LblRMA)
        Me.Controls.Add(Me.txtRMA)
        Me.Controls.Add(Me.LblCredit)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.RdIR)
        Me.Controls.Add(Me.RdCustReturn)
        Me.Controls.Add(Me.RdSales)
        Me.Controls.Add(Me.CmdExec)
        Me.Controls.Add(Me.CmbMPO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtInv)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmSalesInvoiceNotesCredit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada - Invoice Notes Credit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInv As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbMPO As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents RdSales As System.Windows.Forms.RadioButton
    Friend WithEvents RdCustReturn As System.Windows.Forms.RadioButton
    Friend WithEvents RdIR As System.Windows.Forms.RadioButton
    Friend WithEvents LblCredit As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents LblRMA As System.Windows.Forms.Label
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIR As System.Windows.Forms.TextBox
End Class
