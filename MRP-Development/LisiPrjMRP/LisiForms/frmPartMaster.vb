Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmPartMaster

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daPart As New SqlDataAdapter
    Private daMfgDwgNo As New SqlDataAdapter
    Private daRev As New SqlDataAdapter
    Private daMfg As New SqlDataAdapter
    Private daProc As New SqlDataAdapter
    Private daMat As New SqlDataAdapter
    Private daAssy As New SqlDataAdapter
    Private daFromBlanks As New SqlDataAdapter
    Private daPartsList As New SqlDataAdapter
    Private daRef As New SqlDataAdapter
    'Private daCross As New SqlDataAdapter

    Dim PartCurrency As CurrencyManager
    Dim MfgDwgNoCurrency As CurrencyManager
    Dim RevCurrency As CurrencyManager
    Dim MfgCurrency As CurrencyManager
    Dim ProcCurrency As CurrencyManager
    Dim MatCurrency As CurrencyManager
    Dim AssyCurrency As CurrencyManager
    Dim BlanksCurrency As CurrencyManager
    Dim PartListCurrency As CurrencyManager
    Dim PartRefCurrency As CurrencyManager
    'Dim PartCrossCurrency As CurrencyManager

    Dim CallClass As New clsCommon
    Dim RowdgMat As Integer = 0
    Dim RowdgProc As Integer = 0
    Dim RowMpo As Integer = 0
    Dim RowFromBlank As Integer = 0
    Dim RowPartsList As Integer = 0
    Dim RowCross As Integer = 0

    Dim OldQtyEng As String
    Dim OldQtyReq As String
    Dim OldDept As String

    Dim KeepNo As Integer = 0
    Dim SwVal As Boolean
    Dim SwProcType As Integer = 0

    Dim Pages4 As TabPage
    Dim Pages8 As TabPage
    Dim Pages7 As TabPage
    Dim Pages9 As TabPage

    Dim Index4 As Integer = 0
    Dim Index8 As Integer = 0
    Dim Index7 As Integer = 0
    Dim Index9 As Integer = 0
    Dim Index12 As Integer = 0

    Private Property Pages12 As TabPage

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmPartMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        PartCurrency.EndCurrentEdit()
        MfgDwgNoCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()
        MfgCurrency.EndCurrentEdit()
        ProcCurrency.EndCurrentEdit()
        MatCurrency.EndCurrentEdit()
        AssyCurrency.EndCurrentEdit()
        BlanksCurrency.EndCurrentEdit()
        PartListCurrency.EndCurrentEdit()
        PartRefCurrency.EndCurrentEdit()
        'PartCrossCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daPart.Dispose()
        daMfgDwgNo.Dispose()
        daRev.Dispose()
        daMfg.Dispose()
        daProc.Dispose()
        daMat.Dispose()
        daAssy.Dispose()
        daFromBlanks.Dispose()
        daPartsList.Dispose()
        daRef.Dispose()
        'daCross.Dispose()

        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmPartMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1600 And Height > 950 Then
            Me.Width = 1600
            Me.Height = 950
        Else
            If Width < 1600 And Height < 950 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        'keep tabpages for component and blanks
        Index4 = TabControl1.TabPages.IndexOf(TabPage4)
        Index8 = TabControl1.TabPages.IndexOf(TabPage8)
        Index7 = TabControl1.TabPages.IndexOf(TabPage7)
        Index9 = TabControl1.TabPages.IndexOf(TabPage9)
        Index12 = TabControl1.TabPages.IndexOf(TabPage12)

        Pages4 = Me.TabControl1.TabPages(Index4)
        Pages8 = Me.TabControl1.TabPages(Index8)
        Pages7 = Me.TabControl1.TabPages(Index7)
        Pages9 = Me.TabControl1.TabPages(Index9)
        Pages12 = Me.TabControl1.TabPages(Index12)

        HideControls()

        DisableScreen()

        DisableButton()

        BuildSqlCommand()

        InitialComponents()

        SetDataCtl()

        BindComponents()

        CmdNew.Enabled = True
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True
        CmdEdit.Enabled = True

        txtPartDate.Text = Now.ToShortDateString

        CalculMpoValue()
        CalculActRelOrd()

        SwProcType = 0

    End Sub

    Sub HideControls()

        lblPrefix.Visible = False
        lblDia.Visible = False
        lblLength.Visible = False

        txtPrefix.Text = ""
        txtDia.Text = ""
        txtLength.Text = ""

        txtPrefix.Visible = False
        txtDia.Visible = False
        txtLength.Visible = False

        CmdExec.Visible = False

    End Sub

    Sub ShowControlsBlanks()

        lblPrefix.Visible = True
        lblDia.Visible = True
        lblLength.Visible = True

        txtPrefix.Visible = True
        txtDia.Visible = True
        txtLength.Visible = True

        CmdExec.Visible = True

    End Sub

    Private Function BuildSqlCommand() As Boolean

        Try
            daPart = CallClass.PopulateDataAdapter("getTblPartMaster")
            daMfgDwgNo = CallClass.PopulateDataAdapter("gettblPartMfgDwgNo")
            daRev = CallClass.PopulateDataAdapter("getTblPartRev")
            daMfg = CallClass.PopulateDataAdapter("getTblPartMfgSpec")
            daProc = CallClass.PopulateDataAdapter("gettblPartProc")
            daMat = CallClass.PopulateDataAdapter("gettblPartMatlPref")
            daAssy = CallClass.PopulateDataAdapter("gettblPartAssyComponents")
            daFromBlanks = CallClass.PopulateDataAdapter("gettblPartRelationBlank")
            daPartsList = CallClass.PopulateDataAdapter("gettblPartRelationBlank")
            daRef = CallClass.PopulateDataAdapter("gettblPartReference")
            'daCross = CallClass.PopulateDataAdapter("gettblPartCrossPN")

            Dim PartBuilder As New SqlClient.SqlCommandBuilder(daPart)
            Dim MfgDwgNoBuilder As New SqlClient.SqlCommandBuilder(daMfgDwgNo)
            Dim RevBuilder As New SqlClient.SqlCommandBuilder(daRev)
            Dim MfgBuilder As New SqlClient.SqlCommandBuilder(daMfg)
            Dim ProcBuilder As New SqlClient.SqlCommandBuilder(daProc)
            Dim MatlBuilder As New SqlClient.SqlCommandBuilder(daMat)
            Dim AssyBuilder As New SqlClient.SqlCommandBuilder(daAssy)
            Dim BlanksBuilder As New SqlClient.SqlCommandBuilder(daFromBlanks)
            Dim PartListBuilder As New SqlClient.SqlCommandBuilder(daPartsList)
            Dim PartRefBuilder As New SqlClient.SqlCommandBuilder(daRef)
            'Dim PartCrossBuilder As New SqlClient.SqlCommandBuilder(daCross)

            daPart.UpdateCommand = PartBuilder.GetUpdateCommand
            daPart.UpdateCommand.Connection = cn
            daPart.InsertCommand = PartBuilder.GetInsertCommand
            AddHandler daPart.RowUpdated, AddressOf HandleRowUpdatedPartMast
            daPart.InsertCommand.Connection = cn
            daPart.DeleteCommand = PartBuilder.GetDeleteCommand
            daPart.DeleteCommand.Connection = cn
            daPart.AcceptChangesDuringFill = True
            daPart.TableMappings.Add("Table", "tblPartMaster")
            daPart.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daMfgDwgNo.UpdateCommand = MfgDwgNoBuilder.GetUpdateCommand
            daMfgDwgNo.UpdateCommand.Connection = cn
            daMfgDwgNo.InsertCommand = MfgDwgNoBuilder.GetInsertCommand
            AddHandler daMfgDwgNo.RowUpdated, AddressOf HandleRowUpdatedMfgDwgNo
            daMfgDwgNo.InsertCommand.Connection = cn
            daMfgDwgNo.DeleteCommand = MfgDwgNoBuilder.GetDeleteCommand
            daMfgDwgNo.DeleteCommand.Connection = cn
            daMfgDwgNo.AcceptChangesDuringFill = True
            daMfgDwgNo.TableMappings.Add("Table", "tblPartMfgDwgNo")
            daMfgDwgNo.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daRev.UpdateCommand = RevBuilder.GetUpdateCommand
            daRev.UpdateCommand.Connection = cn
            daRev.InsertCommand = RevBuilder.GetInsertCommand
            AddHandler daRev.RowUpdated, AddressOf HandleRowUpdatedPartRev
            daRev.InsertCommand.Connection = cn
            daRev.DeleteCommand = RevBuilder.GetDeleteCommand
            daRev.DeleteCommand.Connection = cn
            daRev.AcceptChangesDuringFill = True
            daRev.TableMappings.Add("Table", "tblPartRev")
            daRev.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daMfg.UpdateCommand = MfgBuilder.GetUpdateCommand
            daMfg.UpdateCommand.Connection = cn
            daMfg.InsertCommand = MfgBuilder.GetInsertCommand
            AddHandler daMfg.RowUpdated, AddressOf HandleRowUpdatedPartMfg
            daMfg.InsertCommand.Connection = cn
            daMfg.DeleteCommand = MfgBuilder.GetDeleteCommand
            daMfg.DeleteCommand.Connection = cn
            daMfg.AcceptChangesDuringFill = True
            daMfg.TableMappings.Add("Table", "tblPartMfgSpec")
            daMfg.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daProc.UpdateCommand = ProcBuilder.GetUpdateCommand
            daProc.UpdateCommand.Connection = cn
            daProc.InsertCommand = ProcBuilder.GetInsertCommand
            AddHandler daProc.RowUpdated, AddressOf HandleRowUpdatedPartProc
            daProc.InsertCommand.Connection = cn
            'daProc.DeleteCommand = ProcBuilder.GetDeleteCommand
            'daProc.DeleteCommand.Connection = cn
            daProc.AcceptChangesDuringFill = True
            daProc.TableMappings.Add("Table", "tblPartProc")
            daProc.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daMat.UpdateCommand = MatlBuilder.GetUpdateCommand
            daMat.UpdateCommand.Connection = cn
            daMat.InsertCommand = MatlBuilder.GetInsertCommand
            AddHandler daMat.RowUpdated, AddressOf HandleRowUpdatedPartMat
            daMat.InsertCommand.Connection = cn
            'daProc.DeleteCommand = ProcBuilder.GetDeleteCommand
            'daProc.DeleteCommand.Connection = cn
            daMat.AcceptChangesDuringFill = True
            daMat.TableMappings.Add("Table", "tblPartMatlPref")
            daMat.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daAssy.UpdateCommand = AssyBuilder.GetUpdateCommand
            daAssy.UpdateCommand.Connection = cn
            daAssy.InsertCommand = AssyBuilder.GetInsertCommand
            AddHandler daAssy.RowUpdated, AddressOf HandleRowUpdatedPartAssy
            daAssy.InsertCommand.Connection = cn
            daAssy.DeleteCommand = AssyBuilder.GetDeleteCommand
            daAssy.DeleteCommand.Connection = cn
            daAssy.AcceptChangesDuringFill = True
            daAssy.TableMappings.Add("Table", "tblPartAssyComponents")
            daAssy.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daFromBlanks.UpdateCommand = BlanksBuilder.GetUpdateCommand
            daFromBlanks.UpdateCommand.Connection = cn
            daFromBlanks.InsertCommand = BlanksBuilder.GetInsertCommand
            AddHandler daFromBlanks.RowUpdated, AddressOf HandleRowUpdatedBlanks
            daFromBlanks.InsertCommand.Connection = cn
            daFromBlanks.DeleteCommand = BlanksBuilder.GetDeleteCommand
            daFromBlanks.DeleteCommand.Connection = cn
            daFromBlanks.AcceptChangesDuringFill = True
            daFromBlanks.TableMappings.Add("Table", "tblPartRelationBlank")
            daFromBlanks.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daPartsList.UpdateCommand = PartListBuilder.GetUpdateCommand
            daPartsList.UpdateCommand.Connection = cn
            daPartsList.InsertCommand = PartListBuilder.GetInsertCommand
            AddHandler daPartsList.RowUpdated, AddressOf HandleRowUpdatedPartsList
            daPartsList.InsertCommand.Connection = cn
            daPartsList.DeleteCommand = PartListBuilder.GetDeleteCommand
            daPartsList.DeleteCommand.Connection = cn
            daPartsList.AcceptChangesDuringFill = True
            daPartsList.TableMappings.Add("Table", "tblPartRelationBlank")
            daPartsList.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daRef.UpdateCommand = PartRefBuilder.GetUpdateCommand
            daRef.UpdateCommand.Connection = cn
            daRef.InsertCommand = PartRefBuilder.GetInsertCommand
            AddHandler daRef.RowUpdated, AddressOf HandleRowUpdatedPartRef
            daRef.InsertCommand.Connection = cn
            daRef.DeleteCommand = PartRefBuilder.GetDeleteCommand
            daRef.DeleteCommand.Connection = cn
            daRef.AcceptChangesDuringFill = True
            daRef.TableMappings.Add("Table", "tblPartReference")
            daRef.MissingSchemaAction = MissingSchemaAction.AddWithKey

            'daCross.UpdateCommand = PartCrossBuilder.GetUpdateCommand
            'daCross.UpdateCommand.Connection = cn
            'daCross.InsertCommand = PartCrossBuilder.GetInsertCommand
            'AddHandler daCross.RowUpdated, AddressOf HandleRowUpdatedPartCross
            'daCross.InsertCommand.Connection = cn
            'daCross.DeleteCommand = PartCrossBuilder.GetDeleteCommand
            'daCross.DeleteCommand.Connection = cn
            'daCross.AcceptChangesDuringFill = True
            'daCross.TableMappings.Add("Table", "tblPartCrossPN")
            'daCross.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    'Private Sub HandleRowUpdatedPartCross(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

    '    Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
    '    If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
    '        e.Row(dsMain.Tables("tblPartCrossPN").Columns("CrossID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
    '        e.Row.AcceptChanges()
    '    End If

    'End Sub

    Private Sub HandleRowUpdatedPartRef(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartReference").Columns("PartRefID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedBlanks(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartRelationBlank").Columns("PNRelID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartsList(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartRelationBlank").Columns("PNRelID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartAssy(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartAssyComponents").Columns("PartAssyID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartMat(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartMatlPref").Columns("PartMatlID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedMfgDwgNo(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartMfgDwgNo").Columns("MfgDwgRevID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartMast(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartMaster").Columns("PartID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartRev(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartRev").Columns("PartRevID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartMfg(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartMfgSpec").Columns("MfgSpecID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedPartProc(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblPartProc").Columns("ProcID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daPart.FillSchema(dsMain, SchemaType.Source, "tblPartMaster")
        daMfgDwgNo.FillSchema(dsMain, SchemaType.Source, "tblPartMfgDwgNo")
        daRev.FillSchema(dsMain, SchemaType.Source, "tblPartRev")
        daMfg.FillSchema(dsMain, SchemaType.Source, "tblPartMfgSpec")
        daProc.FillSchema(dsMain, SchemaType.Source, "tblPartProc")
        daMat.FillSchema(dsMain, SchemaType.Source, "tblPartMatlPref")
        daAssy.FillSchema(dsMain, SchemaType.Source, "tblPartAssyComponents")
        daFromBlanks.FillSchema(dsMain, SchemaType.Source, "tblPartRelationBlank")
        daPartsList.FillSchema(dsMain, SchemaType.Source, "tblPartRelationBlank")
        daRef.FillSchema(dsMain, SchemaType.Source, "tblPartReference")
        'daCross.FillSchema(dsMain, SchemaType.Source, "tblPartCrossPN")

        CallClass.PopulateDataAdapter("getTblMatlMasterDetails").Fill(dsMain, "tblMatlMasterDetails")
        CallClass.PopulateDataAdapter("getTblMpoMasterAndDept").Fill(dsMain, "tblMpoMaster")
        CallClass.PopulateDataAdapter("gettblPartCrossPNReferencesEng_Empty").Fill(dsMain, "tblPartCrossPN")

        CallClass.PopulateDataAdapter("gettblPartMasterEmpty").Fill(dsMain, "tblTemp")

        daPart.Fill(dsMain, "tblPartMaster")
        Dim MastID As DataColumn = dsMain.Tables("tblPartMaster").Columns("PartID")
        MastID.AutoIncrement = True
        MastID.AutoIncrementStep = -1
        MastID.AutoIncrementSeed = -1
        MastID.ReadOnly = False

        daMfgDwgNo.Fill(dsMain, "tblPartMfgDwgNo")
        Dim MfgDwgID As DataColumn = dsMain.Tables("tblPartMfgDwgNo").Columns("MfgDwgRevID")
        MfgDwgID.AutoIncrement = True
        MfgDwgID.AutoIncrementStep = -1
        MfgDwgID.AutoIncrementSeed = -1
        MfgDwgID.ReadOnly = False

        daRev.Fill(dsMain, "tblPartRev")
        Dim RevID As DataColumn = dsMain.Tables("tblPartRev").Columns("PartRevID")
        RevID.AutoIncrement = True
        RevID.AutoIncrementStep = -1
        RevID.AutoIncrementSeed = -1
        RevID.ReadOnly = False

        daMfg.Fill(dsMain, "tblPartMfgSpec")
        Dim MfgID As DataColumn = dsMain.Tables("tblPartMfgSpec").Columns("MfgSpecID")
        MfgID.AutoIncrement = True
        MfgID.AutoIncrementStep = -1
        MfgID.AutoIncrementSeed = -1
        MfgID.ReadOnly = False

        daProc.Fill(dsMain, "tblPartProc")
        Dim PrID As DataColumn = dsMain.Tables("tblPartProc").Columns("ProcID")
        PrID.AutoIncrement = True
        PrID.AutoIncrementStep = -1
        PrID.AutoIncrementSeed = -1
        PrID.ReadOnly = False

        daMat.Fill(dsMain, "tblPartMatlPref")
        Dim PrefMatID As DataColumn = dsMain.Tables("tblPartMatlPref").Columns("PartMatlID")
        PrefMatID.AutoIncrement = True
        PrefMatID.AutoIncrementStep = -1
        PrefMatID.AutoIncrementSeed = -1
        PrefMatID.ReadOnly = False

        daAssy.Fill(dsMain, "tblPartAssyComponents")
        Dim AssyID As DataColumn = dsMain.Tables("tblPartAssyComponents").Columns("PartAssyID")
        AssyID.AutoIncrement = True
        AssyID.AutoIncrementStep = -1
        AssyID.AutoIncrementSeed = -1
        AssyID.ReadOnly = False

        daFromBlanks.Fill(dsMain, "tblPartRelationBlank")
        Dim FromBlanksID As DataColumn = dsMain.Tables("tblPartRelationBlank").Columns("PNRelID")
        FromBlanksID.AutoIncrement = True
        FromBlanksID.AutoIncrementStep = -1
        FromBlanksID.AutoIncrementSeed = -1
        FromBlanksID.ReadOnly = False

        daPartsList.Fill(dsMain, "tblPartRelationBlank")
        Dim PartsListID As DataColumn = dsMain.Tables("tblPartRelationBlank").Columns("PNRelID")
        PartsListID.AutoIncrement = True
        PartsListID.AutoIncrementStep = -1
        PartsListID.AutoIncrementSeed = -1
        PartsListID.ReadOnly = False

        daRef.Fill(dsMain, "tblPartReference")
        Dim PartsRefID As DataColumn = dsMain.Tables("tblPartReference").Columns("PartRefID")
        PartsRefID.AutoIncrement = True
        PartsRefID.AutoIncrementStep = -1
        PartsRefID.AutoIncrementSeed = -1
        PartsRefID.ReadOnly = False

        'daCross.Fill(dsMain, "tblPartCrossPN")
        'Dim PartsCrossID As DataColumn = dsMain.Tables("tblPartCrossPN").Columns("CrossID")
        'PartsCrossID.AutoIncrement = True
        'PartsCrossID.AutoIncrementStep = -1
        'PartsCrossID.AutoIncrementSeed = -1
        'PartsCrossID.ReadOnly = False

        dsMain.EnforceConstraints = False

        'With dsMain
        '    .Relations.Add("PartCross", _
        '        .Tables("tblPartMaster").Columns("PartID"), _
        '        .Tables("tblPartCrossPN").Columns("PartIDCr"), True)
        'End With

        With dsMain
            .Relations.Add("PartRef", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartReference").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartRev", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartRev").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartMfgDwgRev", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartMfgDwgNo").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartMfg", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartMfgSpec").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartProc", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartProc").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartPrefMat", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartMatlPref").Columns("PartID"), True)
        End With

        With dsMain
            .Relations.Add("PartMpo", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblMpoMaster").Columns("MpoPartID"), True)
        End With

        With dsMain
            .Relations.Add("PartAssy", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartAssyComponents").Columns("PartNoID"), True)
        End With

        With dsMain
            .Relations.Add("PartFromBlank", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartRelationBlank").Columns("PNStdCompID"), True)
        End With

        With dsMain
            .Relations.Add("PartsListLinkWithBlank", _
                .Tables("tblPartMaster").Columns("PartID"), _
                .Tables("tblPartRelationBlank").Columns("PNBlanksID"), True)
        End With

        PartCurrency = CType(BindingContext(dsMain, "tblPartMaster"), CurrencyManager)
        MfgDwgNoCurrency = CType(BindingContext(dsMain, "tblPartMfgDwgNo"), CurrencyManager)
        RevCurrency = CType(BindingContext(dsMain, "tblPartRev"), CurrencyManager)
        MfgCurrency = CType(BindingContext(dsMain, "tblPartMfgSpec"), CurrencyManager)
        ProcCurrency = CType(BindingContext(dsMain, "tblPartProc"), CurrencyManager)
        MatCurrency = CType(BindingContext(dsMain, "tblPartMatlPref"), CurrencyManager)
        AssyCurrency = CType(BindingContext(dsMain, "tblPartAssyComponents"), CurrencyManager)
        BlanksCurrency = CType(BindingContext(dsMain, "tblPartRelationBlank"), CurrencyManager)
        PartListCurrency = CType(BindingContext(dsMain, "tblPartRelationBlank"), CurrencyManager)
        PartRefCurrency = CType(BindingContext(dsMain, "tblPartReference"), CurrencyManager)
        'PartCrossCurrency = CType(BindingContext(dsMain, "tblPartCrossPN"), CurrencyManager)

        CmbPartNumber.DataSource = dsMain.Tables("tblPartMaster")
        CmbPartNumber.DisplayMember = "PartNumber"
        CmbPartNumber.ValueMember = "PartID"

        dgRev.AutoGenerateColumns = False
        dgRev.DataSource = dsMain
        dgRev.DataMember = "tblPartMaster.PartRev"

        dgMFGDwgRev.AutoGenerateColumns = False
        dgMFGDwgRev.DataSource = dsMain
        dgMFGDwgRev.DataMember = "tblPartMaster.PartMfgDwgRev"

        dgMfg.AutoGenerateColumns = False
        dgMfg.DataSource = dsMain
        dgMfg.DataMember = "tblPartMaster.PartMfg"

        dgProc.AutoGenerateColumns = False
        dgProc.DataSource = dsMain
        dgProc.DataMember = "tblPartMaster.PartProc"

        dgMat.AutoGenerateColumns = False
        dgMat.DataSource = dsMain
        dgMat.DataMember = "tblPartMaster.PartPrefMat"

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblPartMaster.PartMpo"

        dgAssy.AutoGenerateColumns = False
        dgAssy.DataSource = dsMain
        dgAssy.DataMember = "tblPartMaster.PartAssy"

        dgFromBlanks.AutoGenerateColumns = False
        dgFromBlanks.DataSource = dsMain
        dgFromBlanks.DataMember = "tblPartMaster.PartFromBlank"

        dgPartList.AutoGenerateColumns = False
        dgPartList.DataSource = dsMain
        dgPartList.DataMember = "tblPartMaster.PartsListLinkWithBlank"

        dgRef.AutoGenerateColumns = False
        dgRef.DataSource = dsMain
        dgRef.DataMember = "tblPartMaster.PartRef"

        'dgCross.AutoGenerateColumns = False
        'dgCross.DataSource = dsMain
        'dgCross.DataMember = "tblPartMaster.PartIDCr"

    End Sub

    Sub SetDataCtl()

        With Me.CmbProductLine
            .DataSource = CallClass.PopulateComboBox("tblPartProductLine", "cmbGetProductLine").Tables("tblPartProductLine")
            .DisplayMember = "ProductDescr"
            .ValueMember = "ProductLineID"
        End With

        With Me.CmbDwgSource
            .DataSource = CallClass.PopulateComboBox("tblPartDWGSource", "gettblPartDwgSource").Tables("tblPartDWGSource")
            .DisplayMember = "SourceName"
            .ValueMember = "DwgSourceID"
        End With

        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
        End With

        With Me.CmbCreatedBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetUser").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .SelectedValue = wkEmpId
        End With

        With Me.CmbApprovedBy
            .DataSource = CallClass.PopulateComboBoxWithParam("tblEmployee", "cmbGetEngByEmpID", wkEmpId).Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            '.SelectedValue = wkEmpId
        End With

        'dgRev datagridview

        With Me.PartRevID
            .DataPropertyName = "PartRevID"
            .Name = "PartRevID"
            .Visible = False
        End With

        With Me.PartIDRev
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.RevNo
            .DataPropertyName = "RevNo"
            .Name = "RevNo"
        End With

        With Me.RevDateStart
            .DataPropertyName = "RevDateStart"
            .Name = "RevDateStart"
        End With

        With Me.RevDesc
            .DataPropertyName = "RevDesc"
            .Name = "RevDesc"
        End With

        With Me.RevNotes
            .DataPropertyName = "RevNotes"
            .Name = "RevNotes"
        End With

        With Me.RevStatus
            .DataPropertyName = "RevStatus"
            .Name = "RevStatus"
        End With

        'dgMFGDwgRev

        With Me.MfgDwgRevID
            .DataPropertyName = "MfgDwgRevID"
            .Name = "MfgDwgRevID"
            .Visible = False
        End With

        With Me.PartIDMfgDwg
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MfgDwgRevNo
            .DataPropertyName = "MfgDwgRevNo"
            .Name = "MfgDwgRevNo"
        End With

        With Me.MfgDwgDate
            .DataPropertyName = "MfgDwgDate"
            .Name = "MfgDwgDate"
        End With

        With Me.MfgDwgDescr
            .DataPropertyName = "MfgDwgDescr"
            .Name = "MfgDwgDescr"
        End With

        With Me.MfgDwgNotes
            .DataPropertyName = "MfgDwgNotes"
            .Name = "MfgDwgNotes"
        End With

        With Me.MfgDwgCreatedBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetProc").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DataPropertyName = "MfgDwgCreatedBy"
            .Name = "MfgDwgCreatedBy"
            .DropDownWidth = 250
            .MaxDropDownItems = 20
        End With

        'dgMfg  datagridview

        With Me.MfgSpecID
            .DataPropertyName = "MfgSpecID"
            .Name = "MfgSpecID"
            .Visible = False
        End With

        With Me.PartIDSpec
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MfgSpec
            .DataPropertyName = "MfgSpec"
            .Name = "MfgSpec"
        End With

        With Me.MfgDateIssue
            .DataPropertyName = "MfgDateIssue"
            .Name = "MfgDateIssue"
        End With

        With Me.MfgSpecNotes
            .DataPropertyName = "MfgSpecNotes"
            .Name = "MfgSpecNotes"
        End With

        With Me.MfgStatus
            .DataPropertyName = "MfgStatus"
            .Name = "MfgStatus"
        End With

        'dgProc 
        With Me.ProcID
            .DataPropertyName = "ProcID"
            .Name = "ProcID"
            .Visible = False
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.ProcNo
            .DataPropertyName = "ProcNo"
            .Name = "ProcNo"
        End With

        With Me.ProcType
            .DataPropertyName = "ProcType"
            .Name = "ProcType"
        End With

        With Me.ProcMatlForm
            .DataPropertyName = "ProcMatlForm"
            .Name = "ProcMatlForm"
        End With

        With Me.ProcDia
            .DataPropertyName = "ProcDia"
            .Name = "ProcDia"
        End With

        With Me.ProcMatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "ProcMatlID"
            .Name = "ProcMatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.ProcMatlTypeID
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "ProcMatlTypeID"
            .Name = "ProcMatlTypeID"
            .DropDownWidth = 400
            .MaxDropDownItems = 20
        End With

        With Me.PartNoRevSave
            .DataPropertyName = "PartNoRevSave"
            .Name = "PartNoRevSave"
        End With

        With Me.PartNoRevDate
            .DataPropertyName = "PartNoRevDate"
            .Name = "PartNoRevDate"
        End With

        With Me.CreatedBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetProc").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DataPropertyName = "CreatedBy"
            .Name = "CreatedBy"
        End With

        With Me.CreatedDate
            .DataPropertyName = "CreatedDate"
            .Name = "CreatedDate"
        End With

        With Me.ReviewBy
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetProc").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DataPropertyName = "ReviewBy"
            .Name = "ReviewBy"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.ReviewDate
            .DataPropertyName = "ReviewDate"
            .Name = "ReviewDate"
        End With

        With Me.ProcNotes
            .DataPropertyName = "ProcNotes"
            .Name = "ProcNotes"
        End With

        With Me.ProcStatus
            .DataPropertyName = "ProcStatus"
            .Name = "ProcStatus"
        End With

        'dgMat prefferd
        With Me.PartMatlID
            .DataPropertyName = "PartMatlID"
            .Name = "PartMatlID"
            .Visible = False
        End With

        With Me.MatlPrefPartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        With Me.MatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.MatlDetIDPref
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetIDPref"
            .DropDownWidth = 500
            .MaxDropDownItems = 20
        End With

        With Me.MatlForm
            .DataPropertyName = "MatlForm"
            .Name = "MatlForm"
        End With

        With Me.MatlDia
            .DataPropertyName = "MatlDia"
            .Name = "MatlDia"
        End With

        ' dgMpo fields

        With Me.MpoID
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.QtyActual
            .DataPropertyName = "QtyActual"
            .Name = "QtyActual"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.DeptNode
            .DataPropertyName = "DeptNode"
            .Name = "DeptNode"
        End With

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
        End With

        With Me.ChWFM
            .DataPropertyName = "ChWFM"
            .Name = "ChWFM"
        End With

        With Me.ChWFT
            .DataPropertyName = "ChWFT"
            .Name = "ChWFT"
        End With

        With Me.MpoLotNo
            .DataPropertyName = "MpoLotNo"
            .Name = "MpoLotNo"
        End With

        With Me.MpoMatlWeight
            .DataPropertyName = "MpoMatlWeight"
            .Name = "MpoMatlWeight"
        End With

        With Me.MpoMatlAdj
            .DataPropertyName = "MpoMatlAdj"
            .Name = "MpoMatlAdj"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdDevise
            .DataPropertyName = "OrdDevise"
            .Name = "OrdDevise"
        End With

        With Me.MpoValue
            .DataPropertyName = "MpoValue"
            .Name = "MpoValue"
        End With

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.MpoEngInfo
            .DataPropertyName = "MpoEngInfo"
            .Name = "MpoEngInfo"
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
        End With

        With Me.MpoPartType
            .DataPropertyName = "MpoPartType"
            .Name = "MpoPartType"
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
        End With

        With Me.MpoTechNotes
            .DataPropertyName = "MpoTechNotes"
            .Name = "MpoTechNotes"
        End With

        'dgAssy

        With Me.PartAssyID
            .DataPropertyName = "PartAssyID"
            .Name = "PartAssyID"
            .Visible = False
        End With

        With Me.PartCompID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberComponent").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "PartCompID"
            .Name = "PartCompID"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
        End With

        With Me.PartAssyName
            .DataPropertyName = "PartAssyName"
            .Name = "PartAssyName"
        End With

        With Me.PartAssyNotes
            .DataPropertyName = "PartAssyNotes"
            .Name = "PartAssyNotes"
        End With

        With Me.PartAssyStatus
            .DataPropertyName = "PartAssyStatus"
            .Name = "PartAssyStatus"
        End With

        ' dgFromBlanks

        With Me.PNRelID
            .DataPropertyName = "PNRelID"
            .Name = "PNRelID"
            .Visible = False
        End With

        With Me.PNBlanksID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberBlanks").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "PNBlanksID"
            .Name = "PNBlanksID"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
        End With

        With Me.PNBlankName
            .DataPropertyName = "PNBlankName"
            .Name = "PNBlankName"
        End With

        With Me.PNBlankDescrCode
            .DataPropertyName = "PNBlankDescrCode"
            .Name = "PNBlankDescrCode"
        End With

        With Me.PNRelNotes
            .DataPropertyName = "PNRelNotes"
            .Name = "PNRelNotes"
        End With

        With Me.PNRelStatus
            .DataPropertyName = "PNRelStatus"
            .Name = "PNRelStatus"
        End With

        ' dgPartsList

        'PrtListPNRelID
        With Me.PrtListPNRelID
            .DataPropertyName = "PNRelID"
            .Name = "PNRelID"
            .Visible = False
        End With

        'PrtListPNBlanksID
        With Me.PrtListPNBlanksID
            .DataPropertyName = "PNBlanksID"
            .Name = "PNBlanksID"
            .Visible = False
        End With

        With Me.PrtListPNStdCompID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberListForBlanks").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "PNStdCompID"
            .Name = "PNStdCompID"
            .DropDownWidth = 300
            .MaxDropDownItems = 30
        End With

        With Me.PrtListPNBlankName
            .DataPropertyName = "PrtListPNBlankName"
            .Name = "PrtListPNBlankName"
        End With

        With Me.PrtListPNBlankDescrCode
            .DataPropertyName = "PrtListPNBlankDescrCode"
            .Name = "PrtListPNBlankDescrCode"
        End With

        With Me.PrtListPNRelNotes
            .DataPropertyName = "PNRelNotes"
            .Name = "PNRelNotes"
        End With

        With Me.PrtListPNRelStatus
            .DataPropertyName = "PNRelStatus"
            .Name = "PNRelStatus"
        End With

        'dgRef

        With Me.PartRefIndex
            .DataPropertyName = "PartRefIndex"
            .Name = "PartRefIndex"
        End With

        With Me.PartRefDia
            .DataPropertyName = "PartRefDia"
            .Name = "PartRefDia"
        End With

        With Me.PartRefLength
            .DataPropertyName = "PartRefLength"
            .Name = "PartRefLength"
        End With

        With Me.PartOSCode
            .DataPropertyName = "PartOSCode"
            .Name = "PartOSCode"
        End With

        With Me.PartRefNotes
            .DataPropertyName = "PartRefNotes"
            .Name = "PartRefNotes"
        End With

        With Me.PartRefID
            .DataPropertyName = "PartRefID"
            .Name = "PartRefID"
            .Visible = False
        End With

        With Me.RefPartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
            .Visible = False
        End With

        'dgcross

        With Me.CrossID
            .DataPropertyName = "CrossID"
            .Name = "CrossID"
            .Visible = False
        End With

        With Me.CrossMasterID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross8899").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "CrossMasterID"
            .Name = "CrossMasterID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

        With Me.CrossReferenceID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross20").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "CrossReferenceID"
            .Name = "CrossReferenceID"

            .DropDownWidth = 200
            .MaxDropDownItems = 40
        End With

        With Me.CrossStatus
            .DataPropertyName = "CrossStatus"
            .Name = "CrossStatus"
        End With

        With Me.CrossNotes
            .DataPropertyName = "CrossNotes"
            .Name = "CrossNotes"
        End With

    End Sub

    Sub DisableScreen()
        txtPartDate.ReadOnly = True     'only
        txtPartNo.ReadOnly = True
        txtDocNo.ReadOnly = True
        txtPNLengthUsage.ReadOnly = True
        txtMfgDwgNo.ReadOnly = True
        txtPartName.ReadOnly = True
        txtDescrCode.ReadOnly = True
        txtNSN.ReadOnly = True
        txtLisiPart.ReadOnly = True
        txtRawWeight.ReadOnly = True
        txtPcsBar.ReadOnly = True
        txtFinalWeight.ReadOnly = True
        txtDateIssue.ReadOnly = True
        txtPartNotes.ReadOnly = True
        txtDateApproved.ReadOnly = True

        txtRevDesc.ReadOnly = True
        txtRevNotes.ReadOnly = True

        txtMfgSpec.ReadOnly = True
        txtMfgNotes.ReadOnly = True

        CmbUser.Enabled = False         'only
        CmbPartNumber.Enabled = True
        CmbDwgSource.Enabled = False
        cmbStatus.Enabled = False
        cmbPartType.Enabled = False
        CmbPartClasi.Enabled = False
        CmbCreatedBy.Enabled = False
        CmbApprovedBy.Enabled = False
        CmbCrossStatus.Enabled = False

        dgMFGDwgRev.ReadOnly = True
        dgMfg.ReadOnly = True
        dgMat.ReadOnly = True
        dgAssy.ReadOnly = True
        dgFromBlanks.ReadOnly = True
        dgPartList.ReadOnly = True
        dgRef.ReadOnly = True
        dgCross.ReadOnly = True

        'dgProc.ReadOnly = True

        'dgRev.ReadOnly = True

        dgRev.Columns(0).ReadOnly = True
        dgRev.Columns(1).ReadOnly = True
        dgRev.Columns(2).ReadOnly = True
        dgRev.Columns(3).ReadOnly = True
        dgRev.Columns(4).ReadOnly = True
        dgRev.Columns(5).ReadOnly = True
        dgRev.Columns(6).ReadOnly = True


        dgProc.Columns(0).ReadOnly = True
        dgProc.Columns(1).ReadOnly = True
        dgProc.Columns(2).ReadOnly = True
        dgProc.Columns(3).ReadOnly = True
        dgProc.Columns(4).ReadOnly = True
        dgProc.Columns(5).ReadOnly = True
        dgProc.Columns(6).ReadOnly = True
        dgProc.Columns(7).ReadOnly = True
        dgProc.Columns(8).ReadOnly = True
        dgProc.Columns(9).ReadOnly = True
        dgProc.Columns(10).ReadOnly = True
        dgProc.Columns(11).ReadOnly = True
        dgProc.Columns(12).ReadOnly = True
        dgProc.Columns(13).ReadOnly = True
        dgProc.Columns(14).ReadOnly = False
        dgProc.Columns(15).ReadOnly = True
        dgProc.Columns(16).ReadOnly = False

        dgCross.Columns(0).ReadOnly = True
        dgCross.Columns(1).ReadOnly = True
        dgCross.Columns(2).ReadOnly = True
        dgCross.Columns(3).ReadOnly = True
        dgCross.Columns(4).ReadOnly = True

    End Sub

    Sub DisableButton()
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True
        CmdSeeCust.Enabled = False
        CmdMfgDwg.Enabled = False
        CmdMat.Enabled = False

    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click
        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        CmdReset.Enabled = True
        CmdBrowse.Enabled = False

        CmbPartNumber.Enabled = False

        PartCurrency.EndCurrentEdit()
        dsMain.RejectChanges()
        PartCurrency.AddNew()
        dgRev.Refresh()
        Call EnableFields()
        Call InitValue()

    End Sub

    Sub EnableFields()
        If Len(Trim(txtDateApproved.Text)) <> 0 Or Len(Trim(CmbApprovedBy.Text)) <> 0 Then  'some fields enable
            txtPartDate.Focus()

            txtPartNo.ReadOnly = True
            txtDocNo.ReadOnly = False
            txtPNLengthUsage.ReadOnly = False
            txtPartName.ReadOnly = False
            txtMfgDwgNo.ReadOnly = False
            txtDescrCode.ReadOnly = False
            txtNSN.ReadOnly = False
            txtLisiPart.ReadOnly = False
            txtRawWeight.ReadOnly = False
            txtPcsBar.ReadOnly = False
            txtFinalWeight.ReadOnly = False
            txtDateApproved.ReadOnly = True

            txtPartNotes.ReadOnly = False

            txtRevDesc.ReadOnly = False
            txtRevNotes.ReadOnly = False

            txtMfgSpec.ReadOnly = False
            txtMfgNotes.ReadOnly = False

            CmbPartNumber.Enabled = False
            CmbDwgSource.Enabled = True
            cmbStatus.Enabled = True
            cmbPartType.Enabled = True
            CmbPartClasi.Enabled = True
            CmbApprovedBy.Enabled = False
            CmbCrossStatus.Enabled = True

            CmdSeeCust.Enabled = True
            CmdMfgDwg.Enabled = True
            CmdMat.Enabled = True

            'dgRev.ReadOnly = False
            dgMFGDwgRev.ReadOnly = False
            dgMfg.ReadOnly = False
            dgMat.ReadOnly = False
            dgAssy.ReadOnly = False
            dgFromBlanks.ReadOnly = False
            dgPartList.ReadOnly = False
            dgRef.ReadOnly = False
            dgCross.ReadOnly = False

            txtDateIssue.ReadOnly = True        'created by sales or eng
            CmbCreatedBy.Enabled = False        '  '='
        Else
            txtPartDate.Focus()

            txtPartNo.ReadOnly = False
            txtDocNo.ReadOnly = False
            txtPNLengthUsage.ReadOnly = False
            txtPartName.ReadOnly = False
            txtMfgDwgNo.ReadOnly = False
            txtDescrCode.ReadOnly = False
            txtNSN.ReadOnly = False
            txtLisiPart.ReadOnly = False
            txtRawWeight.ReadOnly = False
            txtPcsBar.ReadOnly = False
            txtFinalWeight.ReadOnly = False
            txtDateApproved.ReadOnly = False

            txtPartNotes.ReadOnly = False

            txtRevDesc.ReadOnly = False
            txtRevNotes.ReadOnly = False

            txtMfgSpec.ReadOnly = False
            txtMfgNotes.ReadOnly = False

            CmbPartNumber.Enabled = False
            CmbDwgSource.Enabled = True
            cmbStatus.Enabled = True
            cmbPartType.Enabled = True
            CmbPartClasi.Enabled = True
            CmbApprovedBy.Enabled = True
            CmbCrossStatus.Enabled = True

            CmdSeeCust.Enabled = True
            CmdMfgDwg.Enabled = True
            CmdMat.Enabled = True

            'dgRev.ReadOnly = False
            dgMFGDwgRev.ReadOnly = False
            dgMfg.ReadOnly = False
            dgMat.ReadOnly = False
            dgAssy.ReadOnly = False
            dgFromBlanks.ReadOnly = False
            dgPartList.ReadOnly = False
            dgRef.ReadOnly = False
            dgCross.ReadOnly = False

            txtDateIssue.ReadOnly = True        'created by sales or eng
            CmbCreatedBy.Enabled = False        '  '='
        End If

        dgRev.Columns(0).ReadOnly = True
        dgRev.Columns(1).ReadOnly = True
        dgRev.Columns(2).ReadOnly = False
        dgRev.Columns(3).ReadOnly = True
        dgRev.Columns(4).ReadOnly = False
        dgRev.Columns(5).ReadOnly = False
        dgRev.Columns(6).ReadOnly = False

        dgProc.Columns(0).ReadOnly = False
        dgProc.Columns(1).ReadOnly = False
        dgProc.Columns(2).ReadOnly = False
        dgProc.Columns(3).ReadOnly = False
        dgProc.Columns(4).ReadOnly = False
        dgProc.Columns(5).ReadOnly = False
        dgProc.Columns(6).ReadOnly = False
        dgProc.Columns(7).ReadOnly = False
        dgProc.Columns(8).ReadOnly = False
        dgProc.Columns(9).ReadOnly = False
        dgProc.Columns(10).ReadOnly = False
        dgProc.Columns(11).ReadOnly = False
        dgProc.Columns(12).ReadOnly = False
        dgProc.Columns(13).ReadOnly = False
        dgProc.Columns(14).ReadOnly = False
        dgProc.Columns(15).ReadOnly = False
        dgProc.Columns(16).ReadOnly = False

        dgCross.Columns(0).ReadOnly = True
        dgCross.Columns(1).ReadOnly = True
        dgCross.Columns(2).ReadOnly = True
        dgCross.Columns(3).ReadOnly = False
        dgCross.Columns(4).ReadOnly = False

    End Sub

    Sub InitValue()
        txtPartDate.Text = Now.ToShortDateString
        txtDateIssue.Text = Now.ToShortDateString
        CmbCreatedBy.SelectedValue = wkEmpId
        txtRawWeight.Text = 0.0
        txtPcsBar.Text = 0
        txtFinalWeight.Text = 0.0
        txtPartName.Text = "BOLT, TYPE"
        cmbStatus.Text = ""
        cmbStatus.SelectedText = "Active"
        CmbDwgSource.SelectedIndex = -1
        cmbPartType.Text = "Part Control"
        CmbPartClasi.Text = "Standard"
        CmbCrossStatus.Text = ""

    End Sub

    Private Sub dgRev_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            If dgRev.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevStatus").Value) = False Then
                If dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "InActive" Then
                    MsgBox("Status Revision = InActive  -  ReadOnly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Revision Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "Active"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgRev_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRev.CellEndEdit
        Select Case e.ColumnIndex
            Case 2      'revno
                If IsDBNull(dgRev.Item("RevNo", e.RowIndex).Value) = False Then
                    dgRev.Item("RevDateStart", e.RowIndex).Value = txtPartDate.Text
                Else
                    Exit Sub
                End If

                If Convert.ToString(Len(Trim(dgRev.Rows(e.RowIndex).Cells("RevStatus").ToString))) = 0 Or _
                    IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevStatus").Value) = True Then
                    dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "Active"
                Else
                    Exit Sub
                End If

            Case 3
                Try
                    If IsDBNull(Me.dgRev.Item("RevDateStart", e.RowIndex).Value) = False Then
                        Dim dt As DateTime = DateTime.Parse(Me.dgRev("RevDateStart", e.RowIndex).Value)

                        If dt.Year < 1990 OrElse dt.Year > 2012 Then
                            MsgBox("The Range of valid Years must be between 1990 and 2012")

                            dgRev.Rows(e.RowIndex).Cells("RevDateStart").Value = "MM/dd/yyyy"
                        End If
                    End If
                Catch ex As Exception
                    If e.RowIndex < 0 Then
                        Exit Sub
                    End If
                    MsgBox("Error: " & ex.Message, _
                    MsgBoxStyle.OKOnly, "Revision Date Issue: MM/dd/yyyy")
                    'Me.dgMfg("MfgDateIssue", e.RowIndex).Value = "MM/dd/yyyy"
                End Try

        End Select


        'save any change in revision or add

        dgRev.EndEdit()
        Me.Focus()
        txtPartNo.Focus()
        dgProc.Focus()
        Me.Focus()
        txtPartNo.Focus()

        RevCurrency.EndCurrentEdit()

        dsMain.GetChanges()
        daRev.Update(dsMain.Tables("tblPartRev").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

        dgRev.Refresh()

    End Sub

    Private Sub dgMfg_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMfg.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.RowIndex <> -1 Then
            If dgMfg.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value) = False Then
                If dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value = "InActive" Then
                    MsgBox("Status Mfg Spec. Status = InActive  -  ReadOnly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Mfg Spec Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value = "Active"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgMfg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMfg.CellEndEdit
        Select Case e.ColumnIndex
            Case 2          ' mfgspec
                If IsDBNull(dgMfg.Item("MfgSpec", e.RowIndex).Value) = False Then
                    dgMfg.Item("MfgDateIssue", e.RowIndex).Value = txtPartDate.Text
                Else
                    Exit Sub
                End If

                If Convert.ToString(Len(Trim(dgMfg.Rows(e.RowIndex).Cells("MfgStatus").ToString))) = 0 Or _
                    IsDBNull(dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value) = True Then
                    dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value = "Active"
                End If

            Case 3
                Try
                    If IsDBNull(Me.dgRev.Item("MfgDateIssue", e.RowIndex).Value) = False Then
                        Dim dt As DateTime = DateTime.Parse(Me.dgMfg("MfgDateIssue", e.RowIndex).Value)

                        If dt.Year < 1990 OrElse dt.Year > 2012 Then
                            MsgBox("The Range of valid Years must be between 1990 an 2012")
                            Me.dgMfg("MfgDateIssue", e.RowIndex).Value = "MM/dd/yyyy"
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, _
                    MsgBoxStyle.OKOnly, "Mfg Date Issue: MM/dd/yyyy")
                    Me.dgMfg("MfgDateIssue", e.RowIndex).Value = "MM/dd/yyyy"
                End Try
        End Select
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgRev.EndEdit()
        dgMFGDwgRev.EndEdit()
        dgMat.EndEdit()
        dgProc.EndEdit()
        dgMfg.EndEdit()
        dgAssy.EndEdit()
        dgFromBlanks.EndEdit()
        dgPartList.EndEdit()
        dgRef.EndEdit()
        dgCross.EndEdit()

        dgProc.ReadOnly = True
        Me.Focus()
        txtPartNo.Focus()
        dgProc.Focus()
        Me.Focus()
        dgProc.ReadOnly = False
        txtPartNo.Focus()

        dgMat.ReadOnly = True
        dgMat.Focus()

        dgProc.AutoGenerateColumns = False
        dgProc.DataSource = dsMain
        dgProc.DataMember = "tblPartMaster.PartProc"
        dgProc.Refresh()

        ''To change the current row, to the last row:
        'Dim cellLastRow As DataGridViewCell = dgMat.Rows(dgMat.Rows.Count - 1).Cells(2)
        'dgMat.CurrentCell = cellLastRow

        Call ValPo()

        If SwVal = True Then
            DisableButton()
            DisableScreen()

            PartCurrency.EndCurrentEdit()
            MfgDwgNoCurrency.EndCurrentEdit()
            RevCurrency.EndCurrentEdit()
            ProcCurrency.EndCurrentEdit()
            MfgCurrency.EndCurrentEdit()
            MatCurrency.EndCurrentEdit()
            AssyCurrency.EndCurrentEdit()
            BlanksCurrency.EndCurrentEdit()
            PartListCurrency.EndCurrentEdit()
            PartRefCurrency.EndCurrentEdit()
            'PartCrossCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daPart.Update(dsMain.Tables("tblPartMaster").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    daMfgDwgNo.Update(dsMain.Tables("tblPartMfgDwgNo").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daRev.Update(dsMain.Tables("tblPartRev").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daMat.Update(dsMain.Tables("tblPartMatlPref").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daProc.Update(dsMain.Tables("tblPartProc").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daMfg.Update(dsMain.Tables("tblPartMfgSpec").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    daPart.Update(dsMain.Tables("tblPartMaster").Select("", "", DataViewRowState.Deleted))
                    daAssy.Update(dsMain.Tables("tblPartAssyComponents").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daFromBlanks.Update(dsMain.Tables("tblPartRelationBlank").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daPartsList.Update(dsMain.Tables("tblPartRelationBlank").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daRef.Update(dsMain.Tables("tblPartReference").Select("", "", DataViewRowState.Deleted Or DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    'daCross.Update(dsMain.Tables("tblPartCrossPN").Select("", "", DataViewRowState.ModifiedCurrent))

                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            If Len(Trim(CmbProductLine.Text)) = 0 Then
                If Len(Trim(txtDescrCode.Text)) > 0 Then
                    UpdateProductLine()
                End If
            End If

            dgRev.Refresh()
            dgMFGDwgRev.Refresh()
            dgMfg.Refresh()
            dgProc.Refresh()
            dgMat.Refresh()
            dgAssy.Refresh()
            dgFromBlanks.Refresh()
            dgPartList.Refresh()
            dgRef.Refresh()
            dgCross.Refresh()
            dsMain.AcceptChanges()

            ' call Reset button
            'dsMain.RejectChanges()
            DisableScreen()

            CmdNew.Enabled = True
            CmdEdit.Enabled = True
            CmdSave.Enabled = False
            CmdReset.Enabled = True
            CmdBrowse.Enabled = True

            'CmbPartNumber.SelectedIndex = -1

            CmbPartNumber.Enabled = False

            ResetButton()
            BindComponents()
        End If

    End Sub

    Sub UpdateProductLine()

        If CmbPartNumber.SelectedValue >= 1 Then
            'skip
        Else

            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateProductLineFromPartMaster", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraID As SqlParameter = New SqlParameter("@PartID", SqlDbType.Int, 4)
        paraID.Value = CmbPartNumber.SelectedValue
        mySqlComm.Parameters.Add(paraID)

        Dim paraDescr As SqlParameter = New SqlParameter("@PartDescCode", SqlDbType.NVarChar, 50)
        paraDescr.Value = txtDescrCode.Text
        mySqlComm.Parameters.Add(paraDescr)

        Dim paraNo As SqlParameter = New SqlParameter("@PartNumber", SqlDbType.NVarChar, 50)
        paraNo.Value = txtPartNo.Text
        mySqlComm.Parameters.Add(paraNo)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Product Line: " & ex.Message)
        Finally
            cn.Close()
        End Try


    End Sub


        Sub BindComponents()

        txtPartDate.DataBindings.Clear()
        txtPartNo.DataBindings.Clear()
        txtMfgDwgNo.DataBindings.Clear()
        txtDocNo.DataBindings.Clear()
        txtPNLengthUsage.DataBindings.Clear()
        txtPartName.DataBindings.Clear()
        txtDescrCode.DataBindings.Clear()
        txtNSN.DataBindings.Clear()
        txtLisiPart.DataBindings.Clear()
        txtRawWeight.DataBindings.Clear()
        txtPcsBar.DataBindings.Clear()
        txtFinalWeight.DataBindings.Clear()
        txtDateIssue.DataBindings.Clear()
        txtDateApproved.DataBindings.Clear()
        txtPartNotes.DataBindings.Clear()

        txtRevDesc.DataBindings.Clear()
        txtRevNotes.DataBindings.Clear()
        txtMfgSpec.DataBindings.Clear()
        txtMfgNotes.DataBindings.Clear()

        CmbUser.DataBindings.Clear()
        CmbCreatedBy.DataBindings.Clear()
        CmbApprovedBy.DataBindings.Clear()
        CmbDwgSource.DataBindings.Clear()
        cmbStatus.DataBindings.Clear()
        CmbProductLine.DataBindings.Clear()

        cmbPartType.DataBindings.Clear()
        CmbPartClasi.DataBindings.Clear()
        CmbProductLine.DataBindings.Clear()
        CmbCrossStatus.DataBindings.Clear()

        CmbProductLine.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.ProductLineID")
        CmbDwgSource.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.CustSourceID")
        txtPartNo.DataBindings.Add("Text", dsMain, "tblPartMaster.PartNumber")
        txtMfgDwgNo.DataBindings.Add("Text", dsMain, "tblPartMaster.PartMfgDwgNo")
        txtDocNo.DataBindings.Add("Text", dsMain, "tblPartMaster.DocNo")
        txtPNLengthUsage.DataBindings.Add("Text", dsMain, "tblPartMaster.PartLengthUsage")
        txtPartName.DataBindings.Add("Text", dsMain, "tblPartMaster.PartName")
        txtDescrCode.DataBindings.Add("Text", dsMain, "tblPartMaster.PartDescCode")
        txtNSN.DataBindings.Add("Text", dsMain, "tblPartMaster.NSNNumber")
        txtLisiPart.DataBindings.Add("Text", dsMain, "tblPartMaster.PartLisi")
        txtRawWeight.DataBindings.Add("Text", dsMain, "tblPartMaster.RawWeight")
        txtPcsBar.DataBindings.Add("Text", dsMain, "tblPartMaster.PcsPerBar")
        txtFinalWeight.DataBindings.Add("Text", dsMain, "tblPartMaster.FinalWeight")
        cmbStatus.DataBindings.Add("Text", dsMain, "tblPartMaster.PartStatus")
        cmbPartType.DataBindings.Add("Text", dsMain, "tblPartMaster.PartControlType", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")
        CmbCrossStatus.DataBindings.Add("Text", dsMain, "tblPartMaster.PNCrossStatus", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")
        CmbPartClasi.DataBindings.Add("Text", dsMain, "tblPartMaster.PartClasification", True, DataSourceUpdateMode.OnValidation, DBNull.Value, "")
        txtDateIssue.DataBindings.Add("Text", dsMain, "tblPartMaster.DateIssue", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")
        CmbCreatedBy.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.CreatedBy")
        txtDateApproved.DataBindings.Add("Text", dsMain, "tblPartMaster.DateApproved", True, DataSourceUpdateMode.OnValidation, "", "MM/dd/yyy")

        CmbApprovedBy.DataBindings.Add("SelectedValue", dsMain, "tblPartMaster.ApprovedBy")
        txtPartNotes.DataBindings.Add("Text", dsMain, "tblPartMaster.PartNotes")

        txtRevDesc.DataBindings.Add("Text", dsMain, "tblPartMaster.PartRev.RevDesc")
        txtRevNotes.DataBindings.Add("Text", dsMain, "tblPartMaster.PartRev.RevNotes")

        txtMfgSpec.DataBindings.Add("Text", dsMain, "tblPartMaster.PartMfg.MfgSpec")
        txtMfgNotes.DataBindings.Add("Text", dsMain, "tblPartMaster.PartMfg.MfgSpecNotes")

    End Sub

    Private Sub CmdSeeCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSeeCust.Click
        frmPartMasterDwgSource.ShowDialog()
    End Sub

    Private Sub CmdMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMat.Click
        frmEngMatlType.ShowDialog()

        PutMaterialTable()

    End Sub

    Sub PutMaterialTable()

        dsMain.Tables("tblMatlMasterDetails").Clear()
        CallClass.PopulateDataAdapter("getTblMatlMasterDetails").Fill(dsMain, "tblMatlMasterDetails")

        With Me.MatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "MatlID"
            .Name = "MatlID"
            .DropDownWidth = 400
            .MaxDropDownItems = 20
        End With

        With Me.MatlDetIDPref
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "MatlDetID"
            .Name = "MatlDetIDPref"
            .DropDownWidth = 400
            .MaxDropDownItems = 20
        End With

        With Me.ProcMatlID
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
            .DataPropertyName = "ProcMatlID"
            .Name = "ProcMatlID"
            .DropDownWidth = 300
            .MaxDropDownItems = 20
        End With

        With Me.ProcMatlTypeID
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
            .DataPropertyName = "ProcMatlTypeID"
            .Name = "ProcMatlTypeID"
            .DropDownWidth = 400
            .MaxDropDownItems = 20
        End With

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click
        ResetButton()

        txtDiaView.Text = ""
        txtLengthView.Text = ""
        GC.Collect()

        dsMain.Tables("tblPartCrossPN").Clear()

    End Sub

    Sub ResetButton()
        PartCurrency.EndCurrentEdit()

        dsMain.RejectChanges()
        dsMain.Tables("tblTemp").Clear()

        DisableScreen()

        HideControls()

        CmdNew.Enabled = True
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdBrowse.Enabled = True

        'CmbPartNumber.SelectedIndex = -1
        CmbPartNumber.Enabled = True

        CmdSeeCust.Enabled = False
        CmdMfgDwg.Enabled = False
        CmdMat.Enabled = False

        SwProcType = 0

    End Sub

    Private Sub CmbDwgSource_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbDwgSource.GotFocus
        With Me.CmbDwgSource
            .DataSource = CallClass.PopulateComboBox("tblPartDWGSource", "gettblPartDwgSource").Tables("tblPartDWGSource")
            .DisplayMember = "SourceName"
            .ValueMember = "DwgSourceID"
        End With
    End Sub

    Private Sub CmbPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPartNumber.SelectedIndexChanged

        Me.BindingContext(dsMain, "tblPartMaster").Position = CType(CmbPartNumber.SelectedIndex, String)

        BindComponents()

        dgProc.EndEdit()
        dgProc.Refresh()
        dgProc.Focus()

        RefreshTabPages()

    End Sub

    Sub PutDiaLength()

        If Len(Trim(txtDescrCode.Text)) = 0 Then
            CmdExec.Visible = False
            Exit Sub
        End If

        Dim ArrStr As String
        ArrStr = Trim(txtDescrCode.Text)
        Dim I As Integer = 0
        Dim NrOf As Integer = 0
        Dim KeepPos As Integer = 0

        For I = 0 To Len(ArrStr) - 1
            If ArrStr(I) = CChar("-") Then
                KeepPos = I
                NrOf = NrOf + 1
                If NrOf = 2 Then
                    txtDia.Text = Mid(ArrStr, KeepPos + 2, 3)
                End If
                If NrOf = 4 Then
                    txtLength.Text = Mid(ArrStr, KeepPos + 2, 2)
                End If
            End If
        Next

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        If CmbPartNumber.SelectedIndex = -1 Then
            MsgBox("Please select the P/N before editing.")
        Else
            CmdNew.Enabled = False
            CmdEdit.Enabled = False
            CmdSave.Enabled = True
            CmdReset.Enabled = True
            CmdBrowse.Enabled = False

            CmbPartNumber.Enabled = False
            Call EnableFields()

            ' ShowControlsBlanks()
            'PutDiaLength()
            'CmdExec.Visible = False
            'HideControls()

            RefreshTabControl()


        End If
      
    End Sub

    Sub ValPo()

        If Len(Trim(CmbCrossStatus.Text)) = 0 Or IsDBNull(CmbCrossStatus.Text) = True Then
            MsgBox("!!! ERROR !!! Cross Status is Empty.")
            SwVal = False
            Exit Sub
        End If

        Dim SwProdDescr As String = ""
        If CmbCrossStatus.Text = 20 Or CmbCrossStatus.Text = 99 Then
            SwProdDescr = CmbPartNumber.Text
            If InStr(SwProdDescr, "BACB30YK", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YM", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YN", vbTextCompare) <> 0 Or _
                InStr(SwProdDescr, "BACB30YL", vbTextCompare) <> 0 Then
                MsgBox("!!! ERROR !!! The P/N Cross Status should read 88.")
                SwVal = False
                Exit Sub
            End If
        End If

        If Len(Trim(cmbStatus.Text)) = 0 Or IsDBNull(cmbStatus.Text) = True Then
            MsgBox("!!! ERROR !!! Status is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(cmbPartType.Text)) = 0 Or IsDBNull(cmbPartType.Text) = True Then
            MsgBox("!!! ERROR !!! Part Control Type is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(CmbPartClasi.Text)) = 0 Or IsDBNull(CmbPartClasi.Text) = True Then
            MsgBox("!!! ERROR !!! Part Clasification is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtPartNo.Text)) = 0 Or IsDBNull(txtPartNo.Text) = True Then
            MsgBox("!!! ERROR !!! Part Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        'If Len(Trim(txtMfgDwgNo.Text)) = 0 Or IsDBNull(txtMfgDwgNo.Text) = True Then
        '    MsgBox("!!! ERROR !!! Mfg Dwg No.")
        '    SwVal = False
        '    Exit Sub
        'End If

        If Len(Trim(CmbDwgSource.SelectedValue)) = 0 Or IsDBNull(CmbDwgSource.SelectedValue) = True Or IsNothing(CmbDwgSource.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Dwg (Source) is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtDocNo.Text)) = 0 Or IsDBNull(txtDocNo.Text) = True Then
            MsgBox("!!! ERROR !!! Document Number is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtDescrCode.Text)) = 0 Or IsDBNull(txtDescrCode.Text) = True Then
            MsgBox("!!! ERROR !!! Descr. Code is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtRawWeight.Text)) = 0 Or IsDBNull(txtRawWeight.Text) = True Then
            MsgBox("!!! ERROR !!! Raw Weight is Empty.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtFinalWeight.Text)) = 0 Or IsDBNull(txtFinalWeight.Text) = True Then
            MsgBox("!!! ERROR !!! Final Weight is Empty.")
            SwVal = False
            Exit Sub
        End If

        Dim II As Integer = 0
        For Each RDeliv As DataGridViewRow In dgProc.Rows
            If Nz.Nz(RDeliv.Cells.Item("ProcMatlID").Value) = True Then
                II = II + 1
            End If
        Next
        If II >= 1 Then
            MsgBox("!!! ERROR !!! Material Family is Empty.")
            SwVal = False
            Exit Sub
        End If

        If CmbPartClasi.Text = "Assembly" Then
            II = 0
            For Each RAssy As DataGridViewRow In dgAssy.Rows
                If Nz.Nz(RAssy.Cells.Item("PartCompID").Value) = True Then
                    II = II + 1
                End If
            Next
            If II >= 1 Then
                MsgBox("!!! ERROR !!! Missing Assembly Components.")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbPartClasi.Text = "Assembly" Or CmbPartClasi.Text = "Blank" Then
            II = 0
            For Each RBlank As DataGridViewRow In dgFromBlanks.Rows
                If Nz.Nz(RBlank.Cells.Item("PNBlanksID").Value) = False Or RBlank.Cells.Item("PNRelStatus").Value = "Active" Then
                    II = II + 1
                End If
            Next
            If II > 1 Then
                MsgBox("!!! ERROR !!! For Part Number Classification Assembly or Blank we should not have data selected in BlanksList View ? ")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbPartClasi.Text = "Assembly" Or CmbPartClasi.Text = "Component" Or CmbPartClasi.Text = "Standard" Then
            II = 0
            For Each RBlank As DataGridViewRow In dgPartList.Rows
                If IsDBNull(RBlank.Cells.Item("PNStdCompID").Value) = False And RBlank.Cells.Item("PNRelStatus").Value = "Active" Then
                    II = II + 1
                End If
            Next
            If II >= 1 Then
                MsgBox("!!! ERROR !!! For Part Number Classification Assembly/Component/Standard we should not have data selected in PartsList View ? ")
                SwVal = False
                Exit Sub
            End If
        End If

        If CmbPartClasi.Text = "Blank" Then
            If Len(Trim(txtPNLengthUsage.Text)) = 0 Or IsDBNull(txtPNLengthUsage.Text) = True Then
                MsgBox("!!! ERROR !!! P/N Maximum Length Usage is Empty.")
                SwVal = False
                Exit Sub
            End If
        End If


        Dim GG As Integer
        GG = 0
        If dgCross.Rows.Count >= 1 Then
            For Each Row As DataGridViewRow In dgCross.Rows
                If IsDBNull(Row.Cells("CrossReferenceID").Value) = False And IsNothing(Row.Cells("CrossReferenceID").Value) = False Then
                    If IsDBNull(Row.Cells("CrossMasterID").Value) = False And IsNothing(Row.Cells("CrossMasterID").Value) = False Then
                        If Row.Cells("CrossStatus").Value <> "Approved" Then
                            If GG = 0 Then
                                MsgBox("!!! ERROR !!! Please Approve at least one Cross P/N.")
                                SwVal = False
                                Exit Sub
                            End If
                        Else
                            GG = GG + 1
                        End If
                    End If
                End If
            Next
        End If



        SwVal = True

    End Sub

    Private Sub dgRev_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRev.DataError
        REM end
    End Sub

    Private Sub dgRev_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgRev.RowPrePaint
        If IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevStatus").Value) = False Then
            If dgRev.Rows(e.RowIndex).Cells("RevStatus").Value = "InActive" Then
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub dgMfg_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMfg.DataError
        REM end
    End Sub

    Private Sub dgMfg_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgMfg.RowPrePaint
        If IsDBNull(dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value) = False Then
            If dgMfg.Rows(e.RowIndex).Cells("MfgStatus").Value = "InActive" Then
                dgMfg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgMfg.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBrowse.Click
        frmPartMasterBrowse.ShowDialog()
    End Sub

    Private Sub CmbApprovedBy_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbApprovedBy.DropDownClosed

        If IsNothing(CmbCreatedBy.SelectedValue) = False Then
            If CmbCreatedBy.SelectedValue = wkEmpId Then
                MsgBox("Access Denied. Created by = Approved by.")
                CmbApprovedBy.SelectedIndex = -1
            Else
                CmbApprovedBy.SelectedValue = wkEmpId
                txtDateApproved.Text = Now.ToShortDateString
            End If
        Else
            MsgBox("Access Denied. Created by is empty.")
            CmbApprovedBy.SelectedIndex = -1
        End If

    End Sub

    Private Sub dgProc_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgProc.CellBeginEdit

        If dgProc.Columns(0).ReadOnly = True Then
            MsgBox("Click on Edit Part# - Action Denied.")
            e.Cancel = True
            Exit Sub
        End If

        If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcType").Value) = False Then
            If dgProc.Rows(e.RowIndex).Cells("ProcType").Value = "Frozen" And SwProcType = 0 Then
                MsgBox("The Process Sheet is Frozen. Action Denied.")
                e.Cancel = True
                Exit Sub
            End If
        End If

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgProc = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 8, 9, 10, 11, 13
                e.Cancel = True

            Case 2

                'If IsDBNull(dgMat.Rows(e.RowIndex).Cells("MatlID").Value) = True Or _
                '    IsNothing(dgMat.Rows(e.RowIndex).Cells("MatlID").Value) = True Then
                '    MsgBox("Please assign Preferred Material to this Part Number.")
                '    e.Cancel = True

                'dgMat.Refresh()
                'dgMat.Rows(e.RowIndex).Selected = True
                'dgMat.CurrentCell = dgMat.Rows(2).Cells(0)

                Try
                    If IsDBNull(dgMat.Rows(0).Cells("MatlID").Value) = True Or _
                                       IsNothing(dgMat.Rows(0).Cells("MatlID").Value) = True Then
                        MsgBox("Please assign Preferred Material to this Part Number.")
                        e.Cancel = True
                    Else
                        If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcNo").Value) = False And _
                        IsNothing(dgProc.Rows(e.RowIndex).Cells("ProcNo").Value) = False Then
                            Dim reply As DialogResult
                            reply = MsgBox("Do you want to change the Process Number ?", MsgBoxStyle.YesNo)
                            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
                        Else
                            e.Cancel = False
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Please assign Preferred Material to this Part Number.")
                    e.Cancel = True
                End Try



                'Case 3
                '    If dgMat.Rows(0).Cells("ProcType").Value = "Frozen" Then
                '        MsgBox("The Process Sheet is Frozen. Action Denied.")
                '        e.Cancel = True
                '    End If

            Case 7

                Dim dgcb As DataGridViewComboBoxCell = CType(dgProc("ProcMatlTypeID", e.RowIndex), DataGridViewComboBoxCell)

                If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcMatlID").Value) = False Then
                    Dim Swmat As Integer
                    Swmat = dgProc.Rows(e.RowIndex).Cells("ProcMatlID").Value
                    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                End If

            Case Else
                If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcNo").Value) = True Or _
                    IsNothing(dgProc.Rows(e.RowIndex).Cells("ProcNo").Value) = True Then
                    MsgBox("Process Number is empty. Action Denied.")
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
        End Select

    End Sub

    Private Sub dgProc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProc.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgProc = e.RowIndex
        End If

        If dgProc.ReadOnly = True Then
            Exit Sub
        End If

        If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcType").Value) = True Then
            Exit Sub
        End If

        If e.ColumnIndex = 16 Or 17 Or 18 Then

            Select Case e.ColumnIndex
                Case 16
                    Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                    Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                    Dim rptPO As New rptProcessMethod

                    rptPO.Load("..\rptProcessMethod.rpt")
                    pdvCustomerName.Value = dgProc.Rows(e.RowIndex).Cells("ProcID").Value
                    pvCollection.Add(pdvCustomerName)
                    rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.ShowDialog()

                Case 17
                    If dgProc.Columns(0).ReadOnly = False Then
                        If dgProc.Rows(e.RowIndex).Cells("ProcID").Value <= 0 Then
                            MsgBox("Save Part Master Data before")
                        Else
                            If dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value = "Cancelled" Then
                                MsgBox("Status Cancelled - Action Denied")
                            Else
                                If dgProc.Item("ProcType", e.RowIndex).Value = "Frozen" And SwProcType = 0 Then
                                    frmPartProcess.SwProc.Text = 1   'process frozen
                                Else
                                    frmPartProcess.SwProc.Text = 0   'process standard
                                End If

                                frmPartProcess.SwForm.Text = dgProc.Rows(e.RowIndex).Cells("ProcID").Value
                                frmPartProcess.ShowDialog()

                            End If
                        End If
                    Else
                        MsgBox("Click on Edit Part# - Action Denied.")
                    End If

                Case 18

                    If dgProc.Item("ProcType", e.RowIndex).Value = "Frozen" And SwProcType = 0 Then
                        frmPartProcMpoSrc.SwProcRevised.Text = "True"
                    Else
                        frmPartProcMpoSrc.SwProcRevised.Text = "False"
                    End If

                    If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value) = False Then
                        If dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value = "Cancelled" Then
                            MsgBox("Status Cancelled - Action Denied")
                        Else
                            If IsNothing(dgProc.Rows(e.RowIndex).Cells("PartID").Value) = False Then
                                frmPartProcMpoSrc.SwPartID.Text = dgProc.Rows(e.RowIndex).Cells("PartID").Value
                                frmPartProcMpoSrc.SwProcID.Text = dgProc.Rows(e.RowIndex).Cells("ProcID").Value
                                frmPartProcMpoSrc.SwPartRevSave.Text = dgProc.Rows(e.RowIndex).Cells("PartNoRevSave").Value

                                frmPartProcMpoSrc.ShowDialog()
                                frmPartProcMpoSrc.Dispose()
                            Else
                                MsgBox("!!! ERROR !!! Missing Process Number.")
                            End If
                        End If
                    Else
                        MsgBox("!!! ERROR !!! Missing Process Number.")
                    End If
            End Select
        Else
            If dgProc.Columns(0).ReadOnly = False Then
                If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcNo").Value) = False Then
                    If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value) = False Then
                        If dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value = "Cancelled" Then
                            MsgBox("Status Revision = Cancelled  -  ReadOnly")
                            Dim reply As DialogResult
                            reply = MsgBox("Do you want to Reset Revision Status ? ", MsgBoxStyle.YesNo)
                            If reply = Windows.Forms.DialogResult.Yes Then
                                dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value = "Active"
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgProc_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProc.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgProc = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 2      'proc no

                Dim II As Integer = 0

                For Each RProc As DataGridViewRow In dgProc.Rows
                    If RProc.Cells.Item("ProcNo").Value = dgProc.Item("ProcNo", e.RowIndex).Value Then
                        II = II + 1
                    End If
                Next
                If II > 1 Then
                    MsgBox("!!! ERROR !!! Process Number. Action denied.")
                    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                        Try
                            dgProc.Rows.RemoveAt(e.RowIndex)
                            ''To change the current row, to the last row:
                            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                            dgProc.CurrentCell = cellLastRow
                            Exit Sub
                        Catch ex As SqlException
                        End Try
                    End If
                End If

                '====
                If IsDBNull(dgMat.Item("MatlForm", RowdgMat).Value) = True Then
                    MsgBox("!!! ERROR !!! Missing Matl Form.")
                    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                        Try
                            dgProc.Rows.RemoveAt(e.RowIndex)
                            ''To change the current row, to the last row:
                            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                            dgProc.CurrentCell = cellLastRow
                            Exit Sub
                        Catch ex As SqlException
                        End Try
                    End If
                End If

                ''====
                'If Nz.Nz(dgMat.Item("MatlForm", RowdgMat).Value) = 0 Then
                '    MsgBox("!!! ERROR !!! Missing Matl Form.")
                '    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                '        Try
                '            dgProc.Rows.RemoveAt(e.RowIndex)
                '            ''To change the current row, to the last row:
                '            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                '            dgProc.CurrentCell = cellLastRow
                '            Exit Sub
                '        Catch ex As SqlException
                '        End Try
                '    End If
                'End If

                ''====
                'If dgMat.RowCount <= 0 Then
                '    MsgBox("!!! ERROR !!! Missing Matl Form.")
                '    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                '        Try
                '            dgProc.Rows.RemoveAt(e.RowIndex)
                '            ''To change the current row, to the last row:
                '            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                '            dgProc.CurrentCell = cellLastRow
                '            Exit Sub
                '        Catch ex As SqlException
                '        End Try
                '    End If
                'End If

                '====
                If IsDBNull(dgMat.Item("MatlDia", RowdgMat).Value) = True Then
                    MsgBox("!!! ERROR !!! Missing Matl Dia.")
                    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                        Try
                            dgProc.Rows.RemoveAt(e.RowIndex)
                            ''To change the current row, to the last row:
                            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                            dgProc.CurrentCell = cellLastRow
                            Exit Sub
                        Catch ex As SqlException
                        End Try
                    End If
                End If

                '========
                If IsDBNull(dgRev.Item("RevNo", 0).Value) = True Or _
                    IsNothing(dgRev.Item("RevNo", 0).Value) = True Then
                    MsgBox("!!! ERROR !!! Missing Part Number Revision. After you enter the PN Revision you must SAVE and ReStart the Module.")
                    If e.RowIndex <= dgProc.Rows.Count - 1 Then
                        Try
                            dgProc.Rows.RemoveAt(e.RowIndex)
                            ''To change the current row, to the last row:
                            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 1).Cells(2)
                            dgProc.CurrentCell = cellLastRow
                            Exit Sub
                        Catch ex As SqlException
                        End Try
                    End If
                End If

                '=====
                If IsDBNull(dgProc.Item("ProcNo", e.RowIndex).Value) = False Then
                    If IsDBNull(dgProc.Item("CreatedBy", e.RowIndex).Value) = True Then
                        dgProc.Item("CreatedBy", e.RowIndex).Value = wkEmpId
                        dgProc.Item("CreatedDate", e.RowIndex).Value = Now.ToShortDateString
                    End If

                    If IsDBNull(dgProc.Item("ProcStatus", e.RowIndex).Value) = True Then
                        dgProc.Item("ProcStatus", e.RowIndex).Value = "Active"
                    End If

                    If IsDBNull(dgProc.Item("ProcType", e.RowIndex).Value) = True Then
                        dgProc.Item("ProcType", e.RowIndex).Value = "Standard"
                    End If

                    'put last rev
                    Dim SwRet As String

                    SwRet = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRev", CmbPartNumber.SelectedValue)
                    If SwRet <> "False" Then
                        dgProc.Item("PartNoRevSave", e.RowIndex).Value = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRev", CmbPartNumber.SelectedValue)
                        dgProc.Item("PartNoRevDate", e.RowIndex).Value = CallClass.ReturnStrWithParInt("cspReturnPSlipLastRevDate", CmbPartNumber.SelectedValue)

                        Dim RDate As Date
                        RDate = dgProc.Item("PartNoRevDate", e.RowIndex).Value
                        dgProc.Item("PartNoRevDate", e.RowIndex).Value = RDate.ToShortDateString
                    End If

                    'dia, material, material type

                    If IsDBNull(dgMat.Rows(RowdgMat).Cells("MatlID").Value) = False And _
                        IsNothing(dgMat.Rows(RowdgMat).Cells("MatlID").Value) = False Then
                        dgProc.Rows(e.RowIndex).Cells("ProcMatlID").Value = dgMat.Rows(RowdgMat).Cells("MatlID").Value
                    End If

                    dgProc.Rows(e.RowIndex).Cells("ProcMatlTypeID").Value = dgMat.Rows(RowdgMat).Cells("MatlDetIDPref").Value
                    dgProc.Rows(e.RowIndex).Cells("ProcMatlForm").Value = dgMat.Rows(RowdgMat).Cells("MatlForm").Value
                    dgProc.Rows(e.RowIndex).Cells("ProcDia").Value = dgMat.Rows(RowdgMat).Cells("MatlDia").Value

                End If

            Case 3
                If dgProc.Item("ProcType", e.RowIndex).Value = "Frozen" Then
                    SwprocType = 99     'means i change now the proc type
                End If
            Case 12
                If IsDBNull(dgProc.Item("ReviewBy", e.RowIndex).Value) = False Then
                    If IsDBNull(dgProc.Item("ReviewDate", e.RowIndex).Value) = True Then
                        dgProc.Item("ReviewDate", e.RowIndex).Value = Now.ToShortDateString
                    End If
                End If

        End Select

    End Sub

    Private Sub dgProc_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProc.DataError
        REM end
    End Sub

    Private Sub dgProc_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgProc.RowPrePaint
        If IsDBNull(dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value) = False Then
            If dgProc.Rows(e.RowIndex).Cells("ProcStatus").Value = "Cancelled" Then
                dgProc.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgProc.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub dgMatDet_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        Select Case e.ColumnIndex
            Case 0, 1
                e.Cancel = True
            Case 3 To 8
                e.Cancel = True
            Case 2
                If IsDBNull(dgMat.Rows(RowdgMat).Cells("MatlID").Value) = True Or _
                    IsNothing(dgMat.Rows(RowdgMat).Cells("MatlID").Value) = True Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub dgMat_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMat.CellBeginEdit
        If e.RowIndex < 0 Then
            e.Cancel = True
            Exit Sub
        Else
            RowdgMat = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0, 1

                e.Cancel = True

            Case 3

                Dim dgcb As DataGridViewComboBoxCell = CType(dgMat("MatlDetIDPref", e.RowIndex), DataGridViewComboBoxCell)

                If IsDBNull(dgMat.Rows(e.RowIndex).Cells("MatlID").Value) = False Then
                    Dim Swmat As Integer
                    Swmat = dgMat.Rows(e.RowIndex).Cells("MatlID").Value
                    dgcb.DataSource = CallClass.PopulateComboBoxWithParam("tblMatlMasterDetails", "cmbGetMatlDetailTypeByMaterialID", Swmat).Tables("tblMatlMasterDetails")
                End If
        End Select

    End Sub

    Private Sub dgMat_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMat.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgMat = e.RowIndex
        End If

    End Sub

    Private Sub dgMat_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMat.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowdgMat = e.RowIndex
        End If

        If e.ColumnIndex = 2 Then
            If IsDBNull(dgMat.Rows(e.RowIndex).Cells("MatlDia").Value) = True Then
                dgMat.Rows(e.RowIndex).Cells("MatlDia").Value = 0
            End If

            If IsDBNull(dgMat.Rows(e.RowIndex).Cells("MatlForm").Value) = True Then
                dgMat.Rows(e.RowIndex).Cells("MatlForm").Value = "Bars"
            End If

            dgMat.Rows(e.RowIndex).Cells("MatlDetIDPref").Value = DBNull.Value
        End If

    End Sub

    Private Sub dgMat_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMat.DataError
        REM end
    End Sub

    Sub CalculMpoValue()
        Dim MpoVal As Double = 0.0

        For Each Row As DataGridViewRow In dgMpo.Rows
            MpoVal = Nz.Nz(Row.Cells("QtyActual").Value) * Nz.Nz(Row.Cells("OrdItemPrice").Value)
            Row.Cells("MpoValue").Value = MpoVal
        Next
    End Sub

    Sub CalculActRelOrd()

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("QtyActual").Value)
        Next
        txtActual.Text = qty.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("QtyEngReleased").Value)
        Next
        txtEngRel.Text = qty.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("QtyOrder").Value)
        Next
        txtOrd.Text = qty.ToString("N0")

        qty = 0.0
        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + Nz.Nz(Row.Cells("MpoValue").Value)
        Next
        txtValue.Text = qty.ToString("C2")

        qty = 0.0
        For Each Row As DataGridViewRow In dgMpo.Rows
            qty = qty + 1
        Next
        txtRelNo.Text = qty.ToString("N0")

    End Sub

    Private Sub CmbPartNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CmbPartNumber.Validating
        If CmbPartNumber.SelectedValue >= 1 Then
            dsMain.Tables("tblMpoMaster").Clear()

            CallClass.PopulateDataAdapterAfterSearch("getMpoProdReleased", CmbPartNumber.SelectedValue).Fill(dsMain, "tblMpoMaster")

            'dsMain.Tables("tblPartRelationBlank").Clear()
            dsMain.Tables("tblTemp").Clear()
            CallClass.PopulateDataAdapter("gettblPartRelationBlank").Fill(dsMain, "tblPartRelationBlank")

        End If
        CalculMpoValue()
        CalculActRelOrd()

        CmbPartNumber.Enabled = False
    End Sub

    Private Sub dgMpo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMpo.CellBeginEdit

        If e.RowIndex < 0 Then
            e.Cancel = True
            Exit Sub
        Else
            RowMpo = e.RowIndex
        End If

        OldQtyEng = Nz.Nz(dgMpo("QtyEngReleased", e.RowIndex).Value)
        OldQtyReq = Nz.Nz(dgMpo("QtyOrder", e.RowIndex).Value)

        If dgMpo.Item("MpoStatus", e.RowIndex).Value <> "Active" Then
            MsgBox("Action Denied. Mpo Status is not Active.")
            e.Cancel = True
        Else
            Select Case e.ColumnIndex
                Case 0 To 6
                    e.Cancel = True
                Case 9 To 24
                    e.Cancel = True
                Case 7
                    If IsDBNull(dgMpo("MpoEngInfo", e.RowIndex).Value) = True Then
                    Else
                        If Len(Trim(dgMpo("MpoEngInfo", e.RowIndex).Value)) > 0 Then
                            MsgBox("Action Denied.")
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
            End Select

        End If

    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMpo = e.RowIndex

        OldQtyEng = Nz.Nz(dgMpo("QtyEngReleased", e.RowIndex).Value)
        OldQtyReq = Nz.Nz(dgMpo("QtyOrder", e.RowIndex).Value)

    End Sub

    Private Sub dgMpo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim reply As DialogResult

        Select Case e.ColumnIndex

            Case 7 'qty released

                reply = MsgBox("Edit Quantity Released ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateQtyReleased()
                Else
                    dgMpo("QtyEngReleased", RowMpo).Value = OldQtyEng
                End If

            Case 8 'qty sales requested

                reply = MsgBox("Edit Sales Quantity Requested ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    UpdateQtyRequested()
                Else
                    dgMpo("QtyOrder", RowMpo).Value = OldQtyReq
                End If

                'Case 9  'Dept
                '    If RoleEng(wkDeptCode) = True Then
                '        Dim SwDept As Integer = 0
                '        Dim SwProd As String = ""

                '        SwDept = dgMpo("DeptID", e.RowIndex).Value
                '        SwProd = CallClass.ReturnStrWithParInt("cspReturnRoleEng", SwDept)
                '        If SwProd <> "1" Then
                '            MsgBox("Access denied.")
                '            dgMpo("DeptID", RowMpo).Value = OldDept
                '            Exit Sub
                '        End If
                '    End If

                '    UpdateMpoDept()

                '    dsMain.Tables("tblMpoRouting").Clear()
                '    CallClass.PopulateDataAdapter("gettblMpoRouting").Fill(dsMain, "tblMpoRouting")
        End Select

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

    Private Sub dgMpo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEnter
        CalculMpoValue()
        CalculActRelOrd()
    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Sub UpdateMpoDept()

        If IsDBNull(dgMpo("DeptID", RowMpo).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDeptID", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
        paraMpo.Value = dgMpo("MpoID", RowMpo).Value
        mySqlComm.Parameters.Add(paraMpo)

        Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
        paraDept.Value = dgMpo("DeptID", RowMpo).Value
        mySqlComm.Parameters.Add(paraDept)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Dept.: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateQtyReleased()

        If IsDBNull(dgMpo("QtyEngReleased", RowMpo).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtyReleased", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgMpo("MpoID", RowMpo).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgMpo("QtyEngReleased", RowMpo).Value
            mySqlComm.Parameters.Add(paraQty)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Update Mpo Qty Released: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateQtyRequested()

        If IsDBNull(dgMpo("QtyOrder", RowMpo).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoQtySales", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgMpo("MpoID", RowMpo).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyOrder", SqlDbType.Real, 4)
            paraQty.Value = dgMpo("QtyOrder", RowMpo).Value
            mySqlComm.Parameters.Add(paraQty)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        
        Catch ex As Exception
            MsgBox("Update Mpo Sales Qty Requested: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub dgMat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgMat.KeyDown

        If e.KeyCode = Keys.Delete Then
            If dgMat.ReadOnly = True Then
                MsgBox("Click on Edit Part# - Action Denied.")
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CmdMfgDwg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMfgDwg.Click
        Dim reply As DialogResult

        reply = MsgBox("Do you want to Generate a New MFG Dwg Number ? ", MsgBoxStyle.YesNo)

        If reply = Windows.Forms.DialogResult.Yes Then

            txtMfgDwgNo.Text = CallClass.GenerateNextLot("cspGetNextLot", "MFGDWGNO")
            If txtMfgDwgNo.Text = "ERROR" Then
                Exit Sub
            Else
                KeepNo = Val(txtMfgDwgNo.Text)
                txtMfgDwgNo.Text = Trim(txtMfgDwgNo.Text)

                UpdateNextMfgDwg()

            End If
        End If
    End Sub

    Sub UpdateNextMfgDwg()
        CallClass.ExecuteUpdateTwoParams("cspUpdateNextLot", "MFGDWGNO", KeepNo)
    End Sub

    Private Sub dgMFGDwgRev_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgMFGDwgRev.CellBeginEdit
        If e.RowIndex < 0 Then
            e.Cancel = True
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 3, 6
                e.Cancel = True
            Case 2
                If IsDBNull(dgMFGDwgRev.Item("MfgDwgRevNo", e.RowIndex).Value) = False Then
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Change the Mfg Dwg Revision ? (If Yes - the Date and Created By will be change also.)", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.No Then
                        e.Cancel = True
                    Else
                        e.Cancel = False
                    End If
                Else
                    Exit Sub
                End If
        End Select

    End Sub

    Private Sub dgMFGDwgRev_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMFGDwgRev.CellEndEdit

        Select Case e.ColumnIndex
            Case 2      'revno
                If IsDBNull(dgMFGDwgRev.Item("MfgDwgRevNo", e.RowIndex).Value) = False Then
                    dgMFGDwgRev.Item("MfgDwgDate", e.RowIndex).Value = Now.ToShortDateString
                    dgMFGDwgRev.Item("MfgDwgCreatedBy", e.RowIndex).Value = wkEmpId
                Else
                    Exit Sub
                End If

        End Select

    End Sub

    Private Sub dgMFGDwgRev_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMFGDwgRev.DataError
        REM end
    End Sub

    Private Sub TabPage5_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Enter
        dsMain.Tables("tblMpoMaster").Clear()
        CallClass.PopulateDataAdapter("getTblMpoMasterAndDept").Fill(dsMain, "tblMpoMaster")
    End Sub

    Private Sub dgAssy_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgAssy.CellBeginEdit

        Select Case e.ColumnIndex
            Case 3
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgAssy_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssy.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            If dgAssy.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value) = False Then
                If dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value = "InActive" Then
                    MsgBox("Status Revision = InActive  -  ReadOnly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Revision Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value = "Active"
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgAssy_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAssy.CellEndEdit

        Select Case e.ColumnIndex
            Case 2      ' Part Id PartCompID
                If IsDBNull(dgAssy.Item("PartCompID", e.RowIndex).Value) = True Then
                    Exit Sub
                End If

                dgAssy.Rows(e.RowIndex).Cells("PartAssyName").Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgAssy.Item("PartCompID", e.RowIndex).Value)


                If Convert.ToString(Len(Trim(dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").ToString))) = 0 Or _
                    IsDBNull(dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value) = True Then
                    dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value = "Active"
                Else
                    Exit Sub
                End If
        End Select

    End Sub

    Private Sub dgAssy_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgAssy.DataError
        REM end
    End Sub

    Private Sub dgAssy_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgAssy.RowPrePaint

        If IsDBNull(dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value) = False Then
            If dgAssy.Rows(e.RowIndex).Cells("PartAssyStatus").Value = "InActive" Then
                dgAssy.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgAssy.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If

    End Sub

    Private Sub TabPage7_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Enter
        Dim II As Integer

        For II = 1 To dgAssy.Rows.Count - 1
            If IsDBNull(dgAssy.Item("PartCompID", II - 1).Value) = False Then
                dgAssy.Item("PartAssyName", II - 1).Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgAssy.Item("PartCompID", II - 1).Value)
            End If
        Next

    End Sub

    Sub RefreshTabPages()

        If TabControl1.TabPages.Contains(TabPage4) = False Then
            TabControl1.TabPages.Insert(Index4, Pages4)     'add Preferred MaterIAL
        End If
        If TabControl1.TabPages.Contains(TabPage8) = False Then
            TabControl1.TabPages.Insert(Index8, Pages8)     'ADD From Blanks
        End If
        If TabControl1.TabPages.Contains(TabPage7) = False Then
            TabControl1.TabPages.Insert(Index7, Pages7)      'ADD Assy Components
        End If
        If TabControl1.TabPages.Contains(TabPage9) = False Then
            TabControl1.TabPages.Insert(Index9, Pages9)      'ADD Parts List
        End If
        If TabControl1.TabPages.Contains(TabPage12) = False Then
            TabControl1.TabPages.Insert(Index12, Pages12)      'ADD cross / dual
        End If

        RefreshTabControl()

    End Sub

    Sub RefreshTabControl()

        Select Case CmbPartClasi.Text
            Case "Blank"
                If TabControl1.TabPages.Contains(TabPage8) = True Then
                    TabControl1.TabPages.Remove(TabPage8)       'delete From Blanks
                End If
                If TabControl1.TabPages.Contains(TabPage7) = True Then
                    TabControl1.TabPages.Remove(TabPage7)       'delete Assy Components
                End If

                ShowControlsBlanks()
                PutDiaLength()

            Case "Assembly"
                If TabControl1.TabPages.Contains(TabPage4) = True Then
                    TabControl1.TabPages.Remove(TabPage4)       'delete Preferred MaterIAL
                End If
                If TabControl1.TabPages.Contains(TabPage8) = True Then
                    TabControl1.TabPages.Remove(TabPage8)       'delete From Blanks
                End If

                ShowControlsBlanks()
                PutDiaLength()
                CmdExec.Visible = False
                'HideControls()

            Case "Component"
                If TabControl1.TabPages.Contains(TabPage7) = True Then
                    TabControl1.TabPages.Remove(TabPage7)       'delete Assy Components
                End If

                If TabControl1.TabPages.Contains(TabPage9) = True Then
                    TabControl1.TabPages.Remove(TabPage9)       'delete Parts List
                End If

                ShowControlsBlanks()
                PutDiaLength()
                CmdExec.Visible = False
                'HideControls()

            Case Else
                If TabControl1.TabPages.Contains(TabPage7) = True Then
                    TabControl1.TabPages.Remove(TabPage7)       'delete Assy Components
                End If
                If TabControl1.TabPages.Contains(TabPage9) = True Then
                    TabControl1.TabPages.Remove(TabPage9)       'delete Parts List
                End If

                ShowControlsBlanks()
                PutDiaLength()
                CmdExec.Visible = False
                'HideControls()

        End Select

    End Sub

    Private Sub CmbPartClasi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPartClasi.TextChanged
        RefreshTabPages()
    End Sub

    Private Sub dgFromBlanks_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgFromBlanks.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowFromBlank = e.RowIndex

        Select Case e.ColumnIndex
            Case 3, 4
                e.Cancel = True
        End Select
    End Sub

    Private Sub dgFromBlanks_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFromBlanks.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowFromBlank = e.RowIndex

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            If dgFromBlanks.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value) = False Then
                If dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value = "InActive" Then
                    MsgBox("Status Revision = InActive  -  ReadOnly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Revision Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value = "Active"
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub dgFromBlanks_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFromBlanks.CellEndEdit

        Select Case e.ColumnIndex
            Case 2      ' PNBlanksID
                If IsDBNull(dgFromBlanks.Item("PNBlanksID", e.RowIndex).Value) = True Then
                    Exit Sub
                End If

                If Len(dgFromBlanks.Item("PNBlanksID", e.RowIndex).Value) = 0 Then
                    Exit Sub
                End If

                dgFromBlanks.Rows(e.RowIndex).Cells("PNBlankName").Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgFromBlanks.Item("PNBlanksID", e.RowIndex).Value)
                dgFromBlanks.Rows(e.RowIndex).Cells("PNBlankDescrCode").Value = CallClass.ReturnStrWithParInt("cspReturnPartDescrCode", dgFromBlanks.Item("PNBlanksID", e.RowIndex).Value)

                PutDiaLengthForGrid()

                If Convert.ToString(Len(Trim(dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").ToString))) = 0 Or _
                    IsDBNull(dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value) = True Then
                    dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value = "Active"
                Else
                    Exit Sub
                End If
        End Select

        dgFromBlanks.Refresh()

    End Sub

    Sub PutDiaLengthForGrid()

        Dim ArrStr As String
        Dim I As Integer = 0
        Dim NrOf As Integer = 0
        Dim KeepPos As Integer = 0

        Select Case CmbPartClasi.Text
            Case "Standard", "Component"
                If dgFromBlanks.Rows.Count <= 1 Then
                    Exit Sub
                End If

                If Len(dgFromBlanks("PNBlankDescrCode", RowFromBlank).Value) = 0 Then
                    MsgBox("Missing Description Code for the Selected Blank.")
                    Exit Sub
                End If

                ArrStr = Trim(dgFromBlanks("PNBlankDescrCode", RowFromBlank).Value)
                For I = 0 To Len(ArrStr) - 1
                    If ArrStr(I) = CChar("-") Then
                        KeepPos = I
                        NrOf = NrOf + 1
                        If NrOf = 2 Then
                            txtDiaView.Text = Mid(ArrStr, KeepPos + 2, 2)
                        End If
                        If NrOf = 4 Then
                            txtLengthView.Text = Mid(ArrStr, KeepPos + 2, 2)
                        End If
                    End If
                Next

                If Val(txtDiaView.Text) <> Val(txtDia.Text) Then
                    MsgBox("!!! ERROR !!! Diameter:" + vbCrLf + _
                        "PartNumber:  " + txtDia.Text + vbCrLf + _
                        "Blank:       " + txtDiaView.Text)
                End If
                If Val(txtLengthView.Text) < Val(txtLength.Text) Then
                    MsgBox("!!! ERROR !!! Length:" + vbCrLf + _
                        "PartNumber:  " + txtLength.Text + vbCrLf + _
                        "Blank:       " + txtLengthView.Text)
                End If

            Case "Blank"
                If dgPartList.Rows.Count <= 1 Then
                    Exit Sub
                End If

                If Len(dgPartList("PrtListPNBlankDescrCode", RowPartsList).Value) = 0 Then
                    MsgBox("Missing Description Code for the Selected Part Number.")
                    Exit Sub
                End If

                ArrStr = Trim(dgPartList("PrtListPNBlankDescrCode", RowFromBlank).Value)
                For I = 0 To Len(ArrStr) - 1
                    If ArrStr(I) = CChar("-") Then
                        KeepPos = I
                        NrOf = NrOf + 1
                        If NrOf = 2 Then
                            txtDiaView.Text = Mid(ArrStr, KeepPos + 2, 2)
                        End If
                        If NrOf = 4 Then
                            txtLengthView.Text = Mid(ArrStr, KeepPos + 2, 2)
                        End If
                    End If
                Next

                If Val(txtDiaView.Text) <> Val(txtDia.Text) Then
                    MsgBox("!!! ERROR !!! Diameter:" + vbCrLf + _
                        "PartNumber:  " + txtDia.Text + vbCrLf + _
                        "Blank:       " + txtDiaView.Text)
                End If
                If Val(txtLengthView.Text) < Val(txtLength.Text) Then
                    MsgBox("!!! ERROR !!! Length:" + vbCrLf + _
                        "PartNumber:  " + txtLength.Text + vbCrLf + _
                        "Blank:       " + txtLengthView.Text)
                End If

        End Select

    End Sub

    Private Sub dgFromBlanks_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgFromBlanks.CellEnter
       PutInfodgFromBlanks
    End Sub

    Private Sub dgFromBlanks_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgFromBlanks.DataError
        REM end
    End Sub

    Private Sub dgFromBlanks_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgFromBlanks.RowPrePaint

        If IsDBNull(dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value) = False Then
            If dgFromBlanks.Rows(e.RowIndex).Cells("PNRelStatus").Value = "InActive" Then
                dgFromBlanks.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgFromBlanks.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub TabPage8_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Enter

        PutInfodgFromBlanks()

    End Sub

    Sub PutInfodgFromBlanks()

        Dim II As Integer

        For II = 1 To dgFromBlanks.Rows.Count - 1
            If IsDBNull(dgFromBlanks.Item("PNBlanksID", II - 1).Value) = False Then
                If Len(dgFromBlanks.Item("PNBlanksID", II - 1).Value) > 0 Then
                    dgFromBlanks.Item("PNBlankName", II - 1).Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgFromBlanks.Item("PNBlanksID", II - 1).Value)
                    dgFromBlanks.Item("PNBlankDescrCode", II - 1).Value = CallClass.ReturnStrWithParInt("cspReturnPartDescrCode", dgFromBlanks.Item("PNBlanksID", II - 1).Value)
                End If
            End If
        Next

    End Sub
    Private Sub txtDescrCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDescrCode.Validating

        PutDiaLength()
        PutDiaLengthForGrid()

    End Sub

    Private Sub CmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExec.Click
        If Len(Trim(txtPrefix.Text)) = 0 Then
            MsgBox("!!! ERROR !!! Missing Part Number Prefix.")
            Exit Sub
        End If

        If Val(txtDia.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Part Number Diameter.")
            Exit Sub
        End If

        If Val(txtLength.Text) = 0 Then
            MsgBox("!!! ERROR !!! Missing Part Number Length.")
            Exit Sub
        End If

        Try
            CallClass.ExecuteUpdate4Params("cspUpdatePartsFromBlank", Trim(txtPrefix.Text), Trim(txtDia.Text), Trim(txtLength.Text), CmbPartNumber.SelectedValue)
            MsgBox("Update successfully.")
        Catch ex As Exception
        End Try

        dsMain.Tables("tblPartRelationBlank").Clear()

        Try
            CallClass.PopulateDataAdapter("gettblPartRelationBlank").Fill(dsMain, "tblPartRelationBlank")
        Catch ex As Exception
        End Try

        dgFromBlanks.AutoGenerateColumns = False
        dgFromBlanks.DataSource = dsMain
        dgFromBlanks.DataMember = "tblPartMaster.PartFromBlank"

        dgFromBlanks.Refresh()

        dgPartList.AutoGenerateColumns = False
        dgPartList.DataSource = dsMain
        dgPartList.DataMember = "tblPartMaster.PartsListLinkWithBlank"

        dgPartList.Refresh()
    End Sub

    Private Sub dgPartList_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPartList.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPartsList = e.RowIndex

        Select Case e.ColumnIndex
            Case 3, 4
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgPartList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPartList.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowPartsList = e.RowIndex

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 Then
            If dgPartList.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value) = False Then
                If dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value = "InActive" Then
                    MsgBox("Status Revision = InActive  -  ReadOnly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Revision Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value = "Active"
                    End If
                End If
            End If
        End If

        PutInfodgPartList()
    End Sub

    Private Sub dgPartList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPartList.CellEndEdit

        Select Case e.ColumnIndex
            Case 2      ' PNBlanksID
                If IsDBNull(dgPartList.Item("PNStdCompID", e.RowIndex).Value) = True Then
                    Exit Sub
                End If

                If Len(dgPartList.Item("PNStdCompID", e.RowIndex).Value) = 0 Then
                    Exit Sub
                End If

                dgPartList.Rows(e.RowIndex).Cells("PrtListPNBlankName").Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgPartList.Item("PNStdCompID", e.RowIndex).Value)
                dgPartList.Rows(e.RowIndex).Cells("PrtListPNBlankDescrCode").Value = CallClass.ReturnStrWithParInt("cspReturnPartDescrCode", dgPartList.Item("PNStdCompID", e.RowIndex).Value)

                PutDiaLengthForGrid()

                If Convert.ToString(Len(Trim(dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").ToString))) = 0 Or _
                    IsDBNull(dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value) = True Then
                    dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value = "Active"
                Else
                    Exit Sub
                End If
        End Select

        dgPartList.Refresh()

    End Sub

    Private Sub dgPartList_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPartList.CellEnter
        'PutInfodgPartList
    End Sub

    Private Sub dgPartList_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPartList.DataError
        REM end
    End Sub

    Private Sub dgPartList_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgPartList.RowPrePaint
        If IsDBNull(dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value) = False Then
            If dgPartList.Rows(e.RowIndex).Cells("PNRelStatus").Value = "InActive" Then
                dgPartList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgPartList.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub TabPage9_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage9.Enter
        'PutInfodgPartList()
    End Sub

    Sub PutInfodgPartList()

        Dim II As Integer

        For II = 1 To dgPartList.Rows.Count - 1
            If IsDBNull(dgPartList.Item("PNStdCompID", II - 1).Value) = False Then
                If Len(dgPartList.Item("PNStdCompID", II - 1).Value) > 0 Then
                    dgPartList.Item("PrtListPNBlankName", II - 1).Value = CallClass.ReturnStrWithParInt("cspReturnPartName", dgPartList.Item("PNStdCompID", II - 1).Value)
                    dgPartList.Item("PrtListPNBlankDescrCode", II - 1).Value = CallClass.ReturnStrWithParInt("cspReturnPartDescrCode", dgPartList.Item("PNStdCompID", II - 1).Value)

                End If
            End If
        Next

        dgPartList.Refresh()
    End Sub

    Private Sub CmdDescrCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDescrCode.Click

        GC.Collect()

        If Len(Trim(txtDescrCode.Text)) = 0 Then
            MsgBox("Missing Description Code. Nothing to View.")
            Exit Sub
        Else
            dsMain.Tables("tblTemp").Clear()
            CallClass.PopulateDataAdapterSearchStrAndStr("getPartAlternativeByDescrCode", txtDescrCode.Text, CmbPartNumber.SelectedValue).Fill(dsMain, "tblTemp")
            dgPartListByDescrCode.AutoGenerateColumns = False
            dgPartListByDescrCode.DataSource = dsMain
            dgPartListByDescrCode.DataMember = "tblTemp"
            dgPartListByDescrCode.Refresh()
        End If

    End Sub

    Private Sub TabPage12_Enter(sender As Object, e As EventArgs) Handles TabPage12.Enter
        PutInfoCrossDual()
    End Sub

    Sub PutInfoCrossDual()

        If Len(Trim(CmbPartNumber.Text)) > 2 Then
            Dim SwStatus As String = ""
            Dim SwCrossPN As String = ""

            SwStatus = CallClass.ReturnStrWithParInt("cspReturnM3Status", CmbPartNumber.SelectedValue)
            If SwStatus = False Then
                MessageBox.Show("Missing CrossPN status 20 / 88 / 99" + vbCrLf + "Please update the P/N Cross status, save and call again the P/N")
                Exit Sub
            End If

            If SwStatus = 99 Or SwStatus = 88 Then
                ' look for ID cross 20
                SwCrossPN = CallClass.ReturnStrWithParInt("cspReturnM3CrossPN_ID_20", CmbPartNumber.SelectedValue) ' return CrossReferenceID based on 88/99 CrossMasterID
                If SwCrossPN = False Then
                    MessageBox.Show("!!! ERROR !!! - Missing Hi-Shear Part Number to MFR in Cross Reference Table" + vbCrLf + "Email sent to IT department.")
                    Dim email As New Mail.MailMessage()
                    Dim strBody As String = ""
                    Dim strText As String = ""
                    strText = CallClass.ReturnStrWithParInt("cspReturnPartNumberWithPartID", CmbPartNumber.SelectedValue)
                    email.Subject = " Missing Hi-Shear Part Number to MFR in Cross Reference Table"
                    strBody = "For the P/N:   " + strText
                    email.Body = strBody
                    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                    email.From = New Net.Mail.MailAddress(wkEmpEmail)
                    email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
                    client.Send(email)
                    Exit Sub

                Else

                    'status 88 or 99 for OrdPartNoID ( I do have CrossRefereanceID (20) and take from  in tblPartCrossPN ID for CrossRefereanceID
                    dsMain.Tables("tblPartCrossPN").Clear()

                    CallClass.PopulateAdapterAfterSearchInt("gettblPartCrossPNReferencesEng_88_99", SwCrossPN).Fill(dsMain, "tblPartCrossPN")

                    dgCross.AutoGenerateColumns = False
                    dgCross.DataSource = dsMain
                    dgCross.DataMember = "tblPartCrossPN"
                    dgCross.Refresh()
                End If

            Else

                'status 20(I do have CrossReferenceID and I need to see all status 99 88 ID

                dsMain.Tables("tblPartCrossPN").Clear()
                CallClass.PopulateAdapterAfterSearchInt("gettblPartCrossPNReferencesEng_88_99", CmbPartNumber.SelectedValue).Fill(dsMain, "tblPartCrossPN")

                dgCross.AutoGenerateColumns = False
                dgCross.DataSource = dsMain
                dgCross.DataMember = "tblPartCrossPN"
                dgCross.Refresh()
            End If

        End If

    End Sub

    Private Sub dgCross_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgCross.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowCross = e.RowIndex
        End If

        If dgCross.Columns(3).ReadOnly = True Then
            MsgBox("Click on Edit Part# - Action Denied.")
            e.Cancel = True
            Exit Sub
        End If

        Dim reply As DialogResult
        Select Case e.ColumnIndex
            Case 3 'CROSS STATUS
                reply = MsgBox("Edit Cross Status ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub dgCross_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCross.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowCross = e.RowIndex
        End If

        dgCross.Columns(0).ReadOnly = True
        dgCross.Columns(1).ReadOnly = True
        dgCross.Columns(2).ReadOnly = True
        dgCross.Columns(3).ReadOnly = False
        dgCross.Columns(4).ReadOnly = False

    End Sub

    Private Sub dgCross_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCross.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowCross = e.RowIndex
        End If

        Select e.ColumnIndex
            Case 3 'CROSS STATUS
                UpdateCrossStatus()
        End Select

    End Sub

    Sub UpdateCrossStatus()

        If IsDBNull(dgCross("CrossStatus", RowCross).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePN_Cross_Status", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraID As SqlParameter = New SqlParameter("@CrossID", SqlDbType.Int, 4)
            paraID.Value = dgCross("CrossID", RowCross).Value
            mySqlComm.Parameters.Add(paraID)

            Dim paraStatus As SqlParameter = New SqlParameter("@CrossStatus", SqlDbType.NVarChar, 25)
            paraStatus.Value = dgCross("CrossStatus", RowCross).Value
            mySqlComm.Parameters.Add(paraStatus)

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox("Update Mpo Qty Released: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub dgCross_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgCross.DataError
        REM end
    End Sub

    Private Sub frmPartMaster_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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