Imports System.Web.Services

Public Class NuevoUsuario
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            Alimentar_CBTipoUsuario()
        End If
    End Sub

    Public Sub Alimentar_CBTipoUsuario()
        With cb_tipoUsuario
            .DataSource = BL.Obtener_TipoUsuario()
            .DataValueField = "id_tipoUsuario"
            .DataTextField = "Tipo"
            .DataBind()
        End With
    End Sub

    <WebMethod()>
    Public Shared Function VerificaUsuario(ByVal usuario As String) As String
        If BL.VerificaUsuario(usuario) Then
            Return "SI"
        End If
        Return "NO"
    End Function
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim NuevoIDUsuario As Integer = 0

        If (BL.VerificaUsuario(tb_usuarioSistema.Text)) Then
            lbl_mensaje.Text = MostrarError("¡El usuario ya existe!")
        Else
            Try
                If cb_tipoUsuario.SelectedValue = 2 Then
                    BL.Inserta_supervisores(tb_NombreUsuario.Text, tb_ap1Usuario.Text, tb_ap2Usuario.Text, tb_email.Text, tb_usuarioSistema.Text,
                        CalculateMD5Hash(tb_contrasenia2.Text), Now.Date, "-")

                    Response.Redirect("../Supervisor/Supervisores.aspx", False)
                Else
                    NuevoIDUsuario = BL.Inserta_usuarios(tb_NombreUsuario.Text, tb_ap1Usuario.Text, tb_ap2Usuario.Text, tb_email.Text, tb_usuarioSistema.Text,
                                     CalculateMD5Hash(tb_contrasenia2.Text), cb_tipoUsuario.SelectedValue, "-")

                    If NuevoIDUsuario > 0 Then
                        If BL.Inserta_supervisorUsuario(NuevoIDUsuario, Usuario.id_usuario) Then
                            Response.Redirect("../Supervisor/Usuarios.aspx", False)
                        Else
                            lbl_mensaje.Text = MostrarError("¡Ocurrio un error! Verifique los datos ingresados e intente de nuevo")
                        End If
                    End If
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("¡Ocurrio un error! " & ex.Message)
            End Try
        End If
    End Sub
    Public Function CalculateMD5Hash(input As String) As String
        Dim md5 = System.Security.Cryptography.MD5.Create()
        Dim inputBytes = System.Text.Encoding.ASCII.GetBytes(input)
        Dim hash = md5.ComputeHash(inputBytes)

        Dim sb = New StringBuilder()

        For I = 0 To hash.Length - 1
            sb.Append(hash(I).ToString("X2"))
        Next

        Return sb.ToString()
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