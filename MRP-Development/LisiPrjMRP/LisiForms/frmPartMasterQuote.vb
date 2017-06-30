Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmPartMasterQuote

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daPart As New SqlDataAdapter
    Private daRev As New SqlDataAdapter

    Dim PartCurrency As CurrencyManager
    Dim RevCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim intPart As Integer
    Dim intRev As Integer

    Dim SwVal As Boolean

    Private Sub frmPartMasterQuote_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        PartCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daRev.Dispose()
        daPart.Dispose()

        Me.Dispose()

        GC.Collect()

    End Sub


    Private Sub frmPartMasterQuote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        DisableScreen()
        DisableButton()

        BuildSqlCommand()

        InitialComponents()

        BindComponents()

        SetDataCtl()

        CmdNew.Enabled = True
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True
        CmdEdit.Enabled = True

        txtPartDate.Text = Now.ToShortDateString

        CmbPartNumber.DataSource = dsMain.Tables("tblPartMaster")
        CmbPartNumber.DisplayMember = "PartNumber"
        CmbPartNumber.ValueMember = "PartID"

        If Len(Trim(SwFormQTShort.Text)) <> 0 Then
            CmbPartNumber.SelectedValue = SwFormQTShort.Text

        End If

        SwFormQTShort.Text = ""

    End Sub

    Function RoleM3Codification(ByVal rstr As String) As Boolean

        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "M3CODE" Then
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

    Private Function BuildSqlCommand() As Boolean

        Try
            daPart = CallClass.PopulateDataAdapter("getTblPartMaster")
            daRev = CallClass.PopulateDataAdapter("getTblPartRev")
            Dim PartBuilder As New SqlClient.SqlCommandBuilder(daPart)
            Dim RevBuilder As New SqlClient.SqlCommandBuilder(daRev)

            daPart.UpdateCommand = PartBuilder.GetUpdateCommand
            daPart.UpdateCommand.Connection = cn
            daPart.InsertCommand = PartBuilder.GetInsertCommand
            AddHandler daPart.RowUpdated, AddressOf HandleRowUpdatedPartMast
            daPart.InsertCommand.Connection = cn
            daPart.DeleteCommand = PartBuilder.GetDeleteCommand
            daPart.DeleteCommand.Connection = cn
            daPart.AcceptChangesDuringFill = True
            daPart.TableMappings.Add("Table", "tblPartMaster")
            daPart.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daRev.UpdateCommand = RevBuilder.GetUpdateCommand
            daRev.UpdateCommand.Connection = cn
            daRev.InsertCommand = RevBuilder.GetInsertCommand
            AddHandler daRev.RowUpdated, AddressOf HandleRowUpdatedPartRev
            daRev.InsertCommand.Connection = cn
            daRev.DeleteCommand = RevBuilder.GetDeleteCommand
            daRev.DeleteCommand.Connection = cn
            daRev.AcceptChangesDuringFill = True
            daRev.TableMappings.Add("Table", "tblPartRev")
            daRev.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedPartMast(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartMaster").Columns("PartID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartRev(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartRev").Columns("PartRevID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daPart.FillSchema(dsMain, SchemaType.Source, "tblPartMaster")
        daRev.FillSchema(dsMain, SchemaType.Source, "tblPartRev")

        daPart.Fill(dsMain, "tblPartMaster")
        Dim MastID As DataColumn = dsMain.Tables("tblPartMaster").Columns("PartID")
        MastID.AutoIncrement = True
        MastID.AutoIncrementStep = -1
        MastID.AutoIncrementSeed = -1
        MastID.ReadOnly = False

        daRev.Fill(dsMain, "tblPartRev")
        Dim RevID As DataColumn = dsMain.Tables("tblPartRev").Columns("PartRevID")
        RevID.AutoIncrement = True
        RevID.AutoIncrementStep = -1
        RevID.AutoIncrementSeed = -1
        RevID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("PartRev", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartRev").Columns("PartID"), True)
        End With

        dsMain.Tables("tblPartRev").Columns("PartRevID").ColumnMapping = MappingType.Hidden
        dsMain.Tables("tblPartRev").Columns("PartID").ColumnMapping = MappingType.Hidden

        PartCurrency = CType(BindingContext(dsMain, "tblPartMaster"), CurrencyManager)
        RevCurrency = CType(BindingContext(dsMain, "tblPartRev"), CurrencyManager)

    End Sub

    Sub SetDataCtl()

        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
        End With

        With Me.CmbCreatedBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
            .SelectedIndex = -1
        End With

        With Me.CmbApprovedBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEng").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
            .SelectedIndex = -1
        End With

        'dgRev datagridview

        With Me.PartRevID
            .DataPropertyName = "PartRevID"
            .Name = "PartRevID"
            .Visible = False
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.RevNo
            .DataPropertyName = "RevNo"
            .Name = "RevNo"
        End With

        With Me.RevDateStart
            .DataPropertyName = "RevDateStart"
            .Name = "RevDateStart"
        End With

        With Me.RevDesc
            .DataPropertyName = "RevDesc"
            .Name = "RevDesc"
        End With

        With Me.RevNotes
            .DataPropertyName = "RevNotes"
            .Name = "RevNotes"
        End With

        With Me.RevStatus
            .DataPropertyName = "RevStatus"
            .Name = "RevStatus"
        End With

        dgRev.AutoGenerateColumns = False
        dgRev.DataSource = dsMain
        dgRev.DataMember = "tblPartMaster.PartRev"

    End Sub

    Sub DisableScreen()
        txtPartDate.ReadOnly = True     'only
        txtPartNo.ReadOnly = True
        txtPartName.ReadOnly = True
        txtDescrCode.ReadOnly = True
        txtDateIssue.ReadOnly = True
        txtDateApproved.ReadOnly = True
        txtMinQty.ReadOnly = True
        txtMaxQty.ReadOnly = True
        txtM3Article.ReadOnly = True
        CmbCrossStatus.Enabled = False

        CmbUser.Enabled = False         'only
        CmbPartNumber.Enabled = True
        CmbCreatedBy.Enabled = False
        CmbApprovedBy.Enabled = False

        dgRev.ReadOnly = True
  
    End Sub

    Sub DisableButton()
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True
        CmdBrowse.Enabled = False

        CmbPartNumber.Enabled = False

        dsMain.RejectChanges()
        dgRev.Refresh()

        PartCurrency.EndCurrentEdit()
        PartCurrency.AddNew()

        Call EnableFields()
        Call InitValue()
        txtPartNo.Focus()

    End Sub

    Sub EnableFields()

        txtMinQty.ReadOnly = False
        txtMaxQty.ReadOnly = False

        If Len(Trim(txtDateApproved.Text)) <> 0 Or Len(Trim(CmbApprovedBy.Text)) <> 0 Then  'some fields enable
            txtPartDate.Focus()

            txtPartNo.ReadOnly = True
            txtPartName.ReadOnly = False
            txtDescrCode.ReadOnly = True
            txtDateApproved.ReadOnly = True

            CmbPartNumber.Enabled = False
            CmbApprovedBy.Enabled = False

            dgRev.ReadOnly = False

            txtDateIssue.ReadOnly = True        'created by sales or eng
            CmbCreatedBy.Enabled = False        '  '='
        Else
            txtPartDate.Focus()

            txtPartNo.ReadOnly = False
            txtPartName.ReadOnly = False
            txtDescrCode.ReadOnly = True
            txtDateApproved.ReadOnly = True

            CmbPartNumber.Enabled = False
            CmbApprovedBy.Enabled = False

            dgRev.ReadOnly = False

            txtDateIssue.ReadOnly = True        'created by sales or eng
            CmbCreatedBy.Enabled = False        '  '='
        End If

        If RoleM3Codification(wkDeptCode) = True Then
            txtM3Article.ReadOnly = False
            CmbCrossStatus.Enabled = True
        Else
            txtM3Article.ReadOnly = True
            CmbCrossStatus.Enabled = False
        End If

    End Sub

    Sub InitValue()
        txtPartDate.Text = Now.ToShortDateString
        txtDateIssue.Text = Now.ToShortDateString
        CmbCreatedBy.SelectedValue = wkEmpId
      
        txtPartName.Text = "BOLT, TYPE"

    End Sub

    Private Sub dgRev_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellClick
        dgRev.Refresh()

        If e.RowIndex >= 0 Then
            If dgRev.ReadOnly = True Then
                Exit Sub
            End If

            Select Case e.ColumnIndex
                Case 6
                    dgRev("revStatus", e.RowIndex).ReadOnly = True
            End Select
           
        End If
    End Sub

    Private Sub dgRev_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellEndEdit
        Select Case e.ColumnIndex
            Case 2      'revno
                If IsDBNull(dgRev.Item("RevNo", e.RowIndex).Value) = False Then
                    dgRev.Item("RevDateStart", e.RowIndex).Value = txtPartDate.Text
                Else
                    Exit Sub
                End If

                If Len(Trim(dgRev.Rows(e.RowIndex).Cells("RevStatus").ToString)) = 0 Or _
                    IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevStatus").Value) = True Then
                    dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "Active"
                Else
                    Exit Sub
                End If

            Case 3
                Try
                    If IsDBNull(Me.dgRev.Item("RevDateStart", e.RowIndex).Value) = False Then
                        Dim dt As DateTime = DateTime.Parse(Me.dgRev("RevDateStart", e.RowIndex).Value)

                        If dt.Year < Now.Year - 4 OrElse dt.Year > Now.Year + 4 Then
                            MsgBox("The Range of valid Years must be between" + Str(Now.Year) - 4 + " and " + Str(Now.Year) + 4)
                            Me.dgRev.Item("RevDateStart", e.RowIndex).Value = "MM/dd/yyyy"
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, _
                    MsgBoxStyle.OKOnly, "Revision Date Start: MM/dd/yyyy")
                    Me.dgRev.Item("RevDateStart", e.RowIndex).Value = "MM/dd/yyyy"
                End Try
        End Select

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Call ValPo()

        If SwVal = True Then
            DisableButton()
            DisableScreen()

            PartCurrency.EndCurrentEdit()
            RevCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    intPart = daPart.Update(dsMain.Tables("tblPartMaster").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    intRev = daRev.Update(dsMain.Tables("tblPartRev").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    intPart += daPart.Update(dsMain.Tables("tblPartMaster").Select("", "", DataViewRowState.Deleted))
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgRev.Refresh()
            dsMain.AcceptChanges()
        End If

    End Sub

    Sub BindComponents()

        txtPartDate.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtPartName.DataBindings.Clear()
        txtDescrCode.DataBindings.Clear()
        txtDateIssue.DataBindings.Clear()
        txtDateApproved.DataBindings.Clear()
        txtMinQty.DataBindings.Clear()
        txtMaxQty.DataBindings.Clear()
        txtM3Article.DataBindings.Clear()

        CmbUser.DataBindings.Clear()
        CmbCreatedBy.DataBindings.Clear()
        CmbApprovedBy.DataBindings.Clear()
        CmbCrossStatus.DataBindings.Clear()

        txtPartNo.DataBindings.Add("Text", dsMain, "tblPartMaster.PartNumber")
        txtPartName.DataBindings.Add("Text", dsMain, "tblPartMaster.PartName")
        txtDescrCode.DataBindings.Add("Text", dsMain, "tblPartMaster.PartDescCode")
        txtDateIssue.DataBindings.Add("Text", dsMain, "tblPartMaster.DateIssue", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        CmbCreatedBy.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.CreatedBy")
        txtDateApproved.DataBindings.Add("Text", dsMain, "tblPartMaster.DateApproved", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtMinQty.DataBindings.Add("Text", dsMain, "tblPartMaster.StMinQty")
        txtMaxQty.DataBindings.Add("Text", dsMain, "tblPartMaster.WIPMaxQty")
        txtM3Article.DataBindings.Add("Text", dsMain, "tblPartMaster.MMITDS")

        CmbApprovedBy.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.ApprovedBy")

        CmbCrossStatus.DataBindings.Add("Text", dsMain, "tblPartMaster.PNCrossStatus")

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        dsMain.RejectChanges()
        DisableScreen()

        CmdNew.Enabled = True
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True

    End Sub

    Private Sub CmbPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPartNumber.SelectedIndexChanged
        Me.BindingContext(dsMain, "tblPartMaster").Position = CType(CmbPartNumber.SelectedIndex, String)
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True
        CmdBrowse.Enabled = False

        CmbPartNumber.Enabled = False
        Call EnableFields()

    End Sub

    Sub ValPo()

        If Len(Trim(txtPartNo.Text)) = 0 Or IsDBNull(txtPartNo.Text) = True Then
            MsgBox("!!! ERROR !!! Part Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtM3Article.Text)) = 0 Or IsDBNull(txtM3Article.Text) = True Then
            MsgBox("!!! ERROR !!! M3 Article is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbCrossStatus.Text)) = 0 Or IsDBNull(CmbCrossStatus.Text) = True Then
            MsgBox("!!! ERROR !!! Part Number M3 status is Empty.")
            SwVal = False
            Exit Sub
        End If

        Dim SwProdDescr As String = ""
        If CmbCrossStatus.Text = 20 Or CmbCrossStatus.Text = 99 Then
            SwProdDescr = txtPartNo.Text
            If InStr(SwProdDescr, "BACB30YK", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YM", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YN", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YL", vbTextCompare) <> 0 Then
                MsgBox("!!! ERROR !!! The P/N Cross Status should read 88.")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbCrossStatus.Text = 20 Or CmbCrossStatus.Text = 99 Then
            SwProdDescr = CmbPartNumber.Text
            If InStr(SwProdDescr, "BACB30YK", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YM", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YN", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YL", vbTextCompare) <> 0 Then
                MsgBox("!!! ERROR !!! The P/N Cross Status should read 88.")
                SwVal = False
                Exit Sub
            End If
        End If

        SwVal = True

    End Sub

    Private Sub dgRev_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRev.DataError
        REM end

    End Sub

    Private Sub dgRev_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgRev.RowPrePaint
        If IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevStatus").Value) = False Then
            If dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "InActive" Then
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
            Else
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click
        frmPartMasterBrowse.ShowDialog()
    End Sub

  
End Class