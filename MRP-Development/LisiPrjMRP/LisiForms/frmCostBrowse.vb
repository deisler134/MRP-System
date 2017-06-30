Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCostBrowse

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
   
    Dim CallClass As New clsCommon

    Dim ds As New DataSet
    Dim daPart As New SqlDataAdapter
    Dim daCost As New SqlDataAdapter
    Dim daQty As New SqlDataAdapter

    Private Sub frmCostBrowse_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds.Dispose()
        daPart.Dispose()
        daCost.Dispose()
        daQty.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmCostBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds.Clear()
        ds.Relations.Clear()

        daPart = CallClass.PopulateDataAdapter("gettblPartMaster")
        daCost = CallClass.PopulateDataAdapter("getTblCostAll")
        daQty = CallClass.PopulateDataAdapter("getTblCostEstimationQty")

        daPart.Fill(ds, "tblPartMaster")
        daCost.Fill(ds, "tblCostEstimation")
        daQty.Fill(ds, "tblCostEstimationQty")

        With ds
            .Relations.Add("PartCost", _
              .Tables("tblPartMaster").Columns("PartID"), _
            .Tables("tblCostEstimation").Columns("PartID"))
        End With

        With ds
            .Relations.Add("CostQty", _
              .Tables("tblCostEstimation").Columns("CostID"), _
            .Tables("tblCostEstimationQty").Columns("CostID"), True)
        End With

        ds.Tables("tblPartMaster").Columns("CustSourceID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblPartMaster").Columns("PartID").ColumnMapping = MappingType.Hidden

        ds.Tables("tblCostEstimation").Columns("CostID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblCostEstimation").Columns("PartID").ColumnMapping = MappingType.Hidden

        ds.Tables("tblCostEstimationQty").Columns("CostQtyID").ColumnMapping = MappingType.Hidden
        ds.Tables("tblCostEstimationQty").Columns("CostID").ColumnMapping = MappingType.Hidden

        dg.ReadOnly = True
        dg.DataSource = ds

    End Sub
End Class