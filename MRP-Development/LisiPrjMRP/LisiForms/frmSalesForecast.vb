Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSalesForecast

    Inherits System.Windows.Forms.Form

    'Private WithEvents DataGridView1 As New DataGridView
    'Private WithEvents DataGridView2 As New DataGridView

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim dsMain As New DataSet

    Dim RowMpo As Integer = 0
    Dim RowSales As Integer = 0
    Dim RowLab As Integer = 0

    Private Sub frmSalesForecast_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmSalesForecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ChkLab.Checked = False
        PlSales.Visible = True
        PlLab.Visible = False

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        PutDataInfo()
        SetCtrl()
        BindComponents()

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "SalesTable.CustMpoPart"

        If ChkLab.Checked = False Then
            dgSales.AutoGenerateColumns = False
            dgSales.DataSource = dsMain
            dgSales.DataMember = "SalesTable"
        Else
            DgLab.AutoGenerateColumns = False
            DgLab.DataSource = dsMain
            DgLab.DataMember = "SalesTable"
        End If

        dgDetails.AutoGenerateColumns = False
        dgDetails.DataSource = dsMain
        dgDetails.DataMember = "SalesTable.CustMpoPart.ProdPo"

        dgInsp.AutoGenerateColumns = False
        dgInsp.DataSource = dsMain
        dgInsp.DataMember = "SalesTable.CustMpoPart.ProdPo.DetailRecv"

        CalculGrid()
        CalculValue()
        dgSales.Focus()

        PutSalesFr()

        If RoleSalesFR(wkDeptCode) = True Then
            txtMpoNotes.ReadOnly = False
            txtTechNotes.ReadOnly = False
            txtSalesNotes.ReadOnly = False
        Else
            txtMpoNotes.ReadOnly = True
            txtTechNotes.ReadOnly = True
            txtSalesNotes.ReadOnly = True
        End If

    End Sub

    Sub PutDataInfo()

        dsMain.Clear()
        dsMain.Relations.Clear()

        If ChkLab.Checked = False Then
            CallClass.PopulateDataAdapterAfterSearch("getSalesForecast", cmbDate.Text).Fill(dsMain, "SalesTable")
        Else
            CallClass.PopulateDataAdapterAfterSearch("getSalesForecastLabInspection", cmbDate.Text).Fill(dsMain, "SalesTable")
        End If

        CallClass.PopulateDataAdapter("getSalesForecastMpo").Fill(dsMain, "MpoTable")

        CallClass.PopulateDataAdapter("gettblPoMasterSalesForecast").Fill(dsMain, "tblPODetails")
        CallClass.PopulateDataAdapter("getTblPoDetailsSalesForecast").Fill(dsMain, "tblPOReceiving")

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("CustMpoPart", _
                .Tables("SalesTable").Columns("OrdPartNoID"), _
                .Tables("MpoTable").Columns("MpoPartID"), True)
        End With

        With dsMain
            .Relations.Add("ProdPo", _
                .Tables("MpoTable").Columns("MpoId"), _
                .Tables("tblPODetails").Columns("POMpoID"), True)
        End With

        With dsMain
            .Relations.Add("DetailRecv", _
            .Tables("tblPODetails").Columns("PODetailID"), _
            .Tables("tblPOReceiving").Columns("PODetailID"), True)
        End With

    End Sub

    Private Sub SetCtrl()

        With Me.OrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.OrdPartNoID
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
            .Visible = False
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.OrdItemNo
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.DelivShippedQty
            .DataPropertyName = "DelivShippedQty"
            .Name = "DelivShippedQty"
        End With

        With Me.DelivQtyToShip
            .DataPropertyName = "DelivQtyToShip"
            .Name = "DelivQtyToShip"
        End With

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
            .Visible = False
        End With

        With Me.FrecastValue
            .DataPropertyName = "FrecastValue"
            .Name = "FrecastValue"
        End With

        With Me.DelivSwForecast
            .DataPropertyName = "DelivSwForecast"
            .Name = "DelivSwForecast"
        End With

        With Me.DelivCheckForecast
            .DataPropertyName = "DelivCheckForecast"
            .Name = "DelivCheckForecast"
        End With

        With Me.DelivCheckProd
            .DataPropertyName = "DelivCheckProd"
            .Name = "DelivCheckProd"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
            .Visible = False
        End With

        'dgLab

        With Me.LabMpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.LabDeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.LabOrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.LabDelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.LabPartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.LabOrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.LabOrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.LabDelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.LabDelivShippedQty
            .DataPropertyName = "DelivShippedQty"
            .Name = "DelivShippedQty"
        End With

        With Me.LabDelivQtyToShip
            .DataPropertyName = "DelivQtyToShip"
            .Name = "DelivQtyToShip"
        End With

        With Me.LAbSwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
            .Visible = False
        End With

        With Me.labFrecastValue
            .DataPropertyName = "FrecastValue"
            .Name = "FrecastValue"
        End With

        With Me.LabDelivSwForecast
            .DataPropertyName = "DelivSwForecast"
            .Name = "DelivSwForecast"
        End With

        With Me.LabDelivCheckForecast
            .DataPropertyName = "DelivCheckForecast"
            .Name = "DelivCheckForecast"
        End With

        With Me.LabDelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
            .Visible = False
        End With

        With Me.LabCustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.LabOrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.LabOrdPartNoID
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
            .Visible = False
        End With

        'dgMpo Info

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.MpoPartID
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
            .Visible = False
        End With

        With Me.DeptSalesFr
            .DataPropertyName = "DeptSalesFr"
            .Name = "DeptSalesFr"
            .Visible = False
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
            .Visible = False
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
            .Visible = False
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoDelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.SwMemoNo
            .DataPropertyName = "SwMemoNo"
            .Name = "SwMemoNo"
        End With


        'For dgDetails properies

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.POMasterID
            .DataPropertyName = "POMasterID"
            .Name = "POMasterID"
            .Visible = False
        End With

        With Me.PONoMast
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
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

        'With Me.POProdID
        '    .DataSource = CallClass.PopulateComboBox("tblProdDesc", "poRecGetProd").Tables("tblProdDesc")
        '    .DisplayMember = "ProdDescr"
        '    .ValueMember = "ProdID"
        '    .DataPropertyName = "POProdID"
        '    .Name = "POProdID"
        'End With

        'With Me.POMpoID
        '    .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
        '    .DisplayMember = "MpoNo"
        '    .ValueMember = "MpoId"
        '    .DataPropertyName = "POMpoID"
        '    .Name = "POMpoID"
        'End With

        With Me.MpoNoDet
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.POUM
            .DataSource = CallClass.PopulateComboBox("tblUM", "cmbGetUM").Tables("tblUM")
            .DisplayMember = "IDum"
            .ValueMember = "IDum"
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POItemEscompte
            .DataPropertyName = "POItemEscompte"
            .Name = "POItemEscompte"
        End With

        With Me.TotalValue
            .DataPropertyName = "TotalValue"
            .Name = "TotalValue"
        End With

        'For dgInsp properies

        With Me.RecvPODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PoDueDate
            .DataPropertyName = "PoDueDate"
            .Name = "PoDueDate"
        End With

        With Me.RecvPOItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.PslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.PSlipQty
            .DataPropertyName = "PSlipQty"
            .Name = "PSlipQty"
        End With

        With Me.PslipUM
            .DataPropertyName = "PslipUM"
            .Name = "PslipUM"
        End With

        With Me.PslipPrice
            .DataPropertyName = "PslipPrice"
            .Name = "PslipPrice"
        End With

        With Me.PslipDiscount
            .DataPropertyName = "PslipDiscount"
            .Name = "PslipDiscount"
        End With

        With Me.TotalPslipValue
            .DataPropertyName = "TotalPslipValue"
            .Name = "TotalPslipValue"
        End With

        With Me.RecQtyAccp
            .DataPropertyName = "RecQtyAccp"
            .Name = "RecQtyAccp"
        End With

        With Me.RecQtyRej
            .DataPropertyName = "RecQtyRej"
            .Name = "RecQtyRej"
        End With

    End Sub

    Private Sub cmbDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbDate.Validating
        PutDataInfo()

        CalculGrid()
        CalculValue()
        dgSales.Focus()

        PutSalesFr()
    End Sub

    Private Sub cmbDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDate.ValueChanged
        ' PutDataInfo()
    End Sub

    Sub BindComponents()
        txtMpoNotes.DataBindings.Clear()
        txtTechNotes.DataBindings.Clear()
        txtSalesNotes.DataBindings.Clear()

        txtMpoNotes.DataBindings.Add("Text", dsMain, "SalesTable.CustMpoPart.MpoNotes")
        txtTechNotes.DataBindings.Add("Text", dsMain, "SalesTable.CustMpoPart.MpoTechNotes")
        txtSalesNotes.DataBindings.Add("Text", dsMain, "SalesTable.DelivNotes")

    End Sub

    'Sub CalculQtyToShip()

    ' it's calculated in store procedure
    '    For Each Row As DataGridViewRow In dgSales.Rows
    '        If IsDBNull(Row.Cells("DelivCheckForecast").Value) = True Or _
    '            Nz.Nz(Row.Cells("DelivCheckForecast").Value) = 0 Or _
    '             IsDBNull(Row.Cells("DelivQtyToShip").Value) = True Then
    '            Row.Cells("DelivQtyToShip").Value = Nz.Nz(Row.Cells("DelivQty").Value) - Nz.Nz(Row.Cells("DelivShippedQty").Value)
    '        End If
    '    Next

    'End Sub

    Sub CalculGrid()

        If ChkLab.Checked = False Then
            For Each Row As DataGridViewRow In dgSales.Rows
                Row.Cells("FrecastValue").Value = Nz.Nz(Row.Cells("DelivQtyToShip").Value) * _
                                    Nz.Nz(Row.Cells("OrdItemPrice").Value) * _
                                    Nz.Nz(Row.Cells("SwRateMonth").Value)
                If Nz.Nz(Row.Cells("DelivQtyToShip").Value) <> Nz.Nz(Row.Cells("DelivQty").Value) Then
                    Row.Cells("DelivQtyToShip").Style.BackColor = Color.Coral
                Else
                    Row.Cells("DelivQtyToShip").Style.BackColor = Color.White
                End If
            Next
        Else
            For Each Row As DataGridViewRow In DgLab.Rows
                Row.Cells("FrecastValue").Value = Nz.Nz(Row.Cells("DelivQtyToShip").Value) * _
                                   Nz.Nz(Row.Cells("OrdItemPrice").Value) * _
                                   Nz.Nz(Row.Cells("SwRateMonth").Value)
                If Nz.Nz(Row.Cells("DelivQtyToShip").Value) <> Nz.Nz(Row.Cells("DelivQty").Value) Then
                    Row.Cells("DelivQtyToShip").Style.BackColor = Color.Coral
                Else
                    Row.Cells("DelivQtyToShip").Style.BackColor = Color.White
                End If
            Next
        End If

    End Sub

    Sub CalculValue()

        Dim qty As Double = 0.0

        If ChkLab.Checked = False Then

            For Each Row As DataGridViewRow In dgSales.Rows
                qty = qty + Nz.Nz(Row.Cells("FrecastValue").Value)
            Next
            txtForecastValue.Text = qty.ToString("C2")

            qty = 0.0
            For Each Row As DataGridViewRow In dgSales.Rows
                If IsDBNull(Row.Cells("DelivCheckForecast").Value) = False Then
                    If Row.Cells("DelivCheckForecast").Value = "1" Then
                        qty = qty + Nz.Nz(Row.Cells("FrecastValue").Value)
                    End If
                End If
            Next
            txtValCheck.Text = qty.ToString("C2")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("QtyActual").Value)
            Next
            txtActual.Text = qty.ToString("N0")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("QtyEngReleased").Value)
            Next
            txtEngRel.Text = qty.ToString("N0")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("StFinal").Value)
            Next
            txtFP.Text = qty.ToString("N0")

        Else

            For Each Row As DataGridViewRow In DgLab.Rows
                qty = qty + Nz.Nz(Row.Cells("FrecastValue").Value)
            Next
            txtForecastValue.Text = qty.ToString("C2")

            qty = 0.0
            For Each Row As DataGridViewRow In DgLab.Rows
                If IsDBNull(Row.Cells("DelivCheckForecast").Value) = False Then
                    If Row.Cells("DelivCheckForecast").Value = "1" Then
                        qty = qty + Nz.Nz(Row.Cells("FrecastValue").Value)
                    End If
                End If
            Next
            txtValCheck.Text = qty.ToString("C2")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("QtyActual").Value)
            Next
            txtActual.Text = qty.ToString("N0")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("QtyEngReleased").Value)
            Next
            txtEngRel.Text = qty.ToString("N0")

            qty = 0.0
            For Each Row As DataGridViewRow In dgMpo.Rows
                qty = qty + Nz.Nz(Row.Cells("StFinal").Value)
            Next
            txtFP.Text = qty.ToString("N0")

        End If

    End Sub

    Sub PutSalesFr()

        If ChkLab.Checked = False Then
            For Each RowFr As DataGridViewRow In dgSales.Rows

                RowFr.Cells("CustomerShort").Style.BackColor = Color.White
                RowFr.Cells("OrdNumber").Style.BackColor = Color.White
                RowFr.Cells("DelivDate").Style.BackColor = Color.White

                If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "1" Then
                    RowFr.Cells("CustomerShort").Style.BackColor = Color.CornflowerBlue
                    RowFr.Cells("OrdNumber").Style.BackColor = Color.CornflowerBlue
                    RowFr.Cells("DelivDate").Style.BackColor = Color.CornflowerBlue
                Else
                    If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "2" Then
                        RowFr.Cells("CustomerShort").Style.BackColor = Color.Yellow
                        RowFr.Cells("OrdNumber").Style.BackColor = Color.Yellow
                        RowFr.Cells("DelivDate").Style.BackColor = Color.Yellow
                    Else
                        If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "3" Then
                            RowFr.Cells("CustomerShort").Style.BackColor = Color.PaleGreen
                            RowFr.Cells("OrdNumber").Style.BackColor = Color.PaleGreen
                            RowFr.Cells("DelivDate").Style.BackColor = Color.PaleGreen
                        Else
                            If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "4" Then
                                RowFr.Cells("CustomerShort").Style.BackColor = Color.Beige
                                RowFr.Cells("OrdNumber").Style.BackColor = Color.Beige
                                RowFr.Cells("DelivDate").Style.BackColor = Color.Beige
                            End If
                        End If
                    End If
                End If
            Next

        Else

            For Each RowFr As DataGridViewRow In DgLab.Rows
                RowFr.Cells("MPONo").Style.BackColor = Color.White
                RowFr.Cells("DeptNode").Style.BackColor = Color.White
                RowFr.Cells("DelivDate").Style.BackColor = Color.White

                If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "1" Then
                    RowFr.Cells("MPONo").Style.BackColor = Color.CornflowerBlue
                    RowFr.Cells("DeptNode").Style.BackColor = Color.CornflowerBlue
                    RowFr.Cells("DelivDate").Style.BackColor = Color.CornflowerBlue
                Else
                    If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "2" Then
                        RowFr.Cells("MPONo").Style.BackColor = Color.Yellow
                        RowFr.Cells("DeptNode").Style.BackColor = Color.Yellow
                        RowFr.Cells("DelivDate").Style.BackColor = Color.Yellow
                    Else
                        If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "3" Then
                            RowFr.Cells("MPONo").Style.BackColor = Color.PaleGreen
                            RowFr.Cells("DeptNode").Style.BackColor = Color.PaleGreen
                            RowFr.Cells("DelivDate").Style.BackColor = Color.PaleGreen
                        Else
                            If Nz.Nz(RowFr.Cells("DelivSwForecast").Value) = "4" Then
                                RowFr.Cells("MPONo").Style.BackColor = Color.Beige
                                RowFr.Cells("DeptNode").Style.BackColor = Color.Beige
                                RowFr.Cells("DelivDate").Style.BackColor = Color.Beige
                            End If
                        End If
                    End If
                End If
            Next
        End If


    End Sub

    Function RoleSalesFR(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SALESFR" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub dgSales_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgSales.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSales = e.RowIndex
        End If

        If RoleSalesFR(wkDeptCode) = True Then
            Select Case e.ColumnIndex
                Case 0 To 10
                    e.Cancel = True
                Case 12, 15, 16
                    e.Cancel = True
            End Select
        Else
            Select Case e.ColumnIndex
                Case 0 To 16
                    e.Cancel = True
            End Select
        End If

    End Sub

    Private Sub dgSales_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSales.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSales = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 11
                UpdateDelivQtyToShip()
                CalculGrid()
                CalculValue()
            Case 13
                UpdateDelivSwForecast()
                PutSalesFr()
            Case 14
                UpdateDelivCheckForecast()
                CalculValue()
        End Select

    End Sub

    Private Sub dgSales_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSales.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSales = e.RowIndex
        End If

        CalculGrid()
        CalculValue()
        PutSalesFr()

    End Sub

    Private Sub dgSales_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSales.DataError
        e.Cancel = True
        REM end
    End Sub

    Private Sub dgSales_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgSales.SortCompare
        'Try to sort based on the columns in the current column.
        e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())

        'If the cells are equal, sort based on the race start time column
        If e.SortResult = 0 Then
            e.SortResult = System.String.Compare(dgSales.Rows(e.RowIndex1).Cells("CopySwForecast").Value.ToString(), dgSales.Rows(e.RowIndex2).Cells("CopySwForecast").Value.ToString())
        End If

        e.Handled = True

    End Sub

    Private Sub dgSales_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSales.Sorted
        CalculGrid()
        CalculValue()
        PutSalesFr()
    End Sub

    Private Sub dgMpo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMpo.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMpo = e.RowIndex

        Select Case e.ColumnIndex
            Case 9

                Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim rptPO As New rptLisiMemo()
                rptPO.ReportOptions.EnableSaveDataWithReport = False

                Dim FindMemo As String
                FindMemo = Nz.Nz(dgMpo("SwMemoNo", RowMpo).Value)

                If FindMemo <> "0" Then

                    Try
                        rptPO.Load("..\rptLisiMemo.rpt")
                        pdvCustomerName.Value = FindMemo
                        pvCollection.Add(pdvCustomerName)
                        rptPO.DataDefinition.ParameterFields("@FindMemo").ApplyCurrentValues(pvCollection)

                        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
                        frmPOMasterPrint.ShowDialog()
                    Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                        MsgBox("Incorrect path for loading report.", _
                                MsgBoxStyle.Critical, "Load Report Error")

                    Catch Exp As Exception
                        MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

                    End Try
                Else
                    MsgBox("!!!  Nothing to View.  !!!")
                End If

        End Select

    End Sub

    Private Sub dgMpo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 8
                UpdateMpoNotes()
            Case 9
                UpdateMpoTechNotes()
        End Select

    End Sub

    Private Sub dgMpo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

        'CalculValue()
    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        e.ThrowException = False
        e.Cancel = True
        REM end 
    End Sub

    Sub UpdateMpoNotes()

        If IsDBNull(dgMpo("MpoNotes", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = dgMpo("MpoNotes", RowMpo).Value
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoTechNotes()

        If IsDBNull(dgMpo("MpoTechNotes", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoTechNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = dgMpo("MpoTechNotes", RowMpo).Value
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Technical Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateDelivCheckForecast()

        If ChkLab.Checked = False Then      'sales screen

            If IsDBNull(dgSales("DelivCheckForecast", RowSales).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivCheckForecast", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = dgSales("OrdDelivID", RowSales).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivCheckForecast", SqlDbType.Bit, 1)
            paraSwForecast.Value = dgSales("DelivCheckForecast", RowSales).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Check Deliv Forecast (Sales Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try

        Else            'LAB screen

            If IsDBNull(DgLab("DelivCheckForecast", RowLab).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivCheckForecast", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = DgLab("OrdDelivID", RowLab).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivCheckForecast", SqlDbType.Bit, 1)
            paraSwForecast.Value = DgLab("DelivCheckForecast", RowLab).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Check Deliv Forecast (LAB Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    Sub UpdateDelivSwForecast()

        If ChkLab.Checked = False Then      'sales screen
            If IsDBNull(dgSales("DelivSwForecast", RowSales).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivSwForecast", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = dgSales("OrdDelivID", RowSales).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivSwForecast", SqlDbType.NVarChar, 1)
            paraSwForecast.Value = dgSales("DelivSwForecast", RowSales).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Flag Deliv Forecast (Sales Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try

        Else            'LAB screen

            If IsDBNull(DgLab("DelivSwForecast", RowLab).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivSwForecast", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = DgLab("OrdDelivID", RowLab).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivSwForecast", SqlDbType.NVarChar, 1)
            paraSwForecast.Value = DgLab("DelivSwForecast", RowLab).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Flag Deliv Forecast (LAB Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try

        End If

    End Sub

    Sub UpdateDelivNotes()

        If IsDBNull(dgSales("DelivNotes", RowSales).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
        paraDelivID.Value = dgSales("OrdDelivID", RowSales).Value
        mySqlComm.Parameters.Add(paraDelivID)

        Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivNotes", SqlDbType.NVarChar, 1000)
        paraSwForecast.Value = dgSales("DelivNotes", RowSales).Value
        mySqlComm.Parameters.Add(paraSwForecast)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Flag Deliv Forecast: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateDelivQtyToShip()

        If ChkLab.Checked = False Then      'sales screen
            If IsDBNull(dgSales("DelivQtyToShip", RowSales).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivQtyToShip", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = dgSales("OrdDelivID", RowSales).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivQtyToShip", SqlDbType.Real, 4)
            paraSwForecast.Value = dgSales("DelivQtyToShip", RowSales).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Flag Deliv Qty To Ship (Sales Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try

        Else            'lab screen
            If IsDBNull(DgLab("DelivQtyToShip", RowLab).Value) = True Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDelivQtyToShip", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = DgLab("OrdDelivID", RowLab).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraSwForecast As SqlParameter = New SqlParameter("@DelivQtyToShip", SqlDbType.Real, 4)
            paraSwForecast.Value = DgLab("DelivQtyToShip", RowLab).Value
            mySqlComm.Parameters.Add(paraSwForecast)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update Flag Deliv Qty To Ship (LAB Screen): " & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    Private Sub txtMpoNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMpoNotes.Validating
        If RowMpo <= 0 Then
            Exit Sub
        End If

        dgMpo("MpoNotes", RowMpo).Value = Trim(txtMpoNotes.Text)
        UpdateMpoNotes()
    End Sub

    Private Sub txtTechNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTechNotes.Validating
        If RowMpo < 0 Then
            Exit Sub
        End If

        dgMpo("MpoTechNotes", RowMpo).Value = Trim(txtTechNotes.Text)
        UpdateMpoTechNotes()

    End Sub

    Private Sub txtSalesNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSalesNotes.Validating
        If RowSales < 0 Then
            Exit Sub
        End If

        dgSales("DelivNotes", RowSales).Value = Trim(txtSalesNotes.Text)
        UpdateDelivNotes()

    End Sub

    Private Sub cmdPrintLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLot.Click

        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim rptPO As New rptSalesForecastOnLine()

        Try
            rptPO.Load("..\rptSalesForecastOnLine.rpt")
            pdvCustomerName.Value = cmbDate.Text
            pvCollection.Add(pdvCustomerName)
            rptPO.DataDefinition.ParameterFields("@strSearch").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Private Sub CmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintAll.Click
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim rptPO As New rptSalesForecastOnLineALL()

        Try
            rptPO.Load("..\rptSalesForecastOnLineAll.rpt")
            pdvCustomerName.Value = cmbDate.Text
            pvCollection.Add(pdvCustomerName)
            rptPO.DataDefinition.ParameterFields("@strSearch").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub ChkLab_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLab.CheckedChanged
        If ChkLab.Checked = True Then
            PlLab.Visible = True
            PlSales.Visible = False
        Else
            PlLab.Visible = False
            PlSales.Visible = True
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        SetupForm()

    End Sub

    Private Sub DgLab_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DgLab.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowLab = e.RowIndex
        End If

        If RoleSalesFR(wkDeptCode) = True Then
            Select Case e.ColumnIndex
                Case 0 To 8, 10, 13 To 17
                    e.Cancel = True
            End Select
        Else
            Select Case e.ColumnIndex
                Case 0 To 17
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub DgLab_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLab.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowLab = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 8
                UpdateDelivQtyToShip()
                CalculGrid()
                CalculValue()
            Case 10
                UpdateDelivSwForecast()
                PutSalesFr()
            Case 11
                UpdateDelivCheckForecast()
                CalculValue()
        End Select
    End Sub

    Private Sub DgLab_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgLab.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowLab = e.RowIndex
        End If

    End Sub

    Private Sub DgLab_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgLab.DataError
        e.Cancel = True
        REM end
    End Sub

    Private Sub DgLab_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DgLab.SortCompare

        'Try to sort based on the columns in the current column.
        e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())

        'If the cells are equal, sort based on the race start time column
        If e.SortResult = 0 Then
            e.SortResult = System.String.Compare(DgLab.Rows(e.RowIndex1).Cells("CopySwForecast").Value.ToString(), DgLab.Rows(e.RowIndex2).Cells("CopySwForecast").Value.ToString())
        End If

        e.Handled = True

    End Sub

    Private Sub DgLab_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgLab.Sorted

        CalculGrid()
        CalculValue()
        PutSalesFr()

    End Sub

    Private Sub CmdLab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLab.Click

        Dim rptPO As New rptSalesForecastLabInspection()

        Try
            rptPO.Load("..\rptSalesForecastLabInspection.rpt")
            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()
            
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub
End Class