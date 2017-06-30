Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSalesPslipBarCodeLabels

    Inherits System.Windows.Forms.Form


    Private Sub frmSalesPslipBarCodeLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ShipTel.Text = ""

        If frmSalesPSlip.RdPDF417.Checked = True Then
            If InStr(ShipName.Text, "Meggitt", vbTextCompare) <> 0 Then
                ShipTel.Text = "330-796-4400"
            End If
        Else
            ShipTel.Text = ""
        End If

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        '=======================  MEGIT ==============================
        If frmSalesPSlip.RdPDF417.Checked = True Then

            Dim ShipNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShiptextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShiptext As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCountryCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipTelCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipTel As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromText As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCountryCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTelCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromTel As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtCustOrderCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtCustOrder As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtItemNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtItemNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtViaNotesCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtViaNotes As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPartNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPartNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPSlipQtyCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPSlipQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtMPOCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtMPO As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtMpoCloseDateCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtMpoCloseDate As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtNoBoxCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtNoBox As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtBarCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtBarCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Try
                Dim rptPO As New rptSalesPslipBarCodeLabels()
                rptPO.Load("..\rptSalesPslipBarCodeLabels.rpt")

                pShipName.Value = Me.ShipName.Text
                pShiptext.Value = Me.Shiptext.Text
                pShipAddress.Value = Me.ShipAddress.Text
                pShipCity.Value = Me.ShipCity.Text
                pShipProv.Value = Me.ShipProv.Text
                pShipCode.Value = Me.ShipCode.Text
                pShipCountry.Value = Me.ShipCountry.Text
                pShipTel.Value = Me.ShipTel.Text
                pFromName.Value = Me.FromName.Text
                pFromText.Value = Me.FromText.Text
                pFromAddress.Value = Me.FromAddress.Text
                pFromCity.Value = Me.FromCity.Text
                pFromProv.Value = Me.FromProv.Text
                pFromCode.Value = Me.FromCode.Text
                pFromCountry.Value = Me.FromCountry.Text
                pFromTel.Value = Me.FromTel.Text
                ptxtCustOrder.Value = Me.txtCustOrder.Text
                ptxtItemNo.Value = Me.txtItemNo.Text
                ptxtViaNotes.Value = Me.txtViaNotes.Text
                ptxtPartNo.Value = Me.txtPartNo.Text
                ptxtPSlipQty.Value = Me.txtPSlipQty.Text
                ptxtMPO.Value = Me.txtMPO.Text
                ptxtMpoCloseDate.Value = Me.txtMpoCloseDate.Text
                ptxtNoBox.Value = Me.txtNoBox.Text
                ptxtBarCode.Value = Me.txtBarCode.Text

                ShipNameCollection.Add(pShipName)
                ShiptextCollection.Add(pShiptext)
                ShipAddressCollection.Add(pShipAddress)
                ShipCityCollection.Add(pShipCity)
                ShipProvCollection.Add(pShipProv)
                ShipCodeCollection.Add(pShipCode)
                ShipCountryCollection.Add(pShipCountry)
                ShipTelCollection.Add(pShipTel)
                FromNameCollection.Add(pFromName)
                FromTextCollection.Add(pFromText)
                FromAddressCollection.Add(pFromAddress)
                FromCityCollection.Add(pFromCity)
                FromProvCollection.Add(pFromProv)
                FromCodeCollection.Add(pFromCode)
                FromCountryCollection.Add(pFromCountry)
                FromTelCollection.Add(pFromTel)
                txtCustOrderCollection.Add(ptxtCustOrder)
                txtItemNoCollection.Add(ptxtItemNo)
                txtViaNotesCollection.Add(ptxtViaNotes)
                txtPartNoCollection.Add(ptxtPartNo)
                txtPSlipQtyCollection.Add(ptxtPSlipQty)
                txtMPOCollection.Add(ptxtMPO)
                txtMpoCloseDateCollection.Add(ptxtMpoCloseDate)
                txtNoBoxCollection.Add(ptxtNoBox)
                txtBarCodeCollection.Add(ptxtBarCode)

                rptPO.DataDefinition.ParameterFields("@ShipName").ApplyCurrentValues(ShipNameCollection)
                rptPO.DataDefinition.ParameterFields("@Shiptext").ApplyCurrentValues(ShiptextCollection)
                rptPO.DataDefinition.ParameterFields("@ShipAddress").ApplyCurrentValues(ShipAddressCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCity").ApplyCurrentValues(ShipCityCollection)
                rptPO.DataDefinition.ParameterFields("@ShipProv").ApplyCurrentValues(ShipProvCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCode").ApplyCurrentValues(ShipCodeCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCountry").ApplyCurrentValues(ShipCountryCollection)
                rptPO.DataDefinition.ParameterFields("@ShipTel").ApplyCurrentValues(ShipTelCollection)
                rptPO.DataDefinition.ParameterFields("@FromName").ApplyCurrentValues(FromNameCollection)
                rptPO.DataDefinition.ParameterFields("@FromText").ApplyCurrentValues(FromTextCollection)
                rptPO.DataDefinition.ParameterFields("@FromAddress").ApplyCurrentValues(FromAddressCollection)
                rptPO.DataDefinition.ParameterFields("@FromCity").ApplyCurrentValues(FromCityCollection)
                rptPO.DataDefinition.ParameterFields("@FromProv").ApplyCurrentValues(FromProvCollection)
                rptPO.DataDefinition.ParameterFields("@FromCode").ApplyCurrentValues(FromCodeCollection)
                rptPO.DataDefinition.ParameterFields("@FromCountry").ApplyCurrentValues(FromCountryCollection)
                rptPO.DataDefinition.ParameterFields("@FromTel").ApplyCurrentValues(FromTelCollection)
                rptPO.DataDefinition.ParameterFields("@txtCustOrder").ApplyCurrentValues(txtCustOrderCollection)
                rptPO.DataDefinition.ParameterFields("@txtItemNo").ApplyCurrentValues(txtItemNoCollection)
                rptPO.DataDefinition.ParameterFields("@txtViaNotes").ApplyCurrentValues(txtViaNotesCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartNo").ApplyCurrentValues(txtPartNoCollection)
                rptPO.DataDefinition.ParameterFields("@txtPSlipQty").ApplyCurrentValues(txtPSlipQtyCollection)
                rptPO.DataDefinition.ParameterFields("@txtMPO").ApplyCurrentValues(txtMPOCollection)
                rptPO.DataDefinition.ParameterFields("@txtMpoCloseDate").ApplyCurrentValues(txtMpoCloseDateCollection)
                rptPO.DataDefinition.ParameterFields("@txtNoBox").ApplyCurrentValues(txtNoBoxCollection)
                rptPO.DataDefinition.ParameterFields("@txtBarCode").ApplyCurrentValues(txtBarCodeCollection)

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
            Exit Sub

        End If

        '===================== WESCO AND OTHER CUSTOMER ==========================

        If frmSalesPSlip.Rd39.Checked = True Then
            Dim ShipNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShiptextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShiptext As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCountryCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipTelCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipTel As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromText As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCountryCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTelCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromTel As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtCustOrderCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtCustOrder As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtItemNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtItemNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtViaNotesCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtViaNotes As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPartNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPartNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPSlipQtyCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPSlipQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtMPOCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtMPO As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtMpoCloseDateCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtMpoCloseDate As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtNoBoxCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtNoBox As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtBarCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtBarCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtWeightCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtWeight As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Try
                Dim rptPO As New rptSalesPslipBarCodeLabels39()
                rptPO.Load("..\rptSalesPslipBarCodeLabels39.rpt")

                pShipName.Value = Me.ShipName.Text
                pShiptext.Value = Me.Shiptext.Text
                pShipAddress.Value = Me.ShipAddress.Text
                pShipCity.Value = Me.ShipCity.Text
                pShipProv.Value = Me.ShipProv.Text
                pShipCode.Value = Me.ShipCode.Text
                pShipCountry.Value = Me.ShipCountry.Text
                pShipTel.Value = Me.ShipTel.Text
                pFromName.Value = Me.FromName.Text
                pFromText.Value = Me.FromText.Text
                pFromAddress.Value = Me.FromAddress.Text
                pFromCity.Value = Me.FromCity.Text
                pFromProv.Value = Me.FromProv.Text
                pFromCode.Value = Me.FromCode.Text
                pFromCountry.Value = Me.FromCountry.Text
                pFromTel.Value = Me.FromTel.Text
                ptxtCustOrder.Value = Me.txtCustOrder.Text
                ptxtItemNo.Value = Me.txtItemNo.Text
                ptxtViaNotes.Value = Me.txtViaNotes.Text
                ptxtPartNo.Value = Me.txtPartNo.Text
                ptxtPSlipQty.Value = Me.txtPSlipQty.Text
                ptxtMPO.Value = Me.txtMPO.Text
                ptxtMpoCloseDate.Value = Me.txtMpoCloseDate.Text
                ptxtNoBox.Value = Me.txtNoBox.Text
                ptxtBarCode.Value = Me.txtBarCode.Text
                ptxtWeight.Value = Me.txtWeight.Text

                ShipNameCollection.Add(pShipName)
                ShiptextCollection.Add(pShiptext)
                ShipAddressCollection.Add(pShipAddress)
                ShipCityCollection.Add(pShipCity)
                ShipProvCollection.Add(pShipProv)
                ShipCodeCollection.Add(pShipCode)
                ShipCountryCollection.Add(pShipCountry)
                ShipTelCollection.Add(pShipTel)
                FromNameCollection.Add(pFromName)
                FromTextCollection.Add(pFromText)
                FromAddressCollection.Add(pFromAddress)
                FromCityCollection.Add(pFromCity)
                FromProvCollection.Add(pFromProv)
                FromCodeCollection.Add(pFromCode)
                FromCountryCollection.Add(pFromCountry)
                FromTelCollection.Add(pFromTel)
                txtCustOrderCollection.Add(ptxtCustOrder)
                txtItemNoCollection.Add(ptxtItemNo)
                txtViaNotesCollection.Add(ptxtViaNotes)
                txtPartNoCollection.Add(ptxtPartNo)
                txtPSlipQtyCollection.Add(ptxtPSlipQty)
                txtMPOCollection.Add(ptxtMPO)
                txtMpoCloseDateCollection.Add(ptxtMpoCloseDate)
                txtNoBoxCollection.Add(ptxtNoBox)
                txtBarCodeCollection.Add(ptxtBarCode)
                txtWeightCollection.Add(ptxtWeight)

                rptPO.DataDefinition.ParameterFields("@ShipName").ApplyCurrentValues(ShipNameCollection)
                rptPO.DataDefinition.ParameterFields("@Shiptext").ApplyCurrentValues(ShiptextCollection)
                rptPO.DataDefinition.ParameterFields("@ShipAddress").ApplyCurrentValues(ShipAddressCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCity").ApplyCurrentValues(ShipCityCollection)
                rptPO.DataDefinition.ParameterFields("@ShipProv").ApplyCurrentValues(ShipProvCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCode").ApplyCurrentValues(ShipCodeCollection)
                rptPO.DataDefinition.ParameterFields("@ShipCountry").ApplyCurrentValues(ShipCountryCollection)
                rptPO.DataDefinition.ParameterFields("@ShipTel").ApplyCurrentValues(ShipTelCollection)
                rptPO.DataDefinition.ParameterFields("@FromName").ApplyCurrentValues(FromNameCollection)
                rptPO.DataDefinition.ParameterFields("@FromText").ApplyCurrentValues(FromTextCollection)
                rptPO.DataDefinition.ParameterFields("@FromAddress").ApplyCurrentValues(FromAddressCollection)
                rptPO.DataDefinition.ParameterFields("@FromCity").ApplyCurrentValues(FromCityCollection)
                rptPO.DataDefinition.ParameterFields("@FromProv").ApplyCurrentValues(FromProvCollection)
                rptPO.DataDefinition.ParameterFields("@FromCode").ApplyCurrentValues(FromCodeCollection)
                rptPO.DataDefinition.ParameterFields("@FromCountry").ApplyCurrentValues(FromCountryCollection)
                rptPO.DataDefinition.ParameterFields("@FromTel").ApplyCurrentValues(FromTelCollection)
                rptPO.DataDefinition.ParameterFields("@txtCustOrder").ApplyCurrentValues(txtCustOrderCollection)
                rptPO.DataDefinition.ParameterFields("@txtItemNo").ApplyCurrentValues(txtItemNoCollection)
                rptPO.DataDefinition.ParameterFields("@txtViaNotes").ApplyCurrentValues(txtViaNotesCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartNo").ApplyCurrentValues(txtPartNoCollection)
                rptPO.DataDefinition.ParameterFields("@txtPSlipQty").ApplyCurrentValues(txtPSlipQtyCollection)
                rptPO.DataDefinition.ParameterFields("@txtMPO").ApplyCurrentValues(txtMPOCollection)
                rptPO.DataDefinition.ParameterFields("@txtMpoCloseDate").ApplyCurrentValues(txtMpoCloseDateCollection)
                rptPO.DataDefinition.ParameterFields("@txtNoBox").ApplyCurrentValues(txtNoBoxCollection)
                rptPO.DataDefinition.ParameterFields("@txtBarCode").ApplyCurrentValues(txtBarCodeCollection)
                rptPO.DataDefinition.ParameterFields("@txtWeight").ApplyCurrentValues(txtWeightCollection)

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
            Exit Sub
        End If


        '==================== HONEYWELL ENGIENES ==============================================

        If frmSalesPSlip.RdHon.Checked = True Then
            Dim ShipNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShiptextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShiptext As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim ShipTotalAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipTotalAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim ShipTotalCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pShipTotalCityAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            'Dim ShipCountryCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim pShipCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim ShipTelCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim pShipTel As New CrystalDecisions.Shared.ParameterDiscreteValue()


            Dim FromNameCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromName As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTextCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromText As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCity As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromProvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromProv As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromCodeCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim FromTotalAddressCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromTotalAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim FromTotalCityCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pFromTotalCityAddress As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim FromCountryCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim pFromCountry As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'Dim FromTelCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim pFromTel As New CrystalDecisions.Shared.ParameterDiscreteValue()


            Dim txtCustOrderCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtCustOrder As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtItemNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtItemNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            'Dim txtViaNotesCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim ptxtViaNotes As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPartNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPartNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPSlipQtyCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPSlipQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtMPOCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtMPO As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtPSLipNoCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtPSlipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            'Dim txtMpoCloseDateCollection As New CrystalDecisions.Shared.ParameterValues
            ' Dim ptxtMpoCloseDate As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtFromCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtfrom As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim txtNoBoxCollection As New CrystalDecisions.Shared.ParameterValues
            Dim ptxtNoBox As New CrystalDecisions.Shared.ParameterDiscreteValue()

            'Dim txtBarCodeCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim ptxtBarCode As New CrystalDecisions.Shared.ParameterDiscreteValue()

            'Dim txtWeightCollection As New CrystalDecisions.Shared.ParameterValues
            'Dim ptxtWeight As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Try
                Dim rptPO As New rptSalesPslipBarCodeLabels39HoneyWell()
                rptPO.Load("..\rptSalesPslipBarCodeLabels39HoneyWell.rpt")

                pShipName.Value = Me.ShipName.Text
                'pShiptext.Value = Me.Shiptext.Text
                'pShipAddress.Value = Me.ShipAddress.Text
                If Len(Trim(Me.Shiptext.Text)) = 0 Then
                    pShipTotalAddress.Value = Trim(Me.ShipAddress.Text)
                Else
                    pShipTotalAddress.Value = Trim(Me.Shiptext.Text) + ", " + Trim(Me.ShipAddress.Text)
                End If
                'pShipCity.Value = Me.ShipCity.Text
                'pShipProv.Value = Me.ShipProv.Text
                'pShipCode.Value = Me.ShipCode.Text
                pShipTotalCityAddress.Value = Trim(Me.ShipCity.Text) + ", " + Trim(Me.ShipProv.Text) + " " + Trim(Me.ShipCode.Text)
                'pShipCountry.Value = Me.ShipCountry.Text
                'pShipTel.Value = Me.ShipTel.Text


                pFromName.Value = Me.FromName.Text

                'pFromText.Value = Me.FromText.Text
                'pFromAddress.Value = Me.FromAddress.Text
                pFromTotalAddress.Value = Trim(Me.FromAddress.Text)

                'pFromCity.Value = Me.FromCity.Text
                'pFromProv.Value = Me.FromProv.Text
                'pFromCode.Value = Me.FromCode.Text
                pFromTotalCityAddress.Value = Trim(Me.FromCity.Text) + ", " + Trim(Me.FromProv.Text) + " " + Trim(Me.FromCode.Text)

                'pFromCountry.Value = Me.FromCountry.Text
                'pFromTel.Value = Me.FromTel.Text

                ptxtCustOrder.Value = Me.txtCustOrder.Text
                ptxtItemNo.Value = Me.txtItemNo.Text
                'ptxtViaNotes.Value = Me.txtViaNotes.Text
                ptxtPartNo.Value = Me.txtPartNo.Text
                ptxtPSlipQty.Value = Me.txtPSlipQty.Text
                ptxtMPO.Value = Me.txtMPO.Text
                ptxtPSlipNo.Value = Me.txtPSlipNo.Text
                'ptxtMpoCloseDate.Value = Me.txtMpoCloseDate.Text
                ptxtfrom.Value = Me.txtFrom.Text
                ptxtNoBox.Value = Me.txtNoBox.Text
                'ptxtBarCode.Value = Me.txtBarCode.Text
                'ptxtWeight.Value = Me.txtWeight.Text

                ShipNameCollection.Add(pShipName)
                'ShiptextCollection.Add(pShiptext)
                'ShipAddressCollection.Add(pShipAddress)
                ShipTotalAddressCollection.Add(pShipTotalAddress)
                'ShipCityCollection.Add(pShipCity)
                'ShipProvCollection.Add(pShipProv)
                'ShipCodeCollection.Add(pShipCode)
                ShipTotalCityCollection.Add(pShipTotalCityAddress)
                'ShipCountryCollection.Add(pShipCountry)
                'ShipTelCollection.Add(pShipTel)


                FromNameCollection.Add(pFromName)
                'FromTextCollection.Add(pFromText)
                'FromAddressCollection.Add(pFromAddress)
                FromTotalAddressCollection.Add(pFromTotalAddress)
                'FromCityCollection.Add(pFromCity)
                'FromProvCollection.Add(pFromProv)
                'FromCodeCollection.Add(pFromCode)
                FromTotalCityCollection.Add(pFromTotalCityAddress)
                'FromCountryCollection.Add(pFromCountry)
                'FromTelCollection.Add(pFromTel)


                txtCustOrderCollection.Add(ptxtCustOrder)
                txtItemNoCollection.Add(ptxtItemNo)
                'txtViaNotesCollection.Add(ptxtViaNotes)
                txtPartNoCollection.Add(ptxtPartNo)
                txtPSlipQtyCollection.Add(ptxtPSlipQty)
                txtMPOCollection.Add(ptxtMPO)
                txtPSLipNoCollection.Add(ptxtPSlipNo)
                'txtMpoCloseDateCollection.Add(ptxtMpoCloseDate)
                txtNoBoxCollection.Add(ptxtNoBox)
                txtFromCollection.Add(ptxtfrom)
                'txtBarCodeCollection.Add(ptxtBarCode)
                'txtWeightCollection.Add(ptxtWeight)

                rptPO.DataDefinition.ParameterFields("@ShipName").ApplyCurrentValues(ShipNameCollection)
                rptPO.DataDefinition.ParameterFields("@ShipTotalAddress").ApplyCurrentValues(ShipTotalAddressCollection)
                rptPO.DataDefinition.ParameterFields("@ShipTotalCityAddress").ApplyCurrentValues(ShipTotalCityCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipAddress").ApplyCurrentValues(ShipAddressCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipCity").ApplyCurrentValues(ShipCityCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipProv").ApplyCurrentValues(ShipProvCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipCode").ApplyCurrentValues(ShipCodeCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipCountry").ApplyCurrentValues(ShipCountryCollection)
                'rptPO.DataDefinition.ParameterFields("@ShipTel").ApplyCurrentValues(ShipTelCollection)

                rptPO.DataDefinition.ParameterFields("@FromName").ApplyCurrentValues(FromNameCollection)
                rptPO.DataDefinition.ParameterFields("@FromTotalAddress").ApplyCurrentValues(FromTotalAddressCollection)
                rptPO.DataDefinition.ParameterFields("@FromTotalCityAddress").ApplyCurrentValues(FromTotalCityCollection)
                'rptPO.DataDefinition.ParameterFields("@FromCity").ApplyCurrentValues(FromCityCollection)
                'rptPO.DataDefinition.ParameterFields("@FromProv").ApplyCurrentValues(FromProvCollection)
                'rptPO.DataDefinition.ParameterFields("@FromCode").ApplyCurrentValues(FromCodeCollection)
                'rptPO.DataDefinition.ParameterFields("@FromCountry").ApplyCurrentValues(FromCountryCollection)
                'rptPO.DataDefinition.ParameterFields("@FromTel").ApplyCurrentValues(FromTelCollection)



                rptPO.DataDefinition.ParameterFields("@txtCustOrder").ApplyCurrentValues(txtCustOrderCollection)
                rptPO.DataDefinition.ParameterFields("@txtItemNo").ApplyCurrentValues(txtItemNoCollection)
                'rptPO.DataDefinition.ParameterFields("@txtViaNotes").ApplyCurrentValues(txtViaNotesCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartNo").ApplyCurrentValues(txtPartNoCollection)
                rptPO.DataDefinition.ParameterFields("@txtPSlipQty").ApplyCurrentValues(txtPSlipQtyCollection)
                rptPO.DataDefinition.ParameterFields("@txtMPO").ApplyCurrentValues(txtMPOCollection)
                rptPO.DataDefinition.ParameterFields("@txtPSlipNo").ApplyCurrentValues(txtPSLipNoCollection)
                'rptPO.DataDefinition.ParameterFields("@txtMpoCloseDate").ApplyCurrentValues(txtMpoCloseDateCollection)
                rptPO.DataDefinition.ParameterFields("@txtFrom").ApplyCurrentValues(txtFromCollection)
                rptPO.DataDefinition.ParameterFields("@txtNoBox").ApplyCurrentValues(txtNoBoxCollection)

                'rptPO.DataDefinition.ParameterFields("@txtBarCode").ApplyCurrentValues(txtBarCodeCollection)
                'rptPO.DataDefinition.ParameterFields("@txtWeight").ApplyCurrentValues(txtWeightCollection)

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
            Exit Sub
        End If
    End Sub

    
End Class