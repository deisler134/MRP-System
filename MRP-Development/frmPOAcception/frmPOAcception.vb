Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.OleDb
Imports Microsoft.Office.Interop



Module Module1
    Dim strFileCSV(0) As String
    Dim nPoDetailID As Int32
    Dim nPoRecvID As Int32
    Dim nPoMasterID As Int32
    Dim fPoDetailQty As Single
    Dim fPoRecvQty As Single
    Dim strLogFile As String = "\\srv115fs01\misdept\2-MRP-Development\LAC_Alusta_Dev\Input\Log.txt" '"C:\POFile\Log.txt"
    Dim strCSVFileSrc As String = "\\srv115fs01\misdept\2-MRP-Development\LAC_Alusta_Dev\Input" '"C:\POFile"
    Dim strCSVFileDst As String = "\\srv115fs01\misdept\2-MRP-Development\LAC_Alusta_Dev\Input_Archive" '"C:\POFile1"

    'Dim CallClass As New clsCommon
    'Const strConnection = "Data Source=172.21.71.14; Initial catalog=SQLMRPDevelopment; Integrated Security=SSPI; Connect Timeout=15; persist security info=False; Trusted_Connection=true; Packet Size=4096"

    Dim cn As New SqlConnection(strConnection)
    Dim cDS As DataSet
    Dim tblFileContent As DataTable
    Dim tblDetail As DataTable
    Dim tblRecv As DataTable
    Dim tblRecvDetail As DataTable
    Dim tblMaster As DataTable

    ''''''test code
    Dim nSheets As Integer = 0
    Dim xlApp As New Excel.Application
    Dim xlSheet As Excel.Worksheet
    Dim xlBook As Excel.Workbook

    Sub Main()

        '''''test code
        xlApp.Visible = True
        xlBook = xlApp.Workbooks.Add
        xlSheet = xlApp.ActiveSheet
        '''''''''''''
        cDS = New DataSet("POInfo")
        tblFileContent = cDS.Tables.Add("FileContent")
        tblFileContent.Columns.Add("PONo", Type.GetType("System.String"))
        tblFileContent.Columns.Add("PORecvID", Type.GetType("System.Int32"))

        tblRecvDetail = cDS.Tables.Add("PORecvDetail")
        tblRecvDetail.Columns.Add("PORecvID", Type.GetType("System.Int32"))
        tblRecvDetail.Columns.Add("PODetailID", Type.GetType("System.Int32"))
        tblRecvDetail.Columns.Add("POQty", Type.GetType("System.Int32"))
        tblRecvDetail.Columns.Add("PSlipQty", Type.GetType("System.Int32"))
        tblMaster = cDS.Tables.Add("POMaster")
        tblMaster.Columns.Add("POMasterID", Type.GetType("System.Int32"))
        tblMaster.Columns.Add("POStatusLine", Type.GetType("System.Int32"))


        tblDetail = cDS.Tables.Add("tblDetail")
        tblDetail.Columns.Add("PODetailID", Type.GetType("System.Int32"))
        tblRecv = cDS.Tables.Add("tblRecv")
        tblRecv.Columns.Add("PORecvID", Type.GetType("System.Int32"))

        GC.Collect()
        SearchFiles(strCSVFileSrc, "*.CSV")
        Dim i As Integer
        Dim ret As Integer
        For i = 0 To strFileCSV.Length - 1
            If strFileCSV(i) <> Nothing Then
                ReadExcel(strFileCSV(i))

                Dim j As Integer
                Dim nPORecvID As Integer
                Dim nPONo As Integer
                For j = 0 To tblFileContent.Rows.Count - 1
                    nPORecvID = tblFileContent.Rows(j).Item(1)
                    ret = QueryPORecvStoreProcedure("gettblPOReceivingQueries", nPORecvID)
                    If ret = -1 Then
                        Continue For
                    End If
                    UpdatePOReceivingStoreProcedure("cspUpdatePORecv", nPORecvID)
                    Dim nPODetailID As Integer
                    Dim k As Integer
                    For k = 0 To cDS.Tables("PORecvDetail").Rows.Count - 1
                        nPODetailID = cDS.Tables("PORecvDetail").Rows(k).Item("PODetailID")
                        ret = QueryPODetailQtyStoreProcedure("gettblPODetailQty", nPODetailID)
                        ret = QueryPORecvQtyStoreProcedure("gettblPORecvQty", nPODetailID)
                        If ret = -1 Then
                            Continue For
                        End If
                        fPoDetailQty = cDS.Tables("POQty").Rows(0).Item(0)
                        fPoRecvQty = cDS.Tables("PSlipQty").Compute("SUM(PSlipQty)", String.Empty)
                        If fPoDetailQty < fPoRecvQty * 0.9 Then
                            UpdatePODetailStatusLine("cspUpdatePODetailStatusLine", nPODetailID, "50")
                        Else
                            UpdatePODetailStatusLine("cspUpdatePODetailStatusLine", nPODetailID, "75")
                            UpdatePORecvStatus("cspUpdatePORecvStatus", nPODetailID, "75")
                        End If
                    Next

                    nPONo = tblFileContent.Rows(j).Item(0)
                    ret = QueryPOMasterStoreProcedure("gettblPOMasterQueries", nPONo)
                    If ret = -1 Then
                        Continue For
                    End If
                    Dim nPOMasterID As Integer
                    For k = 0 To cDS.Tables("POMaster").Rows.Count - 1
                        nPOMasterID = cDS.Tables("POMaster").Rows(k).Item("POMasterID")
                        QueryPODetailsStatusStoreProcedure("gettblPODetailsStatus", nPOMasterID)
                        If cDS.Tables("POMaster").Rows.Count > 0 Then
                            Dim expression As String
                            expression = "POStatusLine<>99 AND POStatusLine<>75"
                            Dim foundRows() As DataRow
                            foundRows = cDS.Tables("POMaster").Select(expression)
                            If foundRows.Length = 0 Then
                                UpdatePOMasterStatus("cspUpdatePOStatusAccepted", nPOMasterID, "")
                            End If
                        End If
                    Next
                    Dim tblCount As Integer = cDS.Tables.Count
                    While tblCount > 5
                        cDS.Tables.RemoveAt(tblCount - 1)
                        tblCount = tblCount - 1
                    End While
                    TestData("", cDS)
                    cDS.Tables("tblDetail").Clear()
                    cDS.Tables("PORecvDetail").Clear()
                    cDS.Tables("POMaster").Clear()
                Next
                MoveFile(strFileCSV(i), strCSVFileDst)
                cDS.Tables("FileContent").Clear()

                ''''Test code
                xlBook.SaveAs("c:\" & Format(Now, "yyyy-MM-dd hh_mm_ss") & ".xls")
                xlBook.Close()
                xlApp.Quit()

            End If
        Next
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cDS.Clear()
        cDS.Dispose()
        GC.Collect()
    End Sub

    Private Sub SearchFiles(Path As String, FileType As String)

        Dim strDir As String() = System.IO.Directory.GetDirectories(Path)
        Dim strFile As String() = System.IO.Directory.GetFiles(Path, FileType)
        Dim i As Integer
        If strFile.Length > 0 Then
            ReDim strFileCSV(strFile.Length - 1)
            For i = 0 To strFile.Length - 1
                'Debug.Print(strFile(i))
                strFileCSV(i) = strFile(i)
            Next
        End If

    End Sub

    Private Sub ReadExcel(path As String)

        ' Hold the Parsed Data
        Dim ary(0) As String

        Dim sr As New System.IO.StreamReader(path)

        Dim placeholder As Integer = 0
        Dim arrlTemp As New ArrayList
        Dim newRow As DataRow
        newRow = tblFileContent.NewRow()
        Do While sr.Peek <> -1 ' Is -1 when no data exists on the next line of the CSV file
            ary(0) = sr.ReadLine()
            Dim delimiter As Char = ";"c
            Dim str() As String = ary(0).Split(delimiter)
            newRow = tblFileContent.NewRow()
            newRow("PONo") = str(0)
            newRow("PORecvID") = System.Convert.ToInt32(str(2))
            tblFileContent.Rows.Add(newRow)
        Loop
        sr.Close()
        sr.Dispose()

    End Sub

    Private Function QueryPORecvStoreProcedure(strSPName As String, ByVal nPORecvID As Integer) As Integer
        Dim ret As Integer = 0
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim da = New SqlDataAdapter()
            Dim cmdSQLCommand = New SqlCommand()
            cmdSQLCommand.Connection = cn
            cmdSQLCommand.CommandType = CommandType.StoredProcedure
            cmdSQLCommand.CommandTimeout = 1000
            cmdSQLCommand.CommandText = strSPName
            'DataApapter
            da.SelectCommand = cmdSQLCommand

            ' Add Parameters to SPROC
            Dim par11 As New SqlParameter("@RecvID", SqlDbType.Int)
            par11.Value = nPORecvID
            da.SelectCommand.Parameters.Add(par11)
            da.Fill(cDS.Tables("tblDetail"))
            If cDS.Tables("tblDetail").Rows.Count = 0 Then
                ret = -1
                WriteLogFile(strLogFile, "PORecvID = " & Format(nPORecvID) & ", return DetailID is NULL ")
                Return ret
            End If
            da.Fill(cDS.Tables("PORecvDetail"))
            tblRecvDetail.Rows(0).Item("PORecvID") = nPORecvID
            cmdSQLCommand.Dispose()
            da.Dispose()
        Catch ex As Exception
            ret = -1
            WriteLogFile(strLogFile, "Exception occured - QueryPODetailID   " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        Return ret
    End Function

    Private Function QueryPOMasterStoreProcedure(strSPName As String, ByVal nPONo As Integer) As Integer
        Dim ret As Integer = 0
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim da = New SqlDataAdapter()
            Dim cmdSQLCommand = New SqlCommand()
            cmdSQLCommand.Connection = cn
            cmdSQLCommand.CommandType = CommandType.StoredProcedure
            cmdSQLCommand.CommandTimeout = 1000
            cmdSQLCommand.CommandText = strSPName
            'DataApapter
            da.SelectCommand = cmdSQLCommand

            ' Add Parameters to SPROC
            Dim par11 As New SqlParameter("@PONo", SqlDbType.Int)
            par11.Value = nPONo
            da.SelectCommand.Parameters.Add(par11)
            cDS.Tables.Add("POMasterID")
            da.Fill(cDS.Tables("POMasterID"))
            If cDS.Tables("POMasterID").Rows.Count = 0 Then
                ret = -1
                WriteLogFile(strLogFile, "PONo = " & Format(nPONo) & ", return POMasterID is NULL ")
                Return ret
            End If
            da.Fill(cDS.Tables("POMaster"))

            cmdSQLCommand.Dispose()
            da.Dispose()
        Catch ex As Exception
            WriteLogFile(strLogFile, "Exception occured - QueryPOMasterID   " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        Return ret
    End Function

    Private Function QueryPODetailQtyStoreProcedure(strSPName As String, ByVal nPODetailID As Integer) As Integer
        Dim ret As Integer = 0
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim da = New SqlDataAdapter()
            Dim cmdSQLCommand = New SqlCommand()
            cmdSQLCommand.Connection = cn
            cmdSQLCommand.CommandType = CommandType.StoredProcedure
            cmdSQLCommand.CommandTimeout = 1000
            cmdSQLCommand.CommandText = strSPName
            'DataApapter
            da.SelectCommand = cmdSQLCommand

            ' Add Parameters to SPROC
            Dim par11 As New SqlParameter("@PoDetailID", SqlDbType.Int)
            par11.Value = nPODetailID
            da.SelectCommand.Parameters.Add(par11)
            cDS.Tables.Add("POQty")
            da.Fill(cDS.Tables("POQty"))

            If cDS.Tables("POQty").Rows.Count = 0 Then
                ret = -1
                WriteLogFile(strLogFile, "PODetailID = " & Format(nPODetailID) & ", return POQty is NULL ")
                Return ret
            End If

            Dim i As Int32
            'cDS.Tables("PORecvDetail").Columns.Add("POQty")

            For i = 0 To cDS.Tables("POQty").Rows.Count - 1
                If cDS.Tables("PORecvDetail").Rows.Count < cDS.Tables("POQty").Rows.Count Then
                    Dim rw As DataRow = cDS.Tables("PORecvDetail").NewRow
                    cDS.Tables("PORecvDetail").Rows.Add(rw)
                End If
                cDS.Tables("PORecvDetail").Rows(i).Item("POQty") = cDS.Tables("POQty").Rows(i).Item("POQty")
            Next

            cmdSQLCommand.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLogFile(strLogFile, "Exception occured - QueryPODetailQty   " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        Return ret
    End Function
    Private Function QueryPORecvQtyStoreProcedure(strSPName As String, ByVal nPODetailID As Integer) As Integer
        Dim ret As Integer = 0
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim da = New SqlDataAdapter()
            Dim cmdSQLCommand = New SqlCommand()
            cmdSQLCommand.Connection = cn
            cmdSQLCommand.CommandType = CommandType.StoredProcedure
            cmdSQLCommand.CommandTimeout = 1000
            cmdSQLCommand.CommandText = strSPName
            'DataApapter
            da.SelectCommand = cmdSQLCommand

            ' Add Parameters to SPROC
            Dim par11 As New SqlParameter("@PoDetailID", SqlDbType.Int)
            par11.Value = nPODetailID
            da.SelectCommand.Parameters.Add(par11)
            cDS.Tables.Add("PSlipQty")
            da.Fill(cDS.Tables("PSlipQty"))
            If cDS.Tables("PSlipQty").Rows.Count = 0 Then
                ret = -1
                WriteLogFile(strLogFile, "PODetailID = " & Format(nPODetailID) & ", return PSlipQty is NULL ")
                Return ret
            End If

            Dim i As Int32
            'cDS.Tables("PORecvDetail").Columns.Add("PSlipQty")

            For i = 0 To cDS.Tables("PSlipQty").Rows.Count - 1
                If cDS.Tables("PORecvDetail").Rows.Count < cDS.Tables("PSlipQty").Rows.Count Then
                    Dim rw As DataRow = cDS.Tables("PORecvDetail").NewRow
                    cDS.Tables("PORecvDetail").Rows.Add(rw)
                End If
                cDS.Tables("PORecvDetail").Rows(i).Item("PSlipQty") = cDS.Tables("PSlipQty").Rows(i).Item("PSlipQty")
            Next
            cmdSQLCommand.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLogFile(strLogFile, "Exception occured - QueryPORecvQty   " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        Return ret
    End Function

    Private Sub QueryPODetailsStatusStoreProcedure(strSPName As String, ByVal nPOMasterID As Integer)
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Dim da = New SqlDataAdapter()
            Dim cmdSQLCommand = New SqlCommand()
            cmdSQLCommand.Connection = cn
            cmdSQLCommand.CommandType = CommandType.StoredProcedure
            cmdSQLCommand.CommandTimeout = 1000
            cmdSQLCommand.CommandText = strSPName
            'DataApapter
            da.SelectCommand = cmdSQLCommand

            ' Add Parameters to SPROC
            Dim par11 As New SqlParameter("@POMasterID", SqlDbType.Int)
            par11.Value = nPOMasterID
            da.SelectCommand.Parameters.Add(par11)
            cDS.Tables.Add("POStatusLine")
            da.Fill(cDS.Tables("POStatusLine"))

            Dim i As Int32
            'cDS.Tables("POMaster").Columns.Add("POStatusLine")

            For i = 0 To cDS.Tables("POStatusLine").Rows.Count - 1
                If cDS.Tables("POMaster").Rows.Count < cDS.Tables("POStatusLine").Rows.Count Then
                    Dim rw As DataRow = cDS.Tables("POMaster").NewRow
                    cDS.Tables("POMaster").Rows.Add(rw)
                End If
                cDS.Tables("POMaster").Rows(i).Item("POStatusLine") = cDS.Tables("POStatusLine").Rows(i).Item("POStatusLine")
            Next
            cmdSQLCommand.Dispose()
            da.Dispose()

        Catch ex As Exception
            WriteLogFile(strLogFile, "Exception occured - QueryPODetailsStatus   " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdatePOReceivingStoreProcedure(strSPName As String, ByVal PORecvID As Integer)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSPName, cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@PORecvID", PORecvID))
        mySqlComm.Parameters.Add(New SqlParameter("@AccpToPay", 1))
        mySqlComm.Parameters.Add(New SqlParameter("@ApprRecvToPay", 1))
        mySqlComm.Parameters.Add(New SqlParameter("@ApprInsp", 1))
        ' mySqlComm.Parameters.Add(New SqlParameter("@PayInvDate", strDate))

        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            If mySqlComm.ExecuteNonQuery() <= 0 Then
                WriteLogFile(strLogFile, "UpdatePOReceiving Execute fail.Please try again.")
            End If

        Catch ex As SqlException
            WriteLogFile(strLogFile, "Exception occured - UpdatePOReceiving " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdatePODetailStatusLine(strSPName As String, ByVal PODetailID As Integer, ByVal StatusLine As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSPName, cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@PODetailID", PODetailID))
        mySqlComm.Parameters.Add(New SqlParameter("@Value", StatusLine))

        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            If mySqlComm.ExecuteNonQuery() <= 0 Then
                WriteLogFile(strLogFile, "UpdatePODetailStatusLine Execute fail.Please try again.")
            End If

        Catch ex As SqlException
            WriteLogFile(strLogFile, "Exception occured - UpdatePODetailStatusLine " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdatePORecvStatus(strSPName As String, ByVal PODetailID As Integer, ByVal RecStatus As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSPName, cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@PODetailID", PODetailID))
        mySqlComm.Parameters.Add(New SqlParameter("@Value", RecStatus))

        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            If mySqlComm.ExecuteNonQuery() <= 0 Then
                WriteLogFile(strLogFile, "UpdatePORecvStatus Execute fail.Please try again.")
            End If

        Catch ex As SqlException
            WriteLogFile(strLogFile, "Exception occured - UpdatePORecvStatus " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub UpdatePOMasterStatus(strSPName As String, ByVal POMasterID As Integer, ByVal POStatus As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strSPName, cn)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@POMasterID", POMasterID))
        'mySqlComm.Parameters.Add(New SqlParameter("@Value", POStatus))

        Try

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            If mySqlComm.ExecuteNonQuery() <= 0 Then
                WriteLogFile(strLogFile, "UpdatePOMasterStatus Execute fail.Please try again.")
            End If

        Catch ex As SqlException
            WriteLogFile(strLogFile, "Exception occured - UpdatePOMasterStatus " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub MoveFile(strPathSrc As String, strPathDst As String)

        Try
            If Right(strPathDst, 1) <> "\" Then strPathDst = strPathDst & "\"
            Dim strFileName As String
            strFileName = System.IO.Path.GetFileName(strPathSrc)
            strPathDst = strPathDst + strFileName
            If File.Exists(strPathDst) Then
                File.Delete(strPathDst)
            End If

            If File.Exists(strPathSrc) Then
                File.Move(strPathSrc, strPathDst)
            End If
        Catch ex As Exception
            WriteLogFile(strLogFile, "Exception occured - MoveFile")
            WriteLogFile(strLogFile, ex.Message)
        End Try

    End Sub
    Private Sub WriteLogFile(strPath As String, strMsg As String)
        Dim sw As StreamWriter = New StreamWriter(strPath, True)
        Try
            If File.Exists(strPath) = False Then
                Dim filestream As FileStream = File.Create(strPath)
                filestream.Close()
                filestream.Dispose()
            End If

            sw.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss"))
            sw.WriteLine(strMsg)
            sw.Flush()

        Catch ex As Exception
            sw.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss"))
            sw.WriteLine("Exception occured - WriteLogFile  " & ex.Message)
            sw.Flush()
        End Try
        sw.Close()
        sw.Dispose()

    End Sub

    Private Function TestData(strPath As String, ds As DataSet)
        'strPath = "c:\1.xls"
        'Dim sw As StreamWriter = New StreamWriter(strPath, True)
        'If File.Exists(strPath) = False Then
        '    Dim excel As Object
        '    excel = CreateObject("Excel.application")
        '    excel.Workbooks.Add.SaveAs(strPath)
        '    excel.quit()
        '    excel = Nothing
        'End If

        xlBook.Sheets.Add(After:=xlBook.Sheets(xlBook.Sheets.Count))
        xlApp.ScreenUpdating = True     ' Enables screen refreshing.

        nSheets = nSheets + 1
        xlSheet = xlBook.Sheets(nSheets)

        Dim rw As Int32
        Dim cl As Int32
        Dim dt As DataTable
        dt = ds.Tables("PORecvDetail")
        For rw = 0 To dt.Rows.Count
            For cl = 0 To dt.Columns.Count - 1
                If rw = 0 Then
                    xlSheet.Cells(rw + 1, cl + 1) = dt.Columns(cl).ColumnName
                Else
                    xlSheet.Cells(rw + 1, cl + 1) = dt.Rows(rw - 1).Item(cl)
                End If
            Next
        Next


        xlBook.Sheets.Add(After:=xlBook.Sheets(xlBook.Sheets.Count))
        xlApp.ScreenUpdating = True     ' Enables screen refreshing.
        nSheets = nSheets + 1
        xlSheet = xlBook.Sheets(nSheets)
        dt = ds.Tables("POMaster")
        For rw = 0 To dt.Rows.Count
            For cl = 0 To dt.Columns.Count - 1
                If rw = 0 Then
                    xlSheet.Cells(rw + 1, cl + 1) = dt.Columns(cl).ColumnName
                Else
                    xlSheet.Cells(rw + 1, cl + 1) = dt.Rows(rw - 1).Item(cl)
                End If
            Next
        Next
        dt.Dispose()
        

        'xlBook.SaveAs("c:\" & Format(Now, "yyyy-MM-dd hh_mm_ss") & ".xls")
        'xlBook.Close()

        'xlApp.Quit()


    End Function
End Module

