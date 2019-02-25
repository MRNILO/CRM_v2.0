Public Class ClientesUsuarios
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        GV_clientes.DataBind()
    End Sub

    Private Sub ObtenerDatosClientes()
        Session("ActiveBinding") = True

        Dim ClientesSupervisor = BL.Obtener_clientesSupervisor(Usuario.id_usuario)

        Dim ROWA As DataRow
        Dim DTA As New DataTable

        DTA.Columns.AddRange({New DataColumn("id_cliente"), New DataColumn("Nombre"), New DataColumn("ApellidoPaterno"), New DataColumn("ApellidoMaterno"), New DataColumn("Email"),
                              New DataColumn("Producto"), New DataColumn("Empresa"), New DataColumn("fechaCreacion"), New DataColumn("Descripcion"), New DataColumn("Usuario"),
                              New DataColumn("Observaciones"), New DataColumn("fotografia"), New DataColumn("fotoTpresentacion")})

        For i As Integer = 0 To ClientesSupervisor.Length - 1
            ROWA = DTA.NewRow()
            ROWA("id_cliente") = ClientesSupervisor(i).id_cliente
            ROWA("Nombre") = ClientesSupervisor(i).Nombre
            ROWA("ApellidoPaterno") = ClientesSupervisor(i).ApellidoPaterno
            ROWA("ApellidoMaterno") = ClientesSupervisor(i).ApellidoMaterno
            ROWA("Email") = ClientesSupervisor(i).Email
            ROWA("Producto") = ClientesSupervisor(i).Producto
            ROWA("Empresa") = ClientesSupervisor(i).Empresa
            ROWA("fechaCreacion") = ClientesSupervisor(i).fechaCreacion
            ROWA("Descripcion") = ClientesSupervisor(i).Descripcion
            ROWA("Usuario") = ClientesSupervisor(i).Usuario
            ROWA("Observaciones") = ClientesSupervisor(i).Observaciones
            ROWA("fotografia") = ClientesSupervisor(i).fotografia
            ROWA("fotoTpresentacion") = ClientesSupervisor(i).fotoTpresentacion

            DTA.Rows.Add(ROWA)
        Next

        ViewState("ClienteSupervisor") = DTA
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