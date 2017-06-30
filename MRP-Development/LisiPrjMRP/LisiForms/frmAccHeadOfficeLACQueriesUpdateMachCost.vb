Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmAccHeadOfficeLACQueriesUpdateMachCost

    Inherits System.Windows.Forms.Form

    Dim CallClass As New clsCommon
    Dim cn As New SqlConnection(strConnection)

    Private dsSrc As New DataSet

    Dim strSQL As String
    Dim RowTrav As Integer = 0

    Dim OldQty As Integer

    Private Sub frmAccHeadOfficeLACQueriesUpdateMachCost_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
        Catch ex As Exception
            MsgBox("Exception occured - Closing Form  " & ex.Message)
        End Try

        GC.Collect()
    End Sub

    Private Sub frmAccHeadOfficeLACQueriesUpdateMachCost_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        dsSrc.Clear()

        Dim strSearch As String

        strSearch = txtMPOID.Text
        CallClass.PopulateAdapterAfterSearchInt("getAccHeadOfficeLACQueriesUpdateMachCost", strSearch).Fill(dsSrc, "tblMach")

        With Me.TrOperNo
            .DataPropertyName = "TrOperNo"
            .Name = "TrOperNo"
        End With

        With Me.TrOperDescr
            .DataPropertyName = "TrOperDescr"
            .Name = "TrOperDescr"
        End With

        With Me.TrDeptHrRate
            .DataPropertyName = "TrDeptHrRate"
            .Name = "TrDeptHrRate"
        End With

        With Me.QtyAccTemp
            .DataPropertyName = "QtyAccTemp"
            .Name = "QtyAccTemp"
        End With

        With Me.TotalTime
            .DataPropertyName = "TotalTime"
            .Name = "TotalTime"
        End With

        With Me.TrMachCost
            .DataPropertyName = "TrMachCost"
            .Name = "TrMachCost"
        End With

        With Me.TrMpoID
            .DataPropertyName = "TrMpoID"
            .Name = "TrMpoID"
            .Visible = False
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
            .Visible = False
        End With

        dgTrav.AutoGenerateColumns = False
        dgTrav.DataSource = dsSrc
        dgTrav.DataMember = "tblMach"

    End Sub

    Private Sub dgTrav_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgTrav.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowTrav = e.RowIndex
        End If

        OldQty = Nz.Nz(dgTrav("QtyAccTemp", e.RowIndex).Value)

        Select Case e.ColumnIndex
            Case 0 To 2
                e.Cancel = True
            Case 4 To 6
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgTrav_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTrav.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            RowTrav = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 3
                Dim reply As DialogResult
                reply = MsgBox("Edit Quantity Accepted ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then

                    UpdateQtyAccepted()
                    UpdateMpoNotes()

                    Dim strSearch As String = txtMPOID.Text
                    Try
                        'we can not use it ---Refresh Machining Cost Value for the same Operation Grouped By Operation Last Update
                        'UpdateMachCostPerOperGrouped()

                        dsSrc.Clear()
                        CallClass.PopulateAdapterAfterSearchInt("getAccHeadOfficeLACQueriesUpdateMachCost", strSearch).Fill(dsSrc, "tblMach")
                        dgTrav.AutoGenerateColumns = False
                        dgTrav.DataSource = dsSrc
                        dgTrav.DataMember = "tblMach"
                        Me.Refresh()

                    Catch ex As Exception
                    End Try
                Else
                    dgTrav("QtyAccTemp", RowTrav).Value = OldQty
                End If
        End Select

    End Sub

    Private Sub dgTrav_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgTrav.DataError
        REM end
    End Sub

    Sub UpdateQtyAccepted()

        If IsDBNull(dgTrav("QtyAccTemp", RowTrav).Value) = True Then
            Exit Sub
        Else
            If Nz.Nz(dgTrav("QtyAccTemp", RowTrav).Value) = 0 Then
                Exit Sub
            End If
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccHeadOfficeLACQueriesMachCost", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@TrMpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgTrav("TrMpoID", RowTrav).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraQty As SqlParameter = New SqlParameter("@QtyAccTemp", SqlDbType.Int, 4)
        paraQty.Value = dgTrav("QtyAccTemp", RowTrav).Value
        mySqlComm.Parameters.Add(paraQty)

        Dim paraOper As SqlParameter = New SqlParameter("@TrOperNo", SqlDbType.Int, 4)
        paraOper.Value = dgTrav("TrOperNo", RowTrav).Value
        mySqlComm.Parameters.Add(paraOper)

        Dim paraRate As SqlParameter = New SqlParameter("@TrDeptHrRate", SqlDbType.SmallMoney, 4)
        paraRate.Value = dgTrav("TrDeptHrRate", RowTrav).Value
        mySqlComm.Parameters.Add(paraRate)

        Dim paraTime As SqlParameter = New SqlParameter("@TotalTime", SqlDbType.Int, 4)
        paraTime.Value = dgTrav("TotalTime", RowTrav).Value
        mySqlComm.Parameters.Add(paraTime)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Routing Quantity: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoNotes()

        If IsDBNull(dgTrav("QtyAccTemp", RowTrav).Value) = True Then
            Exit Sub
        Else
            If Nz.Nz(dgTrav("QtyAccTemp", RowTrav).Value) = 0 Then
                Exit Sub
            End If
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateAccHeadOfficeLACQueriesMpoNotes", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
        paraMpo.Value = dgTrav("TrMpoID", RowTrav).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim txtMpoNotes As String = ""
        Dim paraNotes As SqlParameter = New SqlParameter("@MPONotes", SqlDbType.NVarChar, 2000)
        txtMpoNotes = dgTrav("MpoNotes", RowTrav).Value + vbCrLf + "MPO Routing Qty. was changed for the operation:  " + Str(dgTrav("TrOperNo", RowTrav).Value)
        paraNotes.Value = txtMpoNotes
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update MPO Notes: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

End Class