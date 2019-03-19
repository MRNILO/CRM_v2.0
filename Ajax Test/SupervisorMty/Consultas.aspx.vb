Imports System.IO
Imports ClosedXML.Excel

Public Class ConsultasMty
    Inherits System.Web.UI.Page

    Const Excel_Extencion As String = ".xlsx"
    Const GESQL As String = ".gesql"

    Private GE_Funciones As New Funciones
    Private Ruta As String = ConfigurationManager.ConnectionStrings("RutaXLS").ConnectionString

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 7
    Dim idUsuario As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        If Not IsPostBack() Then
            AlimentarComboArchivos()
        End If
    End Sub

#Region "Metodos"
    Public Sub AlimentarComboArchivos()
        Try
            Dim documentos = GE_Funciones.Obtener_DocumentosSQL()

            If documentos.Count > 0 Then
                For i As Integer = 0 To documentos.Count - 1

                    cmBoxArchivos.Items.Add(documentos(i).NombreDocumento.Substring(documentos(i).NombreDocumento.LastIndexOf("\") + 1), documentos(i).NombreDocumento)
                Next

                cmBoxArchivos.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarUI()
        txtBoxConsulta.Text = ""
        cmBoxArchivos.SelectedIndex = 0

        With grdViewConsulta
            .Columns.Clear()
            .DataSource = Nothing
            .DataBind()
        End With
    End Sub

    Public Sub ObtenerDatos(ByVal Archivo As String)
        Dim Input As String = ""

        Using Reader As New IO.StreamReader(Archivo, Encoding.ASCII, True)
            Input = Reader.ReadToEnd.Replace("?", "ñ")
        End Using

        txtBoxConsulta.Text = Input
    End Sub

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

#Region "Eventos"
    Protected Sub btnAbrirArchivo_Click(sender As Object, e As EventArgs) Handles btnAbrirArchivo.Click
        ObtenerDatos(cmBoxArchivos.SelectedItem.Value)
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Consulta As String = txtBoxConsulta.Text

        If Consulta <> "" Then
            If Not GE_Funciones.Comprobar_OperacionConsulta(Consulta) Then
                Dim Datos = GE_Funciones.ObtenerDatosConsulta(Consulta)

                If Datos.Count > 0 Then
                    If Datos(0).Resultado = "Success" Then
                        With grdViewConsulta
                            .AutoGenerateColumns = True
                            .DataSource = Datos(0).DT
                            .DataBind()
                        End With

                        ViewState("ConjuntoDatos") = Datos(0).DT
                    Else
                        MostrarError("¡Conjunto de datos vacio!" & vbCrLf & Datos(0).Resultado)
                    End If
                End If
            Else
                MostrarAviso("Cuidado . . . Consulta de datos no valida")
                txtBoxConsulta.Focus()
            End If
        Else
            MostrarAviso("¡Te faltan datos para trabajar!" & vbCrLf & "No existen consultas para ejecutar")
            txtBoxConsulta.Focus()
        End If
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarUI()
    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Using wb As New XLWorkbook()
            wb.Worksheets.Add(ViewState("ConjuntoDatos"), "Hoja")
            wb.SaveAs(Ruta & "ConsultaCRM" & Excel_Extencion)
        End Using

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=ConsultaCRM" & Excel_Extencion)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        HttpContext.Current.Response.WriteFile(Ruta & "ConsultaCRM" & Excel_Extencion)
        Session("ConjuntoDatos") = Nothing
        HttpContext.Current.Response.End()
    End Sub
#End Region
End Class