<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEngUpdateRev
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
        Me.components = New System.ComponentModel.Container
        Me.txtPrefix = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRevNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbRevDate = New System.Windows.Forms.DateTimePicker
        Me.txtRevDescr = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRevNotes = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmdUpdate = New System.Windows.Forms.Button
        Me.txtClock = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(189, 32)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(157, 20)
        Me.txtPrefix.TabIndex = 96
        Me.txtPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(64, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Part Number Prefix :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRevNo
        '
        Me.txtRevNo.Location = New System.Drawing.Point(189, 62)
        Me.txtRevNo.Name = "txtRevNo"
        Me.txtRevNo.Size = New System.Drawing.Size(157, 20)
        Me.txtRevNo.TabIndex = 98
        Me.txtRevNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(64, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 23)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Revision Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(64, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 23)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Revision Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbRevDate
        '
        Me.cmbRevDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbRevDate.Location = New System.Drawing.Point(189, 93)
        Me.cmbRevDate.Name = "cmbRevDate"
        Me.cmbRevDate.Size = New System.Drawing.Size(157, 20)
        Me.cmbRevDate.TabIndex = 101
        '
        'txtRevDescr
        '
        Me.txtRevDescr.Location = New System.Drawing.Point(189, 122)
        Me.txtRevDescr.Multiline = True
        Me.txtRevDescr.Name = "txtRevDescr"
        Me.txtRevDescr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRevDescr.Size = New System.Drawing.Size(294, 63)
        Me.txtRevDescr.TabIndex = 102
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(64, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 23)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Revision Description:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRevNotes
        '
        Me.txtRevNotes.Location = New System.Drawing.Point(189, 199)
        Me.txtRevNotes.Multiline = True
        Me.txtRevNotes.Name = "txtRevNotes"
        Me.txtRevNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRevNotes.Size = New System.Drawing.Size(294, 63)
        Me.txtRevNotes.TabIndex = 104
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(64, 196)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 23)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Revision Notes:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmdUpdate
        '
        Me.CmdUpdate.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUpdate.Location = New System.Drawing.Point(67, 297)
        Me.CmdUpdate.Name = "CmdUpdate"
        Me.CmdUpdate.Size = New System.Drawing.Size(123, 30)
        Me.CmdUpdate.TabIndex = 106
        Me.CmdUpdate.Text = "U P D A T E"
        Me.CmdUpdate.UseVisualStyleBackColor = False
        '
        'txtClock
        '
        Me.txtClock.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClock.ForeColor = System.Drawing.Color.Black
        Me.txtClock.Location = New System.Drawing.Point(449, 5)
        Me.txtClock.Name = "txtClock"
        Me.txtClock.ReadOnly = True
        Me.txtClock.Size = New System.Drawing.Size(179, 35)
        Me.txtClock.TabIndex = 107
        Me.txtClock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        '
        'frmEngUpdateRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 339)
        Me.Controls.Add(Me.txtClock)
        Me.Controls.Add(Me.CmdUpdate)
        Me.Controls.Add(Me.txtRevNotes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRevDescr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbRevDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRevNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmEngUpdateRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Upadate Parts Revision"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRevNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbRevDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRevDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRevNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmdUpdate As System.Windows.Forms.Button
    Friend WithEvents txtClock As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
