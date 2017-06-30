Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmEngPartMasterList

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowEng As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet

    Private Sub frmEngPartMasterList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmEngPartMasterList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        CallClass.PopulateDataAdapter("getPartMasterListEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgEng.AutoGenerateColumns = False
        dgEng.DataSource = dsMain
        dgEng.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        'dgEng

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.DocNo
            .DataPropertyName = "DocNo"
            .Name = "DocNo"
        End With

        With Me.SourceName
            .DataPropertyName = "SourceName"
            .Name = "SourceName"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartClasification
            .DataPropertyName = "PartClasification"
            .Name = "PartClasification"
        End With

        With Me.PartNotes
            .DataPropertyName = "PartNotes"
            .Name = "PartNotes"
        End With

        With Me.DateIssue
            .DataPropertyName = "DateIssue"
            .Name = "DateIssue"
        End With

        With Me.DateApproved
            .DataPropertyName = "DateApproved"
            .Name = "DateApproved"
        End With

        With Me.PartStatus
            .DataPropertyName = "PartStatus"
            .Name = "PartStatus"
        End With

        With Me.PartControlType
            .DataPropertyName = "PartControlType"
            .Name = "PartControlType"
        End With
    End Sub

    Sub ClearFields()
        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtPart.Text = ""
        CmbPartClasi.Text = ""
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        ClearFields()

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Dim Par1, Par2, Par3, Par4 As String

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

        If Len(Trim(txtPart.Text)) = 0 Then
            Par3 = ""
        Else
            Par3 = txtPart.Text
        End If

        If Len(Trim(CmbPartClasi.Text)) = 0 Then
            Par4 = ""
        Else
            Par4 = CmbPartClasi.Text
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        CallClass.PopulateDataAdapterSearch4Param("getPartMasterListSelection", Par1, Par2, Par3, Par4).Fill(dsMain, "tblSelect")

        PutDataGrid()

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        Try
            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

            Dim wapp As Microsoft.Office.Interop.Excel.Application
            Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            wapp = New Excel.Application

            wapp.Visible = True
            wbook = wapp.Workbooks.Add()
            wsheet = wbook.ActiveSheet

            Dim iX As Integer
            Dim iY As Integer
            Dim iC As Integer

            For iC = 0 To dgEng.Columns.Count - 2
                wsheet.Cells(1, iC + 1).Value = dgEng.Columns(iC).HeaderText
                'wsheet.Cells(1, iC + 1).font.bold = True
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgEng.Rows.Count - 1
                For iY = 0 To dgEng.Columns.Count - 2
                    wsheet.Cells(iX + 2, iY + 1).value = dgEng(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True
        Catch ex As Exception
        End Try
    End Sub

End Class