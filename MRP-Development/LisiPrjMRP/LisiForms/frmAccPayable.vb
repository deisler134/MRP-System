Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmAccPayable

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim SwpoDetailID As Integer
    Dim SwpoNum As String
    Dim SwPoItem As String
    Dim Swpoqty As Double
    Dim SwNext As Boolean = False  ' if false stop execution

    Dim RowDetails As Integer = 0       'dgDetails row.
    Dim KeepRow As Integer = 0

    Dim RowInsp As Integer = 0       ' dgInsp row
    Dim KeepNo As Integer = 0

    Dim SwVal As Boolean = False

    Dim strSQL As String


    Dim OldQty As String
    Dim OldUM As String
    Dim OldPrice As String
    Dim OldDiscount As String

    Dim SwEndUser As String = ""

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmAccPayable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()


    End Sub

    Private Sub frmAccPayable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1600 And Height > 900 Then
            Me.Width = 1600
            Me.Height = 900
        Else
            If Width < 1600 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()

    End Sub

    Sub SetupForm()

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
        txtTrQty.Text = ""
        txtTrType.Text = ""
        txtTrPrice.Text = ""
        txtTrNotes.Text = ""
        txtToPay.Text = ""
        txtPayed.Text = ""
        txtValPO.Text = ""

        'txtAccNotes.Text = ""
    End Sub

    Sub FirstTimeMenuButtons()

        'CmdSave.Enabled = False
        CmdReset.Enabled = False
        txtAccNotes.Enabled = False

    End Sub

    Sub EnblButtons()

        'CmdSave.Enabled = True
        CmdReset.Enabled = True

    End Sub

    Sub HideCtl()

        pnlPOMas.Visible = False
        dgDetails.Visible = False
        dgInsp.Visible = False
        txtTotalPOValue.Visible = False
        txtTotalPOQty.Visible = False
        PlFooter.Visible = False

    End Sub

    Sub VisibleCtl()

        pnlPOMas.Visible = True
        dgDetails.Visible = True
        dgInsp.Visible = True

        txtTotalPOValue.Visible = True
        txtTotalPOQty.Visible = True
        PlFooter.Visible = True

        txtAccNotes.Enabled = True
    End Sub

    Sub InitialComponents()


        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblPoDetails").Fill(dsMain, "tblPODetails")
        CallClass.PopulateDataAdapter("gettblPoReceiving").Fill(dsMain, "tblPOReceiving")

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("DetailRecv", _
            .Tables("tblPODetails").Columns("PODetailID"), _
            .Tables("tblPOReceiving").Columns("PODetailID"), True)
        End With

    End Sub

    Sub PageReadOnly()

        txtPONumber.ReadOnly = True
        cmbSupp.Enabled = False
        cmbBuyer.Enabled = False
        cmbUser.Enabled = False
        cmbPOStatus.Enabled = False
        cmbPOType.Enabled = False
        CmbGl.Enabled = False

        txtPODate.ReadOnly = True

        'dgDetails.ReadOnly = True
        dgInsp.ReadOnly = True

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

        With Me.CmbGl
            .DataSource = CallClass.PopulateComboBox("tblAccCompte", "cmbGetPOAccount").Tables("tblAccCompte")
            .DisplayMember = "FullDescr"
            .ValueMember = "CompteID"
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

        With Me.PORMSPrice
            .DataPropertyName = "PORMSPrice"
            .Name = "PORMSPrice"
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

        With Me.PODetailAccountID
            .DataSource = CallClass.PopulateComboBox("tblAccCompte", "cmbGetAccCompte").Tables("tblAccCompte")
            .DisplayMember = "FullDescr"
            .ValueMember = "CompteID"
            .DataPropertyName = "PODetailAccountID"
            .Name = "PODetailAccountID"
            .DropDownWidth = 350
            .MaxDropDownItems = 40
        End With

        With Me.POAccNotes
            .DataPropertyName = "POAccNotes"
            .Name = "POAccNotes"
            .Visible = False
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

        With Me.RecMemoNo
            .DataPropertyName = "RecMemoNo"
            .Name = "RecMemoNo"
        End With

        With Me.CmdMemo
            .DataPropertyName = "CmdMemo"
            .Name = "CmdMemo"
        End With

        With Me.PayInvDate
            .DataPropertyName = "PayInvDate"
            .Name = "PayInvDate"
        End With

        With Me.SwLineValue
            .DataPropertyName = "SwLineValue"
            .Name = "SwLineValue"
        End With

        With Me.ApprRecvToPay
            .DataPropertyName = "ApprRecvToPay"
            .Name = "ApprRecvToPay"
        End With

        With Me.RecvDetRmsPrice
            .DataPropertyName = "RecvDetRmsPrice"
            .Name = "RecvDetRmsPrice"
            .Visible = False
        End With

    End Sub

    Sub BindComponents()

        Dim ds As New DataSet

        cmbSupp.DataBindings.Clear()
        CmbGl.DataBindings.Clear()
        cmbBuyer.DataBindings.Clear()
        txtPODate.DataBindings.Clear()
        txtPONumber.DataBindings.Clear()
        cmbUser.DataBindings.Clear()
        cmbPOStatus.DataBindings.Clear()
        cmbPOStatus.Text = ""
        cmbPOType.DataBindings.Clear()

        CmbSalesTax.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        txtGST.DataBindings.Clear()
        txtQST.DataBindings.Clear()
        txtTVH.DataBindings.Clear()

        cmbPOType.Text = ""

        txtAccNotes.DataBindings.Clear()
        txtAccNotes.DataBindings.Add("Text", dsMain, "tblPOMaster.POAccNotes")

        txtPONumber.DataBindings.Add("Text", dsMain, "tblPOMaster.PONo")
        cmbSupp.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSuppID")
        CmbGl.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAccount")
        cmbBuyer.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POBuyer")
        txtPODate.DataBindings.Add("Text", dsMain, "tblPOMaster.PODate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        cmbUser.SelectedValue = wkEmpId
        cmbPOStatus.DataBindings.Add("Text", dsMain, "tblPOMaster.POStatus")
        cmbPOType.DataBindings.Add("Text", dsMain, "tblPOMaster.POType")

        CmbSalesTax.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POSalesTaxID")
        CmbDevise.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODevise")
        txtGST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxGST")
        txtQST.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxQST")
        txtTVH.DataBindings.Add("Text", dsMain, "tblPOMaster.POTaxTVH")

        SwNext = False

        Select Case (cmbPOStatus.Text)
            Case "Cancelled"
                MsgBox("This PO has been cancelled.")
                SwNext = False
            Case "Payed"
                MsgBox("This PO has already been Payed.")
                SwNext = False
            Case "AMMD"
                MsgBox("Please Receive the items on the new Amendment.")
                SwNext = False
            Case "Accepted"
                MsgBox("This PO has already been accepted.")
                SwNext = True
            Case "Open"
                SwNext = True
            Case Else
                MessageBox.Show("For this PO Type you are not allowed to Approve a Payment.")
                SwNext = False
        End Select

        CalculGrid()

    End Sub

    Private Sub SrcPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SrcPO.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchPO()
        End If
        dgDetails.Focus()

    End Sub

    Sub SearchPO()
        Dim strSearch As String

        If Len(SrcPO.Text) = 0 Then
            MessageBox.Show("Missing PO#.")
            ResetForm()
            Exit Sub
        End If

        If InStr(SrcPO.Text, "-") <> 0 Then
            strSearch = Microsoft.VisualBasic.Left(SrcPO.Text, InStr(SrcPO.Text, "-") - 1)
        Else
            strSearch = Trim(SrcPO.Text)
        End If

        VisibleCtl()

        dsMain.Clear()

        CallClass.PopulateDataAdapterAfterSearch("getTblPoMasterByPO", strSearch).Fill(dsMain, "tblPOMaster")

        If dsMain.Tables("tblPOMaster").Rows.Count = 0 Then
            MessageBox.Show("PO number missing, try again.", "Warning")

            ResetForm()
        Else
            
            CmbGl.DataBindings.Clear()
            CmbGl.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.POAccount")

            PutSalesTax()

            PutDevise()


            dsMain.Clear()
            CallClass.PopulateDataAdapterAfterSearch("getTblPoMasterByPO", strSearch).Fill(dsMain, "tblPOMaster")
            CallClass.PopulateDataAdapterAfterSearch("getTblPoDetailsLikePONo", strSearch).Fill(dsMain, "tblPOReceiving")

            Call BindComponents()

            SrcPO.Enabled = False

            dgDetails.AutoGenerateColumns = False
            dgDetails.DataSource = dsMain
            dgDetails.DataMember = "tblPOMaster"

            dgInsp.AutoGenerateColumns = False
            dgInsp.DataSource = dsMain
            dgInsp.DataMember = "tblPOReceiving"

            dgDetails.Focus()

            If dsMain.Tables("tblPOReceiving").Rows.Count = 0 Then
                MessageBox.Show("No Receiving data in the system. Action denied.")

                ResetForm()
            Else

                Call TotalPO()

                TotalToPay()

                If dgInsp.Rows.Count > 0 Then
                    dgInsp.Rows(0).Selected = True
                End If

                CmdReset.Enabled = True

                If SwNext = True Then
                    EnblButtons()
                    dgInsp.ReadOnly = False

                    For Each Row As DataGridViewRow In dgInsp.Rows
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
        End If
    End Sub

    Sub CalculGrid()

        On Error Resume Next

        Dim TotalPO As Decimal = 0
        Dim ValGST As Decimal = 0
        Dim ValQST As Decimal = 0
        Dim ValTVH As Decimal = 0
        Dim ValPo As Decimal = 0

        txtTotalPOValue.Text = 0
        txtValGST.Text = 0
        txtValQST.Text = 0
        txtValTVH.Text = 0
        txtValPO.Text = 0

        If dgDetails.Rows.Count > 0 Then
            Dim I As Integer = 0
            For I = 0 To dgDetails.Rows.Count - 1
                If IsDBNull(Me.dgDetails("POQty", I).Value) = False And _
                    IsDBNull(Me.dgDetails("POPrice", I).Value) = False Then
                    If IsDBNull(Me.dgDetails.Item("POItemescompte", I).Value) = True Or _
                        IsNothing(Me.dgDetails.Item("POItemescompte", I).Value) = True Then
                        Me.dgDetails("TotalValue", I).Value = Me.dgDetails("POQty", I).Value * (Me.dgDetails("POPrice", I).Value + Nz.Nz(Me.dgDetails("PORMSPrice", I).Value))
                    Else
                        Me.dgDetails("TotalValue", I).Value = _
                        Me.dgDetails("POQty", I).Value * _
                        ((Me.dgDetails("POPrice", I).Value * (1 - Me.dgDetails.Item("POItemescompte", I).Value / 100)) + Nz.Nz(Me.dgDetails("PORMSPrice", I).Value))
                    End If
                End If
                TotalPO = Math.Round((TotalPO + Me.dgDetails("TotalValue", I).Value), 4)
            Next
        End If

        ValGST = TotalPO * txtGST.Text
        ValQST = TotalPO * txtQST.Text
        ValTVH = TotalPO * txtTVH.Text
        ValPo = TotalPO + ValGST + ValQST + ValTVH

        txtTotalPOValue.Text = TotalPO.ToString("C2")
        txtValGST.Text = ValGST.ToString("C2")
        txtValQST.Text = ValQST.ToString("C2")
        txtValTVH.Text = ValTVH.ToString("C2")
        txtValPO.Text = ValPo.ToString("C2")

    End Sub

    Sub PutSalesTax()

        strSQL = " SELECT SalesTaxID, DolarSign, GstRate, QstRate, TvhRate, Country FROM tblSalesTax"

        Try
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblSalesTax")

            With CmbSalesTax
                .DataSource = ds.Tables("tblSalesTax")
                .DisplayMember = "Country"
                .ValueMember = "SalesTaxID"
                'If SwPo = 0 Then
                '    .SelectedValue = 3
                'End If
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
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cn)
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

    Sub CheckGLAccount()

        Dim I As Integer

        For I = 0 To dgDetails.Rows.Count - 1
            If IsDBNull(dgDetails("PODetailAccountID", I).Value) = True Then
                Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePODetailGLAccount", cn)
                mySqlComm.CommandType = CommandType.StoredProcedure

                Dim paraDetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
                paraDetailID.Value = dgDetails("PODetailID", I).Value
                mySqlComm.Parameters.Add(paraDetailID)

                Dim paraGL As SqlParameter = New SqlParameter("@PODetailAccountID", SqlDbType.Int, 4)
                paraGL.Value = CmbGl.SelectedValue
                mySqlComm.Parameters.Add(paraGL)

                Try
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    mySqlComm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("!!! ERROR !!! Update GL Account ID: " & ex.Message)
                Finally
                    cn.Close()
                End Try
            End If
        Next

    End Sub

    Sub TotalToPay()

        If dgInsp.Rows.Count <= 0 Then
            Exit Sub
        End If

        TotalPO()

        Dim I As Integer
        Dim tvalue As Single

        Select Case cmbPOType.Text
            Case "Processing", "Sub-Contracting"

                tvalue = 0
                For I = 0 To dgInsp.Rows.Count - 1
                    If IsDBNull(dgInsp("PayInvDate", I).Value) = True And _
                                            Nz.Nz(dgInsp("ApprRecvToPay", I).Value) = "1" Then

                        If Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) = 0 Then
                            tvalue = tvalue + _
                                Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value) * _
                                (Nz.Nz(Me.dgInsp("PslipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value))
                        Else
                            tvalue = tvalue + _
                                Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value) * _
                                (Nz.Nz(Me.dgInsp("PslipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value)) * _
                                (1 - Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) / 100)
                        End If

                    End If
                Next

                txtToPay.Text = tvalue.ToString("C2")

                tvalue = 0
                For I = 0 To dgInsp.Rows.Count - 1
                    If IsDBNull(dgInsp("PayInvDate", I).Value) = False And _
                                                Nz.Nz(dgInsp("ApprRecvToPay", I).Value) = "1" Then

                        If Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) = 0 Then
                            tvalue = tvalue + _
                                    Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value) * _
                                    (Nz.Nz(Me.dgInsp("PslipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value))
                        Else
                            tvalue = tvalue + _
                                    Nz.Nz(Me.dgInsp("RecQtyAccp", I).Value) * _
                                   (Nz.Nz(Me.dgInsp("PslipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value)) * _
                                    (1 - Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) / 100)
                        End If
                    End If
                Next

                txtPayed.Text = tvalue.ToString("C2")

            Case Else
                tvalue = 0
                For I = 0 To dgInsp.Rows.Count - 1
                    If IsDBNull(dgInsp("PayInvDate", I).Value) = True And _
                                               Nz.Nz(dgInsp("ApprRecvToPay", I).Value) = "1" Then

                        tvalue = tvalue + CDec(Nz.Nz(Me.dgInsp("TotalPslipValue", I).Value))
                    End If
                Next

                txtToPay.Text = tvalue.ToString("C2")

                tvalue = 0
                For I = 0 To dgInsp.Rows.Count - 1
                    If IsDBNull(dgInsp("PayInvDate", I).Value) = False And _
                                                Nz.Nz(dgInsp("ApprRecvToPay", I).Value) = "1" Then

                        tvalue = tvalue + CDec(Nz.Nz(Me.dgInsp("TotalPslipValue", I).Value))
                    End If
                Next

                txtPayed.Text = tvalue.ToString("C2")
        End Select

    End Sub

    Sub TotalPO()

        Dim tqty As Integer = 0
        Dim tqPSty As Integer = 0

        If dgDetails.Rows.Count > 0 Then
            Dim I As Integer

            Dim tvalue As Single
            For I = 0 To dgDetails.Rows.Count - 1
                If Nz.Nz(Me.dgDetails.Item("POItemEscompte", I).Value) = 0 Then
                    Me.dgDetails("TotalValue", I).Value = _
                    Nz.Nz(Me.dgDetails("POQty", I).Value) * _
                    (Nz.Nz(Me.dgDetails("POPrice", I).Value) + Nz.Nz(Me.dgDetails("PORMSPrice", I).Value))
                Else
                    Me.dgDetails("TotalValue", I).Value = _
                    Nz.Nz(Me.dgDetails("POQty", I).Value) * _
                    (Nz.Nz(Me.dgDetails("POPrice", I).Value) + Nz.Nz(Me.dgDetails("PORMSPrice", I).Value)) * _
                    (1 - Nz.Nz(Me.dgDetails.Item("POItemEscompte", I).Value) / 100)
                End If

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
                If Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) = 0 Then
                    Me.dgInsp("TotalPslipValue", I).Value = Nz.Nz(Me.dgInsp("PSlipQty", I).Value) * _
                    (Nz.Nz(Me.dgInsp("PSlipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value))
                Else
                    Me.dgInsp("TotalPslipValue", I).Value = _
                    Nz.Nz(Me.dgInsp("PSlipQty", I).Value) * _
                    (Nz.Nz(Me.dgInsp("PSlipPrice", I).Value) + Nz.Nz(Me.dgInsp("RecvDetRmsPrice", I).Value)) * _
                    (1 - Nz.Nz(Me.dgInsp.Item("PslipDiscount", I).Value) / 100)
                End If

                tqPSty = tqPSty + CDec(Nz.Nz(Me.dgInsp("PSlipQty", I).Value))
                tvalue = tvalue + CDec(Nz.Nz(Me.dgInsp("TotalPslipValue", I).Value))
            Next
            txtTotalPSlipQty.Text = tqPSty.ToString("N2")
            txtTotalPSlipValue.Text = tvalue.ToString("C2")
        End If

        txtBal.Text = (tqty - tqPSty).ToString("N2")

        Me.ErrorProvider1.Clear()

        If tqty - tqPSty <> 0 Then
            Me.ErrorProvider1.SetError(txtBal, "Qty PO <> Qty Received.")
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If

    End Sub

    Private Sub dgDetails_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDetails.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowDetails = e.RowIndex
        End If


        If IsDBNull(dgInsp("PayInvDate", RowInsp).Value) = False And _
                    IsDBNull(dgInsp("ApprRecvToPay", RowInsp).Value) = False Then
            e.Cancel = True
            Exit Sub
        End If


        If cmbPOType.Text = "Raw Material" Then
            e.Cancel = True
            Exit Sub
        End If


        Select Case e.ColumnIndex
            Case 0 To 2
                e.Cancel = True
            Case 7 To 8
                e.Cancel = True
            Case 10 To 11
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgDetails_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowDetails = e.RowIndex

        TotalPO()

        SelectInspRow()

    End Sub

    Private Sub dgDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetails.CellEndEdit

        Dim reply As DialogResult

        Select Case e.ColumnIndex
            Case 3
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateQtyPO()
                Else
                    dgDetails.CancelEdit()
                End If
            Case 4
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateUMPO()
                Else
                    dgDetails.CancelEdit()
                End If
            Case 5
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdatePricePO()
                Else
                    dgDetails.CancelEdit()
                End If
            Case 6
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateDiscountPO()
                Else
                    dgDetails.CancelEdit()
                End If
        End Select

        UpDateEmpName()

        SearchPO()

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

        If e.RowIndex < 0 Then
            Return
        Else
            RowInsp = e.RowIndex
        End If

        TotalToPay()

        Select Case e.ColumnIndex
            Case 0 To 5
                e.Cancel = True
            Case 10 To 13
                e.Cancel = True
            Case 15, 16
                e.Cancel = True
            Case 17
                If IsDBNull(dgInsp("PONo", e.RowIndex).Value) = True Then
                    e.Cancel = True
                    MsgBox("Action Denied. Please received data in the system before your payment selection.")
                End If

                If cmbPOType.Text = "Processing" Or cmbPOType.Text = "Sub-Contracting" Then
                    If IsDBNull(dgInsp("RecQtyAccp", e.RowIndex).Value) = True Then
                        e.Cancel = True
                        MsgBox("Action Denied.. Missing Accepted Quantity for Sub-Contracting.")
                    End If
                End If

            Case 18 To 20
                e.Cancel = True

        End Select

    End Sub

    Private Sub dgInsp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInsp.CellClick


        If e.RowIndex < 0 Then
            Return
        Else
            RowInsp = e.RowIndex
        End If

        Dim reply As DialogResult

        For Each Row As DataGridViewRow In dgInsp.Rows
            If IsDBNull(Row.Cells("RecQtyAccp").Value) = False Then
                Row.Cells("RecQtyRej").Value = Nz.Nz(Row.Cells("PSlipQty").Value) - Nz.Nz(Row.Cells("RecQtyAccp").Value)
            Else
                Row.Cells("RecQtyRej").Value = 0
            End If
        Next

        TotalPO()

        TotalToPay()

        Select Case e.ColumnIndex
            Case 14    'view Memo
                If IsDBNull(dgInsp("RecMemoNo", e.RowIndex).Value) = True Then
                    MsgBox("Nothing to View.")
                    Exit Sub
                End If

                If Nz.Nz(dgInsp("RecMemoNo", e.RowIndex).Value) > 0 Then

                    Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                    Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim rptPO As New rptLisiMemo()
                    rptPO.ReportOptions.EnableSaveDataWithReport = False

                    Dim FindMemo As String
                    FindMemo = dgInsp("RecMemoNo", e.RowIndex).Value

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

            Case 17

                Dim TetInt As String = ""
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    TetInt = Nz.Nz(dgInsp("ApprRecvToPay", RowInsp).Value)
                    If TetInt = False Then
                        UpdateApprRecvToPayTrue()
                    Else
                        UpdateApprRecvToPayFalse()
                    End If

                    SearchPO()
                Else
                    dgInsp.CancelEdit()
                End If

        End Select

    End Sub

    Private Sub dgInsp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInsp.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowInsp = e.RowIndex
        End If

        Dim reply As DialogResult

        Select Case e.ColumnIndex

            Case 6              'recv qty
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    'If dgInsp("PSlipQty", RowInsp).Value > dgDetails("POQty", RowDetails).Value Then
                    '    MsgBox("!!! ERROR !!! Qty Received is > Qty PO. Action Denied.")
                    '    dgInsp.CancelEdit()
                    'Else
                    If dgInsp("PSlipQty", RowInsp).Value = 0 Then
                        MsgBox("!!! ERROR !!! Qty Received is 0. Action Denied.")
                        dgInsp.CancelEdit()
                    Else
                        UpdateQtyRecv()
                    End If
                    'End If
                Else
                    dgInsp.CancelEdit()
                End If

            Case 7
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    If IsNothing(dgInsp("PslipUM", RowInsp).Value) = True Then
                        MsgBox("!!! ERROR !!! UM Received is Empty. Action Denied.")
                        dgInsp.CancelEdit()
                    Else
                        UpdateUMRecv()
                    End If
                Else
                    dgInsp.CancelEdit()
                End If

            Case 8
                reply = MsgBox("EDIT ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    If dgInsp("PslipPrice", RowInsp).Value = 0 Then
                        MsgBox("!!! ERROR !!! Price  Received is Empty. Action Denied.")
                        dgInsp.CancelEdit()
                    Else
                        UpdatePriceRecv()
                    End If
                Else
                    dgInsp.CancelEdit()
                End If


        End Select

        TotalPO()

        TotalToPay()

    End Sub

    Private Sub dgInsp_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgInsp.DataError
        REM end
    End Sub

    Sub UpdateApprRecvToPayTrue()

        If RowInsp < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateApprRecvToPayTrueFalse", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
        paraID.Value = dgInsp("PORecvID", RowInsp).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraAppr As SqlParameter = New SqlParameter("@ApprRecvToPay", SqlDbType.Bit, 1)
        paraAppr.Value = True
        mySqlComm.Parameters.Add(paraAppr)

        Dim paraApprDate As SqlParameter = New SqlParameter("@PayInvDate", SqlDbType.SmallDateTime, 4)
        paraApprDate.Value = Now().ToShortDateString
        mySqlComm.Parameters.Add(paraApprDate)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Approve Payment: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateApprRecvToPayFalse()

        If RowInsp < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateApprRecvToPayTrueFalse", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
        paraID.Value = dgInsp("PORecvID", RowInsp).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraAppr As SqlParameter = New SqlParameter("@ApprRecvToPay", SqlDbType.Bit, 1)
        paraAppr.Value = False
        mySqlComm.Parameters.Add(paraAppr)

        Dim paraApprDate As SqlParameter = New SqlParameter("@PayInvDate", SqlDbType.SmallDateTime, 4)
        paraApprDate.Value = DBNull.Value
        mySqlComm.Parameters.Add(paraApprDate)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Approve Payment: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateQtyRecv()

        If RowInsp < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccRecvQty", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
        paraID.Value = dgInsp("PORecvID", RowInsp).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraQty As SqlParameter = New SqlParameter("@PSlipQty", SqlDbType.Float, 8)
        paraQty.Value = dgInsp("PSlipQty", RowInsp).Value
        mySqlComm.Parameters.Add(paraQty)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Recv. Qty: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateUMRecv()

        If RowInsp < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccRecvUM", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
        paraID.Value = dgInsp("PORecvID", RowInsp).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraUM As SqlParameter = New SqlParameter("@PslipUM", SqlDbType.NVarChar, 10)
        paraUM.Value = dgInsp("PslipUM", RowInsp).Value
        mySqlComm.Parameters.Add(paraUM)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Recv. UM: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdatePriceRecv()

        If RowInsp < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccRecvPOPrice", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
        paraID.Value = dgInsp("PORecvID", RowInsp).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraPrice As SqlParameter = New SqlParameter("@PslipPrice", SqlDbType.Float, 8)
        paraPrice.Value = dgInsp("PslipPrice", RowInsp).Value
        mySqlComm.Parameters.Add(paraPrice)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Recv. Price: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateQtyPO()

        If RowDetails < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccPOQty", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgDetails("PODetailID", RowDetails).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraQty As SqlParameter = New SqlParameter("@POQty", SqlDbType.Real, 4)
        paraQty.Value = dgDetails("POQty", RowDetails).Value
        mySqlComm.Parameters.Add(paraQty)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO Qty: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateUMPO()

        If RowDetails < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccPOUM", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgDetails("PODetailID", RowDetails).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraUM As SqlParameter = New SqlParameter("@POUM", SqlDbType.NVarChar, 5)
        paraUM.Value = dgDetails("POUM", RowDetails).Value
        mySqlComm.Parameters.Add(paraUM)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO / Recv. UM: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdatePricePO()

        If RowDetails < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccPOPrice_2", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgDetails("PODetailID", RowDetails).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraPrice As SqlParameter = New SqlParameter("@POPrice", SqlDbType.Money, 8)
        paraPrice.Value = dgDetails("POPrice", RowDetails).Value
        mySqlComm.Parameters.Add(paraPrice)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO / Recv. Price: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Sub UpdateDiscountPO()

        If RowDetails < 0 Then
            Return
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccPODiscountAndRecv", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgDetails("PODetailID", RowDetails).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraDiscount As SqlParameter = New SqlParameter("@POItemEscompte", SqlDbType.Real, 4)
        paraDiscount.Value = dgDetails("POItemEscompte", RowDetails).Value
        mySqlComm.Parameters.Add(paraDiscount)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO / Recv. Discount: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        ResetForm()

    End Sub

    Sub ResetForm()

        InitFields()

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
                Row.Cells("PONo").Selected = True
                Row.Cells("POItem").Selected = True
                'Row.Selected = True
            End If
        Next

    End Sub

    Sub UpdateRecvAcceptedQty(ByVal dsChanges As DataSet)

        Dim cmdUpdPORec As SqlCommand

        cmdUpdPORec = New SqlCommand()
        cmdUpdPORec.Connection = cn
        cmdUpdPORec.CommandType = CommandType.StoredProcedure
        cmdUpdPORec.CommandText = "cspUpdateAccPayInvNo"

        '' Add Parameters to update sproc
        cmdUpdPORec.Parameters.Add("@PORecvID", SqlDbType.Int, 4, "PORecvID")

        cmdUpdPORec.Parameters.Add("@PayInvDate", SqlDbType.SmallDateTime, 4, "PayInvDate")
        cmdUpdPORec.Parameters.Add("@ApprRecvToPay", SqlDbType.Bit, 1, "ApprRecvToPay")

        ''DataApapter
        Dim daPORec = New SqlDataAdapter()
        daPORec.UpdateCommand = cmdUpdPORec
        daPORec.TableMappings.Add("Table", "tblPOReceiving")

        daPORec.Update(dsChanges)

    End Sub

    Private Sub CmdTranz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTranz.Click

        Dim KeepPo As String = ""
        KeepPo = txtPONumber.Text

        ValTranz()

        If SwVal = True Then

            Try

                UpdateTranz()

                dgInsp.EndEdit()
                'To change the current row, to the last row:
                Dim cellLastRow As DataGridViewCell = dgInsp.Rows(dgInsp.Rows.Count - 1).Cells(2)
                dgInsp.CurrentCell = cellLastRow
                If dsMain.HasChanges Then
                    UpdateRecvAcceptedQty(dsMain.GetChanges)
                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - REQ: " & ex.Message)
            End Try

            Call SetupForm()
            If Len(Trim(KeepPo)) <> 0 Then
                SrcPO.Text = KeepPo
                SearchPO()
            End If

        End If

    End Sub

    Sub ValTranz()

        SwVal = False

        If Val(txtTrType.Text) = 0 Then
            MsgBox("!!! ERROR !!! Type Tranzaction")
            SwVal = False
            Exit Sub
        Else
            SwVal = True
        End If

        If Val(txtTrQty.Text) = 0 Then
            MsgBox("!!! ERROR !!! Qty. Tranzaction")
            SwVal = False
            Exit Sub
        Else
            SwVal = True
        End If

        If Val(txtTrPrice.Text) <= 0 Then
            MsgBox("!!! ERROR !!! Price Tranzaction")
            SwVal = False
            Exit Sub
        Else
            SwVal = True
        End If

    End Sub

    Sub UpdateTranz()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccPayTranz", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraDetID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraDetID.Value = dgDetails("PODetailID", 0).Value
        mySqlComm.Parameters.Add(paraDetID)

        Dim paraData As SqlParameter = New SqlParameter("@RecDate", SqlDbType.SmallDateTime, 4)
        paraData.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraData)

        Dim paraText As SqlParameter = New SqlParameter("@PSlipNum", SqlDbType.NVarChar, 30)
        paraText.Value = Trim(txtTrNotes.Text)
        mySqlComm.Parameters.Add(paraText)

        Dim paraQty As SqlParameter = New SqlParameter("@PSlipQty", SqlDbType.Float, 8)
        paraQty.Value = Val(txtTrQty.Text)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraPr As SqlParameter = New SqlParameter("@PslipPrice", SqlDbType.Float, 8)
        paraPr.Value = Val(txtTrPrice.Text)
        mySqlComm.Parameters.Add(paraPr)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Update Accounts Payable Tranzaction : " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try


    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click



        Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()


        Try
            Dim rptPO As New rptAcctPayableSummary()
            rptPO.Load("..\rptAcctPayableSummary.rpt")
            pdFind.Value = dgInsp("PONo", RowInsp).Value


            pvFindCollection.Add(pdFind)

            rptPO.DataDefinition.ParameterFields("@StrSearch").ApplyCurrentValues(pvFindCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True

            frmPOMasterPrint.Show()
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Private Sub CmdPrintAccPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintAccPO.Click
        SwEndUser = ""

        Dim SwMPOId As Integer = 0
        SwMPOId = Nz.Nz(dgDetails.Rows(RowDetails).Cells("POMpoID").Value)
        'If SwMPOId = 0 Then
        'Exit Sub
        'Else
        SwEndUser = CallClass.ReturnStrWithParInt("cspReturnMpoEndUserClient", SwMPOId)
        If SwEndUser = "False" Then
            SwEndUser = ""
        Else
            SwEndUser = SwEndUser + "  End User"
        End If
        'End If

        Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptPOAcc()
            rptPO.Load("..\rptPOAcc.rpt")
            pdFind.Value = dgInsp("PoNo", RowInsp).Value
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
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Sub UpDateEmpName()

        ' Purchasing accounting user
        Dim II, JJ As Integer
        JJ = dgDetails.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPOUser", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPOPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
            parPOPOMasterID.Value = dgDetails.Item("POMasterID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOPOMasterID)

            Dim parPOAccUser As SqlParameter = New SqlParameter("@POAccUser", SqlDbType.NVarChar, 50)
            parPOAccUser.Value = Trim(cmbUser.Text)
            cmdInsertDetail.Parameters.Add(parPOAccUser)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO Accounting User: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
    End Sub

    Sub UpdateAccNotes()
        ' Purchasing information  accounting notes  only one line

        Dim II, JJ As Integer
        JJ = dgDetails.Rows.Count

        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPONotes", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPOPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
            parPOPOMasterID.Value = dgDetails.Item("POMasterID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOPOMasterID)

            Dim parPOAccNotes As SqlParameter = New SqlParameter("@POAccNotes", SqlDbType.NVarChar, 1000)
            parPOAccNotes.Value = Trim(txtAccNotes.Text)
            cmdInsertDetail.Parameters.Add(parPOAccNotes)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO Accounting Notes: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next

    End Sub

    Private Sub txtAccNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccNotes.Validating
        If RowDetails < 0 Then
            Exit Sub
        End If

        If dgDetails.Rows.Count - 1 >= 0 Then
            dgDetails("POAccNotes", RowDetails).Value = Trim(txtAccNotes.Text)
            UpdateAccNotes()
        End If
    End Sub

    Private Sub frmAccPayable_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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