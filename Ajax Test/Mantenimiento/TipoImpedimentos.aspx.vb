Public Class Rankings
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
#Region "Funciones Usuario"
    Private Sub UI()
        Cargar_TipoImpedimentos()
    End Sub
    Private Sub Cargar_TipoImpedimentos()
        GV_TImpedimento.DataSource = GE_Funciones.Obtener_TipoImpedimentos()
        GV_TImpedimento.DataBind()
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
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (String.IsNullOrEmpty(txtTipoImpedimento.Text.Trim) = False) Then
                If (GE_Funciones.Existe_TipoImpedimento(txtTipoImpedimento.Text)) Then
                    lbl_mensaje.Text = MostrarError("El impedimento ya existe.")
                Else
                    If (GE_Funciones.Inserta_TipoImpedimento(txtTipoImpedimento.Text)) Then
                        lbl_mensaje.Text = MostrarExito("Se registros exitosamente.")
                        txtTipoImpedimento.Text = ""
                        Cargar_TipoImpedimentos()
                    Else
                        lbl_mensaje.Text += MostrarError("Error al guardar el tipo de impedimento.")
                    End If
                End If
            Else
                lbl_mensaje.Text = MostrarError("Indique cual es el tipo de impedimento que desea agregar.")
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Error al guardar el tipo de impedimento.")
        End Try
    End Sub
#End Region
End Class