Imports System.Web.Services
Imports DevExpress.Web

Public Class Cliente
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCliente As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        idCliente = Request.QueryString("idCliente")

        If Not IsPostBack Then
            GE_Funciones.Verificar_VigenciaCitas(idCliente)
        End If

        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            'Verifica cliente
            If BL.VerificaCliente(idCliente, Usuario.id_usuario) Then
                Try
                    BL.Actualiza_ultimafecha(idCliente)
                Catch ex As Exception

                End Try

                Alimentar_TablaVisitas(idCliente)

                lbl_generales.Text = Crea_generalesCliente()
                lbl_telefonos.Text = Crea_telefonos()

                'Crea boton para programar llamada
                lbl_botonPrograma.Text = " <a href=""../Usuario/ProgramarLlamada.aspx?idCliente=" + idCliente.ToString + " "" class=""btn btn-sm blue"">Programar Llamada</a>"
                lbl_botonLlamar.Text = "<a href=""../Usuario/NuevaLlamada.aspx?idCliente=" + idCliente.ToString + """ class=""btn green""><i class=""fa fa-phone""></i> Registrar Llamada</a>"
                lbl_botonCitas.Text = "<a href=""../Usuario/NuevaCitaCte.aspx?idCliente=" + idCliente.ToString + """ class=""btn green""><i class=""fa fa-file""></i> Registrar Cita</a>"

                If Page.IsPostBack Then
                Else
                    Dim Datos = BL.Obtener_Clientes_detalles_idCliente(idCliente)
                    GridLlamadas()
                    ComboEtapas(Datos)
                    comboProductos(Datos)
                    BindGVEmails(Datos(0).Email, Datos(0).Email)
                    Ranking(Datos(0))
                    lbl_mensajeRanking.Text = If(Datos(0).ranking = "P", "Pendiente", Datos(0).ranking) : Session("Ranking_Org") = Datos(0).ranking
                    BotonCambiaUsuario()
                End If
                GV_Llamadas.DataSource = Session("GridLlamadas")
                GV_Llamadas.DataBind()

                GV_citas.DataBind()
                GV_operaciones.DataBind()

                DatosEmpresa()
            Else
                Response.Redirect("/")
            End If
        End If

        If Request.QueryString("msj") = "" Then
        Else
            lbl_mensaje.Text = MostrarAviso(Request.QueryString("msj"))
        End If
    End Sub

#Region "Funciones"
    Sub DatosEmpresa()
        Dim HTML As String = ""
        Dim DatosEmpresa = BL.Obtener_detallesEmpresa_idCliente(idCliente)

        HTML += "<strong>Nombre Empresa: </strong>" + DatosEmpresa.Empresa
        HTML += "<br />"
        HTML += "<strong>Razón Social: </strong>" + DatosEmpresa.Razon_Social
        HTML += "<br />"
        HTML += "<strong>Dirección: </strong>" + DatosEmpresa.Direccion
        HTML += "<br />"
        HTML += "<strong>Ciudad: </strong>" + DatosEmpresa.Ciudad
        HTML += "<br />"
        HTML += "<strong>Rubro: </strong>" + DatosEmpresa.rubro
        HTML += "<br />"
        HTML += "<img src=""data:image/jpg;base64," + DatosEmpresa.logotipo + """ />"
        HTML += "<br />"
        HTML += "<strong>Email: </strong>" + DatosEmpresa.email
        HTML += "<br />"
        HTML += "<strong>Horario: </strong>" + DatosEmpresa.Horario
        HTML += "<br />"
        HTML += "<strong>Observaciones: </strong>" + DatosEmpresa.Observaciones
        HTML += "<br />"
        HTML += "<strong>Página web: </strong>" + DatosEmpresa.PaginaWEb

        lbl_datosEmpresa.Text = HTML
    End Sub

    Sub GridLlamadas()
        Dim DatosLlamadas = BL.Obtener_llamadasCliente(idCliente)
        Session("GridLlamadas") = DatosLlamadas
    End Sub

    Sub BotonCambiaUsuario()
        Dim HTML As String = ""
        Select Case Usuario.id_usuario
            Case 1152, 1153, 1154, 1155
                'Permite cambia usuario
                HTML = "<a href=""CambiaUsuarioCC.aspx?idCliente=" + idCliente.ToString + """ class=""btn btn-lg blue"" >Asignar asesor</a>"
                lbl_butonCambia.Text = HTML
        End Select
    End Sub

    Function Crea_telefonos() As String
        Dim HTML As String = ""
        Dim telefonos = BL.Obtener_telefonoCliente(idCliente)

        For I = 0 To telefonos.Count - 1
            HTML += "<a href=""tel:" + telefonos(I).Telefono + """>" + telefonos(I).Telefono + If(telefonos(I).Principal = 1, "(PRINCIPAL)", "") + "</a>"
            HTML += "<br />"
        Next
        Return HTML
    End Function

    Function Crea_generalesCliente() As String
        Dim HTML As String = ""

        Dim Datos = BL.Obtener_Clientes_detalles_idCliente(idCliente)
        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotografia + """ class=""img-responsive"" />"
        HTML += "<br />"
        HTML += "<strong>Apellido Materno </strong>" + Datos(0).ApellidoMaterno
        HTML += "<br />"
        HTML += "<strong>Apellido Paterno </strong>" + Datos(0).ApellidoPaterno
        HTML += "<br />"
        HTML += "<strong>Nombre(s) </strong>" + Datos(0).Nombre
        HTML += "<br />"
        HTML += "<strong>CURP </strong>" + Datos(0).CURP
        HTML += "<br />"
        HTML += "<strong>NSS:</strong>" + Datos(0).NSS
        HTML += "<br />"
        HTML += "<strong>Fecha nacimiento:</strong>" + If(Datos(0).fechaNacimiento = New Date, "-Sin fecha registrada-", Datos(0).fechaNacimiento.ToLongDateString)
        HTML += "<br />"
        HTML += "<strong>Email: </strong><a href=""mailto:" + Datos(0).Email + """>" + Datos(0).Email + "</a>"
        HTML += "<br />"
        HTML += "<strong>Empresa </strong>" + Datos(0).Empresa
        HTML += "<br />"
        HTML += "<strong>ID unico cliente: </strong>" + Datos(0).id_cliente.ToString
        HTML += "<br />"
        HTML += "<strong>Ranking: </strong>" + Datos(0).ranking.ToString()
        HTML += "<br />"
        HTML += "<strong>ID Campaña: </strong>" + Datos(0).Id_Campaña.ToString()
        HTML += "<br />"
        HTML += "<strong>Campaña: </strong>" + Datos(0).campañaNombre.ToString()
        HTML += "<br />"
        HTML += "<strong>Tipo Campaña: </strong>" + Datos(0).tipoCampana.ToString
        HTML += "<br />"
        HTML += "<strong>Tarjeta de Presentación</strong>"
        HTML += "<br />"
        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotoTpresentacion + """ class=""img-responsive"" />"
        HTML += "<br />"
        HTML += "<strong>Observaciones:</strong>" + Datos(0).Observaciones

        Return HTML
    End Function

    Sub Ranking(ByVal Cliente As Servicio.CClientesDetalles)
        If Cliente.ranking = "P" Then
            lbl_ranking.Visible = True
            cb_tipoImpedimento.Visible = True

            btnCambiar.Visible = False
            btnActualizar.Visible = False
            btnCancelar.Visible = False
        Else
            lbl_ranking.Visible = False
            cb_tipoImpedimento.Visible = False
            btn_ranking.Visible = False

            btnCambiar.Visible = False
            btnActualizar.Visible = False
            btnCancelar.Visible = False
        End If
    End Sub

    Sub BindGVEmails(ByVal emailCliente As String, ByVal emailEmpresa As String)
        Dim Correos = BL.Obtener_correosDelCliente(emailCliente, emailEmpresa)
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

    Private Sub Alimentar_TablaVisitas(ByVal Id_Cliente As Integer)
        Dim DT As New DataTable
        DT = GE_Funciones.Obtener_VisitasCliente(Id_Cliente) : ViewState("VisitasCliente") = DT

        With grdViewVisitas
            .DataSource = DT
            .DataBind()
        End With
    End Sub
#End Region

#Region "WebMethods"
    <WebMethod()>
    Public Shared Function Correo(ByVal idEmail As String) As String
        Return BL.Obtener_mensajeEmailID(idEmail)
    End Function

    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        If BL.Cambia_realizadaLlamada(valor) Then
            Return "Exito"
        End If
        Return "No"
    End Function
#End Region

#Region "Eventos"
    '==== RANKING ===='
    Protected Sub btn_ranking_Click(sender As Object, e As EventArgs) Handles btn_ranking.Click
        Dim Ranking As String = ""
        If cb_tipoImpedimento.SelectedValue = 1 Then Ranking = cb_preguntas.SelectedValue Else Ranking = "A"

        If BL.Actualiza_rankingCliente(idCliente, Ranking) Then
            Response.Redirect("../Usuario/cliente.aspx?idCliente=" + idCliente.ToString, False)
        Else
            lbl_mensaje.Text += MostrarError("Ocurrio un error al registrar el Ranking, intentalo nuevamente")
        End If
    End Sub

    Protected Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        lbl_ranking.Visible = True
        cb_tipoImpedimento.Visible = True
        btn_ranking.Visible = True

        btn_ranking.Visible = False
        btnActualizar.Visible = True
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Ranking_Nuevo As String = ""
        If cb_tipoImpedimento.SelectedValue = 1 Then Ranking_Nuevo = cb_preguntas.SelectedValue Else Ranking_Nuevo = "A"

        If BL.Actualizar_Ranking(idCliente, Usuario.id_usuario, Session("Ranking_Org"), Ranking_Nuevo) Then
            Response.Redirect("../Usuario/cliente.aspx?idCliente=" + idCliente.ToString, False)
        Else
            lbl_mensaje.Text += MostrarError("Ocurrio un error al actualizar el Ranking, intentalo nuevamente")
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        lbl_ranking.Visible = False
        cb_tipoImpedimento.Visible = False
        btn_ranking.Visible = False

        btnCambiar.Visible = True
        btnActualizar.Visible = False
        btnCancelar.Visible = False
    End Sub
    '================='

    Protected Sub btn_LlamadasAExcel_Click(sender As Object, e As EventArgs) Handles btn_LlamadasAExcel.Click
        GV_exporterLlamadas.WriteXlsxToResponse()
    End Sub

    Protected Sub btn_CitasExcel_Click(sender As Object, e As EventArgs) Handles btn_CitasExcel.Click
        GV_exporterCitas.WriteXlsxToResponse()
    End Sub

    Protected Sub btn_cambiaEtapa_Click(sender As Object, e As EventArgs) Handles btn_cambiaEtapa.Click
        Try
            If cb_etapas.SelectedValue = 5 Then
                If Not GE_Funciones.Cierre_CitasVisitas(idCliente) Then
                    lbl_mensaje.Text = MostrarError("¡Error al completar las citas y visitas del cliente!")
                    Exit Sub
                End If
            End If

            If BL.Avanza_EtapaCliente(idCliente, Usuario.id_usuario, cb_etapas.SelectedValue, tb_observacionesEtapa.Text, cb_productos.SelectedValue) Then
                GV_operaciones.DataBind()
                lbl_mensaje.Text = MostrarExito("Etapa actualizada")
            Else
                lbl_mensaje.Text = MostrarError("Error al cambiar etapa")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarAviso("Error al cambiar etapa : " + ex.Message)
        End Try
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Response.Redirect("../Usuario/ModificaCliente.aspx?idCliente=" + idCliente.ToString, False)
    End Sub

    Protected Sub cb_tipoImpedimento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_tipoImpedimento.SelectedIndexChanged
        If cb_tipoImpedimento.SelectedValue = 1 Then
            cb_impedimentos.Visible = True
            lbl_impedimentos.Visible = True

            cb_preguntas.Visible = True
            lbl_pregunta.Visible = True
        Else
            cb_impedimentos.Visible = False
            lbl_impedimentos.Visible = False

            cb_preguntas.Visible = False
            lbl_pregunta.Visible = False
        End If

        If cb_tipoImpedimento.SelectedValue = 2 Then
            'Ranking A
            lbl_mensajeRanking.Text = "RANKING: A (Apto para venta)"
        End If
    End Sub

    Protected Sub GV_operaciones_DataBinding(sender As Object, e As EventArgs) Handles GV_operaciones.DataBinding
        GV_operaciones.DataSource = BL.Obtener_operacionesIdCliente(idCliente)
    End Sub

    Protected Sub GV_citas_DataBinding(sender As Object, e As EventArgs) Handles GV_citas.DataBinding
        GV_citas.DataSource = GE_Funciones.Obtener_CitasCliente(idCliente)
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

    Protected Sub GV_citas_CustomButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonEventArgs) Handles GV_citas.CustomButtonInitialize
        If GV_citas.GetRowValues(e.VisibleIndex, "Status") = 0 Then
            e.Visible = DevExpress.Utils.DefaultBoolean.False
        End If
    End Sub

    Protected Sub GV_Llamadas_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles GV_Llamadas.CustomColumnDisplayText
        If e.Column.Name = "Opciones" Then
            If GV_Llamadas.GetRowValues(e.VisibleRowIndex, "realizada") = "REALIZADA" Then
                e.DisplayText = "Ya realizada"
            End If
        End If
    End Sub

    Protected Sub GV_citas_CustomButtonCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_citas.CustomButtonCallback
        Dim IdCita As Integer = GV_citas.GetRowValues(e.VisibleIndex, "Id_Cita")
        ASPxWebControl.RedirectOnCallback("../Usuario/NuevaVisitaCte.aspx?idCliente=" + idCliente.ToString + "&idCita=" + IdCita.ToString)
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
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)

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