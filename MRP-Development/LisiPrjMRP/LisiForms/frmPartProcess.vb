Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.UTF32Encoding


'Add System.Text.Encoding.Default byte order mask  
'as in... IO.StreamReader(sFileName,System.Text.Encoding.Default) 

Public Class frmPartProcess
    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Private dsProc As New DataSet

    Dim CallClass As New clsCommon

    Dim RowProc As Integer = 0

    Dim SwVal As Boolean

    Dim dragRow As Integer

    Private Sub frmPartProcess_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim reply As DialogResult

        If dsProc.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsProc.RejectChanges()
        dsProc.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmPartProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Call SetupForm()

        dgProc.AllowDrop = True
    End Sub

    Sub SetupForm()

        PageReadOnly()
        DisableFields()

        PutMatl()
        PutFinishSurface()
        PutMaterialType()

        SetCtlForm()

        FirstTimeMenuButtons()

        InitialComponents()

        FindProc()

        dgProc.AutoGenerateColumns = False
        dgProc.DataSource = dsProc
        dgProc.DataMember = "tblPartProc.RelPartOper"

        With dgProc
            '    '.DataSource = mDV       ' DGV an DataView (mDV) binden
            '    .RowHeadersWidth = 30   ' Breite der Zeilenköpfe einstellen

            '    ' Textausrichtung für Spalte 0
            '    '.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    '.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    '.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            '    ' Zeilenumbruch für Spalte 1 einstellen
            '    .Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '    '.Columns(3).DefaultCellStyle.Padding = New Padding(50, 1, 50, 1)
            .Columns(3).DefaultCellStyle.Format = "######################################## "

            '    .Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '    '.Columns(5).DefaultCellStyle.Padding = New Padding(20, 1, 20, 1)
            .Columns(5).DefaultCellStyle.Format = "#################### "

            '    ' Spaltenbreite und Zeilenhöhe an die jeweiligen Zelleninhalte anpassen
            '    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            '    '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '    '.AutoResizeColumns()
            '    .AutoResizeRows()
        End With

        ''dgProc.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'dgProc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'dgProc.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)


        'Dim style As DataGridViewCellStyle
        'style = New DataGridViewCellStyle()
        'style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        'style.BackColor = System.Drawing.Color.Navy
        ''style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        'style.ForeColor = System.Drawing.Color.White
        'style.SelectionBackColor = System.Drawing.SystemColors.Highlight
        'style.SelectionForeColor = System.Drawing.Color.Navy
        'style.WrapMode = System.Windows.Forms.DataGridViewTriState.True

        'dgProc.EnableHeadersVisualStyles = False

        'For Each col As DataGridViewRow In dgProc.Rows
        '    col.DefaultCellStyle = style
        'Next

        'With dgProc.Columns("OperSpec")
        '    .Width = 155
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'End With

        RdSQL.Checked = True
        RdAccess.Checked = False
        CmbPrAcc.Enabled = False
        RdAll.Checked = True
        RdPart.Checked = False

        CmbPrAcc.Text = "1"

    End Sub

    Sub PageReadOnly()

        txtPartNo.ReadOnly = True
        txtPartName.ReadOnly = True
        txtDescCode.ReadOnly = True
        txtPartRev.ReadOnly = True
        cmbMatl.Enabled = False

    End Sub

    Sub DisableFields()

        txtMfgSpec.Enabled = False
        cmbFinish.Enabled = False
        txtHeat.Enabled = False

        'dgProc.Enabled = False

    End Sub

    Sub EnableFields()

        txtMfgSpec.Enabled = True
        cmbFinish.Enabled = True
        txtHeat.Enabled = True

        'dgProc.Enabled = True

    End Sub

    Sub FirstTimeMenuButtons()

        If SwProc.Text = "1" Then      'proc revised
            CmdSave.Enabled = False
            CmdPrint.Enabled = True
            CmdSrc.Enabled = True
            CmdAdd.Enabled = False
            CmdNo.Enabled = False
            'dgProc.ReadOnly = True
            'dgProc.Enabled = False
        Else
            CmdSave.Enabled = True
            CmdPrint.Enabled = True
            CmdSrc.Enabled = True
            CmdAdd.Enabled = False
            CmdNo.Enabled = True

            EnableFields()
        End If

    End Sub

    Sub InitialComponents()

        dsProc.Clear()
        dsProc.Relations.Clear()

        CallClass.PopulateDataAdapter("gettblPartProc").Fill(dsProc, "tblPartProc")

        CallClass.PopulateDataAdapter("gettblPartProcOper").FillSchema(dsProc, SchemaType.Source, "tblPartProcOper")
        CallClass.PopulateDataAdapter("gettblPartProcOper").Fill(dsProc, "tblPartProcOper")
        Dim ResId As DataColumn = dsProc.Tables("tblPartProcOper").Columns("ProcOperID")
        ResId.AutoIncrement = True
        ResId.AutoIncrementStep = -1
        ResId.AutoIncrementSeed = -1
        ResId.ReadOnly = False

        dsProc.EnforceConstraints = False

        With dsProc
            .Relations.Add("RelPartOper", _
                .Tables("tblPartProc").Columns("ProcID"), _
                .Tables("tblPartProcOper").Columns("ProcID"), True)
        End With

    End Sub

    Sub PutMaterialType()

        With Me.CmbMatltype
            .DataSource = CallClass.PopulateComboBox("tblMatlMasterDetails", "cmbGetMatlDetailType").Tables("tblMatlMasterDetails")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlDetID"
        End With
    End Sub

    Sub PutMatl()

        With Me.cmbMatl
            .DataSource = CallClass.PopulateComboBox("tblMatlMaster", "cmbGetMatlType").Tables("tblMatlMaster")
            .DisplayMember = "FullDescr"
            .ValueMember = "MatlID"
        End With

    End Sub

    Sub PutFinishSurface()

        With Me.cmbFinish
            .DataSource = CallClass.PopulateComboBox("tblPartProcFinishSurface", "cmbGetProcFinishSurface").Tables("tblPartProcFinishSurface")
            .DisplayMember = "ProcFinishType"
            .ValueMember = "ProcFinishID"
        End With

    End Sub
    Sub SetCtlForm()

        'for dgProc  --   Info
        With Me.ProcOperID
            .DataPropertyName = "ProcOperID"
            .Name = "ProcOperID"
            .Visible = False
        End With

        With Me.ProcID
            .DataPropertyName = "ProcID"
            .Name = "ProcID"
            .Visible = False
        End With

        With Me.OperNo
            .DataPropertyName = "OperNo"
            .Name = "OperNo"
        End With

        With Me.OperDescr
            .DataPropertyName = "OperDescr"
            .Name = "OperDescr"
        End With

        With Me.OperSpec
            .DataPropertyName = "OperSpec"
            .Name = "OperSpec"
        End With

    End Sub

    Sub BindComponents()

        cmbFinish.DataBindings.Clear()
        cmbMatl.DataBindings.Clear()
        CmbMatltype.DataBindings.Clear()

        txtPartNo.DataBindings.Clear()
        txtPartName.DataBindings.Clear()
        txtDescCode.DataBindings.Clear()
        txtPartRev.DataBindings.Clear()

        txtMfgSpec.DataBindings.Clear()
        txtHeat.DataBindings.Clear()
        txtDia.DataBindings.Clear()

        txtPartNo.DataBindings.Add("Text", dsProc, "tblPartProc.PartNumber")
        txtPartName.DataBindings.Add("Text", dsProc, "tblPartProc.PartName")
        txtDescCode.DataBindings.Add("Text", dsProc, "tblPartProc.PartDescCode")
        txtPartRev.DataBindings.Add("Text", dsProc, "tblPartProc.PartNoRevSave")
        txtDia.DataBindings.Add("Text", dsProc, "tblPartProc.ProcDia")

        cmbFinish.DataBindings.Add("SelectedValue", dsProc, "tblPartProc.ProcFinishID")
        cmbMatl.DataBindings.Add("SelectedValue", dsProc, "tblPartProc.ProcMatlID")
        CmbMatltype.DataBindings.Add("SelectedValue", dsProc, "tblPartProc.ProcMatlTypeID")

        txtMfgSpec.DataBindings.Add("Text", dsProc, "tblPartProc.ProcMfgSpec")
        txtHeat.DataBindings.Add("Text", dsProc, "tblPartProc.ProcHeatTr")

    End Sub

    Private Sub CmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNo.Click
        ReorderOper()
    End Sub

    Sub ReorderOper()

        If dgProc.Rows.Count <= 1 Then
            MsgBox("!!! Nothing to Reorder !!!")
        Else
            dgProc.EndEdit()
            dgProc.Refresh()

            If dgProc.Rows.Count - 2 >= 2 Then
                Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 2).Cells(2)
                dgProc.CurrentCell = cellLastRow
                dgProc.CurrentCell = dgProc.Rows(0).Cells(2)
                dgProc.CurrentCell = cellLastRow
                dgProc.CurrentCell = dgProc.Rows(0).Cells(2)
            End If

            If dsProc.HasChanges Then
                dgProc.EndEdit()
                UpdateProcessHeder()
                UpdateProcessOper(dsProc.GetChanges)
                dsProc.AcceptChanges()

                dsProc.RejectChanges()
                SetupForm()
            End If

            Dim II As Integer = 0
            Dim JJ As Integer = 10

            For II = 0 To dgProc.Rows.Count - 1

                dgProc.Rows(II).Cells("OperNo").Value = JJ
                'dgProc.Rows(II).Cells("OperNo").Value = Str(dgProc.Rows(II).Cells("OperNo").Value)
                JJ = JJ + 10

            Next

            If dsProc.HasChanges Then
                dgProc.EndEdit()
                UpdateProcessHeder()
                UpdateProcessOper(dsProc.GetChanges)
                dsProc.AcceptChanges()

                dsProc.RejectChanges()
                SetupForm()
            End If

        End If

    End Sub

    Private Sub dgProc_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgProc.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowProc = e.RowIndex
        End If

        If SwProc.Text = "1" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dgProc_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProc.CellClick


        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowProc = e.RowIndex
        End If

        If SwProc.Text = "1" Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 4       'Find operation

                frmPartProcGetOper.ShowDialog()
                frmPartProcGetOper.Dispose()

                If Not Len(Trim(SwGetOper.Text)) = 0 Then
                    Me.dgProc("OperDescr", RowProc).Value = SwGetOper.Text
                    SwGetOper.Text = ""
                End If

                If Not Len(Trim(SwGetSpec.Text)) = 0 Then
                    Me.dgProc("OperSpec", RowProc).Value = SwGetSpec.Text
                    SwGetSpec.Text = ""
                End If
        End Select

    End Sub

    Private Sub dgProc_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProc.CellEndEdit
        If e.ColumnIndex = 2 Then
            Me.dgProc("OperNo", e.RowIndex).Value = Str(Nz.Nz(dgProc.Rows(e.RowIndex).Cells("OperNo").Value))
        End If

    End Sub

    Sub FindProc()

        Dim strSearch As Integer

        strSearch = SwForm.Text

        dsProc.Tables("tblPartProc").Clear()

        CallClass.PopulateDataAdapterAfterSearch("getTblPartProcByProcID", strSearch).Fill(dsProc, "tblPartProc")

        If dsProc.Tables("tblPartProc").Rows.Count = 0 Then
            MessageBox.Show("Missing Process number, try again.", "Warning")
        Else
            BindComponents()
        End If

    End Sub

    Private Sub dgProc_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProc.DataError
        REM end
    End Sub

    Private Sub CmdSrc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSrc.Click

        frmPartProcSQL.SwIndex.Text = ""

        If RdSQL.Checked = True Then
            If RdAll.Checked = True Then
                frmPartProcSQL.SwIndex.Text = "ALL"
            Else
                frmPartProcSQL.SwIndex.Text = "PART"
            End If
            frmPartProcSQL.Show()
            If SwProc.Text = "0" Then
                CmdAdd.Enabled = True
            End If
        Else
            If RdAll.Checked = True Then
                frmPartProcAccess.SwIndex.Text = CmbPrAcc.Text
                frmPartProcAccess.Show()

                If SwProc.Text = "0" Then
                    CmdAdd.Enabled = True
                End If
            Else
                If RdPart.Checked = True Then
                    frmPartProcAccessByPart.SwIndex.Text = CmbPrAcc.Text
                    frmPartProcAccessByPart.Show()
                    If SwProc.Text = "0" Then
                        CmdAdd.Enabled = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click

        Dim strSearch As Integer

        If Len(Trim(SwMpoID.Text)) = 0 Then
            MessageBox.Show("There is No Data to Import.")
            Exit Sub
        End If

        strSearch = SwMpoID.Text
        ' for MS Access SwMpoid= MpoID; for SQL swMpoID = ProcID

        '======== update delete records and then clear dsproc
        If dsProc.HasChanges Then
            UpdateProcessOper(dsProc.GetChanges)
        End If
        dsProc.Tables("tblPartProcOper").Clear()
        'dsProc.Tables("tblPartProc").Clear()

        If RdSQL.Checked = True Then
            CallClass.PopulateDataAdapterAfterSearch("gettblPartProcessOperSQLByProcID", strSearch).Fill(dsProc, "tblPartProcOper")
        Else
            strSearch = SwMpoID.Text
            Dim FindItem As Integer
            FindItem = CmbPrAcc.Text
            CallClass.PopulateDataAdapterSearchStrAndStr("getTblPartProcBySMPOID", strSearch, FindItem).Fill(dsProc, "tblPartProcOper")
        End If

        If dsProc.Tables("tblPartProcOper").Rows.Count = 0 Then
            MessageBox.Show("Missing Process number existing, try again.", "Warning")
        Else

            dgProc.AutoGenerateColumns = False
            dgProc.DataSource = dsProc
            dgProc.DataMember = "tblPartProcOper"

            For Each RProc As DataGridViewRow In dgProc.Rows
                RProc.Cells("ProcID").Value = CInt(SwForm.Text)
            Next

            dgProc.AutoGenerateColumns = False
            dgProc.DataSource = dsProc
            dgProc.DataMember = "tblPartProc.RelPartOper"
            dgProc.Refresh()

            If dsProc.HasChanges Then

                dgProc.EndEdit()

                ''To change the current row, to the last row:
                If dgProc.Rows.Count - 2 >= 2 Then
                    Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 2).Cells(2)
                    dgProc.CurrentCell = cellLastRow
                End If

                dgProc.EndEdit()
                UpdateProcessHeder()
                UpdateProcessOper(dsProc.GetChanges)
                dsProc.AcceptChanges()

                dsProc.RejectChanges()
                SetupForm()
            End If
        End If

    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgProc.EndEdit()

        ''To change the current row, to the last row:
        If dgProc.Rows.Count - 2 >= 2 Then
            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 2).Cells(2)
            dgProc.CurrentCell = cellLastRow
        End If

        Call ValPo()

        If SwVal = True Then

            Try
                UpdateProcessHeder()

                If dsProc.HasChanges Then

                    UpdateProcessOper(dsProc.GetChanges)

                    MsgBox("Update successfully.")
                    dsProc.AcceptChanges()
                End If
            Catch ex As Exception
                dsProc.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            Call SetupForm()

            CmdSave.Enabled = False
            DisableFields()
            CmdSrc.Enabled = False
            CmdAdd.Enabled = False

            Me.Dispose()

        End If

    End Sub

    Sub UpdateProcessHeder()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateProcessHeader", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraProcID As SqlParameter = New SqlParameter("@ProcID", SqlDbType.Int, 4)
        paraProcID.Value = SwForm.Text
        mySqlComm.Parameters.Add(paraProcID)

        Dim paraMfgSpec As SqlParameter = New SqlParameter("@ProcMfgSpec", SqlDbType.NVarChar, 100)
        paraMfgSpec.Value = Trim(txtMfgSpec.Text)
        mySqlComm.Parameters.Add(paraMfgSpec)

        Dim paraFinish As SqlParameter = New SqlParameter("@ProcFinishID", SqlDbType.Int, 4)
        paraFinish.Value = Nz.Nz(cmbFinish.SelectedValue)
        mySqlComm.Parameters.Add(paraFinish)

        Dim paraHeat As SqlParameter = New SqlParameter("@ProcHeatTr", SqlDbType.NVarChar, 200)
        paraHeat.Value = Trim(txtHeat.Text)
        mySqlComm.Parameters.Add(paraHeat)

        Dim paraMatl As SqlParameter = New SqlParameter("@ProcMatlID", SqlDbType.Int, 4)
        paraMatl.Value = cmbMatl.SelectedValue
        mySqlComm.Parameters.Add(paraMatl)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
            cn.Close()
        Catch ex As SqlException
            MsgBox("Update Process Header: " & ex.Message)
        End Try

    End Sub

    Sub UpdateProcessOper(ByVal dsChanges As DataSet)
        Dim cmdInsOper As SqlCommand
        Dim cmdUpdOper As SqlCommand
        Dim cmdDelOper As SqlCommand

        Dim daProc As SqlDataAdapter

        ' Add Parameters to insert
        cmdInsOper = New SqlCommand()
        cmdInsOper.Connection = cn
        cmdInsOper.CommandType = CommandType.StoredProcedure
        cmdInsOper.CommandText = "cspUpdateProcessOperInsert"

        cmdInsOper.Parameters.Add("@ProcOperID", SqlDbType.Int, 4, "ProcOperID")
        cmdInsOper.Parameters.Add("@ProcID", SqlDbType.Int, 4, "ProcID")
        cmdInsOper.Parameters.Add("@OperNo", SqlDbType.Int, 4, "OperNo")
        cmdInsOper.Parameters.Add("@OperDescr", SqlDbType.NVarChar, 500, "OperDescr")
        cmdInsOper.Parameters.Add("@OperSpec", SqlDbType.NVarChar, 500, "OperSpec")

        ' Add Parameters to update
        cmdUpdOper = New SqlCommand()
        cmdUpdOper.Connection = cn
        cmdUpdOper.CommandType = CommandType.StoredProcedure
        cmdUpdOper.CommandText = "cspUpdateProcessOper"

        cmdUpdOper.Parameters.Add("@ProcOperID", SqlDbType.Int, 4, "ProcOperID")
        cmdUpdOper.Parameters.Add("@ProcID", SqlDbType.Int, 4, "ProcID")
        cmdUpdOper.Parameters.Add("@OperNo", SqlDbType.Int, 4, "OperNo")
        cmdUpdOper.Parameters.Add("@OperDescr", SqlDbType.NVarChar, 500, "OperDescr")
        cmdUpdOper.Parameters.Add("@OperSpec", SqlDbType.NVarChar, 500, "OperSpec")

        ' Add Parameters to delete
        cmdDelOper = New SqlCommand()
        cmdDelOper.Connection = cn
        cmdDelOper.CommandType = CommandType.StoredProcedure
        cmdDelOper.CommandText = "cspUpdateProcessOperDelete"

        cmdDelOper.Parameters.Add("@ProcOperID", SqlDbType.Int, 4, "ProcOperID")

        'DataApapter
        daProc = New SqlDataAdapter()
        daProc.DeleteCommand = cmdDelOper
        daProc.InsertCommand = cmdInsOper
        daProc.UpdateCommand = cmdUpdOper
        daProc.TableMappings.Add("Table", "tblPartProcOper")

        daProc.Update(dsChanges)

    End Sub

    Sub ValPo()

        Dim II As Integer = 0
        Dim K As Integer = 0

        SwVal = False

        dgProc.Refresh()

        For K = 0 To dgProc.Rows.Count - 1
            If IsDBNull(dgProc.Rows(K).Cells("OperNo").Value) = True Then
                II = II + 1
            End If
        Next
        If II <> 0 Then
            MsgBox("!!! ERROR !!! Operation Number.")
            SwVal = False
            Exit Sub
        End If

        '=====
        For K = 0 To dgProc.Rows.Count - 2
            If IsDBNull(dgProc.Rows(K).Cells("OperDescr").Value) = True Then
                MsgBox("!!! ERROR !!! Operation Description. Line: " + Str(K))
                SwVal = False
                Exit Sub
            End If
        Next

        '=====
        For K = 0 To dgProc.Rows.Count - 2
            If Len(Trim(dgProc.Rows(K).Cells("OperDescr").Value)) = 0 Then
                MsgBox("!!! ERROR !!! Operation Description. Line: " + Str(K))
                SwVal = False
                Exit Sub
            End If
        Next

        '=====
        If Len(Trim(cmbFinish.SelectedValue)) = 0 Or IsDBNull(cmbFinish.SelectedValue) = True Or IsNothing(cmbFinish.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Surface Finish.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(txtHeat.Text)) = 0 Or IsDBNull(txtHeat.Text) = True Then
            MsgBox("!!! ERROR !!! Heat Treatment.")
            SwVal = False
            Exit Sub
        End If

        If Len(Trim(cmbMatl.SelectedValue)) = 0 Or IsDBNull(cmbMatl.SelectedValue) = True Or IsNothing(cmbMatl.SelectedValue) = True Then
            MsgBox("!!! ERROR !!! Material Type.")
            SwVal = False
            Exit Sub
        End If

        SwVal = True

    End Sub

    Private Sub CmdFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFinish.Click
        frmEngFinishSourceList.ShowDialog()
    End Sub

    Private Sub cmbFinish_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFinish.DropDown
        PutFinishSurface()
    End Sub

    Private Sub dgProc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgProc.KeyDown

        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Are you sure you want to delete the selected record(s)?", _
            "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
            MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
        Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim rptPO As New rptProcessMethod

        rptPO.Load("..\rptProcessMethod.rpt")
        pdvCustomerName.Value = SwForm.Text
        pvCollection.Add(pdvCustomerName)
        rptPO.DataDefinition.ParameterFields("@txtPrint").ApplyCurrentValues(pvCollection)

        frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
        frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
        frmPOMasterPrint.CrystalReportViewer1.ShowPrintButton = True
        frmPOMasterPrint.CrystalReportViewer1.ShowExportButton = True
        frmPOMasterPrint.ShowDialog()
    End Sub

    Private Sub dgProc_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgProc.ColumnHeaderMouseClick
        '2
        If dgProc.Rows.Count - 2 >= 2 Then
            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 2).Cells(2)
            dgProc.CurrentCell = cellLastRow
            'dgProc.CurrentCell = dgProc.Rows(0).Cells(2)
        End If

        'dgProc.Columns("OperNo").Selected = True

        'dgProc.Columns("OperNo").SortMode = DataGridViewColumnSortMode.Automatic
        'dgProc.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    Private Sub dgProc_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProc.Sorted
        '1
        If dgProc.Rows.Count - 2 >= 2 Then
            Dim cellLastRow As DataGridViewCell = dgProc.Rows(dgProc.Rows.Count - 2).Cells(2)
            dgProc.CurrentCell = cellLastRow
            'dgProc.CurrentCell = dgProc.Rows(0).Cells(2)
        End If

        'dgProc.Columns("OperNo").Selected = True

        'dgProc.Columns("OperNo").SortMode = DataGridViewColumnSortMode.NotSortable
        'dgProc.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    Private Sub RdSQL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdSQL.Click
        RdSQL.Checked = True
        RdAccess.Checked = False
        CmbPrAcc.Enabled = False
        RdAll.Checked = True
        RdPart.Checked = False
    End Sub

    Private Sub RdAccess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdAccess.Click
        RdSQL.Checked = False
        RdAccess.Checked = True
        CmbPrAcc.Enabled = True
        RdAll.Checked = True
        RdPart.Checked = False
    End Sub

End Class


