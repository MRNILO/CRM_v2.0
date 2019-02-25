Public Class Citas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        GE_Citas.WriteXlsxToResponse("Citas")
    End Sub
End Class