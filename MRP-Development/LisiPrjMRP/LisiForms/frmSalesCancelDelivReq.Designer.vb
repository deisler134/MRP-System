<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesCancelDelivReq
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPslipNo = New System.Windows.Forms.TextBox()
        Me.cmdExecute = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPslipType = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvPosted = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Req#"
        '
        'txtPslipNo
        '
        Me.txtPslipNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPslipNo.Location = New System.Drawing.Point(164, 38)
        Me.txtPslipNo.Name = "txtPslipNo"
        Me.txtPslipNo.Size = New System.Drawing.Size(232, 29)
        Me.txtPslipNo.TabIndex = 1
        '
        'cmdExecute
        '
        Me.cmdExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExecute.Location = New System.Drawing.Point(272, 267)
        Me.cmdExecute.Name = "cmdExecute"
        Me.cmdExecute.Size = New System.Drawing.Size(205, 56)
        Me.cmdExecute.TabIndex = 2
        Me.cmdExecute.Text = "Execute"
        Me.cmdExecute.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtPslipType)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtInvPosted)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmdExecute)
        Me.Panel1.Location = New System.Drawing.Point(36, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(592, 338)
        Me.Panel1.TabIndex = 3
        '
        'txtPslipType
        '
        Me.txtPslipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPslipType.Location = New System.Drawing.Point(271, 164)
        Me.txtPslipType.Name = "txtPslipType"
        Me.txtPslipType.ReadOnly = True
        Me.txtPslipType.Size = New System.Drawing.Size(232, 29)
        Me.txtPslipType.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PslipType:"
        '
        'txtInvPosted
        '
        Me.txtInvPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvPosted.Location = New System.Drawing.Point(271, 29)
        Me.txtInvPosted.Name = "txtInvPosted"
        Me.txtInvPosted.ReadOnly = True
        Me.txtInvPosted.Size = New System.Drawing.Size(232, 29)
        Me.txtInvPosted.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "InvPosted:"
        '
        'frmSalesCancelDelivReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 471)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPslipNo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSalesCancelDelivReq"
        Me.Text = "Lisi Aerospace Canada  -  Delivery Cancel Request Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPslipNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdExecute As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPslipType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvPosted As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
