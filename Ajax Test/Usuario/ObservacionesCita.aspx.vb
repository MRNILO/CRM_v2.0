Public Class ObservacionesCita
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCita As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Try
            idCita = Request.QueryString("idCita")
        Catch ex As Exception
            idCita = 0
        End Try

        If idCita > 0 Then
            If Page.IsPostBack Then

            Else
                UI()
            End If
        Else
            Response.Redirect("/", False)
        End If
    End Sub

    Public Sub UI()
        tb_observaciones.Text = ""
        rBtnRealizada.SelectedIndex = 0

        If GE_Funciones.Obtener_EstatusCita(idCita) Then
            btn_guardar.Enabled = False
            btn_guardar.Visible = False
        Else
            btn_guardar.Enabled = True
            btn_guardar.Visible = True
        End If

        ObtenerObservacionesCitas()
    End Sub

    Private Sub ObtenerObservacionesCitas()
        Dim HTML As String = ""

        Dim DTA As New DataTable
        DTA = GE_Funciones.Obtener_ObservacionesCitas(idCita)

        For Each rowA As DataRow In DTA.Rows
            HTML += "<div class=""form-group""> " &
                    "   <label><b><i>" & rowA("Usuario") & "</i></b></label> - " & rowA("Creacion") & "" &
                    "</div> " &
                    "<div class=""form-group""> " &
                    "   <label><b>Observaciones:</b></label> " &
                    "   <textarea class=""form-control"" rows=""3"" placeholder=""" & rowA("Observaciones") & """ disabled></textarea> " &
                    "</div>"
        Next

        lbHtml.Text = HTML
    End Sub

#Region "Eventos"
    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If Trim(tb_observaciones.Text) = "" Then
            lbl_mensaje.Text = MostrarAviso("¡No existe ningún comentario para guardar!")
        Else
            Try
                If BL.Insertar_ObservacionesCitas(idCita, Usuario.id_usuario, rBtnRealizada.SelectedItem.Value, tb_observaciones.Text) Then
                    UI()
                    lbl_mensaje.Text = MostrarExito("¡Comentarios Guardados Exitosamente!")
                Else
                    lbl_mensaje.Text = MostrarError("¡No fue posible guardar los comentarios! ")
                End If
            Catch ex As Exception
                lbl_mensaje.Text = MostrarError("¡Ocurrio un error al guardar las observaciones! <br />" + ex.Message)
            End Try
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