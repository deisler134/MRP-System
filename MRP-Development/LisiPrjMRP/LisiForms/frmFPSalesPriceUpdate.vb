Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFPSalesPriceUpdate

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""

    Private Sub frmFPSalesPriceUpdate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmFPSalesPriceUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        Call SetupForm()

    End Sub

    Sub SetupForm()

        txtNewPr.Text = 0

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        PutMpoMaster()

        CmbMpoNo.SelectedIndex = -1

    End Sub

    Sub DisableFields()

        txtDateEntry.ReadOnly = True
        txtPartNo.ReadOnly = True
        txtPartName.ReadOnly = True
        txtSalesPrice.ReadOnly = True
        txtOldPrice.ReadOnly = True
        txtDevise.ReadOnly = True
        txtMPOPartRev.ReadOnly = True

        txtQtyActual.ReadOnly = True
        txtQtyEng.ReadOnly = True
        txtQtyScrapped.ReadOnly = True
        txtStockNotes.ReadOnly = True

        txtStIni.ReadOnly = True
        txtStInput.ReadOnly = True
        txtStOutput.ReadOnly = True
        txtStFinal.ReadOnly = True

        txtNewPr.ReadOnly = True
        txtStLoc.ReadOnly = True

    End Sub

    Sub FirstTimeMenuButtons()

        CmbMpoNo.Enabled = True

        CmdSave.Enabled = False

        CmdReset.Enabled = True
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutmpoMaster()
        With CmbMpoNo
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoNoFromFP").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOId"
        End With

    End Sub

    Sub BindComponents()

        txtDateEntry.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtPartName.DataBindings.Clear()
        txtSalesPrice.DataBindings.Clear()
        txtOldPrice.DataBindings.Clear()
        txtDevise.DataBindings.Clear()
        txtMPOPartRev.DataBindings.Clear()
        txtStockNotes.DataBindings.Clear()
        txtStLoc.DataBindings.Clear()

        txtQtyActual.DataBindings.Clear()
        txtQtyEng.DataBindings.Clear()
        txtQtyScrapped.DataBindings.Clear()

        txtStIni.DataBindings.Clear()
        txtStInput.DataBindings.Clear()
        txtStOutput.DataBindings.Clear()
        txtStFinal.DataBindings.Clear()

        txtDateEntry.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblStockFinishPart.PartNumber")
        txtPartName.DataBindings.Add("Text", dsMain, "tblStockFinishPart.PartName")
        txtSalesPrice.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StPrice", True, DataSourceUpdateMode.OnValidation, "", "C2")
        txtOldPrice.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StOldPrice", True, DataSourceUpdateMode.OnValidation, "", "C2")
        txtDevise.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StDevise")
        txtMPOPartRev.DataBindings.Add("Text", dsMain, "tblStockFinishPart.MpoPartRev")
        txtStockNotes.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StNotes")
        txtQtyActual.DataBindings.Add("Text", dsMain, "tblStockFinishPart.QtyActual")
        txtQtyEng.DataBindings.Add("Text", dsMain, "tblStockFinishPart.QtyEngReleased")
        txtQtyScrapped.DataBindings.Add("Text", dsMain, "tblStockFinishPart.QtyScrapped")
        txtStIni.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StockIni")
        txtStInput.DataBindings.Add("Text", dsMain, "tblStockFinishPart.InMonth")
        txtStOutput.DataBindings.Add("Text", dsMain, "tblStockFinishPart.OutMonth")
        txtStFinal.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StFinal")
        txtStLoc.DataBindings.Add("Text", dsMain, "tblStockFinishPart.StockLoc")

    End Sub

    Private Sub CmbMpoNo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpoNo.DropDownClosed

        SwOper = "New"

        Dim strSearch As Integer
        strSearch = CmbMpoNo.SelectedValue

        If strSearch <> 0 Then
            dsMain.Clear()

            CallClass.PopulateAdapterAfterSearchInt("getTblFinishPartAdjWithSearch", strSearch).Fill(dsMain, "tblStockFinishPart")

            If dsMain.Tables("tblStockFinishPart").Rows.Count > 0 Then
                BindComponents()

                CmdSave.Enabled = True
            Else
                Return
            End If
        End If

        CmbMpoNo.Enabled = False

        cmdReset.Enabled = True

        txtNewPr.ReadOnly = False

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SwOper = ""

        txtNewPr.Text = 0
        txtStLoc.Text = ""
        txtStockNotes.Text = ""

        dsMain.Clear()
        BindComponents()
        CmbMpoNo.SelectedIndex = -1
        CmbMpoNo.Enabled = True
        CmdSave.Enabled = False

        CmbMpoNo.Focus()

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            Try
                dsMain.GetChanges()

                UpdateAdjPrice()

                'update stock FP with tranz
                CallClass.UpdateMatlStock("cspUpdatetblStockFP")

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

    Sub UpdateAdjPrice()

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateFPAdjPrice", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = CmbMpoNo.SelectedValue
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 4
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
        paraQty.Value = Val(txtStFinal.Text)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraPrice As SqlParameter = New SqlParameter("@PriceTranz", SqlDbType.Money, 8)
        paraPrice.Value = Val(txtNewPr.Text)
        mySqlComm.Parameters.Add(paraPrice)

        Dim paraOldPrice As SqlParameter = New SqlParameter("@OldPriceTranz", SqlDbType.Money, 8)
        If Len(Trim(txtOldPrice.Text)) = 0 Then
            paraOldPrice.Value = txtSalesPrice.Text
        Else
            paraOldPrice.Value = txtOldPrice.Text
        End If
        mySqlComm.Parameters.Add(paraOldPrice)

        Dim paraNotes As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 2000)
        paraNotes.Value = Trim(txtStockNotes.Text)
        mySqlComm.Parameters.Add(paraNotes)

        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Price: " & ex.Message)
        End Try

    End Sub

    Sub ValPo()

        If Val(Nz.Nz(txtNewPr.Text)) <= 0 And _
        Len(Trim(txtNewPr.Text)) > 0 Then
            MsgBox("!!! ERROR !!! Price Adj. <= 0")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtStockNotes.Text)) = 0 Then
            MsgBox("Please provide the reason of the Adj.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub txtNewPr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNewPr.Validating

        If Val(Nz.Nz(txtNewPr.Text)) < 0 Then
            Me.ErrorProvider1.SetError(txtNewPr, "!!! ERROR !!! Price Adj. < 0")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink

            CmdSave.Enabled = False
        Else
            Me.ErrorProvider1.Clear()
            CmdSave.Enabled = True

            txtStockNotes.Text = "On: " + Now.ToShortDateString + " The Inventory Price: " + Trim(txtSalesPrice.Text) + " was adjusted with: " + txtNewPr.Text + " by: " + wkName

        End If

    End Sub

End Class