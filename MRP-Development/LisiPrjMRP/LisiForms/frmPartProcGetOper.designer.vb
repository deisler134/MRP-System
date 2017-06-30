<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPartProcGetOper
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Cmdrestore = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.dgOper = New System.Windows.Forms.DataGridView
        Me.CmdMove = New System.Windows.Forms.DataGridViewButtonColumn
        Me.OperDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OperSpec = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cmdrestore
        '
        Me.Cmdrestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Cmdrestore.ForeColor = System.Drawing.Color.Maroon
        Me.Cmdrestore.Location = New System.Drawing.Point(30, 18)
        Me.Cmdrestore.Name = "Cmdrestore"
        Me.Cmdrestore.Size = New System.Drawing.Size(75, 23)
        Me.Cmdrestore.TabIndex = 1
        Me.Cmdrestore.Text = "Refresh"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(153, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(332, 20)
        Me.txtSearch.TabIndex = 4
        '
        'dgOper
        '
        Me.dgOper.AllowUserToAddRows = False
        Me.dgOper.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOper.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOper.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgOper.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgOper.ColumnHeadersHeight = 25
        Me.dgOper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgOper.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CmdMove, Me.OperDescr, Me.OperSpec})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOper.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgOper.EnableHeadersVisualStyles = False
        Me.dgOper.Location = New System.Drawing.Point(30, 61)
        Me.dgOper.MultiSelect = False
        Me.dgOper.Name = "dgOper"
        Me.dgOper.RowHeadersWidth = 38
        Me.dgOper.Size = New System.Drawing.Size(860, 564)
        Me.dgOper.TabIndex = 5
        Me.dgOper.Text = "DataGridView1"
        '
        'CmdMove
        '
        Me.CmdMove.HeaderText = ""
        Me.CmdMove.Name = "CmdMove"
        Me.CmdMove.Text = "Select"
        Me.CmdMove.UseColumnTextForButtonValue = True
        Me.CmdMove.Width = 80
        '
        'OperDescr
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OperDescr.DefaultCellStyle = DataGridViewCellStyle2
        Me.OperDescr.HeaderText = "Product Description"
        Me.OperDescr.Name = "OperDescr"
        Me.OperDescr.Width = 450
        '
        'OperSpec
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OperSpec.DefaultCellStyle = DataGridViewCellStyle3
        Me.OperSpec.HeaderText = "Product Specification"
        Me.OperSpec.Name = "OperSpec"
        Me.OperSpec.Width = 300
        '
        'frmPartProcGetOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(917, 637)
        Me.Controls.Add(Me.dgOper)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Cmdrestore)
        Me.Name = "frmPartProcGetOper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Process Sheet (Search Operation)"
        CType(Me.dgOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmdrestore As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgOper As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdMove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents OperDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperSpec As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
