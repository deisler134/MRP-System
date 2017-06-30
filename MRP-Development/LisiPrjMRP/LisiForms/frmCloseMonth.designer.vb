<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCloseMonth
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
        Me.CmdTranz = New System.Windows.Forms.Button
        Me.CmdMatlRecv = New System.Windows.Forms.Button
        Me.CmdFP = New System.Windows.Forms.Button
        Me.CmdOpen = New System.Windows.Forms.Button
        Me.CmdMatlRel = New System.Windows.Forms.Button
        Me.CmdMatlAdj = New System.Windows.Forms.Button
        Me.CmdRawInv = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUSD = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEUR = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtGBP = New System.Windows.Forms.TextBox
        Me.cmdTranzFP = New System.Windows.Forms.Button
        Me.CmdPostInv = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CmdRMYTD = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CmdTranz
        '
        Me.CmdTranz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTranz.Location = New System.Drawing.Point(13, 89)
        Me.CmdTranz.Name = "CmdTranz"
        Me.CmdTranz.Size = New System.Drawing.Size(240, 37)
        Me.CmdTranz.TabIndex = 0
        Me.CmdTranz.Text = "UpDate Raw Material Inventory with the month Tranzactions."
        '
        'CmdMatlRecv
        '
        Me.CmdMatlRecv.Location = New System.Drawing.Point(419, 89)
        Me.CmdMatlRecv.Name = "CmdMatlRecv"
        Me.CmdMatlRecv.Size = New System.Drawing.Size(353, 21)
        Me.CmdMatlRecv.TabIndex = 1
        Me.CmdMatlRecv.Text = "Print Month  --  Raw Material  Receiving  -  INVENTORY  CHANGE  ACTIVITY"
        '
        'CmdFP
        '
        Me.CmdFP.Location = New System.Drawing.Point(419, 229)
        Me.CmdFP.Name = "CmdFP"
        Me.CmdFP.Size = New System.Drawing.Size(353, 21)
        Me.CmdFP.TabIndex = 2
        Me.CmdFP.Text = "Print Month  --  Finish Parts  -  INVENTORY  CHANGE  ACTIVITY"
        '
        'CmdOpen
        '
        Me.CmdOpen.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdOpen.Location = New System.Drawing.Point(9, 368)
        Me.CmdOpen.Name = "CmdOpen"
        Me.CmdOpen.Size = New System.Drawing.Size(244, 56)
        Me.CmdOpen.TabIndex = 3
        Me.CmdOpen.Text = "ReOpen Inventory. Prepare the Inventory tables for the next month."
        Me.CmdOpen.UseVisualStyleBackColor = False
        '
        'CmdMatlRel
        '
        Me.CmdMatlRel.Location = New System.Drawing.Point(419, 114)
        Me.CmdMatlRel.Name = "CmdMatlRel"
        Me.CmdMatlRel.Size = New System.Drawing.Size(353, 21)
        Me.CmdMatlRel.TabIndex = 4
        Me.CmdMatlRel.Text = "Print Month  --  Raw Material  Release  -  INVENTORY  CHANGE  ACTIVITY"
        '
        'CmdMatlAdj
        '
        Me.CmdMatlAdj.Location = New System.Drawing.Point(419, 141)
        Me.CmdMatlAdj.Name = "CmdMatlAdj"
        Me.CmdMatlAdj.Size = New System.Drawing.Size(353, 21)
        Me.CmdMatlAdj.TabIndex = 5
        Me.CmdMatlAdj.Text = "Print Month  --  Raw Material  Adjustment  -  INVENTORY  CHANGE  ACTIVITY"
        '
        'CmdRawInv
        '
        Me.CmdRawInv.Location = New System.Drawing.Point(419, 168)
        Me.CmdRawInv.Name = "CmdRawInv"
        Me.CmdRawInv.Size = New System.Drawing.Size(353, 21)
        Me.CmdRawInv.TabIndex = 6
        Me.CmdRawInv.Text = "Print Month  --  Raw Material  Inventory List"
        '
        'cmdCopy
        '
        Me.cmdCopy.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(9, 341)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(244, 21)
        Me.cmdCopy.TabIndex = 7
        Me.cmdCopy.Text = "Archive Current Month Data"
        Me.cmdCopy.UseVisualStyleBackColor = False
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(88, 18)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(100, 20)
        Me.txtDate.TabIndex = 8
        Me.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(12, 17)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(67, 13)
        Me.lbl1.TabIndex = 9
        Me.lbl1.Text = "System Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Status Month"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(88, 44)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(100, 20)
        Me.txtMonth.TabIndex = 10
        Me.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Lisi Date From"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(276, 18)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtDateFrom.TabIndex = 12
        Me.txtDateFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Lisi Date To"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(276, 44)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(100, 20)
        Me.txtDateTo.TabIndex = 14
        Me.txtDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(399, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Exchange Rate - USD"
        '
        'txtUSD
        '
        Me.txtUSD.Location = New System.Drawing.Point(400, 44)
        Me.txtUSD.Name = "txtUSD"
        Me.txtUSD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUSD.Size = New System.Drawing.Size(108, 20)
        Me.txtUSD.TabIndex = 16
        Me.txtUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(530, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Exchange Rate - EUR"
        '
        'txtEUR
        '
        Me.txtEUR.Location = New System.Drawing.Point(531, 44)
        Me.txtEUR.Name = "txtEUR"
        Me.txtEUR.Size = New System.Drawing.Size(108, 20)
        Me.txtEUR.TabIndex = 18
        Me.txtEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(662, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Exchange Rate - GBP"
        '
        'txtGBP
        '
        Me.txtGBP.Location = New System.Drawing.Point(663, 44)
        Me.txtGBP.Name = "txtGBP"
        Me.txtGBP.Size = New System.Drawing.Size(108, 20)
        Me.txtGBP.TabIndex = 20
        Me.txtGBP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdTranzFP
        '
        Me.cmdTranzFP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTranzFP.Location = New System.Drawing.Point(13, 141)
        Me.cmdTranzFP.Name = "cmdTranzFP"
        Me.cmdTranzFP.Size = New System.Drawing.Size(240, 37)
        Me.cmdTranzFP.TabIndex = 22
        Me.cmdTranzFP.Text = "UpDate Finish Parts Inventory with the month Tranzactions."
        '
        'CmdPostInv
        '
        Me.CmdPostInv.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CmdPostInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPostInv.Location = New System.Drawing.Point(13, 193)
        Me.CmdPostInv.Name = "CmdPostInv"
        Me.CmdPostInv.Size = New System.Drawing.Size(240, 37)
        Me.CmdPostInv.TabIndex = 23
        Me.CmdPostInv.Text = "Post the Invoices from Sales Module"
        Me.CmdPostInv.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(506, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdRMYTD
        '
        Me.CmdRMYTD.BackColor = System.Drawing.Color.Gold
        Me.CmdRMYTD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdRMYTD.Location = New System.Drawing.Point(12, 236)
        Me.CmdRMYTD.Name = "CmdRMYTD"
        Me.CmdRMYTD.Size = New System.Drawing.Size(240, 37)
        Me.CmdRMYTD.TabIndex = 25
        Me.CmdRMYTD.Text = "UpDate Raw Material Inventory YTD"
        Me.CmdRMYTD.UseVisualStyleBackColor = False
        '
        'frmCloseMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 445)
        Me.Controls.Add(Me.CmdRMYTD)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdPostInv)
        Me.Controls.Add(Me.cmdTranzFP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtGBP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEUR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUSD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.CmdRawInv)
        Me.Controls.Add(Me.CmdMatlAdj)
        Me.Controls.Add(Me.CmdMatlRel)
        Me.Controls.Add(Me.CmdOpen)
        Me.Controls.Add(Me.CmdFP)
        Me.Controls.Add(Me.CmdMatlRecv)
        Me.Controls.Add(Me.CmdTranz)
        Me.Name = "frmCloseMonth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Month-End ( Closing  and  Opening Inventory)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdTranz As System.Windows.Forms.Button
    Friend WithEvents CmdMatlRecv As System.Windows.Forms.Button
    Friend WithEvents CmdFP As System.Windows.Forms.Button
    Friend WithEvents CmdOpen As System.Windows.Forms.Button
    Friend WithEvents CmdMatlRel As System.Windows.Forms.Button
    Friend WithEvents CmdMatlAdj As System.Windows.Forms.Button
    Friend WithEvents CmdRawInv As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEUR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGBP As System.Windows.Forms.TextBox
    Friend WithEvents cmdTranzFP As System.Windows.Forms.Button
    Friend WithEvents CmdPostInv As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdRMYTD As System.Windows.Forms.Button
End Class
