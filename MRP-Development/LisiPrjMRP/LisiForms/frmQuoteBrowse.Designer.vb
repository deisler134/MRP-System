<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmQuoteBrowse
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
        Me.dg = New System.Windows.Forms.DataGrid
        Me.txtPartID = New System.Windows.Forms.TextBox
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AlternatingBackColor = System.Drawing.Color.Silver
        Me.dg.BackColor = System.Drawing.Color.White
        Me.dg.CaptionBackColor = System.Drawing.Color.Maroon
        Me.dg.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dg.CaptionForeColor = System.Drawing.Color.White
        Me.dg.DataMember = ""
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dg.ForeColor = System.Drawing.Color.Black
        Me.dg.GridLineColor = System.Drawing.Color.Silver
        Me.dg.HeaderBackColor = System.Drawing.Color.Silver
        Me.dg.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dg.HeaderForeColor = System.Drawing.Color.Black
        Me.dg.LinkColor = System.Drawing.Color.Maroon
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Name = "dg"
        Me.dg.ParentRowsBackColor = System.Drawing.Color.Silver
        Me.dg.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dg.SelectionBackColor = System.Drawing.Color.Maroon
        Me.dg.SelectionForeColor = System.Drawing.Color.White
        Me.dg.Size = New System.Drawing.Size(774, 332)
        Me.dg.TabIndex = 17
        '
        'txtPartID
        '
        Me.txtPartID.Location = New System.Drawing.Point(44, 12)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(100, 20)
        Me.txtPartID.TabIndex = 18
        Me.txtPartID.Visible = False
        '
        'frmQuoteBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 332)
        Me.Controls.Add(Me.txtPartID)
        Me.Controls.Add(Me.dg)
        Me.Name = "frmQuoteBrowse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Quote Browse By Part Number"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
End Class
