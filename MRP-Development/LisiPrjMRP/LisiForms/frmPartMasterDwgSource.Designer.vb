<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPartMasterDwgSource
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
        Me.dg = New System.Windows.Forms.DataGridView
        Me.DwgSourceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LisiBinder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
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
        CustToolBar.Size = New System.Drawing.Size(550, 25)
        CustToolBar.TabIndex = 65
        CustToolBar.Text = "BindingNavigator1"
        '
        'dg
        '
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AllowUserToOrderColumns = True
        Me.dg.ColumnHeadersHeight = 20
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DwgSourceID, Me.SourceName, Me.LisiBinder})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 25)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersWidth = 25
        Me.dg.Size = New System.Drawing.Size(550, 478)
        Me.dg.TabIndex = 120
        Me.dg.Text = "DataGridView1"
        '
        'DwgSourceID
        '
        Me.DwgSourceID.HeaderText = "DwgSourceID"
        Me.DwgSourceID.MinimumWidth = 2
        Me.DwgSourceID.Name = "DwgSourceID"
        Me.DwgSourceID.Visible = False
        Me.DwgSourceID.Width = 2
        '
        'SourceName
        '
        Me.SourceName.HeaderText = "SourceName"
        Me.SourceName.Name = "SourceName"
        Me.SourceName.Width = 300
        '
        'LisiBinder
        '
        Me.LisiBinder.HeaderText = "LisiBinder"
        Me.LisiBinder.Name = "LisiBinder"
        Me.LisiBinder.Width = 220
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(131, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 122
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(25, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 121
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'frmPartMasterDwgSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 503)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmPartMasterDwgSource"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPartMasterDwgSource"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DwgSourceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LisiBinder As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
