<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="MisDatos.aspx.vb" Inherits="Ajax_Test.MisDatos1" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
    <%-- Comienza modal --%>
    <div class="modal fade" id="NuevaEmpresa" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Modificar</h4>
                </div>
                <div class="modal-body">
                    Nombre:
                                            <br />
                    <asp:TextBox ID="tb_Nombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Apellido Paterno:
                                            <br />
                    <asp:TextBox ID="tb_apellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Apellido Materno:
                                            <br />
                    <asp:TextBox ID="tb_apellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Email:
                                            <br />
                    <asp:TextBox ID="tb_email" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Contraseña Nueva:
                                            <br />
                    <asp:TextBox ID="tb_contraseña" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Repita contraeña:
                                            <br />
                    <asp:TextBox ID="tb_contraseñaRepite" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btn_guardarDatos" runat="server" Text="Guardar Datos" CssClass="btn btn-lg blue" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <%-- Termina Modal --%>





    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Mis datos generales
            </div>

        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_generales" runat="server"></asp:Literal>
            <a data-toggle="modal" href="#NuevaEmpresa" class="btn btn-sm blue">Modificar datos</a>
        </div>
    </div>
    <%--  <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Mis teléfonos
            </div>
            	
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
            <dx:ASPxGridView ID="GV_telefonos" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="id_telefonoUsuario" Theme="MetropolisBlue">
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Principal" FieldName="Principal" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Teléfono" FieldName="Telefono" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="id_telefonoUsuario" Visible="False" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
                </dx:ASPxGridView>
            </div>
            </div>
        </div>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
