Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmPartGenSerialNo

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daSN As New SqlDataAdapter

    Dim SwTable As String = "tblPartSNLC6101"

    Dim CallClass As New clsCommon

    Dim SNCurrency As CurrencyManager

    Dim strSearch As String


    Private Sub frmPartGenSerialNo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        SNCurrency.EndCurrentEdit()
        dsMain.RejectChanges()
        dsMain.Dispose()
        daSN.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPartGenSerialNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GC.Collect()

        Panel1.Visible = False
        InitFields()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        BindComponents()

    End Sub

    Sub InitFields()

        txtSNFrom.Text = ""
        txtSNTo.Text = ""

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        strSearch = SwTable
        CallClass.PopulateDataAdapter("gettblPartSNLC6101").Fill(dsMain, SwTable)
        daSN.FillSchema(dsMain, SchemaType.Source, SwTable)

        daSN.Fill(dsMain, SwTable)
        Dim SNID As DataColumn = dsMain.Tables(SwTable).Columns("SNID")
        SNID.AutoIncrement = True
        SNID.AutoIncrementStep = -1
        SNID.AutoIncrementSeed = -1
        SNID.ReadOnly = False

        dsMain.EnforceConstraints = False

        SNCurrency = CType(BindingContext(dsMain, SwTable), CurrencyManager)

        CallClass.PopulateDataAdapter("gettblPartMaster").Fill(dsMain, "tblSelect")
        CmbPartNumber.DataSource = dsMain.Tables("tblSelect")
        CmbPartNumber.DisplayMember = "PartNumber"
        CmbPartNumber.ValueMember = "PartID"
        CmbPartNumber.SelectedIndex = -1

    End Sub

    Sub SetCtlForm()

        With Me.SNID
            .DataPropertyName = "SNID"
            .Name = "SNID"
        End With

        With Me.PartID
            .DataPropertyName = "PartID"
            .Name = "PartID"
        End With

        With Me.PartSN
            .DataPropertyName = "PartSN"
            .Name = "PartSN"
        End With

        With Me.PartSNStatus
            .DataPropertyName = "PartSNStatus"
            .Name = "PartSNStatus"
        End With

    End Sub

    Sub BindComponents()

        txtReqSN.DataBindings.Clear()
        txtReqSN.DataBindings.Add("Text", dsMain, "tblSelect.PNSerialNo")

    End Sub

    Sub BuildSqlCommand()

        Try
            daSN = CallClass.PopulateDataAdapter("gettblPartSNLC6101")

            Dim SNBuilder As New SqlClient.SqlCommandBuilder(daSN)

            daSN.UpdateCommand = SNBuilder.GetUpdateCommand
            daSN.UpdateCommand.Connection = cn
            daSN.InsertCommand = SNBuilder.GetInsertCommand
            AddHandler daSN.RowUpdated, AddressOf HandleRowUpdatedSN
            daSN.InsertCommand.Connection = cn
            daSN.DeleteCommand = SNBuilder.GetDeleteCommand
            daSN.DeleteCommand.Connection = cn
            daSN.AcceptChangesDuringFill = True
            daSN.TableMappings.Add("Table", SwTable)
            daSN.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured on BuildSqlCommand - " & ex.Message)
        End Try

    End Sub

    Private Sub HandleRowUpdatedSN(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables(SwTable).Columns("SNID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Sub CheckTableSN()

        Dim SwReturn As Boolean

        'SwTable = "tblPartSN" + CmbPartNumber.Text

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()

        Dim restrictions() As String = {SwTable}

        Dim dbTbl As DataTable = cn.GetSchema("Tables", restrictions)
        If dbTbl.Rows.Count = 0 Then
            SwReturn = False
        Else
            SwReturn = True
            MsgBox("Table name: " + SwTable + " was created in LAC DataBase.")
            Exit Sub
        End If

        If SwReturn = False Then

            Dim createSql As String
            Try
                Dim tblname = "tblPartSN" + CmbPartNumber.Text
                createSql = "CREATE TABLE " & tblname & " ([SNID] INT NOT NULL IDENTITY(1,1)," & _
                    "[PartID]                       INT             NOT NULL," & _
                    "[PartSN]                       NVARCHAR (25)   NOT NULL," & _
                    "[PartSNStatus]                 NVARCHAR (50)   NULL," & _
                    "[MPOID]                        INT             NULL," & _
                    "PRIMARY KEY (SNID));"

                Dim cmd As New SqlCommand(createSql, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try

        End If

    End Sub

    Sub UpdateSNwithY()

        If txtReqSN.Text = "Y" Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdatePartSNFlag", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraPart As SqlParameter = New SqlParameter("@PartID", SqlDbType.Int, 4)
        paraPart.Value = CmbPartNumber.SelectedValue
        mySqlComm.Parameters.Add(paraPart)

        Dim paraSN As SqlParameter = New SqlParameter("@PNSerialNo", SqlDbType.NVarChar, 1)
        paraSN.Value = "Y"
        mySqlComm.Parameters.Add(paraSN)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update S/N flag with Y : " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Private Sub CmbPartNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPartNumber.SelectedIndexChanged

        If CmbPartNumber.SelectedIndex < 1 Then
            Exit Sub
        End If


        Me.BindingContext(dsMain, "tblSelect").Position = CType(CmbPartNumber.SelectedIndex, String)
        BindComponents()

        txtReqSN.Focus()

        If Nz.Nz(txtReqSN.Text) <> "Y" Then

            Dim reply As DialogResult
            reply = MsgBox("DO you want to create S/N for the selected Part Number [Y/N] ?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then
                CheckTableSN()
                UpdateSNwithY()
                InitFields()
                Panel1.Visible = True
            Else
                InitFields()
                Panel1.Visible = False
            End If

        Else
            InitFields()
            Panel1.Visible = True
        End If

        CmdSave.Enabled = False
    End Sub


    Private Sub CmdGen_Click(sender As Object, e As EventArgs) Handles CmdGen.Click


        dsMain.RejectChanges()
        dgSN.Refresh()

        SNCurrency.EndCurrentEdit()
        SNCurrency.AddNew()

        Dim mytext As String = "ABCDEFGHJKLMNPRSTUVWY"

        'Dim mytextSec() As String = {"AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "JJ", "KK", "LL", "MM", "NN", "PP", "RR", "SS", "TT", "UU", "VV", "WW", "YY"}

        Dim myChars() As Char = mytext.ToCharArray()

        '' Loop through the array testing if each is a digit  
        Dim SerNo As String = ""

        Dim IFrom As Integer = txtSNFrom.Text
        Dim JTo As Integer = txtSNTo.Text
        Dim II As Integer = 0



        'For Each ch As Char In myChars

        '    For I As Integer = IFrom To JTo
        '        SerNo = ch + Str(I)

        '        Dim N As Integer = dgSN.Rows.Add()

        '        'dgSN.Rows.Item(N).Cells(1).Value = CmbPartNumber.SelectedValue
        '        'dgSN.Rows.Item(N).Cells(2).Value = SerNo
        '        'dgSN.Rows.Item(N).Cells(3).Value = "GEN"

        '        dgSN.Rows(N).Cells("PartID").Value = CmbPartNumber.SelectedValue
        '        dgSN.Rows(N).Cells("PartSN").Value = SerNo
        '        dgSN.Rows(N).Cells("SNStatus").Value = "GEN"

        '        Dim row As String() = New String() {"", CmbPartNumber.SelectedValue, SerNo, "GEN"}
        '        dgSN.Rows.Add(row)
        '        II = II + I
        '    Next
        'Next


        'For Each ch As String In myChars
        '    For K As Integer = IFrom To JTo
        '        SerNo = ch + Str(K)
        '        Dim row As String() = New String() {CmbPartNumber.SelectedValue, SerNo, "GEN"}
        '        dgSN.Rows.Add(row)
        '    Next
        'Next

        'For Each ch As String In mytextSec
        '    For K As Integer = IFrom To JTo
        '        SerNo = ch + Str(K)
        '        Dim row As String() = New String() {CmbPartNumber.SelectedValue, SerNo, "GEN"}
        '        dgSN.Rows.Add(row)
        '    Next
        'Next


        Me.Cursor = Cursors.WaitCursor

        Dim tb As DataTable
        Dim rw As DataRow
        tb = dsMain.Tables(SwTable)

        For Each ch As Char In myChars
            For I As Integer = IFrom To JTo

                SerNo = ch + Str(I)
                If Len(Trim(SerNo)) <> 0 Then
                    rw = tb.NewRow
                    rw("PartID") = CmbPartNumber.SelectedValue
                    rw("PartSN") = SerNo
                    rw("PartSNStatus") = "NEWSN"
                    tb.Rows.Add(rw)
                    II = II + I
                End If
            Next
        Next

        dgSN.AllowUserToAddRows = False
        dgSN.AutoGenerateColumns = False
        dgSN.DataSource = dsMain
        dgSN.DataMember = SwTable

        Me.dgSN.Rows(Me.dgSN.RowCount - 1).Selected = True
        Me.dgSN.Rows.RemoveAt(dgSN.Rows.Count - 1)

        CmdSave.Enabled = True

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

        Me.Cursor = Cursors.WaitCursor

        CmdSave.Enabled = False

        If dgSN.Rows.Count > 0 Then


            CmdSave.Focus()
            txtSNFrom.Focus()
            CmdSave.Focus()
            txtSNTo.Focus()
            CmdSave.Focus()

            SNCurrency.EndCurrentEdit()
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                daSN.Update(dsMain.Tables(SwTable).Select("", "", DataViewRowState.Added))
                dsMain.AcceptChanges()
                MsgBox("Update successfully.")

            End If
        Else
            MsgBox("Nothing to SAVE.")
        End If

        Me.Cursor = Cursors.Default

    End Sub
End Class