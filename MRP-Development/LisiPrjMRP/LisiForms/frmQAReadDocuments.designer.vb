<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQAReadDocuments
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
        Me.TrView = New System.Windows.Forms.TreeView
        Me.Pb1 = New System.Windows.Forms.ProgressBar
        Me.CmdCollapse = New System.Windows.Forms.Button
        Me.CmdExpand = New System.Windows.Forms.Button
        Me.CmdSrc = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ChkTitle = New System.Windows.Forms.CheckBox
        Me.ChkKey = New System.Windows.Forms.CheckBox
        Me.txtSrc = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblFilePath = New System.Windows.Forms.TextBox
        Me.lblFileName = New System.Windows.Forms.TextBox
        Me.RdMod = New System.Windows.Forms.RadioButton
        Me.RdRead = New System.Windows.Forms.RadioButton
        Me.cmdEmail = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TrView
        '
        Me.TrView.Location = New System.Drawing.Point(12, 12)
        Me.TrView.Name = "TrView"
        Me.TrView.Size = New System.Drawing.Size(343, 504)
        Me.TrView.TabIndex = 12
        '
        'Pb1
        '
        Me.Pb1.Location = New System.Drawing.Point(12, 522)
        Me.Pb1.Name = "Pb1"
        Me.Pb1.Size = New System.Drawing.Size(343, 22)
        Me.Pb1.TabIndex = 15
        '
        'CmdCollapse
        '
        Me.CmdCollapse.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdCollapse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdCollapse.Location = New System.Drawing.Point(395, 47)
        Me.CmdCollapse.Name = "CmdCollapse"
        Me.CmdCollapse.Size = New System.Drawing.Size(75, 52)
        Me.CmdCollapse.TabIndex = 16
        Me.CmdCollapse.Text = "&Collapse Tree View"
        Me.CmdCollapse.UseVisualStyleBackColor = False
        '
        'CmdExpand
        '
        Me.CmdExpand.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdExpand.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdExpand.Location = New System.Drawing.Point(619, 47)
        Me.CmdExpand.Name = "CmdExpand"
        Me.CmdExpand.Size = New System.Drawing.Size(75, 52)
        Me.CmdExpand.TabIndex = 17
        Me.CmdExpand.Text = "&Expand Tree View"
        Me.CmdExpand.UseVisualStyleBackColor = False
        '
        'CmdSrc
        '
        Me.CmdSrc.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdSrc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdSrc.Location = New System.Drawing.Point(619, 403)
        Me.CmdSrc.Name = "CmdSrc"
        Me.CmdSrc.Size = New System.Drawing.Size(75, 23)
        Me.CmdSrc.TabIndex = 18
        Me.CmdSrc.Text = "&Search"
        Me.CmdSrc.UseVisualStyleBackColor = False
        '
        'cmdLoad
        '
        Me.cmdLoad.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.cmdLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdLoad.Location = New System.Drawing.Point(815, 47)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 52)
        Me.cmdLoad.TabIndex = 19
        Me.cmdLoad.Text = "&Reload Tree View"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.DisplayToolbar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 550)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(931, 28)
        Me.CrystalReportViewer1.TabIndex = 22
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'ChkTitle
        '
        Me.ChkTitle.Location = New System.Drawing.Point(395, 314)
        Me.ChkTitle.Name = "ChkTitle"
        Me.ChkTitle.Size = New System.Drawing.Size(62, 50)
        Me.ChkTitle.TabIndex = 28
        Me.ChkTitle.Text = "Search in Doc ""Title"""
        Me.ChkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkTitle.UseVisualStyleBackColor = True
        '
        'ChkKey
        '
        Me.ChkKey.Location = New System.Drawing.Point(550, 317)
        Me.ChkKey.Name = "ChkKey"
        Me.ChkKey.Size = New System.Drawing.Size(60, 44)
        Me.ChkKey.TabIndex = 29
        Me.ChkKey.Text = "Search By Key Words"
        Me.ChkKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkKey.UseVisualStyleBackColor = True
        '
        'txtSrc
        '
        Me.txtSrc.Location = New System.Drawing.Point(395, 403)
        Me.txtSrc.Name = "txtSrc"
        Me.txtSrc.Size = New System.Drawing.Size(215, 20)
        Me.txtSrc.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(488, 332)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "OR"
        '
        'lblFilePath
        '
        Me.lblFilePath.Location = New System.Drawing.Point(395, 146)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(184, 20)
        Me.lblFilePath.TabIndex = 32
        Me.lblFilePath.Visible = False
        '
        'lblFileName
        '
        Me.lblFileName.Location = New System.Drawing.Point(395, 172)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(184, 20)
        Me.lblFileName.TabIndex = 33
        Me.lblFileName.Visible = False
        '
        'RdMod
        '
        Me.RdMod.AutoSize = True
        Me.RdMod.Location = New System.Drawing.Point(395, 236)
        Me.RdMod.Name = "RdMod"
        Me.RdMod.Size = New System.Drawing.Size(121, 17)
        Me.RdMod.TabIndex = 35
        Me.RdMod.TabStop = True
        Me.RdMod.Text = "Modify And Save As"
        Me.RdMod.UseVisualStyleBackColor = True
        Me.RdMod.Visible = False
        '
        'RdRead
        '
        Me.RdRead.AutoSize = True
        Me.RdRead.Location = New System.Drawing.Point(395, 213)
        Me.RdRead.Name = "RdRead"
        Me.RdRead.Size = New System.Drawing.Size(127, 17)
        Me.RdRead.TabIndex = 34
        Me.RdRead.TabStop = True
        Me.RdRead.Text = "Read Only (Message)"
        Me.RdRead.UseVisualStyleBackColor = True
        Me.RdRead.Visible = False
        '
        'cmdEmail
        '
        Me.cmdEmail.BackColor = System.Drawing.Color.Red
        Me.cmdEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdEmail.Location = New System.Drawing.Point(815, 218)
        Me.cmdEmail.Name = "cmdEmail"
        Me.cmdEmail.Size = New System.Drawing.Size(75, 52)
        Me.cmdEmail.TabIndex = 36
        Me.cmdEmail.Text = "&QMS Administrator Email"
        Me.cmdEmail.UseVisualStyleBackColor = False
        Me.cmdEmail.Visible = False
        '
        'frmQAReadDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 578)
        Me.Controls.Add(Me.cmdEmail)
        Me.Controls.Add(Me.RdMod)
        Me.Controls.Add(Me.RdRead)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblFilePath)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSrc)
        Me.Controls.Add(Me.ChkKey)
        Me.Controls.Add(Me.ChkTitle)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.CmdSrc)
        Me.Controls.Add(Me.CmdExpand)
        Me.Controls.Add(Me.CmdCollapse)
        Me.Controls.Add(Me.Pb1)
        Me.Controls.Add(Me.TrView)
        Me.Name = "frmQAReadDocuments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Quality Control Documents - READ ONLY Module"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrView As System.Windows.Forms.TreeView
    Friend WithEvents Pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdCollapse As System.Windows.Forms.Button
    Friend WithEvents CmdExpand As System.Windows.Forms.Button
    Friend WithEvents CmdSrc As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ChkTitle As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKey As System.Windows.Forms.CheckBox
    Friend WithEvents txtSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblFilePath As System.Windows.Forms.TextBox
    Friend WithEvents lblFileName As System.Windows.Forms.TextBox
    Friend WithEvents RdMod As System.Windows.Forms.RadioButton
    Friend WithEvents RdRead As System.Windows.Forms.RadioButton
    Friend WithEvents cmdEmail As System.Windows.Forms.Button
End Class
