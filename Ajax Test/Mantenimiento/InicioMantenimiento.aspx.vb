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
        BuscarClientes()
    End Sub
    Protected Sub cbPanelUsuarioAsignado_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioAsignado.Callback
        lblUsuario.Text = cmBoxUsuarios.SelectedItem.Text
    End Sub
    Protected Sub btn_ActaulizaAsigando_Click(sender As Object, e As EventArgs) Handles btn_ActaulizaAsigando.Click
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
    Protected Sub btn_ActaulizaFechaCita_Click(sender As Object, e As EventArgs) Handles btn_ActaulizaFechaCita.Click
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
    Protected Sub btn_ActualizaCampana_Click(sender As Object, e As EventArgs) Handles btn_ActualizaCampana.Click
        Dim idCita = GV_citas.GetSelectedFieldValues("Id_Cita")
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
    End Sub
    Protected Sub cmBoxMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMedio.SelectedIndexChanged
        If (cmBoxMedio.SelectedItem.Value > 0) Then
            AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value)
            cmBoxCampana.Enabled = True
        Else
            cmBoxCampana.Enabled = False
        End If
    End Sub
    Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
        ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
    End Sub
#End Region
#Region "Metodos"
    Private Sub AlimentarComboCampanas(ByVal Id_Medio As Integer)
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

        With cmBoxCampana
            .DataSource = DTB
            .ValueField = "id_campaña"
            .TextField = "campañaNombre"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Private Sub UI()
        AlimentarComboUsuarios()
        AlimentarComboMedios()
        ''AlimentarComboCampanas()
    End Sub
    Public Sub BuscarClientes()
        Dim Cliente As New BusquedaCliente
        Dim DT As New DataTable

        If IsNumeric(txtNumCliente.Text) Then
            Cliente.IdCliente = txtNumCliente.Text
        Else
            txtNumCliente.Text = 0
            Cliente.IdCliente = 0
        End If
        If (Cliente.IdCliente <> 0) Then
            DT = GE_Funciones.BuscarClientes(Cliente)
            ViewState("ListaClientes") = DT
            If DT.Rows.Count > 0 Then
                For Each row In DT.Rows
                    If Convert.ToInt32(txtNumCliente.Text) = Convert.ToInt32(row("ID").ToString) Then
                        lblNombreCliente.Text = row("Cliente").ToString
                        Id_Cliente = Convert.ToInt32(txtNumCliente.Text())
                        cargarCitas()
                        Exit Sub
                    End If
                Next
            End If
        End If
        GV_citas.DataSource = Nothing
        GV_citas.DataBind()
        txtNumCliente.Text = ""
        lblNombreCliente.Text = ""
        lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
    End Sub
    Private Sub cargarCitas()
        GV_citas.DataSource = GE_Funciones.Obtener_CitasActivasCliente(Id_Cliente)
        GV_citas.DataBind()
    End Sub
    Private Sub ObtenerTipoCampana(ByVal IdCampana As Integer)
        txtTipoCampana.Text = GE_Funciones.Obtener_TipoCampana(IdCampana)
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
    End Sub
#End Region
End Class