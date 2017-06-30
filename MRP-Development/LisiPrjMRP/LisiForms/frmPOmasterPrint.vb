Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmPOMasterPrint

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

        GC.Collect()

        With CrystalReportViewer1
            .ShowGroupTreeButton = False
            .ShowRefreshButton = True
            .Zoom(2)
        End With
    End Sub

    Private Sub frmPOMasterPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CrystalReportViewer1.DisplayToolbar = True

        GC.Collect()

    End Sub

    Private Sub frmPOMasterPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()
    End Sub
End Class