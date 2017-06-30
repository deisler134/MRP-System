Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmCostEstimation

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daCost As New SqlDataAdapter
    Private daQty As New SqlDataAdapter
    'Dim da As New SqlDataAdapter

    Dim CostCurrency As CurrencyManager
    Dim QtyCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim intCost As Integer

    Dim SwVal As Boolean
    Dim StrSql As String

    Private Sub frmCostEstimation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        CostCurrency.EndCurrentEdit()
        QtyCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If
        dsMain.RejectChanges()
        dsMain.Dispose()
        daCost.Dispose()
        daQty.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmCostEstimation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DisableScreen()
        DisableButton()

        BuildSqlCommand()

        InitialComponents()

        SetPartHeader()

        SetDataCtl()

        BindComponents()

        CmdNew.Enabled = True
        CmdReset.Enabled = True
        CmdEdit.Enabled = True
        CmdSave.Enabled = False

        txtPartDate.Text = Now.ToShortDateString
    End Sub

    Sub DisableScreen()
        txtPartDate.ReadOnly = True     'only
        CmbUser.Enabled = False         'only
        CmbPartHeader.Enabled = True

        CmbPart.Enabled = False
        CmbDwgSource.Enabled = False
        txtPartName.ReadOnly = True
        txtDescrCode.ReadOnly = True
        txtPartLength.ReadOnly = True
        txtPartDia.ReadOnly = True
        txtCostDate.ReadOnly = True
        CmbDevise.Enabled = False

        CmbNasMs.Enabled = False
        txtNasLength.ReadOnly = True
        txtNasDia.ReadOnly = True
        CmbRev.Enabled = False
        CmbMfg.Enabled = False

        CmdSeeMat.Enabled = False
        CmbMatType.Enabled = False
        txtDensity.ReadOnly = True
        txtWeight.ReadOnly = True

        txtNotes.ReadOnly = True

        dgQty.ReadOnly = True
        dgQty.Visible = False

        txtPartName.Text = DBNull.Value.ToString
        txtDescrCode.Text = DBNull.Value.ToString
        txtPartLength.Text = DBNull.Value.ToString
        txtPartDia.Text = DBNull.Value.ToString
        txtNasLength.Text = DBNull.Value.ToString
        txtNasDia.Text = DBNull.Value.ToString

    End Sub

    Sub EnableScreen()
        txtPartDate.ReadOnly = True     'only
        CmbUser.Enabled = False         'only
        CmbPartHeader.Enabled = False

        CmbPart.Enabled = True
        CmbDwgSource.Enabled = False
        txtPartName.ReadOnly = True
        txtDescrCode.ReadOnly = True
        txtPartLength.ReadOnly = True
        txtPartDia.ReadOnly = True
        txtCostDate.ReadOnly = True
        CmbDevise.Enabled = True

        CmbNasMs.Enabled = False
        txtNasLength.ReadOnly = True
        txtNasDia.ReadOnly = True
        CmbRev.Enabled = False
        CmbMfg.Enabled = False

        CmdSeeMat.Enabled = True
        CmbMatType.Enabled = True
        txtDensity.ReadOnly = True
        txtWeight.ReadOnly = False

        txtNotes.ReadOnly = False

        dgQty.ReadOnly = False
        dgQty.Visible = True

    End Sub

    Sub DisableButton()
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdSeePart.Enabled = True
    End Sub

    Private Sub CmdSeePart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeePart.Click
        frmPartMaster.ShowDialog()
    End Sub


    Private Function BuildSqlCommand() As Boolean

        Try
            daCost = CallClass.PopulateDataAdapter("getTblCostEstimation")

            Dim CostBuilder As New SqlClient.SqlCommandBuilder(daCost)

            daCost.UpdateCommand = CostBuilder.GetUpdateCommand
            daCost.UpdateCommand.Connection = cn
            daCost.InsertCommand = CostBuilder.GetInsertCommand
            AddHandler daCost.RowUpdated, AddressOf HandleRowUpdatedCostEst
            daCost.InsertCommand.Connection = cn
            daCost.DeleteCommand = CostBuilder.GetDeleteCommand
            daCost.DeleteCommand.Connection = cn
            daCost.AcceptChangesDuringFill = True
            daCost.TableMappings.Add("Table", "tblCostEstimation")
            daCost.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daQty = CallClass.PopulateDataAdapter("getTblCostEstimationQty")

            Dim QtytBuilder As New SqlClient.SqlCommandBuilder(daQty)

            daQty.UpdateCommand = QtytBuilder.GetUpdateCommand
            daQty.UpdateCommand.Connection = cn
            daQty.InsertCommand = QtytBuilder.GetInsertCommand
            AddHandler daQty.RowUpdated, AddressOf HandleRowUpdatedQty
            daQty.InsertCommand.Connection = cn
            daQty.DeleteCommand = QtytBuilder.GetDeleteCommand
            daQty.DeleteCommand.Connection = cn
            daQty.AcceptChangesDuringFill = True
            daQty.TableMappings.Add("Table", "tblCostEstimationQty")
            daQty.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedCostEst(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCostEstimation").Columns("CostID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedQty(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblCostEstimationQty").Columns("CostQtyID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daCost.FillSchema(dsMain, SchemaType.Source, "tblCostEstimation")

        daCost.Fill(dsMain, "tblCostEstimation")
        Dim MastID As DataColumn = dsMain.Tables("tblCostEstimation").Columns("CostID")
        MastID.AutoIncrement = True
        MastID.AutoIncrementStep = -1
        MastID.AutoIncrementSeed = -1
        MastID.ReadOnly = False

        daQty.FillSchema(dsMain, SchemaType.Source, "tblCostEstimationQty")

        daQty.Fill(dsMain, "tblCostEstimationQty")
        Dim QtyID As DataColumn = dsMain.Tables("tblCostEstimationQty").Columns("CostQtyID")
        QtyID.AutoIncrement = True
        QtyID.AutoIncrementStep = -1
        QtyID.AutoIncrementSeed = -1
        QtyID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("RelQty", _
                .Tables("tblCostEstimation").Columns("CostID"), _
                .Tables("tblCostEstimationQty").Columns("CostID"), True)
        End With

        CostCurrency = CType(BindingContext(dsMain, "tblCostEstimation"), CurrencyManager)
        QtyCurrency = CType(BindingContext(dsMain, "tblCostEstimationQty"), CurrencyManager)

    End Sub

    Sub SetPartHeader()

        CmbPartHeader.DataSource = Nothing
        CmbPartHeader.Items.Clear()

        StrSql = "SELECT tblCostEstimation.PartID, tblPartMaster.PartNumber " & _
        "FROM tblCostEstimation LEFT OUTER JOIN tblPartMaster ON tblCostEstimation.PartID =  tblPartMaster.PartID" & _
        " ORDER BY tblPartMaster.PartNumber"
        Try
            Dim cmd As SqlCommand = New SqlCommand(StrSql, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblCostEstimation")

            With CmbPartHeader
                .DataSource = ds.Tables("tblCostEstimation")
                .DisplayMember = "PartNumber"
                .ValueMember = "PartID"
                .SelectedIndex = -1
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - CmbPartHeader  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


    Sub SetDataCtl()


        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
        End With

        PutCmbPart()

        PutCmbDwgSource()

        PutMatlType()

        ' dgQty datagridview  update

        With DataGridViewTextBoxColumn1
            .DataPropertyName = "CostQtyID"
            .Name = "CostQtyID"
        End With

        With DataGridViewTextBoxColumn2
            .DataPropertyName = "CostID"
            .Name = "CostID"
        End With

        With DataGridViewTextBoxColumn3
            .DataPropertyName = "QtyItem"
            .Name = "QtyItem"
        End With

        With DataGridViewTextBoxColumn4
            .DataPropertyName = "CostQty"
            .Name = "CostQty"
        End With

        With DataGridViewTextBoxColumn5
            .DataPropertyName = "CostPrice"
            .Name = "CostPrice"
        End With

        With DataGridViewTextBoxColumn6
            .DataPropertyName = "Value"
            .Name = "Value"
        End With

        With DataGridViewTextBoxColumn10
            .DataPropertyName = "CostEstTime"
            .Name = "CostEstTime"
        End With

        With DataGridViewTextBoxColumn11
            .DataPropertyName = "CostQtyNotes"
            .Name = "CostQtyNotes"
        End With

        dgQty.AutoGenerateColumns = False
        dgQty.DataSource = dsMain
        dgQty.DataMember = "tblCostEstimation.RelQty"
        CalculGrid()
    End Sub

    Sub PutCmbDwgSource()
        With Me.CmbDwgSource
            .DataSource = CallClass.PopulateComboBox("tblPartDWGSource", "gettblPartDwgSource").Tables("tblPartDWGSource")
            .DisplayMember = "SourceName"
            .ValueMember = "DwgSourceID"
        End With

    End Sub

    Sub PutCmbPart()
        With Me.CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "gettblPartMaster").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .SelectedIndex = -1
        End With
    End Sub
    Sub PutMatlType()

        CmbMatType.DataSource = Nothing
        CmbMatType.Items.Clear()

        StrSql = "SELECT MatlID, MatlType, MatlFamily FROM tblMatlMaster ORDER BY MatlType"
        Try
            Dim cmd As SqlCommand = New SqlCommand(StrSql, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblMatlMaster")

            ds.Tables("tblMatlMaster").Columns.Add _
            ("FullText", System.Type.GetType("System.String"), "MatlType + '   ---   ' +  MatlFamily")

            With CmbMatType
                .DataSource = ds.Tables("tblMatlMaster")
                .DisplayMember = "FullText"
                .ValueMember = "MatlID"
                .SelectedIndex = -1
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - PutMatlType  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Sub BindComponents()

        CmbPart.DataBindings.Clear()
        CmbDwgSource.DataBindings.Clear()
        CmbRev.DataBindings.Clear()
        CmbMfg.DataBindings.Clear()
        txtCostDate.DataBindings.Clear()
        CmbDevise.DataBindings.Clear()
        CmbNasMs.DataBindings.Clear()
        CmbMatType.DataBindings.Clear()
        txtWeight.DataBindings.Clear()
        txtNotes.DataBindings.Clear()

        CmbPart.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.PartID")
        CmbDwgSource.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.CustID")
        CmbRev.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.RevID")
        CmbMfg.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.MfgID")
        txtCostDate.DataBindings.Add("Text", dsMain, "tblCostEstimation.CostDate")
        CmbDevise.DataBindings.Add("Text", dsMain, "tblCostEstimation.CostExch")
        CmbNasMs.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.NasMsID")
        CmbMatType.DataBindings.Add("SelectedValue", dsMain, "tblCostEstimation.MatID")
        txtWeight.DataBindings.Add("Text", dsMain, "tblCostEstimation.CostWeight")
        txtNotes.DataBindings.Add("Text", dsMain, "tblCostEstimation.CostNotes")

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        dsMain.RejectChanges()
        dgQty.Refresh()

        CostCurrency.EndCurrentEdit()
        CostCurrency.AddNew()

        Call EnableScreen()
        Call InitValue()
    End Sub

    Sub InitValue()

        txtPartDate.Text = Now.ToShortDateString
        txtCostDate.Text = Now.ToShortDateString
        CmbDevise.Text = "USD"
        txtPartLength.Text = 0
        txtPartDia.Text = 0
        txtDensity.Text = 0
        txtNasLength.Text = 0
        txtNasDia.Text = 0

    End Sub

    Private Sub CmdSeeMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeeMat.Click
        frmEngMatlType.ShowDialog()
    End Sub

    Private Sub CmbPart_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPart.DropDownClosed

        PutCmbPartNumber()
    End Sub

    Private Sub CmbNasMs_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbNasMs.DropDownClosed
        PutCmbNasMs()
    End Sub

    Sub PutCmbPartNumber()

        'If CmbPartHeader.SelectedIndex = -1 Then
        'Exit Sub
        'End If

        txtNasLength.Text = ""
        txtNasDia.Text = ""
        CmbNasMs.SelectedIndex = -1

        If CmbPart.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim index As String = CmbPart.SelectedValue.ToString

        StrSql = "SELECT PartID, PartName, PartDescCode, PartLength, PartDia, CustSourceID FROM tblPartMaster WHERE (PartID = '" & index & "')"
        Dim mySqlComm As New Data.SqlClient.SqlCommand(StrSql, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                'MessageBox.Show("!!! ERROR DATABASE!!!! Part Number cannot be generated.")

                myReader.Close()
                myReader.Dispose()
            Else
                While myReader.Read()
                    txtPartName.Text = Nz.Nz(myReader.GetValue(1))
                    txtDescrCode.Text = Nz.Nz(myReader.GetValue(2))
                    txtPartLength.Text = Nz.Nz(myReader.GetValue(3))
                    txtPartDia.Text = Nz.Nz(myReader.GetValue(4))
                    CmbDwgSource.SelectedValue = Nz.Nz(myReader.GetValue(5))

                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - CmbPart_DropDownClosed  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

        '   put revision

        CmbRev.DataSource = Nothing
        CmbRev.Items.Clear()

        StrSql = "SELECT * FROM tblPartRev WHERE (PartID = '" & index & "') ORDER BY PartRevID DESC"

        Try
            Dim cmd As SqlCommand = New SqlCommand(StrSql, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblPartRev")
            With CmbRev
                .DataSource = ds.Tables("tblPartRev")
                .DisplayMember = "RevNo"
                .ValueMember = "PartRevID"
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch ex As Exception

        End Try

        '   put mfg specification

        CmbMfg.DataSource = Nothing
        CmbMfg.Items.Clear()

        StrSql = "SELECT * FROM tblPartMfgSpec WHERE (PartID = '" & index & "') ORDER BY MfgSpecID DESC"

        Try
            Dim cmd As SqlCommand = New SqlCommand(StrSql, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblPartMfgSpec")
            With CmbMfg
                .DataSource = ds.Tables("tblPartMfgSpec")
                .DisplayMember = "MfgSpec"
                .ValueMember = "MfgSpecID"
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
        Catch ex As Exception

        End Try

        ' nasms if exist

        CmbNasMs.DataSource = Nothing
        CmbNasMs.Items.Clear()

        StrSql = "SELECT * FROM tblPartNasMs WHERE (PartID = '" & index & "') ORDER BY NasMsPartNo ASC"

        Try
            Dim cmd As SqlCommand = New SqlCommand(StrSql, cn)
            Dim da As SqlDataAdapter = New SqlDataAdapter()
            Dim ds As New DataSet
            da.SelectCommand = cmd
            da.Fill(ds, "tblPartNasMs")
            With CmbNasMs
                .DataSource = ds.Tables("tblPartNasMs")
                .DisplayMember = "NasMsPartNo"
                .ValueMember = "NasMsID"
            End With
            da.Dispose()
            ds.Dispose()
            cmd.Dispose()
            CmbNasMs.Enabled = True

            PutCmbNasMs()

        Catch ex As Exception

        End Try
    End Sub

    Sub PutCmbNasMs()

        If CmbNasMs.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim IndexPart As String = CmbPart.SelectedValue.ToString
        Dim IndexNas As String = CmbNasMs.SelectedValue.ToString

        StrSql = "SELECT PartID, NasMsLength, NasMsDia FROM tblPartNasMs WHERE (PartID = '" & IndexPart & "')" & _
        " AND (NasMsID = '" & IndexNas & "')"

        Dim mySqlComm As New Data.SqlClient.SqlCommand(StrSql, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                myReader.Close()
                myReader.Dispose()
            Else
                While myReader.Read()
                    txtNasLength.Text = Nz.Nz(myReader.GetValue(1))
                    txtNasDia.Text = Nz.Nz(myReader.GetValue(2))
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - CmbNasMs_DropDownClosed  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub CmbMatType_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMatType.DropDownClosed

        Dim index As String = CmbMatType.SelectedValue.ToString

        If CmbMatType.SelectedIndex = -1 Then
            Exit Sub
        End If

        StrSql = "SELECT MatlID, MatlDensity, MatlCoef FROM tblMatlMaster WHERE (MatlID = '" & index & "')"
        Dim mySqlComm As New Data.SqlClient.SqlCommand(StrSql, cn)
        Dim myReader As Data.SqlClient.SqlDataReader

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            myReader = mySqlComm.ExecuteReader()

            Dim TestRec As Int16
            TestRec = myReader.HasRows
            If TestRec <> -1 Then
                myReader.Close()
                myReader.Dispose()
            Else
                While myReader.Read()
                    txtDensity.Text = Nz.Nz(myReader.GetValue(1))
                    CalculWeight()
                End While
                myReader.Close()
                myReader.Dispose()
            End If

        Catch xcp As SqlException
            MessageBox.Show(xcp.Message, "SQL Error - CmbMatType_DropDownClosed  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True

        CmbPartHeader.Enabled = False
        Call EnableScreen()
    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        dsMain.RejectChanges()
        DisableScreen()

        CmdNew.Enabled = True
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Call ValPo()

        If SwVal = True Then
            DisableButton()
            DisableScreen()

            CostCurrency.EndCurrentEdit()
            QtyCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daCost.Update(dsMain.Tables("tblCostEstimation").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daQty.Update(dsMain.Tables("tblCostEstimationQty").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    daCost.Update(dsMain.Tables("tblCostEstimation").Select("", "", DataViewRowState.Deleted))
                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgQty.Refresh()

            dsMain.AcceptChanges()
        End If

    End Sub

    Sub ValPo()

        If Len(Trim(CmbPart.SelectedValue)) = 0 Or IsDBNull(CmbPart.SelectedValue) = True Or IsNothing(CmbPart.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Part Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbDwgSource.SelectedValue)) = 0 Or IsDBNull(CmbDwgSource.SelectedValue) = True Or IsNothing(CmbDwgSource.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Dwg Source is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbRev.SelectedValue)) = 0 Or IsDBNull(CmbRev.SelectedValue) = True Or IsNothing(CmbRev.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Part Number Revision is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbMfg.SelectedValue)) = 0 Or IsDBNull(CmbMfg.SelectedValue) = True Or IsNothing(CmbMfg.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Mfg Specification is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbMatType.SelectedValue)) = 0 Or IsDBNull(CmbMatType.SelectedValue) = True Or IsNothing(CmbMatType.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Material Type is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtWeight.Text)) = 0 Or IsDBNull(txtWeight.Text) = True Then
            MsgBox("!!! ERROR !!! Weight is Empty.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Sub CalculWeight()
        ' formula  .7854 * Dia2 * L * Density
        If Len(Trim(CmbNasMs.SelectedValue)) = 0 Or IsDBNull(CmbNasMs.SelectedValue) = True Or IsNothing(CmbNasMs.SelectedValue) = True Then
            txtWeight.Text = 0.7854 * (Nz.Nz(txtPartDia.Text) * _
                            Nz.Nz(txtPartDia.Text) * _
                            Nz.Nz(txtPartLength.Text) * _
                            Nz.Nz(txtDensity.Text))
        Else
            txtWeight.Text = 0.7854 * (Nz.Nz(txtNasDia.Text) * _
                            Nz.Nz(txtNasDia.Text) * _
                            Nz.Nz(txtNasLength.Text) * _
                            Nz.Nz(txtDensity.Text))
        End If
    End Sub

    Private Sub CmbPartHeader_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPartHeader.GotFocus
        SetPartHeader()
    End Sub

    Private Sub CmbPartHeader_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPartHeader.SelectedIndexChanged
        Me.BindingContext(dsMain, "tblCostEstimation").Position = CType(CmbPartHeader.SelectedIndex, String)
        PutCmbPartNumber()
        CmdEdit.Enabled = True
        dgQty.Visible = True
        dgQty.ReadOnly = True
        CalculGrid()
    End Sub

    Private Sub dgQty_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgQty.CellClick
        Call CalculGrid()
    End Sub

    Sub CalculGrid()

        If dgQty.Rows.Count > 0 Then
            Dim I As Integer = 0
            For I = 0 To dgQty.Rows.Count - 1
                If IsDBNull(Me.dgQty("CostQty", I).Value) = False And _
                    IsDBNull(Me.dgQty("CostPrice", I).Value) = False Then
                    Me.dgQty("Value", I).Value = Me.dgQty("CostQty", I).Value * Me.dgQty("CostPrice", I).Value
                End If
            Next
        End If

    End Sub

    Private Sub CmbPart_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPart.GotFocus
        PutCmbPart()
    End Sub

    Private Sub CmbMatType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMatType.GotFocus
        PutMatlType()
    End Sub

End Class