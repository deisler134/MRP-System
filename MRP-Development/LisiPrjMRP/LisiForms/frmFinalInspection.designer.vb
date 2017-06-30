<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmFinalInspection
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
        Me.cmbMpo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCOC = New System.Windows.Forms.TextBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtStockLoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMatlLot = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDevise = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbCust = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCustOrder = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAdj = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtInspScrapped = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProdScrapped = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtQtyScrapped = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQtyReleased = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQtyActual = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdMod = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbStType = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbMpoStatus = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CmbClMpo = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRMCost = New System.Windows.Forms.TextBox()
        Me.txtMFRCost = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtProcCost = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtMPOType = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtShortCust = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtStockClass = New System.Windows.Forms.TextBox()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustToolBar
        '
        CustToolBar.AddNewItem = Nothing
        CustToolBar.CountItem = Nothing
        CustToolBar.DeleteItem = Nothing
        CustToolBar.Location = New System.Drawing.Point(0, 0)
        CustToolBar.MoveFirstItem = Nothing
        CustToolBar.MoveLastItem = Nothing
        CustToolBar.MoveNextItem = Nothing
        CustToolBar.MovePreviousItem = Nothing
        CustToolBar.Name = "CustToolBar"
        CustToolBar.PositionItem = Nothing
        CustToolBar.Size = New System.Drawing.Size(1071, 25)
        CustToolBar.TabIndex = 157
        CustToolBar.Text = "BindingNavigator1"
        '
        'cmbMpo
        '
        Me.cmbMpo.ForeColor = System.Drawing.Color.DarkRed
        Me.cmbMpo.FormattingEnabled = True
        Me.cmbMpo.IntegralHeight = False
        Me.cmbMpo.Location = New System.Drawing.Point(147, 52)
        Me.cmbMpo.Name = "cmbMpo"
        Me.cmbMpo.Size = New System.Drawing.Size(167, 21)
        Me.cmbMpo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(30, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mpo Number"
        '
        'txtCOC
        '
        Me.txtCOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOC.Location = New System.Drawing.Point(417, 193)
        Me.txtCOC.Multiline = True
        Me.txtCOC.Name = "txtCOC"
        Me.txtCOC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCOC.Size = New System.Drawing.Size(630, 426)
        Me.txtCOC.TabIndex = 7
        '
        'CmdSave
        '
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(336, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 1
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(371, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "C.O.C"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txtStockLoc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbDept)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtPrice)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtMatlLot)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbDevise)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cmbCust)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtCustOrder)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtAdj)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtWeight)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtInspScrapped)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtProdScrapped)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtQtyScrapped)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtQtyReleased)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtQtyActual)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtPart)
        Me.Panel1.Location = New System.Drawing.Point(12, 194)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 425)
        Me.Panel1.TabIndex = 156
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Maroon
        Me.Label20.Location = New System.Drawing.Point(10, 390)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 13)
        Me.Label20.TabIndex = 183
        Me.Label20.Text = "Stock Location"
        '
        'txtStockLoc
        '
        Me.txtStockLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockLoc.ForeColor = System.Drawing.Color.Maroon
        Me.txtStockLoc.Location = New System.Drawing.Point(133, 387)
        Me.txtStockLoc.Name = "txtStockLoc"
        Me.txtStockLoc.Size = New System.Drawing.Size(150, 20)
        Me.txtStockLoc.TabIndex = 182
        Me.txtStockLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Tag = "epart"
        Me.Label4.Text = "Department"
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(134, 39)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(150, 21)
        Me.cmbDept.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 337)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 179
        Me.Label15.Text = "Sales Price"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(133, 334)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(150, 20)
        Me.txtPrice.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "Matl Lot No."
        '
        'txtMatlLot
        '
        Me.txtMatlLot.Location = New System.Drawing.Point(133, 199)
        Me.txtMatlLot.Name = "txtMatlLot"
        Me.txtMatlLot.Size = New System.Drawing.Size(150, 20)
        Me.txtMatlLot.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 363)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Devise"
        '
        'cmbDevise
        '
        Me.cmbDevise.FormattingEnabled = True
        Me.cmbDevise.Location = New System.Drawing.Point(134, 360)
        Me.cmbDevise.Name = "cmbDevise"
        Me.cmbDevise.Size = New System.Drawing.Size(150, 21)
        Me.cmbDevise.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 310)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Customer"
        '
        'cmbCust
        '
        Me.cmbCust.FormattingEnabled = True
        Me.cmbCust.Location = New System.Drawing.Point(134, 307)
        Me.cmbCust.Name = "cmbCust"
        Me.cmbCust.Size = New System.Drawing.Size(150, 21)
        Me.cmbCust.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 283)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 171
        Me.Label14.Text = "Customer Order"
        '
        'txtCustOrder
        '
        Me.txtCustOrder.Location = New System.Drawing.Point(134, 280)
        Me.txtCustOrder.Name = "txtCustOrder"
        Me.txtCustOrder.Size = New System.Drawing.Size(150, 20)
        Me.txtCustOrder.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 169
        Me.Label13.Text = "Matl Adj."
        '
        'txtAdj
        '
        Me.txtAdj.Location = New System.Drawing.Point(134, 253)
        Me.txtAdj.Name = "txtAdj"
        Me.txtAdj.Size = New System.Drawing.Size(150, 20)
        Me.txtAdj.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 229)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "Matl Weight"
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(134, 226)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(150, 20)
        Me.txtWeight.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 170)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 26)
        Me.Label11.TabIndex = 165
        Me.Label11.Text = "Inspection Qty Scrapped"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInspScrapped
        '
        Me.txtInspScrapped.Location = New System.Drawing.Point(134, 173)
        Me.txtInspScrapped.Name = "txtInspScrapped"
        Me.txtInspScrapped.Size = New System.Drawing.Size(150, 20)
        Me.txtInspScrapped.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 13)
        Me.Label10.TabIndex = 163
        Me.Label10.Text = "Prod. Qty Scrapped"
        '
        'txtProdScrapped
        '
        Me.txtProdScrapped.Location = New System.Drawing.Point(134, 147)
        Me.txtProdScrapped.Name = "txtProdScrapped"
        Me.txtProdScrapped.Size = New System.Drawing.Size(150, 20)
        Me.txtProdScrapped.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "Qty Scrapped"
        '
        'txtQtyScrapped
        '
        Me.txtQtyScrapped.Location = New System.Drawing.Point(134, 120)
        Me.txtQtyScrapped.Name = "txtQtyScrapped"
        Me.txtQtyScrapped.Size = New System.Drawing.Size(150, 20)
        Me.txtQtyScrapped.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "Qty Released"
        '
        'txtQtyReleased
        '
        Me.txtQtyReleased.Location = New System.Drawing.Point(134, 94)
        Me.txtQtyReleased.Name = "txtQtyReleased"
        Me.txtQtyReleased.Size = New System.Drawing.Size(150, 20)
        Me.txtQtyReleased.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 13)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "Actual / Final -- Qty "
        '
        'txtQtyActual
        '
        Me.txtQtyActual.Location = New System.Drawing.Point(134, 68)
        Me.txtQtyActual.Name = "txtQtyActual"
        Me.txtQtyActual.Size = New System.Drawing.Size(150, 20)
        Me.txtQtyActual.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Part Number"
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(134, 13)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(150, 20)
        Me.txtPart.TabIndex = 0
        '
        'cmdReset
        '
        Me.cmdReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(41, 0)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(75, 23)
        Me.cmdReset.TabIndex = 0
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(912, 0)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 3
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdMod
        '
        Me.cmdMod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMod.Location = New System.Drawing.Point(627, 2)
        Me.cmdMod.Name = "cmdMod"
        Me.cmdMod.Size = New System.Drawing.Size(75, 23)
        Me.cmdMod.TabIndex = 2
        Me.cmdMod.Text = "Modify"
        Me.cmdMod.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(30, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 164
        Me.Label18.Tag = "epart"
        Me.Label18.Text = "Type Stock"
        '
        'cmbStType
        '
        Me.cmbStType.FormattingEnabled = True
        Me.cmbStType.Items.AddRange(New Object() {"FP", "SFP"})
        Me.cmbStType.Location = New System.Drawing.Point(147, 79)
        Me.cmbStType.Name = "cmbStType"
        Me.cmbStType.Size = New System.Drawing.Size(167, 21)
        Me.cmbStType.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(554, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 13)
        Me.Label17.TabIndex = 177
        Me.Label17.Text = "Mpo Status"
        '
        'cmbMpoStatus
        '
        Me.cmbMpoStatus.FormattingEnabled = True
        Me.cmbMpoStatus.Location = New System.Drawing.Point(627, 57)
        Me.cmbMpoStatus.Name = "cmbMpoStatus"
        Me.cmbMpoStatus.Size = New System.Drawing.Size(112, 21)
        Me.cmbMpoStatus.TabIndex = 176
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkRed
        Me.Label19.Location = New System.Drawing.Point(753, 111)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 13)
        Me.Label19.TabIndex = 178
        Me.Label19.Text = "Closed Mpo Number"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbClMpo
        '
        Me.CmbClMpo.ForeColor = System.Drawing.Color.DarkRed
        Me.CmbClMpo.FormattingEnabled = True
        Me.CmbClMpo.Location = New System.Drawing.Point(875, 108)
        Me.CmbClMpo.Name = "CmbClMpo"
        Me.CmbClMpo.Size = New System.Drawing.Size(112, 21)
        Me.CmbClMpo.TabIndex = 179
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(554, 90)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 13)
        Me.Label21.TabIndex = 180
        Me.Label21.Text = "RM Cost:"
        '
        'txtRMCost
        '
        Me.txtRMCost.Location = New System.Drawing.Point(627, 84)
        Me.txtRMCost.Name = "txtRMCost"
        Me.txtRMCost.Size = New System.Drawing.Size(112, 20)
        Me.txtRMCost.TabIndex = 181
        '
        'txtMFRCost
        '
        Me.txtMFRCost.Location = New System.Drawing.Point(627, 110)
        Me.txtMFRCost.Name = "txtMFRCost"
        Me.txtMFRCost.Size = New System.Drawing.Size(112, 20)
        Me.txtMFRCost.TabIndex = 183
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(554, 115)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 182
        Me.Label22.Text = "MFR Cost:"
        '
        'txtProcCost
        '
        Me.txtProcCost.Location = New System.Drawing.Point(627, 136)
        Me.txtProcCost.Name = "txtProcCost"
        Me.txtProcCost.Size = New System.Drawing.Size(112, 20)
        Me.txtProcCost.TabIndex = 185
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(554, 137)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 13)
        Me.Label23.TabIndex = 184
        Me.Label23.Text = "Proc. Cost:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(30, 113)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 13)
        Me.Label24.TabIndex = 187
        Me.Label24.Text = "MPO Type"
        '
        'txtMPOType
        '
        Me.txtMPOType.Location = New System.Drawing.Point(147, 108)
        Me.txtMPOType.Name = "txtMPOType"
        Me.txtMPOType.Size = New System.Drawing.Size(167, 20)
        Me.txtMPOType.TabIndex = 186
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(29, 139)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 13)
        Me.Label25.TabIndex = 189
        Me.Label25.Text = "Cust. Type"
        '
        'txtShortCust
        '
        Me.txtShortCust.Location = New System.Drawing.Point(146, 134)
        Me.txtShortCust.Name = "txtShortCust"
        Me.txtShortCust.Size = New System.Drawing.Size(167, 20)
        Me.txtShortCust.TabIndex = 188
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(421, 90)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(113, 13)
        Me.Label26.TabIndex = 191
        Me.Label26.Text = "Stock Clasification"
        '
        'txtStockClass
        '
        Me.txtStockClass.Location = New System.Drawing.Point(414, 113)
        Me.txtStockClass.Name = "txtStockClass"
        Me.txtStockClass.Size = New System.Drawing.Size(120, 20)
        Me.txtStockClass.TabIndex = 190
        Me.txtStockClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmFinalInspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 650)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtStockClass)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtShortCust)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtMPOType)
        Me.Controls.Add(Me.txtProcCost)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtMFRCost)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtRMCost)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.CmbClMpo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmbMpoStatus)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmbStType)
        Me.Controls.Add(Me.cmdMod)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.txtCOC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMpo)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmFinalInspection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "D"
        Me.Text = "Lisi Aerospace Canada  -  MPO Final Inspection"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMpo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCOC As System.Windows.Forms.TextBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDevise As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCustOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAdj As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtInspScrapped As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProdScrapped As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtQtyScrapped As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyReleased As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQtyActual As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMatlLot As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdMod As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbStType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbMpoStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CmbClMpo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtStockLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtProcCost As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtMFRCost As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtRMCost As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtMPOType As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtShortCust As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtStockClass As System.Windows.Forms.TextBox
End Class
