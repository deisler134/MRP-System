Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmAccHeadOfficeLACQueries

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMPO As Integer = 0       'dgMPO row.

    Private dsMain As New DataSet

    Private Sub frmAccHeadOfficeLACQueries_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmAccHeadOfficeLACQueries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

        ChkSales.Checked = True

        txtDateFrom.Focus()

    End Sub

    Sub ClearFields()

        ChkSales.Checked = True

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtValueCad.Text = ""

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccHeadOfficeLACQueriesEmpty").Fill(dsMain, "tblSelect")

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
        With Me.Year
            .DataPropertyName = "Year"
            .Name = "Year"
        End With

        With Me.Month
            .DataPropertyName = "Month"
            .Name = "Month"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.PslipType
            .DataPropertyName = "PslipType"
            .Name = "PslipType"
        End With

        With Me.PslipCRDNo
            .DataPropertyName = "PslipCRDNo"
            .Name = "PslipCRDNo"
        End With

        With Me.InvShortName
            .DataPropertyName = "InvShortName"
            .Name = "InvShortName"
        End With

        With Me.ShipShortName
            .DataPropertyName = "ShipShortName"
            .Name = "ShipShortName"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.ProductDescr
            .DataPropertyName = "ProductDescr"
            .Name = "ProductDescr"
        End With

        With Me.PslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

        With Me.InvPrice
            .DataPropertyName = "InvPrice"
            .Name = "InvPrice"
        End With

        With Me.InvDevise
            .DataPropertyName = "InvDevise"
            .Name = "InvDevise"
        End With

        With Me.SwValueCAD
            .DataPropertyName = "SwValueCAD"
            .Name = "SwValueCAD"
        End With

        With Me.SwMPOWeight
            .DataPropertyName = "SwMPOWeight"
            .Name = "SwMPOWeight"
        End With

        With Me.CalculRM
            .DataPropertyName = "CalculRM"
            .Name = "CalculRM"
        End With

        With Me.MpoRMCostCDN
            .DataPropertyName = "MpoRMCostCDN"
            .Name = "MpoRMCostCDN"
            .Visible = False
        End With

        With Me.SwMachCost
            .DataPropertyName = "SwMachCost"
            .Name = "SwMachCost"
        End With

        With Me.MPOProcessingCost
            .DataPropertyName = "MPOProcessingCost"
            .Name = "MPOProcessingCost"
        End With

        With Me.WMpoCommission
            .DataPropertyName = "WMpoCommission"
            .Name = "WMpoCommission"
        End With

        With Me.Wbacb31G
            .DataPropertyName = "Wbacb31G"
            .Name = "Wbacb31G"
        End With

        With Me.Whst
            .DataPropertyName = "Whst"
            .Name = "Whst"
        End With

        With Me.InvTextCh1
            .DataPropertyName = "InvTextCh1"
            .Name = "InvTextCh1"
        End With

        With Me.InvTextCh2
            .DataPropertyName = "InvTextCh2"
            .Name = "InvTextCh2"
        End With

        With Me.InvTextCh3
            .DataPropertyName = "InvTextCh3"
            .Name = "InvTextCh3"
        End With

        With Me.InvValCh1
            .DataPropertyName = "InvValCh1"
            .Name = "InvValCh1"
        End With

        With Me.InvValCh2
            .DataPropertyName = "InvValCh2"
            .Name = "InvValCh2"
        End With

        With Me.InvValCh3
            .DataPropertyName = "InvValCh3"
            .Name = "InvValCh3"
        End With

        'With Me.InvMARKET
        '    .DataPropertyName = "InvMARKET"
        '    .Name = "InvMARKET"
        'End With

        With Me.InvMARKETLAC
            .DataPropertyName = "InvMARKETLAC"
            .Name = "InvMARKETLAC"
        End With

        With Me.OrdSalesRepPer
            .DataPropertyName = "OrdSalesRepPer"
            .Name = "OrdSalesRepPer"
        End With

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
        End With

        With Me.SwTrans
            .DataPropertyName = "SwTrans"
            .Name = "SwTrans"
        End With

        With Me.DocNo
            .DataPropertyName = "DocNo"
            .Name = "DocNo"
        End With

        With Me.SourceName
            .DataPropertyName = "SourceName"
            .Name = "SourceName"
        End With

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.PslipAccpacCode
            .DataPropertyName = "PslipAccpacCode"
            .Name = "PslipAccpacCode"
            .Visible = False
        End With


    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        ExecuteSearch()

    End Sub

    Sub ExecuteSearch()

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

        If ChkSales.Checked = True Then

            Me.Refresh()
            CallClass.PopulateDataAdapterSearch2Param("getAccHeadOfficeLACQueries", Par1, Par2).Fill(dsMain, "tblSelect")

            PutInfoSales()

        End If

        CalculToatlVal()

    End Sub

    Sub PutInfoSales()

        For Each Row As DataGridViewRow In dgMPO.Rows

            Row.Cells("SwValueCAD").Value = (Nz.Nz(Row.Cells("InvPrice").Value) * Nz.Nz(Row.Cells("PslipQty").Value) + _
                                        (Nz.Nz(Row.Cells("InvValCh1").Value) + Nz.Nz(Row.Cells("InvValCh2").Value) + Nz.Nz(Row.Cells("InvValCh3").Value))) * Row.Cells("SwRateMonth").Value

            If Row.Cells("SwMPOWeight").Value = 0 Then
                Row.Cells("CalculRM").Value = Nz.Nz(Row.Cells("MpoRMCostCDN").Value) + (1 * Nz.Nz(Row.Cells("SwRateMonth").Value))
            Else
                Row.Cells("CalculRM").Value = Row.Cells("MpoRMCostCDN").Value
            End If

            Row.Cells("UnitCost").Value = Nz.Nz(Row.Cells("CalculRM").Value) + Nz.Nz(Row.Cells("SwMachCost").Value) + Nz.Nz(Row.Cells("MPOProcessingCost").Value)

            Row.Cells("WMpoRM").Value = Nz.Nz(Row.Cells("CalculRM").Value) * Nz.Nz(Row.Cells("PslipQty").Value)
            Row.Cells("WMpoMach").Value = Nz.Nz(Row.Cells("SwMachCost").Value) * Nz.Nz(Row.Cells("PslipQty").Value)
            Row.Cells("WMpoProc").Value = Nz.Nz(Row.Cells("MPOProcessingCost").Value) * Nz.Nz(Row.Cells("PslipQty").Value)
            Row.Cells("WTotalMpo").Value = Row.Cells("WMpoRM").Value + Row.Cells("WMpoMach").Value + Row.Cells("WMpoProc").Value

            Row.Cells("WMpoProfit").Value = Nz.Nz(Row.Cells("SwValueCAD").Value) - Nz.Nz(Row.Cells("WTotalMpo").Value)

            If Row.Cells("WMpoProfit").Value < 0 Then
                If Row.Cells("WMpoProfit").Value < -10000 Then
                    Row.Cells("WMpoProfit").Style.BackColor = Color.Red
                Else
                    Row.Cells("WMpoProfit").Style.BackColor = Color.MistyRose
                End If
            Else
                Row.Cells("WMpoProfit").Style.BackColor = Color.White
            End If

            If Nz.Nz(Row.Cells("SwValueCAD").Value) > 0 Then
                Row.Cells("WMpoper").Value = 100 - (Nz.Nz(Row.Cells("WTotalMpo").Value) / Nz.Nz(Row.Cells("SwValueCAD").Value) * 100)
            End If

            Row.Cells("WMPOCommission").Value = Nz.Nz(Row.Cells("OrdSalesRepPer").Value) * Nz.Nz(Row.Cells("SwValueCAD").Value) / 100
            If Nz.Nz(Row.Cells("WMPOCommission").Value) = 0 Then
                Row.Cells("WMPOCommission").Value = DBNull.Value
                Row.Cells("OrdSalesRepPer").Value = DBNull.Value
            End If

            If Microsoft.VisualBasic.Left(Row.Cells("PartNumber").Value, 7) = "BACB31G" Then
                Row.Cells("Wbacb31g").Value = Row.Cells("SwValueCAD").Value * 5 / 100
            End If
            If Microsoft.VisualBasic.Left(Row.Cells("PartNumber").Value, 3) = "HST" Then
                Row.Cells("Whst").Value = Row.Cells("SwValueCAD").Value * 0.5 / 100
            End If

            If Microsoft.VisualBasic.Left(Trim(Row.Cells("PslipAccpacCode").Value), 2) = "03" Then
                Row.Cells("SwTrans").Value = "IISO"
            Else
                Row.Cells("SwTrans").Value = "EXTI"
            End If


        Next

    End Sub

    Sub CalculToatlVal()

        Dim qty As Double = 0.0

        qty = 0.0
        For Each Row As DataGridViewRow In dgMPO.Rows
            qty = qty + Nz.Nz(Row.Cells("SwValueCAD").Value)
        Next
        txtValueCad.Text = qty.ToString("C2")
        txtValueCad.ReadOnly = True

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Private Sub dgMPO_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMPO.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMPO = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0 To 23
                e.Cancel = True
            Case 25 To 38
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgMPO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMPO.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMPO = e.RowIndex
        End If

        dgMPO.Refresh()

        dgMPO.Rows(RowMPO).Selected = True

        Select Case e.ColumnIndex
            Case 24         'Edit

                frmAccHeadOfficeLACQueriesUpdateMachCost.txtMPOID.Text = dgMPO("MpoID", RowMPO).Value

                frmAccHeadOfficeLACQueriesUpdateMachCost.ShowDialog()
                frmAccHeadOfficeLACQueriesUpdateMachCost.Dispose()

                ExecuteSearch()

                dgMPO.Refresh()
                dgMPO.CurrentCell = dgMPO.Rows(RowMPO).Cells(20)

                'dgMPO.CurrentCell = dgMPO("MpoNo", RowMPO).Value
                dgMPO.Rows(RowMPO).Selected = True

        End Select

    End Sub

    Private Sub dgMPO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMPO.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMPO = e.RowIndex
        End If
    End Sub

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub

    Private Sub dgMPO_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMPO.Sorted
        If ChkSales.Checked = True Then
            Me.Refresh()
        End If

        PutInfoSales()
        CalculToatlVal()
    End Sub

    Private Sub ChkSales_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSales.CheckedChanged
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click


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

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

End Class