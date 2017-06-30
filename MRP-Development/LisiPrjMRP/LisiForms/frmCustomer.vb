Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmCustomer
    Inherits System.Windows.Forms.Form


    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim cmCust As CurrencyManager
    Dim cmCont As CurrencyManager

    Private daCustomers As New SqlDataAdapter
    Private daContacts As New SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim ID As Integer

    Dim strSQL As String
    Dim WhatAction As Integer

    Private Sub frmCustomer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
       
        Dim reply As DialogResult

        cmCust.EndCurrentEdit()
        cmCont.EndCurrentEdit()

        If dsMain.HasChanges Then

            reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daCustomers.Dispose()
        daContacts.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmCustomers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If


        WhatAction = 0
        WhatAction = Val(InStr(1, wkDeptCode, "CUST", vbTextCompare))
        SwForm.Text = ""

        Call DisableFields()
        BuildSqlCommand()
        InitialComponents()
        SetCtlForm()

        BindFields()

        If WhatAction = 0 Then      'readonly
            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdDelete.Enabled = False

            CmdSave.Enabled = False
            CmdCancel.Enabled = True
            CmbCust.Enabled = True
        Else
            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdDelete.Enabled = False ''''''''''

            CmdSave.Enabled = False
            CmdCancel.Enabled = True
            CmbCust.Enabled = True
        End If

        txtCustID.Visible = False

        dgContact.AutoGenerateColumns = False
        dgContact.DataSource = dsMain
        dgContact.DataMember = "tblCustomers.CustContact"

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daCustomers.FillSchema(dsMain, SchemaType.Source, "tblCustomers")
        daContacts.FillSchema(dsMain, SchemaType.Source, "tblCustContact")

        daCustomers.Fill(dsMain, "tblCustomers")
        Dim CustID As DataColumn = dsMain.Tables("tblCustomers").Columns("CustomerID")
        CustID.AutoIncrement = True
        CustID.AutoIncrementStep = -1
        CustID.AutoIncrementSeed = -1
        CustID.ReadOnly = False


        daContacts.Fill(dsMain, "tblCustContact")
        Dim ContID As DataColumn = dsMain.Tables("tblCustContact").Columns("ContactID")
        ContID.AutoIncrement = True
        ContID.AutoIncrementStep = -1
        ContID.AutoIncrementSeed = -1
        ContID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("CustContact", _
                .Tables("tblCustomers").Columns("CustomerID"), _
                .Tables("tblCustContact").Columns("CustomerID"), True)
        End With

        cmCust = CType(BindingContext(dsMain, "tblCustomers"), CurrencyManager)
        cmCont = CType(BindingContext(dsMain, "tblCustContact"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        CmbCust.DataSource = dsMain.Tables("tblCustomers")
        CmbCust.DisplayMember = "CustomerName"
        CmbCust.ValueMember = "CustomerID"

        If Len(Trim(SwForm.Text)) = 0 Then
            If CmbCust.SelectedIndex >= 1 Then
                CmbCust.SelectedIndex = 1
            End If
        Else
            CmbCust.SelectedIndex = SwForm.Text
        End If

        'for dgContacts  --   Certs Info

        With Me.ContactID
            .DataPropertyName = "ContactID"
            .Name = "ContactID"
            .Visible = False
        End With

        With Me.CustomerID
            .DataPropertyName = "CustomerID"
            .Name = "CustomerID"
            .Visible = False
        End With

        With Me.ContactTitle
            .DataPropertyName = "ContactTitle"
            .Name = "ContactTitle"
        End With

        With Me.ContactName
            .DataPropertyName = "ContactName"
            .Name = "ContactName"
        End With

        With Me.Phone
            .DataPropertyName = "Phone"
            .Name = "Phone"
        End With

        With Me.Post
            .DataPropertyName = "Post"
            .Name = "Post"
        End With

        With Me.Fax
            .DataPropertyName = "Fax"
            .Name = "Fax"
        End With

        With Me.Email
            .DataPropertyName = "Email"
            .Name = "Email"
        End With

    End Sub

    Private Sub CmdMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMod.Click

        Call EnableFields()

        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdDelete.Enabled = False

        CmdSave.Enabled = True
        CmdCancel.Enabled = True

        CmbCust.Enabled = False

    End Sub

    Sub EnableFields()
        CmbCust.Enabled = True

        txtCustName.ReadOnly = False
        txtPer.ReadOnly = False
        txtCustShort.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtRegion.ReadOnly = False
        txtPostalCode.ReadOnly = False
        txtM3CustCode.ReadOnly = False
        cmbCountry.Enabled = True
        txtWeb.ReadOnly = False
        txtNotes.ReadOnly = False
        txtShipVia.ReadOnly = False

        CmbCreditInfo.Enabled = True

        dgContact.ReadOnly = False
    End Sub

    Sub DisableFields()

        CmbCust.Enabled = True
        txtCustName.ReadOnly = True
        txtPer.ReadOnly = True
        txtCustShort.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtRegion.ReadOnly = True
        txtPostalCode.ReadOnly = True
        txtM3CustCode.ReadOnly = True
        cmbCountry.Enabled = False
        txtWeb.ReadOnly = True
        txtNotes.ReadOnly = True
        txtShipVia.ReadOnly = True

        CmbCreditInfo.Enabled = False

        dgContact.ReadOnly = True

    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        If WhatAction = 0 Then      'readonly
            CmdCancel.Enabled = True

            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdDelete.Enabled = False

            CmdSave.Enabled = False
        Else
            CmdCancel.Enabled = False

            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdDelete.Enabled = False ''''''''''

            CmdSave.Enabled = False
        End If


        Call DisableFields()

        CmbCust.Enabled = True

        Me.txtCustName.Focus()

        If CmbCust.SelectedIndex >= 1 Then
            CmbCust.SelectedIndex = 1
        End If

        Me.BindingContext(dsMain, "tblCustomers").Position = CType(CmbCust.SelectedIndex, String)
        dsMain.RejectChanges()
        dgContact.Refresh()

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdDelete.Enabled = False

        CmdSave.Enabled = True
        CmdCancel.Enabled = True

        CmbCust.Enabled = False

        Me.BindingContext(dsMain, "tblCustomers").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblCustomers").AddNew()

        cmbCountry.SelectedIndex = 3
        CmbCreditInfo.SelectedIndex = 0

        Call EnableFields()

    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click

        Dim Rep As String
        Rep = MsgBox("Delete this record : ", MsgBoxStyle.YesNo, "Update")
        If Rep = Windows.Forms.DialogResult.Yes Then
            If cmCust.Count > 0 Then
                cmCust.RemoveAt(cmCust.Position)
                CmdCancel.Enabled = True
                CmdSave.Enabled = True
                CmdDelete.Enabled = False
                CmbCust.Enabled = False
                CmdNew.Enabled = False
                CmdMod.Enabled = False
            Else
                CmdCancel.Enabled = True
                CmdSave.Enabled = False
                CmdDelete.Enabled = False
                CmbCust.Enabled = False
                CmdNew.Enabled = False
                CmdMod.Enabled = False

            End If
        End If

    End Sub

    Private Function BindFields() As Boolean

        txtCustName.DataBindings.Clear()
        txtPer.DataBindings.Clear()
        txtCustShort.DataBindings.Clear()
        txtAddress.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtRegion.DataBindings.Clear()
        txtPostalCode.DataBindings.Clear()
        txtM3CustCode.DataBindings.Clear()
        cmbCountry.DataBindings.Clear()
        txtWeb.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtShipVia.DataBindings.Clear()
        CmbCreditInfo.DataBindings.Clear()

        txtCustID.DataBindings.Add("Text", dsMain, "tblCustomers.CustomerID")
        txtCustName.DataBindings.Add("Text", dsMain, "tblCustomers.CustomerName")
        txtShipVia.DataBindings.Add("Text", dsMain, "tblCustomers.CustShipVia")
        txtPer.DataBindings.Add("Text", dsMain, "tblCustomers.SalesRepPer")
        txtCustShort.DataBindings.Add("Text", dsMain, "tblCustomers.CustomerShort")
        txtAddress.DataBindings.Add("Text", dsMain, "tblCustomers.Address")
        txtCity.DataBindings.Add("Text", dsMain, "tblCustomers.City")
        txtRegion.DataBindings.Add("Text", dsMain, "tblCustomers.Region")
        txtPostalCode.DataBindings.Add("Text", dsMain, "tblCustomers.PostalCode")
        txtM3CustCode.DataBindings.Add("Text", dsMain, "tblCustomers.CustCodeM3")
        cmbCountry.DataBindings.Add("Text", dsMain, "tblCustomers.Country")
        txtWeb.DataBindings.Add("Text", dsMain, "tblCustomers.WebAddress")
        txtNotes.DataBindings.Add("Text", dsMain, "tblCustomers.Notes")
        CmbCreditInfo.DataBindings.Add("Text", dsMain, "tblCustomers.CreditInfo")

    End Function

    Private Function BuildSqlCommand() As Boolean

        Try
            daCustomers = CallClass.PopulateDataAdapter("gettblCustomers")
            daContacts = CallClass.PopulateDataAdapter("gettblCustContact")

            Dim cmdCustBuilder As New SqlClient.SqlCommandBuilder(daCustomers)
            Dim cmdContBuilder As New SqlClient.SqlCommandBuilder(daContacts)

            daCustomers.UpdateCommand = cmdCustBuilder.GetUpdateCommand
            daCustomers.UpdateCommand.Connection = cn
            daCustomers.InsertCommand = cmdCustBuilder.GetInsertCommand
            AddHandler daCustomers.RowUpdated, AddressOf HandleRowUpdatedCustomer
            daCustomers.InsertCommand.Connection = cn
            daCustomers.DeleteCommand = cmdCustBuilder.GetDeleteCommand
            daCustomers.DeleteCommand.Connection = cn
            daCustomers.AcceptChangesDuringFill = True
            daCustomers.TableMappings.Add("Table", "tblCustomers")
            daCustomers.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daContacts.UpdateCommand = cmdContBuilder.GetUpdateCommand
            daContacts.UpdateCommand.Connection = cn
            daContacts.InsertCommand = cmdContBuilder.GetInsertCommand
            AddHandler daContacts.RowUpdated, AddressOf HandleRowUpdatedContact
            daContacts.InsertCommand.Connection = cn
            daContacts.DeleteCommand = cmdContBuilder.GetDeleteCommand
            daContacts.DeleteCommand.Connection = cn
            daContacts.AcceptChangesDuringFill = True
            daContacts.TableMappings.Add("Table", "tblCustContact")
            daContacts.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub CmbCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.SelectedIndexChanged
        If WhatAction = 0 Then      'readonly
            CmdMod.Enabled = False
            CmdNew.Enabled = False

            CmdDelete.Enabled = False
            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        Else
            CmdMod.Enabled = True
            CmdNew.Enabled = True

            CmdDelete.Enabled = False '''''''''
            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        End If


        Me.BindingContext(dsMain, "tblCustomers").Position = CType(CmbCust.SelectedIndex, String)
        Me.txtCustName.Focus()
    End Sub

    Private Sub HandleRowUpdatedContact(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustContact").Columns("ContactID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedCustomer(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCustomers").Columns("CustomerID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUndo.Click
        If TypeOf Me.ActiveControl Is TextBox Then
            Dim objControl As TextBox = Me.ActiveControl
            If objControl.SelectionLength > 0 Then
                objControl.Undo()
            End If
        End If
    End Sub

    Private Sub CmdCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCut.Click
        If TypeOf Me.ActiveControl Is TextBox Then
            Dim objControl As TextBox = Me.ActiveControl
            If objControl.SelectionLength > 0 Then
                objControl.Cut()
            End If
        End If
    End Sub

    Private Sub CmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCopy.Click
        If TypeOf Me.ActiveControl Is TextBox Then
            Dim objControl As TextBox = Me.ActiveControl
            If objControl.SelectionLength > 0 Then
                objControl.Copy()
            End If
        End If
    End Sub

    Private Sub CmdPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPaste.Click
        If TypeOf Me.ActiveControl Is TextBox Then
            Dim objControl As TextBox = Me.ActiveControl
            If objControl.SelectionLength > 0 Then
                objControl.Paste()
            End If
        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call DisableFields()

        CmdNew.Enabled = True
        CmdMod.Enabled = True
        CmdDelete.Enabled = False '''''''''
        CmdCancel.Enabled = False
        CmdSave.Enabled = False

        dgContact.Refresh()

        cmCust.EndCurrentEdit()
        cmCont.EndCurrentEdit()
       
        Try
            If dsMain.HasChanges Then
                daCustomers.Update(dsMain.Tables("tblCustomers").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                daContacts.Update(dsMain.Tables("tblCustContact").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                daCustomers.Update(dsMain.Tables("tblCustomers").Select("", "", DataViewRowState.Deleted))

                dsMain.AcceptChanges()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        End Try

        dgContact.Refresh()

        CmbCust.Enabled = True

    End Sub

End Class