<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOReceivingPriceAdj
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
        Me.txtLotGr = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtWeightBefore = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOldPrice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMachCost = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtWeightAfter = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPOPrice = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNewMatlPrice = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMatlValue = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtLotGr
        '
        Me.txtLotGr.Location = New System.Drawing.Point(190, 26)
        Me.txtLotGr.Name = "txtLotGr"
        Me.txtLotGr.ReadOnly = True
        Me.txtLotGr.Size = New System.Drawing.Size(135, 20)
        Me.txtLotGr.TabIndex = 17
        Me.txtLotGr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Matl Lot - Grinding"
        '
        'txtWeightBefore
        '
        Me.txtWeightBefore.Enabled = False
        Me.txtWeightBefore.Location = New System.Drawing.Point(190, 52)
        Me.txtWeightBefore.Name = "txtWeightBefore"
        Me.txtWeightBefore.ReadOnly = True
        Me.txtWeightBefore.Size = New System.Drawing.Size(135, 20)
        Me.txtWeightBefore.TabIndex = 19
        Me.txtWeightBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Matl Weight for - Grinding"
        '
        'txtOldPrice
        '
        Me.txtOldPrice.Enabled = False
        Me.txtOldPrice.Location = New System.Drawing.Point(190, 78)
        Me.txtOldPrice.Name = "txtOldPrice"
        Me.txtOldPrice.ReadOnly = True
        Me.txtOldPrice.Size = New System.Drawing.Size(135, 20)
        Me.txtOldPrice.TabIndex = 21
        Me.txtOldPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Matl Price"
        '
        'txtMachCost
        '
        Me.txtMachCost.Enabled = False
        Me.txtMachCost.Location = New System.Drawing.Point(490, 136)
        Me.txtMachCost.Name = "txtMachCost"
        Me.txtMachCost.ReadOnly = True
        Me.txtMachCost.Size = New System.Drawing.Size(135, 20)
        Me.txtMachCost.TabIndex = 23
        Me.txtMachCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(395, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Machining Cost"
        '
        'txtWeightAfter
        '
        Me.txtWeightAfter.Enabled = False
        Me.txtWeightAfter.Location = New System.Drawing.Point(190, 198)
        Me.txtWeightAfter.Name = "txtWeightAfter"
        Me.txtWeightAfter.ReadOnly = True
        Me.txtWeightAfter.Size = New System.Drawing.Size(135, 20)
        Me.txtWeightAfter.TabIndex = 25
        Me.txtWeightAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Matl Weight after - Grinding"
        '
        'txtPOPrice
        '
        Me.txtPOPrice.Location = New System.Drawing.Point(490, 162)
        Me.txtPOPrice.Name = "txtPOPrice"
        Me.txtPOPrice.Size = New System.Drawing.Size(135, 20)
        Me.txtPOPrice.TabIndex = 27
        Me.txtPOPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(395, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "*** PO Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(630, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "CAD"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(630, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "USD"
        '
        'txtNewMatlPrice
        '
        Me.txtNewMatlPrice.Enabled = False
        Me.txtNewMatlPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewMatlPrice.ForeColor = System.Drawing.Color.Maroon
        Me.txtNewMatlPrice.Location = New System.Drawing.Point(190, 224)
        Me.txtNewMatlPrice.Name = "txtNewMatlPrice"
        Me.txtNewMatlPrice.ReadOnly = True
        Me.txtNewMatlPrice.Size = New System.Drawing.Size(135, 26)
        Me.txtNewMatlPrice.TabIndex = 31
        Me.txtNewMatlPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(38, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Matl Price after - Grinding"
        '
        'txtMatlValue
        '
        Me.txtMatlValue.Enabled = False
        Me.txtMatlValue.Location = New System.Drawing.Point(190, 104)
        Me.txtMatlValue.Name = "txtMatlValue"
        Me.txtMatlValue.ReadOnly = True
        Me.txtMatlValue.Size = New System.Drawing.Size(135, 20)
        Me.txtMatlValue.TabIndex = 33
        Me.txtMatlValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Matl Value"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(38, 270)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(514, 26)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "(Matl Weight for Grinding * (Matl Price+ Grinding PO Price)) / Matl Weight after " & _
            "Grinding"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(331, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "USD"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(331, 227)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "USD"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(331, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "USD"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(331, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "LB"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(331, 201)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "LB"
        '
        'frmPOReceivingPriceAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 331)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtMatlValue)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNewMatlPrice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPOPrice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtWeightAfter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMachCost)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOldPrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWeightBefore)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLotGr)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmPOReceivingPriceAdj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  RM Price Calculation After Grinding Operation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLotGr As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWeightBefore As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOldPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMachCost As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWeightAfter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPOPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNewMatlPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMatlValue As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
