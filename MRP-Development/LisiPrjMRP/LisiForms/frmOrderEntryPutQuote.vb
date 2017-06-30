Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOrderEntryPutQuote

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim strSQL As String
    Dim GridRow As Integer

    Private Sub frmOrderEntryPutQuote_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        da.Dispose()
        ds.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmOrderEntryPutQuote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        ds.Clear()

        If Len(Trim(txtSW.Text)) <> 0 Then
            PutQuotePartNumber(txtSW.Text)

            With Me.QNO
                .DataPropertyName = "QNO"
                .Name = "QNO"
            End With

            With Me.QDate
                .DataPropertyName = "QDate"
                .Name = "QDate"
            End With

            With Me.QQTy
                .DataPropertyName = "QQTy"
                .Name = "QQTy"
            End With

            With Me.QQuotedPrice
                .DataPropertyName = "QQuotedPrice"
                .Name = "QQuotedPrice"
            End With

            With Me.PartNumber
                .DataPropertyName = "PartNumber"
                .Name = "PartNumber"
            End With

            With Me.QID
                .DataPropertyName = "QID"
                .Name = "QID"
                .Visible = False
            End With

            dgGrid.AutoGenerateColumns = False
            dgGrid.DataSource = ds
            dgGrid.DataMember = "tblQuote"
        End If

    End Sub

    Sub PutQuotePartNumber(ByVal SwRow As Integer)

        Dim cmdSql = New SqlCommand()
        cmdSql.Connection = cn
        cmdSql.CommandType = CommandType.StoredProcedure
        cmdSql.CommandText = "getTblOrderEntryPutQuotePart"

        da.SelectCommand = cmdSql

        Dim parameterPoNum As New SqlParameter("@ParamNo", SqlDbType.Int, 4)
        parameterPoNum.Value = SwRow
        da.SelectCommand.Parameters.Add(parameterPoNum)

        da.Fill(ds, "tblQuote")
       
    End Sub

    Private Sub dgGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGrid.CellClick
        GridRow = e.RowIndex
    End Sub

    Private Sub dgGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgGrid.DoubleClick
        If GridRow < 0 Then
            Exit Sub
        End If

        Dim I As Integer
        I = CInt(txtRow.Text)
        frmOrderEntry.dgItem("OrdItemQty", I).Value = Me.dgGrid("QQty", GridRow).Value
        frmOrderEntry.dgItem("OrdItemPrice", I).Value = Me.dgGrid("QQuotedPrice", GridRow).Value
        frmOrderEntry.dgItem("OrdItemQNO", I).Value = Me.dgGrid("QNO", GridRow).Value
        Me.Close()
    End Sub
End Class