Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmPOAddOperation

    Inherits System.Windows.Forms.Form
    Dim cnSqlServer As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon


    Private Sub frmPOAddOperation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOAddOperation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtOper.Text = ""
        txtDescr.Text = ""
        txtSpec.Text = ""

    End Sub

    Private Sub txtOper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOper.KeyDown

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            Call TakeDescr()
        End If

    End Sub

    Sub TakeDescr()

        Dim swMpo As Integer = 0
        Dim getInfo As String = ""

        txtDescr.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodOper", SwMPOId.Text, txtOper.Text)
        txtSpec.Text = CallClass.ReturnStrWith2ParStr("cspReturnPOItemDescrMethodSpec", SwMPOId.Text, txtOper.Text)
    End Sub

End Class