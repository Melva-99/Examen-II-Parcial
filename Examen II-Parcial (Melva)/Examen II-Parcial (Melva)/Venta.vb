Imports System.ComponentModel

Public Class Venta
    Dim conexion As New conexion()
    Dim dt As New DataTable()
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Me.ValidateChildren And txtVenta.Text <> String.Empty And txtFecha.Text <> String.Empty And txtPrecio.Text <> String.Empty And txtCantidad.Text <> String.Empty And txtCliente.Text <> String.Empty And txtProducto.Text <> String.Empty Then
                Dim agregar As String = "insert into factura.Venta values('" + txtVenta.Text + "','" + txtFecha.Text + "','" + txtPrecio.Text + "','" + txtCantidad.Text + "','" + txtCliente.Text + "','" + txtProducto.Text + "')"
                If (conexion.insert(agregar, txtVenta.Text)) Then
                    MessageBox.Show("Datos Agregados exitosamente")
                    Llenar()
                Else
                    MessageBox.Show("Datos existentes")
                End If
            Else
                MessageBox.Show("Revise los datos Ingresados", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenar()
    End Sub
    Private Sub Llenar()
        conexion.Llenar("select * from factura.Venta", "factura.Venta")
        DataVenta.DataSource = conexion.ds.Tables("factura.Venta")
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim update As String = "idVenta='" + txtVenta.Text + "', fechaVenta='" + txtFecha.Text + "', precio='" + txtPrecio.Text + "', cantidad='" + txtCantidad.Text + "', idCliente='" + txtCliente.Text + "', idProducto='" + "'"
        If (conexion.modificar(" factura.Venta ", update, " idVenta= '" + txtVenta.Text + "'")) Then
            MessageBox.Show("Se ha actualizado satisfactoreamente")
            Llenar()
        Else
            MessageBox.Show("Error al actualizar los datos")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If (conexion.eliminar("factura.Venta", "idVenta='" + txtVenta.Text + "'")) Then
            MessageBox.Show("Datos Eliminados exitosamente")
            Llenar()
            Limpiar()
        Else
            MessageBox.Show("Error al eliminar datos")
        End If
    End Sub
    Private Sub Limpiar()
        txtCantidad.Clear()
        txtCliente.Clear()
        txtFecha.Clear()
        txtPrecio.Clear()
        txtProducto.Clear()
        txtVenta.Clear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub
    Private Sub DataVenta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataVenta.CellClick
        Dim FilaActual As Integer
        FilaActual = DataVenta.CurrentRow.Index
        txtVenta.Text = DataVenta.Rows(FilaActual).Cells(0).Value
        txtFecha.Text = DataVenta.Rows(FilaActual).Cells(1).Value
        txtPrecio.Text = DataVenta.Rows(FilaActual).Cells(2).Value
        txtCantidad.Text = DataVenta.Rows(FilaActual).Cells(3).Value
        txtCliente.Text = DataVenta.Rows(FilaActual).Cells(4).Value
        txtProducto.Text = DataVenta.Rows(FilaActual).Cells(5).Value
    End Sub
    Private Sub buscar()
        Try
            dt = conexion.busqueda(" factura.Venta ", " idCliente like '%" + txtBuscar.Text + "%'")
            If dt.Rows.Count <> 0 Then
                DataVenta.DataSource = dt
                conexion.conexion.Close()
            Else
                DataVenta.DataSource = Nothing
                conexion.conexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        buscar()
    End Sub

    Private Sub txtVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVenta.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFecha.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtVenta_Validating(sender As Object, e As CancelEventArgs) Handles txtVenta.Validating
        If DirectCast(sender, TextBox).Text.Length = 4 Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, "Debe obtener 4 dígitos")
        End If
    End Sub
    Private Sub txtPrecio_Validating(sender As Object, e As CancelEventArgs) Handles txtPrecio.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, "Campo obligatorio")
        End If
    End Sub
End Class