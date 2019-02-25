Public Class Configuraciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            GV_Opciones.DataSource = Session("Configuraciones")
        Else
            Dim arreglo(0) As Servicio.CConfiguraciones
            arreglo(0) = BL.Obtener_configuraciones
            Session("Configuraciones") = arreglo
            GV_Opciones.DataSource = Session("Configuraciones")
        End If
        GV_Opciones.DataBind()
    End Sub

    Protected Sub GV_Opciones_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Opciones.RowUpdating
        Try
            If BL.Actualiza_configuraciones(e.Keys(0), e.NewValues("diasDeGracias"), e.NewValues("emailSistema"), e.NewValues("contraseñaEmail"), e.NewValues("smtpServer"), e.NewValues("puertoEmail"), e.NewValues("SSL"), e.NewValues("EnviarEmails")) Then
                Dim arreglo(0) As Servicio.CConfiguraciones
                arreglo(0) = BL.Obtener_configuraciones
                Session("Configuraciones") = arreglo
                GV_Opciones.DataSource = Session("Configuraciones")
                e.Cancel = True
            Else
                e.Cancel = False
            End If
        Catch ex As Exception
            e.Cancel = False
        End Try
    End Sub

    Protected Sub GV_Opciones_CustomErrorText(sender As Object, e As DevExpress.Web.ASPxGridViewCustomErrorTextEventArgs) Handles GV_Opciones.CustomErrorText
        e.ErrorText = "Error al cambiar los valores, verifique no dejar nada en blanco, e intente de nuevo."
    End Sub
End Class