<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDept
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgSearch = New System.Windows.Forms.DataGridView
        Me.SwDeptSrc = New System.Windows.Forms.TextBox
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmdSelect = New System.Windows.Forms.DataGridViewButtonColumn
        Me.DeptNode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeptBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSearch.ColumnHeadersHeight = 35
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DeptID, Me.CmdSelect, Me.DeptNode, Me.DeptBarCode})
        Me.dgSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgSearch.Name = "dgSearch"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSearch.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgSearch.RowHeadersWidth = 25
        Me.dgSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSearch.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgSearch.RowTemplate.Height = 35
        Me.dgSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSearch.Size = New System.Drawing.Size(742, 716)
        Me.dgSearch.TabIndex = 0
        '
        'SwDeptSrc
        '
        Me.SwDeptSrc.BackColor = System.Drawing.Color.Maroon
        Me.SwDeptSrc.Location = New System.Drawing.Point(37, 142)
        Me.SwDeptSrc.Name = "SwDeptSrc"
        Me.SwDeptSrc.Size = New System.Drawing.Size(49, 20)
        Me.SwDeptSrc.TabIndex = 2
        Me.SwDeptSrc.Visible = False
        '
        'DeptID
        '
        Me.DeptID.HeaderText = "DeptID"
        Me.DeptID.MinimumWidth = 2
        Me.DeptID.Name = "DeptID"
        Me.DeptID.Visible = False
        Me.DeptID.Width = 2
        '
        'CmdSelect
        '
        Me.CmdSelect.HeaderText = "Select"
        Me.CmdSelect.Name = "CmdSelect"
        Me.CmdSelect.Text = "<<-----"
        Me.CmdSelect.UseColumnTextForButtonValue = True
        '
        'DeptNode
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeptNode.DefaultCellStyle = DataGridViewCellStyle2
        Me.DeptNode.HeaderText = "Department"
        Me.DeptNode.Name = "DeptNode"
        Me.DeptNode.Width = 600
        '
        'DeptBarCode
        '
        Me.DeptBarCode.HeaderText = "DeptBarCode"
        Me.DeptBarCode.MinimumWidth = 2
        Me.DeptBarCode.Name = "DeptBarCode"
        Me.DeptBarCode.Visible = False
        Me.DeptBarCode.Width = 2
        '
        'frmSelectDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 716)
        Me.Controls.Add(Me.SwDeptSrc)
        Me.Controls.Add(Me.dgSearch)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Select Production Department"
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgSearch As System.Windows.Forms.DataGridView
    Friend WithEvents SwDeptSrc As System.Windows.Forms.TextBox
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DeptNode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
