Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOrderEntryPutM3ITNO

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Private Sub frmOrderEntryPutM3ITNO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Len(Trim(txtM3ITNO.Text)) > 0 Then
            da.Dispose()
            ds.Dispose()

            GC.Collect()
        Else
            MessageBox.Show("!!! ERROR !!! M3 ITNO is Empty!")
            Exit Sub
        End If

    End Sub

    Private Sub frmOrderM3ITNO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        ds.Clear()

        If Len(Trim(txtSW.Text)) <> 0 Then
            txtPart.Text = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", txtSW.Text)
        End If

    End Sub

    Private Sub CmdSave_Click(sender As System.Object, e As System.EventArgs) Handles CmdSave.Click
        If Len(Trim(txtM3ITNO.Text)) > 0 Then
            UpdateITNO()

            Dim I As Integer
            I = CInt(txtRow.Text)
            frmOrderEntry.dgItem("SwM3Article", I).Value = txtM3ITNO.Text

            da.Dispose()
            ds.Dispose()
            GC.Collect()
            Me.Close()
        Else
            MessageBox.Show("!!! ERROR !!! M3 ITNO is Empty!")
        End If

    End Sub

    Sub UpdateITNO()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePartM3ITNO", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPart As SqlParameter = New SqlParameter("@OrdPartID", SqlDbType.Int, 4)
        paraPart.Value = Trim(txtSW.Text)
        mySqlComm.Parameters.Add(paraPart)

        Dim paraITNO As SqlParameter = New SqlParameter("@OrdITNO", SqlDbType.NVarChar, 50)
        paraITNO.Value = Trim(txtM3ITNO.Text)
        mySqlComm.Parameters.Add(paraITNO)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR Update process for M3 ITNO: " & ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

End Class