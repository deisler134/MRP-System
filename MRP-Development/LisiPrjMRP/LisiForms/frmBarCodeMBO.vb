Option Strict Off
Option Explicit On
'Option Infer Off        'no effect

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmBarCodeMBO

    Inherits System.Windows.Forms.Form


    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMPO As Integer = 0       'dgMPO row.

    Dim SwQuery As String = ""

    Private dsMain As New DataSet

    Private Sub frmBarCodeMBO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmBarCodeMBO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()

        PutDept()
        PutOperator()
        DisableFields()
        InitialComponents()

        SetCtlForm()

        ClearFields()

    End Sub

    Sub DisableFields()

        CmdMBO.Visible = True
        PnlMBO.Visible = False
        PnlQuery.Visible = False

    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateFromQuery.Text = ""
        txtDateToQuery.Text = ""
        CmbDept.Text = ""
        CmbEmp.Text = ""

    End Sub

    Sub PutDept()

        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
            .DropDownWidth = 350
            .MaxDropDownItems = 60
        End With

    End Sub

    Sub PutOperator()

        With Me.CmbEmp
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetOperator").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DropDownWidth = 350
            .MaxDropDownItems = 60
        End With

    End Sub


    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getPrintBarCodeEmpByPeriodMBO24HrsEmpty").Fill(dsMain, "tblSelect")

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


        With Me.DeptPlant
            .DataPropertyName = "DeptPlant"
            .Name = "DeptPlant"
        End With

        With Me.DeptBarCode
            .DataPropertyName = "DeptBarCode"
            .Name = "DeptBarCode"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.SwQtyProduced
            .DataPropertyName = "SwQtyProduced"
            .Name = "SwQtyProduced"
        End With

        With Me.SwQtyToProduce
            .DataPropertyName = "SwQtyToProduce"
            .Name = "SwQtyToProduce"
        End With

        With Me.OperNo
            .DataPropertyName = "OperNo"
            .Name = "OperNo"
        End With

        With Me.TrOperDescr
            .DataPropertyName = "TrOperDescr"
            .Name = "TrOperDescr"
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.DiffTime
            .DataPropertyName = "DiffTime"
            .Name = "DiffTime"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
        End With

        With Me.RouteRoughFinish
            .DataPropertyName = "RouteRoughFinish"
            .Name = "RouteRoughFinish"
        End With

        With Me.RouteComments
            .DataPropertyName = "RouteComments"
            .Name = "RouteComments"
        End With

        With Me.InfoQtyOkuma
            .DataPropertyName = "InfoQtyOkuma"
            .Name = "InfoQtyOkuma"
        End With

        With Me.InfoQtyRomi
            .DataPropertyName = "InfoQtyRomi"
            .Name = "InfoQtyRomi"
        End With

        With Me.InfoQtyMarked
            .DataPropertyName = "InfoQtyMarked"
            .Name = "InfoQtyMarked"
        End With

        With Me.RouteQtyAcc
            .DataPropertyName = "RouteQtyAcc"
            .Name = "RouteQtyAcc"
        End With

        With Me.RouteQtyInsp
            .DataPropertyName = "RouteQtyInsp"
            .Name = "RouteQtyInsp"
        End With

        With Me.RouteQtyRej
            .DataPropertyName = "RouteQtyRej"
            .Name = "RouteQtyRej"
        End With

        With Me.RouteQtySetup
            .DataPropertyName = "RouteQtySetup"
            .Name = "RouteQtySetup"
        End With

        With Me.SetupCycleOther
            .DataPropertyName = "SetupCycleOther"
            .Name = "SetupCycleOther"
        End With

        With Me.SetupCycleOkuma
            .DataPropertyName = "SetupCycleOkuma"
            .Name = "SetupCycleOkuma"
        End With

        With Me.SetupCycleRomi
            .DataPropertyName = "SetupCycleRomi"
            .Name = "SetupCycleRomi"
        End With

        With Me.RouteStart
            .DataPropertyName = "RouteStart"
            .Name = "RouteStart"
        End With

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
        End With

        With Me.RouteEnd
            .DataPropertyName = "RouteEnd"
            .Name = "RouteEnd"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        If Len(Trim(SwQuery)) = 0 Then
            MsgBox("Nothing to Search.")
            Exit Sub
        End If

        Select Case SwQuery

            Case "MBO"

                Me.Cursor = Cursors.WaitCursor

                Dim StrSearch As String

                If Len(Trim(txtDateFrom.Text)) = 0 Then

                    MsgBox("Date range search option missing !!!")
                    'StrSearch = Now.ToShortDateString

                    Me.Cursor = Cursors.Default

                    Exit Sub
                Else
                    StrSearch = txtDateFrom.Text
                End If

                dsMain.Clear()
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                Me.Refresh()
                CallClass.PopulateDataAdapterAfterSearch("getPrintBarCodeEmpByPeriodMBO24Hrs", StrSearch).Fill(dsMain, "tblSelect")

                Me.Cursor = Cursors.Default


            Case "Other"

                Dim Par1, Par2, Par3, Par4 As String

                Dim SwFrom As Date
                Dim SwTest As Date

                If Len(Trim(txtDateFromQuery.Text)) = 0 Then   'from
                    'Par1 = DateAdd(DateInterval.Day, -365, Date.Now).ToShortDateString()
                    'txtDateFromQuery.Text = Par1
                    MsgBox("Date range FROM - search option missing !!!")
                    Exit Sub
                Else
                    SwFrom = txtDateFromQuery.Text
                    SwTest = DateAdd(DateInterval.Day, -365, Date.Now).ToShortDateString()

                    If SwFrom < SwTest Then
                        MsgBox("Date range FROM is  > 1 year !!!")
                        Exit Sub
                    Else
                        Par1 = txtDateFromQuery.Text
                    End If
                End If

                If Len(Trim(txtDateToQuery.Text)) = 0 Then
                    MsgBox("Date range TO - search option missing !!!")
                    'Par2 = Now.ToShortDateString()
                    'txtDateToQuery.Text = Par2
                    Exit Sub
                Else
                    Par2 = txtDateToQuery.Text
                End If

                Par3 = CmbEmp.Text
                Par4 = CmbDept.Text

                Me.Cursor = Cursors.WaitCursor
                dsMain.Clear()
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                Me.Refresh()

                CallClass.PopulateDataAdapterSearch4Param("getPrintBarCodeEmpByPeriodQuery", Par1, Par2, Par3, Par4).Fill(dsMain, "tblSelect")

                Me.Cursor = Cursors.Default
        End Select

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        PnlMBO.Visible = False
        PnlQuery.Visible = False

        SwQuery = ""

    End Sub

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub


    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        If dgMPO.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

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


    Private Sub CmdMBO_Click(sender As Object, e As EventArgs) Handles CmdMBO.Click
        PnlMBO.Visible = True
        PnlQuery.Visible = False
        ClearFields()

        SwQuery = "MBO"

    End Sub

    Private Sub CmdOther_Click(sender As Object, e As EventArgs) Handles CmdOther.Click
        PnlMBO.Visible = False
        PnlQuery.Visible = True
        ClearFields()

        SwQuery = "Other"
    End Sub
End Class