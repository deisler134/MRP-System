Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMatlLotStockNotes

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Private Sub frmMatlLotStockNotes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmMatlLotStockNotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        CmbMatlNo.SelectedIndex = -1

    End Sub

    Sub DisableFields()

        txtStockNotes.Text = ""
        txtStockNotes.ReadOnly = True
        ChkStk.Checked = False
        ChkOrders.Checked = False
        ChkStk.Enabled = False
        ChkOrders.Enabled = False

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

        ChkStk.DataBindings.Clear()
        ChkOrders.DataBindings.Clear()

        txtDateEntry.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtStPrice.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StPoPrice")
        txtRmSPrice.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StRmsPoPrice")
        txtDevise.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StDevise")
        txtMatlType.DataBindings.Add("Text", dsMain, "tblStockRawMatl.MatlType")
        txtHeatNo.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlHeat")
        txtMatlCond.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlCond")
        txtRecvWeight.DataBindings.Add("Text", dsMain, "tblStockRawMatl.RecvMatlWeight")
        txtStIni.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StIni")
        txtStInput.DataBindings.Add("Text", dsMain, "tblStockRawMatl.InQty")
        txtStOutput.DataBindings.Add("Text", dsMain, "tblStockRawMatl.OutQty")
        txtStFinal.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StFinal")
        txtMatlLoc.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StLock")

        txtStockNotes.DataBindings.Add("Text", dsMain, "tblStockRawMatl.StComments")
        ChkStk.DataBindings.Add(New Binding("CheckState", dsMain, "tblStockRawMatl.StSwForStock", True))
        ChkOrders.DataBindings.Add(New Binding("CheckState", dsMain, "tblStockRawMatl.StSwForOrders", True))
        'ChkOther.DataBindings.Add(New Binding("CheckState", dsMain, "tblSupplier.SwOther", True))

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
        ChkStk.Enabled = True
        ChkOrders.Enabled = True

        If ChkStk.CheckState = CheckState.Indeterminate Then
            ChkStk.Checked = False
        End If

        If ChkOrders.CheckState = CheckState.Indeterminate Then
            ChkOrders.Checked = False
        End If

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SwOper = ""

        dsMain.Clear()
        BindComponents()
        CmbMatlNo.SelectedIndex = -1
        CmbMatlNo.Enabled = True
        CmdSave.Enabled = False

        ChkStk.Checked = False
        ChkOrders.Checked = False

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Try
            dsMain.GetChanges()

            UpdateMatlLotComments()

            MsgBox("Update successfully.")
            dsMain.AcceptChanges()

            SwOper = ""

        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - REQ: " & ex.Message)
        End Try

        CmdSave.Enabled = False
        DisableFields()

    End Sub

    Sub UpdateMatlLotComments()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateStockRawMatlNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindLot", SqlDbType.NVarChar, 10)
        paraFind.Value = CmbMatlNo.Text
        mySqlComm.Parameters.Add(paraFind)

        Dim paraChkSt As SqlParameter = New SqlParameter("@StSwForStock", SqlDbType.Bit, 1)
        paraChkSt.Value = ChkStk.Checked
        mySqlComm.Parameters.Add(paraChkSt)

        Dim paraChkOrd As SqlParameter = New SqlParameter("@StSwForOrders", SqlDbType.Bit, 1)
        paraChkOrd.Value = ChkOrders.Checked
        mySqlComm.Parameters.Add(paraChkOrd)

        Dim paraNotes As SqlParameter = New SqlParameter("@StComments", SqlDbType.NVarChar, 2000)
        paraNotes.Value = Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Adj. Notes.: " & ex.Message)
        End Try

    End Sub

End Class