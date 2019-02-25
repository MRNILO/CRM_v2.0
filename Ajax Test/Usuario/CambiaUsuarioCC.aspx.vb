Public Class CambiaUsuarioCC
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idUsuario As Integer = 0
    Dim idCliente As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()


        Try
            idCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            idCliente = 0
        End Try

        Try
            idUsuario = Request.QueryString("idUsuario")
        Catch ex As Exception
            idUsuario = 0
        End Try

        If Not Page.IsPostBack Then
            ComboClientes()
            ComboUsuarios()
        End If

    End Sub
    Sub ComboClientes()
        cb_clientes.DataSource = BL.Obtener_nombresClientesidSupervisor(Usuario.id_usuario)
        cb_clientes.DataTextField = "Cliente"
        cb_clientes.DataValueField = "id_cliente"
        cb_clientes.DataBind()


        If idCliente > 0 Then
            cb_clientes.SelectedValue = idCliente
        End If
    End Sub
    Sub ComboUsuarios()
        cb_usuarios.DataSource = BL.Obtener_nombresUsuariosSupervisor(Usuario.id_usuario)
        cb_usuarios.DataTextField = "Usuario"
        cb_usuarios.DataValueField = "id_usuario"
        cb_usuarios.DataBind()
        If idUsuario > 0 Then
            cb_usuarios.SelectedValue = idUsuario
        End If
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If BL.Cambia_usuarioCliente(cb_usuarios.SelectedValue, cb_clientes.SelectedValue) Then
                lbl_mensaje.Text = MostrarExito("Cliente reasignado con exito")
            Else
                lbl_mensaje.Text = MostrarExito("Error por favor verifique los datos.")
            End If
        Catch ex As Exception

        End Try
    End Sub


#Region "FuncionesUsuario"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                Select Case Usuario.id_usuario
                    Case 1152, 1153, 1154, 1155
                        Session("Usuario") = Usuario
                    Case Else
                        RedirigirSegunNivel(Usuario.Nivel)
                End Select

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