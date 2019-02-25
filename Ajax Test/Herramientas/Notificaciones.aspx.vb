Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Public Class Notificaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        Dim Usuarios = GV_Usuarios.GetSelectedFieldValues("id_usuario")
        For I = 0 To Usuarios.Count - 1
            EnviarNotificacion(Usuarios(I), tb_titulo.Text, tb_Mensaje.Text)
        Next
        lbl_mensaje.Text = "Notificaciones enviadas"
    End Sub
    Function EnviarNotificacion(ByVal id_usuario As Integer, ByVal titulo As String, ByVal Mensaje As String) As Boolean
        Dim Enviar As New Data

        Enviar.id_usuario = id_usuario
        Enviar.Titulo = titulo
        Enviar.Mensaje = Mensaje
        Dim JsonRS = New JavaScriptSerializer().Serialize(Enviar)
        Dim request = WebRequest.Create("http://altaircloud.mx/apiEdificasa/api/Notificaciones")

        request.Method = "POST"
        request.ContentType = "application/json"

        Dim SW = New StreamWriter(request.GetRequestStream())

        SW.Write(JsonRS)
        SW.Dispose()
        SW.Close()

        Dim HttpResponse = request.GetResponse()
        Dim streamReader = New StreamReader(HttpResponse.GetResponseStream())

        Dim result = streamReader.ReadToEnd()


    End Function
    Public Class Data
        Public Property id_usuario As Integer
        Public Property Titulo As String
        Public Property Mensaje As String

    End Class

End Class