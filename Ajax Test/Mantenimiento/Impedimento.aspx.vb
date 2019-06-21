Public Class Impedimento
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            Session("idImpedimento") = Request.QueryString("Id")
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
#Region "Funciones Usuario"
    Private Sub UI()
        Dim dt_Impedimento As New DataTable
        Dim Dt_Ranking As DataTable
        Dim Aux As Integer = 0
        Cargar_Ranking()
        Cargar_TipoImpedimento()
        If String.IsNullOrEmpty(Session("idImpedimento")) = False Then
            dt_Impedimento = GE_Funciones.Obtener_Impedimento_Id(Session("idImpedimento"))
            Dt_Ranking = cb_Ranking.DataSource
            For Each row In Dt_Ranking.Rows
                If row("Ranking").ToString() = dt_Impedimento.Rows(0).Item("ranking").ToString() Then
                    cb_Ranking.SelectedIndex = Aux
                End If
                Aux = Aux + 1
            Next
            cb_TipoImpedimento.SelectedIndex = dt_Impedimento.Rows(0).Item("id_tipoImpedimento")
            txt_Impedimento.Text = dt_Impedimento.Rows(0).Item("impedimento")
        End If
    End Sub
    Private Sub Cargar_Ranking()
        Dim Aux As Integer = 0
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTB.Columns.AddRange({New DataColumn("id_Ranking"), New DataColumn("Ranking")})

        RowB = DTB.NewRow
        RowB("id_Ranking") = 0
        RowB("Ranking") = "SELECCIONA"
        DTB.Rows.Add(RowB)

        RowB = DTB.NewRow
        RowB("id_Ranking") = 1
        RowB("Ranking") = "A"
        DTB.Rows.Add(RowB)

        RowB = DTB.NewRow
        RowB("id_Ranking") = 2
        RowB("Ranking") = "B"
        DTB.Rows.Add(RowB)

        RowB = DTB.NewRow
        RowB("id_Ranking") = 3
        RowB("Ranking") = "SP"
        DTB.Rows.Add(RowB)

        With cb_Ranking
            .DataSource = DTB
            .DataValueField = "id_Ranking"
            .DataTextField = "Ranking"
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub Cargar_TipoImpedimento()
        Dim Aux As Integer = 0
        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_TipoImpedimentos()
        DTB.Columns.AddRange({New DataColumn("id_tipoImpedimento"), New DataColumn("TipoImpedimento")})

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
        With cb_TipoImpedimento
            .DataSource = DTB
            .DataValueField = "id_tipoImpedimento"
            .DataTextField = "TipoImpedimento"
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub
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
#Region "Eventos"
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If String.IsNullOrEmpty(Session("idImpedimento")) = False Then
            If String.IsNullOrEmpty(txt_Impedimento.Text) Then
                lbl_mensaje.Text = MostrarError("Indique el nombre del impedimento.")
                txt_Impedimento.Focus()
            ElseIf cb_Ranking.SelectedIndex = 0 Then
                lbl_mensaje.Text = MostrarError("Indique el ranking que desea asignar al impedimento.")
                cb_Ranking.Focus()
            ElseIf cb_TipoImpedimento.SelectedIndex = 0 Then
                lbl_mensaje.Text = MostrarError("Indique el tipo de impedimento que desea asignar al impedimento.")
                cb_TipoImpedimento.Focus()
            Else
                If GE_Funciones.Actualiza_Impedimento(txt_Impedimento.Text.ToUpper, cb_Ranking.SelectedItem.ToString, cb_TipoImpedimento.SelectedIndex, Convert.ToUInt32(Session("idImpedimento"))) Then
                    lbl_mensaje.Text = MostrarExito("El impedimento se actualizo exitosamente.")
                Else
                    lbl_mensaje.Text = MostrarError("No se puede actualizar el impedimento.")
                End If
            End If
        Else
            If String.IsNullOrEmpty(txt_Impedimento.Text) Then
                lbl_mensaje.Text = MostrarError("Indique el nombre del impedimento.")
                txt_Impedimento.Focus()
            ElseIf cb_Ranking.SelectedIndex = 0 Then
                lbl_mensaje.Text = MostrarError("Indique el ranking que desea asignar al impedimento.")
                cb_Ranking.Focus()
            ElseIf cb_TipoImpedimento.SelectedIndex = 0 Then
                lbl_mensaje.Text = MostrarError("Indique el tipo de impedimento que desea asignar al impedimento.")
                cb_TipoImpedimento.Focus()
            Else
                If GE_Funciones.Inserta_Impedimento(txt_Impedimento.Text.ToUpper, cb_Ranking.SelectedItem.ToString, cb_TipoImpedimento.SelectedIndex) Then
                    lbl_mensaje.Text = MostrarExito("El impedimento se guardo exitosamente.")
                Else
                    lbl_mensaje.Text = MostrarError("No se pudo guardar el impedimento.")
                End If
            End If
        End If
    End Sub
#End Region
End Class