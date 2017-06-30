Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmPartProcGetOper
    Inherits System.Windows.Forms.Form

    Dim cnSql As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon
    Private dss As New DataSet
    Dim daa As New SqlDataAdapter

    Dim TakeRowIdx As Integer

    Private Sub frmPartProcGetOper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        dss.Clear()
        dss.Relations.Clear()

        daa = CallClass.PopulateDataAdapter("gettblPartProcOperSortByDescr")
        daa.Fill(dss, "tblPartProcOper")

        dss.EnforceConstraints = False

        With Me.OperDescr
            .DataPropertyName = "OperDescr"
            .Name = "OperDescr"
        End With

        With Me.OperSpec
            .DataPropertyName = "OperSpec"
            .Name = "OperSpec"
        End With

        dgOper.AutoGenerateColumns = False
        dgOper.DataSource = dss
        dgOper.DataMember = "tblPartProcOper"

        Cmdrestore.Enabled = True
        dgOper.ReadOnly = True

    End Sub

    Private Sub frmPartProcGetOper_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        dss.Dispose()
        daa.Dispose()
        cnSql.Close()

        GC.Collect()
    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call SearchText()
        End If

    End Sub

    Private Sub txtSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Leave

        Call SearchText()

    End Sub

    Private Sub SearchText()
        If Not Len(Trim(txtSearch.Text)) = 0 Then
            If Not IsDBNull(txtSearch.Text) Then
                Try
                    dss.Tables("tblPartProcOper").Clear()
                    daa = CallClass.PopulateDataAdapterAfterSearch("gettblPartProcOperForSearch", txtSearch.Text)
                    daa.Fill(dss, "tblPartProcOper")
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message)
                End Try
                Cmdrestore.Focus()
            End If
        End If

    End Sub

    Private Sub Cmdrestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdrestore.Click

        Try
            dss.Tables("tblPartProcOper").Clear()
            daa = CallClass.PopulateDataAdapter("gettblPartProcOperSortByDescr")
            daa.Fill(dss, "tblPartProcOper")
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Cmdrestore.Enabled = True
    End Sub

    Private Sub dgOper_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOper.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        TakeRowIdx = e.RowIndex

        If e.ColumnIndex = 0 Then
            If IsDBNull(Me.dgOper("OperDescr", TakeRowIdx).Value) = False Then
                frmPartProcess.SwGetOper.Text = Me.dgOper("OperDescr", TakeRowIdx).Value
            Else
                frmPartProcess.SwGetOper.Text = ""
            End If

            If IsDBNull(Me.dgOper("OperSpec", TakeRowIdx).Value) = False Then
                frmPartProcess.SwGetSpec.Text = Me.dgOper("OperSpec", TakeRowIdx).Value
            Else
                frmPartProcess.SwGetSpec.Text = ""
            End If

            Me.Close()
            cnSql.Close()
            dss.Dispose()
            daa.Dispose()
        End If

    End Sub

    Private Sub dgOper_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOper.DataError
        REM end
    End Sub

End Class