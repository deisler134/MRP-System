Option Strict Off
Option Explicit On

'Imports ADODB
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmQAImportWordDoc

    ' Dim msWord As Microsoft.Office.Interop.Word.Application

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim daCode As SqlDataAdapter
    Dim daTitle As SqlDataAdapter
    Dim dsMain As DataSet

    Dim SwVal As Boolean

    Dim objfs As Object
    Dim sfolder As String
    Dim mFile As String

    Sub InitScreen()
        'CmbNode.SelectedIndex = -1
        lblFileName.Text = ""
        lblFilePath.Text = ""
        txtShow.Text = ""

        RdRead.Checked = False
        RdMod.Checked = True

        ChkTitle.Checked = False
        ChkKey.Checked = False
        txtSrc.Text = ""

    End Sub

    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click

        InitScreen()

        With OpenFileDialog1
            .InitialDirectory = "\\Srv115fs01\Lisi QMS Documentation"
            .Filter = "All Documents|*.*"
            .FilterIndex = 2
        End With

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim ArrName As String
            ArrName = OpenFileDialog1.FileName
            Dim I As Integer = 0
            Dim KeepPos As Integer = 0
            For I = 0 To Len(ArrName) - 1
                If ArrName(I) = CChar("\") Then
                    KeepPos = I
                End If
            Next

            lblFilePath.Text = OpenFileDialog1.FileName
            lblFileName.Text = Mid(ArrName, KeepPos + 2)

        End If

        CmdSave.Enabled = True
        CmdRemove.Enabled = True
        CmdBrowse.Enabled = True

    End Sub

    Private Sub frmQAImportWordDoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        cn.Close()
        Me.Dispose()
        GC.Collect()

    End Sub

    Private Sub frmQAImportWordDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        PutClasification()

        LoadTree()

        TrView.CollapseAll()

        CmdSave.Enabled = True
        CmdRemove.Enabled = True

        InitScreen()

    End Sub

    Sub LoadTree()
        'establish the minimun and maximun values for our progress bar
        Pb1.Minimum = 0
        Pb1.Maximum = 3000
        'whe hide it so when the user click the button it appears, load the value aand the
        'then hide again...just to give a nice looking...
        Pb1.Visible = False

        TrView.Nodes.Clear()

        cn.Open()

        'get the data..
        daCode = New SqlDataAdapter("select distinct FormNode from tblLisiFormControl ORDER by FormNode", cn)
        'initialize the data set
        dsMain = New Data.DataSet()

        daCode.Fill(dsMain, "tblNode") 'l

        Dim I%, j%, Code$, Title$

        'lets count all the rows we got in order to add them to the control
        'one by one...
        For I = 0 To dsMain.Tables("tblNode").Rows.Count - 1

            Code$ = dsMain.Tables("tblNode").Rows(I).Item("FormNode").ToString

            'we add the items one by one...
            TrView.Nodes.Add(Code)
            TrView.Nodes(I).ImageIndex = 0
            'now that we are in xx position...lets say the 3rd position(remember that the tables in the dataset
            'begin with position 0)we get all the records from the Cargo table that belong to the categoria field
            'so we add them as childs to the respective parent node in the control...

            daTitle = New SqlDataAdapter("select FormTitle from tblLisiFormControl where FormNode='" & Code & "'", cn)
            daTitle.Fill(dsMain, "tblTitle") 'l
            'clear the erronuos data
            dsMain.Tables("tblTitle").Clear()
            'fill again the data with the new query
            daTitle.Fill(dsMain, "tblTitle") 'l

            For j = 0 To dsMain.Tables("tblTitle").Rows.Count - 1
                'once we have the records we fill the respective child node in the control

                Title$ = dsMain.Tables("tblTitle").Rows(j).Item("FormTitle").ToString
                Dim CodeTitle As TreeNode
                CodeTitle = TrView.Nodes(I)

                CodeTitle.Nodes.Add(Title)
                'asigne a image

                'then we expand the nodes so we can show the child nodes
                CodeTitle.Expand()

            Next

            'now ge go to the next row in the categoria table..
        Next

        'after fill the control..lets fill the progress bar just to advice the
        'user that the data is loading...
        Pb1.Visible = True
        For I = 0 To 3000
            Pb1.Value = I
        Next
        Pb1.Visible = False
        cn.Close()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        ValInfo()

        If SwVal = True Then

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateQaForms", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraSrc As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 1000)
            paraSrc.Value = lblFileName.Text
            mySqlComm.Parameters.Add(paraSrc)

            Dim paratitle As SqlParameter = New SqlParameter("@FormTitle", SqlDbType.NVarChar, 1000)
            paratitle.Value = lblFileName.Text
            mySqlComm.Parameters.Add(paratitle)

            Dim paraNode As SqlParameter = New SqlParameter("@FormNode", SqlDbType.NVarChar, 100)
            paraNode.Value = CmbNode.Text
            mySqlComm.Parameters.Add(paraNode)

            Dim paraPath As SqlParameter = New SqlParameter("@FormPath", SqlDbType.NVarChar, 2000)
            paraPath.Value = lblFilePath.Text
            mySqlComm.Parameters.Add(paraPath)

            Dim paraText As SqlParameter = New SqlParameter("@FormText", SqlDbType.NVarChar, 500)
            paraText.Value = txtShow.Text
            mySqlComm.Parameters.Add(paraText)

            Dim paraRead As SqlParameter = New SqlParameter("@FormRead", SqlDbType.NVarChar, 1)
            If RdRead.Checked = True Then
                paraRead.Value = "1"
            Else
                paraRead.Value = "0"
            End If
            mySqlComm.Parameters.Add(paraRead)

            Dim paraMod As SqlParameter = New SqlParameter("@FormMod", SqlDbType.NVarChar, 1)
            If RdMod.Checked = True Then
                paraMod.Value = "1"
            Else
                paraMod.Value = "0"
            End If
            mySqlComm.Parameters.Add(paraMod)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("ERROR  -  Update Quality Documentation Module." & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

        CmdSave.Enabled = True
        CmdBrowse.Enabled = True

        LoadTree()

    End Sub

    Sub ValInfo()

        If IsDBNull(CmbNode.Text) = True Or Len(Trim(CmbNode.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Clasification Description is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(lblFileName.Text) = True Or Len(Trim(lblFileName.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Document Name is Empty.")
            SwVal = False
            Exit Sub
        End If

        If IsDBNull(lblFilePath.Text) = True Or Len(Trim(lblFilePath.Text)) = 0 = True Then
            MsgBox("!!! ERROR !!! Document Path is Empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub TrView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TrView.AfterSelect

        Dim oString As String
        Dim oTempNode As TreeNode = TrView.SelectedNode

        oString = Me.TrView.SelectedNode.FullPath

        Dim ArrName As String
        ArrName = oString
        Dim I As Integer = 0
        Dim KeepPos As Integer = 0
        For I = 0 To Len(ArrName) - 1
            If ArrName(I) = CChar("\") Then
                KeepPos = I
            End If
        Next

        CmbNode.Text = ""
        lblFileName.Text = ""
        lblFilePath.Text = ""

        If KeepPos <> 0 Then
            CmbNode.Text = Trim(Mid(ArrName, 1, KeepPos))
            lblFileName.Text = Trim(Mid(ArrName, KeepPos + 2))
        Else
            CmbNode.Text = Trim(ArrName)
        End If

        lblFilePath.Text = CallClass.ReturnInfoWithParString("cspReturnFormPath", lblFileName.Text)
        If lblFilePath.Text = "False" Then
            lblFilePath.Text = ""
        End If

        txtShow.Text = CallClass.ReturnInfoWithParString("cspReturnFormText", lblFileName.Text)
        If txtShow.Text = "False" Then
            txtShow.Text = ""
        End If

        Dim strRadio As String
        strRadio = ""
        strRadio = CallClass.ReturnInfoWithParString("cspReturnFormRead", lblFileName.Text)
        If strRadio = "False" Then
            RdRead.Checked = False
        Else
            If strRadio = "1" Then
                RdRead.Checked = True
            Else
                RdRead.Checked = False
            End If
        End If

        strRadio = ""
        strRadio = CallClass.ReturnInfoWithParString("cspReturnFormMod", lblFileName.Text)
        If strRadio = "False" Then
            RdMod.Checked = False
        Else
            If strRadio = "1" Then
                RdMod.Checked = True
            Else
                RdMod.Checked = False
            End If
        End If

        CmdRemove.Enabled = True

    End Sub

    Private Sub CmdCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCollapse.Click
        TrView.CollapseAll()
    End Sub

    Private Sub CmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRemove.Click

        If IsDBNull(lblFileName.Text) = True Then
            MsgBox("Action Denied.")
            Exit Sub
        End If

        If Len(Trim(lblFileName.Text)) = 0 Then
            MsgBox("Action Denied.")
            Exit Sub
        End If

        Dim reply As DialogResult

        reply = MsgBox("Do you Want to Remove the Document from Database?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            CallClass.ExecuteUpdateSearchStr("cspUpdateDeleteFormTitle", lblFileName.Text)
            LoadTree()
            CmdRemove.Enabled = False
        End If

    End Sub

    Private Sub CmdExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExpand.Click
        TrView.ExpandAll()
    End Sub

    Private Sub TrView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrView.DoubleClick

        If IsDBNull(lblFilePath.Text) = False And _
            IsNothing(lblFilePath.Text) = False And _
            Len(Trim(lblFilePath.Text)) <> 0 Then
            Try
                Process.Start(lblFilePath.Text)
            Catch
            End Try
        End If

    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        LoadTree()

        TrView.CollapseAll()
    End Sub

    Private Sub CmdSrc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSrc.Click

        If Len(Trim(txtSrc.Text)) <> 0 Then
            Pb1.Minimum = 0
            Pb1.Maximum = 3000
            Pb1.Visible = False

            TrView.Nodes.Clear()

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()

            daCode.Dispose()

            If ChkTitle.Checked = True And ChkKey.Checked = True Then
                daCode = New SqlDataAdapter("select  distinct FormNode from tblLisiFormControl WHERE (FormText LIKE " & "'%" & txtSrc.Text & "%') OR (FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
            Else
                If ChkTitle.Checked = True And ChkKey.Checked = False Then
                    daCode = New SqlDataAdapter("select  distinct FormNode from tblLisiFormControl WHERE (FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                Else
                    If ChkTitle.Checked = False And ChkKey.Checked = True Then
                        daCode = New SqlDataAdapter("select  distinct FormNode from tblLisiFormControl WHERE (FormText LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                    Else
                        MsgBox(" Nothing to Search.")
                        Exit Sub
                    End If
                End If
            End If

            dsMain = New Data.DataSet()

            daCode.Fill(dsMain, "tblNode") 'l

            Dim I%, j%, Code$, Title$

            For I = 0 To dsMain.Tables("tblNode").Rows.Count - 1

                Code$ = dsMain.Tables("tblNode").Rows(I).Item("FormNode").ToString

                TrView.Nodes.Add(Code)
                TrView.Nodes(I).ImageIndex = 0

                'daTitle = New SqlDataAdapter("select FormTitle from tblLisiFormControl where FormNode = '" & Code & "' ", cn)

                If ChkTitle.Checked = True And ChkKey.Checked = True Then
                    daTitle = New SqlDataAdapter("select  FormTitle from tblLisiFormControl WHERE FormNode = '" & Code & "' AND " & "((FormText LIKE " & "'%" & txtSrc.Text & "%') OR (FormTitle LIKE " & "'%" & txtSrc.Text & "%'))" & " ORDER by FormNode", cn)
                Else
                    If ChkTitle.Checked = True And ChkKey.Checked = False Then
                        daTitle = New SqlDataAdapter("select FormTitle from tblLisiFormControl WHERE FormNode = '" & Code & "' AND " & "(FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                    Else
                        If ChkTitle.Checked = False And ChkKey.Checked = True Then
                            daTitle = New SqlDataAdapter("select  FormTitle from tblLisiFormControl WHERE FormNode = '" & Code & "' AND " & "(FormText LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                        End If
                    End If
                End If

                daTitle.Fill(dsMain, "tblTitle") 'l
                dsMain.Tables("tblTitle").Clear()
                daTitle.Fill(dsMain, "tblTitle") 'l

                For j = 0 To dsMain.Tables("tblTitle").Rows.Count - 1

                    Title$ = dsMain.Tables("tblTitle").Rows(j).Item("FormTitle").ToString
                    Dim CodeTitle As TreeNode
                    CodeTitle = TrView.Nodes(I)

                    CodeTitle.Nodes.Add(Title)
                    CodeTitle.Expand()
                Next
            Next
            Pb1.Visible = True
            For I = 0 To 3000
                Pb1.Value = I
            Next
            Pb1.Visible = False
            cn.Close()
        Else
            MsgBox(" Nothing to Search.")
        End If

    End Sub

    Sub PutClasification()

        With Me.CmbNode
            .DataSource = CallClass.PopulateComboBox("tblLisiFormClasification", "gettblLisiFormClasification").Tables("tblLisiFormClasification")
            .DisplayMember = "QAFormClasification"
            .ValueMember = "QAFormClasification"
        End With

    End Sub

    Private Sub CmdClasif_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClasif.Click
        frmQAClasification.ShowDialog()

        PutClasification()
    End Sub
End Class

'Private Sub ConvertFile()
'    If Microsoft.VisualBasic.Right(Trim(lblFilePath.Text), 3) = "doc" Then
'        msWord = CreateObject("Word.Application.8")
'        msWord.Visible = True
'        msWord.ActivePrinter = "PDF4U Adobe PDF Creator"
'        msWord.Documents.Open(lblFilePath.Text)
'        'msWord.DisplayAlerts = False
'        'msWord.ActiveDocument.PrintOut()
'        msWord.ActiveDocument.Application.PrintOut()

'        'msWord.ActiveDocument.SaveAs ("C:\WINDOWS\Desktop\test1.pdf")
'        msWord.ActiveDocument.Close(False)
'        msWord.Application.Quit(True)

'        msWord = Nothing
'        Exit Sub

'    ElseIf Microsoft.VisualBasic.Right(Trim(lblFilePath.Text), 3) = "xls" Then
'        Dim msExcel As Microsoft.Office.Interop.Excel.Application
'        Dim msWorkbook As Microsoft.Office.Interop.Excel.Workbook
'        Dim ws As Microsoft.Office.Interop.Excel.Worksheets
'        msExcel = CreateObject("Excel.application")

'        msExcel.Visible = True
'        msExcel.Workbooks.Open(lblFilePath.Text, UpdateLinks:=False)
'        msExcel.ActiveWorkbook.PrintOut(ActivePrinter:="PDF4U Adobe PDF Creator")

'        msExcel.ActiveWorkbook.Close(False)
'        msExcel.Quit()
'        msWorkbook = Nothing
'        msExcel = Nothing
'        Exit Sub
'    ElseIf Microsoft.VisualBasic.Right(Trim(lblFilePath.Text), 3) = "ppt" Then
'        Dim msppt As Microsoft.Office.Interop.PowerPoint.Application
'        msppt = CreateObject("PowerPoint.Application")

'        msppt.Visible = True

'        msppt.Presentations.Open(lblFilePath.Text)
'        msppt.ActivePresentation.PrintOptions.ActivePrinter = "PDFCreator"
'        msppt.ActivePresentation.PrintOut()

'        msppt.ActivePresentation.Close()
'        msppt.Quit()

'        msppt = Nothing
'        Exit Sub
'    End If
'End Sub

'Private Sub btnConvert_Click()
'    Dim strFileToConvert As String
'    Dim strFolder As String
'    Dim fext As String
'    Dim subfolder

'    strFolder = m_txtSource

'    objfs = CreateObject("Scripting.FileSystemObject")
'    sfolder = objfs.GetFolder("D:\test")



'    For Each subfolder In sfolder.SubFolders
'        fname = subfolder.Name
'        fo1 = objfs.GetFolder("D:\test\" & fname)
'        For Each mFile In fo1.Files

'            fext = Mid(mFile.Name, InStr(1, mFile.Name, ".") + 1)

'            strFileToConvert = "D:\test\" & fname & "\" & mFile.Name

'            If strFileToConvert <> "" Then

'                If (ConvertFile(strFileToConvert, fext) = False) Then
'                    If (MsgBox("There has been a problem converting the file " + strFileToConvert + "Do you wish to exit", vbYesNo) = vbYes) Then
'                        Exit Sub
'                    End If
'                End If
'            End If
'        Next
'    Next
'    Unload(Me)

'End Sub

'    Hi all its urgent 
'Can any one help me 
'While i am converting the normal document into pdf it prompts an save as block to give the destination to the pdf document what i want is that the pdf file should get stored in a specified path through the code . Beacuse i have to shedule programe.
'Please any one help me its very urgent and i am stucking at the end of my work .

'I dont think this warrented a new post mithun,
'however:
'try turning off the display alerts for your word, excel and powerpoint objects..
'e.g. msWord.DisplayAlerts = False

'No sir its not working as i have to save converted pdf file to a particular location
'msWord.ActivePrinter = "PDF995" ' This is the name of the pdf printer
'msWord.Documents.Open strSourceFileName 'Here it takes the name of the file which is to be converted into pdf
'msWord.ActiveDocument.PrintOut 'Here it converts into pdf and prompts an save as box to save the pdf file
'msWord.ActiveDocument.Close (False)
'msWord.Application.Quit (True)




