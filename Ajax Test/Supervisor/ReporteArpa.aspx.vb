Imports ClosedXML.Excel

Public Class ReporteArpa
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
        ViewState("GeneralesARPA") = Nothing

        If ValidarCampos() Then
            Dim FechaInicial As Date = deFechaInicial.Text
            Dim FechaFinal As Date = deFechaFinal.Text

            If FechaInicial > FechaFinal Then
                FechaInicial = deFechaFinal.Text
                FechaFinal = deFechaInicial.Text
            End If

            Dim DTA As New DataTable
            Dim ROWA As DataRow

            DTA.Columns.AddRange({New DataColumn("IDUsuario", GetType(Integer)), New DataColumn("Usuario", GetType(String)), New DataColumn("Nombre", GetType(String)),
                                  New DataColumn("Prospectos", GetType(Integer)), New DataColumn("Visitas", GetType(Integer)), New DataColumn("Separaciones", GetType(Integer)),
                                  New DataColumn("Cancelaciones_EK11", GetType(Integer)), New DataColumn("Separaciones_EK11", GetType(Integer)),
                                  New DataColumn("Prospecciones_EK11", GetType(Integer)), New DataColumn("Cancelaciones_EK18", GetType(Integer)),
                                  New DataColumn("Separaciones_EK18", GetType(Integer)), New DataColumn("Prospecciones_EK18", GetType(Integer))})

            Dim Usuarios = BL.Obtener_usuarios_todos()

            For i As Integer = 0 To Usuarios.Length - 1
                Dim CantidadPVS = BL.Obtener_DatosARPA(Usuarios(i).id_usuario, FechaInicial, FechaFinal)

                If CantidadPVS.Length > 0 Then
                    ROWA = DTA.NewRow
                    ROWA("IDUsuario") = Usuarios(i).id_usuario
                    ROWA("Usuario") = Usuarios(i).usuario
                    ROWA("Nombre") = Usuarios(i).nombre & " " & Usuarios(i).apellidoPaterno & " " & Usuarios(i).apellidoMaterno
                    ROWA("Prospectos") = CantidadPVS(0).Prospectos
                    ROWA("Visitas") = CantidadPVS(0).Visitas
                    ROWA("Separaciones") = CantidadPVS(0).Separaciones
                    ROWA("Cancelaciones_EK11") = 0
                    ROWA("Separaciones_EK11") = 0
                    ROWA("Prospecciones_EK11") = 0
                    ROWA("Cancelaciones_EK18") = 0
                    ROWA("Separaciones_EK18") = 0
                    ROWA("Prospecciones_EK18") = 0

                    DTA.Rows.Add(ROWA)
                End If
            Next

            Dim ROWB As DataRow
            Dim DTB As New DataTable

            DTB.Columns.AddRange({New DataColumn("numcte", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("empleado", GetType(Integer)),
                                  New DataColumn("agente", GetType(String)), New DataColumn("empleadoLider", GetType(Integer)), New DataColumn("lider", GetType(String)),
                                  New DataColumn("cancelacion", GetType(Date)), New DataColumn("cc", GetType(String)), New DataColumn("empresa", GetType(Integer)),
                                  New DataColumn("zona", GetType(String))})

            Dim CancelacionesEnkontrol = BL.Obtener_CancelacionesEnkontrol(FechaInicial, FechaFinal)

            If CancelacionesEnkontrol.Length > 0 Then
                For i As Integer = 0 To CancelacionesEnkontrol.Length - 1
                    ROWB = DTB.NewRow
                    ROWB("numcte") = CancelacionesEnkontrol(i).numeroCliente
                    ROWB("cliente") = CancelacionesEnkontrol(i).nombreCliente
                    ROWB("empleado") = CancelacionesEnkontrol(i).numeroAgente
                    ROWB("agente") = CancelacionesEnkontrol(i).nombreAgente
                    ROWB("empleadoLider") = CancelacionesEnkontrol(i).numeroLider
                    ROWB("lider") = CancelacionesEnkontrol(i).nombreLider
                    ROWB("cancelacion") = CancelacionesEnkontrol(i).fechaCancelacion
                    ROWB("cc") = CancelacionesEnkontrol(i).cc
                    ROWB("empresa") = CancelacionesEnkontrol(i).empresa
                    ROWB("zona") = CancelacionesEnkontrol(i).zona

                    DTB.Rows.Add(ROWB)
                Next
            End If

            Dim ROWC As DataRow
            Dim DTC As New DataTable

            DTC.Columns.AddRange({New DataColumn("numcte", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("empleado", GetType(Integer)),
                                  New DataColumn("agente", GetType(String)), New DataColumn("empleadoLider", GetType(Integer)), New DataColumn("lider", GetType(String)),
                                  New DataColumn("cc", GetType(String)), New DataColumn("empresa", GetType(Integer)), New DataColumn("zona", GetType(String))})

            Dim SeparacionesEnkontrol = BL.Obtener_SeparacionesEnkontrol(FechaInicial, FechaFinal)

            If SeparacionesEnkontrol.Length > 0 Then
                For i As Integer = 0 To SeparacionesEnkontrol.Length - 1
                    ROWC = DTC.NewRow
                    ROWC("numcte") = SeparacionesEnkontrol(i).numeroCliente
                    ROWC("cliente") = SeparacionesEnkontrol(i).cliente
                    ROWC("empleado") = SeparacionesEnkontrol(i).numeroAgente
                    ROWC("agente") = SeparacionesEnkontrol(i).agente
                    ROWC("empleadoLider") = SeparacionesEnkontrol(i).numeroLider
                    ROWC("lider") = SeparacionesEnkontrol(i).nombreLider
                    ROWC("cc") = SeparacionesEnkontrol(i).cc
                    ROWC("empresa") = SeparacionesEnkontrol(i).empresa
                    ROWC("zona") = SeparacionesEnkontrol(i).zona

                    DTC.Rows.Add(ROWC)
                Next
            End If

            Dim ROWD As DataRow
            Dim DTD As New DataTable

            DTD.Columns.AddRange({New DataColumn("numcte", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("empleado", GetType(Integer)),
                                  New DataColumn("agente", GetType(String)), New DataColumn("empleadoLider", GetType(Integer)), New DataColumn("lider", GetType(String)),
                                  New DataColumn("cc", GetType(String)), New DataColumn("empresa", GetType(Integer)), New DataColumn("zona", GetType(String))})

            Dim ProspeccionesEnkontrol = BL.Obtener_ProspeccionesEnkontrol(FechaInicial, FechaFinal)

            If ProspeccionesEnkontrol.Length > 0 Then
                For i As Integer = 0 To ProspeccionesEnkontrol.Length - 1
                    ROWD = DTD.NewRow
                    ROWD("numcte") = ProspeccionesEnkontrol(i).numeroCliente
                    ROWD("cliente") = ProspeccionesEnkontrol(i).cliente
                    ROWD("empleado") = ProspeccionesEnkontrol(i).numeroAgente
                    ROWD("agente") = ProspeccionesEnkontrol(i).agente
                    ROWD("empleadoLider") = ProspeccionesEnkontrol(i).numeroLider
                    ROWD("lider") = ProspeccionesEnkontrol(i).nombreLider
                    ROWD("cc") = ProspeccionesEnkontrol(i).cc
                    ROWD("empresa") = ProspeccionesEnkontrol(i).empresa
                    ROWD("zona") = ProspeccionesEnkontrol(i).zona

                    DTD.Rows.Add(ROWD)
                Next
            End If

            Dim ROWE As DataRow
            Dim DTE As New DataTable

            DTE.Columns.AddRange({New DataColumn("idCliente", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("idUsuario", GetType(Integer)),
                                  New DataColumn("usuario", GetType(String)), New DataColumn("idSupervisor", GetType(Integer)), New DataColumn("supervisor", GetType(String)),
                                  New DataColumn("fechaCreacion", GetType(Date))})

            Dim ProspeccionesCRM = BL.Obtener_ProspeccionesCRM(FechaInicial, FechaFinal)

            If ProspeccionesCRM.Length > 0 Then
                For i As Integer = 0 To ProspeccionesCRM.Length - 1
                    ROWE = DTE.NewRow
                    ROWE("idCliente") = ProspeccionesCRM(i).idCliente
                    ROWE("cliente") = ProspeccionesCRM(i).nombreCliente
                    ROWE("idUsuario") = ProspeccionesCRM(i).idUsuario
                    ROWE("usuario") = ProspeccionesCRM(i).nombreUsuario
                    ROWE("idSupervisor") = ProspeccionesCRM(i).idSupervisor
                    ROWE("supervisor") = ProspeccionesCRM(i).nombreSupervisor
                    ROWE("fechaCreacion") = ProspeccionesCRM(i).fechaCreacion

                    DTE.Rows.Add(ROWE)
                Next
            End If

            Dim ROWF As DataRow
            Dim DTF As New DataTable

            DTF.Columns.AddRange({New DataColumn("idCliente", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("idUsuario", GetType(Integer)),
                                  New DataColumn("usuario", GetType(String)), New DataColumn("idSupervisor", GetType(Integer)), New DataColumn("supervisor", GetType(String)),
                                  New DataColumn("fechaCreacion", GetType(Date)), New DataColumn("fechaUltimaVisita", GetType(Date))})

            Dim VisitasCRM = BL.Obtener_VisitasCRM(FechaInicial, FechaFinal)

            If VisitasCRM.Length > 0 Then
                For i As Integer = 0 To VisitasCRM.Length - 1
                    ROWF = DTF.NewRow
                    ROWF("idCliente") = VisitasCRM(i).idCliente
                    ROWF("cliente") = VisitasCRM(i).nombreCliente
                    ROWF("idUsuario") = VisitasCRM(i).idUsuario
                    ROWF("usuario") = VisitasCRM(i).nombreUsuario
                    ROWF("idSupervisor") = VisitasCRM(i).idSupervisor
                    ROWF("supervisor") = VisitasCRM(i).nombreSupervisor
                    ROWF("fechaCreacion") = VisitasCRM(i).fechaCreacion
                    ROWF("fechaUltimaVisita") = VisitasCRM(i).fechaUltimaVisita

                    DTF.Rows.Add(ROWF)
                Next
            End If

            Dim ROWG As DataRow
            Dim DTG As New DataTable

            DTG.Columns.AddRange({New DataColumn("idCliente", GetType(Integer)), New DataColumn("cliente", GetType(String)), New DataColumn("idUsuario", GetType(Integer)),
                                  New DataColumn("usuario", GetType(String)), New DataColumn("idSupervisor", GetType(Integer)), New DataColumn("supervisor", GetType(String)),
                                  New DataColumn("fechaCreacion", GetType(Date)), New DataColumn("fechaUltimaVisita", GetType(Date)), New DataColumn("fechaCierre", GetType(Date))})

            Dim SeparacionesCRM = BL.Obtener_SeparacionesCRM(FechaInicial, FechaFinal)

            If SeparacionesCRM.Length > 0 Then
                For i As Integer = 0 To SeparacionesCRM.Length - 1
                    ROWG = DTG.NewRow
                    ROWG("idCliente") = SeparacionesCRM(i).idCliente
                    ROWG("cliente") = SeparacionesCRM(i).nombreCliente
                    ROWG("idUsuario") = SeparacionesCRM(i).idUsuario
                    ROWG("usuario") = SeparacionesCRM(i).nombreUsuario
                    ROWG("idSupervisor") = SeparacionesCRM(i).idSupervisor
                    ROWG("supervisor") = SeparacionesCRM(i).nombreSupervisor
                    ROWG("fechaCreacion") = SeparacionesCRM(i).fechaCreacion
                    ROWG("fechaUltimaVisita") = SeparacionesCRM(i).fechaUltimaVisita
                    ROWG("fechaCierre") = SeparacionesCRM(i).fechaCierre

                    DTG.Rows.Add(ROWG)
                Next
            End If

            Dim Index As Integer = 0
            Dim RowResult() As DataRow

            For Each row As DataRow In DTB.Rows
                RowResult = DTA.Select("Usuario = " & row("empleado"))

                For Each rowR As DataRow In RowResult
                    Select Case row("empresa")
                        Case 11
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Cancelaciones_EK11") = DTA.Rows(Index).Item("Cancelaciones_EK11") + 1
                        Case 18
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Cancelaciones_EK18") = DTA.Rows(Index).Item("Cancelaciones_EK18") + 1
                    End Select
                Next
            Next

            RowResult = Nothing

            For Each row As DataRow In DTC.Rows
                RowResult = DTA.Select("Usuario = " & row("empleado"))

                For Each rowR As DataRow In RowResult
                    Select Case row("empresa")
                        Case 11
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Separaciones_EK11") = DTA.Rows(Index).Item("Separaciones_EK11") + 1
                        Case 18
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Separaciones_EK18") = DTA.Rows(Index).Item("Separaciones_EK18") + 1
                    End Select
                Next
            Next

            RowResult = Nothing

            For Each row As DataRow In DTD.Rows
                RowResult = DTA.Select("Usuario = " & row("empleado"))

                For Each rowR As DataRow In RowResult
                    Select Case row("empresa")
                        Case 11
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Prospecciones_EK11") = DTA.Rows(Index).Item("Prospecciones_EK11") + 1
                        Case 18
                            Index = DTA.Rows.IndexOf(rowR)
                            DTA.Rows(Index).Item("Prospecciones_EK18") = DTA.Rows(Index).Item("Prospecciones_EK11") + 1
                    End Select
                Next
            Next

            RowResult = Nothing

            Dim DSG As New DataSet
            DSG.Tables.AddRange({DTA, DTB, DTC, DTD, DTE, DTF, DTG})

            ViewState("GeneralesARPA") = DSG

            GV_ArpaData.DataSource = DTA
            GV_ArpaData.DataBind()
        End If
    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim DSG As New DataSet
        DSG = CType(ViewState("GeneralesARPA"), DataSet)

        Using wb As New XLWorkbook()
            wb.Worksheets.Add(DSG.Tables(0).Copy, "PVSCS")
            wb.Worksheets.Add(DSG.Tables(1).Copy, "Cancelaciones_EK")
            wb.Worksheets.Add(DSG.Tables(2).Copy, "Separaciones_EK")
            wb.Worksheets.Add(DSG.Tables(3).Copy, "Prospectaciones_EK")
            wb.Worksheets.Add(DSG.Tables(4).Copy, "Prospectaciones_CRM")
            wb.Worksheets.Add(DSG.Tables(5).Copy, "Visitas_CRM")
            wb.Worksheets.Add(DSG.Tables(6).Copy, "Separaciones_CRM")

            wb.SaveAs(Ruta & "GeneralesARPA" & XLS)
        End Using

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=GeneralesARPA" & XLS)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        HttpContext.Current.Response.WriteFile(Ruta & "GeneralesARPA" & XLS)
        DSG = Nothing
        HttpContext.Current.Response.End()
    End Sub
#End Region
End Class