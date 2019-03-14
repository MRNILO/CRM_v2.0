Public Class Citas1
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 5
    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Id_Cliente = Request.QueryString("idCliente")
        If Not IsPostBack() Then
            CargarCitas()
            CargarCitasAsignadas()
        End If
    End Sub
#Region "Metodos"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    Session("Usuario") = Usuario
                Else
                    Session("Usuario") = Usuario
                    RedirigirSegunNivel(Usuario.Nivel)
                End If
            Else
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)

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
            Case 4
                Response.Redirect("~/Callcenter/InicioCCenter.aspx", False)
            Case 5
                Response.Redirect("~/Caseta/InicioCaseta.aspx", False)
        End Select
    End Sub
    Sub CargarCitas()
        Dim DA_Citas As DataTable
        DA_Citas = GE_Funciones.Obtener_ListadoCitas(Usuario.id_usuario)

        GV_Citas.DataSource = DA_Citas
        GV_Citas.DataBind()
    End Sub
    Sub CargarCitasAsignadas()
        Dim DA_CitasAsigandas As DataTable
        DA_CitasAsigandas = GE_Funciones.Obtener_ListadoCitasAsignadas(Usuario.id_usuario)

        GV_CitasAsignadas.DataSource = DA_CitasAsigandas
        GV_CitasAsignadas.DataBind()
    End Sub
#End Region
End Class