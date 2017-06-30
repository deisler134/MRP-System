Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmLNAAnalyze
    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowProd As Integer = 0

    Dim excelPathName As String
    Dim fName As String

    Private Sub frmLNAAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmLNAAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

        CmdLocation.Enabled = True
        CmdLoad.Enabled = False

    End Sub

    Sub SetupForm()
        GC.Collect()
        'InitialComponents()
        SetCtlForm()
        'ClearFields()
    End Sub

    Sub SetCtlForm()

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.OrdDate
            .DataPropertyName = "OrdDate"
            .Name = "OrdDate"
        End With

        With Me.SwRel
            .DataPropertyName = "SwRel"
            .Name = "SwRel"
        End With

        With Me.SwMPO
            .DataPropertyName = "SwMPO"
            .Name = "SwMPO"
        End With

        With Me.SwDept
            .DataPropertyName = "SwDept"
            .Name = "SwDept"
        End With

        With Me.SwPriority
            .DataPropertyName = "SwPriority"
            .Name = "SwPriority"
        End With

        With Me.SwDelivery
            .DataPropertyName = "SwDelivery"
            .Name = "SwDelivery"
        End With

        With Me.SwInvDate
            .DataPropertyName = "SwInvDate"
            .Name = "SwInvDate"
        End With

    End Sub

    Private Sub CmdLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLocation.Click

        Dim openFileDialog1 As System.Windows.Forms.OpenFileDialog
        openFileDialog1 = New System.Windows.Forms.OpenFileDialog

        With openFileDialog1
            .Title = "Excel Spreadsheet"
            .FileName = ""
            .DefaultExt = ".xls"
            .AddExtension = True
            .Filter = "Excel Worksheets|*.xls; *.xlsx"

            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                excelPathName = (CType(.FileName, String))
                If (excelPathName.Length) <> 0 Then
                    Me.txtFileLocation.Text = excelPathName
                    fName = openFileDialog1.FileName
                Else
                End If
            End If
        End With

        CmdLocation.Enabled = False
        CmdLoad.Enabled = True

    End Sub

    Private Sub CmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLoad.Click
        'test open up excel spreadsheet  

        CmdLoad.Enabled = False

        Dim objExcel As New Excel.Application
        Dim objBook As Excel.Workbook = objExcel.Workbooks.Open(excelPathName)
        Dim objSheet As Excel.Worksheet = objBook.Worksheets(1)
        objExcel.Visible = False

        Dim bolFlag As Boolean = True
        Dim excelRow As Integer = 2
        Dim excelCol As Integer = 1
        Dim DGVRow As Integer = 1
        Dim Partnumber As String

        Try
            Do While bolFlag = True
                If Convert.ToString(objSheet.Cells(excelRow, 1).value) = "" Then
                    bolFlag = False
                    Exit Do
                End If

                With dgProd
                    Partnumber = CType(objSheet.Cells(excelRow, 1).value, String)
                    DGVRow += 1
                    .Rows.Add(Partnumber)
                    excelRow += 1
                    Partnumber = ""
                End With

            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            objBook.Close()
            objExcel.Quit()
        End Try

        PutInfo()

    End Sub

    Sub PutInfo()

        For Each Row As DataGridViewRow In dgProd.Rows
            Row.Cells("PartID").Value = CallClass.ReturnInfoWithParString("cspReturnLNAPartID", Row.Cells("PartNumber").Value)
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            Row.Cells("OrdNumber").Value = CallClass.ReturnInfoWithParString("cspReturnLNAOrderNumber", Row.Cells("PartNumber").Value)
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            'Row.Cells("OrdDate").Value = CallClass.ReturnInfoWithParString("cspReturnLNAOrderDate", Row.Cells("PartNumber").Value)
            Row.Cells("OrdDate").Value = CallClass.ReturnInfoWithParString("cspReturnLNAOrderDate", Row.Cells("OrdNumber").Value)
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            Try
                If Row.Cells("OrdDate").Value <> "False" Then
                    If (CallClass.ReturnStrWith2ParStr("cspReturnLNAOTDRelNo", Row.Cells("PartID").Value, Row.Cells("OrdDate").Value)) = 0 Then
                        Row.Cells("SwRel").Value = "1"
                    Else
                        Row.Cells("SwRel").Value = CallClass.ReturnStrWith2ParStr("cspReturnLNAOTDRelNo", Row.Cells("PartID").Value, Row.Cells("OrdDate").Value)
                    End If
                Else
                    Row.Cells("SwRel").Value = "False"
                End If
            Catch ex As Exception
            End Try
        Next

        For Each Row As DataGridViewRow In dgProd.Rows

            Dim SwPer As Double     'find the latest department as per %

            If Row.Cells("OrdNumber").Value <> "False" Then

                If CallClass.TakeFinalSt("cspReturnLNAMPODeptPer", Row.Cells("OrdNumber").Value) = "False" Then
                    Row.Cells("SwDept").Value = "False"
                Else
                    SwPer = CallClass.TakeFinalSt("cspReturnLNAMPODeptPer", Row.Cells("OrdNumber").Value)
                    Row.Cells("SwDept").Value = CallClass.ReturnStrWith2ParStr("cspReturnLNAMPODept", Row.Cells("OrdNumber").Value, SwPer)
                End If
            Else
                Row.Cells("SwDept").Value = "False"
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("OrdNumber").Value <> "False" Then
                Row.Cells("SwMpo").Value = CallClass.ReturnStrWith2ParStr("cspReturnLNAMPONo", Row.Cells("OrdNumber").Value, Row.Cells("SwDept").Value)
            Else
                Row.Cells("SwMpo").Value = "False"
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("SwRel").Value = "False" Then
                Row.Cells("SwDelivery").Value = "False"
            Else
                If Row.Cells("SwRel").Value = "1" Then
                    Row.Cells("SwDelivery").Value = DateAdd(DateInterval.Day, 210, Row.Cells("OrdDate").Value).ToShortDateString()
                Else
                    Row.Cells("SwDelivery").Value = DateAdd(DateInterval.Day, 140, Row.Cells("OrdDate").Value).ToShortDateString()
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("SwMpo").Value <> "False" Then
                Row.Cells("SwPriority").Value = CallClass.ReturnInfoWithParString("cspReturnLNAMPOPriority", Row.Cells("SwMpo").Value)
            Else
                Row.Cells("SwPriority").Value = "False"
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("SwMpo").Value <> "False" Then
                Row.Cells("SwMPODelivery").Value = CallClass.ReturnInfoWithParString("cspReturnLNAMPODeliveryDate", Row.Cells("SwMpo").Value)
            Else
                Row.Cells("SwMPODelivery").Value = "False"
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Row.Cells("OrdNumber").Value = "False" Then
                Row.Cells("SwInvDate").Value = CallClass.ReturnInfoWithParString("cspReturnLNALatestInvDate", Row.Cells("PartNumber").Value)
            End If
        Next

    End Sub

    Private Sub dgProd_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProd.Sorted

        Me.Refresh()
        PutInfo()

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        If dgProd.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

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

            For iC = 0 To dgProd.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgProd.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 0 To dgProd.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgProd(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True

        Catch ex As Exception
            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
        End Try

    End Sub

End Class