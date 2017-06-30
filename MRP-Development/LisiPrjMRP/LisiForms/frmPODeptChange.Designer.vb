<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPODeptChange
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbMPO = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbDept = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "MPO Number"
        '
        'CmbMPO
        '
        Me.CmbMPO.Enabled = False
        Me.CmbMPO.FormattingEnabled = True
        Me.CmbMPO.Location = New System.Drawing.Point(121, 47)
        Me.CmbMPO.Name = "CmbMPO"
        Me.CmbMPO.Size = New System.Drawing.Size(145, 21)
        Me.CmbMPO.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "MPO Department"
        '
        'CmbDept
        '
        Me.CmbDept.FormattingEnabled = True
        Me.CmbDept.Location = New System.Drawing.Point(121, 101)
        Me.CmbDept.Name = "CmbDept"
        Me.CmbDept.Size = New System.Drawing.Size(145, 21)
        Me.CmbDept.TabIndex = 27
        '
        'frmPODeptChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 158)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbDept)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CmbMPO)
        Me.Name = "frmPODeptChange"
        Me.Text = "frmPODeptChange"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbMPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbDept As System.Windows.Forms.ComboBox
End Class
