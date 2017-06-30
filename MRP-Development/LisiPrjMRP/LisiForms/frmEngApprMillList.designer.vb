<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEngApprMillList
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
        Me.components = New System.ComponentModel.Container
        Dim CustToolBar As System.Windows.Forms.BindingNavigator
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdSave = New System.Windows.Forms.Button
        Me.dgAppr = New System.Windows.Forms.DataGridView
        Me.MillID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MillName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MillApprDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MillExpDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Days = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MillStatus = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.MillApprFor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextBox1 = New System.Windows.Forms.TextBox
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAppr, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(838, 25)
        CustToolBar.TabIndex = 65
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(272, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 122
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(33, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 121
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgAppr
        '
        Me.dgAppr.AllowUserToDeleteRows = False
        Me.dgAppr.AllowUserToOrderColumns = True
        Me.dgAppr.AllowUserToResizeColumns = False
        Me.dgAppr.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAppr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAppr.ColumnHeadersHeight = 20
        Me.dgAppr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgAppr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MillID, Me.MillName, Me.MillApprDate, Me.MillExpDate, Me.Days, Me.MillStatus, Me.MillApprFor})
        Me.dgAppr.Location = New System.Drawing.Point(13, 39)
        Me.dgAppr.Name = "dgAppr"
        Me.dgAppr.RowHeadersWidth = 20
        Me.dgAppr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgAppr.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgAppr.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgAppr.RowTemplate.Height = 18
        Me.dgAppr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgAppr.Size = New System.Drawing.Size(597, 416)
        Me.dgAppr.TabIndex = 123
        Me.dgAppr.Text = "DataGridView1"
        '
        'MillID
        '
        Me.MillID.HeaderText = "MillID"
        Me.MillID.MinimumWidth = 2
        Me.MillID.Name = "MillID"
        Me.MillID.Visible = False
        Me.MillID.Width = 2
        '
        'MillName
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MillName.DefaultCellStyle = DataGridViewCellStyle2
        Me.MillName.HeaderText = "Company Name"
        Me.MillName.Name = "MillName"
        Me.MillName.Width = 160
        '
        'MillApprDate
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.MillApprDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.MillApprDate.HeaderText = "Approved Date"
        Me.MillApprDate.Name = "MillApprDate"
        Me.MillApprDate.Width = 80
        '
        'MillExpDate
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MillExpDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.MillExpDate.HeaderText = "Expiration Date"
        Me.MillExpDate.Name = "MillExpDate"
        Me.MillExpDate.ReadOnly = True
        Me.MillExpDate.Width = 80
        '
        'Days
        '
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Days.DefaultCellStyle = DataGridViewCellStyle5
        Me.Days.HeaderText = "Days"
        Me.Days.Name = "Days"
        Me.Days.Width = 80
        '
        'MillStatus
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MillStatus.DefaultCellStyle = DataGridViewCellStyle6
        Me.MillStatus.HeaderText = "Status"
        Me.MillStatus.Items.AddRange(New Object() {"Active", "InActive"})
        Me.MillStatus.Name = "MillStatus"
        Me.MillStatus.ReadOnly = True
        Me.MillStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.MillStatus.Width = 70
        '
        'MillApprFor
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.MillApprFor.DefaultCellStyle = DataGridViewCellStyle7
        Me.MillApprFor.HeaderText = "Approved For"
        Me.MillApprFor.Name = "MillApprFor"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(617, 82)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 373)
        Me.TextBox1.TabIndex = 124
        '
        'frmEngApprMillList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 467)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dgAppr)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmEngApprMillList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA  -  Approved Mill List"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAppr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgAppr As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MillID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MillName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MillApprDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MillExpDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Days As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MillStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MillApprFor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
