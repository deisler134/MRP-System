Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOrderEntryPutBCAYearPrice

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private ds As New DataSet
    Private da As New SqlDataAdapter

    Dim strSQL As String
    Dim GridRow As Integer

    Private Sub frmOrderEntryPutBCAYearPrice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        da.Dispose()
        ds.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmOrderEntryPutBCAYearPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        ds.Clear()

        If Len(Trim(txtSW.Text)) <> 0 Then
            PutQuotePartNumber(txtSW.Text)

            With Me.YearNo
                .DataPropertyName = "YearNo"
                .Name = "YearNo"
            End With

            With Me.PriceValue
                .DataPropertyName = "PriceValue"
                .Name = "PriceValue"
            End With

            With Me.PartNumber
                .DataPropertyName = "PartNumber"
                .Name = "PartNumber"
            End With

            With Me.PartPriceID
                .DataPropertyName = "PartPriceID"
                .Name = "PartPriceID"
            End With

            dgGrid.AutoGenerateColumns = False
            dgGrid.DataSource = ds
            dgGrid.DataMember = "tblSelect"
        End If

    End Sub

    Sub PutQuotePartNumber(ByVal SwRow As Integer)

        Dim cmdSql = New SqlCommand()
        cmdSql.Connection = cn
        cmdSql.CommandType = CommandType.StoredProcedure
        cmdSql.CommandText = "getTblOrderEntryPutBCAPrice"

        da.SelectCommand = cmdSql

        Dim parameterPoNum As New SqlParameter("@ParamNo", SqlDbType.Int, 4)
        parameterPoNum.Value = SwRow
        da.SelectCommand.Parameters.Add(parameterPoNum)

        da.Fill(ds, "tblSelect")

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
        'frmOrderEntry.dgItem("OrdItemQty", I).Value = Me.dgGrid("QQty", GridRow).Value
        frmOrderEntry.dgItem("OrdItemPrice", I).Value = Me.dgGrid("PriceValue", GridRow).Value
        'frmOrderEntry.dgItem("OrdItemQNO", I).Value = Me.dgGrid("QNO", GridRow).Value
        Me.Close()
    End Sub
End Class