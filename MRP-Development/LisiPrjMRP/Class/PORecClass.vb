Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class PORecClass

    Private cn As New SqlConnection(strConnection)
    Private daPORec As SqlDataAdapter
    Private cmdSelPORec As SqlCommand
    Private cmdInsPORec As SqlCommand
    Private cmdUpdPORec As SqlCommand
    Private cmdDelPORec As SqlCommand

    Private dsPORec As DataSet

    Public Function GetPODetAd() As SqlDataAdapter

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetDet"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec


        Return daPORec

    End Function

    Public Function GetPODetailAd(ByVal poNum As String) As SqlDataAdapter

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetDetails"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        parameterPoNum.Value = poNum
        daPORec.SelectCommand.Parameters.Add(parameterPoNum)

        Return daPORec

    End Function

    Public Function GetPOData(ByVal poNum As String) As DataSet

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetDetails"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        parameterPoNum.Value = poNum
        daPORec.SelectCommand.Parameters.Add(parameterPoNum)

        ' Create and Fill the DataSet
        dsPORec = New DataSet()
        Try
            daPORec.Fill(dsPORec, "tblPODetails")
        Catch ex As Exception
            MsgBox("Load POData: " & ex.Message)
        End Try

        Return dsPORec

    End Function

    Public Function GetPOMasData(ByVal poNum As String) As DataSet

        ' Create Instance of Connection and Command Object
        Dim myConnection As SqlConnection = New SqlConnection(strConnection)
        Dim myCommand As SqlDataAdapter = New SqlDataAdapter("poRecGetMasData", myConnection)

        ' Mark the Command as a SPROC
        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim paraPoNum As SqlParameter = New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        paraPoNum.Value = poNum
        myCommand.SelectCommand.Parameters.Add(paraPoNum)

        ' Create and Fill the DataSet
        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblPOMasData")
        Catch ex As Exception
            MsgBox("Load POData: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOAllRec(ByVal poNum As String) As DataSet

        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetAllRec", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        parameterPoNum.Value = poNum
        myCommand.SelectCommand.Parameters.Add(parameterPoNum)

        ' Create and Fill the DataSet
        Dim ds As New DataSet()
        Try
            'myCommand.Fill(ds, "tblPORecDetails")
            myCommand.Fill(ds, "tblPoReceiving")
        Catch ex As Exception
            MsgBox("Load POData: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPORecAd() As SqlDataAdapter

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetRec"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec

        Return daPORec

    End Function

    Public Function GetPOReceivingAd(ByVal poNum As String, ByVal poItem As Integer) As SqlDataAdapter

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetReceiving"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec


        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        parameterPoNum.Value = poNum
        daPORec.SelectCommand.Parameters.Add(parameterPoNum)

        Dim parameterPoItem As New SqlParameter("@PoItem", SqlDbType.Int, 4)
        parameterPoItem.Value = poItem
        daPORec.SelectCommand.Parameters.Add(parameterPoItem)

        Return daPORec

    End Function

    Public Function GetPORecData(ByVal poNum As String, ByVal poItem As Integer) As DataSet

        cmdSelPORec = New SqlCommand()
        cmdSelPORec.Connection = cn
        cmdSelPORec.CommandType = CommandType.StoredProcedure
        cmdSelPORec.CommandText = "poRecGetReceiving"

        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.SelectCommand = cmdSelPORec


        ' Add Parameters to SPROC
        Dim parameterPoNum As New SqlParameter("@PoNum", SqlDbType.NVarChar, 10)
        parameterPoNum.Value = poNum
        daPORec.SelectCommand.Parameters.Add(parameterPoNum)

        Dim parameterPoItem As New SqlParameter("@PoItem", SqlDbType.Int, 4)
        parameterPoItem.Value = poItem
        daPORec.SelectCommand.Parameters.Add(parameterPoItem)

        dsPORec = New DataSet()
        Try
            'daPORec.Fill(dsPORec, "tblPORecDetails")
            daPORec.Fill(dsPORec, "tblPOReceiving")
        Catch ex As Exception
            MsgBox("Load RecDetails: " & ex.Message)
        End Try

        Return dsPORec

    End Function

    Public Function GetMpoNo() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("cmbGetMpoMasterAll", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblMpoMaster")
        Catch ex As Exception
            MsgBox("Load MpoNo: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOUM() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetUM", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblUM")
        Catch ex As Exception
            MsgBox("Load POUM: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOProd() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetProd", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblProdDesc")
        Catch ex As Exception
            MsgBox("Load POProd: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOSupplier() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetSupplier", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblSupplier")
        Catch ex As Exception
            MsgBox("Load Supplier: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOBuyer() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetBuyer", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblBuyer")
        Catch ex As Exception
            MsgBox("Load POBuger: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function GetPOStatus() As DataSet
        Dim myConnection As New SqlConnection(strConnection)
        Dim myCommand As New SqlDataAdapter("poRecGetPOStatus", myConnection)

        myCommand.SelectCommand.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet()
        Try
            myCommand.Fill(ds, "tblPOStatus")
        Catch ex As Exception
            MsgBox("Load POStatus: " & ex.Message)
        End Try

        Return ds

    End Function

    Public Function AddPORec(ByVal poDetailID As Integer, _
                        ByVal recDate As Date, _
                        ByVal pslipDate As Date, _
                        ByVal pslipNum As String, _
                        ByVal pslipUM As String, _
                        ByVal pslipPrice As Single, _
                        ByVal pslipDiscount As Single, _
                        ByVal pslipQty As Single, _
                        ByVal AccpToPay As Boolean, _
                        ByVal AlustaBarCode As String, _
                        ByVal payed As Boolean) As Boolean


        ' Create Instance of Connection and Command Object
        Dim myConnection As SqlConnection = New SqlConnection(strConnection)
        Dim myCommand As SqlCommand = New SqlCommand("poRecAdd", myConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim paraPODetailID As SqlParameter = New SqlParameter("@PODetailID", SqlDbType.Int, 4)
        paraPODetailID.Value = poDetailID
        myCommand.Parameters.Add(paraPODetailID)

        Dim paraRecDate As SqlParameter = New SqlParameter("@RecDate", SqlDbType.SmallDateTime, 4)
        paraRecDate.Value = recDate
        myCommand.Parameters.Add(paraRecDate)

        Dim paraPSlipDate As SqlParameter = New SqlParameter("@PSlipDate", SqlDbType.SmallDateTime, 4)
        paraPSlipDate.Value = pslipDate
        myCommand.Parameters.Add(paraPSlipDate)

        Dim paraPSlipNum As SqlParameter = New SqlParameter("@PSlipNum", SqlDbType.NVarChar, 25)
        paraPSlipNum.Value = pslipNum
        myCommand.Parameters.Add(paraPSlipNum)

        Dim paraPSlipUM As SqlParameter = New SqlParameter("@PSlipUM", SqlDbType.NVarChar, 25)
        paraPSlipUM.Value = pslipUM
        myCommand.Parameters.Add(paraPSlipUM)

        Dim paraPSlipPrice As SqlParameter = New SqlParameter("@PSlipPrice", SqlDbType.Float, 8)
        paraPSlipPrice.Value = pslipPrice
        myCommand.Parameters.Add(paraPSlipPrice)

        Dim paraPSlipDiscount As SqlParameter = New SqlParameter("@PSlipDiscount", SqlDbType.Float, 8)
        paraPSlipDiscount.Value = pslipDiscount
        myCommand.Parameters.Add(paraPSlipDiscount)

        Dim paraPSlipQty As SqlParameter = New SqlParameter("@PSlipQty", SqlDbType.Float, 8)
        paraPSlipQty.Value = pslipQty
        myCommand.Parameters.Add(paraPSlipQty)

        Dim paraAccPay As SqlParameter = New SqlParameter("@AccpToPay", SqlDbType.Bit, 1)
        paraAccPay.Value = AccpToPay
        myCommand.Parameters.Add(paraAccPay)

        Dim paraAlusta As SqlParameter = New SqlParameter("@AlustaBarCode", SqlDbType.NVarChar, 25)
        paraAlusta.Value = AlustaBarCode
        myCommand.Parameters.Add(paraAlusta)

        Dim paraPayed As SqlParameter = New SqlParameter("@Payed", SqlDbType.Bit, 1)
        paraPayed.Value = payed
        myCommand.Parameters.Add(paraPayed)

        ' Open the connection and execute the Command
        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If
            myCommand.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add PORec: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
            Return False

        Finally

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

        End Try

        Return True

    End Function

    Public Sub UpdatePORec(ByVal dsChanges As DataSet)

        cmdInsPORec = New SqlCommand()
        cmdInsPORec.Connection = cn
        cmdInsPORec.CommandType = CommandType.StoredProcedure
        cmdInsPORec.CommandText = "poRecAdd"

        cmdUpdPORec = New SqlCommand()
        cmdUpdPORec.Connection = cn
        cmdUpdPORec.CommandType = CommandType.StoredProcedure
        cmdUpdPORec.CommandText = "poRecUpdate"

        cmdDelPORec = New SqlCommand()
        cmdDelPORec.Connection = cn
        cmdDelPORec.CommandType = CommandType.StoredProcedure
        cmdDelPORec.CommandText = "poRecDelete"

        ' Add Parameters to insert SPROC
        cmdInsPORec.Parameters.Add("@PODetailID", SqlDbType.Int, 4, "PODetailID")
        cmdInsPORec.Parameters.Add("@RecDate", SqlDbType.SmallDateTime, 4, "RecDate")
        cmdInsPORec.Parameters.Add("@PSlipDate", SqlDbType.SmallDateTime, 4, "PSlipDate")
        cmdInsPORec.Parameters.Add("@PslipMpoID", SqlDbType.Int, 4, "PslipMpoID")
        cmdInsPORec.Parameters.Add("@PSlipNum", SqlDbType.NVarChar, 25, "PSlipNum")
        cmdInsPORec.Parameters.Add("@PSlipUM", SqlDbType.NVarChar, 25, "PSlipUM")
        cmdInsPORec.Parameters.Add("@PSlipPrice", SqlDbType.Float, 8, "PSlipPrice")
        cmdInsPORec.Parameters.Add("@PSlipDiscount", SqlDbType.Float, 8, "PSlipDiscount")
        cmdInsPORec.Parameters.Add("@PSlipQty", SqlDbType.Float, 8, "PSlipQty")
        cmdInsPORec.Parameters.Add("@AccpToPay", SqlDbType.Bit, 1, "AccpToPay")
        cmdInsPORec.Parameters.Add("@AlustaBarCode", SqlDbType.NVarChar, 25, "AlustaBarCode")
        'cmdInsPORec.Parameters.Add("@Payed", SqlDbType.Bit, 1, "Payed")

        ' Add Parameters to update sproc
        cmdUpdPORec.Parameters.Add("@PORecvID", SqlDbType.Int, 4, "PORecvID")
        cmdUpdPORec.Parameters.Add("@PslipMpoID", SqlDbType.Int, 4, "PslipMpoID")
        cmdUpdPORec.Parameters.Add("@AccpToPay", SqlDbType.Bit, 1, "AccpToPay")
        cmdUpdPORec.Parameters.Add("@PSlipQty", SqlDbType.Float, 8, "PSlipQty")
        cmdUpdPORec.Parameters.Add("@PSlipPrice", SqlDbType.Float, 8, "PSlipPrice")
        ' aug 17, 2016
        cmdUpdPORec.Parameters.Add("@PSlipDate", SqlDbType.SmallDateTime, 4, "PSlipDate")
        cmdUpdPORec.Parameters.Add("@PSlipNum", SqlDbType.NVarChar, 25, "PSlipNum")
        cmdUpdPORec.Parameters.Add("@AlustaBarCode", SqlDbType.NVarChar, 25, "AlustaBarCode")


        ' Add Parameters to delete sproc
        cmdDelPORec.Parameters.Add("@PORecvID", SqlDbType.Int, 4, "PORecvID")


        'DataApapter
        daPORec = New SqlDataAdapter()
        daPORec.InsertCommand = cmdInsPORec
        daPORec.UpdateCommand = cmdUpdPORec
        daPORec.DeleteCommand = cmdDelPORec
        daPORec.TableMappings.Add("Table", "tblPOReceiving")

        daPORec.Update(dsChanges)

    End Sub

    Public Function UpdatePOMas(ByVal poNum As String) As Boolean

        ' Create Instance of Connection and Command Object
        Dim myConnection As SqlConnection = New SqlConnection(strConnection)
        Dim myCommand As SqlCommand = New SqlCommand("poRecUpdMas", myConnection)

        ' Mark the Command as a SPROC
        myCommand.CommandType = CommandType.StoredProcedure

        ' Add Parameters to SPROC
        Dim paraPONum As SqlParameter = New SqlParameter("@PoNum", SqlDbType.NVarChar, 25)
        paraPONum.Value = poNum
        myCommand.Parameters.Add(paraPONum)

        ' Open the connection and execute the Command
        Try

            If myConnection.State = ConnectionState.Closed Then
                myConnection.Open()
            End If

            myCommand.ExecuteNonQuery()

        Catch ex As SqlException
            MsgBox("Add Receiving: " & ex.Message)
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            Return False

        Finally

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

        End Try
        Return True
    End Function

End Class
