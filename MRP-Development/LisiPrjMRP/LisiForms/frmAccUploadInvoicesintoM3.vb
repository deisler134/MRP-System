Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Text

Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.IO

Public Class frmAccUploadInvoicesintoM3
    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim KeepNo As Integer = 0

    Dim KeepIdent As String
    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height


    Private Sub frmAccUploadInvoicesintoM3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmAccUploadInvoicesintoM3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1600 And Height > 900 Then
            Me.Width = 1600
            Me.Height = 900
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

        ClearFields()

        InitialComponents()

        SetCtlForm()

        CmdSearch.Enabled = False
        CmdExport.Enabled = False
        CmdClear.Enabled = True

    End Sub

    Sub ClearFields()

        RdI2.Checked = False
        RdI5.Checked = False
        RdI6.Checked = False
        RdI9.Checked = False
        RdI99.Checked = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccUpload_DOs_I2_IntoM3Empty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("getAccUpload_Invoices_I5_IntoM3Empty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("getAccUpload_FP_I6_IntoM3Empty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("getAccUpload_COs_I9_IntoDWHEmpty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("getAccUpload_DOs_I99_IntoM3Empty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        '    I2     =========================

        With Me.LACData
            .DataPropertyName = "LACData"
            .Name = "LACData"
        End With

        With Me.I2ShipShortName
            .DataPropertyName = "I2ShipShortName"
            .Name = "I2ShipShortName"
            .Visible = False
        End With

        With Me.I2PslipORDRefNo
            .DataPropertyName = "I2PslipORDRefNo"
            .Name = "I2PslipORDRefNo"
            .Visible = False
        End With

        With Me.I2PslipItem
            .DataPropertyName = "I2PslipItem"
            .Name = "I2PslipItem"
            .Visible = False
        End With

        With Me.I2MMITDS
            .DataPropertyName = "I2MMITDS"
            .Name = "I2MMITDS"
            .Visible = False
        End With

        With Me.I2InvDate
            .DataPropertyName = "I2InvDate"
            .Name = "I2InvDate"
            .Visible = False
        End With

        With Me.I2MpoNo
            .DataPropertyName = "I2MpoNo"
            .Name = "I2MpoNo"
            .Visible = False
        End With

        With Me.I2PslipQty
            .DataPropertyName = "I2PslipQty"
            .Name = "I2PslipQty"
            .Visible = False
        End With

        With Me.I2PslipNo
            .DataPropertyName = "I2PslipNo"
            .Name = "I2PslipNo"
            .Visible = False
        End With

        With Me.I2DelivStatus
            .DataPropertyName = "I2DelivStatus"
            .Name = "I2DelivStatus"
            .Visible = False
        End With

        With Me.I2CoCPartRev
            .DataPropertyName = "I2CoCPartRev"
            .Name = "I2CoCPartRev"
            .Visible = False
        End With

        With Me.I2ShipVia
            .DataPropertyName = "I2ShipVia"
            .Name = "I2ShipVia"
            .Visible = False
        End With

        With Me.I2InvFOB
            .DataPropertyName = "I2InvFOB"
            .Name = "I2InvFOB"
            .Visible = False
        End With

        With Me.I2InvPosted
            .DataPropertyName = "I2InvPosted"
            .Name = "I2InvPosted"
            .Visible = False
        End With

        With Me.I2PslipType
            .DataPropertyName = "I2PslipType"
            .Name = "I2PslipType"
            .Visible = False
        End With

        With Me.I2PartNumber
            .DataPropertyName = "I2PartNumber"
            .Name = "I2PartNumber"
            .Visible = False
        End With

        With Me.I2DelivDate
            .DataPropertyName = "I2DelivDate"
            .Name = "I2DelivDate"
            .Visible = False
        End With

        With Me.I2InvPrice
            .DataPropertyName = "I2InvPrice"
            .Name = "I2InvPrice"
            .Visible = False
        End With

        With Me.I2StDate
            .DataPropertyName = "I2StDate"
            .Name = "I2StDate"
            .Visible = False
        End With

        With Me.I2PslipCustPoContr
            .DataPropertyName = "I2PslipCustPoContr"
            .Name = "I2PslipCustPoContr"
            .Visible = False
        End With

        With Me.I2StStockClasification
            .DataPropertyName = "I2StStockClasification"
            .Name = "I2StStockClasification"
            .Visible = False
        End With

        With Me.I2TextNotes
            .DataPropertyName = "I2TextNotes"
            .Name = "I2TextNotes"
            .Visible = False
        End With

        With Me.I2DelivQty
            .DataPropertyName = "I2DelivQty"
            .Name = "I2DelivQty"
            .Visible = False
        End With

        With Me.I2StPrice
            .DataPropertyName = "I2StPrice"
            .Name = "I2StPrice"
            .Visible = False
        End With

        With Me.I2MpoRMCostCDN
            .DataPropertyName = "I2MpoRMCostCDN"
            .Name = "I2MpoRMCostCDN"
            .Visible = False
        End With

        '      I5     ========================


        With Me.I5PslipORDRefNo
            .DataPropertyName = "I5PslipORDRefNo"
            .Name = "I5PslipORDRefNo"
            .Visible = False
        End With

        With Me.I5InvCodeM3
            .DataPropertyName = "I5InvCodeM3"
            .Name = "I5InvCodeM3"
            .Visible = False
        End With

        With Me.I5InvM3TwoCust
            .DataPropertyName = "I5InvM3TwoCust"
            .Name = "I5InvM3TwoCust"
            .Visible = False
        End With

        With Me.I5PslipItem
            .DataPropertyName = "I5PslipItem"
            .Name = "I5PslipItem"
            .Visible = False
        End With

        With Me.I5MMITDS
            .DataPropertyName = "I5MMITDS"
            .Name = "I5MMITDS"
            .Visible = False
        End With

        With Me.I5DelivDate
            .DataPropertyName = "I5DelivDate"
            .Name = "I5DelivDate"
            .Visible = False
        End With

        With Me.I5MpoNo
            .DataPropertyName = "I5MpoNo"
            .Name = "I5MpoNo"
            .Visible = False
        End With

        With Me.I5StDate
            .DataPropertyName = "I5StDate"
            .Name = "I5StDate"
            .Visible = False
        End With

        With Me.I5DelivDate
            .DataPropertyName = "I5DelivDate"
            .Name = "I5DelivDate"
            .Visible = False
        End With

        With Me.I5StStockClasification
            .DataPropertyName = "I5StStockClasification"
            .Name = "I5StStockClasification"
            .Visible = False
        End With

        With Me.I5InvPrice
            .DataPropertyName = "I5InvPrice"
            .Name = "I5InvPrice"
            .Visible = False
        End With

        With Me.I5PslipQty
            .DataPropertyName = "I5PslipQty"
            .Name = "I5PslipQty"
            .Visible = False
        End With

        With Me.I5PslipNo
            .DataPropertyName = "I5PslipNo"
            .Name = "I5PslipNo"
            .Visible = False
        End With

        With Me.I5TextNotes
            .DataPropertyName = "I5TextNotes"
            .Name = "I5TextNotes"
            .Visible = False
        End With

        With Me.I5PoNoDeliv
            .DataPropertyName = "I5PoNoDeliv"
            .Name = "I5PoNoDeliv"
            .Visible = False
        End With

        With Me.I5DelivStatus
            .DataPropertyName = "I5DelivStatus"
            .Name = "I5DelivStatus"
            .Visible = False
        End With

        With Me.I5InvPrice
            .DataPropertyName = "I5InvPrice"
            .Name = "I5InvPrice"
            .Visible = False
        End With

        With Me.I5CoCPartRev
            .DataPropertyName = "I5CoCPartRev"
            .Name = "I5CoCPartRev"
            .Visible = False
        End With

        With Me.I5ShipVia
            .DataPropertyName = "I5ShipVia"
            .Name = "I5ShipVia"
            .Visible = False
        End With

        With Me.I5InvFOB
            .DataPropertyName = "I5InvFOB"
            .Name = "I5InvFOB"
            .Visible = False
        End With

        With Me.I5PartNumber
            .DataPropertyName = "I5PartNumber"
            .Name = "I5PartNumber"
            .Visible = False
        End With

        With Me.I5MpoRMCostCDN
            .DataPropertyName = "I5MpoRMCostCDN"
            .Name = "I5MpoRMCostCDN"
            .Visible = False
        End With

        With Me.I5StPrice
            .DataPropertyName = "I5StPrice"
            .Name = "I5StPrice"
            .Visible = False
        End With

        With Me.I5InvAccpacGL1
            .DataPropertyName = "I5InvAccpacGL1"
            .Name = "I5InvAccpacGL1"
            .Visible = False
        End With

        With Me.I5InvAccpacGL2
            .DataPropertyName = "I5InvAccpacGL2"
            .Name = "I5InvAccpacGL2"
            .Visible = False
        End With

        With Me.I5InvAccpacGL3
            .DataPropertyName = "I5InvAccpacGL3"
            .Name = "I5InvAccpacGL3"
            .Visible = False
        End With

        With Me.I5InvValCh1
            .DataPropertyName = "I5InvValCh1"
            .Name = "I5InvValCh1"
            .Visible = False
        End With

        With Me.I5InvValCh2
            .DataPropertyName = "I5InvValCh2"
            .Name = "I5InvValCh2"
            .Visible = False
        End With

        With Me.I5InvValCh3
            .DataPropertyName = "I5InvValCh3"
            .Name = "I5InvValCh3"
            .Visible = False
        End With


        '  I6   =====================

        With Me.I6CONO
            .DataPropertyName = "I6CONO"
            .Name = "I6CONO"
            .Visible = False
        End With

        With Me.I6WHLO
            .DataPropertyName = "I6WHLO"
            .Name = "I6WHLO"
            .Visible = False
        End With

        With Me.I6MMITDS
            .DataPropertyName = "I6MMITDS"
            .Name = "I6MMITDS"
            .Visible = False
        End With

        With Me.I6Stock
            .DataPropertyName = "I6Stock"
            .Name = "I6Stock"
            .Visible = False
        End With

        With Me.I6STAG
            .DataPropertyName = "I6STAG"
            .Name = "I6STAG"
            .Visible = False
        End With

        With Me.I6MpoNo
            .DataPropertyName = "I6MpoNo"
            .Name = "I6MpoNo"
            .Visible = False
        End With

        With Me.I6StDate
            .DataPropertyName = "I6StDate"
            .Name = "I6StDate"
            .Visible = False
        End With

        With Me.I6WHSL
            .DataPropertyName = "I6WHSL"
            .Name = "I6WHSL"
            .Visible = False
        End With

        With Me.I6StPrice
            .DataPropertyName = "I6StPrice"
            .Name = "I6StPrice"
            .Visible = False
        End With

        With Me.I6MpoPartRev
            .DataPropertyName = "I6MpoPartRev"
            .Name = "I6MpoPartRev"
            .Visible = False
        End With

        With Me.I6PartNumber
            .DataPropertyName = "I6PartNumber"
            .Name = "I6PartNumber"
            .Visible = False
        End With

        With Me.I6StStockClasification
            .DataPropertyName = "I6StStockClasification"
            .Name = "I6StStockClasification"
            .Visible = False
        End With

        With Me.I6MpoRMCostCDN
            .DataPropertyName = "I6MpoRMCostCDN"
            .Name = "I6MpoRMCostCDN"
            .Visible = False
        End With

        '====

        With Me.I9OrderNumber
            .DataPropertyName = "I9OrderNumber"
            .Name = "I9OrderNumber"
            .Visible = False
        End With

        With Me.I9OrderLineNumber
            .DataPropertyName = "I9OrderLineNumber"
            .Name = "I9OrderLineNumber"
            .Visible = False
        End With

        With Me.I9OrderDate
            .DataPropertyName = "I9OrderDate"
            .Name = "I9OrderDate"
            .Visible = False
        End With

        With Me.I9Quantity
            .DataPropertyName = "I9Quantity"
            .Name = "I9Quantity"
            .Visible = False
        End With

        With Me.I9Price
            .DataPropertyName = "I9Price"
            .Name = "I9Price"
            .Visible = False
        End With

        With Me.I9Currency
            .DataPropertyName = "I9Currency"
            .Name = "I9Currency"
            .Visible = False
        End With

        With Me.I9LineStatus
            .DataPropertyName = "I9LineStatus"
            .Name = "I9LineStatus"
            .Visible = False
        End With

        With Me.I9AlliasNumber
            .DataPropertyName = "I9AlliasNumber"
            .Name = "I9AlliasNumber"
            .Visible = False
        End With

        With Me.I9Name
            .DataPropertyName = "I9Name"
            .Name = "I9Name"
            .Visible = False
        End With

        With Me.I9DeliveryDate
            .DataPropertyName = "I9DeliveryDate"
            .Name = "I9DeliveryDate"
            .Visible = False
        End With

        With Me.I9PlannedDate
            .DataPropertyName = "I9PlannedDate"
            .Name = "I9PlannedDate"
            .Visible = False
        End With

        With Me.I9OrdNumber
            .DataPropertyName = "I9OrdNumber"
            .Name = "I9OrdNumber"
            .Visible = False
        End With

        With Me.I9CustCodeM3
            .DataPropertyName = "I9CustCodeM3"
            .Name = "I9CustCodeM3"
            .Visible = False
        End With

        With Me.I9CustomerShort
            .DataPropertyName = "I9CustomerShort"
            .Name = "I9CustomerShort"
            .Visible = False
        End With

        With Me.I9MMITDS
            .DataPropertyName = "I9MMITDS"
            .Name = "I9MMITDS"
            .Visible = False
        End With

        With Me.I9OrdItemQty
            .DataPropertyName = "I9OrdItemQty"
            .Name = "I9OrdItemQty"
            .Visible = False
        End With

        With Me.I9CustomerName
            .DataPropertyName = "I9CustomerName"
            .Name = "I9CustomerName"
            .Visible = False
        End With


        '  I99 ======

        With Me.I99DONumber
            .DataPropertyName = "I99DONumber"
            .Name = "I99DONumber"
            .Visible = False
        End With

        With Me.I99DOLineNumber
            .DataPropertyName = "I99DOLineNumber"
            .Name = "I99DOLineNumber"
            .Visible = False
        End With

        With Me.I99DODate
            .DataPropertyName = "I99DODate"
            .Name = "I99DODate"
            .Visible = False
        End With

        With Me.I99DelivQty
            .DataPropertyName = "I99DelivQty"
            .Name = "I99DelivQty"
            .Visible = False
        End With

        With Me.I99Price
            .DataPropertyName = "I99Price"
            .Name = "I99Price"
            .Visible = False
        End With

        With Me.I99Devise
            .DataPropertyName = "I99Devise"
            .Name = "I99Devise"
            .Visible = False
        End With

        With Me.I99LineStatus
            .DataPropertyName = "I99LineStatus"
            .Name = "I99LineStatus"
            .Visible = False
        End With

        With Me.I99PartITDS
            .DataPropertyName = "I99PartITDS"
            .Name = "I99PartITDS"
            .Visible = False
        End With

        With Me.I99PlanDate
            .DataPropertyName = "I99PlanDate"
            .Name = "I99PlanDate"
            .Visible = False
        End With

        With Me.I99WHSE
            .DataPropertyName = "I99WHSE"
            .Name = "I99WHSE"
            .Visible = False
        End With

        With Me.I99ITNO
            .DataPropertyName = "I99ITNO"
            .Name = "I99ITNO"
            .Visible = False
        End With


    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        '=======

        If RdI2.Checked = False And RdI5.Checked = False And RdI6.Checked = False And RdI9.Checked = False And RdI99.Checked = False Then
            MsgBox("!!! ERROR !!! Please select the type of data that you want to be extracted")
        Else
            If RdI2.Checked = True Then
                CallClass.PopulateDataAdapter("getAccUpload_DOs_I2_IntoM3").Fill(dsMain, "tblSelect")
                If dgMPO.RowCount > 0 Then
                    CmdExport.Enabled = True
                    PutInfoI2_DOs()
                Else
                    MsgBox("No data found after search")
                End If
            End If

            '======

            If RdI5.Checked = True Then
                CallClass.PopulateDataAdapter("getAccUpload_Invoices_I5_IntoM3").Fill(dsMain, "tblSelect")
                If dgMPO.RowCount > 0 Then
                    CmdExport.Enabled = True
                    PutInfoI5_Invoices()
                Else
                    MsgBox("No data found after search")
                End If
            End If

            '======

            If RdI6.Checked = True Then
                CallClass.PopulateDataAdapter("getAccUpload_FP_I6_IntoM3").Fill(dsMain, "tblSelect")
                If dgMPO.RowCount > 0 Then
                    CmdExport.Enabled = True
                    PutInfoI6_FP()
                Else
                    MsgBox("No data found after search")
                End If
            End If

            '=====

            If RdI9.Checked = True Then
                CallClass.PopulateDataAdapter("getAccUpload_COs_I9_IntoDWH").Fill(dsMain, "tblSelect")
                If dgMPO.RowCount > 0 Then
                    CmdExport.Enabled = True
                    PutInfoI9_FP()
                Else
                    MsgBox("No data found after search")
                End If
            End If

            '======

            If RdI99.Checked = True Then
                CallClass.PopulateDataAdapter("getAccUpload_DOs_I99_IntoM3").Fill(dsMain, "tblSelect")
                If dgMPO.RowCount > 0 Then
                    CmdExport.Enabled = True
                    PutInfoI99_DOs()
                Else
                    MsgBox("No data found after search")
                End If
            End If

        End If

    End Sub

    Sub PutInfoI2_DOs()

        For Each Row As DataGridViewRow In dgMPO.Rows

            Row.Cells("LACData").Value = Row.Cells("I2PslipORDRefNo").Value                                             'TRNR  SHOULD BE M3 ORDER NUMBER or DO#
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2ShipShortName").Value)          'TWLO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "LAC"                                             'WHLO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2PslipItem").Value)              'PONR
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "00"                                              'POSX 
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2MMITDS").Value)                 'ITNO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A TRQT 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "PCS"                                             'UNMS 
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2InvDate").Value)                 'RGDT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2DelivDate").Value                    'PLDT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2MpoNo").Value)                  'BANO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2StDate").Value                       'PRTD
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2DelivDate").Value                     'RLDT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A WHSL 

            Select Case Row.Cells("I2StStockClasification").Value
                Case "LACStockPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I2StPrice").Value - Row.Cells("I2MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I2MpoRMCostCDN").Value).ToString("N4"))    'TRPR  (StockPrice-RM)*50+RM
                Case "LACStdPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I2StPrice").Value + Row.Cells("I2MpoRMCostCDN").Value).ToString("N4"))                  'TRPR  SHOULD BE LAC Standard Cost - StPrice contain the std mach cost + rm + processing
                Case "LNAPriceDepreciate"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I2StPrice").Value).ToString("N4"))                  'TRPR  SHOULD BE LNA price Depreciate - StPrice migrated paid with invoice
                Case "LNAPriceCredit"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I2StPrice").Value).ToString("N4"))                 'TRPR  SHOULD BE LNA price Credid  -  StPrice migrated with 25 % reduction
                Case Else
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I2StPrice").Value - Row.Cells("I2MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I2MpoRMCostCDN").Value).ToString("N4"))     'TRPR  (StockPrice-RM)*50+RM
            End Select
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BREF 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BRE2 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BREM 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A RSCD 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2PslipQty").Value)               'DLQT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I2PslipNo").Value)                'CONN
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Dim newString As String = Row.Cells("I2TextNotes").Value.Replace(vbCr, "").Replace(vbLf, "")
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + newString                                         'TEXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2PoNoDeliv").Value                   'N/A RELEASE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            'If (CInt(Row.Cells("I2PslipQty").Value) / CInt(Row.Cells("I2DelivQty").Value)) * 100 < 70 Then              'CLOSE 
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + "N"
            'Else

            'End If
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "Y"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("I2InvPrice").Value)               'PRICE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A CUDT 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2CoCPartRev").Value                 'ECVE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2ShipVia").Value                    'MODLTXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2InvFOB").Value                     'TEDLTXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I2PartNumber").Value                 'Part

        Next

    End Sub

    Sub PutInfoI5_Invoices()

        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("LACData").Value = Row.Cells("I5PslipORDRefNo").Value                                             'ORNO  SHOULD BE M3 ORDER NUMBER or DO#
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"


            If Len(Trim(Row.Cells("I5InvM3TwoCust").Value)) = 0 Then
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5InvCodeM3").Value)          'CUNO
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Else
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5InvM3TwoCust").Value)       'CUNO
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            End If

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "LAC"                                             'WHLO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5PslipItem").Value)              'PONR
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "00"                                              'POSX 
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5MMITDS").Value)                 'ITNO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A TRQT 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + "PCS"                                             'UNMS 
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A RGDT 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5DelivDate").Value                    'PLDT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5MpoNo").Value)                  'BANO
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5StDate").Value                       'PRTD
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5DelivDate").Value                     'RLDT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A WHSL 


            Select Case Row.Cells("I5StStockClasification").Value

                Case "LACStockPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I5StPrice").Value - Row.Cells("I5MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I5MpoRMCostCDN").Value).ToString("N4"))   'TRPR  (StockPrice-RM)*50+RM
                Case "LACStdPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I5StPrice").Value + Row.Cells("I5MpoRMCostCDN").Value).ToString("N4"))                'TRPR  SHOULD BE LAC Standard Cost - StPrice contain the std mach cost + rm + processing
                Case "LNAPriceDepreciate"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I5StPrice").Value).ToString("N4"))                'TRPR  SHOULD BE LNA price Depreciate - StPrice migrated paid with invoice
                Case "LNAPriceCredit"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("I5StPrice").Value).ToString("N4"))                  'TRPR  SHOULD BE LNA price Credid  -  StPrice migrated with 25 % reduction
                Case Else
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I5StPrice").Value - Row.Cells("I5MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I5MpoRMCostCDN").Value).ToString("N4"))     'TRPR  (StockPrice-RM)*50+RM
            End Select
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"


            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BREF 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BRE2 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A BREM 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A RSCD 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5PslipQty").Value)               'DLQT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5PslipNo").Value)                'CONN
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"


            '1950-725000    Cancellation Charge –  7081000 – Other Income
            '400000         EXTRA CHARGES – 7011000 (Product Sales)
            '402000         Expedite Charge - 7081010 Fast Track/Expedite
            '402000         Minimum Charge – 7011000 (Product Sales)
            '403000         Research and Development  - 7081000 – Other Income

            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5InvAccpacGL1").Value)           'CHARGECD1
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5InvAccpacGL2").Value)           'CHARGECD2
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5InvAccpacGL3").Value)           'CHARGECD3
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(CStr(Row.Cells("I5InvValCh1").Value))              'CHARGE1
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(CStr(Row.Cells("I5InvValCh2").Value))            'CHARGE2
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(CStr(Row.Cells("I5InvValCh3").Value))               'CHARGE3
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Dim VarCount, II As Integer
            Dim TmpStr As String = Row.Cells("I5TextNotes").Value

            For II = 1 To Len(TmpStr)
                If Asc(Mid(TmpStr, II, 1)) = 13 Then
                    VarCount = VarCount + 1
                End If
            Next

            Dim newString As String = Row.Cells("I5TextNotes").Value
            For II = 1 To VarCount
                newString = newString.Replace(vbCr, "").Replace(vbLf, "")
            Next

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + newString                                          'TEXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I5PoNoDeliv").Value)                   'RELEASE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            If Row.Cells("I5DelivStatus").Value = "Closed" Then
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + "Y"                                           'CLOSE 
            Else
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + "N"                                           'CLOSE 
            End If
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("I5InvPrice").Value)               'PRICE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           'N/A CUDT 

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5CoCPartRev").Value                 'ECVE
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5ShipVia").Value                    'MODLTXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5InvFOB").Value                     'TEDLTXT
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I5PartNumber").Value                 'Part

        Next
    End Sub

    Sub PutInfoI6_FP()

        For Each Row As DataGridViewRow In dgMPO.Rows

            Row.Cells("LACData").Value = Row.Cells("I6CONO").Value                                                          'CONO  SHOULD BE 100
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6WHLO").Value                             'WHLO  SHOULD BE LAC
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I6MMITDS").Value)                     'ITNO  M3 Item
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I6Stock").Value)                      'TRQT  LAC Stock qty
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6STAG").Value                             'STAG  LAC Stock STATUS SHOUL BE 2
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6MpoNo").Value                            'BANO  LOT NUMBER
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6StDate").Value                           'PRDT  STOCK DATE ENTRY
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6WHSL").Value                             'WHSL  SHOULD BE LAC
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"


            Select Case Row.Cells("I6StStockClasification").Value
                Case "LACStockPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(((Row.Cells("I6StPrice").Value - Row.Cells("I6MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I6MpoRMCostCDN").Value).ToString("N4")     'TRPR  (StockPrice-RM)*50+RM
                Case "LACStdPrice"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(Row.Cells("I6StPrice").Value + Row.Cells("I6MpoRMCostCDN").Value).ToString("N4")                'TRPR  SHOULD BE LAC Standard Cost - StPrice contain the std mach cost + rm + processing
                Case "LNAPriceDepreciate"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(Row.Cells("I6StPrice").Value).ToString("N4")                  'TRPR  SHOULD BE LNA price Depreciate - StPrice migrated paid with invoice
                Case "LNAPriceCredit"
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(Row.Cells("I6StPrice").Value).ToString("N4")                  'TRPR  SHOULD BE LNA price Credid  -  StPrice migrated with 25 % reduction
                Case Else
                    Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(((Row.Cells("I6StPrice").Value - Row.Cells("I6MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I6MpoRMCostCDN").Value).ToString("N4")     'TRPR  (StockPrice-RM)*50+RM


                    'Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(((Row.Cells("I6StPrice").Value - Row.Cells("I6MpoRMCostCDN").Value) * 50 / 100) + Nz.Nz(Row.Cells("I6MpoRMCostCDN")).Value)     'TRPR  (StockPrice-RM)*50+RM
            End Select
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"



            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6MpoPartRev").Value                                   'ECVE  Lot Revision
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I6PartNumber").Value                                   'ITDS Part Number Stock  Lot Revision
        Next

    End Sub

    Sub PutInfoI9_FP()



        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("LACData").Value = Row.Cells("I9OrderNumber").Value                                                   'OrderNumber
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9OrderLineNumber").Value                  'OrderLineNumber
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9OrderDate").Value                        'OrderDate   
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9Quantity").Value)                   'Quantity
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(Row.Cells("I9Price").Value).ToString("N4")                     'Price
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9Currency").Value)                         'Currency
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9LineStatus").Value                       'LineStatus = 22
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9AlliasNumber").Value)                     'AlliasNumber
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9Name").Value)                             'Name
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9DeliveryDate").Value                     'DeliveryDate
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            If IsNothing(Row.Cells("I9PlannedDate").Value) = True Or IsDBNull(Row.Cells("I9PlannedDate").Value) = True Then
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9DeliveryDate").Value                     'PlannedDate
            Else
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9PlannedDate").Value                     'PlannedDate
            End If
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            'CustOrdNumber;M3_CustCode;CustomerShortName;M3_ArticleCode;OrdItemQty"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9OrdNumber").Value                        'OrdNumber
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9CustCodeM3").Value)                       'I9CustCodeM3
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9CustomerName").Value)                     'I9CustomerShort
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I9MMITDS").Value                          'I9MMITDS
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I9OrdItemQty").Value)                    'I9OrdItemQty

        Next

    End Sub


    Sub PutInfoI99_DOs()

        For Each Row As DataGridViewRow In dgMPO.Rows
            Row.Cells("LACData").Value = Row.Cells("I99DONumber").Value                                                     'DO Number
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I99DOLineNumber").Value                    'DO LineNumber
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I99DODate").Value                          'DO Date   
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I99DelivQty").Value)                  'DO Delivered Qty
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CDbl(Row.Cells("I99Price").Value).ToString("N4")      'DO Price
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I99Devise").Value)                    'DO Currency
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I99LineStatus").Value                       'LineStatus = 22
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("I99PartITDS").Value)                   'Name (ITDS)
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I99PlanDate").Value                        'Planned Date
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("I99WHSE").Value                        'LAC
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value & Nz.Nz(Row.Cells("I99ITNO").Value)              'Item Code
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"

            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                                   'Ordered Qty
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                                   'DO Type
            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                                   'Responsable

        Next

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()
        InitialComponents()
        CmdSearch.Enabled = False

        KeepNo = 0
        txtCOBatch.Text = ""

    End Sub

    Sub FindCOBatch()

        KeepNo = 0
        txtCOBatch.Text = ""

        If RdI2.Checked = True Then
            txtCOBatch.Text = CallClass.GenerateNextLot("cspGetNextLot", "LACI2")
        Else
            If RdI5.Checked = True Then
                txtCOBatch.Text = CallClass.GenerateNextLot("cspGetNextLot", "LACI5")
            Else
                If RdI6.Checked = True Then
                    txtCOBatch.Text = CallClass.GenerateNextLot("cspGetNextLot", "LACI6")
                Else
                    txtCOBatch.Text = "ERROR"
                        End If
                    End If
                End If

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        If RdI2.Checked = True Then

            Dim II, JJ As Integer

            For II = 1 To 10000
                JJ = JJ + II
            Next

            FindCOBatch()
            Me.Refresh()

            If txtCOBatch.Text = "ERROR" Then
                CmdSearch.Enabled = False
                CmdExport.Enabled = False
                Exit Sub
            Else
                CmdSearch.Enabled = True
                KeepNo = Val(txtCOBatch.Text)
                txtCOBatch.Text = Trim(txtCOBatch.Text)
            End If

            Dim decimalLength As Integer
            decimalLength = KeepNo.ToString("D").Length + (9 - Len(CStr(KeepNo)))
            KeepIdent = KeepNo.ToString("D" + decimalLength.ToString())

            FileNameStr = ""
            FileNameStr = "LACI2_" + KeepIdent + ".txt"

            Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACI2\" + "LACI2" + "_" + KeepIdent + ".txt")

            For Each Row As DataGridViewRow In dgMPO.Rows
                TextFile.WriteLine(Row.Cells("LACData").Value)
            Next

            TextFile.Close()

            CmdExport.Enabled = False

            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "LACI2", KeepNo)

            CallClass.ExecuteUpdateSearchStr("cspUpdate_DOs_I2", "LNA")


            MsgBox("Action has been successfully completed.")
            dsMain.Clear()

            KeepNo = 0
            txtCOBatch.Text = ""

            sSource = "C:\LACTransferData\LACI2\" + FileNameStr
            sTarget = "\\dcapd01\Interfaces LAC\I2_IN\" + FileNameStr

            File.Copy(sSource, sTarget, True)

            MsgBox("FTP upload successfully done.")

        End If

        '=========================

        If RdI5.Checked = True Then

            Dim II, JJ As Integer

            For II = 1 To 10000
                JJ = JJ + II
            Next

            FindCOBatch()
            Me.Refresh()

            If txtCOBatch.Text = "ERROR" Then
                CmdSearch.Enabled = False
                CmdExport.Enabled = False
                Exit Sub
            Else
                CmdSearch.Enabled = True
                KeepNo = Val(txtCOBatch.Text)
                txtCOBatch.Text = Trim(txtCOBatch.Text)
            End If

            Dim decimalLength As Integer
            decimalLength = KeepNo.ToString("D").Length + (9 - Len(CStr(KeepNo)))
            KeepIdent = KeepNo.ToString("D" + decimalLength.ToString())

            FileNameStr = ""
            FileNameStr = "LACI5_" + KeepIdent + ".txt"

            Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACI5\" + "LACI5" + "_" + KeepIdent + ".txt")

            For Each Row As DataGridViewRow In dgMPO.Rows
                TextFile.WriteLine(Row.Cells("LACData").Value)
            Next

            TextFile.Close()

            CmdExport.Enabled = False
            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "LACI5", KeepNo)

            CallClass.ExecuteUpdateSearchStr("cspUpdate_Invoices_I5", "")

            MsgBox("Action has been successfully completed.")
            dsMain.Clear()

            KeepNo = 0
            txtCOBatch.Text = ""

            sSource = "C:\LACTransferData\LACI5\" + FileNameStr
            sTarget = "\\dcapd01\Interfaces LAC\I5_IN\" + FileNameStr

            File.Copy(sSource, sTarget, True)

            MsgBox("FTP upload successfully done.")

        End If

        '=============

        If RdI6.Checked = True Then
            FindCOBatch()
            Me.Refresh()

            If txtCOBatch.Text = "ERROR" Then
                CmdSearch.Enabled = False
                CmdExport.Enabled = False
                Exit Sub
            Else
                CmdSearch.Enabled = True
                KeepNo = Val(txtCOBatch.Text)
                txtCOBatch.Text = Trim(txtCOBatch.Text)
            End If

            Dim decimalLength As Integer
            decimalLength = KeepNo.ToString("D").Length + (9 - Len(CStr(KeepNo)))
            KeepIdent = KeepNo.ToString("D" + decimalLength.ToString())

            FileNameStr = ""
            FileNameStr = "LACI6_" + KeepIdent + ".txt"

            Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACFinishGoods\" + "LACI6" + "_" + KeepIdent + ".txt")

            For Each Row As DataGridViewRow In dgMPO.Rows
                TextFile.WriteLine(Row.Cells("LACData").Value)
            Next

            TextFile.Close()

            CmdExport.Enabled = False

            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "LACI6", KeepNo)

            MsgBox("Action has been successfully completed.")
            dsMain.Clear()

            KeepNo = 0
            txtCOBatch.Text = ""


            sSource = "C:\LACTransferData\LACFinishGoods\" + FileNameStr
            sTarget = "\\dcapd01\Interfaces LAC\I6_IN\" + FileNameStr

            File.Copy(sSource, sTarget, True)

            MsgBox("FTP upload successfully done.")
       
        FileNameStr = ""

        End If

        '============

        If RdI9.Checked = True Then

            FileNameStr = ""
            FileNameStr = "lacorder" + ".csv"

            Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACI9\" + FileNameStr)

            TextFile.WriteLine("OrderNumber;OrderLineNumber;OrderDate;DelivQuantity;Price;Currency;LineStatus;AlliasNumber;Name;DeliveryDate;PlannedDate;CustOrdNumber;M3_CustCode;CustomerShortName;M3_ArticleCode;OrdItemQty")

            For Each Row As DataGridViewRow In dgMPO.Rows
                TextFile.WriteLine(Row.Cells("LACData").Value)
            Next

            TextFile.Close()

            CmdExport.Enabled = False

            MsgBox("Action has been successfully completed.")
            dsMain.Clear()

            '====

            sSource = "C:\LACTransferData\LACI9\" + FileNameStr
            sTarget = "\\Dcadwp01\lac\" + FileNameStr

            File.Copy(sSource, sTarget, True)

            MsgBox("FTP upload successfully done.")

            FileNameStr = ""

        End If

        '====

        If RdI99.Checked = True Then

            FileNameStr = ""
            FileNameStr = "LAC_DATA_CONTROL_DO" + ".csv"

            Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACI99\" + FileNameStr)

            TextFile.WriteLine("DO_Number;DO_Line_Number;DO_Date;Delivered_Quantity;Price;Currency;Line_Status;Name;Planned_Date;Warehouse;Item_Code")

            For Each Row As DataGridViewRow In dgMPO.Rows
                TextFile.WriteLine(Row.Cells("LACData").Value)
            Next

            TextFile.Close()

            CmdExport.Enabled = False

            MsgBox("Action has been successfully completed.")
            dsMain.Clear()

            KeepNo = 0
            txtCOBatch.Text = ""

            sSource = "C:\LACTransferData\LACI99\" + FileNameStr
            sTarget = "\\Dcadwp01\lac\" + FileNameStr

            File.Copy(sSource, sTarget, True)

            MsgBox("FTP upload successfully done.")

        End If


    End Sub

    Private Sub Upload(ByVal source As String, ByVal target As String, ByVal credential As Net.NetworkCredential)

        Dim request As Net.FtpWebRequest = DirectCast(Net.WebRequest.Create(target), Net.FtpWebRequest)

        request.Method = Net.WebRequestMethods.Ftp.UploadFile
        request.Credentials = credential
        request.Proxy = Nothing
        request.KeepAlive = False
        request.UsePassive = False

        Dim reader As New FileStream(source, FileMode.Open)
        Dim buffer(Convert.ToInt32(reader.Length - 1)) As Byte
        Dim objRequestStream As Stream = Nothing
        reader.Read(buffer, 0, buffer.Length)
        reader.Close()
        request.ContentLength = buffer.Length

        objRequestStream = request.GetRequestStream
        objRequestStream.Write(buffer, 0, buffer.Length)
        objRequestStream.Close()

        Dim response As Net.FtpWebResponse = DirectCast(request.GetResponse, Net.FtpWebResponse)
        MessageBox.Show(response.StatusDescription, "File Uploaded")
        response.Close()

    End Sub
    Private Sub CmbComp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CmdSearch.Enabled = False
        CmdExport.Enabled = False
        InitialComponents()
        FindCOBatch()
        Me.Refresh()
    End Sub

    Private Sub Rd2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdI2.CheckedChanged
        CmdSearch.Enabled = True
    End Sub

    Private Sub RdFP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdI6.CheckedChanged
        CmdSearch.Enabled = True
    End Sub

    Private Sub RdI5_CheckedChanged(sender As Object, e As System.EventArgs) Handles RdI5.CheckedChanged
        CmdSearch.Enabled = True
    End Sub

    Private Sub RdI9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdI9.CheckedChanged
        CmdSearch.Enabled = True
    End Sub

    Private Sub RdI99_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdI99.CheckedChanged
        CmdSearch.Enabled = True
    End Sub

    Private Sub frmAccUploadInvoicesintoM3_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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