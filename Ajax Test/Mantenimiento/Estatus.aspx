<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="Estatus.aspx.vb" Inherits="Ajax_Test.Estatus" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
    <div>
        <dx:ASPxCallbackPanel ID="cbPanelUsuarioAsignado" runat="server" Width="100%" ClientInstanceName="PanelActualizaUsuario">
            <PanelCollection>
                <dx:PanelContent>
                   <%-- <dx:ASPxProgressBar ID="ASPxProgressBar1" runat="server" Height="21px" Width="200px"
                        EnableClientSideAPI="True" ShowPosition="False"
                        Theme="BlackGlass">
                    </dx:ASPxProgressBar>--%>
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-file"></i>Citas
                            </div>
                            <div class="tools">
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <label>Actualiza El estatus de las citas</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <asp:Button ID="btn_ActualizarCitas" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block blue" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="portlet box purple-plum">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-file"></i>Visitas
                            </div>
                            <div class="tools">
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <label>Actualiza el estatus de las visitas</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <asp:Button ID="btn_ActualizarVisitas" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block blue" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>



    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
