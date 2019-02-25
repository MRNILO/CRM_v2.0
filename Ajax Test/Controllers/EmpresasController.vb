Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Results
Imports Newtonsoft.Json

Namespace Usuario
    Public Class EmpresasController
        Inherits ApiController

        ' GET: api/Empresas
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/Empresas/5
        Public Function GetValue(ByVal Query As String) As JsonResult(Of Servicio.CComboEmpresas())
            Dim Empresas = BL.Obtener_empresasComboBusqueda(Query)
            Return Json(Empresas)
        End Function

        ' POST: api/Empresas
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Empresas/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Empresas/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace