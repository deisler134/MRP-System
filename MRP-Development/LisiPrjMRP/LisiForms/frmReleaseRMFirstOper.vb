Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmReleaseRMFirstOper

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim IReturn As Integer = 0
    Dim SwDeptWhat As String = ""


    Private Sub frmReleaseRMFirstOper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetUp()

    End Sub

    Sub SetUp()

        txtOper.Text = ""
        txtDescr.Text = ""
        txtSpec.Text = ""
        'txtMatl.Text = ""
        'txtUser.Text = ""
        CmbDept.Text = ""

        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartmentRMFirstOper").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

        CmdExec.Enabled = False

    End Sub

    Private Sub txtOper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOper.GotFocus
        Call SetUp()
    End Sub

    Private Sub txtOper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOper.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            Call TakeDescr()

            IReturn = InStr(txtDescr.Text, "MAT", vbTextCompare)

            If InStr(txtDescr.Text, "MAT", vbTextCompare) = 0 Then
                MsgBox("!!! ERROR !!! Operation Number.")
                Exit Sub
            Else
                txtUser.Focus()
                CmdExec.Enabled = True
            End If
        End If

    End Sub

    Sub TakeDescr()

        Dim swMpo As Integer = 0
        Dim getInfo As String = ""

        txtDescr.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodOper", SwMPOId.Text, txtOper.Text)
        txtSpec.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodSpec", SwMPOId.Text, txtOper.Text)

    End Sub

    Sub VerifyEmpInRouting()

        ' if the operator exit in one operation open
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspRouteCheckExistMPOAndOper", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMpoID.Text
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = Val(txtOper.Text)
        mySqlComm.Parameters.Add(paraOperNo)

        '=================
        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.Int, 4)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, Integer)
            Else
                IReturn = 0
            End If
            cn.Close()
        Catch ex As SqlException
            MsgBox("Verify MPO and Oper in Routing: " & ex.Message)
            cn.Close()
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Private Sub CmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExec.Click

        CmdExec.Enabled = False
        SwDeptWhat = ""
        If txtMatl.Text = "Coils" Then
            SwDeptWhat = "COLDF"
        Else
            SwDeptWhat = "CUT"
        End If

        UpdateRouteEndException()

        VerifyEmpInRouting()
        If IReturn = 0 Then     'there is no oper open with mpo and emp in routing
            AddStartEndOper()
        Else
            MsgBox("!!! ERROR !!! Operation already exist in routing.")
        End If
    End Sub

    Sub UpdateRouteEndException()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteEndCaseException", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMPOId.Text
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = 1
        mySqlComm.Parameters.Add(paraOperNo)

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("UpdateRouteEndException - Module - frmReleaseRMFirstOper: " & ex.Message)
            cn.Close()
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub AddStartEndOper()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteAddOperStartEnd", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMPOId.Text
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = Val(txtOper.Text)
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDeptID As SqlParameter = New SqlParameter("@SwDeptID", SqlDbType.Int, 4)
        paraDeptID.Value = CmbDept.SelectedValue
        mySqlComm.Parameters.Add(paraDeptID)

        Dim paraEmpID As SqlParameter = New SqlParameter("@SwEmpID", SqlDbType.Int, 4)
        paraEmpID.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmpID)

        Dim paraDeptWhat As SqlParameter = New SqlParameter("@DeptWhat", SqlDbType.NVarChar, 20)
        paraDeptWhat.Value = SwDeptWhat
        mySqlComm.Parameters.Add(paraDeptWhat)

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Add Operation Start: " & ex.Message)
            cn.Close()
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

End Class