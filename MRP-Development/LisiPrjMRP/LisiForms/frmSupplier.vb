Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.UTF32Encoding

Public Class frmSupplier
    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim SuppCurrency As CurrencyManager
    Dim ContactCurrency As CurrencyManager

    Private daSuppliers As New SqlDataAdapter
    Private daContacts As New SqlDataAdapter

    Dim cmdGetIdentity As New SqlCommand

    Dim CallClass As New clsCommon

    Dim ID As Integer
    Dim strSQL As String
    Dim WhatAction As Integer
    Dim SwVal As Boolean

    Private Sub frmSupplier_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        SuppCurrency.EndCurrentEdit()
        ContactCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            Dim reply As DialogResult
            reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                dsMain.Dispose()
                daSuppliers.Dispose()
                daContacts.Dispose()
                Me.Dispose()
                cn.Close()
            End If
        Else
            dsMain.Dispose()
            daSuppliers.Dispose()
            daContacts.Dispose()
            Me.Dispose()
            cn.Close()
        End If

        GC.Collect()
    End Sub

    Private Sub frmSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GC.Collect()

        WhatAction = 0
        WhatAction = Val(InStr(1, wkDeptCode, "SUPP", vbTextCompare))

        SwForm.Visible = False

        DisableFields()

        With Me.CmbGroup
            .DataSource = CallClass.PopulateComboBox("tblSupplierGroup", "cmbGetSupplierGroup").Tables("tblSupplierGroup")
            .DisplayMember = "FullDescr"
            .ValueMember = "SuppGrID"
        End With


        BuildSqlCommand()
        InitialComponents()
        SetDataCtl()

        CmbSupp.DataSource = dsMain.Tables("tblSupplier")
        CmbSupp.ValueMember = "SupplierID"
        CmbSupp.DisplayMember = "SuppName"

        dgContact.AutoGenerateColumns = False
        dgContact.DataSource = dsMain
        dgContact.DataMember = "tblSupplier.RelSuppContact"

        If Val(SwForm.Text) > 0 Then
            CmbSupp.SelectedValue = SwForm.Text
        End If

        SwForm.Text = ""

        BindFields()

        If WhatAction = 0 Then      'readonly
            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdDelete.Enabled = False

            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        Else
            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdDelete.Enabled = False ''''''''''

            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        End If

        CmbSupp.Enabled = True

        txtSuppID.Visible = False

        If RoleSupp(wkDeptCode) = True Then
            PlMainGroup.Visible = True
        Else
            PlMainGroup.Visible = True
            PlMainGroup.Enabled = False
            txtNotes.Enabled = False
            txtStandCalif.Enabled = False
        End If

        txtSuppID.Visible = False

        If RoleM3Supp(wkDeptCode) = True Then
            PLM3Code.Visible = True
        Else
            PLM3Code.Visible = False
        End If

    End Sub

        Sub InitialComponents

        dsMain.Clear()
        dsMain.Relations.Clear()

        daSuppliers.FillSchema(dsMain, SchemaType.Source, "tblSupplier")
        daContacts.FillSchema(dsMain, SchemaType.Source, "tblSuppContact")

        daSuppliers.Fill(dsMain, "tblSupplier")
        Dim SupID As DataColumn = dsMain.Tables("tblSupplier").Columns("SupplierID")
        SupID.AutoIncrement = True
        SupID.AutoIncrementStep = -1
        SupID.AutoIncrementSeed = -1
        SupID.ReadOnly = False

        daContacts.Fill(dsMain, "tblSuppContact")
        Dim ContID As DataColumn = dsMain.Tables("tblSuppContact").Columns("SuppContactID")
        ContID.AutoIncrement = True
        ContID.AutoIncrementStep = -1
        ContID.AutoIncrementSeed = -1
        ContID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("RelSuppContact", _
                .Tables("tblSupplier").Columns("SupplierID"), _
                .Tables("tblSuppContact").Columns("SupplierID"), True)
        End With

        SuppCurrency = CType(BindingContext(dsMain, "tblSupplier"), CurrencyManager)
        ContactCurrency = CType(BindingContext(dsMain, "tblSuppContact"), CurrencyManager)

    End Sub

    Sub SetDataCtl()

        With Me.SuppContactID
            .DataPropertyName = "SuppContactID"
            .Name = "SuppContactID"
            .Visible = False
        End With

        With Me.SupplierID
            .DataPropertyName = "SupplierID"
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

        If CmbSupp.SelectedIndex = -1 Then
            MsgBox("Please select the Supplier before editing.")
        Else
            Call EnableFields()

            CmdNew.Enabled = False
            CmdMod.Enabled = False
            CmdDelete.Enabled = False

            CmdSave.Enabled = True
            CmdCancel.Enabled = True

            CmbSupp.Enabled = False
        End If
        
    End Sub

    Sub EnableFields()
        CmbSupp.Enabled = True

        txtSuppName.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtRegion.ReadOnly = False
        txtPostalCode.ReadOnly = False
        cmbCountry.Enabled = True
        txtWeb.ReadOnly = False
        txtNotes.ReadOnly = False
        txtStandCalif.ReadOnly = False
        txtRating.ReadOnly = False
        CmbSuppType.Enabled = True
        CmbSuppExpDate.Enabled = True
        CmbSuppStatus.Enabled = True
        txtLeadTime.ReadOnly = False
        txtUpdateDate.ReadOnly = False


        dgContact.ReadOnly = False

        ChkMill.Enabled = True
        ChkRedraw.Enabled = True
        ChkDistr.Enabled = True

        Rd12.Enabled = True
        Rd18.Enabled = True
        Rd36.Enabled = True
        CmbAuditBy.Enabled = True
        CmbGroup.Enabled = True

    End Sub

    Sub DisableFields()
        CmbSupp.Enabled = True
        txtSuppName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtRegion.ReadOnly = True
        txtPostalCode.ReadOnly = True
        cmbCountry.Enabled = False
        txtWeb.ReadOnly = True
        txtNotes.ReadOnly = True
        txtStandCalif.ReadOnly = True
        txtRating.ReadOnly = True
        CmbSuppType.Enabled = False
        txtLeadTime.ReadOnly = True
        txtUpdateDate.ReadOnly = True

        dgContact.ReadOnly = True
        CmbSuppExpDate.Enabled = False
        CmbSuppStatus.Enabled = False

        txtSuppName.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtRegion.Text = ""
        txtPostalCode.Text = ""
        cmbCountry.Text = ""
        txtWeb.Text = ""
        txtNotes.Text = ""
        txtStandCalif.Text = ""
        txtRating.Text = ""
        CmbSuppType.Text = ""
        CmbSuppExpDate.Text = Now.ToShortDateString
        CmbSuppStatus.Text = ""
        txtLeadTime.Text = ""

        ChkMill.Checked = False
        ChkRedraw.Checked = False
        ChkDistr.Checked = False

        ChkMill.Enabled = False
        ChkRedraw.Enabled = False
        ChkDistr.Enabled = False

        Rd12.Checked = False
        Rd18.Checked = False
        Rd36.Checked = False

        Rd12.Enabled = False
        Rd18.Enabled = False
        Rd36.Enabled = False
        CmbAuditBy.Enabled = False
        CmbGroup.Enabled = False

    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        DoReset()
    End Sub

    Sub DoReset()

        GC.Collect()
        SuppCurrency.EndCurrentEdit()
        ContactCurrency.EndCurrentEdit()

        If WhatAction = 0 Then          'readonly
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
        dsMain.RejectChanges()

        CmbSupp.Enabled = True
        'CmbSupp.SelectedIndex = -1

        dgContact.Refresh()

        InitialComponents()
        dgContact.AutoGenerateColumns = False
        dgContact.DataSource = dsMain
        dgContact.DataMember = "tblSupplier.RelSuppContact"

        BindFields()

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        CmdNew.Enabled = False
        CmdMod.Enabled = False
        CmdDelete.Enabled = False

        CmdSave.Enabled = True
        CmdCancel.Enabled = True

        CmbSupp.Enabled = False

        'Me.BindingContext(dsMain, "tblSupplier").EndCurrentEdit()
        'Me.BindingContext(dsMain, "tblSupplier").AddNew()

        SuppCurrency.EndCurrentEdit()
        SuppCurrency.AddNew()

        cmbCountry.SelectedIndex = 1
        CmbSuppType.SelectedIndex = 4
        CmbSuppStatus.Text = ""
        CmbSuppStatus.SelectedText = "Approved"
        CmbSuppType.Text = "Other"

        CmbSuppExpDate.Text = ""

        CmbSuppDate.Text = Now.ToShortDateString

        Call EnableFields()
        CmbSupp.Enabled = False

        Rd12.Checked = True
        Rd18.Checked = True
        Rd36.Checked = True
        CmbGroup.SelectedValue = 11     'other
        CmbSuppStatus.Text = "Approved"

    End Sub

    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click

        Dim Rep As String
        If SuppCurrency.Count > 0 Then
            Rep = MsgBox("Delete this record : ", MsgBoxStyle.YesNo, "Update")
            If Rep = Windows.Forms.DialogResult.Yes Then
                SuppCurrency.RemoveAt(SuppCurrency.Position)
                CmdSave.Enabled = True
            End If
        Else
            MsgBox("Nothing to Delete. Action Cancelled.")
            CmdSave.Enabled = False
        End If

        CmdCancel.Enabled = True
        CmdDelete.Enabled = False
        CmbSupp.Enabled = True
        CmdNew.Enabled = False
        CmdMod.Enabled = False
        Call DisableFields()

    End Sub

    Sub BindFields()

        ChkMill.Checked = False
        ChkRedraw.Checked = False
        ChkDistr.Checked = False

        Rd12.Checked = False
        Rd18.Checked = False
        Rd36.Checked = False

        txtSuppID.DataBindings.Clear()
        txtSuppName.DataBindings.Clear()
        txtAddress.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtRegion.DataBindings.Clear()
        txtPostalCode.DataBindings.Clear()
        txtWeb.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtStandCalif.DataBindings.Clear()
        txtRating.DataBindings.Clear()
        txtLeadTime.DataBindings.Clear()
        txtUpdateDate.DataBindings.Clear()
        txtSuppM3Code.DataBindings.Clear()


        cmbCountry.DataBindings.Clear()
        CmbSuppType.DataBindings.Clear()
        CmbSuppExpDate.DataBindings.Clear()
        CmbSuppDate.DataBindings.Clear()
        CmbSuppStatus.DataBindings.Clear()
        CmbGroup.DataBindings.Clear()

        ChkMill.DataBindings.Clear()
        ChkRedraw.DataBindings.Clear()
        ChkDistr.DataBindings.Clear()

        Rd12.DataBindings.Clear()
        Rd18.DataBindings.Clear()
        Rd36.DataBindings.Clear()
        CmbAuditBy.DataBindings.Clear()

        '==============================
        'CmbSupp.DataBindings.Clear()
        '==============================

        txtSuppM3Code.DataBindings.Add("Text", dsMain, "tblSupplier.M3SuppCode")

        txtSuppID.DataBindings.Add("Text", dsMain, "tblSupplier.SupplierID")
        txtSuppName.DataBindings.Add("Text", dsMain, "tblSupplier.SuppName")
        txtAddress.DataBindings.Add("Text", dsMain, "tblSupplier.SuppAddress")
        txtCity.DataBindings.Add("Text", dsMain, "tblSupplier.SuppCity")
        txtRegion.DataBindings.Add("Text", dsMain, "tblSupplier.SuppRegion")
        txtPostalCode.DataBindings.Add("Text", dsMain, "tblSupplier.SuppPostalCode")
        cmbCountry.DataBindings.Add("Text", dsMain, "tblSupplier.SuppCountry")
        txtWeb.DataBindings.Add("Text", dsMain, "tblSupplier.SuppWebAddress")
        txtNotes.DataBindings.Add("Text", dsMain, "tblSupplier.SuppNotes")
        txtStandCalif.DataBindings.Add("Text", dsMain, "tblSupplier.SuppCalifSpec")
        txtRating.DataBindings.Add("Text", dsMain, "tblSupplier.SuppRating")
        txtLeadTime.DataBindings.Add("Text", dsMain, "tblSupplier.SuppLeadTime")
        txtUpdateDate.DataBindings.Add("Text", dsMain, "tblSupplier.UpdateDatesNotes")

        CmbSuppType.DataBindings.Add("Text", dsMain, "tblSupplier.SuppType")

        CmbGroup.DataBindings.Add("SelectedValue", dsMain, "tblSupplier.SuppGroupID")

        CmbSuppExpDate.DataBindings.Add("Text", dsMain, "tblSupplier.SuppExpDate", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")
        CmbSuppDate.DataBindings.Add("Text", dsMain, "tblSupplier.SuppDate", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")
        CmbSuppStatus.DataBindings.Add("Text", dsMain, "tblSupplier.SuppStatus", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")

        If IsDBNull(CmbSuppExpDate.Text) = True Then
            CmbSuppExpDate.Text = ""
        End If

        If IsDBNull(CmbSuppDate.Text) = True Then
            CmbSuppDate.Text = ""
        End If

        If IsDBNull(CmbSuppStatus.Text) = True Then
            CmbSuppStatus.Text = ""
        End If

        ChkMill.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.CatMill", True))
        ChkRedraw.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.CatRedraw", True))
        ChkDistr.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.CatDistr", True))

        Rd12.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.Freq12", True))
        Rd18.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.Freq18", True))
        Rd36.DataBindings.Add(New Binding("Checked", dsMain, "tblSupplier.Freq36", True))
        CmbAuditBy.DataBindings.Add("Text", dsMain, "tblSupplier.AuditBy", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daSuppliers = CallClass.PopulateDataAdapter("gettblSuppliers")
            daContacts = CallClass.PopulateDataAdapter("gettbSuppContact")

            Dim cmdSuppBuilder As New SqlClient.SqlCommandBuilder(daSuppliers)
            Dim cmdContactBuilder As New SqlClient.SqlCommandBuilder(daContacts)

            daSuppliers.UpdateCommand = cmdSuppBuilder.GetUpdateCommand
            daSuppliers.UpdateCommand.Connection = cn
            daSuppliers.InsertCommand = cmdSuppBuilder.GetInsertCommand
            AddHandler daSuppliers.RowUpdated, AddressOf HandleRowUpdatedCustomer
            daSuppliers.InsertCommand.Connection = cn
            daSuppliers.DeleteCommand = cmdSuppBuilder.GetDeleteCommand
            daSuppliers.DeleteCommand.Connection = cn
            daSuppliers.AcceptChangesDuringFill = True
            daSuppliers.TableMappings.Add("Table", "tblSupplier")
            daSuppliers.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daContacts.UpdateCommand = cmdContactBuilder.GetUpdateCommand
            daContacts.UpdateCommand.Connection = cn
            daContacts.InsertCommand = cmdContactBuilder.GetInsertCommand
            AddHandler daContacts.RowUpdated, AddressOf HandleRowUpdatedContact
            daContacts.InsertCommand.Connection = cn
            daContacts.DeleteCommand = cmdContactBuilder.GetDeleteCommand
            daContacts.DeleteCommand.Connection = cn
            daContacts.AcceptChangesDuringFill = True
            daContacts.TableMappings.Add("Table", "tblSuppContact")
            daContacts.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function


    Private Sub HandleRowUpdatedContact(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblSuppContact").Columns("SuppContactID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedCustomer(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblSupplier").Columns("SupplierID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
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

        Me.Refresh()
        CmbSuppStatus.Focus()
        CmdSave.Focus()
        CmbSuppExpDate.Focus()
        CmdSave.Focus()

        txtSuppName.Focus()
        dgContact.Focus()
        txtSuppName.Focus()


        dgContact.Refresh()

        SuppCurrency.EndCurrentEdit()
        ContactCurrency.EndCurrentEdit()

        Call ValPo()

        If SwVal = True Then
            Try
                If dsMain.HasChanges = True Then
                    dsMain.GetChanges()
                    daSuppliers.Update(dsMain.Tables("tblSupplier").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daContacts.Update(dsMain.Tables("tblSuppContact").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daSuppliers.Update(dsMain.Tables("tblSupplier").Select("", "", DataViewRowState.Deleted))
                    dsMain.AcceptChanges()
                End If

            Catch ex As Exception
                MsgBox("Exception occured - " & ex.Message)
            Finally
            End Try

            CmdNew.Enabled = True
            CmdMod.Enabled = True
            CmdDelete.Enabled = False ''''''''''''''''
            CmdCancel.Enabled = False
            CmdSave.Enabled = False

            DoReset()

        End If


    End Sub

    Sub ValPo()

        If ChkMill.CheckState = CheckState.Unchecked Then
            ChkMill.Checked = False
        End If

        If ChkRedraw.CheckState = CheckState.Unchecked Then
            ChkRedraw.Checked = False
        End If

        If ChkDistr.CheckState = CheckState.Unchecked Then
            ChkDistr.Checked = False
        End If

        If IsDBNull(txtSuppName.Text) = True Or IsNothing(txtSuppName.Text) = True Or Len(Trim(txtSuppName.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Supplier Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(txtAddress.Text) = True Or IsNothing(txtAddress.Text) = True Or Len(Trim(txtAddress.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Supplier Address is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(txtCity.Text) = True Or IsNothing(txtAddress.Text) = True Or Len(Trim(txtAddress.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Supplier City is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(cmbCountry.Text) = True Or IsNothing(cmbCountry.Text) = True Or Len(Trim(cmbCountry.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Supplier Country is Empty.")
            SwVal = False
            Exit Sub
        End If


        If CmbGroup.SelectedItem("SuppGrNo") = 1 Or CmbGroup.SelectedItem("SuppGrNo") = 2 Or CmbGroup.SelectedItem("SuppGrNo") = 3 Then
            If IsDBNull(CmbAuditBy.Text) = True Or IsNothing(CmbAuditBy.Text) = True Or Len(Trim(CmbAuditBy.Text)) = 0 Then
                MsgBox("!!! ERROR !!! Audit By is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Rd12.Checked = False And Rd18.Checked = False And Rd36.Checked = False Then
            MsgBox("!!! ERROR !!! Audit Frequency is Empty.")
            SwVal = False
            Exit Sub
        End If

        'If CmbGroup.SelectedItem("SuppGrNo") = 1 Or CmbGroup.SelectedItem("SuppGrNo") = 2 Or CmbGroup.SelectedItem("SuppGrNo") = 3 Then
        '    If Val(InStr(1, CmbSuppStatus.Text, "Approved", vbTextCompare)) = 0 Then
        '        MsgBox("!!! ERROR !!! Supplier Status for the Group 1/2/3")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'End If

        If CmbGroup.SelectedItem("SuppGrNo") = 1 Then
            If ChkDistr.Checked = False And ChkRedraw.Checked = False And ChkMill.Checked = False Then
                MsgBox("!!! ERROR !!! For Group 1 Approved Material Source should be selected.")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbGroup.SelectedItem("SuppGrNo") = 4 Then
            If Val(InStr(1, CmbSuppStatus.Text, "Approved", vbTextCompare)) = 0 Then
                MsgBox("!!! ERROR !!! Supplier Status for the Group 4")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbGroup.SelectedItem("SuppGrNo") = 1 Or CmbGroup.SelectedItem("SuppGrNo") = 2 Or CmbGroup.SelectedItem("SuppGrNo") = 3 Then

            Dim FirstDate As DateTime = CmbSuppExpDate.Text
            Dim SecondDate As DateTime = Now()
            Dim result As Int16 = DateTime.Compare(FirstDate, SecondDate)

            If (result < 0) Then
                MsgBox("!!! ERROR !!! Next Aproval Due Date is less as the  Current System date - Audit is required.")
                SwVal = False
                Exit Sub
            End If

        End If

        SwVal = True

    End Sub

    Private Sub CmbSupp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSupp.SelectedIndexChanged

        Me.BindingContext(dsMain, "tblSupplier").Position = CType(CmbSupp.SelectedIndex, String)

        BindFields()

        dgContact.EndEdit()

        Me.txtSuppName.Focus()

        If WhatAction = 0 Then          'readonly
            CmdMod.Enabled = False
            CmdNew.Enabled = False

            CmdDelete.Enabled = False
            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        Else
            CmdMod.Enabled = True
            CmdNew.Enabled = True

            CmdDelete.Enabled = False '''''''''''''
            CmdSave.Enabled = False
            CmdCancel.Enabled = True
        End If

    End Sub

    Private Sub CmbSuppStatus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        If CmbSuppStatus.Text = "Not Audited" Then
            CmbGroup.SelectedValue = 11
        End If

    End Sub

    Private Sub CmbGroup_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If CmbGroup.SelectedValue = 11 Then
            CmbSuppStatus.Text = "Not Audited"
        End If
    End Sub

    Function RoleSupp(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MAINTSUPP" Then
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

    Function RoleM3Supp(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SUPPM3" Then
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

    Private Sub CmdLocate_Click(sender As Object, e As EventArgs) Handles CmdLocate.Click

        Dim SwPath As String = ""

        SwPath = "\\Srv115fs01\Quality\7 - PRODUCT REALIZATION\SUPPLIER COMMUNICATION\ASL GR1 CORP"

        Try
            Process.Start(SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        'D:\Quality\7 - PRODUCT REALIZATION\SUPPLIER COMMUNICATION\ASL GR1 CORP





        '        'ps is the Crystal Report instance  

        '2:      ps.SetDataSource(DT)


        '4:      Dim repName As String = path & "\" & rdr("UserID") & ".pdf"

        '6:      ps.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, repName)

        '7:      ps.Close()

        '10:     Dim SM As New SendMail

        '11:     'SendMail is a separate class to handle the sending of the email  

        '13:     SM.To = "email@Address.com"

        '14:     'You can also get the email address from the DataReader if preferred.  

        '16:     'add the saved report as an attachment to the email.  

        '17:     SM.Attachment.Add(repName)

        '19:     SM.SendMail()

        '21:     File.Delete(repName)

        '22:     'i don't use this line as I need to keep the files for records. 

    End Sub


End Class