using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class NotaVentaAD
    {
        public static void BajaNotaVenta(NotaVentaEN NotaVenta)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", NotaVenta.NroNota);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0";
                    var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                    CmdActivo.Parameters.AddWithValue("@Param1", NotaVenta.NroNota);
                    int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                    if (Activo > 0)
                    {
                        throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaVentaDadaBaja);
                    }
                    else
                    {
                        // BajaNota
                        string ConsultaUpdate = "UPDATE Nota_Venta SET Activo=0 WHERE Nro_Nota=@Param1";
                        var CmdUpdate = new SqlCommand(ConsultaUpdate, Cnn);
                        CmdUpdate.Parameters.AddWithValue("@Param1", NotaVenta.NroNota);
                        CmdUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaVentaNoExiste);
                }
            }
        }

        public static List<NotaVentaEN> CargarNotaVenta()
        {
            var ListaNV = new List<NotaVentaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Venta WHERE Activo=1";
                var Cmd = new SqlCommand(Consulta, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaNota = new NotaVentaEN();
                    UnaNota.NroNota = Conversions.ToString(Lector[0]);
                    UnaNota.Fecha = Conversions.ToString(Lector[1]);
                    ListaNV.Add(UnaNota);
                }

                return ListaNV;
            }
        }

        public static void CargarNotaVenta(DataSet DS, string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCliente = "SELECT * FROM Cliente";
                string ConsultaProducto = "SELECT * FROM Producto";
                string ConsultaNV = "SELECT * FROM Nota_Venta WHERE Nro_Nota=@Param1";
                string ConsultaDetalle_NV = "SELECT * FROM Detalle_NotaVenta";
                string ConsultaLoc = "SELECT * FROM Localidad";
                var daCliente = new SqlDataAdapter(ConsultaCliente, Cnn);
                var daProducto = new SqlDataAdapter(ConsultaProducto, Cnn);
                var daNV = new SqlDataAdapter();
                daNV.SelectCommand = new SqlCommand(ConsultaNV, Cnn);
                daNV.SelectCommand.Parameters.AddWithValue("@Param1", NroNota);
                var daDetalle = new SqlDataAdapter(ConsultaDetalle_NV, Cnn);
                var daLocalidad = new SqlDataAdapter(ConsultaLoc, Cnn);
                daCliente.Fill(DS, "Cliente");
                daProducto.Fill(DS, "Producto");
                daNV.Fill(DS, "Nota_Venta");
                daDetalle.Fill(DS, "Detalle_NotaVenta");
                daLocalidad.Fill(DS, "Localidad");
            }
        }

        public static void CargarUltimaNotaVenta(DataSet DS)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCliente = "SELECT * FROM Cliente";
                string ConsultaProducto = "SELECT * FROM Producto";
                string ConsultaNV = "SELECT TOP 1 * FROM Nota_Venta WHERE Activo=1 GROUP BY CodNot,Nro_Nota,Cliente_CodCli,Fecha,Activo ORDER BY CodNot DESC";
                string ConsultaDetalle_NV = "SELECT * FROM Detalle_NotaVenta";
                string ConsultaLoc = "SELECT * FROM Localidad";
                var daCliente = new SqlDataAdapter(ConsultaCliente, Cnn);
                var daProducto = new SqlDataAdapter(ConsultaProducto, Cnn);
                var daNV = new SqlDataAdapter(ConsultaNV, Cnn);
                var daDetalle = new SqlDataAdapter(ConsultaDetalle_NV, Cnn);
                var daLocalidad = new SqlDataAdapter(ConsultaLoc, Cnn);
                daCliente.Fill(DS, "Cliente");
                daProducto.Fill(DS, "Producto");
                daNV.Fill(DS, "Nota_Venta");
                daDetalle.Fill(DS, "Detalle_NotaVenta");
                daLocalidad.Fill(DS, "Localidad");
            }
        }

        /// <param name="NotaVenta"></param>
        public static void CrearNotaVenta(NotaVentaEN NotaVenta)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaAlta = "INSERT INTO Nota_Venta(Nro_Nota,Cliente_CodCli,Fecha,Activo)" + "VALUES('1',@CodCli,GETDATE(),1) " + "SELECT SCOPE_IDENTITY()";

                var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                Cmd.Parameters.AddWithValue("@CodCli", NotaVenta.CodCli);
                NotaVenta.CodNot = Conversions.ToInteger(Cmd.ExecuteScalar());
                foreach (DetalleEN item in NotaVenta.Detalle)
                    Datos.NegocioAD.AltaLineaDetalle(NotaVenta.CodNot, item, "Detalle_NotaVenta");
            }
        }

        public static int ObtenerIDNotaVenta(string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCod = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@Param1";
                var Cmd = new SqlCommand(ConsultaCod, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", NroNota);
                int CodNot = Conversions.ToInteger(Cmd.ExecuteScalar());
                return CodNot;
            }
        }

        /// <param name="NroNota"></param>
        public static int ValidarNotaVenta(string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0";
                var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota);
                int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                if (Activo > 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaVentaDadaBaja);
                }
                else
                {
                    string ConsultaValidar = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1";
                    var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", NroNota);
                    int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return Resultado;
                }
            }
        }

        public static List<NotaVentaEN> BuscarNotaVenta(string NroNota)
        {
            var ListaNota = new List<NotaVentaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Venta WHERE Nro_Nota=@Param1 AND Activo=0";
                var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota);
                int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                if (Activo > 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaVentaDadaBaja);
                }
                else
                {
                    string Consulta = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Venta WHERE Nro_Nota LIKE '%' + @Param1 + '%'";
                    var CmdBuscar = new SqlCommand(Consulta, Cnn);
                    CmdBuscar.Parameters.AddWithValue("@Param1", NroNota);
                    var Lector = CmdBuscar.ExecuteReader();
                    while (Lector.Read())
                    {
                        var UnaNota = new NotaVentaEN();
                        UnaNota.NroNota = Conversions.ToString(Lector[0]);
                        UnaNota.Fecha = Conversions.ToString(Lector[1]);
                        ListaNota.Add(UnaNota);
                    }

                    return ListaNota;
                }
            }
        }

        public static List<DetalleEN> ObtenerDetalleNV(int CodNot)
        {
            var ListaDetalle = new List<DetalleEN>();
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaCantidad = "SELECT Producto_CodProd,Cantidad FROM Detalle_NotaVenta WHERE Nota_Venta_CodNot=@Param1";
                var CmdCantidad = new SqlCommand(ConsultaCantidad, cnn);
                CmdCantidad.Parameters.AddWithValue("@Param1", CodNot);
                var Lector = CmdCantidad.ExecuteReader();
                while (Lector.Read())
                {
                    var UnDetalle = new DetalleEN();
                    UnDetalle.CodProd = Conversions.ToInteger(Lector[0]);
                    UnDetalle.Cantidad = Conversions.ToInteger(Lector[1]);
                    ListaDetalle.Add(UnDetalle);
                }
            }

            return ListaDetalle;
        }

        public static void ActualizarCantidadProducto(DetalleEN Detalle)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaProd = "UPDATE Producto SET Cantidad+=@Param1 WHERE CodProd=@Param2";
                var CmdProd = new SqlCommand(ConsultaProd, cnn);
                CmdProd.Parameters.AddWithValue("@Param1", Detalle.Cantidad);
                CmdProd.Parameters.AddWithValue("@Param2", Detalle.CodProd);
                CmdProd.ExecuteNonQuery();
            }
        }
    }
} // NotaVentaAD