Imports Ajax_Test.Funciones
Imports DevExpress.Web
Imports System.Web.Services

Public Class UsuarioSupervisor
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idUsuario As Integer = 0
    Dim idCliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack() Then
            tb_IdUsuario.Focus()
            CargaSupervisores()
        End If
    End Sub
#Region "Metodos"
    Private Sub CargaSupervisores()
        With cmBoxSupervisores

            .DataSource = GE_Funciones.BuscarSupervisores()
            .ValueField = "id_supervisor"
            .TextField = "supervisor"
            .DataBind()
            .SelectedIndex = 0
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
    Public Sub BuscarUsuarios()
        Dim Usuario As New BusquedaUsuarios

        With Usuario
            .nombreUsuario = tb_NombreUsuario.Text
            .apellidoPaterno = tb_ApellidoPaterno.Text
            .apellidoMaterno = tb_ApellidoMaterno.Text
            .IdUsuario = tb_IdUsuario.Text
        End With

        Dim DT As New DataTable
        DT = GE_Funciones.BuscarUsuario(Usuario)
        ViewState("ListaUsuarios") = DT

        With grdView_BusquedaUsuarios
            .DataSource = DT
            .DataBind()
        End With
    End Sub
#End Region
#Region "Eventos"
    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        tb_NombreUsuario.Text = ""
        tb_ApellidoPaterno.Text = ""
        tb_ApellidoMaterno.Text = ""
        tb_IdUsuario.Text = "" : tb_IdUsuario.Focus()

        grdView_BusquedaUsuarios.DataSource = Nothing
        grdView_BusquedaUsuarios.DataBind()
    End Sub
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarUsuarios()
    End Sub
    Protected Sub grdView_BusquedaUsuarios_CustomCallback(sender As Object, e As ASPxGridViewCustomButtonCallbackEventArgs) Handles grdView_BusquedaUsuarios.CustomButtonCallback
        Dim Id_Usuario As Integer = grdView_BusquedaUsuarios.GetRowValues(e.VisibleIndex, "ID")
        Dim Nombre As String = grdView_BusquedaUsuarios.GetRowValues(e.VisibleIndex, "UsuarioNombre")

        lblId_Usuario.Text = Id_Usuario.ToString()
        lblNombre_usuario.Text = Nombre.ToString()
        cmBoxSupervisores.SelectedIndex = 0
        cmBoxSupervisores.Focus()
    End Sub

    Protected Sub cmBoxSupervisores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxSupervisores.SelectedIndexChanged
        If (cmBoxSupervisores.SelectedIndex <> 0) Then
            btnAsignar.Enabled = True
        End If
    End Sub
    Protected Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            If (GE_Funciones.Asignar_Supervisor(CInt(lblId_Usuario.Text), CInt(cmBoxSupervisores.SelectedItem.Value))) Then
                lbl_mensaje.Text = MostrarExito("Asignación exitosa")
                lblId_Usuario.Text = ""
                lblNombre_usuario.Text = ""
                cmBoxSupervisores.SelectedIndex = 0
            Else
                lbl_mensaje.Text = MostrarError("No se pudo realizar la asignación")
            End If

        Catch ex As Exception
            lbl_mensaje.Text = MostrarError(ex.ToString())
        End Try
    End Sub
#End Region
End Class