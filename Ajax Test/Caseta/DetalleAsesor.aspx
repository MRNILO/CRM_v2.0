<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Caseta/Caseta.Master" CodeBehind="DetalleAsesor.aspx.vb" Inherits="Ajax_Test.DetalleAsesor1" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <style>
        .ui-autocomplete-loading {
            background: white url("/assets/imagenes/load.gif") right center no-repeat;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
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
                    <a href="#">
                        <i class="icon-user"></i>Mis Datos </a>
                </li>
                <li>
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Datos del Usuario
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_general" runat="server"></asp:Literal>
        </div>
    </div>

    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Clientes Asignados a
                <asp:Literal ID="lbl_nombreUsuario" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GV_exporterClientes" runat="server" GridViewID="GV_Clientes"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_Clientes" runat="server" Theme="MaterialCompact" Width="100%" AutoGenerateColumns="False">
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Producto" FieldName="NombreCorto" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataHyperLinkColumn Caption="Email" FieldName="Email" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                            <PropertiesHyperLinkEdit NavigateUrlFormatString="mailto:{0}">
                            </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataTextColumn Caption="Nivel Interes" FieldName="nivelinteres" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Empresa" FieldName="Empresa" VisibleIndex="11">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Campaña" FieldName="campañaNombre" VisibleIndex="12">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="Observaciones" VisibleIndex="13">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha Creación" FieldName="fechaCreacion" VisibleIndex="14">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Etapa Actual" FieldName="Etapa" VisibleIndex="15">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Font-Size="9pt" HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="12">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="GV_Exporter" runat="server" GridViewID="GV_Clientes"></dx:ASPxGridViewExporter>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>
</asp:Content>
