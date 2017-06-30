Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmEngDWGSourceName

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daDwg As New SqlDataAdapter
    
    Dim DwgCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String

    Private Sub frmEngDWGSourceName_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        DwgCurrency.EndCurrentEdit()
       
        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        dadwg.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmEngDWGSourceName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        dgDwg.AutoGenerateColumns = False
        dgDwg.DataSource = dsMain
        dgDwg.DataMember = "tblPartDWGSource"

    End Sub

    Sub DisableFields()

        dgDwg.ReadOnly = True

    End Sub

    Sub EnableFields()

        dgDwg.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False
    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daDwg = CallClass.PopulateDataAdapter("gettblPartDWGSource")

            Dim DwgBuilder As New SqlClient.SqlCommandBuilder(daDwg)

            daDwg.UpdateCommand = DwgBuilder.GetUpdateCommand
            daDwg.UpdateCommand.Connection = cn
            daDwg.InsertCommand = DwgBuilder.GetInsertCommand
            AddHandler daDwg.RowUpdated, AddressOf HandleRowUpdatedPartDWGSource
            daDwg.InsertCommand.Connection = cn
            daDwg.DeleteCommand = DwgBuilder.GetDeleteCommand
            daDwg.DeleteCommand.Connection = cn
            daDwg.AcceptChangesDuringFill = True
            daDwg.TableMappings.Add("Table", "tblPartDWGSource")
            daDwg.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daDwg.FillSchema(dsMain, SchemaType.Source, "tblPartDWGSource")

        daDwg.Fill(dsMain, "tblPartDWGSource")
        Dim DwgID As DataColumn = dsMain.Tables("tblPartDWGSource").Columns("DwgSourceID")
        DwgID.AutoIncrement = True
        DwgID.AutoIncrementStep = -1
        DwgID.AutoIncrementSeed = -1
        DwgID.ReadOnly = False

        dsMain.EnforceConstraints = False

        DwgCurrency = CType(BindingContext(dsMain, "tblPartDWGSource"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        'for dgdwg   --   dwh souce name Info
        With Me.DwgSourceID
            .DataPropertyName = "DwgSourceID"
            .Name = "DwgSourceID"
            .Visible = False
        End With

        With Me.SourceName
            .DataPropertyName = "SourceName"
            .Name = "SourceName"
        End With

        With Me.LisiBinder
            .DataPropertyName = "LisiBinder"
            .Name = "LisiBinder"
        End With

    End Sub

    Private Sub HandleRowUpdatedPartDWGSource(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartDWGSource").Columns("DwgSourceID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        EnableFields()
    End Sub

    Private Sub dgDwg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDwg.DataError
        REM end
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then

            DwgCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daDwg.Update(dsMain.Tables("tblPartDWGSource").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgDwg.Refresh()

            dgDwg.Enabled = False
            DisableFields()
            FirstTimeMenuButtons()
        End If
    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgDwg.Rows
            If IsDBNull(Row.Cells("SourceName").Value) = True Then
                MsgBox("!!! ERROR !!! Dwg Source Name is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        SwVal = True

    End Sub

End Class