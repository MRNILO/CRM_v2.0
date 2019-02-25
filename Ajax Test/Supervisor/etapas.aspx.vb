Public Class etapas
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        GV_etapas.DataBind()
    End Sub
    Protected Sub GV_etapas_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles GV_etapas.RowInserting
        Try
            If BL.Inserta_etapasCliente(e.NewValues("nEtapa"), e.NewValues("Descripcion")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub

    Protected Sub GV_etapas_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_etapas.RowUpdating
        Try
            If BL.Actualiza_etapasCliente(e.Keys("id_etapa"), e.NewValues("nEtapa"), e.NewValues("Descripcion")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub

    Protected Sub GV_etapas_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles GV_etapas.RowDeleting
        Try
            If BL.Elimina_etapasCliente(e.Keys("id_etapa")) Then
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub
    Protected Sub GV_etapas_DataBinding(sender As Object, e As EventArgs) Handles GV_etapas.DataBinding
        GV_etapas.DataSource = BL.Obtener_etapasCliente
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
#End Region
End Class