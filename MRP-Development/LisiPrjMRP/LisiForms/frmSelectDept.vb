Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSelectDept

    Inherits System.Windows.Forms.Form

    Dim CallClass As New clsCommon
    Dim cn As New SqlConnection(strConnection)

    Dim SwClose As Boolean = True
    Private dsSrc As New DataSet

    Private Sub frmSelectDept_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = SwClose
        dsSrc.Dispose()
        Me.Dispose()
    End Sub

    Private Sub frmSelectDept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dsSrc.Clear()

        CallClass.PopulateDataAdapter("getDepartmentNodeForMoveNext").Fill(dsSrc, "tmpDept")

        With Me.DeptID
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
            .Visible = False
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.DeptBarCode
            .DataPropertyName = "DeptBarCode"
            .Name = "DeptBarCode"
            .Visible = False
        End With

        dgSearch.AutoGenerateColumns = False
        dgSearch.DataSource = dsSrc
        dgSearch.DataMember = "tmpDept"

        SwClose = True
    End Sub

    Private Sub dgSearch_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgSearch.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0, 2
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgSearch_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSearch.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 1 Then
            frmFPReleaseToMPO.txtDeptSelected.Text = dgSearch.Rows(e.RowIndex).Cells("DeptNode").Value
            frmFPReleaseToMPO.SwDeptID.Text = dgSearch.Rows(e.RowIndex).Cells("DeptID").Value
            frmFPReleaseToMPO.SwDeptWhat.Text = dgSearch.Rows(e.RowIndex).Cells("DeptBarCode").Value
            dsSrc.Dispose()
            SwClose = False
            Me.Close()
        End If

    End Sub

    Private Sub dgSearch_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSearch.DataError
        REM end
    End Sub

End Class