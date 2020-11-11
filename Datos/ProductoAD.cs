using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class ProductoAD
    {
        public static void ActualizarStock(int CodProd, int Cantidad)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaStock = "UPDATE Producto SET Cantidad-=@Param1 WHERE CodProd=@Param2";
                var Cmd = new SqlCommand(ConsultaStock, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Cantidad);
                Cmd.Parameters.AddWithValue("@Param2", CodProd);
                Cmd.ExecuteNonQuery();
            }
        }

        /// <param name="Producto"></param>
        public static void AltaProducto(ProductoEN Producto)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaAlta = "INSERT INTO Producto(Nombre,Descripcion,Cantidad,Sector,Activo,DVH)" + "VALUES(@Nombre,@Descripcion,@Cantidad,@Sector,1,0) " + "SELECT SCOPE_IDENTITY()";

                var CmdAltaProd = new SqlCommand(ConsultaAlta, Cnn);
                CmdAltaProd.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                CmdAltaProd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                CmdAltaProd.Parameters.AddWithValue("@Cantidad", Producto.Cantidad);
                CmdAltaProd.Parameters.AddWithValue("@Sector", Producto.Sector);
                int CodProd = Conversions.ToInteger(CmdAltaProd.ExecuteScalar());
                Producto.CodProd = CodProd;
                string ConsultaAltaPrecio = "INSERT INTO Historico_Precio(Producto_CodProd,Precio,FechaDesde,DVH)VALUES(@CodProd,@Precio,GETDATE(),0) " + "SELECT SCOPE_IDENTITY()";
                var CmdPrecio = new SqlCommand(ConsultaAltaPrecio, Cnn);
                CmdPrecio.Parameters.AddWithValue("@CodProd", Producto.CodProd);
                CmdPrecio.Parameters.AddWithValue("@Precio", Producto.Precio);
                int CodHistorico = Conversions.ToInteger(CmdPrecio.ExecuteScalar());
                Producto.CodHistorico = CodHistorico;
            }
        }

        /// <param name="Producto"></param>
        public static void BajaProducto(ProductoEN Producto)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoEstaEliminado);
                }
                else
                {
                    string ConsultaBaja = "UPDATE Producto SET Activo=0 WHERE CodProd=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Producto.CodProd);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        /// <param name="campo"></param>
    /// <param name="valor"></param>
        public static List<ProductoEN> BuscarProducto(string Campo, string Valor)
        {
            var ListaProducto = new List<ProductoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                switch (Campo ?? "")
                {
                    case var @case when @case == (Datos.My.Resources.ArchivoIdioma.CMBNombre ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " + "FROM Producto P INNER JOIN Historico_Precio HP " + "ON P.CodProd=HP.Producto_CodProd " + "INNER JOIN (" + "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " + "FROM Historico_Precio GROUP BY Producto_CodProd) C " + "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " + "WHERE Activo=1 AND Nombre=@Param1";






                            break;
                        }

                    case var case1 when case1 == (Datos.My.Resources.ArchivoIdioma.CMBSector ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " + "FROM Producto P INNER JOIN Historico_Precio HP " + "ON P.CodProd=HP.Producto_CodProd " + "INNER JOIN (" + "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " + "FROM Historico_Precio GROUP BY Producto_CodProd) C " + "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " + "WHERE Activo=1 AND Sector LIKE '%' + @Param1 + '%'";






                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", Valor);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnProducto = new ProductoEN();
                    UnProducto.CodProd = Conversions.ToInteger(Lector[0]);
                    UnProducto.Nombre = Conversions.ToString(Lector[1]);
                    UnProducto.Sector = Conversions.ToString(Lector[2]);
                    UnProducto.Cantidad = Conversions.ToInteger(Lector[3]);
                    UnProducto.Precio = Conversions.ToString(Lector[4]);
                    UnProducto.Descripcion = Conversions.ToString(Lector[5]);
                    ListaProducto.Add(UnProducto);
                }
            }

            return ListaProducto;
        }

        public static List<ProductoEN> CargarProducto()
        {
            var ListaProducto = new List<ProductoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaProducto = "SELECT CodProd,Nombre,Sector,Cantidad,Precio,Descripcion " + "FROM Producto P INNER JOIN Historico_Precio HP " + "ON P.CodProd=HP.Producto_CodProd " + "INNER JOIN (" + "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " + "FROM Historico_Precio GROUP BY Producto_CodProd) C " + "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " + "WHERE Activo=1";






                var Cmd = new SqlCommand(ConsultaProducto, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnProducto = new ProductoEN();
                    UnProducto.CodProd = Conversions.ToInteger(Lector[0]);
                    UnProducto.Nombre = Conversions.ToString(Lector[1]);
                    UnProducto.Sector = Conversions.ToString(Lector[2]);
                    UnProducto.Cantidad = Conversions.ToInteger(Lector[3]);
                    UnProducto.Precio = Conversions.ToString(Lector[4]);
                    UnProducto.Descripcion = Conversions.ToString(Lector[5]);
                    ListaProducto.Add(UnProducto);
                }
            }

            return ListaProducto;
        }

        public static void ModificarPrecioProducto(ProductoEN Producto)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoDadoBaja);
                }
                else
                {
                    string ConsultaPrecio = "INSERT INTO Historico_Precio(Producto_CodProd,Precio,FechaDesde,DVH)VALUES(@CodProd,@Precio,GETDATE(),0) " + "SELECT SCOPE_IDENTITY()";
                    var CmdPrecio = new SqlCommand(ConsultaPrecio, Cnn);
                    CmdPrecio.Parameters.AddWithValue("@CodProd", Producto.CodProd);
                    CmdPrecio.Parameters.AddWithValue("@Precio", Producto.Precio);
                    int CodHistorico = Conversions.ToInteger(CmdPrecio.ExecuteScalar());
                    Producto.CodHistorico = CodHistorico;
                }
            }
        }

        /// <param name="Producto"></param>
        public static void ModificarProducto(ProductoEN Producto)
        {
            string NombreProd = "";
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoDadoBaja);
                }
                else
                {
                    string ConsultaNombreProd = "SELECT Nombre FROM Producto WHERE CodProd=@Param1";
                    var CmdNombreProd = new SqlCommand(ConsultaNombreProd, Cnn);
                    CmdNombreProd.Parameters.AddWithValue("@Param1", Producto.CodProd);
                    var Lector = CmdNombreProd.ExecuteReader();
                    while (Lector.Read())
                        NombreProd = Conversions.ToString(Lector[0]);
                    if ((NombreProd ?? "") != (Producto.Nombre ?? ""))
                    {
                        string ConsultaValidarNombre = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1";
                        var CmdValidarNombre = new SqlCommand(ConsultaValidarNombre, Cnn);
                        CmdValidarNombre.Parameters.AddWithValue("@Param1", Producto.Nombre);
                        int ResultadoNombre = Conversions.ToInteger(CmdValidarNombre.ExecuteScalar());
                        if (ResultadoNombre > 0)
                        {
                            throw new WarningException(Datos.My.Resources.ArchivoIdioma.NombreProductoExistente);
                        }
                        else
                        {
                            string ConsultaModificarConNombre = "UPDATE Producto SET Nombre=@Nombre,Sector=@Sector,Descripcion=@Desc WHERE CodProd=@Param1";
                            var CmdModNombre = new SqlCommand(ConsultaModificarConNombre, Cnn);
                            CmdModNombre.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                            CmdModNombre.Parameters.AddWithValue("@Sector", Producto.Sector);
                            CmdModNombre.Parameters.AddWithValue("@Desc", Producto.Descripcion);
                            CmdModNombre.Parameters.AddWithValue("@Param1", Producto.CodProd);
                            CmdModNombre.ExecuteNonQuery();
                            return;
                        }
                    }

                    string ConsultaModificar = "UPDATE Producto SET Nombre=@Nombre,Sector=@Sector,Descripcion=@Desc WHERE CodProd=@Param1";
                    var Cmd = new SqlCommand(ConsultaModificar, Cnn);
                    Cmd.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    Cmd.Parameters.AddWithValue("@Sector", Producto.Sector);
                    Cmd.Parameters.AddWithValue("@Desc", Producto.Descripcion);
                    Cmd.Parameters.AddWithValue("@Param1", Producto.CodProd);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarStockProducto(ProductoEN Producto)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Producto.CodProd);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoDadoBaja);
                }
                else
                {
                    string ConsultaStock = "UPDATE Producto SET Cantidad+=@Param1 WHERE CodProd=@Param2";
                    var Cmd = new SqlCommand(ConsultaStock, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Producto.Cantidad);
                    Cmd.Parameters.AddWithValue("@Param2", Producto.CodProd);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static ProductoEN ObtenerProducto(int CodProd)
        {
            var Producto = new ProductoEN();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE CodProd=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", CodProd);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoDadoBaja);
                }
                else
                {
                    string ConsultaProd = "SELECT CodProd,Nombre,Sector,Descripcion,Cantidad,Precio " + "FROM Producto P INNER JOIN Historico_Precio HP " + "ON P.CodProd=HP.Producto_CodProd " + "INNER JOIN (" + "SELECT Producto_CodProd, MAX(FechaDesde) AS 'UltimaFecha' " + "FROM Historico_Precio GROUP BY Producto_CodProd) C " + "ON HP.Producto_CodProd = C.Producto_CodProd AND HP.FechaDesde = C.UltimaFecha " + "WHERE CodProd=@Param1 AND Activo=1";






                    var Cmd = new SqlCommand(ConsultaProd, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", CodProd);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        Producto.CodProd = Conversions.ToInteger(Lector[0]);
                        Producto.Nombre = Conversions.ToString(Lector[1]);
                        Producto.Sector = Conversions.ToString(Lector[2]);
                        Producto.Descripcion = Conversions.ToString(Lector[3]);
                        Producto.Cantidad = Conversions.ToInteger(Lector[4]);
                        Producto.Precio = Conversions.ToString(Lector[5]);
                    }

                    return Producto;
                }
            }
        }

        public static int ObtenerIDProducto(string Nombre)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Nombre);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProductoDadoBaja);
                }
                else
                {
                    string ConsultaID = "SELECT CodProd FROM Producto WHERE Nombre=@Param1 AND Activo=1";
                    var Cmd = new SqlCommand(ConsultaID, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Nombre);
                    int CodProd = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return CodProd;
                }
            }
        }

        public static int StockIDProd(int CodProd)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaStock = "SELECT Cantidad FROM Producto WHERE CodProd=@Param1";
                var Cmd = new SqlCommand(ConsultaStock, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodProd);
                int Cantidad = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Cantidad;
            }
        }

        /// <param name="Nombre"></param>
        public static int ValidarProducto(string Nombre)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Producto WHERE Nombre=@Param1 AND Activo=1";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Nombre);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }
    }
} // ProductoAD