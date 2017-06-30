Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmPORemarks

    Inherits System.Windows.Forms.Form

    Dim cnSqlServer As New SqlConnection(strConnection)

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim dvFilter As String ' Used for filtering dataview 
    Dim dv As New DataView ' For filtering Datagrid 

    Dim currRemark As CurrencyManager

    Dim strSQL As String
    Dim tempText As String

    Private Sub frmPORemarks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ds.Dispose()
        da.Dispose()
        dv.Dispose()
        Me.Dispose()
        cnSqlServer.Close()

        GC.Collect()
    End Sub

    Private Sub frmPORemark_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        tempText = frmPOMaster.txtPORemarks.Text

        Connect()

        da.FillSchema(ds, SchemaType.Source, "tblPORemarks")
        da.Fill(ds, "tblPORemarks")

        ds.EnforceConstraints = False

        currRemark = CType(BindingContext(ds, "tblPORemarks"), CurrencyManager)

        With Me.RemarkID
            .DataPropertyName = "RemarkID"
            .Name = "RemarkID"
        End With

        With Me.RemarkText
            .DataPropertyName = "RemarkText"
            .Name = "RemarkText"
        End With

        dg.AutoGenerateColumns = False
        dg.DataSource = ds
        dg.DataMember = "tblPORemarks"


        ButtProc.Checked = True

        dvFilter = " RemarkType = '" & "Proc" & "'"

        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

        Call BindFields()

    End Sub

    Private Function BindFields() As Boolean

        txtNotes.DataBindings.Add("Text", dv, "RemarkText")
        txtNotes.ReadOnly = True
    End Function

    Private Function Connect() As Boolean

        strSQL = "Select * FROM tblPORemarks Order by RemarkText"

        Try
            Dim commRemark As New SqlClient.SqlCommand(strSQL, cnSqlServer)

            da.SelectCommand = commRemark

            da.AcceptChangesDuringFill = True
            da.TableMappings.Add("Table", "tblPORemarks")
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - Connect Fuction  " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub frmPORemark_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ds.Dispose()
        da.Dispose()
        dv.Dispose()
        Me.Dispose()

    End Sub

    Private Sub ButtProc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtProc.CheckedChanged
        dvFilter = " RemarkType = '" & "Proc" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub ButtMat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtMat.CheckedChanged
        dvFilter = " RemarkType = '" & "Mat" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub ButtShip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtShip.CheckedChanged
        dvFilter = " RemarkType = '" & "Ship" & "'"
        dv.Table = ds.Tables("tblPORemarks")
        dv.RowFilter = dvFilter

        dg.DataSource = dv

    End Sub

    Private Sub dg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick

        If e.ColumnIndex = 0 Then
            If IsDBNull(tempText) = True Or _
                 Len(Trim(tempText)) = 0 Then
                frmPOMaster.txtPORemarks.Text = Me.dg("RemarkText", e.RowIndex).Value
                tempText = Me.dg("RemarkText", e.RowIndex).Value
            Else
                frmPOMaster.txtPORemarks.Text = frmPOMaster.txtPORemarks.Text + vbCrLf
                frmPOMaster.txtPORemarks.Text = frmPOMaster.txtPORemarks.Text + Me.dg("RemarkText", e.RowIndex).Value
            End If
        End If

    End Sub

End Class