<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFPReleaseToMPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFPReleaseToMPO))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmbProdMPO = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
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
        Me.txtStAdj = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtQtyAct = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtStLoc = New System.Windows.Forms.TextBox
        Me.txtDeptSelected = New System.Windows.Forms.TextBox
        Me.SwDeptID = New System.Windows.Forms.TextBox
        Me.SwDeptWhat = New System.Windows.Forms.TextBox
        Me.SwMPOType = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightYellow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.cmbProdMPO)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.cmdReset)
        Me.Panel1.Controls.Add(Me.txtPartID)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.CmbMpoNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(965, 52)
        Me.Panel1.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(515, 1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(109, 44)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "List with all the MPOs from Planning Department."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbProdMPO
        '
        Me.cmbProdMPO.DropDownHeight = 300
        Me.cmbProdMPO.DropDownWidth = 200
        Me.cmbProdMPO.FormattingEnabled = True
        Me.cmbProdMPO.IntegralHeight = False
        Me.cmbProdMPO.Location = New System.Drawing.Point(403, 12)
        Me.cmbProdMPO.Name = "cmbProdMPO"
        Me.cmbProdMPO.Size = New System.Drawing.Size(102, 21)
        Me.cmbProdMPO.TabIndex = 73
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Maroon
        Me.Label21.Location = New System.Drawing.Point(284, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 44)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "Release To Production Mpo No."
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.Color.Transparent
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(868, 5)
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
        Me.CmdSave.Location = New System.Drawing.Point(657, 5)
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
        Me.CmbMpoNo.Location = New System.Drawing.Point(123, 14)
        Me.CmbMpoNo.Name = "CmbMpoNo"
        Me.CmbMpoNo.Size = New System.Drawing.Size(102, 21)
        Me.CmbMpoNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Release From FP Mpo No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(12, 159)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Sales Price"
        '
        'txtSalesPrice
        '
        Me.txtSalesPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.txtSalesPrice.Location = New System.Drawing.Point(127, 154)
        Me.txtSalesPrice.Name = "txtSalesPrice"
        Me.txtSalesPrice.ReadOnly = True
        Me.txtSalesPrice.Size = New System.Drawing.Size(82, 21)
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
        Me.txtPartName.Location = New System.Drawing.Point(127, 128)
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
        Me.txtPartNo.Location = New System.Drawing.Point(127, 102)
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
        Me.txtDateEntry.Location = New System.Drawing.Point(127, 76)
        Me.txtDateEntry.Name = "txtDateEntry"
        Me.txtDateEntry.ReadOnly = True
        Me.txtDateEntry.Size = New System.Drawing.Size(82, 21)
        Me.txtDateEntry.TabIndex = 81
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(215, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 12)
        Me.Label14.TabIndex = 86
        Me.Label14.Text = "MPO Part Rev"
        '
        'txtMPOPartRev
        '
        Me.txtMPOPartRev.BackColor = System.Drawing.SystemColors.Control
        Me.txtMPOPartRev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPOPartRev.Location = New System.Drawing.Point(215, 102)
        Me.txtMPOPartRev.Name = "txtMPOPartRev"
        Me.txtMPOPartRev.Size = New System.Drawing.Size(66, 21)
        Me.txtMPOPartRev.TabIndex = 87
        Me.txtMPOPartRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Currency"
        '
        'txtDevise
        '
        Me.txtDevise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevise.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDevise.Location = New System.Drawing.Point(127, 180)
        Me.txtDevise.Name = "txtDevise"
        Me.txtDevise.ReadOnly = True
        Me.txtDevise.Size = New System.Drawing.Size(82, 21)
        Me.txtDevise.TabIndex = 88
        Me.txtDevise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Stock Notes"
        '
        'txtStockNotes
        '
        Me.txtStockNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNotes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockNotes.Location = New System.Drawing.Point(127, 207)
        Me.txtStockNotes.Multiline = True
        Me.txtStockNotes.Name = "txtStockNotes"
        Me.txtStockNotes.ReadOnly = True
        Me.txtStockNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtStockNotes.Size = New System.Drawing.Size(283, 94)
        Me.txtStockNotes.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(779, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Out Qty"
        '
        'txtStOutput
        '
        Me.txtStOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStOutput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStOutput.Location = New System.Drawing.Point(770, 79)
        Me.txtStOutput.Name = "txtStOutput"
        Me.txtStOutput.ReadOnly = True
        Me.txtStOutput.Size = New System.Drawing.Size(69, 26)
        Me.txtStOutput.TabIndex = 96
        Me.txtStOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(658, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "In Qty"
        '
        'txtStInput
        '
        Me.txtStInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStInput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStInput.Location = New System.Drawing.Point(643, 79)
        Me.txtStInput.Name = "txtStInput"
        Me.txtStInput.ReadOnly = True
        Me.txtStInput.Size = New System.Drawing.Size(69, 26)
        Me.txtStInput.TabIndex = 94
        Me.txtStInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(511, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Stock Initial"
        '
        'txtStIni
        '
        Me.txtStIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStIni.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStIni.Location = New System.Drawing.Point(512, 79)
        Me.txtStIni.Name = "txtStIni"
        Me.txtStIni.ReadOnly = True
        Me.txtStIni.Size = New System.Drawing.Size(69, 26)
        Me.txtStIni.TabIndex = 93
        Me.txtStIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(869, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Final Stock"
        '
        'txtStFinal
        '
        Me.txtStFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStFinal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStFinal.Location = New System.Drawing.Point(872, 79)
        Me.txtStFinal.Name = "txtStFinal"
        Me.txtStFinal.ReadOnly = True
        Me.txtStFinal.Size = New System.Drawing.Size(82, 26)
        Me.txtStFinal.TabIndex = 98
        Me.txtStFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(512, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(307, 90)
        Me.Label11.TabIndex = 101
        Me.Label11.Text = resources.GetString("Label11.Text")
        '
        'txtStAdj
        '
        Me.txtStAdj.BackColor = System.Drawing.Color.White
        Me.txtStAdj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStAdj.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStAdj.Location = New System.Drawing.Point(872, 128)
        Me.txtStAdj.Name = "txtStAdj"
        Me.txtStAdj.ReadOnly = True
        Me.txtStAdj.Size = New System.Drawing.Size(82, 26)
        Me.txtStAdj.TabIndex = 100
        Me.txtStAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(603, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 25)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "+"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(734, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 25)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(845, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 25)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "="
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.ForeColor = System.Drawing.Color.DarkRed
        Me.txtResult.Location = New System.Drawing.Point(872, 234)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(82, 26)
        Me.txtResult.TabIndex = 111
        Me.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(869, 204)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 18)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Stock Adj."
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(335, 107)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 114
        Me.Label16.Text = "Qty Actual"
        '
        'txtQtyAct
        '
        Me.txtQtyAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyAct.ForeColor = System.Drawing.Color.DarkRed
        Me.txtQtyAct.Location = New System.Drawing.Point(407, 102)
        Me.txtQtyAct.Name = "txtQtyAct"
        Me.txtQtyAct.ReadOnly = True
        Me.txtQtyAct.Size = New System.Drawing.Size(82, 21)
        Me.txtQtyAct.TabIndex = 116
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(335, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 113
        Me.Label17.Text = "Department"
        '
        'txtDept
        '
        Me.txtDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDept.Location = New System.Drawing.Point(407, 76)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(82, 21)
        Me.txtDept.TabIndex = 115
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(215, 164)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Stock Location"
        '
        'txtStLoc
        '
        Me.txtStLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStLoc.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStLoc.Location = New System.Drawing.Point(215, 180)
        Me.txtStLoc.Name = "txtStLoc"
        Me.txtStLoc.ReadOnly = True
        Me.txtStLoc.Size = New System.Drawing.Size(82, 21)
        Me.txtStLoc.TabIndex = 117
        Me.txtStLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDeptSelected
        '
        Me.txtDeptSelected.BackColor = System.Drawing.Color.Maroon
        Me.txtDeptSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeptSelected.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDeptSelected.Location = New System.Drawing.Point(423, 133)
        Me.txtDeptSelected.Name = "txtDeptSelected"
        Me.txtDeptSelected.ReadOnly = True
        Me.txtDeptSelected.Size = New System.Drawing.Size(66, 21)
        Me.txtDeptSelected.TabIndex = 119
        Me.txtDeptSelected.Visible = False
        '
        'SwDeptID
        '
        Me.SwDeptID.BackColor = System.Drawing.Color.Maroon
        Me.SwDeptID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwDeptID.ForeColor = System.Drawing.Color.DarkRed
        Me.SwDeptID.Location = New System.Drawing.Point(423, 160)
        Me.SwDeptID.Name = "SwDeptID"
        Me.SwDeptID.ReadOnly = True
        Me.SwDeptID.Size = New System.Drawing.Size(66, 21)
        Me.SwDeptID.TabIndex = 120
        Me.SwDeptID.Visible = False
        '
        'SwDeptWhat
        '
        Me.SwDeptWhat.BackColor = System.Drawing.Color.Maroon
        Me.SwDeptWhat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwDeptWhat.ForeColor = System.Drawing.Color.DarkRed
        Me.SwDeptWhat.Location = New System.Drawing.Point(423, 185)
        Me.SwDeptWhat.Name = "SwDeptWhat"
        Me.SwDeptWhat.ReadOnly = True
        Me.SwDeptWhat.Size = New System.Drawing.Size(66, 21)
        Me.SwDeptWhat.TabIndex = 121
        Me.SwDeptWhat.Visible = False
        '
        'SwMPOType
        '
        Me.SwMPOType.BackColor = System.Drawing.Color.Maroon
        Me.SwMPOType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwMPOType.ForeColor = System.Drawing.Color.DarkRed
        Me.SwMPOType.Location = New System.Drawing.Point(423, 212)
        Me.SwMPOType.Name = "SwMPOType"
        Me.SwMPOType.ReadOnly = True
        Me.SwMPOType.Size = New System.Drawing.Size(66, 21)
        Me.SwMPOType.TabIndex = 122
        Me.SwMPOType.Visible = False
        '
        'frmFPReleaseToMPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 313)
        Me.Controls.Add(Me.SwMPOType)
        Me.Controls.Add(Me.SwDeptWhat)
        Me.Controls.Add(Me.SwDeptID)
        Me.Controls.Add(Me.txtDeptSelected)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtStLoc)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtQtyAct)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtStAdj)
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
        Me.Name = "frmFPReleaseToMPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Release From Finish Parts Inventory To Production"
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
    Friend WithEvents txtStAdj As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbProdMPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQtyAct As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtStLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDeptSelected As System.Windows.Forms.TextBox
    Friend WithEvents SwDeptID As System.Windows.Forms.TextBox
    Friend WithEvents SwDeptWhat As System.Windows.Forms.TextBox
    Friend WithEvents SwMPOType As System.Windows.Forms.TextBox
End Class
