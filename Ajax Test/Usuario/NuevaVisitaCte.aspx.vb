﻿Imports Ajax_Test.Funciones

Public Class NuevaVisitaCte
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 1

    Dim IDCliente As Integer = 0

    Private GE_Funciones As New Funciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ValidaUsuario()

        Try
            IDCliente = Request.QueryString("idCliente")
        Catch ex As Exception
            IDCliente = 0
        End Try

        If Not IsPostBack() Then
            UI()
        End If
    End Sub

#Region "Metodos"
    Private Sub UI()
        Dim DatosCitas As DatosCita = GE_Funciones.Obtener_DatosCita(IDCliente)

        With txBoxProyecto : .Enabled = False : .Text = DatosCitas.Proyecto : End With
        With txBoxModelo : .Enabled = False : .Text = DatosCitas.Modelo : End With
        With txBoxEsquemaFinanciero : .Enabled = False : .Text = DatosCitas.TipoCredito : End With
        With txBoxMedio : .Enabled = False : .Text = DatosCitas.Origen : End With
        With txBoxCual : .Enabled = False : .Text = DatosCitas.LugarContacto : End With
        With txBoxUsuario : .Enabled = False : .Text = DatosCitas.Asesor : End With
        With txBoxAsesor : .Enabled = False : .Text = DatosCitas.AsesorAsignado : End With
        With txBoxFechaCita : .Enabled = False : .Text = DatosCitas.FechaCita : End With
        With txBoxTipoCamapana : .Enabled = False : .Text = DatosCitas.TipoCampana : End With
        With dtp_finicio : .Enabled = False : .Text = dtp_finicio.Date = Now() : End With
        With dtp_ffinal : .Enabled = False : .Text = dtp_ffinal.Date = Now.AddDays(30) : End With

    End Sub
#End Region

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
#End Region

#Region "Eventos"

#End Region
End Class