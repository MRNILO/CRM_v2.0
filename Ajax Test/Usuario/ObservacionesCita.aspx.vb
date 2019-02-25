Public Class ObservacionesCita
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCita As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Try
            idCita = Request.QueryString("idCita")
        Catch ex As Exception
            idCita = 0
        End Try

        If idCita > 0 Then
            If Page.IsPostBack Then
            Else
                Dim Datos = BL.Obtener_observacionesCita(idCita)

                If Datos.Realizada = 1 Then
                    rb_realizada.SelectedValue = "Si"
                Else
                    rb_realizada.SelectedValue = "No"
                End If

                tb_observaciones.Text = Datos.Observaciones
            End If
        Else
            Response.Redirect("/", False)
        End If
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If Trim(tb_observaciones.Text) = "" Then

            lbl_mensaje.Text = MostrarError("No existe ningún comentario")
        Else
            Try
                If BL.ObservacionesCita(idCita, tb_observaciones.Text, If(rb_realizada.SelectedValue = "Si", 1, 0)) Then
                    Try
                        BL.Enviar_CorreoCitaCliente(idCita)
                    Catch ex As Exception

                    End Try

                    lbl_mensaje.Text = MostrarExito("Comentarios guardados")
                Else
                    lbl_mensaje.Text = MostrarError("Ocurrió un problema por favor verifique los datos ingresados ")
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("Ocurrió un problema por favor verifique los datos ingresados " + ex.Message)
            End Try
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