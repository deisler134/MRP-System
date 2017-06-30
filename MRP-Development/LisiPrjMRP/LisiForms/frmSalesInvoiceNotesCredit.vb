Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class frmSalesInvoiceNotesCredit

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)

    Dim CallClass As New clsCommon

    Dim SwCall As String = ""
    Dim SwVal As Boolean = False
    Dim KeepNo As Integer = 0


    Private Sub frmSalesInvoiceNotesCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call SetUp()

    End Sub

    Sub SetUp()

        SwCall = ""

        txtRMA.Text = ""
        txtIR.Text = ""

        txtNotes.Text = ""

        txtRMA.ReadOnly = True
        txtIR.ReadOnly = True
        txtNotes.ReadOnly = True

        RdSales.Checked = False
        RdCustReturn.Checked = False
        RdIR.Checked = False

        CmdExec.Enabled = False
        RdSales.Enabled = True
        RdCustReturn.Enabled = True
        RdIR.Enabled = True

    End Sub

    Private Sub RdSales_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdSales.CheckedChanged

        CmdExec.Enabled = True
        If RdSales.Checked = True Then
            SwCall = "SALES"
            txtNotes.ReadOnly = False
            txtRMA.Text = ""
            txtIR.Text = ""
            txtRMA.ReadOnly = True
            txtIR.ReadOnly = True
        End If

    End Sub

    Private Sub RdCustReturn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdCustReturn.CheckedChanged

        CmdExec.Enabled = True

        If RdCustReturn.Checked = True Then
            SwCall = "RMA"

            txtRMA.ReadOnly = False
            txtIR.ReadOnly = True

            txtRMA.Text = ""
            txtIR.Text = ""

            txtNotes.ReadOnly = False
        End If

    End Sub

    Private Sub RdIR_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdIR.CheckedChanged
        CmdExec.Enabled = True
       
        If RdIR.Checked = True Then
            SwCall = "IR"

            txtRMA.ReadOnly = True
            txtIR.ReadOnly = False

            txtRMA.Text = ""
            txtIR.Text = ""

            txtNotes.ReadOnly = False

        End If

    End Sub

    Private Sub CmdExec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExec.Click

        Call VallFunction()

        If SwVal = True Then

            frmSalesInvoice.txtInvNotes.Text = frmSalesInvoice.txtInvNotes.Text + vbCrLf + txtNotes.Text

            If txtQty.Text <= 0 Then
                frmSalesInvoice.txtPSlipQty.Text = txtQty.Text
            Else
                frmSalesInvoice.txtPSlipQty.Text = txtQty.Text * -1
            End If

            frmSalesInvoice.SwTRText.Text = SwCall
            If SwCall = "SALES" Then

                frmSalesInvoice.SwTrNo.Text = ""

                Dim reply As DialogResult
                reply = MsgBox("Do you want to send an email to LAC Shipment Department ? ", MsgBoxStyle.YesNo)
                If reply = Windows.Forms.DialogResult.Yes Then

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
                    'NotesDoc.Subject = " LAC - Sales Credit"
                    'strBody = "CREDIT Transaction " + vbCrLf
                    'strBody = strBody + "==================" + vbCrLf
                    'strBody = strBody + "Please note that a Credit was issued on the MPO No: " + CmbMPO.Text + vbCrLf
                    'strBody = strBody + "Quantity: " + txtQty.Text

                    'NotesDoc.body = strBody
                    'Call NotesDoc.SEND(False, "expedition.montreal@lisi-aerospace.com")

                    Dim email As New Mail.MailMessage()
                    Dim strBody As String = ""
                    email.Subject = " LAC - Sales Credit"
                    strBody = "CREDIT Transaction " + vbCrLf
                    strBody = strBody + "==================" + vbCrLf
                    strBody = strBody + "Please note that a Credit was issued on the MPO No: " + CmbMPO.Text + vbCrLf
                    strBody = strBody + "Quantity: " + txtQty.Text
                    email.Body = strBody

                    Dim client As New Mail.SmtpClient(wkSMTPAddress, wkSMTPPort)
                    email.From = New Net.Mail.MailAddress(wkEmpEmail)
                    email.To.Add(New Mail.MailAddress("expedition.montreal@lisi-aerospace.com"))
                    client.Send(email)

                End If
            Else
                If SwCall = "RMA" Then
                    frmSalesInvoice.SwTrNo.Text = txtRMA.Text
                Else
                    frmSalesInvoice.SwTrNo.Text = txtIR.Text
                End If
            End If

            Me.Close()
        Else
            MsgBox("!!! ERROR !!! Credit module. Action Denied.")
            frmSalesInvoice.CmdSave.Enabled = False
            Me.Close()
        End If

    End Sub

    Sub VallFunction()

        SwVal = False
        Dim GetInfo As String = ""

        If SwCall = "" Or Len(Trim(SwCall)) = 0 Then
            MsgBox("You need to identify the Credit Type. Action Denied.")
            SwVal = False
            Exit Sub
        End If

        If RdCustReturn.Checked = True Then
            If Len(Trim(txtRMA.Text)) = 0 Then
                MsgBox("!!! ERROR !!! RMA number is empty.")
                SwVal = False
                Exit Sub
            Else
                GetInfo = CallClass.ReturnStrWith2ParStr("cspReturnMPORmaIR", txtRMA.Text, "RMA")
                If GetInfo <> "False" Then
                    MsgBox("!!! ERROR !!! The RMA number exist already in SQL MPO Master table?")
                    SwVal = False
                    Exit Sub
                End If
            End If
        End If

        If RdIR.Checked = True Then
            If Len(Trim(txtIR.Text)) = 0 Then
                MsgBox("!!! ERROR !!! IR number is empty.")
                SwVal = False
                Exit Sub
            Else
                GetInfo = CallClass.ReturnStrWith2ParStr("cspReturnMPORmaIR", txtIR.Text, "IR")
                If GetInfo <> "False" Then
                    MsgBox("!!! ERROR !!! The IR number exist already in SQL MPO Master table?")
                    SwVal = False
                    Exit Sub
                End If
            End If
        End If


        Dim QtyCRD As String

        QtyCRD = CallClass.TakeFinalSt("cspReturnTotalQtyCredit", txtInv.Text)
        If QtyCRD = "False" Then
            'skip
        Else
            Dim Swqty As String = 0
            Swqty = frmSalesInvoice.txtPSlipQty.Text
            If Swqty < 0 Then
                Swqty = Swqty * -1
            End If

            Dim Totqty As String = 0

            If QtyCRD < 0 Then
                QtyCRD = QtyCRD * -1
            End If
            If txtQty.Text < 0 Then
                txtQty.Text = txtQty.Text * -1
            End If
            Totqty = Val(QtyCRD) + Val(txtQty.Text)
            If Val(Totqty) > Val(Swqty) Then
                MsgBox("!!! ERROR !!! Total Credit quantity is > as the quantity from the original invoice:  " + txtInv.Text + "")
                SwVal = False
                Exit Sub
            End If
        End If

        SwVal = True

    End Sub

    Private Sub txtRMA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRMA.Validating
        txtNotes.Text = txtNotes.Text + vbCrLf + "RMA: " + txtRMA.Text
    End Sub

    Private Sub txtIR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIR.Validating
        txtNotes.Text = txtNotes.Text + vbCrLf + "IR: " + txtIR.Text
    End Sub
End Class