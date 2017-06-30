<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmQuoteBrowseAll
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
        Me.dg.Size = New System.Drawing.Size(753, 383)
        Me.dg.TabIndex = 18
        '
        'frmQuoteBrowseAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 383)
        Me.Controls.Add(Me.dg)
        Me.Name = "frmQuoteBrowseAll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQuoteBrowseAll"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGrid
End Class
