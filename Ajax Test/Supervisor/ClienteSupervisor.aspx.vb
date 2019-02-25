Imports System.Data.SqlClient
Imports System.Web.Services

Public Class ClienteSupervisor
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idCliente As Integer = 0
    Dim Conexion As New SqlConnection("Data Source=192.168.1.13\CRM;Initial Catalog=crm_edificasa;Persist Security Info=True;User ID=sa;Password=Sistemas1245")
    Dim Conexion1 As New SqlConnection("Data Source=altaircloud.mx\SQLSERVER,5696;Initial Catalog=crm_edificasa;Persist Security Info=True;User ID=sa;Password=octy#1992.A")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        idCliente = Request.QueryString("idCliente")
        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            'Verifica cliente
            'If BL.VerificaCliente(idCliente, Usuario.id_usuario) Then
            'Cliente si le pertenece a este usuario
            'Mostrar información del cliente
            lbl_generales.Text = Crea_generalesCliente()
            lbl_telefonos.Text = Crea_telefonos()
            'Crea boton para programar llamada
            'lbl_botonPrograma.Text = " <a href=""/Usuario/ProgramarLlamada.aspx?idCliente=" + idCliente.ToString + " "" class=""btn btn-sm blue"">Programar Llamada</a>"
            'lbl_botonLlamar.Text = "<a href=""/Usuario/NuevaLlamada.aspx?idCliente=" + idCliente.ToString + """ class=""btn green""><i class=""fa fa-phone""></i>Registrar Llamada</a>"
            'lbl_botonCitas.Text = "<a href=""/Usuario/NuevaCita.aspx?idCliente=" + idCliente.ToString + """ class=""btn green""><i class=""fa fa-file""></i>Registrar Cita</a>"
            '
            If Page.IsPostBack Then

            Else
                Dim Datos = BL.Obtener_Clientes_detalles_idCliente(idCliente)

                If Datos(0).Numcte = 0 Then
                    tb_numcte.Text = Datos(0).Numcte
                    tb_numcte.Enabled = True
                Else
                    tb_numcte.Text = Datos(0).Numcte
                    tb_numcte.Enabled = False
                End If

                If Datos(0).FechaCierre = "1900-01-01" Then
                    dtp_FechaCierre.Text = ""
                    dtp_FechaCierre.Enabled = True
                Else
                    dtp_FechaCierre.Text = Datos(0).FechaCierre
                    dtp_FechaCierre.Enabled = False
                End If

                If Datos(0).FechaEscritura = "1900-01-01" Then
                    dtp_FechaEscrituracion.Text = ""
                    dtp_FechaEscrituracion.Enabled = True
                Else
                    dtp_FechaEscrituracion.Text = Datos(0).FechaEscritura
                    dtp_FechaEscrituracion.Enabled = False
                End If

                GridLlamadas()
                ComboEtapas(Datos)
                comboProductos(Datos)
                Ranking(Datos(0))
                lbl_mensajeRanking.Text = If(Datos(0).ranking = "P", "Pendiente", Datos(0).ranking) : Session("Ranking_Org") = Datos(0).ranking
                tb_numcte.Text = Obtener_numcte().ToString
            End If
            GV_Llamadas.DataSource = Session("GridLlamadas")
            GV_Llamadas.DataBind()

            GV_citas.DataBind()
            GV_operaciones.DataBind()

            '   Else
            'Response.Redirect("/")
            '   End If
        End If

        If Request.QueryString("msj") = "" Then

        Else
            lbl_mensaje.Text = MostrarAviso(Request.QueryString("msj"))
        End If
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
    Sub ComboEtapas(ByRef Datos As Servicio.CClientesDetalles())

        cb_etapas.DataSource = BL.Obtener_etapasCliente
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
        HTML += "<strong>Tarjeta de Presentación</strong>"
        HTML += "<br />"
        HTML += "<img src=""data:image/jpg;base64," + Datos(0).fotoTpresentacion + """ class=""img-responsive"" />"
        'HTML += "<br />"
        Return HTML
    End Function
    Protected Sub btn_LlamadasAExcel_Click(sender As Object, e As EventArgs) Handles btn_LlamadasAExcel.Click
        GV_exporterLlamadas.WriteXlsxToResponse()
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

    Protected Sub GV_operaciones_DataBinding(sender As Object, e As EventArgs) Handles GV_operaciones.DataBinding
        GV_operaciones.DataSource = BL.Obtener_operacionesIdCliente(idCliente)
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
        Response.Redirect("../Usuario/ModificaCliente.aspx?idCliente=" + idCliente.ToString, False)
    End Sub

    Protected Sub GV_citas_DataBinding(sender As Object, e As EventArgs) Handles GV_citas.DataBinding
        GV_citas.DataSource = BL.Obtener_citas_detalles_idCliente(idCliente)
    End Sub

    Protected Sub btn_cambiarUsuario_Click(sender As Object, e As EventArgs) Handles btn_cambiarUsuario.Click
        Response.Redirect("../Supervisor/CambiaUsuario.aspx?idCliente=" + idCliente.ToString, False)
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
#End Region

#Region "Ranking"
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

            btnCambiar.Visible = True
            btnActualizar.Visible = False
            btnCancelar.Visible = False
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

    Protected Sub btn_ranking_Click(sender As Object, e As EventArgs) Handles btn_ranking.Click
        Dim Ranking As String = ""
        If cb_tipoImpedimento.SelectedValue = 1 Then Ranking = cb_preguntas.SelectedValue Else Ranking = "A"

        If BL.Actualiza_rankingCliente(idCliente, Ranking) Then
            Response.Redirect("../Usuario/cliente.aspx?idCliente=" + idCliente.ToString, False)
        Else
            lbl_mensaje.Text += MostrarError("Ocurrio un error al registrar el Ranking, intentalo nuevamente")
        End If
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
#End Region
End Class