Module Generales
    Public BL As New Servicio.Service1Client
    Public EK_REST As New EKREST.Iwcf_enkontrolClient

    Function MostrarError(ByVal TextoError As String) As String
        Dim HTML As String = ""

        HTML = "<script type='text/javascript'>
                    jQuery(document).ready(function() {    
                    sweetAlert('¡Algo salio mal!', '" + TextoError + "', 'error');});
                </script>"
        Return HTML
    End Function

    Function MostrarAviso(ByVal Aviso As String) As String
        Dim HTML As String = ""

        HTML = "<script type='text/javascript'>
                     jQuery(document).ready(function() {    
                    sweetAlert('¡Alerta!', '" + Aviso + "', 'warning');});
                </script>"

        Return HTML
    End Function

    Function MostrarExito(ByVal Aviso As String) As String
        Dim HTML As String = ""

        HTML = "<script type='text/javascript'>
                     jQuery(document).ready(function() {    
                     sweetAlert('¡Buen trabajo!', '" + Aviso + "', 'success');});
                </script>"

        Return HTML
    End Function
End Module
