Imports System.Data.SqlClient
Imports Ajax_Test.Funciones

Public Class CitaCteProspectador
    Inherits System.Web.UI.Page

    Dim NivelSeccion As Integer = 6
    Dim Usuario As New Servicio.CUsuarios

    Dim Id_Cliente As Integer = 0
    Dim Id_Cita As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Id_Cliente = Request.QueryString("idCliente")
        Try
            Crea_generalesCliente()
        Catch ex As Exception

        End Try

        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
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
        cmBoxMedio.Enabled = False

        Alimentar_TablaVisitas(Id_Cliente)
        AlimentarComboUsuarios()
        AlimentarComboMedios()
        AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value)
        AlimentarComboProyectos()
        AlimentarComboModelos(cb_fraccinamientos.SelectedValue)

        If cmBoxCampana.Items.Count > 0 Then
            ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
        End If

        cargarCitas()
    End Sub

    Private Sub cargarCitas()
        GV_citas.DataSource = GE_Funciones.Obtener_CitasCliente(Id_Cliente)
        GV_citas.DataBind()
    End Sub

    Private Sub AlimentarComboMedios()
        Dim da_Medios As DataTable
        da_Medios = GE_Funciones.ObtenerMedios()

        With cmBoxMedio
            .DataSource = da_Medios
            .ValueField = "Id_Medio"
            .TextField = "NombreMedio"
            .DataBind()

            .SelectedIndex = 0
        End With

        For i = 0 To da_Medios.Rows.Count - 1
            If da_Medios.Rows(i).Item("NombreMedio") = "PROSPECTACION" Then
                cmBoxMedio.SelectedIndex = i

                Exit Sub
            End If
        Next
    End Sub

    Private Sub AlimentarComboCampanas(ByVal Id_Medio As Integer)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerCampanas(Id_Medio)
        DTB.Columns.AddRange({New DataColumn("id_campaña"), New DataColumn("campañaNombre")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_campaña") = "0"
                RowB("campañaNombre") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_campaña") = Row("id_campaña")
            RowB("campañaNombre") = Row("campañaNombre")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxCampana
            .DataSource = DTB
            .ValueField = "id_campaña"
            .TextField = "campañaNombre"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub AlimentarComboProyectos()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Proyectos()
        DTB.Columns.AddRange({New DataColumn("Proyecto"), New DataColumn("Fraccionamiento")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow()
                RowB("Proyecto") = "-"
                RowB("Fraccionamiento") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow()
            RowB("Proyecto") = Row("Proyecto")
            RowB("Fraccionamiento") = Row("Fraccionamiento")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_fraccinamientos
            .DataSource = DTB
            .DataValueField = "Proyecto"
            .DataTextField = "Fraccionamiento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub AlimentarComboModelos(ByVal Proyecto As String)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_ModelosXProyecto(Proyecto)
        DTB.Columns.AddRange({New DataColumn("id_producto"), New DataColumn("Modelo")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_producto") = "0"
                RowB("Modelo") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_producto") = Row("id_producto")
            RowB("Modelo") = Row("Modelo")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_modelos
            .DataSource = DTB
            .DataValueField = "id_producto"
            .DataTextField = "Modelo"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_TablaVisitas(ByVal Id_Cliente As Integer)
        Dim DT As New DataTable
        DT = GE_Funciones.Obtener_VisitasCliente(Id_Cliente) : ViewState("VisitasCliente") = DT

        With grdViewVisitas
            .DataSource = DT
            .DataBind()
        End With
    End Sub

    Private Sub AlimentarComboUsuarios()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Usuarios()
        DTB.Columns.AddRange({New DataColumn("id_usuario"), New DataColumn("nombre")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_usuario") = 0
                RowB("nombre") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_usuario") = Row("id_usuario")
            RowB("nombre") = Row("nombre")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_usuarios
            .DataSource = DTB
            .DataBind()
            .DataValueField = "id_usuario"
            .DataTextField = "nombre"
        End With
    End Sub

    Public Sub Crea_generalesCliente()
        Id_Cita = Request.QueryString("id")

        Dim Datos = BL.Obtener_Clientes_detalles_idCliente(Id_Cita) : Id_Cliente = Datos(0).id_cliente
        Dim Telefonos = BL.Obtener_Clientes_Telefonos_idCliente(Id_Cliente)
        Dim TipoCredito = BL.Obtener_Clientes_TipoCredito_idCliente(Id_Cliente)
        Dim AsesorCallCenter = BL.Obtener_Clientes_AsesorCallCenter(Id_Cliente)
        Dim UsuarioDetalles = BL.Obtener_usuarios_detalles(Datos(0).id_Usuario)

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
        lblRanking.Text = Datos(0).ranking.ToString()
        If TipoCredito.Length = 0 Then
            lblTipoCredito.Text = "-"
        Else
            lblTipoCredito.Text = TipoCredito(0).TipoCredito
        End If
        lblEmpresa.Text = Datos(0).Empresa
        lblCampana.Text = Datos(0).campañaNombre.ToString()
        lblTipoCampana.Text = Datos(0).tipoCampana.ToString()
        lblObservaciones.Text = Datos(0).Observaciones
        lblNumeroEnKontrol.Text = Datos(0).Numcte.ToString
        lblFechaCierreEnKontrol.Text = Datos(0).FechaCierre
        lblEscrituracionEnkontrol.Text = Datos(0).FechaEscritura

        lblAsesor.Text = "(USUARIO-" + UsuarioDetalles.usuario + ") - " + UsuarioDetalles.nombre + " " + UsuarioDetalles.apellidoPaterno + " " + UsuarioDetalles.apellidoMaterno

        If (GE_Funciones.Obtener_OperacionesCierre(Id_Cliente) = 0) Then
            Dim Vigencias = BL.Verificar_VigenciaCitas(Id_Cliente)
            If Vigencias.Length > 0 Then
                If Vigencias(0).CitasVigentes > 0 Then
                    lbl_usuario.Text = "(" + Vigencias(0).TipoUsuario + " - " + Vigencias(0).Id_Usuario.ToString + ") " + Vigencias(0).UsuarioVigente
                    lblTUsuarioVigencia.Visible = True
                    lblUsuarioVigencia.Visible = True
                    lblUsuarioVigencia.Text = "(" + Vigencias(0).TipoUsuario + " - " + Vigencias(0).Id_Usuario.ToString + ") " + Vigencias(0).UsuarioVigente
                    btn_asignaCita.Visible = False
                Else
                    lbl_usuario.Text = "-"
                    btn_asignaCita.Visible = True

                    lblTUsuarioVigencia.Visible = False
                    lblUsuarioVigencia.Visible = False
                End If
            Else
                lbl_usuario.Text = "-"
                btn_asignaCita.Visible = True
                lblTUsuarioVigencia.Visible = False
                lblUsuarioVigencia.Visible = False
            End If
        Else
            btn_asignaCita.Visible = False
            lblTUsuarioVigencia.Visible = False
            lblUsuarioVigencia.Visible = False
        End If
    End Sub

    Private Sub ObtenerTipoCampana(ByVal IdCampana As Integer)
        tb_TipoCampana.Text = GE_Funciones.Obtener_TipoCampana(IdCampana)
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

    Public Function Validar_Campos()
        If cb_usuarios.SelectedIndex = 0 Then Return False
        If cmBoxCampana.SelectedIndex = 0 Then Return False
        If cb_fraccinamientos.SelectedIndex = 0 Then Return False
        If cb_modelos.Items.Count = 0 Then Return False
        If cb_modelos.SelectedIndex = 0 Then Return False
        If dtp_fechaCita.Text = "" Then Return False

        Return True
    End Function
#End Region

#Region "Eventos"
    Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
        ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
        cb_fraccinamientos.Focus()
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        If Validar_Campos() Then
            Try
                If BL.Insertar_CitasProspectador(Request.QueryString("id"), Usuario.id_usuario, cb_usuarios.SelectedValue, cmBoxCampana.SelectedItem.Value, tb_TipoCampana.Text,
                                           tb_origen.Text, cmBoxCampana.SelectedItem.Text, cb_fraccinamientos.SelectedValue, cb_modelos.SelectedValue,
                                           dtp_finicio.Date, dtp_ffinal.Date, dtp_fechaCita.Date, GE_Funciones.ObtenerRankingCliente(Request.QueryString("id")), 1) Then
                    Response.Redirect("../Prospectador/Citas.aspx", False)
                End If
            Catch ex As Exception
                lbl_mensaje.Text = "<strong>No se pudo guardar la cita Error: " + ex.Message + "</strong>"
            End Try
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te falta capturar información para la cita, revisa los datos capturados!")
        End If
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Response.Redirect("../Prospectador/ModificaCliente.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + Id_Cita.ToString, False)
    End Sub

    Protected Sub cb_fraccinamientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_fraccinamientos.SelectedIndexChanged
        AlimentarComboModelos(cb_fraccinamientos.SelectedValue)
        cb_modelos.Focus()
    End Sub

    Protected Sub GV_citas_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles GV_citas.HtmlDataCellPrepared
        If e.DataColumn.Caption = "Estatus" Then
            Select Case e.CellValue
                Case 0
                    e.Cell.BackColor = Drawing.Color.OrangeRed
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "VENCIDA"
                Case 1
                    e.Cell.BackColor = Drawing.Color.LightSkyBlue
                    e.Cell.Text = "VIGENTE"
                Case 2
                    e.Cell.BackColor = Drawing.Color.Green
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "COMPLETADA"
            End Select
        End If
    End Sub

    Protected Sub GV_Visitas_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles grdViewVisitas.HtmlDataCellPrepared
        If e.DataColumn.Caption = "Estatus" Then
            Select Case e.CellValue
                Case 0
                    e.Cell.BackColor = Drawing.Color.OrangeRed
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "VENCIDA"
                Case 1
                    e.Cell.BackColor = Drawing.Color.LightSkyBlue
                    e.Cell.Text = "VIGENTE"
                Case 2
                    e.Cell.BackColor = Drawing.Color.Green
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "COMPLETADA"
            End Select
        End If
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