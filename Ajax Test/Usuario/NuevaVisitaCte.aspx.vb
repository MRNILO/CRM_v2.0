Imports Ajax_Test.Funciones

Public Class NuevaVisitaCte
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Dim IDCita As Integer = 0
    Dim IDCliente As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            IDCliente = Request.QueryString("idCliente")
            IDCita = Request.QueryString("idCita")
        Catch ex As Exception
            IDCliente = 0
        End Try

        If Not IsPostBack() Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub

#Region "Metodos"
    Private Sub UI()
        Dim DatosCitas As DatosCita = GE_Funciones.Obtener_DatosCita(IDCita)

        With txBoxEsquemaFinanciero : .Enabled = False : .Text = DatosCitas.TipoCredito : End With
        With txBoxMedio : .Enabled = False : .Text = DatosCitas.Origen : End With
        With txBoxCual : .Enabled = False : .Text = DatosCitas.LugarContacto : End With
        With txBoxUsuario : .Enabled = False : .Text = DatosCitas.Asesor : End With
        With txBoxAsesor : .Enabled = False : .Text = DatosCitas.AsesorAsignado : End With
        With txBoxTipoCamapana : .Enabled = False : .Text = DatosCitas.TipoCampana : End With
        With dtFechaVisita : .Enabled = False : .Date = Now() : End With
        With dtp_finicio : .Enabled = False : .Date = Now() : End With
        With dtp_ffinal : .Enabled = False : .Date = Now.AddDays(30) : End With

        Alimentar_ComboProyectos()
        Alimentar_TablaVisitas(IDCliente)
        Alimentar_ComboModelos(cmBoxProyecto.SelectedItem.Value)

        Alimentar_ComboClasificacion()
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
        'Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)
    End Sub

    Private Sub Alimentar_ComboClasificacion()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Clasificacion()
        DTB.Columns.AddRange({New DataColumn("Ranking")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("Ranking") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("Ranking") = Row("Ranking")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxClasificacion
            .DataSource = DTB
            .ValueField = "Ranking"
            .TextField = "Ranking"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboMotivos(ByVal Clasificacion As String)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Motivos(Clasificacion)
        DTB = DTA.Clone()

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_tipoImpedimento") = 0
                RowB("TipoImpedimento") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_tipoImpedimento") = Row("id_tipoImpedimento")
            RowB("TipoImpedimento") = Row("TipoImpedimento")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxMotivo
            .DataSource = DTB
            .ValueField = "id_tipoImpedimento"
            .TextField = "TipoImpedimento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboSubmotivos(ByVal Clasificacion As String, ByVal IdMotivo As Integer)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Submotivos(Clasificacion, IdMotivo)
        DTB = DTA.Clone()

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_impedimento") = 0
                RowB("impedimento") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_impedimento") = Row("id_impedimento")
            RowB("impedimento") = Row("impedimento")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxSubMotivo
            .DataSource = DTB
            .ValueField = "id_impedimento"
            .TextField = "impedimento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboProyectos()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Proyectos()
        DTB = DTA.Clone()

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("Proyecto") = "-"
                RowB("Fraccionamiento") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("Proyecto") = Row("Proyecto")
            RowB("Fraccionamiento") = Row("Fraccionamiento")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxProyecto
            .DataSource = DTB
            .ValueField = "Proyecto"
            .TextField = "Fraccionamiento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_ComboModelos(ByVal Proyecto As String)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_ModelosXProyecto(Proyecto)
        DTB = DTA.Clone()

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_producto") = 0
                RowB("Modelo") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_producto") = Row("id_producto")
            RowB("Modelo") = Row("Modelo")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxModelo
            .DataSource = DTB
            .ValueField = "id_producto"
            .TextField = "Modelo"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Alimentar_TablaVisitas(ByVal Id_Cliente As Integer)
        Dim DT As New DataTable
        DT = GE_Funciones.Obtener_VisitasCliente(Id_Cliente) : ViewState("VisitasCliente") = DT

        With grdViewVisitas
            .DataSource = DT
            .DataBind()
        End With
    End Sub

    Public Function Validar_Campos()
        If cmBoxClasificacion.SelectedIndex = 0 Then Return False

        If cmBoxMotivo.Items.Count = 0 Then Return False
        If cmBoxMotivo.SelectedIndex = 0 Then Return False

        If cmBoxSubMotivo.Items.Count = 0 Then Return False
        If cmBoxSubMotivo.SelectedIndex = 0 Then Return False

        If cmBoxProyecto.SelectedIndex = 0 Then Return False

        If cmBoxModelo.Items.Count = 0 Then Return False
        If cmBoxModelo.SelectedIndex = 0 Then Return False

        Return True
    End Function
#End Region

#Region "FuncionesUsuario"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    Session("Usuario") = Usuario
                Else
                    Session("Usuario") = Usuario
                    RedirigirSegunNivel(Usuario.Nivel)
                End If
            Else
                'No valido
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)
                'lbl_error.Text = MostrarError("Usuario o/y contraseña equivocados")
            End If
        Else
            Session.Clear()
            Response.Redirect("/Account/LogOn.aspx")
        End If
    End Sub

    Sub RedirigirSegunNivel(ByVal Nivel As Integer)
        Select Case Nivel
            Case 1
                Response.Redirect("~/Usuario/InicioUsuario.aspx", False)
            Case 2
                Response.Redirect("~/Supervisor/InicioSupervisor.aspx", False)
            Case 3
                Response.Redirect("~/Administrativo/InicioAdmin.aspx", False)
        End Select
    End Sub
#End Region

#Region "Eventos"
    Protected Sub cmBoxClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxClasificacion.SelectedIndexChanged
        Alimentar_ComboMotivos(cmBoxClasificacion.SelectedItem.Value)
    End Sub

    Protected Sub cmBoxMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMotivo.SelectedIndexChanged
        Alimentar_ComboSubmotivos(cmBoxClasificacion.SelectedItem.Value, cmBoxMotivo.SelectedItem.Value)
    End Sub

    Protected Sub btnAsignaVisita_Click(sender As Object, e As EventArgs) Handles btnAsignaVisita.Click
        If Validar_Campos() Then
            Dim DatosCitas As DatosCita = GE_Funciones.Obtener_DatosCita(IDCita)

            With DatosCitas
                If GE_Funciones.Insertar_VisitasClientes(.IdCita, .IdCliente, .IdUsuario, .IdUsuarioAsignado, Usuario.id_usuario, .IdCampana, cmBoxSubMotivo.SelectedItem.Value, .TipoCredito,
                        0, cmBoxClasificacion.SelectedItem.Value, .Origen, cmBoxProyecto.SelectedItem.Value, cmBoxModelo.SelectedItem.Value,
                        .TipoCampana, dtp_finicio.Text, dtp_ffinal.Text, dtFechaVisita.Text, 1) Then

                    Session("DatosCitas") = Nothing
                    Alimentar_TablaVisitas(IDCliente)

                    lbl_mensaje.Text = MostrarExito("¡Visita registrada correctamente!")
                Else
                    Session("DatosCitas") = Nothing
                    lbl_mensaje.Text = MostrarError("¡Ocurrio un error al registrar la visita!")
                End If
            End With
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te falta capturar información para la cita, revisa los datos capturados!")
        End If
    End Sub

    Protected Sub cmBoxProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxProyecto.SelectedIndexChanged
        Alimentar_ComboModelos(cmBoxProyecto.SelectedItem.Value)
    End Sub

    Protected Sub grdViewVisitas_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles grdViewVisitas.HtmlDataCellPrepared
        If e.DataColumn.Caption = "Estatus" Then
            Select Case e.CellValue
                Case 0
                    e.Cell.BackColor = Drawing.Color.OrangeRed
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "VENCIDA"
                Case 1
                    e.Cell.BackColor = Drawing.Color.LightSkyBlue
                    e.Cell.Text = "VIGENTE"
                Case 2
                    e.Cell.BackColor = Drawing.Color.Green
                    e.Cell.ForeColor = Drawing.Color.White
                    e.Cell.Text = "COMPLETADA"
            End Select
        End If
    End Sub
#End Region
End Class