<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="ProgramarTarea.aspx.vb" Inherits="Ajax_Test.ProgramarTarea" %>

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
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-phone"></i>Programar Tarea
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            Seleccione prioridad:
            <br />
            <asp:DropDownList ID="cb_prioridad" runat="server" CssClass="form-control"></asp:DropDownList>
            <br />
            ¿Cuando?
            <br />
            <dx:ASPxDateEdit ID="dtp_fecha" runat="server"></dx:ASPxDateEdit>
            <br />
            ¿Hora?
            <br />
            <dx:ASPxTimeEdit ID="tp_hora" runat="server"></dx:ASPxTimeEdit>
            <br />
            Tarea
            <br />
            <asp:TextBox ID="tb_Tarea" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Programar Tarea" CssClass="btn btn-lg green" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
