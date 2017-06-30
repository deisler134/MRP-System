Option Strict Off
Option Explicit On

'Imports ADODB
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmHSEImportWordDoc

    ' Dim msWord As Microsoft.Office.Interop.Word.Application

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim daCode As SqlDataAdapter
    Dim daCode_1 As SqlDataAdapter
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
            .InitialDirectory = "\\Srv115fs01\Lisi HSE Documentation"
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

    Private Sub frmHSEImportWordDoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmHSEImportWordDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        PutClasification()

        PutClasification_1()

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
        'whe hide it so when the user click the button it appears, load the value and the
        'then hide again...just to give a nice looking...
        Pb1.Visible = False

        TrView.Nodes.Clear()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        'get the data..
        daCode = New SqlDataAdapter("select distinct FormNode from tblHSEFormControl ORDER by FormNode", cn)

        dsMain = New Data.DataSet()
        daCode.Fill(dsMain, "tblNode")

        Dim I%, J%, K%, Code$, Code_1$, Title$

        'lets count all the rows we got in order to add them to the control one by one...
        For I = 0 To dsMain.Tables("tblNode").Rows.Count - 1
            Code$ = dsMain.Tables("tblNode").Rows(I).Item("FormNode").ToString

            TrView.Nodes.Add(Code$)          'we add the items one by one...

            TrView.Nodes(I).ImageIndex = 0
            'now that we are in xx position...lets say the 3rd position(remember that the tables in the dataset
            'begin with position 0)we get all the records from the Cargo table that belong to the categoria field
            'so we add them as childs to the respective parent node in the control...

            daCode_1 = New SqlDataAdapter("select distinct FormNode_1 from tblHSEFormControl where FormNode='" & Code$ & "'" & " ORDER BY FormNode_1", cn)
            daCode_1.Fill(dsMain, "tblNode_1")
            dsMain.Tables("tblNode_1").Clear()
            daCode_1.Fill(dsMain, "tblNode_1")
            For K = 0 To dsMain.Tables("tblNode_1").Rows.Count - 1
                Code_1$ = dsMain.Tables("tblNode_1").Rows(K).Item("FormNode_1").ToString
                Dim Code_1Node As New TreeNode
                If IsDBNull(Code_1$) = False And Len(Trim(Code_1$)) > 0 Then
                    Code_1Node = TrView.Nodes(I)
                    Code_1Node.Nodes.Add(Code_1$)
                    'asigne a image 'then we expand the nodes so we can show the child nodes
                    Code_1Node.Expand()
                End If

                daTitle = New SqlDataAdapter("select FormTitle from tblHSEFormControl where FormNode='" & Code$ & "'" & " AND FormNode_1='" & Code_1$ & "'", cn)
                daTitle.Fill(dsMain, "tblTitle")
                dsMain.Tables("tblTitle").Clear()
                daTitle.Fill(dsMain, "tblTitle")
                For J = 0 To dsMain.Tables("tblTitle").Rows.Count - 1
                    Title$ = dsMain.Tables("tblTitle").Rows(J).Item("FormTitle").ToString
                    Dim CodeTitle As TreeNode
                    If IsDBNull(Code_1$) = False And Len(Trim(Code_1$)) > 0 Then
                        CodeTitle = Code_1Node.Nodes(K)
                    Else
                        CodeTitle = TrView.Nodes(I)
                    End If

                    CodeTitle.Nodes.Add(Title)
                    'asigne a image 'then we expand the nodes so we can show the child nodes
                    CodeTitle.Expand()
                Next
            Next
        Next

        Pb1.Visible = True
        For I = 0 To 3000
            Pb1.Value = I
        Next

        Pb1.Visible = False

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        ValInfo()

        If SwVal = True Then

            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateHSEForms", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraSrc As SqlParameter = New SqlParameter("@StrSearch", SqlDbType.NVarChar, 1000)
            paraSrc.Value = Trim(CmbNode.Text) + Trim(CmbNode_1.Text) + Trim(lblFileName.Text)
            mySqlComm.Parameters.Add(paraSrc)

            Dim paratitle As SqlParameter = New SqlParameter("@FormTitle", SqlDbType.NVarChar, 1000)
            paratitle.Value = lblFileName.Text
            mySqlComm.Parameters.Add(paratitle)

            Dim paraNode As SqlParameter = New SqlParameter("@FormNode", SqlDbType.NVarChar, 100)
            paraNode.Value = CmbNode.Text
            mySqlComm.Parameters.Add(paraNode)

            Dim paraNode1 As SqlParameter = New SqlParameter("@FormNode_1", SqlDbType.NVarChar, 100)
            paraNode1.Value = CmbNode_1.Text
            mySqlComm.Parameters.Add(paraNode1)

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
                MsgBox("ERROR  -  Update HSE Documentation Module." & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

        CmdSave.Enabled = True
        CmdBrowse.Enabled = True


        Dim StrSearch, SwCount As String
        StrSearch = Trim(CmbNode.Text) + Trim(CmbNode_1.Text)
        
        SwCount = CallClass.TakeFinalSt("cspReturnHSENodeEmpty", StrSearch)
        If Val(SwCount) > 1 Then
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateHSEFormsDeleteEmpty", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraSrc As SqlParameter = New SqlParameter("@StrSearchDelete", SqlDbType.NVarChar, 400)
            paraSrc.Value = Trim(CmbNode.Text) + Trim(CmbNode_1.Text)
            mySqlComm.Parameters.Add(paraSrc)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("ERROR  -  Delete HSE Documentation Module - Empty Records." & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

        LoadTree()

        CmbNode.Text = ""
        CmbNode_1.Text = ""
        lblFileName.Text = ""
        lblFilePath.Text = ""

    End Sub

    Sub ValInfo()

        If IsDBNull(CmbNode.Text) = True Or Len(Trim(CmbNode.Text)) = 0 = True Then
            If IsDBNull(CmbNode_1.Text) = True Or Len(Trim(CmbNode_1.Text)) = 0 = True Then
                If IsDBNull(lblFileName.Text) = True Or Len(Trim(lblFileName.Text)) = 0 = True Then
                    MsgBox("!!! ERROR !!! Nodes and document description are Empty.")
                    SwVal = False
                    Exit Sub
                End If
            End If
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
        Dim JJ As Integer = 0
        Dim KeepPos As Integer = 0
        Dim KeepPos_2 As Integer = 0
        For I = 0 To Len(ArrName) - 1
            If ArrName(I) = CChar("\") Then
                KeepPos = I
                JJ = JJ + 1
            End If
        Next

        CmbNode.Text = ""
        CmbNode_1.Text = ""
        lblFileName.Text = ""
        lblFilePath.Text = ""

        If KeepPos <> 0 Then
            If JJ = 1 Then
                CmbNode.Text = Trim(Mid(ArrName, 1, KeepPos))
                CmbNode_1.Text = Trim(Mid(ArrName, KeepPos + 2))
                lblFileName.Text = Trim(Mid(ArrName, KeepPos + 2))
            Else
                'CmbNode.Text = Trim(Mid(ArrName, 1, 1))
                'CmbNode_1.Text = Trim(Mid(ArrName, 1 + 2))

                'CmbNode.Text = Trim(Mid(ArrName, 1, JJ))
                'CmbNode_1.Text = Trim(Mid(ArrName, 1, JJ + 2))
                lblFileName.Text = Trim(Mid(ArrName, KeepPos + 2))
            End If
           
        Else
            CmbNode.Text = Trim(ArrName)
        End If

        lblFilePath.Text = CallClass.ReturnInfoWithParString("cspReturnFormPathHSE", lblFileName.Text)
        If lblFilePath.Text = "False" Then
            lblFilePath.Text = ""
        End If

        txtShow.Text = CallClass.ReturnInfoWithParString("cspReturnFormTextHSE", lblFileName.Text)
        If txtShow.Text = "False" Then
            txtShow.Text = ""
        End If

        Dim strRadio As String
        strRadio = ""
        strRadio = CallClass.ReturnInfoWithParString("cspReturnFormReadHSE", lblFileName.Text)
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
        strRadio = CallClass.ReturnInfoWithParString("cspReturnFormModHSE", lblFileName.Text)
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

        reply = MsgBox("Do you Want to Remove the Document Path from Database?", MsgBoxStyle.YesNo)
        If reply = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            CallClass.ExecuteUpdateSearchStr("cspUpdateDeleteFormTitleHSE", Trim(lblFileName.Text))
            LoadTree()
            CmdRemove.Enabled = False
            CmdSave.Enabled = False

            CmbNode.Text = ""
            CmbNode_1.Text = ""
            lblFileName.Text = ""
            lblFilePath.Text = ""
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
                daCode = New SqlDataAdapter("select  distinct FormNode from tblHSEFormControl WHERE (FormText LIKE " & "'%" & txtSrc.Text & "%') OR (FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
            Else
                If ChkTitle.Checked = True And ChkKey.Checked = False Then
                    daCode = New SqlDataAdapter("select  distinct FormNode from tblHSEFormControl WHERE (FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                Else
                    If ChkTitle.Checked = False And ChkKey.Checked = True Then
                        daCode = New SqlDataAdapter("select  distinct FormNode from tblHSEFormControl WHERE (FormText LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
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
                    daTitle = New SqlDataAdapter("select  FormTitle from tblHSEFormControl WHERE FormNode = '" & Code & "' AND " & "((FormText LIKE " & "'%" & txtSrc.Text & "%') OR (FormTitle LIKE " & "'%" & txtSrc.Text & "%'))" & " ORDER by FormNode", cn)
                Else
                    If ChkTitle.Checked = True And ChkKey.Checked = False Then
                        daTitle = New SqlDataAdapter("select FormTitle from tblHSEFormControl WHERE FormNode = '" & Code & "' AND " & "(FormTitle LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
                    Else
                        If ChkTitle.Checked = False And ChkKey.Checked = True Then
                            daTitle = New SqlDataAdapter("select  FormTitle from tblHSEFormControl WHERE FormNode = '" & Code & "' AND " & "(FormText LIKE " & "'%" & txtSrc.Text & "%')" & " ORDER by FormNode", cn)
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

    Private Sub CmdClasif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClasif.Click
        frmHSEClasification.ShowDialog()

        PutClasification()
        PutClasification_1()

    End Sub

    Sub PutClasification()

        With Me.CmbNode
            .DataSource = CallClass.PopulateComboBox("tblHSEFormClasification", "gettblHSEFormClasification").Tables("tblHSEFormClasification")
            .DisplayMember = "HSEFormClasification"
            .ValueMember = "HSEFormClasification"
        End With

    End Sub

    Sub PutClasification_1()

        With Me.CmbNode_1
            .DataSource = CallClass.PopulateComboBox("tblHSEFormClasification", "gettblHSEFormClasification").Tables("tblHSEFormClasification")
            .DisplayMember = "HSEFormClasification"
            .ValueMember = "HSEFormClasification"
        End With

    End Sub

    Private Sub CmdClasif_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmHSEClasification.ShowDialog()

        PutClasification()
        PutClasification_1()

    End Sub

End Class

