Imports Servicios.Seguridad
Public Class Reporte_de_Clientes
    Private Sub Reporte_de_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'GeneralDS.Cliente' Puede moverla o quitarla según sea necesario.
        Me.ClienteTableAdapter.Fill(Me.GeneralDS.Cliente)
        Desencriptar(Me.GeneralDS.Cliente.CuitColumn) To String


        Me.ReportViewer1.RefreshReport()
    End Sub
End Class