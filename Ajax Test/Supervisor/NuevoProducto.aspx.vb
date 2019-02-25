Public Class NuevoProducto
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Page.IsPostBack Then
        Else
            ComboCategorias()
        End If

    End Sub
    Sub ComboCategorias()
        cb_categoria.DataSource = BL.Obtener_categoriasProductos
        cb_categoria.DataTextField = "categoria"
        cb_categoria.DataValueField = "id_categoria"
        cb_categoria.DataBind()
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If BL.Inserta_productos(tb_nombreCorto.Text, tb_NombreCompleto.Text, tb_Descripcion.Text, tb_PrecioNormal.Text, tb_PrecioDescuento.Text, cb_categoria.SelectedValue, Now, tb_observaciones.Text, "-") Then
                lbl_mensaje.Text = MostrarExito("Producto guardado correctamente")
            Else
                lbl_mensaje.Text = MostrarError("Error al guardar nuevo producto, por favor verifique los datos ingresados")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error al guardar nuevo producto, por favor verifique los datos ingresados codigo de error: " + ex.Message)
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