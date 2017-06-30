Public Module Nz
    Function Nz(ByVal Expression, Optional ByVal ValueIfNull = Nothing)
        ' returns ValueIfNull if Expression is null or nothing,
        ' returns zero if Expression is null or nothing and ValueIfNull is nothing
        ' else returns Expression
        '==============================================================
        'example:
        '    Dim Category As String = Nz(myDataRow("cat"), "")
        '==============================================================

        If Not IsNothing(ValueIfNull) Then
            If IsNothing(Expression) OrElse IsDBNull(Expression) Then
                Return ValueIfNull
            End If
        Else
            If IsNothing(Expression) OrElse IsDBNull(Expression) Then
                Return 0
            End If
        End If

        Return Expression
    End Function
End Module
