Imports System.IO

Public Class Funciones
    Private GE_SQL As New SQL_Functions

#Region "Estructuras"
    Public Structure BusquedaCliente
        Dim nombreCliente As String
        Dim apellidoMaterno As String
        Dim apellidoPaterno As String
        Dim RFC As String
        Dim CURP As String
        Dim NSS As String
        Dim IdCliente As String
        Dim Numcte As String
    End Structure
#End Region

#Region "Archivos"
    Public Sub EliminarArchivos(ByVal Archivos() As String)
        Try
            For i As Integer = 0 To Archivos.Length - 1
                File.Delete(Archivos(i))
            Next i
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Consultas"
    Public Function Comprobar_OperacionConsulta(ByVal Consulta As String) As Boolean
        Dim Existe As Boolean
        Dim Verbos() As String = {"UPDATE", "DELETE", "INSERT", "DROP", "TRUNCATE"}

        For i As Integer = 0 To Verbos.Length - 1
            If Consulta.ToUpper.Contains(Verbos(i)) Then
                Existe = True
                Exit For
            End If
        Next

        Return Existe
    End Function

    Public Function ObtenerDatosConsulta(ByVal Query As String) As List(Of DatosConsulta)
        Dim Datos As New List(Of DatosConsulta)
        Dim Aux As DatosConsulta

        Try
            Aux = New DatosConsulta
            Aux.DT = GE_SQL.SQLGetTable(Query)
            Aux.Resultado = "Success"

            Datos.Add(Aux)
        Catch ex As Exception
            Aux = New DatosConsulta
            Aux.DT = Nothing
            Aux.Resultado = ex.Message.ToString

            Datos.Add(Aux)
        End Try

        Return Datos
    End Function

    Public Function BuscarClientes(ByVal Cliente As BusquedaCliente) As DataTable
        Dim Query As String = "EXEC [dbo].[BuscarClientes]
		                            @Nombre = N'" & Cliente.nombreCliente & "',
		                            @ApellidoPaterno = N'" & Cliente.apellidoPaterno & "',
		                            @ApellidoMaterno = N'" & Cliente.apellidoMaterno & "',
		                            @rfcCliente = N'" & Cliente.RFC & "',
		                            @curpCliente = N'" & Cliente.CURP & "',
		                            @nssCliente = N'" & Cliente.NSS & "',
                                    @IdCrm = N'" & Cliente.IdCliente & "',
	                                @NumCliente = N'" & Cliente.Numcte & "'"

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim ROWB As DataRow

        DTB.Columns.AddRange({New DataColumn("ID", GetType(Integer)), New DataColumn("Cliente", GetType(String)), New DataColumn("Asesor", GetType(String)),
                              New DataColumn("CallCenter", GetType(String)), New DataColumn("Ranking", GetType(String)), New DataColumn("Nacimiento", GetType(Date)),
                              New DataColumn("RFC", GetType(String)), New DataColumn("CURP", GetType(String)), New DataColumn("NSS", GetType(String))})

        DTA = GE_SQL.SQLGetTable(Query)
        If DTA.Rows.Count > 0 Then
            For Each rowA As DataRow In DTA.Rows
                ROWB = DTB.NewRow
                ROWB("ID") = rowA("ID")
                ROWB("Cliente") = rowA("Cliente")

                If IsDBNull(rowA("Asesor")) Then
                    ROWB("Asesor") = "-"
                Else
                    ROWB("Asesor") = rowA("Asesor")
                End If

                If IsDBNull(rowA("CallCenter")) Then
                    ROWB("CallCenter") = "-"
                Else
                    ROWB("CallCenter") = rowA("CallCenter")
                End If

                ROWB("Ranking") = rowA("Ranking")
                ROWB("Nacimiento") = rowA("Nacimiento")
                ROWB("RFC") = rowA("RFC")
                ROWB("CURP") = rowA("CURP")
                ROWB("NSS") = rowA("NSS")

                DTB.Rows.Add(ROWB)
            Next
        End If

        BuscarClientes = DTB
    End Function
#End Region

#Region "Citas"
    Public Function ObtenerCampanas() As DataTable
        Dim Query As String = "SELECT id_campaña, campañaNombre
                               FROM campañas"

        ObtenerCampanas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerTipoCampana(ByVal IdCampana As Integer) As String
        Dim Query As String = String.Format("SELECT tipocampaña
                                             FROM campañas CP
                                             INNER JOIN tipocampaña TP ON TP.id_tipoCampaña = CP.id_tipoCampaña
                                             WHERE CP.id_campaña = {0}", IdCampana)

        ObtenerTipoCampana = GE_SQL.SQLGetDataStr(Query)
    End Function
#End Region
#Region "Reportes"
    Public Function Obtener_ReporteCalidad(ByVal FechaInicial As Date, ByVal FechaFin As Date) As DataTable
        Dim DTA As New DataTable
        Dim DTB As New DataTable

        Dim ROWA As DataRow

        Dim Query As String = "EXEC [dbo].[Reporte_Calidad]
		                            @FechaInicio = N'" & FechaInicial & "',
	                                @FechaFin = N'" & FechaFin & "'"

        DTA = GE_SQL.SQLGetTable(Query)

        DTB.Columns.AddRange({New DataColumn("ClienteId", GetType(String)), New DataColumn("ID_CRM", GetType(Integer)), New DataColumn("Numcte", GetType(String)), New DataColumn("Plaza", GetType(String)),
                              New DataColumn("Fraccionamiento", GetType(String)), New DataColumn("Proyecto", GetType(String)), New DataColumn("Mza", GetType(String)), New DataColumn("Lote", GetType(String)),
                              New DataColumn("TipoFraccionamiento", GetType(String)), New DataColumn("EsqFraccionamiento", GetType(String)), New DataColumn("Cliente", GetType(String)), New DataColumn("Contrato", GetType(String)),
                              New DataColumn("FechaEntrega", GetType(String)), New DataColumn("Telefono1", GetType(String)), New DataColumn("Telefono2", GetType(String)), New DataColumn("Empresa", GetType(String)),
                              New DataColumn("Departamento", GetType(String)), New DataColumn("Conyuge", GetType(String)), New DataColumn("Asesor", GetType(String)), New DataColumn("Integrador", GetType(String)),
                              New DataColumn("Titular", GetType(String)), New DataColumn("Responsable", GetType(String)), New DataColumn("Ranqueo", GetType(String)), New DataColumn("Visita", GetType(Date))})


        If DTA.Rows.Count <> 0 Then
            For j As Integer = 0 To DTA.Rows.Count - 1
                ROWA = DTB.NewRow
                ROWA("ClienteId") = DTA.Rows(j).Item("ClienteID")
                ROWA("ID_CRM") = DTA.Rows(j).Item("ID_CRM")
                ROWA("Numcte") = DTA.Rows(j).Item("Numcte")
                ROWA("Plaza") = DTA.Rows(j).Item("Plaza")
                ROWA("Fraccionamiento") = DTA.Rows(j).Item("Fraccionamiento")
                ROWA("Proyecto") = DTA.Rows(j).Item("Proyecto")
                ROWA("Mza") = DTA.Rows(j).Item("Mza")
                ROWA("Lote") = DTA.Rows(j).Item("Lote")
                ROWA("TipoFraccionamiento") = DTA.Rows(j).Item("Tipo_Fracc")
                ROWA("EsqFraccionamiento") = DTA.Rows(j).Item("EsqFracc")
                ROWA("Cliente") = DTA.Rows(j).Item("Cliente")
                ROWA("Contrato") = DTA.Rows(j).Item("Contrato")
                ROWA("FechaEntrega") = DTA.Rows(j).Item("FechaEntrega")
                ROWA("Telefono1") = DTA.Rows(j).Item("Telefono_1")
                ROWA("Telefono2") = DTA.Rows(j).Item("Telefono_2")
                ROWA("Empresa") = DTA.Rows(j).Item("Empresa")
                ROWA("Departamento") = DTA.Rows(j).Item("Departamento")
                ROWA("Conyuge") = DTA.Rows(j).Item("Conyuge")
                ROWA("Asesor") = DTA.Rows(j).Item("Asesor")
                ROWA("Integrador") = DTA.Rows(j).Item("Integrador")
                ROWA("Titular") = DTA.Rows(j).Item("Titular")
                ROWA("Responsable") = DTA.Rows(j).Item("Responsable")
                ROWA("Ranqueo") = DTA.Rows(j).Item("Ranqueo")
                ROWA("Visita") = DTA.Rows(j).Item("Visita")

                DTB.Rows.Add(ROWA)
            Next
        End If

        Return DTB
    End Function

    Public Function Obtener_ReporteCumplimiento(ByVal FechaInicial As Date, ByVal FechaFin As Date) As DataSet
        Dim ROW As DataRow
        Dim DTA As New DataTable
        Dim DTA_Proyectos As New DataTable
        Dim DTA_DatosCumplimiento As New DataTable
        Dim DTA_DetalleCumplimiento As New DataTable
        Dim DTS As New DataSet
        Dim Query As String = ""

        Query = "EXEC [dbo].[Obtener_Proyectos]"
        DTA_Proyectos = GE_SQL.SQLGetTable(Query)

        DTA.Columns.AddRange({New DataColumn("Proyecto", GetType(String)), New DataColumn("Cantidad", GetType(Integer)),
                              New DataColumn("Campana", GetType(String)), New DataColumn("TipoCampana", GetType(String))})

        If DTA_Proyectos.Rows.Count <> 0 Then
            For i As Integer = 0 To DTA_Proyectos.Rows.Count - 1
                Query = "EXEC [dbo].[Reporte_CumplimientoProyectoCampaña]
                                    @Proyecto = N'" & DTA_Proyectos.Rows(i).Item("abrev_fracc") & "',
		                            @FechaInicio = N'" & FechaInicial & "',
	                                @FechaFin = N'" & FechaFin & "'"
                DTA_DatosCumplimiento = GE_SQL.SQLGetTable(Query)

                If DTA_DatosCumplimiento.Rows.Count <> 0 Then
                    For j As Integer = 0 To DTA_DatosCumplimiento.Rows.Count - 1
                        ROW = DTA.NewRow
                        ROW("Proyecto") = DTA_Proyectos.Rows(i).Item("abrev_fracc")
                        ROW("Cantidad") = DTA_DatosCumplimiento.Rows(j).Item("Cantidad").ToString().Trim
                        ROW("Campana") = DTA_DatosCumplimiento.Rows(j).Item("Campana").ToString().Trim
                        ROW("TipoCampana") = DTA_DatosCumplimiento.Rows(j).Item("TipoCampana").ToString().Trim

                        DTA.Rows.Add(ROW)
                    Next
                End If
            Next
        End If
        DTA.TableName = "DTA_DatosCumplimiento"

        Dim DTB As New DataTable

        DTB.Columns.AddRange({New DataColumn("Semana", GetType(Integer)), New DataColumn("Asesor", GetType(String)), New DataColumn("Cliente", GetType(String)), New DataColumn("Ranking", GetType(String)),
                              New DataColumn("Prototipo", GetType(String)), New DataColumn("Fraccionamiento", GetType(String)), New DataColumn("FechaInicio", GetType(Date)),
                              New DataColumn("Etapa", GetType(String)), New DataColumn("campanaNombre", GetType(String))})

        For i As Integer = 0 To DTA_Proyectos.Rows.Count - 1
            Query = "EXEC [dbo].[Reporte_CumplimientoProyectoDetalles]
                                    @Proyecto = N'" & DTA_Proyectos.Rows(i).Item("abrev_fracc") & "',
		                            @FechaInicio = N'" & FechaInicial & "',
	                                @FechaFin = N'" & FechaFin & "'"
            DTA_DetalleCumplimiento = GE_SQL.SQLGetTable(Query)

            If DTA_DetalleCumplimiento.Rows.Count <> 0 Then
                For j As Integer = 0 To DTA_DetalleCumplimiento.Rows.Count - 1
                    ROW = DTB.NewRow
                    ROW("Semana") = DTA_DetalleCumplimiento.Rows(j).Item("semana")
                    ROW("Asesor") = DTA_DetalleCumplimiento.Rows(j).Item("asesor")
                    ROW("Cliente") = DTA_DetalleCumplimiento.Rows(j).Item("cliente")
                    ROW("Ranking") = DTA_DetalleCumplimiento.Rows(j).Item("Ranking")
                    ROW("Prototipo") = DTA_DetalleCumplimiento.Rows(j).Item("prototipo")
                    ROW("Fraccionamiento") = DTA_DetalleCumplimiento.Rows(j).Item("fraccionamiento")
                    ROW("FechaInicio") = DTA_DetalleCumplimiento.Rows(j).Item("fechaInicio")
                    ROW("Etapa") = DTA_DetalleCumplimiento.Rows(j).Item("etapa")
                    ROW("campanaNombre") = DTA_DetalleCumplimiento.Rows(j).Item("campañaNombre")

                    DTB.Rows.Add(ROW)
                Next
            End If
        Next
        DTB.TableName = "DTB_CumplimientoProyectoDetalles"
        DTS.Tables.Add(DTA)
        DTS.Tables.Add(DTB)

        Return DTS

    End Function
#End Region
End Class
