<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReleaseRMFirstOper
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
        Me.SwMPOId = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSpec = New System.Windows.Forms.TextBox
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.txtOper = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.CmbDept = New System.Windows.Forms.ComboBox
        Me.CmdExec = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SwEmpID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMatl = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'SwMPOId
        '
        Me.SwMPOId.BackColor = System.Drawing.Color.Maroon
        Me.SwMPOId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwMPOId.Location = New System.Drawing.Point(40, 15)
        Me.SwMPOId.Name = "SwMPOId"
        Me.SwMPOId.Size = New System.Drawing.Size(100, 29)
        Me.SwMPOId.TabIndex = 13
        Me.SwMPOId.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(624, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Specifications"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(199, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Operations"
        '
        'txtSpec
        '
        Me.txtSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpec.Location = New System.Drawing.Point(554, 160)
        Me.txtSpec.Multiline = True
        Me.txtSpec.Name = "txtSpec"
        Me.txtSpec.ReadOnly = True
        Me.txtSpec.Size = New System.Drawing.Size(221, 152)
        Me.txtSpec.TabIndex = 10
        '
        'txtDescr
        '
        Me.txtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescr.Location = New System.Drawing.Point(21, 160)
        Me.txtDescr.Multiline = True
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ReadOnly = True
        Me.txtDescr.Size = New System.Drawing.Size(468, 152)
        Me.txtDescr.TabIndex = 9
        '
        'txtOper
        '
        Me.txtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOper.Location = New System.Drawing.Point(360, 64)
        Me.txtOper.Name = "txtOper"
        Me.txtOper.Size = New System.Drawing.Size(100, 29)
        Me.txtOper.TabIndex = 8
        Me.txtOper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(228, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Please enter the Process Operation Number:"
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(180, 395)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.ReadOnly = True
        Me.txtUser.Size = New System.Drawing.Size(309, 29)
        Me.txtUser.TabIndex = 14
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbDept
        '
        Me.CmbDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbDept.FormattingEnabled = True
        Me.CmbDept.Location = New System.Drawing.Point(180, 445)
        Me.CmbDept.Name = "CmbDept"
        Me.CmbDept.Size = New System.Drawing.Size(309, 26)
        Me.CmbDept.TabIndex = 15
        '
        'CmdExec
        '
        Me.CmdExec.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExec.Location = New System.Drawing.Point(554, 393)
        Me.CmdExec.Name = "CmdExec"
        Me.CmdExec.Size = New System.Drawing.Size(221, 31)
        Me.CmdExec.TabIndex = 16
        Me.CmdExec.Text = "Execute"
        Me.CmdExec.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(51, 395)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "User"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(51, 450)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Next Department"
        '
        'SwEmpID
        '
        Me.SwEmpID.BackColor = System.Drawing.Color.Maroon
        Me.SwEmpID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwEmpID.Location = New System.Drawing.Point(40, 64)
        Me.SwEmpID.Name = "SwEmpID"
        Me.SwEmpID.Size = New System.Drawing.Size(100, 29)
        Me.SwEmpID.TabIndex = 19
        Me.SwEmpID.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(51, 343)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Matl Family"
        '
        'txtMatl
        '
        Me.txtMatl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatl.Location = New System.Drawing.Point(180, 343)
        Me.txtMatl.Name = "txtMatl"
        Me.txtMatl.ReadOnly = True
        Me.txtMatl.Size = New System.Drawing.Size(309, 29)
        Me.txtMatl.TabIndex = 20
        Me.txtMatl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmReleaseRMFirstOper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 507)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMatl)
        Me.Controls.Add(Me.SwEmpID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmdExec)
        Me.Controls.Add(Me.CmbDept)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.SwMPOId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSpec)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtOper)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmReleaseRMFirstOper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Raw Material Release to Production (First Operation)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SwMPOId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSpec As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtOper As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents CmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents CmdExec As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SwEmpID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMatl As System.Windows.Forms.TextBox
End Class
