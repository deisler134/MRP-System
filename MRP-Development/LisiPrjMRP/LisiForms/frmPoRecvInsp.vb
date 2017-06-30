Option Strict Off
Option Explicit On

Imports System.Text
Imports System.IO
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmPoRecvInsp

    Inherits System.Windows.Forms.Form
   
    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Private dsAlusta As New DataSet

    Private daRecv As New SqlDataAdapter
    Private daRecvDoc As New SqlDataAdapter
    Private daReq As New SqlDataAdapter
   
    Dim RecvCurrency As CurrencyManager
    Dim RecvDocCurrency As CurrencyManager
    Dim ReqCurrency As CurrencyManager

    Dim CallClass As New clsCommon
    Dim poc As New PORecClass

    Dim SwPrint As Boolean = False
    Dim SwVal As Boolean
    Dim poNum As String = ""
    Dim flgGo As Boolean = False
    Dim RowPo As Integer = 0        'dgrecv
    Dim RowDoc As Integer = 0       'dgrecvdoc
    Dim KeepNo As Integer = 0
    Dim updflg As Boolean
    Dim SwCheckMat As Integer = 0   ' 9 is true

    Dim SwSave As Boolean = True
    Dim SwNoMessage As Boolean = False

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""

    Private Sub frmPoRecvInsp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        'RecvCurrency.EndCurrentEdit()
        'RecvDocCurrency.EndCurrentEdit()
        'ReqCurrency.EndCurrentEdit()
       
        'If dsMain.HasChanges Then
        '    reply = MsgBox("The change you made has not been saved to the database. Action Denied.")
        '    'If reply = DialogResult.No Then e.Cancel = True
        '    'Exit Sub
        '    e.Cancel = True
        'Else
        '    dsMain.RejectChanges()
        '    dsMain.Dispose()
        '    daRecv.Dispose()
        '    daRecvDoc.Dispose()
        '    daReq.Dispose()
        '    Me.Dispose()
        'End If

        If SwSave = False Then
            reply = MsgBox("The change you made has not been saved to the database. Action Denied.")
            'If reply = DialogResult.No Then e.Cancel = True
            'Exit Sub
            e.Cancel = True
        Else
            dsMain.RejectChanges()
            dsMain.Dispose()
            daRecv.Dispose()
            daRecvDoc.Dispose()
            daReq.Dispose()
            Me.Dispose()

            dsAlusta.Dispose()

            GC.Collect()

        End If

    End Sub

    Private Sub frmPoRecvInsp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1705 And Height > 900 Then
            Me.Width = 1705
            Me.Height = 900
        Else
            If Width < 1705 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height


        cmbDevise.Enabled = False

        SwPrint = False

        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        PutDevise()
        PutSupplier()
        PutUser()

        SetCtlForm()

        BindComponents()

        dgRecv.AutoGenerateColumns = False
        dgRecv.DataSource = dsMain
        dgRecv.DataMember = "tblPOReceiving"

        dgRecvDoc.AutoGenerateColumns = False
        dgRecvDoc.DataSource = dsMain
        dgRecvDoc.DataMember = "tblPOReceiving.RecvDoc"

        dgReq.AutoGenerateColumns = False
        dgReq.DataSource = dsMain
        dgReq.DataMember = "tblPOReceiving.RecvDoc.DocRes"

        PutFirstOpen()

    End Sub

    Sub PutFirstOpen()

        FindPO.ReadOnly = False
        FindPO.Focus()
        txtPrint.Text = ""

        CmdGen.Text = "Generate Lisi Matl Lot Number"

        CmdSearch.Enabled = True

    End Sub
    Private Function BuildSqlCommand() As Boolean
        daRecv = CallClass.PopulateDataAdapter("gettblPoReceiving")
        daRecvDoc = CallClass.PopulateDataAdapter("gettblPoReceivingDOC")
        daReq = CallClass.PopulateDataAdapter("gettblPoReceivingResults")
      
        Dim RecvBuilder As New SqlClient.SqlCommandBuilder(daRecv)
        Dim RecvDocBuilder As New SqlClient.SqlCommandBuilder(daRecvDoc)
        Dim ReqBuilder As New SqlClient.SqlCommandBuilder(daReq)

        daRecv.UpdateCommand = RecvBuilder.GetUpdateCommand
        daRecv.UpdateCommand.Connection = cn
        daRecv.InsertCommand = RecvBuilder.GetInsertCommand
        AddHandler daRecv.RowUpdated, AddressOf HandleRowUpdatedRecv
        daRecv.InsertCommand.Connection = cn
        daRecv.DeleteCommand = RecvBuilder.GetDeleteCommand
        daRecv.DeleteCommand.Connection = cn
        daRecv.AcceptChangesDuringFill = True
        daRecv.TableMappings.Add("Table", "tblPoReceiving")
        daRecv.MissingSchemaAction = MissingSchemaAction.AddWithKey

        daRecvDoc.UpdateCommand = RecvDocBuilder.GetUpdateCommand
        daRecvDoc.UpdateCommand.Connection = cn
        daRecvDoc.InsertCommand = RecvDocBuilder.GetInsertCommand
        AddHandler daRecvDoc.RowUpdated, AddressOf HandleRowUpdatedDoc
        daRecvDoc.InsertCommand.Connection = cn
        daRecvDoc.DeleteCommand = RecvDocBuilder.GetDeleteCommand
        daRecvDoc.DeleteCommand.Connection = cn
        daRecvDoc.AcceptChangesDuringFill = True
        daRecvDoc.TableMappings.Add("Table", "tblPoReceivingDoc")
        daRecvDoc.MissingSchemaAction = MissingSchemaAction.AddWithKey

        daReq.UpdateCommand = ReqBuilder.GetUpdateCommand
        daReq.UpdateCommand.Connection = cn
        daReq.InsertCommand = ReqBuilder.GetInsertCommand
        AddHandler daReq.RowUpdated, AddressOf HandleRowUpdatedReq
        daReq.InsertCommand.Connection = cn
        daReq.DeleteCommand = ReqBuilder.GetDeleteCommand
        daReq.DeleteCommand.Connection = cn
        daReq.AcceptChangesDuringFill = True
        daReq.TableMappings.Add("Table", "tblPoReceivingResults")
        daReq.MissingSchemaAction = MissingSchemaAction.AddWithKey

    End Function

    Private Sub HandleRowUpdatedRecv(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPoReceiving").Columns("PORecvID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedDoc(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPoReceivingDoc").Columns("RecvIDDoc")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedReq(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPoReceivingResults").Columns("RecvResID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daRecv.FillSchema(dsMain, SchemaType.Source, "tblPOReceiving")
        daRecvDoc.FillSchema(dsMain, SchemaType.Source, "tblPOReceivingDoc")
        daReq.FillSchema(dsMain, SchemaType.Source, "tblPoReceivingResults")

        daRecv.Fill(dsMain, "tblPOReceiving")
        Dim RecvID As DataColumn = dsMain.Tables("tblPOReceiving").Columns("PORecvID")
        RecvID.AutoIncrement = True
        RecvID.AutoIncrementStep = -1
        RecvID.AutoIncrementSeed = -1
        RecvID.ReadOnly = False

        daRecvDoc.Fill(dsMain, "tblPOReceivingDoc")
        Dim DocID As DataColumn = dsMain.Tables("tblPOReceivingDoc").Columns("RecvIDDoc")
        DocID.AutoIncrement = True
        DocID.AutoIncrementStep = -1
        DocID.AutoIncrementSeed = -1
        DocID.ReadOnly = False

        daReq.Fill(dsMain, "tblPoReceivingResults")
        Dim ResID As DataColumn = dsMain.Tables("tblPoReceivingResults").Columns("RecvResID")
        ResID.AutoIncrement = True
        ResID.AutoIncrementStep = -1
        ResID.AutoIncrementSeed = -1
        ResID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("RecvDoc", _
                .Tables("tblPOReceiving").Columns("PORecvID"), _
                .Tables("tblPOReceivingDoc").Columns("PORecvID"), True)
        End With

        With dsMain
            .Relations.Add("DocRes", _
                .Tables("tblPOReceivingDoc").Columns("RecvIDDoc"), _
                .Tables("tblPoReceivingResults").Columns("RecvIDDoc"), True)
        End With

        RecvCurrency = CType(BindingContext(dsMain, "tblPOReceiving"), CurrencyManager)
        RecvDocCurrency = CType(BindingContext(dsMain, "tblPOReceivingDoc"), CurrencyManager)
        ReqCurrency = CType(BindingContext(dsMain, "tblPoReceivingResults"), CurrencyManager)


        '=========================
        dsAlusta.Clear()
        dsAlusta.Relations.Clear()

        CallClass.PopulateDataAdapter("getPOUpload_IntoAlustaEmpty").Fill(dsAlusta, "tblSelect")

        dsAlusta.EnforceConstraints = False

        dgAlusta.AutoGenerateColumns = False
        dgAlusta.DataSource = dsAlusta
        dgAlusta.DataMember = "tblSelect"


    End Sub

    Sub PutDevise()
        With Me.cmbDevise
            .DataSource = CallClass.PopulateComboBox("tblSalesTax", "cmbGetDevise").Tables("tblSalesTax")
            .DisplayMember = "DolarSign"
            .ValueMember = "SalesTaxID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutSupplier()
        With Me.CmbSupp
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutUser()
        With Me.cmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub SetCtlForm()

        'combo boxes

        'For dgRecv properies

        With Me.PORecvIDRecv
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            ' .Visible = False
        End With

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            ' .Visible = False
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
            .ReadOnly = True
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
            .ReadOnly = True
        End With

        With Me.PSlipDate
            .DataPropertyName = "PSlipDate"
            .Name = "PSlipDate"
            .ReadOnly = True
        End With

        With Me.PslipQty
            .DataPropertyName = "PSlipQty"
            .Name = "PSlipQty"
            .ReadOnly = True
        End With

        With Me.PSlipUM     'it is a combobox
            .DataSource = CallClass.PopulateComboBox("tblUM", "cmbGetUM").Tables("tblUM")
            .DisplayMember = "IDum"
            .ValueMember = "IDum"
            .DataPropertyName = "PSlipUM"
            .Name = "PSlipUM"
            .ReadOnly = True
        End With

        With Me.PSlipPrice
            .DataPropertyName = "PSlipPrice"
            .Name = "PSlipPrice"
            .ReadOnly = True
        End With

        With Me.PORmsPrice
            .DataPropertyName = "PORmsPrice"
            .Name = "PORmsPrice"
            .ReadOnly = True
        End With

        With Me.PSlipDiscount
            .DataPropertyName = "PSlipDiscount"
            .Name = "PSlipDiscount"
            .ReadOnly = True
        End With

        With Me.AccpToPay
            .DataPropertyName = "AccpToPay"
            .Name = "AccpToPay"
            .ReadOnly = True
        End With

        'With Me.ApprRecvToPay
        '    .DataPropertyName = "ApprRecvToPay"
        '    .Name = "ApprRecvToPay"
        '    .visible = False
        'End With

        With Me.RecvValue
            .DataPropertyName = "RecvValue"
            .Name = "RecvValue"
            .ReadOnly = True
        End With

        'For dgRecvDoc properies

        With Me.RecvIDDoc
            .DataPropertyName = "RecvIDDoc"
            .Name = "RecvIDDoc"
            .Visible = False
        End With

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With

        With Me.Item
            .DataPropertyName = "Item"
            .Name = "Item"
            .ReadOnly = True
        End With

        With Me.DocRecvNo
            .DataPropertyName = "DocRecvNo"
            .Name = "DocRecvNo"
            .ReadOnly = True
        End With

        With Me.RecvApprDate
            .DataPropertyName = "RecvApprDate"
            .Name = "RecvApprDate"
        End With

        With Me.RecvCertNo
            .DataPropertyName = "RecvCertNo"
            .Name = "RecvCertNo"
        End With

        PutMillProd()

        PutStockLoc()

        With Me.RecvMatlType
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "RecvMatlType"
            .Name = "RecvMatlType"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

        With Me.RecvMatlDetID
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "RecvMatlDetID"
            .Name = "RecvMatlDetID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlInsideDIA
            .DataPropertyName = "RecvMatlInsideDIA"
            .Name = "RecvMatlInsideDIA"
        End With

        With Me.RecvMatlLength
            .DataPropertyName = "RecvMatlLength"
            .Name = "RecvMatlLength"
        End With

        With Me.RecvMatlHeat
            .DataPropertyName = "RecvMatlHeat"
            .Name = "RecvMatlHeat"
        End With

        With Me.RecvMatlWeight
            .DataPropertyName = "RecvMatlWeight"
            .Name = "RecvMatlWeight"
        End With

        With Me.RecvMatlCond
            .DataPropertyName = "RecvMatlCond"
            .Name = "RecvMatlCond"
        End With

        With Me.RecvMatlBars
            .DataPropertyName = "RecvMatlBars"
            .Name = "RecvMatlBars"
        End With

        With Me.RecvMatlTube
            .DataPropertyName = "RecvMatlTube"
            .Name = "RecvMatlTube"
        End With

        With Me.RecvMatlSheetMetal
            .DataPropertyName = "RecvMatlSheetMetal"
            .Name = "RecvMatlSheetMetal"
        End With

        With Me.RecvMatlCoils
            .DataPropertyName = "RecvMatlCoils"
            .Name = "RecvMatlCoils"
        End With

        With Me.RecvMatlHex
            .DataPropertyName = "RecvMatlHex"
            .Name = "RecvMatlHex"
        End With

        With Me.RecvChYes
            .DataPropertyName = "RecvChYes"
            .Name = "RecvChYes"
        End With

        With Me.RecvChNo
            .DataPropertyName = "RecvChNo"
            .Name = "RecvChNo"
        End With

        With Me.RecvHoldMatl
            .DataPropertyName = "RecvHoldMatl"
            .Name = "RecvHoldMatl"
        End With

        With Me.RecvRejectMatl
            .DataPropertyName = "RecvRejectMatl"
            .Name = "RecvRejectMatl"
        End With

        With Me.RecvMillID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierMill").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvMillID"
            .Name = "RecvMillID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvRedrawID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierRedraw").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvRedrawID"
            .Name = "RecvRedrawID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvDistrID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierDistr").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvDistrID"
            .Name = "RecvDistrID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvPoItemsNotes
            .DataPropertyName = "RecvPoItemsNotes"
            .Name = "RecvPoItemsNotes"
            .Visible = False
        End With

        With Me.RecvQANotes
            .DataPropertyName = "RecvQANotes"
            .Name = "RecvQANotes"
        End With

        With Me.RecvLocCerts
            .DataPropertyName = "RecvLocCerts"
            .Name = "RecvLocCerts"
        End With

        With Me.RecvForStock
            .DataPropertyName = "RecvForStock"
            .Name = "RecvForStock"
        End With

        With Me.RecvForOrders
            .DataPropertyName = "RecvForOrders"
            .Name = "RecvForOrders"
        End With

        With Me.RecvMatlNotes
            .DataPropertyName = "RecvMatlNotes"
            .Name = "RecvMatlNotes"
        End With

        'For dgReq properies

        With Me.RecvResID
            .DataPropertyName = "RecvResID"
            .Name = "RecvResID"
            .Visible = False
        End With

        With Me.RecvIDDocReq
            .DataPropertyName = "RecvIDDoc"
            .Name = "RecvIDDoc"
            .Visible = False
        End With

        PutReqList()

        With Me.ResSuppCert
            .DataPropertyName = "ResSuppCert"
            .Name = "ResSuppCert"
        End With

        With Me.ResLisiResult
            .DataPropertyName = "ResLisiResult"
            .Name = "ResLisiResult"
        End With

        ' LACDATA 
        With Me.LACDATA
            .DataPropertyName = "LACDATA"
            .Name = "LACDATA"
        End With

        With Me.ENTPONo
            .DataPropertyName = "ENTPONo"
            .Name = "ENTPONo"
            .Visible = False
        End With

        With Me.ENTLAC
            .DataPropertyName = "ENTLAC"
            .Name = "ENTLAC"
            .Visible = False
        End With
        With Me.ENTDOR
            .DataPropertyName = "ENTDOR"
            .Name = "ENTDOR"
            .Visible = False
        End With
        With Me.ENTSUPP
            .DataPropertyName = "ENTSUPP"
            .Name = "ENTSUPP"
            .Visible = False
        End With
        With Me.ENTDEVISE
            .DataPropertyName = "ENTDEVISE"
            .Name = "ENTDEVISE"
            .Visible = False
        End With
        With Me.ENTCODETAXE
            .DataPropertyName = "ENTCODETAXE"
            .Name = "ENTCODETAXE"
            .Visible = False
        End With
        With Me.SwENTHT
            .DataPropertyName = "SwENTHT"
            .Name = "SwENTHT"
            .Visible = False
        End With
        With Me.ENTTTC
            .DataPropertyName = "ENTTTC"
            .Name = "ENTTTC"
            .Visible = False
        End With
        With Me.ENTRequester
            .DataPropertyName = "ENTRequester"
            .Name = "ENTRequester"
            .Visible = False
        End With
        With Me.ENTBuyer
            .DataPropertyName = "ENTBuyer"
            .Name = "ENTBuyer"
            .Visible = False
        End With
        With Me.ENTPOStatus
            .DataPropertyName = "ENTPOStatus"
            .Name = "ENTPOStatus"
            .Visible = False
        End With
        With Me.ENTPODate
            .DataPropertyName = "ENTPODate"
            .Name = "ENTPODate"
            .Visible = False
        End With
        With Me.ENTPOModDate
            .DataPropertyName = "ENTPOModDate"
            .Name = "ENTPOModDate"
            .Visible = False
        End With
        With Me.LINPONo
            .DataPropertyName = "LINPONo"
            .Name = "LINPONo"
            .Visible = False
        End With
        With Me.LINPOType
            .DataPropertyName = "LINPOType"
            .Name = "LINPOType"
            .Visible = False
        End With
        With Me.LINPOItem
            .DataPropertyName = "LINPOItem"
            .Name = "LINPOItem"
            .Visible = False
        End With
        With Me.LINPOQty
            .DataPropertyName = "LINPOQty"
            .Name = "LINPOQty"
            .Visible = False
        End With
        With Me.LINPOUM
            .DataPropertyName = "LINPOUM"
            .Name = "LINPOUM"
            .Visible = False
        End With
        With Me.LINTotalPrice
            .DataPropertyName = "LINTotalPrice"
            .Name = "LINTotalPrice"
            .Visible = False
        End With
        With Me.LINTotPriceConf
            .DataPropertyName = "LINTotPriceConf"
            .Name = "LINTotPriceConf"
            .Visible = False
        End With
        With Me.LINHT
            .DataPropertyName = "LINHT"
            .Name = "LINHT"
            .Visible = False
        End With
        With Me.LINRemise
            .DataPropertyName = "LINRemise"
            .Name = "LINRemise"
            .Visible = False
        End With
        With Me.LINProdID
            .DataPropertyName = "LINProdID"
            .Name = "LINProdID"
            .Visible = False
        End With
        With Me.LINProdDescr
            .DataPropertyName = "LINProdDescr"
            .Name = "LINProdDescr"
            .Visible = False
        End With
        With Me.LINGLCode
            .DataPropertyName = "LINGLCode"
            .Name = "LINGLCode"
            .Visible = False
        End With
        With Me.LINEtablissement
            .DataPropertyName = "LINEtablissement"
            .Name = "LINEtablissement"
            .Visible = False
        End With
        With Me.LINSUPP
            .DataPropertyName = "LINSUPP"
            .Name = "LINSUPP"
            .Visible = False
        End With
        With Me.LINCostCenter
            .DataPropertyName = "LINCostCenter"
            .Name = "LINCostCenter"
            .Visible = False
        End With
        With Me.LINFamille
            .DataPropertyName = "LINFamille"
            .Name = "LINFamille"
            .Visible = False
        End With
        With Me.LINCommande
            .DataPropertyName = "LINCommande"
            .Name = "LINCommande"
            .Visible = False
        End With
        With Me.LINCapexNo
            .DataPropertyName = "LINCapexNo"
            .Name = "LINCapexNo"
            .Visible = False
        End With
        With Me.LINCapexDescr
            .DataPropertyName = "LINCapexDescr"
            .Name = "LINCapexDescr"
            .Visible = False
        End With
        With Me.LINStatus
            .DataPropertyName = "LINStatus"
            .Name = "LINStatus"
            .Visible = False
        End With
        With Me.LINSolde
            .DataPropertyName = "LINSolde"
            .Name = "LINSolde"
            .Visible = False
        End With
        With Me.RECPONo
            .DataPropertyName = "RECPONo"
            .Name = "RECPONo"
            .Visible = False
        End With
        With Me.RECLine
            .DataPropertyName = "RECLine"
            .Name = "RECLine"
            .Visible = False
        End With
        With Me.RECNo
            .DataPropertyName = "RECNo"
            .Name = "RECNo"
            .Visible = False
        End With
        With Me.RECQty
            .DataPropertyName = "RECQty"
            .Name = "RECQty"
            .Visible = False
        End With
        With Me.RECNET
            .DataPropertyName = "RECNET"
            .Name = "RECNET"
            .Visible = False
        End With
        With Me.ARECDate
            .DataPropertyName = "ARECDate"
            .Name = "ARECDate"
            .Visible = False
        End With
        With Me.RECBarCode
            .DataPropertyName = "RECBarCode"
            .Name = "RECBarCode"
            .Visible = False
        End With
        With Me.RECSTATUS
            .DataPropertyName = "RECSTATUS"
            .Name = "RECSTATUS"
            .Visible = False
        End With

        With Me.ADocRecvNo
            .DataPropertyName = "ADocRecvNo"
            .Name = "ADocRecvNo"
            .Visible = False
        End With

        With Me.ARecvMatlWeight
            .DataPropertyName = "ARecvMatlWeight"
            .Name = "ARecvMatlWeight"
            .Visible = False
        End With

        With Me.ARecQtyAccp
            .DataPropertyName = "ARecQtyAccp"
            .Name = "ARecQtyAccp"
            .Visible = False
        End With

        With Me.AAccpToPay
            .DataPropertyName = "AAccpToPay"
            .Name = "AAccpToPay"
            .Visible = False
        End With
        With Me.AApprInsp
            .DataPropertyName = "AApprInsp"
            .Name = "AApprInsp"
            .Visible = False
        End With
        With Me.AApprRecvToPay
            .DataPropertyName = "AApprRecvToPay"
            .Name = "AApprRecvToPay"
            .Visible = False
        End With
        With Me.APayInvDate
            .DataPropertyName = "APayInvDate"
            .Name = "APayInvDate"
            .Visible = False
        End With

       


    End Sub

    Sub PutReqList()

        With Me.ReqID
            .DataSource = CallClass.PopulateComboBox("tblRequirementsList", "cmbGetRequirements").Tables("tblRequirementsList")
            .DisplayMember = "ReqName"
            .ValueMember = "ReqID"
            .DataPropertyName = "ReqID"
            .Name = "ReqID"
        End With

    End Sub

    Sub PutMillProd()

        With Me.RecvMatlMfg
            .DataSource = CallClass.PopulateComboBox("tblApprMillList", "cmbGetApprMillList").Tables("tblApprMillList")
            .DisplayMember = "MillName"
            .ValueMember = "MillID"
            .DataPropertyName = "RecvMatlMfg"
            .Name = "RecvMatlMfg"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

    End Sub

    Sub PutStockLoc()

        With Me.RecvMatlLoc
            .DataSource = CallClass.PopulateComboBox("tblStockLoc", "cmbGetStockLoc").Tables("tblStockLoc")
            .DisplayMember = "StLocID"
            .ValueMember = "StLocID"
            .DataPropertyName = "RecvMatlLoc"
            .Name = "RecvMatlLoc"
            .DropDownWidth = 100
            .MaxDropDownItems = 50
        End With

    End Sub

    Sub DisableFields()

        txtPrint.ReadOnly = True
        cmdPrint.Enabled = False

        lblQtyInsp.Visible = False
        txtQtyInsp.Visible = False

        txtQtyInsp.Text = ""
        txtQtyInsp.ReadOnly = True

        txtDocNo.ReadOnly = True
        txtDocNo.Text = ""

        cmbPOStatus.Enabled = False
        cmbPOType.Enabled = False
        cmbUser.Enabled = False
        CmbSupp.Enabled = False

        txtItemsNotes.ReadOnly = True
        'txtQANotes.ReadOnly = True

        dgRecv.ReadOnly = True
        dgRecvDoc.ReadOnly = True
        dgReq.ReadOnly = True

        dgRecv.Visible = False
        dgRecvDoc.Visible = False
        dgReq.Visible = False

        PanelNotes.Visible = False

        CmdReset.Enabled = True
        CmdGen.Enabled = False
        CmdSave.Enabled = False

    End Sub

    Sub EnableFields()

        lblQtyInsp.Visible = True
        txtQtyInsp.Visible = True

        txtItemsNotes.ReadOnly = True
        'txtQANotes.ReadOnly = False

        CmdSave.Enabled = True
        CmdReset.Enabled = True

        dgRecv.ReadOnly = False
        dgRecvDoc.ReadOnly = False
        dgReq.ReadOnly = False

        dgRecv.Enabled = True
        dgRecvDoc.Enabled = True
        dgReq.Enabled = True

        dgRecv.Visible = True
        dgRecvDoc.Visible = True
        dgReq.Visible = True

        PanelNotes.Visible = True

    End Sub

    Sub FirstTimeMenuButtons()
        CmdReset.Enabled = True
        CmdSave.Enabled = False
        CmdGen.Enabled = False
        CmdSearch.Enabled = True

        FindPO.Text = ""
        FindPO.ReadOnly = True
        txtPrint.Text = ""
        txtPrint.ReadOnly = True

    End Sub

    Private Sub FindPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FindPO.KeyDown

        If e.KeyCode = Keys.Enter Then
            poNum = FindPO.Text
            FindPO.ReadOnly = True

            VerifyPoStatus()
            If flgGo = True Then
                Call Populate_Recv_RecvDoc()
                CmdReset.Enabled = False

                SwNoMessage = True      'put message
                '========================
                SpecialSituation()
                '========================

            End If
        End If

        CmdSearch.Enabled = False

        dsAlusta.Clear()

    End Sub

    Private Sub txtPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrint.KeyDown
        If e.KeyCode = Keys.Enter Then
            FindPO.Text = CallClass.ReturnInfoWithParString("cspReturnPOByRMLot", txtPrint.Text)
            poNum = FindPO.Text
            FindPO.ReadOnly = True
            txtPrint.ReadOnly = True

            VerifyPoStatus()
            If flgGo = True Then
                Call Populate_LotNo()
                CmdReset.Enabled = False

                SwNoMessage = True      'put message
                '========================
                SpecialSituation()
                '========================

                dsAlusta.Clear()

            End If
        End If

    End Sub

    Sub VerifyPoStatus()
        Dim ds As New DataSet

        ds = CallClass.SearchByString(poNum, "cspGetPOStatus")

        cmbPOStatus.DataBindings.Clear()
        cmbPOStatus.Text = ""

        cmbPOType.DataBindings.Clear()
        cmbPOType.Text = ""

        cmbUser.DataBindings.Clear()
        CmbSupp.DataBindings.Clear()
        cmbDevise.DataBindings.Clear()

        PutDevise()
        PutSupplier()
        PutUser()

        cmbUser.SelectedValue = wkEmpId

        cmbPOStatus.DataBindings.Add("SelectedText", ds, "tblTableSearch.POStatus")
        CmbSupp.DataBindings.Add("SelectedValue", ds, "tblTableSearch.POSuppID")
        cmbPOType.DataBindings.Add("SelectedText", ds, "tblTableSearch.POType")
        cmbDevise.DataBindings.Add("SelectedValue", ds, "tblTableSearch.PoDevise")

        flgGo = False

        Select Case (cmbPOStatus.Text)
            Case "Cancelled"
                MsgBox("This PO has been cancelled.")
                Call DisableFields()
            Case "Accepted"
                MsgBox("This PO has already been accepted.")

                SwCheckMat = 11     'send from po status check

                flgGo = True
                EnableFields()

                'Call DisableFields()
                'dgRecv.Visible = True
                'dgRecvDoc.Visible = True
                'dgReq.Visible = True
                'PanelNotes.Visible = True

            Case "Payed"
                MsgBox("This PO has already been payed.")
                Call DisableFields()
                CmdSave.Enabled = True
                CmdReset.Enabled = True
                flgGo = True
                dgRecv.Visible = True
                dgRecvDoc.Visible = True
                dgReq.Visible = True

                PanelNotes.Visible = True

            Case "AMMD"
                MsgBox("Please receive the items on the new Amendment.")
                Call DisableFields()
            Case "Open"
                If cmbPOType.Text <> "Raw Material" And cmbPOType.Text <> "Grinding" Then
                    MsgBox("You don't need a Receiving Inspection for this type of PO.")
                    Call DisableFields()
                Else   ' Raw Material & MS Access & Grinding
                    flgGo = True
                    EnableFields()
                End If
            Case Else
                MsgBox("!!! ERROR !!! PO Number or Missing Receiving information for this PO.")
                Call DisableFields()
                FindPO.Text = ""
        End Select

        ds.Dispose()

    End Sub

    Sub CheckReservationAndProduction()

        Dim strSearch As String
        Dim SwMatlReserv As String

        strSearch = dgRecvDoc("DocRecvNo", RowDoc).Value
        If IsNothing(strSearch) Then
            'MsgBox(" !!! ERROR !!! Missing Material Lot Number. Please call IT Technical Support.")
            SwCheckMat = 0
            Exit Sub
        End If
        SwMatlReserv = CallClass.TakeFinalSt("cspReturnMatlLotReservCount", strSearch)
        If Val(SwMatlReserv) > 0 Then
            If SwNoMessage = True Then
                MsgBox("Allready we have Reservation(s) on this Material Lot. Any updates for the received material lot are denied.")
            End If
            SwCheckMat = 9
        End If

        strSearch = dgRecvDoc("DocRecvNo", RowDoc).Value
        SwMatlReserv = CallClass.TakeFinalSt("cspReturnMatlLotProductionCount", strSearch)
        If Val(SwMatlReserv) > 0 Then
            If SwNoMessage = True Then
                MsgBox("Allready we have Released to production with this Material Lot. Any updates for the received material lot are denied.")
            End If
            SwCheckMat = 9
        End If

    End Sub

    Sub Populate_Recv_RecvDoc()

        dsMain.Tables("tblPOReceiving").Clear()
        daRecv = CallClass.PopulateDataAdapterAfterSearch("getTblPOReceivingvByPONO", poNum)

        daRecv.FillSchema(dsMain, SchemaType.Source, "tblPOReceiving")
        daRecv.Fill(dsMain, "tblPOReceiving")

        If dsMain.Tables("tblPOReceiving").Rows.Count = 0 Then
            MsgBox("!!! ERROR !!! PO Number or Missing Receiving information for this PO.")
            DisableFields()
        Else

            SetCtlForm()

            BindComponents()

            dgRecv.AutoGenerateColumns = False
            dgRecv.DataSource = dsMain
            dgRecv.DataMember = "tblPOReceiving"

            dgRecvDoc.AutoGenerateColumns = False
            dgRecvDoc.DataSource = dsMain
            dgRecvDoc.DataMember = "tblPOReceiving.RecvDoc"

            dgReq.AutoGenerateColumns = False
            dgReq.DataSource = dsMain
            dgReq.DataMember = "tblPOReceiving.RecvDoc.DocRes"

            Dim I As Integer
            For I = 0 To dgRecv.Rows.Count - 1
                Me.dgRecv("RecvValue", I).Value = _
                    Nz.Nz(dgRecv.Item("PSlipQty", I).Value) * _
                    Nz.Nz(dgRecv.Item("PSlipPrice", I).Value) * _
                    (1 - Nz.Nz(dgRecv.Item("PSlipDiscount", I).Value) / 100)

                dgRecv.Rows(I).ReadOnly = True
            Next

            dgRecv.Refresh()
            dgRecvDoc.Refresh()
            dgReq.Refresh()

            dgRecv.Rows(0).Selected = True

            CalculDgrecvDoc()

        End If

    End Sub

    Sub Populate_LotNo()

        'SwPrint = True

        dsMain.Tables("tblPOReceiving").Clear()
        daRecv = CallClass.PopulateDataAdapterAfterSearch("getTblPOReceivingvByPONO", poNum)

        daRecv.FillSchema(dsMain, SchemaType.Source, "tblPOReceiving")
        daRecv.Fill(dsMain, "tblPOReceiving")

        If dsMain.Tables("tblPOReceiving").Rows.Count = 0 Then
            MsgBox("!!! ERROR !!! PO Number or Missing Receiving information for this PO.")
            DisableFields()
        Else

            SetCtlForm()

            BindComponents()

            dgRecv.AutoGenerateColumns = False
            dgRecv.DataSource = dsMain
            dgRecv.DataMember = "tblPOReceiving"

            dgRecvDoc.AutoGenerateColumns = False
            dgRecvDoc.DataSource = dsMain
            dgRecvDoc.DataMember = "tblPOReceiving.RecvDoc"

            dgReq.AutoGenerateColumns = False
            dgReq.DataSource = dsMain
            dgReq.DataMember = "tblPOReceiving.RecvDoc.DocRes"

            Dim I As Integer
            For I = 0 To dgRecv.Rows.Count - 1
                Me.dgRecv("RecvValue", I).Value = _
                    Nz.Nz(dgRecv.Item("PSlipQty", I).Value) * _
                    Nz.Nz(dgRecv.Item("PSlipPrice", I).Value) * _
                    (1 - Nz.Nz(dgRecv.Item("PSlipDiscount", I).Value) / 100)

                dgRecv.Rows(I).ReadOnly = True
            Next

            dgRecv.Refresh()
            dgRecvDoc.Refresh()
            dgReq.Refresh()

            dgRecv.Rows(0).Selected = True

            CalculDgrecvDoc()

        End If

    End Sub

    Sub BindComponents()

        txtItemsNotes.DataBindings.Clear()
        txtQANotes.DataBindings.Clear()
        'lblFilePath.DataBindings.Clear()

        txtItemsNotes.DataBindings.Add("Text", dsMain, "tblPOReceiving.RecvDoc.RecvPoItemsNotes")
        txtQANotes.DataBindings.Add("Text", dsMain, "tblPOReceiving.RecvDoc.RecvQANotes")
        'lblFilePath.DataBindings.Add("Text", dsMain, "tblPOReceiving.RecvDoc.RecvLocCerts")

    End Sub

    Private Sub dgRecv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRecv.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPo = e.RowIndex

        CheckReservationAndProduction()

        dgRecv.Rows(e.RowIndex).ReadOnly = True


        If SwCheckMat = 9 Then
            Exit Sub
        End If

        If IsDBNull(dgRecv.Item("AccpToPay", e.RowIndex).Value) = False Then
            If dgRecv.Item("AccpToPay", e.RowIndex).Value = True Then
                VerQtyInspPerItem()
                If updflg = True Then
                    dgRecv.Item("AccpToPay", e.RowIndex).ReadOnly = True
                Else
                    dgRecv.Item("AccpToPay", e.RowIndex).ReadOnly = False
                End If
            Else
                dgRecv.Item("AccpToPay", e.RowIndex).ReadOnly = False
            End If
        End If

        dgRecv.Refresh()
        CalculDgrecvDoc()

    End Sub

    Sub UpdateNextLot()

        CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "MATLLOT", KeepNo)

    End Sub

    Private Sub dgRecv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRecv.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPo = e.RowIndex

    End Sub

    Private Sub dgRecv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRecv.DataError
        REM end
    End Sub

    Private Sub CmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdGen.Click

        Dim reply As DialogResult

        reply = MsgBox("Do you want to Generate a New Lisi Receiving Number ? ", MsgBoxStyle.YesNo)

        If reply = Windows.Forms.DialogResult.Yes Then

            txtDocNo.Text = CallClass.GenerateNextLot("cspGetNextLot", "MATLLOT")

            If txtDocNo.Text = "ERROR" Then
                Exit Sub
            Else

                KeepNo = Val(txtDocNo.Text)

                txtDocNo.Text = "M" + Trim(txtDocNo.Text)
                SwSave = False
            End If
        End If

    End Sub

    Sub TakeAction()

        txtDocNo.Text = ""

        Dim reply As DialogResult
        reply = MsgBox("The Lot Number will be generated. Do you want to Continue ? ", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            UpdateNextLot()
        End If

    End Sub

    Sub TakePoItemInfo()

        Dim swPOItem As String = ""
        swPOItem = dgRecv.Rows(rowPo).Cells("POItem").Value

        If Len(Trim(txtItemsNotes.Text)) = 0 Or IsDBNull(txtItemsNotes.Text) = True Then
            txtItemsNotes.Text = CallClass.FindPoItemInfo("cspGetPOItemInfo", FindPO.Text, swPOItem)
        Else
            txtItemsNotes.Text = txtItemsNotes.Text + vbCrLf + CallClass.FindPoItemInfo("cspGetPOItemInfo", FindPO.Text, swPOItem)
        End If

    End Sub

    Sub TakePoRemarks()

        If Len(Trim(txtItemsNotes.Text)) = 0 Or IsDBNull(txtItemsNotes.Text) = True Then
            txtItemsNotes.Text = CallClass.FindPoItemRemarks("cspGetPORemarks", FindPO.Text)
        Else
            txtItemsNotes.Text = txtItemsNotes.Text + vbCrLf + CallClass.FindPoItemRemarks("cspGetPORemarks", FindPO.Text)
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        SwPrint = False

        dgRecvDoc.EndEdit()
        'To change the current row, to the last row:
        Dim cellLastRow As DataGridViewCell = dgRecvDoc.Rows(dgRecvDoc.Rows.Count - 1).Cells(2)
        dgRecvDoc.CurrentCell = cellLastRow
        cellLastRow = dgRecvDoc.Rows(RowDoc).Cells(2)
        dgRecvDoc.CurrentCell = cellLastRow

        txtPrint.Focus()
        dgRecvDoc.Focus()
        txtPrint.Focus()
        dgReq.Focus()
        Me.Focus()
        dgRecv.Focus()
        txtPrint.Focus()

        Call ValPo()

        If SwVal = True Then

            VerQtyInspPerItem()

            RecvCurrency.EndCurrentEdit()
            RecvDocCurrency.EndCurrentEdit()
            ReqCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()

                    UpdateRecVdOC(dsMain.GetChanges)
                    daRecvDoc.Update(dsMain.Tables("tblPOReceivingDoc").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daReq.Update(dsMain.Tables("tblPOReceivingResults").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()
                Else
                    MsgBox("No Data to Save.")
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

            dgRecv.Refresh()
            dgRecvDoc.Refresh()
            dgReq.Refresh()

            DisableFields()
            FirstTimeMenuButtons()
            BindComponents()

            PutFirstOpen()

            SwSave = True
            'lblFilePath.Text = ""

            AlustaProcess()

        End If

    End Sub

    Sub AlustaProcess()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        dsAlusta.Clear()
        CallClass.PopulateDataAdapterAfterSearch("getPOUpload_IntoAlusta", FindPO.Text).Fill(dsAlusta, "tblSelect")

        Me.Refresh()

        If dgAlusta.RowCount <= 0 Then
            Exit Sub
        Else
            PutInfoAlusta()
        End If

    End Sub

    Public Sub UpdateRecvDoc(ByVal dsChanges As DataSet)

        Dim daAccp As SqlDataAdapter
        Dim cmdUpdAccp As SqlCommand
        cmdUpdAccp = New SqlCommand()
        cmdUpdAccp.Connection = cn
        cmdUpdAccp.CommandType = CommandType.StoredProcedure
        cmdUpdAccp.CommandText = "cspPoRecvAccp"

        ' Add Parameters to update accp for pay
        cmdUpdAccp.Parameters.Add("@PORecvID", SqlDbType.Int, 4, "PORecvID")
        cmdUpdAccp.Parameters.Add("@AccpToPay", SqlDbType.Bit, 1, "AccpToPay")

        daAccp = New SqlDataAdapter()
        daAccp.UpdateCommand = cmdUpdAccp
        daAccp.AcceptChangesDuringFill = True
        daAccp.TableMappings.Add("Table", "tblPOReceiving")
        daAccp.MissingSchemaAction = MissingSchemaAction.AddWithKey
        daAccp.Update(dsChanges)

    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgRecvDoc.Rows

            If IsDBNull(Row.Cells("DocRecvNo").Value) = True Then
                MsgBox("!!! ERROR !!! Lot Number is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvCertNo").Value) = True Then
                MsgBox("!!! ERROR !!! C.O.C. Number is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvApprDate").Value) = True Then
                MsgBox("!!! ERROR !!! Approved Date is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlLoc").Value) = True Then
                MsgBox("!!! ERROR !!! Stock Location Date is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlMfg").Value) = True Then
                MsgBox("!!! ERROR !!! Mill Producer is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlType").Value) = True Then
                MsgBox("!!! ERROR !!! Material .")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlDetID").Value) = True Then
                MsgBox("!!! ERROR !!! Material Type (KSI) is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlSize").Value) = True Then
                MsgBox("!!! ERROR !!! Material Size is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlTube").Value) = False And _
                IsDBNull(Row.Cells("RecvMatlInsideDIA").Value) = True Then
                MsgBox("!!! ERROR !!! Material type TUBE  AW is Empty.")
            End If

            If IsDBNull(Row.Cells("RecvMatlHeat").Value) = True Then
                MsgBox("!!! ERROR !!! Heat Number is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlCond").Value) = True Then
                MsgBox("!!! ERROR !!! Material Condition is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("RecvMatlWeight").Value) = True Then
                MsgBox("!!! ERROR !!! Material Weight is Empty.")
                SwVal = False
                Exit Sub
            End If


            'If Nz.Nz(Row.Cells("RecvMillID").Value) = 0 And _
            '    Nz.Nz(Row.Cells("RecvRedrawID").Value) = 0 And _
            '        Nz.Nz(Row.Cells("RecvDistrID").Value) = 0 Then
            '    MsgBox("!!! ERROR !!! Approved Material Source is Empty.")
            '    SwVal = False
            '    Exit Sub
            'End If

            If IsDBNull(Row.Cells("RecvMatlBars").Value) = True And _
                 IsDBNull(Row.Cells("RecvMatlCoils").Value) = True And _
                 IsDBNull(Row.Cells("RecvMatlHex").Value) = True And _
                 IsDBNull(Row.Cells("RecvMatlTube").Value) = True And _
                 IsDBNull(Row.Cells("RecvMatlSheetMetal").Value) = True Then
                MsgBox("!!! ERROR !!! Material Family is Empty.")
                SwVal = False
                Exit Sub
            End If

            Dim II As Integer
            For II = 1 To dgRecvDoc.Rows.Count - 1
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", II - 1).Value) = False Then
                    If Nz.Nz(dgRecvDoc.Item("RecvMatlBars", II - 1).Value) = 0 And _
                     Nz.Nz(dgRecvDoc.Item("RecvMatlCoils", II - 1).Value) = 0 And _
                     Nz.Nz(dgRecvDoc.Item("RecvMatlHex", II - 1).Value) = 0 And _
                     Nz.Nz(dgRecvDoc.Item("RecvMatlTube", II - 1).Value) = 0 And _
                     Nz.Nz(dgRecvDoc.Item("RecvMatlSheetMetal", II - 1).Value) = 0 Then
                        MsgBox("!!! ERROR !!! Material Family is Empty.")
                        SwVal = False
                        Exit Sub
                    End If
                End If
            Next

        Next

        SwVal = True

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        If SwSave = False Then
            MsgBox("Please Save before Reset the Form.")
            Exit Sub
        End If

        Dim reply As DialogResult

        If dsMain.HasChanges Then

            reply = MsgBox("The change you made has not been saved to the database. Action Denied.", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                SwPrint = False
                SwSave = True

                RecvCurrency.EndCurrentEdit()
                RecvDocCurrency.EndCurrentEdit()
                ReqCurrency.EndCurrentEdit()

                dsMain.RejectChanges()

                dgRecv.Refresh()
                dgRecvDoc.Refresh()
                dgReq.Refresh()

                DisableFields()
                FirstTimeMenuButtons()
                BindComponents()

                PutFirstOpen()
            End If
        Else
            SwPrint = False
            SwSave = True

            RecvCurrency.EndCurrentEdit()
            RecvDocCurrency.EndCurrentEdit()
            ReqCurrency.EndCurrentEdit()

            dsMain.RejectChanges()
            
            dgRecv.Refresh()
            dgRecvDoc.Refresh()
            dgReq.Refresh()

            DisableFields()
            FirstTimeMenuButtons()
            BindComponents()

            PutFirstOpen()
        End If

        'lblFilePath.Text = ""

    End Sub

    Sub SetTranz(ByVal index As Integer)

        If SwPrint = True Then
            Exit Sub
        End If

        Try
            If index < 0 Then
                Exit Sub
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRecvTranzMatl", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
            paraFind.Value = dgRecvDoc.Item("DocRecvNo", index).Value.ToString
            mySqlComm.Parameters.Add(paraFind)

            Dim paraTranz As SqlParameter = New SqlParameter("@MatlTranz", SqlDbType.NVarChar, 1)
            paraTranz.Value = 1
            mySqlComm.Parameters.Add(paraTranz)

            Dim paraStatus As SqlParameter = New SqlParameter("@MatlStatus", SqlDbType.NVarChar, 1)
            paraStatus.Value = "O"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraData As SqlParameter = New SqlParameter("@MatlDateTranz", SqlDbType.SmallDateTime, 4)
            paraData.Value = dgRecvDoc.Item("RecvApprDate", index).Value
            mySqlComm.Parameters.Add(paraData)

            Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
            paraQty.Value = dgRecvDoc.Item("RecvMatlWeight", index).Value
            mySqlComm.Parameters.Add(paraQty)

            Dim paraUM As SqlParameter = New SqlParameter("@MatlUM", SqlDbType.NVarChar, 10)
            paraUM.Value = dgRecv.Item("PSlipUM", RowPo).Value
            mySqlComm.Parameters.Add(paraUM)

            Dim paraPrice As SqlParameter = New SqlParameter("@PoPrice", SqlDbType.Money, 8)
            paraPrice.Value = dgRecv.Item("PSlipPrice", RowPo).Value
            mySqlComm.Parameters.Add(paraPrice)

            Dim paraRmsPrice As SqlParameter = New SqlParameter("@RmsPoPrice", SqlDbType.Money, 8)
            paraRmsPrice.Value = dgRecv.Item("PORmsPrice", RowPo).Value
            mySqlComm.Parameters.Add(paraRmsPrice)

            Dim paraDev As SqlParameter = New SqlParameter("@MatlDevise", SqlDbType.NVarChar, 10)
            paraDev.Value = cmbDevise.Text
            mySqlComm.Parameters.Add(paraDev)

            Dim paraLoc As SqlParameter = New SqlParameter("@MatlLoc", SqlDbType.NVarChar, 10)
            paraLoc.Value = dgRecvDoc.Item("RecvMatlLoc", index).Value
            mySqlComm.Parameters.Add(paraLoc)

            Dim paraforSt As SqlParameter = New SqlParameter("@MatlForStock", SqlDbType.Bit, 1)
            paraforSt.Value = dgRecvDoc.Item("RecvForStock", index).Value
            mySqlComm.Parameters.Add(paraforSt)

            Dim paraforOrder As SqlParameter = New SqlParameter("@MatlForOrder", SqlDbType.Bit, 1)
            paraforOrder.Value = dgRecvDoc.Item("RecvForOrders", index).Value
            mySqlComm.Parameters.Add(paraforOrder)

            Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 2000)
            paraNotes.Value = dgRecvDoc.Item("RecvMatlNotes", index).Value
            mySqlComm.Parameters.Add(paraNotes)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Add Receiving: " & ex.Message)

            End Try
        Catch ex As Exception
        End Try

    End Sub

    Sub VerQtyInspPerItem()

        updflg = False

        If Nz.Nz(dgRecv("AccpToPay", RowPo).Value) = True Then
            Exit Sub
        Else
            Dim poQty As Integer = 0
            Dim recQty As Integer = 0
            Dim min10 As Integer = 0
            Dim plus10 As Integer = 0

            poQty = Nz.Nz(dgRecv("PslipQty", RowPo).Value)
            For Each rectrw As DataRow In dsMain.Tables("tblPOReceivingDOC").Rows
                If dgRecv("PORecvID", RowPo).Value = rectrw.Item("PORecvID") Then
                    recQty = recQty + rectrw.Item("RecvMatlWeight")
                End If
            Next

            min10 = poQty * (1 - 10 / 100)
            plus10 = poQty * (1 + 10 / 100)

            If recQty > plus10 Then
                Dim reply As DialogResult
                reply = MsgBox("!!! Quantity Inspected is Greather then Quantity Ordered + 10% !!!  Accept it ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    dgRecv("AccpToPay", RowPo).Value = 1
                    updflg = True
                    Call EmailToBuyer()
                End If
            End If

            If recQty > plus10 Then
                Dim reply As DialogResult
                reply = MsgBox("!!! Quantity Inspected is Less then Quantity Ordered - 10% !!!  Accept it ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    dgRecv("AccpToPay", RowPo).Value = 1
                    updflg = True
                    Call EmailToBuyer()
                End If
            End If

            If recQty >= min10 And recQty <= plus10 Then
                'MsgBox("Quantity Inspected is in the limit with Quantity Ordered. Please Accept the Po Line ? ", MsgBoxStyle.OKOnly)
                dgRecv("AccpToPay", RowPo).Value = 1
                updflg = True
            End If

        End If

    End Sub

    Sub EmailToBuyer()

        'Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
        'Dim strBody As String = ""
        'NotesSession = CreateObject("Notes.NotesSession")

        'If Len(wkEmpLogin) > 8 Then
        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
        'Else
        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
        'End If

        'NotesDoc = NotesDb.CREATEDOCUMENT
        'NotesItem = NotesDoc.CreateRichTextItem("BODY")
        'NotesDoc.Subject = "Purchasing Module"
        ''NotesDoc.cc = ""
        'strBody = "This is to inform you" & vbCrLf
        'strBody = strBody & "that at the PO Number: " & FindPO.Text & vbCrLf
        'strBody = strBody & " Inspection Department has Inspected and Accepted " & vbCrLf
        'strBody = strBody & " this Quantity: " & dgRecvDoc.Item("RecvMatlWeight", RowDoc).Value.ToString & vbCrLf
        'strBody = strBody & " which is more or less then Quantity Ordered with 10%."

        'NotesDoc.body = strBody

        'Call NotesDoc.SEND(False, "yanick.levert@lisi-aerospace.com")
        ''Call NotesDoc.SEND(True, "stefan.tudor@lisi-aerospace.com")

        Dim email As New Mail.MailMessage()
        Dim strBody As String = ""
        email.Subject = "Purchasing Module"
        strBody = "This is to inform you" & vbCrLf
        strBody = strBody & "that at the PO Number: " & FindPO.Text & vbCrLf
        strBody = strBody & " Inspection Department has Inspected and Accepted " & vbCrLf
        strBody = strBody & " this Quantity: " & dgRecvDoc.Item("RecvMatlWeight", RowDoc).Value.ToString & vbCrLf
        strBody = strBody & " which is more or less then Quantity Ordered with 10%."
        email.Body = strBody

        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
        email.From = New Net.Mail.MailAddress(wkEmpEmail)
        email.To.Add(New Mail.MailAddress("yanick.levert@lisi-aerospace.com"))
        client.Send(email)

    End Sub

    Sub CalculDgrecvDoc()

        Dim TotQty As Integer = 0

        For I As Integer = 0 To (dgRecvDoc.Rows.Count - 1)
            If dgRecv("PORecvID", RowPo).Value = dgRecvDoc("PORecvID", I).Value Then
                TotQty = TotQty + Nz.Nz(dgRecvDoc("RecvMatlWeight", I).Value)
            End If
        Next I

        txtQtyInsp.Text = TotQty.ToString("N3")

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        SwPrint = False

        If Len(Trim(txtPrint.Text)) > 0 Then
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptMatlLotNumber

            rptPO.Load("..\rptMatlLotNumber.rpt")
            pdvCustomerName.Value = txtPrint.Text
            pvCollection.Add(pdvCustomerName)
            rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()
        Else
            MsgBox("Missing Lot Number.")
        End If
    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        'lblFilePath.Text = ""

        CmdReset.Enabled = False
        CmdSave.Enabled = False
        CmdGen.Enabled = False
        CmdSearch.Enabled = False

        FindPO.Text = ""
        FindPO.ReadOnly = True
        txtPrint.Text = ""
        txtPrint.ReadOnly = False
        txtPrint.Focus()
    End Sub

    Private Sub dgRecvDoc_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRecvDoc.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowDoc = e.RowIndex
            txtPrint.Text = Nz.Nz(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value)
        End If

    End Sub

    Private Sub dgRecvDoc_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgRecvDoc.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDoc = e.RowIndex

        Select Case e.ColumnIndex
            Case 5 To 36
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) = True Or _
                    IsNothing(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) Then
                    PanelNotes.Enabled = False
                    MsgBox("!!! ERROR !!! You must before to Generate the System Number for your Receiving.")
                    e.Cancel = True
                Else
                    SwNoMessage = False      'do not put message

                    SwSave = False
                    '========================
                    SpecialSituation()
                    '========================

                    Select Case e.ColumnIndex
                        Case 11     'material
                            Dim dgcb As DataGridViewComboBoxCell = CType(dgRecvDoc("RecvMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                            Dim Swmat As Integer
                            Swmat = 0
                            dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                        Case 12     ' ksi
                            Dim dgcb As DataGridViewComboBoxCell = CType(dgRecvDoc("RecvMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                            If IsDBNull(dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value) = False Then
                                Dim Swmat As Integer
                                Swmat = dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value
                                dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                            End If
                        Case 19 To 23
                            If SwCheckMat <> 9 Then
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlBars").Value = False
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlCoils").Value = False
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlHex").Value = False
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlTube").Value = False
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlSheetMetal").Value = False
                            End If
                        Case 24 To 25
                            If SwCheckMat <> 9 Then
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvChYes").Value = False
                                dgRecvDoc.Rows(e.RowIndex).Cells("RecvChNo").Value = False
                            End If
                    End Select

                End If

        End Select
    End Sub

    Private Sub dgRecvDoc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRecvDoc.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDoc = e.RowIndex

        dgRecvDoc.Rows(e.RowIndex).Cells("Item").Value = dgRecv.Rows(RowPo).Cells("POItem").Value
        dgRecvDoc("Item", e.RowIndex).ReadOnly = True
        dgRecvDoc.Item("DocRecvNo", e.RowIndex).ReadOnly = True


        Select Case e.ColumnIndex
            Case 2 To 36
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) = True Or _
                    IsNothing(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) Then
                    CmdGen.Enabled = True
                    PanelNotes.Enabled = True
                    cmdPrint.Enabled = False
                    txtPrint.Text = ""
                Else
                    CmdGen.Enabled = False
                    PanelNotes.Enabled = True
                    cmdPrint.Enabled = True
                    txtPrint.Text = dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value
                End If
        End Select

        Select Case e.ColumnIndex
            Case 3
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) = True Or _
                    IsNothing(dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value) Then
                    If IsDBNull(txtDocNo.Text) = True Or txtDocNo.Text = "ERROR" Or Len(Trim(txtDocNo.Text)) = 0 Then
                        MsgBox("!!! ERROR !!! You must before to Generate the System Number for your Receiving.")
                    Else
                        dgRecvDoc.Item("DocRecvNo", e.RowIndex).Value = txtDocNo.Text
                        dgRecvDoc.Item("RecvMatlWeight", e.RowIndex).Value = dgRecv.Item("PslipQty", RowPo).Value
                        dgRecvDoc.Item("RecvApprDate", e.RowIndex).Value = Now.ToShortDateString
                        TakeAction()
                        TakePoItemInfo()
                        TakePoRemarks()

                        Dim swPOItem As String = ""
                        swPOItem = dgRecv.Rows(RowPo).Cells("POItem").Value

                        If IsDBNull(dgRecvDoc.Item("RecvMatlType", e.RowIndex).Value) = True Then
                            If CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialType", FindPO.Text, swPOItem) <> "False" Then
                                dgRecvDoc.Item("RecvMatlType", e.RowIndex).Value = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialType", FindPO.Text, swPOItem)
                            End If
                        End If

                        If IsDBNull(dgRecvDoc.Item("RecvMatlDetID", e.RowIndex).Value) = True Then
                            Dim dgcb As DataGridViewComboBoxCell = CType(dgRecvDoc("RecvMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                            If IsDBNull(dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value) = False Then
                                Dim Swmat As Integer
                                Swmat = dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value
                                dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                            End If
                            If CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialKSI", FindPO.Text, swPOItem) <> "False" Then
                                dgRecvDoc.Item("RecvMatlDetID", e.RowIndex).Value = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialKSI", FindPO.Text, swPOItem)
                            End If
                        End If

                        If IsDBNull(dgRecvDoc.Item("RecvMatlSize", e.RowIndex).Value) = True Then
                            If CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialDia", FindPO.Text, swPOItem) <> "False" Then
                                dgRecvDoc.Item("RecvMatlSize", e.RowIndex).Value = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialDia", FindPO.Text, swPOItem)
                            End If
                        End If

                        If IsDBNull(dgRecvDoc.Item("RecvMatlInsideDIA", e.RowIndex).Value) = True Then
                            If CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialInsideDIA", FindPO.Text, swPOItem) <> "False" Then
                                dgRecvDoc.Item("RecvMatlInsideDIA", e.RowIndex).Value = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialInsideDIA", FindPO.Text, swPOItem)
                            End If
                        End If

                        Dim SwForm As String
                        If IsDBNull(dgRecvDoc.Item("RecvMatlBars", e.RowIndex).Value) = True And _
                            IsDBNull(dgRecvDoc.Item("RecvMatlCoils", e.RowIndex).Value) = True And _
                            IsDBNull(dgRecvDoc.Item("RecvMatlHex", e.RowIndex).Value) = True And _
                            IsDBNull(dgRecvDoc.Item("RecvMatlTube", e.RowIndex).Value) = True And _
                            IsDBNull(dgRecvDoc.Item("RecvMatlSheetMetal", e.RowIndex).Value) = True Then
                            SwForm = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialForm", FindPO.Text, swPOItem)
                            If SwForm = "Bars" Then
                                dgRecvDoc.Item("RecvMatlBars", e.RowIndex).Value = True
                            End If
                            If SwForm = "Coils" Then
                                dgRecvDoc.Item("RecvMatlCoils", e.RowIndex).Value = True
                            End If
                            If SwForm = "Hex" Then
                                dgRecvDoc.Item("RecvMatlHex", e.RowIndex).Value = True
                            End If
                            If SwForm = "Tube" Then
                                dgRecvDoc.Item("RecvMatlTube", e.RowIndex).Value = True
                            End If
                            If SwForm = "SheetMetal" Then
                                dgRecvDoc.Item("RecvMatlSheetMetal", e.RowIndex).Value = True
                            End If

                        End If

                        Dim SwCheck As String
                        SwCheck = ""

                        If IsDBNull(dgRecvDoc.Item("RecvForStock", e.RowIndex).Value) = True Then
                            SwCheck = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialForStock", FindPO.Text, swPOItem)
                            If SwCheck <> "False" Then
                                dgRecvDoc.Item("RecvForStock", e.RowIndex).Value = 1
                            End If
                        End If

                        SwCheck = ""
                        If IsDBNull(dgRecvDoc.Item("RecvForOrders", e.RowIndex).Value) = True Then
                            SwCheck = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialForOrder", FindPO.Text, swPOItem)
                            If SwCheck <> "False" Then
                                dgRecvDoc.Item("RecvForOrders", e.RowIndex).Value = 1
                            End If
                        End If

                        If IsDBNull(dgRecvDoc.Item("RecvMatlNotes", e.RowIndex).Value) = True Then
                            If CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialNotes", FindPO.Text, swPOItem) <> "False" Then
                                dgRecvDoc.Item("RecvMatlNotes", e.RowIndex).Value = CallClass.ReturnStrWith2ParStr("cspReturnPOItemMaterialNotes", FindPO.Text, swPOItem)
                            End If
                        End If

                        'put on hold the RM LOT when the LOT is created
                        dgRecvDoc.Item("RecvHoldMatl", e.RowIndex).Value = True
                        '============================
                        txtItemsNotes.Text = Trim(txtItemsNotes.Text) + vbCrLf + vbCrLf + _
                                            "Material Lot Created and activate the HOLD Status By: " + wkName + " on " + Now.ToShortDateString
                        SwSave = False
                        '-------------------------------------------------------------------------------------------------------------------------

                        'Reject RM LOT when the LOT is created
                        dgRecvDoc.Item("RecvRejectMatl", e.RowIndex).Value = True
                        '============================
                        txtItemsNotes.Text = Trim(txtItemsNotes.Text) + vbCrLf + vbCrLf + _
                                            "Material Lot Created and activate the Reject Status By: " + wkName + " on " + Now.ToShortDateString
                        SwSave = False
                        '-------------------------------------------------------------------------------------------------------------------------



                        dgRecvDoc.Refresh()

                        Call SetTranz(RowDoc)

                        SwCheck = ""
                        SwCheck = CallClass.ReturnStrWith2ParStr("cspReturnPOItemEngMaterialDia", FindPO.Text, swPOItem)
                        If SwCheck <> "False" Then
                            If Val(SwCheck) > 0 Then
                                If CDec(dgRecvDoc.Item("RecvMatlSize", e.RowIndex).Value) <> CDec(SwCheck) Then

                                    Dim email As New Mail.MailMessage()
                                    Dim strBody As String = ""
                                    email.Subject = "Raw Material Receiving Inspection Module"
                                    strBody = "Please note that the material DIA received: " & dgRecvDoc.Item("RecvMatlSize", RowDoc).Value.ToString & vbCrLf
                                    strBody = strBody & "is different from the Eng. material DIA: " & CallClass.ReturnStrWith2ParStr("cspReturnPOItemEngMaterialDia", FindPO.Text, swPOItem)
                                    strBody = strBody & " requested." & vbCrLf
                                    strBody = strBody & "LAC Purchase Order: " & FindPO.Text & vbCrLf
                                    email.Body = strBody

                                    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                                    email.From = New Net.Mail.MailAddress(wkEmpEmail)
                                    'email.To.Add(New Mail.MailAddress("ventes.montreal@lisi-aerospace.com"))
                                    email.To.Add(New Mail.MailAddress("Planning.Montreal@lisi-aerospace.com"))
                                    email.To.Add(New Mail.MailAddress("ingenierie.montreal@lisi-aerospace.com"))
                                    client.Send(email)

                                End If
                            End If
                        End If

                    End If
                Else
                    MsgBox("The Lot Number was allready assigned. Action denied.")
                End If

            Case 8
                frmEngApprMillList.ShowDialog()
                frmEngApprMillList.Dispose()
                PutMillProd()
            Case 10
                frmRMStockLocation.ShowDialog()
                frmRMStockLocation.Dispose()
                PutStockLoc()
            Case 17         'addksi
                Dim dgcb As DataGridViewComboBoxCell = CType(dgRecvDoc("RecvMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                If IsDBNull(dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value) = False Then
                    Dim Swmat As Integer
                    Swmat = dgRecvDoc.Rows(e.RowIndex).Cells("RecvMatlType").Value
                    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                End If

            Case 26
                dgRecvDoc.Rows(e.RowIndex).Cells("RecvRejectMatl").Value = False
            Case 27
                dgRecvDoc.Rows(e.RowIndex).Cells("RecvHoldMatl").Value = False
        End Select

        CalculDgrecvDoc()

    End Sub

    Private Sub dgRecvDoc_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRecvDoc.CellEndEdit
        If RowDoc < 0 Then
            Exit Sub
        End If

        SwSave = False

        Call SetTranz(RowDoc)

        CalculDgrecvDoc()

        VerQtyInspPerItem()

        If updflg = True = True Then
            dgRecv("AccpToPay", RowPo).Value = 0
        End If

        Select Case e.ColumnIndex
            Case 26

                If dgRecvDoc.Item("RecvHoldMatl", RowDoc).Value = True Or dgRecvDoc.Item("RecvRejectMatl", RowDoc).Value = True Then

                    'check if it's not second time on hold or rejected in the same date
                    If InStr(txtItemsNotes.Text, Now.ToShortDateString, vbTextCompare) = 0 Then
                        txtItemsNotes.Text = Trim(txtItemsNotes.Text) + vbCrLf + vbCrLf + "Material on HOLD or Rejected Status; By: " + wkName + " on " + Now.ToShortDateString

                        CheckReservationAndProduction()
                        If SwCheckMat = 9 Then


                            Dim email As New Mail.MailMessage()
                            Dim strBody As String = ""
                            email.Subject = "Raw Material Lot Status on HOLD or Rejected "
                            strBody = "This is to inform you that the Raw Material Lot#: " & dgRecvDoc.Item("DocRecvNo", RowDoc).Value & " is on HOLD or Rejected.  " & vbCrLf
                            strBody = strBody & "System checked and identify that THE MATERIAL LOT was reserved or already released to production."
                            email.Body = strBody

                            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            'email.To.Add(New Mail.MailAddress("ventes.montreal@lisi-aerospace.com"))
                            email.To.Add(New Mail.MailAddress("Planning.Montreal@lisi-aerospace.com"))
                            email.To.Add(New Mail.MailAddress("ingenierie.montreal@lisi-aerospace.com"))
                            client.Send(email)

                        End If
                    End If
                End If
        End Select

    End Sub

    Private Sub dgRecvDoc_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRecvDoc.DataError
        REM end
    End Sub

    Private Sub dgReq_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgReq.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If RowDoc < 0 Then
            Exit Sub
        End If
        Select Case e.ColumnIndex
            Case 2 To 5
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", RowDoc).Value) = True Or _
                    IsNothing(dgRecvDoc.Item("DocRecvNo", RowDoc).Value) Then
                    MsgBox("You can not edit the field without a Receiving Number.")
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgReq_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReq.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        dgReq.Refresh()

        Select Case e.ColumnIndex
            Case 3
                frmInspReqList.ShowDialog()
                frmInspReqList.Dispose()
                PutReqList()
        End Select
    End Sub

    Private Sub dgReq_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReq.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        dgReq.Refresh()

        SwSave = False

    End Sub

    Private Sub dgReq_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgReq.DataError
        REM end
    End Sub

    Private Sub dgRecvDoc_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgRecvDoc.RowsRemoved
        For Each trw As DataRow In dsMain.Tables("tblPOReceivingDoc").Rows
            If trw.RowState = DataRowState.Deleted = True Then
                If IsDBNull(dgRecvDoc.Item("DocRecvNo", RowDoc).Value) = False Or _
                    IsNothing(dgRecvDoc.Item("DocRecvNo", RowDoc).Value) = False Or _
                    Len(Trim(dgRecvDoc.Item("DocRecvNo", RowDoc).Value)) <> 0 Then
                    MsgBox("You can not Delete this line.")
                    trw.RejectChanges()
                    dsMain.RejectChanges()
                    dgRecvDoc.Refresh()
                    dgReq.Refresh()

                    SwSave = False
                End If
            End If
        Next

    End Sub

    Private Sub CmdSee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSee.Click


        Dim pattern As String = ""
        Dim SwPath As String = ""
        'Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Inspection\Raw Material\Raw Material Cert")
        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Lisi Raw Material Mill Certs\Raw Material Cert")
        'Dim txtLotno As String = dgRecvDoc("DocRecvNo", RowDoc).Value
        Dim txtLotno As String = txtPrint.Text

        If Len(txtLotno) = 0 Then
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        Select Case Len(txtLotno)
            Case 2
                pattern = "M-00" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case 3
                pattern = "M-0" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case Else
                pattern = "M-" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
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

        End If

        Select Case Len(txtLotno)
            Case 2
                pattern = "M00" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case 3
                pattern = "M0" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case Else
                pattern = "M" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
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

    Private Sub CmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMat.Click
        frmEngMatlType.ShowDialog()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click

        If Len(Trim(FindPO.Text)) > 0 Then

            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptPOSupp()

            Try
                rptPO.Load("..\rptposupp.rpt")
                pdvCustomerName.Value = FindPO.Text
                pvCollection.Add(pdvCustomerName)
                rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = False
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

    Private Sub dgReq_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgReq.RowsRemoved

        For Each trw As DataRow In dsMain.Tables("tblPoReceivingResults").Rows
            If trw.RowState = DataRowState.Deleted = True Then
                SwSave = False
            End If
        Next

    End Sub

    Private Sub txtQANotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQANotes.Validating
        If SwCheckMat = 9 Then
            CmdSave.Enabled = True
            CmdReset.Enabled = True
        End If
    End Sub

    Sub SpecialSituation()
        ' CheckReservationAndProduction()
        If SwCheckMat = 9 Then

            SwSave = True

            dgRecv.ReadOnly = True
            dgReq.ReadOnly = True

            'txtQANotes.ReadOnly = True
            txtItemsNotes.ReadOnly = True

            CmdReset.Enabled = True
            CmdGen.Enabled = False
            CmdSave.Enabled = True

            dgRecvDoc.ReadOnly = False

            dgRecvDoc.Item("Item", RowDoc).ReadOnly = True
            dgRecvDoc.Item("CmdTake", RowDoc).ReadOnly = True
            dgRecvDoc.Item("DocRecvNo", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvApprDate", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvCertNo", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlMfg", RowDoc).ReadOnly = True
            dgRecvDoc.Item("CmdMillProd", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlLoc", RowDoc).ReadOnly = True
            dgRecvDoc.Item("CmdLoc", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlType", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlDetID", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlSize", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlInsideDia", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlLength", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlHeat", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlWeight", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlCond", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlBars", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlCoils", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlHex", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlTube", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvMatlSheetMetal", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvChYes", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvChNo", RowDoc).ReadOnly = True
            dgRecvDoc.Item("RecvPoItemsNotes", RowDoc).ReadOnly = True


            dgRecvDoc.Item("RecvHoldMatl", RowDoc).ReadOnly = False
            dgRecvDoc.Item("RecvRejectMatl", RowDoc).ReadOnly = False

            dgRecvDoc.Item("RecvMillID", RowDoc).ReadOnly = False
            dgRecvDoc.Item("RecvRedrawID", RowDoc).ReadOnly = False
            dgRecvDoc.Item("RecvDistrID", RowDoc).ReadOnly = False
        End If

    End Sub

    Private Sub frmPoRecvInsp_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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

    Sub PutInfoAlusta()
        For Each Row As DataGridViewRow In dgAlusta.Rows

            '  Header
            '=========
            Row.Cells("LACData").Value = Row.Cells("ENTPONo").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTLAC").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTDOR").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTSUPP").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTDEVISE").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                          ' CODE TAXES

            Dim ENT_HT As Double = 0.0
            For Each Row11 As DataGridViewRow In dgAlusta.Rows
                ENT_HT = ENT_HT + CStr(CDbl(Row11.Cells("LINHT").Value).ToString("N3"))
            Next
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(ENT_HT).ToString("N3")) + ";"                                          ' ENT_HT


            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I5StPrice").Value - Row.Cells("I5MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I5MpoRMCostCDN").Value).ToString("N4"))   'TRPR  (StockPrice-RM)*50+RM



            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                          ' ENT_TTC

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTRequester").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTBuyer").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTPOStatus").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTPODate").Value) + ";"

            If IsDBNull(Row.Cells("ENTPOModDate").Value) = True Then
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Else
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("ENTPOModDate").Value + ";"
            End If

            '====
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPONo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOType").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOItem").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINPOQty").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOUM").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINTotalPrice").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINTotPriceConf").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINHT").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINRemise").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINProdID").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINProdDescr").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINGLCode").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINEtablissement").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINCostCenter").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           ' LIN_Famille

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINSUPP").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           ' LIN_Commande

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("LINCapexNo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("LINCapexDescr").Value) + ";"

            ' 20 doc print & sent
            ' 50 good received
            ' 65 quality inspection completed
            ' 75 put-away completed

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINStatus").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                        ' LIN_Solde


            '===
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("RECPONo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECLine").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECNo").Value)).ToString + ";"


            Dim SwRecStatus As String = ""

            Select Case cmbPOType.Text

                Case "Raw Material"

                    If Nz.Nz(Row.Cells("ARecvMatlWeight").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("ARecvMatlWeight").Value).ToString("F3")) + ";"            ' matl inspected
                        SwRecStatus = "65"
                    Else
                        If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "50"
                        Else
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "20"
                        End If

                    End If

                Case "Processing", "Sub-Contracting", "Tooling", "Calibration/Testing"

                    If Nz.Nz(Row.Cells("ARecQtyAccp").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("ARecQtyAccp").Value).ToString("F3")) + ";"                ' processing received
                        SwRecStatus = "65"
                    Else
                        If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "50"
                        Else
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "20"
                        End If
                    End If

                Case Else

                    If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                        'pslipqty
                        SwRecStatus = "50"
                    Else
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                        'pslipqty
                        SwRecStatus = "20"
                    End If

            End Select

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECNET").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("ARECDate").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECBarCode").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + SwRecStatus

        Next



        FileNameStr = ""

        Dim SwDate As String
        Dim newDate As Date = Now.ToShortDateString

        SwDate = newDate.ToString("yyyyMMdd")

        FileNameStr = "LACPO_" + FindPO.Text + "_" + SwDate + "_" + Trim(Now.ToShortTimeString) + ".csv"
        FileNameStr = FileNameStr.Replace(":", " ")
        Dim TextFile As New IO.StreamWriter("\\SRV115FS01\LISI Alusta\" + FileNameStr)

        For Each Row As DataGridViewRow In dgAlusta.Rows
            TextFile.WriteLine(Row.Cells("LACData").Value)
        Next

        TextFile.Close()

        sSource = "\\SRV115FS01\LISI Alusta\" + FileNameStr
        sTarget = "\\dcxapt04\mvxfiletransfert\LAC ALUSTA DEV\" + FileNameStr

        File.Copy(sSource, sTarget, True)

        MsgBox("Alusta  -  successfully uploaded.")


    End Sub

End Class


