Imports Ajax_Test.Funciones

Public Class InicioMantenimiento
    Inherits System.Web.UI.Page
    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Protected Sub PanelCampana_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelCampana.Callback
        If (e.Parameter = "cmBoxMedio") Then
            If (cmBoxMedio.SelectedItem.Value > 0) Then
                AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value, "cmBoxCampanaCita")
                cmBoxCampana.Enabled = True
            Else
                cmBoxCampana.Enabled = False
            End If
        ElseIf (e.Parameter.Contains("cmBoxCampana")) Then
            Dim ParametrosLista() As String = e.Parameter.Split(",")
            Dim id As Integer = ParametrosLista(1)
            If (cmBoxCampana.SelectedIndex <> 0) Then
                ObtenerTipoCampana(id, "txtTipoCampana")
            End If
        End If
    End Sub
    Protected Sub PanelCampanaVisita_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelCampanaVisita.Callback
        If (e.Parameter = "cmBoxMedioVisita") Then
            If (cmBoxMedioVisita.SelectedItem.Value > 0) Then
                AlimentarComboCampanas(cmBoxMedioVisita.SelectedItem.Value, "cmBoxCampanaVisita")
                cmBoxCampanaVisita.Enabled = True
            Else
                cmBoxCampanaVisita.Enabled = False
            End If
        ElseIf (e.Parameter.Contains("cmBoxCampanaVisita")) Then
            Dim ParametrosLista() As String = e.Parameter.Split(",")
            Dim id As Integer = ParametrosLista(1)
            If (cmBoxCampanaVisita.SelectedIndex <> 0) Then
                ObtenerTipoCampana(id, "txtTipoCampanaVisita")
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
    Protected Sub btn_ActualizaCampana_Click(sender As Object, e As EventArgs) Handles btn_ActualizaCampana.Click
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
        If (txtTipoCampana.Text <> "") Then
            If (idCita.Count > 0) Then
                For Each cita In idCita
                    If (GE_Funciones.Actualiza_Campana(cmBoxCampana.SelectedItem.Value, cmBoxCampana.SelectedItem.Text, txtTipoCampana.Text, cita)) Then
                        cargarCitas()
                        UI()
                        lbl_mensaje.Text += MostrarExito("Usuario actualizado")
                    Else
                        lbl_mensaje.Text += MostrarError("No se puede actualizar el usuario asignado.")
                    End If
                Next
            Else
                lbl_mensaje.Text += MostrarError("Seleccione la cita que desea modificar.")
            End If
        Else
            lbl_mensaje.Text += MostrarError("Capture la información necesaria.")
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
    Protected Sub btn_ActualizaCampanaVisita_Click(sender As Object, e As EventArgs) Handles btn_ActualizaCampanaVisita.Click
        Dim idVisita = GV_Visitas.GetSelectedFieldValues("Id_Visita")
        If (txtTipoCampanaVisita.Text <> "") Then
            If (idVisita.Count > 0) Then
                For Each Visita In idVisita
                    If (GE_Funciones.Actualiza_CampanaVisita(cmBoxCampanaVisita.SelectedItem.Value, txtTipoCampanaVisita.Text, Visita)) Then
                        cargarVisitas()
                        UI()
                        lbl_mensaje.Text += MostrarExito("Usuario actualizado")
                    Else
                        lbl_mensaje.Text += MostrarError("No se puede actualizar la visita seleccionada.")
                    End If
                Next
            Else
                lbl_mensaje.Text += MostrarError("Seleccione la visita que desea modificar.")
            End If
        Else
            lbl_mensaje.Text += MostrarError("Capture la información necesaria.")
        End If
    End Sub

#End Region
#Region "Metodos"
    Private Sub UI()
        AlimentarComboUsuarios()
        AlimentarComboMedios()
        ''AlimentarComboCampanas()
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
    Public Sub ObtenerTipoCampana(ByVal IdCampana As Integer, ByVal Control As String)
        If Control = "txtTipoCampana" Then
            txtTipoCampana.Text = GE_Funciones.Obtener_TipoCampana(IdCampana)

        ElseIf Control = "txtTipoCampanaVisita" Then
            txtTipoCampanaVisita.Text = GE_Funciones.Obtener_TipoCampana(IdCampana)
        End If

    End Sub
#End Region
End Class