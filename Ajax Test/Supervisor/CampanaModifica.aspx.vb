Imports DevExpress.Web

Public Class CampanaModifica
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ValidaUsuario()
        If Not Page.IsPostBack Then
            Session("idCampana") = Request.QueryString("Id")
            If Session("idCampana") = 0 Then
                Response.Redirect("/")
            Else
                comboTiposCampaña()
                comboMedioCampaña()
                ObtieneDatosCampana()
            End If
        End If
    End Sub
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
        End Select
    End Sub
    Sub comboTiposCampaña()
        Dim Aux As Integer = 0
        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow
        Dim DatosTipoCampaña = BL.Obtener_tipocampaña

        DTB.Columns.AddRange({New DataColumn("id_tipoCampaña"), New DataColumn("TipoCampaña")})

        For tipoCampaña = 0 To DatosTipoCampaña.Count - 1
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_tipoCampaña") = 0
                RowB("TipoCampaña") = "SELECCIONA"
                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_tipoCampaña") = DatosTipoCampaña(tipoCampaña).id_tipoCampaña
            RowB("TipoCampaña") = DatosTipoCampaña(tipoCampaña).TipoCampaña

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_tiposCampañas
            .DataSource = DTB
            .DataTextField = "TipoCampaña"
            .DataValueField = "id_tipoCampaña"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Sub comboMedioCampaña()
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

        With cb_MedioCampañas
            .DataSource = DTB
            .DataValueField = "Id_Medio"
            .DataTextField = "NombreMedio"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Sub ObtieneDatosCampana()
        Dim dt_DatosCampana As New DataTable
        dt_DatosCampana = GE_Funciones.ObtenerCampanasId(Session("idCampana"))

        If dt_DatosCampana.Rows.Count > 0 Then
            tb_NombreCampaña.Text = dt_DatosCampana.Rows(0).ItemArray(1).ToString()
            cb_tiposCampañas.SelectedValue = dt_DatosCampana.Rows(0).ItemArray(2)
            cb_MedioCampañas.SelectedValue = dt_DatosCampana.Rows(0).ItemArray(8)
            dtp_inicio.Date = dt_DatosCampana.Rows(0).ItemArray(6)
            dtp_final.Date = dt_DatosCampana.Rows(0).ItemArray(7)
            tb_observaciones.Text = dt_DatosCampana.Rows(0).ItemArray(4)
            If dt_DatosCampana.Rows(0).ItemArray(5) = 0 Then
                chkActivo.Checked = False
            Else
                chkActivo.Checked = True
            End If
        Else
            Response.Redirect("/")
        End If
    End Sub
#End Region
#Region "Eventos"
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Try
            If (cb_MedioCampañas.SelectedValue = 0 Or cb_tiposCampañas.SelectedValue = 0) Then
                lbl_mensaje.Text = MostrarError("Error, por favor verifique los datos ingresados.")
            Else
                If GE_Funciones.Actualiza_Campanas(Session("idCampana"), tb_NombreCampaña.Text, cb_tiposCampañas.SelectedValue, cb_MedioCampañas.SelectedValue, If(chkActivo.Checked, 1, 0), dtp_inicio.Date, dtp_final.Date, tb_observaciones.Text) Then
                    lbl_mensaje.Text = MostrarExito("Campaña actualizada")
                    ASPxWebControl.RedirectOnCallback("../Supervisor/campanas.aspx")
                Else
                    lbl_mensaje.Text = MostrarError("Error, por favor verifique los datos ingresados.")
                End If
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error, por favor verifique los datos ingresados. codigo: " + ex.Message)
        End Try
    End Sub

#End Region

End Class