Public Class DetalleObservaciones1
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 5
    Dim idCliente As Integer = 0

    Dim HTML As String = ""

    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        idCliente = Request.QueryString("idCliente")

        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            If Page.IsPostBack Then

            Else
                Dim Datos = BL.Obtener_ClienteObservaciones(idCliente)
                If Not Page.IsPostBack Then
                    For i As Integer = 0 To Datos.Length - 1
                        HTML += "<label><strong><em> Observación - " & Datos(i).Fecha_Registro & "</em></strong></label><br>
                                 <p>" & Datos(i).Observacion & "</p><br>"
                    Next

                    lbl_Observaciones.Text = HTML
                End If
            End If
        End If
    End Sub
#Region "Metodos"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    Session("Usuario") = Usuario
                Else
                    Session("Usuario") = Usuario
                    RedirigirSegunNivel(Usuario.Nivel)
                End If
            Else
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)

            End If
        Else
            Session.Clear()
            Response.Redirect("../Account/LogOn.aspx")
        End If
    End Sub
    Sub RedirigirSegunNivel(ByVal Nivel As Integer)
        Select Case Nivel
            Case 1
                Response.Redirect("~/Usuario/InicioUsuario.aspx", False)
            Case 2
                Response.Redirect("~/Supervisor/InicioSupervisor.aspx", False)
            Case 3
                Response.Redirect("~/Administrativo/InicioAdmin.aspx", False)
            Case 4
                Response.Redirect("~/Callcenter/InicioCCenter.aspx", False)
            Case 5
                Response.Redirect("~/Caseta/InicioCaseta.aspx", False)
        End Select
    End Sub
#End Region
End Class