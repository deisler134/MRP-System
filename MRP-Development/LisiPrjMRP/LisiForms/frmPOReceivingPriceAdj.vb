Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class frmPOReceivingPriceAdj

    Inherits System.Windows.Forms.Form

    Private Sub frmPOReceivingPriceAdj_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        frmPOReceiving.SwPrice.Text = txtNewMatlPrice.Text

        GC.Collect()
        Me.Dispose()
    End Sub

    Private Sub frmPOReceivingPriceAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        txtOldPrice.Text = Val(txtOldPrice.Text).ToString("C2")
        txtMachCost.Text = Val(txtMachCost.Text).ToString("C2")
        txtPOPrice.Text = Val(txtPOPrice.Text).ToString("C2")
        txtNewMatlPrice.Text = Val(txtNewMatlPrice.Text).ToString("C2")

        txtMatlValue.Text = (txtWeightBefore.Text * txtOldPrice.Text).ToString("C2")

        CalcPrice()

    End Sub

    Sub CalcPrice()

        txtNewMatlPrice.Text = ((CDec(txtWeightBefore.Text) * (CDec(txtOldPrice.Text) + CDec(txtPOPrice.Text))) / CDec(txtWeightAfter.Text)).ToString("C2")

    End Sub

    Private Sub txtPOPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOPrice.TextChanged
        CalcPrice()
    End Sub

    Private Sub txtPOPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPOPrice.Validating
        CalcPrice()
    End Sub

End Class