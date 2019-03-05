Public Class NuevaCitaCte
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Dim idCliente As Integer = 0

        Try
            idCliente = Request.QueryString("idCliente")
            UI()
        Catch ex As Exception
            idCliente = 0
        End Try
    End Sub

#Region "Metodos"
    Private Sub UI()
        With dtp_finicio
            .Date = Now
            .Enabled = False
        End With

        With dtp_ffinal
            .Date = Now.AddDays(30)
            .Enabled = False
        End With

        tb_origen.Enabled = False
        tb_TipoCampana.Enabled = False

        txBox_AsesorAsignado.Text = String.Format("{0} {1} {2}", Usuario.nombre, Usuario.apellidoPaterno, Usuario.apellidoMaterno)

        AlimentarComboCampanas()
        If cmBoxCampana.Items.Count > 0 Then
            ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
        End If
    End Sub

    Private Sub AlimentarComboCampanas()
        With cmBoxCampana
            .DataSource = GE_Funciones.ObtenerCampanas()
            .ValueField = "id_campaña"
            .TextField = "campañaNombre"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub ObtenerTipoCampana(ByVal IdCampana As Integer)
        tb_TipoCampana.Text = GE_Funciones.ObtenerTipoCampana(IdCampana)
    End Sub
#End Region

#Region "Eventos"
    Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
        ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        Try
            If BL.Insertar_CitaCallCenter(Request.QueryString("id"), Usuario.id_usuario, Usuario.id_usuario, tb_origen.Text, cmBoxCampana.SelectedItem.Text,
                                          cb_fraccinamientos.SelectedValue, cb_modelos.SelectedValue, dtp_finicio.Date, dtp_ffinal.Date, dtp_fechaCita.Date, "ACTIVO",
                                          cmBoxCampana.SelectedItem.Value, tb_TipoCampana.Text, 1) Then

                Response.Redirect("Citas.aspx", False)
            End If
        Catch ex As Exception
            lbl_mensaje.Text = "<strong>No se pudo guardar la cita Error: " + ex.Message + "</strong>"
        End Try
    End Sub
#End Region

#Region "FuncionesUsuario"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    Session("Usuario") = Usuario
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
            Response.Redirect("/Account/LogOn.aspx")
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