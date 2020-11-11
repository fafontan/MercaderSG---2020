Imports Negocios
Imports Entidades
Imports Servicios
Imports Excepciones
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class ConsultarNP

    Public NroNota As String

    Private Sub ConsultarNP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = My.Resources.ArchivoIdioma.ConsultarNPFrm
        Dim NPDS As New GeneralDS

        Try
            NotaPedidoRN.CargarNotaPedido(NPDS, NroNota)
        Catch ex As WarningException
            MessageBox.Show(ex.Message, My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GestionNP.Activate()
            Me.Close()
        End Try

        Dim Reporte As New NotaPedidoRP
        Reporte.SetDataSource(NPDS)
        NotaPedidoCRV.ReportSource = Reporte
    End Sub

End Class