Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmEngBlankIndex
    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Private daIndex As New SqlDataAdapter
    Dim IndexCurrency As CurrencyManager

    Dim SwVal As Boolean
    Dim strSQL As String

    Private Sub frmEngBlankIndex_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        IndexCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daIndex.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmEngBlankIndex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        dgIndex.AutoGenerateColumns = False
        dgIndex.DataSource = dsMain
        dgIndex.DataMember = "tblPartBlankRef"
    End Sub

    Sub DisableFields()
        dgIndex.ReadOnly = True
    End Sub

    Sub EnableFields()

        dgIndex.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False
    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daIndex = CallClass.PopulateDataAdapter("gettblPartBlankRef")

            Dim DwgBuilder As New SqlClient.SqlCommandBuilder(daIndex)

            daIndex.UpdateCommand = DwgBuilder.GetUpdateCommand
            daIndex.UpdateCommand.Connection = cn
            daIndex.InsertCommand = DwgBuilder.GetInsertCommand
            AddHandler daIndex.RowUpdated, AddressOf HandleRowUpdatedPartDWGSource
            daIndex.InsertCommand.Connection = cn
            daIndex.DeleteCommand = DwgBuilder.GetDeleteCommand
            daIndex.DeleteCommand.Connection = cn
            daIndex.AcceptChangesDuringFill = True
            daIndex.TableMappings.Add("Table", "tblPartBlankRef")
            daIndex.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daIndex.FillSchema(dsMain, SchemaType.Source, "tblPartBlankRef")

        daIndex.Fill(dsMain, "tblPartBlankRef")
        Dim DwgID As DataColumn = dsMain.Tables("tblPartBlankRef").Columns("PNBlankIndexID")
        DwgID.AutoIncrement = True
        DwgID.AutoIncrementStep = -1
        DwgID.AutoIncrementSeed = -1
        DwgID.ReadOnly = False

        dsMain.EnforceConstraints = False

        IndexCurrency = CType(BindingContext(dsMain, "tblPartBlankRef"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        'for dgindex   
        
        With Me.PNBlankIndex
            .DataPropertyName = "PNBlankIndex"
            .Name = "PNBlankIndex"
        End With

        With Me.PNBlankNotes
            .DataPropertyName = "PNBlankNotes"
            .Name = "PNBlankNotes"
        End With

        With Me.PNBlankIndexID
            .DataPropertyName = "PNBlankIndexID"
            .Name = "PNBlankIndexID"
            .Visible = False
        End With

    End Sub

    Private Sub HandleRowUpdatedPartDWGSource(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartBlankRef").Columns("PNBlankIndexID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then

            IndexCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daIndex.Update(dsMain.Tables("tblPartBlankRef").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgIndex.Refresh()

            dgIndex.Enabled = False
            DisableFields()
            FirstTimeMenuButtons()
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        EnableFields()
    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgIndex.Rows
            If IsDBNull(Row.Cells("PNBlankIndex").Value) = True Then
                MsgBox("!!! ERROR !!! P/N Blank Index is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        SwVal = True

    End Sub

    Private Sub dgIndex_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgIndex.DataError
        REM end
    End Sub
End Class