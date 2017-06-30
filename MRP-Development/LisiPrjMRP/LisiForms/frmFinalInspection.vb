Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

'Imports System.Net.Mime
'Imports System.Threading
'Imports System.ComponentModel


Public Class frmFinalInspection

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim SwStatus As Boolean = False
    Dim SwParMpo As Integer
    Dim SwOper As String
    Dim SwVal As Boolean = False
    Dim OldActual As String

    Dim CallClass As New clsCommon

    Private Sub frmFinalInspection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmFinalInspection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        If IsNothing(wkEmpId) Or IsDBNull(wkEmpId) Or wkEmpId = 0 Then
            MessageBox.Show("!!! Login ERROR !!! Access Denied")
            Me.Dispose()
        End If

        Call SetupForm()

    End Sub

    Sub SetupForm()

        DisableFields()

        FirstTimeMenuButtons()

        InitialComponents()

        PutMpoNo()
        PutClosedMpoNo()
        PutCustomer()
        PutDept()

        BindData()

        SwStatus = False
        SwParMpo = -1
        SwOper = ""

        txtStockClass.Text = ""

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        'CallClass.PopulateDataAdapter("getShopFloorControl").Fill(dsMain, "tblMpoMaster")
        CallClass.PopulateDataAdapter("getFinalInspectionMpoIDEmpty").Fill(dsMain, "tblMpoMaster")
        dsMain.EnforceConstraints = False

    End Sub

    Sub PutMpoNo()

        With cmbMpo
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGettblMpoMaster").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

    End Sub

    Sub PutClosedMpoNo()

        With CmbClMpo
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGettblMpoMasterClosed").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

    End Sub

    Sub PutCustomer()

        With Me.cmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Sub PutDept()

        With cmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub
    Sub DisableFields()

        cmbMpo.Enabled = False
        cmbCust.Enabled = False
        cmbDept.Enabled = False
        cmbDevise.Enabled = False
        cmbStType.Enabled = False
        cmbMpoStatus.Enabled = False

        txtPart.ReadOnly = True
        txtMPOType.ReadOnly = True
        txtShortCust.ReadOnly = True
        txtStockClass.ReadOnly = True
        txtQtyActual.ReadOnly = True
        txtQtyReleased.ReadOnly = True
        txtQtyScrapped.ReadOnly = True
        txtProdScrapped.ReadOnly = True
        txtInspScrapped.ReadOnly = True
        txtMatlLot.ReadOnly = True
        txtWeight.ReadOnly = True
        txtAdj.ReadOnly = True
        txtCustOrder.ReadOnly = True
        txtCOC.ReadOnly = True
        txtPrice.ReadOnly = True

        txtRMCost.Enabled = False
        txtMFRCost.Enabled = False
        txtProcCost.Enabled = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdSave.Enabled = False

        cmdPrint.Enabled = False
        cmdReset.Enabled = True
        cmdMod.Enabled = True

        cmbMpo.Enabled = True
        CmbClMpo.Enabled = False

        cmbStType.Text = "FP"

    End Sub

    Sub BindData()

        'cmbMpo.DataBindings.Clear()
        cmbCust.DataBindings.Clear()
        cmbDept.DataBindings.Clear()
        cmbStType.DataBindings.Clear()
        cmbDevise.DataBindings.Clear()
        cmbMpoStatus.DataBindings.Clear()

        txtPart.DataBindings.Clear()
        txtMPOType.DataBindings.Clear()
        txtShortCust.DataBindings.Clear()
        txtQtyActual.DataBindings.Clear()
        txtQtyReleased.DataBindings.Clear()

        txtQtyScrapped.DataBindings.Clear()
        txtProdScrapped.Text = ""
        txtInspScrapped.DataBindings.Clear()

        txtMatlLot.DataBindings.Clear()
        txtWeight.DataBindings.Clear()
        txtAdj.DataBindings.Clear()
        txtCustOrder.DataBindings.Clear()

        txtCOC.DataBindings.Clear()
        txtPrice.DataBindings.Clear()

        txtRMCost.DataBindings.Clear()
        txtMFRCost.DataBindings.Clear()
        txtProcCost.DataBindings.Clear()

        'cmbMpo.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.MpoID")
        cmbCust.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.CustID")
        cmbDept.DataBindings.Add("SelectedValue", dsMain, "tblMpoMaster.DeptID")
        'cmbStType.DataBindings.Add("Text", dsMain, "tblMpoMaster.")
        cmbDevise.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdDevise")
        cmbMpoStatus.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoStatus")

        txtPart.DataBindings.Add("Text", dsMain, "tblMpoMaster.PartNumber")
        txtMPOType.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoType")
        txtShortCust.DataBindings.Add("Text", dsMain, "tblMpoMaster.CustomerShort")
        txtQtyActual.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyActual")
        txtQtyReleased.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyEngReleased")
        txtQtyScrapped.DataBindings.Add("Text", dsMain, "tblMpoMaster.QtyScrapped")
        txtInspScrapped.DataBindings.Add("Text", dsMain, "tblMpoMaster.InspScrapped")

        txtMatlLot.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoLotNo")
        txtWeight.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoMatlWeight")
        txtAdj.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoMatlAdj")
        txtCustOrder.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdNumber")

        txtPrice.DataBindings.Add("Text", dsMain, "tblMpoMaster.OrdItemPrice")
        txtCOC.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoCOC")

        txtRMCost.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoRMCostCDN")
        txtMFRCost.DataBindings.Add("Text", dsMain, "tblMpoMaster.MpoMachCostCDN")
        txtProcCost.DataBindings.Add("Text", dsMain, "tblMpoMaster.MPOProcessingCost")

    End Sub

    Private Sub cmbMpo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMpo.DropDownClosed

        Dim strSearch As Integer
        strSearch = cmbMpo.SelectedValue

        dsMain.Clear()

        CallClass.PopulateAdapterAfterSearchInt("getFinalInspectionMpoID", strSearch).Fill(dsMain, "tblMpoMaster")

        If dsMain.Tables("tblMpoMaster").Rows.Count > 0 Then
            BindData()

            CalculateQtyScr()
            CalculInspscr()

            OldActual = txtQtyActual.Text

            txtCOC.ReadOnly = False

            cmdMod.Enabled = False
            CmbClMpo.Enabled = False
            CmbClMpo.SelectedIndex = -1

            cmbStType.Enabled = True

            SwParMpo = cmbMpo.SelectedValue
            SwOper = "New"

            EnableFields()

            CmdSave.Enabled = True
            cmdReset.Enabled = True
            cmdPrint.Enabled = False

            If txtMPOType.Text = "Min/Max" And txtShortCust.Text = "LISI-CDN" Then
                txtStockClass.Text = "LACStdPrice"
            Else
                txtStockClass.Text = "LACStockPrice"
            End If

            'txtRMCost.Text = ""
            'txtMFRCost.Text = ""
            'txtProcCost.Text = ""
            'txtRMCost.Enabled = False
            'txtMFRCost.Enabled = False
            'txtProcCost.Enabled = False
        Else
            MsgBox("No Data selected. Please try again.")
        End If

    End Sub

    Private Sub cmbMpo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMpo.GotFocus
        InitDataSet()
    End Sub

    Sub InitDataSet()

        dsMain.Clear()

        CallClass.PopulateDataAdapter("getShopFloorControlEmpty").Fill(dsMain, "tblMpoMaster")

        dsMain.EnforceConstraints = False

        BindData()

    End Sub

    Sub GetMatlInfo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("getFinalInspectionMatlLot", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@SwMatlLot", txtMatlLot.Text))
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! Missing Material Lot Number data !!!")
            Else
                While myReader.Read()
                    txtCOC.Text = Trim(txtCOC.Text) + vbCrLf + Nz.Nz(Trim(myReader.GetValue(0)))
                    txtCOC.Text = Trim(txtCOC.Text) + vbCrLf + Nz.Nz(Trim(myReader.GetValue(1)))
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - Put Material Data   " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub GetPoInfo()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("getFinalInspectionPoInfo", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@SwMpoID", SwParMpo))
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! Missing Purchasing Mpo Data !!!")
            Else
                While myReader.Read()
                    txtCOC.Text = Trim(txtCOC.Text) + vbCrLf + Nz.Nz(Trim(myReader.GetValue(0)))
                    txtCOC.Text = Trim(txtCOC.Text) + vbCrLf + Nz.Nz(Trim(myReader.GetValue(1)))
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - Put Po Data  " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub EnableFields()

        cmbMpo.Enabled = False
        CmbClMpo.Enabled = False

        If Len(Trim(txtCOC.Text)) = 0 Then
            GetMatlInfo()
            GetPoInfo()
        End If

        txtInspScrapped.ReadOnly = False
        txtQtyActual.ReadOnly = False

    End Sub

    Sub CalculateQtyScr()
        txtQtyScrapped.Text = (Val(txtQtyReleased.Text) - Val(txtQtyActual.Text)).ToString("N0")
        
        If Val(txtQtyScrapped.Text) >= 0 Then
            Me.ErrorProvider1.Clear()
        Else
            Me.ErrorProvider1.SetError(txtQtyScrapped, "Qty Scrapped is Negative. Please correct the actual quantity or the released quantity.")
            Me.ErrorProvider1.BlinkRate = 200
            Me.ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
        End If
    End Sub

    Sub CalculInspscr()
        txtProdScrapped.Text = (Val(txtQtyScrapped.Text) - Val(txtInspScrapped.Text)).ToString("N0")
    End Sub

    Private Sub txtInspScrapped_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtInspScrapped.Validating
        CalculInspscr()
    End Sub

    Private Sub txtQtyActual_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQtyActual.Validating
        If Nz.Nz(txtQtyActual.Text) = 0 Then
            MsgBox("If you want to Scrap the MPO use the MEMO module. Action Denied.")
            txtQtyActual.Text = OldActual
            e.Cancel = True
        End If
        CalculateQtyScr()
        CalculInspscr()
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        Call SetupForm()

        Me.ErrorProvider1.Clear()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Me.Cursor = Cursors.WaitCursor

        Select Case SwOper
            Case "New"

                Call ValPo()

                If SwVal = False Then
                    Exit Sub
                Else
                    UpdateMpoDept()
                    UpdateMpoDataAndClose()
                    UpdateTranzFP()
                    CallClass.UpdateFPStock("cspUpdatetblStockFP")

                    SalesMail()

                End If

            Case "Mod"
                If SwStatus = True Then
                    UpdateMpoDataAndClose()
                    UpdateTranzFP()
                    CallClass.UpdateFPStock("cspUpdatetblStockFP")
                Else
                    UpdateCOC()
                End If
        End Select

        cmdPrint.Enabled = True
        CmdSave.Enabled = False

        DisableFields()


        Try
            ' when RM lot is empty the RM value from blanks is assign when we send the blanks to prod: see SFP/FP Released to MPO
            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            If Len(Trim(txtMatlLot.Text)) > 0 Then
                If Nz.Nz(txtQtyActual.Text) > 0 Then   ' we look for RM cost
                    If CallClass.ReturnStrWith2ParStr("cspCalculMPORawMaterialCost", cmbMpo.SelectedValue, txtQtyActual.Text) <> "False" Then
                        txtRMCost.Text = CallClass.ReturnStrWith2ParStr("cspCalculMPORawMaterialCost", cmbMpo.SelectedValue, txtQtyActual.Text)
                    End If
                Else   ' we have a scrapped 
                    If CallClass.ReturnStrWith2ParStr("cspCalculMPORawMaterialCost", cmbMpo.SelectedValue, txtQtyReleased.Text) <> "False" Then
                        txtRMCost.Text = CallClass.ReturnStrWith2ParStr("cspCalculMPORawMaterialCost", cmbMpo.SelectedValue, txtQtyReleased.Text)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("!!! ERROR !!! cspCalculMPORawMaterialCost: " & ex.Message)
        End Try

        Try
            'calcul Machining Cost Value for the same Operation Grouped By Operation Last Update
            UpdateMachCostPerOperGrouped()
            txtMFRCost.Text = CallClass.ReturnStrWithParInt("cspCalculMPOMachiningCost", cmbMpo.SelectedValue)
        Catch ex As Exception
            MsgBox("!!! ERROR !!! cspCalculMPOMachiningCost: " & ex.Message)
        End Try

        Try
            'calcul Processing Cost Value Last Update. Accounting app will finalize the cost with qty recv and insp
            txtProcCost.Text = CallClass.TakeFinalSt("cspCalculMPOProcessingCost", cmbMpo.SelectedValue)
        Catch ex As Exception
            MsgBox("!!! ERROR !!! cspCalculMPOProcessingCost: " & ex.Message)
        End Try

        Try
            'calcul MFG Production Days#
            Dim SwNoDays As String = ""
            SwNoDays = CallClass.ReturnStrWithParInt("cspCalculMPODaysInProd", cmbMpo.SelectedValue)
        Catch ex As Exception
            MsgBox("!!! ERROR !!! cspCalculMPODaysInProd: " & ex.Message)
        End Try


        'Try
        '    Dim SwOperNo As String = ""
        '    SwOperNo = CallClass.ReturnStrWithParInt("cspReturnMPOCountOperNull", cmbMpo.SelectedValue)

        '    If Len(Trim(SwOperNo)) > 0 Then

        '        Dim email As New Mail.MailMessage()
        '        Dim strBody As String = ""
        '        email.Subject = " MPO Final Inspection"
        '        strBody = "For the MPO Number:  " + cmbMpo.Text + " (Part Number:" + txtPart.Text + vbCrLf
        '        strBody = strBody + "There is/are one or more Operations not CLOSED in MPO Routing:" + vbCrLf
        '        strBody = strBody + "( " + SwOperNo + " )"
        '        'email.Body = strBody

        '        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
        '        email.From = New Net.Mail.MailAddress(wkEmpEmail)
        '        email.To.Add(New Mail.MailAddress("qualite.montreal@lisi-aerospace.com"))
        '        'client.Send(email)
        '        client.SendAsync(email, strBody)
        '    End If

        'Catch ex As Exception

        'End Try

        MsgBox("Record has been successfully updated")

        Me.Cursor = Cursors.Default

    End Sub

    Sub SalesMail()

        Try

            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "MPO Final Inspection"
            strBody = "The MPO Number:  " + cmbMpo.Text + "  (Part Number:" + txtPart.Text + "; Final Qty: " + txtQtyActual.Text + " ) was Closed in MRP."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("ventes.montreal@lisi-aerospace.com"))
            
            client.Send(email)

        Catch ex As Exception
        Finally
        End Try

        If txtMPOType.Text = "Assembly" Then

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                Dim email As New Mail.MailMessage()
                Dim strBody As String = ""
                email.Subject = "MPO Final Inspection"
                strBody = "The MPO Number:  " + cmbMpo.Text + "  (Part Number:" + txtPart.Text + "; Final Qty: " + txtQtyActual.Text + " ) was Closed in MRP."
                email.Body = strBody

                Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                email.From = New Net.Mail.MailAddress(wkEmpEmail)
                email.To.Add(New Mail.MailAddress("vente.montreal@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Yanick.LEVERT@lisi-aerospace.com"))
                email.To.Add(New Mail.MailAddress("Vinoj.Vijayaratnam@lisi-aerospace.com"))
                client.Send(email)

            Catch ex As Exception
            Finally
            End Try

        End If

         
    End Sub
    Sub UpdateMachCostPerOperGrouped()
        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMPOMachCostAndProcPerOperGrouped", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@SwMPOId", SqlDbType.Int, 4)
            paraMpo.Value = cmbMpo.SelectedValue
            mySqlComm.Parameters.Add(paraMpo)

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox("Update Machining Cost Mpo: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub ValPo()

        If Val(txtQtyActual.Text) > Val(txtQtyReleased.Text) Then
            MsgBox("!!! ERROR !!! Qty Actual is > then Qty Released.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtStockLoc.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Stock Location.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(cmbStType.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Inventory Type (FP / SFP).")
            SwVal = False
            Exit Sub
        End If

        Dim SwCount As Integer = 0
        SwCount = CallClass.ReturnStrWithParInt("cspReturnQtyAcceptedNull", cmbMpo.SelectedValue)

        If SwCount > 0 Then
            MsgBox(" !!! ATTENTION !!! There is/are one or more PO(s) in MRP where the inspected qty was not accepted.")
            SwVal = False
            Exit Sub
        End If


        SwCount = CallClass.ReturnStrWithParInt("cspReturnMEMOStatus", cmbMpo.SelectedValue)

        If SwCount > 0 Then
            MsgBox(" !!! ATTENTION !!! There is/are one or more open MEMOs.")


            Dim email As New Mail.MailMessage()
            Dim strBody As String = ""
            email.Subject = "MPO Final Inspection"
            strBody = "For the MPO Number:  " + cmbMpo.Text + " (Part Number:" + txtPart.Text + vbCrLf
            strBody = strBody + "There is/are one or more open MEMOs."
            email.Body = strBody

            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
            email.From = New Net.Mail.MailAddress(wkEmpEmail)
            email.To.Add(New Mail.MailAddress("qualite.montreal@lisi-aerospace.com"))
            client.Send(email)

            SwVal = False
            Exit Sub
        End If


        'Dim SwOperNo As String = ""
        'SwOperNo = CallClass.ReturnStrWithParInt("cspReturnMPOCountOperNull", cmbMpo.SelectedValue)

        'If Len(Trim(SwOperNo)) > 0 Then
        '    MsgBox(" !!! ATTENTION !!! There is/are one or more Operations not CLOSED in MPO Routing ---  " + SwOperNo + "   .")
        '    SwVal = False
        '    Exit Sub
        'End If

        SwVal = True

    End Sub

    Sub UpdateMpoDept()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            'paraMpo.Value = cmbMpo.SelectedValue
            paraMpo.Value = SwParMpo
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = 18
            mySqlComm.Parameters.Add(paraDept)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update MPO - FP Dept.: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Update MPO - FP Dept.: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateCOC()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoCOC", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = SwParMpo
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraCOC As SqlParameter = New SqlParameter("@MpoCOC", SqlDbType.NVarChar, 2000)
            paraCOC.Value = Trim(txtCOC.Text)
            mySqlComm.Parameters.Add(paraCOC)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update MPO COC " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Update MPO COC " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateMpoDataAndClose()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoFinalInspection", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            'paraMpo.Value = cmbMpo.SelectedValue
            paraMpo.Value = SwParMpo
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraAct As SqlParameter = New SqlParameter("@QtyActual", SqlDbType.Real, 4)
            paraAct.Value = Val(txtQtyActual.Text)
            mySqlComm.Parameters.Add(paraAct)

            Dim paraInsp As SqlParameter = New SqlParameter("@InspScrapped", SqlDbType.Real, 4)
            paraInsp.Value = Val(txtInspScrapped.Text)
            mySqlComm.Parameters.Add(paraInsp)

            Dim paraCOC As SqlParameter = New SqlParameter("@MpoCOC", SqlDbType.NVarChar, 2000)
            paraCOC.Value = Trim(txtCOC.Text)
            mySqlComm.Parameters.Add(paraCOC)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update Mpo Data: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo Data: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Sub UpdateTranzFP()

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRecvFinishParts", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MpoStockID", SqlDbType.Int, 4)
            'paraMpo.Value = cmbMpo.SelectedValue
            paraMpo.Value = SwParMpo
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraOper As SqlParameter = New SqlParameter("@TrOper", SqlDbType.NVarChar, 1)
            paraOper.Value = 1
            mySqlComm.Parameters.Add(paraOper)

            Dim paraStatus As SqlParameter = New SqlParameter("@TrStatus", SqlDbType.NVarChar, 1)
            paraStatus.Value = "O"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraStType As SqlParameter = New SqlParameter("@TypeStock", SqlDbType.NVarChar, 10)
            paraStType.Value = cmbStType.Text
            mySqlComm.Parameters.Add(paraStType)

            Dim paraDate As SqlParameter = New SqlParameter("@DateTranz", SqlDbType.SmallDateTime, 4)
            paraDate.Value = Now.ToShortDateString
            mySqlComm.Parameters.Add(paraDate)

            If txtMPOType.Text = "Grinding" Then
                Dim paraInMonth As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
                paraInMonth.Value = 0
                mySqlComm.Parameters.Add(paraInMonth)
            Else
                Dim paraInMonth As SqlParameter = New SqlParameter("@QtyTranz", SqlDbType.Real, 4)
                paraInMonth.Value = Val(txtQtyActual.Text)
                mySqlComm.Parameters.Add(paraInMonth)
            End If

            Dim paraPrice As SqlParameter = New SqlParameter("@PriceTranz", SqlDbType.Money, 4)
            paraPrice.Value = Val(txtPrice.Text)
            mySqlComm.Parameters.Add(paraPrice)

            Dim paraDevise As SqlParameter = New SqlParameter("@TrDevise", SqlDbType.NVarChar, 10)
            paraDevise.Value = cmbDevise.Text
            mySqlComm.Parameters.Add(paraDevise)

            Dim paraLoc As SqlParameter = New SqlParameter("@StLoc", SqlDbType.NVarChar, 20)
            paraLoc.Value = Trim(txtStockLoc.Text)
            mySqlComm.Parameters.Add(paraLoc)

            Dim paraStClasification As SqlParameter = New SqlParameter("@TrStStockClasification", SqlDbType.NVarChar, 25)
            paraStClasification.Value = Trim(txtStockClass.Text)
            mySqlComm.Parameters.Add(paraStClasification)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update Finish Parts Inventory (InPut): " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try
        Catch ex As Exception
            MsgBox("Update Finish Parts Inventory (InPut): " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        cmbMpo.Enabled = False

        cmdMod.Enabled = False
        cmdPrint.Enabled = False
        CmdSave.Enabled = False
    End Sub

    Private Sub cmdMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMod.Click
        cmbMpo.Enabled = False
        cmbMpo.SelectedIndex = -1

        cmdMod.Enabled = False
        CmbClMpo.Enabled = True
    End Sub

    Private Sub CmbClMpo_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbClMpo.DropDownClosed
        Dim strSearch As Integer
        strSearch = CmbClMpo.SelectedValue

        dsMain.Clear()

        CallClass.PopulateAdapterAfterSearchInt("getFinalInspectionMpoID", strSearch).Fill(dsMain, "tblMpoMaster")

        BindData()

        DisableFields()

        CalculateQtyScr()
        CalculInspscr()

        cmbStType.Enabled = False
        CmbClMpo.Enabled = False

        If VerifyFPTranzStatus() = False Then
            MsgBox("You can modify only the C.O.C.")
            txtCOC.ReadOnly = False
            SwStatus = False
        Else
            SwStatus = True
            EnableFields()
        End If

        SwParMpo = CmbClMpo.SelectedValue
        SwOper = "Mod"

        CmdSave.Enabled = True
        cmdReset.Enabled = True

        cmdPrint.Enabled = False

    End Sub

    Public Function VerifyFPTranzStatus() As Boolean

        Dim swRet As Boolean
        swRet = False

        Dim SqlStr As String
        SqlStr = "SELECT * FROM tblTranzFP " _
                & "WHERE (TrStatus = '" & "O" & "') AND (TrOper = '" & "1" & "') AND (MpoStockID = " & CmbClMpo.SelectedValue & ")"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(SqlStr, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Boolean
            TestRec = myReader.HasRows
            swRet = TestRec
            myReader.Close()
            myReader.Dispose()
        Catch ex As Exception
            swRet = False
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

        Return swRet

    End Function

End Class