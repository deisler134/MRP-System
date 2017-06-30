<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFPSalesPriceUpdate
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdReset = New System.Windows.Forms.Button
        Me.txtPartID = New System.Windows.Forms.TextBox
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmbMpoNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtSalesPrice = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPartName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPartNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDateEntry = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMPOPartRev = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDevise = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtStockNotes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStOutput = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStInput = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtStIni = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtStFinal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtQtyScrapped = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtQtyEng = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtQtyActual = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtStLoc = New System.Windows.Forms.TextBox
        Me.txtNewPr = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtOldPrice = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightYellow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdReset)
        Me.Panel1.Controls.Add(Me.txtPartID)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.CmbMpoNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(15, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 52)
        Me.Panel1.TabIndex = 2
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.Color.Transparent
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(737, 9)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(51, 33)
        Me.cmdReset.TabIndex = 71
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = False
        '
        'txtPartID
        '
        Me.txtPartID.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPartID.Location = New System.Drawing.Point(968, 31)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.ReadOnly = True
        Me.txtPartID.Size = New System.Drawing.Size(10, 20)
        Me.txtPartID.TabIndex = 70
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.Transparent
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(381, 9)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(51, 33)
        Me.CmdSave.TabIndex = 2
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmbMpoNo
        '
        Me.CmbMpoNo.DropDownHeight = 300
        Me.CmbMpoNo.DropDownWidth = 200
        Me.CmbMpoNo.FormattingEnabled = True
        Me.CmbMpoNo.IntegralHeight = False
        Me.CmbMpoNo.Location = New System.Drawing.Point(95, 14)
        Me.CmbMpoNo.Name = "CmbMpoNo"
        Me.CmbMpoNo.Size = New System.Drawing.Size(82, 21)
        Me.CmbMpoNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search By Mpo No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(687, 130)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Sales Price"
        '
        'txtSalesPrice
        '
        Me.txtSalesPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSalesPrice.Location = New System.Drawing.Point(787, 127)
        Me.txtSalesPrice.Name = "txtSalesPrice"
        Me.txtSalesPrice.ReadOnly = True
        Me.txtSalesPrice.Size = New System.Drawing.Size(69, 21)
        Me.txtSalesPrice.TabIndex = 84
        Me.txtSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Part Name"
        '
        'txtPartName
        '
        Me.txtPartName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartName.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPartName.Location = New System.Drawing.Point(99, 130)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.ReadOnly = True
        Me.txtPartName.Size = New System.Drawing.Size(82, 21)
        Me.txtPartName.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Part Number"
        '
        'txtPartNo
        '
        Me.txtPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPartNo.Location = New System.Drawing.Point(99, 104)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.ReadOnly = True
        Me.txtPartNo.Size = New System.Drawing.Size(82, 21)
        Me.txtPartNo.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Date Entry"
        '
        'txtDateEntry
        '
        Me.txtDateEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateEntry.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDateEntry.Location = New System.Drawing.Point(99, 78)
        Me.txtDateEntry.Name = "txtDateEntry"
        Me.txtDateEntry.ReadOnly = True
        Me.txtDateEntry.Size = New System.Drawing.Size(82, 21)
        Me.txtDateEntry.TabIndex = 81
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(187, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 12)
        Me.Label14.TabIndex = 86
        Me.Label14.Text = "MPO Part Rev"
        '
        'txtMPOPartRev
        '
        Me.txtMPOPartRev.BackColor = System.Drawing.SystemColors.Control
        Me.txtMPOPartRev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPOPartRev.Location = New System.Drawing.Point(187, 104)
        Me.txtMPOPartRev.Name = "txtMPOPartRev"
        Me.txtMPOPartRev.Size = New System.Drawing.Size(66, 21)
        Me.txtMPOPartRev.TabIndex = 87
        Me.txtMPOPartRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Currency"
        '
        'txtDevise
        '
        Me.txtDevise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevise.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDevise.Location = New System.Drawing.Point(99, 157)
        Me.txtDevise.Name = "txtDevise"
        Me.txtDevise.ReadOnly = True
        Me.txtDevise.Size = New System.Drawing.Size(82, 21)
        Me.txtDevise.TabIndex = 88
        Me.txtDevise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Stock Notes"
        '
        'txtStockNotes
        '
        Me.txtStockNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNotes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockNotes.Location = New System.Drawing.Point(99, 222)
        Me.txtStockNotes.Multiline = True
        Me.txtStockNotes.Name = "txtStockNotes"
        Me.txtStockNotes.ReadOnly = True
        Me.txtStockNotes.Size = New System.Drawing.Size(450, 65)
        Me.txtStockNotes.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(702, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Out Qty"
        '
        'txtStOutput
        '
        Me.txtStOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStOutput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStOutput.Location = New System.Drawing.Point(685, 78)
        Me.txtStOutput.Name = "txtStOutput"
        Me.txtStOutput.ReadOnly = True
        Me.txtStOutput.Size = New System.Drawing.Size(69, 26)
        Me.txtStOutput.TabIndex = 96
        Me.txtStOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(593, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "In Qty"
        '
        'txtStInput
        '
        Me.txtStInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStInput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStInput.Location = New System.Drawing.Point(586, 78)
        Me.txtStInput.Name = "txtStInput"
        Me.txtStInput.ReadOnly = True
        Me.txtStInput.Size = New System.Drawing.Size(69, 26)
        Me.txtStInput.TabIndex = 94
        Me.txtStInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(487, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Stock Initial"
        '
        'txtStIni
        '
        Me.txtStIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStIni.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStIni.Location = New System.Drawing.Point(480, 77)
        Me.txtStIni.Name = "txtStIni"
        Me.txtStIni.ReadOnly = True
        Me.txtStIni.Size = New System.Drawing.Size(69, 26)
        Me.txtStIni.TabIndex = 93
        Me.txtStIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(786, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Final Stock"
        '
        'txtStFinal
        '
        Me.txtStFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStFinal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStFinal.Location = New System.Drawing.Point(787, 78)
        Me.txtStFinal.Name = "txtStFinal"
        Me.txtStFinal.ReadOnly = True
        Me.txtStFinal.Size = New System.Drawing.Size(69, 26)
        Me.txtStFinal.TabIndex = 98
        Me.txtStFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(687, 186)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 24)
        Me.Label11.TabIndex = 101
        Me.Label11.Text = "Price Adjustment" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "==============" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(555, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 25)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "+"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(661, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 25)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(760, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 25)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "="
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(301, 132)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 13)
        Me.Label16.TabIndex = 110
        Me.Label16.Text = "Qty Scrapped"
        '
        'txtQtyScrapped
        '
        Me.txtQtyScrapped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyScrapped.ForeColor = System.Drawing.Color.DarkRed
        Me.txtQtyScrapped.Location = New System.Drawing.Point(388, 129)
        Me.txtQtyScrapped.Name = "txtQtyScrapped"
        Me.txtQtyScrapped.ReadOnly = True
        Me.txtQtyScrapped.Size = New System.Drawing.Size(82, 21)
        Me.txtQtyScrapped.TabIndex = 109
        Me.txtQtyScrapped.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(301, 106)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Qty Eng. Rel."
        '
        'txtQtyEng
        '
        Me.txtQtyEng.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyEng.ForeColor = System.Drawing.Color.DarkRed
        Me.txtQtyEng.Location = New System.Drawing.Point(388, 103)
        Me.txtQtyEng.Name = "txtQtyEng"
        Me.txtQtyEng.ReadOnly = True
        Me.txtQtyEng.Size = New System.Drawing.Size(82, 21)
        Me.txtQtyEng.TabIndex = 107
        Me.txtQtyEng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(301, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "Qty Actual"
        '
        'txtQtyActual
        '
        Me.txtQtyActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyActual.ForeColor = System.Drawing.Color.DarkRed
        Me.txtQtyActual.Location = New System.Drawing.Point(388, 77)
        Me.txtQtyActual.Name = "txtQtyActual"
        Me.txtQtyActual.ReadOnly = True
        Me.txtQtyActual.Size = New System.Drawing.Size(82, 21)
        Me.txtQtyActual.TabIndex = 106
        Me.txtQtyActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(12, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 17)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Stock Location"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStLoc
        '
        Me.txtStLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStLoc.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStLoc.Location = New System.Drawing.Point(99, 184)
        Me.txtStLoc.Name = "txtStLoc"
        Me.txtStLoc.ReadOnly = True
        Me.txtStLoc.Size = New System.Drawing.Size(82, 22)
        Me.txtStLoc.TabIndex = 113
        Me.txtStLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNewPr
        '
        Me.txtNewPr.BackColor = System.Drawing.Color.White
        Me.txtNewPr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPr.ForeColor = System.Drawing.Color.DarkRed
        Me.txtNewPr.Location = New System.Drawing.Point(787, 186)
        Me.txtNewPr.Name = "txtNewPr"
        Me.txtNewPr.ReadOnly = True
        Me.txtNewPr.Size = New System.Drawing.Size(69, 26)
        Me.txtNewPr.TabIndex = 115
        Me.txtNewPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(687, 158)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 117
        Me.Label19.Text = "Old Sales Price"
        '
        'txtOldPrice
        '
        Me.txtOldPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.txtOldPrice.Location = New System.Drawing.Point(787, 155)
        Me.txtOldPrice.Name = "txtOldPrice"
        Me.txtOldPrice.ReadOnly = True
        Me.txtOldPrice.Size = New System.Drawing.Size(69, 21)
        Me.txtOldPrice.TabIndex = 116
        Me.txtOldPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmFPSalesPriceUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 299)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtOldPrice)
        Me.Controls.Add(Me.txtNewPr)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtStLoc)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtQtyScrapped)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtQtyEng)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtQtyActual)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtStFinal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtStOutput)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStInput)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtStIni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtStockNotes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDevise)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMPOPartRev)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtSalesPrice)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDateEntry)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmFPSalesPriceUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Finish Parts Inventory (Price Adjustment)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmbMpoNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtSalesPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDateEntry As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMPOPartRev As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDevise As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStockNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtStOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStInput As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQtyScrapped As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtQtyEng As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtQtyActual As System.Windows.Forms.TextBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtStLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPr As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtOldPrice As System.Windows.Forms.TextBox
End Class
