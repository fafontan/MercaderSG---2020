Public Class FiltroCompleto
    Public Shared Event BotonClick()

    Private Sub BuscarComBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarComBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        RaiseEvent BotonClick()
    End Sub

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If DesdeComDTP.Value > HastaComDTP.Value Then
            ErrorP.SetError(DesdeComDTP, My.Resources.ArchivoIdioma.FechaDesdeMenor)
            DesdeComDTP.Focus()

            Resultado = False
        End If

        Return Resultado
    End Function

    Private Sub DesdeComDTP_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DesdeComDTP.ValueChanged
        ErrorP.SetError(DesdeComDTP, "")
    End Sub

    Private Sub FiltroCompleto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        HastaComDTP.MaxDate = DateTime.Today
        DesdeComDTP.MaxDate = DateTime.Today
    End Sub

    Public Sub AplicarIdioma()
        CompletoGB.Text = My.Resources.ArchivoIdioma.FCompletoGB
        DesdeComLbl.Text = My.Resources.ArchivoIdioma.FechaDesdeLbl
        HastaComLbl.Text = My.Resources.ArchivoIdioma.FechaHastaLbl
        UsuComLbl.Text = My.Resources.ArchivoIdioma.UsuarioLbl
        CritiComLbl.Text = My.Resources.ArchivoIdioma.CriticidadLbl
        BuscarComBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarComBtn, My.Resources.ArchivoIdioma.TTBuscarCompleto)
    End Sub

End Class
