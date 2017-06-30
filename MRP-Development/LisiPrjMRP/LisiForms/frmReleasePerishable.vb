Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmReleasePerishable

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowPer As Integer = 0
    Dim SwVal As Boolean

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 


    Private Sub frmReleasePerishable_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmReleasePerishable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GC.Collect()

        Call SetupForm()

    End Sub

    Sub SetupForm()

        txtSearch.Text = ""

        InitialComponents()

        SetCtlForm()

        dgPer.AutoGenerateColumns = False
        dgPer.DataSource = dsMain
        dgPer.DataMember = "tblStockPerishable"

        dgPer.Focus()

        CalculValue()

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getStFinaltblStockPerishable").Fill(dsMain, "tblStockPerishable")

    End Sub

    Sub SetCtlForm()


        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With


        With Me.ProdSpec
            .DataPropertyName = "ProdSpec"
            .Name = "ProdSpec"
        End With


        With Me.StockLoc
            .DataPropertyName = "StockLoc"
            .Name = "StockLoc"
        End With


        With Me.FinalStock
            .DataPropertyName = "FinalStock"
            .Name = "FinalStock"
        End With


        With Me.StUM
            .DataPropertyName = "StUM"
            .Name = "StUM"
        End With


        With Me.StPrice
            .DataPropertyName = "StPrice"
            .Name = "StPrice"
        End With


        With Me.StDevise
            .DataPropertyName = "StDevise"
            .Name = "StDevise"
        End With


        With Me.SwFinalSold
            .DataPropertyName = "SwFinalSold"
            .Name = "SwFinalSold"
        End With


        With Me.StDate
            .DataPropertyName = "StDate"
            .Name = "StDate"
        End With


        With Me.StNotes
            .DataPropertyName = "StNotes"
            .Name = "StNotes"
        End With


        With Me.StockPerishableID
            .DataPropertyName = "StockPerishableID"
            .Name = "StockPerishableID"
            .Visible = False
        End With


        With Me.ProdStockID
            .DataPropertyName = "ProdStockID"
            .Name = "ProdStockID"
            .Visible = False
        End With


        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
            .Visible = False
        End With

    End Sub


    Sub CalculValue()

        For Each row As DataGridViewRow In dgPer.Rows
            row.Cells("SwFinalSold").Value = row.Cells("FinalStock").Value * row.Cells("StPrice").Value
        Next

    End Sub

    Private Sub dgPer_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgPer.CellBeginEdit

        Select Case e.Cancel

            Case 0 To 9
                e.Cancel = True
        End Select

    End Sub

   
    Private Sub dgPer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPer.CellClick

        GC.Collect()

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPer = e.ColumnIndex
        End If

    End Sub

End Class