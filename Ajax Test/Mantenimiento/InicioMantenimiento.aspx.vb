Imports Ajax_Test.Funciones

Public Class InicioMantenimiento
    Inherits System.Web.UI.Page
    Dim Id_Cliente As Integer = 0
    Private GE_Funciones As New Funciones
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UI()
        Else
            lbl_mensaje.Text = ""
        End If
    End Sub
#Region "Eventos"
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarClientes()
    End Sub
    'Protected Sub cmBoxUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxUsuarios.SelectedIndexChanged
    '    lblUsuario.Text = cmBoxUsuarios.SelectedItem.Text
    '    tab_CambiaUsuarioAsignado.Attributes.Add("class", "active")
    '    'tab_CambiaUsuarioAsignado.Attributes.Add("aria-expanded", "true")
    'End Sub
    'Protected Sub cmBoxCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmBoxCampana.SelectedIndexChanged
    '    lblCampana.Text = cmBoxCampana.SelectedItem.Text
    '    tab_CambiaCampana.Attributes.Add("class", "active")
    'End Sub
#End Region
#Region "Metodos"
    Private Sub UI()
        AlimentarComboUsuarios()
        AlimentarComboCampanas()
    End Sub
    Public Sub BuscarClientes()
        Dim Cliente As New BusquedaCliente
        Dim DT As New DataTable

        Cliente.IdCliente = txtNumCliente.Text

        DT = GE_Funciones.BuscarClientes(Cliente)
        ViewState("ListaClientes") = DT
        If DT.Rows.Count > 0 Then
            For Each row In DT.Rows
                lblNombreCliente.Text = row("Cliente").ToString
                Id_Cliente = Convert.ToInt32(txtNumCliente.Text())
                cargarCitas()
            Next
        Else
            txtNumCliente.Text = ""
            lblNombreCliente.Text = ""
            lbl_mensaje.Text += MostrarError("Cliente no existe, verifique los datos e intente de nuevo")
        End If
    End Sub
    Private Sub cargarCitas()
        GV_citas.DataSource = GE_Funciones.Obtener_CitasActivasCliente(Id_Cliente)
        GV_citas.DataBind()
    End Sub
    Private Sub AlimentarComboCampanas()
        With cmBoxCampana
            .DataSource = GE_Funciones.ObtenerCampanas()
            .ValueField = "id_campaña"
            .TextField = "campañaNombre"
            .DataBind()

            .SelectedIndex = 0
        End With
    End Sub
    Private Sub AlimentarComboUsuarios()
        Dim Aux As Integer = 0

        Dim DTA As New DataTable
        Dim DTB As New DataTable
        Dim RowB As DataRow

        DTA = GE_Funciones.Obtener_Usuarios()
        DTB.Columns.AddRange({New DataColumn("id_usuario"), New DataColumn("nombre")})

        For Each Row As DataRow In DTA.Rows
            If Aux = 0 Then
                RowB = DTB.NewRow
                RowB("id_usuario") = 0
                RowB("nombre") = "SELECCIONA"

                DTB.Rows.Add(RowB)
            End If

            RowB = DTB.NewRow
            RowB("id_usuario") = Row("id_usuario")
            RowB("nombre") = Row("nombre")

            DTB.Rows.Add(RowB)
            Aux += 1
        Next

        With cmBoxUsuarios
            .DataSource = DTB
            .DataBind()
            .ValueField = "id_usuario"
            .TextField = "nombre"
        End With
    End Sub
#End Region
    Protected Sub cbPanelRanking_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelUsuarioAsignado.Callback
        lblUsuario.Text = cmBoxUsuarios.SelectedItem.Text
    End Sub

    Protected Sub cbPanelCampana_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles cbPanelCampana.Callback
        lblCampana.Text = cmBoxCampana.SelectedItem.Text
    End Sub


End Class