Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFPReleaseToMPO

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""
    Dim KeepNo As Integer = 0

    Private Sub frmFPReleaseToMPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmFPReleaseToMPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        Call SetupForm()

    End Sub

    Sub SetupForm()

        txtStAdj.Text = 0
        txtResult.Text = 0

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        PutMpoMaster()
        PutMpoProd()

        CmbMpoNo.SelectedIndex = -1
        cmbProdMPO.SelectedIndex = -1

    End Sub

    Sub DisableFields()

        txtDateEntry.ReadOnly = True
        txtPartNo.ReadOnly = True
        txtPartName.ReadOnly = True
        txtSalesPrice.ReadOnly = True
        txtDevise.ReadOnly = True
        txtMPOPartRev.ReadOnly = True
        txtStLoc.ReadOnly = True

        txtDept.ReadOnly = True
        txtQtyAct.ReadOnly = True

        txtStockNotes.ReadOnly = True

        txtStIni.ReadOnly = True
        txtStInput.ReadOnly = True
        txtStOutput.ReadOnly = True
        txtStFinal.ReadOnly = True

        txtStAdj.ReadOnly = True

        txtResult.ReadOnly = True

    End Sub

    Sub FirstTimeMenuButtons()

        CmbMpoNo.Enabled = True
        cmbProdMPO.Enabled = False

        CmdSave.Enabled = False
        cmdReset.Enabled = True

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutmpoMaster()
        With CmbMpoNo
            '.DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoNoFromFP").Tables("tblMpoMaster")
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoNoFromFPReleaseToProd").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Sub PutMpoProd()
        With cmbProdMPO
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterFromPlanning").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Sub BindComponents()

        txtDateEntry.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtPartName.DataBindings.Clear()
        txtSalesPrice.DataBindings.Clear()
        txtDevise.DataBindings.Clear()
        txtMPOPartRev.DataBindings.Clear()
        txtStockNotes.DataBindings.Clear()
        txtStLoc.DataBindings.Clear()

        txtStIni.DataBindings.Clear()
        txtStInput.DataBindings.Clear()
        txtStOutput.DataBindings.Clear()
        txtStFinal.DataBindings.Clear()
        txtDept.DataBindings.Clear()
        txtQtyAct.DataBindings.Clear()
        SwMPOType.DataBindings.Clear()

        txtDateEntry.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblStockFinishPart.PartNumber")
        txtPartName.DataBindings.Add("Text", dsMain, "tblStockFinishPart.PartName")
        txtSalesPrice.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StPrice", True, DataSourceUpdateMode.OnValidation, "", "C2")
        txtDevise.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StDevise")
        txtMPOPartRev.DataBindings.Add("Text", dsMain, "tblStockFinishPart.MpoPartRev")
        txtStockNotes.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StNotes")
        txtStIni.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StockIni")
        txtStInput.DataBindings.Add("Text", dsMain, "tblStockFinishPart.InMonth")
        txtStOutput.DataBindings.Add("Text", dsMain, "tblStockFinishPart.OutMonth")
        txtStFinal.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StFinal")

        txtStLoc.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StockLoc")

        txtDept.DataBindings.Add("Text", dsMain, "tblMpoMaster.DeptNode")
        txtQtyAct.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyActual")

        SwMPOType.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoType")

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SwOper = ""

        txtStAdj.Text = 0
        txtResult.Text = 0

        dsMain.Clear()
        'BindComponents()
        CmbMpoNo.SelectedIndex = -1
        cmbProdMPO.SelectedIndex = -1
        CmbMpoNo.Enabled = True
        CmdSave.Enabled = False

        CmbMpoNo.Focus()

    End Sub

    Private Sub txtStAdj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStAdj.Validating

        txtResult.Text = Val(txtStFinal.Text) + Val(txtStAdj.Text)

        If Val(Nz.Nz(txtResult.Text)) < 0 Then
            Me.ErrorProvider1.SetError(txtResult, "!!! ERROR !!! Stock Adj. < 0")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink

            CmdSave.Enabled = False
        Else
            Me.ErrorProvider1.Clear()
            CmdSave.Enabled = True
        End If

        txtStockNotes.Text = "Qty: " + Trim(txtStAdj.Text) + " Released From FP Mpo: " + CmbMpoNo.Text + _
                    " To Production Mpo: " + cmbProdMPO.Text + " "

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                dsMain.GetChanges()

                TakeDocumentNo()        'keep number

                UpdateAdj()             'also update keep number

                'update stock FP with tranz
                CallClass.UpdateMatlStock("cspUpdatetblStockFP")

                'update Mpo Qty Actual
                UpdateQtyActual()
                UpdateTechNotes()
                UpdateMpoReleaseToProd()     'also update keep number
                'UpdateMPOProdWithRMCost()     'also update keep number

                MsgBox("Update successfully.")
                dsMain.AcceptChanges()

                SwOper = ""

                Dim reply As DialogResult
                reply = MsgBox("DO YOU NOW WANT TO MOVE THE MPO TO THE NEXT DEPARTMENT? (Yes / No)", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
SelDept:
                    frmSelectDept.SwDeptSrc.Text = "MoveDept"
                    frmSelectDept.ShowDialog()

                    reply = MsgBox("The Department Selected " + vbCrLf + _
                                   "=================" + vbCrLf + "     " + _
                                    txtDept.Text + vbCrLf + _
                                   "=================" + vbCrLf + " is Correct? (Yes / No)", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        AddStartOper()
                        UpdateMpoDept()
                        UpdateRouteEndCase0()
                    Else
                        GoTo SelDept
                    End If
                End If

            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - REQ: " & ex.Message)
            End Try

            Try
                'Par1 = MPOFromFPID
                'Par2 = MPOProdID
                'Par3 = MPOType From FP (Blanks or Component)
                CallClass.ExecuteUpdate3Params("cspUpdateBlanksRMToReleasedMPO", CmbMpoNo.SelectedValue, cmbProdMPO.SelectedValue, SwMPOType.Text)
            Catch ex As Exception
            End Try

            CmdSave.Enabled = False
            DisableFields()

        End If

    End Sub

    Sub TakeDocumentNo()

        Dim SwNo As String = ""

        SwNo = CallClass.GenerateNextLot("cspGetNextLot", "RELFROMFPTOPROD")
        If SwNo = "ERROR" Then
            KeepNo = 0
        Else
            KeepNo = Val(SwNo)
            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "RELFROMFPTOPROD", KeepNo)
        End If

    End Sub
    Sub AddStartOper()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteAddOperStart", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = cmbProdMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = 0
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDeptID As SqlParameter = New SqlParameter("@SwDeptID", SqlDbType.Int, 4)
        paraDeptID.Value = SwDeptID.Text
        mySqlComm.Parameters.Add(paraDeptID)

        Dim paraEmpID As SqlParameter = New SqlParameter("@SwEmpID", SqlDbType.Int, 4)
        paraEmpID.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmpID)

        Dim paraDeptWhat As SqlParameter = New SqlParameter("@DeptWhat", SqlDbType.NVarChar, 20)
        paraDeptWhat.Value = SwDeptWhat.Text
        mySqlComm.Parameters.Add(paraDeptWhat)

      
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add Operation Start: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoDept()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = cmbProdMPO.SelectedValue
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = SwDeptID.Text
            mySqlComm.Parameters.Add(paraDept)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Update Mpo Dept.: " & ex.Message)
        Finally
            cn.Close()
        End Try

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub UpdateRouteEndCase0()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteEndCase0", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraEmpID As SqlParameter = New SqlParameter("@Wkempid", SqlDbType.Int, 4)
        paraEmpID.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmpID)

        Dim paraMPOID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMPOID.Value = cmbProdMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMPOID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = 0
        mySqlComm.Parameters.Add(paraOperNo)

       
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("cspUpdateRouteEndCase0: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateAdj()

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzCorrectionFromFPMpoProd", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMpoNo.SelectedValue
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
        paraQty.Value = Val(txtStAdj.Text)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraLoc As SqlParameter = New SqlParameter("@StLoc", SqlDbType.NVarChar, 20)
        paraLoc.Value = Trim(txtStLoc.Text)
        mySqlComm.Parameters.Add(paraLoc)

        Dim paraNotes As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Dim paraKeep As SqlParameter = New SqlParameter("@MPOKeepNo", SqlDbType.Int, 4)
        paraKeep.Value = KeepNo
        mySqlComm.Parameters.Add(paraKeep)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Info.: " & ex.Message)
        End Try

    End Sub

    Sub UpdateQtyActual()

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyActualFromFPAdj", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
        paraMpo.Value = cmbProdMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQty.Value = Val(txtStAdj.Text) * -1
        mySqlComm.Parameters.Add(paraQty)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Mpo Qty Actual: " & ex.Message)
        End Try

    End Sub

    Sub UpdateTechNotes()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoTechNotesFromFPAdj", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMpoNo.SelectedValue
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + "Qty: " + txtStAdj.Text + " Released To Production Mpo: " + cmbProdMPO.Text
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Tech Notes MPO: " & ex.Message)
        End Try

    End Sub

    Sub UpdateMpoReleaseToProd()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoRelToProd", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoFrom As SqlParameter = New SqlParameter("@MpoFromID", SqlDbType.Int, 4)
        paraMpoFrom.Value = CmbMpoNo.SelectedValue
        mySqlComm.Parameters.Add(paraMpoFrom)

        Dim paraMpoTo As SqlParameter = New SqlParameter("@MpoToID", SqlDbType.Int, 4)
        paraMpoTo.Value = cmbProdMPO.SelectedValue
        mySqlComm.Parameters.Add(paraMpoTo)

        Dim paraDate As SqlParameter = New SqlParameter("@MpoDateTr", SqlDbType.SmallDateTime, 4)
        paraDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraDate)

        Dim paraQty As SqlParameter = New SqlParameter("@MpoQtyTr", SqlDbType.Real, 4)
        paraQty.Value = Val(txtStAdj.Text) * -1
        mySqlComm.Parameters.Add(paraQty)

        Dim paraKeep As SqlParameter = New SqlParameter("@MPOKeepNo", SqlDbType.Int, 4)
        paraKeep.Value = KeepNo
        mySqlComm.Parameters.Add(paraKeep)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Qty Mpo Release to Prod: " & ex.Message)
        End Try

    End Sub

    'Sub UpdateMPOProdWithRMCost()
    '    Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoRelToProd", cn)
    '    mySqlComm.CommandType = CommandType.StoredProcedure

    '    Dim paraMpoFrom As SqlParameter = New SqlParameter("@MpoFromID", SqlDbType.Int, 4)
    '    paraMpoFrom.Value = CmbMpoNo.SelectedValue
    '    mySqlComm.Parameters.Add(paraMpoFrom)

    '    Dim paraMpoTo As SqlParameter = New SqlParameter("@MpoToID", SqlDbType.Int, 4)
    '    paraMpoTo.Value = cmbProdMPO.SelectedValue
    '    mySqlComm.Parameters.Add(paraMpoTo)

    '    Dim paraDate As SqlParameter = New SqlParameter("@MpoDateTr", SqlDbType.SmallDateTime, 4)
    '    paraDate.Value = Now.ToShortDateString
    '    mySqlComm.Parameters.Add(paraDate)

    '    Dim paraQty As SqlParameter = New SqlParameter("@MpoQtyTr", SqlDbType.Real, 4)
    '    paraQty.Value = Val(txtStAdj.Text) * -1
    '    mySqlComm.Parameters.Add(paraQty)

    '    Dim paraKeep As SqlParameter = New SqlParameter("@MPOKeepNo", SqlDbType.Int, 4)
    '    paraKeep.Value = KeepNo
    '    mySqlComm.Parameters.Add(paraKeep)

    '    Try
    '        cn.Open()
    '        mySqlComm.ExecuteNonQuery()
    '        cn.Close()
    '    Catch ex As SqlException
    '        MsgBox("Update Qty Mpo Release to Prod: " & ex.Message)
    '    End Try


    'End Sub

    Sub ValPo()

        If CmbMpoNo.SelectedValue <> 0 Then
        Else
            MsgBox("!!! ERROR !!! Missing FP MPO No.")
            SwVal = False
            Exit Sub
        End If

        If cmbProdMPO.SelectedValue <> 0 Then
        Else
            MsgBox("!!! ERROR !!! Missing Production MPO No.")
            SwVal = False
            Exit Sub
        End If

        If IsNothing(txtDept.Text) = True Then
            MsgBox("!!! ERROR !!! Missing Production MPO Department.")
            SwVal = False
            Exit Sub
        End If

        If Val(Nz.Nz(txtResult.Text)) < 0 Then
            MsgBox("!!! ERROR !!! Stock Adj. < 0")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub cmbProdMPO_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProdMPO.DropDownClosed

        Dim strSearch As Integer
        strSearch = cmbProdMPO.SelectedValue

        If strSearch <> 0 Then
            CallClass.PopulateAdapterAfterSearchInt("getTblMpoQtyActDept", strSearch).Fill(dsMain, "tblMpoMaster")

            BindComponents()

            If IsNothing(Convert.ToString(txtDept.Text)) = False And _
                IsNothing(Convert.ToString(txtQtyAct.Text)) = False Then
                CmdSave.Enabled = True
                cmbProdMPO.Enabled = False

                txtStAdj.ReadOnly = False
                txtStockNotes.ReadOnly = False
                txtStAdj.Focus()
            Else
                MsgBox("Please Select Again the Production MPO.")
                cmbProdMPO.SelectedIndex = -1
                cmbProdMPO.Focus()
                dsMain.Tables("tblMpoMaster").Clear()
            End If
        Else
            MsgBox("Please Select Again the Production MPO.")
            cmbProdMPO.SelectedIndex = -1
            cmbProdMPO.Focus()
        End If

    End Sub

    Private Sub CmbMpoNo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpoNo.DropDownClosed

        SwOper = "New"

        Dim strSearch As Integer
        strSearch = CmbMpoNo.SelectedValue

        If strSearch <> 0 Then
            dsMain.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getTblFinishPartAdjWithSearch", strSearch).Fill(dsMain, "tblStockFinishPart")

            If dsMain.Tables("tblStockFinishPart").Rows.Count = 0 Then
                MessageBox.Show("MPO not selected, try again.", "Warning")
                'BindComponents()

                SwOper = ""

                txtStAdj.Text = 0
                txtResult.Text = 0

                dsMain.Clear()
                'BindComponents()
                CmbMpoNo.SelectedIndex = -1
                cmbProdMPO.SelectedIndex = -1
                CmbMpoNo.Enabled = True
                CmdSave.Enabled = False

                CmbMpoNo.Focus()
            End If

        End If

        CmbMpoNo.Enabled = False

        cmdReset.Enabled = True

        txtStAdj.ReadOnly = True
        txtResult.Text = txtStFinal.Text
        txtStockNotes.ReadOnly = True

        CmdSave.Enabled = False
        cmbProdMPO.Enabled = True
        cmbProdMPO.Focus()

    End Sub

End Class