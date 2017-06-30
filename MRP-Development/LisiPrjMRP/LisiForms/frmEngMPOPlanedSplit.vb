Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmEngMPOPlanedSplit

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Private daMPO As New SqlDataAdapter
    Dim MPOCurrency As CurrencyManager

    Private Sub frmEngMPOPlanedSplit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        MPOCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daMPO.Dispose()
        Me.Dispose()

    End Sub

    Private Sub frmEngMPOPlanedSplit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Call SetupForm()

    End Sub

    Sub SetupForm()

        DisableFields()
        FirstTimeMenuButtons()

        BuildSqlCommand()
        InitialComponents()

        SetCtlForm()

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblMpoMaster"

        PutMpo()
        CmbMPO.Enabled = True
        CmbMPO.SelectedIndex = -1

    End Sub

    Sub PutMpo()

        With Me.CmbMPO
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMPOForSplit").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
        End With

    End Sub

    Sub DisableFields()

        CmbMPO.Enabled = False
        txtSplitNo.Enabled = False

    End Sub

    Sub FirstTimeMenuButtons()

        CmdReset.Enabled = True
        CmdSave.Enabled = False
        CmdExec.Enabled = False

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daMPO = CallClass.PopulateDataAdapter("getTblMpoMasterEmpty")
           
            Dim MPOBuilder As New SqlClient.SqlCommandBuilder(daMPO)

            daMPO.UpdateCommand = MPOBuilder.GetUpdateCommand
            daMPO.UpdateCommand.Connection = cn
            daMPO.InsertCommand = MPOBuilder.GetInsertCommand
            AddHandler daMPO.RowUpdated, AddressOf HandleRowUpdatedMPO
            daMPO.InsertCommand.Connection = cn
            daMPO.DeleteCommand = MPOBuilder.GetDeleteCommand
            daMPO.DeleteCommand.Connection = cn
            daMPO.AcceptChangesDuringFill = True
            daMPO.TableMappings.Add("Table", "tblMpoMaster")
            daMPO.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedMPO(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMpoMaster").Columns("MPOId")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daMPO.FillSchema(dsMain, SchemaType.Source, "tblMpoMaster")
        daMPO.Fill(dsMain, "tblMpoMaster")
        Dim MpID As DataColumn = dsMain.Tables("tblMpoMaster").Columns("MPOId")
        MpID.AutoIncrement = True
        MpID.AutoIncrementStep = -1
        MpID.AutoIncrementSeed = -1
        MpID.ReadOnly = False

        dsMain.EnforceConstraints = False

        MPOCurrency = CType(BindingContext(dsMain, "tblMpoMaster"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
            .ReadOnly = True
        End With

        With Me.MpoParent
            .DataPropertyName = "MpoParent"
            .Name = "MpoParent"
            .ReadOnly = True
        End With

        With Me.MpoChild
            .DataPropertyName = "MpoChild"
            .Name = "MpoChild"
            .ReadOnly = True
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
            .ReadOnly = True
        End With

        With Me.MpoPartID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
            .ReadOnly = True
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
            .ReadOnly = True
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
            .ReadOnly = True
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
            .ReadOnly = False
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
            .ReadOnly = False
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.OrderItemsID
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.OrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
            .Visible = False
        End With

        With Me.DeptID
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
            .Visible = False
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
            .Visible = False
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
            .Visible = False
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
            .Visible = False
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
            .Visible = False
        End With

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
            .Visible = False
        End With

        With Me.ChWFM
            .DataPropertyName = "ChWFM"
            .Name = "ChWFM"
            .Visible = False
        End With

        With Me.ChWFT
            .DataPropertyName = "ChWFT"
            .Name = "ChWFT"
            .Visible = False
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
            .Visible = False
        End With

        With Me.MpoMatlWeight
            .DataPropertyName = "MpoMatlWeight"
            .Name = "MpoMatlWeight"
            .Visible = False
        End With

        With Me.MpoPartType
            .DataPropertyName = "MpoPartType"
            .Name = "MpoPartType"
            .Visible = False
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
            .Visible = False
        End With

        With Me.MpoRMCostCDN
            .DataPropertyName = "MpoRMCostCDN"
            .Name = "MpoRMCostCDN"
            .Visible = False
        End With

        With Me.MPORMValueUsedCDN
            .DataPropertyName = "MPORMValueUsedCDN"
            .Name = "MPORMValueUsedCDN"
            .Visible = False
        End With

        With Me.MPOProcessingCost
            .DataPropertyName = "MPOProcessingCost"
            .Name = "MPOProcessingCost"
            .Visible = False
        End With

        With Me.TotalDaysINMFG
            .DataPropertyName = "TotalDaysINMFG"
            .Name = "TotalDaysINMFG"
            .Visible = False
        End With

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
            .Visible = False
        End With

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click
        
        ResetForm()

    End Sub

    Sub ResetForm()
        MPOCurrency.EndCurrentEdit()

        dsMain.RejectChanges()
        DisableFields()
        FirstTimeMenuButtons()

        CmbMPO.Enabled = True
        CmbMPO.SelectedIndex = -1
        txtSplitNo.Text = ""

        dsMain.Clear()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        CmbMPO.Focus()
        txtSplitNo.Focus()
        dgMPO.Focus()
        CmdReset.Focus()
        CmbMPO.Focus()

        MPOCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daMPO.Update(dsMain.Tables("tblMpoMaster").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                Try
                    For Each RMpo As DataGridViewRow In dgMPO.Rows

                        Dim SwMpo As String = "MPO-" + RMpo.Cells.Item("MpoNo").Value

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
                        'path_1 = path + "\3) Forging Records\a) Technique sheet"
                        'di = Directory.CreateDirectory(path_1)
                        'path_1 = path + "\3) Forging Records\b) First off"
                        'di = Directory.CreateDirectory(path_1)

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

                    Next
                Catch ex As Exception

                End Try


                dsMain.AcceptChanges()

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! ATTENTION !!!"
                strBody = "The MPO Number: " + CmbMPO.Text + " was splited in LAC-MRP." + vbCrLf
                strBody = strBody + "Please check the customer delivery date for each MPO split. "
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
                client.Send(email)
            End If

        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

        PutMpo()
        ResetForm()

    End Sub

    Private Sub CmbMPO_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMPO.DropDownClosed

        Dim strSearch As String

        dsMain.Clear()

        strSearch = CmbMPO.SelectedValue
        CallClass.PopulateDataAdapterAfterSearch("getTblMpoMasterByMPOId", strSearch).Fill(dsMain, "tblMpoMaster")

        If dsMain.Tables("tblMpoMaster").Rows.Count = 0 Then
            MessageBox.Show("MPO number missing, try again.", "Warning")
            ResetForm()
        Else
            dgMPO.AutoGenerateColumns = False
            dgMPO.DataSource = dsMain
            dgMPO.DataMember = "tblMpoMaster"

            txtSplitNo.Enabled = True

        End If

    End Sub

    Private Sub CmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExec.Click

        txtSplitNo.Enabled = False

        If Val(txtSplitNo.Text) > 1 And Val(txtSplitNo.Text) <= 6 Then
            CreateSplit()
            CmdSave.Enabled = True
        Else
            MessageBox.Show("!!! ERROR !!! Number of MPO Splits.")

            txtSplitNo.Text = ""
            txtSplitNo.Focus()
        End If

        CmdExec.Enabled = False

    End Sub

    Sub CreateSplit()

        dgMPO.Item("MPONo", 0).Value = dgMPO.Item("MPONo", 0).Value + "A"
        dgMPO.Item("MpoChild", 0).Value = "A"

        Try
            Dim tb As DataTable
            Dim rw As DataRow
            tb = dsMain.Tables("tblMpoMaster")

            Dim EngQty As Integer = 0
            Dim SalesQty As Integer = 0
            EngQty = dgMPO.Item("QtyEngReleased", 0).Value
            SalesQty = dgMPO.Item("QtyOrder", 0).Value

            dgMPO.Item("QtyEngReleased", 0).Value = CInt(EngQty / Val(txtSplitNo.Text))
            dgMPO.Item("QtyOrder", 0).Value = CInt(SalesQty / Val(txtSplitNo.Text))

            For I As Integer = 2 To Val(txtSplitNo.Text)
                rw = tb.NewRow

                Select Case I
                    Case 2
                        rw("MpoNo") = dgMPO.Item("MpoParent", 0).Value + "B"
                        rw("MpoChild") = "B"
                    Case 3
                        rw("MpoNo") = dgMPO.Item("MpoParent", 0).Value + "C"
                        rw("MpoChild") = "C"
                    Case 4
                        rw("MpoNo") = dgMPO.Item("MpoParent", 0).Value + "D"
                        rw("MpoChild") = "D"
                    Case 5
                        rw("MpoNo") = dgMPO.Item("MpoParent", 0).Value + "E"
                        rw("MpoChild") = "E"
                    Case 6
                        rw("MpoNo") = dgMPO.Item("MpoParent", 0).Value + "F"
                        rw("MpoChild") = "F"
                End Select

                rw("MpoParent") = dgMPO.Item("MpoParent", 0).Value
                rw("MpoPartID") = dgMPO.Item("MpoPartID", 0).Value
                rw("MpoPartRev") = dgMPO.Item("MpoPartRev", 0).Value
                rw("QtyActual") = dgMPO.Item("QtyActual", 0).Value
                rw("QtyEngReleased") = CInt(EngQty / Val(txtSplitNo.Text))
                rw("QtyOrder") = CInt(SalesQty / Val(txtSplitNo.Text))
                rw("MpoId") = dgMPO.Item("MpoId", 0).Value
                rw("OrderItemsID") = dgMPO.Item("OrderItemsID", 0).Value
                rw("OrdDelivID") = dgMPO.Item("OrdDelivID", 0).Value
                rw("MpoDate") = dgMPO.Item("MpoDate", 0).Value
                rw("DeptID") = dgMPO.Item("DeptID", 0).Value
                rw("StartProdDate") = dgMPO.Item("StartProdDate", 0).Value
                rw("EndProdDate") = dgMPO.Item("EndProdDate", 0).Value
                rw("MpoNotes") = dgMPO.Item("MpoNotes", 0).Value
                rw("MpoTechNotes") = dgMPO.Item("MpoTechNotes", 0).Value
                rw("ChNewOrder") = dgMPO.Item("ChNewOrder", 0).Value
                rw("ChWFM") = dgMPO.Item("ChWFM", 0).Value
                rw("ChWFT") = dgMPO.Item("ChWFT", 0).Value
                rw("MpoStatus") = dgMPO.Item("MpoStatus", 0).Value
                rw("MpoType") = dgMPO.Item("MpoType", 0).Value
                rw("MpoMatlWeight") = dgMPO.Item("MpoMatlWeight", 0).Value
                rw("MpoPartType") = dgMPO.Item("MpoPartType", 0).Value
                rw("MpoLotNo") = dgMPO.Item("MpoLotNo", 0).Value
                rw("MpoRMCostCDN") = dgMPO.Item("MpoRMCostCDN", 0).Value
                rw("MPORMValueUsedCDN") = dgMPO.Item("MPORMValueUsedCDN", 0).Value
                rw("MPOProcessingCost") = dgMPO.Item("MPOProcessingCost", 0).Value
                rw("TotalDaysINMFG") = dgMPO.Item("TotalDaysINMFG", 0).Value
                rw("MpoPriority") = "99"

                tb.Rows.Add(rw)
            Next

        Catch ex As Exception
        End Try

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblMpoMaster"

    End Sub

    Private Sub txtSplitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSplitNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtSplitNo.Text) > 1 And Val(txtSplitNo.Text) <= 6 Then
                CmdExec.Enabled = True
                CmdExec.Focus()
            Else
                MessageBox.Show("!!! ERROR !!! Number of MPO Splits.")
                txtSplitNo.Text = ""
                txtSplitNo.Focus()
            End If
        End If

    End Sub

    Private Sub dgMPO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMPO.CellClick

        dgMPO("QtyEngReleased", e.RowIndex).ReadOnly = False
        dgMPO("QtyOrder", e.RowIndex).ReadOnly = False

    End Sub

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub

End Class