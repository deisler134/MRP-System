Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmQuoteEngEst
    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim ds As New DataSet
    Dim da As New SqlDataAdapter

    Private Sub frmQuoteEngEst_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds.Dispose()
        da.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmQuoteEngEst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        ds.Clear()
        ds.Relations.Clear()

        da = CallClass.PopulateDataAdapter("getTblQuoteEngEst")
        da.FillSchema(ds, SchemaType.Source, "tblQuote")
        da.Fill(ds, "tblQuote")

        ds.EnforceConstraints = False

        With Me.QID
            .DataPropertyName = "QID"
            .Name = "QID"
            .Visible = False
        End With

        With Me.QNo
            .DataPropertyName = "QNo"
            .Name = "QNo"
        End With

        With Me.QDate
            .DataPropertyName = "QDate"
            .Name = "QDate"
        End With

        With Me.QAsk
            .DataPropertyName = "QAsk"
            .Name = "QAsk"
        End With

        With Me.Form
            .DataPropertyName = "Form"
            .Name = "Form"
        End With

        'dg.ReadOnly = True
        dg.AutoGenerateColumns = False
        dg.DataSource = ds
        dg.DataMember = "tblQuote"

    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        Try
            Select Case e.ColumnIndex
                Case 4
                    frmQuote.SwFormQT.Text = dg.Rows(e.RowIndex).Cells("QID").Value
                    frmQuote.ShowDialog()
                    frmQuote.Dispose()
            End Select
        Catch ex As Exception
        End Try
    End Sub

End Class