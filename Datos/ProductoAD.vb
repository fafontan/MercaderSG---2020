Imports Entidades
Imports System.Data.SqlClient
Imports System.Configuration
Imports Excepciones
Public Class ProductoAD

    Public Shared Sub ActualizarStock(ByVal CodProd As Integer, ByVal Cantidad As Integer)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaStock As String = "UPDATE Producto SET Cantidad-=@Param1 WHERE CodProd=@Param2"
            Dim Cmd As New SqlCommand(ConsultaStock, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Cantidad)
            Cmd.Parameters.AddWithValue("@Param2", CodProd)

            Cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' 
    ''' <param name="Producto"></param>
    Public Shared Sub AltaProducto(ByVal Producto As ProductoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaAlta As String = "INSERT INTO Producto(Nombre,Descripcion,Cantidad,Sector,Activo,DVH)" & _
                                            "VALUES(@Nombre,@Descripcion,@Cantidad,@Sector,1,0) " & _
                                                "SELECT SCOPE_IDENTITY()"
            Dim CmdAltaProd As New SqlCommand(ConsultaAlta, Cnn)
            CmdAltaProd.Parameters.AddWithValue("@Nombre", Producto.Nombre)
            CmdAltaProd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion)
            CmdAltaProd.Parameters.AddWithValue("@Cantidad", Producto.Cantidad)
            CmdAltaProd.Parameters.AddWithValue("@Sector", Producto.Sector)

            Dim CodProd As Integer = CInt(CmdAltaProd.ExecuteScalar())

            Producto.CodProd = CodProd

            Dim ConsultaAltaPrecio As String = "INSERT INTO Historico_Precio(Producto_CodProd,Precio,FechaDesde,DVH)VALUES(@CodProd,@Precio,GETDATE(),0) " & _
                                                "SELECT SCOPE_IDENTITY()"

            Dim CmdPrecio As New SqlCommand(ConsultaAltaPrecio, Cnn)
            CmdPrecio.Parameters.AddWithValue("@CodProd", Producto.CodProd)
            CmdPrecio.Parameters.AddWithValue("@Precio", Producto.Precio)

            Dim CodHistorico As Integer = CInt(CmdPrecio.ExecuteScalar())

            Producto.CodHistorico = CodHistorico
        End Using

    End Sub

    ''' 
    ''' <param name="Producto"></param>
    Public Shared Sub BajaProducto(ByVal Producto As ProductoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())

            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoEstaEliminado)
            Else
                Dim ConsultaBaja As String = "UPDATE Producto SET Activo=0 WHERE CodProd=@Param1"
                Dim Cmd As New SqlCommand(ConsultaBaja, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Producto.CodProd)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub

    ''' 
    ''' <param name="campo"></param>
    ''' <param name="valor"></param>
    Public Shared Function BuscarProducto(ByVal Campo As String, ByVal Valor As String) As List(Of ProductoEN)
        Dim ListaProducto As New List(Of ProductoEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim Cmd As New SqlCommand
            Cmd.Connection = Cnn

            Select Case Campo
                Case My.Resources.ArchivoIdioma.CMBNombre
                    Cmd.CommandText = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " & _
                                         "FROM Producto P INNER JOIN Historico_Precio HP " & _
                                            "ON P.CodProd=HP.Producto_CodProd " & _
                                                "INNER JOIN (" & _
                                                    "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " & _
                                                        "FROM Historico_Precio GROUP BY Producto_CodProd) C " & _
                                                            "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " & _
                                        "WHERE Activo=1 AND Nombre=@Param1"
                Case My.Resources.ArchivoIdioma.CMBSector
                    Cmd.CommandText = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " & _
                                             "FROM Producto P INNER JOIN Historico_Precio HP " & _
                                                "ON P.CodProd=HP.Producto_CodProd " & _
                                                    "INNER JOIN (" & _
                                                        "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " & _
                                                            "FROM Historico_Precio GROUP BY Producto_CodProd) C " & _
                                                                "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " & _
                                            "WHERE Activo=1 AND Sector LIKE '%' + @Param1 + '%'"
            End Select

            Cmd.Parameters.AddWithValue("@Param1", Valor)

            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnProducto As New ProductoEN
                UnProducto.CodProd = Lector(0)
                UnProducto.Nombre = Lector(1)
                UnProducto.Sector = Lector(2)
                UnProducto.Cantidad = Lector(3)
                UnProducto.Precio = Lector(4)
                UnProducto.Descripcion = Lector(5)

                ListaProducto.Add(UnProducto)
            End While
        End Using

        Return ListaProducto
    End Function

    Public Shared Function CargarProducto() As List(Of ProductoEN)
        Dim ListaProducto As New List(Of ProductoEN)

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaProducto As String = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " & _
                                             "FROM Producto P INNER JOIN Historico_Precio HP " & _
                                                "ON P.CodProd=HP.Producto_CodProd " & _
                                                    "INNER JOIN (" & _
                                                        "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " & _
                                                            "FROM Historico_Precio GROUP BY Producto_CodProd) C " & _
                                                                "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " & _
                                            "WHERE Activo=1"

            Dim Cmd As New SqlCommand(ConsultaProducto, Cnn)
            Dim Lector As SqlDataReader = Cmd.ExecuteReader()

            While Lector.Read()
                Dim UnProducto As New ProductoEN
                UnProducto.CodProd = Lector(0)
                UnProducto.Nombre = Lector(1)
                UnProducto.Sector = Lector(2)
                UnProducto.Cantidad = Lector(3)
                UnProducto.Precio = Lector(4)
                UnProducto.Descripcion = Lector(5)

                ListaProducto.Add(UnProducto)
            End While
        End Using

        Return ListaProducto
    End Function


    Public Shared Sub ModificarPrecioProducto(ByVal Producto As ProductoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())

            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoDadoBaja)
            Else
                Dim ConsultaPrecio As String = "INSERT INTO Historico_Precio(Producto_CodProd,Precio,FechaDesde,DVH)VALUES(@CodProd,@Precio,GETDATE(),0) " & _
                                                    "SELECT SCOPE_IDENTITY()"

                Dim CmdPrecio As New SqlCommand(ConsultaPrecio, Cnn)
                CmdPrecio.Parameters.AddWithValue("@CodProd", Producto.CodProd)
                CmdPrecio.Parameters.AddWithValue("@Precio", Producto.Precio)

                Dim CodHistorico As Integer = CInt(CmdPrecio.ExecuteScalar())

                Producto.CodHistorico = CodHistorico
            End If
        End Using
    End Sub

    ''' 
    ''' <param name="Producto"></param>
    Public Shared Sub ModificarProducto(ByVal Producto As ProductoEN)
        Dim NombreProd As String = ""

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoDadoBaja)
            Else
                Dim ConsultaNombreProd As String = "SELECT Nombre FROM Producto WHERE CodProd=@Param1"
                Dim CmdNombreProd As New SqlCommand(ConsultaNombreProd, Cnn)
                CmdNombreProd.Parameters.AddWithValue("@Param1", Producto.CodProd)

                Dim Lector As SqlDataReader = CmdNombreProd.ExecuteReader()

                While Lector.Read()
                    NombreProd = Lector(0)
                End While

                If NombreProd <> Producto.Nombre Then
                    Dim ConsultaValidarNombre As String = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1"
                    Dim CmdValidarNombre As New SqlCommand(ConsultaValidarNombre, Cnn)
                    CmdValidarNombre.Parameters.AddWithValue("@Param1", Producto.Nombre)

                    Dim ResultadoNombre As Integer = CmdValidarNombre.ExecuteScalar()

                    If ResultadoNombre > 0 Then
                        Throw New WarningException(My.Resources.ArchivoIdioma.NombreProductoExistente)
                    Else
                        Dim ConsultaModificarConNombre As String = "UPDATE Producto SET Nombre=@Nombre,Sector=@Sector,Descripcion=@Desc WHERE CodProd=@Param1"
                        Dim CmdModNombre As New SqlCommand(ConsultaModificarConNombre, Cnn)
                        CmdModNombre.Parameters.AddWithValue("@Nombre", Producto.Nombre)
                        CmdModNombre.Parameters.AddWithValue("@Sector", Producto.Sector)
                        CmdModNombre.Parameters.AddWithValue("@Desc", Producto.Descripcion)
                        CmdModNombre.Parameters.AddWithValue("@Param1", Producto.CodProd)

                        CmdModNombre.ExecuteNonQuery()

                        Exit Sub
                    End If
                End If

                Dim ConsultaModificar As String = "UPDATE Producto SET Nombre=@Nombre,Sector=@Sector,Descripcion=@Desc WHERE CodProd=@Param1"
                Dim Cmd As New SqlCommand(ConsultaModificar, Cnn)
                Cmd.Parameters.AddWithValue("@Nombre", Producto.Nombre)
                Cmd.Parameters.AddWithValue("@Sector", Producto.Sector)
                Cmd.Parameters.AddWithValue("@Desc", Producto.Descripcion)
                Cmd.Parameters.AddWithValue("@Param1", Producto.CodProd)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub


    Public Shared Sub ModificarStockProducto(ByVal Producto As ProductoEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoDadoBaja)
            Else
                Dim ConsultaStock As String = "UPDATE Producto SET Cantidad+=@Param1 WHERE CodProd=@Param2"
                Dim Cmd As New SqlCommand(ConsultaStock, Cnn)
                Cmd.Parameters.AddWithValue("@Param1", Producto.Cantidad)
                Cmd.Parameters.AddWithValue("@Param2", Producto.CodProd)

                Cmd.ExecuteNonQuery()
            End If
        End Using
    End Sub

    Public Shared Function ObtenerProducto(ByVal CodProd As Integer) As ProductoEN
        Dim Producto As New ProductoEN

        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", CodProd)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoDadoBaja)
            Else
                Dim ConsultaProd As String = "SELECT CodProd,Nombre,Sector,Descripcion,Cantidad,Precio " & _
                                             "FROM Producto P INNER JOIN Historico_Precio HP " & _
                                                "ON P.CodProd=HP.Producto_CodProd " & _
                                                    "INNER JOIN (" & _
                                                        "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " & _
                                                            "FROM Historico_Precio GROUP BY Producto_CodProd) C " & _
                                                                "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " & _
                                            "WHERE CodProd=@Param1 AND Activo=1"
                Dim Cmd As New SqlCommand(ConsultaProd, Cnn)

                Cmd.Parameters.AddWithValue("@Param1", CodProd)

                Dim Lector As SqlDataReader = Cmd.ExecuteReader()

                While Lector.Read()
                    Producto.CodProd = Lector(0)
                    Producto.Nombre = Lector(1)
                    Producto.Sector = Lector(2)
                    Producto.Descripcion = Lector(3)
                    Producto.Cantidad = Lector(4)
                    Producto.Precio = Lector(5)
                End While

                Return Producto
            End If

        End Using
    End Function

    Public Shared Function ObtenerIDProducto(Nombre As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1"
            Dim CmdValidar As New SqlCommand(ConsultaValidar, Cnn)
            CmdValidar.Parameters.AddWithValue("@Param1", Nombre)

            Dim Resultado As Integer = CmdValidar.ExecuteScalar()

            If Resultado = 0 Then
                Throw New WarningException(My.Resources.ArchivoIdioma.ProductoDadoBaja)
            Else
                Dim ConsultaID As String = "SELECT CodProd FROM Producto WHERE Nombre=@Param1 AND Activo=1"
                Dim Cmd As New SqlCommand(ConsultaID, Cnn)

                Cmd.Parameters.AddWithValue("@Param1", Nombre)

                Dim CodProd As Integer = Cmd.ExecuteScalar()

                Return CodProd
            End If
        End Using
    End Function


    Public Shared Function StockIDProd(ByVal CodProd As Integer) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaStock As String = "SELECT Cantidad FROM Producto WHERE CodProd=@Param1"
            Dim Cmd As New SqlCommand(ConsultaStock, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", CodProd)

            Dim Cantidad As Integer = CInt(Cmd.ExecuteScalar())

            Return Cantidad
        End Using
    End Function

    ''' 
    ''' <param name="Nombre"></param>
    Public Shared Function ValidarProducto(ByVal Nombre As String) As Integer
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()

            Dim ConsultaValidar As String = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1"
            Dim Cmd As New SqlCommand(ConsultaValidar, Cnn)
            Cmd.Parameters.AddWithValue("@Param1", Nombre)

            Dim Resultado As Integer = Cmd.ExecuteScalar()

            Return Resultado
        End Using
    End Function

End Class ' ProductoAD