Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmPOQuery

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmPOQuery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPOQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1650 And Height > 900 Then
            Me.Width = 1650
            Me.Height = 900
        Else
            If Width < 1650 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        GC.Collect()

        SetupForm()

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

        CallClass.PopulateDataAdapter("getPOQueryEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        Call PutBuyer()

        Call PutSupplier()

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgPO.AutoGenerateColumns = False
        dgPO.DataSource = dsMain
        dgPO.DataMember = "tblSelect"

        dgPO.ReadOnly = True

    End Sub

    Sub PutSupplier()

        With Me.CmbSupplier
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutBuyer()

        With Me.CmbBuyer
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetPOBuyers").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedIndex = -1
        End With

    End Sub
    Sub SetCtlForm()

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.POType
            .DataPropertyName = "POType"
            .Name = "POType"
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With

        With Me.PONotes
            .DataPropertyName = "PONotes"
            .Name = "PONotes"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.PORMSPrice
            .DataPropertyName = "PORMSPrice"
            .Name = "PORMSPrice"
        End With

        With Me.POUM
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.DolarSign
            .DataPropertyName = "DolarSign"
            .Name = "DolarSign"
        End With

        With Me.PONotesItem
            .DataPropertyName = "PONotesItem"
            .Name = "PONotesItem"
        End With

        With Me.CompteDescr
            .DataPropertyName = "CompteDescr"
            .Name = "CompteDescr"
        End With

        With Me.POStatus
            .DataPropertyName = "POStatus"
            .Name = "POStatus"
        End With

        With Me.MasterPODueDate
            .DataPropertyName = "MasterPODueDate"
            .Name = "MasterPODueDate"
        End With

        With Me.Rate
            .DataPropertyName = "Rate"
            .Name = "Rate"
        End With

    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        CmbSupplier.SelectedIndex = -1
        CmbBuyer.SelectedIndex = -1

    End Sub

    Private Sub CmdSearch_Click(sender As Object, e As EventArgs) Handles CmdSearch.Click

        Dim Par1, Par2, Par3, Par4 As String

        If Len(Trim(txtDateFrom.Text)) = 0 Then
            Par1 = "01/01/2005"
            txtDateFrom.Text = Par1
        Else
            Par1 = txtDateFrom.Text
        End If

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par2 = DateAdd(DateInterval.Day, 1000, Date.Now).ToShortDateString()
            txtDateTo.Text = Par2
        Else
            Par2 = txtDateTo.Text
        End If

        If Trim(Len(CmbSupplier.Text)) = 0 Then
            Par3 = ""
        Else
            Par3 = CmbSupplier.Text
        End If

        If Trim(Len(CmbBuyer.Text)) = 0 Then
            Par4 = ""
        Else
            Par4 = CmbBuyer.Text
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()


        Me.Cursor = Cursors.WaitCursor

        CallClass.PopulateDataAdapterSearch4Param("getPOQuery", Par1, Par2, Par3, Par4).Fill(dsMain, "tblSelect")

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click

        If dgPO.Rows.Count <= 0 Then
            MsgBox("Nothing to Export in Excel.")
            Exit Sub
        End If

        Try
            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

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

            Me.Cursor = Cursors.WaitCursor

            For iC = 0 To dgPO.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgPO.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgPO.Rows.Count - 1
                For iY = 0 To dgPO.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgPO(iY, iX).Value
                Next
            Next

            Me.Cursor = Cursors.Default

            wapp.Visible = True
            wapp.UserControl = True
        Catch ex As Exception
        End Try


    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Private Sub dgPO_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgPO.DataError
        REM end
    End Sub




End Class