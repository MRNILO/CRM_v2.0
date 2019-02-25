Imports System.Web.Services
Imports System.IO

Public Class nuevaEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    End Sub

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
            If BL.Inserta_empresas(tb_nombreEmpresa.Text, tb_razonSocial.Text, tb_Direccion.Text, tb_paginaweb.Text, tb_Horario.Text, cb_rubros.SelectedValue, idCiudad, tb_email.Text, tb_observaciones.Text, Resultado.Cliente) Then
            Else
                lbl_mensaje.Text += MostrarError("Ocurrio un error, por favor verifique los datos.")
            End If
        End If

        
    End Sub
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
    <WebMethod()> _
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
End Class