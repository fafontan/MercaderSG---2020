Imports Negocios
Imports Entidades
Imports Servicios
Imports Excepciones

Public Class ConsultarRemito

    Public NroNota As String

    Private Sub ConsultarRemito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = My.Resources.ArchivoIdioma.ConsultaRemitoFrm
        Dim RemDS As New GeneralDS
        Try
            NVRemitoRN.CargarRemitoNV(RemDS, NroNota)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GestionNV.Activate()
            Me.Close()
        End Try

        Dim Reporte As New UltimaNVRepor
        Reporte.SetDataSource(RemDS)
        RemitoCRV.ReportSource = Reporte
    End Sub

    Private Sub ConsultarRemito_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class