Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Public Class UltimaNVRepor

    Private Sub ReportesNV_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Resources.ArchivoIdioma.UltimaNotaVentaFrm

        Dim NVDS As New GeneralDS

        NotaVentaRN.CargarUltimaNotaVenta(NVDS)

        Dim Reporte As New NotaVentaRP
        Reporte.SetDataSource(NVDS)
        UltimaNotaRPV.ReportSource = Reporte
    End Sub

    Private Sub UltimaNVRepor_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class