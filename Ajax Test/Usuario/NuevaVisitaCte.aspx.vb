Imports Ajax_Test.Funciones

Public Class NuevaVisitaCte
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Dim IDCliente As Integer = 0
    Dim DatosCitas As DatosCita

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            IDCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            IDCliente = 0
        End Try

        If Not IsPostBack() Then
            UI()
        End If
    End Sub

#Region "Metodos"
    Private Sub UI()
        DatosCitas = GE_Funciones.Obtener_DatosCita(IDCliente)

        With txBoxProyecto : .Enabled = False : .Text = DatosCitas.Proyecto : End With
        With txBoxModelo : .Enabled = False : .Text = DatosCitas.Modelo : End With
        With txBoxEsquemaFinanciero : .Enabled = False : .Text = DatosCitas.TipoCredito : End With
        With txBoxMedio : .Enabled = False : .Text = DatosCitas.Origen : End With
        With txBoxCual : .Enabled = False : .Text = DatosCitas.LugarContacto : End With
        With txBoxUsuario : .Enabled = False : .Text = DatosCitas.Asesor : End With
        With txBoxAsesor : .Enabled = False : .Text = DatosCitas.AsesorAsignado : End With
        With txBoxTipoCamapana : .Enabled = False : .Text = DatosCitas.TipoCampana : End With
        With dtp_finicio : .Enabled = False : .Date = Now() : End With
        With dtp_ffinal : .Enabled = False : .Date = Now.AddDays(30) : End With

        Alimentar_ComboClasificacion()
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
        Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)
    End Sub

    Private Sub Alimentar_ComboClasificacion()
        With cmBoxClasificacion
            .DataSource = GE_Funciones.Obtener_Clasificacion()
            .ValueField = "Ranking"
            .TextField = "Ranking"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboMotivos(ByVal Clasificacion As String)
        With cmBoxMotivo
            .DataSource = GE_Funciones.Obtener_Motivos(Clasificacion)
            .ValueField = "id_tipoImpedimento"
            .TextField = "TipoImpedimento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboSubmotivos(ByVal Clasificacion As String, ByVal IdMotivo As Integer)
        With cmBoxSubMotivo
            .DataSource = GE_Funciones.Obtener_Submotivos(Clasificacion, IdMotivo)
            .ValueField = "id_impedimento"
            .TextField = "impedimento"
            .DataBind()

            .SelectedIndex = 0
        End With
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

#Region "Eventos"
    Protected Sub cmBoxClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxClasificacion.SelectedIndexChanged
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
    End Sub

    Protected Sub cmBoxMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMotivo.SelectedIndexChanged
        Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        With DatosCitas
            If BL.Insertar_VisitasClientes(.IdCita, .IdCliente, .IdUsuario, .IdUsuarioAsignado, .IdCampana, cmBoxSubMotivo.SelectedItem.Value, .TipoCredito,
                    0, cmBoxClasificacion.SelectedItem.Value, .Origen, .Proyecto, .Modelo, .TipoCampana, dtp_finicio.Text, dtp_ffinal.Text, dtFechaVisita.Text, 1) Then
                lbl_mensaje.Text = MostrarError("¡Visita registrada correctamente!")
            Else
                lbl_mensaje.Text = MostrarError("¡Ocurrio un error al registrar la visita!")
            End If
        End With
    End Sub
#End Region
End Class