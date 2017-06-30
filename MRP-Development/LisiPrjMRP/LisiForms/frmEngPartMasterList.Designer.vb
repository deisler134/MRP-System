<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngPartMasterList
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgEng = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.CmdExport = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdSearch = New System.Windows.Forms.Button
        Me.Label30 = New System.Windows.Forms.Label
        Me.CmbPartClasi = New System.Windows.Forms.ComboBox
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DocNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartClasification = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateApproved = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartControlType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgEng, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgEng
        '
        Me.dgEng.AllowUserToAddRows = False
        Me.dgEng.AllowUserToDeleteRows = False
        Me.dgEng.AllowUserToResizeRows = False
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEng.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEng.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgEng.ColumnHeadersHeight = 45
        Me.dgEng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEng.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumber, Me.PartName, Me.DocNo, Me.SourceName, Me.PartDescCode, Me.PartClasification, Me.DateIssue, Me.DateApproved, Me.PartStatus, Me.PartControlType, Me.PartNotes})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgEng.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgEng.Location = New System.Drawing.Point(12, 71)
        Me.dgEng.Name = "dgEng"
        Me.dgEng.ReadOnly = True
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEng.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgEng.RowHeadersWidth = 25
        Me.dgEng.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEng.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgEng.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgEng.RowTemplate.Height = 18
        Me.dgEng.Size = New System.Drawing.Size(957, 627)
        Me.dgEng.TabIndex = 28
        Me.dgEng.Text = "DataGridView1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Date Issue To (mm/dd/yyyy)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(170, 35)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(122, 20)
        Me.txtDateTo.TabIndex = 44
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Date Issue From (mm/dd/yyyy)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(170, 6)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(122, 20)
        Me.txtDateFrom.TabIndex = 42
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(361, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Part No."
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(464, 6)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(150, 20)
        Me.txtPart.TabIndex = 46
        Me.txtPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExport
        '
        Me.CmdExport.BackgroundImage = Global.LisiPrjMRP.My.Resources.Resources.csv
        Me.CmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdExport.Location = New System.Drawing.Point(905, 12)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(64, 36)
        Me.CmdExport.TabIndex = 50
        Me.CmdExport.UseVisualStyleBackColor = True
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(785, 7)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(112, 21)
        Me.CmdClear.TabIndex = 49
        Me.CmdClear.Text = "Clear Search"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'CmdSearch
        '
        Me.CmdSearch.Location = New System.Drawing.Point(785, 39)
        Me.CmdSearch.Name = "CmdSearch"
        Me.CmdSearch.Size = New System.Drawing.Size(112, 21)
        Me.CmdSearch.TabIndex = 48
        Me.CmdSearch.Text = "Execute Search"
        Me.CmdSearch.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(354, 35)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 23)
        Me.Label30.TabIndex = 173
        Me.Label30.Text = "P/N Clasification"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbPartClasi
        '
        Me.CmbPartClasi.FormattingEnabled = True
        Me.CmbPartClasi.Items.AddRange(New Object() {"Assembly", "Blank", "Component", "Standard"})
        Me.CmbPartClasi.Location = New System.Drawing.Point(464, 35)
        Me.CmbPartClasi.Name = "CmbPartClasi"
        Me.CmbPartClasi.Size = New System.Drawing.Size(150, 21)
        Me.CmbPartClasi.TabIndex = 172
        '
        'PartNumber
        '
        Me.PartNumber.HeaderText = "Part Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        '
        'PartName
        '
        Me.PartName.HeaderText = "Part Name"
        Me.PartName.Name = "PartName"
        Me.PartName.ReadOnly = True
        Me.PartName.Width = 90
        '
        'DocNo
        '
        Me.DocNo.HeaderText = "Doc. No."
        Me.DocNo.Name = "DocNo"
        Me.DocNo.ReadOnly = True
        Me.DocNo.Width = 80
        '
        'SourceName
        '
        Me.SourceName.HeaderText = "Source"
        Me.SourceName.Name = "SourceName"
        Me.SourceName.ReadOnly = True
        Me.SourceName.Width = 70
        '
        'PartDescCode
        '
        Me.PartDescCode.HeaderText = "Part DescCode"
        Me.PartDescCode.Name = "PartDescCode"
        Me.PartDescCode.ReadOnly = True
        '
        'PartClasification
        '
        Me.PartClasification.HeaderText = "Part Clasification"
        Me.PartClasification.Name = "PartClasification"
        Me.PartClasification.ReadOnly = True
        Me.PartClasification.Width = 80
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Issue"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        Me.DateIssue.Width = 80
        '
        'DateApproved
        '
        Me.DateApproved.HeaderText = "Date Approved"
        Me.DateApproved.Name = "DateApproved"
        Me.DateApproved.ReadOnly = True
        Me.DateApproved.Width = 80
        '
        'PartStatus
        '
        Me.PartStatus.HeaderText = "Part Status"
        Me.PartStatus.Name = "PartStatus"
        Me.PartStatus.ReadOnly = True
        Me.PartStatus.Width = 70
        '
        'PartControlType
        '
        Me.PartControlType.HeaderText = "Part Control Type"
        Me.PartControlType.Name = "PartControlType"
        Me.PartControlType.ReadOnly = True
        Me.PartControlType.Width = 70
        '
        'PartNotes
        '
        Me.PartNotes.HeaderText = "Part Notes"
        Me.PartNotes.Name = "PartNotes"
        Me.PartNotes.ReadOnly = True
        '
        'frmEngPartMasterList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 702)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.CmbPartClasi)
        Me.Controls.Add(Me.CmdExport)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdSearch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.dgEng)
        Me.Name = "frmEngPartMasterList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Part Master List"
        CType(Me.dgEng, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgEng As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CmbPartClasi As System.Windows.Forms.ComboBox
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartClasification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateApproved As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartControlType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
