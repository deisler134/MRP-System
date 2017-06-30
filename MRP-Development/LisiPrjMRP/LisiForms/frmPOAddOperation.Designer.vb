<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOAddOperation
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOper = New System.Windows.Forms.TextBox
        Me.txtDescr = New System.Windows.Forms.TextBox
        Me.txtSpec = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SwMPOId = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(132, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please enter the Process Operation Number:"
        '
        'txtOper
        '
        Me.txtOper.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOper.Location = New System.Drawing.Point(266, 63)
        Me.txtOper.Name = "txtOper"
        Me.txtOper.Size = New System.Drawing.Size(100, 29)
        Me.txtOper.TabIndex = 1
        Me.txtOper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescr
        '
        Me.txtDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescr.Location = New System.Drawing.Point(12, 148)
        Me.txtDescr.Multiline = True
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.ReadOnly = True
        Me.txtDescr.Size = New System.Drawing.Size(354, 254)
        Me.txtDescr.TabIndex = 2
        '
        'txtSpec
        '
        Me.txtSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpec.Location = New System.Drawing.Point(392, 148)
        Me.txtSpec.Multiline = True
        Me.txtSpec.Name = "txtSpec"
        Me.txtSpec.ReadOnly = True
        Me.txtSpec.Size = New System.Drawing.Size(221, 254)
        Me.txtSpec.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(133, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Operations"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(462, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Specifications"
        '
        'SwMPOId
        '
        Me.SwMPOId.BackColor = System.Drawing.Color.Maroon
        Me.SwMPOId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwMPOId.Location = New System.Drawing.Point(25, 63)
        Me.SwMPOId.Name = "SwMPOId"
        Me.SwMPOId.Size = New System.Drawing.Size(100, 29)
        Me.SwMPOId.TabIndex = 6
        Me.SwMPOId.Visible = False
        '
        'frmPOAddOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 414)
        Me.Controls.Add(Me.SwMPOId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSpec)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.txtOper)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmPOAddOperation"
        Me.Text = "Lisi Aerospace Canada  -  Sub Contracting Purchasing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOper As System.Windows.Forms.TextBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents txtSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SwMPOId As System.Windows.Forms.TextBox
End Class
