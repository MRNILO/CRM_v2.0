Public Class LogOn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        Dim userName As String = Request.Form("username")
        Dim Contraseña As String = Request.Form("password")

        Dim Usuario As New Servicio.CUsuarios

        Try
            Usuario = BL.LogIN(userName, CalculateMD5Hash(Contraseña))

            If Usuario.id_usuario > 0 Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then

                    FormsAuthentication.SetAuthCookie(userName, True)
                    Session("Usuario") = Usuario

                    RedirigirSegunNivel(Usuario.Nivel)
                    'Response.Redirect("~/", False)
                Else
                    Session("Usuario") = Usuario
                    FormsAuthentication.RedirectFromLoginPage(userName, False)
                End If
            Else
                'No valido
                lbl_error.Text = MostrarError("Usuario o/y contraseña equivocados")
            End If

        Catch ex As Exception
            'No valido
            lbl_error.Text = MostrarError("Hubo un error ;( " + ex.Message)
        End Try
    End Sub
    Sub RedirigirSegunNivel(ByVal Nivel As Integer)
        Select Case Nivel
            Case 1
                Response.Redirect("~/Usuario/InicioUsuario.aspx", False)
            Case 2
                Response.Redirect("~/Supervisor/InicioSupervisor.aspx", False)
            Case 3
                Response.Redirect("~/Administrativo/InicioAdmin.aspx", False)
            Case 4
                Response.Redirect("~/CallCenter/BusquedaClientes.aspx", False)
            Case 5
                Response.Redirect("~/Caseta/BusquedaClientes.aspx", False)
                'Response.Redirect("~/CallCenter/InicioCCenter.aspx", False)
        End Select
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
End Class