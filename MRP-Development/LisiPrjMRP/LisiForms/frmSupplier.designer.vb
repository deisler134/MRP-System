<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSupplier
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
        Me.components = New System.ComponentModel.Container()
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplier))
        Dim Labell33 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.CmdCut = New System.Windows.Forms.ToolStripButton()
        Me.CmdCopy = New System.Windows.Forms.ToolStripButton()
        Me.CmdPaste = New System.Windows.Forms.ToolStripButton()
        Me.CmdUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdMod = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdCancel = New System.Windows.Forms.ToolStripButton()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtSuppName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSuppID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbSupp = New System.Windows.Forms.ComboBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWeb = New System.Windows.Forms.TextBox()
        Me.labell55 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.CmbSuppType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCountry = New System.Windows.Forms.ComboBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.SwForm = New System.Windows.Forms.TextBox()
        Me.dgContact = New System.Windows.Forms.DataGridView()
        Me.SuppContactID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Post = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtStandCalif = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRating = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLeadTime = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PlMainGroup = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdLocate = New System.Windows.Forms.Button()
        Me.txtUpdateDate = New System.Windows.Forms.TextBox()
        Me.ChkMill = New System.Windows.Forms.CheckBox()
        Me.ChkDistr = New System.Windows.Forms.CheckBox()
        Me.ChkRedraw = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CmbGroup = New System.Windows.Forms.ComboBox()
        Me.CmbAuditBy = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Rd36 = New System.Windows.Forms.RadioButton()
        Me.Rd18 = New System.Windows.Forms.RadioButton()
        Me.Rd12 = New System.Windows.Forms.RadioButton()
        Me.CmbSuppStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbSuppExpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbSuppDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PLM3Code = New System.Windows.Forms.Panel()
        Me.txtSuppM3Code = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        Labell33 = New System.Windows.Forms.Label()
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CustToolBar.SuspendLayout()
        CType(Me.dgContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlMainGroup.SuspendLayout()
        Me.PLM3Code.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustToolBar
        '
        CustToolBar.AddNewItem = Nothing
        CustToolBar.CountItem = Nothing
        CustToolBar.DeleteItem = Me.CmdDelete
        CustToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdCut, Me.CmdCopy, Me.CmdPaste, Me.CmdUndo, Me.ToolStripSeparator1, Me.CmdNew, Me.ToolStripSeparator5, Me.CmdDelete, Me.ToolStripSeparator4, Me.CmdMod, Me.ToolStripSeparator3, Me.CmdCancel})
        CustToolBar.Location = New System.Drawing.Point(0, 0)
        CustToolBar.MoveFirstItem = Nothing
        CustToolBar.MoveLastItem = Nothing
        CustToolBar.MoveNextItem = Nothing
        CustToolBar.MovePreviousItem = Nothing
        CustToolBar.Name = "CustToolBar"
        CustToolBar.PositionItem = Nothing
        CustToolBar.Size = New System.Drawing.Size(1383, 25)
        CustToolBar.TabIndex = 63
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdDelete
        '
        Me.CmdDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdDelete.Image = CType(resources.GetObject("CmdDelete.Image"), System.Drawing.Image)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(64, 22)
        Me.CmdDelete.Text = "Delete"
        '
        'CmdCut
        '
        Me.CmdCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdCut.Image = CType(resources.GetObject("CmdCut.Image"), System.Drawing.Image)
        Me.CmdCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdCut.Name = "CmdCut"
        Me.CmdCut.Size = New System.Drawing.Size(23, 22)
        Me.CmdCut.Text = "C&ut"
        '
        'CmdCopy
        '
        Me.CmdCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdCopy.Image = CType(resources.GetObject("CmdCopy.Image"), System.Drawing.Image)
        Me.CmdCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdCopy.Name = "CmdCopy"
        Me.CmdCopy.Size = New System.Drawing.Size(23, 22)
        Me.CmdCopy.Text = "&Copy"
        '
        'CmdPaste
        '
        Me.CmdPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdPaste.Image = CType(resources.GetObject("CmdPaste.Image"), System.Drawing.Image)
        Me.CmdPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdPaste.Name = "CmdPaste"
        Me.CmdPaste.Size = New System.Drawing.Size(23, 22)
        Me.CmdPaste.Text = "&Paste"
        '
        'CmdUndo
        '
        Me.CmdUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CmdUndo.Image = CType(resources.GetObject("CmdUndo.Image"), System.Drawing.Image)
        Me.CmdUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdUndo.Name = "CmdUndo"
        Me.CmdUndo.Size = New System.Drawing.Size(23, 22)
        Me.CmdUndo.Text = "&Undo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CmdNew
        '
        Me.CmdNew.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdNew.Image = CType(resources.GetObject("CmdNew.Image"), System.Drawing.Image)
        Me.CmdNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(50, 22)
        Me.CmdNew.Text = "New"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'CmdMod
        '
        Me.CmdMod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdMod.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdMod.Name = "CmdMod"
        Me.CmdMod.Size = New System.Drawing.Size(49, 22)
        Me.CmdMod.Text = "Modify"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'CmdCancel
        '
        Me.CmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(47, 22)
        Me.CmdCancel.Text = " Reset"
        '
        'Labell33
        '
        Labell33.ForeColor = System.Drawing.Color.Blue
        Labell33.Location = New System.Drawing.Point(19, 209)
        Labell33.Name = "Labell33"
        Labell33.Size = New System.Drawing.Size(64, 23)
        Labell33.TabIndex = 110
        Labell33.Text = "Country"
        Labell33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(115, 103)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(232, 20)
        Me.txtAddress.TabIndex = 92
        '
        'txtSuppName
        '
        Me.txtSuppName.Location = New System.Drawing.Point(115, 77)
        Me.txtSuppName.Name = "txtSuppName"
        Me.txtSuppName.Size = New System.Drawing.Size(232, 20)
        Me.txtSuppName.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(19, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(19, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Supplier Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSuppID
        '
        Me.txtSuppID.BackColor = System.Drawing.Color.DarkRed
        Me.txtSuppID.Location = New System.Drawing.Point(567, 0)
        Me.txtSuppID.Name = "txtSuppID"
        Me.txtSuppID.Size = New System.Drawing.Size(56, 20)
        Me.txtSuppID.TabIndex = 90
        Me.txtSuppID.Visible = False
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(19, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 23)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Choose Supplier"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSupp
        '
        Me.CmbSupp.DropDownHeight = 500
        Me.CmbSupp.DropDownWidth = 400
        Me.CmbSupp.Font = New System.Drawing.Font("Arial Unicode MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSupp.ForeColor = System.Drawing.Color.DarkRed
        Me.CmbSupp.FormattingEnabled = True
        Me.CmbSupp.IntegralHeight = False
        Me.CmbSupp.Location = New System.Drawing.Point(115, 37)
        Me.CmbSupp.MaxDropDownItems = 30
        Me.CmbSupp.Name = "CmbSupp"
        Me.CmbSupp.Size = New System.Drawing.Size(232, 24)
        Me.CmbSupp.TabIndex = 89
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(115, 129)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(232, 20)
        Me.txtCity.TabIndex = 93
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(19, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "City"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(115, 155)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(232, 20)
        Me.txtRegion.TabIndex = 94
        '
        'Label44
        '
        Me.Label44.ForeColor = System.Drawing.Color.Blue
        Me.Label44.Location = New System.Drawing.Point(19, 155)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 23)
        Me.Label44.TabIndex = 106
        Me.Label44.Text = "Region"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(115, 181)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(232, 20)
        Me.txtPostalCode.TabIndex = 95
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(19, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Postal Code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWeb
        '
        Me.txtWeb.Location = New System.Drawing.Point(115, 235)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(232, 20)
        Me.txtWeb.TabIndex = 98
        '
        'labell55
        '
        Me.labell55.ForeColor = System.Drawing.Color.Blue
        Me.labell55.Location = New System.Drawing.Point(19, 235)
        Me.labell55.Name = "labell55"
        Me.labell55.Size = New System.Drawing.Size(90, 23)
        Me.labell55.TabIndex = 112
        Me.labell55.Text = "Web Address"
        Me.labell55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(859, 387)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(512, 92)
        Me.txtNotes.TabIndex = 99
        '
        'Label66
        '
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Blue
        Me.Label66.Location = New System.Drawing.Point(860, 361)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(37, 23)
        Me.Label66.TabIndex = 114
        Me.Label66.Text = "Notes"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSuppType
        '
        Me.CmbSuppType.BackColor = System.Drawing.Color.DarkRed
        Me.CmbSuppType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSuppType.ForeColor = System.Drawing.Color.Black
        Me.CmbSuppType.FormattingEnabled = True
        Me.CmbSuppType.Items.AddRange(New Object() {"Machining", "Maintenance", "Material", "Office", "Other", "Plating/Heat Tr.", "Tooling"})
        Me.CmbSuppType.Location = New System.Drawing.Point(792, 0)
        Me.CmbSuppType.Name = "CmbSuppType"
        Me.CmbSuppType.Size = New System.Drawing.Size(104, 21)
        Me.CmbSuppType.TabIndex = 96
        Me.CmbSuppType.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Maroon
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(698, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Type Supplier"
        Me.Label7.Visible = False
        '
        'cmbCountry
        '
        Me.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"AUSTRALIA", "CANADA", "FRANCE", "GREAT BRITAIN", "SPAIN", "USA"})
        Me.cmbCountry.Location = New System.Drawing.Point(115, 209)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(232, 21)
        Me.cmbCountry.Sorted = True
        Me.cmbCountry.TabIndex = 97
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(456, 1)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 117
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'SwForm
        '
        Me.SwForm.BackColor = System.Drawing.Color.DarkRed
        Me.SwForm.Location = New System.Drawing.Point(629, 0)
        Me.SwForm.Name = "SwForm"
        Me.SwForm.Size = New System.Drawing.Size(63, 20)
        Me.SwForm.TabIndex = 125
        Me.SwForm.Visible = False
        '
        'dgContact
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgContact.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContact.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContact.ColumnHeadersHeight = 20
        Me.dgContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgContact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SuppContactID, Me.SupplierID, Me.ContactTitle, Me.ContactName, Me.Phone, Me.Post, Me.Fax, Me.Email})
        Me.dgContact.Location = New System.Drawing.Point(22, 264)
        Me.dgContact.Name = "dgContact"
        Me.dgContact.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgContact.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgContact.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgContact.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgContact.RowTemplate.Height = 18
        Me.dgContact.Size = New System.Drawing.Size(831, 426)
        Me.dgContact.TabIndex = 126
        Me.dgContact.Text = "DataGridView1"
        '
        'SuppContactID
        '
        Me.SuppContactID.HeaderText = "SuppContactID"
        Me.SuppContactID.MinimumWidth = 2
        Me.SuppContactID.Name = "SuppContactID"
        Me.SuppContactID.Visible = False
        Me.SuppContactID.Width = 2
        '
        'SupplierID
        '
        Me.SupplierID.HeaderText = "SupplierID"
        Me.SupplierID.MinimumWidth = 2
        Me.SupplierID.Name = "SupplierID"
        Me.SupplierID.Visible = False
        Me.SupplierID.Width = 2
        '
        'ContactTitle
        '
        Me.ContactTitle.HeaderText = "Contact Title"
        Me.ContactTitle.Name = "ContactTitle"
        Me.ContactTitle.Width = 120
        '
        'ContactName
        '
        Me.ContactName.HeaderText = "Contact Name"
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Width = 120
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone"
        Me.Phone.Name = "Phone"
        Me.Phone.Width = 130
        '
        'Post
        '
        Me.Post.HeaderText = "Post"
        Me.Post.Name = "Post"
        Me.Post.Width = 50
        '
        'Fax
        '
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.Width = 120
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.Width = 220
        '
        'txtStandCalif
        '
        Me.txtStandCalif.Location = New System.Drawing.Point(860, 519)
        Me.txtStandCalif.Multiline = True
        Me.txtStandCalif.Name = "txtStandCalif"
        Me.txtStandCalif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStandCalif.Size = New System.Drawing.Size(511, 171)
        Me.txtStandCalif.TabIndex = 140
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(860, 493)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 23)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Standard Certification"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRating
        '
        Me.txtRating.Location = New System.Drawing.Point(339, 189)
        Me.txtRating.Name = "txtRating"
        Me.txtRating.Size = New System.Drawing.Size(81, 20)
        Me.txtRating.TabIndex = 142
        Me.txtRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(238, 193)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 143
        Me.Label11.Text = "Rating"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(426, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 13)
        Me.Label12.TabIndex = 144
        Me.Label12.Text = "%"
        '
        'txtLeadTime
        '
        Me.txtLeadTime.Location = New System.Drawing.Point(339, 158)
        Me.txtLeadTime.Name = "txtLeadTime"
        Me.txtLeadTime.Size = New System.Drawing.Size(81, 20)
        Me.txtLeadTime.TabIndex = 145
        Me.txtLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(238, 157)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.TabIndex = 146
        Me.Label13.Text = "Supplier Lead Time"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(426, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 20)
        Me.Label14.TabIndex = 147
        Me.Label14.Text = "Day(s)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PlMainGroup
        '
        Me.PlMainGroup.Controls.Add(Me.Button1)
        Me.PlMainGroup.Controls.Add(Me.CmdLocate)
        Me.PlMainGroup.Controls.Add(Me.txtUpdateDate)
        Me.PlMainGroup.Controls.Add(Me.ChkMill)
        Me.PlMainGroup.Controls.Add(Me.Label14)
        Me.PlMainGroup.Controls.Add(Me.ChkDistr)
        Me.PlMainGroup.Controls.Add(Me.txtLeadTime)
        Me.PlMainGroup.Controls.Add(Me.Label13)
        Me.PlMainGroup.Controls.Add(Me.ChkRedraw)
        Me.PlMainGroup.Controls.Add(Me.Label16)
        Me.PlMainGroup.Controls.Add(Me.Label12)
        Me.PlMainGroup.Controls.Add(Me.Label18)
        Me.PlMainGroup.Controls.Add(Me.Label11)
        Me.PlMainGroup.Controls.Add(Me.CmbGroup)
        Me.PlMainGroup.Controls.Add(Me.txtRating)
        Me.PlMainGroup.Controls.Add(Me.CmbAuditBy)
        Me.PlMainGroup.Controls.Add(Me.Label17)
        Me.PlMainGroup.Controls.Add(Me.Label15)
        Me.PlMainGroup.Controls.Add(Me.Rd36)
        Me.PlMainGroup.Controls.Add(Me.Rd18)
        Me.PlMainGroup.Controls.Add(Me.Rd12)
        Me.PlMainGroup.Controls.Add(Me.CmbSuppStatus)
        Me.PlMainGroup.Controls.Add(Me.Label8)
        Me.PlMainGroup.Controls.Add(Me.CmbSuppExpDate)
        Me.PlMainGroup.Controls.Add(Me.Label6)
        Me.PlMainGroup.Location = New System.Drawing.Point(362, 37)
        Me.PlMainGroup.Name = "PlMainGroup"
        Me.PlMainGroup.Size = New System.Drawing.Size(1009, 221)
        Me.PlMainGroup.TabIndex = 166
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Orange
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(533, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(174, 23)
        Me.Button1.TabIndex = 182
        Me.Button1.Text = "Take Last Date Updated"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CmdLocate
        '
        Me.CmdLocate.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdLocate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLocate.Location = New System.Drawing.Point(832, 30)
        Me.CmdLocate.Name = "CmdLocate"
        Me.CmdLocate.Size = New System.Drawing.Size(174, 23)
        Me.CmdLocate.TabIndex = 180
        Me.CmdLocate.Text = "ASL Validated Documents"
        Me.CmdLocate.UseVisualStyleBackColor = False
        '
        'txtUpdateDate
        '
        Me.txtUpdateDate.Location = New System.Drawing.Point(533, 130)
        Me.txtUpdateDate.Multiline = True
        Me.txtUpdateDate.Name = "txtUpdateDate"
        Me.txtUpdateDate.ReadOnly = True
        Me.txtUpdateDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUpdateDate.Size = New System.Drawing.Size(473, 80)
        Me.txtUpdateDate.TabIndex = 180
        '
        'ChkMill
        '
        Me.ChkMill.AutoSize = True
        Me.ChkMill.ForeColor = System.Drawing.Color.DarkRed
        Me.ChkMill.Location = New System.Drawing.Point(164, 191)
        Me.ChkMill.Name = "ChkMill"
        Me.ChkMill.Size = New System.Drawing.Size(41, 17)
        Me.ChkMill.TabIndex = 179
        Me.ChkMill.Text = "Mill"
        Me.ChkMill.UseVisualStyleBackColor = True
        '
        'ChkDistr
        '
        Me.ChkDistr.AutoSize = True
        Me.ChkDistr.ForeColor = System.Drawing.Color.DarkRed
        Me.ChkDistr.Location = New System.Drawing.Point(13, 191)
        Me.ChkDistr.Name = "ChkDistr"
        Me.ChkDistr.Size = New System.Drawing.Size(71, 17)
        Me.ChkDistr.TabIndex = 178
        Me.ChkDistr.Text = "Distrbutor"
        Me.ChkDistr.UseVisualStyleBackColor = True
        '
        'ChkRedraw
        '
        Me.ChkRedraw.AutoSize = True
        Me.ChkRedraw.ForeColor = System.Drawing.Color.DarkRed
        Me.ChkRedraw.Location = New System.Drawing.Point(95, 191)
        Me.ChkRedraw.Name = "ChkRedraw"
        Me.ChkRedraw.Size = New System.Drawing.Size(63, 17)
        Me.ChkRedraw.TabIndex = 177
        Me.ChkRedraw.Text = "Redraw"
        Me.ChkRedraw.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkRed
        Me.Label16.Location = New System.Drawing.Point(10, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(180, 23)
        Me.Label16.TabIndex = 176
        Me.Label16.Text = "Approved Material Source"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkRed
        Me.Label18.Location = New System.Drawing.Point(10, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 23)
        Me.Label18.TabIndex = 175
        Me.Label18.Text = "Supplier Group:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbGroup
        '
        Me.CmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGroup.FormattingEnabled = True
        Me.CmbGroup.Items.AddRange(New Object() {"Approved", "Restricted", "InActive", "Not Audited", "Disqualified", "Under Observation", "Suspended"})
        Me.CmbGroup.Location = New System.Drawing.Point(12, 101)
        Me.CmbGroup.Name = "CmbGroup"
        Me.CmbGroup.Size = New System.Drawing.Size(450, 21)
        Me.CmbGroup.TabIndex = 174
        '
        'CmbAuditBy
        '
        Me.CmbAuditBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAuditBy.FormattingEnabled = True
        Me.CmbAuditBy.Items.AddRange(New Object() {"Corporate / Other Plant", "LAC", " "})
        Me.CmbAuditBy.Location = New System.Drawing.Point(629, 32)
        Me.CmbAuditBy.Name = "CmbAuditBy"
        Me.CmbAuditBy.Size = New System.Drawing.Size(160, 21)
        Me.CmbAuditBy.TabIndex = 173
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(665, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 23)
        Me.Label17.TabIndex = 172
        Me.Label17.Text = "Audit By:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(446, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 23)
        Me.Label15.TabIndex = 171
        Me.Label15.Text = "Audit Frequency:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Rd36
        '
        Me.Rd36.AutoSize = True
        Me.Rd36.Location = New System.Drawing.Point(533, 36)
        Me.Rd36.Name = "Rd36"
        Me.Rd36.Size = New System.Drawing.Size(75, 17)
        Me.Rd36.TabIndex = 170
        Me.Rd36.TabStop = True
        Me.Rd36.Text = "36 Months"
        Me.Rd36.UseVisualStyleBackColor = True
        '
        'Rd18
        '
        Me.Rd18.AutoSize = True
        Me.Rd18.Location = New System.Drawing.Point(452, 36)
        Me.Rd18.Name = "Rd18"
        Me.Rd18.Size = New System.Drawing.Size(75, 17)
        Me.Rd18.TabIndex = 169
        Me.Rd18.TabStop = True
        Me.Rd18.Text = "18 Months"
        Me.Rd18.UseVisualStyleBackColor = True
        '
        'Rd12
        '
        Me.Rd12.AutoSize = True
        Me.Rd12.Location = New System.Drawing.Point(371, 36)
        Me.Rd12.Name = "Rd12"
        Me.Rd12.Size = New System.Drawing.Size(75, 17)
        Me.Rd12.TabIndex = 168
        Me.Rd12.TabStop = True
        Me.Rd12.Text = "12 Months"
        Me.Rd12.UseVisualStyleBackColor = True
        '
        'CmbSuppStatus
        '
        Me.CmbSuppStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSuppStatus.FormattingEnabled = True
        Me.CmbSuppStatus.Items.AddRange(New Object() {"Approved", "Conditional", "Disapproved", "InActive", "Suspended", "Temporary"})
        Me.CmbSuppStatus.Location = New System.Drawing.Point(10, 36)
        Me.CmbSuppStatus.Name = "CmbSuppStatus"
        Me.CmbSuppStatus.Size = New System.Drawing.Size(127, 21)
        Me.CmbSuppStatus.Sorted = True
        Me.CmbSuppStatus.TabIndex = 167
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(185, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 166
        Me.Label8.Text = "Next Audit Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbSuppExpDate
        '
        Me.CmbSuppExpDate.Location = New System.Drawing.Point(161, 36)
        Me.CmbSuppExpDate.Name = "CmbSuppExpDate"
        Me.CmbSuppExpDate.Size = New System.Drawing.Size(192, 20)
        Me.CmbSuppExpDate.TabIndex = 165
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(43, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 23)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "Supplier Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbSuppDate
        '
        Me.CmbSuppDate.Location = New System.Drawing.Point(1194, 5)
        Me.CmbSuppDate.Name = "CmbSuppDate"
        Me.CmbSuppDate.ReadOnly = True
        Me.CmbSuppDate.Size = New System.Drawing.Size(174, 20)
        Me.CmbSuppDate.TabIndex = 167
        Me.CmbSuppDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(1109, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 23)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Supplier Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PLM3Code
        '
        Me.PLM3Code.Controls.Add(Me.txtSuppM3Code)
        Me.PLM3Code.Controls.Add(Me.Label19)
        Me.PLM3Code.Location = New System.Drawing.Point(859, 264)
        Me.PLM3Code.Name = "PLM3Code"
        Me.PLM3Code.Size = New System.Drawing.Size(511, 94)
        Me.PLM3Code.TabIndex = 174
        '
        'txtSuppM3Code
        '
        Me.txtSuppM3Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuppM3Code.Location = New System.Drawing.Point(115, 53)
        Me.txtSuppM3Code.Name = "txtSuppM3Code"
        Me.txtSuppM3Code.Size = New System.Drawing.Size(232, 29)
        Me.txtSuppM3Code.TabIndex = 95
        Me.txtSuppM3Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(150, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(142, 23)
        Me.Label19.TabIndex = 96
        Me.Label19.Text = "Supplier M3 Code"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1383, 698)
        Me.Controls.Add(Me.PLM3Code)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbSuppDate)
        Me.Controls.Add(Me.PlMainGroup)
        Me.Controls.Add(Me.txtStandCalif)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgContact)
        Me.Controls.Add(Me.SwForm)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbSuppType)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.txtWeb)
        Me.Controls.Add(Me.labell55)
        Me.Controls.Add(Labell33)
        Me.Controls.Add(Me.txtPostalCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRegion)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtSuppName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSuppID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CmbSupp)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -   Suppliers Update Form"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CustToolBar.ResumeLayout(False)
        CustToolBar.PerformLayout()
        CType(Me.dgContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlMainGroup.ResumeLayout(False)
        Me.PlMainGroup.PerformLayout()
        Me.PLM3Code.ResumeLayout(False)
        Me.PLM3Code.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSuppName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSuppID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbSupp As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CmdMod As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRegion As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWeb As System.Windows.Forms.TextBox
    Friend WithEvents labell55 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents CmbSuppType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents SwForm As System.Windows.Forms.TextBox
    Friend WithEvents dgContact As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtStandCalif As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRating As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLeadTime As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SuppContactID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Post As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlMainGroup As System.Windows.Forms.Panel
    Friend WithEvents ChkMill As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDistr As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRedraw As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents CmbAuditBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Rd36 As System.Windows.Forms.RadioButton
    Friend WithEvents Rd18 As System.Windows.Forms.RadioButton
    Friend WithEvents Rd12 As System.Windows.Forms.RadioButton
    Friend WithEvents CmbSuppStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CmbSuppExpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdLocate As System.Windows.Forms.Button
    Friend WithEvents txtUpdateDate As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmbSuppDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PLM3Code As System.Windows.Forms.Panel
    Friend WithEvents txtSuppM3Code As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
