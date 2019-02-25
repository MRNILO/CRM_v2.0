Public Class ProgramarLlamada
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCliente As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            idCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            idCliente = 0
        End Try
        If Page.IsPostBack Then
        Else
            dtp_FechaHora.DateTime = Now.AddHours(2)
            dtp_FechaHora.DateTime = dtp_FechaHora.DateTime.AddMinutes(-Now.Minute)
            dtp_FechaHora.DateTime = dtp_FechaHora.DateTime.AddSeconds(-Now.Second)
            dtp_FechaHora.DateTime = dtp_FechaHora.DateTime.AddMilliseconds(-Now.Millisecond)
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
    Protected Sub btn_programarLlamada_Click(sender As Object, e As EventArgs) Handles btn_programarLlamada.Click
        If dtp_FechaHora.DateTime > Now.AddHours(1) Then
            'Si es mayor a una hora
            If BL.Inserta_llamadas(cb_clientes.SelectedValue, Usuario.id_usuario, dtp_FechaHora.DateTime, dtp_FechaHora.DateTime, 1, 0, 0, 0, tb_comentarios.Text, "") > 0 Then
                'Llamada programada correctamente
                lbl_mensaje.Text = MostrarAviso("Llamada programada correctamente para: " + dtp_FechaHora.DateTime.ToShortDateString + " a las: " + dtp_FechaHora.DateTime.ToLongTimeString)
                Response.Redirect("../Usuario/cliente.aspx?idCliente=" + idCliente.ToString, False)
            End If
        Else
            lbl_mensaje.Text = MostrarError("La fecha y hora capturados deben ser mayor a una hora")
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