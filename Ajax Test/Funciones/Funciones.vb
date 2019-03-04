Imports System.IO

Public Class Funciones
    Private GE_SQL As New SQL_Functions

#Region "Estructuras"
    Public Structure BusquedaCliente
        Dim nombreCliente As String
        Dim apellidoMaterno As String
        Dim apellidoPaterno As String
        Dim RFC As String
        Dim CURP As String
        Dim NSS As String
        Dim IdCliente As String
        Dim Numcte As String
    End Structure
#End Region

#Region "Archivos"
    Public Sub EliminarArchivos(ByVal Archivos() As String)
        Try
            For i As Integer = 0 To Archivos.Length - 1
                File.Delete(Archivos(i))
            Next i
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Consultas"
    Public Function Comprobar_OperacionConsulta(ByVal Consulta As String) As Boolean
        Dim Existe As Boolean
        Dim Verbos() As String = {"UPDATE", "DELETE", "INSERT", "DROP", "TRUNCATE"}

        For i As Integer = 0 To Verbos.Length - 1
            If Consulta.ToUpper.Contains(Verbos(i)) Then
                Existe = True
                Exit For
            End If
        Next

        Return Existe
    End Function

    Public Function ObtenerDatosConsulta(ByVal Query As String) As List(Of DatosConsulta)
        Dim Datos As New List(Of DatosConsulta)
        Dim Aux As DatosConsulta

        Try
            Aux = New DatosConsulta
            Aux.DT = GE_SQL.SQLGetTable(Query)
            Aux.Resultado = "Success"

            Datos.Add(Aux)
        Catch ex As Exception
            Aux = New DatosConsulta
            Aux.DT = Nothing
            Aux.Resultado = ex.Message.ToString

            Datos.Add(Aux)
        End Try

        Return Datos
    End Function

    Public Function BuscarClientes(ByVal Cliente As BusquedaCliente) As DataTable
        Dim Query As String = "EXEC [dbo].[BuscarClientes]
		                            @Nombre = N'" & Cliente.nombreCliente & "',
		                            @ApellidoPaterno = N'" & Cliente.apellidoPaterno & "',
		                            @ApellidoMaterno = N'" & Cliente.apellidoMaterno & "',
		                            @rfcCliente = N'" & Cliente.RFC & "',
		                            @curpCliente = N'" & Cliente.CURP & "',
		                            @nssCliente = N'" & Cliente.NSS & "',
                                    @IdCrm = N'" & Cliente.IdCliente & "',
	                                @NumCliente = N'" & Cliente.Numcte & "'"

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim ROWB As DataRow

        DTB.Columns.AddRange({New DataColumn("ID", GetType(Integer)), New DataColumn("Cliente", GetType(String)), New DataColumn("Asesor", GetType(String)),
                              New DataColumn("CallCenter", GetType(String)), New DataColumn("Ranking", GetType(String)), New DataColumn("Nacimiento", GetType(Date)),
                              New DataColumn("RFC", GetType(String)), New DataColumn("CURP", GetType(String)), New DataColumn("NSS", GetType(String))})

        DTA = GE_SQL.SQLGetTable(Query)
        If DTA.Rows.Count > 0 Then
            For Each rowA As DataRow In DTA.Rows
                ROWB = DTB.NewRow
                ROWB("ID") = rowA("ID")
                ROWB("Cliente") = rowA("Cliente")

                If IsDBNull(rowA("Asesor")) Then
                    ROWB("Asesor") = "-"
                Else
                    ROWB("Asesor") = rowA("Asesor")
                End If

                If IsDBNull(rowA("CallCenter")) Then
                    ROWB("CallCenter") = "-"
                Else
                    ROWB("CallCenter") = rowA("CallCenter")
                End If

                ROWB("Ranking") = rowA("Ranking")
                ROWB("Nacimiento") = rowA("Nacimiento")
                ROWB("RFC") = rowA("RFC")
                ROWB("CURP") = rowA("CURP")
                ROWB("NSS") = rowA("NSS")

                DTB.Rows.Add(ROWB)
            Next
        End If

        BuscarClientes = DTB
    End Function
#End Region

#Region "Citas"
    Public Function ObtenerCampanas() As DataTable
        Dim Query As String = "SELECT id_campaña, campañaNombre
                               FROM campañas"

        ObtenerCampanas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerTipoCampana(ByVal IdCampana As Integer) As String
        Dim Query As String = String.Format("SELECT tipocampaña
                                             FROM campañas CP
                                             INNER JOIN tipocampaña TP ON TP.id_tipoCampaña = CP.id_tipoCampaña
                                             WHERE CP.id_campaña = {0}", IdCampana)

        ObtenerTipoCampana = GE_SQL.SQLGetDataStr(Query)
    End Function
#End Region
End Class
