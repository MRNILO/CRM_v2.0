<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="BusquedaClientes.aspx.vb" Inherits="Ajax_Test.BusquedaClientes1" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                <i class="fa fa-file"></i>Busqueda Prospectos
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-4">
                    <label><b><i>Nombre:</i></b></label>
                    <asp:TextBox ID="tb_NombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label><b><i>Apellido Paterno:</i></b></label>
                    <asp:TextBox ID="tb_ApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label><b><i>Apellido Materno:</i></b></label>
                    <asp:TextBox ID="tb_ApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="col-lg-2">
                    <label><b><i>ID Cte:</i></b></label>
                    <asp:TextBox ID="tb_idcliente" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label><b><i>Núm. Cte:</i></b></label>
                    <asp:TextBox ID="tb_NumCte" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label><b><i>RFC:</i></b></label>
                    <asp:TextBox ID="tb_RFC" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label><b><i>NSS:</i></b></label>
                    <asp:TextBox ID="tb_NSS" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <label><b><i>Fecha Nacimiento:</i></b></label>
                    <dx:ASPxDateEdit ID="dtp_FechaNacimiento" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
            </div>
            <div class="row" style="margin-top: 25px">
                <div class="col-lg-2 pull-right">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                </div>
                <div class="col-lg-2 pull-right">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-sm btn-block yellow" />
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Busqueda Prospectos
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="grdView_BusquedaCliente" runat="server" Width="100%" Theme="Moderno">
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings VerticalScrollableHeight="450" VerticalScrollBarMode="Visible" />
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="/assets/global/plugins/jquery-ui/jquery-ui.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
