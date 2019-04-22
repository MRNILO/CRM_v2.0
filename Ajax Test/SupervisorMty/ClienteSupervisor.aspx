<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SupervisorMty/SupervisorMty.master" CodeBehind="ClienteSupervisor.aspx.vb" Inherits="Ajax_Test.ClienteSupervisorMty" %>

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

    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Opciones de Supervisor
            </div>
        </div>
        <div class="portlet-body">
            <div class="portlet box purple">
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-lg-2">
                            <label>Cliente EK</label>
                            <asp:TextBox ID="tb_numcte" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <label>Cliente EK2</label>
                            <asp:TextBox ID="tb_numcte2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <label>Cierre EK</label>
                            <dx:ASPxDateEdit ID="dtp_FechaCierre" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                        </div>
                        <div class="col-lg-2">
                            <label>Escrituracion EK</label>
                            <dx:ASPxDateEdit ID="dtp_FechaEscrituracion" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                        </div>
                        <div class="col-lg-2">
                            <label>Fecha Cancelación</label>
                            <dx:ASPxDateEdit ID="dtp_FechaCancelacion" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                        </div>
                        <div class="col-lg-2">
                            <label>Fecha Recuperación</label>
                            <dx:ASPxDateEdit ID="dtp_FechaRecuperacion" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                        </div>
                        <br />
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <div class="col-lg-4">
                            <label>Empresa</label>
                            <dx:ASPxComboBox ID="cmBoxEmpresa" runat="server" AutoPostBack="true" Theme="MaterialCompact" TextField="Empresa" ValueField="idEmpresa" Font-Size="9pt" Width="100%" ValueType="System.Int32"></dx:ASPxComboBox>
                        </div>
                        <div class="col-lg-2 col-lg-offset-6" style="margin-top: 25px">
                            <asp:Button ID="btn_guardaNumcte" runat="server" Text="Actualizar Datos" CssClass="btn btn-sm btn-block red" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-6">
                    <label><b><i>Asesor Asignado:</i></b> </label>
                    <dx:ASPxComboBox ID="cmBoxUsuarios" runat="server" Width="100%" Theme="MaterialCompact" AutoPostBack="False" TextField="Asesor" ValueField="clave" Font-Size="9pt" ValueType="System.Int32">
                        <Columns>
                            <dx:ListBoxColumn Caption="ID" FieldName="clave" Width="20px" />
                            <dx:ListBoxColumn Caption="Asesor" FieldName="Asesor" Width="50px" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="lbl_CitasVigentes" runat="server" Text="Cliente con citas vigentes" ForeColor="Red" Visible="false"></asp:Label>
                </div>
                <div class="col-lg-2" style="margin-top: 25px">
                    <asp:Button ID="btn_cambiarUsuario" runat="server" Text="Dar a otro usuario" CssClass="btn btn-sm btn-block yellow" />
                </div>

                <br />
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="col-lg-6">
                    <asp:Label ID="lbl_numcte" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Datos generales cliente
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_generales" runat="server"></asp:Literal>
            <asp:Button ID="btn_modificar" runat="server" Text="Modificar Datos" CssClass="btn btn-sm blue" />
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Teléfonos
            </div>
        </div>
        <div class="portlet-body">
            <asp:Literal ID="lbl_telefonos" runat="server"></asp:Literal>
            <asp:Literal ID="lbl_botonLlamar" runat="server"></asp:Literal>
        </div>
    </div>

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Ranking
            </div>
            <div class="tools">
                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar Ranking" CssClass="btn btn-sm yellow-haze" />
            </div>
        </div>
        <div class="portlet-body">
            <h4>
                <asp:Label ID="lbl_mensajeRanking" runat="server" Text=""></asp:Label></h4>
            <h4>
                <asp:Label ID="lbl_ranking" runat="server" Text="¿El Cliente tiene algún impedimento de compra?"></asp:Label></h4>
            <asp:DropDownList ID="cb_tipoImpedimento" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                <asp:ListItem Value="1">Sí, el cliente tiene un impedimento.</asp:ListItem>
                <asp:ListItem Value="2">No, el cliente cumple todo para su compra</asp:ListItem>
            </asp:DropDownList>
            <br />
            <h4>
                <asp:Label ID="lbl_impedimentos" runat="server" Text="¿Que tipo de impedimento es?" Visible="False"></asp:Label></h4>
            <asp:DropDownList ID="cb_impedimentos" runat="server" CssClass="form-control" AutoPostBack="True" DataSourceID="impedimentosDS" DataTextField="TipoImpedimento" DataValueField="id_tipoImpedimento" Visible="False"></asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="impedimentosDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT [id_tipoImpedimento], [TipoImpedimento] FROM [TipoImpedimento]"></asp:SqlDataSource>
            <br />
            <h4>
                <asp:Label ID="lbl_pregunta" runat="server" Text="¿Cual es el impedimento?" Visible="False"></asp:Label></h4>
            <br />
            <asp:DropDownList ID="cb_preguntas" runat="server" CssClass="form-control" DataSourceID="PreguntasDS" DataTextField="impedimento" DataValueField="ranking" Visible="False"></asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="PreguntasDS" runat="server" ConnectionString="<%$ ConnectionStrings:crm_roest3ConnectionString %>" SelectCommand="SELECT
                               CONCAT('(',dbo.impedimentos.ranking,') ',dbo.impedimentos.impedimento) as impedimento, dbo.impedimentos.ranking
                               FROM
                               dbo.impedimentos
                               WHERE 
                               id_tipoImpedimento=@IdImp">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cb_impedimentos" DefaultValue="0" Name="IdImp" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="btn_ranking" runat="server" CssClass="btn-lg green" Text="Guardar Ranking" />
            <asp:Button ID="btnActualizar" runat="server" CssClass="btn-lg green" Text="Actualizar Ranking" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn-lg green" Text="Cancelar" />
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
    <div class="portlet box purple">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Operaciones
            </div>

        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_operaciones" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%">
                    <Settings ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsSearchPanel Visible="True" />
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <div class="portlet box green-dark">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-globe"></i>Historico Citas
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-scrollable">
                <dx:ASPxGridViewExporter ID="GV_exporterCitas" runat="server" GridViewID="GV_citas"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_citas" runat="server" Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" Font-Size="9pt">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Origen" VisibleIndex="1">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LugarContacto" Caption="Lugar Contacto" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TipoCampana" Caption="Medio" VisibleIndex="3">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Proyecto" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Fraccionamiento" VisibleIndex="5">
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
                        <dx:GridViewDataDateColumn FieldName="FechaCita" Caption="Cita" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Status" Caption="Estatus" VisibleIndex="9">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-phone"></i>LLamadas realizadas
            </div>
            <div class="tools">
                <asp:Button ID="btn_LlamadasAExcel" runat="server" Text="A Excel" CssClass="btn btn-sm green-haze" />
            </div>
        </div>

        <div class="portlet-body">
            <asp:Literal ID="lbl_botonPrograma" runat="server"></asp:Literal>
            <div class="table-scrollable">
                <dx:ASPxGridViewExporter ID="GV_exporterLlamadas" runat="server" GridViewID="GV_Llamadas"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="GV_Llamadas" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="id_llamada">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Id de llamada" FieldName="id_llamada" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Usuario" FieldName="usuario" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="FechaRegistro" FieldName="fechaCreacion" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Hora Programada" FieldName="HoraProgramacion" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Programada" FieldName="Programada" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="AvisoCliente" FieldName="AvisoCliente" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="AvisoUsuario" FieldName="AvisoUsuario" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Realizada" FieldName="realizada" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Observacion Usuario" FieldName="ObservacionUsuario" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Fecha" FieldName="Fecha" VisibleIndex="3">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="ObservacionCliente" FieldName="ObservacionCliente" VisibleIndex="11">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_llamada" VisibleIndex="0">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;javascript:void(0)&quot; onclick=&quot;cambiarLlamada({0})&quot; class=&quot;btn btn-sm green&quot;&gt;Realizada&lt;/a&gt;">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%--<script type="text/javascript" src="/assets/global/plugins/select2/select2.min.js"></script>--%>
    <script type="text/javascript">

        function cambiarLlamada(idLlamada) {
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/cliente.aspx/PruebaAjax")%>",
                data: '{valor: "' + idLlamada + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            if (response.d == 'Exito') {
                location.reload();
            } else {
                alert('No se cambio el estatus');
            }
        }
    </script>
    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
