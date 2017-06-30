Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Public Class frmPONote

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Dim I As Integer
        I = CInt(txtRow.Text)
        frmPOMaster.dgDetail("PONotesItem", I).Value = txtPONotes.Text.ToString()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmPONote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Dim I, J As Integer
        I = CInt(txtRow.Text)
        txtRow.Visible = False
        J = Val(frmPOMaster.dgDetail("POItem", I).Value.ToString)

        If J = 0 Then
            MessageBox.Show("Action Denied. Enter before the PO item number.")
            Me.Dispose()
        End If
    End Sub
End Class