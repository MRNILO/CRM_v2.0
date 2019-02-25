<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="GrupoTrabajo.aspx.vb" Inherits="Ajax_Test.GrupoTrabajo" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Tus usuarios 
            </div>
            	<div class="tools">
                    
                    
            	</div>
        </div>
         
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_usuarios" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_usuario" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre usuario" FieldName="nombre" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="apellidoPaterno" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="apellidoMaterno" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Usuario sistema" FieldName="usuario" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Ingreso" FieldName="fechaCreacion" VisibleIndex="7">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" VisibleIndex="1" FieldName="id_usuario">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;/Supervisor/Usuario.aspx?idUsuario={0}&quot; class=&quot;btn btn-sm green&quot;&gt;Detalles&lt;/a&gt; " EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                </div>
            </div>
         </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
