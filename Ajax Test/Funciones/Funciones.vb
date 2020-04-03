Imports System.IO
Imports Ajax_Test.SQL_Functions

Public Class Funciones
    Private GE_SQL As New SQL_Functions
    Private ROOT_GESQL As String = ConfigurationManager.ConnectionStrings("RutaSQLS").ConnectionString

#Region "Estructuras"
    Public Structure DatosCita
        Dim IdCita As Integer
        Dim IdCliente As Integer
        Dim IdUsuario As Integer
        Dim IdUsuarioAsignado As Integer
        Dim IdCampana As Integer
        Dim Origen As String
        Dim LugarContacto As String
        Dim Medio As String
        Dim TipoCampana As String
        Dim Fraccionamiento As String
        Dim Modelo As String
        Dim Proyecto As String
        Dim FechaCita As Date
        Dim Asesor As String
        Dim AsesorAsignado As String
        Dim TipoCredito As String
    End Structure

    Public Structure BusquedaCliente
        Dim nombreCliente As String
        Dim apellidoMaterno As String
        Dim apellidoPaterno As String
        Dim RFC As String
        Dim CURP As String
        Dim NSS As String
        Dim IdCliente As String
        Dim Numcte As String
        Dim Numcte2 As String
    End Structure

    Public Structure BusquedaClienteAsesor
        Dim nombreCliente As String
        Dim apellidoMaterno As String
        Dim apellidoPaterno As String
        Dim RFC As String
        Dim CURP As String
        Dim NSS As String
        Dim IdCliente As String
        Dim IdUsuario As String
        Dim Numcte As String
    End Structure

    Public Structure BusquedaUsuarios
        Dim nombreUsuario As String
        Dim apellidoMaterno As String
        Dim apellidoPaterno As String
        Dim Email As String
        Dim fecahCreacion As Date
        Dim Usuario As String
        Dim IdUsuario As String
    End Structure

    Public Structure ArchivosSQL
        Dim NombreDocumento As String
    End Structure

    Public Structure CitaVigente
        Dim ExisteCitaVigente As String
    End Structure

    Public Structure VisitaVigente
        Dim ExisteVisitaVigente As Boolean
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

    Public Function Obtener_DocumentosSQL() As List(Of ArchivosSQL)
        Dim Result As New List(Of ArchivosSQL)

        Try
            Dim Documentos() As String = Directory.GetFiles(ROOT_GESQL)
            Dim Docs As ArchivosSQL

            For i As Integer = 0 To Documentos.Length - 1
                Docs = New ArchivosSQL

                Docs.NombreDocumento = Documentos(i).ToUpper
                Result.Add(Docs)
            Next
        Catch ex As Exception
            Result = Nothing
        End Try

        Return Result
    End Function
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

    Public Class DatosConsulta
        Public DT As DataTable
        Public Resultado As String
    End Class

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

    Public Function BuscarClientesEK2(ByVal Cliente As BusquedaCliente) As DataTable
        Dim Query As String = "EXEC [dbo].[BuscarClientesEK2]
		                            @Nombre = N'" & Cliente.nombreCliente & "',
		                            @ApellidoPaterno = N'" & Cliente.apellidoPaterno & "',
		                            @ApellidoMaterno = N'" & Cliente.apellidoMaterno & "',
		                            @rfcCliente = N'" & Cliente.RFC & "',
		                            @curpCliente = N'" & Cliente.CURP & "',
		                            @nssCliente = N'" & Cliente.NSS & "',
                                    @IdCrm = N'" & Cliente.IdCliente & "',
                                    @NumCliente = N'" & Cliente.Numcte & "',
	                                @NumCliente2 = N'" & Cliente.Numcte2 & "'"

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

        BuscarClientesEK2 = DTB
    End Function

    Public Function BuscarClientesXAsesor(ByVal Cliente As BusquedaClienteAsesor)
        Dim Query As String = "EXEC [dbo].[BuscarClientesXAsesor]
		                            @Nombre = N'" & Cliente.nombreCliente & "',
		                            @ApellidoPaterno = N'" & Cliente.apellidoPaterno & "',
		                            @ApellidoMaterno = N'" & Cliente.apellidoMaterno & "',
		                            @rfcCliente = N'" & Cliente.RFC & "',
		                            @curpCliente = N'" & Cliente.CURP & "',
		                            @nssCliente = N'" & Cliente.NSS & "',
                                    @IdCrm = N'" & Cliente.IdCliente & "',
                                    @IdAsesor = N'" & Cliente.IdUsuario & "',
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

        BuscarClientesXAsesor = DTB
    End Function

    Public Function BuscarUsuario(ByVal Usuario As BusquedaUsuarios) As DataTable
        Dim Query As String = "EXEC [dbo].[BuscarUsuario]
		                            @Nombre = N'" & Usuario.nombreUsuario & "',
		                            @ApellidoPaterno = N'" & Usuario.apellidoPaterno & "',
		                            @ApellidoMaterno = N'" & Usuario.apellidoMaterno & "',
                                    @IdCrm = N'" & Usuario.IdUsuario & "'"

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim ROWB As DataRow

        DTB.Columns.AddRange({New DataColumn("ID", GetType(Integer)), New DataColumn("UsuarioNombre", GetType(String)), New DataColumn("Email", GetType(String)),
                               New DataColumn("Usuario", GetType(String)), New DataColumn("fechaCreacion", GetType(Date))})

        DTA = GE_SQL.SQLGetTable(Query)
        If DTA.Rows.Count > 0 Then
            For Each rowA As DataRow In DTA.Rows
                ROWB = DTB.NewRow
                ROWB("ID") = rowA("ID")
                ROWB("UsuarioNombre") = rowA("UsuarioNombre")
                ROWB("Email") = rowA("Email")
                ROWB("Usuario") = rowA("Usuario")
                ROWB("fechaCreacion") = rowA("fechaCreacion")

                DTB.Rows.Add(ROWB)
            Next
        End If

        BuscarUsuario = DTB
    End Function

    Public Function BuscarSupervisores() As DataTable
        Dim Query As String = "EXEC [dbo].[Obtener_supervisores]"

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim ROWB As DataRow

        DTB.Columns.AddRange({New DataColumn("id_supervisor", GetType(Integer)), New DataColumn("supervisor", GetType(String))})

        DTA = GE_SQL.SQLGetTable(Query)
        If DTA.Rows.Count > 0 Then
            ROWB = DTB.NewRow
            ROWB("id_supervisor") = "0"
            ROWB("supervisor") = "Seleccione supervisor"
            DTB.Rows.Add(ROWB)
            For Each rowA As DataRow In DTA.Rows
                ROWB = DTB.NewRow
                ROWB("id_supervisor") = rowA("id_supervisor")
                ROWB("supervisor") = rowA("supervisor")

                DTB.Rows.Add(ROWB)
            Next
        End If

        BuscarSupervisores = DTB
    End Function
#End Region

#Region "Citas"
    Public Function Obtener_Usuarios() As DataTable
        Dim Query As String = "SELECT dbo.usuarios.id_usuario, 
                                      CONCAT(dbo.usuarios.nombre,' ',
                                             dbo.usuarios.apellidoPaterno,' ',
                                             dbo.usuarios.apellidoMaterno,' (',usuarios.usuario,')') AS nombre
                               FROM dbo.usuarios
                              INNER JOIN  TipoUsuarios tu ON  usuarios.id_tipoUsuario= tu.id_tipoUsuario
                               WHERE activo = 1 AND tu.id_tipoUsuario  IN (1, 5)
                               ORDER BY nombre ASC"

        Obtener_Usuarios = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerMedios() As DataTable
        Dim Query As String = "SELECT Id_Medio, NombreMedio 
                               FROM CampanasMedios"

        ObtenerMedios = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerOrigenCitas() As DataTable
        Dim Query As String = "SELECT  DISTINCT(Origen) FROM CitasClientes"

        ObtenerOrigenCitas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerCampanas(Optional ByVal Id_Medio As Integer = 0) As DataTable
        Dim Query As String = "SELECT id_campaña, campañaNombre
                               FROM campañas
                               WHERE Activa = 1"

        If Id_Medio > 0 Then Query += " AND Id_Medio = " & Id_Medio
        Query += "ORDER BY campañaNombre"

        ObtenerCampanas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerCampanasTipoCampana(Optional ByVal Id_Medio As Integer = 0) As DataTable
        Dim Query As String = "SELECT  campañas.id_campaña, campañas.campañaNombre, tipocampaña.TipoCampaña
                                FROM campañas  
                                INNER JOIN tipocampaña ON tipocampaña.id_tipoCampaña = campañas.id_tipoCampaña
                                WHERE Activa= 1"

        If Id_Medio > 0 Then Query += " AND Id_Medio = " & Id_Medio
        Query += "ORDER BY campañaNombre"

        ObtenerCampanasTipoCampana = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function ObtenerCampanasId(ByVal Id_Campana As Integer) As DataTable
        Dim Query As String = "SELECT  id_campaña, campañaNombre,id_tipoCampaña, fechaCreacion,
                                       Observaciones, Activa, FechaInic, FechaFin, Id_Medio 
                               FROM campañas WHERE id_campaña= " & Id_Campana

        ObtenerCampanasId = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Actualiza_Campanas(ByVal id_campaña As Integer, ByVal campañaNombre As String, ByVal id_tipoCampaña As Integer, ByVal id_MedioCampaña As Integer, ByVal Activa As Integer,
                                       ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal Observaciones As String) As Boolean

        Dim Query As String = " EXEC [dbo].[Actualiza_Campanas]
                                   @Pid_campaña = N'" & id_campaña & "',
                                   @PcampañaNombre = N'" & campañaNombre & "',
                                   @Pid_tipoCampaña = N'" & id_tipoCampaña & "',
                                   @Pid_MedioCampaña = N'" & id_MedioCampaña & "',
                                   @PActiva = N'" & Activa & "',
                                   @PfechaInicio = N'" & fechaInicio & "',
                                   @PfechaFinal = N'" & fechaFinal & "',
                                   @PObservaciones = N'" & Observaciones & "'"

        If (GE_SQL.SQLGetDataDbl(Query) = 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Actualiza_UsuarioAsignado(ByVal Id_Usuario As Integer, ByVal Id_Cita As Integer) As Boolean
        Dim Query As String = ""

        Query = " UPDATE CitasClientes "
        Query = Query + " SET Id_UsuarioAsignado=" & Id_Usuario & ", Id_Supervisor_UsuarioAsignado= (SELECT id_supervisor FROM usuarios WHERE id_usuario= " & Id_Usuario & ")"
        Query = Query + " WHERE Id_Cita =" & Id_Cita

        Actualiza_UsuarioAsignado = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_UsuarioRegistro_Cita(ByVal Id_Usuario As Integer, ByVal Id_Cita As Integer, ByVal Id_Cliente As Integer) As Boolean
        Dim Query As String = ""

        Query = " UPDATE CitasClientes "
        Query = Query + " SET  Id_Usuario=" & Id_Usuario & ",  Id_Supervisor_Usuario= (SELECT id_supervisor FROM usuarios WHERE id_usuario= " & Id_Usuario & ")"
        Query = Query + " WHERE Id_Cita =" & Id_Cita & ";"

        Query = Query + " UPDATE clientes "
        Query = Query + " SET  id_usuarioOriginal=" & Id_Usuario
        Query = Query + " WHERE Id_Cliente =" & Id_Cliente


        Actualiza_UsuarioRegistro_Cita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_Origen_Cita(ByVal Origen As String, ByVal Id_Cita As Integer) As Boolean
        Dim Query As String = ""

        Query = " UPDATE CitasClientes "
        Query = Query + " Set  Origen='" & Origen & "'"
        Query = Query + " WHERE Id_Cita =" & Id_Cita

        Actualiza_Origen_Cita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_Campana(ByVal IdCampana As Integer, ByVal Campana As String, ByVal TipoCampana As String, ByVal Id_Cita As Integer) As Boolean
        Dim Query As String = ""

        Query = " EXEC [dbo].[Actualiza_Campana_CitasClientes]
                                   @IdCampana = N'" & IdCampana & "',
                                   @Campana = N'" & Campana & "',
                                   @TCampana = N'" & TipoCampana & "',
                                   @cita = N'" & Id_Cita & "'"
        Actualiza_Campana = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_FechaCita(ByVal fechaCita As Date, ByVal Id_Cita As Integer) As Boolean
        Dim Query As String = ""
        fechaCita.ToString("yyyy-MM-dd")

        Query = "  UPDATE CitasClientes  "
        Query = Query + " SET FechaCita='" & fechaCita.ToString("yyyy-MM-dd") & "', VigenciaInicial= '" & fechaCita.ToString("yyyy-MM-dd") & "', VigenciaFinal='" & fechaCita.AddDays(30).ToString("yyyy-MM-dd") & "' WHERE Id_Cita= " & Id_Cita

        Actualiza_FechaCita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Obtener_Proyectos() As DataTable
        Dim Query As String = "SELECT DISTINCT(abrev_fracc) Proyecto, Fraccionamiento
                               FROM productos
                               WHERE Estatus=1
                               ORDER BY Proyecto"

        Obtener_Proyectos = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_ModelosXProyecto(ByVal Proyecto As String) As DataTable
        Dim Query As String = "SELECT id_producto, NombreCorto Modelo
                               FROM productos 
                               WHERE abrev_fracc = '" & Proyecto & "'
                               ORDER BY Modelo"

        Obtener_ModelosXProyecto = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_TipoCampana(ByVal IdCampana As Integer) As String
        Dim Query As String = String.Format("SELECT tipocampaña
                                             FROM campañas CP
                                             INNER JOIN tipocampaña TP ON TP.id_tipoCampaña = CP.id_tipoCampaña
                                             WHERE CP.id_campaña = {0}", IdCampana)


        Obtener_TipoCampana = GE_SQL.SQLGetDataStr(Query)
    End Function

    Public Function Obtener_CitasCliente(ByVal IdCliente As Integer) As DataTable
        Dim Query As String = "SELECT CCL.Id_Cita, CCL.Origen, CCL.LugarContacto, CCL.TipoCampana, CCL.Proyecto,
	                                  PR.Fraccionamiento, CCl.VigenciaInicial, CCl.VigenciaFinal, CCL.FechaCita, CCL.Status,
	                                  CONCAT(CL.Nombre, ' ', CL.ApellidoPaterno, ' ', CL.ApellidoMaterno) Cliente,
	                                  CONCAT(US.Nombre, ' ', US.ApellidoPaterno, ' ', US.ApellidoMaterno) Asesor,
	                                  CONCAT(UA.Nombre, ' ', UA.ApellidoPaterno, ' ', UA.ApellidoMaterno) AsesorAsignado                                   
                               FROM Clientes CL
                               INNER JOIN CitasClientes CCL ON CCL.Id_Cliente = CL.id_cliente
                               INNER JOIN usuarios US ON US.id_usuario =  CCL.Id_Usuario
                               INNER JOIN usuarios UA ON UA.id_usuario =  CCL.Id_UsuarioAsignado
                               INNER JOIN campañas CP ON CP.id_campaña =  CCL.Id_Campana
                               INNER JOIN productos PR ON PR.id_producto =  CCL.Modelo
                               WHERE CCL.Id_Cliente = " & IdCliente

        Obtener_CitasCliente = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_CitasActivasCliente(ByVal IdCliente As Integer) As DataTable
        Dim Query As String = "SELECT CCL.Id_Cita, CONCAT(CL.Nombre, ' ', CL.ApellidoPaterno, ' ', CL.ApellidoMaterno) Cliente, CCL.Origen, CCL.LugarContacto, CCL.TipoCampana, CCL.Proyecto, 
	                                  PR.Fraccionamiento, CCl.VigenciaInicial, CCl.VigenciaFinal, CCL.FechaCita, CONCAT(US.Nombre, ' ', US.ApellidoPaterno, ' ', US.ApellidoMaterno) Usuario_Asignado,CCL.Status
                               FROM Clientes CL
                               INNER JOIN CitasClientes CCL ON CCL.Id_Cliente = CL.id_cliente
                               INNER JOIN campañas CP ON CP.id_campaña =  CCL.Id_Campana
                               INNER JOIN productos PR ON PR.id_producto =  CCL.Modelo
                               LEFT JOIN usuarios US ON CCL.Id_UsuarioAsignado=US.id_usuario
                               WHERE CCL.Id_Cliente = " & IdCliente & " AND CCL.Status = 1"

        Obtener_CitasActivasCliente = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_OperacionesCierre(ByVal IdCliente As Integer) As Integer
        Dim Query As String = String.Format("SELECT id_operacion FROM operaciones  WHERE id_cliente = {0} AND id_etapa= 5", IdCliente)
        Obtener_OperacionesCierre = GE_SQL.SQLGetDataDbl(Query)
    End Function

    Public Function Obtener_EstatusCita(ByVal IdCita As Integer) As Integer
        Dim Query As String = String.Format("SELECT Status FROM CitasClientes WHERE Id_Cita = {0}", IdCita)
        Obtener_EstatusCita = GE_SQL.SQLGetDataDbl(Query)
    End Function

    Public Function Obtener_ObservacionesCitas(ByVal IdCita As Integer) As DataTable
        Dim Query As String = "SELECT CONCAT(US.nombre, ' ', US.apellidoPaterno, ' ', US.apellidoMaterno) Usuario, CO.Observaciones, CO.Creacion
                               FROM CitasObservaciones CO
                               INNER JOIN usuarios US ON US.id_usuario = CO.Id_Usuario
                               WHERE CO.Id_Cita = " & IdCita

        Obtener_ObservacionesCitas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Sub Verificar_VigenciaCitas(ByVal IdCliente As Integer)
        Dim Query As String = ""
        Dim DT As New DataTable

        DT = Obtener_CitasCliente(IdCliente)
        For Each Row As DataRow In DT.Rows
            Query += "EXEC [dbo].[Verificar_VigenciaCitas]
                        @pId_Cita = " & Row("Id_Cita") & ";"
        Next

        GE_SQL.SQLExecSQL(Query, SQL_Functions.TipoTransaccion.UniqueTransaction)
    End Sub

    Public Function Citas_Vigentes(ByVal IdCliente As Integer) As CitaVigente
        Dim CitaVigente As New CitaVigente
        Dim DTA As DataTable = New DataTable

        Dim Query As String = "SELECT Id_Cita FROM CitasClientes WHERE Status = 1 AND Id_Cliente=" & IdCliente

        DTA = GE_SQL.SQLGetTable(Query)

        If DTA.Rows.Count > 0 Then
            CitaVigente.ExisteCitaVigente = True
        Else
            CitaVigente.ExisteCitaVigente = False
        End If

        Return CitaVigente
    End Function

    Public Function Obtener_ListadoCitas(ByVal IdUsuario As Integer) As DataTable
        Dim Query As String = ""

        Query = "EXEC [dbo].[Obtener_Citas_idUsuario]
                            @PidUsuario = " & IdUsuario & ";"

        Obtener_ListadoCitas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_ListadoCitasAsignadas(ByVal IdUsuario As Integer) As DataTable
        Dim Query As String = ""

        Query = "EXEC [dbo].[Obtener_CitasAsignadas_idUsuario]
                            @PidUsuario = " & IdUsuario & ";"

        Obtener_ListadoCitasAsignadas = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Valida_PrimerCita(ByVal NivelUsuario As Integer, ByVal idCliente As Integer) As Boolean
        Dim dta_CitasCliente As DataTable = New DataTable
        Dim dta_TipoUsuario As DataTable = New DataTable
        Dim UsuarioRegistroCliente As Integer = 0
        dta_CitasCliente = Obtener_CitasCliente(idCliente)

        If dta_CitasCliente.Rows.Count > 0 Then
            Return True
        Else
            UsuarioRegistroCliente = Obtener_TipoUsuarioRegCliente(idCliente)
            If UsuarioRegistroCliente = 4 Then
                If NivelUsuario = UsuarioRegistroCliente Then '' valida que el usuario que desea registrar la primer cita sea un call center
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
    End Function

    Public Function Obtener_TipoUsuarioRegCliente(ByVal IdCliente As Integer) As Integer
        ' obtiene el tipo de ususario que registro por primera ves al cliente
        ' si el cliente tiene un  fecha de creacion menor de 2019-03-19(fecha creacion de esa tabla)
        ' se toma en cuenta el  campo de usuario original del  registro del cliente
        ' no existe otra forma de saber que tipo de usuario dio de alta a ese registro


        Dim Query As String = "SELECT  fechaCreacion FROM  clientes WHERE id_cliente=" & IdCliente
        If CDate(GE_SQL.SQLGetTable(Query).Rows(0).Item(0)) < CDate("2019-03-19") Then
            Query = "SELECT  usuarios.id_tipoUsuario
                    FROM  clientes 
                    INNER JOIN  usuarios ON usuarios.id_usuario= clientes.id_usuarioOriginal
                    WHERE clientes.id_cliente =" & IdCliente
        Else
            Query = "SELECT usuarios.id_tipoUsuario
                     FROM  Clientes_RegistroLog
                     INNER JOIN usuarios ON usuarios.id_usuario= Clientes_RegistroLog.Id_Usuario
                     INNER JOIN TipoUsuarios ON TipoUsuarios.id_tipoUsuario= usuarios.id_tipoUsuario
                     WHERE Id_Cliente =" & IdCliente
        End If
        Obtener_TipoUsuarioRegCliente = GE_SQL.SQLGetDataDbl(Query)

    End Function

    Public Function Actualiza_Estatus_Citas() As Boolean
        Dim Query As String = ""
        Query = " EXECUTE  [dbo].[sp_MToolVigenciaCitas]"

        Actualiza_Estatus_Citas = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function
#End Region

#Region "Visitas"
    Public Function Visitas_Vigentes(ByVal IdCliente As Integer) As VisitaVigente
        Dim VisitaVigente As New VisitaVigente
        Dim DTA As DataTable = New DataTable

        Dim Query As String = "SELECT Id_Visita FROM VisitasClientes WHERE Status = 1  AND Id_Cliente = " & IdCliente

        DTA = GE_SQL.SQLGetTable(Query)

        If DTA.Rows.Count > 0 Then
            VisitaVigente.ExisteVisitaVigente = True
        Else
            VisitaVigente.ExisteVisitaVigente = False
        End If
        Return VisitaVigente
    End Function

    Public Function Obtener_DatosCita(ByVal Id_Cita As Integer) As DatosCita
        Dim Query As String = String.Format("EXEC [dbo].[Obtener_DetallesCitas]
                                                   @pIdCita = {0}", Id_Cita)

        Dim DTA As New DataTable
        DTA = GE_SQL.SQLGetTable(Query)

        Dim Resultado As New DatosCita
        Try
            For Each row As DataRow In DTA.Rows
                Resultado.IdCita = row("Id_Cita")
                Resultado.IdCliente = row("Id_Cliente")
                Resultado.IdUsuario = row("Id_Usuario")
                Resultado.IdUsuarioAsignado = row("Id_UsuarioAsignado")
                Resultado.IdCampana = row("Id_Campana")
                Resultado.Origen = row("Origen")
                Resultado.LugarContacto = row("LugarContacto")
                Resultado.Medio = row("Medio")
                Resultado.TipoCampana = row("TipoCampana")
                Resultado.Fraccionamiento = row("Fraccionamiento")
                Resultado.Modelo = row("Modelo")
                Resultado.Proyecto = row("Proyecto")
                Resultado.FechaCita = row("FechaCita")
                Resultado.Asesor = row("Asesor")
                Resultado.AsesorAsignado = row("AsesorAsignado")

                If IsDBNull(row("TipoCredito")) Then
                    Resultado.TipoCredito = "N/A"
                Else
                    Resultado.TipoCredito = row("tipocredito")
                End If
            Next
        Catch ex As Exception
            Resultado = Nothing
        End Try

        Return Resultado
    End Function

    Public Function Insertar_VisitasClientes(ByVal IdCita As Integer, ByVal IdCliente As Integer, ByVal IdUsuario As Integer, ByVal IdUsuarioAsignado As Integer, ByVal IdUsuarioVisita As Integer,
                                      ByVal IdCampana As Integer, ByVal IdImpedimento As Integer, ByVal TipoCredito As String, ByVal TipoVisita As Integer, ByVal Monto As Double, ByVal Ranking As String,
                                      ByVal Origen As String, ByVal Proyecto As String, ByVal Modelo As Integer, ByVal TipoCampana As String, ByVal VigenciaIncial As Date,
                                      ByVal VigenciaFinal As Date, ByVal FechaVisita As Date, ByVal Status As Integer) As Boolean

        Dim Query As String = String.Format("EXEC [dbo].[Insertar_VisitasClientes]
                                                   @pIdCita = {0},
                                                   @pIdCliente = {1},
                                                   @pIdUsuario = {2},
                                                   @pIdUsuarioAsignado = {3},
                                                   @pIdUsuarioVisita = {4},
                                                   @pIdCampana = {5},
                                                   @pIdImpedimento = {6},
                                                   @pIdTipoVisita = {8}
                                                   @pTipoCredito = N'{7}',
                                                   @pMonto = {9},
                                                   @pRanking = N'{10}',
                                                   @pOrigen = N'{11}',
                                                   @pProyecto = N'{12}',
                                                   @pModelo = {13},
                                                   @pTipoCampana = N'{14}',
                                                   @pVigenciaInicial = '{15}',
                                                   @pVigenciaFinal = '{16}',
                                                   @pFechaVisita = '{17}',
                                                   @pStatus = {18}", IdCita, IdCliente, IdUsuario, IdUsuarioAsignado, IdUsuarioVisita, IdCampana, IdImpedimento, TipoCredito, TipoVisita, Monto,
                                                                     Ranking, Origen, Proyecto, Modelo, TipoCampana, VigenciaIncial.ToString("yyyy-MM-dd"),
                                                                     VigenciaFinal.ToString("yyyy-MM-dd"), FechaVisita.ToString("yyyy-MM-dd"), Status)

        Insertar_VisitasClientes = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Obtener_Clasificacion() As DataTable
        Dim Query As String = "SELECT DISTINCT(ranking) Ranking FROM impedimentos"
        Obtener_Clasificacion = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_VisitasCliente(ByVal IdCliente As Integer) As DataTable
        Dim Query As String = String.Format("EXEC [dbo].[Obtener_VisitasClientes]
                                                @PidCliente = {0}", IdCliente)

        Obtener_VisitasCliente = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_VisitasActivasCliente(ByVal IdCliente As Integer) As DataTable
        Dim Query As String = String.Format("EXEC [dbo].[Obtener_VisitasActivasClientes]
                                                @PidCliente = {0}", IdCliente)

        Obtener_VisitasActivasCliente = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_Motivos(ByVal Clasificacion As String) As DataTable
        Dim Query As String = String.Format("SELECT DISTINCT(TI.TipoImpedimento)TipoImpedimento, IP.id_tipoImpedimento
                                             FROM impedimentos IP 
                                             INNER JOIN TipoImpedimento TI ON TI.id_tipoImpedimento = IP.id_tipoImpedimento 
                                             WHERE IP.ranking = '{0}'", Clasificacion)

        Obtener_Motivos = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Obtener_Submotivos(ByVal Clasificacion As String, ByVal IdMotivo As Integer) As DataTable
        Dim Query As String = String.Format("SELECT id_impedimento, impedimento  
                                             FROM impedimentos
                                             WHERE ranking = '{0}' AND id_tipoImpedimento = {1}", Clasificacion, IdMotivo)

        Obtener_Submotivos = GE_SQL.SQLGetTable(Query)
    End Function

    Public Function Actualiza_UsuarioAsignado_Visita(ByVal Id_Usuario As Integer, ByVal Id_Visita As Integer) As Boolean
        Dim Query As String = ""

        Query = "  UPDATE VisitasClientes "
        Query = Query + " SET Id_UsuarioVisita=" & Id_Usuario & ", Id_Supervisor_UsuarioVisita = (SELECT id_supervisor FROM usuarios WHERE id_usuario= " & Id_Usuario & ")"
        Query = Query + " WHERE Id_Visita =" & Id_Visita

        Actualiza_UsuarioAsignado_Visita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_UsuarioRegistro_Visita(ByVal Id_Usuario As Integer, ByVal Id_Visita As Integer) As Boolean
        Dim Query As String = ""

        Query = "  UPDATE VisitasClientes "
        Query = Query + " SET  Id_Usuario=" & Id_Usuario & ",  Id_Supervisor_Usuario= (SELECT id_supervisor FROM usuarios WHERE id_usuario= " & Id_Usuario & ")"
        Query = Query + " WHERE Id_Visita =" & Id_Visita

        Actualiza_UsuarioRegistro_Visita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_FechaVisita(ByVal fechaVisita As Date, ByVal Id_Visita As Integer) As Boolean
        Dim Query As String = ""
        fechaVisita.ToString("yyyy-MM-dd")

        Query = "  UPDATE VisitasClientes  "
        Query = Query + " SET FechaVisita='" & fechaVisita.ToString("yyyy-MM-dd") & "', VigenciaInicial= '" & fechaVisita.ToString("yyyy-MM-dd") & "', VigenciaFinal='" & fechaVisita.AddDays(30).ToString("yyyy-MM-dd") & "' WHERE Id_Visita= " & Id_Visita

        Actualiza_FechaVisita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_CampanaVisita(ByVal IdCampana As Integer, ByVal Campana As String, ByVal TipoCampana As String, ByVal Id_Visita As Integer) As Boolean
        Dim Query As String = ""
        Query = " EXEC [dbo].[Actualiza_Campana_VisitasClientes]
                                   @IdCampana = N'" & IdCampana & "',
                                   @Campana = N'" & Campana & "',
                                   @TCampana = N'" & TipoCampana & "',
                                   @idVisita = N'" & Id_Visita & "'"
        Actualiza_CampanaVisita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_Estatus_Visitas() As Boolean
        Dim Query As String = ""
        Query = " EXECUTE  [dbo].[sp_MToolVigenciaVisitas]"

        Actualiza_Estatus_Visitas = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_Origen_Visita(ByVal Origen As String, ByVal Id_Visita As Integer) As Boolean
        Dim Query As String = ""

        Query = " UPDATE VisitasClientes "
        Query = Query + " SET  Origen='" & Origen & "'"
        Query = Query + " WHERE Id_Visita =" & Id_Visita

        Actualiza_Origen_Visita = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Obtener_TipoVisitas() As DataTable
        Dim Query As String = "EXEC [dbo].[spObtener_TipoVisita]"
        Return GE_SQL.SQLGetTable(Query)
    End Function
#End Region

#Region "Cierre"
    Public Function Cierre_CitasVisitas(ByVal Id_Cliente As Integer) As Boolean
        Dim Query As String = ""

        Dim DTA As New DataTable
        Dim DTB As New DataTable

        DTA = Obtener_CitasActivasCliente(Id_Cliente)
        DTB = Obtener_VisitasActivasCliente(Id_Cliente)

        For Each rowA As DataRow In DTA.Rows
            Query += "UPDATE CitasClientes SET Status = 2 WHERE Id_Cita = " & rowA("Id_Cita") & ";"
        Next

        For Each rowB As DataRow In DTB.Rows
            Query += "UPDATE VisitasClientes SET Status = 2 WHERE Id_Visita = " & rowB("Id_Visita") & ";"
        Next
        Cierre_CitasVisitas = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Cierre_Valida(ByVal Id_Cliente As Integer) As Boolean
        Dim Query As String = ""
        Dim idOperacionCierre As Integer = 0

        idOperacionCierre = Obtener_OperacionesCierre(Id_Cliente)

        If (idOperacionCierre = 0) Then
            Cierre_Valida = True
        Else
            Cierre_Valida = False
        End If
    End Function

#End Region

#Region "Clientes"
    Function ValidaCliente(ByVal nombre As String, ByVal app1 As String, ByVal app2 As String, ByVal idCliente As Integer) As Boolean
        Dim Query As String = ""
        Query = "SELECT id_cliente FROM clientes WHERE (nombre='" & nombre & "'AND ApellidoPaterno='" & app1 & "'AND ApellidoMaterno ='" & app2 & "'AND  id_cliente =" & idCliente & ")"

        If (GE_SQL.SQLGetTable(Query).Rows.Count > 1) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ValidaNSS(ByVal nss As String, ByVal idCliente As Integer) As Boolean
        Dim Query As String = ""
        Query = "SELECT id_cliente FROM clientes WHERE (NSS='" & nss & "'AND id_cliente =" & idCliente & ")"

        If (GE_SQL.SQLGetTable(Query).Rows.Count > 1) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ValidaCURP(ByVal curp As String, ByVal idCliente As Integer) As Boolean
        Dim Query As String = ""
        Query = "SELECT id_cliente FROM clientes WHERE (CURP='" & curp & "'AND id_cliente =" & idCliente & ")"

        If (GE_SQL.SQLGetTable(Query).Rows.Count > 1) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Generar_NSSAleatorio() As String
        Dim RND As New Random()
        Dim Digito As Integer
        Dim Numeros(5) As Integer
        Dim Codigo As String = ""

        For x As Integer = 0 To 5
Inicio:
            Digito = RND.Next(10)
            For y As Integer = 0 To 5
                If Digito = Numeros(y) Then GoTo Inicio
            Next y
            Numeros(x) = Digito
        Next x

        For i As Integer = 0 To 5
            Codigo = Codigo & (Numeros(i))
        Next

        Generar_NSSAleatorio = Codigo
    End Function

    Public Function ObtenerRankingCliente(ByVal IdCliente As Integer) As String
        Dim Query As String = String.Format("Select Ranking FROM clientes WHERE id_cliente = {0}", IdCliente)
        ObtenerRankingCliente = GE_SQL.SQLGetDataStr(Query)
    End Function

    Public Function Actualiza_NKontrol(ByVal Cliente_EK As Boolean, ByVal Cliente_EK2 As Boolean, ByVal Cierre_Ek As Boolean, ByVal Escrituracion_Ek As Boolean, ByVal Cancelacion_EK As Boolean, ByVal Recuperacion_EK As Boolean, ByVal Empresa_EK As Boolean, ByVal Modelo_EK As Boolean, ByVal Operacion_EK As Boolean, ByVal idCliente As Integer, ByVal idUsuario As Integer, ByVal ComentarioEK As String) As Boolean
        Dim Query As String = " EXEC [dbo].[Actualiza_Cliente_NKontrol]
                                   @PCliente_Ek = " & Cliente_EK & ",
                                   @PCliente_Ek2 = " & Cliente_EK2 & ",
                                   @PCierre_EK = " & Cierre_Ek & ",
                                   @PEscrituracion_Ek = " & Escrituracion_Ek & ",
                                   @PCancelacion = " & Cancelacion_EK & ",
                                   @PRecuperacion = " & Recuperacion_EK & ",
                                   @PEmpresa = " & Empresa_EK & ",
                                   @PModelo = " & Modelo_EK & ",
                                   @POperacion = " & Operacion_EK & ",
                                   @PClienteID = " & idCliente & ",
                                   @PUsuarioID = " & idUsuario & ",
                                   @PComentario = N'" & ComentarioEK & "'"

        Actualiza_NKontrol = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function

    Public Function Actualiza_Cliente(ByVal idCliente As Integer, ByVal ApPaterno As String, ByVal ApMaterno As String, ByVal Nombre As String, ByVal CURP As String, ByVal NSS As String, ByVal EMAIL As String, ByVal RFC As String,
            ByVal EdoCivil As String, ByVal Observaciones As String, ByVal Empresa As Integer, ByVal Nacimiento As Date, ByVal Id_Usuario As Integer) As Boolean

        Dim Query As String = " EXEC [dbo].[Actualiza_Cliente_Datos]
                @PClienteID = " & idCliente & ",
                @PNombre = '" & Nombre & "',
                @PApPaterno = '" & ApPaterno & "',
                @PApMaterno = '" & ApMaterno & "',
                @PCURP = '" & CURP & "',
                @PNSS = '" & NSS & "',
                @PEMAIL  = '" & EMAIL & "',
                @PRFC = '" & RFC & "',
                @PEdoCivil = '" & EdoCivil & "',
                @PObservaciones = '" & Observaciones & "',
                @PEmpresa = " & Empresa & ",
                @PFechaNacimiento = N'" & Nacimiento & "',
                @IdUsr = " & Id_Usuario & ""

        Actualiza_Cliente = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)

    End Function
#End Region

#Region "Supervisor"
    Public Function Actualiza_SupervisorBorraEk(ByVal id_supervisor As Integer, ByVal activo As Integer) As Boolean
        Dim Query As String = ""
        Query = "UPDATE supervisores SET BorraEK = " & activo & " WHERE id_supervisor = " & id_supervisor
        Actualiza_SupervisorBorraEk = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function
#End Region

#Region "Reportes"
    Public Function Obtener_ReporteCalidad(ByVal FechaInicial As Date, ByVal FechaFin As Date) As DataTable
        Dim ROWA As DataRow
        Dim DTA As New DataTable
        Dim DTB As New DataTable

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
        Dim DTB As New DataTable
        Dim DTC As New DataTable
        Dim DTD As New DataTable
        Dim DTF As New DataTable

        Dim DSR As New DataSet

        Dim Query As String = ""

        Query = "EXEC [dbo].[Obtener_Proyectos]"
        DTB = GE_SQL.SQLGetTable(Query)

        DTA.Columns.AddRange({New DataColumn("Proyecto", GetType(String)), New DataColumn("Cantidad", GetType(Integer)),
                              New DataColumn("Campana", GetType(String)), New DataColumn("TipoCampana", GetType(String))})

        If DTB.Rows.Count <> 0 Then
            For i As Integer = 0 To DTB.Rows.Count - 1
                Query = "EXEC [dbo].[Reporte_CumplimientoProyectoCampaña]
                                    @Proyecto = N'" & DTB.Rows(i).Item("abrev_fracc") & "',
		                            @FechaInicio = N'" & FechaInicial & "',
	                                @FechaFin = N'" & FechaFin & "'"
                DTC = GE_SQL.SQLGetTable(Query)

                If DTC.Rows.Count <> 0 Then
                    For j As Integer = 0 To DTC.Rows.Count - 1
                        ROW = DTA.NewRow
                        ROW("Proyecto") = DTB.Rows(i).Item("abrev_fracc")
                        ROW("Cantidad") = DTC.Rows(j).Item("Cantidad").ToString().Trim
                        ROW("Campana") = DTC.Rows(j).Item("Campana").ToString().Trim
                        ROW("TipoCampana") = DTC.Rows(j).Item("TipoCampana").ToString().Trim

                        DTA.Rows.Add(ROW)
                    Next
                End If
            Next
        End If
        DTA.TableName = "DTA_DatosCumplimiento"

        Dim DTE As New DataTable

        DTE.Columns.AddRange({New DataColumn("Semana", GetType(Integer)), New DataColumn("Asesor", GetType(String)), New DataColumn("Cliente", GetType(String)), New DataColumn("Ranking", GetType(String)),
                              New DataColumn("Prototipo", GetType(String)), New DataColumn("Fraccionamiento", GetType(String)), New DataColumn("FechaInicio", GetType(Date)),
                              New DataColumn("Etapa", GetType(String)), New DataColumn("campanaNombre", GetType(String))})

        For i As Integer = 0 To DTB.Rows.Count - 1
            Query = "EXEC [dbo].[Reporte_CumplimientoProyectoDetalles]
                                    @Proyecto = N'" & DTB.Rows(i).Item("abrev_fracc") & "',
		                            @FechaInicio = N'" & FechaInicial & "',
	                                @FechaFin = N'" & FechaFin & "'"
            DTD = GE_SQL.SQLGetTable(Query)

            If DTD.Rows.Count <> 0 Then
                For j As Integer = 0 To DTD.Rows.Count - 1
                    ROW = DTE.NewRow
                    ROW("Semana") = DTD.Rows(j).Item("semana")
                    ROW("Asesor") = DTD.Rows(j).Item("asesor")
                    ROW("Cliente") = DTD.Rows(j).Item("cliente")
                    ROW("Ranking") = DTD.Rows(j).Item("Ranking")
                    ROW("Prototipo") = DTD.Rows(j).Item("prototipo")
                    ROW("Fraccionamiento") = DTD.Rows(j).Item("fraccionamiento")
                    ROW("FechaInicio") = DTD.Rows(j).Item("fechaInicio")
                    ROW("Etapa") = DTD.Rows(j).Item("etapa")
                    ROW("campanaNombre") = DTD.Rows(j).Item("campañaNombre")

                    DTE.Rows.Add(ROW)
                Next
            End If
        Next
        DTE.TableName = "DTB_CumplimientoProyectoDetalles"

        Query = "EXEC [dbo].[Reporte_CumplimientoProyectoVisitas]
		                       @FechaInicio = N'" & FechaInicial & "',
	                           @FechaFin = N'" & FechaFin & "'"
        DTF = GE_SQL.SQLGetTable(Query)
        DTF.TableName = "DTF_ProyectosVisitas"

        DSR.Tables.Add(DTA)
        DSR.Tables.Add(DTE)
        DSR.Tables.Add(DTF)

        Return DSR
    End Function
#End Region

#Region "Usuarios"
    Public Function Asignar_Supervisor(ByVal idUsuario As Integer, ByVal idSupervisor As Integer) As Boolean
        Dim Query As String = " EXEC [dbo].[Inserta_Asignacion_supervisorUsuario]
                                   @Pid_usuario = " & idUsuario & ",
                                   @Pid_supervisor = " & idSupervisor

        If (GE_SQL.SQLGetDataDbl(Query) = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Campañas"
    Public Function Inserta_TipoCampaña(ByVal TipoCampaña As String) As Boolean
        Dim Query As String = " EXEC [dbo].[Inserta_TipoCampaña]
                                   @PTipoCampaña = N'" & TipoCampaña & "'"

        If (GE_SQL.SQLGetDataDbl(Query) = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Impedimentos"
    Public Function Obtener_TipoImpedimentos() As DataTable
        Dim Query As String = "SELECT id_tipoImpedimento, 
                                TipoImpedimento
                        FROM TipoImpedimento"

        Obtener_TipoImpedimentos = GE_SQL.SQLGetTable(Query)
    End Function
    Public Function Existe_TipoImpedimento(ByVal TipoImpedimento As String) As Boolean
        Dim idTipoImpedimento As Integer = 0

        Dim Query As String = "SELECT id_tipoImpedimento FROM TipoImpedimento WHERE TipoImpedimento = UPPER(LTRIM(RTRIM('" + TipoImpedimento + "')))"

        idTipoImpedimento = GE_SQL.SQLGetDataDbl(Query)

        If (idTipoImpedimento = 0) Then
            Return False
        Else
            Return True
        End If

    End Function
    Public Function Inserta_TipoImpedimento(ByVal TipoImpedimento As String) As Boolean
        Dim Query As String = " EXEC [dbo].[Inserta_TipoImpedimento]
                                   @PTipoImpedimento = N'" & TipoImpedimento & "'"

        If (GE_SQL.SQLGetDataDbl(Query) = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Obtener_Impedimentos() As DataTable
        Dim Query As String = "SELECT impedimentos.id_impedimento, 
                                       impedimentos.impedimento, 
                                       impedimentos.ranking, 
                                       TipoImpedimento.TipoImpedimento
                                FROM impedimentos
                                INNER JOIN TipoImpedimento ON impedimentos.id_tipoImpedimento= TipoImpedimento.id_tipoImpedimento"

        Obtener_Impedimentos = GE_SQL.SQLGetTable(Query)
    End Function
    Public Function Obtener_Impedimento_Id(ByVal idimpedimento As Integer) As DataTable
        Dim Query As String = "SELECT impedimentos.id_impedimento, 
                                       impedimentos.impedimento, 
                                       impedimentos.ranking, 
                                       TipoImpedimento.id_tipoImpedimento
                                FROM impedimentos
                                INNER JOIN TipoImpedimento ON impedimentos.id_tipoImpedimento= TipoImpedimento.id_tipoImpedimento
                                WHERE impedimentos.id_impedimento= " & idimpedimento

        Obtener_Impedimento_Id = GE_SQL.SQLGetTable(Query)
    End Function
    Public Function Inserta_Impedimento(ByVal Impedimento As String, ByVal Ranking As String, ByVal IdTipoImpedimento As Integer) As Boolean
        Dim Query As String = " EXEC [dbo].[Inserta_Impedimento]
                                   @PImpedimento = N'" & Impedimento & "',
                                   @PRnaking = N'" & Ranking & "',
                                   @PIdTipoImpedimento = N'" & IdTipoImpedimento & "'"
        If (GE_SQL.SQLGetDataDbl(Query) = 0) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Actualiza_Impedimento(ByVal Impedimento As String, ByVal Ranking As String, ByVal IdTipoImpedimento As Integer, ByVal IdImpedimento As Integer) As Boolean
        Dim Query As String = " EXEC [dbo].[Actualiza_Impedimento]
                                   @PImpedimento = N'" & Impedimento & "',
                                   @PRnaking = N'" & Ranking & "',
                                   @PIdTipoImpedimento = N'" & IdTipoImpedimento & "',
                                   @PIdImpedimento = N'" & IdImpedimento & "'"

        Actualiza_Impedimento = GE_SQL.SQLExecSQL(Query, TipoTransaccion.UniqueTransaction)
    End Function
#End Region
End Class
