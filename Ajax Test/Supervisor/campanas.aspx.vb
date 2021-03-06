﻿Imports DevExpress.Web

Public Class campanas
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
        If Not IsPostBack() Then
            CargaCampañas()
        End If

    End Sub
    Protected Sub GV_campañas_DataBinding(sender As Object, e As EventArgs) Handles GV_campañas.DataBinding
        GV_campañas.DataSource = ViewState("ListaCampañas")
    End Sub

#Region "FuncionesUsuario"
    Sub CargaCampañas()
        Dim DT = BL.Obtener_campañasDetalles()
        ViewState("ListaCampañas") = DT

        With GV_campañas
            .DataSource = DT
            .DataBind()
        End With

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
    Protected Sub GV_campañas_CustomButtonCallback(sender As Object, e As ASPxGridViewCustomButtonCallbackEventArgs) Handles GV_campañas.CustomButtonCallback
        Dim IdCampana As Integer = GV_campañas.GetRowValues(e.VisibleIndex, "id_campaña")
        ASPxWebControl.RedirectOnCallback("../Supervisor/CampanaModifica?id=" + IdCampana.ToString)
    End Sub
#End Region
End Class