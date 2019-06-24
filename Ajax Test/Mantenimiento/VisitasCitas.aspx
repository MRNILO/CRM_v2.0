<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Mantenimiento/Mantenimiento.Master" CodeBehind="VisitasCitas.aspx.vb" Inherits="Ajax_Test.VisitasCitas" %>

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
                <i class="fa fa-file"></i>Busqueda
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
                                                        <dx:ASPxGridView ID="GV_citas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt" HorizontalScrollBarMode="Visible"
                                                            KeyFieldName="Id_Cita">
                                                            <SettingsBehavior AllowSelectSingleRowOnly="True" AllowFocusedRow="True" AllowSelectByRowClick="True" />

                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells">
                                                            </SettingsAdaptivity>
                                                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="0" Width="80px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Origen" Caption="Origen" VisibleIndex="1" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="LugarContacto" Caption="Lugar Contacto" VisibleIndex="2" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="TipoCampana" Caption="Medio" VisibleIndex="3" Width="200px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Proyecto" Caption="Proyecto" VisibleIndex="4" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Fraccionamiento" Caption="Fraccionamiento" VisibleIndex="5" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="6" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="7" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataDateColumn FieldName="FechaCita" Caption="Fecha Cita" VisibleIndex="8" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="9" Width="100px" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Usuario_Asignado" Caption="Usuario Asignado" VisibleIndex="10" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <ul class="nav nav-tabs" id="myTab" role="tablist" style="border-color: cadetblue; background-color: powderblue;">
                                            <li id="tab_CambiaUsuarioAsignado" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Usuario" data-toggle="tab" href="#Usuario_Asignado" role="tab" aria-controls="home" aria-selected="true">Usuario Asignado</a>
                                            </li>
                                            <li id="tab_CambiaUsuarioRegistro" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_UsuarioRegistro" data-toggle="tab" href="#Usuario_RegistroCita" role="tab" aria-controls="home" aria-selected="true">Usuario Registro</a>
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
                                                <dx:ASPxCallbackPanel ID="cbPanelUsuarioAsignado" runat="server" Width="100%" ClientInstanceName="PanelActualizaUsuario">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Asignar Usuario:</i></label><br />
                                                                    <dx:ASPxComboBox ID="cmBoxUsuarios" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="5">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                            PanelActualizaUsuario.PerformCallback();
                                                                            }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblUsuario" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActualizaAsigando" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="Usuario_RegistroCita" role="tabpanel" aria-labelledby="tab_Usuario">
                                                <dx:ASPxCallbackPanel ID="cbPanelUsuarioRegistroCita" runat="server" Width="100%" ClientInstanceName="PanelActualizaUsuarioRegistroCita">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Usuario Registro:</i></label><br />
                                                                    <dx:ASPxComboBox ID="cmBoxUsuarioRegistro_Cita" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="5">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                            PanelActualizaUsuarioRegistroCita.PerformCallback();
                                                                            }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblUsuarioResgitroCita" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActualizaRegistroCita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="Campana" role="tabpanel" aria-labelledby="tab_Campana">
                                                <dx:ASPxCallbackPanel ID="cbPanelCampana" runat="server" Width="100%" ClientInstanceName="PanelCampana">
                                                    <ClientSideEvents EndCallback="function (s, e){ 
                                                                        if (s.cpResult == 'OK')
			                                                                { 
                                                                                              sweetAlert('¡CORRECTO!', 'La actualización se completo correctamente', 'success');                            
			                                                                }
	                                                                    else if(s.cpResult == 'ERR')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Ocurrio un error al actualizar', 'error');
                                                                                                                        }
                                                                        else if(s.cpResult == 'SELCITA')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Seleccione la cita que desea modificar.', 'error');
                                                                            }
                                                                        else if(s.cpResult == 'FINFO')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Capture la información necesaria.', 'error');
			                                                                }
                                                                               }" />
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="form-group" style="margin-top: 15px">
                                                                    <div class="col-lg-2">
                                                                        <label><strong>Medio:</strong></label><br />
                                                                        <dx:ASPxComboBox ID="cmBoxMedio" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="4">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	                                                                                                               PanelCampana.PerformCallback('cmBoxMedio');
                                                                                                                }" />
                                                                        </dx:ASPxComboBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-4">
                                                                        <label><strong>Submedio:</strong></label><br />
                                                                        <dx:ASPxComboBox ID="cmBoxCampana" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="4" Enabled="False" ClientInstanceName="cBoxCampana">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                                                          PanelCampana.PerformCallback('cmBoxCampana,' + cBoxCampana.GetValue());
                                                                                                                        }" />
                                                                        </dx:ASPxComboBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-4">
                                                                        <label><strong>Medio2:</strong></label><br />
                                                                        <dx:ASPxTextBox ID="txtTipoCampana" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True" DropDownRows="4" Enabled="false"></dx:ASPxTextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <dx:ASPxButton ID="btn_ActualizaCampanaCita" runat="server" Text="Actualizar" Theme="Moderno" Width="100%" ClientInstanceName="btnActualiza_CampanaCita" AutoPostBack="false">
                                                                        <ClientSideEvents Click="function(s, e) {
	                                                                                                                PanelCampana.PerformCallback('ActualizaCampana,' + cBoxCampana.GetValue());
                                                                                                                }" />
                                                                    </dx:ASPxButton>
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="fechaCita" role="tabpanel" aria-labelledby="tab_Fecha">
                                                <div class="row" style="height: 250px">
                                                    <div class="col-lg-3">
                                                        <label><i>Fecha Cita:</i></label>
                                                    </div>
                                                    <div class="col-lg-7">
                                                        <dx:ASPxDateEdit ID="dateFechaCita" runat="server" Theme="MaterialCompact">
                                                            <CalendarProperties EnableMonthNavigation="true" EnableYearNavigation="true"
                                                                ShowClearButton="False" ShowDayHeaders="true" ShowTodayButton="true"
                                                                ShowWeekNumbers="False">
                                                                <MonthGridPaddings Padding="3px" />
                                                                <DayStyle Font-Size="11px">
                                                                    <Paddings Padding="3px" />
                                                                </DayStyle>
                                                            </CalendarProperties>
                                                        </dx:ASPxDateEdit>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="btn_ActualizaFechaCita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
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
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <label><i>ID Cliente:</i></label>
                                                <br />
                                                <dx:ASPxTextBox ID="txtNumClienteVisitas" Text="" runat="server" Width="100%" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </div>
                                            <div class="col-lg-2" style="margin-top: 25px">
                                                <asp:Button ID="btnBuscarVisitas" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                                            </div>
                                            <div class=" col-lg-8">
                                                <label><i>Nombre Cliente:</i></label>
                                                <br />
                                                <dx:ASPxLabel ID="lblNombreClienteVisitas" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-lg-12" style="margin-top: 15px">
                                                <div class="portlet box green-dark">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-globe"></i>Visitas Vigentes
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <dx:ASPxGridView ID="GV_Visitas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt" HorizontalScrollBarMode="Visible"
                                                            KeyFieldName="Id_Cita">
                                                            <SettingsBehavior AllowSelectSingleRowOnly="True" AllowFocusedRow="True" AllowSelectByRowClick="True" />

                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells">
                                                            </SettingsAdaptivity>
                                                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn FieldName="Id_Visita" Caption="Visita" VisibleIndex="0" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="1" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="campañaNombre" Caption="Campaña" VisibleIndex="2" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="TipoCampaña" Caption="Tipo Campaña" VisibleIndex="3" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="4" Width="100px" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="5" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="6" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataDateColumn FieldName="FechaVisita" Caption="Fecha Visita" VisibleIndex="7" Width="100px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataTextColumn FieldName="AgenteAsignado" Caption="Agente Asignado" VisibleIndex="8" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="AgenteVisita" Caption="Agente Visita" VisibleIndex="9" Width="150px">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <ul class="nav nav-tabs" id="tabVisita" role="tablist" style="border-color: cadetblue; background-color: powderblue;">
                                            <li id="tabUsuarioVisita" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_UsuarioVisita" data-toggle="tab" href="#Usuario_Visita" role="tab" aria-controls="home" aria-selected="true">Usuario Visita</a>
                                            </li>
                                            <li id="tabUsuarioRegVisita" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_UsuarioRegistroVisita" data-toggle="tab" href="#Usuario_RegistroVisita" role="tab" aria-controls="home" aria-selected="true">Usuario Registro</a>
                                            </li>
                                            <li id="tabCampanaVisita" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Campana_Visita" data-toggle="tab" href="#CampanaVisita" role="tab" aria-controls="profile" aria-selected="true">Campaña</a>
                                            </li>
                                            <li id="tabFechaVista" class="nav-item" style="border-color: chartreuse" runat="server">
                                                <a class="nav-link" id="tab_Fecha_Visita" data-toggle="tab" href="#fechaVisita" role="tab" aria-controls="contact" aria-selected="true">Fecha Visita</a>
                                            </li>
                                        </ul>
                                        <div class="tab-content" id="myTabVisitas">
                                            <div class="tab-pane fade" id="Usuario_Visita" role="tabpanel" aria-labelledby="tab_UsuarioVisita">
                                                <dx:ASPxCallbackPanel ID="cbPanelUsuarioAsignadoVisita" runat="server" Width="100%" ClientInstanceName="PanelActualizaUsuarioVisita">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Asignar Usuario:</i></label>
                                                                    <br />
                                                                    <dx:ASPxComboBox ID="cmBoxUsuariosVisita" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="5">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                            PanelActualizaUsuarioVisita.PerformCallback();
                                                                                            }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblUsuarioVisita" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActualizaAsigandoVisita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="Usuario_RegistroVisita" role="tabpanel" aria-labelledby="tab_UsuarioRegVisita">
                                                <dx:ASPxCallbackPanel ID="cbPanelUsuarioRegVisita" runat="server" Width="100%" ClientInstanceName="PanelActualizaUsuarioRegistroVisita">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="col-lg-3">
                                                                    <label><i>Usuario Registro:</i></label><br />
                                                                    <dx:ASPxComboBox ID="cmBoxUsuariosRegistro_Visita" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="5">
                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                            PanelActualizaUsuarioRegistroVisita.PerformCallback();
                                                                            }" />
                                                                    </dx:ASPxComboBox>
                                                                </div>
                                                                <div class="col-lg-7" style="margin-top: 25px">
                                                                    <dx:ASPxLabel ID="lblUsuarioRegVisita" runat="server" Text="" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <asp:Button ID="btn_ActualizaRegVisita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="CampanaVisita" role="tabpanel" aria-labelledby="tab_Campana_Visita">
                                                <dx:ASPxCallbackPanel ID="cbPanelCampanaVisita" runat="server" Width="100%" ClientInstanceName="PanelCampanaVisita">
                                                    <ClientSideEvents EndCallback="function (s, e){ 
                                                                        if (s.cpResult == 'OK')
			                                                                { 
                                                                                              sweetAlert('¡CORRECTO!', 'La actualización se completo correctamente', 'success');                            
			                                                                }
	                                                                    else if(s.cpResult == 'ERR')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Ocurrio un error al actualizar', 'error');
                                                                                                                        }
                                                                        else if(s.cpResult == 'SELCITA')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Seleccione la cita que desea modificar.', 'error');
                                                                            }
                                                                        else if(s.cpResult == 'FINFO')
			                                                                {
                                                                                              sweetAlert('¡ERROR!', 'Capture la información necesaria.', 'error');
			                                                                }
                                                                               }" />
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <div class="row" style="height: 200px">
                                                                <div class="form-group" style="margin-top: 15px">
                                                                    <div class="col-lg-2">
                                                                        <label><strong>Medio:</strong></label><br />
                                                                        <dx:ASPxComboBox ID="cmBoxMedioVisita" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="4">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	                                                                                                               PanelCampanaVisita.PerformCallback('cmBoxMedioVisita');
                                                                                                                }" />
                                                                        </dx:ASPxComboBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-4">
                                                                        <label><strong>Submedio:</strong></label><br />
                                                                        <dx:ASPxComboBox ID="cmBoxCampanaVisita" runat="server" Width="100%" Theme="MaterialCompact" DropDownRows="4" Enabled="False" ClientInstanceName="cBoxCampanaVisita">
                                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
                                                                                                                          PanelCampanaVisita.PerformCallback('cmBoxCampanaVisita,' + cBoxCampanaVisita.GetValue());
                                                                                                                        }" />
                                                                        </dx:ASPxComboBox>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-4">
                                                                        <label><strong>Medio2:</strong></label><br />
                                                                        <dx:ASPxTextBox ID="txtTipoCampanaVisita" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True" DropDownRows="4" Enabled="false"></dx:ASPxTextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-2" style="margin-top: 25px">
                                                                    <dx:ASPxButton ID="btn_ActualizaCampanaVisita" runat="server" Text="Actualizar" Theme="Moderno" Width="100%" ClientInstanceName="btnActualiza_CampanaVisita" AutoPostBack="false">
                                                                        <ClientSideEvents Click="function(s, e) {
	                                                                                                                PanelCampanaVisita.PerformCallback('ActualizaCampana,' + cBoxCampanaVisita.GetValue());
                                                                                                                }"></ClientSideEvents>
                                                                    </dx:ASPxButton>
                                                                </div>
                                                            </div>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                            </div>
                                            <div class="tab-pane fade" id="fechaVisita" role="tabpanel" aria-labelledby="tab_Fecha_Visita">
                                                <div class="row" style="height: 250px">
                                                    <div class="col-lg-3">
                                                        <label><i>Fecha Visita:</i></label>
                                                    </div>
                                                    <div class="col-lg-7">
                                                        <dx:ASPxDateEdit ID="dateFechaVisita" runat="server" Theme="MaterialCompact">
                                                            <CalendarProperties EnableMonthNavigation="true" EnableYearNavigation="true"
                                                                ShowClearButton="False" ShowDayHeaders="true" ShowTodayButton="true"
                                                                ShowWeekNumbers="False">
                                                                <MonthGridPaddings Padding="3px" />
                                                                <DayStyle Font-Size="11px">
                                                                    <Paddings Padding="3px" />
                                                                </DayStyle>
                                                            </CalendarProperties>
                                                        </dx:ASPxDateEdit>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="btn_ActualizaFechaVisita" runat="server" Text="Actualizar" CssClass="btn btn-sm btn-block green" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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
