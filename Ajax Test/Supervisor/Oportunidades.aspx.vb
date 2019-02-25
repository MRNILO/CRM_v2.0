Public Class Oportunidades
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GV_oportunidades.DataBind()
    End Sub

    Protected Sub GV_oportunidades_DataBinding(sender As Object, e As EventArgs) Handles GV_oportunidades.DataBinding
        GV_oportunidades.DataSource = BL.Obtener_oportunidades

    End Sub
End Class