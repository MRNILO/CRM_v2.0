Public Class Usuario1
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idUsuario As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()



        Try
            idUsuario = Request.QueryString("idUsuario")
        Catch ex As Exception
            idUsuario = 0
        End Try

        If idUsuario = 0 Then
            Response.Redirect("/", False)
        End If

        'Estadisticas
        Dim Estadisticas = BL.Obtener_totalesUsuario(idUsuario)

        lbl_ClientesActivos.Text = Estadisticas.ClientesActivos.ToString
        lbl_ClientesCancelados.Text = Estadisticas.ClientesCancelados.ToString
        lbl_clientesTotal.Text = Estadisticas.ClientesTotal.ToString
        lbl_ProspectosSemana.Text = Estadisticas.ProspectosPorsemana.ToString


        GV_TareasPendientes.DataBind()
        GV_llamadas.DataBind()
    End Sub
    Protected Sub GV_TareasPendientes_DataBinding(sender As Object, e As EventArgs) Handles GV_TareasPendientes.DataBinding
        GV_TareasPendientes.DataSource = BL.Obtener_tareasPendientesUsuario(idUsuario)
    End Sub
    Protected Sub GV_llamadas_DataBinding(sender As Object, e As EventArgs) Handles GV_llamadas.DataBinding
        GV_llamadas.DataSource = BL.Obtener_llamadasPendientesHoyUsuario(idUsuario)
    End Sub
    Protected Sub btn_nuevatarea_Click(sender As Object, e As EventArgs) Handles btn_nuevatarea.Click
        Response.Redirect("../Supervisor/TareaUsuario.aspx?idUsuario=" + idUsuario.ToString, False)
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