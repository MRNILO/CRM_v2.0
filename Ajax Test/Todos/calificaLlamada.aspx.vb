Public Class calificaLlamada
    Inherits System.Web.UI.Page
    Dim idLlamada As Integer = 0
    Dim idCita As Integer = 0
    Dim idCalifica As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            idLlamada = Request.QueryString("idLlam")
        Catch ex As Exception
            idLlamada = 0
        End Try
        Try
            idCita = Request.QueryString("idCita")
        Catch ex As Exception
            idCita = 0
        End Try
        Try
            idCalifica = Request.QueryString("Calif")
        Catch ex As Exception
            idCalifica = 0
        End Try

        If idCalifica = 4 Then
            '¡¡¡No hubo actividad REPORTAR!!!

            If idLlamada > 0 Then
                'Fue Llamda
                BL.Obtener_detallesEmailLlamada(idLlamada)
            Else
                'Fue Cita
                BL.ObtenerDetallesCitaEmail(idCita)
            End If

        End If

        If idLlamada > 0 Then
            'Es una calificaciond e llamada
            Try
                BL.CalificaLlamada(idLlamada, idCalifica)
            Catch ex As Exception

            End Try

        End If

        If idCita > 0 Then
            'Es una calificaciond e llamada

            Try
                BL.CalificaCita(idCita, idCalifica)
            Catch ex As Exception

            End Try
            'BL.CalificaLlamada(idCita, idCalifica)
        End If

    End Sub

End Class