Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmOrderAssignDellivToMPO

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon
    Private dsMain As New DataSet

    Dim RowOrd As Integer = 0
    Dim RowMPO As Integer = 0
    Dim RowDeliv As Integer = 0
    Dim KeepMpo As Integer = 0
    Dim SwVal As Boolean

    Dim DelDate As Date
    Dim StartDate As Date
    Dim EndDate As Date
    Dim strSearch As String = ""

    Private Sub frmOrderAssignDellivToMPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmOrderAssignDellivToMPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Call SetupForm()
        Me.Focus()

        CmbPart.Enabled = True
        CmbPart.Focus()

    End Sub

    Sub SetupForm()

        PageReadOnly()

        PutPartNumberMPOActive()
        SetCtlForm()

        FirstTimeMenuButtons()

        InitFields()

        InitialComponents()

        RdYes.Checked = False
        RdNo.Checked = True

    End Sub

    Sub PageReadOnly()

        dgOrd.ReadOnly = True
        dgMpo.ReadOnly = True

    End Sub

    Sub FirstTimeMenuButtons()

        cmdAssg.Enabled = False
        CmdReset.Enabled = True

    End Sub

    Sub InitFields()
        CmbPart.SelectedIndex = -1
    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getTblMpoMasterEmpty").Fill(dsMain, "tblMpo")

        CallClass.PopulateDataAdapter("gettblCustOrderItemEmpty").Fill(dsMain, "tblOrderAndItem")
        CallClass.PopulateDataAdapter("gettblCustOrderItemDelivEmpty").Fill(dsMain, "tblOrderDeliv")
        CallClass.PopulateDataAdapter("gettblCustOrderDelivWithMPODelivEmty").Fill(dsMain, "tblMpoDeliv")

        dsMain.EnforceConstraints = False

        'With dsMain
        '    .Relations.Add("MpoOrderItem", _
        '      .Tables("tblMpo").Columns("OrderItemsID"), _
        '        .Tables("tblOrderAndItem").Columns("OrderItemsID"), True)
        'End With

        'With dsMain
        '    .Relations.Add("MpoOrderDeliv", _
        '      .Tables("tblMpo").Columns("OrderItemsID"), _
        '        .Tables("tblOrderDeliv").Columns("OrderItemsID"), True)
        'End With

        With dsMain
            .Relations.Add("MpoDeliv", _
              .Tables("tblOrderDeliv").Columns("OrdDelivID"), _
                .Tables("tblMpoDeliv").Columns("OrdDelivID"), True)
        End With

    End Sub

    Sub PutPartNumberMPOActive()
        With CmbPart
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberForProductionAnalyze").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub SetCtlForm()

        'dgOrdItem
        With Me.OrderItemsID
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.OrderID
            .DataPropertyName = "OrderID"
            .Name = "OrderID"
            .Visible = False
        End With

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.OrdItemNo
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.OrdItemQty
            .DataPropertyName = "OrdItemQty"
            .Name = "OrdItemQty"
        End With

        With Me.OrdItemUM
            .DataPropertyName = "OrdItemUM"
            .Name = "OrdItemUM"
        End With

        With Me.OrdItemPrice
            .DataPropertyName = "OrdItemPrice"
            .Name = "OrdItemPrice"
        End With

        With Me.OrdItemStatus
            .DataPropertyName = "OrdItemStatus"
            .Name = "OrdItemStatus"
        End With

        With Me.NotesOrder
            .DataPropertyName = "NotesOrder"
            .Name = "NotesOrder"
        End With

        With Me.OrdItemNotes
            .DataPropertyName = "OrdItemNotes"
            .Name = "OrdItemNotes"
        End With

        'dgdeliv

        With Me.OrdDelivID
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.OrderItemsIDDeliv
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.DelivQty
            .DataPropertyName = "DelivQty"
            .Name = "DelivQty"
        End With

        With Me.DelivStatus
            .DataPropertyName = "DelivStatus"
            .Name = "DelivStatus"
        End With

        With Me.SwShipedQty
            .DataPropertyName = "SwShipedQty"
            .Name = "SwShipedQty"
        End With

        With Me.DelivQtyToShip
            .DataPropertyName = "DelivQtyToShip"
            .Name = "DelivQtyToShip"
        End With

        With Me.DelivWhat
            .DataPropertyName = "DelivWhat"
            .Name = "DelivWhat"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

        With Me.SwMpoQty
            .DataPropertyName = "SwMpoQty"
            .Name = "SwMpoQty"
        End With

        'dgMpo

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
            .Visible = False
        End With

        With Me.OrdDelivIDMpo
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.OrderItemsIDMpo
            .DataPropertyName = "OrderItemsID"
            .Name = "OrderItemsID"
            .Visible = False
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.MpoDelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.MpoPromDate
            .DataPropertyName = "MpoPromDate"
            .Name = "MpoPromDate"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.MpoPartID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DropDownWidth = 300
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
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

        With Me.DeptID
            .DataSource = CallClass.PopulateComboBox("tblDepartment", "cmbGetDepartment").Tables("tblDepartment")
            .DisplayMember = "DeptNode"
            .ValueMember = "DeptID"
            .DropDownWidth = 300
            .DataPropertyName = "DeptID"
            .Name = "DeptID"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
        End With

        'dgMpoSel

        With Me.OrdDelivIDSel
            .DataPropertyName = "OrdDelivID"
            .Name = "OrdDelivID"
            .Visible = False
        End With

        With Me.MpoNoSel
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

    End Sub

    Sub Searchpart()

        strSearch = CmbPart.SelectedValue
        dsMain.Clear()

        If Len(Trim(strSearch)) > 0 Then
            CallClass.PopulateDataAdapterAfterSearch("getTblMpoMasterbyPartNumber", strSearch).Fill(dsMain, "tblMpo")
        Else
            Exit Sub
        End If

        If dsMain.Tables("tblMpo").Rows.Count = 0 Then
            MessageBox.Show("!!! Warning !!! Part number missing, try again.")

            PageReadOnly()

            FirstTimeMenuButtons()

            InitFields()

            CmdReset.Focus()
            CmbPart.Focus()
        Else
            CmbPart.Enabled = False

            CallClass.PopulateDataAdapterAfterSearch("getTblCustOrderAndItemByPartNumber", strSearch).Fill(dsMain, "tblOrderAndItem")
            CallClass.PopulateDataAdapterAfterSearch("getTblCustOrderDelivByPartNumber", strSearch).Fill(dsMain, "tblOrderDeliv")
            CallClass.PopulateDataAdapter("gettblCustOrderDelivWithMPODeliv").Fill(dsMain, "tblMpoDeliv")

            dgMpo.AutoGenerateColumns = False
            dgMpo.DataSource = dsMain
            dgMpo.DataMember = "tblMpo"

            dgOrd.AutoGenerateColumns = False
            dgOrd.DataSource = dsMain
            'dgOrd.DataMember = "tblMpo.MpoOrderItem"
            dgOrd.DataMember = "tblOrderAndItem"

            If dsMain.Tables("tblOrderAndItem").Rows.Count > 0 Then
                dgOrd.Rows(0).Selected = True
                dgOrd.Columns("OrdNumber").Selected = True
            End If

            dgDel.AutoGenerateColumns = False
            dgDel.DataSource = dsMain
            ' dgDel.DataMember = "tblMpo.MpoOrderDeliv"
            dgDel.DataMember = "tblOrderDeliv"

            dgSelMPO.AutoGenerateColumns = False
            dgSelMPO.DataSource = dsMain
            ' dgDel.DataMember = "tblMpo.MpoOrderDeliv"
            dgSelMPO.DataMember = "tblOrderDeliv.MpoDeliv"

            cmdAssg.Enabled = True


        End If

    End Sub

    Private Sub CmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdReset.Click

        PageReadOnly()

        FirstTimeMenuButtons()

        InitFields()

        dsMain.Clear()
        CmbPart.Enabled = True
        CmbPart.Focus()

    End Sub

    Private Sub dgDel_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDel.CellBeginEdit

        RowDeliv = 0

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowDeliv = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 0, 1, 2, 3, 4, 5, 6, 8, 9
                e.Cancel = True
            Case 7
                For Each RDeliv As DataGridViewRow In dgDel.Rows
                    RDeliv.Cells("DelivWhat").Value = False
                Next
        End Select

    End Sub

    Private Sub dgDel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDel.CellClick

        CalculQtyToShip()
        PutMpoLinkColor()

    End Sub

    Private Sub dgDel_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDel.DataError
        REM end
    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick
        RowMPO = 0

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowMPO = e.RowIndex
        End If
    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Private Sub dgOrd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrd.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowOrd = e.RowIndex
        End If
    End Sub

    Private Sub dgOrd_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrd.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowOrd = e.RowIndex
        End If
    End Sub

    Private Sub dgOrd_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOrd.DataError
        REM end
    End Sub

    Private Sub cmdAssg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssg.Click

        Call ValPo()

        If SwVal = True Then

            DelDate = CDate(dgDel("DelivDate", RowDeliv).Value).ToShortDateString
            StartDate = DateAdd(DateInterval.Day, -112, DelDate).ToShortDateString      '16 wks
            EndDate = DateAdd(DateInterval.Day, -35, DelDate).ToShortDateString         '5 wks

            If RdNo.Checked = True Then
                CreateDeliv()
            Else
                CreateDelivPO()
            End If

            MsgBox("Update successfully.")
            dsMain.AcceptChanges()

            dsMain.Clear()
            CallClass.PopulateDataAdapterAfterSearch("getTblMpoMasterbyPartNumber", strSearch).Fill(dsMain, "tblMpo")

            CallClass.PopulateDataAdapterAfterSearch("getTblCustOrderAndItemByPartNumber", strSearch).Fill(dsMain, "tblOrderAndItem")
            CallClass.PopulateDataAdapterAfterSearch("getTblCustOrderDelivByPartNumber", strSearch).Fill(dsMain, "tblOrderDeliv")
            CallClass.PopulateDataAdapter("gettblCustOrderDelivWithMPODeliv").Fill(dsMain, "tblMpoDeliv")

            dgMpo.AutoGenerateColumns = False
            dgMpo.DataSource = dsMain
            dgMpo.DataMember = "tblMpo"

            dgOrd.AutoGenerateColumns = False
            dgOrd.DataSource = dsMain
            'dgOrd.DataMember = "tblMpo.MpoOrderItem"
            dgOrd.DataMember = "tblOrderAndItem"

            dgDel.AutoGenerateColumns = False
            dgDel.DataSource = dsMain
            ' dgDel.DataMember = "tblMpo.MpoOrderDeliv"
            dgDel.DataMember = "tblOrderDeliv"

            dgSelMPO.AutoGenerateColumns = False
            dgSelMPO.DataSource = dsMain
            ' dgDel.DataMember = "tblMpo.MpoOrderDeliv"
            dgSelMPO.DataMember = "tblOrderDeliv.MpoDeliv"

            'dgMpo.Rows(RowMPO).Selected = True

        End If

    End Sub

    Sub CreateDeliv()

        If RowDeliv < 0 Then
            MsgBox("!!! ERROR Delivery Index !!!  Try Again.")
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDelivDateAssg", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgMpo("MpoID", RowMPO).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraOrdDelID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraOrdDelID.Value = dgDel("OrdDelivID", RowDeliv).Value
            mySqlComm.Parameters.Add(paraOrdDelID)

            Dim paraStartDate As SqlParameter = New SqlParameter("@StartProdDate", SqlDbType.SmallDateTime, 4)
            paraStartDate.Value = StartDate
            mySqlComm.Parameters.Add(paraStartDate)

            Dim paraEndDate As SqlParameter = New SqlParameter("@EndProdDate", SqlDbType.SmallDateTime, 4)
            paraEndDate.Value = EndDate
            mySqlComm.Parameters.Add(paraEndDate)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Insert Mpo Update Sql: " & ex.Message)
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Insert Mpo Parameter: " & ex.Message)
        End Try

    End Sub

    Sub CreateDelivPO()

        If RowOrd < 0 Then
            MsgBox("!!! ERROR Index Order !!!  Try Again.")
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoDelivDateAssgWithPO", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgMpo("MpoID", RowMPO).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraOrderItemsID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
            paraOrderItemsID.Value = dgOrd("OrderItemsID", RowOrd).Value
            mySqlComm.Parameters.Add(paraOrderItemsID)

            Dim paraOrdDelID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraOrdDelID.Value = dgDel("OrdDelivID", RowDeliv).Value
            mySqlComm.Parameters.Add(paraOrdDelID)

            Dim paraStartDate As SqlParameter = New SqlParameter("@StartProdDate", SqlDbType.SmallDateTime, 4)
            paraStartDate.Value = StartDate
            mySqlComm.Parameters.Add(paraStartDate)

            Dim paraEndDate As SqlParameter = New SqlParameter("@EndProdDate", SqlDbType.SmallDateTime, 4)
            paraEndDate.Value = EndDate
            mySqlComm.Parameters.Add(paraEndDate)

            Try
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Insert Mpo Update Sql: " & ex.Message)
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Insert Mpo Parameter: " & ex.Message)
        End Try

    End Sub

    Sub ValPo()

        Dim II As Integer = 0
        SwVal = False
        II = 0

        For Each RDeliv As DataGridViewRow In dgDel.Rows
            If Nz.Nz(RDeliv.Cells.Item("DelivWhat").Value) = True Then
                II = II + 1
            End If
        Next
        If II = 1 Then
            SwVal = True
        Else
            MsgBox("!!! ERROR !!! Delivery Data is not Selected or there are more of one delivery selected.")
            SwVal = False
            Exit Sub
        End If
    End Sub

    Sub CalculQtyToShip()

        For Each Row As DataGridViewRow In dgDel.Rows
            Row.Cells("DelivQtyToShip").Value = Nz.Nz(Row.Cells("DelivQty").Value) - Nz.Nz(Row.Cells("SwShipedQty").Value)

            If Nz.Nz(Row.Cells("DelivQtyToShip").Value) <> Nz.Nz(Row.Cells("DelivQty").Value) Then
                Row.Cells("DelivQtyToShip").Style.BackColor = Color.Coral
            Else
                Row.Cells("DelivQtyToShip").Style.BackColor = Color.White
            End If
        Next

        dgDel.Focus()

    End Sub

    Sub PutMpoLinkColor()

        For K As Integer = 0 To (dgMpo.Rows.Count - 1)
            dgMpo("MPONo", K).Style.BackColor = Color.White
        Next K

        For K As Integer = 0 To (dgDel.Rows.Count - 1)
            For J As Integer = 0 To (dgSelMPO.Rows.Count - 1)
                For M As Integer = 0 To (dgMpo.Rows.Count - 1)
                    If dgSelMPO("MPONo", J).Value = dgMpo("MpoNo", M).Value Then
                        dgMpo("MPONo", M).Style.BackColor = Color.Khaki
                    End If
                Next M
            Next J
        Next K

    End Sub

    Private Sub CmbPart_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPart.DropDownClosed

        RdYes.Checked = False
        RdNo.Checked = True

        Searchpart()
        dgMpo.Focus()
        CmbPart.Focus()
    
    End Sub

    Private Sub dgSelMPO_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgSelMPO.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgSelMPO_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgSelMPO.DataError
        REM end
    End Sub
End Class