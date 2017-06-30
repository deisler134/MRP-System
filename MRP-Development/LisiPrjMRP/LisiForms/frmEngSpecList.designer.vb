<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEngSpecList
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dgSpec = New System.Windows.Forms.DataGridView()
        Me.SpecID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DwgSourceID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Add = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.SpecType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SpecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgRev = New System.Windows.Forms.DataGridView()
        Me.SpecRevID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecIDid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevDateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevCreatedID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SpecRevDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevApprovedID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SpecRevApprDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SwEmail = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtSpecDescr = New System.Windows.Forms.TextBox()
        Me.txtSpecNotes = New System.Windows.Forms.TextBox()
        Me.txtRevNotes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdReset = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRevDescr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbSpecNo = New System.Windows.Forms.ComboBox()
        Me.CmdNew = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbUser = New System.Windows.Forms.ComboBox()
        CType(Me.dgSpec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(635, 2)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 123
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.Transparent
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(882, 2)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(122, 23)
        Me.CmdSave.TabIndex = 122
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgSpec
        '
        Me.dgSpec.AllowUserToDeleteRows = False
        Me.dgSpec.AllowUserToOrderColumns = True
        Me.dgSpec.AllowUserToResizeColumns = False
        Me.dgSpec.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSpec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSpec.ColumnHeadersHeight = 25
        Me.dgSpec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSpec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SpecID, Me.SpecNo, Me.DwgSourceID, Me.Add, Me.SpecType, Me.SpecDescr, Me.SpecNotes, Me.SpecStatus})
        Me.dgSpec.Location = New System.Drawing.Point(12, 82)
        Me.dgSpec.Name = "dgSpec"
        Me.dgSpec.RowHeadersWidth = 25
        Me.dgSpec.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSpec.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSpec.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgSpec.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSpec.RowTemplate.Height = 20
        Me.dgSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSpec.Size = New System.Drawing.Size(1353, 543)
        Me.dgSpec.TabIndex = 124
        Me.dgSpec.Text = "DataGridView1"
        '
        'SpecID
        '
        Me.SpecID.HeaderText = "SpecID"
        Me.SpecID.MinimumWidth = 2
        Me.SpecID.Name = "SpecID"
        Me.SpecID.Visible = False
        Me.SpecID.Width = 2
        '
        'SpecNo
        '
        Me.SpecNo.HeaderText = "Spec / Doc No."
        Me.SpecNo.Name = "SpecNo"
        Me.SpecNo.Width = 140
        '
        'DwgSourceID
        '
        Me.DwgSourceID.HeaderText = "Spec. Source"
        Me.DwgSourceID.MaxDropDownItems = 40
        Me.DwgSourceID.Name = "DwgSourceID"
        Me.DwgSourceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DwgSourceID.Width = 140
        '
        'Add
        '
        Me.Add.HeaderText = ""
        Me.Add.Name = "Add"
        Me.Add.Text = "Add"
        Me.Add.UseColumnTextForButtonValue = True
        Me.Add.Width = 60
        '
        'SpecType
        '
        Me.SpecType.HeaderText = "Spec. Type"
        Me.SpecType.Items.AddRange(New Object() {"F.A.I.", "Matl", "Mfg", "Proc", "QA", "Other"})
        Me.SpecType.Name = "SpecType"
        Me.SpecType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SpecType.Width = 140
        '
        'SpecDescr
        '
        Me.SpecDescr.HeaderText = "Spec. Descr."
        Me.SpecDescr.Name = "SpecDescr"
        Me.SpecDescr.Width = 500
        '
        'SpecNotes
        '
        Me.SpecNotes.HeaderText = "List Binder / Notes"
        Me.SpecNotes.Name = "SpecNotes"
        Me.SpecNotes.Width = 200
        '
        'SpecStatus
        '
        Me.SpecStatus.HeaderText = "Spec. Status"
        Me.SpecStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.SpecStatus.Name = "SpecStatus"
        Me.SpecStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SpecStatus.Width = 120
        '
        'dgRev
        '
        Me.dgRev.AllowUserToDeleteRows = False
        Me.dgRev.AllowUserToOrderColumns = True
        Me.dgRev.AllowUserToResizeColumns = False
        Me.dgRev.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRev.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgRev.ColumnHeadersHeight = 40
        Me.dgRev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgRev.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SpecRevID, Me.SpecIDid, Me.SpecRevNo, Me.SpecRevDateIssue, Me.RevCreatedID, Me.SpecRevDescr, Me.SpecRevNotes, Me.RevApprovedID, Me.SpecRevApprDate, Me.SpecRevStatus, Me.SwEmail})
        Me.dgRev.Location = New System.Drawing.Point(12, 645)
        Me.dgRev.Name = "dgRev"
        Me.dgRev.RowHeadersWidth = 25
        Me.dgRev.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgRev.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgRev.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgRev.RowTemplate.Height = 17
        Me.dgRev.Size = New System.Drawing.Size(1353, 222)
        Me.dgRev.TabIndex = 125
        Me.dgRev.Text = "DataGridView1"
        '
        'SpecRevID
        '
        Me.SpecRevID.HeaderText = "SpecRevID"
        Me.SpecRevID.MinimumWidth = 2
        Me.SpecRevID.Name = "SpecRevID"
        Me.SpecRevID.Visible = False
        Me.SpecRevID.Width = 2
        '
        'SpecIDid
        '
        Me.SpecIDid.HeaderText = "MatlSpecID"
        Me.SpecIDid.MinimumWidth = 2
        Me.SpecIDid.Name = "SpecIDid"
        Me.SpecIDid.Visible = False
        Me.SpecIDid.Width = 2
        '
        'SpecRevNo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SpecRevNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.SpecRevNo.HeaderText = "Rev No"
        Me.SpecRevNo.Name = "SpecRevNo"
        Me.SpecRevNo.Width = 120
        '
        'SpecRevDateIssue
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.SpecRevDateIssue.DefaultCellStyle = DataGridViewCellStyle5
        Me.SpecRevDateIssue.HeaderText = "Rev DateIssue (mm/dd/yyyy)"
        Me.SpecRevDateIssue.Name = "SpecRevDateIssue"
        '
        'RevCreatedID
        '
        Me.RevCreatedID.HeaderText = "Created By"
        Me.RevCreatedID.Name = "RevCreatedID"
        '
        'SpecRevDescr
        '
        Me.SpecRevDescr.HeaderText = "Revision  Description"
        Me.SpecRevDescr.Name = "SpecRevDescr"
        Me.SpecRevDescr.Width = 240
        '
        'SpecRevNotes
        '
        Me.SpecRevNotes.HeaderText = "Review Notes"
        Me.SpecRevNotes.Name = "SpecRevNotes"
        Me.SpecRevNotes.Width = 380
        '
        'RevApprovedID
        '
        Me.RevApprovedID.HeaderText = "Approved By"
        Me.RevApprovedID.Name = "RevApprovedID"
        Me.RevApprovedID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RevApprovedID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'SpecRevApprDate
        '
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.SpecRevApprDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.SpecRevApprDate.HeaderText = "Approved Date (mm/dd/yyyy)"
        Me.SpecRevApprDate.Name = "SpecRevApprDate"
        '
        'SpecRevStatus
        '
        Me.SpecRevStatus.HeaderText = "Rev Status"
        Me.SpecRevStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.SpecRevStatus.Name = "SpecRevStatus"
        Me.SpecRevStatus.Width = 75
        '
        'SwEmail
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SwEmail.DefaultCellStyle = DataGridViewCellStyle7
        Me.SwEmail.HeaderText = "Send Email"
        Me.SwEmail.Name = "SwEmail"
        Me.SwEmail.Width = 80
        '
        'txtSpecDescr
        '
        Me.txtSpecDescr.BackColor = System.Drawing.Color.PowderBlue
        Me.txtSpecDescr.Location = New System.Drawing.Point(1382, 23)
        Me.txtSpecDescr.Multiline = True
        Me.txtSpecDescr.Name = "txtSpecDescr"
        Me.txtSpecDescr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSpecDescr.Size = New System.Drawing.Size(378, 274)
        Me.txtSpecDescr.TabIndex = 126
        '
        'txtSpecNotes
        '
        Me.txtSpecNotes.BackColor = System.Drawing.Color.PowderBlue
        Me.txtSpecNotes.Location = New System.Drawing.Point(1382, 321)
        Me.txtSpecNotes.Multiline = True
        Me.txtSpecNotes.Name = "txtSpecNotes"
        Me.txtSpecNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSpecNotes.Size = New System.Drawing.Size(381, 176)
        Me.txtSpecNotes.TabIndex = 127
        '
        'txtRevNotes
        '
        Me.txtRevNotes.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtRevNotes.Location = New System.Drawing.Point(1382, 621)
        Me.txtRevNotes.Multiline = True
        Me.txtRevNotes.Name = "txtRevNotes"
        Me.txtRevNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRevNotes.Size = New System.Drawing.Size(378, 246)
        Me.txtRevNotes.TabIndex = 128
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1385, 605)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Revision Notes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1382, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Specification Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1382, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Specification Notes"
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(1168, 2)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(75, 23)
        Me.CmdReset.TabIndex = 132
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1382, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Revision Descr"
        '
        'txtRevDescr
        '
        Me.txtRevDescr.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtRevDescr.Location = New System.Drawing.Point(1382, 529)
        Me.txtRevDescr.Multiline = True
        Me.txtRevDescr.Name = "txtRevDescr"
        Me.txtRevDescr.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRevDescr.Size = New System.Drawing.Size(378, 59)
        Me.txtRevDescr.TabIndex = 133
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(107, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Spec / Doc No."
        '
        'CmbSpecNo
        '
        Me.CmbSpecNo.FormattingEnabled = True
        Me.CmbSpecNo.Location = New System.Drawing.Point(12, 40)
        Me.CmbSpecNo.MaxDropDownItems = 40
        Me.CmbSpecNo.Name = "CmbSpecNo"
        Me.CmbSpecNo.Size = New System.Drawing.Size(299, 21)
        Me.CmbSpecNo.TabIndex = 137
        '
        'CmdNew
        '
        Me.CmdNew.BackColor = System.Drawing.Color.Transparent
        Me.CmdNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdNew.Location = New System.Drawing.Point(326, 2)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(122, 23)
        Me.CmdNew.TabIndex = 138
        Me.CmdNew.Text = "New Spec No"
        Me.CmdNew.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 187
        Me.Label6.Text = "User:"
        '
        'CmbUser
        '
        Me.CmbUser.Enabled = False
        Me.CmbUser.FormattingEnabled = True
        Me.CmbUser.Location = New System.Drawing.Point(560, 40)
        Me.CmbUser.Name = "CmbUser"
        Me.CmbUser.Size = New System.Drawing.Size(150, 21)
        Me.CmbUser.TabIndex = 186
        '
        'frmEngSpecList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1777, 882)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CmbUser)
        Me.Controls.Add(Me.CmdNew)
        Me.Controls.Add(Me.CmbSpecNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRevDescr)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRevNotes)
        Me.Controls.Add(Me.txtSpecNotes)
        Me.Controls.Add(Me.txtSpecDescr)
        Me.Controls.Add(Me.dgRev)
        Me.Controls.Add(Me.dgSpec)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Name = "frmEngSpecList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -   SPECIFICATIONS"
        CType(Me.dgSpec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgSpec As System.Windows.Forms.DataGridView
    Friend WithEvents dgRev As System.Windows.Forms.DataGridView
    Friend WithEvents txtSpecDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecNotes As System.Windows.Forms.TextBox
    Friend WithEvents txtRevNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRevDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbSpecNo As System.Windows.Forms.ComboBox
    Friend WithEvents CmdNew As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbUser As System.Windows.Forms.ComboBox
    Friend WithEvents SpecID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DwgSourceID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Add As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SpecType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SpecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SpecRevID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecIDid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevDateIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevCreatedID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SpecRevDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevApprovedID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SpecRevApprDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SwEmail As System.Windows.Forms.DataGridViewButtonColumn
End Class
