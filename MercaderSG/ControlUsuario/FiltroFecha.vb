Public Class FiltroFecha
    Public Shared Event BotonClick()

    Private Sub BuscarFechaBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarFechaBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        RaiseEvent BotonClick()
    End Sub

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If DesdeDTP.Value > HastaDTP.Value Then
            ErrorP.SetError(DesdeDTP, My.Resources.ArchivoIdioma.FechaDesdeMenor)
            DesdeDTP.Focus()

            Resultado = False
        End If

        Return Resultado
    End Function

    Private Sub DesdeDTP_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DesdeDTP.ValueChanged
        ErrorP.SetError(DesdeDTP, "")
    End Sub

    Private Sub FiltroFecha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
        HastaDTP.MaxDate = DateTime.Today
        DesdeDTP.MaxDate = DateTime.Today
    End Sub

    Public Sub AplicarIdioma()
        FechasGB.Text = My.Resources.ArchivoIdioma.FechasGB
        DesdeLbl.Text = My.Resources.ArchivoIdioma.FechaDesdeLbl
        HastaLbl.Text = My.Resources.ArchivoIdioma.FechaHastaLbl
        BuscarFechaBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarFechaBtn, My.Resources.ArchivoIdioma.TTBuscarFechas)
    End Sub

End Class
