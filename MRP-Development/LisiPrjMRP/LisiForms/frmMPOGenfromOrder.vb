Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Net
Imports System.Net.Mail

Public Class frmMPOGenfromOrder

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Private dsMain As New DataSet

    Dim RowOrd As Integer = 0
    Dim RowMPO As Integer = 0
    Dim RowDel As Integer = 0
    Dim KeepMpo As Integer = 0
    Dim SwVal As Boolean

    Dim DelDate As Date
    Dim PromDate As Date
    Dim StartDate As Date
    Dim EndDate As Date

    Dim KeepIndex As Integer = 0

    Dim IReturn As Integer = 0
    Dim SwMpoID As Integer = 0

    Private Sub frmMPOGenfromOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim reply As DialogResult

        'If dsMain.HasChanges Then
        'reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
        'If reply = DialogResult.No Then e.Cancel = True
        'Exit Sub
        'End If

        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()
    End Sub

    Private Sub frmMPOGenfromOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Call SetupForm()

        CmdAssign.Visible = False

        txtDelDate.Text = ""
        txtOrdDelivID.Text = ""
        txtExpediteValue.Text = ""

    End Sub

    Sub SetupForm()
        cmbCust.Enabled = False
        txtOrd.ReadOnly = True
        txtOrdDate.ReadOnly = True
        txtOrdDevise.ReadOnly = True
        txtOrdNotes.ReadOnly = True

        InitialComponents()

        SetCtlForm()

        BindData()

        dgOrd.AutoGenerateColumns = False
        dgOrd.DataSource = dsMain
        dgOrd.DataMember = "tblCustOrder.OrdItem"

        dgDel.AutoGenerateColumns = False
        dgDel.DataSource = dsMain
        dgDel.DataMember = "tblCustOrder.OrdItem.ItemDeliv"

        dgMpo.AutoGenerateColumns = False
        dgMpo.DataSource = dsMain
        dgMpo.DataMember = "tblCustOrder.OrdItem.ItemMpo"

        'CmbOrder.DataSource = dsMain.Tables("tblCustOrder")
        'CmbOrder.DisplayMember = "OrdNumber"
        'CmbOrder.ValueMember = "OrderID"

        With CmbOrder
            .DataSource = dsMain.Tables("tblCustOrder")
            .DisplayMember = "DispInfo"
            .ValueMember = "OrderID"
        End With

        txtQtySelected.Text = ""
        txtQtySelected.ReadOnly = False

        MpoMaster.Text = ""
        MpoMaster.ReadOnly = True

    End Sub

    Sub InitialComponents()

        dsMain.Clear()
        dsMain.Relations.Clear()

        CallClass.PopulateDataAdapter("getTblMpoMaster").FillSchema(dsMain, SchemaType.Source, "tblMpoMaster")

        'CallClass.PopulateDataAdapter("gettblCustOrder").Fill(dsMain, "tblCustOrder")
        CallClass.PopulateDataAdapter("gettblCustOrderDispInfoForDelivReq").Fill(dsMain, "tblCustOrder")
        CallClass.PopulateDataAdapter("gettblCustOrderItem").Fill(dsMain, "tblCustOrderItem")
        CallClass.PopulateDataAdapter("gettblCustOrderItemDeliv").Fill(dsMain, "tblCustOrderItemDeliv")

        CallClass.PopulateDataAdapter("getTblMpoMaster").Fill(dsMain, "tblMpoMaster")
        Dim JobId As DataColumn = dsMain.Tables("tblMpoMaster").Columns("MpoID")
        JobId.AutoIncrement = True
        JobId.AutoIncrementStep = -1
        JobId.AutoIncrementSeed = -1
        JobId.ReadOnly = False

        dsMain.EnforceConstraints = False

        With dsMain
            .Relations.Add("OrdItem", _
              .Tables("tblCustOrder").Columns("OrderID"), _
                .Tables("tblCustOrderItem").Columns("OrderID"), True)
        End With

        With dsMain
            .Relations.Add("ItemDeliv", _
              .Tables("tblCustOrderItem").Columns("OrderItemsID"), _
                .Tables("tblCustOrderItemDeliv").Columns("OrderItemsID"), True)
        End With

        With dsMain
            .Relations.Add("ItemMpo", _
              .Tables("tblCustOrderItem").Columns("OrderItemsID"), _
                .Tables("tblMpoMaster").Columns("OrderItemsID"), True)
        End With

    End Sub

    Sub BindData()

        cmbCust.DataBindings.Clear()
        txtOrd.DataBindings.Clear()
        txtOrdDate.DataBindings.Clear()
        txtOrdDevise.DataBindings.Clear()
        txtOrdNotes.DataBindings.Clear()

        cmbCust.DataBindings.Add("SelectedValue", dsMain, "tblCustOrder.CustID")
        txtOrd.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdNumber")
        txtOrdDate.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDate")
        txtOrdDevise.DataBindings.Add("Text", dsMain, "tblCustOrder.OrdDevise")
        txtOrdNotes.DataBindings.Add("Text", dsMain, "tblCustOrder.NotesOrder")

    End Sub

    Sub SetCtlForm()

        PutCust()
        cmbCust.SelectedIndex = -1

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

        With Me.OrdItemNo
            .DataPropertyName = "OrdItemNo"
            .Name = "OrdItemNo"
        End With

        With Me.OrdPartNoID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DropDownWidth = 300
            .DataPropertyName = "OrdPartNoID"
            .Name = "OrdPartNoID"
        End With

        With Me.OrdPartCross99ID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumberCross20").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DataPropertyName = "OrdPartCross99ID"
            .Name = "OrdPartCross99ID"
            .DropDownWidth = 300
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

        With Me.DelivWhat
            .DataPropertyName = "DelivWhat"
            .Name = "DelivWhat"
        End With

        With Me.DelivType
            .DataPropertyName = "DelivType"
            .Name = "DelivType"
        End With

        With Me.DelivNotes
            .DataPropertyName = "DelivNotes"
            .Name = "DelivNotes"
        End With

        'dgMpo

        With Me.MpoId
            .DataPropertyName = "MpoId"
            .Name = "MpoId"
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

        With Me.MpoDate
            .DataPropertyName = "MpoDate"
            .Name = "MpoDate"
        End With

        With Me.StartProdDate
            .DataPropertyName = "StartProdDate"
            .Name = "StartProdDate"
        End With

        With Me.EndProdDate
            .DataPropertyName = "EndProdDate"
            .Name = "EndProdDate"
        End With

        With Me.MpoStatus
            .DataPropertyName = "MpoStatus"
            .Name = "MpoStatus"
        End With

        With Me.MpoPartID
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
            .DropDownWidth = 300
            .DataPropertyName = "MpoPartID"
            .Name = "MpoPartID"
        End With

        With Me.MpoPartType
            .DataPropertyName = "MpoPartType"
            .Name = "MpoPartType"
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
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

        With Me.ChNewOrder
            .DataPropertyName = "ChNewOrder"
            .Name = "ChNewOrder"
        End With

        With Me.MpoNotes
            .DataPropertyName = "MpoNotes"
            .Name = "MpoNotes"
        End With

    End Sub

    Sub PutCust()
        With Me.CmbCust
            .DataSource = CallClass.PopulateComboBox("tblCustomers", "cmbGetCustomer").Tables("tblCustomers")
            .DisplayMember = "CustomerName"
            .ValueMember = "CustomerID"
        End With

    End Sub

    Private Sub CmbOrder_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOrder.DropDownClosed
        KeepIndex = CmbOrder.SelectedValue
    End Sub

    Private Sub CmbOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbOrder.SelectedIndexChanged

        Me.BindingContext(dsMain, "tblCustOrder").Position = CType(CmbOrder.SelectedIndex, String)

        ClearSelection()

        txtDelDate.Text = ""
        txtOrdDelivID.Text = ""
        txtExpediteValue.Text = ""

        txtQtySelected.ReadOnly = False

        CmbMpoType.Text = ""
        CmbMpoType.SelectedText = "Standard"

        CalculGridsQty()

        If txtOrd.Text = "LISI Grinding" Then
            CmbMpoType.Text = "Grinding"
        End If

    End Sub

    Private Sub dgDel_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDel.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowDel = e.RowIndex
        End If

        If Microsoft.VisualBasic.UCase(txtOrd.Text) = "MIN/MAX" And dgDel.Rows(e.RowIndex).Cells("DelivType").Value = "Estimated" Then
            txtQtySelected.ReadOnly = False
            dgDel.Rows(e.RowIndex).Cells("DelivStatus").ReadOnly = False
        Else
            If dgDel.Rows(e.RowIndex).Cells("DelivStatus").Value <> "Active" Then
                MsgBox("You can not edit this field.")
                e.Cancel = True
                txtQtySelected.Text = ""
                txtQtySelected.ReadOnly = True
            Else
                txtQtySelected.ReadOnly = False
            End If
        End If

    End Sub

    Private Sub dgDel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDel.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowDel = e.RowIndex
        End If

        dgDel.Rows(e.RowIndex).Cells("DelivDate").ReadOnly = True
        dgDel.Rows(e.RowIndex).Cells("DelivQty").ReadOnly = True
        dgDel.Rows(e.RowIndex).Cells("DelivStatus").ReadOnly = True
        dgDel.Rows(e.RowIndex).Cells("SwShipedQty").ReadOnly = True
        dgDel.Rows(e.RowIndex).Cells("DelivNotes").ReadOnly = True
        dgDel.Rows(e.RowIndex).Cells("DelivType").ReadOnly = True
        
        dgDel.Rows(e.RowIndex).Cells("DelivWhat").ReadOnly = False

        If Microsoft.VisualBasic.UCase(txtOrd.Text) = "MIN/MAX" And dgDel.Rows(e.RowIndex).Cells("DelivType").Value = "Estimated" Then
            dgDel.Rows(e.RowIndex).Cells("DelivStatus").ReadOnly = False
        End If

    End Sub

    Private Sub dgDel_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDel.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowDel = e.RowIndex
        End If

        Select Case e.ColumnIndex
            Case 6
                Dim qty As Double = 0.0
                For Each Row As DataGridViewRow In dgDel.Rows
                    If Nz.Nz(Row.Cells("DelivWhat").Value) = True Then
                        qty = qty + Nz.Nz(Row.Cells("DelivQty").Value)
                    End If
                Next
                txtQtySelected.Text = qty.ToString("N2")
            Case 4
                UpdateDelivStatus()

        End Select
    End Sub

    Private Sub dgDel_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDel.DataError
        REM end
    End Sub

    Private Sub dgMpo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowMPO = e.RowIndex

        'dgMpo.Rows(e.RowIndex).Cells("MpoNo").ReadOnly = True
        'dgMpo.Rows(e.RowIndex).Cells("MpoDate").ReadOnly = True
        'dgMpo.Rows(e.RowIndex).Cells("MpoStatus").ReadOnly = True
        'dgMpo.Rows(e.RowIndex).Cells("MpoPartID").ReadOnly = True
        'dgMpo.Rows(e.RowIndex).Cells("QtyOrder").ReadOnly = True
        'dgMpo.Rows(e.RowIndex).Cells("QtyEngReleased").ReadOnly = True
        dgMpo.Rows(e.RowIndex).Cells("MpoNotes").ReadOnly = False
        Select Case e.ColumnIndex
            Case 2 To 10
                dgMpo.Columns(e.ColumnIndex).ReadOnly = True
        End Select

        KeepMpo = dgMpo.Rows(e.RowIndex).Cells("MpoID").Value

    End Sub

    Private Sub dgMpo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgMpo.CellEndEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 13
                UpdateGenMpo()
        End Select

    End Sub

    Private Sub dgMpo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgMpo.DataError
        REM end
    End Sub

    Private Sub dgOrd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrd.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowOrd = e.RowIndex

    End Sub

    Private Sub dgOrd_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrd.CellEnter
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowOrd = e.RowIndex

        CalculGridsQty()
    End Sub

    Private Sub dgOrd_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgOrd.DataError
        REM end
    End Sub

    Sub ClearSelection()

        For Each Row As DataGridViewRow In dgDel.Rows
            Row.Cells("DelivWhat").Value = False
        Next

        MpoMaster.Text = ""
        txtQtySelected.Text = ""

        cmdVerify.Enabled = True
        CmdAssign.Visible = False
        cmdDelete.Enabled = True

    End Sub

    Private Sub cmdVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerify.Click

        SwVal = True
        CmdAssign.Visible = False

        Dim II As Integer
        II = Len(Trim(txtQtySelected.Text))
        If II <= 0 Then
            MsgBox("Qty Order is Empty ")
            Exit Sub
        End If

        'If Len(Trim(txtDelDate.Text)) <= 0 Then
        '    MsgBox("ERROR  Missing Delivery Date.")
        '    Exit Sub
        'End If

        If dgOrd.RowCount > 0 Then
            For Each row As DataGridViewRow In dgOrd.Rows
                For Each cell As DataGridViewCell In row.Cells

                    With cell
                        If .ColumnIndex = 4 Then
                            If IsNothing(cell.Value) = True OrElse IsDBNull(cell.Value) = True Then
                                MsgBox("!!!  ERROR !!!  Missing Manufacturing P/N - ACTION DENIED")
                                SwVal = False
                                Exit Sub
                            Else
                                SwVal = True
                            End If
                        End If
                    End With
                Next
            Next
        End If

        '    For Each Row As DataGridViewRow In dgOrd.Rows
        '        SwTest = Row.Cells(4).Value.ToString()
        '        If Not String.IsNullOrEmpty(SwTest) Then
        '            If Not String.IsNullOrEmpty(Trim(SwTest).ToString()) Then
        '                MsgBox("!!!  ERROR !!!  Missing Manufacturing P/N - ACTION DENIED")
        '                SwVal = False
        '                Exit Sub
        '            Else
        '                SwVal = True
        '            End If
        '        End If
        '    Next
        'End If


        'For Each rw As DataGridViewRow In dataGridView1.Rows
        '    For i As Integer = 0 To rw.Cells.Count - 1
        '        If rw.Cells(i).Value Is Nothing OrElse rw.Cells(i).Value = DBNull.Value OrElse String.IsNullOrWhiteSpace(rw.Cells(i).Value.ToString()) Then
        '            'empty
        '        End If
        '    Next
        'Next



        'Public Function IsDataGridViewEmpty(ByRef dataGridView As DataGridView) As Boolean
        '    Dim isEmpty As Boolean = True
        '    For Each row As DataGridViewRow In dataGridView.Rows
        '        For Each cell As DataGridViewCell In row.Cells
        '            If Not String.IsNullOrEmpty(cell.Value) Then
        '                If Not String.IsNullOrEmpty(Trim(cell.Value.ToString())) Then
        '                    isEmpty = False
        '                    Exit For
        '                End If
        '            End If
        '        Next
        '    Next
        '    Return isEmpty
        'End Function



        If dgDel.RowCount > 0 Then
            For Each Row As DataGridViewRow In dgDel.Rows
                If Nz.Nz(Row.Cells("DelivStatus").Value) = "Active" Then
                    If Nz.Nz(Row.Cells("DelivWhat").Value) = True Then
                        txtDelDate.Text = Row.Cells("DelivDate").Value
                        txtOrdDelivID.Text = Row.Cells("OrdDelivID").Value
                        Exit For
                    End If
                End If
            Next
        End If

        If txtOrd.Text = "LISI Grinding" Then
            CmbMpoType.Text = "Grinding"
        End If

        Dim SwMFGLT As Integer
        '4 wks = 28 days processing
        SwMFGLT = CallClass.ReturnInfoWithParString("cspReturnMFGLeadTime", "MFGLEADTIME")
        SwMFGLT = (SwMFGLT * 7) + 28

        DelDate = CDate(txtDelDate.Text).ToShortDateString
        PromDate = CDate(txtDelDate.Text).ToShortDateString

        StartDate = DateAdd(DateInterval.Day, -SwMFGLT, DelDate).ToShortDateString
        EndDate = DateAdd(DateInterval.Day, -28, DelDate).ToShortDateString

        MpoMaster.Text = ""
        MPOChild.Text = ""

        If CmbMpoType.Text = "Grinding" Then
            'Default MPO Grinding = 3193
            MpoMaster.Text = "3193"
            MPOChild.Text = CallClass.ReturnLastMpo("cspReturnLastMpoChildGrinding")
            MPOChild.Text = Val(MPOChild.Text) + 1
        Else
            MpoMaster.Text = CallClass.ReturnLastMpo("cspReturnLastMpoNo")
            MpoMaster.Text = MpoMaster.Text + 1
        End If

        If Len(Trim(MpoMaster.Text)) > 0 And SwVal = True Then
            CmdAssign.Visible = True
        Else
            CmdAssign.Visible = False
        End If

        cmdVerify.Enabled = False

    End Sub

    Private Sub CmdAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAssign.Click

        If RowOrd < 0 Then
            MsgBox("!!! ERROR Index !!!  Try Again.")
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspGenInsertMpoNo", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraOrdID As SqlParameter = New SqlParameter("@OrderItemsID", SqlDbType.Int, 4)
            paraOrdID.Value = dgOrd("OrderItemsID", RowOrd).Value
            mySqlComm.Parameters.Add(paraOrdID)

            Dim paraMpoType As SqlParameter = New SqlParameter("@MpoType", SqlDbType.NVarChar, 25)
            paraMpoType.Value = CmbMpoType.Text
            mySqlComm.Parameters.Add(paraMpoType)

            Dim paraMpoExp As SqlParameter = New SqlParameter("@MPOExpediteValue", SqlDbType.SmallMoney, 4)
            paraMpoExp.Value = Val(txtExpediteValue.Text)
            mySqlComm.Parameters.Add(paraMpoExp)

            If CmbMpoType.Text = "Grinding" Then
                Dim paraMpo As SqlParameter = New SqlParameter("@MpoNo", SqlDbType.NVarChar, 25)
                paraMpo.Value = Trim(MpoMaster.Text) + "-" + Trim(MPOChild.Text)
                mySqlComm.Parameters.Add(paraMpo)
            Else
                Dim paraMpo As SqlParameter = New SqlParameter("@MpoNo", SqlDbType.NVarChar, 25)
                paraMpo.Value = Trim(MpoMaster.Text)
                mySqlComm.Parameters.Add(paraMpo)
            End If

            Dim paraPar As SqlParameter = New SqlParameter("@MpoParent", SqlDbType.NVarChar, 15)
            paraPar.Value = Trim(MpoMaster.Text)
            mySqlComm.Parameters.Add(paraPar)

            If CmbMpoType.Text = "Grinding" Then
                Dim paraSuf As SqlParameter = New SqlParameter("@MpoChild", SqlDbType.NVarChar, 10)
                paraSuf.Value = Trim(MPOChild.Text)
                mySqlComm.Parameters.Add(paraSuf)
            Else
                Dim paraSuf As SqlParameter = New SqlParameter("@MpoChild", SqlDbType.NVarChar, 10)
                paraSuf.Value = ""
                mySqlComm.Parameters.Add(paraSuf)
            End If

            Dim paraDate As SqlParameter = New SqlParameter("@MpoDate", SqlDbType.SmallDateTime, 4)
            paraDate.Value = Now.ToShortDateString
            mySqlComm.Parameters.Add(paraDate)

            Dim paraPromDate As SqlParameter = New SqlParameter("@MPOPromDate", SqlDbType.SmallDateTime, 4)
            paraPromDate.Value = PromDate
            mySqlComm.Parameters.Add(paraPromDate)

            Dim paraStartDate As SqlParameter = New SqlParameter("@StartProdDate", SqlDbType.SmallDateTime, 4)
            paraStartDate.Value = StartDate
            mySqlComm.Parameters.Add(paraStartDate)

            Dim paraEndDate As SqlParameter = New SqlParameter("@EndProdDate", SqlDbType.SmallDateTime, 4)
            paraEndDate.Value = EndDate
            mySqlComm.Parameters.Add(paraEndDate)

            Dim paraStatus As SqlParameter = New SqlParameter("@MpoStatus", SqlDbType.NVarChar, 10)
            paraStatus.Value = "Active"
            mySqlComm.Parameters.Add(paraStatus)

            Dim paraPart As SqlParameter = New SqlParameter("@MpoPartID", SqlDbType.Int, 4)
            paraPart.Value = dgOrd("OrdPartCross99ID", RowOrd).Value
            mySqlComm.Parameters.Add(paraPart)

            Dim paraPartRev As SqlParameter = New SqlParameter("@MpoPartRev", SqlDbType.NVarChar, 25)
            paraPartRev.Value = ""
            mySqlComm.Parameters.Add(paraPartRev)

            Dim paraPartType As SqlParameter = New SqlParameter("@MpoPartType", SqlDbType.NVarChar, 25)
            paraPartType.Value = ""
            mySqlComm.Parameters.Add(paraPartType)

            Dim paraQtyOrd As SqlParameter = New SqlParameter("@QtyOrder", SqlDbType.Real, 4)
            paraQtyOrd.Value = txtQtySelected.Text
            mySqlComm.Parameters.Add(paraQtyOrd)

            Dim paraQtyEng As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQtyEng.Value = 0
            mySqlComm.Parameters.Add(paraQtyEng)

            Dim paraDept As SqlParameter = New SqlParameter("@DeptID", SqlDbType.Int, 4)
            paraDept.Value = 56
            mySqlComm.Parameters.Add(paraDept)

            Dim paraLot As SqlParameter = New SqlParameter("@MpoLotNo", SqlDbType.NVarChar, 10)
            paraLot.Value = ""
            mySqlComm.Parameters.Add(paraLot)

            Dim paraWeight As SqlParameter = New SqlParameter("@MpoMatlWeight", SqlDbType.Real, 4)
            paraWeight.Value = 0
            mySqlComm.Parameters.Add(paraWeight)

            Dim paraNewOrd As SqlParameter = New SqlParameter("@ChNewOrder", SqlDbType.Bit, 1)
            paraNewOrd.Value = 1
            mySqlComm.Parameters.Add(paraNewOrd)

            Dim paraWFM As SqlParameter = New SqlParameter("@ChWFM", SqlDbType.Bit, 1)
            paraWFM.Value = 0
            mySqlComm.Parameters.Add(paraWFM)

            Dim paraWFT As SqlParameter = New SqlParameter("@ChWFT", SqlDbType.Bit, 1)
            paraWFT.Value = 0
            mySqlComm.Parameters.Add(paraWFT)

            Dim paraOrdDelivID As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
            paraOrdDelivID.Value = Val(txtOrdDelivID.Text)
            mySqlComm.Parameters.Add(paraOrdDelivID)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If
                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Insert Mpo Update Sql: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        Catch ex As Exception
            MsgBox("Insert Mpo Parameter: " & ex.Message)
        End Try

        'Call SetupForm()


        '================================================

        Dim SwMpo As String = "MPO-" + Trim(MpoMaster.Text)

        Dim path As String = ""
        Dim path_1 As String = ""

        path = "\\Srv115fs01\Lisi MPO Quality Records\" + SwMpo
        Dim di As DirectoryInfo = Directory.CreateDirectory(path)

        path_1 = path + "\1) Test Certs"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\2) Heat treatment Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\3) Forging Records"
        di = Directory.CreateDirectory(path_1)
        'path_1 = path + "\3) Forging Records\a) Technique sheet"
        'di = Directory.CreateDirectory(path_1)
        'path_1 = path + "\3) Forging Records\b) First off"
        'di = Directory.CreateDirectory(path_1)

        path_1 = path + "\4) Thread rolling Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\5) Cold working Records"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\6) Surface finishing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\7) Final Inspections"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\8) Metallurgical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\9) Mechanical Testing"
        di = Directory.CreateDirectory(path_1)

        path_1 = path + "\10) Others"
        di = Directory.CreateDirectory(path_1)

        '===================================================


        VerifyEmpInRouting()

        If IReturn = 0 Then     'there is no oper open with mpo and emp in routing
            AddStartEndOper()
        Else
            MsgBox("!!! ERROR !!! Operation already exist in routing.")
        End If

        InitialComponents()

        BindData()

        CmbOrder.SelectedValue = KeepIndex

    End Sub

    Sub VerifyEmpInRouting()

        ' if the operator exit in one operation open
        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspRouteCheckExistMPOAndOper", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure


        Dim SwMpoNew As String = ""

        If CmbMpoType.Text = "Grinding" Then
            SwMpoNew = Trim(MpoMaster.Text) + "-" + Trim(MPOChild.Text)
        Else
            SwMpoNew = Trim(MpoMaster.Text)
        End If

        SwMpoID = CallClass.ReturnStrWithParString("cspReturnMPOID", SwMpoNew)

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMpoID
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = 1
        mySqlComm.Parameters.Add(paraOperNo)

        '=================
        Dim paraRet As SqlParameter = New SqlParameter("@ParRet", SqlDbType.Int, 4)
        paraRet.Value = 0
        paraRet.Direction = ParameterDirection.Output
        mySqlComm.Parameters.Add(paraRet)

        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If

            mySqlComm.ExecuteNonQuery()
            paraRet = mySqlComm.Parameters("@ParRet")
            If IsDBNull(paraRet.Value) = False Then
                IReturn = CType(paraRet.Value, Integer)
            Else
                IReturn = 0
            End If

        Catch ex As SqlException
            MsgBox("Verify Employee in Routing: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub AddStartEndOper()

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateRouteAddOperStart", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraMpoID As SqlParameter = New SqlParameter("@SwMpoID", SqlDbType.Int, 4)
        paraMpoID.Value = SwMpoID
        mySqlComm.Parameters.Add(paraMpoID)

        Dim paraOperNo As SqlParameter = New SqlParameter("@SwOperNo", SqlDbType.Int, 4)
        paraOperNo.Value = 1
        mySqlComm.Parameters.Add(paraOperNo)

        Dim paraDeptID As SqlParameter = New SqlParameter("@SwDeptID", SqlDbType.Int, 4)
        paraDeptID.Value = 56
        mySqlComm.Parameters.Add(paraDeptID)

        Dim paraEmpID As SqlParameter = New SqlParameter("@SwEmpID", SqlDbType.Int, 4)
        paraEmpID.Value = wkEmpId
        mySqlComm.Parameters.Add(paraEmpID)

        Dim paraDeptWhat As SqlParameter = New SqlParameter("@DeptWhat", SqlDbType.NVarChar, 20)
        paraDeptWhat.Value = "ENGBUFF"
        mySqlComm.Parameters.Add(paraDeptWhat)

       
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            mySqlComm.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add Operation Start: " & ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub

    Sub UpdateGenMpo()
        If RowMPO < 0 Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspGenUpdateMpoNotes", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findMpo", SqlDbType.NVarChar, 25)
            paraFind.Value = dgMpo("MpoNo", RowMPO).Value
            mySqlComm.Parameters.Add(paraFind)

            Dim paraNotes As SqlParameter = New SqlParameter("@MpoNotes", SqlDbType.NVarChar, 1000)
            paraNotes.Value = dgMpo("MpoNotes", RowMPO).Value
            mySqlComm.Parameters.Add(paraNotes)
            Try

                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Update Mpo Notes: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Mpo Notes: " & ex.Message)
        End Try

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim reply As DialogResult

        If dgMpo.Rows(RowMPO).Selected = True Then
            If dgMpo("DeptID", RowMPO).Value = 56 Then      ' not a good solution 56 = engbuff; must find another critera
                reply = MsgBox("Do you want to delete the Mpo Number ?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    dgMpo.Rows.RemoveAt(RowMPO)
                    DeleteGenMpo()

                    InitialComponents()
                    BindData()
                    CmbOrder.SelectedValue = KeepIndex
                End If
            Else
                MsgBox("You can not Remove the Mpo from this Department.", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("Please Select the Mpo Line.", MsgBoxStyle.OkOnly)
        End If

    End Sub

    Sub DeleteGenMpo()
        If KeepMpo <= 0 Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspGenDeleteMpo", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraFind As SqlParameter = New SqlParameter("@findMpo", SqlDbType.Int, 4)
            paraFind.Value = KeepMpo
            mySqlComm.Parameters.Add(paraFind)

            Try
                If cn.State = ConnectionState.Closed Then
                    cn.Open()
                End If

                mySqlComm.ExecuteNonQuery()

            Catch ex As SqlException
                MsgBox("Delete Mpo Number: " & ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            Finally
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If

            End Try

        Catch ex As Exception
            MsgBox("!!! ERROR !!! Delete Mpo Number: " & ex.Message)
        End Try

    End Sub

    Sub CalculGridsQty()

        Dim qty As Integer = 0
        For Each Row As DataGridViewRow In dgOrd.Rows
            If IsDBNull(Row.Cells("OrdItemStatus").Value) = False Then
                If Row.Cells("OrdItemStatus").Value = "Active" Then
                    qty = qty + Nz.Nz(Row.Cells("OrdItemQty").Value)
                End If
            End If
        Next
        OrdQty.Text = qty.ToString("N2")

        qty = 0

        For Each Row As DataGridViewRow In dgDel.Rows
            If IsDBNull(Row.Cells("DelivStatus").Value) = False Then
                If Row.Cells("DelivStatus").Value = "Active" Then
                    qty = qty + Nz.Nz(Row.Cells("DelivQty").Value)
                End If
            End If
        Next
        txtDelivQty.Text = qty.ToString("N2")

        qty = 0

        For Each Row As DataGridViewRow In dgMpo.Rows
            If IsDBNull(Row.Cells("MpoStatus").Value) = False Then
                If Row.Cells("MpoStatus").Value = "Active" Then
                    qty = qty + Nz.Nz(Row.Cells("QtyOrder").Value)
                End If
            End If
        Next
        MpoQty.Text = qty.ToString("N2")
    End Sub

    Sub UpdateDelivStatus()

        If IsDBNull(dgDel("DelivStatus", RowDel).Value) = True Then
            Exit Sub
        End If

        Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateDeliveryStatus", cn)
        mySqlComm.CommandType = CommandType.StoredProcedure

        Dim paraDel As SqlParameter = New SqlParameter("@OrdDelivID", SqlDbType.Int, 4)
        paraDel.Value = dgDel("OrdDelivID", RowDel).Value
        mySqlComm.Parameters.Add(paraDel)

        Dim paraStatus As SqlParameter = New SqlParameter("@DelivStatus", SqlDbType.NVarChar, 10)
        paraStatus.Value = dgDel("DelivStatus", RowDel).Value
        mySqlComm.Parameters.Add(paraStatus)

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            mySqlComm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("!!! ERROR !!! Update Delivery Status: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

End Class