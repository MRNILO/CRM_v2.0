Public Class Supervisores
    Inherits System.Web.UI.Page

    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        GV_Supervisores.DataBind()
    End Sub

    Protected Sub GV_Supervisores_DataBinding(sender As Object, e As EventArgs) Handles GV_Supervisores.DataBinding
        GV_Supervisores.DataSource = BL.Obtener_DetalleSupervisor()
    End Sub

#Region "Funciones"
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

    Protected Sub GV_Usuarios_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Supervisores.RowUpdating
        If BL.Actualiza_supervisores(e.Keys(0), e.NewValues("nombre"), e.NewValues("apellidoPaterno"), e.NewValues("apellidoMaterno"), e.NewValues("Email"), e.NewValues("activo")) Then
            e.Cancel = True
        End If
    End Sub
#End Region
End Class