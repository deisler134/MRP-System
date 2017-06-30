Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmBackLogAnalyze

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowOrder As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet

    Private Sub frmBackLogAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmBackLogAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        PutCustomer()
        SetCtlForm()

        ClearFields()

        RdCorp.Checked = True
        PlCorp.Visible = True
        PlDgOrder.Visible = False
        RdBacklogActive.Checked = False
        RDBooking.Checked = False

    End Sub

    Sub ClearFields()
        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtPart.Text = ""
        txtOrder.Text = ""
        txtValue.Text = ""

        CmbSelCust.Text = ""

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getOrderSelectionEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgOrder.AutoGenerateColumns = False
        dgOrder.DataSource = dsMain
        dgOrder.DataMember = "tblSelect"

        dgCorp.AutoGenerateColumns = False
        dgCorp.DataSource = dsMain
        dgCorp.DataMember = "tblSelect"

    End Sub

    Sub PutCustomer()

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomerShort").Tables("tblCustomers")
            .DisplayMember = "CustomerShort"
            .ValueMember = "CustomerShort"
        End With

    End Sub

    Sub SetCtlForm()

        'dgOreder

        With Me.year
            .DataPropertyName = "year"
            .Name = "year"
        End With

        With Me.month
            .DataPropertyName = "month"
            .Name = "month"
        End With

        With Me.DelivFermDate
            .DataPropertyName = "DelivFermDate"
            .Name = "DelivFermDate"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.Country
            .DataPropertyName = "Country"
            .Name = "Country"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.OrdItemNo
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.OrdDate
            .DataPropertyName = "OrdDate"
            .Name = "OrdDate"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.OrdValue
            .DataPropertyName = "OrdValue"
            .Name = "OrdValue"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.DelivType
            .DataPropertyName = "DelivType"
            .Name = "DelivType"
        End With

        With Me.SwShipedQty
            .DataPropertyName = "SwShipedQty"
            .Name = "SwShipedQty"
        End With



        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

        With Me.NotesOrder
            .DataPropertyName = "NotesOrder"
            .Name = "NotesOrder"
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
        End With

        With Me.OrdStatus
            .DataPropertyName = "OrdStatus"
            .Name = "OrdStatus"
        End With

        With Me.OrdItemStatus
            .DataPropertyName = "OrdItemStatus"
            .Name = "OrdItemStatus"
        End With

        With Me.DelivStatus
            .DataPropertyName = "DelivStatus"
            .Name = "DelivStatus"
        End With



        'dgCorp

        With Me.DelivFermDatecor
            .DataPropertyName = "DelivFermDate"
            .Name = "DelivFermDate"
        End With

        With Me.CustomerID
            .DataPropertyName = "CustomerID"
            .Name = "CustomerID"
        End With

        With Me.CustomerShortCor
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumberCor
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.OrdDateCor
            .DataPropertyName = "OrdDate"
            .Name = "OrdDate"
        End With

        With Me.PartNumberCor
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartNameCor
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.SwDia
            .DataPropertyName = "SwDia"
            .Name = "SwDia"
        End With

        With Me.SwMatlType
            .DataPropertyName = "SwMatlType"
            .Name = "SwMatlType"
        End With

        With Me.OrdItemNoCor
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.DelivDateCor
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.DelivQtyCor
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.SwShipedQtyCor
            .DataPropertyName = "SwShipedQtyCor"
            .Name = "SwShipedQtyCor"
        End With

        With Me.SwBalance
            .DataPropertyName = "SwBalance"
            .Name = "SwBalance"
        End With

        With Me.SwStPart
            .DataPropertyName = "SwStPart"
            .Name = "SwStPart"
        End With

        With Me.SwWIPQty
            .DataPropertyName = "SwWIPQty"
            .Name = "SwWIPQty"
        End With

        With Me.OrdItemPriceCor
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDeviseCor
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.SwDate
            .DataPropertyName = "SwDate"
            .Name = "SwDate"
        End With

        With Me.OrdPartNoID
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
            .Visible = False
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        Dim Par1, Par2, Par3, Par4, Par5 As String

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

        Par3 = txtPart.Text
        Par4 = CmbSelCust.Text
        Par5 = txtOrder.Text

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        txtValue.Text = ""
        If RDBooking.Checked = True Then
            CallClass.PopulateDataAdapterSearch5Param("getOrderSelectionALLBooking", Par1, Par2, Par3, Par4, Par5).Fill(dsMain, "tblSelect")
            CalculValue()
        End If

        If RdBacklogActive.Checked = True Then
            CallClass.PopulateDataAdapterSearch5Param("getOrderSelectionALLBackLog", Par1, Par2, Par3, Par4, Par5).Fill(dsMain, "tblSelect")
            CalculValue()
        End If

        If RdCorp.Checked = True Then
            CallClass.PopulateDataAdapterSearch5Param("getOrderSelectionALLBookingCorporatif", Par1, Par2, Par3, Par4, Par5).Fill(dsMain, "tblSelect")
            CalculBalance()
            CalculValOrder()
            CalculToatlVal()
            TakeWIPQty()
            PutDiaLength()
        End If

    End Sub

    Sub CalculValue()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgOrder.Rows
            qty = qty + Nz.Nz(Row.Cells("OrdValue").Value)
        Next
        txtValue.Text = qty.ToString("C2")
        txtValue.ReadOnly = True

    End Sub

    Sub CalculBalance()

        For Each Row As DataGridViewRow In dgCorp.Rows
            Row.Cells("SwBalance").Value = Nz.Nz(Row.Cells("DelivQty").Value) - Nz.Nz(Row.Cells("SwShipedQtyCor").Value)
        Next

    End Sub

    Sub CalculValOrder()

        For Each Row As DataGridViewRow In dgCorp.Rows
            Row.Cells("SwValue").Value = Nz.Nz(Row.Cells("SwBalance").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value)
        Next

    End Sub

    Sub CalculToatlVal()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgCorp.Rows
            qty = qty + Nz.Nz(Row.Cells("SwValue").Value)
        Next
        txtValue.Text = qty.ToString("C2")
        txtValue.ReadOnly = True

    End Sub

    Sub TakeWIPQty()

        Dim SwFPQty As String = ""

        For Each Row As DataGridViewRow In dgCorp.Rows
            SwFPQty = ""
            SwFPQty = CallClass.ReturnStrWithParInt("cspReturnPartWIPQty", Nz.Nz(Row.Cells("OrdPartNoID").Value))
            If SwFPQty = "False" Then
                SwFPQty = ""
            End If
            Row.Cells("SwWIPQty").Value = SwFPQty
        Next

        For Each Row As DataGridViewRow In dgCorp.Rows
            SwFPQty = ""
            SwFPQty = CallClass.ReturnStrWithParInt("cspReturnPartFPQty", Nz.Nz(Row.Cells("OrdPartNoID").Value))
            If SwFPQty = "False" Then
                SwFPQty = ""
            End If
            Row.Cells("SwStPart").Value = SwFPQty
        Next

    End Sub

    Sub PutDiaLength()

        Dim txtDescrCode As String = ""
        For Each Row As DataGridViewRow In dgCorp.Rows
            txtDescrCode = ""
            txtDescrCode = Nz.Nz(Row.Cells("PartDescCode").Value)

            '===
            Dim ArrStr As String
            ArrStr = Trim(txtDescrCode)
            Dim I As Integer = 0
            Dim NrOf As Integer = 0
            Dim KeepPos As Integer = 0
            Dim Matl As String = ""

            For I = 0 To Len(ArrStr) - 1
                If ArrStr(I) = CChar("-") Then
                    KeepPos = I
                    NrOf = NrOf + 1
                    If NrOf = 2 Then
                        Row.Cells("swDia").Value = Mid(ArrStr, KeepPos + 2, 3)
                        If Microsoft.VisualBasic.Right(Row.Cells("swDia").Value, 1) = "-" Then
                            Row.Cells("swDia").Value = Microsoft.VisualBasic.Left(Row.Cells("swDia").Value, 2)
                        End If
                    End If
                    If NrOf = 1 Then
                        Matl = ""
                        Matl = Mid(ArrStr, KeepPos + 2, 1)
                        If Matl = "P" Then
                            Matl = Mid(ArrStr, KeepPos + 2, 2)
                        End If
                        Row.Cells("SwMatlType").Value = CallClass.ReturnInfoWithParString("cspReturnMatlFromDescCode", Matl)
                    End If
                End If
            Next
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


        If RDBooking.Checked = True Or RdBacklogActive.Checked = True Then
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

                For iC = 0 To dgCorp.Columns.Count - 1
                    wsheet.Cells(1, iC + 1).Value = dgOrder.Columns(iC).HeaderText
                    'wsheet.Cells(1, iC + 1).font.bold = True
                Next

                wsheet.Rows(2).select()

                For iX = 0 To dgCorp.Rows.Count - 1
                    For iY = 0 To dgCorp.Columns.Count - 1
                        wsheet.Cells(iX + 2, iY + 1).value = dgOrder(iY, iX).Value
                    Next
                Next
                wapp.Visible = True
                wapp.UserControl = True
            Catch ex As Exception
            End Try
        Else
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

                For iC = 0 To dgCorp.Columns.Count - 2
                    wsheet.Cells(1, iC + 1).Value = dgCorp.Columns(iC).HeaderText
                    'wsheet.Cells(1, iC + 1).font.bold = True
                Next

                wsheet.Rows(2).select()

                For iX = 0 To dgCorp.Rows.Count - 1
                    For iY = 0 To dgCorp.Columns.Count - 2
                        wsheet.Cells(iX + 2, iY + 1).value = dgCorp(iY, iX).Value
                    Next
                Next
                wapp.Visible = True
                wapp.UserControl = True
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub dgOrder_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        e.Cancel = True
    End Sub

    Private Sub RdCorp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCorp.CheckedChanged
        If RdCorp.Checked = True Then
            PlCorp.Visible = True
            PlDgOrder.Visible = False
        End If
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub RdBacklogActive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdBacklogActive.CheckedChanged
        If RdBacklogActive.Checked = True Then
            PlCorp.Visible = False
            PlDgOrder.Visible = True
        End If
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub RDBooking_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDBooking.CheckedChanged
        If RDBooking.Checked = True Then
            PlCorp.Visible = False
            PlDgOrder.Visible = True
        End If
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub dgCorp_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCorp.Sorted
        CalculBalance()
        CalculValOrder()
        CalculToatlVal()
        TakeWIPQty()
        PutDiaLength()
    End Sub

End Class