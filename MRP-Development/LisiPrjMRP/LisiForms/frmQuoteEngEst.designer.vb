<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmQuoteEngEst
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
        Me.dg = New System.Windows.Forms.DataGridView
        Me.QID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QAsk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Form = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.AllowUserToResizeColumns = False
        Me.dg.AllowUserToResizeRows = False
        Me.dg.ColumnHeadersHeight = 22
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QID, Me.QNo, Me.QDate, Me.QAsk, Me.Form})
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.RowHeadersWidth = 25
        Me.dg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg.RowTemplate.Height = 20
        Me.dg.Size = New System.Drawing.Size(382, 398)
        Me.dg.TabIndex = 0
        Me.dg.Text = "DataGridView1"
        '
        'QID
        '
        Me.QID.HeaderText = "QID"
        Me.QID.MinimumWidth = 2
        Me.QID.Name = "QID"
        Me.QID.ReadOnly = True
        Me.QID.Visible = False
        Me.QID.Width = 2
        '
        'QNo
        '
        Me.QNo.HeaderText = "Quote#"
        Me.QNo.Name = "QNo"
        Me.QNo.ReadOnly = True
        Me.QNo.Width = 70
        '
        'QDate
        '
        Me.QDate.HeaderText = "Quoate Date"
        Me.QDate.Name = "QDate"
        Me.QDate.ReadOnly = True
        '
        'QAsk
        '
        Me.QAsk.HeaderText = "Ask EstCost"
        Me.QAsk.Name = "QAsk"
        Me.QAsk.ReadOnly = True
        Me.QAsk.Width = 70
        '
        'Form
        '
        Me.Form.HeaderText = "Form"
        Me.Form.Name = "Form"
        Me.Form.ReadOnly = True
        Me.Form.Text = "Quote"
        Me.Form.UseColumnTextForButtonValue = True
        '
        'frmQuoteEngEst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 398)
        Me.Controls.Add(Me.dg)
        Me.Name = "frmQuoteEngEst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Eng. Quote(s) waitting"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents QID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QAsk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Form As System.Windows.Forms.DataGridViewButtonColumn
End Class
