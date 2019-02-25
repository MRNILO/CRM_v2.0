﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="ClientesUsuarios.aspx.vb" Inherits="Ajax_Test.ClientesUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Clientes de tus usuarios 
            </div>
            	<div class="tools">
                    <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn btn-sm green-haze-stripe" />
                    
            	</div>
        </div>
         
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GV_exporter" runat="server" GridViewID="GV_clientes">
                </dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_clientes" runat="server" Width="100%" Theme="MaterialCompact" AutoGenerateColumns="False" EnableCallBacks="False" EnableTheming="True">
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsBehavior AutoFilterRowInputDelay="600" />
                    <SettingsSearchPanel Visible="True" Delay="600" />

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_cliente" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre Cliente" FieldName="Nombre" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Producto" FieldName="Producto" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Empresa" FieldName="Empresa" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Creación" FieldName="fechaCreacion" VisibleIndex="8">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Etapa" FieldName="Descripcion" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Usuario" FieldName="Usuario" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="Observaciones" VisibleIndex="11">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="fotografia" FieldName="fotografia" VisibleIndex="12">
                            <PropertiesTextEdit DisplayFormatString="&lt;img src=&quot;data:image/png;base64,{0}&quot;  width=&quot;150&quot;/&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="TPresentación" FieldName="fotoTpresentacion" VisibleIndex="13">
                            <PropertiesTextEdit DisplayFormatString="&lt;img src=&quot;data:image/png;base64,{0}&quot;  width=&quot;150&quot;/&gt;">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_cliente" VisibleIndex="1">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;/Supervisor/ClienteSupervisor.aspx?idCliente={0}&quot; class=&quot;btn btn-sm green&quot;&gt;Detalles&lt;/a&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="ShowFilterEditor" Text="Filtros">
                                    <Image IconID="filter_singlemasterfilter_16x16">
                                    </Image>
                                </dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>
                </dx:ASPxGridView>
                </div>
            </div>
          </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
