Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMatlPriceDepreciation

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Private Sub frmMatlPriceDepreciation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMatlPriceDepreciation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        txtStockNotes.Text = ""

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

        txtStockNotes.ReadOnly = False

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SwOper = ""

        dsMain.Clear()
        BindComponents()
        CmbMatlNo.SelectedIndex = -1
        CmbMatlNo.Enabled = True
        CmdSave.Enabled = False

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                dsMain.GetChanges()

                UpdatePriceAdj()

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

    Sub UpdatePriceAdj()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
        paraFind.Value = CmbMatlNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraData As SqlParameter = New SqlParameter("@MatlDateTranz", SqlDbType.SmallDateTime, 4)
        paraData.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraData)

        Dim paraTranz As SqlParameter = New SqlParameter("@MatlTranz", SqlDbType.NVarChar, 1)
        paraTranz.Value = 4             'Price Depreciation
        mySqlComm.Parameters.Add(paraTranz)

        Dim paraStatus As SqlParameter = New SqlParameter("@MatlStatus", SqlDbType.NVarChar, 1)
        paraStatus.Value = "O"
        mySqlComm.Parameters.Add(paraStatus)

        Dim paraLoc As SqlParameter = New SqlParameter("@MatlLoc", SqlDbType.NVarChar, 10)
        paraLoc.Value = txtMatlLoc.Text
        mySqlComm.Parameters.Add(paraLoc)

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = 0
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
        paraQty.Value = txtStFinal.Text
        mySqlComm.Parameters.Add(paraQty)

        Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
        paraPer.Value = Val(CmbPer.Text)
        mySqlComm.Parameters.Add(paraPer)

        If Len(Trim(txtStockNotes.Text)) <> 0 Then
            txtStockNotes.Text = txtStockNotes.Text + vbCrLf + "Material Lot Price Depreciation = " + CmbPer.Text + " %"
        Else
            txtStockNotes.Text = "Material Lot Price Depreciation = " + CmbPer.Text + " %"
        End If
        Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
        paraNotes.Value = Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Raw Material Tranz. Adj. Info.: " & ex.Message)
        End Try


    End Sub

    Sub ValPo()

        If Val(Nz.Nz(CmbPer.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Price Depreciation % = 0")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPer.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Price Depreciation % = 0")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

End Class