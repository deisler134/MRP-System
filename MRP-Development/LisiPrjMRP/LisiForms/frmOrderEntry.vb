Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmOrderEntry

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daOrder As New SqlDataAdapter
    Private daItem As New SqlDataAdapter
    Private daDeliv As New SqlDataAdapter
    Private daInv As New SqlDataAdapter
    Private daShip As New SqlDataAdapter
    Private daRev As New SqlDataAdapter
    Private daCerts As New SqlDataAdapter
    Private da As New SqlDataAdapter

    Dim OrderCurrency As CurrencyManager
    Dim ItemCurrency As CurrencyManager
    Dim DelivCurrency As CurrencyManager
    Dim InvCurrency As CurrencyManager
    Dim ShipCurrency As CurrencyManager
    Dim RevCurrency As CurrencyManager
    Dim CertsCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""
    Dim ItemRow As Integer = 0
    Dim ItemDeliv As Integer = 0
    Dim ItemCross As Integer = 0
    Dim SwItemNo As String = ""

    Dim DelDate As Date
    Dim StartDate As Date
    Dim EndDate As Date

    Dim KeepOldSTatus As String = ""
    Dim KeepPO As String = ""

    Dim SwNew As Boolean = False

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmOrderEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        OrderCurrency.EndCurrentEdit()
        ItemCurrency.EndCurrentEdit()
        DelivCurrency.EndCurrentEdit()
        InvCurrency.EndCurrentEdit()
        ShipCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()
        CertsCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daOrder.Dispose()
        daItem.Dispose()
        daDeliv.Dispose()
        daInv.Dispose()
        daShip.Dispose()
        daRev.Dispose()
        daCerts.Dispose()
        da.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmOrderEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1825 And Height > 925 Then
            Me.Width = 1825
            Me.Height = 925
        Else
            If Width < 1825 And Height < 925 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height


        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        GC.Collect()

        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        CalculGrid()

        BindComponents()

        dgItem.AutoGenerateColumns = False
        dgItem.DataSource = dsMain
        dgItem.DataMember = "tblCustOrder.OrderItems"

        dgInv.AutoGenerateColumns = False
        dgInv.DataSource = dsMain
        dgInv.DataMember = "tblCustOrder.OrderInv"

        dgShip.AutoGenerateColumns = False
        dgShip.DataSource = dsMain
        dgShip.DataMember = "tblCustOrder.OrderShip"

        dgDeliv.AutoGenerateColumns = False
        dgDeliv.DataSource = dsMain
        dgDeliv.DataMember = "tblCustOrder.OrderItems.ItemsDeliv"

        dgRev.AutoGenerateColumns = False
        dgRev.DataSource = dsMain
        dgRev.DataMember = "tblCustOrder.OrderItems.OrderRevision"

        dgCerts.AutoGenerateColumns = False
        dgCerts.DataSource = dsMain
        dgCerts.DataMember = "tblCustOrder.OrderItems.OrderCerts"

        dgPslipInv.AutoGenerateColumns = False
        dgPslipInv.DataSource = dsMain
        dgPslipInv.DataMember = "tblCustOrder.OrderItems.ItemsDeliv.DelivPslip"

        CallClass.PopulateDataAdapter("gettblCustOrderDispInfo").Fill(dsMain, "tblCustOrder")

        With CmbOrder
            .DataSource = dsMain.Tables("tblCustOrder")
            .DisplayMember = "DispInfo"
            .ValueMember = "OrderID"
        End With


        TakeSalesRepPer()

        CmbM3BillCust.SelectedIndex = -1

    End Sub

    Sub DisableFields()

        KeepItem.ReadOnly = True

        CmbCust.Enabled = False
        SwM3CustCode.Enabled = False
        CmbDevise.Enabled = False
        CmbTerms.Enabled = False
        CmbOrderStatus.Enabled = False
        CmbPOType.Enabled = False

        CmdCust.Enabled = False
        CmdShipNew.Enabled = False
        CmdInvNew.Enabled = False

        txtPONumber.ReadOnly = True
        txtPORev.ReadOnly = True
        txtPODate.ReadOnly = True
        txtPODateRecv.ReadOnly = True
        txtCustRefNo.ReadOnly = True
        txtPODateExp.ReadOnly = True
        txtPONotes.ReadOnly = True
        txtPOBuyer.ReadOnly = True

        txtPSlipNotes.ReadOnly = True
        txtBillingNotes.ReadOnly = True
        txtRevNotes.ReadOnly = True
        txtCerts.ReadOnly = True

        RadioContract.Enabled = False
        RadioOrder.Enabled = False

        dgItem.ReadOnly = True
        dgDeliv.ReadOnly = True
        dgCross.ReadOnly = True
        dgInv.ReadOnly = True
        dgShip.ReadOnly = True
        dgRev.ReadOnly = True
        dgCerts.ReadOnly = True

        LblPer.Visible = False
        txtPer.Visible = False
        txtPer.Text = ""


        dgCross.Columns(0).ReadOnly = True
        dgCross.Columns(1).ReadOnly = True
        dgCross.Columns(2).ReadOnly = True
        dgCross.Columns(3).ReadOnly = True
        dgCross.Columns(4).ReadOnly = True

    End Sub

    Sub EnableFields()
        CmbCust.Enabled = True
        SwM3CustCode.Enabled = False
        CmbDevise.Enabled = True
        CmbTerms.Enabled = True
        CmbOrderStatus.Enabled = True
        CmbPOType.Enabled = True

        CmdCust.Enabled = True
        CmdShipNew.Enabled = True
        CmdInvNew.Enabled = True

        txtPONumber.ReadOnly = False
        txtPORev.ReadOnly = False
        txtPODate.ReadOnly = False
        txtPODateRecv.ReadOnly = False
        txtCustRefNo.ReadOnly = False
        txtPODateExp.ReadOnly = False
        txtPONotes.ReadOnly = False
        txtPOBuyer.ReadOnly = False

        txtPSlipNotes.ReadOnly = False
        txtBillingNotes.ReadOnly = False
        txtRevNotes.ReadOnly = False
        txtCerts.ReadOnly = False

        RadioContract.Enabled = True
        RadioOrder.Enabled = True

        dgItem.ReadOnly = False
        dgDeliv.ReadOnly = False
        dgInv.ReadOnly = False
        dgShip.ReadOnly = False
        dgRev.ReadOnly = False
        dgCerts.ReadOnly = False

        dgCross.ReadOnly = False
        dgCross.Columns(0).ReadOnly = True
        dgCross.Columns(1).ReadOnly = True
        dgCross.Columns(2).ReadOnly = True
        dgCross.Columns(3).ReadOnly = False
        dgCross.Columns(4).ReadOnly = False

    End Sub

    Sub FirstTimeMenuButtons()
        If RoleSalesMng(wkDeptCode) = True Then
            CmdNew.Enabled = False
            CmdReset.Enabled = True
            CmdEdit.Enabled = False
            CmdSave.Enabled = False
        Else
            CmdNew.Enabled = True
            CmdReset.Enabled = True
            CmdEdit.Enabled = True
            CmdSave.Enabled = False
        End If

    End Sub

    Function RoleSalesMng(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MNGSALES" Then
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

    Private Function BuildSqlCommand() As Boolean

        Try
            daOrder = CallClass.PopulateDataAdapter("gettblCustOrder")
            daItem = CallClass.PopulateDataAdapter("gettblCustOrderItem")
            daDeliv = CallClass.PopulateDataAdapter("gettblCustOrderItemDeliv")
            daInv = CallClass.PopulateDataAdapter("gettblCustOrderInv")
            daShip = CallClass.PopulateDataAdapter("gettblCustOrderShip")
            daRev = CallClass.PopulateDataAdapter("gettblCustOrderRev")
            daCerts = CallClass.PopulateDataAdapter("gettblCustOrderCerts")

            Dim OrderBuilder As New SqlClient.SqlCommandBuilder(daOrder)
            Dim ItemBuilder As New SqlClient.SqlCommandBuilder(daItem)
            Dim DelivBuilder As New SqlClient.SqlCommandBuilder(daDeliv)
            Dim InvBuilder As New SqlClient.SqlCommandBuilder(daInv)
            Dim ShipBuilder As New SqlClient.SqlCommandBuilder(daShip)
            Dim RevBuilder As New SqlClient.SqlCommandBuilder(daRev)
            Dim CertsBuilder As New SqlClient.SqlCommandBuilder(daCerts)

            daOrder.UpdateCommand = OrderBuilder.GetUpdateCommand
            daOrder.UpdateCommand.Connection = cn
            daOrder.InsertCommand = OrderBuilder.GetInsertCommand
            AddHandler daOrder.RowUpdated, AddressOf HandleRowUpdatedOrder
            daOrder.InsertCommand.Connection = cn
            daOrder.DeleteCommand = OrderBuilder.GetDeleteCommand
            daOrder.DeleteCommand.Connection = cn
            daOrder.AcceptChangesDuringFill = True
            daOrder.TableMappings.Add("Table", "tblCustOrder")
            daOrder.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daItem.UpdateCommand = ItemBuilder.GetUpdateCommand
            daItem.UpdateCommand.Connection = cn
            daItem.InsertCommand = ItemBuilder.GetInsertCommand
            AddHandler daItem.RowUpdated, AddressOf HandleRowUpdatedItem
            daItem.InsertCommand.Connection = cn
            daItem.DeleteCommand = ItemBuilder.GetDeleteCommand
            daItem.DeleteCommand.Connection = cn
            daItem.AcceptChangesDuringFill = True
            daItem.TableMappings.Add("Table", "tblCustOrderItem")
            daItem.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daDeliv.UpdateCommand = DelivBuilder.GetUpdateCommand
            daDeliv.UpdateCommand.Connection = cn
            daDeliv.InsertCommand = DelivBuilder.GetInsertCommand
            AddHandler daDeliv.RowUpdated, AddressOf HandleRowUpdatedDeliv
            daDeliv.InsertCommand.Connection = cn
            daDeliv.DeleteCommand = DelivBuilder.GetDeleteCommand
            daDeliv.DeleteCommand.Connection = cn
            daDeliv.AcceptChangesDuringFill = True
            daDeliv.TableMappings.Add("Table", "tblCustOrderItemDeliv")
            daDeliv.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daInv.UpdateCommand = InvBuilder.GetUpdateCommand
            daInv.UpdateCommand.Connection = cn
            daInv.InsertCommand = InvBuilder.GetInsertCommand
            AddHandler daInv.RowUpdated, AddressOf HandleRowUpdatedInv
            daInv.InsertCommand.Connection = cn
            daInv.DeleteCommand = InvBuilder.GetDeleteCommand
            daInv.DeleteCommand.Connection = cn
            daInv.AcceptChangesDuringFill = True
            daInv.TableMappings.Add("Table", "tblCustOrderInvInfo")
            daInv.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daShip.UpdateCommand = ShipBuilder.GetUpdateCommand
            daShip.UpdateCommand.Connection = cn
            daShip.InsertCommand = ShipBuilder.GetInsertCommand
            AddHandler daShip.RowUpdated, AddressOf HandleRowUpdatedShip
            daShip.InsertCommand.Connection = cn
            daShip.DeleteCommand = ShipBuilder.GetDeleteCommand
            daShip.DeleteCommand.Connection = cn
            daShip.AcceptChangesDuringFill = True
            daShip.TableMappings.Add("Table", "tblCustOrderShipInfo")
            daShip.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daRev.UpdateCommand = RevBuilder.GetUpdateCommand
            daRev.UpdateCommand.Connection = cn
            daRev.InsertCommand = RevBuilder.GetInsertCommand
            AddHandler daRev.RowUpdated, AddressOf HandleRowUpdatedRev
            daRev.InsertCommand.Connection = cn
            daRev.DeleteCommand = RevBuilder.GetDeleteCommand
            daRev.DeleteCommand.Connection = cn
            daRev.AcceptChangesDuringFill = True
            daRev.TableMappings.Add("Table", "tblCustOrderRev")
            daRev.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daCerts.UpdateCommand = CertsBuilder.GetUpdateCommand
            daCerts.UpdateCommand.Connection = cn
            daCerts.InsertCommand = CertsBuilder.GetInsertCommand
            AddHandler daCerts.RowUpdated, AddressOf HandleRowUpdatedCerts
            daCerts.InsertCommand.Connection = cn
            daCerts.DeleteCommand = CertsBuilder.GetDeleteCommand
            daCerts.DeleteCommand.Connection = cn
            daCerts.AcceptChangesDuringFill = True
            daCerts.TableMappings.Add("Table", "tblCustOrderCerts")
            daCerts.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try


    End Function

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblLisiPslip").Fill(dsMain, "tblLisiPslip")
        CallClass.PopulateDataAdapter("gettblPartCrossPNReferencesEng_Empty").Fill(dsMain, "tblPartCrossPN")


        daOrder.FillSchema(dsMain, SchemaType.Source, "tblCustOrder")
        daItem.FillSchema(dsMain, SchemaType.Source, "tblCustOrderItem")
        daDeliv.FillSchema(dsMain, SchemaType.Source, "tblCustOrderItemDeliv")
        daInv.FillSchema(dsMain, SchemaType.Source, "tblCustOrderInvInfo")
        daShip.FillSchema(dsMain, SchemaType.Source, "tblCustOrderShipInfo")
        daRev.FillSchema(dsMain, SchemaType.Source, "tblCustOrderRev")
        daCerts.FillSchema(dsMain, SchemaType.Source, "tblCustOrderCerts")

        daOrder.Fill(dsMain, "tblCustOrder")
        Dim OrdID As DataColumn = dsMain.Tables("tblCustOrder").Columns("OrderID")
        OrdID.AutoIncrement = True
        OrdID.AutoIncrementStep = -1
        OrdID.AutoIncrementSeed = -1
        OrdID.ReadOnly = False

        daItem.Fill(dsMain, "tblCustOrderItem")
        Dim ItID As DataColumn = dsMain.Tables("tblCustOrderItem").Columns("OrderItemsID")
        ItID.AutoIncrement = True
        ItID.AutoIncrementStep = -1
        ItID.AutoIncrementSeed = -1
        ItID.ReadOnly = False

        daDeliv.Fill(dsMain, "tblCustOrderItemDeliv")
        Dim DelID As DataColumn = dsMain.Tables("tblCustOrderItemDeliv").Columns("OrdDelivID")
        DelID.AutoIncrement = True
        DelID.AutoIncrementStep = -1
        DelID.AutoIncrementSeed = -1
        DelID.ReadOnly = False

        daInv.Fill(dsMain, "tblCustOrderInvInfo")
        Dim InvID As DataColumn = dsMain.Tables("tblCustOrderInvInfo").Columns("OrdInvID")
        InvID.AutoIncrement = True
        InvID.AutoIncrementStep = -1
        InvID.AutoIncrementSeed = -1
        InvID.ReadOnly = False

        daShip.Fill(dsMain, "tblCustOrderShipInfo")
        Dim ShipID As DataColumn = dsMain.Tables("tblCustOrderShipInfo").Columns("OrdShipID")
        ShipID.AutoIncrement = True
        ShipID.AutoIncrementStep = -1
        ShipID.AutoIncrementSeed = -1
        ShipID.ReadOnly = False

        daRev.Fill(dsMain, "tblCustOrderRev")
        Dim RevID As DataColumn = dsMain.Tables("tblCustOrderRev").Columns("OrdRevID")
        RevID.AutoIncrement = True
        RevID.AutoIncrementStep = -1
        RevID.AutoIncrementSeed = -1
        RevID.ReadOnly = False

        daCerts.Fill(dsMain, "tblCustOrderCerts")
        Dim CertsID As DataColumn = dsMain.Tables("tblCustOrderCerts").Columns("OrdCertsID")
        CertsID.AutoIncrement = True
        CertsID.AutoIncrementStep = -1
        CertsID.AutoIncrementSeed = -1
        CertsID.ReadOnly = False

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
            .Relations.Add("OrderRevision", _
                .Tables("tblCustOrderItem").Columns("OrderItemsID"), _
                .Tables("tblCustOrderRev").Columns("OrderItemsID"), True)
        End With

        With dsMain
            .Relations.Add("OrderCerts", _
                .Tables("tblCustOrderItem").Columns("OrderItemsID"), _
                .Tables("tblCustOrderCerts").Columns("OrderItemsID"), True)
        End With

        With dsMain
            .Relations.Add("DelivPslip", _
                .Tables("tblCustOrderItemDeliv").Columns("OrdDelivID"), _
                .Tables("tblLisiPslip").Columns("OrdDelivID"), True)
        End With

        OrderCurrency = CType(BindingContext(dsMain, "tblCustOrder"), CurrencyManager)
        ItemCurrency = CType(BindingContext(dsMain, "tblCustOrderItem"), CurrencyManager)
        DelivCurrency = CType(BindingContext(dsMain, "tblCustOrderItemDeliv"), CurrencyManager)
        InvCurrency = CType(BindingContext(dsMain, "tblCustOrderInvInfo"), CurrencyManager)
        ShipCurrency = CType(BindingContext(dsMain, "tblCustOrderShipInfo"), CurrencyManager)
        RevCurrency = CType(BindingContext(dsMain, "tblCustOrderRev"), CurrencyManager)
        CertsCurrency = CType(BindingContext(dsMain, "tblCustOrderCerts"), CurrencyManager)

    End Sub

    Sub BindComponents()

        txtPONumber.DataBindings.Clear()
        txtPORev.DataBindings.Clear()
        txtPODate.DataBindings.Clear()
        txtPODateRecv.DataBindings.Clear()
        txtCustRefNo.DataBindings.Clear()
        txtPODateExp.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()
        txtPOBuyer.DataBindings.Clear()

        txtPSlipNotes.DataBindings.Clear()
        txtBillingNotes.DataBindings.Clear()
        txtRevNotes.DataBindings.Clear()
        txtCerts.DataBindings.Clear()

        CmbCust.DataBindings.Clear()
        SwM3CustCode.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbTerms.DataBindings.Clear()
        CmbOrderStatus.DataBindings.Clear()
        CmbPOType.DataBindings.Clear()

        RadioOrder.DataBindings.Clear()
        RadioContract.DataBindings.Clear()


        SwM3CustCode.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdM3TwoCust")

        txtPer.DataBindings.Clear()
        txtPer.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdSalesRepPer")

        txtPONumber.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdNumber")
        txtPORev.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdRevision")
        txtPODate.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPODateRecv.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDateRecv", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtCustRefNo.DataBindings.Add("Text", dsMain, "tblCustOrder.ORDRefNo")
        txtPODateExp.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdExpDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPONotes.DataBindings.Add("Text", dsMain, "tblCustOrder.NotesOrder")
        txtPOBuyer.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdBuyer")

        txtPSlipNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderShip.ShipNotes")
        txtBillingNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderInv.InvNotes")
        txtRevNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderItems.OrderRevision.OrdRevNotes")
        txtCerts.DataBindings.Add("Text", dsMain, "tblCustOrder.OrderItems.OrderCerts.OrdCertsNotes")

        CmbCust.DataBindings.Add("SelectedValue", dsMain, "tblCustOrder.CustID")

        CmbDevise.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDevise")
        CmbTerms.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdTerms")
        CmbOrderStatus.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdStatus")
        CmbPOType.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdType")

        RadioOrder.DataBindings.Add(New Binding("Checked", dsMain, "tblCustOrder.OrdOrder", True))
        RadioContract.DataBindings.Add(New Binding("Checked", dsMain, "tblCustOrder.OrdContract", True))

    End Sub


    Sub SetCtlForm()

        PutCust()

        PutM3Cust()

        PutTerms()

        PutHideCross20()

        'for dgCerts   --   Certs Info

        With Me.OrdCertsID
            .DataPropertyName = "OrdCertsID"
            .Name = "OrdCertsID"
            .Visible = False
        End With

        With Me.OrderItemsIDCerts
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.OrdCertsItem
            .DataPropertyName = "OrdCertsItem"
            .Name = "OrdCertsItem"
        End With

        With Me.OrdCertsDescr
            .DataPropertyName = "OrdCertsDescr"
            .Name = "OrdCertsDescr"
        End With

        With Me.OrdCertsValue
            .DataPropertyName = "OrdCertsValue"
            .Name = "OrdCertsValue"
        End With

        With Me.OrdCertsStatus
            .DataPropertyName = "OrdCertsStatus"
            .Name = "OrdCertsStatus"
        End With

        With Me.OrdCertsNotes
            .DataPropertyName = "OrdCertsNotes"
            .Name = "OrdCertsNotes"
        End With


        'for dgRev   --   Revision Info
        With Me.OrdRevID
            .DataPropertyName = "OrdRevID"
            .Name = "OrdRevID"
            .Visible = False
        End With

        With Me.OrderItemsIDRev
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.OrdRevItem
            .DataPropertyName = "OrdRevItem"
            .Name = "OrdRevItem"
        End With

        With Me.OrdRevNo
            .DataPropertyName = "OrdRevNo"
            .Name = "OrdRevNo"
        End With

        With Me.OrdRevDate
            .DataPropertyName = "OrdRevDate"
            .Name = "OrdRevDate"
        End With

        With Me.OrdRevPrice
            .DataPropertyName = "OrdRevPrice"
            .Name = "OrdRevPrice"
        End With

        With Me.OrdRevNotes
            .DataPropertyName = "OrdRevNotes"
            .Name = "OrdRevNotes"
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

        With Me.InvNotes
            .DataPropertyName = "InvNotes"
            .Name = "InvNotes"
        End With


        'for dgItem  Items Description
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
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40
            
        End With

        With Me.OrdPartCross99ID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross20").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "OrdPartCross99ID"
            .Name = "OrdPartCross99ID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40

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

        With Me.OrdLACStdPrice
            .DataPropertyName = "OrdLACStdPrice"
            .Name = "OrdLACStdPrice"
        End With

        With Me.OrdItemStatus
            .DataPropertyName = "OrdItemStatus"
            .Name = "OrdItemStatus"
        End With

        With Me.OrdItemNotes
            .DataPropertyName = "OrdItemNotes"
            .Name = "OrdItemNotes"
        End With

        With Me.SwM3Article
            .DataPropertyName = "SwM3Article"
            .Name = "SwM3Article"
        End With

        With Me.SwMFGM3Article
            .DataPropertyName = "SwMFGM3Article"
            .Name = "SwMFGM3Article"
        End With

        ' for dgcross

        With Me.CrossID
            .DataPropertyName = "CrossID"
            .Name = "CrossID"
            .Visible = False
        End With

        With Me.CrossMasterID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross8899").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "CrossMasterID"
            .Name = "CrossMasterID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

        With Me.CrossReferenceID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross20").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "CrossReferenceID"
            .Name = "CrossReferenceID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

        With Me.CrossStatus
            .DataPropertyName = "CrossStatus"
            .Name = "CrossStatus"
        End With

        With Me.CrossNotes
            .DataPropertyName = "CrossNotes"
            .Name = "CrossNotes"
        End With




        'for dgOrdDeliv Delivery Info
        With Me.OrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
        End With

        With Me.OrderItemsIDDeliv
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
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

        With Me.DelivType
            .DataPropertyName = "DelivType"
            .Name = "DelivType"
        End With

        'With Me.DelivShippedQty
        '    .DataPropertyName = "DelivShippedQty"
        '    .Name = "DelivShippedQty"
        'End With

        With Me.DelivStatus
            .DataPropertyName = "DelivStatus"
            .Name = "DelivStatus"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

        With Me.DelivFermDate
            .DataPropertyName = "DelivFermDate"
            .Name = "DelivFermDate"
        End With

        'dgPslipInv

        With Me.InvOrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.InvPosted
            .DataPropertyName = "InvPosted"
            .Name = "InvPosted"
        End With

        With Me.PslipType
            .DataPropertyName = "PslipType"
            .Name = "PslipType"
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
        End With

        With Me.PslipQty
            .DataPropertyName = "PslipQty"
            .Name = "PslipQty"
        End With

    End Sub

    Sub PutM3Cust()

        With Me.CmbM3BillCust
            .DataSource = CallClass.PopulateComboBox("tblCustInv", "cmbGetM3Customer").Tables("tblCustInv")
            .DisplayMember = "FullDescr"
            .ValueMember = "InvCodeM3"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

    End Sub

    Sub PutCust()
        With Me.CmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutShipAddress()

        With Me.ShipWhere
            .DataSource = CallClass.PopulateComboBox("tblCustShip", "cmbGetShipWhere").Tables("tblCustShip")
            .DisplayMember = "FullDest"
            .ValueMember = "CustShipID"
            .DataPropertyName = "ShipWhere"
            .Name = "ShipWhere"
            .DropDownWidth = 600
            .MaxDropDownItems = 30
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


    Sub PutInvAddress()
        With Me.InvWhere
            .DataSource = CallClass.PopulateComboBox("tblCustInv", "cmbGetInvWhere").Tables("tblCustInv")
            .DisplayMember = "FullDest"
            .ValueMember = "CustInvID"
            .DataPropertyName = "InvWhere"
            .Name = "InvWhere"
            .DropDownWidth = 600
            .MaxDropDownItems = 30
        End With

    End Sub

    Sub PutHideCross20()


        With Me.CmbCross20
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross20").Tables("tblPartMaster")
            .DisplayMember = "PartID"
            .ValueMember = "PartID"
        End With

    End Sub


    Private Sub HandleRowUpdatedOrder(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrder").Columns("OrderID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedItem(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderItem").Columns("OrderItemsID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedDeliv(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderItemDeliv").Columns("OrdDelivID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedInv(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderInvInfo").Columns("OrdInvID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedShip(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderShipInfo").Columns("OrdShipID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedRev(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderRev").Columns("OrdRevID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedCerts(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustOrderCerts").Columns("OrdCertsID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub txtPODate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPODate.Validating

        Try
            Dim dt As DateTime = DateTime.Parse(txtPODate.Text)
            If dt.Year < Now.Year - 4 OrElse dt.Year > Now.Year + 4 Then
                MsgBox("The Range of valid Years must be between" + Str(Now.Year) - 4 + " and " + Str(Now.Year) + 4)
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, _
            MsgBoxStyle.OkOnly, "Date of Order: MM/dd/yyyy")
            e.Cancel = True
        End Try

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbOrder.Enabled = False

        dsMain.RejectChanges()
        dgItem.Refresh()
        dgDeliv.Refresh()
        dgInv.Refresh()
        dgShip.Refresh()
        dgRev.Refresh()
        dgCross.Refresh()

        CmbOrder.SelectedIndex = -1
        OrderCurrency.EndCurrentEdit()
        OrderCurrency.AddNew()

        EnableFields()

        Call InitValue()

        CmbCust.Focus()

        SwNew = True

    End Sub

    Sub InitValue()
        txtPODate.Text = Now.ToShortDateString
        txtPODateRecv.Text = Now.ToShortDateString

        CmbDevise.Text = "USD"

        CmbOrderStatus.Text = "Active"
        CmbPOType.Text = "Normal"

        CmbCust.SelectedIndex = -1

        RadioOrder.Checked = True
        RadioContract.Checked = False

        CmbTerms.Text = "Net 60 Days"

    End Sub


    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        If Len(Trim(CmbCust.Text)) = 0 Or Len(Trim(txtPONumber.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Nothing to modify.")
            Exit Sub
        End If

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbOrder.Enabled = False

        EnableFields()

        TakeSalesRepPer()

        SwNew = False

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        OrderCurrency.EndCurrentEdit()
        ItemCurrency.EndCurrentEdit()
        DelivCurrency.EndCurrentEdit()
        InvCurrency.EndCurrentEdit()
        ShipCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()
        CertsCurrency.EndCurrentEdit()

        dsMain.RejectChanges()

        DisableFields()
        FirstTimeMenuButtons()

        CmbOrder.Enabled = True
        CmbOrder.SelectedIndex = -1

        SwOper = ""

        SwNew = False

        dsMain.Tables("tblPartCrossPN").Clear()

    End Sub

    Public Function GetOrderNumber(ByVal ParamNo As String) As SqlDataAdapter

        Dim cmdSql = New SqlCommand()
        cmdSql.Connection = cn
        cmdSql.CommandType = CommandType.StoredProcedure
        cmdSql.CommandText = "getTblCustOrderFindOrder"

        'Dim da = New SqlDataAdapter()
        da.SelectCommand = cmdSql

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@ParamNo", SqlDbType.NVarChar, 50)
        parameterPoNum.Value = ParamNo
        da.SelectCommand.Parameters.Add(parameterPoNum)

        Return da

    End Function

    Private Sub CmdCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCust.Click
        frmCustomer.SwForm.Text = CmbCust.SelectedIndex
        frmCustomer.ShowDialog()

        PutCust()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgCross.EndEdit()

        CmbDevise.Focus()

        CmbOrderStatus.Focus()

        CmdSave.Focus()

        CmbDevise.Focus()

        CmbOrderStatus.Focus()

        CmdSave.Focus()
        CmbCust.Focus()

        Call ValPo()

        If SwVal = True Then

            SwOper = "Save"

            SwNew = False

            KeepPO = txtPONumber.Text

            OrderCurrency.EndCurrentEdit()
            ItemCurrency.EndCurrentEdit()
            DelivCurrency.EndCurrentEdit()
            InvCurrency.EndCurrentEdit()
            ShipCurrency.EndCurrentEdit()
            RevCurrency.EndCurrentEdit()
            CertsCurrency.EndCurrentEdit()

            SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

            Try
                If dsMain.HasChanges Then

                    SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

                    dsMain.GetChanges()
                    daOrder.Update(dsMain.Tables("tblCustOrder").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daItem.Update(dsMain.Tables("tblCustOrderItem").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daDeliv.Update(dsMain.Tables("tblCustOrderItemDeliv").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daInv.Update(dsMain.Tables("tblCustOrderInvInfo").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daShip.Update(dsMain.Tables("tblCustOrderShipInfo").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daRev.Update(dsMain.Tables("tblCustOrderRev").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daCerts.Update(dsMain.Tables("tblCustOrderCerts").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

                    dsMain.AcceptChanges()

                    MsgBox("Update successfully.")

                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgItem.Refresh()
            dgDeliv.Refresh()
            dgCross.Refresh()
            dgInv.Refresh()
            dgShip.Refresh()
            dgRev.Refresh()
            dgCerts.Refresh()

            SwOper = ""
            DisableFields()
            FirstTimeMenuButtons()
            CmdNew.Enabled = False
            BindComponents()
        End If

    End Sub


    Sub ValPo()

        If Len(Trim(CmbTerms.Text)) = 0 Or IsDBNull(CmbTerms.Text) = True Or IsNothing(CmbTerms.Text) = True Then
            MsgBox("!!! ERROR !!! Terms are Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbCust.SelectedValue)) = 0 Or IsDBNull(CmbCust.SelectedValue) = True Or IsNothing(CmbCust.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Customer is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPONumber.Text)) = 0 Or IsDBNull(txtPONumber.Text) = True Or IsNothing(txtPONumber.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPODate.Text)) = 0 Or IsDBNull(txtPODate.Text) = True Or IsNothing(txtPODate.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Date is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPODateRecv.Text)) = 0 Or IsDBNull(txtPODateRecv.Text) = True Or IsNothing(txtPODateRecv.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Date Received is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbDevise.Text)) = 0 = True Or IsDBNull(CmbDevise.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Devise is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbOrderStatus.Text)) = 0 Or IsDBNull(CmbOrderStatus.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Status is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPOType.Text)) = 0 Or IsDBNull(CmbPOType.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Order Type is Empty.")
            SwVal = False
            Exit Sub
        End If


        'Dim GG As Integer
        'GG = 0
        'If dgCross.Rows.Count >= 1 Then
        '    For Each Row As DataGridViewRow In dgCross.Rows
        '        If IsDBNull(Row.Cells("CrossReferenceID").Value) = False And IsNothing(Row.Cells("CrossReferenceID").Value) = False Then
        '            If IsDBNull(Row.Cells("CrossMasterID").Value) = False And IsNothing(Row.Cells("CrossMasterID").Value) = False Then
        '                If Row.Cells("CrossStatus").Value <> "Approved" Then
        '                    If GG = 0 Then
        '                        MsgBox("!!! ERROR !!! Please Approve at least one Cross P/N.")
        '                        SwVal = False
        '                        Exit Sub
        '                    End If
        '                Else
        '                    GG = GG + 1
        '                End If
        '            End If
        '        End If
        '    Next
        'End If


        For Each Row As DataGridViewRow In dgItem.Rows
            If IsDBNull(Row.Cells("OrdPartNoID").Value) = True Then
                MsgBox("!!! ERROR !!! Customer PartNumber is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("OrdPartCross99ID").Value) = True Then
                MsgBox("!!! ERROR !!! Manufacturing PartNumber is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("OrdLACStdPrice").Value) = True Then
                MsgBox("!!! ERROR !!! LAC Standard Price is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("OrdItemQty").Value) = True Then
                MsgBox("!!! ERROR !!! Order Qty is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("OrdItemPrice").Value) = True Then
                MsgBox("!!! ERROR !!! Order Price is Empty.")
                SwVal = False
                Exit Sub
            End If

        Next

        For Each Row As DataGridViewRow In dgDeliv.Rows
            If IsDBNull(Row.Cells("DelivDate").Value) = True Then
                MsgBox("!!! ERROR !!! Delivery Date is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("DelivQty").Value) = True Then
                MsgBox("!!! ERROR !!! Delivery Qty is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        For Each Row As DataGridViewRow In dgRev.Rows
            If IsDBNull(Row.Cells("OrdRevItem").Value) = False Then
                If IsDBNull(Row.Cells("OrdRevNo").Value) = True Then
                    MsgBox("!!! ERROR !!! Revision Number is Empty.")
                    SwVal = False
                    Exit Sub
                End If
                If IsDBNull(Row.Cells("OrdRevDate").Value) = True Then
                    MsgBox("!!! ERROR !!! Revision Date is Empty.")
                    SwVal = False
                    Exit Sub
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgCerts.Rows
            If IsDBNull(Row.Cells("OrdCertsItem").Value) = False Then
                If IsDBNull(Row.Cells("OrdCertsValue").Value) = True Then
                    MsgBox("!!! ERROR !!! Amount Value is Empty. Please check Certs Charge DataGrid.")
                    SwVal = False
                    Exit Sub
                End If
            End If
        Next


        If SwCustShort.Text = "LNA-SpotPOs" Then
            For Each Row As DataGridViewRow In dgInv.Rows
                If InStr(Row.Cells("InvWhere").Value, "Spot POs") <> 0 Then
                    MsgBox("!!! ERROR !!! Customer LNA Spot PO   -   You must Choose Bill to LNA Spot POs.")
                    SwVal = False
                    Exit Sub
                End If
            Next

            If Len(Trim(CmbM3BillCust.SelectedValue)) = 0 Or IsDBNull(CmbM3BillCust.SelectedValue) = True Or IsNothing(CmbM3BillCust.SelectedValue) = True Then
                MsgBox("!!! ERROR !!! M3 Customer code is Empty when we do hace LNA Customer Spot POs.")
                SwVal = False
                Exit Sub
            End If

        End If


        SwVal = True

    End Sub

    Private Sub dgItem_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgItem.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemRow = e.RowIndex
        ItemDeliv = 0
        ItemCross = 0

        Select Case e.ColumnIndex
            Case 3 To 9
                If IsDBNull(dgItem("OrdItemNo", e.RowIndex).Value) = True Then
                    MsgBox("You cannot edit here without Order Item Number.")
                    e.Cancel = True
                Else
                    e.Cancel = False
                    KeepItem.Text = dgItem("OrdItemNo", e.RowIndex).Value.ToString
                End If
        End Select

    End Sub

    Private Sub dgItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellClick

        If e.RowIndex < 0 Then
        Else
            'dgItem.Refresh()

            ItemRow = e.RowIndex
            ItemDeliv = 0
            ItemCross = 0

            dgItem("SwM3Article", e.RowIndex).ReadOnly = True

            dgItem("SwMFGM3Article", e.RowIndex).ReadOnly = True

            dgItem("OrdPartCross99ID", e.RowIndex).ReadOnly = True

            'dgItem("OrdLACStdPrice", e.RowIndex).ReadOnly = True

            KeepItem.Text = dgItem("OrdItemNo", e.RowIndex).Value.ToString

            totQty.Text = dgItem("OrdItemQty", e.RowIndex).Value.ToString

            'dgItem("OrdItemQNO", e.RowIndex).ReadOnly = False

            Dim II As Integer = 0
            For Each Row As DataGridViewRow In dgItem.Rows
                If IsDBNull(Row.Cells("OrdItemNo").Value) = False Then
                    If Row.Cells("OrdItemNo").Value = KeepItem.Text Then
                        II = II + 1
                    End If
                    If IsDBNull(Row.Cells("OrdPartNoID").Value) = False And IsNothing(Row.Cells("OrdPartNoID").Value) = False And Nz.Nz(Row.Cells("OrdPartNoID").Value) > 0 Then

                        PutInfoCrossDual()

                        Row.Cells("SwM3Article").Value = CallClass.ReturnStrWithParInt("cspReturnM3Code", Row.Cells("OrdPartNoID").Value)
                        If Row.Cells("SwM3Article").Value = "False" Then
                            Row.DefaultCellStyle.BackColor = Color.LightBlue
                        Else
                            Row.DefaultCellStyle.BackColor = Color.Empty
                        End If

                        Row.Cells("SwMFGM3Article").Value = CallClass.ReturnStrWithParInt("cspReturnM3Code", Row.Cells("OrdPartCross99ID").Value)
                        If Row.Cells("SwMFGM3Article").Value = "False" Then
                            Row.DefaultCellStyle.BackColor = Color.LightBlue
                        Else
                            Row.DefaultCellStyle.BackColor = Color.Empty
                        End If


                    End If
                End If
            Next

        End If

        'CalculGrid()

    End Sub

    Private Sub dgItem_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            ItemRow = e.RowIndex
        End If

        'CalculGrid()

        If IsDBNull(dgItem.Rows(e.RowIndex).Cells("OrdItemStatus").Value) = True Then
            dgItem.Rows(e.RowIndex).Cells("OrdItemStatus").Value = "Active"
        End If

        If IsDBNull(dgItem.Rows(e.RowIndex).Cells("OrdItemUM").Value) = True Then
            dgItem.Rows(e.RowIndex).Cells("OrdItemUM").Value = "EA"
        End If

        Select Case e.ColumnIndex
            Case 2
                'If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = False Then
                'dgItem.Rows(e.RowIndex).Cells("OrdItemQty").Value = 0
                'dgItem.Rows(e.RowIndex).Cells("OrdItemPrice").Value = 0
                'End If

            Case 3
                If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value) = False Then
                    Dim SwStatus As String = ""
                    Dim SwCrossPN As String = ""
                    Dim SwCross20 As String = ""

                    SwStatus = CallClass.ReturnStrWithParInt("cspReturnM3Status", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value) ' return the P/N status
                    If SwStatus = False Then
                        MessageBox.Show("Missing P/N status (20 or 88 or 99)" + vbCrLf + "Please save and close Order Entry - Open Part Master Short to update the P/N status.")

                        DisableFields()
                        Exit Sub

                    Else
                        PutInfoCrossDual()
                    End If

                    '###################################################################

                    If SwStatus = 99 Or SwStatus = 88 Then
                        ' look for ID cross 20
                        SwCrossPN = CallClass.ReturnStrWithParInt("cspReturnM3CrossPN_ID_20", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
                        If SwCrossPN = False Then
                            MessageBox.Show("Missing Hi-Shear Part Number to MFR" + vbCrLf + "Please save and wait for the updates to be done. Email was sent IT department.")

                            Dim email As New Mail.MailMessage()
                            Dim strBody As String = ""
                            Dim strText As String = ""
                            strText = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
                            email.Subject = "Missing Hi-Shear Part Number to MFR - Need to be updated into SQL DB."
                            strBody = "For the P/N:   " + strText
                            email.Body = strBody

                            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
                            client.Send(email)
                            Exit Sub
                        Else
                            CmbCross20.SelectedValue = SwCrossPN
                            dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value = CmbCross20.SelectedValue
                        End If

                    Else

                        dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value = dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value

                    End If

                    '###################################################################


                    If SwCustShort.Text = "LISI-CDN" Then       'THIS IS FOR STOCK NEDD TO PULL OUT THE TABLE WITH THE COST PER DIA - same prices for both fields

                        PutMachiningStdCost()

                        dgItem.Rows(ItemRow).Cells("OrdItemPrice").Value = dgItem.Rows(ItemRow).Cells("OrdLACStdPrice").Value

                    Else
                        If SwCustShort.Text = "LNA" Then            'THIS IS FOR Spot POs -  NEED TO PULL OUT THE TABLE WITH THE PRICE LIST 2014/2015 ETC... and std price
                            frmOrderEntryPutBCAYearPrice.txtSW.Text = dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value
                            frmOrderEntryPutBCAYearPrice.txtRow.Text = e.RowIndex
                            frmOrderEntryPutBCAYearPrice.ShowDialog()
                            frmOrderEntryPutBCAYearPrice.Dispose()

                            PutMachiningStdCost()
                        Else
                            PutMachiningStdCost()

                            'CallClass.ExecuteUpdateTwoParams("cspUpdateQuoteItemStatus90", Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdItemQNO").Value), dgItem.Rows(e.RowIndex).Cells("OrdPartNoID").Value)
                            'CallClass.ExecuteUpdateSearchStr("cspUpdateQuoteFollowUpNull", Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdItemQNO").Value))
                        End If

                    End If


                    dgItem.Rows(ItemRow).Cells("SwM3Article").Value = CallClass.ReturnStrWithParInt("cspReturnM3Code", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
                    If IsDBNull(dgItem.Rows(ItemRow).Cells("SwM3Article").Value) = True Or dgItem.Rows(ItemRow).Cells("SwM3Article").Value = "False" Then
                        MessageBox.Show("!!! ERROR !!! Missing M3 Item for Customer Part Number. Please update the M3 code now - if not we'll have issues on REQ & PSlip.")
                        frmOrderEntryPutM3ITNO.txtSW.Text = dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value
                        frmOrderEntryPutM3ITNO.txtRow.Text = e.RowIndex
                        frmOrderEntryPutM3ITNO.ShowDialog()
                        frmOrderEntryPutM3ITNO.Dispose()
                    End If

                    dgItem.Rows(ItemRow).Cells("SwMFGM3Article").Value = CallClass.ReturnStrWithParInt("cspReturnM3Code", dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value)
                    If IsDBNull(dgItem.Rows(ItemRow).Cells("SwMFGM3Article").Value) = True Or dgItem.Rows(ItemRow).Cells("SwMFGM3Article").Value = "False" Then
                        MessageBox.Show("!!! ERROR !!! Missing M3 Item for MFG Part Number. Please update the M3 code now - if not we'll have issues on REQ & PSlip.")
                        frmOrderEntryPutM3ITNO.txtSW.Text = dgItem.Rows(ItemRow).Cells("OrdPartCross99ID").Value
                        frmOrderEntryPutM3ITNO.txtRow.Text = e.RowIndex
                        frmOrderEntryPutM3ITNO.ShowDialog()
                        frmOrderEntryPutM3ITNO.Dispose()
                    End If

                End If

            Case 7  ' when the quote# was updated
                'CallClass.ExecuteUpdateTwoParams("cspUpdateQuoteItemStatus90", Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdItemQNO").Value), dgItem.Rows(e.RowIndex).Cells("OrdPartNoID").Value)
                'CallClass.ExecuteUpdateSearchStr("cspUpdateQuoteFollowUpNull", Nz.Nz(dgItem.Rows(e.RowIndex).Cells("OrdItemQNO").Value))

        End Select

    End Sub

    Sub PutInfoCrossDual()

        If Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value) <> 0 Then
            Dim SwStatus As String = ""
            Dim SwCrossPN As String = ""

            SwStatus = CallClass.ReturnStrWithParInt("cspReturnM3Status", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
            If SwStatus = False Then
                MessageBox.Show("Missing CrossPN status 20 / 88 / 99" + vbCrLf + "Please update the P/N Cross status.")
                Exit Sub
            End If

            If SwStatus = 99 Or SwStatus = 88 Then
                ' look for ID cross 20
                SwCrossPN = CallClass.ReturnStrWithParInt("cspReturnM3CrossPN_ID_20", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value) ' return CrossReferenceID based on 88/99 CrossMasterID
                If SwCrossPN = False Then
                    MessageBox.Show("!!! ERROR !!! - Missing Hi-Shear Part Number to MFR in Cross Reference Table.")

                    Dim email As New Mail.MailMessage()
                    Dim strBody As String = ""
                    Dim strText As String = ""
                    strText = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
                    email.Subject = " Missing Hi-Shear Part Number to MFR in Cross Reference Table"
                    strBody = "For the P/N:   " + strText
                    email.Body = strBody
                    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                    email.From = New Net.Mail.MailAddress(wkEmpEmail)
                    email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
                    client.Send(email)
                    Exit Sub

                Else

                    'status 88 or 99 for OrdPartNoID ( I do have CrossRefereanceID (20) and take from  in tblPartCrossPN ID for CrossRefereanceID
                    dsMain.Tables("tblPartCrossPN").Clear()

                    CallClass.PopulateAdapterAfterSearchInt("gettblPartCrossPNReferencesEng_88_99", SwCrossPN).Fill(dsMain, "tblPartCrossPN")

                    dgCross.AutoGenerateColumns = False
                    dgCross.DataSource = dsMain
                    dgCross.DataMember = "tblPartCrossPN"
                    dgCross.Refresh()
                End If

            Else

                'status 20(I do have CrossReferenceID and I need to see all status 99 88 ID

                dsMain.Tables("tblPartCrossPN").Clear()
                CallClass.PopulateAdapterAfterSearchInt("gettblPartCrossPNReferencesEng_88_99", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value).Fill(dsMain, "tblPartCrossPN")

                dgCross.AutoGenerateColumns = False
                dgCross.DataSource = dsMain
                dgCross.DataMember = "tblPartCrossPN"
                dgCross.Refresh()
            End If

        End If

    End Sub

    Sub PutMachiningStdCost()

        Dim txtDescrCode As String = ""
        txtDescrCode = CallClass.ReturnStrWithParInt("cspReturnPartDescrCode", dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value)
        If txtDescrCode = "False" Then
            MessageBox.Show("!!! ERROR !!! Missing Decr Code." + vbCrLf + "Please enter manually the machining standard cost.")
        Else
            Dim ArrStr As String
            ArrStr = Trim(txtDescrCode)
            Dim I As Integer = 0
            Dim NrOf As Integer = 0
            Dim KeepPos As Integer = 0
            Dim Matl As String = ""
            Dim SwDia As String = ""

            For I = 0 To Len(ArrStr) - 1
                If ArrStr(I) = CChar("-") Then
                    KeepPos = I
                    NrOf = NrOf + 1
                    If NrOf = 2 Then
                        SwDia = Mid(ArrStr, KeepPos + 2, 3)
                        If Microsoft.VisualBasic.Right(SwDia, 1) = "-" Then
                            SwDia = Microsoft.VisualBasic.Left(SwDia, 2)
                        End If
                        Exit For
                    End If
                End If
            Next

            MessageBox.Show("Part Number DIA = " + SwDia + vbCrLf + "Please chose the standard maching cost based on DIA/16 = " + Str(CInt(SwDia) / 16))
            frmOrderEntryPutMachSTDCost.txtSW.Text = dgItem.Rows(ItemRow).Cells("OrdPartNoID").Value
            frmOrderEntryPutMachSTDCost.txtRow.Text = ItemRow
            frmOrderEntryPutMachSTDCost.ShowDialog()
            frmOrderEntryPutMachSTDCost.Dispose()
        End If

    End Sub

    Private Sub dgItem_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItem.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemRow = e.RowIndex
        ItemDeliv = 0
        ItemCross = 0

        KeepItem.Text = Nz.Nz(dgItem("OrdItemNo", e.RowIndex).Value).ToString

        CalculGrid()

    End Sub

    Private Sub dgItem_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgItem.DataError
        REM end
    End Sub

    Sub CalculGrid()

        totQty.Text = 0
        totValue.Text = 0
        totDelQty.Text = 0
        totShipQty.Text = 0
        DelQtyPerLine.Text = 0
        QtyToShip.Text = 0

        Dim CountRow As Integer = 0

        If dgItem.RowCount <= 0 Then
            Exit Sub
        End If


        Try
            totQty.Text = Val(Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemQty").Value)).ToString("N0")
            totValue.Text = Val((Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemQty").Value) * Nz.Nz(dgItem.Rows(ItemRow).Cells("OrdItemPrice").Value))).ToString("N2")
        Catch ex As Exception
        End Try


        For Each RowDeliv As DataGridViewRow In dgDeliv.Rows
            totDelQty.Text = Val(totDelQty.Text + Nz.Nz(RowDeliv.Cells("DelivQty").Value)).ToString("N0")
        Next

        For Each RowDeliv As DataGridViewRow In dgPslipInv.Rows
            totShipQty.Text = Val(totShipQty.Text + Nz.Nz(RowDeliv.Cells("PslipQty").Value)).ToString("N0")
        Next

        If ItemDeliv < 0 Then
        Else
            DelQtyPerLine.Text = Val(Nz.Nz(dgDeliv.Rows(ItemDeliv).Cells("DelivQty").Value)).ToString("N0")
        End If

        Dim DifRes As Integer
        DifRes = (totQty.Text) - (totDelQty.Text)
        DiffQty.Text = DifRes.ToString("N0")

        DifRes = (DelQtyPerLine.Text) - (totShipQty.Text)
        QtyToShip.Text = DifRes.ToString("N0")

        If DifRes <> 0 Then
            Me.ErrorProvider1.SetError(DiffQty, "Total Delivery Quantity not Equal with Item Quantity.")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        Else
            Me.ErrorProvider1.Clear()
        End If

    End Sub

    Private Sub dgDeliv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDeliv.CellBeginEdit
        If ItemRow < 0 Then
            Exit Sub
        End If

        ItemDeliv = e.RowIndex

        If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Or _
                Len(Trim(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value)) = 0 = True Then
            MsgBox("You cannot edit here without Order Item Number.")
            e.Cancel = True
        End If

        If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value) = False Then
            If dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value = "Closed" Then
                MsgBox("Action Denied. Delivery Status = Closed.")
                e.Cancel = True
                Exit Sub
            End If
        End If

        If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value) = True Then
            KeepOldSTatus = "Active"
        Else
            KeepOldSTatus = dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value
        End If

        Select Case e.ColumnIndex
            Case 4 To 8
                If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivDate").Value) = True Then
                    MsgBox("You cannot edit here without Delivery Date.")
                    e.Cancel = True
                End If
            Case 5
                If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value) = False Then
                    If dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value = "Confirmed" Then
                        e.Cancel = True
                    End If
                End If
        End Select
    End Sub

    Private Sub dgDeliv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemDeliv = e.RowIndex

        dgDeliv.Rows(e.RowIndex).ReadOnly = True

        Select Case e.ColumnIndex
            Case 2 To 8
                If ItemRow >= 0 Then
                    'CalculGrid()

                    If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Then
                        MsgBox("You cannot edit here without Order Item Numer.")
                    Else
                        dgDeliv("PoNoDeliv", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivDate", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivQty", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivType", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivStatus", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivNotes", e.RowIndex).ReadOnly = False
                        dgDeliv("DelivFermDate", e.RowIndex).ReadOnly = False
                    End If
                End If
        End Select

    End Sub

    Private Sub dgDeliv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellEndEdit
        Select Case e.ColumnIndex
            Case 3
                dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value = "Active"
                If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value) = True Then
                    dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value = "Estimated"
                End If

                Dim dt As DateTime = DateTime.Parse(Me.dgDeliv("DelivDate", e.RowIndex).Value)

                If dt.Year < Now.Year - 4 OrElse dt.Year > Now.Year + 4 Then
                    MsgBox("The Range of valid Years must be between" + Str(Now.Year) - 4 + " and " + Str(Now.Year) + 4)

                    Dim II As Keys
                    II = Keys.Escape

                    Nz.Nz(dgDeliv.Rows(e.RowIndex).Cells("DelivDate")).Value = DBNull.Value
                Else
                    DelDate = CDate(dgDeliv("DelivDate", e.RowIndex).Value).ToShortDateString
                    StartDate = DateAdd(DateInterval.Day, -112, DelDate).ToShortDateString      '16 wks
                    EndDate = DateAdd(DateInterval.Day, -35, DelDate).ToShortDateString         '5 wks
                    CreateDeliv()
                End If

            Case 5
                If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value) = False Then
                    If dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value = "Confirmed" Then
                        dgDeliv.Rows(e.RowIndex).Cells("DelivFermDate").Value = Now.ToShortDateString
                    End If
                End If

                If IsDBNull(dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value) = False Then
                    If dgDeliv.Rows(e.RowIndex).Cells("DelivType").Value = "Confirmed" Then
                        If dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value = "Cancelled" Then
                            If Month(dgDeliv.Rows(e.RowIndex).Cells("DelivFermDate").Value) <> Month(Now.ToShortDateString) Then
                                MsgBox("!!! ERROR !!! You can not cancel this delivery date. Close it and make a booking adj. if is necessary.")
                                dgDeliv.Rows(e.RowIndex).Cells("DelivStatus").Value = KeepOldSTatus
                            End If
                        End If
                    End If
                End If
        End Select

        If dsMain.HasChanges(DataRowState.Added) Then
            dgItem.Refresh()
        End If

    End Sub

    Sub CreateDeliv()

        If ItemDeliv < 0 Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDelivStartEndProd", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraDelivID.Value = dgDeliv("OrdDelivID", ItemDeliv).Value
            mySqlComm.Parameters.Add(paraDelivID)

            Dim paraStartDate As SqlParameter = New SqlParameter("@StartProdDate", SqlDbType.SmallDateTime, 4)
            paraStartDate.Value = StartDate
            mySqlComm.Parameters.Add(paraStartDate)

            Dim paraEndDate As SqlParameter = New SqlParameter("@EndProdDate", SqlDbType.SmallDateTime, 4)
            paraEndDate.Value = EndDate
            mySqlComm.Parameters.Add(paraEndDate)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update Start/End Production Date: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Update Start/End Production Date: " & ex.Message)
        End Try

    End Sub

    Private Sub dgDeliv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeliv.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemDeliv = e.RowIndex

        CalculGrid()

    End Sub

    Private Sub dgDeliv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDeliv.DataError
        REM end
    End Sub

    Private Sub dgInv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInv.CellClick
        Try
            Select Case e.ColumnIndex

                Case 3
                    PutInvAddress()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgInv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgInv.DataError
        REM end
    End Sub

    Private Sub dgShip_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgShip.CellClick
        Try
            Select Case e.ColumnIndex

                Case 3
                    PutShipAddress()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgShip_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgShip.CellEndEdit

        If e.ColumnIndex = 2 Then
            If IsDBNull(dgShip.Rows(e.RowIndex).Cells("ShipNotes").Value) = True Then
                'Microsoft.VisualBasic.Len(dgShip.Rows(e.RowIndex).Cells("ShipNotes").Value) = 0 Then

                Dim SwShipVia As String = ""
                SwShipVia = CallClass.ReturnStrWithParInt("cspReturnCustShipVia", CmbCust.SelectedValue)
                If SwShipVia = "False" Then
                    Exit Sub
                Else
                    dgShip.Rows(e.RowIndex).Cells("ShipNotes").Value = SwShipVia
                End If
            End If
        End If

    End Sub

    Private Sub dgShip_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgShip.DataError
        REM end
    End Sub

    Private Sub CmdShipNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdShipNew.Click
        frmCustShippingAddress.ShowDialog()
    End Sub

    Private Sub CmdInvNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdInvNew.Click
        frmCustInvoiceAddress.ShowDialog()
    End Sub

    Private Sub CmdCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCust.GotFocus
        'PutCust()
    End Sub

    Private Sub CmbCust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.Click
        'SwIdCust.Text = CmbCust.SelectedItem("CustomerID")
        'PutCust()
    End Sub

    Private Sub dgRev_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgRev.CellBeginEdit
        If ItemRow < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Or _
                Len(Trim(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value)) = 0 = True Then
            MsgBox("You cannot edit here without Order Item Number.")
            e.Cancel = True
        End If
    End Sub

    Private Sub dgRev_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellClick
        'dgRev.Refresh()

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        dgRev("OrdRevItem", e.RowIndex).ReadOnly = True

    End Sub

    Private Sub dgRev_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellEndEdit
        'dgRev.Refresh()
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 2 To 7
                dgRev.Rows(e.RowIndex).Cells("OrdRevItem").Value = dgItem.Rows(ItemRow).Cells("OrdItemNo").Value
        End Select
    End Sub

    Private Sub dgRev_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRev.DataError
        REM end
    End Sub

    Private Sub dgItem_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgItem.EditingControlShowing
        If TypeOf e.Control Is ComboBox Then
            Dim cbo As ComboBox = DirectCast(e.Control, ComboBox)
            cbo.DropDownHeight = 450
        End If
    End Sub

    Private Sub dgItem_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgItem.RowsRemoved

        For Each trw As DataRow In dsMain.Tables("tblCustOrderItem").Rows
            If trw.RowState = DataRowState.Deleted = True Then
                Dim reply As DialogResult
                reply = MsgBox("Delete Order Item ??? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.No Then
                    trw.RejectChanges()
                    dsMain.RejectChanges()
                    dgItem.Refresh()
                    dgDeliv.Refresh()
                    dgCross.Refresh()
                    dgShip.Refresh()
                    dgInv.Refresh()
                    dgRev.Refresh()
                    dgCerts.Refresh()
                End If
                Exit Sub
            End If
        Next

    End Sub

    Private Sub dgCerts_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgCerts.CellBeginEdit
        If ItemRow < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Or _
                Len(Trim(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value)) = 0 = True Then
            MsgBox("You cannot edit here without Order Item Number.")
            e.Cancel = True
        End If
    End Sub

    Private Sub dgCerts_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCerts.CellClick

        If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Or _
                        Len(Trim(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value)) = 0 = True Then
            MsgBox("You cannot edit here without Order Item Number.")
            Exit Sub
        End If

        'dgRev.Refresh()

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        dgCerts("OrdCertsItem", e.RowIndex).ReadOnly = True
    End Sub

    Private Sub dgCerts_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCerts.CellEndEdit
        'dgRev.Refresh()
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 2 To 6
                dgCerts.Rows(e.RowIndex).Cells("OrdCertsItem").Value = dgItem.Rows(ItemRow).Cells("OrdItemNo").Value
                dgCerts.Rows(e.RowIndex).Cells("OrdCertsStatus").Value = "Active"
        End Select
    End Sub

    Private Sub dgCerts_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgCerts.DataError
        REM end
    End Sub

    Private Sub dgPslipInv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPslipInv.DataError
        REM end
    End Sub

    Private Sub dgDeliv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDeliv.KeyDown

        If e.KeyCode = Keys.Delete Then
            If dgDeliv.ReadOnly = False Then
                If IsDBNull(dgDeliv.Rows(ItemDeliv).Cells("delivdate").Value) = True And _
                    IsDBNull(dgDeliv.Rows(ItemDeliv).Cells("delivqty").Value) = True And _
                    IsDBNull(dgDeliv.Rows(ItemDeliv).Cells("delivtype").Value) = True Then
                    If MessageBox.Show("Are you sure you want to delete the selected record(s)?", _
                    "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                    MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub CmbCust_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.DropDownClosed

        TakeSalesRepPer()
        SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

        Dim ParRet As String = ""
        ParRet = CallClass.ReturnStrWithParInt("cspReturnCustomerM3Code", SwIdCust.Text)
        If ParRet = "False" Then
            MsgBox("!!! ERROR !!!  Missing the M3 Customer Code. Please contact Accounting Department.")

            OrderCurrency.EndCurrentEdit()
            ItemCurrency.EndCurrentEdit()
            DelivCurrency.EndCurrentEdit()
            InvCurrency.EndCurrentEdit()
            ShipCurrency.EndCurrentEdit()
            RevCurrency.EndCurrentEdit()
            CertsCurrency.EndCurrentEdit()

            dsMain.RejectChanges()
            DisableFields()
            FirstTimeMenuButtons()

            CmbOrder.Enabled = True
            CmbOrder.SelectedIndex = -1

            SwOper = ""

            SwNew = False

        End If

        ParRet = CallClass.ReturnStrWithParInt("cspReturnCustomerShortName", SwIdCust.Text)
        SwCustShort.Text = ParRet
    End Sub

    Sub TakeSalesRepPer()

        If Val(txtPer.Text) = 0 Then
            Dim swComm As String
            swComm = Nz.Nz(CmbCust.SelectedItem("SalesRepPer"))

            If Val(swComm) > 0 Then
                LblPer.Visible = True
                txtPer.Visible = True
                txtPer.Text = swComm
            Else
                LblPer.Visible = False
                txtPer.Visible = False
                txtPer.Text = ""
            End If
        Else
            LblPer.Visible = True
            txtPer.Visible = True
        End If

    End Sub

    Private Sub txtPONumber_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPONumber.Validated
        If SwNew = True Then

            Dim SwStatus As String = ""
            SwStatus = CallClass.ReturnInfoWithParString("cspReturnCustPONumber", txtPONumber.Text)
            If SwStatus = txtPONumber.Text Then
                MsgBox("!!! ATTENTION !!!  The Customer Order Number: " + txtPONumber.Text + " is already in the system.")
            End If

        End If
    End Sub

    Private Sub CmbOrder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbOrder.SelectedIndexChanged

        If SwOper = "Save" Then
            Exit Sub
        End If

        SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

        Me.BindingContext(dsMain, "tblCustOrder").Position = CType(CmbOrder.SelectedIndex, String)

        SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

        BindComponents()

        SwIdCust.Text = CmbCust.SelectedItem("CustomerID")

        Dim ParRet As String = ""
        ParRet = CallClass.ReturnStrWithParInt("cspReturnCustomerShortName", SwIdCust.Text)
        SwCustShort.Text = ParRet

        CalculGrid()
        TakeSalesRepPer()

        CmbM3BillCust.SelectedIndex = -1

    End Sub

    Private Sub CmbM3BillCust_DropDownClosed(sender As Object, e As System.EventArgs) Handles CmbM3BillCust.DropDownClosed

        If SwCustShort.Text <> "LNA-SpotPOs" Then
            MsgBox("!!! ACTION DENIED !!!  This function is applicable only for LNA Spot POs.")
            CmbM3BillCust.SelectedIndex = -1
        Else
            SwM3CustCode.Text = CmbM3BillCust.SelectedItem("InvCodeM3")
        End If

    End Sub

    Private Sub dgCross_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)

        If ItemRow < 0 Then
            Exit Sub
        End If

        ItemCross = e.RowIndex

        If Nz.Nz(dgCross.Rows(ItemCross).Cells("CrossMasterID").Value) = 0 Or _
                Len(Trim(dgCross.Rows(ItemCross).Cells("CrossMasterID").Value)) = 0 = True Then
            MsgBox("You cannot edit here without Cross Part Number.")
            e.Cancel = True
        End If

    End Sub

    Private Sub dgCross_CellClick(sender As Object, e As DataGridViewCellEventArgs)


        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemCross = e.RowIndex

        If dgCross.ReadOnly = True Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 2 To 5

                If ItemRow >= 0 Then
                    If IsDBNull(dgItem.Rows(ItemRow).Cells("OrdItemNo").Value) = True Then
                        MsgBox("You cannot edit here without Order Item Numer.")
                    Else
                        dgCross("CrossItemNo", e.RowIndex).ReadOnly = True
                        dgCross("CrossMasterID", e.RowIndex).ReadOnly = True

                        dgCross("CrossApproved", e.RowIndex).ReadOnly = False
                        dgCross("CrossNotes", e.RowIndex).ReadOnly = False
                    End If
                End If

                If IsDBNull(Me.dgCross("CrossApproved", e.RowIndex).Value) = False And dgCross("CrossApproved", e.RowIndex).ReadOnly = False Then
                    If dgCross.Rows(e.RowIndex).Cells("CrossApproved").Value = "InActive" Then
                        MsgBox("P/N Cross Referance Status = InActive  -  Readonly")
                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to Reset P/N Cross Referance Status ? ", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            dgCross.Rows(e.RowIndex).Cells("CrossApproved").Value = "Active"
                        End If
                    End If
                End If

        End Select

    End Sub

    Private Sub dgCross_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)

        If dsMain.HasChanges(DataRowState.Added) Then
            dgItem.Refresh()
            dgCross.Refresh()
        End If

    End Sub

    Private Sub dgCross_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        ItemCross = e.RowIndex

    End Sub

    Private Sub dgCross_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        REM end
    End Sub

    Private Sub dgCross_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)

        If IsDBNull(Me.dgCross("CrossApproved", e.RowIndex).Value) = False Then
            If dgCross.Rows(e.RowIndex).Cells("CrossApproved").Value = "InActive" Then
                dgCross.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgCross.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If

    End Sub

    Private Sub frmOrderEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize


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