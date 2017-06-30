Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmQuote

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daQuote As New SqlDataAdapter
    Private daDetail As New SqlDataAdapter
    Private daQty As New SqlDataAdapter

    Dim QuoteCurrency As CurrencyManager
    Dim DetailCurrency As CurrencyManager
    Dim QtyCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwRole As String
    Dim rowPart As Integer = 0
    Dim rowQty As Integer = 0
    Dim PoLisiKey As Integer
    Dim SwOper As String
    Dim swDelete As Integer
    Dim SwEmailCreator As String

    Dim comboBoxColumn As New DataGridViewComboBoxColumn()

    Private Sub frmQuote_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        QuoteCurrency.EndCurrentEdit()
        DetailCurrency.EndCurrentEdit()
        QtyCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daQuote.Dispose()
        daDetail.Dispose()
        daQty.Dispose()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmQuote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Me.ErrorProvider1.Clear()

        DisableScreen()
        VerifyRoleButtons()

        BuildSqlCommand()

        InitialComponents()

        SetDataCtl()

        BindComponents()

        dgPart.AutoGenerateColumns = False
        dgPart.DataSource = dsMain
        dgPart.DataMember = "tblQuote.MastDetail"         'MastDetail

        dgQty.AutoGenerateColumns = False
        dgQty.DataSource = dsMain
        dgQty.DataMember = "tblQuote.MastDetail.DetailQty"        'DetailQty

        txtPartDate.Text = Now.ToShortDateString

        swDelete = 0  'no delete

        CmbQuoteNo.DataSource = dsMain.Tables("tblQuote")
        CmbQuoteNo.DisplayMember = "QNo"
        CmbQuoteNo.ValueMember = "QID"

        If Len(Trim(SwFormQT.Text)) <> 0 Then
            CmbQuoteNo.SelectedValue = SwFormQT.Text
        Else
            CalculGrid()
        End If

        SwFormQT.Text = ""



    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daQuote = CallClass.PopulateDataAdapter("getTblQuote")
            daDetail = CallClass.PopulateDataAdapter("getTblQuoteDetail")
            daQty = CallClass.PopulateDataAdapter("getTblQuoteDetailQty")

            Dim PartBuilder As New SqlClient.SqlCommandBuilder(daQuote)
            Dim RevBuilder As New SqlClient.SqlCommandBuilder(daDetail)
            Dim MfgBuilder As New SqlClient.SqlCommandBuilder(daQty)

            daQuote.UpdateCommand = PartBuilder.GetUpdateCommand
            daQuote.UpdateCommand.Connection = cn
            daQuote.InsertCommand = PartBuilder.GetInsertCommand
            AddHandler daQuote.RowUpdated, AddressOf HandleRowUpdatedQuote
            daQuote.InsertCommand.Connection = cn
            daQuote.DeleteCommand = PartBuilder.GetDeleteCommand
            daQuote.DeleteCommand.Connection = cn
            daQuote.AcceptChangesDuringFill = True
            daQuote.TableMappings.Add("Table", "tblQuote")
            daQuote.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daDetail.UpdateCommand = RevBuilder.GetUpdateCommand
            daDetail.UpdateCommand.Connection = cn
            daDetail.InsertCommand = RevBuilder.GetInsertCommand
            AddHandler daDetail.RowUpdated, AddressOf HandleRowUpdatedQuoteDetail
            daDetail.InsertCommand.Connection = cn
            daDetail.DeleteCommand = RevBuilder.GetDeleteCommand
            daDetail.DeleteCommand.Connection = cn
            daDetail.AcceptChangesDuringFill = True
            daDetail.TableMappings.Add("Table", "tblQuoteDetail")
            daDetail.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daQty.UpdateCommand = MfgBuilder.GetUpdateCommand
            daQty.UpdateCommand.Connection = cn
            daQty.InsertCommand = MfgBuilder.GetInsertCommand
            AddHandler daQty.RowUpdated, AddressOf HandleRowUpdatedQuoteDetailQty
            daQty.InsertCommand.Connection = cn
            daQty.DeleteCommand = MfgBuilder.GetDeleteCommand
            daQty.DeleteCommand.Connection = cn
            daQty.AcceptChangesDuringFill = True
            daQty.TableMappings.Add("Table", "tblQuoteDetailQty")
            daQty.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblTempEmpty").Fill(dsMain, "tblTemp")

        daQuote.FillSchema(dsMain, SchemaType.Source, "tblQuote")
        daDetail.FillSchema(dsMain, SchemaType.Source, "tblQuoteDetail")
        daQty.FillSchema(dsMain, SchemaType.Source, "tblQuoteDetailQty")

        daQuote.Fill(dsMain, "tblQuote")
        Dim QqID As DataColumn = dsMain.Tables("tblQuote").Columns("QID")
        QqID.AutoIncrement = True
        QqID.AutoIncrementStep = -1
        QqID.AutoIncrementSeed = -1
        QqID.ReadOnly = False

        daDetail.Fill(dsMain, "tblQuoteDetail")
        Dim DetailID As DataColumn = dsMain.Tables("tblQuoteDetail").Columns("QDetailID")
        DetailID.AutoIncrement = True
        DetailID.AutoIncrementStep = -1
        DetailID.AutoIncrementSeed = -1
        DetailID.ReadOnly = False

        daQty.Fill(dsMain, "tblQuoteDetailQty")
        Dim QtyID As DataColumn = dsMain.Tables("tblQuoteDetailQty").Columns("QQtyID")
        QtyID.AutoIncrement = True
        QtyID.AutoIncrementStep = -1
        QtyID.AutoIncrementSeed = -1
        QtyID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("MastDetail", _
                .Tables("tblQuote").Columns("QID"), _
                .Tables("tblQuoteDetail").Columns("QID"), True)
        End With

        With dsMain
            .Relations.Add("DetailQty", _
                .Tables("tblQuoteDetail").Columns("QDetailID"), _
                .Tables("tblQuoteDetailQty").Columns("QDetailID"), True)
        End With

        QuoteCurrency = CType(BindingContext(dsMain, "tblQuote"), CurrencyManager)
        DetailCurrency = CType(BindingContext(dsMain, "tblQuoteDetail"), CurrencyManager)
        QtyCurrency = CType(BindingContext(dsMain, "tblQuoteDetailQty"), CurrencyManager)

    End Sub

    Sub BindComponents()


        Chk1.Checked = False
        Chk2.Checked = False
        Chk3.Checked = False
        Chk4.Checked = False
        Chk5.Checked = False
        Chk6.Checked = False
        Chk7.Checked = False
        Chk8.Checked = False

        'ChkContract.Checked = False
        'ChkFollow.Checked = False
        'ChkAsk.Checked = False


        txtPartDate.DataBindings.Clear()    'only

        txtCustRef.DataBindings.Clear()
        txtFOB.DataBindings.Clear()
        txtTerms.DataBindings.Clear()
        txtQtyVar.DataBindings.Clear()
        txtValidity.DataBindings.Clear()
        txtExpediate.DataBindings.Clear()
        txtReports.DataBindings.Clear()
        txtHeader.DataBindings.Clear()
        txtFooter.DataBindings.Clear()
        txtDateIssue.DataBindings.Clear()
        txtLACNotes.DataBindings.Clear()
        txtDueDate.DataBindings.Clear()

        CmbQuoteNo.DataBindings.Clear()
        CmbCust.DataBindings.Clear()
        CmbAttn.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbCreatedBy.DataBindings.Clear()
        CmbApprovedBy.DataBindings.Clear()

        ChkAsk.DataBindings.Clear()
        ChkContract.DataBindings.Clear()
        ChkFollow.DataBindings.Clear()

        Chk1.DataBindings.Clear()
        Chk2.DataBindings.Clear()
        Chk3.DataBindings.Clear()
        Chk4.DataBindings.Clear()
        Chk5.DataBindings.Clear()
        Chk6.DataBindings.Clear()
        Chk7.DataBindings.Clear()
        Chk8.DataBindings.Clear()
        txtEngReview.DataBindings.Clear()

        CmbCust.DataBindings.Add("SelectedValue", dsMain, "tblQuote.QCustID")

        PutAttn()

        CmbAttn.DataBindings.Add("SelectedValue", dsMain, "tblQuote.QAttnID")
        CmbCreatedBy.DataBindings.Add("SelectedValue", dsMain, "tblQuote.QCreatedBy")
        CmbApprovedBy.DataBindings.Add("SelectedValue", dsMain, "tblQuote.QApprovedBy")
        CmbDevise.DataBindings.Add("Text", dsMain, "tblQuote.QDevise")

        txtQNO.DataBindings.Clear()
        'txtQNO.DataBindings.Add(New Binding("Text", dsMain, "tblQuote.QNo", True))
        txtQNO.DataBindings.Add("Text", dsMain, "tblQuote.QNo")

        txtDateIssue.DataBindings.Add("Text", dsMain, "tblQuote.Qdate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        txtDueDate.DataBindings.Add("Text", dsMain, "tblQuote.QDueDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

        txtCustRef.DataBindings.Add("Text", dsMain, "tblQuote.QCustRefNo")
        txtFOB.DataBindings.Add("Text", dsMain, "tblQuote.QFob")
        txtTerms.DataBindings.Add("Text", dsMain, "tblQuote.QTerms")
        txtQtyVar.DataBindings.Add("Text", dsMain, "tblQuote.QtyVariance")
        txtValidity.DataBindings.Add("Text", dsMain, "tblQuote.QValidity")
        txtExpediate.DataBindings.Add("Text", dsMain, "tblQuote.QExpediteFee", True, DataSourceUpdateMode.OnValidation, "", "N2")
        txtReports.DataBindings.Add("Text", dsMain, "tblQuote.QMfrReport", True, DataSourceUpdateMode.OnValidation, "", "N2")
        txtHeader.DataBindings.Add("Text", dsMain, "tblQuote.QHeaderNotes")
        txtFooter.DataBindings.Add("Text", dsMain, "tblQuote.QFooterNotes")
        txtLACNotes.DataBindings.Add("Text", dsMain, "tblQuote.QLACNotes")

        ChkAsk.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QAsk", True))
        ChkContract.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QContract", True))
        ChkFollow.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QFollow", True))

        Chk1.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk1", True))
        Chk2.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk2", True))
        Chk3.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk3", True))
        Chk4.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk4", True))
        Chk5.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk5", True))
        Chk6.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk6", True))
        Chk7.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk7", True))
        Chk8.DataBindings.Add(New Binding("Checked", dsMain, "tblQuote.QChk8", True))
        txtEngReview.DataBindings.Add("Text", dsMain, "tblQuote.QEngReview")

    End Sub

    Private Sub HandleRowUpdatedQuote(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblQuote").Columns("QID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedQuoteDetail(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblQuoteDetail").Columns("QDetailID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedQuoteDetailQty(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblQuoteDetailQty").Columns("QQtyID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub DisableScreen()
        txtPartDate.ReadOnly = True     'only
        txtQNO.ReadOnly = True

        txtCustRef.ReadOnly = True
        txtFOB.ReadOnly = True
        txtTerms.ReadOnly = True
        txtQtyVar.ReadOnly = True
        txtValidity.ReadOnly = True
        txtExpediate.ReadOnly = True
        txtReports.ReadOnly = True
        txtHeader.ReadOnly = True
        txtFooter.ReadOnly = True
        txtDateIssue.ReadOnly = True
        txtLACNotes.ReadOnly = True
        txtDueDate.ReadOnly = True

        CmbUser.Enabled = False         'only
        CmbQuoteNo.Enabled = True
        CmbCreatedBy.Enabled = False
        CmbApprovedBy.Enabled = False

        'ChkAsk.Checked = False
        'ChkHist.Checked = False
        'ChkContract.Checked = False
        'ChkFollow.Checked = False

        ChkAsk.Enabled = False
        ChkHist.Enabled = True
        ChkContract.Enabled = False
        ChkFollow.Enabled = False

        CmbCust.Enabled = False
        CmbAttn.Enabled = False
        CmbDevise.Enabled = False

        CmdHeader.Enabled = False
        CmdFooter.Enabled = False
        CmdSeeCust.Enabled = False

        dgPart.ReadOnly = True
        dgQty.ReadOnly = True

        PanelRev.Visible = False

        CmbLeadTime.Visible = False
        lblCmbLead.Visible = False
        CmdMfgLead.Visible = False
        CmdExpLead.Visible = False
        CmdSelect.Enabled = False
        CmdClosed.Enabled = False
        CmdUnSelect.Enabled = False
        CmdCancelled.Enabled = False

    End Sub

    Sub SetDataCtl()

        PutCustomer()
        PutAttn()

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
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetQuote").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
            .SelectedIndex = -1
        End With

        'dgPart datagridview

        With Me.QDetailID
            .DataPropertyName = "QDetailID"
            .Name = "QDetailID"
            .Visible = False
        End With

        With Me.QID
            .DataPropertyName = "QID"
            .Name = "QID"
            .Visible = False
        End With

        With Me.QDetLine
            .DataPropertyName = "QDetLine"
            .Name = "QDetLine"
        End With

        PutCmbPartNumberGrid()

        With Me.QRev
            .DataPropertyName = "QRev"
            .Name = "QRev"
            .ReadOnly = True
        End With

        With Me.QPartName
            .DataPropertyName = "QPartName"
            .Name = "QPartName"
            .ReadOnly = True
        End With

        With Me.QPartNotes
            .DataPropertyName = "QPartNotes"
            .Name = "QPartNotes"
        End With

        With Me.PartValue
            .DataPropertyName = "PartValue"
            .Name = "PartValue"
        End With

        With Me.QLineStatus
            .DataPropertyName = "QLineStatus"
            .Name = "QLineStatus"
        End With

        With Me.SWSelect
            .DataPropertyName = "SWSelect"
            .Name = "SWSelect"
        End With

        With Me.QQTyContract
            .DataPropertyName = "QQTyContract"
            .Name = "QQTyContract"
        End With

        With Me.QFPRevision
            .DataPropertyName = "QFPRevision"
            .Name = "QFPRevision"
        End With

        'dgQty datagridview

        With Me.QQtyID
            .DataPropertyName = "QQtyID"
            .Name = "QQtyID"
            .Visible = False
        End With

        With Me.QDetailIDQty
            .DataPropertyName = "QDetailID"
            .Name = "QDetailID"
            .Visible = False
        End With

        With Me.QLineQty
            .DataPropertyName = "QLineQty"
            .Name = "QLineQty"
        End With

        With Me.QQty
            .DataPropertyName = "QQty"
            .Name = "QQty"
        End With

        With Me.QQuotedPrice
            .DataPropertyName = "QQuotedPrice"
            .Name = "QQuotedPrice"
        End With

        With Me.QContractSw
            .DataPropertyName = "QContractSw"
            .Name = "QContractSw"
        End With

        With Me.QLineValue
            .DataPropertyName = "QLineValue"
            .Name = "QLineValue"
        End With

        With Me.QEstPriceDevise
            .DataPropertyName = "QEstPriceDevise"
            .Name = "QEstPriceDevise"
        End With

        With Me.QEstPrice
            .DataPropertyName = "QEstPrice"
            .Name = "QEstPrice"
        End With

        With Me.QLeadTime
            .DataPropertyName = "QLeadTime"
            .Name = "QLeadTime"
        End With

        With Me.QExpPrYesNo
            .DataPropertyName = "QExpPrYesNo"
            .Name = "QExpPrYesNo"
        End With

        With Me.QExpLead
            .DataPropertyName = "QExpLead"
            .Name = "QExpLead"
        End With

        With Me.QExpValue
            .DataPropertyName = "QExpValue"
            .Name = "QExpValue"
        End With

        With Me.QRawMaterial
            .DataPropertyName = "QRawMaterial"
            .Name = "QRawMaterial"
        End With

        With Me.QTooling
            .DataPropertyName = "QTooling"
            .Name = "QTooling"
        End With

     
    End Sub

    Sub PutCmbPartNumberGrid()

        With Me.QdetPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
            .DataPropertyName = "QdetPart"
            .Name = "QdetPart"
        End With

    End Sub

    Sub PutCustomer()
        With Me.CmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub PutAttn()

        With Me.CmbAttn
            .DataSource = CallClass.PopulateComboBoxWithParam("tblCustContact", "cmbGetCustContactByCustID", CmbCust.SelectedValue).Tables("tblCustContact")
            .DisplayMember = "ContactName"
            .ValueMember = "ContactID"
        End With

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True
        CmdPrint.Enabled = False
        CmdBrowse.Enabled = True
        CmdSelect.Enabled = True
        CmdClosed.Enabled = True

        CmdUnSelect.Enabled = True
        CmdCancelled.Enabled = True

        CmbQuoteNo.Enabled = False

        dsMain.RejectChanges()
        dgPart.Refresh()
        dgQty.Refresh()

        CmbQuoteNo.SelectedIndex = 1

        QuoteCurrency.EndCurrentEdit()
        QuoteCurrency.AddNew()

        Call InitValue()
        EnableQt()

        SwOper = "OperNew"
        swDelete = 9  'delete accepted

    End Sub

    Sub InitValue()

        txtPartDate.Text = Now.ToShortDateString
        txtDateIssue.Text = Now.ToShortDateString
        CmbCreatedBy.SelectedValue = wkEmpId
        CmbUser.SelectedValue = wkEmpId
        txtFOB.Text = "DORVAL"
        txtTerms.Text = "NET 30 DAYS"
        CmbDevise.Text = "USD"
        txtQtyVar.Text = "+/-10%"
        txtValidity.Text = "90 DAYS"
        txtReports.Text = ""

        CmbLeadTime.Text = "18 Weeks"

        ChkAsk.Checked = False
        ChkHist.Checked = False
        ChkContract.Checked = False
        ChkFollow.Checked = False

        txtTotalQuote.Text = 0

        If SwOper = "OperNew" Then
            Chk1.Checked = True
            Chk2.Checked = True
            Chk3.Checked = True
            Chk4.Checked = True
            Chk5.Checked = True
            Chk6.Checked = True
            Chk7.Checked = True
            Chk8.Checked = True
        Else
            Chk1.Checked = False
            Chk2.Checked = False
            Chk3.Checked = False
            Chk4.Checked = False
            Chk5.Checked = False
            Chk6.Checked = False
            Chk7.Checked = False
            Chk8.Checked = False
        End If

        txtEngReview.Text = ""

    End Sub

    Sub EnableQt()

        txtPartDate.ReadOnly = True     'only
        txtQNO.ReadOnly = True

        txtCustRef.ReadOnly = False
        txtFOB.ReadOnly = False
        txtTerms.ReadOnly = False
        txtQtyVar.ReadOnly = False
        txtValidity.ReadOnly = False
        txtExpediate.ReadOnly = False
        txtReports.ReadOnly = False
        txtHeader.ReadOnly = False
        txtFooter.ReadOnly = False
        txtDateIssue.ReadOnly = False
        txtLACNotes.ReadOnly = False
        txtDueDate.ReadOnly = False

        CmbUser.Enabled = False         'only
        'CmbQuoteNo.Enabled = True
        CmbCreatedBy.Enabled = False
        CmbApprovedBy.Enabled = False

        CmbCust.Enabled = True
        CmbAttn.Enabled = True
        CmbDevise.Enabled = True

        CmdHeader.Enabled = True
        CmdFooter.Enabled = True
        CmdSeeCust.Enabled = True
        ChkAsk.Enabled = True
        ChkHist.Enabled = True
        ChkContract.Enabled = True
        ChkFollow.Enabled = True

        dgPart.ReadOnly = False
        dgQty.ReadOnly = False

        PanelRev.Visible = False

        CmbLeadTime.Visible = True
        lblCmbLead.Visible = True
        CmdMfgLead.Visible = True
        CmdExpLead.Visible = True
    End Sub

    Sub EnableEng()

        txtPartDate.ReadOnly = True     'only
        txtQNO.ReadOnly = True

        txtCustRef.ReadOnly = True
        txtFOB.ReadOnly = True
        txtTerms.ReadOnly = True
        txtQtyVar.ReadOnly = True
        txtValidity.ReadOnly = True
        txtExpediate.ReadOnly = True
        txtReports.ReadOnly = True
        txtHeader.ReadOnly = True
        txtFooter.ReadOnly = True
        txtDateIssue.ReadOnly = True
        txtLACNotes.ReadOnly = True
        txtDueDate.ReadOnly = True

        CmbUser.Enabled = False         'only
        CmbQuoteNo.Enabled = False
        CmbCreatedBy.Enabled = False
        CmbApprovedBy.Enabled = False

        CmbCust.Enabled = False
        CmbAttn.Enabled = False
        CmbDevise.Enabled = False

        CmdHeader.Enabled = False
        CmdFooter.Enabled = False
        CmdSeeCust.Enabled = False
        ChkAsk.Enabled = True
        ChkHist.Enabled = True
        ChkContract.Enabled = False
        ChkFollow.Enabled = False

        dgPart.ReadOnly = True
        dgQty.ReadOnly = False

        PanelRev.Visible = True

        CmbLeadTime.Visible = False
        lblCmbLead.Visible = False
        CmdMfgLead.Visible = False
        CmdExpLead.Visible = False

    End Sub

    Function RoleEng(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ENG" Then
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

    Function RoleQt(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "QT" Then
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

    Sub VerifyRoleButtons()
        If RoleEng(wkDeptCode) = True Then          ' eng
            CmdNew.Enabled = False
            CmdReset.Enabled = True
            CmdPrint.Enabled = True
            CmdEdit.Enabled = True
            CmdSave.Enabled = False
            CmdBrowse.Enabled = True
            CmbLeadTime.Visible = False
            lblCmbLead.Visible = False
            CmdMfgLead.Visible = False
            CmdExpLead.Visible = False
            CmdSelect.Visible = False
            CmdUnSelect.Visible = False
            CmdClosed.Visible = False
            CmdCancelled.Visible = False

            SwRole = "ENG"
        Else
            If RoleQt(wkDeptCode) = True Then       'QT
                CmdNew.Enabled = True
                CmdReset.Enabled = True
                CmdPrint.Enabled = True
                CmdEdit.Enabled = True
                CmdSave.Enabled = False
                CmdBrowse.Enabled = True
                SwRole = "QT"
            Else                                'other users
                CmdNew.Enabled = False
                CmdReset.Enabled = True
                CmdPrint.Enabled = True
                CmdEdit.Enabled = False
                CmdSave.Enabled = False
                CmdBrowse.Enabled = True
                CmbLeadTime.Visible = False
                lblCmbLead.Visible = False
                CmdMfgLead.Visible = False
                CmdExpLead.Visible = False
                SwRole = ""
            End If
        End If

    End Sub

    Sub VerifyRoleFields()

        If RoleEng(wkDeptCode) = True Then          ' eng
            EnableEng()
        Else
            If RoleQt(wkDeptCode) = True Then       'qty
                EnableQt()
            Else                                'other users
                DisableScreen()
            End If
        End If

    End Sub

    Private Sub CmbQuoteNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbQuoteNo.SelectedIndexChanged

        'Chk1.Checked = False
        'Chk2.Checked = False
        'Chk3.Checked = False
        'Chk4.Checked = False
        'Chk5.Checked = False
        'Chk6.Checked = False
        'Chk7.Checked = False
        'Chk8.Checked = False

        'ChkContract.Checked = False
        'ChkFollow.Checked = False

        Me.BindingContext(dsMain, "tblQuote").Position = CType(CmbQuoteNo.SelectedIndex, String)

        BindComponents()        'useful to put correct value for attention combobox
        CalculGrid()

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        If Len(Trim(CmbQuoteNo.Text)) > 0 Then
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = True
            CmdReset.Enabled = True
            CmdPrint.Enabled = False
            CmdBrowse.Enabled = True
            CmdSelect.Enabled = True
            CmdClosed.Enabled = True
            CmdUnSelect.Enabled = True
            CmdCancelled.Enabled = True

            CmbQuoteNo.Enabled = False
            Call VerifyRoleFields()

            SwOper = "Mod"
            swDelete = 9   'delete accepted
        Else
            MsgBox("Action Denied - No Quote info.")
        End If

        Dim swComm As String
        swComm = Nz.Nz(CmbCust.SelectedItem("SalesRepPer"))

        Me.ErrorProvider1.Clear()
        If Val(swComm) > 0 Then
            Me.ErrorProvider1.SetError(CmbCust, "!!! Attention !!! Sales Rep. Comission: " + swComm)
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        ChkFollow.Focus()
        dgPart.Focus()
        dgPart.Refresh()
        CmdSave.Focus()
        dgQty.Focus()
        dgQty.Refresh()
        CmdPrint.Focus()
        dgPart.Focus()
        txtPartDate.Focus()
        CmbUser.Focus()

        Call ValPo()

        If SwVal = True Then

            VerifyRoleButtons()

            If SwOper = "OperNew" Then
                PutQTNumber()
            End If

            SwOper = ""
            If Len(Trim(txtQNO.Text)) = 0 Then
                MsgBox("Exception occured - Cannot Generate The Quote Number. Action was cancelled.")
                Exit Sub
            End If

            Dim KKQNO As String
            KKQNO = txtQNO.Text

            QuoteCurrency.EndCurrentEdit()
            DetailCurrency.EndCurrentEdit()
            QtyCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daQuote.Update(dsMain.Tables("tblQuote").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daDetail.Update(dsMain.Tables("tblQuoteDetail").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daQty.Update(dsMain.Tables("tblQuoteDetailQty").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    daQty.Update(dsMain.Tables("tblQuoteDetailQty").Select("", "", DataViewRowState.Deleted))
                    daDetail.Update(dsMain.Tables("tblQuoteDetail").Select("", "", DataViewRowState.Deleted))

                    dsMain.AcceptChanges()

                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgPart.Refresh()
            dgQty.Refresh()
            dgPart.ReadOnly = True
            dgQty.ReadOnly = True

            Me.ErrorProvider1.Clear()

            swDelete = 0   'delete reset

            BindComponents()

            DisableScreen()

            If RoleEng(wkDeptCode) = True Then
                If IsDBNull(CmbCreatedBy) = False Then
                    If ChkAsk.Checked = False Then

                        'Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
                        'Dim strBody As String = ""
                        'NotesSession = CreateObject("Notes.NotesSession")
                        'If Len(wkEmpLogin) > 8 Then
                        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
                        'Else
                        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
                        'End If
                        'NotesDoc = NotesDb.CREATEDOCUMENT
                        'NotesItem = NotesDoc.CreateRichTextItem("BODY")
                        ''NotesDoc.Form = "Memo"
                        'NotesDoc.Subject = "RFQ Module"
                        ''NotesDoc.cc = ""
                        'strBody = "This is to inform you" & vbCrLf
                        'strBody = strBody & "that the Quote Number: " & txtQNO.Text & vbCrLf
                        'strBody = strBody & " has been revised by Engineering Department."
                        'NotesDoc.body = strBody

                        IdentifyCreator()
                        If Len(Trim(SwEmailCreator)) <> 0 Then
                            'Call NotesDoc.SEND(False, SwEmailCreator)

                            Dim email As New Mail.MailMessage()
                            Dim strBody As String = ""
                            email.Subject = "RFQ Module"
                            strBody = "This is to inform you" & vbCrLf
                            strBody = strBody & "that the Quote Number: " & txtQNO.Text & vbCrLf
                            strBody = strBody & " has been revised by Engineering Department."
                            email.Body = strBody

                            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            email.To.Add(New Mail.MailAddress(SwEmailCreator))
                            client.Send(email)

                        End If

                    End If
                End If
            End If

            CmbQuoteNo.SelectedIndex = CmbQuoteNo.FindStringExact(KKQNO)
        End If

    End Sub

    Sub IdentifyCreator()

        SwEmailCreator = ""

        Dim SqlStr As String
        SqlStr = "SELECT * FROM tblEmployee WHERE (EmployeeID = " & CmbCreatedBy.SelectedValue & " )"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(SqlStr, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("Access Denied. User Can't be identified.")
                End
            Else
                While myReader.Read()
                    SwEmailCreator = myReader.GetString(8)
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub PutQTNumber()

        strSQL = "SELECT tblLisiKey.ValueKey FROM tblLisiKey " _
                        & "WHERE ((tblLisiKey.ModuleKey)= '" & "QUOTE" & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            cn.Open()
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! Quote Number cannot be generated.")
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                Exit Sub
            Else
                While myReader.Read()
                    PoLisiKey = myReader.GetValue(0)
                End While
                myReader.Close()
                myReader.Dispose()
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                If PoLisiKey = 0 Then
                    Call UpdateLisiPOKey()
                    Call FindNewMonthLisiDate()
                Else
                    FindNextQTNumber()
                End If
                End If
        Catch ex As Exception
            MsgBox("Exception occured - Put PO Number   " & ex.Message)
            Exit Sub
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub FindNextQTNumber()

        strSQL = "SELECT DISTINCT Max(STR(tblQuote.QNo)) AS MaxQT FROM tblQuote"

        Dim myNo As String
        Dim myPos As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! QT Number cannot be generated.")
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                Exit Sub
            Else
                While myReader.Read()
                    If IsDBNull(myReader.GetString(0)) OrElse IsNothing(Nz.Nz(myReader.GetString(0))) Then
                        MsgBox("Exception occured - QT Number cannot be generate. Null value. ")
                        Exit Sub
                    Else
                        myPos = InStr(1, myReader.GetString(0), "-")
                        If myPos = 0 Then
                            txtQNO.Text = Trim(Str(CInt(Nz.Nz(myReader.GetString(0), "")) + 1))
                        Else
                            myNo = Microsoft.VisualBasic.Left(myReader.GetString(0), myPos - 1)
                            txtQNO.Text = CInt(myNo) + 1
                            txtQNO.Focus()
                        End If
                    End If
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - FindNextQTNumber   " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateLisiPOKey()

        strSQL = "UPDATE tblLisiKey Set ValueKey = 99 " _
            & "WHERE ((tblLisiKey.ModuleKey)= '" & "QUOTE" & "')"

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim cmd As SqlCommand = New SqlCommand(strSQL, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Exception occured - UpdateLisiPOKey   " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Sub FindNewMonthLisiDate()

        strSQL = "SELECT tblLisiDate.LisiDateTo FROM tblLisiDate " _
                        & "WHERE ((tblLisiDate.StatusMonth)= '" & "OPEN" & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! PO Number cannot be generated.")
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                Exit Sub
            Else
                Dim txtMonth As String
                Dim txtYear As String
                While myReader.Read()
                    txtYear = Trim(Str(Format(myReader.GetValue(0), "yy")))
                    txtMonth = Trim(Format(myReader.GetValue(0), "MM"))

                    txtQNO.Text = Trim(Str(txtYear)) + Trim(txtMonth) + "001"
                    txtQNO.Focus()
                End While
                myReader.Close()
                myReader.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - FindMonthLisiDate   " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        Me.ErrorProvider1.Clear()

        QuoteCurrency.EndCurrentEdit()
        DetailCurrency.EndCurrentEdit()
        QtyCurrency.EndCurrentEdit()

        dsMain.RejectChanges()

        DisableScreen()
        ChkAsk.Checked = False
        ChkHist.Checked = False
        ChkContract.Checked = False
        ChkFollow.Checked = False

        VerifyRoleButtons()

        SwOper = ""
        swDelete = 0   'delete reset

        txtTotalQuote.Text = 0
        txtEngReview.Text = ""
        'txtQNO.Text = ""

        BuildSqlCommand()

        InitialComponents()

        CmbQuoteNo.SelectedIndex = -1

    End Sub

    Sub ValPo()

        If ChkAsk.CheckState = CheckState.Unchecked Then
            ChkAsk.Checked = False
        End If

        If ChkContract.CheckState = CheckState.Unchecked Then
            ChkContract.Checked = False
        End If

        If ChkFollow.CheckState = CheckState.Unchecked Then
            ChkFollow.Checked = False
        End If

        If IsDBNull(CmbCust.SelectedValue) = True Or IsNothing(CmbCust.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Customer is Empty.")
            SwVal = False
            Exit Sub
        End If

        Dim II As Integer
        II = dgPart.Rows.Count
        For II = 1 To dgPart.Rows.Count - 1
            If IsDBNull(dgPart.Item("QdetPart", II - 1).Value) = True Or _
                Nz.Nz(dgPart.Item("QdetPart", II - 1).Value) = 0 Then
                MsgBox("!!! ERROR !!! Product Number is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        Dim JJ As Integer
        JJ = dgQty.Rows.Count
        For JJ = 1 To dgQty.Rows.Count - 1
            If IsDBNull(dgQty.Item("QQty", JJ - 1).Value) = True Or _
                Nz.Nz(dgQty.Item("QQty", JJ - 1).Value) = 0 Then
                MsgBox("!!! ERROR !!! QT. Quantity is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        CalculGrid()

        If txtTotalQuote.Text >= 100000 Then
            If Len(Trim(CmbApprovedBy.Text)) <> 0 Then
            Else
                MsgBox("!!! Total Quote Value is greater than 100,000.00.  ---   Approve the Quote before saving it.")
                CmbApprovedBy.Enabled = True
                SwVal = False
                Exit Sub
            End If
            If ChkFollow.Checked = False Then
                Dim reply As DialogResult
                reply = MsgBox("!!! Total Quote Value is greater than 100,000.00 / Do you want to avtivate the Check Box (Quote Follow-Up)?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    ChkFollow.Checked = True
                End If
            End If
        End If

        Dim swComm As String
        swComm = Nz.Nz(CmbCust.SelectedItem("SalesRepPer"))

        If Val(swComm) > 0 Then
            Dim reply As DialogResult
            reply = MsgBox("This Customer Request a Sales Rep. Comission. SAVE? (Yes/No)", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                SwVal = False
                Exit Sub
            End If
        End If

        SwVal = True

    End Sub

    Sub CheckPartNumber()

        'Dim II As Integer
        'Dim SwCount As Integer = 0
        'Dim SwPartID As Integer
        'Dim SwRet As String = ""

        'II = dgPart.Rows.Count
        'For II = 1 To dgPart.Rows.Count - 1
        '    SwPartID = dgPart.Item("QdetPart", II - 1).Value
        '    SwRet = CallClass.ReturnStrWithParInt("cspReturnIDPartNumberQuoteCheck", SwPartID)
        '    If SwRet <> "False" Then
        '        SwCount = SwCount + 1
        '    End If
        'Next

        'If SwCount > 0 Then
        '    Dim email As New Mail.MailMessage()
        '    Dim strBody As String = ""
        '    email.Subject = "RFQ Module"
        '    strBody = "This is to inform you" & vbCrLf
        '    strBody = strBody & "that the Quote Number: " & txtQNO.Text & vbCrLf
        '    strBody = strBody & " has " + Str(SwCount) + " part(s) quoted before."
        '    email.Body = strBody

        '    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
        '    email.From = New Net.Mail.MailAddress(wkEmpEmail)
        '    email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
        '    client.Send(email)

        'End If

    End Sub

    Private Sub dgPart_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPart.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            rowPart = e.RowIndex
        End If

        If Nz.Nz(dgPart("QLineStatus", e.RowIndex).Value) = 90 Then
            e.Cancel = True
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 3                      ' part number
                If IsDBNull(Me.dgPart("QDetLine", e.RowIndex).Value) Then
                    e.Cancel = True
                End If
            Case 4                     ' part number
                If ChkContract.Checked = False Then
                    MsgBox("This cell is disable. Activate - Contract Check Box - to enable the cell.")
                    e.Cancel = True
                End If
            Case 7, 8
                e.Cancel = True
            Case 10                   'status quote line
                e.Cancel = True
            Case 11, 12
                If IsDBNull(Me.dgPart("QDetLine", e.RowIndex).Value) Then
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgPart_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPart.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            rowPart = e.RowIndex
        End If

        CalculGrid()

        Select Case e.ColumnIndex
            Case 5
                If Nz.Nz(dgPart("QDetLine", e.RowIndex).Value) = 0 Then
                    MessageBox.Show("Action Denied. Enter before the Quote Line number.")
                    dgPart.EndEdit()
                Else
                    frmPartMasterQuote.SwFormQTShort.Text = Nz.Nz(dgPart.Rows(e.RowIndex).Cells("QdetPart").Value)
                    frmPartMasterQuote.ShowDialog()
                    PutCmbPartNumberGrid()
                End If
            Case 6
                If IsDBNull(dgPart("QdetPart", e.RowIndex).Value) = False Then
                    Dim II As Integer
                    II = Nz.Nz(dgPart("QdetPart", e.RowIndex).Value)

                    frmQuoteBrowse.txtPartID.Text = II.ToString
                    frmQuoteBrowse.ShowDialog()
                End If
            Case 9     'Refresh Revision
                TakeRevAndPartName()
            Case 13
                frmSalesPlanningFPInventory.SwFPPrev.Text = Nz.Nz(dgPart("QdetPart", e.RowIndex).Value)
                frmSalesPlanningFPInventory.ShowDialog()
        End Select

        PutLineDgQty()
    End Sub

    Sub PutLineDgQty()

        For I As Integer = 0 To (dgQty.Rows.Count - 2)
            dgQty.Rows(I).Cells("QLineQty").Value = dgPart("QDetLine", rowPart).Value
        Next

    End Sub

    Private Sub dgPart_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPart.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            rowPart = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 2
                If IsDBNull(Me.dgPart("QLineStatus", e.RowIndex).Value) = True 
                    Me.dgPart("QLineStatus", e.RowIndex).Value = 40
                End If

            Case 3
                TakeRevAndPartName()
        End Select

    End Sub

    Private Sub dgPart_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPart.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            rowPart = e.RowIndex
        End If

      PutLineDgQty

    End Sub

    Sub TakeRevAndPartName()

        'put last rev
        Dim SwRet As String = ""
        Dim SwPartID As Integer = 0

        Dim reply As DialogResult

        If IsDBNull(dgPart("QdetPart", rowPart).Value) = True Then
            Exit Sub
        Else
            If IsDBNull(dgPart("QRev", rowPart).Value) = True Then
                SwPartID = dgPart("QdetPart", rowPart).Value
                SwRet = CallClass.ReturnStrWithParInt("cmbGetQuotePnLastRev", SwPartID)
                If SwRet <> "False" Then
                    dgPart("QRev", rowPart).Value = SwRet
                End If
            Else
                If Len(Trim(dgPart("QRev", rowPart).Value)) = 0 Then
                    SwPartID = dgPart("QdetPart", rowPart).Value
                    SwRet = CallClass.ReturnStrWithParInt("cmbGetQuotePnLastRev", SwPartID)
                    If SwRet <> "False" Then
                        dgPart("QRev", rowPart).Value = SwRet
                    End If
                Else
                    reply = MsgBox("Do you want to Update the PartNumber Revision with the latest one?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    Else
                        SwPartID = dgPart("QdetPart", rowPart).Value
                        SwRet = CallClass.ReturnStrWithParInt("cmbGetQuotePnLastRev", SwPartID)
                        If SwRet <> "False" Then
                            dgPart("QRev", rowPart).Value = SwRet
                        Else
                            dgPart("QRev", rowPart).Value = DBNull.Value
                        End If
                    End If
                End If
            End If
        End If

        SwRet = ""
        SwRet = CallClass.ReturnStrWithParInt("cmbGetQuotePartName", SwPartID)
        If SwRet <> "False" Then
            dgPart("QPartName", rowPart).Value = SwRet
        End If

    End Sub

    Private Sub dgPart_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPart.DataError
        REM end
    End Sub

    Private Sub dgQty_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQty.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        rowQty = e.RowIndex

        Select Case e.ColumnIndex
            Case 2 To 12

                CalculGrid()

                If Nz.Nz(dgPart("QDetLine", rowPart).Value) = 0 Then
                    MsgBox("You cannot edit here without Part Numer Line.")
                    dgQty.Rows(e.RowIndex).ReadOnly = True
                Else
                    If SwRole = "ENG" Then
                        dgQty("QQty", e.RowIndex).ReadOnly = True
                        dgQty("QContractSw", e.RowIndex).ReadOnly = True
                        dgQty("QQuotedPrice", e.RowIndex).ReadOnly = True
                        dgQty("QLeadTime", e.RowIndex).ReadOnly = False
                        dgQty("QEstPriceDevise", e.RowIndex).ReadOnly = True
                        dgQty("QEstPrice", e.RowIndex).ReadOnly = False
                    Else
                        dgQty("QQty", e.RowIndex).ReadOnly = False
                        dgQty("QContractSw", e.RowIndex).ReadOnly = False
                        dgQty("QQuotedPrice", e.RowIndex).ReadOnly = False
                        dgQty("QLeadTime", e.RowIndex).ReadOnly = False
                        dgQty("QEstPriceDevise", e.RowIndex).ReadOnly = True
                        dgQty("QEstPrice", e.RowIndex).ReadOnly = False
                    End If
                    dgQty("QLineValue", e.RowIndex).ReadOnly = True
                End If

        End Select

    End Sub

    Private Sub dgQty_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQty.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        rowQty = e.RowIndex

        Select Case e.ColumnIndex
            Case 2, 3, 4, 5, 7
                dgQty.Rows(e.RowIndex).Cells("QLineQty").Value = dgPart.Rows(rowPart).Cells("QDetLine").Value
                If IsDBNull(dgQty.Rows(e.RowIndex).Cells("QLeadTime").Value) = True Then
                    dgQty.Rows(e.RowIndex).Cells("QLeadTime").Value = CmbLeadTime.Text
                End If

                dgPart.Rows(rowPart).Selected = True
                dgQty.Rows(e.RowIndex).Cells("QLineValue").Value = _
                    Nz.Nz(dgQty.Rows(e.RowIndex).Cells("QQty").Value) * _
                    Nz.Nz(dgQty.Rows(e.RowIndex).Cells("QQuotedPrice").Value)
            Case 6

                Dim swCAD, swUSD, swEUR, swGBP As Double

                strSQL = "SELECT tblLisiDate.LisiExchCAD,tblLisiDate.LisiExchUSD, " _
                   & " tblLisiDate.LisiExchEUR, tblLisiDate.LisiExchGBP  FROM tblLisiDate " _
                   & " WHERE ((tblLisiDate.LisiYear) = " & Year(txtDateIssue.Text) & " and (tblLisiDate.LisiMonth) = " & Month(txtDateIssue.Text) & " )"

                Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cn)
                Dim myReader As Data.SqlClient.SqlDataReader
                Try
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    myReader = mySqlComm.ExecuteReader()
                    Dim TestRec As Int16
                    TestRec = myReader.HasRows
                    If TestRec <> -1 Then
                        MessageBox.Show("!!! ERROR Function!!!! Conversion Price.")
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                        Exit Sub
                    Else
                        While myReader.Read()
                            swCAD = myReader.GetValue(0)
                            swUSD = myReader.GetValue(1)
                            swEUR = myReader.GetValue(2)
                            swGBP = myReader.GetValue(3)
                        End While
                        myReader.Close()
                        myReader.Dispose()
                    End If
                Catch ex As Exception
                    MsgBox("Exception occured - dgQty_CellEndEdit   " & ex.Message)
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try

                Select Case CmbDevise.Text
                    Case "CAD"
                        dgQty.Rows(e.RowIndex).Cells("QEstPriceDevise").Value = dgQty.Rows(e.RowIndex).Cells("QEstPrice").Value * swUSD
                    Case "USD"
                        dgQty.Rows(e.RowIndex).Cells("QEstPriceDevise").Value = dgQty.Rows(e.RowIndex).Cells("QEstPrice").Value
                    Case "EUR"
                        dgQty.Rows(e.RowIndex).Cells("QEstPriceDevise").Value = (dgQty.Rows(e.RowIndex).Cells("QEstPrice").Value * swUSD) / swEUR
                    Case "GBP"
                        dgQty.Rows(e.RowIndex).Cells("QEstPriceDevise").Value = (dgQty.Rows(e.RowIndex).Cells("QEstPrice").Value * swUSD) / swGBP
                End Select

                If RoleEng(wkDeptCode) = True Then
                    dgPart.ReadOnly = False
                End If
                dgPart.Focus()
                dgQty.Focus()
                txtDateIssue.Focus()
                dgQty.Focus()

                dgPart.Rows(rowPart).Selected = True
                If Nz.Nz(dgPart("QLineStatus", rowPart).Value) = 40 Then
                    Me.dgPart("QLineStatus", rowPart).Value = 60
                    dgPart.Focus()
                    dgQty.Focus()
                    txtDateIssue.Focus()
                    dgQty.Focus()
                End If
                dgQty.Refresh()
                dgQty.Focus()
                If RoleEng(wkDeptCode) = True Then
                    dgPart.ReadOnly = True
                End If
        End Select

    End Sub

    Private Sub dgQty_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgQty.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            rowQty = e.RowIndex
        End If

        If IsDBNull(dgPart("QLineStatus", rowPart).Value) = True Then
            MsgBox("Please Enter part line number before.")
            e.Cancel = True
            Exit Sub
        End If

        If Nz.Nz(dgPart("QLineStatus", rowPart).Value) = 90 Then
            e.Cancel = True
            Exit Sub
        End If

        If IsDBNull(dgPart("QdetPart", rowPart).Value) = True Then
            MsgBox("Please Enter part number before.")
            e.Cancel = True
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 3, 5, 7, 8, 10, 11, 12
                If SwRole = "ENG" Then
                    e.Cancel = True
                End If
            Case 2
                e.Cancel = True
            Case 4
                If SwRole = "ENG" Then
                    e.Cancel = True
                Else
                    If ChkContract.Checked = False Then
                        'MsgBox("This cell is disable. Activate - Contract Check Box - to enable the cell.")
                        e.Cancel = True
                    End If
                End If
            Case 13, 14
                If SwRole = "ENG" Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgQty_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgQty.DataError
        REM end
    End Sub

    Sub CalculGrid()

        'For Each rows As DataGridViewRow In Me.Table1DataGridView.Rows
        '    For x As Integer = 0 To Me.Table1DataGridView.Rows.Count - 2
        '        If Not TypeOf Me.Table1DataGridView.Rows(x).Cells(1).Value Is DBNull Then
        '            Debit = Me.Table1DataGridView.Rows(x).Cells(1).Value
        '        End If
        '        If Not TypeOf Me.Table1DataGridView.Rows(x).Cells(2).Value Is DBNull Then
        '            Credit = Me.Table1DataGridView.Rows(x).Cells(2).Value
        '        End If
        '        balance = balance + Credit - Debit
        '        Me.Table1DataGridView.Rows(x).Cells(3).Value = balance
        '    Next
        '    balance = 0.0
        'Next

        'For i As Integer = 0 To (dgPODetails.Rows.Count - 1)
        '    flg = False
        '    ppoQty = ppoQty + dgPODetails("POQty", i).Value
        '    For Each trw As DataRow In myds.Tables("tblPOReceiving").Rows
        '        If Nz.Nz(trw.Item("PODetailID")) = Nz.Nz(dgPODetails.Rows(i).Cells("PODetailID").Value) And _
        '            Nz.Nz(trw.Item("POItem")) = Nz.Nz(dgPODetails.Rows(i).Cells("POItem").Value) Then
        '            flg = True
        '            Exit For
        '        End If
        '    Next
        '    'have no receiving before
        '    If flg = False Then
        '        SetMyds(i, True)
        '    End If
        'Next i

      

        'For I As Integer = 0 To (dgPart.Rows.Count - 1)
        '    For Each trw As DataRow In dsMain.Tables("tblQuoteDetailQty").Rows
        '        If IsDBNull(dgPart.Rows(I).Cells("QDetLine").Value) = False And _
        '                    Nz.Nz(dgPart.Rows(I).Cells("QdetailID").Value) = Nz.Nz(trw.Item("QdetailID")) Then
        '            'trw.Item("QLineValue") = Nz.Nz(trw.Item("QQty")) * Nz.Nz(trw.Item("QQuotedPrice"))
        '            If Len(Trim(txtQNO.Text)) = 0 Then      'new action
        '                TotalQT = TotalQT + Nz.Nz(trw.Item("QQty")) * Nz.Nz(trw.Item("QQuotedPrice"))
        '            Else
        '                If CmbQuoteNo.Text = txtQNO.Text Then
        '                    TotalQT = TotalQT + Nz.Nz(trw.Item("QQty")) * Nz.Nz(trw.Item("QQuotedPrice"))
        '                End If
        '            End If
        '            'trw.Item("QLineQty") = Nz.Nz(dgPart.Rows(I).Cells("QDetLine").Value)
        '        End If
        '    Next
        '    If TotalQT <> 0 Then
        '        dgPart.Rows(I).Cells("PartValue").Value = TotalQT.ToString("C2")
        '    End If

        'Next I

        Dim TotalQT As Double = 0.0

        txtTotalQuote.Text = 0
        If dgPart.Rows.Count > 0 Then
            For I As Integer = 0 To (dgPart.Rows.Count - 1)
                TotalQT = 0
                For Each trw As DataGridViewRow In dgQty.Rows
                    If IsDBNull(dgPart.Rows(I).Cells("QDetLine").Value) = False And _
                            Nz.Nz(dgPart.Rows(I).Cells("QdetailID").Value) = Nz.Nz(trw.Cells("QdetailID").Value) Then
                        trw.Cells("QLineValue").Value = Nz.Nz(trw.Cells("QQty").Value) * Nz.Nz(trw.Cells("QQuotedPrice").Value)
                        If Len(Trim(txtQNO.Text)) = 0 Then      'new action
                            TotalQT = TotalQT + trw.Cells("QLineValue").Value
                        Else
                            If CmbQuoteNo.Text = txtQNO.Text Then
                                TotalQT = TotalQT + trw.Cells("QLineValue").Value
                            End If
                        End If
                        trw.Cells("QLineQty").Value = Nz.Nz(dgPart.Rows(I).Cells("QDetLine").Value)
                    End If
                Next
                If TotalQT <> 0 Then
                    dgPart.Rows(I).Cells("PartValue").Value = TotalQT.ToString("C2")
                End If
            Next
        End If

        TotalQT = 0
        For Each RPart As DataGridViewRow In dgPart.Rows
            TotalQT = TotalQT + RPart.Cells("PartValue").Value
        Next
        txtTotalQuote.Text = TotalQT.ToString("C2")

        If Len(Trim(txtQNO.Text)) > 0 Then
            txtTotalQuote.Text = 0
            TotalQT = 0
            dsMain.Tables("tblTemp").Clear()
            CallClass.PopulateAdapterAfterSearchInt("GetFindQuoteNoForCalculation", txtQNO.Text).Fill(dsMain, "tblTemp")

            For Each trw As DataRow In dsMain.Tables("tblTemp").Rows
                TotalQT = TotalQT + Nz.Nz(trw.Item("QQty")) * Nz.Nz(trw.Item("QQuotedPrice"))
            Next
            txtTotalQuote.Text = TotalQT.ToString("C2")
        End If

    End Sub

    Private Sub dgQty_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgQty.RowsRemoved
        If swDelete = 0 Then
            For Each trw As DataRow In dsMain.Tables("tblQuoteDetailQTy").Rows
                If trw.RowState = DataRowState.Deleted = True Then
                    trw.RejectChanges()
                    CalculGrid()
                End If
            Next
        End If

    End Sub

    Private Sub dgPart_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgPart.RowsRemoved
        If swDelete = 0 Then
            For Each trw As DataRow In dsMain.Tables("tblQuoteDetail").Rows
                If trw.RowState = DataRowState.Deleted = True Then
                    trw.RejectChanges()
                    CalculGrid()
                End If
            Next
        End If
    End Sub

    Private Sub CmdSeeCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeeCust.Click
        frmCustomer.SwForm.Text = CmbCust.SelectedIndex
        frmCustomer.ShowDialog()
    End Sub

    Private Sub CmbCust_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.DropDownClosed

        Dim swComm As String
        swComm = Nz.Nz(CmbCust.SelectedItem("SalesRepPer"))

        Me.ErrorProvider1.Clear()
        If Val(swComm) > 0 Then
            Me.ErrorProvider1.SetError(CmbCust, "!!! Attention !!! Sales Rep. Comission: " + swComm)
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If
     
    End Sub

    Private Sub CmbCust_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.GotFocus
        With Me.CmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
            .SelectedIndex = -1
        End With

        PutAttn()
    End Sub

    Private Sub CmbAttn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAttn.GotFocus
        PutAttn()
    End Sub

    Private Sub CmdHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdHeader.Click
        frmQuoteRemarks.SwFrom.Text = "Header"
        frmQuoteRemarks.ShowDialog()
    End Sub

    Private Sub CmdFooter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFooter.Click
        frmQuoteRemarks.SwFrom.Text = "Footer"
        frmQuoteRemarks.ShowDialog()
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        CheckPartNumber()

        If RoleEng(wkDeptCode) = False Then
            Dim I As Integer = 0
            For Each RPart As DataGridViewRow In dgPart.Rows
                For Each RQty As DataGridViewRow In dgQty.Rows
                    If Nz.Nz(RPart.Cells("QLineStatus").Value) = 60 Then
                        If Nz.Nz(RQty.Cells("QQuotedPrice").Value) > 0 Then
                            RPart.Cells("QLineStatus").Value = 80
                            I = I + 1
                        End If
                    End If
                Next
            Next
            If I >= 1 Then
                dgPart.Refresh()
                dgPart.EndEdit()

                ''To change the current row, to the last row:
                If dgPart.Rows.Count - 2 >= 2 Then
                    Dim cellLastRow As DataGridViewCell = dgPart.Rows(dgPart.Rows.Count - 2).Cells(2)
                    dgPart.CurrentCell = cellLastRow
                End If

                QuoteCurrency.EndCurrentEdit()
                DetailCurrency.EndCurrentEdit()
                QtyCurrency.EndCurrentEdit()

                Try
                    'If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    ModifyItemStatus()
                    dsMain.AcceptChanges()
                    'End If
                Catch ex As Exception
                    dsMain.RejectChanges()
                    MsgBox("Exception occured - Save Quote Item Status 80" & ex.Message)
                End Try
            End If
        End If

        Dim pvQnoCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvYesNoCollection As New CrystalDecisions.Shared.ParameterValues()

        Dim PdvQno As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvYesNo As New CrystalDecisions.Shared.ParameterDiscreteValue

        Try
            Dim rptPO As New rptQuoteNo()
            rptPO.Load("..\rptQuoteNo.rpt")

            PdvQno.Value = txtQNO.Text
            If ChkHist.Checked = True Then
                pdvYesNo.Value = 1
            Else
                pdvYesNo.Value = 0
            End If

            pvQnoCollection.Add(PdvQno)
            pvYesNoCollection.Add(pdvYesNo)

            rptPO.DataDefinition.ParameterFields("@txtQNO").ApplyCurrentValues(pvQnoCollection)
            rptPO.DataDefinition.ParameterFields("@ChkHist").ApplyCurrentValues(pvYesNoCollection)

            frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
            frmPOPrintAll.CrystalReportViewer1.Zoom(2)
            frmPOPrintAll.CrystalReportViewer1.ShowPrintButton = True
            frmPOPrintAll.CrystalReportViewer1.ShowExportButton = True
            frmPOPrintAll.ShowDialog()

            rptPO.Close()
            rptPO.Dispose()

        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Sub ModifyItemStatus()

        Dim II, JJ As Integer
        JJ = dgPart.Rows.Count
        For II = 1 To JJ - 1
            Dim cmdUpdate As SqlCommand = New SqlCommand("cspUpdateQuoteStatusWhenPrinting", cn)
            cmdUpdate.CommandType = CommandType.StoredProcedure

            Dim parQDetailID As SqlParameter = New SqlParameter("@QDetailID", SqlDbType.Int, 4)
            parQDetailID.Value = dgPart.Item("QDetailID", II - 1).Value
            cmdUpdate.Parameters.Add(parQDetailID)

            Dim parQStatus As SqlParameter = New SqlParameter("@QLineStatus", SqlDbType.Int, 4)
            parQStatus.Value = dgPart.Item("QLineStatus", II - 1).Value
            cmdUpdate.Parameters.Add(parQStatus)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cmdUpdate.ExecuteNonQuery()
                cmdUpdate.Dispose()
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Catch ex As SqlException
                MsgBox("Update Item Status: " & ex.Message)
            End Try
        Next

    End Sub

    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click
        Dim frm As New Form
        frm = frmQuoteBrowseAll
        frm.ShowDialog()
    End Sub

    Private Sub CmdPricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPricing.Click

        Dim pvQnoCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvYesNoCollection As New CrystalDecisions.Shared.ParameterValues()

        Dim PdvQno As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvYesNo As New CrystalDecisions.Shared.ParameterDiscreteValue

        Try
            Dim rptPO As New rptQuoteforPricingNew()
            rptPO.Load("..\rptQuoteforPricingNew.rpt")

            PdvQno.Value = txtQNO.Text
            If ChkHist.Checked = True Then
                pdvYesNo.Value = 1
            Else
                pdvYesNo.Value = 0
            End If

            pvQnoCollection.Add(PdvQno)
            pvYesNoCollection.Add(pdvYesNo)

            rptPO.DataDefinition.ParameterFields("@txtQNO").ApplyCurrentValues(pvQnoCollection)
            rptPO.DataDefinition.ParameterFields("@ChkHist").ApplyCurrentValues(pvYesNoCollection)

            frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
            frmPOPrintAll.CrystalReportViewer1.Zoom(2)
            frmPOPrintAll.CrystalReportViewer1.ShowPrintButton = True
            frmPOPrintAll.CrystalReportViewer1.ShowExportButton = True
            frmPOPrintAll.ShowDialog()

            rptPO.Close()
            rptPO.Dispose()

        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        Finally

        End Try

    End Sub

    Private Sub CmdMfgLead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMfgLead.Click

        Dim reply As DialogResult
        reply = MsgBox("Execute ? (Yes / No)", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then

            For I As Integer = 0 To (dgPart.Rows.Count - 1)
                For Each trw As DataRow In dsMain.Tables("tblQuoteDetailQty").Rows
                    If Nz.Nz(trw.Item("QdetailID")) = Nz.Nz(dgPart.Rows(I).Cells("QdetailID").Value) Then
                        trw.Item("QLeadTime") = CmbLeadTime.Text
                    End If
                Next
            Next I

        End If

    End Sub

    Private Sub CmdExpLead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExpLead.Click

        Dim reply As DialogResult
        reply = MsgBox("Execute ? (Yes / No)", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then

            For I As Integer = 0 To (dgPart.Rows.Count - 1)
                For Each trw As DataRow In dsMain.Tables("tblQuoteDetailQty").Rows
                    If Nz.Nz(trw.Item("QdetailID")) = Nz.Nz(dgPart.Rows(I).Cells("QdetailID").Value) Then
                        trw.Item("QExpLead") = CmbLeadTime.Text
                    End If
                Next
            Next I

        End If

    End Sub


    'Sub CalculMpoValue()
    '    Dim I As Integer = 0

    '    For I = 0 To dgQuote.Rows.Count - 1
    '        If IsDBNull(Me.dgQuote("QQuotedPrice", I).Value) = True Then
    '            Me.dgQuote("QMargin", I).Value = 0
    '        Else
    '            If Nz.Nz(Me.dgQuote("QQuotedPrice", I).Value) > 0 Then
    '                Me.dgQuote("QMargin", I).Value = (1 - (Nz.Nz(Me.dgQuote("QEstPrice", I).Value) / Nz.Nz(Me.dgQuote("QQuotedPrice", I).Value))) * 100
    '            Else
    '                Me.dgQuote("QMargin", I).Value = 0
    '            End If
    '        End If
    '    Next

    'End Sub

    Private Sub CmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSelect.Click

        For Each RPart As DataGridViewRow In dgPart.Rows
            If Nz.Nz(RPart.Cells("SWSelect").Value) = 0 And _
                Nz.Nz(RPart.Cells("QLineStatus").Value) <> 90 Then
                RPart.Cells("SWSelect").Value = True
            End If
        Next
    End Sub

    Private Sub CmdClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClosed.Click
        Dim reply As DialogResult
        reply = MsgBox("All the selected items will be closed. Continue (Y/N)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            'Dim II, JJ As Integer
            'JJ = dgPart.Rows.Count
            'For II = 1 To JJ - 1
            '    If Nz.Nz(dgPart.Item("SWSelect", II - 1)).value = "1" Then
            '        dgPart.Item("QLineStatus", II - 1).Value = 90
            '    End If
            'Next

            For Each RPart As DataGridViewRow In dgPart.Rows
                If Nz.Nz(RPart.Cells("SWSelect").Value) = "1" Then
                    RPart.Cells("QLineStatus").Value = 90
                End If
            Next
        End If

        ChkFollow.Checked = False

    End Sub

    Private Sub CmdCancelled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelled.Click
        Dim reply As DialogResult
        reply = MsgBox("All the selected items will be cancelled. Continue (Y/N)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            For Each RPart As DataGridViewRow In dgPart.Rows
                If Nz.Nz(RPart.Cells("SWSelect").Value) = "1" Then
                    RPart.Cells("QLineStatus").Value = 0
                End If
            Next
        End If

        ChkFollow.Checked = False
    End Sub

    Private Sub CmdUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUnSelect.Click

        For Each RPart As DataGridViewRow In dgPart.Rows
            If Nz.Nz(RPart.Cells("SWSelect").Value) = "1" And _
                Nz.Nz(RPart.Cells("QLineStatus").Value) <> 90 Then
                RPart.Cells("SWSelect").Value = False
            End If
        Next

    End Sub

    Private Sub CmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExcel.Click

        'Dim opendlg As New OpenFileDialog
        'opendlg.Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"
        'If opendlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Dim pathandfile As String = opendlg.FileName
        '    Dim connection As OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + _
        '    "data source=" & pathandfile & ";Extended Properties=Excel 8.0;")

        '    Dim adapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", connection)
        '    adapter.Fill(Me.dsMain.Tables("tblQuote1"))
        '    connection.Close()

        '    dgPart.AutoGenerateColumns = False
        '    dgPart.DataSource = dsMain
        '    dgPart.DataMember = "tblQuote1"
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim connect As System.Data.OleDb.OleDbConnection
        'Dim adapter As System.Data.OleDb.OleDbDataAdapter
        'Dim dataset As New System.Data.DataSet()
        'Dim opendlg As New OpenFileDialog

        'opendlg.Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"

        'If opendlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Dim pathname As String = opendlg.FileName
        '    connect = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + _
        '    "data source=" & pathname & ";Extended Properties=Excel 8.0;")
        '    'C:\testoledb.xls
        '    adapter = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", connect)
        '    connect.Open()
        '    adapter.Fill(dataset)
        '    Me.dgPart.DataSource = dataset.Tables(0)
        '    adapter.Fill(dataset.Tables(0))
        '    connect.Close()
        '    MsgBox(CType(dataset.Tables(0).Rows(0).Item(0), Object).ToString)
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim opendlg As New OpenFileDialog

        Dim cn11 As System.Data.OleDb.OleDbConnection
        Dim cmd As System.Data.OleDb.OleDbDataAdapter
        Dim ds As New System.Data.DataSet()
        opendlg.Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"
        If opendlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim pathname As String = opendlg.FileName
            cn11 = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + _
            "data source=" & pathname & ";Extended Properties=Excel 8.0;")
            cmd = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", cn11)
            cn11.Open()
            cmd.Fill(ds)
            cn11.Close()
            Dim rowCount As Integer = 0
            Dim coCount As Integer = 0
            rowCount = ds.Tables(0).Rows.Count
            coCount = ds.Tables(0).Columns.Count

            For I As Integer = 0 To ds.Tables(0).Rows.Count - 1
                For Each trw As DataRow In ds.Tables(0).Rows
                    'Dim ColumnNum As Integer

                    'Dim dgvr As DataGridViewRow = New System.Windows.Forms.DataGridViewRow()
                    'dgvr.CreateCells(dgPart)
                    'dgvr.Cells(1).Value = trw.Item(0)
                    'dgvr.Cells(2).Value = trw.Item(1)
                    'dgPart.Rows.Add(dgvr)
                    'dgPart.Item("QDetLine", I).Value = trw.Item(0)
                    'dgPart.Item("QdetPart", I).Value = trw.Item(1)
                    'dgPart.Rows = dgPart.newrow

                Next
            Next I
        End If


        ds.Dispose()
        'cmd.Dispose()
        'cn11.Close()

    End Sub

End Class