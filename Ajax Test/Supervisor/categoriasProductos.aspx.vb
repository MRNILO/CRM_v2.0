Public Class categoriasProductos
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        gv_categoriasProductos.DataBind()
    End Sub
    Protected Sub gv_categoriasProductos_DataBinding(sender As Object, e As EventArgs) Handles gv_categoriasProductos.DataBinding
        gv_categoriasProductos.DataSource = BL.Obtener_categoriasProductos
    End Sub
    Protected Sub gv_categoriasProductos_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gv_categoriasProductos.RowDeleting
        Try
            If BL.Elimina_categoriasProductos(e.Keys("id_categoria")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try

    End Sub

    Protected Sub gv_categoriasProductos_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gv_categoriasProductos.RowInserting
        Try
            If BL.Inserta_categoriasProductos(e.NewValues("categoria")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub

    Protected Sub gv_categoriasProductos_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_categoriasProductos.RowUpdating
        Try
            If BL.Actualiza_categoriasProductos(e.Keys("id_categoria"), e.NewValues("categoria")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
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