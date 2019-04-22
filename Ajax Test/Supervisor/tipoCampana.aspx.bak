<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="tipoCampana.aspx.vb" Inherits="Ajax_Test.tipoCampana" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <div id="divNuevo" class="row" style="margin-bottom: 15px">
        <div class="col-lg-2">
            <asp:Button ID="cmdNuevo" Text="Nuevo Tipo campaña" runat="server" class="btn btn-sm btn-block purple" OnClientClick="MuestraNuevo()" />
        </div>
    </div>
    <div id="NuevoTipo_Campana" class="portlet box purple" style="margin-top: 20px" hidden="hidden">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Nuevo tipo campaña 
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-4">
                    <label>Tipo de campaña:</label>
                    <asp:TextBox ID="tb_TipoCampana" runat="server" CssClass="form-control uppercase" required="required" MaxLength="29"></asp:TextBox>
                </div>
                <div class="col-lg-2" style="margin-top: 20px">
                    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-sm btn-block blue" OnClientClick="OcultaDiv()" />
                </div>
                <div class="col-lg-2" style="margin-top: 20px">
                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-sm yellow-casablanca" OnClientClick="OcultaDiv()" />
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box green" style="margin-top: 20px">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-check-circle"></i>Tipo campaña 
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_TipoCampaña" runat="server" Width="100%" Theme="MaterialCompact" AutoGenerateColumns="False" KeyFieldName="id_tipoCampaña" Font-Size="9pt" EnableTheming="True">
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="false" ShowEditButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_tipoCampaña" VisibleIndex="1">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Tipo Campaña" FieldName="TipoCampaña" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function OcultaDiv() {
            $('#NuevoTipo_Campana').hide();
            $('#divNuevo').show();
        }
        function MuestraNuevo() {
            $('#NuevoTipo_Campana').show();
            $('#divNuevo').hide();
        }
    </script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
