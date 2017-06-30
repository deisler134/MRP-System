<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOrderEntryPutMachSTDCost
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgGrid = New System.Windows.Forms.DataGridView()
        Me.DIAFinish = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIARow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSW = New System.Windows.Forms.TextBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgGrid
        '
        Me.dgGrid.AllowUserToAddRows = False
        Me.dgGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DIAFinish, Me.DIARow, Me.DIAPrice, Me.IDCost})
        Me.dgGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgGrid.Location = New System.Drawing.Point(0, 0)
        Me.dgGrid.Name = "dgGrid"
        Me.dgGrid.ReadOnly = True
        Me.dgGrid.Size = New System.Drawing.Size(374, 535)
        Me.dgGrid.TabIndex = 0
        Me.dgGrid.Text = "DataGridView1"
        '
        'DIAFinish
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DIAFinish.DefaultCellStyle = DataGridViewCellStyle2
        Me.DIAFinish.HeaderText = "DIA_Finish"
        Me.DIAFinish.Name = "DIAFinish"
        Me.DIAFinish.ReadOnly = True
        '
        'DIARow
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DIARow.DefaultCellStyle = DataGridViewCellStyle3
        Me.DIARow.HeaderText = "DIA__RM"
        Me.DIARow.Name = "DIARow"
        Me.DIARow.ReadOnly = True
        '
        'DIAPrice
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DIAPrice.DefaultCellStyle = DataGridViewCellStyle4
        Me.DIAPrice.HeaderText = "Mach_Cost"
        Me.DIAPrice.Name = "DIAPrice"
        Me.DIAPrice.ReadOnly = True
        '
        'IDCost
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IDCost.DefaultCellStyle = DataGridViewCellStyle5
        Me.IDCost.HeaderText = "IDCost"
        Me.IDCost.Name = "IDCost"
        Me.IDCost.ReadOnly = True
        Me.IDCost.Visible = False
        '
        'txtSW
        '
        Me.txtSW.Location = New System.Drawing.Point(33, 124)
        Me.txtSW.Name = "txtSW"
        Me.txtSW.Size = New System.Drawing.Size(63, 20)
        Me.txtSW.TabIndex = 2
        Me.txtSW.Visible = False
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(292, 123)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(63, 20)
        Me.txtRow.TabIndex = 3
        Me.txtRow.Visible = False
        '
        'frmOrderEntryPutMachSTDCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 535)
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.txtSW)
        Me.Controls.Add(Me.dgGrid)
        Me.Name = "frmOrderEntryPutMachSTDCost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrderEntryPutMachSTDCost.vb"
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgGrid As System.Windows.Forms.DataGridView
    Friend WithEvents txtSW As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
    Friend WithEvents DIAFinish As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIARow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDCost As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
