Imports ClosedXML.Excel

Public Class ReporteCumplimientoMty
    Inherits System.Web.UI.Page
    Private GE_Funciones As New Funciones

    Private Const XLS As String = ".xlsx"
    Private Ruta As String = ConfigurationManager.ConnectionStrings("RutaXLS").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

#Region "Funciones"
    Public Function ValidarCampos()
        If deFechaInicial.Text = "" Then
            deFechaInicial.Focus()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "err_msg", "alert('El campo fecha inicial no puede estar vacio')", True)

            Return False
        End If

        If deFechaFinal.Text = "" Then
            deFechaFinal.Focus()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "err_msg", "alert('El campo fecha final no puede estar vacio')", True)

            Return False
        End If

        Return True
    End Function
#End Region

#Region "Eventos"
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim FechaInicial As Date = deFechaInicial.Text
        Dim FechaFinal As Date = deFechaFinal.Text
        Dim DTS As DataSet = New DataSet

        If FechaInicial > FechaFinal Then
            FechaInicial = deFechaFinal.Text
            FechaFinal = deFechaInicial.Text
        End If

        DTS = GE_Funciones.Obtener_ReporteCumplimiento(FechaInicial, FechaFinal)

        If (DTS.Tables("DTA_DatosCumplimiento").Rows.Count > 0) Then
            ViewState("DatosCumplimiento") = DTS

            GV_CumplimientoData.DataSource = DTS.Tables("DTA_DatosCumplimiento")
            GV_CumplimientoData.DataBind()
            btnExcel.Enabled = True
        Else
            lbl_mensaje.Text = MostrarError("No hay información que procesar.")
            btnExcel.Enabled = False
        End If

    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim DSG As New DataSet
        DSG = CType(ViewState("DatosCumplimiento"), DataSet)

        Using wb As New XLWorkbook
            wb.Worksheets.Add(DSG.Tables(0).Copy, "Totales_Cumplimiento")
            wb.Worksheets.Add(DSG.Tables(1).Copy, "Detalle_Cumplimiento")

            wb.SaveAs(Ruta & "DatosCumplimiento" & XLS)
        End Using

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=DatosCumplimiento" & XLS)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        HttpContext.Current.Response.WriteFile(Ruta & "DatosCumplimiento" & XLS)
        DSG = Nothing
        HttpContext.Current.Response.End()
    End Sub
#End Region
End Class