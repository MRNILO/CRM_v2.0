﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="Empresas.aspx.vb" Inherits="Ajax_Test.Empresas" %>

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
    <div class="portlet box green-jungle">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-car"></i>Empresas
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Empresas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" DataSourceID="EmpresasDS" KeyFieldName="id_empresa">
                    <Settings ShowFilterRow="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="id_empresa" ReadOnly="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Empresa" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Razon_Social" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Direccion" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PaginaWEb" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Horario" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="email" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Observaciones" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="EmpresasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" DeleteCommand="DELETE FROM 
empresas
WHERE
id_empresa= @id_empresa;"
                    SelectCommand="SELECT
dbo.empresas.id_empresa,
dbo.empresas.Empresa,
dbo.empresas.Razon_Social,
dbo.empresas.Direccion,
dbo.empresas.PaginaWEb,
dbo.empresas.Horario,
dbo.empresas.email,
dbo.empresas.Observaciones

FROM
dbo.empresas
"
                    UpdateCommand="UPDATE 
empresas
SET
Empresa=@Empresa,
Razon_Social=@Razon_Social,
Direccion=@Direccion,
PaginaWEb=@PaginaWEb,
Horario=@Horario,
email=@email,
Observaciones=@Observaciones
WHERE
id_empresa= @id_empresa;">
                    <DeleteParameters>
                        <asp:Parameter Name="id_empresa" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Empresa" />
                        <asp:Parameter Name="Razon_Social" />
                        <asp:Parameter Name="Direccion" />
                        <asp:Parameter Name="PaginaWEb" />
                        <asp:Parameter Name="Horario" />
                        <asp:Parameter Name="email" />
                        <asp:Parameter Name="Observaciones" />
                        <asp:Parameter Name="id_empresa" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
