<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Supervisor/Supervisor.Master" CodeBehind="Productos.aspx.vb" Inherits="Ajax_Test.Productos" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSSContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuDeActividades" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="portlet box red">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Opciones
            </div>
            <div class="tools">
            </div>
        </div>
        <div class="portlet-body">
            <asp:Button ID="btn_NuevoProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-lg green" Width="173px" />
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-file"></i>Catalogo de Productos
            </div>
            <div class="tools">
                <asp:Button ID="btn_excel" runat="server" Text="A Excel" CssClass="btn green" />
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">
                <dx:ASPxGridView ID="GV_Productos" runat="server" Theme="MetropolisBlue" Width="100%" AutoGenerateColumns="False" EnableCallBacks="False" KeyFieldName="id_producto">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="id_producto" VisibleIndex="2">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nombre Corto" FieldName="NombreCorto" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Descripcion" FieldName="Descripcion" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Precio Normal" FieldName="PrecioNormal" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Precio Descuento" FieldName="PrecioDescuento" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="fechaCreacion" FieldName="fechaCreacion" VisibleIndex="8">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Observaciones" FieldName="Observaciones" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Categoria" FieldName="categoria" VisibleIndex="7">
                            <PropertiesComboBox TextField="categoria" ValueField="id_categoria">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Opciones" FieldName="id_producto" VisibleIndex="1">
                            <PropertiesTextEdit DisplayFormatString="&lt;a href=&quot;/Supervisor/cambiaProducto.aspx?idProducto={0}&quot;&gt;Editar&lt;/a&gt;">
                            </PropertiesTextEdit>
                            <Settings FilterMode="DisplayText" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">


    <asp:Literal ID="lbl_mensaje" runat="server"></asp:Literal>
</asp:Content>
