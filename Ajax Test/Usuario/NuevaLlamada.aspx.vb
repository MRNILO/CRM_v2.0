Imports System.Web.Services

Public Class NuevaLlamada
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Dim idCliente As Integer = 0
        Try
            idCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            idCliente = 0
        End Try
        If Page.IsPostBack Then
        Else
            combos(idCliente)
        End If

    End Sub
    Sub combos(ByVal idCliente As Integer)
        Dim Clientes = BL.Obtener_nombresClientesidUsuario(Usuario.id_usuario).ToList
        Dim Telefono As New Servicio.CNombresCliente
        Telefono.Cliente = "SELECCIONE UN CLIENTE"
        Telefono.id_cliente = 0

        Clientes.Insert(0, Telefono)

        cb_clientes.DataSource = Clientes
        cb_clientes.DataTextField = "Cliente"
        cb_clientes.DataValueField = "id_cliente"
        cb_clientes.DataBind()
        If Not idCliente = 0 Then
            cb_clientes.SelectedValue = idCliente
        End If
    End Sub
    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        Dim HTML As String = ""
        Dim Telefonos = BL.Obtener_telefonoCliente(valor)

        HTML = "<select name=""idTelefono"" class=""form-control"" id=""idTelefono"">"
        If Telefonos.Count = 0 Then
            HTML += " <option value=""0"">SIN TELÉFONOS</option>"
        End If
        For I = 0 To Telefonos.Count - 1
            HTML += " <option value=""" + Telefonos(I).Telefono.ToString + """>" + Telefonos(I).Telefono.ToString + "</option>"
        Next
        HTML += "      </select>"

        Return HTML
    End Function
    Private Sub btn_guardarLLamada_Click(sender As Object, e As EventArgs) Handles btn_guardarLLamada.Click

        Dim IDLLamada As Integer = 0

        Try
            IDLLamada = BL.Inserta_llamadas(cb_clientes.SelectedValue, Usuario.id_usuario, Now, Now, 0, 0, 0, If(rbg_Respuesta.Value = "SI", 1, 0), tb_observaciones.Text, "-")
        Catch ex As Exception

        End Try
        If IDLLamada > 0 Then

            If rbg_Respuesta.Value = "SI" Then
                Try
                    BL.Enviar_CorreoLlamadaCliente(IDLLamada)
                Catch ex As Exception

                End Try
            End If


            Response.Redirect("../Usuario/cliente.aspx?idCliente=" + cb_clientes.SelectedValue.ToString, False)
        Else
            lbl_mensaje.Text = MostrarError("Ocurrio un error al registrar la llamada, verifique los datos e intente nuevamente.")
        End If
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