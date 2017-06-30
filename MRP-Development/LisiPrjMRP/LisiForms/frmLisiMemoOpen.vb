Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmLisiMemoOpen

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean = False

    Sub VallFunction()

        SwVal = False
        Dim GetInfo As String = ""

        If CmbMemo.Text = "" Or Len(Trim(CmbMemo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! MEMO number is empty.")
            SwVal = False
            Exit Sub
        End If

        If txtObs.Text = "" Or Len(Trim(txtObs.Text)) = 0 Then
            MsgBox("!!! ERROR !!! NOTES text is empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub frmLisiMemoOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.CmbMemo
            .DataSource = CallClass.PopulateComboBox("tblMemo", "cmbGetMemoNo").Tables("tblMemo")
            .DisplayMember = "MemoNo"
            .ValueMember = "MemoId"
        End With

        CmbMemo.SelectedValue = SwMemoId.Text

        CmdOpenCall.Enabled = True

    End Sub

    Sub UpdateMEMOStatus()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMEMOStatusReOpen", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMEMO As SqlParameter = New SqlParameter("@MemoID", SqlDbType.Int, 4)
        paraMEMO.Value = SwMemoId.Text
        mySqlComm.Parameters.Add(paraMEMO)

        Dim paraNotes As SqlParameter = New SqlParameter("@SrText", SqlDbType.NVarChar, 1000)
        paraNotes.Value = txtObs.Text
        mySqlComm.Parameters.Add(paraNotes)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! MEMO Re-Open status: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub CmdOpenCall_Click(sender As Object, e As EventArgs) Handles CmdOpenCall.Click
        Call VallFunction()

        If SwVal = True Then
            UpdateMEMOStatus()
            frmLisiMemoApp.CmbMemo.Enabled = False

            MsgBox("Update successfully.")

        End If

        Me.Close()

    End Sub

End Class