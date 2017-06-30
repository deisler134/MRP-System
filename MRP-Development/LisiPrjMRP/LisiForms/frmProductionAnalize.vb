Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Imports Microsoft.Office.Interop

Public Class frmProductionAnalize

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowOrder As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet

    Dim RowProd As Integer = 0       'dgProd row.


    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmProductionAnalize_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmProductionAnalize_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1740 And Height > 880 Then
            Me.Width = 1740
            Me.Height = 880
        Else
            If Width < 1740 And Height < 880 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()
        InitialComponents()

        PutCustomer()
        PutPart()
        PutDept()

        SetCtlForm()

        ClearFields()

        txtTechNotes.DataBindings.Clear()
        txtTechNotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoTechNotes")

        txtQANotes.DataBindings.Clear()
        txtQANotes.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoQANotes")
    End Sub

    Sub ClearFields()

        txtExpedite.Text = ""
        txtActualQty.Text = ""
        txtSalesQty.Text = ""
        txtDeptCode.Text = ""
        txtMPONo.Text = ""
        txtNo3.Text = ""
        txtTotDays.Text = ""
        txtFPQty.Text = ""
        txtSalesValue.Text = ""
        txtAvg.Text = ""

        txtDateTo.Text = ""
        CmbPart.Text = ""
        CmbSelCust.Text = ""
        CmbMpoType.Text = ""
        CmbDept.Text = ""

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getProductionAnalyzeEmpty").Fill(dsMain, "tblMpoMaster")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDept()

        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartmentMPOActive").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutCustomer()

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomerShort").Tables("tblCustomers")
            .DisplayMember = "CustomerShort"
            .ValueMember = "CustomerShort"
        End With

    End Sub

    Sub PutPart()

        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberForProductionAnalyze").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub SetCtlForm()

        With Me.MpoPriority
            .DataPropertyName = "MpoPriority"
            .Name = "MpoPriority"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.DeptSalesFr
            .DataPropertyName = "DeptSalesFr"
            .Name = "DeptSalesFr"
        End With

        With Me.SwRouteStart
            .DataPropertyName = "SwRouteStart"
            .Name = "SwRouteStart"
        End With

        With Me.SwNoDays
            .DataPropertyName = "SwNoDays"
            .Name = "SwNoDays"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.SwSalesValue
            .DataPropertyName = "SwSalesValue"
            .Name = "SwSalesValue"
        End With

        With Me.MPOExpediteValue
            .DataPropertyName = "MPOExpediteValue"
            .Name = "MPOExpediteValue"
        End With

        With Me.SuppNotes
            .DataPropertyName = "SuppNotes"
            .Name = "SuppNotes"
        End With

        With Me.WKMpoSourceInsp
            .DataPropertyName = "WKMpoSourceInsp"
            .Name = "WKMpoSourceInsp"
        End With

        With Me.WKMpoFAI
            .DataPropertyName = "WKMpoFAI"
            .Name = "WKMpoFAI"
        End With

        With Me.WKMpoDVI
            .DataPropertyName = "WKMpoDVI"
            .Name = "WKMpoDVI"
        End With

        With Me.TestInsp
            .DataPropertyName = "TestInsp"
            .Name = "TestInsp"
        End With

        With Me.MicroInsp
            .DataPropertyName = "MicroInsp"
            .Name = "MicroInsp"
        End With

        With Me.DimInsp
            .DataPropertyName = "DimInsp"
            .Name = "DimInsp"
        End With

        With Me.MPODVINo
            .DataPropertyName = "MPODVINo"
            .Name = "MPODVINo"
        End With

        With Me.FaiDviInsp
            .DataPropertyName = "FaiDviInsp"
            .Name = "FaiDviInsp"
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.MPOPromDate
            .DataPropertyName = "MPOPromDate"
            .Name = "MPOPromDate"
        End With

        With Me.MemoNo
            .DataPropertyName = "MemoNo"
            .Name = "MemoNo"
        End With

        With Me.CmdSeeMemo
            .DataPropertyName = "CmdSeeMemo"
            .Name = "CmdSeeMemo"
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
            .Visible = False
        End With

        With Me.MpoQANotes
            .DataPropertyName = "MpoQANotes"
            .Name = "MpoQANotes"
            .Visible = False
        End With

        With Me.MPOID
            .DataPropertyName = "MPOID"
            .Name = "MPOID"
            .Visible = False
        End With

        With Me.MpoPartID
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
            .Visible = False
        End With

        With Me.MemoID
            .DataPropertyName = "MemoID"
            .Name = "MemoID"
            .Visible = False
        End With

        With Me.SwSuppName
            .DataPropertyName = "SwSuppName"
            .Name = "SwSuppName"
            .Visible = False
        End With

        With Me.SwPODate
            .DataPropertyName = "SwPODate"
            .Name = "SwPODate"
            .Visible = False
        End With

        With Me.SwPromisedDate
            .DataPropertyName = "SwPromisedDate"
            .Name = "SwPromisedDate"
            .Visible = False
        End With

        With Me.SwReceiveDate
            .DataPropertyName = "SwReceiveDate"
            .Name = "SwReceiveDate"
            .Visible = False
        End With

        With Me.SwPslipQty
            .DataPropertyName = "SwPslipQty"
            .Name = "SwPslipQty"
            .Visible = False
        End With

        With Me.SwPOQty
            .DataPropertyName = "SwPOQty"
            .Name = "SwPOQty"
            .Visible = False
        End With

        With Me.FlagColor
            .DataPropertyName = "FlagColor"
            .Name = "FlagColor"
            .Visible = False
        End With

    End Sub

    Sub PutDataGrid()

        dgProd.AutoGenerateColumns = False
        dgProd.DataSource = dsMain
        dgProd.DataMember = "tblMpoMaster"

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        ExecuteSearch()

    End Sub

    Sub ExecuteSearch()

        Me.Cursor = Cursors.WaitCursor

        Dim Par1, Par2, Par3, Par4, Par5, Par6 As String

        Par1 = CmbMpoType.Text
        Par2 = CmbPart.Text
        Par3 = CmbSelCust.Text

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par4 = DateAdd(DateInterval.Day, 2500, Date.Now).ToShortDateString()
        Else
            Par4 = txtDateTo.Text
        End If

        Par5 = CmbDept.Text
        Par6 = txtDeptCode.Text

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        CallClass.PopulateDataAdapterSearch6Param("getProductionAnalyzeSelection", Par1, Par2, Par3, Par4, Par5, Par6).Fill(dsMain, "tblMpoMaster")

        DisplayData()

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub DisplayData()

        Dim TDays As Integer = 0
        Dim DateStart As Date
        Dim DateEnd As Date


        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("QtyActual").Value) = True Then
                Row.Cells("SwSalesValue").Value = Row.Cells("QtyOrder").Value * Row.Cells("OrdItemPrice").Value
            Else
                If Row.Cells("QtyActual").Value < Row.Cells("QtyOrder").Value Then
                    Row.Cells("SwSalesValue").Value = Row.Cells("QtyActual").Value * Row.Cells("OrdItemPrice").Value
                Else
                    Row.Cells("SwSalesValue").Value = Row.Cells("QtyOrder").Value * Row.Cells("OrdItemPrice").Value
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If Val(Nz.Nz(Row.Cells("QtyActual").Value)) > 0 Then
                If Val(Row.Cells("QtyActual").Value) < Val(Row.Cells("QtyOrder").Value) Then
                    Row.Cells("QtyActual").Style.BackColor = Color.GreenYellow
                Else
                    Row.Cells("QtyActual").Style.BackColor = Color.White
                End If
            Else
                Row.Cells("QtyActual").Style.BackColor = Color.White
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("SwReceiveDate").Value) = False Then
                If Val(Row.Cells("SwPOQty").Value) - Val(Row.Cells("SwPslipQty").Value) = 0 Then
                    Row.Cells("SuppNotes").Value = "Recv. all Qty from: " + _
                                   Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                                    " on " + Row.Cells("SwReceiveDate").Value
                    Row.Cells("SuppNotes").Style.BackColor = Color.White
                Else
                    Row.Cells("SuppNotes").Value = "Recv. Partial Qty: " + _
                                      Str(Row.Cells("SwPslipQty").Value) + _
                                     " from: " + _
                                     Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                                      " on " + Row.Cells("SwReceiveDate").Value
                    Row.Cells("SuppNotes").Style.BackColor = Color.LemonChiffon
                End If
            Else
                If IsDBNull(Row.Cells("SwPODate").Value) = False Then
                    If IsDBNull(Row.Cells("SwPromisedDate").Value) = False Then
                        Row.Cells("SuppNotes").Value = "Send To: " + _
                            Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                            " on " + Row.Cells("SwPODate").Value + _
                            ".  Promised date: " + Row.Cells("SwPromisedDate").Value
                    Else
                        Row.Cells("SuppNotes").Value = "Send To: " + _
                            Microsoft.VisualBasic.Left(Row.Cells("SwSuppName").Value, 9) + _
                            " on " + Row.Cells("SwPODate").Value
                    End If
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("SwRouteStart").Value) = False Then
                If Len(Trim(Row.Cells("SwRouteStart").Value)) > 0 Then
                    DateStart = Row.Cells("SwRouteStart").Value
                    DateEnd = Date.Now.ToShortDateString
                    TDays = DateDiff(DateInterval.Day, DateStart, DateEnd)
                    Row.Cells("SwNoDays").Value = TDays.ToString
                End If
            End If
        Next

        For Each Row As DataGridViewRow In dgProd.Rows
            If IsDBNull(Row.Cells("FlagColor").Value) = False Then
                If (Row.Cells("FlagColor").Value) = True Then
                    Row.Cells("MpoPriority").Style.BackColor = Color.YellowGreen
                    Row.Cells("PartNumber").Style.BackColor = Color.YellowGreen
                    Row.Cells("MpoNo").Style.BackColor = Color.YellowGreen
                End If
            End If

        Next

    End Sub

    Sub CalculValue()
        Dim qty1 As Double = 0.0
        Dim qty2 As Double = 0.0
        Dim qty3 As Double = 0.0
        Dim qty4 As Double = 0.0
        Dim qty5 As Integer = 0
        Dim qty6 As Integer = 0
        Dim qty7 As Integer = 0

        txtExpedite.Text = ""
        txtActualQty.Text = ""
        txtSalesQty.Text = ""
        txtSalesValue.Text = ""
        txtMPONo.Text = ""
        txtNo3.Text = ""
        txtTotDays.Text = ""
        txtAvg.Text = ""
        txtFPQty.Text = ""
        txtSalesValue.Text = ""

        For Each Row As DataGridViewRow In dgProd.Rows
            qty1 = qty1 + Nz.Nz(Row.Cells("MPOExpediteValue").Value)
            qty2 = qty2 + Nz.Nz(Row.Cells("QtyActual").Value)
            qty3 = qty3 + Nz.Nz(Row.Cells("QtyOrder").Value)
            qty4 = qty4 + Nz.Nz(Row.Cells("SwSalesValue").Value)
            qty5 = qty5 + 1
            If Nz.Nz(Row.Cells("SwNoDays").Value) >= 3 Then
                qty6 = qty6 + 1
                qty7 = qty7 + Nz.Nz(Row.Cells("SwNoDays").Value)
            End If
        Next
        txtExpedite.Text = qty1.ToString("C2")
        txtActualQty.Text = qty2.ToString("N0")
        txtSalesQty.Text = qty3.ToString("N0")
        txtSalesValue.Text = qty4.ToString("C2")
        txtMPONo.Text = qty5.ToString("N0")
        txtNo3.Text = qty6.ToString("N0")
        txtTotDays.Text = qty7.ToString("N0")
        If qty6 > 0 Then
            txtAvg.Text = (qty7 / qty6).ToString("N0")
        End If

    End Sub

    Private Sub dgProd_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgProd.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0 To 16
                e.Cancel = True

            Case 17 To 22
                If RoleInspData(wkDeptCode) = False Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                    If e.ColumnIndex = 20 Then
                        If IsDBNull(dgProd("WKMpoFAI", e.RowIndex).Value) = True And IsDBNull(dgProd("WKMpoDVI", e.RowIndex).Value) = True Then
                            MsgBox("Nothing to accept.")
                            e.Cancel = True
                        End If
                    End If

                    If e.ColumnIndex = 21 Then
                        If IsDBNull(dgProd("WKMpoDVI", e.RowIndex).Value) = True Or Nz.Nz(dgProd("WKMpoDVI", e.RowIndex).Value) = 0 Then
                            MsgBox("Action Denied.")
                            e.Cancel = True
                        End If
                    End If
                End If

            Case 23 To 24
                e.Cancel = True
            Case 27 To 40
                e.Cancel = True
            Case 25
                If IsDBNull(dgProd("MemoNo", e.RowIndex).Value) = True Then
                    e.Cancel = True
                End If
        End Select

    End Sub

    Private Sub dgProd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProd.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If

        Select Case e.ColumnIndex

            Case 22

                If RoleInspData(wkDeptCode) = False Then
                    Exit Sub
                End If


                If Nz.Nz(dgProd("WKMpoDVI", RowProd).Value) = "1" Then
                    If Nz.Nz(dgProd("FaiDviInsp", RowProd).Value) = "1" Then
                        If Nz.Nz(dgProd("MPODVINo", RowProd).Value) = 0 Then
                            MsgBox("Please fill out the D.V.I. No. before you send the Email.")
                            Exit Sub
                        End If
                    Else
                        MsgBox("Please check -- FAI / DVI Acceptance -- before you send the Email.")
                        Exit Sub
                    End If
                End If

                Dim SwValid As Boolean = False          'if false email QA else if True  email Vinoj
                Dim SwNothing As Boolean = False        'true no data false yes we have

                If IsDBNull(dgProd("TestInsp", RowProd).Value) = True And IsDBNull(dgProd("MicroInsp", RowProd).Value) = True And IsDBNull(dgProd("DimInsp", RowProd).Value) = True Then
                    SwNothing = True
                    GoTo NextOper
                End If

                If dgProd("TestInsp", RowProd).Value.ToString = "TC" And dgProd("MicroInsp", RowProd).Value.ToString = "MC" And dgProd("DimInsp", RowProd).Value.ToString = "DC" Then
                    SwNothing = False
                    If Nz.Nz(dgProd("WKMpoFAI", RowProd).Value) = "1" Or Nz.Nz(dgProd("WKMpoDVI", RowProd).Value) = "1" Then
                        If Nz.Nz(dgProd("FaiDviInsp", RowProd).Value) = "1" Then
                            SwValid = True
                            GoTo NextOper
                        Else
                            MsgBox("Please complete FAI / DVI process.")
                            Exit Sub
                        End If
                    Else
                        SwValid = True
                        GoTo NextOper
                    End If
                Else
                    SwNothing = True
                End If

                If dgProd("TestInsp", RowProd).Value.ToString = "N/A" And dgProd("MicroInsp", RowProd).Value.ToString = "N/A" And dgProd("DimInsp", RowProd).Value.ToString = "DC" Then
                    SwNothing = False
                    If Nz.Nz(dgProd("WKMpoFAI", RowProd).Value) = "1" Or Nz.Nz(dgProd("WKMpoDVI", RowProd).Value) = "1" Then
                        If Nz.Nz(dgProd("FaiDviInsp", RowProd).Value) = "1" Then
                            SwValid = True
                            GoTo NextOper
                        Else
                            MsgBox("Please complete FAI / DVI process.")
                            Exit Sub
                        End If
                    Else
                        SwValid = True
                        GoTo NextOper
                    End If
                Else
                    SwNothing = True
                End If

                If dgProd("TestInsp", RowProd).Value.ToString = "NC" Or dgProd("MicroInsp", RowProd).Value.ToString = "NC" Or dgProd("DimInsp", RowProd).Value.ToString = "NC" Then
                    SwNothing = False
                    SwValid = False
                    GoTo NextOper
                End If

NEXTOPER:
                If SwNothing = True Then
                    Exit Sub
                Else
                    If SwValid = True Then
                        Dim reply As DialogResult

                        reply = MsgBox("The MPO is ready for shipment. Do you proceed ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            Try

                                Dim email As New Mail.MailMessage()
                                Dim strBody As String = ""
                                email.Subject = " MPO Ready for Package / Shipment"
                                strBody = "The MPO Number:  " + dgProd("MpoNo", RowProd).Value + "  (Part Number: " + dgProd("PartNumber", RowProd).Value + ") was send to Shipping Department."
                                email.Body = strBody

                                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                                email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
                                email.To.Add(New Mail.MailAddress("Vinoj.Vijayaratnam@lisi-aerospace.com"))

                                client.Send(email)

                            Catch ex As Exception
                            Finally
                            End Try


                            Dim swCode As String = ""
                            reply = MsgBox("Which Plant Number:   PL1 = YES  /  PL4  =  NO", MsgBoxStyle.YesNo)
                            If reply = Windows.Forms.DialogResult.Yes Then
                                swCode = CallClass.ReturnStrWithParString("cspReturnDeptID", "PL1-Final")
                            Else
                                swCode = CallClass.ReturnStrWithParString("cspReturnDeptID", "PL4-Final")
                            End If

                            'update MPO deptID = shipping
                            If IsDBNull(dgProd("MpoID", RowProd).Value) = True Then
                                Exit Sub
                            End If

                            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptIDByDeptCode", cn)
                            mySqlComm.CommandType = CommandType.StoredProcedure

                            Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
                            paraMpoID.Value = dgProd("MpoID", RowProd).Value
                            mySqlComm.Parameters.Add(paraMpoID)

                            Dim paraDeptID As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
                            paraDeptID.Value = swCode
                            mySqlComm.Parameters.Add(paraDeptID)

                            Try
                                If cn.State = ConnectionState.Open Then
                                    cn.Close()
                                End If
                                cn.Open()
                                mySqlComm.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox("!!! ERROR !!! Update Mpo Shipping Department: " & ex.Message)
                            Finally
                                cn.Close()
                            End Try

                        End If


                        ExecuteSearch()


                    Else
                        Dim reply As DialogResult

                        reply = MsgBox("Do you want to send the MPO for QA ReView ?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then

                            Try
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
                                'NotesDoc.Subject = " MPO for QA Review"
                                'strBody = "MPO Number:  " + dgProd("MpoNo", RowProd).Value + "  (Part Number: " + dgProd("PartNumber", RowProd).Value + ")."
                                'NotesDoc.body = strBody
                                ''Call NotesDoc.SEND(False, "stefan.tudor@lisi-aerospace.com")
                                'Call NotesDoc.SEND(False, "Vincent.PILLAI@Lisi-Aerospace.com")
                                'Call NotesDoc.SEND(False, "Arian.ALVARADE@Lisi-Aerospace.com")

                                Dim email As New Mail.MailMessage()
                                Dim strBody As String = ""
                                email.Subject = " MPO for QA Review"
                                strBody = "MPO Number:  " + dgProd("MpoNo", RowProd).Value + "  (Part Number: " + dgProd("PartNumber", RowProd).Value + ")."
                                email.Body = strBody

                                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                                email.To.Add(New Mail.MailAddress("Vincent.PILLAI@Lisi-Aerospace.com"))
                                'email.To.Add(New Mail.MailAddress("Arian.ALVARADE@Lisi-Aerospace.com"))
                                client.Send(email)

                            Catch ex As Exception
                            Finally
                            End Try
                        End If
                    End If
                End If

            Case Is = 25

                If IsDBNull(dgProd("MemoNo", e.RowIndex).Value) = True Then
                    MsgBox("Nothing to View.")
                    Exit Sub
                End If

                Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim rptPO As New rptLisiMemo()
                rptPO.ReportOptions.EnableSaveDataWithReport = False

                Dim FindMemo As String = ""
                FindMemo = Nz.Nz(dgProd("MemoNo", e.RowIndex).Value)
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
            Case 26

                Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

                Dim rptPO As New rptMFGMethodBarCodeRefOnly
                rptPO.Load("..\rptMFGMethodBarCodeRefOnly.rpt")

                pdvMpoID.Value = Convert.ToInt32(dgProd.Rows(RowProd).Cells("MPOID").Value)
                pdvPartID.Value = Convert.ToInt32(dgProd.Rows(RowProd).Cells("MpoPartID").Value)
                pvMPOIDCollection.Add(pdvMpoID)
                pvPartIDCollection.Add(pdvPartID)
                rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
                rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

                frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                frmPOMasterPrint.ShowDialog()
        End Select


        txtFPQty.Text = ""
        txtFPQty.Text = CallClass.ReturnStrWithParInt("cspReturnPartFPQty", dgProd("MpoPartID", e.RowIndex).Value)
        If txtFPQty.Text = "False" Then
            txtFPQty.Text = ""
        End If

        CalculValue()

    End Sub

    Private Sub dgProd_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProd.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowProd = e.RowIndex
        End If


        Select Case e.ColumnIndex

            Case 17
                UpdateMpoTestInsp()
            Case 18
                UpdateMpoMicroInsp()
            Case 19
                UpdateMpoDimInsp()
            Case 20
                UpdateMpoFAIOK()
            Case 21
                UpdateMpoDVINp()
        End Select
    End Sub

    Private Sub dgProd_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProd.DataError
        REM end
    End Sub


    Private Sub dgProd_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProd.Sorted
        DisplayData()
        CalculValue()
    End Sub

    Sub UpdateMpoDVINp()

        If IsDBNull(dgProd("MPODVINo", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDVINo", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpoID.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraDVINo As SqlParameter = New SqlParameter("@MPODVINo", SqlDbType.NVarChar, 10)
        paraDVINo.Value = dgProd("MPODVINo", RowProd).Value
        mySqlComm.Parameters.Add(paraDVINo)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo D.V.I. No: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoTestInsp()

        If IsDBNull(dgProd("TestInsp", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoTestInsp", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpoID.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraT As SqlParameter = New SqlParameter("@TestInsp", SqlDbType.NVarChar, 15)
        paraT.Value = dgProd("TestInsp", RowProd).Value
        mySqlComm.Parameters.Add(paraT)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Test Inspection: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoMicroInsp()

        If IsDBNull(dgProd("MicroInsp", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoMicroInsp", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpoID.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraM As SqlParameter = New SqlParameter("@MicroInsp", SqlDbType.NVarChar, 15)
        paraM.Value = dgProd("MicroInsp", RowProd).Value
        mySqlComm.Parameters.Add(paraM)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Micro Inspection: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoDimInsp()

        If IsDBNull(dgProd("DimInsp", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDimInsp", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpoID.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraD As SqlParameter = New SqlParameter("@DimInsp", SqlDbType.NVarChar, 15)
        paraD.Value = dgProd("DimInsp", RowProd).Value
        mySqlComm.Parameters.Add(paraD)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Dimmensional Inspection: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoFAIOK()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoFAIOK", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpoID.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOK As SqlParameter = New SqlParameter("@FaiDviInsp", SqlDbType.Bit, 1)
        paraOK.Value = dgProd("FaiDviInsp", RowProd).Value
        mySqlComm.Parameters.Add(paraOK)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Dimmensional Inspection: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Function RoleInspData(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "INSPDATA" Then
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

    Private Sub txtTechNotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTechNotes.Validating
        If RowProd < 0 Then
            Exit Sub
        End If

        If dgProd.Rows.Count - 1 >= 0 Then
            dgProd("MpoTechNotes", RowProd).Value = Trim(txtTechNotes.Text)
            UpdateMpoTechNotes()
        End If
    End Sub

    Sub UpdateMpoTechNotes()

        If IsDBNull(dgProd("MpoTechNotes", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoTechNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoTechNotes", SqlDbType.NVarChar, 2000)
        paraNotes.Value = dgProd("MpoTechNotes", RowProd).Value
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Technical Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub txtQANotes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQANotes.Validating
        If RowProd < 0 Then
            Exit Sub
        End If

        If dgProd.Rows.Count - 1 >= 0 Then
            dgProd("MpoQANotes", RowProd).Value = Trim(txtQANotes.Text)
            UpdateQANotes()
        End If
    End Sub

    Sub UpdateQANotes()

        If IsDBNull(dgProd("MpoQANotes", RowProd).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQANotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgProd("MpoID", RowProd).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraNotes As SqlParameter = New SqlParameter("@MpoQANotes", SqlDbType.NVarChar, 1000)
        paraNotes.Value = dgProd("MpoQANotes", RowProd).Value
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update QA Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        'Me.Cursor = Cursors.WaitCursor

        'If dgProd.Rows.Count - 1 >= 0 Then
        'Else
        '    MsgBox("Nothing to Export.")
        '    Exit Sub
        'End If

        'Try

        '    Dim wapp As Excel.Application
        '    Dim wsheet As Excel.Worksheet
        '    Dim wbook As Excel.Workbook
        '    wapp = New Excel.Application

        '    wapp.Visible = True
        '    wbook = wapp.Workbooks.Add()
        '    wsheet = wbook.ActiveSheet

        '    Dim iX As Integer
        '    Dim iY As Integer
        '    Dim iC As Integer

        '    For iC = 1 To 14 - 1
        '        wsheet.Cells(1, iC).Value = dgProd.Columns(iC).HeaderText
        '    Next
        '    For iC = 24 To 25 - 1
        '        wsheet.Cells(1, iC - 10).Value = dgProd.Columns(iC).HeaderText
        '    Next

        '    For iC = 28 To 29 - 1
        '        wsheet.Cells(1, iC - 13).Value = dgProd.Columns(iC).HeaderText
        '    Next

        '    For iC = 30 To 31 - 1
        '        wsheet.Cells(1, iC - 14).Value = dgProd.Columns(iC).HeaderText
        '    Next

        '    wsheet.Rows(2).select()

        '    For iX = 0 To dgProd.Rows.Count - 1
        '        For iY = 1 To 14 - 1
        '            wsheet.Cells(iX + 2, iY).value = dgProd(iY, iX).Value
        '        Next
        '    Next
        '    For iX = 0 To dgProd.Rows.Count - 1
        '        For iY = 24 To 25 - 1
        '            wsheet.Cells(iX + 2, iY - 10).value = dgProd(iY, iX).Value
        '        Next
        '    Next
        '    For iX = 0 To dgProd.Rows.Count - 1
        '        For iY = 28 To 29 - 1
        '            wsheet.Cells(iX + 2, iY - 13).value = dgProd(iY, iX).Value
        '        Next
        '    Next
        '    For iX = 0 To dgProd.Rows.Count - 1
        '        For iY = 30 To 31 - 1
        '            wsheet.Cells(iX + 2, iY - 14).value = dgProd(iY, iX).Value
        '        Next
        '    Next


        '    wapp.Visible = True
        '    wapp.UserControl = True

        'Catch ex As Exception

        '    MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        'End Try

        'Me.Cursor = Cursors.Default

        If dgProd.Rows.Count - 1 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

            Me.Cursor = Cursors.WaitCursor

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

            For iC = 0 To dgProd.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgProd.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgProd.Rows.Count - 1
                For iY = 0 To dgProd.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgProd(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True

            Me.Cursor = Cursors.Default

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmProductionAnalize_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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