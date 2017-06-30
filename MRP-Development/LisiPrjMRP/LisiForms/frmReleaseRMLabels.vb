Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmReleaseRMLabels

    Inherits System.Windows.Forms.Form


    Private Sub frmReleaseRMLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ProcReadOnly()

    End Sub

    Sub ProcReadOnly()

        txtMatlLot.ReadOnly = True
        txtMaterial.ReadOnly = True
        txtDIA.ReadOnly = True
        txtKSI.ReadOnly = True
        txtMatlHeat.ReadOnly = True
        txtMill.ReadOnly = True
        txtRMStatus.ReadOnly = True
        ChkHold.Enabled = False
        ChkRejected.Enabled = False

        txtFrom.ReadOnly = False
        txtTo.ReadOnly = False
        txtFinalQty.ReadOnly = False

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintInter.Click

        If Len(Trim(txtMatlLot.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Matl LOT#")
            Exit Sub
        End If

        If Len(Trim(txtDIA.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Matl DIA")
            Exit Sub
        End If

        If Len(Trim(txtMatlHeat.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Matl Heat")
            Exit Sub
        End If

        If Len(Trim(txtMatlCond.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Matl Condition")
            Exit Sub
        End If

        If Len(Trim(txtKSI.Text)) = 0 Then
            MsgBox("!!! ERROR !!!   Missing Matl KSI")
            Exit Sub
        End If

        If Len(Trim(txtFinalQty.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing Total Qty per Box")
            Exit Sub
        End If

        If Len(Trim(txtDate.Text)) = 0 Then
            MsgBox("!!! ERROR !!!  Missing Date.")
            Exit Sub
        Else
            Dim NewDate As Date
            NewDate = txtDate.Text
            txtDate.Text = NewDate.ToString("yyyy-MM-dd")
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

        Dim txtMatlLotCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMatlLot As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtMaterialCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMaterial As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtDIACollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtDIA As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtMatlHeatCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMatlHeat As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtMatlCondCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMatlCond As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtKSICollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtKSI As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtMILLCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtMILL As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtFinalQtyCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtFinalQty As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtFromCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtFrom As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtTOCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtTO As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtDateCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtDate As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtRMStatusCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtRMStatus As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim txtNoBoxCollection As New CrystalDecisions.Shared.ParameterValues
        Dim ptxtNoBox As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptRawMaterialLabels
            rptPO.Load("..\rptRawMaterialLabels.rpt")


            ptxtMatlLot.Value = Trim(Me.txtMatlLot.Text)
            ptxtMaterial.Value = Trim(Me.txtMaterial.Text)
            ptxtDIA.Value = Trim(Me.txtDIA.Text)
            ptxtMatlHeat.Value = Trim(Me.txtMatlHeat.Text)
            ptxtMatlCond.Value = Trim(Me.txtMatlCond.Text)
            ptxtKSI.Value = Trim(Me.txtKSI.Text)
            ptxtMILL.Value = Trim(Me.txtMill.Text)
            ptxtFinalQty.Value = Trim(Me.txtFinalQty.Text)
            ptxtFrom.Value = Trim(Me.txtFrom.Text)
            ptxtTO.Value = Trim(Me.txtTo.Text)
            ptxtDate.Value = Trim(Me.txtDate.Text)
            ptxtRMStatus.Value = Trim(Me.txtRMStatus.Text)
            ptxtNoBox.Value = Trim(Me.txtNoBox.Text)

            txtMatlLotCollection.Add(ptxtMatlLot)
            txtMaterialCollection.Add(ptxtMaterial)
            txtDIACollection.Add(ptxtDIA)
            txtMatlHeatCollection.Add(ptxtMatlHeat)
            txtMatlCondCollection.Add(ptxtMatlCond)
            txtKSICollection.Add(ptxtKSI)
            txtMILLCollection.Add(ptxtMILL)
            txtFinalQtyCollection.Add(ptxtFinalQty)
            txtFromCollection.Add(ptxtFrom)
            txtTOCollection.Add(ptxtTO)
            txtDateCollection.Add(ptxtDate)
            txtRMStatusCollection.Add(ptxtRMStatus)
            txtNoBoxCollection.Add(ptxtNoBox)

            rptPO.DataDefinition.ParameterFields("@txtMatlLot").ApplyCurrentValues(txtMatlLotCollection)
            rptPO.DataDefinition.ParameterFields("@txtMaterial").ApplyCurrentValues(txtMaterialCollection)
            rptPO.DataDefinition.ParameterFields("@txtDIA").ApplyCurrentValues(txtDIACollection)
            rptPO.DataDefinition.ParameterFields("@txtMatlHeat").ApplyCurrentValues(txtMatlHeatCollection)
            rptPO.DataDefinition.ParameterFields("@txtMatlCond").ApplyCurrentValues(txtMatlCondCollection)
            rptPO.DataDefinition.ParameterFields("@txtKSI").ApplyCurrentValues(txtKSICollection)
            rptPO.DataDefinition.ParameterFields("@txtMill").ApplyCurrentValues(txtMILLCollection)
            rptPO.DataDefinition.ParameterFields("@txtRMStatus").ApplyCurrentValues(txtRMStatusCollection)
            rptPO.DataDefinition.ParameterFields("@txtFrom").ApplyCurrentValues(txtFromCollection)
            rptPO.DataDefinition.ParameterFields("@txtFinalQty").ApplyCurrentValues(txtFinalQtyCollection)
            rptPO.DataDefinition.ParameterFields("@txtTo").ApplyCurrentValues(txtTOCollection)
            rptPO.DataDefinition.ParameterFields("@txtNoBox").ApplyCurrentValues(txtNoBoxCollection)
            rptPO.DataDefinition.ParameterFields("@txtDate").ApplyCurrentValues(txtDateCollection)

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

  
End Class