Imports Entidades
Imports System.Configuration
Imports System.Data.SqlClient
Imports Excepciones

Public Class NegocioAD
    Public Shared Sub AltaLineaDetalle(CodNota As Integer, Detalle As DetalleEN, Tabla As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand

            Select Case Tabla
                Case "Detalle_NotaVenta"
                    Dim ConsultaDNV As String = "INSERT INTO Detalle_NotaVenta(Nota_Venta_CodNot,Producto_CodProd,Precio,Cantidad)" & _
                                                    "VALUES(@CodNota,@CodProd,@Precio,@Cantidad)"
                    Cmd.Connection = Cnn
                        Cmd.CommandText = ConsultaDNV
                Case "Detalle_NotaPedido"
                    Dim ConsultaDNV As String = "INSERT INTO Detalle_NotaPedido(Nota_Pedido_CodNot,Producto_CodProd,Precio,Cantidad)" & _
                                                    "VALUES(@CodNota,@CodProd,@Precio,@Cantidad)"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = ConsultaDNV
            End Select

            Cmd.Parameters.AddWithValue("@CodNota", CodNota)
            Cmd.Parameters.AddWithValue("@CodProd", Detalle.CodProd)
            Cmd.Parameters.AddWithValue("@Cantidad", Detalle.Cantidad)
            Cmd.Parameters.AddWithValue("@Precio", Detalle.Precio)

            Cmd.ExecuteNonQuery()
        End Using

    End Sub

    Public Shared Sub AltaLineaDetalle(CodDet As Integer, Detalle As DetalleEN)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim ConsultaDet As String = "INSERT INTO Detalle_RemitoNV(Remito_NotaVenta_CodRemito,Producto_CodProd,Cantidad)" & _
                                                    "VALUES(@CodNot,@CodProd,@Cantidad)"
                Dim Cmd As New SqlCommand(ConsultaDet, Cnn)
                Cmd.Parameters.AddWithValue("@CodNot", CodDet)
                Cmd.Parameters.AddWithValue("@CodProd", Detalle.CodProd)
                Cmd.Parameters.AddWithValue("@Cantidad", Detalle.Cantidad)

                Cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Sub AltaTelefono(Codigo As Integer, Telefono As TelefonoEN, tabla As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand
            Select Case tabla
                Case "Tel_Usu"
                    Dim TelefonoUsuarioAlta As String = "INSERT INTO Tel_Usu VALUES(@Codigo,@Numero)"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoUsuarioAlta
                Case "Tel_Cli"
                    Dim TelefonoClienteAlta As String = "INSERT INTO Tel_Cli VALUES(@Codigo,@Numero)"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoClienteAlta
                Case "Tel_Prov"
                    Dim TelefonoProvAlta As String = "INSERT INTO Tel_Prov VALUES(@Codigo,@Numero)"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoProvAlta
            End Select

            Cmd.Parameters.AddWithValue("@Codigo", Codigo)
            Cmd.Parameters.AddWithValue("@Numero", Telefono.Numero)

            Cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Sub ModificarTelefono(codigo As Integer, Telefono As TelefonoEN, tabla As String)
        Using Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("Mercader").ToString())
            Cnn.Open()
            Dim Cmd As New SqlCommand
            Select Case tabla
                Case "Tel_Usu"
                    Dim TelefonoUsuarioMod As String = "UPDATE Tel_Usu SET Numero=@Param1 WHERE CodTel=@Param2 AND Usuario_CodUsu=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoUsuarioMod
                Case "Tel_Cli"
                    Dim TelefonoClienteMod As String = "UPDATE Tel_Cli SET Numero=@Param1 WHERE CodTel=@Param2 AND Cliente_CodCli=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoClienteMod
                Case "Tel_Prov"
                    Dim TelefonoProvMod As String = "UPDATE Tel_Prov SET Numero=@Param1 WHERE CodTel=@Param2 AND Proveedor_CodProv=@Param3"
                    Cmd.Connection = Cnn
                    Cmd.CommandText = TelefonoProvMod
            End Select

            Cmd.Parameters.AddWithValue("@Param1", Telefono.Numero)
            Cmd.Parameters.AddWithValue("@Param2", Telefono.CodTel)
            Cmd.Parameters.AddWithValue("@Param3", Telefono.CodEn)

            Cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
