Public Class clientes
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 1
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        lbl_nombre.Text = Usuario.nombre
        lbl_nombreUsuario.Text = Usuario.nombre
        GV_Clientes.DataBind()
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

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        GV_exporterClientes.WriteXlsxToResponse("UltimosClientes")
        'GV_Clientes.Columns("fotografia").Visible = False
        'GV_Clientes.Columns("TPresentacion").Visible = False
        'GV_Clientes.Columns("Opciones").Visible = False
        'GV_Exporter.WriteXlsxToResponse("UltimosClientes")
        'GV_Clientes.Columns("Opciones").Visible = True
        'GV_Clientes.Columns("TPresentacion").Visible = True
        'GV_Clientes.Columns("fotografia").Visible = True
    End Sub

    Protected Sub GV_Clientes_DataBinding(sender As Object, e As EventArgs) Handles GV_Clientes.DataBinding
        GV_Clientes.DataSource = BL.Obtener_clientes_detalles_idUsuario(Usuario.id_usuario)
    End Sub
End Class