Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOperatorsPay

    Inherits System.Windows.Forms.Form

    Private cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet
    Private daOper As New SqlDataAdapter

    Dim OperCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim strSQL As String

    Private Sub frmOperatorsPay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        CmdSave.Focus()
        dgOper.Refresh()
        CmdEdit.Focus()

        Dim reply As DialogResult

        OperCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If
        dsMain.Dispose()
        daOper.Dispose()
        Me.Dispose()

    End Sub

    Private Sub frmOperatorsPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        dgOper.ReadOnly = True

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        ButtActive.Checked = True

        dsMain.Tables("tblEmployee").Clear()

        CallClass.PopulateDataAdapter("gettblEmployeeShoopActive").Fill(dsMain, "tblEmployee")

        dgOper.AutoGenerateColumns = False
        dgOper.DataSource = dsMain
        dgOper.DataMember = "tblEmployee"

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daOper = CallClass.PopulateDataAdapter("gettblEmployeePayActive")

            Dim OperBuilder As New SqlClient.SqlCommandBuilder(daOper)

            daOper.UpdateCommand = OperBuilder.GetUpdateCommand
            daOper.UpdateCommand.Connection = cn
            daOper.InsertCommand = OperBuilder.GetInsertCommand
            AddHandler daOper.RowUpdated, AddressOf HandleRowUpdatedMatl
            daOper.InsertCommand.Connection = cn
            daOper.DeleteCommand = OperBuilder.GetDeleteCommand
            daOper.DeleteCommand.Connection = cn
            daOper.AcceptChangesDuringFill = True
            daOper.TableMappings.Add("Table", "tblEmployee")
            daOper.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedMatl(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblEmployee").Columns("EmployeeID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daOper.FillSchema(dsMain, SchemaType.Source, "tblEmployee")

        daOper.Fill(dsMain, "tblEmployee")
        Dim MOperID As DataColumn = dsMain.Tables("tblEmployee").Columns("EmployeeID")
        MOperID.AutoIncrement = True
        MOperID.AutoIncrementStep = -1
        MOperID.AutoIncrementSeed = -1
        MOperID.ReadOnly = False

        dsMain.EnforceConstraints = False

        OperCurrency = CType(BindingContext(dsMain, "tblEmployee"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        With Me.EmployeeID
            .DataPropertyName = "EmployeeID"
            .Name = "EmployeeID"
            .Visible = False
        End With

        With Me.EmpUserID
            .DataPropertyName = "EmpUserID"
            .Name = "EmpUserID"
            .Visible = False
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.Emppassword
            .DataPropertyName = "Emppassword"
            .Name = "Emppassword"
        End With

        With Me.Discontinued
            .DataPropertyName = "Discontinued"
            .Name = "Discontinued"
            .ToString()
        End With

        With Me.NivAccess
            .DataPropertyName = "NivAccess"
            .Name = "NivAccess"
        End With

        With Me.DeptCode
            .DataPropertyName = "DeptCode"
            .Name = "DeptCode"
        End With

        With Me.EmpDept
            .DataPropertyName = "EmpDept"
            .Name = "EmpDept"
        End With

        With Me.EmpMatricule
            .DataPropertyName = "EmpMatricule"
            .Name = "EmpMatricule"
        End With

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        CmdSave.Focus()
        dgOper.Refresh()
        CmdEdit.Focus()

        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        dgOper.ReadOnly = True

        dgOper.Refresh()

        OperCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daOper.Update(dsMain.Tables("tblEmployee").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                dsMain.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        dgOper.Refresh()

    End Sub

    Private Sub dgOper_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgOper.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 5, 6, 7, 8
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgOper_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOper.CellClick
        If e.RowIndex >= 0 Then
            If dgOper.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgOper("Discontinued", e.RowIndex).Value) = False Then
                If dgOper.Rows(e.RowIndex).Cells("Discontinued").Value = "1" Then
                    MsgBox("Employee Status = Discontinued  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Employee Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgOper.Rows(e.RowIndex).Cells("Discontinued").Value = "0"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgOper_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOper.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 2 Then
            If IsDBNull(dgOper.Rows(e.RowIndex).Cells("Discontinued").Value) = True Then
                dgOper.Rows(e.RowIndex).Cells("Discontinued").Value = "0"
                dgOper.Rows(e.RowIndex).Cells("NivAccess").Value = "9"
                dgOper.Rows(e.RowIndex).Cells("DeptCode").Value = "SHOP"
                dgOper.Rows(e.RowIndex).Cells("EmpDept").Value = "PROD"
                dgOper.Rows(e.RowIndex).Cells("EmpUserID").Value = "Lisi"
            End If
        End If

        If e.ColumnIndex = 3 Then
            If IsDBNull(dgOper.Rows(e.RowIndex).Cells("EmpMatricule").Value) = True Then
                dgOper.Rows(e.RowIndex).Cells("EmpMatricule").Value = Val(dgOper.Rows(e.RowIndex).Cells("Emppassword").Value)
            End If
        End If

    End Sub

    Private Sub dgoper_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOper.DataError
        REM end
    End Sub

    Private Sub dgOper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOper.GotFocus

        For Each Row As DataGridViewRow In dgOper.Rows
            Row.Cells("NivAccess").Style.BackColor = Color.LightBlue
            Row.Cells("DeptCode").Style.BackColor = Color.LightBlue
            Row.Cells("EmpDept").Style.BackColor = Color.LightBlue
            Row.Cells("EmpMatricule").Style.BackColor = Color.LightBlue
        Next

    End Sub

    Private Sub dgOper_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgOper.RowPrePaint
        If IsDBNull(Me.dgOper("Discontinued", e.RowIndex).Value) = False Then
            If dgOper.Rows(e.RowIndex).Cells("Discontinued").Value = "1" Then
                dgOper.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgOper.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        dgOper.ReadOnly = False
    End Sub

    Private Sub ButtActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtActive.CheckedChanged

        dsMain.Tables("tblEmployee").Clear()

        CallClass.PopulateDataAdapter("gettblEmployeeShoopActive").Fill(dsMain, "tblEmployee")

        dgOper.AutoGenerateColumns = False
        dgOper.DataSource = dsMain
        dgOper.DataMember = "tblEmployee"

    End Sub

    Private Sub ButtAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtAll.CheckedChanged

        dsMain.Tables("tblEmployee").Clear()

        CallClass.PopulateDataAdapter("gettblEmployeeShoopAll").Fill(dsMain, "tblEmployee")

        dgOper.AutoGenerateColumns = False
        dgOper.DataSource = dsMain
        dgOper.DataMember = "tblEmployee"

    End Sub
End Class

