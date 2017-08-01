Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSalesCancelDelivReq

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private Sub frmSalesCancelDelivReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetupForm()

    End Sub

    Sub SetupForm()
        GC.Collect()
        ClearFields()
        SetCtlVisible(False)
    End Sub

    Sub ClearFields()

        txtPslipNo.Text = ""
        txtInvPosted.Text = ""
        txtPslipType.Text = ""
        txtPslipNo.Focus()

    End Sub

    Sub SetCtlVisible(state As Boolean)

        cmdExecute.Enabled = state
        Panel1.Visible = state

    End Sub

    Private Sub txtPslipNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPslipNo.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim strSearch As String
            If Len(Trim(txtPslipNo.Text)) = 0 Then
                MsgBox("Please input the Request Number.")
                txtPslipNo.Focus()
                Exit Sub
            Else
                strSearch = txtPslipNo.Text
            End If

            Dim mySqlComm As New Data.SqlClient.SqlCommand("gettblLisiPslipQueries", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure
            mySqlComm.Parameters.Add(New SqlParameter("@Par1", strSearch))
            Dim myReader As Data.SqlClient.SqlDataReader

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                myReader = mySqlComm.ExecuteReader()
                Dim TestRec As Int16
                TestRec = myReader.HasRows
                If TestRec <> -1 Then
                    MsgBox("Input the Request Number is wrong!")
                    ClearFields()
                    SetCtlVisible(False)
                Else
                    Dim strPslipType As String = ""
                    Dim strInvPosted As String = ""
                    While myReader.Read()
                        strInvPosted = Trim(myReader.GetValue(0).ToString)
                        strPslipType = Trim(myReader.GetValue(1).ToString)
                    End While
                    If StrComp(strInvPosted, "") = 0 And StrComp(strPslipType, "REQ") = 0 Then
                        SetCtlVisible(True)
                        txtInvPosted.Text = "NULL"
                        txtPslipType.Text = strPslipType
                    Else
                        txtInvPosted.Text = strInvPosted
                        txtPslipType.Text = strPslipType
                        SetCtlVisible(True)
                        cmdExecute.Enabled() = False
                        Dim reply As DialogResult
                        reply = MsgBox("The ReqNumber had closed or cann't cancel." & vbCrLf & "Cancel another REQ or exit?", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            ClearFields()
                            SetCtlVisible(False)
                        Else
                            myReader.Close()
                            myReader.Dispose()
                            Me.Close()
                        End If
                    End If
                    myReader.Close()
                    myReader.Dispose()
                End If

            Catch ex As Exception
                MsgBox("Exception occured - QueryReqNumber   " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

        End If

    End Sub


    Private Sub cmdExecute_Click(sender As Object, e As EventArgs) Handles cmdExecute.Click
        
        Dim strSearch As String

        If Len(Trim(txtPslipNo.Text)) = 0 Then
            MsgBox("Please input the Request Number.")
            txtPslipNo.Focus()
            Exit Sub
        Else
            strSearch = Trim(txtPslipNo.Text)
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePOReceiving", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@Par1", strSearch))

        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            If mySqlComm.ExecuteNonQuery() <= 0 Then
                MsgBox("Execute fail.Please try again.")
                ClearFields()
                SetCtlVisible(False)
            End If


            Dim mySqlComm1 As New Data.SqlClient.SqlCommand("gettblLisiPslipQueries", cn)
            mySqlComm1.CommandType = CommandType.StoredProcedure
            mySqlComm1.Parameters.Add(New SqlParameter("@Par1", strSearch))
            Dim myReader1 As Data.SqlClient.SqlDataReader


            myReader1 = mySqlComm1.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader1.HasRows
            If TestRec <> -1 Then
                MsgBox("Execute fail. Please try again.")
                ClearFields()
                SetCtlVisible(False)
            Else
                Dim strPslipType As String = ""
                Dim strInvPosted As String = ""
                While myReader1.Read()
                    strInvPosted = Trim(myReader1.GetValue(0).ToString)
                    strPslipType = Trim(myReader1.GetValue(1).ToString)
                End While
                If StrComp(strInvPosted, "P") = 0 And StrComp(strPslipType, "Close") = 0 Then
                    txtInvPosted.Text = strInvPosted
                    txtPslipType.Text = strPslipType
                    Dim reply As DialogResult
                    reply = MsgBox("The request has Closed." & vbCrLf & "Cancel another REQ or exit?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        ClearFields()
                        SetCtlVisible(False)
                    Else
                        Me.Close()
                        Exit Sub
                    End If
                Else
                    MsgBox("Execute fail.Please try again.")
                    ClearFields()
                    SetCtlVisible(False)
                End If
            End If

        Catch ex As SqlException
            MsgBox("Exception occured - UpdateReqNumber " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub frmSalesCancelDelivReq_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Me.Dispose()
        GC.Collect()

    End Sub

End Class