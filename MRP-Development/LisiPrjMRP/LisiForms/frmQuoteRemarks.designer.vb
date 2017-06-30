<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmQuoteRemarks
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
        Me.CmdSave = New System.Windows.Forms.Button
        Me.dg = New System.Windows.Forms.DataGridView
        Me.QTRemarkID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QTLang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QTRemarkText = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.ButtEngl = New System.Windows.Forms.RadioButton
        Me.ButtFr = New System.Windows.Forms.RadioButton
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.SwFrom = New System.Windows.Forms.TextBox
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
        CustToolBar.Size = New System.Drawing.Size(829, 25)
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
        Me.dg.ColumnHeadersHeight = 22
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QTRemarkID, Me.QTLang, Me.QTRemarkText})
        Me.dg.Location = New System.Drawing.Point(147, 28)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersWidth = 25
        Me.dg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg.RowTemplate.Height = 20
        Me.dg.Size = New System.Drawing.Size(677, 246)
        Me.dg.TabIndex = 120
        Me.dg.Text = "DataGridView1"
        '
        'QTRemarkID
        '
        Me.QTRemarkID.HeaderText = "QTRemarkID"
        Me.QTRemarkID.MinimumWidth = 2
        Me.QTRemarkID.Name = "QTRemarkID"
        Me.QTRemarkID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QTRemarkID.Visible = False
        Me.QTRemarkID.Width = 2
        '
        'QTLang
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.QTLang.DefaultCellStyle = DataGridViewCellStyle1
        Me.QTLang.HeaderText = "Language"
        Me.QTLang.Name = "QTLang"
        Me.QTLang.ReadOnly = True
        Me.QTLang.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'QTRemarkText
        '
        Me.QTRemarkText.HeaderText = "Notes"
        Me.QTRemarkText.Name = "QTRemarkText"
        Me.QTRemarkText.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.QTRemarkText.Width = 550
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(147, 280)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(677, 91)
        Me.txtNotes.TabIndex = 121
        '
        'ButtEngl
        '
        Me.ButtEngl.AutoSize = True
        Me.ButtEngl.Location = New System.Drawing.Point(25, 68)
        Me.ButtEngl.Name = "ButtEngl"
        Me.ButtEngl.Size = New System.Drawing.Size(90, 17)
        Me.ButtEngl.TabIndex = 122
        Me.ButtEngl.Text = "English Notes"
        '
        'ButtFr
        '
        Me.ButtFr.AutoSize = True
        Me.ButtFr.Location = New System.Drawing.Point(25, 115)
        Me.ButtFr.Name = "ButtFr"
        Me.ButtFr.Size = New System.Drawing.Size(89, 17)
        Me.ButtFr.TabIndex = 123
        Me.ButtFr.Text = "French Notes"
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
        'SwFrom
        '
        Me.SwFrom.Location = New System.Drawing.Point(25, 175)
        Me.SwFrom.Name = "SwFrom"
        Me.SwFrom.Size = New System.Drawing.Size(86, 20)
        Me.SwFrom.TabIndex = 126
        '
        'frmQuoteRemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 375)
        Me.Controls.Add(Me.SwFrom)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.ButtFr)
        Me.Controls.Add(Me.ButtEngl)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmQuoteRemarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Quote Remarks"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents ButtEngl As System.Windows.Forms.RadioButton
    Friend WithEvents ButtFr As System.Windows.Forms.RadioButton
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents SwFrom As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTRemarkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTLang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTRemarkText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
