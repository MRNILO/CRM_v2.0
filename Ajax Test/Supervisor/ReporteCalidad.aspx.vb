Imports ClosedXML.Excel

Public Class ReporteCalidad
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
        Dim DTA As DataTable = New DataTable

        If FechaInicial > FechaFinal Then
            FechaInicial = deFechaFinal.Text
            FechaFinal = deFechaInicial.Text
        End If

        DTA = GE_Funciones.Obtener_ReporteCalidad(FechaInicial, FechaFinal)
        If (DTA.Rows.Count > 0) Then
            ViewState("DatosCalidad") = DTA

            GV_CalidadData.DataSource = DTA
            GV_CalidadData.DataBind()
            btnExcel.Enabled = True
        Else
            lbl_mensaje.Text = MostrarError("No hay información que procesar.")
            btnExcel.Enabled = False
        End If

    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim DTA As New DataTable
        DTA = CType(ViewState("DatosCalidad"), DataTable)

        Using wb As New XLWorkbook
            wb.Worksheets.Add(DTA, "DatosCalidad")
            wb.SaveAs(Ruta & "DatosCalidad" & XLS)
        End Using

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=DatosCalidad" & XLS)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        HttpContext.Current.Response.WriteFile(Ruta & "DatosCalidad" & XLS)
        DTA = Nothing
        HttpContext.Current.Response.End()
    End Sub
#End Region
End Class