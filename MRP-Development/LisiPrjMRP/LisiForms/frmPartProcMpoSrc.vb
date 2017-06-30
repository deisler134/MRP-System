Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net
Imports System.Net.Mail

Public Class frmPartProcMpoSrc

    Inherits System.Windows.Forms.Form

    Dim CallClass As New clsCommon
    Dim cn As New SqlConnection(strConnection)

    Private dsSrc As New DataSet
    Dim RowdgSearch As Integer = 0

    Dim strSQL As String

    Dim OldQtyEng As String

    Private Sub frmPartProcMpoSrc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsSrc.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Function RoleViewProc(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "VIEWPROC" Then
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

    Private Sub frmPartProcMpoSrc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        dsSrc.Clear()
        dsSrc.Relations.Clear()

        If RoleViewProc(wkDeptCode) = True Then
            CallClass.PopulateAdapterAfterSearchInt("getPartProcMPOSearchAll", SwPartID.Text).Fill(dsSrc, "tmpPartProcMpoSrc")
        Else
            CallClass.PopulateAdapterAfterSearchInt("getPartProcMPOSearch", SwPartID.Text).Fill(dsSrc, "tmpPartProcMpoSrc")
        End If

        CallClass.PopulateDataAdapter("gettblStockRawMatlReservation").Fill(dsSrc, "tblStockRawMatlReservation")

        dsSrc.EnforceConstraints = False

        With dsSrc
            .Relations.Add("MpoReserv", _
              .Tables("tmpPartProcMpoSrc").Columns("MpoId"), _
            .Tables("tblStockRawMatlReservation").Columns("MpoId"), True)
        End With

        dgSearch.AutoGenerateColumns = False
        dgSearch.DataSource = dsSrc
        dgSearch.DataMember = "tmpPartProcMpoSrc"

        dgMatl.AutoGenerateColumns = False
        dgMatl.DataSource = dsSrc
        dgMatl.DataMember = "tmpPartProcMpoSrc.MpoReserv"


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

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlHeat
            .DataPropertyName = "RecvMatlHeat"
            .Name = "RecvMatlHeat"
        End With

        With Me.RecvMatlCond
            .DataPropertyName = "RecvMatlCond"
            .Name = "RecvMatlCond"
        End With

        With Me.MpoSourceInsp
            .DataPropertyName = "MpoSourceInsp"
            .Name = "MpoSourceInsp"
        End With

        With Me.MpoCustAppr
            .DataPropertyName = "MpoCustAppr"
            .Name = "MpoCustAppr"
        End With

        With Me.MpoFAI
            .DataPropertyName = "MpoFAI"
            .Name = "MpoFAI"
        End With

        With Me.MpoDVI
            .DataPropertyName = "MpoDVI"
            .Name = "MpoDVI"
        End With

        With Me.MpoProcRemarks
            .DataPropertyName = "MpoProcRemarks"
            .Name = "MpoProcRemarks"
        End With

        With Me.MpoEngBars
            .DataPropertyName = "MpoEngBars"
            .Name = "MpoEngBars"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.MpoEstWeight
            .DataPropertyName = "MpoEstWeight"
            .Name = "MpoEstWeight"
        End With

        With Me.MpoReleasedNo
            .DataPropertyName = "MpoReleasedNo"
            .Name = "MpoReleasedNo"
        End With

        With Me.ProcNo
            .DataPropertyName = "ProcNo"
            .Name = "ProcNo"
        End With

        With Me.MpoEngInfo
            .DataPropertyName = "MpoEngInfo"
            .Name = "MpoEngInfo"
        End With

        With Me.DeptEng
            .DataPropertyName = "DeptEng"
            .Name = "DeptEng"
            .Visible = False
        End With

        With Me.DeptRoot
            .DataPropertyName = "DeptRoot"
            .Name = "DeptRoot"
            .Visible = False
        End With

        ' matl resevation

        With Me.MpoIDRez
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.StLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.ResWeight
            .DataPropertyName = "ResWeight"
            .Name = "ResWeight"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.RecvMatlHeatRez
            .DataPropertyName = "RecvMatlHeat"
            .Name = "RecvMatlHeat"
        End With

        With Me.RecvMatlCondRez
            .DataPropertyName = "RecvMatlCond"
            .Name = "RecvMatlCond"
        End With

        With Me.RecvMatlLength
            .DataPropertyName = "RecvMatlLength"
            .Name = "RecvMatlLength"
        End With

        With Me.RecvMatlSizeRez
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlBars
            .DataPropertyName = "RecvMatlBars"
            .Name = "RecvMatlBars"
        End With

        With Me.RecvMatlCoils
            .DataPropertyName = "RecvMatlCoils"
            .Name = "RecvMatlCoils"
        End With

        With Me.RecvMatlHex
            .DataPropertyName = "RecvMatlHex"
            .Name = "RecvMatlHex"
        End With

        With Me.MatlFam
            .DataPropertyName = "MatlFam"
            .Name = "MatlFam"
        End With

        With Me.MatType
            .DataPropertyName = "MatType"
            .Name = "MatType"
        End With

        With Me.MatDetKSI
            .DataPropertyName = "MatDetKSI"
            .Name = "MatDetKSI"
        End With

    End Sub

    Private Sub dgSearch_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgSearch.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgSearch = e.RowIndex
        End If

        OldQtyEng = Nz.Nz(dgSearch("QtyEngReleased", e.RowIndex).Value)

        Dim StrSearch As Integer = 0
        Dim getInfo As String = ""
        StrSearch = Nz.Nz(dgSearch("MpoId", RowdgSearch).Value) & vbCrLf
        getInfo = CallClass.ReturnStrWithParInt("cspReturnMpoStatus", StrSearch)

        If getInfo = "Closed" Or getInfo = "Cancelled" Or getInfo = "Scrapped" Then
            MsgBox("Action Denied. MPO Status is not Active.")
            e.Cancel = True
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 21, 22, 23               '21-depteng, 22=process id
                e.Cancel = True
            Case 3, 4, 5, 7, 8, 9, 12, 13       'mpo, par,sales qty,type, cond,dia, lot, heat
                e.Cancel = True
            Case 6
                If IsDBNull(dgSearch("MpoEngInfo", e.RowIndex).Value) = True Then
                Else
                    If Len(Trim(dgSearch("MpoEngInfo", e.RowIndex).Value)) > 0 Then
                        MsgBox("Action Denied.")
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
        End Select

    End Sub

    Private Sub dgSearch_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgSearch = e.RowIndex
        End If

        'dgSearch.Rows(e.RowIndex).Selected = True

        OldQtyEng = Nz.Nz(dgSearch("QtyEngReleased", e.RowIndex).Value)

        If e.ColumnIndex = 2 Then       'select
            If SwProcRevised.Text = "True" Then
                MsgBox("Action Denied. The Manufacturing Method is not revised.")
                Exit Sub
            End If

            If dgSearch("DeptEng", e.RowIndex).Value <> "1" Then
                MsgBox("Action Denied. The MPO is in production.")
            Else
                If IsDBNull(dgSearch("ProcNo", e.RowIndex).Value) = False Then
                    Dim reply As DialogResult
                    reply = MsgBox("A Manufacturing Method was assigned to MPO. Do you want to continue ?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        UpdateAssinMpo()
                    End If
                Else

                    UpdateAssinMpo()

                    '  Check if the part number is 1st time manufacture @ LAC
                    Dim strSearch As String
                    Dim SwCount As String

                    strSearch = dgSearch("MpoPartID", e.RowIndex).Value
                    SwCount = CallClass.TakeFinalSt("cspReturnPartInProductionCount", strSearch)

                    If Val(SwCount) <= 1 Then
                        Dim email As New Mail.MailMessage()
                        Dim strBody As String = ""
                        Dim SwtxtPart As String = ""

                        'SwtxtPart = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", dgOrd.Rows(RowOrd).Cells("OrdPartNoID").Value)

                        email.Subject = " !!! ATTENTION !!!"
                        strBody = "Part Number:" + dgSearch("PartNumber", e.RowIndex).Value + "  ---   First Time Release To Production" + vbCrLf
                        strBody = strBody + "========================================================="
                        email.Body = strBody

                        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                        email.From = New Net.Mail.MailAddress(wkEmpEmail)
                        email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                        email.To.Add(New Mail.MailAddress("TAO.Zhen@lisi-aerospace.com"))
                        email.To.Add(New Mail.MailAddress("Ken.NEILL@lisi-aerospace.com"))
                        '                      email.To.Add(New Mail.MailAddress("stefan.TUDOR@lisi-aerospace.com"))
                        email.To.Add(New Mail.MailAddress("Zhanxi.LIN@lisi-aerospace.com"))
                        email.To.Add(New Mail.MailAddress("PlantManager.Montreal@lisi-aerospace.com"))

                        client.Send(email)

                    End If
                End If
            End If
        End If


        '   bar code process sheet
        If e.ColumnIndex = 20 Then     ' view
            Dim pvMPOIDCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pvPartIDCollection As New CrystalDecisions.Shared.ParameterValues()
            Dim pdvMpoID As New CrystalDecisions.Shared.ParameterDiscreteValue()
            Dim pdvPartID As New CrystalDecisions.Shared.ParameterDiscreteValue()

            Dim rptPO As New rptMFGMethodBarCode
            rptPO.Load("..\rptMFGMethodBarCode.rpt")

            pdvMpoID.Value = dgSearch.Rows(e.RowIndex).Cells("MPOID").Value
            pdvPartID.Value = dgSearch.Rows(e.RowIndex).Cells("MpoPartID").Value
            pvMPOIDCollection.Add(pdvMpoID)
            pvPartIDCollection.Add(pdvPartID)
            rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvMPOIDCollection)
            rptPO.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()

            If InStr(dgSearch("DeptRoot", e.RowIndex).Value, "Planning", vbTextCompare) <> 0 Then
                MsgBox("Warning. The MPO is in planning department and you'll reassign the P/N revision info.")
                UpdateAssinMpo()
            End If

            Try
                If Nz.Nz(dgSearch("MpoReleasedNo", e.RowIndex).Value) > 1 Then

                    MsgBox("Please print the next Part Number Tool Box Report and attached with the Traveler too.")

                    Dim rptPO1 As New rptPartToolBox
                    rptPO1.Load("..\rptPartToolBox.rpt")

                    pdvPartID.Value = dgSearch.Rows(e.RowIndex).Cells("MpoPartID").Value
                    pvPartIDCollection.Add(pdvPartID)
                    rptPO1.DataDefinition.ParameterFields("@txtPartID").ApplyCurrentValues(pvPartIDCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO1
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
                    frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
                    frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
                    frmPOMasterPrint.ShowDialog()

                End If
            Catch ex As Exception

            End Try
           
        End If

    End Sub

    Private Sub dgSearch_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellEndEdit

        Dim reply As DialogResult

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgSearch = e.RowIndex
        End If

        dgSearch.EndEdit()
        dgSearch.Refresh()

        Select Case e.ColumnIndex
            Case 14
                UpdateSourceInsp()
            Case 15
                UpdateCustAppr()
            Case 16
                UpdateFAI()
            Case 17
                UpdateDVI()
            Case 18
                UpdateRemarks()
            Case 10
                UpdateEngBars()
            Case 6
                reply = MsgBox("Edit Quantity Released ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateQtyReleased()
                Else
                    dgSearch("QtyEngReleased", RowdgSearch).Value = OldQtyEng
                End If
            Case 11
                UpdateEstWeight()
            Case 19
                UpdateMpoReleasedNo()
        End Select
    End Sub

    Sub UpdateQtyReleased()

        If IsDBNull(dgSearch("QtyEngReleased", RowdgSearch).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleased", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgSearch("QtyEngReleased", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraQty)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Update Mpo Qty Released: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateSourceInsp()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgSearch("MpoSourceInsp", RowdgSearch).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoSourceInsp", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraInsp As SqlParameter = New SqlParameter("@MpoSourceInsp", SqlDbType.Bit, 1)
            paraInsp.Value = dgSearch("MpoSourceInsp", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraInsp)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Source Inspection" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Source Inspection" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateCustAppr()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgSearch("MpoCustAppr", RowdgSearch).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOCustApproval", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraAppr As SqlParameter = New SqlParameter("@MpoCustAppr", SqlDbType.Bit, 1)
            paraAppr.Value = dgSearch("MpoCustAppr", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraAppr)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Cust Approval" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Cust Approval" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateFAI()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgSearch("MpoFAI", RowdgSearch).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoFAI", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraFAI As SqlParameter = New SqlParameter("@MpoFAI", SqlDbType.Bit, 1)
            paraFAI.Value = dgSearch("MpoFAI", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraFAI)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update FAI" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update FAI" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateDVI()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        If IsDBNull(dgSearch("MpoDVI", RowdgSearch).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDVI", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraFAI As SqlParameter = New SqlParameter("@MpoDVI", SqlDbType.Bit, 1)
            paraFAI.Value = dgSearch("MpoDVI", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraFAI)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update FAI" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update FAI" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateRemarks()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        'If IsDBNull(dgSearch("MpoProcRemarks", RowdgSearch).Value) = True Then
        '    Exit Sub
        'End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoProcRemarks", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraNotes As SqlParameter = New SqlParameter("@MpoProcRemarks", SqlDbType.NVarChar, 200)
            paraNotes.Value = dgSearch("MpoProcRemarks", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraNotes)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Proc Remarks" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Proc Remarks" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateEngBars()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        'If IsDBNull(dgSearch("MpoEngBars", RowdgSearch).Value) = True Then
        '    Exit Sub
        'End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoEngBars", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraBars As SqlParameter = New SqlParameter("@MpoEngBars", SqlDbType.Real, 4)
            paraBars.Value = dgSearch("MpoEngBars", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraBars)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Eng Bars" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Eng Bars" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateEstWeight()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        'If IsDBNull(dgSearch("MpoEstWeight", RowdgSearch).Value) = True Then
        '    Exit Sub
        'End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoEstWeight", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraEstWeight As SqlParameter = New SqlParameter("@MpoEstWeight", SqlDbType.Real, 4)
            paraEstWeight.Value = dgSearch("MpoEstWeight", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraEstWeight)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Est Weight" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Est Weight" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoReleasedNo()

        If RowdgSearch < 0 Then
            Exit Sub
        End If

        'If IsDBNull(dgSearch("MpoEstWeight", RowdgSearch).Value) = True Then
        '    Exit Sub
        'End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoReleasedNo", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgSearch("MpoID", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraEstWeight As SqlParameter = New SqlParameter("@MpoReleasedNo", SqlDbType.Int, 4)
            paraEstWeight.Value = dgSearch("MpoReleasedNo", RowdgSearch).Value
            mySqlComm.Parameters.Add(paraEstWeight)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox("Update Mpo Released No" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo Released No" & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub dgSearch_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSearch.DataError
        REM end
    End Sub

    Sub UpdateAssinMpo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoTraveler", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMPOID As SqlParameter = New SqlParameter("@FindMPOID", SqlDbType.Int, 4)
        paraMPOID.Value = dgSearch("MpoID", RowdgSearch).Value
        mySqlComm.Parameters.Add(paraMPOID)

        Dim paraProcID As SqlParameter = New SqlParameter("@FindProcID", SqlDbType.Int, 4)
        paraProcID.Value = SwProcID.Text
        mySqlComm.Parameters.Add(paraProcID)

        Dim paraPartRev As SqlParameter = New SqlParameter("@FindPartRev", SqlDbType.NVarChar, 50)
        paraPartRev.Value = SwPartRevSave.Text
        mySqlComm.Parameters.Add(paraPartRev)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update MPO Traveler: " & ex.Message)
        Finally
            cn.Close()
            MsgBox("Update successfully.")
        End Try

    End Sub

    Private Sub dgMatl_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMatl.CellBeginEdit
        e.Cancel = True
    End Sub
End Class