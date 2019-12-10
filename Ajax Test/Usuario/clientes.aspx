<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="clientes.aspx.vb" Inherits="Ajax_Test.clientes" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="ActivityContent" ContentPlaceHolderID="MenuDeActividades" runat="server">
    <ul class="nav navbar-nav pull-right">
        <li class="dropdown dropdown-user">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                <span class="username username-hide-on-mobile">
                    <asp:Literal ID="lbl_nombre" runat="server"></asp:Literal>
                </span>
                <i class="fa fa-angle-down"></i>
            </a>

            <ul class="dropdown-menu dropdown-menu-default">
                <li>
                    <a href="/Usuario/MisDatos.aspx">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <li>
                  <a href="../Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Opciones
            </div>
        </div>
        <div class="portlet-body">
            <a href="/Usuario/NuevoCliente.aspx" class="btn btn-lg blue">Nuevo Prospecto</a>
            <br />
        </div>
    </div>

    <div class="portlet box blue-hoki">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Ultimos clientes de
                <asp:Literal ID="lbl_nombreUsuario" runat="server"></asp:Literal>
            </div>
            <div class="tools">
                <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn btn-sm green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GV_exporterClientes" runat="server" GridViewID="GV_Clientes"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_Clientes" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" Font-Size="9pt">
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Fotografía" FieldName="fotografia" VisibleIndex="0" Visible="false">
                            <PropertiesTextEdit DisplayFormatString="&lt;img src=&quot;data:image/jpg;base64,{0}&quot; width=&quot;80&quot;/&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="TPresentacion" FieldName="fotoTpresentacion" VisibleIndex="2" Visible="false">
                            <PropertiesTextEdit DisplayFormatString="&lt;img src=&quot;data:image/jpg;base64,{0}&quot; width=&quot;80&quot;/&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_cliente" VisibleIndex="3">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;/Usuario/cliente.aspx?idCliente={0}&quot; class=&quot;btn btn-sm green&quot; &gt;Detalles&lt;/a&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="NombreCliente" FieldName="Nombre" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Producto" FieldName="NombreCorto" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="Email" FieldName="Email" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <PropertiesHyperLinkEdit NavigateUrlFormatString="mailto:{0}">
                            </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataTextColumn Caption="Nivel Interes" FieldName="nivelinteres" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Empresa" FieldName="Empresa" VisibleIndex="11">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Campaña" FieldName="campañaNombre" VisibleIndex="12">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="Observaciones" VisibleIndex="13">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Creación" FieldName="fechaCreacion" VisibleIndex="14">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Etapa Actual" FieldName="Etapa" VisibleIndex="15">
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="20">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="GV_Exporter" runat="server" GridViewID="GV_Clientes"></dx:ASPxGridViewExporter>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
