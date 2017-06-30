<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOAnalyze
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
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgPO = New System.Windows.Forms.DataGridView
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.POMasterID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODetailID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwRateMPO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwRatePO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MPOLineValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelivQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustDelivDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NrDaysNowToDeliv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdItemPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDevise = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SuppName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODueDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POItem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POUM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLineValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DolarSign = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChkPoItemStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.POPromisedDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONotesLAC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgPO
        '
        Me.dgPO.AllowUserToAddRows = False
        Me.dgPO.AllowUserToDeleteRows = False
        Me.dgPO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgPO.ColumnHeadersHeight = 45
        Me.dgPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.POMasterID, Me.PODetailID, Me.SwRateMPO, Me.SwRatePO, Me.POType, Me.MpoNo, Me.MpoType, Me.PartNumber, Me.QtyActual, Me.MPOLineValue, Me.DelivQty, Me.CustomerShort, Me.CustDelivDate, Me.NrDaysNowToDeliv, Me.OrdItemPrice, Me.OrdDevise, Me.SuppName, Me.PONo, Me.PODate, Me.PODueDate, Me.POItem, Me.ProdDescr, Me.POQty, Me.POPrice, Me.POUM, Me.POLineValue, Me.DolarSign, Me.ChkPoItemStatus, Me.POPromisedDate, Me.PONotesLAC, Me.TotQty})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPO.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgPO.Location = New System.Drawing.Point(5, 51)
        Me.dgPO.Name = "dgPO"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPO.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgPO.RowHeadersWidth = 25
        Me.dgPO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgPO.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPO.RowTemplate.Height = 18
        Me.dgPO.Size = New System.Drawing.Size(1135, 683)
        Me.dgPO.TabIndex = 25
        Me.dgPO.Text = "DataGridView1"
        '
        'CmdSearch
        '
        Me.CmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearch.Location = New System.Drawing.Point(12, 12)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(71, 21)
        Me.CmdSearch.TabIndex = 33
        Me.CmdSearch.Text = "Refresh"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'POMasterID
        '
        Me.POMasterID.HeaderText = "POMasterID"
        Me.POMasterID.MinimumWidth = 2
        Me.POMasterID.Name = "POMasterID"
        Me.POMasterID.Visible = False
        Me.POMasterID.Width = 2
        '
        'PODetailID
        '
        Me.PODetailID.HeaderText = "PODetailID"
        Me.PODetailID.MinimumWidth = 2
        Me.PODetailID.Name = "PODetailID"
        Me.PODetailID.Visible = False
        Me.PODetailID.Width = 2
        '
        'SwRateMPO
        '
        Me.SwRateMPO.HeaderText = "SwRateMPO"
        Me.SwRateMPO.MinimumWidth = 2
        Me.SwRateMPO.Name = "SwRateMPO"
        Me.SwRateMPO.Visible = False
        Me.SwRateMPO.Width = 2
        '
        'SwRatePO
        '
        Me.SwRatePO.HeaderText = "SwRatePO"
        Me.SwRatePO.MinimumWidth = 2
        Me.SwRatePO.Name = "SwRatePO"
        Me.SwRatePO.Visible = False
        Me.SwRatePO.Width = 2
        '
        'POType
        '
        Me.POType.HeaderText = "PO Type"
        Me.POType.Name = "POType"
        Me.POType.Width = 50
        '
        'MpoNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue
        Me.MpoNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.MpoNo.HeaderText = "MpoNo"
        Me.MpoNo.Name = "MpoNo"
        Me.MpoNo.Width = 60
        '
        'MpoType
        '
        Me.MpoType.HeaderText = "MPO Classification"
        Me.MpoType.Name = "MpoType"
        Me.MpoType.Width = 70
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "PartNumber"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Width = 70
        '
        'QtyActual
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QtyActual.DefaultCellStyle = DataGridViewCellStyle4
        Me.QtyActual.HeaderText = "MPO Qty Actual"
        Me.QtyActual.Name = "QtyActual"
        Me.QtyActual.Width = 60
        '
        'MPOLineValue
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        Me.MPOLineValue.DefaultCellStyle = DataGridViewCellStyle5
        Me.MPOLineValue.HeaderText = "MPO Value (CDN)"
        Me.MPOLineValue.MinimumWidth = 2
        Me.MPOLineValue.Name = "MPOLineValue"
        Me.MPOLineValue.Visible = False
        Me.MPOLineValue.Width = 2
        '
        'DelivQty
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DelivQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.DelivQty.HeaderText = "Cust Deliv Qty"
        Me.DelivQty.Name = "DelivQty"
        Me.DelivQty.Width = 60
        '
        'CustomerShort
        '
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 60
        '
        'CustDelivDate
        '
        Me.CustDelivDate.HeaderText = "Cust DelivDate"
        Me.CustDelivDate.Name = "CustDelivDate"
        Me.CustDelivDate.Width = 65
        '
        'NrDaysNowToDeliv
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NrDaysNowToDeliv.DefaultCellStyle = DataGridViewCellStyle7
        Me.NrDaysNowToDeliv.HeaderText = "# Days to Deliv"
        Me.NrDaysNowToDeliv.Name = "NrDaysNowToDeliv"
        Me.NrDaysNowToDeliv.Width = 50
        '
        'OrdItemPrice
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        Me.OrdItemPrice.DefaultCellStyle = DataGridViewCellStyle8
        Me.OrdItemPrice.HeaderText = "Cust Price"
        Me.OrdItemPrice.Name = "OrdItemPrice"
        Me.OrdItemPrice.Width = 60
        '
        'OrdDevise
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.OrdDevise.DefaultCellStyle = DataGridViewCellStyle9
        Me.OrdDevise.HeaderText = "Cust Devise"
        Me.OrdDevise.Name = "OrdDevise"
        Me.OrdDevise.Width = 50
        '
        'SuppName
        '
        Me.SuppName.HeaderText = "Supplier "
        Me.SuppName.Name = "SuppName"
        Me.SuppName.Width = 50
        '
        'PONo
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightBlue
        Me.PONo.DefaultCellStyle = DataGridViewCellStyle10
        Me.PONo.HeaderText = "PO No"
        Me.PONo.Name = "PONo"
        Me.PONo.Width = 60
        '
        'PODate
        '
        Me.PODate.HeaderText = "PO Date"
        Me.PODate.Name = "PODate"
        Me.PODate.Width = 65
        '
        'PODueDate
        '
        Me.PODueDate.HeaderText = "PO Due Date"
        Me.PODueDate.Name = "PODueDate"
        Me.PODueDate.Width = 65
        '
        'POItem
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.POItem.DefaultCellStyle = DataGridViewCellStyle11
        Me.POItem.HeaderText = "PO Item"
        Me.POItem.Name = "POItem"
        Me.POItem.Width = 50
        '
        'ProdDescr
        '
        Me.ProdDescr.HeaderText = "Prod Descr"
        Me.ProdDescr.Name = "ProdDescr"
        '
        'POQty
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.POQty.DefaultCellStyle = DataGridViewCellStyle12
        Me.POQty.HeaderText = "PO Qty"
        Me.POQty.Name = "POQty"
        Me.POQty.Width = 60
        '
        'POPrice
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "C2"
        Me.POPrice.DefaultCellStyle = DataGridViewCellStyle13
        Me.POPrice.HeaderText = "PO Price"
        Me.POPrice.Name = "POPrice"
        Me.POPrice.Width = 60
        '
        'POUM
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.POUM.DefaultCellStyle = DataGridViewCellStyle14
        Me.POUM.HeaderText = "PO UM"
        Me.POUM.Name = "POUM"
        Me.POUM.Width = 50
        '
        'POLineValue
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "C2"
        Me.POLineValue.DefaultCellStyle = DataGridViewCellStyle15
        Me.POLineValue.HeaderText = "PO Line Value (CDN)"
        Me.POLineValue.Name = "POLineValue"
        Me.POLineValue.Width = 60
        '
        'DolarSign
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DolarSign.DefaultCellStyle = DataGridViewCellStyle16
        Me.DolarSign.HeaderText = "PO Devise"
        Me.DolarSign.Name = "DolarSign"
        Me.DolarSign.Width = 50
        '
        'ChkPoItemStatus
        '
        Me.ChkPoItemStatus.HeaderText = "Close Item"
        Me.ChkPoItemStatus.MinimumWidth = 2
        Me.ChkPoItemStatus.Name = "ChkPoItemStatus"
        Me.ChkPoItemStatus.Visible = False
        Me.ChkPoItemStatus.Width = 2
        '
        'POPromisedDate
        '
        DataGridViewCellStyle17.NullValue = "MM/dd/yyyy"
        Me.POPromisedDate.DefaultCellStyle = DataGridViewCellStyle17
        Me.POPromisedDate.HeaderText = "Supp Promised Date (mm/dd/yyyy)"
        Me.POPromisedDate.Name = "POPromisedDate"
        Me.POPromisedDate.Width = 80
        '
        'PONotesLAC
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.PONotesLAC.DefaultCellStyle = DataGridViewCellStyle18
        Me.PONotesLAC.HeaderText = "Notes"
        Me.PONotesLAC.Name = "PONotesLAC"
        '
        'TotQty
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.TotQty.DefaultCellStyle = DataGridViewCellStyle19
        Me.TotQty.HeaderText = "Qty Received"
        Me.TotQty.Name = "TotQty"
        Me.TotQty.Width = 60
        '
        'frmPOAnalyze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 739)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.dgPO)
        Me.Name = "frmPOAnalyze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Subcontracting Analyze Module"
        CType(Me.dgPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgPO As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents POMasterID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRateMPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRatePO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOLineValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelivQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustDelivDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NrDaysNowToDeliv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdItemPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDevise As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODueDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLineValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DolarSign As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkPoItemStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents POPromisedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONotesLAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
