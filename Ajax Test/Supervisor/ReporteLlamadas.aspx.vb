Public Class ReporteLlamadas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
        Else
            dtp_inicio.Date = Now.AddMonths(-1)
            dtp_final.Date = Now
        End If
    End Sub

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        PE_exporter.ExportXlsxToResponse("Llamadas del " + dtp_inicio.Date.ToString("dd-MM-yy") + " al " + dtp_final.Date.ToString("dd-MM-yy"))
    End Sub
End Class