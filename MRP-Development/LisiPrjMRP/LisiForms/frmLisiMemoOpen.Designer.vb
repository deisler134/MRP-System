<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLisiMemoOpen
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
        Me.CmbMemo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.CmdOpenCall = New System.Windows.Forms.Button()
        Me.SwMemoId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(95, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 24)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "Memo No."
        '
        'CmbMemo
        '
        Me.CmbMemo.DropDownHeight = 500
        Me.CmbMemo.DropDownWidth = 111
        Me.CmbMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMemo.FormattingEnabled = True
        Me.CmbMemo.IntegralHeight = False
        Me.CmbMemo.Location = New System.Drawing.Point(221, 37)
        Me.CmbMemo.Name = "CmbMemo"
        Me.CmbMemo.Size = New System.Drawing.Size(202, 33)
        Me.CmbMemo.Sorted = True
        Me.CmbMemo.TabIndex = 181
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(96, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 189
        Me.Label10.Text = "Notes"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(221, 119)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObs.Size = New System.Drawing.Size(625, 128)
        Me.txtObs.TabIndex = 188
        '
        'CmdOpenCall
        '
        Me.CmdOpenCall.BackColor = System.Drawing.Color.Transparent
        Me.CmdOpenCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOpenCall.Location = New System.Drawing.Point(343, 302)
        Me.CmdOpenCall.Name = "CmdOpenCall"
        Me.CmdOpenCall.Size = New System.Drawing.Size(219, 60)
        Me.CmdOpenCall.TabIndex = 290
        Me.CmdOpenCall.Text = "Execute"
        Me.CmdOpenCall.UseVisualStyleBackColor = False
        '
        'SwMemoId
        '
        Me.SwMemoId.Location = New System.Drawing.Point(500, 46)
        Me.SwMemoId.Name = "SwMemoId"
        Me.SwMemoId.ReadOnly = True
        Me.SwMemoId.Size = New System.Drawing.Size(83, 20)
        Me.SwMemoId.TabIndex = 291
        Me.SwMemoId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmLisiMemoOpen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 383)
        Me.Controls.Add(Me.SwMemoId)
        Me.Controls.Add(Me.CmdOpenCall)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmbMemo)
        Me.Name = "frmLisiMemoOpen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmLisiMemoOpen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbMemo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents CmdOpenCall As System.Windows.Forms.Button
    Friend WithEvents SwMemoId As System.Windows.Forms.TextBox
End Class
