Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCustInvoiceAddress

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

        CmbCust.DataSource = ds.Tables("tblCustInv")
        CmbCust.DisplayMember = "InvName"
        CmbCust.ValueMember = "CustInvId"
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
        txtTerms.ReadOnly = True
        txtAccpacCode.ReadOnly = True
        txtM3CustCode.ReadOnly = True

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
        txtTerms.ReadOnly = False
        txtAccpacCode.ReadOnly = False
        txtM3CustCode.ReadOnly = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdNew.Enabled = True
        CmdReset.Enabled = True
        CmdMod.Enabled = True
        CmdSave.Enabled = False
    End Sub

    Private Function BuildSqlCommand() As Boolean
        Try
            da = CallClass.PopulateDataAdapter("gettblCustMail")

            Dim InvBuilder As New SqlClient.SqlCommandBuilder(da)

            da.UpdateCommand = InvBuilder.GetUpdateCommand
            da.UpdateCommand.Connection = cn
            da.InsertCommand = InvBuilder.GetInsertCommand
            AddHandler da.RowUpdated, AddressOf HandleRowUpdatedInv
            da.InsertCommand.Connection = cn
            da.DeleteCommand = InvBuilder.GetDeleteCommand
            da.DeleteCommand.Connection = cn
            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblCustInv")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        ds.Clear()
        ds.Relations.Clear()

        da.FillSchema(ds, SchemaType.Source, "tblCustInv")

        da.Fill(ds, "tblCustInv")
        Dim InvID As DataColumn = ds.Tables("tblCustInv").Columns("CustInvId")
        InvID.AutoIncrement = True
        InvID.AutoIncrementStep = -1
        InvID.AutoIncrementSeed = -1
        InvID.ReadOnly = False

        ds.EnforceConstraints = False

        InvCurrency = CType(BindingContext(ds, "tblCustInv"), CurrencyManager)
       
    End Sub

    Private Sub HandleRowUpdatedInv(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(ds.Tables("tblCustInv").Columns("CustInvId")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
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
        txtTerms.DataBindings.Clear()
        txtAccpacCode.DataBindings.Clear()
        txtM3CustCode.DataBindings.Clear()


        CmbCust.DataBindings.Clear()
        cmbCountry.DataBindings.Clear()

        txtShortName.DataBindings.Add("Text", ds, "tblCustInv.InvShortName")
        txtCustName.DataBindings.Add("Text", ds, "tblCustInv.InvName")
        txtAddress.DataBindings.Add("Text", ds, "tblCustInv.InvAddress")
        txtCity.DataBindings.Add("Text", ds, "tblCustInv.InvCity")
        txtStateProv.DataBindings.Add("Text", ds, "tblCustInv.InvProv")
        txtPostalCode.DataBindings.Add("Text", ds, "tblCustInv.InvPostalCode")
        txtRefCode.DataBindings.Add("Text", ds, "tblCustInv.InvRefCode")
        txtInvFOB.DataBindings.Add("Text", ds, "tblCustInv.InvFob")
        txtConsignee.DataBindings.Add("Text", ds, "tblCustInv.InvConsignee")
        txtTerms.DataBindings.Add("Text", ds, "tblCustInv.CustInvTerms")
        txtAccpacCode.DataBindings.Add("Text", ds, "tblCustInv.InvAccpacCode")
        txtM3CustCode.DataBindings.Add("Text", ds, "tblCustInv.InvCodeM3")

        cmbCountry.DataBindings.Add("Text", ds, "tblCustInv.InvCountry", True, DataSourceUpdateMode.OnValidation, "", "USA")
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
                    da.Update(ds.Tables("tblCustInv").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
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

        If Len(Trim(txtAccpacCode.Text)) = 0 Or IsDBNull(txtAccpacCode.Text) = True Or IsNothing(txtAccpacCode.Text) = True Then
            MsgBox("!!! ERROR !!! Client Account is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtM3CustCode.Text)) = 0 Or IsDBNull(txtM3CustCode.Text) = True Or IsNothing(txtM3CustCode.Text) = True Then
            MsgBox("!!! ERROR !!! M3 Customer Code is Empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub CmbCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCust.SelectedIndexChanged
        Me.BindingContext(ds, "tblCustInv").Position = CType(CmbCust.SelectedIndex, String)
        Me.txtShortName.Focus()
    End Sub

End Class