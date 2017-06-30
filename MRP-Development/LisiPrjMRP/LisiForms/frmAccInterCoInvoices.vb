Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Text

Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.IO


Public Class frmAccInterCoInvoices
    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim KeepNo As Integer = 0

    Dim KeepIdent As String
    Dim FileNameStr As String

    Private Sub frmAccInterCoInvoices_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmAccInterCoInvoices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        ClearFields()

        InitialComponents()

        SetCtlForm()

        txtAccDate.Text = Now.ToShortDateString

        CmdSearch.Enabled = False
        CmdExport.Enabled = False
        CmdFTP.Enabled = False

    End Sub

    Sub ClearFields()

        CmbComp.SelectedIndex = -1

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getAccInterCOInvoicesEmpty").Fill(dsMain, "tblSelect")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgMPO.AutoGenerateColumns = False
        dgMPO.DataSource = dsMain
        dgMPO.DataMember = "tblSelect"

    End Sub

    Sub SetCtlForm()


        With Me.CmbComp
            .DataSource = CallClass.PopulateComboBox("tblCustInv", "cmbGetAccInterCoName").Tables("tblCustInv")
            .DisplayMember = "InvInterCoPrefix"
            .ValueMember = "InvInterCoPrefix"
        End With


        'dgmpo

        With Me.LACData
            .DataPropertyName = "LACData"
            .Name = "LACData"
        End With

        With Me.PslipInterCoPrefix
            .DataPropertyName = "PslipInterCoPrefix"
            .Name = "PslipInterCoPrefix"
            .Visible = False
        End With

        With Me.PslipNo
            .DataPropertyName = "PslipNo"
            .Name = "PslipNo"
            .Visible = False
        End With

        With Me.InvDate
            .DataPropertyName = "InvDate"
            .Name = "InvDate"
            .Visible = False
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
            .Visible = False
        End With

        With Me.IVAM
            .DataPropertyName = "IVAM"
            .Name = "IVAM"
            .Visible = False
        End With

        With Me.InvDevise
            .DataPropertyName = "InvDevise"
            .Name = "InvDevise"
            .Visible = False
        End With

        With Me.ACDT
            .DataPropertyName = "ACDT"
            .Name = "ACDT"
            .Visible = False
        End With

        With Me.PslipCustPoContr
            .DataPropertyName = "PslipCustPoContr"
            .Name = "PslipCustPoContr"
            .Visible = False
        End With

        With Me.ParInv
            .DataPropertyName = "ParInv"
            .Name = "ParInv"
            .Visible = False
        End With

        With Me.InvTerms
            .DataPropertyName = "InvTerms"
            .Name = "InvTerms"
            .Visible = False
        End With

        With Me.SwInvDate
            .DataPropertyName = "SwInvDate"
            .Name = "SwInvDate"
            .Visible = False
        End With

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If


        Me.Refresh()

        If Len(Trim(CmbComp.Text)) > 0 Then
            CallClass.PopulateDataAdapterAfterSearch("getAccInterCOInvoices", CmbComp.Text).Fill(dsMain, "tblSelect")

            If dgMPO.RowCount > 0 Then
                CmdExport.Enabled = True
                PutInfoSales()
            Else
                MsgBox("No data found after search")
            End If
        Else
            MsgBox("!!! ERROR !!! Selected company missing.")
        End If

    End Sub

    Sub PutInfoSales()

        Dim I As Integer = 0
        Dim J As Integer = 1
        Dim SwVal As Integer = 0

        For Each Row As DataGridViewRow In dgMPO.Rows

            Dim decimalLength As Integer
            
            Row.Cells("LACData").Value = String.Format("{0,2}", "I1")                                               'ID - A2

            decimalLength = KeepNo.ToString("D").Length + (9 - Len(CStr(KeepNo)))
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + KeepNo.ToString("D" + decimalLength.ToString())     'RNNO  
            KeepIdent = KeepNo.ToString("D" + decimalLength.ToString())

            I = I + 1
            'Dim dd As Integer = Len(CStr(I))

            decimalLength = I.ToString("D").Length + (8 - Len(CStr(I)))
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + I.ToString("D" + decimalLength.ToString())    'GRNR  - N8

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("PslipInterCoPrefix").Value         'DIVI  - A3
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,-10}", "FS1002")            'SUNO  - A10
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,-10}", "FS1002")            'SPYN  - A10

            'Dim SwPslip As Integer = Row.Cells("PslipNo").Value                                                    'SINO  - A24
            If Row.Cells("IVAM").Value > 0 Then
                'decimalLength = SwPslip.ToString("D").Length + (24 - (Len(Row.Cells("PslipNo").Value) + 7))
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + "INVOICE" + SwPslip.ToString("D" + decimalLength.ToString())
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + "INVOICE" + String.Format("{0,-17}", Row.Cells("PslipNo").Value)
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,-24}", Row.Cells("PslipNo").Value)
            Else
                'decimalLength = SwPslip.ToString("D").Length + (24 - (Len(Row.Cells("PslipNo").Value) + 10))
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + "CREDITMEMO" + SwPslip.ToString("D" + decimalLength.ToString())
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + "CREDITMEMO" + String.Format("{0,-14}", Row.Cells("PslipNo").Value)
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,-24}", Row.Cells("PslipNo").Value)
            End If

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("InvDate").Value                    'IVDT  - N8



            'INVOICE DUE DATE
            Dim mytext As String = Row.Cells("InvTerms").Value
            Dim NewNumber As String = ""
            ' Convert it to an array of characters  
            Dim myChars() As Char = mytext.ToCharArray()
            ' Loop through the array testing if each is a digit  
            For Each ch As Char In myChars
                If Char.IsDigit(ch) Then
                    NewNumber = NewNumber + ch
                    ' If it is a digit, show it in a messagebox  
                    ' (here is where you would save the number to array, variable or whatever)  
                    'MessageBox.Show(ch)
                End If
            Next

            Dim SwDate As Date
            Dim NewDate As Date
            Dim StrDate As String

            If Val(NewNumber) > 0 Then
                'SwDate = Date.Parse(Row.Cells("SwInvDate").Value)
                'NewDate = DateAdd(DateInterval.Day, Val(NewNumber), SwDate)

                If Val(NewNumber) = 30 Then
                    NewDate = (Now.AddDays((Now.Day - 1) * -1).AddMonths(2)).ToShortDateString
                Else
                    If Val(NewNumber) = 45 Then
                        NewDate = (Now.AddDays((Now.Day - 1) * -1).AddMonths(3)).ToShortDateString
                    Else
                        If Val(NewNumber) = 60 Then
                            NewDate = (Now.AddDays((Now.Day - 1) * -1).AddMonths(3)).ToShortDateString
                        Else
                            NewDate = (Now.AddDays((Now.Day - 1) * -1).AddMonths(2)).ToShortDateString
                        End If
                    End If
                End If

                NewDate = DateAdd(DateInterval.Day, 9, NewDate)

                If NewDate.DayOfWeek = DayOfWeek.Saturday Then
                    'NewDate = DateAdd(DateInterval.Day, Val(NewNumber) + 2, SwDate)
                    NewDate = DateAdd(DateInterval.Day, 2, NewDate)
                End If
                If NewDate.DayOfWeek = DayOfWeek.Sunday Then
                    'NewDate = DateAdd(DateInterval.Day, Val(NewNumber) + 1, SwDate)
                    NewDate = DateAdd(DateInterval.Day, 1, NewDate)
                End If

                StrDate = NewDate.ToString("yyyyMMdd")
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + StrDate

            Else
                'SwDate = Date.Parse(Row.Cells("SwInvDate").Value)
                'NewDate = DateAdd(DateInterval.Day, 30, SwDate)

                NewDate = (Now.AddDays((Now.Day - 1) * -1).AddMonths(2)).ToShortDateString
                NewDate = DateAdd(DateInterval.Day, 9, NewDate)

                If NewDate.DayOfWeek = DayOfWeek.Saturday Then
                    NewDate = DateAdd(DateInterval.Day, 30 + 2, SwDate)
                End If
                If NewDate.DayOfWeek = DayOfWeek.Sunday Then
                    NewDate = DateAdd(DateInterval.Day, 30 + 1, SwDate)
                End If

                StrDate = NewDate.ToString("yyyyMMdd")
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + StrDate
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("DelivDate").Value                  'DUDT  - N8
            End If


                SwVal = Row.Cells("IVAM").Value
                'decimalLength = SwVal.ToString("D").Length + (17 - Len(CStr(SwVal)))
                'Row.Cells("LACData").Value = Row.Cells("LACData").Value + SwVal.ToString("D" + decimalLength.ToString())    
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,17}", RTrim(Str(SwVal)))    'IVAM  - N17

                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,2}", "00")                  'VTCD  - A2
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,17}", "0")                  'VTAM  - N17
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("InvDevise").Value                  'CUCD  - A3
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,2}", "01")                  'CRTP  - A2


                Dim txtEx As Double = 0.0
                Dim txtEx2 As Double = 0.0
                Dim txtExInteger As Integer = 0

                Select Case Row.Cells("InvDevise").Value
                    Case "CAD"
                        Select Case CmbComp.Text
                            Case "BAI", "LIA", "BUK"                'CAD TO EUR
                                txtEx = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "EUR")
                            Case "MDK", "HSC", "LNA"                'CAD TO USD
                                txtEx = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "USD")
                        End Select

                        If txtEx > 0 Then
                            txtEx = (1 / txtEx) * 1000000
                            txtExInteger = Microsoft.VisualBasic.Int(txtEx)
                        End If
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,13}", txtExInteger)

                    Case "USD"
                        Select Case CmbComp.Text
                            Case "BAI", "LIA", "BUK"                ' USD to EUR
                                txtEx = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "USD")    'take USD to CDN
                                txtEx2 = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "EUR")   'take EUR to CDN

                                txtEx = (1 * txtEx) / txtEx2

                                If txtEx > 0 Then
                                    txtEx = (1 / txtEx) * 1000000
                                    txtExInteger = Microsoft.VisualBasic.Int(txtEx)
                                End If
                                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,13}", txtExInteger)

                            Case "MDK", "HSC", "LNA"                ' USD TO USD
                                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,13}", "1000000")
                        End Select

                    Case "EUR"

                        Select Case CmbComp.Text
                            Case "BAI", "LIA", "BUK"                'EUR TO EUR
                                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,13}", "1000000")
                            Case "MDK", "HSC", "LNA"                'EUR TO USD
                                txtEx = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "USD")    'take USD to CDN
                                txtEx2 = CallClass.ReturnStrWith2ParStr("cspReturnExchangeRate", Row.Cells("ParInv").Value, "EUR")   'take EUR to CDN

                                If txtEx > 0 Then
                                    txtEx = (txtEx2 / txtEx) * 1000000
                                    txtExInteger = Microsoft.VisualBasic.Int(txtEx)
                                End If
                                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,13}", txtExInteger)
                        End Select
                End Select

            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("ACDT").Value                       'ACDT  - N8

            Dim AccNewDate As Date
            Dim AccStrDate As String

            AccNewDate = txtAccDate.Text
            AccStrDate = AccNewDate.ToString("yyyyMMdd")
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + AccStrDate                                       'ACDT  - N8

                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,10}", "")                   'APCD  - A10
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,17}", "0")                  'CDAM  - N17
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,6}", "0")                   'CDP1  - N6
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,8}", "0")                   'CDT1  - N8
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,6}", "0")                   'CDP2  - N6
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,8}", "0")                   'CDT2  - N8
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,6}", "0")                   'CDP3  - N6
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,8}", "0")                   'CDT3  - N8
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + String.Format("{0,-7}", Row.Cells("PslipCustPoContr").Value)      'PUNO  - A7


        Next

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click

        InitialComponents()
        CmdSearch.Enabled = False

        KeepNo = 0
        txtCOBatch.Text = ""

    End Sub

    Sub FindCOBatch()

        KeepNo = 0
        txtCOBatch.Text = ""

        txtCOBatch.Text = CallClass.GenerateNextLot("cspGetNextLot", CmbComp.Text)
        If txtCOBatch.Text = "ERROR" Then
            CmdSearch.Enabled = False
            CmdExport.Enabled = False
            Exit Sub
        Else
            CmdSearch.Enabled = True
            KeepNo = Val(txtCOBatch.Text)
            txtCOBatch.Text = Trim(txtCOBatch.Text)
        End If

    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click

        CmdFTP.Enabled = False

        FileNameStr = ""
        FileNameStr = "LAC" + CmbComp.Text + "_" + KeepIdent + ".txt"

        Dim TextFile As New IO.StreamWriter("C:\InterCoInvoices\" + "LAC" + CmbComp.Text + "_" + KeepIdent + ".txt")

        For Each Row As DataGridViewRow In dgMPO.Rows
            TextFile.WriteLine(Row.Cells("LACData").Value)
        Next

        TextFile.Close()

        CmdExport.Enabled = False

        CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", CmbComp.Text, KeepNo)

        CallClass.ExecuteUpdateSearchStr("cspUpdateAccInterCOInvoice", CmbComp.Text)


        MsgBox("Export successfully.")
        dsMain.Clear()

        KeepNo = 0
        txtCOBatch.Text = ""

        CmdFTP.Enabled = False


    End Sub

    Private Sub CmbComp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbComp.SelectedIndexChanged
        CmdSearch.Enabled = False
        CmdExport.Enabled = False
        InitialComponents()
        FindCOBatch()
        Me.Refresh()
    End Sub

    Private Sub CmdFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFTP.Click

        FileNameStr = "LACLNA_000000028.txt"

        If Len(Trim(FileNameStr)) > 0 Then

            'CallClass.FtpUploadFileToServer("172.20.32.191", "C:\InterCoInvoices\" + FileNameStr, "/M3BE/env/P100/Mvxfiletransfert/TOPROCESS", , "INTLAC", "LACINTER", , )

            Dim credential As New Net.NetworkCredential("dor-ftp", "2000Dorval")
            Call Upload("C:\InterCoInvoices\" + FileNameStr, "ftp://192.168.115.6" + "/Folder1/" + FileNameStr, credential)

            'Dim credential As New Net.NetworkCredential("INTLAC", "LACINTER")
            'Call Upload("C:\InterCoInvoices\" + FileNameStr, "ftp://172.20.32.191" + "/M3BE/env/P100/Mvxfiletransfert/TOPROCESS/" + FileNameStr, credential)

            MsgBox("FTP upload successfully done.")
        Else
            MsgBox("Nothing to upload to FTP.")
        End If

        FileNameStr = ""
        CmdFTP.Enabled = False

    End Sub

    Private Sub Upload(ByVal source As String, ByVal target As String, ByVal credential As Net.NetworkCredential)

        Dim request As Net.FtpWebRequest = DirectCast(Net.WebRequest.Create(target), Net.FtpWebRequest)

        request.Method = Net.WebRequestMethods.Ftp.UploadFile
        request.Credentials = credential
        request.Proxy = Nothing
        request.KeepAlive = False
        request.UsePassive = False

        Dim reader As New FileStream(source, FileMode.Open)
        Dim buffer(Convert.ToInt32(reader.Length - 1)) As Byte
        Dim objRequestStream As Stream = Nothing
        reader.Read(buffer, 0, buffer.Length)
        reader.Close()
        request.ContentLength = buffer.Length

        objRequestStream = request.GetRequestStream
        objRequestStream.Write(buffer, 0, buffer.Length)
        objRequestStream.Close()

        Dim response As Net.FtpWebResponse = DirectCast(request.GetResponse, Net.FtpWebResponse)
        MessageBox.Show(response.StatusDescription, "File Uploaded")
        response.Close()


        '          Imports System.IO
        '        Imports System.Net
        '        Imports System.Text

        '        Dim localFile As String = "C:\Yserver.txt"
        '        Dim remoteFile As String = "ftp://ftpSERVER/test12345.txt"
        '        Dim username As String = "user"
        '        Dim password As String = "pwd"

        '        Dim sourceStream As New StreamReader(localFile)
        '        Dim fileContents As Byte() = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd())
        '        sourceStream.Close()

        '        'Get the object used to communicate with the server.
        '        Dim Request As System.Net.FtpWebRequest = FtpWebRequest.Create(remoteFile)

        '        ' Setting Properties
        '        Request.Credentials = New Net.NetworkCredential(username, password)
        '        Request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        '        Request.Proxy = Nothing
        '        Request.KeepAlive = False

        '        ' Uploading file
        '        Request.GetRequestStream.Write(fileContents, 0, fileContents.Length)
        '        MsgBox("File Uploaded Successfully !!!")

        'When I execute these, I am getting following error 

        'System.Net.WebException was caught
        '        Message = "The remote server returned an error: (501) Syntax error in parameters or arguments."


        '============================

        'Dim ftp As New Chilkat.Ftp2()

        'Dim success As Boolean

        ''  Any string unlocks the component for the 1st 30-days.
        'success = ftp.UnlockComponent("Anything for 30-day trial")
        'If (success <> True) Then
        '    MsgBox(ftp.LastErrorText)
        '    Exit Sub
        'End If


        'ftp.Hostname = "ftp.chilkatsoft.com"
        'ftp.Username = "****"
        'ftp.Password = "****"

        ''  The default data transfer mode is "Active" as opposed to "Passive".

        ''  Connect and login to the FTP server.
        'success = ftp.Connect()
        'If (success <> True) Then
        '    MsgBox(ftp.LastErrorText)
        '    Exit Sub
        'End If


        ''  Change to the remote directory where the file will be uploaded.
        'success = ftp.ChangeRemoteDir("junk")
        'If (success <> True) Then
        '    MsgBox(ftp.LastErrorText)
        '    Exit Sub
        'End If


        ''  Upload a file.
        'Dim localFilename As String
        'localFilename = "hamlet.xml"
        'Dim remoteFilename As String
        'remoteFilename = "hamlet.xml"

        'success = ftp.PutFile(localFilename, remoteFilename)
        'If (success <> True) Then
        '    MsgBox(ftp.LastErrorText)
        '    Exit Sub
        'End If


        'ftp.Disconnect()

        'MsgBox("File Uploaded!")



    End Sub

    'Public Function FtpUploadFileToServer(ByVal pServer As String, _
    '                      ByVal pUploadPathAndFileName As String, _
    '                      Optional ByVal pTargetPath As String = "", _
    '                      Optional ByVal pTargetFileName As String = "", _
    '                      Optional ByVal pUserName As String = "", _
    '                      Optional ByVal pPassword As String = "", _
    '                      Optional ByVal pPort As Integer = 21, _
    '                      Optional ByVal pUsePassive As Boolean = False)
    '    Dim objUploadStream As FileStream = Nothing
    '    Dim objRequest As Net.FtpWebRequest = Nothing
    '    Dim objResponse As Net.FtpWebResponse = Nothing
    '    Dim objRequestStream As Stream = Nothing
    '    Try
    '        objUploadStream = File.OpenRead(pUploadPathAndFileName)
    '        Dim bytBuffer(CType(objUploadStream.Length, Integer)) As Byte
    '        objUploadStream.Read(bytBuffer, 0, bytBuffer.Length)

    '        If pTargetFileName.Length = 0 Then
    '            pTargetFileName = IO.Path.GetFileName(objUploadStream.Name)
    '        End If
    '        Dim strUrl As String = String.Format("ftp://{0}:{1}/{2}/{3}", pServer, pPort, pTargetPath, pTargetFileName)
    '        objRequest = CType(Net.FtpWebRequest.Create(strUrl), Net.FtpWebRequest)
    '        If pUserName.Length > 0 And pPassword.Length > 0 Then
    '            objRequest.Credentials = New Net.NetworkCredential(pUserName, pPassword)
    '        End If
    '        objRequest.Method = Net.WebRequestMethods.Ftp.UploadFile
    '        objRequest.Proxy = Nothing
    '        objRequest.KeepAlive = False
    '        objRequest.UsePassive = pUsePassive

    '        objRequestStream = objRequest.GetRequestStream()
    '        objRequestStream.Write(bytBuffer, 0, bytBuffer.Length)
    '        objRequestStream.Close()

    '        objResponse = CType(objRequest.GetResponse, Net.FtpWebResponse)
    '        MsgBox(objResponse.StatusDescription)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        Try
    '            If Not objRequestStream Is Nothing Then
    '                objRequestStream.Close()
    '            End If
    '            If Not objUploadStream Is Nothing Then
    '                objUploadStream.Close()
    '                objUploadStream.Dispose()
    '            End If
    '            If Not objRequest Is Nothing Then
    '                objRequest = Nothing
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Try

    '    Return True

    'End Function

End Class