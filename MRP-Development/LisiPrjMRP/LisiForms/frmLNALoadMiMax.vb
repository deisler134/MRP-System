Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmLNALoadMiMax
    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowProd As Integer = 0

    Dim excelPathName As String
    Dim fName As String

    Private Sub frmLNALoadMiMax_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub


    Private Sub CmdLocation_Click(sender As System.Object, e As System.EventArgs) Handles CmdLocation.Click

        Dim dateNow As New System.DateTime
        dateNow = Date.Today.ToString

        Dim strcon = New SqlConnection(strConnection)
        strcon.open()

        Try
            Dim com As New SqlCommand("drop table MinMaxLoad", strcon)
            com.ExecuteNonQuery()
            MsgBox("Table has been droped")
        Catch ex As Exception
            MsgBox("Can not droped table")
        End Try


        Dim createSql As String
        Try
            Dim tblname = "MinMaxLoad"
            createSql = "CREATE TABLE " & tblname & " ([ID] INT NOT NULL IDENTITY(1,1)," & _
                "[MMPart]                       NVARCHAR (50) NULL," & _
                "[MMWhse]                       NVARCHAR (10) NULL," & _
                "[MMCust_PO]                    NVARCHAR (50) NULL," & _
                "[MMInv_Status]                 NVARCHAR (25) NULL," & _
                "[MMCurrent_Inv]                NVARCHAR (5) NULL," & _
                "[MMMax_Qty]                    NVARCHAR (5) NULL," & _
                "[MMBCA_AMU]                    NVARCHAR (5) NULL," & _
                "[MMUnfulfilled_Demand]         NVARCHAR (5) NULL," & _
                "[MetricEffectiveDate]          NVARCHAR (10) NULL," & _
                "[LastQtyRecd]                  NVARCHAR (5) NULL," & _
                "[DateLastQtyRecd]              NVARCHAR (10) NULL," & _
                "[QtyInTranz]                   NVARCHAR (5) NULL," & _
                "[MMDate_Load]                  SmallDateTime NULL," & _
                "PRIMARY KEY (ID));"

            Dim cmd As New SqlCommand(createSql, strcon)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Dim SwPath As String = "\\srv115fs01\Public\  Outside process - machining\Min Max Extraction for Structure"

        txtFileLocation.Text = SwPath

        Dim fBrowse As New OpenFileDialog
        With fBrowse
            .InitialDirectory = SwPath
            .Filter = "Text files(*.csv)|*.csv|All files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Import data from Text file"
        End With

        If fBrowse.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
        Dim fname As String = fBrowse.FileName

        Try
            Dim parser As New FileIO.TextFieldParser(fname)
            parser.Delimiters = New String() {","} ' fields are separated by comma
            parser.HasFieldsEnclosedInQuotes = True ' each of the values is enclosed with double quotes
            parser.TrimWhiteSpace = True
            parser.ReadLine() 'skip column headers


            Dim strSql As String = "INSERT INTO MinMaxLoad (MMPart, MMWhse, MMCust_PO, MMInv_Status, MMCurrent_Inv, MMMax_Qty, MMBCA_AMU, MMUnfulfilled_Demand, MetricEffectiveDate, LastQtyRecd, DateLastQtyRecd, QtyInTranz, MMDate_Load) " + _
                " VALUES (isnull(@MMPart,''), isnull(@MMWhse,''), isnull(@MMCust_PO,''), isnull(@MMInv_Status,''), isnull(@MMCurrent_Inv,0), isnull(@MMMax_Qty,0), isnull(@MMBCA_AMU,0), isnull(@MMUnfulfilled_Demand,0), isnull(@MetricEffectiveDate,''), CONVERT(nvarchar(5),@LastQtyRecd), isnull(@DateLastQtyRecd,''), isnull(@QtyInTranz,0),  @MMDate_Load) "

            Using cn As New SqlConnection(strConnection), cmd As New SqlCommand(strSql, cn)

                With cmd.Parameters
                    .Add("@MMPart", SqlDbType.VarChar, 50)
                    .Add("@MMWhse", SqlDbType.VarChar, 10)
                    .Add("@MMCust_PO", SqlDbType.VarChar, 50)
                    .Add("@MMInv_Status", SqlDbType.VarChar, 25)
                    .Add("@MMCurrent_Inv", SqlDbType.VarChar, 5)
                    .Add("@MMMax_Qty", SqlDbType.VarChar, 5)
                    .Add("@MMBCA_AMU", SqlDbType.VarChar, 5)
                    .Add("@MMUnfulfilled_Demand", SqlDbType.VarChar, 5)
                    .Add("@MetricEffectiveDate", SqlDbType.VarChar, 10)
                    .Add("@LastQtyRecd", SqlDbType.VarChar, 5)
                    .Add("@DateLastQtyRecd", SqlDbType.VarChar, 10)
                    .Add("@QtyInTranz", SqlDbType.VarChar, 5)
                    .Add("@MMDate_Load", SqlDbType.SmallDateTime)
                End With

                cn.Open()
                Do Until parser.EndOfData = True
                    Dim fields() As String = parser.ReadFields()
                    For i As Integer = 0 To 11
                        cmd.Parameters(i).Value = fields(i)
                        If i = 11 Then
                            cmd.Parameters(12).Value = dateNow
                        End If
                    Next
                    cmd.ExecuteNonQuery()
                Loop
            End Using
            MsgBox("Action has been successfully completed.")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblMinMax").Fill(dsMain, "tblSelect")

        If dsMain.Tables("tblSelect").Rows.Count = 0 Then
            MessageBox.Show("Min/Max Table was not created. Please check conversion file and try again.")
        Else
            MessageBox.Show("Min/Max Table:  " + Str(dsMain.Tables("tblSelect").Rows.Count) + "  records added.")
        End If

        strcon.close()

    End Sub

End Class