<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngBlankDia
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.dgIndex = New System.Windows.Forms.DataGridView
        Me.PNBlankDia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PNBlankDiaID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(49, 10)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 129
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(324, 10)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 128
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgIndex
        '
        Me.dgIndex.AllowUserToDeleteRows = False
        Me.dgIndex.AllowUserToOrderColumns = True
        Me.dgIndex.AllowUserToResizeColumns = False
        Me.dgIndex.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgIndex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgIndex.ColumnHeadersHeight = 20
        Me.dgIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgIndex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PNBlankDia, Me.PNBlankDiaID})
        Me.dgIndex.Location = New System.Drawing.Point(22, 42)
        Me.dgIndex.Name = "dgIndex"
        Me.dgIndex.RowHeadersWidth = 25
        Me.dgIndex.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgIndex.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgIndex.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgIndex.RowTemplate.Height = 17
        Me.dgIndex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgIndex.Size = New System.Drawing.Size(418, 473)
        Me.dgIndex.TabIndex = 127
        Me.dgIndex.Text = "DataGridView1"
        '
        'PNBlankDia
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PNBlankDia.DefaultCellStyle = DataGridViewCellStyle4
        Me.PNBlankDia.HeaderText = "Blank Dia"
        Me.PNBlankDia.Name = "PNBlankDia"
        Me.PNBlankDia.Width = 380
        '
        'PNBlankDiaID
        '
        Me.PNBlankDiaID.HeaderText = "PNBlankDiaID"
        Me.PNBlankDiaID.MinimumWidth = 2
        Me.PNBlankDiaID.Name = "PNBlankDiaID"
        Me.PNBlankDiaID.Visible = False
        Me.PNBlankDiaID.Width = 2
        '
        'frmEngBlankDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 527)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.dgIndex)
        Me.Name = "frmEngBlankDia"
        Me.Text = "LISI AEROSPACE CANADA  - Maintain Blank Dia Reference"
        CType(Me.dgIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgIndex As System.Windows.Forms.DataGridView
    Friend WithEvents PNBlankDia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PNBlankDiaID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
