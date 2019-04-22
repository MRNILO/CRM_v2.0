<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Caseta/Caseta.Master" CodeBehind="NuevaVisitaCte.aspx.vb" Inherits="Ajax_Test.NuevaVisitaCteCaseta" %>

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
    <div class="portlet box blue-hoki">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Visita
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="form-group">
                    <div class="col-lg-2" style="margin-top: 15px">
                        <label><strong>Proyecto:</strong></label>
                        <dx:ASPxComboBox ID="cmBoxProyecto" runat="server" Width="100%" Height="35px" Theme="MaterialCompact" AutoPostBack="True"></dx:ASPxComboBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-3">
                        <label><strong>Modelo:</strong></label>
                        <dx:ASPxComboBox ID="cmBoxModelo" runat="server" Width="100%" Height="35px" Theme="MaterialCompact"></dx:ASPxComboBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-3">
                        <label><strong>Esq. Financiero:</strong></label>
                        <asp:TextBox ID="txBoxEsquemaFinanciero" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Medio:</strong></label>
                        <asp:TextBox ID="txBoxMedio" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Cual:</strong></label>
                        <asp:TextBox ID="txBoxCual" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 5px">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-2">
                        <label><strong>Fecha Visita:</strong></label>
                        <dx:ASPxDateEdit ID="dtFechaVisita" runat="server" Width="100%" Height="35px" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-5">
                        <label><strong>Usuario:</strong></label>
                        <asp:TextBox ID="txBoxUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-5">
                        <label><strong>Asesor Asignado:</strong></label>
                        <asp:TextBox ID="txBoxAsesor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row" style="margin-top: 5px">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-2">
                        <label><strong>Vigencia De:</strong></label><br />
                        <dx:ASPxDateEdit ID="dtp_finicio" runat="server" Width="100%" Height="35px" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>A:</strong></label><br />
                        <dx:ASPxDateEdit ID="dtp_ffinal" runat="server" Width="100%" Height="35px" Theme="Mulberry"></dx:ASPxDateEdit>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-3">
                        <label><strong>Tipo Campaña:</strong></label>
                        <asp:TextBox ID="txBoxTipoCamapana" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-2">
                        <label><strong>Clasificación:</strong></label>
                        <dx:ASPxComboBox ID="cmBoxClasificacion" runat="server" Width="100%" Height="35px" Theme="MaterialCompact" AutoPostBack="true"></dx:ASPxComboBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-3">
                        <label><strong>Motivo:</strong></label>
                        <dx:ASPxComboBox ID="cmBoxMotivo" runat="server" Width="100%" Height="35px" Theme="MaterialCompact" AutoPostBack="true"></dx:ASPxComboBox>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 5px">
                <div class="form-group" style="margin-top: 15px">
                    <div class="col-lg-10">
                        <label><strong>SubMotivo:</strong></label>
                        <dx:ASPxComboBox ID="cmBoxSubMotivo" runat="server" Width="100%" Height="35px" Theme="MaterialCompact"></dx:ASPxComboBox>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 20px">
                <div class="col-lg-2 col-lg-offset-10">
                    <dx:ASPxButton ID="btnAsignaVisita" runat="server" Text="Asigna Visita" Theme="Moderno" Width="100%">
                        <Image IconID="actions_save_16x16devav">
                        </Image>
                    </dx:ASPxButton>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box yellow-casablanca">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Visitas
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
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
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
