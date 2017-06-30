<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEngMatlType
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
        Me.components = New System.ComponentModel.Container()
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dgMat = New System.Windows.Forms.DataGridView()
        Me.MatlID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlFamily = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlDensity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlLeadTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.ButtActive = New System.Windows.Forms.RadioButton()
        Me.ButtAll = New System.Windows.Forms.RadioButton()
        Me.dgDet = New System.Windows.Forms.DataGridView()
        Me.MatlDetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlIDDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatDetKSI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatColorCoding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatDetSpecs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatDetNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatDetStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dgSpec = New System.Windows.Forms.DataGridView()
        Me.MatlSpecID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatlDetIDSpec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SwAdd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.SwRemove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.SpecID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SourceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSpecRev = New System.Windows.Forms.DataGridView()
        Me.SpecRevID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecIDRev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevDateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecRevStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdReset = New System.Windows.Forms.Button()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSpec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSpecRev, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(1684, 25)
        CustToolBar.TabIndex = 64
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(27, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 118
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgMat
        '
        Me.dgMat.AllowUserToDeleteRows = False
        Me.dgMat.AllowUserToOrderColumns = True
        Me.dgMat.AllowUserToResizeColumns = False
        Me.dgMat.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMat.ColumnHeadersHeight = 32
        Me.dgMat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgMat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MatlID, Me.MatlType, Me.MatlFamily, Me.MatlDensity, Me.MatlLeadTime, Me.MatlStatus})
        Me.dgMat.Location = New System.Drawing.Point(8, 29)
        Me.dgMat.Name = "dgMat"
        Me.dgMat.RowHeadersWidth = 25
        Me.dgMat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgMat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMat.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgMat.RowTemplate.Height = 17
        Me.dgMat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgMat.Size = New System.Drawing.Size(593, 840)
        Me.dgMat.TabIndex = 119
        Me.dgMat.Text = "DataGridView1"
        '
        'MatlID
        '
        Me.MatlID.HeaderText = "MatlID"
        Me.MatlID.MinimumWidth = 2
        Me.MatlID.Name = "MatlID"
        Me.MatlID.Visible = False
        Me.MatlID.Width = 2
        '
        'MatlType
        '
        Me.MatlType.HeaderText = "Material Type"
        Me.MatlType.Name = "MatlType"
        Me.MatlType.Width = 120
        '
        'MatlFamily
        '
        Me.MatlFamily.HeaderText = "Matl Family"
        Me.MatlFamily.Name = "MatlFamily"
        Me.MatlFamily.Width = 180
        '
        'MatlDensity
        '
        Me.MatlDensity.HeaderText = "Matl Density"
        Me.MatlDensity.Name = "MatlDensity"
        Me.MatlDensity.Width = 60
        '
        'MatlLeadTime
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatlLeadTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.MatlLeadTime.HeaderText = "Purchasing LeadTime  (Weeks)"
        Me.MatlLeadTime.Name = "MatlLeadTime"
        '
        'MatlStatus
        '
        Me.MatlStatus.HeaderText = "Matl Status"
        Me.MatlStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.MatlStatus.Name = "MatlStatus"
        Me.MatlStatus.ReadOnly = True
        Me.MatlStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MatlStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MatlStatus.Width = 80
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(164, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 120
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'ButtActive
        '
        Me.ButtActive.AutoSize = True
        Me.ButtActive.Location = New System.Drawing.Point(442, 3)
        Me.ButtActive.Name = "ButtActive"
        Me.ButtActive.Size = New System.Drawing.Size(55, 17)
        Me.ButtActive.TabIndex = 123
        Me.ButtActive.Text = "Active"
        '
        'ButtAll
        '
        Me.ButtAll.AutoSize = True
        Me.ButtAll.Location = New System.Drawing.Point(510, 3)
        Me.ButtAll.Name = "ButtAll"
        Me.ButtAll.Size = New System.Drawing.Size(36, 17)
        Me.ButtAll.TabIndex = 124
        Me.ButtAll.Text = "All"
        '
        'dgDet
        '
        Me.dgDet.AllowUserToDeleteRows = False
        Me.dgDet.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDet.ColumnHeadersHeight = 32
        Me.dgDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MatlDetID, Me.MatlIDDet, Me.MatType, Me.MatDetKSI, Me.MatColorCoding, Me.MatDetSpecs, Me.MatDetNotes, Me.MatDetStatus})
        Me.dgDet.Location = New System.Drawing.Point(608, 27)
        Me.dgDet.Name = "dgDet"
        Me.dgDet.RowHeadersWidth = 25
        Me.dgDet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDet.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgDet.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgDet.RowTemplate.Height = 17
        Me.dgDet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgDet.Size = New System.Drawing.Size(1066, 454)
        Me.dgDet.TabIndex = 125
        Me.dgDet.Text = "DataGridView1"
        '
        'MatlDetID
        '
        Me.MatlDetID.HeaderText = "MatlDetID"
        Me.MatlDetID.MinimumWidth = 2
        Me.MatlDetID.Name = "MatlDetID"
        Me.MatlDetID.Visible = False
        Me.MatlDetID.Width = 2
        '
        'MatlIDDet
        '
        Me.MatlIDDet.HeaderText = "MatlID"
        Me.MatlIDDet.MinimumWidth = 2
        Me.MatlIDDet.Name = "MatlIDDet"
        Me.MatlIDDet.Visible = False
        Me.MatlIDDet.Width = 2
        '
        'MatType
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatType.DefaultCellStyle = DataGridViewCellStyle4
        Me.MatType.HeaderText = "Material Article"
        Me.MatType.Name = "MatType"
        '
        'MatDetKSI
        '
        Me.MatDetKSI.HeaderText = "UTS / KSI"
        Me.MatDetKSI.Name = "MatDetKSI"
        Me.MatDetKSI.Width = 220
        '
        'MatColorCoding
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MatColorCoding.DefaultCellStyle = DataGridViewCellStyle5
        Me.MatColorCoding.HeaderText = "Material Color Coding"
        Me.MatColorCoding.Name = "MatColorCoding"
        Me.MatColorCoding.Width = 80
        '
        'MatDetSpecs
        '
        Me.MatDetSpecs.HeaderText = "Matl Specification(s)"
        Me.MatDetSpecs.Name = "MatDetSpecs"
        Me.MatDetSpecs.Width = 240
        '
        'MatDetNotes
        '
        Me.MatDetNotes.HeaderText = "Notes"
        Me.MatDetNotes.Name = "MatDetNotes"
        Me.MatDetNotes.Width = 280
        '
        'MatDetStatus
        '
        Me.MatDetStatus.HeaderText = "Status"
        Me.MatDetStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.MatDetStatus.Name = "MatDetStatus"
        Me.MatDetStatus.Width = 95
        '
        'dgSpec
        '
        Me.dgSpec.AllowUserToDeleteRows = False
        Me.dgSpec.AllowUserToOrderColumns = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSpec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgSpec.ColumnHeadersHeight = 32
        Me.dgSpec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSpec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MatlSpecID, Me.MatlDetIDSpec, Me.SwAdd, Me.SwRemove, Me.SpecID, Me.SourceName, Me.SpecType, Me.SpecDescr, Me.SpecNotes, Me.SpecStatus})
        Me.dgSpec.Location = New System.Drawing.Point(608, 487)
        Me.dgSpec.Name = "dgSpec"
        Me.dgSpec.RowHeadersWidth = 30
        Me.dgSpec.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSpec.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgSpec.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSpec.RowTemplate.Height = 25
        Me.dgSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSpec.Size = New System.Drawing.Size(1066, 182)
        Me.dgSpec.TabIndex = 126
        Me.dgSpec.Text = "DataGridView1"
        '
        'MatlSpecID
        '
        Me.MatlSpecID.HeaderText = "MatlSpecID"
        Me.MatlSpecID.MinimumWidth = 2
        Me.MatlSpecID.Name = "MatlSpecID"
        Me.MatlSpecID.Visible = False
        Me.MatlSpecID.Width = 2
        '
        'MatlDetIDSpec
        '
        Me.MatlDetIDSpec.HeaderText = "MatlDetID"
        Me.MatlDetIDSpec.MinimumWidth = 2
        Me.MatlDetIDSpec.Name = "MatlDetIDSpec"
        Me.MatlDetIDSpec.Visible = False
        Me.MatlDetIDSpec.Width = 2
        '
        'SwAdd
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.SwAdd.DefaultCellStyle = DataGridViewCellStyle7
        Me.SwAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SwAdd.HeaderText = "Assign Spec. No."
        Me.SwAdd.Name = "SwAdd"
        Me.SwAdd.Width = 60
        '
        'SwRemove
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Red
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Chocolate
        Me.SwRemove.DefaultCellStyle = DataGridViewCellStyle8
        Me.SwRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SwRemove.HeaderText = "Remove Spec. No."
        Me.SwRemove.Name = "SwRemove"
        Me.SwRemove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SwRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SwRemove.Width = 70
        '
        'SpecID
        '
        Me.SpecID.HeaderText = "Spec No"
        Me.SpecID.Name = "SpecID"
        Me.SpecID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SpecID.Width = 140
        '
        'SourceName
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SourceName.DefaultCellStyle = DataGridViewCellStyle9
        Me.SourceName.HeaderText = "Spec Source"
        Me.SourceName.Name = "SourceName"
        Me.SourceName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'SpecType
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SpecType.DefaultCellStyle = DataGridViewCellStyle10
        Me.SpecType.HeaderText = "Spec Type"
        Me.SpecType.Name = "SpecType"
        Me.SpecType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SpecDescr
        '
        Me.SpecDescr.HeaderText = "SpecDescr"
        Me.SpecDescr.Name = "SpecDescr"
        Me.SpecDescr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecDescr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpecDescr.Width = 260
        '
        'SpecNotes
        '
        Me.SpecNotes.HeaderText = "Spec Notes"
        Me.SpecNotes.Name = "SpecNotes"
        Me.SpecNotes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecNotes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpecNotes.Width = 205
        '
        'SpecStatus
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SpecStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.SpecStatus.HeaderText = "Spec Status"
        Me.SpecStatus.Name = "SpecStatus"
        Me.SpecStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpecStatus.Width = 80
        '
        'dgSpecRev
        '
        Me.dgSpecRev.AllowUserToDeleteRows = False
        Me.dgSpecRev.AllowUserToOrderColumns = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSpecRev.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgSpecRev.ColumnHeadersHeight = 32
        Me.dgSpecRev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSpecRev.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SpecRevID, Me.SpecIDRev, Me.SpecRevNo, Me.SpecRevDateIssue, Me.SpecRevDescr, Me.SpecRevNotes, Me.SpecRevStatus})
        Me.dgSpecRev.Location = New System.Drawing.Point(608, 687)
        Me.dgSpecRev.Name = "dgSpecRev"
        Me.dgSpecRev.RowHeadersWidth = 25
        Me.dgSpecRev.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSpecRev.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgSpecRev.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgSpecRev.RowTemplate.Height = 25
        Me.dgSpecRev.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSpecRev.Size = New System.Drawing.Size(1066, 182)
        Me.dgSpecRev.TabIndex = 127
        Me.dgSpecRev.Text = "DataGridView2"
        '
        'SpecRevID
        '
        Me.SpecRevID.HeaderText = "SpecRecvID"
        Me.SpecRevID.MinimumWidth = 2
        Me.SpecRevID.Name = "SpecRevID"
        Me.SpecRevID.Visible = False
        Me.SpecRevID.Width = 2
        '
        'SpecIDRev
        '
        Me.SpecIDRev.HeaderText = "SpecID"
        Me.SpecIDRev.MinimumWidth = 2
        Me.SpecIDRev.Name = "SpecIDRev"
        Me.SpecIDRev.Visible = False
        Me.SpecIDRev.Width = 2
        '
        'SpecRevNo
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SpecRevNo.DefaultCellStyle = DataGridViewCellStyle13
        Me.SpecRevNo.HeaderText = "Rev. No."
        Me.SpecRevNo.Name = "SpecRevNo"
        Me.SpecRevNo.Width = 150
        '
        'SpecRevDateIssue
        '
        Me.SpecRevDateIssue.HeaderText = "Rev. Date Issue"
        Me.SpecRevDateIssue.Name = "SpecRevDateIssue"
        '
        'SpecRevDescr
        '
        Me.SpecRevDescr.HeaderText = "Rev. Descr"
        Me.SpecRevDescr.Name = "SpecRevDescr"
        Me.SpecRevDescr.Width = 320
        '
        'SpecRevNotes
        '
        Me.SpecRevNotes.HeaderText = "Rev. Notes"
        Me.SpecRevNotes.Name = "SpecRevNotes"
        Me.SpecRevNotes.Width = 350
        '
        'SpecRevStatus
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SpecRevStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.SpecRevStatus.HeaderText = "Rev. Status"
        Me.SpecRevStatus.Name = "SpecRevStatus"
        Me.SpecRevStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecRevStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CmdReset
        '
        Me.CmdReset.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdReset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdReset.Location = New System.Drawing.Point(608, 2)
        Me.CmdReset.Name = "CmdReset"
        Me.CmdReset.Size = New System.Drawing.Size(75, 23)
        Me.CmdReset.TabIndex = 128
        Me.CmdReset.Text = "Reset"
        Me.CmdReset.UseVisualStyleBackColor = False
        '
        'frmEngMatlType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1684, 882)
        Me.Controls.Add(Me.CmdReset)
        Me.Controls.Add(Me.dgSpecRev)
        Me.Controls.Add(Me.dgSpec)
        Me.Controls.Add(Me.dgDet)
        Me.Controls.Add(Me.ButtAll)
        Me.Controls.Add(Me.ButtActive)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.dgMat)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmEngMatlType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -  Material Master Form"
        CType(CustToolBar,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgMat,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgDet,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgSpec,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgSpecRev,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgMat As System.Windows.Forms.DataGridView
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ButtActive As System.Windows.Forms.RadioButton
    Friend WithEvents ButtAll As System.Windows.Forms.RadioButton
    Friend WithEvents dgDet As System.Windows.Forms.DataGridView
    Friend WithEvents dgSpec As System.Windows.Forms.DataGridView
    Friend WithEvents dgSpecRev As System.Windows.Forms.DataGridView
    Friend WithEvents MatlSpecID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlDetIDSpec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SwAdd As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SwRemove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents SpecID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SourceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecIDRev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevDateIssue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecRevStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdReset As System.Windows.Forms.Button
    Friend WithEvents MatlID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlFamily As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlDensity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlLeadTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MatlDetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatlIDDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatDetKSI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatColorCoding As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatDetSpecs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatDetNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MatDetStatus As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
