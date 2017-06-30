Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail


Public Class frmEngSpecList

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Private daSpec As New SqlDataAdapter
    Private daRev As New SqlDataAdapter

    Dim SpecCurrency As CurrencyManager
    Dim RevCurrency As CurrencyManager

    Dim CallClass As New clsCommon

    Dim SwVal As Boolean
    Dim strSQL As String
    Dim SwOper As String = ""
    Dim SwFirst As Boolean = False

    Dim RowSpec As Integer

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height

    Private Sub frmEngSpecList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        SpecCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()

        If dsMain.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        daSpec.Dispose()
        daRev.Dispose()

        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmEngSpecList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GC.Collect()

        Width = Screen.PrimaryScreen.Bounds.Width
        Height = Screen.PrimaryScreen.Bounds.Height

        If Width > 1800 And Height > 920 Then
            Me.Width = 1800
            Me.Height = 920
        Else
            If Width < 1800 And Height < 920 Then
            End If
        End If

        IW = Me.Width
        IH = Me.Height

        ClearFields()

        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        SetCtlForm()

        CmbUser.SelectedIndex = -1

        CmbUser.SelectedValue = wkEmpId

        BindComponents()

        dgSpec.AutoGenerateColumns = False
        dgSpec.DataSource = dsMain
        dgSpec.DataMember = "tblLisiSpecificationsControl"

        dgRev.AutoGenerateColumns = False
        dgRev.DataSource = dsMain
        dgRev.DataMember = "tblLisiSpecificationsControl.SpecListRev"

        CallClass.PopulateDataAdapter("gettblLisiSpecificationsControl").Fill(dsMain, "tblLisiSpecificationsControl")

        With CmbSpecNo
            .DataSource = dsMain.Tables("tblLisiSpecificationsControl")
            .DisplayMember = "SpecNo"
            .ValueMember = "SpecID"
        End With


        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        'Me.WindowState = FormWindowState.Maximized


    End Sub

    Sub ClearFields()

        txtSpecDescr.Text = ""
        txtSpecNotes.Text = ""
        txtRevDescr.Text = ""
        txtRevNotes.Text = ""

    End Sub

    Sub DisableFields()
        txtSpecDescr.ReadOnly = True
        txtSpecNotes.ReadOnly = True
        txtRevNotes.ReadOnly = True
        txtRevDescr.ReadOnly = True

        dgSpec.ReadOnly = True
        dgRev.ReadOnly = True
    End Sub

    Sub EnableFields()

        txtSpecDescr.ReadOnly = False
        txtSpecNotes.ReadOnly = False
        txtRevNotes.ReadOnly = False
        txtRevDescr.ReadOnly = False

        dgSpec.ReadOnly = False
        dgRev.ReadOnly = False

        CmdSave.Enabled = True
        CmdEdit.Enabled = False

    End Sub

    Sub FirstTimeMenuButtons()
        CmdEdit.Enabled = True
        CmdSave.Enabled = False
        CmdReset.Enabled = True
        CmdNew.Enabled = True
    End Sub


    Private Function BuildSqlCommand() As Boolean
        Try
            daSpec = CallClass.PopulateDataAdapter("gettblLisiSpecification")
            daRev = CallClass.PopulateDataAdapter("gettblLisiSpecificationRev")

            Dim SpecBuilder As New SqlClient.SqlCommandBuilder(daSpec)
            Dim RevBuilder As New SqlClient.SqlCommandBuilder(daRev)

            daSpec.UpdateCommand = SpecBuilder.GetUpdateCommand
            daSpec.UpdateCommand.Connection = cn
            daSpec.InsertCommand = SpecBuilder.GetInsertCommand
            AddHandler daSpec.RowUpdated, AddressOf HandleRowUpdatedMatlSpec
            daSpec.InsertCommand.Connection = cn
            daSpec.DeleteCommand = SpecBuilder.GetDeleteCommand
            daSpec.DeleteCommand.Connection = cn
            daSpec.AcceptChangesDuringFill = True
            daSpec.TableMappings.Add("Table", "tblLisiSpecificationsControl")
            daSpec.MissingSchemaAction = MissingSchemaAction.AddWithKey

            daRev.UpdateCommand = RevBuilder.GetUpdateCommand
            daRev.UpdateCommand.Connection = cn
            daRev.InsertCommand = RevBuilder.GetInsertCommand
            AddHandler daRev.RowUpdated, AddressOf HandleRowUpdatedMatlSpecRev
            daRev.InsertCommand.Connection = cn
            daRev.DeleteCommand = RevBuilder.GetDeleteCommand
            daRev.DeleteCommand.Connection = cn
            daRev.AcceptChangesDuringFill = True
            daRev.TableMappings.Add("Table", "tblLisiSpecificationsRev")
            daRev.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally

        End Try

    End Function

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        daSpec.FillSchema(dsMain, SchemaType.Source, "tblLisiSpecificationsControl")
        daRev.FillSchema(dsMain, SchemaType.Source, "tblLisiSpecificationsRev")

        daSpec.Fill(dsMain, "tblLisiSpecificationsControl")
        Dim SpecID As DataColumn = dsMain.Tables("tblLisiSpecificationsControl").Columns("SpecID")
        SpecID.AutoIncrement = True
        SpecID.AutoIncrementStep = -1
        SpecID.AutoIncrementSeed = -1
        SpecID.ReadOnly = False

        daRev.Fill(dsMain, "tblLisiSpecificationsRev")
        Dim RevID As DataColumn = dsMain.Tables("tblLisiSpecificationsRev").Columns("SpecRevID")
        RevID.AutoIncrement = True
        RevID.AutoIncrementStep = -1
        RevID.AutoIncrementSeed = -1
        RevID.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("SpecListRev", _
                .Tables("tblLisiSpecificationsControl").Columns("SpecID"), _
                .Tables("tblLisiSpecificationsRev").Columns("SpecID"), True)
        End With

        SpecCurrency = CType(BindingContext(dsMain, "tblLisiSpecificationsControl"), CurrencyManager)
        RevCurrency = CType(BindingContext(dsMain, "tblLisiSpecificationsRev"), CurrencyManager)

    End Sub

    Sub SetCtlForm()

        PutUser()

        'for dgspec   --   specifications Info

        With Me.SpecID
            .DataPropertyName = "SpecID"
            .Name = "SpecID"
            .Visible = False
        End With

        With Me.SpecNo
            .DataPropertyName = "SpecNo"
            .Name = "SpecNo"
        End With

        PutDwgSource()

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

        'for dgrev   --   revisions Info
        With Me.SpecRevID
            .DataPropertyName = "SpecRevID"
            .Name = "SpecRevID"
            .Visible = False
        End With

        With Me.SpecIDid
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

        With Me.RevApprovedID
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbgetSpecRevAppr").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
            .DataPropertyName = "RevApprovedID"
            .Name = "RevApprovedID"
        End With

        With Me.RevCreatedID
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEmployeeAll").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
            .DropDownWidth = 200
            .MaxDropDownItems = 40
            .DataPropertyName = "RevCreatedID"
            .Name = "RevCreatedID"
        End With

        With Me.SpecRevApprDate
            .DataPropertyName = "SpecRevApprDate"
            .Name = "SpecRevApprDate"
        End With

    End Sub

    Sub PutUser()

        With Me.CmbUser
            .DataSource = CallClass.PopulateComboBox("tblEmployee", "cmbGetEmployeeAll").Tables("tblEmployee")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

    End Sub

    Sub PutDwgSource()

        With Me.DwgSourceID
            .DataSource = CallClass.PopulateComboBox("tblPartDWGSource", "gettblPartDwgSource").Tables("tblPartDWGSource")
            .DisplayMember = "SourceName"
            .ValueMember = "DwgSourceID"
            .DropDownWidth = 300
            .DataPropertyName = "DwgSourceID"
            .Name = "DwgSourceID"
        End With


    End Sub

    Sub BindComponents()
       
        txtSpecDescr.DataBindings.Clear()
        txtSpecNotes.DataBindings.Clear()
        txtRevNotes.DataBindings.Clear()
        txtRevDescr.DataBindings.Clear()

        txtSpecDescr.DataBindings.Add("Text", dsMain, "tblLisiSpecificationsControl.SpecDescr")
        txtSpecNotes.DataBindings.Add("Text", dsMain, "tblLisiSpecificationsControl.SpecNotes")
        txtRevNotes.DataBindings.Add("Text", dsMain, "tblLisiSpecificationsControl.SpecListRev.SpecRevNotes")
        txtRevDescr.DataBindings.Add("Text", dsMain, "tblLisiSpecificationsControl.SpecListRev.SpecRevDescr")

    End Sub

    Private Sub HandleRowUpdatedMatlSpec(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblLisiSpecificationsControl").Columns("SpecID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub HandleRowUpdatedMatlSpecRev(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)

        Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cn)
        If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
            e.Row(dsMain.Tables("tblLisiSpecificationsRev").Columns("SpecRevID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
            e.Row.AcceptChanges()
        End If

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        CmbSpecNo.Enabled = False

        enableFields()

    End Sub

    Private Sub dgSpec_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgSpec.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSpec = e.RowIndex
        End If

    End Sub

    Private Sub dgSpec_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSpec.CellClick
        If e.RowIndex >= 0 Then
            RowSpec = e.RowIndex
            If dgSpec.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgSpec("SpecStatus", e.RowIndex).Value) = False Then
                If dgSpec.Rows(e.RowIndex).Cells("SpecStatus").Value = "InActive" Then
                    MsgBox("Specification Status = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Specification Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgSpec.Rows(e.RowIndex).Cells("SpecStatus").Value = "Active"
                    End If
                End If
            End If
        End If

        Select Case e.ColumnIndex
            Case 3
                frmEngDWGSourceName.ShowDialog()
                PutDwgSource()
        End Select

    End Sub

    Private Sub dgSpec_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpec.CellEndEdit

        Select Case e.ColumnIndex

            Case 1      'revno

                If Convert.ToString(Len(Trim(dgSpec.Rows(e.RowIndex).Cells("SpecStatus").ToString))) = 0 Or _
                            IsDBNull(dgSpec.Rows(e.RowIndex).Cells("SpecStatus").Value) = True Then
                    dgSpec.Rows(e.RowIndex).Cells("SpecStatus").Value = "Active"
                Else
                    Exit Sub
                End If

        End Select

    End Sub

    Private Sub dgSpec_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgSpec.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowSpec = e.RowIndex
        End If
    End Sub

    Private Sub dgSpec_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSpec.DataError
        REM END
    End Sub

    Private Sub dgRev_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgRev.CellBeginEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 2, 3, 4, 5, 7, 8


                If IsDBNull(dgRev("RevApprovedID", e.RowIndex).Value) = False Then
                    'If SwFirst = False Then
                    MsgBox("Action Denied - Spec Revision was already approved.")
                    e.Cancel = True
                    'End If
                End If
                'If Convert.ToString(Len(Trim(dgRev.Rows(e.RowIndex).Cells("RevApprovedID").ToString))) = True Or _
                '            IsDBNull(dgRev.Rows(e.RowIndex).Cells("RevApprovedID").Value) = False Then
                '    MsgBox("Action Denied - Spec Revision was already approved.")
                '    e.Cancel = True
                'End If

        End Select


    End Sub

    Private Sub dgRev_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRev.CellClick

        If e.RowIndex >= 0 Then
            If dgRev.ReadOnly = True Then
                Exit Sub
            End If
            If IsDBNull(Me.dgRev("SpecRevStatus", e.RowIndex).Value) = False Then
                If dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").Value = "InActive" Then
                    MsgBox("Specification Revision Status = InActive  -  Readonly")
                    Dim reply As DialogResult
                    reply = MsgBox("Do you want to Reset Specification Revision Status ? ", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").Value = "Active"
                    End If
                End If
            End If
        End If

        Select Case e.ColumnIndex

            Case 4, 8

                dgRev.Columns(e.ColumnIndex).ReadOnly = True

            Case 7

                If SwFirst = True Then
                    Exit Sub
                End If

                If IsDBNull(dgRev("SpecRevApprDate", e.RowIndex).Value) = True Or IsNothing(dgRev("SpecRevApprDate", e.RowIndex).Value) = True Then
                    SwFirst = True
                Else
                    SwFirst = False
                End If

            Case 10         'send email
                If IsDBNull(dgRev("SpecRevNo", e.RowIndex).Value) = True Then
                    MsgBox("Action Denied - Missing Spec Revision.")
                Else
                    If (IsDBNull(dgRev("SpecRevStatus", e.RowIndex).Value) = False And dgRev("SpecRevStatus", e.RowIndex).Value = "InActive") Then
                        MsgBox("Action Denied - Spec Revision InActive.")
                    Else
                        Dim reply As DialogResult
                        Dim email As New Mail.MailMessage()
                        Dim strBody As String = ""
                        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)

                        reply = MsgBox("DO you want to send an email notification ? Continue(Yes / No)", MsgBoxStyle.YesNo)
                        If reply = Windows.Forms.DialogResult.Yes Then
                            email.Subject = " !!! LAC SPECIFICATIONS LIST !!!"
                            strBody = "Specification: " + Trim(dgSpec("SpecNo", RowSpec).Value) + ", Revison Number: " + Trim(dgRev("SpecRevNo", e.RowIndex).Value) + " was Created / Modified in MRP." + vbCrLf
                            strBody = strBody + "===========================================================================" + vbCrLf

                            email.Body = strBody
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            email.To.Add(New Mail.MailAddress("stefan.tudor@lisi-aerospace.com"))
                            'email.To.Add(New Mail.MailAddress("Christian.MIHAILESCU@lisi-aerospace.com"))
                            email.To.Add(New Mail.MailAddress("Mariusz.JAWORSKI@lisi-aerospace.com"))
                            email.To.Add(New Mail.MailAddress("Vincent.PILLAI@lisi-aerospace.com"))
                            email.To.Add(New Mail.MailAddress("Madeleine.GOMEZ@lisi-aerospace.com"))
                            client.Send(email)
                        End If
                    End If
                End If

        End Select

    End Sub

    Private Sub dgRev_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRev.CellEndEdit

        Select Case e.ColumnIndex

            Case 2      'revno

                'If Convert.ToString(Len(Trim(dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").ToString))) = 0 Or _
                '            IsDBNull(dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").Value) = True Then
                '    dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").Value = "Active"
                'Else
                '    Exit Sub
                'End If

                If IsDBNull(dgRev("SpecRevStatus", e.RowIndex).Value) = True Then
                    dgRev("SpecRevStatus", e.RowIndex).Value = "Active"
                End If

                If IsDBNull(dgRev("RevCreatedID", e.RowIndex).Value) = True Then
                    dgRev("RevCreatedID", e.RowIndex).Value = CmbUser.SelectedValue
                End If

            Case 7      ' approved by

                If IsDBNull(dgRev("SpecRevApprDate", e.RowIndex).Value) = True Or IsNothing(dgRev("SpecRevApprDate", e.RowIndex).Value) = True Then
                    dgRev("SpecRevApprDate", e.RowIndex).Value = Now.ToShortDateString
                End If


        End Select

    End Sub

    Private Sub dgRev_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRev.DataError
        REM END
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        dgSpec.ReadOnly = True
        dgRev.ReadOnly = True
        Me.Focus()
        txtRevDescr.Focus()
        dgSpec.Focus()
        dgRev.Focus()
        CmbUser.Focus()
        dgRev.Focus()
        txtRevDescr.Focus()
        dgSpec.Focus()


        Call ValPo()

        If SwVal = True Then

            SwOper = "Save"

            SpecCurrency.EndCurrentEdit()
            RevCurrency.EndCurrentEdit()

            Try
                If dsMain.HasChanges Then
                    dsMain.GetChanges()
                    daSpec.Update(dsMain.Tables("tblLisiSpecificationsControl").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                    daRev.Update(dsMain.Tables("tblLisiSpecificationsRev").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))

                    dsMain.AcceptChanges()
                    MsgBox("Update successfully.")

                End If
            Catch ex As Exception
                dsMain.RejectChanges()
                MsgBox("Exception occured - " & ex.Message)
            End Try

            dgSpec.Refresh()
            dgRev.Refresh()

            DisableFields()

            FirstTimeMenuButtons()

            CmdNew.Enabled = False
            CmdEdit.Enabled = False

            BuildSqlCommand()

        End If

    End Sub

    Sub ValPo()

        For Each Row As DataGridViewRow In dgSpec.Rows
            If IsDBNull(Row.Cells("SpecNo").Value) = True Then
                MsgBox("!!! ERROR !!! Specification Number is Empty.")
                SwVal = False
                Exit Sub
            End If

            '
        Next

        'For Each Row As DataGridViewRow In dgRev.Rows
        '    If IsDBNull(Row.Cells("SpecRevNo").Value) = True Then
        '        MsgBox("!!! ERROR !!! Specification Revision Number is Empty.")
        '        SwVal = False
        '        Exit Sub
        '    End If
        'Next

        SwVal = True

    End Sub

    Private Sub dgSpec_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgSpec.RowPrePaint
        If IsDBNull(Me.dgSpec("SpecStatus", e.RowIndex).Value) = False Then
            If dgSpec.Rows(e.RowIndex).Cells("SpecStatus").Value = "InActive" Then
                dgSpec.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgSpec.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub dgRev_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgRev.RowPrePaint

        If IsDBNull(Me.dgRev("SpecRevStatus", e.RowIndex).Value) = False Then
            If dgRev.Rows(e.RowIndex).Cells("SpecRevStatus").Value = "InActive" Then
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
            Else
                dgRev.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Empty
            End If
        End If
    End Sub

    Private Sub CmdReset_Click(sender As Object, e As EventArgs) Handles CmdReset.Click

        SpecCurrency.EndCurrentEdit()
        RevCurrency.EndCurrentEdit()

        dsMain.RejectChanges()

        ClearFields()

        DisableFields()

        FirstTimeMenuButtons()

        BuildSqlCommand()

        InitialComponents()

        BindComponents()

        dgSpec.AutoGenerateColumns = False
        dgSpec.DataSource = dsMain
        dgSpec.DataMember = "tblLisiSpecificationsControl"

        dgRev.AutoGenerateColumns = False
        dgRev.DataSource = dsMain
        dgRev.DataMember = "tblLisiSpecificationsControl.SpecListRev"

        CallClass.PopulateDataAdapter("gettblLisiSpecificationsControl").Fill(dsMain, "tblLisiSpecificationsControl")

        With CmbSpecNo
            .DataSource = dsMain.Tables("tblLisiSpecificationsControl")
            .DisplayMember = "SpecNo"
            .ValueMember = "SpecID"
        End With


        CmbSpecNo.Enabled = True

        SwOper = ""

    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click

        CmdNew.Enabled = True
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        CmdReset.Enabled = True

        CmbSpecNo.Enabled = False

        dsMain.RejectChanges()
        dgSpec.Refresh()
        dgRev.Refresh()

        CmbSpecNo.SelectedIndex = -1

        SpecCurrency.EndCurrentEdit()
        SpecCurrency.AddNew()

        EnableFields()

        CmbSpecNo.Focus()

    End Sub

    Private Sub CmbSpecNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSpecNo.SelectedIndexChanged

        If SwOper = "Save" Then
            Exit Sub
        End If


        Me.BindingContext(dsMain, "tblLisiSpecificationsControl").Position = CType(CmbSpecNo.SelectedIndex, String)

        BindComponents()

    End Sub

    Private Sub frmEngSpecList_Resize(sender As Object, e As EventArgs) Handles Me.Resize

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