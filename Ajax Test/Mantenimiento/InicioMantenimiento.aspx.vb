﻿Public Class InicioMantenimiento
    Inherits System.Web.UI.Page
    Dim Usuario As New Servicio.CUsuarios
    Dim NivelSeccion As Integer = 8

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
    End Sub
#Region "Funciones Usuario"
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