Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmStQuoteAnalyze

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowQt As Integer = 0       'dgQuote row.

    Private dsMain As New DataSet

    Private Sub frmStQuoteAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmStQuoteAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()

        InitButtons()

        InitialComponents()

        PutCustomer()
        SetCtlForm()

        ClearFields()

        CalculMpoValue()

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

        CallClass.PopulateDataAdapter("getStQuoteSelectionEmpty").Fill(dsMain, "tblStQuote")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgQuote.AutoGenerateColumns = False
        dgQuote.DataSource = dsMain
        dgQuote.DataMember = "tblStQuote"

    End Sub

    Sub PutCustomer()

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblStCustomers", "cmbGetStCustomer").Tables("tblStCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub SetCtlForm()

        'dgQuote

        With Me.QNo
            .DataPropertyName = "QNo"
            .Name = "QNo"
        End With

        With Me.QDate
            .DataPropertyName = "QDate"
            .Name = "QDate"
        End With

        With Me.QFollow
            .DataPropertyName = "QFollow"
            .Name = "QFollow"
        End With

        With Me.QDueDate
            .DataPropertyName = "QDueDate"
            .Name = "QDueDate"
        End With

        With Me.QContract
            .DataPropertyName = "QContract"
            .Name = "QContract"
        End With

        With Me.QQtyContract
            .DataPropertyName = "QQtyContract"
            .Name = "QQtyContract"
        End With

        With Me.ContactName
            .DataPropertyName = "ContactName"
            .Name = "ContactName"
        End With

        With Me.QCustRefNo
            .DataPropertyName = "QCustRefNo"
            .Name = "QCustRefNo"
        End With

        With Me.EmpName
            .DataPropertyName = "EmpName"
            .Name = "EmpName"
        End With

        With Me.QDevise
            .DataPropertyName = "QDevise"
            .Name = "QDevise"
        End With

        With Me.QDetLine
            .DataPropertyName = "QDetLine"
            .Name = "QDetLine"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.DocNo
            .DataPropertyName = "DocNo"
            .Name = "DocNo"
        End With

        With Me.SourceName
            .DataPropertyName = "SourceName"
            .Name = "SourceName"
        End With

        With Me.QPartName
            .DataPropertyName = "QPartName"
            .Name = "QPartName"
        End With

        With Me.QRev
            .DataPropertyName = "QRev"
            .Name = "QRev"
        End With

        With Me.QLineStatus
            .DataPropertyName = "QLineStatus"
            .Name = "QLineStatus"
        End With

        With Me.QQty
            .DataPropertyName = "QQty"
            .Name = "QQty"
        End With

        With Me.QContractSw
            .DataPropertyName = "QContractSw"
            .Name = "QContractSw"
        End With

        With Me.QQuotedPrice
            .DataPropertyName = "QQuotedPrice"
            .Name = "QQuotedPrice"
        End With

        With Me.QEstPrice
            .DataPropertyName = "QEstPrice"
            .Name = "QEstPrice"
        End With

        With Me.QMargin
            .DataPropertyName = "QMargin"
            .Name = "QMargin"
        End With

        With Me.QLeadTime
            .DataPropertyName = "QLeadTime"
            .Name = "QLeadTime"
        End With

        With Me.QExpLead
            .DataPropertyName = "QExpLead"
            .Name = "QExpLead"
        End With

        With Me.QExpValue
            .DataPropertyName = "QExpValue"
            .Name = "QExpValue"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.QLACNotes
            .DataPropertyName = "QLACNotes"
            .Name = "QLACNotes"
        End With

        With Me.QPartNotes
            .DataPropertyName = "QPartNotes"
            .Name = "QPartNotes"
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

    Sub CalculMpoValue()
        Dim I As Integer = 0

        For I = 0 To dgQuote.Rows.Count - 1
            If IsDBNull(Me.dgQuote("QQuotedPrice", I).Value) = True Then
                Me.dgQuote("QMargin", I).Value = 0
            Else
                If Nz.Nz(Me.dgQuote("QQuotedPrice", I).Value) > 0 Then
                    Me.dgQuote("QMargin", I).Value = (1 - (Nz.Nz(Me.dgQuote("QEstPrice", I).Value) / Nz.Nz(Me.dgQuote("QQuotedPrice", I).Value))) * 100
                Else
                    Me.dgQuote("QMargin", I).Value = 0
                End If
            End If
        Next

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

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
            CallClass.PopulateDataAdapterSearch7Param("getStQuoteSelectionRdAll", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblStQuote")
            CalculMpoValue()
            Exit Sub
        End If

        'If RdFollowup.Checked = True Then
        '    CallClass.PopulateDataAdapterSearch7Param("getQuoteSelectionRdFollowUp", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblStQuote")
        '    CalculMpoValue()
        '    Exit Sub
        'End If

        'If RdNoPrice.Checked = True Then
        '    CallClass.PopulateDataAdapterSearch5Param("getQuoteSelectionRdNoPrice", Par1, Par2, Par3, Par4, Par5).Fill(dsMain, "tblQuote")
        '    CalculMpoValue()
        '    Exit Sub
        'End If

        If RdNoBid.Checked = True Then
            CallClass.PopulateDataAdapterSearch7Param("getStQuoteSelectionRdAllNOBID", Par1, Par2, Par3, Par4, Par5, Par6, Par7).Fill(dsMain, "tblStQuote")
            CalculMpoValue()
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

        Try
            'Dim oXL As Microsoft.Office.Interop.Excel.Application
            'Dim oWB As Microsoft.Office.Interop.Excel.Workbook
            'Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim oRng As Microsoft.Office.Interop.Excel.Range

            Dim oXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim oWB As Excel.Workbook
            Dim oRng As Excel.Range

            ' Start Excel and get Application object.
            oXL = CreateObject("Excel.Application")
            oXL.Visible = True

            ' Get a new workbook.
            oWB = oXL.Workbooks.Add
            oSheet = oWB.ActiveSheet
            oXL.Visible = True
            Dim r As Integer
            Dim c As Integer


            oSheet.Cells(1, 1).Value = "Quote No."
            oSheet.Cells(1, 2).Value = "Quote Date"
            oSheet.Cells(1, 3).Value = "Quote Follow-Up"
            oSheet.Cells(1, 4).Value = "Quote Due Date"
            oSheet.Cells(1, 5).Value = "Contract"
            oSheet.Cells(1, 6).Value = "Contract Qty."
            oSheet.Cells(1, 7).Value = "Customer"
            oSheet.Cells(1, 8).Value = "Cust. Ref. No."
            oSheet.Cells(1, 9).Value = "Buyer"
            oSheet.Cells(1, 10).Value = "User"
            oSheet.Cells(1, 11).Value = "Quote Line"
            oSheet.Cells(1, 12).Value = "Part Number"
            oSheet.Cells(1, 13).Value = "Doc. No."
            oSheet.Cells(1, 14).Value = "DWG Source"
            oSheet.Cells(1, 15).Value = "Part Name"
            oSheet.Cells(1, 16).Value = "Part Revision"
            oSheet.Cells(1, 17).Value = "Quote Line Status"
            oSheet.Cells(1, 18).Value = "Contract Qty. Selected"
            oSheet.Cells(1, 19).Value = "Quote Qty."
            oSheet.Cells(1, 20).Value = "Quote Price"
            oSheet.Cells(1, 21).Value = "Quote EstPr"
            oSheet.Cells(1, 22).Value = "Gross Margin"
            oSheet.Cells(1, 23).Value = "Quote Devise"
            oSheet.Cells(1, 24).Value = "Lead Time"
            oSheet.Cells(1, 25).Value = "Expedite LT"
            oSheet.Cells(1, 26).Value = "Expedite Value"
            oSheet.Cells(1, 27).Value = "PO Customer"
            oSheet.Cells(1, 28).Value = "PO Date"
            oSheet.Cells(1, 29).Value = "Item Notes"
            oSheet.Cells(1, 30).Value = "Quote Notes"
            oSheet.Cells(1, 31).Value = "Raw Material"
            oSheet.Cells(1, 32).Value = "Tooling"

            ' Format A1:D1 as bold, vertical alignment = center.
            With oSheet.Range("A1", "S1")
                .Font.Bold = True
                '.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                '.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify
            End With

            For r = 0 To Me.dgQuote.Rows.Count - 1
                For c = 0 To 31
                    Dim s As String
                    If IsDBNull(dgQuote.Rows(r).Cells(c).Value) = True Then
                        s = ""
                    Else
                        s = dgQuote.Rows(r).Cells(c).FormattedValue
                    End If
                    oSheet.Cells(r + 1 + 2, c + 1).Value = s
                Next
            Next

            ' Make sure Excel is visible and give the user control

            ' of Microsoft Excel's lifetime.

            oXL.Visible = True
            oXL.UserControl = True

            ' Make sure you release object references.

            oRng = Nothing
            oSheet = Nothing
            oWB = Nothing
            oXL = Nothing

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

    End Sub

    Private Sub dgQuote_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgQuote.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgQuote_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgQuote.DataError
        REM end
    End Sub

    Private Sub dgQuote_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgQuote.Sorted
        CalculMpoValue()
    End Sub
End Class