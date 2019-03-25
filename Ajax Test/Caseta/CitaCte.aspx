﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Caseta/Caseta.Master" CodeBehind="CitaCte.aspx.vb" Inherits="Ajax_Test.CitaCteCaseta" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Datos generales cliente
            </div>
            <div class="tools">
                <asp:Button ID="btn_modificar" runat="server" Text="Modificar Datos" CssClass="btn btn-sm blue" />
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_generales" runat="server"></asp:Literal>

            <h2>Asesor: </h2>
            <dx:ASPxGridView ID="GV_usuario" runat="server" AutoGenerateColumns="False" DataSourceID="AsesorDS" Theme="MaterialCompact">
                <SettingsPager Visible="False">
                </SettingsPager>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="usuario" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nombre" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoPaterno" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="apellidoMaterno" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="AsesorDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT dbo.usuarios.usuario, dbo.usuarios.nombre,
                               dbo.usuarios.apellidoPaterno, dbo.usuarios.apellidoMaterno
                               FROM
                               dbo.clientes
                               INNER JOIN dbo.usuarios ON dbo.clientes.id_usuarioOriginal = dbo.usuarios.id_usuario
                               WHERE id_cliente=@idCliente">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="idCliente" QueryStringField="id" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="portlet box yellow">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Etapa
            </div>
        </div>
        <div class="portlet-body">

            <br />
            Nueva Etapa:<asp:DropDownList ID="cb_etapas" runat="server" CssClass="form-control">
            </asp:DropDownList>
            Observaciones:<br />
            <asp:TextBox ID="tb_observacionesEtapa" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            <br />
            Seleccione un producto:
            <br />
            <asp:DropDownList ID="cb_productos" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <br />

            <asp:Button ID="btn_cambiaEtapa" runat="server" CssClass="btn green" Text="Cambiar etapa" />

        </div>
    </div>
    <div class="portlet box blue-hoki">
        <div class="portlet box blue-hoki">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-globe"></i>Cita
                </div>
            </div>
            <div class="portlet-body">
                <div class="row">
                    <div class="col-lg-12">
                        <label><strong>Usuario en Vigencia: &nbsp</strong></label><i><asp:Literal ID="lbl_usuario" runat="server"></asp:Literal></i>
                    </div>
                </div>
                <div class="row" style="margin-top: 5px">
                    <div class="col-lg-2">
                        <label><strong>Origen:</strong></label><br />
                        <asp:TextBox ID="tb_origen" runat="server" CssClass="form-control">AGENTE CASETA</asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group" style="margin-top: 15px">
                        <div class="col-lg-4">
                            <label><strong>Asesor Asignado:</strong></label><br />
                            <asp:DropDownList ID="cb_usuarios" runat="server" DataSourceID="UsuariosDS" DataTextField="nombre" DataValueField="id_usuario" CssClass="form-control"></asp:DropDownList>
                            <asp:SqlDataSource ID="UsuariosDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT dbo.usuarios.id_usuario, 
                                                                                                                                                                    CONCAT(dbo.usuarios.nombre,' ',
                                                                                                                                                                          dbo.usuarios.apellidoPaterno,' ',
                                                                                                                                                                          dbo.usuarios.apellidoMaterno,' (',usuarios.usuario,')') AS nombre
                                                                                                                                                                    FROM dbo.usuarios
                                                                                                                                                                    ORDER BY nombre ASC"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>Vigencia De:</strong></label><br />
                            <dx:ASPxDateEdit ID="dtp_finicio" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>A:</strong></label><br />
                            <dx:ASPxDateEdit ID="dtp_ffinal" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>Fecha Cita:</strong></label><br />
                            <dx:ASPxDateEdit ID="dtp_fechaCita" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group" style="margin-top: 15px">
                        <div class="col-lg-2">
                            <label><strong>Medio:</strong></label><br />
                            <dx:ASPxComboBox ID="cmBoxMedio" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True"></dx:ASPxComboBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>Lugar Contacto:</strong></label><br />
                            <dx:ASPxComboBox ID="cmBoxCampana" runat="server" ValueType="System.String" Width="100%" Theme="MaterialCompact" AutoPostBack="True"></dx:ASPxComboBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>Medio 2:</strong></label>
                            <asp:TextBox ID="tb_TipoCampana" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-4">
                            <label><strong>Proyacto que visitará:</strong></label><br />
                            <asp:DropDownList ID="cb_fraccinamientos" runat="server" CssClass="form-control" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label><strong>Modelo:</strong></label><br />
                            <asp:DropDownList ID="cb_modelos" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 20px">
                    <div class="col-lg-2 pull-right">
                        <dx:ASPxButton ID="btn_asignaCita" runat="server" Text="Asigna Cita" Theme="Moderno" Width="100%">
                            <Image IconID="actions_save_16x16devav">
                            </Image>
                        </dx:ASPxButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="portlet box green-dark">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Historico Citas
            </div>
            <div class="tools">
                <%-- Botones --%>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-scrollable">
                <dx:ASPxGridViewExporter ID="GV_exporterCitas" runat="server" GridViewID="GV_citas"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_citas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt" HorizontalScrollBarMode="Visible">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
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
                        <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="1" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="2" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Origen" VisibleIndex="3" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Asesor" Caption="Asesor Cita" VisibleIndex="4" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="AsesorAsignado" Caption="Asesor Asignado" VisibleIndex="5" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LugarContacto" Caption="Lugar Contacto" VisibleIndex="6" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TipoCampana" Caption="Medio" VisibleIndex="7" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Proyecto" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaCita" Caption="Fecha Cita" VisibleIndex="11">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                    </Columns>

                </dx:ASPxGridView>
            </div>
        </div>
    </div>

    <div class="portlet box yellow-casablanca">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Historico Visitas
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_botonVisitas" runat="server"></asp:Literal>
            <div class="table-scrollable">
                <dx:ASPxGridView ID="grdViewVisitas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Id_Visita" VisibleIndex="0" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="1">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Ranking" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="3">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaVisita" Caption="Visita" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Proyecto" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="AgenteAsignado" VisibleIndex="7">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="AgenteVisita" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="9">
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

    <asp:Literal ID="lbl_mensaje_Alert" runat="server"></asp:Literal>
    <script src="/assets/usuario_cliente.js"></script>
</asp:Content>
