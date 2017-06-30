Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmProdFirstRelease

    Inherits System.Windows.Forms.Form


    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMPO As Integer = 0       'dgMPO row.

    Private dsMain As New DataSet

    Private Sub frmProdFirstRelease_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmProdFirstRelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

      
    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
    
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getProdFirstReleaseEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.DeptRoot
            .DataPropertyName = "DeptRoot"
            .Name = "DeptRoot"
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.MpoReleasedNo
            .DataPropertyName = "MpoReleasedNo"
            .Name = "MpoReleasedNo"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click


        Me.Cursor = Cursors.WaitCursor


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
        CallClass.PopulateDataAdapterSearch2Param("getProdFirstRelease", Par1, Par2).Fill(dsMain, "tblSelect")
       

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click
        If dgMPO.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

            Me.Cursor = Cursors.WaitCursor

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

            For iC = 0 To dgMPO.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgMPO.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgMPO.Rows.Count - 1
                For iY = 0 To dgMPO.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgMPO(iY, iX).Value
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