<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccHeadOfficeLACQueriesUpdateMachCost
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgTrav = New System.Windows.Forms.DataGridView
        Me.txtMPOID = New System.Windows.Forms.TextBox
        Me.TrOperNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrOperDescr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrDeptHrRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyAccTemp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrMachCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrMpoID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MpoNotes = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgTrav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgTrav
        '
        Me.dgTrav.AllowUserToAddRows = False
        Me.dgTrav.AllowUserToDeleteRows = False
        Me.dgTrav.AllowUserToResizeRows = False
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgTrav.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTrav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTrav.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTrav.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgTrav.ColumnHeadersHeight = 45
        Me.dgTrav.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgTrav.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrOperNo, Me.TrOperDescr, Me.TrDeptHrRate, Me.QtyAccTemp, Me.TotalTime, Me.TrMachCost, Me.TrMpoID, Me.MpoNotes})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTrav.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgTrav.Location = New System.Drawing.Point(12, 12)
        Me.dgTrav.Name = "dgTrav"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-US")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTrav.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgTrav.RowHeadersWidth = 25
        Me.dgTrav.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgTrav.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgTrav.RowTemplate.DefaultCellStyle.FormatProvider = New System.Globalization.CultureInfo("en-US")
        Me.dgTrav.RowTemplate.Height = 18
        Me.dgTrav.Size = New System.Drawing.Size(1007, 886)
        Me.dgTrav.TabIndex = 55
        Me.dgTrav.Text = "DataGridView1"
        '
        'txtMPOID
        '
        Me.txtMPOID.BackColor = System.Drawing.Color.DarkRed
        Me.txtMPOID.Location = New System.Drawing.Point(556, 22)
        Me.txtMPOID.Name = "txtMPOID"
        Me.txtMPOID.Size = New System.Drawing.Size(121, 20)
        Me.txtMPOID.TabIndex = 59
        Me.txtMPOID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMPOID.Visible = False
        '
        'TrOperNo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TrOperNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.TrOperNo.HeaderText = "Oper No"
        Me.TrOperNo.Name = "TrOperNo"
        Me.TrOperNo.Width = 70
        '
        'TrOperDescr
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TrOperDescr.DefaultCellStyle = DataGridViewCellStyle4
        Me.TrOperDescr.HeaderText = "Oper Descr."
        Me.TrOperDescr.Name = "TrOperDescr"
        Me.TrOperDescr.Width = 600
        '
        'TrDeptHrRate
        '
        DataGridViewCellStyle5.Format = "c2"
        Me.TrDeptHrRate.DefaultCellStyle = DataGridViewCellStyle5
        Me.TrDeptHrRate.HeaderText = "Dept Hr. Rate"
        Me.TrDeptHrRate.Name = "TrDeptHrRate"
        Me.TrDeptHrRate.Width = 70
        '
        'QtyAccTemp
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle6.Format = "n0"
        Me.QtyAccTemp.DefaultCellStyle = DataGridViewCellStyle6
        Me.QtyAccTemp.HeaderText = "Qty Accepted"
        Me.QtyAccTemp.Name = "QtyAccTemp"
        Me.QtyAccTemp.Width = 70
        '
        'TotalTime
        '
        DataGridViewCellStyle7.Format = "n0"
        Me.TotalTime.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalTime.HeaderText = "Total Time"
        Me.TotalTime.Name = "TotalTime"
        Me.TotalTime.Width = 70
        '
        'TrMachCost
        '
        DataGridViewCellStyle8.Format = "c2"
        Me.TrMachCost.DefaultCellStyle = DataGridViewCellStyle8
        Me.TrMachCost.HeaderText = "Mach. Cost"
        Me.TrMachCost.Name = "TrMachCost"
        Me.TrMachCost.Width = 70
        '
        'TrMpoID
        '
        Me.TrMpoID.HeaderText = "TrMpoID"
        Me.TrMpoID.MinimumWidth = 2
        Me.TrMpoID.Name = "TrMpoID"
        Me.TrMpoID.Visible = False
        Me.TrMpoID.Width = 2
        '
        'MpoNotes
        '
        Me.MpoNotes.HeaderText = "MpoNotes"
        Me.MpoNotes.MinimumWidth = 2
        Me.MpoNotes.Name = "MpoNotes"
        Me.MpoNotes.Visible = False
        Me.MpoNotes.Width = 2
        '
        'frmAccHeadOfficeLACQueriesUpdateMachCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 910)
        Me.Controls.Add(Me.txtMPOID)
        Me.Controls.Add(Me.dgTrav)
        Me.Name = "frmAccHeadOfficeLACQueriesUpdateMachCost"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lisi Aerospace Canada  -  Machining Cost Update"
        CType(Me.dgTrav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgTrav As System.Windows.Forms.DataGridView
    Friend WithEvents txtMPOID As System.Windows.Forms.TextBox
    Friend WithEvents TrOperNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrOperDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrDeptHrRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyAccTemp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrMachCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrMpoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MpoNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
