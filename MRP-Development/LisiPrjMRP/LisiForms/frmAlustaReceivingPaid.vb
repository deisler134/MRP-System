Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmAlustaReceivingPaid

    Inherits System.Windows.Forms.Form
    Dim cn As New SqlConnection(strConnection)
    Dim CallClass As New clsCommon

    Private Declare Function URLDownloadToFile Lib "urlmon" Alias "URLDownloadToFileA" (ByVal pCaller As Long, ByVal szURL As String, ByVal szFileName As String, ByVal dwReserved As Long, ByVal lpfnCB As Long) As Long

    Private Sub frmAlustaReceivingPaid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim wc As New Net.WebClient
        wc.UseDefaultCredentials = True
        wc.Credentials = New Net.NetworkCredential("ABC", "AJ77A")
        wc.DownloadFile("fddfddddddddhttp://samplewebsite.com/webclients/sample/SAMPLE.CSV", "C:\FOLDER")

    End Sub

 
    'Function downloadWeatherData(location As String)
    '    Dim done
    '    Dim myLink As String
    '    Dim locationNum As String

    '    Select Case location
    '        Case "AK - BARROW W POST-W ROGERS ARPT [NSA - ARM]"
    '            locationNum = "723230"
    '    End Select
    '    myLink = "fffffffhttp://rredc.nrel.gov/solar/old_data/nsrdb/1991-2005/data/tmy3/" & locationNum & "TY.csv"

    '    done = URLDownloadToFile(0, "myLink", "C:\Users\***myname****\Documents\DownloadTest", 0, 0)

    '    'Test.
    '    If done = 0 Then
    '        MsgBox "File has been downloaded!"
    '    Else
    '        MsgBox "File not found!"
    '    End If

    'End Function

    'Function transfercsv(location As String)
    '    Dim sCSVLink As String
    '    Dim sfile As String
    '    Dim locationNum As String
    '    Dim wnd

    '    Select Case location
    '        Case "AK - BARROW W POST-W ROGERS ARPT [NSA - ARM]"
    '            locationNum = "723230"
    '    End Select
    '    sCSVLink = "http://rredc.nrel.gov/solar/old_data/nsrdb/1991-2005/data/tmy3/" & locationNum & "TY.csv"

    '    sfile = locationNum & "TY.csv"

    '    wnd = ActiveWindow
    '    Application.ScreenUpdating = False
    '    Sheets("CSV Transfer").Cells.ClearContents()
    '    Workbooks.Open Filename:=sCSVLink
    '    'Windows(sfile).Activate
    '    ActiveSheet.Cells.Copy()
    '    wnd.Activate()
    '    Workbooks("SpreadsheetDraft").Sheets("CSV Transfer").Range("A1").Select()
    '    Workbooks("SpreadsheetDraft").Sheets("CSV Transfer").Paste()
    '    Application.DisplayAlerts = False
    '    Windows(sfile).Close False
    '    Application.DisplayAlerts = True
    '    Application.ScreenUpdating = True
    'End Function

End Class