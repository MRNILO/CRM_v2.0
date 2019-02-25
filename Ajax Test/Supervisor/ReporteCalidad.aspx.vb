Imports ClosedXML.Excel

Public Class ReporteCalidad
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

        DTA.Columns.AddRange({New DataColumn("ClienteId", GetType(String)), New DataColumn("ID_CRM", GetType(Integer)), New DataColumn("Numcte", GetType(String)), New DataColumn("Plaza", GetType(String)),
                              New DataColumn("Fraccionamiento", GetType(String)), New DataColumn("Proyecto", GetType(String)), New DataColumn("Mza", GetType(String)), New DataColumn("Lote", GetType(String)),
                              New DataColumn("TipoFraccionamiento", GetType(String)), New DataColumn("EsqFraccionamiento", GetType(String)), New DataColumn("Cliente", GetType(String)), New DataColumn("Contrato", GetType(String)),
                              New DataColumn("FechaEntrega", GetType(String)), New DataColumn("Telefono1", GetType(String)), New DataColumn("Telefono2", GetType(String)), New DataColumn("Empresa", GetType(String)),
                              New DataColumn("Departamento", GetType(String)), New DataColumn("Conyuge", GetType(String)), New DataColumn("Asesor", GetType(String)), New DataColumn("Integrador", GetType(String)),
                              New DataColumn("Titular", GetType(String)), New DataColumn("Responsable", GetType(String)), New DataColumn("Ranqueo", GetType(String)), New DataColumn("Visita", GetType(Date))})

        Dim DatosCalidad = BL.Obtener_DatosCalidad(FechaInicial, FechaFinal)

        If DatosCalidad.Length > 0 Then
                For j As Integer = 0 To DatosCalidad.Length - 1
                    ROWA = DTA.NewRow
                    ROWA("ClienteId") = DatosCalidad(j).ClienteID
                    ROWA("ID_CRM") = DatosCalidad(j).ClienteIDCRM
                    ROWA("Numcte") = DatosCalidad(j).Numcte
                    ROWA("Plaza") = DatosCalidad(j).Plaza
                    ROWA("Fraccionamiento") = DatosCalidad(j).Fraccionamiento
                    ROWA("Proyecto") = DatosCalidad(j).Proyecto
                    ROWA("Mza") = DatosCalidad(j).Mza
                    ROWA("Lote") = DatosCalidad(j).Lote
                    ROWA("TipoFraccionamiento") = DatosCalidad(j).TipoFraccionamiento
                    ROWA("EsqFraccionamiento") = DatosCalidad(j).EsqFraccionamiento
                    ROWA("Cliente") = DatosCalidad(j).Cliente
                    ROWA("Contrato") = DatosCalidad(j).Contrato
                    ROWA("FechaEntrega") = DatosCalidad(j).FechaEntrega
                    ROWA("Telefono1") = DatosCalidad(j).Telefono1
                    ROWA("Telefono2") = DatosCalidad(j).Telefono2
                    ROWA("Empresa") = DatosCalidad(j).Empresa
                    ROWA("Departamento") = DatosCalidad(j).Departamento
                    ROWA("Conyuge") = DatosCalidad(j).Conyuge
                    ROWA("Asesor") = DatosCalidad(j).Asesor
                    ROWA("Integrador") = DatosCalidad(j).Integrador
                    ROWA("Titular") = DatosCalidad(j).Titular
                    ROWA("Responsable") = DatosCalidad(j).Responsable
                    ROWA("Ranqueo") = DatosCalidad(j).Ranqueo
                    ROWA("Visita") = DatosCalidad(j).Visita

                    DTA.Rows.Add(ROWA)
                Next
            End If

        ViewState("DatosCalidad") = DTA

        GV_CalidadData.DataSource = DTA
        GV_CalidadData.DataBind()
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