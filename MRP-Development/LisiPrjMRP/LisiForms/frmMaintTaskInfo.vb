Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmMaintTaskInfo

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Dim SwVal As Boolean

    Private daEq As New SqlDataAdapter
    Dim EqCurrency As CurrencyManager

    Private Sub frmMaintTaskInfo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        EqCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmMaintTaskInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        DisableFields()

        FirstTimeMenuButtons()
        BuildSqlCommand()
        InitialComponents()
        SetCtlForm()

        dgEq.AutoGenerateColumns = False
        dgEq.DataSource = dsMain
        dgEq.DataMember = "tblMaintTaskInfo"
    End Sub

    Sub DisableFields()

        dgEq.ReadOnly = True

    End Sub

    Sub EnableFields()

        dgEq.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Sub SetCtlForm()
        'for dgeq  --    Info
        With Me.TaskCodeInfo
            .DataPropertyName = "TaskCodeInfo"
            .Name = "TaskCodeInfo"
        End With

        With Me.TaskDescrInfo
            .DataPropertyName = "TaskDescrInfo"
            .Name = "TaskDescrInfo"
        End With

        With Me.TaskStatus
            .DataPropertyName = "TaskStatus"
            .Name = "TaskStatus"
        End With

        With Me.TaskInfoID
            .DataPropertyName = "TaskInfoID"
            .Name = "TaskInfoID"
            .Visible = False
        End With

    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daEq = CallClass.PopulateDataAdapter("gettblMaintTasks")

            Dim DwgBuilder As New SqlClient.SqlCommandBuilder(daEq)

            daEq.UpdateCommand = DwgBuilder.GetUpdateCommand
            daEq.UpdateCommand.Connection = cn
            daEq.InsertCommand = DwgBuilder.GetInsertCommand
            AddHandler daEq.RowUpdated, AddressOf HandleRowUpdatedEqipment
            daEq.InsertCommand.Connection = cn
            daEq.DeleteCommand = DwgBuilder.GetDeleteCommand
            daEq.DeleteCommand.Connection = cn
            daEq.AcceptChangesDuringFill = True
            daEq.TableMappings.Add("Table", "tblMaintTaskInfo")
            daEq.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

    End Function

    Private Sub HandleRowUpdatedEqipment(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintTaskInfo").Columns("TaskInfoID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daEq.FillSchema(dsMain, SchemaType.Source, "tblMaintTaskInfo")

        daEq.Fill(dsMain, "tblMaintTaskInfo")
        Dim EqID As DataColumn = dsMain.Tables("tblMaintTaskInfo").Columns("TaskInfoID")
        EqID.AutoIncrement = True
        EqID.AutoIncrementStep = -1
        EqID.AutoIncrementSeed = -1
        EqID.ReadOnly = False

        dsMain.EnforceConstraints = False

        EqCurrency = CType(BindingContext(dsMain, "tblMaintTaskInfo"), CurrencyManager)

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        EnableFields()
    End Sub

    Private Sub dgEq_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgEq.CellBeginEdit

        Select Case e.ColumnIndex

            Case 0 To 1
                If IsDBNull(dgEq("TaskStatus", e.RowIndex).Value) = True Then
                    dgEq("TaskStatus", e.RowIndex).Value = "Active"
                End If
            Case 2
                If IsDBNull(dgEq("TaskCodeInfo", e.RowIndex).Value) = True And IsDBNull(dgEq("TaskDescrInfo", e.RowIndex).Value) = True Then
                    MsgBox("You cannot update here without Equipment Number.")
                    e.Cancel = True
                Else
                    dgEq("TaskStatus", e.RowIndex).Value = "Active"
                End If
        End Select

    End Sub

    Private Sub dgEq_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEq.CellClick
        If e.RowIndex >= 0 Then
            If dgEq.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgEq("TaskStatus", e.RowIndex).Value) = False Then
                If dgEq.Rows(e.RowIndex).Cells("TaskStatus").Value = "InActive" Then
                    MsgBox("Task Info Status  = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Task Info Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgEq.Rows(e.RowIndex).Cells("TaskStatus").Value = "Active"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgEq_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgEq.DataError
        REM end
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then

            EqCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daEq.Update(dsMain.Tables("tblMaintTaskInfo").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgEq.Refresh()

            dgEq.ReadOnly = False
            DisableFields()
            FirstTimeMenuButtons()
        End If

    End Sub

    Sub ValPo()

        Dim II As Integer
        For II = 1 To dgEq.Rows.Count - 1
            For Each Row As DataGridViewRow In dgEq.Rows
                If IsDBNull(dgEq.Item("TaskCodeInfo", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Task Code is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If Len(Trim(dgEq.Item("TaskCodeInfo", II - 1).Value)) = 0 Then
                    MsgBox("!!! ERROR !!! Task Description.")
                    SwVal = False
                    Exit Sub
                End If
            Next

            SwVal = True
        Next

    End Sub

    Private Sub dgEq_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgEq.RowPrePaint
        If IsDBNull(Me.dgEq("TaskStatus", e.RowIndex).Value) = False Then
            If dgEq.Rows(e.RowIndex).Cells("TaskStatus").Value = "InActive" Then
                dgEq.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgEq.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub
End Class