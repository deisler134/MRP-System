<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartProcess
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPartProcess))
        Me.dgProc = New System.Windows.Forms.DataGridView()
        Me.ProcOperID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdFind = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OperSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHeat = New System.Windows.Forms.TextBox()
        Me.cmbFinish = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMfgSpec = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPartRev = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDescCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.SwForm = New System.Windows.Forms.TextBox()
        Me.cmbMatl = New System.Windows.Forms.ComboBox()
        Me.CmdNo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CmbPrAcc = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RdSQL = New System.Windows.Forms.RadioButton()
        Me.RdAccess = New System.Windows.Forms.RadioButton()
        Me.RdPart = New System.Windows.Forms.RadioButton()
        Me.RdAll = New System.Windows.Forms.RadioButton()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdSrc = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.SwProc = New System.Windows.Forms.TextBox()
        Me.SwMpoID = New System.Windows.Forms.TextBox()
        Me.CmdFinish = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbMatltype = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDia = New System.Windows.Forms.TextBox()
        Me.SwGetOper = New System.Windows.Forms.TextBox()
        Me.SwGetSpec = New System.Windows.Forms.TextBox()
        CType(Me.dgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgProc
        '
        Me.dgProc.AllowDrop = True
        Me.dgProc.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgProc.BackgroundColor = System.Drawing.Color.LemonChiffon
        Me.dgProc.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgProc.ColumnHeadersHeight = 30
        Me.dgProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProcOperID, Me.ProcID, Me.OperNo, Me.OperDescr, Me.CmdFind, Me.OperSpec})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgProc.Location = New System.Drawing.Point(11, 169)
        Me.dgProc.Name = "dgProc"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgProc.RowHeadersWidth = 25
        Me.dgProc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgProc.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue
        Me.dgProc.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.RowTemplate.DividerHeight = 2
        Me.dgProc.RowTemplate.Height = 40
        Me.dgProc.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgProc.Size = New System.Drawing.Size(672, 654)
        Me.dgProc.TabIndex = 25
        '
        'ProcOperID
        '
        Me.ProcOperID.HeaderText = "ProcOperID"
        Me.ProcOperID.MinimumWidth = 2
        Me.ProcOperID.Name = "ProcOperID"
        Me.ProcOperID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcOperID.Visible = False
        Me.ProcOperID.Width = 2
        '
        'ProcID
        '
        Me.ProcID.HeaderText = "ProcID"
        Me.ProcID.MinimumWidth = 2
        Me.ProcID.Name = "ProcID"
        Me.ProcID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcID.Visible = False
        Me.ProcID.Width = 2
        '
        'OperNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OperNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.OperNo.HeaderText = "Oper No"
        Me.OperNo.Name = "OperNo"
        Me.OperNo.Width = 80
        '
        'OperDescr
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OperDescr.DefaultCellStyle = DataGridViewCellStyle4
        Me.OperDescr.HeaderText = "Description (40Char)"
        Me.OperDescr.Name = "OperDescr"
        Me.OperDescr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperDescr.Width = 285
        '
        'CmdFind
        '
        Me.CmdFind.HeaderText = "Search"
        Me.CmdFind.Name = "CmdFind"
        Me.CmdFind.Text = "Search"
        Me.CmdFind.UseColumnTextForButtonValue = True
        '
        'OperSpec
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OperSpec.DefaultCellStyle = DataGridViewCellStyle5
        Me.OperSpec.HeaderText = "Tech. / Specifications (20 Char)"
        Me.OperSpec.Name = "OperSpec"
        Me.OperSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OperSpec.Width = 155
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(470, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Heat Tr."
        '
        'txtHeat
        '
        Me.txtHeat.Location = New System.Drawing.Point(550, 37)
        Me.txtHeat.Multiline = True
        Me.txtHeat.Name = "txtHeat"
        Me.txtHeat.Size = New System.Drawing.Size(178, 47)
        Me.txtHeat.TabIndex = 60
        '
        'cmbFinish
        '
        Me.cmbFinish.DropDownHeight = 300
        Me.cmbFinish.FormattingEnabled = True
        Me.cmbFinish.IntegralHeight = False
        Me.cmbFinish.Location = New System.Drawing.Point(550, 11)
        Me.cmbFinish.Name = "cmbFinish"
        Me.cmbFinish.Size = New System.Drawing.Size(141, 21)
        Me.cmbFinish.TabIndex = 59
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(470, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Surface Finish"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(223, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Mfg Spec."
        '
        'txtMfgSpec
        '
        Me.txtMfgSpec.Location = New System.Drawing.Point(302, 14)
        Me.txtMfgSpec.Multiline = True
        Me.txtMfgSpec.Name = "txtMfgSpec"
        Me.txtMfgSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMfgSpec.Size = New System.Drawing.Size(162, 47)
        Me.txtMfgSpec.TabIndex = 56
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Part No. Rev"
        '
        'txtPartRev
        '
        Me.txtPartRev.Location = New System.Drawing.Point(80, 90)
        Me.txtPartRev.Name = "txtPartRev"
        Me.txtPartRev.Size = New System.Drawing.Size(139, 20)
        Me.txtPartRev.TabIndex = 50
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Desc. Code"
        '
        'txtDescCode
        '
        Me.txtDescCode.Location = New System.Drawing.Point(80, 64)
        Me.txtDescCode.Name = "txtDescCode"
        Me.txtDescCode.Size = New System.Drawing.Size(139, 20)
        Me.txtDescCode.TabIndex = 48
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Part Name"
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(80, 38)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(139, 20)
        Me.txtPartName.TabIndex = 46
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Part Number"
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(80, 12)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(139, 20)
        Me.txtPartNo.TabIndex = 44
        '
        'SwForm
        '
        Me.SwForm.BackColor = System.Drawing.Color.Maroon
        Me.SwForm.Location = New System.Drawing.Point(225, 33)
        Me.SwForm.Name = "SwForm"
        Me.SwForm.Size = New System.Drawing.Size(27, 20)
        Me.SwForm.TabIndex = 43
        Me.SwForm.Visible = False
        '
        'cmbMatl
        '
        Me.cmbMatl.FormattingEnabled = True
        Me.cmbMatl.Location = New System.Drawing.Point(302, 67)
        Me.cmbMatl.Name = "cmbMatl"
        Me.cmbMatl.Size = New System.Drawing.Size(162, 21)
        Me.cmbMatl.TabIndex = 71
        '
        'CmdNo
        '
        Me.CmdNo.Location = New System.Drawing.Point(11, 122)
        Me.CmdNo.Name = "CmdNo"
        Me.CmdNo.Size = New System.Drawing.Size(130, 37)
        Me.CmdNo.TabIndex = 73
        Me.CmdNo.Text = "Renumber Method and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Save Method"
        Me.CmdNo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(225, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Material"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.RdPart)
        Me.Panel1.Controls.Add(Me.RdAll)
        Me.Panel1.Controls.Add(Me.CmdAdd)
        Me.Panel1.Controls.Add(Me.CmdSrc)
        Me.Panel1.Controls.Add(Me.CmdPrint)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Location = New System.Drawing.Point(735, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 197)
        Me.Panel1.TabIndex = 85
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CmbPrAcc)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.RdSQL)
        Me.Panel2.Controls.Add(Me.RdAccess)
        Me.Panel2.Location = New System.Drawing.Point(81, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(303, 57)
        Me.Panel2.TabIndex = 100
        '
        'CmbPrAcc
        '
        Me.CmbPrAcc.DropDownHeight = 300
        Me.CmbPrAcc.FormattingEnabled = True
        Me.CmbPrAcc.IntegralHeight = False
        Me.CmbPrAcc.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.CmbPrAcc.Location = New System.Drawing.Point(237, 26)
        Me.CmbPrAcc.Name = "CmbPrAcc"
        Me.CmbPrAcc.Size = New System.Drawing.Size(60, 21)
        Me.CmbPrAcc.TabIndex = 101
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(185, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Proc#:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RdSQL
        '
        Me.RdSQL.AutoSize = True
        Me.RdSQL.Location = New System.Drawing.Point(74, 6)
        Me.RdSQL.Name = "RdSQL"
        Me.RdSQL.Size = New System.Drawing.Size(76, 17)
        Me.RdSQL.TabIndex = 98
        Me.RdSQL.TabStop = True
        Me.RdSQL.Text = "SQL Table"
        Me.RdSQL.UseVisualStyleBackColor = True
        '
        'RdAccess
        '
        Me.RdAccess.AutoSize = True
        Me.RdAccess.Location = New System.Drawing.Point(188, 6)
        Me.RdAccess.Name = "RdAccess"
        Me.RdAccess.Size = New System.Drawing.Size(109, 17)
        Me.RdAccess.TabIndex = 99
        Me.RdAccess.TabStop = True
        Me.RdAccess.Text = "MS Access Table"
        Me.RdAccess.UseVisualStyleBackColor = True
        '
        'RdPart
        '
        Me.RdPart.AutoSize = True
        Me.RdPart.Location = New System.Drawing.Point(275, 75)
        Me.RdPart.Name = "RdPart"
        Me.RdPart.Size = New System.Drawing.Size(66, 17)
        Me.RdPart.TabIndex = 90
        Me.RdPart.TabStop = True
        Me.RdPart.Text = "By Part#"
        Me.RdPart.UseVisualStyleBackColor = True
        '
        'RdAll
        '
        Me.RdAll.AutoSize = True
        Me.RdAll.Location = New System.Drawing.Point(159, 75)
        Me.RdAll.Name = "RdAll"
        Me.RdAll.Size = New System.Drawing.Size(63, 17)
        Me.RdAll.TabIndex = 89
        Me.RdAll.TabStop = True
        Me.RdAll.Text = "All Parts"
        Me.RdAll.UseVisualStyleBackColor = True
        '
        'CmdAdd
        '
        Me.CmdAdd.AutoEllipsis = True
        Me.CmdAdd.Location = New System.Drawing.Point(158, 153)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(221, 23)
        Me.CmdAdd.TabIndex = 88
        Me.CmdAdd.Text = "Transfer in the Method"
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'CmdSrc
        '
        Me.CmdSrc.Location = New System.Drawing.Point(159, 118)
        Me.CmdSrc.Name = "CmdSrc"
        Me.CmdSrc.Size = New System.Drawing.Size(221, 23)
        Me.CmdSrc.TabIndex = 87
        Me.CmdSrc.Text = "Search And View Proc"
        Me.CmdSrc.UseVisualStyleBackColor = True
        '
        'CmdPrint
        '
        Me.CmdPrint.Location = New System.Drawing.Point(0, 153)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.CmdPrint.TabIndex = 86
        Me.CmdPrint.Text = "View/Print"
        Me.CmdPrint.UseVisualStyleBackColor = True
        '
        'CmdSave
        '
        Me.CmdSave.Location = New System.Drawing.Point(0, 75)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 46)
        Me.CmdSave.TabIndex = 85
        Me.CmdSave.Text = "Save Method"
        Me.CmdSave.UseVisualStyleBackColor = True
        '
        'SwProc
        '
        Me.SwProc.BackColor = System.Drawing.Color.Maroon
        Me.SwProc.Location = New System.Drawing.Point(489, 129)
        Me.SwProc.Name = "SwProc"
        Me.SwProc.Size = New System.Drawing.Size(102, 20)
        Me.SwProc.TabIndex = 86
        Me.SwProc.Visible = False
        '
        'SwMpoID
        '
        Me.SwMpoID.BackColor = System.Drawing.Color.Maroon
        Me.SwMpoID.Location = New System.Drawing.Point(261, 33)
        Me.SwMpoID.Name = "SwMpoID"
        Me.SwMpoID.Size = New System.Drawing.Size(27, 20)
        Me.SwMpoID.TabIndex = 87
        Me.SwMpoID.Visible = False
        '
        'CmdFinish
        '
        Me.CmdFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdFinish.Image = CType(resources.GetObject("CmdFinish.Image"), System.Drawing.Image)
        Me.CmdFinish.Location = New System.Drawing.Point(697, 10)
        Me.CmdFinish.Name = "CmdFinish"
        Me.CmdFinish.Size = New System.Drawing.Size(31, 22)
        Me.CmdFinish.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Material Type"
        '
        'CmbMatltype
        '
        Me.CmbMatltype.Enabled = False
        Me.CmbMatltype.FormattingEnabled = True
        Me.CmbMatltype.Location = New System.Drawing.Point(302, 93)
        Me.CmbMatltype.Name = "CmbMatltype"
        Me.CmbMatltype.Size = New System.Drawing.Size(427, 21)
        Me.CmbMatltype.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Material Dia"
        '
        'txtDia
        '
        Me.txtDia.Location = New System.Drawing.Point(302, 119)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ReadOnly = True
        Me.txtDia.Size = New System.Drawing.Size(162, 20)
        Me.txtDia.TabIndex = 91
        Me.txtDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SwGetOper
        '
        Me.SwGetOper.BackColor = System.Drawing.Color.Maroon
        Me.SwGetOper.Location = New System.Drawing.Point(517, 64)
        Me.SwGetOper.Name = "SwGetOper"
        Me.SwGetOper.Size = New System.Drawing.Size(27, 20)
        Me.SwGetOper.TabIndex = 93
        Me.SwGetOper.Visible = False
        '
        'SwGetSpec
        '
        Me.SwGetSpec.BackColor = System.Drawing.Color.Maroon
        Me.SwGetSpec.Location = New System.Drawing.Point(517, 40)
        Me.SwGetSpec.Name = "SwGetSpec"
        Me.SwGetSpec.Size = New System.Drawing.Size(27, 20)
        Me.SwGetSpec.TabIndex = 94
        Me.SwGetSpec.Visible = False
        '
        'frmPartProcess
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1131, 826)
        Me.Controls.Add(Me.SwGetSpec)
        Me.Controls.Add(Me.SwGetOper)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbMatltype)
        Me.Controls.Add(Me.CmdFinish)
        Me.Controls.Add(Me.SwMpoID)
        Me.Controls.Add(Me.SwProc)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmdNo)
        Me.Controls.Add(Me.cmbMatl)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtHeat)
        Me.Controls.Add(Me.cmbFinish)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMfgSpec)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPartRev)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtDescCode)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.SwForm)
        Me.Controls.Add(Me.dgProc)
        Me.Name = "frmPartProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Process Sheet"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgProc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgProc As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHeat As System.Windows.Forms.TextBox
    Friend WithEvents cmbFinish As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMfgSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPartRev As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDescCode As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents SwForm As System.Windows.Forms.TextBox
    Friend WithEvents cmbMatl As System.Windows.Forms.ComboBox
    Friend WithEvents CmdNo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdSrc As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents SwProc As System.Windows.Forms.TextBox
    Friend WithEvents SwMpoID As System.Windows.Forms.TextBox
    Friend WithEvents CmdFinish As System.Windows.Forms.Button
    Friend WithEvents RdPart As System.Windows.Forms.RadioButton
    Friend WithEvents RdAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbMatltype As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDia As System.Windows.Forms.TextBox
    Friend WithEvents SwGetOper As System.Windows.Forms.TextBox
    Friend WithEvents SwGetSpec As System.Windows.Forms.TextBox
    Friend WithEvents RdAccess As System.Windows.Forms.RadioButton
    Friend WithEvents RdSQL As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CmbPrAcc As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ProcOperID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdFind As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents OperSpec As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
