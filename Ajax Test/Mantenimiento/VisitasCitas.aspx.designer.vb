'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class VisitasCitas

    '''<summary>
    '''Control lbl_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_nombre As Global.System.Web.UI.WebControls.Literal

    '''<summary>
    '''Control Mantenimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Mantenimiento As Global.DevExpress.Web.ASPxPageControl

    '''<summary>
    '''Control Citas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Citas As Global.DevExpress.Web.ContentControl

    '''<summary>
    '''Control txtNumCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumCliente As Global.DevExpress.Web.ASPxTextBox

    '''<summary>
    '''Control btnBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscar As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control lblNombreCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblNombreCliente As Global.DevExpress.Web.ASPxLabel

    '''<summary>
    '''Control GV_citas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_citas As Global.DevExpress.Web.ASPxGridView

    '''<summary>
    '''Control tab_CambiaUsuarioAsignado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tab_CambiaUsuarioAsignado As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control tab_CambiaCampana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tab_CambiaCampana As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control tab_CambiaFechaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tab_CambiaFechaCita As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control cbPanelUsuarioAsignado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbPanelUsuarioAsignado As Global.DevExpress.Web.ASPxCallbackPanel

    '''<summary>
    '''Control cmBoxUsuarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxUsuarios As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control lblUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsuario As Global.DevExpress.Web.ASPxLabel

    '''<summary>
    '''Control btn_ActualizaAsigando.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaAsigando As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control cbPanelCampana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbPanelCampana As Global.DevExpress.Web.ASPxCallbackPanel

    '''<summary>
    '''Control cmBoxMedio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxMedio As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control cmBoxCampana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxCampana As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control txtTipoCampana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTipoCampana As Global.DevExpress.Web.ASPxTextBox

    '''<summary>
    '''Control btn_ActualizaCampanaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaCampanaCita As Global.DevExpress.Web.ASPxButton

    '''<summary>
    '''Control dateFechaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dateFechaCita As Global.DevExpress.Web.ASPxDateEdit

    '''<summary>
    '''Control btn_ActualizaFechaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaFechaCita As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control Visitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Visitas As Global.DevExpress.Web.ContentControl

    '''<summary>
    '''Control txtNumClienteVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumClienteVisitas As Global.DevExpress.Web.ASPxTextBox

    '''<summary>
    '''Control btnBuscarVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnBuscarVisitas As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control lblNombreClienteVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblNombreClienteVisitas As Global.DevExpress.Web.ASPxLabel

    '''<summary>
    '''Control GV_Visitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_Visitas As Global.DevExpress.Web.ASPxGridView

    '''<summary>
    '''Control tabUsuarioVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tabUsuarioVisita As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control tabCampanaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tabCampanaVisita As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control tabFechaVista.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tabFechaVista As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control cbPanelUsuarioAsignadoVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbPanelUsuarioAsignadoVisita As Global.DevExpress.Web.ASPxCallbackPanel

    '''<summary>
    '''Control cmBoxUsuariosVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxUsuariosVisita As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control lblUsuarioVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsuarioVisita As Global.DevExpress.Web.ASPxLabel

    '''<summary>
    '''Control btn_ActualizaAsigandoVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaAsigandoVisita As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control cbPanelCampanaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbPanelCampanaVisita As Global.DevExpress.Web.ASPxCallbackPanel

    '''<summary>
    '''Control cmBoxMedioVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxMedioVisita As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control cmBoxCampanaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmBoxCampanaVisita As Global.DevExpress.Web.ASPxComboBox

    '''<summary>
    '''Control txtTipoCampanaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTipoCampanaVisita As Global.DevExpress.Web.ASPxTextBox

    '''<summary>
    '''Control btn_ActualizaCampanaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaCampanaVisita As Global.DevExpress.Web.ASPxButton

    '''<summary>
    '''Control dateFechaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dateFechaVisita As Global.DevExpress.Web.ASPxDateEdit

    '''<summary>
    '''Control btn_ActualizaFechaVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ActualizaFechaVisita As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control lbl_mensaje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_mensaje As Global.System.Web.UI.WebControls.Literal
End Class
