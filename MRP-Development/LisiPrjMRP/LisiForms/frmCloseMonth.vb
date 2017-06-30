Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmCloseMonth

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim FindMonth As Boolean = False

    Private Sub frmCloseMonth_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Dispose()
        GC.Collect()
    End Sub

    Private Sub frmCloseMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        LoadInfo()

        If FindMonth = True Then
            CmdTranz.Enabled = True
            CmdRMYTD.Enabled = True

            CmdMatlRecv.Enabled = True
            CmdMatlRel.Enabled = True
            CmdMatlAdj.Enabled = True
            CmdRawInv.Enabled = True
            CmdPostInv.Enabled = True
            CmdFP.Enabled = True

            cmdCopy.Enabled = False
            CmdOpen.Enabled = False
        Else
            CmdTranz.Enabled = False
            CmdRMYTD.Enabled = False

            CmdMatlRecv.Enabled = False
            CmdMatlRel.Enabled = False
            CmdMatlAdj.Enabled = False
            CmdRawInv.Enabled = False
            CmdPostInv.Enabled = False
            CmdFP.Enabled = False

            cmdCopy.Enabled = False
            CmdOpen.Enabled = False

        End If

    End Sub

    Sub LoadInfo()
        txtDate.ReadOnly = True
        txtMonth.ReadOnly = True
        txtDateFrom.ReadOnly = True
        txtDateTo.ReadOnly = True

        txtDate.Text = Now.ToShortDateString
        txtMonth.Text = ""
        txtDateFrom.Text = ""
        txtDateTo.Text = ""


        txtUSD.Text = ""
        txtEUR.Text = ""
        txtGBP.Text = ""

        FindLisiMonth()

    End Sub

    Sub FindLisiMonth()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspFindOpenLisiData", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        Dim myReader As Data.SqlClient.SqlDataReader
       
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR !!! The system can not identify the Open Month. You must ReOpen the Month status.")
                FindMonth = False
            Else
                While myReader.Read()
                    txtMonth.Text = myReader.GetValue(0).ToString
                    txtDateFrom.Text = myReader.GetValue(1).ToShortDateString
                    txtDateTo.Text = myReader.GetValue(2).ToShortDateString
                    txtUSD.Text = myReader.GetValue(3).ToString
                    txtEUR.Text = myReader.GetValue(4).ToString
                    txtGBP.Text = myReader.GetValue(5).ToString
                    FindMonth = True
                End While
                myReader.Close()
                myReader.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - cspFindOpenLisiData   " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub CmdTranz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTranz.Click

        CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")

        CmdTranz.Enabled = False
        CmdRMYTD.Enabled = True
        CmdMatlRecv.Enabled = True
        CmdMatlRel.Enabled = True
        CmdMatlAdj.Enabled = True
        CmdRawInv.Enabled = True

        CmdFP.Enabled = True
        CmdOpen.Enabled = True

    End Sub

    Private Sub CmdMatlRecv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMatlRecv.Click

        Dim rptPO As New rptRawMatRecvTranz

        rptPO.Load("..\rptRawMatRecvTranz.rpt")
        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree

        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()
    End Sub

    Private Sub CmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOpen.Click

        If txtMonth.Text = "OPEN" Then
            If txtDate.Text < txtDateTo.Text Then
                MsgBox("!!! ERROR !!! You can not close the month as the current system date is less than the month end date.")
            Else
                CallClass.UpdateMatlStock("cspReOpenInventory")

                CmdTranz.Enabled = False
                CmdMatlRecv.Enabled = True
                CmdFP.Enabled = True
                CmdOpen.Enabled = False
            End If
        End If

    End Sub

    Private Sub CmdMatlRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMatlRel.Click

        Dim rptPO As New rptRawMatlRelTranz

        rptPO.Load("..\rptRawMatlRelTranz.rpt")
        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()
    End Sub

    Private Sub CmdMatlAdj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMatlAdj.Click
        Dim rptPO As New rptRawMatlAdjTranz

        rptPO.Load("..\rptRawMatlAdjTranz.rpt")
        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()
    End Sub

    Private Sub CmdRawInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRawInv.Click
        Dim rptPO As New rptInvRawMaterial

        rptPO.Load("..\rptInvRawMaterial.rpt")
        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.ShowDialog()

    End Sub

    Sub UpdateRate(ByVal strType As String, ByVal strValue As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateExchangeRate", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@CurrType", SqlDbType.NVarChar, 3)
        paraSearch.Value = strType
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraVal As SqlParameter = New SqlParameter("@CurrValue", SqlDbType.Real, 4)
        paraVal.Value = Val(strValue)
        mySqlComm.Parameters.Add(paraVal)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("!!!ERROR!!! Update Lisi Exchange Rates. " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub txtUSD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUSD.Validating
        Call UpdateRate("USD", txtUSD.Text)
    End Sub

   
    Private Sub txtEUR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEUR.Validating
        Call UpdateRate("EUR", txtEUR.Text)
    End Sub

    Private Sub txtGBP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtGBP.Validating
        Call UpdateRate("GBP", txtGBP.Text)
    End Sub

    Private Sub cmdTranzFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTranzFP.Click

        CallClass.UpdateMatlStock("cspUpdatetblStockFP")

        CmdTranz.Enabled = False
        cmdTranzFP.Enabled = False

        CmdMatlRecv.Enabled = True
        CmdMatlRel.Enabled = True
        CmdMatlAdj.Enabled = True
        CmdRawInv.Enabled = True

        CmdFP.Enabled = True
        CmdOpen.Enabled = True
    End Sub

    Private Sub CmdPostInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPostInv.Click

        CallClass.UpdateMatlStock("cspUpdatePostInvoice")
        CmdPostInv.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim txtComputer As String = "192.168.115.75"
        Dim txtMessage As String = "Hello"

        Shell("net send " & txtComputer & " " & txtMessage)

    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click

    End Sub

    Private Sub CmdRMYTD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRMYTD.Click

        CallClass.ExecuteUpdate3Params("cspUpdateSaveRMStockPerMonthYear", txtDateTo.Text, Year(txtDateTo.Text), Month(txtDateTo.Text))

        CmdTranz.Enabled = False
        CmdRMYTD.Enabled = False

        CmdMatlRecv.Enabled = True
        CmdMatlRel.Enabled = True
        CmdMatlAdj.Enabled = True
        CmdRawInv.Enabled = True

        CmdFP.Enabled = True
        CmdOpen.Enabled = True


    End Sub
End Class