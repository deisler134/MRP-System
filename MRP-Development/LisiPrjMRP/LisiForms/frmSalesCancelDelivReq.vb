Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSalesCancelDelivReq

    Inherits System.Windows.Forms.Form

    'Dim mySqlComm As New Data.SqlClient.SqlCommand
    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daPslip As New SqlDataAdapter


    Dim CallClass As New clsCommon

    Dim strSQL As String
    Dim VerReq As Integer = 9    '0=serach ok, 1 = posted, 9=search wrong

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

    Private Sub cmdExecute_Click(sender As Object, e As EventArgs) Handles cmdExecute.Click
        'strSQL = "UPDATE tblLisiPslip SET InvPosted = 'P', PSlipType = 'Close' WHERE ((tblLisiPslip.PslipNo)= '" & txtPslipNo.Text & "')"
        'Dim mySqlConn As New Data.SqlClient.SqlConnection(strConnection)
        'Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, mySqlConn)
        'Dim myReader As Data.SqlClient.SqlDataReader

        'Try
        '    If mySqlConn.State = ConnectionState.Open Then
        '        mySqlConn.Close()
        '    End If
        '    mySqlConn.Open()
        '    myReader = mySqlComm.ExecuteReader()

        '    mySqlComm.Dispose()
        '    myReader.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        '    mySqlConn.Close()
        '    mySqlConn.Dispose()
        '    End
        'Finally
        '    mySqlConn.Close()
        '    mySqlConn.Dispose()
        'End Try

        'myReader.Read()
        'txtInvPosted.Text = myReader.GetValue(0).ToString
        'txtPslipType.Text = myReader.GetValue(1).ToString

        Dim strSearch As String

        If Len(Trim(txtPslipNo.Text)) = 0 Then
            MsgBox("Please input the Request Number.")
            txtPslipNo.Focus()
            Exit Sub
        Else
            strSearch = Trim(txtPslipNo.Text)
        End If

        Try
            Dim ret As New Boolean
            ret = BuildSqlCommandUpdate1Param("updatetblLisiPslip", strSearch)

            If ret Then
                txtInvPosted.Text = "P"
                txtPslipType.Text = "Close"
                Dim reply As DialogResult
                reply = MsgBox("Cancel another REQ or close?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    ClearFields()
                    SetCtlVisible(False)
                Else
                    Me.Close()
                    Exit Sub
                End If
            Else
                MsgBox("Execute fail.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Function BuildSqlCommandQurery1Param(ByVal strGet As String, ByVal Par1 As String) As DataSet
        Dim ds As New DataSet
        Try
            daPslip = PopulateDataAdapterQurery1Param(strGet, Par1)
            daPslip.Fill(ds)
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try
        Return ds
    End Function

    Public Function PopulateDataAdapterQurery1Param(ByVal strGet As String, ByVal Par1 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = cn
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandTimeOut = 1000
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Return da

    End Function

    Private Function BuildSqlCommandUpdate1Param(ByVal strGet As String, ByVal Par1 As String) As Boolean

        Try
            daPslip = PopulateDataAdapterUpdate1Param(strGet, Par1)
            dsMain.Tables("Table").Rows(0)(0) = "P"
            dsMain.Tables("Table").Rows(0)(1) = "Close"
            daPslip.Update(dsMain)
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
            Return False
        Finally
        End Try

        Return True
    End Function

    Public Function PopulateDataAdapterUpdate1Param(ByVal strGet As String, ByVal Par1 As String) As SqlDataAdapter

        Dim da As New SqlDataAdapter
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = cn
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandTimeOut = 1000
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da.UpdateCommand = cmdSQLCommand

        ' Add Parameters 
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.UpdateCommand.Parameters.Add(par11)

        Return da

    End Function

    Private Sub txtPslipNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPslipNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Dim strSearch As String

                If Len(Trim(txtPslipNo.Text)) = 0 Then
                    MsgBox("Please input the Request Number.")
                    txtPslipNo.Focus()
                    Exit Sub
                Else
                    strSearch = Trim(txtPslipNo.Text)
                End If

                Try
                    dsMain.Clear()
                    dsMain = BuildSqlCommandQurery1Param("gettblLisiPslipQueries", strSearch)

                    If dsMain.Tables("Table").Rows.Count < 1 Then
                        MsgBox("Input the Request Number is wrong!")
                        txtPslipNo.Text = ""
                        txtPslipNo.Focus()
                    Else
                        Dim strPslipType As String = ""
                        Dim strInvPosted As String = ""
                        strInvPosted = dsMain.Tables("Table").Rows(0)(0).ToString
                        strPslipType = dsMain.Tables("Table").Rows(0)(1).ToString
                        If StrComp(strInvPosted, "") = 0 And StrComp(strPslipType, "REQ") = 0 Then
                            SetCtlVisible(True)
                            txtInvPosted.Text = "NULL"
                            txtPslipType.Text = strPslipType
                        Else
                            MsgBox("Input the Request Number is wrong!")
                            ClearFields()
                            SetCtlVisible(False)
                        End If
                    End If
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

                'strSQL = "SELECT InvPosted, PSlipType FROM tblLisiPslip WHERE ((tblLisiPslip.PslipNo)= '" & txtPslipNo.Text & "')"
                'Dim mySqlConn As New Data.SqlClient.SqlConnection(strConnection)
                'Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQL, mySqlConn)
                'Dim myReader As Data.SqlClient.SqlDataReader
                'Try
                '    If mySqlConn.State = ConnectionState.Open Then
                '        mySqlConn.Close()
                '    End If

                '    mySqlConn.Open()
                '    myReader = mySqlComm.ExecuteReader()

                '    Dim TestRec As Int16
                '    TestRec = myReader.HasRows
                '    If TestRec <> -1 Then
                '        VerReq = 9
                '        MsgBox("Input the Request Number is wrong!")
                '        txtPslipNo.Text = ""
                '        txtPslipNo.Focus()
                '    Else
                '        Dim strPslipType As String = ""
                '        myReader.Read()

                '        strPslipType = myReader.GetValue(1).ToString
                '        strPslipType = Trim(strPslipType)
                '        If IsDBNull(myReader.GetValue(0)) And StrComp(strPslipType, "REQ") = 0 Then
                '            SetCtlVisible(True)
                '        Else
                '            MsgBox("Input the Request Number is wrong!")
                '            ClearFields()
                '            SetCtlVisible(False)
                '        End If
                '        txtInvPosted.Text = "NULL"
                '        txtPslipType.Text = myReader.GetValue(1).ToString
                '    End If

                '    myReader.Close()
                '    mySqlComm.Dispose()

                '    Me.Refresh()
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                '    mySqlConn.Close()
                '    mySqlConn.Dispose()
                '    End
                'Finally
                '    mySqlConn.Close()
                '    mySqlConn.Dispose()
                'End Try

            End If
        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - txtPslipNo_KeyDown. Please contact the administrator." & ex.Message)
        End Try
    End Sub

    Private Sub frmSalesCancelDelivReq_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dsMain.Clear()
        Me.Dispose()
        GC.Collect()

    End Sub


End Class