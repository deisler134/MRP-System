<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartProcSQL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.SwIndex = New System.Windows.Forms.TextBox
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AllowDrop = True
        Me.dg.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.dg.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dg.BackgroundColor = System.Drawing.Color.LightGray
        Me.dg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.dg.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.dg.DataMember = ""
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dg.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dg.GridLineColor = System.Drawing.Color.Gainsboro
        Me.dg.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dg.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dg.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dg.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.dg.LinkColor = System.Drawing.Color.Teal
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Name = "dg"
        Me.dg.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.dg.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dg.ReadOnly = True
        Me.dg.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.dg.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.dg.Size = New System.Drawing.Size(756, 392)
        Me.dg.TabIndex = 16
        '
        'SwIndex
        '
        Me.SwIndex.Location = New System.Drawing.Point(285, 6)
        Me.SwIndex.Name = "SwIndex"
        Me.SwIndex.Size = New System.Drawing.Size(53, 20)
        Me.SwIndex.TabIndex = 17
        Me.SwIndex.Visible = False
        '
        'frmPartProcSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 392)
        Me.Controls.Add(Me.SwIndex)
        Me.Controls.Add(Me.dg)
        Me.Name = "frmPartProcSQL"
        Me.Text = "Lisi Aerospace Canada  -  View / Import Manufacturing METHOD from SQL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    Friend WithEvents SwIndex As System.Windows.Forms.TextBox
End Class
