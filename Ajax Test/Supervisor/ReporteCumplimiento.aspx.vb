Imports ClosedXML.Excel

Public Class ReporteCumplimiento
    Inherits System.Web.UI.Page

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

        If FechaInicial > FechaFinal Then
            FechaInicial = deFechaFinal.Text
            FechaFinal = deFechaInicial.Text
        End If

        Dim ROWA As DataRow
        Dim DTA As New DataTable

        DTA.Columns.AddRange({New DataColumn("Proyecto", GetType(String)), New DataColumn("Cantidad", GetType(Integer)),
                              New DataColumn("Campana", GetType(String)), New DataColumn("TipoCampana", GetType(String))})

        Dim Proyectos = BL.Obtener_Proyectos()

        For i As Integer = 0 To Proyectos.Length - 1
            Dim DatosCumplimiento = BL.Obtener_TotalesCumplimientoProyecto(Proyectos(i).Proyecto, FechaInicial, FechaFinal)

            If DatosCumplimiento.Length > 0 Then
                For j As Integer = 0 To DatosCumplimiento.Length - 1
                    ROWA = DTA.NewRow
                    ROWA("Proyecto") = Proyectos(i).Proyecto.Trim
                    ROWA("Cantidad") = DatosCumplimiento(j).Cantidad
                    ROWA("Campana") = DatosCumplimiento(j).Campana.Trim
                    ROWA("TipoCampana") = DatosCumplimiento(j).TipoCampana.Trim

                    DTA.Rows.Add(ROWA)
                Next
            End If
        Next

        Dim ROWB As DataRow
        Dim DTB As New DataTable

        DTB.Columns.AddRange({New DataColumn("Semana", GetType(Integer)), New DataColumn("Asesor", GetType(String)), New DataColumn("Cliente", GetType(String)), New DataColumn("Ranking", GetType(String)),
                              New DataColumn("Prototipo", GetType(String)), New DataColumn("Fraccionamiento", GetType(String)), New DataColumn("FechaInicio", GetType(Date)),
                              New DataColumn("Etapa", GetType(String)), New DataColumn("campanaNombre", GetType(String))})

        For i As Integer = 0 To Proyectos.Length - 1
            Dim DetalleCumplimiento = BL.Obtener_DetallesCumplimientoProyecto(Proyectos(i).Proyecto, FechaInicial, FechaFinal)

            If DetalleCumplimiento.Length > 0 Then
                For j As Integer = 0 To DetalleCumplimiento.Length - 1
                    ROWB = DTB.NewRow
                    ROWB("Semana") = DetalleCumplimiento(j).semana
                    ROWB("Asesor") = DetalleCumplimiento(j).asesor
                    ROWB("Cliente") = DetalleCumplimiento(j).cliente
                    ROWB("Ranking") = DetalleCumplimiento(j).Ranking
                    ROWB("Prototipo") = DetalleCumplimiento(j).prototipo
                    ROWB("Fraccionamiento") = DetalleCumplimiento(j).fraccionamiento
                    ROWB("FechaInicio") = DetalleCumplimiento(j).fechaInicio
                    ROWB("Etapa") = DetalleCumplimiento(j).etapa
                    ROWB("campanaNombre") = DetalleCumplimiento(j).nombreCampaña

                    DTB.Rows.Add(ROWB)
                Next
            End If
        Next

        Dim DS As New DataSet
        DS.Tables.AddRange({DTA, DTB})

        ViewState("DatosCumplimiento") = DS

        GV_CumplimientoData.DataSource = DTA
        GV_CumplimientoData.DataBind()
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