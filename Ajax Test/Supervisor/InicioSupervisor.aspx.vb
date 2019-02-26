Public Class InicioSupervisor
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        If Not IsPostBack() Then
            rangoFechas.Style.Add("display", "none")
            rangoDias.Style.Add("display", "none")

            Alimentar_ComboFiltro()
            Alimentar_ComboDias()
        End If
    End Sub
    Public Sub Alimentar_ComboDias()
        Dim Filtros() As String = {"15", "30", "60", "90", "120", "180", ">180"}

        With cb_Dias
            For i As Integer = 0 To Filtros.Length - 1
                .Items.Add(Filtros(i))
            Next
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub

    Public Sub Alimentar_ComboFiltro()
        Dim Filtros() As String = {"Prospecto", "Visita", "Separacion", "SP"}

        With cb_tipoCliente
            For i As Integer = 0 To Filtros.Length - 1
                .Items.Add(Filtros(i))
            Next
            .DataBind()
            .SelectedIndex = 0
        End With
    End Sub

    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        GE_Clientes.WriteXlsxToResponse()
    End Sub

    Protected Sub GV_ClientesDias_DataBinding(sender As Object, e As EventArgs) Handles GV_ClientesDias.DataBinding
        Dim ActiveBinding As Boolean = Session("ActiveBinding")

        If ActiveBinding Then
            GV_ClientesDias.DataSource = ViewState("DatosDiasST")
        End If
    End Sub

    Protected Sub btn_MostrarClientes_Click(sender As Object, e As EventArgs) Handles btn_MostrarClientes.Click
        Session("ActiveBinding") = True

        Dim Etapa As Integer
        Dim Filtro As String
        Dim EsEstapa As Boolean
        Dim FechaIncio As Date
        Dim FechaFin As Date
        Dim DiasFiltro As Integer

        Select Case cb_tipoCliente.SelectedItem.Value
            Case "Prospecto"
                EsEstapa = True
                Etapa = 1
            Case "Visita"
                EsEstapa = True
                Etapa = 9
            Case "Separacion"
                EsEstapa = True
                Etapa = 5
            Case "SP"
                Filtro = "SP"
        End Select

        If rdbFechas.Checked Then
            If String.IsNullOrEmpty(dtp_inicio.Text) Then
                dtp_inicio.Date = Now.Date()
                FechaIncio = dtp_inicio.Text
            Else
                FechaIncio = dtp_inicio.Text
            End If
            If String.IsNullOrEmpty(dtp_Fin.Text) Then
                dtp_Fin.Date = Now.Date()
                FechaFin = dtp_Fin.Text
            Else
                FechaFin = dtp_Fin.Text
            End If
            DiasFiltro = 0
        End If

        If rdbDias.Checked Then
            FechaIncio = "1900-01-01"
            FechaFin = "1900-01-01"
            Select Case cb_Dias.SelectedItem.Value
                Case ">180"
                    'Programacion para mas de 180 dias 
                Case Else
                    DiasFiltro = CType(cb_Dias.SelectedValue, Int32)
            End Select
        End If

        Dim ROW As DataRow
        Dim DTA As New DataTable
        DTA.Columns.AddRange({New DataColumn("ID"), New DataColumn("Cliente"), New DataColumn("Ultima"), New DataColumn("Dias")})

        If EsEstapa Then
            Dim DiasSTEtapa As Servicio.DiasSinTrabajar()
            If rdbFechas.Checked Or rdbDias.Checked Then
                DiasSTEtapa = BL.DiasSinTrabajarEtapaFiltro(Usuario.id_usuario, Etapa, DiasFiltro, FechaIncio, FechaFin)
            Else
                DiasSTEtapa = BL.DiasSinTrabajarEtapa(Usuario.id_usuario, Etapa)
            End If

            If DiasSTEtapa.Length > 0 Then
                For i As Integer = 0 To DiasSTEtapa.Length - 1
                    ROW = DTA.NewRow
                    ROW("ID") = DiasSTEtapa(i).ID
                    ROW("Cliente") = DiasSTEtapa(i).Cliente.ToUpper
                    ROW("Ultima") = DiasSTEtapa(i).Ultima
                    ROW("Dias") = DiasSTEtapa(i).Dias

                    DTA.Rows.Add(ROW)
                Next
            End If
        Else
            Dim DiasSTFiltro = BL.DiasSinTrabajarFiltro(Usuario.id_usuario, Filtro)

            If DiasSTFiltro.Length > 0 Then
                For i As Integer = 0 To DiasSTFiltro.Length - 1
                    ROW = DTA.NewRow
                    ROW("ID") = DiasSTFiltro(i).ID
                    ROW("Cliente") = DiasSTFiltro(i).Cliente
                    ROW("Ultima") = DiasSTFiltro(i).Ultima
                    ROW("Dias") = DiasSTFiltro(i).Dias

                    DTA.Rows.Add(ROW)
                Next
            End If
        End If

        ViewState("DatosDiasST") = DTA
        GV_ClientesDias.DataBind()
    End Sub

    Protected Sub rdbFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFechas.CheckedChanged
        If (rdbFechas.Checked) Then
            cb_Dias.ClearSelection()
        End If

        rangoFechas.Style.Add("display", "show")
        rangoDias.Style.Add("display", "none")
    End Sub

    Protected Sub rdbDias_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDias.CheckedChanged
        rangoFechas.Style.Add("display", "none")
        rangoDias.Style.Add("display", "show")
    End Sub

#Region "FuncionesUsuario"
    Sub ValidaUsuario()
        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.Nivel >= NivelSeccion Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    Session("Usuario") = Usuario
                    'Response.Redirect("~/", False)
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
#End Region
End Class