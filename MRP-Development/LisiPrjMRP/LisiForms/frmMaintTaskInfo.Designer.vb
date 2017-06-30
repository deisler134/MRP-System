<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintTaskInfo
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
        Me.components = New System.ComponentModel.Container
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgEq = New System.Windows.Forms.DataGridView
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.TaskCodeInfo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaskDescrInfo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaskStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.TaskInfoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgEq, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(874, 25)
        CustToolBar.TabIndex = 125
        CustToolBar.Text = "BindingNavigator1"
        '
        'dgEq
        '
        Me.dgEq.AllowUserToDeleteRows = False
        Me.dgEq.AllowUserToOrderColumns = True
        Me.dgEq.AllowUserToResizeColumns = False
        Me.dgEq.AllowUserToResizeRows = False
        Me.dgEq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgEq.ColumnHeadersHeight = 30
        Me.dgEq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TaskCodeInfo, Me.TaskDescrInfo, Me.TaskStatus, Me.TaskInfoID})
        Me.dgEq.Location = New System.Drawing.Point(12, 38)
        Me.dgEq.Name = "dgEq"
        Me.dgEq.RowHeadersWidth = 25
        Me.dgEq.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgEq.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgEq.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEq.RowTemplate.Height = 20
        Me.dgEq.Size = New System.Drawing.Size(848, 616)
        Me.dgEq.TabIndex = 124
        Me.dgEq.Text = "DataGridView1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(622, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 127
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(92, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 126
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'TaskCodeInfo
        '
        Me.TaskCodeInfo.HeaderText = "Task Code"
        Me.TaskCodeInfo.Name = "TaskCodeInfo"
        Me.TaskCodeInfo.Width = 200
        '
        'TaskDescrInfo
        '
        Me.TaskDescrInfo.HeaderText = "Task Descr."
        Me.TaskDescrInfo.Name = "TaskDescrInfo"
        Me.TaskDescrInfo.Width = 500
        '
        'TaskStatus
        '
        Me.TaskStatus.HeaderText = "Task Status"
        Me.TaskStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.TaskStatus.Name = "TaskStatus"
        '
        'TaskInfoID
        '
        Me.TaskInfoID.HeaderText = "TaskInfoID"
        Me.TaskInfoID.MinimumWidth = 2
        Me.TaskInfoID.Name = "TaskInfoID"
        Me.TaskInfoID.Visible = False
        Me.TaskInfoID.Width = 2
        '
        'frmMaintTaskInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 666)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Controls.Add(Me.dgEq)
        Me.Name = "frmMaintTaskInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -   Maintain Task Info"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgEq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEq As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents TaskCodeInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaskDescrInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaskStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TaskInfoID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
