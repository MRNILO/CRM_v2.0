<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Usuario/Usuario.Master" CodeBehind="inbox.aspx.vb" Inherits="Ajax_Test.inbox" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="modal fade" id="basic" tabindex="-1" role="basic" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Detalles corrreo</h4>
                </div>
                <div class="modal-body">
                    <div id="CorreoBody">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn dark btn-outline" data-dismiss="modal">Aceptar</button>
                        <%-- <div  class="btn green" onclick="agregarProductos()">Agregar a mi pedido</div>--%>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
    <a href="/Usuario/NuevoEmail.aspx" class="btn btn-lg blue">Nuevo Correo</a>

    <div class="portlet box green-jungle">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-envelope"></i>Recibidos
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <dx:ASPxGridView ID="GV_Recibidos" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Id Email" FieldName="id_email" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="De:" FieldName="emailFrom" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Asunto" FieldName="subjet" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fecha recibido" FieldName="fechaRecepcion" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_email" VisibleIndex="4">
                        <PropertiesTextEdit DisplayFormatString="&lt;a href='javascript:void(0)'  class='btn btn-sm green' onclick='revisarEmail({0})'&gt;Ver correo&lt;/a&gt;" EncodeHtml="False">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
    </div>

    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-envelope"></i>Enviados
            </div>
            <div class="tools">
            </div>
        </div>

        <div class="portlet-body">
            <dx:ASPxGridView ID="GV_enviados" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Id Email" FieldName="id_email" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Para:" FieldName="emailTo" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Asunto" FieldName="subjet" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fecha recibido" FieldName="fechaRecepcion" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_email" VisibleIndex="4">
                        <PropertiesTextEdit DisplayFormatString="&lt;a href='javascript:void(0)'  class='btn btn-sm green' onclick='revisarEmail({0})'&gt;Ver correo&lt;/a&gt;" EncodeHtml="False">
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        function revisarEmail(PidMail) {
            document.getElementById('CorreoBody').innerHTML = "<img src='/assets/imagenes/load.gif'/>"
            $('#basic').modal('show');
            $.ajax({
                type: "POST",
                url: "<%= ResolveUrl("/Usuario/inbox.aspx/Correo")%>",
                data: '{idEmail: "' + PidMail + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: ExitoMail,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function ExitoMail(response) {
            document.getElementById('CorreoBody').innerHTML = response.d;

        }
    </script>
</asp:Content>
