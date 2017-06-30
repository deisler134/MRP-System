Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmLogin
    'Inherits System.Windows.Forms.Form

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserID.Focus()
        GC.Collect()
    End Sub

    Private Sub txtUserID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtUserID.Text.Length < 4 Then
                MessageBox.Show("User ID: Value you entered is not valid;" _
                    & " it must be at least 4 characters.")
                txtUserID.Focus()
            Else
                txtPassword.Focus()
            End If
        End If
    End Sub


    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text.Length < 4 Then
                MessageBox.Show("User Password: Value you entered is not valid;" _
                 & " it must be at least 4 characters.")
                txtPassword.Focus()
            Else
                Dim SqlStr As String
                SqlStr = "SELECT * FROM tblEmployee " _
                        & "WHERE (EmpUserID = '" & txtUserID.Text & "') AND (EmpPassword = '" & txtPassword.Text & "')"

                Dim mySqlConn As New Data.SqlClient.SqlConnection(strConnection)
                Dim mySqlComm As New Data.SqlClient.SqlCommand(SqlStr, mySqlConn)
                Dim myReader As Data.SqlClient.SqlDataReader

                Try
                    If mySqlConn.State = ConnectionState.Open Then
                        mySqlConn.Close()
                    End If
                    mySqlConn.Open()
                    myReader = mySqlComm.ExecuteReader()

                    Dim TestRec As Int16
                    TestRec = myReader.HasRows
                    If TestRec <> -1 Then
                        MessageBox.Show("Access Denied. User Can't be identified.")
                        End
                    Else
                        While myReader.Read()
                            If myReader.GetValue(3) = "1" Then
                                MessageBox.Show("Access Denied. Permision Ended.")
                                End
                            Else
                                wkEmpId = myReader.GetValue(0)
                                wkEmpLogin = myReader.GetValue(1)
                                wkName = myReader.GetString(6)
                                wkAccess = myReader.GetValue(4)
                                wkDeptCode = myReader.GetString(5)
                                wkEmpEmail = myReader.GetString(8)
                                wkEmpDept = myReader.GetString(10)
                            End If
                        End While
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    If mySqlConn.State = ConnectionState.Open Then
                        mySqlConn.Close()
                    End If
                Finally
                    If mySqlConn.State = ConnectionState.Open Then
                        mySqlConn.Close()
                    End If

                    frmMenu.ShowDialog()
                    Me.Dispose()

                End Try
            End If
        End If
    End Sub

    Private Sub txtUserID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserID.Leave
        If txtUserID.Text.Length < 4 Then
            MessageBox.Show _
             ("User ID: Value you entered is not valid;" _
                & " it must be at least 4 characters.")
            txtUserID.Focus()
        End If
    End Sub

    Private Sub txtpassword_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Leave
        If txtPassword.Text.Length < 4 Then
            MessageBox.Show _
             ("User Password: Value you entered is not valid;" _
                & " it must be at least 4 characters.")
            txtPassword.Focus()
        End If
    End Sub

End Class
