<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderEntryM3CODO
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgLoad = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DODONo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOShipTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOFacility = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOBl1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOITNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOPNSTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOMFGITNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOMFGPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOMFGPNSTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOBl2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOEntryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DODeliveryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOSalesPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DODODate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoeingPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOERROR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdPartNoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdPartCross99ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdDOs = New System.Windows.Forms.Button()
        Me.CmdCOs = New System.Windows.Forms.Button()
        Me.CmdExec = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.txtDOC = New System.Windows.Forms.TextBox()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.txtOrdDelivID = New System.Windows.Forms.TextBox()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.CmdExport = New System.Windows.Forms.Button()
        CType(Me.dgLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLoad
        '
        Me.dgLoad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLoad.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgLoad.ColumnHeadersHeight = 30
        Me.dgLoad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.DODONo, Me.DOShipTo, Me.DOFacility, Me.DOLine, Me.DOBl1, Me.DOITNO, Me.DOPN, Me.DOPNSTATUS, Me.DOQty, Me.DOMFGITNO, Me.DOMFGPN, Me.DOMFGPNSTATUS, Me.DOBl2, Me.DOEntryDate, Me.DODeliveryDate, Me.DOSalesPrice, Me.DODODate, Me.BoeingPrice, Me.DOERROR, Me.OrdPartNoID, Me.OrdPartCross99ID})
        Me.dgLoad.EnableHeadersVisualStyles = False
        Me.dgLoad.Location = New System.Drawing.Point(12, 132)
        Me.dgLoad.Name = "dgLoad"
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLoad.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgLoad.RowHeadersWidth = 25
        Me.dgLoad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgLoad.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgLoad.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgLoad.RowTemplate.Height = 17
        Me.dgLoad.Size = New System.Drawing.Size(1553, 721)
        Me.dgLoad.TabIndex = 154
        Me.dgLoad.Text = "DataGridView1"
        '
        'ID
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle20
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        Me.ID.Width = 80
        '
        'DODONo
        '
        Me.DODONo.HeaderText = "DODONo"
        Me.DODONo.Name = "DODONo"
        Me.DODONo.Width = 120
        '
        'DOShipTo
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOShipTo.DefaultCellStyle = DataGridViewCellStyle21
        Me.DOShipTo.HeaderText = "DOShipTo"
        Me.DOShipTo.Name = "DOShipTo"
        Me.DOShipTo.Width = 60
        '
        'DOFacility
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOFacility.DefaultCellStyle = DataGridViewCellStyle22
        Me.DOFacility.HeaderText = "DOFacility"
        Me.DOFacility.Name = "DOFacility"
        Me.DOFacility.Width = 60
        '
        'DOLine
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOLine.DefaultCellStyle = DataGridViewCellStyle23
        Me.DOLine.HeaderText = "DOLine"
        Me.DOLine.Name = "DOLine"
        Me.DOLine.Width = 60
        '
        'DOBl1
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOBl1.DefaultCellStyle = DataGridViewCellStyle24
        Me.DOBl1.HeaderText = "DOBl1"
        Me.DOBl1.Name = "DOBl1"
        Me.DOBl1.Width = 60
        '
        'DOITNO
        '
        Me.DOITNO.HeaderText = "DOITNO"
        Me.DOITNO.Name = "DOITNO"
        Me.DOITNO.Width = 70
        '
        'DOPN
        '
        Me.DOPN.HeaderText = "DOPN"
        Me.DOPN.Name = "DOPN"
        '
        'DOPNSTATUS
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOPNSTATUS.DefaultCellStyle = DataGridViewCellStyle25
        Me.DOPNSTATUS.HeaderText = "DOPNSTATUS"
        Me.DOPNSTATUS.Name = "DOPNSTATUS"
        Me.DOPNSTATUS.Width = 80
        '
        'DOQty
        '
        Me.DOQty.HeaderText = "DOQty"
        Me.DOQty.Name = "DOQty"
        Me.DOQty.Width = 70
        '
        'DOMFGITNO
        '
        Me.DOMFGITNO.HeaderText = "DOMFGITNO"
        Me.DOMFGITNO.Name = "DOMFGITNO"
        Me.DOMFGITNO.Width = 70
        '
        'DOMFGPN
        '
        Me.DOMFGPN.HeaderText = "DOMFGPN"
        Me.DOMFGPN.Name = "DOMFGPN"
        '
        'DOMFGPNSTATUS
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DOMFGPNSTATUS.DefaultCellStyle = DataGridViewCellStyle26
        Me.DOMFGPNSTATUS.HeaderText = "DOMFGPNSTATUS"
        Me.DOMFGPNSTATUS.Name = "DOMFGPNSTATUS"
        Me.DOMFGPNSTATUS.Width = 80
        '
        'DOBl2
        '
        Me.DOBl2.HeaderText = "DOBl2"
        Me.DOBl2.Name = "DOBl2"
        Me.DOBl2.Width = 60
        '
        'DOEntryDate
        '
        Me.DOEntryDate.HeaderText = "DOEntryDate"
        Me.DOEntryDate.Name = "DOEntryDate"
        '
        'DODeliveryDate
        '
        Me.DODeliveryDate.HeaderText = "DODeliveryDate"
        Me.DODeliveryDate.Name = "DODeliveryDate"
        Me.DODeliveryDate.Width = 80
        '
        'DOSalesPrice
        '
        Me.DOSalesPrice.HeaderText = "DOSalesPrice"
        Me.DOSalesPrice.Name = "DOSalesPrice"
        Me.DOSalesPrice.Width = 90
        '
        'DODODate
        '
        Me.DODODate.HeaderText = "DODODate"
        Me.DODODate.Name = "DODODate"
        Me.DODODate.Width = 80
        '
        'BoeingPrice
        '
        Me.BoeingPrice.HeaderText = "Boeing Price"
        Me.BoeingPrice.Name = "BoeingPrice"
        Me.BoeingPrice.Width = 90
        '
        'DOERROR
        '
        Me.DOERROR.HeaderText = "DOERROR"
        Me.DOERROR.Name = "DOERROR"
        Me.DOERROR.Width = 70
        '
        'OrdPartNoID
        '
        Me.OrdPartNoID.HeaderText = "OrdPartNoID"
        Me.OrdPartNoID.MinimumWidth = 2
        Me.OrdPartNoID.Name = "OrdPartNoID"
        Me.OrdPartNoID.Visible = False
        Me.OrdPartNoID.Width = 2
        '
        'OrdPartCross99ID
        '
        Me.OrdPartCross99ID.HeaderText = "OrdPartCross99ID"
        Me.OrdPartCross99ID.MinimumWidth = 2
        Me.OrdPartCross99ID.Name = "OrdPartCross99ID"
        Me.OrdPartCross99ID.Visible = False
        Me.OrdPartCross99ID.Width = 2
        '
        'CmdDOs
        '
        Me.CmdDOs.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CmdDOs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdDOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDOs.ForeColor = System.Drawing.Color.Black
        Me.CmdDOs.Location = New System.Drawing.Point(12, 12)
        Me.CmdDOs.Name = "CmdDOs"
        Me.CmdDOs.Size = New System.Drawing.Size(286, 41)
        Me.CmdDOs.TabIndex = 155
        Me.CmdDOs.Text = "DOs - Integreation into LAC Sytem"
        Me.CmdDOs.UseVisualStyleBackColor = False
        '
        'CmdCOs
        '
        Me.CmdCOs.BackColor = System.Drawing.Color.MediumTurquoise
        Me.CmdCOs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdCOs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCOs.Location = New System.Drawing.Point(12, 71)
        Me.CmdCOs.Name = "CmdCOs"
        Me.CmdCOs.Size = New System.Drawing.Size(286, 41)
        Me.CmdCOs.TabIndex = 156
        Me.CmdCOs.Text = "COs - Integreation into LAC Sytem"
        Me.CmdCOs.UseVisualStyleBackColor = False
        '
        'CmdExec
        '
        Me.CmdExec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExec.Location = New System.Drawing.Point(1150, 35)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(139, 41)
        Me.CmdExec.TabIndex = 157
        Me.CmdExec.Text = "Execute"
        Me.CmdExec.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileLocation.Location = New System.Drawing.Point(328, 49)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(530, 22)
        Me.txtFileLocation.TabIndex = 158
        '
        'txtDOC
        '
        Me.txtDOC.BackColor = System.Drawing.Color.Maroon
        Me.txtDOC.Location = New System.Drawing.Point(392, 92)
        Me.txtDOC.Name = "txtDOC"
        Me.txtDOC.ReadOnly = True
        Me.txtDOC.Size = New System.Drawing.Size(85, 20)
        Me.txtDOC.TabIndex = 159
        Me.txtDOC.Visible = False
        '
        'txtOrderID
        '
        Me.txtOrderID.BackColor = System.Drawing.Color.Maroon
        Me.txtOrderID.Location = New System.Drawing.Point(572, 92)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.ReadOnly = True
        Me.txtOrderID.Size = New System.Drawing.Size(85, 20)
        Me.txtOrderID.TabIndex = 160
        Me.txtOrderID.Visible = False
        '
        'txtOrdDelivID
        '
        Me.txtOrdDelivID.BackColor = System.Drawing.Color.Maroon
        Me.txtOrdDelivID.Location = New System.Drawing.Point(686, 92)
        Me.txtOrdDelivID.Name = "txtOrdDelivID"
        Me.txtOrdDelivID.ReadOnly = True
        Me.txtOrdDelivID.Size = New System.Drawing.Size(85, 20)
        Me.txtOrdDelivID.TabIndex = 161
        Me.txtOrdDelivID.Visible = False
        '
        'CmdPrint
        '
        Me.CmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.Location = New System.Drawing.Point(1374, 35)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(139, 41)
        Me.CmdPrint.TabIndex = 162
        Me.CmdPrint.Text = "DO Contract Review - Print"
        Me.CmdPrint.UseVisualStyleBackColor = True
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(978, 35)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 163
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'frmOrderEntryM3CODO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1573, 858)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.txtOrdDelivID)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.txtDOC)
        Me.Controls.Add(Me.txtFileLocation)
        Me.Controls.Add(Me.CmdExec)
        Me.Controls.Add(Me.CmdCOs)
        Me.Controls.Add(Me.CmdDOs)
        Me.Controls.Add(Me.dgLoad)
        Me.Name = "frmOrderEntryM3CODO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrderEntryM3CODO"
        CType(Me.dgLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgLoad As System.Windows.Forms.DataGridView
    Friend WithEvents CmdDOs As System.Windows.Forms.Button
    Friend WithEvents CmdCOs As System.Windows.Forms.Button
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtDOC As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderID As System.Windows.Forms.TextBox
    Friend WithEvents txtOrdDelivID As System.Windows.Forms.TextBox
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DODONo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOShipTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOFacility As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOBl1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOITNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOPNSTATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOMFGITNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOMFGPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOMFGPNSTATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOBl2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOEntryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DODeliveryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOSalesPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DODODate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoeingPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOERROR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdPartNoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdPartCross99ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdExport As System.Windows.Forms.Button
End Class
