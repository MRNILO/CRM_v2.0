Imports System.IO

Public Class Funciones
    Private GE_SQL As New SQL_Functions

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
#End Region
End Class
