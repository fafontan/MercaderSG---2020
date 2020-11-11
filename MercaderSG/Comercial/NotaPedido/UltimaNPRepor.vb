Imports Negocios
Imports Servicios
Imports Entidades
Imports Excepciones
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class UltimaNPRepor

    Private Sub UltimaNPRepor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Resources.ArchivoIdioma.UltimaNotaPedidoFrm

        Dim NPDS As New GeneralDS

        NotaPedidoRN.CargarUltimaNotaPedido(NPDS)

        Dim Reporte As New NotaPedidoRP
        Reporte.SetDataSource(NPDS)
        UltimaNotaPedRPV.ReportSource = Reporte
    End Sub
End Class