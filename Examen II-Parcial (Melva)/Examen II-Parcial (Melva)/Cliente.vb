Public Class Cliente
    Dim conexion As New conexion()
    Dim dt As New DataTable()
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.ValidateChildren And txtID.Text <> String.Empty And txtNombre.Text <> String.Empty And txtApellido.Text <> String.Empty And txtDireccion.Text <> String.Empty Then
            Dim agregar As String = "insert into factura.cliente values('" + txtID.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtDireccion.Text + "')"
            If (conexion.insert2(agregar, txtID.Text)) Then
                MessageBox.Show("Datos Agregados exitosamente")
                Llenar()
            Else
                MessageBox.Show("Datos existentes")
            End If
        End If
    End Sub

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenar()
    End Sub
    Private Sub Llenar()
        conexion.Llenar("select * from factura.cliente", "factura.cliente")
    End Sub
End Class