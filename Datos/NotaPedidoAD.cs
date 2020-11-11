using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class NotaPedidoAD
    {


        /// <param name="NotaPedido"></param>
        public static void BajaNotaPedido(NotaPedidoEN NotaPedido)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", NotaPedido.NroNota);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0";
                    var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                    CmdActivo.Parameters.AddWithValue("@Param1", NotaPedido.NroNota);
                    int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                    if (Activo > 0)
                    {
                        throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaPedidoDadaBaja);
                    }
                    else
                    {
                        string ConsultaUpdate = "UPDATE Nota_Pedido SET Activo=0 WHERE Nro_Nota=@Param1";
                        var CmdUpdate = new SqlCommand(ConsultaUpdate, Cnn);
                        CmdUpdate.Parameters.AddWithValue("@Param1", NotaPedido.NroNota);
                        CmdUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaPedidoNoExiste);
                }
            }
        }

        public static List<NotaPedidoEN> CargarNotaPedido()
        {
            var ListaNP = new List<NotaPedidoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Pedido WHERE Activo=1";
                var Cmd = new SqlCommand(Consulta, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaNota = new NotaPedidoEN();
                    UnaNota.NroNota = Conversions.ToString(Lector[0]);
                    UnaNota.Fecha = Conversions.ToDate(Lector[1]);
                    ListaNP.Add(UnaNota);
                }

                return ListaNP;
            }
        }

        public static void CargarNotaPedido(DataSet DS, string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaProveedor = "SELECT * FROM Proveedor";
                string ConsultaProducto = "SELECT * FROM Producto";
                string ConsultaNP = "SELECT * FROM Nota_Pedido WHERE Nro_Nota=@Param1";
                string ConsultaDetalle_NP = "SELECT * FROM Detalle_NotaPedido";
                string ConsultaLoc = "SELECT * FROM Localidad";
                var daProveedor = new SqlDataAdapter(ConsultaProveedor, Cnn);
                var daProducto = new SqlDataAdapter(ConsultaProducto, Cnn);
                var daNP = new SqlDataAdapter();
                daNP.SelectCommand = new SqlCommand(ConsultaNP, Cnn);
                daNP.SelectCommand.Parameters.AddWithValue("@Param1", NroNota);
                var daDetalle = new SqlDataAdapter(ConsultaDetalle_NP, Cnn);
                var daLocalidad = new SqlDataAdapter(ConsultaLoc, Cnn);
                daProveedor.Fill(DS, "Proveedor");
                daProducto.Fill(DS, "Producto");
                daNP.Fill(DS, "Nota_Pedido");
                daDetalle.Fill(DS, "Detalle_NotaPedido");
                daLocalidad.Fill(DS, "Localidad");
            }
        }

        public static void CargarUltimaNotaPedido(DataSet DS)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaProveedor = "SELECT * FROM Proveedor";
                string ConsultaProducto = "SELECT * FROM Producto";
                string ConsultaNP = "SELECT TOP 1 * FROM Nota_Pedido WHERE Activo=1 GROUP BY CodNot,Nro_Nota,Proveedor_CodProv,Fecha,Activo ORDER BY CodNot DESC";
                string ConsultaDetalle_NP = "SELECT * FROM Detalle_NotaPedido";
                string ConsultaLoc = "SELECT * FROM Localidad";
                var daProveedor = new SqlDataAdapter(ConsultaProveedor, Cnn);
                var daProducto = new SqlDataAdapter(ConsultaProducto, Cnn);
                var daNP = new SqlDataAdapter(ConsultaNP, Cnn);
                var daDetalle = new SqlDataAdapter(ConsultaDetalle_NP, Cnn);
                var daLocalidad = new SqlDataAdapter(ConsultaLoc, Cnn);
                daProveedor.Fill(DS, "Proveedor");
                daProducto.Fill(DS, "Producto");
                daNP.Fill(DS, "Nota_Pedido");
                daDetalle.Fill(DS, "Detalle_NotaPedido");
                daLocalidad.Fill(DS, "Localidad");
            }
        }

        /// <param name="NotaPedido"></param>
        public static void CrearNotaPedido(NotaPedidoEN NotaPedido)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaAlta = "INSERT INTO Nota_Pedido(Nro_Nota,Proveedor_CodProv,Fecha,Activo)" + "VALUES('1',@CodProv,GETDATE(),1) " + "SELECT SCOPE_IDENTITY()";

                var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                Cmd.Parameters.AddWithValue("@CodProv", NotaPedido.CodProv);
                NotaPedido.CodNot = Conversions.ToInteger(Cmd.ExecuteScalar());
                foreach (DetalleEN item in NotaPedido.Detalle)
                    Datos.NegocioAD.AltaLineaDetalle(NotaPedido.CodNot, item, "Detalle_NotaPedido");
            }
        }

        /// <param name="NroNota"></param>
        public static int ValidarNotaPedido(string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0";
                var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota);
                int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                if (Activo > 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaPedidoDadaBaja);
                }
                else
                {
                    string ConsultaValidar = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1";
                    var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", NroNota);
                    int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return Resultado;
                }
            }
        }

        public static List<NotaPedidoEN> BuscarNotaPedido(string NroNota)
        {
            var ListaNota = new List<NotaPedidoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaActivo = "SELECT COUNT(*) FROM Nota_Pedido WHERE Nro_Nota=@Param1 AND Activo=0";
                var CmdActivo = new SqlCommand(ConsultaActivo, Cnn);
                CmdActivo.Parameters.AddWithValue("@Param1", NroNota);
                int Activo = Conversions.ToInteger(CmdActivo.ExecuteScalar());
                if (Activo > 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NotaPedidoDadaBaja);
                }
                else
                {
                    string Consulta = "SELECT Nro_Nota,CONVERT(VARCHAR(10),Fecha,103) FROM Nota_Pedido WHERE Nro_Nota LIKE '%' + @Param1 + '%' AND Activo=1";
                    var Cmd = new SqlCommand(Consulta, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", NroNota);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        var UnaNota = new NotaPedidoEN();
                        UnaNota.NroNota = Conversions.ToString(Lector[0]);
                        UnaNota.Fecha = Conversions.ToDate(Lector[1]);
                        ListaNota.Add(UnaNota);
                    }

                    return ListaNota;
                }
            }
        }
    }
} // NotaPedidoAD