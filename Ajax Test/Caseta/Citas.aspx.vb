Imports DevExpress.Web

Public Class Citas1
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 5
    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack() Then
            CargarCitas()
            CargarCitasAsignadas()
        End If
    End Sub
    Protected Sub GV_Citas_DataBinding(sender As Object, e As EventArgs) Handles GV_Citas.DataBinding
        Dim ActiveBinding As Boolean = Session("ActiveBinding")
        If ActiveBinding Then
            GV_Citas.DataSource = ViewState("Citas")
        End If
    End Sub
    Protected Sub GV_CitasAsignadas_DataBinding(sender As Object, e As EventArgs) Handles GV_CitasAsignadas.DataBinding
        Dim ActiveBinding As Boolean = Session("ActiveBinding")
        If ActiveBinding Then
            GV_CitasAsignadas.DataSource = ViewState("CitasAsignadas")
        End If
    End Sub
    Protected Sub GV_Citas_CustomButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonEventArgs) Handles GV_Citas.CustomButtonInitialize
        If GV_Citas.GetRowValues(e.VisibleIndex, "Descripcion") = "Separación/Cierre" Then
            e.Visible = DevExpress.Utils.DefaultBoolean.False
        End If
    End Sub
    Protected Sub GV_CitasAsignadas_CustomButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonEventArgs) Handles GV_CitasAsignadas.CustomButtonInitialize
        If GV_CitasAsignadas.GetRowValues(e.VisibleIndex, "Descripcion") = "Separación/Cierre" Then
            e.Visible = DevExpress.Utils.DefaultBoolean.False
        End If
    End Sub
    Protected Sub GV_citas_CustomButtonCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_Citas.CustomButtonCallback
        Dim IdCita As Integer = GV_Citas.GetRowValues(e.VisibleIndex, "Id_Cita")
        Id_Cliente = GV_Citas.GetRowValues(e.VisibleIndex, "id_cliente")
        ASPxWebControl.RedirectOnCallback("../Caseta/NuevaVisitaCte.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + IdCita.ToString)
    End Sub
    Protected Sub GV_CitasAsignadas_CustomButtonCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_CitasAsignadas.CustomButtonCallback
        Dim IdCita As Integer = GV_CitasAsignadas.GetRowValues(e.VisibleIndex, "Id_Cita")
        Id_Cliente = GV_CitasAsignadas.GetRowValues(e.VisibleIndex, "id_cliente")
        ASPxWebControl.RedirectOnCallback("../Caseta/NuevaVisitaCte.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + IdCita.ToString)
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
        Session("ActiveBinding") = True

        DA_Citas = GE_Funciones.Obtener_ListadoCitas(Usuario.id_usuario)
        ViewState("Citas") = DA_Citas
        GV_Citas.DataSource = ViewState("Citas")
        GV_Citas.DataBind()
    End Sub
    Sub CargarCitasAsignadas()
        Dim DA_CitasAsigandas As DataTable
        Session("ActiveBinding") = True
        DA_CitasAsigandas = GE_Funciones.Obtener_ListadoCitasAsignadas(Usuario.id_usuario)
        ViewState("CitasAsignadas") = DA_CitasAsigandas
        GV_CitasAsignadas.DataSource = ViewState("CitasAsignadas")
        GV_CitasAsignadas.DataBind()
    End Sub
#End Region
End Class