Public Class ProgramarTarea
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Page.IsPostBack Then
        Else
            ComboPrioridad()
        End If

    End Sub
    Sub ComboPrioridad()
        Dim Datos = BL.Obtener_tareas_prioridad

        cb_prioridad.DataSource = Datos
        cb_prioridad.DataTextField = "prioridad"
        cb_prioridad.DataValueField = "id_prioridad"
        cb_prioridad.DataBind()
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If BL.Inserta_tareas(tb_Tarea.Text, cb_prioridad.SelectedValue, Usuario.id_usuario, 0, Now, dtp_fecha.Date, tp_hora.DateTime.ToString("HH:mm")) Then
            Response.Redirect("../Usuario/Tareas.aspx", False)
        Else
            lbl_mensaje.Text = MostrarError("Error por favor verifica los datos e intenta nuevamente.")
        End If
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