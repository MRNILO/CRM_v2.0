Public Class MisDatos
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1
    Dim idCliente As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        Dim DatosUsuario = BL.Obtener_usuarios_detalles(Usuario.id_usuario)
        CreaDatosGenerales(DatosUsuario)
        GV_telefonos.DataBind()

        If Page.IsPostBack Then
        Else
            tb_Nombre.Text = DatosUsuario.nombre
            tb_apellidoPaterno.Text = DatosUsuario.apellidoPaterno
            tb_apellidoMaterno.Text = DatosUsuario.apellidoMaterno
            tb_email.Text = DatosUsuario.Email
        End If


    End Sub
    Sub CreaDatosGenerales(ByVal DatosUsuario As Servicio.CUsuarios)
        Dim HTML As String = ""
        HTML += "<strong>Nombre completo:</strong> " + DatosUsuario.nombre + " " + DatosUsuario.apellidoPaterno + " " + DatosUsuario.apellidoMaterno
        HTML += "<br />"
        HTML += "<strong>Email:</strong> " + DatosUsuario.Email
        HTML += "<br />"
        HTML += "<strong>Usuario:</strong> " + DatosUsuario.usuario
        HTML += "<br />"
        HTML += "<strong>Registrado desde:</strong> " + DatosUsuario.fechaCreacion.ToLongDateString
        HTML += "<br />"
        lbl_generales.Text = HTML

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
    Protected Sub GV_telefonos_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles GV_telefonos.RowDeleting
        If BL.Elimina_telefonoUsuario(e.Keys("id_telefonoUsuario")) Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub GV_telefonos_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles GV_telefonos.RowInserting
        If IsNothing(e.NewValues("Principal")) Or e.NewValues("Principal") = "" Or e.NewValues("Principal") = 0 Then
            e.NewValues("Principal") = 0
        Else
            e.NewValues("Principal") = 1
        End If
        If BL.Inserta_telefonoUsuario(e.NewValues("Principal"), Usuario.id_usuario, e.NewValues("Telefono")) Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub GV_telefonos_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_telefonos.RowUpdating

        If BL.Actualiza_telefonoUsuario(e.Keys("id_telefonoUsuario"), e.NewValues("Principal"), Usuario.id_usuario, e.NewValues("Telefono")) Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub GV_telefonos_DataBinding(sender As Object, e As EventArgs) Handles GV_telefonos.DataBinding
        GV_telefonos.DataSource = BL.Obtener_telefonoUsuario(Usuario.id_usuario)
    End Sub

    Private Sub btn_guardarDatos_Click(sender As Object, e As EventArgs) Handles btn_guardarDatos.Click
        If tb_contraseña.Text = tb_contraseñaRepite.Text Then
            If tb_contraseña.Text = "" Then
            Else
                If BL.Actualiza_contraseaUsuario(Usuario.id_usuario, CalculateMD5Hash(tb_contraseña.Text)) Then
                Else
                    lbl_mensaje.Text = "Error al cambiar la contraseña"
                End If
            End If
        Else
            lbl_mensaje.Text = "Las contraseñas no coinciden"
        End If
        If BL.Actualiza_usuarios(Usuario.id_usuario, tb_Nombre.Text, tb_apellidoPaterno.Text, tb_apellidoMaterno.Text, tb_email.Text, 1) Then


            Response.Redirect("../Usuario/MisDatos.aspx", False)
        End If
    End Sub
    Public Function CalculateMD5Hash(input As String) As String


        Dim md5 = System.Security.Cryptography.MD5.Create()
        Dim inputBytes = System.Text.Encoding.ASCII.GetBytes(input)
        Dim hash = md5.ComputeHash(inputBytes)


        Dim sb = New StringBuilder()

        For I = 0 To hash.Length - 1
            sb.Append(hash(I).ToString("X2"))
        Next



        Return sb.ToString()
    End Function
End Class