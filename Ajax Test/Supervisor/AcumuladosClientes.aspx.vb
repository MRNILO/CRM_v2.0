Public Class AcumuladosClientes
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        PG_AcumuladosClientes.DataBind()

        'If Page.IsPostBack Then
        '    Dim Resultado = PG_AcumuladosClientes.CalcCallbackResult
        '    Resultado.
        'End If
    End Sub

    Protected Sub PG_AcumuladosClientes_DataBinding(sender As Object, e As EventArgs) Handles PG_AcumuladosClientes.DataBinding
        Try
            PG_AcumuladosClientes.DataSource = BL.Obtener_AcumuladosSupervisor(Usuario.id_usuario, dtp_inicio.Date, dtp_final.Date)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Generar_Click(sender As Object, e As EventArgs) Handles btn_Generar.Click
        PG_AcumuladosClientes.DataBind()

        PG_AcumuladosClientes.RetrieveFields()
        Try
            PG_AcumuladosClientes.Fields.Remove(PG_AcumuladosClientes.Fields("ExtensionData"))
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        PG_exporter.ExportXlsxToResponse("Acumuladosclientes")
    End Sub
    Protected Sub btn_actualiza_Click(sender As Object, e As EventArgs) Handles btn_actualiza.Click
        Wcc_grafico.RefreshData()
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