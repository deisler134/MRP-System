<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustUpdateBudget
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.CmbCust = New System.Windows.Forms.ComboBox
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmdReset = New System.Windows.Forms.Button
        Me.dgBudget = New System.Windows.Forms.DataGridView
        Me.BudID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdentYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month01 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month02 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month03 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month04 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month05 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month06 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month07 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month08 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month09 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbCust
        '
        Me.CmbCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCust.ForeColor = System.Drawing.Color.DarkRed
        Me.CmbCust.FormattingEnabled = True
        Me.CmbCust.Location = New System.Drawing.Point(12, 55)
        Me.CmbCust.MaxDropDownItems = 30
        Me.CmbCust.Name = "CmbCust"
        Me.CmbCust.Size = New System.Drawing.Size(312, 23)
        Me.CmbCust.TabIndex = 3
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(12, 5)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 4
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(249, 5)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(75, 23)
        Me.CmdReset.TabIndex = 5
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'dgBudget
        '
        Me.dgBudget.AllowUserToDeleteRows = False
        Me.dgBudget.AllowUserToResizeColumns = False
        Me.dgBudget.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgBudget.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBudget.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgBudget.ColumnHeadersHeight = 20
        Me.dgBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgBudget.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BudID, Me.CustomerID, Me.IdentYear, Me.Month01, Me.Month02, Me.Month03, Me.Month04, Me.Month05, Me.Month06, Me.Month07, Me.Month08, Me.Month09, Me.Month10, Me.Month11, Me.Month12, Me.Total})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgBudget.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgBudget.Location = New System.Drawing.Point(12, 99)
        Me.dgBudget.Name = "dgBudget"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgBudget.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgBudget.RowHeadersWidth = 25
        Me.dgBudget.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgBudget.RowsDefaultCellStyle = DataGridViewCellStyle19
        Me.dgBudget.RowTemplate.Height = 20
        Me.dgBudget.Size = New System.Drawing.Size(937, 260)
        Me.dgBudget.TabIndex = 6
        '
        'BudID
        '
        Me.BudID.HeaderText = "BudID"
        Me.BudID.MinimumWidth = 2
        Me.BudID.Name = "BudID"
        Me.BudID.Visible = False
        Me.BudID.Width = 2
        '
        'CustomerID
        '
        Me.CustomerID.HeaderText = "CustomerID"
        Me.CustomerID.MinimumWidth = 2
        Me.CustomerID.Name = "CustomerID"
        Me.CustomerID.Visible = False
        Me.CustomerID.Width = 2
        '
        'IdentYear
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdentYear.DefaultCellStyle = DataGridViewCellStyle3
        Me.IdentYear.HeaderText = "IdentYear"
        Me.IdentYear.Name = "IdentYear"
        Me.IdentYear.Width = 50
        '
        'Month01
        '
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Month01.DefaultCellStyle = DataGridViewCellStyle4
        Me.Month01.HeaderText = "Month01"
        Me.Month01.Name = "Month01"
        Me.Month01.Width = 65
        '
        'Month02
        '
        DataGridViewCellStyle5.Format = "C2"
        Me.Month02.DefaultCellStyle = DataGridViewCellStyle5
        Me.Month02.HeaderText = "Month02"
        Me.Month02.Name = "Month02"
        Me.Month02.Width = 65
        '
        'Month03
        '
        DataGridViewCellStyle6.Format = "C2"
        Me.Month03.DefaultCellStyle = DataGridViewCellStyle6
        Me.Month03.HeaderText = "Month03"
        Me.Month03.Name = "Month03"
        Me.Month03.Width = 65
        '
        'Month04
        '
        DataGridViewCellStyle7.Format = "C2"
        Me.Month04.DefaultCellStyle = DataGridViewCellStyle7
        Me.Month04.HeaderText = "Month04"
        Me.Month04.Name = "Month04"
        Me.Month04.Width = 65
        '
        'Month05
        '
        DataGridViewCellStyle8.Format = "C2"
        Me.Month05.DefaultCellStyle = DataGridViewCellStyle8
        Me.Month05.HeaderText = "Month05"
        Me.Month05.Name = "Month05"
        Me.Month05.Width = 65
        '
        'Month06
        '
        DataGridViewCellStyle9.Format = "C2"
        Me.Month06.DefaultCellStyle = DataGridViewCellStyle9
        Me.Month06.HeaderText = "Month06"
        Me.Month06.Name = "Month06"
        Me.Month06.Width = 65
        '
        'Month07
        '
        DataGridViewCellStyle10.Format = "C2"
        Me.Month07.DefaultCellStyle = DataGridViewCellStyle10
        Me.Month07.HeaderText = "Month07"
        Me.Month07.Name = "Month07"
        Me.Month07.Width = 65
        '
        'Month08
        '
        DataGridViewCellStyle11.Format = "C2"
        Me.Month08.DefaultCellStyle = DataGridViewCellStyle11
        Me.Month08.HeaderText = "Month08"
        Me.Month08.Name = "Month08"
        Me.Month08.Width = 65
        '
        'Month09
        '
        DataGridViewCellStyle12.Format = "C2"
        Me.Month09.DefaultCellStyle = DataGridViewCellStyle12
        Me.Month09.HeaderText = "Month09"
        Me.Month09.Name = "Month09"
        Me.Month09.Width = 65
        '
        'Month10
        '
        DataGridViewCellStyle13.Format = "C2"
        Me.Month10.DefaultCellStyle = DataGridViewCellStyle13
        Me.Month10.HeaderText = "Month10"
        Me.Month10.Name = "Month10"
        Me.Month10.Width = 65
        '
        'Month11
        '
        DataGridViewCellStyle14.Format = "C2"
        Me.Month11.DefaultCellStyle = DataGridViewCellStyle14
        Me.Month11.HeaderText = "Month11"
        Me.Month11.Name = "Month11"
        Me.Month11.Width = 65
        '
        'Month12
        '
        DataGridViewCellStyle15.Format = "C2"
        Me.Month12.DefaultCellStyle = DataGridViewCellStyle15
        Me.Month12.HeaderText = "Month12"
        Me.Month12.Name = "Month12"
        Me.Month12.Width = 65
        '
        'Total
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.Format = "C2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Total.DefaultCellStyle = DataGridViewCellStyle16
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 80
        '
        'frmCustUpdateBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 371)
        Me.Controls.Add(Me.dgBudget)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.CmbCust)
        Me.Name = "frmCustUpdateBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Customer Booking Budget"
        CType(Me.dgBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents dgBudget As System.Windows.Forms.DataGridView
    Friend WithEvents BudID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdentYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month01 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month02 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month03 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month04 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month05 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month06 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month07 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month08 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month09 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
