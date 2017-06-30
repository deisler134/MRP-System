<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStQuoteAnalyze
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.CmbSelCust = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.dgQuote = New System.Windows.Forms.DataGridView
        Me.CmdExport = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtQuote = New System.Windows.Forms.TextBox
        Me.CmbItemStatus = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDueDate = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RdNoBid = New System.Windows.Forms.RadioButton
        Me.RdFollowup = New System.Windows.Forms.RadioButton
        Me.RdAll = New System.Windows.Forms.RadioButton
        Me.QNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QFollow = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QDueDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QContract = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QQtyContract = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QCustRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QDetLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DocNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QPartName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QRev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QLineStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QContractSw = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QQuotedPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QEstPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QMargin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QDevise = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QLeadTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QExpLead = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QExpValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QPartNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QLACNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QRawMaterial = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QTooling = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.QCustID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgQuote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(329, 8)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(88, 20)
        Me.txtDateFrom.TabIndex = 6
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbSelCust
        '
        Me.CmbSelCust.DropDownHeight = 600
        Me.CmbSelCust.DropDownWidth = 200
        Me.CmbSelCust.FormattingEnabled = True
        Me.CmbSelCust.IntegralHeight = False
        Me.CmbSelCust.Location = New System.Drawing.Point(555, 34)
        Me.CmbSelCust.Name = "CmbSelCust"
        Me.CmbSelCust.Size = New System.Drawing.Size(98, 21)
        Me.CmbSelCust.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(457, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Customer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(457, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Part No."
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(555, 8)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(98, 20)
        Me.txtPart.TabIndex = 20
        Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgQuote
        '
        Me.dgQuote.AllowUserToAddRows = False
        Me.dgQuote.AllowUserToDeleteRows = False
        Me.dgQuote.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgQuote.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgQuote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgQuote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgQuote.ColumnHeadersHeight = 45
        Me.dgQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgQuote.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QNo, Me.QDate, Me.QFollow, Me.QDueDate, Me.QContract, Me.QQtyContract, Me.CustomerShort, Me.QCustRefNo, Me.ContactName, Me.EmpName, Me.QDetLine, Me.PartNumber, Me.DocNo, Me.SourceName, Me.QPartName, Me.QRev, Me.QLineStatus, Me.QContractSw, Me.QQty, Me.QQuotedPrice, Me.QEstPrice, Me.QMargin, Me.QDevise, Me.QLeadTime, Me.QExpLead, Me.QExpValue, Me.QPartNotes, Me.QLACNotes, Me.QRawMaterial, Me.QTooling, Me.QCustID})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQuote.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgQuote.Location = New System.Drawing.Point(2, 96)
        Me.dgQuote.Name = "dgQuote"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgQuote.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgQuote.RowHeadersWidth = 25
        Me.dgQuote.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgQuote.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgQuote.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgQuote.RowTemplate.Height = 18
        Me.dgQuote.Size = New System.Drawing.Size(1098, 621)
        Me.dgQuote.TabIndex = 24
        Me.dgQuote.Text = "DataGridView1"
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(1026, 25)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 25
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Date To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(329, 34)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(88, 20)
        Me.txtDateTo.TabIndex = 26
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(898, 62)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(93, 21)
        Me.CmdSearch.TabIndex = 32
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(898, 9)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(93, 21)
        Me.CmdClear.TabIndex = 33
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(702, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Quote#"
        '
        'txtQuote
        '
        Me.txtQuote.Location = New System.Drawing.Point(751, 35)
        Me.txtQuote.Name = "txtQuote"
        Me.txtQuote.Size = New System.Drawing.Size(98, 20)
        Me.txtQuote.TabIndex = 34
        Me.txtQuote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbItemStatus
        '
        Me.CmbItemStatus.DropDownHeight = 600
        Me.CmbItemStatus.DropDownWidth = 200
        Me.CmbItemStatus.FormattingEnabled = True
        Me.CmbItemStatus.IntegralHeight = False
        Me.CmbItemStatus.Items.AddRange(New Object() {"40", "60", "80", "90"})
        Me.CmbItemStatus.Location = New System.Drawing.Point(555, 60)
        Me.CmbItemStatus.Name = "CmbItemStatus"
        Me.CmbItemStatus.Size = New System.Drawing.Size(98, 21)
        Me.CmbItemStatus.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(457, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Quote Item Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Due Date (mm/dd/yyyy)"
        '
        'txtDueDate
        '
        Me.txtDueDate.Location = New System.Drawing.Point(329, 60)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Size = New System.Drawing.Size(88, 20)
        Me.txtDueDate.TabIndex = 38
        Me.txtDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.RdNoBid)
        Me.Panel1.Controls.Add(Me.RdFollowup)
        Me.Panel1.Controls.Add(Me.RdAll)
        Me.Panel1.Location = New System.Drawing.Point(12, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(109, 81)
        Me.Panel1.TabIndex = 40
        '
        'RdNoBid
        '
        Me.RdNoBid.AutoSize = True
        Me.RdNoBid.Location = New System.Drawing.Point(24, 55)
        Me.RdNoBid.Name = "RdNoBid"
        Me.RdNoBid.Size = New System.Drawing.Size(62, 17)
        Me.RdNoBid.TabIndex = 34
        Me.RdNoBid.Text = "NO BID"
        '
        'RdFollowup
        '
        Me.RdFollowup.AutoSize = True
        Me.RdFollowup.Location = New System.Drawing.Point(24, 32)
        Me.RdFollowup.Name = "RdFollowup"
        Me.RdFollowup.Size = New System.Drawing.Size(72, 17)
        Me.RdFollowup.TabIndex = 33
        Me.RdFollowup.Text = "Follow-Up"
        '
        'RdAll
        '
        Me.RdAll.AutoSize = True
        Me.RdAll.Checked = True
        Me.RdAll.Location = New System.Drawing.Point(24, 9)
        Me.RdAll.Name = "RdAll"
        Me.RdAll.Size = New System.Drawing.Size(73, 17)
        Me.RdAll.TabIndex = 32
        Me.RdAll.TabStop = True
        Me.RdAll.Text = "All Quotes"
        '
        'QNo
        '
        Me.QNo.HeaderText = "Quote No."
        Me.QNo.Name = "QNo"
        Me.QNo.Width = 60
        '
        'QDate
        '
        Me.QDate.HeaderText = "Quote Date"
        Me.QDate.Name = "QDate"
        Me.QDate.Width = 60
        '
        'QFollow
        '
        Me.QFollow.HeaderText = "Quote Follow-Up "
        Me.QFollow.Name = "QFollow"
        Me.QFollow.Width = 50
        '
        'QDueDate
        '
        Me.QDueDate.HeaderText = "Due Date"
        Me.QDueDate.Name = "QDueDate"
        Me.QDueDate.Width = 60
        '
        'QContract
        '
        Me.QContract.HeaderText = "Contract"
        Me.QContract.Name = "QContract"
        Me.QContract.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.QContract.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.QContract.Width = 50
        '
        'QQtyContract
        '
        Me.QQtyContract.HeaderText = "Contract Qty"
        Me.QQtyContract.Name = "QQtyContract"
        Me.QQtyContract.Width = 60
        '
        'CustomerShort
        '
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 60
        '
        'QCustRefNo
        '
        Me.QCustRefNo.HeaderText = "Cust. Ref. No."
        Me.QCustRefNo.Name = "QCustRefNo"
        Me.QCustRefNo.Width = 60
        '
        'ContactName
        '
        Me.ContactName.HeaderText = "Buyer"
        Me.ContactName.Name = "ContactName"
        Me.ContactName.Width = 60
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "User"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Width = 70
        '
        'QDetLine
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QDetLine.DefaultCellStyle = DataGridViewCellStyle3
        Me.QDetLine.HeaderText = "Quote Line"
        Me.QDetLine.Name = "QDetLine"
        Me.QDetLine.Width = 50
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Width = 90
        '
        'DocNo
        '
        Me.DocNo.HeaderText = "Doc No."
        Me.DocNo.Name = "DocNo"
        Me.DocNo.Width = 60
        '
        'SourceName
        '
        Me.SourceName.HeaderText = "DWG Source"
        Me.SourceName.Name = "SourceName"
        Me.SourceName.Width = 60
        '
        'QPartName
        '
        Me.QPartName.HeaderText = "Part Name"
        Me.QPartName.Name = "QPartName"
        Me.QPartName.Width = 50
        '
        'QRev
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QRev.DefaultCellStyle = DataGridViewCellStyle4
        Me.QRev.HeaderText = "Part Revision"
        Me.QRev.Name = "QRev"
        Me.QRev.Width = 50
        '
        'QLineStatus
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.QLineStatus.DefaultCellStyle = DataGridViewCellStyle5
        Me.QLineStatus.HeaderText = "Quote Line Status"
        Me.QLineStatus.Name = "QLineStatus"
        Me.QLineStatus.Width = 60
        '
        'QContractSw
        '
        Me.QContractSw.HeaderText = "Contract Qty Selected"
        Me.QContractSw.Name = "QContractSw"
        Me.QContractSw.Width = 60
        '
        'QQty
        '
        Me.QQty.HeaderText = "Quote Qty"
        Me.QQty.Name = "QQty"
        Me.QQty.Width = 60
        '
        'QQuotedPrice
        '
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.QQuotedPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.QQuotedPrice.HeaderText = "Quote Price"
        Me.QQuotedPrice.Name = "QQuotedPrice"
        Me.QQuotedPrice.Width = 60
        '
        'QEstPrice
        '
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.QEstPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.QEstPrice.HeaderText = "Quote EstPr"
        Me.QEstPrice.Name = "QEstPrice"
        Me.QEstPrice.Width = 60
        '
        'QMargin
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.QMargin.DefaultCellStyle = DataGridViewCellStyle8
        Me.QMargin.HeaderText = "Gross Margin"
        Me.QMargin.Name = "QMargin"
        Me.QMargin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.QMargin.Width = 60
        '
        'QDevise
        '
        Me.QDevise.HeaderText = "Quote Devise"
        Me.QDevise.Name = "QDevise"
        Me.QDevise.Width = 40
        '
        'QLeadTime
        '
        Me.QLeadTime.HeaderText = "Quote Lead Time"
        Me.QLeadTime.Name = "QLeadTime"
        Me.QLeadTime.Width = 60
        '
        'QExpLead
        '
        Me.QExpLead.HeaderText = "Quote Expedite Lead Time"
        Me.QExpLead.Name = "QExpLead"
        Me.QExpLead.Width = 60
        '
        'QExpValue
        '
        DataGridViewCellStyle9.Format = "C2"
        Me.QExpValue.DefaultCellStyle = DataGridViewCellStyle9
        Me.QExpValue.HeaderText = "Expedite Value"
        Me.QExpValue.Name = "QExpValue"
        Me.QExpValue.Width = 60
        '
        'QPartNotes
        '
        Me.QPartNotes.HeaderText = "Quote Item Notes"
        Me.QPartNotes.Name = "QPartNotes"
        Me.QPartNotes.Width = 60
        '
        'QLACNotes
        '
        Me.QLACNotes.HeaderText = "Quote Notes"
        Me.QLACNotes.Name = "QLACNotes"
        Me.QLACNotes.Width = 60
        '
        'QRawMaterial
        '
        Me.QRawMaterial.HeaderText = "Raw Material"
        Me.QRawMaterial.Name = "QRawMaterial"
        Me.QRawMaterial.Width = 50
        '
        'QTooling
        '
        Me.QTooling.HeaderText = "Tooling"
        Me.QTooling.Name = "QTooling"
        Me.QTooling.Width = 50
        '
        'QCustID
        '
        Me.QCustID.HeaderText = "QCustID"
        Me.QCustID.MinimumWidth = 2
        Me.QCustID.Name = "QCustID"
        Me.QCustID.Visible = False
        Me.QCustID.Width = 2
        '
        'frmStQuoteAnalyze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(1102, 729)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDueDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbItemStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQuote)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.dgQuote)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.CmbSelCust)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Name = "frmStQuoteAnalyze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ST Quote Analyze"
        CType(Me.dgQuote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents CmbSelCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents dgQuote As System.Windows.Forms.DataGridView
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuote As System.Windows.Forms.TextBox
    Friend WithEvents CmbItemStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RdNoBid As System.Windows.Forms.RadioButton
    Friend WithEvents RdFollowup As System.Windows.Forms.RadioButton
    Friend WithEvents RdAll As System.Windows.Forms.RadioButton
    Friend WithEvents QNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QFollow As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QDueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QContract As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QQtyContract As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QCustRefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QDetLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QPartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QLineStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QContractSw As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QQuotedPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QEstPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QMargin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QLeadTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QExpLead As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QExpValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QPartNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QLACNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRawMaterial As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QTooling As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents QCustID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
