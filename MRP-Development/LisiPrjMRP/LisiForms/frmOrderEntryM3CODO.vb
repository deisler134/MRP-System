Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop


Public Class frmOrderEntryM3CODO

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim LoadRow As Integer = 0

    Dim KeepDO As String = ""
    Dim KeepLine As String = ""
    Dim strSQL As String = ""
    Dim strSQLItemsID As String = ""
    Dim strSqlTable As String = ""
    Dim strSQLOrderID As String = ""
    Dim strSQLCustID As String = ""
    Dim strSQLInvID As String = ""
    Dim strSQLShipID As String = ""
    Dim strSQLPartID As String = ""
    Dim strSQLPMaster As String = ""

    Dim myReader As Data.SqlClient.SqlDataReader

    Dim NrRecordes As Integer = 0

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmOrderEntryM3CODO_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmOrderEntryM3CODO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1600 And Height > 900 Then
            Me.Width = 1600
            Me.Height = 900
        Else
            If Width < 1600 And Height < 900 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        GC.Collect()

        DisableFields()

        InitialComponents()

        PutDataGrid()

        FirstTimeMenuButtons()

        SetCtlForm()

        dgLoad.AutoGenerateColumns = False
        dgLoad.DataSource = dsMain
        dgLoad.DataMember = "tblSelect"

        dsMain.Clear()

        txtDOC.Text = ""

    End Sub

    Sub PutDataGrid()

        dgLoad.AutoGenerateColumns = False
        dgLoad.DataSource = dsMain
        dgLoad.DataMember = "tblSelect"

        dgLoad.ReadOnly = True



    End Sub

    Sub DisableFields()


    End Sub

    Sub FirstTimeMenuButtons()
        CmdCOs.Enabled = False
        CmdCOs.Visible = False

        CmdExec.Visible = False

        CmdDOs.Enabled = True
        CmdExport.Visible = True

        CmdPrint.Enabled = False

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblDOsLoadEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

    End Sub

    Sub SetCtlForm()

        '   dgLoad
        '   =======

        With Me.ID
            .DataPropertyName = "ID"
            .Name = "ID"
        End With

        With Me.DODONo
            .DataPropertyName = "DODONo"
            .Name = "DODONo"
        End With

        With Me.DOShipTo
            .DataPropertyName = "DOShipTo"
            .Name = "DOShipTo"
        End With

        With Me.DOFacility
            .DataPropertyName = "DOFacility"
            .Name = "DOFacility"
        End With

        With Me.DOLine
            .DataPropertyName = "DOLine"
            .Name = "DOLine"
        End With

        With Me.DOBl1
            .DataPropertyName = "DOBl1"
            .Name = "DOBl1"
        End With

        With Me.DOITNO
            .DataPropertyName = "DOITNO"
            .Name = "DOITNO"
        End With

        With Me.DOPN
            .DataPropertyName = "DOPN"
            .Name = "DOPN"
        End With

        With Me.DOPNSTATUS
            .DataPropertyName = "DOPNSTATUS"
            .Name = "DOPNSTATUS"
        End With

        With Me.DOMFGITNO
            .DataPropertyName = "DOMFGITNO"
            .Name = "DOMFGITNO"
        End With

        With Me.DOMFGPN
            .DataPropertyName = "DOMFGPN"
            .Name = "DOMFGPN"
        End With

        With Me.DOMFGPNSTATUS
            .DataPropertyName = "DOMFGPNSTATUS"
            .Name = "DOMFGPNSTATUS"
        End With

        With Me.DOQty
            .DataPropertyName = "DOQty"
            .Name = "DOQty"
        End With

        With Me.DOBl2
            .DataPropertyName = "DOBl2"
            .Name = "DOBl2"
        End With

        With Me.DOEntryDate
            .DataPropertyName = "DOEntryDate"
            .Name = "DOEntryDate"
        End With

        With Me.DODeliveryDate
            .DataPropertyName = "DODeliveryDate"
            .Name = "DODeliveryDate"
        End With

        With Me.DOSalesPrice
            .DataPropertyName = "DOSalesPrice"
            .Name = "DOSalesPrice"
        End With

        With Me.DODODate
            .DataPropertyName = "DODODate"
            .Name = "DODODate"
        End With

        With Me.BoeingPrice
            .DataPropertyName = "BoeingPrice"
            .Name = "BoeingPrice"
        End With

        With Me.DOERROR
            .DataPropertyName = "DOERROR"
            .Name = "DOERROR"
        End With

        With Me.OrdPartNoID
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
        End With

        With Me.OrdPartCross99ID
            .DataPropertyName = "OrdPartCross99ID"
            .Name = "OrdPartCross99ID"
        End With

    End Sub


    Private Sub CmdDOs_Click(sender As System.Object, e As System.EventArgs) Handles CmdDOs.Click

        dsMain.Clear()
        PutDataGrid()

        CmdExport.Visible = True
        CmdExec.Visible = False
        CmdPrint.Visible = False

        Dim dateNow As New System.DateTime
        dateNow = Date.Today.ToString


        Dim strcon = New SqlConnection(strConnection)
        strcon.open()

        Try
            Dim com As New SqlCommand("drop table DOsLoad", strcon)
            com.ExecuteNonQuery()
            MsgBox("Table has been droped")
        Catch ex As Exception
            MsgBox("Can not droped table")
        End Try

        Dim createSql As String
        Try
            Dim tblname = "DOsLoad"
            createSql = "CREATE TABLE " & tblname & " ([ID] INT NOT NULL IDENTITY(1,1)," & _
                "[DODONo]              NVARCHAR (25)   NULL," & _
                "[DOShipTo]            NVARCHAR (10)   NULL," & _
                "[DOFacility]          NVARCHAR (5)    NULL," & _
                "[DOLine]              NVARCHAR (5)    NULL," & _
                "[DOBl1]               NVARCHAR (2)    NULL," & _
                "[DOITNO]              NVARCHAR (10)   NULL," & _
                "[DOPN]                NVARCHAR (30)   NULL," & _
                "[DOQty]               INT             NULL," & _
                "[DOBl2]               NVARCHAR (5)    NULL," & _
                "[DOEntryDate]         SmallDateTime   NULL," & _
                "[DODeliveryDate]      SmallDateTime   NULL," & _
                "[DOSalesPrice]        SmallMoney      NULL," & _
                "[DODODate]            SmallDateTime   NULL," & _
                "PRIMARY KEY (ID));"

            Dim cmd As New SqlCommand(createSql, strcon)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        Dim SwPath As String = "\\srv115fs01\M3-PDF\MCDOS\Converted"
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
            'parser.ReadLine() 'skip column headers

            Dim strSqlTable As String = "INSERT INTO DOsLoad(DODONo, DOShipTo, DOFacility, DOLine, DOBl1, DOITNO, DOPN, DOQty, DOBl2, DOEntryDate, DODeliveryDate, DOSalesPrice, DODODate) " + _
                                              "VALUES (isnull(@DODONo,''), isnull(@DOShipTo,''), isnull(@DOFacility,''), isnull(@DOLine,''), isnull(@DOBl1,''), isnull(@DOITNO,''), isnull(@DOPN,''), isnull(@DOQty,0), isnull(@DOBl2,''), @DOEntryDate, @DODeliveryDate, @DOSalesPrice, @DODODate)"


            Using cn As New SqlConnection(strConnection), cmd As New SqlCommand(strSqlTable, cn)

                With cmd.Parameters
                    .Add("@DODONo", SqlDbType.VarChar, 25)
                    .Add("@DOShipTo", SqlDbType.VarChar, 10)
                    .Add("@DOFacility", SqlDbType.VarChar, 5)
                    .Add("@DOLine", SqlDbType.VarChar, 5)
                    .Add("@DOBl1", SqlDbType.VarChar, 2)
                    .Add("@DOITNO", SqlDbType.VarChar, 10)
                    .Add("@DOPN", SqlDbType.VarChar, 30)
                    .Add("@DOQty", SqlDbType.Int, 4)
                    .Add("@DOBl2", SqlDbType.VarChar, 5)
                    .Add("@DOEntryDate", SqlDbType.VarChar, 8)
                    .Add("@DODeliveryDate", SqlDbType.VarChar, 8)
                    .Add("@DOSalesPrice", SqlDbType.SmallMoney)
                    .Add("@DODODate", SqlDbType.VarChar, 8)
                End With

                cn.Open()
                Do Until parser.EndOfData = True
                    Dim fields() As String = parser.ReadFields()
                    For i As Integer = 0 To 12
                        If i = 0 Then
                            cmd.Parameters(i).Value = "00" + fields(i)
                        Else
                            cmd.Parameters(i).Value = fields(i)
                        End If
                    Next
                    cmd.ExecuteNonQuery()
                Loop
            End Using
            MsgBox("Action has been successfully completed.")

            dsMain.Clear()
            'dsMain.Relations.Clear()
            dsMain.EnforceConstraints = False

            CallClass.PopulateDataAdapter("gettblDOsLoad").Fill(dsMain, "tblSelect")

            PutDataGrid()

            txtDOC.Text = "DO"
            CmdExec.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        strcon.close()

        CmdPrint.Enabled = True

        ValidateLoadedData()

    End Sub

    Private Sub CmdExec_Click(sender As System.Object, e As System.EventArgs) Handles CmdExec.Click


        If txtDOC.Text = "DO" Then
            PutDO()
            CmdExec.Visible = False
        Else
            If txtDOC.Text = "CO" Then
                PutCO()
                CmdExec.Visible = False
            Else
                MessageBox.Show("!!! ERROR !!! Missing data to be updated.")
                Me.Dispose()
                CmdExec.Visible = True
            End If
        End If

    End Sub

    Sub ValidateLoadedData()

        Dim SwCross20 As String = ""
        Dim SwCross8899 As String = ""

        If dgLoad.RowCount > 0 Then

            For I As Integer = 0 To (dgLoad.Rows.Count - 2)
                dgLoad("DOPNSTATUS", I).Value = CallClass.TakeFinalSt("cspReturnM3StatusByPN", dgLoad("DOPN", I).Value)
                If dgLoad("DOPNSTATUS", I).Value = "False" Then
                    dgLoad("DOPNSTATUS", I).Style.BackColor = Color.LightSalmon
                Else
                    If dgLoad("DOPNSTATUS", I).Value = 99 Or dgLoad("DOPNSTATUS", I).Value = 88 Then

                        SwCross8899 = CallClass.TakeFinalSt("cspReturnPartIDWithPartNumber", dgLoad("DOPN", I).Value)     ' return ID part status 88/99
                        SwCross20 = CallClass.ReturnStrWithParInt("cspReturnM3CrossPN_ID_20", SwCross8899)                ' return ID part status 20

                        dgLoad("OrdPartNoID", I).Value = SwCross8899

                        If SwCross20 = "False" Then
                            dgLoad("DOMFGPN", I).Style.BackColor = Color.LightSalmon
                            dgLoad("DOMFGPNSTATUS", I).Style.BackColor = Color.LightSalmon
                        Else
                            dgLoad("DOMFGPN", I).Value = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", SwCross20)
                            dgLoad("OrdPartCross99ID", I).Value = SwCross20
                            dgLoad("DOMFGITNO", I).Value = CallClass.ReturnStrWithParString("cspReturnM3Article", dgLoad("DOMFGPN", I).Value)
                            dgLoad("DOMFGPNSTATUS", I).Value = CallClass.TakeFinalSt("cspReturnM3StatusByPN", dgLoad("DOMFGPN", I).Value)
                        End If

                    Else
                        SwCross20 = CallClass.TakeFinalSt("cspReturnPartIDWithPartNumber", dgLoad("DOPN", I).Value)

                        dgLoad("DOMFGPN", I).Value = dgLoad("DOPN", I).Value
                        dgLoad("OrdPartCross99ID", I).Value = SwCross20
                        dgLoad("OrdPartNoID", I).Value = SwCross20
                        dgLoad("DOMFGITNO", I).Value = CallClass.ReturnStrWithParString("cspReturnM3Article", dgLoad("DOMFGPN", I).Value)
                        dgLoad("DOMFGPNSTATUS", I).Value = CallClass.TakeFinalSt("cspReturnM3StatusByPN", dgLoad("DOMFGPN", I).Value)

                    End If
                End If
            Next

            '=================

            For I As Integer = 0 To (dgLoad.Rows.Count - 2)

                Dim SwVal As Boolean = True
                Dim SwTestM3ItemCustPN As Integer = 0

                If IsNothing(dgLoad("DOITNO", I).Value) = True Or IsDBNull(dgLoad("DOITNO", I).Value) = True Or Nz.Nz(dgLoad("DOITNO", I).Value) = 0 Then
                    dgLoad("DOITNO", I).Style.BackColor = Color.LightSalmon
                    SwVal = False
                End If

                If IsNothing(dgLoad("DOPNSTATUS", I).Value) = True Or IsDBNull(dgLoad("DOPNSTATUS", I).Value) = True Or Nz.Nz(dgLoad("DOPNSTATUS", I).Value) = 0 Then
                    dgLoad("DOPNSTATUS", I).Style.BackColor = Color.LightSalmon
                    SwVal = False
                Else
                    SwTestM3ItemCustPN = CallClass.ReturnStrWithParString("cspReturnM3Article", dgLoad("DOPN", I).Value)   ' return Cust PN ITNO from LAC DB
                    If SwTestM3ItemCustPN = 0 Then

                        dgLoad("DOITNO", I).Style.BackColor = Color.LightSkyBlue

                        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePartM3ITNO", cn)
                        mySqlComm.CommandType = CommandType.StoredProcedure

                        If dgLoad("DOPNSTATUS", I).Value = 99 Or dgLoad("DOPNSTATUS", I).Value = 88 Then
                            Dim paraPart As SqlParameter = New SqlParameter("@OrdPartID", SqlDbType.Int, 4)
                            paraPart.Value = SwCross8899
                            mySqlComm.Parameters.Add(paraPart)
                        Else
                            Dim paraPart As SqlParameter = New SqlParameter("@OrdPartID", SqlDbType.Int, 4)
                            paraPart.Value = SwCross20
                            mySqlComm.Parameters.Add(paraPart)
                        End If

                        Dim paraITNO As SqlParameter = New SqlParameter("@OrdITNO", SqlDbType.NVarChar, 50)
                        paraITNO.Value = dgLoad("DOITNO", I).Value
                        mySqlComm.Parameters.Add(paraITNO)

                        Try
                            If cn.State = ConnectionState.Open Then
                                cn.Close()
                            End If
                            cn.Open()
                            mySqlComm.ExecuteNonQuery()
                            If cn.State = ConnectionState.Open Then
                                cn.Close()
                            End If
                        Catch ex As Exception
                            MsgBox("ERROR Update process for M3 ITNO: " & ex.Message)
                        Finally
                            If cn.State = ConnectionState.Open Then
                                cn.Close()
                            End If
                        End Try

                    End If

                End If

                If IsNothing(dgLoad("DOMFGITNO", I).Value) = True Or IsDBNull(dgLoad("DOMFGITNO", I).Value) = True Or Nz.Nz(dgLoad("DOMFGITNO", I).Value) = 0 Then
                    dgLoad("DOMFGITNO", I).Style.BackColor = Color.LightSalmon
                    SwVal = False
                End If

                If IsNothing(dgLoad("DOMFGPN", I).Value) = True Or IsDBNull(dgLoad("DOMFGPN", I).Value) = True Then
                    dgLoad("DOMFGPN", I).Style.BackColor = Color.LightSalmon
                    SwVal = False
                End If

                If IsNothing(dgLoad("DOMFGPNSTATUS", I).Value) = True Or IsDBNull(dgLoad("DOMFGPNSTATUS", I).Value) = True Or Nz.Nz(dgLoad("DOMFGPNSTATUS", I).Value) = 0 Then
                    dgLoad("DOMFGPNSTATUS", I).Style.BackColor = Color.LightSalmon
                    SwVal = False
                Else
                    If Nz.Nz(dgLoad("DOMFGPNSTATUS", I).Value) <> 20 Then
                        dgLoad("DOMFGPNSTATUS", I).Style.BackColor = Color.LightSalmon
                        SwVal = False
                    End If
                End If


                If SwVal = True Then
                    dgLoad("DOERROR", I).Value = "OK"
                Else
                    dgLoad("DOERROR", I).Value = "ERROR"
                    dgLoad("DOERROR", I).Style.BackColor = Color.LightSalmon
                End If

            Next

        End If

    End Sub

    Sub PutDO()

        Dim II, JJ As Integer
        JJ = dgLoad.Rows.Count

        KeepDO = ""
        KeepLine = ""
        txtOrderID.Text = 0
        txtOrdDelivID.Text = 0

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        For II = 1 To JJ - 1

            LoadRow = II

            KeepDO = dgLoad.Item("DODONo", II - 1).Value
            KeepLine = dgLoad.Item("DOLine", II - 1).Value

            strSQLOrderID = "SELECT tblCustOrder.OrderID FROM tblCustOrder WHERE ((tblCustOrder.OrdNumber)= '" & KeepDO & "')"

            Dim mySqlComm As New Data.SqlClient.SqlCommand(strSQLOrderID, cn)

            Try

                If II > 1 Then
                    If myReader.IsClosed = False Then
                        myReader.Close()
                    End If
                End If

                myReader = mySqlComm.ExecuteReader()

                Dim TestRec As Int16
                TestRec = myReader.HasRows
                If TestRec <> -1 Then
                    Add_tblCustOrder_All_Tables()               ' New DO  to add into LAC DO, DO line , ship and inv info
                    NrRecordes = NrRecordes + 1
                Else
                    While myReader.Read()
                        txtOrderID.Text = myReader.GetValue(0)
                    End While
                    CheckOrderLine()                ' check if the DO Line exist in cust ordrer 
                End If

            Catch ex As Exception
                MsgBox("Exception occured - To Find OrderID  " & ex.Message)

            Finally

            End Try

        Next

        cn.Close()
        myReader.Close()

        MessageBox.Show("DOs lines to be integrated into LAC database: " + Str(dsMain.Tables("tblSelect").Rows.Count) + "  DO Lines integreaded: " + Str(NrRecordes))

        dsMain.Clear()
        PutDataGrid()

    End Sub

    Sub PutCO()

    End Sub

    Private Sub CheckOrderLine()

        strSQLitemsid = "SELECT tblCustOrderItem.OrderItemsID FROM tblCustOrderItem WHERE ((tblCustOrderItem.OrderID) = '" & txtOrderID.Text & "'  AND (tblCustOrderItem.OrdItemNo) = '" & KeepLine & "' )"
        Dim mySqlCommLine As New Data.SqlClient.SqlCommand(strSQLitemsid, cn)

        Try
            If myReader.IsClosed = False Then
                myReader.Close()
            End If
            myReader = mySqlCommLine.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                Add_tblCustOrderItem_Only()
                NrRecordes = NrRecordes + 1
            End If

        Catch ex As Exception
            MsgBox("Exception occured - To Find OrderItemsID  " & ex.Message)
        End Try

    End Sub

    Private Sub Add_tblCustOrder_All_Tables()


        '#######################################################################
        '
        '   CHECK the store procedure for shipnotes  cspUpdateAllCustOrderInsert
        '
        '########################################################################

        Dim cmdInsertOrder As SqlCommand = New SqlCommand("cspUpdateAllCustOrderInsert", cn)
        cmdInsertOrder.CommandType = CommandType.StoredProcedure

        '  tblCustOrder
        ' ============================

        ' we need to add the code when Spirit will come (this code is working now only for LNA and MHI DOs)
        ' Select Case DOShipTo
        '       Case MHI
        '           Dim StrCustLNA As String = "MHI" or we can go with ID value = 356 - changed to 299 LNA
        '       Case SPI
        '           Dim StrCustLNA As String = "SPI" or we can go with ID value
        '       Other
        '           Dim StrCustLNA As String = "LNA" or we can go with ID value = 299

        Dim StrCustLNA As String = ""
        Dim IDCustLNA As Integer = 0

        'strSQLCustID = "SELECT tblCustomers.CustomerID FROM tblCustomers WHERE ((tblCustomers.CustomerShort)= '" & StrCustLNA & "')"

        'Dim mySqlCommCustLNA As New Data.SqlClient.SqlCommand(strSQLCustID, cn)

        'Try
        '    If myReader.IsClosed = False Then
        '        myReader.Close()
        '    End If
        '    myReader = mySqlCommCustLNA.ExecuteReader()

        '    Dim TestRec As Int16
        '    TestRec = myReader.HasRows
        '    If TestRec <> -1 Then
        '        IDCustLNA = 299    'if ERROR with LNA by default I put the ID = 299
        '    Else
        '        While myReader.Read()
        '            IDCustLNA = myReader.GetValue(0)
        '        End While

        '    End If

        'Catch ex As Exception
        '    MsgBox("Exception occured - To Find LNA ID in Customers Table   " & ex.Message)

        'Finally

        'End Try

        Select Case dgLoad.Item("DOShipTo", LoadRow - 1).Value
            Case "MHI"
                StrCustLNA = "MHI"
                IDCustLNA = 299
            Case "EMB"
                StrCustLNA = "EMB"
                IDCustLNA = 299
            Case Else
                StrCustLNA = "LNA"
                IDCustLNA = 299
        End Select

        ' MAIN IF WITH OK TEST
        If dgLoad.Item("DOERROR", LoadRow - 1).Value = "OK" Then

            Dim parOrdID As SqlParameter = New SqlParameter("@OrderID", SqlDbType.Int, 4)
            parOrdID.Value = CInt(txtOrderID.Text)
            cmdInsertOrder.Parameters.Add(parOrdID)

            Dim parCustID As SqlParameter = New SqlParameter("@CustID", SqlDbType.Int, 4)
            parCustID.Value = IDCustLNA
            cmdInsertOrder.Parameters.Add(parCustID)

            Dim parOrdNumber As SqlParameter = New SqlParameter("@OrdNumber", SqlDbType.NVarChar, 50)
            parOrdNumber.Value = dgLoad.Item("DODONo", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parOrdNumber)

            Dim parORDRefNo As SqlParameter = New SqlParameter("@ORDRefNo", SqlDbType.NVarChar, 50)
            parORDRefNo.Value = dgLoad.Item("DODONo", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parORDRefNo)

            Dim parOrdDate As SqlParameter = New SqlParameter("@OrdDate", SqlDbType.SmallDateTime, 4)
            parOrdDate.Value = dgLoad.Item("DOEntryDate", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parOrdDate)

            Dim parOrdDateRecv As SqlParameter = New SqlParameter("@OrdDateRecv", SqlDbType.SmallDateTime, 4)
            parOrdDateRecv.Value = dgLoad.Item("DODODate", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parOrdDateRecv)

            Dim parOrdDevise As SqlParameter = New SqlParameter("@OrdDevise", SqlDbType.NVarChar, 5)
            parOrdDevise.Value = "USD"
            cmdInsertOrder.Parameters.Add(parOrdDevise)

            Dim parOrdStatus As SqlParameter = New SqlParameter("@OrdStatus", SqlDbType.NVarChar, 10)
            parOrdStatus.Value = "Active"
            cmdInsertOrder.Parameters.Add(parOrdStatus)

            Dim parOrdTerms As SqlParameter = New SqlParameter("@OrdTerms", SqlDbType.NVarChar, 30)
            parOrdTerms.Value = "Net 30 Days"
            cmdInsertOrder.Parameters.Add(parOrdTerms)

            Dim parOrdType As SqlParameter = New SqlParameter("@OrdType", SqlDbType.NVarChar, 25)
            parOrdType.Value = "Min/Max"
            cmdInsertOrder.Parameters.Add(parOrdType)

            '  tblCustOrderInvInfo
            ' ============================

            Dim StrLNA As String = "LNA" ' This code is working now only for LNA & MHI & EMB - For Spirit we need to add new code
            Dim IDLNA As Integer = 0

            'strSQLInvID = "SELECT tblCustInv.CustInvID FROM tblCustInv WHERE ((tblCustInv.InvShortName)= '" & StrLNA & "')"

            'Dim mySqlCommLNA As New Data.SqlClient.SqlCommand(strSQLInvID, cn)

            'Try
            '    If myReader.IsClosed = False Then
            '        myReader.Close()
            '    End If
            '    myReader = mySqlCommLNA.ExecuteReader()

            '    Dim TestRec As Int16
            '    TestRec = myReader.HasRows
            '    If TestRec <> -1 Then
            '        IDLNA = 115
            '    Else
            '        While myReader.Read()
            '            IDLNA = myReader.GetValue(0)
            '        End While

            '    End If

            'Catch ex As Exception
            '    MsgBox("Exception occured - To Find LNA ID in Customer Invoice Info Table   " & ex.Message)

            'Finally

            'End Try

            Select Case dgLoad.Item("DOShipTo", LoadRow - 1).Value
                Case "MHI"
                    StrLNA = "MHI"   'we'll use LNA for biling for MHI products
                    IDLNA = 115
                Case "EMB"
                    StrLNA = "EMB"   'we'll use LNA for biling for EMB products
                    IDLNA = 115
                Case Else
                    StrLNA = "LNA"
                    IDLNA = 115
            End Select

            Dim parInvID As SqlParameter = New SqlParameter("@OrdInvID", SqlDbType.Int, 4)
            parInvID.Value = 0
            cmdInsertOrder.Parameters.Add(parInvID)

            Dim parInvLine As SqlParameter = New SqlParameter("@InvLine", SqlDbType.TinyInt, 1)
            parInvLine.Value = "1"
            cmdInsertOrder.Parameters.Add(parInvLine)

            ' need to add the code for Spirit
            Dim parInvWhere As SqlParameter = New SqlParameter("@InvWhere", SqlDbType.Int, 4)
            parInvWhere.Value = IDLNA
            cmdInsertOrder.Parameters.Add(parInvWhere)


            '====== tblCustOrderShipInfo  OrdInvID


            Dim parShipID As SqlParameter = New SqlParameter("@OrdShipID", SqlDbType.Int, 4)
            parShipID.Value = 0
            cmdInsertOrder.Parameters.Add(parShipID)

            Dim parShipLine As SqlParameter = New SqlParameter("@ShipLine", SqlDbType.TinyInt, 1)
            parShipLine.Value = "1"
            cmdInsertOrder.Parameters.Add(parShipLine)


            'Dim StrWHSE As String = "BCE"

            Dim StrWHSE As String = ""
            Dim IDWhere As Integer = 0

            StrWHSE = dgLoad.Item("DOShipTo", LoadRow - 1).Value

            strSQLShipID = "SELECT tblCustShip.CustShipID FROM tblCustShip WHERE ((tblCustShip.ShipShortName)= '" & StrWHSE & "')"

            Dim mySqlCommWHSE As New Data.SqlClient.SqlCommand(strSQLShipID, cn)

            Try

                If myReader.IsClosed = False Then
                    myReader.Close()
                End If
                myReader = mySqlCommWHSE.ExecuteReader()

                Dim TestRec As Int16
                TestRec = myReader.HasRows
                If TestRec <> -1 Then
                    IDWhere = 0
                Else
                    While myReader.Read()
                        IDWhere = myReader.GetValue(0)
                    End While
                End If

            Catch ex As Exception
                MsgBox("Exception occured - To Find Ship to WHSE   " & ex.Message)

            Finally

            End Try

            Dim parShipWhere As SqlParameter = New SqlParameter("@ShipWhere", SqlDbType.Int, 4)
            parShipWhere.Value = IDWhere
            cmdInsertOrder.Parameters.Add(parShipWhere)

            Dim parShipNotes As SqlParameter = New SqlParameter("@ShipNotes", SqlDbType.NVarChar, 500)
            parShipNotes.Value = ""
            cmdInsertOrder.Parameters.Add(parShipNotes)

            'tblCustOrderItem
            '===========================

            Dim parItemOrderID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
            parItemOrderID.Value = 0
            cmdInsertOrder.Parameters.Add(parItemOrderID)

            Dim parItemLine As SqlParameter = New SqlParameter("@OrdItemNo", SqlDbType.NVarChar, 20)
            parItemLine.Value = dgLoad.Item("DOLine", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parItemLine)

            'Dim StrPartNo As String = dgLoad.Item("DOPN", LoadRow - 1).Value
            'Dim PartItemID As Integer = 0
            'strSQLPartID = "SELECT tblPartMaster.PartID FROM tblPartMaster WHERE ((tblPartMaster.PartNumber)= '" & StrPartNo & "')"

            'Dim mySqlCommPartID As New Data.SqlClient.SqlCommand(strSQLPartID, cn)

            'Try
            '    If myReader.IsClosed = False Then
            '        myReader.Close()
            '    End If
            '    myReader = mySqlCommPartID.ExecuteReader()

            '    Dim TestRec As Int16
            '    TestRec = myReader.HasRows
            '    If TestRec <> -1 Then
            '        PartItemID = 0
            '    Else
            '        While myReader.Read()
            '            PartItemID = myReader.GetValue(0)
            '        End While
            '    End If
            'Catch ex As Exception
            '    MsgBox("Exception occured - To Find Part ID   " & ex.Message)
            'Finally
            'End Try

            'Dim parItemPartID As SqlParameter = New SqlParameter("@OrdPartNoID", SqlDbType.Int, 4)
            'parItemPartID.Value = PartItemID
            'cmdInsertOrder.Parameters.Add(parItemPartID)

            'Dim parrItemPartCross As SqlParameter = New SqlParameter("@OrdPartCross99ID", SqlDbType.Int, 4)
            'parrItemPartCross.Value = PartItemID
            'cmdInsertOrder.Parameters.Add(parrItemPartCross)

            Dim parItemPartID As SqlParameter = New SqlParameter("@OrdPartNoID", SqlDbType.Int, 4)
            parItemPartID.Value = dgLoad.Item("OrdPartNoID", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parItemPartID)

            Dim parrItemPartCross As SqlParameter = New SqlParameter("@OrdPartCross99ID", SqlDbType.Int, 4)
            parrItemPartCross.Value = dgLoad.Item("OrdPartCross99ID", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parrItemPartCross)

            Dim parItemQty As SqlParameter = New SqlParameter("@OrdItemQty", SqlDbType.Real, 4)
            parItemQty.Value = dgLoad.Item("DOQty", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parItemQty)

            Dim parItemUM As SqlParameter = New SqlParameter("@OrdItemUM", SqlDbType.NVarChar, 5)
            parItemUM.Value = "EA"
            cmdInsertOrder.Parameters.Add(parItemUM)

            Dim parItemPrice As SqlParameter = New SqlParameter("@OrdItemPrice", SqlDbType.Money, 8)
            parItemPrice.Value = dgLoad.Item("DOSalesPrice", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parItemPrice)

            Dim parItemStatus As SqlParameter = New SqlParameter("@OrdItemStatus", SqlDbType.NVarChar, 10)
            parItemStatus.Value = "Active"
            cmdInsertOrder.Parameters.Add(parItemStatus)

            Dim parItemNotes As SqlParameter = New SqlParameter("@OrdItemNotes", SqlDbType.NVarChar, 500)
            parItemNotes.Value = "DOs  -  Automatically Integration"
            cmdInsertOrder.Parameters.Add(parItemNotes)

            'tblCustOrderItemDeliv
            '===========================

            Dim parDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            parDelivID.Value = 0
            cmdInsertOrder.Parameters.Add(parDelivID)

            'Dim parItemDelivID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
            'parItemDelivID.Value = 0
            'cmdInsertOrder.Parameters.Add(parItemDelivID)

            Dim parDelivDate As SqlParameter = New SqlParameter("@DelivDate", SqlDbType.SmallDateTime, 4)
            parDelivDate.Value = dgLoad.Item("DODeliveryDate", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parDelivDate)

            Dim parDelivQty As SqlParameter = New SqlParameter("@DelivQty", SqlDbType.Real, 4)
            parDelivQty.Value = dgLoad.Item("DOQty", LoadRow - 1).Value
            cmdInsertOrder.Parameters.Add(parDelivQty)

            'for Spirit need to be Estimated
            Dim parDelivType As SqlParameter = New SqlParameter("@DelivType", SqlDbType.NVarChar, 25)
            parDelivType.Value = "Confirmed"
            cmdInsertOrder.Parameters.Add(parDelivType)

            Dim parDelivStatus As SqlParameter = New SqlParameter("@DelivStatus", SqlDbType.NVarChar, 10)
            parDelivStatus.Value = "Active"
            cmdInsertOrder.Parameters.Add(parDelivStatus)

            'for Spirit need to be Empty
            Dim parDelivDermDate As SqlParameter = New SqlParameter("@DelivFermDate", SqlDbType.SmallDateTime, 4)
            parDelivDermDate.Value = Now.ToShortDateString
            cmdInsertOrder.Parameters.Add(parDelivDermDate)

            Try
                If myReader.IsClosed = False Then
                    myReader.Close()
                End If

                cmdInsertOrder.ExecuteNonQuery()
                cmdInsertOrder.Dispose()
            Catch ex As SqlException
                MsgBox(" !!! ERROR !!! Add New DO: " & ex.Message)
            End Try


            ' MAIN IF WITH OK TEST
        End If


    End Sub

    Private Sub Add_tblCustOrderItem_Only()


        ' MAIN IF WITH OK TEST
        If dgLoad.Item("DOERROR", LoadRow - 1).Value = "OK" Then



            Dim cmdInsertOrderItem As SqlCommand = New SqlCommand("cspUpdateAllCustOrderLinesOnly", cn)
            cmdInsertOrderItem.CommandType = CommandType.StoredProcedure

            'tblCustOrderItem
            '===========================

            Dim parItemOrderItemsID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
            parItemOrderItemsID.Value = 0
            cmdInsertOrderItem.Parameters.Add(parItemOrderItemsID)

            Dim parItemsOrderID As SqlParameter = New SqlParameter("@OrderID", SqlDbType.Int, 4)
            parItemsOrderID.Value = CInt(txtOrderID.Text)
            cmdInsertOrderItem.Parameters.Add(parItemsOrderID)

            Dim parItemsLine As SqlParameter = New SqlParameter("@OrdItemNo", SqlDbType.NVarChar, 20)
            parItemsLine.Value = dgLoad.Item("DOLine", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parItemsLine)

            'Dim StrPartNo As String = dgLoad.Item("DOPN", LoadRow - 1).Value
            'Dim PartItemID As Integer = 0
            'strSQLPMaster = "SELECT tblPartMaster.PartID FROM tblPartMaster WHERE ((tblPartMaster.PartNumber)= '" & StrPartNo & "')"

            'Dim mySqlCommPartIDLine As New Data.SqlClient.SqlCommand(strSQLPMaster, cn)

            'Try
            '    If myReader.IsClosed = False Then
            '        myReader.Close()
            '    End If
            '    myReader = mySqlCommPartIDLine.ExecuteReader()

            '    Dim TestRec As Int16
            '    TestRec = myReader.HasRows
            '    If TestRec <> -1 Then
            '        PartItemID = 0
            '    Else
            '        While myReader.Read()
            '            PartItemID = myReader.GetValue(0)
            '        End While
            '    End If
            'Catch ex As Exception
            '    MsgBox("Exception occured - To Find Part ID   " & ex.Message)
            'Finally
            'End Try

            'Dim parItemsPartID As SqlParameter = New SqlParameter("@OrdPartNoID", SqlDbType.Int, 4)
            'parItemsPartID.Value = PartItemID
            'cmdInsertOrderItem.Parameters.Add(parItemsPartID)

            'Dim parrItemPartCross As SqlParameter = New SqlParameter("@OrdPartCross99ID", SqlDbType.Int, 4)
            'parrItemPartCross.Value = PartItemID
            'cmdInsertOrderItem.Parameters.Add(parrItemPartCross)

            Dim parItemPartID As SqlParameter = New SqlParameter("@OrdPartNoID", SqlDbType.Int, 4)
            parItemPartID.Value = dgLoad.Item("OrdPartNoID", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parItemPartID)

            Dim parrItemPartCross As SqlParameter = New SqlParameter("@OrdPartCross99ID", SqlDbType.Int, 4)
            parrItemPartCross.Value = dgLoad.Item(" OrdPartCross99ID", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parrItemPartCross)

            Dim parItemsQty As SqlParameter = New SqlParameter("@OrdItemQty", SqlDbType.Real, 4)
            parItemsQty.Value = dgLoad.Item("DOQty", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parItemsQty)

            Dim parItemsUM As SqlParameter = New SqlParameter("@OrdItemUM", SqlDbType.NVarChar, 5)
            parItemsUM.Value = "EA"
            cmdInsertOrderItem.Parameters.Add(parItemsUM)

            Dim parItemsPrice As SqlParameter = New SqlParameter("@OrdItemPrice", SqlDbType.Money, 8)
            parItemsPrice.Value = dgLoad.Item("DOSalesPrice", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parItemsPrice)

            Dim parItemsStatus As SqlParameter = New SqlParameter("@OrdItemStatus", SqlDbType.NVarChar, 10)
            parItemsStatus.Value = "Active"
            cmdInsertOrderItem.Parameters.Add(parItemsStatus)

            Dim parItemsNotes As SqlParameter = New SqlParameter("@OrdItemNotes", SqlDbType.NVarChar, 500)
            parItemsNotes.Value = "DOs  -  Automatically Integration"
            cmdInsertOrderItem.Parameters.Add(parItemsNotes)


            'tblCustOrderItemDeliv
            '===========================

            Dim parsDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            parsDelivID.Value = 0
            cmdInsertOrderItem.Parameters.Add(parsDelivID)

            Dim parsDelivDate As SqlParameter = New SqlParameter("@DelivDate", SqlDbType.SmallDateTime, 4)
            parsDelivDate.Value = dgLoad.Item("DODeliveryDate", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parsDelivDate)

            Dim parsDelivQty As SqlParameter = New SqlParameter("@DelivQty", SqlDbType.Real, 4)
            parsDelivQty.Value = dgLoad.Item("DOQty", LoadRow - 1).Value
            cmdInsertOrderItem.Parameters.Add(parsDelivQty)


            '    to add in the future, bellow the code for Spirt with Estimate status 
            '================================================================
            Dim parsDelivType As SqlParameter = New SqlParameter("@DelivType", SqlDbType.NVarChar, 25)
            parsDelivType.Value = "Confirmed"
            cmdInsertOrderItem.Parameters.Add(parsDelivType)

            Dim parsDelivStatus As SqlParameter = New SqlParameter("@DelivStatus", SqlDbType.NVarChar, 10)
            parsDelivStatus.Value = "Active"
            cmdInsertOrderItem.Parameters.Add(parsDelivStatus)

            '    to add in the future, bellow the code for Spirt with EMPTY FERM DATE
            '========================================================================
            Dim parsDelivDermDate As SqlParameter = New SqlParameter("@DelivFermDate", SqlDbType.SmallDateTime, 4)
            parsDelivDermDate.Value = Now.ToShortDateString
            cmdInsertOrderItem.Parameters.Add(parsDelivDermDate)

            Try
                If myReader.IsClosed = False Then
                    myReader.Close()
                End If

                cmdInsertOrderItem.ExecuteNonQuery()
                cmdInsertOrderItem.Dispose()
            Catch ex As SqlException
                MsgBox(" !!! ERROR !!! Add New DO LINE: " & ex.Message)
            End Try


            ' MAIN IF WITH OK TEST
        End If


    End Sub


    Private Sub dgLoad_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLoad.CellClick

        If dgLoad.RowCount > 0 Then


            Dim strYear As Integer = 0

            Dim dateNow As New System.DateTime
            dateNow = Date.Today.ToString

            Dim Bprice As Double = 0.0
            Dim Difprice As Double = 0.0

            For I As Integer = 0 To (dgLoad.Rows.Count - 1)

                dateNow = dgLoad("DODODate", I).Value
                strYear = Year(dateNow)
                If CallClass.ReturnStrWith2ParStr("cspReturnBoeingYearPrice", Nz.Nz(dgLoad("DOPN", I).Value), strYear) <> False Then
                    dgLoad("BoeingPrice", I).Value = CallClass.ReturnStrWith2ParStr("cspReturnBoeingYearPrice", Nz.Nz(dgLoad("DOPN", I).Value), strYear)

                    Bprice = CDbl(Nz.Nz(dgLoad("BoeingPrice", I).Value))
                    Difprice = dgLoad("DOSalesPrice", I).Value - Bprice

                    If Difprice <> 0.0 Then
                        dgLoad("BoeingPrice", I).Style.BackColor = Color.LightSalmon
                        dgLoad("DOERROR", I).Value = "ERROR"
                        dgLoad("DOERROR", I).Style.BackColor = Color.LightSalmon
                    End If
                Else
                    If IsNothing(dgLoad("DOPN", I).Value) = False Then
                        dgLoad("BoeingPrice", I).Style.BackColor = Color.LightSalmon
                        dgLoad("DOERROR", I).Value = "ERROR"
                        dgLoad("DOERROR", I).Style.BackColor = Color.LightSalmon
                    End If

                End If

            Next I

        End If

    End Sub

    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click

        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim rptPO As New rptDOsContractReview()
        rptPO.Load("..\rptDOsContractReview.rpt")

        rptPO.ReportOptions.EnableSaveDataWithReport = False

        Try
            Me.Cursor = Cursors.WaitCursor
            frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
            frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
            frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = True
            frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
            frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
            frmPOMasterPrint.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Sub frmOrderEntryM3CODO_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        'Dim RW As Double = (Me.Width - CW) / CW ' Ratio change of width
        'Dim RH As Double = (Me.Height - CH) / CH ' Ratio change of height

        'For Each Ctrl As Control In Controls
        '    Ctrl.Width += CInt(Ctrl.Width * RW)
        '    Ctrl.Height += CInt(Ctrl.Height * RH)
        '    Ctrl.Left += CInt(Ctrl.Left * RW)
        '    Ctrl.Top += CInt(Ctrl.Top * RH)
        'Next

        'CW = Me.Width
        'CH = Me.Height

        'Dim Screen As System.Drawing.Rectangle
        'Screen = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea()
        'Me.Top = (Screen.Height \ 2) - (Me.Height \ 2)
        'Me.Left = (Screen.Width \ 2) - (Me.Width \ 2)

    End Sub

    Private Sub CmdExport_Click(sender As Object, e As EventArgs) Handles CmdExport.Click

        If dgLoad.Rows.Count - 2 >= 0 Then
        Else
            MsgBox("Nothing to Export.")
            Exit Sub
        End If

        CmdExport.Visible = True
        CmdExec.Visible = True
        CmdPrint.Visible = True

        Me.Cursor = Cursors.WaitCursor

        Try

            'Dim wapp As Microsoft.Office.Interop.Excel.Application
            'Dim wsheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim wbook As Microsoft.Office.Interop.Excel.Workbook
            'wapp = New Microsoft.Office.Interop.Excel.Application

            Me.Cursor = Cursors.WaitCursor

            Dim wapp As Excel.Application
            Dim wsheet As Excel.Worksheet
            Dim wbook As Excel.Workbook
            wapp = New Excel.Application

            wapp.Visible = True

            wbook = wapp.Workbooks.Add()
            wsheet = wbook.ActiveSheet

            Dim iX As Integer
            Dim iY As Integer
            Dim iC As Integer

            For iC = 0 To dgLoad.Columns.Count - 1
                wsheet.Cells(1, iC + 1).Value = dgLoad.Columns(iC).HeaderText
            Next

            wsheet.Rows(2).select()

            For iX = 0 To dgLoad.Rows.Count - 1
                For iY = 0 To dgLoad.Columns.Count - 1
                    wsheet.Cells(iX + 2, iY + 1).value = dgLoad(iY, iX).Value
                Next
            Next
            wapp.Visible = True
            wapp.UserControl = True

            Me.Cursor = Cursors.Default

        Catch ex As Exception

            MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

        End Try

        Me.Cursor = Cursors.Default

    End Sub
End Class