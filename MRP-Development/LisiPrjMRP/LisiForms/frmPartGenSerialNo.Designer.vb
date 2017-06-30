<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartGenSerialNo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmbPartNumber = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReqSN = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dgSN = New System.Windows.Forms.DataGridView()
        Me.SNID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartSN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartSNStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MPOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdGen = New System.Windows.Forms.Button()
        Me.txtSNTo = New System.Windows.Forms.TextBox()
        Me.txtSNFrom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbPartNumber
        '
        Me.CmbPartNumber.DropDownHeight = 500
        Me.CmbPartNumber.DropDownWidth = 200
        Me.CmbPartNumber.FormattingEnabled = True
        Me.CmbPartNumber.IntegralHeight = False
        Me.CmbPartNumber.Location = New System.Drawing.Point(127, 29)
        Me.CmbPartNumber.Name = "CmbPartNumber"
        Me.CmbPartNumber.Size = New System.Drawing.Size(223, 21)
        Me.CmbPartNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Part Number"
        '
        'txtReqSN
        '
        Me.txtReqSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqSN.Location = New System.Drawing.Point(405, 29)
        Me.txtReqSN.Name = "txtReqSN"
        Me.txtReqSN.ReadOnly = True
        Me.txtReqSN.Size = New System.Drawing.Size(85, 26)
        Me.txtReqSN.TabIndex = 14
        Me.txtReqSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.dgSN)
        Me.Panel1.Controls.Add(Me.CmdGen)
        Me.Panel1.Controls.Add(Me.txtSNTo)
        Me.Panel1.Controls.Add(Me.txtSNFrom)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(531, 828)
        Me.Panel1.TabIndex = 16
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(383, 777)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(127, 34)
        Me.CmdSave.TabIndex = 25
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgSN
        '
        Me.dgSN.AllowUserToAddRows = False
        Me.dgSN.AllowUserToResizeColumns = False
        Me.dgSN.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSN.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSN.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SNID, Me.PartID, Me.PartSN, Me.PartSNStatus, Me.MPOID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSN.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgSN.EnableHeadersVisualStyles = False
        Me.dgSN.Location = New System.Drawing.Point(17, 78)
        Me.dgSN.Name = "dgSN"
        Me.dgSN.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSN.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgSN.RowHeadersWidth = 25
        Me.dgSN.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSN.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgSN.RowTemplate.Height = 20
        Me.dgSN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSN.Size = New System.Drawing.Size(493, 678)
        Me.dgSN.TabIndex = 24
        Me.dgSN.Text = "DataGridView1"
        '
        'SNID
        '
        Me.SNID.HeaderText = "SNID"
        Me.SNID.MinimumWidth = 2
        Me.SNID.Name = "SNID"
        Me.SNID.ReadOnly = True
        Me.SNID.Width = 70
        '
        'PartID
        '
        Me.PartID.HeaderText = "PartID"
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        '
        'PartSN
        '
        Me.PartSN.HeaderText = "PartSN"
        Me.PartSN.Name = "PartSN"
        Me.PartSN.ReadOnly = True
        Me.PartSN.Width = 145
        '
        'PartSNStatus
        '
        Me.PartSNStatus.HeaderText = "S/N Status"
        Me.PartSNStatus.Name = "PartSNStatus"
        Me.PartSNStatus.ReadOnly = True
        '
        'MPOID
        '
        Me.MPOID.HeaderText = "MPOID"
        Me.MPOID.MinimumWidth = 2
        Me.MPOID.Name = "MPOID"
        Me.MPOID.ReadOnly = True
        Me.MPOID.Visible = False
        Me.MPOID.Width = 2
        '
        'CmdGen
        '
        Me.CmdGen.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdGen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdGen.Location = New System.Drawing.Point(383, 23)
        Me.CmdGen.Name = "CmdGen"
        Me.CmdGen.Size = New System.Drawing.Size(127, 34)
        Me.CmdGen.TabIndex = 23
        Me.CmdGen.Text = "Generate S/N"
        Me.CmdGen.UseVisualStyleBackColor = False
        '
        'txtSNTo
        '
        Me.txtSNTo.Location = New System.Drawing.Point(266, 27)
        Me.txtSNTo.Name = "txtSNTo"
        Me.txtSNTo.Size = New System.Drawing.Size(85, 20)
        Me.txtSNTo.TabIndex = 19
        '
        'txtSNFrom
        '
        Me.txtSNFrom.Location = New System.Drawing.Point(128, 29)
        Me.txtSNFrom.Name = "txtSNFrom"
        Me.txtSNFrom.Size = New System.Drawing.Size(87, 20)
        Me.txtSNFrom.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(231, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 20)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "From"
        '
        'frmPartGenSerialNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 910)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtReqSN)
        Me.Controls.Add(Me.CmbPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPartGenSerialNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Generate Serial Numbers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReqSN As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdGen As System.Windows.Forms.Button
    Friend WithEvents txtSNTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSNFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgSN As System.Windows.Forms.DataGridView
    Friend WithEvents SNID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartSN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartSNStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MPOID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
