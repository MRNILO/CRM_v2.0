Imports System.Web.Services
Imports Ajax_Test.Funciones

Public Class DatosCliente
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub

#Region "Eventos"
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If (BuscarClientes(txtNumCliente.Text) = False) Then
                txtNumCliente.Text = ""
                lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
        End Try
    End Sub

    Protected Sub btn_ActualizarDatos_Click(sender As Object, e As EventArgs) Handles btn_ActualizarDatos.Click
        Try
            If (ValidaCliente(txtnombre.Text.ToUpper, txtAPaterno.Text.ToUpper.Trim, txtAMaterno.Text.ToUpper.Trim, Convert.ToInt32(txtNumCliente.Text)) = "si") Then
                If (ValidaNSS(txtNSS.Text.ToUpper.Trim, Convert.ToInt32(txtNumCliente.Text)) = "si") Then
                    If (ValidaCURP(txtCURP.Text.ToUpper.Trim, Convert.ToInt32(txtNumCliente.Text)) = "si") Then
                        If (GE_Funciones.Actualiza_Cliente(txtNumCliente.Text, txtAPaterno.Text.ToUpper, txtAMaterno.Text.ToUpper, txtnombre.Text.ToUpper, txtCURP.Text.ToUpper, txtNSS.Text.ToUpper, txtEmail.Text, txtRFC.Text.ToUpper, cb_edoCivil.Text.ToUpper, txtObservaciones.Text.ToUpper, cbEmpresa.Text, dtFechaNacimiento.Date, Usuario.id_usuario)) Then
                            lbl_mensaje.Text = MostrarExito("Cliente actualizado.")
                            txtAPaterno.Text = ""
                            txtAMaterno.Text = ""
                            txtnombre.Text = ""
                            txtCURP.Text = ""
                            txtNSS.Text = ""
                            txtEmail.Text = ""
                            txtRFC.Text = ""
                            txtObservaciones.Text = ""
                            cb_edoCivil.Text = ""
                            cbEmpresa.Text = ""
                            dtFechaNacimiento.Text = ""
                            txtNumCliente.Text = ""
                        Else
                            lbl_mensaje.Text = MostrarError("No se puedo actualizar el cliente")
                        End If
                    Else
                        lbl_mensaje.Text = MostrarError("Cliente duplicado, verifique el CURP")
                    End If
                Else
                    lbl_mensaje.Text = MostrarError("Cliente duplicado, verifique el NSS")
                End If
            Else
                lbl_mensaje.Text = MostrarError("Cliente duplicado, verifique el Nombre")
            End If
        Catch ex As Exception
            lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
        End Try
    End Sub
#End Region

#Region "Funciones de usuario"
    Private Sub UI()
    End Sub
    Public Function ValidaCliente(ByVal nombre As String, ByVal app1 As String, ByVal app2 As String, ByVal idCliente As Integer) As String
        Dim HTML As String = ""
        If GE_Funciones.ValidaCliente(nombre, app1, app2, idCliente) Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function
    Public Function ValidaNSS(ByVal nss As String, ByVal idCliente As Integer) As String
        Dim HTML As String = ""
        If GE_Funciones.ValidaNSS(nss, idCliente) Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function
    Public Function ValidaCURP(ByVal curp As String, ByVal idCliente As Integer) As String
        Dim HTML As String = ""
        If GE_Funciones.ValidaCURP(curp, idCliente) Then
            HTML = "duplicado"
        Else
            HTML = "si"
        End If
        Return HTML
    End Function
    Public Function BuscarClientes(ByVal NumCliente As Integer) As Boolean
        Dim Cliente As New BusquedaCliente
        Dim NombreCliente As String = ""
        Dim DT As New DataTable

        If IsNumeric(NumCliente) Then
            Cliente.IdCliente = NumCliente
        Else
            txtNumCliente.Text = 0
            Cliente.IdCliente = 0
            Return False
        End If

        If (Cliente.IdCliente <> 0) Then
            Dim Datos = BL.Obtener_ids_cliente(Cliente.IdCliente)
            datosCliente(Datos)
            Dim Telefonos = BL.Obtener_Clientes_Telefonos_idCliente(NumCliente)
            GV_telefonos.DataSource = BL.Obtener_telefonosModificaCliente(NumCliente)
            GV_telefonos.DataBind()
            Return True
        End If
        Return False
    End Function
    Sub datosCliente(ByRef Datos As Servicio.CidCliente())
        txtnombre.Text = Datos(0).Nombre
        txtAMaterno.Text = Datos(0).ApellidoMaterno
        txtAPaterno.Text = Datos(0).ApellidoPaterno
        txtEmail.Text = Datos(0).Email
        txtNSS.Text = Datos(0).NSS
        txtCURP.Text = Datos(0).CURP
        cbEmpresa.Text = Datos(0).id_empresa
        txtObservaciones.Text = Datos(0).Observaciones
        cb_edoCivil.Value = Datos(0).EdoCivil
        txtRFC.Text = Datos(0).RFC
        dtFechaNacimiento.Date = Datos(0).fechaNacimiento.ToString("yyyy-MM-dd")
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
End Class