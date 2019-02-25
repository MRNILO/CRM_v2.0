Public Class cambiaProducto
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Dim idProducto As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Try
            idProducto = Request.QueryString("idProducto")
            If idProducto > 0 Then
                If Page.IsPostBack Then
                Else
                    cargaDatos()
                End If

            Else
                Response.Redirect("../Supervisor/Productos.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub cargaDatos()
        Dim Datos = BL.Obtener_detallesProducto(idProducto)

        tb_NombreCorto.Text = Datos.NombreCorto
        tb_NombreCompleto.Text = Datos.NombreCompleto
        tb_descripcion.Text = Datos.Descripcion
        tb_observaciones.Text = Datos.Observaciones
        PNormal.Text = Datos.PrecioNormal
        PDesc.Text = Datos.PrecioDescuento

        cb_categorias.DataSource = BL.Obtener_categoriasProductos
        cb_categorias.DataValueField = "id_categoria"
        cb_categorias.DataTextField = "categoria"
        cb_categorias.SelectedValue = Datos.categoria
        cb_categorias.DataBind()
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If BL.Actualiza_productos(idProducto, tb_NombreCorto.Text, tb_NombreCompleto.Text, tb_descripcion.Text, PNormal.Text, PDesc.Text, cb_categorias.SelectedValue, tb_observaciones.Text) Then
                Response.Redirect("../Supervisor/Productos.aspx")
            Else
                lbl_mensaje.Text = MostrarError("Error en cambiar los datos por favor veririque")
            End If
        Catch ex As Exception

        End Try
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