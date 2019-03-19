Imports Ajax_Test.Funciones
Imports DevExpress.Web

Public Class CambiaUsuarioMty
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 7
    Dim idUsuario As Integer = 0
    Dim idCliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack() Then
            tb_IdCliente.Focus()
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
                'No valido
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
        End Select
    End Sub
    Public Sub BuscarClientes()
        Dim Cliente As New BusquedaCliente

        With Cliente
            .nombreCliente = tb_NombreCliente.Text
            .apellidoPaterno = tb_ApellidoPaterno.Text
            .apellidoMaterno = tb_ApellidoMaterno.Text
            .IdCliente = tb_IdCliente.Text
        End With

        Dim DT As New DataTable
        DT = GE_Funciones.BuscarClientes(Cliente)
        ViewState("ListaClientes") = DT

        With grdView_BusquedaCliente
            .DataSource = DT
            .DataBind()
        End With
    End Sub
#End Region
#Region "Eventos"
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarClientes()
    End Sub
    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        tb_NombreCliente.Text = ""
        tb_ApellidoPaterno.Text = ""
        tb_ApellidoMaterno.Text = ""
        tb_IdCliente.Text = "" : tb_IdCliente.Focus()

        grdView_BusquedaCliente.DataSource = Nothing
        grdView_BusquedaCliente.DataBind()
    End Sub
    Protected Sub grdView_BusquedaCliente_DataBinding(sender As Object, e As EventArgs) Handles grdView_BusquedaCliente.DataBinding
        grdView_BusquedaCliente.DataSource = ViewState("ListaClientes")
    End Sub

    Protected Sub grdView_BusquedaCliente_CustomButtonCallback(sender As Object, e As ASPxGridViewCustomButtonCallbackEventArgs) Handles grdView_BusquedaCliente.CustomButtonCallback
        Dim IdCliente As Integer = grdView_BusquedaCliente.GetRowValues(e.VisibleIndex, "ID")
        ASPxWebControl.RedirectOnCallback("../SupervisorMty/ClienteSupervisor.aspx?idCliente=" + IdCliente.ToString)
    End Sub

#End Region
End Class