Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.VBMath
Imports System.Net
Imports System.Net.Mail

Public Class frmSalesInvoice

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwDevise As Integer = 0
    Dim SwNewPrice As String = ""

    Dim MsgDelivQty As String = ""
    Dim MsgShippedQty As String = ""
    Dim DeltaQty As String = ""
    Dim OrderItemsID As String = ""

    Private Sub frmSalesInvoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmSalesInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()

        GC.Collect()

        SwTxtOrdDelivID.Visible = False
        swPosted.Visible = False
        SwDelivDate.Visible = False
        SwDelivPrize.Visible = False
        SwPslipPrize.Visible = False
        SwCreditNO.Visible = False
        SwTRText.Visible = False
        SwTrNo.Visible = False

        SwMPONo.Visible = False
        SwWSHE.Visible = False

        SwMPODelivID.Visible = False
        SwPslipDelivID.Visible = False

        InitFields()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        PutGL1()
        PutGL2()
        PutGL3()
        PutCustomer()
        PutTerms()
        PutShipVia()
        PutmpoMaster()
        PutSalesTax()
        PutPSlipNo()

    End Sub

    Sub PutGL1()
        With CmbGL1
            .DataSource = CallClass.PopulateComboBox("tblAccCompte", "cmbGetInvGL").Tables("tblAccCompte")
            .DisplayMember = "CompteNo"
            .ValueMember = "CompteID"
        End With

    End Sub

    Sub PutGL2()
        With CmbGL2
            .DataSource = CallClass.PopulateComboBox("tblAccCompte", "cmbGetInvGL").Tables("tblAccCompte")
            .DisplayMember = "CompteNo"
            .ValueMember = "CompteID"
        End With

    End Sub

    Sub PutGL3()
        With CmbGL3
            .DataSource = CallClass.PopulateComboBox("tblAccCompte", "cmbGetInvGL").Tables("tblAccCompte")
            .DisplayMember = "CompteNo"
            .ValueMember = "CompteID"
        End With

    End Sub

    Sub PutPSlipNo()
        With CmbPslip
            .DataSource = CallClass.PopulateComboBox("tblLisiPslip", "cmbGetDelivInvoice").Tables("tblLisiPslip")
            .DisplayMember = "PslipNo"
            .ValueMember = "PSlipID"
        End With

    End Sub

    Sub PutCustomer()

        With Me.CmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub PutTerms()
        With Me.CmbTerms
            .DataSource = CallClass.PopulateComboBox("tblLisiInvTerms", "cmbGetInvTerms").Tables("tblLisiInvTerms")
            .DisplayMember = "InvTerms"
            .ValueMember = "InvTerms"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

    End Sub

    Sub PutShipVia()

        With Me.cmbVia
            .DataSource = CallClass.PopulateComboBox("tblShipVia", "cmbGetShipVia").Tables("tblShipVia")
            .DisplayMember = "ShipVia"
            .ValueMember = "ViaID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutmpoMaster()
        With CmbMPO
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoNoFromFP").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Sub DisableFields()

        cmbSalesTax.Enabled = False
        CmbDevise.Enabled = False
        CmbTerms.Enabled = False

        txtCharge1.ReadOnly = True
        txtCharge2.ReadOnly = True
        txtCharge3.ReadOnly = True
        CmbGL1.Enabled = False
        CmbGL2.Enabled = False
        CmbGL3.Enabled = False

        txtValCh1.ReadOnly = True
        txtValCh2.ReadOnly = True
        txtValCh3.ReadOnly = True
        txtFOB.ReadOnly = True

        txtPSlipQty.ReadOnly = True
    End Sub

    Sub EnableFields()

        cmbSalesTax.Enabled = True
        CmbDevise.Enabled = True
        CmbTerms.Enabled = True

        txtCharge1.ReadOnly = True
        txtCharge2.ReadOnly = True
        txtCharge3.ReadOnly = True
        CmbGL1.Enabled = True
        CmbGL2.Enabled = True
        CmbGL3.Enabled = True

        txtValCh1.ReadOnly = False
        txtValCh2.ReadOnly = False
        txtValCh3.ReadOnly = False
        txtFOB.ReadOnly = False
        txtInvNotes.ReadOnly = False

    End Sub

    Sub FirstTimeMenuButtons()

        CmbPslip.Enabled = True

        CmdReset.Enabled = True
        CmdPrint.Enabled = True
        cmdEdit.Enabled = False
        cmdCredit.Enabled = False
        CmdSave.Enabled = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        dsMain.EnforceConstraints = False

    End Sub

    Sub BindComponents()

        txtDocNo.DataBindings.Clear()

        ShipName.DataBindings.Clear()
        Shiptext.DataBindings.Clear()
        ShipAddress.DataBindings.Clear()
        ShipCity.DataBindings.Clear()
        ShipProv.DataBindings.Clear()
        ShipCode.DataBindings.Clear()
        ShipCountry.DataBindings.Clear()

        InvName.DataBindings.Clear()
        InvText.DataBindings.Clear()
        InvAddress.DataBindings.Clear()
        InvCity.DataBindings.Clear()
        InvProv.DataBindings.Clear()
        InvCode.DataBindings.Clear()
        InvCountry.DataBindings.Clear()

        CmbCust.DataBindings.Clear()
        CmbMPO.DataBindings.Clear()
        cmbSalesTax.DataBindings.Clear()
        cmbVia.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbTerms.DataBindings.Clear()

        txtCustOrd.DataBindings.Clear()
        txtPORev.DataBindings.Clear()
        txtPODate.DataBindings.Clear()
        txtRefNo.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()

        txtPslipDate.DataBindings.Clear()
        txtFOB.DataBindings.Clear()
        txtViaNotes.DataBindings.Clear()
        txtPslipNotes.DataBindings.Clear()
        txtCoCRev.DataBindings.Clear()
        txtPSlipQty.DataBindings.Clear()
        txtItemNo.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtPartName.DataBindings.Clear()

        txtInvNo.DataBindings.Clear()
        txtInvDate.DataBindings.Clear()
        txtInvNotes.DataBindings.Clear()
        txtSalesPrice.DataBindings.Clear()
        txtCharge1.DataBindings.Clear()
        txtCharge2.DataBindings.Clear()
        txtCharge3.DataBindings.Clear()
        CmbGL1.DataBindings.Clear()
        CmbGL2.DataBindings.Clear()
        CmbGL3.DataBindings.Clear()

        txtValCh1.DataBindings.Clear()
        txtValCh2.DataBindings.Clear()
        txtValCh3.DataBindings.Clear()
        txtGST.DataBindings.Clear()
        txtQST.DataBindings.Clear()
        txtTVH.DataBindings.Clear()

        SwTxtOrdDelivID.DataBindings.Clear()
        swPosted.DataBindings.Clear()
        SwDelivDate.DataBindings.Clear()
        SwDelivPrize.DataBindings.Clear()
        SwPslipPrize.DataBindings.Clear()

        SwMPONo.DataBindings.Clear()
        SwWSHE.DataBindings.Clear()

        SwMPODelivID.DataBindings.Clear()
        SwPslipDelivID.DataBindings.Clear()
        SwInvShortName.DataBindings.Clear()

        txtCustCode.DataBindings.Clear()

        CmbCust.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.CustID")
        CmbMPO.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.PSlipMpoID")
        cmbSalesTax.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.InvSalesTaxID")
        cmbVia.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.PslipViaID")

        txtDocNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipType")

        If Trim(txtDocNo.Text) = "PSlip" Then
            CmbDevise.DataBindings.Add("Text", dsMain, "tblLisiPslip.OrdDevise")
        Else
            CmbDevise.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvDevise")
        End If

        CmbTerms.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvTerms")

        ShipName.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipName")
        Shiptext.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipText")
        ShipAddress.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipAddress")
        ShipCity.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipCity")
        ShipProv.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipProv")
        ShipCode.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipPostalCode")
        ShipCountry.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipCountry")

        InvName.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvName")

        InvAddress.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvAddress")
        InvCity.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvCity")
        InvProv.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvProv")
        InvCode.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvPostalCode")
        InvCountry.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvCountry")

        txtCustOrd.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipCustPOContr")
        txtPORev.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipCustPoRev")
        txtPODate.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipDatePOContr", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtRefNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipORDRefNo")
        txtPONotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.NotesOrder")

        txtPslipDate.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtFOB.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvFOB")
        txtViaNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipViaNotes")
        txtPslipNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipNotes")
        txtCoCRev.DataBindings.Add("Text", dsMain, "tblLisiPslip.CoCPartRev")
        txtPSlipQty.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipQty")
        txtItemNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipItem")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PartNumber")
        txtPartName.DataBindings.Add("Text", dsMain, "tblLisiPslip.PartName")

        txtInvNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipNo")
        txtInvDate.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

        'txtTerms.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvTerms")
        'If Len(Trim(txtTerms.Text)) = 0 Then
        '    txtTerms.DataBindings.Clear()
        '    txtTerms.DataBindings.Add("Text", dsMain, "tblLisiPslip.CustInvTerms")
        '    If Len(Trim(txtTerms.Text)) = 0 Then
        '        MsgBox("The Terms for this customer are missing." + vbCrLf + _
        '            "The Invoice module will close." + vbCrLf + _
        '            "Please update the terms in Customer Order Entry Module")
        '        dsMain.RejectChanges()
        '        dsMain.Dispose()
        '        Me.Dispose()
        '        GC.Collect()
        '    End If
        'End If

        txtSalesPrice.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvPrice", True, DataSourceUpdateMode.OnValidation, 0, "C4")

        txtCharge1.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvTextCh1")
        txtCharge2.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvTextCh2")
        txtCharge3.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvTextCh3")
        CmbGL1.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvAccpacGL1")
        CmbGL2.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvAccpacGL2")
        CmbGL3.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvAccpacGL3")

        txtValCh1.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvValCh1", True, DataSourceUpdateMode.OnValidation, 0, "C2")
        txtValCh2.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvValCh2", True, DataSourceUpdateMode.OnValidation, 0, "C2")
        txtValCh3.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvValCh3", True, DataSourceUpdateMode.OnValidation, 0, "C2")

        txtInvNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvNotes")

        SwTxtOrdDelivID.DataBindings.Add("Text", dsMain, "tblLisiPslip.OrdDelivID")
        swPosted.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvPosted")
        SwDelivDate.DataBindings.Add("Text", dsMain, "tblLisiPslip.DelivDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        SwDelivPrize.DataBindings.Add("Text", dsMain, "tblLisiPslip.DelivPrize", True, DataSourceUpdateMode.OnValidation, 0, "N0")
        SwPslipPrize.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipDelivPrize", True, DataSourceUpdateMode.OnValidation, 0, "N0")

        SwMPONo.DataBindings.Add("Text", dsMain, "tblLisiPslip.MPONo")
        SwWSHE.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipWSHE")
        SwMPODelivID.DataBindings.Add("Text", dsMain, "tblLisiPslip.MPODelivID")
        SwPslipDelivID.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipDelivID")

        SwInvShortName.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvShortName")

        txtCustCode.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipAccpacCode")

    End Sub

    Private Sub CmbPslip_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPslip.DropDownClosed

        Dim SwSalesID As Integer = 0
        Dim strSearch As Integer
        strSearch = CmbPslip.SelectedValue

        InitFields()

        If strSearch <> 0 Then
            dsMain.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getPslipDelivReqWithSearch", strSearch).Fill(dsMain, "tblLisiPslip")

            BindComponents()

            If Trim(txtDocNo.Text) = "PSlip" Then
                txtInvDate.Text = Now.ToShortDateString
                'txtTerms.Text = "Net 30 Days"
                txtFOB.Text = "Origin"
                ' if cad return id for canada else return id for the country
                If CmbDevise.Text = "CAD" Then
                    SwSalesID = CallClass.ReturnStrWithParString("cspReturnInvSalesCAD", "CAD")
                Else
                    SwSalesID = CallClass.ReturnStrWithParString("cspReturnInvSalesOther", CmbDevise.Text)
                End If
            Else
                SwSalesID = cmbSalesTax.SelectedValue
            End If

            If SwSalesID <> 0 Then
                PutSalesTax()

                cmbSalesTax.SelectedValue = SwSalesID
            Else
                MsgBox("!!! ERROR !!! System can not identify the Sales Info.")
                cmdEdit.Enabled = False
                Exit Sub
            End If

        End If

        CmbPslip.Enabled = False

        cmdEdit.Enabled = True

        'Select Case txtDocNo.Text
        '    Case "Inv"
        '        CmdPrint.Enabled = True
        '    Case "Pslip"
        '        CmdPrint.Enabled = False
        '    Case "CRD"
        '        CmdPrint.Enabled = True
        'End Select

        If Trim(txtDocNo.Text) = "Inv" Or Trim(txtDocNo.Text) = "CRD" Then
            CmdPrint.Enabled = True
        Else
            CmdPrint.Enabled = False
        End If

        If Trim(Nz.Nz(swPosted.Text)) = "P" Then
            cmdEdit.Enabled = False
            cmdCredit.Enabled = True
        Else
            cmdCredit.Enabled = False
            If Trim(txtDocNo.Text) = "CRD" Then
                cmdEdit.Enabled = False      'keep false becouse if you edit and save he will create a new credite
            End If
        End If

        'If InStr(txtPartNo.Text, "EXPEDITE", vbTextCompare) <> 0 Then
        '    txtSalesPrice.Text = "0.001"
        'End If

        CalculInvoice()

        SwDevise = 9

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        EnableFields()
        CmdSave.Enabled = True
        cmdEdit.Enabled = False
        CmdPrint.Enabled = False
        CmdReset.Enabled = True
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        DisableFields()
        FirstTimeMenuButtons()

        dsMain.RejectChanges()
        dsMain.Clear()
        InitFields()

        SwDevise = 0

        CmbPslip.SelectedIndex = -1
        CmdPrint.Enabled = False

        txtPSlipQty.BackColor = System.Windows.Forms.Control.DefaultBackColor

        PutPSlipNo()

        'BindComponents()

    End Sub

    Sub CalculInvoice()

        Dim TAmount As Double = 0
        Dim TSub As Decimal = 0
        Dim TGST As Double = 0
        Dim TQST As Double = 0
        Dim TTVH As Double = 0
        Dim TInv As Double = 0

        If Len(Trim(txtSalesPrice.Text)) = 0 Then
            txtSalesPrice.Text = 0
        End If

        If Len(Trim(txtValCh1.Text)) = 0 Or IsDBNull(txtValCh1.Text) = True Then
            txtValCh1.Text = 0
        End If
        If Len(Trim(txtValCh2.Text)) = 0 Or IsDBNull(txtValCh2.Text) = True Then
            txtValCh2.Text = 0
        End If
        If Len(Trim(txtValCh3.Text)) = 0 Or IsDBNull(txtValCh3.Text) = True Then
            txtValCh3.Text = 0
        End If

        Try
            TAmount = Math.Round((txtSalesPrice.Text * txtPSlipQty.Text), 4)
            TSub = TAmount + CDbl(txtValCh1.Text) + CDbl(txtValCh2.Text) + CDbl(txtValCh3.Text)
        Catch ex As Exception
        End Try

        TGST = TSub * Nz.Nz(txtGST.Text)
        'TQST = (TSub + TGST) * Nz.Nz(txtQST.Text)
        TQST = TSub * Nz.Nz(txtQST.Text)
        TTVH = TSub * Nz.Nz(txtTVH.Text)
        TInv = TSub + TGST + TQST + TTVH

        txtAmount.Text = TAmount.ToString("C2")
        txtSubTotal.Text = TSub.ToString("C2")
        txtTotalInv.Text = TInv.ToString("C2")
        txtValGST.Text = TGST.ToString("C2")
        txtValQST.Text = TQST.ToString("C2")
        txtValTVH.Text = TTVH.ToString("C2")

    End Sub

    Sub InitFields()
        txtAmount.Text = 0
        txtSubTotal.Text = 0
        txtSalesPrice.Text = 0
        txtPSlipQty.Text = 0
        txtGST.Text = 0
        txtQST.Text = 0
        txtTVH.Text = 0
        txtValGST.Text = 0
        txtValQST.Text = 0
        txtValTVH.Text = 0
        txtTotalInv.Text = 0
        txtValCh1.Text = 0
        txtValCh2.Text = 0
        txtValCh3.Text = 0
        txtInvNotes.Text = ""
    End Sub

    Private Sub txtValCh1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValCh1.Validated
        CalculInvoice()
    End Sub

    Private Sub txtValCh2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValCh2.Validated
        CalculInvoice()
    End Sub

    Private Sub txtValCh3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValCh3.Validated
        CalculInvoice()
    End Sub

    Sub PutSalesTax()

        strSQL = " SELECT SalesTaxID, DolarSign, GstRate, QstRate, TvhRate, Country FROM tblSalesTax"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblSalesTax")

            With cmbSalesTax
                .DataSource = ds.Tables("tblSalesTax")
                .DisplayMember = "Country"
                .ValueMember = "SalesTaxID"
            End With

            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - PutSalesTax  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch xcp As Exception
            MessageBox.Show(xcp.Message, "General Error - PutSalesTax  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub cmbSalesTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSalesTax.SelectedIndexChanged

        If IsNothing(cmbSalesTax.SelectedItem) = True Then
        Else
            txtGST.Text = cmbSalesTax.SelectedItem("GstRate")
            txtQST.Text = cmbSalesTax.SelectedItem("QstRate")
            txtTVH.Text = cmbSalesTax.SelectedItem("TvhRate")

            If SwDevise = 9 Then  'after cmbpslip dropdown
                CmbDevise.Text = cmbSalesTax.SelectedItem("DolarSign")
            End If


            CalculInvoice()

        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        CalculInvoice()
        Call ValPo()

        If SwVal = True Then


            Try
                dsMain.GetChanges()
                If Val(txtPSlipQty.Text) > 0 Then

                    UpdateInvoice()

                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()

                    MsgDelivQty = ""
                    MsgShippedQty = ""

                    Dim reply As DialogResult

                    MsgDelivQty = CallClass.ReturnStrWithParInt("cspReturnInvDelivQty", SwTxtOrdDelivID.Text)
                    MsgShippedQty = CallClass.ReturnStrWithParInt("cspReturnInvShippedQty", SwTxtOrdDelivID.Text)

                    If SwInvShortName.Text = "LNA" Then

                        UpdateDeliveryStatus()

                        If Val(MsgShippedQty) <> Val(MsgDelivQty) Then

                            UpdateBookingAdkQtyLNAOnly()

                        End If

                    Else
                        If Val(MsgShippedQty) >= Val(MsgDelivQty) Then
                            reply = MsgBox("Customer item Delivery Qty = " + MsgDelivQty + "||  Total Shipped Qty = " + MsgShippedQty + vbCrLf _
                                    + "Do you want to close the Customer item Delivery Status ? ", MsgBoxStyle.YesNo)
                            If reply = Windows.Forms.DialogResult.Yes Then
                                UpdateDeliveryStatus()
                            End If
                        Else
                            'If SwInvShortName.Text = "LNA" Then
                            'If MsgShippedQty < MsgDelivQty * 70 / 100 Then
                            'MessageBox.Show("Total Qty Shipped is below DO qty 70%")
                            'Else
                            'MessageBox.Show("Total Qty Shipped is over  DO qty 70%  -  delivery it will be closed  in LAC system")
                            'UpdateDeliveryStatus()
                            'End If

                            'End If
                        End If
                    End If


                    'Check and Update tblInvPslip with the new Price

                    SwNewPrice = ""
                    SwNewPrice = CallClass.TakeFinalSt("cspReturnHIShearNewPrice", txtPartNo.Text)

                    If SwNewPrice = "False" Then
                        SwNewPrice = 0
                    End If

                    UpdateNewPrice()

                    If InStr(txtPartNo.Text, "BACB", vbTextCompare) <> 0 Then
                        reply = MsgBox("Do you want to send an email to Hi-Shear ? ", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then


                            Dim email As New Mail.MailMessage()
                            Dim strBody As String = ""
                            email.Subject = " LAC - BACB Shipment"
                            strBody = "Invoice/PSlip No: " + txtInvNo.Text + vbCrLf
                            strBody = strBody + "==================" + vbCrLf

                            strBody = strBody + "Boeing WSHE  : " + SwWSHE.Text + vbCrLf + vbCrLf
                            strBody = strBody + "Shipping Date: " + txtPslipDate.Text + vbCrLf
                            strBody = strBody + "Invoice Date: " + txtPslipDate.Text + vbCrLf
                            strBody = strBody + "PO Delivery Date: " + SwDelivDate.Text + vbCrLf
                            strBody = strBody + "MPO No: " + CmbMPO.Text + vbCrLf
                            strBody = strBody + "Cust PO No: " + txtCustOrd.Text + vbCrLf
                            strBody = strBody + "Line No: " + txtItemNo.Text + vbCrLf
                            strBody = strBody + "Part No: " + txtPartNo.Text + vbCrLf
                            strBody = strBody + "Quantity: " + txtPSlipQty.Text + vbCrLf
                            strBody = strBody + "Sales Price: " + txtSalesPrice.Text
                            email.Body = strBody

                            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            email.To.Add(New Mail.MailAddress("DORSalesLNA@lisi-aerospace.com"))
                            client.Send(email)

                        End If

                    End If

                Else


                    If SwTRText.Text = "SALES" Then
                        UpdateCreditInvoice()
                    Else
                        'do you want to continue with the rma/ir procedure?
                        'If Yes the system will create the credit documnet and a new RMA/IR MPO in Quarantine department.
                        'an email will be generate and send it to QA.

                        UpdateCreditRmaIR()

                    End If

                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()

                    PutPSlipNo()

                End If

                CmdPrint.Enabled = True

            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - REQ: " & ex.Message)
            End Try

            CmdSave.Enabled = False
            DisableFields()

            'If Val(SwMPODelivID.Text) <> Val(SwPslipDelivID.Text) Then

            '    Dim email As New Mail.MailMessage()
            '    Dim strBody As String = ""
            '    email.Subject = " !!! WARNING !!!"
            '    strBody = "MPO Delivery date: " + CmbMPO.Text + " Part Number: " + txtPartNo.Text + " mismatch with Customer Delivery date." + vbCrLf
            '    strBody = strBody + "Please check the customer delivery date for each MPO split. "
            '    email.Body = strBody

            '    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            '    email.From = New Net.Mail.MailAddress(wkEmpEmail)
            '    email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
            '    email.To.Add(New Mail.MailAddress("yanick.levert@lisi-aerospace.com"))
            '    client.Send(email)
            'End If

        End If

    End Sub

    Sub ValPo()


        If txtTotalInv.Text > 0 Then
            If InStr(ShipCountry.Text, "CANADA", vbTextCompare) <> 0 Then
                If Val(txtGST.Text) = 0 And Val(txtQST.Text) = 0 And Val(txtTVH.Text = 0) Then
                    MsgBox("!!! ERROR !!! As you ship to Canada, you must activate the Canadien Sales taxes.")
                    SwVal = False
                    Exit Sub
                End If
            End If
        End If

        'If CmbDevise.Text = "EUR" Then
        '    If InStr(SwInvShortName.Text, "EUR", vbTextCompare) <> 0 Then
        '    Else
        '        MsgBox("!!! ERROR !!! Please check the Customer Billing accountig code as the devise is EUR.")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'End If

        If InStr(InvCountry.Text, "CANADA", vbTextCompare) <> 0 Then
            If Val(txtGST.Text) = 0 And Val(txtQST.Text) = 0 And Val(txtTVH.Text = 0) Then
                MsgBox("!!! ERROR !!! As you bill to Canada, you must activate the Canadien Sales taxes.")
                SwVal = False
                Exit Sub
            End If
        End If

        'If Microsoft.VisualBasic.Left(txtCustCode.Text, 2) = "01" Then
        '    If CmbDevise.Text <> "USD" Then
        '        MsgBox("!!! ERROR !!! Devise. The Client Code is for US.")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'End If

        'If Microsoft.VisualBasic.Left(txtCustCode.Text, 2) = "02" Then
        '    If CmbDevise.Text <> "CAD" Then
        '        MsgBox("!!! ERROR !!! Devise. The Client Code is for Canada.")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'End If

        'If Microsoft.VisualBasic.Left(txtCustCode.Text, 2) = "04" Then
        '    If CmbDevise.Text <> "EUR" Then
        '        MsgBox("!!! ERROR !!! Devise. The Client Code is for Europe.")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'End If

        If txtSalesPrice.Text = 0 Then
            MsgBox("!!! ERROR !!! Sales Price is Null.")
            SwVal = False
            Exit Sub
        End If

        'If Len(Trim(txtPSlipQty.Text)) = 0 = True Or Val(txtPSlipQty.Text) = 0 Then
        '    MsgBox("!!! ERROR !!! Invoice Quantity is Null.")
        '    SwVal = False
        '    Exit Sub
        'End If

        If CmbMPO.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! Mpo Nummber is Null.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtFOB.Text)) = 0 Then
            MsgBox("!!! ERROR !!! FOB is Null.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbTerms.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Terms are Null.")
            SwVal = False
            Exit Sub
        End If

        If txtTotalInv.Text = 0 Then
            MsgBox("!!! ERROR !!! Invoice value is Null.")
            SwVal = False
            Exit Sub
        End If

        If cmbSalesTax.SelectedValue <= 0 Or Len(Trim(cmbSalesTax.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Sales tax is Null.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbDevise.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Currency is Null.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtCustCode.Text)) = 0 Or Trim(txtCustCode.Text) = "False" Then
            MsgBox("!!! ERROR !!! Customer Accounting Code is Empty")
            SwVal = False
            Exit Sub
        End If

        If Val(txtPSlipQty.Text) < 0 Then
            If txtTotalInv.Text >= 0 Then
                Dim reply As DialogResult

                reply = MsgBox("Total Credit Amount is >= 0" + vbCrLf _
                        + "Do you accept this Amount ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    SwVal = True
                Else
                    SwVal = False
                    Exit Sub
                End If
            End If
        End If

        If SwInvShortName.Text = "LNA" Then
            If Len(Trim(SwWSHE.Text)) = 0 Then
                MsgBox("!!! ERROR !!! Missing Boeing WHSE.")
                SwVal = False
                Exit Sub
            End If
        End If

        If SwInvShortName.Text = "MHI" Then
            If Len(Trim(SwWSHE.Text)) = 0 Then
                MsgBox("!!! ERROR !!! Missing MHI WHSE.")
                SwVal = False
                Exit Sub
            End If
        End If

        If SwInvShortName.Text = "EMB" Then
            If Len(Trim(SwWSHE.Text)) = 0 Then
                MsgBox("!!! ERROR !!! Missing EMB WHSE.")
                SwVal = False
                Exit Sub
            End If
        End If

        SwVal = True

    End Sub


    Sub UpdateNewPrice()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvoiceNewPrice", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtInvNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraNewPrice As SqlParameter = New SqlParameter("@InvNewPrice2010", SqlDbType.Money, 8)
        paraNewPrice.Value = SwNewPrice
        mySqlComm.Parameters.Add(paraNewPrice)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Invoice New Price: " & ex.Message)
        End Try

    End Sub


    Sub UpdateInvoice()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvoiceInfo", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtInvNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraType As SqlParameter = New SqlParameter("@PslipType", SqlDbType.NVarChar, 5)
        paraType.Value = "Inv"
        mySqlComm.Parameters.Add(paraType)

        Dim paraDate As SqlParameter = New SqlParameter("@InvDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = txtInvDate.Text
        mySqlComm.Parameters.Add(paraDate)

        Dim paraFOB As SqlParameter = New SqlParameter("@InvFOB", SqlDbType.NVarChar, 25)
        paraFOB.Value = txtFOB.Text
        mySqlComm.Parameters.Add(paraFOB)

        Dim paraTerms As SqlParameter = New SqlParameter("@InvTerms", SqlDbType.NVarChar, 50)
        paraTerms.Value = CmbTerms.Text
        mySqlComm.Parameters.Add(paraTerms)

        Dim paraCh1 As SqlParameter = New SqlParameter("@InvTextCh1", SqlDbType.NVarChar, 50)
        paraCh1.Value = txtCharge1.Text
        mySqlComm.Parameters.Add(paraCh1)

        Dim paraCh2 As SqlParameter = New SqlParameter("@InvTextCh2", SqlDbType.NVarChar, 50)
        paraCh2.Value = txtCharge2.Text
        mySqlComm.Parameters.Add(paraCh2)

        Dim paraCh3 As SqlParameter = New SqlParameter("@InvTextCh3", SqlDbType.NVarChar, 50)
        paraCh3.Value = txtCharge3.Text
        mySqlComm.Parameters.Add(paraCh3)

        Dim paraGL1 As SqlParameter = New SqlParameter("@InvAccpacGL1", SqlDbType.NVarChar, 25)
        paraGL1.Value = CmbGL1.Text
        mySqlComm.Parameters.Add(paraGL1)

        Dim paraGL2 As SqlParameter = New SqlParameter("@InvAccpacGL2", SqlDbType.NVarChar, 25)
        paraGL2.Value = CmbGL2.Text
        mySqlComm.Parameters.Add(paraGL2)

        Dim paraGL3 As SqlParameter = New SqlParameter("@InvAccpacGL3", SqlDbType.NVarChar, 25)
        paraGL3.Value = CmbGL3.Text
        mySqlComm.Parameters.Add(paraGL3)

        Dim paraVal1 As SqlParameter = New SqlParameter("@InvValCh1", SqlDbType.Money, 8)
        paraVal1.Value = txtValCh1.Text
        mySqlComm.Parameters.Add(paraVal1)

        Dim paraVal2 As SqlParameter = New SqlParameter("@InvValCh2", SqlDbType.Money, 8)
        paraVal2.Value = txtValCh2.Text
        mySqlComm.Parameters.Add(paraVal2)

        Dim paraVal3 As SqlParameter = New SqlParameter("@InvValCh3", SqlDbType.Money, 8)
        paraVal3.Value = txtValCh3.Text
        mySqlComm.Parameters.Add(paraVal3)

        Dim paraSalesID As SqlParameter = New SqlParameter("@InvSalesTaxID", SqlDbType.Int, 4)
        paraSalesID.Value = cmbSalesTax.SelectedValue
        mySqlComm.Parameters.Add(paraSalesID)

        Dim paraDevise As SqlParameter = New SqlParameter("@InvDevise", SqlDbType.NVarChar, 10)
        paraDevise.Value = CmbDevise.Text
        mySqlComm.Parameters.Add(paraDevise)

        Dim paraGST As SqlParameter = New SqlParameter("@InvGST", SqlDbType.Real, 4)
        paraGST.Value = Val(txtGST.Text)
        mySqlComm.Parameters.Add(paraGST)

        Dim paraQST As SqlParameter = New SqlParameter("@InvQST", SqlDbType.Real, 4)
        paraQST.Value = Val(txtQST.Text)
        mySqlComm.Parameters.Add(paraQST)

        Dim paraTVH As SqlParameter = New SqlParameter("@InvTVH", SqlDbType.Real, 4)
        paraTVH.Value = Val(txtTVH.Text)
        mySqlComm.Parameters.Add(paraTVH)

        Dim paraNotes As SqlParameter = New SqlParameter("@InvNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = txtInvNotes.Text
        mySqlComm.Parameters.Add(paraNotes)

        Dim paraPslipDate As SqlParameter = New SqlParameter("@PslipDate", SqlDbType.SmallDateTime, 4)
        paraPslipDate.Value = txtPslipDate.Text
        mySqlComm.Parameters.Add(paraPslipDate)

        Dim paraPslipPrize As SqlParameter = New SqlParameter("@PslipDelivPrize", SqlDbType.Int, 4)
        If Trim(txtDocNo.Text) = "Inv" Then
            paraPslipPrize.Value = SwPslipPrize.Text
        Else
            Select Case SwDelivPrize.Text
                Case 1
                    If txtInvDate.Text <= SwDelivDate.Text Then
                        paraPslipPrize.Value = 1
                    Else
                        paraPslipPrize.Value = 9
                    End If
                Case 9
                    paraPslipPrize.Value = 9
                Case Else
                    If txtInvDate.Text <= SwDelivDate.Text Then
                        paraPslipPrize.Value = 1
                        UpdateDelivPrizeINCustOrder(1)
                    Else
                        paraPslipPrize.Value = 9
                        UpdateDelivPrizeINCustOrder(9)
                    End If
            End Select
        End If

        mySqlComm.Parameters.Add(paraPslipPrize)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Invoice Info.: " & ex.Message)
        End Try

    End Sub

    Sub UpdateCreditRmaIR()

        'create the credit in tblLisiPslip
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvoiceCredit", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtInvNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraType As SqlParameter = New SqlParameter("@PslipType", SqlDbType.NVarChar, 5)
        paraType.Value = "CRD"
        mySqlComm.Parameters.Add(paraType)

        Dim paraDate As SqlParameter = New SqlParameter("@InvDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraDate)

        Dim paraNotes As SqlParameter = New SqlParameter("@InvNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = txtInvNotes.Text
        mySqlComm.Parameters.Add(paraNotes)

        Dim paraQtyCRD As SqlParameter = New SqlParameter("@SwQtyCRD", SqlDbType.Real, 4)
        paraQtyCRD.Value = txtPSlipQty.Text
        mySqlComm.Parameters.Add(paraQtyCRD)

        Dim paraTextCh1 As SqlParameter = New SqlParameter("@SwTextCh1", SqlDbType.NVarChar, 50)
        paraTextCh1.Value = Trim(txtCharge1.Text)
        mySqlComm.Parameters.Add(paraTextCh1)

        Dim paraTextCh2 As SqlParameter = New SqlParameter("@SwTextCh2", SqlDbType.NVarChar, 50)
        paraTextCh2.Value = Trim(txtCharge2.Text)
        mySqlComm.Parameters.Add(paraTextCh2)

        Dim paraTextCh3 As SqlParameter = New SqlParameter("@SwTextCh3", SqlDbType.NVarChar, 50)
        paraTextCh3.Value = Trim(txtCharge3.Text)
        mySqlComm.Parameters.Add(paraTextCh3)

        Dim paraGL1 As SqlParameter = New SqlParameter("@SwGL1", SqlDbType.NVarChar, 25)
        paraGL1.Value = CmbGL1.Text
        mySqlComm.Parameters.Add(paraGL1)

        Dim paraGL2 As SqlParameter = New SqlParameter("@SwGL2", SqlDbType.NVarChar, 25)
        paraGL2.Value = CmbGL2.Text
        mySqlComm.Parameters.Add(paraGL2)

        Dim paraGL3 As SqlParameter = New SqlParameter("@SwGL3", SqlDbType.NVarChar, 25)
        paraGL3.Value = CmbGL3.Text
        mySqlComm.Parameters.Add(paraGL3)

        Dim paraValCh1 As SqlParameter = New SqlParameter("@SwValCh1", SqlDbType.Real, 4)
        paraValCh1.Value = CDbl(txtValCh1.Text)
        mySqlComm.Parameters.Add(paraValCh1)

        Dim paraValCh2 As SqlParameter = New SqlParameter("@SwValCh2", SqlDbType.Real, 4)
        paraValCh2.Value = CDbl(txtValCh2.Text)
        mySqlComm.Parameters.Add(paraValCh2)

        Dim paraValCh3 As SqlParameter = New SqlParameter("@SwValCh3", SqlDbType.Real, 4)
        paraValCh3.Value = CDbl(txtValCh3.Text)
        mySqlComm.Parameters.Add(paraValCh3)

        Dim paraCRD As SqlParameter = New SqlParameter("@PslipCRDNo", SqlDbType.NVarChar, 15)
        paraCRD.Value = SwCreditNO.Text
        mySqlComm.Parameters.Add(paraCRD)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Credit Invoice Info.: " & ex.Message)
        End Try


        'Create the new MPO with the RMA or IR No and put it in Quarantine department  205 
        Dim mySql As New Data.SqlClient.SqlCommand("cspUpdateMpoRmaIR", cn)
        mySql.CommandType = CommandType.StoredProcedure

        Dim paraMpoOld As SqlParameter = New SqlParameter("@FindMpo", SqlDbType.NVarChar, 25)
        paraMpoOld.Value = Trim(CmbMPO.Text)
        mySql.Parameters.Add(paraMpoOld)

        Dim paraMpoNew As SqlParameter = New SqlParameter("@MpoNo", SqlDbType.NVarChar, 25)
        paraMpoNew.Value = Trim(CmbMPO.Text) + "-" + SwTRText.Text + Trim(SwTrNo.Text)
        mySql.Parameters.Add(paraMpoNew)

        'Dim paraParent As SqlParameter = New SqlParameter("@MpoParent", SqlDbType.NVarChar, 15)
        'paraParent.Value = Trim(CmbMPO.Text)
        'mySql.Parameters.Add(paraParent)

        Dim paraChild As SqlParameter = New SqlParameter("@MpoChild", SqlDbType.NVarChar, 10)
        paraChild.Value = SwTRText.Text + Trim(SwTrNo.Text)
        mySql.Parameters.Add(paraChild)

        Dim paraDateMpoNew As SqlParameter = New SqlParameter("@MpoDate", SqlDbType.SmallDateTime, 4)
        paraDateMpoNew.Value = Now.ToShortDateString
        mySql.Parameters.Add(paraDateMpoNew)

        Dim paraStatus As SqlParameter = New SqlParameter("@MpoStatus", SqlDbType.NVarChar, 10)
        paraStatus.Value = "Active"
        mySql.Parameters.Add(paraStatus)

        Dim paraQtyActual As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQtyActual.Value = Val(txtPSlipQty.Text) * -1
        mySql.Parameters.Add(paraQtyActual)

        Dim paraQtyEng As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
        paraQtyEng.Value = Val(txtPSlipQty.Text) * -1
        mySql.Parameters.Add(paraQtyEng)

        Dim paraSalesNew As SqlParameter = New SqlParameter("@QtyOrder", SqlDbType.Real, 4)
        paraSalesNew.Value = Val(txtPSlipQty.Text) * -1
        mySql.Parameters.Add(paraSalesNew)

        Dim paraWeight As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
        paraWeight.Value = 0
        mySql.Parameters.Add(paraWeight)

        Dim paraNotesMpoNew As SqlParameter = New SqlParameter("@MpoNotesNew", SqlDbType.NVarChar, 1000)
        paraNotesMpoNew.Value = vbCrLf + "Mpo RMA/IR - See initial Mpo Number: " + Trim(CmbMPO.Text)
        mySql.Parameters.Add(paraNotesMpoNew)

        Dim paraRMAText As SqlParameter = New SqlParameter("@MpoRmaIrText", SqlDbType.NVarChar, 10)
        paraRMAText.Value = SwTRText.Text
        mySql.Parameters.Add(paraRMAText)

        Dim paraRMANo As SqlParameter = New SqlParameter("@MpoRmaIrNo", SqlDbType.NVarChar, 10)
        paraRMANo.Value = SwTrNo.Text
        mySql.Parameters.Add(paraRMANo)


        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySql.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("New MPO RMA/IR: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateCreditInvoice()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvoiceCredit", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtInvNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraType As SqlParameter = New SqlParameter("@PslipType", SqlDbType.NVarChar, 5)
        paraType.Value = "CRD"
        mySqlComm.Parameters.Add(paraType)

        Dim paraDate As SqlParameter = New SqlParameter("@InvDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraDate)

        Dim paraNotes As SqlParameter = New SqlParameter("@InvNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = txtInvNotes.Text
        mySqlComm.Parameters.Add(paraNotes)

        Dim paraQtyCRD As SqlParameter = New SqlParameter("@SwQtyCRD", SqlDbType.Real, 4)
        paraQtyCRD.Value = txtPSlipQty.Text
        mySqlComm.Parameters.Add(paraQtyCRD)

        Dim paraTextCh1 As SqlParameter = New SqlParameter("@SwTextCh1", SqlDbType.NVarChar, 50)
        paraTextCh1.Value = Trim(txtCharge1.Text)
        mySqlComm.Parameters.Add(paraTextCh1)

        Dim paraTextCh2 As SqlParameter = New SqlParameter("@SwTextCh2", SqlDbType.NVarChar, 50)
        paraTextCh2.Value = Trim(txtCharge2.Text)
        mySqlComm.Parameters.Add(paraTextCh2)

        Dim paraTextCh3 As SqlParameter = New SqlParameter("@SwTextCh3", SqlDbType.NVarChar, 50)
        paraTextCh3.Value = Trim(txtCharge3.Text)
        mySqlComm.Parameters.Add(paraTextCh3)

        Dim paraGL1 As SqlParameter = New SqlParameter("@SwGL1", SqlDbType.NVarChar, 25)
        paraGL1.Value = CmbGL1.Text
        mySqlComm.Parameters.Add(paraGL1)

        Dim paraGL2 As SqlParameter = New SqlParameter("@SwGL2", SqlDbType.NVarChar, 25)
        paraGL2.Value = CmbGL2.Text
        mySqlComm.Parameters.Add(paraGL2)

        Dim paraGL3 As SqlParameter = New SqlParameter("@SwGL3", SqlDbType.NVarChar, 25)
        paraGL3.Value = CmbGL3.Text
        mySqlComm.Parameters.Add(paraGL3)

        Dim paraValCh1 As SqlParameter = New SqlParameter("@SwValCh1", SqlDbType.Real, 4)
        paraValCh1.Value = CDbl(txtValCh1.Text)
        mySqlComm.Parameters.Add(paraValCh1)

        Dim paraValCh2 As SqlParameter = New SqlParameter("@SwValCh2", SqlDbType.Real, 4)
        paraValCh2.Value = CDbl(txtValCh2.Text)
        mySqlComm.Parameters.Add(paraValCh2)

        Dim paraValCh3 As SqlParameter = New SqlParameter("@SwValCh3", SqlDbType.Real, 4)
        paraValCh3.Value = CDbl(txtValCh3.Text)
        mySqlComm.Parameters.Add(paraValCh3)

        Dim paraCRD As SqlParameter = New SqlParameter("@PslipCRDNo", SqlDbType.NVarChar, 15)
        paraCRD.Value = SwCreditNO.Text
        mySqlComm.Parameters.Add(paraCRD)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Credit Invoice Info.: " & ex.Message)
        End Try


        'create the adj tranz
        Dim mySql As New Data.SqlClient.SqlCommand("cspUpdateRelTranzAdjFP", cn)
        mySql.CommandType = CommandType.StoredProcedure

        Dim paraSwFind As SqlParameter = New SqlParameter("@FindRelNo", SqlDbType.NVarChar, 15)
        paraSwFind.Value = txtInvNo.Text
        mySql.Parameters.Add(paraSwFind)

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMPO.SelectedValue
        mySql.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 3
        mySql.Parameters.Add(paraTrOper)

        Dim paraTrStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
        paraTrStatus.Value = "O"
        mySql.Parameters.Add(paraTrStatus)

        Dim paraTypeSt As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
        paraTypeSt.Value = "FP"
        mySql.Parameters.Add(paraTypeSt)

        Dim paraTrDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraTrDate.Value = Now.ToShortDateString
        mySql.Parameters.Add(paraTrDate)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
        paraQty.Value = Val(txtPSlipQty.Text) * -1
        mySql.Parameters.Add(paraQty)

        Dim paraStComm As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 500)
        paraStComm.Value = "Qty Return to FP Inventory After the Credit Inv#:" + CmbPslip.Text
        mySql.Parameters.Add(paraStComm)

        Try
            cn.Open()
            mySql.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Info.: " & ex.Message)
        End Try

        'update stock FP with tranz
        CallClass.UpdateMatlStock("cspUpdatetblStockFP")

    End Sub


    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        If Len(Trim(CmbPslip.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to Print.")
        Else
            Dim II As Integer = 0
            For II = 0 To 1000
                II = II + 1
            Next

            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptLisiInvoice()

            rptPO.Load("..\rptLisiInvoice.rpt")
            pdvPslipNo.Value = CmbPslip.Text
            pvCollection.Add(pdvPslipNo)

            rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()

            rptPO.Close()
            rptPO.Dispose()

        End If
    End Sub

    Sub UpdateDelivPrizeINCustOrder(ByVal strPar As Integer)

        Try
            Dim mySqlPr As New Data.SqlClient.SqlCommand("cspUpdateInvDeliveryPrize", cn)
            mySqlPr.CommandType = CommandType.StoredProcedure

            Dim paraOrdDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraOrdDelivID.Value = Val(SwTxtOrdDelivID.Text)
            mySqlPr.Parameters.Add(paraOrdDelivID)

            Dim paraSw As SqlParameter = New SqlParameter("@DelivPrize", SqlDbType.Int, 4)
            paraSw.Value = strPar
            mySqlPr.Parameters.Add(paraSw)

            Try
                cn.Open()
                mySqlPr.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Delivery Prize " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Delivery Prize " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateBookingAdkQtyLNAOnly()

        DeltaQty = ""

        DeltaQty = Val(MsgDelivQty) - Val(MsgShippedQty)

        If DeltaQty = 0 Then
            Exit Sub
        Else

            DeltaQty = DeltaQty * -1

            'If DeltaQty > 0 Then        '  means that I shipped less so the booking adj will be - DeltaQty
            '    DeltaQty = DeltaQty * -1
            'Else
            '    If DeltaQty < 0 Then    '  menas that I shipped more so the booking adj witl be + DeltaQty
            '        DeltaQty = DeltaQty * -1
            '    End If
            'End If

            OrderItemsID = CallClass.ReturnStrWithParString("cspReturnCustOrderItemID", CInt(SwTxtOrdDelivID.Text))

            Try
                Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateOrderEntryLNABookingAdj", cn)
                mySqlComm.CommandType = CommandType.StoredProcedure

                Dim parItemsID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
                parItemsID.Value = OrderItemsID
                mySqlComm.Parameters.Add(parItemsID)


                Dim parDelivDate As SqlParameter = New SqlParameter("@DelivDate", SqlDbType.SmallDateTime, 4)
                parDelivDate.Value = Now().ToShortDateString
                mySqlComm.Parameters.Add(parDelivDate)

                Dim parDelivQty As SqlParameter = New SqlParameter("@DelivQty", SqlDbType.Real, 4)
                parDelivQty.Value = DeltaQty
                mySqlComm.Parameters.Add(parDelivQty)

                Dim parDelivType As SqlParameter = New SqlParameter("@DelivType", SqlDbType.NVarChar, 25)
                parDelivType.Value = "Confirmed"
                mySqlComm.Parameters.Add(parDelivType)

                Dim parDelivStatus As SqlParameter = New SqlParameter("@DelivStatus", SqlDbType.NVarChar, 10)
                parDelivStatus.Value = "Closed"
                mySqlComm.Parameters.Add(parDelivStatus)

                Dim parDelivDermDate As SqlParameter = New SqlParameter("@DelivFermDate", SqlDbType.SmallDateTime, 4)
                parDelivDermDate.Value = Now.ToShortDateString
                mySqlComm.Parameters.Add(parDelivDermDate)

                Dim parDelivNotes As SqlParameter = New SqlParameter("@DelivNotes", SqlDbType.NVarChar, 100)
                parDelivNotes.Value = "LNA - Booking Adjustment"
                mySqlComm.Parameters.Add(parDelivNotes)

                Try
                    cn.Open()
                    mySqlComm.ExecuteNonQuery()
                    cn.Close()
                Catch ex As SqlException
                    MsgBox("Update LNA Booking Adjustment - ERROR " & ex.Message)
                End Try
            Catch ex As Exception
                MsgBox("Update LNA Booking Adjustment - ERROR " & ex.Message)
            Finally
                cn.Close()
            End Try

        End If

    End Sub

    Sub UpdateDeliveryStatus()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvDeliveryStatus", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraID.Value = Val(SwTxtOrdDelivID.Text)
            mySqlComm.Parameters.Add(paraID)

            Dim paraStatus As SqlParameter = New SqlParameter("@DelivStatus", SqlDbType.NVarChar, 10)
            paraStatus.Value = "Closed"
            mySqlComm.Parameters.Add(paraStatus)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Delivery Status - Closed " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Delivery Status - Closed " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub cmdCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCredit.Click

        If txtDocNo.Text = "Close" Then
            MsgBox("!!! ERROR !!! Document Type <> Invoice!")
            cmdCredit.Enabled = False
            Exit Sub
        End If

        DisableFields()
        CmdSave.Enabled = True
        cmdEdit.Enabled = False
        CmdPrint.Enabled = False
        CmdReset.Enabled = True
        cmdCredit.Enabled = False

        txtPSlipQty.Text = txtPSlipQty.Text * -1
        txtPSlipQty.BackColor = Color.LightBlue

        txtCharge1.ReadOnly = False
        txtCharge2.ReadOnly = False
        txtCharge3.ReadOnly = False
        CmbGL1.Enabled = True
        CmbGL2.Enabled = True
        CmbGL3.Enabled = True

        txtValCh1.ReadOnly = False
        txtValCh2.ReadOnly = False
        txtValCh3.ReadOnly = False

        CalculInvoice()

        txtInvNotes.ReadOnly = False
        txtInvNotes.Text = txtInvNotes.Text + vbCrLf + _
                "Credit Invoice No.: " + CmbPslip.Text
        SwCreditNO.Text = CmbPslip.Text

        txtPSlipQty.ReadOnly = False

        '=====================================================
        'PARTIAL DISABLE


        frmSalesInvoiceNotesCredit.txtInv.Text = ""
        frmSalesInvoiceNotesCredit.txtPrice.Text = ""
        frmSalesInvoiceNotesCredit.txtQty.Text = ""
        frmSalesInvoiceNotesCredit.txtCreditAmount.Text = ""
        frmSalesInvoiceNotesCredit.txtRMA.Text = ""
        frmSalesInvoiceNotesCredit.txtNotes.Text = ""

        frmSalesInvoiceNotesCredit.txtPrice.Enabled = False
        frmSalesInvoiceNotesCredit.txtQty.Enabled = False
        frmSalesInvoiceNotesCredit.txtCreditAmount.Enabled = False

        With frmSalesInvoiceNotesCredit.CmbMPO
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoNoFromFP").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

        frmSalesInvoiceNotesCredit.CmbMPO.Text = ""

        frmSalesInvoiceNotesCredit.txtInv.Text = CmbPslip.Text
        frmSalesInvoiceNotesCredit.CmbMPO.SelectedValue = CmbMPO.SelectedValue
        frmSalesInvoiceNotesCredit.txtPrice.Text = txtSalesPrice.Text

        frmSalesInvoiceNotesCredit.txtQty.Text = txtPSlipQty.Text
        frmSalesInvoiceNotesCredit.txtQty.Enabled = True

        frmSalesInvoiceNotesCredit.txtCreditAmount.Enabled = True


        frmSalesInvoiceNotesCredit.CmdExec.Enabled = True

        frmSalesInvoiceNotesCredit.ShowDialog()

        CalculInvoice()

        '==========================================================

    End Sub

    Private Sub txtPSlipQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPSlipQty.Validating
        CalculInvoice()
    End Sub

    'Private Sub CmbGL1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbGL1.SelectedIndexChanged

    '    If IsNothing(CmbGL1.SelectedItem) = True Or Len(Trim(CmbGL1.Text)) = 0 Then
    '        txtCharge1.Text = ""
    '    Else
    '        txtCharge1.Text = CmbGL1.SelectedItem("CompteDescr")
    '    End If

    'End Sub

    'Private Sub CmbGL2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbGL2.SelectedIndexChanged
    '    If IsNothing(CmbGL2.SelectedItem) = True Or Len(Trim(CmbGL2.Text)) = 0 Then
    '        txtCharge2.Text = ""
    '    Else
    '        txtCharge2.Text = CmbGL2.SelectedItem("CompteDescr")
    '    End If

    'End Sub

    'Private Sub CmbGL3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbGL3.SelectedIndexChanged
    '    If IsNothing(CmbGL3.SelectedItem) = True Or Len(Trim(CmbGL3.Text)) = 0 Then
    '        txtCharge3.Text = ""
    '    Else
    '        txtCharge3.Text = CmbGL3.SelectedItem("CompteDescr")
    '    End If
    'End Sub

    Private Sub CmbGL1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbGL1.Validating
        If IsNothing(CmbGL1.SelectedItem) = True Or Len(Trim(CmbGL1.Text)) = 0 Then
            txtCharge1.Text = ""
        Else
            txtCharge1.Text = CmbGL1.SelectedItem("CompteDescr")
        End If
    End Sub

    Private Sub CmbGL2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbGL2.Validating
        If IsNothing(CmbGL2.SelectedItem) = True Or Len(Trim(CmbGL2.Text)) = 0 Then
            txtCharge2.Text = ""
        Else
            txtCharge2.Text = CmbGL2.SelectedItem("CompteDescr")
        End If
    End Sub

    Private Sub CmbGL3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbGL3.Validating
        If IsNothing(CmbGL3.SelectedItem) = True Or Len(Trim(CmbGL3.Text)) = 0 Then
            txtCharge3.Text = ""
        Else
            txtCharge3.Text = CmbGL3.SelectedItem("CompteDescr")
        End If
    End Sub

End Class