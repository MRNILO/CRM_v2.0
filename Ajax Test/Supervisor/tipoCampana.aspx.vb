Public Class tipoCampana
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        GV_TipoCampaña.DataBind()
    End Sub
    Protected Sub GV_TipoCampaña_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_TipoCampaña.RowUpdating
        Try
            If BL.Actualiza_tipocampaña(e.Keys("id_tipoCampaña"), e.NewValues("TipoCampaña")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub

    Protected Sub GV_TipoCampaña_DataBinding(sender As Object, e As EventArgs) Handles GV_TipoCampaña.DataBinding
        GV_TipoCampaña.DataSource = BL.Obtener_tipocampaña
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

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim TipoCampana As String = ""
        lbl_mensaje.Text = ""

        TipoCampana = tb_TipoCampana.Text

        If GE_Funciones.Inserta_TipoCampaña(TipoCampana) Then
            lbl_mensaje.Text = MostrarExito("Tipo campaña resgistrado satisfactoriamente.")
        Else
            lbl_mensaje.Text = MostrarError("Error al dar de alta el Tipo de campaña.")
        End If
    End Sub
#End Region
End Class