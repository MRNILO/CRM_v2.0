Imports System.IO
Imports ClosedXML.Excel
Public Class Consultas
    Inherits System.Web.UI.Page

    Const Excel_Extencion As String = ".xlsx"
    Const GESQL As String = ".gesql"

    Private Const DATE_MASK = "yyyy-MM-dd"

    Private GE_Funciones As New Funciones
    Private Ruta As String = ConfigurationManager.ConnectionStrings("RutaXLS").ConnectionString
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 2
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
        dtp_inicio.Text = ""
        dtp_Fin.Text = ""
        lbl_Total.Text = ""
        lbl_mensaje.Text = ""

        LimpiaGrid()
    End Sub
    Sub LimpiaGrid()
        lbl_Total.Text = ""
        With grdViewConsulta
            .Columns.Clear()
            .Dispose()
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

    Protected Sub grdViewConsulta_DataBinding(sender As Object, e As EventArgs) Handles grdViewConsulta.DataBinding
        grdViewConsulta.DataSource = ViewState("ConjuntoDatos")
    End Sub
    Protected Sub btnAbrirArchivo_Click(sender As Object, e As EventArgs) Handles btnAbrirArchivo.Click
        LimpiaGrid()
        ObtenerDatos(cmBoxArchivos.SelectedItem.Value)
        lbl_mensaje.Text = ""
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Consulta As String = ViewState("Consulta")
        Dim FechaInicio As Date
        Dim FechaFinal As Date

        If Consulta <> "" Then
            If (String.IsNullOrEmpty(dtp_inicio.Text) Or String.IsNullOrEmpty(dtp_Fin.Text)) Then
                lbl_mensaje.Text = MostrarAviso("¡Te faltan datos para trabajar! \n" & "Los datos de fecha Inicio y fecha fin no pueden ir vacíos")
                If (String.IsNullOrEmpty(dtp_inicio.Text)) Then
                    dtp_inicio.Focus()
                Else
                    dtp_Fin.Focus()
                End If
            ElseIf (dtp_inicio.Date > dtp_Fin.Date) Then
                lbl_mensaje.Text = MostrarAviso("¡Te faltan datos para trabajar! \n" & "La fecha de inicio no puede ser posterior a la fecha de fin")
                dtp_inicio.Focus()
            Else
                FechaInicio = dtp_inicio.Text : FechaFinal = dtp_Fin.Text

                Consulta = Consulta.Replace("$FecInicio", dtp_inicio.Text).Replace("$FecFin", FechaFinal)

                If Not GE_Funciones.Comprobar_OperacionConsulta(Consulta) Then
                    Dim Datos = GE_Funciones.ObtenerDatosConsulta(Consulta)

                    LimpiaGrid()

                    If Datos.Count > 0 Then
                        ViewState("ConjuntoDatos") = Datos(0).DT
                        If Datos(0).Resultado = "Success" Then
                            With grdViewConsulta
                                .AutoGenerateColumns = True
                                .DataSource = ViewState("ConjuntoDatos")
                                .DataBind()
                            End With
                            lbl_mensaje.Text = ""
                            lbl_Total.Text = "Total registros: " & Datos(0).DT.Rows.Count
                        Else
                            lbl_mensaje.Text = MostrarError("¡Conjunto de datos vacio! \n" & Datos(0).Resultado)
                        End If
                    End If
                Else
                    lbl_mensaje.Text = MostrarAviso("Cuidado . . . Consulta de datos no valida")
                End If
            End If
        Else
            lbl_mensaje.Text = MostrarAviso("¡Te faltan datos para trabajar! \n" & "No existen consultas para ejecutar")
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
        lbl_mensaje.Text = ""
    End Sub
#End Region
End Class