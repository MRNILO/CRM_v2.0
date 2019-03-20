<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="Asesores.aspx.vb" Inherits="Ajax_Test.Asesores" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
            <div class="caption"><i class="fa fa-tencent-weibo"></i>Listado de Asesores</div>
        </div>
        <div class="portlet-body">
            <dx:ASPxGridView ID="GV_Asesores" runat="server" Theme="MaterialCompact" Width="100%" AutoGenerateColumns="False" DataSourceID="DS_Asesores" KeyFieldName="id_usuario">
                <SettingsPager PageSize="10">
                </SettingsPager>
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

                <SettingsSearchPanel Visible="True" />

                <Columns>
                    <dx:GridViewDataTextColumn Caption="Detalles" FieldName="id_usuario" VisibleIndex="0">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;DetalleAsesor.aspx?id={0}&quot; class=&quot;btn btn-sm green&quot;&gt;Ver&lt;/a&gt;" EncodeHtml="False">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="id_usuario" ReadOnly="True" VisibleIndex="1" Caption="# Usuario">
                        <EditFormSettings Visible="False" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nombre" VisibleIndex="2" Caption="Nombre">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoPaterno" VisibleIndex="3" Caption="Apellido Paterno">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoMaterno" VisibleIndex="4" Caption="Apellido Materno">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="5" Caption="Correo">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="usuario" VisibleIndex="6" Caption="Usuario CRM">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="contraseña" VisibleIndex="7" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="fechaCreacion" VisibleIndex="8" Caption="Registrado">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="fotografia" VisibleIndex="9" Visible="false">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="DS_Asesores" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="Obtener_usuarios_todos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>
</asp:Content>
