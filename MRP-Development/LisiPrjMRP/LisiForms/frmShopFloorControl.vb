Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop
Imports System.Net
Imports System.Net.Mail

Public Class frmShopFloorControl

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowMpo As Integer = 0       'dgMPO row.
    Dim RowPslip As Integer = 0     ' dgPslip row
    Dim RowPoDet As Integer = 0     ' dgPoDetail row
    Dim RowBar As Integer = 0       'dgBar row.
    Dim RowMBOCh As Integer = 0         ' dgmbo row
    Dim RowAssy As Integer = 0      ' dgAssy

    Dim SwEndUser As String

    Dim OldQty As String
    Dim OldQtyActual As String
    Dim OldQtyReq As String
    Dim OldDept As Integer
    Dim OldMpoType As String = ""

    Private dsMain As New DataSet

    Dim SwOperNo = 0    '1 = gen MPO; 2 = Eng; 3 = planning
    Dim IReturn As Integer = 0

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmShopFloorControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmShopFloorControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1730 And Height > 940 Then
            Me.Width = 1730
            Me.Height = 940
        Else
            If Width < 1730 And Height < 940 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        ClearFields()

        InitButtons()

        InitialComponents()

        PutCustomer()
        PutDept()

        SetCtlForm()

        BindData()

        'CalculMpoValue()

        CalculActRelOrd()

        'CalculDiffTime()                ' keep them here only when you start the program
        CalculDiffTimeBarCode()
        'PutErrorMessage()

        RdActive.Checked = True

    End Sub

    Sub ClearFields()
        txtMpo.Text = ""
        txtPart.Text = ""
        txtCustOrder.Text = ""
        txtRefNoM3.Text = ""
        txtPSlip.Text = ""
        txtLotNo.Text = ""
        txtOrderNo.Text = ""
        txtOrderDate.Text = ""
        txtCustRefNo.Text = ""
        txtPONotes.Text = ""

        txtRawWeight.Text = ""
        txtReleasedWeight.Text = ""
        txtActualWeight.Text = ""

        txtOrderNo.ReadOnly = True
        txtOrderDate.ReadOnly = True
        txtCustRefNo.ReadOnly = True
        txtPONotes.ReadOnly = True
        txtEngInfo.ReadOnly = True

        cmbCust.Text = ""
        CmbDevise.Text = ""
        CmbOrderStatus.Text = ""
        cmbDept.Text = ""
        CmbSelCust.SelectedIndex = -1

        cmbCust.Enabled = False
        CmbDevise.Enabled = False
        CmbOrderStatus.Enabled = False

    End Sub

    Sub InitButtons()
        RdAll.Checked = False
        RdActive.Checked = False
        RdClosed.Checked = False
        RdCancelled.Checked = False
        RdContract.Checked = False
        RdOrder.Checked = False

        cmdPrintLot.Enabled = True
        CmdMethod.Enabled = False

    End Sub

    Sub PutTablesAdapters()

        CallClass.PopulateDataAdapter("gettblCustOrderItemDelivShopEmpty").Fill(dsMain, "tblSelectItemDeliv")
        CallClass.PopulateDataAdapter("gettblLisiPslip").Fill(dsMain, "tblLisiPslip ")
        'CallClass.PopulateDataAdapter("getTblMpoRoutingEmpty").Fill(dsMain, "tblMpoRouting")
        CallClass.PopulateDataAdapter("gettblPoDetailShop").Fill(dsMain, "tblPoDetails")
        CallClass.PopulateDataAdapter("gettblPoReceivingShop").Fill(dsMain, "tblPOReceiving")
        CallClass.PopulateDataAdapter("getTblMpoRoutingBarCode").Fill(dsMain, "tblMpoRoutingBarCode")
        CallClass.PopulateDataAdapter("getTblMpoMatlResev").Fill(dsMain, "tblStockRawMatlReservation")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefEmpty").Fill(dsMain, "tblPartMatlPref")
        CallClass.PopulateDataAdapter("gettblLisiPslipEmpty").Fill(dsMain, "tblLisiPslip")
        CallClass.PopulateDataAdapter("gettblMpoTravelerEmpty").Fill(dsMain, "tblMpoTraveler")
        CallClass.PopulateDataAdapter("gettblMpoMasterHistoryTranzEmpty").Fill(dsMain, "tblMpoMasterHistoryTranz")
        CallClass.PopulateDataAdapter("gettblPartAssyComponentsEmpty").Fill(dsMain, "tblPartAssyComponents")
        CallClass.PopulateDataAdapter("gettblPartAssyComponentsEmpty").Fill(dsMain, "tblTemp")
        CallClass.PopulateDataAdapter("gettblPartBlankEmpty").Fill(dsMain, "tblTempBlank")
        CallClass.PopulateDataAdapter("gettblMemoEmpty").Fill(dsMain, "tblTempMemo")

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getShopFloorControlEmpty").Fill(dsMain, "tblMpoMaster")
        PutTablesAdapters()

        CallClass.PopulateDataAdapter("gettblPartMasterEmpty").Fill(dsMain, "tblTemp")


        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("DelivPslip", _
               .Tables("tblSelectItemDeliv").Columns("OrdDelivID"), _
                .Tables("tblLisiPslip ").Columns("OrdDelivID"), True)
        End With

        With dsMain
            .Relations.Add("MpoPoDetails", _
               .Tables("tblMpoMaster").Columns("MpoId"), _
                .Tables("tblPoDetails").Columns("POMpoID"), True)
        End With

        With dsMain
            .Relations.Add("DetailsRecv", _
               .Tables("tblPoDetails").Columns("PODetailID"), _
                .Tables("tblPOReceiving").Columns("PODetailID"), True)
        End With

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblMpoMaster"

        dgPslip.AutoGenerateColumns = False
        dgPslip.DataSource = dsMain
        dgPslip.DataMember = "tblSelectItemDeliv.DelivPslip"

        dgPODetail.AutoGenerateColumns = False
        dgPODetail.DataSource = dsMain
        dgPODetail.DataMember = "tblMpoMaster.MpoPoDetails"

        dgPoRecv.AutoGenerateColumns = False
        dgPoRecv.DataSource = dsMain
        dgPoRecv.DataMember = "tblMpoMaster.MpoPoDetails.DetailsRecv"

    End Sub

    Sub BindData()

        txtMpo.DataBindings.Clear()
        txtPart.DataBindings.Clear()
        txtCustOrder.DataBindings.Clear()
        txtRefNoM3.DataBindings.Clear()
        txtPSlip.DataBindings.Clear()
        txtLotNo.DataBindings.Clear()
        cmbDept.DataBindings.Clear()
        CmbSelCust.DataBindings.Clear()

        txtRawWeight.DataBindings.Clear()

        txtOrderNo.DataBindings.Clear()
        txtOrderDate.DataBindings.Clear()
        txtCustRefNo.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()
        txtEngInfo.DataBindings.Clear()

        CmbMpoType.DataBindings.Clear()
        cmbCust.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbOrderStatus.DataBindings.Clear()
        txtMpoPriority.DataBindings.Clear()

        RdContract.DataBindings.Clear()
        RdOrder.DataBindings.Clear()

        'dgmpo
        txtMpoNotes.DataBindings.Clear()
        txtTechNotes.DataBindings.Clear()
        txtQANotes.DataBindings.Clear()

        txtMpo.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoNo")
        txtPart.DataBindings.Add("Text", dsMain, "tblMpoMaster.PartNumber")
        txtCustOrder.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdNumber")
        'txtPSlip.DataBindings.Add("Text", dsMain, "tblMpoMaster.PSlipNo")
        txtLotNo.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoLotNo")
        cmbDept.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.deptID")
        CmbSelCust.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.CustID")

        txtRawWeight.DataBindings.Add("Text", dsMain, "tblMpoMaster.RawWeight")

        txtMpoNotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoNotes")
        txtTechNotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoTechNotes")
        txtQANotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoQANotes")

        txtOrderNo.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdNumber")
        txtOrderDate.DataBindings.Add("Text", dsMain, "tblMpoMaster.orddate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtRefNoM3.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdRefNo")
        txtCustRefNo.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdRefNo")
        txtPONotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.notesOrder")
        txtEngInfo.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoEngInfo")
        CmbMpoType.DataBindings.Add("SelectedItem", dsMain, "tblMpoMaster.MpoType")
        cmbCust.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.CustID")
        CmbDevise.DataBindings.Add("Text", dsMain, "tblMpoMaster.orddevise")
        CmbOrderStatus.DataBindings.Add("Text", dsMain, "tblMpoMaster.ordStatus")
        txtMpoPriority.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoPriority")

        RdContract.DataBindings.Add(New Binding("Checked", dsMain, "tblMpoMaster.OrdContract", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "N0"))
        RdOrder.DataBindings.Add(New Binding("Checked", dsMain, "tblMpoMaster.OrdOrder", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "N0"))

        txtFP.DataBindings.Clear()
        txtFP.DataBindings.Add("Text", dsMain, "tblMpoMaster.FPStock")

    End Sub

    Sub PutCustomer()

        With Me.cmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub PutDept()

        With cmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub SetCtlForm()

        'dgMpo

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.OrderItemsID
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
        End With

        With Me.MpoTypeClass
            .DataPropertyName = "MpoType"
            .Name = "MpoTypeClass"
            '.DropDownWidth = 150
            '.MaxDropDownItems = 20
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.MpoDeliveryDate
            .DataPropertyName = "MpoDeliveryDate"
            .Name = "MpoDeliveryDate"
        End With

        With Me.MpoPromDate
            .DataPropertyName = "MpoPromDate"
            .Name = "MpoPromDate"
        End With

        With Me.DiffDays
            .DataPropertyName = "DiffDays"
            .Name = "DiffDays"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

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

        With Me.QtyScrapped
            .DataPropertyName = "QtyScrapped"
            .Name = "QtyScrapped"
        End With

        With Me.DeptID
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
            .DropDownWidth = 300
            .MaxDropDownItems = 40
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
        End With

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
        End With

        With Me.ChWFM
            .DataPropertyName = "ChWFM"
            .Name = "ChWFM"
        End With

        With Me.ChWFT
            .DataPropertyName = "ChWFT"
            .Name = "ChWFT"
        End With

        With Me.WKMpoSourceInsp
            .DataPropertyName = "WKMpoSourceInsp"
            .Name = "WKMpoSourceInsp"
        End With

        With Me.WKMpoCustAppr
            .DataPropertyName = "WKMpoCustAppr"
            .Name = "WKMpoCustAppr"
        End With

        With Me.WKMpoFAI
            .DataPropertyName = "WKMpoFAI"
            .Name = "WKMpoFAI"
        End With

        With Me.WKMpoDVI
            .DataPropertyName = "WKMpoDVI"
            .Name = "WKMpoDVI"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.MpoMatlWeight
            .DataPropertyName = "MpoMatlWeight"
            .Name = "MpoMatlWeight"
        End With

        With Me.MpoMatlAdj
            .DataPropertyName = "MpoMatlAdj"
            .Name = "MpoMatlAdj"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.MpoValue
            .DataPropertyName = "MpoValue"
            .Name = "MpoValue"
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
        End With

        With Me.MpoPartType
            .DataPropertyName = "MpoPartType"
            .Name = "MpoPartType"
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
        End With

        With Me.MPOExpediteValue
            .DataPropertyName = "MPOExpediteValue"
            .Name = "MPOExpediteValue"
        End With

        With Me.ProcessID
            .DataPropertyName = "ProcessID"
            .Name = "ProcessID"
        End With

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.MPOPartID
            .DataPropertyName = "MpopartID"
            .Name = "MpopartID"
            .Visible = False
        End With

        With Me.CustName
            .DataPropertyName = "CustName"
            .Name = "CustName"
        End With

        With Me.CustDelivQty
            .DataPropertyName = "CustDelivQty"
            .Name = "CustDelivQty"
        End With

        With Me.StDate
            .DataPropertyName = "StDate"
            .Name = "StDate"
        End With

        With Me.MpoRMCostCDN
            .DataPropertyName = "MpoRMCostCDN"
            .Name = "MpoRMCostCDN"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.MPORMValueUsedCDN
            .DataPropertyName = "MPORMValueUsedCDN"
            .Name = "MPORMValueUsedCDN"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.SwMachCost
            .DataPropertyName = "SwMachCost"
            .Name = "SwMachCost"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.MPOProcessingCost
            .DataPropertyName = "MPOProcessingCost"
            .Name = "MPOProcessingCost"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.SwTotCost
            .DataPropertyName = "SwTotCost"
            .Name = "SwTotCost"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.SwPerCost
            .DataPropertyName = "SwPerCost"
            .Name = "SwPerCost" 
            .Visible = False

        End With

        With Me.SwValuePrime
            .DataPropertyName = "SwValuePrime"
            .Name = "SwValuePrime"
            If RoleViewCost(wkDeptCode) = True Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With

        With Me.dgMPOPartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.TotalDaysINMFG
            .DataPropertyName = "TotalDaysINMFG"
            .Name = "TotalDaysINMFG"
        End With

        With Me.MpoQANotes
            .DataPropertyName = "MpoQANotes"
            .Name = "MpoQANotes"
        End With

        With Me.FlagColor
            .DataPropertyName = "FlagColor"
            .Name = "FlagColor"
            .Visible = False
        End With


        'dgDeliv
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

        With Me.OrderItemsIDDeliv
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.DelivType
            .DataPropertyName = "DelivType"
            .Name = "DelivType"
        End With

        With Me.DelivStatus
            .DataPropertyName = "DelivStatus"
            .Name = "DelivStatus"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

        'dgPslip

        With Me.PslipType
            .DataPropertyName = "PslipType"
            .Name = "PslipType"
        End With

        With Me.PslipOrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.PslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

        With Me.PslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.PslipTrackingNo
            .DataPropertyName = "PslipTrackingNo"
            .Name = "PslipTrackingNo"
        End With


        'dgInv

        With Me.InvPslipType
            .DataPropertyName = "PslipType"
            .Name = "PslipType"
        End With

        With Me.InvOrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
        End With

        With Me.InvPslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.InvPslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.InvInvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.InvPslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

        With Me.InvPslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.InvPslipTrackingNo
            .DataPropertyName = "PslipTrackingNo"
            .Name = "PslipTrackingNo"
        End With

        With Me.InvShortName
            .DataPropertyName = "InvShortName"
            .Name = "InvShortName"
        End With

        With Me.ShipShortName
            .DataPropertyName = "ShipShortName"
            .Name = "ShipShortName"
        End With


        'dgPODetails

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.PoNo
            .DataPropertyName = "PoNo"
            .Name = "PoNo"
        End With

        With Me.PoStatus
            .DataPropertyName = "PoStatus"
            .Name = "PoStatus"
        End With

        With Me.POSuppID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "POSuppID"
            .Name = "POSuppID"
        End With

        With Me.POType
            .DataPropertyName = "POType"
            .Name = "POType"
        End With

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.POProdID
            .DataSource = CallClass.PopulateComboBox("tblPOProdDescr", "cmbGetPoProdDescr").Tables("tblPOProdDescr")
            .DisplayMember = "ProdDescr"
            .ValueMember = "ProdID"
            .DataPropertyName = "POProdID"
            .Name = "POProdID"
        End With

        With Me.POMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "POMpoID"
            .Name = "POMpoID"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.PORMSPrice
            .DataPropertyName = "PORMSPrice"
            .Name = "PORMSPrice"
        End With

        With Me.POUM
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.POItemEscompte
            .DataPropertyName = "POItemEscompte"
            .Name = "POItemEscompte"
        End With

        With Me.TotalDetVal
            .DataPropertyName = "TotalDetVal"
            .Name = "TotalDetVal"
        End With

        'dgPORecv

        With Me.PODetailIDRecv
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
        End With

        With Me.PslipMpoIDRecv
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.RecvPSlipQty
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

        With Me.RecQtyAccp
            .DataPropertyName = "RecQtyAccp"
            .Name = "RecQtyAccp"
        End With

        'dgBar

        With Me.RouteBarID
            .DataPropertyName = "RouteBarID"
            .Name = "RouteBarID"
            .Visible = False
        End With

        With Me.MpoIDBar
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.MpoNoBar
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.OperNo
            .DataPropertyName = "OperNo"
            .Name = "OperNo"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.RouteSingleMach
            .DataPropertyName = "RouteSingleMach"
            .Name = "RouteSingleMach"
        End With

        With Me.TrOperDescr
            .DataPropertyName = "TrOperDescr"
            .Name = "TrOperDescr"
        End With

        With Me.TrOperSpec
            .DataPropertyName = "TrOperSpec"
            .Name = "TrOperSpec"
        End With

        With Me.RouteRoughFinish
            .DataPropertyName = "RouteRoughFinish"
            .Name = "RouteRoughFinish"
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.RouteStartBar
            .DataPropertyName = "RouteStart"
            .Name = "RouteStart"
        End With

        With Me.RouteEndBar
            .DataPropertyName = "RouteEnd"
            .Name = "RouteEnd"
        End With

        With Me.FinalMinutes
            .DataPropertyName = "FinalMinutes"
            .Name = "FinalMinutes"
        End With

        With Me.FinalTime
            .DataPropertyName = "FinalTime"
            .Name = "FinalTime"
        End With

        With Me.InfoQtyOkuma
            .DataPropertyName = "InfoQtyOkuma"
            .Name = "InfoQtyOkuma"
        End With

        With Me.InfoQtyRomi
            .DataPropertyName = "InfoQtyRomi"
            .Name = "InfoQtyRomi"
        End With

        With Me.InfoQyMarked
            .DataPropertyName = "InfoQyMarked"
            .Name = "InfoQyMarked"
        End With

        With Me.RouteQtyMBO
            .DataPropertyName = "RouteQtyMBO"
            .Name = "RouteQtyMBO"
        End With

        With Me.RouteQtyAcc
            .DataPropertyName = "RouteQtyAcc"
            .Name = "RouteQtyAcc"
        End With

        With Me.RouteQtyRej
            .DataPropertyName = "RouteQtyRej"
            .Name = "RouteQtyRej"
        End With

        With Me.RouteQtySetup
            .DataPropertyName = "RouteQtySetup"
            .Name = "RouteQtySetup"
        End With

        With Me.RouteQtyInsp
            .DataPropertyName = "RouteQtyInsp"
            .Name = "RouteQtyInsp"
        End With

        With Me.RouteProblems
            .DataPropertyName = "RouteProblems"
            .Name = "RouteProblems"
        End With

        With Me.RouteComments
            .DataPropertyName = "RouteComments"
            .Name = "RouteComments"
        End With

        With Me.CutWeightStart
            .DataPropertyName = "CutWeightStart"
            .Name = "CutWeightStart"
        End With

        With Me.CutWeightEndCoils
            .DataPropertyName = "CutWeightEndCoils"
            .Name = "CutWeightEndCoils"
        End With

        With Me.CutWeightQtyScrapped
            .DataPropertyName = "CutWeightQtyScrapped"
            .Name = "CutWeightQtyScrapped"
        End With

        With Me.CutMatLot
            .DataPropertyName = "CutMatLot"
            .Name = "CutMatLot"
        End With

        With Me.SetupCycleOkuma
            .DataPropertyName = "SetupCycleOkuma"
            .Name = "SetupCycleOkuma"
        End With

        With Me.SetupCycleRomi
            .DataPropertyName = "SetupCycleRomi"
            .Name = "SetupCycleRomi"
        End With

        With Me.SetupMBOLastOpDescr
            .DataPropertyName = "SetupMBOLastOpDescr"
            .Name = "SetupMBOLastOpDescr"
        End With

        With Me.SetupCycleOther
            .DataPropertyName = "SetupCycleOther"
            .Name = "SetupCycleOther"
        End With

        With Me.RouteCostMach
            .DataPropertyName = "RouteCostMach"
            .Name = "RouteCostMach"
        End With

        'With Me.SetupOpNoOther
        '    .DataPropertyName = "SetupOpNoOther"
        '    .Name = "SetupOpNoOther"
        'End With

        'dgstockres
        With Me.ResMatID
            .DataPropertyName = "ResMatID"
            .Name = "ResMatID"
            .Visible = False
        End With

        With Me.MPOIdReserv
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.MpoNoReserv
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.StLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.ResWeight
            .DataPropertyName = "ResWeight"
            .Name = "ResWeight"
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.RecvMatlHeat
            .DataPropertyName = "RecvMatlHeat"
            .Name = "RecvMatlHeat"
        End With

        With Me.RecvMatlCond
            .DataPropertyName = "RecvMatlCond"
            .Name = "RecvMatlCond"
        End With

        With Me.RecvMatlLength
            .DataPropertyName = "RecvMatlLength"
            .Name = "RecvMatlLength"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlBars
            .DataPropertyName = "RecvMatlBars"
            .Name = "RecvMatlBars"
        End With

        With Me.RecvMatlCoils
            .DataPropertyName = "RecvMatlCoils"
            .Name = "RecvMatlCoils"
        End With

        With Me.RecvMatlHex
            .DataPropertyName = "RecvMatlHex"
            .Name = "RecvMatlHex"
        End With

        With Me.ResNotes
            .DataPropertyName = "ResNotes"
            .Name = "ResNotes"
        End With

        'dgMat prefferd
        With Me.PartMatlID
            .DataPropertyName = "PartMatlID"
            .Name = "PartMatlID"
            .Visible = False
        End With

        With Me.MatlPrefPartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.MatlDetIDPref
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetIDPref"
            .DropDownWidth = 500
            .MaxDropDownItems = 20
        End With

        With Me.MatlForm
            .DataPropertyName = "MatlForm"
            .Name = "MatlForm"
        End With

        With Me.MatlDia
            .DataPropertyName = "MatlDia"
            .Name = "MatlDia"
        End With

        'dgMBO Calculation
        With Me.TrMpoID
            .DataPropertyName = "TrMpoID"
            .Name = "TrMpoID"
            .Visible = False
        End With

        With Me.TrMBOCheck
            .DataPropertyName = "TrMBOCheck"
            .Name = "TrMBOCheck"
        End With

        With Me.TrMBOSendCell
            .DataPropertyName = "TrMBOSendCell"
            .Name = "TrMBOSendCell"
        End With

        With Me.TrOperNo
            .DataPropertyName = "TrOperNo"
            .Name = "TrOperNo"
        End With

        With Me.TrQtyOKuma
            .DataPropertyName = "TrQtyOKuma"
            .Name = "TrQtyOKuma"
        End With

        With Me.TrQtyRomi
            .DataPropertyName = "TrQtyRomi"
            .Name = "TrQtyRomi"
        End With

        With Me.TrQtyMarking
            .DataPropertyName = "TrQtyMarking"
            .Name = "TrQtyMarking"
        End With

        With Me.MBOTrOperDescr
            .DataPropertyName = "TrOperDescr"
            .Name = "TrOperDescr"
        End With

        With Me.MBOTrOperSpec
            .DataPropertyName = "TrOperSpec"
            .Name = "TrOperSpec"
        End With

        With Me.QtyAccTemp
            .DataPropertyName = "QtyAccTemp"
            .Name = "QtyAccTemp"
        End With

        With Me.MBODeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.OperStart
            .DataPropertyName = "OperStart"
            .Name = "OperStart"
        End With

        With Me.OperEnd
            .DataPropertyName = "OperEnd"
            .Name = "OperEnd"
        End With

        With Me.MBOFinalTime
            .DataPropertyName = "MBOFinalTime"
            .Name = "MBOFinalTime"
        End With

        With Me.DeptPer
            .DataPropertyName = "DeptPer"
            .Name = "DeptPer"
        End With

        With Me.TrMachCost
            .DataPropertyName = "TrMachCost"
            .Name = "TrMachCost"
        End With

        With Me.TrDeptHrRate
            .DataPropertyName = "TrDeptHrRate"
            .Name = "TrDeptHrRate"
        End With

        With Me.TotalTime
            .DataPropertyName = "TotalTime"
            .Name = "TotalTime"
        End With

        'dgActualQty

        With Me.MPOTrID
            .DataPropertyName = "MPOTrID"
            .Name = "MPOTrID"
            .Visible = False
        End With

        With Me.MpoNoHist
            .DataPropertyName = "MpoNoHist"
            .Name = "MpoNoHist"
        End With

        With Me.EmpNameHist
            .DataPropertyName = "EmpNameHist"
            .Name = "EmpNameHist"
        End With

        With Me.DateTranz
            .DataPropertyName = "DateTranz"
            .Name = "DateTranz"
        End With

        With Me.QtyActualHist
            .DataPropertyName = "QtyActualHist"
            .Name = "QtyActualHist"
        End With

        With Me.QtyActualOld
            .DataPropertyName = "QtyActualOld"
            .Name = "QtyActualOld"
        End With

        With Me.QtyVariance
            .DataPropertyName = "QtyVariance"
            .Name = "QtyVariance"
        End With

        With Me.ValueVariance
            .DataPropertyName = "ValueVariance"
            .Name = "ValueVariance"
        End With

        'dgAssy

        With Me.PartAssyID
            .DataPropertyName = "PartAssyID"
            .Name = "PartAssyID"
            .Visible = False
        End With

        With Me.PartNoID
            .DataPropertyName = "PartNoID"
            .Name = "PartNoID"
            .Visible = False
        End With

        With Me.PartCompID
            .DataPropertyName = "PartCompID"
            .Name = "PartCompID"
            .Visible = False
        End With

        With Me.PartNumberAssy
            .DataPropertyName = "PartNumberAssy"
            .Name = "PartNumberAssy"
        End With

        With Me.PartAssyName
            .DataPropertyName = "PartAssyName"
            .Name = "PartAssyName"
        End With

        With Me.PartAssyNotes
            .DataPropertyName = "PartAssyNotes"
            .Name = "PartAssyNotes"
        End With

        'dgAssyDetail

        With Me.MpoNoDet
            .DataPropertyName = "MpoNoDet"
            .Name = "MpoNoDet"
        End With

        With Me.PartNoDet
            .DataPropertyName = "PartNoDet"
            .Name = "PartNoDet"
        End With

        With Me.LotNoDet
            .DataPropertyName = "LotNoDet"
            .Name = "LotNoDet"
        End With

        With Me.QtyActualDet
            .DataPropertyName = "QtyActualDet"
            .Name = "QtyActualDet"
        End With

        With Me.DeptNodeDet
            .DataPropertyName = "DeptNodeDet"
            .Name = "DeptNodeDet"
        End With

        With Me.FinalStDet
            .DataPropertyName = "FinalStDet"
            .Name = "FinalStDet"
        End With

        'dgBlanks
        With Me.BLMpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.BLPartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.BLDeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.BLQtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.BLQtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.BLQtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        'dgMatlFromBlanks

        With Me.FromBLPartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartNotes
            .DataPropertyName = "PartNotes"
            .Name = "PartNotes"
        End With

        ' dgMEMO

        With Me.MemoID
            .DataPropertyName = "MemoID"
            .Name = "MemoID"
            .Visible = False
        End With

        With Me.CmdViewMemo
            .DataPropertyName = "CmdViewMemo"
            .Name = "CmdViewMemo"
        End With

        With Me.MemoNo
            .DataPropertyName = "MemoNo"
            .Name = "MemoNo"
        End With

        With Me.MemoNoPrefix
            .DataPropertyName = "MemoNoPrefix"
            .Name = "MemoNoPrefix"
        End With

        With Me.MemoMPONo
            .DataPropertyName = "MemoMPONo"
            .Name = "MemoMPONo"
        End With

        With Me.MemoMpoStatus
            .DataPropertyName = "MemoMpoStatus"
            .Name = "MemoMpoStatus"
        End With

        With Me.MemoCustomer
            .DataPropertyName = "MemoCustomer"
            .Name = "MemoCustomer"
        End With

        With Me.MemoPartNumber
            .DataPropertyName = "MemoPartNumber"
            .Name = "MemoPartNumber"
        End With

        With Me.MpoQty
            .DataPropertyName = "MpoQty"
            .Name = "MpoQty"
        End With

        With Me.MemoMpoType
            .DataPropertyName = "MemoMpoType"
            .Name = "MemoMpoType"
        End With

        With Me.MemoQtyRwk
            .DataPropertyName = "MemoQtyRwk"
            .Name = "MemoQtyRwk"
        End With

        With Me.MemoQtyScrap
            .DataPropertyName = "MemoQtyScrap"
            .Name = "MemoQtyScrap"
        End With

        With Me.MemoDeptQtyRej
            .DataPropertyName = "MemoDeptQtyRej"
            .Name = "MemoDeptQtyRej"
        End With

        With Me.SeeMemoNo
            .DataPropertyName = "SeeMemoNo"
            .Name = "SeeMemoNo"
        End With

        With Me.ActionDescr
            .DataPropertyName = "ActionDescr"
            .Name = "ActionDescr"
        End With

        'dgcross

        With Me.CrPartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.CrPartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.CrPartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

    End Sub

    Private Sub dgMpo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMpo.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMpo = e.RowIndex
        End If

        If dgMpo.Item("MpoStatus", e.RowIndex).Value <> "Active" Then
            If RoleQA(wkDeptCode) = False Then
                MsgBox("Action Denied. Mpo Status is not Active.")
                e.Cancel = True
                Exit Sub
            Else
                GoTo NextStep
            End If
        Else
            GoTo NextStep
        End If

NextStep:
        RowMpo = e.RowIndex

        OldQtyActual = Nz.Nz(dgMpo("QtyActual", e.RowIndex).Value)
        OldQty = Nz.Nz(dgMpo("QtyEngReleased", e.RowIndex).Value)
        OldQtyReq = Nz.Nz(dgMpo("QtyOrder", e.RowIndex).Value)

        OldDept = Nz.Nz(dgMpo("DeptID", e.RowIndex).Value)

        If RolePlanning(wkDeptCode) = True Then
            Select Case e.ColumnIndex   ' start prod date; qty actual; qty rel; dept; wfm; wft; qa flag
                '
                Case 4, 5, 6, 7, 10, 11, 14, 15, 17
                    '9, 10, 13, 14, 16
                    e.Cancel = True
                Case 20 To 31
                    '19 To 30
                    e.Cancel = True
                Case 35 To 48
                    '34 To 47
                    e.Cancel = True
                Case 3

                    OldMpoType = dgMpo("MpoTypeClass", RowMpo).Value

                    If IsDBNull(dgMpo("MpoTypeClass", RowMpo).Value) = True Then
                        Exit Sub
                    End If

                Case 13     '12 old
                    If IsDBNull(txtEngInfo.Text) = True Then
                    Else
                        If Len(Trim(txtEngInfo.Text)) > 0 Then
                            MsgBox("Access Denied.")
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
            End Select
        Else
            If RoleEng(wkDeptCode) = True Then
                Select Case e.ColumnIndex           'eng,   13 = sales qty req also give access to QA flags
                    Case 0 To 13
                        '0 To 12
                        e.Cancel = True
                    Case 15                         'old 14
                        e.Cancel = True
                    Case 24 To 31
                        '23 To 30
                        e.Cancel = True
                    Case 34 To 48
                        '33 To 47
                        e.Cancel = True
                End Select
            Else
                If RoleQA(wkDeptCode) = True Then
                    Select Case e.ColumnIndex           'QA FRlags,   12 = sales qty req
                        Case 0 To 19
                            '0 To 18
                            e.Cancel = True
                        Case 24 To 31
                            '23 To 30
                            e.Cancel = True
                        Case 34 To 48
                            '33 To 47
                            e.Cancel = True
                    End Select
                Else
                    If RoleSalesFR(wkDeptCode) = True Then
                        Select Case e.ColumnIndex       ' sales forecast only 2 mpo priority
                            Case 0 To 1
                                e.Cancel = True
                            Case 3 To 31
                                '3 To 30
                                e.Cancel = True
                            Case 34 To 48
                                '33 To 47
                                e.Cancel = True
                        End Select
                    Else

                        Select Case e.ColumnIndex           'everybody
                            Case 0 To 31
                                '0 To 30
                                e.Cancel = True
                            Case 33 To 47
                                '34 To 48
                                e.Cancel = True
                        End Select
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgMpo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMpo = e.RowIndex
        End If

        Dim SwFlags As String = ""

        Select Case e.ColumnIndex
            Case 2
                UpdateMpoPriority()
            Case Is = 3
                Dim reply As DialogResult
                reply = MsgBox("Accept changes (Yes/No)?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                   
                    UpdateMpoClassification()

                Else
                    dgMpo("MpoTypeClass", RowMpo).Value = OldMpoType
                End If

            Case 8 'MPO Promised Date
                UpdateMPOPromDate()
            Case 9 'start prod date
                '8 'start prod date
                UpdateStartProdDate()

            Case 12 'qtyActual
                '11 'qtyActual
                UpdateQtyActual()
                UpdateHystoryQtyActual()

            Case 13 'qty released
                '12 'qty released
                Dim reply As DialogResult
                Dim DifQty As String
                Dim QtyA As String
                Dim QtyE As String
                QtyA = Nz.Nz(dgMpo("QtyActual", RowMpo).Value)
                QtyE = OldQty
                DifQty = QtyA - QtyE
                If DifQty > 30 Then
                    If IsDBNull(dgMpo("MpoMatlAdj", RowMpo).Value) = True Or Len(Trim(Nz.Nz(dgMpo("MpoMatlAdj", RowMpo).Value))) = 0 = True Then
                        dgMpo("QtyEngReleased", RowMpo).Value = OldQty
                        MsgBox("You can not modify the Eng Released Qty. An adjustment for raw material should be done before.")

                        If dgMpo("MpoTypeClass", RowMpo).Value <> "Assembly" Then

                            reply = MsgBox("Do you want to send an Email to Inspection ? ", MsgBoxStyle.YesNo)
                            If reply = Windows.Forms.DialogResult.Yes Then
                                Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
                                Dim strBody As String = ""
                                NotesSession = CreateObject("Notes.NotesSession")
                                If Len(wkEmpLogin) > 8 Then
                                    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
                                Else
                                    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
                                End If
                                NotesDoc = NotesDb.CREATEDOCUMENT
                                NotesItem = NotesDoc.CreateRichTextItem("BODY")
                                'NotesDoc.Form = "Memo"
                                NotesDoc.Subject = "Shop Floor Control"
                                strBody = "This is to inform you" & vbCrLf
                                strBody = strBody & "that for the MPO Number: " & dgMpo("MPONo", RowMpo).Value & vbCrLf
                                strBody = strBody & " a Raw Material adjustment must be done."
                                NotesDoc.body = strBody

                                Call NotesDoc.SEND(False, "inspection.Montreal@lisi-aerospace.com")
                            End If
                        End If
                    Else
                        reply = MsgBox("Edit Quantity Released ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            UpdateQtyReleased()
                        Else
                            dgMpo("QtyEngReleased", RowMpo).Value = OldQty
                        End If
                    End If
                Else
                    reply = MsgBox("Edit Quantity Released ?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        UpdateQtyReleased()
                    Else
                        dgMpo("QtyEngReleased", RowMpo).Value = OldQty
                    End If
                End If

                PutErrorMessage()

            Case 14 'qty sales requested
                '13 'qty sales requested

                Dim reply As DialogResult
                reply = MsgBox("Edit Sales Quantity Requested ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateQtyRequested()
                Else
                    dgMpo("QtyOrder", RowMpo).Value = OldQtyReq
                End If

            Case 16  'Dept
                '15  'Dept
                If RoleEng(wkDeptCode) = True Then
                    SwOperNo = 2
                    Dim SwDept As Integer = 0
                    Dim SwProd As String = ""

                    ' old department check
                    SwDept = OldDept
                    SwProd = CallClass.ReturnStrWithParInt("cspReturnRoleEng", SwDept)
                    If SwProd = 0 Then
                        MsgBox("Access denied.")
                        dgMpo("DeptID", RowMpo).Value = OldDept
                        Exit Sub
                    End If

                    SwDept = dgMpo("DeptID", e.RowIndex).Value
                    SwProd = CallClass.ReturnStrWithParInt("cspReturnRoleEng", SwDept)
                    If SwProd <> "1" Then
                        If dgMpo("DeptID", e.RowIndex).Value <> 16 Then  ' freeeze code 16 = Planing dept
                            MsgBox("Access denied.")
                            dgMpo("DeptID", RowMpo).Value = OldDept
                            Exit Sub
                        End If
                    End If
                Else
                    SwOperNo = 3
                End If

                UpdateMpoDept()

                UpdateRouteEndException()
                VerifyEmpInRouting()
                If IReturn = 0 Then     'there is no oper open with mpo and emp in routing
                    AddStartEndOper()
                Else
                    MsgBox("!!! ERROR !!! Operation already exist in routing.")
                End If


            Case 17
                '16
                UpdateMpoNewOrder()
            Case 18
                '17
                UpdateMpoWFM()
            Case 19
                '18
                UpdateMpoWFT()
            Case 20
                '19
                UpdateMpoCustAppr()
                SwFlags = "Cust. Approval"
                CheckQAFlags(SwFlags)
            Case 21
                '20
                UpdateMpoSourceInsp()
                SwFlags = "Source Inspection"
                CheckQAFlags(SwFlags)
            Case 22
                '21
                UpdateMpoWKMpoFAI()
                SwFlags = "F.A.I."
                CheckQAFlags(SwFlags)
            Case 23
                '22
                UpdateMpoWKMpoDVI()
                SwFlags = "D.V.I."
                CheckQAFlags(SwFlags)
            Case 32
                '31
                UpdateMpoNotes()
            Case 33
                '32
                UpdateMpoTechNotes()
            Case 34
                '33
                UpdateMpoExpediteValue()
        End Select

    End Sub

    Sub UpdateMpoPriority()
        If IsDBNull(dgMpo("MpoPriority", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoPriority", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraPriority As SqlParameter = New SqlParameter("@MpoPriority", SqlDbType.NVarChar, 5)
        paraPriority.Value = dgMpo("MpoPriority", RowMpo).Value
        mySqlComm.Parameters.Add(paraPriority)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Priority: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateRouteEndException()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteEndCaseException", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = SwOperNo
        mySqlComm.Parameters.Add(paraOperNo)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("UpdateRouteEndException - Module - frmShopFloorControl: " & ex.Message)

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub VerifyEmpInRouting()

        ' if the operator exit in one operation open
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspRouteCheckExistMPOAndOper", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = SwOperNo
        mySqlComm.Parameters.Add(paraOperNo)

        '=================
        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.Int, 4)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

      
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, Integer)
            Else
                IReturn = 0
            End If

        Catch ex As SqlException
            MsgBox("Verify MPO and Oper in Routing: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub AddStartEndOper()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteAddOperStartEnd", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = SwOperNo
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDeptID As SqlParameter = New SqlParameter("@SwDeptID", SqlDbType.Int, 4)
        paraDeptID.Value = dgMpo("DeptID", RowMpo).Value
        mySqlComm.Parameters.Add(paraDeptID)

        Dim paraEmpID As SqlParameter = New SqlParameter("@SwEmpID", SqlDbType.Int, 4)
        paraEmpID.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmpID)

        Dim paraDeptWhat As SqlParameter = New SqlParameter("@DeptWhat", SqlDbType.NVarChar, 20)
        paraDeptWhat.Value = ""
        mySqlComm.Parameters.Add(paraDeptWhat)

       
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add Operation Start: " & ex.Message)

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


    Sub CheckQAFlags(ByVal SwFlag As String)

        'Dim email As New Mail.MailMessage()
        'Dim strBody As String = ""
        'email.Subject = " !!! ATTENTION !!!"
        'strBody = "Please note that for the MPO: " + txtMpo.Text + " one of QA flags << " + SwFlag + " >> was activated/desactivated in MRP."
        'email.Body = strBody

        'Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
        'email.From = New Net.Mail.MailAddress(wkEmpEmail)
        'email.To.Add(New Mail.MailAddress("ventes.montreal@lisi-aerospace.com"))
        'client.Send(email)

    End Sub
    Private Sub dgMpo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEnter

        If e.RowIndex < 0 Then
            Return
        Else
            RowMpo = e.RowIndex
        End If

        'If e.RowIndex < 0 Then
        '    Exit Sub
        'Else
        '    RowMpo = e.RowIndex
        'End If

        If Len(Trim(Convert.ToString(dgMpo.Item("ProcessID", e.RowIndex).Value))) = 0 Then
            CmdMethod.Enabled = False
        Else
            CmdMethod.Enabled = True
        End If

        CalculMpoValue()
        CalculActRelOrd()
        CalculMpoWeight()

        RowMpo = e.RowIndex

        OldQtyActual = Nz.Nz(dgMpo("QtyActual", e.RowIndex).Value)
        OldQty = Nz.Nz(dgMpo("QtyEngReleased", e.RowIndex).Value)
        OldQtyReq = Nz.Nz(dgMpo("QtyOrder", e.RowIndex).Value)

        OldDept = Nz.Nz(dgMpo("DeptID", e.RowIndex).Value)

        'is a killer PutErrorMessage()

        If IsDBNull(dgMpo("MpoTypeClass", RowMpo).Value) = True Then
            Exit Sub
        End If

        If dgMpo("MpoTypeClass", RowMpo).Value <> "Standard" And _
            dgMpo("MpoTypeClass", RowMpo).Value <> "Expedite" Then
            Exit Sub
        End If

    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Private Sub cmdPrintLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLot.Click

        If dgMpo.Rows.Count - 1 >= 0 Then
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptMatlLotNumber

            rptPO.Load("..\rptMatlLotNumber.rpt")
            pdvCustomerName.Value = txtLotNo.Text
            pvCollection.Add(pdvCustomerName)
            rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.ShowDialog()

            rptPO.Close()
            rptPO.Dispose()

        Else
            MsgBox("Nothing to View.")
        End If

    End Sub

    Private Sub txtMpo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMpo.Click
        dsMain.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtMpo.Focus()

    End Sub

    Private Sub txtPart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPart.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtPart.Focus()

    End Sub

    Private Sub txtCustOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustOrder.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtCustOrder.Focus()
    End Sub

    Private Sub txtPSlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPSlip.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtPSlip.Focus()
    End Sub

    Private Sub txtLotNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNo.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtLotNo.Focus()
    End Sub

    Private Sub cmbDept_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.DropDownClosed
        Dim strSearch As String
        strSearch = cmbDept.SelectedValue

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        cmbDept.Focus()

        If RdAll.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlDeptID", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdActive.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlDeptIDActive", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdClosed.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlDeptIDClosed", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdCancelled.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlDeptIDCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

    End Sub

    Private Sub CmbSelCust_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSelCust.DropDownClosed

        Dim strSearch As String
        strSearch = CmbSelCust.SelectedValue

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        CmbSelCust.Focus()

        If RdAll.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlCustID", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdActive.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlCustIDActive", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdClosed.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlCustIDClosed", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdCancelled.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlCustIDCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


    End Sub

    Sub ContinueAfterSrc()

        PutTablesAdapters()

        CalculMpoValue()


        CalculActRelOrd()

        'CalculDiffTime()
        CalculDiffTimeBarCode()

        CalculPodetail()
        PutDetailTotal()
        PutTotalRecv()

        PutErrorMessage()

    End Sub

  
    Private Sub txtMpo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMpo.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim strSearch As String
            strSearch = txtMpo.Text



            If RdAll.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpo", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdActive.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoActive", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdClosed.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoClosed", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdCancelled.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If

    End Sub

    Private Sub txtPart_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPart.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            strSearch = txtPart.Text

            'dsMain.Clear()
            'If cn.State = ConnectionState.Open Then
            '    cn.Close()
            'End If

            If RdAll.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlPartNo", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdActive.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlPartNoActive", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdClosed.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlPartNoClosed", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdCancelled.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlPartNoCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If

    End Sub

    Function RolePlanning(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "PL" Then
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

    Function RoleEng(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ENG" Then
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

    Function RoleQA(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "QAFlags" Then
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

    Function RoleViewCost(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "VIEWSHOPCOST" Then
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

    Function RoleMBOCheck(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SHOPMBO" Then
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

    Sub CalculMpoWeight()

        Me.ErrorProvider2.Clear()

        If IsDBNull(dgMpo("QtyEngReleased", RowMpo).Value) = False Then
            txtReleasedWeight.Text = Val(txtRawWeight.Text) * Val(dgMpo("QtyEngReleased", RowMpo).Value)
        Else
            txtReleasedWeight.Text = 0
        End If

        If IsDBNull(dgMpo("QtyActual", RowMpo).Value) = False Then
            txtActualWeight.Text = Val(txtRawWeight.Text) * Val(dgMpo("QtyActual", RowMpo).Value)
        Else
            txtActualWeight.Text = 0
        End If

        If IsDBNull(dgMpo("MpoMatlWeight", RowMpo).Value) = True Then
            Exit Sub
        End If


        If Val(txtRawWeight.Text) > 0 Then
            If (Nz.Nz(dgMpo("MpoMatlWeight", RowMpo).Value) + Nz.Nz(dgMpo("MpoMatlAdj", RowMpo).Value)) > 0 Then

                Dim SwWeight As Double = 0.0
                SwWeight = dgMpo("MpoMatlWeight", RowMpo).Value + Nz.Nz(dgMpo("MpoMatlAdj", RowMpo).Value)

                If Val(txtReleasedWeight.Text) >= SwWeight - (SwWeight * 0.2) And _
                Val(txtReleasedWeight.Text) <= SwWeight + (SwWeight * 0.2) Then
                    Me.ErrorProvider2.Clear()
                Else
                    Me.ErrorProvider2.SetError(txtReleasedWeight, "!!! Error !!! Estimated Released Weight not in Range With Cutting Weight")
                    Me.ErrorProvider2.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
                End If
            End If
        End If

    End Sub

    Sub CalculMpoValue()

        'For Each Row As DataGridViewRow In dgMpo.Rows
        '    Row.Cells("MpoValue").Value = Nz.Nz(Row.Cells("QtyActual").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value)
        'Next

        Dim I As Integer = 0

        For I = 0 To dgMpo.Rows.Count - 1
            If IsDBNull(Me.dgMpo("QtyActual", I).Value) = False And _
               IsDBNull(Me.dgMpo("OrdItemPrice", I).Value) = False Then
                Me.dgMpo("MpoValue", I).Value = Me.dgMpo("QtyActual", I).Value * Me.dgMpo("OrdItemPrice", I).Value
            Else
                Me.dgMpo("MpoValue", I).Value = 0
            End If

            Me.dgMpo("SwTotCost", I).Value = Nz.Nz(Me.dgMpo("MpoRMCostCDN", I).Value) + _
                                             Nz.Nz(Me.dgMpo("SwMachCost", I).Value) + _
                                             Nz.Nz(Me.dgMpo("MPOProcessingCost", I).Value)
            If Nz.Nz(Me.dgMpo("OrdItemPrice", I).Value) = 0 Then
                Me.dgMpo("SwPerCost", I).Value = 0
                Me.dgMpo("SwValuePrime", I).Value = 0
            Else
                Me.dgMpo("SwValuePrime", I).Value = (Me.dgMpo("SwTotCost", I).Value * Nz.Nz(Me.dgMpo("QtyActual", I).Value))
                If Nz.Nz(Me.dgMpo("QtyActual", I).Value) = 0 Then
                    Me.dgMpo("SwPerCost", I).Value = DBNull.Value
                Else
                    Me.dgMpo("SwPerCost", I).Value = (Me.dgMpo("SwValuePrime", I).Value / (Nz.Nz(Me.dgMpo("QtyActual", I).Value) * Nz.Nz(Me.dgMpo("OrdItemPrice", I).Value))) * 100
                    'Me.dgMpo("SwPerCost", I).Value = Math.Round((100 - (Nz.Nz(Me.dgMpo("SwTotCost", I).Value) / Nz.Nz(Me.dgMpo("OrdItemPrice", I).Value)) * 100), 2)
                End If
            End If

            If Me.dgMpo("SwTotCost", I).Value = 0 Then
                Me.dgMpo("SwPerCost", I).Value = DBNull.Value
                Me.dgMpo("SwValuePrime", I).Value = DBNull.Value
            End If
            If Nz.Nz(Me.dgMpo("OrdItemPrice", I).Value) <= 1 Then
                Me.dgMpo("SwPerCost", I).Value = DBNull.Value
            End If
        Next

        'qRes = txtWeightRes.Text
        'qFinal = Nz.Nz(dgMatl("StFinal", e.RowIndex).Value)
        'qdif = qFinal - qRes

        'dgMatl("Balance", e.RowIndex).Value = qdif

    End Sub

    'Sub CalculDiffTime()

    '    Dim DiffTime As Integer = 0
    '    Dim TDays As Integer = 0
    '    Dim THr As Integer = 0

    '    Dim DateStart As Date
    '    Dim DateEnd As Date

    '    For Each Row As DataGridViewRow In dgRoute.Rows
    '        If IsDBNull(Row.Cells("RouteStart").Value) = True Then
    '            Row.Cells("DiffTime").Value = 0
    '            Exit Sub
    '        Else
    '            DateStart = Row.Cells("RouteStart").Value
    '        End If

    '        If IsDBNull(Row.Cells("RouteEnd").Value) = True Then
    '            Row.Cells("DiffTime").Value = 0
    '            Exit Sub
    '        Else
    '            DateEnd = Row.Cells("RouteEnd").Value
    '        End If

    '        DiffTime = DateDiff(DateInterval.Minute, DateStart, DateEnd)
    '        Row.Cells("DiffTime").Value = DiffTime

    '        TDays = DateDiff(DateInterval.Day, DateStart, DateEnd)
    '        THr = DateDiff(DateInterval.Hour, DateStart, DateEnd)

    '        Row.Cells("RouteDetail").Value = IIf(TDays = 0, "", TDays.ToString + "Day  ") + _
    '                IIf(THr = 0, "", (THr - (TDays * 24)).ToString + "  Hr  ") _
    '                + (DiffTime - (THr * 60)).ToString + "  Min"
    '    Next

    'End Sub

    Sub CalculDiffTimeBarCode()

        Dim DiffTime As Integer = 0
        Dim TDays As Integer = 0
        Dim THr As Integer = 0

        Dim DateStart As Date
        Dim DateEnd As Date

        For Each Row As DataGridViewRow In dgBar.Rows
            If IsDBNull(Row.Cells("RouteStart").Value) = True Then
                Row.Cells("FinalMinutes").Value = 0
                GoTo NextOper
            Else
                DateStart = Row.Cells("RouteStart").Value
            End If

            If IsDBNull(Row.Cells("RouteEnd").Value) = True Then
                Row.Cells("FinalMinutes").Value = 0
                GoTo NextOper
            Else
                DateEnd = Row.Cells("RouteEnd").Value
            End If

            DiffTime = DateDiff(DateInterval.Minute, DateStart, DateEnd)
            Row.Cells("FinalMinutes").Value = DiffTime.ToString

            TDays = DateDiff(DateInterval.Day, DateStart, DateEnd)
            THr = DateDiff(DateInterval.Hour, DateStart, DateEnd)

            Row.Cells("FinalTime").Value = IIf(TDays = 0, "", TDays.ToString + "Day  ") + _
                    IIf(THr = 0, "", (THr - (TDays * 24)).ToString + "  Hr  ") _
                    + (DiffTime - (THr * 60)).ToString + "  Min"
NextOper:
        Next

        Dim qty As Double = 0.0

        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("InfoQtyOkuma").Value)
        Next
        txtOkuma.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("InfoQtyRomi").Value)
        Next
        txtRomi.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("InfoQyMarked").Value)
        Next
        txtMarked.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("RouteQtyMBO").Value)
        Next
        txtMBO.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("RouteQtyRej").Value)
        Next
        txtQtyRej.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("RouteQtySetup").Value)
        Next
        txtQtySetup.Text = qty.ToString("N0")

        qty = 0.0
        For Each rBar As DataGridViewRow In dgBar.Rows
            qty = qty + Nz.Nz(rBar.Cells("RouteCostMach").Value)
        Next
        txtMachCost.Text = qty.ToString("C2")

    End Sub

    Sub PutErrorMessage()

        Dim RetVal As String
        Dim StrSearch As Integer

        Me.ErrorProvider1.Clear()

        For Each Row As DataGridViewRow In dgMpo.Rows
            If (Nz.Nz(Row.Cells("QtyEngReleased").Value) - Nz.Nz(Row.Cells("QtyActual").Value)) < 0 And _
                 Nz.Nz(Row.Cells("MpoStatus").Value) = "Active" Then
                Me.ErrorProvider1.SetError(dgMpo, "Qty Actual is Greater than Qty Released OR Raw Material is not released to Production")
                Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
                Row.Cells("QtyActual").Style.BackColor = Color.DarkRed
            Else
                Row.Cells("QtyActual").Style.BackColor = Color.LightBlue
            End If

            StrSearch = Nz.Nz(Row.Cells("DeptID").Value)

            RetVal = CallClass.ReturnStrWithParInt("cspReturnDeptEngValue", StrSearch)

            If Val(RetVal) = 0 Then
                If (IsDBNull(Row.Cells("MpoLotNo").Value) = True Or _
                Len(Trim(Nz.Nz(Row.Cells("MpoLotNo").Value))) = 0 = True) And _
                    InStr(Row.Cells("MpoNo").Value, "ASSY", vbTextCompare) = 0 Then

                    Row.Cells("MpoLotNo").Style.BackColor = Color.DarkRed
                Else
                    Row.Cells("MpoLotNo").Style.BackColor = Color.White
                End If
            End If

            If Nz.Nz(Row.Cells("QtyActual").Value) > 0 Then
                If (Nz.Nz(Row.Cells("QtyActual").Value) - Nz.Nz(Row.Cells("CustDelivQty").Value)) < 0 And _
                       Nz.Nz(Row.Cells("MpoStatus").Value) = "Active" Then
                    Row.Cells("QtyActual").Style.BackColor = Color.LightGreen
                End If
            End If

            If Row.Cells("MpoStatus").Value = "Active" Then
                If IsDBNull(Row.Cells("FlagColor").Value) = False Then
                    If (Row.Cells("FlagColor").Value) = True Then
                        Row.Cells("MpoPriority").Style.BackColor = Color.YellowGreen
                        Row.Cells("PartNumber").Style.BackColor = Color.YellowGreen
                        Row.Cells("MpoNo").Style.BackColor = Color.YellowGreen
                    End If
                End If
            End If


        Next

    End Sub

    Sub UpdateHystoryQtyActual()
        If RowMpo < 0 Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("[cspUpdateInsertQtyActualHystory]", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraEmp As SqlParameter = New SqlParameter("@EmpID", SqlDbType.Int, 4)
        paraEmp.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmp)

        Dim paraDt As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraDt.Value = Now
        mySqlComm.Parameters.Add(paraDt)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQty.Value = dgMpo("QtyActual", RowMpo).Value
        mySqlComm.Parameters.Add(paraQty)

        Dim paraQtyOld As SqlParameter = New SqlParameter("@QtyActualOld", SqlDbType.Real, 4)
        paraQtyOld.Value = OldQtyActual
        mySqlComm.Parameters.Add(paraQtyOld)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update History Mpo Qty Actual: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateQtyActual()

        If RowMpo < 0 Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyActual", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQty.Value = dgMpo("QtyActual", RowMpo).Value
        mySqlComm.Parameters.Add(paraQty)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Qty Actual: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateQtyReleased()

        If IsDBNull(dgMpo("QtyEngReleased", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleased", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
        paraQty.Value = dgMpo("QtyEngReleased", RowMpo).Value
        mySqlComm.Parameters.Add(paraQty)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Qty Released: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateQtyRequested()
        If IsDBNull(dgMpo("QtyOrder", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtySales", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyOrder", SqlDbType.Real, 4)
        paraQty.Value = dgMpo("QtyOrder", RowMpo).Value
        mySqlComm.Parameters.Add(paraQty)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Update Mpo Sales Qty Requested: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoDept()

        If IsDBNull(dgMpo("DeptID", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
        paraDept.Value = dgMpo("DeptID", RowMpo).Value
        mySqlComm.Parameters.Add(paraDept)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Dept.: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoRevision()

        If IsDBNull(dgMpo("MpoPartRev", RowMpo).Value) = True Then
            dgMpo("MpoPartRev", RowMpo).Value = ""
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoRevision", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraMpoRev As SqlParameter = New SqlParameter("@MpoPartRev", SqlDbType.NVarChar, 25)
        paraMpoRev.Value = dgMpo("MpoPartRev", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoRev)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Update Mpo Revision: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

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
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Notes: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
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
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Technical Notes: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoQANotes()

        If IsDBNull(dgMpo("MpoQANotes", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQANotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoQANotes", SqlDbType.NVarChar, 1000)
        paraNotes.Value = dgMpo("MpoQANotes", RowMpo).Value
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo QA Notes: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoExpediteValue()

        If IsDBNull(dgMpo("MpoExpediteValue", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoExpediteValue", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraExp As SqlParameter = New SqlParameter("@MpoExpediteValue", SqlDbType.SmallMoney, 4)
        paraExp.Value = dgMpo("MpoExpediteValue", RowMpo).Value
        mySqlComm.Parameters.Add(paraExp)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Expedite Value: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


    Sub UpdateMpoClassification()
        If IsDBNull(dgMpo("MpoTypeClass", RowMpo).Value) = True Then
            Exit Sub
        End If

        'If dgMpo("MpoTypeClass", RowMpo).Value <> "Standard" And _
        '            dgMpo("MpoTypeClass", RowMpo).Value <> "Standard (RM NULL)" And _
        '            dgMpo("MpoTypeClass", RowMpo).Value <> "Expedite" Then
        '    MsgBox("!!! ERROR !!! MPO Classification.")
        '    dgMpo.Refresh()
        '    Exit Sub
        'End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoType", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraType As SqlParameter = New SqlParameter("@MpoType", SqlDbType.NVarChar, 25)
        paraType.Value = dgMpo("MpoTypeClass", RowMpo).Value
        mySqlComm.Parameters.Add(paraType)

        Dim paraNotes As SqlParameter = New SqlParameter("@MPONotes", SqlDbType.NVarChar, 2000)
        txtMpoNotes.Text = txtMpoNotes.Text + vbCrLf + "MPO Classification was changed From: " + OldMpoType + _
                            " TO: " + dgMpo("MpoTypeClass", RowMpo).Value + _
                            " on " + Now.ToShortDateString
        paraNotes.Value = txtMpoNotes.Text
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Classification: " & ex.Message)
            dgMpo("MpoTypeClass", RowMpo).Value = OldMpoType
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Sub UpdateStartProdDate()

        'DelDate = CDate(dgDel("DelivDate", RowDeliv).Value).ToShortDateString
        'StartDate = DateAdd(DateInterval.Day, -112, DelDate).ToShortDateString      '16 wks
        'EndDate = DateAdd(DateInterval.Day, -35, DelDate).ToShortDateString         '5 wks

        If IsDBNull(dgMpo("StartProdDate", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoStartProdDate", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraStart As SqlParameter = New SqlParameter("@StartProdDate", SqlDbType.SmallDateTime, 4)
        paraStart.Value = dgMpo("StartProdDate", RowMpo).Value
        mySqlComm.Parameters.Add(paraStart)

        Dim StartDate As Date
        Dim EndDate As Date

        Dim SwMFGLT As Integer
        SwMFGLT = CallClass.ReturnInfoWithParString("cspReturnMFGLeadTime", "MFGLEADTIME")
        If SwMFGLT > 0 Then
            StartDate = CDate(dgMpo("StartProdDate", RowMpo).Value).ToShortDateString
            EndDate = DateAdd(DateInterval.Day, SwMFGLT * 7, StartDate).ToShortDateString
        Else
            'MFG Lead Time = 16 WKS * 7 = 112
            StartDate = CDate(dgMpo("StartProdDate", RowMpo).Value).ToShortDateString
            EndDate = DateAdd(DateInterval.Day, 112, StartDate).ToShortDateString
        End If

        dgMpo("EndProdDate", RowMpo).Value = EndDate
        Dim paraEnd As SqlParameter = New SqlParameter("@EndProdDate", SqlDbType.SmallDateTime, 4)
        paraEnd.Value = EndDate
        mySqlComm.Parameters.Add(paraEnd)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Start Production Date: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMPOPromDate()

        'If IsDBNull(dgMpo("MpoPromDate", RowMpo).Value) = True Then
        'Exit Sub
        'End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoPromDate", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraStart As SqlParameter = New SqlParameter("@MpoPromDate", SqlDbType.SmallDateTime, 4)
        paraStart.Value = dgMpo("MpoPromDate", RowMpo).Value
        mySqlComm.Parameters.Add(paraStart)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 2000)
        If Len(Trim(txtTechNotes.Text)) = 0 Then
            txtTechNotes.Text = "New MPO promised date: " + dgMpo("MpoPromDate", RowMpo).Value + " on " + Now.ToShortDateString
        Else
            txtTechNotes.Text = txtTechNotes.Text + vbCrLf + "New MPO promised date: " + dgMpo("MpoPromDate", RowMpo).Value + " on " + Now.ToShortDateString.ToString
        End If
        paraNotes.Value = txtTechNotes.Text
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Promised Date: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoNewOrder()

        If IsDBNull(dgMpo("ChNewOrder", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoNewOrder", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNewOrd As SqlParameter = New SqlParameter("@ChNewOrder", SqlDbType.Bit, 1)
        paraNewOrd.Value = dgMpo("ChNewOrder", RowMpo).Value
        mySqlComm.Parameters.Add(paraNewOrd)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!! ERROR !!! Update Mpo New Order: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoWFM()

        If IsDBNull(dgMpo("ChWFM", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoWFM", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFM As SqlParameter = New SqlParameter("@ChWFM", SqlDbType.Bit, 1)
        paraWFM.Value = dgMpo("ChWFM", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo WFM: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoWFT()

        If IsDBNull(dgMpo("ChWFT", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoWFT", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFT As SqlParameter = New SqlParameter("@ChWFT", SqlDbType.Bit, 1)
        paraWFT.Value = dgMpo("ChWFT", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFT)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo WFT: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoCustAppr()

        If IsDBNull(dgMpo("WKMpoCustAppr", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoCustAppr", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFT As SqlParameter = New SqlParameter("@WKMpoCustAppr", SqlDbType.Bit, 1)
        paraWFT.Value = dgMpo("WKMpoCustAppr", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFT)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Cust. Appr: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoSourceInsp()

        If IsDBNull(dgMpo("WKMpoSourceInsp", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoWKSourceInsp", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFT As SqlParameter = New SqlParameter("@WKMpoSourceInsp", SqlDbType.Bit, 1)
        paraWFT.Value = dgMpo("WKMpoSourceInsp", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFT)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Source Insp: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


    Sub UpdateMpoWKMpoFAI()

        If IsDBNull(dgMpo("WKMpoFAI", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoWKMpoFAI", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFT As SqlParameter = New SqlParameter("@WKMpoFAI", SqlDbType.Bit, 1)
        paraWFT.Value = dgMpo("WKMpoFAI", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFT)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo FAI: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoWKMpoDVI()

        If IsDBNull(dgMpo("WKMpoDVI", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoWKMpoDVI", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraWFT As SqlParameter = New SqlParameter("@WKMpoDVI", SqlDbType.Bit, 1)
        paraWFT.Value = dgMpo("WKMpoDVI", RowMpo).Value
        mySqlComm.Parameters.Add(paraWFT)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo DVI: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


    Private Sub dgDeliv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellClick
        Dim qty As Double = 0.0

        qty = 0.0
        For Each Row As DataGridViewRow In dgPslip.Rows
            qty = qty + Nz.Nz(Row.Cells("PslipQty").Value)
        Next
        txtShipQty.Text = qty.ToString("N0")
    End Sub

    Private Sub dgDeliv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDeliv.DataError
        REM end
    End Sub

    Private Sub dgRoute_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        REM end
    End Sub

    Private Sub txtCustOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustOrder.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            strSearch = txtCustOrder.Text

            'dsMain.Clear()
            'If cn.State = ConnectionState.Open Then
            '    cn.Close()
            'End If

            If RdAll.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustOrder", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdActive.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustOrderActive", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdClosed.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustOrderClosed", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdCancelled.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustOrderCancelled", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If
    End Sub

    Private Sub txtPSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSlip.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            strSearch = txtPSlip.Text

            Me.Cursor = Cursors.WaitCursor

            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlPSlipInv", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default

        End If
    End Sub


    Private Sub txtLotNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            strSearch = txtLotNo.Text

            Me.Cursor = Cursors.WaitCursor

            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMatlLotNo", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub txtMpoNotes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMpoNotes.GotFocus

        If dgMpo.Rows.Count - 1 >= 0 Then
            If dgMpo("MpoStatus", RowMpo).Value = "Closed" Or dgMpo("MpoStatus", RowMpo).Value = "Cancelled" Or dgMpo("MpoStatus", RowMpo).Value = "Scrapped" Then
                If RoleQA(wkDeptCode) = False Then
                    dgMpo.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtMpoNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMpoNotes.Validating
        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.Rows.Count - 1 >= 0 Then
            dgMpo("MpoNotes", RowMpo).Value = Trim(txtMpoNotes.Text)
            UpdateMpoNotes()
        End If

    End Sub

    Private Sub txtTechNotes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTechNotes.GotFocus
        If dgMpo.Rows.Count - 1 >= 0 Then
            If dgMpo("MpoStatus", RowMpo).Value = "Closed" Or dgMpo("MpoStatus", RowMpo).Value = "Cancelled" Or dgMpo("MpoStatus", RowMpo).Value = "Scrapped" Then
                If RoleQA(wkDeptCode) = False Then
                    dgMpo.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtTechNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTechNotes.Validating
        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.Rows.Count - 1 >= 0 Then
            dgMpo("MpoTechNotes", RowMpo).Value = Trim(txtTechNotes.Text)
            UpdateMpoTechNotes()
        End If

    End Sub

    Sub CalculActRelOrd()

        If RowMpo < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMpo.Rows
            If IsDBNull(Row.Cells("QtyActual").Value) = False Then
                If Nz.Nz(Row.Cells("QtyActual").Value) > 0 Then
                    Row.Cells("QtyScrapped").Value = Nz.Nz(Row.Cells("QtyEngReleased").Value) - Nz.Nz(Row.Cells("QtyActual").Value)
                End If
            End If
        Next

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
            qty = qty + Nz.Nz(Row.Cells("QtyOrder").Value)
        Next
        txtOrd.Text = qty.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("MpoValue").Value)
        Next
        txtValue.Text = qty.ToString("C2")

        '  dgDeliv
        qty = 0.0
        For Each Row As DataGridViewRow In dgDeliv.Rows
            qty = qty + Nz.Nz(Row.Cells("DelivQty").Value)
        Next
        txtDelivQty.Text = qty.ToString("N0")

        'dgPslip
        qty = 0.0
        For Each Row As DataGridViewRow In dgPslip.Rows
            qty = qty + Nz.Nz(Row.Cells("PslipQty").Value)
        Next
        txtShipQty.Text = qty.ToString("N0")

        '========================================
        Dim DelDate As Date
        Dim NowDate As Date

        For Each Row As DataGridViewRow In dgMpo.Rows
            If IsDBNull(Row.Cells("MpoDeliveryDate").Value) = False Then
                DelDate = CDate(Row.Cells("MpoDeliveryDate").Value).ToShortDateString
                NowDate = CDate(Now.ToShortDateString)

                Row.Cells("DiffDays").Value = DateDiff(DateInterval.Day, NowDate, DelDate)
            End If
        Next

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

        Select Case e.ColumnIndex           'only planing
            Case 0 To 6
                dgPslip.Columns(e.ColumnIndex).ReadOnly = True
        End Select
    End Sub

    Private Sub dgPslip_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPslip.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPslip = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 7  'WayBill No
                UpdateWaiBillNo()
        End Select
    End Sub

    Private Sub dgPslip_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPslip.DataError
        REM end
    End Sub

    Sub UpdateWaiBillNo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoPslipWayBill", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPslipNo As SqlParameter = New SqlParameter("@PslipNo", SqlDbType.NVarChar, 15)
        paraPslipNo.Value = dgPslip("PslipNo", RowPslip).Value
        mySqlComm.Parameters.Add(paraPslipNo)

        If IsDBNull(dgPslip("PslipTrackingNo", RowPslip).Value) = True Then
            dgPslip("PslipTrackingNo", RowPslip).Value = ""
        End If
        Dim paraWayBill As SqlParameter = New SqlParameter("@PslipTrackingNo", SqlDbType.NVarChar, 100)
        paraWayBill.Value = dgPslip("PslipTrackingNo", RowPslip).Value
        mySqlComm.Parameters.Add(paraWayBill)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox("Update PSlip WayBill Number: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub CalculPodetail()

        Dim MpoVal As Double = 0.0

        For Each Row As DataGridViewRow In dgPODetail.Rows
            MpoVal = Nz.Nz(Row.Cells("POQty").Value) * ((Nz.Nz(Row.Cells("POPrice").Value)) - (Nz.Nz(Row.Cells("POPrice").Value) * Nz.Nz(Row.Cells("POItemEscompte").Value)) / 100)
            Row.Cells("TotalDetVal").Value = MpoVal
        Next

    End Sub

    Sub PutDetailTotal()


        Dim tqty As Integer = 0
        Dim tvalue As Single = 0.0

        If RowPoDet >= 0 And RowPoDet < dgPODetail.Rows.Count Then
            tqty = CDec(Nz.Nz(dgPODetail("POQty", RowPoDet).Value))

            tvalue = CDec(Nz.Nz(dgPODetail("TotalDetVal", RowPoDet).Value))

            txtTotalPOQty.Text = tqty.ToString("N2")
            txtTotalPOValue.Text = tvalue.ToString("C2")
        End If


    End Sub

    Private Sub dgPODetail_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPODetail.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPoDet = e.RowIndex

        CalculPodetail()

        PutDetailTotal()

        PutTotalRecv()

    End Sub

    Private Sub dgPODetail_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPODetail.DataError
        REM end
    End Sub

    Sub PutTotalRecv()

        If IsDBNull(txtMpo.Text) = True Or _
            Len(Trim(txtMpo.Text)) = 0 = True Then
            Exit Sub
        End If

        txtTotalRecvQty.Text = ""
        txtTotalAccpQty.Text = ""
        txtRecvVal.Text = ""
        txtAccVal.Text = ""

        Dim tqty As Integer
        Dim tqty1 As Integer

        Dim trecVal As Single
        Dim tAccVal As Single
        tqty = 0
        tqty1 = 0
        trecVal = 0
        tAccVal = 0

        If dgPoRecv.Rows.Count > 0 Then
            Dim I As Integer
            For I = 0 To dgPoRecv.Rows.Count - 1
                dgPoRecv("TotRecValue", I).Value = Nz.Nz(dgPoRecv("PSlipQty", I).Value) * ((Nz.Nz(dgPoRecv("PslipPrice", I).Value)) - (Nz.Nz(dgPoRecv("PslipPrice", I).Value) * Nz.Nz(dgPoRecv("PslipDiscount", I).Value)) / 100)
                dgPoRecv("TotAccValue", I).Value = Nz.Nz(dgPoRecv("RecQtyAccp", I).Value) * ((Nz.Nz(dgPoRecv("PslipPrice", I).Value)) - (Nz.Nz(dgPoRecv("PslipPrice", I).Value) * Nz.Nz(dgPoRecv("PslipDiscount", I).Value)) / 100)

                tqty = tqty + CDec(Nz.Nz(Me.dgPoRecv("PslipQty", I).Value))
                tqty1 = tqty1 + CDec(Nz.Nz(Me.dgPoRecv("RecQtyAccp", I).Value))

                trecVal = trecVal + CDec(dgPoRecv("TotRecValue", I).Value)
                tAccVal = tAccVal + CDec(dgPoRecv("TotAccValue", I).Value)
            Next
            txtTotalRecvQty.Text = tqty.ToString("N2")
            txtTotalAccpQty.Text = tqty1.ToString("N2")
            txtRecvVal.Text = trecVal.ToString("C2")
            txtAccVal.Text = tAccVal.ToString("C2")
        End If

        For Each Row As DataGridViewRow In dgPoRecv.Rows
            Row.Cells("PSlipQty").Style.BackColor = Color.LightBlue
            Row.Cells("RecQtyAccp").Style.BackColor = Color.LightBlue
        Next

    End Sub

    Private Sub dgPoRecv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPoRecv.DataError
        REM end
    End Sub

    Private Sub dgPODetail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPODetail.GotFocus
        For Each Row As DataGridViewRow In dgPODetail.Rows
            Row.Cells("POQty").Style.BackColor = Color.LightBlue
        Next
    End Sub

    Private Sub dgMpo_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMpo.Sorted
        PutErrorMessage()
    End Sub

    Sub CheckEndUser()

        Dim SwMPOId As Integer = 0

        SwMPOId = Nz.Nz(dgMpo.Rows(RowMpo).Cells("MpoID").Value)
        If SwMPOId = 0 Then
            Exit Sub
        Else
            SwEndUser = CallClass.ReturnStrWithParInt("cspReturnMpoEndUserClient", SwMPOId)
            If SwEndUser = "False" Then
                MsgBox("!!! Warning !!! Missing DWG Source information in Part Master Table.")
                SwEndUser = "N/A End User"
            Else
                SwEndUser = SwEndUser + "  End User"
            End If
        End If

    End Sub

    Private Sub CmdPrintPo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintPo.Click

        If RowPoDet < 0 Then
            Exit Sub
        End If

        If dgPODetail.RowCount > 0 Then
            Dim FindPO As String

            SwEndUser = ""

            Call CheckEndUser()
            FindPO = dgPODetail("PoNo", RowPoDet).Value

            Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Try
                Dim rptPO As New rptPOSupp()
                rptPO.Load("..\rptposupp.rpt")
                pdFind.Value = FindPO
                pdEndUser.Value = SwEndUser

                pvFindCollection.Add(pdFind)
                pvEndUserCollection.Add(pdEndUser)

                rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvFindCollection)
                rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pvEndUserCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True

                frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = False
                frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = False

                frmPOMasterPrint.ShowDialog()
            Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                MsgBox("Incorrect path for loading report.", _
                        MsgBoxStyle.Critical, "Load Report Error")

            Catch Exp As Exception
                MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        Else
            MsgBox("Nothing to PreView.")
        End If

    End Sub

    Private Sub CmdPSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPSlip.Click

        Dim txtPslipNo As String

        If dgPslip.RowCount <= 0 Then
            MsgBox("Nothing to PreView.")
            Exit Sub
        End If

        If IsDBNull(Nz.Nz(dgPslip("PslipNo", RowPslip).Value)) = True Or _
        IsNothing(Nz.Nz(dgPslip("PslipNo", RowPslip).Value)) = True Then
            MsgBox("Nothing to PreView.")
        Else

            txtPslipNo = dgPslip("PslipNo", RowPslip).Value
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptLisiPslipCOC()

            rptPO.Load("..\rptLisiPSlipCOC.rpt")
            pdvPslipNo.Value = txtPslipNo
            pvCollection.Add(pdvPslipNo)

            rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = False
            frmPOMasterPrint.ShowDialog()
        End If

    End Sub

    Private Sub CmdInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdInv.Click

        Dim txtPslipNo As String

        If dgPslip.RowCount <= 0 Then
            MsgBox("Nothing to PreView.")
            Exit Sub
        End If

        If IsDBNull(dgPslip("PslipNo", RowPslip).Value) = True Then
            MsgBox("Nothing to PreView.")
            Exit Sub
            If IsNothing(dgPslip("PslipNo", RowPslip).Value) = True Then
                MsgBox("Nothing to PreView.")
                Exit Sub
            End If
        End If

        txtPslipNo = dgPslip("PslipNo", RowPslip).Value

        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPslipNo As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptLisiInvoice()

        rptPO.Load("..\rptLisiInvoice.rpt")
        pdvPslipNo.Value = txtPslipNo
        pvCollection.Add(pdvPslipNo)

        rptPO.DataDefinition.ParameterFields("@txtPslipNo").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = False
        frmPOMasterPrint.ShowDialog()

    End Sub

    Private Sub RdActive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdActive.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub RdAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdAll.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub RdCancelled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCancelled.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub RdClosed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdClosed.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub CmdMatlCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMatlCert.Click

        'Try
        '    Dim SwPath As String = ""
        '    SwPath = CallClass.ReturnInfoWithParString("cspReturnMatlCertPath", txtLotNo.Text)
        '    If SwPath <> "False" Then
        '        Process.Start(SwPath)
        '    Else
        '        MsgBox("Nothing to View.")
        '    End If
        'Catch ex As Exception
        '    MsgBox("!!! ERROR !!! Access Material Mill Cert." & ex.Message)
        'Finally
        '    cn.Close()
        'End Try

        Dim pattern As String = ""
        Dim SwPath As String = ""
        'Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Inspection\Raw Material\Raw Material Cert")

        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Lisi Raw Material Mill Certs\Raw Material Cert")

        If Len(txtLotNo.Text) = 0 Then
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        Select Case Len(txtLotNo.Text)
            Case 2
                pattern = "M-00" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
            Case 3
                pattern = "M-0" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
            Case Else
                pattern = "M-" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
        End Select

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                ' Create an instance
                Dim proc As New System.Diagnostics.Process()

                ' Fill-up StartInfo
                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If

            Exit Sub

        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        Select Case Len(txtLotNo.Text)
            Case 2
                pattern = "M00" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
            Case 3
                pattern = "M0" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
            Case Else
                pattern = "M" + Microsoft.VisualBasic.Right(txtLotNo.Text, Len(txtLotNo.Text) - 1) + ".PDF"
        End Select

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                ' Create an instance


                ' Fill-up StartInfo
                Dim proc As New System.Diagnostics.Process()

                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If
        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If

    End Sub

    Private Sub CmdMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMethod.Click
        Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptMFGMethodBarCodeRefOnly
        rptPO.Load("..\rptMFGMethodBarCodeRefOnly.rpt")

        pdvMpoID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MPOID").Value)
        pdvPartID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MpoPartID").Value)
        pvMPOIDCollection.Add(pdvMpoID)
        pvPartIDCollection.Add(pdvPartID)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

        rptPO.Close()
        rptPO.Dispose()

    End Sub

    Private Sub TabPage5_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Enter

        Me.Cursor = Cursors.WaitCursor

        CalculPodetail()

        PutDetailTotal()

        PutTotalRecv()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TabPage4_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Enter

        Me.Cursor = Cursors.WaitCursor

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblMpoRoutingBarCode").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlBarCode", strSearch).Fill(dsMain, "tblMpoRoutingBarCode")

            dgBar.AutoGenerateColumns = False
            dgBar.DataSource = dsMain
            dgBar.DataMember = "tblMpoRoutingBarCode"

            dgBar.ReadOnly = True
        End If

        CalculDiffTimeBarCode()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMat.Click
        frmEngMatlType.ShowDialog()
    End Sub

    Private Sub TabPage6_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Enter

        Me.Cursor = Cursors.WaitCursor

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblStockRawMatlReservation").Clear()

            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMatlReservation", strSearch).Fill(dsMain, "tblStockRawMatlReservation")

            dgStockRes.AutoGenerateColumns = False
            dgStockRes.DataSource = dsMain
            dgStockRes.DataMember = "tblStockRawMatlReservation"

            dgStockRes.ReadOnly = True
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TabPage7_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoPartID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblPartMatlPref").Clear()

            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMatlPreferred", strSearch).Fill(dsMain, "tblPartMatlPref")

            dgMat.AutoGenerateColumns = False
            dgMat.DataSource = dsMain
            dgMat.DataMember = "tblPartMatlPref"

            dgMat.ReadOnly = True
        End If


        'Blanks
        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblTempBlank").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlPrefMatlFromBlanks", strSearch).Fill(dsMain, "tblTempBlank")
            dgMatFromBlanks.AutoGenerateColumns = False
            dgMatFromBlanks.DataSource = dsMain
            dgMatFromBlanks.DataMember = "tblTempBlank"
            dgMatFromBlanks.Refresh()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgStockRes_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockRes.CellEnter
        txtLotNo.Text = dgStockRes("StLotNo", e.RowIndex).Value
    End Sub

    Private Sub dgBar_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBar.CellEnter
        CalculDiffTimeBarCode()
    End Sub

    Private Sub dgBar_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgBar.DataError
        REM end
    End Sub


    Private Sub CmdCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCost.Click
        Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptMPOOperationsCost
        rptPO.Load("..\rptMPOOperationsCost.rpt")

        pdvMpoID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MPOID").Value)
        pvMPOIDCollection.Add(pdvMpoID)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()
    End Sub

    Private Sub CmdMpoCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMpoCost.Click
        Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptMPOCost
        rptPO.Load("..\rptMpoCost.rpt")

        pdvMpoID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MPOID").Value)
        pvMPOIDCollection.Add(pdvMpoID)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.Show()
    End Sub

    Private Sub CmbMpoType_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpoType.DropDownClosed

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0

        Dim strSearch As String
        strSearch = CmbMpoType.SelectedItem
        If Len(Trim(strSearch)) <= 0 Then
            Exit Sub
        End If
        'strSearch = CmbMpoType.SelectedText
        'strSearch = CmbMpoType.SelectedValue
        'strSearch = CmbMpoType.Text

        If RdAll.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlTypeMPO", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            txtMpo.Focus()
            dgMpo.Focus()
            Exit Sub
        End If

        If RdActive.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlTypeMpoActive", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            txtMpo.Focus()
            dgMpo.Focus()
            Exit Sub
        End If

        If RdClosed.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlTypeMpoClosed", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            txtMpo.Focus()
            dgMpo.Focus()
            Exit Sub
        End If

        If RdCancelled.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlTypeMpoCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

            ContinueAfterSrc()
            Me.Cursor = Cursors.Default
            txtMpo.Focus()
            dgMpo.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
        GC.Collect()
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        'With dsMain
        '    .Relations.Add("DelivPslip", _
        '       .Tables("tblCustOrderItemDeliv").Columns("OrdDelivID"), _
        '        .Tables("tblLisiPslip ").Columns("OrdDelivID"), True)
        'End With

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)     'search for all delivery active for the same PartID
        If strSearch > 0 Then
            dsMain.Tables("tblSelectItemDeliv").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlItemsDelivLinkPartID", strSearch).Fill(dsMain, "tblSelectItemDeliv")
            dgDeliv.AutoGenerateColumns = False
            dgDeliv.DataSource = dsMain
            dgDeliv.DataMember = "tblSelectItemDeliv"
            dgDeliv.ReadOnly = True
        Else
            Exit Sub
        End If


        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblLisiPslip").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlInvLinkMPO", strSearch).Fill(dsMain, "tblLisiPslip")
            dgInv.AutoGenerateColumns = False
            dgInv.DataSource = dsMain
            dgInv.DataMember = "tblLisiPslip"
            dgInv.ReadOnly = True
        End If


        Dim qty As Double = 0.0

        qty = 0.0
        For Each Row As DataGridViewRow In dgInv.Rows
            qty = qty + Nz.Nz(Row.Cells("PslipQty").Value)
        Next
        txtInvQty.Text = qty.ToString("N0")

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub TabPage8_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Enter
        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            ' check 800 operation
            dsMain.Tables("tblMpoTraveler").Clear()
            CallClass.PopulateAdapterAfterSearchInt("cspUpdateShopFloorControl800Oper", strSearch).Fill(dsMain, "tblMpoTraveler")

            ' call traveler and display the grid
            dsMain.Tables("tblMpoTraveler").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMBOCheck", strSearch).Fill(dsMain, "tblMpoTraveler")

            dgMBO.AutoGenerateColumns = False
            dgMBO.DataSource = dsMain
            dgMBO.DataMember = "tblMpoTraveler"

            Dim MpoVal As Double = 0.0

            For Each Row As DataGridViewRow In dgMBO.Rows
                MpoVal = MpoVal + Nz.Nz(Row.Cells("TrMachCost").Value)
            Next
            txtMPOMachCost.Text = MpoVal.ToString("C3")
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgMBO_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMBO.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMBOCh = e.RowIndex
        End If

        If dgMpo("MpoStatus", RowMpo).Value <> "Active" Then
            MsgBox("Access Denied.")
            e.Cancel = True
            Exit Sub
        End If

        If RoleMBOCheck(wkDeptCode) = True Then
            Select Case e.ColumnIndex
                Case 0, 7, 8, 9, 10, 11, 12, 13, 14
                    e.Cancel = True
                Case 4, 5, 6
                    If dgMBO("TrOperNo", RowMBOCh).Value <> 800 Then
                        MsgBox("Access Denied.")
                        e.Cancel = True
                    End If
                Case 2
                    If dgMBO("TrOperNo", RowMBOCh).Value = 800 Then
                        MsgBox("Access Denied.")
                        e.Cancel = True
                    End If

                    If IsDBNull(dgMBO("TrMBOCheck", RowMBOCh).Value) = True Or _
                        Nz.Nz(dgMBO("TrMBOCheck", RowMBOCh).Value) = 0 Then
                        MsgBox("Access Denied. Please Check Before (MBO Calculation Field)")
                        e.Cancel = True
                    End If

            End Select
        Else
            dgMBO.ReadOnly = True
        End If

    End Sub

    Private Sub dgMBO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMBO.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowMBOCh = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 1
                UpdateMBOCheck()
                If Nz.Nz(dgMBO("TrMBOCheck", RowMBOCh).Value) = 0 Then
                    dgMBO("TrMBOSendCell", RowMBOCh).Value = 0
                    UpdateMBOSendCell()
                End If
            Case 2
                UpdateMBOSendCell()
            Case 4
                UpdateOkumaCheck()
            Case 5
                UpdateRomiCheck()
            Case 6
                UpdateMarkingCheck()
        End Select

    End Sub

    Private Sub dgMBO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMBO.DataError
        REM end
    End Sub

    Sub UpdateMBOCheck()

        If IsDBNull(dgMBO("TrMBOCheck", RowMBOCh).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMBOCheck", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgMBO("TrMpoID", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgMBO("TrOperNo", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraWFM As SqlParameter = New SqlParameter("@TrMBOCheck", SqlDbType.Bit, 1)
        paraWFM.Value = dgMBO("TrMBOCheck", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MBO Check: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMBOSendCell()

        If IsDBNull(dgMBO("TrMBOSendCell", RowMBOCh).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMBOSendCell", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgMBO("TrMpoID", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgMBO("TrOperNo", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraWFM As SqlParameter = New SqlParameter("@TrMBOSendCell", SqlDbType.Bit, 1)
        paraWFM.Value = dgMBO("TrMBOSendCell", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MBO Send Cell: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateOkumaCheck()

        If IsDBNull(dgMBO("TrQtyOKuma", RowMBOCh).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMBOOKuma", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgMBO("TrMpoID", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgMBO("TrOperNo", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraWFM As SqlParameter = New SqlParameter("@TrQtyOKuma", SqlDbType.Bit, 1)
        paraWFM.Value = dgMBO("TrQtyOKuma", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MBO Okuma: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateRomiCheck()

        If IsDBNull(dgMBO("TrQtyRomi", RowMBOCh).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMBORomi", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgMBO("TrMpoID", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgMBO("TrOperNo", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraWFM As SqlParameter = New SqlParameter("@TrQtyRomi", SqlDbType.Bit, 1)
        paraWFM.Value = dgMBO("TrQtyRomi", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MBO Romi: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMarkingCheck()

        If IsDBNull(dgMBO("TrQtyMarking", RowMBOCh).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMBOMarking", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgMBO("TrMpoID", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgMBO("TrOperNo", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraWFM As SqlParameter = New SqlParameter("@TrQtyMarking", SqlDbType.Bit, 1)
        paraWFM.Value = dgMBO("TrQtyMarking", RowMBOCh).Value
        mySqlComm.Parameters.Add(paraWFM)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MBO Marking: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub dgMBO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMBO.Enter
        Dim DiffTime As Integer = 0
        Dim TDays As Integer = 0
        Dim THr As Integer = 0

        Dim DateStart As Date
        Dim DateEnd As Date

        For Each Row As DataGridViewRow In dgMBO.Rows
            If IsDBNull(Row.Cells("OperStart").Value) = True Then
                Row.Cells("MBOFinalTime").Value = ""
                GoTo NextOper
            Else
                DateStart = Row.Cells("OperStart").Value
            End If

            If IsDBNull(Row.Cells("OperEnd").Value) = True Then
                Row.Cells("MBOFinalTime").Value = ""
                GoTo NextOper
            Else
                DateEnd = Row.Cells("OperEnd").Value
            End If

            DiffTime = DateDiff(DateInterval.Minute, DateStart, DateEnd)
            'Row.Cells("MBOFinalTime").Value = DiffTime.ToString

            TDays = DateDiff(DateInterval.Day, DateStart, DateEnd)
            THr = DateDiff(DateInterval.Hour, DateStart, DateEnd)

            Row.Cells("MBOFinalTime").Value = IIf(TDays = 0, "", TDays.ToString + "Day ") + _
                    IIf(THr = 0, "", (THr - (TDays * 24)).ToString + " Hr ") _
                    + (DiffTime - (THr * 60)).ToString + " Min"
NextOper:
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If dgMpo.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

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
            'Dim iY As Integer
            Dim iC As Integer

            For iC = 0 To dgMpo.Columns.Count - 20

                wsheet.Cells(1, 1).Value = dgMpo.Columns(37).HeaderText    ' Customer

                wsheet.Cells(1, 2).Value = dgMpo.Columns(2).HeaderText      ' MPO Priority
                wsheet.Cells(1, 3).Value = dgMpo.Columns(3).HeaderText      ' MPO Clasification
                wsheet.Cells(1, 4).Value = dgMpo.Columns(4).HeaderText      ' MPO Number
                wsheet.Cells(1, 5).Value = dgMpo.Columns(5).HeaderText      ' MPO Status
                wsheet.Cells(1, 6).Value = dgMpo.Columns(6).HeaderText      ' MPO Delivery
                wsheet.Cells(1, 7).Value = dgMpo.Columns(8).HeaderText      ' MPO Promised Date
                wsheet.Cells(1, 8).Value = dgMpo.Columns(7).HeaderText      ' No Days until Delivery
                wsheet.Cells(1, 9).Value = dgMpo.Columns(9).HeaderText      ' Start Production Date
                wsheet.Cells(1, 10).Value = dgMpo.Columns(10).HeaderText     ' End Production Date
                wsheet.Cells(1, 11).Value = dgMpo.Columns(11).HeaderText    ' Part Number

                wsheet.Cells(1, 12).Value = dgMpo.Columns(30).HeaderText    ' Part Number Rev

                wsheet.Cells(1, 13).Value = dgMpo.Columns(12).HeaderText    ' Actual Qty
                wsheet.Cells(1, 14).Value = dgMpo.Columns(13).HeaderText    ' Released Qty
                wsheet.Cells(1, 15).Value = dgMpo.Columns(14).HeaderText    ' Sales Qty
                wsheet.Cells(1, 16).Value = dgMpo.Columns(15).HeaderText    ' Scrapped Qty
                wsheet.Cells(1, 17).Value = dgMpo.Columns(16).HeaderText    ' Dept
                wsheet.Cells(1, 18).Value = dgMpo.Columns(24).HeaderText    ' Matl Lot
                wsheet.Cells(1, 19).Value = dgMpo.Columns(25).HeaderText    ' Matl Weight
                wsheet.Cells(1, 20).Value = dgMpo.Columns(26).HeaderText    ' Matl Adj
                wsheet.Cells(1, 21).Value = dgMpo.Columns(27).HeaderText    ' Price
                wsheet.Cells(1, 22).Value = dgMpo.Columns(28).HeaderText    ' Value
                wsheet.Cells(1, 23).Value = dgMpo.Columns(29).HeaderText    ' MPO Date

                wsheet.Cells(1, 24).Value = dgMpo.Columns(39).HeaderText    ' MPO Closed Date
                wsheet.Cells(1, 25).Value = dgMpo.Columns(40).HeaderText    ' Description Code
                wsheet.Cells(1, 26).Value = dgMpo.Columns(48).HeaderText    ' # Days in Prod

                wsheet.Cells(1, 27).Value = dgMpo.Columns(32).HeaderText    ' MPO Prod Notes
                wsheet.Cells(1, 28).Value = dgMpo.Columns(33).HeaderText    ' MPO Notes

            Next


            wsheet.Rows(2).select()

            For iX = 0 To dgMpo.Rows.Count - 1
                '    For iY = 0 To dgMpo.Columns.Count - 20
                '        wsheet.Cells(iX + 2, iY + 1).value = dgMpo(iY, iX).Value
                '    Next


                wsheet.Cells(iX + 2, 1).value = dgMpo(37, iX).Value

                wsheet.Cells(iX + 2, 2).value = dgMpo(2, iX).Value
                wsheet.Cells(iX + 2, 3).value = dgMpo(3, iX).Value
                wsheet.Cells(iX + 2, 4).value = dgMpo(4, iX).Value
                wsheet.Cells(iX + 2, 5).value = dgMpo(5, iX).Value
                wsheet.Cells(iX + 2, 6).value = dgMpo(6, iX).Value
                wsheet.Cells(iX + 2, 7).value = dgMpo(8, iX).Value
                wsheet.Cells(iX + 2, 8).value = dgMpo(7, iX).Value
                wsheet.Cells(iX + 2, 9).value = dgMpo(9, iX).Value
                wsheet.Cells(iX + 2, 10).value = dgMpo(10, iX).Value
                wsheet.Cells(iX + 2, 11).value = dgMpo(11, iX).Value

                wsheet.Cells(iX + 2, 12).value = dgMpo(30, iX).Value

                wsheet.Cells(iX + 2, 13).value = Nz.Nz(dgMpo(12, iX).Value)
                wsheet.Cells(iX + 2, 14).value = Nz.Nz(dgMpo(13, iX).Value)
                wsheet.Cells(iX + 2, 15).value = Nz.Nz(dgMpo(14, iX).Value)
                wsheet.Cells(iX + 2, 16).value = Nz.Nz(dgMpo(15, iX).Value)


                'cmbDept.SelectedItem = dgMpo(16, iX).Value
                'cmbDept.SelectedIndex = dgMpo(16, iX).Value

                cmbDept.SelectedValue = dgMpo(16, iX).Value
                wsheet.Cells(iX + 2, 17).value = cmbDept.Text

                wsheet.Cells(iX + 2, 18).value = dgMpo(24, iX).Value
                wsheet.Cells(iX + 2, 19).value = Nz.Nz(dgMpo(25, iX).Value).ToString
                wsheet.Cells(iX + 2, 20).value = Nz.Nz(dgMpo(26, iX).Value).ToString
                wsheet.Cells(iX + 2, 21).value = CStr(CDbl(Nz.Nz(dgMpo(27, iX).Value)).ToString("C2"))
                wsheet.Cells(iX + 2, 22).value = CStr(CDbl(Nz.Nz(dgMpo(28, iX).Value)).ToString("C2"))
                wsheet.Cells(iX + 2, 23).value = dgMpo(29, iX).Value
                wsheet.Cells(iX + 2, 24).value = dgMpo(39, iX).Value
                wsheet.Cells(iX + 2, 25).value = dgMpo(40, iX).Value
                wsheet.Cells(iX + 2, 26).value = dgMpo(48, iX).Value

                wsheet.Cells(iX + 2, 27).value = dgMpo(32, iX).Value
                wsheet.Cells(iX + 2, 28).value = dgMpo(33, iX).Value

            Next

            wapp.Visible = True
            wapp.UserControl = True

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

    End Sub


    Private Sub TabPage9_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage9.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblMpoMasterHistoryTranz").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMpoActualQtyHistory", strSearch).Fill(dsMain, "tblMpoMasterHistoryTranz")

            dgActualQty.AutoGenerateColumns = False
            dgActualQty.DataSource = dsMain
            dgActualQty.DataMember = "tblMpoMasterHistoryTranz"

            'Dim MpoVal As Double = 0.0

            'For Each Row As DataGridViewRow In dgMBO.Rows
            '    MpoVal = MpoVal + Nz.Nz(Row.Cells("TrMachCost").Value)
            'Next
            'txtMPOMachCost.Text = MpoVal.ToString("C3")
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TabPage10_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage10.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        If dgMpo("MpoTypeClass", RowMpo).Value <> "Assembly" Then
            MsgBox("This function is active only for Assembly MPOs.")
        End If

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblPartAssyComponents").Clear()

            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMpoAssemblyComp", strSearch).Fill(dsMain, "tblPartAssyComponents")
            dgAssy.AutoGenerateColumns = False
            dgAssy.DataSource = dsMain
            dgAssy.DataMember = "tblPartAssyComponents"

            'Use MPOPartId Assembly and GO in Part Master to identify the components and then check wip and FP
            dsMain.Tables("tblTemp").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMpoAssemblyCompDetail", strSearch).Fill(dsMain, "tblTemp")
            dgAssyDetail.AutoGenerateColumns = False
            dgAssyDetail.DataSource = dsMain
            dgAssyDetail.DataMember = "tblTemp"

            dgAssy.Refresh()
            PutColor()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgAssy_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssy.CellClick
        PutColor()
    End Sub

    Private Sub dgAssy_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssy.CellEnter
        If e.RowIndex < 0 Then
            Return
        Else
            RowAssy = e.RowIndex
        End If

        PutColor()
    End Sub

    Private Sub dgAssy_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgAssy.DataError
        REM end
    End Sub

    Sub PutColor()
        For Each Row As DataGridViewRow In dgAssyDetail.Rows
            If dgAssy.Item("PartNumberAssy", RowAssy).Value = Row.Cells("PartNoDet").Value Then
                If RowAssy = 0 Then
                    'Row.Cells("PartNoDet").Selected = True
                    Row.Cells("PartNoDet").Style.BackColor = Color.LightGray
                Else
                    Row.Cells("PartNoDet").Style.BackColor = Color.LightSkyBlue
                End If
            End If

            If Nz.Nz(Row.Cells("FinalStDet").Value) = 0 Then
                Row.Cells("FinalStDet").Value = DBNull.Value
            End If

            If Nz.Nz(Row.Cells("DeptNodeDet").Value) = "FP/SFP" Then
                Row.Cells("QtyActualDet").Value = DBNull.Value
            End If

        Next

    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call Shell("net send" & " studor" & " Hello")
    'End Sub

    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblTempBlank").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMpoBlankToPN", strSearch).Fill(dsMain, "tblTempBlank")
            dgBlanks.AutoGenerateColumns = False
            dgBlanks.DataSource = dsMain
            dgBlanks.DataMember = "tblTempBlank"
            dgBlanks.Refresh()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TabPage11_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage11.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblTempMemo").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlMEMObyPartNo", strSearch).Fill(dsMain, "tblTempMemo")
            dgMEMO.AutoGenerateColumns = False
            dgMEMO.DataSource = dsMain
            dgMEMO.DataMember = "tblTempMemo"
            dgMEMO.Refresh()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgMEMO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMEMO.CellClick

        If e.ColumnIndex = 1 Then
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptLisiMemo()
            rptPO.ReportOptions.EnableSaveDataWithReport = False

            Dim FindMemo As String = ""
            FindMemo = Nz.Nz(dgMEMO("MemoNo", e.RowIndex).Value)
            If Len(Trim(FindMemo)) = 0 Then
                Exit Sub
            End If

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
        End If

        If e.ColumnIndex = 15 Then
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptLisiMemo()
            rptPO.ReportOptions.EnableSaveDataWithReport = False

            Dim FindMemo As String = ""
            FindMemo = Nz.Nz(dgMEMO("SeeMemoNo", e.RowIndex).Value)
            If Trim(FindMemo) = 0 Then
                MsgBox("Nothing to View.")
                Exit Sub
            End If

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
        End If

    End Sub

    Private Sub txtQANotes_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQANotes.GotFocus
        If dgMpo.Rows.Count - 1 >= 0 Then
            If dgMpo("MpoStatus", RowMpo).Value = "Closed" Or dgMpo("MpoStatus", RowMpo).Value = "Cancelled" Or dgMpo("MpoStatus", RowMpo).Value = "Scrapped" Then
                If RoleQA(wkDeptCode) = False Then
                    dgMpo.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtQANotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQANotes.Validating
        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.Rows.Count - 1 >= 0 Then
            dgMpo("MpoQANotes", RowMpo).Value = Trim(txtQANotes.Text)
            UpdateMpoQANotes()
        End If

    End Sub

    Private Sub TabPage12_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage12.Enter

        Me.Cursor = Cursors.WaitCursor

        GC.Collect()

        Dim strSearch As String = ""

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("PartDescCode", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = dgMpo("PartDescCode", RowMpo).Value

        If Len(Trim(strSearch)) > 0 Then
            dsMain.Tables("tblTemp").Clear()
            CallClass.PopulateDataAdapterSearchStrAndStr("getPartAlternativeByDescrCode", strSearch, dgMpo("MPOPartID", RowMpo).Value).Fill(dsMain, "tblTemp")
            dgCross.AutoGenerateColumns = False
            dgCross.DataSource = dsMain
            dgCross.DataMember = "tblTemp"
            dgCross.Refresh()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdDwg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDwg.Click


        Dim pattern As String = txtPart.Text + ".DWG"
        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Engineering\Eng4 (dwg & tech)\Mfg Dwg\Mfg Part dwg")

        ListFiles(lstFiles, pattern, dir_info)

        Dim SwPath As String

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                ' Create an instance
                Dim proc As New System.Diagnostics.Process()

                ' Fill-up StartInfo
                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If
        Else
            MsgBox("Nothing to View.")
        End If

    End Sub

    Private Sub ListFiles(ByVal lst As ListBox, ByVal pattern As String, ByVal dir_info As IO.DirectoryInfo)
        ' Get the files in this directory.
        Dim fs_infos() As IO.FileInfo = dir_info.GetFiles(pattern)
        For Each fs_info As IO.FileInfo In fs_infos
            lstFiles.Items.Add(fs_info.FullName)
        Next fs_info
        fs_infos = Nothing

        ' Search subdirectories.
        Dim subdirs() As IO.DirectoryInfo = dir_info.GetDirectories()
        For Each subdir As IO.DirectoryInfo In subdirs
            ListFiles(lst, pattern, subdir)
        Next subdir
    End Sub

    Private Sub CmdShowAllDeliv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdShowAllDeliv.Click

        GC.Collect()

        Dim strSearch As Integer = 0

        If RowMpo < 0 Then
            Exit Sub
        End If

        If dgMpo.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MpoID", RowMpo).Value) = True Then
            Exit Sub
        End If

        If IsDBNull(dgMpo("MPOPartID", RowMpo).Value) = True Then
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MPOPartID", RowMpo).Value)     'search for all delivery active for the same PartID
        If strSearch > 0 Then
            dsMain.Tables("tblSelectItemDeliv").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlItemsDelivLinkPartIDAllStatus", strSearch).Fill(dsMain, "tblSelectItemDeliv")
            dgDeliv.AutoGenerateColumns = False
            dgDeliv.DataSource = dsMain
            dgDeliv.DataMember = "tblSelectItemDeliv"
            dgDeliv.ReadOnly = True
        Else
            Exit Sub
        End If

        strSearch = Nz.Nz(dgMpo("MpoID", RowMpo).Value)

        If strSearch > 0 Then
            dsMain.Tables("tblLisiPslip").Clear()
            CallClass.PopulateAdapterAfterSearchInt("getShopFloorControlInvLinkMPO", strSearch).Fill(dsMain, "tblLisiPslip")
            dgInv.AutoGenerateColumns = False
            dgInv.DataSource = dsMain
            dgInv.DataMember = "tblLisiPslip"
            dgInv.ReadOnly = True
        End If

        Dim qty As Double = 0.0

        qty = 0.0
        For Each Row As DataGridViewRow In dgInv.Rows
            qty = qty + Nz.Nz(Row.Cells("PslipQty").Value)
        Next
        txtInvQty.Text = qty.ToString("N0")

    End Sub

    Private Sub CmdMpoRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMpoRecords.Click

        'If Len(Trim(txtMpo.Text)) = 0 Then
        '    MsgBox("Nothing to View.")
        '    Exit Sub
        'End If

        'OpenFileDialog1.Reset()

        'Dim Swpath As String = "\\Srv115fs01\Lisi MPO Quality Records\MPO-" + Trim(txtMpo.Text)

        'With OpenFileDialog1
        '    .InitialDirectory = Swpath
        '    .Filter = "All Documents|*.*"
        '    .FilterIndex = 2
        '    .RestoreDirectory = True
        'End With

        'Dim fullAppPath As String = System.IO.Path.GetFullPath(Swpath)

        'If System.IO.Directory.Exists(Swpath) = True Then
        '    OpenFileDialog1.ShowDialog()
        '    Try
        '        Process.Start(OpenFileDialog1.FileName)
        '    Catch
        '    End Try
        'Else
        '    MsgBox("Nothing to View.")
        '    Exit Sub
        'End If

        If dgMpo.RowCount > 0 Then
            Me.txtMPOId.Text = Me.dgMpo("MpoID", RowMpo).Value
            'frmQAMpoRecords.txtMPOId.Text = Me.txtMPOId.Text
            frmQAMpoRecords.txtMpo.Text = Me.txtMpo.Text
            frmQAMpoRecords.txtMpoStatus.Text = Me.dgMpo("MpoStatus", RowMpo).Value
            frmQAMpoRecords.txtPartNo.Text = Me.txtPart.Text
            frmQAMpoRecords.txtMPOClosed.Text = Nz.Nz(Me.dgMpo("StDate", RowMpo).Value)
            frmQAMpoRecords.ShowDialog()
        Else
            MsgBox(" Nothing to View.")
            Exit Sub
        End If

        'If Len(Trim(txtMpo.Text)) = 0 Then
        '    MsgBox("Nothing to View.")
        '    Exit Sub
        'End If

        'OpenFileDialog1.Reset()

        'Dim Swpath As String = "\\Srv115fs01\lisi mpo quality records\Test Certificate (1-4600)"

        'With OpenFileDialog1
        '    .InitialDirectory = Swpath
        '    .FileName = "CT-" + txtMpo.Text + "*.pdf"
        '    .Filter = "All Documents|*.*"
        '    .FilterIndex = 2
        '    .RestoreDirectory = True
        'End With

        'Dim fullAppPath As String = System.IO.Path.GetFullPath(Swpath)

        'If System.IO.Directory.Exists(Swpath) = True Then
        '    OpenFileDialog1.ShowDialog()
        '    Try

        '        Process.Start(OpenFileDialog1.FileName)

        '    Catch
        '    End Try
        'Else
        '    MsgBox("Nothing to View.")
        '    Exit Sub
        'End If

    End Sub

    Private Sub txtMpoPriority_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMpoPriority.Click

        dsMain.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtMpoPriority.Focus()

    End Sub

    Private Sub txtMpoPriority_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMpoPriority.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim strSearch As String
            strSearch = txtMpoPriority.Text

            If RdAll.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMPOPriority", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                txtMpo.Focus()
                dgMpo.Focus()
                Exit Sub
            End If

            If RdActive.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoPriorityActive", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                txtMpo.Focus()
                dgMpo.Focus()
                Exit Sub
            End If

            If RdClosed.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoPriorityClosed", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                txtMpo.Focus()
                dgMpo.Focus()
                Exit Sub
            End If

            If RdCancelled.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlMpoPriorityCancelled", strSearch).Fill(dsMain, "tblMpoMaster")

                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                txtMpo.Focus()
                dgMpo.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub CmdTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTool.Click

        Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptPartToolBox
        rptPO.Load("..\rptPartToolBox.rpt")

        pdvPartID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MpoPartID").Value)
        pvPartIDCollection.Add(pdvPartID)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

        rptPO.Close()
        rptPO.Dispose()

    End Sub

    Private Sub txtRefNoM3_Click(sender As Object, e As EventArgs) Handles txtRefNoM3.Click

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()
        TabControl1.SelectedIndex = 0
        txtRefNoM3.Focus()

    End Sub

    Private Sub txtRefNoM3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRefNoM3.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            strSearch = txtRefNoM3.Text

            If RdAll.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustRefM3", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdActive.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustRefM3Active", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If RdClosed.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustRefM3Closed", strSearch).Fill(dsMain, "tblMpoMaster")
                Me.Cursor = Cursors.Default
                ContinueAfterSrc()
                Exit Sub
            End If

            If RdCancelled.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                CallClass.PopulateDataAdapterAfterSearch("getShopFloorControlCustRefM3Cancelled", strSearch).Fill(dsMain, "tblMpoMaster")
                ContinueAfterSrc()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If

    End Sub

    Private Sub frmShopFloorControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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

