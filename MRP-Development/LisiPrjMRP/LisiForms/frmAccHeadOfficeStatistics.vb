Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmAccHeadOfficeStatistics

    Inherits System.Windows.Forms.Form


    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMPO As Integer = 0       'dgMPO row.

    Private dsMain As New DataSet


    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height


    Private Sub frmAccHeadOfficeStatistics_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmAccHeadOfficeStatistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1680 And Height > 950 Then
            Me.Width = 1680
            Me.Height = 950
        Else
            If Width < 1600 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

        ChkSales.Checked = True
        ChkBooking.Checked = False
        ChkSalesYTD.Checked = False

    End Sub

    Sub ClearFields()

        ChkSales.Checked = True
        ChkBooking.Checked = False
        ChkSalesYTD.Checked = False

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtValueOrig.Text = ""
        txtValueCad.Text = ""

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccHeadOfficeStatisticsEmpty").Fill(dsMain, "tblSelect")

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



        With Me.PslipORDRefNo
            .DataPropertyName = "PslipORDRefNo"
            .Name = "PslipORDRefNo"
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.SwSalesBooking
            .DataPropertyName = "SwSalesBooking"
            .Name = "SwSalesBooking"
        End With

        With Me.SwCategActualBudget
            .DataPropertyName = "SwCategActualBudget"
            .Name = "SwCategActualBudget"
        End With

        With Me.SwProd
            .DataPropertyName = "SwProd"
            .Name = "SwProd"
        End With

        With Me.SwLegal
            .DataPropertyName = "SwLegal"
            .Name = "SwLegal"
        End With

        With Me.SwOrderType
            .DataPropertyName = "SwOrderType"
            .Name = "SwOrderType"
        End With

        With Me.SwTrans
            .DataPropertyName = "SwTrans"
            .Name = "SwTrans"
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.PslipItem
            .DataPropertyName = "PslipItem"
            .Name = "PslipItem"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.M3PartArticle
            .DataPropertyName = "SwPartArticle"
            .Name = "SwPartArticle"
        End With

        With Me.InvCodeM3
            .DataPropertyName = "InvCodeM3"
            .Name = "InvCodeM3"
        End With

        With Me.PslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

        With Me.InvMARKET
            .DataPropertyName = "InvMARKET"
            .Name = "InvMARKET"
        End With

        With Me.SwTrAmountOrig
            .DataPropertyName = "SwTrAmountOrig"
            .Name = "SwTrAmountOrig"
        End With

        With Me.InvDevise
            .DataPropertyName = "InvDevise"
            .Name = "InvDevise"
        End With

        With Me.SwLocalAmount
            .DataPropertyName = "SwLocalAmount"
            .Name = "SwLocalAmount"
        End With

        With Me.SwLocalDevise
            .DataPropertyName = "SwLocalDevise"
            .Name = "SwLocalDevise"
        End With

        With Me.InvShortName
            .DataPropertyName = "InvShortName"
            .Name = "InvShortName"
        End With

        With Me.PslipAccpacCode
            .DataPropertyName = "PslipAccpacCode"
            .Name = "PslipAccpacCode"
        End With

        With Me.ProductDescr
            .DataPropertyName = "ProductDescr"
            .Name = "ProductDescr"
        End With

        With Me.InvPrice
            .DataPropertyName = "InvPrice"
            .Name = "InvPrice"
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

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
        End With

        With Me.InvMARKETLAC
            .DataPropertyName = "InvMARKETLAC"
            .Name = "InvMARKETLAC"
        End With

        With Me.SWLNAType
            .DataPropertyName = "SWLNAType"
            .Name = "SWLNAType"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.OTD_Days
            .DataPropertyName = "OTD_Days"
            .Name = "OTD_Days"
            .Visible = False
        End With

        With Me.OTD_True
            .DataPropertyName = "OTD_True"
            .Name = "OTD_True"
        End With

        With Me.SwStDate
            .DataPropertyName = "SwStDate"
            .Name = "SwStDate"
        End With

        With Me.StPrice
            .DataPropertyName = "StPrice"
            .Name = "StPrice"
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

        If ChkSales.Checked = True Then

            Me.Refresh()
            CallClass.PopulateDataAdapterSearch2Param("getAccHeadOfficeStatisticsSales", Par1, Par2).Fill(dsMain, "tblSelect")
            dgMPO.Columns(8).HeaderText = "INVOICE_AR#"
            dgMPO.Columns(9).HeaderText = "INVOICE_LINE_NO"

            PutInfoSales()
            GoTo NextOper
        End If

        If ChkSalesYTD.Checked = True Then

            Me.Refresh()
            Par1 = "01/01/" + Str(Year(txtDateFrom.Text))
            CallClass.PopulateDataAdapterSearch2Param("getAccHeadOfficeStatisticsSales", Par1, Par2).Fill(dsMain, "tblSelect")
            dgMPO.Columns(8).HeaderText = "INVOICE_AR#"
            dgMPO.Columns(9).HeaderText = "INVOICE_LINE_NO"

            PutInfoSales()
            GoTo NextOper
        End If

        If ChkBooking.Checked = True Then

            Me.Refresh()
            Par1 = "01/01/" + Str(Year(txtDateFrom.Text))
            CallClass.PopulateDataAdapterSearch2Param("getAccHeadOfficeStatisticsBooking", Par1, Par2).Fill(dsMain, "tblSelect")
            dgMPO.Columns(8).HeaderText = "ORDER_NO"
            dgMPO.Columns(9).HeaderText = "ORDER_LINE_NO"

            PutInfoBooking()
            GoTo NextOper
        End If

NextOper:
        CalculToatlVal()

        Me.Cursor = Cursors.Default

    End Sub

    Sub PutInfoSales()

        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("SwSalesBooking").Value = "S"
            Row.Cells("SwCategActualBudget").Value = "A"
            Row.Cells("SwProd").Value = "LAC"
            Row.Cells("SwLegal").Value = "LAC"
            Row.Cells("SwOrderType").Value = "STD"
            If Microsoft.VisualBasic.Left(Trim(Row.Cells("PslipAccpacCode").Value), 2) = "03" Then
                Row.Cells("SwTrans").Value = "IISO"
            Else
                Row.Cells("SwTrans").Value = "EXTI"
            End If

            Row.Cells("SwTrAmountOrig").Value = (Nz.Nz(Row.Cells("InvValCh1").Value) + Nz.Nz(Row.Cells("InvValCh2").Value) + Nz.Nz(Row.Cells("InvValCh3").Value)) + _
                                        Nz.Nz(Row.Cells("InvPrice").Value) * Nz.Nz(Row.Cells("PslipQty").Value)


            Row.Cells("SwLocalAmount").Value = ((Nz.Nz(Row.Cells("InvPrice").Value) * Nz.Nz(Row.Cells("PslipQty").Value)) + _
                                        (Nz.Nz(Row.Cells("InvValCh1").Value) + Nz.Nz(Row.Cells("InvValCh2").Value) + Nz.Nz(Row.Cells("InvValCh3").Value))) * Row.Cells("SwRateMonth").Value

            Row.Cells("SwLocalDevise").Value = "CAD"

            Row.Cells("OTD_Days").Value = DateDiff(DateInterval.Day, Row.Cells("DelivDate").Value, Row.Cells("InvDate").Value)
            If Row.Cells("OTD_Days").Value <= 0 Then
                Row.Cells("OTD_true").Value = True
            Else
                Row.Cells("OTD_true").Value = False
            End If
        Next

    End Sub

    Sub PutInfoBooking()

        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("SwSalesBooking").Value = "B"
            Row.Cells("SwCategActualBudget").Value = "A"
            Row.Cells("SwProd").Value = "LAC"
            Row.Cells("SwLegal").Value = "LAC"
            Row.Cells("SwOrderType").Value = "STD"

            If Nz.Nz(Row.Cells("PslipAccpacCode").Value) = "03" Then
                Row.Cells("SwTrans").Value = "IISO"
            Else
                Row.Cells("SwTrans").Value = "EXTI"
            End If

            Row.Cells("SwTrAmountOrig").Value = Nz.Nz(Row.Cells("InvPrice").Value) * Nz.Nz(Row.Cells("PslipQty").Value)

            Row.Cells("SwLocalAmount").Value = Nz.Nz(Row.Cells("InvPrice").Value) * Nz.Nz(Row.Cells("PslipQty").Value) * Nz.Nz(Row.Cells("SwRateMonth").Value)

            Row.Cells("SwLocalDevise").Value = "CAD"

        Next
    End Sub

    Sub CalculToatlVal()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMPO.Rows
            qty = qty + Nz.Nz(Row.Cells("SwTrAmountOrig").Value)
        Next
        txtValueOrig.Text = qty.ToString("C2")
        txtValueOrig.ReadOnly = True

        qty = 0.0
        For Each Row As DataGridViewRow In dgMPO.Rows
            qty = qty + Nz.Nz(Row.Cells("SwLocalAmount").Value)
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

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub

    Private Sub dgMPO_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMPO.Sorted
        If ChkSales.Checked = True Then
            Me.Refresh()
            PutInfoSales()
        Else
            If ChkSalesYTD.Checked = True Then
                Me.Refresh()
                PutInfoSales()
            Else
                Me.Refresh()
                PutInfoBooking()
            End If
        End If

        CalculToatlVal()
    End Sub

    Private Sub ChkBooking_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBooking.CheckedChanged
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
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





        'Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

        'Using con As New SqlConnection(constr)

        '    Using cmd As New SqlCommand("SELECT * FROM Customers")
        '        Using sda As New SqlDataAdapter()
        '            cmd.Connection = con
        '            sda.SelectCommand = cmd

        '            Using dt As New DataTable()

        '                sda.Fill(dt)



        '                'Build the CSV file data as a Comma separated string.



        'Dim dt As New DataTable()
        'dt = TryCast(dgMPO.DataSource, DataTable)


        'Dim csv As String = String.Empty

        'For Each column As DataColumn In dt.Columns
        '    'Add the Header row for CSV file.
        '    csv += column.ColumnName + ","c
        'Next
        ''Add new line.
        'csv += vbCr & vbLf

        'For Each row As DataRow In dt.Rows
        '    For Each column As DataColumn In dt.Columns
        '        'Add the Data rows.
        '        csv += row(column.ColumnName).ToString().Replace(",", ";") + ","c
        '    Next
        '    'Add new line.
        '    csv += vbCr & vbLf
        'Next
        'Download the CSV file.

        'Response.Clear()

        'Response.Buffer = True

        'Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv")

        'Response.Charset = ""

        'Response.ContentType = "application/text"

        'Response.Output.Write(csv)

        'Response.Flush()

        'Response.End()

        '            End Using

        '        End Using

        '    End Using

        'End Using




    End Sub

    Private Sub ChkSalesYTD_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSalesYTD.CheckedChanged
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub frmAccHeadOfficeStatistics_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Dim RW As Double = (Me.Width - CW) / CW ' Ratio change of width
        'Dim RH As Double = (Me.Height - CH) / CH ' Ratio change of height

        'For Each Ctrl As Control In Controls
        '    Ctrl.Width += CInt(Ctrl.Width * RW)
        '    Ctrl.Height += CInt(Ctrl.Height * RH)
        '    Ctrl.Left += CInt(Ctrl.Left * RW)
        '    Ctrl.Top += CInt(Ctrl.Top * RH)
        'Next

        'CW = Me.Width
        'CH = Me.Height

        'Dim Screen As System.Drawing.Rectangle
        'Screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea()
        'Me.Top = (Screen.Height \ 2) - (Me.Height \ 2)
        'Me.Left = (Screen.Width \ 2) - (Me.Width \ 2)

    End Sub

End Class