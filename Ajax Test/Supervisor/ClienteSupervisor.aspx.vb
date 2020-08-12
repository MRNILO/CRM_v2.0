Imports System.Data.SqlClient
Imports System.Web.Services
Imports Ajax_Test.Funciones
Imports Newtonsoft.Json

Public Class ClienteSupervisor
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idCliente As Integer = 0
    Dim StringConnection As String = ConfigurationManager.ConnectionStrings("crm_roest3ConnectionString").ConnectionString
    Dim Conexion As New SqlConnection(StringConnection)
    'Dim Conexion1 As New SqlConnection("Data Source=altaircloud.mx\SQLSERVER,5696;Initial Catalog=crm_edificasa;Persist Security Info=True;User ID=sa;Password=octy#1992.A")
    Private GE_Funciones As New Funciones
    Private DatosCliente() As Servicio.CClientesDetalles


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        lbl_mensaje.Text = ""
        idCliente = Request.QueryString("idCliente")
        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            Crea_generalesCliente()
            lbl_telefonos.Text = Crea_telefonos()

            If Not Page.IsPostBack Then
                UI()
            Else

                If String.IsNullOrEmpty(Session("Visita")) = False Then
                    Clasificacion.Style.Add("display", "show")
                    Submotivo.Style.Add("display", "show")
                    Controles.Style.Add("display", "show")
                End If

            End If

            GV_Llamadas.DataSource = Session("GridLlamadas")
            GV_Llamadas.DataBind()

            CargarCitas()
            GV_operaciones.DataBind()
        End If

        If Request.QueryString("msj") = "" Then

        Else
            lbl_mensaje.Text = MostrarAviso(Request.QueryString("msj"))
        End If
    End Sub

#Region "Metodos"

    Public Sub UI()
        BuscaCitasActivas()
        DatosCliente = BL.Obtener_Clientes_detalles_idCliente(idCliente)

        If DatosCliente(0).Numcte = 0 Then
            tb_numcte.Text = DatosCliente(0).Numcte
            tb_numcte.Enabled = True
        Else
            tb_numcte.Text = DatosCliente(0).Numcte
            'CAMBIOS
            tb_numcte.Enabled = False
        End If

        If DatosCliente(0).Numcte2 = 0 Then
            tb_numcte2.Text = DatosCliente(0).Numcte2
            tb_numcte2.Enabled = True
        Else
            tb_numcte2.Text = DatosCliente(0).Numcte2
            'CAMBIOS
            tb_numcte2.Enabled = False
        End If

        If DatosCliente(0).ModeloEk = "-" Then
            tb_Modelo.Text = DatosCliente(0).ModeloEk
            tb_Modelo.Enabled = True
        Else
            tb_Modelo.Text = DatosCliente(0).ModeloEk
            'CAMBIOS
            tb_Modelo.Enabled = False
        End If

        If DatosCliente(0).Fecha_Recuperacion = "1900-01-01" Then
            dtp_FechaRecuperacion.Text = ""
            dtp_FechaRecuperacion.Enabled = True
        Else
            dtp_FechaRecuperacion.Text = DatosCliente(0).Fecha_Recuperacion
            'CAMBIOS
            dtp_FechaRecuperacion.Enabled = False
        End If

        If DatosCliente(0).FechaCierre = "1900-01-01" Then
            dtp_FechaCierre.Text = ""
            dtp_FechaCierre.Enabled = True
        Else
            dtp_FechaCierre.Text = DatosCliente(0).FechaCierre
            'CAMBIOS
            dtp_FechaCierre.Enabled = False
        End If

        If DatosCliente(0).FechaEscritura = "1900-01-01" Then
            dtp_FechaEscrituracion.Text = ""
            dtp_FechaEscrituracion.Enabled = True
        Else
            dtp_FechaEscrituracion.Text = DatosCliente(0).FechaEscritura
            'CAMBIOS
            dtp_FechaEscrituracion.Enabled = False
        End If

        If DatosCliente(0).FechaCancelacion = "1900-01-01" Then
            dtp_FechaCancelacion.Text = ""
            dtp_FechaCancelacion.Enabled = True
        Else
            dtp_FechaCancelacion.Text = DatosCliente(0).FechaCancelacion
            'CAMBIOS
            dtp_FechaCancelacion.Enabled = False
        End If

        If DatosCliente(0).Fecha_OperacionEK = "1900-01-01" Then
            dtp_FechaOperacion.Text = ""
            dtp_FechaOperacion.Enabled = True
        Else
            dtp_FechaOperacion.Text = DatosCliente(0).Fecha_OperacionEK
            'CAMBIOS
            dtp_FechaOperacion.Enabled = False
        End If

        Alimentar_TablaVisitas(idCliente)
        Alimentar_ComboClasificacion()
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
        Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)

        GridLlamadas()
        ComboEtapas(DatosCliente)
        ComboEmpresas()
        comboProductos(DatosCliente)
        ComboUsuarios(DatosCliente)
        cmBoxUsuarios.Value = DatosCliente(0).id_Usuario
        cmBoxUsuarios.Text = String.Format("({0}) {1}", DatosCliente(0).id_Usuario, DatosCliente(0).NombreAsesor + " " + DatosCliente(0).ApellidoAsesor)
        cmBoxEmpresa.Value = DatosCliente(0).EmpresaEK

        Ranking(DatosCliente(0))
        lbl_mensajeRanking.Text = If(DatosCliente(0).ranking = "P", "Pendiente", DatosCliente(0).ranking) : Session("Ranking_Org") = DatosCliente(0).ranking
        tb_numcte.Text = Obtener_numcte().ToString
        If Usuario.BorraEk = 1 Then
            btn_LimpiarNumcte.Style.Add("display", "always")
        Else
            btn_LimpiarNumcte.Style.Add("display", "none")
        End If
    End Sub

    Sub Ranking(ByVal Cliente As Servicio.CClientesDetalles)
        If Cliente.ranking = "P" Then
            Clasificacion.Style.Add("display", "show")
            Submotivo.Style.Add("display", "show")
            Controles.Style.Add("display", "show")
            btnGuardar.Visible = True
            btnActualizar.Visible = False
        Else
            Clasificacion.Style.Add("display", "none")
            Submotivo.Style.Add("display", "none")
            Controles.Style.Add("display", "none")
            'lbl_idVisita.Text = ""
        End If
    End Sub

    Function Crea_telefonos() As String
        Dim HTML As String = ""
        Dim telefonos = BL.Obtener_telefonoCliente(idCliente)

        For I = 0 To telefonos.Count - 1
            HTML += "<a href="" tel:" + telefonos(I).Telefono + """>" + telefonos(I).Telefono + If(telefonos(I).Principal = 1, "(PRINCIPAL)", "") + "</a>"
            HTML += "<br/>"
        Next
        Return HTML
    End Function

    Public Sub Crea_generalesCliente()
        Dim Datos = BL.Obtener_Clientes_detalles_idCliente(idCliente)

        lblIdUnico.Text = Datos(0).id_cliente.ToString
        lblAPaterno.Text = Datos(0).ApellidoPaterno
        lblAMaterno.Text = Datos(0).ApellidoMaterno
        lblnombre.Text = Datos(0).Nombre
        lblEmail.Text = Datos(0).Email
        lblEmpresa.Text = Datos(0).Empresa
        lblRanking.Text = Datos(0).ranking.ToString()
        lblCampana.Text = Datos(0).campañaNombre.ToString()
        lblTipoCampana.Text = Datos(0).tipoCampana.ToString()
    End Sub

    Function Obtener_numcte() As Integer
        Dim Resultado As Integer = 0
        Dim cmd As New SqlCommand("SELECT numcte FROM clientes WHERE id_cliente=@id_cliente", Conexion)
        ' cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@id_cliente", idCliente)
        Conexion.Close()
        Conexion.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read
            Resultado = DirectCast(reader.Item("numcte"), Integer)
        End While
        Conexion.Close()
        Return Resultado
    End Function

    Function Guarda_numcte() As Boolean
        Dim FechaCierre As Date
        Dim FechaEscrituracion As Date
        Dim FechaCancelacion As Date
        Dim FechaRecuperacion As Date
        Dim FechaOperacion As Date

        Dim NumeroClienteEK As Integer = tb_numcte.Text

        Dim Resultado As Boolean = False
        Dim cmd As New SqlCommand("Actualizar_DatosEnkontrol", Conexion)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@usuario", Usuario.id_usuario)
        cmd.Parameters.AddWithValue("@cliente", idCliente)
        cmd.Parameters.AddWithValue("@Numcte", tb_numcte.Text)
        cmd.Parameters.AddWithValue("@Numcte2", tb_numcte2.Text)
        cmd.Parameters.AddWithValue("@ModeloEk", tb_Modelo.Text)

        If dtp_FechaCierre.Text = "" Then
            cmd.Parameters.AddWithValue("@FechaCierre", "")
        Else
            FechaCierre = dtp_FechaCierre.Text
            cmd.Parameters.AddWithValue("@FechaCierre", FechaCierre)
        End If

        If dtp_FechaEscrituracion.Text = "" Then
            cmd.Parameters.AddWithValue("@FechaEscritura", "")
        Else
            FechaEscrituracion = dtp_FechaEscrituracion.Text
            cmd.Parameters.AddWithValue("@FechaEscritura", FechaEscrituracion)
        End If

        If dtp_FechaCancelacion.Text = "" Then
            cmd.Parameters.AddWithValue("@FechaCancelacion", "")
        Else
            FechaCancelacion = dtp_FechaCancelacion.Text
            cmd.Parameters.AddWithValue("@FechaCancelacion", FechaCancelacion)
        End If

        If dtp_FechaRecuperacion.Text = "" Then
            cmd.Parameters.AddWithValue("@FechaRecuperacion", "")
        Else
            FechaRecuperacion = dtp_FechaRecuperacion.Text
            cmd.Parameters.AddWithValue("@FechaRecuperacion", FechaRecuperacion)
        End If

        If dtp_FechaOperacion.Text = "" Then
            cmd.Parameters.AddWithValue("@FechaOperacion", "")
        Else
            FechaOperacion = dtp_FechaOperacion.Text
            cmd.Parameters.AddWithValue("@FechaOperacion", FechaOperacion)
        End If

        cmd.Parameters.AddWithValue("@EmpresaEK", cmBoxEmpresa.SelectedItem.Value)

        Conexion.Close()
        Try
            Conexion.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Conexion.Close()
                Return True
            End If
        Catch ex As Exception
            Conexion.Close()
            Return False
        End Try
        Conexion.Close()

        Return False
    End Function

    Public Sub Alimentar_ComboClasificacion()
        With cmBoxClasificacion
            .DataSource = GE_Funciones.Obtener_Clasificacion()
            .ValueField = "Ranking"
            .TextField = "Ranking"
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

    Public Sub Alimentar_ComboMotivos(ByVal Clasificacion As String)
        With cmBoxMotivo
            .DataSource = GE_Funciones.Obtener_Motivos(Clasificacion)
            .ValueField = "id_tipoImpedimento"
            .TextField = "TipoImpedimento"
            .DataBind()

            .SelectedIndex = 0
        End With


    End Sub

    Public Sub Alimentar_ComboSubmotivos(ByVal Clasificacion As String, ByVal IdMotivo As Integer)
        With cmBoxSubMotivo
            .DataSource = GE_Funciones.Obtener_Submotivos(Clasificacion, IdMotivo)
            .ValueField = "id_impedimento"
            .TextField = "impedimento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub ComboUsuarios(ByRef Datos As Servicio.CClientesDetalles())
        Dim ROWA As DataRow
        Dim DTA As New DataTable
        Dim dtaUsuarios = BL.Obtener_usuarios_todos

        If (dtaUsuarios.Length > 0) Then

            DTA.Columns.AddRange({New DataColumn("clave", GetType(Integer)), New DataColumn("Asesor", GetType(String))})

            For i = 0 To dtaUsuarios.Length - 1
                ROWA = DTA.NewRow
                ROWA("clave") = dtaUsuarios(i).id_usuario
                ROWA("Asesor") = dtaUsuarios(i).nombre + " " + dtaUsuarios(i).apellidoPaterno + " " + dtaUsuarios(i).apellidoMaterno

                DTA.Rows.Add(ROWA)
            Next

            With cmBoxUsuarios
                .DataSource = DTA
                .ValueField = "clave"
                .TextField = "Asesor"
                .DataBind()
            End With
        End If
    End Sub

    Sub ComboEtapas(ByRef Datos As Servicio.CClientesDetalles())
        Dim DT = BL.Obtener_etapasCliente

        cb_etapas.DataSource = DT
        cb_etapas.DataTextField = "Descripcion"
        cb_etapas.DataValueField = "id_etapa"
        cb_etapas.DataBind()

        ViewState("EtapasCliente") = DT
        cb_etapas.SelectedValue = Datos(0).id_etapaActual
    End Sub

    Sub BuscaCitasActivas()
        Dim DTCitas = GE_Funciones.Obtener_CitasCliente(idCliente)

        For Each Row As DataRow In DTCitas.Rows
            If (Row("Status") = 1) Then
                btn_cambiarUsuario.Enabled = False
                cmBoxUsuarios.Enabled = False
                lbl_CitasVigentes.Visible = True
                Exit Sub
            End If
        Next
        btn_cambiarUsuario.Enabled = True
        cmBoxUsuarios.Enabled = True
        lbl_CitasVigentes.Visible = False
    End Sub

    Sub comboProductos(ByRef Datos As Servicio.CClientesDetalles())

        cb_productos.DataSource = BL.Obtener_datos_comboProductos
        cb_productos.DataTextField = "NombreCorto"
        cb_productos.DataValueField = "id_producto"
        cb_productos.DataBind()
        cb_productos.SelectedValue = Datos(0).id_producto
    End Sub

    Private Sub ComboEmpresas()
        Dim ROWA As DataRow
        Dim DTA As New DataTable

        DTA.Columns.AddRange({New DataColumn("idEmpresa", GetType(Integer)), New DataColumn("Empresa", GetType(String))})

        ROWA = DTA.NewRow
        ROWA("idEmpresa") = 0
        ROWA("Empresa") = "SELECCIONE EMPRESA"
        DTA.Rows.Add(ROWA)

        ROWA = DTA.NewRow
        ROWA("idEmpresa") = 11
        ROWA("Empresa") = "VILLA MAGNA"
        DTA.Rows.Add(ROWA)

        ROWA = DTA.NewRow
        ROWA("idEmpresa") = 18
        ROWA("Empresa") = "EDIFICASA-GPV"
        DTA.Rows.Add(ROWA)

        With cmBoxEmpresa
            .DataSource = DTA
            .ValueField = "idEmpresa"
            .TextField = "Empresa"
            .DataBind()
        End With
        cmBoxEmpresa.Value = 0
    End Sub

    Sub GridLlamadas()
        Dim DatosLlamadas = BL.Obtener_llamadasCliente(idCliente)
        Session("GridLlamadas") = DatosLlamadas
    End Sub

    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        If BL.Cambia_realizadaLlamada(valor) Then
            Return "Exito"
        End If
        Return "No"
    End Function
#End Region

#Region "Eventos"
    Protected Sub cmBoxClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxClasificacion.SelectedIndexChanged
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
    End Sub

    Protected Sub cmBoxMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMotivo.SelectedIndexChanged
        Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)
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
            DatosCliente = BL.Obtener_Clientes_detalles_idCliente(idCliente)
            If cb_etapas.SelectedValue = 5 Then
                Dim DatosCita As CitaVigente = GE_Funciones.Citas_Vigentes(idCliente)
                If DatosCita.ExisteCitaVigente Then

                    Dim DatosVisita As VisitaVigente = GE_Funciones.Visitas_Vigentes(idCliente)
                    If DatosVisita.ExisteVisitaVigente Then

                        If GE_Funciones.Cierre_Valida(idCliente) Then
                            If Not GE_Funciones.Cierre_CitasVisitas(idCliente) Then
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
                If BL.Avanza_EtapaCliente(idCliente, Usuario.id_usuario, cb_etapas.SelectedValue, tb_observacionesEtapa.Text, cb_productos.SelectedValue) Then
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
        Response.Redirect("../Supervisor/ModificaCliente.aspx?idCliente=" + idCliente.ToString, False)
    End Sub

    Protected Sub btn_cambiarUsuario_Click(sender As Object, e As EventArgs) Handles btn_cambiarUsuario.Click
        Try
            If BL.Cambia_usuarioClienteSupervisor(CInt(cmBoxUsuarios.Value), idCliente, CInt(Usuario.id_usuario)) Then
                lbl_mensaje.Text = MostrarExito("¡El Cliente se reasigno exitosamente!")
            Else
                lbl_mensaje.Text = MostrarExito("¡Ocurrio un error al tratar de reaginar el cliente!")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarExito("¡Ocurrio un error al procesar la operación!")
        End Try
    End Sub

    Protected Sub btn_guardaNumcte_Click(sender As Object, e As EventArgs) Handles btn_guardaNumcte.Click
        Dim JSONObj As Object
        Dim Data As String
        If IsNumeric(tb_numcte.Text) Then
            If cmBoxEmpresa.SelectedItem.Value = 0 Then
                cmBoxEmpresa.Focus()
                lbl_mensaje.Text = MostrarError("¡Es indispensable seleccionar la empresa.!")
                Exit Sub
            Else
                Dim NumeroCliente As Integer = Convert.ToInt32(tb_numcte.Text)
                If NumeroCliente <> 0 Then
                    If tb_numcte2.Text <> "0" Then
                        If IsNumeric(tb_numcte2.Text) Then
                            Dim NumeroClienteEk2 As Integer = Convert.ToInt32(tb_numcte2.Text)
                            Data = EK_REST.Obtener_Datos_Cliente(cmBoxEmpresa.SelectedItem.Value, NumeroClienteEk2)
                            JSONObj = JsonConvert.DeserializeObject(Of Object)(Data)
                            If JSONObj("Numero_Cliente") <> 0 Then
                                If dtp_FechaRecuperacion.Text = "" Then
                                    dtp_FechaRecuperacion.Focus()
                                    lbl_mensaje.Text = MostrarError("¡El campo fecha de recuperación no debe ir vacio!")
                                    Exit Sub
                                End If
                            Else
                                lbl_mensaje.Text = MostrarError(String.Format("¡El cliente {0} no existe en la empresa {1}!", NumeroClienteEk2, cmBoxEmpresa.SelectedItem.Text))
                                Exit Sub
                            End If
                        Else
                            tb_numcte2.Focus()
                            lbl_mensaje.Text = MostrarError("¡El campo solamente puede aceptar números!")
                            Exit Sub
                        End If
                    End If
                    Data = EK_REST.Obtener_Datos_Cliente(cmBoxEmpresa.SelectedItem.Value, NumeroCliente)
                    JSONObj = JsonConvert.DeserializeObject(Of Object)(Data)
                    If JSONObj("Numero_Cliente") <> 0 Then
                        If Guarda_numcte() Then
                            lbl_mensaje.Text = MostrarExito(String.Format("¡Datos guardados correctamente.!"))
                            tb_numcte.Enabled = False
                        Else
                            lbl_numcte.ForeColor = Drawing.Color.Red
                            lbl_numcte.Text = "¡Ocurrió un error al guardar la información, intentalo nuevamente!"
                            Exit Sub
                        End If
                    Else
                        lbl_mensaje.Text = MostrarError(String.Format("¡El cliente {0} no existe en la empresa {1}!", NumeroCliente, cmBoxEmpresa.SelectedItem.Text))
                        Exit Sub
                    End If
                Else
                    tb_numcte.Focus()
                    lbl_mensaje.Text = MostrarError("¡El número de cliente no puede ser 0.")
                    Exit Sub
                End If
            End If
        Else
            tb_numcte.Focus()
            lbl_mensaje.Text = MostrarError("¡El campo solamente puede aceptar números!")
            Exit Sub
        End If
    End Sub

    Protected Sub btn_LlamadasAExcel_Click(sender As Object, e As EventArgs) Handles btn_LlamadasAExcel.Click
        GV_exporterLlamadas.WriteXlsxToResponse()
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Ranking_Nuevo As String = cmBoxClasificacion.SelectedItem.Value

        If BL.Actualizar_Ranking_Visitas(idCliente, Usuario.id_usuario, Session("Ranking_Org"), Ranking_Nuevo, Session("Visita"), cmBoxSubMotivo.Value) Then
            Response.Redirect("../Supervisor/ClienteSupervisor.aspx?idCliente=" + idCliente.ToString, False)
        Else
            lbl_mensaje.Text += MostrarError("¡Ocurrio un error al actualizar el Ranking!")
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Clasificacion.Style.Add("display", "none")
        Submotivo.Style.Add("display", "none")
        Controles.Style.Add("display", "none")
        btnGuardar.Visible = False
        btnActualizar.Visible = False
        btnCancelar.Visible = False
    End Sub

    Protected Sub GV_operaciones_DataBinding(sender As Object, e As EventArgs) Handles GV_operaciones.DataBinding
        GV_operaciones.DataSource = BL.Obtener_operacionesIdCliente(idCliente)
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
    Protected Sub btn_Resetear_Click(sender As Object, e As EventArgs) Handles btn_Resetear.Click
        Dim Cliente_EK As Boolean = chkCliente_Ek.Checked
        Dim Cliente_EK2 As Boolean = chkCliente_Ek2.Checked
        Dim Cierre_Ek As Boolean = chkCierre_EK.Checked
        Dim Escrituracion_Ek As Boolean = chkEscrituracion_Ek.Checked
        Dim Cancelacion_EK As Boolean = chkCancelacion.Checked
        Dim Recuperacion_EK As Boolean = chkRecuperacion.Checked
        Dim Empresa_EK As Boolean = chkEmpresa.Checked
        Dim Modelo_EK As Boolean = chkModelo.Checked
        Dim Operacion_EK As Boolean = chkOperacion.Checked
        Dim Comentario_EK As String = txtComentario_EK.Text

        If GE_Funciones.Actualiza_NKontrol(Cliente_EK, Cliente_EK2, Cierre_Ek, Escrituracion_Ek, Cancelacion_EK, Recuperacion_EK, Empresa_EK, Modelo_EK, Operacion_EK, idCliente, Usuario.id_usuario, Comentario_EK) Then
            chkCliente_Ek.Checked = False
            chkCliente_Ek2.Checked = False
            chkCierre_EK.Checked = False
            chkEscrituracion_Ek.Checked = False
            chkCancelacion.Checked = False
            chkRecuperacion.Checked = False
            chkEmpresa.Checked = False
            chkModelo.Checked = False
            chkOperacion.Checked = False
            txtComentario_EK.Text = ""
            UI()
            lbl_mensaje.Text += MostrarExito("¡Cliente actualizado!")
        Else
            lbl_mensaje.Text += MostrarError("¡Nose pudo actualizar!")
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

    Sub CargarCitas()
        GV_citas.DataSource = GE_Funciones.Obtener_CitasCliente(idCliente)
        GV_citas.DataBind()
    End Sub

    Protected Sub cbPanelRanking_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelRanking.Callback
        Session("Visita") = grdViewVisitas.GetRowValues(e.Parameter, "Id_Visita")

        Clasificacion.Style.Add("display", "show")
        Submotivo.Style.Add("display", "show")
        Controles.Style.Add("display", "show")

        btnGuardar.Visible = False
        btnActualizar.Visible = True
        btnCancelar.Visible = True

    End Sub
#End Region
End Class