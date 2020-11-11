Public Class FiltroCriticidad
    Public Shared Event BotonClick()

    Private Sub BuscarCritiBtn_Click(sender As System.Object, e As System.EventArgs) Handles BuscarCritiBtn.Click
        If Not ConsistenciaDatos() Then
            Exit Sub
        End If

        RaiseEvent BotonClick()
    End Sub

    Private Sub CritiTxt_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim CaracterPermitido As String = "123" & Convert.ToChar(8)
        Dim c As Char = e.KeyChar
        If Not CaracterPermitido.Contains(c) Then
            e.Handled = True
        End If
    End Sub

    Private Function ConsistenciaDatos() As Boolean
        Dim Resultado As Boolean = True

        If CriticidadCMB.SelectedValue = 0 Then
            MensajeTT.Show(My.Resources.ArchivoIdioma.DebeSeleccionarCriticidad, CriticidadCMB)
            CriticidadCMB.Focus()
            Resultado = False

            Return Resultado
        End If

        Return Resultado
    End Function

    Private Sub FiltroCriticidad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AplicarIdioma()
        CargarTT()
    End Sub

    Public Sub AplicarIdioma()
        CriticidadGB.Text = My.Resources.ArchivoIdioma.CriticidadGB
        CriticidadLbl.Text = My.Resources.ArchivoIdioma.CriticidadLbl
        BuscarCritiBtn.Text = My.Resources.ArchivoIdioma.BuscarBtn
    End Sub

    Private Sub CargarTT()
        ControlesTP.SetToolTip(BuscarCritiBtn, My.Resources.ArchivoIdioma.TTBuscarCriticidad)
    End Sub

    Private Sub CriticidadCMB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CriticidadCMB.SelectedIndexChanged
        MensajeTT.Hide(CriticidadCMB)
    End Sub

End Class
