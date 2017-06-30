Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmReceivingPerishable

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim strSQL As String = ""

    Dim SwpoDetailID As Integer
    Dim SwpoNum As String
    Dim SwPoItem As String
    Dim Swpoqty As Double
    Dim SwNext As Boolean = False  ' if false stop execution

    Dim RowDetails As Integer = 0       'dgDetails row.
    Dim RowIsp As Integer = 0       ' dgInsp row
    Dim KeepNo As Integer = 0

    Private Sub frmReceivingPerishable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub frmReceivingPerishable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        CallClass.PopulateDataAdapter("gettblPoDetailsEmpty").Fill(dsMain, "tblPODetails")
        CallClass.PopulateDataAdapter("gettblPoReceivingEmpty").Fill(dsMain, "tblPOReceiving")

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
        txtPODate.ReadOnly = True

        dgDetails.ReadOnly = True
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

        'For dgDetails properies

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

        With Me.POProdIDSpec
            .DataSource = CallClass.PopulateComboBox("tblProdDesc", "poRecGetProd").Tables("tblProdDesc")
            .DisplayMember = "ProdSpec"
            .ValueMember = "ProdID"
            .DataPropertyName = "POProdID"
            .Name = "POProdIDSpec"
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

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With


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

        With Me.PslipMpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAll").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
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

        With Me.StLoc
            .DataPropertyName = "StLoc"
            .Name = "StLoc"
        End With

        With Me.POProdIDPer
            .DataPropertyName = "POProdIDPer"
            .Name = "POProdIDPer"
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
        CmbDevise.DataBindings.Clear()

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
        CmbDevise.DataBindings.Add("SelectedValue", dsMain, "tblPOMaster.PODevise")

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
                SwNext = False
            Case "Open"
                'If cmbPOType.Text = "Perishable" Then
                SwNext = True
                'Else
                '    MsgBox("For this PO Type: " + cmbPOType.Text + " ---  Perishable / Acceptance is not necessary.")
                '    SwNext = False
                'End If
            Case Else
                MessageBox.Show("For this PO Type: " + cmbPOType.Text + " --- Perishable / Acceptance is not necessary.")
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

            Call PutDevise()

            CmdReset.Enabled = True

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



            If SwNext = True Then
                EnblButtons()
                dgInsp.ReadOnly = True
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

        If Nz.Nz(dgInsp("ApprRecvToPay", e.RowIndex).Value) = "1" Then
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
                Case 17     'switch aproved for payment
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
                Row.Cells("RecQtyAccp").Style.BackColor = Color.LightBlue
                Row.Cells("PSlipNum").Style.BackColor = Color.LightBlue
                Row.Cells("PSlipQty").Style.BackColor = Color.LightBlue

                Row.Cells("RecQtyRej").Style.BackColor = Color.LightYellow
                Row.Cells("ApprInsp").Style.BackColor = Color.LightYellow
                Row.Cells("StLoc").Style.BackColor = Color.LightYellow

                If IsDBNull(Row.Cells("RecQtyAccp").Value) = False Then
                    Row.Cells("RecQtyRej").Value = Nz.Nz(Row.Cells("PSlipQty").Value) - Nz.Nz(Row.Cells("RecQtyAccp").Value)
                Else
                    Row.Cells("RecQtyRej").Value = 0
                End If
            Next

            TotalPO()

        End If

        If SwNext = True Then
            dgInsp.ReadOnly = False
            Select Case e.ColumnIndex
                Case 0 To 12
                    dgInsp.Columns(e.ColumnIndex).ReadOnly = True
                Case 14, 17, 18
                    dgInsp.Columns(e.ColumnIndex).ReadOnly = True

            End Select
        Else
            MessageBox.Show("Access Denied.")
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
            Dim cellLastRow As DataGridViewCell = dgInsp.Rows(dgInsp.Rows.Count - 1).Cells(3)
            dgInsp.CurrentCell = cellLastRow

            Try
                If dsMain.HasChanges Then
                    UpdateRecvAcceptedQty(dsMain.GetChanges)

                    UpdateTranzPerishable()
                    CallClass.UpdatePerishableStock("cspUpdatetblStockPerishable")

                    MsgBox("Update successfully.")

                    CmdReset.Enabled = True

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
                        'If recQty >= ppoQty Then
                        '    ''''''UpdatePOStatusAccepted()
                        'End If
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

        Call SetupForm()

    End Sub

    Sub UpdateTranzPerishable()

        Dim II, JJ As Integer

        JJ = dgInsp.Rows.Count

        For II = 1 To JJ

            Try
                Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRecvPerishable", cn)
                mySqlComm.CommandType = CommandType.StoredProcedure

                Dim paraRecID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
                paraRecID.Value = dgInsp.Item("PORecvID", II - 1).Value
                mySqlComm.Parameters.Add(paraRecID)

                Dim paraProd As SqlParameter = New SqlParameter("@ProdStockID", SqlDbType.Int, 4)
                paraProd.Value = dgInsp.Item("POProdIDPer", II - 1).Value
                mySqlComm.Parameters.Add(paraProd)

                Dim paraOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
                paraOper.Value = 1
                mySqlComm.Parameters.Add(paraOper)

                Dim paraStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
                paraStatus.Value = "O"
                mySqlComm.Parameters.Add(paraStatus)

                Dim paraDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
                paraDate.Value = Now.ToShortDateString
                mySqlComm.Parameters.Add(paraDate)



                If IsNothing(dgInsp.Item("RecQtyAccp", II - 1).Value) = True Then
                    GoTo SkipLine
                End If
                If IsDBNull(dgInsp.Item("RecQtyAccp", II - 1).Value) = True Then
                    GoTo SkipLine
                End If
                If Nz.Nz(dgInsp.Item("RecQtyAccp", II - 1).Value) = 0 Then
                    GoTo SkipLine
                End If
                Dim paraQty As SqlParameter = New SqlParameter("@QtyAccepted", SqlDbType.Real, 4)
                paraQty.Value = dgInsp.Item("RecQtyAccp", II - 1).Value
                mySqlComm.Parameters.Add(paraQty)




                Dim paraUM As SqlParameter = New SqlParameter("@TRUM", SqlDbType.NVarChar, 10)
                paraUM.Value = dgInsp.Item("PslipUM", II - 1).Value
                mySqlComm.Parameters.Add(paraUM)

                Dim paraPrice As SqlParameter = New SqlParameter("@PriceTranz", SqlDbType.SmallMoney, 4)
                paraPrice.Value = dgInsp.Item("PslipPrice", II - 1).Value
                mySqlComm.Parameters.Add(paraPrice)

                Dim paraDevise As SqlParameter = New SqlParameter("@TrDevise", SqlDbType.NVarChar, 10)
                paraDevise.Value = cmbDevise.Text
                mySqlComm.Parameters.Add(paraDevise)

                If IsNothing(dgInsp.Item("StLoc", II - 1).Value) = True Then
                    dgInsp.Item("StLoc", II - 1).Value = DBNull.Value
                End If
                Dim paraLoc As SqlParameter = New SqlParameter("@StLoc", SqlDbType.NVarChar, 20)
                paraLoc.Value = dgInsp.Item("StLoc", II - 1).Value
                mySqlComm.Parameters.Add(paraLoc)

                Try
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    mySqlComm.ExecuteNonQuery()
                    cn.Close()
                Catch ex As SqlException
                    MsgBox("Update Perishable Inventory (InPut): " & ex.Message)
                End Try
            Catch ex As Exception
                MsgBox("Update Perishable Inventory (InPut): " & ex.Message)
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

SkipLine:

        Next

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

End Class