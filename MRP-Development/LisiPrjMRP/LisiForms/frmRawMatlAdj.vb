Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmRawMatlAdj

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowLot As Integer = 0
    Dim swMes As Boolean = False

    Dim OldRMWeight As String

    Private Sub frmRawMatlAdj_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub frmRawMatlAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        DisableCtl()

        PutCmbLot()

        Call SetupForm()

    End Sub

    Sub PutCmbLot()
        With CmbLot
            .DataSource = CallClass.PopulateComboBox("tblStockRawMatl", "cmbGetLotNoFromStock").Tables("tblStockRawMatl")
            .DisplayMember = "StLotNo"
            .ValueMember = "StLotNo"
        End With

    End Sub

    Sub DisableCtl()

        txtStock.ReadOnly = True
        txtStock.Text = ""

        txtReleased.ReadOnly = True
        txtReleased.Text = ""

        dgLot.Visible = False

    End Sub

    Sub SetupForm()

        txtStock.ReadOnly = True
        txtStock.Text = ""

        txtReleased.ReadOnly = True
        txtReleased.Text = ""

        SetCtlForm()

    End Sub

    Sub SetCtlForm()

        'dgMpo
        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.MpoMatlWeight
            .DataPropertyName = "MpoMatlWeight"
            .Name = "MpoMatlWeight"
        End With

        With Me.QtyAdj
            .DataPropertyName = "QtyAdj"
            .Name = "QtyAdj"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.StartQtyAdj
            .DataPropertyName = "StartQtyAdj"
            .Name = "StartQtyAdj"
        End With

        With Me.AdjNotes
            .DataPropertyName = "AdjNotes"
            .Name = "AdjNotes"
        End With

        With Me.RawWeight
            .DataPropertyName = "RawWeight"
            .Name = "RawWeight"
        End With

        With Me.WeightValidation
            .DataPropertyName = "WeightValidation"
            .Name = "WeightValidation"
        End With

        With Me.MpoPartID
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
            .Visible = False
        End With

    End Sub

    Sub CalculTotMpoMatl()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgLot.Rows
            qty = qty + Nz.Nz(Row.Cells("MpoMatlWeight").Value)
        Next
        txtReleased.Text = qty.ToString("N2")

    End Sub

    Private Sub CmbLot_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLot.DropDownClosed
        PutRefreshData()

        'CalculTotMpoMatl()

        swMes = False
    End Sub

    Private Sub CmbLot_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLot.GotFocus
        'txtStock.Text = CallClass.TakeFinalSt("cspTakeStockByLotNo", CmbLot.Text)

        'CalculTotMpoMatl()
    End Sub

    Private Sub CmbLot_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLot.SelectedIndexChanged

        'PutRefreshData()

        ''CalculTotMpoMatl()

        'swMes = False

    End Sub

    Sub PutRefreshData()

        dsMain.Clear()

        Dim strSearch As String
        strSearch = CmbLot.SelectedValue

        txtStock.Text = CallClass.TakeFinalSt("cspTakeStockByLotNo", strSearch)

        CallClass.PopulateDataAdapterAfterSearch("getMpoNoByLotNo", strSearch).Fill(dsMain, "tblMpoMaster")

        dgLot.AutoGenerateColumns = False
        dgLot.DataSource = dsMain
        dgLot.DataMember = "tblMpoMaster"

        CalculTotMpoMatl()

        dgLot.Visible = True

    End Sub

    Private Sub dgLot_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgLot.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        OldRMWeight = Nz.Nz(dgLot("RawWeight", e.RowIndex).Value)

        Select Case e.ColumnIndex
            Case 0, 1, 2, 3, 5, 8
                e.Cancel = True

            Case 4  'rm actual stock is zero
                If Val(txtStock.Text) = 0 Then
                    MsgBox("!!! ERROR !!! Action Denied. RM inventory, actual stock is zero.")
                    e.Cancel = True
                End If
            Case 6
                Dim RetVal As String
                Dim StrSearch As Integer

                StrSearch = dgLot.Rows(e.RowIndex).Cells("MPOID").Value
                RetVal = CallClass.ReturnStrWithParInt("cspReturnDeptCuttingValue", StrSearch)

                If Val(RetVal) = 0 Then
                    MsgBox("You can not edit the Actual Quantity Cut. The MPO is not in the allowed Department.")
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgLot_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLot.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowLot = e.RowIndex

        Select Case e.ColumnIndex
            Case 10
                If Val(txtStock.Text) + Nz.Nz(dgLot.Rows(e.RowIndex).Cells("QtyAdj").Value) < 0 Then
                    MsgBox("!!! ERROR !!! The Final RM stock is negative.")
                    Exit Sub
                End If

                If IsDBNull(dgLot.Rows(e.RowIndex).Cells("QtyAdj").Value) = False And _
                    dgLot.Rows(e.RowIndex).Cells("QtyAdj").Value <> 0 = True Then

                    UpdateAdj()
                    MsgBox("RM Adj.  Update successfully.")
                Else
                    MsgBox("!!! Nothing to Save !!! Raw Material Weight Adj. is Empty.")
                End If

                If IsDBNull(dgLot.Rows(e.RowIndex).Cells("StartQtyAdj").Value) = False And _
                dgLot.Rows(e.RowIndex).Cells("StartQtyAdj").Value > 0 = True Then

                    UpdateActualCut()
                    MsgBox("Start Quantity.  Update successfully.")
                Else
                    MsgBox("!!! Nothing to Save !!! Actual Quantity Cut Correction is Empty.")
                End If

                dsMain.AcceptChanges()
                PutRefreshData()
        End Select

    End Sub

    Sub UpdateActualCut()

        If IsDBNull(dgLot("StartQtyAdj", RowLot).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleasedAfterCutting", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgLot("MpoID", RowLot).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgLot("StartQtyAdj", RowLot).Value
            mySqlComm.Parameters.Add(paraQty)

            Dim paraNotes As SqlParameter = New SqlParameter("@MpoNotes", SqlDbType.NVarChar, 2000)
            paraNotes.Value = vbCrLf + "MPO Start Quantity after Cutting Department = " + Str(dgLot("StartQtyAdj", RowLot).Value)
            mySqlComm.Parameters.Add(paraNotes)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox("Update Mpo Qty Released -- Correction: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        End Try

    End Sub

    Sub PutWeightValidation()

        For Each Row As DataGridViewRow In dgLot.Rows
            If IsDBNull(Row.Cells("StartQtyAdj").Value) = False And _
                            Nz.Nz(Row.Cells("StartQtyAdj").Value) <> 0 = True Then
                Row.Cells("WeightValidation").Value = Nz.Nz(Row.Cells("StartQtyAdj").Value) * _
                                                    Nz.Nz(Row.Cells("RawWeight").Value)
            Else
                Row.Cells("WeightValidation").Value = Nz.Nz(Row.Cells("QtyEngReleased").Value) * _
                                                    Nz.Nz(Row.Cells("RawWeight").Value)
            End If

            Dim swWeight As Integer = 0
            swWeight = Nz.Nz(Row.Cells("MpoMatlWeight").Value) + Val(Nz.Nz(Row.Cells("QtyAdj").Value))

            If Row.Cells("WeightValidation").Value <= swWeight + (swWeight * 2 / 100) And _
                               Row.Cells("WeightValidation").Value >= swWeight - (swWeight * 2 / 100) Then
                Row.Cells("WeightValidation").Style.BackColor = Color.LemonChiffon
                'swMes = False
            Else
                Row.Cells("WeightValidation").Style.BackColor = Color.Red
                If swMes = False Then
                    MsgBox("Weight Quantity Cut is not in range +-2% with RM weight used.")
                    swMes = True
                End If
            End If
        Next

    End Sub

    Sub UpdateAdj()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
            paraFind.Value = dgLot("MpoLotNo", RowLot).Value
            mySqlComm.Parameters.Add(paraFind)

            Dim paraData As SqlParameter = New SqlParameter("@MatlDateTranz", SqlDbType.SmallDateTime, 4)
            paraData.Value = Now.ToShortDateString
            mySqlComm.Parameters.Add(paraData)

            Dim paraTranz As SqlParameter = New SqlParameter("@MatlTranz", SqlDbType.NVarChar, 1)
            paraTranz.Value = 3
            mySqlComm.Parameters.Add(paraTranz)

            Dim paraStatus As SqlParameter = New SqlParameter("@MatlStatus", SqlDbType.NVarChar, 1)
            paraStatus.Value = "O"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraLoc As SqlParameter = New SqlParameter("@MatlLoc", SqlDbType.NVarChar, 10)
            paraLoc.Value = ""
            mySqlComm.Parameters.Add(paraLoc)

            Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
            paraQty.Value = dgLot("QtyAdj", RowLot).Value
            mySqlComm.Parameters.Add(paraQty)

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgLot("MpoID", RowLot).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
            paraPer.Value = DBNull.Value
            mySqlComm.Parameters.Add(paraPer)

            Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
            paraNotes.Value = Nz.Nz(dgLot("AdjNotes", RowLot).Value)
            mySqlComm.Parameters.Add(paraNotes)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            cn.Open()
            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("Update Adj: " & ex.Message)
        Finally

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        End Try


        'update mpo qty adj
        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyAdj", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgLot("MpoID", RowLot).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@MpoMatlAdj", SqlDbType.Real, 4)
            paraQty.Value = dgLot("QtyAdj", RowLot).Value
            mySqlComm.Parameters.Add(paraQty)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            cn.Open()
            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("Update Mpo Qty Adj: " & ex.Message)
        Finally

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        End Try

        CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

    End Sub

    Private Sub dgLot_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLot.CellEndEdit

        Select Case e.ColumnIndex
            Case 4      ' qty adj
                Dim swAdj As Integer = 0

                swAdj = Nz.Nz(dgLot.Rows(e.RowIndex).Cells("QtyAdj").Value)
                If Val(txtStock.Text) + swAdj < 0 Then
                    MsgBox("!!! ERROR !!! RM final stock is negative. Action denied.")
                    dgLot.Rows(e.RowIndex).Cells("QtyAdj").Value = DBNull.Value
                End If

            Case 6
                If dgLot.Rows(e.RowIndex).Cells("StartQtyAdj").Value < 0 Then
                    MsgBox("!!! ERROR !!! Quantity Cut is negative")
                    dgLot.Rows(e.RowIndex).Cells("StartQtyAdj").Value = DBNull.Value
                End If
            Case 7 'qty sales requested

                Dim reply As DialogResult
                reply = MsgBox("Edit Raw Material Raw Weight?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateRMWeight()
                Else
                    dgLot("RawWeight", RowLot).Value = OldRMWeight
                End If
        End Select

    End Sub

    Sub UpdateRMWeight()

        If IsDBNull(dgLot("RawWeight", RowLot).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePartRawWeight", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPart As SqlParameter = New SqlParameter("@MpoPartID", SqlDbType.Int, 4)
        paraPart.Value = dgLot("MpoPartID", RowLot).Value
        mySqlComm.Parameters.Add(paraPart)

        Dim paraRMWeight As SqlParameter = New SqlParameter("@RawWeight", SqlDbType.Real, 4)
        paraRMWeight.Value = dgLot("RawWeight", RowLot).Value
        mySqlComm.Parameters.Add(paraRMWeight)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("Update Part Number Material Raw Weight: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub dgLot_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLot.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowLot = e.RowIndex

        OldRMWeight = Nz.Nz(dgLot("RawWeight", e.RowIndex).Value)

        PutWeightValidation()

    End Sub

    Private Sub dgLot_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgLot.DataError
        REM end
    End Sub

End Class