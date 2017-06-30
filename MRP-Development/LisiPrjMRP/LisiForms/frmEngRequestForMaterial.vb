Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail


Public Class frmEngRequestForMaterial

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Private daRMReq As New SqlDataAdapter

    Dim RMReqCurrency As CurrencyManager

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim RowSpec As Integer = 0
    Dim KeepNo As Integer = 0
    Dim SwRMREQNOID As Integer = 0
    Dim SwOper As String = ""

    Dim SwFirstReset As Boolean = True

    Dim II, JJ As Integer

    Private Sub frmEngRequestForMaterial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If SwFrom.Text = "POMAT" Then

            Exit Sub

        Else

            Dim reply As DialogResult

            RMReqCurrency.EndCurrentEdit()

            If dsMain.HasChanges Then
                reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
                Exit Sub
            End If

            dsMain.RejectChanges()
            dsMain.Dispose()

            daRMReq.Dispose()

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            Me.Dispose()

            GC.Collect()

        End If

    End Sub

    Private Sub frmEngRequestForMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GC.Collect()

        HideCtl()

        DisableFields()


        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        InitFields()    '====

        BindComponents()

        PutEMReqNO()

        txtRMREQDate.Text = Now.ToShortDateString

        CmbRMReq.DataSource = dsMain.Tables("tblMatlREQ")
        CmbRMReq.DisplayMember = "RMReqNo"
        CmbRMReq.ValueMember = "RMReqID"

        CmbRMReq.Enabled = True
        CmbRMReq.Focus()

        If SwFrom.Text = "POMAT" Then
            CmdNew.Visible = False
            CmdEdit.Visible = False
            CmdSave.Visible = False
            CmdPrint.Visible = False
            'CmdReset.Visible = False

            CmdSend.Visible = True
            CmdSend.Enabled = False
        Else
            CmdNew.Visible = True
            CmdEdit.Visible = True
            CmdSave.Visible = True
            CmdPrint.Visible = True
            CmdReset.Visible = True

            CmdSend.Visible = False

        End If

    End Sub

    Sub HideCtl()

        PanelDetail.Visible = False

    End Sub

    Sub ShowCtl()
        PanelDetail.Visible = True
    End Sub

    Sub DisableFields()

        CmbStatus.Enabled = False
        CmbUser.Enabled = False
        txtRMREQDate.Enabled = False
        txtRMApprDate.Enabled = False

        CmbApprBy.Enabled = False
        ChAppr.Enabled = False

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdSearch.Enabled = False
        CmdReset.Enabled = True

        LbInside.Visible = False
        txtInsideAW.Visible = False

        SetReadOnlyTrue()

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daRMReq = CallClass.PopulateDataAdapter("getTblMatlREQ")

            Dim RMReqBuilder As New SqlClient.SqlCommandBuilder(daRMReq)

            daRMReq.UpdateCommand = RMReqBuilder.GetUpdateCommand
            daRMReq.UpdateCommand.Connection = cn
            daRMReq.InsertCommand = RMReqBuilder.GetInsertCommand
            AddHandler daRMReq.RowUpdated, AddressOf HandleRowUpdatedRMReq
            daRMReq.InsertCommand.Connection = cn
            daRMReq.DeleteCommand = RMReqBuilder.GetDeleteCommand
            daRMReq.DeleteCommand.Connection = cn
            daRMReq.AcceptChangesDuringFill = True
            daRMReq.TableMappings.Add("Table", "tblMatlREQ")
            daRMReq.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured on BuildSqlCommand - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedRMReq(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMatlREQ").Columns("RMReqID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub SetCtlForm()

        PutUser()
        PutMatlType()
        PutVerApprBy()
        PutApprSource()

        'For dgSpecs properies

        With Me.SpecID
            .DataPropertyName = "SpecID"
            .Name = "SpecID"
            .Visible = False
        End With

        With Me.RMReqSpecID
            .DataPropertyName = "RMReqSpecID"
            .Name = "RMReqSpecID"
            Visible = False
        End With

        With Me.RMReqID
            .DataPropertyName = "RMReqID"
            .Name = "RMReqID"
            .Visible = False
        End With

        With Me.RMReqMatlType
            .DataPropertyName = "RMReqMatlType"
            .Name = "RMReqMatlType"
        End With

        With Me.RMReqDetKSI
            .DataPropertyName = "RMReqDetKSI"
            .Name = "RMReqDetKSI"
        End With

        With Me.RMReqSpecNo
            .DataPropertyName = "RMReqSpecNo"
            .Name = "RMReqSpecNo"
        End With

        With Me.RMReqSpecDescr
            .DataPropertyName = "RMReqSpecDescr"
            .Name = "RMReqSpecDescr"
        End With

        With Me.RMReqSpecNotes
            .DataPropertyName = "RMReqSpecNotes"
            .Name = "RMReqSpecNotes"
        End With

        With Me.RMReqSpecRev
            .DataPropertyName = "RMReqSpecRev"
            .Name = "RMReqSpecRev"
        End With

        With Me.RMReqSpecDate
            .DataPropertyName = "RMReqSpecDate"
            .Name = "RMReqSpecDate"
        End With

        With Me.RMReqSpecStd
            .DataPropertyName = "RMReqSpecStd"
            .Name = "RMReqSpecStd"
        End With

        With Me.RMReqSpecChe
            .DataPropertyName = "RMReqSpecChe"
            .Name = "RMReqSpecChe"
        End With

        With Me.RMReqSpecCap
            .DataPropertyName = "RMReqSpecCap"
            .Name = "RMReqSpecCap"
        End With

        With Me.SwOperation
            .DataPropertyName = "SwOperation"
            .Name = "SwOperation"
        End With

        '  dgMPO

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.MpoPromDate
            .DataPropertyName = "MpoPromDate"
            .Name = "MpoPromDate"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.RawWeight
            .DataPropertyName = "RawWeight"
            .Name = "RawWeight"
        End With

        With Me.MpoEstWeight
            .DataPropertyName = "MpoEstWeight"
            .Name = "MpoEstWeight"
        End With

    End Sub

    Sub InitFields()

        'CmbRMReq.SelectedIndex = -1

        SwFirstReset = True

        SwOper = ""

        CmbStatus.Text = ""
        CmbUser.SelectedValue = wkEmpId
        CmbSource.SelectedIndex = -1
        CmbMatlType.SelectedIndex = -1
        CmbKSI.SelectedIndex = -1
        CmbDia.SelectedIndex = -1

        CmbApprBy.SelectedIndex = -1

        txtRMReqNo.Text = ""

        txtRMREQDate.Text = ""
        txtRMApprDate.Text = ""

        txtShear.Text = ""
        txtInsideAW.Text = 0.0
        txtHardness.Text = ""
        txtCoatedOther.Text = ""
        txtQty.Text = ""
        txtHT.Text = ""
        txtUltraSonic.Text = ""
        txtCondOthers.Text = ""
        txtGenNotes.Text = ""
        txtNotes.Text = ""

        txtMPOQty.Text = ""

        RdBars.Checked = False
        RdCoils.Checked = False
        RdHEX.Checked = False
        RdTube.Checked = False
        RdSheet.Checked = False
        RdStock.Checked = False
        RdMPO.Checked = False

        Chk_Coated_Cu.Checked = False
        Chk_Coated_Phosphate.Checked = False
        Chk_Cond_ANN1.Checked = False
        Chk_Cond_ANN2.Checked = False
        Chk_Cond_VAR.Checked = False
        Chk_Cond_VIM.Checked = False
        Chk_Cond_ESR.Checked = False

        ChAppr.Checked = False

    End Sub

    Sub FirstTimeMenuButtons()

        CmdNew.Enabled = True
        CmdEdit.Enabled = False
        CmdSeeRMReq.Enabled = True
        CmdSave.Enabled = False
        CmdPrint.Enabled = False
        CmdReset.Enabled = True

    End Sub

    Protected Sub SetReadOnlyTrue()

        For Each ctrl As Control In PanelDetail.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = True
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = False
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = False
            End If

            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = False
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = False
            End If

        Next

        PanelBars.Enabled = False
        PanelProd.Enabled = False

        dgSpecs.ReadOnly = True

    End Sub

    Protected Sub SetReadOnlyFalse()

        For Each ctrl As Control In PanelDetail.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).ReadOnly = False
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = True
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = True
            End If

            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = True
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = True
            End If
        Next

        PanelBars.Enabled = True
        PanelProd.Enabled = True

        dgSpecs.ReadOnly = False

        txtMPOQty.ReadOnly = True

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblMemoDescrEmpty").Fill(dsMain, "tblSelect")         ' is a dummy store procedure

        CallClass.PopulateDataAdapter("gettblMatlREQSpecEmpty").Fill(dsMain, "tblMatlReqSpecs")

        daRMReq.FillSchema(dsMain, SchemaType.Source, "tblMatlReq")

        daRMReq.Fill(dsMain, "tblMatlReq")
        Dim WReqID As DataColumn = dsMain.Tables("tblMatlReq").Columns("RMReqID")
        WReqID.AutoIncrement = True
        WReqID.AutoIncrementStep = -1
        WReqID.AutoIncrementSeed = -1
        WReqID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("WWReqForSpec", _
                .Tables("tblMatlReq").Columns("RMReqID"), _
                .Tables("tblMatlReqSpecs").Columns("RMReqID"), True)
        End With

        RMReqCurrency = CType(BindingContext(dsMain, "tblMatlReq"), CurrencyManager)

        dgSpecs.AutoGenerateColumns = False
        dgSpecs.DataSource = dsMain
        dgSpecs.DataMember = "tblMatlReqSpecs"

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelect"

    End Sub

    Sub PutEMReqNO()

        With Me.CmbRMReq
            .DataSource = CallClass.PopulateComboBox("tblMatlREQ", "cmbGetRMReqNo").Tables("tblMatlREQ")
            .DisplayMember = "RMReqNo"
            .ValueMember = "RMReqID"
        End With

    End Sub

    Sub PutUser()

        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEmployeeAll").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub PutVerApprBy()

        With Me.CmbApprBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetRMREQAppr").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub PutApprSource()

        With Me.CmbSource
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierGroup1").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
        End With

    End Sub

    Sub PutMatlType()

        With Me.CmbMatlType
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 40
        End With

    End Sub

    Sub PutMatlKSI()

        With Me.CmbKSI
            .DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlKSIRMREQ", CmbMatlType.SelectedValue).Tables("tblMatlMasterDetails")
            .DisplayMember = "MatDetKSI"
            .ValueMember = "MatlDetID"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
        End With

    End Sub

    Sub PutMatlDIA()

        With Me.CmbDia
            .DataSource = CallClass.PopulateComboBoxWithParam("tblPartMatlPref", "cmbGetMatlDIA", CmbMatlType.SelectedValue).Tables("tblPartMatlPref")
            .DisplayMember = "MatlDIA"
            .ValueMember = "MatlDIA"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
        End With

    End Sub


    Sub BindComponents()

        RdBars.Checked = False
        RdCoils.Checked = False
        RdHEX.Checked = False
        RdTube.Checked = False
        RdSheet.Checked = False

        RdStock.Checked = False
        RdMPO.Checked = False

        Chk_Coated_Cu.Checked = False
        Chk_Coated_Phosphate.Checked = False

        Chk_Cond_ANN1.Checked = False
        Chk_Cond_ANN2.Checked = False
        Chk_Cond_VAR.Checked = False
        Chk_Cond_VIM.Checked = False
        Chk_Cond_ESR.Checked = False

        ChAppr.Checked = False

        RdBars.DataBindings.Clear()
        RdCoils.DataBindings.Clear()
        RdHEX.DataBindings.Clear()
        RdTube.DataBindings.Clear()
        RdSheet.DataBindings.Clear()

        RdStock.DataBindings.Clear()
        RdMPO.DataBindings.Clear()

        Chk_Coated_Cu.DataBindings.Clear()
        Chk_Coated_Phosphate.DataBindings.Clear()

        Chk_Cond_ANN1.DataBindings.Clear()
        Chk_Cond_ANN2.DataBindings.Clear()
        Chk_Cond_VAR.DataBindings.Clear()
        Chk_Cond_VIM.DataBindings.Clear()
        Chk_Cond_ESR.DataBindings.Clear()

        ChAppr.DataBindings.Clear()

        CmbStatus.DataBindings.Clear()
        CmbUser.DataBindings.Clear()
        CmbSource.DataBindings.Clear()
        CmbApprBy.DataBindings.Clear()
        CmbMatlType.DataBindings.Clear()
        CmbDia.DataBindings.Clear()
        CmbKSI.DataBindings.Clear()
        KsiID.DataBindings.Clear()

        txtRMReqNo.DataBindings.Clear()


        txtRMREQDate.DataBindings.Clear()
        txtRMApprDate.DataBindings.Clear()

        txtInsideAW.DataBindings.Clear()
        txtShear.DataBindings.Clear()
        txtHardness.DataBindings.Clear()
        txtQty.DataBindings.Clear()
        txtCoatedOther.DataBindings.Clear()
        txtHT.DataBindings.Clear()
        txtUltraSonic.DataBindings.Clear()
        txtCondOthers.DataBindings.Clear()
        txtGenNotes.DataBindings.Clear()
        txtNotes.DataBindings.Clear()

        txtRMReqNo.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqNo")

        txtRMREQDate.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")
        txtRMApprDate.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqApprDate", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyyy")

        txtShear.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqShear")
        txtHardness.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqHardness")
        txtQty.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqQty")
        txtCoatedOther.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqCoatedOthersTxt")
        txtHT.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqCondHTTxt")
        txtUltraSonic.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqCondUltrasonicTxt")
        txtCondOthers.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqCondOthersTxt")
        txtGenNotes.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqGenNotes")
        txtNotes.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqNotes")
        txtInsideAW.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqInsideDIA")

        CmbStatus.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqStatus")
        CmbUser.DataBindings.Add("SelectedValue", dsMain, "tblMatlREQ.RMReqbyUser")
        CmbApprBy.DataBindings.Add("SelectedValue", dsMain, "tblMatlREQ.RMReqbyAppr")
        CmbSource.DataBindings.Add("SelectedValue", dsMain, "tblMatlREQ.RMReqApprSource")
        CmbMatlType.DataBindings.Add("SelectedValue", dsMain, "tblMatlREQ.RMReqMatlID")
        CmbDia.DataBindings.Add("Text", dsMain, "tblMatlREQ.RMReqDIA")
        CmbKSI.DataBindings.Add("text", dsMain, "tblMatlREQ.RMReqUTSKSI")
        KsiID.DataBindings.Add("text", dsMain, "tblMatlREQ.RMReqUTSKSIID")

        RdBars.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqBars", True))
        RdCoils.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCoils", True))
        RdHEX.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqHex", True))
        RdTube.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqTube", True))
        RdSheet.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqSheet", True))
        RdStock.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqForStock", True))
        RdMPO.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqForProd", True))

        Chk_Coated_Cu.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCoatedCopper", True))
        Chk_Coated_Phosphate.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCoatedPhosphate", True))
        Chk_Cond_ANN1.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCondAnnealed", True))
        Chk_Cond_ANN2.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCondAnnAndDrawn", True))
        Chk_Cond_VAR.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqCondVAR", True))
        Chk_Cond_VIM.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqVIM", True))
        Chk_Cond_ESR.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMReqESR", True))

        ChAppr.DataBindings.Add(New Binding("Checked", dsMain, "tblMatlREQ.RMApprCheck", True))

        If IsDBNull(RdBars.Text) = True Then
            RdBars.Checked = False
        End If
        If IsDBNull(RdCoils.Text) = True Then
            RdCoils.Checked = False
        End If
        If IsDBNull(RdHEX.Text) = True Then
            RdHEX.Checked = False
        End If
        If IsDBNull(RdTube.Text) = True Then
            RdTube.Checked = False
            LbInside.Visible = False
            txtInsideAW.Visible = True
        Else
            LbInside.Visible = True
            txtInsideAW.Visible = True
        End If
        If IsDBNull(RdSheet.Text) = True Then
            RdSheet.Checked = False
        End If

        If IsDBNull(RdStock.Text) = True Then
            RdStock.Checked = False
        End If
        If IsDBNull(RdMPO.Text) = True Then
            RdMPO.Checked = False
        End If

        If IsDBNull(Chk_Coated_Cu.Text) = True Then
            Chk_Coated_Cu.Checked = False
        End If
        If IsDBNull(Chk_Coated_Phosphate.Text) = True Then
            Chk_Coated_Phosphate.Checked = False
        End If

        If IsDBNull(Chk_Cond_ANN1.Text) = True Then
            Chk_Cond_ANN1.Checked = False
        End If
        If IsDBNull(Chk_Cond_ANN2.Text) = True Then
            Chk_Cond_ANN2.Checked = False
        End If
        If IsDBNull(Chk_Cond_VAR.Text) = True Then
            Chk_Cond_VAR.Checked = False
        End If
        If IsDBNull(Chk_Cond_VIM.Text) = True Then
            Chk_Cond_VIM.Checked = False
        End If
        If IsDBNull(Chk_Cond_ESR.Text) = True Then
            Chk_Cond_ESR.Checked = False
        End If

        Select Case (CmbStatus.Text)
            Case "Active"
            Case "Closed"
                MsgBox("This RM REQ has been Closed.")
                DisableFields()
                'ViewDisable()
            Case "Cancelled"
                MsgBox("This RM REQ has been cancelled.")
                DisableFields()
                ' ViewDisable()
        End Select

    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click

        SwFirstReset = False
        SwOper = "New"

        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        CmdNew.Enabled = False
        CmdReset.Enabled = True

        dsMain.RejectChanges()
        dgSpecs.Refresh()
        dgMPO.Refresh()

        CmbRMReq.SelectedIndex = -1

        dsMain.Tables("tblSelect").Clear()
        dsMain.Tables("tblMatlReqSpecs").Clear()
        txtMPOQty.Text = ""

        RMReqCurrency.EndCurrentEdit()
        RMReqCurrency.AddNew()

        InitFields()
        PutGenNotes()


        RdBars.Checked = True
        RdMPO.Checked = True
        CmbStatus.SelectedText = "Active"
        txtRMReqNo.Text = ""
        txtRMREQDate.Text = Now.ToShortDateString

        CmbUser.SelectedValue = wkEmpId

        CmbRMReq.Enabled = False
        SetReadOnlyFalse()

        ShowCtl()

        'If RoleRMREQAPPR(wkDeptCode) = True Then   ' they can create 
        '    CmbApprBy.Enabled = True
        'Else
        '    CmbApprBy.Enabled = False
        'End If

    End Sub

    Sub PutGenNotes()

        Dim str1 As String = ""
        Dim str2 As String = ""

        txtGenNotes.Text = "One heat Lot mandatory for each Item / LAC PO Line    One Raw Material batch per LAC PO Line" & vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Centerless  Ground  Bars                                        Material shall be uniform" & vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Defect free and Seam free                                      All alloy steel shall be decarb free" + vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Minimum bar length shall be 10 feet.                          Mill & Test cert required" + vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Material shall be adaquatly packaged to avoid damage   Qty Delivary Tolerance  +/- 10%" & vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "MP35N, MP159 use wood box or equivalent for packaging" & vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Surface Finish  50 RMS maximum." & vbCrLf
        txtGenNotes.Text = txtGenNotes.Text & "Coils to be in 250 lb max. strands." & vbCrLf

        txtGenNotes.Text = txtGenNotes.Text & "Specified MCL Requiremnts for PW orders:" & vbCrLf

    End Sub

    Private Sub CmdReset_Click(sender As Object, e As EventArgs) Handles CmdReset.Click

        SwFirstReset = True
        SwOper = "Reset"

        RMReqCurrency.EndCurrentEdit()

        dsMain.Tables("tblSelect").Clear()
        dsMain.Tables("tblMatlReqSpecs").Clear()

        txtMPOQty.Text = ""

        CmdSend.Enabled = False

        HideCtl()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        InitFields()    '====

        BindComponents()

        PutEMReqNO()

        txtRMREQDate.Text = Now.ToShortDateString


        CmbRMReq.DataSource = dsMain.Tables("tblMatlREQ")
        CmbRMReq.DisplayMember = "RMReqNo"
        CmbRMReq.ValueMember = "RMReqID"

        CmbRMReq.Enabled = True
        CmbRMReq.Focus()

        If SwFrom.Text = "POMAT" Then
            CmdSend.Enabled = False
        End If

    End Sub

    Private Sub CmbMatlType_DropDownClosed(sender As Object, e As EventArgs) Handles CmbMatlType.DropDownClosed

        PutMatlDIA()
        PutMatlKSI()
        CmbDia.SelectedIndex = -1
        CmbKSI.SelectedIndex = -1
        CmdSearch.Enabled = True

    End Sub

    Sub PutSpecRev()

        Dim StrSearch As Integer = 0
        Dim TakeRev As String = ""
        Dim TakeRevDate As String = ""

        For I As Integer = 0 To (dgSpecs.Rows.Count - 1)

            StrSearch = Nz.Nz(dgSpecs("SpecID", I).Value)

            TakeRev = CallClass.ReturnStrWithParInt("cspReturnRMSpecLastRev", StrSearch)
            If TakeRev = "False" Then
                TakeRev = ""
            End If
            dgSpecs("RMReqSpecRev", I).Value = TakeRev

            TakeRevDate = CallClass.ReturnStrWithParInt("cspReturnRMSpecLastRevDate", StrSearch)
            If TakeRevDate = "False" Then
                TakeRevDate = ""
            End If
            dgSpecs("RMReqSpecDate", I).Value = TakeRevDate

        Next I

    End Sub

    Private Sub dgSpecs_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgSpecs.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSpec = e.RowIndex
        End If

        If dgSpecs.ReadOnly = True Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 1 To 7
                e.Cancel = True

            Case 8
                If Nz.Nz(dgSpecs.Rows(e.RowIndex).Cells("RMReqSpecChe").Value) = "1" Then
                    e.Cancel = True
                End If
                If Nz.Nz(dgSpecs.Rows(e.RowIndex).Cells("RMReqSpecCap").Value) = "1" Then
                    e.Cancel = True
                End If

                dgSpecs.Rows(e.RowIndex).Cells("SwSelectLine").Value = "1"

            Case 9, 10

                If Nz.Nz(dgSpecs.Rows(e.RowIndex).Cells("RMReqSpecStd").Value) = "1" Then
                    e.Cancel = True
                End If
                dgSpecs.Rows(e.RowIndex).Cells("SwSelectLine").Value = "1"

            Case 11

                If Len(Trim(dgSpecs.Rows(e.RowIndex).Cells("RMReqSpecNo").Value)) = 0 Then
                    dgSpecs.Rows(e.RowIndex).Cells("SwSelectLine").ReadOnly = True
                    MsgBox("Action Denied - Missing RM Spec No.")
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgSpecs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpecs.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSpec = e.RowIndex
        End If

        If dgSpecs.ReadOnly = True Then
            Exit Sub
        End If

    End Sub

    Private Sub CmdSearch_Click(sender As Object, e As EventArgs) Handles CmdSearch.Click

        dsMain.Tables("tblSelect").Clear()
        dsMain.Tables("tblMatlReqSpecs").Clear()
        txtMPOQty.Text = ""

        Dim Par1, Par2, Par3 As String

        If IsDBNull(CmbKSI.SelectedValue) = True Then
            CmbKSI.SelectedValue = ""
        End If

        Par1 = CmbMatlType.SelectedValue
        Par2 = Microsoft.VisualBasic.Left(Trim(CmbKSI.Text), 3)
        Par3 = CmbDia.Text

        If Len(Trim(Par1)) = 0 And Len(Trim(Par2)) = 0 Then
            MsgBox("Material Tyupe and UTS/KSI need to be selected before this action.")
            Exit Sub
        End If

        If Len(Trim(Par1)) = 0 And Len(Trim(Par3)) = 0 Then
            MsgBox("Material Tyupe and DIA need to be selected before this action.")
            Exit Sub
        End If

        If Len(Trim(Par2)) > 0 Then

            CallClass.PopulateDataAdapterSearch2Param("getMatlSpecForProposal2Param", Par1, Par2).Fill(dsMain, "tblMatlReqSpecs")
        Else

            CallClass.PopulateDataAdapterAfterSearch("getMatlSpecForProposal1Param", Par1).Fill(dsMain, "tblMatlReqSpecs")
        End If

        dgSpecs.AutoGenerateColumns = False
        dgSpecs.DataSource = dsMain
        dgSpecs.DataMember = "tblMatlReqSpecs"

        If Len(Trim(Par3)) > 0 Then
            CallClass.PopulateDataAdapterSearch2Param("getMatlSpecForProposalMPOs", Par1, Par3).Fill(dsMain, "tblSelect")
            dgMPO.AutoGenerateColumns = False
            dgMPO.DataSource = dsMain
            dgMPO.DataMember = "tblSelect"
        Else
            MsgBox("!!! ERROR !!! - Missing Dia.")
        End If

        PutSpecRev()
        PutTotalMPOQty()

    End Sub

    Sub PutTotalMPOQty()

        Dim qtyMPO As Double = 0.0
        txtMPOQty.Text = ""

        For Each Row As DataGridViewRow In dgMPO.Rows
            qtyMPO = qtyMPO + Val(Row.Cells("MpoEstWeight").Value)
        Next

        txtMPOQty.Text = qtyMPO.ToString("N0")

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

        SwFirstReset = False

        SwOper = "Save"

        dgSpecs.Focus()
        dgSpecs.Refresh()

        dgMPO.Focus()
        dgMPO.Refresh()

        PanTool.Focus()
        PanelDetail.Focus()

        txtRMReqNo.Focus()
        CmdPrint.Focus()
        dgSpecs.Focus()
        txtRMReqNo.Focus()
        CmbUser.Focus()
        Me.Focus()
        Me.Validate()
        CmdPrint.Focus()
        CmbMatlType.Focus()
        CmbDia.Focus()

        Call ValPo()

        If SwVal = False Then
            Exit Sub
        End If

        SwOper = "Save"

        If Len(Trim(txtRMReqNo.Text)) = 0 Then

            PutRMReqNo()

            If txtRMReqNo.Text = "ERROR" Then
                MsgBox("!!! ERROR !!! - RM REQ number can not be generated. Action Denied. Try again to SAVE.")
                GoTo EXITFORCE
                Exit Sub
            End If
        End If

        Me.Validate()
        RMReqCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daRMReq.Update(dsMain.Tables("tblMatlREQ").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                UpdateRMREQNOSpecs(dsMain.GetChanges)
                MsgBox("Update successfully.")

            End If

        Catch ex As Exception
            dsMain.RejectChanges()
            MsgBox("Exception occured on SAVE function - " & ex.Message)
        End Try

        dsMain.AcceptChanges()


        Dim reply As DialogResult
        Dim email As New Mail.MailMessage()
        Dim strBody As String = ""
        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)

        If RoleRMREQPO(wkDeptCode) = True Then
            reply = MsgBox("DO you want to send an email for REQ RM approval ? Continue(Yes / No)", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then
                email.Subject = " !!! PURCHASING MATERIAL REQUEST FOR APPROVAL !!!"
                strBody = "RM REQ Number :   " + txtRMReqNo.Text + "   was Created / Modified in MRP." + vbCrLf
                strBody = strBody + "======================================================" + vbCrLf
                strBody = strBody + "Material Type : " + CmbMatlType.Text + vbCrLf
                strBody = strBody + "DIA (Inches)  : " + CmbDia.Text + vbCrLf
                strBody = strBody + "Total RM (LBS): " + txtQty.Text

                email.Body = strBody
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("ApproveRM.Montreal@lisi-aerospace.com"))
                'email.To.Add(New Mail.MailAddress("Yanick.Levert@lisi-aerospace.com"))
                client.Send(email)
            End If

        End If


        If CmbStatus.Text = "Approved" Then
            email.Subject = " !!!  RAW MATERIAL PURCHASE REQUEST WAS APPROVED - PLEASE PROCEED WITH THE PO !!!"
            strBody = "RM REQ Number :   " + txtRMReqNo.Text + "   was approved." + vbCrLf
            strBody = strBody + "=======================================" + vbCrLf
            strBody = strBody + "Material Type : " + CmbMatlType.Text + vbCrLf
            strBody = strBody + "DIA (Inches)  : " + CmbDia.Text + vbCrLf
            strBody = strBody + "Total RM (LBS): " + txtQty.Text

            email.Body = strBody
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("Purchase.Montreal@lisi-aerospace.com"))
            email.To.Add(New Mail.MailAddress("Yanick.Levert@lisi-aerospace.com"))
            client.Send(email)
        End If

        dgSpecs.Refresh()
        dgMPO.Refresh()

        SwOper = ""
        DisableFields()
        SetReadOnlyTrue()
        FirstTimeMenuButtons()
        CmdNew.Enabled = False
        BindComponents()


EXITFORCE:

    End Sub

    Sub UpdateRMREQNOSpecs(ByVal dsChanges As DataSet)

        If dgSpecs.RowCount > 0 Then
            Try

                SwRMREQNOID = 0
                strSQL = "SELECT tblMatlREQ.RMReqID FROM tblMatlREQ WHERE ((tblMatlREQ.RMReqNo)= '" & txtRMReqNo.Text & "')"

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
                        MessageBox.Show("!!! ERROR DATABASE!!!! Find RMReqNo Number")
                        Exit Sub
                    Else
                        While myReader.Read()
                            SwRMREQNOID = myReader.GetValue(0)
                        End While
                        myReader.Close()
                        myReader.Dispose()
                    End If
                Catch ex As Exception
                    MsgBox("Exception occured - When try to identify the RMReqNo No   " & ex.Message)
                    Exit Sub
                End Try

                If SwRMREQNOID > 0 Then

                    CheckUpdateRMSpecsModifyDelete()

                    CheckUpdateRMSpecsInsert()

                Else
                    'MsgBox("Update for the info RM REQ Specs faild.")
                End If



            Catch ex As Exception
                MsgBox("Exception occured - " & ex.Message)
            End Try
        End If

    End Sub


    Sub CheckUpdateRMSpecsInsert()


        If dgSpecs.Rows.Count <= 0 Then
            Exit Sub
        End If

        JJ = dgSpecs.Rows.Count

        For II = 1 To JJ

            Dim cmdInsRMSpecs As SqlCommand = New SqlCommand("cspUpdateRMREQNOSpecsInsert", cn)
            cmdInsRMSpecs.CommandType = CommandType.StoredProcedure

            If Nz.Nz(dgSpecs.Item("SwSelectLine", II - 1).Value) = "1" Then
                Dim parSpecID As SqlParameter = New SqlParameter("@RMReqSpecID", SqlDbType.Int, 4)
                parSpecID.Value = dgSpecs.Item("RMReqSpecID", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecID)

                Dim parReqID As SqlParameter = New SqlParameter("@RMReqID", SqlDbType.Int, 4)
                parReqID.Value = SwRMREQNOID
                cmdInsRMSpecs.Parameters.Add(parReqID)

                Dim parMatlType As SqlParameter = New SqlParameter("@RMReqMatlType", SqlDbType.NVarChar, 50)
                parMatlType.Value = dgSpecs.Item("RMReqMatlType", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parMatlType)

                Dim parDetKSI As SqlParameter = New SqlParameter("@RMReqDetKSI", SqlDbType.NVarChar, 100)
                parDetKSI.Value = dgSpecs.Item("RMReqDetKSI", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parDetKSI)

                Dim parSpecNo As SqlParameter = New SqlParameter("@RMReqSpecNo", SqlDbType.NVarChar, 50)
                parSpecNo.Value = dgSpecs.Item("RMReqSpecNo", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecNo)

                Dim parSpecDescr As SqlParameter = New SqlParameter("@RMReqSpecDescr", SqlDbType.NVarChar, 500)
                parSpecDescr.Value = dgSpecs.Item("RMReqSpecDescr", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecDescr)

                Dim parSpecNotes As SqlParameter = New SqlParameter("@RMReqSpecNotes", SqlDbType.NVarChar, 1000)
                parSpecNotes.Value = dgSpecs.Item("RMReqSpecNotes", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecNotes)

                Dim parSpecRev As SqlParameter = New SqlParameter("@RMReqSpecRev", SqlDbType.NVarChar, 50)
                parSpecRev.Value = dgSpecs.Item("RMReqSpecRev", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecRev)

                Dim parSpecDate As SqlParameter = New SqlParameter("@RMReqSpecDate", SqlDbType.SmallDateTime, 4)
                parSpecDate.Value = dgSpecs.Item("RMReqSpecDate", II - 1).Value
                cmdInsRMSpecs.Parameters.Add(parSpecDate)

                Dim parSpecStd As SqlParameter = New SqlParameter("@RMReqSpecStd", SqlDbType.Bit, 1)
                parSpecStd.Value = Nz.Nz(dgSpecs.Item("RMReqSpecStd", II - 1).Value)
                cmdInsRMSpecs.Parameters.Add(parSpecStd)

                Dim parSpecChe As SqlParameter = New SqlParameter("@RMReqSpecChe", SqlDbType.Bit, 1)
                parSpecChe.Value = Nz.Nz(dgSpecs.Item("RMReqSpecChe", II - 1).Value)
                cmdInsRMSpecs.Parameters.Add(parSpecChe)

                Dim parSpecCap As SqlParameter = New SqlParameter("@RMReqSpecCap", SqlDbType.Bit, 1)
                parSpecCap.Value = Nz.Nz(dgSpecs.Item("RMReqSpecCap", II - 1).Value)
                cmdInsRMSpecs.Parameters.Add(parSpecCap)

                Try
                    If cn.State = ConnectionState.Closed Then
                        cn.Open()
                    End If
                    cmdInsRMSpecs.ExecuteNonQuery()
                    cmdInsRMSpecs.Dispose()
                Catch ex As SqlException
                    MsgBox("Insert RM Specs: " & ex.Message)
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                Finally
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End Try

            End If

        Next



    End Sub

    Sub CheckUpdateRMSpecsModifyDelete()

        Dim cmdDelRMSpecs As SqlCommand = New SqlCommand("cspUpdateRMREQNOSpecsDelete", cn)
        cmdDelRMSpecs.CommandType = CommandType.StoredProcedure

        Dim parReqID As SqlParameter = New SqlParameter("@RMReqID", SqlDbType.Int, 4)
        parReqID.Value = SwRMREQNOID
        cmdDelRMSpecs.Parameters.Add(parReqID)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            cmdDelRMSpecs.ExecuteNonQuery()
            cmdDelRMSpecs.Dispose()
        Catch ex As SqlException
            MsgBox("Delete RM Specs: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub PutRMReqNo()

        txtRMReqNo.Text = CallClass.GenerateNextLot("cspGetNextLot", "RMREQNO")
        If txtRMReqNo.Text = "ERROR" Then
            Exit Sub
        Else
            KeepNo = Val(txtRMReqNo.Text)
            txtRMReqNo.Text = Trim(txtRMReqNo.Text)

            UpdateNextLot()
        End If

    End Sub

    Sub UpdateNextLot()

        CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "RMREQNO", KeepNo)

    End Sub

    Sub ValPo()

        If ChAppr.CheckState = CheckState.Unchecked Then
            ChAppr.Checked = False
        End If

        If Chk_Coated_Cu.CheckState = CheckState.Unchecked Then
            Chk_Coated_Cu.Checked = False
        End If
        If Chk_Coated_Phosphate.CheckState = CheckState.Unchecked Then
            Chk_Coated_Phosphate.Checked = False
        End If

        If Chk_Cond_ANN1.CheckState = CheckState.Unchecked Then
            Chk_Cond_ANN1.Checked = False
        End If
        If Chk_Cond_ANN2.CheckState = CheckState.Unchecked Then
            Chk_Cond_ANN2.Checked = False
        End If
        If Chk_Cond_VAR.CheckState = CheckState.Unchecked Then
            Chk_Cond_VAR.Checked = False
        End If
        If Chk_Cond_VIM.CheckState = CheckState.Unchecked Then
            Chk_Cond_VIM.Checked = False
        End If
        If Chk_Cond_ESR.CheckState = CheckState.Unchecked Then
            Chk_Cond_ESR.Checked = False
        End If

        If RdTube.Checked = True Then
            If Len(Trim(txtInsideAW.Text)) = 0 Then
                MsgBox("!!! ERROR !!! Missing Inside Tube DIA.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Len(Trim(CmbMatlType.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Material Type.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbDia.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Material DIA.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbSource.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Material Approved Source.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtQty.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing RM Qty REQ.")
            SwVal = False
            Exit Sub
        End If

        If IsNumeric(txtQty.Text) = False Then
            MsgBox("!!! ERROR !!! RM qty REQ is not numeric.")
            SwVal = False
            Exit Sub
        End If

        If Nz.Nz(txtQty.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing RM Qty REQ.")
            SwVal = False
            Exit Sub
        End If

        If Nz.Nz(txtQty.Text) < Nz.Nz(txtMPOQty.Text) Then
            MsgBox("RM Qty REQ is less than the Total MPOs WFM qty proposed to purchase.")

            Dim reply As DialogResult
            reply = MsgBox("Accepted?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                SwVal = False
                Exit Sub
            End If
        End If

        For Each Row As DataGridViewRow In dgSpecs.Rows
            If IsDBNull(Row.Cells("RMReqSpecStd").Value) = False Then
                If Nz.Nz(Row.Cells("RMReqSpecStd").Value) = "1" Then

                    If IsDBNull(Row.Cells("RMReqSpecChe").Value) = False Then
                        If Nz.Nz(Row.Cells("RMReqSpecChe").Value) = "1" Then
                            MsgBox("!!! ERROR !!! Chemistry Only should be unchecked.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If
                    If IsDBNull(Row.Cells("RMReqSpecCap").Value) = False Then
                        If Nz.Nz(Row.Cells("RMReqSpecCap").Value) = "1" Then
                            MsgBox("!!! ERROR !!! Capable Only should be unchecked.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If
                End If
            End If

        Next

        II = 0
        JJ = 0
        For Each Row As DataGridViewRow In dgSpecs.Rows
            If Nz.Nz(Row.Cells("SwSelectLine").Value) = "1" Then
                II = II + 1
            End If
            If Nz.Nz(Row.Cells("RMReqSpecStd").Value) = "1" Or Nz.Nz(Row.Cells("RMReqSpecChe").Value) = "1" Or Nz.Nz(Row.Cells("RMReqSpecCap").Value) = "1" Then
                JJ = JJ + 1
            End If
        Next
        If II = 0 Then
            MsgBox("!!! ERROR !!! No Spec line selected.")
            SwVal = False
            Exit Sub
        End If

        If JJ = 0 Then
            MsgBox("!!! ERROR !!! At least one of Standard, Chemical and Capability check boxes should be selected.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub dgSpecs_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSpecs.DataError
        REM end
    End Sub

    Private Sub dgMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMPO.DataError
        REM end
    End Sub

    Private Sub CmbRMReq_DropDownClosed(sender As Object, e As EventArgs) Handles CmbRMReq.DropDownClosed

        If CmbRMReq.SelectedValue <= 0 Then
            Exit Sub
        End If

        dsMain.Tables("tblMatlReqSpecs").Clear()

        CallClass.PopulateDataAdapterAfterSearch("getMatlSpecForProposaByRMReqID", CmbRMReq.SelectedValue).Fill(dsMain, "tblMatlReqSpecs")

        dgSpecs.AutoGenerateColumns = False
        dgSpecs.DataSource = dsMain
        dgSpecs.DataMember = "tblMatlReqSpecs"

        ShowCtl()

        If CmbStatus.Text = "Approved" Or CmbStatus.Text = "Closed" Or CmbStatus.Text = "Cancelled" Then
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = False
            CmdSearch.Enabled = False
            CmdReset.Enabled = True
        Else
            CmdNew.Enabled = True
            CmdEdit.Enabled = True
            CmdSave.Enabled = True
            CmdSearch.Enabled = False
            CmdReset.Enabled = True
        End If

    End Sub

    Private Sub CmbRMReq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbRMReq.SelectedIndexChanged

        Me.BindingContext(dsMain, "tblMatlREQ").Position = CType(CmbRMReq.SelectedIndex, String)

        BindComponents()

        dsMain.Tables("tblSelect").Clear()
        txtMPOQty.Text = ""

        Try
            If SwFirstReset = False Then
                If Len(Trim(CmbDia.Text)) > 0 Then
                    CallClass.PopulateDataAdapterSearch2Param("getMatlSpecForProposalMPOs", CmbMatlType.SelectedValue, CmbDia.Text).Fill(dsMain, "tblSelect")
                    dgMPO.AutoGenerateColumns = False
                    dgMPO.DataSource = dsMain
                    dgMPO.DataMember = "tblSelect"

                    PutTotalMPOQty()

                Else
                    MsgBox("!!! ERROR !!! - Missing Dia.")
                End If
            End If


            If SwFirstReset = True Then
                CmdNew.Enabled = True
                CmdEdit.Enabled = True
                CmdSave.Enabled = True
                CmdReset.Enabled = True
                'CmbApprBy.Enabled = False
                If RoleRMREQAPPR(wkDeptCode) = True Then
                    CmbApprBy.Enabled = False       ' I assigned false as I used chAppr
                    ChAppr.Enabled = False   '  only on edit enable with cond
                Else
                    CmbApprBy.Enabled = False
                    ChAppr.Enabled = False
                End If
            End If
            If CmbStatus.Text = "Approved" Or CmbStatus.Text = "Closed" Or CmbStatus.Text = "Cancelled" Then
                CmdNew.Enabled = True
                CmdEdit.Enabled = False
                CmdSave.Enabled = False
                CmdReset.Enabled = True
                CmbApprBy.Enabled = False
                ChAppr.Enabled = False
            End If

            CmbRMReq.Enabled = False


            If SwFrom.Text = "POMAT" Then
                CmdNew.Enabled = False
                CmdEdit.Enabled = False
                CmdSave.Enabled = False
                CmdReset.Enabled = True
                CmbApprBy.Enabled = False
                ChAppr.Enabled = False

                CmdSend.Enabled = True
            End If

            If SwOper = "New" Then
                CmdNew.Enabled = False
                CmdEdit.Enabled = False
                CmdSave.Enabled = True
                CmdReset.Enabled = True
                CmbApprBy.Enabled = False
                ChAppr.Enabled = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Function RoleRMREQPO(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RMREQPO" Then
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

    Function RoleRMREQAPPR(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RMREQAPPR" Then
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


    Private Sub CmdEdit_Click(sender As Object, e As EventArgs) Handles CmdEdit.Click


        SwOper = "Edit"

        CmdSave.Enabled = True
        CmdEdit.Enabled = False
        CmdNew.Enabled = False
        CmdReset.Enabled = True

        CmdSearch.Enabled = True

        dsMain.RejectChanges()
        dgSpecs.Refresh()
        dgMPO.Refresh()

        SetReadOnlyFalse()


        For Each Row As DataGridViewRow In dgSpecs.Rows
            Row.Cells("SwSelectLine").Value = "1"
            Row.Cells("SwSelectLine").Value = True
        Next

        CmbRMReq.Enabled = False

        If CmbStatus.Text = "Approved" And SwFirstReset = False Then
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = False
            CmdReset.Enabled = True

            CmbApprBy.Enabled = False
            ChAppr.Enabled = False

        Else
            If RoleRMREQAPPR(wkDeptCode) = True Then
                CmbApprBy.Enabled = False           ' I used chAppr
                ChAppr.Enabled = True
            Else
                CmbApprBy.Enabled = False
                ChAppr.Enabled = False
            End If

        End If

        SwFirstReset = False

    End Sub

    Private Sub CmdSend_Click(sender As Object, e As EventArgs) Handles CmdSend.Click

        If CmbStatus.Text <> "Approved" Then
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = False
            CmdReset.Enabled = True
            CmbApprBy.Enabled = False
            ChAppr.Enabled = False

            MsgBox("!!! ERROR !!! - Material Request -- not approved.")

            CmdSend.Enabled = False
            Exit Sub
        End If

        Dim SwMatlForms As String = ""
        Dim SwStkOrd As String = ""


        If RdBars.Checked = True Then
            SwMatlForms = "BARS"
        Else
            If RdCoils.Checked = True Then
                SwMatlForms = "COILS"
            Else
                If RdHEX.Checked = True Then
                    SwMatlForms = "HEX"
                    If RdTube.Checked = True Then
                        SwMatlForms = "TUBE"
                    Else
                        SwMatlForms = "SHEETMETAL"
                    End If
                End If
            End If
        End If

        If RdStock.Checked = True Then
            SwStkOrd = "STK"
        Else
            SwStkOrd = "ORD"
        End If

        swNotes.Text = "PRODUCT DESCRIPTION:" + vbCrLf
        swNotes.Text = swNotes.Text + "======================" + vbCrLf
        swNotes.Text = swNotes.Text + CmbMatlType.Text + "           " + CmbKSI.Text + vbCrLf

        If RdTube.Checked = True And Len(Trim(txtInsideAW.Text)) <> 0 Then
            swNotes.Text = swNotes.Text + CmbDia.Text + Chr(34) + " OD  X   " + txtInsideAW.Text + Chr(34) + "AW" + "  X  20 Ft Long" + vbCrLf
            swNotes.Text = swNotes.Text + "OD Tol: +/-  .005   Wall:  +/- 10%" + vbCrLf
        Else
            swNotes.Text = swNotes.Text + "SIZE / DIA:  " + CmbDia.Text + Chr(34) + " dia.  Tol.:  +.0015" + Chr(34) + "/-.0015" + Chr(34) + vbCrLf
        End If

        swNotes.Text = swNotes.Text + "MATERIAL FORM:  " + SwMatlForms + vbCrLf

        swNotes.Text = swNotes.Text + "Domestic Mill Source Only (US)"

        If Chk_Coated_Cu.Checked = True Or _
                Chk_Coated_Phosphate.Checked = True Or _
                Len(Trim(txtCoatedOther.Text)) > 0 Or _
                Chk_Cond_ANN1.Checked = True Or _
                Chk_Cond_ANN2.Checked = True Or _
                Len(Trim(txtHT.Text)) > 0 Or _
                Len(Trim(txtUltraSonic.Text)) > 0 Or _
                Chk_Cond_VAR.Checked = True Or _
                Chk_Cond_VIM.Checked = True Or _
                Chk_Cond_ESR.Checked = True Or _
                Len(Trim(txtCondOthers.Text)) > 0 Then

            swNotes.Text = swNotes.Text + vbCrLf + vbCrLf
            swNotes.Text = swNotes.Text + "OTHER REQUIREMENTS:" + vbCrLf
            swNotes.Text = swNotes.Text + "=======================" + vbCrLf
            If Chk_Coated_Cu.Checked = True Then
                swNotes.Text = swNotes.Text + "Heavy Copper  (.002 IN  -  .005 IN Thick ) and Moly Soap coating" + vbCrLf
            End If
            If Chk_Coated_Phosphate.Checked = True Then
                swNotes.Text = swNotes.Text + "Phosphate" + vbCrLf
            End If
            If Len(Trim(txtCoatedOther.Text)) > 0 Then
                swNotes.Text = swNotes.Text + Trim(txtCoatedOther.Text) + vbCrLf
            End If

            If Chk_Cond_ANN1.Checked = True Then
                swNotes.Text = swNotes.Text + "ANNEALED" + vbCrLf
            End If
            If Chk_Cond_ANN2.Checked = True Then
                swNotes.Text = swNotes.Text + "ANNEALED AND COLD DRAWN" + vbCrLf
            End If
            If Len(Trim(txtHT.Text)) > 0 Then
                swNotes.Text = swNotes.Text + Trim(txtHT.Text) + vbCrLf
            End If
            If Len(Trim(txtUltraSonic.Text)) > 0 Then
                swNotes.Text = swNotes.Text + Trim(txtUltraSonic.Text) + vbCrLf
            End If

            If Chk_Cond_VAR.Checked = True Then
                swNotes.Text = swNotes.Text + "VAR" + vbCrLf
            End If
            If Chk_Cond_VIM.Checked = True Then
                swNotes.Text = swNotes.Text + "VIM" + vbCrLf
            End If
            If Chk_Cond_ESR.Checked = True Then
                swNotes.Text = swNotes.Text + "E.S.R." + vbCrLf
            End If
            If Len(Trim(txtCondOthers.Text)) > 0 Then
                swNotes.Text = swNotes.Text + Trim(txtCondOthers.Text)
            End If
        End If

        swNotes.Text = swNotes.Text + vbCrLf + vbCrLf
        swNotes.Text = swNotes.Text + "SPECIFICATION(s):" + vbCrLf
        swNotes.Text = swNotes.Text + "================"

        Dim II As Integer
        For II = 1 To dgSpecs.Rows.Count

            Dim SwChem As String = ""
            Try
                If Len(Trim(dgSpecs.Item("RMReqSpecNo", II - 1).Value)) > 0 Then

                    swNotes.Text = swNotes.Text + vbCrLf

                    If dgSpecs.Item("RMReqSpecStd", II - 1).Value = "1" Then
                        swNotes.Text = swNotes.Text + dgSpecs.Item("RMReqSpecNo", II - 1).Value + "  REV " + dgSpecs.Item("RMReqSpecRev", II - 1).Value + "  (" + dgSpecs.Item("RMReqSpecDate", II - 1).Value + ")" + "   STANDARD"
                        GoTo NEXTROW
                    End If

                    If dgSpecs.Item("RMReqSpecCap", II - 1).Value = "1" Then
                        SwChem = "CAPABLE ONLY"
                        If dgSpecs.Item("RMReqSpecChe", II - 1).Value = "1" Then
                            If Len(Trim(SwChem)) = 0 Then
                                SwChem = "CHEMISTRY ONLY"
                            Else
                                SwChem = SwChem + "   " + "CHEMISTRY ONLY"
                            End If
                        End If
                    Else
                        If dgSpecs.Item("RMReqSpecChe", II - 1).Value = "1" Then
                            SwChem = "CHEMISTRY ONLY"
                        End If
                    End If
                    swNotes.Text = swNotes.Text + dgSpecs.Item("RMReqSpecNo", II - 1).Value + "  REV " + dgSpecs.Item("RMReqSpecRev", II - 1).Value + "  (" + dgSpecs.Item("RMReqSpecDate", II - 1).Value + ")" + "    " + SwChem
                End If

            Catch ex As Exception
            End Try

NEXTROW:

        Next

        If Len(Trim(txtGenNotes.Text)) > 0 Then
            swNotes.Text = swNotes.Text + vbCrLf + vbCrLf
            swNotes.Text = swNotes.Text + "GENERAL NOTES AS APPLICABALE:" + vbCrLf
            swNotes.Text = swNotes.Text + "===============================" + vbCrLf
            swNotes.Text = swNotes.Text + Trim(txtGenNotes.Text)
        End If

        Dim I As Integer
        I = CInt(txtRow.Text)

        Try
            frmPOMaster.dgDetail("PoMatlID", I).Value = CmbMatlType.SelectedValue

            If Len(Trim(KsiID.Text)) > 0 Then
                frmPOMaster.dgDetail.Rows(I).Cells("POMatlDetID").Value = KsiID.Text
            Else
                frmPOMaster.dgDetail.Rows(I).Cells("POMatlDetID").Value = DBNull.Value
            End If

            frmPOMaster.dgDetail("POMatlDia", I).Value = CmbDia.Text.ToString
            frmPOMaster.dgDetail("POMatlForm", I).Value = SwMatlForms.ToString


            '''''''''''''''''''''''''''''frmPOMaster.dgDetail("POMatlInsideDia", I).Value = txtInsideAW.Text.ToString


            If SwStkOrd = "STK" Then
                frmPOMaster.dgDetail("POForStock", I).Value = True
                frmPOMaster.dgDetail("POForOrders", I).Value = False
            Else
                frmPOMaster.dgDetail("POForStock", I).Value = False
                frmPOMaster.dgDetail("POForOrders", I).Value = True
            End If

            frmPOMaster.dgDetail("PONotesItem", I).Value = swNotes.Text.ToString()

            frmPOMaster.dgDetail("POMatlNotes", I).Value = txtNotes.Text.ToString()

            frmPOMaster.dgDetail("POProdID", I).Value = 9351

            If SwOperRM.Text = "New" Then
                frmPOMaster.dgDetail("POQty", I).Value = txtQty.Text
            End If

            frmPOMaster.CmbPOSupp.SelectedValue = CmbSource.SelectedValue

            frmPOMaster.txtReqNo.Text = CmbRMReq.Text

        Catch ex As Exception

        End Try

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub CmbKSI_DropDownClosed(sender As Object, e As EventArgs) Handles CmbKSI.DropDownClosed

        KsiID.Text = CmbKSI.SelectedValue

    End Sub

    Private Sub ChAppr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChAppr.Click

        If ChAppr.Checked = True Then
            Dim reply As DialogResult

            reply = MsgBox("Do you want approve this RM request - Continue (Yes/No)?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                CmbApprBy.SelectedIndex = -1
                ChAppr.Checked = False
                txtRMApprDate.Text = ""
            Else
                CmbApprBy.SelectedValue = wkEmpId
                txtRMApprDate.Text = Now.ToShortDateString
                txtRMApprDate.Refresh()
                ChAppr.Checked = True
                CmbStatus.Text = "Approved"
            End If
        Else
            CmbApprBy.SelectedIndex = -1
            ChAppr.Checked = False
            txtRMApprDate.Text = ""
        End If

    End Sub

    Private Sub RdTube_Click(sender As Object, e As EventArgs) Handles RdTube.Click

        LbInside.Visible = True
        txtInsideAW.Visible = True

    End Sub

End Class