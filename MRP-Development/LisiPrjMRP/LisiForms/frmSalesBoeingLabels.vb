Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSalesBoeingLabels

    Inherits System.Windows.Forms.Form


    Private Sub frmSalesBoeingLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcReadOnly()
        ProcUploadInterData()

    End Sub

    Sub ProcReadOnly()

        txtCustOrder.ReadOnly = True
        txtItemNo.ReadOnly = True
        txtMPO.ReadOnly = True

        txtItemName.ReadOnly = True
        txtCustPN.ReadOnly = True

        txtBoeingPO.ReadOnly = False
        txtBoeingLine.ReadOnly = True
        txtQty.ReadOnly = False


        txtPSlip.ReadOnly = True
        txtPNBCA.ReadOnly = True
        txtM3Item.ReadOnly = True

        txtFrom.ReadOnly = False
        txtTo.ReadOnly = False
        txtDelivNo.ReadOnly = False

    End Sub

    Sub ProcUploadInterData()

        txtNoBox.Text = 2

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintInter.Click

        If Len(Trim(txtQty.Text)) = 0 Then
            MsgBox("!!! ERROR Quantity !!!")
            Exit Sub
        End If

        If Len(Trim(txtBoeingPO.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Boeing PO#")
            Exit Sub
        End If

        If Len(Trim(txtPslipDate.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   -  Missing Packing Slip Date")
            Exit Sub
        End If

        'If Len(Trim(txtCopies.Text)) = 0 Then
        '    MsgBox("!!! ERROR !!! Missing Label Copies !!!")
        '    Exit Sub
        'End If

        Dim txtCustOrderCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtCustOrder As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtItemNoCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtItemNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtMPOCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMPO As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtItemNameCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtItemName As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtCustPNCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtCustPN As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtBoeingPOCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtBoeingPO As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtBoeingLineCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtBoeingLine As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtQtyCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim ttxtDateCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pptxtdate As New CrystalDecisions.Shared.ParameterDiscreteValue()


        Try
            Dim rptPO As New rptSalesBoeingLabels39Intermediere()
            rptPO.Load("..\rptSalesBoeingLabels39Intermediere.rpt")

            ptxtCustOrder.Value = Me.txtCustOrder.Text
            ptxtItemNo.Value = Me.txtItemNo.Text
            ptxtMPO.Value = Me.txtMPO.Text
            ptxtItemName.Value = Me.txtItemName.Text
            ptxtCustPN.Value = Me.txtCustPN.Text
            ptxtBoeingPO.Value = Me.txtBoeingPO.Text
            ptxtBoeingLine.Value = Me.txtBoeingLine.Text
            ptxtQty.Value = Me.txtQty.Text
            pptxtdate.Value = Me.txtPslipDate.Text

            txtCustOrderCollection.Add(ptxtCustOrder)
            txtItemNoCollection.Add(ptxtItemNo)
            txtMPOCollection.Add(ptxtMPO)
            txtItemNameCollection.Add(ptxtItemName)
            txtCustPNCollection.Add(ptxtCustPN)
            txtBoeingPOCollection.Add(ptxtBoeingPO)
            txtBoeingLineCollection.Add(ptxtBoeingLine)
            txtQtyCollection.Add(ptxtQty)
            ttxtDateCollection.Add(pptxtdate).ToString()

            rptPO.DataDefinition.ParameterFields("@txtCustOrder").ApplyCurrentValues(txtCustOrderCollection)
            rptPO.DataDefinition.ParameterFields("@txtItemNo").ApplyCurrentValues(txtItemNoCollection)
            rptPO.DataDefinition.ParameterFields("@txtMPO").ApplyCurrentValues(txtMPOCollection)
            rptPO.DataDefinition.ParameterFields("@txtItemName").ApplyCurrentValues(txtItemNameCollection)
            rptPO.DataDefinition.ParameterFields("@txtCustPN").ApplyCurrentValues(txtCustPNCollection)
            rptPO.DataDefinition.ParameterFields("@txtBoeingPO").ApplyCurrentValues(txtBoeingPOCollection)
            rptPO.DataDefinition.ParameterFields("@txtBoeingLine").ApplyCurrentValues(txtBoeingLineCollection)
            rptPO.DataDefinition.ParameterFields("@txtQty").ApplyCurrentValues(txtQtyCollection)
            rptPO.DataDefinition.ParameterFields("@txtPslipDate").ApplyCurrentValues(ttxtDateCollection)


            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True

            frmPOMasterPrint.ShowDialog()


            'rptPO.PrintToPrinter(txtCopies.Text, True, 0, 1)


        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Private Sub CmdPrintCont_Click(sender As System.Object, e As System.EventArgs) Handles CmdPrintCont.Click

        If Len(Trim(txtNoBox.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing -  Container: Box(s) Number")
            Exit Sub
        End If

        If Len(Trim(txtTotalQty.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing - Container: Total Qty")
            Exit Sub
        End If

        If Len(Trim(txtFrom.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing Label# FROM")
            Exit Sub
        End If

        If Len(Trim(txtTo.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing Label# TO")
            Exit Sub
        End If

        If CInt(txtFrom.Text) > CInt(txtTo.Text) Then
            MsgBox("!!! ERROR !!!  FROM should be less or equal with TO")
            Exit Sub
        End If

        If Len(Trim(txtDelivNo.Text)) = 0 Then
            MsgBox("!!! ERROR Delivery# !!!")
            Exit Sub
        End If

        If Len(Trim(txtPNBCA.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   -  Missing Part Number")
            Exit Sub
        End If

        If Len(Trim(txtPslipDate.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   -  Missing Packing Slip Date")
            Exit Sub
        End If

        Dim txtPSlipCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtPSlip As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtPNBCACollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtPNBCA As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtM3ItemCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtM3Item As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtDelivNoCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtDelivNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtCustNameCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtCustName As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtWSHECollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtWSHE As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtBoxNoCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtBoxNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtFromCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtFrom As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtTOCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtTO As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim ttxtDateCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pptxtdate As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtNoBoxCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtNoBox As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtTotalQtyCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtTotalQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptSalesBoeingLabels39Container()
            rptPO.Load("..\rptSalesBoeingLabels39Container.rpt")

            ptxtPSlip.Value = Me.txtPSlip.Text
            ptxtPNBCA.Value = Me.txtPNBCA.Text
            ptxtM3Item.Value = Me.txtM3Item.Text
            ptxtDelivNo.Value = Me.txtDelivNo.Text
            ptxtCustName.Value = Me.txtCustName.Text
            ptxtWSHE.Value = Me.txtWSHE.Text
            ptxtFrom.Value = Me.txtFrom.Text
            ptxtTO.Value = Me.txtTo.Text
            pptxtdate.Value = Me.txtPslipDate.Text
            ptxtNoBox.Value = Me.txtNoBox.Text
            ptxtTotalQty.Value = Me.txtTotalQty.Text

            txtPSlipCollection.Add(ptxtPSlip)
            txtPNBCACollection.Add(ptxtPNBCA)
            txtM3ItemCollection.Add(ptxtM3Item)
            txtDelivNoCollection.Add(ptxtDelivNo)
            txtCustNameCollection.Add(ptxtCustName)
            txtWSHECollection.Add(ptxtWSHE)
            txtFromCollection.Add(ptxtFrom)
            txtTOCollection.Add(ptxtTO)
            ttxtDateCollection.Add(pptxtdate)
            txtNoBoxCollection.Add(ptxtNoBox)
            txtTotalQtyCollection.Add(ptxtTotalQty)

            rptPO.DataDefinition.ParameterFields("@txtPSlip").ApplyCurrentValues(txtPSlipCollection)
            rptPO.DataDefinition.ParameterFields("@txtPNBCA").ApplyCurrentValues(txtPNBCACollection)
            rptPO.DataDefinition.ParameterFields("@txtM3Item").ApplyCurrentValues(txtM3ItemCollection)
            rptPO.DataDefinition.ParameterFields("@txtDelivNo").ApplyCurrentValues(txtDelivNoCollection)
            rptPO.DataDefinition.ParameterFields("@txtCustName").ApplyCurrentValues(txtCustNameCollection)
            rptPO.DataDefinition.ParameterFields("@txtWSHE").ApplyCurrentValues(txtWSHECollection)
            'rptPO.DataDefinition.ParameterFields("@txtWSHE").ApplyCurrentValues(txtWSHECollection)
            rptPO.DataDefinition.ParameterFields("@txtFrom").ApplyCurrentValues(txtFromCollection)
            rptPO.DataDefinition.ParameterFields("@txtTO").ApplyCurrentValues(txtTOCollection)
            rptPO.DataDefinition.ParameterFields("@txtPslipDate").ApplyCurrentValues(ttxtDateCollection)

            rptPO.DataDefinition.ParameterFields("@txtNoBox").ApplyCurrentValues(txtNoBoxCollection)
            rptPO.DataDefinition.ParameterFields("@txtTotalQty").ApplyCurrentValues(txtTotalQtyCollection)


            'rptPO.PrintToPrinter(1, True, 0, 1)


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

    Private Sub txtPslipDate_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPslipDate.TextChanged

    End Sub
End Class