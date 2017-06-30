Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmQAReadDocuments


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

    Dim fileToPrint As String

    Sub InitScreen()

        ChkTitle.Checked = False
        ChkKey.Checked = False
        txtSrc.Text = ""
        lblFilePath.Text = ""

    End Sub

    Private Sub frmQAReadDocuments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmQAReadDocuments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        LoadTree()

        TrView.CollapseAll()
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

        lblFileName.Text = ""
        lblFilePath.Text = ""

        If KeepPos <> 0 Then
            lblFileName.Text = Trim(Mid(ArrName, KeepPos + 2))
        End If

        lblFilePath.Text = CallClass.ReturnInfoWithParString("cspReturnFormPath", lblFileName.Text)
        If lblFilePath.Text = "False" Then
            lblFilePath.Text = ""
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

    End Sub


    Private Sub CmdCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCollapse.Click
        TrView.CollapseAll()
    End Sub

    Private Sub CmdExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExpand.Click
        TrView.ExpandAll()
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

    Private Sub TrView_DoubleClick(sender As Object, e As EventArgs) Handles TrView.DoubleClick

        If Len(Trim(lblFilePath.Text)) <> 0 Then
            If RdRead.Checked = True Then
                MsgBox("Uncontrolled when printed")
            Else
                If RdMod.Checked = True Then
                    MsgBox("Record is valid only when printed and signed / stamped." + vbCrLf _
                        + "Always use FORMS from this data base." + vbCrLf _
                        + "Don't save blank FORM on your computer, FORM might be updated anytime." + vbCrLf + vbCrLf _
                        + "Any question, send a request to QMS administrator.")
                End If
            End If
            ' Process.Start(lblFilePath.Text)

            ' Create an instance
            Dim proc As New System.Diagnostics.Process()

            ' Fill-up StartInfo
            proc.StartInfo.UseShellExecute = True
            proc.StartInfo.FileName = lblFilePath.Text

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

            'MessageBox.Show("Application exited with exitcode: " + proc.ExitCode.ToString())
            proc.Dispose()
        End If
    End Sub

End Class

