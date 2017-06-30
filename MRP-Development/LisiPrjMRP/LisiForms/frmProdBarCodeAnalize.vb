Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Imports Microsoft.Office.Interop

Public Class frmProdBarCodeAnalize

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowOrder As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet

    Dim RowProd As Integer = 0       'dgProd row.

    Private Sub frmProdBarCodeAnalize_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmProdBarCodeAnalize_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()

        GC.Collect()
        InitialComponents()

        PutPart()
        PutDept()

        SetCtlForm()

        ClearFields()

    End Sub

    Sub ClearFields()

        txtDateTo.Text = ""
        CmbPart.Text = ""
       
        'CmbDept.Text = ""

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getProdBarCodeAnalizeEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDept()

        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartmentMPOActive").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutPart()

        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberProduction").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub SetCtlForm()

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.SwRouteStart
            .DataPropertyName = "SwRouteStart"
            .Name = "SwRouteStart"
        End With

        With Me.SwNoDays
            .DataPropertyName = "SwNoDays"
            .Name = "SwNoDays"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.SwSalesValue
            .DataPropertyName = "SwSalesValue"
            .Name = "SwSalesValue"
        End With

        With Me.MPOExpediteValue
            .DataPropertyName = "MPOExpediteValue"
            .Name = "MPOExpediteValue"
        End With

    End Sub

    Sub PutDataGrid()

        dgProd.AutoGenerateColumns = False
        dgProd.DataSource = dsMain
        dgProd.DataMember = "tblMpoMaster"

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        ExecuteSearch()

    End Sub

    Sub ExecuteSearch()

        Me.Cursor = Cursors.WaitCursor

        Dim Par1, Par2, Par3, Par4, Par5, Par6 As String

        Par1 = ""
        Par2 = ""
        Par3 = ""

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par4 = DateAdd(DateInterval.Day, 2500, Date.Now).ToShortDateString()
        Else
            Par4 = txtDateTo.Text
        End If

        Par5 = CmbDept.Text
        Par6 = ""

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        CallClass.PopulateDataAdapterSearch6Param("getProductionAnalyzeSelection", Par1, Par2, Par3, Par4, Par5, Par6).Fill(dsMain, "tblMpoMaster")

        DisplayData()

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub DisplayData()

        Dim TDays As Integer = 0
        Dim DateStart As Date
        Dim DateEnd As Date


        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("QtyActual").Value) = True Then
                Row.Cells("SwSalesValue").Value = Row.Cells("QtyOrder").Value * Row.Cells("OrdItemPrice").Value
            Else
                If Row.Cells("QtyActual").Value < Row.Cells("QtyOrder").Value Then
                    Row.Cells("SwSalesValue").Value = Row.Cells("QtyActual").Value * Row.Cells("OrdItemPrice").Value
                Else
                    Row.Cells("SwSalesValue").Value = Row.Cells("QtyOrder").Value * Row.Cells("OrdItemPrice").Value
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Val(Nz.Nz(Row.Cells("QtyActual").Value)) > 0 Then
                If Val(Row.Cells("QtyActual").Value) < Val(Row.Cells("QtyOrder").Value) Then
                    Row.Cells("QtyActual").Style.BackColor = Color.GreenYellow
                Else
                    Row.Cells("QtyActual").Style.BackColor = Color.White
                End If
            Else
                Row.Cells("QtyActual").Style.BackColor = Color.White
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("SwReceiveDate").Value) = False Then
                If Val(Row.Cells("SwPOQty").Value) - Val(Row.Cells("SwPslipQty").Value) = 0 Then
                    Row.Cells("SuppNotes").Value = "Recv. all Qty from: " + _
                                   Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                                    " on " + Row.Cells("SwReceiveDate").Value
                    Row.Cells("SuppNotes").Style.BackColor = Color.White
                Else
                    Row.Cells("SuppNotes").Value = "Recv. Partial Qty: " + _
                                      Str(Row.Cells("SwPslipQty").Value) + _
                                     " from: " + _
                                     Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                                      " on " + Row.Cells("SwReceiveDate").Value
                    Row.Cells("SuppNotes").Style.BackColor = Color.LemonChiffon
                End If
            Else
                If IsDBNull(Row.Cells("SwPODate").Value) = False Then
                    If IsDBNull(Row.Cells("SwPromisedDate").Value) = False Then
                        Row.Cells("SuppNotes").Value = "Send To: " + _
                            Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                            " on " + Row.Cells("SwPODate").Value + _
                            ".  Promised date: " + Row.Cells("SwPromisedDate").Value
                    Else
                        Row.Cells("SuppNotes").Value = "Send To: " + _
                            Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                            " on " + Row.Cells("SwPODate").Value
                    End If
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("SwRouteStart").Value) = False Then
                If Len(Trim(Row.Cells("SwRouteStart").Value)) > 0 Then
                    DateStart = Row.Cells("SwRouteStart").Value
                    DateEnd = Date.Now.ToShortDateString
                    TDays = DateDiff(DateInterval.Day, DateStart, DateEnd)
                    Row.Cells("SwNoDays").Value = TDays.ToString
                End If
            End If
        Next

    End Sub

   

    Private Sub dgProd_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgProd.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0 To 16
                e.Cancel = True

            Case 17 To 22
                'If RoleInspData(wkDeptCode) = False Then
                '    e.Cancel = True
                'Else
                '    e.Cancel = False
                '    If e.ColumnIndex = 20 Then
                '        If IsDBNull(dgProd("WKMpoFAI", e.RowIndex).Value) = True And IsDBNull(dgProd("WKMpoDVI", e.RowIndex).Value) = True Then
                '            MsgBox("Nothing to accept.")
                '            e.Cancel = True
                '        End If
                '    End If

                '    If e.ColumnIndex = 21 Then
                '        If IsDBNull(dgProd("WKMpoDVI", e.RowIndex).Value) = True Or Nz.Nz(dgProd("WKMpoDVI", e.RowIndex).Value) = 0 Then
                '            MsgBox("Action Denied.")
                '            e.Cancel = True
                '        End If
                '    End If
                'End If

            Case 23 To 24
                e.Cancel = True
            Case 27 To 40
                e.Cancel = True
            Case 25
                If IsDBNull(dgProd("MemoNo", e.RowIndex).Value) = True Then
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgProd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProd.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If

      

    End Sub

    Private Sub dgProd_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProd.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If


        Select Case e.ColumnIndex

           
        End Select
    End Sub

    Private Sub dgProd_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProd.DataError
        REM end
    End Sub


    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        Me.Cursor = Cursors.WaitCursor

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

            For iC = 1 To 14 - 1
                wsheet.Cells(1, iC).Value = dgProd.Columns(iC).HeaderText
            Next
            For iC = 24 To 25 - 1
                wsheet.Cells(1, iC - 10).Value = dgProd.Columns(iC).HeaderText
            Next

            For iC = 28 To 29 - 1
                wsheet.Cells(1, iC - 13).Value = dgProd.Columns(iC).HeaderText
            Next

            For iC = 30 To 31 - 1
                wsheet.Cells(1, iC - 14).Value = dgProd.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 1 To 14 - 1
                    wsheet.Cells(iX + 2, iY).value = dgProd(iY, iX).Value
                Next
            Next
            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 24 To 25 - 1
                    wsheet.Cells(iX + 2, iY - 10).value = dgProd(iY, iX).Value
                Next
            Next
            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 28 To 29 - 1
                    wsheet.Cells(iX + 2, iY - 13).value = dgProd(iY, iX).Value
                Next
            Next
            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 30 To 31 - 1
                    wsheet.Cells(iX + 2, iY - 14).value = dgProd(iY, iX).Value
                Next
            Next


            wapp.Visible = True
            wapp.UserControl = True

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

End Class