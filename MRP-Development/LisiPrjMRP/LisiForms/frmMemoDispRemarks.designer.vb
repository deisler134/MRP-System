<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMemoDispRemarks
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CmdSave = New System.Windows.Forms.Button
        Me.dgDisp = New System.Windows.Forms.DataGridView
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.CmdSend = New System.Windows.Forms.DataGridViewButtonColumn
        Me.DispText = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DispTextID = New System.Windows.Forms.DataGridViewTextBoxColumn
        CustToolBar = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDisp, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CustToolBar.Size = New System.Drawing.Size(1259, 25)
        CustToolBar.TabIndex = 64
        CustToolBar.Text = "BindingNavigator1"
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(1014, 0)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 118
        Me.CmdSave.Text = "Save Data"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'dgDisp
        '
        Me.dgDisp.AllowUserToResizeColumns = False
        Me.dgDisp.AllowUserToResizeRows = False
        Me.dgDisp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDisp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDisp.ColumnHeadersHeight = 40
        Me.dgDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDisp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CmdSend, Me.DispText, Me.DispTextID})
        Me.dgDisp.Location = New System.Drawing.Point(12, 44)
        Me.dgDisp.Name = "dgDisp"
        Me.dgDisp.RowHeadersWidth = 25
        Me.dgDisp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDisp.RowTemplate.Height = 20
        Me.dgDisp.Size = New System.Drawing.Size(1230, 404)
        Me.dgDisp.TabIndex = 120
        Me.dgDisp.Text = "DataGridView1"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(12, 465)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(1230, 110)
        Me.txtNotes.TabIndex = 121
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.Location = New System.Drawing.Point(278, 0)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 125
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'txtFrom
        '
        Me.txtFrom.BackColor = System.Drawing.Color.DarkRed
        Me.txtFrom.Location = New System.Drawing.Point(57, 2)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtFrom.TabIndex = 128
        Me.txtFrom.Visible = False
        '
        'CmdSend
        '
        Me.CmdSend.HeaderText = "Send"
        Me.CmdSend.Name = "CmdSend"
        Me.CmdSend.Text = "Send"
        Me.CmdSend.UseColumnTextForButtonValue = True
        Me.CmdSend.Width = 80
        '
        'DispText
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DispText.DefaultCellStyle = DataGridViewCellStyle4
        Me.DispText.HeaderText = "Disposition Text"
        Me.DispText.Name = "DispText"
        Me.DispText.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DispText.Width = 1100
        '
        'DispTextID
        '
        Me.DispTextID.HeaderText = "DispTextID"
        Me.DispTextID.MinimumWidth = 2
        Me.DispTextID.Name = "DispTextID"
        Me.DispTextID.Visible = False
        Me.DispTextID.Width = 5
        '
        'frmMemoDispRemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1259, 587)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.dgDisp)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmMemoDispRemarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Disposition Text"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDisp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dgDisp As System.Windows.Forms.DataGridView
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents CmdSend As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DispText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DispTextID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
