Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmMaintEquipmentsModule

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daInfo As New SqlDataAdapter
    Private daTasks As New SqlDataAdapter
    Private daOrders As New SqlDataAdapter
    Private daOrdersDetails As New SqlDataAdapter

    Dim InfoCurrency As CurrencyManager
    Dim TasksCurrency As CurrencyManager
    Dim OrdersCurrency As CurrencyManager
    Dim OrdersDetailsCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim RowInfo As Integer = 0       'dgInfo row.
    Dim RowTasks As Integer = 0      'dgTasks row.
    Dim RowOrders As Integer = 0     'dgOrders row.
    Dim RowOrdersDetails As Integer = 0     'dgOrdersDetails row.

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmMaintEquipmentsModule_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        InfoCurrency.EndCurrentEdit()
        TasksCurrency.EndCurrentEdit()
        OrdersCurrency.EndCurrentEdit()
        OrdersDetailsCurrency.EndCurrentEdit()
       
        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()

        daInfo.Dispose()
        daTasks.Dispose()
        daOrders.Dispose()
        daOrdersDetails.Dispose()
       
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmMaintEquipmentsModule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1730 And Height > 905 Then
            Me.Width = 1730
            Me.Height = 905
        Else
            If Width < 1730 And Height < 905 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        DisableFields()

        FirstTimeMenuButtons()

        ClearFields()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        PutEquip()

        PutHeaderInfo()

        CmbEquip.SelectedIndex = -1

        PutDataGrid()

        PutDescrTasks()

        dsMain.Tables("tblMaintEquipDetails").Clear()

    End Sub

    Sub PutDataGrid()

        dgInfo.AutoGenerateColumns = False
        dgInfo.DataSource = dsMain
        dgInfo.DataMember = "tblMaintEquipDetails"

        dgTasks.AutoGenerateColumns = False
        dgTasks.DataSource = dsMain
        dgTasks.DataMember = "tblMaintEquipDetails.DetailTask"

        dgOrders.AutoGenerateColumns = False
        dgOrders.DataSource = dsMain
        dgOrders.DataMember = "tblMaintEquipDetails.DetailTask.DetailOrder"

        dgOrdersDetails.AutoGenerateColumns = False
        dgOrdersDetails.DataSource = dsMain
        dgOrdersDetails.DataMember = "tblMaintEquipDetails.DetailTask.DetailOrder.DetailOrderDetails"

        If RoleMaint(wkDeptCode) = True Then
            dgInfo.ReadOnly = True
            dgTasks.ReadOnly = True
        End If

    End Sub

    Sub DisableFields()

        dgInfo.ReadOnly = True
        dgTasks.ReadOnly = True
        dgOrders.ReadOnly = True
        dgOrdersDetails.ReadOnly = True

        CmbEquip.Enabled = True

    End Sub

    Sub FirstTimeMenuButtons()

        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdNew.Enabled = False

        If RoleMaint(wkDeptCode) = True Then
            CmdMach.Enabled = False
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblMaintEquipments").Fill(dsMain, "tblMaintEquipments")

        daInfo.FillSchema(dsMain, SchemaType.Source, "tblMaintEquipDetails")
        daTasks.FillSchema(dsMain, SchemaType.Source, "tblMaintEquipTasks")
        daOrders.FillSchema(dsMain, SchemaType.Source, "tblMaintEquipOrders")
        daOrdersDetails.FillSchema(dsMain, SchemaType.Source, "tblMaintEquipOrdersDetails")

        daInfo.Fill(dsMain, "tblMaintEquipDetails")
        Dim MaID As DataColumn = dsMain.Tables("tblMaintEquipDetails").Columns("MachDetailsID")
        MaID.AutoIncrement = True
        MaID.AutoIncrementStep = -1
        MaID.AutoIncrementSeed = -1
        MaID.ReadOnly = False

        daTasks.Fill(dsMain, "tblMaintEquipTasks")
        Dim TaID As DataColumn = dsMain.Tables("tblMaintEquipTasks").Columns("TaskID")
        TaID.AutoIncrement = True
        TaID.AutoIncrementStep = -1
        TaID.AutoIncrementSeed = -1
        TaID.ReadOnly = False

        daOrders.Fill(dsMain, "tblMaintEquipOrders")
        Dim WoID As DataColumn = dsMain.Tables("tblMaintEquipOrders").Columns("WorkID")
        WoID.AutoIncrement = True
        WoID.AutoIncrementStep = -1
        WoID.AutoIncrementSeed = -1
        WoID.ReadOnly = False

        daOrdersDetails.Fill(dsMain, "tblMaintEquipOrdersDetails")
        Dim DetID As DataColumn = dsMain.Tables("tblMaintEquipOrdersDetails").Columns("WorkDetailID")
        DetID.AutoIncrement = True
        DetID.AutoIncrementStep = -1
        DetID.AutoIncrementSeed = -1
        DetID.ReadOnly = False

        dsMain.EnforceConstraints = False


        With dsMain
            .Relations.Add("EquipDetail", _
                .Tables("tblMaintEquipments").Columns("EquipID"), _
                .Tables("tblMaintEquipDetails").Columns("EquipID"), True)
        End With

        With dsMain
            .Relations.Add("DetailTask", _
                .Tables("tblMaintEquipDetails").Columns("MachDetailsID"), _
                .Tables("tblMaintEquipTasks").Columns("MachDetailsID"), True)
        End With

        With dsMain
            .Relations.Add("DetailOrder", _
                .Tables("tblMaintEquipTasks").Columns("TaskID"), _
                .Tables("tblMaintEquipOrders").Columns("TaskID"), True)
        End With

        With dsMain
            .Relations.Add("DetailOrderDetails", _
                .Tables("tblMaintEquipOrders").Columns("WorkID"), _
                .Tables("tblMaintEquipOrdersDetails").Columns("WorkID"), True)
        End With

        InfoCurrency = CType(BindingContext(dsMain, "tblMaintEquipDetails"), CurrencyManager)
        TasksCurrency = CType(BindingContext(dsMain, "tblMaintEquipTasks"), CurrencyManager)
        OrdersCurrency = CType(BindingContext(dsMain, "tblMaintEquipOrders"), CurrencyManager)
        OrdersDetailsCurrency = CType(BindingContext(dsMain, "tblMaintEquipOrdersDetails"), CurrencyManager)

    End Sub

    Sub PutEquip()

        With Me.CmbEquip
            .DataSource = CallClass.PopulateComboBox("tblMaintEquipments", "cmbGetMaintEquipmentActive").Tables("tblMaintEquipments")
            .DisplayMember = "FullDescr"
            .ValueMember = "EquipID"
        End With

    End Sub

    Sub SetCtlForm()

        'dginfo
        With Me.MachSerialNo
            .DataPropertyName = "MachSerialNo"
            .Name = "MachSerialNo"
        End With

        With Me.MachNotes
            .DataPropertyName = "MachNotes"
            .Name = "MachNotes"
        End With

        With Me.MachDateIn
            .DataPropertyName = "MachDateIn"
            .Name = "MachDateIn"
        End With

        With Me.MachWarantyTill
            .DataPropertyName = "MachWarantyTill"
            .Name = "MachWarantyTill"
        End With

        With Me.MachStatus
            .DataPropertyName = "MachStatus"
            .Name = "MachStatus"
        End With

        With Me.MachCountryOrig
            .DataPropertyName = "MachCountryOrig"
            .Name = "MachCountryOrig"
        End With

        With Me.MachMFGDate
            .DataPropertyName = "MachMFGDate"
            .Name = "MachMFGDate"
        End With

        With Me.MachLoc
            .DataPropertyName = "MachLoc"
            .Name = "MachLoc"
        End With

        With Me.MachDetailsID
            .DataPropertyName = "MachDetailsID"
            .Name = "MachDetailsID"
            .Visible = False
        End With

        With Me.EquipID
            .DataPropertyName = "EquipID"
            .Name = "EquipID"
            .Visible = False
        End With

        'dgTask

       PutTaskInfo

        With Me.TaskPriority
            .DataPropertyName = "TaskPriority"
            .Name = "TaskPriority"
        End With

        With Me.TaskFrequency
            .DataPropertyName = "TaskFrequency"
            .Name = "TaskFrequency"
        End With

        With Me.TaskEmailNotification
            .DataPropertyName = "TaskEmailNotification"
            .Name = "TaskEmailNotification"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

        With Me.SWInstructions
            .DataPropertyName = "SWInstructions"
            .Name = "SWInstructions"
        End With

        With Me.TaskStatus
            .DataPropertyName = "TaskStatus"
            .Name = "TaskStatus"
        End With

        With Me.TaskID
            .DataPropertyName = "TaskID"
            .Name = "TaskID"
            .Visible = False
        End With

        With Me.MachDetailsIDTsk
            .DataPropertyName = "MachDetailsID"
            .Name = "MachDetailsID"
            .Visible = False
        End With

        'dgOrders
        With Me.WorkDate
            .DataPropertyName = "WorkDate"
            .Name = "WorkDate"
        End With

        With Me.WorkDescription
            .DataPropertyName = "WorkDescription"
            .Name = "WorkDescription"
        End With

        With Me.WorkHoursStop
            .DataPropertyName = "WorkHoursStop"
            .Name = "WorkHoursStop"
        End With

        With Me.WorkPerson
            .DataPropertyName = "WorkPerson"
            .Name = "WorkPerson"
        End With

        'With Me.WorkPartCost
        '    .DataPropertyName = "WorkPartCost"
        '    .Name = "WorkPartCost"
        'End With

        With Me.WorkTechCost
            .DataPropertyName = "WorkTechCost"
            .Name = "WorkTechCost"
        End With

        With Me.WorkSuppPOID
            .DataSource = CallClass.PopulateComboBox("tblPOMaster", "cmbGetPONoGeneral").Tables("tblPOMaster")
            .DisplayMember = "PONo"
            .ValueMember = "POMasterID"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
            .DataPropertyName = "WorkSuppPOID"
            .Name = "WorkSuppPOID"
        End With

        With Me.WorkID
            .DataPropertyName = "WorkID"
            .Name = "WorkID"
            .Visible = False
        End With

        With Me.TaskIDWO
            .DataPropertyName = "TaskID"
            .Name = "TaskID"
            .Visible = False
        End With

        'dgOrdersDetails

        PutProductInfo()

        With Me.WorkDetailProdID
            .DataPropertyName = "WorkDetailProdID"
            .Name = "WorkDetailProdID"
        End With

        With Me.WorkDetailQty
            .DataPropertyName = "WorkDetailQty"
            .Name = "WorkDetailQty"
        End With

        With Me.WorkDetailCost
            .DataPropertyName = "WorkDetailCost"
            .Name = "WorkDetailCost"
        End With

        With Me.WorkDetailID
            .DataPropertyName = "WorkDetailID"
            .Name = "WorkDetailID"
            .Visible = False
        End With

        With Me.WorkIDDetail
            .DataPropertyName = "WorkID"
            .Name = "WorkID"
            .Visible = False
        End With

    End Sub

    Sub ClearFields()
        txtFileNo.Text = ""
        txtNotes.Text = ""
        txtInfo.Text = ""
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daInfo = CallClass.PopulateDataAdapter("gettblMaintEquipDetails")
            daTasks = CallClass.PopulateDataAdapter("gettblMaintEquipTasks")
            daOrders = CallClass.PopulateDataAdapter("gettblMaintEquipOrdersNewVer")
            daOrdersDetails = CallClass.PopulateDataAdapter("gettblMaintEquipOrdersDetails")

            Dim InforBuilder As New SqlClient.SqlCommandBuilder(daInfo)
            Dim TasksBuilder As New SqlClient.SqlCommandBuilder(daTasks)
            Dim OrdersBuilder As New SqlClient.SqlCommandBuilder(daOrders)
            Dim OrdersDetailsBuilder As New SqlClient.SqlCommandBuilder(daOrdersDetails)

            daInfo.UpdateCommand = InforBuilder.GetUpdateCommand
            daInfo.UpdateCommand.Connection = cn
            daInfo.InsertCommand = InforBuilder.GetInsertCommand
            AddHandler daInfo.RowUpdated, AddressOf HandleRowUpdatedEquipDetails
            daInfo.InsertCommand.Connection = cn
            daInfo.DeleteCommand = InforBuilder.GetDeleteCommand
            daInfo.DeleteCommand.Connection = cn
            daInfo.AcceptChangesDuringFill = True
            daInfo.TableMappings.Add("Table", "tblMaintEquipDetails")
            daInfo.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daTasks.UpdateCommand = TasksBuilder.GetUpdateCommand
            daTasks.UpdateCommand.Connection = cn
            daTasks.InsertCommand = TasksBuilder.GetInsertCommand
            AddHandler daTasks.RowUpdated, AddressOf HandleRowUpdatedEquipTasks
            daTasks.InsertCommand.Connection = cn
            daTasks.DeleteCommand = TasksBuilder.GetDeleteCommand
            daTasks.DeleteCommand.Connection = cn
            daTasks.AcceptChangesDuringFill = True
            daTasks.TableMappings.Add("Table", "tblMaintEquipTasks")
            daTasks.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daOrders.UpdateCommand = OrdersBuilder.GetUpdateCommand
            daOrders.UpdateCommand.Connection = cn
            daOrders.InsertCommand = OrdersBuilder.GetInsertCommand
            AddHandler daOrders.RowUpdated, AddressOf HandleRowUpdatedEquipOrders
            daOrders.InsertCommand.Connection = cn
            daOrders.DeleteCommand = OrdersBuilder.GetDeleteCommand
            daOrders.DeleteCommand.Connection = cn
            daOrders.AcceptChangesDuringFill = True
            daOrders.TableMappings.Add("Table", "tblMaintEquipOrders")
            daOrders.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daOrdersDetails.UpdateCommand = OrdersDetailsBuilder.GetUpdateCommand
            daOrdersDetails.UpdateCommand.Connection = cn
            daOrdersDetails.InsertCommand = OrdersDetailsBuilder.GetInsertCommand
            AddHandler daOrdersDetails.RowUpdated, AddressOf HandleRowUpdatedEquipOrdersDetails
            daOrdersDetails.InsertCommand.Connection = cn
            daOrdersDetails.DeleteCommand = OrdersDetailsBuilder.GetDeleteCommand
            daOrdersDetails.DeleteCommand.Connection = cn
            daOrdersDetails.AcceptChangesDuringFill = True
            daOrdersDetails.TableMappings.Add("Table", "tblMaintEquipOrdersDetails")
            daOrdersDetails.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedEquipDetails(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintEquipDetails").Columns("MachDetailsID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedEquipTasks(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintEquipTasks").Columns("TaskID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedEquipOrders(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintEquipOrders").Columns("WorkID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedEquipOrdersDetails(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintEquipOrdersDetails").Columns("WorkDetailID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMach.Click

        frmMaintEquipInfo.ShowDialog()
        PutEquip()

    End Sub

    Private Sub dgInfo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgInfo.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowInfo = e.RowIndex

        Select Case e.ColumnIndex
            Case 0 To 6
                If IsDBNull(dgInfo("EquipID", e.RowIndex).Value) = True And IsDBNull(dgInfo("MachStatus", e.RowIndex).Value) = True Then
                    If Len(Trim(CmbEquip.Text)) = 0 Then
                        MsgBox("You cannot update  without Equipment Number.")
                        e.Cancel = True
                    Else
                        dgInfo("EquipID", e.RowIndex).Value = CmbEquip.SelectedItem("Equipid")

                        If IsDBNull(dgInfo("MachStatus", e.RowIndex).Value) = True Then
                            dgInfo("MachStatus", e.RowIndex).Value = "Active"
                        End If

                        If IsDBNull(dgInfo("MachSerialNo", e.RowIndex).Value) = True Then
                            MsgBox("You cannot update without S/N.")
                            e.Cancel = True
                        End If
                    End If
                End If
        End Select

    End Sub

    Private Sub dgInfo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInfo.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowInfo = e.RowIndex

        PutDescrTasks()
        PutNextWorkDate()

        If dgInfo.ReadOnly = True Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 2
                If IsDBNull(Me.dgInfo("MachStatus", e.RowIndex).Value) = False Then
                    If dgInfo.Rows(e.RowIndex).Cells("MachStatus").Value = "InActive" Then
                        MsgBox("Equipment Detail -- Status  = InActive  -  Readonly")
                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to Reset Equipment Detail -- Status ? ", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            dgInfo.Rows(e.RowIndex).Cells("MachStatus").Value = "Active"
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub dgInfo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInfo.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowInfo = e.RowIndex

        Select Case e.ColumnIndex
            Case 3
                Dim dt As DateTime = DateTime.Parse(Me.dgInfo("MachDateIn", e.RowIndex).Value)

                If dt.Year < 2005 OrElse dt.Year > Now.Year Then
                    MsgBox("Error LAC Year Date In")
                    Me.dgInfo("MachDateIn", e.RowIndex).Value = DBNull.Value
                    'dgInfo.CancelEdit()
                End If
        End Select

    End Sub

    Private Sub dgInfo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgInfo.DataError
        REM end
    End Sub

    Private Sub dgOrders_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgOrders.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowOrders = e.RowIndex

        If dgOrders.ReadOnly = True Then
            Exit Sub
        End If

        If IsDBNull(dgTasks("TaskInfoID", RowTasks).Value) = True Or Len(Trim(dgTasks("TaskInfoID", RowTasks).Value)) = 0 Then
            MsgBox("You can not edit until a task was entered or selected.")
            e.Cancel = True
            Exit Sub
        End If

        If dgTasks("TaskStatus", RowTasks).Value = "InActive" Then
            MsgBox("You can not edit as the task is InActive.")
            e.Cancel = True
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0
                If IsDBNull(dgOrders("WorkDate", e.RowIndex).Value) = True Then
                    dgOrders("WorkDate", e.RowIndex).Value = Now().ToShortDateString
                End If
        End Select

    End Sub

    Private Sub dgOrders_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOrders.DataError
        REM end
    End Sub

    Private Sub dgTasks_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgTasks.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowTasks = e.RowIndex
        End If

        If IsDBNull(dgInfo("MachSerialNo", RowInfo).Value) = True Or Len(Trim(dgInfo("MachSerialNo", RowInfo).Value)) = 0 Then
            MsgBox("You can not edit until an Equipment S/N was entered or selected.")
            e.Cancel = True
            Exit Sub
        End If

        If dgInfo("MachStatus", RowInfo).Value = "InActive" Then
            MsgBox("You can not edit as the Equipment has the status InActive.")
            e.Cancel = True
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0 To 4
                If IsDBNull(dgTasks("TaskStatus", e.RowIndex).Value) = True Then
                    dgTasks("TaskStatus", e.RowIndex).Value = "Active"
                    'Else
                    '    e.Cancel = True
                End If

        End Select

    End Sub

    Private Sub dgTasks_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTasks.CellClick


        If e.RowIndex < 0 Then
            Exit Sub
        Else
            If dgTasks.ReadOnly = True Then
                Exit Sub
            End If
        End If

       RowTasks = e.RowIndex

        'If dgTasks.RowCount >= 0 Then
        '    If dgTasks.ReadOnly = True Then
        '        Exit Sub
        '    End If
        'Else
        '    Exit Sub
        'End If

        PutDescrTasks()

        Select Case e.ColumnIndex
            Case 0
                'dgPart.EndEdit()
            Case 1
                frmMaintTaskInfo.ShowDialog()
                PutTaskInfo()
            Case 5

                If IsDBNull(Me.dgTasks("TaskStatus", e.RowIndex).Value) = False Then
                    If dgTasks.Rows(e.RowIndex).Cells("TaskStatus").Value = "InActive" Then
                        MsgBox("Maintenance Scheduler -- Status  = InActive  -  Readonly")
                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to Reset Maintenance Scheduler -- Status ? ", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            dgTasks.Rows(e.RowIndex).Cells("TaskStatus").Value = "Active"
                        End If
                    End If
                End If

        End Select

    End Sub

    Sub PutTaskInfo()
        With Me.TaskInfoID
            .DataSource = CallClass.PopulateComboBox("tblMaintTaskInfo", "cmbGetMaintTaskInfoActive").Tables("tblMaintTaskInfo")
            .DisplayMember = "TaskCodeInfo"
            .ValueMember = "TaskInfoID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
            .DataPropertyName = "TaskInfoID"
            .Name = "TaskInfoID"
        End With

    End Sub

    Private Sub dgTasks_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTasks.CellEndEdit
        If dgTasks.RowCount >= 0 Then
            If dgTasks.ReadOnly = True Then
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        RowTasks = e.RowIndex

        Dim SwSearch As String = ""

        Select Case e.ColumnIndex
            Case 0
                Try
                    'dgTasks.Rows(e.RowIndex).Cells("SWInstructions").ReadOnly = True

                    Dim II As Integer = 0
                    Dim OldTask As Integer
                    Dim SwError As String = ""

                    OldTask = Nz.Nz(dgTasks("TaskInfoID", e.RowIndex).Value)

                    For Each Row As DataGridViewRow In dgTasks.Rows
                        If Nz.Nz(Row.Cells("TaskInfoID").Value) = OldTask Then
                            If II >= 1 Then
                                'Row.Cells("TaskInfoID").Value = DBNull.Value
                                MsgBox("!!! ERROR Task Description - Duplicate !!! - Action denied.")
                                SwError = "ERROR"
                                Exit For
                            End If
                            II = II + 1
                        End If
                    Next

                    If SwError = "ERROR" Then
                        dgTasks.CancelEdit()
                        Exit Sub
                    End If

                    SwSearch = Nz.Nz(dgTasks.Rows(e.RowIndex).Cells("TaskInfoID").Value)
                    If SwSearch = 0 Then
                        Exit Sub
                    End If
                    SwSearch = CallClass.ReturnStrWithParInt("cspReturnMaintTaskDescription", dgTasks.Rows(e.RowIndex).Cells("TaskInfoID").Value)
                    If SwSearch = "False" Then
                        dgTasks.Rows(e.RowIndex).Cells("SWInstructions").Value = ""
                    Else
                        dgTasks.Rows(e.RowIndex).Cells("SWInstructions").Value = SwSearch
                    End If
                Catch ex As Exception
                    'MsgBox("Exception occured - " & ex.Message)
                End Try
        End Select

    End Sub

    Sub PutDescrTasks()

        Dim SwSearch As String = ""

        For I As Integer = 0 To (dgTasks.Rows.Count - 2)

            Try
                SwSearch = Nz.Nz(dgTasks("TaskInfoID", I).Value)
                If SwSearch = 0 Then
                    Exit Sub
                End If
                SwSearch = CallClass.ReturnStrWithParInt("cspReturnMaintTaskDescription", dgTasks("TaskInfoID", I).Value)
                If SwSearch = "False" Then
                    dgTasks("SWInstructions", I).Value = ""
                Else
                    dgTasks("SWInstructions", I).Value = SwSearch
                End If

            Catch ex As Exception
                'MsgBox("Exception occured - " & ex.Message)
            End Try

        Next I

    End Sub

    Private Sub dgTasks_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTasks.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowTasks = e.RowIndex
        End If

        'If e.RowIndex >= 0 Then
        '    dgTasks.Rows(e.RowIndex).Cells("SWInstructions").ReadOnly = True
        'End If

    End Sub

    Private Sub dgTasks_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgTasks.DataError
        REM end
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        If Len(Trim(CmbEquip.Text)) > 0 Then

            dgInfo.ReadOnly = False
            dgTasks.ReadOnly = False
            dgOrders.ReadOnly = False
            dgOrdersDetails.ReadOnly = False

            CmbEquip.Enabled = False

            CmdEdit.Enabled = False
            CmdSave.Enabled = True
            CmdNew.Enabled = False
            CmdReset.Enabled = True

            If RoleMaint(wkDeptCode) = True Then
                CmdMach.Enabled = False
                dgInfo.ReadOnly = True
                dgTasks.ReadOnly = True
            End If

        Else
            MsgBox("!!! ERROR !!! Please Chose the equipment before.")
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then
            InfoCurrency.EndCurrentEdit()
            TasksCurrency.EndCurrentEdit()
            OrdersCurrency.EndCurrentEdit()
            OrdersDetailsCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()

                    daInfo.Update(dsMain.Tables("tblMaintEquipDetails").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daTasks.Update(dsMain.Tables("tblMaintEquipTasks").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daOrders.Update(dsMain.Tables("tblMaintEquipOrders").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daOrdersDetails.Update(dsMain.Tables("tblMaintEquipOrdersDetails").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgInfo.Refresh()
            dgTasks.Refresh()
            dgOrders.Refresh()
            dgOrdersDetails.Refresh()


            DisableFields()
            FirstTimeMenuButtons()

            CmdSave.Enabled = False
            CmdReset.Enabled = True
            CmdNew.Enabled = False
            CmdEdit.Enabled = False

            PutDescrTasks()

        End If

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        If Len(Trim(CmbEquip.Text)) > 0 Then
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = True
            CmdReset.Enabled = True

            CmbEquip.Enabled = False

            dsMain.RejectChanges()
            dgInfo.Refresh()
            dgTasks.Refresh()
            dgOrders.Refresh()
            dgOrdersDetails.Refresh()

            InfoCurrency.EndCurrentEdit()
            InfoCurrency.AddNew()

            dgInfo.ReadOnly = False
            dgTasks.ReadOnly = False
            dgOrders.ReadOnly = False
            dgOrdersDetails.ReadOnly = False
        Else
            MsgBox("!!! ERROR !!! Please Chose the equipment before.")
        End If

    End Sub

    Private Sub dgTasks_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgTasks.RowPrePaint

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If IsDBNull(Me.dgTasks("TaskStatus", e.RowIndex).Value) = False Then
            If dgTasks.Rows(e.RowIndex).Cells("TaskStatus").Value = "InActive" Then
                dgTasks.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgTasks.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If

    End Sub

    Private Sub CmdPrintPo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintPo.Click
        If RowOrders < 0 Then
            Exit Sub
        End If

        If dgOrders.RowCount > 0 Then
            Dim FindPO As String

            Dim SwEndUser As String = ""

            If IsDBNull(dgOrders("WorkSuppPOID", RowOrders).Value) = True Or Nz.Nz(dgOrders("WorkSuppPOID", RowOrders).Value) = 0 Then
                MsgBox("!!! Nothing to View !!!")
                Exit Sub
            End If

            FindPO = CallClass.ReturnInfoWithParString("cspReturnPOByPOMasterID", dgOrders("WorkSuppPOID", RowOrders).Value)

            If Len(Trim(FindPO)) > 0 Then

                Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
                Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
                Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

                Try
                    Dim rptPO As New rptPOSupp()
                    rptPO.Load("..\rptposupp.rpt")
                    pdFind.Value = FindPO
                    pdEndUser.Value = SwEndUser

                    pvFindCollection.Add(pdFind)
                    pvEndUserCollection.Add(pdEndUser)

                    rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvFindCollection)
                    rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pvEndUserCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True

                    frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = False
                    frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = False

                    frmPOMasterPrint.ShowDialog()
                Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                    MsgBox("Incorrect path for loading report.", _
                            MsgBoxStyle.Critical, "Load Report Error")

                Catch Exp As Exception
                    MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
                End Try
            Else
                MsgBox("Nothing to PreView.")
            End If
        Else
            MsgBox("Nothing to PreView.")
        End If

    End Sub

    Private Sub dgTasks_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgTasks.Sorted

        PutDescrTasks()

        PutNextWorkDate()

    End Sub

    Private Sub dgInfo_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgInfo.RowPrePaint

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If IsDBNull(Me.dgInfo("MachStatus", e.RowIndex).Value) = False Then
            If dgInfo.Rows(e.RowIndex).Cells("MachStatus").Value = "InActive" Then
                dgInfo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgInfo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If

    End Sub

    Sub ValPo()

        If Len(Trim(CmbEquip.Text)) = 0 Or IsDBNull(CmbEquip.Text) = True Or IsNothing(CmbEquip.Text) = True Then
            MsgBox("!!! ERROR !!! Equipment Type is Empty.")
            SwVal = False
            Exit Sub
        End If

        For Each Row As DataGridViewRow In dgInfo.Rows
            If IsDBNull(Row.Cells("MachSerialNo").Value) = True Then
                MsgBox("!!! ERROR !!! Equipment S/N is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("MachNotes").Value) = True Then
                MsgBox("!!! ERROR !!! Equipment Notes is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("MachStatus").Value) = True Then
                MsgBox("!!! ERROR !!! Equipment Status is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        For Each Row As DataGridViewRow In dgTasks.Rows
            If IsDBNull(Row.Cells("TaskInfoID").Value) = True Then
                MsgBox("!!! ERROR !!! Task Description is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        For Each Row As DataGridViewRow In dgOrders.Rows
            If IsDBNull(Row.Cells("WorkDate").Value) = True Then
                MsgBox("!!! ERROR !!! Work Date is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("WorkDescription").Value) = True Then
                MsgBox("!!! ERROR !!! Work Description is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next


        SwVal = True

    End Sub

    Sub PutHeaderInfo()

        Try
            If IsDBNull(CmbEquip.SelectedItem("EquipFileNo")) = False Then
                txtFileNo.Text = Nz.Nz(CmbEquip.SelectedItem("EquipFileNo"))
            Else
                If IsNothing(CmbEquip.SelectedItem("EquipFileNo")) = False Then
                    txtFileNo.Text = Nz.Nz(CmbEquip.SelectedItem("EquipFileNo"))
                End If
            End If

            If IsDBNull(CmbEquip.SelectedItem("EquipNotes")) = False Then
                txtNotes.Text = Nz.Nz(CmbEquip.SelectedItem("EquipNotes"))
            Else
                If IsNothing(CmbEquip.SelectedItem("EquipNotes")) = False Then
                    txtNotes.Text = Nz.Nz(CmbEquip.SelectedItem("EquipNotes"))
                End If
            End If

            txtInfo.Text = "Supplier: " + Nz.Nz(CmbEquip.SelectedItem("EquipSupp")).ToString + vbCrLf + _
                            "Contact: " + Nz.Nz(CmbEquip.SelectedItem("EquipContactName")).ToString + vbCrLf + _
                            "Tel.   : " + Nz.Nz(CmbEquip.SelectedItem("EquipTel")).ToString + vbCrLf + _
                            "Fax    : " + Nz.Nz(CmbEquip.SelectedItem("EquipFax")).ToString + vbCrLf + _
                            "Email  : " + Nz.Nz(CmbEquip.SelectedItem("EquipEmail")).ToString
        Catch ex As Exception
        End Try

    End Sub


    Private Sub CmbEquip_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEquip.DropDownClosed

        dsMain.Tables("tblMaintEquipDetails").Clear()
        txtFileNo.Focus()

        Try
            Dim strSearch As String
            strSearch = CmbEquip.SelectedValue

            CallClass.PopulateAdapterAfterSearchInt("gettblMaintEquipDetailsByEquipID", strSearch).Fill(dsMain, "tblMaintEquipDetails")

            PutDataGrid()

            CmdNew.Enabled = True
            CmdEdit.Enabled = True
            CmdSave.Enabled = False
            CmdReset.Enabled = True

            PutHeaderInfo()

            PutNextWorkDate()
        Catch ex As Exception

        End Try

    End Sub

    Sub PutNextWorkDate()

        'For I As Integer = 0 To (dgTasks.Rows.Count - 1)
        '    If IsDBNull(dgTasks("TaskID", I).Value) = False Then
        '        If Nz.Nz(dgTasks("TaskFrequency", I).Value) > 0 Then

        '            Dim SwDate As Date
        '            Dim NewDate As Date

        '            SwDate = CallClass.ReturnStrWithParInt("cspReturnLastTaskWorkDate", dgTasks("TaskID", I).Value)
        '            NewDate = DateAdd(DateInterval.Day, dgTasks("TaskFrequency", I).Value, SwDate)
        '            dgTasks("SwNextWork", I).Value = NewDate.ToShortDateString
        '            dgTasks("SwNextWork", I).Style.BackColor = Color.LightGreen

        '        End If
        '    End If
        'Next

        For Each Row As DataGridViewRow In dgTasks.Rows
            If IsDBNull(Row.Cells("TaskID").Value) = False Then
                If Nz.Nz(Row.Cells("TaskFrequency").Value) > 0 Then

                    Dim SwDate As Date
                    Dim NewDate As Date
                    If CallClass.ReturnStrWithParInt("cspReturnLastTaskWorkDate", Row.Cells("TaskID").Value) <> "False" Then
                        SwDate = CallClass.ReturnStrWithParInt("cspReturnLastTaskWorkDate", Row.Cells("TaskID").Value)
                        NewDate = DateAdd(DateInterval.Day, Row.Cells("TaskFrequency").Value, SwDate)
                        Row.Cells("SwNextWork").Value = NewDate.ToShortDateString
                        Row.Cells("SwNextWork").Style.BackColor = Color.LightGreen
                    End If
                End If
            End If
        Next

    End Sub

    Sub PutProductInfo()
        With Me.WorkDetailProdID
            .DataSource = CallClass.PopulateComboBox("tblMaintProductsCatalog", "cmbGetMaintProductActive").Tables("tblMaintProductsCatalog")
            .DisplayMember = "ProductDescr"
            .ValueMember = "ProductID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
            .DataPropertyName = "WorkDetailProdID"
            .Name = "WorkDetailProdID"
        End With
    End Sub

    Private Sub dgOrdersDetails_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgOrdersDetails.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If dgOrdersDetails.ReadOnly = True Then
            Exit Sub
        End If

        If dgTasks("TaskStatus", RowTasks).Value = "InActive" Then
            MsgBox("You can not edit as the task is InActive.")
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub dgOrdersDetails_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrdersDetails.CellClick

        If dgOrdersDetails.RowCount >= 0 Then
            'If dgOrdersDetails.ReadOnly = True Then
            '    Exit Sub
            'End If
        Else
            Exit Sub
        End If

        RowOrdersDetails = e.RowIndex

        Select Case e.ColumnIndex
            Case 1
                frmMaintProductCatalog.ShowDialog()
                PutProductInfo()
        End Select
    End Sub

    Private Sub dgOrdersDetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOrdersDetails.DataError
        REM end
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        'GC.Collect()

        'CmbEquip.Enabled = False

        'DisableFields()

        'FirstTimeMenuButtons()

        'ClearFields()

        'BuildSqlCommand()

        'InitialComponents()

        'SetCtlForm()

        'PutEquip()

        ''PutHeaderInfo

        'CmbEquip.SelectedIndex = -1

        'PutDataGrid()

        'PutDescrTasks()

        'dsMain.Tables("tblMaintEquipDetails").Clear()

        'CmbEquip.Enabled = True

        InfoCurrency.EndCurrentEdit()
        TasksCurrency.EndCurrentEdit()
        OrdersCurrency.EndCurrentEdit()
        OrdersDetailsCurrency.EndCurrentEdit()
      

        dsMain.RejectChanges()
        DisableFields()
        FirstTimeMenuButtons()

        CmbEquip.Enabled = True
        CmbEquip.SelectedIndex = -1

        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdNew.Enabled = False

    End Sub

    Private Sub dgOrders_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgOrders.RowsRemoved

        If dgOrders.ReadOnly = True Then
            For Each trw As DataRow In dsMain.Tables("tblMaintEquipOrders").Rows
                If trw.RowState = DataRowState.Deleted = True Then
                    trw.RejectChanges()
                End If
            Next
        End If

    End Sub

    Private Sub dgOrdersDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgOrdersDetails.RowsRemoved

        If dgOrdersDetails.ReadOnly = True Then
            For Each trw As DataRow In dsMain.Tables("tblMaintEquipOrdersDetails").Rows
                If trw.RowState = DataRowState.Deleted = True Then
                    trw.RejectChanges()
                End If
            Next
        End If

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        Dim rptPO As New rptMaintEquipScheduler
        rptPO.Load("..\rptMaintEquipScheduler.rpt")
        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
        'frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
        frmPOPrintAll.Show()

    End Sub

    Private Sub CmdPrintMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintMach.Click

        Dim rptPO As New rptMaintEquipList
        rptPO.Load("..\rptMaintEquipList.rpt")
        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
        frmPOPrintAll.Show()

    End Sub

    Function RoleMaint(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MAINT" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub frmMaintEquipmentsModule_Resize(sender As Object, e As EventArgs) Handles Me.Resize


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

    Private Sub CmdWO_Click(sender As Object, e As EventArgs) Handles CmdWO.Click


        Dim pdEquipIDCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdEquipID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptPOSupp()
        rptPO.Load("..\rptposupp.rpt")
        pdEquipID.Value = CmbEquip.SelectedValue

        pdEquipIDCollection.Add(pdEquipID)

        rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pdEquipIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
       
        frmPOMasterPrint.ShowDialog()

        '==========



    End Sub
End Class