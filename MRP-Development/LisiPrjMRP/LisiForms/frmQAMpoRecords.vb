Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports Microsoft.Office.Interop

Public Class frmQAMpoRecords

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet
    Private daScan As New SqlDataAdapter

    Dim ScanCurrency As CurrencyManager

    Dim SwPath As String = ""
    Dim SwUser As String = ""

    Dim reply As DialogResult

    Private Sub frmQAMpoRecords_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'ScanCurrency.EndCurrentEdit()

        dsMain.RejectChanges()
        dsMain.Dispose()
        daScan.Dispose()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Timer1.Stop()

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmQAMpoRecords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Start()

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()

        Dim getInfo As String = ""
        getInfo = CallClass.ReturnStrWithParInt("cspReturnMpoParent", frmShopFloorControl.txtMPOId.Text)

        If getInfo = "False" Then
            MsgBox(" Nothing to View.")
            Exit Sub
        End If

        If CInt(getInfo) <= 4600 Then
            Dim KeepMpo As String = txtMpo.Text

            Me.Dispose()
            OpenFileDialog1.Reset()

            Dim Swpath As String = "\\Srv115fs01\lisi mpo quality records\Test Certificate (1-4600)"

            With OpenFileDialog1
                .InitialDirectory = Swpath
                .FileName = "CT-" + KeepMpo + "*.*"
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
        Else

            OpenFileDialog1.Reset()
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\1) Test Certs"
            Dim fullAppPath As String = System.IO.Path.GetFullPath(SwPath)
            If System.IO.Directory.Exists(SwPath) = False Then
                CreateMPOFolder()
            End If
            

            BuildSqlCommand()
            InitialComponents()

            txtMpo.Focus()

            Dim strSearch As String
            strSearch = txtMpo.Text

            dsMain.Clear()

            CallClass.PopulateDataAdapterAfterSearch("gettblMpoScanRecordsByMPONo", strSearch).Fill(dsMain, "tblMPOScanRecords")

            BindComponents()

            CheckRole()

            If RoleScanFull(wkDeptCode) = True Then
                CheckNewRecord()
            End If

            CheckViewRecord()

        End If

    End Sub

    Sub CheckRole()

        If RoleScanFull(wkDeptCode) = True Then
            ShowScanFull()
        Else
            ViewOnly()
        End If

    End Sub

    Function RoleScanFull(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "SCANFULL" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Function RoleTestCerts(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "TESTCERTS" Then
                flg = True
                Exit For
            End If
        Next

        If flg = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub ViewOnly()

        CmdScan1.Enabled = False
        CmdScan2a.Enabled = False

        CmdScan3a.Enabled = False

        CmdScan4.Enabled = False
        CmdScan5.Enabled = False
        CmdScan6a.Enabled = False
        CmdScan7.Enabled = False
        CmdScan8.Enabled = False
        CmdScan9.Enabled = False
        CmdScan10.Enabled = False

    End Sub

    Sub ShowScanFull()

        CmdScan1.Enabled = True
        CmdScan2a.Enabled = True

        CmdScan3a.Enabled = True

        CmdScan4.Enabled = True
        CmdScan5.Enabled = True
        CmdScan6a.Enabled = True
        CmdScan7.Enabled = True
        CmdScan8.Enabled = True
        CmdScan9.Enabled = True
        CmdScan10.Enabled = True

    End Sub

    Sub CheckViewRecord()

        Dim pattern As String = "*.PDF"
        If pattern.IndexOf("(") >= 0 Then
            pattern = pattern.Substring(0, pattern.IndexOf("("))
        End If

        lstFiles.Items.Clear()
        Dim dir_info1 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\1) Test Certs")

        ListFiles(lstFiles, pattern, dir_info1)

        If RoleTestCerts(wkDeptCode) = True Then
            If lstFiles.Items.Count > 0 Then
                CmdView1.BackColor = Color.Green
                CmdView1.Enabled = True
            Else
                CmdView1.BackColor = Color.LightGray
                CmdView1.Enabled = False
            End If
        Else
            CmdView1.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info2a As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\2) Heat treatment Records")
        ListFiles(lstFiles, pattern, dir_info2a)

        If lstFiles.Items.Count > 0 Then
            CmdView2a.BackColor = Color.Green
            CmdView2a.Enabled = True
        Else
            CmdView2a.BackColor = Color.LightGray
            CmdView2a.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info3a As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\3) Forging Records")
        ListFiles(lstFiles, pattern, dir_info3a)

        If lstFiles.Items.Count > 0 Then
            CmdView3a.BackColor = Color.Green
            CmdView3a.Enabled = True
        Else
            CmdView3a.BackColor = Color.LightGray
            CmdView3a.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info4 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\4) Thread rolling Records")
        ListFiles(lstFiles, pattern, dir_info4)

        If lstFiles.Items.Count > 0 Then
            CmdView4.BackColor = Color.Green
            CmdView4.Enabled = True
        Else
            CmdView4.BackColor = Color.LightGray
            CmdView4.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info5 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\5) Cold working Records")
        ListFiles(lstFiles, pattern, dir_info5)

        If lstFiles.Items.Count > 0 Then
            CmdView5.BackColor = Color.Green
            CmdView5.Enabled = True
        Else
            CmdView5.BackColor = Color.LightGray
            CmdView5.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info6a As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\6) Surface finishing")
        ListFiles(lstFiles, pattern, dir_info6a)

        If lstFiles.Items.Count > 0 Then
            CmdView6a.BackColor = Color.Green
            CmdView6a.Enabled = True
        Else
            CmdView6a.BackColor = Color.LightGray
            CmdView6a.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info7 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\7) Final Inspections")
        ListFiles(lstFiles, pattern, dir_info4)

        If lstFiles.Items.Count > 0 Then
            CmdView7.BackColor = Color.Green
            CmdView7.Enabled = True
        Else
            CmdView7.BackColor = Color.LightGray
            CmdView7.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info8 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\8) Metallurgical Testing")
        ListFiles(lstFiles, pattern, dir_info8)

        If lstFiles.Items.Count > 0 Then
            CmdView8.BackColor = Color.Green
            CmdView8.Enabled = True
        Else
            CmdView8.BackColor = Color.LightGray
            CmdView8.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info9 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\9) Mechanical Testing")
        ListFiles(lstFiles, pattern, dir_info9)

        If lstFiles.Items.Count > 0 Then
            CmdView9.BackColor = Color.Green
            CmdView9.Enabled = True
        Else
            CmdView9.BackColor = Color.LightGray
            CmdView9.Enabled = False
        End If

        lstFiles.Items.Clear()
        Dim dir_info10 As New IO.DirectoryInfo("\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\10) Others")
        ListFiles(lstFiles, pattern, dir_info10)

        If lstFiles.Items.Count > 0 Then
            CmdView10.BackColor = Color.Green
            CmdView10.Enabled = True
        Else
            CmdView10.BackColor = Color.LightGray
            CmdView10.Enabled = False
        End If

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

    Private Function BuildSqlCommand() As Boolean

        Try
            daScan = CallClass.PopulateDataAdapter("gettblMpoScanRecords")
            Dim ScanBuilder As New SqlClient.SqlCommandBuilder(daScan)

            daScan.UpdateCommand = ScanBuilder.GetUpdateCommand
            daScan.UpdateCommand.Connection = cn
            daScan.InsertCommand = ScanBuilder.GetInsertCommand
            AddHandler daScan.RowUpdated, AddressOf HandleRowUpdatedScan
            daScan.InsertCommand.Connection = cn
            daScan.DeleteCommand = ScanBuilder.GetDeleteCommand
            daScan.DeleteCommand.Connection = cn
            daScan.AcceptChangesDuringFill = True
            daScan.TableMappings.Add("Table", "tblMPOScanRecords")
            daScan.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedScan(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMPOScanRecords").Columns("MpoScanID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()


        daScan.FillSchema(dsMain, SchemaType.Source, "tblMPOScanRecords")
        daScan.Fill(dsMain, "tblMPOScanRecords")

        Dim ScanID As DataColumn = dsMain.Tables("tblMPOScanRecords").Columns("MpoScanID")
        ScanID.AutoIncrement = True
        ScanID.AutoIncrementStep = -1
        ScanID.AutoIncrementSeed = -1
        ScanID.ReadOnly = False

        dsMain.EnforceConstraints = False

        ScanCurrency = CType(BindingContext(dsMain, "tblMPOScanRecords"), CurrencyManager)

    End Sub

    Sub BindComponents()

        txtUser1.DataBindings.Clear()
        txtUser2a.DataBindings.Clear()

        txtUser3a.DataBindings.Clear()

        txtUser4.DataBindings.Clear()
        txtUser5.DataBindings.Clear()
        txtUser6a.DataBindings.Clear()
        txtUser7.DataBindings.Clear()
        txtUser8.DataBindings.Clear()
        txtUser9.DataBindings.Clear()
        txtUser10.DataBindings.Clear()

        txtUser1.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes1")
        txtUser2a.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes2a")

        txtUser3a.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes3a")

        txtUser4.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes4")
        txtUser5.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes5")
        txtUser6a.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes6a")
        txtUser7.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes7")
        txtUser8.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes8")
        txtUser9.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes9")
        txtUser10.DataBindings.Add("Text", dsMain, "tblMPOScanRecords.Notes10")

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txtClock.Text = Now.ToLongTimeString
    End Sub

    Sub CreateMPOFolder()

        '================================================

        Dim SwMpo As String = "MPO-" + Trim(txtMpo.Text)

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
       

        path_1 = path + "\5) Cold working Records"
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
    Private Sub CmdScan1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan1.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\1) Test Certs"
            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo1", SwUser) = "False" Then
                txtUser1.Text = txtUser1.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan2a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan2a.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\2) Heat treatment Records"
            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo2a", SwUser) = "False" Then
                txtUser2a.Text = txtUser2a.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub


    Private Sub CmdScan3a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan3a.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\3) Forging Records"
            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo3a", SwUser) = "False" Then
                txtUser3a.Text = txtUser3a.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan4.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\4) Thread rolling Records"
            Try
                'Process.Start("""" + SwPath + """")
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo4", SwUser) = "False" Then
                txtUser4.Text = txtUser4.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If
    End Sub

    Private Sub CmdScan5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan5.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\5) Cold working Records"
            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo5", SwUser) = "False" Then
                txtUser5.Text = txtUser5.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan6a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan6a.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\6) Surface finishing"

            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo6a", SwUser) = "False" Then
                txtUser6a.Text = txtUser6a.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan7.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\7) Final Inspections"

            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo7", SwUser) = "False" Then
                txtUser7.Text = txtUser7.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan8.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\8) Metallurgical Testing"

            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo8", SwUser) = "False" Then
                txtUser8.Text = txtUser8.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan9.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\9) Mechanical Testing"

            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo9", SwUser) = "False" Then
                txtUser9.Text = txtUser9.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Private Sub CmdScan10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdScan10.Click

        reply = MsgBox("Continue?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.Yes Then
            SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\10) Others"

            Try
                Process.Start(SwPath)
            Catch ex As Exception
                MsgBox("ERROR - " & ex.Message)
                Exit Sub
            End Try

            SwUser = "(" + wkName + " -- " + Now.ToShortDateString + ") "

            If CallClass.ReturnInfoWithParString("cspReturnCheckExistingScanInfo10", SwUser) = "False" Then
                txtUser10.Text = txtUser10.Text + SwUser
                UpdateData()
            End If

            CheckViewRecord()

        End If

    End Sub

    Sub UpdateData()

        If RoleScanFull(wkDeptCode) = True Then
            Me.Focus()
            Me.Refresh()

            ScanCurrency.EndCurrentEdit()

            txtMpo.Focus()
            txtUser1.Focus()
            txtMpoStatus.Focus()
            txtUser2a.Focus()
            txtMpo.Focus()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daScan.Update(dsMain.Tables("tblMPOScanRecords").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    dsMain.AcceptChanges()

                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            BindComponents()

            CheckViewRecord()

        End If

    End Sub

    Sub CheckNewRecord()

        Dim swCode As Integer = 0
        swCode = CallClass.ReturnStrWithParString("cspReturnMpoScanID", frmShopFloorControl.txtMPOId.Text)
        If swCode = 0 Then

            Dim cmdInsertMpoID As SqlCommand = New SqlCommand("cspUpdateAddScanMpoID", cn)
            cmdInsertMpoID.CommandType = CommandType.StoredProcedure

            Dim parMpoID As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
            parMpoID.Value = frmShopFloorControl.txtMPOId.Text
            cmdInsertMpoID.Parameters.Add(parMpoID)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                cmdInsertMpoID.ExecuteNonQuery()
                cmdInsertMpoID.Dispose()
            Catch ex As SqlException
                MsgBox("Add MpoID on Scan Table: " & ex.Message)
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End If

    End Sub

    Private Sub RdYes1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes2a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes2b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes3a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes3b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes6a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes6b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes6c_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes7_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes8_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes9_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdYes10_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo2a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo2b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo3a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo3b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo6a_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo6b_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo6c_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo7_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo8_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo9_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub RdNo10_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateData()
    End Sub

    Private Sub CmdView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView1.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\1) Test Certs"
        Try
            Process.Start(SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        Me.Refresh()
        CheckViewRecord()
    End Sub

    Private Sub CmdView2a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView2a.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\2) Heat treatment Records"
        Try
            Process.Start(SwPath)

            'Dim MyPrintJob As New PrintJob("HP Color LaserJet CM2320", "DocumentA.pdf")
            'MyPrintJob.print()


        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView3a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView3a.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\3) Forging Records"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub


    Private Sub CmdView4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView4.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\4) Thread rolling Records"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub CmdView5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView5.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\5) Cold working Records"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView6a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView6a.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\6) Surface finishing"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView7.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\7) Final Inspections"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView8.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\8) Metallurgical Testing"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView9.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\9) Mechanical Testing"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

    Private Sub CmdView10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView10.Click
        SwPath = "\\Srv115fs01\lisi mpo quality records\MPO-" + Trim(txtMpo.Text) + "\10) Others"
        Try
            Process.Start("explorer.exe", SwPath)
        Catch ex As Exception
            MsgBox("ERROR - " & ex.Message)
            Exit Sub
        End Try

        CheckViewRecord()
    End Sub

End Class