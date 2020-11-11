Imports Entidades
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excepciones
Public Class NotaVentaAD

    Public Shared Sub BajaNotaVenta(ByVal NotaVenta As NotaVentaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1"
                Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", NotaVenta.NroNota)
                Dim Resultado As Integer = Cmd.ExecuteScalar()

            If Resultado > 0 Then

                Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NotaVenta.NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaVentaDadaBaja)
                Else
                    'BajaNota
                    Dim ConsultaUpdate As String = "UPDATE Nota_Venta SET Activo=0 WHERE Nro_Nota=@Param1"
                    Dim CmdUpdate As New SqlCommand(ConsultaUpdate, Cnn)
                    CmdUpdate.Parameters.AddWithValue("@Param1", NotaVenta.NroNota)

                    CmdUpdate.ExecuteNonQuery()
                End If
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.NotaVentaNoExiste)
            End If
        End Using
    End Sub

    Public Shared Function CargarNotaVenta() As List(Of NotaVentaEN)
        Dim ListaNV As New List(Of NotaVentaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Venta WHERE Activo=1"
                Dim Cmd As New SqlCommand(Consulta, Cnn)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnaNota As New NotaVentaEN
                    UnaNota.NroNota = Lector(0)
                    UnaNota.Fecha = Lector(1)

                    ListaNV.Add(UnaNota)
                End While

                Return ListaNV
        End Using
    End Function

    Public Shared Sub CargarNotaVenta(DS As DataSet, NroNota As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCliente As String = "SELECT * FROM Cliente"
            Dim ConsultaProducto As String = "SELECT * FROM Producto"
            Dim ConsultaNV As String = "SELECT * FROM Nota_Venta WHERE Nro_Nota=@Param1"
            Dim ConsultaDetalle_NV As String = "SELECT * FROM Detalle_NotaVenta"
            Dim ConsultaLoc As String = "SELECT * FROM Localidad"

            Dim daCliente As New SqlDataAdapter(ConsultaCliente, Cnn)
            Dim daProducto As New SqlDataAdapter(ConsultaProducto, Cnn)
            Dim daNV As New SqlDataAdapter
            daNV.SelectCommand = New SqlCommand(ConsultaNV, Cnn)
            daNV.SelectCommand.Parameters.AddWithValue("@Param1", NroNota)
            Dim daDetalle As New SqlDataAdapter(ConsultaDetalle_NV, Cnn)
            Dim daLocalidad As New SqlDataAdapter(ConsultaLoc, Cnn)

            daCliente.Fill(DS, "Cliente")
            daProducto.Fill(DS, "Producto")
            daNV.Fill(DS, "Nota_Venta")
            daDetalle.Fill(DS, "Detalle_NotaVenta")
            daLocalidad.Fill(DS, "Localidad")
        End Using
    End Sub

    Public Shared Sub CargarUltimaNotaVenta(DS As DataSet)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCliente As String = "SELECT * FROM Cliente"
            Dim ConsultaProducto As String = "SELECT * FROM Producto"
            Dim ConsultaNV As String = "SELECT TOP 1 * FROM Nota_Venta WHERE Activo=1 GROUP BY CodNot,Nro_Nota,Cliente_CodCli,Fecha,Activo ORDER BY CodNot DESC"
            Dim ConsultaDetalle_NV As String = "SELECT * FROM Detalle_NotaVenta"
            Dim ConsultaLoc As String = "SELECT * FROM Localidad"

            Dim daCliente As New SqlDataAdapter(ConsultaCliente, Cnn)
            Dim daProducto As New SqlDataAdapter(ConsultaProducto, Cnn)
            Dim daNV As New SqlDataAdapter(ConsultaNV, Cnn)
            Dim daDetalle As New SqlDataAdapter(ConsultaDetalle_NV, Cnn)
            Dim daLocalidad As New SqlDataAdapter(ConsultaLoc, Cnn)

            daCliente.Fill(DS, "Cliente")
            daProducto.Fill(DS, "Producto")
            daNV.Fill(DS, "Nota_Venta")
            daDetalle.Fill(DS, "Detalle_NotaVenta")
            daLocalidad.Fill(DS, "Localidad")
        End Using
    End Sub

    ''' 
    ''' <param name="NotaVenta"></param>
    Public Shared Sub CrearNotaVenta(ByVal NotaVenta As NotaVentaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaAlta As String = "INSERT INTO Nota_Venta(Nro_Nota,Cliente_CodCli,Fecha,Activo)" & _
                                "VALUES('1',@CodCli,GETDATE(),1) " & _
                                    "SELECT SCOPE_IDENTITY()"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@CodCli", NotaVenta.CodCli)

                NotaVenta.CodNot = CInt(Cmd.ExecuteScalar())

                For Each item As DetalleEN In NotaVenta.Detalle
                    NegocioAD.AltaLineaDetalle(NotaVenta.CodNot, item, "Detalle_NotaVenta")
                Next
        End Using
    End Sub


    Public Shared Function ObtenerIDNotaVenta(ByVal NroNota As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaCod As String = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@Param1"
                Dim Cmd As New SqlCommand(ConsultaCod, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", NroNota)

                Dim CodNot As Integer = CInt(Cmd.ExecuteScalar())

                Return CodNot
        End Using
    End Function

    ''' 
    ''' <param name="NroNota"></param>
    Public Shared Function ValidarNotaVenta(ByVal NroNota As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaVentaDadaBaja)
                Else
                    Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1"
                    Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", NroNota)
                    Dim Resultado As Integer = Cmd.ExecuteScalar()

                    Return Resultado
                End If
        End Using
    End Function

    Public Shared Function BuscarNotaVenta(NroNota As String) As List(Of NotaVentaEN)
        Dim ListaNota As New List(Of NotaVentaEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaVentaDadaBaja)
                Else
                    Dim Consulta As String = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Venta WHERE Nro_Nota LIKE '%' + @Param1 + '%'"
                    Dim CmdBuscar As New SqlCommand(Consulta, Cnn)
                    CmdBuscar.Parameters.AddWithValue("@Param1", NroNota)
                    Dim Lector As SqlDataReader = CmdBuscar.ExecuteReader()

                    While Lector.Read()
                        Dim UnaNota As New NotaVentaEN
                        UnaNota.NroNota = Lector(0)
                        UnaNota.Fecha = Lector(1)

                        ListaNota.Add(UnaNota)
                    End While

                    Return ListaNota
                End If
        End Using
    End Function

    Public Shared Function ObtenerDetalleNV(CodNot As Integer) As List(Of DetalleEN)
        Dim ListaDetalle As New List(Of DetalleEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaCantidad As String = "SELECT Producto_CodProd,Cantidad FROM Detalle_NotaVenta WHERE Nota_Venta_CodNot=@Param1"
            Dim CmdCantidad As New SqlCommand(ConsultaCantidad, cnn)
            CmdCantidad.Parameters.AddWithValue("@Param1", CodNot)
            Dim Lector As SqlDataReader = CmdCantidad.ExecuteReader()

            While Lector.Read()
                Dim UnDetalle As New DetalleEN
                UnDetalle.CodProd = Lector(0)
                UnDetalle.Cantidad = Lector(1)

                ListaDetalle.Add(UnDetalle)
            End While
        End Using

        Return ListaDetalle
    End Function

    Public Shared Sub ActualizarCantidadProducto(Detalle As DetalleEN)
        Using cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            cnn.Open()

            Dim ConsultaProd As String = "UPDATE Producto SET Cantidad+=@Param1 WHERE CodProd=@Param2"
            Dim CmdProd As New SqlCommand(ConsultaProd, cnn)
            CmdProd.Parameters.AddWithValue("@Param1", Detalle.Cantidad)
            CmdProd.Parameters.AddWithValue("@Param2", Detalle.CodProd)
            CmdProd.ExecuteNonQuery()
        End Using
    End Sub

End Class ' NotaVentaAD