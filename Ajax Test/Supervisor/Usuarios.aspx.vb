Imports DevExpress.Web
Imports DevExpress.XtraEditors.Repository

Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Dim DTA As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack() Then
            ObtenerDatosUsuarios()
        End If
        lbl_mensaje.Text = ""
    End Sub

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
                              New DataColumn("Usuario"), New DataColumn("Contrasena"), New DataColumn("Registrado"), New DataColumn("activo", GetType(Boolean)), New DataColumn("Perfil"), New DataColumn("PerfilDes")})

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
            ROWA("Contrasena") = ClientesSupervisor(i).contraseña
            ROWA("Perfil") = ClientesSupervisor(i).id_TipoUsuario
            ROWA("PerfilDes") = ClientesSupervisor(i).TipousuarioDes
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
        Try
            Dim Activo As Integer = 0
            Dim Index As Integer = 0
            Dim RowResult() As DataRow
            Dim DTA As New DataTable
            Dim Contrasena As String

            If (e.NewValues("activo")) Then Activo = 1

            If (String.IsNullOrEmpty(e.NewValues("Contrasena"))) Then Contrasena = "" Else Contrasena = CalculateMD5Hash(e.NewValues("Contrasena"))

            If BL.Actualiza_usuariosPass(e.Keys(0), e.NewValues("Nombre"), e.NewValues("ApellidoPaterno"), e.NewValues("ApellidoMaterno"), e.NewValues("Email"), e.NewValues("Usuario"), Contrasena, Activo, e.NewValues("Perfil")) Then
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
                    DTA.Rows(Index).Item("Contrasena") = e.NewValues("contraseña")
                    DTA.Rows(Index).Item("Usuario") = e.NewValues("Usuario")
                    DTA.Rows(Index).Item("Perfil") = e.NewValues("Perfil")
                    DTA.Rows(Index).Item("PerfilDes") = BuscarDesPerfil(e.NewValues("Perfil"))

                Next

                ViewState("ClienteUsuarios") = DTA
                GV_Usuarios.DataBind()
                lbl_mensaje.Text = MostrarExito("Datos del cliente actualizados con éxito.")
            End If
        Catch ex As Exception

            lbl_mensaje.Text = MostrarError("Error por favor verifique los datos.")
        End Try
    End Sub

    Private Function BuscarDesPerfil(ByVal IdPerfil As Integer) As String
        Dim PerfilDes As String = ""

        For Each TipoUsuario In ViewState("TiposUsuarios")
            If (DirectCast(TipoUsuario, Ajax_Test.Servicio.TipoUsuario).id_tipoUsuario = IdPerfil) Then
                PerfilDes = DirectCast(TipoUsuario, Ajax_Test.Servicio.TipoUsuario).Tipo
            End If
        Next

        Return PerfilDes
    End Function

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

    Protected Sub GV_Usuarios_CellEditorInitialize1(sender As Object, e As ASPxGridViewEditorEventArgs) Handles GV_Usuarios.CellEditorInitialize
        If (e.Column.FieldName = "Perfil") Then
            Dim DT As New DataTable
            Dim cb_Perfiles As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            With cb_Perfiles

                .DataSource = BL.Obtener_TipoUsuario()
                .DataBindItems()
            End With
            ViewState("TiposUsuarios") = cb_Perfiles.DataSource
        End If
    End Sub
#End Region
End Class