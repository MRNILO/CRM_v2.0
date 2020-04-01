<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CallCenter/CallCenter.Master" CodeBehind="cita.aspx.vb" Inherits="Ajax_Test.cita" %>

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
            <div class="row">
                <div class="col-lg-2">
                    <asp:Label ID="lblTIdUnico" runat="server" Text="ID unico cliente" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblIdUnico" runat="server" Width="100%" Text="" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTPaterno" runat="server" Text="Apellido Paterno" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblAPaterno" runat="server" Width="100%" Text="" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTMaterno" runat="server" Text="Apellido Materno" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblAMaterno" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static"
                        Text="">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblTNombre" runat="server" Text="Nombre(s)" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblnombre" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblTFechaNacimiento" runat="server" Text="Fecha de nacimiento" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblFechaNacimiento" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <asp:Label ID="lblTCurp" runat="server" Text="CURP" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblCURP" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTNSS" runat="server" Text="NSS" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblNSS" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblEmail" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static"></dx:ASPxLabel>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblTTelefono" runat="server" Text="Teléfono" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblTelefono" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static"></dx:ASPxLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-2">
                    <asp:Label ID="lblTTipoCredito" runat="server" Text="Tipo de Crédito" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblTipoCredito" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTEmpresa" runat="server" Text="Empresa" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblEmpresa" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="lblTObservaciones" runat="server" Text="Observaciones" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblObservaciones" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-2">
                    <asp:Label ID="lblTNumeroEnKontrol" runat="server" Text="Número cliente Enkontrol" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblNumeroEnKontrol" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblTFechaCierreEnKontrol" runat="server" Text="Fecha cierre Enkontrol" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblFechaCierreEnKontrol" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static"></dx:ASPxLabel>
                </div>
                <div class="col-lg-3">
                    <asp:Label ID="lblTEscrituracionEnkontrol" runat="server" Text="Fecha escrituración Enkontrol" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblEscrituracionEnkontrol" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static"></dx:ASPxLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblTUsuarioVigencia" runat="server" Text="Usuario en vigencia" Font-Bold="true" Visible="false"></asp:Label><br />
                    <dx:ASPxLabel ID="lblUsuarioVigencia" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static" Visible="false">
                    </dx:ASPxLabel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblTAsesorCC" runat="server" Text="Asesor Call Center" Font-Bold="true"></asp:Label><br />
                    <dx:ASPxLabel ID="lblAsesorCC" runat="server" Width="100%" Font-Size="Medium" CssClass="form-control-static">
                    </dx:ASPxLabel>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box blue-hoki">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Cita
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <div class="row">
                <div class="col-lg-12">
                    <label><strong>Usuario Call Center: &nbsp</strong></label><i><asp:Literal ID="lbl_usuario" runat="server"></asp:Literal></i>
                </div>
            </div>
            <div class="row" style="margin-top: 5px">
                <div class="col-lg-2">
                    <label><strong>Origen:</strong></label><br />
                    <asp:TextBox ID="tb_origen" runat="server" CssClass="form-control">CALL CENTER</asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label><strong>Lugar Contacto:</strong></label><br />
                    <asp:TextBox ID="tb_lContacto" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <label><strong>Proyacto que visitará:</strong></label><br />
                    <asp:DropDownList ID="cb_fraccinamientos" runat="server" DataSourceID="FraccDS" DataTextField="nom_fracc" DataValueField="id_cve_fracc" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="FraccDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT dbo.sm_fraccionamiento.id_cve_fracc, dbo.sm_fraccionamiento.nom_fracc
                                                                                                                                                         FROM dbo.sm_fraccionamiento where status_fracc = 'A'"></asp:SqlDataSource>
                </div>
                <div class="col-lg-2">
                    <label><strong>Modelo:</strong></label><br />
                    <asp:DropDownList ID="cb_modelos" runat="server" DataSourceID="productosDs" DataTextField="NombreCorto" DataValueField="id_producto" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="productosDs" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT * FROM [productos]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row" style="margin-top: 10px">
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
                <div class="col-lg-2">
                    <label><strong>Vigencia De:</strong></label><br />
                    <dx:ASPxDateEdit ID="dtp_finicio" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2">
                    <label><strong>A:</strong></label><br />
                    <dx:ASPxDateEdit ID="dtp_ffinal" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
                <div class="col-lg-2">
                    <label><strong>Fecha Cita:</strong></label><br />
                    <dx:ASPxDateEdit ID="dtp_fechaCita" runat="server" Width="100%" Theme="Mulberry"></dx:ASPxDateEdit>
                </div>
            </div>
            <div class="row" style="margin-top: 20px">
                <div class="col-lg-2 pull-right">
                    <dx:ASPxButton ID="btn_asignaCita" runat="server" Text="Asigna Cita" Theme="Moderno" Width="100%">
                        <Image IconID="actions_right_16x16">
                        </Image>
                    </dx:ASPxButton>
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
                        <dx:GridViewDataTextColumn FieldName="Id_Cita" Caption="Cita" VisibleIndex="0" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="1" Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Origen" VisibleIndex="2" Width="150px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Asesor" Caption="Asesor Cita" VisibleIndex="3" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="AsesorAsignado" Caption="Asesor Asignado" VisibleIndex="4" Width="300px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LugarContacto" Caption="Lugar Contacto" VisibleIndex="5" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TipoCampana" Caption="Medio" VisibleIndex="6" Width="200px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Proyecto" VisibleIndex="7">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaInicial" Caption="Fecha Inicial" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="VigenciaFinal" Caption="Fecha Final" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaCita" Caption="Fecha Cita" VisibleIndex="10">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
