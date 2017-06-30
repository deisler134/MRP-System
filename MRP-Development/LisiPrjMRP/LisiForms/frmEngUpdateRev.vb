Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmEngUpdateRev



    Inherits System.Windows.Forms.Form
    Dim CallClass As New clsCommon

    Dim SwExec As Boolean = False

    Private Sub frmEngUpdateRev_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Stop()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmEngUpdateRev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Start()
        InitParam()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txtClock.Text = Now.ToLongTimeString
    End Sub

    Private Sub CmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUpdate.Click

        If Len(Trim(txtPrefix.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Part Number Prefix.")
            Exit Sub
        End If

        If Len(txtRevNo.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Revision Number.")
            Exit Sub
        End If

        If Len(cmbRevDate.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Revision Date.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        SwExec = False

        Dim SwDate As String = ""
        SwDate = Now.ToShortDateString

        SwExec = CallClass.ExecuteUpdate5Params("cspUpdateRevisionByPartsFamily", Trim(txtPrefix.Text), Trim(txtRevNo.Text), cmbRevDate.Text, Trim(txtRevDescr.Text), Trim(txtRevNotes.Text))


        If SwExec = True Then
            MsgBox("Successfully Updated .")
        Else
            MsgBox("!!! ERROR !!! Update Unsuccessfully")
        End If

        Me.Cursor = Cursors.Default

        InitParam()

    End Sub

    Sub InitParam()

        txtPrefix.Text = ""
        txtRevNo.Text = ""
        cmbRevDate.Text = Now.ToShortDateString
        txtRevDescr.Text = ""
        txtRevNotes.Text = ""

    End Sub
End Class