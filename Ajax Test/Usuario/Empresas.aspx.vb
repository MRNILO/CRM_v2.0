Public Class Empresas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GV_Empresas_CustomErrorText(sender As Object, e As DevExpress.Web.ASPxGridViewCustomErrorTextEventArgs) Handles GV_Empresas.CustomErrorText
        e.ErrorText = "Todos los campos son obligatorios"
    End Sub

    Protected Sub GV_Empresas_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Empresas.RowUpdating
        If IsNothing(e.NewValues("Empresa")) Or e.NewValues("Empresa") = "" Then
            e.NewValues("Empresa") = "-"
        End If
        If IsNothing(e.NewValues("Razon_Social")) Or e.NewValues("Razon_Social") = "" Then
            e.NewValues("Razon_Social") = "-"
        End If
        If IsNothing(e.NewValues("Direccion")) Or e.NewValues("Direccion") = "" Then
            e.NewValues("Direccion") = "-"
        End If
        If IsNothing(e.NewValues("PaginaWEb")) Or e.NewValues("PaginaWEb") = "" Then
            e.NewValues("PaginaWEb") = "-"
        End If
        If IsNothing(e.NewValues("Horario")) Or e.NewValues("Horario") = "" Then
            e.NewValues("Horario") = "-"
        End If
        If IsNothing(e.NewValues("email")) Or e.NewValues("email") = "" Then
            e.NewValues("email") = "-"
        End If
        If IsNothing(e.NewValues("Observaciones")) Or e.NewValues("Observaciones") = "" Then
            e.NewValues("Observaciones") = "-"
        End If
    End Sub
End Class