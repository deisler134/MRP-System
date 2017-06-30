<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartCreateCrossRef
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdExec = New System.Windows.Forms.Button()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.lblDia = New System.Windows.Forms.Label()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbPrefix = New System.Windows.Forms.ComboBox()
        Me.CmbDIA = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbFinish = New System.Windows.Forms.ComboBox()
        Me.CmdReset = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dgPart = New System.Windows.Forms.DataGridView()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrossPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwNewPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrossPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwCrossPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDIAInch = New System.Windows.Forms.TextBox()
        Me.CmbFrom = New System.Windows.Forms.ComboBox()
        Me.CmbTo = New System.Windows.Forms.ComboBox()
        Me.CmdSearch = New System.Windows.Forms.Button()
        Me.CmbACU = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbXY = New System.Windows.Forms.ComboBox()
        CType(Me.dgPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdExec
        '
        Me.CmdExec.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdExec.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdExec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExec.Location = New System.Drawing.Point(717, 124)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(196, 23)
        Me.CmdExec.TabIndex = 185
        Me.CmdExec.Text = "GENERATE "
        Me.CmdExec.UseVisualStyleBackColor = False
        '
        'lblLength
        '
        Me.lblLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLength.ForeColor = System.Drawing.Color.Maroon
        Me.lblLength.Location = New System.Drawing.Point(643, 40)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(94, 16)
        Me.lblLength.TabIndex = 184
        Me.lblLength.Text = "Part Length From" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDia
        '
        Me.lblDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDia.ForeColor = System.Drawing.Color.Maroon
        Me.lblDia.Location = New System.Drawing.Point(150, 41)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(91, 16)
        Me.lblDia.TabIndex = 182
        Me.lblDia.Text = "Nominal DIA " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrefix
        '
        Me.lblPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.ForeColor = System.Drawing.Color.Maroon
        Me.lblPrefix.Location = New System.Drawing.Point(36, 41)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(96, 16)
        Me.lblPrefix.TabIndex = 180
        Me.lblPrefix.Text = "Basic Number"
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(402, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 187
        Me.Label1.Text = "Part Finishing"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(845, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 52)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Shank Oversize" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "============" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "X = .0156" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Y = .0312"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbPrefix
        '
        Me.CmbPrefix.DropDownHeight = 500
        Me.CmbPrefix.DropDownWidth = 200
        Me.CmbPrefix.FormattingEnabled = True
        Me.CmbPrefix.IntegralHeight = False
        Me.CmbPrefix.Location = New System.Drawing.Point(12, 65)
        Me.CmbPrefix.Name = "CmbPrefix"
        Me.CmbPrefix.Size = New System.Drawing.Size(135, 21)
        Me.CmbPrefix.Sorted = True
        Me.CmbPrefix.TabIndex = 190
        '
        'CmbDIA
        '
        Me.CmbDIA.DropDownWidth = 200
        Me.CmbDIA.FormattingEnabled = True
        Me.CmbDIA.Items.AddRange(New Object() {"3", "4", "5", "6", "7", "8", "9", "10", "12", "14", "16", "18", "20", "22", "24"})
        Me.CmbDIA.Location = New System.Drawing.Point(153, 65)
        Me.CmbDIA.Name = "CmbDIA"
        Me.CmbDIA.Size = New System.Drawing.Size(89, 21)
        Me.CmbDIA.TabIndex = 191
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(747, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "Part Length To"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbFinish
        '
        Me.CmbFinish.DropDownHeight = 300
        Me.CmbFinish.DropDownWidth = 500
        Me.CmbFinish.FormattingEnabled = True
        Me.CmbFinish.IntegralHeight = False
        Me.CmbFinish.Location = New System.Drawing.Point(360, 65)
        Me.CmbFinish.Name = "CmbFinish"
        Me.CmbFinish.Size = New System.Drawing.Size(165, 21)
        Me.CmbFinish.TabIndex = 195
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(939, 11)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(161, 23)
        Me.CmdReset.TabIndex = 196
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightBlue
        Me.CmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(1005, 115)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(72, 40)
        Me.CmdSave.TabIndex = 197
        Me.CmdSave.Text = "S  A  V  E"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgPart
        '
        Me.dgPart.AllowUserToAddRows = False
        Me.dgPart.AllowUserToDeleteRows = False
        Me.dgPart.AllowUserToResizeRows = False
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgPart.ColumnHeadersHeight = 45
        Me.dgPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumber, Me.PartDescCode, Me.PartName, Me.CrossPN, Me.PartID, Me.SwNewPartID, Me.CrossPartID, Me.SwCrossPartID})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgPart.Location = New System.Drawing.Point(12, 103)
        Me.dgPart.Name = "dgPart"
        Me.dgPart.ReadOnly = True
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgPart.RowHeadersWidth = 25
        Me.dgPart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPart.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgPart.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgPart.RowTemplate.Height = 18
        Me.dgPart.Size = New System.Drawing.Size(662, 581)
        Me.dgPart.TabIndex = 198
        Me.dgPart.Text = "DataGridView1"
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        Me.PartNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartNumber.Width = 120
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "Description Code"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.ReadOnly = True
        Me.PartDescCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartDescCode.Width = 200
        '
        'PartName
        '
        Me.PartName.HeaderText = "Part Name"
        Me.PartName.Name = "PartName"
        Me.PartName.ReadOnly = True
        Me.PartName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartName.Width = 180
        '
        'CrossPN
        '
        Me.CrossPN.HeaderText = "Cross PN"
        Me.CrossPN.Name = "CrossPN"
        Me.CrossPN.ReadOnly = True
        Me.CrossPN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CrossPN.Width = 120
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.MinimumWidth = 2
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        Me.PartID.Visible = False
        Me.PartID.Width = 2
        '
        'SwNewPartID
        '
        Me.SwNewPartID.HeaderText = "SwNewPartID"
        Me.SwNewPartID.MinimumWidth = 2
        Me.SwNewPartID.Name = "SwNewPartID"
        Me.SwNewPartID.ReadOnly = True
        Me.SwNewPartID.Visible = False
        Me.SwNewPartID.Width = 2
        '
        'CrossPartID
        '
        Me.CrossPartID.HeaderText = "CrossPartID"
        Me.CrossPartID.MinimumWidth = 2
        Me.CrossPartID.Name = "CrossPartID"
        Me.CrossPartID.ReadOnly = True
        Me.CrossPartID.Visible = False
        Me.CrossPartID.Width = 2
        '
        'SwCrossPartID
        '
        Me.SwCrossPartID.HeaderText = "SwCrossPartID"
        Me.SwCrossPartID.MinimumWidth = 2
        Me.SwCrossPartID.Name = "SwCrossPartID"
        Me.SwCrossPartID.ReadOnly = True
        Me.SwCrossPartID.Visible = False
        Me.SwCrossPartID.Width = 2
        '
        'txtDIAInch
        '
        Me.txtDIAInch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIAInch.ForeColor = System.Drawing.Color.Maroon
        Me.txtDIAInch.Location = New System.Drawing.Point(165, 14)
        Me.txtDIAInch.Name = "txtDIAInch"
        Me.txtDIAInch.ReadOnly = True
        Me.txtDIAInch.Size = New System.Drawing.Size(64, 20)
        Me.txtDIAInch.TabIndex = 199
        Me.txtDIAInch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbFrom
        '
        Me.CmbFrom.DropDownHeight = 300
        Me.CmbFrom.DropDownWidth = 200
        Me.CmbFrom.FormattingEnabled = True
        Me.CmbFrom.IntegralHeight = False
        Me.CmbFrom.Items.AddRange(New Object() {"6", "8", "10", "16"})
        Me.CmbFrom.Location = New System.Drawing.Point(641, 64)
        Me.CmbFrom.Name = "CmbFrom"
        Me.CmbFrom.Size = New System.Drawing.Size(96, 21)
        Me.CmbFrom.TabIndex = 200
        '
        'CmbTo
        '
        Me.CmbTo.DropDownHeight = 300
        Me.CmbTo.DropDownWidth = 200
        Me.CmbTo.FormattingEnabled = True
        Me.CmbTo.IntegralHeight = False
        Me.CmbTo.Items.AddRange(New Object() {"20", "24", "36", "48", "60", "68", "71", "72", "74", "88", "89", "94", "92", "91", "100"})
        Me.CmbTo.Location = New System.Drawing.Point(743, 64)
        Me.CmbTo.Name = "CmbTo"
        Me.CmbTo.Size = New System.Drawing.Size(96, 21)
        Me.CmbTo.TabIndex = 201
        '
        'CmdSearch
        '
        Me.CmdSearch.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSearch.Location = New System.Drawing.Point(248, 65)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(106, 23)
        Me.CmdSearch.TabIndex = 202
        Me.CmdSearch.Text = "Search Parts"
        Me.CmdSearch.UseVisualStyleBackColor = False
        '
        'CmbACU
        '
        Me.CmbACU.DropDownHeight = 300
        Me.CmbACU.DropDownWidth = 200
        Me.CmbACU.FormattingEnabled = True
        Me.CmbACU.IntegralHeight = False
        Me.CmbACU.Items.AddRange(New Object() {"", "ACU", "AWU"})
        Me.CmbACU.Location = New System.Drawing.Point(539, 64)
        Me.CmbACU.Name = "CmbACU"
        Me.CmbACU.Size = New System.Drawing.Size(75, 21)
        Me.CmbACU.TabIndex = 204
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(550, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "ACU/AWU"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbXY
        '
        Me.CmbXY.DropDownHeight = 300
        Me.CmbXY.DropDownWidth = 200
        Me.CmbXY.FormattingEnabled = True
        Me.CmbXY.IntegralHeight = False
        Me.CmbXY.Items.AddRange(New Object() {"No", "Yes"})
        Me.CmbXY.Location = New System.Drawing.Point(939, 64)
        Me.CmbXY.Name = "CmbXY"
        Me.CmbXY.Size = New System.Drawing.Size(68, 21)
        Me.CmbXY.TabIndex = 205
        '
        'frmPartCreateCrossRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 696)
        Me.Controls.Add(Me.CmbXY)
        Me.Controls.Add(Me.CmbACU)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.CmbTo)
        Me.Controls.Add(Me.CmbFrom)
        Me.Controls.Add(Me.txtDIAInch)
        Me.Controls.Add(Me.dgPart)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.CmbFinish)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbDIA)
        Me.Controls.Add(Me.CmbPrefix)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdExec)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.lblDia)
        Me.Controls.Add(Me.lblPrefix)
        Me.Name = "frmPartCreateCrossRef"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  - BOEING PART CODING"
        CType(Me.dgPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents lblDia As System.Windows.Forms.Label
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbPrefix As System.Windows.Forms.ComboBox
    Friend WithEvents CmbDIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbFinish As System.Windows.Forms.ComboBox
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgPart As System.Windows.Forms.DataGridView
    Friend WithEvents txtDIAInch As System.Windows.Forms.TextBox
    Friend WithEvents CmbFrom As System.Windows.Forms.ComboBox
    Friend WithEvents CmbTo As System.Windows.Forms.ComboBox
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents CmbACU As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrossPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwNewPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrossPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwCrossPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmbXY As System.Windows.Forms.ComboBox
End Class
