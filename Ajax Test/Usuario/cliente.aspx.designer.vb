﻿'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Cliente
    
    '''<summary>
    '''Control lbl_nombre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_nombre As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control lbl_butonCambia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_butonCambia As Global.System.Web.UI.WebControls.Literal
    
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
    '''Control lbl_datosEmpresa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_datosEmpresa As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control lbl_telefonos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_telefonos As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control lbl_botonLlamar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_botonLlamar As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control cb_etapas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_etapas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control tb_observacionesEtapa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tb_observacionesEtapa As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control cb_productos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_productos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btn_cambiaEtapa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_cambiaEtapa As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnCambiar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCambiar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control lbl_mensajeRanking.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_mensajeRanking As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lbl_ranking.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_ranking As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control cb_tipoImpedimento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_tipoImpedimento As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_impedimentos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_impedimentos As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control cb_impedimentos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_impedimentos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control impedimentosDS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents impedimentosDS As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbl_pregunta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_pregunta As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control cb_preguntas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cb_preguntas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control PreguntasDS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PreguntasDS As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control btn_ranking.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_ranking As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnActualizar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnActualizar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnCancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control GV_operaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_operaciones As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control btn_CitasExcel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_CitasExcel As Global.System.Web.UI.WebControls.Button
    
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
    '''Control btnVisita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnVisita As Global.DevExpress.Web.GridViewCommandColumnCustomButton
    
    '''<summary>
    '''Control grdViewVisitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents grdViewVisitas As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control btn_LlamadasAExcel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_LlamadasAExcel As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control lbl_botonPrograma.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_botonPrograma As Global.System.Web.UI.WebControls.Literal
    
    '''<summary>
    '''Control GV_exporterLlamadas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_exporterLlamadas As Global.DevExpress.Web.ASPxGridViewExporter
    
    '''<summary>
    '''Control GV_Llamadas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GV_Llamadas As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control lbl_mensaje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_mensaje As Global.System.Web.UI.WebControls.Literal
End Class
