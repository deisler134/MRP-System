Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPOMatlReservation

    Inherits System.Windows.Forms.Form

    Dim cn As New SqlConnection(strConnection)

    Private dsSrc As New DataSet
    Dim da As SqlDataAdapter

    Dim CallClass As New clsCommon

    Dim RowPO As Integer = 0
    Dim RowRecv As Integer = 0
    Dim RowReserv As Integer = 0

    Private Sub frmPOMatlReservation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim reply As DialogResult

        If dsSrc.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        dsSrc.RejectChanges()
        dsSrc.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmPOMatlReservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetupForm()
    End Sub

    Sub SetupForm()

        GC.Collect()

        InitialComponents()

        SetCtlForm()

        dgPo.AutoGenerateColumns = False
        dgPo.DataSource = dsSrc
        dgPo.DataMember = "TempPoMaster"

        dgEng.AutoGenerateColumns = False
        dgEng.DataSource = dsSrc
        dgEng.DataMember = "TempMPOEng"

    End Sub

    Sub InitialComponents()

        dsSrc.Clear()
        dsSrc.Relations.Clear()

        CallClass.PopulateDataAdapter("getPORawMaterialPurchasing").Fill(dsSrc, "TempPoMaster")
        CallClass.PopulateDataAdapter("getMatlRecvPoReserved").Fill(dsSrc, "TempMatlReceived")
        CallClass.PopulateDataAdapter("gettblStockMatlPoResevWithPart").Fill(dsSrc, "TempStockRawMatlPOReserv")
        CallClass.PopulateDataAdapter("gettblMpoEngToBeReserved").Fill(dsSrc, "TempMPOEng")

        dsSrc.EnforceConstraints = False

    End Sub

    Sub SetCtlForm()

        'for dgPO  --   Info
        With Me.PONo
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.POItem
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.PODueDate
            .DataPropertyName = "PODueDate"
            .Name = "PODueDate"
        End With

        With Me.SuppName
            .DataPropertyName = "SuppName"
            .Name = "SuppName"
        End With

        With Me.ProdDescr
            .DataPropertyName = "ProdDescr"
            .Name = "ProdDescr"
        End With

        With Me.PONotesItem
            .DataPropertyName = "PONotesItem"
            .Name = "PONotesItem"
        End With

        With Me.PoRemarks
            .DataPropertyName = "PoRemarks"
            .Name = "PoRemarks"
        End With

        With Me.POQty
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POUM
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.DolarSign
            .DataPropertyName = "DolarSign"
            .Name = "DolarSign"
        End With

        'for dgRecv  --   Info
        With Me.PONoLot
            .DataPropertyName = "PONo"
            .Name = "PONo"
        End With

        With Me.POItemLot
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.RecvApprDate
            .DataPropertyName = "RecvApprDate"
            .Name = "RecvApprDate"
        End With

        With Me.DocRecvNo
            .DataPropertyName = "DocRecvNo"
            .Name = "DocRecvNo"
        End With

        With Me.MatLType
            .DataPropertyName = "MatLType"
            .Name = "MatLType"
        End With

        With Me.RecvMatlWeight
            .DataPropertyName = "RecvMatlWeight"
            .Name = "RecvMatlWeight"
        End With

        With Me.PslipUM
            .DataPropertyName = "PslipUM"
            .Name = "PslipUM"
        End With

        With Me.RecvMatlSize
            .DataPropertyName = "RecvMatlSize"
            .Name = "RecvMatlSize"
        End With

        With Me.RecvMatlLength
            .DataPropertyName = "RecvMatlLength"
            .Name = "RecvMatlLength"
        End With

        With Me.MillName
            .DataPropertyName = "MillName"
            .Name = "MillName"
        End With

        'for dgReserv  --   Info
        With Me.MatlPoResID
            .DataPropertyName = "MatlPoResID"
            .Name = "MatlPoResID"
            .Visible = False
        End With

        PutMpoID()

        With Me.MpoNo
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PartNumber
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCode
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.MatlPoWeight
            .DataPropertyName = "MatlPoWeight"
            .Name = "MatlPoWeight"
        End With

        With Me.QtyEngReleased
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrder
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

        With Me.PONoReserv
            .DataPropertyName = "PONoReserv"
            .Name = "PONoReserv"
        End With

        With Me.POItemReserv
            .DataPropertyName = "POItemReserv"
            .Name = "POItemReserv"
        End With

        'for dgEng  --   Info
        With Me.MpoIdEng
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .Visible = False
        End With

        With Me.MpoNoEng
            .DataPropertyName = "MpoNo"
            .Name = "MpoNo"
        End With

        With Me.PartNumberEng
            .DataPropertyName = "PartNumber"
            .Name = "PartNumber"
        End With

        With Me.PartDescCodeEng
            .DataPropertyName = "PartDescCode"
            .Name = "PartDescCode"
        End With

        With Me.QtyEngReleasedEng
            .DataPropertyName = "QtyEngReleased"
            .Name = "QtyEngReleased"
        End With

        With Me.QtyOrderEng
            .DataPropertyName = "QtyOrder"
            .Name = "QtyOrder"
        End With

    End Sub

    Sub PutMpoID()

        With Me.MpoID
            .DataSource = CallClass.PopulateComboBox("tblMpoMaster", "cmbGetMpoEngForPoReserv").Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoID"
            .DataPropertyName = "MpoID"
            .Name = "MpoID"
            .DropDownWidth = 200
            .MaxDropDownItems = 50
        End With

    End Sub

    Private Sub dgPo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPo.CellBeginEdit

        RowPO = e.RowIndex

        Select Case e.ColumnIndex
            Case 0 To 6
                e.Cancel = True
            Case 8 To 10
                e.Cancel = True
            Case 7

                For Each Row As DataGridViewRow In dgPo.Rows
                    Row.Cells("PurCheck").Value = False
                Next

                If dgPo.Rows(e.RowIndex).Cells("POQty").Value - txtMatlRecv.Text < 100 Then
                    MsgBox("Missing Quantity ?")
                    e.Cancel = True
                    dgPo.Rows(e.RowIndex).Cells("PurCheck").Value = False
                End If
        End Select

    End Sub

    Private Sub dgPo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPo.CellClick
        Dim FindPO As String

        If e.ColumnIndex = 12 Then
            If IsDBNull(dgPo("PONo", RowPO).Value) = True Then
                MsgBox("Nothing to PreView.")
            Else
                FindPO = dgPo("PONo", RowPO).Value
                Dim pvCollection As New CrystalDecisions.Shared.ParameterValues()
                Dim pdvCustomerName As New CrystalDecisions.Shared.ParameterDiscreteValue()
                Dim rptPO As New rptPOSupp()
                Try
                    rptPO.Load("..\rptposupp.rpt")
                    pdvCustomerName.Value = FindPO
                    pvCollection.Add(pdvCustomerName)
                    rptPO.DataDefinition.ParameterFields("@FindPO").ApplyCurrentValues(pvCollection)

                    frmPOMasterPrint.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                    frmPOMasterPrint.CrystalReportViewer1.ReportSource = rptPO
                    frmPOMasterPrint.CrystalReportViewer1.Zoom(2)
                    frmPOMasterPrint.CrystalReportViewer1.DisplayToolbar = False
                    frmPOMasterPrint.ShowDialog()
                Catch Exp As CrystalDecisions.CrystalReports.Engine.LoadSaveReportException
                    MsgBox("Incorrect path for loading report.", _
                            MsgBoxStyle.Critical, "Load Report Error")
                Catch Exp As Exception
                    MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
                End Try
            End If
        End If

    End Sub

    Private Sub dgPo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPo.DataError
        REM end
    End Sub

    Private Sub dgPo_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPo.RowEnter

        If e.RowIndex < 0 Then
            Exit Sub
        Else
            RowPO = e.RowIndex
        End If

        Dim strSearch As String
        Dim Findpo As String = ""
        Dim FindItem As Integer

        Findpo = dgPo("PONo", e.RowIndex).Value

        If InStr(Findpo, "-") <> 0 Then
            strSearch = Microsoft.VisualBasic.Left(Findpo, InStr(Findpo, "-") - 1)
        Else
            strSearch = Trim(Findpo)
        End If

        FindItem = dgPo("POItem", e.RowIndex).Value

        dsSrc.Tables("TempMatlReceived").Clear()
        CallClass.PopulateDataAdapterSearchStrAndStr("getPOMatlRecvByPoAndItem", strSearch, FindItem).Fill(dsSrc, "TempMatlReceived")
        dgRecv.AutoGenerateColumns = False
        dgRecv.DataSource = dsSrc
        dgRecv.DataMember = "TempMatlReceived"

        CalculMatlRecv()

        PutdgReserv()

        dgPo.Rows(e.RowIndex).Selected = True

    End Sub

    Sub PutdgReserv()

        Dim strSearch As String
        Dim Findpo As String = ""
        Dim FindItem As Integer

        strSearch = dgPo("PONo", RowPO).Value

        If IsNothing(strSearch) Then
            Exit Sub
        End If

        FindItem = dgPo("POItem", RowPO).Value

        dsSrc.Tables("TempStockRawMatlPOReserv").Clear()
        CallClass.PopulateDataAdapterSearchStrAndStr("gettblStockMatlPoResevSrcPoNoAndItem", strSearch, FindItem).Fill(dsSrc, "TempStockRawMatlPOReserv")
        dgReserv.AutoGenerateColumns = False
        dgReserv.DataSource = dsSrc
        dgReserv.DataMember = "TempStockRawMatlPOReserv"

    End Sub

    Private Sub dgRecv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgRecv.DataError
        REM end
    End Sub

    Private Sub dgReserv_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgReserv.CellBeginEdit
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowReserv = e.RowIndex

        Select Case e.ColumnIndex
            Case 0, 2, 3, 4, 7, 8, 9
                e.Cancel = True
            Case 1

                If dgPo.Rows(RowPO).Cells("PurCheck").Value = False Then
                    MsgBox("Please Select the PO Line before Mpo Reservation.")
                    e.Cancel = True
                End If
            Case 5, 6
                If IsDBNull(dgReserv.Rows(RowReserv).Cells("MatlPoResID").Value) = True Then
                    e.Cancel = True
                End If

        End Select

    End Sub

    Private Sub dgReserv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReserv.CellEndEdit

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowReserv = e.RowIndex

        Select Case e.ColumnIndex

            Case 1
                dgReserv.Rows(RowReserv).Cells("PONoReserv").Value = dgPo.Rows(RowPO).Cells("PONo").Value
                dgReserv.Rows(RowReserv).Cells("POItemReserv").Value = dgPo.Rows(RowPO).Cells("POItem").Value

                UpdateMpoPoReserv()
                PutdgReserv()

            Case 5          'update weight
                If IsDBNull(dgReserv.Rows(RowReserv).Cells("MatlPoResID").Value) = False Then
                    UpdateWeightPoReserv()
                End If

            Case 6          ' update qty eng
                If IsDBNull(dgReserv.Rows(RowReserv).Cells("MpoID").Value) = False Then
                    UpdateEngQtyPoReserv()
                End If
        End Select

    End Sub

    Private Sub dgReserv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReserv.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowReserv = e.RowIndex

        Select Case e.ColumnIndex
            Case 1
                PutMpoID()
        End Select

    End Sub

    Private Sub dgReserv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgReserv.DataError
        REM end
    End Sub

    Sub UpdateMpoPoReserv()

        If IsDBNull(dgReserv("MpoId", RowReserv).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoPoAndItemReserv", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgReserv("MpoId", RowReserv).Value
            mySqlComm.Parameters.Add(paraMpo)

            Dim paraPO As SqlParameter = New SqlParameter("@PONoReserv", SqlDbType.NVarChar, 10)
            paraPO.Value = dgReserv("PONoReserv", RowReserv).Value
            mySqlComm.Parameters.Add(paraPO)

            Dim paraItem As SqlParameter = New SqlParameter("@POItemReserv", SqlDbType.TinyInt, 1)
            paraItem.Value = dgReserv("POItemReserv", RowReserv).Value
            mySqlComm.Parameters.Add(paraItem)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Mpo reserved PoNo and po Item: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo reserved PoNo and po Item: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateWeightPoReserv()

        If IsDBNull(dgReserv("MatlPoResID", RowReserv).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateWeightPoReserv", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraID As SqlParameter = New SqlParameter("@MatlPoResID", SqlDbType.Int, 4)
            paraID.Value = dgReserv("MatlPoResID", RowReserv).Value
            mySqlComm.Parameters.Add(paraID)

            Dim paraPO As SqlParameter = New SqlParameter("@MatlPoWeight", SqlDbType.Real, 4)
            paraPO.Value = dgReserv("MatlPoWeight", RowReserv).Value
            mySqlComm.Parameters.Add(paraPO)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Weight PO Reserved: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Weight PO Reserved: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateEngQtyPoReserv()

        If IsDBNull(dgReserv("MpoID", RowReserv).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateEngQtyPoReserv", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraID As SqlParameter = New SqlParameter("@MpoID", SqlDbType.Int, 4)
            paraID.Value = dgReserv("MpoID", RowReserv).Value
            mySqlComm.Parameters.Add(paraID)

            Dim paraQty As SqlParameter = New SqlParameter("@QtyEngReleased", SqlDbType.Real, 4)
            paraQty.Value = dgReserv("QtyEngReleased", RowReserv).Value
            mySqlComm.Parameters.Add(paraQty)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Eng Qty PO Reserved: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Eng Qty PO Reserved: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub UpdateMpoPoReservdelete()

        If IsDBNull(dgReserv("MpoId", RowReserv).Value) = True Then
            Exit Sub
        End If

        Try
            Dim mySqlComm As New Data.SqlClient.SqlCommand("cspUpdateMpoReservDelete", cn)
            mySqlComm.CommandType = CommandType.StoredProcedure

            Dim paraMpo As SqlParameter = New SqlParameter("@MPOId", SqlDbType.Int, 4)
            paraMpo.Value = dgReserv("MpoId", RowReserv).Value
            mySqlComm.Parameters.Add(paraMpo)

            Try
                cn.Open()
                mySqlComm.ExecuteNonQuery()
                cn.Close()
            Catch ex As SqlException
                MsgBox("Update Mpo Reserved - Delete: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("Update Mpo Reserved - Delete: " & ex.Message)
        Finally
            cn.Close()
        End Try

    End Sub

    Sub CalculMatlRecv()
        If RowRecv < 0 Then
            Exit Sub
        End If

        Dim qty As Double = 0.0

        For Each Row As DataGridViewRow In dgRecv.Rows
            qty = qty + Nz.Nz(Row.Cells("RecvMatlWeight").Value)
        Next
        txtMatlRecv.Text = qty.ToString("N2")
    End Sub

    Private Sub dgEng_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgEng.CellBeginEdit

        Select Case e.ColumnIndex
            Case 0 To 5
                e.Cancel = True
        End Select

    End Sub

    Private Sub dgEng_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgEng.DataError
        REM end
    End Sub

    Private Sub dgReserv_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgReserv.UserDeletingRow

        If RowReserv < 0 Then
            e.Cancel = True
            Exit Sub
        End If

        If IsDBNull(dgReserv.Item("MpoID", RowReserv).Value) = True Then
            MsgBox("Nothing to Delete.")
            e.Cancel = True
        Else
            Dim reply As DialogResult
            reply = MsgBox("Delete ?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then
                UpdateMpoPoReservdelete()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

End Class