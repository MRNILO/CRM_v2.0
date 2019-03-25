Imports System.Data.SqlClient
Imports System.Web.Services

Public Class ClienteSupervisor
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idCliente As Integer = 0
    Dim Conexion As New SqlConnection("Data Source=192.168.1.13\CRM;Initial Catalog=crm_edificasa;Persist Security Info=True;User ID=sa;Password=Sistemas1245")
    Dim Conexion1 As New SqlConnection("Data Source=altaircloud.mx\SQLSERVER,5696;Initial Catalog=crm_edificasa;Persist Security Info=True;User ID=sa;Password=octy#1992.A")
    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        idCliente = Request.QueryString("idCliente")
        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            lbl_generales.Text = Crea_generalesCliente()
            lbl_telefonos.Text = Crea_telefonos()

            If Page.IsPostBack Then

            Else
                BuscaCitasActivas()
                Dim Datos = BL.Obtener_Clientes_detalles_idCliente(idCliente)

                If Datos(0).Numcte = 0 Then
                    tb_numcte.Text = Datos(0).Numcte
                    tb_numcte.Enabled = True
                Else
                    tb_numcte.Text = Datos(0).Numcte
                    'CAMBIOS
                    tb_numcte.Enabled = True
                End If

                If Datos(0).FechaCierre = "1900-01-01" Then
                    dtp_FechaCierre.Text = ""
                    dtp_FechaCierre.Enabled = True
                Else
                    dtp_FechaCierre.Text = Datos(0).FechaCierre
                    'CAMBIOS
                    dtp_FechaCierre.Enabled = True
                End If

                If Datos(0).FechaEscritura = "1900-01-01" Then
                    dtp_FechaEscrituracion.Text = ""
                    dtp_FechaEscrituracion.Enabled = True
                Else
                    dtp_FechaEscrituracion.Text = Datos(0).FechaEscritura
                    'CAMBIOS
                    dtp_FechaEscrituracion.Enabled = True
                End If

                If Datos(0).FechaCancelacion = "1900-01-01" Then
                    dtp_FechaCancelacion.Text = ""
                    dtp_FechaCancelacion.Enabled = True
                Else
                    dtp_FechaCancelacion.Text = Datos(0).FechaCancelacion
                    'CAMBIOS
                    dtp_FechaCancelacion.Enabled = True
                End If

                Alimentar_ComboClasificacion()
                Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
                Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)

                GridLlamadas()
                ComboEtapas(Datos)
                ComboEmpresas()
                comboProductos(Datos)
                ComboUsuarios(Datos)
                cmBoxUsuarios.Value = Datos(0).id_Usuario
                cmBoxUsuarios.Text = String.Format("({0}) {1}", Datos(0).id_Usuario, Datos(0).NombreAsesor + " " + Datos(0).ApellidoAsesor)
                cmBoxEmpresa.Value = Datos(0).EmpresaEK

                Ranking(Datos(0))
                lbl_mensajeRanking.Text = If(Datos(0).ranking = "P", "Pendiente", Datos(0).ranking) : Session("Ranking_Org") = Datos(0).ranking
                tb_numcte.Text = Obtener_numcte().ToString
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
    Sub Ranking(ByVal Cliente As Servicio.CClientesDetalles)
        If Cliente.ranking = "P" Then
            Clasificacion.Style.Add("display", "show")
            Submotivo.Style.Add("display", "show")
            Controles.Style.Add("display", "show")

            btnCambiar.Visible = False
            btnGuardar.Visible = True
            btnActualizar.Visible = False
            btnCambiar.Visible = False
        Else
            Clasificacion.Style.Add("display", "none")
            Submotivo.Style.Add("display", "none")
            Controles.Style.Add("display", "none")

            btnCambiar.Visible = True
        End If
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
        HTML += "<strong>Email: </strong><a href=""mailto:" + Datos(0).Email + """>" + Datos(0).Email + "</a>"
        HTML += "<br />"
        HTML += "<strong>Empresa </strong>" + Datos(0).Empresa
        HTML += "<br />"
        HTML += "<strong>ID unico cliente: </strong>" + Datos(0).id_cliente.ToString
        HTML += "<br />"
        HTML += "<strong>Ranking: </strong>" + Datos(0).ranking.ToString()
        HTML += "<br />"
        HTML += "<strong>Campaña: </strong>" + Datos(0).campañaNombre.ToString()
        HTML += "<br />"
        HTML += "<strong>Tipo Campaña: </strong>" + Datos(0).tipoCampana.ToString + "<br />"
        HTML += "<br />"
        HTML += "<strong>Tarjeta de Presentación</strong>"
        HTML += "<br />"
        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotoTpresentacion + """ class=""img-responsive"" />"

        Return HTML
    End Function

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

        Dim NumeroClienteEK As Integer = tb_numcte.Text

        Dim Resultado As Boolean = False
        Dim cmd As New SqlCommand("Actualizar_DatosEnkontrol", Conexion)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@usuario", Usuario.id_usuario)
        cmd.Parameters.AddWithValue("@cliente", idCliente)
        cmd.Parameters.AddWithValue("@Numcte", tb_numcte.Text)

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

        cb_etapas.DataSource = BL.Obtener_etapasCliente
        cb_etapas.DataTextField = "Descripcion"
        cb_etapas.DataValueField = "id_etapa"
        cb_etapas.DataBind()

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
            If BL.Avanza_EtapaCliente(idCliente, Usuario.id_usuario, cb_etapas.SelectedValue, tb_observacionesEtapa.Text, cb_productos.SelectedValue) Then
                GV_operaciones.DataBind()
                lbl_mensaje.Text = MostrarAviso("Etapa actualizada")
            Else
                lbl_mensaje.Text = MostrarError("Error al cambiar etapa")
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
        Dim NumeroCliente As Integer

        Try
            NumeroCliente = Convert.ToInt32(tb_numcte.Text)
        Catch ex As Exception
            tb_numcte.Focus()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "err_msg", "alert('¡El campo solamente puede aceptar números!')", True)

            Exit Sub
        End Try

        If NumeroCliente <> 0 Then
            If Guarda_numcte() Then
                lbl_numcte.ForeColor = Drawing.Color.Green
                lbl_numcte.Text = "¡Los datos se guardaron exitosamente!."
            Else
                lbl_numcte.ForeColor = Drawing.Color.Red
                lbl_numcte.Text = "¡Ocurrió un error al guardar la información, intentalo nuevamente'"
            End If
        End If
    End Sub

    Protected Sub btn_LlamadasAExcel_Click(sender As Object, e As EventArgs) Handles btn_LlamadasAExcel.Click
        GV_exporterLlamadas.WriteXlsxToResponse()
    End Sub

    Protected Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        Clasificacion.Style.Add("display", "show")
        Submotivo.Style.Add("display", "show")
        Controles.Style.Add("display", "show")

        btnGuardar.Visible = False
        btnActualizar.Visible = True
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Ranking_Nuevo As String = cmBoxClasificacion.SelectedItem.Value

        If BL.Actualizar_Ranking(idCliente, Usuario.id_usuario, Session("Ranking_Org"), Ranking_Nuevo) Then
            Response.Redirect("../Supervisor/ClienteSupervisor.aspx?idCliente=" + idCliente.ToString, False)
        Else
            lbl_mensaje.Text += MostrarError("¡Ocurrio un error al actualizar el Ranking!")
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Clasificacion.Style.Add("display", "none")
        Submotivo.Style.Add("display", "none")
        Controles.Style.Add("display", "none")

        btnCambiar.Visible = True
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
#End Region
End Class