<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPORemarks
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
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.ButtProc = New System.Windows.Forms.RadioButton()
        Me.ButtMat = New System.Windows.Forms.RadioButton()
        Me.ButtShip = New System.Windows.Forms.RadioButton()
        Me.CmdSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.RemarkID = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CustToolBar.Size = New System.Drawing.Size(1097, 25)
        CustToolBar.TabIndex = 64
        CustToolBar.Text = "BindingNavigator1"
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
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
        Me.dg.ColumnHeadersHeight = 25
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CmdSelect, Me.RemarkID, Me.RemarkText})
        Me.dg.Location = New System.Drawing.Point(147, 12)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.RowHeadersWidth = 25
        Me.dg.Size = New System.Drawing.Size(943, 527)
        Me.dg.TabIndex = 120
        Me.dg.Text = "DataGridView1"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.LightBlue
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(147, 545)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(943, 91)
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
        'CmdSelect
        '
        Me.CmdSelect.HeaderText = ""
        Me.CmdSelect.Name = "CmdSelect"
        Me.CmdSelect.ReadOnly = True
        Me.CmdSelect.Text = "Select"
        Me.CmdSelect.UseColumnTextForButtonValue = True
        '
        'RemarkID
        '
        Me.RemarkID.HeaderText = "RemarkID"
        Me.RemarkID.MinimumWidth = 2
        Me.RemarkID.Name = "RemarkID"
        Me.RemarkID.ReadOnly = True
        Me.RemarkID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemarkID.Visible = False
        Me.RemarkID.Width = 2
        '
        'RemarkText
        '
        Me.RemarkText.HeaderText = "RemarkText"
        Me.RemarkText.Name = "RemarkText"
        Me.RemarkText.ReadOnly = True
        Me.RemarkText.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RemarkText.Width = 800
        '
        'frmPORemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 648)
        Me.Controls.Add(Me.ButtShip)
        Me.Controls.Add(Me.ButtMat)
        Me.Controls.Add(Me.ButtProc)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(CustToolBar)
        Me.Name = "frmPORemarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Technical Notes for Purchasing"
        CType(CustToolBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents ButtProc As System.Windows.Forms.RadioButton
    Friend WithEvents ButtMat As System.Windows.Forms.RadioButton
    Friend WithEvents ButtShip As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents RemarkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarkText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
