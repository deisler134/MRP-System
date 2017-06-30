Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmMemoDispRemarks
    Inherits System.Windows.Forms.Form

    Dim cnSql As New SqlConnection(strConnection)

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim currDisp As CurrencyManager

    Dim strSQL As String
    Dim SwEdit As Integer = 0

    Dim tempText As String
    Dim RowGrid As Integer

    Private Sub frmMemoDispRemarks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If currDisp.Count > 0 Then
            currDisp.EndCurrentEdit()
        End If

        If ds.HasChanges Then
            If txtFrom.Text = "Button" Then
                Dim reply As DialogResult
                reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                Else
                    ds.Dispose()
                    da.Dispose()
                    Me.Dispose()
                    cnSql.Close()
                End If
            Else
                ds.Dispose()
                da.Dispose()
                Me.Dispose()
                cnSql.Close()
            End If
        End If


        GC.Collect()

    End Sub

    Private Sub frmMemoDispRemarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Connect()

        da.FillSchema(ds, SchemaType.Source, "tblMemoDispText")
        da.Fill(ds, "tblMemoDispText")

        Dim DispID As DataColumn = ds.Tables("tblMemoDispText").Columns("DispTextID")
        DispID.AutoIncrement = True
        DispID.AutoIncrement = True
        DispID.AutoIncrementStep = -1
        DispID.AutoIncrementSeed = -1
        DispID.ReadOnly = False

        ds.EnforceConstraints = False

        currDisp = CType(BindingContext(ds, "tblMemoDispText"), CurrencyManager)


        With Me.DispText
            .DataPropertyName = "DispText"
            .Name = "DispText"
        End With

        With Me.DispTextID
            .DataPropertyName = "DispTextID"
            .Name = "DispTextID"
            .Visible = False
        End With

        dgDisp.AutoGenerateColumns = False
        dgDisp.DataSource = ds
        dgDisp.DataMember = "tblMemoDispText"

        Call BindFields()

        If RoleDispText(wkDeptCode) = True Then
            CmdEdit.Enabled = True
            CmdSave.Enabled = False
            dgDisp.ReadOnly = True
            txtNotes.ReadOnly = True
        Else
            CmdEdit.Enabled = False
            CmdSave.Enabled = False
            dgDisp.ReadOnly = True
            txtNotes.ReadOnly = True
        End If

    End Sub

    Sub EnableScreen()
        CmdEdit.Enabled = False
        CmdSave.Enabled = True

        dgDisp.ReadOnly = False
        txtNotes.ReadOnly = False
    End Sub

    Private Function BindFields() As Boolean

        txtNotes.DataBindings.Clear()
        txtNotes.DataBindings.Add("Text", ds, "tblMemoDispText")

    End Function

    Private Function Connect() As Boolean

        ds.Clear()
        'ds.Tables("tblMemoDispText").Clear()
        ds.Relations.Clear()

        strSQL = "SELECT  TOP 100 PERCENT dbo.tblMemoDispText.* FROM dbo.tblMemoDispText ORDER BY DispText"

        Try
            Dim commRemark As New SqlClient.SqlCommand(strSQL, cnSql)

            da.SelectCommand = commRemark

            Dim cmdProduct As New SqlClient.SqlCommandBuilder(da)

            da.UpdateCommand = cmdProduct.GetUpdateCommand
            da.UpdateCommand.Connection = cnSql
            da.InsertCommand = cmdProduct.GetInsertCommand
            AddHandler da.RowUpdated, AddressOf HandleRowUpdatedRemark
            da.InsertCommand.Connection = cnSql
            da.DeleteCommand = cmdProduct.GetDeleteCommand
            da.DeleteCommand.Connection = cnSql

            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblMemoDispText")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            'MsgBox("Exception occured - Connect Fuction  " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedRemark(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSql)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblMemoDispText").Columns("DispTextID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgDisp.ReadOnly = True
        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        SwEdit = 0
        dgDisp.Refresh()

        Me.BindingContext(ds, "tblMemoDispText").EndCurrentEdit()

        Try
            If ds.HasChanges Then
                da.Update(ds.Tables("tblMemoDispText").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent Or DataViewRowState.Deleted))
            End If

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        ds.AcceptChanges()

    End Sub

    Private Sub dgdisp_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDisp.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowGrid = e.RowIndex
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        Call EnableScreen()
        SwEdit = 9      'button was activated

    End Sub

    Private Sub dgDisp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDisp.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowGrid = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0

                If RoleDispText(wkDeptCode) = True Then

                    If Len(Trim(Convert.ToString(dgDisp.Rows(e.RowIndex).Cells("DispText").Value))) = 0 Then
                        Me.Dispose()
                        cnSql.Close()
                        Exit Sub
                    End If

                    dgDisp.Refresh()
                    Me.BindingContext(ds, "tblMemoDispText").EndCurrentEdit()

                    If ds.HasChanges Then
                        MsgBox(" Action Denied. Please activate SAVE button before.")
                        Exit Sub
                    End If
                End If

                If txtFrom.Text = "DataGrid" Then
                    Dim SwRow As Integer = frmLisiMemoApp.SwRowAction.Text

                    tempText = Nz.Nz(frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value)

                    If IsDBNull(Me.dgDisp("DispText", RowGrid).Value) = False Then
                        If IsDBNull(tempText) = True Or Len(Trim(tempText)) = 0 Then
                            frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value = Me.dgDisp("DispText", RowGrid).Value
                            tempText = Me.dgDisp("DispText", RowGrid).Value
                        Else
                            frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value = frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value + vbCrLf
                            frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value = frmLisiMemoApp.dgAction("ActionDescr", SwRow).Value + Me.dgDisp("DispText", RowGrid).Value
                        End If
                    End If
                End If

                Me.Dispose()
                cnSql.Close()
        End Select

    End Sub

    Private Sub dg_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgDisp.UserDeletingRow

        If SwEdit = 0 And RoleDispText(wkDeptCode) = True Then
            dgDisp.ReadOnly = True
            MsgBox("You must before Activate the Edit Button.")
            e.Cancel = True
        End If

    End Sub

    Function RoleDispText(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MEMODISPTEXT" Then
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

End Class