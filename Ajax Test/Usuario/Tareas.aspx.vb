Imports System.Web.Services

Public Class Tareas
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Page.IsPostBack Then
        Else
            GV_TareasPendientes.DataBind()
            GV_TareasTerminadas.DataBind()
        End If

    End Sub
    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        If BL.TerminarTarea(valor) Then
            Return "Exito"
        Else
            Return "No"
        End If
    End Function
    Protected Sub GV_TareasPendientes_DataBinding(sender As Object, e As EventArgs) Handles GV_TareasPendientes.DataBinding
        GV_TareasPendientes.DataSource = BL.Obtener_tareasPendientesUsuario(Usuario.id_usuario)
    End Sub

    Protected Sub GV_TareasTerminadas_DataBinding(sender As Object, e As EventArgs) Handles GV_TareasTerminadas.DataBinding
        GV_TareasTerminadas.DataSource = BL.Obtener_tareasTerminadasUsuario(Usuario.id_usuario)
    End Sub

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