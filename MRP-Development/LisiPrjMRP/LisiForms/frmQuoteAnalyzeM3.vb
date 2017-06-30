Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmQuoteAnalyzeM3

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowQt As Integer = 0       'dgQuote row.

    Private dsMain As New DataSet

    Private Sub frmQuoteAnalyzeM3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmQuoteAnalyzeM3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()

        InitButtons()

        InitialComponents()

        PutCustomer()
        SetCtlForm()

        ClearFields()

        RdAll.Checked = True

    End Sub

    Sub ClearFields()

        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtPart.Text = ""
        txtQuote.Text = ""
        txtDueDate.Text = ""
        CmbItemStatus.Text = ""

        CmbSelCust.SelectedIndex = -1

    End Sub

    Sub InitButtons()
        RdAll.Checked = True
        RdFollowup.Checked = False
        RdNoBid.Checked = False
    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getQuoteSelectionEmpty").Fill(dsMain, "tblQuote")
        CallClass.PopulateDataAdapter("getOrderSelectionEmpty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefEmpty").Fill(dsMain, "tmpPartMatlPref")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgSel.AutoGenerateColumns = False
        dgSel.DataSource = dsMain
        dgSel.DataMember = "tblSelect"

        dgQuote.AutoGenerateColumns = False
        dgQuote.DataSource = dsMain
        dgQuote.DataMember = "tblQuote"

        dgMatlPref.AutoGenerateColumns = False
        dgMatlPref.DataSource = dsMain
        dgMatlPref.DataMember = "tmpPartMatlPref"

    End Sub

    Sub PutCustomer()

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub SetCtlForm()

        ' dgSel
        With Me.CustomerShortForecast
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.QtyToShip
            .DataPropertyName = "QtyToShip"
            .Name = "QtyToShip"
        End With

        With Me.CalcStock
            .DataPropertyName = "CalcStock"
            .Name = "CalcStock"
        End With

        With Me.DeptMPO
            .DataPropertyName = "DeptMPO"
            .Name = "DeptMPO"
        End With

        With Me.DeptPer
            .DataPropertyName = "DeptPer"
            .Name = "DeptPer"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.SwOrder
            .DataPropertyName = "SwOrder"
            .Name = "SwOrder"
            .Visible = False
        End With


        'dgQuote

        With Me.QNo
            .DataPropertyName = "QNo"
            .Name = "QNo"
        End With

        With Me.QDate
            .DataPropertyName = "QDate"
            .Name = "QDate"
        End With

        With Me.ContactName
            .DataPropertyName = "ContactName"
            .Name = "ContactName"
        End With

        With Me.QCustRefNo
            .DataPropertyName = "QCustRefNo"
            .Name = "QCustRefNo"
        End With

        With Me.QDetLine
            .DataPropertyName = "QDetLine"
            .Name = "QDetLine"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QQty
            .DataPropertyName = "QQty"
            .Name = "QQty"
        End With

        With Me.QQuotedPrice
            .DataPropertyName = "QQuotedPrice"
            .Name = "QQuotedPrice"
        End With

        With Me.QLeadTime
            .DataPropertyName = "QLeadTime"
            .Name = "QLeadTime"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
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

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        Me.Cursor = Cursors.WaitCursor

        Dim Par1 As String = ""
        Dim Par2 As String = ""
        Dim Par3 As String = ""
        Dim Par4 As String = ""
        Dim Par5 As String = ""
        Dim Par6 As String = ""
        Dim Par7 As String = ""

        If Len(Trim(txtDateFrom.Text)) = 0 Then
            Par1 = "01/01/2003"
        Else
            Par1 = txtDateFrom.Text
        End If

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par2 = Now.ToShortDateString
        Else
            Par2 = txtDateTo.Text
        End If

        Par3 = txtPart.Text

        If IsNothing(CmbSelCust.SelectedValue) = True Then
            Par4 = 0
        Else
            Par4 = CmbSelCust.SelectedValue
        End If

        Par5 = txtQuote.Text

        If Len(Trim(txtDueDate.Text)) = 0 Then
            Par6 = DateAdd(DateInterval.Day, 300, Date.Now).ToShortDateString
        Else
            Par6 = txtDueDate.Text
        End If

        If Len(Trim(CmbItemStatus.Text)) = 0 Then
            Par7 = ""
        Else
            Par7 = CmbItemStatus.Text
        End If

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Me.Refresh()

        If RdAll.Checked = True Then
            CallClass.PopulateDataAdapterSearch7Param("getQuoteSelectionRdAll", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblQuote")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If RdFollowup.Checked = True Then
            CallClass.PopulateDataAdapterSearch7Param("getQuoteSelectionRdFollowUp", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblQuote")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        'If RdNoPrice.Checked = True Then
        '    CallClass.PopulateDataAdapterSearch5Param("getQuoteSelectionRdNoPrice", Par1, Par2, Par3, Par4, Par5).Fill(dsMain, "tblQuote")
        '    Exit Sub
        'End If

        If RdNoBid.Checked = True Then
            CallClass.PopulateDataAdapterSearch7Param("getQuoteSelectionRdAllNOBID", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblQuote")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        If dgQuote.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        Try
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

            For iC = 0 To dgQuote.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgQuote.Columns(iC).HeaderText
                'wsheet.Cells(1, iC + 1).font.bold = True
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgQuote.Rows.Count - 1
                For iY = 0 To dgQuote.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgQuote(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

    End Sub

    Private Sub dgQuote_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgQuote.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgQuote_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQuote.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowQt = e.RowIndex

        dsMain.Tables("tmpPartMatlPref").Clear()
        dsMain.Tables("tblSelect").Clear()


        Dim StrSearch As String = ""
        Dim SwQty As String = ""

        StrSearch = Nz.Nz(dgQuote("PartNumber", RowQt).Value)

        CallClass.PopulateDataAdapterAfterSearch("getSalesPlanningFPOrdersActive", StrSearch).Fill(dsMain, "tblSelect")

        CallClass.PopulateDataAdapterAfterSearch("getSalesPlanningFPRawMatlPrefByPartNo", StrSearch).Fill(dsMain, "tmpPartMatlPref")

        SwQty = CallClass.TakeFinalSt("cspReturnStockFPByPartNo", StrSearch)
        If SwQty = "False" Then
            txtFPStock.Text = 0
        Else
            txtFPStock.Text = SwQty
        End If

        PutGridCalcul()

    End Sub

    Sub PutGridCalcul()
        If dgSel.Rows.Count > 0 Then
            For I As Integer = 0 To (dgSel.Rows.Count - 1)
                If I = 0 Then
                    dgSel("CalcStock", I).Value = Val(txtFPStock.Text) + Nz.Nz(dgSel("QtyToShip", I).Value)
                Else
                    dgSel("CalcStock", I).Value = Nz.Nz(dgSel("QtyToShip", I).Value) + Nz.Nz(dgSel("CalcStock", I - 1).Value)
                End If
            Next I
        End If

    End Sub

    Private Sub dgQuote_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgQuote.DataError
        REM end
    End Sub

    Private Sub CmdRmAnalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRmAnalize.Click
        frmRawMaterialAnalyze.Show()
    End Sub

    Private Sub CmdShowRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdShowRM.Click
        frmReleaseRawMaterial.Show()
    End Sub

End Class