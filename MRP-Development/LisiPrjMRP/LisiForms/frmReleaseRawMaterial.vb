Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmReleaseRawMaterial

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowMatl As Integer = 0
    Dim RowStRes As Integer = 0
    Dim RoWMpo As Integer = 0
    Dim SwVal As Boolean
    Dim OldDept As Integer

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 
    Dim swFirst As Integer = 0 'first time = 0

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmReleaseRawMaterial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmReleaseRawMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1850 And Height > 905 Then
            Me.Width = 1850
            Me.Height = 905
        Else
            If Width < 1850 And Height < 905 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()

        If RoleReserveMatl(wkDeptCode) = True Then
            cmdSave.Enabled = True
        Else
            cmdSave.Enabled = False
        End If

    End Sub

    Sub SetupForm()

        txtMPOMatl.ReadOnly = True
        txtMPOMatl.Text = ""

        txtSpec.Text = ""

        InitialComponents()

        SetCtlForm()

        BindData()

        dgMatl.AutoGenerateColumns = False
        dgMatl.DataSource = dsMain
        dgMatl.DataMember = "tblStockRawMatl"

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblStockRawMatl.LotMpo"

        dgStockRes.AutoGenerateColumns = False
        dgStockRes.DataSource = dsMain
        dgStockRes.DataMember = "tblStockRawMatl.LotRes"

        dgInsp.AutoGenerateColumns = False
        dgInsp.DataSource = dsMain
        dgInsp.DataMember = "tblStockRawMatl.LotInsp"

        PutMatlType()
        dgMatl.Focus()

        PutMatlFamily()

        If swFirst = 0 Then
            swFirst = 9
        Else
            CalculTotMpoMatl()
            PutValueStRes()
        End If

        RdPlus.Checked = True

    End Sub

    Sub InitialComponents()


        '         dbo.tblPoReceivingDOC.RecvMatlInsideDIA,   dbo.tblPoReceivingDOC.RecvMatlTube, dbo.tblPoReceivingDOC.RecvMatlSheetMetal,


        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getMPOWithReserved").FillSchema(dsMain, SchemaType.Source, "tblStockRawMatlReservation")

        CallClass.PopulateDataAdapter("getStFinalTblStockRawMatl").Fill(dsMain, "tblStockRawMatl")
        CallClass.PopulateDataAdapter("getMPOWithMatlReleased").Fill(dsMain, "tblMpoMaster")
        CallClass.PopulateDataAdapter("getRequirmentWithLot").Fill(dsMain, "tblRequirementsList")
        CallClass.PopulateDataAdapter("getNotesInsp").Fill(dsMain, "tblPoReceivingDOC")

        CallClass.PopulateDataAdapter("getMPOWithReserved").Fill(dsMain, "tblStockRawMatlReservation")
        Dim ResId As DataColumn = dsMain.Tables("tblStockRawMatlReservation").Columns("ResMatID")
        ResId.AutoIncrement = True
        ResId.AutoIncrementStep = -1
        ResId.AutoIncrementSeed = -1
        ResId.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("LotMpo", _
              .Tables("tblStockRawMatl").Columns("StLotNo"), _
                .Tables("tblMpoMaster").Columns("MpoLotNo"), True)
        End With

        With dsMain
            .Relations.Add("LotRes", _
              .Tables("tblStockRawMatl").Columns("StLotNo"), _
                .Tables("tblStockRawMatlReservation").Columns("StLotNo"), True)
        End With

        With dsMain
            .Relations.Add("LotInsp", _
              .Tables("tblStockRawMatl").Columns("StLotNo"), _
                .Tables("tblRequirementsList").Columns("DocRecvNo"), True)
        End With

        With dsMain
            .Relations.Add("LotNotes", _
              .Tables("tblStockRawMatl").Columns("StLotNo"), _
                .Tables("tblPoReceivingDOC").Columns("DocRecvNo"), True)
        End With

    End Sub

    Sub BindData()

        txtPO.DataBindings.Clear()
        txtQA.DataBindings.Clear()

        txtPO.DataBindings.Add("Text", dsMain, "tblStockRawMatl.LotNotes.RecvPoItemsNotes")
        txtQA.DataBindings.Add("Text", dsMain, "tblStockRawMatl.LotNotes.RecvQANotes")

    End Sub

    Sub SetCtlForm()


        With Me.CmbSupp
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierMill").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
        End With


        'dgMatl
        With Me.StRawMatlID
            .DataPropertyName = "StRawMatlID"
            .Name = "StRawMatlID"
            .Visible = False
        End With

        With Me.RecvMatlBars
            .DataPropertyName = "RecvMatlBars"
            .Name = "RecvMatlBars"
            .Visible = False
        End With

        With Me.RecvMatlCoils
            .DataPropertyName = "RecvMatlCoils"
            .Name = "RecvMatlCoils"
            .Visible = False
        End With

        With Me.RecvMatlHex
            .DataPropertyName = "RecvMatlHex"
            .Name = "RecvMatlHex"
            .Visible = False
        End With

        With Me.RecvMatlTube
            .DataPropertyName = "RecvMatlTube"
            .Name = "RecvMatlTube"
            .Visible = False
        End With

        With Me.RecvMatlSheetMetal
            .DataPropertyName = "RecvMatlSheetMetal"
            .Name = "RecvMatlSheetMetal"
            .Visible = False
        End With


        With Me.LotSort
            .DataPropertyName = "LotSort"
            .Name = "LotSort"
        End With

        With Me.StLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.StLock
            .DataPropertyName = "StLock"
            .Name = "StLock"
        End With

        With Me.StMatlIni
            .DataPropertyName = "StMatlIni"
            .Name = "StMatlIni"
        End With

        With Me.StDateIni
            .DataPropertyName = "StDateIni"
            .Name = "StDateIni"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.Balance
            .DataPropertyName = "Balance"
            .Name = "Balance"
        End With

        With Me.StUM
            .DataPropertyName = "StUM"
            .Name = "StUM"
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
            .SortMode = DataGridViewColumnSortMode.Automatic
        End With

        With Me.FullKSIDescr
            .DataPropertyName = "FullKSIDescr"
            .Name = "FullKSIDescr"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlInsideDIA
            .DataPropertyName = "RecvMatlInsideDIA"
            .Name = "RecvMatlInsideDIA"
        End With

        With Me.MatlFamily
            .DataPropertyName = "MatlFamily"
            .Name = "MatlFamily"
            .SortMode = DataGridViewColumnSortMode.Automatic
        End With

        With Me.RecvMatlHeat
            .DataPropertyName = "RecvMatlHeat"
            .Name = "RecvMatlHeat"
        End With

        With Me.RecvMatlCond
            .DataPropertyName = "RecvMatlCond"
            .Name = "RecvMatlCond"
        End With

        With Me.StComments
            .DataPropertyName = "StComments"
            .Name = "StComments"
        End With

        With Me.RecvHoldMatl
            .DataPropertyName = "RecvHoldMatl"
            .Name = "RecvHoldMatl"
        End With

        With Me.RecvRejectMatl
            .DataPropertyName = "RecvRejectMatl"
            .Name = "RecvRejectMatl"
        End With

        With Me.RecvMillID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierMill").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvMillID"
            .Name = "RecvMillID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvRedrawID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierRedraw").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvRedrawID"
            .Name = "RecvRedrawID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.RecvDistrID
            .DataSource = CallClass.PopulateComboBox("tblSupplier", "cmbGetSupplierDistr").Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
            .DataPropertyName = "RecvDistrID"
            .Name = "RecvDistrID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With


        'dgMPO

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.MpoMatlWeight
            .DataPropertyName = "MpoMatlWeight"
            .Name = "MpoMatlWeight"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.DeptID
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
            .DropDownWidth = 300
            .MaxDropDownItems = 40
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
        End With

        With Me.SwPartNumber
            .DataPropertyName = "SwPartNumber"
            .Name = "SwPartNumber"
        End With

        'dgStockRes

        With Me.ResMatID
            .DataPropertyName = "ResMatID"
            .Name = "ResMatID"
            .Visible = False
        End With

        With Me.StLotNoStRes
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
            .ReadOnly = True
        End With

        PutMpoID()

        With Me.ResWeight
            .DataPropertyName = "ResWeight"
            .Name = "ResWeight"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.DeptIDRes
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
        End With

        With Me.PartNo
            .DataPropertyName = "PartNo"
            .Name = "PartNo"
        End With

        With Me.ResNotes
            .DataPropertyName = "ResNotes"
            .Name = "ResNotes"
        End With

        With Me.ProcessID
            .DataPropertyName = "ProcessID"
            .Name = "ProcessID"
            .Visible = False
        End With

        'dgInsp

        With Me.DocRecvNo
            .DataPropertyName = "DocRecvNo"
            .Name = "DocRecvNo"
        End With

        With Me.ReqName
            .DataPropertyName = "ReqName"
            .Name = "ReqName"
        End With

        With Me.ResSuppCert
            .DataPropertyName = "ResSuppCert"
            .Name = "ResSuppCert"
        End With

        With Me.ResLisiResult
            .DataPropertyName = "ResLisiResult"
            .Name = "ResLisiResult"
        End With

    End Sub

    Sub PutMpoID()

        With Me.MpoIDRes
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterNull").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MpoID"
            .DataPropertyName = "MPOID"
            .Name = "MPOID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

    End Sub

    Sub PutMatlFamily()

        For I As Integer = 0 To (dgMatl.Rows.Count - 1)
            If Nz.Nz(dgMatl("RecvMatlBars", I).Value) = True Then
                dgMatl("MatlFamily", I).Value = "Bars"
            Else
                If Nz.Nz(dgMatl("RecvMatlCoils", I).Value) = True Then
                    dgMatl("MatlFamily", I).Value = "Coils"
                Else
                    If Nz.Nz(dgMatl("RecvMatlHex", I).Value) = True Then
                        dgMatl("MatlFamily", I).Value = "Hex"
                    Else
                        If Nz.Nz(dgMatl("RecvMatlTube", I).Value) = True Then
                            dgMatl("MatlFamily", I).Value = "Tube"
                        Else
                            If Nz.Nz(dgMatl("RecvMatlSheetMetal", I).Value) = True Then
                                dgMatl("MatlFamily", I).Value = "SheetMetal"
                            Else
                                dgMatl("MatlFamily", I).Value = "????"
                            End If
                        End If
                    End If
                End If
            End If

        Next I

    End Sub

    Sub PutHoldColor()
        For I As Integer = 0 To (dgMatl.Rows.Count - 1)
            If Nz.Nz(dgMatl("RecvHoldMatl", I).Value) = True Then
                dgMatl.Rows(I).DefaultCellStyle.BackColor = Color.Red
            Else
                dgMatl.Rows(I).DefaultCellStyle.BackColor = Color.Empty
            End If

        Next I
        Exit Sub

        For I As Integer = 0 To (dgMatl.Rows.Count - 1)
            If Nz.Nz(dgMatl("RecvRejectMatl", I).Value) = True Then
                dgMatl.Rows(I).DefaultCellStyle.BackColor = Color.Purple
            Else
                dgMatl.Rows(I).DefaultCellStyle.BackColor = Color.Empty
            End If
        Next I
        Exit Sub

    End Sub

    Sub CalculTotMpoMatl()
        If RowMatl < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("MpoMatlWeight").Value)
        Next
        txtMPOMatl.Text = qty.ToString("N2")

        qty = txtMPOMatl.Text + dgMatl("StFinal", RowMatl).Value
        txtTotMat.Text = qty.ToString("N2")

    End Sub

    Private Sub dgMatl_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMatl.CellClick

        GC.Collect()

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMatl = e.RowIndex

        PutMatlFamily()

        CalculTotMpoMatl()

        PutValueStRes()

        BindData()

        PutErrorStQty()

        Select Case e.ColumnIndex
            Case 16     'print matl tranz
                Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim rptPO As New rptRawMatlSeeTranz
                Dim txtPrint As String
                txtPrint = Nz.Nz(dgMatl("StLotNo", RowMatl).Value)

                rptPO.Load("..\rptRawMatlSeeTranz.rpt")
                pdvCustomerName.Value = txtPrint
                pvCollection.Add(pdvCustomerName)
                rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
                frmPOMasterPrint.ShowDialog()

            Case 27
                frmReleaseRMLabels.txtMatlLot.Text = dgMatl("StLotNo", RowMatl).Value
                frmReleaseRMLabels.txtMaterial.Text = dgMatl("MatlType", RowMatl).Value
                frmReleaseRMLabels.txtDIA.Text = dgMatl("RecvMatlSize", RowMatl).Value

                'frmReleaseRMLabels.txtDIA.Text = dgMatl("RecvMatlInsideDIA", RowMatl).Value

                frmReleaseRMLabels.txtMatlHeat.Text = dgMatl("RecvMatlHeat", RowMatl).Value
                frmReleaseRMLabels.txtMatlCond.Text = dgMatl("RecvMatlCond", RowMatl).Value
                frmReleaseRMLabels.txtKSI.Text = dgMatl("FullKSIDescr", RowMatl).Value

                If IsDBNull(dgMatl("RecvHoldMatl", RowMatl).Value) = True Then
                    frmReleaseRMLabels.ChkHold.Checked = False
                Else
                    frmReleaseRMLabels.ChkHold.Checked = dgMatl("RecvHoldMatl", RowMatl).Value
                End If

                If IsDBNull(dgMatl("RecvRejectMatl", RowMatl).Value) = True Then
                    frmReleaseRMLabels.ChkRejected.Checked = False
                Else
                    frmReleaseRMLabels.ChkRejected.Checked = dgMatl("RecvRejectMatl", RowMatl).Value
                End If


                If IsDBNull(dgMatl("RecvHoldMatl", RowMatl).Value) = True And IsDBNull(dgMatl("RecvRejectMatl", RowMatl).Value) = True Or _
                            IsNothing(dgMatl("RecvHoldMatl", RowMatl).Value) = True And IsNothing(dgMatl("RecvRejectMatl", RowMatl).Value) = True Or _
                                    Nz.Nz(dgMatl("RecvHoldMatl", RowMatl).Value) = 0 And Nz.Nz(dgMatl("RecvRejectMatl", RowMatl).Value) = 0 Then
                    frmReleaseRMLabels.txtRMStatus.Text = "INSPECTED  -  Status ACCEPTED"
                Else
                    If IsDBNull(dgMatl("RecvHoldMatl", RowMatl).Value) = False Or _
                                IsNothing(dgMatl("RecvHoldMatl", RowMatl).Value) = False Or _
                                    Nz.Nz(dgMatl("RecvHoldMatl", RowMatl).Value) = 1 Then
                        frmReleaseRMLabels.txtRMStatus.Text = "NOT INSPECTED  -  Status HOLD"
                    Else
                        If IsDBNull(dgMatl("RecvRejectMatl", RowMatl).Value) = False Or _
                                IsNothing(dgMatl("RecvRejectMatl", RowMatl).Value) = False Or _
                                    IsNothing(dgMatl("RecvRejectMatl", RowMatl).Value) = 1 Then
                            frmReleaseRMLabels.txtRMStatus.Text = "INSPECTED  -  Status REJECTED"
                        End If
                    End If
                End If

                CmbSupp.SelectedValue = dgMatl("RecvMillID", RowMatl).Value
                frmReleaseRMLabels.txtMill.Text = CmbSupp.Text

                frmReleaseRMLabels.ShowDialog()

        End Select

    End Sub

    Private Sub dgMatl_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMatl.CellEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMatl = e.RowIndex

        CalculTotMpoMatl()

        PutValueStRes()

        PutHoldColor()

        Dim qRes As Double
        Dim qFinal As Double
        Dim qdif As Double

        qRes = txtWeightRes.Text
        qFinal = Nz.Nz(dgMatl("StFinal", e.RowIndex).Value)
        qdif = qFinal - qRes

        dgMatl("Balance", e.RowIndex).Value = qdif

        BindData()

    End Sub

    Sub PutErrorStQty()

        If Nz.Nz(dgMatl("StMatlIni", RowMatl).Value) <> Nz.Nz(dgMatl("StFinal", RowMatl).Value) + _
                                                                        Nz.Nz(txtMPOMatl.Text) Then
            dgMatl("LotSort", RowMatl).Style.BackColor = Color.DarkRed
        Else
            dgMatl("LotSort", RowMatl).Style.BackColor = Color.White
        End If

    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RoWMpo = e.RowIndex

        If RoleReleaseMatl(wkDeptCode) = True Then  'inspection to return to inventory
            Select Case e.ColumnIndex
                Case 7

                    If dgMpo("MpoStatus", e.RowIndex).Value <> "Active" Then
                        MsgBox("Action Denied. MPO No. is not Active.")
                        Exit Sub
                    End If

                    If IsDBNull(dgMpo("DeptID", e.RowIndex).Value) = True Then
                        MsgBox("Action Denied. Department code is Null")
                        Exit Sub
                    End If

                    Dim SwDept As Integer = 0
                    Dim SwProd As String = ""

                    SwDept = dgMpo("DeptID", e.RowIndex).Value
                    SwProd = CallClass.ReturnStrWithParInt("cspReturnParamStr", SwDept)

                    If Val(Trim(SwProd)) = 0 Then
                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to Return to Raw Material Inventory ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If

                        ReturnRawMatl()

                        UpdateReturnMpoMasterWeight()
                        ''''''''''''''''''''''''''''''''''''''''''''''''

                        ' why SAVE stoc_res as he has no access to change in reservation

                        If (dsMain.HasChanges) Then
                            Try
                                UpdateStockRes(dsMain.GetChanges)
                                dsMain.AcceptChanges()
                            Catch ex As Exception
                                MsgBox("Update failed: " & ex.Message)
                                dsMain.RejectChanges()
                            End Try
                        End If

                        MsgBox("Update successfully.")

                        '''''''''''''''''''''''''''''''''''''''''''''''''
                        InitialComponents()

                        SetCtlForm()
                    Else
                        MsgBox("Action Denied. Can not Release the MPO# from production.")
                    End If

            End Select
        Else
            dgMpo.ReadOnly = True
        End If

    End Sub

    Private Sub dgStockRes_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgStockRes.CellBeginEdit

        If RoleReleaseMatl(wkDeptCode) = True Then   'release matl  --  Inspection
            Select Case e.ColumnIndex  'enable 1
                Case 0
                    e.Cancel = True
                Case 1
                    If IsDBNull(dgMatl("RecvHoldMatl", e.RowIndex).Value) = False Then
                        If dgMatl("RecvHoldMatl", e.RowIndex).Value = True Then
                            MsgBox("Material Lot Status = HOLD. !!! Action Denied. !!! ")
                            e.Cancel = True
                        End If
                    End If

                    If IsDBNull(dgMatl("RecvRejectMatl", e.RowIndex).Value) = False Then
                        If dgMatl("RecvRejectMatl", e.RowIndex).Value = True Then
                            MsgBox("Material Lot Status = Rejected. !!! Action Denied. !!! ")
                            e.Cancel = True
                        End If
                    End If

                Case 2 To 14
                    e.Cancel = True
            End Select

            Exit Sub
        Else
            If RoleReserveMatl(wkDeptCode) = True Then 'reserve  --  'engeneering and planning
                Select Case e.ColumnIndex  'disable 1
                    Case 0, 1, 2
                        e.Cancel = True
                    Case 6, 8, 9, 10, 11, 14
                        e.Cancel = True

                    Case 3      'MPO
                        If IsDBNull(dgMatl("RecvHoldMatl", RowMatl).Value) = False Then
                            If dgMatl("RecvHoldMatl", RowMatl).Value = True Then
                                MsgBox("Material Lot Status = HOLD. !!! Action Denied. !!! ")
                                e.Cancel = True
                            End If
                        End If

                        If IsDBNull(dgMatl("RecvRejectMatl", RowMatl).Value) = False Then
                            If dgMatl("RecvRejectMatl", RowMatl).Value = True Then
                                MsgBox("Material Lot Status = Rejected. !!! Action Denied. !!! ")
                                e.Cancel = True
                            End If
                        End If

                    Case 7
                        If RoleReserveMatl(wkDeptCode) = True Then
                            If IsDBNull(dgStockRes("MpoID", e.RowIndex).Value) = True Then
                                MsgBox("Please choose the MPO# before change the department.")
                                e.Cancel = True
                            End If
                        End If
                    Case 13
                        If RoleReserveMatl(wkDeptCode) = True Then
                            If IsDBNull(dgStockRes("MpoID", e.RowIndex).Value) = True Then
                                MsgBox("Please choose the MPO# before.")
                                e.Cancel = True
                            End If
                        End If
                End Select

                Exit Sub
            Else
                e.Cancel = True
                Exit Sub
            End If
        End If

    End Sub

    Private Sub dgStockRes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockRes.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowStRes = e.RowIndex

        OldDept = Nz.Nz(dgStockRes("DeptID", e.RowIndex).Value)

        'If RoleEng(wkDeptCode) = True Then

        Select Case e.ColumnIndex
            Case 1

                If IsDBNull(dgMatl("RecvHoldMatl", RowMatl).Value) = False Then
                    If dgMatl("RecvHoldMatl", RowMatl).Value = True Then
                        MsgBox("Material Lot Status = HOLD. !!! Action Denied. !!! ")
                        Exit Sub
                    End If
                End If

                If IsDBNull(dgMatl("RecvRejectMatl", RowMatl).Value) = False Then
                    If dgMatl("RecvRejectMatl", RowMatl).Value = True Then
                        MsgBox("Material Lot Status = Rejected. !!! Action Denied. !!! ")
                        Exit Sub
                    End If
                End If

                If RoleReleaseMatl(wkDeptCode) = True Then
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Release to Production ?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                    Call ValPo()
                    If SwVal = True Then

                        If Len(Trim(Convert.ToString(dgStockRes.Item("ProcessID", RowStRes).Value))) = 0 Then
                            MsgBox("!!! ERROR !!! Missing Production Method.")
                            Exit Sub
                        End If

                        'prepare the first RM routing operation
                        frmReleaseRMFirstOper.SwMPOId.Text = Nz.Nz(dgStockRes.Rows(RowStRes).Cells("MpoID").Value)
                        frmReleaseRMFirstOper.SwEmpID.Text = wkEmpId
                        frmReleaseRMFirstOper.txtUser.Text = wkName
                        frmReleaseRMFirstOper.txtMatl.Text = Nz.Nz(dgMatl.Rows(RowMatl).Cells("MatlFamily").Value)
                        frmReleaseRMFirstOper.ShowDialog()

                        ReleaseRawMatl()
                        UpdateMpoMasterWeight()

                        Try
                            ' add RM Cost in MPOMaster
                            Dim txtRMCost As String = ""
                            txtRMCost = CallClass.ReturnStrWith2ParStr("cspCalculMPORawMaterialCost", dgStockRes("MpoID", RowStRes).Value, dgStockRes("QtyEngReleased", RowStRes).Value)
                        Catch ex As Exception
                            MsgBox("Update failed: RM Cost into tblMPOMaster " & ex.Message)
                        End Try

                        'delete record from stock reservation
                        dgStockRes.Rows.RemoveAt(RowStRes)
                        dgStockRes.Refresh()

                        If (dsMain.HasChanges) Then
                            Try
                                UpdateStockRes(dsMain.GetChanges)
                                MsgBox("Update successfully.")
                                dsMain.AcceptChanges()
                            Catch ex As Exception
                                MsgBox("Update failed: " & ex.Message)
                                dsMain.RejectChanges()
                            End Try
                        End If

                        InitialComponents()

                        SetCtlForm()
                    End If
                Else
                    MsgBox("Access Denied.")
                End If
            Case 13
                If RoleReserveMatl(wkDeptCode) = True Then
                    If IsDBNull(dgStockRes("MpoID", e.RowIndex).Value) = True Then
                        MsgBox("Please choose the MPO# before.")
                        Exit Sub
                    End If

                    Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
                    Dim pvEmpCollection As New CrystalDecisions.Shared.ParameterValues()
                    Dim pvLotCollection As New CrystalDecisions.Shared.ParameterValues()

                    Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim pdvEmp As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim pdvLot As New CrystalDecisions.Shared.ParameterDiscreteValue()

                    Dim rptPO As New rptRawMatlReleaseControl
                    rptPO.Load("..\rptRawMatlReleaseControl.rpt")

                    pdvMpoID.Value = Convert.ToInt32(dgStockRes.Rows(RowStRes).Cells("MPOID").Value)
                    pdvEmp.Value = wkName
                    pdvLot.Value = dgStockRes.Rows(RowStRes).Cells("StLotNo").Value

                    pvMPOIDCollection.Add(pdvMpoID)
                    pvEmpCollection.Add(pdvEmp)
                    pvLotCollection.Add(pdvLot)

                    rptPO.DataDefinition.ParameterFields("@SwMpoID").ApplyCurrentValues(pvMPOIDCollection)
                    rptPO.DataDefinition.ParameterFields("@SwEmpName").ApplyCurrentValues(pvEmpCollection)
                    rptPO.DataDefinition.ParameterFields("@SwMatlLot").ApplyCurrentValues(pvLotCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
                    frmPOMasterPrint.ShowDialog()

                End If
        End Select
        'Else
        'dgStockRes.ReadOnly = True
        'End If

    End Sub

    Private Sub dgStockRes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockRes.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If RoleReserveMatl(wkDeptCode) = True Then
            Select Case e.ColumnIndex

                Case 3      'mpo no
                    Dim StrSearch As Integer = 0
                    Dim getMpoRes As String = ""
                    StrSearch = Nz.Nz(dgStockRes("MpoID", RowStRes).Value)
                    getMpoRes = CallClass.ReturnStrWithParInt("cspReturnMpoMatlStockRes", StrSearch)
                    If Trim(getMpoRes) <> "False" Then
                        MsgBox("!! ERROR MPO# !!! - Action denied. The RM was Reserved before.")
                        dgStockRes("Mpoid", e.RowIndex).Value = DBNull.Value
                        Exit Sub
                    End If

                    Dim OldMpo As Integer
                    OldMpo = Nz.Nz(dgStockRes("MpoID", e.RowIndex).Value)
                    Dim II As Integer = 0

                    For Each Row As DataGridViewRow In dgStockRes.Rows
                        If Nz.Nz(Row.Cells("MpoID").Value) = OldMpo Then
                            If II >= 1 Then
                                Row.Cells("MpoID").Value = DBNull.Value
                                MsgBox("!!! ERROR MPO# !!! - Action denied.")
                                Exit For
                            End If
                            II = II + 1
                        End If
                    Next

                Case 4      'weight
                    dgMatl("Balance", RowMatl).Selected = True
                    If Nz.Nz(dgStockRes("ResWeight", e.RowIndex).Value) > Nz.Nz(dgMatl("Balance", RowMatl).Value) Then
                        MsgBox("!!! ERROR !!! - Quantity Reserved is Greater than Quantity in Stock")
                        dgStockRes("ResWeight", e.RowIndex).Value = 0
                    End If

                    If Nz.Nz(dgMatl("Balance", RowMatl).Value) < 0 Then
                        MsgBox("!!! ERROR !!! - The Quantity available in Stock is negative.")
                        dgStockRes("ResWeight", e.RowIndex).Value = 0
                    End If

                    'PutValueStRes()

                Case 5      'qty eng
                    UpdateQtyReleased()
                Case 7      'dept
                    Dim SwDept As Integer = 0
                    Dim SwProd As String = ""

                    SwDept = Nz.Nz(dgStockRes("DeptID", e.RowIndex).Value)
                    SwProd = CallClass.ReturnStrWithParInt("cspReturnRoleEng", SwDept)
                    If SwProd <> "1" Then
                        MsgBox("Access denied.")
                        dgStockRes("DeptID", RowStRes).Value = OldDept
                        Exit Sub
                    End If

                    UpdateMpoDept()
            End Select
        Else
            dgStockRes.ReadOnly = True
        End If

    End Sub

    Sub UpdateQtyReleased()

        If IsDBNull(dgStockRes("QtyEngReleased", RowStRes).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleased", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgStockRes("MpoID", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgStockRes("QtyEngReleased", RowStRes).Value
            mySqlComm.Parameters.Add(paraQty)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Mpo Qty Released: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo Qty Released: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoDept()

        If IsDBNull(dgStockRes("DeptID", RowStRes).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgStockRes("MpoID", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = dgStockRes("DeptID", RowStRes).Value
            mySqlComm.Parameters.Add(paraDept)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Mpo Dept.: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo Dept.: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub PutValueStRes()

        If RowMatl < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgStockRes.Rows
            qty = qty + Nz.Nz(Row.Cells("ResWeight").Value)
        Next
        txtWeightRes.Text = qty.ToString("N2")

    End Sub

    Sub ReturnRawMatl()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
            paraFind.Value = dgMpo("MpoLotNo", RoWMpo).Value
            mySqlComm.Parameters.Add(paraFind)

            Dim paraData As SqlParameter = New SqlParameter("@MatlDateTranz", SqlDbType.SmallDateTime, 4)
            paraData.Value = Now.ToShortDateString
            mySqlComm.Parameters.Add(paraData)

            Dim paraTranz As SqlParameter = New SqlParameter("@MatlTranz", SqlDbType.NVarChar, 1)
            paraTranz.Value = 3
            mySqlComm.Parameters.Add(paraTranz)

            Dim paraStatus As SqlParameter = New SqlParameter("@MatlStatus", SqlDbType.NVarChar, 1)
            paraStatus.Value = "O"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraLoc As SqlParameter = New SqlParameter("@MatlLoc", SqlDbType.NVarChar, 10)
            paraLoc.Value = ""
            mySqlComm.Parameters.Add(paraLoc)

            Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
            paraQty.Value = dgMpo("MpoMatlWeight", RoWMpo).Value
            mySqlComm.Parameters.Add(paraQty)

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgMpo("MpoID", RoWMpo).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
            paraPer.Value = DBNull.Value
            mySqlComm.Parameters.Add(paraPer)

            Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
            paraNotes.Value = Nz.Nz(dgStockRes("ResNotes", RowStRes).Value)
            mySqlComm.Parameters.Add(paraNotes)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Add Release: " & ex.Message)
            End Try
        Catch ex As Exception
        End Try

        CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

    End Sub

    Sub UpdateReturnMpoMasterWeight()

        ' return to eng dept = 15 code
        'wfm = 1

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOMasterWeightReturn", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpoPar As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
            paraMpoPar.Value = dgMpo("MpoID", RoWMpo).Value
            mySqlComm.Parameters.Add(paraMpoPar)

            Dim paraMpoQtyActual As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
            paraMpoQtyActual.Value = 0
            mySqlComm.Parameters.Add(paraMpoQtyActual)

            Dim paraMpoWe As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
            paraMpoWe.Value = 0
            mySqlComm.Parameters.Add(paraMpoWe)

            Dim paraMpoAdj As SqlParameter = New SqlParameter("@MpoMatlAdj", SqlDbType.Real, 4)
            paraMpoAdj.Value = 0
            mySqlComm.Parameters.Add(paraMpoAdj)

            Dim parampoLo As SqlParameter = New SqlParameter("@MpoLotNo", SqlDbType.NVarChar, 10)
            parampoLo.Value = ""
            mySqlComm.Parameters.Add(parampoLo)

            Dim paraEngInfo As SqlParameter = New SqlParameter("@MpoEngInfo", SqlDbType.NVarChar, 100)
            paraEngInfo.Value = ""
            mySqlComm.Parameters.Add(paraEngInfo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = 15
            mySqlComm.Parameters.Add(paraDept)

            Dim paraWFM As SqlParameter = New SqlParameter("@Chwfm", SqlDbType.Bit, 1)
            paraWFM.Value = 1
            mySqlComm.Parameters.Add(paraWFM)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Mpo UpDate: " & ex.Message)
            End Try
        Catch ex As Exception
        End Try

    End Sub

    Sub ReleaseRawMatl()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzMatl", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findLot", SqlDbType.NVarChar, 10)
            paraFind.Value = dgStockRes("StLotNo", RowStRes).Value
            mySqlComm.Parameters.Add(paraFind)

            Dim paraData As SqlParameter = New SqlParameter("@MatlDateTranz", SqlDbType.SmallDateTime, 4)
            paraData.Value = Now.ToShortDateString
            mySqlComm.Parameters.Add(paraData)

            Dim paraTranz As SqlParameter = New SqlParameter("@MatlTranz", SqlDbType.NVarChar, 1)
            paraTranz.Value = 2
            mySqlComm.Parameters.Add(paraTranz)

            Dim paraStatus As SqlParameter = New SqlParameter("@MatlStatus", SqlDbType.NVarChar, 1)
            paraStatus.Value = "O"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraLoc As SqlParameter = New SqlParameter("@MatlLoc", SqlDbType.NVarChar, 10)
            paraLoc.Value = dgMatl("StLock", RowMatl).Value
            mySqlComm.Parameters.Add(paraLoc)

            Dim paraQty As SqlParameter = New SqlParameter("@MatlQty", SqlDbType.Real, 4)
            paraQty.Value = dgStockRes("ResWeight", RowStRes).Value
            mySqlComm.Parameters.Add(paraQty)

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgStockRes("MpoID", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraPer As SqlParameter = New SqlParameter("@MatlDeprPer", SqlDbType.Int, 4)
            paraPer.Value = DBNull.Value
            mySqlComm.Parameters.Add(paraPer)

            Dim paraNotes As SqlParameter = New SqlParameter("@MatlComments", SqlDbType.NVarChar, 500)
            paraNotes.Value = Nz.Nz(dgStockRes("ResNotes", RowStRes).Value)
            mySqlComm.Parameters.Add(paraNotes)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Add Release: " & ex.Message)
            End Try
        Catch ex As Exception
        End Try

        CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

    End Sub

    Sub UpdateMpoMasterWeight()

        ' put cut-buff = 26 code
        ' take out matl resev

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOMasterWeight", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpoPar As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
            paraMpoPar.Value = dgStockRes("MpoID", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpoPar)

            Dim paraMpoWe As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
            paraMpoWe.Value = dgStockRes("ResWeight", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpoWe)

            Dim parampoLo As SqlParameter = New SqlParameter("@MpoLotNo", SqlDbType.NVarChar, 10)
            parampoLo.Value = dgStockRes("StLotNo", RowStRes).Value
            mySqlComm.Parameters.Add(parampoLo)

            Dim paraMpoQty As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
            paraMpoQty.Value = dgStockRes("QtyEngReleased", RowStRes).Value
            mySqlComm.Parameters.Add(paraMpoQty)

            Dim paraMpoEngInfo As SqlParameter = New SqlParameter("@MpoEngInfo", SqlDbType.NVarChar, 100)
            paraMpoEngInfo.Value = Str(dgStockRes("QtyEngReleased", RowStRes).Value) + "EA; Weight = " + Str(dgStockRes("ResWeight", RowStRes).Value)
            mySqlComm.Parameters.Add(paraMpoEngInfo)

            Dim swCode As String = ""
            Dim swTest As String = ""

            swTest = dgMatl("MatlFamily", RowMatl).Value

            Dim paraDeptcut As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDeptcut.Value = 0

            If swTest = "Bars" Or swTest = "Hex" Then
                paraDeptcut.Value = 26
            Else
                If swTest = "Coils" Then
                    paraDeptcut.Value = 3
                Else
                    paraDeptcut.Value = 26
                End If
            End If

            mySqlComm.Parameters.Add(paraDeptcut)


            Dim paraWFM As SqlParameter = New SqlParameter("@Chwfm", SqlDbType.Bit, 1)
            paraWFM.Value = 0
            mySqlComm.Parameters.Add(paraWFM)


            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Mpo UpDate: " & ex.Message)
            End Try
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call ValPo()

        If SwVal = True Then

            If (dsMain.HasChanges) Then
                Try
                    UpdateStockRes(dsMain.GetChanges)

                    UpdatePOStockReserv(dsMain.GetChanges)

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

    Public Sub UpdateStockRes(ByVal dsChanges As DataSet)

        Dim cmdIns As SqlCommand
        Dim cmdUpd As SqlCommand
        Dim cmdDel As SqlCommand

        Dim da As SqlDataAdapter

        'insert
        cmdIns = New SqlCommand()
        cmdIns.Connection = cn
        cmdIns.CommandType = CommandType.StoredProcedure
        cmdIns.CommandText = "cspStockResInsert"

        cmdIns.Parameters.Add("@ResMatID", SqlDbType.Int, 4, "ResMatID")
        cmdIns.Parameters.Add("@StLotNo", SqlDbType.NVarChar, 10, "StLotNo")
        cmdIns.Parameters.Add("@MpoID", SqlDbType.Int, 4, "MpoID")
        cmdIns.Parameters.Add("@ResWeight", SqlDbType.Real, 4, "ResWeight")
        cmdIns.Parameters.Add("@ResNotes", SqlDbType.NVarChar, 500, "ResNotes")

        'update
        cmdUpd = New SqlCommand()
        cmdUpd.Connection = cn
        cmdUpd.CommandType = CommandType.StoredProcedure
        cmdUpd.CommandText = "cspStockResUpdate"

        cmdUpd.Parameters.Add("@ResMatID", SqlDbType.Int, 4, "ResMatID")
        cmdUpd.Parameters.Add("@StLotNo", SqlDbType.NVarChar, 10, "StLotNo")
        cmdUpd.Parameters.Add("@MpoID", SqlDbType.Int, 4, "MpoID")
        cmdUpd.Parameters.Add("@ResWeight", SqlDbType.Real, 4, "ResWeight")
        cmdUpd.Parameters.Add("@ResNotes", SqlDbType.NVarChar, 500, "ResNotes")

        'delete
        cmdDel = New SqlCommand()
        cmdDel.Connection = cn
        cmdDel.CommandType = CommandType.StoredProcedure
        cmdDel.CommandText = "cspStockResDelete"

        cmdDel.Parameters.Add("@ResMatID", SqlDbType.Int, 4, "ResMatID")

        'DataApapter
        da = New SqlDataAdapter()

        da.DeleteCommand = cmdDel
        da.InsertCommand = cmdIns
        da.UpdateCommand = cmdUpd

        da.TableMappings.Add("Table", "tblStockRawMatlReservation")

        da.Update(dsChanges)

    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgStockRes.Rows

            If IsDBNull(Row.Cells("MpoID").Value) = True Then
                MsgBox("!!! ERROR !!! MPO Number is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(Row.Cells("ResWeight").Value) = True Then
                MsgBox("!!! ERROR !!! Weight Quantity Reserved is Empty.")
                SwVal = False
                Exit Sub
            End If

            'If IsNothing(Row.Cells("ResWeight").Value) = True Then
            '    MsgBox("!!! ERROR !!! Weight Quantity Reserved is Empty.")
            '    SwVal = False
            '    Exit Sub
            'End If

            If IsDBNull(Row.Cells("QtyEngReleased").Value) = True Then
                MsgBox("!!! ERROR !!! Quantity Eng. Reserved is Empty." + vbCrLf + _
                    "Please first SAVE the Material Reservation and then Release the material to Production")
                SwVal = False
                Exit Sub
            End If

            'If IsNothing(Row.Cells("QtyEngReleased").Value) = true Then
            '    MsgBox("!!! ERROR !!! Quantity Eng. Reserved is Empty." + vbCrLf + _
            '        "Please first SAVE the Material Reservation and then Release the material to Production")
            '    SwVal = False
            '    Exit Sub
            'End If
        Next

        SwVal = True

    End Sub

    Private Sub Rdzero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdZero.CheckedChanged
        txtSpec.Text = ""
        dsMain.Tables("tblStockRawMatl").Clear()
        CallClass.PopulateDataAdapter("getStFinalTblStockRawMatlZero").Fill(dsMain, "tblStockRawMatl")
    End Sub

    Private Sub RdPlus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdPlus.CheckedChanged
        txtSpec.Text = ""
        dsMain.Tables("tblStockRawMatl").Clear()
        CallClass.PopulateDataAdapter("getStFinalTblStockRawMatl").Fill(dsMain, "tblStockRawMatl")
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        'txtSpec.Text = ""
        'dsMain.Tables("tblStockRawMatl").Clear()
        'CallClass.PopulateDataAdapter("getStFinalTblStockRawMatl").Fill(dsMain, "tblStockRawMatl")
        'RdZero.Checked = False
        'RdPlus.Checked = 0

        GC.Collect()

        Call SetupForm()

        If RoleReserveMatl(wkDeptCode) = True Then
            cmdSave.Enabled = True
        Else
            cmdSave.Enabled = False
        End If

    End Sub

    Sub PutMatlType()
        With cmbMatlType
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
            If swFirst = 0 Then
                .SelectedValue = 48
            End If
        End With

    End Sub

    Private Sub cmbMatlType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMatlType.LostFocus
        Dim strSearch As Integer
        strSearch = cmbMatlType.SelectedValue

        dsMain.Tables("tblStockRawMatl").Clear()
        If RdPlus.Checked = True Then
            CallClass.PopulateAdapterAfterSearchInt("getStFinalWithMatlType", strSearch).Fill(dsMain, "tblStockRawMatl")
        Else
            If RdZero.Checked = True Then
                CallClass.PopulateAdapterAfterSearchInt("getStFinalWithMatlTypeStZero", strSearch).Fill(dsMain, "tblStockRawMatl")
            Else
                MsgBox("!!! ERROR !!! Can not identify the selection mode.")
            End If
        End If

    End Sub

    Private Sub cmbMatlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatlType.SelectedIndexChanged
        dgMatl.Focus()
        txtSpec.Text = ""
    End Sub

    Function RoleReserveMatl(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RESMATL" Then
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

    Function RoleReleaseMatl(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RELMATL" Then
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

    Private Sub dgStockRes_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgStockRes.DataError
        REM end
    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Private Sub txtSpec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpec.GotFocus
        txtSpec.Text = ""
    End Sub

    Private Sub txtSpec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSpec.KeyDown
        If e.KeyCode = Keys.Enter Or _
            e.KeyCode = Keys.Return Then

            dsMain.Tables("tblStockRawMatl").Clear()
            If RdPlus.Checked = True Then
                CallClass.PopulateDataAdapterAfterSearch("getStFinalRawMatlWithSpec", txtSpec.Text).Fill(dsMain, "tblStockRawMatl")
            Else
                If RdZero.Checked = True Then
                    CallClass.PopulateDataAdapterAfterSearch("getStFinalRawMatlWithSpecStZero", txtSpec.Text).Fill(dsMain, "tblStockRawMatl")
                Else
                    MsgBox("!!! ERROR !!! Can not identify the search mode.")
                End If
            End If

            dgMatl.Focus()
        End If

    End Sub

    Private Sub dgMatl_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMatl.DataError
        REM end
    End Sub

    Public Sub UpdatePOStockReserv(ByVal dsChanges As DataSet)

        Dim cmdUpd As SqlCommand
        Dim cmdDel As SqlCommand

        Dim da As SqlDataAdapter

        'update
        cmdUpd = New SqlCommand()
        cmdUpd.Connection = cn
        cmdUpd.CommandType = CommandType.StoredProcedure
        cmdUpd.CommandText = "cspStockPOReservUpdate"

        cmdUpd.Parameters.Add("@MatlPoResID", SqlDbType.Int, 4, "MatlPoResID")
        cmdUpd.Parameters.Add("@MatlPoWeight", SqlDbType.Real, 4, "MatlPoWeight")
        cmdUpd.Parameters.Add("@MatlPoNotes", SqlDbType.NVarChar, 500, "MatlPoNotes")

        'delete
        cmdDel = New SqlCommand()
        cmdDel.Connection = cn
        cmdDel.CommandType = CommandType.StoredProcedure
        cmdDel.CommandText = "cspStockPoReservDelete"

        cmdDel.Parameters.Add("@MatlPoResID", SqlDbType.Int, 4, "MatlPoResID")

        'DataApapter
        da = New SqlDataAdapter()

        da.DeleteCommand = cmdDel
        da.UpdateCommand = cmdUpd

        da.TableMappings.Add("Table", "tblStockRawMatlPOReserv")

        da.Update(dsChanges)

    End Sub

    Private Sub CmdMatlCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMatlCert.Click
        'Dim SwPath As String = ""
        'SwPath = CallClass.ReturnInfoWithParString("cspReturnMatlCertPath", dgMatl("StLotNo", RowMatl).Value)
        'If SwPath <> "False" Then
        '    Process.Start(SwPath)
        'Else
        '    MsgBox("Nothing to View.")
        'End If


        Dim pattern As String = ""
        Dim SwPath As String = ""
        'Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Inspection\Raw Material\Raw Material Cert")
        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\Lisi Raw Material Mill Certs\Raw Material Cert")
        Dim txtLotno As String = dgMatl("StLotNo", RowMatl).Value

        If Len(txtLotno) = 0 Then
            MsgBox("Nothing to View.")
            Exit Sub
        End If

        Select Case Len(txtLotno)
            Case 2
                pattern = "M-00" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case 3
                pattern = "M-0" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case Else
                pattern = "M-" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
        End Select

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                ' Create an instance
                Dim proc As New System.Diagnostics.Process()

                ' Fill-up StartInfo
                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
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

        Select Case Len(txtLotno)
            Case 2
                pattern = "M00" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case 3
                pattern = "M0" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
            Case Else
                pattern = "M" + Microsoft.VisualBasic.Right(txtLotno, Len(txtLotno) - 1) + ".PDF"
        End Select

        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        ListFiles(lstFiles, pattern, dir_info)

        If lstFiles.Items.Count > 0 Then
            SwPath = lstFiles.Items(0)

            If IsDBNull(SwPath) = False And IsNothing(SwPath) = False And Len(Trim(SwPath)) <> 0 Then

                ' Create an instance
                '
                Dim proc As New System.Diagnostics.Process()
                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwPath

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If
        Else
            MsgBox("Nothing to View.")
        End If

    End Sub

    Private Sub ListFiles(ByVal lst As ListBox, ByVal pattern As String, ByVal dir_info As IO.DirectoryInfo)
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
    End Sub

    Private Sub CmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMat.Click
        frmEngMatlType.ShowDialog()
    End Sub

    Private Sub dgStockRes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStockRes.KeyDown

        If e.KeyCode = Keys.Delete Then
            If wkAccess = 11 Then            'chief inspector and RM
                If MessageBox.Show("Access Denied", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning, _
            MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub CmdViewPO_Click(sender As Object, e As EventArgs) Handles CmdViewPO.Click


        Dim FindPO As String = ""
        Dim SwEndUser As String = ""
        Dim StrSQL As String = ""

        If RowMatl < 0 Then
            Exit Sub
        End If

        If dgMatl.RowCount > 0 Then

            ' StrSQL = "SELECT PartID, NasMsLength, NasMsDia FROM tblPartNasMs WHERE (PartID = '" & IndexPart & "')"


            StrSQL = "Select dbo.tblPOMaster.PONo FROM dbo.tblPOReceiving INNER JOIN dbo.tblPODetails ON dbo.tblPOReceiving.PODetailID = dbo.tblPODetails.PODetailID INNER JOIN" & _
                          " dbo.tblPOMaster ON dbo.tblPODetails.POMasterID = dbo.tblPOMaster.POMasterID WHERE (dbo.tblPOReceiving.PORecvID = '" & dgMatl("PORecvID", RowMatl).Value & "')"

            Dim mySqlComm As New Data.SqlClient.SqlCommand(StrSQL, cn)
            Dim myReader As Data.SqlClient.SqlDataReader
            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                myReader = mySqlComm.ExecuteReader()

                Dim TestRec As Int16
                TestRec = myReader.HasRows
                If TestRec <> -1 Then
                    myReader.Close()
                    myReader.Dispose()
                Else
                    While myReader.Read()
                        FindPO = Nz.Nz(myReader.GetValue(0))
                    End While
                    myReader.Close()
                    myReader.Dispose()
                End If
            Catch xcp As SqlException
                MessageBox.Show(xcp.Message, "SQL Error - Missing PO Number  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try


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

    Private Sub frmReleaseRawMaterial_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        'Dim RW As Double = (Me.Width - CW) / CW ' Ratio change of width
        'Dim RH As Double = (Me.Height - CH) / CH ' Ratio change of height

        'For Each Ctrl As Control In Controls
        '    Ctrl.Width += CInt(Ctrl.Width * RW)
        '    Ctrl.Height += CInt(Ctrl.Height * RH)
        '    Ctrl.Left += CInt(Ctrl.Left * RW)
        '    Ctrl.Top += CInt(Ctrl.Top * RH)
        'Next

        'CW = Me.Width
        'CH = Me.Height

        'Dim Screen As System.Drawing.Rectangle
        'Screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea()
        'Me.Top = (Screen.Height \ 2) - (Me.Height \ 2)
        'Me.Left = (Screen.Width \ 2) - (Me.Width \ 2)

    End Sub

End Class