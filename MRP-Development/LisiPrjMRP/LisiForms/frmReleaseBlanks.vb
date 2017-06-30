Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmReleaseBlanks
    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowBlank As Integer = 0
    Dim RowRes As Integer = 0
    Dim RowMpo As Integer = 0
    Dim SwVal As Boolean
    Dim OldDept As Integer

    Dim KeepNo As Integer = 0

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 
    Dim swFirst As Integer = 0 'first time = 0

    Private Sub frmReleaseBlanks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmReleaseBlanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        If RoleResBlanks(wkDeptCode) = True Then
            cmdSave.Enabled = True
        Else
            cmdSave.Enabled = False
        End If

        Call SetupForm()

    End Sub

    Sub SetupForm()

        InitialComponents()
        DisableFields()

        SetCtlForm()

        PutPartRef()

        txtQtyReleased.ReadOnly = True
        txtQtyReleased.Text = ""
        RdPlus.Checked = True
        RdZero.Checked = False

        dgBlank.AutoGenerateColumns = False
        dgBlank.DataSource = dsMain
        dgBlank.DataMember = "tblBlanksAndWIP"

        PutSFStock()

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblBlanksAndWIP.StBlank_Released"

        dgStockRes.AutoGenerateColumns = False
        dgStockRes.DataSource = dsMain
        dgStockRes.DataMember = "tblBlanksAndWIP.StBlank_Reserv"

        dgPartList.AutoGenerateColumns = False
        dgPartList.DataSource = dsMain
        dgPartList.DataMember = "tblBlanksAndWIP.StBlank_PartList"

        If swFirst = 0 Then
            swFirst = 9
        Else
            CalculTotMpoMatl()
            PutValueStRes()
        End If

    End Sub

    Sub SetCtlForm()

        'dgBlank

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.SwBlankST
            .DataPropertyName = "SwBlankST"
            .Name = "SwBlankST"
        End With

        With Me.SwBalance
            .DataPropertyName = "SwBalance"
            .Name = "SwBalance"
        End With

        With Me.StQty
            .DataPropertyName = "StQty"
            .Name = "StQty"
            .Visible = False
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
            .Visible = False
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
            .Visible = False
        End With

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.MpoPartID
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
            .Visible = False
        End With

        With Me.DeptPage
            .DataPropertyName = "DeptPage"
            .Name = "DeptPage"
            .Visible = False
        End With

        With Me.StockLoc
            .DataPropertyName = "StockLoc"
            .Name = "StockLoc"
            .Visible = False
        End With

        With Me.StNotes
            .DataPropertyName = "StNotes"
            .Name = "StNotes"
            .Visible = False
        End With

        With Me.PartRefIndex
            .DataPropertyName = "PartRefIndex"
            .Name = "PartRefIndex"
            .Visible = False
        End With

        With Me.PartRefDia
            .DataPropertyName = "PartRefDia"
            .Name = "PartRefDia"
            .Visible = False
        End With

        With Me.PartRefLength
            .DataPropertyName = "PartRefLength"
            .Name = "PartRefLength"
            .Visible = False
        End With

        With Me.PartOSCode
            .DataPropertyName = "PartOSCode"
            .Name = "PartOSCode"
            .Visible = False
        End With

        With Me.PartRefNotes
            .DataPropertyName = "PartRefNotes"
            .Name = "PartRefNotes"
            .Visible = False
        End With

        With Me.PartRefID
            .DataPropertyName = "PartRefID"
            .Name = "PartRefID"
            .Visible = False
        End With

        'dgMpo

        With Me.MpoNoFrom
            .DataPropertyName = "MpoNoFrom"
            .Name = "MpoNoFrom"
        End With

        With Me.MpoNoTo
            .DataPropertyName = "MpoNoTo"
            .Name = "MpoNoTo"
        End With

        With Me.PartNumberTO
            .DataPropertyName = "PartNumberTO"
            .Name = "PartNumberTO"
        End With

        With Me.RelQtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.RelQtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.RelQtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.RelDeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.MpoIDFrom
            .DataPropertyName = "MpoIDFrom"
            .Name = "MpoIDFrom"
            .Visible = False
        End With

        With Me.MpoIdTO
            .DataPropertyName = "MpoIdTO"
            .Name = "MpoIdTO"
            .Visible = False
        End With

        With Me.MpoPartIDTO
            .DataPropertyName = "MpoPartIDTO"
            .Name = "MpoPartIDTO"
            .Visible = False
        End With

        With Me.MpoToIDrel
            .DataPropertyName = "MpoToID"
            .Name = "MpoToID"
            .Visible = False
        End With

        With Me.MpoFromIDrel
            .DataPropertyName = "MpoFromID"
            .Name = "MpoFromID"
            .Visible = False
        End With

        ' dgStockRez

        PutMpoTO_Res()

        PutMpoBlankID()

        With Me.QtyToEng
            .DataPropertyName = "QtyToEng"
            .Name = "QtyToEng"
        End With

        With Me.QtyOrderRez
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
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

        With Me.PartNo
            .DataPropertyName = "PartNo"
            .Name = "PartNo"
        End With

        With Me.PartDescCodeRez
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
        End With

        With Me.RezNotes
            .DataPropertyName = "RezNotes"
            .Name = "RezNotes"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.ResBlankID
            .DataPropertyName = "ResBlankID"
            .Name = "ResBlankID"
            .Visible = False
        End With

        With Me.MPOBlankFromID
            .DataPropertyName = "MPOBlankFromID"
            .Name = "MPOBlankFromID"
            .ReadOnly = True
        End With

        'dgPartList

        With Me.PartNumberList
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCodeList
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.PNBlanksID
            .DataPropertyName = "PNBlanksID"
            .Name = "PNBlanksID"
            .Visible = False
        End With

    End Sub

    Sub PutMpoTO_Res()

        'show all the MPOs before production
        With Me.MPOToIDRes
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterQtyEngZero").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOID"
            .DataPropertyName = "MPOToIDRes"
            .Name = "MPOToIDRes"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

    End Sub

    Sub PutMpoBlankID()

        With Me.MPOBlankFromID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoMasterBlanksAll").Tables("tblMpoMaster")
            .DisplayMember = "MPONo"
            .ValueMember = "MPOBlankFromID"
            .DataPropertyName = "MPOBlankFromID"
            .Name = "MPOBlankFromID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

    End Sub

    Sub DisableFields()

        txtPartRef.ReadOnly = False
        txtDia.ReadOnly = False
        txtLength.ReadOnly = False
        txtOSCode.ReadOnly = False
        txtNotes.ReadOnly = True

    End Sub

    Sub PutPartRef()
        With Me.CmbPartRef
            .DataSource = CallClass.PopulateComboBox("tblPartReference", "cmbGetPartRefAll").Tables("tblPartReference")
            .DisplayMember = "FullDescr"
            .ValueMember = "PartRefID"
        End With
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getBlanksWithReserved").FillSchema(dsMain, SchemaType.Source, "tblStockBlankReservation")

        CallClass.PopulateDataAdapter("getStFinalBlanksAndMpoWIP").Fill(dsMain, "tblBlanksAndWIP")
        CallClass.PopulateDataAdapter("getMPOReleasedFromBlanks").Fill(dsMain, "tblMpoFromBlank")
        CallClass.PopulateDataAdapter("getPartListFromBlanks").Fill(dsMain, "tblPartsListFromBlanks")

        CallClass.PopulateDataAdapter("getBlanksWithReserved").Fill(dsMain, "tblStockBlankReservation")
        Dim ResId As DataColumn = dsMain.Tables("tblStockBlankReservation").Columns("ResBlankID")
        ResId.AutoIncrement = True
        ResId.AutoIncrementStep = -1
        ResId.AutoIncrementSeed = -1
        ResId.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("StBlank_Reserv", _
              .Tables("tblBlanksAndWIP").Columns("MpoId"), _
                .Tables("tblStockBlankReservation").Columns("MPOBlankFromID"), True)
        End With

        With dsMain
            .Relations.Add("StBlank_Released", _
              .Tables("tblBlanksAndWIP").Columns("MpoId"), _
                .Tables("tblMpoFromBlank").Columns("MpoIDFrom"), True)
        End With

        With dsMain
            .Relations.Add("StBlank_PartList", _
              .Tables("tblBlanksAndWIP").Columns("MpoPartID"), _
                .Tables("tblPartsListFromBlanks").Columns("PNBlanksID"), True)
        End With

    End Sub

    Private Sub CmbPartRef_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPartRef.DropDownClosed

        If IsNothing(CmbPartRef.SelectedItem) = False Then
            txtPartRef.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefIndex"))
            txtDia.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefDia"))
            txtLength.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefLength"))

            If IsDBNull(CmbPartRef.SelectedItem("PartOSCode")) = True Then
                txtOSCode.Text = ""
            Else
                txtOSCode.Text = CmbPartRef.SelectedItem("PartOSCode")
            End If

            If IsDBNull(CmbPartRef.SelectedItem("PartRefNotes")) = True Then
                txtNotes.Text = ""
            Else
                txtNotes.Text = CmbPartRef.SelectedItem("PartRefNotes")
            End If

            txtDia.ReadOnly = False
            txtLength.ReadOnly = False

            SearchData()

        End If

    End Sub

    Sub PutSFStock()

        For I As Integer = 0 To (dgBlank.Rows.Count - 1)
            If RdZero.Checked = False Then
                If Nz.Nz(dgBlank("StQty", I).Value) > 0 Then
                    dgBlank("SwBlankST", I).Value = Nz.Nz(dgBlank("StQty", I).Value)
                Else
                    If Nz.Nz(dgBlank("QtyActual", I).Value) > 0 Then
                        dgBlank("SwBlankST", I).Value = Nz.Nz(dgBlank("QtyActual", I).Value)
                    Else
                        dgBlank("SwBlankST", I).Value = Nz.Nz(dgBlank("QtyOrder", I).Value)
                    End If
                End If
            End If
        Next I

    End Sub

    Private Sub dgBlank_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBlank.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowBlank = e.RowIndex
        End If

        If RdZero.Checked = True And Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefID").Value) = 0 Then

        Else
            CmbPartRef.SelectedValue = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefID").Value)
            txtPartRef.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefIndex").Value)
            txtDia.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefDia").Value)
            txtLength.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefLength").Value)

            If IsDBNull(dgBlank.Rows(RowBlank).Cells("PartOSCode").Value) = True Then
                txtOSCode.Text = ""
            Else
                txtOSCode.Text = dgBlank.Rows(RowBlank).Cells("PartOSCode").Value
            End If

            If IsDBNull(dgBlank.Rows(RowBlank).Cells("PartRefNotes").Value) = True Then
                txtNotes.Text = ""
            Else
                txtNotes.Text = dgBlank.Rows(RowBlank).Cells("PartRefNotes").Value
            End If
        End If

        txtDia.ReadOnly = False
        txtLength.ReadOnly = False

        CalculTotMpoMatl()
        PutValueStRes()

        Dim qRes As Integer
        Dim qFinal As Integer
        Dim qdif As Integer

        qRes = txtBlanksRes.Text
        qFinal = Nz.Nz(dgBlank("SwBlankST", e.RowIndex).Value)
        qdif = qFinal - qRes

        dgBlank("SwBalance", e.RowIndex).Value = qdif

        Select Case e.ColumnIndex
            Case 7
                Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

                Dim rptPO As New rptMFGMethodBarCodeRefOnly
                rptPO.Load("..\rptMFGMethodBarCodeRefOnly.rpt")

                pdvMpoID.Value = Convert.ToInt32(dgBlank.Rows(RowBlank).Cells("MPOID").Value)
                pdvPartID.Value = Convert.ToInt32(dgBlank.Rows(RowBlank).Cells("MpoPartID").Value)
                pvMPOIDCollection.Add(pdvMpoID)
                pvPartIDCollection.Add(pdvPartID)
                rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.ShowDialog()
        End Select

    End Sub

    Private Sub dgBlank_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBlank.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowBlank = e.RowIndex
        End If

        If RdZero.Checked = True And Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefID").Value) = 0 Then
        Else

            CmbPartRef.SelectedValue = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefID").Value)
            txtPartRef.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefIndex").Value)
            txtDia.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefDia").Value)
            txtLength.Text = Nz.Nz(dgBlank.Rows(RowBlank).Cells("PartRefLength").Value)

            If IsDBNull(dgBlank.Rows(RowBlank).Cells("PartOSCode").Value) = True Then
                txtOSCode.Text = ""
            Else
                txtOSCode.Text = dgBlank.Rows(RowBlank).Cells("PartOSCode").Value
            End If

            If IsDBNull(dgBlank.Rows(RowBlank).Cells("PartRefNotes").Value) = True Then
                txtNotes.Text = ""
            Else
                txtNotes.Text = dgBlank.Rows(RowBlank).Cells("PartRefNotes").Value
            End If
        End If
        txtDia.ReadOnly = False
        txtLength.ReadOnly = False

        CalculTotMpoMatl()
        PutValueStRes()

        Dim qRes As Integer
        Dim qFinal As Integer
        Dim qdif As Integer

        qRes = txtBlanksRes.Text
        qFinal = Nz.Nz(dgBlank("SwBlankST", e.RowIndex).Value)
        qdif = qFinal - qRes

        dgBlank("SwBalance", e.RowIndex).Value = qdif

    End Sub

    Private Sub dgBlank_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgBlank.DataError
        REM end
    End Sub

    Private Sub dgBlank_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBlank.Sorted
        PutSFStock()
    End Sub


    Sub CalculTotMpoMatl()

        If RowBlank < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("QtyEngReleased").Value)
        Next
        txtQtyReleased.Text = qty.ToString("N0")

        qty = txtQtyReleased.Text + dgBlank("StQty", RowBlank).Value
        txtTotQty.Text = qty.ToString("N0")

    End Sub

    Sub PutValueStRes()

        If RowBlank < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgStockRes.Rows
            qty = qty + Nz.Nz(Row.Cells("QtyToEng").Value)
        Next
        txtBlanksRes.Text = qty.ToString("N2")

    End Sub

    Private Sub dgStockRes_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgStockRes.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowRes = e.RowIndex
        End If

        If RoleResBlanks(wkDeptCode) = True Then   'reserved blanks
            Select Case e.ColumnIndex  'enable 2,3,5
                Case 0, 1, 4, 6, 7, 8, 9, 10, 11, 12
                    e.Cancel = True
            End Select
        Else
            Select Case e.ColumnIndex
                Case 0 To 12
                    e.Cancel = True
            End Select
        End If

    End Sub

    Private Sub dgStockRes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockRes.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowRes = e.RowIndex
        End If

        OldDept = Nz.Nz(dgStockRes("DeptID", e.RowIndex).Value)

        If RoleRelBlanks(wkDeptCode) = True Then
            Select Case e.ColumnIndex
                Case 0
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Release to Production ?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                    Call ValPo()

                    If SwVal = True Then

                        Try
                            TakeDocumentNo()        'keep number and update in LisiKey
                        Catch ex As Exception
                        End Try

                        Try
                            UpdateAdj()             'release from FP tr 3 adj also update keep number
                        Catch ex As Exception
                        End Try

                        Try
                            CallClass.UpdateMatlStock("cspUpdatetblStockFP")    'update stock FP with tranz
                        Catch ex As Exception
                        End Try

                        Try
                            UpdateQtyActual()   'update Mpo Qty Actual
                        Catch ex As Exception
                        End Try

                        'delete record from stock reservation
                        dgStockRes.Rows.RemoveAt(RowRes)
                        dgStockRes.Refresh()
                        If (dsMain.HasChanges) Then
                            Try
                                UpdateStockResBlanks(dsMain.GetChanges)
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
            End Select
        Else
            MsgBox("Access Denied.")
        End If

    End Sub

    Private Sub dgStockRes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockRes.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowRes = e.RowIndex
        End If

        If RoleResBlanks(wkDeptCode) = True Then
            Select Case e.ColumnIndex

                Case 2      'mpo no  

                    Dim StrSearch As Integer = 0
                    Dim getMpoRes As String = ""
                    'check if the mpo was reserved before in tblStockBlankReservation
                    StrSearch = Nz.Nz(dgStockRes("MPOToIDRes", RowRes).Value)
                    getMpoRes = CallClass.ReturnStrWithParInt("cspReturnMpoBlankStockRes", StrSearch)
                    If Trim(getMpoRes) <> "False" Then
                        MsgBox("!! ERROR MPO# !!! - Action denied. The MPO from Blanks was Reserved before.")
                        dgStockRes("MPOToIDRes", e.RowIndex).Value = DBNull.Value
                        Exit Sub
                    End If

                    'check if MPO was reserved on screen
                    Dim OldMpo As Integer
                    OldMpo = Nz.Nz(dgStockRes("MPOToIDRes", e.RowIndex).Value)
                    Dim II As Integer = 0

                    For Each Row As DataGridViewRow In dgStockRes.Rows
                        If Nz.Nz(Row.Cells("MPOToIDRes").Value) = OldMpo Then
                            If II >= 1 Then
                                Row.Cells("MPOToIDRes").Value = DBNull.Value
                                MsgBox("!!! ERROR MPO# !!! - Action denied.")
                                Exit For
                            End If
                            II = II + 1
                        End If
                    Next

                Case 3  'eng qty blanks

                    dgBlank("SwBalance", RowBlank).Selected = True
                    If Nz.Nz(dgStockRes("QtyToEng", e.RowIndex).Value) > Nz.Nz(dgBlank("SwBalance", RowBlank).Value) Then
                        MsgBox("!!! ERROR !!! - Quantity Blanks Reserved is Greater than Quantity in Stock")
                        dgStockRes("QtyToEng", e.RowIndex).Value = 0
                    End If

                    If Nz.Nz(dgBlank("SwBalance", RowBlank).Value) <= 0 Then
                        MsgBox("!!! ERROR !!! - The Blanks Quantity available in Stock is negative or zero.")
                        dgStockRes("QtyToEng", e.RowIndex).Value = 0
                    End If

                    UpdateQtyReleased()

                Case 9      'dept
                    Dim SwDept As Integer = 0
                    Dim SwProd As String = ""

                    SwDept = Nz.Nz(dgStockRes("DeptID", e.RowIndex).Value)
                    SwProd = CallClass.ReturnStrWithParInt("cspReturnRoleEng", SwDept)
                    If SwProd <> "1" Then
                        MsgBox("Access denied.")
                        dgStockRes("DeptID", RowRes).Value = OldDept
                        Exit Sub
                    End If

                    UpdateMpoDept()
            End Select
        Else
            dgStockRes.ReadOnly = True
        End If

    End Sub

    Private Sub dgStockRes_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgStockRes.DataError
        REM end
    End Sub

    Private Sub dgMpo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMpo.CellBeginEdit
        If RoleRelBlanks(wkDeptCode) = False Then
            Select Case e.ColumnIndex
                Case 0 To 8
                    e.Cancel = True
            End Select
        Else
            Select Case e.ColumnIndex
                Case 0 To 7
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMpo = e.RowIndex

        Select Case e.ColumnIndex
            Case 8
                If RoleRelBlanks(wkDeptCode) = True Then
                    If dgMpo("MpoStatus", e.RowIndex).Value <> "Active" Then
                        MsgBox("Action Denied. MPO No. is not Active.")
                        Exit Sub
                    End If

                    If IsDBNull(dgMpo("DeptNode", e.RowIndex).Value) = True Then
                        MsgBox("Action Denied. Department code is Null")
                        Exit Sub
                    End If

                    Dim SwMPOId As Integer = 0
                    Dim SwRes As String = ""

                    SwMPOId = dgMpo("MpoIdTO", e.RowIndex).Value
                    SwRes = CallClass.ReturnStrWithParInt("cspReturnLastOper", SwMPOId)

                    If Val(Trim(SwRes)) <= 30 Then
                        Dim reply As DialogResult
                        reply = MsgBox("Do you want to Return the Blanks to Inventory ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If

                        ReturnBlanks()
                        UpdateReturnMpoProdQty()
                        UpdateDeleteFromMPOReleasedTo()

                        If (dsMain.HasChanges) Then
                            Try
                                ''''''''''''''''''''''''''''''''''''''''''''

                                'UpdateStockRes(dsMain.GetChanges)
                                dsMain.AcceptChanges()
                            Catch ex As Exception
                                MsgBox("Update failed: " & ex.Message)
                                dsMain.RejectChanges()
                            End Try
                        End If

                        MsgBox("Update successfully.")

                        SearchData()

                        dgBlank.Refresh()
                        dgMpo.Refresh()

                    Else
                        MsgBox("Action Denied. Can not return to inventory the MPO# from production.")
                    End If
                End If
            Case 9
                Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

                Dim rptPO As New rptMFGMethodBarCodeRefOnly
                rptPO.Load("..\rptMFGMethodBarCodeRefOnly.rpt")

                pdvMpoID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MpoIdTO").Value)
                pdvPartID.Value = Convert.ToInt32(dgMpo.Rows(RowMpo).Cells("MpoPartIDTO").Value)
                pvMPOIDCollection.Add(pdvMpoID)
                pvPartIDCollection.Add(pdvPartID)
                rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.ShowDialog()
        End Select

    End Sub

    Sub UpdateMpoDept()

        If IsDBNull(dgStockRes("DeptID", RowRes).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgStockRes("MPOToIDRes", RowRes).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = dgStockRes("DeptID", RowRes).Value
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

    Sub UpdateQtyReleased()

        If IsDBNull(dgStockRes("QtyToEng", RowRes).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleased", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgStockRes("MPOToIDRes", RowRes).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgStockRes("QtyToEng", RowRes).Value
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

    Sub ReturnBlanks()

        'create the adj tranz for return Blanks to Inventory
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzAdjFPWithStLoc", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraFind As SqlParameter = New SqlParameter("@FindRelNo", SqlDbType.NVarChar, 15)
        paraFind.Value = DBNull.Value
        mySqlComm.Parameters.Add(paraFind)

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoIDFrom", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 3
        mySqlComm.Parameters.Add(paraTrOper)

        Dim paraTrStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
        paraTrStatus.Value = "O"
        mySqlComm.Parameters.Add(paraTrStatus)

        Dim paraTypeSt As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
        paraTypeSt.Value = "FP"
        mySqlComm.Parameters.Add(paraTypeSt)

        Dim paraTrDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraTrDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraTrDate)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
        paraQty.Value = dgMpo("QtyEngReleased", RowMpo).Value
        mySqlComm.Parameters.Add(paraQty)

        Dim paraStComm As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 500)
        paraStComm.Value = "Qty Blanks Return to inventory from MPO: " + dgMpo("MpoNoFrom", RowMpo).Value
        mySqlComm.Parameters.Add(paraStComm)

        Dim paraStloc As SqlParameter = New SqlParameter("@StLoc", SqlDbType.NVarChar, 20)
        paraStloc.Value = CallClass.ReturnStrWithParInt("cspReturnStLoc", dgMpo("MpoIDFrom", RowMpo).Value)
        mySqlComm.Parameters.Add(paraStloc)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update SFP Tranz. Adj. Info.: " & ex.Message)
        End Try

        'update stock FP with tranz
        CallClass.UpdateMatlStock("cspUpdatetblStockFP")

    End Sub

    Sub UpdateReturnMpoProdQty()
        ' return to eng dept = 15 code
        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOMasterBlanksReturn", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpoPar As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
            paraMpoPar.Value = dgMpo("MpoIdTO", RowMpo).Value
            mySqlComm.Parameters.Add(paraMpoPar)

            Dim paraMpoWe As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
            paraMpoWe.Value = 0
            mySqlComm.Parameters.Add(paraMpoWe)

            Dim paraMpoAdj As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraMpoAdj.Value = 0
            mySqlComm.Parameters.Add(paraMpoAdj)

            Dim paraEngInfo As SqlParameter = New SqlParameter("@MpoEngInfo", SqlDbType.NVarChar, 100)
            paraEngInfo.Value = ""
            mySqlComm.Parameters.Add(paraEngInfo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = 15
            mySqlComm.Parameters.Add(paraDept)

            Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 2000)
            paraNotes.Value = vbCrLf + "Qty: " + Str(dgMpo("QtyActual", RowMpo).Value) + _
                            " Return From Mpo: " + dgMpo("MpoNoTo", RowMpo).Value + _
                            " To Inventory Mpo: " + dgMpo("MpoNoFrom", RowMpo).Value + " "
            mySqlComm.Parameters.Add(paraNotes)

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

    Sub UpdateDeleteFromMPOReleasedTo()

        ' delete record from tblMpoReleasedto prod 
        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDeletefromMPOReleasedtoProd", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpoFrom As SqlParameter = New SqlParameter("@MpoFromID", SqlDbType.Int, 4)
            paraMpoFrom.Value = dgMpo("MpoFromID", RowMpo).Value
            mySqlComm.Parameters.Add(paraMpoFrom)

            Dim paraMpoTo As SqlParameter = New SqlParameter("@MpoToID", SqlDbType.Int, 4)
            paraMpoTo.Value = dgMpo("MpoToID", RowMpo).Value
            mySqlComm.Parameters.Add(paraMpoTo)

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

    Function RoleRelBlanks(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RELBLANKS" Then
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

    Function RoleResBlanks(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RESBLANKS" Then
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

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Sub ValPo()

        Dim II, JJ As Integer
        JJ = dgStockRes.Rows.Count
        For II = 1 To JJ
            If IsDBNull(dgStockRes.Item("MPOToIDRes", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! MPO Number Release to Production is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsNothing(dgStockRes.Item("MPOToIDRes", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! MPO Number Release to Production is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgStockRes.Item("MPOBlankFromID", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! MPO Number Blank is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsNothing(dgStockRes.Item("MPOBlankFromID", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! MPO Number Blank is Empty.")
                SwVal = False
                Exit Sub
            End If

            If IsDBNull(dgStockRes.Item("QtyToEng", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Quantity Eng. Reserved is Empty.")
                SwVal = False
                Exit Sub
            End If

            If Nz.Nz(dgStockRes.Item("QtyToEng", II - 1).Value) = True Then
                MsgBox("!!! ERROR !!! Quantity Eng. Reserved is Empty.")
                SwVal = False
                Exit Sub
            End If
        Next

        If Val(txtBlanksRes.Text) > dgBlank("SwBlankST", RowBlank).Value Then
            MsgBox("!!! ERROR !!! Reserved Qty > Qty Available.")
            SwVal = False
            Exit Sub
        End If


        SwVal = True

    End Sub

    Sub TakeDocumentNo()

        Dim SwNo As String = ""

        SwNo = CallClass.GenerateNextLot("cspGetNextLot", "RELFROMFPTOPROD")
        If SwNo = "ERROR" Then
            KeepNo = 0
        Else
            KeepNo = Val(SwNo)
            CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "RELFROMFPTOPROD", KeepNo)
        End If

    End Sub

    Sub UpdateAdj()

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRelTranzCorrectionFromFPMpoProd", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
        paraMpo.Value = Nz.Nz(dgStockRes("MPOBlankFromID", RowRes).Value)
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraTrOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
        paraTrOper.Value = 3
        mySqlComm.Parameters.Add(paraTrOper)

        Dim paraTrStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
        paraTrStatus.Value = "O"
        mySqlComm.Parameters.Add(paraTrStatus)

        Dim paraTypeSt As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
        paraTypeSt.Value = "FP"
        mySqlComm.Parameters.Add(paraTypeSt)

        Dim paraTrDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
        paraTrDate.Value = Now.ToShortDateString
        mySqlComm.Parameters.Add(paraTrDate)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
        paraQty.Value = Nz.Nz(dgStockRes("QtyToEng", RowRes).Value)
        mySqlComm.Parameters.Add(paraQty)

        Dim paraLoc As SqlParameter = New SqlParameter("@StLoc", SqlDbType.NVarChar, 20)
        paraLoc.Value = Nz.Nz(dgStockRes("StockLoc", RowRes).Value)
        mySqlComm.Parameters.Add(paraLoc)

        Dim paraNotes As SqlParameter = New SqlParameter("@StComm", SqlDbType.NVarChar, 1000)
        paraNotes.Value = vbCrLf + Nz.Nz(dgStockRes("StNotes", RowRes).Value) + vbCrLf + _
                "Qty: " + Nz.Nz(dgStockRes("QtyToEng", RowRes).Value) + " Released From FP Mpo: " + Nz.Nz(dgBlank("MpoNo", RowBlank).Value) + _
                    " To Production Mpo: " + Nz.Nz(dgStockRes("MpoNo", RowRes).Value)
        mySqlComm.Parameters.Add(paraNotes)

        Dim paraKeep As SqlParameter = New SqlParameter("@MPOKeepNo", SqlDbType.Int, 4)
        paraKeep.Value = KeepNo
        mySqlComm.Parameters.Add(paraKeep)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update FP Tranz. Adj. Info.: " & ex.Message)
        End Try

    End Sub

    Sub UpdateQtyActual()

        'create the adj tranz
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyActualFromFPAdj", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
        paraMpo.Value = Nz.Nz(dgStockRes("MPOToID", RowRes).Value)
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
        paraQty.Value = Nz.Nz(dgStockRes("QtyToEng", RowRes).Value)
        mySqlComm.Parameters.Add(paraQty)

        'Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 1000)
        'paraNotes.Value = vbCrLf + Trim(txtStockNotes.Text)
        'mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Mpo Qty Actual: " & ex.Message)
        End Try

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        SearchData()

    End Sub

    Sub SearchData()

        Dim Par1 As String = ""
        Dim Par2 As String = ""
        Dim Par3 As String = ""
        Dim Par4 As String = ""

        Par1 = Trim(txtPartRef.Text)
        Par2 = Trim(txtDia.Text)
        Par3 = Trim(txtLength.Text)
        Par4 = Trim(txtOSCode.Text)

        dsMain.Tables("tblBlanksAndWIP").Clear()
        dsMain.Tables("tblMpoFromBlank").Clear()

        CallClass.PopulateDataAdapter("getMPOReleasedFromBlanks").Fill(dsMain, "tblMpoFromBlank")

        If RdPlus.Checked = True Then
            CallClass.PopulateDataAdapterSearch4Param("getStFinalBlanksAndMpoWIPAfterSearchNotZero", Par1, Par2, Par3, Par4).Fill(dsMain, "tblBlanksAndWIP")
        Else
            If RdZero.Checked = True Then
                CallClass.PopulateDataAdapterSearch4Param("getStFinalBlanksAndMpoWIPAfterSearchEqualZero", Par1, Par2, Par3, Par4).Fill(dsMain, "tblBlanksAndWIP")
            Else
                MsgBox("!!! ERROR !!! Can not identify the selection mode.")
            End If
        End If

        dgBlank.AutoGenerateColumns = False
        dgBlank.DataSource = dsMain
        dgBlank.DataMember = "tblBlanksAndWIP"

        PutSFStock()

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblBlanksAndWIP.StBlank_Released"

        dgStockRes.AutoGenerateColumns = False
        dgStockRes.DataSource = dsMain
        dgStockRes.DataMember = "tblBlanksAndWIP.StBlank_Reserv"

        dgPartList.AutoGenerateColumns = False
        dgPartList.DataSource = dsMain
        dgPartList.DataMember = "tblBlanksAndWIP.StBlank_PartList"

    End Sub

    Private Sub txtLength_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLength.GotFocus
        dsMain.Tables("tblBlanksAndWIP").Clear()
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

        SetupForm()

        txtPartRef.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefIndex"))
        txtDia.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefDia"))
        txtLength.Text = Nz.Nz(CmbPartRef.SelectedItem("PartRefLength"))

        If IsDBNull(CmbPartRef.SelectedItem("PartOSCode")) = True Then
            txtOSCode.Text = ""
        Else
            txtOSCode.Text = CmbPartRef.SelectedItem("PartOSCode")
        End If

        If IsDBNull(CmbPartRef.SelectedItem("PartRefNotes")) = True Then
            txtNotes.Text = ""
        Else
            txtNotes.Text = CmbPartRef.SelectedItem("PartRefNotes")
        End If

        txtDia.ReadOnly = False
        txtLength.ReadOnly = False

    End Sub

    Private Sub RdPlus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdPlus.CheckedChanged
        SearchData()
    End Sub

    Private Sub RdZero_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdZero.CheckedChanged
        SearchData()
    End Sub

    Private Sub dgStockRes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStockRes.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RoleResBlanks(wkDeptCode) = False Then          'eng rights to reserve and delete
                If MessageBox.Show("Access Denied", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning, _
            MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Public Sub UpdateStockResBlanks(ByVal dsChanges As DataSet)

        Dim cmdIns As SqlCommand
        Dim cmdUpd As SqlCommand
        Dim cmdDel As SqlCommand

        Dim da As SqlDataAdapter

        'insert
        cmdIns = New SqlCommand()
        cmdIns.Connection = cn
        cmdIns.CommandType = CommandType.StoredProcedure
        cmdIns.CommandText = "cspStockResBlanksInsert"

        cmdIns.Parameters.Add("@ResBlankID", SqlDbType.Int, 4, "ResBlankID")

        cmdIns.Parameters.Add("@MPOBlankFromID", SqlDbType.Int, 4, "MPOBlankFromID")
        cmdIns.Parameters.Add("@MPOToID", SqlDbType.Int, 4, "MPOToID")
        cmdIns.Parameters.Add("@QtyToEng", SqlDbType.Int, 4, "QtyToEng")
        cmdIns.Parameters.Add("@RezNotes", SqlDbType.NVarChar, 200, "RezNotes")

        'update
        cmdUpd = New SqlCommand()
        cmdUpd.Connection = cn
        cmdUpd.CommandType = CommandType.StoredProcedure
        cmdUpd.CommandText = "cspStockResBlanksUpdate"

        cmdUpd.Parameters.Add("@ResBlankID", SqlDbType.Int, 4, "ResBlankID")
        cmdUpd.Parameters.Add("@MPOBlankFromID", SqlDbType.Int, 4, "MPOBlankFromID")
        cmdUpd.Parameters.Add("@MPOToID", SqlDbType.Int, 4, "MPOToID")
        cmdUpd.Parameters.Add("@QtyToEng", SqlDbType.Int, 4, "QtyToEng")
        cmdUpd.Parameters.Add("@RezNotes", SqlDbType.NVarChar, 200, "RezNotes")

        'delete
        cmdDel = New SqlCommand()
        cmdDel.Connection = cn
        cmdDel.CommandType = CommandType.StoredProcedure
        cmdDel.CommandText = "cspStockResBlanksDelete"

        cmdDel.Parameters.Add("@ResBlankID", SqlDbType.Int, 4, "ResBlankID")

        'DataApapter
        da = New SqlDataAdapter()

        da.DeleteCommand = cmdDel
        da.InsertCommand = cmdIns
        da.UpdateCommand = cmdUpd

        da.TableMappings.Add("Table", "tblStockBlankReservation")

        da.Update(dsChanges)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Dim rptPO As New rptPartRefListWithBlanks
        rptPO.Load("..\rptPartRefListWithBlanks.rpt")
        frmPOPrintAll.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOPrintAll.CrystalReportViewer1.ReportSource = rptPO
        frmPOPrintAll.CrystalReportViewer1.Zoom(2)
        frmPOPrintAll.CrystalReportViewer1.ShowRefreshButton = True
        frmPOPrintAll.CrystalReportViewer1.ShowPrintButton = True
        frmPOPrintAll.CrystalReportViewer1.ShowExportButton = True
        frmPOPrintAll.ShowDialog()
    End Sub
End Class