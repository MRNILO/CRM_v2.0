Public Class NuevaCita
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Dim idCliente As Integer = 0
        Try
            idCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            idCliente = 0
        End Try
        If Page.IsPostBack Then
        Else
            combos(idCliente)
        End If
    End Sub
    Sub combos(ByVal idCliente As Integer)
        Dim Clientes = BL.Obtener_nombresClientesidUsuario(Usuario.id_usuario).ToList
        Dim Telefono As New Servicio.CNombresCliente
        Telefono.Cliente = "SELECCIONE UN CLIENTE"
        Telefono.id_cliente = 0

        Clientes.Insert(0, Telefono)

        cb_clientes.DataSource = Clientes
        cb_clientes.DataTextField = "Cliente"
        cb_clientes.DataValueField = "id_cliente"
        cb_clientes.DataBind()
        If Not idCliente = 0 Then
            cb_clientes.SelectedValue = idCliente
        End If
    End Sub

    Protected Sub btn_guardarCita_Click(sender As Object, e As EventArgs) Handles btn_guardarCita.Click
        ValidaUsuario()
        Dim idCita As Integer = 0

        Dim FechaHoraCita As Date = dtp_fecha.Date

        FechaHoraCita = FechaHoraCita.AddHours(tp_horaInicio.DateTime.Hour)
        FechaHoraCita = FechaHoraCita.AddMinutes(tp_horaInicio.DateTime.Minute)
        FechaHoraCita = FechaHoraCita.AddSeconds(tp_horaInicio.DateTime.Second)

        If FechaHoraCita > Now Then
            'Cita a futuro se debe programar
            Try
                idCita = BL.Inserta_citas(cb_clientes.SelectedValue, Usuario.id_usuario, dtp_fecha.Date, tp_horaInicio.DateTime.ToString("HH:mm"), 1, 0, 0, 0, tb_observaciones.Text, "-", tp_horaFinal.DateTime.ToString("hh:mm:ss"), tb_lugar.Text, 0)
                If idCita > 0 Then
                    Response.Redirect("../Usuario/cliente.aspx?idCliente=" + cb_clientes.SelectedValue.ToString, False)
                Else
                    lbl_mensaje.Text = MostrarError("Error por favor verifique los datos para continuar.")
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("Error por favor verifique los datos para continuar. mensaje de error: " + ex.Message)
            End Try
        Else
            'Cita ya realizada unicamente registro
            Try
                idCita = BL.Inserta_citas(cb_clientes.SelectedValue, Usuario.id_usuario, dtp_fecha.Date, tp_horaInicio.DateTime.ToString("HH:mm"), 0, 0, 0, 1, tb_observaciones.Text, "-", tp_horaFinal.DateTime.ToString("hh:mm:ss"), tb_lugar.Text, 0)
                If idCita > 0 Then

                    'Enviar correo de seguimiento

                    Try
                        BL.Enviar_CorreoCitaCliente(idCita)
                    Catch ex As Exception

                    End Try

                    Response.Redirect("../Usuario/cliente.aspx?idCliente=" + cb_clientes.SelectedValue.ToString, False)
                Else
                    lbl_mensaje.Text = MostrarError("Error por favor verifique los datos para continuar.")
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("Error por favor verifique los datos para continuar. mensaje de error: " + ex.Message)
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

    Protected Sub cb_clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_clientes.SelectedIndexChanged
        Response.Redirect("../Usuario/cliente.aspx?idCliente=" + cb_clientes.SelectedValue.ToString, False)
    End Sub

#End Region
End Class