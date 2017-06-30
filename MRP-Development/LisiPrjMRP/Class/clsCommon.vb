Imports System.Data
Imports System.Data.SqlClient

Imports System.IO


Public Class clsCommon

    Dim myConnection As New SqlConnection(strConnection)


    Dim rc As Integer
    Dim Results As String = False

    Public Function SortDataTable(ByRef Table As DataTable, ByVal SortString As String) As DataTable
        Dim View As New DataView(Table)
        View.Sort = SortString
        Return View.ToTable()
    End Function

    Public Function removeDuplicateRMInv(ByVal dTable As DataTable) As DataTable

        Dim row1 As DataRow
        Dim row2 As DataRow
        'Const wantedColumn As Integer = 0
        Dim tableSize As Integer = dTable.Rows.Count
        For I As Integer = 0 To tableSize - 2
            row1 = dTable.Rows(I)
            If row1.RowState = DataRowState.Deleted Then
                Exit For
            End If
            For J As Integer = I + 1 To tableSize - 1
                row2 = dTable.Rows(J)
                If J >= tableSize Then
                    Exit For
                End If

                If row2.RowState = DataRowState.Deleted Then
                    'skip
                Else
                    Try
                        If row1(0) = row2(0) Then
                            row2.Delete()
                            'tableSize = tableSize - 1
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next
        Next
        Return (dTable)

    End Function

    Public Function removeDuplicateRMPOLines(ByVal dTable As DataTable) As DataTable

        Dim row1 As DataRow
        Dim row2 As DataRow
        'Const wantedColumn As Integer = 4
        Dim tableSize As Integer = dTable.Rows.Count
        For I As Integer = 0 To tableSize - 2
            row1 = dTable.Rows(I)
            If row1.RowState = DataRowState.Deleted Then
                Exit For
            End If
            For J As Integer = I + 1 To tableSize - 1
                row2 = dTable.Rows(J)
                If J >= tableSize Then
                    Exit For
                End If

                If row2.RowState = DataRowState.Deleted Then
                    'skip
                Else
                    Try
                        If row1(4) = row2(4) Then
                            row2.Delete()
                            'tableSize = tableSize - 1
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next
        Next

        Return (dTable)

    End Function

    Public Function SearchByString(ByVal StrSearch As String, ByVal StrGet As String) As DataSet

        Dim myCommand As SqlDataAdapter = New SqlDataAdapter(StrGet, myConnection)
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim paraPoNum As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 10)
        paraPoNum.Value = StrSearch
        myCommand.SelectCommand.Parameters.Add(paraPoNum)

        Dim dsTemp As New DataSet()
        Try
            myCommand.Fill(dsTemp, "tblTableSearch")
        Catch ex As Exception
            MsgBox("Load Data Searched: " & ex.Message)
        End Try

        Return dsTemp

    End Function

    Public Function PopulateComboBox(ByVal strTable As String, ByVal strGet As String) As DataSet

        Dim dsTemp As New DataSet
        Dim da As New SqlDataAdapter(strGet, myConnection)

        da.SelectCommand.CommandType = CommandType.StoredProcedure

        Try
            da.Fill(dsTemp, strTable)
        Catch ex As Exception
            'MsgBox("Load ComboBox. Store Procedure = " & strGet & "--" & ex.Message)
        End Try

        Return dsTemp

    End Function

    Public Function PopulateComboBoxWithParam(ByVal strTable As String, ByVal strGet As String, ByVal strSearch As Integer) As DataSet

        Dim myCommand As SqlDataAdapter = New SqlDataAdapter(strGet, myConnection)
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim paraPoNum As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 10)
        paraPoNum.Value = strSearch
        myCommand.SelectCommand.Parameters.Add(paraPoNum)

        Dim dsTemp As New DataSet()
        Try
            myCommand.Fill(dsTemp, strTable)
        Catch ex As Exception
            'MsgBox("Load ComboBox With Param = " & ex.Message)
        End Try

        Return dsTemp


    End Function

    Public Function PopulateDataAdapter(ByVal strGet As String) As SqlDataAdapter

        'If myConnection.State = ConnectionState.Closed Then
        '    myConnection.Open()
        'End If
        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter

        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        Return da

    End Function

    Public Function PopulateDataAdapterAfterSearch(ByVal strGet As String, ByVal strSearch As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()

        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand
        da.SelectCommand.CommandTimeout = 0

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@strSearch", SqlDbType.NVarChar, 100)
        parameterPoNum.Value = strSearch
        da.SelectCommand.Parameters.Add(parameterPoNum)
        Return da

    End Function

    Public Function PopulateAdapterAfterSearchInt(ByVal strGet As String, ByVal strSearch As Integer) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@strSearch", SqlDbType.Int, 4)
        parameterPoNum.Value = strSearch
        da.SelectCommand.Parameters.Add(parameterPoNum)

        Return da


    End Function

    Public Function PopulateDataAdapterSearchStrAndStr(ByVal strGet As String, ByVal strSearch As String, ByVal FindItem As Integer) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim parPoNum As New SqlParameter("@strSearch", SqlDbType.NVarChar, 50)
        parPoNum.Value = strSearch
        da.SelectCommand.Parameters.Add(parPoNum)

        Dim parItem As New SqlParameter("@FindItem", SqlDbType.Int, 1)
        parItem.Value = FindItem
        da.SelectCommand.Parameters.Add(parItem)

        Return da

    End Function

    Public Function PopulateDataAdapterSearchWithMultipleValues(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Dim par44 As New SqlParameter("@Par4", SqlDbType.NVarChar, 100)
        par44.Value = Par4
        da.SelectCommand.Parameters.Add(par44)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch2Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandTimeOut = 1000
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch3Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch4Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Dim par44 As New SqlParameter("@Par4", SqlDbType.NVarChar, 100)
        par44.Value = Par4
        da.SelectCommand.Parameters.Add(par44)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch5Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String, ByVal Par5 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Dim par44 As New SqlParameter("@Par4", SqlDbType.NVarChar, 100)
        par44.Value = Par4
        da.SelectCommand.Parameters.Add(par44)

        Dim par55 As New SqlParameter("@Par5", SqlDbType.NVarChar, 100)
        par55.Value = Par5
        da.SelectCommand.Parameters.Add(par55)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch6Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String, ByVal Par5 As String, ByVal Par6 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Dim par44 As New SqlParameter("@Par4", SqlDbType.NVarChar, 100)
        par44.Value = Par4
        da.SelectCommand.Parameters.Add(par44)

        Dim par55 As New SqlParameter("@Par5", SqlDbType.NVarChar, 100)
        par55.Value = Par5
        da.SelectCommand.Parameters.Add(par55)

        Dim par66 As New SqlParameter("@Par6", SqlDbType.NVarChar, 100)
        par66.Value = Par6
        da.SelectCommand.Parameters.Add(par66)

        Return da

    End Function

    Public Function PopulateDataAdapterSearch7Param(ByVal strGet As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String, ByVal Par5 As String, ByVal Par6 As String, ByVal Par7 As String) As SqlDataAdapter

        Dim da = New SqlDataAdapter()
        Dim cmdSQLCommand = New SqlCommand()
        cmdSQLCommand.Connection = myConnection
        cmdSQLCommand.CommandType = CommandType.StoredProcedure
        cmdSQLCommand.CommandText = strGet

        'DataApapter
        da = New SqlDataAdapter()
        da.SelectCommand = cmdSQLCommand

        ' Add Parameters to SPROC
        Dim par11 As New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        par11.Value = Par1
        da.SelectCommand.Parameters.Add(par11)

        Dim par22 As New SqlParameter("@Par2", SqlDbType.NVarChar, 100)
        par22.Value = Par2
        da.SelectCommand.Parameters.Add(par22)

        Dim par33 As New SqlParameter("@Par3", SqlDbType.NVarChar, 100)
        par33.Value = Par3
        da.SelectCommand.Parameters.Add(par33)

        Dim par44 As New SqlParameter("@Par4", SqlDbType.NVarChar, 100)
        par44.Value = Par4
        da.SelectCommand.Parameters.Add(par44)

        Dim par55 As New SqlParameter("@Par5", SqlDbType.NVarChar, 100)
        par55.Value = Par5
        da.SelectCommand.Parameters.Add(par55)

        Dim par66 As New SqlParameter("@Par6", SqlDbType.NVarChar, 100)
        par66.Value = Par6
        da.SelectCommand.Parameters.Add(par66)

        Dim par77 As New SqlParameter("@Par7", SqlDbType.NVarChar, 100)
        par77.Value = Par7
        da.SelectCommand.Parameters.Add(par77)

        Return da

    End Function

    Public Function getTblQuotePartBrowse(ByVal txtpartid As String) As SqlDataAdapter

        Dim cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = myConnection
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "getTblQuotePartBrowse"

        'DataApapter
        Dim daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@txtPartID", SqlDbType.Int, 4)
        parameterPoNum.Value = txtpartid
        daPORec.SelectCommand.Parameters.Add(parameterPoNum)

        Return daPORec

    End Function

    Public Function GenerateNextLot(ByVal StoreProc As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StoreProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@StrSearch", strSearch))
        Dim myReader As Data.SqlClient.SqlDataReader
        Dim ReturnParam As String = ""

        Try
            'myConnection.Open()
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! ERROR DATABASE!!!! Receiving Lot Number can not be generated.")
                ReturnParam = "ERROR"
            Else
                While myReader.Read()
                    ReturnParam = myReader.GetValue(0).ToString + 1
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - GenerateNext No.   " & ex.Message)
            ReturnParam = "ERROR"
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return ReturnParam

    End Function

    Public Function ExecuteUpdateTwoParams(ByVal StProc As String, ByVal strSearch As String, ByVal NextNo As Integer) As Boolean

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 20)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraNext As SqlParameter = New SqlParameter("@NextNo", SqlDbType.Int, 4)
        paraNext.Value = NextNo
        mySqlComm.Parameters.Add(paraNext)

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add Receiving: " & ex.Message)

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False

        Finally

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

        End Try

        Return True

    End Function

    Public Function ExecuteUpdate3Params(ByVal StProc As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String) As Boolean

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Par1", SqlDbType.NVarChar, 50)
        paraPar1.Value = Par1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Par2", SqlDbType.NVarChar, 50)
        paraPar2.Value = Par2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraPar3 As SqlParameter = New SqlParameter("@Par3", SqlDbType.NVarChar, 50)
        paraPar3.Value = Par3
        mySqlComm.Parameters.Add(paraPar3)

        Try
           
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Update Procedure: " & ex.Message)

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return True

    End Function

    Public Function ExecuteUpdate4Params(ByVal StProc As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String) As Boolean

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Par1", SqlDbType.NVarChar, 50)
        paraPar1.Value = Par1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Par2", SqlDbType.NVarChar, 50)
        paraPar2.Value = Par2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraPar3 As SqlParameter = New SqlParameter("@Par3", SqlDbType.NVarChar, 50)
        paraPar3.Value = Par3
        mySqlComm.Parameters.Add(paraPar3)

        Dim paraPar4 As SqlParameter = New SqlParameter("@Par4", SqlDbType.NVarChar, 50)
        paraPar4.Value = Par4
        mySqlComm.Parameters.Add(paraPar4)

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Update Procedure: " & ex.Message)

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return True

    End Function

    Public Function ExecuteUpdate5Params(ByVal StProc As String, ByVal Par1 As String, ByVal Par2 As String, ByVal Par3 As String, ByVal Par4 As String, ByVal Par5 As String) As Boolean

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Par1", SqlDbType.NVarChar, 100)
        paraPar1.Value = Par1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Par2", SqlDbType.NVarChar, 50)
        paraPar2.Value = Par2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraPar3 As SqlParameter = New SqlParameter("@Par3", SqlDbType.NVarChar, 500)
        paraPar3.Value = Par3
        mySqlComm.Parameters.Add(paraPar3)

        Dim paraPar4 As SqlParameter = New SqlParameter("@Par4", SqlDbType.NVarChar, 500)
        paraPar4.Value = Par4
        mySqlComm.Parameters.Add(paraPar4)

        Dim paraPar5 As SqlParameter = New SqlParameter("@Par5", SqlDbType.NVarChar, 500)
        paraPar5.Value = Par5
        mySqlComm.Parameters.Add(paraPar5)


        Try
            
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Update Procedure: " & ex.Message)

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return True

    End Function

    Public Function ExecuteUpdateSearchStr(ByVal StProc As String, ByVal strSearch As String) As Boolean

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 400)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("ERROR Update Store Procedure: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return True

    End Function

    Public Function FindPoItemInfo(ByVal StProc As String, ByVal strSearch As String, ByVal strItem As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@StrSearch", strSearch))
        mySqlComm.Parameters.Add(New SqlParameter("@strItem", strItem))
        Dim myReader As Data.SqlClient.SqlDataReader
        Dim ReturnParam As String = ""

        Try
            'myConnection.Open()

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! Missing data !!!")
                ReturnParam = ""
            Else
                While myReader.Read()
                    ReturnParam = Trim(myReader.GetValue(0).ToString) + "  " + Trim(myReader.GetValue(1).ToString) + vbCrLf + _
                                    Trim(myReader.GetValue(2).ToString)
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - FindPoItemInfo   " & ex.Message)
            ReturnParam = ""

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return ReturnParam

    End Function

    Public Function FindMpoNoInfo(ByVal StProc As String, ByVal strSearch As Integer) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@swMpo", strSearch))
        Dim myReader As Data.SqlClient.SqlDataReader
        Dim ReturnParam As String = ""

        Try
            ' myConnection.Open()
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! Missing data !!!")
                ReturnParam = ""
            Else
                While myReader.Read()
                    ReturnParam = "MPO Number: " + Trim(myReader.GetValue(1).ToString) + vbCrLf + _
                                    "Part Number: " + Trim(myReader.GetValue(2).ToString) + _
                                    "  Rev.: " + Trim(myReader.GetValue(4).ToString) + vbCrLf + _
                                    "MPO Quantity: " + Trim(myReader.GetValue(3).ToString)
                End While
                myReader.Close()
                myReader.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception occured - FindPoItemInfo   " & ex.Message)
            ReturnParam = ""

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return ReturnParam

    End Function


    Public Function FindPoItemRemarks(ByVal StProc As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StProc, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure
        mySqlComm.Parameters.Add(New SqlParameter("@StrSearch", strSearch))
        Dim myReader As Data.SqlClient.SqlDataReader
        Dim ReturnParam As String = ""

        Try
            ' myConnection.Open()
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            myReader = mySqlComm.ExecuteReader()
            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                MessageBox.Show("!!! Missing data !!!")
                ReturnParam = ""
            Else
                While myReader.Read()
                    ReturnParam = Trim(myReader.GetValue(0).ToString)
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch ex As Exception
            MsgBox("Exception occured - FindPoItemRemarks   " & ex.Message)
            ReturnParam = ""

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return ReturnParam

    End Function

    Sub UpdateMatlStock(ByVal strGet As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Try
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("!!!ERROR!!! Inventory Stock: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

    End Sub

    Sub UpdateFPStock(ByVal strGet As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("!!!ERROR!!! Update Finish Parts Inventory: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

    End Sub

    Sub UpdatePerishableStock(ByVal strGet As String)

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("!!!ERROR!!! Update Perishable Items Inventory: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

    End Sub

    Public Function SearchMpo(ByVal strGet As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 25)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraRet As SqlParameter = New SqlParameter("@ExistMpo", SqlDbType.NVarChar, 25)
        paraRet.Value = strSearch
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ExistMpo")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding MPO: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnLastMpo(ByVal strGet As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraRet As SqlParameter = New SqlParameter("@LastMpo", SqlDbType.NVarChar, 25)
        'paraRet.Value = strSearch
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@LastMpo")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding Last MPO: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function TakeFinalSt(ByVal strGet As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 25)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraRet As SqlParameter = New SqlParameter("@TakeSt", SqlDbType.Real, 4)
        paraRet.Value = strSearch
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@TakeSt")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException

            MsgBox("Finding MPO: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Throw ex
            Return False

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnStrWithParInt(ByVal strGet As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.Int, 4)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.NVarChar, 1000)
        paraRet.Value = strSearch
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try
            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()

            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("ERROR: " & ex.Message)

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False

        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnInfoWithParString(ByVal strGet As String, ByVal strSearch As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 400)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.NVarChar, 2000)
        paraRet.Value = strSearch
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding text: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnStrWithParString(ByVal strGet As String, ByVal strSearch As String) As Integer

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraSearch As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 25)
        paraSearch.Value = strSearch
        mySqlComm.Parameters.Add(paraSearch)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.Int, 4)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As Integer

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")

            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, Integer)
            Else
                IReturn = 0
            End If

        Catch ex As SqlException
            MsgBox("Finding ID: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnStrWith2ParStr(ByVal strGet As String, ByVal Para1 As String, ByVal Para2 As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Para1", SqlDbType.NVarChar, 1000)
        paraPar1.Value = Para1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Para2", SqlDbType.NVarChar, 1000)
        paraPar2.Value = Para2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.NVarChar, 2000)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        'If myConnection.State = ConnectionState.Open Then
        '    myConnection.Close()
        'End If

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding text: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnStrWith3ParStr(ByVal strGet As String, ByVal Para1 As String, ByVal Para2 As String, ByVal Para3 As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Para1", SqlDbType.NVarChar, 1000)
        paraPar1.Value = Para1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Para2", SqlDbType.NVarChar, 1000)
        paraPar2.Value = Para2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraPar3 As SqlParameter = New SqlParameter("@Para3", SqlDbType.NVarChar, 1000)
        paraPar3.Value = Para3
        mySqlComm.Parameters.Add(paraPar3)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.NVarChar, 2000)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding text: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

    Public Function ReturnStrWith4ParStr(ByVal strGet As String, ByVal Para1 As String, ByVal Para2 As String, ByVal Para3 As String, ByVal Para4 As String) As String

        Dim mySqlComm As New Data.SqlClient.SqlCommand(strGet, myConnection)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPar1 As SqlParameter = New SqlParameter("@Para1", SqlDbType.NVarChar, 1000)
        paraPar1.Value = Para1
        mySqlComm.Parameters.Add(paraPar1)

        Dim paraPar2 As SqlParameter = New SqlParameter("@Para2", SqlDbType.NVarChar, 1000)
        paraPar2.Value = Para2
        mySqlComm.Parameters.Add(paraPar2)

        Dim paraPar3 As SqlParameter = New SqlParameter("@Para3", SqlDbType.NVarChar, 1000)
        paraPar3.Value = Para3
        mySqlComm.Parameters.Add(paraPar3)

        Dim paraPar4 As SqlParameter = New SqlParameter("@Para4", SqlDbType.NVarChar, 1000)
        paraPar4.Value = Para4
        mySqlComm.Parameters.Add(paraPar4)

        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.NVarChar, 2000)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Dim IReturn As String

        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, String)
            Else
                IReturn = "False"
            End If

        Catch ex As SqlException
            MsgBox("Finding text: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False
        Finally
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try

        Return IReturn

    End Function

End Class
