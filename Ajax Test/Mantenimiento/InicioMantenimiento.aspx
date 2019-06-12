<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="InicioMantenimiento.aspx.vb" Inherits="Ajax_Test.InicioMantenimiento" %>

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
                <i class="fa fa-file"></i>Busqueda Citas
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="form-group" style="margin-top: 15px">
                    <dx:ASPxPageControl ID="Mantenimiento" runat="server" ActiveTabIndex="0" EnableHierarchyRecreation="True" Theme="Office365" Width="100%">
                        <TabPages>
                            <dx:TabPage Text="Citas">
                                <ContentCollection>
                                    <dx:ContentControl ID="Citas" runat="server">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <label><i>ID Cliente:</i></label>
                                                <br />
                                                <dx:ASPxTextBox ID="txtNumCliente" Text="" runat="server" Width="100%" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </div>
                                            <div class="col-lg-2" style="margin-top: 25px">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                                            </div>
                                            <div class=" col-lg-8">
                                                <label><i>Nombre Cliente:</i></label>
                                                <br />
                                                <dx:ASPxLabel ID="lblNombreCliente" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-lg-12" style="margin-top: 15px">
                                                <div class="portlet box green-dark">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Citas Vigentes
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="table-responsive">
                                                            <dx:ASPxGridView ID="GV_citas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt" HorizontalScrollBarMode="Visible">
                                                                <SettingsBehavior AllowSelectByRowClick="True" />
                                                                <SettingsAdaptivity AdaptivityMode="HideDataCells">
                                                                </SettingsAdaptivity>
                                                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="0" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Origen" VisibleIndex="1" Width="150px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="LugarContacto" Caption="Lugar Contacto" VisibleIndex="2" Width="200px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="TipoCampana" Caption="Medio" VisibleIndex="3" Width="200px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Proyecto" VisibleIndex="4">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Fraccionamiento" Caption="Asesor Asignado" VisibleIndex="5" Width="300px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="6">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="7">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataDateColumn FieldName="FechaCita" Caption="Fecha Cita" VisibleIndex="8">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataDateColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="9" Width="100px" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="Usuario_Asignado" Caption="Usuario Asignado" VisibleIndex="10" Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <ul class="nav nav-tabs" id="myTab" role="tablist" style="border-color: cadetblue; background-color: powderblue;">
                                            <li id="tab_CambiaUsuarioAsignado" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Usuario" data-toggle="tab" href="#Usuario_Asignado" role="tab" aria-controls="home" aria-selected="true">Usuario Asignado</a>
                                            </li>
                                            <li id="tab_CambiaCampana" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Campana" data-toggle="tab" href="#Campana" role="tab" aria-controls="profile" aria-selected="true">Campaña</a>
                                            </li>
                                            <li id="tab_CambiaFechaCita" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Fecha" data-toggle="tab" href="#fechaCita" role="tab" aria-controls="contact" aria-selected="true">Fecha</a>
                                            </li>
                                        </ul>
                                        <div class="tab-content" id="myTabContent">
                                            <div class="tab-pane fade" id="Usuario_Asignado" role="tabpanel" aria-labelledby="tab_Usuario">
                                                <dx:ASPxCallbackPanel ID="cbPanelUsuarioAsignado" runat="server" Width="100%" ClientInstanceName="PanelRanking">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Asignar Usuario:</i></label>
                                                                    <br />
                                                                    <dx:ASPxComboBox ID="cmBoxUsuarios" runat="server" Width="100%" TextField="nombre" ValueField="id_usuario" Theme="MaterialCompact">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                            PanelRanking.PerformCallback('1');
                                                                                            }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblUsuario" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActaulizaAsigando" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="Campana" role="tabpanel" aria-labelledby="tab_Campana">
                                                <dx:ASPxCallbackPanel ID="cbPanelCampana" runat="server" Width="100%" ClientInstanceName="PanelCampana">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Asignar Campaña:</i></label>
                                                                    <br />
                                                                    <dx:ASPxComboBox ID="cmBoxCampana" runat="server" Width="100%" Theme="MaterialCompact" AutoPostBack="True">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {	 
                                                                                            PanelCampana.PerformCallback('1');
                                                                                           }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblCampana" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActaulizaCampana" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="fechaCita" role="tabpanel" aria-labelledby="tab_Fecha">
                                                <div class="row" style="height: 200px">
                                                    <div class="col-lg-3">
                                                        <label><i>Fecha Cita:</i></label>
                                                    </div>
                                                    <div class="col-lg-7">
                                                        <dx:ASPxDateEdit ID="dateFechaCita" runat="server" Theme="MaterialCompact"></dx:ASPxDateEdit>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="btn_ActaulizaFechaCita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                            <dx:TabPage Text="Visitas">
                                <ContentCollection>
                                    <dx:ContentControl ID="Visitas" runat="server">
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                    </dx:ASPxPageControl>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
