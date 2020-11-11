Imports Entidades
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excepciones
Public Class NotaPedidoAD


	''' 
	''' <param name="NotaPedido"></param>
    Public Shared Sub BajaNotaPedido(ByVal NotaPedido As NotaPedidoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", NotaPedido.NroNota)
            Dim Resultado As Integer = Cmd.ExecuteScalar()

            If Resultado > 0 Then
                Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NotaPedido.NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaPedidoDadaBaja)
                Else
                    Dim ConsultaUpdate As String = "UPDATE Nota_Pedido SET Activo=0 WHERE Nro_Nota=@Param1"
                    Dim CmdUpdate As New SqlCommand(ConsultaUpdate, Cnn)
                    CmdUpdate.Parameters.AddWithValue("@Param1", NotaPedido.NroNota)

                    CmdUpdate.ExecuteNonQuery()
                End If
            Else
                Throw New WarningException(My.Resources.ArchivoIdioma.NotaPedidoNoExiste)
            End If

        End Using
    End Sub

    Public Shared Function CargarNotaPedido() As List(Of NotaPedidoEN)
        Dim ListaNP As New List(Of NotaPedidoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Consulta As String = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Pedido WHERE Activo=1"
                Dim Cmd As New SqlCommand(Consulta, Cnn)
                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Dim UnaNota As New NotaPedidoEN
                    UnaNota.NroNota = Lector(0)
                    UnaNota.Fecha = Lector(1)

                    ListaNP.Add(UnaNota)
                End While

                Return ListaNP
        End Using
    End Function

    Public Shared Sub CargarNotaPedido(DS As DataSet, NroNota As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaProveedor As String = "SELECT * FROM Proveedor"
            Dim ConsultaProducto As String = "SELECT * FROM Producto"
            Dim ConsultaNP As String = "SELECT * FROM Nota_Pedido WHERE Nro_Nota=@Param1"
            Dim ConsultaDetalle_NP As String = "SELECT * FROM Detalle_NotaPedido"
            Dim ConsultaLoc As String = "SELECT * FROM Localidad"

            Dim daProveedor As New SqlDataAdapter(ConsultaProveedor, Cnn)
            Dim daProducto As New SqlDataAdapter(ConsultaProducto, Cnn)
            Dim daNP As New SqlDataAdapter
            daNP.SelectCommand = New SqlCommand(ConsultaNP, Cnn)
            daNP.SelectCommand.Parameters.AddWithValue("@Param1", NroNota)
            Dim daDetalle As New SqlDataAdapter(ConsultaDetalle_NP, Cnn)
            Dim daLocalidad As New SqlDataAdapter(ConsultaLoc, Cnn)

            daProveedor.Fill(DS, "Proveedor")
            daProducto.Fill(DS, "Producto")
            daNP.Fill(DS, "Nota_Pedido")
            daDetalle.Fill(DS, "Detalle_NotaPedido")
            daLocalidad.Fill(DS, "Localidad")
        End Using
    End Sub

    Public Shared Sub CargarUltimaNotaPedido(DS As DataSet)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaProveedor As String = "SELECT * FROM Proveedor"
            Dim ConsultaProducto As String = "SELECT * FROM Producto"
            Dim ConsultaNP As String = "SELECT TOP 1 * FROM Nota_Pedido WHERE Activo=1 GROUP BY CodNot,Nro_Nota,Proveedor_CodProv,Fecha,Activo ORDER BY CodNot DESC"
            Dim ConsultaDetalle_NP As String = "SELECT * FROM Detalle_NotaPedido"
            Dim ConsultaLoc As String = "SELECT * FROM Localidad"

            Dim daProveedor As New SqlDataAdapter(ConsultaProveedor, Cnn)
            Dim daProducto As New SqlDataAdapter(ConsultaProducto, Cnn)
            Dim daNP As New SqlDataAdapter(ConsultaNP, Cnn)
            Dim daDetalle As New SqlDataAdapter(ConsultaDetalle_NP, Cnn)
            Dim daLocalidad As New SqlDataAdapter(ConsultaLoc, Cnn)

            daProveedor.Fill(DS, "Proveedor")
            daProducto.Fill(DS, "Producto")
            daNP.Fill(DS, "Nota_Pedido")
            daDetalle.Fill(DS, "Detalle_NotaPedido")
            daLocalidad.Fill(DS, "Localidad")
        End Using

    End Sub

    ''' 
    ''' <param name="NotaPedido"></param>
    Public Shared Sub CrearNotaPedido(ByVal NotaPedido As NotaPedidoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaAlta As String = "INSERT INTO Nota_Pedido(Nro_Nota,Proveedor_CodProv,Fecha,Activo)" & _
                                            "VALUES('1',@CodProv,GETDATE(),1) " & _
                                                "SELECT SCOPE_IDENTITY()"
                Dim Cmd As New SqlCommand(ConsultaAlta, Cnn)
                Cmd.Parameters.AddWithValue("@CodProv", NotaPedido.CodProv)

                NotaPedido.CodNot = CInt(Cmd.ExecuteScalar())

                For Each item As DetalleEN In NotaPedido.Detalle
                    NegocioAD.AltaLineaDetalle(NotaPedido.CodNot, item, "Detalle_NotaPedido")
                Next

        End Using
    End Sub

    ''' 
    ''' <param name="NroNota"></param>
    Public Shared Function ValidarNotaPedido(ByVal NroNota As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

           
                Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaPedidoDadaBaja)
                Else
                    Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1"
                    Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", NroNota)
                    Dim Resultado As Integer = Cmd.ExecuteScalar()

                    Return Resultado
                End If
        End Using
    End Function

    Public Shared Function BuscarNotaPedido(NroNota As String) As List(Of NotaPedidoEN)
        Dim ListaNota As New List(Of NotaPedidoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaActivo As String = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0"
                Dim CmdActivo As New SqlCommand(ConsultaActivo, Cnn)
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota)
                Dim Activo As Integer = CmdActivo.ExecuteScalar()

                If Activo > 0 Then
                    Throw New WarningException(My.Resources.ArchivoIdioma.NotaPedidoDadaBaja)
                Else
                    Dim Consulta As String = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Pedido WHERE Nro_Nota LIKE '%' + @Param1 + '%' AND Activo=1"
                    Dim Cmd As New SqlCommand(Consulta, Cnn)
                    Cmd.Parameters.AddWithValue("@Param1", NroNota)
                    Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                    While Lector.Read()
                        Dim UnaNota As New NotaPedidoEN
                        UnaNota.NroNota = Lector(0)
                        UnaNota.Fecha = Lector(1)

                        ListaNota.Add(UnaNota)
                    End While

                    Return ListaNota
                End If
        End Using
    End Function


End Class ' NotaPedidoAD