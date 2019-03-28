Imports System.Web.Services
Public Class NuevoCliente1
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 4
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim IDCliente As Integer = 0

        If cb_campañas.SelectedValue = 14 Then
            lbl_mensaje.Text += "<strong style='color:red'>DEBE SELECCIONAR UN ORIGEN/CAMPAÑA VALIDO</strong>"
            Exit Sub
        End If

        Try
            If Trim(tb_email.Text) = "" Then
                tb_email.Text = "-"
            End If
            If Trim(tb_nombre.Text) = "" Then
                tb_nombre.Text = "-"
            End If
            If Trim(tb_paterno.Text) = "" Then
                tb_paterno.Text = "-"
            End If
            If Trim(tb_materno.Text) = "" Then
                tb_materno.Text = "-"
            End If
            If Trim(tb_nss.Text) = "" Then
                tb_nss.Text = "-"
            End If
            If Trim(tb_curp.Text) = "" Then
                tb_curp.Text = "-"
            End If
            If Trim(tb_rfc.Text) = "" Then
                tb_rfc.Text = "-"
            End If
            If Trim(tb_nHijos.Text) = "" Then
                tb_nHijos.Text = 0
            End If
            If Trim(tb_ingresosPersonales.Text) = "" Then
                tb_ingresosPersonales.Text = 0
            End If
            If Trim(tb_tel.Text) = "" Then
                tb_tel.Text = 0
            End If
            If Trim(tb_lada.Text) = "" Then
                tb_lada.Text = 0
            End If

            IDCliente = BL.Inserta_clientes(tb_nombre.Text, tb_paterno.Text, tb_materno.Text, tb_email.Text, cb_producto.SelectedValue, 1, 5340 _
                        , 1, cb_campañas.SelectedValue, Usuario.id_usuario, "Tipo CREDITO: " + CB_TIPOcREDITO.SelectedValue, "-", "-", Trim(tb_nss.Text), Trim(tb_curp.Text), dtp_fecnac.Date, cb_fracc.SelectedValue)

            If IDCliente > 0 Then
                BL.Inserta_telefonoCliente(1, IDCliente, (tb_lada.Text + "-" + tb_tel.Text).ToString)

                BL.CompletaCliente(IDCliente, 0, "-", tb_rfc.Text, tb_nHijos.Text, tb_ingresosPersonales.Text, cb_edoCivil.SelectedValue)
            End If

            Try
                BL.Inserta_ClientesCC(IDCliente, Usuario.id_usuario, CB_TIPOcREDITO.SelectedValue)
            Catch ex As Exception

            End Try
            Response.Redirect("cita.aspx?id=" + IDCliente.ToString, False)
        Catch ex As Exception
            lbl_mensaje.Text += "<strong style='color:red'>Por favor complete todos los campos </strong>"
        End Try
    End Sub

#Region "FuncionesUsuario"
    <WebMethod()>
    Public Shared Function ValidaCliente(ByVal nombre As String, ByVal app1 As String, ByVal app2 As String) As String
        Dim HTML As String = ""
        If BL.ValidaCliente(nombre, app1, app2) Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function

    <WebMethod()>
    Public Shared Function ValidaNSS(ByVal nss As String) As String
        Dim HTML As String = ""
        If BL.ComprobarNSS(nss) > 0 Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function

    <WebMethod()>
    Public Shared Function ValidaCURP(ByVal curp As String) As String
        Dim HTML As String = ""
        If BL.ComprobarCURP(curp) > 0 Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function

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