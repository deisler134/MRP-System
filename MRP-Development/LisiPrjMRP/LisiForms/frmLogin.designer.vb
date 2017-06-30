<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmLogin
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
        Dim EmpUserIDLabel As System.Windows.Forms.Label
        Dim EmppasswordLabel As System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        EmpUserIDLabel = New System.Windows.Forms.Label()
        EmppasswordLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'EmpUserIDLabel
        '
        EmpUserIDLabel.AutoSize = True
        EmpUserIDLabel.Font = New System.Drawing.Font("Book Antiqua", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EmpUserIDLabel.Location = New System.Drawing.Point(113, 42)
        EmpUserIDLabel.Name = "EmpUserIDLabel"
        EmpUserIDLabel.Size = New System.Drawing.Size(69, 19)
        EmpUserIDLabel.TabIndex = 1
        EmpUserIDLabel.Text = "User ID:"
        '
        'EmppasswordLabel
        '
        EmppasswordLabel.AutoSize = True
        EmppasswordLabel.Font = New System.Drawing.Font("Book Antiqua", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EmppasswordLabel.Location = New System.Drawing.Point(113, 91)
        EmppasswordLabel.Name = "EmppasswordLabel"
        EmppasswordLabel.Size = New System.Drawing.Size(80, 19)
        EmppasswordLabel.TabIndex = 2
        EmppasswordLabel.Text = "Password:"
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Book Antiqua", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(208, 42)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(128, 26)
        Me.txtUserID.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Book Antiqua", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(208, 91)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(128, 23)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(453, 166)
        Me.Controls.Add(EmppasswordLabel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(EmpUserIDLabel)
        Me.Controls.Add(Me.txtUserID)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISI AEROSPACE CANADA CORP   (Ver. 2013 - SQL 2012)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox

End Class
