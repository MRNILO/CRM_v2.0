Module Generales
    Public BL As New Servicio.Service1Client

    Function MostrarError(ByVal TextoError As String) As String
        Dim HTML As String = ""
        'HTML += "<div class=""alert alert-danger display-none"" style=""display: block;"">"
        'HTML += "					<button class=""close"" data-dismiss=""alert""></button>"
        'HTML += TextoError
        'HTML += "				</div>"

        HTML = "    <script type='text/javascript'>
jQuery(document).ready(function() {    

        sweetAlert('¡Algo salio mal!', '" + TextoError + "', 'error');
 });
    </script>"
        Return HTML
    End Function
    Function MostrarAviso(ByVal Aviso As String) As String
        Dim HTML As String = ""
        'HTML += "<div class=""alert alert-info display-none"" style=""display: block;"">"
        'HTML += "					<button class=""close"" data-dismiss=""alert""></button>"
        'HTML += Aviso
        'HTML += "				</div>"


        HTML = "    <script type='text/javascript'>
jQuery(document).ready(function() {    

        sweetAlert('¡Alerta!', '" + Aviso + "', 'warning');
 });
    </script>"

        Return HTML
    End Function
    Function MostrarExito(ByVal Aviso As String) As String
        Dim HTML As String = ""
        'HTML += "<div class=""alert alert-success display-none"" style=""display: block;"">"
        'HTML += "					<button class=""close"" data-dismiss=""alert""></button>"
        'HTML += Aviso
        'HTML += "				</div>"

        HTML = "    <script type='text/javascript'>
jQuery(document).ready(function() {    

        sweetAlert('¡Buen trabajo!', '" + Aviso + "', 'success');
 });
    </script>"


        Return HTML
    End Function
End Module
