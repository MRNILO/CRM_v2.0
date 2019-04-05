Imports System.Web.Services
Imports System.IO

Public Class NuevoCliente
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        If Not Page.IsPostBack Then
            UI()
            Combos()
        Else

        End If
    End Sub

#Region "Metodos"
    Public Sub UI()
        Dim NSSAleatorio As String = GE_Funciones.Generar_NSSAleatorio()
        tb_email.Text = "corrigeme@micliente" & Now.Hour & Now.Minute & Now.Second & Now.Millisecond
        tb_nss.Text = NSSAleatorio & NSSAleatorio
    End Sub
#End Region

#Region "Trabajo Fotos"
    Function TrabajoFotos() As CFotos
        Dim MaximoWidth As Integer = 400
        Dim Resultado As New CFotos

        If Path.GetExtension(Fupl_Foto_Cliente.FileName).ToLower() = "" Then
            'Sin imagen
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

    Protected Sub btn_validarCliente_Click(sender As Object, e As EventArgs) Handles btn_validarCliente.Click
        Dim listaTel As New List(Of CTelefonos)
        Dim IdCliente As Integer = 0
        lbl_mensaje.Text = ""

        If lbl_mensaje.Text <> "" Then

        Else
            If Not tb_email.Text.Contains("corrigeme") Then
                If BL.ValidaEmail(tb_email.Text) Then
                    lbl_mensaje.Text = MostrarError("El Correo ya se habia capturado previamente en otro cliente.")
                Else
                    btn_validarCliente.Visible = False
                    btn_Guardar.Visible = True
                End If
            End If
        End If
    End Sub

    Sub Combos()
        Dim Estados = BL.Obtener_estados.ToList
        Dim estado = New Servicio.CEstados

        estado.id = 0
        estado.nombre = "SELECCIONE UN ESTADO"

        Estados.Insert(0, estado)
        cb_estados.DataSource = Estados
        cb_estados.DataTextField = "nombre"
        cb_estados.DataValueField = "id"
        cb_estados.DataBind()

        cb_rubros.DataSource = BL.Obtener_rubros
        cb_rubros.DataTextField = "rubro"
        cb_rubros.DataValueField = "id_rubro"
        cb_rubros.DataBind()


        cb_nivelInteres.DataSource = BL.Obtener_nivelinteres
        cb_nivelInteres.DataTextField = "nivelinteres"
        cb_nivelInteres.DataValueField = "id_nivelInteres"
        cb_nivelInteres.DataBind()

        AlimentarComboCampanas()
    End Sub
    Private Sub AlimentarComboCampanas()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.ObtenerCampanasTipoCampana()

        DTB.Columns.AddRange({New DataColumn("id_Campana"), New DataColumn("Campana")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_Campana") = 0
                RowB("Campana") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_Campana") = Row("id_campaña")
            RowB("Campana") = Row("campañaNombre") & "  | " & Row("TipoCampaña")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cb_campañas
            .DataSource = DTB
            .DataBind()
            .DataValueField = "id_Campana"
            .DataTextField = "Campana"
        End With
    End Sub
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

    <WebMethod()>
    Public Shared Function EmpresasBusqueda(ByVal QUERY) As String
        Dim JS As String = ""
        Dim Empresas = BL.Obtener_empresasComboBusqueda(QUERY)
        JS = "{"
        For I = 0 To Empresas.Count - 1
            JS += "{empresa:" + Empresas(I).Empresa.ToString + ",id:" + Empresas(I).id_empresa.ToString + "}"
            If I = Empresas.Count - 1 Then
            Else
                JS += ","
            End If
        Next
        JS += "}"
        Return JS
    End Function

    Sub ValidaNombre()
        If Trim(tb_NombreCliente.Text) = "" Then
            tb_NombreCliente.Text = "-"
        End If
        If Trim(tb_ApellidoMaterno.Text) = "" Then
            tb_ApellidoMaterno.Text = "-"
        End If
        If Trim(tb_ApellidoPaterno.Text) = "" Then
            tb_ApellidoPaterno.Text = "-"
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
#End Region

    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim listaTel As New List(Of CTelefonos)
        Dim IdCliente As Integer = 0

        lbl_mensaje.Text = ""

        'Valida Campaña
        If cb_campañas.SelectedValue = 14 Then
            lbl_mensaje.Text += MostrarError("Por favor seleccione una campaña valida.")
            Exit Sub
        End If

        'Verifica Errores
        If lbl_mensaje.Text <> "" Then

        Else
            Try
                If IsNothing(dtp_fechaNacimiento.Date) Then
                    dtp_fechaNacimiento.Date = New Date
                End If

                If tb_curp.Text = "" Then
                    tb_curp.Text = "-"
                End If

                If tb_nss.Text = "" Then
                    tb_nss.Text = "-"
                End If

                IdCliente = BL.Inserta_clientes(tb_NombreCliente.Text, tb_ApellidoPaterno.Text, tb_ApellidoMaterno.Text, tb_email.Text, cb_productos.SelectedValue, cb_nivelInteres.SelectedValue, cb_empresas.SelectedValue _
                          , 1, cb_campañas.SelectedValue, Usuario.id_usuario, tb_observaciones.Text, "-", "-", Trim(tb_nss.Text), Trim(tb_curp.Text), dtp_fechaNacimiento.Date, cb_fracc.SelectedValue)
            Catch ex As Exception
                lbl_mensaje.Text += MostrarError("Existe un error en la información ingresada, por favor verifique e intente nuevamente")
                Exit Sub
            End Try

            If IdCliente > 0 Then
                'Agregar telefonos
                BL.Inserta_telefonoCliente(1, IdCliente, tb_telefono.Text)

                Response.Redirect("../Usuario/clientes.aspx", False)
            Else
                lbl_mensaje.Text += MostrarError("Error al insertar cliente, verifique los datos e intente de nuevo")
            End If
        End If
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Dim listaTel As New List(Of CTelefonos)
        Dim Telefono As New CTelefonos
        If Trim(tb_telefono.Text) = "" Then
            lbl_mensaje.Text += "No se encontro ningún teléfono"
        Else
            If IsNothing(Session("ListaDeTelefonos")) Then
                'No se ha agregado ningun telefono 
                Session("ListaDeTelefonos") = listaTel
            Else
                listaTel = Session("ListaDeTelefonos")
            End If

            Telefono.Telefono = tb_telefono.Text
            If chB_telPrincipal.Checked = True Then
                Telefono.Principal = True
            Else
                Telefono.Principal = False
            End If
            listaTel.Add(Telefono)
            Session("ListaDeTelefonos") = listaTel
        End If

        Crea_listaTelefonos()
    End Sub

    Sub Crea_listaTelefonos()
        Dim HTML As String = ""
        Dim listaTel As New List(Of CTelefonos)
        listaTel = Session("ListaDeTelefonos")

        If IsNothing(listaTel) Then
        Else
            For I = 0 To listaTel.Count - 1
                If listaTel(I).Principal = True Then
                    HTML += "<strong>Teléfono:</strong>" + listaTel(I).Telefono + " (Principal)"
                Else
                    HTML += "<strong>Teléfono:</strong>" + listaTel(I).Telefono
                End If

                HTML += "<br />"
            Next
        End If

        lbl_telefonos.Text = HTML

    End Sub

#Region "Nueva Empresa"
    Protected Sub btn_guardarEmpresa_Click(sender As Object, e As EventArgs) Handles btn_guardarEmpresa.Click
        Dim idCiudad As String = Request("idCiudad")

        Dim MaximoWidth As Integer = 100
        Dim Resultado As New CFotos

        If Path.GetExtension(fup_logotipo.FileName).ToLower() = "" Then
            'Sin imagen
        Else

            If Path.GetExtension(fup_logotipo.FileName).ToLower() = ".jpg" Then
                Dim Arreglo As Byte()
                Dim StrImg As String = ""
                If IsNothing(fup_logotipo.FileBytes) Then
                Else
                    Arreglo = fup_logotipo.FileBytes
                    Dim MS As New MemoryStream(Arreglo)
                    Dim Imagen1 = System.Drawing.Image.FromStream(MS)
                    Imagen1 = resizeImage(Imagen1, MaximoWidth)
                    StrImg = ImageToBase64(Imagen1, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Resultado.Cliente = StrImg
                End If
            Else
                lbl_mensaje.Text += MostrarError("-Solo se aceptan archivos JPG para imagenes.<br />")
                Exit Sub
            End If
        End If

        If idCiudad = 0 Then
            lbl_mensaje.Text += MostrarError("Seleccione un estado y una ciudad Por favor.")
        Else
            If BL.Inserta_empresas(tb_nombreEmpresa.Text, tb_razonSocial.Text, tb_Direccion.Text, tb_paginaweb.Text, tb_Horario.Text, cb_rubros.SelectedValue, idCiudad, tb_email.Text, tb_EmpObservaciones.Text, Resultado.Cliente) Then
                Combos()
            Else
                lbl_mensaje.Text += MostrarError("Ocurrio un error, por favor verifique los datos.")
            End If
        End If
        Combos()
    End Sub

    <WebMethod()>
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        Dim HTML As String = ""
        Dim Ciudades = BL.Obtener_ciudad(valor)

        HTML = "<select name=""idCiudad"" class=""form-control"">"
        For I = 0 To Ciudades.Count - 1
            HTML += " <option value=""" + Ciudades(I).id.ToString + """>" + Ciudades(I).nombre + "</option>"
        Next
        HTML += "      </select>"

        Return HTML
    End Function

    Protected Sub btn_borrarTel_Click(sender As Object, e As EventArgs) Handles btn_borrarTel.Click
        Try
            Dim listaTel As New List(Of CTelefonos)
            listaTel = Session("ListaDeTelefonos")
            listaTel.RemoveAt(listaTel.Count - 1)
            Crea_listaTelefonos()
            lbl_mensaje.Text = MostrarAviso("Teléfono eliminado")
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class

Public Class CTelefonos
    Public Telefono As String
    Public Principal As Boolean
End Class

Public Class CFotos
    Public Cliente As String = "-"
    Public TarjetaP As String = "-"
End Class