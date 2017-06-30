<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQAImportWordDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQAImportWordDoc))
        Me.CmdBrowse = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lblFilePath = New System.Windows.Forms.Label
        Me.lblFileName = New System.Windows.Forms.Label
        Me.CmdSave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbNode = New System.Windows.Forms.ComboBox
        Me.TrView = New System.Windows.Forms.TreeView
        Me.CmdRemove = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pb1 = New System.Windows.Forms.ProgressBar
        Me.CmdCollapse = New System.Windows.Forms.Button
        Me.CmdExpand = New System.Windows.Forms.Button
        Me.CmdSrc = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.txtShow = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label4 = New System.Windows.Forms.Label
        Me.RdRead = New System.Windows.Forms.RadioButton
        Me.RdMod = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkTitle = New System.Windows.Forms.CheckBox
        Me.ChkKey = New System.Windows.Forms.CheckBox
        Me.txtSrc = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmdClasif = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CmdBrowse
        '
        Me.CmdBrowse.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdBrowse.Location = New System.Drawing.Point(264, 11)
        Me.CmdBrowse.Name = "CmdBrowse"
        Me.CmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.CmdBrowse.TabIndex = 2
        Me.CmdBrowse.Text = "&Browse..."
        Me.CmdBrowse.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblFilePath
        '
        Me.lblFilePath.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFilePath.Location = New System.Drawing.Point(343, 157)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(455, 32)
        Me.lblFilePath.TabIndex = 6
        Me.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFileName
        '
        Me.lblFileName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFileName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFileName.Location = New System.Drawing.Point(343, 102)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(455, 32)
        Me.lblFileName.TabIndex = 7
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.LightSkyBlue
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdSave.Location = New System.Drawing.Point(819, 11)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(75, 23)
        Me.CmdSave.TabIndex = 8
        Me.CmdSave.Text = "&Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(264, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Path:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(264, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 29)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Document Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmbNode
        '
        Me.CmbNode.FormattingEnabled = True
        Me.CmbNode.Location = New System.Drawing.Point(343, 64)
        Me.CmbNode.Name = "CmbNode"
        Me.CmbNode.Size = New System.Drawing.Size(212, 21)
        Me.CmbNode.TabIndex = 11
        '
        'TrView
        '
        Me.TrView.Location = New System.Drawing.Point(12, 12)
        Me.TrView.Name = "TrView"
        Me.TrView.Size = New System.Drawing.Size(235, 422)
        Me.TrView.TabIndex = 12
        '
        'CmdRemove
        '
        Me.CmdRemove.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdRemove.Location = New System.Drawing.Point(528, 11)
        Me.CmdRemove.Name = "CmdRemove"
        Me.CmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.CmdRemove.TabIndex = 13
        Me.CmdRemove.Text = "&Remove"
        Me.CmdRemove.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(264, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Clasification:"
        '
        'Pb1
        '
        Me.Pb1.Location = New System.Drawing.Point(12, 440)
        Me.Pb1.Name = "Pb1"
        Me.Pb1.Size = New System.Drawing.Size(235, 16)
        Me.Pb1.TabIndex = 15
        '
        'CmdCollapse
        '
        Me.CmdCollapse.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdCollapse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CmdCollapse.Location = New System.Drawing.Point(819, 79)
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
        Me.CmdExpand.Location = New System.Drawing.Point(819, 178)
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
        Me.CmdSrc.Location = New System.Drawing.Point(819, 400)
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
        Me.cmdLoad.Location = New System.Drawing.Point(819, 269)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 52)
        Me.cmdLoad.TabIndex = 19
        Me.cmdLoad.Text = "&Reload Tree View"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'txtShow
        '
        Me.txtShow.Location = New System.Drawing.Point(343, 208)
        Me.txtShow.Multiline = True
        Me.txtShow.Name = "txtShow"
        Me.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtShow.Size = New System.Drawing.Size(455, 86)
        Me.txtShow.TabIndex = 20
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.DisplayToolbar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 468)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(906, 28)
        Me.CrystalReportViewer1.TabIndex = 22
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(264, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 49)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Key Words" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Search Criteria"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RdRead
        '
        Me.RdRead.AutoSize = True
        Me.RdRead.Location = New System.Drawing.Point(343, 322)
        Me.RdRead.Name = "RdRead"
        Me.RdRead.Size = New System.Drawing.Size(127, 17)
        Me.RdRead.TabIndex = 24
        Me.RdRead.TabStop = True
        Me.RdRead.Text = "Read Only (Message)"
        Me.RdRead.UseVisualStyleBackColor = True
        '
        'RdMod
        '
        Me.RdMod.AutoSize = True
        Me.RdMod.Location = New System.Drawing.Point(499, 322)
        Me.RdMod.Name = "RdMod"
        Me.RdMod.Size = New System.Drawing.Size(121, 17)
        Me.RdMod.TabIndex = 25
        Me.RdMod.TabStop = True
        Me.RdMod.Text = "Modify And Save As"
        Me.RdMod.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(264, 322)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Access Rights"
        '
        'ChkTitle
        '
        Me.ChkTitle.Location = New System.Drawing.Point(264, 387)
        Me.ChkTitle.Name = "ChkTitle"
        Me.ChkTitle.Size = New System.Drawing.Size(62, 50)
        Me.ChkTitle.TabIndex = 28
        Me.ChkTitle.Text = "Search in Doc ""Title"""
        Me.ChkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkTitle.UseVisualStyleBackColor = True
        '
        'ChkKey
        '
        Me.ChkKey.Location = New System.Drawing.Point(395, 388)
        Me.ChkKey.Name = "ChkKey"
        Me.ChkKey.Size = New System.Drawing.Size(60, 44)
        Me.ChkKey.TabIndex = 29
        Me.ChkKey.Text = "Search By Key Words"
        Me.ChkKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkKey.UseVisualStyleBackColor = True
        '
        'txtSrc
        '
        Me.txtSrc.Location = New System.Drawing.Point(564, 400)
        Me.txtSrc.Name = "txtSrc"
        Me.txtSrc.Size = New System.Drawing.Size(234, 20)
        Me.txtSrc.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(342, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "OR"
        '
        'CmdClasif
        '
        Me.CmdClasif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClasif.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdClasif.Image = CType(resources.GetObject("CmdClasif.Image"), System.Drawing.Image)
        Me.CmdClasif.Location = New System.Drawing.Point(580, 64)
        Me.CmdClasif.Name = "CmdClasif"
        Me.CmdClasif.Size = New System.Drawing.Size(23, 19)
        Me.CmdClasif.TabIndex = 32
        '
        'frmQAImportWordDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 496)
        Me.Controls.Add(Me.CmdClasif)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSrc)
        Me.Controls.Add(Me.ChkKey)
        Me.Controls.Add(Me.ChkTitle)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RdMod)
        Me.Controls.Add(Me.RdRead)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtShow)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.CmdSrc)
        Me.Controls.Add(Me.CmdExpand)
        Me.Controls.Add(Me.CmdCollapse)
        Me.Controls.Add(Me.Pb1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmdRemove)
        Me.Controls.Add(Me.TrView)
        Me.Controls.Add(Me.CmbNode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmdSave)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblFilePath)
        Me.Controls.Add(Me.CmdBrowse)
        Me.Name = "frmQAImportWordDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Quality Control Documents - ADMIN Module"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdBrowse As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblFilePath As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbNode As System.Windows.Forms.ComboBox
    Friend WithEvents TrView As System.Windows.Forms.TreeView
    Friend WithEvents CmdRemove As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdCollapse As System.Windows.Forms.Button
    Friend WithEvents CmdExpand As System.Windows.Forms.Button
    Friend WithEvents CmdSrc As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents txtShow As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RdRead As System.Windows.Forms.RadioButton
    Friend WithEvents RdMod As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkTitle As System.Windows.Forms.CheckBox
    Friend WithEvents ChkKey As System.Windows.Forms.CheckBox
    Friend WithEvents txtSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdClasif As System.Windows.Forms.Button
End Class
