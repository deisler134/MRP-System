<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPOMasterBrowse
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Cmdrestore = New System.Windows.Forms.Button
        Me.CmdNew = New System.Windows.Forms.Button
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.dgDetail = New System.Windows.Forms.DataGridView
        Me.CmdMove = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ProdID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProdDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProdSpec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.txtSpec = New System.Windows.Forms.TextBox
        Me.txtRow = New System.Windows.Forms.TextBox
        Me.txtProdID = New System.Windows.Forms.TextBox
        Me.CmdSave = New System.Windows.Forms.Button
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'CmdNew
        '
        Me.CmdNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdNew.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmdNew.Location = New System.Drawing.Point(545, 19)
        Me.CmdNew.Name = "CmdNew"
        Me.CmdNew.Size = New System.Drawing.Size(75, 23)
        Me.CmdNew.TabIndex = 2
        Me.CmdNew.Text = "New"
        '
        'CmdEdit
        '
        Me.CmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CmdEdit.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmdEdit.Location = New System.Drawing.Point(681, 19)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.Size = New System.Drawing.Size(75, 23)
        Me.CmdEdit.TabIndex = 3
        Me.CmdEdit.Text = "Edit"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(153, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(332, 20)
        Me.txtSearch.TabIndex = 4
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        Me.dgDetail.AllowUserToResizeRows = False
        Me.dgDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgDetail.ColumnHeadersHeight = 25
        Me.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CmdMove, Me.ProdID, Me.ProdDescr, Me.ProdSpec})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetail.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDetail.EnableHeadersVisualStyles = False
        Me.dgDetail.Location = New System.Drawing.Point(30, 61)
        Me.dgDetail.MultiSelect = False
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.RowHeadersWidth = 38
        Me.dgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetail.Size = New System.Drawing.Size(860, 219)
        Me.dgDetail.TabIndex = 5
        Me.dgDetail.Text = "DataGridView1"
        '
        'CmdMove
        '
        Me.CmdMove.HeaderText = ""
        Me.CmdMove.Name = "CmdMove"
        Me.CmdMove.Text = "Select"
        Me.CmdMove.UseColumnTextForButtonValue = True
        Me.CmdMove.Width = 80
        '
        'ProdID
        '
        Me.ProdID.HeaderText = "ProdID"
        Me.ProdID.Name = "ProdID"
        Me.ProdID.Visible = False
        Me.ProdID.Width = 50
        '
        'ProdDescr
        '
        Me.ProdDescr.HeaderText = "Product Description"
        Me.ProdDescr.Name = "ProdDescr"
        Me.ProdDescr.Width = 450
        '
        'ProdSpec
        '
        Me.ProdSpec.HeaderText = "Product Specification"
        Me.ProdSpec.Name = "ProdSpec"
        Me.ProdSpec.Width = 300
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(30, 300)
        Me.txtDescr.Multiline = True
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescr.Size = New System.Drawing.Size(521, 92)
        Me.txtDescr.TabIndex = 6
        '
        'txtSpec
        '
        Me.txtSpec.Location = New System.Drawing.Point(567, 300)
        Me.txtSpec.Multiline = True
        Me.txtSpec.Name = "txtSpec"
        Me.txtSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSpec.Size = New System.Drawing.Size(323, 92)
        Me.txtSpec.TabIndex = 7
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(105, 1)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(45, 20)
        Me.txtRow.TabIndex = 8
        '
        'txtProdID
        '
        Me.txtProdID.Location = New System.Drawing.Point(895, 372)
        Me.txtProdID.Name = "txtProdID"
        Me.txtProdID.Size = New System.Drawing.Size(22, 20)
        Me.txtProdID.TabIndex = 9
        '
        'CmdSave
        '
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.ForeColor = System.Drawing.Color.DarkBlue
        Me.CmdSave.Location = New System.Drawing.Point(815, 21)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 10
        Me.CmdSave.Text = "Save"
        '
        'frmPOMasterBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(917, 404)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.txtProdID)
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.txtSpec)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.dgDetail)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdNew)
        Me.Controls.Add(Me.Cmdrestore)
        Me.Name = "frmPOMasterBrowse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Products Catalog (Search & UpDate)"
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cmdrestore As System.Windows.Forms.Button
    Friend WithEvents CmdNew As System.Windows.Forms.Button
    Friend WithEvents CmdEdit As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
    Friend WithEvents txtProdID As System.Windows.Forms.TextBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdMove As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ProdID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProdSpec As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
