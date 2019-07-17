Public Class citaMty
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 7
    Dim Usuario As New Servicio.CUsuarios

    Dim Id_Cliente As Integer = 0
    Dim id_Cita As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Try
            Crea_generalesCliente()
        Catch ex As Exception

        End Try

        If Not Page.IsPostBack Then
            dtp_finicio.Date = Now
            dtp_ffinal.Date = Now.AddDays(30)
        End If
    End Sub

    Public Sub Crea_generalesCliente()
        Dim HTML As String = ""

        id_Cita = Request.QueryString("id")

        Dim Datos = BL.Obtener_Clientes_detalles_idCliente(id_Cita) : Id_Cliente = Datos(0).id_cliente
        Dim Telefonos = BL.Obtener_Clientes_Telefonos_idCliente(Id_Cliente)
        Dim TipoCredito = BL.Obtener_Clientes_TipoCredito_idCliente(Id_Cliente)
        Dim AsesorCallCenter = BL.Obtener_Clientes_AsesorCallCenter(Id_Cliente)

        lblIdUnico.Text = Datos(0).id_cliente.ToString
        lblAPaterno.Text = Datos(0).ApellidoPaterno
        lblAMaterno.Text = Datos(0).ApellidoMaterno
        lblnombre.Text = Datos(0).Nombre
        lblFechaNacimiento.Text = If(Datos(0).fechaNacimiento = New Date, "-Sin fecha registrada-", Datos(0).fechaNacimiento.ToLongDateString)
        lblCURP.Text = Datos(0).CURP
        lblNSS.Text = Datos(0).NSS
        lblEmail.Text = Datos(0).Email
        For i As Integer = 0 To Telefonos.Length - 1
            lblTelefono.Text = lblTelefono.Text + Telefonos(i).Telefono + vbCrLf
        Next
        If TipoCredito.Length = 0 Then
            lblTipoCredito.Text = "-"
        Else
            lblTipoCredito.Text = TipoCredito(0).TipoCredito
        End If
        lblEmpresa.Text = Datos(0).Empresa
        lblObservaciones.Text = Datos(0).Observaciones
        lblNumeroEnKontrol.Text = Datos(0).Numcte.ToString
        lblFechaCierreEnKontrol.Text = Datos(0).FechaCierre
        lblEscrituracionEnkontrol.Text = Datos(0).FechaEscritura
        If AsesorCallCenter.Length > 0 Then
            lblAsesorCC.Text = AsesorCallCenter(0).id_usuario.ToString + " - " + AsesorCallCenter(0).nombre + " " + AsesorCallCenter(0).apellidoPaterno + " " + AsesorCallCenter(0).apellidoMaterno
        End If
        If AsesorCallCenter.Length = 0 Then
            lbl_usuario.Text = "-"
        Else
            lbl_usuario.Text = AsesorCallCenter(0).nombre + " " + AsesorCallCenter(0).apellidoPaterno + " " + AsesorCallCenter(0).apellidoMaterno
        End If

        If (GE_Funciones.Obtener_OperacionesCierre(Id_Cliente) > 0) Then
            btn_asignaCita.Visible = False
        Else
            btn_asignaCita.Visible = True
        End If
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        Try
            If BL.Inserta_CitasCall(Request.QueryString("id"), Usuario.id_usuario, cb_usuarios.SelectedValue, tb_origen.Text, tb_lContacto.Text, cb_fraccinamientos.SelectedValue, cb_modelos.SelectedValue, dtp_finicio.Date, dtp_ffinal.Date, dtp_fechaCita.Date, "ACTIVO") Then
                Response.Redirect("Citas.aspx", False)
            End If
        Catch ex As Exception
            lbl_mensaje.Text = "<strong>No se pudo guardar la cita Error: " + ex.Message + "</strong>"
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
        Response.Redirect("../SupervisorMty/ModificaCliente.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + id_Cita.ToString, False)
    End Sub
#End Region
End Class