Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSalesPSlip

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwDisable As Boolean = False
    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Private Sub frmSalesPSlip_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        If Len(Trim(SwOper)) <> 0 Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub
    
    Private Sub frmSalesPSlip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        cmdReturn.Visible = False

        CmdSave.Enabled = False
        CmdEdit.Enabled = False
        CmdPrint.Enabled = False
        CmdEmail.Enabled = False
        CmdBoeing.Enabled = False


        RdInv.Checked = False
        RdReq.Checked = True


        DisableFields()

        VerifyRadioBtn()

        InitialComponents()

        PutCoCAppr()

        PutCustomer()
        PutShipVia()
        PutmpoMaster()

        DisableBarCode()

        CmbDelNo.SelectedIndex = -1

    End Sub

    Sub DisableBarCode()

        Rd39.Checked = True
        RdPDF417.Checked = False

        Rd39.Enabled = False
        RdPDF417.Enabled = False
        CmdBar.Enabled = False

        txtNoBox.ReadOnly = True
        txtNoBox.Text = ""

    End Sub
    Sub VerifyRadioBtn()

        If RdReq.Checked = True Then
            PutReqNo()
        Else
            PutInvNo()
        End If

        CmbDelNo.Enabled = True

    End Sub
    Sub DisableFields()

        txtDocNo.ReadOnly = True
        txtPosted.ReadOnly = True
        txtInvShortName.ReadOnly = True

        ShipName.ReadOnly = True
        Shiptext.ReadOnly = True
        ShipAddress.ReadOnly = True
        ShipCity.ReadOnly = True
        ShipProv.ReadOnly = True
        ShipCode.ReadOnly = True
        ShipCountry.ReadOnly = True

        InvName.ReadOnly = True
        InvText.ReadOnly = True
        InvAddress.ReadOnly = True
        InvCity.ReadOnly = True
        InvProv.ReadOnly = True
        InvCode.ReadOnly = True
        InvCountry.ReadOnly = True

        CmbCust.Enabled = False
        txtCustRef.ReadOnly = True
        txtCustOrder.ReadOnly = True
        txtDateCustOrder.ReadOnly = True
        txtOrderNotes.ReadOnly = True

        txtItemNo.ReadOnly = True
        txtPartNo.ReadOnly = True
        txtMMITDS.ReadOnly = True
        txtPartName.ReadOnly = True
        txtSalesPrice.ReadOnly = True
        txtLateRev.ReadOnly = True
        txtQtyToShip.ReadOnly = True


        CmbMPO.Enabled = False
        txtMPOPartRev.ReadOnly = True
        txtCOCRev.ReadOnly = True
        txtCustCOCRev.ReadOnly = True

        txtFPQty.ReadOnly = True

        txtPslipDate.ReadOnly = True
        txtBillNo.ReadOnly = True
        txtBoxNo.ReadOnly = True
        txtWeight.ReadOnly = True
        txtPSlipQty.ReadOnly = True
        cmbVia.Enabled = False
        txtViaNotes.ReadOnly = True

        cmbSig.Enabled = False
        txtPslipNo.ReadOnly = True

        txtPslipNotes.ReadOnly = True

        txtWSHE.ReadOnly = True
        txtBoeingPO.ReadOnly = True
        txtM3Code.ReadOnly = True

    End Sub

    Sub FirstTimeMenuButtons()

        CmbDelNo.Enabled = False

        CmdEdit.Enabled = False
        CmdSave.Enabled = False

        CmdReset.Enabled = True

        CmdPrint.Enabled = False
        CmdEmail.Enabled = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutCoCAppr()

        With cmbSig
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetCoCAppr").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub PutReqNo()

        With CmbDelNo
            .DataSource = CallClass.PopulateComboBox("tblLisiPslip", "cmbGetDelivReq").Tables("tblLisiPslip")
            .DisplayMember = "PslipNo"
            .ValueMember = "PSlipID"
        End With

    End Sub

    Sub PutInvNo()

        With CmbDelNo
            .DataSource = CallClass.PopulateComboBox("tblLisiPslip", "cmbGetDelivInvoice").Tables("tblLisiPslip")
            .DisplayMember = "PslipNo"
            .ValueMember = "PSlipID"
        End With

    End Sub

    Sub PutCustomer()

        With Me.cmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
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

    Sub BindComponents()

        txtDocNo.DataBindings.Clear()
        txtPosted.DataBindings.Clear()
        txtInvShortName.DataBindings.Clear()

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
        txtCustRef.DataBindings.Clear()
        txtCustOrder.DataBindings.Clear()
        txtDateCustOrder.DataBindings.Clear()
        txtOrderNotes.DataBindings.Clear()

        txtItemNo.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtCustPart.DataBindings.Clear()
        txtMMITDS.DataBindings.Clear()
        txtPartName.DataBindings.Clear()

        txtLateRev.DataBindings.Clear()
        txtQtyToShip.DataBindings.Clear()
        txtPoDelivNo.DataBindings.Clear()
        txtOrdDelivDate.DataBindings.Clear()


        CmbMPO.DataBindings.Clear()

        txtMPOPartRev.DataBindings.Clear()
        txtCOCRev.DataBindings.Clear()
        txtCustCOCRev.DataBindings.Clear()

        txtFPQty.DataBindings.Clear()

        txtPslipDate.DataBindings.Clear()
        txtBillNo.DataBindings.Clear()
        txtBoxNo.DataBindings.Clear()
        txtWeight.DataBindings.Clear()
        txtPSlipQty.DataBindings.Clear()
        cmbVia.DataBindings.Clear()
        txtViaNotes.DataBindings.Clear()
        SwTxtViaNotes.DataBindings.Clear()

        cmbSig.DataBindings.Clear()
        txtPslipNo.DataBindings.Clear()

        txtPslipNotes.DataBindings.Clear()

        txtSalesPrice.DataBindings.Clear()

        txtWSHE.DataBindings.Clear()
        txtBoeingPO.DataBindings.Clear()
        txtM3Code.DataBindings.Clear()


        txtDocNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipType")
        txtPosted.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvPosted")
        txtInvShortName.DataBindings.Add("Text", dsMain, "tblLisiPslip.InvShortName")

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

        CmbCust.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.CustID")
        CmbMPO.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.PSlipMpoID")

        txtMPOPartRev.DataBindings.Add("Text", dsMain, "tblLisiPslip.MpoPartRev")
        '==================
        txtCOCRev.DataBindings.Add("Text", dsMain, "tblLisiPslip.CoCPartRev")

        txtCustCOCRev.DataBindings.Add("Text", dsMain, "tblLisiPslip.CustCoCRev")
        '==================
        txtFPQty.DataBindings.Add("Text", dsMain, "tblLisiPslip.StFinal")

        txtCustRef.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipOrdRefNo")
        txtCustOrder.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipCustPOContr")
        txtDateCustOrder.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipDatePOContr", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtOrderNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.NotesOrder")

        txtItemNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipItem")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PartNumber")
        txtCustPart.DataBindings.Add("Text", dsMain, "tblLisiPslip.CustPartNumber")
        txtMMITDS.DataBindings.Add("Text", dsMain, "tblLisiPslip.MMITDS")
        txtPartName.DataBindings.Add("Text", dsMain, "tblLisiPslip.PartName")
        txtQtyToShip.DataBindings.Add("Text", dsMain, "tblLisiPslip.ReqQty")

        txtPoDelivNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PoNoDeliv")
        txtOrdDelivDate.DataBindings.Add("Text", dsMain, "tblLisiPslip.DelivDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

        txtViaNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipViaNotes")

        SwTxtViaNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.ShipNotes")        ' ship notes

        txtPartID.DataBindings.Clear()
        txtPartID.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipPartID")

        txtCustPartID.DataBindings.Clear()
        txtCustPartID.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipCustPartID")

        txtPslipDate.DataBindings.Add("Text", dsMain, "tblLisiPslip.PSlipDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtBillNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipTrackingNo")
        txtWeight.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipWeight")
        txtBoxNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipPackNo")
        txtPSlipQty.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipQty")
        cmbVia.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.PslipViaID")
        cmbSig.DataBindings.Add("SelectedValue", dsMain, "tblLisiPslip.PSlipSigID")
        txtPslipNotes.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipNotes")
        txtPslipNo.DataBindings.Add("Text", dsMain, "tblLisiPslip.PslipNo")
        txtSalesPrice.DataBindings.Add("Text", dsMain, "tblLisiPslip.OrdItemPrice", True, DataSourceUpdateMode.OnValidation, "", "C4")

        txtWSHE.DataBindings.Add("Text", dsMain, "tblLisiPslip.CO_WSHE")
        txtBoeingPO.DataBindings.Add("Text", dsMain, "tblLisiPslip.CO_CustPO")
        txtM3Code.DataBindings.Add("Text", dsMain, "tblLisiPslip.CO_ITNO")

    End Sub

    Private Sub CmbDelNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDelNo.Click
        VerifyRadioBtn()
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        GC.Collect()

        CallReset()
    End Sub

    Sub CallReset()

        SwOper = ""

        If CmbDelNo.SelectedValue <> 0 Then
            dsMain.Clear()
            BindComponents()
            CmbDelNo.SelectedIndex = -1
            CmbDelNo.Enabled = True
            CmdSave.Enabled = False
            cmdReturn.Visible = False
            CmdEdit.Enabled = False
            CmdEmail.Enabled = False
            CmdBoeing.Enabled = False

            RdInv.Enabled = True
            RdReq.Enabled = True

            txtPslipNo.Text = ""
            txtLateRev.Text = ""

            txtMPOPartRev.Text = ""
            txtCOCRev.Text = ""
            txtCOCRev.ReadOnly = True

            txtCustCOCRev.Text = ""
            txtCustCOCRev.ReadOnly = True

            txtFPQty.Text = ""
            CmdPrint.Enabled = False
            CmdEmail.Enabled = False
            CmbMPO.SelectedIndex = -1
            CmbMPO.Enabled = False

            Me.ErrorProvider1.Clear()

            ClearPSlip()

            DisablePslip()

            txtPSlipQty.BackColor = Color.LightGray
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        Call VerifyStatus()

    End Sub

    Sub VerifyStatus()

        CmbDelNo.Enabled = False

        CmdEdit.Enabled = False

        If Len(Trim(txtCOCRev.Text)) = 0 Or IsDBNull(txtCOCRev.Text) Then
            txtCOCRev.Text = txtMPOPartRev.Text
            txtMPOPartRev.ReadOnly = True
        End If

        '==============================================

        If txtPartID.Text = txtCustPartID.Text Then
            txtCustCOCRev.Text = txtMPOPartRev.Text
        Else
            If Len(Trim(txtCustPartID.Text)) <> 0 Then
                If Len(Trim(txtCustCOCRev.Text)) = 0 Then
                    txtCustCOCRev.Text = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRev", txtCustPartID.Text)
                    If txtCustCOCRev.Text = "False" Then
                        txtCustCOCRev.Text = ""
                    End If
                End If
            Else
                txtCustCOCRev.Text = ""
            End If
        End If

        txtCustCOCRev.ReadOnly = False

        '================================================


        SwDisable = False

        Me.ErrorProvider1.Clear()

        If Trim(txtLateRev.Text) <> Trim(txtCOCRev.Text) Then
            Me.ErrorProvider1.SetError(txtMPOPartRev, "MPO Part Number Revision is different from the latest Part Number revision. Please Contact the Engineering Department.")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink

            '------------modify april 27, 2007    SwDisable = True to false
            SwDisable = False

            txtCOCRev.ReadOnly = False
        End If

        If txtDocNo.Text = "REQ" Then
            txtPSlipQty.ReadOnly = False
            cmdReturn.Visible = False
            SwOper = "NEW"
            If SwDisable = True Then
                DisablePslip()
                SwDisable = False
            Else
                EnablePslip()
            End If
        Else
            If txtDocNo.Text = "PSlip" Then
                txtPSlipQty.ReadOnly = True
                cmdReturn.Visible = True
                cmdReturn.Enabled = True
                SwOper = "MOD"
                If SwDisable = True Then
                    DisablePslip()
                    SwDisable = False
                Else
                    EnablePslip()
                End If
            Else
                If txtDocNo.Text = "Inv" Then
                    txtPSlipQty.ReadOnly = True
                    cmdReturn.Visible = True
                    cmdReturn.Enabled = True
                    SwOper = "Inv"
                    If SwDisable = True Then
                        DisablePslip()
                        SwDisable = False
                    Else
                        EnablePslip()
                    End If
                Else
                    cmdReturn.Visible = False
                    DisablePslip()
                End If
            End If
        End If

        CreatePSlip()

        VerifyLastRev()

        CmdPrint.Enabled = False
        CmdEmail.Enabled = False

    End Sub

    Sub DisablePslip()
        CmdSave.Enabled = False

        txtPslipDate.ReadOnly = True
        txtBillNo.ReadOnly = True
        txtBoxNo.ReadOnly = True
        txtWeight.ReadOnly = True
        'txtCOCRev.ReadOnly = True
        'txtPSlipQty.ReadOnly = True
        txtViaNotes.ReadOnly = True
        txtPslipNotes.ReadOnly = True
        cmbVia.Enabled = False
        cmbSig.Enabled = False

    End Sub

    Sub EnablePslip()

        txtPslipDate.ReadOnly = False
        txtBillNo.ReadOnly = False
        txtBoxNo.ReadOnly = False
        txtWeight.ReadOnly = False

        txtViaNotes.ReadOnly = False
        txtPslipNotes.ReadOnly = False
        cmbVia.Enabled = True
        cmbSig.Enabled = True

        CmdSave.Enabled = True
        CmdEmail.Enabled = False

    End Sub

    Sub ClearPSlip()
        txtPslipDate.Text = ""
        txtBillNo.Text = ""
        txtBoxNo.Text = ""
        txtWeight.Text = ""
        txtPSlipQty.Text = ""
        cmbVia.SelectedIndex = -1

    End Sub

    Sub CreatePSlip()
        If Len(Trim(Nz.Nz(txtPslipDate.Text))) = 0 Then
            txtPslipDate.Text = Now.ToShortDateString
        End If

        If Len(Trim(Nz.Nz(txtPSlipQty.Text))) = 0 Then
            If Val(txtFPQty.Text) >= Val(txtQtyToShip.Text) Then
                txtPSlipQty.Text = txtQtyToShip.Text
            Else
                txtPSlipQty.Text = txtFPQty.Text
            End If
        End If

        If txtPSlipQty.ReadOnly = False Then
            txtPSlipQty.BackColor = Color.LightSkyBlue
        Else
            txtPSlipQty.BackColor = Color.LightGray
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                dsMain.GetChanges()
                UpdateDelivReq()

                If SwOper = "NEW" Then
                    UpdateTranzFP()

                    CallClass.UpdateMatlStock("cspUpdatetblStockFP")

                    'return the stock FP for MPO
                    txtFPQty.DataBindings.Clear()
                    txtFPQty.Text = CallClass.ReturnStrWithParInt("cspReturnMPOFPQty", CmbMPO.SelectedValue)

                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()

                End If

                SwOper = ""

                CmdPrint.Enabled = True
                CmdEmail.Enabled = True
                cmdReturn.Visible = False

                CmdBoeing.Enabled = True
                EnableBarCode()

            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - REQ: " & ex.Message)
            End Try

            CmdSave.Enabled = False
            CmdEmail.Enabled = True
            CmdBoeing.Enabled = False

            DisableFields()

            If Trim(txtDocNo.Text) = "REQ" Then
                txtDocNo.Text = "PSlip"
            End If

        End If

    End Sub

    Sub UpdateDelivReq()

        If SwOper = "Posted" Or SwOper = "Inv" Then
            UpdatePosted()
        Else
            UpdatePslipInfo()
        End If

    End Sub

    Sub UpdatePosted()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateInvposted", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtPslipNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraDate As SqlParameter = New SqlParameter("@PslipDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = txtPslipDate.Text
        mySqlComm.Parameters.Add(paraDate)

        Dim paraBillNo As SqlParameter = New SqlParameter("@PslipTrackingNo", SqlDbType.NVarChar, 100)
        paraBillNo.Value = txtBillNo.Text
        mySqlComm.Parameters.Add(paraBillNo)

        Dim paraBoxNo As SqlParameter = New SqlParameter("@PslipPackNo", SqlDbType.NVarChar, 15)
        paraBoxNo.Value = txtBoxNo.Text
        mySqlComm.Parameters.Add(paraBoxNo)

        Dim paraWeight As SqlParameter = New SqlParameter("@PslipWeight", SqlDbType.NVarChar, 15)
        paraWeight.Value = txtWeight.Text
        mySqlComm.Parameters.Add(paraWeight)

        Dim paraCmbVia As SqlParameter = New SqlParameter("@PslipViaID", SqlDbType.Int, 4)
        paraCmbVia.Value = cmbVia.SelectedValue
        mySqlComm.Parameters.Add(paraCmbVia)

        Dim paraViaNotes As SqlParameter = New SqlParameter("@PslipViaNotes", SqlDbType.NVarChar, 1000)
        paraViaNotes.Value = txtViaNotes.Text
        mySqlComm.Parameters.Add(paraViaNotes)

        Dim paraPslipNotes As SqlParameter = New SqlParameter("@PSlipNotes", SqlDbType.NVarChar, 1000)
        paraPslipNotes.Value = txtPslipNotes.Text
        mySqlComm.Parameters.Add(paraPslipNotes)

        Dim paraPslipSig As SqlParameter = New SqlParameter("@PSlipSigID", SqlDbType.Int, 4)
        paraPslipSig.Value = cmbSig.SelectedValue
        mySqlComm.Parameters.Add(paraPslipSig)

        Dim paraCocRev As SqlParameter = New SqlParameter("@CoCPartRev", SqlDbType.NVarChar, 25)
        paraCocRev.Value = txtCOCRev.Text
        mySqlComm.Parameters.Add(paraCocRev)

        Dim paraCustCocRev As SqlParameter = New SqlParameter("@CustCoCRev", SqlDbType.NVarChar, 25)
        paraCustCocRev.Value = txtCustCOCRev.Text
        mySqlComm.Parameters.Add(paraCustCocRev)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Inv Posted Info.: " & ex.Message)
        End Try

    End Sub

    Sub UpdatePslipInfo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePSlipInfo", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindPSlip", SqlDbType.NVarChar, 15)
        paraFind.Value = txtPslipNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraType As SqlParameter = New SqlParameter("@PslipType", SqlDbType.NVarChar, 5)
        paraType.Value = "PSlip"
        mySqlComm.Parameters.Add(paraType)

        Dim paraDate As SqlParameter = New SqlParameter("@PslipDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = txtPslipDate.Text
        mySqlComm.Parameters.Add(paraDate)

        Dim paraBillNo As SqlParameter = New SqlParameter("@PslipTrackingNo", SqlDbType.NVarChar, 100)
        paraBillNo.Value = txtBillNo.Text
        mySqlComm.Parameters.Add(paraBillNo)

        Dim paraBoxNo As SqlParameter = New SqlParameter("@PslipPackNo", SqlDbType.NVarChar, 15)
        paraBoxNo.Value = txtBoxNo.Text
        mySqlComm.Parameters.Add(paraBoxNo)

        Dim paraWeight As SqlParameter = New SqlParameter("@PslipWeight", SqlDbType.NVarChar, 15)
        paraWeight.Value = txtWeight.Text
        mySqlComm.Parameters.Add(paraWeight)

        Dim paraPslipQty As SqlParameter = New SqlParameter("@PslipQty", SqlDbType.Real, 4)
        paraPslipQty.Value = Val(txtPSlipQty.Text)
        mySqlComm.Parameters.Add(paraPslipQty)

        Dim paraCmbVia As SqlParameter = New SqlParameter("@PslipViaID", SqlDbType.Int, 4)
        paraCmbVia.Value = cmbVia.SelectedValue
        mySqlComm.Parameters.Add(paraCmbVia)

        Dim paraViaNotes As SqlParameter = New SqlParameter("@PslipViaNotes", SqlDbType.NVarChar, 1000)
        paraViaNotes.Value = txtViaNotes.Text
        mySqlComm.Parameters.Add(paraViaNotes)

        Dim paraPslipNotes As SqlParameter = New SqlParameter("@PSlipNotes", SqlDbType.NVarChar, 1000)
        paraPslipNotes.Value = txtPslipNotes.Text
        mySqlComm.Parameters.Add(paraPslipNotes)

        Dim paraPslipSig As SqlParameter = New SqlParameter("@PSlipSigID", SqlDbType.Int, 4)
        paraPslipSig.Value = cmbSig.SelectedValue
        mySqlComm.Parameters.Add(paraPslipSig)

        Dim paraCocRev As SqlParameter = New SqlParameter("@CoCPartRev", SqlDbType.NVarChar, 25)
        paraCocRev.Value = txtCOCRev.Text
        mySqlComm.Parameters.Add(paraCocRev)

        Dim paraCustCocRev As SqlParameter = New SqlParameter("@CustCoCRev", SqlDbType.NVarChar, 25)
        paraCustCocRev.Value = txtCustCOCRev.Text
        mySqlComm.Parameters.Add(paraCustCocRev)

        Dim paraPrice As SqlParameter = New SqlParameter("@InvPrice", SqlDbType.Money, 8)
        paraPrice.Value = txtSalesPrice.Text
        mySqlComm.Parameters.Add(paraPrice)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update PSlip Info.: " & ex.Message)
        End Try

    End Sub
    Sub UpdateTranzFP()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzFP", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindRelNo", SqlDbType.NVarChar, 15)
        paraFind.Value = txtPslipNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 2
        mySqlComm.Parameters.Add(paraTrOper)

        Dim paraTrStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
        paraTrStatus.Value = "O"
        mySqlComm.Parameters.Add(paraTrStatus)

        Dim paraTypeSt As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
        paraTypeSt.Value = "FP"
        mySqlComm.Parameters.Add(paraTypeSt)

        Dim paraTrDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraTrDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraTrDate)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
        paraQty.Value = Val(txtPSlipQty.Text)
        mySqlComm.Parameters.Add(paraQty)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FPTranz Info.: " & ex.Message)
        End Try

    End Sub

    Sub ValPo()

        If Len(Trim(txtPslipDate.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Packing Slip Date is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPSlipQty.Text)) = 0 = True Or Val(txtPSlipQty.Text) = 0 Then
            MsgBox("!!! ERROR !!! Packing Slip Quantity is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPslipNo.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Packing Slip Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtWeight.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Weight.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtBoxNo.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Package Nº.")
            SwVal = False
            Exit Sub
        End If

        If cmbVia.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! Ship Via.")
            SwVal = False
            Exit Sub
        End If

        If CmbMPO.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! Mpo Nummber.")
            SwVal = False
            Exit Sub
        End If

        If cmbSig.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! COC Signature.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub cmdReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturn.Click

        Dim reply As DialogResult

        reply = MsgBox("This Action Return the Qty in FP. Do you want to Continue ?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        SwOper = "NEW"

        If Val(txtPSlipQty.Text) = 0 Then
            txtPSlipQty.ReadOnly = False

            cmdReturn.Enabled = False

            If txtPSlipQty.ReadOnly = False Then
                txtPSlipQty.BackColor = Color.LightSkyBlue
            Else
                txtPSlipQty.BackColor = Color.LightGray
            End If

            Exit Sub

        End If

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzAdjFP", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindRelNo", SqlDbType.NVarChar, 15)
        paraFind.Value = txtPslipNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 3
        mySqlComm.Parameters.Add(paraTrOper)

        Dim paraTrStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
        paraTrStatus.Value = "O"
        mySqlComm.Parameters.Add(paraTrStatus)

        Dim paraTypeSt As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
        paraTypeSt.Value = "FP"
        mySqlComm.Parameters.Add(paraTypeSt)

        Dim paraTrDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraTrDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraTrDate)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
        paraQty.Value = Val(txtPSlipQty.Text)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraStComm As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 500)
        paraStComm.Value = "Qty Return to FP from PSlip Module"
        mySqlComm.Parameters.Add(paraStComm)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Info.: " & ex.Message)
        End Try

        'update stock FP with tranz
        CallClass.UpdateMatlStock("cspUpdatetblStockFP")

        'return the stock FP for MPO
        txtFPQty.DataBindings.Clear()
        txtFPQty.Text = CallClass.ReturnStrWithParInt("cspReturnMPOFPQty", CmbMPO.SelectedValue)

        'init qty pslip in database AND CHANGE THE TYPE TO REQ
        txtPSlipQty.Text = 0
        txtPSlipQty.ReadOnly = False
        txtPslipNo.DataBindings.Clear()
        txtDocNo.DataBindings.Clear()
        txtDocNo.Text = "REQ"

        Dim mySql As New Data.SqlClient.SqlCommand("cspUpdatetblLisiPSlipInitQty", cn)
        mySql.CommandType = CommandType.StoredProcedure

        Dim paraNo As SqlParameter = New SqlParameter("@FindRelNo", SqlDbType.NVarChar, 15)
        paraNo.Value = txtPslipNo.Text
        mySql.Parameters.Add(paraNo)

        Try
            cn.Open()
            mySql.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update tblLisiPSlip Init Qty: " & ex.Message)
        End Try

        txtPSlipQty.ReadOnly = False

        cmdReturn.Enabled = False

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        If Len(Trim(txtPslipNo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to Print.")
            Exit Sub
        End If


        If Trim(txtDocNo.Text) = "PSlip" Or Trim(txtDocNo.Text) = "Inv" Then
            Dim SwEndUser As String = ""
            SwEndUser = CallClass.ReturnStrWithParInt("cspReturnMpoEndUserClient", CmbMPO.SelectedValue)
            If SwEndUser = "False" Then
                PrintNormalCOC()
            Else
                If InStr(1, SwEndUser, "Honey", vbTextCompare) <> 0 Or _
                        InStr(1, SwEndUser, "SNECMA", vbTextCompare) <> 0 Or _
                        InStr(1, SwEndUser, "PRATT", vbTextCompare) <> 0 Or _
                        InStr(1, SwEndUser, "GE AIRCRAFT", vbTextCompare) <> 0 Or _
                        InStr(1, SwEndUser, "MEGGITT", vbTextCompare) <> 0 Then

                    PrintHoneywellCOC()
                Else
                    ' If InStr(1, SwEndUser, "Boeing", vbTextCompare) <> 0 And InStr(1, txtInvShortName.Text, "LNA", vbTextCompare) <> 0 Then     'DO Boeing LNA  -  no export delivery PDF

                    '(InStr(1, txtPartNo.Text, "BACB30US", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB31G", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30Y", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30UU", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30LE", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30MR", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30MY", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NM", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NR", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NW", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NX", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NZ", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30UW", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30WP", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30XN", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB31B", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "XBACB31", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB31AD", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NX", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "BACB30NX", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT420", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT421", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT422", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT423", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT620", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT621", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT622", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT623", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT714", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT715", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT716", vbTextCompare) <> 0 Or _
                    '   InStr(1, txtPartNo.Text, "HLT717", vbTextCompare) <> 0) Then

                    If InStr(1, txtInvShortName.Text, "LNA", vbTextCompare) <> 0 And _
                        (InStr(1, txtPartNo.Text, "BACB30", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "BACB31", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "XBACB", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT420", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT421", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT422", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT423", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT620", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT621", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT622", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT623", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT714", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT715", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT716", vbTextCompare) <> 0 Or _
                        InStr(1, txtPartNo.Text, "HLT717", vbTextCompare) <> 0) Then
                        PrintBoeingCOC()
                    Else
                        If InStr(1, SwEndUser, "Boeing", vbTextCompare) = 0 And InStr(1, txtInvShortName.Text, "LNA", vbTextCompare) <> 0 Then  'DO MHI LNA  -  no export delivery PDF
                            PrintMHICOC()
                        Else
                            PrintNormalCOC()
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("!!! ERROR !!! You Should first generate the PSlip.")
        End If

    End Sub

    Sub PrintNormalCOC()
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptLisiPslipCOC()

        rptPO.Load("..\rptLisiPSlipCOC.rpt")
        pdvPslipNo.Value = txtPslipNo.Text
        pvCollection.Add(pdvPslipNo)

        rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()


        '=========================================
        frmPOMasterPrint.CrystalReportViewer1.Refresh()
        Dim sSource As String = ""
        Dim sTarget As String = ""
        Dim FileNameStr As String = ""

        FileNameStr = ""
        FileNameStr = txtPslipNo.Text + "_BL_LAC.pdf"

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = "\\DCAFSP04\mom-m3-sp\pdf\" + FileNameStr

        CrExportOptions = rptPO.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        rptPO.Export()

    End Sub

    Sub PrintHoneywellCOC()
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptLisiHoneywellPslipCOC()

        rptPO.Load("..\rptLisiHoneywellPslipCOC.rpt")
        pdvPslipNo.Value = txtPslipNo.Text
        pvCollection.Add(pdvPslipNo)

        rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

        '=========================================
        frmPOMasterPrint.CrystalReportViewer1.Refresh()
        Dim sSource As String = ""
        Dim sTarget As String = ""
        Dim FileNameStr As String = ""

        FileNameStr = ""
        FileNameStr = txtPslipNo.Text + "_BL_LAC.pdf"

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = "\\DCAFSP04\mom-m3-sp\pdf\" + FileNameStr

        CrExportOptions = rptPO.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        rptPO.Export()

    End Sub

    Sub PrintBoeingCOC()
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptLisiLNABoeingPslipCOC()

        rptPO.Load("..\rptLisiLNABoeingPslipCOC.rpt")
        pdvPslipNo.Value = txtPslipNo.Text
        pvCollection.Add(pdvPslipNo)

        rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

        '=========================================
        'frmPOMasterPrint.CrystalReportViewer1.Refresh()
        'Dim sSource As String = ""
        'Dim sTarget As String = ""
        'Dim FileNameStr As String = ""

        'FileNameStr = ""
        'FileNameStr = txtPslipNo.Text + "_BL_LAC.pdf"

        'Dim CrExportOptions As ExportOptions
        'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        'CrDiskFileDestinationOptions.DiskFileName = "\\DCAFSP04\mom-m3-sp\pdf\" + FileNameStr

        'CrExportOptions = rptPO.ExportOptions
        'With CrExportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.PortableDocFormat
        '    .DestinationOptions = CrDiskFileDestinationOptions
        '    .FormatOptions = CrFormatTypeOptions
        'End With
        'rptPO.Export()

    End Sub

    Sub PrintMHICOC()
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptLisiPslipCOC()

        rptPO.Load("..\rptLisiPSlipCOC.rpt")
        pdvPslipNo.Value = txtPslipNo.Text
        pvCollection.Add(pdvPslipNo)

        rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()


        '=========================================
        'frmPOMasterPrint.CrystalReportViewer1.Refresh()
        'Dim sSource As String = ""
        'Dim sTarget As String = ""
        'Dim FileNameStr As String = ""

        'FileNameStr = ""
        'FileNameStr = txtPslipNo.Text + "_BL_LAC.pdf"

        'Dim CrExportOptions As ExportOptions
        'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        'Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        'CrDiskFileDestinationOptions.DiskFileName = "\\DCAFSP04\mom-m3-sp\pdf\" + FileNameStr

        'CrExportOptions = rptPO.ExportOptions
        'With CrExportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.PortableDocFormat
        '    .DestinationOptions = CrDiskFileDestinationOptions
        '    .FormatOptions = CrFormatTypeOptions
        'End With
        'rptPO.Export()

    End Sub

    Private Sub CmbDelNo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDelNo.DropDownClosed
        Dim strSearch As Integer
        strSearch = CmbDelNo.SelectedValue

        If strSearch <> 0 Then
            dsMain.Clear()
            Me.ErrorProvider1.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getPslipDelivReqWithSearch", strSearch).Fill(dsMain, "tblLisiPslip")

            BindComponents()

            strSearch = CmbMPO.SelectedValue

            Try
                If Year(txtPslipDate.Text) >= 2015 Then
                    If Len(Trim(txtMMITDS.Text)) = 0 Then
                        MessageBox.Show("!!! ERROR DATABASE!!!! Missing the M3 Item No. Action Denied. " + vbCrLf + "An email was sent it to IT depratment")

                        Dim email As New Mail.MailMessage()
                        Dim strBody As String
                        Dim strText As String = ""

                        strText = CmbDelNo.SelectedText
                        email.Subject = " Shipping Department  -  Missing M3 article"

                        strBody = "For the Packing Slip   " + strText
                        email.Body = strBody

                        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                        email.From = New Net.Mail.MailAddress(wkEmpEmail)
                        email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
                        'email.To.Add(New Mail.MailAddress("DORSalesLNA@lisi-aerospace.com"))
                        client.Send(email)
                        CmdEdit.Enabled = False
                        CmdSave.Enabled = False

                        Exit Sub
                    End If

                End If
            Catch ex As Exception
            End Try


            If InStr(txtPartNo.Text, "EXPEDITE", vbTextCompare) <> 0 Then
                txtSalesPrice.Text = "0.001"
            End If

            If Len(Trim(txtPartID.Text)) <> 0 Then
                txtLateRev.Text = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRev", txtPartID.Text)
                If txtLateRev.Text = "False" Then
                    txtLateRev.Text = ""
                End If
            End If

            '=============================================

            If txtPartID.Text = txtCustPartID.Text Then
                txtCustCOCRev.Text = txtMPOPartRev.Text
            Else
                If Len(Trim(txtCustPartID.Text)) <> 0 Then
                    If Len(Trim(txtCustCOCRev.Text)) = 0 Then
                        txtCustCOCRev.Text = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRev", txtCustPartID.Text)
                        If txtCustCOCRev.Text = "False" Then
                            txtCustCOCRev.Text = ""
                        End If
                    End If
                Else
                    txtCustCOCRev.Text = ""
                End If
            End If

            txtCustCOCRev.ReadOnly = False

            '============================================

            If Len(Trim(txtViaNotes.Text)) = 0 Then
                txtViaNotes.Text = SwTxtViaNotes.Text
            End If

            'VerifyLastRev() problems

            CmbDelNo.Enabled = False

            SwOper = ""

            If Trim(txtDocNo.Text) = "CRD" Then
                DisablePslip()
                txtCOCRev.ReadOnly = True
                txtCustCOCRev.ReadOnly = True
                Exit Sub
            End If

            If Nz.Nz(txtPosted.Text) = "P" Then
                cmdReturn.Visible = False
                EnablePslip()
                SwOper = "Posted"
            Else
                FirstTimeMenuButtons()
                CmdEdit.Enabled = True
            End If

            CmdPrint.Enabled = True


            RdInv.Enabled = False
            RdReq.Enabled = False



            CmdBoeing.Enabled = True
            If Trim(txtDocNo.Text) = "PSlip" Or Trim(txtDocNo.Text) = "Inv" Then
                CmdBoeing.Enabled = True
                CmdEmail.Enabled = True
                EnableBarCode()
            Else
                'CmdBoeing.Enabled = False
                CmdEmail.Enabled = False
            End If
        End If


    End Sub

    Sub EnableBarCode()

        Rd39.Checked = True
        RdPDF417.Checked = False

        Rd39.Enabled = True
        RdPDF417.Enabled = True
        CmdBar.Enabled = True

        Dim SwDate As New DateTime

        SwDate = CallClass.ReturnStrWithParInt("cspReturnMPOCloseDateWithMPOID", CmbMPO.SelectedValue)

        txtMpoCloseDate.Text = Format(SwDate, "yyyyMMdd")
        txtNoBox.ReadOnly = False
        txtNoBox.Text = ""

    End Sub

    Private Sub txtCOCRev_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCOCRev.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBillNo.Focus()
        End If
    End Sub

    Private Sub txtCOCRev_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCRev.TextChanged
        VerifyLastRev()
    End Sub

    Sub VerifyLastRev()

        Me.ErrorProvider1.Clear()

        If Nz.Nz(txtPosted.Text) <> "P" Then
            If Trim(txtLateRev.Text) <> Trim(txtCOCRev.Text) Then
                Me.ErrorProvider1.SetError(txtMPOPartRev, "MPO Part Number Revision is different from the latest Part Number revision. Please Contact the Engineering Department.")
                Me.ErrorProvider1.BlinkRate = 200
                Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            End If
            '    DisablePslip()
            '    txtCOCRev.ReadOnly = False
            'Else
            '----------- modify September 02, 2008 from TRUE to FALSE to give access to print the rev on CofC
            txtCOCRev.ReadOnly = False

            CmdSave.Enabled = True
            EnablePslip()
            'Call VerifyStatus()  problems!!!

        End If

    End Sub
    Private Sub txtPSlipQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPSlipQty.TextChanged
        Me.ErrorProvider1.Clear()

        ' Nz.Nz(txtPosted.Text) <> "P" Or

        If Trim(txtDocNo.Text) = "PSlip" Or Trim(txtDocNo.Text) = "Inv" Then
            Exit Sub
        Else
            If Val(Nz.Nz(txtPSlipQty.Text)) > Val(Nz.Nz(txtFPQty.Text)) Then
                Me.ErrorProvider1.SetError(txtPSlipQty, "!!! ERROR !!! Qty Packing Slip is Greater than Qty Stock.")
                Me.ErrorProvider1.BlinkRate = 200
                Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink

                CmdSave.Enabled = False
            Else
                CmdSave.Enabled = True

            End If
        End If
    End Sub

    Private Sub RdInv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdInv.Click
        PutInvNo()
    End Sub

    Private Sub RdReq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdReq.Click
        PutReqNo()
    End Sub

    Private Sub CmdBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBar.Click

        frmSalesPslipBarCodeLabels.ShipName.Text = Me.ShipName.Text
        frmSalesPslipBarCodeLabels.Shiptext.Text = Me.Shiptext.Text
        frmSalesPslipBarCodeLabels.ShipAddress.Text = Me.ShipAddress.Text
        frmSalesPslipBarCodeLabels.ShipCity.Text = Me.ShipCity.Text
        frmSalesPslipBarCodeLabels.ShipProv.Text = Me.ShipProv.Text
        frmSalesPslipBarCodeLabels.ShipCode.Text = Me.ShipCode.Text
        frmSalesPslipBarCodeLabels.ShipCountry.Text = Me.ShipCountry.Text

        frmSalesPslipBarCodeLabels.FromName.Text = "LISI Aerospace Canada"
        frmSalesPslipBarCodeLabels.FromText.Text = "LINK SOLUTIONS FOR INDUSTRY"
        frmSalesPslipBarCodeLabels.FromAddress.Text = "2000 Place Transcanadienne"
        frmSalesPslipBarCodeLabels.FromCity.Text = "Dorval"
        frmSalesPslipBarCodeLabels.FromProv.Text = "QC"
        frmSalesPslipBarCodeLabels.FromCode.Text = "H9P 2X5"
        frmSalesPslipBarCodeLabels.FromCountry.Text = "CANADA"
        frmSalesPslipBarCodeLabels.FromTel.Text = "514-421-4567"

        frmSalesPslipBarCodeLabels.txtCustOrder.Text = Me.txtCustOrder.Text
        frmSalesPslipBarCodeLabels.txtItemNo.Text = String.Format("{0,2}", "00") + Trim(Me.txtItemNo.Text)

        'String.Format("{0,-24}", Row.Cells("PslipNo").Value)

        frmSalesPslipBarCodeLabels.txtViaNotes.Text = Me.txtViaNotes.Text
        frmSalesPslipBarCodeLabels.txtPartNo.Text = Me.txtPartNo.Text
        frmSalesPslipBarCodeLabels.txtPSlipQty.Text = Me.txtPSlipQty.Text
        frmSalesPslipBarCodeLabels.txtMPO.Text = Me.CmbMPO.Text
        frmSalesPslipBarCodeLabels.txtMpoCloseDate.Text = Me.txtMpoCloseDate.Text
        frmSalesPslipBarCodeLabels.txtNoBox.Text = Me.txtNoBox.Text
        frmSalesPslipBarCodeLabels.txtPSlipNo.Text = Me.CmbDelNo.Text
        frmSalesPslipBarCodeLabels.txtWeight.Text = ""

        frmSalesPslipBarCodeLabels.txtBarCode.Text = ""

        If RdPDF417.Checked = True Then
            frmSalesPslipBarCodeLabels.txtBarCode.Text = "Z" + _
                                                         "K" + Microsoft.VisualBasic.Left(Trim(Me.txtCustOrder.Text), 10) + _
                                                         "4K" + Microsoft.VisualBasic.Left(Trim(Me.txtItemNo.Text), 5) + _
                                                         "11K" + Microsoft.VisualBasic.Left(Trim(Me.txtPslipNo.Text), 16) + _
                                                         "P" + Microsoft.VisualBasic.Left(Trim(Me.txtPartNo.Text), 18) + _
                                                         "7Q" + Microsoft.VisualBasic.Left(Trim(Me.txtPSlipQty.Text), 6) + _
                                                         "X" + Microsoft.VisualBasic.Left(Trim(Me.txtNoBox.Text), 3) + _
                                                         "1T" + Microsoft.VisualBasic.Left(Trim(Me.CmbMPO.Text), 10) + _
                                                         "6D" + Microsoft.VisualBasic.Left(Trim(Me.txtMpoCloseDate.Text), 8)
        Else
            frmSalesPslipBarCodeLabels.txtBarCode.Text = Me.txtPartNo.Text
        End If

        frmSalesPslipBarCodeLabels.ShowDialog()

    End Sub

    Private Sub CmdEmail_Click(sender As System.Object, e As System.EventArgs) Handles CmdEmail.Click



            Dim reply As DialogResult

            reply = MsgBox("Do you want to Send an Email to Planning Department ? ", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""

            email.Subject = "Packing Slip Number: " + txtPslipNo.Text
            strBody = "ASN Label Information" & vbCrLf
            strBody = strBody & "====================" & vbCrLf

                Dim StrSearch As Integer = 0
                Dim getInfo As String = ""

              

            strBody = strBody & "Boeing Info           " & Trim(txtPslipNotes.Text) & vbCrLf
            strBody = strBody & "Part Number           " & Trim(txtPartNo.Text) & vbCrLf
            strBody = strBody & "MPO#                  " & Trim(CmbMPO.Text) & vbCrLf
            strBody = strBody & "Carrier               " & Trim(cmbVia.Text) & vbCrLf
            strBody = strBody & "Actual Ship Date      " & txtPslipDate.Text & vbCrLf

            Dim Swdate As Date
            Dim SwEst As String = ""
            Swdate = txtPslipDate.Text
            SwEst = DateAdd(DateInterval.Day, 7, Swdate).ToShortDateString

            strBody = strBody & "Estimate Arrive Date  " & SwEst & vbCrLf + vbCrLf

            strBody = strBody & "Tracking Number       " & Trim(txtBillNo.Text) & vbCrLf
            strBody = strBody & "Total packages        " & Trim(txtBoxNo.Text) & vbCrLf
            strBody = strBody & "                      " & Trim(txtViaNotes.Text) & vbCrLf

            strBody = strBody & "Gross weight          " & Trim(txtWeight.Text) & vbCrLf
            strBody = strBody & "Shipped Quantity      " & Trim(txtPSlipQty.Text) & vbCrLf

            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)

            'email.To.Add(New Mail.MailAddress("Stefan.Tudor@Lisi-Aerospace.com"))

            email.To.Add(New Mail.MailAddress("Planning.Montreal@Lisi-Aerospace.com"))
            client.Send(email)

            End If

    End Sub

    Private Sub CmdBoeing_Click(sender As System.Object, e As System.EventArgs) Handles CmdBoeing.Click

        frmSalesBoeingLabels.txtCustOrder.Text = Me.txtCustRef.Text
        frmSalesBoeingLabels.txtItemNo.Text = Me.txtItemNo.Text
        frmSalesBoeingLabels.txtMPO.Text = Me.CmbMPO.Text
        frmSalesBoeingLabels.txtItemName.Text = Me.txtCustPart.Text
        frmSalesBoeingLabels.txtCustPN.Text = Me.txtCustPart.Text
        frmSalesBoeingLabels.txtBoeingLine.Text = "0000"
        frmSalesBoeingLabels.txtQty.Text = Me.txtPSlipQty.Text
        frmSalesBoeingLabels.txtPslipDate.Text = Me.txtPslipDate.Text

        Dim mypos As Integer = 0
        mypos = InStr(txtBoeingPO.Text, "-")
        If mypos = 0 Then
            frmSalesBoeingLabels.txtBoeingPO.Text = txtBoeingPO.Text
        Else
            frmSalesBoeingLabels.txtBoeingPO.Text = Replace(txtBoeingPO.Text, "-", "")
        End If


        frmSalesBoeingLabels.txtPSlip.Text = txtPslipNo.Text
        frmSalesBoeingLabels.txtPNBCA.Text = txtCustPart.Text
        frmSalesBoeingLabels.txtM3Item.Text = txtM3Code.Text
        frmSalesBoeingLabels.txtDelivNo.Text = Trim(txtPslipNo.Text) + "-" + Trim(txtWSHE.Text)
        frmSalesBoeingLabels.txtCustName.Text = ShipName.Text
        frmSalesBoeingLabels.txtWSHE.Text = txtWSHE.Text

        frmSalesBoeingLabels.ShowDialog()

    End Sub

End Class