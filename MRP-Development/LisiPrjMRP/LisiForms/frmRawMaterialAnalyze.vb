Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmRawMaterialAnalyze

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Private dt As New DataTable

    Dim RowSel As Integer = 0
    Dim RowMatlPref As Integer = 0
    Dim RowMatlInv As Integer = 0

    Dim SwDepSales As Boolean = False
    Dim SwFirstClick As Boolean = False

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmRawMaterialAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmRawMaterialAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1600 And Height > 900 Then
            Me.Width = 1600
            Me.Height = 900
        Else
            If Width < 1600 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        PutKSI()
        PutDept()
        PutPart()
        PutCust()
        PutRMArticle()

        SetCtlForm()

        cmbDept.Text = ""
        CmbPart.Text = ""
        CmbCust.text = ""
        CmbRM.Text = ""

       
    End Sub

    Sub HideFields()

        txtMpoWithWeight.Text = ""
        txtMPONoWeight.Text = ""
        txtTotalMPOWeight.Text = ""
        txtRMDisp.Text = ""
        txtRMToBuy.Text = ""

        LblDisp.Visible = False
        txtRMDisp.Visible = False
        LblBuy.Visible = False
        txtRMToBuy.Visible = False

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        PutTablesAdapters()
        dsMain.EnforceConstraints = False

        PutRelations()
        PutDataGrid()

    End Sub

    Sub PutRelations()
        With dsMain
            .Relations.Add("MatlPref", _
               .Tables("tblSelect").Columns("PartID"), _
                .Tables("tmpPartMatlPref").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PrefWithRMInv", _
               .Tables("tmpPartMatlPref").Columns("LinkCombKey"), _
                .Tables("tmpRMInventory").Columns("LinkCombKey"), True)
        End With

    End Sub


    Sub PutTablesAdapters()

        'gettblPartMatlPrefEmpty is use in other screens
        CallClass.PopulateDataAdapter("getRMAnalizeAllEmpty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefEmpty").Fill(dsMain, "tmpPartMatlPref")
        CallClass.PopulateDataAdapter("gettblRawMaterialInvEmpty").Fill(dsMain, "tmpRMInventory")
        CallClass.PopulateDataAdapter("gettblRawMaterialRezervationEmpty").Fill(dsMain, "tmpRMRezervation")
        CallClass.PopulateDataAdapter("gettblPORMPurchaseEmpty").Fill(dsMain, "tmpPORMPurchase")

    End Sub

    Sub PutDataGrid()

        dgSel.AutoGenerateColumns = False
        dgSel.DataSource = dsMain
        dgSel.DataMember = "tblSelect"

        dgMatlPref.AutoGenerateColumns = False
        dgMatlPref.DataSource = dsMain
        dgMatlPref.DataMember = "tblSelect.MatlPref"

        dgRMInv.AutoGenerateColumns = False
        dgRMInv.DataSource = dsMain
        dgRMInv.DataMember = "tblSelect.MatlPref.PrefWithRMInv"

    End Sub

    Sub PutKSI()

        With cmbksi
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlKSI").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "FullDescr"
        End With

    End Sub

    Sub PutDept()

        With cmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartmentBeforeProd").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutPart()

        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberForRMAnalyze").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub PutCust()

        With CmbCust
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetCustomerForRMAnalyze").Tables("tblPartMaster")
            .DisplayMember = "CustomerShort"
            .ValueMember = "CustID"
        End With

    End Sub

    Sub PutRMArticle()
        'change done
        With CmbRM
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbRMArticleForRMAnalyze").Tables("tblPartMaster")
            .DisplayMember = "RMKey"
            .ValueMember = "LinkCombKey"
        End With
    End Sub

    Sub SetCtlForm()

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.MPOPromDate
            .DataPropertyName = "MPOPromDate"
            .Name = "MPOPromDate"
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

        With Me.RawWeight
            .DataPropertyName = "RawWeight"
            .Name = "RawWeight"
        End With

        With Me.RawWeightFromBl
            .DataPropertyName = "RawWeightFromBl"
            .Name = "RawWeightFromBl"
        End With

        With Me.MpoEstWeight
            .DataPropertyName = "MpoEstWeight"
            .Name = "MpoEstWeight"
        End With

        With Me.MPOFinalWeight
            .DataPropertyName = "MPOFinalWeight"
            .Name = "MPOFinalWeight"
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

        With Me.ProcessID
            .DataPropertyName = "ProcessID"
            .Name = "ProcessID"
            .Visible = False
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.SwRMType
            .DataPropertyName = "SwRMType"
            .Name = "SwRMType"
        End With

        With Me.SwRMDia
            .DataPropertyName = "SwRMDia"
            .Name = "SwRMDia"
        End With

        With Me.SwLeadTime
            .DataPropertyName = "SwLeadTime"
            .Name = "SwLeadTime"
        End With

        With Me.SwStartDate
            .DataPropertyName = "SwStartDate"
            .Name = "SwStartDate"
        End With

        'dgMatlPref  prefferd
        With Me.PartMatlID
            .DataPropertyName = "PartMatlID"
            .Name = "PartMatlID"
            .Visible = False
        End With

        With Me.LinkCombKey
            .DataPropertyName = "LinkCombKey"
            .Name = "LinkCombKey"
            .Visible = False
        End With

        With Me.MatlPrefPartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.MatlDetIDPref
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetIDPref"
            .DropDownWidth = 500
            .MaxDropDownItems = 20
        End With

        With Me.MatlForm
            .DataPropertyName = "MatlForm"
            .Name = "MatlForm"
        End With

        With Me.MatlDia
            .DataPropertyName = "MatlDia"
            .Name = "MatlDia"
        End With

        With Me.SwRMKSI
            .DataPropertyName = "SwRMKSI"
            .Name = "SwRMKSI"
        End With

        'dgRMInv  

        With Me.StRawMatlID
            .DataPropertyName = "StRawMatlID"
            .Name = "StRawMatlID"
            .Visible = False
        End With

        With Me.RMInvLinkCombKey
            .DataPropertyName = "LinkCombKey"
            .Name = "LinkCombKey"
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

        With Me.StLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.StUM
            .DataPropertyName = "StUM"
            .Name = "StUM"
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.MatDetKSI
            .DataPropertyName = "MatDetKSI"
            .Name = "MatDetKSI"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.MatlFamily
            .DataPropertyName = "MatlFamily"
            .Name = "MatlFamily"
        End With

        With Me.MatDetSpecs
            .DataPropertyName = "MatDetSpecs"
            .Name = "MatDetSpecs"
        End With

        With Me.MatDetNotes
            .DataPropertyName = "MatDetNotes"
            .Name = "MatDetNotes"
        End With

        With Me.StComments
            .DataPropertyName = "StComments"
            .Name = "StComments"
        End With

        'dgRezerv
        With Me.RezervStLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.RezervMpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.ResWeight
            .DataPropertyName = "ResWeight"
            .Name = "ResWeight"
        End With

        'dgPOMatl
        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PODueDate
            .DataPropertyName = "PODueDate"
            .Name = "PODueDate"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.DiffQty
            .DataPropertyName = "DiffQty"
            .Name = "DiffQty"
        End With

        With Me.POMatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.POMatDetKSI
            .DataPropertyName = "MatDetKSI"
            .Name = "MatDetKSI"
        End With

        With Me.POMatlDia
            .DataPropertyName = "POMatlDia"
            .Name = "POMatlDia"
        End With

        With Me.POLinkCombKey
            .DataPropertyName = "LinkCombKey"
            .Name = "LinkCombKey"
            .Visible = False
        End With

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            '.Visible = False
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        SwFirstClick = False

        dsMain.Clear()
        cmbDept.Text = ""

        HideFields()

        CallClass.PopulateDataAdapter("getRMAnalizeAll").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefRMAnalyze").Fill(dsMain, "tmpPartMatlPref")
        'CallClass.PopulateDataAdapter("gettblMatlPrefLinkWithRMInv").Fill(dsMain, "tmpRMInventory")

        PutDataGrid()

        If RowMatlPref >= 0 And RowMatlPref < dgMatlPref.Rows.Count - 1 Then
            dgMatlPref("LinkCombKey", RowMatlPref).Selected = True
        End If

        CalculValue()
        PutMatlReserv()
        PutPORawMaterial()
        CalculFields()

    End Sub

    Sub PeintWeightPO()

        ' cspReturnLinkRMKey   DONE
        Dim KeepPOWeight As Integer = 0
        KeepPOWeight = txtRMPO.Text

        Dim CountMpo As Integer = 0

        If KeepPOWeight > 0 Then

            Dim KeyLink As String = ""
            Dim StrSearch As Integer = 0
            Dim getInfo As String = ""

            If dgMatlPref.Rows.Count > 0 Then
                'KeyLink = LTrim(dgMatlPref("LinkCombKey", RowMatlPref).Value)
                For Each Row As DataGridViewRow In dgMatlPref.Rows
                    KeyLink = Val(Row.Cells("LinkCombKey").Value)

                    For I As Integer = 0 To (dgSel.Rows.Count - 1)
                        StrSearch = Nz.Nz(dgSel("PartID", I).Value)
                        getInfo = CallClass.ReturnStrWithParInt("cspReturnLinkRMKey", StrSearch)
                        If KeyLink = getInfo Then
                            CountMpo = 0
                            For J As Integer = 0 To (dgRezerv.Rows.Count - 1)
                                If dgSel("MPONo", I).Value = dgRezerv("MpoNo", J).Value Then
                                    CountMpo = CountMpo + 1
                                End If
                            Next J

                            If CountMpo = 0 Then
                                KeepPOWeight = KeepPOWeight - Nz.Nz(dgSel("MPOFinalWeight", I).Value)
                                If KeepPOWeight > 0 Then
                                    dgSel("MPONo", I).Style.BackColor = Color.LightSalmon
                                End If
                            End If
                        End If
                    Next I
                Next
            Else
                Exit Sub
            End If


        End If

    End Sub

    Sub CalculValue()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgSel.Rows

            If SwDepSales = False Then
                If Row.Cells("DeptNode").Value = "Sales Hold" Then
                    Row.Cells("MPOFinalWeight").Value = DBNull.Value
                    GoTo SWNEXT
                End If
            End If

            If Nz.Nz(Row.Cells("MpoEstWeight").Value) > 0 Then
                Row.Cells("MPOFinalWeight").Value = Row.Cells("MpoEstWeight").Value
                GoTo SWNEXT
            End If

            If Nz.Nz(Row.Cells("RawWeight").Value) > 0 Then
                If Nz.Nz(Row.Cells("QtyEngReleased").Value) > 0 Then
                    Row.Cells("MPOFinalWeight").Value = Math.Round(Row.Cells("QtyEngReleased").Value * Row.Cells("RawWeight").Value, 0)
                Else
                    Row.Cells("MPOFinalWeight").Value = Math.Round(Row.Cells("QtyOrder").Value * Row.Cells("RawWeight").Value, 0)
                End If
                GoTo SWNEXT
            End If

            If Nz.Nz(Row.Cells("RawWeightFromBl").Value) > 0 Then
                If Nz.Nz(Row.Cells("QtyEngReleased").Value) > 0 Then
                    Row.Cells("MPOFinalWeight").Value = Math.Round(Row.Cells("QtyEngReleased").Value * Row.Cells("RawWeight").Value, 0)
                Else
                    Row.Cells("MPOFinalWeight").Value = Math.Round(Row.Cells("QtyOrder").Value * Row.Cells("RawWeight").Value, 0)
                End If
                GoTo SWNEXT
            End If

SWNEXT: Next

    End Sub

    Private Sub dgSel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSel.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            RowSel = e.RowIndex

            'dgSel.Rows(e.RowIndex).Selected = True
            PutMatlReserv()
            PutPORawMaterial()
            CalculFields()
            CheckTotalWeightforSelection()
            PrepareRMInfo()
        End If

    End Sub

    Private Sub dgSel_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSel.CellEnter

        If e.RowIndex < 0 Then
            Return
        Else
            RowSel = e.RowIndex
        End If

    End Sub

    Sub PrepareRMInfo()

        If SwFirstClick = False Then

            Dim StrSearch As Integer = 0
            Dim getInfo As String = ""
            Dim getMatl As String = ""

            Dim DelDate As Date
            Dim StartDate As Date
            Dim NoWks As Integer

            For I As Integer = 0 To (dgSel.Rows.Count - 1)
                StrSearch = Nz.Nz(dgSel("PartID", I).Value)

                If IsDBNull(dgSel("DelivDate", I).Value) = False Then
                    DelDate = CDate(dgSel("DelivDate", I).Value).ToShortDateString
                    NoWks = Nz.Nz(dgSel("SwLeadTime", I).Value) * 7
                    If NoWks <> 0 Then
                        StartDate = DateAdd(DateInterval.Day, -NoWks, DelDate).ToShortDateString
                        dgSel("SwStartDate", I).Value = StartDate.ToShortDateString
                    Else
                        dgSel("SwStartDate", I).Value = DBNull.Value
                    End If
                End If

            Next I

            SwFirstClick = True
        End If

    End Sub

    Sub CheckTotalWeightforSelection()

        Dim KeyLink As String = ""
        Dim StrSearch As Integer = 0
        Dim getInfo As String = ""
        Dim SwMPOWithWeight As Integer = 0
        Dim SwMPONoWeight As Integer = 0
        Dim SwMPOWeight As Integer = 0
        Dim SwCalculWeight As Integer = 0

        txtMpoWithWeight.Text = ""
        txtMPONoWeight.Text = ""
        txtTotalMPOWeight.Text = ""
        txtRMDisp.Text = ""
        txtRMToBuy.Text = ""

        For I As Integer = 0 To (dgSel.Rows.Count - 1)
            dgSel("PartNumber", I).Style.BackColor = Color.White
        Next I

        If dgMatlPref.Rows.Count > 0 Then
            'KeyLink = LTrim(dgMatlPref("LinkCombKey", RowMatlPref).Value)

            For Each Row As DataGridViewRow In dgMatlPref.Rows
                If IsDBNull(Row.Cells("LinkCombKey").Value) = False Then
                    KeyLink = Val(Row.Cells("LinkCombKey").Value)


                    For I As Integer = 0 To (dgSel.Rows.Count - 1)
                        StrSearch = Nz.Nz(dgSel("PartID", I).Value)

                        getInfo = CallClass.ReturnStrWithParInt("cspReturnLinkRMKey", StrSearch)
                        If KeyLink = getInfo Then
                            If Nz.Nz(dgSel("MPOFinalWeight", I).Value) > 0 Then
                                SwMPOWithWeight = SwMPOWithWeight + 1
                                SwMPOWeight = SwMPOWeight + Nz.Nz(dgSel("MPOFinalWeight", I).Value)
                                dgSel("PartNumber", I).Style.BackColor = Color.LightSkyBlue
                            Else
                                SwMPONoWeight = SwMPONoWeight + 1
                            End If
                        End If

                    Next I


                    txtMpoWithWeight.Text = SwMPOWithWeight.ToString
                    txtMPONoWeight.Text = SwMPONoWeight.ToString
                    txtTotalMPOWeight.Text = SwMPOWeight.ToString

                    SwCalculWeight = CInt(txtRMStock.Text) + CInt(txtRMPO.Text) - CInt(txtTotalMPOWeight.Text)

                    If SwCalculWeight < 0 Then
                        LblDisp.Visible = False
                        txtRMDisp.Visible = False
                        LblBuy.Visible = True
                        txtRMToBuy.Visible = True
                        txtRMToBuy.Text = (SwCalculWeight * -1).ToString("N0")
                    Else
                        LblBuy.Visible = False
                        txtRMToBuy.Visible = False
                        LblDisp.Visible = True
                        txtRMDisp.Visible = True
                        txtRMDisp.Text = SwCalculWeight.ToString("N0")
                    End If



                End If
            Next
        Else
            HideFields()
            Exit Sub
        End If
    End Sub

    Private Sub dgSel_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSel.Sorted

        CalculValue()

        SwFirstClick = False
        PrepareRMInfo()

    End Sub

    Sub PutMatlFamily()

        For I As Integer = 0 To (dgRMInv.Rows.Count - 1)
            If Nz.Nz(dgRMInv("RecvMatlBars", I).Value) = True Then
                dgRMInv("MatlFamily", I).Value = "Bars"
            Else
                If Nz.Nz(dgRMInv("RecvMatlCoils", I).Value) = True Then
                    dgRMInv("MatlFamily", I).Value = "Coils"
                Else
                    If Nz.Nz(dgRMInv("RecvMatlHex", I).Value) = True Then
                        dgRMInv("MatlFamily", I).Value = "Hex"
                    Else
                        dgRMInv("MatlFamily", I).Value = "????"
                    End If
                End If
            End If
        Next I
    End Sub

    Private Sub CmdMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMethod.Click

        Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim rptPO As New rptMFGMethodBarCodeRefOnly
        rptPO.Load("..\rptMFGMethodBarCodeRefOnly.rpt")

        pdvMpoID.Value = Convert.ToInt32(dgSel.Rows(RowSel).Cells("MPOID").Value)
        pdvPartID.Value = Convert.ToInt32(dgSel.Rows(RowSel).Cells("PartID").Value)
        pvMPOIDCollection.Add(pdvMpoID)
        pvPartIDCollection.Add(pdvPartID)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
        rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()

    End Sub

    Private Sub dgRMInv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRMInv.CellClick
        If e.RowIndex < 0 Then
            Return
        Else
            RowMatlInv = e.RowIndex
        End If
    End Sub

    Private Sub dgRMInv_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRMInv.CellEnter
        If e.RowIndex < 0 Then
            Return
        Else
            RowMatlInv = e.RowIndex
        End If

        PutMatlFamily()
    End Sub

    Private Sub dgMatlPref_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMatlPref.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            RowMatlPref = e.RowIndex

            PutMatlReserv()
            PutPORawMaterial()
            CalculFields()
            CheckTotalWeightforSelection()
            PeintWeightPO()
        End If

    End Sub

    Private Sub dgMatlPref_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMatlPref.CellEnter

        If e.RowIndex < 0 Then
            Return
        Else
            RowMatlPref = e.RowIndex
        End If

    End Sub

    Sub PutMatlReserv()

        dsMain.Tables("tmpRMRezervation").Clear()
        Dim StrSearch As Integer = 0
        Dim getInfo As String = ""

        For I As Integer = 0 To (dgRMInv.Rows.Count - 1)

            If IsDBNull(dgRMInv("StLotNo", I).Value) = True Then
                Exit Sub
            Else
                If Len(Trim(dgRMInv("StLotNo", I).Value)) = 0 Then
                    Exit Sub
                Else
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    CallClass.PopulateDataAdapterAfterSearch("getRawMaterialReservation", dgRMInv("StLotNo", I).Value).Fill(dsMain, "tmpRMRezervation")

                    dgRezerv.AutoGenerateColumns = False
                    dgRezerv.DataSource = dsMain
                    dgRezerv.DataMember = "tmpRMRezervation"
                End If
            End If
        Next I

        For K As Integer = 0 To (dgSel.Rows.Count - 1)
            dgSel("MPONo", K).Style.BackColor = Color.White
        Next K

        For K As Integer = 0 To (dgSel.Rows.Count - 1)
            For J As Integer = 0 To (dgRezerv.Rows.Count - 1)
                If dgSel("MPONo", K).Value = dgRezerv("MpoNo", J).Value Then
                    dgSel("MPONo", K).Style.BackColor = Color.Khaki
                End If
            Next J
        Next K
    End Sub

    Sub CalculFields()

        Dim qty As Double = 0.0
        Dim qtyKSI As Double = 0.0
        Dim SwKSY As String = ""
        txtRMStock.Text = ""
        txtRmRezerv.Text = ""
        txtRMPO.Text = ""

        For Each Row As DataGridViewRow In dgRMInv.Rows
            qty = qty + Val(Row.Cells("StFinal").Value)
            SwKSY = Nz.Nz(Microsoft.VisualBasic.Left(Row.Cells("MatDetKSI").Value.ToString, 3))
            If Val(SwKSY) >= Val(CmbKsi.Text) Then
                qtyKSI = qtyKSI + Val(Row.Cells("StFinal").Value)
            End If
        Next
        txtRMStock.Text = qtyKSI.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgRezerv.Rows
            qty = qty + Val(Row.Cells("ResWeight").Value)
        Next

        txtRmRezerv.Text = qty.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgPOMatl.Rows
            qty = qty + Val(Row.Cells("DiffQty").Value)
        Next
        txtRMPO.Text = qty.ToString("N0")

    End Sub

    Sub PutPORawMaterial()

        Dim strSearchPlus As String = ""
        Dim strSearchMinus As String = ""
        Dim StrForm As String = ""

        dsMain.Tables("tmpPORMPurchase").Clear()
        dsMain.Tables("tmpRMInventory").Clear()

        Dim strSearch As String = ""
        If RowMatlPref >= 0 And RowMatlPref < dgMatlPref.Rows.Count Then

            For Each Row As DataGridViewRow In dgMatlPref.Rows
                strSearch = Nz.Nz(Row.Cells("LinkCombKey").Value)
                StrForm = Nz.Nz(Row.Cells("MatlForm").Value)

                If Val(strSearch) > 0 Then
                    'CallClass.PopulateDataAdapterAfterSearch("gettblPORMPurchaseWithKey", strSearch).Fill(dsMain, "tmpPORMPurchase")
                    'CallClass.PopulateDataAdapterAfterSearch("gettblMatlPrefLinkWithRMInv", strSearch).Fill(dsMain, "tmpRMInventory")

                    strSearchPlus = strSearch + 0.03
                    strSearchMinus = strSearch - 0.001

                    CallClass.PopulateDataAdapterSearch3Param("gettblPORMPurchaseWithKey3Params", strSearchPlus, strSearchMinus, StrForm).Fill(dsMain, "tmpPORMPurchase")

                    CallClass.PopulateDataAdapterSearch3Param("gettblMatlPrefLinkWithRMInv3Params", strSearchPlus, strSearchMinus, StrForm).Fill(dsMain, "tmpRMInventory")

                End If
            Next

            'dsMain.Tables("tmpPORMPurchase").DefaultView.ToTable(True, "PONo")
            'dsMain.Tables("tmpRMInventory").DefaultView.ToTable(True, "StRawMatlID")

            'dt1.DefaultView.RowFilter = "Michel > 33 And Michel < 66"
            'Dim dt2 As DataTable = dt1.DefaultView.ToTable(False, "Cor")
            'DataGridView1.DataSource = dt2


            'Try this code. u'll get distinct table from ur original table(dtTemp).


            'Dim dt As DataTable
            'dt = dsMain.Tables("tmpRMInventory").DefaultView.ToTable(True, "StRawMatlID")
            'dsMain.Tables("tmpRMInventory").Clear()
            'dsMain.Tables("tmpRMInventory") = dt

            CallClass.SortDataTable(dsMain.Tables("tmpRMInventory"), "StLotNo")
            CallClass.removeDuplicateRMInv(dsMain.Tables("tmpRMInventory"))

            dgRMInv.AutoGenerateColumns = False
            dgRMInv.DataSource = dsMain
            dgRMInv.DataMember = "tmpRMInventory"

            CallClass.SortDataTable(dsMain.Tables("tmpPORMPurchase"), "PODetailID")
            CallClass.removeDuplicateRMPOLines(dsMain.Tables("tmpPORMPurchase"))

            dgPOMatl.AutoGenerateColumns = False
            dgPOMatl.DataSource = dsMain
            dgPOMatl.DataMember = "tmpPORMPurchase"

        End If

    End Sub

    Private Sub cmbDept_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.DropDownClosed
        SwDepSales = True
        SwFirstClick = False

        dsMain.Clear()
        cmbDept.Focus()

        HideFields()

        Dim strSearch As String
        strSearch = cmbDept.SelectedValue

        CallClass.PopulateAdapterAfterSearchInt("getRMAnalizeAllByDept", strSearch).Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefRMAnalyze").Fill(dsMain, "tmpPartMatlPref")
        'CallClass.PopulateDataAdapter("gettblMatlPrefLinkWithRMInv").Fill(dsMain, "tmpRMInventory")

        PutDataGrid()
        'dgMatlPref("LinkCombKey", RowMatlPref).Selected = True
        If dgSel.Rows.Count <= 0 Then
            dsMain.Tables("tmpPartMatlPref").Clear()
        End If

        CalculValue()
        PutMatlReserv()
        PutPORawMaterial()
        CalculFields()

    End Sub

    Private Sub CmbPart_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPart.DropDownClosed
        SwDepSales = False
        SwFirstClick = False

        dsMain.Clear()
        CmbPart.Focus()

        HideFields()

        Dim strSearch As String
        strSearch = CmbPart.SelectedValue

        'getRMAnalizeAllByPartNumber  DONE
        'gettblPartMatlPrefRMAnalyze  DONE
        'gettblMatlPrefLinkWithRMInv  DONE
        CallClass.PopulateAdapterAfterSearchInt("getRMAnalizeAllByPartNumber", strSearch).Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefRMAnalyze").Fill(dsMain, "tmpPartMatlPref")
        'CallClass.PopulateDataAdapter("gettblMatlPrefLinkWithRMInv").Fill(dsMain, "tmpRMInventory")

        PutDataGrid()
        'dgMatlPref("LinkCombKey", RowMatlPref).Selected = True
        If dgSel.Rows.Count <= 0 Then
            dsMain.Tables("tmpPartMatlPref").Clear()
        End If

        CalculValue()
        PutMatlReserv()
        PutPORawMaterial()
        CalculFields()

    End Sub

    Private Sub CmbRM_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbRM.DropDownClosed

        SwDepSales = False
        SwFirstClick = False

        dsMain.Clear()

       HideFields

        CmbRM.Focus()

        Dim strSearch As String
        strSearch = CmbRM.SelectedValue

        If IsNothing(strSearch) Then
            Exit Sub
        End If
        CallClass.PopulateDataAdapterAfterSearch("getRMAnalizeAllByRMArticle", strSearch).Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefRMAnalyze").Fill(dsMain, "tmpPartMatlPref")
        'CallClass.PopulateDataAdapter("gettblMatlPrefLinkWithRMInv").Fill(dsMain, "tmpRMInventory")

        PutDataGrid()
        'dgMatlPref("LinkCombKey", RowMatlPref).Selected = True
        If dgSel.Rows.Count <= 0 Then
            dsMain.Tables("tmpPartMatlPref").Clear()
        End If

        CalculValue()
        PutMatlReserv()
        PutPORawMaterial()
        CalculFields()

    End Sub

    Private Sub CmdPrintPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrintPO.Click

        Dim rptPO As New rptRawMaterialActivePOList
        rptPO.Load("..\rptRawMaterialActivePOList.rpt")
        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
        frmPOPrintAll.CrystalReportViewer1.ShowPrintButton = True
        frmPOPrintAll.CrystalReportViewer1.ShowExportButton = True
        frmPOPrintAll.ShowDialog()

    End Sub

    Private Sub CmbCust_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCust.DropDownClosed
        SwDepSales = False
        SwFirstClick = False

        dsMain.Clear()
        CmbPart.Focus()

        HideFields()

        Dim strSearch As String
        strSearch = CmbCust.SelectedValue

        CallClass.PopulateAdapterAfterSearchInt("getRMAnalizeAllByCustomer", strSearch).Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefRMAnalyze").Fill(dsMain, "tmpPartMatlPref")
        'CallClass.PopulateDataAdapter("gettblMatlPrefLinkWithRMInv").Fill(dsMain, "tmpRMInventory")

        PutDataGrid()
        'dgMatlPref("LinkCombKey", RowMatlPref).Selected = True
        If dgSel.Rows.Count <= 0 Then
            dsMain.Tables("tmpPartMatlPref").Clear()
        End If

        CalculValue()
        PutMatlReserv()
        PutPORawMaterial()
        CalculFields()

    End Sub

   
    Private Sub CmbKsi_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbKsi.Validating
        dgMatlPref.Focus()
        txtTotalMPOWeight.Focus()
        CalculFields()
        CheckTotalWeightforSelection()
    End Sub

    Private Sub frmRawMaterialAnalyze_Resize(sender As Object, e As EventArgs) Handles Me.Resize


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