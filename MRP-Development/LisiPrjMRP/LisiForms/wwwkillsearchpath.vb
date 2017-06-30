Option Strict Off
Option Explicit On

'Imports ADODB
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic


Imports System.Net
Imports System.Net.Mail




Public Class wwwkillsearchpath
    Inherits System.Windows.Forms.Form

    Private dsMain As New DataSet
    Dim CallClass As New clsCommon

    Private Sub wwwkillsearchpath_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        dsMain.Clear()
        CallClass.PopulateDataAdapter("gettblPartMaster").Fill(dsMain, "tblPartMaster")

        CmbPartNumber.DataSource = dsMain.Tables("tblPartMaster")
        CmbPartNumber.DisplayMember = "PartNumber"
        CmbPartNumber.ValueMember = "PartID"

        txtTarget.Text = "\\Srv115fs01\Engineering"

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

        Dim pattern As String = "*3483C*.pdf"
        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        Dim dir_info As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\Test Certificate (1-4600)")

        ListFiles(lstFiles, pattern, dir_info)
        Dim swc As Integer = lstFiles.Items.Count

    End Sub


    Private Sub ListFiles(ByVal lst As ListBox, ByVal pattern As String, ByVal dir_info As IO.DirectoryInfo)
        ' Get the files in this directory.
        Dim fs_infos() As IO.FileInfo = dir_info.GetFiles(pattern)
        For Each fs_info As IO.FileInfo In fs_infos
            lstFiles.Items.Add(fs_info.FullName)
        Next fs_info
        fs_infos = Nothing

        ' Search subdirectories.
        Dim subdirs() As IO.DirectoryInfo = dir_info.GetDirectories()
        For Each subdir As IO.DirectoryInfo In subdirs
            ListFiles(lst, pattern, subdir)
        Next subdir
    End Sub

    Private Sub CmdPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPath.Click

        Dim SwMpo As String = "MPO-4094"

        Dim path As String = ""
        Dim path_1 As String = ""

        path = "\\Srv115fs01\Lisi MPO Quality Records\" + SwMpo
        Dim di As DirectoryInfo = Directory.CreateDirectory(path)

        path_1 = path + "\1) Test Certs"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\2) Heat treatment Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\3) Forging Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\4) Thread rolling Records"
        di = Directory.CreateDirectory(path_1)
        path_1 = path + "\4) Thread rolling Records\Technique sheet + First off"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\5) Cold working Records"
        di = Directory.CreateDirectory(path_1)
        path_1 = path + "\5) Cold working Records\Technique sheet + First off"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\6) Surface finishing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\7) Final Inspections"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\8) Metallurgical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\9) Mechanical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\10) Others"
        di = Directory.CreateDirectory(path_1)

    End Sub

    Private Sub lstFiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFiles.DoubleClick

        Dim SwPath As String = ""

        Dim SwIndex As String = ""


        If lstFiles.Items.Count > 0 Then

            SwIndex = lstFiles.Text

            If IsDBNull(SwIndex) = False And IsNothing(SwIndex) = False And Len(Trim(SwIndex)) <> 0 Then

                ' Create an instance
                Dim proc As New System.Diagnostics.Process()

                ' Fill-up StartInfo
                proc.StartInfo.UseShellExecute = True
                proc.StartInfo.FileName = SwIndex

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                ' Start the process
                ' System.Drawing.Printing.PrintDocument = False
                Try
                    proc.Start()
                Catch
                End Try

                While Not proc.HasExited
                    ' Wait until the process exit
                End While
            End If

            Exit Sub

        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim txtMpo As String = "3483C"
        'If Len(Trim(txtMpo)) = 0 Then
        '    MsgBox("Nothing to View.")
        '    Exit Sub
        'End If

        OpenFileDialog1.Reset()

        Dim Swpath As String = "\\Srv115fs01\lisi mpo quality records\Test Certificate (1-4600)"

        With OpenFileDialog1
            .InitialDirectory = Swpath
            .FileName = "CT-" + txtMpo + "*.pdf"
            .Filter = "All Documents|*.*"
            .FilterIndex = 2
            .RestoreDirectory = True
        End With

        Dim fullAppPath As String = System.IO.Path.GetFullPath(Swpath)

        If System.IO.Directory.Exists(Swpath) = True Then
            OpenFileDialog1.ShowDialog()
            Try
                Process.Start(OpenFileDialog1.FileName)
            Catch
            End Try
        Else
            MsgBox("Nothing to View.")
            Exit Sub
        End If
    End Sub


    Private Sub CmdEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEmail.Click

        Dim email As New Mail.MailMessage()

        email.From = New Net.Mail.MailAddress("stefan.tudor@lisi-aerospace.com")
        email.Subject = "Test"
        email.Body = "This is the body of the email"

        Dim smtpServer, smtpPort As String
        'smtpServer = "mail.bsfinc.ca"
        'smtpServer = "172.20.32.146"           'not good

        smtpServer = "172.20.33.72"            'dominique address
        smtpPort = 25

        Dim client As New Mail.SmtpClient(smtpServer, smtpPort)
        email.To.Add(New Mail.MailAddress("studor@bsfinc.ca"))
        client.Send(email)
        email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
        client.Send(email)
        email.To.Add(New Mail.MailAddress("dominique.bourrier@lisi-aerospace.com"))
        client.Send(email)

        'Dim mail As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        'mail.From = New Mail.MailAddress("stefan.tudor@lisi-aerospace.com")
        'mail.To.Add(New Mail.MailAddress("studor@bsfinc.ca"))

        'mail.Subject = "Subject"
        'mail.Body = "Body"

        'Dim mySmtpClient As New SmtpClient("mail.bsfinc.ca")
        'mySmtpClient.Port = 25
        ''mySmtpClient.Credentials = New NetworkCredential("Your.Account@gmail.com", " YourPassword")
        ''mySmtpClient.EnableSsl = True
        'mySmtpClient.Send(mail)


        ''My(Code)
        ''*******
        'Dim mail As New MailMessage()

        'mail.From = New MailAddress("stefan.tudor@lisi-aerospace.com")
        'mail.To.Add("studor@bsfinc.ca")
        'mail.Subject = "Test MS..."
        'mail.Body = "Body"

        'Dim smtp As New SmtpClient("172.20.32.146")
        'smtp.Send(mail)



       
    End Sub


End Class