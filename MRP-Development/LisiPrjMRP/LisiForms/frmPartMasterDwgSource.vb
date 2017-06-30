Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmPartMasterDwgSource

    Inherits System.Windows.Forms.Form

    Dim CurrMast As CurrencyManager
   
    Private cnSqlServer As New SqlConnection(strConnection)
    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim strSQL As String

    Private Sub frmPartMasterDwgSource_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        CurrMast.EndCurrentEdit()

        If ds.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        ds.RejectChanges()
        ds.Dispose()
        da.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmPartMasterDwgSource_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Connect()

        Try
            ds.Clear()

            da.FillSchema(ds, SchemaType.Source, "tblPartDWGSource")
            da.Fill(ds, "tblPartDWGSource")

            Dim MastID As DataColumn = ds.Tables("tblPartDWGSource").Columns("DwgSourceID")
            MastID.AutoIncrement = True
            MastID.AutoIncrement = True
            MastID.AutoIncrementStep = -1
            MastID.AutoIncrementSeed = -1
            MastID.ReadOnly = False

            ds.EnforceConstraints = False

            CurrMast = CType(BindingContext(ds, "tblPartDWGSource"), CurrencyManager)

            With Me.DwgSourceID
                .DataPropertyName = "DwgSourceID"
                .Name = "DwgSourceID"
            End With

            With Me.SourceName
                .DataPropertyName = "SourceName"
                .Name = "SourceName"
            End With

            With Me.LisiBinder
                .DataPropertyName = "LisiBinder"
                .Name = "LisiBinder"
            End With

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, _
            MsgBoxStyle.OKOnly, "frmPartMasterDwgSource_Load")
        End Try

        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        dg.ReadOnly = True

        dg.AutoGenerateColumns = False
        dg.DataSource = ds
        dg.DataMember = "tblPartDWGSource"

    End Sub

    Private Function Connect() As Boolean

        Dim strSQLMast As String = "SELECT  *  FROM  tblPartDwgSource ORDER BY SourceName"

        Try
            Dim commMaster As New SqlClient.SqlCommand(strSQLMast, cnSqlServer)

            da.SelectCommand = commMaster

            Dim cmdContBuilder As New SqlClient.SqlCommandBuilder(da)

            da.UpdateCommand = cmdContBuilder.GetUpdateCommand
            da.UpdateCommand.Connection = cnSqlServer
            da.InsertCommand = cmdContBuilder.GetInsertCommand
            AddHandler da.RowUpdated, AddressOf HandleRowUpdatedMatlType
            da.InsertCommand.Connection = cnSqlServer

            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblPartDWGSource")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedMatlType(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSqlServer)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblPartDWGSource").Columns("DwgSourceID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        dg.ReadOnly = True

        dg.Refresh()

        CurrMast.EndCurrentEdit()

        Try
            If ds.HasChanges Then
                da.Update(ds.Tables("tblPartDWGSource").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
            End If

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        ds.AcceptChanges()

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        dg.ReadOnly = False
    End Sub

    Private Sub dg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg.DataError
        MsgBox("!!! ERROR !!!  -  " & dg(e.ColumnIndex, e.RowIndex).ToString)
        REM end
    End Sub

End Class