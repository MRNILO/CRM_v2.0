Imports DevExpress.Web
Imports Ajax_Test.Funciones
Public Class BusquedaClientes1
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 4

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        If Not IsPostBack() Then
            tb_NombreCliente.Focus()
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
        End Select
    End Sub

    Public Sub BuscarClientes()
        Dim Cliente As New BusquedaCliente

        With Cliente
            .nombreCliente = tb_NombreCliente.Text
            .apellidoPaterno = tb_ApellidoPaterno.Text
            .apellidoMaterno = tb_ApellidoMaterno.Text
            .RFC = tb_RFC.Text
            .CURP = tb_CURP.Text
            .NSS = tb_NSS.Text
            .IdCliente = tb_IdCliente.Text
            .Numcte = tb_NumeroCliente.Text
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
        tb_RFC.Text = ""
        tb_CURP.Text = ""
        tb_NSS.Text = ""
        tb_IdCliente.Text = "" : tb_IdCliente.Focus()
        tb_NumeroCliente.Text = ""

        grdView_BusquedaCliente.DataSource = Nothing
        grdView_BusquedaCliente.DataBind()
    End Sub

    Protected Sub grdView_BusquedaCliente_DataBinding(sender As Object, e As EventArgs) Handles grdView_BusquedaCliente.DataBinding
        grdView_BusquedaCliente.DataSource = ViewState("ListaClientes")
    End Sub

    Protected Sub grdView_BusquedaCliente_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles grdView_BusquedaCliente.CustomCallback
        Dim IdCliente As Integer = grdView_BusquedaCliente.GetRowValues(e.Parameters, "ID")
        ASPxWebControl.RedirectOnCallback("../CallCenter/CitaCte.aspx?id=" + IdCliente.ToString)
    End Sub
#End Region
End Class