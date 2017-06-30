<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintProductCatalog
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
        Me.dgEq = New System.Windows.Forms.DataGridView
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.ProductDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        CustToolBar.Size = New System.Drawing.Size(582, 25)
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgEq.ColumnHeadersHeight = 30
        Me.dgEq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductDescr, Me.ProductStatus, Me.ProductID})
        Me.dgEq.Location = New System.Drawing.Point(12, 38)
        Me.dgEq.Name = "dgEq"
        Me.dgEq.RowHeadersWidth = 25
        Me.dgEq.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgEq.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgEq.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEq.RowTemplate.Height = 20
        Me.dgEq.Size = New System.Drawing.Size(553, 651)
        Me.dgEq.TabIndex = 124
        Me.dgEq.Text = "DataGridView1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(490, 0)
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
        Me.CmdSave.Location = New System.Drawing.Point(12, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 126
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'ProductDescr
        '
        Me.ProductDescr.HeaderText = "Product/Component Name"
        Me.ProductDescr.Name = "ProductDescr"
        Me.ProductDescr.Width = 400
        '
        'ProductStatus
        '
        Me.ProductStatus.HeaderText = "Status"
        Me.ProductStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.ProductStatus.Name = "ProductStatus"
        Me.ProductStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ProductID
        '
        Me.ProductID.HeaderText = "ProductID"
        Me.ProductID.MinimumWidth = 2
        Me.ProductID.Name = "ProductID"
        Me.ProductID.Visible = False
        Me.ProductID.Width = 2
        '
        'frmMaintProductCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 701)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Controls.Add(Me.dgEq)
        Me.Name = "frmMaintProductCatalog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -   Maintain Products/Components"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgEq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEq As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents ProductDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ProductID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
