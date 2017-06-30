Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPartProcSQL

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim cmm As CurrencyManager

    Dim CallClass As New clsCommon

    Dim dss As New DataSet
    Dim daaPart As New SqlDataAdapter
    Dim daaOper As New SqlDataAdapter

    Dim daMfg As New SqlDataAdapter

    Private Sub frmPartProcSQL_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dss.Dispose()
        daaPart.Dispose()
        daaOper.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmPartProcSQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        dss.Clear()
        dss.Relations.Clear()

        Dim SwPart As String
        SwPart = frmPartProcess.txtPartNo.Text

        If SwIndex.Text = "ALL" Then
            daaPart = CallClass.PopulateDataAdapter("gettblPartProcessSQLAll")
            daaOper = CallClass.PopulateDataAdapter("gettblPartProcessSQLAllOper")
        Else
            If SwIndex.Text = "PART" Then
                daaPart = CallClass.PopulateDataAdapterAfterSearch("gettblPartProcessSQLByPart", SwPart)
                daaOper = CallClass.PopulateDataAdapterAfterSearch("gettblPartProcessSQLOperByPart", SwPart)
            End If
        End If

        daaPart.Fill(dss, "tmpPartSQL")
        daaOper.Fill(dss, "tmpPartSQLOper")

        dss.EnforceConstraints = False

        With dss
            .Relations.Add("PartOperations", _
              .Tables("tmpPartSQL").Columns("ProcID"), _
            .Tables("tmpPartSQLOper").Columns("ProcID"), True)
        End With

        dg.DataSource = dss
        dg.DataMember = "tmpPartSQL"

    End Sub

    Private Sub dg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg.DoubleClick

        If frmPartProcess.SwProc.Text <> "1" Then
            Dim reply As DialogResult
            reply = MsgBox("Do you want to Import the Process Sheet. (Yes/No)?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then
                'skip
            Else
                Dim iRownr As Integer
                iRownr = dg.CurrentCell.RowNumber

                frmPartProcess.SwMpoID.Text = dg.Item(iRownr, 1).ToString

                dss.Dispose()
                daaPart.Dispose()
                daaOper.Dispose()
                Me.Dispose()
            End If
        Else
            MsgBox("Action Denied. Process has been Revised.")
        End If

    End Sub

End Class