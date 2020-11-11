Imports Negocios
Imports Entidades
Imports Servicios
Imports Excepciones
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class ConsultarNV

    Public NroNota As String

    Private Sub ConsultarNV_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = My.Resources.ArchivoIdioma.NotaVentaFrm
        Dim NVDS As New GeneralDS
        Try
            NotaVentaRN.CargarNotaVenta(NVDS, NroNota)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GestionNV.Activate()
            Me.Close()
        End Try

        Dim Reporte As New NotaVentaRP
        Reporte.SetDataSource(NVDS)
        NotaVentaCRV.ReportSource = Reporte
    End Sub

    Private Sub ConsultarNV_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class