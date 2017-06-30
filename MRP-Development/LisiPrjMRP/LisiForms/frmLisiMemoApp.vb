Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text.UTF32Encoding
Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Imports System.Net
Imports System.Net.Mail

Public Class frmLisiMemoApp

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""
    Dim KeepNo As Integer = 0
    Dim SwFirst As Boolean = True   'first time
    Dim SwMemoID As Integer = 0
    Dim SwPath As String = ""


    Dim swMPOScrap As Boolean = False

    Dim CreateIR As Boolean = False
    Dim CreateRMA As Boolean = False

    Dim SwMEMOClose As Boolean = False ' close the memo

    Private Sub frmLisiMemoApp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub frmLisiMemoApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Call SetupForm()

    End Sub

    Sub SetupForm()

        HideCtl()
        DisableFields()

        SetCtlForm()

        InitFields()

        FirstTimeMenuButtons()

        InitialComponents()


        PutMemoNo()
        CmbMemo.Enabled = True
        CmbMemo.Focus()

        BindComponents()

        If ChAppr.Checked = True Then
            PanelSource.Visible = True
            PanelSource.Enabled = False

            PanelDescr.Visible = True
            PanelDescr.Enabled = False

            PanelDisp.Visible = True
            PanelDisp.Enabled = False

            PanelFinalDisp.Visible = True
            PanelFinalDisp.Enabled = False

            PanelCorrective.Visible = True
            PanelCorrective.Enabled = False
        End If

        If Len(Trim(SwFrom.Text)) <> 0 Then
            If SwFrom.Text = "QAINSP" Then
                If Len(Trim(SwValue.Text)) <> 0 Then
                    If SwValue.Text <> "New" Then
                        SwMemoID = SwValue.Text
                        CmbMemo.SelectedValue = SwValue.Text
                        PutMemoInfo()
                    Else
                        SwMemoID = 0
                        PutMemoInfo()
                    End If
                End If
            End If
        End If

        CheckViewRecord()


    End Sub

    Sub PutMemoNo()

        With Me.CmbMemo
            .DataSource = CallClass.PopulateComboBox("tblMemo", "cmbGetMemoNo").Tables("tblMemo")
            .DisplayMember = "MemoNo"
            .ValueMember = "MemoId"
        End With

    End Sub

    Sub PutUser()
        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEmployeeAll").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub PutPONo()
        With Me.CmbLisiPO
            .DataSource = CallClass.PopulateComboBox("tblPOMaster", "cmbGetPONoWithSuppName").Tables("tblPOMaster")
            .DisplayMember = "PONo"
            .ValueMember = "POMasterID"
        End With

    End Sub

    Sub PutCustPO()
        With Me.CmbCustPo
            .DataSource = CallClass.PopulateComboBox("tblCustOrder", "cmbGetCustOrderNo").Tables("tblCustOrder")
            .DisplayMember = "OrdNumber"
            .ValueMember = "OrderID"
        End With

    End Sub

    Sub PutMpoNo()
        With Me.CmbMpo
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterAllQtyDept").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
        End With
    End Sub

    Sub PutPartNo()
        With Me.CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub PutDept()
        With Me.CmbMpoDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutDeptQtyRej()
        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartmentForMEMO").Tables("tblDepartment")
            .DisplayMember = "DeptMemoDescr"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutVerApprBy()
        With Me.CmbVerifyBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetMemoVeify").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

        With Me.CmbApprBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetMemoAppr").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub HideCtl()

        PanelSource.Visible = False
        PanelDescr.Visible = False
        PanelDisp.Visible = False
        PanelCorrective.Visible = False
        PanelFinalDisp.Visible = False

        CmdViewTraining.Visible = False
        CmdViewOther.Visible = False

    End Sub

    Sub DisableFields()

        CmbStatus.Enabled = False
        CmbUser.Enabled = False

    End Sub

    Sub InitFields()

        CmbMemo.SelectedIndex = -1

        txtMemoKey.Text = ""
        CmbStatus.Text = ""
        CmbStatus.SelectedText = "Active"
        CmbUser.SelectedIndex = -1
        CmbPart.SelectedIndex = -1
        txtUserDept.Text = ""

        txtIR.Text = ""
        txtRMA.Text = ""

        txtMemoDate.Text = ""
        RdInternal.Checked = False
        RdSupplier.Checked = False
        RdCustomer.Checked = False

        CmbLisiPO.SelectedIndex = -1
        CmbCustPo.SelectedIndex = -1
        txtSupp.Text = ""
        txtCust.Text = ""
        txtSuppCert.Text = ""
        CmbMpo.SelectedIndex = -1
        txtMpoQty.Text = ""
        CmbDateSales.Text = ""
        CmbDateEng.Text = ""
        CmbDateQA.Text = ""

        txtPartRev.Text = ""
        txtMpoStatus.Text = ""
        CmbMpoDept.SelectedIndex = -1
        CmbObs.SelectedIndex = -1
        txtObs.Text = ""
        CmbApprBy.SelectedIndex = -1
        CmbVerifyBy.SelectedIndex = -1
        cmbDateVerify.Text = ""
        cmbDateAppr.Text = ""
        txtNCRNo.Text = ""
        txtMemoQtyRwk.Text = ""
        txtMemoQtyScrap.Text = ""
        txtMemoQtySort.Text = ""
        txtSeeMemo.Text = ""
        txtSNCRNo.Text = ""
        txtMemoNo.Text = ""
        txtCustSpecify.Text = ""
        txtSuppSpecify.Text = ""
        CmbDept.SelectedValue = -1

        RdDocYes.Checked = False
        RdDocNo.Checked = False

        ChNCR.Checked = False
        ChCust.Checked = False
        ChSupp.Checked = False
        ChSalesMessage.Checked = False
        ChEngMessage.Checked = False
        ChQAMessage.Checked = False

        ChPlant1.Checked = False
        ChPlant2.Checked = False
        ChPlant3.Checked = False
        ChPlant4.Checked = False

        ChAppr.Checked = False

        txtMPOCost.Text = ""
        txtAmount.Text = ""
        txtRwkQty.Text = ""
        txtRwkVal.Text = ""
        txtScrapQty.Text = ""
        txtScrapVal.Text = ""
        txtQtyAcc.Text = ""

        SwMEMOClose = False

        CmdIR.Enabled = False
        txtIR.ReadOnly = True

        CmdRMA.Enabled = False
        txtRMA.ReadOnly = True

        ChSystem.Checked = False
        RdQuality.Checked = False
        RdMfg.Checked = False
        RdTraining.Checked = False

        RdHelth.Checked = False
        RdSafety.Checked = False
        RdEnv.Checked = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdNew.Enabled = True
        CmdEdit.Enabled = True
        CmdSeeMemo.Enabled = True
        CmdSave.Enabled = False
        CmdPrint.Enabled = False
        CmdReset.Enabled = True

        CmdOpen.Visible = False

    End Sub


    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        'CallClass.PopulateDataAdapter("gettblMemoEmpty").FillSchema(dsMain, SchemaType.Source, "tblMemo")
        'CallClass.PopulateDataAdapter("gettblMemoDescrEmpty").FillSchema(dsMain, SchemaType.Source, "tblMemoDescr")
        'CallClass.PopulateDataAdapter("gettblMemoActionEmpty").FillSchema(dsMain, SchemaType.Source, "tblMemoAction")
        'CallClass.PopulateDataAdapter("gettblMemoReworkCardEmpty").FillSchema(dsMain, SchemaType.Source, "tblMemoReworkCard")
        'CallClass.PopulateDataAdapter("gettblMemoCorrectiveActionEmpty").FillSchema(dsMain, SchemaType.Source, "tblMemoCorrectiveAction")

        CallClass.PopulateDataAdapter("gettblMemoEmpty").Fill(dsMain, "tblMemo")
        'Dim MemID As DataColumn = dsMain.Tables("tblMemo").Columns("MemoId")
        'MemID.AutoIncrement = True
        'MemID.AutoIncrementStep = -1
        'MemID.AutoIncrementSeed = -1
        'MemID.ReadOnly = False

        CallClass.PopulateDataAdapter("gettblMemoDescrEmpty").Fill(dsMain, "tblMemoDescr")
        'Dim DesID As DataColumn = dsMain.Tables("tblMemoDescr").Columns("DescrID")
        'DesID.AutoIncrement = True
        'DesID.AutoIncrementStep = -1
        'DesID.AutoIncrementSeed = -1
        'DesID.ReadOnly = False

        CallClass.PopulateDataAdapter("gettblMemoActionEmpty").Fill(dsMain, "tblMemoAction")
        'Dim ActID As DataColumn = dsMain.Tables("tblMemoAction").Columns("ActionId")
        'ActID.AutoIncrement = True
        'ActID.AutoIncrementStep = -1
        'ActID.AutoIncrementSeed = -1
        'ActID.ReadOnly = False

        CallClass.PopulateDataAdapter("gettblMemoReworkCardEmpty").Fill(dsMain, "tblMemoReworkCard")
        'Dim RwkID As DataColumn = dsMain.Tables("tblMemoReworkCard").Columns("ReworkID")
        'RwkID.AutoIncrement = True
        'RwkID.AutoIncrementStep = -1
        'RwkID.AutoIncrementSeed = -1
        'RwkID.ReadOnly = False

        CallClass.PopulateDataAdapter("gettblMemoCorrectiveActionEmpty").Fill(dsMain, "tblMemoCorrectiveAction")
        'Dim CorrID As DataColumn = dsMain.Tables("tblMemoCorrectiveAction").Columns("CorrActionID")
        'CorrID.AutoIncrement = True
        'CorrID.AutoIncrementStep = -1
        'CorrID.AutoIncrementSeed = -1
        'CorrID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("MemoDescr", _
                .Tables("tblMemo").Columns("MemoId"), _
                .Tables("tblMemoDescr").Columns("MemoId"), True)
        End With

        With dsMain
            .Relations.Add("MemoAction", _
                .Tables("tblMemo").Columns("MemoId"), _
                .Tables("tblMemoAction").Columns("MemoId"), True)
        End With

        With dsMain
            .Relations.Add("MemoRwk", _
                .Tables("tblMemo").Columns("MemoId"), _
                .Tables("tblMemoReworkCard").Columns("MemoId"), True)
        End With

        With dsMain
            .Relations.Add("MemoCorr", _
                .Tables("tblMemo").Columns("MemoId"), _
                .Tables("tblMemoCorrectiveAction").Columns("MemoId"), True)
        End With

        dgDescr.AutoGenerateColumns = False
        dgDescr.DataSource = dsMain
        dgDescr.DataMember = "tblMemoDescr"

        dgAction.AutoGenerateColumns = False
        dgAction.DataSource = dsMain
        dgAction.DataMember = "tblMemoAction"

        dgRework.AutoGenerateColumns = False
        dgRework.DataSource = dsMain
        dgRework.DataMember = "tblMemoReworkCard"

        dgCorr.AutoGenerateColumns = False
        dgCorr.DataSource = dsMain
        dgCorr.DataMember = "tblMemoCorrectiveAction"

    End Sub

    Sub BindComponents()

        RdInternal.Checked = False
        RdSupplier.Checked = False
        RdCustomer.Checked = False

        ChSystem.Checked = False
        RdQuality.Checked = False
        RdMfg.Checked = False
        RdTraining.Checked = False

        RdHelth.Checked = False
        RdSafety.Checked = False
        RdEnv.Checked = False

        ChNCR.Checked = False
        ChCust.Checked = False
        ChSupp.Checked = False
        RdDocYes.Checked = False
        RdDocNo.Checked = False

        ChAppr.Checked = False


        txtIR.DataBindings.Clear()
        txtRMA.DataBindings.Clear()

        txtMemoKey.DataBindings.Clear()
        txtUserDept.Text = ""
        txtMemoDate.DataBindings.Clear()
        txtMemoNo.DataBindings.Clear()
        'txtUserDept.DataBindings.Clear()
        txtSuppCert.DataBindings.Clear()
        txtMpoQty.DataBindings.Clear()

        CmbDateSales.DataBindings.Clear()
        CmbDateEng.DataBindings.Clear()
        CmbDateQA.DataBindings.Clear()

        txtObs.DataBindings.Clear()
        txtNCRNo.DataBindings.Clear()
        txtMemoQtyRwk.DataBindings.Clear()
        txtMemoQtyScrap.DataBindings.Clear()
        txtMemoQtySort.DataBindings.Clear()
        txtSNCRNo.DataBindings.Clear()
        txtSeeMemo.DataBindings.Clear()
        txtCustSpecify.DataBindings.Clear()
        txtSuppSpecify.DataBindings.Clear()


        ChSystem.DataBindings.Clear()
        RdQuality.DataBindings.Clear()
        RdMfg.DataBindings.Clear()
        RdTraining.DataBindings.Clear()

        RdHelth.DataBindings.Clear()
        RdSafety.DataBindings.Clear()
        RdEnv.DataBindings.Clear()

        RdInternal.DataBindings.Clear()
        RdSupplier.DataBindings.Clear()
        RdCustomer.DataBindings.Clear()
        ChNCR.DataBindings.Clear()
        ChCust.DataBindings.Clear()
        ChSupp.DataBindings.Clear()
        RdDocYes.DataBindings.Clear()
        RdDocNo.DataBindings.Clear()

        ChAppr.DataBindings.Clear()


        CmbDept.DataBindings.Clear()
        CmbStatus.DataBindings.Clear()
        CmbUser.DataBindings.Clear()
        CmbLisiPO.DataBindings.Clear()
        CmbCustPo.DataBindings.Clear()
        CmbMpo.DataBindings.Clear()
        CmbMpoDept.DataBindings.Clear()
        CmbVerifyBy.DataBindings.Clear()
        CmbApprBy.DataBindings.Clear()
        cmbDateAppr.Text = ""
        cmbDateAppr.DataBindings.Clear()
        cmbDateVerify.DataBindings.Clear()

        'CmbMemo.DataBindings.Clear()

        txtMemoNo.DataBindings.Add("Text", dsMain, "tblMemo.MemoNo")
        txtMemoKey.DataBindings.Add("Text", dsMain, "tblMemo.MemoNoPrefix")
        txtMemoDate.DataBindings.Add("Text", dsMain, "tblMemo.CreatedDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        txtIR.DataBindings.Add("Text", dsMain, "tblMemo.MemoIR")
        txtRMA.DataBindings.Add("Text", dsMain, "tblMemo.MemoRMA")
        txtSuppCert.DataBindings.Add("Text", dsMain, "tblMemo.SuppCertNo")
        txtMpoQty.DataBindings.Add("Text", dsMain, "tblMemo.MpoQty")
        txtObs.DataBindings.Add("Text", dsMain, "tblMemo.ObsList")
        txtNCRNo.DataBindings.Add("Text", dsMain, "tblMemo.NCRNo")
        txtMemoQtyRwk.DataBindings.Add("Text", dsMain, "tblMemo.MemoQtyRwk")
        txtMemoQtyScrap.DataBindings.Add("Text", dsMain, "tblMemo.MemoQtyScrap")
        txtMemoQtySort.DataBindings.Add("Text", dsMain, "tblMemo.MemoQtySort")
        txtSNCRNo.DataBindings.Add("Text", dsMain, "tblMemo.SNCRNo")
        txtSeeMemo.DataBindings.Add("Text", dsMain, "tblMemo.SeeMemoNo")
        txtCustSpecify.DataBindings.Add("Text", dsMain, "tblMemo.CustSpecify")
        txtSuppSpecify.DataBindings.Add("Text", dsMain, "tblMemo.SuppSpecify")

        CmbStatus.DataBindings.Add("Text", dsMain, "tblMemo.MemoStatus")
        CmbDept.DataBindings.Add("SelectedValue", dsMain, "tblMemo.DeptQtyRej")
        CmbUser.DataBindings.Add("SelectedValue", dsMain, "tblMemo.CreatedUser")
        CmbLisiPO.DataBindings.Add("SelectedValue", dsMain, "tblMemo.PoNoID")
        CmbCustPo.DataBindings.Add("SelectedValue", dsMain, "tblMemo.CustPoID")
        CmbMpo.DataBindings.Add("SelectedValue", dsMain, "tblMemo.MPOID")
        CmbMpoDept.DataBindings.Add("SelectedValue", dsMain, "tblMemo.MpoDept")
        CmbVerifyBy.DataBindings.Add("SelectedValue", dsMain, "tblMemo.VerifyBy")
        CmbApprBy.DataBindings.Add("SelectedValue", dsMain, "tblMemo.ApprBy")
        cmbDateAppr.DataBindings.Add("Text", dsMain, "tblMemo.ApprDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        cmbDateVerify.DataBindings.Add("Text", dsMain, "tblMemo.VerifyDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        CmbDateSales.DataBindings.Add("Text", dsMain, "tblMemo.SalesDateMessage", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        CmbDateEng.DataBindings.Add("Text", dsMain, "tblMemo.EngDateMessage", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        CmbDateQA.DataBindings.Add("Text", dsMain, "tblMemo.QADateMessage", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")

        RdInternal.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalSource", True))

        ChSystem.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.ApprSystem", True))
        RdMfg.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalMfg", True))
        RdQuality.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalQuality", True))
        RdTraining.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalTraining", True))

        RdHelth.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalHelth", True))
        RdSafety.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalSafety", True))
        RdEnv.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.InternalEnvironment", True))


        RdSupplier.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.SupplierSource", True))
        RdCustomer.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.CustomerSource", True))
        RdDocYes.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.DocConfYes", True))
        RdDocNo.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.DocConfNo", True))
        ChNCR.DataBindings.Add(New Binding("CheckState", dsMain, "tblMemo.NCRReq", True))
        ChCust.DataBindings.Add(New Binding("CheckState", dsMain, "tblMemo.CustNotificationReq", True))
        ChSupp.DataBindings.Add(New Binding("CheckState", dsMain, "tblMemo.SuppNotificationReq", True))

        ChAppr.DataBindings.Add(New Binding("Checked", dsMain, "tblMemo.ApprCheck", True))


        If IsNothing(CmbUser.SelectedItem) = False And IsDBNull(CmbUser.SelectedItem) = False Then
            txtUserDept.Text = CmbUser.SelectedItem("EmpDept")
        End If

        If IsNothing(CmbLisiPO.SelectedItem) = False Then
            txtSupp.Text = Nz.Nz(CmbLisiPO.SelectedItem("SuppName"))
        End If

        CmdCancelled.Enabled = False

        If IsNothing(CmbMpo.SelectedItem) = False Then
            If Val(txtMpoQty.Text) = 0 Then
                txtMpoQty.Text = Nz.Nz(CmbMpo.SelectedItem("QtyActual"))
            End If

            txtMpoStatus.Text = Nz.Nz(CmbMpo.SelectedItem("MpoStatus"))
            CmbMpoDept.SelectedValue = Nz.Nz(CmbMpo.SelectedItem("DeptID"))
            CmbPart.SelectedValue = CallClass.ReturnStrWithParInt("cspReturnPartIDWithMPOID", CmbMpo.SelectedValue)

            If IsDBNull(CmbMpo.SelectedItem("MpoPartRev")) = True Then
                txtPartRev.Text = ""
            Else
                txtPartRev.Text = CmbMpo.SelectedItem("MpoPartRev")
            End If

            If IsNothing(CmbCustPo.SelectedItem) = False Then
                txtCust.Text = Nz.Nz(CmbCustPo.SelectedItem("CustomerName"))
            End If

            If txtMpoStatus.Text = "Active" Then
                CmdCancelled.Enabled = True     'yes we can cancelled
            Else
                CmdCancelled.Enabled = False    'NO we can not cancelled
            End If

        End If

        If IsDBNull(ChNCR.Text) = True Then
            ChNCR.Checked = False
        End If
        If IsDBNull(ChCust.Text) = True Then
            ChCust.Checked = False
        End If
        If IsDBNull(ChSupp.Text) = True Then
            ChSupp.Checked = False
        End If

        If IsDBNull(RdDocYes.Text) = True Then
            RdDocYes.Checked = False
        End If
        If IsDBNull(RdDocNo.Text) = True Then
            RdDocNo.Checked = False
        End If

        If IsDBNull(RdInternal.Text) = True Then
            RdInternal.Checked = False
        End If
        If IsDBNull(RdSupplier.Text) = True Then
            RdSupplier.Checked = False
        End If
        If IsDBNull(RdCustomer.Text) = True Then
            RdCustomer.Checked = False
        End If

        Select Case (CmbStatus.Text)
            Case "Active"
            Case "Closed"
                MsgBox("This MEMO has been Closed.")
                DisableFields()
                ViewDisable()
            Case "Cancelled"
                MsgBox("This MEMO has been Cancelled.")
                DisableFields()
                ViewDisable()
        End Select

    End Sub

    Function RoleOpen(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "OPENMEMO" Then
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

    Function RoleDispText(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MEMODISPTEXT" Then
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


    Function RoleProd(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "PROD" Then
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

    Function RoleAppr(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MEMOAPPR" Then
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

    Function RoleVer(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "MEMOVER" Then
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

    Sub ViewEnableUser()

        If RoleAppr(wkDeptCode) = True Then
            ViewEnableAppr()
        Else
            If RoleVer(wkDeptCode) = True Then
                ViewEnableVer()
            Else
                PanelSource.Visible = True
                PanelSource.Enabled = True

                PanelDescr.Visible = True
                PanelDescr.Enabled = True

                CmbVerifyBy.Enabled = False
                cmbDateVerify.Enabled = False

                PanelDisp.Visible = True
                PanelDisp.Enabled = False

                PanelCorrective.Visible = True
                PanelCorrective.Enabled = False

                PanelFinalDisp.Visible = True
                PanelFinalDisp.Enabled = False

                If ChAppr.Checked = True Then
                    PanelSource.Visible = True
                    PanelSource.Enabled = False

                    PanelDescr.Visible = True
                    PanelDescr.Enabled = False

                    PanelDisp.Visible = True
                    PanelDisp.Enabled = False

                    PanelFinalDisp.Visible = True
                    PanelFinalDisp.Enabled = False

                    PanelCorrective.Visible = True
                    PanelCorrective.Enabled = False
                End If

            End If
        End If

    End Sub

    Sub ViewEnableAppr()

        PanelSource.Visible = True
        PanelSource.Enabled = True

        PanelDescr.Visible = True
        PanelDescr.Enabled = True

        PanelDisp.Visible = True
        PanelDisp.Enabled = True
        If RoleDispText(wkDeptCode) = True Then
            CmdDisp.Enabled = True
        Else
            CmdDisp.Enabled = False
        End If

        PanelFinalDisp.Visible = True
        PanelFinalDisp.Enabled = True

        PanelCorrective.Visible = True
        PanelCorrective.Enabled = True

        If ChAppr.Checked = True Then
            PanelSource.Visible = True
            PanelSource.Enabled = False

            PanelDescr.Visible = True
            PanelDescr.Enabled = False

            PanelDisp.Visible = True
            PanelDisp.Enabled = False

            PanelFinalDisp.Visible = True
            PanelFinalDisp.Enabled = False

            PanelCorrective.Visible = True
            PanelCorrective.Enabled = True
        End If

    End Sub

    Sub ViewEnableVer()

        PanelSource.Visible = True
        PanelSource.Enabled = True

        PanelDescr.Visible = True
        PanelDescr.Enabled = True

        PanelDisp.Visible = True
        PanelDisp.Enabled = True
        If RoleDispText(wkDeptCode) = True Then
            CmdDisp.Enabled = True
        Else
            CmdDisp.Enabled = False
        End If

        PanelCorrective.Visible = True
        PanelCorrective.Enabled = False

        PanelFinalDisp.Visible = True
        PanelFinalDisp.Enabled = False

        If ChAppr.Checked = True Then
            PanelSource.Visible = True
            PanelSource.Enabled = False

            PanelDescr.Visible = True
            PanelDescr.Enabled = False

            PanelDisp.Visible = True
            PanelDisp.Enabled = False

            PanelFinalDisp.Visible = True
            PanelFinalDisp.Enabled = False

            PanelCorrective.Visible = True
            PanelCorrective.Enabled = False
        End If

    End Sub

    Sub ViewDisable()

        PanelSource.Visible = True
        PanelSource.Enabled = False

        PanelDescr.Visible = True
        PanelDescr.Enabled = False

        PanelDisp.Visible = True
        PanelDisp.Enabled = False

        PanelCorrective.Visible = True
        PanelCorrective.Enabled = False

        PanelFinalDisp.Visible = True
        PanelFinalDisp.Enabled = False

        If SwOper = "Save" Then
            Exit Sub
        Else
            If CmbStatus.Text = "Active" Then
                Exit Sub
            Else
                If RoleOpen(wkDeptCode) = True Then
                    PanelFinalDisp.Visible = True
                    PanelFinalDisp.Enabled = True
                    CmdOpen.Visible = True
                    CmdOpen.Enabled = True
                    CmdClose.Enabled = False
                    CmdCancelled.Enabled = False
                End If
            End If
        End If

    End Sub

    Sub SetCtlForm()

        PutUser()
        PutPONo()
        PutCustPO()
        PutDept()
        PutDeptQtyRej()
        PutMpoNo()
        PutPartNo()
        PutVerApprBy()

        'For dgDescr properies

        With Me.DescrID
            .DataPropertyName = "DescrID"
            .Name = "DescrID"
            .Visible = False
        End With

        With Me.MemoID
            .DataPropertyName = "MemoID"
            .Name = "MemoID"
            .Visible = False
        End With

        With Me.ItemNo
            .DataPropertyName = "ItemNo"
            .Name = "ItemNo"
        End With

        With Me.Requirement
            .DataPropertyName = "Requirement"
            .Name = "Requirement"
        End With

        With Me.ActualCondition
            .DataPropertyName = "ActualCondition"
            .Name = "ActualCondition"
        End With

        With Me.OperNo
            .DataPropertyName = "OperNo"
            .Name = "OperNo"
        End With

        With Me.TypeDescr
            .DataPropertyName = "TypeDescr"
            .Name = "TypeDescr"
        End With

        With Me.QtyInsp
            .DataPropertyName = "QtyInsp"
            .Name = "QtyInsp"
        End With

        With Me.QtyRej
            .DataPropertyName = "QtyRej"
            .Name = "QtyRej"
        End With

        With Me.DefCode
            .DataSource = CallClass.PopulateComboBox("tblDefectCodes", "cmbGetDefectCodes").Tables("tblDefectCodes")
            .DisplayMember = "FullDesc"
            .ValueMember = "DefCodeId"
            .DropDownWidth = 300
            .MaxDropDownItems = 40
            .DataPropertyName = "DefCode"
            .Name = "DefCode"
        End With

        'For dgAction properies

        With Me.ActionId
            .DataPropertyName = "ActionId"
            .Name = "ActionId"
            .Visible = False
        End With

        With Me.MemoIdAction
            .DataPropertyName = "MemoId"
            .Name = "MemoId"
            .Visible = False
        End With

        With Me.ItemNoAction
            .DataPropertyName = "ItemNo"
            .Name = "ItemNo"
        End With

        With Me.ActionDescr
            .DataPropertyName = "ActionDescr"
            .Name = "ActionDescr"
        End With

        With Me.ActionPrice
            .DataPropertyName = "ActionPrice"
            .Name = "ActionPrice"
        End With

        With Me.ActionQty
            .DataPropertyName = "ActionQty"
            .Name = "ActionQty"
        End With

        With Me.ActionValue
            .DataPropertyName = "ActionValue"
            .Name = "ActionValue"
        End With

        'For dgRework properies

        With Me.ReworkID
            .DataPropertyName = "ReworkID"
            .Name = "ReworkID"
            .Visible = False
        End With

        With Me.MemoIdRWK
            .DataPropertyName = "MemoId"
            .Name = "MemoId"
            .Visible = False
        End With

        With Me.ItemNoRWK
            .DataPropertyName = "ItemNo"
            .Name = "ItemNo"
        End With

        With Me.ReworkDescr
            .DataPropertyName = "ReworkDescr"
            .Name = "ReworkDescr"
        End With

        With Me.Qtyrework
            .DataPropertyName = "Qtyrework"
            .Name = "Qtyrework"
        End With

        With Me.QtyAct
            .DataPropertyName = "QtyAct"
            .Name = "QtyAct"
        End With

        With Me.OperatorID
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetOperator").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
            .DataPropertyName = "OperatorID"
            .Name = "OperatorID"
        End With

        With Me.OperHr
            .DataPropertyName = "OperHr"
            .Name = "OperHr"
        End With

        With Me.RwkRate
            .DataPropertyName = "RwkRate"
            .Name = "RwkRate"
        End With


        'For dgCorr 

        With Me.CorrActionID
            .DataPropertyName = "CorrActionID"
            .Name = "CorrActionID"
            .Visible = False
        End With

        With Me.CorrMemoID
            .DataPropertyName = "MemoID"
            .Name = "MemoID"
        End With

        With Me.CorrItem
            .DataPropertyName = "CorrItem"
            .Name = "CorrItem"
        End With

        With Me.CorrDescr
            .DataPropertyName = "CorrDescr"
            .Name = "CorrDescr"
        End With

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        dsMain.RejectChanges()
        InitFields()
        SwOper = ""
        HideCtl()
        DisableFields()
        FirstTimeMenuButtons()
        CmdEdit.Enabled = False

        CmbMemo.Enabled = True

        CmbMemo.SelectedValue = SwMemoID
        CmbMemo.Focus()


    End Sub

    Private Sub dgDescr_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDescr.DataError
        REM end
    End Sub

    Private Sub dgAction_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgAction.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            SwRowAction.Text = e.RowIndex
        End If

        If dgDescr.Rows.Count - 1 = 0 Then
            MsgBox("Please enter before the description requirement.")
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub dgAction_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAction.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            SwRowAction.Text = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 4
                frmMemoDispRemarks.txtFrom.Text = "DataGrid"
                frmMemoDispRemarks.ShowDialog()
        End Select

    End Sub

    Private Sub dgAction_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAction.CellEnter
        'dgAction("ActionValue", e.RowIndex).Value = Nz.Nz(dgAction("ActionPrice", e.RowIndex).Value) * Nz.Nz(dgAction("ActionQty", e.RowIndex).Value)
        If SwOper = "Save" Then
            Exit Sub
        Else
            CalculValue()
        End If
    End Sub

    Private Sub dgAction_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgAction.DataError
        REM end
    End Sub

    Private Sub dgRework_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgRework.CellBeginEdit

        If dgDescr.Rows.Count - 1 = 0 Then
            MsgBox("Please enter before the description requirement.")
            e.Cancel = True
            Exit Sub
        End If

        Select Case e.ColumnIndex

            Case 4
                If Val(txtMpoQty.Text) = 0 Then
                    MsgBox("Please select the production MPO.")
                    e.Cancel = True
                End If
            Case 5
                If IsDBNull(dgRework("Qtyrework", e.RowIndex).Value) = True Then
                    e.Cancel = True
                End If
            Case 8
                If IsDBNull(dgRework("Qtyrework", e.RowIndex).Value) = True Then
                    MsgBox("Please enter before Qty Rework.")
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgRework_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRework.CellEndEdit

        Select Case e.ColumnIndex

            Case 4      'rejected quantity
                If IsDBNull(dgRework("Qtyrework", e.RowIndex).Value) = False Then
                    If Nz.Nz(dgRework("Qtyrework", e.RowIndex).Value) > Val(txtMpoQty.Text) Then
                        MsgBox("Qty Rej. > MPO Actual Qty.")
                        dgRework("Qtyrework", e.RowIndex).Value = DBNull.Value
                    End If
                End If

                dgRework("QtyAct", e.RowIndex).Value = DBNull.Value
                dgRework("QtyRwkRej", e.RowIndex).Value = DBNull.Value
                dgRework("SwRwkValue", e.RowIndex).Value = DBNull.Value

            Case 5  'accepted quantiy
                If IsDBNull(dgRework("QtyAct", e.RowIndex).Value) = False Then
                    If dgRework("QtyAct", e.RowIndex).Value > dgRework("Qtyrework", e.RowIndex).Value Then
                        MsgBox("Accepted Qty > Rejected Qty.")
                        dgRework("QtyAct", e.RowIndex).Value = DBNull.Value
                    Else
                        dgRework("QtyRwkRej", e.RowIndex).Value = dgRework("Qtyrework", e.RowIndex).Value - dgRework("QtyAct", e.RowIndex).Value
                    End If
                End If

            Case 9  'rework rate
                dgRework("SwRwkValue", e.RowIndex).Value = dgRework("OperHr", e.RowIndex).Value * _
                                                            dgRework("RwkRate", e.RowIndex).Value

        End Select

    End Sub

    Private Sub dgRework_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRework.CellEnter
        If SwOper = "Save" Then
            Exit Sub
        Else
            CalculRwk()
        End If
    End Sub

    Private Sub dgRework_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRework.DataError
        REM end
    End Sub

    Private Sub CmbMpo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMpo.DropDownClosed

        If IsNothing(CmbMpo.SelectedItem) = False Then

            If Val(txtMpoQty.Text) = 0 Then
                txtMpoQty.Text = Nz.Nz(CmbMpo.SelectedItem("QtyActual"))
            End If
            txtMpoQty.Text = Nz.Nz(CmbMpo.SelectedItem("QtyActual"))
            txtMpoStatus.Text = Nz.Nz(CmbMpo.SelectedItem("MpoStatus"))

            CmbMpoDept.SelectedValue = Nz.Nz(CmbMpo.SelectedItem("DeptID"))
            CmbPart.SelectedValue = CallClass.ReturnStrWithParInt("cspReturnPartIDWithMPOID", CmbMpo.SelectedValue)
            If IsDBNull(CmbMpo.SelectedItem("MpoPartRev")) = True Then
                txtPartRev.Text = ""
            Else
                txtPartRev.Text = CmbMpo.SelectedItem("MpoPartRev")
            End If
        End If

    End Sub

    Private Sub CmbLisiPO_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLisiPO.DropDownClosed

        If IsNothing(CmbLisiPO.SelectedItem) = False Then
            txtSupp.Text = Nz.Nz(CmbLisiPO.SelectedItem("SuppName"))
            RdInternal.Checked = False
            RdSupplier.Checked = True
            RdCustomer.Checked = False
        End If

    End Sub

    Private Sub CmbCustPo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCustPo.DropDownClosed

        If IsNothing(CmbCustPo.SelectedItem) = False Then
            txtCust.Text = Nz.Nz(CmbCustPo.SelectedItem("CustomerName"))
            RdInternal.Checked = False
            RdSupplier.Checked = False
            RdCustomer.Checked = True
        End If

    End Sub

    Private Sub CmbObs_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbObs.DropDownClosed

        txtObs.Focus()

        If Len(Trim(txtObs.Text)) = 0 = True Or IsDBNull(txtObs.Text) = True Then
            txtObs.Text = CmbObs.SelectedItem
        Else
            txtObs.Text = txtObs.Text + vbCrLf + CmbObs.SelectedItem
        End If
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Me.Cursor = Cursors.WaitCursor

        SwOper = "Save"

        If CreateIR = True And CreateRMA = True Then
            MsgBox("You can not create an IR No. and RMA No. on the same MEMO.")
            SwVal = False
            Exit Sub
        End If

        If CreateIR = True Then
            PickIR()
        Else
            If CreateRMA = True Then
                PickRMA()
            End If
        End If

        dgDescr.EndEdit()
        dgAction.EndEdit()
        dgRework.EndEdit()
        dgCorr.EndEdit()

        dgDescr.Focus()
        dgDescr.Refresh()
        dgAction.Focus()
        dgAction.Refresh()
        dgRework.Focus()
        dgRework.Refresh()
        dgCorr.Focus()
        dgCorr.Refresh()
        PanTool.Focus()
        PanelSource.Focus()
        PanelDescr.Focus()
        PanelCorrective.Focus()
        PanelFinalDisp.Focus()

        txtMemoKey.Focus()
        CmdPrint.Focus()
        dgCorr.Focus()
        txtMemoKey.Focus()
        CmbPart.Focus()

        Call ValPo()

        If SwVal = False Then
            Exit Sub
        End If

        If Len(Trim(txtMemoKey.Text)) = 0 Then

            PutMemoNumber()

            If txtMemoNo.Text = "ERROR" Then
                MsgBox("!!! ERROR !!! - MEMO number can not be generated. Action Denied. Try again to SAVE.")
                GoTo EXITFORCE
                Exit Sub
            End If
        End If

        Me.BindingContext(dsMain, "tblMemo").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblMemoDescr").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblMemoAction").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblMemoReworkCard").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblMemoCorrectiveAction").EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                UpdateMemo(dsMain.GetChanges)

                '==================
                SwMemoID = 0
                strSQL = "SELECT tblMemo.MemoID FROM tblMemo WHERE ((tblMemo.MemoNo)= '" & txtMemoNo.Text & "')"

                Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, cn)
                Dim myReader As Data.SqlClient.SqlDataReader
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                Try
                    myReader = mySqlComm.ExecuteReader()

                    Dim TestRec As Int16
                    TestRec = myReader.HasRows
                    If TestRec <> -1 Then
                        MessageBox.Show("!!! ERROR DATABASE!!!! Find Memo Number")
                        Exit Sub
                    Else
                        While myReader.Read()
                            SwMemoID = myReader.GetValue(0)
                        End While
                        myReader.Close()
                        myReader.Dispose()
                    End If
                Catch ex As Exception
                    MsgBox("Exception occured - When try to identify the Memo No   " & ex.Message)
                    Exit Sub
                End Try

                If SwMemoID > 0 Then
                    UpdateMemoAllInfo(dsMain.GetChanges)
                    MsgBox("Update successfully.")

                    'Dim email As New Mail.MailMessage()
                    'Dim strBody As String = ""
                    'email.Subject = " !!! WARNING !!!"
                    'strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created in MRP." + vbCrLf
                    'email.Body = strBody

                    'Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                    'email.From = New Net.Mail.MailAddress(wkEmpEmail)
                    'email.To.Add(New Mail.MailAddress("marcel.quirion@lisi-aerospace.com"))
                    'client.Send(email)

                Else
                    MsgBox("Update for the info MEMO faild.")
                End If
            End If

        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured - " & ex.Message)
        End Try

        dsMain.AcceptChanges()


        If RdSupplier.Checked = True Then
            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = " !!! WARNING !!!"
            strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
            strBody = strBody + "LAC PO Number : " + CmbLisiPO.Text + vbCrLf
            strBody = strBody + "Supplier Name : " + txtSupp.Text
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Comptabilite.Montreal@lisi-aerospace.com"))
            email.To.Add(New Mail.MailAddress("Planning.Montreal@lisi-aerospace.com"))
            client.Send(email)
        End If

        If SwMEMOClose = True Then
            'close memo
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMEMOStatus", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMemoID As SqlParameter = New SqlParameter("@MemoId", SqlDbType.Int, 4)
            paraMemoID.Value = CmbMemo.SelectedValue
            mySqlComm.Parameters.Add(paraMemoID)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("!!! ERROR !!! Update MEMO Status: " & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

        If txtMpoStatus.Text = "Active" Then
            If swMPOScrap = True Then
                'Scrapped MPO
                Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOCancelled", cn)
                mySqlComm.CommandType = CommandType.StoredProcedure

                Dim paraMPOID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
                paraMPOID.Value = CmbMpo.SelectedValue
                mySqlComm.Parameters.Add(paraMPOID)

                Try
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Open()
                    mySqlComm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("!!! ERROR !!! Update MPO Cancelled: " & ex.Message)
                Finally
                    cn.Close()
                    Dim email As New Mail.MailMessage()
                    Dim strBody As String = ""
                    email.Subject = " !!! WARNING !!!"
                    strBody = "The MPO Number :   " + CmbMpo.Text + "   was Scrapped in MRP." + vbCrLf
                    strBody = strBody + "LAC MEMO Number : " + CmbMemo.Text
                    email.Body = strBody

                    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                    email.From = New Net.Mail.MailAddress(wkEmpEmail)
                    email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
                    client.Send(email)
                End Try
            End If
        End If

        swMPOScrap = False

        KeepNo = Val(txtMemoNo.Text)

        If ChPlant1.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! WARNING !!!"
                strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Vincent.PILLAI@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Michael.BROKAMP@lisi-aerospace.com"))
                client.Send(email)
            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChPlant2.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! WARNING !!!"
                strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Vincent.PILLAI@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Marc.CHICOINE@lisi-aerospace.com"))
                client.Send(email)
            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChPlant3.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! WARNING !!!"
                strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Vincent.PILLAI@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Gilles.GAUTHIER@lisi-aerospace.com"))
                client.Send(email)
            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChPlant4.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! WARNING !!!"
                strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Vincent.PILLAI@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("TheTrung.HUYNH@lisi-aerospace.com"))
                client.Send(email)
            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChSalesMessage.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " !!! WARNING !!!"
                strBody = "MPO Number:   " + CmbMpo.Text + "   MEMO Quantity Scrapped:  " + txtMemoQtyScrap.Text + vbCrLf
                strBody = strBody + "LAC MEMO Number : " + txtMemoNo.Text
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Planning.Montreal@lisi-aerospace.com"))
                client.Send(email)

            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChEngMessage.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then
                CmbDateEng.Text = Date.Now.ToShortDateString

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " MEMO "
                strBody = "Please review the memo number:  " + txtMemoNo.Text + "  which may require your action or attention for taking corrective action." + vbCrLf
                strBody = strBody + "Contact quality assurance if additional information is required."
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("mariusz.jaworski@lisi-aerospace.com"))
                client.Send(email)

            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If ChQAMessage.Checked = True Then
            If Len(Trim(txtMemoNo.Text)) > 0 Then
                CmbDateQA.Text = Date.Now.ToShortDateString
                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = " MEMO "
                strBody = "Disposition has been taken and require additional information." + vbCrLf
                strBody = strBody + "Please review the memo number:  " + txtMemoNo.Text + "  which may require your action or attention for taking corrective action."
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("qualite.montreal@lisi-aerospace.com"))
                client.Send(email)

            Else
                MsgBox("!!! ERROR !!! Action Denied. You need first to create the MEMO.")
            End If
        End If

        If Len(Trim(txtRMA.Text)) > 0 Then

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = " !!! RMA !!!"
            strBody = "The MEMO Number :   " + txtMemoNo.Text + "   was Created / Modified in MRP." + vbCrLf
            strBody = strBody + "Customer PO Number : " + CmbCustPo.Text + vbCrLf
            strBody = strBody + "Customer Name      : " + txtCust.Text()
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Comptabilite.Montreal@lisi-aerospace.com"))
            client.Send(email)

        End If

        CmdPrint.Enabled = True
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSeeMemo.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True

        SwOper = ""
        SwMEMOClose = False

        PutMemoNo()
        DisableFields()
        ViewDisable()

EXITFORCE:

        Me.Cursor = Cursors.Default

    End Sub

    Sub PutMemoNumber()

        txtMemoNo.Text = CallClass.GenerateNextLot("cspGetNextLot", "MEMONO")
        If txtMemoNo.Text = "ERROR" Then
            Exit Sub
        Else
            KeepNo = Val(txtMemoNo.Text)
            txtMemoNo.Text = Trim(txtMemoNo.Text)
            txtMemoKey.Text = Trim(txtUserDept.Text) + "-" + Trim(txtMemoNo.Text)

            UpdateNextLot()
        End If

    End Sub

    Sub UpdateNextLot()
        CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "MEMONO", KeepNo)
    End Sub

    Sub ValPo()

        If ChAppr.CheckState = CheckState.Unchecked Then
            ChAppr.Checked = False
        End If

        If ChSystem.CheckState = CheckState.Unchecked Then
            ChSystem.Checked = False
        End If

        If RdSupplier.Checked = True Then
            If Len(Trim(CmbLisiPO.SelectedValue)) = 0 Or IsDBNull(CmbUser.SelectedValue) = True Or IsNothing(CmbUser.SelectedValue) = True Then
                MsgBox("!!! ERROR !!! PO Supplier is Empty.")
                SwVal = False
                Exit Sub
            End If

            If Len(Trim(txtSuppCert.Text)) = 0 Or IsDBNull(txtSuppCert.Text) = True Or IsNothing(txtSuppCert.Text) = True Then
                MsgBox("!!! ERROR !!! Supplier Cert. No. is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Len(Trim(CmbStatus.Text)) = 0 Or IsDBNull(CmbStatus.Text) = True Or IsNothing(CmbStatus.Text) = True Then
            MsgBox("!!! ERROR !!! Memo Status is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbUser.SelectedValue)) = 0 Or IsDBNull(CmbUser.SelectedValue) = True Or IsNothing(CmbUser.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! User Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(txtObs.Text) = True Or IsNothing(txtObs.Text) = True Or Len(Trim(txtObs.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Observations Data is Empty.")
            SwVal = False
            Exit Sub
        End If

        Dim II As Integer

        For II = 1 To dgDescr.Rows.Count - 1

            If IsDBNull(dgDescr.Item("DefCode", II - 1).FormattedValue) = True Then
                MsgBox("!!! ERROR !!! Defective Codes - Value is Empty.")
                SwVal = False
                Exit Sub
            Else
                If Len(Trim(dgDescr.Item("DefCode", II - 1).FormattedValue)) = 0 Then
                    MsgBox("!!! ERROR !!! Defective Codes - Value is Empty.")
                    SwVal = False
                    Exit Sub
                End If
            End If

            If IsDBNull(dgDescr.Item("Requirement", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Description Requirement - Value is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgDescr.Item("ItemNo", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Description Item No - Value is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgDescr.Item("QtyRej", II - 1).Value) = True And IsDBNull(dgDescr.Item("DefCode", II - 1).Value) = False Then
                MsgBox("!!! ERROR !!! Description Qty Rejected Value is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgDescr.Item("QtyRej", II - 1).Value) = False And Nz.Nz(dgDescr.Item("QtyRej", II - 1).Value) <> 0 Then
                If IsDBNull(dgDescr.Item("DefCode", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Description Defected Code Value is Empty.")
                    SwVal = False
                    Exit Sub
                End If
            End If

            If IsDBNull(dgDescr.Item("QtyRej", II - 1).Value) And IsDBNull(dgDescr.Item("QtyInsp", II - 1).Value) = False Then
                If Val(dgDescr.Item("QtyRej", II - 1).Value) > Val(dgDescr.Item("QtyInsp", II - 1).Value) Then
                    MsgBox("!!! ERROR !!! Rejected Qty > Inspected Qty. Please see Description Info.")
                    SwVal = False
                    Exit Sub
                End If
            End If

        Next

        II = 0

        If dgAction.Rows.Count > 0 Then
            For II = 1 To dgAction.Rows.Count - 1

                If RdSupplier.Checked = True Then
                    If IsDBNull(dgAction.Item("ActionPrice", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! This is a Debit Memo Document. Price is Empty.")
                        SwVal = False
                        Exit Sub
                    End If
                    If IsDBNull(dgAction.Item("ActionQty", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! This is a Debit Memo Document. Qty is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If IsDBNull(dgAction.Item("ActionDescr", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Action Description  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If IsDBNull(dgAction.Item("ItemNo", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Action Item No.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If Len(Trim(CmbVerifyBy.Text)) = 0 Then
                        MsgBox("!!! ERROR !!! Disposition By.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If Len(Trim(cmbDateVerify.Text)) = 0 Then
                        MsgBox("!!! ERROR !!! Disposition Verify Date.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If
                Else
                    If IsDBNull(dgAction.Item("ActionDescr", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Action Description  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If IsDBNull(dgAction.Item("ItemNo", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Action Item No.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If Len(Trim(CmbVerifyBy.Text)) = 0 Then
                        MsgBox("!!! ERROR !!! Disposition By.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If Len(Trim(cmbDateVerify.Text)) = 0 Then
                        MsgBox("!!! ERROR !!! Disposition Verify Date.  - Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If
                End If
            Next
        End If

        II = 0

        For II = 1 To dgRework.Rows.Count - 1

            If IsDBNull(dgRework.Item("ReworkDescr", II - 1).Value) = False And _
                IsDBNull(dgRework.Item("ItemNo", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Rework Item No.  - Value is Empty.")
                SwVal = False
                Exit Sub
            End If

            'If IsDBNull(dgRework.Item("ReworkDescr", II - 1).Value) = True Then
            '    MsgBox("!!! ERROR !!! Rework Description.  - Value is Empty.")
            '    SwVal = False
            '    Exit Sub
            'End If

            If ChAppr.Checked = True Then
                If IsDBNull(dgRework.Item("ReworkDescr", II - 1).Value) = False Then

                    If IsDBNull(dgRework.Item("Qtyrework", II - 1).Value) = False And Nz.Nz(dgRework.Item("Qtyrework", II - 1).Value) <> 0 Then
                        If IsDBNull(dgRework.Item("QtyAct", II - 1).Value) = True Then
                            MsgBox("!!! ERROR !!! Rework Qty Accepted Value is Empty.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If

                    If IsDBNull(dgRework.Item("OperatorID", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Rework Operator Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If IsDBNull(dgRework.Item("OperHr", II - 1).Value) = True Then
                        MsgBox("!!! ERROR !!! Rework Hours# Value is Empty.")
                        SwVal = False
                        Exit Sub
                    End If

                    If Nz.Nz(dgRework.Item("Qtyrework", II - 1).Value) <> Nz.Nz(dgRework.Item("QtyAct", II - 1).Value) + Nz.Nz(dgRework.Item("QtyRwkRej", II - 1).Value) Then
                        MsgBox("!!! ERROR !!! Rwk Qty <> AccQty + RejQty")
                        SwVal = False
                        Exit Sub
                    End If
                End If
            End If

        Next

        II = 0

        For II = 1 To dgCorr.Rows.Count - 1

            If IsDBNull(dgCorr.Item("CorrItem", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Corrective Action Item No.  - Value is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgCorr.Item("CorrDescr", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Corrective Action Description  - Value is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        If Val(txtMemoQtyRwk.Text) > Val(txtMpoQty.Text) Then
            MsgBox("!!! ERROR !!! Rwk Qty > MPO Qty")
            SwVal = False
            Exit Sub
        End If

        If Val(txtMemoQtyScrap.Text) > Val(txtMpoQty.Text) Then
            MsgBox("!!! ERROR !!! Scrap Qty > MPO Qty")
            SwVal = False
            Exit Sub
        End If

        If Val(txtMemoQtySort.Text) > Val(txtMpoQty.Text) Then
            MsgBox("!!! ERROR !!! Sort Qty > MPO Qty")
            SwVal = False
            Exit Sub
        End If

        If RdInternal.Checked = True Then
            If ChSystem.Checked = False And RdQuality.Checked = False And RdTraining.Checked = False And RdMfg.Checked = False And RdHelth.Checked = False And RdSafety.Checked = False And RdEnv.Checked = False Then
                MsgBox("!!! ERROR !!! For Internal MEMO  - System / Final / InProcess / Training / Helth / Safety / Environment - one of them must to be activated.")
                SwVal = False
                Exit Sub
            End If
        End If

        SwVal = True

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        dsMain.RejectChanges()
        'InitialComponents()

        Me.BindingContext(dsMain, "tblMemo").AddNew()
        'Me.BindingContext(dsMain, "tblMemoDescr").AddNew()
        'Me.BindingContext(dsMain, "tblMemoAction").AddNew()
        'Me.BindingContext(dsMain, "tblMemoReworkCard").AddNew()
        'Me.BindingContext(dsMain, "tblMemoCorrectiveAction").AddNew()

        dsMain.Tables("tblMemoDescr").Clear()
        dsMain.Tables("tblMemoAction").Clear()
        dsMain.Tables("tblMemoReworkCard").Clear()
        dsMain.Tables("tblMemoCorrectiveAction").Clear()

        CmbMemo.Enabled = False
        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        CmdNew.Enabled = False
        CmdReset.Enabled = True
        CmdSeeMemo.Enabled = False

        InitFields()
        ViewEnableUser()

        CmbUser.SelectedValue = wkEmpId
        txtUserDept.Text = CmbUser.SelectedItem("EmpDept")
        txtMemoDate.Text = Date.Now.ToShortDateString
        txtMemoKey.Text = ""
        'CmbStatus.SelectedText = "Active"

        RdSupplier.Checked = True
        RdCustomer.Checked = True


        RdInternal.Checked = True
        RdInternal.Focus()

        RdDocYes.Checked = True
        RdDocNo.Checked = True
        RdDocNo.Checked = False
        RdDocYes.Checked = True
        RdInternal.Focus()

        If RoleProd(wkEmpDept) = True Then
            RdInternal.Checked = True
            RdSupplier.Enabled = False
            RdCustomer.Enabled = False
            RdQuality.Enabled = False
            RdTraining.Enabled = True
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        If Len(Trim(txtMemoKey.Text)) = 0 Then
            'MsgBox("!!! ERROR !!! Nothing to modify.")
            'Exit Sub
        End If

        If CmbStatus.Text <> "Active" Then
            ' Closed or Cancelled
            ViewDisable()
        Else
            If CmbUser.SelectedValue = wkEmpId Then
                ViewEnableUser()
                CmdSave.Enabled = True
            Else
                If RoleAppr(wkDeptCode) = True Then
                    ViewEnableAppr()
                    CmdSave.Enabled = True
                Else
                    If RoleVer(wkDeptCode) = True Then
                        ViewEnableVer()
                        CmdSave.Enabled = True
                    Else
                        ViewDisable()
                        CmdSave.Enabled = False
                    End If
                End If
            End If
        End If

        CmdNew.Enabled = False
        CmdReset.Enabled = True
        CmbMemo.Enabled = False
        CmdEdit.Enabled = False
        CmdSeeMemo.Enabled = False

        'Me.BindingContext(dsMain, "tblMemo").EndCurrentEdit()

    End Sub

    Private Sub CmdSeeMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeeMemo.Click
        Me.Cursor = Cursors.WaitCursor

        frmLisiMemoSrc.ShowDialog()
        frmLisiMemoSrc.Dispose()

        SwMemoID = CmbMemo.SelectedValue

        PutMemoInfo()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        If RdTraining.Checked = False Then

            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptLisiMemo()
            rptPO.Load("..\rptLisiMemo.rpt")

            rptPO.ReportOptions.EnableSaveDataWithReport = False

            Dim FindMemo As String
            FindMemo = Trim(txtMemoNo.Text)

            Try
                Me.Cursor = Cursors.WaitCursor
                pdvCustomerName.Value = FindMemo
                pvCollection.Add(pdvCustomerName)
                rptPO.DataDefinition.ParameterFields("@FindMemo").ApplyCurrentValues(pvCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
                frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
                frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
                frmPOMasterPrint.ShowDialog()
                Me.Cursor = Cursors.Default

            Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                MsgBox("Incorrect path for loading report.", _
                        MsgBoxStyle.Critical, "Load Report Error")
            Catch Exp As Exception
                MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            End Try

        Else

            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim rptPO As New rptLisiMemoTraining()
            rptPO.Load("..\rptLisiMemoTraining.rpt")
            rptPO.ReportOptions.EnableSaveDataWithReport = False

            Dim FindMemo As String
            FindMemo = Trim(txtMemoNo.Text)

            Try
                Me.Cursor = Cursors.WaitCursor
                pdvCustomerName.Value = FindMemo
                pvCollection.Add(pdvCustomerName)
                rptPO.DataDefinition.ParameterFields("@FindMemo").ApplyCurrentValues(pvCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
                frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
                frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
                frmPOMasterPrint.ShowDialog()
                Me.Cursor = Cursors.Default
            Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                MsgBox("Incorrect path for loading report.", _
                        MsgBoxStyle.Critical, "Load Report Error")
            Catch Exp As Exception
                MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        End If

    End Sub

    Private Sub dgCorr_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If dgDescr.Rows.Count - 1 = 0 Then
            MsgBox("Please enter before the description requirement.")
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub dgCorr_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        REM end
    End Sub

    Private Sub CmdSeePo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeePo.Click

        If Len(Trim(CmbLisiPO.Text)) > 0 Then
            Dim FindPO As String
            Dim SwEndUser As String = ""

            FindPO = CmbLisiPO.Text

            Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Try
                Dim rptPO As New rptPOSupp()
                rptPO.Load("..\rptposupp.rpt")
                pdFind.Value = FindPO
                pdEndUser.Value = SwEndUser

                pvFindCollection.Add(pdFind)
                pvEndUserCollection.Add(pdEndUser)

                rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvFindCollection)
                rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pvEndUserCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True

                frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = False
                frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = False

                frmPOMasterPrint.ShowDialog()
            Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                MsgBox("Incorrect path for loading report.", _
                        MsgBoxStyle.Critical, "Load Report Error")

            Catch Exp As Exception
                MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            End Try
        Else
            MsgBox("Nothing to PreView.")
        End If

    End Sub

    Private Sub cspReturnPartIDWithMPOID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cspReturnPartIDWithMPOID.Click

        If Val(CmbMpo.SelectedValue) > 0 Then
            txtMPOCost.Text = CallClass.ReturnStrWithParInt("cspReturnCostElemMEMOLisi", CmbMpo.SelectedValue)
        Else
            MsgBox("Please select before MPO Number")
        End If

    End Sub

    Sub CalculValue()
        Dim I As Integer = 0

        For I = 0 To dgAction.Rows.Count - 1
            If IsDBNull(Me.dgAction("ActionPrice", I).Value) = False And _
               IsDBNull(Me.dgAction("ActionQty", I).Value) = False Then
                Me.dgAction("ActionValue", I).Value = Me.dgAction("ActionPrice", I).Value * Me.dgAction("ActionQty", I).Value
            Else
                Me.dgAction("ActionValue", I).Value = 0
            End If
        Next I

        Dim qty As Double = 0.0
        For Each rBar As DataGridViewRow In dgAction.Rows
            qty = qty + Nz.Nz(rBar.Cells("ActionValue").Value)
        Next
        txtAmount.Text = qty.ToString("C2")

    End Sub

    Sub CalculRwk()
        Dim I As Integer = 0

        For I = 0 To dgRework.Rows.Count - 1
            dgRework("QtyRwkRej", I).Value = Nz.Nz(dgRework("Qtyrework", I).Value) - _
                                             Nz.Nz(dgRework("QtyAct", I).Value)
            Me.dgRework("SwRwkValue", I).Value = Nz.Nz(dgRework("OperHr", I).Value) * _
                                                 Nz.Nz(dgRework("RwkRate", I).Value)


            If Nz.Nz(dgAction("ActionPrice", 0).Value) = 0 Then
                If SwFirst = True Then
                    SwFirst = False
                    'Else
                    'MsgBox("Please Enter the MPO Revised Cost on Line 1 from Action / Disposition")
                End If
            Else
                Me.dgRework("SwScrapValue", I).Value = Nz.Nz(dgRework("QtyRwkRej", I).Value) * _
                                                                 Nz.Nz(dgAction("ActionPrice", 0).Value)
            End If

        Next I

        Dim qty As Double = 0.0
        Dim qtyrwk As Integer = 0
        Dim qtyacc As Integer = 0

        For Each rBar As DataGridViewRow In dgRework.Rows
            qty = qty + Nz.Nz(rBar.Cells("SwRwkValue").Value)
            qtyrwk = qtyrwk + Nz.Nz(rBar.Cells("Qtyrework").Value)
        Next

        txtRwkVal.Text = qty.ToString("C2")
        txtRwkQty.Text = qtyrwk.ToString("N0")
        txtQtyAcc.Text = qtyacc.ToString("N0")

        qty = 0.0
        qtyrwk = 0
        qtyacc = 0
        For Each rBar As DataGridViewRow In dgRework.Rows
            If Nz.Nz(rBar.Cells("SwScrapValue").Value) <> 0 Then
                qty = Nz.Nz(rBar.Cells("SwScrapValue").Value)
                qtyrwk = Nz.Nz(rBar.Cells("QtyRwkRej").Value)
            End If
            If Nz.Nz(rBar.Cells("QtyAct").Value) <> 0 Then
                qtyacc = Nz.Nz(rBar.Cells("QtyAct").Value)
            End If
        Next
        txtScrapVal.Text = qty.ToString("C2")
        txtScrapQty.Text = qtyrwk.ToString("N0")
        txtQtyAcc.Text = qtyacc.ToString("N0")
    End Sub

    Private Sub RdInternal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdInternal.Click
        CmbLisiPO.Enabled = True
        CmbCustPo.Enabled = True
        txtSuppCert.ReadOnly = False

        'CmdIR.Enabled = True
        'CmdRMA.Enabled = False

    End Sub

    Private Sub RdSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdSupplier.Click
        If RdSupplier.Checked = True Then
            CmbCustPo.SelectedIndex = -1
            txtCust.Text = ""
            CmbCustPo.Enabled = False

            CmbLisiPO.Enabled = True
            txtSuppCert.ReadOnly = False

            CmdIR.Enabled = False
            CmdRMA.Enabled = False

        End If
    End Sub

    Private Sub RdCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCustomer.Click
        If RdCustomer.Checked = True Then
            CmbLisiPO.SelectedIndex = -1
            CmbLisiPO.Enabled = False
            txtSupp.Text = ""
            txtSuppCert.ReadOnly = True
            txtSuppCert.Text = ""

            CmbCustPo.Enabled = True

            CmdIR.Enabled = True
            CmdRMA.Enabled = True
        End If

    End Sub

    Private Sub CmbMemo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMemo.DropDownClosed

        SwMemoID = CmbMemo.SelectedValue
        PutMemoInfo()

    End Sub

    Sub PutMemoInfo()

        If CmbMemo.SelectedValue <= 0 Then
            Exit Sub
        End If

        'SetupForm()
        'dsMain.Tables("tblMemo").Clear()

        dsMain.Clear()

        'dsMain.Tables("tblMemoDescr").Clear()
        'dsMain.Tables("tblMemoAction").Clear()
        'dsMain.Tables("tblMemoReworkCard").Clear()
        'dsMain.Tables("tblMemoCorrectiveAction").Clear()

        CallClass.PopulateDataAdapterAfterSearch("gettblMemoByMemoID", CmbMemo.SelectedValue).Fill(dsMain, "tblMemo")
        CallClass.PopulateDataAdapterAfterSearch("gettblMemoDescrByMemoID", CmbMemo.SelectedValue).Fill(dsMain, "tblMemoDescr")
        CallClass.PopulateDataAdapterAfterSearch("gettblMemoActionByMemoID", CmbMemo.SelectedValue).Fill(dsMain, "tblMemoAction")
        CallClass.PopulateDataAdapterAfterSearch("gettblMemoReworkCardByMemoID", CmbMemo.SelectedValue).Fill(dsMain, "tblMemoReworkCard")
        CallClass.PopulateDataAdapterAfterSearch("gettblMemoCorrectiveActionByMemoID", CmbMemo.SelectedValue).Fill(dsMain, "tblMemoCorrectiveAction")

        CalculValue()
        CalculRwk()

        'InitFields()

        CmdEdit.Enabled = True
        CmdPrint.Enabled = True
        CmbMemo.Enabled = False

        DisableFields()
        ViewDisable()

        Call BindComponents()

        dgDescr.AutoGenerateColumns = False
        dgDescr.DataSource = dsMain
        dgDescr.DataMember = "tblMemoDescr"

        dgAction.AutoGenerateColumns = False
        dgAction.DataSource = dsMain
        dgAction.DataMember = "tblMemoAction"

        dgRework.AutoGenerateColumns = False
        dgRework.DataSource = dsMain
        dgRework.DataMember = "tblMemoReworkCard"

        dgCorr.AutoGenerateColumns = False
        dgCorr.DataSource = dsMain
        dgCorr.DataMember = "tblMemoCorrectiveAction"

        CheckViewRecord()

    End Sub

    Sub UpdateMemo(ByVal dsChanges As DataSet)

        Dim cmdInsMemo As SqlCommand
        Dim cmdUpdMemo As SqlCommand
        Dim daMemo As SqlDataAdapter

        cmdInsMemo = New SqlCommand()
        cmdInsMemo.Connection = cn
        cmdInsMemo.CommandType = CommandType.StoredProcedure
        cmdInsMemo.CommandText = "cspUpdateMemoInsert"

        cmdUpdMemo = New SqlCommand()
        cmdUpdMemo.Connection = cn
        cmdUpdMemo.CommandType = CommandType.StoredProcedure
        cmdUpdMemo.CommandText = "cspUpdateMemoModify"

        'Add Parameter to Insert
        cmdInsMemo.Parameters.Add("@MemoId", SqlDbType.Int, 4, "MemoId")

        cmdInsMemo.Parameters.Add("@MemoNo", SqlDbType.NVarChar, 10, "MemoNo")
        'cmdInsMemo.Parameters.Item(1).Value = txtMemoNo.Text

        cmdInsMemo.Parameters.Add("@MemoNoPrefix", SqlDbType.NVarChar, 25, "MemoNoPrefix")
        cmdInsMemo.Parameters.Add("@MemoStatus", SqlDbType.NVarChar, 10, "MemoStatus")
        cmdInsMemo.Parameters.Add("@CreatedUser", SqlDbType.Int, 4, "CreatedUser")
        cmdInsMemo.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime, 4, "CreatedDate")
        cmdInsMemo.Parameters.Add("@CustPoID", SqlDbType.Int, 4, "CustPoID")
        cmdInsMemo.Parameters.Add("@PoNoID", SqlDbType.Int, 4, "PoNoID")
        cmdInsMemo.Parameters.Add("@SuppCertNo", SqlDbType.NVarChar, 50, "SuppCertNo")
        cmdInsMemo.Parameters.Add("@MPOID", SqlDbType.Int, 4, "MPOID")
        cmdInsMemo.Parameters.Add("@MpoQty", SqlDbType.Real, 4, "MpoQty")
        cmdInsMemo.Parameters.Add("@MpoDept", SqlDbType.Int, 4, "MpoDept")
        cmdInsMemo.Parameters.Add("@VerifyBy", SqlDbType.Int, 4, "VerifyBy")
        cmdInsMemo.Parameters.Add("@VerifyDate", SqlDbType.SmallDateTime, 4, "VerifyDate")
        cmdInsMemo.Parameters.Add("@ObsList", SqlDbType.NVarChar, 1000, "ObsList")
        cmdInsMemo.Parameters.Add("@ApprBy", SqlDbType.Int, 4, "ApprBy")
        cmdInsMemo.Parameters.Add("@ApprDate", SqlDbType.SmallDateTime, 4, "ApprDate")
        cmdInsMemo.Parameters.Add("@NCRNo", SqlDbType.NVarChar, 5, "NCRNo")
        cmdInsMemo.Parameters.Add("@SNCRNo", SqlDbType.NVarChar, 5, "SNCRNo")
        cmdInsMemo.Parameters.Add("@SeeMemoNo", SqlDbType.NVarChar, 5, "SeeMemoNo")
        cmdInsMemo.Parameters.Add("@CustSpecify", SqlDbType.NVarChar, 100, "CustSpecify")
        cmdInsMemo.Parameters.Add("@SuppSpecify", SqlDbType.NVarChar, 100, "SuppSpecify")
        cmdInsMemo.Parameters.Add("@InternalSource", SqlDbType.Bit, 1, "InternalSource")
        cmdInsMemo.Parameters.Add("@SupplierSource", SqlDbType.Bit, 1, "SupplierSource")
        cmdInsMemo.Parameters.Add("@CustomerSource", SqlDbType.Bit, 1, "CustomerSource")
        cmdInsMemo.Parameters.Add("@DocConfYes", SqlDbType.Bit, 1, "DocConfYes")
        cmdInsMemo.Parameters.Add("@DocConfNo", SqlDbType.Bit, 1, "DocConfNo")
        cmdInsMemo.Parameters.Add("@NCRReq", SqlDbType.Bit, 1, "NCRReq")
        cmdInsMemo.Parameters.Add("@CustNotificationReq", SqlDbType.Bit, 1, "CustNotificationReq")
        cmdInsMemo.Parameters.Add("@SuppNotificationReq", SqlDbType.Bit, 1, "SuppNotificationReq")
        cmdInsMemo.Parameters.Add("@MemoQtyRwk", SqlDbType.Int, 4, "MemoQtyRwk")
        cmdInsMemo.Parameters.Add("@MemoQtyScrap", SqlDbType.Int, 4, "MemoQtyScrap")
        cmdInsMemo.Parameters.Add("@DeptQtyRej", SqlDbType.Int, 4, "DeptQtyRej")
        cmdInsMemo.Parameters.Add("@MemoQtySort", SqlDbType.Int, 4, "MemoQtySort")
        cmdInsMemo.Parameters.Add("@SalesDateMessage", SqlDbType.SmallDateTime, 4, "SalesDateMessage")
        cmdInsMemo.Parameters.Add("@ApprCheck", SqlDbType.Bit, 1, "ApprCheck")
        cmdInsMemo.Parameters.Add("@MemoIR", SqlDbType.NVarChar, 10, "MemoIR")
        cmdInsMemo.Parameters.Add("@MemoRMA", SqlDbType.NVarChar, 10, "MemoRMA")
        cmdInsMemo.Parameters.Add("@InternalMfg", SqlDbType.Bit, 1, "InternalMfg")
        cmdInsMemo.Parameters.Add("@InternalQuality", SqlDbType.Bit, 1, "InternalQuality")
        cmdInsMemo.Parameters.Add("@InternalTraining", SqlDbType.Bit, 1, "InternalTraining")
        cmdInsMemo.Parameters.Add("@EngDateMessage", SqlDbType.SmallDateTime, 4, "EngDateMessage")
        cmdInsMemo.Parameters.Add("@QADateMessage", SqlDbType.SmallDateTime, 4, "QADateMessage")
        cmdInsMemo.Parameters.Add("@ApprSystem", SqlDbType.Bit, 1, "ApprSystem")
        cmdInsMemo.Parameters.Add("@InternalHelth", SqlDbType.Bit, 1, "InternalHelth")
        cmdInsMemo.Parameters.Add("@InternalSafety", SqlDbType.Bit, 1, "InternalSafety")
        cmdInsMemo.Parameters.Add("@InternalEnvironment", SqlDbType.Bit, 1, "InternalEnvironment")

        'Add param for Update
        cmdUpdMemo.Parameters.Add("@MemoId", SqlDbType.Int, 4, "MemoId")
        'cmdUpdMemo.Parameters.Add("@MemoNo", SqlDbType.NVarChar, 10, "MemoNo")
        cmdUpdMemo.Parameters.Add("@MemoNoPrefix", SqlDbType.NVarChar, 25, "MemoNoPrefix")
        cmdUpdMemo.Parameters.Add("@MemoStatus", SqlDbType.NVarChar, 10, "MemoStatus")
        cmdUpdMemo.Parameters.Add("@CreatedUser", SqlDbType.Int, 4, "CreatedUser")
        cmdUpdMemo.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime, 4, "CreatedDate")
        cmdUpdMemo.Parameters.Add("@CustPoID", SqlDbType.Int, 4, "CustPoID")
        cmdUpdMemo.Parameters.Add("@PoNoID", SqlDbType.Int, 4, "PoNoID")
        cmdUpdMemo.Parameters.Add("@SuppCertNo", SqlDbType.NVarChar, 50, "SuppCertNo")
        cmdUpdMemo.Parameters.Add("@MPOID", SqlDbType.Int, 4, "MPOID")
        cmdUpdMemo.Parameters.Add("@MpoQty", SqlDbType.Real, 4, "MpoQty")
        cmdUpdMemo.Parameters.Add("@MpoDept", SqlDbType.Int, 4, "MpoDept")
        cmdUpdMemo.Parameters.Add("@VerifyBy", SqlDbType.Int, 4, "VerifyBy")
        cmdUpdMemo.Parameters.Add("@VerifyDate", SqlDbType.SmallDateTime, 4, "VerifyDate")
        cmdUpdMemo.Parameters.Add("@ObsList", SqlDbType.NVarChar, 1000, "ObsList")
        cmdUpdMemo.Parameters.Add("@ApprBy", SqlDbType.Int, 4, "ApprBy")
        cmdUpdMemo.Parameters.Add("@ApprDate", SqlDbType.SmallDateTime, 4, "ApprDate")
        cmdUpdMemo.Parameters.Add("@NCRNo", SqlDbType.NVarChar, 5, "NCRNo")
        cmdUpdMemo.Parameters.Add("@SNCRNo", SqlDbType.NVarChar, 5, "SNCRNo")
        cmdUpdMemo.Parameters.Add("@SeeMemoNo", SqlDbType.NVarChar, 5, "SeeMemoNo")
        cmdUpdMemo.Parameters.Add("@CustSpecify", SqlDbType.NVarChar, 100, "CustSpecify")
        cmdUpdMemo.Parameters.Add("@SuppSpecify", SqlDbType.NVarChar, 100, "SuppSpecify")
        cmdUpdMemo.Parameters.Add("@InternalSource", SqlDbType.Bit, 1, "InternalSource")
        cmdUpdMemo.Parameters.Add("@SupplierSource", SqlDbType.Bit, 1, "SupplierSource")
        cmdUpdMemo.Parameters.Add("@CustomerSource", SqlDbType.Bit, 1, "CustomerSource")
        cmdUpdMemo.Parameters.Add("@DocConfYes", SqlDbType.Bit, 1, "DocConfYes")
        cmdUpdMemo.Parameters.Add("@DocConfNo", SqlDbType.Bit, 1, "DocConfNo")
        cmdUpdMemo.Parameters.Add("@NCRReq", SqlDbType.Bit, 1, "NCRReq")
        cmdUpdMemo.Parameters.Add("@CustNotificationReq", SqlDbType.Bit, 1, "CustNotificationReq")
        cmdUpdMemo.Parameters.Add("@SuppNotificationReq", SqlDbType.Bit, 1, "SuppNotificationReq")
        cmdUpdMemo.Parameters.Add("@MemoQtyRwk", SqlDbType.Int, 4, "MemoQtyRwk")
        cmdUpdMemo.Parameters.Add("@MemoQtyScrap", SqlDbType.Int, 4, "MemoQtyScrap")
        cmdUpdMemo.Parameters.Add("@MemoQtySort", SqlDbType.Int, 4, "MemoQtySort")
        cmdUpdMemo.Parameters.Add("@DeptQtyRej", SqlDbType.Int, 4, "DeptQtyRej")
        cmdUpdMemo.Parameters.Add("@SalesDateMessage", SqlDbType.SmallDateTime, 4, "SalesDateMessage")
        cmdUpdMemo.Parameters.Add("@ApprCheck", SqlDbType.Bit, 1, "ApprCheck")
        cmdUpdMemo.Parameters.Add("@MemoIR", SqlDbType.NVarChar, 10, "MemoIR")
        cmdUpdMemo.Parameters.Add("@MemoRMA", SqlDbType.NVarChar, 10, "MemoRMA")
        cmdUpdMemo.Parameters.Add("@InternalMfg", SqlDbType.Bit, 1, "InternalMfg")
        cmdUpdMemo.Parameters.Add("@InternalQuality", SqlDbType.Bit, 1, "InternalQuality")
        cmdUpdMemo.Parameters.Add("@InternalTraining", SqlDbType.Bit, 1, "InternalTraining")
        cmdUpdMemo.Parameters.Add("@EngDateMessage", SqlDbType.SmallDateTime, 4, "EngDateMessage")
        cmdUpdMemo.Parameters.Add("@QADateMessage", SqlDbType.SmallDateTime, 4, "QADateMessage")
        cmdUpdMemo.Parameters.Add("@ApprSystem", SqlDbType.Bit, 1, "ApprSystem")
        cmdUpdMemo.Parameters.Add("@InternalHelth", SqlDbType.Bit, 1, "InternalHelth")
        cmdUpdMemo.Parameters.Add("@InternalSafety", SqlDbType.Bit, 1, "InternalSafety")
        cmdUpdMemo.Parameters.Add("@InternalEnvironment", SqlDbType.Bit, 1, "InternalEnvironment")

        daMemo = New SqlDataAdapter()
        daMemo.InsertCommand = cmdInsMemo
        daMemo.UpdateCommand = cmdUpdMemo
        daMemo.TableMappings.Add("Table", "tblMemo")
        daMemo.Update(dsChanges)

        'daMemo.Dispose()
        'cmdInsMemo.Dispose()
        'cmdUpdMemo.Dispose()

    End Sub

    Sub UpdateMemoAllInfo(ByVal dsChanges As DataSet)

        Dim cmdInsMemoDescr As SqlCommand
        Dim cmdUpdMemoDescr As SqlCommand
        Dim cmdDelMemoDescr As SqlCommand

        Dim daMemoDescr As SqlDataAdapter

        cmdInsMemoDescr = New SqlCommand()
        cmdInsMemoDescr.Connection = cn
        cmdInsMemoDescr.CommandType = CommandType.StoredProcedure
        cmdInsMemoDescr.CommandText = "cspUpdateMemoDescriptionInsert"

        cmdUpdMemoDescr = New SqlCommand()
        cmdUpdMemoDescr.Connection = cn
        cmdUpdMemoDescr.CommandType = CommandType.StoredProcedure
        cmdUpdMemoDescr.CommandText = "cspUpdateMemoDescriptionModify"

        cmdDelMemoDescr = New SqlCommand()
        cmdDelMemoDescr.Connection = cn
        cmdDelMemoDescr.CommandType = CommandType.StoredProcedure
        cmdDelMemoDescr.CommandText = "cspUpdateMemoDescriptionDelete"

        'Add Parameter to Insert Memo Description
        cmdInsMemoDescr.Parameters.Add("@DescrID", SqlDbType.Int, 4, "DescrID")

        cmdInsMemoDescr.Parameters.Add("@MemoID", SqlDbType.Int, 4)
        cmdInsMemoDescr.Parameters.Item(1).Value = SwMemoID

        cmdInsMemoDescr.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdInsMemoDescr.Parameters.Add("@Requirement", SqlDbType.NVarChar, 1500, "Requirement")
        cmdInsMemoDescr.Parameters.Add("@ActualCondition", SqlDbType.NVarChar, 1500, "ActualCondition")
        cmdInsMemoDescr.Parameters.Add("@TypeDescr", SqlDbType.NVarChar, 1, "TypeDescr")
        cmdInsMemoDescr.Parameters.Add("@OperNo", SqlDbType.NVarChar, 5, "OperNo")
        cmdInsMemoDescr.Parameters.Add("@QtyInsp", SqlDbType.Real, 4, "QtyInsp")
        cmdInsMemoDescr.Parameters.Add("@QtyRej", SqlDbType.Real, 4, "QtyRej")
        cmdInsMemoDescr.Parameters.Add("@DefCode", SqlDbType.Int, 4, "DefCode")

        'Add Parameter to Modify Memo Descrption
        cmdUpdMemoDescr.Parameters.Add("@DescrID", SqlDbType.Int, 4, "DescrID")
        cmdUpdMemoDescr.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdUpdMemoDescr.Parameters.Add("@Requirement", SqlDbType.NVarChar, 1500, "Requirement")
        cmdUpdMemoDescr.Parameters.Add("@ActualCondition", SqlDbType.NVarChar, 1500, "ActualCondition")
        cmdUpdMemoDescr.Parameters.Add("@TypeDescr", SqlDbType.NVarChar, 1, "TypeDescr")
        cmdUpdMemoDescr.Parameters.Add("@OperNo", SqlDbType.NVarChar, 5, "OperNo")
        cmdUpdMemoDescr.Parameters.Add("@QtyInsp", SqlDbType.Real, 4, "QtyInsp")
        cmdUpdMemoDescr.Parameters.Add("@QtyRej", SqlDbType.Real, 4, "QtyRej")
        cmdUpdMemoDescr.Parameters.Add("@DefCode", SqlDbType.Int, 4, "DefCode")

        'Add Parameter to Delete Memo Descrption
        cmdDelMemoDescr.Parameters.Add("@DescrID", SqlDbType.Int, 4, "DescrID")

        daMemoDescr = New SqlDataAdapter()
        daMemoDescr.InsertCommand = cmdInsMemoDescr
        daMemoDescr.UpdateCommand = cmdUpdMemoDescr
        daMemoDescr.DeleteCommand = cmdDelMemoDescr
        daMemoDescr.TableMappings.Add("Table", "tblMemoDescr")
        daMemoDescr.Update(dsChanges)

        '=========================================================

        Dim cmdInsMemoAction As SqlCommand
        Dim cmdUpdMemoAction As SqlCommand
        Dim cmdDelMemoAction As SqlCommand

        Dim daMemoAction As SqlDataAdapter

        cmdInsMemoAction = New SqlCommand()
        cmdInsMemoAction.Connection = cn
        cmdInsMemoAction.CommandType = CommandType.StoredProcedure
        cmdInsMemoAction.CommandText = "cspUpdateMemoActionInsert"

        cmdUpdMemoAction = New SqlCommand()
        cmdUpdMemoAction.Connection = cn
        cmdUpdMemoAction.CommandType = CommandType.StoredProcedure
        cmdUpdMemoAction.CommandText = "cspUpdateMemoActionModify"

        cmdDelMemoAction = New SqlCommand()
        cmdDelMemoAction.Connection = cn
        cmdDelMemoAction.CommandType = CommandType.StoredProcedure
        cmdDelMemoAction.CommandText = "cspUpdateMemoActionDelete"

        'Add Parameter to Insert Memo Action
        cmdInsMemoAction.Parameters.Add("@ActionId", SqlDbType.Int, 4, "ActionId")

        cmdInsMemoAction.Parameters.Add("@MemoID", SqlDbType.Int, 4)
        cmdInsMemoAction.Parameters.Item(1).Value = SwMemoID

        cmdInsMemoAction.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdInsMemoAction.Parameters.Add("@ActionDescr", SqlDbType.NVarChar, 1500, "ActionDescr")
        cmdInsMemoAction.Parameters.Add("@ActionPrice", SqlDbType.SmallMoney, 4, "ActionPrice")
        cmdInsMemoAction.Parameters.Add("@ActionQty", SqlDbType.Real, 4, "ActionQty")

        'Add Parameter to Modify Memo Action
        cmdUpdMemoAction.Parameters.Add("@ActionId", SqlDbType.Int, 4, "ActionId")
        'cmdUpdMemoAction.Parameters.Add("@MemoID", SqlDbType.Int, 4, "MemoID")
        cmdUpdMemoAction.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdUpdMemoAction.Parameters.Add("@ActionDescr", SqlDbType.NVarChar, 1500, "ActionDescr")
        cmdUpdMemoAction.Parameters.Add("@ActionPrice", SqlDbType.SmallMoney, 4, "ActionPrice")
        cmdUpdMemoAction.Parameters.Add("@ActionQty", SqlDbType.Real, 4, "ActionQty")

        'Add Parameter to Delete Memo Action
        cmdDelMemoAction.Parameters.Add("@ActionId", SqlDbType.Int, 4, "ActionId")

        daMemoAction = New SqlDataAdapter()
        daMemoAction.InsertCommand = cmdInsMemoAction
        daMemoAction.UpdateCommand = cmdUpdMemoAction
        daMemoAction.DeleteCommand = cmdDelMemoAction
        daMemoAction.TableMappings.Add("Table", "tblMemoAction")
        daMemoAction.Update(dsChanges)

        '=========================================================

        Dim cmdInsMemoRwk As SqlCommand
        Dim cmdUpdMemoRwk As SqlCommand
        Dim cmdDelMemoRwk As SqlCommand

        Dim daMemoRwk As SqlDataAdapter

        cmdInsMemoRwk = New SqlCommand()
        cmdInsMemoRwk.Connection = cn
        cmdInsMemoRwk.CommandType = CommandType.StoredProcedure
        cmdInsMemoRwk.CommandText = "cspUpdateMemoReworkInsert"

        cmdUpdMemoRwk = New SqlCommand()
        cmdUpdMemoRwk.Connection = cn
        cmdUpdMemoRwk.CommandType = CommandType.StoredProcedure
        cmdUpdMemoRwk.CommandText = "cspUpdateMemoReworkModify"

        cmdDelMemoRwk = New SqlCommand()
        cmdDelMemoRwk.Connection = cn
        cmdDelMemoRwk.CommandType = CommandType.StoredProcedure
        cmdDelMemoRwk.CommandText = "cspUpdateMemoReworkDelete"

        'Add Parameter to Insert Memo Rework
        cmdInsMemoRwk.Parameters.Add("@ReworkID", SqlDbType.Int, 4, "ReworkID")

        cmdInsMemoRwk.Parameters.Add("@MemoID", SqlDbType.Int, 4)
        cmdInsMemoRwk.Parameters.Item(1).Value = SwMemoID

        cmdInsMemoRwk.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdInsMemoRwk.Parameters.Add("@ReworkDescr", SqlDbType.NVarChar, 1500, "ReworkDescr")
        cmdInsMemoRwk.Parameters.Add("@Qtyrework", SqlDbType.Int, 4, "Qtyrework")
        cmdInsMemoRwk.Parameters.Add("@QtyAct", SqlDbType.Int, 4, "QtyAct")
        cmdInsMemoRwk.Parameters.Add("@QtyRwkRej", SqlDbType.Int, 4, "QtyRwkRej")
        cmdInsMemoRwk.Parameters.Add("@OperatorID", SqlDbType.Int, 4, "OperatorID")
        cmdInsMemoRwk.Parameters.Add("@OperHr", SqlDbType.Real, 4, "OperHr")
        cmdInsMemoRwk.Parameters.Add("@RwkRate", SqlDbType.SmallMoney, 4, "RwkRate")

        'Add Parameter to Modify Memo Rework
        cmdUpdMemoRwk.Parameters.Add("@ReworkID", SqlDbType.Int, 4, "ReworkID")
        'cmdUpdMemoRwk.Parameters.Add("@MemoID", SqlDbType.Int, 4, "MemoID")
        cmdUpdMemoRwk.Parameters.Add("@ItemNo", SqlDbType.NVarChar, 5, "ItemNo")
        cmdUpdMemoRwk.Parameters.Add("@ReworkDescr", SqlDbType.NVarChar, 1500, "ReworkDescr")
        cmdUpdMemoRwk.Parameters.Add("@Qtyrework", SqlDbType.Int, 4, "Qtyrework")
        cmdUpdMemoRwk.Parameters.Add("@QtyAct", SqlDbType.Int, 4, "QtyAct")
        cmdUpdMemoRwk.Parameters.Add("@QtyRwkRej", SqlDbType.Int, 4, "QtyRwkRej")
        cmdUpdMemoRwk.Parameters.Add("@OperatorID", SqlDbType.Int, 4, "OperatorID")
        cmdUpdMemoRwk.Parameters.Add("@OperHr", SqlDbType.Real, 4, "OperHr")
        cmdUpdMemoRwk.Parameters.Add("@RwkRate", SqlDbType.SmallMoney, 4, "RwkRate")

        'Add Parameter to Delete Memo Rework
        cmdDelMemoRwk.Parameters.Add("@ReworkID", SqlDbType.Int, 4, "ReworkID")

        daMemoRwk = New SqlDataAdapter()
        daMemoRwk.InsertCommand = cmdInsMemoRwk
        daMemoRwk.UpdateCommand = cmdUpdMemoRwk
        daMemoRwk.DeleteCommand = cmdDelMemoRwk
        daMemoRwk.TableMappings.Add("Table", "tblMemoReworkCard")
        daMemoRwk.Update(dsChanges)

        '====================================================

        Dim cmdInsMemoCorr As SqlCommand
        Dim cmdUpdMemoCorr As SqlCommand
        Dim cmdDelMemoCorr As SqlCommand

        Dim daMemoCorr As SqlDataAdapter

        cmdInsMemoCorr = New SqlCommand()
        cmdInsMemoCorr.Connection = cn
        cmdInsMemoCorr.CommandType = CommandType.StoredProcedure
        cmdInsMemoCorr.CommandText = "cspUpdateMemoCorrectionInsert"

        cmdUpdMemoCorr = New SqlCommand()
        cmdUpdMemoCorr.Connection = cn
        cmdUpdMemoCorr.CommandType = CommandType.StoredProcedure
        cmdUpdMemoCorr.CommandText = "cspUpdateMemoCorrectionModify"

        cmdDelMemoCorr = New SqlCommand()
        cmdDelMemoCorr.Connection = cn
        cmdDelMemoCorr.CommandType = CommandType.StoredProcedure
        cmdDelMemoCorr.CommandText = "cspUpdateMemoCorrectionDelete"

        'Add Parameter to Insert Memo Correction
        cmdInsMemoCorr.Parameters.Add("@CorrActionID", SqlDbType.Int, 4, "CorrActionID")

        cmdInsMemoCorr.Parameters.Add("@MemoID", SqlDbType.Int, 4)
        cmdInsMemoCorr.Parameters.Item(1).Value = SwMemoID

        cmdInsMemoCorr.Parameters.Add("@CorrItem", SqlDbType.NVarChar, 5, "CorrItem")
        cmdInsMemoCorr.Parameters.Add("@CorrDescr", SqlDbType.NVarChar, 1500, "CorrDescr")

        'Add Parameter to Modify Memo Correction
        cmdUpdMemoCorr.Parameters.Add("@CorrActionID", SqlDbType.Int, 4, "CorrActionID")
        'cmdUpdMemoCorr.Parameters.Add("@MemoID", SqlDbType.Int, 4, "MemoID")
        cmdUpdMemoCorr.Parameters.Add("@CorrItem", SqlDbType.NVarChar, 5, "CorrItem")
        cmdUpdMemoCorr.Parameters.Add("@CorrDescr", SqlDbType.NVarChar, 1500, "CorrDescr")

        'Add Parameter to Delete Memo Correction
        cmdDelMemoCorr.Parameters.Add("@CorrActionID", SqlDbType.Int, 4, "CorrActionID")

        daMemoCorr = New SqlDataAdapter()
        daMemoCorr.InsertCommand = cmdInsMemoCorr
        daMemoCorr.UpdateCommand = cmdUpdMemoCorr
        daMemoCorr.DeleteCommand = cmdDelMemoCorr
        daMemoCorr.TableMappings.Add("Table", "tblMemoCorrectiveAction")
        daMemoCorr.Update(dsChanges)

        'daMemoDescr.Dispose()
        'daMemoAction.Dispose()
        'daMemoRwk.Dispose()
        'daMemoCorr.Dispose()

        'cmdInsMemoDescr.Dispose()
        'cmdUpdMemoDescr.Dispose()
        'cmdDelMemoDescr.Dispose()

        'cmdInsMemoAction.Dispose()
        'cmdUpdMemoAction.Dispose()
        'cmdDelMemoAction.Dispose()

        'cmdInsMemoRwk.Dispose()
        'cmdUpdMemoRwk.Dispose()
        'cmdDelMemoRwk.Dispose()

        'cmdInsMemoCorr.Dispose()
        'cmdUpdMemoCorr.Dispose()
        'cmdDelMemoCorr.Dispose()
    End Sub

    Private Sub dgRework_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRework.Sorted
        CalculRwk()
    End Sub

    Private Sub CmdCancelled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelled.Click

        swMPOScrap = False

        'If Val(txtMpoQty.Text) = Val(txtMemoQtyScrap.Text) Then
        Dim reply As DialogResult
        reply = MsgBox("By activate this button the MPO will be scrapped in LAC MRP when you'll save." + vbCrLf + _
            "Do you want to continue (Yes/No)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            swMPOScrap = True
        Else
            swMPOScrap = False
        End If

    End Sub

    Private Sub CmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClose.Click

        SwMEMOClose = False

        If ChAppr.Checked = False Then
            MsgBox("You can not Close the MPO as the Final Disposition is not activated.")
            Exit Sub
        End If

        Dim reply As DialogResult

        reply = MsgBox("By Activate this button the MEMO will be close when you will SAVE." + vbCrLf + _
            "Do you want to continue (Yes/No)?", MsgBoxStyle.YesNo)

        If reply = Windows.Forms.DialogResult.Yes Then
            SwMEMOClose = True
        End If

    End Sub

    Private Sub ChAppr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChAppr.Click


        If ChAppr.Checked = True Then

            Dim reply As DialogResult

            reply = MsgBox("By Checking this field the Final Disposition info will be freeze when you'll SAVE." + vbCrLf + _
                "Do you want to continue (Yes/No)?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                CmbApprBy.SelectedIndex = -1
                ChAppr.Checked = False
                cmbDateAppr.Text = ""
            Else
                CmbApprBy.SelectedValue = wkEmpId
                cmbDateAppr.Text = Date.Now.ToShortDateString
                cmbDateAppr.Refresh()
                ChAppr.Checked = True
            End If

        Else
            CmbApprBy.SelectedIndex = -1
            ChAppr.Checked = False
            cmbDateAppr.Text = ""
        End If
    End Sub

    Private Sub CmdIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIR.Click

        CreateIR = False
        CreateRMA = False

        Dim reply As DialogResult
        reply = MsgBox("Do you want to generate an IR Number (Yes/No)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            If Len(Trim(txtIR.Text)) > 0 Then
                MsgBox("!!! ERROR !!! The IR number was already assigned.")
                CreateIR = False
            Else
                CreateIR = True
                MsgBox("The IR Number will be generate when you will save the MEMO.", MsgBoxStyle.OkOnly)
                'PickIR()
            End If
        End If

    End Sub

    Sub PickIR()

        Dim SwIR As Integer = 0
        txtIR.Text = CallClass.GenerateNextLot("cspGetNextLot", "MEMOIR")
        If txtIR.Text = "ERROR" Then
            Exit Sub
        Else
            SwIR = Val(txtIR.Text)
            txtIR.Text = SwIR

            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "MEMOIR", SwIR)
        End If

    End Sub

    Private Sub CmdRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRMA.Click

        CreateRMA = False
        CreateIR = False

        Dim reply As DialogResult
        reply = MsgBox("Do you want to generate an RMA Number (Yes/No)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            If Len(Trim(txtRMA.Text)) > 0 Then
                MsgBox("!!! ERROR !!! The RMA number was already assigned.")
                CreateRMA = False
            Else
                CreateRMA = True
                MsgBox("The RMA Number will be generate when you will save the MEMO.", MsgBoxStyle.OkOnly)
                'PickRMA()
            End If
        End If

    End Sub

    Sub PickRMA()

        Dim SwRMA As Integer = 0
        txtRMA.Text = CallClass.GenerateNextLot("cspGetNextLot", "MEMORMA")
        If txtRMA.Text = "ERROR" Then
            Exit Sub
        Else
            SwRMA = Val(txtRMA.Text)
            txtRMA.Text = SwRMA

            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "MEMORMA", SwRMA)
        End If

    End Sub


    Sub PutDefCodeNoSystem()

        Try
            With Me.DefCode
                .DataSource = CallClass.PopulateComboBox("tblDefectCodes", "cmbGetDefectCodesNoSystem").Tables("tblDefectCodes")
                .DisplayMember = "FullDesc"
                .ValueMember = "DefCodeId"
                .DropDownWidth = 300
                .MaxDropDownItems = 40
                .DataPropertyName = "DefCode"
                .Name = "DefCode"
            End With
        Catch ex As Exception
        End Try

    End Sub

    Sub PutDefCodeOnlySystem()

        Try
            With Me.DefCode
                .DataSource = CallClass.PopulateComboBox("tblDefectCodes", "cmbGetDefectCodesOnlySystem").Tables("tblDefectCodes")
                .DisplayMember = "FullDesc"
                .ValueMember = "DefCodeId"
                .DropDownWidth = 300
                .MaxDropDownItems = 40
                .DataPropertyName = "DefCode"
                .Name = "DefCode"
            End With
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CmdDisp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDisp.Click
        frmMemoDispRemarks.txtFrom.Text = "Button"
        frmMemoDispRemarks.ShowDialog()
    End Sub


    Private Sub CmdUndoQMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUndoQMS.Click
        RdQuality.Checked = False
        RdMfg.Checked = False
        RdTraining.Checked = False
    End Sub

    Private Sub CmdUndoHSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUndoHSE.Click
        RdHelth.Checked = False
        RdSafety.Checked = False
        RdEnv.Checked = False
    End Sub

    Private Sub RdTraining_Click(sender As Object, e As EventArgs) Handles RdTraining.Click
        If RdTraining.Checked = True Then
            txtObs.Text = "Event Training"
        End If
    End Sub

    Private Sub CmdOpen_Click(sender As Object, e As EventArgs) Handles CmdOpen.Click

        Dim reply As DialogResult

        reply = MsgBox("Do you want to re-open the MEMO # " + CmbMemo.Text + "  (Yes/No)?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            swMPOScrap = True


            frmLisiMemoOpen.SwMemoId.Text = CmbMemo.SelectedValue
            frmLisiMemoOpen.txtObs.Text = ""
            frmLisiMemoOpen.CmdOpenCall.Enabled = False

            frmLisiMemoOpen.ShowDialog()

            CmdOpen.Enabled = False

        End If

    End Sub

    Private Sub CmdViewTraining_Click(sender As Object, e As EventArgs) Handles CmdViewTraining.Click

        Dim pattern As String = ""
        Dim SwPath As String = ""

        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Lisi Training Records\TRAINING\TRAINING AFTER MEMO")

        If Len(txtMemoNo.Text) = 0 Then
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        pattern = "Memo" + txtMemoNo.Text + ".*"

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                Dim proc As New System.Diagnostics.Process()

                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized

                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If

            Exit Sub

        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If


    End Sub

    Sub CheckViewRecord()

        Dim pattern As String = "*.*"
        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        Dim dir_info1 As New IO.DirectoryInfo("\\Srv115fs01\Lisi Training Records\TRAINING\TRAINING AFTER MEMO")

        ListFiles(lstFiles, pattern, dir_info1)

        CmdViewTraining.Visible = True
        CmdViewTraining.Enabled = True
        'If lstFiles.Items.Count > 0 Then
        '    CmdViewTraining.BackColor = Color.Green
        'Else
        '    CmdViewTraining.BackColor = Color.LightGray
        'End If
        
        lstFiles.Items.Clear()
        Dim dir_info2 As New IO.DirectoryInfo("\\Srv115fs01\Quality\MEMO-EVIDENCE-ACTION PLAN\MEMO PICTURE")

        ListFiles(lstFiles, pattern, dir_info1)

        CmdViewOther.Visible = True
        CmdViewOther.Enabled = True
        'If lstFiles.Items.Count > 0 Then
        '    CmdViewOther.BackColor = Color.Green
        'Else
        '    CmdViewOther.BackColor = Color.LightGray
        'End If
      
    End Sub

    Private Sub ListFiles(ByVal lst As ListBox, ByVal pattern As String, ByVal dir_info As IO.DirectoryInfo)

        Try
            ' Get the files in this directory.
            Dim fs_infos() As IO.FileInfo = dir_info.GetFiles(pattern)
            For Each fs_info As IO.FileInfo In fs_infos
                lstFiles.Items.Add(fs_info.FullName)
            Next fs_info
            fs_infos = Nothing

            ' Search subdirectories.
            Dim subdirs() As IO.DirectoryInfo = dir_info.GetDirectories()
            For Each subdir As IO.DirectoryInfo In subdirs
                ListFiles(lst, pattern, subdir)
            Next subdir

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdViewOther_Click(sender As Object, e As EventArgs) Handles CmdViewOther.Click

        Dim pattern As String = ""
        Dim SwPath As String = ""

        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Quality\MEMO-EVIDENCE-ACTION PLAN\MEMO PICTURE")

        If Len(txtMemoNo.Text) = 0 Then
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        pattern = "Memo" + txtMemoNo.Text + ".*"

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                Dim proc As New System.Diagnostics.Process()

                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized

                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If

            Exit Sub

        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If

    End Sub


End Class