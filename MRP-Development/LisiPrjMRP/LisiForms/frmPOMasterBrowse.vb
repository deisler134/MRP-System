Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmPOMasterBrowse
    Inherits System.Windows.Forms.Form

    Dim cnSql As New SqlConnection(strConnection)

    Private dsMain As New DataSet

    Dim cmProd As CurrencyManager
    Private daProd As New SqlDataAdapter

    Dim intProd As Integer

    Dim strSQL As String
    Dim TakeRowIdx As Integer

    Private Sub frmPOMasterBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        txtRow.Visible = False

        cnSql.Open()

        Connect()

        Try
            dsMain.Clear()

            daProd.FillSchema(dsMain, SchemaType.Source, "tblPOProdDescr")
           
            daProd.Fill(dsMain, "tblPOProdDescr")

            dsMain.EnforceConstraints = False

            cmProd = CType(BindingContext(dsMain, "tblPOProdDescr"), CurrencyManager)

            dsMain.Tables("tblPOProdDescr").Columns("ProdID").ColumnMapping = MappingType.Hidden

            Dim tableStyle As New DataGridTableStyle()
            tableStyle.MappingName = "tblPOProdDescr"

            With Me.ProdID
                .DataPropertyName = "ProdID"
                .Name = "ProdID"
            End With

            With Me.ProdDescr
                .DataPropertyName = "ProdDescr"
                .Name = "ProdDescr"
            End With

            With Me.ProdSpec
                .DataPropertyName = "ProdSpec"
                .Name = "ProdSpec"
            End With

            dgDetail.AutoGenerateColumns = False
            dgDetail.DataSource = dsMain
            dgDetail.DataMember = "tblPOProdDescr"

            BindFields()

        Catch ex As Exception
            MsgBox("Error: " & ex.Source & ": " & ex.Message, _
            MsgBoxStyle.OKOnly, "frmPOMasterBrowse_Load")
            Me.Hide()
        End Try

        CmdNew.Enabled = True
        Cmdrestore.Enabled = True

        CmdEdit.Enabled = True
        dgDetail.ReadOnly = True
        txtDescr.ReadOnly = True
        txtSpec.ReadOnly = True

        '=======================
        Dim I, J As Integer
        I = CInt(txtRow.Text)
        txtRow.Visible = False
        J = Val(frmPOMaster.dgDetail("POItem", I).Value.ToString)
        If J = 0 Then
            MessageBox.Show("Action Denied. Enter before the PO item number.")
            Me.Close()
        Else
            If Not Len(Trim(txtProdID.Text)) = 0 Then
                If Not IsDBNull(txtProdID.Text) = True Then
                    Call SearchForProductID()
                End If
            End If
        End If

    End Sub

    Private Function Connect() As Boolean

        strSQL = "Select * FROM tblPoProdDescr Order by ProdDescr"

        Try
            Dim commProd As New SqlClient.SqlCommand(strSQL, cnSql)

            daProd.SelectCommand = commProd
            
            Dim cmdProduct As New SqlClient.SqlCommandBuilder(daProd)
            
            daProd.UpdateCommand = cmdProduct.GetUpdateCommand
            daProd.UpdateCommand.Connection = cnSql
            daProd.InsertCommand = cmdProduct.GetInsertCommand
            AddHandler daProd.RowUpdated, AddressOf HandleRowUpdatedProduct
            daProd.InsertCommand.Connection = cnSql
            daProd.DeleteCommand = cmdProduct.GetDeleteCommand
            daProd.DeleteCommand.Connection = cnSql

            daProd.AcceptChangesDuringFill = True
            daProd.TableMappings.Add("Table", "tblPoProdDescr")
            daProd.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Catch ex As Exception
            MsgBox("Exception occured - Connect Fuction  " & ex.Message)
        Finally

        End Try

    End Function

    Private Sub HandleRowUpdatedProduct(ByVal sender As Object, ByVal e As SqlRowUpdatedEventArgs)
        Try
            Dim cmdGetIdentity As New SqlCommand("SELECT @@IDENTITY", cnSql)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                e.Row(dsMain.Tables("tblPoProdDescr").Columns("ProdID")) = Int32.Parse(cmdGetIdentity.ExecuteScalar.ToString)
                e.Row.AcceptChanges()
            End If

        Catch ex As Exception
            'MsgBox("Exception occured - HandleRowUpdatedDetail   " & ex.Message)
        End Try

    End Sub

    Private Sub frmPOMasterBrowse_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If cmProd.Count > 0 Then
            cmProd.EndCurrentEdit()
        End If

        If dsMain.HasChanges Then
            Dim reply As DialogResult
            reply = MsgBox("The DataSet has changes that were not committed to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

        cnSql.Close()

        GC.Collect()

    End Sub

    Private Function BindFields() As Boolean

        txtDescr.DataBindings.Add("Text", dsMain, "tblPoProdDescr.ProdDescr")
        txtSpec.DataBindings.Add("Text", dsMain, "tblPoProdDescr.ProdSpec")

    End Function

    Private Sub SearchForProductID()

        Try
            strSQL = "Select * FROM tblPoProdDescr WHERE ProdID = " & CInt(txtProdID.Text)
            Dim commProd As New SqlClient.SqlCommand(strSQL, cnSql)
            daProd.SelectCommand = commProd
            dsMain.Clear()
            daProd.FillSchema(dsMain, SchemaType.Source, "tblPOProdDescr")
            daProd.Fill(dsMain, "tblPOProdDescr")
            Dim SwProdID As DataColumn = dsMain.Tables("tblPOProdDescr").Columns("ProdID")
            SwProdID.AutoIncrement = True
            SwProdID.AutoIncrement = True
            SwProdID.AutoIncrementStep = -1
            SwProdID.AutoIncrementSeed = -1
            SwProdID.ReadOnly = False
            dsMain.EnforceConstraints = False

            cmProd = CType(BindingContext(dsMain, "tblPOProdDescr"), CurrencyManager)

            dsMain.Tables("tblPOProdDescr").Columns("ProdID").ColumnMapping = MappingType.Hidden
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            Call SearchText()
        End If

    End Sub

    Private Sub txtSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Leave

        Call SearchText()

    End Sub

    Private Sub SearchText()
        If Not Len(Trim(txtSearch.Text)) = 0 Then
            If Not IsDBNull(txtSearch.Text) Then
                Try
                    strSQL = "Select * FROM tblPoProdDescr WHERE (ProdDescr LIKE '%" & txtSearch.Text & "%') ORDER BY ProdDescr"
                    Dim commProd As New SqlClient.SqlCommand(strSQL, cnSql)
                    daProd.SelectCommand = commProd
                    dsMain.Clear()
                    daProd.FillSchema(dsMain, SchemaType.Source, "tblPOProdDescr")
                    daProd.Fill(dsMain, "tblPOProdDescr")
                    Dim SwProdID As DataColumn = dsMain.Tables("tblPOProdDescr").Columns("ProdID")
                    SwProdID.AutoIncrement = True
                    SwProdID.AutoIncrement = True
                    SwProdID.AutoIncrementStep = -1
                    SwProdID.AutoIncrementSeed = -1
                    SwProdID.ReadOnly = False
                    dsMain.EnforceConstraints = False

                    cmProd = CType(BindingContext(dsMain, "tblPOProdDescr"), CurrencyManager)

                    dsMain.Tables("tblPOProdDescr").Columns("ProdID").ColumnMapping = MappingType.Hidden
                Catch ex As System.Exception
                    MessageBox.Show(ex.Message)
                End Try

                Cmdrestore.Focus()
            End If
        End If

    End Sub

    Private Sub Cmdrestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdrestore.Click

        Try
            strSQL = "Select * FROM tblPoProdDescr ORDER BY ProdDescr"
            Dim commProd As New SqlClient.SqlCommand(strSQL, cnSql)
            daProd.SelectCommand = commProd
            dsMain.Clear()
            daProd.Fill(dsMain, "tblPOProdDescr")
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Cmdrestore.Enabled = True
    End Sub

    Private Sub CmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNew.Click

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True
        Cmdrestore.Enabled = False

        dsMain.Clear()
        Me.BindingContext(dsMain, "tblPOProdDescr").EndCurrentEdit()
        Me.BindingContext(dsMain, "tblPOProdDescr").AddNew()

        txtSearch.Visible = False
        txtDescr.ReadOnly = False
        txtSpec.ReadOnly = False
        dgDetail.ReadOnly = False
        dgDetail.Focus()

    End Sub

    Private Sub CmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = True

        txtDescr.ReadOnly = False
        txtSpec.ReadOnly = False
        dgDetail.ReadOnly = False

        Cmdrestore.Enabled = False
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click

        txtDescr.ReadOnly = True
        txtSpec.ReadOnly = True

        CmdNew.Enabled = False
        CmdEdit.Enabled = False
        CmdSave.Enabled = False
        Cmdrestore.Enabled = False
        dgDetail.ReadOnly = True
        dgDetail.Refresh()
        txtSearch.Visible = True
        txtSearch.Focus()

        Me.BindingContext(dsMain, "tblPOProdDescr").EndCurrentEdit()

        Try
            If dsMain.HasChanges Then
                dsMain.GetChanges()
                intProd = daProd.Update(dsMain.Tables("tblPOProdDescr").Select("", "", DataViewRowState.Added Or DataViewRowState.ModifiedCurrent))
                intProd += daProd.Update(dsMain.Tables("tblPOProdDescr").Select("", "", DataViewRowState.Deleted))
            End If

        Catch ex As Exception
            MsgBox("Exception occured - " & ex.Message)
        Finally
        End Try
        dsMain.AcceptChanges()

    End Sub

    Private Sub dgDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        TakeRowIdx = e.RowIndex

        If e.ColumnIndex = 0 Then
            'If Not IsDBNull(Me.dgDetail("ProdID", TakeRowIdx).Value) Then
            frmPOMaster.RecvPoID.Text = Me.dgDetail("ProdID", TakeRowIdx).Value

            If cmProd.Count > 0 Then
                cmProd.EndCurrentEdit()
            End If

            Me.Close()
            cnSql.Close()
            'End If
        End If

    End Sub

    Private Sub dgDetail_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetail.DataError
        REM end
    End Sub
End Class