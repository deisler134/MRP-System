Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic


Public Class frmMpoSplitProd

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Dim ParMpoID As Integer
    Dim ParQty As Single
    Dim ParBool As Boolean = False
    Dim RowMpo As Integer = 0
    Dim SwMpoID As String = ""

    Private Sub frmMpoSplitProd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub frmMpoSplitProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Call SetupForm()

    End Sub

    Sub SetupForm()

        CmdVer.Enabled = False
        CmdVer.Visible = False
        CmdSave.Enabled = False
        CmdSave.Visible = False
        CmdPrint.Visible = False

        CmdReset.Enabled = True

        DisableFields()

        InitialComponents()

        SetCtlForm()

        PutMpoMasterProd()

        If fBool = True Then
            txtActualSplit.Text = fQty
            CmbMpo.SelectedValue = fMpo

            ContinueCmbMpo()

            CmbMpo.Enabled = False
            CmdReset.Enabled = False
            dgMpo.Enabled = False
            txtActualSplit.ReadOnly = True
        Else
            CmbMpo.SelectedIndex = -1
        End If


        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblMpoMaster"

    End Sub

    Sub DisableFields()

        txtSufix.ReadOnly = True
        txtOper.ReadOnly = True
        txtActualSplit.ReadOnly = True

        txtSufix.Text = ""
        txtActualSplit.Text = 0
        txtWeightPcs.Text = 0
        txtOper.Text = ""
        txtDescr.Text = ""
        txtSpec.Text = ""

        txtActualOldCh.Text = ""
        txtEngOldCh.Text = ""
        txtSalesOldCh.Text = ""
        txtWeightOldCh.Text = ""

        txtMpoNew.Text = ""
        txtActualNew.Text = ""
        txtEngNew.Text = ""
        txtSalesNew.Text = ""
        txtWeightNew.Text = ""

        txtMpoType.Text = ""
        txtMpoType.ReadOnly = True

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getTblMpoMasterEmpty").Fill(dsMain, "tblMpoMaster")

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutMpoMasterProd()

        With CmbMpo
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterProd").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Private Sub CmbMpo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpo.Click
        PutMpoMasterProd()
    End Sub

    Private Sub CmbMpo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpo.DropDownClosed
        ContinueCmbMpo()
    End Sub

    Sub ContinueCmbMpo()

        Dim strSearch As Integer
        strSearch = CmbMpo.SelectedValue

        If strSearch <> 0 Then
            dsMain.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getMpoMasterDataForSplit", strSearch).Fill(dsMain, "tblMpoMaster")

            BindComponents()

            CmbMpo.Enabled = False

            SwOper = "NEW"

            txtSufix.ReadOnly = False
            txtActualSplit.ReadOnly = False
            txtOper.ReadOnly = False

            CmdVer.Enabled = True
            CmdVer.Visible = True

            If Val(txtEngOld.Text) > 0 Then
                txtWeightPcs.Text = Math.Round((Val(txtWeightOld.Text) / Val(txtEngOld.Text)), 5)
            End If

            'Put Grid Info

            Dim strText As String

            If InStr(txtMpoOld.Text, "-") <> 0 Then
                strText = Trim(Microsoft.VisualBasic.Left(Trim(txtMpoOld.Text), InStr(txtMpoOld.Text, "-") - 1))
            Else
                strText = Trim(txtMpoOld.Text)
            End If

            dsMain.Clear()

            CallClass.PopulateDataAdapterAfterSearch("getMpoMasterSplitHistory", strText).Fill(dsMain, "tblMpoMaster")

            dgMpo.AutoGenerateColumns = False
            dgMpo.DataSource = dsMain
            dgMpo.DataMember = "tblMpoMaster"
            dgMpo.Enabled = True

        End If

    End Sub
    Sub SetCtlForm()

        With Me.MpoId
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.PartId
            .DataPropertyName = "PartId"
            .Name = "PartId"
            .Visible = False
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
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

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.TotalMatl
            .DataPropertyName = "TotalMatl"
            .Name = "TotalMatl"
        End With

    End Sub

    Sub BindComponents()

        txtMpoOld.DataBindings.Clear()
        txtMpoOldID.DataBindings.Clear()
        txtMpoType.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()

        txtDept.DataBindings.Clear()
        txtLotNo.DataBindings.Clear()
        txtActualOld.DataBindings.Clear()
        txtEngOld.DataBindings.Clear()
        txtSalesOld.DataBindings.Clear()

        txtWeightOld.DataBindings.Clear()
        txtMpoOld.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoNo")
        txtMpoOldID.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoID")

        txtMpoType.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoType")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblMpoMaster.PartNumber")

        txtDept.DataBindings.Add("Text", dsMain, "tblMpoMaster.DeptNode")
        txtLotNo.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoLotNo")
        txtActualOld.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyActual")
        txtEngOld.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyEngReleased")
        txtSalesOld.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyOrder")
        txtWeightOld.DataBindings.Add("Text", dsMain, "tblMpoMaster.TotalMatl")
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        CmdVer.Enabled = False
        CmdVer.Visible = False
        CmdSave.Enabled = False
        CmdSave.Visible = False

        DisableFields()

        CmbMpo.Enabled = True
        CmbMpo.SelectedIndex = -1

        dsMain.Clear()
        BindComponents()

        SwOper = ""

    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

        If Val(txtEngOld.Text) > 0 Then
            txtWeightPcs.Text = Math.Round((Val(txtWeightOld.Text) / Val(txtEngOld.Text)), 4)
        End If

        If InStr(dgMpo("MpoNo", RowMpo).Value, "-") <> 0 Then
            CmdPrint.Visible = True
        Else
            CmdPrint.Visible = False
        End If

    End Sub

    Private Sub dgMpo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

    End Sub

    Private Sub dgMpo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMpo.Click

        'If Val(txtEngOld.Text) > 0 Then
        '    txtWeightPcs.Text = Math.Round((Val(txtWeightOld.Text) / Val(txtEngOld.Text)), 4)
        'End If

    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Private Sub CmdVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdVer.Click

        dgMpo.Enabled = False

        txtDescr.Text = ""
        txtSpec.Text = ""

        ValData()

        If SwVal = True Then
            CmdVer.Visible = False
            CmdSave.Visible = True
            CmdSave.Enabled = True

            txtSufix.ReadOnly = True
            txtActualSplit.ReadOnly = True
            txtOper.ReadOnly = True

            CalculateSplit()
        Else
            dgMpo.Enabled = True
        End If
       
    End Sub

    Sub CalculateSplit()

        If InStr(txtMpoOld.Text, "-") <> 0 Then
            txtMpoNew.Text = Trim(Microsoft.VisualBasic.Left(Trim(txtMpoOld.Text), InStr(txtMpoOld.Text, "-") - 1)) + "-" + Trim(txtSufix.Text)
        Else
            txtMpoNew.Text = Trim(txtMpoOld.Text) + "-" + Trim(txtSufix.Text)
        End If

        txtActualOldCh.Text = Val(txtActualOld.Text) - Val(txtActualSplit.Text)
        txtActualNew.Text = Val(txtActualSplit.Text)

        txtEngOldCh.Text = Val(txtEngOld.Text) - Val(txtActualSplit.Text)
        txtEngNew.Text = Val(txtActualSplit.Text)

        txtSalesOldCh.Text = Val(txtSalesOld.Text)
        txtSalesNew.Text = Val(txtSalesOld.Text)

        'txtWeightOldCh.Text = Math.Round(Val(txtEngOldCh.Text) * Val(txtWeightPcs.Text))
        'txtWeightNew.Text = Math.Round(Val(txtEngNew.Text) * Val(txtWeightPcs.Text))

        txtWeightOldCh.Text = (CDec(txtEngOldCh.Text) * CDec(txtWeightPcs.Text)).ToString("N4")
        txtWeightNew.Text = (CDec(txtEngNew.Text) * CDec(txtWeightPcs.Text)).ToString("N4")

    End Sub

    Sub ValData()

        SwVal = False

        If Len(Trim(txtSufix.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Mpo Split Sufix is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Val(txtActualSplit.Text) = 0 Then
            MsgBox("!!! ERROR !!! Qty Actual to Split is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtOper.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Method Operation Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        txtOper.Text = CallClass.ReturnStrWith2ParStr("cspReturnMethodOperForVerify", CmbMpo.SelectedValue, Val(txtOper.Text))
        If Trim(txtOper.Text) = "False" Then
            txtDescr.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodOper", CmbMpo.SelectedValue, Val(txtOper.Text))
            txtSpec.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodSpec", CmbMpo.SelectedValue, Val(txtOper.Text))
            MsgBox("!!! ERROR !!! Method Operation Number is Missing.")
            SwVal = False
            Exit Sub
        Else
            txtDescr.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodOper", CmbMpo.SelectedValue, Val(txtOper.Text))
            txtSpec.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodSpec", CmbMpo.SelectedValue, Val(txtOper.Text))
        End If

        If Val(txtActualSplit.Text) > Val(txtActualOld.Text) Then
            MsgBox("!!! ERROR !!! Mpo Split Qty is greater than Mpo Qty Actual.")
            SwVal = False
            Exit Sub
        End If

        Dim II As Integer = 0

        Dim strText As String = ""

        For Each RMpo As DataGridViewRow In dgMpo.Rows
            strText = RMpo.Cells.Item("MpoNo").Value
            If InStr(strText, txtSufix.Text, vbTextCompare) <> 0 Then
                II = II + 1
            End If
        Next
        If II >= 1 Then
            MsgBox("!!! ERROR !!! Mpo Split Sufix.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub txtSufix_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSufix.Validating
        txtSufix.Text = UCase(txtSufix.Text)
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Try

            If CDec(txtWeightOld.Text) <> 0 Then
                If txtMpoType.Text <> "Assembly" Then
                    If IsDBNull(txtWeightOldCh.Text) = True Then
                        MsgBox("!!! ERROR !!! Parent Mpo. Weight is Null. Save action was cancelled.")
                        SwVal = False
                        Exit Sub
                    End If
                End If

                If txtMpoType.Text <> "Assembly" Then
                    If CDec(txtWeightOldCh.Text) = 0.0 Then
                        MsgBox("!!! ERROR !!! Parent Mpo. Weight is Empty. Save action was cancelled.")
                        SwVal = False
                        Exit Sub
                    End If
                End If

                If txtMpoType.Text <> "Assembly" Then
                    If CDec(txtWeightNew.Text) = 0.0 Then
                        MsgBox("!!! ERROR !!! Child Mpo. Weight is Empty. Save action was cancelled.")
                        SwVal = False
                        Exit Sub
                    End If
                End If
            End If

            dsMain.GetChanges()
            AddMpoSplit()
            ModifyOrigMpo()

            UpdateSplitTOText()

            SwMpoID = ""
            SwMpoID = CallClass.ReturnStrWithParString("cspReturnMPOID", txtMpoNew.Text)
            If SwMpoID = 0 Then
                MsgBox("!!! ERROR !!! NEW Mpo Split Number. Missing Status = Closed. Please try again.")
                Exit Sub
            Else
                UpdateSplitFrom()
                UpdateSplitFromText()
            End If

            MsgBox("Update successfully.")
            dsMain.AcceptChanges()

            SwOper = ""

            CmdSave.Visible = False

            If fBool = True Then
                dsMain.RejectChanges()
                dsMain.Dispose()
                Me.Dispose()
            End If

            ContinueCmbMpo()

        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

    End Sub

    Sub UpdateSplitTOText()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoSplitTOText", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = Val(txtOper.Text - 1)
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDescr As SqlParameter = New SqlParameter("@TrOperDescr", SqlDbType.NVarChar, 500)
        paraDescr.Value = "======================================" + vbCrLf + _
                          "Split " + txtActualSplit.Text + " pcs to MPO No.: " + txtMpoNew.Text + " on: " + Now.ToShortDateString + vbCrLf + _
                          "======================================"
        mySqlComm.Parameters.Add(paraDescr)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Insert Split Operation To: " & ex.Message)
        End Try

    End Sub

    Sub UpdateSplitFrom()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoSplitFrom", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@FindMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@FindOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = txtOper.Text
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraNewMpo As SqlParameter = New SqlParameter("@NewMPO", SqlDbType.Int, 4)
        paraNewMpo.Value = SwMpoID
        mySqlComm.Parameters.Add(paraNewMpo)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Retrive Method operations from the original MPO: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

        Sub UpdateSplitFromText

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoSplitFromText", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMpoID
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = Val(txtOper.Text - 1)
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDescr As SqlParameter = New SqlParameter("@TrOperDescr", SqlDbType.NVarChar, 500)
        paraDescr.Value = "======================================" + vbCrLf + _
                          "Split " + txtActualSplit.Text + " pcs from MPO No.: " + txtMpoOld.Text + " on: " + Now.ToShortDateString + vbCrLf + _
                          "======================================"
        mySqlComm.Parameters.Add(paraDescr)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Insert Split Operation From: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub AddMpoSplit()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoSplit", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoOld As SqlParameter = New SqlParameter("@FindMpo", SqlDbType.NVarChar, 25)
        paraMpoOld.Value = Trim(txtMpoOld.Text)
        mySqlComm.Parameters.Add(paraMpoOld)

        Dim paraMpoNew As SqlParameter = New SqlParameter("@MpoNo", SqlDbType.NVarChar, 25)
        paraMpoNew.Value = Trim(txtMpoNew.Text)
        mySqlComm.Parameters.Add(paraMpoNew)

        Dim paraSufix As SqlParameter = New SqlParameter("@MpoSufix", SqlDbType.NVarChar, 10)
        paraSufix.Value = Trim(txtSufix.Text)
        mySqlComm.Parameters.Add(paraSufix)

        Dim paraDate As SqlParameter = New SqlParameter("@MpoDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraDate)

        Dim paraStatus As SqlParameter = New SqlParameter("@MpoStatus", SqlDbType.NVarChar, 10)
        paraStatus.Value = "Active"
        mySqlComm.Parameters.Add(paraStatus)

        Dim paraQtyActual As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQtyActual.Value = Val(txtActualNew.Text)
        mySqlComm.Parameters.Add(paraQtyActual)

        Dim paraQtyEng As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
        paraQtyEng.Value = Val(txtEngNew.Text)
        mySqlComm.Parameters.Add(paraQtyEng)

        Dim paraSalesNew As SqlParameter = New SqlParameter("@QtyOrder", SqlDbType.Real, 4)
        paraSalesNew.Value = Val(txtSalesNew.Text)
        mySqlComm.Parameters.Add(paraSalesNew)

        Dim paraWeight As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
        paraWeight.Value = Val(txtWeightNew.Text)
        mySqlComm.Parameters.Add(paraWeight)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoNotesNew", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + "Mpo Split - See Mpo Number: " + Trim(txtMpoOld.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Insert New MPO Split: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

        '================================================

        Dim SwMpo As String = "MPO-" + Trim(txtMpoNew.Text)

        Dim path As String = ""
        Dim path_1 As String = ""

        path = "\\Srv115fs01\Lisi MPO Quality Records\" + SwMpo
        Dim di As DirectoryInfo = Directory.CreateDirectory(path)

        path_1 = path + "\1) Test Certs"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\2) Heat treatment Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\3) Forging Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\4) Thread rolling Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\5) Cold working Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\6) Surface finishing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\7) Final Inspections"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\8) Metallurgical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\9) Mechanical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\10) Others"
        di = Directory.CreateDirectory(path_1)

        '===================================================

    End Sub

    Sub ModifyOrigMpo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoOriginalSplit", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoOld As SqlParameter = New SqlParameter("@FindMpo", SqlDbType.NVarChar, 25)
        paraMpoOld.Value = Trim(txtMpoOld.Text)
        mySqlComm.Parameters.Add(paraMpoOld)

        Dim paraQtyActual As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQtyActual.Value = Val(txtActualOldCh.Text)
        mySqlComm.Parameters.Add(paraQtyActual)

        Dim paraQtyEng As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
        paraQtyEng.Value = Val(txtEngOldCh.Text)
        mySqlComm.Parameters.Add(paraQtyEng)

        Dim paraWeight As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
        paraWeight.Value = Val(txtWeightOldCh.Text)
        mySqlComm.Parameters.Add(paraWeight)

        Dim paraAdj As SqlParameter = New SqlParameter("@MpoMatlAdj", SqlDbType.Real, 4)
        paraAdj.Value = 0
        mySqlComm.Parameters.Add(paraAdj)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoNotes", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + "Mpo Split - See Mpo Split Number: " + Trim(txtMpoNew.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Invoice Info.: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Public Property fMpo() As Integer
        Get
            Return ParMpoID
        End Get

        Set(ByVal value As Integer)
            ParMpoID = value
        End Set
    End Property

    Public Property fQty() As Single
        Get
            Return ParQty
        End Get

        Set(ByVal value As Single)
            ParQty = value
        End Set
    End Property

    Public Property fBool() As Boolean
        Get
            Return ParBool
        End Get

        Set(ByVal value As Boolean)
            ParBool = value
        End Set
    End Property

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptMFGMethodBarCodeMpoSplit
        rptPO.Load("..\rptMFGMethodBarCodeMpoSplit.rpt")

        pdvMpoID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MPOID").Value)
        pdvPartID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("PartID").Value)
        pvMPOIDCollection.Add(pdvMpoID)
        pvPartIDCollection.Add(pdvPartID)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()

    End Sub
End Class