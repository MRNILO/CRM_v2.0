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
            RangoFechas.Style.Add("display", "none")
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
        ViewState("Consulta") = ""
        cmBoxArchivos.SelectedIndex = 0
        lbl_ConsultaAbierta.Text = ""
        RangoFechas.Style.Add("display", "none")

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

        If (Input.ToString.ToUpper.Contains("BETWEEN")) Then
            RangoFechas.Style.Add("display", "show")
        Else
            RangoFechas.Style.Add("display", "none")
        End If

        lbl_ConsultaAbierta.Text = Input.ToUpper.Substring(0, Input.IndexOf("-- BD:") - 1)

        ViewState("Consulta") = Input
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
        Dim Consulta As String = ViewState("Consulta")
        If Consulta <> "" Then
            If (String.IsNullOrEmpty(dtp_inicio.Text) Or String.IsNullOrEmpty(dtp_Fin.Text)) Then
                lbl_mensaje.Text = MostrarExito("¡Te faltan datos para trabajar!" & vbCrLf & "Los datos de fecha Inicio y fecha fin no pueden ir vacios")
                If (String.IsNullOrEmpty(dtp_inicio.Text)) Then
                    dtp_inicio.Focus()
                Else
                    dtp_Fin.Focus()
                End If
            ElseIf (dtp_inicio.Date > dtp_Fin.Date) Then
                lbl_mensaje.Text = MostrarError("¡Te faltan datos para trabajar!" & vbCrLf & "La fecha de inicio no puede ser posterior a la fecha de fin")
                dtp_inicio.Focus()
            Else
                Consulta = Consulta.Replace("$FecInicio", Convert.ToString(dtp_inicio.Date.Year & "-" & dtp_inicio.Date.Month.ToString("00") & "-" & dtp_inicio.Date.Day.ToString("00")))
                Consulta = Consulta.Replace("$FecFin", Convert.ToString(dtp_Fin.Date.Year & "-" & dtp_Fin.Date.Month.ToString("00") & "-" & dtp_Fin.Date.Day.ToString("00")))

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
                            lbl_mensaje.Text = MostrarError("¡Conjunto de datos vacio!" & vbCrLf & Datos(0).Resultado)
                        End If
                    End If
                Else
                    lbl_mensaje.Text = MostrarAviso("Cuidado . . . Consulta de datos no valida")
                    ' txtBoxConsulta.Focus()
                End If
            End If
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te faltan datos para trabajar!" & vbCrLf & "No existen consultas para ejecutar")
            'txtBoxConsulta.Focus()
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