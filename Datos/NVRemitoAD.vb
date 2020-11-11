Imports Entidades
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class NVRemitoAD
    Public Shared Function CargarRemito() As DataSet
        Dim ds As New DataSet
        Return ds
    End Function

    Public Shared Sub CargarRemitoNV(DS As DataSet, NroNota As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@NroNota"
            Dim Cmd As New SqlCommand(Consulta, Cnn)
            Cmd.Parameters.AddWithValue("@NroNota", NroNota)

            Dim CodNot As Integer = CInt(Cmd.ExecuteScalar())

            Dim ConsultaCliente As String = "SELECT * FROM Cliente"
            Dim ConsultaProducto As String = "SELECT * FROM Producto"
            Dim ConsultaRem As String = "SELECT * FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param1"
            Dim ConsultaDetalle_Rem As String = "SELECT * FROM Detalle_RemitoNV"
            Dim ConsultaLoc As String = "SELECT * FROM Localidad"

            Dim daCliente As New SqlDataAdapter(ConsultaCliente, Cnn)
            Dim daProducto As New SqlDataAdapter(ConsultaProducto, Cnn)
            Dim daNV As New SqlDataAdapter
            daNV.SelectCommand = New SqlCommand(ConsultaRem, Cnn)
            daNV.SelectCommand.Parameters.AddWithValue("@Param1", CodNot)

            Dim daDetalle As New SqlDataAdapter(ConsultaDetalle_Rem, Cnn)
            Dim daLocalidad As New SqlDataAdapter(ConsultaLoc, Cnn)

            daCliente.Fill(DS, "Cliente")
            daProducto.Fill(DS, "Producto")
            daNV.Fill(DS, "Remito_NotaVenta")
            daDetalle.Fill(DS, "Detalle_RemitoNV")
            daLocalidad.Fill(DS, "Localidad")
        End Using
    End Sub

    Public Shared Sub GenerarRemito(CodNot As Integer, RENV As NVRemitoEN)
        Dim ListaDetalleNV As New List(Of DetalleEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCli As String = "SELECT Cliente_CodCli FROM Nota_Venta WHERE CodNot=@CodNot"
            Dim CmdCli As New SqlCommand(ConsultaCli, Cnn)
            CmdCli.Parameters.AddWithValue("@CodNot", CodNot)

            Dim CodCli As Integer = CInt(CmdCli.ExecuteScalar())

            Dim ConsultaNV As String = "INSERT INTO Remito_NotaVenta(Nota_Venta_CodNot,Nro_Remito,Cliente_CodCli,Fecha) " & _
                                        "VALUES(@CodNot,'0',@CodCli,GETDATE())" & _
                                            " SELECT SCOPE_IDENTITY()"
            Dim Cmd As New SqlCommand(ConsultaNV, Cnn)
            Cmd.Parameters.AddWithValue("@CodNot", CodNot)
            Cmd.Parameters.AddWithValue("@CodCli", CodCli)

            RENV.CodRemito = CInt(Cmd.ExecuteScalar())

            Dim ConsultaDetNV As String = "SELECT Producto_CodProd,Cantidad" & _
                                            " FROM Detalle_NotaVenta WHERE Nota_Venta_CodNot=@Param1"
            Dim CmdDetalle As New SqlCommand(ConsultaDetNV, Cnn)
            CmdDetalle.Parameters.AddWithValue("@Param1", CodNot)

            Dim Lector As SqlDataReader = CmdDetalle.ExecuteReader()

            While Lector.Read()
                Dim UnaLinea As New DetalleEN
                UnaLinea.CodProd = Lector(0)
                UnaLinea.Cantidad = Lector(1)

                ListaDetalleNV.Add(UnaLinea)
            End While

            For Each Detalle As DetalleEN In ListaDetalleNV
                NegocioAD.AltaLineaDetalle(RENV.CodRemito, Detalle)
            Next
        End Using
    End Sub

    Public Shared Function ValidarRemitoNV(CodNot As Integer) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param1"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodNot)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function

    Public Shared Function VerificarRemitoNV(NroNota As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@Param1"
            Dim Cmd As New SqlCommand(Consulta, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", NroNota)

            Dim CodNot As Integer = CInt(Cmd.ExecuteScalar())

            Dim ConsultaExiste As String = "SELECT COUNT(*) FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param2"
            Dim CmdExiste As New SqlCommand(ConsultaExiste, Cnn)
            CmdExiste.Parameters.AddWithValue("@Param2", CodNot)

            Dim Resultado As Integer = CInt(CmdExiste.ExecuteScalar())

            Return Resultado
        End Using
    End Function
End Class
