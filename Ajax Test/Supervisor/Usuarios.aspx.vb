Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Dim DTA As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        ''GV_Usuarios.DataBind()
        If Not IsPostBack() Then
            ObtenerDatosUsuarios()
        End If
    End Sub
    'Private Sub GV_Usuarios_DataBinding(sender As Object, e As EventArgs) Handles GV_Usuarios.DataBinding
    '    GV_Usuarios.DataSource = BL.Obtener_UsuarioDetalleSupervisor(Usuario.id_usuario)
    'End Sub
    Private Sub GV_Usuarios_DataBinding(sender As Object, e As EventArgs) Handles GV_Usuarios.DataBinding
        Dim ActiveBinding As Boolean = Session("ActiveBinding")
        If ActiveBinding Then
            GV_Usuarios.DataSource = ViewState("ClienteUsuarios")
        End If
    End Sub
    Private Sub ObtenerDatosUsuarios()
        Session("ActiveBinding") = True

        Dim ClientesSupervisor = BL.Obtener_UsuarioDetalleSupervisor(Usuario.id_usuario)
        Dim ROWA As DataRow
        Dim DTA As New DataTable

        DTA.Columns.AddRange({New DataColumn("id_usuario"), New DataColumn("Nombre"), New DataColumn("ApellidoPaterno"), New DataColumn("ApellidoMaterno"), New DataColumn("Email"),
                              New DataColumn("Usuario"), New DataColumn("Registrado"), New DataColumn("activo", GetType(Boolean))})

        For i As Integer = 0 To ClientesSupervisor.Length - 1
            ROWA = DTA.NewRow()
            ROWA("id_usuario") = ClientesSupervisor(i).id_usuario
            ROWA("Nombre") = ClientesSupervisor(i).nombre
            ROWA("ApellidoPaterno") = ClientesSupervisor(i).apellidoPaterno
            ROWA("ApellidoMaterno") = ClientesSupervisor(i).apellidoMaterno
            ROWA("Email") = ClientesSupervisor(i).Email
            ROWA("Usuario") = ClientesSupervisor(i).usuario
            ROWA("Registrado") = ClientesSupervisor(i).fechaCreacion.ToString("dd/MM/yyyy")
            ROWA("activo") = ClientesSupervisor(i).activo

            DTA.Rows.Add(ROWA)
        Next

        ViewState("ClienteUsuarios") = DTA
        GV_Usuarios.DataBind()
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
    Protected Sub GV_Usuarios_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Usuarios.RowUpdating
        Dim Activo As Integer = 0

        If (e.NewValues("activo")) Then Activo = 1

        If BL.Actualiza_usuarios(e.Keys(0), e.NewValues("Nombre"), e.NewValues("ApellidoPaterno"), e.NewValues("ApellidoMaterno"), e.NewValues("Email"), Activo) Then
            Dim Index As Integer = 0
            Dim RowResult() As DataRow
            Dim DTA As New DataTable

            e.Cancel = True
            DTA = ViewState("ClienteUsuarios")

            RowResult = DTA.Select("id_usuario = " & e.Keys(0))

            For Each rowR As DataRow In RowResult
                Index = DTA.Rows.IndexOf(rowR)
                DTA.Rows(Index).Item("Nombre") = e.NewValues("Nombre")
                DTA.Rows(Index).Item("ApellidoPaterno") = e.NewValues("ApellidoPaterno")
                DTA.Rows(Index).Item("ApellidoMaterno") = e.NewValues("ApellidoMaterno")
                DTA.Rows(Index).Item("Email") = e.NewValues("Email")
                DTA.Rows(Index).Item("activo") = e.NewValues("activo")
            Next

            ViewState("ClienteUsuarios") = DTA
            GV_Usuarios.DataBind()

        End If
    End Sub
#End Region
End Class