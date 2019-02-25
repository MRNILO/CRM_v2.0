Imports System.Web.Services

Public Class inbox
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Try
            If Page.IsPostBack Then
            Else
                Session("EmailsUsuario") = BL.Obtener_emailsUsuario(Usuario.Email)
                Session("EmailEnviados") = BL.Obtener_enviadosUsuario(Usuario.Email)
            End If
        Catch ex As Exception

        End Try

        GV_enviados.DataSource = Session("EmailEnviados")
        GV_enviados.DataBind()

        GV_Recibidos.DataSource = Session("EmailsUsuario")
        GV_Recibidos.DataBind()
    End Sub
    <WebMethod()>
    Public Shared Function Correo(ByVal idEmail As String) As String
        Return BL.Obtener_mensajeEmailID(idEmail)
    End Function
#Region "FuncionesUsuario"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then


                    Session("Usuario") = Usuario


                    'Response.Redirect("~/", False)
                Else
                    Session("Usuario") = Usuario
                    RedirigirSegunNivel(Usuario.Nivel)
                End If
            Else
                'No valido
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)
                'lbl_error.Text = MostrarError("Usuario o/y contraseña equivocados")
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
        End Select
    End Sub



#End Region
End Class