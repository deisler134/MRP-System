Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmPartToolBox

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim CallClass As New clsCommon

    Private daTool As New SqlDataAdapter

    Dim ToolCurrency As CurrencyManager

    Dim RowTool As Integer = 0
    Dim SwVal As Boolean


    Private Sub frmPartToolBox_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        ToolCurrency.EndCurrentEdit()
   
        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daTool.Dispose()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Me.Dispose()
        GC.Collect()

    End Sub

    Private Sub frmPartToolBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()

        BuildSqlCommand()

        InitialComponents()

        SetDataCtl()

        CmbPart.SelectedIndex = -1

        dgTool.AutoGenerateColumns = False
        dgTool.DataSource = dsMain
        dgTool.DataMember = "tblPartToolBox"

        dgTool.ReadOnly = True

        CmdReset.Enabled = False
        CmdSave.Enabled = False
        'CmdPrint.Enabled = False

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daTool = CallClass.PopulateDataAdapter("gettblPartToolBoxEmpty")

            Dim ToolBuilder As New SqlClient.SqlCommandBuilder(daTool)

            daTool.UpdateCommand = ToolBuilder.GetUpdateCommand
            daTool.UpdateCommand.Connection = cn
            daTool.InsertCommand = ToolBuilder.GetInsertCommand
            AddHandler daTool.RowUpdated, AddressOf HandleRowUpdatedTool
            daTool.InsertCommand.Connection = cn
            daTool.DeleteCommand = ToolBuilder.GetDeleteCommand
            daTool.DeleteCommand.Connection = cn
            daTool.AcceptChangesDuringFill = True
            daTool.TableMappings.Add("Table", "tblPartToolBox")
            daTool.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedTool(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartToolBox").Columns("ToolID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblPartToolBoxEmpty").Fill(dsMain, "tblPartToolBox")

        daTool.FillSchema(dsMain, SchemaType.Source, "tblPartToolBox")

        daTool.Fill(dsMain, "tblPartToolBox")
        Dim ToID As DataColumn = dsMain.Tables("tblPartToolBox").Columns("ToolID")
        ToID.AutoIncrement = True
        ToID.AutoIncrementStep = -1
        ToID.AutoIncrementSeed = -1
        ToID.ReadOnly = False

        dsMain.EnforceConstraints = False

        ToolCurrency = CType(BindingContext(dsMain, "tblPartToolBox"), CurrencyManager)

    End Sub

    Sub SetDataCtl()

        PutPart()

        With Me.ToolID
            .DataPropertyName = "ToolID"
            .Name = "ToolID"
            .Visible = False
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.ToolLine
            .DataPropertyName = "ToolLine"
            .Name = "ToolLine"
        End With

        With Me.ToolOperID
            .DataSource = CallClass.PopulateComboBox("dbo.tblPartCostCenter", "cmbGetToolsName").Tables("dbo.tblPartCostCenter")
            .DisplayMember = "OperDescr"
            .ValueMember = "OperID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
            .DataPropertyName = "ToolOperID"
            .Name = "ToolOperID"
        End With

        With Me.ToolName
            .DataPropertyName = "ToolName"
            .Name = "ToolName"
        End With

        With Me.ToolNotes
            .DataPropertyName = "ToolNotes"
            .Name = "ToolNotes"
        End With

    End Sub

    Sub PutPart()

        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberProduction").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Private Sub CmbPart_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPart.DropDownClosed

        CmbPart.Enabled = False

        If CmbPart.SelectedValue < 0 Then
            Exit Sub
        End If

        CallClass.PopulateDataAdapterAfterSearch("gettblPartToolBox", CmbPart.SelectedValue).Fill(dsMain, "tblPartToolBox")

        dgTool.AutoGenerateColumns = False
        dgTool.DataSource = dsMain
        dgTool.DataMember = "tblPartToolBox"

        If dgTool.Rows.Count - 1 <= 0 Then
            'new data
            CmdReset.Enabled = True
            CmdSave.Enabled = True

            dsMain.RejectChanges()
            dgTool.Refresh()

            ToolCurrency.EndCurrentEdit()
            ToolCurrency.AddNew()

            dgTool.ReadOnly = False
        Else
            'modify data
            CmdReset.Enabled = True
            CmdSave.Enabled = True

            dgTool.ReadOnly = False

        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgTool.Focus()
        dgTool.Refresh()
        CmdSave.Focus()
        dgTool.Focus()
        CmdReset.Focus()


        ToolCurrency.EndCurrentEdit()

        Call ValPo()

        If SwVal = False Then
            Exit Sub
        End If

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daTool.Update(dsMain.Tables("tblPartToolBox").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                dsMain.AcceptChanges()
            End If
        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

        dsMain.Clear()
        CallClass.PopulateDataAdapter("gettblPartToolBoxEmpty").Fill(dsMain, "tblPartToolBox")
        dgTool.AutoGenerateColumns = False
        dgTool.DataSource = dsMain
        dgTool.DataMember = "tblPartToolBox"

        dgTool.Refresh()
        dgTool.ReadOnly = True
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmbPart.Enabled = True
        CmbPart.Focus()

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        dsMain.Clear()
        CallClass.PopulateDataAdapter("gettblPartToolBoxEmpty").Fill(dsMain, "tblPartToolBox")
        dgTool.AutoGenerateColumns = False
        dgTool.DataSource = dsMain
        dgTool.DataMember = "tblPartToolBox"

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        GC.Collect()
        Me.Refresh()

        CmbPart.Enabled = True
        CmdSave.Enabled = False
        dgTool.ReadOnly = True

    End Sub

    Private Sub dgTool_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgTool.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowTool = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 3, 4, 5                   ' part number
                If IsDBNull(Me.dgTool("ToolLine", e.RowIndex).Value) Then
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgTool_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTool.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowTool = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 3, 4, 5
                If Nz.Nz(dgTool("ToolLine", e.RowIndex).Value) = 0 Then
                    MessageBox.Show("Action Denied. Enter before the Tool Line number.")
                    dgTool.EndEdit()
                Else
                    If Nz.Nz(dgTool("PartID", e.RowIndex).Value) = 0 Then
                        dgTool("PartID", e.RowIndex).Value = CmbPart.SelectedValue
                    End If
                End If
            Case 4
                If Nz.Nz(dgTool("ToolOperID", e.RowIndex).Value) = 0 Then
                    MessageBox.Show("Action Denied. Select before the Operation.")
                    dgTool.EndEdit()
                End If

        End Select
    End Sub

    Private Sub dgTool_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgTool.DataError
        REM end
    End Sub

    Sub ValPo()

        Dim II As Integer
        II = dgTool.Rows.Count
        For II = 1 To dgTool.Rows.Count - 1
            If IsDBNull(dgTool.Item("ToolLine", II - 1).Value) = True Or _
                Nz.Nz(dgTool.Item("ToolLine", II - 1).Value) = 0 Then
                MsgBox("!!! ERROR !!! Tool Line Number is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        II = dgTool.Rows.Count
        For II = 1 To dgTool.Rows.Count - 1
            If IsDBNull(dgTool.Item("PartID", II - 1).Value) = True Or _
                Nz.Nz(dgTool.Item("PartID", II - 1).Value) = 0 Then
                MsgBox("!!! ERROR !!! Part ID Number is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        II = dgTool.Rows.Count
        For II = 1 To dgTool.Rows.Count - 1
            If IsDBNull(dgTool.Item("ToolOperID", II - 1).Value) = True Or _
                Nz.Nz(dgTool.Item("ToolOperID", II - 1).Value) = 0 Then
                MsgBox("!!! ERROR !!! Operation Description is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        II = dgTool.Rows.Count
        For II = 1 To dgTool.Rows.Count - 1
            If IsDBNull(dgTool.Item("ToolName", II - 1).Value) = True 
                MsgBox("!!! ERROR !!! Tool Description is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        SwVal = True
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptPartToolBox
        rptPO.Load("..\rptPartToolBox.rpt")

        If dgTool.RowCount <= 2 Then
            Exit Sub
        End If

        pdvPartID.Value = Convert.ToInt32(dgTool.Rows(RowTool).Cells("PartID").Value)
        pvPartIDCollection.Add(pdvPartID)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()

    End Sub

End Class