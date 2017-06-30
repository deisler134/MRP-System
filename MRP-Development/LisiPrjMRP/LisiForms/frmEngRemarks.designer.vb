<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEngRemarks
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
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.ButtProc = New System.Windows.Forms.RadioButton()
        Me.ButtMat = New System.Windows.Forms.RadioButton()
        Me.ButtShip = New System.Windows.Forms.RadioButton()
        Me.CmdEdit = New System.Windows.Forms.Button()
        Me.RemarkID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarkType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarkText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(1094, 25)
        CustToolBar.TabIndex = 64
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(45, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 118
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dg
        '
        Me.dg.AllowUserToResizeColumns = False
        Me.dg.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg.ColumnHeadersHeight = 20
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RemarkID, Me.RemarkType, Me.RemarkText})
        Me.dg.Location = New System.Drawing.Point(147, 43)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersWidth = 25
        Me.dg.Size = New System.Drawing.Size(935, 505)
        Me.dg.TabIndex = 120
        Me.dg.Text = "DataGridView1"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.PowderBlue
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(147, 554)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(935, 91)
        Me.txtNotes.TabIndex = 121
        '
        'ButtProc
        '
        Me.ButtProc.AutoSize = True
        Me.ButtProc.Location = New System.Drawing.Point(25, 68)
        Me.ButtProc.Name = "ButtProc"
        Me.ButtProc.Size = New System.Drawing.Size(108, 17)
        Me.ButtProc.TabIndex = 122
        Me.ButtProc.Text = "Processing Notes"
        '
        'ButtMat
        '
        Me.ButtMat.AutoSize = True
        Me.ButtMat.Location = New System.Drawing.Point(25, 115)
        Me.ButtMat.Name = "ButtMat"
        Me.ButtMat.Size = New System.Drawing.Size(93, 17)
        Me.ButtMat.TabIndex = 123
        Me.ButtMat.Text = "Material Notes"
        '
        'ButtShip
        '
        Me.ButtShip.AutoSize = True
        Me.ButtShip.Location = New System.Drawing.Point(25, 165)
        Me.ButtShip.Name = "ButtShip"
        Me.ButtShip.Size = New System.Drawing.Size(97, 17)
        Me.ButtShip.TabIndex = 124
        Me.ButtShip.Text = "Shipping Notes"
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(147, 2)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 125
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'RemarkID
        '
        Me.RemarkID.HeaderText = "RemarkID"
        Me.RemarkID.MinimumWidth = 2
        Me.RemarkID.Name = "RemarkID"
        Me.RemarkID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemarkID.Visible = False
        Me.RemarkID.Width = 2
        '
        'RemarkType
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.RemarkType.DefaultCellStyle = DataGridViewCellStyle2
        Me.RemarkType.HeaderText = "RemarkType"
        Me.RemarkType.Name = "RemarkType"
        Me.RemarkType.ReadOnly = True
        Me.RemarkType.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'RemarkText
        '
        Me.RemarkText.HeaderText = "RemarkText"
        Me.RemarkText.Name = "RemarkText"
        Me.RemarkText.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemarkText.Width = 800
        '
        'frmEngRemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 657)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.ButtShip)
        Me.Controls.Add(Me.ButtMat)
        Me.Controls.Add(Me.ButtProc)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmEngRemarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Technical Notes for Purchasing"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents ButtProc As System.Windows.Forms.RadioButton
    Friend WithEvents ButtMat As System.Windows.Forms.RadioButton
    Friend WithEvents ButtShip As System.Windows.Forms.RadioButton
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarkType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarkText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
