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


Partial Public Class CitaCteProspectador
    
    '''<summary>
    '''Control lbl_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_nombre As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control btn_modificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_modificar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control lbl_generales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_generales As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control GV_usuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_usuario As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control AsesorDS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents AsesorDS As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbl_usuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_usuario As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control tb_origen.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_origen As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cb_usuarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_usuarios As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control dtp_finicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dtp_finicio As Global.DevExpress.Web.ASPxDateEdit
    
    '''<summary>
    '''Control dtp_ffinal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dtp_ffinal As Global.DevExpress.Web.ASPxDateEdit
    
    '''<summary>
    '''Control dtp_fechaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dtp_fechaCita As Global.DevExpress.Web.ASPxDateEdit
    
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
    '''Control tb_TipoCampana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_TipoCampana As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cb_fraccinamientos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_fraccinamientos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cb_modelos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_modelos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btn_asignaCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_asignaCita As Global.DevExpress.Web.ASPxButton
    
    '''<summary>
    '''Control lbl_botonCitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_botonCitas As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control GV_exporterCitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_exporterCitas As Global.DevExpress.Web.ASPxGridViewExporter
    
    '''<summary>
    '''Control GV_citas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_citas As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control lbl_botonVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_botonVisitas As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control grdViewVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grdViewVisitas As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control lbl_mensaje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_mensaje As Global.System.Web.UI.WebControls.Literal
End Class
