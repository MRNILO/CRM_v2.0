<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SupervisorMty/SupervisorMty.master" CodeBehind="BusquedaClientes.aspx.vb" Inherits="Ajax_Test.BusquedaClientesMty" %>

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
                <i class="fa fa-file"></i>Busqueda Prospectos
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-2">
                        <label><b><i>ID CRM:</i></b></label>
                        <asp:TextBox ID="tb_IdCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><b><i>Numcte EK:</i></b></label>
                        <asp:TextBox ID="tb_NumeroCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><b><i>Numcte EK2:</i></b></label>
                        <asp:TextBox ID="tb_NumeroCliente2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><b><i>RFC:</i></b></label>
                        <asp:TextBox ID="tb_RFC" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><b><i>CURP:</i></b></label>
                        <asp:TextBox ID="tb_CURP" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><b><i>NSS:</i></b></label>
                        <asp:TextBox ID="tb_NSS" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row" style="margin-top: 15px">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-4">
                        <label><b><i>Nombre:</i></b></label>
                        <asp:TextBox ID="tb_NombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-4">
                        <label><b><i>Apellido Paterno:</i></b></label>
                        <asp:TextBox ID="tb_ApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-4">
                        <label><b><i>Apellido Materno:</i></b></label>
                        <asp:TextBox ID="tb_ApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 25px">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-2 pull-right">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2 pull-right">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-sm btn-block yellow" />
                    </div>
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
                <dx:ASPxGridView ID="grdView_BusquedaCliente" runat="server" Width="100%" EnableTheming="True" Theme="MaterialCompact" AutoGenerateColumns="False" Font-Size="9pt" KeyFieldName="ID"
                    ClientInstanceName="BusquedaClientes">
                    <SettingsAdaptivity AdaptivityMode="HideDataCells">
                    </SettingsAdaptivity>
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings VerticalScrollableHeight="450" VerticalScrollBarMode="Visible" HorizontalScrollBarMode="Visible" />
                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
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
                        <dx:GridViewDataTextColumn Name="ID" FieldName="ID" Caption="ID CRM" VisibleIndex="1" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="Cliente" FieldName="Cliente" VisibleIndex="2" Width="350px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="Asesor" FieldName="Asesor" VisibleIndex="3" Width="350px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="CallCenter" FieldName="CallCenter" Caption="Call Center" VisibleIndex="4" Width="350px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="Ranking" FieldName="Ranking" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="Nacimiento" FieldName="Nacimiento" Caption="Fecha Nacimiento" VisibleIndex="6" Width="150px">
                            <PropertiesTextEdit DisplayFormatString="yyyy-MM-dd">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="RFC" FieldName="RFC" VisibleIndex="7" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="CURP" FieldName="CURP" VisibleIndex="8" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="NSS" FieldName="NSS" VisibleIndex="9" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
