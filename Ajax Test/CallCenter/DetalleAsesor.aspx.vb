Public Class DetalleAsesor
    Inherits System.Web.UI.Page

    Dim Usuario As New Servicio.CUsuarios

    Dim NivelSeccion As Integer = 4
    Dim ID_Usuario As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ValidaUsuario()

        Try
            lbl_general.Text = Crea_GeneraUsuario()
            GV_Clientes.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Public Function Crea_GeneraUsuario()
        ID_Usuario = Request.QueryString("id")

        Dim HTML As String = ""
        Dim Datos = BL.Obtener_usuarios_detalles(ID_Usuario)

        HTML += "<div class=""row"">"
        HTML += "  <div class=""col-lg-2 col-lg-offset-1"">"
        HTML += "    <table class=""table table-hover"">
                       <thead>
                         <tr>
                           <th scope=""col"" style=""text-align:center""># Usuario</th>

                           <th scope=""col"" style=""text-align:center"">Usuario CRM</th>
                         </tr>
                       </thead>
                       <tbody>
                         <tr>"
        HTML += "           <td style=""text-align:center"">" + Datos.id_usuario.ToString + "</td>"
        HTML += "           <td style=""text-align:center"">" + Datos.usuario + "</td>"
        HTML += "        </tr>
                       </tbody>
                     </table>
                   </div></div>"

        HTML += " <div class=""row""> <div class=""col-lg-8 col-lg-offset-1"" style=""overflow-x:auto;"">"
        HTML += "    <table class=""table table-hover"">
                       <thead>
                         <tr>
                           <th scope=""col"" style=""text-align:center"">Nombre</th>
                           <th scope=""col"" style=""text-align:center"">Apellido Paterno</th>
                           <th scope=""col"" style=""text-align:center"">Apellido Materno</th>
                           <th scope=""col"" style=""text-align:center"">e-mail</th>
                           <th scope=""col"" style=""text-align:center"">Registro</th>
                         </tr>
                       </thead>
                       <tbody>
                         <tr>"
        HTML += "           <td style=""text-align:center"">" + Datos.nombre + "</td>"
        HTML += "           <td style=""text-align:center"">" + Datos.apellidoPaterno + "</td>"
        HTML += "           <td style=""text-align:center"">" + Datos.apellidoMaterno + "</td>"
        HTML += "           <td style=""text-align:center"">" + Datos.Email + "</td>"
        HTML += "           <td style=""text-align:center"">" + Datos.fechaCreacion + "</td>"
        HTML += "        </tr>
                       </tbody>
                     </table>
                   </div>
                 </div>"

        Return HTML
    End Function

#Region "Eventos"
    Protected Sub GV_Clientes_DataBinding(sender As Object, e As EventArgs) Handles GV_Clientes.DataBinding
        Try
            GV_Clientes.DataSource = BL.Obtener_clientes_detalles_idUsuario(ID_Usuario)
        Catch ex As Exception

        End Try

    End Sub
#End Region

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
End Class