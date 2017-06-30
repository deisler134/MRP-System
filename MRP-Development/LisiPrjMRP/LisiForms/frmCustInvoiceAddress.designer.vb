<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCustInvoiceAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustInvoiceAddress))
        Dim Labell33 As System.Windows.Forms.Label
        Me.CmdNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdMod = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmdReset = New System.Windows.Forms.ToolStripButton()
        Me.cmbCountry = New System.Windows.Forms.ComboBox()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtStateProv = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbCust = New System.Windows.Forms.ComboBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.txtShortName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRefCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConsignee = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInvFOB = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAccpacCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtM3CustCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        Labell33 = New System.Windows.Forms.Label()
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CustToolBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustToolBar
        '
        CustToolBar.AddNewItem = Nothing
        CustToolBar.CountItem = Nothing
        CustToolBar.DeleteItem = Nothing
        CustToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmdNew, Me.ToolStripSeparator5, Me.CmdMod, Me.ToolStripSeparator3, Me.CmdReset})
        CustToolBar.Location = New System.Drawing.Point(0, 0)
        CustToolBar.MoveFirstItem = Nothing
        CustToolBar.MoveLastItem = Nothing
        CustToolBar.MoveNextItem = Nothing
        CustToolBar.MovePreviousItem = Nothing
        CustToolBar.Name = "CustToolBar"
        CustToolBar.PositionItem = Nothing
        CustToolBar.Size = New System.Drawing.Size(564, 25)
        CustToolBar.TabIndex = 0
        CustToolBar.Text = "BindingNavigator1"
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
        'CmdReset
        '
        Me.CmdReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(50, 22)
        Me.CmdReset.Text = "  Reset"
        '
        'Labell33
        '
        Labell33.ForeColor = System.Drawing.Color.Blue
        Labell33.Location = New System.Drawing.Point(67, 260)
        Labell33.Name = "Labell33"
        Labell33.Size = New System.Drawing.Size(64, 23)
        Labell33.TabIndex = 126
        Labell33.Text = "Country"
        Labell33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCountry
        '
        Me.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCountry.FormattingEnabled = True
        Me.cmbCountry.Items.AddRange(New Object() {"AUSTRALIA", "BRASIL", "CANADA", "FRANCE", "GERMANY", "INDIA", "ITALY", "SPAIN", "SWEDEN", "TURQUIE", "UK", "USA"})
        Me.cmbCountry.Location = New System.Drawing.Point(197, 262)
        Me.cmbCountry.Name = "cmbCountry"
        Me.cmbCountry.Size = New System.Drawing.Size(232, 21)
        Me.cmbCountry.Sorted = True
        Me.cmbCountry.TabIndex = 9
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(197, 236)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(232, 20)
        Me.txtPostalCode.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(67, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Postal Code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStateProv
        '
        Me.txtStateProv.Location = New System.Drawing.Point(197, 210)
        Me.txtStateProv.Name = "txtStateProv"
        Me.txtStateProv.Size = New System.Drawing.Size(232, 20)
        Me.txtStateProv.TabIndex = 7
        '
        'Label44
        '
        Me.Label44.ForeColor = System.Drawing.Color.Blue
        Me.Label44.Location = New System.Drawing.Point(67, 207)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(96, 23)
        Me.Label44.TabIndex = 124
        Me.Label44.Text = "State/Province"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(197, 184)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(232, 20)
        Me.txtCity.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(67, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "City"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(197, 158)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(232, 20)
        Me.txtAddress.TabIndex = 5
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(197, 132)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(232, 20)
        Me.txtCustName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(67, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Billing Address"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(67, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Customer Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(67, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 23)
        Me.Label10.TabIndex = 112
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
        Me.CmbCust.Location = New System.Drawing.Point(197, 44)
        Me.CmbCust.MaxDropDownItems = 50
        Me.CmbCust.Name = "CmbCust"
        Me.CmbCust.Size = New System.Drawing.Size(232, 23)
        Me.CmbCust.TabIndex = 2
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(354, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 1
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'txtShortName
        '
        Me.txtShortName.Location = New System.Drawing.Point(197, 106)
        Me.txtShortName.Name = "txtShortName"
        Me.txtShortName.Size = New System.Drawing.Size(232, 20)
        Me.txtShortName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(67, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Short Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRefCode
        '
        Me.txtRefCode.Location = New System.Drawing.Point(197, 289)
        Me.txtRefCode.Name = "txtRefCode"
        Me.txtRefCode.Size = New System.Drawing.Size(232, 20)
        Me.txtRefCode.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(67, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Ref. Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConsignee
        '
        Me.txtConsignee.Location = New System.Drawing.Point(197, 341)
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.Size = New System.Drawing.Size(232, 20)
        Me.txtConsignee.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(67, 341)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Consignee IRS No:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInvFOB
        '
        Me.txtInvFOB.Location = New System.Drawing.Point(197, 315)
        Me.txtInvFOB.Name = "txtInvFOB"
        Me.txtInvFOB.Size = New System.Drawing.Size(232, 20)
        Me.txtInvFOB.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(67, 312)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 23)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "F.O.B."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAccpacCode
        '
        Me.txtAccpacCode.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAccpacCode.Location = New System.Drawing.Point(197, 393)
        Me.txtAccpacCode.Name = "txtAccpacCode"
        Me.txtAccpacCode.Size = New System.Drawing.Size(232, 20)
        Me.txtAccpacCode.TabIndex = 136
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(67, 393)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 20)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Accpac Cust. Code"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.ForeColor = System.Drawing.Color.Maroon
        Me.txtTerms.Location = New System.Drawing.Point(197, 367)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(232, 20)
        Me.txtTerms.TabIndex = 138
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(67, 364)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 23)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "Terms:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(435, 106)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 23)
        Me.Label12.TabIndex = 140
        Me.Label12.Text = "Max. 15 Char."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtM3CustCode
        '
        Me.txtM3CustCode.BackColor = System.Drawing.Color.Gainsboro
        Me.txtM3CustCode.Location = New System.Drawing.Point(197, 419)
        Me.txtM3CustCode.Name = "txtM3CustCode"
        Me.txtM3CustCode.Size = New System.Drawing.Size(232, 20)
        Me.txtM3CustCode.TabIndex = 141
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(67, 419)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 20)
        Me.Label13.TabIndex = 142
        Me.Label13.Text = "M3 Cust. Code"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCustInvoiceAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(564, 460)
        Me.Controls.Add(Me.txtM3CustCode)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTerms)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtAccpacCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtInvFOB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtConsignee)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRefCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtShortName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.cmbCountry)
        Me.Controls.Add(Labell33)
        Me.Controls.Add(Me.txtPostalCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStateProv)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtCustName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CmbCust)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmCustInvoiceAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Customer Update Billing Address Form"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CustToolBar.ResumeLayout(False)
        CustToolBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CmdMod As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CmdReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents txtPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStateProv As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents txtShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRefCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConsignee As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInvFOB As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAccpacCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtM3CustCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
