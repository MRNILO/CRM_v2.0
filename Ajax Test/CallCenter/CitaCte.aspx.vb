Public Class CitaCte
    Inherits System.Web.UI.Page

    Dim NivelSeccion As Integer = 4
    Dim Usuario As New Servicio.CUsuarios

    Dim Id_Cliente As Integer = 0
    Dim Id_Cita As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            lbl_generales.Text = Crea_generalesCliente()
        Catch ex As Exception

        End Try

        If Not IsPostBack Then
            UI()
        End If
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

    Function Crea_generalesCliente() As String
        Dim HTML As String = ""

        Id_Cita = Request.QueryString("id")

        Dim Datos = BL.Obtener_Clientes_detalles_idCliente(Id_Cita) : Id_Cliente = Datos(0).id_cliente
        Dim Telefonos = BL.Obtener_Clientes_Telefonos_idCliente(Id_Cliente)
        Dim TipoCredito = BL.Obtener_Clientes_TipoCredito_idCliente(Id_Cliente)
        Dim AsesorCallCenter = BL.Obtener_Clientes_AsesorCallCenter(Id_Cliente)

        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotografia + """ class=""img-responsive"" />"
        HTML += "<br />"
        HTML += "<strong>Apellido Materno: </strong>" + Datos(0).ApellidoMaterno
        HTML += "<br />"
        HTML += "<strong>Apellido Paterno: </strong>" + Datos(0).ApellidoPaterno
        HTML += "<br />"
        HTML += "<strong>Nombre(s): </strong>" + Datos(0).Nombre
        HTML += "<br />"
        HTML += "<strong>CURP: </strong>" + Datos(0).CURP
        HTML += "<br />"
        HTML += "<strong>NSS: </strong>" + Datos(0).NSS
        HTML += "<br />"
        HTML += "<strong>Fecha Nacimiento: </strong>" + If(Datos(0).fechaNacimiento = New Date, "-Sin fecha registrada-", Datos(0).fechaNacimiento.ToLongDateString)
        HTML += "<br />"
        HTML += "<strong>Email: </strong><a href=""mailto:" + Datos(0).Email + """>" + Datos(0).Email + "</a>"
        HTML += "<br />"

        For i As Integer = 0 To Telefonos.Length - 1
            HTML += "<strong>Telefono: </strong>" + Telefonos(i).Telefono + "<br />"
        Next

        If TipoCredito.Length = 0 Then
            HTML += "<strong> Tipo de Credito: </strong> - <br />"
        Else
            HTML += "<strong> Tipo de Credito: </strong>" + TipoCredito(0).TipoCredito + "<br />"
        End If

        HTML += "<strong>Empresa: </strong>" + Datos(0).Empresa
        HTML += "<br />"
        HTML += "<strong>ID unico cliente: </strong>" + Datos(0).id_cliente.ToString
        HTML += "<br />"
        HTML += "<strong>Ranking: </strong>" + Datos(0).ranking.ToString()
        HTML += "<br />"
        HTML += "<strong>Campaña: </strong>" + Datos(0).campañaNombre.ToString()
        HTML += "<br />"
        HTML += "<strong>Tipo Campaña: </strong>" + Datos(0).tipoCampana.ToString()
        HTML += "<br />"
        HTML += "<strong>Tarjeta de Presentación: </strong>"
        HTML += "<br />"
        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotoTpresentacion + """ class=""img-responsive"" />"
        HTML += "<br />"
        HTML += "<strong>Observaciones: </strong>" + Datos(0).Observaciones + "<br />"

        HTML += "<strong>Número Cliente Enkontrol: </strong>" + Datos(0).Numcte.ToString
        HTML += "<br />"
        HTML += "<strong>Fecha Cierre Enkontrol: </strong>" + Datos(0).FechaCierre
        HTML += "<br />"
        HTML += "<strong>Fecha Escrituración Enkontrol: </strong>" + Datos(0).FechaEscritura
        HTML += "<br />"

        If AsesorCallCenter.Length > 0 Then
            HTML += "<br /><h5><strong>Asesor Call Center</strong></h5>"
            HTML += "<label>" + AsesorCallCenter(0).id_usuario.ToString + " - " + AsesorCallCenter(0).nombre + " " + AsesorCallCenter(0).apellidoPaterno + " " + AsesorCallCenter(0).apellidoMaterno + "</label>"
        End If

        If AsesorCallCenter.Length = 0 Then
            lbl_usuario.Text = "N/A"
            btn_asignaCita.Visible = True
        Else
            If AsesorCallCenter(0).id_usuario = Usuario.id_usuario Then
                btn_asignaCita.Visible = True
            Else
                VerificarVigenciaCita()
            End If
        End If

        Return HTML
    End Function

    Private Sub ObtenerTipoCampana(ByVal IdCampana As Integer)
        tb_TipoCampana.Text = GE_Funciones.ObtenerTipoCampana(IdCampana)
    End Sub

    Private Sub VerificarVigenciaCita()
        Dim Vigencias = BL.Verificar_VigenciaCita(Id_Cliente)

        If Vigencias.Length > 0 Then
            If Vigencias(0).CitasVigentes > 0 Then
                lbl_usuario.Text = Vigencias(0).UsuarioVigente
                btn_asignaCita.Visible = False
            Else
                lbl_usuario.Text = "-"
                btn_asignaCita.Visible = True
            End If
        Else
            lbl_usuario.Text = "-"
            btn_asignaCita.Visible = True
        End If
    End Sub
#End Region

#Region "Eventos"
    Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
        ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        Try
            If BL.Insertar_CitaCallCenter(Request.QueryString("id"), Usuario.id_usuario, cb_usuarios.SelectedValue, tb_origen.Text, cmBoxCampana.SelectedItem.Text,
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
    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Response.Redirect("../CallCenter/ModificaCliente.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + Id_Cita.ToString, False)
    End Sub
#End Region
End Class