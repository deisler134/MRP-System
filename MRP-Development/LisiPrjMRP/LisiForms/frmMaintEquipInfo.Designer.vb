<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintEquipInfo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgEq = New System.Windows.Forms.DataGridView
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.EquipFileNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.EquipSupp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipContactName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipTel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipFax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipEmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EquipID = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        CustToolBar.Size = New System.Drawing.Size(967, 25)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgEq.ColumnHeadersHeight = 30
        Me.dgEq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EquipFileNo, Me.EquipName, Me.EquipNotes, Me.EquipStatus, Me.EquipSupp, Me.EquipContactName, Me.EquipTel, Me.EquipFax, Me.EquipEmail, Me.EquipID})
        Me.dgEq.Location = New System.Drawing.Point(12, 38)
        Me.dgEq.Name = "dgEq"
        Me.dgEq.RowHeadersWidth = 25
        Me.dgEq.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgEq.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgEq.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEq.RowTemplate.Height = 20
        Me.dgEq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgEq.Size = New System.Drawing.Size(941, 596)
        Me.dgEq.TabIndex = 124
        Me.dgEq.Text = "DataGridView1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(755, 0)
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
        Me.CmdSave.Location = New System.Drawing.Point(100, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 126
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'EquipFileNo
        '
        Me.EquipFileNo.HeaderText = "File N°"
        Me.EquipFileNo.Name = "EquipFileNo"
        Me.EquipFileNo.Width = 60
        '
        'EquipName
        '
        Me.EquipName.HeaderText = "Machine / Equipment"
        Me.EquipName.Name = "EquipName"
        Me.EquipName.Width = 150
        '
        'EquipNotes
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquipNotes.DefaultCellStyle = DataGridViewCellStyle2
        Me.EquipNotes.HeaderText = "Notes"
        Me.EquipNotes.Name = "EquipNotes"
        Me.EquipNotes.Width = 200
        '
        'EquipStatus
        '
        Me.EquipStatus.HeaderText = "Status"
        Me.EquipStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.EquipStatus.Name = "EquipStatus"
        Me.EquipStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquipStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.EquipStatus.Width = 70
        '
        'EquipSupp
        '
        Me.EquipSupp.HeaderText = "Supplier"
        Me.EquipSupp.Name = "EquipSupp"
        Me.EquipSupp.Width = 80
        '
        'EquipContactName
        '
        Me.EquipContactName.HeaderText = "ContactName"
        Me.EquipContactName.Name = "EquipContactName"
        Me.EquipContactName.Width = 80
        '
        'EquipTel
        '
        Me.EquipTel.HeaderText = "Tel"
        Me.EquipTel.Name = "EquipTel"
        Me.EquipTel.Width = 80
        '
        'EquipFax
        '
        Me.EquipFax.HeaderText = "Fax"
        Me.EquipFax.Name = "EquipFax"
        Me.EquipFax.Width = 80
        '
        'EquipEmail
        '
        Me.EquipEmail.HeaderText = "Email"
        Me.EquipEmail.Name = "EquipEmail"
        Me.EquipEmail.Width = 90
        '
        'EquipID
        '
        Me.EquipID.HeaderText = "EquipID"
        Me.EquipID.MinimumWidth = 2
        Me.EquipID.Name = "EquipID"
        Me.EquipID.Visible = False
        Me.EquipID.Width = 2
        '
        'frmMaintEquipInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 646)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Controls.Add(Me.dgEq)
        Me.Name = "frmMaintEquipInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -   Maintain Machinery and Equipment Info"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgEq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEq As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents EquipFileNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents EquipSupp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipContactName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipFax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
