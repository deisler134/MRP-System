Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmLisiMemoSrc

    Inherits System.Windows.Forms.Form

    Dim CallClass As New clsCommon

    Private dsSrc As New DataSet

    Dim strSQL As String

    Private Sub frmLisiMemoSrc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
        Catch ex As Exception
            MsgBox("Exception occured - Closing Form  " & ex.Message)
        End Try

        GC.Collect()
    End Sub

    Private Sub frmLisiMemoSrc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        dsSrc.Clear()

        CallClass.PopulateDataAdapter("gettblLisiMemoSearch").Fill(dsSrc, "tblMemo")

        With Me.MemoId
            .DataPropertyName = "MemoId"
            .Name = "MemoId"
            .Visible = False
        End With

        With Me.InternalSource
            .DataPropertyName = "InternalSource"
            .Name = "InternalSource"
            .Visible = False
        End With

        With Me.MemoNoPrefix
            .DataPropertyName = "MemoNoPrefix"
            .Name = "MemoNoPrefix"
        End With

        With Me.MemoNo
            .DataPropertyName = "MemoNo"
            .Name = "MemoNo"
        End With

        With Me.ApprSystem
            .DataPropertyName = "ApprSystem"
            .Name = "ApprSystem"
        End With

        With Me.InternalMfg
            .DataPropertyName = "InternalMfg"
            .Name = "InternalMfg"
        End With

        With Me.InternalQuality
            .DataPropertyName = "InternalQuality"
            .Name = "InternalQuality"
        End With

        With Me.ApprHSE
            .DataPropertyName = "ApprHSE"
            .Name = "ApprHSE"
        End With

        With Me.InternalHelth
            .DataPropertyName = "InternalHelth"
            .Name = "InternalHelth"
        End With

        With Me.InternalSafety
            .DataPropertyName = "InternalSafety"
            .Name = "InternalSafety"
        End With

        With Me.InternalEnvironment
            .DataPropertyName = "InternalEnvironment"
            .Name = "InternalEnvironment"
        End With

        With Me.InternalTraining
            .DataPropertyName = "InternalTraining"
            .Name = "InternalTraining"
        End With

        With Me.MemoIR
            .DataPropertyName = "MemoIR"
            .Name = "MemoIR"
        End With

        With Me.MemoRMA
            .DataPropertyName = "MemoRMA"
            .Name = "MemoRMA"
        End With

        With Me.SwInternal
            .DataPropertyName = "SwInternal"
            .Name = "SwInternal"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.CustomerName
            .DataPropertyName = "CustomerName"
            .Name = "CustomerName"
        End With

        With Me.MPOType
            .DataPropertyName = "MPOType"
            .Name = "MPOType"
        End With

        With Me.MPONO
            .DataPropertyName = "MPONO"
            .Name = "MPONO"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.MemoStatus
            .DataPropertyName = "MemoStatus"
            .Name = "MemoStatus"
        End With

        With Me.CreatedUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEmployeeAll").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DataPropertyName = "CreatedUser"
            .Name = "CreatedUser"
        End With

        With Me.CreatedDate
            .DataPropertyName = "CreatedDate"
            .Name = "CreatedDate"
        End With

        With Me.MemoQtyRwk
            .DataPropertyName = "MemoQtyRwk"
            .Name = "MemoQtyRwk"
        End With

        With Me.MemoQtyScrap
            .DataPropertyName = "MemoQtyScrap"
            .Name = "MemoQtyScrap"
        End With

        With Me.MemoQtyScrap
            .DataPropertyName = "MemoQtyScrap"
            .Name = "MemoQtyScrap"
        End With

        With Me.DeptRejectedQty
            .DataPropertyName = "DeptRejectedQty"
            .Name = "DeptRejectedQty"
        End With

        With Me.SwMPORevCost
            .DataPropertyName = "SwMPORevCost"
            .Name = "SwMPORevCost"
        End With

        With Me.SwHourRwk
            .DataPropertyName = "SwHourRwk"
            .Name = "SwHourRwk"
        End With

        With Me.MpoQty
            .DataPropertyName = "MpoQty"
            .Name = "MpoQty"
        End With

        With Me.NCRNo
            .DataPropertyName = "NCRNo"
            .Name = "NCRNo"
        End With

        With Me.SNCRNo
            .DataPropertyName = "SNCRNo"
            .Name = "SNCRNo"
        End With

        With Me.SeeMemoNo
            .DataPropertyName = "SeeMemoNo"
            .Name = "SeeMemoNo"
        End With

        With Me.SwDescr
            .DataPropertyName = "SwDescr"
            .Name = "SwDescr"
        End With


        dgSearch.AutoGenerateColumns = False
        dgSearch.DataSource = dsSrc
        dgSearch.DataMember = "tblMemo"

        TakeDescr()
        TakeCostandRwkHours()

    End Sub

    Private Sub dgSearch_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 2 Then
            frmLisiMemoApp.CmbMemo.Enabled = True
            frmLisiMemoApp.CmbMemo.SelectedValue = Me.dgSearch("MemoID", e.RowIndex).Value
            dsSrc.Dispose()
            Me.Close()
        End If

    End Sub

    Private Sub dgSearch_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSearch.DataError
        REM end
    End Sub

    Sub TakeCostandRwkHours()

        Dim TakeCost As String = ""
        Dim TakeRwk As String = ""

        For Each Row As DataGridViewRow In dgSearch.Rows
            TakeCost = ""
            TakeCost = CallClass.TakeFinalSt("cspReturnMEMOMpoRevCost", Nz.Nz(Row.Cells("MemoId").Value))
            If TakeCost = "False" Then
                TakeCost = ""
            End If
            Row.Cells("SwMPORevCost").Value = Val(TakeCost).ToString("C2")

            TakeRwk = ""
            TakeRwk = CallClass.ReturnStrWithParInt("cspReturnMEMORwkHours", Nz.Nz(Row.Cells("MemoId").Value))
            If TakeRwk = "False" Then
                TakeRwk = ""
            End If
            Row.Cells("SwHourRwk").Value = TakeRwk
        Next

    End Sub

    Sub TakeDescr()

        For Each Row As DataGridViewRow In dgSearch.Rows
            Row.Cells("SwDescr").Value = CallClass.ReturnStrWithParInt("cspReturnRequirments", Nz.Nz(Row.Cells("MemoId").Value))
        Next

    End Sub

    Private Sub dgSearch_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSearch.Sorted
        TakeCostandRwkHours()

        TakeDescr()
    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click

        Me.Cursor = Cursors.WaitCursor

        If dgSearch.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim wapp As Excel.Application
            Dim wsheet As Excel.Worksheet
            Dim wbook As Excel.Workbook
            wapp = New Excel.Application

            wapp.Visible = True

            wbook = wapp.Workbooks.Add()
            wsheet = wbook.ActiveSheet

            Dim IX As Integer
            Dim IY As Integer
            Dim IC As Integer

            For IC = 0 To dgSearch.Columns.Count - 1
                wsheet.Cells(1, IC + 1).Value = dgSearch.Columns(IC).HeaderText
            Next

            wsheet.Rows(2).select()

            For IX = 0 To dgSearch.Rows.Count - 1
                For IY = 0 To dgSearch.Columns.Count - 1
                    wsheet.Cells(IX + 2, IY + 1).value = dgSearch(IY, IX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True

            Me.Cursor = Cursors.Default

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

End Class