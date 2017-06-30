Module LisiModule

    Public wkPassword As String
    Public wkAccess As Integer
    Public wkName As String
    Public wkEmpId As Integer
    Public wkEmpLogin As String
    Public wkDeptCode As String
    Public wkEmpDept As String
    Public wkEmpEmail As String

    Public wkSMTPAddress As String = "172.20.33.72"
    Public wkSMTPPort As Integer = 25

    Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer

    Public printDoc As New Printing.PrintDocument

    Public Property ShrinkToFit As Boolean

    'MultipleActiveResultSets=True   sql 2005



    'Public Const strConnection = "Initial Catalog=LisiMRPData;Data Source=172.21.71.19;Integrated Security=SSPI;Persist Security Info=False;packet size=4096;timeout=45; MultipleActiveResultSets=True"
    '   old one Public Const strConnection = "Initial catalog=LisiMRPData; Data Source=172.21.71.10; Connect Timeout=180; Integrated Security=SSPI; persist security info=False; Trusted_Connection=True; Packet Size=4096;"

    'SQL 2000
    'Public Const strConnection = "Data Source=172.21.71.10; Initial catalog=LisiMRPData; Integrated Security=SSPI; Connect Timeout=15; persist security info=False; Trusted_Connection=true; Packet Size=4096"


    'SQL 2012
    Public Const strConnection = "Data Source=172.21.71.8; Initial catalog=SQLMRPDevelopment; Integrated Security=SSPI; Connect Timeout=15; persist security info=False; Trusted_Connection=true; Packet Size=4096"
    'Public Const strConnection = "Data Source=DORAPZ01\MSSQLSERVER_12; Initial catalog=LisiMRPData_12; Integrated Security=SSPI; Connect Timeout=30; persist security info=False; Trusted_Connection=true; Packet Size=4096"


    ' Public Const strADO = "Provider=sqlOLEDB.1;Data Source=172.21.71.10;Initial Catalog=LisiMRPData;integrated security=SSPI; persist security info=False"
    'Public Const strADO = "Provider=sqlOLEDB.1;Data Source=172.21.71.19;Initial Catalog=LisiMRPData;integrated security=SSPI; persist security info=False; MultipleActiveResultSets=True"



    'integrated security=SSPI;persist security info=False;
End Module
