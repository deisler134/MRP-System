Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmPOAnalyze

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowPO As Integer = 0       'dgQuote row.

    Private dsMain As New DataSet

    Private Sub frmPOAnalyze_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPOAnalyze_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()
        GC.Collect()

        'InitButtons()

        InitialComponents()

        'PutCustomer()
        SetCtlForm()

        'ClearFields()

        'CalculMpoValue()

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getPOAnalyzeSelection").Fill(dsMain, "tblPOAnalyze")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgPO.AutoGenerateColumns = False
        dgPO.DataSource = dsMain
        dgPO.DataMember = "tblPOAnalyze"

    End Sub

    Sub SetCtlForm()

        'dgPo

        With Me.POMasterID
            .DataPropertyName = "POMasterID"
            .Name = "POMasterID"
            .Visible = False
        End With

        With Me.PODetailID
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
            .Visible = False
        End With

        With Me.POType
            .DataPropertyName = "POType"
            .Name = "POType"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.PODate
            .DataPropertyName = "PODate"
            .Name = "PODate"
        End With

        With Me.PODueDate
            .DataPropertyName = "PODueDate"
            .Name = "PODueDate"
        End With

        With Me.CustDelivDate
            .DataPropertyName = "CustDelivDate"
            .Name = "CustDelivDate"
        End With

        With Me.NrDaysNowToDeliv
            .DataPropertyName = "NrDaysNowToDeliv"
            .Name = "NrDaysNowToDeliv"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.POUM
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.DolarSign
            .DataPropertyName = "DolarSign"
            .Name = "DolarSign"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.POPromisedDate
            .DataPropertyName = "POPromisedDate"
            .Name = "POPromisedDate"
        End With

        With Me.PONotesLAC
            .DataPropertyName = "PONotesLAC"
            .Name = "PONotesLAC"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.POLineValue
            .DataPropertyName = "POLineValue"
            .Name = "POLineValue"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.SwRateMPO
            .DataPropertyName = "SwRateMPO"
            .Name = "SwRateMPO"
        End With

        With Me.SwRatePO
            .DataPropertyName = "SwRatePO"
            .Name = "SwRatePO"
        End With

        With Me.MPOLineValue
            .DataPropertyName = "MPOLineValue"
            .Name = "MPOLineValue"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.TotQty
            .DataPropertyName = "TotQty"
            .Name = "TotQty"
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click
        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        CallClass.PopulateDataAdapter("getPOAnalyzeSelection").Fill(dsMain, "tblPOAnalyze")
    End Sub

    Sub CalculMpoValue()

        'For Each Row As DataGridViewRow In dgMpo.Rows
        '    Row.Cells("MpoValue").Value = Nz.Nz(Row.Cells("QtyActual").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value)
        'Next

        Dim I As Integer = 0

        For I = 0 To dgPO.Rows.Count - 1
            If IsDBNull(Me.dgPO("QtyActual", I).Value) = False And _
               IsDBNull(Me.dgPO("OrdItemPrice", I).Value) = False Then
                Me.dgPO("MpoValue", I).Value = Me.dgPO("QtyActual", I).Value * Me.dgPO("OrdItemPrice", I).Value
            Else
                Me.dgPO("MpoValue", I).Value = 0
            End If
        Next

        'qRes = txtWeightRes.Text
        'qFinal = Nz.Nz(dgMatl("StFinal", e.RowIndex).Value)
        'qdif = qFinal - qRes

        'dgMatl("Balance", e.RowIndex).Value = qdif

    End Sub

    Private Sub dgPO_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPO.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowPO = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0 To 27
                e.Cancel = True
            Case 28             'promised date only Sub Analyze can change

                If RoleSubAnalyze(wkDeptCode) = False Then
                    e.Cancel = True
                End If

            Case 30
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgPO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPO.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowPO = e.RowIndex
        End If

        Select Case e.ColumnIndex

            Case 27
                UpdatePoItemStatus()                'it's hide the controler the changes was done andtthe system sould control now
            Case 28

                If IsDBNull(dgPO("POPromisedDate", e.RowIndex).Value) = True Then
                    Exit Sub
                End If

                Dim Mi, Di, Yi As String

                Mi = Format(Me.dgPO("POPromisedDate", e.RowIndex).Value, "MM")
                Di = Format(Me.dgPO("POPromisedDate", e.RowIndex).Value, "dd")
                Yi = Format(Me.dgPO("POPromisedDate", e.RowIndex).Value, "yyyy")

                If Val(Di) >= 1 And Val(Di) <= 31 Then
                Else
                    MsgBox("!!! ERROR - Day Value.  -  " & Di)
                    Exit Sub
                End If

                If Val(Mi) >= 1 And Val(Mi) <= 12 Then
                Else
                    MsgBox("!!! ERROR - Month Value.  -  " & Mi)
                    Exit Sub
                End If

                If Val(Yi) <= Format(Now, "yyyy") + 1 And Val(Yi) >= Format(Now, "yyyy") Then
                Else
                    MsgBox("!!! ERROR - Year Value.  -  " & Yi)
                    Exit Sub
                End If
                UpdatePromisedSuppDate()
            Case 29
                UpdatePoItemNotes()
        End Select

    End Sub

    Private Sub dgPO_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPO.CellEnter
        If e.RowIndex < 0 Then
            Return
        Else
            RowPO = e.RowIndex
        End If
    End Sub

    Private Sub dgPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPO.DataError
        REM end
    End Sub

    Sub UpdatePoItemStatus()

        If IsDBNull(dgPO("ChkPoItemStatus", RowPO).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePOItemStatusClose", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgPO("PODetailID", RowPO).Value
        mySqlComm.Parameters.Add(paraID)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Close PO Item Status: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdatePromisedSuppDate()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePOItemPromissedDate", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgPO("PODetailID", RowPO).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraDate As SqlParameter = New SqlParameter("@POPromisedDate", SqlDbType.SmallDateTime, 4)
        paraDate.Value = dgPO("POPromisedDate", RowPO).Value
        mySqlComm.Parameters.Add(paraDate)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO Item Promissed Date: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdatePoItemNotes()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePOItemLACNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraID.Value = dgPO("PODetailID", RowPO).Value
        mySqlComm.Parameters.Add(paraID)

        Dim paraDate As SqlParameter = New SqlParameter("@PONotesLAC", SqlDbType.NVarChar, 500)
        paraDate.Value = dgPO("PONotesLAC", RowPO).Value
        mySqlComm.Parameters.Add(paraDate)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update PO Item LAC Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Function RoleSubAnalyze(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SUBAZ" Then
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

End Class