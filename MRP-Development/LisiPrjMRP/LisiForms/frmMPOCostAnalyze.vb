Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmMPOCostAnalyze

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMPO As Integer = 0       'dgMPO row.

    Private dsMain As New DataSet

    Private Sub frmMPOCostAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmMPOCostAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

    End Sub

    Sub ClearFields()

        txtDateYear.Text = ""
        txtPart.Text = ""
        txtValue.Text = ""

        CmbSelCust.Text = ""
        CmbMpoType.Text = ""

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getMPOCostAnalyzeEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        'dgmpo

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.MatlWeight
            .DataPropertyName = "MatlWeight"
            .Name = "MatlWeight"
        End With

        With Me.MPORMValueUsedCDN
            .DataPropertyName = "MPORMValueUsedCDN"
            .Name = "MPORMValueUsedCDN"
        End With

        With Me.MpoRMCostCDN
            .DataPropertyName = "MpoRMCostCDN"
            .Name = "MpoRMCostCDN"
        End With

        With Me.MpoMachCostCDN
            .DataPropertyName = "MpoMachCostCDN"
            .Name = "MpoMachCostCDN"
        End With

        With Me.MPOProcessingCost
            .DataPropertyName = "MPOProcessingCost"
            .Name = "MPOProcessingCost"
        End With

        With Me.SwMachCostYear
            .DataPropertyName = "SwMachCostYear"
            .Name = "SwMachCostYear"
        End With

        With Me.SwTotalCost
            .DataPropertyName = "SwTotalCost"
            .Name = "SwTotalCost"
        End With

        With Me.TotalDaysINMFG
            .DataPropertyName = "TotalDaysINMFG"
            .Name = "TotalDaysINMFG"
        End With

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        Dim Par1, Par2, Par3, Par4 As String

        Par1 = CmbMpoType.Text

        If Len(Trim(txtDateYear.Text)) = 0 Then
            Par2 = Year(Now())
        Else
            Par2 = txtDateYear.Text
        End If

        Par3 = txtPart.Text
        Par4 = CmbSelCust.Text

        txtValue.Text = ""

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()
        CallClass.PopulateDataAdapterSearch4Param("getMPOCostAnalyze", Par1, Par2, Par3, Par4).Fill(dsMain, "tblSelect")

        TakeYearCost()
        CalculUnitCost()
        CalculTotalValue()

    End Sub

    Sub CalculTotalValue()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMPO.Rows



            If Nz.Nz(Row.Cells("QtyActual").Value) = 0 Then
                Row.Cells("SwMPOCostValue").Value = Nz.Nz(Row.Cells("SwTotalCost").Value) * Nz.Nz(Row.Cells("QtyEngReleased").Value)
                qty = qty + Nz.Nz(Row.Cells("SwTotalCost").Value) * Nz.Nz(Row.Cells("QtyEngReleased").Value)
            Else
                Row.Cells("SwMPOCostValue").Value = Nz.Nz(Row.Cells("SwTotalCost").Value) * Nz.Nz(Row.Cells("QtyActual").Value)
                qty = qty + Nz.Nz(Row.Cells("SwTotalCost").Value) * Nz.Nz(Row.Cells("QtyActual").Value)
            End If
        Next
        txtValue.Text = qty.ToString("C2")
        txtValue.ReadOnly = True

    End Sub

    Sub CalculUnitCost()

        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("SwTotalCost").Value = CDbl(Nz.Nz(Row.Cells("MpoRMCostCDN").Value)) + CDbl(Nz.Nz(Row.Cells("SwMachCostYear").Value)) + CDbl(Nz.Nz(Row.Cells("MPOProcessingCost").Value))
        Next

    End Sub

    Sub TakeYearCost()

        Dim SwCost As String = ""

        For Each Row As DataGridViewRow In dgMPO.Rows
            SwCost = ""
            SwCost = CallClass.ReturnStrWith2ParStr("cspReturnMPOYearCost", Nz.Nz(Row.Cells("mpoid").Value), txtDateYear.Text)
            If SwCost = "False" Then
                Row.Cells("SwMachCostYear").Value = 0
            Else
                Row.Cells("SwMachCostYear").Value = CDbl(SwCost)
            End If

        Next

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        Try
            Dim wapp As Excel.Application
            Dim wsheet As Excel.Worksheet
            Dim wbook As Excel.Workbook
            wapp = New Excel.Application

            wapp.Visible = True
            wbook = wapp.Workbooks.Add()
            wsheet = wbook.ActiveSheet

            Dim iX As Integer
            Dim iY As Integer
            Dim iC As Integer

            For iC = 0 To dgMPO.Columns.Count - 2
                wsheet.Cells(1, iC + 1).Value = dgMPO.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgMPO.Rows.Count - 1
                For iY = 0 To dgMPO.Columns.Count - 2
                    wsheet.Cells(iX + 2, iY + 1).value = dgMPO(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub

    Private Sub dgMPO_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMPO.Sorted
        TakeYearCost()
        CalculUnitCost()
    End Sub

End Class