Option Strict Off
Option Explicit On

Imports System.Web.Services
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services.Protocols
Imports System.ComponentModel


Public Class wwwcallwebservices

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet


    Private Sub wwwcallwebservices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMethod.Click


        ' Dim OPerItem As New LACLocalHost.GetOperationCollection

        'Dim OPerItem As LACLocalHost.GetOperationCollection = New LACLocalHost.GetOperationCollection

        'Dim Input As LACLocalHost.GetOperationItem = New LACLocalHost.GetOperationItem

        'Dim Input As New LACLocalHost.GetOperationItem
        'With Input
        '    .Company = 100
        '    .Facility = "VDR"
        '    .ProductNumber = 5002806
        '    .ManufacturingOrderNumber = 585678
        '    .OperationNumber = 100
        'End With

        'Dim result As LACLocalHost.GetOperationResponseItem = OPerItem.GetOperationItem(Input)
        'Dim result As String = Input.OperationNumber
        'dgMpo.DataSource = result
        'dgMpo.AutoGenerateColumns = True

    End Sub

    Private Sub dgMpo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellContentClick

    End Sub
End Class