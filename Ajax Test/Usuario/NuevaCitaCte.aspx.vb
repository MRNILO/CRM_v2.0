Public Class NuevaCitaCte
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Dim IDCliente As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            IDCliente = Request.QueryString("idCliente")
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
        With dtp_finicio
            .Date = Now
            .Enabled = False
        End With

        With dtp_ffinal
            .Date = Now.AddDays(30)
            .Enabled = False
        End With

        dtp_fechaCita.Text = ""
        tb_origen.Enabled = False
        tb_TipoCampana.Enabled = False

        txBox_AsesorAsignado.Text = String.Format("{0} {1} {2}", Usuario.nombre, Usuario.apellidoPaterno, Usuario.apellidoMaterno)
        txBox_AsesorAsignado.Enabled = False

        AlimentarComboMedios()
        AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value)
        AlimentarComboProyectos()
        AlimentarComboModelos(cb_fraccinamientos.SelectedValue)
        AlimentarTablaCitas(IDCliente)

        If cmBoxCampana.Items.Count > 0 Then
            ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
        End If
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

    Private Sub AlimentarComboProyectos()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Proyectos()
        DTB.Columns.AddRange({New DataColumn("Proyecto"), New DataColumn("Fraccionamiento")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow()
                RowB("Proyecto") = "-"
                RowB("Fraccionamiento") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow()
            RowB("Proyecto") = Row("Proyecto")
            RowB("Fraccionamiento") = Row("Fraccionamiento")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_fraccinamientos
            .DataSource = DTB
            .DataValueField = "Proyecto"
            .DataTextField = "Fraccionamiento"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub AlimentarComboModelos(ByVal Proyecto As String)
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_ModelosXProyecto(Proyecto)
        DTB.Columns.AddRange({New DataColumn("id_producto"), New DataColumn("Modelo")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_producto") = "0"
                RowB("Modelo") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_producto") = Row("id_producto")
            RowB("Modelo") = Row("Modelo")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_modelos
            .DataSource = DTB
            .DataValueField = "id_producto"
            .DataTextField = "Modelo"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub

    Private Sub AlimentarTablaCitas(ByVal IdCliente As Integer)
        Dim DT As New DataTable

        DT = GE_Funciones.Obtener_CitasCliente(IdCliente) : ViewState("CitasClientes") = DT
        With grdViewCitas
            .DataSource = DT
            .DataBind()
        End With

        For Each Row As DataRow In DT.Rows
            If Row("Status") = 1 Then
                btn_asignaCita.Visible = False
                Exit For
            End If
        Next
    End Sub

    Private Sub ObtenerTipoCampana(ByVal IdCampana As Integer)
        tb_TipoCampana.Text = GE_Funciones.Obtener_TipoCampana(IdCampana)
    End Sub

    Public Function Validar_Campos()
        If cmBoxMedio.SelectedIndex = 0 Then Return False
        If cmBoxCampana.SelectedIndex = 0 Then Return False
        If cb_fraccinamientos.SelectedIndex = 0 Then Return False
        If cb_modelos.Items.Count = 0 Then Return False
        If cb_modelos.SelectedIndex = 0 Then Return False
        If dtp_fechaCita.Text = "" Then Return False

        Return True
    End Function
#End Region

#Region "Eventos"
    Protected Sub cb_fraccinamientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_fraccinamientos.SelectedIndexChanged
        AlimentarComboModelos(cb_fraccinamientos.SelectedValue)
    End Sub

    Protected Sub cmBoxMedio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxMedio.SelectedIndexChanged
        AlimentarComboCampanas(cmBoxMedio.SelectedItem.Value)
    End Sub

    Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
        ObtenerTipoCampana(cmBoxCampana.SelectedItem.Value)
    End Sub

    Protected Sub btn_asignaCita_Click(sender As Object, e As EventArgs) Handles btn_asignaCita.Click
        If Validar_Campos() Then
            Try
                If BL.Insertar_Cita(IDCliente, Usuario.id_usuario, Usuario.id_usuario, cmBoxCampana.SelectedItem.Value, tb_TipoCampana.Text, tb_origen.Text,
                                cmBoxCampana.SelectedItem.Text, cb_fraccinamientos.SelectedValue, cb_modelos.SelectedValue, dtp_finicio.Text, dtp_ffinal.Text,
                                dtp_fechaCita.Text, GE_Funciones.ObtenerRankingCliente(IDCliente), 1) Then

                    UI()
                    AlimentarTablaCitas(IDCliente)

                    lbl_mensaje.Text = MostrarExito("¡La cita se registro correctamente!")
                Else
                    lbl_mensaje.Text = MostrarError("¡No se pudo guardar la cita!")
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("No se pudo guardar la cita Error: " + ex.Message)
            End Try
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te falta capturar información para la cita, revisa los datos capturados!")
        End If
    End Sub

    Protected Sub grdViewCitas_HtmlDataCellPrepared(sender As Object, e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs) Handles grdViewCitas.HtmlDataCellPrepared
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
End Class