<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StPartMaster
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdReset = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdNew = New System.Windows.Forms.Button
        Me.CmbPartNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPartNo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtPartName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgPart = New System.Windows.Forms.DataGridView
        Me.PrtListPNRelID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrtListPNBlanksID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrtListPNStdCompID = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.CmdAddPN = New System.Windows.Forms.DataGridViewButtonColumn
        Me.PrtListPNBlankName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrtListPNRelNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrtListPNRelStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dgSupp = New System.Windows.Forms.DataGridView
        Me.CageCode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.SuppName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CmdAdd = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.dgPart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(1007, 22)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(75, 23)
        Me.CmdReset.TabIndex = 10
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(877, 22)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 9
        Me.CmdSave.Text = "Save Part#"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(579, 22)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 8
        Me.CmdEdit.Text = "Edit Part#"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdNew
        '
        Me.CmdNew.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNew.Location = New System.Drawing.Point(466, 22)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(75, 23)
        Me.CmdNew.TabIndex = 7
        Me.CmdNew.Text = "New Part#"
        Me.CmdNew.UseVisualStyleBackColor = False
        '
        'CmbPartNumber
        '
        Me.CmbPartNumber.DropDownHeight = 700
        Me.CmbPartNumber.DropDownWidth = 200
        Me.CmbPartNumber.FormattingEnabled = True
        Me.CmbPartNumber.IntegralHeight = False
        Me.CmbPartNumber.Location = New System.Drawing.Point(133, 24)
        Me.CmbPartNumber.Name = "CmbPartNumber"
        Me.CmbPartNumber.Size = New System.Drawing.Size(226, 21)
        Me.CmbPartNumber.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "NSN Number:"
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(133, 77)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(226, 20)
        Me.txtPartNo.TabIndex = 156
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.Location = New System.Drawing.Point(13, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 23)
        Me.Label22.TabIndex = 157
        Me.Label22.Text = "NSN Number:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(133, 103)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(226, 20)
        Me.txtPartName.TabIndex = 158
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(13, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 23)
        Me.Label5.TabIndex = 159
        Me.Label5.Text = "Item Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgPart
        '
        Me.dgPart.AllowUserToDeleteRows = False
        Me.dgPart.AllowUserToOrderColumns = True
        Me.dgPart.AllowUserToResizeColumns = False
        Me.dgPart.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPart.ColumnHeadersHeight = 20
        Me.dgPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrtListPNRelID, Me.PrtListPNBlanksID, Me.PrtListPNStdCompID, Me.CmdAddPN, Me.PrtListPNBlankName, Me.PrtListPNRelNotes, Me.PrtListPNRelStatus})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPart.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgPart.Location = New System.Drawing.Point(12, 157)
        Me.dgPart.Name = "dgPart"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgPart.RowHeadersWidth = 25
        Me.dgPart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgPart.RowTemplate.Height = 20
        Me.dgPart.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgPart.Size = New System.Drawing.Size(859, 470)
        Me.dgPart.TabIndex = 160
        Me.dgPart.Text = "DataGridView2"
        '
        'PrtListPNRelID
        '
        Me.PrtListPNRelID.HeaderText = "PNRelID"
        Me.PrtListPNRelID.MinimumWidth = 2
        Me.PrtListPNRelID.Name = "PrtListPNRelID"
        Me.PrtListPNRelID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrtListPNRelID.Visible = False
        Me.PrtListPNRelID.Width = 2
        '
        'PrtListPNBlanksID
        '
        Me.PrtListPNBlanksID.HeaderText = "PrtListPNBlanksID"
        Me.PrtListPNBlanksID.MinimumWidth = 2
        Me.PrtListPNBlanksID.Name = "PrtListPNBlanksID"
        Me.PrtListPNBlanksID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrtListPNBlanksID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrtListPNBlanksID.Visible = False
        Me.PrtListPNBlanksID.Width = 2
        '
        'PrtListPNStdCompID
        '
        Me.PrtListPNStdCompID.HeaderText = "Part Number"
        Me.PrtListPNStdCompID.Name = "PrtListPNStdCompID"
        Me.PrtListPNStdCompID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrtListPNStdCompID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PrtListPNStdCompID.Width = 200
        '
        'CmdAddPN
        '
        Me.CmdAddPN.FillWeight = 80.0!
        Me.CmdAddPN.HeaderText = "New Part"
        Me.CmdAddPN.Name = "CmdAddPN"
        Me.CmdAddPN.Width = 80
        '
        'PrtListPNBlankName
        '
        Me.PrtListPNBlankName.HeaderText = "Description"
        Me.PrtListPNBlankName.Name = "PrtListPNBlankName"
        Me.PrtListPNBlankName.Width = 230
        '
        'PrtListPNRelNotes
        '
        Me.PrtListPNRelNotes.HeaderText = "Notes"
        Me.PrtListPNRelNotes.Name = "PrtListPNRelNotes"
        Me.PrtListPNRelNotes.Width = 200
        '
        'PrtListPNRelStatus
        '
        Me.PrtListPNRelStatus.HeaderText = "Status"
        Me.PrtListPNRelStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.PrtListPNRelStatus.Name = "PrtListPNRelStatus"
        Me.PrtListPNRelStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrtListPNRelStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgSupp
        '
        Me.dgSupp.AllowUserToDeleteRows = False
        Me.dgSupp.AllowUserToOrderColumns = True
        Me.dgSupp.AllowUserToResizeColumns = False
        Me.dgSupp.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSupp.ColumnHeadersHeight = 20
        Me.dgSupp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSupp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CageCode, Me.SuppName, Me.CmdAdd})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSupp.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgSupp.Location = New System.Drawing.Point(877, 157)
        Me.dgSupp.Name = "dgSupp"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSupp.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgSupp.RowHeadersWidth = 25
        Me.dgSupp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSupp.RowTemplate.Height = 20
        Me.dgSupp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSupp.Size = New System.Drawing.Size(343, 208)
        Me.dgSupp.TabIndex = 161
        Me.dgSupp.Text = "DataGridView2"
        '
        'CageCode
        '
        Me.CageCode.HeaderText = "Cage Code"
        Me.CageCode.Name = "CageCode"
        Me.CageCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CageCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'SuppName
        '
        Me.SuppName.HeaderText = "SuppName"
        Me.SuppName.Name = "SuppName"
        '
        'CmdAdd
        '
        Me.CmdAdd.HeaderText = "New Supplier"
        Me.CmdAdd.Name = "CmdAdd"
        '
        'StPartMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 635)
        Me.Controls.Add(Me.dgSupp)
        Me.Controls.Add(Me.dgPart)
        Me.Controls.Add(Me.txtPartName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdNew)
        Me.Controls.Add(Me.CmbPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StPartMaster"
        Me.Text = "StPartMaster"
        CType(Me.dgPart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSupp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdNew As System.Windows.Forms.Button
    Friend WithEvents CmbPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPartName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgPart As System.Windows.Forms.DataGridView
    Friend WithEvents PrtListPNRelID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrtListPNBlanksID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrtListPNStdCompID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CmdAddPN As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents PrtListPNBlankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrtListPNRelNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrtListPNRelStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dgSupp As System.Windows.Forms.DataGridView
    Friend WithEvents CageCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SuppName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdAdd As System.Windows.Forms.DataGridViewButtonColumn
End Class
