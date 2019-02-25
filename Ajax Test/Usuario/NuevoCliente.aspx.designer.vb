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


Partial Public Class NuevoCliente
    
    '''<summary>
    '''Control lbl_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_nombre As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control tb_nombreEmpresa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_nombreEmpresa As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_razonSocial.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_razonSocial As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_Direccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_Direccion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cb_estados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_estados As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control tb_paginaweb.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_paginaweb As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cb_rubros.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_rubros As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control tb_Horario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_Horario As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TextBox1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TextBox1 As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control fup_logotipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fup_logotipo As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control tb_EmpObservaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_EmpObservaciones As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_guardarEmpresa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_guardarEmpresa As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control tb_NombreCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_NombreCliente As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_ApellidoPaterno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_ApellidoPaterno As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_ApellidoMaterno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_ApellidoMaterno As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_email.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_email As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_nss.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_nss As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control tb_curp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_curp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control dtp_fechaNacimiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dtp_fechaNacimiento As Global.DevExpress.Web.ASPxDateEdit
    
    '''<summary>
    '''Control cb_empresas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_empresas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control EmpresasDS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents EmpresasDS As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbl_telefonos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_telefonos As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control tb_telefono.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_telefono As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control chB_telPrincipal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chB_telPrincipal As Global.System.Web.UI.WebControls.CheckBox
    
    '''<summary>
    '''Control btn_agregar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_agregar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_borrarTel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_borrarTel As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control cb_fracc.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_fracc As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control FraccDs.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents FraccDs As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control cb_productos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_productos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control ProductosDS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ProductosDS As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control cb_nivelInteres.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_nivelInteres As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cb_campañas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_campañas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Fupl_Foto_Cliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Fupl_Foto_Cliente As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control Fupl_bCard.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Fupl_bCard As Global.System.Web.UI.WebControls.FileUpload
    
    '''<summary>
    '''Control tb_observaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_observaciones As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btn_validarCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_validarCliente As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_Guardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Guardar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control lbl_mensaje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_mensaje As Global.System.Web.UI.WebControls.Literal
End Class
