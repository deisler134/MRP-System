Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmCustUpdateBudget

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean = True

    Private Sub frmCustUpdateBudget_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmCustUpdateBudget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
        Call SetupForm()

    End Sub

    Sub SetupForm()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        SetCtlForm()

        PutCustomer()

        CmbCust.Enabled = True

    End Sub

    Sub DisableFields()

        dgBudget.Visible = False

    End Sub

    Sub FirstTimeMenuButtons()

        CmdReset.Enabled = True
        CmdSave.Enabled = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblCustBudget").FillSchema(dsMain, SchemaType.Source, "tblCustBudget")
        Dim IdentID As DataColumn = dsMain.Tables("tblCustBudget").Columns("BudID")
        IdentID.AutoIncrement = True
        IdentID.AutoIncrementStep = -1
        IdentID.AutoIncrementSeed = -1
        IdentID.ReadOnly = False

        dsMain.EnforceConstraints = False

    End Sub

    Sub PutCustomer()

        With Me.cmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub SetCtlForm()

        With Me.BudID
            .DataPropertyName = "BudID"
            .Name = "BudID"
            .Visible = False
        End With

        With Me.CustomerID
            .DataPropertyName = "CustomerID"
            .Name = "CustomerID"
            .Visible = False
        End With

        With Me.IdentYear
            .DataPropertyName = "IdentYear"
            .Name = "IdentYear"
        End With

        With Me.Month01
            .DataPropertyName = "Month01"
            .Name = "Month01"
        End With

        With Me.Month02
            .DataPropertyName = "Month02"
            .Name = "Month02"
        End With

        With Me.Month03
            .DataPropertyName = "Month03"
            .Name = "Month03"
        End With

        With Me.Month04
            .DataPropertyName = "Month04"
            .Name = "Month04"
        End With

        With Me.Month05
            .DataPropertyName = "Month05"
            .Name = "Month05"
        End With

        With Me.Month06
            .DataPropertyName = "Month06"
            .Name = "Month06"
        End With

        With Me.Month07
            .DataPropertyName = "Month07"
            .Name = "Month07"
        End With

        With Me.Month08
            .DataPropertyName = "Month08"
            .Name = "Month08"
        End With

        With Me.Month09
            .DataPropertyName = "Month09"
            .Name = "Month09"
        End With

        With Me.Month10
            .DataPropertyName = "Month10"
            .Name = "Month10"
        End With

        With Me.Month11
            .DataPropertyName = "Month11"
            .Name = "Month11"
        End With

        With Me.Month12
            .DataPropertyName = "Month12"
            .Name = "Month12"
        End With

        With Me.Total
            .DataPropertyName = "Total"
            .Name = "Total"
        End With

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        'Call ValPo()

        If SwVal = True Then

            If (dsMain.HasChanges) Then
                Try
                    UpdateBudget(dsMain.GetChanges)
                    MsgBox("Update successfully.")
                    dsMain.AcceptChanges()

                    Call SetupForm()

                Catch ex As Exception
                    MsgBox("Update failed: " & ex.Message)
                    dsMain.RejectChanges()

                End Try
            Else
                MsgBox("No Data to Save.")
            End If

        End If

    End Sub

    Public Sub UpdateBudget(ByVal dsChanges As DataSet)

        Dim cmdIns As SqlCommand
        Dim cmdUpd As SqlCommand

        Dim da As SqlDataAdapter

        'insert
        cmdIns = New SqlCommand()
        cmdIns.Connection = cn
        cmdIns.CommandType = CommandType.StoredProcedure
        cmdIns.CommandText = "cspBudgetInsert"

        

        cmdIns.Parameters.Add("@BudID", SqlDbType.Int, 4, "BudID")

        Dim paraCh3 As SqlParameter = New SqlParameter("@CustomerID", SqlDbType.Int, 4)
        paraCh3.Value = CmbCust.SelectedValue
        cmdIns.Parameters.Add(paraCh3)

        'cmdIns.Parameters.Add("@CustomerID", SqlDbType.Int, 4, "CustomerID")

        cmdIns.Parameters.Add("@IdentYear", SqlDbType.Int, 4, "IdentYear")
        cmdIns.Parameters.Add("@Month01", SqlDbType.Money, 8, "Month01")
        cmdIns.Parameters.Add("@Month02", SqlDbType.Money, 8, "Month02")
        cmdIns.Parameters.Add("@Month03", SqlDbType.Money, 8, "Month03")
        cmdIns.Parameters.Add("@Month04", SqlDbType.Money, 8, "Month04")
        cmdIns.Parameters.Add("@Month05", SqlDbType.Money, 8, "Month05")
        cmdIns.Parameters.Add("@Month06", SqlDbType.Money, 8, "Month06")
        cmdIns.Parameters.Add("@Month07", SqlDbType.Money, 8, "Month07")
        cmdIns.Parameters.Add("@Month08", SqlDbType.Money, 8, "Month08")
        cmdIns.Parameters.Add("@Month09", SqlDbType.Money, 8, "Month09")
        cmdIns.Parameters.Add("@Month10", SqlDbType.Money, 8, "Month10")
        cmdIns.Parameters.Add("@Month11", SqlDbType.Money, 8, "Month11")
        cmdIns.Parameters.Add("@Month12", SqlDbType.Money, 8, "Month12")

        'update
        cmdUpd = New SqlCommand()
        cmdUpd.Connection = cn
        cmdUpd.CommandType = CommandType.StoredProcedure
        cmdUpd.CommandText = "cspBudgetUpdate"

        cmdUpd.Parameters.Add("@BudID", SqlDbType.Int, 4, "BudID")
        cmdUpd.Parameters.Add("@IdentYear", SqlDbType.Int, 4, "IdentYear")
        cmdUpd.Parameters.Add("@Month01", SqlDbType.Money, 8, "Month01")
        cmdUpd.Parameters.Add("@Month02", SqlDbType.Money, 8, "Month02")
        cmdUpd.Parameters.Add("@Month03", SqlDbType.Money, 8, "Month03")
        cmdUpd.Parameters.Add("@Month04", SqlDbType.Money, 8, "Month04")
        cmdUpd.Parameters.Add("@Month05", SqlDbType.Money, 8, "Month05")
        cmdUpd.Parameters.Add("@Month06", SqlDbType.Money, 8, "Month06")
        cmdUpd.Parameters.Add("@Month07", SqlDbType.Money, 8, "Month07")
        cmdUpd.Parameters.Add("@Month08", SqlDbType.Money, 8, "Month08")
        cmdUpd.Parameters.Add("@Month09", SqlDbType.Money, 8, "Month09")
        cmdUpd.Parameters.Add("@Month10", SqlDbType.Money, 8, "Month10")
        cmdUpd.Parameters.Add("@Month11", SqlDbType.Money, 8, "Month11")
        cmdUpd.Parameters.Add("@Month12", SqlDbType.Money, 8, "Month12")

        'DataApapter
        da = New SqlDataAdapter()

        da.InsertCommand = cmdIns
        da.UpdateCommand = cmdUpd

        da.TableMappings.Add("Table", "tblCustBudget")

        da.Update(dsChanges)

    End Sub

    Private Sub CmbCust_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.DropDownClosed
        dsMain.Clear()

        Dim strSearch As Integer
        strSearch = CmbCust.SelectedValue

        CallClass.PopulateAdapterAfterSearchInt("getCustBudgetByCustID", strSearch).Fill(dsMain, "tblCustBudget")

        dgBudget.AutoGenerateColumns = False
        dgBudget.DataSource = dsMain
        dgBudget.DataMember = "tblCustBudget"

        dgBudget.Visible = True

        CmbCust.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        Call SetupForm()

    End Sub

    Private Sub dgBudget_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBudget.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        CalculValue()
    End Sub

    Private Sub dgBudget_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBudget.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        CalculValue()
    End Sub

    Private Sub dgBudget_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBudget.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        CalculValue()
    End Sub

    Private Sub dgBudget_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgBudget.DataError
        REM end
    End Sub

    Sub CalculValue()

        'Dim MpoVal As Double = 0.0

        'For Each Row As DataGridViewRow In dgMpo.Rows
        '    MpoVal = Nz.Nz(Row.Cells("QtyActual").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value)
        '    Row.Cells("MpoValue").Value = MpoVal
        'Next

        'dgCerts.Rows(e.RowIndex).Cells("OrdCertsItem").Value = dgItem.Rows(ItemRow).Cells("OrdItemNo").Value

        For Each Row As DataGridViewRow In dgBudget.Rows
            Dim II As Integer
            Dim SS As String
            Dim BudVal As Double = 0.0
            For II = 1 To 12
                SS = Format(II, "00")
                BudVal = BudVal + Nz.Nz(Row.Cells("Month" + SS).Value)
            Next
            Row.Cells("Total").Value = BudVal
        Next
    End Sub

End Class