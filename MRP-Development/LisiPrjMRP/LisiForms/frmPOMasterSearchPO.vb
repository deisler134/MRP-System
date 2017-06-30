Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPOMasterSearchPO

    Inherits System.Windows.Forms.Form

    Dim CallClass As New clsCommon

    Private dsPO As New DataSet

    Dim strSQL As String

    Private Sub frmPOMasterSearchPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
        Catch ex As Exception
            MsgBox("Exception occured - Closing Form  " & ex.Message)
        End Try

        GC.Collect()
    End Sub


    Private Sub frmPOMasterSearchPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        CmdListAll.Enabled = True
        CmdSearchPO.Enabled = False


        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
        End With

        With Me.POStatus
            .DataPropertyName = "POStatus"
            .Name = "POStatus"
        End With

        With Me.PoType
            .DataPropertyName = "PoType"
            .Name = "PoType"
        End With


        With Me.CmbPOSupp
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub dgSearch_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            frmPOMaster.FindPO.Text = Me.dgSearch("PONo", e.RowIndex).Value
            frmPOMaster.FindPO.Enabled = True
            dsPO.Dispose()
            Me.Close()
        End If

    End Sub

    Private Sub dgSearch_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSearch.DataError

        REM end
    End Sub

    Private Sub CmdListAll_Click(sender As Object, e As EventArgs) Handles CmdListAll.Click

        dsPO.Clear()

        txtPONo.Text = ""
        CmbPOSupp.SelectedIndex = -1

        Me.Cursor = Cursors.WaitCursor

        CallClass.PopulateDataAdapter("gettblPOMasterFindPO").Fill(dsPO, "tblPOMaster")

        dgSearch.AutoGenerateColumns = False
        dgSearch.DataSource = dsPO
        dgSearch.DataMember = "tblPOMaster"

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdSearchPO_Click(sender As Object, e As EventArgs) Handles CmdSearchPO.Click

        dsPO.Clear()

        CmbPOSupp.SelectedIndex = -1

        Me.Cursor = Cursors.WaitCursor

        If txtPONo.Text = "" Or Len(Trim(txtPONo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! PO Number is Empty.")
        Else
            CallClass.PopulateDataAdapterAfterSearch("getTblPoMasterByPOSerachModule", txtPONo.Text).Fill(dsPO, "tblPOMaster")
            dgSearch.AutoGenerateColumns = False
            dgSearch.DataSource = dsPO
            dgSearch.DataMember = "tblPOMaster"
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub txtPONo_VisibleChanged(sender As Object, e As EventArgs) Handles txtPONo.VisibleChanged

        CmdSearchPO.Enabled = True

    End Sub

    Private Sub CmdSearchSupp_Click(sender As Object, e As EventArgs) Handles CmdSearchSupp.Click

        dsPO.Clear()

        txtPONo.Text = ""

        Me.Cursor = Cursors.WaitCursor

        If CmbPOSupp.Text = "" Or Len(Trim(CmbPOSupp.Text)) = 0 Or CmbPOSupp.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! PO Supplier is Empty.")
        Else
            CallClass.PopulateDataAdapterAfterSearch("getTblPoMasterBySupplierSearchModule", CmbPOSupp.SelectedValue).Fill(dsPO, "tblPOMaster")
            dgSearch.AutoGenerateColumns = False
            dgSearch.DataSource = dsPO
            dgSearch.DataMember = "tblPOMaster"
        End If

        Me.Cursor = Cursors.Default

    End Sub

End Class