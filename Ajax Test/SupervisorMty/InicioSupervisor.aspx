<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SupervisorMty/SupervisorMty.Master" CodeBehind="InicioSupervisor.aspx.vb" Inherits="Ajax_Test.InicioSupervisorMty" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Bienvenido Supervisor</h3>
    <div class="portlet box blue" style="margin-top: 15px">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Clientes activos
            </div>
            <div class="tools">
                <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="form-group">
                <div class="row">
                    <div class="col-lg-3">
                        <label>Tipo de Cliente:</label>
                        <asp:DropDownList ID="cb_tipoCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="col-lg-3 form-control-static" style="margin-top: 25px">
                        <div class="row">
                            <div class="col-lg-6">
                                <dx:ASPxRadioButton ID="rdbFechas" runat="server" Text="Por fechas" GroupName="Filtros" Theme="Office365" AutoPostBack="true"></dx:ASPxRadioButton>
                            </div>
                            <div class="col-lg-6">
                                <dx:ASPxRadioButton ID="rdbDias" runat="server" Text="Por días" GroupName="Filtros" Theme="Office365" AutoPostBack="true"></dx:ASPxRadioButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2" style="margin-top: 25px">
                        <asp:Button ID="btn_MostrarClientes" runat="server" Text="Consultar" CssClass="btn btn-ms btn-block green" />
                    </div>
                    <div class="col-lg-2" style="margin-top: 25px">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-ms btn-block yellow" />
                    </div>
                </div>
                <div class="row" id="rangoFechas" runat="server" style="margin-top: 20px">
                    <div class="col-lg-2  col-lg-offset-3">
                        <label>Fecha Inicio:</label>
                        <dx:ASPxDateEdit ID="dtp_inicio" runat="server" Theme="Mulberry" Width="100%" required="required"></dx:ASPxDateEdit>
                    </div>
                    <div class="col-lg-2">
                        <label>Fecha Final:</label>
                        <dx:ASPxDateEdit ID="dtp_Fin" runat="server" Theme="Mulberry" Width="100%" required="required"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="row" id="rangoDias" runat="server" style="margin-top: 20px">
                    <div class="col-lg-3 col-lg-offset-3">
                        <label>Rango de Días</label>
                        <asp:DropDownList ID="cb_Dias" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="table-responsive">
                <dx:ASPxGridViewExporter ID="GE_Clientes" runat="server" GridViewID="GV_ClientesDias"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_ClientesDias" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="MaterialCompact" Width="100%" Font-Size="9pt" EnableCallBacks="False">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="ID" VisibleIndex="0">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;/Supervisor/ClienteSupervisor.aspx?idCliente={0}&quot; class=&quot;btn btn-sm green&quot; &gt;Ver cliente&lt;/a&gt;" EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="1">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cliente" FieldName="Cliente" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Último Movimiento" FieldName="Ultima" VisibleIndex="3">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Dias de último movimiento" FieldName="Dias" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="JSContent" runat="server"></asp:Content>
<asp:Content ContentPlaceHolderID="CSSContent" runat="server"></asp:Content>
