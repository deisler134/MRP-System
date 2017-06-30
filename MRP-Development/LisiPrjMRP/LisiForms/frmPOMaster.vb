Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.VisualBasic

Imports System.Net
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPOMaster

    Inherits System.Windows.Forms.Form

    Dim cnSqlServer As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Private dsAlusta As New DataSet
    Private daPOMaster As New SqlDataAdapter
    Private daPoDetail As New SqlDataAdapter
    Private daMatl As New SqlDataAdapter

    Dim intCust As Integer
    Dim intCont As Integer

    Dim cmMaster As CurrencyManager
    Dim cmDetail As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwEndUser As String
    Dim strSQL As String
    Dim SwOper As String
    Dim SwVal As Boolean
    Dim PoLisiKey As Integer
    Dim VerPo As Integer = 9    '0=serach ok, 1 = posted, 9=search wrong
    Dim SwPo As Integer = 0
    Dim OldPO, NewPONo As String
    Dim WhatAction As Integer = 0
    Dim KeepNo As Integer = 0

    Dim RowDetail As Integer = 0

    Dim AccGST As Boolean = True
    Dim AccQST As Boolean = True

    ' Dim AlustaNo As Integer = 0
    Dim KeepIdent As String
    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmPOMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dgDetail.Refresh()
        Me.Refresh()


        Try
            If cmMaster.Count > 0 Then
                cmMaster.EndCurrentEdit()
            End If

            If cmDetail.Count > 0 Then
                cmDetail.EndCurrentEdit()
            End If

            If dsMain.HasChanges Then
                Dim reply As DialogResult
                reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                Else
                    dsMain.Dispose()
                    daPOMaster.Dispose()
                    daPoDetail.Dispose()
                    Me.Dispose()

                    If cnSqlServer.State = ConnectionState.Open Then
                        cnSqlServer.Close()
                    End If

                End If
            Else
                dsMain.Dispose()
                dsAlusta.Dispose()
                daPOMaster.Dispose()
                daPoDetail.Dispose()
                Me.Dispose()

                If cnSqlServer.State = ConnectionState.Open Then
                    cnSqlServer.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox("Exception occured - Closing Form  " & ex.Message)
        End Try

        GC.Collect()

    End Sub

    Private Sub frmPOMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1800 And Height > 900 Then
            Me.Width = 1800
            Me.Height = 900
        Else
            If Width < 1800 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        GC.Collect()

        SwPo = 0
        SwOper = ""
        txtRMREQNo.Text = ""

        dsMain.RejectChanges()
        dgDetail.Refresh()
        Call InitialComponents()

    End Sub

    Sub InitialComponents()

        RecvPoID.Visible = False
        txtPosted.Visible = False
        txtMastID.Visible = False
        txtPORev.Text = ""
        txtPOReq.Text = ""

        Call LoadFirst()
        FindPO.Enabled = False
        'FindPO.Text = ""
        FindPO.Focus()
        FindPO.BackColor = Color.LightBlue

        'cnSqlServer.Close()
        'cnSqlServer.Open()

        Connect()

        Try

            dsMain.Clear()
            dsMain.Relations.Clear()    '  added in aug 

            daPOMaster.FillSchema(dsMain, SchemaType.Source, "tblPoMaster")
            daPoDetail.FillSchema(dsMain, SchemaType.Source, "tblPODetails")

            daPOMaster.Fill(dsMain, "tblPOMaster")
            Dim MastID As DataColumn = dsMain.Tables("tblPOMaster").Columns("POMasterID")
            MastID.AutoIncrement = True
            MastID.AutoIncrementStep = -1
            MastID.AutoIncrementSeed = -1
            MastID.ReadOnly = False

            daPoDetail.Fill(dsMain, "tblPODetails")
            Dim DetID As DataColumn = dsMain.Tables("tblPODetails").Columns("PODetailID")
            DetID.AutoIncrement = True
            DetID.AutoIncrementStep = -1
            DetID.AutoIncrementSeed = -1
            DetID.ReadOnly = False

            dsMain.EnforceConstraints = False

            With dsMain
                .Relations.Add("MastDet", _
                    .Tables("tblPOMaster").Columns("POMasterID"), _
                    .Tables("tblPODetails").Columns("POMasterID"), True)
            End With

            cmMaster = CType(BindingContext(dsMain, "tblPOMaster"), CurrencyManager)
            cmDetail = CType(BindingContext(dsMain, "tblPODetails"), CurrencyManager)

            ClearBindFields()

            Call PutBuyer()
            Call PutGl()
            Call PutSupplier()

            CmbPOSupp.SelectedIndex = -1

            CmbPOType.Text = ""
            CmbPOType.SelectedText = "General"
            'CmbPOType.SelectedIndex = 3


            Call PutDropShip()
            Call PutShipVia()
            Call PutSalesTax()
            Call PutDevise()

            LoadCmbProduct()
            LoadUMProduct()
            LoadMatlType()

            SetCtl()

            dgDetail.AutoGenerateColumns = False
            dgDetail.DataSource = dsMain
            dgDetail.DataMember = "tblPOMaster.MastDet"

            dgDetail.Visible = False

            BindFields()


            '=========================
            dsAlusta.Clear()
            dsAlusta.Relations.Clear()

            CallClass.PopulateDataAdapter("getPOUpload_IntoAlustaEmpty").Fill(dsAlusta, "tblSelect")

            dsAlusta.EnforceConstraints = False

            dgAlusta.AutoGenerateColumns = False
            dgAlusta.DataSource = dsAlusta
            dgAlusta.DataMember = "tblSelect"

        Catch ex As Exception
            MsgBox("Error - Purchasing Module" & ex.Message)
            Me.Dispose()
        End Try

    End Sub

    Sub SetCtl()

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


        'detail
        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.POMasterID
            .DataPropertyName = "POMasterID"
            .Name = "POMasterID"
            .Visible = False
        End With

        With Me.POStatusLine
            .DataPropertyName = "POStatusLine"
            .Name = "POStatusLine"
        End With


        With Me.POCostCenter
            .DataSource = CallClass.PopulateComboBox("tblPOCostCenter", "cmbGetPOCostCenter").Tables("tblPOCostCenter")
            .DisplayMember = "FullDesc"
            .ValueMember = "CCID"
            .DropDownWidth = 300
            .MaxDropDownItems = 40
            .DataPropertyName = "POCostCenter"
            .Name = "POCostCenter"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.POProdID
            .DataPropertyName = "POProdID"
            .Name = "POProdID"
            .DropDownWidth = 300
            '.MaxDropDownItems = 50
        End With

        If RoleAdminPO(wkDeptCode) = False Then
            With Me.PoMpoID
                .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGettblMpoMaster").Tables("tblMpoMaster")
                .DisplayMember = "MpoNo"
                .ValueMember = "MpoId"
                .DropDownWidth = 200
                '.MaxDropDownItems = 40
                .DataPropertyName = "PoMpoID"
                .Name = "PoMpoID"
            End With
        Else
            'for admin PO when the MPO is closed

            With Me.PoMpoID
                .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGettblMpoMasterAll").Tables("tblMpoMaster")
                .DisplayMember = "MpoNo"
                .ValueMember = "MpoId"
                .DropDownWidth = 200
                '.MaxDropDownItems = 40
                .DataPropertyName = "PoMpoID"
                .Name = "PoMpoID"
            End With
        End If

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
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

        With Me.PODueDate
            .DataPropertyName = "PODueDate"
            .Name = "PODueDate"
        End With

        With Me.POItemEscompte
            .DataPropertyName = "POItemEscompte"
            .Name = "POItemEscompte"
        End With

        With Me.PONotesItem
            .DataPropertyName = "PONotesItem"
            .Name = "PONotesItem"
        End With

        With Me.PoMatlID
            .DataPropertyName = "PoMatlID"
            .Name = "PoMatlID"
            .DropDownWidth = 400
            .MaxDropDownItems = 50
        End With

        With Me.POMatlDetID
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "POMatlDetID"
            .Name = "POMatlDetID"
            .DropDownWidth = 500
            .MaxDropDownItems = 40
        End With

        With Me.POMatlDia
            .DataPropertyName = "POMatlDia"
            .Name = "POMatlDia"
        End With

        With Me.POMatlInsideDia
            .DataPropertyName = "POMatlInsideDia"
            .Name = "POMatlInsideDia"
        End With
        With Me.POEngMatlDia
            .DataPropertyName = "POEngMatlDia"
            .Name = "POEngMatlDia"
        End With

        With Me.POMatlForm
            .DataPropertyName = "POMatlForm"
            .Name = "POMatlForm"
        End With

        With Me.POForStock
            .DataPropertyName = "POForStock"
            .Name = "POForStock"
        End With

        With Me.POForOrders
            .DataPropertyName = "POForOrders"
            .Name = "POForOrders"
        End With

        With Me.POMatlNotes
            .DataPropertyName = "POMatlNotes"
            .Name = "POMatlNotes"
        End With

    End Sub

    Function RoleAdminPO(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ADMINPO" Then
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

    Public Sub LoadFirst()

        Call DisableScreen()

        WhatAction = 0
        WhatAction = Val(InStr(1, wkDeptCode, "PO", vbTextCompare))

        If WhatAction = 0 Then          'only read & print PO
            CmdNew.Enabled = False
            CmdCancel.Enabled = True
            CmdMod.Enabled = False
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
        Else                            'full rights
            CmdNew.Enabled = True
            CmdCancel.Enabled = True
            CmdMod.Enabled = True
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
        End If

        CmdSupp.Enabled = False
        CmdRemarks.Enabled = False
        CmdSeePO.Enabled = True

        txtPORev.ReadOnly = True
        txtPODate.Text = Now.ToShortDateString

    End Sub

    Sub EnableScreen()

        CmbPOType.Enabled = True
        CmbPOGL.Enabled = True
        CmbPoStatus.Enabled = False
        CmbPOBuyer.Enabled = False
        CmbPOSupp.Enabled = True
        CmbPORefA.Enabled = True
        txtPORef.ReadOnly = False
        txtPOReq.ReadOnly = False
        CmbPOTerms.Enabled = True
        CmbPODropShip.Enabled = True
        CmbPOShipVia.Enabled = True
        CmbPoFOB.Enabled = True
        txtMastPODueDate.Enabled = True

        ChkCOC.Enabled = True
        ChkMill.Enabled = True
        ChkTest.Enabled = True
        txtPORemarks.ReadOnly = False
        txtPONotes.ReadOnly = False
        CmbSalesTax.Enabled = True
        CmbDevise.Enabled = True

        ButtCancel.Visible = False

        dgDetail.Enabled = True
        txtReqNo.ReadOnly = True

    End Sub

    Sub DisableScreen()

        CmbPOType.Enabled = False
        txtPORev.ReadOnly = True
        CmbPOGL.Enabled = False
        CmbPoStatus.Enabled = False
        CmbPOBuyer.Enabled = False
        CmbPOSupp.Enabled = False
        CmbPORefA.Enabled = False
        txtPORef.ReadOnly = True
        txtPOReq.ReadOnly = True
        CmbPOTerms.Enabled = False
        CmbPODropShip.Enabled = False
        CmbPOShipVia.Enabled = False
        CmbPoFOB.Enabled = False
        txtMastPODueDate.Enabled = False
        ChkCOC.Enabled = False
        ChkMill.Enabled = False
        ChkTest.Enabled = False
        txtPORemarks.ReadOnly = True
        txtPONotes.ReadOnly = True
        CmbSalesTax.Enabled = False
        CmbDevise.Enabled = False

        ButtCancel.Visible = False

        dgDetail.Enabled = False

        txtReqNo.ReadOnly = True

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        Dim reply As DialogResult
        reply = MsgBox("Do you want to create a new Purchase Order ? ", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then

            Try
                SwOper = "New"
                SwPo = 0
                txtRMREQNo.Text = ""

                'FindPO.Text = ""
                'OldPO = ""

                Me.BindingContext(dsMain, "tblPOMaster").EndCurrentEdit()
                Me.BindingContext(dsMain, "tblPODetails").EndCurrentEdit()
                dsMain.RejectChanges()
                Me.BindingContext(dsMain, "tblPOMaster").AddNew()

                'PutPOInfo()

                Call EnableScreen()

                CmdNew.Enabled = False
                CmdMod.Enabled = False
                CmdCancel.Enabled = True
                CmdSave.Enabled = True
                CmdPrint.Enabled = False
                CmdView.Enabled = True

                CmdSupp.Enabled = True
                CmdRemarks.Enabled = True
                CmdSeePO.Enabled = False

                txtPORev.ReadOnly = True

                CmbPoStatus.Text = ""
                CmbPoStatus.SelectedText = "Open"
                CmbPoStatus.Enabled = False

                CmbPOTerms.Text = ""
                CmbPOTerms.SelectedText = "2% Discount 15 Days or Net 60 Days"

                CmbPoFOB.Text = ""
                CmbPoFOB.SelectedText = "Dorval"

                CmbPOType.Text = ""
                CmbPOType.SelectedText = "General"
                'CmbPOType.SelectedIndex = 3

                CmbDevise.Enabled = True
                CmbSalesTax.Enabled = True
                CmbDevise.SelectedIndex = 1
                CmbSalesTax.SelectedValue = 3
                CmbDevise.SelectedValue = CmbSalesTax.SelectedValue

                CmbPODropShip.SelectedValue = 3055
                CmbPOShipVia.SelectedValue = 2

                txtPOLeadTime.Text = ""
                txtPOReq.Text = ""

                Call PutBuyer()

                txtMastPODueDate.Text = Now.ToShortDateString()
                txtPODate.Text = Now.ToShortDateString()
                txtPOModDate.Text = Now.ToShortDateString

                LblCapex.Visible = False
                txtCapexNo.Visible = False
                LblCapexDescr.Visible = False
                txtCapexDescr.Visible = False

                dgDetail.Visible = True

                dsAlusta.Clear()

12:
            Catch ex As Exception
                MsgBox("Exception occured - New Action  " & ex.Message)
            End Try
        End If

    End Sub

    Sub PutSalesTax()

        strSQL = " SELECT SalesTaxID, DolarSign, GstRate, QstRate, TvhRate, Country FROM tblSalesTax"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblSalesTax")

            With CmbSalesTax
                .DataSource = ds.Tables("tblSalesTax")
                .DisplayMember = "Country"
                .ValueMember = "SalesTaxID"
                If SwPo = 0 Then
                    .SelectedValue = 3
                End If
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

    Sub PutDevise()

        strSQL = " SELECT SalesTaxID, DolarSign, GstRate, QstRate, TvhRate, Country FROM tblSalesTax"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblSalesTax")
            With CmbDevise
                .DataSource = ds.Tables("tblSalesTax")
                .DisplayMember = "DolarSign"
                .ValueMember = "SalesTaxID"
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch xcp As Exception
            MessageBox.Show(xcp.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub PutShipVia()

        With Me.CmbPOShipVia
            .DataSource = CallClass.PopulateComboBox("tblShipVia", "cmbGetShipVia").Tables("tblShipVia")
            .DisplayMember = "ShipVia"
            .ValueMember = "ViaID"
            .SelectedItem = -1
        End With

    End Sub

    Sub PutDropShip()

        With Me.CmbPODropShip
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .SelectedValue = 3055
        End With

    End Sub

    Sub PutPORefA()

        Dim index As Integer = CmbPOSupp.SelectedValue()

        strSQL = "SELECT SuppContactID, ContactName, SupplierID FROM tblSuppContact " _
            & " WHERE (SupplierID = " & index & " ) ORDER BY ContactTitle"
        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblSuppContact")

            With CmbPORefA
                .DataSource = ds.Tables("tblSuppContact")
                .DisplayMember = "ContactName"
                .ValueMember = "SuppContactID"
                '.SelectedIndex = -1
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch xcp As Exception
            MessageBox.Show(xcp.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub PutSupplier()

        With Me.CmbPOSupp
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .SelectedIndex = -1
        End With

    End Sub

    Sub PutBuyer()

        With Me.CmbPOBuyer
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
            .Enabled = False
        End With

    End Sub

    Sub PutGl()

        strSQL = "SELECT CompteID, CompteNo, CompteDescr, CompteNotes FROM tblAccCompte WHERE CompteStatus = 'Y' ORDER BY CompteDescr"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblAccCompte")

            ds.Tables("tblAccCompte").Columns.Add _
            ("FullCompte", System.Type.GetType("System.String"), "CompteNo + '    '+ CompteDescr")

            With CmbPOGL
                .DataSource = ds.Tables("tblAccCompte")
                .DisplayMember = "FullCompte"
                .ValueMember = "CompteID"
                '.DropDownWidth = 200
                '.MaxDropDownItems = 100

                .SelectedIndex = -1
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - PutGl  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch xcp As Exception
            MessageBox.Show(xcp.Message, "General Error - PutGl  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub CmbPOType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPOType.SelectedIndexChanged
        If SwPo = 0 Then

            Select Case CmbPOType.Text
                Case "Raw Material"
                    ChkCOC.Checked = True
                    ChkMill.Checked = True
                    ChkTest.Checked = False

                    Me.PoMatlID.Visible = True
                    Me.POMatlDetID.Visible = True
                    Me.POMatlDia.Visible = True
                    Me.POMatlInsideDia.Visible = True
                    Me.POEngMatlDia.Visible = True
                    Me.POMatlForm.Visible = True
                    Me.POForStock.Visible = True
                    Me.POForOrders.Visible = True
                    'Me.POMatlSource.Visible = True
                    Me.POMatlNotes.Visible = True
                    Me.CmdTextRawMatl.Visible = True
                    CmdMat.Visible = True
                    LblCmdMat.Visible = True

                    CmbPOSupp.Enabled = False

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = True
                    LabelReqNo.Visible = True

                    LblCapex.Visible = False
                    txtCapexNo.Visible = False
                    LblCapexDescr.Visible = False
                    txtCapexDescr.Visible = False

                Case "CAPEX"

                    LblCapex.Visible = True
                    txtCapexNo.Visible = True
                    LblCapexDescr.Visible = True
                    txtCapexDescr.Visible = True

                    Me.PoMatlID.Visible = False
                    Me.POMatlDetID.Visible = False
                    Me.POMatlDia.Visible = False
                    Me.POMatlInsideDia.Visible = False
                    Me.POEngMatlDia.Visible = False
                    Me.POMatlForm.Visible = False
                    Me.POForStock.Visible = False
                    Me.POForOrders.Visible = False
                    'Me.POMatlSource.Visible = False
                    Me.POMatlNotes.Visible = False
                    Me.CmdTextRawMatl.Visible = False
                    CmdMat.Visible = False
                    LblCmdMat.Visible = False

                    CmbPOSupp.Enabled = True

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = False
                    LabelReqNo.Visible = False

                Case Else
                    Me.PoMatlID.Visible = False
                    Me.POMatlDetID.Visible = False
                    Me.POMatlDia.Visible = False
                    Me.POMatlInsideDia.Visible = False
                    Me.POEngMatlDia.Visible = False
                    Me.POMatlForm.Visible = False
                    Me.POForStock.Visible = False
                    Me.POForOrders.Visible = False
                    'Me.POMatlSource.Visible = False
                    Me.POMatlNotes.Visible = False
                    Me.CmdTextRawMatl.Visible = False
                    CmdMat.Visible = False
                    LblCmdMat.Visible = False

                    CmbPOSupp.Enabled = True

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = False
                    LabelReqNo.Visible = False

                    LblCapex.Visible = False
                    txtCapexNo.Visible = False
                    LblCapexDescr.Visible = False
                    txtCapexDescr.Visible = False

            End Select


            If CmbPOType.Text = "Processing" Or CmbPOType.Text = "Sub-Contracting" Or CmbPOType.Text = "Tooling" Or CmbPOType.Text = "Calibration/Testing" Then
                ChkCOC.Checked = True
                ChkMill.Checked = False
                ChkTest.Checked = True
            End If

            If CmbPOType.Text = "General" Or CmbPOType.Text = "Perishable" Then
                ChkCOC.Checked = False
                ChkMill.Checked = False
                ChkTest.Checked = False
            End If

            If CmbPOType.Text = "Components" Then
                ChkCOC.Checked = True
                ChkMill.Checked = True
                ChkTest.Checked = True
            End If

            If CmbPOType.Text = "Chemicals" Then
                ChkCOC.Checked = True
                ChkMill.Checked = False
                ChkTest.Checked = False
            End If

            If CmbPOType.Text = "Tooling Material" Then
                ChkCOC.Checked = False
                ChkMill.Checked = True
                ChkTest.Checked = False
            End If

        End If

    End Sub

    Private Sub CmdSupp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSupp.Click
        frmSupplier.SwForm.Text = CmbPOSupp.SelectedValue
        frmSupplier.ShowDialog()

    End Sub

    Private Sub CmbPOSupp_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPOSupp.DropDownClosed

        Try
            txtPOLeadTime.Text = Nz.Nz(CmbPOSupp.SelectedItem("SuppLeadTime"))

            If Len(Trim(txtPOLeadTime.Text)) > 0 Then
                txtMastPODueDate.Text = DateAdd(DateInterval.Day, CInt(txtPOLeadTime.Text), Date.Now).ToShortDateString()
            Else
                MsgBox("!!! ERROR !!! Supplier Lead Time is Empty - please update it. The system for now it will add 5 wks LT. PLease check the PO Due Date.")
                txtMastPODueDate.Text = DateAdd(DateInterval.Day, 35, Date.Now).ToShortDateString()
            End If

            CheckSupplier()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CmbPOSupp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPOSupp.GotFocus
        Call PutSupplier()
        Call PutPORefA()
    End Sub

    Private Sub CmbPORefA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPORefA.GotFocus
        Call PutPORefA()
    End Sub

    Sub CheckVendorNo()

        Dim ParRet As String = ""
        Dim StrSearch As Integer

        CmbPOGL.Enabled = True
        CmbDevise.Enabled = True
        CmbSalesTax.Enabled = True

        CmbDevise.SelectedIndex = 1
        CmbSalesTax.SelectedValue = 3
        CmbDevise.SelectedValue = CmbSalesTax.SelectedValue
        CmbPOGL.SelectedIndex = -1

        AccGST = True
        AccQST = True

        StrSearch = CmbPOSupp.SelectedValue
        ParRet = CallClass.ReturnStrWithParInt("cspReturnSupplierVendorNo", StrSearch)
        If ParRet <> "False" Then
            ParRet = CallClass.ReturnStrWithParInt("cspReturnSupplierGLNo", StrSearch)
            If ParRet <> "False" Then
                Dim TakeSt As String
                TakeSt = CallClass.TakeFinalSt("cspReturnGLId", ParRet)
                If TakeSt = "False" Then
                    Exit Sub
                End If
                CmbPOGL.SelectedValue = TakeSt
                CmbPOGL.Enabled = False

                ParRet = CallClass.ReturnStrWithParInt("cspReturnSupplierAccGST", StrSearch)
                If ParRet <> "False" Then
                    If Len(Trim(ParRet)) > 0 Then
                        CmbSalesTax.SelectedValue = 1
                    End If
                    CmbSalesTax.Enabled = False
                Else
                    AccGST = False
                End If

                ParRet = CallClass.ReturnStrWithParInt("cspReturnSupplierAccQST", StrSearch)
                If ParRet <> "False" Then
                    If Len(Trim(ParRet)) > 0 Then
                        CmbSalesTax.SelectedValue = 3
                    End If
                    CmbSalesTax.Enabled = False
                Else
                    AccQST = False
                End If

                'keep devise the last test
                ParRet = CallClass.ReturnStrWithParInt("cspReturnSupplierDevise", StrSearch)
                If ParRet <> "False" Then
                    Select Case ParRet
                        Case "EUR"
                            CmbDevise.SelectedValue = 5
                        Case "BANKEUR"
                            CmbDevise.SelectedValue = 5
                        Case "USD"
                            CmbDevise.SelectedValue = 4
                        Case "CAN"
                            CmbDevise.SelectedValue = 3
                        Case Else
                            CmbDevise.SelectedValue = 3
                    End Select
                    CmbDevise.Enabled = False

                    If AccGST = False And AccQST = False Then
                        CmbSalesTax.SelectedValue = 4
                    End If
                End If
            End If


        End If

    End Sub

    Private Sub CmbSalesTax_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSalesTax.SelectedIndexChanged
        If IsNothing(CmbSalesTax.SelectedItem) = True Then
        Else
            txtGST.Text = CmbSalesTax.SelectedItem("GstRate")
            txtQST.Text = CmbSalesTax.SelectedItem("QstRate")
            txtTVH.Text = CmbSalesTax.SelectedItem("TvhRate")
            'If Len(Trim(CmbDevise.Text)) = 0 Or IsDBNull(CmbDevise.Text) = True Then
            CmbDevise.SelectedValue = CmbSalesTax.SelectedValue
            'End If
        End If

        CalculGrid()

    End Sub

    Private Function Connect() As Boolean

        Dim strSQLMast As String = "Select * FROM tblPOMaster Order by PONo"
        Dim strSQLDet As String = "SELECT * FROM tblPODetails Order by POMasterID, POItem"

        Try

            Dim commMast As New SqlClient.SqlCommand(strSQLMast, cnSqlServer)
            Dim commDet As New SqlClient.SqlCommand(strSQLDet, cnSqlServer)

            daPOMaster.SelectCommand = commMast
            daPoDetail.SelectCommand = commDet

            Dim cmdMastBuilder As New SqlClient.SqlCommandBuilder(daPOMaster)
            Dim cmdDetBuilder As New SqlClient.SqlCommandBuilder(daPoDetail)

            daPOMaster.UpdateCommand = cmdMastBuilder.GetUpdateCommand
            daPOMaster.UpdateCommand.Connection = cnSqlServer
            daPOMaster.InsertCommand = cmdMastBuilder.GetInsertCommand
            AddHandler daPOMaster.RowUpdated, AddressOf HandleRowUpdatedMaster
            daPOMaster.InsertCommand.Connection = cnSqlServer
            daPOMaster.DeleteCommand = cmdMastBuilder.GetDeleteCommand
            daPOMaster.DeleteCommand.Connection = cnSqlServer

            daPOMaster.AcceptChangesDuringFill = True
            daPOMaster.TableMappings.Add("Table", "tblPOMaster")
            daPOMaster.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daPoDetail.UpdateCommand = cmdDetBuilder.GetUpdateCommand
            daPoDetail.UpdateCommand.Connection = cnSqlServer
            daPoDetail.InsertCommand = cmdDetBuilder.GetInsertCommand
            AddHandler daPoDetail.RowUpdated, AddressOf HandleRowUpdatedDetail
            daPoDetail.InsertCommand.Connection = cnSqlServer
            daPoDetail.DeleteCommand = cmdDetBuilder.GetDeleteCommand
            daPoDetail.DeleteCommand.Connection = cnSqlServer

            daPoDetail.AcceptChangesDuringFill = True
            daPoDetail.TableMappings.Add("Table", "tblPODetails")
            daPoDetail.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedDetail(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Try
            Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSqlServer)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                e.Row(dsMain.Tables("tblPODetails").Columns("PODetailID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
                e.Row.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - HandleRowUpdatedDetail   " & ex.Message)
        End Try

    End Sub

    Private Sub HandleRowUpdatedMaster(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Try
            Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSqlServer)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                e.Row(dsMain.Tables("tblPOMaster").Columns("POMasterID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
                e.Row.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - HandleRowUpdatedMaster   " & ex.Message)
        End Try

    End Sub

    Private Function BindFields() As Boolean
        Try

            txtMastID.DataBindings.Add("Text", dsMain, "tblPOMaster.POMasterID")
            txtPosted.DataBindings.Add("Text", dsMain, "tblPOMaster.POPosted")

            FindPO.DataBindings.Add(New Binding("Text", dsMain, "tblPOMaster.PONo", True))
            txtPORev.DataBindings.Add("Text", dsMain, "tblPOMaster.PORev")
            txtPODate.DataBindings.Add("Text", dsMain, "tblPOMaster.PODate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
            CmbPOType.DataBindings.Add("Text", dsMain, "tblPOMaster.POType")
            CmbPoStatus.DataBindings.Add("Text", dsMain, "tblPOMaster.POStatus")
            CmbPOBuyer.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POBuyer")
            CmbPOGL.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAccount")
            CmbPOSupp.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSuppID")

            Call PutPORefA()

            CmbPORefA.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAttnID")
            txtPORef.DataBindings.Add("Text", dsMain, "tblPOMaster.PORefB")
            txtPOModDate.DataBindings.Add("Text", dsMain, "tblPOMaster.POModDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
            txtPOReq.DataBindings.Add("Text", dsMain, "tblPOMaster.POReqBy")
            txtCapexNo.DataBindings.Add("Text", dsMain, "tblPOMaster.POCapexNo")
            txtCapexDescr.DataBindings.Add("Text", dsMain, "tblPOMaster.POCapexDescr")
            CmbPOTerms.DataBindings.Add("Text", dsMain, "tblPOMaster.POCond")
            CmbPODropShip.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODropShipID")
            CmbPOShipVia.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POShipVia")
            CmbPoFOB.DataBindings.Add("Text", dsMain, "tblPOMaster.POFob")

            txtMastPODueDate.DataBindings.Add("Text", dsMain, "tblPOMaster.MasterPODueDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

            txtPOLeadTime.DataBindings.Add("Text", dsMain, "tblPOMaster.POSuppLeadTime")

            txtReqNo.DataBindings.Add("Text", dsMain, "tblPOMaster.PORMReqNo")

            ChkCOC.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POCOC", True))
            ChkMill.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POMil", True))
            ChkTest.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POTest", True))
            txtPORemarks.DataBindings.Add("Text", dsMain, "tblPOMaster.PORemarks")
            txtPONotes.DataBindings.Add("Text", dsMain, "tblPOMaster.PONotes")
            CmbSalesTax.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSalesTaxID")
            CmbDevise.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODevise")
            txtGST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxGST")
            txtQST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxQST")
            txtTVH.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxTVH")

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        End Try

    End Function

    Sub ClearBindFields()

        'txtMastID.DataBindings.Clear()     '
        txtPosted.DataBindings.Clear()

        'FindPO.DataBindings.Clear()         '

        'txtPORev.DataBindings.Clear()       '
        'txtPODate.DataBindings.Clear()
        CmbPOType.DataBindings.Clear()
        CmbPoStatus.DataBindings.Clear()
        CmbPOBuyer.DataBindings.Clear()
        CmbPOGL.DataBindings.Clear()
        CmbPOSupp.DataBindings.Clear()
        CmbPORefA.DataBindings.Clear()
        txtPORef.DataBindings.Clear()
        txtCapexNo.DataBindings.Clear()
        txtCapexDescr.DataBindings.Clear()
        txtPOModDate.DataBindings.Clear()
        txtPOReq.DataBindings.Clear()
        CmbPOTerms.DataBindings.Clear()
        CmbPODropShip.DataBindings.Clear()
        CmbPOShipVia.DataBindings.Clear()
        CmbPoFOB.DataBindings.Clear()
        txtMastPODueDate.DataBindings.Clear()
        txtReqNo.DataBindings.Clear()
        txtPOLeadTime.DataBindings.Clear()
        ChkCOC.DataBindings.Clear()
        ChkMill.DataBindings.Clear()
        ChkTest.DataBindings.Clear()
        txtPORemarks.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()
        CmbSalesTax.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        txtGST.DataBindings.Clear()
        txtQST.DataBindings.Clear()
        txtTVH.DataBindings.Clear()
    End Sub

    Sub LoadCmbProduct()

        strSQL = "SELECT ProdID, ProdDescr FROM tblPOProdDescr ORDER BY ProdDescr"
        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblPOProdDescr")

            With Me.POProdID
                .DataSource = ds.Tables("tblPOProdDescr")
                .DisplayMember = "ProdDescr"
                .ValueMember = "ProdID"
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch xcp As Exception
            MessageBox.Show(xcp.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub LoadUMProduct()

        With Me.POUM
            .DataSource = CallClass.PopulateComboBox("tblUM", "cmbGetUM").Tables("tblUM")
            .DisplayMember = "IDUM"
            .ValueMember = "IDUM"
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

    End Sub

    Sub LoadMatlType()

        With Me.CmbSwRawMatl
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .Visible = False
        End With

        With Me.PoMatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "PoMatlID"
            .Name = "PoMatlID"
            .DropDownWidth = 200
            .MaxDropDownItems = 20
        End With

        With Me.CmbSwKSI
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailKSI").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .Visible = False
        End With

    End Sub

    Private Sub dgDetail_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDetail.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDetail = e.RowIndex
        Select Case e.ColumnIndex

            Case 17        ' Matl type
                Dim dgcb As DataGridViewComboBoxCell = CType(dgDetail("POMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                Dim Swmat As Integer = 0
                dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")

            Case 18
                If IsDBNull(dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value) = True Then
                    MessageBox.Show("Action Denied. Select before the Material Type.")
                    e.Cancel = True
                Else
                    Dim dgcb As DataGridViewComboBoxCell = CType(dgDetail("POMatlDetID", e.RowIndex), DataGridViewComboBoxCell)

                    If IsDBNull(dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value) = False Then
                        Dim Swmat As Integer
                        Swmat = dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value
                        dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                    End If
                End If
        End Select

    End Sub

    Private Sub dgDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDetail = e.RowIndex

        dgDetail.Refresh()

        Select Case e.ColumnIndex
            Case 7         'items notes
                If Not IsDBNull(Me.dgDetail("PoNotesItem", e.RowIndex).Value) Then
                    frmPONote.txtPONotes.Text = Me.dgDetail("PoNotesItem", e.RowIndex).Value
                    frmPONote.txtRow.Text = e.RowIndex
                Else
                    frmPONote.txtPONotes.Text = ""
                    frmPONote.txtRow.Text = e.RowIndex
                End If
                frmPONote.ShowDialog()

            Case 6       'Find product
                If Not IsDBNull(Me.dgDetail("POProdID", e.RowIndex).Value) Then
                    frmPOMasterBrowse.txtRow.Text = e.RowIndex
                    frmPOMasterBrowse.txtProdID.Text = Me.dgDetail("POProdID", e.RowIndex).Value
                Else
                    frmPOMasterBrowse.txtProdID.Text = ""
                    frmPOMasterBrowse.txtRow.Text = e.RowIndex
                End If
                frmPOMasterBrowse.ShowDialog()
                frmPOMasterBrowse.Dispose()

                If Not Len(Trim(RecvPoID.Text)) = 0 Then
                    If Not IsDBNull(RecvPoID.Text) = True Then
                        Call LoadCmbProduct()
                        With POProdID
                            .DataPropertyName = "POProdID"
                            .Name = "POProdID"
                        End With
                        dgDetail.DataMember = "tblPOMaster.MastDet"
                        Me.dgDetail("POProdID", e.RowIndex).Value = RecvPoID.Text
                        RecvPoID.Text = ""
                    End If
                End If

            Case 5, 8, 9, 10, 11, 12, 13, 14, 17, 18, 19, 20, 21, 22, 23
                Dim J As Integer
                J = Nz.Nz(dgDetail("POItem", e.RowIndex).Value)
                'If J = 0 Then
                '    MessageBox.Show("Action Denied. Enter before the PO item number.")
                '    'dgDetail.EndEdit()
                '    dgDetail.CancelEdit()
                'End If

            Case 17         ' Matl type
                'Dim dgcb As DataGridViewComboBoxCell = CType(dgDetail("POMatlDetID", e.RowIndex), DataGridViewComboBoxCell)

                'If IsDBNull(dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value) = False Then
                '    Dim Swmat As Integer
                '    Swmat = 0
                '    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                'End If

            Case 18     ' matl ksi
                Dim dgcb As DataGridViewComboBoxCell = CType(dgDetail("POMatlDetID", e.RowIndex), DataGridViewComboBoxCell)

                If IsDBNull(dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value) = False Then
                    Dim Swmat As Integer
                    Swmat = dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value
                    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                End If

            Case 25
                Dim J As Integer
                J = Nz.Nz(dgDetail("POItem", e.RowIndex).Value)
                If J = 0 Then
                    'MessageBox.Show("Action Denied. Enter before the PO item number.")
                    ''dgDetail.EndEdit()
                    'dgDetail.CancelEdit()
                Else
                    If IsDBNull(dgDetail("PoNotesItem", e.RowIndex).Value) = True Then

                        'PutTextRawMatl()
                        frmEngRequestForMaterial.SwFrom.Text = "POMAT"
                        frmEngRequestForMaterial.SwOperRM.Text = SwOper
                        frmEngRequestForMaterial.txtRow.Text = e.RowIndex
                        frmEngRequestForMaterial.ShowDialog()

                        FindPO.Enabled = False
                        FindPO.Focus()
                        dgDetail.Refresh()
                        dgDetail.Focus()
                        CmbPOType.Focus()
                        dgDetail.Focus()
                        txtSpecRev.Focus()
                        dgDetail.Focus()
                        Me.BindingContext(dsMain, "tblPOMaster").EndCurrentEdit()
                        Me.BindingContext(dsMain, "tblPODetails").EndCurrentEdit()

                    Else

                        Dim reply As DialogResult
                        reply = MsgBox("Raw Material notes is Not Empty. Do yoy want to replace ? (yes/no)", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            'PutTextRawMatl()
                            frmEngRequestForMaterial.SwFrom.Text = "POMAT"
                            frmEngRequestForMaterial.txtRow.Text = e.RowIndex
                            frmEngRequestForMaterial.SwOperRM.Text = SwOper
                            frmEngRequestForMaterial.ShowDialog()

                            FindPO.Enabled = False
                            FindPO.Focus()
                            dgDetail.Refresh()
                            dgDetail.Focus()
                            CmbPOType.Focus()
                            dgDetail.Focus()
                            txtSpecRev.Focus()
                            dgDetail.Focus()
                            Me.BindingContext(dsMain, "tblPOMaster").EndCurrentEdit()
                            Me.BindingContext(dsMain, "tblPODetails").EndCurrentEdit()

                        End If
                    End If
                End If

        End Select

        Select Case e.ColumnIndex
            Case 8
                If WhatAction = 0 Then
                    dgDetail.Columns(e.ColumnIndex).ReadOnly = True
                Else
                    If CmbPOType.Text = "Processing" Or CmbPOType.Text = "Sub-Contracting" Or CmbPOType.Text = "Grinding" Then
                        dgDetail.Columns(e.ColumnIndex).ReadOnly = False
                    Else
                        dgDetail.Columns(e.ColumnIndex).ReadOnly = True
                    End If
                End If
        End Select

        Call CalculGrid()

    End Sub

    Sub PutTextRawMatl()

        CmbSwRawMatl.SelectedValue = dgDetail.Rows(RowDetail).Cells("PoMatlId").Value
        CmbSwKSI.SelectedValue = dgDetail.Rows(RowDetail).Cells("POMatlDetID").Value

        dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = CmbSwRawMatl.Text + vbCrLf + CmbSwKSI.Text

        If IsDBNull(dgDetail.Rows(RowDetail).Cells("POMatlDia").Value) = False Then
            dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = dgDetail.Rows(RowDetail).Cells("PONotesItem").Value + _
            vbCrLf + "Size: " + Str(dgDetail.Rows(RowDetail).Cells("POMatlDia").Value) + " dia."
        End If

        If IsDBNull(dgDetail.Rows(RowDetail).Cells("POMatlInsideDia").Value) = False Then
            dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = dgDetail.Rows(RowDetail).Cells("PONotesItem").Value + _
            vbCrLf + "Size: " + Str(dgDetail.Rows(RowDetail).Cells("POMatlInsideDia").Value) + " Inside dia."
        End If

        If IsDBNull(dgDetail.Rows(RowDetail).Cells("POMatlForm").Value) = False Then
            dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = dgDetail.Rows(RowDetail).Cells("PONotesItem").Value + _
            vbCrLf + "Material Form: " + dgDetail.Rows(RowDetail).Cells("POMatlForm").Value
        End If

        If IsDBNull(dgDetail.Rows(RowDetail).Cells("POMatlSource").Value) = False Then
            If dgDetail.Rows(RowDetail).Cells("POMatlSource").Value = 1 Then
                dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = dgDetail.Rows(RowDetail).Cells("PONotesItem").Value + vbCrLf + _
                "Domestic Mill Source Only (US)"
            End If
        End If

    End Sub

    Sub CalculGrid()

        On Error Resume Next

        Dim TotalPO As Decimal = 0
        Dim ValGST As Decimal = 0
        Dim ValQST As Decimal = 0
        Dim ValTVH As Decimal = 0
        Dim ValPo As Decimal = 0

        txtValItems.Text = 0
        txtValGST.Text = 0
        txtValQST.Text = 0
        txtValTVH.Text = 0
        txtValPO.Text = 0

        If dgDetail.Rows.Count > 0 Then
            Dim I As Integer = 0
            For I = 0 To dgDetail.Rows.Count - 1
                If IsDBNull(Me.dgDetail("POQty", I).Value) = False And _
                    IsDBNull(Me.dgDetail("POPrice", I).Value) = False Then
                    If IsDBNull(Me.dgDetail.Item("POItemescompte", I).Value) = True Or _
                        IsNothing(Me.dgDetail.Item("POItemescompte", I).Value) = True Then
                        Me.dgDetail("Valitem", I).Value = Me.dgDetail("POQty", I).Value * (Me.dgDetail("POPrice", I).Value + Nz.Nz(Me.dgDetail("PORMSPrice", I).Value))
                    Else
                        Me.dgDetail("Valitem", I).Value = _
                        Me.dgDetail("POQty", I).Value * _
                        ((Me.dgDetail("POPrice", I).Value * (1 - Me.dgDetail.Item("POItemescompte", I).Value / 100)) + Nz.Nz(Me.dgDetail("PORMSPrice", I).Value))
                    End If
                End If
                TotalPO = Math.Round((TotalPO + Me.dgDetail("Valitem", I).Value), 4)
            Next
        End If

        ValGST = TotalPO * txtGST.Text
        'ValQST = (TotalPO + ValGST) * txtQST.Text
        ValQST = TotalPO * txtQST.Text
        ValTVH = TotalPO * txtTVH.Text
        ValPo = TotalPO + ValGST + ValQST + ValTVH

        txtValItems.Text = TotalPO.ToString("C2")
        txtValGST.Text = ValGST.ToString("C2")
        txtValQST.Text = ValQST.ToString("C2")
        txtValTVH.Text = ValTVH.ToString("C2")
        txtValPO.Text = ValPo.ToString("C2")

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                CmdNew.Enabled = False
                CmdMod.Enabled = False
                CmdCancel.Enabled = True
                CmdSave.Enabled = False
                CmdPrint.Enabled = True
                CmdView.Enabled = True

                FindPO.Enabled = False
                FindPO.Focus()

                dgDetail.Refresh()

                Select Case SwOper
                    Case "New"
                        Call PutPONumber(sender, e)
                    Case "Mod"
                End Select

                Me.BindingContext(dsMain, "tblPOMaster").EndCurrentEdit()
                Me.BindingContext(dsMain, "tblPODetails").EndCurrentEdit()

                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    intCust = daPOMaster.Update(dsMain.Tables("tblPOMaster").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    intCont = daPoDetail.Update(dsMain.Tables("tblPODetails").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    intCust += daPOMaster.Update(dsMain.Tables("tblPOMaster").Select("", "", DataViewRowState.Deleted))

                    dgDetail.Refresh()

                End If

                dsMain.AcceptChanges()

                If cmMaster.Count > 0 Then
                    cmMaster.EndCurrentEdit()
                End If

                If cmDetail.Count > 0 Then
                    cmDetail.EndCurrentEdit()
                End If

                dgDetail.Visible = False
                Call DisableScreen()

                SwPo = 0
                SwOper = ""

                ButtCancel.Visible = False
                CmdMat.Visible = False
                LblCmdMat.Visible = False

                AlustaProcess()

            Catch ex As Exception
                MsgBox("Exception occured - Save Action  " & ex.Message)

            End Try

        End If
    End Sub

    Sub ValPo()

        Dim SwM3Code As String = ""

        SwM3Code = CallClass.ReturnStrWithParInt("cspReturnSupplierM3Code", CmbPOSupp.SelectedValue)
        If SwM3Code = "False" Or Len(Trim(SwM3Code)) = 0 Or Trim(SwM3Code) = "CREDIT CARD" Then

            MsgBox("!!! ERROR !!! Missing M3 supplier code. Please contact LAC A/P department.")

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "Purchasing Module"
            strBody = "This is to inform you that for the PO Number: " & FindPO.Text & vbCrLf
            strBody = strBody & "Supplier Name: " & CmbPOSupp.Text & vbCrLf
            strBody = strBody & " the M3 Supplier code need to be updated."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Comptabilite.Montreal@lisi-aerospace.com"))
            client.Send(email)

            SwVal = False
            Exit Sub
        End If


        If Len(Trim(CmbPOGL.SelectedValue)) = 0 Or IsDBNull(CmbPOGL.SelectedValue) = True Or IsNothing(CmbPOGL.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! GL# is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPOSupp.SelectedValue)) = 0 Or IsDBNull(CmbPOSupp.SelectedValue) = True Or IsNothing(CmbPOSupp.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Supplier Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPODropShip.SelectedValue)) = 0 Or IsDBNull(CmbPODropShip.SelectedValue) = True Or IsNothing(CmbPODropShip.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Drop Ship Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPOShipVia.SelectedValue)) = 0 Or IsDBNull(CmbPOShipVia.SelectedValue) = True Or IsNothing(CmbPOShipVia.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Ship Via is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbSalesTax.SelectedValue)) = 0 Or IsDBNull(CmbSalesTax.SelectedValue) = True Or IsNothing(CmbSalesTax.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Sales Taxes are Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbDevise.SelectedValue)) = 0 Or IsDBNull(CmbDevise.SelectedValue) = True Or IsNothing(CmbDevise.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Devise is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtMastPODueDate.Text)) = 0 Or IsDBNull(txtMastPODueDate.Text) = True Or IsNothing(CmbDevise.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! PO Due Date is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPOReq.Text)) = 0 Or IsDBNull(txtPOReq.Text) = True Then
            MsgBox("!!! ERROR !!! PO Requester is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPOModDate.Text)) = 0 Or IsDBNull(txtPOModDate.Text) = True Then
            txtPOModDate.Text = Now.ToShortDateString
        End If

        Dim SwMatlType As Integer = 1
        Dim SwMatlDia As Integer = 1
        Dim II As Integer
        For II = 1 To dgDetail.Rows.Count - 1

            Dim K As Integer
            K = Nz.Nz(dgDetail.Item("POItem", II - 1).Value)
            If K = 0 Then
                MsgBox("!!! ERROR !!! PO item / line number is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgDetail.Item("POItem", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! PO item / line number is Empty.")
                SwVal = False
                Exit Sub
            End If


            If dgDetail.Item("POStatusLine", II - 1).Value = "20" Then

                If IsDBNull(dgDetail.Item("POProdID", II - 1).Value) = True Then
                    MsgBox(" Product Description is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If IsDBNull(dgDetail.Item("POStatusLine", II - 1).Value) = True Then
                    MsgBox(" PO Status Line is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If IsDBNull(dgDetail.Item("POCostCenter", II - 1).Value) = True Then
                    MsgBox(" PO Cost Center is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If CmbPOType.Text = "Processing" Or CmbPOType.Text = "Sub-Contracting" Or CmbPOType.Text = "Grinding" Or CmbPOType.Text = "Components" Then
                    If IsDBNull(dgDetail.Item("POMpoID", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Mpo Number is Empty.")
                        SwVal = False
                        Exit Sub
                    End If
                End If

                If IsDBNull(dgDetail.Item("POMpoID", II - 1).Value) = False Then
                    If CmbPOType.Text <> "Processing" And CmbPOType.Text <> "Sub-Contracting" And CmbPOType.Text <> "Grinding" And CmbPOType.Text <> "Components" Then
                        MsgBox("!!! ERROR !!! Your PO Type must to be Processing or Sub-Contracting or Grinding or Components .")
                        SwVal = False
                        Exit Sub
                    End If
                End If

                If IsDBNull(dgDetail.Item("POUM", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! PO UM is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If dgDetail.Item("ValItem", II - 1).Value = 0 Then
                    MsgBox("!!! ERROR !!! Item Value is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                Dim SwProdDescr As String = ""
                If CmbPOType.Text <> "Processing" And CmbPOType.Text <> "Sub-Contracting" Then

                    SwProdDescr = CallClass.ReturnStrWithParInt("cspReturnPoProdDescr", dgDetail.Item("PoProdID", II - 1).Value)

                    If InStr(SwProdDescr, "Cadmium", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Chrome Plating", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Chrome Plate", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Chrome", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Chromage", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Cleaning", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Heat tr", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Heat treat", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Heat Treatment", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Nickel Cad", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Passivate", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Silver Plating", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Silver Plate", vbTextCompare) <> 0 Or _
                        InStr(SwProdDescr, "Stress Relief", vbTextCompare) <> 0 Then
                        MsgBox("!!! ERROR !!! Your PO Type must to be Processing or Sub-Contracting.")
                        SwVal = False
                        Exit Sub
                    End If
                End If

                Dim TestPos As Integer = 0
                SwProdDescr = CallClass.ReturnStrWithParInt("cspReturnPoProdDescr", dgDetail.Item("PoProdID", II - 1).Value)
                TestPos = InStr(SwProdDescr, "Heat Tr", vbTextCompare)
                If TestPos <> 0 Then
                    If IsDBNull(dgDetail.Item("PONotesItem", II - 1).Value) = False Then
                        If InStr(dgDetail.Item("PONotesItem", II - 1).Value, "B30", vbTextCompare) <> 0 Or _
                        InStr(dgDetail.Item("PONotesItem", II - 1).Value, "B31", vbTextCompare) <> 0 Or _
                        InStr(dgDetail.Item("PONotesItem", II - 1).Value, "BACB", vbTextCompare) <> 0 Then
                            MsgBox("!!! ERROR !!! You Can Not send outside for Heat Treatment this PO.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If
                End If

                If CmbPOType.Text = "Raw Material" Then
                    If IsDBNull(dgDetail.Item("PoMatlID", II - 1).Value) = False Then
                        If II - 2 >= 0 Then
                            If IsDBNull(dgDetail.Item("PoMatlID", II - 2).Value) = False Then
                                If dgDetail.Item("PoMatlID", II - 1).Value <> dgDetail.Item("PoMatlID", II - 2).Value Then
                                    SwMatlType = SwMatlType + 1
                                End If
                            End If
                        End If
                    End If

                    If IsDBNull(dgDetail.Item("POMatlDia", II - 1).Value) = False Then
                        If II - 2 >= 0 Then
                            If IsDBNull(dgDetail.Item("POMatlDia", II - 2).Value) = False Then
                                If dgDetail.Item("POMatlDia", II - 1).Value <> dgDetail.Item("POMatlDia", II - 2).Value Then
                                    SwMatlDia = SwMatlDia + 1
                                End If
                            End If
                        End If
                    End If
                End If



            End If

        Next

        If CmbPOType.Text = "CAPEX" Then
            If Len(Trim(txtCapexNo.Text)) = 0 Or IsDBNull(txtCapexNo.Text) = True Then
                MsgBox("!!! ERROR !!! CAPEX Project No. is Empty.")
                SwVal = False
                Exit Sub
            End If
            If Len(Trim(txtCapexDescr.Text)) = 0 Or IsDBNull(txtCapexDescr.Text) = True Then
                MsgBox("!!! ERROR !!! CAPEX Project description is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbPOType.Text = "Raw Material" Then
            If SwMatlType = 0 Then
                MsgBox("!!! ERROR !!! Material Type is Empty.")
                SwVal = False
                Exit Sub
            End If

            If SwMatlType > 1 Then
                MsgBox("!!! ERROR !!! Only one Material Type per PO.")
                SwVal = False
                Exit Sub
            End If

            If SwMatlDia = 0 Then
                MsgBox("!!! ERROR !!! Material Diameter is Empty.")
                SwVal = False
                Exit Sub
            End If

            If SwMatlDia > 1 Then
                MsgBox("!!! ERROR !!! Only one Material Dia per PO.")
                SwVal = False
                Exit Sub
            End If
        End If

        Dim SwSuppID As Integer = 0
        Dim SwSuppStatus As String = ""
        Dim SwSuppGroup As String = ""

        SwSuppID = CmbPOSupp.SelectedValue
        SwSuppStatus = CallClass.ReturnStrWithParInt("cspReturnSupplierStatus", SwSuppID)
        If SwSuppStatus <> "Approved" And SwSuppStatus <> "Conditional" Then
            MsgBox("!!! ERROR !!! Approved Supplier Status")
            SwVal = False
            Exit Sub
        End If

        ' inactive stop the and email to QA and buyer

        ' do not use the cond date if it's group 1. - done I removed the condition on Feb 16, 2017

        SwSuppGroup = CallClass.ReturnStrWithParInt("cspReturnSupplierGroupNo", SwSuppID)
        If Val(SwSuppGroup) = 2 Or Val(SwSuppGroup) = 3 Then
            Dim DateStart As Date
            DateStart = CallClass.ReturnStrWithParInt("cspReturnSupplierDateExp", SwSuppID)
            If DateStart < Now.ToShortDateString Then
                MsgBox("!!! ERROR !!! Approved Supplier Date")
                SwVal = False
                Exit Sub
            End If
        End If


        'Dim SwDate As Date
        'Dim NewDate As Date
        'Dim SwDays As Integer = 0
        'SwDate = CallClass.ReturnStrWithParInt("cspReturnLastSuppPODate", CmbPOSupp.SelectedValue)
        'NewDate = Now()
        'SwDays = DateDiff(DateInterval.Day, NewDate, SwDate)

        'If SwDays > 732 Then
        '    MsgBox("!!! ERROR !!! Supplier InActive - Please contact QA department")
        '    SwVal = False
        '    Exit Sub
        'End If

        Dim SwDate As Date
        Dim NewDate As Date
        Dim SwDays As Integer = 0

        Try
            SwDate = CallClass.ReturnStrWithParInt("cspReturnLastSuppPODate", CmbPOSupp.SelectedValue)
        Catch ex As Exception
            ' no PO issued for this supplier
            GoTo NextTestVal
        End Try

        NewDate = Now()
        SwDays = DateDiff(DateInterval.Day, NewDate, SwDate)
        If SwDays > 732 Then
            MsgBox("!!! ERROR !!! Supplier InActive - Please contact QA department")
            ResetButton()
            Exit Sub
        End If

NextTestVal:

        SwVal = True

    End Sub

    Sub CheckSupplier()

        Dim SwM3Code As String = ""
        Dim KeepSuppName As String = ""

        KeepSuppName = Nz.Nz(CmbPOSupp.SelectedItem("SuppName"))

        SwM3Code = CallClass.ReturnStrWithParInt("cspReturnSupplierM3Code", CmbPOSupp.SelectedValue)
        If SwM3Code = "False" Or Len(Trim(SwM3Code)) = 0 Or Trim(SwM3Code) = "CREDIT CARD" Then

            Call PutReadOnly()

            MsgBox("!!! ERROR !!! Missing M3 supplier code. Please contact LAC A/P department.")

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "Purchasing Module"
            strBody = "This is to inform you that for the PO Number: " & FindPO.Text & vbCrLf
            strBody = strBody & "Supplier Name: " & KeepSuppName & vbCrLf
            strBody = strBody & " the M3 Supplier code need to be updated."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Comptabilite.Montreal@lisi-aerospace.com"))
            client.Send(email)

            Exit Sub

        End If

        Dim SwDate As Date
        Dim NewDate As Date
        Dim SwDays As Integer = 0
        Dim SwCode As Integer = 0


        Try
            SwDate = CallClass.ReturnStrWithParInt("cspReturnLastSuppPODate", CmbPOSupp.SelectedValue)
        Catch ex As Exception
            ' no PO issued for this supplier
            GoTo NextTest
        End Try

        NewDate = Now()
        SwDays = DateDiff(DateInterval.Day, NewDate, SwDate)
        If SwDays > 732 Then
            MsgBox("!!! ERROR !!! Supplier InActive - Please contact QA department")
            ResetButton()
            Exit Sub
        End If



        'Try
        '    SwCode = CallClass.ReturnStrWithParInt("cspReturnLastSuppPODate", CmbPOSupp.SelectedValue)
        'Catch ex As Exception
        '    ' no PO issued for this supplier 
        '    GoTo NextTest
        'End Try

        'NewDate = Now()
        'SwDays = DateDiff(DateInterval.Day, NewDate, SwDate)
        'If SwDays > 732 Then
        '    MsgBox("!!! ERROR !!! Supplier InActive - Please contact QA department")
        '    ResetButton()
        '    Exit Sub
        'End If

NextTest:

        Dim SwSuppID As Integer = 0
        Dim SwSuppStatus As String = ""
        Dim SwSuppGroup As String = ""
        SwSuppID = CmbPOSupp.SelectedValue
        SwSuppStatus = CallClass.ReturnStrWithParInt("cspReturnSupplierStatus", SwSuppID)
        If SwSuppStatus <> "Approved" And SwSuppStatus <> "Conditional" Then
            MsgBox("!!! ERROR !!! Supplier Status - Please contact QA department")
            ResetButton()
            Exit Sub
        End If

        SwSuppGroup = CallClass.ReturnStrWithParInt("cspReturnSupplierGroupNo", SwSuppID)
        If Val(SwSuppGroup) = 2 Or Val(SwSuppGroup) = 3 Then
            Dim DateStart As Date
            DateStart = CallClass.ReturnStrWithParInt("cspReturnSupplierDateExp", SwSuppID)
            If DateStart < Now.ToShortDateString Then
                MsgBox("!!! ERROR !!!  Supplier Next Audit Date - Please contact QA department")
                ResetButton()
                Exit Sub
            End If
        End If
    End Sub

    Sub ResetButton()

        If WhatAction = 0 Then          'only read & Print
            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
            CmdCancel.Enabled = True
        Else
            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
            CmdCancel.Enabled = True
        End If

        CmdSupp.Enabled = False
        CmdRemarks.Enabled = False
        CmdSeePO.Enabled = True

        SwOper = ""
        SwPo = 0
        txtRMREQNo.Text = ""

        Call DisableScreen()

        dsMain.RejectChanges()
        dgDetail.Visible = False
        dgDetail.Refresh()

        FindPO.Enabled = False        'inainte de a schimba
        FindPO.Focus()

        txtValItems.Text = 0
        txtValGST.Text = 0
        txtValQST.Text = 0
        txtValTVH.Text = 0
        txtValPO.Text = 0

        txtGST.Text = 0
        txtQST.Text = 0
        txtTVH.Text = 0

    End Sub
    Sub PutPONumber(ByVal sender As System.Object, ByVal e As System.EventArgs)

        strSQL = "SELECT tblLisiKey.ValueKey FROM tblLisiKey " _
                & "WHERE ((tblLisiKey.ModuleKey)= '" & "PO" & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cnSqlServer)
        Dim myReader1 As Data.SqlClient.SqlDataReader

        Try
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            myReader1 = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader1.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! PO Number cannot be generated.")
                CmdCancel_Click(sender, e)
            Else
                While myReader1.Read()
                    PoLisiKey = myReader1.GetValue(0)
                End While

                myReader1.Close()
                myReader1.Dispose()

                If PoLisiKey = 0 Then
                    Call UpdateLisiPOKey()
                    Call FindNewMonthLisiDate(sender, e)
                Else
                    FindNextPONumber(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Exception occured - Put PO Number   " & ex.Message)
            CmdCancel_Click(sender, e)
        Finally
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If
        End Try

    End Sub

    Sub FindNextPONumber(ByVal sender As System.Object, ByVal e As System.EventArgs)

        strSQL = "SELECT DISTINCT MAX(DISTINCT PONo) AS MaxPo FROM dbo.tblPOMaster " _
                & "WHERE LEFT(PONo, 2) = RIGHT(CONVERT(varchar(4), YEAR(GETDATE())), 2)"

        Dim myNo As String
        Dim myPos As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cnSqlServer)
        Dim myReader2 As Data.SqlClient.SqlDataReader

        Try
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            myReader2 = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader2.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! PO Number cannot be generated.")
                CmdCancel_Click(sender, e)
            Else
                While myReader2.Read()
                    If IsDBNull(myReader2.GetString(0)) OrElse IsNothing(myReader2.GetString(0)) Then
                        MsgBox("Exception occured - PO Number cannot be generate. Null value. ")
                        CmdCancel_Click(sender, e)
                    Else
                        myPos = InStr(1, myReader2.GetString(0), "-")
                        If myPos = 0 Then
                            FindPO.Text = Trim(Str(CInt(Nz.Nz(myReader2.GetString(0), "")) + 1))
                        Else
                            myNo = Microsoft.VisualBasic.Left(myReader2.GetString(0), myPos - 1)
                            FindPO.Text = CInt(myNo) + 1
                        End If
                    End If
                End While
                myReader2.Close()
                myReader2.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - FindNextPONumber   " & ex.Message)
        Finally
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If
        End Try

    End Sub

    Sub FindNewMonthLisiDate(ByVal sender As System.Object, ByVal e As System.EventArgs)

        strSQL = "SELECT tblLisiDate.LisiDateTo FROM tblLisiDate " _
                        & "WHERE ((tblLisiDate.StatusMonth)= '" & "OPEN" & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cnSqlServer)
        Dim myReader3 As Data.SqlClient.SqlDataReader

        Try
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            myReader3 = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader3.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! PO Number cannot be generated.")
                CmdCancel_Click(sender, e)
            Else
                Dim txtMonth As String
                Dim txtYear As String
                While myReader3.Read()
                    txtYear = Trim(Str(Format(myReader3.GetValue(0), "yy")))
                    txtMonth = Trim(Format(myReader3.GetValue(0), "MM"))

                    FindPO.Text = Trim(Str(txtYear)) + Trim(txtMonth) + "001"
                End While
                myReader3.Close()
                myReader3.Dispose()

            End If
        Catch ex As Exception
            MsgBox("Exception occured - FindMonthLisiDate   " & ex.Message)
        Finally
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

    End Sub

    Sub UpdateLisiPOKey()

        strSQL = "UPDATE tblLisiKey Set ValueKey = 99 " _
            & "WHERE ((tblLisiKey.ModuleKey)= '" & "PO" & "')"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)

            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Exception occured - UpdateLisiPOKey   " & ex.Message)
        Finally

            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

    End Sub

    Private Sub CmdMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMod.Click
        SwOper = "Mod"
        txtRMREQNo.Text = ""


        txtPOModDate.Text = Now.ToShortDateString
        LblCapex.Visible = False
        txtCapexNo.Visible = False
        LblCapexDescr.Visible = False
        txtCapexDescr.Visible = False

        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSupp.Enabled = True
        CmdSave.Enabled = True
        CmdCancel.Enabled = True
        CmdPrint.Enabled = False
        CmdView.Enabled = True

        CmdSupp.Enabled = True
        CmdRemarks.Enabled = True
        CmdSeePO.Enabled = False

        CmdMat.Visible = False
        LblCmdMat.Visible = False

        FindPO.Enabled = True
        FindPO.Text = ""
        FindPO.Focus()

    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click

        If WhatAction = 0 Then          'only read & Print
            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
            CmdCancel.Enabled = True
        Else
            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdView.Enabled = True
            CmdCancel.Enabled = True
        End If

        CmdSupp.Enabled = False
        CmdRemarks.Enabled = False
        CmdSeePO.Enabled = True

        SwOper = ""
        SwPo = 0
        txtRMREQNo.Text = ""
        txtPOReq.Text = ""
        txtCapexDescr.Text = ""
        txtCapexNo.Text = ""
        txtPOModDate.Text = ""

        CmbPOType.Text = ""
        CmbPOType.SelectedText = "General"

        Call DisableScreen()

        dsMain.RejectChanges()
        dgDetail.Visible = False
        dgDetail.Refresh()

        FindPO.Enabled = False        'inainte de a schimba
        FindPO.Focus()

        txtValItems.Text = 0
        txtValGST.Text = 0
        txtValQST.Text = 0
        txtValTVH.Text = 0
        txtValPO.Text = 0

        txtGST.Text = 0
        txtQST.Text = 0
        txtTVH.Text = 0

        LblCapex.Visible = False
        txtCapexNo.Visible = False
        LblCapexDescr.Visible = False
        txtCapexDescr.Visible = False

    End Sub

    Sub ClearScreen()
        CmbPOType.DataBindings.Clear()
        CmbPoStatus.DataBindings.Clear()
        CmbPOBuyer.DataBindings.Clear()
        CmbPOGL.DataBindings.Clear()
        CmbPOSupp.DataBindings.Clear()
        CmbPORefA.DataBindings.Clear()
        CmbPOTerms.DataBindings.Clear()
        CmbPODropShip.DataBindings.Clear()
        CmbPOShipVia.DataBindings.Clear()
        CmbPoFOB.DataBindings.Clear()
        txtMastPODueDate.DataBindings.Clear()
        txtReqNo.DataBindings.Clear()
        txtPOLeadTime.DataBindings.Clear()
        CmbSalesTax.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()

        ChkCOC.DataBindings.Clear()
        ChkMill.DataBindings.Clear()
        ChkTest.DataBindings.Clear()

        txtPORemarks.DataBindings.Clear()
        txtPONotes.DataBindings.Clear()

        txtGST.DataBindings.Clear()
        txtQST.DataBindings.Clear()
        txtTVH.DataBindings.Clear()

    End Sub

    Private Sub FindPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FindPO.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If SwPo = 0 Then
                If Len(Trim(FindPO.Text)) = 0 Or IsDBNull(FindPO.Text) = True Then
                    Exit Sub
                Else
                    Call FindPOInfo(sender, e)
                    SwPo = 1
                End If
            End If
        End If
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        SwEndUser = ""

        If CmbPOType.Text = "Processing" Or _
            CmbPOType.Text = "Sub-Contracting" Then
            Call CheckEndUser()
        End If

        Call DisableScreen()
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSupp.Enabled = False
        CmdSave.Enabled = False
        CmdCancel.Enabled = True
        CmdPrint.Enabled = False
        CmdView.Enabled = True

        If Len(Trim(FindPO.Text)) = 0 Or IsDBNull(FindPO.Text) = True Then
            MsgBox("Purchase Order Number is Empty.")
        Else
            If SwOper = "" Then
                SwOper = "Print"
                FindPO.Enabled = False
                FindPO.Focus()
                Call PrintPO()
                'Call PrintTerms()
            Else
                Call PrintPO()
                'Call PrintTerms()
            End If
        End If
    End Sub

    Sub CheckEndUser()

        Dim SwMPOId As Integer = 0

        SwMPOId = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMpoID").Value)
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

    Sub PrintPO()

        txtPosted.Text = KeepNo

        strSQL = "UPDATE tblPoMaster Set POPosted = '" & Val(txtPosted.Text) + 1 & "' " _
                    & "WHERE ((tblPOMaster.PONo)= '" & FindPO.Text & "')"

        txtPosted.Text = Val(txtPosted.Text) + 1

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            'cnSqlServer.Open()

            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Exception occured - Update PoPosted   " & ex.Message)
        Finally
            'cnSqlServer.Close()
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

        Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptPOSupp()
            rptPO.Load("..\rptposupp.rpt")
            pdFind.Value = FindPO.Text
            pdEndUser.Value = SwEndUser

            pvFindCollection.Add(pdFind)
            pvEndUserCollection.Add(pdEndUser)

            rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvFindCollection)
            rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pvEndUserCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()

            '==========

            If txtPosted.Text = 0 Or IsDBNull(txtPosted.Text) = True Or txtPosted.Text = 1 Then

                frmPOMasterPrint.CrystalReportViewer1.Refresh()

                Dim sSource As String = ""
                Dim sTarget As String = ""
                Dim FileNameStr As String = ""

                FileNameStr = ""
                FileNameStr = "LAC_LAC_" + FindPO.Text + "_FS1002.pdf"

                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                CrDiskFileDestinationOptions.DiskFileName = "\\Dcbwbp25\movex\OA\LAC\LAC\" + FileNameStr

                CrExportOptions = rptPO.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With
                rptPO.Export()



            End If

        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Sub PrintTerms()

        Try
            Dim rptPO As New rptLisiPOTermsEnglish
            rptPO.Load("..\rptLisiPOTermsEnglish.rpt")
            frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
            frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
            frmPOPrintAll.CrystalReportViewer1.Zoom(2)
            frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
            frmPOPrintAll.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Print Terms ERROR")
        End Try

    End Sub

    Sub FindPOInfo(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FindPO.Enabled = False

        If SwOper = "Print" Then
            Call PrintPO()
            SwOper = ""
        Else
            SwPo = 1
            Call VerifyPOPrint()

            If VerPo = 9 Then    'po# missing
                Exit Sub
            End If

            Call PutPOInfo()

            Select Case CmbPOType.Text
                Case "Raw Material"
                    Me.PoMatlID.Visible = True
                    Me.POMatlDetID.Visible = True
                    Me.POMatlDia.Visible = True
                    Me.POMatlInsideDia.Visible = True
                    Me.POEngMatlDia.Visible = True
                    Me.POMatlForm.Visible = True
                    Me.POForStock.Visible = True
                    Me.POForOrders.Visible = True
                    'Me.POMatlSource.Visible = True
                    Me.POMatlNotes.Visible = True
                    Me.CmdTextRawMatl.Visible = True

                    CmdMat.Visible = True
                    LblCmdMat.Visible = True

                    CmbPOSupp.Enabled = False

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = True
                    LabelReqNo.Visible = True

                    LblCapex.Visible = False
                    txtCapexNo.Visible = False
                    LblCapexDescr.Visible = False
                    txtCapexDescr.Visible = False

                Case "CAPEX"

                    LblCapex.Visible = True
                    txtCapexNo.Visible = True
                    LblCapexDescr.Visible = True
                    txtCapexDescr.Visible = True

                    Me.PoMatlID.Visible = False
                    Me.POMatlDetID.Visible = False
                    Me.POMatlDia.Visible = False
                    Me.POMatlInsideDia.Visible = False
                    Me.POEngMatlDia.Visible = False
                    Me.POMatlForm.Visible = False
                    Me.POForStock.Visible = False
                    Me.POForOrders.Visible = False
                    'Me.POMatlSource.Visible = False
                    Me.POMatlNotes.Visible = False
                    Me.CmdTextRawMatl.Visible = False
                    CmdMat.Visible = False
                    LblCmdMat.Visible = False

                    CmbPOSupp.Enabled = True

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = False
                    LabelReqNo.Visible = False

                Case Else

                    Me.PoMatlID.Visible = False
                    Me.POMatlDetID.Visible = False
                    Me.POMatlDia.Visible = False
                    Me.POMatlInsideDia.Visible = False
                    Me.POEngMatlDia.Visible = False
                    Me.POMatlForm.Visible = False
                    Me.POForStock.Visible = False
                    Me.POForOrders.Visible = False
                    'Me.POMatlSource.Visible = False
                    Me.POMatlNotes.Visible = False
                    Me.CmdTextRawMatl.Visible = False

                    CmdMat.Visible = False
                    LblCmdMat.Visible = False

                    CmbPOSupp.Enabled = True

                    txtReqNo.ReadOnly = True
                    txtReqNo.Visible = False
                    LabelReqNo.Visible = False

                    LblCapex.Visible = False
                    txtCapexNo.Visible = False
                    LblCapexDescr.Visible = False
                    txtCapexDescr.Visible = False
            End Select

            Select Case CmbPoStatus.Text
                Case "Accepted"
                    MsgBox("This PO has already been accepted. Action denied.")
                    Call PutReadOnly()
                Case "Payed"
                    MsgBox("This PO has already been payed. Action denied.")
                    Call PutReadOnly()
                Case "Cancelled"
                    MsgBox("This PO has been cancelled. Action denied.")
                    Call PutReadOnly()
                Case "AMMD"
                    MsgBox("PO allready has an Amendment. Action denied.")
                    Call PutReadOnly()
                Case "Open"
                    If WhatAction = 0 Then      'only read & print PO
                        Call PutReadOnly()
                    Else

                        Call CheckReceiving()

                        Select Case VerPo
                            Case 0          'not posted
                                Call PutEnableOnly()
                                If SwOper = "Mod" Then
                                    ButtCancel.Visible = True
                                End If
                            Case 1          ' posted
                                Dim reply As DialogResult
                                reply = MsgBox("Do you want to create a new Amendment for the Purchase Order ? ", MsgBoxStyle.YesNo)
                                If reply = Windows.Forms.DialogResult.Yes Then
                                    Call CreateNewPoRev(sender, e)
                                    'Call PutEnableOnly()
                                    Call PutReadOnly()
                                Else
                                    Call PutReadOnly()
                                End If
                        End Select
                    End If
            End Select
        End If

    End Sub

    Sub CheckReceiving()
        Dim strSearch As String
        Dim SwSum As String

        If InStr(FindPO.Text, "-") <> 0 Then
            strSearch = Microsoft.VisualBasic.Left(FindPO.Text, InStr(FindPO.Text, "-") - 1)
        Else
            strSearch = Trim(FindPO.Text)
        End If

        SwSum = CallClass.TakeFinalSt("cspReturnPOReceivingData", FindPO.Text)
        If SwSum = "False" Then
            Exit Sub
        Else
            VerPo = 0
            MsgBox("Allready we have a Receiving on this PO. The system it will skip the Amendment / Cancellation for the PO.")
        End If

    End Sub

    Sub PutReadOnly()

        Call DisableScreen()
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSupp.Enabled = False
        CmdSave.Enabled = False
        CmdCancel.Enabled = True
        CmdPrint.Enabled = True
        CmdView.Enabled = True

        CmdSupp.Enabled = False
        CmdSeePO.Enabled = False
        CmdRemarks.Enabled = False

    End Sub

    Sub PutEnableOnly()

        Call EnableScreen()
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSave.Enabled = True
        CmdCancel.Enabled = True
        CmdPrint.Enabled = True
        CmdView.Enabled = True

        CmdSupp.Enabled = True
        CmdSeePO.Enabled = False
        CmdRemarks.Enabled = True

    End Sub

    Sub VerifyPOPrint()

        VerPo = 9

        strSQL = "SELECT POPosted FROM tblPoMaster WHERE ((tblPOMaster.PONo)= '" & FindPO.Text & "')"

        Dim mySqlConn As New Data.SqlClient.SqlConnection(strConnection)
        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, mySqlConn)
        Dim myReader4 As Data.SqlClient.SqlDataReader

        Try
            If mySqlConn.State = ConnectionState.Closed Then
                mySqlConn.Open()
            End If
            myReader4 = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader4.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("Access Denied. PO# Can't be identified.")
                Call PutReadOnly()
                VerPo = 9
            Else
                While myReader4.Read()
                    If IsDBNull(myReader4.GetValue(0)) Then
                        VerPo = 0       ' Not posted
                    Else
                        KeepNo = myReader4.GetValue(0)
                        '=======================================================================
                        'If myReader4.GetValue(0) >= 2 Then
                        'MessageBox.Show("PO was Posted.")
                        'VerPo = 1
                        'Else
                        VerPo = 0
                        'End If
                    End If
                End While

                myReader4.Close()
                myReader4.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If mySqlConn.State = ConnectionState.Open Then
                mySqlConn.Close()
            End If

        End Try

    End Sub

    Sub PutPOInfo()

        Dim strSQLMast As String = "Select * FROM tblPOMaster WHERE PONo = '" & FindPO.Text & "'"
        Dim strSQLDet As String = "SELECT * FROM tblPODetails Order by POMasterID, POItem"

        Dim commMast As New SqlClient.SqlCommand(strSQLMast, cnSqlServer)
        Dim commDet As New SqlClient.SqlCommand(strSQLDet, cnSqlServer)

        daPOMaster.SelectCommand = commMast
        daPoDetail.SelectCommand = commDet

        cmMaster.EndCurrentEdit()
        cmDetail.EndCurrentEdit()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daPOMaster.FillSchema(dsMain, SchemaType.Source, "tblPoMaster")
        daPoDetail.FillSchema(dsMain, SchemaType.Source, "tblPODetails")

        daPOMaster.Fill(dsMain, "tblPOMaster")
        Dim MastID As DataColumn = dsMain.Tables("tblPOMaster").Columns("POMasterID")
        MastID.AutoIncrement = True
        MastID.AutoIncrement = True
        MastID.AutoIncrementStep = -1
        MastID.AutoIncrementSeed = -1
        MastID.ReadOnly = False

        daPoDetail.Fill(dsMain, "tblPODetails")
        Dim DetID As DataColumn = dsMain.Tables("tblPODetails").Columns("PODetailID")
        DetID.AutoIncrement = True
        DetID.AutoIncrementStep = -1
        DetID.AutoIncrementSeed = -1
        DetID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("MastDet", _
                .Tables("tblPOMaster").Columns("POMasterID"), _
                .Tables("tblPODetails").Columns("POMasterID"), True)
        End With

        cmMaster = CType(BindingContext(dsMain, "tblPOMaster"), CurrencyManager)
        cmDetail = CType(BindingContext(dsMain, "tblPODetails"), CurrencyManager)

        Call ClearScreen()

        Call PutBuyer()
        Call PutGl()
        Call PutSupplier()

        Call PutDropShip()
        Call PutShipVia()
        Call PutSalesTax()
        Call PutDevise()

        CmbPOType.DataBindings.Add("Text", dsMain, "tblPOMaster.POType")
        CmbPoStatus.DataBindings.Add("Text", dsMain, "tblPOMaster.POStatus")
        CmbPOBuyer.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POBuyer")
        CmbPOGL.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAccount")
        CmbPOSupp.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSuppID")

        Call PutPORefA()

        CmbPORefA.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAttnID")
        CmbPOTerms.DataBindings.Add("Text", dsMain, "tblPOMaster.POCond")
        CmbPODropShip.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODropShipID")
        CmbPOShipVia.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POShipVia")
        CmbPoFOB.DataBindings.Add("Text", dsMain, "tblPOMaster.POFob")

        ChkCOC.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POCOC", True))
        ChkMill.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POMil", True))
        ChkTest.DataBindings.Add(New Binding("Checked", dsMain, "tblPOMaster.POTest", True))

        txtMastPODueDate.DataBindings.Add("Text", dsMain, "tblPOMaster.MasterPODueDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

        txtPOLeadTime.DataBindings.Add("Text", dsMain, "tblPOMaster.POSuppLeadTime")

        txtReqNo.DataBindings.Add("Text", dsMain, "tblPOMaster.PORMReqNo")

        txtPORemarks.DataBindings.Add("Text", dsMain, "tblPOMaster.PORemarks")
        txtPONotes.DataBindings.Add("Text", dsMain, "tblPOMaster.PONotes")
        CmbSalesTax.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSalesTaxID")
        CmbDevise.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODevise")
        txtGST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxGST")
        txtQST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxQST")
        txtTVH.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxTVH")

        Dim ii, jj As Integer
        ii = CmbSalesTax.SelectedValue
        jj = CmbDevise.SelectedValue

        LoadCmbProduct()
        LoadUMProduct()
        SetCtl()

        dgDetail.AutoGenerateColumns = False
        dgDetail.DataSource = dsMain
        dgDetail.DataMember = "tblPOMaster.MastDet"
        dgDetail.Visible = True

        Call CalculGrid()

    End Sub

    Sub CreateNewPoRev(ByVal sender As System.Object, ByVal e As System.EventArgs)

        OldPO = FindPO.Text
        txtPORev.Text = Str(Val(txtPORev.Text) + 1)
        txtPosted.Text = 0
        KeepNo = 0

        Dim myPos As String
        Dim myNO As String
        myPos = InStr(1, FindPO.Text, "-")
        If myPos = 0 Then
            FindPO.Text = FindPO.Text & "-" & Trim(Str(txtPORev.Text))
        Else
            myNO = Microsoft.VisualBasic.Left(FindPO.Text, myPos - 1)
            FindPO.Text = CInt(myNO) & "-" & Trim(Str(txtPORev.Text))
        End If

        Call DisableScreen()

        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdCancel.Enabled = False
        CmdSave.Enabled = True
        CmdPrint.Enabled = False
        CmdView.Enabled = True

        Call InsertMaster()
        Call InsertDetail(sender, e)
        Call PutStatusAmmd()

    End Sub

    Sub PutStatusAmmd()

        strSQL = "UPDATE tblPoMaster Set POStatus = 'AMMD' WHERE ((tblPOMaster.PONo)= '" & OldPO & "')"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cnSqlServer)
            'cnSqlServer.Open()
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Exception occured - Update PoPosted   " & ex.Message)
        Finally

            'cnSqlServer.Close()
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

    End Sub

    Sub InsertMaster()

        Dim command As SqlCommand = New SqlCommand("POMasterInsert", cnSqlServer)
        command.CommandType = CommandType.StoredProcedure

        Dim parPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
        parPOMasterID.Value = txtMastID.Text
        command.Parameters.Add(parPOMasterID)

        Dim parPONo As SqlParameter = New SqlParameter("@PONo", SqlDbType.NVarChar, 10)
        parPONo.Value = FindPO.Text
        command.Parameters.Add(parPONo)

        Dim parPORev As SqlParameter = New SqlParameter("@PORev", SqlDbType.NVarChar, 2)
        parPORev.Value = txtPORev.Text
        command.Parameters.Add(parPORev)

        Dim parPODate As SqlParameter = New SqlParameter("@PODate", SqlDbType.SmallDateTime, 4)
        parPODate.Value = Now.ToShortDateString
        command.Parameters.Add(parPODate)

        If Len(Trim(txtMastPODueDate.Text)) = 0 = True Or IsNothing(txtMastPODueDate.Text) = True Then
            txtMastPODueDate.Text = Now.ToShortDateString
        End If
        Dim parPODueDate As SqlParameter = New SqlParameter("@MasterPODueDate", SqlDbType.SmallDateTime, 4)
        parPODueDate.Value = txtMastPODueDate.Text
        command.Parameters.Add(parPODueDate)

        If Len(Trim(txtPOModDate.Text)) = 0 = True Or IsNothing(txtPOModDate.Text) = True Then
            txtPOModDate.Text = Now.ToShortDateString
        End If
        Dim parPOModDate As SqlParameter = New SqlParameter("@POModDate", SqlDbType.SmallDateTime, 4)
        parPOModDate.Value = txtPOModDate.Text
        command.Parameters.Add(parPOModDate)

        Dim parPOType As SqlParameter = New SqlParameter("@POType", SqlDbType.NVarChar, 50)
        parPOType.Value = CmbPOType.Text
        command.Parameters.Add(parPOType)

        Dim parReqNo As SqlParameter = New SqlParameter("@PORMReqNo", SqlDbType.NVarChar, 10)
        parReqNo.Value = txtReqNo.Text
        command.Parameters.Add(parReqNo)

        Dim parPOStatus As SqlParameter = New SqlParameter("@POStatus", SqlDbType.NVarChar, 20)
        parPOStatus.Value = CmbPoStatus.Text
        command.Parameters.Add(parPOStatus)

        Dim parPOBuyer As SqlParameter = New SqlParameter("@POBuyer", SqlDbType.Int, 4)
        parPOBuyer.Value = CmbPOBuyer.SelectedValue
        command.Parameters.Add(parPOBuyer)

        Dim parPOAccount As SqlParameter = New SqlParameter("@POAccount", SqlDbType.Int, 4)
        parPOAccount.Value = CmbPOGL.SelectedValue
        command.Parameters.Add(parPOAccount)

        Dim parPOSuppID As SqlParameter = New SqlParameter("@POSuppID", SqlDbType.Int, 4)
        parPOSuppID.Value = CmbPOSupp.SelectedValue
        command.Parameters.Add(parPOSuppID)

        Dim parPOAttnID As SqlParameter = New SqlParameter("@POAttnID", SqlDbType.Int, 4)
        parPOAttnID.Value = CmbPORefA.SelectedValue
        If IsNothing(parPOAttnID.Value) = True Then
            parPOAttnID.Value = 0
        End If
        command.Parameters.Add(parPOAttnID)

        Dim parPORefB As SqlParameter = New SqlParameter("@PORefB", SqlDbType.NVarChar, 50)
        parPORefB.Value = txtPORef.Text
        command.Parameters.Add(parPORefB)

        Dim parPOReq As SqlParameter = New SqlParameter("@POReqBy", SqlDbType.NVarChar, 50)
        parPOReq.Value = txtPOReq.Text
        command.Parameters.Add(parPOReq)

        Dim parCAPEX As SqlParameter = New SqlParameter("@POCapexNo", SqlDbType.NVarChar, 50)
        parCAPEX.Value = txtCapexNo.Text
        command.Parameters.Add(parCAPEX)

        Dim parCAPEXDescr As SqlParameter = New SqlParameter("@POCapexDescr", SqlDbType.NVarChar, 200)
        parCAPEXDescr.Value = txtCapexDescr.Text
        command.Parameters.Add(parCAPEXDescr)

        Dim parPOCond As SqlParameter = New SqlParameter("@POCond", SqlDbType.NVarChar, 100)
        parPOCond.Value = CmbPOTerms.Text
        command.Parameters.Add(parPOCond)

        Dim parPODropShipID As SqlParameter = New SqlParameter("@PODropShipID", SqlDbType.Int, 4)
        parPODropShipID.Value = CmbPODropShip.SelectedValue
        command.Parameters.Add(parPODropShipID)

        Dim parPOShipVia As SqlParameter = New SqlParameter("@POShipVia", SqlDbType.Int, 4)
        parPOShipVia.Value = CmbPOShipVia.SelectedValue
        command.Parameters.Add(parPOShipVia)

        Dim parPOFob As SqlParameter = New SqlParameter("@POFob", SqlDbType.NVarChar, 15)
        parPOFob.Value = CmbPoFOB.Text
        command.Parameters.Add(parPOFob)

        Dim parPOCOC As SqlParameter = New SqlParameter("@POCOC", SqlDbType.Bit, 1)
        parPOCOC.Value = ChkCOC.Checked
        command.Parameters.Add(parPOCOC)

        Dim parPOMIL As SqlParameter = New SqlParameter("@POMIL", SqlDbType.Bit, 1)
        parPOMIL.Value = ChkMill.Checked
        command.Parameters.Add(parPOMIL)

        Dim parPOTest As SqlParameter = New SqlParameter("@POTest", SqlDbType.Bit, 1)
        parPOTest.Value = ChkTest.Checked
        command.Parameters.Add(parPOTest)

        Dim parPORemarks As SqlParameter = New SqlParameter("@PORemarks", SqlDbType.NVarChar, 1000)
        parPORemarks.Value = txtPORemarks.Text
        command.Parameters.Add(parPORemarks)

        Dim parPONotes As SqlParameter = New SqlParameter("@PONotes", SqlDbType.NVarChar, 500)
        parPONotes.Value = txtPONotes.Text
        command.Parameters.Add(parPONotes)

        Dim parPOSalesTaxID As SqlParameter = New SqlParameter("@POSalesTaxID", SqlDbType.Int, 4)
        parPOSalesTaxID.Value = CmbSalesTax.SelectedValue
        command.Parameters.Add(parPOSalesTaxID)

        Dim parPODevise As SqlParameter = New SqlParameter("@PODevise", SqlDbType.Int, 4)
        parPODevise.Value = CmbDevise.SelectedValue
        command.Parameters.Add(parPODevise)

        If Len(Trim(txtGST.Text)) = 0 Then
            txtGST.Text = 0
        End If
        Dim parPOTaxGst As SqlParameter = New SqlParameter("@POTaxGst", SqlDbType.Real, 4)
        parPOTaxGst.Value = txtGST.Text
        command.Parameters.Add(parPOTaxGst)

        If Len(Trim(txtQST.Text)) = 0 Then
            txtQST.Text = 0
        End If
        Dim parPOTaxQst As SqlParameter = New SqlParameter("@POTaxQst", SqlDbType.Real, 4)
        parPOTaxQst.Value = txtQST.Text
        command.Parameters.Add(parPOTaxQst)

        If Len(Trim(txtTVH.Text)) = 0 Then
            txtTVH.Text = 0
        End If
        Dim parPOTaxTvh As SqlParameter = New SqlParameter("@POTaxTvh", SqlDbType.Real, 4)
        parPOTaxTvh.Value = txtTVH.Text
        command.Parameters.Add(parPOTaxTvh)

        txtPosted.Text = 0
        Dim parPoPosted As SqlParameter = New SqlParameter("@PoPosted", SqlDbType.Int, 4)
        parPoPosted.Value = txtPosted.Text
        command.Parameters.Add(parPoPosted)

        Try
            'cnSqlServer.Open()
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If

            command.ExecuteNonQuery()
            'cnSqlServer.Close()
        Catch ex As SqlException
            MsgBox("Add New PO Revision: " & ex.Message)
        Finally

            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

    End Sub

    Sub InsertDetail(ByVal sender As System.Object, ByVal e As System.EventArgs)

        strSQL = "SELECT tblPoMaster.POMasterID FROM tblPoMaster WHERE ((tblPOMaster.PONo)= '" & FindPO.Text & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cnSqlServer)
        Dim myReader5 As Data.SqlClient.SqlDataReader
        'cnSqlServer.Open()

        Try
            If cnSqlServer.State = ConnectionState.Closed Then
                cnSqlServer.Open()
            End If
            myReader5 = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader5.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! Insert Detail")
                CmdCancel_Click(sender, e)
            Else
                While myReader5.Read()
                    txtMastID.Text = myReader5.GetValue(0)
                End While
                myReader5.Close()
                myReader5.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - Put PO Number   " & ex.Message)
            CmdCancel_Click(sender, e)
        Finally
            If cnSqlServer.State = ConnectionState.Open Then
                cnSqlServer.Close()
            End If

        End Try

        Dim II, JJ As Integer
        JJ = dgDetail.Rows.Count
        For II = 1 To JJ - 1
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("POMasterInsertDetail", cnSqlServer)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPODetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
            parPODetailID.Value = dgDetail.Item("PODetailID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPODetailID)

            Dim parPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
            parPOMasterID.Value = txtMastID.Text
            cmdInsertDetail.Parameters.Add(parPOMasterID)

            Dim parPOMpoID As SqlParameter = New SqlParameter("@POMpoID", SqlDbType.Int, 4)
            parPOMpoID.Value = dgDetail.Item("POMpoID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOMpoID)

            Dim parPOItem As SqlParameter = New SqlParameter("@POItem", SqlDbType.TinyInt, 1)
            parPOItem.Value = dgDetail.Item("POItem", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOItem)

            Dim parPOStatusLine As SqlParameter = New SqlParameter("@POStatusLine", SqlDbType.NVarChar, 10)
            parPOStatusLine.Value = dgDetail.Item("POStatusLine", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOStatusLine)

            Dim parPOCostCenter As SqlParameter = New SqlParameter("@POCostCenter", SqlDbType.Int, 4)
            parPOCostCenter.Value = dgDetail.Item("POCostCenter", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOCostCenter)

            Dim parPOProdID As SqlParameter = New SqlParameter("@POProdID", SqlDbType.Int, 4)
            parPOProdID.Value = dgDetail.Item("POProdID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOProdID)

            Dim parPONotesItem As SqlParameter = New SqlParameter("@PONotesItem", SqlDbType.NVarChar, 1000)
            parPONotesItem.Value = dgDetail.Item("PONotesItem", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPONotesItem)

            Dim parPOQty As SqlParameter = New SqlParameter("@POQty", SqlDbType.Real, 4)
            parPOQty.Value = dgDetail.Item("POQty", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOQty)

            Dim parPOPrice As SqlParameter = New SqlParameter("@POPrice", SqlDbType.Money, 8)
            parPOPrice.Value = dgDetail.Item("POPrice", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOPrice)

            Dim parPORMSPrice As SqlParameter = New SqlParameter("@PORMSPrice", SqlDbType.Money, 8)
            parPORMSPrice.Value = dgDetail.Item("PORMSPrice", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPORMSPrice)

            Dim parPOUM As SqlParameter = New SqlParameter("@POUM", SqlDbType.NVarChar, 5)
            parPOUM.Value = dgDetail.Item("POUM", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOUM)

            Dim parPODueDate As SqlParameter = New SqlParameter("@PODueDate", SqlDbType.SmallDateTime, 4)
            parPODueDate.Value = dgDetail.Item("PODueDate", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPODueDate)

            Dim parPOItemEscompte As SqlParameter = New SqlParameter("@POItemEscompte", SqlDbType.Real, 4)
            parPOItemEscompte.Value = dgDetail.Item("POItemEscompte", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOItemEscompte)

            Dim parMatlType As SqlParameter = New SqlParameter("@POMatlID", SqlDbType.Int, 4)
            parMatlType.Value = dgDetail.Item("POMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlType)

            Dim parMatlDetID As SqlParameter = New SqlParameter("@POMatlDetID", SqlDbType.Int, 4)
            parMatlDetID.Value = dgDetail.Item("POMatlDetID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlDetID)

            Dim parMatlDia As SqlParameter = New SqlParameter("@PoMatlDia", SqlDbType.Real, 4)
            parMatlDia.Value = dgDetail.Item("PoMatlDia", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlDia)

            Dim parMatlInsideDia As SqlParameter = New SqlParameter("@POMatlInsideDia", SqlDbType.Real, 4)
            parMatlInsideDia.Value = dgDetail.Item("POMatlInsideDia", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlInsideDia)

            Dim parEngMatlDia As SqlParameter = New SqlParameter("@POEngMatlDia", SqlDbType.Real, 4)
            parEngMatlDia.Value = dgDetail.Item("POEngMatlDia", II - 1).Value
            cmdInsertDetail.Parameters.Add(parEngMatlDia)

            Dim parMatlForm As SqlParameter = New SqlParameter("@POMatlForm", SqlDbType.NVarChar, 10)
            parMatlForm.Value = dgDetail.Item("POMatlForm", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlForm)

            Dim parMatlStock As SqlParameter = New SqlParameter("@POForStock", SqlDbType.Bit, 1)
            parMatlStock.Value = dgDetail.Item("POForStock", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlStock)

            Dim parMatlOrd As SqlParameter = New SqlParameter("@POForOrders", SqlDbType.Bit, 1)
            parMatlOrd.Value = dgDetail.Item("POForOrders", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlOrd)

            Dim parMatlSource As SqlParameter = New SqlParameter("@PoMatlSource", SqlDbType.TinyInt, 1)         ' discontinue
            parMatlSource.Value = "1"
            cmdInsertDetail.Parameters.Add(parMatlSource)

            Dim parMatlNotes As SqlParameter = New SqlParameter("@POMatlNotes", SqlDbType.NVarChar, 2000)
            parMatlNotes.Value = dgDetail.Item("POMatlNotes", II - 1).Value
            cmdInsertDetail.Parameters.Add(parMatlNotes)

            Try
                'cnSqlServer.Open()

                If cnSqlServer.State = ConnectionState.Closed Then
                    cnSqlServer.Open()
                End If

                cmdInsertDetail.ExecuteNonQuery()
                'cnSqlServer.Close()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Add New PO Revision - Detail: " & ex.Message)
            Finally

                If cnSqlServer.State = ConnectionState.Open Then
                    cnSqlServer.Close()
                End If

            End Try
        Next

    End Sub

    Private Sub dgDetail_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellEndEdit
        Select Case e.ColumnIndex
            Case 13       'due date
                Dim Mi, Di, Yi As String

                Mi = Format(Me.dgDetail("PODueDate", e.RowIndex).Value, "MM")
                Di = Format(Me.dgDetail("PODueDate", e.RowIndex).Value, "dd")
                Yi = Format(Me.dgDetail("PODueDate", e.RowIndex).Value, "yyyy")

                If Val(Di) >= 1 And Val(Di) <= 31 Then
                Else
                    MsgBox("!!! ERROR - Day Value.  -  " & Di)
                End If

                If Val(Mi) >= 1 And Val(Mi) <= 12 Then
                Else
                    MsgBox("!!! ERROR - Month Value.  -  " & Mi)
                End If

                If Val(Yi) <= Format(Now, "yyyy") + 1 And Val(Yi) >= Format(Now, "yyyy") Then
                Else
                    MsgBox("!!! ERROR - Year Value.  -  " & Yi)
                End If
            Case 2                  ' PO Item

                If IsDBNull(dgDetail.Item("POItem", e.RowIndex).Value) = False Then
                    dgDetail.Item("PODueDate", e.RowIndex).Value = txtMastPODueDate.Text

                    dgDetail.Item("POStatusLine", e.RowIndex).Value = 20

                    If CmbPOType.Text = "Raw Material" Then
                        dgDetail.Item("POUM", e.RowIndex).Value = "LB"
                    Else
                        dgDetail.Item("POUM", e.RowIndex).Value = "EA"
                    End If
                End If

            Case 8                  ' MPO Nº
                If CmbPOType.Text = "Processing" Or CmbPOType.Text = "Sub-Contracting" Or CmbPOType.Text = "Grinding" Then

                    If dgDetail.Item("POItem", RowDetail).Value = 1 Then

                        frmPOAddOperation.SwMPOId.Text = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMpoID").Value)
                        frmPOAddOperation.ShowDialog()

                        If frmPOAddOperation.txtDescr.Text <> "False" Then
                            dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = frmPOAddOperation.txtDescr.Text + vbCrLf
                        End If

                        If frmPOAddOperation.txtSpec.Text <> "False" Then
                            dgDetail.Rows(RowDetail).Cells("PONotesItem").Value = dgDetail.Rows(RowDetail).Cells("PONotesItem").Value + frmPOAddOperation.txtSpec.Text
                        End If

                        frmPOAddOperation.Dispose()

                        TakeMpoNoInfo()
                        TakeMpoMatl()
                        TakeMpoHard()
                    End If
                End If

            Case 17     'matl type
                CmbSwRawMatl.SelectedValue = Nz.Nz(dgDetail.Rows(RowDetail).Cells("PoMatlId").Value)

                Dim dgcb As DataGridViewComboBoxCell = CType(dgDetail("POMatlDetID", e.RowIndex), DataGridViewComboBoxCell)
                Dim Swmat As Integer = 0
                dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")

                If IsDBNull(dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value) = False Then
                    Swmat = dgDetail.Rows(e.RowIndex).Cells("PoMatlID").Value
                    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                End If

                dgDetail.Rows(RowDetail).Cells("POMatlDetID").Value = DBNull.Value
                CmbSwKSI.SelectedValue = DBNull.Value

            Case 18     'matl KSI
                CmbSwKSI.SelectedValue = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMatlDetID").Value)
            Case 19     'matl dia

                If IsDBNull(dgDetail.Item("POEngMatlDia", e.RowIndex).Value) = True Or _
                    IsNothing(dgDetail.Item("POEngMatlDia", e.RowIndex).Value) Then
                    dgDetail.Item("POEngMatlDia", e.RowIndex).Value = dgDetail.Item("POMatlDia", e.RowIndex).Value
                End If
        End Select

    End Sub

    Sub TakeMpoHard()

        Dim swMpo As Integer = 0
        Dim getInfo As String = ""

        swMpo = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMpoID").Value)

        getInfo = CallClass.ReturnStrWithParInt("cspReturnMPOKSIForPurch", swMpo)

        If getInfo = "False" Then
            Exit Sub
        End If

        If Len(Trim(getInfo)) <> 0 Then
            If Len(Trim(Nz.Nz(Me.dgDetail("PoNotesItem", RowDetail).Value))) = 0 Or _
                IsDBNull(Me.dgDetail("PoNotesItem", RowDetail).Value) = True Then
                Me.dgDetail("PoNotesItem", RowDetail).Value = "Material KSI: " + getInfo
            Else
                Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value + _
                vbCrLf + "Material KSI: " + getInfo
            End If
            Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value
        End If

    End Sub

    Sub TakeMpoMatl()
        Dim swMpo As Integer = 0
        Dim getInfo As String = ""

        swMpo = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMpoID").Value)

        getInfo = CallClass.ReturnStrWithParInt("cspReturnMPOMatlForPurch", swMpo)

        If getInfo = "False" Then
            Exit Sub
        End If

        If Len(Trim(getInfo)) <> 0 Then
            If Len(Trim(Nz.Nz(Me.dgDetail("PoNotesItem", RowDetail).Value))) = 0 Or _
                IsDBNull(Me.dgDetail("PoNotesItem", RowDetail).Value) = True Then
                Me.dgDetail("PoNotesItem", RowDetail).Value = "Material: " + getInfo
            Else
                Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value + _
                vbCrLf + vbCrLf + "Material: " + getInfo
            End If
            Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value
        End If

    End Sub

    Sub TakeMpoNoInfo()

        Dim swMpo As Integer = 0
        Dim getInfo As String = ""

        swMpo = Nz.Nz(dgDetail.Rows(RowDetail).Cells("POMpoID").Value)

        getInfo = CallClass.FindMpoNoInfo("cspGeMPONoInfo", swMpo)

        If Len(Trim(getInfo)) <> 0 Then
            If Len(Trim(Nz.Nz(Me.dgDetail("PoNotesItem", RowDetail).Value))) = 0 Or _
                IsDBNull(Me.dgDetail("PoNotesItem", RowDetail).Value) = True Then
                Me.dgDetail("PoNotesItem", RowDetail).Value = getInfo
            Else
                Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value + _
                vbCrLf + vbCrLf + getInfo
            End If
            Me.dgDetail("PoNotesItem", RowDetail).Value = Me.dgDetail("PoNotesItem", RowDetail).Value
        End If

    End Sub

    Private Sub dgDetail_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetail.DataError
        REM end
    End Sub

    Private Sub CmdSeePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeePO.Click

        Me.Cursor = Cursors.WaitCursor

        frmPOMasterSearchPO.ShowDialog()
        frmPOMasterSearchPO.Dispose()
        FindPO.Focus()
        CmdSeePO.Enabled = False

        Call FindPOInfo(sender, e)

        Me.Cursor = Cursors.Default

        txtPOModDate.Text = Now.ToShortDateString

    End Sub

    Private Sub CmdRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRemarks.Click
        frmPORemarks.ShowDialog()
    End Sub

    Private Sub txtMastPODueDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMastPODueDate.Validating
        Try
            Dim dt As DateTime = DateTime.Parse(txtMastPODueDate.Text)
            If dt.Year < Now.Year - 4 OrElse dt.Year > Now.Year + 4 Then
                MsgBox("The Range of valid Years must be between" + Str(Now.Year) - 4 + " and " + Str(Now.Year) + 4)
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, _
            MsgBoxStyle.OkOnly, "PO Due Date: MM/dd/yyyy")
            e.Cancel = True
        End Try

    End Sub

    Private Sub ButtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtCancel.Click

        Dim reply As DialogResult
        reply = MsgBox("Do you want to Cancel the Purchase Order ? ", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then


            VerPo = 1
            Call CheckReceiving()

            If VerPo = 0 Then
                Exit Sub
            End If
            VerPo = 0

            CmbPoStatus.Text = "Cancelled"

            'Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
            'Dim strBody As String = ""
            'NotesSession = CreateObject("Notes.NotesSession")

            'If Len(wkEmpLogin) > 8 Then
            '    NotesDb = NotesSession.GetDatabase("197872.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
            'Else
            '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
            'End If

            'NotesDoc = NotesDb.CREATEDOCUMENT
            'NotesItem = NotesDoc.CreateRichTextItem("BODY")
            ''NotesDoc.Form = "Memo"
            'NotesDoc.Subject = "Purchasing Module"
            ''NotesDoc.cc = ""
            'strBody = "This is to inform you" & vbCrLf
            'strBody = strBody & "that the PO Number: " & FindPO.Text & vbCrLf
            'strBody = strBody & "Supplier Name: " & CmbPOSupp.Text & vbCrLf
            'strBody = strBody & " has been cancelled."
            'NotesDoc.body = strBody

            ''Call NotesDoc.SEND(False, "stefan.tudor@lisi-aerospace.com")
            'Call NotesDoc.SEND(False, "Comptabilite.Montreal@lisi-aerospace.com")

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "Purchasing Module"
            strBody = "This is to inform you" & vbCrLf
            strBody = strBody & "that the PO Number: " & FindPO.Text & vbCrLf
            strBody = strBody & "Supplier Name: " & CmbPOSupp.Text & vbCrLf
            strBody = strBody & " has been cancelled."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Comptabilite.Montreal@lisi-aerospace.com"))
            client.Send(email)

        End If

    End Sub

    Private Sub CmbDevise_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDevise.GotFocus
        Call PutDevise()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click

        SwEndUser = ""

        If CmbPOType.Text = "Processing" Or _
            CmbPOType.Text = "Sub-Contracting" Then
            Call CheckEndUser()
        End If

        Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptPOSupp()
            rptPO.Load("..\rptposupp.rpt")
            pdFind.Value = FindPO.Text
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

    End Sub

    Private Sub CmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMat.Click
        frmEngMatlType.ShowDialog()
    End Sub

    Private Sub CmdPOTermsEng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPOTermsEng.Click
        Dim rptPO As New rptLisiPOTermsEnglish
        rptPO.Load("..\rptLisiPOTermsEnglish.rpt")
        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
        frmPOPrintAll.ShowDialog()
    End Sub

    Private Sub CmbPOSupp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbPOSupp.Validating

        'Call CheckVendorNo()

    End Sub

    Private Sub CmbPOGL_DropDownClosed(sender As Object, e As EventArgs) Handles CmbPOGL.DropDownClosed

        If CmbPOGL.SelectedItem("CompteNo") = "2154100" Then
            LblCapex.Visible = True
            txtCapexNo.Visible = True
            LblCapexDescr.Visible = True
            txtCapexDescr.Visible = True
        Else
            LblCapex.Visible = False
            txtCapexNo.Visible = False
            LblCapexDescr.Visible = False
            txtCapexDescr.Visible = False
        End If

    End Sub

    Sub AlustaProcess()

        If cnSqlServer.State = ConnectionState.Open Then
            cnSqlServer.Close()
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

            Select Case CmbPOType.Text

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