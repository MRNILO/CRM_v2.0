Imports System.Web.Services

Public Class InicioUsuario
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        'Estadisticas
        Dim Estadisticas = BL.Obtener_totalesUsuario(Usuario.id_usuario)

        lbl_ClientesActivos.Text = Estadisticas.ClientesActivos.ToString
        lbl_ClientesCancelados.Text = Estadisticas.ClientesCancelados.ToString
        lbl_clientesTotal.Text = Estadisticas.ClientesTotal.ToString
        lbl_ProspectosSemana.Text = Estadisticas.ProspectosPorsemana.ToString


        GV_TareasPendientes.DataBind()
        GV_llamadas.DataBind()
        'Buscar cliente
        If Page.IsPostBack Then
        Else
            combos()
        End If
    End Sub
    Sub combos()
        Dim Clientes = BL.Obtener_nombresClientesidUsuario(Usuario.id_usuario).ToList
        Dim Telefono As New Servicio.CNombresCliente
        Telefono.Cliente = "SELECCIONE UN CLIENTE"
        Telefono.id_cliente = 0

        Clientes.Insert(0, Telefono)

        cb_clientes.DataSource = Clientes
        cb_clientes.DataTextField = "Cliente"
        cb_clientes.DataValueField = "id_cliente"
        cb_clientes.DataBind()
    End Sub
    Protected Sub cb_clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_clientes.SelectedIndexChanged
        Response.Redirect("../Usuario/cliente.aspx?idCliente=" + cb_clientes.SelectedValue.ToString, False)
    End Sub

    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        If BL.TerminarTarea(valor) Then
            Return "Exito"
        End If
        Return "No"
    End Function
    Public Function ObtenerID() As Integer
        Return Usuario.id_usuario
    End Function
    <WebMethod()>
    Public Shared Function noti() As String

        Dim sess = HttpContext.Current.Session()
        Dim Datos = BL.Obtener_notificaciones(sess("Usuario").id_usuario).ToList
        Dim Resultado As String = ""



        For I = 0 To Datos.Count - 1
            Resultado += "{""titulo"":""" + Datos(I).TituloNotificacion + """,""desc"":""" + Datos(I).DescripcionNotificacion + """,""url"":""" + Datos(I).URL + """}"

            If I = Datos.Count - 1 Then
            Else
                Resultado += ","
            End If
        Next


        Return Resultado
    End Function
    Protected Sub GV_TareasPendientes_DataBinding(sender As Object, e As EventArgs) Handles GV_TareasPendientes.DataBinding
        GV_TareasPendientes.DataSource = BL.Obtener_tareasPendientesUsuario(Usuario.id_usuario)
    End Sub
    Protected Sub GV_llamadas_DataBinding(sender As Object, e As EventArgs) Handles GV_llamadas.DataBinding
        GV_llamadas.DataSource = BL.Obtener_llamadasPendientesHoyUsuario(Usuario.id_usuario)
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