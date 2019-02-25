Imports System.Web.Services

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim Usuario As New Servicio.CUsuarios


        If Not IsNothing(Session("Usuario")) Then
            Usuario = Session("Usuario")
            If Usuario.id_usuario > 0 Then
                If String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then


                    Session("Usuario") = Usuario

                    RedirigirSegunNivel(Usuario.Nivel)
                    'Response.Redirect("~/", False)
                Else
                    Session("Usuario") = Usuario

                End If
            Else
                'No valido
                'lbl_error.Text = MostrarError("Usuario o/y contraseña equivocados")
            End If
        Else
            Session.Clear()
            Response.Redirect("~/Account/LogOn.aspx")
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function PruebaAjax(ByVal valor As String) As String
        Return "Hola " + valor.ToString
    End Function
    Sub RedirigirSegunNivel(ByVal Nivel As Integer)
        Select Case Nivel
            Case 1
                Response.Redirect("~/Usuario/InicioUsuario.aspx", False)
            Case 2
                Response.Redirect("~/Supervisor/InicioSupervisor.aspx", False)
            Case 3
                Response.Redirect("~/Administrativo/InicioAdmin.aspx", False)
            Case 4
                Response.Redirect("~/CallCenter/InicioCCenter.aspx", False)
        End Select
    End Sub
End Class