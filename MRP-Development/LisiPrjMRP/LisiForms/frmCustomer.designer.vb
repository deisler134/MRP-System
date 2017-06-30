<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomer))
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
        Me.txtCustShort = New System.Windows.Forms.TextBox()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbCust = New System.Windows.Forms.ComboBox()
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
        Me.CmbCreditInfo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCountry = New System.Windows.Forms.ComboBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.SwForm = New System.Windows.Forms.TextBox()
        Me.dgContact = New System.Windows.Forms.DataGridView()
        Me.ContactID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Post = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtShipVia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtM3CustCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        Labell33 = New System.Windows.Forms.Label()
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CustToolBar.SuspendLayout()
        CType(Me.dgContact, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(744, 25)
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
        Me.CmdCancel.Size = New System.Drawing.Size(50, 22)
        Me.CmdCancel.Text = "  Reset"
        '
        'Labell33
        '
        Labell33.ForeColor = System.Drawing.Color.Blue
        Labell33.Location = New System.Drawing.Point(405, 77)
        Labell33.Name = "Labell33"
        Labell33.Size = New System.Drawing.Size(64, 23)
        Labell33.TabIndex = 110
        Labell33.Text = "Country"
        Labell33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(109, 128)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(232, 20)
        Me.txtAddress.TabIndex = 94
        '
        'txtCustShort
        '
        Me.txtCustShort.Location = New System.Drawing.Point(109, 104)
        Me.txtCustShort.Name = "txtCustShort"
        Me.txtCustShort.Size = New System.Drawing.Size(232, 20)
        Me.txtCustShort.TabIndex = 93
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(109, 80)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(232, 20)
        Me.txtCustName.TabIndex = 92
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(13, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 23)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "ShortCustName"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(13, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Customer Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustID
        '
        Me.txtCustID.Location = New System.Drawing.Point(501, 40)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(100, 20)
        Me.txtCustID.TabIndex = 91
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(13, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 23)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Choose Customer"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbCust
        '
        Me.CmbCust.DropDownHeight = 500
        Me.CmbCust.DropDownWidth = 250
        Me.CmbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCust.ForeColor = System.Drawing.Color.DarkRed
        Me.CmbCust.FormattingEnabled = True
        Me.CmbCust.IntegralHeight = False
        Me.CmbCust.Location = New System.Drawing.Point(109, 40)
        Me.CmbCust.MaxDropDownItems = 50
        Me.CmbCust.Name = "CmbCust"
        Me.CmbCust.Size = New System.Drawing.Size(232, 23)
        Me.CmbCust.TabIndex = 89
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(109, 154)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(232, 20)
        Me.txtCity.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(13, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "City"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(109, 180)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Size = New System.Drawing.Size(232, 20)
        Me.txtRegion.TabIndex = 96
        '
        'Label44
        '
        Me.Label44.ForeColor = System.Drawing.Color.Blue
        Me.Label44.Location = New System.Drawing.Point(13, 180)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 23)
        Me.Label44.TabIndex = 106
        Me.Label44.Text = "Region"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(109, 206)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(232, 20)
        Me.txtPostalCode.TabIndex = 97
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(13, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Postal Code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWeb
        '
        Me.txtWeb.Location = New System.Drawing.Point(501, 103)
        Me.txtWeb.Name = "txtWeb"
        Me.txtWeb.Size = New System.Drawing.Size(232, 20)
        Me.txtWeb.TabIndex = 99
        '
        'labell55
        '
        Me.labell55.ForeColor = System.Drawing.Color.Blue
        Me.labell55.Location = New System.Drawing.Point(405, 103)
        Me.labell55.Name = "labell55"
        Me.labell55.Size = New System.Drawing.Size(90, 23)
        Me.labell55.TabIndex = 112
        Me.labell55.Text = "Web Address"
        Me.labell55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(501, 128)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(232, 69)
        Me.txtNotes.TabIndex = 100
        '
        'Label66
        '
        Me.Label66.ForeColor = System.Drawing.Color.Blue
        Me.Label66.Location = New System.Drawing.Point(405, 128)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(64, 23)
        Me.Label66.TabIndex = 114
        Me.Label66.Text = "Notes"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbCreditInfo
        '
        Me.CmbCreditInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCreditInfo.FormattingEnabled = True
        Me.CmbCreditInfo.Items.AddRange(New Object() {"GC-1   Excellent credit status", "GC-2   Very good credit status", "GC-3   Good credit status", "GC-4   Normal credit status", "GC-5   Ordinary credit status", "GC-6   Poor credit status", "GC-7   Very poor credit status"})
        Me.CmbCreditInfo.Location = New System.Drawing.Point(501, 203)
        Me.CmbCreditInfo.Name = "CmbCreditInfo"
        Me.CmbCreditInfo.Size = New System.Drawing.Size(231, 21)
        Me.CmbCreditInfo.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(405, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Credit Info"
        '
        'cmbCountry
        '
        Me.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"AUSTRALIA", "BRASIL", "CANADA", "FRANCE", "GERMANY", "INDIA", "ITALY", "SPAIN", "SWEDEN", "TURQUIE", "UK", "USA"})
        Me.cmbCountry.Location = New System.Drawing.Point(501, 77)
        Me.cmbCountry.MaxDropDownItems = 20
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(230, 21)
        Me.cmbCountry.Sorted = True
        Me.cmbCountry.TabIndex = 98
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(526, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 117
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'SwForm
        '
        Me.SwForm.Location = New System.Drawing.Point(640, 39)
        Me.SwForm.Name = "SwForm"
        Me.SwForm.Size = New System.Drawing.Size(63, 20)
        Me.SwForm.TabIndex = 126
        Me.SwForm.Visible = False
        '
        'dgContact
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContact.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgContact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContactID, Me.CustomerID, Me.ContactTitle, Me.ContactName, Me.Phone, Me.Post, Me.Fax, Me.Email})
        Me.dgContact.Location = New System.Drawing.Point(11, 346)
        Me.dgContact.Name = "dgContact"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgContact.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgContact.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgContact.RowTemplate.Height = 17
        Me.dgContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgContact.Size = New System.Drawing.Size(721, 225)
        Me.dgContact.TabIndex = 127
        '
        'ContactID
        '
        Me.ContactID.HeaderText = "ContactID"
        Me.ContactID.MinimumWidth = 2
        Me.ContactID.Name = "ContactID"
        Me.ContactID.Visible = False
        Me.ContactID.Width = 2
        '
        'CustomerID
        '
        Me.CustomerID.HeaderText = "CustomerID"
        Me.CustomerID.MinimumWidth = 2
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Visible = False
        Me.CustomerID.Width = 2
        '
        'ContactTitle
        '
        Me.ContactTitle.HeaderText = "Contact Title"
        Me.ContactTitle.Name = "ContactTitle"
        '
        'ContactName
        '
        Me.ContactName.HeaderText = "Contact Name"
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Width = 150
        '
        'Phone
        '
        Me.Phone.HeaderText = "Phone"
        Me.Phone.Name = "Phone"
        '
        'Post
        '
        Me.Post.HeaderText = "Post"
        Me.Post.Name = "Post"
        Me.Post.Width = 70
        '
        'Fax
        '
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.Width = 150
        '
        'txtPer
        '
        Me.txtPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPer.ForeColor = System.Drawing.Color.Maroon
        Me.txtPer.Location = New System.Drawing.Point(109, 261)
        Me.txtPer.Name = "txtPer"
        Me.txtPer.Size = New System.Drawing.Size(232, 26)
        Me.txtPer.TabIndex = 128
        Me.txtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(106, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(244, 17)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Sales Rep. Comission on Percentage (%)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtShipVia
        '
        Me.txtShipVia.Location = New System.Drawing.Point(501, 240)
        Me.txtShipVia.Multiline = True
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(232, 69)
        Me.txtShipVia.TabIndex = 130
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(405, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 23)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Notes Ship Via"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtM3CustCode
        '
        Me.txtM3CustCode.Location = New System.Drawing.Point(109, 293)
        Me.txtM3CustCode.Name = "txtM3CustCode"
        Me.txtM3CustCode.Size = New System.Drawing.Size(232, 20)
        Me.txtM3CustCode.TabIndex = 132
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(13, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 23)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "M3 Cust. Code"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 583)
        Me.Controls.Add(Me.txtM3CustCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtShipVia)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgContact)
        Me.Controls.Add(Me.SwForm)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbCreditInfo)
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
        Me.Controls.Add(Me.txtCustShort)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCustID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CmbCust)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Customers Update Form"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CustToolBar.ResumeLayout(False)
        CustToolBar.PerformLayout()
        CType(Me.dgContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCustShort As System.Windows.Forms.TextBox
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbCust As System.Windows.Forms.ComboBox
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
    Friend WithEvents CmbCreditInfo As System.Windows.Forms.ComboBox
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
    Friend WithEvents ContactID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Post As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtM3CustCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
