<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="NuevoProducto.aspx.vb" Inherits="Ajax_Test.NuevoProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
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
                    <a href="/Supervisor/MisDatos.aspx">
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

    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Nuevo Producto
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            Nombre corto:
            <br />
            <asp:TextBox ID="tb_nombreCorto" runat="server" CssClass="form-control"></asp:TextBox>
            Nombre completo:
            <br />
            <asp:TextBox ID="tb_NombreCompleto" runat="server" CssClass="form-control"></asp:TextBox>
            Descripcion:
            <br />
            <asp:TextBox ID="tb_Descripcion" runat="server" CssClass="form-control"></asp:TextBox>
            Precio lista:
            <br />
            <asp:TextBox ID="tb_PrecioNormal" runat="server" CssClass="form-control"></asp:TextBox>
            Precio con descuento:
            <br />
            <asp:TextBox ID="tb_PrecioDescuento" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            Categoria Producto:
            <br />
            <asp:DropDownList ID="cb_categoria" runat="server" CssClass="form-control"></asp:DropDownList>
            <br />
            Observaciones:
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-lg green" Text="Guardar Producto" Width="195px" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
