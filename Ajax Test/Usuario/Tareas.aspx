<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="Tareas.aspx.vb" Inherits="Ajax_Test.Tareas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <a href="/Usuario/ProgramarTarea.aspx" class="btn btn-lg green">Nueva Tarea</a>
    <br />
    <br />
     <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Tareas Pendientes
            </div>
            	<div class="tools">
                    
                    
            	</div>
        </div>
         
        <div class="portlet-body">
            <div class="table-responsive">
            <dx:ASPxGridView ID="GV_TareasPendientes" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False">
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID Tarea" FieldName="id_tarea" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Prioridad" FieldName="Prioridad" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Avisado" FieldName="Avisado" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Fecha Creada" FieldName="fechaCreacion" VisibleIndex="4">
                        <PropertiesDateEdit DisplayFormatString="D">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Fecha Programada" FieldName="fechaProgramada" VisibleIndex="5">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Hora Programada" FieldName="HoraProgramada" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_tarea" VisibleIndex="7">
                        <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;javascript:void(0)&quot; onclick=&quot;cambiarTarea({0})&quot; class=&quot;btn btn-sm green&quot;&gt;Terminar&lt;/a&gt;" EncodeHtml="False">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
                </div>
            </div>
         </div>
      <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Tareas Terminadas
            </div>
            	<div class="tools">
                    
                    
            	</div>
        </div>
         
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_TareasTerminadas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False">
                      <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID Tarea" FieldName="id_tarea" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Prioridad" FieldName="Prioridad" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Avisado" FieldName="Avisado" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Fecha Creada" FieldName="fechaCreacion" VisibleIndex="5">
                        <PropertiesDateEdit DisplayFormatString="D">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Fecha Programada" FieldName="fechaProgramada" VisibleIndex="6">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Hora Programada" FieldName="HoraProgramada" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
                </dx:ASPxGridView>
                </div>
            </div>
          </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
       
        function cambiarTarea(idTarea) {
                $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/Tareas.aspx/PruebaAjax")%>",
                    data: '{valor: "' + idTarea + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            if (response.d == 'Exito') {
                location.reload();
            } else {
                alert('No se cambio el estatus');
            }
        }
    </script>
</asp:Content>
