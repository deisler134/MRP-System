<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wwwkillsearchpath
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
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CmbPartNumber = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtjh = New System.Windows.Forms.TextBox
        Me.txtTarget = New System.Windows.Forms.TextBox
        Me.lstFiles = New System.Windows.Forms.ListBox
        Me.CmdPath = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CmdEmail = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(511, 24)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 0
        Me.cmdSearch.Text = "Button1"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CmbPartNumber
        '
        Me.CmbPartNumber.DropDownHeight = 700
        Me.CmbPartNumber.DropDownWidth = 200
        Me.CmbPartNumber.FormattingEnabled = True
        Me.CmbPartNumber.IntegralHeight = False
        Me.CmbPartNumber.Location = New System.Drawing.Point(136, 24)
        Me.CmbPartNumber.Name = "CmbPartNumber"
        Me.CmbPartNumber.Size = New System.Drawing.Size(171, 21)
        Me.CmbPartNumber.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number"
        '
        'txtjh
        '
        Me.txtjh.Location = New System.Drawing.Point(29, 87)
        Me.txtjh.Multiline = True
        Me.txtjh.Name = "txtjh"
        Me.txtjh.Size = New System.Drawing.Size(146, 48)
        Me.txtjh.TabIndex = 3
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(29, 345)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(165, 20)
        Me.txtTarget.TabIndex = 4
        '
        'lstFiles
        '
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(211, 72)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(1093, 563)
        Me.lstFiles.TabIndex = 5
        '
        'CmdPath
        '
        Me.CmdPath.Location = New System.Drawing.Point(860, 24)
        Me.CmdPath.Name = "CmdPath"
        Me.CmdPath.Size = New System.Drawing.Size(141, 23)
        Me.CmdPath.TabIndex = 6
        Me.CmdPath.Text = "Create Path"
        Me.CmdPath.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(677, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdEmail
        '
        Me.CmdEmail.Location = New System.Drawing.Point(1087, 22)
        Me.CmdEmail.Name = "CmdEmail"
        Me.CmdEmail.Size = New System.Drawing.Size(141, 23)
        Me.CmdEmail.TabIndex = 8
        Me.CmdEmail.Text = "Send Email"
        Me.CmdEmail.UseVisualStyleBackColor = True
        '
        'wwwkillsearchpath
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 664)
        Me.Controls.Add(Me.CmdEmail)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CmdPath)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.txtjh)
        Me.Controls.Add(Me.CmbPartNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSearch)
        Me.Name = "wwwkillsearchpath"
        Me.Text = "wwwkillsearchpath"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CmbPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtjh As System.Windows.Forms.TextBox
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents CmdPath As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmdEmail As System.Windows.Forms.Button
End Class
