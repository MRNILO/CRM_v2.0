Imports DevExpress.Web

Public Class Impedimentos
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
    Protected Sub GV_Impedimento_DataBinding(sender As Object, e As EventArgs) Handles GV_Impedimento.DataBinding
        GV_Impedimento.DataSource = ViewState("ListaImpedimentos")
    End Sub
    Protected Sub GV_campañas_CustomButtonCallback(sender As Object, e As ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_Impedimento.CustomButtonCallback
        Dim id_impedimento As Integer = GV_Impedimento.GetRowValues(e.VisibleIndex, "id_impedimento")
        ASPxWebControl.RedirectOnCallback("../Mantenimiento/Impedimento?id=" + id_impedimento.ToString)
    End Sub
#Region "Funciones Usuario"
    Private Sub UI()
        Cargar_Impedimentos()
    End Sub
    Private Sub Cargar_Impedimentos()
        Dim DT = GE_Funciones.Obtener_Impedimentos()
        ViewState("ListaImpedimentos") = DT

        With GV_Impedimento
            .DataSource = DT
            .DataBind()
        End With
    End Sub
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
#End Region

End Class