<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="Supervisorpermiso.aspx.vb" Inherits="Ajax_Test.Supervisorpermiso" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
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
                    <a href="../Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Permisos Especiales
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Supervisores" runat="server" Width="100%" Theme="MaterialCompact" AutoGenerateColumns="False" KeyFieldName="id_supervisor" Font-Size="9pt">
                    <SettingsAdaptivity>
                        <AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
                    </SettingsAdaptivity>
                    <SettingsEditing Mode="Batch">
                    </SettingsEditing>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsBehavior AutoFilterRowInputDelay="600" />
                    <SettingsSearchPanel Visible="True" Delay="600" />

                    <EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_supervisor" VisibleIndex="0" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="1" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="2" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="ApellidoMaterno" VisibleIndex="3" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn Caption="BorraEK" FieldName="BorraEK" VisibleIndex="4" ReadOnly="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
