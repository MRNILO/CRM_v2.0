Imports DevExpress.Web

Public Class Productos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GV_Productos.DataBind()
    End Sub

    Protected Sub GV_Productos_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles GV_Productos.RowDeleting
        Try
            If BL.Elimina_productos(e.Keys("id_producto")) Then
                lbl_mensaje.Text = MostrarExito("Producto eliminado")
            Else
                lbl_mensaje.Text = MostrarError("Producto asignado, no se puede eliminar")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error: " + ex.Message)
        End Try

        e.Cancel = True
    End Sub

    Protected Sub GV_Productos_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles GV_Productos.RowInserting
        Try
            If BL.Inserta_productos(e.NewValues("NombreCorto"), "-", e.NewValues("Descripcion"), e.NewValues("PrecioNormal"),
                                    e.NewValues("PrecioDescuento"), e.NewValues("categoria"), Now, e.NewValues("Observaciones"), "-") Then
                lbl_mensaje.Text = MostrarExito("Producto guardado exitosamente")
            Else
                lbl_mensaje.Text = MostrarError("Verifique los datos ingresados e intente de nuevo por favor")
            End If
        Catch ex As Exception
            lbl_mensaje.Text = MostrarError("Error: " + ex.Message)
        End Try
    End Sub

    Protected Sub GV_Productos_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles GV_Productos.RowUpdating
        Try
            If BL.Actualiza_productos(e.Keys("id_producto"), e.NewValues("NombreCorto"), e.NewValues("Descripcion"), e.NewValues("Descripcion"), e.NewValues("PrecioNormal"), e.NewValues("PrecioDescuento"), e.NewValues("categoria"), e.NewValues("Observaciones")) Then
                lbl_mensaje.Text = MostrarExito("Cambios guardados")
                Throw New Exception("Cambios guardados")
            Else
                lbl_mensaje.Text = MostrarError("No se registrarón los cambios")
            End If
        Catch ex As Exception

        End Try

        e.Cancel = True
    End Sub

    Protected Sub GV_Productos_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewEditorEventArgs) Handles GV_Productos.CellEditorInitialize

        If e.Column.FieldName = "categoria" Then
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.DataSource = BL.Obtener_categoriasProductos
            cmb.ValueField = "id_categoria"
            cmb.ValueType = GetType(Int32)
            cmb.TextField = "categoria"
            cmb.DataBindItems()
        End If
    End Sub

    Protected Sub GV_Productos_DataBinding(sender As Object, e As EventArgs) Handles GV_Productos.DataBinding
        GV_Productos.DataSource = BL.Obtener_Productos_Detalles
    End Sub

    Protected Sub btn_NuevoProducto_Click(sender As Object, e As EventArgs) Handles btn_NuevoProducto.Click
        Response.Redirect("~/Supervisor/NuevoProducto.aspx", False)
    End Sub
End Class