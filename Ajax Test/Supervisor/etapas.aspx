﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="etapas.aspx.vb" Inherits="Ajax_Test.etapas" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Etapas
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_etapas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" KeyFieldName="id_etapa">
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_etapa" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Numero Etapa" FieldName="nEtapa" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Etapa" FieldName="Descripcion" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
