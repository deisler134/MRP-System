<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLNALoadMiMax
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CmdLocation = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CmdLocation
        '
        Me.CmdLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLocation.Location = New System.Drawing.Point(26, 91)
        Me.CmdLocation.Name = "CmdLocation"
        Me.CmdLocation.Size = New System.Drawing.Size(94, 80)
        Me.CmdLocation.TabIndex = 49
        Me.CmdLocation.Text = "File Location"
        Me.CmdLocation.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Location = New System.Drawing.Point(152, 122)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(645, 20)
        Me.txtFileLocation.TabIndex = 50
        '
        'frmLNALoadMiMax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 349)
        Me.Controls.Add(Me.txtFileLocation)
        Me.Controls.Add(Me.CmdLocation)
        Me.Name = "frmLNALoadMiMax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  LNA  Excel Imported Data and Extracted Data from LAC MR" & _
    "P System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdLocation As System.Windows.Forms.Button
    Friend WithEvents txtFileLocation As System.Windows.Forms.TextBox
End Class
