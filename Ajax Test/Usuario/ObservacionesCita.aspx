<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="ObservacionesCita.aspx.vb" Inherits="Ajax_Test.ObservacionesCita" %>

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
                <i class="fa fa-users"></i>Cita
            </div>
        </div>
        <div class="portlet-body">
            <label><b><i>¿Ya fue realizada la cita?</i></b></label>
            <br />
            <dx:ASPxRadioButtonList ID="rBtnRealizada" runat="server" Theme="Office365" ValueType="System.Int32">
                <Items>
                    <dx:ListEditItem Text="Sin Completar" Value="0" />
                    <dx:ListEditItem Text="Completada" Value="1" />
                </Items>
            </dx:ASPxRadioButtonList>
            <br />
            <label><b><i>Observaciones:</i></b></label>
            <br />
            <asp:TextBox ID="tb_observaciones" runat="server" CssClass="form-control" Height="150px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar Observaciones" CssClass="btn btn-lg btn-sm blue" />
            <br />
            <br />
        </div>
    </div>
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-users"></i>Observaciones de la Cita
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Literal ID="lbHtml" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
