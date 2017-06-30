<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPartMasterQuote
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
        Dim Label23 As System.Windows.Forms.Label
        Dim Label18 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SwFormQTShort = New System.Windows.Forms.TextBox()
        Me.CmdBrowse = New System.Windows.Forms.Button()
        Me.CmbUser = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPartDate = New System.Windows.Forms.MaskedTextBox()
        Me.CmdReset = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.CmdNew = New System.Windows.Forms.Button()
        Me.CmbPartNumber = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dgRev = New System.Windows.Forms.DataGridView()
        Me.PartRevID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevDateStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CmbApprovedBy = New System.Windows.Forms.ComboBox()
        Me.txtDateApproved = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CmbCreatedBy = New System.Windows.Forms.ComboBox()
        Me.txtDateIssue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescrCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMinQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMaxQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtM3Article = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbCrossStatus = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        Label18 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgRev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label23
        '
        Label23.ForeColor = System.Drawing.Color.Blue
        Label23.Location = New System.Drawing.Point(10, 346)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(64, 23)
        Label23.TabIndex = 169
        Label23.Text = "Approved BY"
        Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Label18.ForeColor = System.Drawing.Color.Blue
        Label18.Location = New System.Drawing.Point(10, 318)
        Label18.Name = "Label18"
        Label18.Size = New System.Drawing.Size(64, 23)
        Label18.TabIndex = 165
        Label18.Text = "Created BY"
        Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(850, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "User"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.SwFormQTShort)
        Me.Panel1.Controls.Add(Me.CmdBrowse)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.CmbUser)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtPartDate)
        Me.Panel1.Controls.Add(Me.CmdReset)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.CmdEdit)
        Me.Panel1.Controls.Add(Me.CmdNew)
        Me.Panel1.Controls.Add(Me.CmbPartNumber)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1025, 55)
        Me.Panel1.TabIndex = 2
        '
        'SwFormQTShort
        '
        Me.SwFormQTShort.Location = New System.Drawing.Point(69, 3)
        Me.SwFormQTShort.Name = "SwFormQTShort"
        Me.SwFormQTShort.Size = New System.Drawing.Size(10, 20)
        Me.SwFormQTShort.TabIndex = 170
        Me.SwFormQTShort.Visible = False
        '
        'CmdBrowse
        '
        Me.CmdBrowse.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBrowse.Location = New System.Drawing.Point(743, 17)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(91, 23)
        Me.CmdBrowse.TabIndex = 6
        Me.CmdBrowse.Text = "Browse"
        Me.CmdBrowse.UseVisualStyleBackColor = False
        '
        'CmbUser
        '
        Me.CmbUser.FormattingEnabled = True
        Me.CmbUser.Location = New System.Drawing.Point(889, 29)
        Me.CmbUser.Name = "CmbUser"
        Me.CmbUser.Size = New System.Drawing.Size(124, 21)
        Me.CmbUser.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(850, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Date"
        '
        'txtPartDate
        '
        Me.txtPartDate.Location = New System.Drawing.Point(889, 3)
        Me.txtPartDate.Name = "txtPartDate"
        Me.txtPartDate.ReadOnly = True
        Me.txtPartDate.Size = New System.Drawing.Size(124, 20)
        Me.txtPartDate.TabIndex = 8
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(629, 17)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(91, 23)
        Me.CmdReset.TabIndex = 5
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(518, 17)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(91, 23)
        Me.CmdSave.TabIndex = 4
        Me.CmdSave.Text = "Save Part#"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(410, 17)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(91, 23)
        Me.CmdEdit.TabIndex = 3
        Me.CmdEdit.Text = "Edit Part#"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdNew
        '
        Me.CmdNew.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNew.Location = New System.Drawing.Point(301, 17)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(91, 23)
        Me.CmdNew.TabIndex = 2
        Me.CmdNew.Text = "New Part#"
        Me.CmdNew.UseVisualStyleBackColor = False
        '
        'CmbPartNumber
        '
        Me.CmbPartNumber.DropDownHeight = 500
        Me.CmbPartNumber.FormattingEnabled = True
        Me.CmbPartNumber.IntegralHeight = False
        Me.CmbPartNumber.Location = New System.Drawing.Point(114, 17)
        Me.CmbPartNumber.Name = "CmbPartNumber"
        Me.CmbPartNumber.Size = New System.Drawing.Size(149, 21)
        Me.CmbPartNumber.TabIndex = 1
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
        'txtPartNo
        '
        Me.txtPartNo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtPartNo.Location = New System.Drawing.Point(117, 80)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(172, 20)
        Me.txtPartNo.TabIndex = 156
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(10, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 23)
        Me.Label22.TabIndex = 158
        Me.Label22.Text = "Part Number"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgRev
        '
        Me.dgRev.AllowUserToDeleteRows = False
        Me.dgRev.AllowUserToOrderColumns = True
        Me.dgRev.AllowUserToResizeColumns = False
        Me.dgRev.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgRev.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRev.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgRev.ColumnHeadersHeight = 20
        Me.dgRev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgRev.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartRevID, Me.PartID, Me.RevNo, Me.RevDateStart, Me.RevDesc, Me.RevNotes, Me.RevStatus})
        Me.dgRev.EnableHeadersVisualStyles = False
        Me.dgRev.Location = New System.Drawing.Point(305, 80)
        Me.dgRev.Name = "dgRev"
        Me.dgRev.RowHeadersWidth = 25
        Me.dgRev.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgRev.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgRev.RowTemplate.Height = 20
        Me.dgRev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgRev.Size = New System.Drawing.Size(722, 373)
        Me.dgRev.TabIndex = 159
        Me.dgRev.Text = "DataGridView1"
        '
        'PartRevID
        '
        Me.PartRevID.HeaderText = "PartRevID"
        Me.PartRevID.MinimumWidth = 2
        Me.PartRevID.Name = "PartRevID"
        Me.PartRevID.Visible = False
        Me.PartRevID.Width = 2
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.MinimumWidth = 2
        Me.PartID.Name = "PartID"
        Me.PartID.Visible = False
        Me.PartID.Width = 2
        '
        'RevNo
        '
        Me.RevNo.HeaderText = "Revision"
        Me.RevNo.Name = "RevNo"
        Me.RevNo.Width = 70
        '
        'RevDateStart
        '
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = "MM/dd/yyyy"
        Me.RevDateStart.DefaultCellStyle = DataGridViewCellStyle3
        Me.RevDateStart.HeaderText = "DateStart"
        Me.RevDateStart.Name = "RevDateStart"
        Me.RevDateStart.Width = 80
        '
        'RevDesc
        '
        Me.RevDesc.HeaderText = "RevDesc"
        Me.RevDesc.Name = "RevDesc"
        Me.RevDesc.Width = 200
        '
        'RevNotes
        '
        Me.RevNotes.HeaderText = "RevNotes"
        Me.RevNotes.Name = "RevNotes"
        Me.RevNotes.Width = 240
        '
        'RevStatus
        '
        Me.RevStatus.HeaderText = "RevStatus"
        Me.RevStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.RevStatus.Name = "RevStatus"
        Me.RevStatus.Width = 80
        '
        'CmbApprovedBy
        '
        Me.CmbApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbApprovedBy.FormattingEnabled = True
        Me.CmbApprovedBy.Location = New System.Drawing.Point(117, 347)
        Me.CmbApprovedBy.Name = "CmbApprovedBy"
        Me.CmbApprovedBy.Size = New System.Drawing.Size(172, 21)
        Me.CmbApprovedBy.TabIndex = 168
        '
        'txtDateApproved
        '
        Me.txtDateApproved.Location = New System.Drawing.Point(117, 376)
        Me.txtDateApproved.Name = "txtDateApproved"
        Me.txtDateApproved.Size = New System.Drawing.Size(172, 20)
        Me.txtDateApproved.TabIndex = 166
        '
        'Label24
        '
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(11, 374)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 23)
        Me.Label24.TabIndex = 167
        Me.Label24.Text = "Date Approuved"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbCreatedBy
        '
        Me.CmbCreatedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCreatedBy.FormattingEnabled = True
        Me.CmbCreatedBy.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.CmbCreatedBy.Location = New System.Drawing.Point(117, 318)
        Me.CmbCreatedBy.Name = "CmbCreatedBy"
        Me.CmbCreatedBy.Size = New System.Drawing.Size(172, 21)
        Me.CmbCreatedBy.TabIndex = 164
        '
        'txtDateIssue
        '
        Me.txtDateIssue.Location = New System.Drawing.Point(117, 167)
        Me.txtDateIssue.Name = "txtDateIssue"
        Me.txtDateIssue.Size = New System.Drawing.Size(172, 20)
        Me.txtDateIssue.TabIndex = 161
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(11, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 23)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Date Issue"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(117, 138)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(172, 20)
        Me.txtPartName.TabIndex = 160
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(10, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 23)
        Me.Label5.TabIndex = 162
        Me.Label5.Text = "Part Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescrCode
        '
        Me.txtDescrCode.Location = New System.Drawing.Point(117, 108)
        Me.txtDescrCode.Name = "txtDescrCode"
        Me.txtDescrCode.Size = New System.Drawing.Size(172, 20)
        Me.txtDescrCode.TabIndex = 170
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(10, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Description Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinQty
        '
        Me.txtMinQty.Location = New System.Drawing.Point(117, 404)
        Me.txtMinQty.Name = "txtMinQty"
        Me.txtMinQty.Size = New System.Drawing.Size(172, 20)
        Me.txtMinQty.TabIndex = 172
        Me.txtMinQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(11, 402)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 23)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "Stock Min Qty"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaxQty
        '
        Me.txtMaxQty.Location = New System.Drawing.Point(117, 432)
        Me.txtMaxQty.Name = "txtMaxQty"
        Me.txtMaxQty.Size = New System.Drawing.Size(172, 20)
        Me.txtMaxQty.TabIndex = 174
        Me.txtMaxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(11, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 23)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Max Qty to Launch"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtM3Article
        '
        Me.txtM3Article.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM3Article.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtM3Article.Location = New System.Drawing.Point(117, 195)
        Me.txtM3Article.Name = "txtM3Article"
        Me.txtM3Article.Size = New System.Drawing.Size(172, 26)
        Me.txtM3Article.TabIndex = 176
        Me.txtM3Article.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label8.Location = New System.Drawing.Point(11, 194)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 23)
        Me.Label8.TabIndex = 177
        Me.Label8.Text = "M3 Article"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Chocolate
        Me.Label9.Location = New System.Drawing.Point(3, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 21)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = "Cross Status:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbCrossStatus
        '
        Me.CmbCrossStatus.DropDownHeight = 500
        Me.CmbCrossStatus.FormattingEnabled = True
        Me.CmbCrossStatus.IntegralHeight = False
        Me.CmbCrossStatus.Items.AddRange(New Object() {"20", "88", "99" & Global.Microsoft.VisualBasic.ChrW(9)})
        Me.CmbCrossStatus.Location = New System.Drawing.Point(117, 232)
        Me.CmbCrossStatus.Name = "CmbCrossStatus"
        Me.CmbCrossStatus.Size = New System.Drawing.Size(172, 21)
        Me.CmbCrossStatus.Sorted = True
        Me.CmbCrossStatus.TabIndex = 180
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Chocolate
        Me.Label11.Location = New System.Drawing.Point(16, 253)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 19)
        Me.Label11.TabIndex = 181
        Me.Label11.Text = "20 MFR"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Chocolate
        Me.Label12.Location = New System.Drawing.Point(16, 272)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 19)
        Me.Label12.TabIndex = 182
        Me.Label12.Text = "88 Dual Certtification"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Chocolate
        Me.Label13.Location = New System.Drawing.Point(16, 291)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(156, 19)
        Me.Label13.TabIndex = 183
        Me.Label13.Text = "99 Cross Reference"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmPartMasterQuote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 531)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CmbCrossStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtM3Article)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMaxQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMinQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescrCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbApprovedBy)
        Me.Controls.Add(Label23)
        Me.Controls.Add(Me.txtDateApproved)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.CmbCreatedBy)
        Me.Controls.Add(Label18)
        Me.Controls.Add(Me.txtDateIssue)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgRev)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPartMasterQuote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Part Master Form (Short Version)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgRev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents CmbUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPartDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdNew As System.Windows.Forms.Button
    Friend WithEvents CmbPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dgRev As System.Windows.Forms.DataGridView
    Friend WithEvents CmbApprovedBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtDateApproved As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CmbCreatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtDateIssue As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SwFormQTShort As System.Windows.Forms.TextBox
    Friend WithEvents txtDescrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtMinQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMaxQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtM3Article As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PartRevID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDateStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbCrossStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
