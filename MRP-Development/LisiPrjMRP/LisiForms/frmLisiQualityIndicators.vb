Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmLisiQualityIndicators

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowQA As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet

    Private Sub frmLACQualityIndicators_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmLACQualityIndicators_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetupForm()
        RdDeff.Checked = True
        RdSupp.Checked = False

    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getLisiQAIndicatorsEmpty").Fill(dsMain, "tblSelect")

        CallClass.PopulateDataAdapter("getLisiQAIndQtyProducedEmpty").Fill(dsMain, "tblSelectPcsProd")

        CallClass.PopulateDataAdapter("getLisiQAIndicatorsMPOInfosEmpty").Fill(dsMain, "tblSelectMPO")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgQA.AutoGenerateColumns = False
        dgQA.DataSource = dsMain
        dgQA.DataMember = "tblSelect"

        dgProd.AutoGenerateColumns = False
        dgProd.DataSource = dsMain
        dgProd.DataMember = "tblSelectPcsProd"

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelectMPO"

    End Sub

    Sub SetCtlForm()

        With Me.CmbDwgSource
            .DataSource = CallClass.PopulateComboBox("tblPartDWGSource", "gettblPartDwgSource").Tables("tblPartDWGSource")
            .DisplayMember = "SourceName"
            .ValueMember = "DwgSourceID"
        End With

        With Me.CmdSeeMemo
            .DataPropertyName = "CmdSeeMemo"
            .Name = "CmdSeeMemo"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.InternalQuality
            .DataPropertyName = "InternalQuality"
            .Name = "InternalQuality"
        End With

        With Me.InternalMfg
            .DataPropertyName = "InternalMfg"
            .Name = "InternalMfg"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.CustomerName
            .DataPropertyName = "CustomerName"
            .Name = "CustomerName"
        End With

        With Me.CreatedDate
            .DataPropertyName = "CreatedDate"
            .Name = "CreatedDate"
        End With

        With Me.SwDescrProblem
            .DataPropertyName = "SwDescrProblem"
            .Name = "SwDescrProblem"
        End With

        With Me.MemoNo
            .DataPropertyName = "MemoNo"
            .Name = "MemoNo"
        End With

        With Me.MemoStatus
            .DataPropertyName = "MemoStatus"
            .Name = "MemoStatus"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.MemoQtyRwk
            .DataPropertyName = "MemoQtyRwk"
            .Name = "MemoQtyRwk"
        End With

        With Me.MemoQtyScrap
            .DataPropertyName = "MemoQtyScrap"
            .Name = "MemoQtyScrap"
        End With

        With Me.MemoQtySort
            .DataPropertyName = "MemoQtySort"
            .Name = "MemoQtySort"
        End With

        With Me.SwCostPerPcs
            .DataPropertyName = "SwCostPerPcs"
            .Name = "SwCostPerPcs"
        End With

        With Me.SwManHrs
            .DataPropertyName = "SwManHrs"
            .Name = "SwManHrs"
        End With

        With Me.SwCostScrapPcs
            .DataPropertyName = "SwCostScrapPcs"
            .Name = "SwCostScrapPcs"
        End With

        With Me.MemoNotes
            .DataPropertyName = "MemoNotes"
            .Name = "MemoNotes"
        End With

        With Me.ItemNo
            .DataPropertyName = "ItemNo"
            .Name = "ItemNo"
        End With

        With Me.Requirement
            .DataPropertyName = "Requirement"
            .Name = "Requirement"
        End With

        With Me.Codes
            .DataPropertyName = "Codes"
            .Name = "Codes"
        End With

        With Me.MemoID
            .DataPropertyName = "MemoID"
            .Name = "MemoID"
            .Visible = False
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
            .Visible = False
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
            .Visible = False
        End With

        'dgprod

        With Me.SelYear
            .DataPropertyName = "SelYear"
            .Name = "SelYear"
        End With

        With Me.SelMonth
            .DataPropertyName = "SelMonth"
            .Name = "SelMonth"
        End With

        With Me.SelQty
            .DataPropertyName = "SelQty"
            .Name = "SelQty"
        End With

        With Me.SelBatch
            .DataPropertyName = "SelBatch"
            .Name = "SelBatch"
        End With

        'dgMPO

        With Me.SwMpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.RMAIRText
            .DataPropertyName = "RMAIRText"
            .Name = "RMAIRText"
        End With

        With Me.RMAIRNo
            .DataPropertyName = "RMAIRNo"
            .Name = "RMAIRNo"
        End With

        With Me.DateSelection
            .DataPropertyName = "DateSelection"
            .Name = "DateSelection"
        End With

        With Me.SwPartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.SwMpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.SwMpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtLotsScrapped.Text = ""
        txtMPORwk.Text = ""
        txtRMA.Text = ""
        txtIR.Text = ""
        txtBefore.Text = ""
        txtIn.Text = ""

        txtRwk.Text = ""
        txtScrap.Text = ""
        txtQtySort.Text = ""
        txtHr.Text = ""
        txtValue.Text = ""

        ChkDwg.Checked = False
        CmbDwgSource.Enabled = False

    End Sub


    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        Me.Cursor = Cursors.WaitCursor

        Dim Par1, Par2, Par3 As String

        If Len(Trim(txtDateFrom.Text)) = 0 Then
            Par1 = "01/01/2005"
            txtDateFrom.Text = Par1
        Else
            Par1 = txtDateFrom.Text
        End If

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par2 = DateAdd(DateInterval.Day, 1000, Date.Now).ToShortDateString()
            txtDateTo.Text = Par2
        Else
            Par2 = txtDateTo.Text
        End If

        If ChkDwg.Checked = True Then
            If Len(Trim(CmbDwgSource.Text)) > 0 Then
                Par3 = CmbDwgSource.Text
            Else
                Par3 = ""
                MsgBox("!!! ERROR !!!  Designer field is Empty.")
            End If
        Else
            Par3 = ""
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()


        CallClass.PopulateDataAdapterSearch3Param("getLisiQAIndicators", Par1, Par2, Par3).Fill(dsMain, "tblSelect")
        TakeExtraInfo()
        CalculCostValue()
        CalculValue()


        '========================================================

        txtMPORwk.Text = ""
        txtMPORwk.Text = CallClass.ReturnStrWith3ParStr("cspReturnMpoTotalRwkOnSelectedPeriod", Par1, Par2, Par3)

        txtLotsScrapped.Text = ""
        txtLotsScrapped.Text = CallClass.ReturnStrWith3ParStr("cspReturnMPOScrappedOnSelectedPeriod", Par1, Par2, Par3)

        txtRMA.Text = ""
        txtRMA.Text = CallClass.ReturnStrWith4ParStr("cspReturnMpoRMAOnSelectedPeriod", Par1, Par2, Par3, "RMA")

        txtIR.Text = ""
        txtIR.Text = CallClass.ReturnStrWith4ParStr("cspReturnMpoRMAOnSelectedPeriod", Par1, Par2, Par3, "IR")

        txtBefore.Text = ""
        txtBefore.Text = CallClass.ReturnStrWith3ParStr("cspReturnMpoSalesCancelledBefore", Par1, Par2, Par3)

        txtIn.Text = ""
        txtIn.Text = CallClass.ReturnStrWith3ParStr("cspReturnMpoSalesCancelledIN", Par1, Par2, Par3)

        CallClass.PopulateDataAdapterSearch3Param("getLisiQAIndQtyProduced", Par1, Par2, Par3).Fill(dsMain, "tblSelectPcsProd")

        CallClass.PopulateDataAdapterSearch3Param("getLisiQAIndicatorsMPOInfos", Par1, Par2, Par3).Fill(dsMain, "tblSelectMpo")

        Me.Cursor = Cursors.Default

    End Sub

    Sub TakeExtraInfo()

        Dim SwText As String = ""
        Dim TakeCost As String = ""
        Dim TakeRwk As String = ""

        For Each Row As DataGridViewRow In dgQA.Rows
            SwText = ""
            SwText = CallClass.ReturnInfoWithParString("cspReturnActualCondition", Nz.Nz(Row.Cells("MemoNo").Value))
            If SwText = "False" Then
                SwText = ""
            End If
            Row.Cells("SwDescrProblem").Value = SwText

            TakeCost = ""
            TakeCost = CallClass.TakeFinalSt("cspReturnMEMOMpoRevCost", Nz.Nz(Row.Cells("MemoId").Value))
            If TakeCost = "False" Then
                Row.Cells("SwCostPerPcs").Value = DBNull.Value
            Else
                Row.Cells("SwCostPerPcs").Value = Val(TakeCost).ToString("C2")
            End If

            TakeRwk = ""
            TakeRwk = CallClass.ReturnStrWithParInt("cspReturnMEMORwkHours", Nz.Nz(Row.Cells("MemoId").Value))
            If TakeRwk = "False" Then
                Row.Cells("SwManHrs").Value = DBNull.Value
            Else
                Row.Cells("SwManHrs").Value = TakeRwk
            End If

        Next

    End Sub

    Sub CalculCostValue()

        For Each Row As DataGridViewRow In dgQA.Rows
            Row.Cells("SwCostScrapPcs").Value = Nz.Nz(Row.Cells("MemoQtyScrap").Value) * Nz.Nz(Row.Cells("SwCostPerPcs").Value)
        Next

    End Sub

    Sub CalculValue()

        Dim qtyrwk As Integer = 0
        Dim qtyscrap As Integer = 0
        Dim qtyhr As Integer = 0
        Dim qtyvalue As Double = 0.0
        Dim qtySort As Integer = .0

        For Each Row As DataGridViewRow In dgQA.Rows
            qtyrwk = qtyrwk + Nz.Nz(Row.Cells("MemoQtyRwk").Value)
            qtyscrap = qtyscrap + Nz.Nz(Row.Cells("MemoQtyScrap").Value)
            qtyhr = qtyhr + Nz.Nz(Row.Cells("SwManHrs").Value)
            qtyvalue = qtyvalue + Nz.Nz(Row.Cells("SwCostScrapPcs").Value)
            qtySort = qtySort + Nz.Nz(Row.Cells("MemoQtySort").Value)
        Next

        txtRwk.Text = qtyrwk.ToString("N0")
        txtRwk.ReadOnly = True

        txtScrap.Text = qtyscrap.ToString("N0")
        txtScrap.ReadOnly = True

        txtQtySort.Text = qtySort.ToString("N0")
        txtQtySort.ReadOnly = True

        txtHr.Text = qtyhr.ToString("N0")
        txtHr.ReadOnly = True

        txtValue.Text = qtyvalue.ToString("C2")
        txtValue.ReadOnly = True

    End Sub

    Private Sub dgQA_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgQA.CellBeginEdit
        If e.RowIndex < 0 Then
            Return
        Else
            RowQA = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0 To 18
                e.Cancel = True
            Case 20 To 22
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgQA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQA.CellClick
        Select Case e.ColumnIndex

            Case 0
                Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim rptPO As New rptLisiMemo()
                rptPO.ReportOptions.EnableSaveDataWithReport = False

                If IsDBNull(dgQA("MemoNo", e.RowIndex).Value) = True Then
                    Exit Sub
                End If

                Dim FindMemo As String = ""
                FindMemo = Nz.Nz(dgQA("MemoNo", e.RowIndex).Value)
                If Len(Trim(FindMemo)) = 0 Then
                    Exit Sub
                End If

                Try
                    rptPO.Load("..\rptLisiMemo.rpt")
                    pdvCustomerName.Value = FindMemo
                    pvCollection.Add(pdvCustomerName)
                    rptPO.DataDefinition.ParameterFields("@FindMemo").ApplyCurrentValues(pvCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
                    frmPOMasterPrint.ShowDialog()
                Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                    MsgBox("Incorrect path for loading report.", _
                            MsgBoxStyle.Critical, "Load Report Error")
                Catch Exp As Exception
                    MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
                End Try

            Case 1

                frmLisiMemoApp.SwFrom.Text = "QAINSP"
                frmLisiMemoApp.SwValue.Text = Me.dgQA("MemoID", e.RowIndex).Value
                frmLisiMemoApp.ShowDialog()

        End Select

    End Sub

    Private Sub dgQA_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQA.CellEndEdit
        If e.RowIndex < 0 Then
            Return
        Else
            RowQA = e.RowIndex
        End If

        Select Case e.ColumnIndex

            Case 19
                UpdateMemoNotes()
        End Select
    End Sub

    Private Sub dgQA_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQA.CellEnter
        If e.RowIndex < 0 Then
            Return
        Else
            RowQA = e.RowIndex
        End If
    End Sub

    Private Sub dgQA_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgQA.DataError
        REM end
    End Sub

    Private Sub dgQA_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgQA.Sorted

        TakeExtraInfo()
        CalculCostValue()
        CalculValue()

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        Me.Cursor = Cursors.WaitCursor

        If dgQA.Rows.Count <= 0 Then
            MsgBox("Nothing to Export in Excel.")
            Exit Sub
        End If

        Try
            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

            Dim wapp As Excel.Application
            Dim wsheet As Excel.Worksheet
            Dim wbook As Excel.Workbook
            wapp = New Excel.Application

            wapp.Visible = True
            wbook = wapp.Workbooks.Add()
            wsheet = wbook.ActiveSheet

            Dim iX As Integer
            Dim iY As Integer
            Dim iC As Integer

            For iC = 1 To dgQA.Columns.Count - 4
                wsheet.Cells(1, iC + 1).Value = dgQA.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgQA.Rows.Count - 1
                For iY = 1 To dgQA.Columns.Count - 4
                    wsheet.Cells(iX + 2, iY + 1).value = dgQA(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True
        Catch ex As Exception
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub UpdateMemoNotes()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMemoNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@MemoID", SqlDbType.Int, 4)
        paraID.Value = dgQA("MemoID", RowQA).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraDate As SqlParameter = New SqlParameter("@MemoNotes", SqlDbType.NVarChar, 200)
        paraDate.Value = dgQA("MemoNotes", RowQA).Value
        mySqlComm.Parameters.Add(paraDate)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Memo Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub CmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReport.Click

        If Len(Trim(txtDateFrom.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Date From.")
            Exit Sub
        End If

        If Len(Trim(txtDateTo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Date To.")
            Exit Sub
        End If

        If RdDeff.Checked = True Then
            Dim pvDateFromCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvDateToCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvDateFrom As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdvDateTo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptQAIndicators
            rptPO.Load("..\rptQAIndicators.rpt")
            pdvDateFrom.Value = txtDateFrom.Text
            pdvDateTo.Value = txtDateTo.Text

            pvDateFromCollection.Add(pdvDateFrom)
            pvDateToCollection.Add(pdvDateTo)
            rptPO.DataDefinition.ParameterFields("@SwDateFrom").ApplyCurrentValues(pvDateFromCollection)
            rptPO.DataDefinition.ParameterFields("@SwDateTo").ApplyCurrentValues(pvDateToCollection)

            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
            frmPOMasterPrint.ShowDialog()

            Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()
        End If

        If RdSupp.Checked = True Then
            Dim pvDateFromCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvDateToCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvDateFrom As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdvDateTo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptQAIndSuppliers
            rptPO.Load("..\rptQAIndSuppliers.rpt")
            pdvDateFrom.Value = txtDateFrom.Text
            pdvDateTo.Value = txtDateTo.Text

            pvDateFromCollection.Add(pdvDateFrom)
            pvDateToCollection.Add(pdvDateTo)
            rptPO.DataDefinition.ParameterFields("@SwDateFrom").ApplyCurrentValues(pvDateFromCollection)
            rptPO.DataDefinition.ParameterFields("@SwDateTo").ApplyCurrentValues(pvDateToCollection)

            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
            frmPOMasterPrint.ShowDialog()

            Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()
        End If

        If RdDept.Checked = True Then
            Dim pvDateFromCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvDateToCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvDateFrom As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdvDateTo As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptQAIndDepartments
            rptPO.Load("..\rptQAIndDepartments.rpt")
            pdvDateFrom.Value = txtDateFrom.Text
            pdvDateTo.Value = txtDateTo.Text

            pvDateFromCollection.Add(pdvDateFrom)
            pvDateToCollection.Add(pdvDateTo)
            rptPO.DataDefinition.ParameterFields("@SwDateFrom").ApplyCurrentValues(pvDateFromCollection)
            rptPO.DataDefinition.ParameterFields("@SwDateTo").ApplyCurrentValues(pvDateToCollection)

            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree
            frmPOMasterPrint.ShowDialog()

            Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()
        End If

    End Sub

    Private Sub ChkDwg_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDwg.CheckStateChanged
        If ChkDwg.Checked = True Then
            CmbDwgSource.Enabled = True
        Else
            CmbDwgSource.Enabled = False
            CmbDwgSource.SelectedIndex = -1
        End If

        txtLotsScrapped.Text = ""
        txtMPORwk.Text = ""
        txtRMA.Text = ""
        txtIR.Text = ""
        txtBefore.Text = ""
        txtIn.Text = ""

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()
    End Sub
End Class