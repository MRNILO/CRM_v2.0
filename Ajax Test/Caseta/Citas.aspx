<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Caseta/Caseta.Master" CodeBehind="Citas.aspx.vb" Inherits="Ajax_Test.Citas1" %>

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
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet-body">
        <div class="portlet box blue-hoki">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-globe"></i>Mis Citas
                </div>
                <div class="tools">
                    <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn btn-sm green" />
                </div>
            </div>
            <div class="portlet-body">
                <div class="table-responsive">
                    <dx:ASPxGridViewExporter ID="GV_exporterCitas" runat="server" GridViewID="GV_Citas"></dx:ASPxGridViewExporter>
                    <dx:ASPxGridView ID="GV_Citas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" Font-Size="9pt">
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="False" ShowNewButton="False" ShowDeleteButton="False" Caption="Visita">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="btnVisita" Text="Visita">
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="cita" FieldName="Id_Cita" VisibleIndex="1" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Cliente" FieldName="id_cliente" VisibleIndex="2" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="3">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="4">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="Apellidomaterno" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Fraccionamiento" FieldName="Fraccionamiento" VisibleIndex="7">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nivel Interes" FieldName="nivelinteres" VisibleIndex="8">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Empresa" FieldName="Empresa" VisibleIndex="9">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Camapaña" FieldName="campañaNombre" VisibleIndex="10">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Etapa Actual" FieldName="Descripcion" VisibleIndex="11">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign ="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn Caption="Fecha Creación" FieldName="Creacion" VisibleIndex="12">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataDateColumn>
                        </Columns>
                        <SettingsPager PageSize="10">
                        </SettingsPager>
                        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="GV_Exporter" runat="server" GridViewID="GV_Citas"></dx:ASPxGridViewExporter>
                </div>
            </div>
        </div>

    </div>

    <div class="portlet-body">
        <div class="portlet box blue-hoki">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-globe"></i>Citas Asignadas
                </div>
                <div class="tools">
                    <asp:Button ID="btn_excelAsignadas" runat="server" Text="A Excel" CssClass="btn btn-sm green" />
                </div>
            </div>
            <div class="portlet-body">
                <div class="table-responsive">
                    <dx:ASPxGridViewExporter ID="GV_exporterCitasAsignadas" runat="server" GridViewID="GV_CitasAsignadas"></dx:ASPxGridViewExporter>
                    <dx:ASPxGridView ID="GV_CitasAsignadas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" Font-Size="9pt">
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="False" ShowNewButton="False" ShowDeleteButton="False" Caption="Visita">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="btnVisitaAsignadas" Text="Visita">
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="cita" FieldName="Id_Cita" VisibleIndex="1" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Cliente" FieldName="id_cliente" VisibleIndex="2" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="3">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Apellido Paterno" FieldName="ApellidoPaterno" VisibleIndex="4">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Apellido Materno" FieldName="Apellidomaterno" VisibleIndex="5">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Fraccionamiento" FieldName="Fraccionamiento" VisibleIndex="7">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nivel Interes" FieldName="nivelinteres" VisibleIndex="8">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Empresa" FieldName="Empresa" VisibleIndex="9">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Camapaña" FieldName="campañaNombre" VisibleIndex="10">
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Etapa Actual" FieldName="Descripcion" VisibleIndex="11">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn Caption="Fecha Creación" FieldName="Creacion" VisibleIndex="12">
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataDateColumn>
                        </Columns>
                        <SettingsPager PageSize="10">
                        </SettingsPager>
                        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="GV_ExporterAsignadas" runat="server" GridViewID="GV_CitasAsignadas"></dx:ASPxGridViewExporter>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

