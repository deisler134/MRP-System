Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Text

Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.IO


Public Class frmAccUploadCorpData

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim KeepNo As Integer = 0

    Dim KeepIdent As String
    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""

    Private Sub frmAccUploadCorpData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmAccUploadCorpData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        ClearFields()

        InitialComponents()

        SetCtlForm()

        CmdSearch.Enabled = True
        CmdExport.Enabled = False
        CmdClear.Enabled = True

    End Sub

    Sub ClearFields()

        txtWIPGross.Text = 0
        txtWIPSalesValue.Text = 0
        txtRMGross.Text = 0
        txtFGStockGross.Text = 0
        txtFGStdGross.Text = 0
        txtFGLNAGross.Text = 0
        txtLACTotalValue.Text = 0
        txtFGsLACAdj2.Text = 0
        txtFGsLNAAdj2.Text = 0
        txtFGsLACFinalTotal.Text = 0
        txtFGsLNAFinalTotal.Text = 0
        txtWIPGrossAdj.Text = 0
        txtWIPFinalTotal.Text = 0
        txtWIPFinalTotal.Text = 0
        txtRMGrossAdj.Text = 0
        txtRMFinalTotal.Text = 0

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccUpload_Corp_WIP_Empty").Fill(dsMain, "tblSelect")
        'CallClass.PopulateDataAdapter("getAccUpload_Corp_RM_Empty").Fill(dsMain, "tblSelect")
        'CallClass.PopulateDataAdapter("getAccUpload_FP_I6_IntoM3Empty").Fill(dsMain, "tblSelect")
        'CallClass.PopulateDataAdapter("getAccUpload_COs_I9_IntoDWHEmpty").Fill(dsMain, "tblSelect")
        'CallClass.PopulateDataAdapter("getAccUpload_DOs_I99_IntoM3Empty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgCalcul.AutoGenerateColumns = False
        dgCalcul.DataSource = dsMain
        dgCalcul.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()

        With Me.LACData
            .DataPropertyName = "LACData"
            .Name = "LACData"
        End With



        With Me.WIPStockName
            .DataPropertyName = "WIPStockName"
            .Name = "WIPStockName"
        End With

        With Me.WIPGrossValue
            .DataPropertyName = "WIPGrossValue"
            .Name = "WIPGrossValue"
        End With

        With Me.WIPValue
            .DataPropertyName = "WIPValue"
            .Name = "WIPValue"

        End With

        With Me.RMStockName
            .DataPropertyName = "RMStockName"
            .Name = "RMStockName"
        End With

        With Me.RMGrossValue
            .DataPropertyName = "RMGrossValue"
            .Name = "RMGrossValue"
        End With

        With Me.RMValue
            .DataPropertyName = "RMValue"
            .Name = "RMValue"
        End With


        ' dgcalcul

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.DeptPer
            .DataPropertyName = "DeptPer"
            .Name = "DeptPer"
        End With

        With Me.MpoWeight
            .DataPropertyName = "MpoWeight"
            .Name = "MpoWeight"
        End With

        With Me.FinalStpoPrice
            .DataPropertyName = "FinalStpoPrice"
            .Name = "FinalStpoPrice"
        End With

        With Me.StDevise
            .DataPropertyName = "StDevise"
            .Name = "StDevise"
        End With

        With Me.SwRateMonth
            .DataPropertyName = "SwRateMonth"
            .Name = "SwRateMonth"
        End With

        With Me.SwRateMatl
            .DataPropertyName = "SwRateMatl"
            .Name = "SwRateMatl"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MatlValCdn
            .DataPropertyName = "MatlValCdn"
            .Name = "MatlValCdn"
        End With

        With Me.SwRMBlanksCost
            .DataPropertyName = "SwRMBlanksCost"
            .Name = "SwRMBlanksCost"
        End With


        With Me.WipValPerDetail
            .DataPropertyName = "WipValPerDetail"
            .Name = "WipValPerDetail"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.MPONo
            .DataPropertyName = "MPONo"
            .Name = "MPONo"
        End With

        '======rm

        With Me.StDeprPer
            .DataPropertyName = "StDeprPer"
            .Name = "StDeprPer"
        End With
        With Me.StPrice
            .DataPropertyName = "StPrice"
            .Name = "StPrice"
        End With

        With Me.RMSwRateMonth
            .DataPropertyName = "RMSwRateMonth"
            .Name = "RMSwRateMonth"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.RMValCdn
            .DataPropertyName = "RMValCdn"
            .Name = "RMValCdn"
        End With

        ' ====================FG Std Price

        With Me.FGStdPrSwRateMonth
            .DataPropertyName = "FGStdPrSwRateMonth"
            .Name = "FGStdPrSwRateMonth"
        End With

        With Me.FGStdPrStPrice
            .DataPropertyName = "FGStdPrStPrice"
            .Name = "FGStdPrStPrice"
        End With

        With Me.FGStdPrStFinal
            .DataPropertyName = "FGStdPrStFinal"
            .Name = "FGStdPrStFinal"
        End With

        With Me.FGStdPrValCdn
            .DataPropertyName = "FGStdPrValCdn"
            .Name = "FGStdPrValCdn"
        End With

        ' ====================FG stock Price

        With Me.FGStockPrRMVal
            .DataPropertyName = "FGStockPrRMVal"
            .Name = "FGStockPrRMVal"
        End With

        With Me.FGStockPrStPrice
            .DataPropertyName = "FGStockPrStPrice"
            .Name = "FGStockPrStPrice"
        End With

        With Me.FGStockPRQtyEngReleased
            .DataPropertyName = "FGStockPRQtyEngReleased"
            .Name = "FGStockPRQtyEngReleased"
        End With

        With Me.PrRawMatl
            .DataPropertyName = "PrRawMatl"
            .Name = "PrRawMatl"
        End With

        With Me.FGStockPRSwRawMatlMonth
            .DataPropertyName = "FGStockPRSwRawMatlMonth"
            .Name = "FGStockPRSwRawMatlMonth"
        End With

        With Me.FGStockPRStFinal
            .DataPropertyName = "FGStockPRStFinal"
            .Name = "FGStockPRStFinal"
        End With

        With Me.TotRawMatl
            .DataPropertyName = "TotRawMatl"
            .Name = "TotRawMatl"
        End With

        With Me.FGStockPrLotValue
            .DataPropertyName = "FGStockPrLotValue"
            .Name = "FGStockPrLotValue"
        End With

        With Me.FGStockPRStDate
            .DataPropertyName = "FGStockPRStDate"
            .Name = "FGStockPRStDate"
        End With

        With Me.FGStockPRSwRateMonth
            .DataPropertyName = "FGStockPRSwRateMonth"
            .Name = "FGStockPRSwRateMonth"
        End With

        '===============LNA

        With Me.FGLNAStFinal
            .DataPropertyName = "FGLNAStFinal"
            .Name = "FGLNAStFinal"
        End With

        With Me.FGLNAStPrice
            .DataPropertyName = "FGLNAStPrice"
            .Name = "FGLNAStPrice"
        End With

        With Me.FGLNASwRateMonth
            .DataPropertyName = "FGLNASwRateMonth"
            .Name = "FGLNASwRateMonth"
        End With

        With Me.FGLNAStValue
            .DataPropertyName = "FGLNAStValue"
            .Name = "FGLNAStValue"
        End With

    End Sub

    Private Sub CmdSearch_Click(sender As Object, e As EventArgs) Handles CmdSearch.Click
        Me.Cursor = Cursors.WaitCursor


        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        '=======

        CallClass.PopulateDataAdapter("getAccUpload_Corp_WIP").Fill(dsMain, "tblSelect")
        If dgCalcul.RowCount > 0 Then
            CmdExport.Enabled = True
            PutWIP()
        Else
            MsgBox("No WIP data found after search")
        End If

        '========

        CallClass.PopulateDataAdapter("getAccUpload_Corp_RM").Fill(dsMain, "tblSelect")
        If dgCalcul.RowCount > 0 Then
            CmdExport.Enabled = True
            PutRM()
        Else
            MsgBox("No RM data found after search")
        End If

        '========

        CallClass.PopulateDataAdapter("getAccUpload_Corp_FGStandardPrice").Fill(dsMain, "tblSelect")
        If dgCalcul.RowCount > 0 Then
            CmdExport.Enabled = True
            PutFGStdPrice()
        Else
            MsgBox("No FG Standard Price data found after search")
        End If



        '========

        CallClass.PopulateDataAdapter("getAccUpload_Corp_FGStockPrice").Fill(dsMain, "tblSelect")
        If dgCalcul.RowCount > 0 Then
            CmdExport.Enabled = True
            PutFGStockPrice()
        Else
            MsgBox("No FG Standard Price data found after search")
        End If

        Me.Cursor = Cursors.Default

        '========

        CallClass.PopulateDataAdapter("getAccUpload_Corp_FG_LNA").Fill(dsMain, "tblSelect")
        If dgCalcul.RowCount > 0 Then
            CmdExport.Enabled = True
            PutFGLNA()
        Else
            MsgBox("No FG LNA data found after search")
        End If



        Dim GrossVal As Double = 0.0
        GrossVal = 0.0
        txtFGsLACAdj2.Text = GrossVal.ToString("C2")
        txtFGsLNAAdj2.Text = GrossVal.ToString("C2")
        txtWIPGrossAdj.Text = GrossVal.ToString("C2")
        txtRMGrossAdj.Text = GrossVal.ToString("C2")

        'WIP
        GrossVal = CDbl(txtWIPGross.Text)
        txtWIPFinalTotal.Text = GrossVal.ToString("C2")

        'RM
        GrossVal = CDbl(txtRMGross.Text)
        txtRMFinalTotal.Text = GrossVal.ToString("C2")

        'FG
        GrossVal = CDbl(txtFGStockGross.Text)
        GrossVal = GrossVal + CDbl(txtFGStdGross.Text)
        txtLACTotalValue.Text = GrossVal.ToString("C2")
        txtFGsLACFinalTotal.Text = GrossVal.ToString("C2")

        'LNA
        GrossVal = CDbl(txtFGLNAGross.Text)
        txtFGsLNAFinalTotal.Text = GrossVal.ToString("C2")

    End Sub


    Sub PutFGLNA()

        '===== Gross Value

        'calculate matl vale and is the same as WIP RM Value
        For Each Row As DataGridViewRow In dgCalcul.Rows
            Row.Cells("FGLNAStValue").Value = Math.Round(Nz.Nz(Row.Cells("FGLNAStPrice").Value) * Nz.Nz(Row.Cells("FGLNASwRateMonth").Value) * Nz.Nz(Row.Cells("FGLNAStFinal").Value), 2)
        Next

        Dim GrossVal As Double = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("FGLNAStValue").Value)
        Next
        txtFGLNAGross.Text = GrossVal.ToString("C2")

    End Sub

    Sub PutFGStockPrice()

        '===== Gross Value

        For Each Row As DataGridViewRow In dgCalcul.Rows
            If Nz.Nz(Row.Cells("FGStockPrStPrice").Value) < 1 Then
                Row.Cells("FGStockPrRMVal").Value = 0
            Else
                If Nz.Nz(Row.Cells("FGStockPRQtyEngReleased").Value) = 0 Then
                    Row.Cells("FGStockPrRMVal").Value = 0
                Else
                    If Nz.Nz(Row.Cells("FGStockPRQtyEngReleased").Value) * Nz.Nz(Row.Cells("FGStockPRSwRawMatlMonth").Value) * Nz.Nz(Row.Cells("PrRawMatl").Value) * Nz.Nz(Row.Cells("FGStockPRStFinal").Value) = 0 Then
                        Row.Cells("FGStockPrRMVal").Value = 0
                    Else
                        Row.Cells("FGStockPrRMVal").Value = (Nz.Nz(Row.Cells("TotRawMatl").Value) / Nz.Nz(Row.Cells("FGStockPRQtyEngReleased").Value)) * (Nz.Nz(Row.Cells("FGStockPRSwRawMatlMonth").Value) * Nz.Nz(Row.Cells("PrRawMatl").Value) * Nz.Nz(Row.Cells("FGStockPRStFinal").Value))
                    End If
                End If
            End If
        Next

        'calculate Lot\ value 

        Dim DateStock As Date

        For Each Row As DataGridViewRow In dgCalcul.Rows

            If IsDBNull(Row.Cells("FGStockPRStDate").Value) = True Then
                GoTo NextOperLot
            End If

            If IsNothing(Row.Cells("FGStockPRStDate").Value) = True Then
                GoTo NextOperLot
            End If

            DateStock = Row.Cells("FGStockPRStDate").Value
            If Year(Now()) - Year(DateStock) >= 8 Then
                Row.Cells("FGStockPrLotValue").Value = 0.01
            Else
                If Nz.Nz(Row.Cells("FGStockPrStPrice").Value) > 0.01 Then
                    Row.Cells("FGStockPrLotValue").Value = (((Nz.Nz(Row.Cells("FGStockPRStFinal").Value) * Nz.Nz(Row.Cells("FGStockPrStPrice").Value) * Nz.Nz(Row.Cells("FGStockPRSwRateMonth").Value)) - Nz.Nz(Row.Cells("FGStockPrRMVal").Value)) * 50 / 100) + Nz.Nz(Row.Cells("FGStockPrRMVal").Value)
                Else
                    Row.Cells("FGStockPrLotValue").Value = 0

                End If
            End If

NextOperLot:
        Next

        Dim GrossVal As Double = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("FGStockPrLotValue").Value)
        Next
        txtFGStockGross.Text = GrossVal.ToString("C2")

    End Sub

    Sub PutFGStdPrice()

        '===== Gross Value

        'calculate matl vale and is the same as WIP RM Value
        For Each Row As DataGridViewRow In dgCalcul.Rows
            Row.Cells("FGStdPrValCdn").Value = Math.Round(Nz.Nz(Row.Cells("FGStdPrStPrice").Value) * Nz.Nz(Row.Cells("FGStdPrSwRateMonth").Value) * Nz.Nz(Row.Cells("FGStdPrStFinal").Value), 2)
        Next

        Dim GrossVal As Double = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("FGStdPrValCdn").Value)
        Next
        txtFGStdGross.Text = GrossVal.ToString("C2")

    End Sub

    Sub PutRM()

        '===== Gross Value

        'calculate matl vale and is the same as WIP RM Value
        For Each Row As DataGridViewRow In dgCalcul.Rows
            If Nz.Nz(Row.Cells("StDeprPer").Value) = 100 Then
                Row.Cells("RMValCdn").Value = 0
            Else
                Row.Cells("RMValCdn").Value = Math.Round(Nz.Nz(Row.Cells("StPrice").Value) * Nz.Nz(Row.Cells("RMSwRateMonth").Value) * Nz.Nz(Row.Cells("StFinal").Value), 2)
            End If
        Next

        Dim GrossVal As Double = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("RMValCdn").Value)
        Next
        txtRMGross.Text = GrossVal.ToString("C2")

    End Sub


    Sub PutWip()

        '=====   

        'calculate matl vale and is the same as WIP RM Value
        For Each Row As DataGridViewRow In dgCalcul.Rows
            If Row.Cells("MPOType").Value = "Standard (RM NULL)" Then
                Row.Cells("MatlValCdn").Value = 0
            Else
                If Row.Cells("MPOWeight").Value = 0 Then
                    If Row.Cells("DeptPer").Value = 0 Then
                        Row.Cells("MatlValCdn").Value = 0
                    Else
                        Row.Cells("MatlValCdn").Value = ((Nz.Nz(Row.Cells("SwRMBlanksCost").Value) + (1 * Nz.Nz(Row.Cells("SwRateMonth").Value))) * Nz.Nz(Row.Cells("QtyEngReleased").Value))
                    End If
                Else
                    Row.Cells("MatlValCdn").Value = (Nz.Nz(Row.Cells("MpoWeight").Value) * Nz.Nz(Row.Cells("FinalStpoPrice").Value) * Nz.Nz(Row.Cells("SwRateMatl").Value))
                    'FinalStpoPrice   = dbo.tblStockRawMatl.StPoPrice  +  dbo.tblStockRawMatl.StRmsPoPrice
                End If
            End If
        Next


        'calculate sales value and is the same value as in WIP
        For Each Row As DataGridViewRow In dgCalcul.Rows
            Row.Cells("DeptValue").Value = Nz.Nz(Row.Cells("QtyActual").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value) * Nz.Nz(Row.Cells("SwRateMonth").Value)
        Next

        '   if {getPrintWipSummary;1.MpoType} = "Min/Max" then
        '//({getPrintWipSummary;1.QtyActual}*{getPrintWipSummary;1.OrdItemPrice}*{getPrintWipSummary;1.SwRateMonth}) + {@MatlValCdn}
        '({getPrintWipSummary;1.QtyActual}*{getPrintWipSummary;1.OrdItemPrice}*{getPrintWipSummary;1.SwRateMonth}) 
        '    Else
        '({getPrintWipSummary;1.QtyActual}*{getPrintWipSummary;1.OrdItemPrice}*{getPrintWipSummary;1.SwRateMonth})


        '        if {@SalesValCDN} = 0 and  {@MatlValCDN} <> 0 then
        '    {@MatlValCDN}
        '        Else
        '    if {getPrintWipDetail;1.DeptPer} = 0 then
        '0:
        '            Else
        '        if {getPrintWipDetail;1.MpoType} = "Testing"  then
        '0:
        '                Else
        '            if {getPrintWipDetail;1.MpoType} = "RND"   then
        '0:
        '                    Else
        '                if {getPrintWipDetail;1.MpoType} = "Qualification"   then
        '0:
        '                        Else
        '                    if {getPrintWipDetail;1.MpoType} = "Quarantine"   then
        '0:
        '                            Else
        '                        if {@SalesValCDN} - {@MatlValCDN} <=0 then
        '                            {@MatlValCDN}
        '                                Else
        '                            (((((({@SalesValCDN}-{@MatlValCDN})*{getPrintWipDetail;1.DeptPer})/100)*{?@CostPer})/100)+{@MatlValCDN})


        For Each Row As DataGridViewRow In dgCalcul.Rows
            If Trim(Row.Cells("MpoType").Value) = "Testing" Then
                Row.Cells("WipValPerDetail").Value = 0
                GoTo NextOper
            End If

            If Trim(Row.Cells("MpoType").Value) = "RND" Then
                Row.Cells("WipValPerDetail").Value = 0
                GoTo NextOper
            End If

            If Trim(Row.Cells("MpoType").Value) = "Qualification" Then
                Row.Cells("WipValPerDetail").Value = 0
                GoTo NextOper
            End If

            If Nz.Nz(Row.Cells("DeptValue").Value) = 0 And Nz.Nz(Row.Cells("MatlValCdn").Value) <> 0 Then
                Row.Cells("WipValPerDetail").Value = Nz.Nz(Row.Cells("MatlValCdn").Value)
                GoTo NextOper
            End If

            If Nz.Nz(Row.Cells("DeptPer").Value) = 0 Then
                Row.Cells("WipValPerDetail").Value = 0
                GoTo NextOper
            End If

            If Nz.Nz(Row.Cells("DeptValue").Value) - Nz.Nz(Row.Cells("MatlValCDN").Value) <= 0 Then
                If Trim(Row.Cells("MPOType").Value) = "Min/Max" Then
                    Row.Cells("WipValPerDetail").Value = ((Nz.Nz(Row.Cells("DeptValue").Value) * Nz.Nz(Row.Cells("DeptPer").Value)) / 100) + Nz.Nz(Row.Cells("MatlValCDN").Value)
                Else
                    Row.Cells("WipValPerDetail").Value = Nz.Nz(Row.Cells("MatlValCDN").Value)
                End If
                GoTo NextOper
            End If

            If Trim(Row.Cells("MPOType").Value) = "Min/Max" Then
                Row.Cells("WipValPerDetail").Value = ((Nz.Nz(Row.Cells("DeptValue").Value) * Nz.Nz(Row.Cells("DeptPer").Value)) / 100) + Nz.Nz(Row.Cells("MatlValCDN").Value)
            Else
                Row.Cells("WipValPerDetail").Value = (((Nz.Nz(Row.Cells("DeptValue").Value) - Nz.Nz(Row.Cells("MatlValCDN").Value)) * Nz.Nz(Row.Cells("DeptPer").Value) / 100 * 50 / 100) + Nz.Nz(Row.Cells("MatlValCDN").Value))
            End If
NextOper:
        Next

        Dim GrossVal As Double = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("WipValPerDetail").Value)
        Next
        txtWIPGross.Text = GrossVal.ToString("C2")

        ' Gross Value
        '===============

        GrossVal = 0.0
        For Each Row As DataGridViewRow In dgCalcul.Rows
            GrossVal = GrossVal + CDbl(Row.Cells("DeptValue").Value)
        Next
        txtWIPSalesValue.Text = GrossVal.ToString("C2")

    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        ClearFields()

        InitialComponents()

        CmdSearch.Enabled = True
        CmdExport.Enabled = False
        CmdClear.Enabled = True

    End Sub

    Private Sub txtFGsLACAdj2_Validated(sender As Object, e As EventArgs) Handles txtFGsLACAdj2.Validated

        If IsNumeric(txtFGsLACAdj2.Text) = False Then
            MsgBox("!!! ERROR !!! FGs LAC Adj. is not numeric")
            CmdExport.Enabled = False
        Else
            CmdExport.Enabled = True
            Dim GrossVal As Double = 0.0
            GrossVal = CDbl(txtFGsLACAdj2.Text)
            txtFGsLACAdj2.Text = GrossVal.ToString("C2")
            txtFGsLACFinalTotal.Text = (CDbl(txtLACTotalValue.Text) + GrossVal).ToString("C2")
        End If

    End Sub

    Private Sub txtFGsLNAAdj2_Validated(sender As Object, e As EventArgs) Handles txtFGsLNAAdj2.Validated

        If IsNumeric(txtFGsLNAAdj2.Text) = False Then
            MsgBox("!!! ERROR !!! FG LNA Adj. is not numeric")
            CmdExport.Enabled = False
        Else
            CmdExport.Enabled = True
            Dim GrossVal As Double = 0.0
            GrossVal = CDbl(txtFGsLNAAdj2.Text)
            txtFGsLNAAdj2.Text = GrossVal.ToString("C2")
            txtFGsLNAFinalTotal.Text = (CDbl(txtFGLNAGross.Text) + GrossVal).ToString("C2")
        End If

    End Sub

    Private Sub txtWIPGrossAdj_Validated(sender As Object, e As EventArgs) Handles txtWIPGrossAdj.Validated

        If IsNumeric(txtWIPGrossAdj.Text) = False Then
            MsgBox("!!! ERROR !!! WIP LAC Adj. is not numeric")
            CmdExport.Enabled = False
        Else
            CmdExport.Enabled = True
            Dim GrossVal As Double = 0.0
            GrossVal = CDbl(txtWIPGrossAdj.Text)
            txtWIPGrossAdj.Text = GrossVal.ToString("C2")
            txtWIPFinalTotal.Text = (CDbl(txtWIPGross.Text) + GrossVal).ToString("C2")
        End If

    End Sub

    Private Sub txtRMGrossAdj_Validated(sender As Object, e As EventArgs) Handles txtRMGrossAdj.Validated

        If IsNumeric(txtRMGrossAdj.Text) = False Then
            MsgBox("!!! ERROR !!! RM LAC Adj. is not numeric")
            CmdExport.Enabled = False
        Else
            CmdExport.Enabled = True
            Dim GrossVal As Double = 0.0
            GrossVal = CDbl(txtRMGrossAdj.Text)
            txtRMGrossAdj.Text = GrossVal.ToString("C2")
            txtRMFinalTotal.Text = (CDbl(txtRMGross.Text) + GrossVal).ToString("C2")
        End If

    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click

        FileNameStr = ""
        FileNameStr = "LACInventoriesData" + ".csv"

        Dim ListText As String

        Dim TextFile As New IO.StreamWriter("C:\LACTransferData\LACINV\" + FileNameStr)

        TextFile.WriteLine("Inventory_Type;Inventory_Gross_Value;Date_Extraction")

        ListText = "WIP_Inventory;" + Trim(Str(CDbl(txtWIPFinalTotal.Text).ToString("N0"))) + ";" + Now.ToShortDateString
        TextFile.WriteLine(ListText)

        ListText = "RM_Inventory;" + Trim(Str(CDbl(txtRMFinalTotal.Text).ToString("N0"))) + ";" + Now.ToShortDateString
        TextFile.WriteLine(ListText)

        ListText = "LAC_FG_Inventory;" + Trim(Str(CDbl(txtFGsLACFinalTotal.Text).ToString("N0"))) + ";" + Now.ToShortDateString
        TextFile.WriteLine(ListText)

        ListText = "LNA_Transfered_Inventory;" + Trim(Str(CDbl(txtFGsLNAFinalTotal.Text).ToString("N0"))) + ";" + Now.ToShortDateString
        TextFile.WriteLine(ListText)

        TextFile.Close()

        CmdExport.Enabled = False

        MsgBox("Action has been successfully completed.")
        dsMain.Clear()

        '====

        sSource = "C:\LACTransferData\LACINV\" + FileNameStr
        sTarget = "\\Dcadwp01\lac\" + FileNameStr

        File.Copy(sSource, sTarget, True)

        MsgBox("FTP upload successfully done.")

        FileNameStr = ""

    End Sub

End Class