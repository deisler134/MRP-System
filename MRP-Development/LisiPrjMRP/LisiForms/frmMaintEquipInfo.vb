Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmMaintEquipInfo

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Dim SwVal As Boolean

    Private daEq As New SqlDataAdapter
    Dim EqCurrency As CurrencyManager

    Private Sub frmMaintEquipInfo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        EqCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        With frmMaintEquipmentsModule.CmbEquip
            .DataSource = CallClass.PopulateComboBox("tblMaintEquipments", "cmbGetEquipment").Tables("tblMaintEquipments")
            .DisplayMember = "EquipName"
            .ValueMember = "EquipID"
        End With

        GC.Collect()
    End Sub

    Private Sub frmMaintEquipInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        DisableFields()

        FirstTimeMenuButtons()
        BuildSqlCommand()
        InitialComponents()
        SetCtlForm()

        dgEq.AutoGenerateColumns = False
        dgEq.DataSource = dsMain
        dgEq.DataMember = "tblMaintEquipments"
    End Sub

    Sub DisableFields()

        dgEq.ReadOnly = True

    End Sub

    Sub EnableFields()

        dgEq.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Sub SetCtlForm()
        'for dgeq  --    Info
        With Me.EquipName
            .DataPropertyName = "EquipName"
            .Name = "EquipName"
        End With

        With Me.EquipFileNo
            .DataPropertyName = "EquipFileNo"
            .Name = "EquipFileNo"
        End With

        With Me.EquipStatus
            .DataPropertyName = "EquipStatus"
            .Name = "EquipStatus"
        End With

        With Me.EquipNotes
            .DataPropertyName = "EquipNotes"
            .Name = "EquipNotes"
        End With

        With Me.EquipSupp
            .DataPropertyName = "EquipSupp"
            .Name = "EquipSupp"
        End With

        With Me.EquipContactName
            .DataPropertyName = "EquipContactName"
            .Name = "EquipContactName"
        End With

        With Me.EquipTel
            .DataPropertyName = "EquipTel"
            .Name = "EquipTel"
        End With

        With Me.EquipFax
            .DataPropertyName = "EquipFax"
            .Name = "EquipFax"
        End With

        With Me.EquipEmail
            .DataPropertyName = "EquipEmail"
            .Name = "EquipEmail"
        End With

        With Me.EquipID
            .DataPropertyName = "EquipID"
            .Name = "EquipID"
            .Visible = False
        End With

    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            daEq = CallClass.PopulateDataAdapter("gettblMaintEquipments")

            Dim DwgBuilder As New SqlClient.SqlCommandBuilder(daEq)

            daEq.UpdateCommand = DwgBuilder.GetUpdateCommand
            daEq.UpdateCommand.Connection = cn
            daEq.InsertCommand = DwgBuilder.GetInsertCommand
            AddHandler daEq.RowUpdated, AddressOf HandleRowUpdatedEqipment
            daEq.InsertCommand.Connection = cn
            daEq.DeleteCommand = DwgBuilder.GetDeleteCommand
            daEq.DeleteCommand.Connection = cn
            daEq.AcceptChangesDuringFill = True
            daEq.TableMappings.Add("Table", "tblMaintEquipments")
            daEq.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedEqipment(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMaintEquipments").Columns("EquipID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daEq.FillSchema(dsMain, SchemaType.Source, "tblMaintEquipments")

        daEq.Fill(dsMain, "tblMaintEquipments")
        Dim EqID As DataColumn = dsMain.Tables("tblMaintEquipments").Columns("EquipID")
        EqID.AutoIncrement = True
        EqID.AutoIncrementStep = -1
        EqID.AutoIncrementSeed = -1
        EqID.ReadOnly = False

        dsMain.EnforceConstraints = False

        EqCurrency = CType(BindingContext(dsMain, "tblMaintEquipments"), CurrencyManager)

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        EnableFields()
    End Sub

    Private Sub dgEq_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEq.CellClick

        If e.RowIndex >= 0 Then
            If dgEq.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgEq("EquipStatus", e.RowIndex).Value) = False Then
                If dgEq.Rows(e.RowIndex).Cells("EquipStatus").Value = "InActive" Then
                    MsgBox("Equipment Status  = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Equipment Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgEq.Rows(e.RowIndex).Cells("EquipStatus").Value = "Active"
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgEq_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgEq.DataError
        REM end
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then

            EqCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daEq.Update(dsMain.Tables("tblMaintEquipments").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    dsMain.AcceptChanges()
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgEq.Refresh()

            dgEq.ReadOnly = False
            DisableFields()
            FirstTimeMenuButtons()
        End If

    End Sub

    Sub ValPo()

        Dim II As Integer
        For II = 1 To dgEq.Rows.Count - 1
            For Each Row As DataGridViewRow In dgEq.Rows
                If IsDBNull(dgEq.Item("EquipName", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Equipment Name is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If Len(Trim(dgEq.Item("EquipName", II - 1).Value)) = 0 Then
                    MsgBox("!!! ERROR !!! Equipment Name is Empty.")
                    SwVal = False
                    Exit Sub
                End If
            Next

            SwVal = True
        Next

    End Sub

    Private Sub dgEq_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgEq.RowPrePaint
        If IsDBNull(Me.dgEq("EquipStatus", e.RowIndex).Value) = False Then
            If dgEq.Rows(e.RowIndex).Cells("EquipStatus").Value = "InActive" Then
                dgEq.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgEq.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

End Class