Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmEngApprMillList

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daAppr As New SqlDataAdapter

    Dim ApprCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Private Sub frmEngApprMillList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        ApprCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daAppr.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub
    Private Sub frmEngApprMillList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        CmdSave.Enabled = False
        CmdEdit.Enabled = True

        dgAppr.ReadOnly = True

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        CalculGrid()

        dgAppr.AutoGenerateColumns = False
        dgAppr.DataSource = dsMain
        dgAppr.DataMember = "tblApprMillList"

    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daAppr = CallClass.PopulateDataAdapter("gettblApprMillList")

            Dim ApprBuilder As New SqlClient.SqlCommandBuilder(daAppr)
         
            daAppr.UpdateCommand = ApprBuilder.GetUpdateCommand
            daAppr.UpdateCommand.Connection = cn
            daAppr.InsertCommand = ApprBuilder.GetInsertCommand
            AddHandler daAppr.RowUpdated, AddressOf HandleRowUpdatedAppr
            daAppr.InsertCommand.Connection = cn
            daAppr.DeleteCommand = ApprBuilder.GetDeleteCommand
            daAppr.DeleteCommand.Connection = cn
            daAppr.AcceptChangesDuringFill = True
            daAppr.TableMappings.Add("Table", "tblApprMillList")
            daAppr.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedAppr(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblApprMillList").Columns("MillID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daAppr.FillSchema(dsMain, SchemaType.Source, "tblApprMillList")

        daAppr.Fill(dsMain, "tblApprMillList")
        Dim ApprID As DataColumn = dsMain.Tables("tblApprMillList").Columns("MillID")
        ApprID.AutoIncrement = True
        ApprID.AutoIncrementStep = -1
        ApprID.AutoIncrementSeed = -1
        ApprID.ReadOnly = False

        dsMain.EnforceConstraints = False

        ApprCurrency = CType(BindingContext(dsMain, "tblApprMillList"), CurrencyManager)
      
    End Sub

    Sub SetCtlForm()

        'for dgAppr  

        With Me.MillID
            .DataPropertyName = "MillID"
            .Name = "MillID"
            .Visible = False
        End With

        With Me.MillName
            .DataPropertyName = "MillName"
            .Name = "MillName"
        End With

        With Me.MillApprDate
            .DataPropertyName = "MillApprDate"
            .Name = "MillApprDate"
        End With

        With Me.MillExpDate
            .DataPropertyName = "MillExpDate"
            .Name = "MillExpDate"
        End With

        With Me.Days
            .DataPropertyName = "Days"
            .Name = "Days"
        End With

        With Me.MillStatus
            .DataPropertyName = "MillStatus"
            .Name = "MillStatus"
        End With

        With Me.MillApprFor
            .DataPropertyName = "MillApprFor"
            .Name = "MillApprFor"
        End With

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        ApprCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daAppr.Update(dsMain.Tables("tblApprMillList").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                dsMain.AcceptChanges()
            End If
        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

        dgAppr.Refresh()
      
        dgAppr.ReadOnly = True

        CmdSave.Enabled = False
        CmdEdit.Enabled = True

    End Sub

    Private Sub dgAppr_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAppr.CellClick
        If e.RowIndex >= 0 Then
            If dgAppr.ReadOnly = True Then
                CalculGrid()
                Exit Sub
            End If
            If IsDBNull(Me.dgAppr("MillStatus", e.RowIndex).Value) = False Then
                If dgAppr.Rows(e.RowIndex).Cells("MillStatus").Value = "InActive" Then
                    MsgBox("Status Mill Producer = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reactivate Mill Producer information ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgAppr.Rows(e.RowIndex).Cells("MillStatus").Value = "Active"
                        dgAppr.Rows(e.RowIndex).Cells("MillApprDate").Value = Date.Today
                        dgAppr.Rows(e.RowIndex).Cells("MillExpDate").Value = DateAdd(DateInterval.Year, 2, dgAppr.Rows(e.RowIndex).Cells("MillApprDate").Value)
                    End If
                End If
            End If
            CalculGrid()
            dgAppr("MillExpDate", e.RowIndex).ReadOnly = True
            dgAppr("days", e.RowIndex).ReadOnly = True
            dgAppr("MillStatus", e.RowIndex).ReadOnly = True
        End If

    End Sub

    Private Sub dgAppr_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAppr.CellEndEdit
        Select Case e.ColumnIndex
            Case 2
                If IsDBNull(dgAppr.Rows(e.RowIndex).Cells("MillApprDate").Value) = False Then
                    dgAppr.Rows(e.RowIndex).Cells("MillStatus").Value = "Active"
                    dgAppr.Rows(e.RowIndex).Cells("MillExpDate").Value = DateAdd(DateInterval.Year, 2, dgAppr.Rows(e.RowIndex).Cells("MillApprDate").Value)
                End If
        End Select

    End Sub

    Private Sub dgAppr_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgAppr.DataError
        MsgBox("!!! ERROR !!!  -  " & dgAppr(e.ColumnIndex, e.RowIndex).ToString)
        REM end
    End Sub

    Private Sub dgAppr_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgAppr.RowPrePaint
        If IsDBNull(Me.dgAppr("MillStatus", e.RowIndex).Value) = False Then
            If dgAppr.Rows(e.RowIndex).Cells("MillStatus").Value = "InActive" Then
                dgAppr.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgAppr.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        dgAppr.ReadOnly = False
    End Sub

    Sub CalculGrid()
        For Each Row As DataGridViewRow In dgAppr.Rows
            If IsDBNull(Row.Cells("MillName").Value) = True Then
                Exit Sub
            Else
                If IsDBNull(Row.Cells("MillExpDate").Value) = True Then
                    Exit Sub
                End If
            End If

            Dim dateExp, dateNow As New System.DateTime
            Dim diff3 As System.TimeSpan

            dateExp = Row.Cells("MillExpDate").Value
            dateNow = Date.Today.ToString
            diff3 = System.DateTime.op_Subtraction(dateExp, dateNow)

            Row.Cells("days").Value = diff3.TotalDays
            'diff2 = System.DateTime.op_Subtraction(date2, date3)

            If Val(diff3.ToString) < 0 Then
                Row.Cells("MillStatus").Value = "InActive"
                Row.Cells("days").ReadOnly = True
                Row.Cells("MillExpDate").ReadOnly = True
                Row.Cells("MillStatus").ReadOnly = True
            End If
        Next
       
    End Sub

End Class