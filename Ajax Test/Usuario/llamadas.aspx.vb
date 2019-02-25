Public Class llamadas
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCliente As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Page.IsPostBack Then
        Else
            dtp_inicio.Date = Now.AddDays(-1)
            dtp_final.Date = Now
            'Session("ReporteLlamadas") = BL.Obtener_llamadasFechaUsuario(Usuario.id_usuario, dtp_inicio.Date, dtp_final.Date)
        End If
        GV_Llamadas.DataBind()

    End Sub


    Protected Sub btn_generar_Click(sender As Object, e As EventArgs) Handles btn_generar.Click
        '  Session("ReporteLlamadas") = BL.Obtener_llamadasFechaUsuario(Usuario.id_usuario, dtp_inicio.Date, dtp_final.Date)
        GV_Llamadas.DataBind()
    End Sub

    Protected Sub GV_Llamadas_DataBinding(sender As Object, e As EventArgs) Handles GV_Llamadas.DataBinding
        'GV_Llamadas.DataSource = Session("ReporteLlamadas")
        GV_Llamadas.DataSource = BL.Obtener_llamadasFechaUsuario(Usuario.id_usuario, dtp_inicio.Date, dtp_final.Date)
    End Sub
    Protected Sub GV_Llamadas_CustomColumnDisplayText(sender As Object, e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs) Handles GV_Llamadas.CustomColumnDisplayText
        If e.Column.Name = "Opciones" Then
            If GV_Llamadas.GetRowValues(e.VisibleRowIndex, "realizada") = "REALIZADA" Then
                e.DisplayText = "Ya realizada"
            Else

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