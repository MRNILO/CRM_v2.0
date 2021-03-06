﻿Imports Ajax_Test.Funciones
Imports DevExpress.Web

Public Class CitaCteCaseta
    Inherits System.Web.UI.Page

    Dim NivelSeccion As Integer = 5
    Dim Usuario As New Servicio.CUsuarios

    Dim Id_Cliente As Integer = 0
    Dim Id_Cita As Integer = 0
    Private DatosCliente() As Servicio.CClientesDetalles
    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Id_Cliente = Request.QueryString("id")
        Try
            Crea_generalesCliente()
            If Page.IsPostBack Then
            Else
                DatosCliente = BL.Obtener_Clientes_detalles_idCliente(Id_Cliente)
                ComboEtapas(DatosCliente)
                comboProductos(DatosCliente)
            End If
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
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerMedios()
        DTB.Columns.AddRange({New DataColumn("Id_Medio"), New DataColumn("NombreMedio")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("Id_Medio") = 0
                RowB("NombreMedio") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("Id_Medio") = Row("Id_Medio")
            RowB("NombreMedio") = Row("NombreMedio")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxMedio
            .DataSource = DTB
            .ValueField = "Id_Medio"
            .TextField = "NombreMedio"
            .DataBind()

            .SelectedIndex = 0
        End With
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

    Sub ComboEtapas(ByRef Datos As Servicio.CClientesDetalles())
        Dim Dt_Etapas As New DataTable
        Dim ROWA As DataRow
        Dim DT = BL.Obtener_etapasCliente

        Dt_Etapas.Columns.AddRange({New DataColumn("Descripcion", GetType(String)), New DataColumn("id_etapa", GetType(Integer))})

        For i = 0 To DT.Count - 1
            If DT(i).Descripcion.ToUpper <> "VISITA" Then
                ROWA = Dt_Etapas.NewRow
                ROWA("Descripcion") = DT(i).Descripcion
                ROWA("id_etapa") = DT(i).id_etapa

                Dt_Etapas.Rows.Add(ROWA)
            End If
        Next

        ViewState("EtapasCliente") = DT
        cb_etapas.DataSource = Dt_Etapas
        cb_etapas.DataTextField = "Descripcion"
        cb_etapas.DataValueField = "id_etapa"
        cb_etapas.DataBind()

        cb_etapas.SelectedValue = Datos(0).id_etapaActual
    End Sub

    Sub comboProductos(ByRef Datos As Servicio.CClientesDetalles())

        cb_productos.DataSource = BL.Obtener_datos_comboProductos
        cb_productos.DataTextField = "NombreCorto"
        cb_productos.DataValueField = "id_producto"
        cb_productos.DataBind()
        cb_productos.SelectedValue = Datos(0).id_producto
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

    Private Sub Alimentar_TablaVisitas(ByVal Id_Cliente As Integer)
        Dim DT As New DataTable
        DT = GE_Funciones.Obtener_VisitasCliente(Id_Cliente) : ViewState("VisitasCliente") = DT

        With grdViewVisitas
            .DataSource = DT
            .DataBind()
        End With
    End Sub

    Public Function Validar_Campos()
        If cb_usuarios.SelectedIndex = 0 Then Return False
        If cmBoxMedio.SelectedIndex = 0 Then Return False
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

    Protected Sub cmBoxMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMedio.SelectedIndexChanged
        AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value)
        cmBoxCampana.Focus()
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        If Validar_Campos() Then
            Try
                If BL.Insertar_CitasCaseta(Request.QueryString("id"), Usuario.id_usuario, cb_usuarios.SelectedValue, cmBoxCampana.SelectedItem.Value, tb_TipoCampana.Text,
                                           tb_origen.Text, cmBoxCampana.SelectedItem.Text, cb_fraccinamientos.SelectedValue, cb_modelos.SelectedValue,
                                           dtp_finicio.Date, dtp_ffinal.Date, dtp_fechaCita.Date, GE_Funciones.ObtenerRankingCliente(Request.QueryString("id")), 1) Then
                    Response.Redirect("../Caseta/Citas.aspx", False)
                End If
            Catch ex As Exception
                lbl_mensaje.Text = "<strong>No se pudo guardar la cita Error: " + ex.Message + "</strong>"
            End Try
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te falta capturar información para la cita, revisa los datos capturados!")
        End If
    End Sub

    Protected Sub cb_fraccinamientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_fraccinamientos.SelectedIndexChanged
        AlimentarComboModelos(cb_fraccinamientos.SelectedValue)
        cb_modelos.Focus()
    End Sub

    Protected Sub GV_citas_CustomButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonEventArgs) Handles GV_citas.CustomButtonInitialize
        If GV_citas.GetRowValues(e.VisibleIndex, "Status") = 0 Then
            e.Visible = DevExpress.Utils.DefaultBoolean.False
        End If

        If GV_citas.GetRowValues(e.VisibleIndex, "Status") = 2 Then
            e.Visible = DevExpress.Utils.DefaultBoolean.False
        End If
    End Sub

    Protected Sub GV_citas_CustomButtonCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_citas.CustomButtonCallback
        Dim Id_Cita As Integer = GV_citas.GetRowValues(e.VisibleIndex, "Id_Cita")
        ASPxWebControl.RedirectOnCallback("../Caseta/NuevaVisitaCte.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + Id_Cita.ToString)
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

    Protected Sub grdViewVisitas_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles grdViewVisitas.HtmlDataCellPrepared
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

    Protected Sub btn_cambiaEtapa_Click(sender As Object, e As EventArgs) Handles btn_cambiaEtapa.Click
        Try
            Dim DT_Etapas As New DataTable
            Dim ROWA As DataRow
            Dim DT = ViewState("EtapasCliente")
            Dim EtapaActaual As Integer
            Dim EtapaNueva As Integer

            DT_Etapas.Columns.AddRange({New DataColumn("Descripcion", GetType(String)), New DataColumn("id_etapa", GetType(Integer)), New DataColumn("nEtapa", GetType(Integer))})
            For i = 0 To DT.length - 1
                ROWA = DT_Etapas.NewRow
                ROWA("Descripcion") = DT(i).Descripcion
                ROWA("id_etapa") = DT(i).id_etapa
                ROWA("nEtapa") = DT(i).nEtapa
                DT_Etapas.Rows.Add(ROWA)
            Next
            DatosCliente = BL.Obtener_Clientes_detalles_idCliente(Id_Cliente)
            If cb_etapas.SelectedValue = 5 Then
                Dim DatosCita As CitaVigente = GE_Funciones.Citas_Vigentes(Id_Cliente)
                If DatosCita.ExisteCitaVigente Then

                    Dim DatosVisita As VisitaVigente = GE_Funciones.Visitas_Vigentes(Id_Cliente)
                    If DatosVisita.ExisteVisitaVigente Then

                        If GE_Funciones.Cierre_Valida(Id_Cliente) Then
                            If Not GE_Funciones.Cierre_CitasVisitas(Id_Cliente) Then
                                lbl_mensaje.Text = MostrarError("¡Error al completar las citas y visitas del cliente!")
                                Exit Sub
                            End If
                        Else
                            lbl_mensaje.Text = MostrarError("¡Existe una operacion de cierre previa!")
                            Exit Sub
                        End If
                    Else
                        lbl_mensaje.Text = MostrarError("Falta registrar visita")
                        Exit Sub
                    End If
                Else
                    lbl_mensaje.Text = MostrarError("Falta registrar cita.")
                    Exit Sub
                End If
            End If
            For Each row In DT_Etapas.Rows
                If row("id_etapa") = DatosCliente(0).id_etapaActual Then
                    EtapaActaual = row("nEtapa")
                End If
                If row("id_etapa") = cb_etapas.SelectedValue Then
                    EtapaNueva = row("nEtapa")
                End If
            Next
            If EtapaNueva = EtapaActaual Then
                lbl_mensaje.Text = MostrarError("Debe de seleccionar una etapa difente a la etapa actual del cliente.")
            ElseIf EtapaNueva < EtapaActaual Then
                lbl_mensaje.Text = MostrarError("No puede regresar etapa.")
            Else
                If BL.Avanza_EtapaCliente(Id_Cliente, Usuario.id_usuario, cb_etapas.SelectedValue, tb_observacionesEtapa.Text, cb_productos.SelectedValue) Then
                    lbl_mensaje.Text = MostrarExito("Etapa actualizada")
                Else
                    lbl_mensaje.Text = MostrarError("Error al cambiar etapa")
                End If
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarAviso("Error al cambiar etapa : " + ex.Message)
        End Try
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Response.Redirect("../Caseta/ModificaCliente.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + Id_Cita.ToString, False)
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