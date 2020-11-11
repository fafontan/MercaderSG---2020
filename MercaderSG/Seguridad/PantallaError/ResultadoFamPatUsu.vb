Public Class ResultadoFamPatUsu

    Private Sub ErrorFamPatUsu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Resources.ArchivoIdioma.InformeErrores
    End Sub

    Private Sub ResultadoFamPatUsu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class