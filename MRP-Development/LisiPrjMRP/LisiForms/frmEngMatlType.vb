Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmEngMatlType

    Inherits System.Windows.Forms.Form

    Private cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daMatl As New SqlDataAdapter
    Private daDet As New SqlDataAdapter
    Private daSpec As New SqlDataAdapter

    Dim MatlCurrency As CurrencyManager
    Dim DetCurrency As CurrencyManager
    Dim SpecCurrency As CurrencyManager

    Dim rowMat As Integer = 0
    Dim rowMatDetail As Integer = 0
    Dim rowSpec As Integer = 0
    Dim rowSpecRev As Integer = 0

    Dim StrSearch As String = ""
    Dim GetInfo As String = ""
    Dim ConditionToDisable As Boolean = False

    Dim CallClass As New clsCommon

    Dim strSQL As String

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height


    Private Sub frmEngMatlType_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        CmdSave.Focus()
        dgMat.Refresh()
        dgDet.Refresh()
        dgSpec.Refresh()

        dgSpecRev.Refresh()

        CmdEdit.Focus()

        Dim reply As DialogResult

        MatlCurrency.EndCurrentEdit()
        DetCurrency.EndCurrentEdit()
        SpecCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()

        dsMain.Dispose()
        daMatl.Dispose()
        daDet.Dispose()
        daSpec.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmEngMatlType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1720 And Height > 925 Then
            Me.Width = 1720
            Me.Height = 925
        Else
            If Width < 1720 And Height < 925 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        LoadForm()
       
    End Sub

    Sub LoadForm()
        GC.Collect()
        If RoleEng(wkDeptCode) = True Or RoleNiv7(wkDeptCode) = True Then
            CmdSave.Enabled = False
            CmdEdit.Enabled = True
        Else
            CmdSave.Enabled = False
            CmdEdit.Enabled = False
        End If

        CmdReset.Enabled = True

        InitButtons()

        BuildSqlCommand()


        InitialComponents()

        SetCtlForm()

        ButtActive.Checked = True

        dsMain.Tables("tblMatlMaster").Clear()
        dsMain.Tables("tblMatlMasterDetails").Clear()
        dsMain.Tables("tblMatlMasterDetailsSpec").Clear()



        CallClass.PopulateDataAdapter("getTblMatlMasterActive").Fill(dsMain, "tblMatlMaster")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetails").Fill(dsMain, "tblMatlMasterDetails")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetailsSpec").Fill(dsMain, "tblMatlMasterDetailsSpec")

        CallClass.PopulateDataAdapter("gettblLisiSpecificationRev").Fill(dsMain, "tmpSpecRev")

        dgMat.AutoGenerateColumns = False
        dgMat.DataSource = dsMain
        dgMat.DataMember = "tblMatlMaster"

        dgDet.AutoGenerateColumns = False
        dgDet.DataSource = dsMain
        dgDet.DataMember = "tblMatlMaster.MatlDet"

        dgSpec.AutoGenerateColumns = False
        dgSpec.DataSource = dsMain
        dgSpec.DataMember = "tblMatlMaster.MatlDet.MatlDetSpec"

        dsMain.Tables("tmpSpecRev").Clear()
        dgSpecRev.AutoGenerateColumns = False
        dgSpecRev.DataSource = dsMain
        dgSpecRev.DataMember = "tmpSpecRev"

    End Sub


    Sub InitButtons()

        dgMat.ReadOnly = True
        dgDet.ReadOnly = True
        dgSpecRev.ReadOnly = True

        'dgSpec.ReadOnly = True

        CmdSave.Enabled = False

        dgSpec.Columns(2).ReadOnly = False
        dgSpec.Columns(3).ReadOnly = False

        dgSpec.Columns(4).ReadOnly = True
        dgSpec.Columns(5).ReadOnly = True
        dgSpec.Columns(6).ReadOnly = True
        dgSpec.Columns(7).ReadOnly = True
        dgSpec.Columns(8).ReadOnly = True
        dgSpec.Columns(9).ReadOnly = True

        ConditionToDisable = False

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daMatl = CallClass.PopulateDataAdapter("getTblMatlMaster")
            daDet = CallClass.PopulateDataAdapter("getTblMatlMasterDetails")
            daSpec = CallClass.PopulateDataAdapter("getTblMatlMasterDetailsSpec")

            Dim MatlBuilder As New SqlClient.SqlCommandBuilder(daMatl)
            Dim DetBuilder As New SqlClient.SqlCommandBuilder(daDet)
            Dim SpecBuilder As New SqlClient.SqlCommandBuilder(daSpec)

            daMatl.UpdateCommand = MatlBuilder.GetUpdateCommand
            daMatl.UpdateCommand.Connection = cn
            daMatl.InsertCommand = MatlBuilder.GetInsertCommand
            AddHandler daMatl.RowUpdated, AddressOf HandleRowUpdatedMatl
            daMatl.InsertCommand.Connection = cn
            daMatl.DeleteCommand = MatlBuilder.GetDeleteCommand
            daMatl.DeleteCommand.Connection = cn
            daMatl.AcceptChangesDuringFill = True
            daMatl.TableMappings.Add("Table", "tblMatlMaster")
            daMatl.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daDet.UpdateCommand = DetBuilder.GetUpdateCommand
            daDet.UpdateCommand.Connection = cn
            daDet.InsertCommand = DetBuilder.GetInsertCommand
            AddHandler daDet.RowUpdated, AddressOf HandleRowUpdatedDet
            daDet.InsertCommand.Connection = cn
            daDet.DeleteCommand = DetBuilder.GetDeleteCommand
            daDet.DeleteCommand.Connection = cn
            daDet.AcceptChangesDuringFill = True
            daDet.TableMappings.Add("Table", "tblMatlMasterDetails")
            daDet.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daSpec.UpdateCommand = SpecBuilder.GetUpdateCommand
            daSpec.UpdateCommand.Connection = cn
            daSpec.InsertCommand = SpecBuilder.GetInsertCommand
            AddHandler daSpec.RowUpdated, AddressOf HandleRowUpdatedSpec
            daSpec.InsertCommand.Connection = cn
            daSpec.DeleteCommand = SpecBuilder.GetDeleteCommand
            daSpec.DeleteCommand.Connection = cn
            daSpec.AcceptChangesDuringFill = True
            daSpec.TableMappings.Add("Table", "getTblMatlMasterDetailsSpec")
            daSpec.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedMatl(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMatlMaster").Columns("MatlID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedDet(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMatlMasterDetails").Columns("MatlDetID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedSpec(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblMatlMasterDetailsSpec").Columns("MatlSpecID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daMatl.FillSchema(dsMain, SchemaType.Source, "tblMatlMaster")
        daDet.FillSchema(dsMain, SchemaType.Source, "tblMatlMasterDetails")
        daSpec.FillSchema(dsMain, SchemaType.Source, "tblMatlMasterDetailsSpec")

        daMatl.Fill(dsMain, "tblMatlMaster")
        Dim MMatlID As DataColumn = dsMain.Tables("tblMatlMaster").Columns("MatlID")
        MMatlID.AutoIncrement = True
        MMatlID.AutoIncrementStep = -1
        MMatlID.AutoIncrementSeed = -1
        MMatlID.ReadOnly = False

        daDet.Fill(dsMain, "tblMatlMasterDetails")
        Dim MDetlID As DataColumn = dsMain.Tables("tblMatlMasterDetails").Columns("MatlDetID")
        MDetlID.AutoIncrement = True
        MDetlID.AutoIncrementStep = -1
        MDetlID.AutoIncrementSeed = -1
        MDetlID.ReadOnly = False

        daSpec.Fill(dsMain, "tblMatlMasterDetailsSpec")
        Dim MSpecID As DataColumn = dsMain.Tables("tblMatlMasterDetailsSpec").Columns("MatlSpecID")
        MSpecID.AutoIncrement = True
        MSpecID.AutoIncrementStep = -1
        MSpecID.AutoIncrementSeed = -1
        MSpecID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("MatlDet", _
                .Tables("tblMatlMaster").Columns("MatlID"), _
                .Tables("tblMatlMasterDetails").Columns("MatlID"), True)
        End With

        With dsMain
            .Relations.Add("MatlDetSpec", _
                .Tables("tblMatlMasterDetails").Columns("MatlDetID"), _
                .Tables("tblMatlMasterDetailsSpec").Columns("MatlDetID"), True)
        End With

        MatlCurrency = CType(BindingContext(dsMain, "tblMatlMaster"), CurrencyManager)
        DetCurrency = CType(BindingContext(dsMain, "tblMatlMasterDetails"), CurrencyManager)
        SpecCurrency = CType(BindingContext(dsMain, "tblMatlMasterDetailsSpec"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        With Me.MatlID
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .Visible = False
        End With

        With Me.MatlType
            .DataPropertyName = "MatlType"
            .Name = "MatlType"
        End With

        With Me.MatlFamily
            .DataPropertyName = "MatlFamily"
            .Name = "MatlFamily"
        End With

        With Me.MatlDensity
            .DataPropertyName = "MatlDensity"
            .Name = "MatlDensity"
        End With

        With Me.MatlLeadTime
            .DataPropertyName = "MatlLeadTime"
            .Name = "MatlLeadTime"
        End With

        With Me.MatlStatus
            .DataPropertyName = "MatlStatus"
            .Name = "MatlStatus"
        End With

        'dgdet

        With Me.MatlDetID
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetID"
            .Visible = False
        End With

        With Me.MatlIDDet
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .Visible = False
        End With

        With Me.MatType
            .DataPropertyName = "MatType"
            .Name = "MatType"
        End With

        With Me.MatDetKSI
            .DataPropertyName = "MatDetKSI"
            .Name = "MatDetKSI"
        End With

        With Me.MatColorCoding
            .DataPropertyName = "MatColorCoding"
            .Name = "MatColorCoding"
        End With

        With Me.MatDetSpecs
            .DataPropertyName = "MatDetSpecs"
            .Name = "MatDetSpecs"
        End With

        With Me.MatDetNotes
            .DataPropertyName = "MatDetNotes"
            .Name = "MatDetNotes"
        End With

        With Me.MatDetStatus
            .DataPropertyName = "MatDetStatus"
            .Name = "MatDetStatus"
        End With

        ' dgSpec

        With Me.MatlSpecID
            .DataPropertyName = "MatlSpecID"
            .Name = "MatlSpecID"
            .Visible = False
        End With

        With Me.MatlDetIDSpec
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetID"
            .Visible = False
        End With

        With Me.SpecID
            .DataSource = CallClass.PopulateComboBox("tblLisiSpecificationsControl", "cmbGetMatlSpecifications").Tables("tblLisiSpecificationsControl")
            .DisplayMember = "SpecNo"
            .ValueMember = "SpecID"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
            .DataPropertyName = "SpecID"
            .Name = "SpecID"
        End With

        With Me.SourceName
            .DataPropertyName = "SourceName"
            .Name = "SourceName"
        End With

        With Me.SpecType
            .DataPropertyName = "SpecType"
            .Name = "SpecType"
        End With

        With Me.SpecDescr
            .DataPropertyName = "SpecDescr"
            .Name = "SpecDescr"
        End With

        With Me.SpecNotes
            .DataPropertyName = "SpecNotes"
            .Name = "SpecNotes"
        End With

        With Me.SpecStatus
            .DataPropertyName = "SpecStatus"
            .Name = "SpecStatus"
        End With

        'dgRev

        With Me.SpecRevID
            .DataPropertyName = "SpecRevID"
            .Name = "SpecRevID"
            .Visible = False
        End With

        With Me.SpecIDRev
            .DataPropertyName = "SpecID"
            .Name = "SpecID"
            .Visible = False
        End With

        With Me.SpecRevNo
            .DataPropertyName = "SpecRevNo"
            .Name = "SpecRevNo"
        End With

        With Me.SpecRevDateIssue
            .DataPropertyName = "SpecRevDateIssue"
            .Name = "SpecRevDateIssue"
        End With

        With Me.SpecRevNotes
            .DataPropertyName = "SpecRevNotes"
            .Name = "SpecRevNotes"
        End With

        With Me.SpecRevDescr
            .DataPropertyName = "SpecRevDescr"
            .Name = "SpecRevDescr"
        End With

        With Me.SpecRevStatus
            .DataPropertyName = "SpecRevStatus"
            .Name = "SpecRevStatus"
        End With

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        CmdSave.Focus()
        dgMat.Refresh()
        dgDet.Refresh()
        CmdEdit.Focus()

        CmdSave.Enabled = False
        CmdEdit.Enabled = True
        dgMat.ReadOnly = True
        dgDet.ReadOnly = True

        dgMat.Refresh()
        dgDet.Refresh()

        MatlCurrency.EndCurrentEdit()
        DetCurrency.EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daMatl.Update(dsMain.Tables("tblMatlMaster").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                daDet.Update(dsMain.Tables("tblMatlMasterDetails").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                daSpec.Update(dsMain.Tables("tblMatlMasterDetailsSpec").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                MsgBox("Update successfully.")
                dsMain.AcceptChanges()

            End If
        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try

        dgMat.Refresh()
        dgDet.Refresh()
        dgSpec.Refresh()

        InitButtons()

    End Sub

    Private Sub dgMat_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMat.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            rowMat = e.RowIndex
        End If

        dgMat.Rows(rowMat).Selected = True

        PutdgSpec()
        PutSpecRev()

        If e.RowIndex >= 0 Then
            If dgMat.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgMat("MatlStatus", e.RowIndex).Value) = False Then
                If dgMat.Rows(e.RowIndex).Cells("MatlStatus").Value = "InActive" Then
                    MsgBox("Status Material = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Material Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgMat.Rows(e.RowIndex).Cells("MatlStatus").Value = "Active"
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgMat_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMat.DataError
        MsgBox("!!! ERROR !!!  -  " & dgMat(e.ColumnIndex, e.RowIndex).ToString)
        REM end
    End Sub

    Private Sub dgMat_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgMat.RowPrePaint
        If IsDBNull(Me.dgMat("MatlStatus", e.RowIndex).Value) = False Then
            If dgMat.Rows(e.RowIndex).Cells("MatlStatus").Value = "InActive" Then
                dgMat.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgMat.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        CmdSave.Enabled = True
        CmdEdit.Enabled = False

        dgMat.ReadOnly = False
        dgDet.ReadOnly = False

        dgSpec.Columns(2).ReadOnly = False
        dgSpec.Columns(3).ReadOnly = False

        dgSpec.Columns(4).ReadOnly = True
        dgSpec.Columns(5).ReadOnly = True
        dgSpec.Columns(6).ReadOnly = True
        dgSpec.Columns(7).ReadOnly = True
        dgSpec.Columns(8).ReadOnly = True
        dgSpec.Columns(9).ReadOnly = True

        ConditionToDisable = True

    End Sub

    Private Sub ButtActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtActive.CheckedChanged

        dsMain.Tables("tblMatlMaster").Clear()
        dsMain.Tables("tblMatlMasterDetails").Clear()
        dsMain.Tables("tblMatlMasterDetailsSpec").Clear()

        CallClass.PopulateDataAdapter("getTblMatlMasterActive").Fill(dsMain, "tblMatlMaster")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetails").Fill(dsMain, "tblMatlMasterDetails")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetailsSpec").Fill(dsMain, "tblMatlMasterDetailsSpec")

        dgMat.AutoGenerateColumns = False
        dgMat.DataSource = dsMain
        dgMat.DataMember = "tblMatlMaster"

        dgDet.AutoGenerateColumns = False
        dgDet.DataSource = dsMain
        dgDet.DataMember = "tblMatlMaster.MatlDet"

        dgSpec.AutoGenerateColumns = False
        dgSpec.DataSource = dsMain
        dgSpec.DataMember = "tblMatlMaster.MatlDet.MatlDetSpec"

    End Sub

    Private Sub ButtAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtAll.CheckedChanged

        dsMain.Tables("tblMatlMaster").Clear()
        dsMain.Tables("tblMatlMasterDetails").Clear()

        CallClass.PopulateDataAdapter("getTblMatlMaster").Fill(dsMain, "tblMatlMaster")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetails").Fill(dsMain, "tblMatlMasterDetails")
        CallClass.PopulateDataAdapter("getTblMatlMasterDetailsSpec").Fill(dsMain, "tblMatlMasterDetailsSpec")

        dgMat.AutoGenerateColumns = False
        dgMat.DataSource = dsMain
        dgMat.DataMember = "tblMatlMaster"

        dgDet.AutoGenerateColumns = False
        dgDet.DataSource = dsMain
        dgDet.DataMember = "tblMatlMaster.MatlDet"

        dgSpec.AutoGenerateColumns = False
        dgSpec.DataSource = dsMain
        dgSpec.DataMember = "tblMatlMaster.MatlDet.MatlDetSpec"

    End Sub

    Private Sub dgDet_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDet.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            rowMatDetail = e.RowIndex
        End If

        dgDet.Rows(rowMatDetail).Selected = True

        PutdgSpec()
        PutSpecRev()

        If e.RowIndex >= 0 Then
            If dgDet.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgDet("MatDetStatus", e.RowIndex).Value) = False Then
                If dgDet.Rows(e.RowIndex).Cells("MatDetStatus").Value = "InActive" Then
                    MsgBox("Status Material Detail = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Material Detail Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgDet.Rows(e.RowIndex).Cells("MatDetStatus").Value = "Active"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgDet_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDet.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            rowMatDetail = e.RowIndex
        End If

        If IsDBNull(Me.dgDet("MatDetStatus", e.RowIndex).Value) = True Then
            dgDet.Rows(e.RowIndex).Cells("MatDetStatus").Value = "Active"
        End If

    End Sub

    Private Sub dgDet_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgDet.CellEnter

        If e.RowIndex < 0 Then
            Return
        Else
            rowMatDetail = e.RowIndex
        End If

    End Sub

    Private Sub dgDet_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDet.DataError
        REM end
    End Sub

    Private Sub dgDet_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgDet.RowPrePaint
        If IsDBNull(Me.dgDet("MatDetStatus", e.RowIndex).Value) = False Then
            If dgDet.Rows(e.RowIndex).Cells("MatDetStatus").Value = "InActive" Then
                dgDet.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgDet.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Function RoleEng(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "ENG" Then
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

    Function RoleNiv7(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RMNIV7" Then
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

    Private Sub dgSpec_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgSpec.CellBeginEdit

        If e.RowIndex < 0 Then
            Return
        Else
            rowSpec = e.RowIndex
        End If

    End Sub

    Private Sub dgSpec_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpec.CellClick

        If e.RowIndex < 0 Then
            Return
        Else
            rowSpec = e.RowIndex
        End If

        PutdgSpec()
        PutSpecRev()

        Select Case e.ColumnIndex
            Case 2              ' assign spec

                If dgSpec.Rows(rowSpec).Cells("SwAdd").Value <> "False" Then
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to assign a new Spec No.?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgSpec.Columns(4).ReadOnly = False
                    End If
                End If

            Case 3              ' remove line

                If dgSpec.Rows(rowSpec).Cells("SwRemove").Value <> "False" Then
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to remove this line?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgSpec.Rows(rowSpec).Selected = True

                        Try
                            dgSpec.Rows.RemoveAt(rowSpec)
                            dgSpec.Refresh()
                        Catch ex As Exception
                        End Try

                    End If
                End If

            Case 4
                If dgSpec.Rows(rowSpec).Cells("SwAdd").Value = "False" Then
                    MsgBox("Please click on EDIT to turn On - Enable Editing")
                End If

        End Select

    End Sub

    Sub PutdgSpec()

        If dgSpec.RowCount < 0 Then
            Exit Sub
        End If

        For I As Integer = 0 To (dgSpec.Rows.Count - 1)

            StrSearch = Nz.Nz(dgSpec("SpecID", I).Value)

            GetInfo = CallClass.ReturnStrWithParInt("cspReturnSpecSourceBySpecID", StrSearch)
            If GetInfo <> "False" Then
                dgSpec("SourceName", I).Value = GetInfo
            End If

            GetInfo = CallClass.ReturnStrWithParInt("cspReturnSpecTypeBySpecID", StrSearch)
            If GetInfo <> "False" Then
                dgSpec("SpecType", I).Value = GetInfo
            End If

            GetInfo = CallClass.ReturnStrWithParInt("cspReturnSpecDescrBySpecID", StrSearch)
            If GetInfo <> "False" Then
                dgSpec("SpecDescr", I).Value = GetInfo
            End If

            GetInfo = CallClass.ReturnStrWithParInt("cspReturnSpecNotesBySpecID", StrSearch)
            If GetInfo <> "False" Then
                dgSpec("SpecNotes", I).Value = GetInfo
            End If

            GetInfo = CallClass.ReturnStrWithParInt("cspReturnSpecStatusBySpecID", StrSearch)
            If GetInfo <> "False" Then
                dgSpec("SpecStatus", I).Value = GetInfo
            End If

        Next I

    End Sub

    Sub PutSpecRev()

        dsMain.Tables("tmpSpecRev").Clear()
        dgSpecRev.Refresh()

        If dgSpec.RowCount <= 0 Then
            Exit Sub
        End If

        If IsDBNull(dgSpec.Rows(rowSpec).Cells("SpecID").Value) = True Then
            Exit Sub
        End If

        If IsNothing(dgSpec.Rows(rowSpec).Cells("SpecID").Value) = True Then
            Exit Sub
        End If

        StrSearch = Nz.Nz(dgSpec("SpecID", rowSpec).Value)
        If StrSearch > 0 Then
            CallClass.PopulateDataAdapterAfterSearch("getSpecRevisionsWithSpecID", StrSearch).Fill(dsMain, "tmpSpecRev")

            dgSpecRev.AutoGenerateColumns = False
            dgSpecRev.DataSource = dsMain
            dgSpecRev.DataMember = "tmpSpecRev"
        End If

        dgSpecRev.Refresh()

    End Sub

    Private Sub dgSpec_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpec.CellEndEdit

        If e.RowIndex < 0 Then
            Return
        Else
            rowSpec = e.RowIndex
        End If

        Select Case e.ColumnIndex

            Case 4
                If dgSpec.Rows(rowSpec).Cells("SwAdd").Value = "False" Then
                    MsgBox("Please click on EDIT to turn On - Enable Editing")
                Else
                    dgSpec("MatlDetID", e.RowIndex).Value = dgDet.Rows(rowMatDetail).Cells("MatlDetID").Value
                    PutdgSpec()
                End If
        End Select

    End Sub

    Private Sub dgSpec_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpec.CellEnter

        If e.RowIndex < 0 Then
            Return
        Else
            rowSpec = e.RowIndex
        End If

        Dim cell As New DataGridViewTextBoxCell                 'Replace the ButtonCell for a TextCell'
        Dim cell1 As New DataGridViewTextBoxCell

        If ConditionToDisable = False Then

            If dgSpec.Rows(rowSpec).Cells("SwAdd").Value = "False" Then
                Exit Sub
            Else
                cell.Value = "False"                                    'Set the value again'
                cell1.Value = "False"

                dgSpec.Rows(rowSpec).Cells("SwAdd") = cell              'Override the cell'
                dgSpec.Rows(rowSpec).Cells("SwRemove") = cell1          'Override the cell'
            End If
        Else
            If dgSpec.Rows(rowSpec).Cells("SwAdd").Value = "False" Then
                cell.Value = ""                                         'Set the value again'
                cell1.Value = ""

                dgSpec.Rows(rowSpec).Cells("SwAdd") = cell              'Override the cell'
                dgSpec.Rows(rowSpec).Cells("SwRemove") = cell1          'Override the cell'
            End If
        End If

    End Sub

    Private Sub dgSpec_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSpec.DataError
        REM end
    End Sub

    Private Sub dgSpecRev_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSpecRev.DataError
        REM end
    End Sub

    Private Sub CmdReset_Click(sender As Object, e As EventArgs) Handles CmdReset.Click

        Dim reply As DialogResult

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then
                LoadForm()
            End If
        End If

    End Sub

    Private Sub frmEngMatlType_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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

End Class

