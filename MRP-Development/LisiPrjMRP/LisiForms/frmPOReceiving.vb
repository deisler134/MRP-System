Option Strict Off
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmPOReceiving

    Inherits System.Windows.Forms.Form

    Dim cnSqlServer As New SqlConnection(strConnection)

    Dim myds As New DataSet
    Private dsAlusta As New DataSet

    Dim poc As New PORecClass
    Dim CallClass As New clsCommon

    Dim poDetailID As Integer
    Dim poNum As String
    Dim PoItem As String
    Dim poqty As Double

    Dim rowPOIndex As Integer   'for row in dgPODetails
    Dim rowRecIndex As Integer  'for row in dgPORecDetails
    Dim rowColRecIndex As Integer  'for row in dgPORecDetails
    Dim rowCount As Integer
    Dim updflg As Boolean
    Dim FindPoflg As Boolean = False
    Dim SwRecvInsp As Boolean = False
    Dim flagMes As Boolean = False
    Dim SwVal As Boolean = True

    Dim FileNameStr As String = ""
    Dim sSource As String = ""
    Dim sTarget As String = ""


    Private Sub frmPOReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        Call EnableCtl()
        Call InitialComponents()
        txtPSlipNumber.Focus()

    End Sub

    Sub InitialComponents()

        myds.Clear()
        myds.Relations.Clear()

        HideCtl()
        SetCtlPry()

        Try
            poc.GetPODetAd.FillSchema(myds, SchemaType.Source, "tblPODetails")
            poc.GetPORecAd.FillSchema(myds, SchemaType.Source, "tblPOReceiving")

            poc.GetPODetAd.Fill(myds, "tblPODetails")
            Dim detailID As DataColumn = myds.Tables("tblPODetails").Columns("PODetailID")
            detailID.AutoIncrement = True
            detailID.AutoIncrementStep = -1
            detailID.AutoIncrementSeed = -1
            detailID.ReadOnly = False

            poc.GetPORecAd.Fill(myds, "tblPOReceiving")
            Dim recvID As DataColumn = myds.Tables("tblPOReceiving").Columns("PORecvID")
            recvID.AutoIncrement = True
            recvID.AutoIncrementStep = -1
            recvID.AutoIncrementSeed = -1
            recvID.ReadOnly = False

            myds.EnforceConstraints = False

            With myds
                .Relations.Add("DetRecv", _
                    .Tables("tblPODetails").Columns("PODetailID"), _
                    .Tables("tblPOReceiving").Columns("PODetailID"), True)
            End With

            rowCount = myds.Tables("tblPOReceiving").Rows.Count

        Catch ex As EvaluateException
            MsgBox("Exception occured - " & ex.Message)
        End Try

        '=========================
        dsAlusta.Clear()
        dsAlusta.Relations.Clear()

        CallClass.PopulateDataAdapter("getPOUpload_IntoAlustaEmpty").Fill(dsAlusta, "tblSelect")

        dsAlusta.EnforceConstraints = False

        dgAlusta.AutoGenerateColumns = False
        dgAlusta.DataSource = dsAlusta
        dgAlusta.DataMember = "tblSelect"


    End Sub

    Sub HideCtl()

        pnlPORecv.Visible = False
        dtPSlipDate.Visible = False
        dtRecDate.Visible = False
        txtPONumber.Visible = False
        btnSave.Visible = False
        btnAccAll.Visible = False
        btnRecAll.Visible = False
        'btnFindPO.Visible = False

        pnlPOMas.Visible = False
        cmbSupplier.Visible = False
        cmbBuyer.Visible = False
        cmbUser.Visible = False
        cmbPOStatus.Visible = False
        cmbPOType.Visible = False
        txtPODate.Visible = False

    End Sub

    Sub SetCtlPry()

        With Me.cmbSupplier
            .DataSource = poc.GetPOSupplier().Tables("tblSupplier")
            .DisplayMember = "SuppName"
            .ValueMember = "SupplierID"
        End With

        With Me.cmbBuyer
            .DataSource = poc.GetPOBuyer().Tables("tblBuyer")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

        With Me.cmbUser
            .DataSource = poc.GetPOBuyer().Tables("tblBuyer")
            .DisplayMember = "EmpName"
            .ValueMember = "EmployeeID"
        End With

        'For dgPODetails properies

        With Me.ProdDesc
            .DataSource = poc.GetPOProd().Tables("tblProdDesc")
            .DisplayMember = "ProdDescr"
            .ValueMember = "ProdID"
            .DataPropertyName = "POProdID"
            .Name = "POProdID"
        End With

        With Me.POMpoNo
            .DataSource = poc.GetMpoNo().Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
            .DataPropertyName = "POMpoID"
            .Name = "POMpoID"
        End With

        With Me.POUM
            .DataSource = poc.GetPOUM().Tables("tblUM")
            .DisplayMember = "IDum"
            .ValueMember = "IDum"
            .DataPropertyName = "POUM"
            .Name = "POUM"
        End With

        With Me.PODetails
            .DataPropertyName = "PODetailID"
            .Name = "PODetailID"
        End With

        With Me.POItemDet
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.POQtyDet
            .DataPropertyName = "POQty"
            .Name = "POQty"
        End With

        With Me.POPrice
            .DataPropertyName = "POPrice"
            .Name = "POPrice"
        End With

        With Me.PODiscount
            .DataPropertyName = "PODiscount"
            .Name = "PODiscount"
        End With

        With Me.TotalValue
            .DataPropertyName = "TotalValue"
            .Name = "TotalValue"
        End With

        'For dgPOReceivings properies

        With Me.POItemRecv
            .DataPropertyName = "POItem"
            .Name = "POItem"
        End With

        With Me.RecDate
            .DataPropertyName = "RecDate"
            .Name = "RecDate"
        End With

        With Me.POMpoNoRecv
            .DataSource = poc.GetMpoNo().Tables("tblMpoMaster")
            .DisplayMember = "MpoNo"
            .ValueMember = "MpoId"
            .DataPropertyName = "PslipMpoID"
            .Name = "PslipMpoID"
        End With

        With Me.PSlipNum
            .DataPropertyName = "PSlipNum"
            .Name = "PSlipNum"
        End With

        With Me.PSlipDate
            .DataPropertyName = "PSlipDate"
            .Name = "PSlipDate"
        End With

        With Me.PSlipQty
            .DataPropertyName = "PSlipQty"
            .Name = "PSlipQty"
        End With

        With Me.PSlipUM
            .DataSource = poc.GetPOUM().Tables("tblUM")
            .DisplayMember = "IDum"
            .ValueMember = "IDum"
            .DataPropertyName = "PSlipUM"
            .Name = "PSlipUM"
        End With

        With Me.PSlipPrice
            .DataPropertyName = "PSlipPrice"
            .Name = "PSlipPrice"
        End With

        With Me.PSlipDiscount
            .DataPropertyName = "PSlipDiscount"
            .Name = "PSlipDiscount"
        End With

        With Me.AccpToPay
            .DataPropertyName = "AccpToPay"
            .Name = "AccpToPay"
            .TrueValue = 1
            .FalseValue = 0
        End With

        With Me.ApprRecvToPay
            .DataPropertyName = "ApprRecvToPay"
            .Name = "ApprRecvToPay"
            .TrueValue = 1
            .FalseValue = 0
            .Visible = False
        End With
      
        With Me.TotalValueRecv
            .DataPropertyName = "TotalValue"
            .Name = "TotalValue"
        End With

        With Me.PoRecvID
            .DataPropertyName = "PoRecvID"
            .Name = "PoRecvID"
        End With

        With Me.AlustaBarCode
            .DataPropertyName = "AlustaBarCode"
            .Name = "AlustaBarCode"
        End With


        ' LACDATA 
        With Me.LACDATA
            .DataPropertyName = "LACDATA"
            .Name = "LACDATA"
        End With

        With Me.ENTPONo
            .DataPropertyName = "ENTPONo"
            .Name = "ENTPONo"
            .Visible = False
        End With

        With Me.ENTLAC
            .DataPropertyName = "ENTLAC"
            .Name = "ENTLAC"
            .Visible = False
        End With
        With Me.ENTDOR
            .DataPropertyName = "ENTDOR"
            .Name = "ENTDOR"
            .Visible = False
        End With
        With Me.ENTSUPP
            .DataPropertyName = "ENTSUPP"
            .Name = "ENTSUPP"
            .Visible = False
        End With
        With Me.ENTDEVISE
            .DataPropertyName = "ENTDEVISE"
            .Name = "ENTDEVISE"
            .Visible = False
        End With
        With Me.ENTCODETAXE
            .DataPropertyName = "ENTCODETAXE"
            .Name = "ENTCODETAXE"
            .Visible = False
        End With
        With Me.SwENTHT
            .DataPropertyName = "SwENTHT"
            .Name = "SwENTHT"
            .Visible = False
        End With
        With Me.ENTTTC
            .DataPropertyName = "ENTTTC"
            .Name = "ENTTTC"
            .Visible = False
        End With
        With Me.ENTRequester
            .DataPropertyName = "ENTRequester"
            .Name = "ENTRequester"
            .Visible = False
        End With
        With Me.ENTBuyer
            .DataPropertyName = "ENTBuyer"
            .Name = "ENTBuyer"
            .Visible = False
        End With
        With Me.ENTPOStatus
            .DataPropertyName = "ENTPOStatus"
            .Name = "ENTPOStatus"
            .Visible = False
        End With
        With Me.ENTPODate
            .DataPropertyName = "ENTPODate"
            .Name = "ENTPODate"
            .Visible = False
        End With
        With Me.ENTPOModDate
            .DataPropertyName = "ENTPOModDate"
            .Name = "ENTPOModDate"
            .Visible = False
        End With
        With Me.LINPONo
            .DataPropertyName = "LINPONo"
            .Name = "LINPONo"
            .Visible = False
        End With
        With Me.LINPOType
            .DataPropertyName = "LINPOType"
            .Name = "LINPOType"
            .Visible = False
        End With
        With Me.LINPOItem
            .DataPropertyName = "LINPOItem"
            .Name = "LINPOItem"
            .Visible = False
        End With
        With Me.LINPOQty
            .DataPropertyName = "LINPOQty"
            .Name = "LINPOQty"
            .Visible = False
        End With
        With Me.LINPOUM
            .DataPropertyName = "LINPOUM"
            .Name = "LINPOUM"
            .Visible = False
        End With
        With Me.LINTotalPrice
            .DataPropertyName = "LINTotalPrice"
            .Name = "LINTotalPrice"
            .Visible = False
        End With
        With Me.LINTotPriceConf
            .DataPropertyName = "LINTotPriceConf"
            .Name = "LINTotPriceConf"
            .Visible = False
        End With
        With Me.LINHT
            .DataPropertyName = "LINHT"
            .Name = "LINHT"
            .Visible = False
        End With
        With Me.LINRemise
            .DataPropertyName = "LINRemise"
            .Name = "LINRemise"
            .Visible = False
        End With
        With Me.LINProdID
            .DataPropertyName = "LINProdID"
            .Name = "LINProdID"
            .Visible = False
        End With
        With Me.LINProdDescr
            .DataPropertyName = "LINProdDescr"
            .Name = "LINProdDescr"
            .Visible = False
        End With
        With Me.LINGLCode
            .DataPropertyName = "LINGLCode"
            .Name = "LINGLCode"
            .Visible = False
        End With
        With Me.LINEtablissement
            .DataPropertyName = "LINEtablissement"
            .Name = "LINEtablissement"
            .Visible = False
        End With
        With Me.LINSUPP
            .DataPropertyName = "LINSUPP"
            .Name = "LINSUPP"
            .Visible = False
        End With
        With Me.LINCostCenter
            .DataPropertyName = "LINCostCenter"
            .Name = "LINCostCenter"
            .Visible = False
        End With
        With Me.LINFamille
            .DataPropertyName = "LINFamille"
            .Name = "LINFamille"
            .Visible = False
        End With
        With Me.LINCommande
            .DataPropertyName = "LINCommande"
            .Name = "LINCommande"
            .Visible = False
        End With
        With Me.LINCapexNo
            .DataPropertyName = "LINCapexNo"
            .Name = "LINCapexNo"
            .Visible = False
        End With
        With Me.LINCapexDescr
            .DataPropertyName = "LINCapexDescr"
            .Name = "LINCapexDescr"
            .Visible = False
        End With
        With Me.LINStatus
            .DataPropertyName = "LINStatus"
            .Name = "LINStatus"
            .Visible = False
        End With
        With Me.LINSolde
            .DataPropertyName = "LINSolde"
            .Name = "LINSolde"
            .Visible = False
        End With
        With Me.RECPONo
            .DataPropertyName = "RECPONo"
            .Name = "RECPONo"
            .Visible = False
        End With
        With Me.RECLine
            .DataPropertyName = "RECLine"
            .Name = "RECLine"
            .Visible = False
        End With
        With Me.RECNo
            .DataPropertyName = "RECNo"
            .Name = "RECNo"
            .Visible = False
        End With
        With Me.RECQty
            .DataPropertyName = "RECQty"
            .Name = "RECQty"
            .Visible = False
        End With
        With Me.RECNET
            .DataPropertyName = "RECNET"
            .Name = "RECNET"
            .Visible = False
        End With
        With Me.ARECDate
            .DataPropertyName = "ARECDate"
            .Name = "ARECDate"
            .Visible = False
        End With
        With Me.RECBarCode
            .DataPropertyName = "RECBarCode"
            .Name = "RECBarCode"
            .Visible = False
        End With
        With Me.RECSTATUS
            .DataPropertyName = "RECSTATUS"
            .Name = "RECSTATUS"
            .Visible = False
        End With

        With Me.ADocRecvNo
            .DataPropertyName = "ADocRecvNo"
            .Name = "ADocRecvNo"
            .Visible = False
        End With

        With Me.ARecvMatlWeight
            .DataPropertyName = "ARecvMatlWeight"
            .Name = "ARecvMatlWeight"
            .Visible = False
        End With

        With Me.ARecQtyAccp
            .DataPropertyName = "ARecQtyAccp"
            .Name = "ARecQtyAccp"
            .Visible = False
        End With

        With Me.AAccpToPay
            .DataPropertyName = "AAccpToPay"
            .Name = "AAccpToPay"
            .Visible = False
        End With
        With Me.AApprInsp
            .DataPropertyName = "AApprInsp"
            .Name = "AApprInsp"
            .Visible = False
        End With
        With Me.AApprRecvToPay
            .DataPropertyName = "AApprRecvToPay"
            .Name = "AApprRecvToPay"
            .Visible = False
        End With
        With Me.APayInvDate
            .DataPropertyName = "APayInvDate"
            .Name = "APayInvDate"
            .Visible = False
        End With

    End Sub

    Sub BindComponents()

        Try
            Dim ds As New DataSet

            VisibleCtl()

            ds = poc.GetPOMasData(poNum)

            cmbSupplier.DataBindings.Clear()
            cmbBuyer.DataBindings.Clear()
            txtPODate.DataBindings.Clear()
            cmbUser.DataBindings.Clear()
            cmbPOStatus.DataBindings.Clear()
            cmbPOStatus.Text = ""
            cmbPOType.DataBindings.Clear()
            cmbPOType.Text = ""

            cmbSupplier.DataBindings.Add("SelectedValue", ds, "tblPOMasData.POSuppID")
            cmbBuyer.DataBindings.Add("SelectedValue", ds, "tblPOMasData.POBuyer")
            txtPODate.DataBindings.Add("Text", ds, "tblPOMasData.PODate")
            'cmbUser.DataBindings.Add("SelectedValue", ds, "tblPOMasData.POUser")
            cmbUser.SelectedValue = wkEmpId
            cmbPOStatus.DataBindings.Add("SelectedText", ds, "tblPOMasData.POStatus")
            cmbPOType.DataBindings.Add("SelectedText", ds, "tblPOMasData.POType")

            Select Case (cmbPOStatus.Text)
                Case "Cancelled"
                    MsgBox("This PO has been cancelled.")
                    Call PageReadOnly()
                Case "Accepted"
                    MsgBox("This PO has already been accepted.")
                    Call PageReadOnly()
                Case "Payed"
                    MsgBox("This PO has already been payed.")
                    Call PageReadOnly()
                Case "AMMD"
                    MsgBox("Please receive the items on the new Amendment.")
                    Call PageReadOnly()
                Case "Open"
                    If cmbPOType.Text = "General" Or cmbPOType.Text = "MSAccess" Then
                        btnAccAll.Enabled = True
                        btnRecAll.Enabled = False

                        If RoleRecv(wkDeptCode) = True Or RoleRecvInsp(wkDeptCode) = True Then
                            'EnableCtl()
                            dgPOReceivings.ReadOnly = False
                        Else
                            'PageReadOnly()
                            dgPOReceivings.ReadOnly = True
                        End If
                    Else
                        btnAccAll.Enabled = False
                        btnRecAll.Enabled = True

                        dgPOReceivings.Columns("AccpToPay").ReadOnly = False
                    End If

            End Select

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - BindComponents. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Function RoleRecv(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RECV" Then
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

    Function RoleRecvInsp(ByVal rstr As String) As Boolean
        Dim flg As Boolean
        Dim str() As String
        str = rstr.Split(";")
        For i As Integer = 0 To str.Length - 1
            If str(i) = "RECVINSP" Then
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

    Sub VisibleCtl()

        pnlPORecv.Visible = True
        pnlPOMas.Visible = True
        cmbSupplier.Visible = True
        cmbBuyer.Visible = True
        cmbUser.Visible = True
        cmbPOStatus.Visible = True
        cmbPOType.Visible = True
        txtPODate.Visible = True

        pnlPORecv.Enabled = True
        cmbSupplier.Enabled = False
        cmbBuyer.Enabled = False
        cmbUser.Enabled = False
        cmbPOStatus.Enabled = False
        cmbPOType.Enabled = False
        txtPODate.Enabled = False

        If RoleRecv(wkDeptCode) = True Or RoleRecvInsp(wkDeptCode) = True Then
            btnSave.Visible = True
            btnAccAll.Visible = True
            btnRecAll.Visible = True
            dgPOReceivings.ReadOnly = False
            'EnableCtl()
        Else
            btnSave.Visible = False
            btnAccAll.Visible = False
            btnRecAll.Visible = False
            dgPOReceivings.ReadOnly = True
            'PageReadOnly()
        End If

        btnFindPO.Visible = True

    End Sub

    Sub PageReadOnly()

        btnFindPO.Enabled = False
        btnSave.Enabled = False
        btnAccAll.Enabled = False
        btnRecAll.Enabled = False
        btnDelRecv.Enabled = False

        txtPSlipNumber.ReadOnly = True
        txtPONumber.ReadOnly = True
        dtPSlipDate.Enabled = False
        dtRecDate.Enabled = False

        cmbSupplier.Enabled = False
        cmbBuyer.Enabled = False
        cmbUser.Enabled = False
        cmbPOStatus.Enabled = False
        cmbPOType.Enabled = False
        txtPODate.ReadOnly = True

        dgPODetails.ReadOnly = True
        dgPOReceivings.ReadOnly = True
        'pnlPORecv.Enabled = False

    End Sub

    Sub EnableCtl()

        txtPSlipNumber.Enabled = True
        'txtPSlipNumber.Clear()
        dtPSlipDate.Enabled = True
        dtRecDate.Enabled = True
        txtPONumber.Enabled = True
        txtPONumber.Clear()
        btnFindPO.Enabled = True
        btnSave.Enabled = True
        btnAccAll.Enabled = True
        btnRecAll.Enabled = True
        btnDelRecv.Enabled = True

        txtPSlipNumber.Visible = True
        txtPSlipNumber.ReadOnly = False
        txtPONumber.ReadOnly = False
        txtPODate.ReadOnly = False
        dgPODetails.ReadOnly = False
        dgPOReceivings.ReadOnly = False

    End Sub

    Sub PopulatePOReceivings()

        Try
            dgPOReceivings.AutoGenerateColumns = False
            dgPOReceivings.DataSource = myds
            dgPOReceivings.DataMember = "tblPODetails.DetRecv"

            If dgPOReceivings.Rows.Count > 0 Then
                Dim I As Integer

                For I = 0 To dgPOReceivings.Rows.Count - 1
                    Me.dgPOReceivings("TotalValue", I).Value = Nz.Nz(Me.dgPOReceivings("PSlipQty", I).Value) * ((Nz.Nz(Me.dgPOReceivings("PSlipPrice", I).Value)) - (Nz.Nz(Me.dgPOReceivings("PSlipPrice", I).Value) * Nz.Nz(Me.dgPOReceivings.Item("PSlipDiscount", I).Value)) / 100)
                    If cmbPOType.Text = "General" Or cmbPOType.Text = "MSAccess" Then
                        If Nz.Nz(Me.dgPOReceivings("AccpToPay", I).Value) = True Then
                            dgPOReceivings.Rows(I).ReadOnly = True
                        End If
                    End If
                Next
            End If

            Call TotalRec()

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - PopulatePOReceivings. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Sub TotalRec()

        Try
            Dim qty As Integer
            Dim tvalue As Single
            For Each Row As DataGridViewRow In dgPOReceivings.Rows
                qty = qty + Nz.Nz(Row.Cells("PSlipQty").Value)
                tvalue = tvalue + Nz.Nz(Row.Cells("TotalValue").Value)
            Next
            txtTotalRecQty.Text = qty.ToString("N2")
            txtTotalRecValue.Text = tvalue.ToString("C2")

            If cmbPOType.Text = "Raw Material" Then

                If Nz.Nz(qty) = 0 Then
                    Exit Sub
                End If

                If qty > (Val(poqty) + ((Val(poqty) * 30) / 100)) Then
                    If flagMes = False Then
                        Try
                            MsgBox("Raw Material Quantity exceeds the maximum value (+30%).")

                            'Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
                            'Dim strBody As String = ""
                            'NotesSession = CreateObject("Notes.NotesSession")

                            'If Len(wkEmpLogin) > 8 Then
                            '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
                            'Else
                            '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
                            'End If

                            'NotesDoc = NotesDb.CREATEDOCUMENT
                            'NotesItem = NotesDoc.CreateRichTextItem("BODY")
                            ''NotesDoc.Form = "Memo"
                            'NotesDoc.Subject = "Receiving Module"
                            ''NotesDoc.cc = ""
                            'strBody = "Raw Material Quantity exceeds the maximum value (+30%)" & vbCrLf
                            'strBody = strBody & "-- PO Number: " & txtPONumber.Text & vbCrLf
                            'NotesDoc.body = strBody

                            'Call NotesDoc.SEND(False, "yanick.levert@lisi-aerospace.com")
                            ''Call NotesDoc.SEND(False, "stefan.tudor@lisi-aerospace.com")

                            Dim email As New Mail.MailMessage()
                            Dim strBody As String = ""
                            email.Subject = "Receiving Module"
                            strBody = "Raw Material Quantity exceeds the maximum value (+30%)" & vbCrLf
                            strBody = strBody & "-- PO Number: " & txtPONumber.Text & vbCrLf
                            email.Body = strBody

                            Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                            email.From = New Net.Mail.MailAddress(wkEmpEmail)
                            email.To.Add(New Mail.MailAddress("yanick.levert@lisi-aerospace.com"))
                            client.Send(email)

                            flagMes = True

                        Catch ex As Exception
                            MsgBox("!!! ERROR !!! - The Application can not send the Email to Buyer. Please contact the administrator." & ex.Message)
                        End Try
                    End If
                Else

                    If qty < (Val(poqty) - ((Val(poqty) * 10) / 100)) Then
                        MsgBox("Raw Material Quantity received is less with (10%). " + vbCrLf + _
                        "That means there is a BackOrder Delivery or multiples delivery for the same PO line. " + vbCrLf + _
                         " PO amendment is requested.")

                        btnSave.Enabled = False
                        btnAccAll.Enabled = False
                        btnRecAll.Enabled = False

                        'Dim NotesSession As Object, NotesDoc As Object, NotesItem As Object, NotesDb As Object
                        'Dim strBody As String = ""
                        'NotesSession = CreateObject("Notes.NotesSession")

                        'If Len(wkEmpLogin) > 8 Then
                        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & Microsoft.VisualBasic.Left(wkEmpLogin, 8) & ".NSF")
                        'Else
                        '    NotesDb = NotesSession.GetDatabase("19772.168.115.2", "mail\" & wkEmpLogin & ".NSF")
                        'End If

                        'NotesDoc = NotesDb.CREATEDOCUMENT
                        'NotesItem = NotesDoc.CreateRichTextItem("BODY")
                        ''NotesDoc.Form = "Memo"
                        'NotesDoc.Subject = "Receiving Module"
                        ''NotesDoc.cc = ""
                        'strBody = "Raw Material Quantity received is less with (10%). " + vbCrLf + _
                        '"That means there is a BackOrder Delivery or multiples delivery for the same PO line." + vbCrLf + _
                        ' " PO amendment is requested." & vbCrLf

                        'strBody = strBody & "-- PO Number: " & txtPONumber.Text & vbCrLf
                        'NotesDoc.body = strBody

                        'Call NotesDoc.SEND(False, "yanick.levert@lisi-aerospace.com")
                        ''Call NotesDoc.SEND(False, "stefan.tudor@lisi-aerospace.com")

                        Dim email As New Mail.MailMessage()
                        Dim strBody As String = ""
                        email.Subject = "Receiving Module"
                        strBody = "Raw Material Quantity received is less with (10%). " + vbCrLf + _
                        "That means there is a BackOrder Delivery or multiples delivery for the same PO line." + vbCrLf + _
                         " PO amendment is requested." & vbCrLf

                        strBody = strBody & "-- PO Number: " & txtPONumber.Text & vbCrLf
                        email.Body = strBody

                        Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                        email.From = New Net.Mail.MailAddress(wkEmpEmail)
                        email.To.Add(New Mail.MailAddress("yanick.levert@lisi-aerospace.com"))
                        client.Send(email)

                        flagMes = True
                    End If
                End If
            Else
                If Val(qty) > Val(poqty) Then
                    If flagMes = False Then
                        MsgBox("Quantity exceeds the maximum value.")
                        flagMes = True
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - TotalRec. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Private Sub txtPONumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONumber.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                poNum = txtPONumber.Text
                txtPONumber.Enabled = False
                Call BindComponents()
                Call PopulatePODetails()
                If dgPODetails.Rows.Count > 0 Then
                    dgPODetails.Rows(0).Selected = True
                    PoItem = dgPODetails("POItem", 0).Value
                    poDetailID = dgPODetails("PODetailID", 0).Value
                    poqty = dgPODetails("POQty", 0).Value

                    Call PopulatePOReceivings()

                    btnFindPO.Enabled = False

                    If FindPoflg = True Then
                        PageReadOnly()
                        FindPoflg = False
                    End If


                    If RoleRecv(wkDeptCode) = True Or RoleRecvInsp(wkDeptCode) = True Then
                        'EnableCtl()
                        dgPOReceivings.ReadOnly = False
                    Else
                        'PageReadOnly()
                        dgPOReceivings.ReadOnly = True
                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - TxtPONumber_KeyDown. Please contact the administrator." & ex.Message)
        End Try

        dsAlusta.Clear()

    End Sub

    Sub PopulatePODetails()

        Try
            myds.Tables("tblPODetails").Clear()
            poc.GetPODetailAd(poNum).Fill(myds, "tblPODetails")

            If myds.Tables("tblPODetails").Rows.Count = 0 Then
                MessageBox.Show("There is no such PO number existing, try again.", "Warning")
                txtPONumber.Enabled = True
                txtPONumber.Clear()
                txtPONumber.Focus()

                HideCtl()
            End If

            dgPODetails.AutoGenerateColumns = False
            dgPODetails.DataSource = myds
            dgPODetails.DataMember = "tblPODetails"
            dgPODetails.ReadOnly = True

            Call TotalPO()

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - PopulatePODetails. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Sub TotalPO()

        Try
            If dgPODetails.Rows.Count > 0 Then
                Dim I As Integer
                Dim tqty As Integer
                Dim tvalue As Single
                For I = 0 To dgPODetails.Rows.Count - 1
                    Me.dgPODetails("TotalValue", I).Value = Me.dgPODetails("POQty", I).Value * ((Me.dgPODetails("POPrice", I).Value) - (Me.dgPODetails("POPrice", I).Value * Nz.Nz(Me.dgPODetails.Item("PODiscount", I).Value)) / 100)
                    tqty = tqty + CDec(Nz.Nz(Me.dgPODetails("POQty", I).Value))
                    tvalue = tvalue + CDec(Nz.Nz(Me.dgPODetails("TotalValue", I).Value))
                Next
                txtTotalPOQty.Text = tqty.ToString("N2")
                txtTotalPOValue.Text = tvalue.ToString("C2")
            End If

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - TotalPO. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Call ValInfo()

        If SwVal = False Then
            Exit Sub
        End If

        dgPOReceivings.EndEdit()
        'To change the current row, to the last row:
        Dim cellLastRow As DataGridViewCell = dgPOReceivings.Rows(dgPOReceivings.Rows.Count - 1).Cells(0)
        dgPOReceivings.CurrentCell = cellLastRow

        For Each Row As DataGridViewRow In dgPOReceivings.Rows
            Row.Cells("AccpToPay").Value = 1
        Next

        If (myds.HasChanges) Then
            Try
                poc.UpdatePORec(myds.GetChanges)

                If cmbPOType.Text = "Raw Material" Then
                    CallClass.UpdateMatlStock("cspUpdatetblStockRawMatl")
                End If

                MsgBox("Update successfully.")
                myds.AcceptChanges()

                Call VerQtyRecv()

            Catch ex As Exception
                MsgBox("Update failed: " & ex.Message)
                myds.RejectChanges()

                updflg = False

            End Try
        End If

        If SwRecvInsp = True Then
            updflg = False
            SwRecvInsp = False
        End If

        If updflg = True Then
            poc.UpdatePOMas(poNum)
            updflg = False
        End If

        Call BindComponents()

        Call PageReadOnly()

        AlustaProcess()

    End Sub

    Sub ValInfo()

        Try
            Dim II As Integer
            For II = 1 To dgPOReceivings.Rows.Count - 1

                If IsDBNull(dgPOReceivings.Item("PSlipQty", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Quantity Received is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If dgPOReceivings.Item("PSlipQty", II - 1).Value = 0 Then
                    MsgBox("!!! ERROR !!! Quantity Received is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If IsDBNull(dgPOReceivings.Item("PSlipNum", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Packing Slip number is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If IsDBNull(dgPOReceivings.Item("PSlipDate", II - 1).Value) = True Then
                    MsgBox("!!! ERROR !!! Packing Slip date is Empty.")
                    SwVal = False
                    Exit Sub
                End If

                If (dgPOReceivings.Item("POItem", 0).Value = Nothing) Then
                    MsgBox("!!! ERROR !!! Please select PO Item to create new receiving before saving.")
                    SwVal = False
                    Exit Sub
                End If

                ' test

                Dim SwDateRecv As Date = dgPOReceivings.Item("RecDate", 0).Value
                Dim SwNow As Date = "04/01/2017"

                If SwDateRecv >= SwNow Then

                    If IsNothing(dgPOReceivings.Item("AlustaBarCode", 0).Value) = True Or IsDBNull(dgPOReceivings.Item("AlustaBarCode", 0).Value) = True Then
                        MsgBox("!!! ERROR: BarCode is Empty !!! Please enter the BarCode# - ALUTSA project.")
                        SwVal = False
                        Exit Sub
                    Else
                        If InStr(dgPOReceivings.Item("AlustaBarCode", 0).Value, "LC1") <> 0 Or _
                                InStr(dgPOReceivings.Item("AlustaBarCode", 0).Value, "LC2") <> 0 Or _
                                InStr(dgPOReceivings.Item("AlustaBarCode", 0).Value, "LC3") <> 0 Then
                        Else
                            MsgBox("!!! ERROR: BarCode Prefix !!!  BarCode# - ALUTSA project.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If

                    If IsNothing(dgPOReceivings.Item("AlustaBarCode", 0).Value) = False Or IsDBNull(dgPOReceivings.Item("AlustaBarCode", 0).Value) = False Then
                        If Len(Trim(dgPOReceivings.Item("AlustaBarCode", 0).Value)) <> 9 Then
                            MsgBox("!!! ERROR: BarCode Length !!! Please enter the correct BarCode# - ALUTSA project.")
                            SwVal = False
                            Exit Sub
                        End If
                    End If


                End If

            Next

            SwVal = True

        Catch ex As Exception
            MsgBox("!!! ERROR Application !!! - ValInfo. Please contact the administrator." & ex.Message)
        End Try

    End Sub

    Sub VerQtyRecv()

        If cmbPOType.Text = "Raw Material" Or cmbPOType.Text = "Processing" Then
            updflg = False
            Exit Sub
        End If

        Dim ppoQty As Integer = 0
        Dim recQty As Integer = 0

        For I As Integer = 0 To (dgPODetails.Rows.Count - 1)
            ppoQty = ppoQty + dgPODetails("POQty", I).Value
            For Each rectrw As DataRow In myds.Tables("tblPOReceiving").Rows
                If dgPODetails("PODetailID", I).Value = rectrw.Item("PODetailID") Then
                    recQty = recQty + rectrw.Item("PSlipQty")
                End If
            Next
        Next I

        If SwRecvInsp = False Then
            If recQty >= ppoQty Then
                Dim reply As DialogResult
                reply = MsgBox("Quantity Received is Greater or Equal with Quantity Ordered. Do you want to Accept the PO ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    updflg = True
                Else
                    updflg = False
                End If
            End If
        End If
    End Sub

    Private Sub txtPSlipNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSlipNumber.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If txtPSlipNumber.Text = Nothing Then
                MsgBox("PSlip number is required.")
                txtPSlipNumber.Focus()
            Else
                dtPSlipDate.Visible = True
                dtPSlipDate.Focus()
                txtPSlipNumber.Enabled = False
            End If

        End If
    End Sub

    Private Sub dtPSlipDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtPSlipDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtRecDate.Visible = True
            dtRecDate.Focus()
            dtPSlipDate.Enabled = False
        End If
    End Sub

    Private Sub dtRecDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtRecDate.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtPONumber.Visible = True
            txtPONumber.Focus()
            dtRecDate.Enabled = False
        End If
    End Sub

    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click


        GC.Collect()
        EnableCtl()
        InitialComponents()

        'HideCtl()
        txtPSlipNumber.Clear()
        txtPSlipNumber.Focus()

        myds.RejectChanges()

        ' FindPoflg = False
        ' flagMes = False
        '  SwRecvInsp = False

    End Sub


    Private Sub dtPSlipDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPSlipDate.ValueChanged
        dtRecDate.Visible = True
        dtRecDate.Focus()
        dtPSlipDate.Enabled = False
    End Sub

    Private Sub dtRecDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtRecDate.ValueChanged
        txtPONumber.Visible = True
        txtPONumber.Focus()
        dtRecDate.Enabled = False
    End Sub

    Private Sub btnAccAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccAll.Click
        Dim ppoQty As Integer
        Dim recQty As Integer
        Dim flg As Boolean

        'For Each drw As DataGridViewRow In dgPODetails.Rows
        For i As Integer = 0 To (dgPODetails.Rows.Count - 1)
            flg = False
            ppoQty = ppoQty + dgPODetails("POQty", i).Value
            For Each trw As DataRow In myds.Tables("tblPOReceiving").Rows
                If Nz.Nz(trw.Item("PODetailID")) = Nz.Nz(dgPODetails.Rows(i).Cells("PODetailID").Value) And _
                    Nz.Nz(trw.Item("POItem")) = Nz.Nz(dgPODetails.Rows(i).Cells("POItem").Value) Then
                    flg = True
                    Exit For
                End If
            Next
            'have no receiving before
            If flg = False Then
                SetMyds(i, True)
            End If
        Next i

        'calculate the total receiving qty
        Try
            For Each trw As DataRow In myds.Tables("tblPOReceiving").Rows
                recQty = recQty + Nz.Nz(trw.Item("PSlipQty"))
                If Nz.Nz(trw.Item("AccpToPay")) = 0 Then
                    trw.Item("AccpToPay") = True
                End If
            Next
        Catch ex As Exception

        End Try
       

        If recQty >= ppoQty Then
            updflg = True
            'poc.UpdatePOMas(poNum)
            'Call BindComponents()
        End If

        Call PopulatePOReceivings()

        btnAccAll.Enabled = False

    End Sub

    Sub SetMyds(ByVal index As Integer, ByVal ckd As Boolean)
        Try
            If index < 0 Then
                Exit Sub
            End If

            Dim tb As DataTable
            Dim rw As DataRow
            tb = myds.Tables("tblPOReceiving")
            rw = tb.NewRow

            rw("POItem") = dgPODetails.Item("POItem", index).Value
            rw("PODetailID") = dgPODetails.Item("PODetailID", index).Value
            rw("PslipMpoID") = dgPODetails.Item("POMpoID", index).Value
            rw("RecDate") = dtRecDate.Text
            rw("PSlipDate") = dtPSlipDate.Text
            rw("PSlipNum") = txtPSlipNumber.Text
            rw("PSlipDiscount") = dgPODetails.Item("PODiscount", index).Value
            rw("AccpToPay") = ckd

            If cmbPOType.Text = "Raw Material" Then
                If dgPODetails.Item("POUM", index).Value = "KG" Then
                    MessageBox.Show("The quantity received will be converted in LBS. Please adjust the quantity received if we have a back order. The Coef. used is: 2.2046", "Warning")
                    rw("PSlipUM") = "LB"
                    rw("PSlipQty") = (dgPODetails.Item("POQty", index).Value) * 2.2046
                    rw("PSlipPrice") = (dgPODetails.Item("POPrice", index).Value) / 2.2046
                Else
                    rw("PSlipUM") = dgPODetails.Item("POUM", index).Value
                    'rw("PSlipQty") = dgPODetails.Item("POQty", index).Value
                    rw("PSlipQty") = 0
                    rw("PSlipPrice") = dgPODetails.Item("POPrice", index).Value
                End If

                If dgPODetails.Item("POUM", index).Value = "SH" Then
                    MessageBox.Show("The quantity received MUST TO be converted in LBS. Please adjust the quantity received and the unit price", "Warning")
                End If
            Else
                rw("PSlipUM") = dgPODetails.Item("POUM", index).Value
                rw("PSlipQty") = dgPODetails.Item("POQty", index).Value
                rw("PSlipPrice") = dgPODetails.Item("POPrice", index).Value
            End If

            tb.Rows.Add(rw)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgPOReceivings_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgPOReceivings.CellBeginEdit

        If e.ColumnIndex = 0 Then
            dgPOReceivings.Columns(0).Selected = True
        End If

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case e.ColumnIndex
            Case 0 To 8
                If IsDBNull(dgPOReceivings("AccpToPay", e.RowIndex).Value) = False And _
                    Nz.Nz(dgPOReceivings("AccpToPay", e.RowIndex).Value) = True Then
                    MsgBox("You cannot edit here. The Receiving data was accepted")
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If

                If IsDBNull(dgPOReceivings("ApprRecvToPay", e.RowIndex).Value) = False And _
                    Nz.Nz(dgPOReceivings("ApprRecvToPay", e.RowIndex).Value) = True Then
                    MsgBox("You cannot edit here. The item was approved for payment")
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If

        End Select

    End Sub

    Private Sub dgPOReceivings_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPOReceivings.CellClick
        rowRecIndex = e.RowIndex
        rowColRecIndex = e.ColumnIndex

        If rowRecIndex < 0 Then
            Exit Sub
        End If

        dgPOReceivings.Item("TotalValue", rowRecIndex).Value = _
             Nz.Nz(dgPOReceivings.Item("PSlipQty", rowRecIndex).Value) * _
             Nz.Nz(dgPOReceivings.Item("PSlipPrice", rowRecIndex).Value) * _
             (1 - Nz.Nz(dgPOReceivings.Item("PSlipDiscount", rowRecIndex).Value) / 100)

        Call TotalRec()

        Select Case e.ColumnIndex
            Case 5 To 9
                If IsDBNull(dgPOReceivings.Item("POItem", rowRecIndex).Value) = True Then
                    MsgBox("you cannot edit here without PO Item.")
                    dgPOReceivings.Rows(rowRecIndex).ReadOnly = True
                    dgPOReceivings("POItem", rowRecIndex).ReadOnly = False
                End If

            Case 10

                If IsDBNull(dgPOReceivings("POItem", rowRecIndex).Value) = True And _
                    Nz.Nz(dgPOReceivings("POItem", rowRecIndex).Value) = 0 Then
                    MsgBox("You cannot edit here. The Receiving Item is empty.")
                End If
        End Select
    End Sub

    Private Sub dgPOReceivings_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPOReceivings.CellEndEdit
        'Dim II As Integer = 0
        'II = e.KeyCode
        'If II = Keys.Return Or II = Keys.Tab Or II = Keys.Right Then

        If rowRecIndex < 0 Then
            Exit Sub
        End If

        Try
            dgPOReceivings.Rows(rowRecIndex).Selected = True
        Catch ex As Exception
        End Try

        Select Case rowColRecIndex
            Case 0
                Dim reply As DialogResult
                If Nz.Nz(dgPOReceivings.Item("POItem", rowRecIndex).Value) = POItem Then
                    reply = MsgBox("Do you want to create new receiving?", MsgBoxStyle.YesNo)
                    If reply = Windows.Forms.DialogResult.Yes Then
                        dgPOReceivings.Rows(rowRecIndex).Selected = True
                        dgPOReceivings.Rows.RemoveAt(rowRecIndex)
                        dgPOReceivings.Refresh()

                        Call SetMyds(rowPOIndex, False)

                        dgPOReceivings.Refresh()
                        dgPOReceivings.Rows(rowRecIndex).Selected = True
                    Else
                        If rowRecIndex >= 0 Then
                            dgPOReceivings.Rows.RemoveAt(rowRecIndex)
                            dgPOReceivings.Refresh()
                        End If
                    End If
                Else
                    MessageBox.Show("you must enter the same PO item number.", "Warning")
                    dgPOReceivings.Rows.RemoveAt(rowRecIndex)
                    dgPOReceivings.Refresh()
                End If
            Case 5      'pslip quantity

                If cmbPOType.Text = "Grinding" Then
                    Try
                        Dim SWMatlLot As String = ""
                        Dim SwMatlWeightBefore As Integer
                        Dim SwOldPrice As String = ""
                        Dim SwMPOMachCost As String = ""
                        Dim SwMatlWeightAfter As String = ""

                        SWMatlLot = CallClass.ReturnStrWithParInt("cspReturnMpoMatlLotNo", dgPODetails("POMpoID", rowPOIndex).Value)
                        SwMatlWeightBefore = dgPODetails("POQty", rowPOIndex).Value
                        SwOldPrice = CallClass.ReturnInfoWithParString("cspReturnMatlSTPriceByMatlLot", SWMatlLot)
                        SwMPOMachCost = CallClass.TakeFinalSt("cspReturnMpoMachCost", dgPODetails("POMpoID", rowPOIndex).Value)
                        SwMatlWeightAfter = dgPOReceivings("PslipQty", rowRecIndex).Value

                        frmPOReceivingPriceAdj.txtLotGr.Text = SWMatlLot
                        frmPOReceivingPriceAdj.txtWeightBefore.Text = SwMatlWeightBefore
                        frmPOReceivingPriceAdj.txtOldPrice.Text = SwOldPrice
                        frmPOReceivingPriceAdj.txtMachCost.Text = SwMPOMachCost
                        frmPOReceivingPriceAdj.txtWeightAfter.Text = SwMatlWeightAfter
                        frmPOReceivingPriceAdj.txtPOPrice.Text = dgPODetails("POPrice", rowPOIndex).Value
                        frmPOReceivingPriceAdj.ShowDialog()

                        'dgPOReceivings("PSlipPrice", rowRecIndex).Value = SwPrice.Text

                        dgPOReceivings.Item("PSlipPrice", rowRecIndex).Value = CDbl(SwPrice.Text)


                        'dgPOReceivings.Rows(rowRecIndex).Selected = True

                    Catch ex As Exception

                    End Try
                End If

            Case 10

                If Len(Trim(Nz.Nz(dgPOReceivings.Item("POItem", rowRecIndex).Value))) <> 0 Then
                    dgPOReceivings("AlustaBarCode", rowRecIndex).Value = Microsoft.VisualBasic.UCase(dgPOReceivings("AlustaBarCode", rowRecIndex).Value)
                End If

                Dim SwInter As String = ""
                Dim SwPO As String = ""

                SwPO = CallClass.ReturnStrWith2ParStr("cspReturnAlustaBarCodeWithPO", txtPONumber.Text, dgPOReceivings("AlustaBarCode", rowRecIndex).Value)
                If SwPO = False Then

                    SwInter = CallClass.ReturnInfoWithParString("cspReturnAlustaBarCode", dgPOReceivings("AlustaBarCode", rowRecIndex).Value)
                    If SwInter <> "False" Then
                        MessageBox.Show("!!! ERROR !!! Alusta Bar Code already entered in DB.  Please enter the correct BarCode.")
                        dgPOReceivings("AlustaBarCode", rowRecIndex).Value = ""
                    End If

                End If

               End Select

        dgPOReceivings.Item("TotalValue", rowRecIndex).Value = _
            Nz.Nz(dgPOReceivings.Item("PSlipQty", rowRecIndex).Value) * _
           Nz.Nz(dgPOReceivings.Item("PSlipPrice", rowRecIndex).Value) * _
          (1 - Nz.Nz(dgPOReceivings.Item("PSlipDiscount", rowRecIndex).Value) / 100)

        Call TotalRec()

        ' End If

    End Sub

    Private Sub dgPODetails_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPODetails.CellClick
        rowPOIndex = e.RowIndex

        If rowPOIndex >= 0 Then
            If IsDBNull(dgPODetails("POItem", rowPOIndex).Value) = False Then
                dgPODetails.Rows(rowPOIndex).Selected = True
                poItem = dgPODetails("POItem", rowPOIndex).Value
                poDetailID = dgPODetails("PODetailID", rowPOIndex).Value
                poQty = dgPODetails("POQty", rowPOIndex).Value

                Call PopulatePOReceivings()
            End If
        End If

    End Sub

    Private Sub btnDelRecv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelRecv.Click
        Dim reply As DialogResult

        If Nz.Nz(dgPOReceivings.Item("AccpToPay", rowRecIndex).Value) = False And _
                dgPOReceivings.Rows(rowRecIndex).Selected = True Then
            reply = MsgBox("Do you want to delete the new receiving?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.Yes Then
                Try
                    dgPOReceivings.Rows.RemoveAt(rowRecIndex)
                    dgPOReceivings.Refresh()
                Catch ex As Exception
                End Try
            End If
        Else
            If Nz.Nz(dgPOReceivings.Item("PSlipQty", rowRecIndex).Value) = 0 And _
                dgPOReceivings.Rows(rowRecIndex).Selected = True Then
                reply = MsgBox("Do you want to delete the new receiving?", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then
                    Try
                        dgPOReceivings.Rows.RemoveAt(rowRecIndex)
                        dgPOReceivings.Refresh()
                    Catch ex As Exception
                    End Try
                   
                End If
            Else

                MsgBox("Action denied.")
            End If
        End If

        Call PopulatePOReceivings()

    End Sub

    Private Sub btnRecAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecAll.Click
        Dim flg As Boolean
        SwRecvInsp = True           'skip accepted for recv insp.

        'For Each drw As DataGridViewRow In dgPODetails.Rows
        For i As Integer = 0 To (dgPODetails.Rows.Count - 1)
            flg = False
            For Each trw As DataRow In myds.Tables("tblPOReceiving").Rows
                If trw.Item("PODetailID") = dgPODetails.Rows(i).Cells("PODetailID").Value And _
                    trw.Item("POItem") = dgPODetails.Rows(i).Cells("POItem").Value Then
                    flg = True
                    Exit For
                End If
            Next
            'have no receiving before
            If flg = False Then
                SetMyds(i, False)
            End If
        Next i

        Call PopulatePOReceivings()

        btnRecAll.Enabled = False
    End Sub

    Private Sub btnFindPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPO.Click
        EnableCtl()
        HideCtl()

        'PageReadOnly()
        txtPSlipNumber.Visible = False
        txtPONumber.Visible = True
        txtPONumber.Enabled = True
        txtPONumber.ReadOnly = False
        txtPONumber.Focus()

        FindPoflg = True

        dsAlusta.Clear()

    End Sub

    Private Sub frmPOReceiving_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim reply As DialogResult
        If myds.HasChanges Then
            reply = MsgBox("The change you made has not been saved to the database. Exit anyway?", MsgBoxStyle.YesNo)
            If reply = Windows.Forms.DialogResult.No Then e.Cancel = True
            Exit Sub
        End If

        myds.RejectChanges()
        myds.Dispose()
        dsAlusta.Dispose()
        Me.Dispose()

        GC.Collect()

    End Sub

    Private Sub dgPODetails_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPODetails.CellEnter
        rowPOIndex = e.RowIndex
    End Sub

    Private Sub dgPODetails_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPODetails.DataError
        REM end
    End Sub

    Private Sub dgPOReceivings_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgPOReceivings.DataError
        REM end
    End Sub

    Sub AlustaProcess()

        If cnSqlServer.State = ConnectionState.Open Then
            cnSqlServer.Close()
        End If

        dsAlusta.Clear()
        CallClass.PopulateDataAdapterAfterSearch("getPOUpload_IntoAlusta", txtPONumber.Text).Fill(dsAlusta, "tblSelect")

        Me.Refresh()

        If dgAlusta.RowCount <= 0 Then
            Exit Sub
        Else
            PutInfoAlusta()
        End If

    End Sub

    Sub PutInfoAlusta()

        For Each Row As DataGridViewRow In dgAlusta.Rows

            '  Header
            '=========
            Row.Cells("LACData").Value = Row.Cells("ENTPONo").Value + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTLAC").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTDOR").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTSUPP").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTDEVISE").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                          ' CODE TAXES

            Dim ENT_HT As Double = 0.0
            For Each Row11 As DataGridViewRow In dgAlusta.Rows
                ENT_HT = ENT_HT + CStr(CDbl(Row11.Cells("LINHT").Value).ToString("N3"))
            Next
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(ENT_HT).ToString("N3")) + ";"                                          ' ENT_HT


            'Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(((Row.Cells("I5StPrice").Value - Row.Cells("I5MpoRMCostCDN").Value) * 50 / 100) + Row.Cells("I5MpoRMCostCDN").Value).ToString("N4"))   'TRPR  (StockPrice-RM)*50+RM



            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                          ' ENT_TTC

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTRequester").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTBuyer").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTPOStatus").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("ENTPODate").Value) + ";"

            If IsDBNull(Row.Cells("ENTPOModDate").Value) = True Then
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"
            Else
                Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("ENTPOModDate").Value + ";"
            End If

            '====
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPONo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOType").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOItem").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINPOQty").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINPOUM").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINTotalPrice").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("LINTotPriceConf").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINHT").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINRemise").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINProdID").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINProdDescr").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINGLCode").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINEtablissement").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Row.Cells("LINCostCenter").Value + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           ' LIN_Famille

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINSUPP").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                           ' LIN_Commande

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("LINCapexNo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Row.Cells("LINCapexDescr").Value) + ";"

            ' 20 doc print & sent
            ' 50 good received
            ' 65 quality inspection completed
            ' 75 put-away completed

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("LINStatus").Value) + ";"

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + ";"                                        ' LIN_Solde


            '===
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + Trim(Row.Cells("RECPONo").Value) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECLine").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECNo").Value)).ToString + ";"


            Dim SwRecStatus As String = ""

            Select Case cmbPOType.Text

                Case "Raw Material"

                    If Nz.Nz(Row.Cells("ARecvMatlWeight").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("ARecvMatlWeight").Value).ToString("F3")) + ";"            ' matl inspected
                        SwRecStatus = "65"
                    Else
                        If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "50"
                        Else
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "20"
                        End If

                    End If

                Case "Processing", "Sub-Contracting", "Tooling", "Calibration/Testing"

                    If Nz.Nz(Row.Cells("ARecQtyAccp").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("ARecQtyAccp").Value).ToString("F3")) + ";"                ' processing received
                        SwRecStatus = "65"
                    Else
                        If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "50"
                        Else
                            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                    ' pslipqty
                            SwRecStatus = "20"
                        End If
                    End If

                Case Else

                    If Nz.Nz(Row.Cells("RECQty").Value) <> 0 Then
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                        'pslipqty
                        SwRecStatus = "50"
                    Else
                        Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECQty").Value).ToString("F3")) + ";"                        'pslipqty
                        SwRecStatus = "20"
                    End If

            End Select

            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(CDbl(Row.Cells("RECNET").Value).ToString("F3")) + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("ARECDate").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + CStr(Nz.Nz(Row.Cells("RECBarCode").Value)).ToString + ";"
            Row.Cells("LACData").Value = Row.Cells("LACData").Value + SwRecStatus

        Next



        FileNameStr = ""

        Dim SwDate As String
        Dim newDate As Date = Now.ToShortDateString

        SwDate = newDate.ToString("yyyyMMdd")

        FileNameStr = "LACPO_" + txtPONumber.Text + "_" + SwDate + "_" + Trim(Now.ToShortTimeString) + ".csv"
        FileNameStr = FileNameStr.Replace(":", " ")
        Dim TextFile As New IO.StreamWriter("\\SRV115FS01\LISI Alusta\" + FileNameStr)

        For Each Row As DataGridViewRow In dgAlusta.Rows
            TextFile.WriteLine(Row.Cells("LACData").Value)
        Next

        TextFile.Close()

        sSource = "\\SRV115FS01\LISI Alusta\" + FileNameStr
        sTarget = "\\dcxapt04\mvxfiletransfert\LAC ALUSTA DEV\" + FileNameStr

        File.Copy(sSource, sTarget, True)

        MsgBox("Alusta  -  successfully uploaded.")


    End Sub
End Class