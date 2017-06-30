Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net


Public Class frmProductionFollowUpProgress

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Dim RowProd As Integer = 0

    Private Sub frmProductionFollowUpProgress_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmProductionFollowUpProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()
        InitialComponents()

        PutCustomer()
        PutPart()
        PutDept()

        SetCtlForm()

        ClearFields()

        txtTechNotes.DataBindings.Clear()
        txtTechNotes.DataBindings.Add("Text", dsMain, "tblMpoMasterTemp.MpoTechNotes")

        txtQANotes.DataBindings.Clear()
        txtQANotes.DataBindings.Add("Text", dsMain, "tblMpoMasterTemp.MpoQANotes")
    End Sub

    Sub ClearFields()

        txtDateTo.Text = ""
        CmbPart.Text = ""
        CmbSelCust.Text = ""
        CmbDept.Text = ""

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        'CallClass.PopulateDataAdapter("getProductionAnalyzeEmpty").Fill(dsMain, "tblMpoMasterTemp")

        dsMain.EnforceConstraints = False

        'PutDataGrid()

    End Sub

    Sub PutDept()

        With Me.CmbDept
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
        End With

    End Sub

    Sub PutCustomer()

        With Me.CmbSelCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomerShort").Tables("tblCustomers")
            .DisplayMember = "CustomerShort"
            .ValueMember = "CustomerShort"
        End With

    End Sub

    Sub PutPart()

        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberForProductionAnalyze").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub SetCtlForm()

    End Sub


    Sub PutDataGrid()

        dgProd.AutoGenerateColumns = False
        dgProd.DataSource = dsMain
        dgProd.DataMember = "tblMpoMasterTemp"

    End Sub


    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        ExecuteSearch()

    End Sub

    Sub ExecuteSearch()

        Dim Par1, Par2, Par3, Par4, Par5, Par6 As String
        Par1 = ""
        Par6 = ""

        Par2 = CmbPart.Text
        Par3 = CmbSelCust.Text

        If Len(Trim(txtDateTo.Text)) = 0 Then
            Par4 = DateAdd(DateInterval.Day, 2500, Date.Now).ToShortDateString()
        Else
            Par4 = txtDateTo.Text
        End If

        Par5 = CmbDept.Text
        'Par6 = txtDeptCode.Text

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Me.Refresh()

        CallClass.PopulateDataAdapterSearch6Param("getProductionAnalyzeSelection", Par1, Par2, Par3, Par4, Par5, Par6).Fill(dsMain, "tblMpoMaster")

        DisplayData()

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        ClearFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub DisplayData()

    End Sub

End Class