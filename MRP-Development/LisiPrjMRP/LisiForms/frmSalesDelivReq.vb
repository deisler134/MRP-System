Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class frmSalesDelivReq

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""
    Dim ItemRow As Integer
    Dim RowWSHE As Integer
    Dim RowDeliv As Integer
    Dim RowPslip As Integer
    Dim KeepIndexPO As Integer

    Dim SwCreate As Boolean = False

    Dim SwCrossVal As Boolean = True

    Dim VerReq As Integer = 9    '0=serach ok, 1 = posted, 9=search wrong


    Private Sub frmSalesDelivReq_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub frmSalesDelivReq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        PlQAFlags.Visible = False

        'dsMain.Tables("tblCustOrder").Clear()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        SetCtlForm()

        BindComponents()

        dgItem.AutoGenerateColumns = False
        dgItem.DataSource = dsMain
        dgItem.DataMember = "tblCustOrder.OrderItems"

        dgInv.AutoGenerateColumns = False
        dgInv.DataSource = dsMain
        dgInv.DataMember = "tblCustOrder.OrderInv"

        dgPslip.AutoGenerateColumns = False
        dgPslip.DataSource = dsMain
        dgPslip.DataMember = "tblCustOrder.OrderItems.ItemsDeliv.DelivPslip"

        dgShip.AutoGenerateColumns = False
        dgShip.DataSource = dsMain
        dgShip.DataMember = "tblCustOrder.OrderShip"

        dgDeliv.AutoGenerateColumns = False
        dgDeliv.DataSource = dsMain
        dgDeliv.DataMember = "tblCustOrder.OrderItems.ItemsDeliv"

        'CmbOrder.DataSource = dsMain.Tables("tblCustOrder")
        'CmbOrder.DisplayMember  = "OrdNumber"
        'CmbOrder.ValueMember = "OrderID"

        With CmbOrder
            .DataSource = dsMain.Tables("tblCustOrder")
            .DisplayMember = "DispInfo"
            .ValueMember = "OrderID"
        End With

        ItemRow = 0

        CalculGrid()

    End Sub

    Sub DisableFields()

        cmbMpoFp.Enabled = False

        KeepItem.ReadOnly = True

        CmbCust.Enabled = False
        CmbDevise.Enabled = False
        CmbTerms.Enabled = False
        CmbOrderStatus.Enabled = False

        CmdCust.Enabled = False

        txtPONumber.ReadOnly = True


        txtPORev.ReadOnly = True
        txtPODate.ReadOnly = True
        txtPODateRecv.ReadOnly = True
        txtPONotes.ReadOnly = True
        txtPOBuyer.ReadOnly = True
        txtRefNo.ReadOnly = True

        txtPslipNotes.ReadOnly = True
        txtReqNotes.ReadOnly = True

        RadioContract.Enabled = False
        RadioOrder.Enabled = False

        dgItem.ReadOnly = True
        dgDeliv.ReadOnly = True
        dgInv.ReadOnly = True
        dgShip.ReadOnly = True

    End Sub

    Sub EnableFields()

        dgItem.ReadOnly = True
        dgDeliv.ReadOnly = False
        dgInv.ReadOnly = False
        dgShip.ReadOnly = False

        cmbMpoFp.Enabled = True

        txtPslipNotes.ReadOnly = False
        txtReqNotes.ReadOnly = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdReset.Enabled = True
        CmdEdit.Enabled = True
        CmdSave.Enabled = False

        CmdPrint.Enabled = True
        txtReqNo.ReadOnly = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        ' CallClass.PopulateDataAdapter("gettblCustOrder").Fill(dsMain, "tblCustOrder")
        CallClass.PopulateDataAdapter("gettblCustOrderDispInfoForDelivReq").Fill(dsMain, "tblCustOrder")
        CallClass.PopulateDataAdapter("gettblCustOrderItem").Fill(dsMain, "tblCustOrderItem")
        CallClass.PopulateDataAdapter("gettblCustOrderItemDeliv").Fill(dsMain, "tblCustOrderItemDeliv")
        CallClass.PopulateDataAdapter("gettblLisiPslip").Fill(dsMain, "tblLisiPslip")
        CallClass.PopulateDataAdapter("gettblCustOrderInv").Fill(dsMain, "tblCustOrderInvInfo")
        CallClass.PopulateDataAdapter("gettblCustOrderShipWithWSHE").Fill(dsMain, "tblCustOrderShipInfo")

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("OrderItems", _
                .Tables("tblCustOrder").Columns("OrderID"), _
                .Tables("tblCustOrderItem").Columns("OrderID"), True)
        End With

        With dsMain
            .Relations.Add("OrderInv", _
                .Tables("tblCustOrder").Columns("OrderID"), _
                .Tables("tblCustOrderInvInfo").Columns("OrderID"), True)
        End With

        With dsMain
            .Relations.Add("OrderShip", _
                .Tables("tblCustOrder").Columns("OrderID"), _
                .Tables("tblCustOrderShipInfo").Columns("OrderID"), True)
        End With

        With dsMain
            .Relations.Add("ItemsDeliv", _
                .Tables("tblCustOrderItem").Columns("OrderItemsID"), _
                .Tables("tblCustOrderItemDeliv").Columns("OrderItemsID"), True)
        End With

        With dsMain
            .Relations.Add("DelivPslip", _
                .Tables("tblCustOrderItemDeliv").Columns("OrdDelivID"), _
                .Tables("tblLisiPslip").Columns("OrdDelivID"), True)
        End With

    End Sub

    Sub BindComponents()

        txtPONumber.DataBindings.Clear()
        txtPORev.DataBindings.Clear()
        txtPODate.DataBindings.Clear()
        txtPODateRecv.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()
        txtPOBuyer.DataBindings.Clear()
        txtRefNo.DataBindings.Clear()
        txtPslipNotes.DataBindings.Clear()
        txtReqNotes.DataBindings.Clear()

        CmbCust.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbTerms.DataBindings.Clear()
        CmbOrderStatus.DataBindings.Clear()

        RadioOrder.DataBindings.Clear()
        RadioContract.DataBindings.Clear()

        txtPONumber.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdNumber")
        txtPORev.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdRevision")
        txtPODate.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPODateRecv.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDateRecv", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPONotes.DataBindings.Add("Text", dsMain, "tblCustOrder.NotesOrder")
        txtPOBuyer.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdBuyer")
        txtRefNo.DataBindings.Add("Text", dsMain, "tblCustOrder.ORDRefNo")

        txtPslipNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderItems.ItemsDeliv.DelivPSlip.PSlipNotes")
        txtReqNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderItems.ItemsDeliv.DelivPSlip.ReqNotes")

        CmbCust.DataBindings.Add("SelectedValue", dsMain, "tblCustOrder.CustID")
        CmbDevise.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDevise")
        CmbTerms.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdTerms")
        CmbOrderStatus.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdStatus")

        RadioOrder.DataBindings.Add(New Binding("Checked", dsMain, "tblCustOrder.OrdOrder", True))
        RadioContract.DataBindings.Add(New Binding("Checked", dsMain, "tblCustOrder.OrdContract", True))

    End Sub

    Sub SetCtlForm()

        PutCust()
        CmbCust.SelectedIndex = -1

        PutTerms()
        'for dgPslip  --   Info
        With Me.PslipID
            .DataPropertyName = "PslipID"
            .Name = "PslipID"
            .Visible = False
        End With

        With Me.PslipType
            .DataPropertyName = "PslipType"
            .Name = "PslipType"
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.PslipReqDate
            .DataPropertyName = "PslipReqDate"
            .Name = "PslipReqDate"
        End With

        With Me.ReqQty
            .DataPropertyName = "ReqQty"
            .Name = "ReqQty"
        End With

        With Me.PslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

        With Me.PslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGettblMpoMasterClosed").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        'for dgShip  --  Shipping Info

        With Me.OrdShipID
            .DataPropertyName = "OrdShipID"
            .Name = "OrdShipID"
            .Visible = False
        End With

        With Me.OrderIDShip
            .DataPropertyName = "OrderID"
            .Name = "OrderID"
            .Visible = False
        End With

        With Me.ShipLine
            .DataPropertyName = "ShipLine"
            .Name = "ShipLine"
        End With

        PutShipAddress()

        With Me.ShipWhat
            .DataPropertyName = "ShipWhat"
            .Name = "ShipWhat"
        End With

        With Me.ShipWSHE
            .DataPropertyName = "ShipWSHE"
            .Name = "ShipWSHE"
        End With

        With Me.ShipNotes
            .DataPropertyName = "ShipNotes"
            .Name = "ShipNotes"
        End With

        'for dgInv  --  Billing Info

        With Me.OrdInvID
            .DataPropertyName = "OrdInvID"
            .Name = "OrdInvID"
            .Visible = False
        End With

        With Me.OrderIDInv
            .DataPropertyName = "OrderID"
            .Name = "OrderID"
            .Visible = False
        End With

        With Me.InvLine
            .DataPropertyName = "InvLine"
            .Name = "InvLine"
        End With

        PutInvAddress()

        With Me.InvWhat
            .DataPropertyName = "InvWhat"
            .Name = "InvWhat"
        End With

        With Me.InvNotes
            .DataPropertyName = "InvNotes"
            .Name = "InvNotes"
        End With

        'for dgOrdItem  Items Description

        With Me.OrderItemsID
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.OrderID
            .DataPropertyName = "OrderID"
            .Name = "OrderID"
            .Visible = False
        End With

        With Me.OrdItemNo
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.OrdPartNoID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DropDownWidth = 300
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
        End With

        With Me.OrdPartCross99ID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40

            .DataPropertyName = "OrdPartCross99ID"
            .Name = "OrdPartCross99ID"
        End With

        With Me.OrdItemQty
            .DataPropertyName = "OrdItemQty"
            .Name = "OrdItemQty"
        End With

        With Me.OrdItemUM
            .DataSource = CallClass.PopulateComboBox("tblUM", "cmbGetUM").Tables("tblUM")
            .DisplayMember = "IDUM"
            .ValueMember = "IDUM"
            .DataPropertyName = "OrdItemUM"
            .Name = "OrdItemUM"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdItemStatus
            .DataPropertyName = "OrdItemStatus"
            .Name = "OrdItemStatus"
        End With

        With Me.OrdItemNotes
            .DataPropertyName = "OrdItemNotes"
            .Name = "OrdItemNotes"
        End With

        'for dgOrdDeliv Delivery Info

        With Me.OrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.OrderItemsIDDeliv
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.PoNoDeliv
            .DataPropertyName = "PoNoDeliv"
            .Name = "PoNoDeliv"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.DelivShippedQty
            .DataPropertyName = "DelivShippedQty"
            .Name = "DelivShippedQty"
        End With

        With Me.DelivWhat
            .DataPropertyName = "DelivWhat"
            .Name = "DelivWhat"
        End With

        With Me.DelivStatus
            .DataPropertyName = "DelivStatus"
            .Name = "DelivStatus"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

    End Sub

    Sub PutCust()
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

    Sub PutShipAddress()

        With Me.ShipWhere
            .DataSource = CallClass.PopulateComboBox("tblCustShip", "cmbGetShipWhere").Tables("tblCustShip")
            .DisplayMember = "FullDest"
            .ValueMember = "CustShipID"
            .DataPropertyName = "ShipWhere"
            .Name = "ShipWhere"
        End With

    End Sub

    Sub PutInvAddress()

        With Me.InvWhere
            .DataSource = CallClass.PopulateComboBox("tblCustInv", "cmbGetInvWhere").Tables("tblCustInv")
            .DisplayMember = "FullDest"
            .ValueMember = "CustInvID"
            .DataPropertyName = "InvWhere"
            .Name = "InvWhere"
        End With

    End Sub

    Sub PutInfoBoeing()

        'txtPart.Text = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value)

        txtPart.Text = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)

        txtWSHE.Text = Nz.Nz(dgShip.Rows(RowWSHE).Cells("ShipWSHE").Value)

        If Len(txtPart.Text) > 0 And Len(txtWSHE.Text) > 0 Then
            Try
                txtBoeingCO.Text = CallClass.ReturnStrWith2ParStr("cspReturnBoeingCO_Number", txtPart.Text, txtWSHE.Text)
            Catch ex As Exception
            End Try
        Else
            MsgBox("!!! ERROR !!! Can not locate the Boeing CO#")
        End If

        txtM3Code.Text = CallClass.ReturnStrWithParString("cspReturnM3Article", txtPart.Text)

        If Len(txtPslipNotes.Text) = 0 Then
            txtPslipNotes.Text = "CPO#:    " + txtBoeingCO.Text + vbCrLf
            txtPslipNotes.Text = txtPslipNotes.Text + "WSHE:  " + txtWSHE.Text + vbCrLf
            txtPslipNotes.Text = txtPslipNotes.Text + "Article: " + txtM3Code.Text

        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        If Len(Trim(CmbCust.Text)) = 0 Or Len(Trim(txtPONumber.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to modify.")
            Exit Sub
        End If

        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbOrder.Enabled = False

        EnableFields()

        If Len(Trim(CmbTerms.Text)) = 0 Then
            CmbTerms.Text = "Net 60 Days"
        End If

        txtFPNotes.Text = ""

        SwCreate = True


    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        dsMain.RejectChanges()
        DisableFields()
        FirstTimeMenuButtons()

        CmbOrder.Enabled = True
        CmbOrder.SelectedIndex = -1

        SwOper = ""
        txtQtyStock.Text = 0

        txtREQ.Text = 0


        PlQAFlags.Visible = False

        txtFPNotes.Text = ""

        SwCreate = False

    End Sub

    Private Sub CmdCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCust.Click
        frmCustomer.SwForm.Text = CmbCust.SelectedIndex
        frmCustomer.ShowDialog()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Me.Cursor = Cursors.WaitCursor

        Call ValPo()

        If SwVal = True Then

            SwOper = "Save"

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    CreateDelivReq()
                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()
                End If



            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            Call SetupForm()

            SwOper = ""

            CmbOrder.Enabled = True
            CmbOrder.SelectedValue = KeepIndexPO

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Sub CreateDelivReq()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspSalesInsertDelivReq", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraType As SqlParameter = New SqlParameter("@PslipType", SqlDbType.NVarChar, 5)
        paraType.Value = "REQ"
        mySqlComm.Parameters.Add(paraType)

        Dim paraDate As SqlParameter = New SqlParameter("@PslipReqDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraDate)

        Dim paraSoldID As SqlParameter = New SqlParameter("@PslipSoldID", SqlDbType.Int, 4)
        For Each RowSold As DataGridViewRow In dgInv.Rows
            If Nz.Nz(RowSold.Cells("invWhat").Value) = "1" Then
                paraSoldID.Value = dgInv("OrdInvID", RowSold.Index).Value
            End If
        Next
        mySqlComm.Parameters.Add(paraSoldID)

        Dim paraAccpac As SqlParameter = New SqlParameter("@PslipAccpacCode", SqlDbType.NVarChar, 7)
        For Each RowSold As DataGridViewRow In dgInv.Rows
            If Nz.Nz(RowSold.Cells("invWhat").Value) = "1" Then
                paraAccpac.Value = dgInv("AccpacCode", RowSold.Index).Value
            End If
        Next
        mySqlComm.Parameters.Add(paraAccpac)

        Dim paraShipID As SqlParameter = New SqlParameter("@PslipShipID", SqlDbType.Int, 4)
        For Each RowShip As DataGridViewRow In dgShip.Rows
            If Nz.Nz(RowShip.Cells("ShipWhat").Value) = "1" Then
                paraShipID.Value = dgShip("OrdShipID", RowShip.Index).Value
            End If
        Next
        mySqlComm.Parameters.Add(paraShipID)

        Dim paraContr As SqlParameter = New SqlParameter("@PslipCustPoContr", SqlDbType.NVarChar, 50)
        paraContr.Value = Trim(Nz.Nz(txtPONumber.Text))
        mySqlComm.Parameters.Add(paraContr)

        Dim paraPoRev As SqlParameter = New SqlParameter("@PslipCustPoRev", SqlDbType.NVarChar, 10)
        paraPoRev.Value = Trim(Nz.Nz(txtPORev.Text))
        mySqlComm.Parameters.Add(paraPoRev)

        Dim paraDateContr As SqlParameter = New SqlParameter("@PslipDatePoContr", SqlDbType.SmallDateTime, 4)
        paraDateContr.Value = txtPODate.Text
        mySqlComm.Parameters.Add(paraDateContr)

        Dim paraRefNo As SqlParameter = New SqlParameter("@PslipORDRefNo", SqlDbType.NVarChar, 25)
        paraRefNo.Value = Trim(Nz.Nz(txtRefNo.Text))
        mySqlComm.Parameters.Add(paraRefNo)

        Dim paraItem As SqlParameter = New SqlParameter("@PslipItem", SqlDbType.NVarChar, 20)
        'paraItem.Value = Convert.ToString(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value)
        paraItem.Value = KeepItem.Text
        mySqlComm.Parameters.Add(paraItem)

        Dim paraReqQty As SqlParameter = New SqlParameter("@ReqQty", SqlDbType.Real, 4)
        'For Each RowDeliv As DataGridViewRow In dgDeliv.Rows
        'If Nz.Nz(RowDeliv.Cells("DelivWhat")).Value = "1" Then
        paraReqQty.Value = dgDeliv("DelivShippedQty", RowDeliv).Value
        'End If
        'Next
        mySqlComm.Parameters.Add(paraReqQty)

        Dim paraUM As SqlParameter = New SqlParameter("@PslipUM", SqlDbType.NVarChar, 10)
        paraUM.Value = dgItem.Rows(ItemRow).Cells("OrdItemUM").Value
        mySqlComm.Parameters.Add(paraUM)

        Dim paraPartID As SqlParameter = New SqlParameter("@PslipPartID", SqlDbType.Int, 4)
        paraPartID.Value = dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value
        mySqlComm.Parameters.Add(paraPartID)

        Dim paraCustPartID As SqlParameter = New SqlParameter("@PslipCustPartID", SqlDbType.Int, 4)
        paraCustPartID.Value = dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value
        mySqlComm.Parameters.Add(paraCustPartID)

        Dim paraShipNotes As SqlParameter = New SqlParameter("@PSlipNotes", SqlDbType.NVarChar, 1000)
        paraShipNotes.Value = Trim(txtPslipNotes.Text)
        mySqlComm.Parameters.Add(paraShipNotes)

        Dim paraReqNotes As SqlParameter = New SqlParameter("@ReqNotes", SqlDbType.NVarChar, 500)
        paraReqNotes.Value = Trim(txtReqNotes.Text)
        mySqlComm.Parameters.Add(paraReqNotes)

        Dim paraViaNotes As SqlParameter = New SqlParameter("@PSlipViaNotes", SqlDbType.NVarChar, 1000)
        For Each RowShip As DataGridViewRow In dgShip.Rows
            If Nz.Nz(RowShip.Cells("ShipWhat").Value) = "1" Then
                paraViaNotes.Value = dgShip("ShipNotes", RowShip.Index).Value
            End If
        Next
        mySqlComm.Parameters.Add(paraViaNotes)

        Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
        'For Each RowDeliv As DataGridViewRow In dgDeliv.Rows
        'If Nz.Nz(RowDeliv.Cells("DelivWhat").Value) = "1" Then
        paraDelivID.Value = dgDeliv("OrdDelivID", RowDeliv).Value
        'End If
        'Next
        mySqlComm.Parameters.Add(paraDelivID)

        Dim paraMpoID As SqlParameter = New SqlParameter("@PslipMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = cmbMpoFp.SelectedValue
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraTerms As SqlParameter = New SqlParameter("@InvTerms", SqlDbType.NVarChar, 50)
        paraTerms.Value = CmbTerms.Text
        mySqlComm.Parameters.Add(paraTerms)

        Dim paraInter As SqlParameter = New SqlParameter("@PslipInterCoPrefix", SqlDbType.NVarChar, 5)
        For Each RowSold As DataGridViewRow In dgInv.Rows
            If Nz.Nz(RowSold.Cells("invWhat").Value) = "1" Then
                paraInter.Value = dgInv("InterCoPrefix", RowSold.Index).Value
            End If
        Next
        mySqlComm.Parameters.Add(paraInter)

        Dim paraSw As SqlParameter = New SqlParameter("@PslipInterCoSw", SqlDbType.NVarChar, 1)
        paraSw.Value = "1"
        mySqlComm.Parameters.Add(paraSw)

        Dim paraWSHE As SqlParameter = New SqlParameter("@CO_WSHE", SqlDbType.NVarChar, 15)
        paraWSHE.Value = txtWSHE.Text
        mySqlComm.Parameters.Add(paraWSHE)

        Dim paraPO As SqlParameter = New SqlParameter("@CO_CustPO", SqlDbType.NVarChar, 50)
        paraPO.Value = txtBoeingCO.Text
        mySqlComm.Parameters.Add(paraPO)

        Dim paraITNO As SqlParameter = New SqlParameter("@CO_ITNO", SqlDbType.NVarChar, 50)
        paraITNO.Value = txtM3Code.Text
        mySqlComm.Parameters.Add(paraITNO)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("!!! ERROR !!! - Insert Delivery Request: " & ex.Message)
        End Try

    End Sub

    Sub ValPo()

        Dim II As Integer = 0
        SwVal = False

        dgDeliv.Refresh()

        If SwCrossVal = False Then
            MsgBox("!!!  ERROR   !!! P/N status 20 is not equal with P/N Customer PO. ")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbTerms.Text)) = 0 Or IsDBNull(CmbTerms.Text) = True Or IsNothing(CmbTerms.Text) = True Then
            MsgBox("!!! ERROR !!! Terms are Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(dgDeliv("DelivShippedQty", RowDeliv).Value) = False Then
            If Val(dgDeliv("DelivShippedQty", RowDeliv).Value) > Val(txtQtyStock.Text) Then
                MsgBox("!!! ERROR !!! Requested Qty > Stock Qty.")
                SwVal = False
                Exit Sub
            End If
        Else
            MsgBox("!!! ERROR !!! Requested qty is empty.")
            SwVal = False
            Exit Sub
        End If


        Dim MsgShippedQty As String = ""
        MsgShippedQty = CallClass.ReturnStrWithParInt("cspReturnInvShippedQtyByMPOId", cmbMpoFp.SelectedValue)
        If MsgShippedQty = "False" Then
            'skip
        Else
            If Val(MsgShippedQty) + Val(dgDeliv("DelivShippedQty", RowDeliv).Value) > Val(txtQtyStock.Text) Then
                MsgBox("!!! ERROR !!! Requested Qty > Stock Qty for the selected MPO.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Val(txtQtyStock.Text) <= 0 Then
            MsgBox("!!! ERROR !!! Stock Qty.")
            SwVal = False
            Exit Sub
        End If

        If RowDeliv < 0 Then
            MsgBox("!!! ERROR !!! Index Deleivery Row.")
            SwVal = False
            Exit Sub
        End If

        II = 0
        For Each RDeliv As DataGridViewRow In dgDeliv.Rows
            If Nz.Nz(RDeliv.Cells.Item("DelivWhat").Value) = True Then
                II = II + 1
            End If
        Next
        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! Delivery Data is not Selected or there are more of one delivery selected.")
            SwVal = False
            Exit Sub
        End If

        II = 0
        For Each RDeliv As DataGridViewRow In dgDeliv.Rows
            If Nz.Nz(RDeliv.Cells.Item("DelivShippedQty").Value) <> 0 And Nz.Nz(RDeliv.Cells.Item("DelivWhat").Value) <> 0 Then
                II = II + 1
            End If
        Next
        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! Delivery Quantity is Empty.")
            SwVal = False
            Exit Sub
        End If

        II = 0
        For Each RDeliv As DataGridViewRow In dgShip.Rows
            If Nz.Nz(RDeliv.Cells.Item("ShipWhat").Value) = True Then
                II = II + 1
            End If
        Next
        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! Shipping Info is not Selected.")
            SwVal = False
            Exit Sub
        End If

        II = 0
        For Each RDeliv As DataGridViewRow In dgInv.Rows
            If Nz.Nz(RDeliv.Cells("InvWhat").Value) = True Then
                II = II + 1
            End If
        Next
        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! Billing Info is not Selected.")
            SwVal = False
            Exit Sub
        End If

        II = 0
        For Each RDeliv As DataGridViewRow In dgInv.Rows
            If IsDBNull(RDeliv.Cells("AccpacCode").Value) = True Then
            Else
                If IsNothing(RDeliv.Cells("AccpacCode").Value) = False And RDeliv.Cells("AccpacCode").Value <> "False" Then
                    II = II + 1
                End If
            End If
        Next

        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! This is a new Customer Billing Address. You should contact accounting department to provide you with a code for this customer.")
            SwVal = False
            Exit Sub
        End If



        II = 0
        For Each RDeliv As DataGridViewRow In dgInv.Rows
            If IsDBNull(RDeliv.Cells("InvCodeM3").Value) = True Then
            Else
                If IsNothing(RDeliv.Cells("InvCodeM3").Value) = False And RDeliv.Cells("InvCodeM3").Value <> "False" Then
                    II = II + 1
                End If
            End If
        Next

        If II = 1 Then
            'SwVal = True
        Else
            MsgBox("!!! ERROR !!! Missing M3 Customer Code Number.")
            SwVal = False
            Exit Sub
        End If


        If cmbMpoFp.SelectedValue <= 0 Then
            MsgBox("!!! ERROR !!! Mpo Number.")
            SwVal = False
            Exit Sub
        End If

        If Len(txtBoeingCO.Text) > 0 And Len(txtWSHE.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Boeing WHSE")
            SwVal = False
            Exit Sub
        End If

        If Len(txtWSHE.Text) > 0 And Len(txtBoeingCO.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Boeing CO#")
            SwVal = False
            Exit Sub
        End If

        Dim SwCount As Integer = 0

        SwCount = CallClass.ReturnStrWithParInt("cspReturnMEMOStatus", cmbMpoFp.SelectedValue)
        If SwCount > 0 Then
            MsgBox(" !!! ATTENTION !!! There is/are one or more open MEMOs.")
            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "MPO Final Inspection"
            strBody = "For the MPO Number:  " + cmbMpoFp.Text + vbCrLf
            strBody = strBody + "There is/are one or more open MEMOs."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("qualite.montreal@lisi-aerospace.com"))
            client.Send(email)
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Sub CalculGrid()

        If ItemRow < 0 Then
            Exit Sub
        End If

        totQty.Text = 0
        totValue.Text = 0
        totDelQty.Text = 0

        Try
            totQty.Text = Val(Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemQty").Value)).ToString("N0")
            totValue.Text = Val((Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemQty").Value) * Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemPrice").Value))).ToString("C2")
        Catch ex As Exception
        End Try
        

        For Each RDeliv As DataGridViewRow In dgDeliv.Rows
            totDelQty.Text = Val(totDelQty.Text + Nz.Nz(RDeliv.Cells("DelivQty").Value)).ToString("N0")
        Next

        Dim DifRes As Integer
        DifRes = (totQty.Text) - (totDelQty.Text)

        DiffQty.Text = DifRes.ToString("N0")

        If DifRes <> 0 Then
            Me.ErrorProvider1.SetError(DiffQty, "Total Delivery Quantity not Equal with Item Quantity.")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        Else
            Me.ErrorProvider1.Clear()
        End If

        txtReqQty.Text = 0
        For Each RowPslip As DataGridViewRow In dgPslip.Rows
            txtReqQty.Text = Val(txtReqQty.Text + Nz.Nz(RowPslip.Cells("ReqQty").Value)).ToString("N0")
        Next

        If Val(txtREQ.Text) > Val(txtQtyStock.Text) Then
            Me.ErrorProvider1.SetError(txtREQ, "SUM of active Delivery Quantity > than the Total FP Stock.")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If
    End Sub

    Private Sub dgInv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgInv.CellBeginEdit

        Select Case e.ColumnIndex
            Case 0, 1, 2, 3, 4, 6, 7
                e.Cancel = True
        End Select

        Dim SwInter As String
        Dim StrSearch As Integer

        StrSearch = dgInv("InvWhere", e.RowIndex).Value
        dgInv("AccpacCode", e.RowIndex).Value = CallClass.ReturnStrWithParInt("cspReturnAccpacCode", StrSearch)

        dgInv("InvCodeM3", e.RowIndex).Value = CallClass.ReturnStrWithParInt("cspReturnInvCodeM3", StrSearch)

        SwInter = CallClass.ReturnStrWithParInt("cspReturnInterCoPrefix", StrSearch)
        If SwInter = "False" Then
            dgInv("InterCoPrefix", e.RowIndex).Value = DBNull.Value
        Else
            dgInv("InterCoPrefix", e.RowIndex).Value = SwInter
        End If

    End Sub

    Private Sub dgInv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgInv.DataError
        REM end
    End Sub

    Private Sub dgShip_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgShip.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            Select Case e.ColumnIndex
                Case 0, 1, 2, 3, 5
                    e.Cancel = True
            End Select

            RowWSHE = e.RowIndex

        End If

    End Sub

    Private Sub dgShip_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgShip.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowWSHE = e.RowIndex

            PutInfoBoeing()
        End If

    End Sub

    Private Sub dgShip_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgShip.DataError
        REM end
    End Sub

    Private Sub dgItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemRow = e.RowIndex
        dgItem.Rows(e.RowIndex).Selected = True

        If SwCreate = True Then
            '==========================================================
            dgItem.Rows(ItemRow).Selected = False
            dgItem.ReadOnly = False

            dgItem.Rows(ItemRow).Cells("OrdItemNo").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdPartNoID").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemQty").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemUM").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemPrice").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemStatus").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemNotes").ReadOnly = True

            dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").ReadOnly = False

        End If
        '==========================================================

        'dgItem.Rows(ItemRow).Cells("OrdItemNo").ReadOnly = False

        KeepItem.Text = dgItem("OrdItemNo", e.RowIndex).Value.ToString

        totQty.Text = dgItem("OrdItemQty", e.RowIndex).Value.ToString

        txtPartID.Text = Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdPartCross99ID").Value)

        txtOrdPartID.Text = Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdPartNoID").Value)

        txtReqNo.Text = ""

        'CalculGrid()

        PutInfoBoeing()

    End Sub

    Private Sub dgItem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgItem.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            ItemRow = e.RowIndex
        End If

        Select Case e.ColumnIndex

            Case 4

                SwCrossVal = True
                If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value) = False Then
                    'If dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value <> dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value Then  'i did this testy as they can change the 20 p/n and should be as cust pn
                    '    MsgBox("!!!  ERROR   !!! MFG P/N W/status 20 is not equal with Customer PO P/N !!!")
                    '    SwCrossVal = False
                    'End If
                Else
                    MsgBox("!!!  ERROR   !!! P/N status 20 is empty.")
                    SwCrossVal = False
                End If

                If dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value <> dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value Then
                    MsgBox("!!!  WARNING   !!! The MFG P/N was changed - Please double check the P/N before saving the REQ.")
                End If
        End Select

    End Sub

    Private Sub dgItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemRow = e.RowIndex

        dgItem.Rows(e.RowIndex).Selected = True

        'dgItem.Rows(ItemRow).Cells("OrdItemNo").ReadOnly = False

        KeepItem.Text = Nz.Nz(dgItem("OrdItemNo", e.RowIndex).Value).ToString

        totQty.Text = Nz.Nz(dgItem("OrdItemQty", e.RowIndex).Value).ToString

        txtPartID.Text = Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdPartCross99ID").Value)

        txtOrdPartID.Text = Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdPartNoID").Value)

        txtReqNo.Text = ""

        CalculGrid()
    End Sub

    Private Sub dgItem_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgItem.DataError
        REM end
    End Sub

    Private Sub dgDeliv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDeliv.CellBeginEdit

        Select Case e.ColumnIndex
            Case 0, 1, 2, 3, 4, 7, 8
                e.Cancel = True
            Case 5
                If Convert.ToString(dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value) <> "Active" Then
                    MsgBox("Delivery Date is Closed. Action Denied.")
                    RowDeliv = -1
                    e.Cancel = True
                End If

                RowDeliv = e.RowIndex

                If Val(totDelQty.Text) - Val(txtReqQty.Text) <= 0 Then
                    Dim reply As DialogResult
                    reply = MsgBox("Total Quantity Shipped is Equal or Greater than Delivery Quantity. Continue ?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        e.Cancel = False
                        dgDeliv.Rows(e.RowIndex).Cells("DelivWhat").Value = True
                    Else
                        e.Cancel = True
                        dgDeliv.Rows(e.RowIndex).Cells("DelivWhat").Value = False
                    End If
                End If

        End Select

    End Sub

    Private Sub dgDeliv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellClick

        dgDeliv.Refresh()

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDeliv = e.RowIndex

        Select Case e.ColumnIndex
            Case 6

                'If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value) = False Then
                If Convert.ToString(dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value) <> "Active" Then
                    MsgBox("Delivery Date is Closed. Action Denied.")
                    dgDeliv.Rows(e.RowIndex).Cells("DelivWhat").ReadOnly = True
                    dgDeliv.Rows(e.RowIndex).Cells("DelivShippedQty").ReadOnly = True
                End If
                'End If
        End Select

        'CalculGrid()

    End Sub

    Private Sub dgDeliv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellEndEdit

        ' CalculGrid()

    End Sub

    Private Sub dgDeliv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellEnter
        CalculGrid()
    End Sub

    Private Sub dgDeliv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDeliv.DataError
        REM end
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        If Len(Trim(txtReqNo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to Print. Action was cancelled - No email sent to Expedition Department.")
            Exit Sub
        End If

        If dgPslip.Rows.Count <= 0 Then
            MsgBox("!!! ERROR !!! Nothing to Print. Action was cancelled - No email sent to Expedition Department.")
            Exit Sub
        End If

        Dim II As Integer = 0
        For II = 0 To 1000
            II = II + 1
        Next

        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        'Dim pvCustPartCollection As New CrystalDecisions.Shared.ParameterValues()

        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()
        'Dim pdvCustPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptSalesDelivReq()

        rptPO.Load("..\rptSalesDelivReq.rpt")
        pdvCustomerName.Value = txtReqNo.Text
        pdvPartID.Value = txtPartID.Text
        'pdvCustPartID.Value = txtOrdPartID.Text

        pvCollection.Add(pdvCustomerName)
        pvPartCollection.Add(pdvPartID)
        'pvCustPartCollection.Add(pdvCustPartID)

        rptPO.DataDefinition.ParameterFields("@txtReqNo").ApplyCurrentValues(pvCollection)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartCollection)
        ' rptPO.DataDefinition.ParameterFields("@txtOrdPartID").ApplyCurrentValues(pvCustPartCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

        '=============================

        VerifyREQPrint()

        If Val(txtPosted.Text) >= 1 Then
            Dim reply As DialogResult
            reply = MsgBox("Delivery Request notification email is being sent. Are you sure you want to send Delivery Request notification email again? ", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If


        frmPOMasterPrint.CrystalReportViewer1.Refresh()
        Dim sSource As String = ""
        Dim sTarget As String = ""
        Dim FileNameStr As String = ""

        FileNameStr = ""
        FileNameStr = txtReqNo.Text + ".pdf"

        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = FileNameStr

        CrExportOptions = rptPO.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        rptPO.Export()

        Dim email As New Mail.MailMessage()

        Dim strBody As String = ""
        email.Subject = "Delivery Request Number: " + txtReqNo.Text + "     Customer: " + Trim(CmbCust.Text)
        strBody = "Please see attached" & vbCrLf
        strBody = strBody + "===================" & vbCrLf + vbCrLf + vbCrLf

        email.Body = strBody

        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
        email.From = New Net.Mail.MailAddress(wkEmpEmail)
        email.To.Add(New Mail.MailAddress("Vinoj.Vijayaratnam@Lisi-Aerospace.com"))
        email.Attachments.Add(New Net.Mail.Attachment(FileNameStr))

        client.Send(email)

        SaveREQNoPrint()


    End Sub

    Sub VerifyREQPrint()

        VerReq = 9

        strSQL = "SELECT REQPosted FROM tblLisiPslip WHERE ((tblLisiPslip.PslipNo)= '" & txtReqNo.Text & "')"

        Dim mySqlConn As New Data.SqlClient.SqlConnection(strConnection)
        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, mySqlConn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try

            If mySqlConn.State = ConnectionState.Open Then
                mySqlConn.Close()
            End If
            mySqlConn.Open()
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                VerReq = 9
            Else
                While myReader.Read()
                    If IsDBNull(myReader.GetValue(0)) Then
                        VerReq = 0       ' Not posted
                    Else
                        txtPosted.Text = myReader.GetValue(0)
                        If myReader.GetValue(0) >= 2 Then
                            VerReq = 1
                        Else
                            VerReq = 0
                        End If
                    End If
                End While
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            mySqlConn.Close()
            mySqlConn.Dispose()
            End
        Finally
            mySqlConn.Close()
            mySqlConn.Dispose()
        End Try

    End Sub

    Sub SaveREQNoPrint()

        strSQL = "UPDATE tblLisiPslip Set REQPosted = '" & Val(txtPosted.Text) + 1 & "' " _
                    & "WHERE ((tblLisiPslip.PslipNo)= '" & txtReqNo.Text & "')"

        txtPosted.Text = Val(txtPosted.Text) + 1

        Dim mySqlConn1 As New Data.SqlClient.SqlConnection(strConnection)
        Dim cmd As SqlCommand = New SqlCommand(strSQL, mySqlConn1)

        Try
            If mySqlConn1.State = ConnectionState.Open Then
                mySqlConn1.Close()
            End If
            mySqlConn1.Open()
            cmd.ExecuteNonQuery()
            mySqlConn1.Close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Exception occured - Update PoPosted   " & ex.Message)
            mySqlConn1.Close()
            cmd.Dispose()
        Finally

        End Try


    End Sub


    Private Sub dgPslip_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPslip.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPslip = e.RowIndex
        End If

    End Sub

    Private Sub dgPslip_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPslip.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPslip = e.RowIndex
        End If

        txtReqNo.Text = Nz.Nz(dgPslip.Rows(e.RowIndex).Cells("PslipNo").Value)

    End Sub

    Private Sub dgPslip_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPslip.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPslip = e.RowIndex
        End If

        txtReqNo.Text = Nz.Nz(dgPslip.Rows(e.RowIndex).Cells("PslipNo").Value)

    End Sub

    Private Sub cmbMpoFp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMpoFp.Click
        PutMpoInfo()
    End Sub

    Sub PutMpoInfo()

        Dim txtPartID As Integer = 0

        txtPartID = Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value)


        With cmbMpoFp
            .DataSource = CallClass.PopulateComboBoxWithParam("tblStockFinishPart", "cspPutMPOFPWithPartNumber", txtPartID).Tables("tblStockFinishPart")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Private Sub dgPslip_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPslip.DataError
        REM end
    End Sub

    Private Sub cmbMpoFp_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMpoFp.DropDownClosed

        If cmbMpoFp.SelectedValue > 1 Then

            txtQtyStock.Focus()
            txtQtyStock.Text = cmbMpoFp.SelectedItem("StFinal")

            PlQAFlags.Visible = False

            ChkCA.Checked = Nz.Nz(cmbMpoFp.SelectedItem("WKMpoCustAppr"))
            ChkSI.Checked = Nz.Nz(cmbMpoFp.SelectedItem("WKMpoSourceInsp"))
            ChkFAI.Checked = Nz.Nz(cmbMpoFp.SelectedItem("WKMpoFAI"))
            ChkDVI.Checked = Nz.Nz(cmbMpoFp.SelectedItem("WKMpoDVI"))
            If ChkSI.Checked = True Or ChkFAI.Checked = True Or ChkDVI.Checked = True Then
                PlQAFlags.Visible = True
                ChkCA.Enabled = False
                ChkSI.Enabled = False
                ChkFAI.Enabled = False
                ChkDVI.Enabled = False

                ChkAppr.Visible = True
                ChkAppr.Enabled = True
                ChkAppr.Checked = 0

                MsgBox("As one/more QA flag(s) was/were activated, your approval for this delivery request is required.")
                CmdSave.Enabled = False
                CmdEmail.Enabled = False
                CmdPrint.Enabled = False
            End If
        Else

            MsgBox("Due the new development for Cross and Dual parts, please choose the MFR part number (status 20) to complete this request - this is regarding the stock created before the new process.")

            dgItem.Rows(ItemRow).Selected = False
            dgItem.ReadOnly = False

            dgItem.Rows(ItemRow).Cells("OrdItemNo").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdPartNoID").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemQty").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemUM").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemPrice").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemStatus").ReadOnly = True
            dgItem.Rows(ItemRow).Cells("OrdItemNotes").ReadOnly = True

            dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").ReadOnly = False

            PutMpoInfo()

        End If

        txtFPNotes.Text = ""
        txtFPNotes.Text = CallClass.ReturnStrWithParInt("cspReturnFP_Notes", cmbMpoFp.SelectedValue)

        'txtREQ have the qty in transit in PSlip
        txtREQ.Text = CallClass.ReturnStrWith2ParStr("cspReturnREQActiveQty", dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value, cmbMpoFp.SelectedValue)

    End Sub

    Private Sub CmdEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEmail.Click

        If Len(Trim(txtReqNo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to Send by Email.")
        Else

            Dim reply As DialogResult

            reply = MsgBox("Do you want to Send an Email to Shipping Department ? ", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then

                Dim email As New Mail.MailMessage()

                Dim strBody As String = ""
                email.Subject = "Delivery Request Number: " + txtReqNo.Text
                strBody = "Information" & vbCrLf
                strBody = strBody & "===========" & vbCrLf

                Dim StrSearch As Integer = 0
                Dim getInfo As String = ""

                strBody = strBody & "Delivery Date            " & Nz.Nz(dgDeliv("DelivDate", RowDeliv).Value) & vbCrLf

                strBody = strBody & "Boeing WHSE              " & Trim(txtWSHE.Text) & vbCrLf
                strBody = strBody & "Boeing CO#               " & Trim(txtBoeingCO.Text) & vbCrLf
                strBody = strBody & "Part Number              " & Trim(txtPart.Text) & vbCrLf
                strBody = strBody & "M3 Article               " & Trim(txtM3Code.Text) & vbCrLf + vbCrLf

                getInfo = ""
                StrSearch = Nz.Nz(dgPslip("PslipMpoID", RowPslip).Value)
                getInfo = CallClass.ReturnStrWithParInt("cspReturnMpoNo", StrSearch)
                strBody = strBody & "MPO Number               " & Trim(getInfo) & vbCrLf
                strBody = strBody & "MPO Location             " & Trim(txtFPNotes.Text) & vbCrLf

                strBody = strBody & "Customer                 " & Trim(CmbCust.Text) & vbCrLf
                strBody = strBody & "Customer Order           " & Trim(txtPONumber.Text) & vbCrLf
                strBody = strBody & "Item Price               " & Trim(Str(Nz.Nz(dgItem("OrdItemPrice", ItemRow).Value))) & vbCrLf
                strBody = strBody & "Currency                 " & CmbDevise.Text & vbCrLf
                strBody = strBody & "Quantity Requested       " & Nz.Nz(dgPslip("ReqQty", RowPslip).Value) & vbCrLf
                strBody = strBody & "PSlip Notes              " & Trim(txtPslipNotes.Text) & vbCrLf
                strBody = strBody & "Delivery Requested Notes " & Trim(txtReqNotes.Text) & vbCrLf

                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)


                email.To.Add(New Mail.MailAddress("Vinoj.Vijayaratnam@Lisi-Aerospace.com"))
                'email.To.Add(New Mail.MailAddress("Planning.Montreal@Lisi-Aerospace.com"))
                'email.To.Add(New Mail.MailAddress("stefan.tudor@Lisi-Aerospace.com"))
                client.Send(email)

            End If
        End If

    End Sub

    Private Sub ChkAppr_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAppr.CheckedChanged
        If ChkAppr.Checked = True Then
            CmdSave.Enabled = True
            CmdEmail.Enabled = True
            CmdPrint.Enabled = True
        Else
            CmdSave.Enabled = False
            CmdEmail.Enabled = False
            CmdPrint.Enabled = False
        End If
    End Sub

    Private Sub CmbOrder_DropDownClosed(sender As Object, e As EventArgs) Handles CmbOrder.DropDownClosed
        KeepIndexPO = CmbOrder.SelectedValue

        txtQtyStock.Text = 0
        cmbMpoFp.SelectedIndex = -1

        PutInfoBoeing()
    End Sub

    Private Sub CmbOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbOrder.SelectedIndexChanged
        If SwOper = "Save" Then
            Exit Sub
        End If

        Me.BindingContext(dsMain, "tblCustOrder").Position = CType(CmbOrder.SelectedIndex, String)

        For Each RDeliv As DataGridViewRow In dgDeliv.Rows
            RDeliv.Cells("DelivWhat").Value = 0
        Next

        For Each RDeliv As DataGridViewRow In dgShip.Rows
            RDeliv.Cells("ShipWhat").Value = 0
        Next

        For Each RDeliv As DataGridViewRow In dgInv.Rows
            RDeliv.Cells("InvWhat").Value = 0
        Next

        BindComponents()

        ItemRow = 0

        CalculGrid()

        PutInfoBoeing()

    End Sub

  
End Class