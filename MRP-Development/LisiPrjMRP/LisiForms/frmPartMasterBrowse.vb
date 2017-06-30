Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frmPartMasterBrowse

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim cmm As CurrencyManager

    Dim CallClass As New clsCommon

    Dim ds As New DataSet
    Dim daPart As New SqlDataAdapter
    Dim daRev As New SqlDataAdapter
    Dim daMfg As New SqlDataAdapter

    Private Sub frmPartMasterBrowse_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds.Dispose()
        daPart.Dispose()
        daRev.Dispose()
        daMfg.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub


    Private Sub frmPartMasterBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        ds.Clear()
        ds.Relations.Clear()

        daPart = CallClass.PopulateDataAdapter("getTblPartMasterBrowse")
        daRev = CallClass.PopulateDataAdapter("getTblPartRev")
        daMfg = CallClass.PopulateDataAdapter("getTblPartMfgSpec")

        daPart.Fill(ds, "tblPartMaster")
        daRev.Fill(ds, "tblPartRev")
        daMfg.Fill(ds, "tblPartMfgSpec")

        ds.EnforceConstraints = False

        With ds
            .Relations.Add("PartRev", _
              .Tables("tblPartMaster").Columns("PartID"), _
            .Tables("tblPartRev").Columns("PartID"), True)
        End With

        With ds
            .Relations.Add("PartMfg", _
              .Tables("tblPartMaster").Columns("PartID"), _
            .Tables("tblPartMfgSpec").Columns("PartID"), True)
        End With

        ds.Tables("tblPartMaster").Columns("CustSourceID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblPartMaster").Columns("PartID").ColumnMapping = MappingType.Hidden

        ds.Tables("tblPartRev").Columns("PartRevID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblPartRev").Columns("PartID").ColumnMapping = MappingType.Hidden

        ds.Tables("tblPartMfgSpec").Columns("MfgSpecID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblPartMfgSpec").Columns("PartID").ColumnMapping = MappingType.Hidden

        dg.ReadOnly = True
        dg.DataSource = ds

    End Sub
End Class