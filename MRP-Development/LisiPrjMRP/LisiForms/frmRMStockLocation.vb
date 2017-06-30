Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmRMStockLocation

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daStLoc As New SqlDataAdapter

    Dim StLocCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Private Sub frmRMStockLocation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        StLocCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daStLoc.Dispose()

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmRMStockLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        CmdSave.Enabled = False
        CmdEdit.Enabled = True

        dg.ReadOnly = True

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        dg.AutoGenerateColumns = False
        dg.DataSource = dsMain
        dg.DataMember = "tblStockLoc"
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daStLoc = CallClass.PopulateDataAdapter("gettblStockLoc")

            Dim StLocBuilder As New SqlClient.SqlCommandBuilder(daStLoc)

            daStLoc.UpdateCommand = StLocBuilder.GetUpdateCommand
            daStLoc.UpdateCommand.Connection = cn
            daStLoc.InsertCommand = StLocBuilder.GetInsertCommand
            'AddHandler daStLoc.RowUpdated, AddressOf HandleRowUpdatedStLoc
            daStLoc.InsertCommand.Connection = cn
            daStLoc.DeleteCommand = StLocBuilder.GetDeleteCommand
            daStLoc.DeleteCommand.Connection = cn
            daStLoc.AcceptChangesDuringFill = True
            daStLoc.TableMappings.Add("Table", "tblStockLoc")
            daStLoc.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedStLoc(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblStockLoc").Columns("StLocID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daStLoc.FillSchema(dsMain, SchemaType.Source, "tblStockLoc")

        daStLoc.Fill(dsMain, "tblStockLoc")

        dsMain.EnforceConstraints = False

        StLocCurrency = CType(BindingContext(dsMain, "tblStockLoc"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        'for dg   
        With Me.StLocID
            .DataPropertyName = "StLocID"
            .Name = "StLocID"
        End With

        With Me.StLocNotes
            .DataPropertyName = "StLocNotes"
            .Name = "StLocNotes"
        End With

        With Me.StLocStatus
            .DataPropertyName = "StLocStatus"
            .Name = "StLocStatus"
        End With

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        StLocCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daStLoc.Update(dsMain.Tables("tblStockLoc").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
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
            If IsDBNull(Me.dg("StLocStatus", e.RowIndex).Value) = False Then
                If dg.Rows(e.RowIndex).Cells("StLocStatus").Value = "InActive" Then
                    MsgBox("Status Stock Location = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Activate Stock Location Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dg.Rows(e.RowIndex).Cells("StLocStatus").Value = "Active"
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellEndEdit
        Select Case e.ColumnIndex
            Case 0
                If IsDBNull(dg.Rows(e.RowIndex).Cells("StLocID").Value) = False Then
                    dg.Rows(e.RowIndex).Cells("StLocStatus").Value = "Active"
                End If
        End Select
    End Sub

    Private Sub dg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg.DataError
        MsgBox("!!! ERROR !!!  -  " & dg(e.ColumnIndex, e.RowIndex).ToString)
        REM end
    End Sub

    Private Sub dg_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dg.RowPrePaint
        If IsDBNull(Me.dg("StLocStatus", e.RowIndex).Value) = False Then
            If dg.Rows(e.RowIndex).Cells("StLocStatus").Value = "InActive" Then
                dg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
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