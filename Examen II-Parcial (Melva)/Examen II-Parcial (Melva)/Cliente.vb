Imports System.ComponentModel

Public Class Cliente
    Dim conexion As New conexion()
    Dim dt As New DataTable()

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenar()
        LlenarP()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
    End Sub
    Private Sub Llenar()
        conexion.Llenar("select * from factura.cliente", "factura.cliente")
    End Sub
    Private Sub LlenarP()
        conexion.Llenar("select * from factura.producto", "factura.producto")
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        txtID.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtApellido.Clear()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Venta.Show()
        Me.Hide()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.ValidateChildren And txtID.Text <> String.Empty And txtNombre.Text <> String.Empty And txtApellido.Text <> String.Empty And txtDireccion.Text <> String.Empty Then
            Dim agregar As String = "insert into factura.cliente values('" + txtID.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtDireccion.Text + "')"
            If (conexion.insert2(agregar, txtID.Text)) Then
                MessageBox.Show("Datos Agregados exitosamente")
                Llenar()
            Else
                MessageBox.Show("Datos existentes")
            End If
        Else
            MessageBox.Show("Revise los datos Ingresados", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtID.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtIDP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDP.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtID_Validating(sender As Object, e As CancelEventArgs) Handles txtID.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider1.SetError(sender, "")
        Else
            Me.ErrorProvider1.SetError(sender, "Campo obligatorio")
        End If
    End Sub

    Private Sub btnGuardarP_Click(sender As Object, e As EventArgs) Handles btnGuardarP.Click
        If Me.ValidateChildren And txtIDP.Text <> String.Empty And txtNombreP.Text <> String.Empty And txtDescripcion.Text <> String.Empty Then
            Dim agregar As String = "insert into factura.producto values('" + txtIDP.Text + "','" + txtNombreP.Text + "','" + txtDescripcion.Text + "')"
            If (conexion.insert2(agregar, txtIDP.Text)) Then
                MessageBox.Show("Datos Agregados exitosamente")
                LlenarP()
            Else
                MessageBox.Show("Datos existentes")
            End If
        Else
            MessageBox.Show("Revise los datos Ingresados", "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtIDP_Validating(sender As Object, e As CancelEventArgs) Handles txtIDP.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider2.SetError(sender, "")
        Else
            Me.ErrorProvider2.SetError(sender, "Campo obligatorio")
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked = True Then
            chkProducto.Checked = False
            GroupBox2.Enabled = False
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub chkProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chkProducto.CheckedChanged
        If chkProducto.Checked = True Then
            chkCliente.Checked = False
            GroupBox1.Enabled = False
            GroupBox2.Enabled = True
        End If
    End Sub
End Class