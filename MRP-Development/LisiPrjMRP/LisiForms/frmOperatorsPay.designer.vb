<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOperatorsPay
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dgOper = New System.Windows.Forms.DataGridView()
        Me.EmployeeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Emppassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Discontinued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NivAccess = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpMatricule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.ButtActive = New System.Windows.Forms.RadioButton()
        Me.ButtAll = New System.Windows.Forms.RadioButton()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgOper, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(1149, 25)
        CustToolBar.TabIndex = 64
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(32, 12)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 118
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgOper
        '
        Me.dgOper.AllowUserToDeleteRows = False
        Me.dgOper.AllowUserToOrderColumns = True
        Me.dgOper.AllowUserToResizeColumns = False
        Me.dgOper.AllowUserToResizeRows = False
        Me.dgOper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOper.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOper.ColumnHeadersHeight = 32
        Me.dgOper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgOper.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeID, Me.EmpUserID, Me.EmpName, Me.Emppassword, Me.Discontinued, Me.NivAccess, Me.DeptCode, Me.EmpDept, Me.EmpMatricule})
        Me.dgOper.Location = New System.Drawing.Point(12, 45)
        Me.dgOper.Name = "dgOper"
        Me.dgOper.RowHeadersWidth = 25
        Me.dgOper.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgOper.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgOper.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgOper.RowTemplate.Height = 25
        Me.dgOper.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgOper.Size = New System.Drawing.Size(1125, 664)
        Me.dgOper.TabIndex = 119
        Me.dgOper.Text = "DataGridView1"
        '
        'EmployeeID
        '
        Me.EmployeeID.HeaderText = "EmployeeID"
        Me.EmployeeID.MinimumWidth = 2
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Visible = False
        Me.EmployeeID.Width = 2
        '
        'EmpUserID
        '
        Me.EmpUserID.HeaderText = "EmpUserID"
        Me.EmpUserID.MinimumWidth = 2
        Me.EmpUserID.Name = "EmpUserID"
        Me.EmpUserID.Visible = False
        Me.EmpUserID.Width = 2
        '
        'EmpName
        '
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Width = 150
        '
        'Emppassword
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Emppassword.DefaultCellStyle = DataGridViewCellStyle2
        Me.Emppassword.HeaderText = "Employee Password"
        Me.Emppassword.Name = "Emppassword"
        '
        'Discontinued
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Discontinued.DefaultCellStyle = DataGridViewCellStyle3
        Me.Discontinued.HeaderText = "Discontinued"
        Me.Discontinued.Name = "Discontinued"
        '
        'NivAccess
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NivAccess.DefaultCellStyle = DataGridViewCellStyle4
        Me.NivAccess.HeaderText = "Access Level"
        Me.NivAccess.Name = "NivAccess"
        '
        'DeptCode
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DeptCode.DefaultCellStyle = DataGridViewCellStyle5
        Me.DeptCode.HeaderText = "Department Code"
        Me.DeptCode.Name = "DeptCode"
        '
        'EmpDept
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EmpDept.DefaultCellStyle = DataGridViewCellStyle6
        Me.EmpDept.HeaderText = "Employee Department"
        Me.EmpDept.Name = "EmpDept"
        '
        'EmpMatricule
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EmpMatricule.DefaultCellStyle = DataGridViewCellStyle7
        Me.EmpMatricule.HeaderText = "Employee Matricule#"
        Me.EmpMatricule.Name = "EmpMatricule"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(265, 12)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 120
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'ButtActive
        '
        Me.ButtActive.AutoSize = True
        Me.ButtActive.Location = New System.Drawing.Point(447, 15)
        Me.ButtActive.Name = "ButtActive"
        Me.ButtActive.Size = New System.Drawing.Size(55, 17)
        Me.ButtActive.TabIndex = 123
        Me.ButtActive.Text = "Active"
        '
        'ButtAll
        '
        Me.ButtAll.AutoSize = True
        Me.ButtAll.Location = New System.Drawing.Point(631, 15)
        Me.ButtAll.Name = "ButtAll"
        Me.ButtAll.Size = New System.Drawing.Size(36, 17)
        Me.ButtAll.TabIndex = 124
        Me.ButtAll.Text = "All"
        '
        'frmOperatorsPay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 823)
        Me.Controls.Add(Me.ButtAll)
        Me.Controls.Add(Me.ButtActive)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.dgOper)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmOperatorsPay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -  Update Operators Data"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgOper As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ButtActive As System.Windows.Forms.RadioButton
    Friend WithEvents ButtAll As System.Windows.Forms.RadioButton
    Friend WithEvents EmployeeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Emppassword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discontinued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NivAccess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpMatricule As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
