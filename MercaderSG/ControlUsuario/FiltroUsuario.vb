Public Class FiltroUsuario
    Public Shared Event BotonClick()

    Private Sub BuscarUsuBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarUsuBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        RaiseEvent BotonClick()
    End Sub

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True
        If UsuarioCMB.SelectedValue = 0 Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.DebeSeleccionarUsuario, UsuarioCMB)
            UsuarioCMB.Focus()
            Resultado = False

            Return Resultado
        End If

        Return Resultado
    End Function

    Private Sub FiltroUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
    End Sub

    Public Sub AplicarIdioma()
        UsuarioGB.Text = My.Resources.ArchivoIdioma.UsuarioGBBit
        UsuarioLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        BuscarUsuBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarUsuBtn, My.Resources.ArchivoIdioma.TTBuscarUsuarios)
    End Sub

    Private Sub UsuarioCMB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles UsuarioCMB.SelectedIndexChanged
        MensajeTT.Hide(UsuarioCMB)
    End Sub
End Class
