Imports System.Net
Imports System.Net.Mail
Imports SendGrid

Public Class NuevoEmail
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
            Try
                tb_email.Text = BL.Obtener_Clientes_detalles_idCliente(cb_clientes.SelectedValue)(0).Email
            Catch ex As Exception
                tb_email.Text = ""
            End Try
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
    Protected Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        Dim Cliente = BL.Obtener_Clientes_detalles_idCliente(cb_clientes.SelectedValue)
        Dim Emaildestino As String = ""



        If Trim(tb_email.Text) = "" Then
            Emaildestino = Cliente(0).Email
        Else
            Emaildestino = Trim(tb_email.Text)
        End If

        If fup_adjunto.HasFile Then
            'Se encontro un adjunto 
            Dim Archivo = fup_adjunto.FileBytes
            Dim Adjunto As IO.Stream = New IO.MemoryStream(Archivo)
            Try
                If Enviar_correo_sendgrid(Usuario.Email, Emaildestino, tb_asunto.Text, ed_mensaje.Html, Adjunto, fup_adjunto.FileName) Then
                    BL.Inserta_emails(Usuario.Email, ed_mensaje.Html, Emaildestino, tb_asunto.Text, 2, Now, 1)
                    Response.Redirect("../Usuario/inbox.aspx", False)
                End If
            Catch ex As Exception

            End Try
        Else
            If tb_asunto.Text <> "" Then
                If BL.EnviarEmailSendGrid(Usuario.Email, Emaildestino, tb_asunto.Text, ed_mensaje.Html, 0) Then
                    lbl_mensaje.Text = MostrarExito("Correo enviado")
                Else
                    lbl_mensaje.Text = MostrarError("Error al enviar tu correo, por favor verifica la información")
                End If
            End If
        End If
    End Sub
    Function Enviar_correo_sendgrid(ByVal EmailOrigen As String, ByVal EmailDestino As String, ByVal Asunto As String, ByVal MensajeHTML As String, ByVal Adjunto As IO.Stream, ByVal AdjuntoName As String) As Boolean
        Dim Mensaje As New SendGridMessage
        Dim Credenciales As New NetworkCredential("roest", "roest.2016A")
        Mensaje.From = New MailAddress(EmailOrigen)

        Mensaje.AddAttachment(Adjunto, AdjuntoName)
        Mensaje.AddTo(EmailDestino)
        Mensaje.Subject = Asunto
        Mensaje.Html = MensajeHTML


        Dim TransporteWEB As New Web(Credenciales)

        Try
            TransporteWEB.DeliverAsync(Mensaje)
            Return True
        Catch ex As Exception
            Return False
        End Try

        Return False
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
#End Region
End Class