<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="DatosCliente.aspx.vb" Inherits="Ajax_Test.DatosCliente" %>

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
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Busqueda
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-2">
                    <label><i>ID Cliente:</i></label>
                    <br />
                    <dx:ASPxTextBox ID="txtNumCliente" Text="" runat="server" Width="100%" Theme="MaterialCompact"></dx:ASPxTextBox>
                </div>
                <div class="col-lg-2" style="margin-top: 25px">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                </div>
                <br />
            </div>
        </div>
    </div>
    <div class="portlet box  yellow-casablanca">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Datos generales cliente
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblPaterno" runat="server" Text="Apellido Paterno"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtAPaterno" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblMaterno" runat="server" Text="Apellido Materno"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtAMaterno" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre(s)"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtnombre" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="lblCurp" runat="server" Text="CURP"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtCURP" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblNSS" runat="server" Text="NSS"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtNSS" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento"></asp:Label><br />
                    <dx:ASPxDateEdit ID="dtFechaNacimiento" runat="server" Width="100%" CssClass="form-control"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="100%" CssClass="form-control"></dx:ASPxTextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="lblRFC" runat="server" Text="RFC"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtRFC" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label><br />
                    <dx:ASPxComboBox ID="cbEmpresa" runat="server" Width="100%" CssClass="form-control"></dx:ASPxComboBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil"></asp:Label><br />
                    <dx:ASPxComboBox ID="cb_edoCivil" runat="server" CssClass="form-control" Width="100%">
                        <Items>
                            <dx:ListEditItem Text="SOLTERO" />
                            <dx:ListEditItem Text="CASADO" />
                            <dx:ListEditItem Text="DIVORCIADO" />
                            <dx:ListEditItem Text="UNION LIBRE" />
                        </Items>
                    </dx:ASPxComboBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label><br />
                    <dx:ASPxTextBox ID="txtObservaciones" runat="server" Width="100%" CssClass="form-control">
                        <ClientSideEvents KeyUp="function(s, e) { var txt = s.GetText(); s.SetText(txt.toUpperCase()); }" />
                    </dx:ASPxTextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <div class="portlet box blue-steel">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-check-square"></i>Teléfonos
                            </div>
                        </div>
                        <div class="portlet-body">
                            <dx:ASPxGridView ID="GV_telefonos" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" KeyFieldName="id_telefonoCliente">
                                <Settings ShowGroupPanel="True" />
                                <SettingsSearchPanel Visible="True" />
                                <Columns>
                                    <dx:GridViewCommandColumn Caption="Opciones" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Principal" FieldName="Principal" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Telefono" FieldName="Telefono" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="id_telefonoCliente" VisibleIndex="0">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2 col-lg-offset-10">
                    <dx:ASPxButton ID="btn_ActualizarDatos" runat="server" Text="Actualizar" Width="100%" Height="32px" Font-Size="8pt"
                        AutoPostBack="false" Theme="Material">
                    </dx:ASPxButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>

