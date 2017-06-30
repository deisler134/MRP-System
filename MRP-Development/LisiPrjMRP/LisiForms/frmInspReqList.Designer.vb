<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInspReqList
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
        Me.components = New System.ComponentModel.Container
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.dg = New System.Windows.Forms.DataGridView
        Me.ReqID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReqName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReqStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(527, 25)
        CustToolBar.TabIndex = 67
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(205, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 126
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(28, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 125
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dg
        '
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AllowUserToOrderColumns = True
        Me.dg.AllowUserToResizeColumns = False
        Me.dg.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg.ColumnHeadersHeight = 25
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReqID, Me.ReqName, Me.ReqStatus})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 25)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersWidth = 20
        Me.dg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dg.RowTemplate.Height = 18
        Me.dg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dg.Size = New System.Drawing.Size(527, 342)
        Me.dg.TabIndex = 127
        Me.dg.Text = "DataGridView1"
        '
        'ReqID
        '
        Me.ReqID.HeaderText = "ReqID"
        Me.ReqID.MinimumWidth = 2
        Me.ReqID.Name = "ReqID"
        Me.ReqID.Visible = False
        Me.ReqID.Width = 2
        '
        'ReqName
        '
        Me.ReqName.HeaderText = "ReqName"
        Me.ReqName.Name = "ReqName"
        Me.ReqName.Width = 400
        '
        'ReqStatus
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.ReqStatus.DefaultCellStyle = DataGridViewCellStyle4
        Me.ReqStatus.HeaderText = "Status"
        Me.ReqStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.ReqStatus.Name = "ReqStatus"
        '
        'frmInspReqList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 367)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmInspReqList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Maintain Inspection Requirement List"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ReqID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReqStatus As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
