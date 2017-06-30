<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderEntryPutM3ITNO
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
        Me.txtSW = New System.Windows.Forms.TextBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtM3ITNO = New System.Windows.Forms.TextBox()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSW
        '
        Me.txtSW.Location = New System.Drawing.Point(16, 230)
        Me.txtSW.Name = "txtSW"
        Me.txtSW.Size = New System.Drawing.Size(63, 20)
        Me.txtSW.TabIndex = 3
        Me.txtSW.Visible = False
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(122, 230)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(63, 20)
        Me.txtRow.TabIndex = 4
        Me.txtRow.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Part Number"
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(135, 35)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.ReadOnly = True
        Me.txtPart.Size = New System.Drawing.Size(241, 20)
        Me.txtPart.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(12, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "M3 ITNO"
        '
        'txtM3ITNO
        '
        Me.txtM3ITNO.Location = New System.Drawing.Point(135, 96)
        Me.txtM3ITNO.Name = "txtM3ITNO"
        Me.txtM3ITNO.Size = New System.Drawing.Size(241, 20)
        Me.txtM3ITNO.TabIndex = 22
        Me.txtM3ITNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.Transparent
        Me.CmdSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(242, 180)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(134, 43)
        Me.CmdSave.TabIndex = 23
        Me.CmdSave.Text = "S A V E"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'frmOrderEntryPutM3ITNO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.txtM3ITNO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.txtSW)
        Me.Name = "frmOrderEntryPutM3ITNO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOrderEntryPutM3ITNO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSW As System.Windows.Forms.TextBox
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtM3ITNO As System.Windows.Forms.TextBox
    Friend WithEvents CmdSave As System.Windows.Forms.Button
End Class
