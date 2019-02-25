Public Class InicioCCenter
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 4
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

    End Sub
    Protected Sub cb_clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_clientes.SelectedIndexChanged
        Response.Redirect("cita.aspx?id=" + cb_clientes.SelectedValue.ToString, False)
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