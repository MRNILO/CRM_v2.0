Imports Ajax_Test.Funciones

Public Class VisitasCitas
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
#Region "Eventos"
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim NombreCliente = BuscarClientes(txtNumCliente.Text)
            If (String.IsNullOrEmpty(NombreCliente)) Then
                GV_citas.DataSource = Nothing
                GV_citas.DataBind()
                txtNumCliente.Text = ""
                lblNombreCliente.Text = ""
                lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
            Else
                lblNombreCliente.Text = NombreCliente.ToString()
                cargarCitas()
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
        End Try
    End Sub
    Protected Sub btnBuscarVisitas_Click(sender As Object, e As EventArgs) Handles btnBuscarVisitas.Click
        Try
            Dim NombreCliente = BuscarClientes(txtNumClienteVisitas.Text)
            If (String.IsNullOrEmpty(NombreCliente)) Then
                GV_citas.DataSource = Nothing
                GV_citas.DataBind()
                txtNumCliente.Text = ""
                lblNombreCliente.Text = ""
                lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
            Else
                lblNombreClienteVisitas.Text = NombreCliente.ToString()
                cargarVisitas()
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
        End Try
    End Sub
    Protected Sub cbPanelUsuarioAsignado_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioAsignado.Callback
        lblUsuario.Text = cmBoxUsuarios.SelectedItem.Text
    End Sub
    Protected Sub cbPanelUsuarioAsignadoVisita_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioAsignadoVisita.Callback
        lblUsuarioVisita.Text = cmBoxUsuariosVisita.SelectedItem.Text
    End Sub
    Protected Sub cbPanelUsuarioRegistroCita_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioRegistroCita.Callback
        lblUsuarioResgitroCita.Text = cmBoxUsuarioRegistro_Cita.SelectedItem.Text
    End Sub
    Protected Sub cbPanelUsuarioRegVisita_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioRegVisita.Callback
        lblUsuarioRegVisita.Text = cmBoxUsuariosRegistro_Visita.SelectedItem.Text
    End Sub
    Protected Sub PanelCampana_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelCampana.Callback
        Try
            If (e.Parameter = "cmBoxMedio") Then
                If (cmBoxMedio.SelectedItem.Value > 0) Then
                    AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value, "cmBoxCampanaCita")
                    cmBoxCampana.Enabled = True
                Else
                    cmBoxCampana.Enabled = False
                End If
                cbPanelCampana.JSProperties("cpResult") = ""
            ElseIf (e.Parameter.Contains("cmBoxCampana")) Then
                Dim ParametrosLista() As String = e.Parameter.Split(",")
                Dim id As Integer = ParametrosLista(1)
                If (cmBoxCampana.SelectedIndex <> 0) Then
                    txtTipoCampana.Text = ObtTipoCampana(id)
                End If
                cbPanelCampana.JSProperties("cpResult") = ""
            ElseIf (e.Parameter.Contains("ActualizaCampana")) Then
                Dim ParametrosLista() As String = e.Parameter.Split(",")
                Dim idCampana As Integer = ParametrosLista(1)
                If (idCampana > 0) Then
                    ActualizaCampanaCita(idCampana)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Protected Sub PanelCampanaVisita_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelCampanaVisita.Callback
        If (e.Parameter = "cmBoxMedioVisita") Then
            If (cmBoxMedioVisita.SelectedItem.Value > 0) Then
                AlimentarComboCampanas(cmBoxMedioVisita.SelectedItem.Value, "cmBoxCampanaVisita")
                cmBoxCampanaVisita.Enabled = True
            Else
                cmBoxCampanaVisita.Enabled = False
            End If
            cbPanelCampanaVisita.JSProperties("cpResult") = ""
        ElseIf (e.Parameter.Contains("cmBoxCampanaVisita")) Then
            Dim ParametrosLista() As String = e.Parameter.Split(",")
            Dim id As Integer = ParametrosLista(1)
            If (cmBoxCampanaVisita.SelectedIndex <> 0) Then
                txtTipoCampanaVisita.Text = ObtTipoCampana(id)
            End If
            cbPanelCampanaVisita.JSProperties("cpResult") = ""
        ElseIf (e.Parameter.Contains("ActualizaCampana")) Then
            Dim ParametrosLista() As String = e.Parameter.Split(",")
            Dim idCampana As Integer = ParametrosLista(1)
            If (idCampana > 0) Then
                ActualizaCampanaVisita(idCampana)
            End If
        End If
    End Sub
    Protected Sub btn_ActualizaAsigando_Click(sender As Object, e As EventArgs) Handles btn_ActualizaAsigando.Click
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
        If (idCita.Count > 0) Then
            For Each cita In idCita
                If (GE_Funciones.Actualiza_UsuarioAsignado(cmBoxUsuarios.SelectedItem.Value, cita)) Then
                    cargarCitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Cita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la cita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
        End If
    End Sub
    Protected Sub btn_ActualizaAsigandoVisita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaAsigandoVisita.Click
        Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
        If (idVisita.Count > 0) Then
            For Each Visita In idVisita
                If (GE_Funciones.Actualiza_UsuarioAsignado_Visita(cmBoxUsuariosVisita.SelectedItem.Value, Visita)) Then
                    cargarVisitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Visita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la visita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la visita que desea modificar.")
        End If
    End Sub
    Protected Sub btn_ActualizaRegistroCita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaRegistroCita.Click
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
        If (idCita.Count > 0) Then
            For Each cita In idCita
                If (GE_Funciones.Actualiza_UsuarioRegistro_Cita(cmBoxUsuarioRegistro_Cita.SelectedItem.Value, cita, txtNumCliente.Text)) Then
                    cargarCitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Cita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la cita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
        End If
    End Sub
    Protected Sub btn_ActualizaRegVisita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaRegVisita.Click
        Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
        If (idVisita.Count > 0) Then
            For Each Visita In idVisita
                If (GE_Funciones.Actualiza_UsuarioRegistro_Visita(cmBoxUsuariosRegistro_Visita.SelectedItem.Value, Visita)) Then
                    cargarVisitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Visita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la visita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la visita que desea modificar.")
        End If
    End Sub
    Protected Sub ActualizaCampanaCita(IdCampana As Integer)
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
        Dim CampanaDescripcion = GE_Funciones.ObtenerCampanasId(IdCampana)
        If (CampanaDescripcion.Rows.Count > 0) Then
            If (idCita.Count > 0) Then
                For Each cita In idCita
                    If (GE_Funciones.Actualiza_Campana(IdCampana, CampanaDescripcion.Rows(0).Item("campañaNombre").ToString(), ObtTipoCampana(IdCampana), cita)) Then
                        cargarCitas()
                        UI()
                        cbPanelCampana.JSProperties("cpResult") = "OK"
                    Else
                        cbPanelCampana.JSProperties("cpResult") = "ERR"
                    End If
                Next
            Else
                cbPanelCampana.JSProperties("cpResult") = "SELCITA"
            End If
        Else
            cbPanelCampana.JSProperties("cpResult") = "FINFO"
        End If
    End Sub
    Protected Sub ActualizaCampanaVisita(IdCampana As Integer)
        Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
        Dim CampanaDescripcion = GE_Funciones.ObtenerCampanasId(IdCampana)
        If (CampanaDescripcion.Rows.Count > 0) Then
            If (idVisita.Count > 0) Then
                For Each Visita In idVisita
                    If (GE_Funciones.Actualiza_CampanaVisita(IdCampana, CampanaDescripcion.Rows(0).Item("campañaNombre").ToString(), ObtTipoCampana(IdCampana), Visita)) Then
                        cargarVisitas()
                        UI()
                        cbPanelCampanaVisita.JSProperties("cpResult") = "OK"
                    Else
                        cbPanelCampanaVisita.JSProperties("cpResult") = "ERR"
                    End If
                Next
            Else
                cbPanelCampanaVisita.JSProperties("cpResult") = "SELCITA"
            End If
        Else
            cbPanelCampanaVisita.JSProperties("cpResult") = "FINFO"
        End If
    End Sub
    Protected Sub btn_ActualizaFechaCita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaFechaCita.Click
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
        If (idCita.Count > 0) Then
            For Each cita In idCita
                If (GE_Funciones.Actualiza_FechaCita(dateFechaCita.Date, cita)) Then
                    cargarCitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Cita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la cita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
        End If
    End Sub
    Protected Sub btn_ActualizaFechaVisita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaFechaVisita.Click
        Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
        If (idVisita.Count > 0) Then
            For Each Visita In idVisita
                If (GE_Funciones.Actualiza_FechaVisita(dateFechaVisita.Date, Visita)) Then
                    cargarVisitas()
                    UI()
                    lbl_mensaje.Text += MostrarExito("Visita Actualizada.")
                Else
                    lbl_mensaje.Text += MostrarError("No se puede actualizar la visita seleccionada.")
                End If
            Next
        Else
            lbl_mensaje.Text += MostrarError("Seleccione la visita que desea modificar.")
        End If
    End Sub
    Protected Sub btn_ActualizaOrigen_Click(sender As Object, e As EventArgs) Handles btn_ActualizaOrigen.Click
        Try
            Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
            If (idCita.Count > 0) Then
                For Each cita In idCita
                    If (GE_Funciones.Actualiza_Origen_Cita(cmBoxOrigen.SelectedItem.Text, cita)) Then
                        cargarCitas()
                        UI()
                        lbl_mensaje.Text += MostrarExito("Cita Actualizada.")
                    Else
                        lbl_mensaje.Text += MostrarError("No se pudo actualizar la cita.")
                    End If
                Next
            Else
                lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
        End Try
    End Sub
    Protected Sub btn_ActualizaOrigenVisita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaOrigenVisita.Click
        Try
            Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
            If (idVisita.Count > 0) Then
                For Each Visita In idVisita
                    If (GE_Funciones.Actualiza_Origen_Visita(cmBoxOrigenVisita.SelectedItem.Text, Visita)) Then
                        cargarVisitas()
                        UI()
                        lbl_mensaje.Text += MostrarExito("Visita Actualizada.")
                    Else
                        lbl_mensaje.Text += MostrarError("No se pudo actualizar la Visita.")
                    End If
                Next
            Else
                lbl_mensaje.Text += MostrarError("Seleccione la Visita que desea modificar.")
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Seleccione la Visita que desea modificar.")
        End Try
    End Sub
#End Region
#Region "Funciones Usuario"
    Private Sub UI()
        AlimentarComboUsuarios()
        AlimentarComboMedios()
        AlimentarComboOrigen()
    End Sub
    Private Sub AlimentarComboUsuarios()
        Dim Aux As Integer = 0
        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Usuarios()
        DTB.Columns.AddRange({New DataColumn("id_usuario"), New DataColumn("nombre")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_usuario") = 0
                RowB("nombre") = "SELECCIONA"
                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_usuario") = Row("id_usuario")
            RowB("nombre") = Row("nombre")
            DTB.Rows.Add(RowB)
            Aux += 1
        Next
        With cmBoxUsuarios
            .DataSource = DTB
            .ValueField = "id_usuario"
            .TextField = "nombre"
            .DataBind()

            .SelectedIndex = 0
        End With
        With cmBoxUsuariosVisita
            .DataSource = DTB
            .ValueField = "id_usuario"
            .TextField = "nombre"
            .DataBind()

            .SelectedIndex = 0
        End With
        With cmBoxUsuarioRegistro_Cita
            .DataSource = DTB
            .ValueField = "id_usuario"
            .TextField = "nombre"
            .DataBind()

            .SelectedIndex = 0
        End With
        With cmBoxUsuariosRegistro_Visita
            .DataSource = DTB
            .ValueField = "id_usuario"
            .TextField = "nombre"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Public Function BuscarClientes(ByVal NumCliente As Integer) As String
        Dim Cliente As New BusquedaCliente
        Dim NombreCliente As String = ""
        Dim DT As New DataTable

        If IsNumeric(NumCliente) Then
            Cliente.IdCliente = NumCliente
        Else
            txtNumCliente.Text = 0
            Cliente.IdCliente = 0
        End If
        If (Cliente.IdCliente <> 0) Then
            DT = GE_Funciones.BuscarClientes(Cliente)
            ViewState("ListaClientes") = DT
            If DT.Rows.Count > 0 Then
                For Each row In DT.Rows
                    If Convert.ToInt32(NumCliente) = Convert.ToInt32(row("ID").ToString) Then
                        NombreCliente = row("Cliente").ToString
                        Id_Cliente = Convert.ToInt32(NumCliente)
                        Return NombreCliente
                    End If
                Next
            End If
        End If
    End Function
    Private Sub cargarCitas()
        GV_citas.DataSource = GE_Funciones.Obtener_CitasActivasCliente(Id_Cliente)
        GV_citas.DataBind()
    End Sub
    Private Sub cargarVisitas()
        GV_Visitas.DataSource = GE_Funciones.Obtener_VisitasActivasCliente(Id_Cliente)
        GV_Visitas.DataBind()
    End Sub
    Private Sub AlimentarComboOrigen()
        Dim Aux As Integer = 0
        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerOrigenCitas()
        DTB.Columns.AddRange({New DataColumn("Id"), New DataColumn("Origen")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("Id") = 0
                RowB("Origen") = "SELECCIONA"
                DTB.Rows.Add(RowB)
            End If
            RowB = DTB.NewRow
            RowB("Id") = Aux
            RowB("Origen") = Row("Origen")
            DTB.Rows.Add(RowB)
            Aux += 1
        Next
        With cmBoxOrigen
            .DataSource = DTB
            .ValueField = "Id"
            .TextField = "Origen"
            .DataBind()
            .SelectedIndex = 0
        End With
        With cmBoxOrigenVisita
            .DataSource = DTB
            .ValueField = "Id"
            .TextField = "Origen"
            .DataBind()
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub AlimentarComboMedios()
        Dim Aux As Integer = 0
        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerMedios()
        DTB.Columns.AddRange({New DataColumn("Id_Medio"), New DataColumn("NombreMedio")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("Id_Medio") = 0
                RowB("NombreMedio") = "SELECCIONA"
                DTB.Rows.Add(RowB)
            End If
            RowB = DTB.NewRow
            RowB("Id_Medio") = Row("Id_Medio")
            RowB("NombreMedio") = Row("NombreMedio")
            DTB.Rows.Add(RowB)
            Aux += 1
        Next
        With cmBoxMedio
            .DataSource = DTB
            .ValueField = "Id_Medio"
            .TextField = "NombreMedio"
            .DataBind()

            .SelectedIndex = 0
        End With
        With cmBoxMedioVisita
            .DataSource = DTB
            .ValueField = "Id_Medio"
            .TextField = "NombreMedio"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Private Sub AlimentarComboCampanas(ByVal Id_Medio As Integer, ByVal Control As String)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerCampanas(Id_Medio)
        DTB.Columns.AddRange({New DataColumn("id_campaña"), New DataColumn("campañaNombre")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_campaña") = "0"
                RowB("campañaNombre") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_campaña") = Row("id_campaña")
            RowB("campañaNombre") = Row("campañaNombre")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next
        If Control = "cmBoxCampanaCita" Then
            With cmBoxCampana
                .DataSource = DTB
                .ValueField = "id_campaña"
                .TextField = "campañaNombre"
                .DataBind()

                .SelectedIndex = 0
            End With

        ElseIf Control = "cmBoxCampanaVisita" Then
            With cmBoxCampanaVisita
                .DataSource = DTB
                .ValueField = "id_campaña"
                .TextField = "campañaNombre"
                .DataBind()

                .SelectedIndex = 0
            End With
        End If
    End Sub
    Public Function ObtTipoCampana(ByVal IdCampana As Integer) As String
        Return GE_Funciones.Obtener_TipoCampana(IdCampana)
    End Function
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
                Session("Usuario") = Usuario
                RedirigirSegunNivel(Usuario.Nivel)

            End If
        Else
            Session.Clear()
            Response.Redirect("../Account/LogOn.aspx")
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
            Case 4
                Response.Redirect("~/Callcenter/InicioCCenter.aspx", False)
            Case 5
                Response.Redirect("~/Caseta/InicioCaseta.aspx", False)
            Case 6
                Response.Redirect("~/Prospectador/InicioProspectador.aspx", False)
            Case 7
                Response.Redirect("~/SupervisorMty/InicioCaseta.aspx", False)
        End Select
    End Sub
#End Region
End Class

