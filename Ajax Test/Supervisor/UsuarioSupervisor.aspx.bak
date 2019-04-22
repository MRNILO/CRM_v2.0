<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="UsuarioSupervisor.aspx.vb" Inherits="Ajax_Test.UsuarioSupervisor" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
    <link href="/assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" />
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
                    <a href="/Account/Logoff.aspx">
                        <i class="icon-key"></i>Salir </a>
                </li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Asignar supervisor
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-2">
                    <label><b><i>ID CRM:</i></b></label>
                    <asp:TextBox ID="tb_IdUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-3">
                    <label><b><i>Nombre:</i></b></label>
                    <asp:TextBox ID="tb_NombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <label><b><i>Apellido Paterno:</i></b></label>
                    <asp:TextBox ID="tb_ApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <label><b><i>Apellido Materno:</i></b></label>
                    <asp:TextBox ID="tb_ApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 25px">
                <div class="col-lg-2 pull-right">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-sm btn-block blue" />
                </div>
                <div class="col-lg-2 pull-right">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-sm btn-block yellow" />
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Busqueda
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="grdView_BusquedaUsuarios" runat="server" Width="100%" EnableTheming="True" Theme="MaterialCompact" AutoGenerateColumns="False" Font-Size="9pt" KeyFieldName="ID"
                    ClientInstanceName="BusquedaUsuarios" EnableCallBacks="false">
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
                        <dx:GridViewDataTextColumn FieldName="ID" Caption="ID CRM" VisibleIndex="1" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UsuarioNombre" VisibleIndex="2" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="5" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Usuario" Caption="Usuario" VisibleIndex="4" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="fechaCreacion" Caption="Fecha Registro" VisibleIndex="6" Width="150px">
                            <PropertiesTextEdit DisplayFormatString="yyyy-MM-dd">
                            </PropertiesTextEdit>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Asignar Supervisor
            </div>
        </div>
        <div class="portlet-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel0" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-1">
                            <asp:Label ID="lblId_Usuario" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-lg-3">
                            <asp:Label ID="lblNombre_usuario" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            <dx:ASPxComboBox ID="cmBoxSupervisores" runat="server" AutoPostBack="true"></dx:ASPxComboBox>
                        </div>
                        <div class="col-lg-2">
                            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="btn btn-sm btn-block blue" Enabled="false" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>

    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
