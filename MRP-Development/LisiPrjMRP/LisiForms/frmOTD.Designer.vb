<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOTD
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgProd = New System.Windows.Forms.DataGridView
        Me.CmdClear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt20POtobe = New System.Windows.Forms.TextBox
        Me.txt30POtobe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerShort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdRevision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrdDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwRel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwLead = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SwWks = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.AllowUserToResizeRows = False
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgProd.ColumnHeadersHeight = 45
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartID, Me.CustomerShort, Me.PartNumber, Me.OrdNumber, Me.OrdRevision, Me.OrdDate, Me.Year, Me.Month, Me.InvDate, Me.SwRel, Me.SwLead, Me.SwDays, Me.SwWks})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.DefaultCellStyle = DataGridViewCellStyle24
        Me.dgProd.Location = New System.Drawing.Point(5, 87)
        Me.dgProd.Name = "dgProd"
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgProd.RowHeadersWidth = 25
        Me.dgProd.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgProd.RowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgProd.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgProd.RowTemplate.Height = 18
        Me.dgProd.Size = New System.Drawing.Size(1477, 643)
        Me.dgProd.TabIndex = 47
        Me.dgProd.Text = "DataGridView1"
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(1051, 25)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 66
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Date To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(165, 38)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(121, 20)
        Me.txtDateTo.TabIndex = 64
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Date From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(165, 12)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtDateFrom.TabIndex = 62
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(550, 25)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 61
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 744)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 26)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "# POs to be deliverd by 20 wks"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt20POtobe
        '
        Me.txt20POtobe.Location = New System.Drawing.Point(95, 773)
        Me.txt20POtobe.Name = "txt20POtobe"
        Me.txt20POtobe.Size = New System.Drawing.Size(103, 20)
        Me.txt20POtobe.TabIndex = 67
        Me.txt20POtobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt30POtobe
        '
        Me.txt30POtobe.Location = New System.Drawing.Point(248, 773)
        Me.txt30POtobe.Name = "txt30POtobe"
        Me.txt30POtobe.Size = New System.Drawing.Size(103, 20)
        Me.txt30POtobe.TabIndex = 69
        Me.txt30POtobe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(245, 744)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 26)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "# POs to be deliverd by 30 wks"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.MinimumWidth = 2
        Me.PartID.Name = "PartID"
        Me.PartID.Visible = False
        Me.PartID.Width = 2
        '
        'CustomerShort
        '
        Me.CustomerShort.HeaderText = "Customer"
        Me.CustomerShort.Name = "CustomerShort"
        Me.CustomerShort.Width = 50
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Width = 120
        '
        'OrdNumber
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Aquamarine
        Me.OrdNumber.DefaultCellStyle = DataGridViewCellStyle16
        Me.OrdNumber.HeaderText = "Order Number"
        Me.OrdNumber.Name = "OrdNumber"
        Me.OrdNumber.Width = 70
        '
        'OrdRevision
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.OrdRevision.DefaultCellStyle = DataGridViewCellStyle17
        Me.OrdRevision.HeaderText = "Order Revision"
        Me.OrdRevision.Name = "OrdRevision"
        Me.OrdRevision.Width = 50
        '
        'OrdDate
        '
        Me.OrdDate.HeaderText = "Order Date"
        Me.OrdDate.Name = "OrdDate"
        Me.OrdDate.Width = 80
        '
        'Year
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Year.DefaultCellStyle = DataGridViewCellStyle18
        Me.Year.HeaderText = "Order Year"
        Me.Year.Name = "Year"
        Me.Year.Width = 60
        '
        'Month
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Month.DefaultCellStyle = DataGridViewCellStyle19
        Me.Month.HeaderText = "Order Month"
        Me.Month.Name = "Month"
        Me.Month.Width = 60
        '
        'InvDate
        '
        Me.InvDate.HeaderText = "Invoice Date"
        Me.InvDate.Name = "InvDate"
        Me.InvDate.Width = 80
        '
        'SwRel
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SwRel.DefaultCellStyle = DataGridViewCellStyle20
        Me.SwRel.HeaderText = "# Release to Prod"
        Me.SwRel.Name = "SwRel"
        Me.SwRel.Width = 70
        '
        'SwLead
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Aquamarine
        Me.SwLead.DefaultCellStyle = DataGridViewCellStyle21
        Me.SwLead.HeaderText = "Promised Lead Time (Wks)"
        Me.SwLead.Name = "SwLead"
        Me.SwLead.Width = 70
        '
        'SwDays
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SwDays.DefaultCellStyle = DataGridViewCellStyle22
        Me.SwDays.HeaderText = "# Days (OrdDate-InvDate)"
        Me.SwDays.Name = "SwDays"
        '
        'SwWks
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.Aquamarine
        Me.SwWks.DefaultCellStyle = DataGridViewCellStyle23
        Me.SwWks.HeaderText = "# Wks"
        Me.SwWks.Name = "SwWks"
        '
        'frmOTD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1487, 807)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt30POtobe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt20POtobe)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.dgProd)
        Me.Name = "frmOTD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOTD"
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgProd As System.Windows.Forms.DataGridView
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt20POtobe As System.Windows.Forms.TextBox
    Friend WithEvents txt30POtobe As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdRevision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Year As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwRel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwLead As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwWks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
