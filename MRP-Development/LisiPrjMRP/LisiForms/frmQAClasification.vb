Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmQAClasification

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsFinish As New DataSet

    Private daFinish As New SqlDataAdapter

    Dim FinishCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String

    Private Sub frmQAClasification_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        FinishCurrency.EndCurrentEdit()

        If dsFinish.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsFinish.RejectChanges()
        dsFinish.Dispose()
        daFinish.Dispose()

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmQAClasification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        dgFinish.AutoGenerateColumns = False
        dgFinish.DataSource = dsFinish
        dgFinish.DataMember = "tblLisiFormClasification"

    End Sub

    Sub DisableFields()

        dgFinish.ReadOnly = True

    End Sub

    Sub EnableFields()

        dgFinish.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False
    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daFinish = CallClass.PopulateDataAdapter("gettblLisiFormClasification")

            Dim DwgBuilder As New SqlClient.SqlCommandBuilder(daFinish)

            daFinish.UpdateCommand = DwgBuilder.GetUpdateCommand
            daFinish.UpdateCommand.Connection = cn
            daFinish.InsertCommand = DwgBuilder.GetInsertCommand
            'AddHandler daFinish.RowUpdated, AddressOf HandleRowUpdatedPartDWGSource
            daFinish.InsertCommand.Connection = cn
            daFinish.DeleteCommand = DwgBuilder.GetDeleteCommand
            daFinish.DeleteCommand.Connection = cn
            daFinish.AcceptChangesDuringFill = True
            daFinish.TableMappings.Add("Table", "tblLisiFormClasification")
            daFinish.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        dsFinish.Clear()
        dsFinish.Relations.Clear()

        daFinish.FillSchema(dsFinish, SchemaType.Source, "tblLisiFormClasification")

        daFinish.Fill(dsFinish, "tblLisiFormClasification")

        dsFinish.EnforceConstraints = False

        FinishCurrency = CType(BindingContext(dsFinish, "tblLisiFormClasification"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        With Me.QAFormClasification
            .DataPropertyName = "QAFormClasification"
            .Name = "QAFormClasification"
        End With

    End Sub

    Private Sub HandleRowUpdatedPartDWGSource(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsFinish.Tables("tblLisiFormClasification").Columns("QAFormClasification")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        EnableFields()
    End Sub

    Private Sub dgDwg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgFinish.DataError
        REM end
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then

            FinishCurrency.EndCurrentEdit()

            Try
                If dsFinish.HasChanges Then
                    dsFinish.GetChanges()
                    daFinish.Update(dsFinish.Tables("tblLisiFormClasification").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    dsFinish.AcceptChanges()
                End If
            Catch ex As Exception
                dsFinish.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgFinish.Refresh()

            dgFinish.Enabled = False
            DisableFields()
            FirstTimeMenuButtons()
        End If
    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgFinish.Rows
            If IsDBNull(Row.Cells("QAFormClasification").Value) = True Then
                MsgBox("!!! ERROR !!! Description Node.")
                SwVal = False
                Exit Sub
            End If
        Next

        SwVal = True

    End Sub

    Private Sub dgFinish_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgFinish.KeyDown

        If e.KeyCode = Keys.Delete Then
            If dgFinish.ReadOnly = True Then
                e.Handled = True
            End If
        End If

    End Sub
End Class