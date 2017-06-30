Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmstQuoteRemarks
    Inherits System.Windows.Forms.Form

    Dim cnSqlServer As New SqlConnection(strConnection)

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 

    Dim currRemark As CurrencyManager

    Dim strSQL As String
    Dim SwEdit As Integer = 0

    Dim tempText As String
    Dim Rawgrid As Integer

    Private Sub frmStQuoteRemarks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmStQuoteRemarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        If SwFrom.Text = "Header" Then
            tempText = frmStQuote.txtHeader.Text
        Else
            tempText = frmStQuote.txtFooter.Text
        End If

        Connect()

        da.FillSchema(ds, SchemaType.Source, "tblStQuoteRemark")
        da.Fill(ds, "tblStQuoteRemark")

        Dim RemID As DataColumn = ds.Tables("tblStQuoteRemark").Columns("QTRemarkID")
        RemID.AutoIncrement = True
        RemID.AutoIncrement = True
        RemID.AutoIncrementStep = -1
        RemID.AutoIncrementSeed = -1
        RemID.ReadOnly = False

        ds.EnforceConstraints = False

        currRemark = CType(BindingContext(ds, "tblStQuoteRemark"), CurrencyManager)


        With Me.QTRemarkID
            .DataPropertyName = "QTRemarkID"
            .Name = "QTRemarkID"
        End With

        With Me.QTLang
            .DataPropertyName = "QTLang"
            .Name = "QTLang"
        End With

        With Me.QTRemarkText
            .DataPropertyName = "QTRemarkText"
            .Name = "QTRemarkText"
        End With

        dg.AutoGenerateColumns = False
        dg.DataSource = ds
        dg.DataMember = "tblStQuoteRemark"


        ButtEngl.Checked = True

        dvFilter = " QTLang = '" & "Engl" & "'"

        dv.Table = ds.Tables("tblStQuoteRemark")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

        Call BindFields()

        Call DisableScreen()

        ButtEngl.Enabled = True
        ButtFr.Enabled = True

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

        txtNotes.DataBindings.Add("Text", dv, "QTRemarkText")

    End Function

    Private Function Connect() As Boolean

        strSQL = "Select * FROM tblStQuoteRemark Order by QTRemarkText"

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
            da.TableMappings.Add("Table", "tblStQuoteRemark")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - Connect Fuction  " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedRemark(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSqlServer)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblStQuoteRemark").Columns("QTRemarkID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dg.ReadOnly = True
        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        SwEdit = 0
        dg.Refresh()

        Me.BindingContext(ds, "tblStQuoteRemark").EndCurrentEdit()

        Try
            If ds.HasChanges Then
                da.Update(ds.Tables("tblStQuoteRemark").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent Or DataViewRowState.Deleted))
            End If

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        ds.AcceptChanges()

        Call DisableScreen()
    End Sub

    Private Sub ButtEngl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtEngl.CheckedChanged
        dvFilter = " QTLang = '" & "Engl" & "'"
        dv.Table = ds.Tables("tblStQuoteRemark")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub ButtFr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtFr.CheckedChanged
        dvFilter = " QTLang = '" & "Fr" & "'"
        dv.Table = ds.Tables("tblStQuoteRemark")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub


    Private Sub dg_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dg.CellBeginEdit
        dg("QTLang", e.RowIndex).ReadOnly = True
        If e.RowIndex <> -1 Then
            If Len(Trim(dg("QTLang", e.RowIndex).ToString)) = 0 Or _
                IsDBNull(dg("QTLang", e.RowIndex).Value) = True Then
                If ButtEngl.Checked = True Then
                    dg("QTLang", e.RowIndex).Value = "Engl"
                Else
                    If ButtFr.Checked = True Then
                        dg("QTLang", e.RowIndex).Value = "Fr"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        Call EnableScreen()
        dg("QTLang", 0).ReadOnly = True
        SwEdit = 9      'button was activated
    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        If e.RowIndex >= 0 Then
            dg("QTLang", e.RowIndex).ReadOnly = True
            Rawgrid = e.RowIndex
        End If
    End Sub

    Private Sub dg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg.DoubleClick

        If SwFrom.Text = "Header" Then
            If IsDBNull(tempText) = True Or Len(Trim(tempText)) = 0 Then
                frmStQuote.txtHeader.Text = Me.dg("QTRemarkText", Rawgrid).Value
                tempText = Me.dg("QTRemarkText", Rawgrid).Value
            Else
                frmStQuote.txtHeader.Text = frmStQuote.txtHeader.Text + vbCrLf
                frmStQuote.txtHeader.Text = frmStQuote.txtHeader.Text + Me.dg("QTRemarkText", Rawgrid).Value
            End If
        Else
            If IsDBNull(tempText) = True Or Len(Trim(tempText)) = 0 Then
                frmStQuote.txtFooter.Text = Me.dg("QTRemarkText", Rawgrid).Value
                tempText = Me.dg("QTRemarkText", Rawgrid).Value
            Else
                frmStQuote.txtFooter.Text = frmStQuote.txtFooter.Text + vbCrLf
                frmStQuote.txtFooter.Text = frmStQuote.txtFooter.Text + Me.dg("QTRemarkText", Rawgrid).Value
            End If
        End If

    End Sub

    Private Sub dg_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dg.UserDeletingRow
        If SwEdit = 0 Then
            dg.ReadOnly = True
            MsgBox("You must before Activate the Edit Button.")
            e.Cancel = True
        End If
    End Sub
End Class