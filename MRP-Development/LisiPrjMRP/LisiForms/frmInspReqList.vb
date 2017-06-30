Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmInspReqList

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daReq As New SqlDataAdapter

    Dim ReqCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Private Sub frmInspReqList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        ReqCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daReq.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmInspReqList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        CmdSave.Enabled = False
        CmdEdit.Enabled = True

        dg.ReadOnly = True

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        dg.AutoGenerateColumns = False
        dg.DataSource = dsMain
        dg.DataMember = "tblRequirementsList"

    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daReq = CallClass.PopulateDataAdapter("gettblRequirementsList")

            Dim ReqBuilder As New SqlClient.SqlCommandBuilder(daReq)

            daReq.UpdateCommand = ReqBuilder.GetUpdateCommand
            daReq.UpdateCommand.Connection = cn
            daReq.InsertCommand = ReqBuilder.GetInsertCommand
            AddHandler daReq.RowUpdated, AddressOf HandleRowUpdatedReq
            daReq.InsertCommand.Connection = cn
            daReq.DeleteCommand = ReqBuilder.GetDeleteCommand
            daReq.DeleteCommand.Connection = cn
            daReq.AcceptChangesDuringFill = True
            daReq.TableMappings.Add("Table", "tblRequirementsList")
            daReq.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedReq(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblRequirementsList").Columns("ReqID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daReq.FillSchema(dsMain, SchemaType.Source, "tblRequirementsList")

        daReq.Fill(dsMain, "tblRequirementsList")
        Dim LocID As DataColumn = dsMain.Tables("tblRequirementsList").Columns("ReqID")
        LocID.AutoIncrement = True
        LocID.AutoIncrementStep = -1
        LocID.AutoIncrementSeed = -1
        LocID.ReadOnly = False

        dsMain.EnforceConstraints = False

        ReqCurrency = CType(BindingContext(dsMain, "tblRequirementsList"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        'for dg   
        With Me.ReqID
            .DataPropertyName = "ReqID"
            .Name = "ReqID"
        End With

        With Me.ReqName
            .DataPropertyName = "ReqName"
            .Name = "ReqName"
        End With

        With Me.ReqStatus
            .DataPropertyName = "ReqStatus"
            .Name = "ReqStatus"
        End With

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        ReqCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daReq.Update(dsMain.Tables("tblRequirementsList").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                dsMain.AcceptChanges()
            End If
        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

        dg.Refresh()

        dg.ReadOnly = True

        CmdSave.Enabled = False
        CmdEdit.Enabled = True

    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        If e.RowIndex >= 0 Then
            If dg.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dg("ReqStatus", e.RowIndex).Value) = False Then
                If dg.Rows(e.RowIndex).Cells("ReqStatus").Value = "InActive" Then
                    MsgBox("Status = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Activate the Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dg.Rows(e.RowIndex).Cells("ReqStatus").Value = "Active"
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellEndEdit
        Select Case e.ColumnIndex
            Case 1
                If IsDBNull(dg.Rows(e.RowIndex).Cells("ReqName").Value) = False Then
                    dg.Rows(e.RowIndex).Cells("ReqStatus").Value = "Active"
                End If
        End Select
    End Sub


    Private Sub dg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg.DataError
        MsgBox("!!! ERROR !!!  -  " & dg(e.ColumnIndex, e.RowIndex).ToString)
        REM end
    End Sub

    Private Sub dg_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg.RowPrePaint
        If IsDBNull(Me.dg("ReqStatus", e.RowIndex).Value) = False Then
            If dg.Rows(e.RowIndex).Cells("ReqStatus").Value = "InActive" Then
                dg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        dg.ReadOnly = False

    End Sub

End Class