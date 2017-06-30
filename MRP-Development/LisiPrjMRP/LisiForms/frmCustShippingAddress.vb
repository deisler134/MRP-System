Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCustShippingAddress

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim InvCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean

    Private Sub frmCustInvoiceAddress_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        InvCurrency.EndCurrentEdit()

        If ds.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        ds.RejectChanges()
        da.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmCustInvoiceAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisableFields()
        FirstTimeMenuButtons()
        BuildSqlCommand()
        InitialComponents()
        BindComponents()

        CmbCust.DataSource = ds.Tables("tblCustShip")
        CmbCust.DisplayMember = "FullShipName"
        CmbCust.ValueMember = "CustShipID"
        CmbCust.Enabled = True

    End Sub

    Sub DisableFields()
        CmbCust.Enabled = False
        cmbCountry.Enabled = False

        txtShortName.ReadOnly = True
        txtCustName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtStateProv.ReadOnly = True
        txtPostalCode.ReadOnly = True
        txtRefCode.ReadOnly = True
        txtInvFOB.ReadOnly = True
        txtConsignee.ReadOnly = True
    End Sub

    Sub EnableFields()
        cmbCountry.Enabled = True

        txtShortName.ReadOnly = False
        txtCustName.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtStateProv.ReadOnly = False
        txtPostalCode.ReadOnly = False
        txtRefCode.ReadOnly = False
        txtInvFOB.ReadOnly = False
        txtConsignee.ReadOnly = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdNew.Enabled = True
        CmdReset.Enabled = True
        CmdMod.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            da = CallClass.PopulateDataAdapter("gettblCustShip")

            Dim InvBuilder As New SqlClient.SqlCommandBuilder(da)

            da.UpdateCommand = InvBuilder.GetUpdateCommand
            da.UpdateCommand.Connection = cn
            da.InsertCommand = InvBuilder.GetInsertCommand
            AddHandler da.RowUpdated, AddressOf HandleRowUpdatedShip
            da.InsertCommand.Connection = cn
            da.DeleteCommand = InvBuilder.GetDeleteCommand
            da.DeleteCommand.Connection = cn
            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblCustShip")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        ds.Clear()
        ds.Relations.Clear()

        da.FillSchema(ds, SchemaType.Source, "tblCustShip")

        da.Fill(ds, "tblCustShip")
        Dim InvID As DataColumn = ds.Tables("tblCustShip").Columns("CustShipID")
        InvID.AutoIncrement = True
        InvID.AutoIncrementStep = -1
        InvID.AutoIncrementSeed = -1
        InvID.ReadOnly = False

        ds.EnforceConstraints = False

        InvCurrency = CType(BindingContext(ds, "tblCustShip"), CurrencyManager)

    End Sub

    Private Sub HandleRowUpdatedShip(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblCustShip").Columns("CustShipID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub BindComponents()

        txtShortName.DataBindings.Clear()
        txtCustName.DataBindings.Clear()
        txtAddress.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtStateProv.DataBindings.Clear()
        txtPostalCode.DataBindings.Clear()
        txtRefCode.DataBindings.Clear()
        txtInvFOB.DataBindings.Clear()
        txtConsignee.DataBindings.Clear()

        CmbCust.DataBindings.Clear()
        cmbCountry.DataBindings.Clear()

        txtShortName.DataBindings.Add("Text", ds, "tblCustShip.ShipShortName")
        txtCustName.DataBindings.Add("Text", ds, "tblCustShip.ShipName")
        txtAddress.DataBindings.Add("Text", ds, "tblCustShip.ShipAddress")
        txtCity.DataBindings.Add("Text", ds, "tblCustShip.ShipCity")
        txtStateProv.DataBindings.Add("Text", ds, "tblCustShip.ShipProv")
        txtPostalCode.DataBindings.Add("Text", ds, "tblCustShip.ShipPostalCode")
        txtRefCode.DataBindings.Add("Text", ds, "tblCustShip.ShipCode")
        txtInvFOB.DataBindings.Add("Text", ds, "tblCustShip.ShipFob")
        txtConsignee.DataBindings.Add("Text", ds, "tblCustShip.ShipConsignee")

        cmbCountry.DataBindings.Add("Text", ds, "tblCustShip.ShipCountry", True, DataSourceUpdateMode.OnValidation, "", "USA")
    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbCust.Enabled = False

        ds.RejectChanges()

        InvCurrency.EndCurrentEdit()
        InvCurrency.AddNew()

        EnableFields()

        txtInvFOB.Text = "Dorval"
        cmbCountry.Text = "USA"
        txtShortName.Focus()

    End Sub

    Private Sub CmdMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMod.Click
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbCust.Enabled = False

        EnableFields()
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click
        ds.RejectChanges()
        DisableFields()
        FirstTimeMenuButtons()

        CmbCust.Enabled = True
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then
            DisableFields()

            InvCurrency.EndCurrentEdit()

            Try
                If ds.HasChanges Then
                    ds.GetChanges()
                    da.Update(ds.Tables("tblCustShip").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                End If
            Catch ex As Exception
                ds.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            BindComponents()

        End If
    End Sub

    Sub ValPO()

        If Len(Trim(txtShortName.Text)) = 0 Or IsDBNull(txtShortName.Text) = True Or IsNothing(txtShortName.Text) = True Then
            MsgBox("!!! ERROR !!! Short Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtCustName.Text)) = 0 Or IsDBNull(txtCustName.Text) = True Or IsNothing(txtCustName.Text) = True Then
            MsgBox("!!! ERROR !!! Customer Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtAddress.Text)) = 0 Or IsDBNull(txtAddress.Text) = True Or IsNothing(txtAddress.Text) = True Then
            MsgBox("!!! ERROR !!! Billing Address is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtCity.Text)) = 0 Or IsDBNull(txtCity.Text) = True Or IsNothing(txtCity.Text) = True Then
            MsgBox("!!! ERROR !!! City is Empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub CmbCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCust.SelectedIndexChanged
        Me.BindingContext(ds, "tblCustShip").Position = CType(CmbCust.SelectedIndex, String)
        Me.txtShortName.Focus()
    End Sub

End Class