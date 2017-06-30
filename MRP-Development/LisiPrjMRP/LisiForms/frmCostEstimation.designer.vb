<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCostEstimation
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
        Dim Label15 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCostEstimation))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPartDate = New System.Windows.Forms.MaskedTextBox
        Me.CmdReset = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmdBrowse = New System.Windows.Forms.Button
        Me.CmdSeePart = New System.Windows.Forms.Button
        Me.CmbUser = New System.Windows.Forms.ComboBox
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdNew = New System.Windows.Forms.Button
        Me.CmbPartHeader = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.CmbDwgSource = New System.Windows.Forms.ComboBox
        Me.txtPartName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescrCode = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbPart = New System.Windows.Forms.ComboBox
        Me.txtPartDia = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPartLength = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbRev = New System.Windows.Forms.ComboBox
        Me.CmbMfg = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbNasMs = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNasDia = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNasLength = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmdSeeMat = New System.Windows.Forms.Button
        Me.txtDensity = New System.Windows.Forms.TextBox
        Me.CmbMatType = New System.Windows.Forms.ComboBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.CmbDevise = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtCostDate = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.dgQty = New System.Windows.Forms.DataGridView
        Me.CostQtyID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyItem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostEstTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostQtyNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Label15 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Label17 = New System.Windows.Forms.Label
        Label19 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label15
        '
        Label15.ForeColor = System.Drawing.Color.Blue
        Label15.Location = New System.Drawing.Point(3, 5)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(53, 23)
        Label15.TabIndex = 154
        Label15.Text = "Mat'l Type"
        Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label16.ForeColor = System.Drawing.Color.Blue
        Label16.Location = New System.Drawing.Point(3, 35)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(42, 23)
        Label16.TabIndex = 157
        Label16.Text = "Material"
        Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label17.ForeColor = System.Drawing.Color.Blue
        Label17.Location = New System.Drawing.Point(3, 63)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(41, 23)
        Label17.TabIndex = 158
        Label17.Text = "Density"
        Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label19.ForeColor = System.Drawing.Color.Blue
        Label19.Location = New System.Drawing.Point(3, 86)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(41, 23)
        Label19.TabIndex = 163
        Label19.Text = "Weight"
        Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(803, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "User"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(803, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Date"
        '
        'txtPartDate
        '
        Me.txtPartDate.Location = New System.Drawing.Point(860, 3)
        Me.txtPartDate.Name = "txtPartDate"
        Me.txtPartDate.ReadOnly = True
        Me.txtPartDate.Size = New System.Drawing.Size(89, 20)
        Me.txtPartDate.TabIndex = 8
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(621, 14)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(75, 23)
        Me.CmdReset.TabIndex = 5
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(525, 14)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 4
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmdBrowse)
        Me.Panel1.Controls.Add(Me.CmdSeePart)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.CmbUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtPartDate)
        Me.Panel1.Controls.Add(Me.CmdReset)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.CmdEdit)
        Me.Panel1.Controls.Add(Me.CmdNew)
        Me.Panel1.Controls.Add(Me.CmbPartHeader)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(954, 55)
        Me.Panel1.TabIndex = 2
        '
        'CmdBrowse
        '
        Me.CmdBrowse.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.Location = New System.Drawing.Point(712, 14)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.CmdBrowse.TabIndex = 136
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = False
        '
        'CmdSeePart
        '
        Me.CmdSeePart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdSeePart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSeePart.Image = CType(resources.GetObject("CmdSeePart.Image"), System.Drawing.Image)
        Me.CmdSeePart.Location = New System.Drawing.Point(284, 18)
        Me.CmdSeePart.Name = "CmdSeePart"
        Me.CmdSeePart.Size = New System.Drawing.Size(25, 19)
        Me.CmdSeePart.TabIndex = 135
        '
        'CmbUser
        '
        Me.CmbUser.FormattingEnabled = True
        Me.CmbUser.Location = New System.Drawing.Point(860, 29)
        Me.CmbUser.Name = "CmbUser"
        Me.CmbUser.Size = New System.Drawing.Size(89, 21)
        Me.CmbUser.TabIndex = 10
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(430, 15)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 3
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdNew
        '
        Me.CmdNew.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNew.Location = New System.Drawing.Point(329, 16)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(75, 23)
        Me.CmdNew.TabIndex = 2
        Me.CmdNew.Text = "New"
        Me.CmdNew.UseVisualStyleBackColor = False
        '
        'CmbPartHeader
        '
        Me.CmbPartHeader.FormattingEnabled = True
        Me.CmbPartHeader.Location = New System.Drawing.Point(114, 17)
        Me.CmbPartHeader.Name = "CmbPartHeader"
        Me.CmbPartHeader.Size = New System.Drawing.Size(149, 21)
        Me.CmbPartHeader.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Part Number"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label14.Location = New System.Drawing.Point(19, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = "Dwg Source"
        '
        'CmbDwgSource
        '
        Me.CmbDwgSource.DropDownHeight = 400
        Me.CmbDwgSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDwgSource.DropDownWidth = 300
        Me.CmbDwgSource.ForeColor = System.Drawing.Color.Black
        Me.CmbDwgSource.FormattingEnabled = True
        Me.CmbDwgSource.IntegralHeight = False
        Me.CmbDwgSource.Location = New System.Drawing.Point(98, 41)
        Me.CmbDwgSource.Name = "CmbDwgSource"
        Me.CmbDwgSource.Size = New System.Drawing.Size(111, 21)
        Me.CmbDwgSource.TabIndex = 128
        '
        'txtPartName
        '
        Me.txtPartName.ForeColor = System.Drawing.Color.Black
        Me.txtPartName.Location = New System.Drawing.Point(98, 67)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(111, 20)
        Me.txtPartName.TabIndex = 132
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label5.Location = New System.Drawing.Point(19, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 23)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Part Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label2.Location = New System.Drawing.Point(19, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 23)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Part Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescrCode
        '
        Me.txtDescrCode.ForeColor = System.Drawing.Color.Black
        Me.txtDescrCode.Location = New System.Drawing.Point(98, 93)
        Me.txtDescrCode.Name = "txtDescrCode"
        Me.txtDescrCode.Size = New System.Drawing.Size(111, 20)
        Me.txtDescrCode.TabIndex = 135
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label12.Location = New System.Drawing.Point(19, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 23)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "Descr. Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbPart
        '
        Me.CmbPart.DropDownHeight = 400
        Me.CmbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPart.DropDownWidth = 300
        Me.CmbPart.ForeColor = System.Drawing.Color.Black
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.IntegralHeight = False
        Me.CmbPart.Location = New System.Drawing.Point(98, 14)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.Size = New System.Drawing.Size(111, 21)
        Me.CmbPart.TabIndex = 137
        '
        'txtPartDia
        '
        Me.txtPartDia.ForeColor = System.Drawing.Color.Black
        Me.txtPartDia.Location = New System.Drawing.Point(98, 199)
        Me.txtPartDia.Name = "txtPartDia"
        Me.txtPartDia.Size = New System.Drawing.Size(100, 20)
        Me.txtPartDia.TabIndex = 139
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label9.Location = New System.Drawing.Point(19, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 23)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Blank Dia"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartLength
        '
        Me.txtPartLength.ForeColor = System.Drawing.Color.Black
        Me.txtPartLength.Location = New System.Drawing.Point(98, 173)
        Me.txtPartLength.Name = "txtPartLength"
        Me.txtPartLength.Size = New System.Drawing.Size(100, 20)
        Me.txtPartLength.TabIndex = 138
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label8.Location = New System.Drawing.Point(19, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 22)
        Me.Label8.TabIndex = 140
        Me.Label8.Text = "Blank Length"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label3.Location = New System.Drawing.Point(20, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 22)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Part Revision"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbRev
        '
        Me.CmbRev.DropDownHeight = 500
        Me.CmbRev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRev.DropDownWidth = 300
        Me.CmbRev.ForeColor = System.Drawing.Color.Black
        Me.CmbRev.FormattingEnabled = True
        Me.CmbRev.IntegralHeight = False
        Me.CmbRev.Location = New System.Drawing.Point(98, 119)
        Me.CmbRev.Name = "CmbRev"
        Me.CmbRev.Size = New System.Drawing.Size(111, 21)
        Me.CmbRev.TabIndex = 144
        '
        'CmbMfg
        '
        Me.CmbMfg.DropDownHeight = 500
        Me.CmbMfg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMfg.DropDownWidth = 300
        Me.CmbMfg.ForeColor = System.Drawing.Color.Black
        Me.CmbMfg.FormattingEnabled = True
        Me.CmbMfg.IntegralHeight = False
        Me.CmbMfg.Location = New System.Drawing.Point(98, 146)
        Me.CmbMfg.Name = "CmbMfg"
        Me.CmbMfg.Size = New System.Drawing.Size(111, 21)
        Me.CmbMfg.TabIndex = 146
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label4.Location = New System.Drawing.Point(20, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 22)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Mfg. Spec."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbNasMs
        '
        Me.CmbNasMs.DropDownHeight = 500
        Me.CmbNasMs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNasMs.DropDownWidth = 300
        Me.CmbNasMs.ForeColor = System.Drawing.Color.Black
        Me.CmbNasMs.FormattingEnabled = True
        Me.CmbNasMs.IntegralHeight = False
        Me.CmbNasMs.Location = New System.Drawing.Point(98, 11)
        Me.CmbNasMs.Name = "CmbNasMs"
        Me.CmbNasMs.Size = New System.Drawing.Size(111, 21)
        Me.CmbNasMs.TabIndex = 148
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(19, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 22)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "NAS  --  MS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNasDia
        '
        Me.txtNasDia.ForeColor = System.Drawing.Color.Black
        Me.txtNasDia.Location = New System.Drawing.Point(98, 63)
        Me.txtNasDia.Name = "txtNasDia"
        Me.txtNasDia.Size = New System.Drawing.Size(100, 20)
        Me.txtNasDia.TabIndex = 150
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(19, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 23)
        Me.Label11.TabIndex = 152
        Me.Label11.Text = "Blank Dia"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNasLength
        '
        Me.txtNasLength.ForeColor = System.Drawing.Color.Black
        Me.txtNasLength.Location = New System.Drawing.Point(98, 38)
        Me.txtNasLength.Name = "txtNasLength"
        Me.txtNasLength.Size = New System.Drawing.Size(100, 20)
        Me.txtNasLength.TabIndex = 149
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.DarkRed
        Me.Label13.Location = New System.Drawing.Point(19, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 22)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "Blank Length"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdSeeMat
        '
        Me.CmdSeeMat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdSeeMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdSeeMat.Image = CType(resources.GetObject("CmdSeeMat.Image"), System.Drawing.Image)
        Me.CmdSeeMat.Location = New System.Drawing.Point(74, 7)
        Me.CmdSeeMat.Name = "CmdSeeMat"
        Me.CmdSeeMat.Size = New System.Drawing.Size(23, 19)
        Me.CmdSeeMat.TabIndex = 153
        '
        'txtDensity
        '
        Me.txtDensity.ForeColor = System.Drawing.Color.Black
        Me.txtDensity.Location = New System.Drawing.Point(74, 59)
        Me.txtDensity.Name = "txtDensity"
        Me.txtDensity.Size = New System.Drawing.Size(103, 20)
        Me.txtDensity.TabIndex = 156
        '
        'CmbMatType
        '
        Me.CmbMatType.DropDownHeight = 400
        Me.CmbMatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMatType.DropDownWidth = 300
        Me.CmbMatType.ForeColor = System.Drawing.Color.Black
        Me.CmbMatType.FormattingEnabled = True
        Me.CmbMatType.IntegralHeight = False
        Me.CmbMatType.Location = New System.Drawing.Point(74, 32)
        Me.CmbMatType.Name = "CmbMatType"
        Me.CmbMatType.Size = New System.Drawing.Size(103, 21)
        Me.CmbMatType.TabIndex = 159
        '
        'txtWeight
        '
        Me.txtWeight.ForeColor = System.Drawing.Color.Black
        Me.txtWeight.Location = New System.Drawing.Point(75, 85)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(74, 20)
        Me.txtWeight.TabIndex = 162
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtNasDia)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtNasLength)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.CmbNasMs)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(3, 372)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 93)
        Me.Panel2.TabIndex = 170
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(200, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(13, 13)
        Me.Label23.TabIndex = 154
        Me.Label23.Text = """"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(200, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 13)
        Me.Label22.TabIndex = 153
        Me.Label22.Text = """"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Label19)
        Me.Panel3.Controls.Add(Me.txtWeight)
        Me.Panel3.Controls.Add(Me.CmbMatType)
        Me.Panel3.Controls.Add(Label17)
        Me.Panel3.Controls.Add(Label16)
        Me.Panel3.Controls.Add(Me.txtDensity)
        Me.Panel3.Controls.Add(Label15)
        Me.Panel3.Controls.Add(Me.CmdSeeMat)
        Me.Panel3.Location = New System.Drawing.Point(257, 73)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(183, 114)
        Me.Panel3.TabIndex = 171
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(155, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 13)
        Me.Label21.TabIndex = 164
        Me.Label21.Text = "LBS"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.CmbDevise)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.txtCostDate)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.txtPartDia)
        Me.Panel4.Controls.Add(Me.CmbMfg)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.txtPartLength)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.CmbRev)
        Me.Panel4.Controls.Add(Me.CmbPart)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtDescrCode)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txtPartName)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.CmbDwgSource)
        Me.Panel4.Location = New System.Drawing.Point(3, 73)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(248, 281)
        Me.Panel4.TabIndex = 172
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(201, 206)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 13)
        Me.Label20.TabIndex = 150
        Me.Label20.Text = """"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(202, 178)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(13, 13)
        Me.Label18.TabIndex = 149
        Me.Label18.Text = """"
        '
        'CmbDevise
        '
        Me.CmbDevise.DropDownHeight = 500
        Me.CmbDevise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDevise.DropDownWidth = 300
        Me.CmbDevise.ForeColor = System.Drawing.Color.Black
        Me.CmbDevise.FormattingEnabled = True
        Me.CmbDevise.IntegralHeight = False
        Me.CmbDevise.Items.AddRange(New Object() {"USD", "CAD", "EUR"})
        Me.CmbDevise.Location = New System.Drawing.Point(98, 251)
        Me.CmbDevise.Name = "CmbDevise"
        Me.CmbDevise.Size = New System.Drawing.Size(111, 21)
        Me.CmbDevise.TabIndex = 148
        '
        'Label28
        '
        Me.Label28.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label28.Location = New System.Drawing.Point(20, 250)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(71, 22)
        Me.Label28.TabIndex = 147
        Me.Label28.Text = "Currency"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostDate
        '
        Me.txtCostDate.ForeColor = System.Drawing.Color.Black
        Me.txtCostDate.Location = New System.Drawing.Point(98, 225)
        Me.txtCostDate.Name = "txtCostDate"
        Me.txtCostDate.Size = New System.Drawing.Size(111, 20)
        Me.txtCostDate.TabIndex = 142
        '
        'Label27
        '
        Me.Label27.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label27.Location = New System.Drawing.Point(19, 225)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(71, 23)
        Me.Label27.TabIndex = 143
        Me.Label27.Text = "Cost Date"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.Location = New System.Drawing.Point(492, 73)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(461, 114)
        Me.txtNotes.TabIndex = 181
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(446, 73)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(40, 23)
        Me.Label26.TabIndex = 182
        Me.Label26.Text = "Notes"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgQty
        '
        Me.dgQty.AllowUserToOrderColumns = True
        Me.dgQty.AllowUserToResizeColumns = False
        Me.dgQty.AllowUserToResizeRows = False
        Me.dgQty.ColumnHeadersHeight = 20
        Me.dgQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgQty.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CostQtyID, Me.CostID, Me.QtyItem, Me.CostQty, Me.CostPrice, Me.Value, Me.CostEstTime, Me.CostQtyNotes})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgQty.Location = New System.Drawing.Point(257, 220)
        Me.dgQty.Name = "dgQty"
        Me.dgQty.RowHeadersWidth = 25
        Me.dgQty.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgQty.RowTemplate.Height = 18
        Me.dgQty.Size = New System.Drawing.Size(696, 245)
        Me.dgQty.TabIndex = 185
        Me.dgQty.Text = "DataGridView1"
        '
        'CostQtyID
        '
        Me.CostQtyID.HeaderText = "CostQtyID"
        Me.CostQtyID.MinimumWidth = 2
        Me.CostQtyID.Name = "CostQtyID"
        Me.CostQtyID.Visible = False
        Me.CostQtyID.Width = 2
        '
        'CostID
        '
        Me.CostID.HeaderText = "CostID"
        Me.CostID.Name = "CostID"
        Me.CostID.Visible = False
        '
        'QtyItem
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.NullValue = Nothing
        Me.QtyItem.DefaultCellStyle = DataGridViewCellStyle1
        Me.QtyItem.HeaderText = "Line"
        Me.QtyItem.Name = "QtyItem"
        Me.QtyItem.Width = 50
        '
        'CostQty
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CostQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.CostQty.HeaderText = "Qty"
        Me.CostQty.Name = "CostQty"
        Me.CostQty.Width = 70
        '
        'CostPrice
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CostPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.CostPrice.HeaderText = "Cost"
        Me.CostPrice.Name = "CostPrice"
        Me.CostPrice.Width = 70
        '
        'Value
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Value.DefaultCellStyle = DataGridViewCellStyle4
        Me.Value.HeaderText = "Value"
        Me.Value.Name = "Value"
        Me.Value.Width = 80
        '
        'CostEstTime
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CostEstTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.CostEstTime.HeaderText = "Est. Time"
        Me.CostEstTime.Name = "CostEstTime"
        Me.CostEstTime.Width = 80
        '
        'CostQtyNotes
        '
        Me.CostQtyNotes.HeaderText = "Notes"
        Me.CostQtyNotes.Name = "CostQtyNotes"
        Me.CostQtyNotes.Width = 300
        '
        'frmCostEstimation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 474)
        Me.Controls.Add(Me.dgQty)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCostEstimation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Cost Estimation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPartDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbUser As System.Windows.Forms.ComboBox
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdNew As System.Windows.Forms.Button
    Friend WithEvents CmbPartHeader As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbDwgSource As System.Windows.Forms.ComboBox
    Friend WithEvents CmdSeePart As System.Windows.Forms.Button
    Friend WithEvents txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents txtPartDia As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPartLength As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbRev As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMfg As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbNasMs As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNasDia As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNasLength As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmdSeeMat As System.Windows.Forms.Button
    Friend WithEvents txtDensity As System.Windows.Forms.TextBox
    Friend WithEvents CmbMatType As System.Windows.Forms.ComboBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtCostDate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CmbDevise As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dgQty As System.Windows.Forms.DataGridView
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CostQtyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostEstTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostQtyNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
