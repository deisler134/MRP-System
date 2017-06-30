Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmPartCreateCrossRef

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowPart As Integer = 0       'dgProd row.
    Dim SwVal As Boolean = False
    Dim SWNewNo As String = ""
    Dim SwCheck As Integer = 0

    Private Sub frmPartCreateCrossRef_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPartCreateCrossRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetupForm()

    End Sub

    Sub SetupForm()

        GC.Collect()
        InitialComponents()
        PutBasicNumber()
        PutPartFinishing()

        SetCtlForm()

        ClearFields()

        EnableFields()

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getPartNumberListByBasicNumberEmpty").Fill(dsMain, "tblSelectBasic")

        dsMain.EnforceConstraints = False

        PutDataGrid()

    End Sub

    Sub PutDataGrid()

        dgPart.AutoGenerateColumns = False
        dgPart.DataSource = dsMain
        dgPart.DataMember = "tblSelectBasic"

    End Sub

    Sub PutBasicNumber()

        With Me.CmbPrefix
            .DataSource = CallClass.PopulateComboBox("tblPartBasicNumber", "cmbGetPartBasicNo").Tables("tblPartBasicNumber")
            .DisplayMember = "FullDescr"
            .ValueMember = "BasicNumber"
        End With

    End Sub

    Sub PutPartFinishing()

        With Me.CmbFinish
            .DataSource = CallClass.PopulateComboBox("tblPartFinishCode", "cmbGetPartFinishing").Tables("tblPartFinishCode")
            .DisplayMember = "FullDescr"
            .ValueMember = "FinishID"
        End With

    End Sub

    Sub SetCtlForm()

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.PartName
            .DataPropertyName = "PartName"
            .Name = "PartName"
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.SwNewPartID
            .DataPropertyName = "SwNewPartID"
            .Name = "SwNewPartID"
            .Visible = False
        End With

        With Me.CrossPN
            .DataPropertyName = "CrossPN"
            .Name = "CrossPN"
        End With

        With Me.CrossPartID
            .DataPropertyName = "CrossPartID"
            .Name = "CrossPartID"
            .Visible = False
        End With

        With Me.SwCrossPartID
            .DataPropertyName = "SwCrossPartID"
            .Name = "SwCrossPartID"
            .Visible = False
        End With

    End Sub

    Sub ClearFields()

        txtDIAInch.Text = ""

        'CmbFrom.Text = ""
        'CmbTo.Text = ""
        'CmbPrefix.Text = ""
        CmbDIA.Text = ""
        'CmbFinish.Text = ""
        CmbXY.Text = "No"

    End Sub

    Sub DisableFields()

        CmbPrefix.Enabled = False
        CmbDIA.Enabled = False
        CmbFinish.Enabled = False
        CmbFrom.Enabled = False
        CmbXY.Enabled = False
        CmbTo.Enabled = False

        CmdSearch.Enabled = False
        CmdExec.Enabled = False

    End Sub

    Sub EnableFields()

        CmbPrefix.Enabled = True
        CmbDIA.Enabled = True
        CmbFinish.Enabled = True
        CmbFrom.Enabled = True
        CmbTo.Enabled = True
        CmbXY.Enabled = True

        CmdSearch.Enabled = True
        CmdExec.Enabled = False
        CmdSave.Enabled = False

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        ClearFields()
        EnableFields()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

    End Sub

    Sub ExecuteSearch()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Me.Refresh()

        Dim strSearch As String

        strSearch = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(CmbDIA.Text)

        If Len(Trim(strSearch)) > 0 Then
            CallClass.PopulateDataAdapterAfterSearch("getPartNumberListByBasicNumber", strSearch).Fill(dsMain, "tblSelectBasic")

            CmdExec.Enabled = True

        Else
            MsgBox("!!! ERROR !!! Search criteria is missing.")
        End If

    End Sub

    Private Sub CmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExec.Click

        ValData()

        If SwVal = False Then
            Exit Sub
        End If

        DisableFields()

        GenerateNewMasterParts()

        GenerateNewCrossParts()

        CmdSave.Enabled = True

    End Sub

    Sub GenerateNewMasterParts()

        Dim IFr As Integer = 0
        Dim JTo As Integer = 0

        IFr = CmbFrom.Text
        JTo = CmbTo.Text

        For I As Integer = IFr To JTo

            Select Case CmbPrefix.SelectedItem("BasicCust")

                Case "BOMBARDIER"

                    If InStr(dgPart.Item("PartNumber", RowPart).Value, "-") <> 0 Then
                        SWNewNo = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(CmbDIA.Text) + Trim(CmbFinish.SelectedItem("FinishID")) + Trim(Str(I))
                        SwCheck = 0
                        For Each Row As DataGridViewRow In dgPart.Rows
                            If Row.Cells("PartNumber").Value = SWNewNo Then
                                SwCheck = 1
                            End If
                        Next
                        If SwCheck = 0 Then         ' zero not found
                            AddNewRow()
                        End If
                    Else
                        SWNewNo = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(Str(I)) + CmbACU.Text        '+ Trim(CmbDIA.Text) 
                        SwCheck = 0
                        For Each Row As DataGridViewRow In dgPart.Rows
                            If Row.Cells("PartNumber").Value = SWNewNo Then
                                SwCheck = 1
                            End If
                        Next
                        If SwCheck = 0 Then         ' zero not found
                            AddNewRow()
                        End If
                    End If

                Case "BOEING"
                    ' step normal
                    SWNewNo = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(CmbDIA.Text) + Trim(CmbFinish.SelectedItem("FinishID")) + Trim(Str(I))
                    SwCheck = 0
                    For Each Row As DataGridViewRow In dgPart.Rows
                        If Row.Cells("PartNumber").Value = SWNewNo Then
                            SwCheck = 1
                        End If
                    Next
                    If SwCheck = 0 Then         ' zero not found
                        AddNewRow()
                    End If

                    If CmbXY.Text = "Yes" Then
                        ' step with X
                        SWNewNo = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(CmbDIA.Text) + Trim(CmbFinish.SelectedItem("FinishID")) + Trim(Str(I)) + "X"
                        SwCheck = 0
                        For Each Row As DataGridViewRow In dgPart.Rows
                            If Row.Cells("PartNumber").Value = SWNewNo Then
                                SwCheck = 1
                            End If
                        Next
                        If SwCheck = 0 Then         ' zero not found
                            AddNewRow()
                        End If

                        'step with Y
                        SWNewNo = Trim(CmbPrefix.SelectedItem("BasicNumber")) + Trim(CmbDIA.Text) + Trim(CmbFinish.SelectedItem("FinishID")) + Trim(Str(I)) + "Y"
                        SwCheck = 0
                        For Each Row As DataGridViewRow In dgPart.Rows
                            If Row.Cells("PartNumber").Value = SWNewNo Then
                                SwCheck = 1
                            End If
                        Next
                        If SwCheck = 0 Then         ' zero not found
                            AddNewRow()
                        End If

                    End If



                Case Else

            End Select
        Next

        For Each Row As DataGridViewRow In dgPart.Rows
            If Row.Cells("SwNewPartID").Value = "9" Then
                Row.Cells("PartNumber").Style.BackColor = Color.LightSkyBlue
            End If
        Next

    End Sub

    Sub AddNewRow()

        Dim tb As DataTable
        Dim rw As DataRow
        tb = dsMain.Tables("tblSelectBasic")
        rw = tb.NewRow

        rw("PartNumber") = SWNewNo
        rw("PartDescCode") = ""

        If CmbPrefix.SelectedItem("BasicCust") = "BOMBARDIER" Then
            rw("PartName") = ""
        Else
            rw("PartName") = "BOLT, TYPE"
        End If

        rw("SwNewPartID") = "9"
        tb.Rows.Add(rw)

    End Sub

    Sub GenerateNewCrossParts()

        Dim SwBasicCust As String
        Dim SwBasicCross As String
        Dim SwTempFiels As String
        Dim SwFindFinish As String

        Dim DigitStr As String
        DigitStr = ""
        Dim I As Integer = 0

        For Each Row As DataGridViewRow In dgPart.Rows
            If IsDBNull(Row.Cells("CrossPN").Value) = True Then
                Row.Cells("SwCrossPartID").Value = "9"
                GoTo NextCross
            Else
                If Microsoft.VisualBasic.Len(Trim(Row.Cells("CrossPN").Value)) = 0 Then
                    Row.Cells("SwCrossPartID").Value = "9"
                    GoTo NextCross
                End If
                GoTo NextPart
            End If

NextCross:
            SwBasicCust = CallClass.ReturnInfoWithParString("cspReturnBasicCust", Row.Cells("PartNumber").Value)
            Select Case SwBasicCust
                Case "BOMBARDIER"           ' replace in partnumber wIth basic CROSS and will give you the new cross part number
                    SwBasicCross = CallClass.ReturnInfoWithParString("cspReturnBasicCross", Row.Cells("PartNumber").Value)

                    Dim str1 As String = Row.Cells("PartNumber").Value

                    Row.Cells("CrossPN").Value = str1.Replace(CmbPrefix.SelectedItem("BasicNumber"), SwBasicCross)
                    Row.Cells("CrossPN").Style.BackColor = Color.LemonChiffon
                    'Dim str1 As String = "ppp"
                    'Dim repStr As String = str1.Replace("p", "l")

                Case "BOEING"

                    If Microsoft.VisualBasic.Right(Trim(Row.Cells("PartNumber").Value), 1) = "Y" Then
                        SwBasicCross = CallClass.ReturnInfoWithParString("cspReturnBasicCrossY", Row.Cells("PartNumber").Value)
                    Else
                        If Microsoft.VisualBasic.Right(Trim(Row.Cells("PartNumber").Value), 1) = "X" Then
                            SwBasicCross = CallClass.ReturnInfoWithParString("cspReturnBasicCrossX", Row.Cells("PartNumber").Value)
                        Else
                            SwBasicCross = CallClass.ReturnInfoWithParString("cspReturnBasicCross", Row.Cells("PartNumber").Value)
                        End If
                    End If


                    If SwBasicCross <> "False" Then
                        Dim str1 As String = Row.Cells("PartNumber").Value
                        'Row.Cells("CrossPN").Value = str1.Replace(CmbPrefix.SelectedItem("BasicNumber"), SwBasicCross)

                        SwTempFiels = str1.Replace(CmbPrefix.SelectedItem("BasicNumber"), "")
                        For I = 0 To Len(SwTempFiels) - 1
                            If IsNumeric(SwTempFiels(I)) = False Then
                                If SwTempFiels(I) <> "X" And SwTempFiels(I) <> "Y" Then
                                    DigitStr = SwTempFiels(I)
                                End If
                            End If
                        Next
                        SwFindFinish = CallClass.ReturnStrWith2ParStr("cspReturnCrossFinishNo", CmbPrefix.SelectedItem("BasicNumber"), DigitStr)

                        If SwFindFinish <> "False" Then
                            Row.Cells("CrossPN").Value = SwBasicCross + SwFindFinish
                            For I = 0 To Len(SwTempFiels) - 1
                                If IsNumeric(SwTempFiels(I)) = True Then
                                    Row.Cells("CrossPN").Value = Row.Cells("CrossPN").Value + SwTempFiels(I)
                                Else
                                    If SwTempFiels(I) <> "X" And SwTempFiels(I) <> "Y" Then
                                        Row.Cells("CrossPN").Value = Row.Cells("CrossPN").Value + "-"
                                    End If
                                End If
                            Next
                            Row.Cells("CrossPN").Style.BackColor = Color.LemonChiffon
                        End If


                    End If

                Case Else

            End Select

NextPart:
        Next

    End Sub

    Sub ValData()

        SwVal = False

        If Len(Trim(CmbPrefix.Text)) = 0 Then
            MsgBox("!!! ERROR !!! The Basic Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If CmbPrefix.SelectedItem("BasicCust") = "BOMBARDIER" Then
            'skip
        Else
            If Len(Trim(CmbDIA.Text)) = 0 Then
                MsgBox("!!! ERROR !!! The Nominal DIA is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbPrefix.SelectedItem("BasicCust") = "BOMBARDIER" Then
            'skip
        Else
            If Len(Trim(CmbFinish.Text)) = 0 Then
                MsgBox("!!! ERROR !!! The Part Finishing is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Len(Trim(CmbFrom.Text)) = 0 Then
            MsgBox("!!! ERROR !!! The Part Length From is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbTo.Text)) = 0 Then
            MsgBox("!!! ERROR !!! The Part Length To is Empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub dgPart_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPart.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPart = e.RowIndex
    End Sub

    Private Sub dgPart_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPart.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPart = e.RowIndex

    End Sub

    Private Sub dgPart_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPart.DataError
        REM end
    End Sub

    Private Sub dgPart_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPart.Sorted

        For Each Row As DataGridViewRow In dgPart.Rows
            If Row.Cells("SwNewPartID").Value = "9" Then
                Row.Cells("PartNumber").Style.BackColor = Color.LightSkyBlue
            End If

            If Nz.Nz(Row.Cells("SwCrossPartID").Value) = "9" Then
                Row.Cells("CrossPN").Style.BackColor = Color.LemonChiffon
            End If
        Next

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSearch.Click

        If Len(Trim(CmbPrefix.Text)) > 0 Then
            txtDIAInch.Text = Nz.Nz(CmbPrefix.SelectedItem("BasicSizeValue")) * Val(CmbDIA.Text)

            ExecuteSearch()

            If dgPart.Rows.Count <= 0 Then
                CmdExec.Enabled = False
                Exit Sub
            Else
                CmdExec.Enabled = True
            End If

            If CmbPrefix.SelectedItem("BasicCust") = "BOMBARDIER" Then
                If InStr(dgPart.Item("PartNumber", RowPart).Value, "-") <> 0 Then
                    CmbFinish.Text = "-"
                Else
                    CmbFinish.Text = ""
                End If

                CmbFinish.Enabled = False       'only for Bombardier
            End If
        Else
            MsgBox("Please select the Part Family you want to generate.")
        End If

    End Sub

    Sub SaveGenMaster()

        If dgPart.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim II, JJ As Integer
        JJ = dgPart.Rows.Count
        For II = 0 To JJ - 1
            Dim cmdInsertPartID As SqlCommand = New SqlCommand("cspUpdateNewPartBasicInPartMaster", cn)
            cmdInsertPartID.CommandType = CommandType.StoredProcedure

            If dgPart.Item("SwNewPartID", II).Value = "9" Then
                If IsDBNull(dgPart.Item("PartNumber", II).Value) = False Then

                    Dim parPartID As SqlParameter = New SqlParameter("@PartID", SqlDbType.Int, 4)
                    parPartID.Value = dgPart.Item("PartID", II).Value
                    cmdInsertPartID.Parameters.Add(parPartID)

                    Dim parDate As SqlParameter = New SqlParameter("@DateIssue", SqlDbType.SmallDateTime, 4)
                    parDate.Value = Now.ToShortDateString
                    cmdInsertPartID.Parameters.Add(parDate)

                    Dim parCreatedBy As SqlParameter = New SqlParameter("@CreatedBy", SqlDbType.Int, 4)
                    parCreatedBy.Value = wkEmpId
                    cmdInsertPartID.Parameters.Add(parCreatedBy)

                    Dim parPartNo As SqlParameter = New SqlParameter("@PartNumber", SqlDbType.NVarChar, 50)
                    parPartNo.Value = dgPart.Item("PartNumber", II).Value
                    cmdInsertPartID.Parameters.Add(parPartNo)

                    Dim parPartName As SqlParameter = New SqlParameter("@PartName", SqlDbType.NVarChar, 100)
                    parPartName.Value = dgPart.Item("PartName", II).Value
                    cmdInsertPartID.Parameters.Add(parPartName)

                    Dim parCrStatus As SqlParameter = New SqlParameter("@PNCrossStatus", SqlDbType.Int, 4)
                    parCrStatus.Value = 99
                    cmdInsertPartID.Parameters.Add(parCrStatus)

                    Try
                        If cn.State = ConnectionState.Closed Then
                            cn.Open()
                        End If
                        cmdInsertPartID.ExecuteNonQuery()
                        cmdInsertPartID.Dispose()
                    Catch ex As SqlException
                        MsgBox("Add Master Part - ID: " & ex.Message)
                    Finally
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                    End Try
                End If
            End If

        Next

    End Sub

    Sub SaveGenCrossPart()

        If dgPart.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim II, JJ As Integer
        JJ = dgPart.Rows.Count
        For II = 0 To JJ - 1
            Dim cmdInsertPartID As SqlCommand = New SqlCommand("cspUpdateNewPartBasicInPartMaster", cn)
            cmdInsertPartID.CommandType = CommandType.StoredProcedure

            If dgPart.Item("SwCrossPartID", II).Value = "9" Then
                If IsDBNull(dgPart.Item("CrossPN", II).Value) = False Then

                    Dim parPartID As SqlParameter = New SqlParameter("@PartID", SqlDbType.Int, 4)
                    parPartID.Value = dgPart.Item("PartID", II).Value
                    cmdInsertPartID.Parameters.Add(parPartID)

                    Dim parDate As SqlParameter = New SqlParameter("@DateIssue", SqlDbType.SmallDateTime, 4)
                    parDate.Value = Now.ToShortDateString
                    cmdInsertPartID.Parameters.Add(parDate)

                    Dim parCreatedBy As SqlParameter = New SqlParameter("@CreatedBy", SqlDbType.Int, 4)
                    parCreatedBy.Value = wkEmpId
                    cmdInsertPartID.Parameters.Add(parCreatedBy)

                    Dim parPartNo As SqlParameter = New SqlParameter("@PartNumber", SqlDbType.NVarChar, 50)
                    parPartNo.Value = dgPart.Item("CrossPN", II).Value
                    cmdInsertPartID.Parameters.Add(parPartNo)

                    Dim parPartName As SqlParameter = New SqlParameter("@PartName", SqlDbType.NVarChar, 100)
                    parPartName.Value = dgPart.Item("PartName", II).Value
                    cmdInsertPartID.Parameters.Add(parPartName)

                    Dim parCrStatus As SqlParameter = New SqlParameter("@PNCrossStatus", SqlDbType.Int, 4)
                    parCrStatus.Value = 20
                    cmdInsertPartID.Parameters.Add(parCrStatus)

                    Try
                        If cn.State = ConnectionState.Closed Then
                            cn.Open()
                        End If
                        cmdInsertPartID.ExecuteNonQuery()
                        cmdInsertPartID.Dispose()
                    Catch ex As SqlException
                        MsgBox("Add Cross Part - ID: " & ex.Message)
                    Finally
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                    End Try
                End If
            End If

        Next

    End Sub

    Sub FindNewIDForCrossParts()

        For Each Row As DataGridViewRow In dgPart.Rows

            If IsDBNull(Row.Cells("PartNumber").Value) = False Then
                Row.Cells("SwNewPartID").Value = CallClass.TakeFinalSt("cspReturnPartIDWithPartNumber", Row.Cells("PartNumber").Value)
            End If

            If IsDBNull(Row.Cells("CrossPN").Value) = False Then
                Row.Cells("SwCrossPartID").Value = CallClass.TakeFinalSt("cspReturnPartIDWithPartNumber", Row.Cells("CrossPN").Value)
            End If
        Next

        If dgPart.Rows.Count <= 0 Then
            Exit Sub
        End If

        Dim II, JJ As Integer
        JJ = dgPart.Rows.Count

        For II = 0 To JJ - 1
            Dim cmdInsertPartID As SqlCommand = New SqlCommand("cspUpdateAddRelationMasterCrossID", cn)
            cmdInsertPartID.CommandType = CommandType.StoredProcedure

            If dgPart.Item("SwCrossPartID", II).Value <> "9" Then
                If IsDBNull(dgPart.Item("SwNewPartID", II).Value) = False And IsDBNull(dgPart.Item("SwCrossPartID", II).Value) = False Then
                    Dim parPartID As SqlParameter = New SqlParameter("@CrossMasterID", SqlDbType.Int, 4)
                    parPartID.Value = dgPart.Item("SwNewPartID", II).Value
                    cmdInsertPartID.Parameters.Add(parPartID)

                    Dim parCrossID As SqlParameter = New SqlParameter("@CrossReferenceID", SqlDbType.Int, 4)
                    parCrossID.Value = dgPart.Item("SwCrossPartID", II).Value
                    cmdInsertPartID.Parameters.Add(parCrossID)

                    Try
                        If cn.State = ConnectionState.Closed Then
                            cn.Open()
                        End If
                        cmdInsertPartID.ExecuteNonQuery()
                        cmdInsertPartID.Dispose()
                    Catch ex As SqlException
                        MsgBox("Add Master Part And Cross Part - ID: " & ex.Message)
                    Finally
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If
                    End Try
                End If
            End If
        Next


    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        SaveGenMaster()
        SaveGenCrossPart()

        FindNewIDForCrossParts()

        dsMain.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        ExecuteSearch()

        Me.Refresh()
        CmdSave.Enabled = False

    End Sub

End Class