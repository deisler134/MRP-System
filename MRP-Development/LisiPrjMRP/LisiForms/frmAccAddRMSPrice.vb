Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmAccAddRMSPrice
    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim RowPO As Integer = 0       'dgPO row.
    Dim SwEndUser As String = ""

    Private Sub frmAccAddRMSPrice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmAccAddRMSPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()
        GC.Collect()
        InitialComponents()

        SetCtlForm()

        ClearFields()

        FirstTime()

    End Sub

    Sub FirstTime()
        txtMatlLot.Enabled = True
        cmdReset.Enabled = True

        txtRMS.Enabled = False
        txtPOQty.Enabled = False
        txtPOPrice.Enabled = False
        txtAccNotes.Enabled = False
        txtDevise.Enabled = False

        CmdSave.Enabled = False

        CmdPrint.Enabled = False

        txtMatlLot.Focus()
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        txtUser.Text = wkName
    End Sub

    Sub AfterSelection()
        txtMatlLot.Enabled = False
        cmdReset.Enabled = True
        CmdSave.Enabled = True
        CmdPrint.Enabled = True

        txtRMS.Enabled = True
        txtPOPrice.Enabled = True
        txtPOQty.Enabled = True
        txtAccNotes.Enabled = True
        txtDevise.Enabled = True

        txtRMS.Focus()

        BindComponents()

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccPricesChPOInfoEmpty").Fill(dsMain, "tblSelPOInfo")
        CallClass.PopulateDataAdapter("getAccPricesChRecvInfoEmpty").Fill(dsMain, "tblSelRecv")
        CallClass.PopulateDataAdapter("getAccPricesChRMTrzInfoEmpty").Fill(dsMain, "tblSelRMTrz")
        CallClass.PopulateDataAdapter("getAccPricesChStockRMInfoEmpty").Fill(dsMain, "tblSelStock")
        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgPO.AutoGenerateColumns = False
        dgPO.DataSource = dsMain
        dgPO.DataMember = "tblSelPOInfo"

        dgRecv.AutoGenerateColumns = False
        dgRecv.DataSource = dsMain
        dgRecv.DataMember = "tblSelRecv"

        dgRMTrz.AutoGenerateColumns = False
        dgRMTrz.DataSource = dsMain
        dgRMTrz.DataMember = "tblSelRMTrz"

        dgStock.AutoGenerateColumns = False
        dgStock.DataSource = dsMain
        dgStock.DataMember = "tblSelStock"

    End Sub

    Sub BindComponents()

        txtAccNotes.DataBindings.Clear()
        txtAccNotes.DataBindings.Add("Text", dsMain, "tblSelPOInfo.POAccNotes")

    End Sub

    Sub SetCtlForm()

        ' po info
        With Me.PoNo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PoStatus
            .DataPropertyName = "POStatus"
            .Name = "POStatus"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.POType
            .DataPropertyName = "POType"
            .Name = "POType"
        End With

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.PORMSPrice
            .DataPropertyName = "PORMSPrice"
            .Name = "PORMSPrice"
        End With

        With Me.DocRecvNo
            .DataPropertyName = "DocRecvNo"
            .Name = "DocRecvNo"
        End With

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.POMasterID
            .DataPropertyName = "POMasterID"
            .Name = "POMasterID"
            .Visible = False
        End With

        With Me.POMpoID
            .DataPropertyName = "POMpoID"
            .Name = "POMpoID"
            .Visible = False
        End With

        'recv info

        With Me.RecvPONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.RecvPOItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.DocRecvNo
            .DataPropertyName = "DocRecvNo"
            .Name = "DocRecvNo"
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
        End With

        With Me.PslipDate
            .DataPropertyName = "PslipDate"
            .Name = "PslipDate"
        End With

        With Me.PSlipQty
            .DataPropertyName = "PSlipQty"
            .Name = "PSlipQty"
        End With

        With Me.PslipUM
            .DataPropertyName = "PslipUM"
            .Name = "PslipUM"
        End With

        With Me.PslipPrice
            .DataPropertyName = "PslipPrice"
            .Name = "PslipPrice"
        End With

        With Me.PORecvID
            .DataPropertyName = "PORecvID"
            .Name = "PORecvID"
            .Visible = False
        End With

        'RMTrz Info
        With Me.RMTrPONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.RMTrPOItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.MatlLotNo
            .DataPropertyName = "MatlLotNo"
            .Name = "MatlLotNo"
        End With

        With Me.MatlTranz
            .DataPropertyName = "MatlTranz"
            .Name = "MatlTranz"
        End With

        With Me.MatlStatus
            .DataPropertyName = "MatlStatus"
            .Name = "MatlStatus"
        End With

        With Me.MatlDateTranz
            .DataPropertyName = "MatlDateTranz"
            .Name = "MatlDateTranz"
        End With

        With Me.MatlQty
            .DataPropertyName = "MatlQty"
            .Name = "MatlQty"
        End With

        With Me.MatlUm
            .DataPropertyName = "MatlUm"
            .Name = "MatlUm"
        End With

        With Me.RMTrPoPrice
            .DataPropertyName = "PoPrice"
            .Name = "PoPrice"
        End With

        With Me.RmsPoPrice
            .DataPropertyName = "RmsPoPrice"
            .Name = "RmsPoPrice"
        End With

        With Me.MatlDevise
            .DataPropertyName = "MatlDevise"
            .Name = "MatlDevise"
        End With

        With Me.TrMatlID
            .DataPropertyName = "TrMatlID"
            .Name = "TrMatlID"
            .Visible = False
        End With

        'stock info

        With Me.StPONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.StPOItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.StLotNo
            .DataPropertyName = "StLotNo"
            .Name = "StLotNo"
        End With

        With Me.StDate
            .DataPropertyName = "StDate"
            .Name = "StDate"
        End With

        With Me.StFinal
            .DataPropertyName = "StFinal"
            .Name = "StFinal"
        End With

        With Me.StPoPrice
            .DataPropertyName = "StPoPrice"
            .Name = "StPoPrice"
        End With

        With Me.StRmsPoPrice
            .DataPropertyName = "StRmsPoPrice"
            .Name = "StRmsPoPrice"
        End With

        With Me.StDevise
            .DataPropertyName = "StDevise"
            .Name = "StDevise"
        End With

        With Me.StUM
            .DataPropertyName = "StUM"
            .Name = "StUM"
        End With

        With Me.StRawMatlID
            .DataPropertyName = "StRawMatlID"
            .Name = "StRawMatlID"
            .Visible = False
        End With

    End Sub

    Sub ClearFields()

        txtRMS.Text = ""
        txtPOPrice.Text = ""
        txtPOQty.Text = ""
        txtAccNotes.Text = ""
        txtDevise.Text = ""

        txtMatlLot.Text = ""
        txtMatlLot.Focus()

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        ClearFields()

        FirstTime()

        BindComponents()

    End Sub

    Private Sub txtMatlLot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatlLot.Click
        FirstTime()
    End Sub

    Private Sub txtMatlLot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMatlLot.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then

                Dim strSearch As String

                If Len(Trim(txtMatlLot.Text)) = 0 Then
                    MsgBox("Please enter the material Lot Number.")
                    txtMatlLot.Focus()
                    Exit Sub
                Else
                    strSearch = Trim(txtMatlLot.Text)
                End If

                dsMain.Clear()
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                Me.Refresh()

                'check if the RM tranz is open in the month

                Dim SwStatus As String = ""
                SwStatus = CallClass.ReturnInfoWithParString("cspReturnAccMatlTranzStatus", strSearch)
                If SwStatus = "O" Then
                    CallClass.PopulateDataAdapterAfterSearch("getAccPricesChPOInfo", strSearch).Fill(dsMain, "tblSelPOInfo")
                    CallClass.PopulateDataAdapterAfterSearch("getAccPricesChRecvInfo", strSearch).Fill(dsMain, "tblSelRecv")
                    CallClass.PopulateDataAdapterAfterSearch("getAccPricesChRMTrzInfo", strSearch).Fill(dsMain, "tblSelRMTrz")
                    CallClass.PopulateDataAdapterAfterSearch("getAccPricesChStockRMInfo", strSearch).Fill(dsMain, "tblSelStock")

                    If dgPO.Rows.Count <= 0 Then
                        MsgBox("!!! ERROR !!! - No Data selected.")

                        ClearFields()
                        FirstTime()
                    Else
                        AfterSelection()
                    End If
                Else
                    MsgBox("!!! Action Deneid. You can not change RM RMS/Price for a close tranzaction.")
                End If
            End If
        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - TxtMatlLot_KeyDown. Please contact the administrator." & ex.Message)
        End Try
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        Dim SwSave As Boolean = False

        If Len(Trim(txtDevise.Text)) > 0 Then
            Select Case txtDevise.Text
                Case "USD"
                    UpdateDevise()
                    SwSave = True
                Case "CAD"
                    UpdateDevise()
                    SwSave = True
                Case "EUR"
                    UpdateDevise()
                    SwSave = True
                Case Else
                    MsgBox("!!! ERROR !!! Currency Type.")
            End Select
        End If

        If Len(Trim(txtRMS.Text)) > 0 And Val(txtRMS.Text) > 0 Then
            UpdateRMS()
            SwSave = True
        End If

        If Len(Trim(txtPOPrice.Text)) > 0 And Val(txtPOPrice.Text) > 0 Then
            UpdatePOPrice()
            SwSave = True
        End If

        If Len(Trim(txtPOQty.Text)) > 0 And Val(txtPOQty.Text) > 0 Then
            UpdatePOQty()
            SwSave = True
        End If

        UpdateAccNotes()

        If SwSave = True Then

            UpDateEmpName()

            dsMain.Clear()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            Me.Refresh()

            Dim strSearch As String = ""
            strSearch = Trim(txtMatlLot.Text)
            CallClass.PopulateDataAdapterAfterSearch("getAccPricesChPOInfo", strSearch).Fill(dsMain, "tblSelPOInfo")
            CallClass.PopulateDataAdapterAfterSearch("getAccPricesChRecvInfo", strSearch).Fill(dsMain, "tblSelRecv")
            CallClass.PopulateDataAdapterAfterSearch("getAccPricesChRMTrzInfo", strSearch).Fill(dsMain, "tblSelRMTrz")
            CallClass.PopulateDataAdapterAfterSearch("getAccPricesChStockRMInfo", strSearch).Fill(dsMain, "tblSelStock")

            txtRMS.Enabled = False
            txtPOQty.Enabled = False
            txtPOPrice.Enabled = False
            txtAccNotes.Enabled = False
            CmdSave.Enabled = False
        Else
            MsgBox("Nothing to modify.")
        End If
        
    End Sub

    Sub UpdateDevise()

        Dim II, JJ As Integer

        ' RM tranzactions  -  devise 
        JJ = dgRMTrz.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccTrMatlDevise", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parTRMatlID As SqlParameter = New SqlParameter("@TrMatlID", SqlDbType.Int, 4)
            parTRMatlID.Value = dgRMTrz.Item("TrMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parTRMatlID)

            Dim parTrMatl As SqlParameter = New SqlParameter("@MatlDevise", SqlDbType.NVarChar, 10)
            parTrMatl.Value = txtDevise.Text
            cmdInsertDetail.Parameters.Add(parTrMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()

            Catch ex As SqlException
                MsgBox("Update RM Tranzaction Devise Value" & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try
        Next

        ' RM Stock  -  devise
        JJ = dgStock.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccStDevise", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parStMatlID As SqlParameter = New SqlParameter("@StRawMatlID", SqlDbType.Int, 4)
            parStMatlID.Value = dgStock.Item("StRawMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parStMatlID)

            Dim parStMatl As SqlParameter = New SqlParameter("@StDevise", SqlDbType.NVarChar, 10)
            parStMatl.Value = txtDevise.Text
            cmdInsertDetail.Parameters.Add(parStMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()

            Catch ex As SqlException
                MsgBox("Update RM Stock devise Value " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try
        Next
    End Sub

    Sub UpDateEmpName()

        ' Purchasing accounting user
        Dim II, JJ As Integer
        JJ = dgPO.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPOUser", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPOPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
            parPOPOMasterID.Value = dgPO.Item("POMasterID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOPOMasterID)

            Dim parPOAccUser As SqlParameter = New SqlParameter("@POAccUser", SqlDbType.NVarChar, 50)
            parPOAccUser.Value = Trim(txtUser.Text)
            cmdInsertDetail.Parameters.Add(parPOAccUser)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()

            Catch ex As SqlException
                MsgBox("Update PO Accounting User: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try
        Next
    End Sub

    Sub UpdateAccNotes()
        ' Purchasing information  accounting notes  only one line
        Dim II, JJ As Integer
        JJ = dgPO.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPONotes", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPOPOMasterID As SqlParameter = New SqlParameter("@POMasterID", SqlDbType.Int, 4)
            parPOPOMasterID.Value = dgPO.Item("POMasterID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPOPOMasterID)

            Dim parPOAccNotes As SqlParameter = New SqlParameter("@POAccNotes", SqlDbType.NVarChar, 1000)
            parPOAccNotes.Value = Trim(txtAccNotes.Text)
            cmdInsertDetail.Parameters.Add(parPOAccNotes)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO Accounting Notes: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
    End Sub

    Sub UpdateRMS()

        ' Purchasing information  RMS value  only 1 line
        Dim II, JJ As Integer
        JJ = dgPO.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPOPrices", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPODetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
            parPODetailID.Value = dgPO.Item("PODetailID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPODetailID)

            Dim parPORMS As SqlParameter = New SqlParameter("@PORMSPrice", SqlDbType.Money, 8)
            parPORMS.Value = txtRMS.Text
            cmdInsertDetail.Parameters.Add(parPORMS)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO RMS Value: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
       
        ' RM tranzactions  -  RMS Value
        JJ = dgRMTrz.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccTrMatlPrices", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parTRMatlID As SqlParameter = New SqlParameter("@TrMatlID", SqlDbType.Int, 4)
            parTRMatlID.Value = dgRMTrz.Item("TrMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parTRMatlID)

            Dim parTrMatl As SqlParameter = New SqlParameter("@RmsPoPrice", SqlDbType.Money, 8)
            parTrMatl.Value = txtRMS.Text
            cmdInsertDetail.Parameters.Add(parTrMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update RM Tranzaction RMS Value" & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next

        ' RM Stock  -  RMS Value
        JJ = dgStock.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccStMatlPrices", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parStMatlID As SqlParameter = New SqlParameter("@StRawMatlID", SqlDbType.Int, 4)
            parStMatlID.Value = dgStock.Item("StRawMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parStMatlID)

            Dim parStMatl As SqlParameter = New SqlParameter("@StRmsPoPrice", SqlDbType.Money, 8)
            parStMatl.Value = txtRMS.Text
            cmdInsertDetail.Parameters.Add(parStMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update RM Stock RMS Value " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
    End Sub

    Sub UpdatePOPrice()

        Dim II, JJ As Integer

        ' Purchasing information  PO Price
        JJ = dgPO.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPOPrice_2", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPODetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
            parPODetailID.Value = dgPO.Item("PODetailID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPODetailID)

            Dim parPOPrice As SqlParameter = New SqlParameter("@POPrice", SqlDbType.Money, 8)
            parPOPrice.Value = txtPOPrice.Text
            cmdInsertDetail.Parameters.Add(parPOPrice)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO Price: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next

        ' PSlip information  PO Price 
        JJ = dgRecv.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccRecvPOPrice", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parRecvID As SqlParameter = New SqlParameter("@PORecvID", SqlDbType.Int, 4)
            parRecvID.Value = dgRecv.Item("PORecvID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parRecvID)

            Dim parPOPrice As SqlParameter = New SqlParameter("@PslipPrice", SqlDbType.Float, 8)
            parPOPrice.Value = txtPOPrice.Text
            cmdInsertDetail.Parameters.Add(parPOPrice)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update Receiving PO Price: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next

        ' RM tranzactions  -  PO Price Value
        JJ = dgRMTrz.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccTrMatlPrice_2", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parTRMatlID As SqlParameter = New SqlParameter("@TrMatlID", SqlDbType.Int, 4)
            parTRMatlID.Value = dgRMTrz.Item("TrMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parTRMatlID)

            Dim parTrMatl As SqlParameter = New SqlParameter("@PoPrice", SqlDbType.Money, 8)
            parTrMatl.Value = txtPOPrice.Text
            cmdInsertDetail.Parameters.Add(parTrMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update RM Tranzaction with PO Price" & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next

        ' RM Stock  -  PO Price Value
        JJ = dgStock.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccStMatlPrice_2", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parStMatlID As SqlParameter = New SqlParameter("@StRawMatlID", SqlDbType.Int, 4)
            parStMatlID.Value = dgStock.Item("StRawMatlID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parStMatlID)

            Dim parStMatl As SqlParameter = New SqlParameter("@StPoPrice", SqlDbType.Money, 8)
            parStMatl.Value = txtPOPrice.Text
            cmdInsertDetail.Parameters.Add(parStMatl)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update RM Stock PO Price " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
    End Sub

    Sub UpdatePOQty()
        Dim II, JJ As Integer

        ' Purchasing information  PO Qty
        JJ = dgPO.Rows.Count
        For II = 1 To JJ
            Dim cmdInsertDetail As SqlCommand = New SqlCommand("cspUpdateAccPOQty", cn)
            cmdInsertDetail.CommandType = CommandType.StoredProcedure

            Dim parPODetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
            parPODetailID.Value = dgPO.Item("PODetailID", II - 1).Value
            cmdInsertDetail.Parameters.Add(parPODetailID)

            Dim parPOQty As SqlParameter = New SqlParameter("@POQty", SqlDbType.Real, 4)
            parPOQty.Value = txtPOQty.Text
            cmdInsertDetail.Parameters.Add(parPOQty)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertDetail.ExecuteNonQuery()
                cmdInsertDetail.Dispose()
            Catch ex As SqlException
                MsgBox("Update PO Quantity: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Next
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click

        SwEndUser = ""

        Dim SwMPOId As Integer = 0
        SwMPOId = Nz.Nz(dgPO.Rows(RowPO).Cells("POMpoID").Value)
        'If SwMPOId = 0 Then
        'Exit Sub
        'Else
        SwEndUser = CallClass.ReturnStrWithParInt("cspReturnMpoEndUserClient", SwMPOId)
        If SwEndUser = "False" Then
            SwEndUser = ""
        Else
            SwEndUser = SwEndUser + "  End User"
        End If
        'End If

        Dim pvFindCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pvEndUserCollection As New CrystalDecisions.Shared.ParameterValues
        Dim pdFind As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim pdEndUser As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Try
            Dim rptPO As New rptPOAcc()
            rptPO.Load("..\rptPOAcc.rpt")
            pdFind.Value = dgPO("PoNo", RowPO).Value
            pdEndUser.Value = SwEndUser

            pvFindCollection.Add(pdFind)
            pvEndUserCollection.Add(pdEndUser)

            rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvFindCollection)
            rptPO.DataDefinition.ParameterFields("@SwEndUser").ApplyCurrentValues(pvEndUserCollection)

            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            'frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None

            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True

            frmPOMasterPrint.ShowDialog()
        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try

    End Sub

    Private Sub dgPO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPO.CellClick
        If e.RowIndex < 0 Then
            Return
        Else
            RowPO = e.RowIndex
        End If
    End Sub

    Private Sub dgPO_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPO.CellEnter
        If e.RowIndex < 0 Then
            Return
        Else
            RowPO = e.RowIndex
        End If
    End Sub
End Class