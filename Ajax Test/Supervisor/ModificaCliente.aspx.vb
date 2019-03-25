Imports System.IO

Public Class ModificaCliente3
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
    Dim idCliente As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        idCliente = Request.QueryString("idCliente")
        If idCliente = 0 Then
            Response.Redirect("/")
        Else
            'Verifica cliente
            'If BL.VerificaCliente(idCliente, Usuario.id_usuario) Then
            'Cliente si le pertenece a este usuario
            'Mostrar información del cliente

            If Page.IsPostBack Then
            Else
                Dim Datos = BL.Obtener_ids_cliente(idCliente)
                If Not Page.IsPostBack Then
                    Combos(Datos)
                    datosCliente(Datos)
                    Fotos(Datos)
                    Session("ListaDeTelefonos") = Nothing
                End If
            End If

            'Else
            '    Response.Redirect("/")
            'End If
        End If
        GV_telefonos.DataBind()
    End Sub

    Sub Fotos(ByRef Datos As Servicio.CidCliente())
        lbl_fotocliente.Text = "<img src=""data:image/jpg;base64," + Datos(0).fotografia + """ class=""img-responsive"" />"
        lbl_fotoTpres.Text = "<img src=""data:image/jpg;base64," + Datos(0).fotoTpresentacion + """ class=""img-responsive"" />"
    End Sub

    Sub datosCliente(ByRef Datos As Servicio.CidCliente())
        tb_NombreCliente.Text = Datos(0).Nombre
        tb_ApellidoMaterno.Text = Datos(0).ApellidoMaterno
        tb_ApellidoPaterno.Text = Datos(0).ApellidoPaterno
        tb_email.Text = Datos(0).Email
        lbl_Observaciones.Text = Datos(0).Observaciones
        'tb_observaciones.Text = Datos(0).Observaciones
        ' tb_monto.Text = Datos(0).Monto.ToString
    End Sub

    Sub Combos(ByRef Datos As Servicio.CidCliente())

        Dim Estados = BL.Obtener_estados.ToList

        cb_productos.DataSource = BL.Obtener_datos_comboProductos
        cb_productos.DataTextField = "NombreCorto"
        cb_productos.DataValueField = "id_producto"
        cb_productos.DataBind()

        cb_productos.SelectedValue = Datos(0).id_producto

        cb_nivelInteres.DataSource = BL.Obtener_nivelinteres
        cb_nivelInteres.DataTextField = "nivelinteres"
        cb_nivelInteres.DataValueField = "id_nivelInteres"
        cb_nivelInteres.DataBind()
        cb_nivelInteres.SelectedValue = Datos(0).id_nivel

        'cb_empresas.DataSource = BL.Obtener_combo_empresas
        'cb_empresas.DataTextField = "Empresa"
        'cb_empresas.DataValueField = "id_empresa"
        'cb_empresas.DataBind()

        'cb_empresas.SelectedValue = Datos(0).id_empresa

        tb_empresas.Text = Datos(0).id_empresa.ToString


        cb_campañas.DataSource = BL.Obtener_combo_campañas
        cb_campañas.DataTextField = "Campaña"
        cb_campañas.DataValueField = "id_campaña"
        cb_campañas.DataBind()
        cb_campañas.SelectedValue = Datos(0).id_campaña
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
            Response.Redirect("/Account/LogOn.aspx")
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

    'Protected Sub btn_cambiaEtapa_Click(sender As Object, e As EventArgs) Handles btn_cambiaEtapa.Click
    '    Try
    '        If BL.Avanza_EtapaCliente(idCliente, Usuario.id_usuario, cb_etapas.SelectedValue, tb_observacionesEtapa.Text, cb_productos.SelectedValue) Then
    '            lbl_mensaje.Text = MostrarAviso("Etapa actualizada")
    '        Else
    '            lbl_mensaje.Text = MostrarAviso("Error al cambiar etapa")
    '        End If
    '    Catch ex As Exception
    '        lbl_mensaje.Text = MostrarAviso("Error al cambiar etapa : " + ex.Message)
    '    End Try
    'End Sub

#End Region

    Protected Sub GV_telefonos_DataBinding(sender As Object, e As EventArgs) Handles GV_telefonos.DataBinding
        GV_telefonos.DataSource = BL.Obtener_telefonosModificaCliente(idCliente)
    End Sub

    Protected Sub GV_telefonos_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles GV_telefonos.RowDeleting
        If BL.Elimina_telefonoCliente(e.Values("id_telefonoCliente")) Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Protected Sub GV_telefonos_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles GV_telefonos.RowInserting
        If BL.Inserta_telefonoCliente(e.NewValues("Principal"), idCliente, e.NewValues("Telefono")) Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Protected Sub GV_telefonos_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_telefonos.RowUpdating
        If BL.Actualiza_telefonoCliente(e.Keys("id_telefonoCliente"), e.NewValues("Principal"), idCliente, e.NewValues("Telefono")) Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click

        Dim Datos = BL.Obtener_ids_cliente(idCliente)

        lbl_mensaje.Text = ""

        Dim Fotos = TrabajoFotos()
        'Verifica Errores
        If lbl_mensaje.Text <> "" Then
            'Existen errores no se puede insertar el cliente
        Else
            If Fotos.Cliente = "" Then
                Fotos.Cliente = Datos(0).fotografia
            End If

            If Fotos.TarjetaP = "" Then
                Fotos.TarjetaP = Datos(0).fotoTpresentacion
            End If

            ' Existe al menos un telefono
            If BL.Actualiza_clientes(idCliente, tb_NombreCliente.Text, tb_ApellidoPaterno.Text, tb_ApellidoMaterno.Text, tb_email.Text, cb_productos.SelectedValue, cb_nivelInteres.SelectedValue, tb_empresas.Text, cb_campañas.SelectedValue, tb_observaciones.Text, Fotos.Cliente, Fotos.TarjetaP, 0) Then
                Response.Redirect("../Supervisor/ClienteSupervisor.aspx?idCliente=" + idCliente.ToString, False)
            Else
                lbl_mensaje.Text += MostrarError("Error al insertar cliente, verifique los datos e intente de nuevo")
            End If
        End If
    End Sub

    Protected Sub btn_verobservacion_Click(sender As Object, e As EventArgs) Handles btn_verobservacion.Click
        Response.Redirect("../Supervisor/DetalleObservacion.aspx?idCliente=" + idCliente.ToString, False)
    End Sub
#Region "Trabajo Fotos"
    Function TrabajoFotos() As CFotos
        Dim MaximoWidth As Integer = 400
        Dim Resultado As New CFotos

        If Path.GetExtension(Fupl_Foto_Cliente.FileName).ToLower() = "" Then
            'Sin imagen
            Resultado.Cliente = ""
        Else

            If Path.GetExtension(Fupl_Foto_Cliente.FileName).ToLower() = ".jpg" Then
                Dim Arreglo As Byte()
                Dim StrImg As String = ""
                If IsNothing(Fupl_Foto_Cliente.FileBytes) Then
                Else
                    Arreglo = Fupl_Foto_Cliente.FileBytes
                    Dim MS As New MemoryStream(Arreglo)
                    Dim Imagen1 = System.Drawing.Image.FromStream(MS)
                    Imagen1 = resizeImage(Imagen1, MaximoWidth)
                    StrImg = ImageToBase64(Imagen1, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Resultado.Cliente = StrImg
                End If
            Else
                lbl_mensaje.Text += MostrarError("-Solo se aceptan archivos JPG para imagenes.<br />")
            End If
        End If

        If Path.GetExtension(Fupl_bCard.FileName).ToLower() = "" Then
            'Sin imagen
            Resultado.TarjetaP = ""
        Else
            If Path.GetExtension(Fupl_bCard.FileName).ToLower() = ".jpg" Then
                Dim Arreglo As Byte()
                Dim StrImg As String = ""
                If IsNothing(Fupl_bCard.FileBytes) Then
                Else
                    Arreglo = Fupl_bCard.FileBytes
                    Dim MS As New MemoryStream(Arreglo)
                    Dim Imagen1 = System.Drawing.Image.FromStream(MS)
                    Imagen1 = resizeImage(Imagen1, MaximoWidth)
                    StrImg = ImageToBase64(Imagen1, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Resultado.TarjetaP = StrImg
                End If
            Else
                lbl_mensaje.Text += MostrarError("-Solo se aceptan archivos JPG para imagenes.<br />")
            End If
        End If

        Return Resultado
    End Function
    Function resizeImage(ByVal Imagen As System.Drawing.Image, ByVal MaximoLargo As Integer)
        Dim original As Drawing.Bitmap, resizedImage As Drawing.Bitmap

        Try
            'Using fs As FileStream = New System.IO.FileStream(, System.IO.FileMode.Open)
            '    original = New Drawing.Bitmap(fs)
            'End Using

            original = Imagen

            Dim rectHeight As Integer = 100
            Dim rectWidth As Integer = MaximoLargo

            'if the image is squared set it's height and width to the smallest of the desired dimensions (our box). In the current example rectHeight<rectWidth
            If original.Height = original.Width Then
                resizedImage = New Drawing.Bitmap(original, rectHeight, rectHeight)
            Else
                'calculate aspect ratio
                Dim aspect As Single = original.Width / CSng(original.Height)
                Dim newWidth As Integer, newHeight As Integer

                'calculate new dimensions based on aspect ratio
                newWidth = CInt(rectWidth * aspect)
                newHeight = CInt(newWidth / aspect)

                'if one of the two dimensions exceed the box dimensions
                If newWidth > rectWidth OrElse newHeight > rectHeight Then
                    'depending on which of the two exceeds the box dimensions set it as the box dimension and calculate the other one based on the aspect ratio
                    If newWidth > newHeight Then
                        newWidth = rectWidth
                        newHeight = CInt(newWidth / aspect)
                    Else
                        newHeight = rectHeight
                        newWidth = CInt(newHeight * aspect)
                    End If
                End If
                resizedImage = New Drawing.Bitmap(original, newWidth, newHeight)
            End If
        Catch ex As Exception

        End Try
        Return resizedImage
    End Function
    Public Function ImageToBase64(image As System.Drawing.Image, format As System.Drawing.Imaging.ImageFormat) As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray()

            ' Convert byte[] to Base64 String
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function
#End Region
End Class