Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic

Public Class frmSalesPlanningFPInventory

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Dim RowOrder As Integer = 0       'dgOrder row.

    Private dsMain As New DataSet
    Dim SwError As Boolean = False

    Dim DelDate As Date
    Dim StartDate As Date

    Private Sub frmSalesPlanningFPInventory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        dsMain.Clear()
        dsMain.Relations.Clear()
        dsMain.RejectChanges()
        dsMain.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub frmSalesPlanningFPInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SwFPPrev.Visible = False

        Call SetupForm()

        If Val(SwFPPrev.Text) > 0 Then
            CmbPartNumber.SelectedValue = SwFPPrev.Text
        Else
            CmbPartNumber.SelectedIndex = -1
        End If
    End Sub

    Sub SetupForm()
        GC.Collect()

        InitialComponents()
        PutPartNumber()

        SetCtlForm()

        txtFPStock.ReadOnly = True

    End Sub

    Sub InitialComponents()
        dsMain.Clear()
        dsMain.Relations.Clear()

        PutTablesAdapters()
        dsMain.EnforceConstraints = False

        PutDataGrid()


    End Sub


    Sub PutTablesAdapters()

        CallClass.PopulateDataAdapter("getOrderSelectionEmpty").Fill(dsMain, "tblSelect")
        CallClass.PopulateDataAdapter("gettblPartMatlPrefEmpty").Fill(dsMain, "tmpPartMatlPref")

    End Sub

    Sub PutDataGrid()

        dgSel.AutoGenerateColumns = False
        dgSel.DataSource = dsMain
        dgSel.DataMember = "tblSelect"

        dgMatlPref.AutoGenerateColumns = False
        dgMatlPref.DataSource = dsMain
        dgMatlPref.DataMember = "tmpPartMatlPref"

    End Sub

    Sub PutPartNumber()

        With Me.CmbPartNumber
            .DataSource = CallClass.PopulateComboBox("tblPartMaster", "cmbGetPartNumber").Tables("tblPartMaster")
            .DisplayMember = "PartNumber"
            .ValueMember = "PartID"
        End With

    End Sub

    Sub SetCtlForm()

        With Me.CustomerShort
            .DataPropertyName = "CustomerShort"
            .Name = "CustomerShort"
        End With

        With Me.OrdNumber
            .DataPropertyName = "OrdNumber"
            .Name = "OrdNumber"
        End With

        With Me.MpoPartRev
            .DataPropertyName = "MpoPartRev"
            .Name = "MpoPartRev"
        End With

        With Me.DelivDate
            .DataPropertyName = "DelivDate"
            .Name = "DelivDate"
        End With

        With Me.QtyToShip
            .DataPropertyName = "QtyToShip"
            .Name = "QtyToShip"
        End With

        With Me.CalcStock
            .DataPropertyName = "CalcStock"
            .Name = "CalcStock"
        End With

        With Me.DeptMPO
            .DataPropertyName = "DeptMPO"
            .Name = "DeptMPO"
        End With

        With Me.DeptPer
            .DataPropertyName = "DeptPer"
            .Name = "DeptPer"
        End With

        With Me.MpoType
            .DataPropertyName = "MpoType"
            .Name = "MpoType"
        End With

        With Me.SwOrder
            .DataPropertyName = "SwOrder"
            .Name = "SwOrder"
            .Visible = False
        End With

        'dgMatlPref  prefferd
        With Me.PartMatlID
            .DataPropertyName = "PartMatlID"
            .Name = "PartMatlID"
            .Visible = False
        End With

        With Me.LinkCombKey
            .DataPropertyName = "LinkCombKey"
            .Name = "LinkCombKey"
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

    End Sub

    Private Sub CmbPartNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPartNumber.SelectedIndexChanged

        If CmbPartNumber.SelectedIndex >= 1 Then

            Dim StrSearch As String = ""
            Dim SwQty As String = ""

            dsMain.Tables("tblSelect").Clear()
            dsMain.Tables("tmpPartMatlPref").Clear()

            StrSearch = CmbPartNumber.Text
            CallClass.PopulateDataAdapterAfterSearch("getSalesPlanningFPOrdersActive", StrSearch).Fill(dsMain, "tblSelect")

            CallClass.PopulateDataAdapterAfterSearch("getSalesPlanningFPRawMatlPref", CmbPartNumber.SelectedValue).Fill(dsMain, "tmpPartMatlPref")

            SwQty = CallClass.ReturnStrWithParInt("cspReturnStockFPByPart", CmbPartNumber.SelectedValue)
            If SwQty = "False" Then
                txtFPStock.Text = 0
            Else
                txtFPStock.Text = SwQty
            End If

        End If

        PutDataGrid()

        PutGridCalcul()
        dgSel.Refresh()

        SwError = False
        PutMessageGrid()

    End Sub

    Sub PutGridCalcul()
        If dgSel.Rows.Count > 0 Then
            For I As Integer = 0 To (dgSel.Rows.Count - 1)
                If I = 0 Then
                    dgSel("CalcStock", I).Value = Val(txtFPStock.Text) + Nz.Nz(dgSel("QtyToShip", I).Value)
                Else
                    dgSel("CalcStock", I).Value = Nz.Nz(dgSel("QtyToShip", I).Value) + Nz.Nz(dgSel("CalcStock", I - 1).Value)
                End If
            Next I
        End If

    End Sub

    Private Sub CmdShowRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdShowRM.Click
        frmReleaseRawMaterial.Show()

    End Sub

    Private Sub CmdRmAnalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRmAnalize.Click
        frmRawMaterialAnalyze.Show()
    End Sub

    Sub PutMessageGrid()

        For I As Integer = 0 To (dgSel.Rows.Count - 1)
            dgSel("CalcStock", I).Style.BackColor = Color.White

            If Nz.Nz(dgSel("CalcStock", I).Value) < 0 Then
                dgSel("CalcStock", I).Style.BackColor = Color.LightGray
                If SwError = False Then
                    Dim SwMFGLT As Integer
                    '4 wks = 28 days processing
                    SwMFGLT = CallClass.ReturnInfoWithParString("cspReturnMFGLeadTime", "MFGLEADTIME")
                    SwMFGLT = (SwMFGLT * 7) + 28

                    DelDate = CDate(dgSel("DelivDate", I).Value).ToShortDateString
                    StartDate = DateAdd(DateInterval.Day, -SwMFGLT, DelDate).ToShortDateString
                    'EndDate = DateAdd(DateInterval.Day, -28, DelDate).ToShortDateString


                    dgSel("CalcStock", I).ErrorText = "Start Production Date should be before or on: " + StartDate.ToLongDateString + "  (MFG LT = " + Str(SwMFGLT / 7) + " wks)"
                    SwError = True
                End If
            Else
                dgSel("CalcStock", I).Style.BackColor = Color.White
            End If

        Next I

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmShopFloorControl.Show()
    End Sub

End Class