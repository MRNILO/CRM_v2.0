Public Class agenda
    Inherits System.Web.UI.Page
    Dim NivelSeccion As Integer = 2
    Dim Usuario As New Servicio.CUsuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()
    End Sub
    Function CreaCalendario()
        Dim JS As String = ""

        JS = "<script type=""text/javascript"">
        $(document).ready(function () {

            // page is now ready, initialize the calendar...

            $('#calendar').fullCalendar({
                // put your options and callbacks here
                lang: 'es',
                events: [{
                    title: 'Click for Google',
                    start: '2016-05-09T12:30:00',
                    end: '2016-05-09T18:30:00',
                    backgroundColor: App.getBrandColor('yellow'),
                    url: 'http://google.com/',
                }]
            })

        });
    </script>"

        Return JS
    End Function

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
End Class