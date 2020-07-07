Public Class Datos
    Dim conexion As New conexion()
    Dim dt As New DataTable()
    Private Sub Datos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenar()
    End Sub
    Private Sub Llenar()
        conexion.Llenar("select fc.nombre as 'Nombre',fc.apellido as 'Apellido',fp.nombreProducto as 'Producto',cantidad as 'Cantidad',precio as 'Precio',fechaVenta as 'Fecha de Venta' 
                        from factura.cliente as fc
                        inner join factura.Venta as fv 
                        on fc.idCliente = fv.idCliente
                        inner join factura.producto as fp
                        on fv.idProducto = fp.idProducto", "factura.cliente, factura.Venta, factura.producto")
        DataVenta.DataSource = conexion.ds.Tables("factura.cliente, factura.Venta, factura.producto")
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Cliente.Show()
        Me.Hide()
    End Sub
End Class