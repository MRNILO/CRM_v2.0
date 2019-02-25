Public Class ReporteClientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            dtp_inicio.Date = Now.AddMonths(-1)
            dtp_final.Date = Now
        End If
        GV_Clientes.DataBind()
    End Sub

    Protected Sub GV_Clientes_DataBinding(sender As Object, e As EventArgs) Handles GV_Clientes.DataBinding
        GV_Clientes.DataSource = BL.Obtener_reporte_clientesFechas(dtp_inicio.Date, dtp_final.Date)
    End Sub

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        GV_exporter.WriteXlsxToResponse("Reporte Clientes")
    End Sub
End Class