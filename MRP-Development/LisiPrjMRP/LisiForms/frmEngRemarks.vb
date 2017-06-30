Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmEngRemarks

    Inherits System.Windows.Forms.Form

    Dim cnSqlServer As New SqlConnection(strConnection)

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 

    Dim currRemark As CurrencyManager

    Dim intRemark As Integer
    Dim strSQL As String
    Dim SwEdit As Integer = 0

    Private Sub frmEngRemarks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If currRemark.Count > 0 Then
            currRemark.EndCurrentEdit()
        End If

        If ds.HasChanges Then
            Dim reply As DialogResult
            reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                ds.Dispose()
                da.Dispose()
                Me.Dispose()
                cnSqlServer.Close()
            End If
        Else
            ds.Dispose()
            da.Dispose()
            Me.Dispose()
            cnSqlServer.Close()
        End If

        GC.Collect()
    End Sub

    Private Sub frmEngRemarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()
        Connect()

        da.FillSchema(ds, SchemaType.Source, "tblPORemarks")
        da.Fill(ds, "tblPORemarks")

        Dim RemID As DataColumn = ds.Tables("tblPORemarks").Columns("RemarkID")
        RemID.AutoIncrement = True
        RemID.AutoIncrement = True
        RemID.AutoIncrementStep = -1
        RemID.AutoIncrementSeed = -1
        RemID.ReadOnly = False

        ds.EnforceConstraints = False

        currRemark = CType(BindingContext(ds, "tblPORemarks"), CurrencyManager)

        'Dim tableStyle As New DataGridTableStyle()
        'tableStyle.MappingName = "tblPOProdDescr"

        With Me.RemarkID
            .DataPropertyName = "RemarkID"
            .Name = "RemarkID"
        End With

        With Me.RemarkType
            .DataPropertyName = "RemarkType"
            .Name = "RemarkType"
        End With

        With Me.RemarkText
            .DataPropertyName = "RemarkText"
            .Name = "RemarkText"
        End With

        dg.AutoGenerateColumns = False
        dg.DataSource = ds
        dg.DataMember = "tblPORemarks"

        ButtProc.Checked = True

        dvFilter = " RemarkType = '" & "Proc" & "'"

        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

        Call BindFields()

        Call DisableScreen()

        ButtProc.Enabled = True
        ButtMat.Enabled = True
        ButtShip.Enabled = True

    End Sub

    Sub DisableScreen()

        CmdEdit.Enabled = True
        CmdSave.Enabled = False
        dg.ReadOnly = True
        txtNotes.ReadOnly = True
       
    End Sub

    Sub EnableScreen()
        CmdEdit.Enabled = False
        CmdSave.Enabled = True

        dg.ReadOnly = False
        txtNotes.ReadOnly = False
    End Sub

    Private Function BindFields() As Boolean

        txtNotes.DataBindings.Add("Text", dv, "RemarkText")

    End Function

    Private Function Connect() As Boolean

        strSQL = "Select * FROM tblPORemarks Order by RemarkText"

        Try
            Dim commRemark As New SqlClient.SqlCommand(strSQL, cnSqlServer)

            da.SelectCommand = commRemark

            Dim cmdProduct As New SqlClient.SqlCommandBuilder(da)

            da.UpdateCommand = cmdProduct.GetUpdateCommand
            da.UpdateCommand.Connection = cnSqlServer
            da.InsertCommand = cmdProduct.GetInsertCommand
            AddHandler da.RowUpdated, AddressOf HandleRowUpdatedRemark
            da.InsertCommand.Connection = cnSqlServer
            da.DeleteCommand = cmdProduct.GetDeleteCommand
            da.DeleteCommand.Connection = cnSqlServer

            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblPORemarks")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - Connect Fuction  " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedRemark(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSqlServer)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblPORemarks").Columns("RemarkID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dg.ReadOnly = True
        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        SwEdit = 0
        dg.Refresh()

        Me.BindingContext(ds, "tblPORemarks").EndCurrentEdit()

        Try
            If ds.HasChanges Then
                intRemark = da.Update(ds.Tables("tblPORemarks").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                intRemark += da.Update(ds.Tables("tblPORemarks").Select("", "", DataViewRowState.Deleted))
            End If

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        ds.AcceptChanges()

        Call DisableScreen()
    End Sub

    Private Sub ButtProc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtProc.CheckedChanged
        dvFilter = " RemarkType = '" & "Proc" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub ButtMat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtMat.CheckedChanged
        dvFilter = " RemarkType = '" & "Mat" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub ButtShip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtShip.CheckedChanged
        dvFilter = " RemarkType = '" & "Ship" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub dg_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dg.CellBeginEdit
        dg("RemarkType", e.RowIndex).ReadOnly = True
        If e.RowIndex <> -1 Then
            If Len(Trim(dg("RemarkType", e.RowIndex).ToString)) = 0 Or _
                IsDBNull(dg("RemarkType", e.RowIndex).Value) = True Then
                If ButtProc.Checked = True Then
                    dg("RemarkType", e.RowIndex).Value = "Proc"
                Else
                    If ButtMat.Checked = True Then
                        dg("RemarkType", e.RowIndex).Value = "Mat"
                    Else
                        dg("RemarkType", e.RowIndex).Value = "Ship"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Call EnableScreen()
        dg("RemarkType", 0).ReadOnly = True
        SwEdit = 9      'button was activated
    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        dg("RemarkType", e.RowIndex).ReadOnly = True
    End Sub

    Private Sub dg_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dg.UserDeletingRow
        If SwEdit = 0 Then
            dg.ReadOnly = True
            MsgBox("You must before Activate the Edit Button.")
            e.Cancel = True
        End If
    End Sub
End Class