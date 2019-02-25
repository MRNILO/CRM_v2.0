Imports DevExpress.Web

Public Class Clientes1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        GE_Clientes.WriteXlsxToResponse("Clientes")
    End Sub

    Protected Sub GV_Clientes_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles GV_Clientes.CustomCallback
        Dim Id_Cliente As Integer = GV_Clientes.GetRowValues(e.Parameters, "id_cliente")

        ASPxWebControl.RedirectOnCallback("../CallCenter/ModificaCliente.aspx?idCliente=" + Id_Cliente.ToString + "&idCita=" + Id_Cliente.ToString)
    End Sub
End Class