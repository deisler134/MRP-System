Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMatlLotAdj

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Private Sub frmMatlLotAdj_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMatlLotAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        Call SetupForm()

    End Sub

    Sub SetupForm()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        PutMatlLot()
        PutStockLoc()

        CmbMatlNo.SelectedIndex = -1

    End Sub

    Sub DisableFields()

        txtStAdj.Text = 0
        txtResult.Text = 0
        txtStockNotes.Text = ""

        txtStAdj.ReadOnly = True
        txtResult.ReadOnly = True
        txtStockNotes.ReadOnly = True

    End Sub

    Sub FirstTimeMenuButtons()

        CmbMatlNo.Enabled = True

        CmdSave.Enabled = False

        CmdReset.Enabled = True
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutMatlLot()
        With CmbMatlNo
            .DataSource = CallClass.PopulateComboBox("tblStockRawMatl", "cmbGetLotIDFromStock").Tables("tblStockRawMatl")
            .DisplayMember = "StLotNo"
            .ValueMember = "StRawMatlID"
        End With

    End Sub

    Sub PutStockLoc()

        With txtMatlLoc
            .DataSource = CallClass.PopulateComboBox("tblStockLoc", "cmbGetStockLoc").Tables("tblStockLoc")
            .DisplayMember = "StLocID"
            .ValueMember = "StLocID"
        End With

    End Sub

    Sub BindComponents()

        txtDateEntry.DataBindings.Clear()
        txtStPrice.DataBindings.Clear()
        txtRmSPrice.DataBindings.Clear()
        txtDevise.DataBindings.Clear()
        txtDevise.DataBindings.Clear()
        txtStockNotes.DataBindings.Clear()
        txtMatlType.DataBindings.Clear()
        txtHeatNo.DataBindings.Clear()
        txtMatlCond.DataBindings.Clear()
        txtRecvWeight.DataBindings.Clear()
        txtMatlLoc.DataBindings.Clear()

        txtStIni.DataBindings.Clear()
        txtStInput.DataBindings.Clear()
        txtStOutput.DataBindings.Clear()
        txtStFinal.DataBindings.Clear()

        txtDateEntry.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtStPrice.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StPoPrice")
        txtRmSPrice.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StRmsPoPrice")
        txtDevise.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StDevise")
        txtStockNotes.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StComments")
        txtMatlType.DataBindings.Add("Text", dsMain, "tblStockRawMatl.MatlType")
        txtHeatNo.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlHeat")
        txtMatlCond.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlCond")
        txtRecvWeight.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlWeight")
        txtMatlLoc.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StLock")

        txtStIni.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StIni")
        txtStInput.DataBindings.Add("Text", dsMain, "tblStockRawMatl.InQty")
        txtStOutput.DataBindings.Add("Text", dsMain, "tblStockRawMatl.OutQty")
        txtStFinal.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StFinal")

    End Sub

    Private Sub CmbMatlNo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMatlNo.DropDownClosed

        SwOper = "New"

        Dim strSearch As Integer
        strSearch = CmbMatlNo.SelectedValue

        If strSearch <> 0 Then
            dsMain.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getTblRawMatlAdjWithSearch", strSearch).Fill(dsMain, "tblStockRawMatl")

            BindComponents()

            CmdSave.Enabled = True

        End If

        CmbMatlNo.Enabled = False

        cmdReset.Enabled = True

        txtStAdj.ReadOnly = False

        txtResult.Text = txtStFinal.Text
        txtStockNotes.ReadOnly = False

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SwOper = ""

        txtStAdj.Text = 0
        txtResult.Text = 0

        dsMain.Clear()
        BindComponents()
        CmbMatlNo.SelectedIndex = -1
        CmbMatlNo.Enabled = True
        CmdSave.Enabled = False

    End Sub

    Private Sub txtStAdj_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStAdj.Validating

        txtResult.Text = Val(txtStFinal.Text) + Val(txtStAdj.Text)

        If wkAccess = 0 Then

        Else
            If Val(Nz.Nz(txtResult.Text)) < 0 Then
                Me.ErrorProvider1.SetError(txtResult, "!!! ERROR !!! Stock Adj. < 0")
                Me.ErrorProvider1.BlinkRate = 200
                Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink

                CmdSave.Enabled = False
            End If

            If Val(Nz.Nz(txtStFinal.Text)) <= 0 Then
                Me.ErrorProvider1.SetError(txtStFinal, "!!! ERROR !!! You can not adjustment the material stock if the final stock is zero. Please contact SQL administrator person.")
                Me.ErrorProvider1.BlinkRate = 200
                Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
                txtStAdj.Text = 0
                txtResult.Text = 0
                CmdSave.Enabled = False
            End If
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                dsMain.GetChanges()

                UpdateMatlLotAdj()

                CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

                MsgBox("Update successfully.")
                dsMain.AcceptChanges()

                SwOper = ""

            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - REQ: " & ex.Message)
            End Try

            CmdSave.Enabled = False
            DisableFields()

        End If

    End Sub

    Sub UpdateMatlLotAdj()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
        paraFind.Value = CmbMatlNo.Text
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
        paraLoc.Value = txtMatlLoc.Text
        mySqlComm.Parameters.Add(paraLoc)

        Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
        paraQty.Value = Val(txtStAdj.Text)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = 0
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
        paraPer.Value = DBNull.Value
        mySqlComm.Parameters.Add(paraPer)

        If Len(Trim(txtStockNotes.Text)) <> 0 Then
            txtStockNotes.Text = vbCrLf + Trim(txtStockNotes.Text)
        Else
            txtStockNotes.Text = "Matl Lot Adj. QTy = " + txtStAdj.Text
        End If
        Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
        paraNotes.Value = Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Info.: " & ex.Message)
        End Try


    End Sub

    Sub UpdateQtyActual()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
            paraFind.Value = CmbMatlNo.Text
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
            paraQty.Value = Val(txtStAdj.Text)
            mySqlComm.Parameters.Add(paraQty)

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = 0
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
            paraPer.Value = DBNull.Value
            mySqlComm.Parameters.Add(paraPer)

            Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
            paraNotes.Value = vbCrLf + Trim(txtStockNotes.Text)
            mySqlComm.Parameters.Add(paraNotes)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Adj: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Adj: " & ex.Message)
        End Try

    End Sub

    Sub ValPo()

        'If Val(Nz.Nz(txtResult.Text)) < 0 Then
        '    MsgBox("!!! ERROR !!! Stock Adj. < 0")
        '    SwVal = False
        '    Exit Sub
        'End If

        'If Val(Nz.Nz(txtStAdj.Text)) = 0 Then
        '    MsgBox("!!! ERROR !!! Qty Adj. = 0")
        '    SwVal = False
        '    Exit Sub
        'End If

        SwVal = True

    End Sub

    Private Sub CmdLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdLoc.Click
        frmRMStockLocation.ShowDialog()
        frmRMStockLocation.Dispose()

    End Sub

    Private Sub txtMatlLoc_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatlLoc.DropDown
        PutStockLoc()
    End Sub
End Class