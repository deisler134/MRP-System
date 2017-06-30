Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.VisualBasic

Public Class frmPoRecvTreatInsp

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon
    Private dsMain As New DataSet
    Private dsAlusta As New DataSet


    Dim SwpoDetailID As Integer
    Dim SwpoNum As String
    Dim SwPoItem As String
    Dim Swpoqty As Double
    Dim SwNext As Boolean = False  ' if false stop execution

    Dim RowDetails As Integer = 0       'dgDetails row.
    Dim RowIsp As Integer = 0       ' dgInsp row
    Dim KeepNo As Integer = 0

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""


    Private Sub frmPoRecvTreatInsp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        dsAlusta.Dispose()

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPoRecvTreatInsp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1200 And Height > 700 Then
            Me.Width = 1200
            Me.Height = 700
        Else
            If Width < 1200 And Height < 700 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()
    End Sub

    Sub SetupForm()

        GC.Collect()

        PageReadOnly()

        HideCtl()

        SetCtlForm()

        InitFields()

        FirstTimeMenuButtons()

        InitialComponents()

        SrcPO.Enabled = True
        SrcPO.Focus()

    End Sub

    Sub InitFields()
        SrcPO.Text = ""
    End Sub

    Sub FirstTimeMenuButtons()

        CmdSave.Enabled = False
        CmdReset.Enabled = False

    End Sub

    Sub EnblButtons()

        CmdSave.Enabled = True
        CmdReset.Enabled = True

    End Sub

    Sub HideCtl()

        pnlPOMas.Visible = False
        dgDetails.Visible = False
        dgInsp.Visible = False
        dgMemo.Visible = False

        txtTotalPOValue.Visible = False
        txtTotalPOQty.Visible = False
        txtTotalAccpValue.Visible = False
        txtTotalPSlipQty.Visible = False
        txtBal.Visible = False
        txtTotalQtyAccp.Visible = False
        txtTotalQtyRej.Visible = False

        Label4.Visible = False
        Label9.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label2.Visible = False

    End Sub

    Sub VisibleCtl()

        pnlPOMas.Visible = True
        dgDetails.Visible = True
        dgInsp.Visible = True
        dgMemo.Visible = True

        txtTotalPOValue.Visible = True
        txtTotalPOQty.Visible = True
        txtTotalAccpValue.Visible = True
        txtTotalPSlipQty.Visible = True
        txtBal.Visible = True
        txtTotalQtyAccp.Visible = True
        txtTotalQtyRej.Visible = True

        Label4.Visible = True
        Label9.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        Label2.Visible = True

    End Sub

    Sub InitialComponents()


        dsMain.Clear()
        dsMain.Relations.Clear()

        'CallClass.PopulateDataAdapter("gettblPoDetails").Fill(dsMain, "tblPODetails")
        'CallClass.PopulateDataAdapter("gettblPoReceiving").Fill(dsMain, "tblPOReceiving")

        CallClass.PopulateDataAdapter("gettblPoDetailsEmpty").Fill(dsMain, "tblPODetails")
        CallClass.PopulateDataAdapter("gettblPoReceivingEmpty").Fill(dsMain, "tblPOReceiving")
        CallClass.PopulateDataAdapter("gettblMemoEmpty").Fill(dsMain, "tblMemo")

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("DetailRecv", _
            .Tables("tblPODetails").Columns("PODetailID"), _
            .Tables("tblPOReceiving").Columns("PODetailID"), True)
        End With

        With dsMain
            .Relations.Add("LinkMemo", _
            .Tables("tblPOReceiving").Columns("PslipMpoID"), _
            .Tables("tblMemo").Columns("MPOID"), True)
        End With


        '=========================
        dsAlusta.Clear()
        dsAlusta.Relations.Clear()

        CallClass.PopulateDataAdapter("getPOUpload_IntoAlustaEmpty").Fill(dsAlusta, "tblSelect")

        dsAlusta.EnforceConstraints = False

        dgAlusta.AutoGenerateColumns = False
        dgAlusta.DataSource = dsAlusta
        dgAlusta.DataMember = "tblSelect"

    End Sub

    Sub PageReadOnly()

        txtPONumber.ReadOnly = True
        cmbSupp.Enabled = False
        cmbBuyer.Enabled = False
        cmbUser.Enabled = False
        cmbPOStatus.Enabled = False
        cmbPOType.Enabled = False
        txtPODate.ReadOnly = True

        dgDetails.ReadOnly = True
        dgInsp.ReadOnly = True
        dgMemo.ReadOnly = True

    End Sub

    Sub SetCtlForm()

        With Me.cmbSupp
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplier").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
        End With

        With Me.cmbBuyer
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "poRecGetBuyer").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

        With Me.cmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "poRecGetBuyer").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

        'For dgDetails properies

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With

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

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.POProdID
            .DataSource = CallClass.PopulateComboBox("tblProdDesc", "poRecGetProd").Tables("tblProdDesc")
            .DisplayMember = "ProdDescr"
            .ValueMember = "ProdID"
            .DataPropertyName = "POProdID"
            .Name = "POProdID"
        End With

        With Me.POMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
            .DataPropertyName = "POMpoID"
            .Name = "POMpoID"
        End With

        With Me.POUM
            .DataSource = CallClass.PopulateComboBox("tblUM", "cmbGetUM").Tables("tblUM")
            .DisplayMember = "IDum"
            .ValueMember = "IDum"
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POItemEscompte
            .DataPropertyName = "POItemEscompte"
            .Name = "POItemEscompte"
        End With

        With Me.TotalValue
            .DataPropertyName = "TotalValue"
            .Name = "TotalValue"
        End With

        'For dgInsp properies

        With Me.RecvPODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.RecvPOItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.PslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.PSlipQty
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

        With Me.TotalPslipValue
            .DataPropertyName = "TotalPslipValue"
            .Name = "TotalPslipValue"
        End With

        With Me.RecQtyAccp
            .DataPropertyName = "RecQtyAccp"
            .Name = "RecQtyAccp"
        End With

        With Me.RecQtyRej
            .DataPropertyName = "RecQtyRej"
            .Name = "RecQtyRej"
        End With

        With Me.ApprInsp
            .DataPropertyName = "ApprInsp"
            .Name = "ApprInsp"
        End With

        With Me.ApprRecvToPay
            .DataPropertyName = "ApprRecvToPay"
            .Name = "ApprRecvToPay"
        End With

        With Me.CmdAssign
            .DataPropertyName = "CmdAssign"
            .Name = "CmdAssign"
        End With

        'For dgMemo properies

        With Me.MemoId
            .DataPropertyName = "MemoId"
            .Name = "MemoId"
            .Visible = False
        End With

        With Me.MPOID
            .DataPropertyName = "MPOID"
            .Name = "MPOID"
            .Visible = False
        End With

        With Me.MemoNo
            .DataPropertyName = "MemoNo"
            .Name = "MemoNo"
        End With

        With Me.CmdSeeMemo
            .DataPropertyName = "CmdSeeMemo"
            .Name = "CmdSeeMemo"
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

    Sub BindComponents()

        Dim ds As New DataSet

        cmbSupp.DataBindings.Clear()
        cmbBuyer.DataBindings.Clear()
        txtPODate.DataBindings.Clear()
        txtPONumber.DataBindings.Clear()
        cmbUser.DataBindings.Clear()
        cmbPOStatus.DataBindings.Clear()
        cmbPOStatus.Text = ""
        cmbPOType.DataBindings.Clear()
        cmbPOType.Text = ""

        txtPONumber.DataBindings.Add("Text", dsMain, "tblPOMaster.PONo")
        cmbSupp.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSuppID")
        cmbBuyer.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POBuyer")
        txtPODate.DataBindings.Add("Text", dsMain, "tblPOMaster.PODate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        cmbUser.SelectedValue = wkEmpId
        cmbPOStatus.DataBindings.Add("Text", dsMain, "tblPOMaster.POStatus")
        cmbPOType.DataBindings.Add("Text", dsMain, "tblPOMaster.POType")

        SwNext = False

        Select Case (cmbPOStatus.Text)
            Case "Cancelled"
                MsgBox("This PO has been CANCELLED.")
                SwNext = False
            Case "Payed"
                MsgBox("This PO has been PAYED.")
                SwNext = False
            Case "AMMD"
                MsgBox("Please Receive the items on the new Amendment.")
                SwNext = False
            Case "Accepted"
                MsgBox("!!! This PO has been ACCEPTED !!!")
                If cmbPOType.Text = "Processing" Or _
                    cmbPOType.Text = "Sub-Contracting" Or _
                    cmbPOType.Text = "Calibration/Testing" Or _
                    cmbPOType.Text = "Components" Or _
                    cmbPOType.Text = "Lab Supplies (Matl/Product)" Then
                    SwNext = True
                Else
                    MsgBox("For this PO Type  --- " + cmbPOType.Text + " ---  Inspection / Acceptance is not necessary.")
                    SwNext = False
                End If
            Case "Open"
                If cmbPOType.Text = "Processing" Or _
                    cmbPOType.Text = "Sub-Contracting" Or _
                    cmbPOType.Text = "Calibration/Testing" Or _
                    cmbPOType.Text = "Components" Or _
                    cmbPOType.Text = "Lab Supplies (Matl/Product)" Then
                    SwNext = True
                Else
                    MsgBox("For this PO Type  --- " + cmbPOType.Text + " ---  Inspection / Acceptance is not necessary.")
                    SwNext = False
                End If
            Case Else
                MessageBox.Show("For this PO Type --- " + cmbPOType.Text + " --- you are not allowed to do an inspection")
                SwNext = False
        End Select

    End Sub

    Private Sub SrcPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SrcPO.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim strSearch As String

            If InStr(SrcPO.Text, "-") <> 0 Then
                strSearch = Microsoft.VisualBasic.Left(SrcPO.Text, InStr(SrcPO.Text, "-") - 1)
            Else
                strSearch = Trim(SrcPO.Text)
            End If

            VisibleCtl()

            dsMain.Clear()
            dsAlusta.Clear()

            CallClass.PopulateDataAdapterAfterSearch("getTblPoMasterByPO", strSearch).Fill(dsMain, "tblPOMaster")

            If dsMain.Tables("tblPOMaster").Rows.Count = 0 Then
                MessageBox.Show("There is no such PO Number: " + SrcPO.Text + " Try again.", "Warning")
                ResetForm()
                Exit Sub
            End If
            Call BindComponents()
            SrcPO.Enabled = False
            dgDetails.AutoGenerateColumns = False
            dgDetails.DataSource = dsMain
            dgDetails.DataMember = "tblPOMaster"

            CallClass.PopulateDataAdapterAfterSearch("getTblPoDetailsLikePONo", strSearch).Fill(dsMain, "tblPOReceiving")

            If dsMain.Tables("tblPOReceiving").Rows.Count = 0 Then
                MessageBox.Show("There is no Receiving/Inspection data for this PO Number: " + SrcPO.Text + " Try again.", "Warning")
                ResetForm()
                Exit Sub
            End If
            dgInsp.AutoGenerateColumns = False
            dgInsp.DataSource = dsMain
            dgInsp.DataMember = "tblPOReceiving"

            Call TotalPO()

            If dgInsp.Rows.Count > 0 Then
                dgInsp.Rows(0).Selected = True
                If IsDBNull(dgInsp("PslipMpoID", 0).Value) = False Then
                    CallClass.PopulateDataAdapterAfterSearch("gettblMemoByMPOID", dgInsp("PslipMpoID", 0).Value).Fill(dsMain, "tblMemo")
                    dgMemo.AutoGenerateColumns = False
                    dgMemo.DataSource = dsMain
                    dgMemo.DataMember = "tblMemo"
                End If
            End If

            CmdReset.Enabled = True

            If SwNext = True Then
                EnblButtons()
                dgInsp.ReadOnly = True
                For Each Row As DataGridViewRow In dgInsp.Rows
                    'Row.Cells("PslipMpoID").Style.BackColor = Color.LightBlue
                    'Row.Cells("RecQtyAccp").Style.BackColor = Color.LightBlue
                    'Row.Cells("PSlipNum").Style.BackColor = Color.LightBlue
                    'Row.Cells("PSlipQty").Style.BackColor = Color.LightBlue
                    'Row.Cells("RecQtyRej").Style.BackColor = Color.LightYellow

                    'If Nz.Nz(Row.Cells("RecQtyAccp").Value) = 0 Then
                    '    Row.Cells("RecQtyRej").Value = 0
                    'Else
                    '    Row.Cells("RecQtyRej").Value = Nz.Nz(Row.Cells("PSlipQty").Value) - Nz.Nz(Row.Cells("RecQtyAccp").Value)
                    'End If

                    If IsDBNull(Row.Cells("RecQtyAccp").Value) = False Then
                        Row.Cells("RecQtyRej").Value = Nz.Nz(Row.Cells("PSlipQty").Value) - Nz.Nz(Row.Cells("RecQtyAccp").Value)
                    Else
                        Row.Cells("RecQtyRej").Value = 0
                    End If
                Next
            Else
                PageReadOnly()
            End If
        End If

        dgDetails.Focus()

    End Sub

    Sub TotalPO()

        Dim tqty As Integer
        Dim tqPSty As Integer
        Dim tqAccp As Integer
        Dim tqRej As Integer

        If dgDetails.Rows.Count > 0 Then
            Dim I As Integer

            Dim tvalue As Single
            For I = 0 To dgDetails.Rows.Count - 1
                Me.dgDetails("TotalValue", I).Value = Nz.Nz(Me.dgDetails("POQty", I).Value) * ((Nz.Nz(Me.dgDetails("POPrice", I).Value)) - (Nz.Nz(Me.dgDetails("POPrice", I).Value) * Nz.Nz(Me.dgDetails.Item("POItemEscompte", I).Value)) / 100)
                tqty = tqty + CDec(Nz.Nz(Me.dgDetails("POQty", I).Value))
                tvalue = tvalue + CDec(Nz.Nz(Me.dgDetails("TotalValue", I).Value))
            Next
            txtTotalPOQty.Text = tqty.ToString("N2")
            txtTotalPOValue.Text = tvalue.ToString("C2")
        End If

        If dgInsp.Rows.Count > 0 Then
            Dim I As Integer

            Dim tvalue As Single
            For I = 0 To dgInsp.Rows.Count - 1
                Me.dgInsp("TotalPslipValue", I).Value = Nz.Nz(Me.dgInsp("PSlipQty", I).Value) * ((Nz.Nz(Me.dgInsp("PSlipPrice", I).Value)) - (Nz.Nz(Me.dgInsp("PSlipPrice", I).Value) * Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value)) / 100)
                tqPSty = tqPSty + CDec(Nz.Nz(Me.dgInsp("PSlipQty", I).Value))
                tvalue = tvalue + Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value) * _
                                ((Nz.Nz(Me.dgInsp("PSlipPrice", I).Value)) - (Nz.Nz(Me.dgInsp("PSlipPrice", I).Value) * Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value)) / 100)
                tqAccp = tqAccp + CDec(Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value))
                tqRej = tqRej + CDec(Nz.Nz(Me.dgInsp("RecQtyRej", I).Value))
            Next
            txtTotalPSlipQty.Text = tqPSty.ToString("N2")
            txtTotalAccpValue.Text = tvalue.ToString("C2")
            txtTotalQtyAccp.Text = tqAccp.ToString("N2")
            txtTotalQtyRej.Text = tqRej.ToString("N2")
        End If

        txtBal.Text = (tqty - tqPSty).ToString("N2")

        Me.ErrorProvider1.Clear()

        If tqty - tqPSty <> 0 Then
            Me.ErrorProvider1.SetError(txtBal, "Qty PO <> Qty Received.")
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If

    End Sub

    Function RoleRecvInsp(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RECVINSP" Then
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

    Private Sub dgDetails_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDetails = e.RowIndex

        TotalPO()

        SelectInspRow()

    End Sub

    Private Sub dgDetails_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDetails = e.RowIndex

        SelectInspRow()

    End Sub

    Private Sub dgDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetails.DataError
        REM end
    End Sub

    Private Sub dgInsp_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgInsp.CellBeginEdit

        Dim SwMPOId As Integer = 0
        Dim SwMpoStatus As String = ""

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If Nz.Nz(dgInsp("ApprRecvToPay", e.RowIndex).Value) = 1 Then
            MsgBox("You can not EDIT this line. It was Approved by Accounting for Payment.")
            e.Cancel = True
            Exit Sub
        End If

        If cmbPOType.Text = "Processing" Or cmbPOType.Text = "Sub-Contracting" Then
            SwMPOId = Nz.Nz(dgInsp("PslipMpoID", e.RowIndex).Value)
            If SwMPOId = 0 Then
                'MessageBox.Show("Please select the MPO Number in Receiving DataGridView.", "Warning")
                'dgInsp("PslipMpoID", e.RowIndex).Value = Nz.Nz(dgDetails("POMpoID", RowDetails).Value)
            Else
                SwMpoStatus = CallClass.ReturnStrWithParInt("cspReturnMpoStatus", SwMPOId)
                If SwMpoStatus <> "Active" Then
                    MsgBox("MPO Status is not Active. Access Denied")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        If SwNext = True Then
            Select Case e.ColumnIndex
                Case 13                                 ' Qty Accepted
                    If IsDBNull(dgInsp("RecQtyAccp", e.RowIndex).Value) = False Then
                        Dim reply As DialogResult
                        reply = MsgBox("Edit Quantity Accepted ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            e.Cancel = False
                        Else
                            e.Cancel = True
                        End If

                        'Exit Sub

                    End If

                    If IsDBNull(dgInsp("PslipMpoID", e.RowIndex).Value) = True Then
                        MessageBox.Show("Lisi Mpo Receiving is EMPTY.", "Warning")
                        dgInsp("PslipMpoID", e.RowIndex).Value = Nz.Nz(dgDetails("POMpoID", RowDetails).Value)
                        e.Cancel = True
                        Exit Sub
                    End If

                    If Nz.Nz(dgInsp("PslipMpoID", e.RowIndex).Value) = Nz.Nz(dgDetails("POMpoID", RowDetails).Value) Then
                        Dim tPer As Integer
                        tPer = (dgDetails("POQty", RowDetails).Value * 5) / 100
                        If Nz.Nz(dgInsp("PSlipQty", e.RowIndex).Value) < Nz.Nz(dgDetails("POQty", RowDetails).Value) - tPer And _
                            txtTotalPSlipQty.Text < Nz.Nz(dgDetails("POQty", RowDetails).Value) - tPer Then

                            MessageBox.Show("Qty PSlip - Incoming Receiving < Qty PO. Split the MPO.", "Warning")
                            'e.Cancel = True

                            Dim frm As New frmMpoSplitProd
                            frm.fMpo = Nz.Nz(dgInsp("PslipMpoID", e.RowIndex).Value)
                            frm.fQty = Nz.Nz(dgInsp("PSlipQty", e.RowIndex).Value)
                            frm.fBool = True
                            frm.ShowDialog()

                        End If
                    End If

                Case 16     'switch aproved for payment
                    e.Cancel = True
            End Select


        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub dgInsp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInsp.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            For Each Row As DataGridViewRow In dgInsp.Rows
                Row.Cells("PslipMpoID").Style.BackColor = Color.LightBlue
                Row.Cells("RecQtyAccp").Style.BackColor = Color.LightBlue
                Row.Cells("PSlipNum").Style.BackColor = Color.LightBlue
                Row.Cells("PSlipQty").Style.BackColor = Color.LightBlue
                Row.Cells("RecQtyRej").Style.BackColor = Color.LightYellow

                If IsDBNull(Row.Cells("RecQtyAccp").Value) = False Then
                    Row.Cells("RecQtyRej").Value = Nz.Nz(Row.Cells("PSlipQty").Value) - Nz.Nz(Row.Cells("RecQtyAccp").Value)
                Else
                    Row.Cells("RecQtyRej").Value = 0
                End If
            Next

            TotalPO()

        End If

        If SwNext = True Then
            If RoleRecvInsp(wkDeptCode) = True Then
                dgInsp.ReadOnly = False
                Select Case e.ColumnIndex
                    Case 0, 1, 2, 3, 4, 6
                        dgInsp.Columns(e.ColumnIndex).ReadOnly = True
                    Case 9 To 12
                        dgInsp.Columns(e.ColumnIndex).ReadOnly = True
                    Case 14, 16
                        dgInsp.Columns(e.ColumnIndex).ReadOnly = True
                    Case 17     'cmd Memo

                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to create a new LAC MEMO? (Yes/No)", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            frmLisiMemoApp.SwFrom.Text = "QAINSP"
                            frmLisiMemoApp.SwValue.Text = "NEW"
                            frmLisiMemoApp.CmbUser.SelectedIndex = -1
                            frmLisiMemoApp.CmbMpo.SelectedIndex = -1
                            frmLisiMemoApp.ShowDialog()
                        End If
                End Select
            Else
                MessageBox.Show("Access Denied.")
            End If
        End If
    End Sub

    Private Sub dgInsp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInsp.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgInsp("RecQtyAccp", e.RowIndex).Value) = False Then
            dgInsp("RecQtyRej", e.RowIndex).Value = Nz.Nz(dgInsp("PSlipQty", e.RowIndex).Value) - Nz.Nz(dgInsp("RecQtyAccp", e.RowIndex).Value)
        Else
            dgInsp("RecQtyRej", e.RowIndex).Value = 0
        End If

        If dgInsp("RecQtyRej", e.RowIndex).Value < 0 Then
            MsgBox("!!! ERROR !!! Qty Accepted > Qty Received")
            dgInsp("RecQtyAccp", e.RowIndex).Value = DBNull.Value
            dgInsp("RecQtyRej", e.RowIndex).Value = DBNull.Value
        End If

        If Nz.Nz(dgInsp("PSlipQty", e.RowIndex).Value) = Nz.Nz(dgInsp("RecQtyAccp", e.RowIndex).Value) Then
            dgInsp("ApprInsp", e.RowIndex).Value = 1
        End If

        TotalPO()

    End Sub

    Private Sub dgInsp_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgInsp.DataError
        REM end
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click
        ResetForm()
    End Sub

    Sub ResetForm()

        SrcPO.Enabled = True
        SrcPO.Clear()
        SrcPO.Focus()

        FirstTimeMenuButtons()
        dsMain.Clear()
        HideCtl()
    End Sub

    Sub SelectInspRow()

        For Each Row As DataGridViewRow In dgInsp.Rows
            Row.Selected = False
        Next

        For Each Row As DataGridViewRow In dgInsp.Rows
            If Nz.Nz(dgDetails.Item("POItem", RowDetails).Value) = Nz.Nz(Row.Cells("POItem").Value) Then
                Row.Cells("POItem").Selected = True
            End If
        Next

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgInsp.EndEdit()

        If dgInsp.Rows.Count <= 0 Then
            MsgBox("Nothing to SAVE.")
        Else
            'To change the current row, to the last row:
            Dim cellLastRow As DataGridViewCell = dgInsp.Rows(dgInsp.Rows.Count - 1).Cells(2)
            dgInsp.CurrentCell = cellLastRow

            Try
                If dsMain.HasChanges Then
                    UpdateRecvAcceptedQty(dsMain.GetChanges)
                    MsgBox("Update successfully.")

                    'Checking Qty received to accept the po 
                    If cmbPOStatus.Text = "Open" Then
                        Dim ppoQty As Integer = 0
                        Dim recQty As Integer = 0
                        For I As Integer = 0 To (dgDetails.Rows.Count - 1)
                            ppoQty = ppoQty + dgDetails("POQty", I).Value
                            For Each rectrw As DataRow In dsMain.Tables("tblPOReceiving").Rows
                                If dgDetails("PODetailID", I).Value = rectrw.Item("PODetailID") Then
                                    recQty = recQty + rectrw.Item("PSlipQty")
                                End If
                            Next
                        Next I
                        If recQty >= ppoQty Then
                            UpdatePOStatusAccepted()
                        End If
                    End If
                    '-----------------------

                    dsMain.AcceptChanges()
                Else
                    MsgBox("Nothing to SAVE.")
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try
        End If

        AlustaProcess()

        Call SetupForm()

    End Sub

    Sub UpdatePOStatusAccepted()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePOStatusAccepted", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
        paraID.Value = dgDetails("POMasterID", RowDetails).Value
        mySqlComm.Parameters.Add(paraID)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO Status: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateRecvAcceptedQty(ByVal dsChanges As DataSet)

        Dim cmdUpdPORec As SqlCommand

        cmdUpdPORec = New SqlCommand()
        cmdUpdPORec.Connection = cn
        cmdUpdPORec.CommandType = CommandType.StoredProcedure
        cmdUpdPORec.CommandText = "cspUpdatePoRecvTreatInsp"

        '' Add Parameters to update sproc
        cmdUpdPORec.Parameters.Add("@PORecvID", SqlDbType.Int, 4, "PORecvID")
        cmdUpdPORec.Parameters.Add("@PslipMpoID", SqlDbType.Int, 4, "PslipMpoID")
        cmdUpdPORec.Parameters.Add("@PslipQty", SqlDbType.Float, 8, "PslipQty")
        cmdUpdPORec.Parameters.Add("@RecQtyAccp", SqlDbType.Float, 8, "RecQtyAccp")
        cmdUpdPORec.Parameters.Add("@ApprInsp", SqlDbType.Bit, 1, "ApprInsp")

        ''DataApapter
        Dim daPORec = New SqlDataAdapter()
        daPORec.UpdateCommand = cmdUpdPORec
        daPORec.TableMappings.Add("Table", "tblPOReceiving")

        daPORec.Update(dsChanges)

    End Sub

    Private Sub dgMemo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMemo.CellClick

        If e.ColumnIndex = 3 Then
            frmLisiMemoApp.SwFrom.Text = "QAINSP"
            frmLisiMemoApp.SwValue.Text = Me.dgMemo("MemoID", e.RowIndex).Value
            frmLisiMemoApp.ShowDialog()
        End If

    End Sub

    Private Sub dgMemo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMemo.DataError
        REM end
    End Sub

    Private Sub frmPoRecvTreatInsp_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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

    Sub AlustaProcess()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        dsAlusta.Clear()
        CallClass.PopulateDataAdapterAfterSearch("getPOUpload_IntoAlusta", SrcPO.Text).Fill(dsAlusta, "tblSelect")

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

        FileNameStr = "LACPO_" + SrcPO.Text + "_" + SwDate + "_" + Trim(Now.ToShortTimeString) + ".csv"
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