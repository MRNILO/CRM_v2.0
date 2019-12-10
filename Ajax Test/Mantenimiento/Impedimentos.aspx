<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="Impedimentos.aspx.vb" Inherits="Ajax_Test.Impedimentos" %>

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
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Opciones
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <a href="/Mantenimiento/Impedimento.aspx" class="btn btn-lg blue">Agregar</a>
        </div>
    </div>
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Impedimentos
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Impedimento" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False"
                    KeyFieldName="id_impedimento">
                    <SettingsBehavior AllowSelectSingleRowOnly="True" AllowFocusedRow="True" AllowSelectByRowClick="True" />
                    <SettingsAdaptivity AdaptivityMode="HideDataCells">
                    </SettingsAdaptivity>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <Columns>
                        <dx:GridViewCommandColumn ButtonRenderMode="Image" ButtonType="Image" Caption="Detalles" VisibleIndex="0" Name="Detalles">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Detalles">
                                    <Image IconID="mail_contact_16x16office2013" ToolTip="Detalle">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_impedimento" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Impedimento" FieldName="impedimento" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Ranking" FieldName="ranking" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Tipo Impedimento" FieldName="TipoImpedimento" VisibleIndex="4">
                        </dx:GridViewDataDateColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
