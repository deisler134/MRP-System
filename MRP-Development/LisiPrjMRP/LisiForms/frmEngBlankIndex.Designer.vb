<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngBlankIndex
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgIndex = New System.Windows.Forms.DataGridView
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.PNBlankIndex = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PNBlankNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PNBlankIndexID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgIndex
        '
        Me.dgIndex.AllowUserToDeleteRows = False
        Me.dgIndex.AllowUserToOrderColumns = True
        Me.dgIndex.AllowUserToResizeColumns = False
        Me.dgIndex.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgIndex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgIndex.ColumnHeadersHeight = 20
        Me.dgIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgIndex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PNBlankIndex, Me.PNBlankNotes, Me.PNBlankIndexID})
        Me.dgIndex.Location = New System.Drawing.Point(12, 44)
        Me.dgIndex.Name = "dgIndex"
        Me.dgIndex.RowHeadersWidth = 25
        Me.dgIndex.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgIndex.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgIndex.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgIndex.RowTemplate.Height = 17
        Me.dgIndex.Size = New System.Drawing.Size(459, 412)
        Me.dgIndex.TabIndex = 124
        Me.dgIndex.Text = "DataGridView1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(37, 12)
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
        Me.CmdSave.Location = New System.Drawing.Point(360, 12)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 125
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'PNBlankIndex
        '
        Me.PNBlankIndex.HeaderText = "Index"
        Me.PNBlankIndex.Name = "PNBlankIndex"
        Me.PNBlankIndex.Width = 80
        '
        'PNBlankNotes
        '
        Me.PNBlankNotes.HeaderText = "Notes"
        Me.PNBlankNotes.Name = "PNBlankNotes"
        Me.PNBlankNotes.Width = 340
        '
        'PNBlankIndexID
        '
        Me.PNBlankIndexID.HeaderText = "PNBlankIndexID"
        Me.PNBlankIndexID.MinimumWidth = 2
        Me.PNBlankIndexID.Name = "PNBlankIndexID"
        Me.PNBlankIndexID.Visible = False
        Me.PNBlankIndexID.Width = 2
        '
        'frmEngBlankIndex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 467)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.dgIndex)
        Me.Name = "frmEngBlankIndex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  - Maintain Blank Index Reference"
        CType(Me.dgIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgIndex As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents PNBlankIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PNBlankNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PNBlankIndexID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
