Public Class ClientesUsuarios
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        GV_clientes.DataBind()
    End Sub

    Private Sub ObtenerDatosClientes()
        Dim ClientesSupervisor = BL.Obtener_clientesSupervisor(Usuario.id_usuario)

        ViewState("ClienteSupervisor") = ClientesSupervisor
        GV_clientes.DataSource = ClientesSupervisor
        GV_clientes.DataBind()
    End Sub

    Protected Sub GV_clientes_DataBinding(sender As Object, e As EventArgs) Handles GV_clientes.DataBinding
        GV_clientes.DataSource = BL.Obtener_clientesSupervisor(Usuario.id_usuario)
    End Sub

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        GV_clientes.Columns("fotografia").Visible = False
        GV_clientes.Columns("TPresentación").Visible = False
        GV_exporter.WriteXlsxToResponse()
        GV_clientes.Columns("fotografia").Visible = True
        GV_clientes.Columns("TPresentación").Visible = True
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