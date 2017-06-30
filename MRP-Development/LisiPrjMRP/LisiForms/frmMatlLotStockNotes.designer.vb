<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatlLotStockNotes
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
        Me.CmbMatlNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtRecvWeight = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMatlCond = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtHeatNo = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtMatlType = New System.Windows.Forms.TextBox
        Me.txtDevise = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtRmSPrice = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtStPrice = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDateEntry = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ChkStk = New System.Windows.Forms.CheckBox
        Me.ChkOrders = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMatlLoc = New System.Windows.Forms.TextBox
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
        Me.Panel1.Controls.Add(Me.CmbMatlNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(718, 52)
        Me.Panel1.TabIndex = 2
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.Color.Transparent
        Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(658, 7)
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
        Me.CmdSave.Location = New System.Drawing.Point(379, 9)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(51, 33)
        Me.CmdSave.TabIndex = 2
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmbMatlNo
        '
        Me.CmbMatlNo.DropDownHeight = 400
        Me.CmbMatlNo.DropDownWidth = 200
        Me.CmbMatlNo.FormattingEnabled = True
        Me.CmbMatlNo.IntegralHeight = False
        Me.CmbMatlNo.Location = New System.Drawing.Point(95, 14)
        Me.CmbMatlNo.Name = "CmbMatlNo"
        Me.CmbMatlNo.Size = New System.Drawing.Size(82, 21)
        Me.CmbMatlNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search By Matl Lot No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Stock Notes"
        '
        'txtStockNotes
        '
        Me.txtStockNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNotes.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStockNotes.Location = New System.Drawing.Point(15, 235)
        Me.txtStockNotes.Multiline = True
        Me.txtStockNotes.Name = "txtStockNotes"
        Me.txtStockNotes.ReadOnly = True
        Me.txtStockNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStockNotes.Size = New System.Drawing.Size(523, 125)
        Me.txtStockNotes.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(577, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Out Qty"
        '
        'txtStOutput
        '
        Me.txtStOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStOutput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStOutput.Location = New System.Drawing.Point(570, 78)
        Me.txtStOutput.Name = "txtStOutput"
        Me.txtStOutput.ReadOnly = True
        Me.txtStOutput.Size = New System.Drawing.Size(59, 29)
        Me.txtStOutput.TabIndex = 96
        Me.txtStOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(486, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "In Qty"
        '
        'txtStInput
        '
        Me.txtStInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStInput.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStInput.Location = New System.Drawing.Point(479, 78)
        Me.txtStInput.Name = "txtStInput"
        Me.txtStInput.ReadOnly = True
        Me.txtStInput.Size = New System.Drawing.Size(59, 29)
        Me.txtStInput.TabIndex = 94
        Me.txtStInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(380, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Stock Initial"
        '
        'txtStIni
        '
        Me.txtStIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStIni.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStIni.Location = New System.Drawing.Point(383, 78)
        Me.txtStIni.Name = "txtStIni"
        Me.txtStIni.ReadOnly = True
        Me.txtStIni.Size = New System.Drawing.Size(59, 29)
        Me.txtStIni.TabIndex = 93
        Me.txtStIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(661, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Final Stock"
        '
        'txtStFinal
        '
        Me.txtStFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStFinal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStFinal.Location = New System.Drawing.Point(662, 78)
        Me.txtStFinal.Name = "txtStFinal"
        Me.txtStFinal.ReadOnly = True
        Me.txtStFinal.Size = New System.Drawing.Size(59, 29)
        Me.txtStFinal.TabIndex = 98
        Me.txtStFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(448, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 25)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "+"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(544, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 25)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(635, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 25)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "="
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(197, 162)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Recv Weight"
        '
        'txtRecvWeight
        '
        Me.txtRecvWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecvWeight.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRecvWeight.Location = New System.Drawing.Point(278, 159)
        Me.txtRecvWeight.Name = "txtRecvWeight"
        Me.txtRecvWeight.ReadOnly = True
        Me.txtRecvWeight.Size = New System.Drawing.Size(82, 21)
        Me.txtRecvWeight.TabIndex = 118
        Me.txtRecvWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(197, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 114
        Me.Label16.Text = "Matl. Cond."
        '
        'txtMatlCond
        '
        Me.txtMatlCond.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatlCond.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMatlCond.Location = New System.Drawing.Point(278, 133)
        Me.txtMatlCond.Name = "txtMatlCond"
        Me.txtMatlCond.ReadOnly = True
        Me.txtMatlCond.Size = New System.Drawing.Size(82, 21)
        Me.txtMatlCond.TabIndex = 117
        Me.txtMatlCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(197, 110)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 113
        Me.Label17.Text = "Heat No."
        '
        'txtHeatNo
        '
        Me.txtHeatNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeatNo.ForeColor = System.Drawing.Color.DarkRed
        Me.txtHeatNo.Location = New System.Drawing.Point(278, 107)
        Me.txtHeatNo.Name = "txtHeatNo"
        Me.txtHeatNo.ReadOnly = True
        Me.txtHeatNo.Size = New System.Drawing.Size(82, 21)
        Me.txtHeatNo.TabIndex = 116
        Me.txtHeatNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(197, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 119
        Me.Label18.Text = "Matl Type"
        '
        'txtMatlType
        '
        Me.txtMatlType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatlType.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMatlType.Location = New System.Drawing.Point(278, 79)
        Me.txtMatlType.Name = "txtMatlType"
        Me.txtMatlType.ReadOnly = True
        Me.txtMatlType.Size = New System.Drawing.Size(82, 21)
        Me.txtMatlType.TabIndex = 120
        Me.txtMatlType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDevise
        '
        Me.txtDevise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevise.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDevise.Location = New System.Drawing.Point(99, 159)
        Me.txtDevise.Name = "txtDevise"
        Me.txtDevise.ReadOnly = True
        Me.txtDevise.Size = New System.Drawing.Size(82, 21)
        Me.txtDevise.TabIndex = 84
        Me.txtDevise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(12, 159)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(40, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Devise"
        '
        'txtRmSPrice
        '
        Me.txtRmSPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRmSPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRmSPrice.Location = New System.Drawing.Point(99, 133)
        Me.txtRmSPrice.Name = "txtRmSPrice"
        Me.txtRmSPrice.ReadOnly = True
        Me.txtRmSPrice.Size = New System.Drawing.Size(82, 21)
        Me.txtRmSPrice.TabIndex = 83
        Me.txtRmSPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Rms Price"
        '
        'txtStPrice
        '
        Me.txtStPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStPrice.ForeColor = System.Drawing.Color.DarkRed
        Me.txtStPrice.Location = New System.Drawing.Point(99, 107)
        Me.txtStPrice.Name = "txtStPrice"
        Me.txtStPrice.ReadOnly = True
        Me.txtStPrice.Size = New System.Drawing.Size(82, 21)
        Me.txtStPrice.TabIndex = 82
        Me.txtStPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Stock Price"
        '
        'txtDateEntry
        '
        Me.txtDateEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateEntry.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDateEntry.Location = New System.Drawing.Point(99, 79)
        Me.txtDateEntry.Name = "txtDateEntry"
        Me.txtDateEntry.ReadOnly = True
        Me.txtDateEntry.Size = New System.Drawing.Size(82, 21)
        Me.txtDateEntry.TabIndex = 81
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
        'ChkStk
        '
        Me.ChkStk.AutoSize = True
        Me.ChkStk.Location = New System.Drawing.Point(570, 235)
        Me.ChkStk.Name = "ChkStk"
        Me.ChkStk.Size = New System.Drawing.Size(94, 17)
        Me.ChkStk.TabIndex = 121
        Me.ChkStk.Text = "For Stock only"
        Me.ChkStk.UseVisualStyleBackColor = True
        '
        'ChkOrders
        '
        Me.ChkOrders.AutoSize = True
        Me.ChkOrders.Location = New System.Drawing.Point(570, 324)
        Me.ChkOrders.Name = "ChkOrders"
        Me.ChkOrders.Size = New System.Drawing.Size(154, 17)
        Me.ChkOrders.TabIndex = 122
        Me.ChkOrders.Text = "For Future Contract / Order"
        Me.ChkOrders.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Matl Location"
        '
        'txtMatlLoc
        '
        Me.txtMatlLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatlLoc.ForeColor = System.Drawing.Color.DarkRed
        Me.txtMatlLoc.Location = New System.Drawing.Point(278, 186)
        Me.txtMatlLoc.Name = "txtMatlLoc"
        Me.txtMatlLoc.ReadOnly = True
        Me.txtMatlLoc.Size = New System.Drawing.Size(82, 21)
        Me.txtMatlLoc.TabIndex = 124
        Me.txtMatlLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmMatlLotStockNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 376)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMatlLoc)
        Me.Controls.Add(Me.ChkOrders)
        Me.Controls.Add(Me.ChkStk)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtMatlType)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtRecvWeight)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtMatlCond)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtHeatNo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtDevise)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRmSPrice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStPrice)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDateEntry)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMatlLotStockNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Add Notes to an Existent Material Lot"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmbMatlNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRecvWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMatlCond As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtHeatNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtMatlType As System.Windows.Forms.TextBox
    Friend WithEvents txtDevise As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRmSPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDateEntry As System.Windows.Forms.TextBox
    Friend WithEvents ChkOrders As System.Windows.Forms.CheckBox
    Friend WithEvents ChkStk As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMatlLoc As System.Windows.Forms.TextBox
End Class
