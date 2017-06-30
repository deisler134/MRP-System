Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmOTD

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowProd As Integer = 0

    Private Sub frmOTD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub       'dgProd row.

    Private Sub frmOTD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()
        SetCtlForm()
        ClearFields()
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getLNAOTDEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgProd.AutoGenerateColumns = False
        dgProd.DataSource = dsMain
        dgProd.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.OrdRevision
            .DataPropertyName = "OrdRevision"
            .Name = "OrdRevision"
        End With

        With Me.OrdDate
            .DataPropertyName = "OrdDate"
            .Name = "OrdDate"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.Year
            .DataPropertyName = "Year"
            .Name = "Year"
        End With

        With Me.Month
            .DataPropertyName = "Month"
            .Name = "Month"
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.SwRel
            .DataPropertyName = "SwRel"
            .Name = "SwRel"
        End With

        With Me.SwLead
            .DataPropertyName = "SwLead"
            .Name = "SwLead"
        End With

        With Me.SwWks
            .DataPropertyName = "SwWks"
            .Name = "SwWks"
        End With

    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""

        txt20POtobe.Text = ""
        txt30POtobe.Text = ""

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Private Sub dgProd_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProd.DataError
        REM end
    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        Dim Par1, Par2 As String

        If Len(Trim(txtDateFrom.Text)) = 0 Then
            Par1 = "01/01/2005"
        Else
            Par1 = txtDateFrom.Text
        End If

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par2 = DateAdd(DateInterval.Day, 1000, Date.Now).ToShortDateString()
        Else
            Par2 = txtDateTo.Text
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()
        CallClass.PopulateDataAdapterSearch2Param("getLNAODT", Par1, Par2).Fill(dsMain, "tblSelect")
        PutInfo()
        CalculToatlVal()

    End Sub

    Sub PutInfo()

        For Each Row As DataGridViewRow In dgProd.Rows

            Row.Cells("SwRel").Value = CallClass.ReturnStrWith2ParStr("cspReturnLNAOTDRelNo", Row.Cells("PartID").Value, Row.Cells("OrdDate").Value)

            If Nz.Nz(Row.Cells("SwRel").Value) <= 1 Then
                Row.Cells("SwLead").Value = "30"
            Else
                Row.Cells("SwLead").Value = "20"
            End If

            Row.Cells("SwDays").Value = DateDiff(DateInterval.Day, Row.Cells("OrdDate").Value, Row.Cells("InvDate").Value)

            If Nz.Nz(Row.Cells("SwDays").Value) <> 0 Then
                Row.Cells("SwWks").Value = Math.Round((Row.Cells("SwDays").Value / 7), 0)
            End If
        Next

    End Sub

    Private Sub dgProd_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProd.Sorted
        Me.Refresh()
        PutInfo()
    End Sub

    Sub CalculToatlVal()

        Dim ICount20 As Int16 = 0
        Dim ICount30 As Int16 = 0

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("SwLead").Value = "20" Then
                ICount20 = ICount20 + 1
            Else
                ICount30 = ICount30 + 1
            End If
        Next
        txt20POtobe.Text = ICount20.ToString("N0")
        txt20POtobe.ReadOnly = True

        txt30POtobe.Text = ICount30.ToString("N0")
        txt30POtobe.ReadOnly = True

    End Sub

End Class