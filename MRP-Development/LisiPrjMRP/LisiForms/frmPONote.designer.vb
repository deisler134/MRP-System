<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPONote
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
        Me.txtPONotes = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPONotes
        '
        Me.txtPONotes.Location = New System.Drawing.Point(12, 26)
        Me.txtPONotes.Multiline = True
        Me.txtPONotes.Name = "txtPONotes"
        Me.txtPONotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPONotes.Size = New System.Drawing.Size(1091, 510)
        Me.txtPONotes.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(465, 552)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 37)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(293, 0)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(100, 20)
        Me.txtRow.TabIndex = 2
        '
        'frmPONote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 601)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtRow)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtPONotes)
        Me.Name = "frmPONote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lisi Aerospace Canada  -  Purchase Order Notes item"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPONotes As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtRow As System.Windows.Forms.TextBox
End Class
