Public Class NuevaCampana
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Page.IsPostBack Then
        Else
            comboTiposCampaña()
        End If
    End Sub
    Sub comboTiposCampaña()
        cb_tiposCampañas.DataSource = BL.Obtener_tipocampaña
        cb_tiposCampañas.DataTextField = "TipoCampaña"
        cb_tiposCampañas.DataValueField = "id_tipoCampaña"
        cb_tiposCampañas.DataBind()
    End Sub
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If BL.Inserta_campañas(tb_NombreCampaña.Text, cb_tiposCampañas.SelectedValue, dtp_inicio.Date, dtp_final.Date, tb_observaciones.Text) Then
                tb_NombreCampaña.Text = ""
                cb_tiposCampañas.SelectedIndex = 0
                dtp_inicio.Text = ""
                dtp_final.Text = ""
                tb_observaciones.Text = ""

                tb_NombreCampaña.Focus()

                lbl_mensaje.Text = MostrarExito("Campaña creada con exito")
            Else
                lbl_mensaje.Text = MostrarError("Error, por favor verifique los datos ingresados.")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error, por favor verifique los datos ingresados. codigo: " + ex.Message)
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