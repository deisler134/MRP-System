<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartToolBox
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.CmdReset = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmbPart = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgTool = New System.Windows.Forms.DataGridView
        Me.ToolID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolOperID = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.ToolName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dgTool, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmdPrint)
        Me.Panel1.Controls.Add(Me.CmdReset)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.CmbPart)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1018, 55)
        Me.Panel1.TabIndex = 3
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.Khaki
        Me.CmdPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.Location = New System.Drawing.Point(928, 10)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(69, 28)
        Me.CmdPrint.TabIndex = 59
        Me.CmdPrint.Text = "Print"
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.Transparent
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(552, 9)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(63, 29)
        Me.CmdReset.TabIndex = 58
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(723, 9)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(103, 28)
        Me.CmdSave.TabIndex = 57
        Me.CmdSave.Text = "Save "
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmbPart
        '
        Me.CmbPart.DropDownHeight = 600
        Me.CmbPart.DropDownWidth = 200
        Me.CmbPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.IntegralHeight = False
        Me.CmbPart.Location = New System.Drawing.Point(137, 9)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.Size = New System.Drawing.Size(336, 28)
        Me.CmbPart.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number"
        '
        'dgTool
        '
        Me.dgTool.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTool.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgTool.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTool.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTool.ColumnHeadersHeight = 35
        Me.dgTool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgTool.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ToolID, Me.PartID, Me.ToolLine, Me.ToolOperID, Me.ToolName, Me.ToolNotes})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTool.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgTool.Location = New System.Drawing.Point(12, 104)
        Me.dgTool.Name = "dgTool"
        Me.dgTool.RowHeadersWidth = 25
        Me.dgTool.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgTool.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgTool.RowTemplate.Height = 25
        Me.dgTool.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgTool.Size = New System.Drawing.Size(1018, 515)
        Me.dgTool.TabIndex = 20
        Me.dgTool.Text = "DataGridView1"
        '
        'ToolID
        '
        Me.ToolID.HeaderText = "ToolID"
        Me.ToolID.MinimumWidth = 2
        Me.ToolID.Name = "ToolID"
        Me.ToolID.Visible = False
        Me.ToolID.Width = 2
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.MinimumWidth = 2
        Me.PartID.Name = "PartID"
        Me.PartID.Visible = False
        Me.PartID.Width = 2
        '
        'ToolLine
        '
        Me.ToolLine.HeaderText = "Line"
        Me.ToolLine.Name = "ToolLine"
        Me.ToolLine.Width = 70
        '
        'ToolOperID
        '
        Me.ToolOperID.HeaderText = "Operation"
        Me.ToolOperID.MinimumWidth = 2
        Me.ToolOperID.Name = "ToolOperID"
        Me.ToolOperID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ToolOperID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ToolOperID.Width = 200
        '
        'ToolName
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ToolName.DefaultCellStyle = DataGridViewCellStyle2
        Me.ToolName.HeaderText = "Tool Name"
        Me.ToolName.Name = "ToolName"
        Me.ToolName.Width = 300
        '
        'ToolNotes
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ToolNotes.DefaultCellStyle = DataGridViewCellStyle3
        Me.ToolNotes.HeaderText = "Tool Notes"
        Me.ToolNotes.Name = "ToolNotes"
        Me.ToolNotes.Width = 400
        '
        'frmPartToolBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 631)
        Me.Controls.Add(Me.dgTool)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPartToolBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  - Part Tool Box"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgTool, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents dgTool As System.Windows.Forms.DataGridView
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents ToolID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolOperID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToolName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
