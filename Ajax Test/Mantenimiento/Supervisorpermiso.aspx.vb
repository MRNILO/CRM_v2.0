Public Class Supervisorpermiso
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            ObtenerDatosUsuarios()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
#Region "Funciones Usuario"
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
            Case 6
                Response.Redirect("~/Prospectador/InicioProspectador.aspx", False)
            Case 7
                Response.Redirect("~/SupervisorMty/InicioCaseta.aspx", False)
        End Select
    End Sub
    Private Sub ObtenerDatosUsuarios()
        Session("ActiveBinding") = True

        Dim Supervisor = BL.Obtener_DetalleSupervisor()
        Dim ROWA As DataRow
        Dim DTA As New DataTable

        DTA.Columns.AddRange({New DataColumn("id_supervisor"), New DataColumn("Nombre"), New DataColumn("ApellidoPaterno"), New DataColumn("ApellidoMaterno"), New DataColumn("BorraEK", GetType(Boolean))})

        For i As Integer = 0 To Supervisor.Length - 1
            ROWA = DTA.NewRow()
            ROWA("id_supervisor") = Supervisor(i).id_supervisor
            ROWA("Nombre") = Supervisor(i).nombre
            ROWA("ApellidoPaterno") = Supervisor(i).apellidoPaterno
            ROWA("ApellidoMaterno") = Supervisor(i).apellidoMaterno
            ROWA("BorraEK") = Supervisor(i).BorraEK
            DTA.Rows.Add(ROWA)
        Next

        ViewState("Supervisor") = DTA
        GV_Supervisores.DataBind()

    End Sub
#End Region
    Private Sub GV_Supervisores_DataBinding(sender As Object, e As EventArgs) Handles GV_Supervisores.DataBinding
        Dim ActiveBinding As Boolean = Session("ActiveBinding")
        If ActiveBinding Then
            GV_Supervisores.DataSource = ViewState("Supervisor")
        End If
    End Sub
    Protected Sub GV_Supervisores_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Supervisores.RowUpdating
        Try
            Dim BorraEK As Integer = 0
            Dim Index As Integer = 0
            Dim RowResult() As DataRow
            Dim DTA As New DataTable

            If (e.NewValues("BorraEK")) Then BorraEK = 1

            If GE_Funciones.Actualiza_SupervisorBorraEk(e.Keys(0), BorraEK) Then
                e.Cancel = True
                DTA = ViewState("Supervisor")
                RowResult = DTA.Select("id_supervisor ='" & e.Keys(0) & "'")

                For Each rowR As DataRow In RowResult
                    Index = DTA.Rows.IndexOf(rowR)
                    DTA.Rows(Index).Item("Nombre") = e.NewValues("Nombre")
                    DTA.Rows(Index).Item("ApellidoPaterno") = e.NewValues("ApellidoPaterno")
                    DTA.Rows(Index).Item("ApellidoMaterno") = e.NewValues("ApellidoMaterno")
                    DTA.Rows(Index).Item("BorraEK") = e.NewValues("BorraEK")
                Next

                ViewState("Supervisor") = DTA
                GV_Supervisores.DataBind()
                lbl_mensaje.Text = MostrarExito("Datos del cliente actualizados con éxito.")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error por favor verifique los datos.")
        End Try
    End Sub
End Class