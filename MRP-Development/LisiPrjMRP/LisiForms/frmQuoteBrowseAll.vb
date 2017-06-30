Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmQuoteBrowseAll

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim ds As New DataSet
    Dim daPart As New SqlDataAdapter
    Dim daQty As New SqlDataAdapter

    Private Sub frmQuoteBrowseAll_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds.Dispose()
        daPart.Dispose()
        daQty.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmQuoteBrowseAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        ds.Clear()
        ds.Relations.Clear()

        daPart = CallClass.PopulateDataAdapter("getTblQuotePartBrowseAll")
        daPart.Fill(ds, "tblQuoteDetail")

        daQty = CallClass.PopulateDataAdapter("gettblQuoteDetailQtyBrowse")
        daQty.Fill(ds, "tblQuoteDetailQty")

        ds.EnforceConstraints = False

        With ds
            .Relations.Add("PartQty", _
              .Tables("tblQuoteDetail").Columns("QDetailID"), _
            .Tables("tblQuoteDetailQty").Columns("QDetailID"))
        End With

        ds.Tables("tblQuoteDetail").Columns("QDetailID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblQuoteDetail").Columns("QDetPart").ColumnMapping = MappingType.Hidden

        ds.Tables("tblQuoteDetailQty").Columns("QQtyID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblQuoteDetailQty").Columns("QDetailID").ColumnMapping = MappingType.Hidden

        dg.ReadOnly = True
        dg.DataSource = ds

    End Sub
End Class