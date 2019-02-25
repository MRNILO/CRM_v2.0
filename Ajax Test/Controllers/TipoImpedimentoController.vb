Imports System.Data.SqlClient
Imports System.Net
Imports System.Web.Http

Namespace Usuario
    Public Class TipoImpedimentoController
        Inherits ApiController

        Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("crm_roest3ConnectionString").ToString)
        ' GET: api/TipoImpedimento
        Public Function GetValues() As List(Of CTipoImpedimentos)

            Dim Result As New List(Of CTipoImpedimentos)
            Dim aux As CTipoImpedimentos
            Dim cmd As New SqlCommand("SELECT * FROM TipoImpedimento", conexion)

            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
            End If

            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader

            While reader.Read
                aux = New CTipoImpedimentos
                aux.id_tipoImpedimento = reader.Item("id_tipoImpedimento")
                aux.TipoImpedimento = reader.Item("TipoImpedimento")
                Result.Add(aux)
            End While


            Return Result
        End Function

        ' GET: api/RankingCitas/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/RankingCitas
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/RankingCitas/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/RankingCitas/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
        Class CTipoImpedimentos
            Property id_tipoImpedimento As Integer = 0
            Property TipoImpedimento As String = ""
        End Class
    End Class
End Namespace