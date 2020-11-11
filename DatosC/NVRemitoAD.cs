using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntidadesC;
using Microsoft.VisualBasic.CompilerServices;

namespace DatosC
{
    public class NVRemitoAD
    {
        public static DataSet CargarRemito()
        {
            var ds = new DataSet();
            return ds;
        }

        public static void CargarRemitoNV(DataSet DS, string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@NroNota";
                var Cmd = new SqlCommand(Consulta, Cnn);
                Cmd.Parameters.AddWithValue("@NroNota", NroNota);
                int CodNot = Conversions.ToInteger(Cmd.ExecuteScalar());
                string ConsultaCliente = "SELECT * FROM Cliente";
                string ConsultaProducto = "SELECT * FROM Producto";
                string ConsultaRem = "SELECT * FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param1";
                string ConsultaDetalle_Rem = "SELECT * FROM Detalle_RemitoNV";
                string ConsultaLoc = "SELECT * FROM Localidad";
                var daCliente = new SqlDataAdapter(ConsultaCliente, Cnn);
                var daProducto = new SqlDataAdapter(ConsultaProducto, Cnn);
                var daNV = new SqlDataAdapter();
                daNV.SelectCommand = new SqlCommand(ConsultaRem, Cnn);
                daNV.SelectCommand.Parameters.AddWithValue("@Param1", CodNot);
                var daDetalle = new SqlDataAdapter(ConsultaDetalle_Rem, Cnn);
                var daLocalidad = new SqlDataAdapter(ConsultaLoc, Cnn);
                daCliente.Fill(DS, "Cliente");
                daProducto.Fill(DS, "Producto");
                daNV.Fill(DS, "Remito_NotaVenta");
                daDetalle.Fill(DS, "Detalle_RemitoNV");
                daLocalidad.Fill(DS, "Localidad");
            }
        }

        public static void GenerarRemito(int CodNot, NVRemitoEN RENV)
        {
            var ListaDetalleNV = new List<DetalleEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCli = "SELECT Cliente_CodCli FROM Nota_Venta WHERE CodNot=@CodNot";
                var CmdCli = new SqlCommand(ConsultaCli, Cnn);
                CmdCli.Parameters.AddWithValue("@CodNot", CodNot);
                int CodCli = Conversions.ToInteger(CmdCli.ExecuteScalar());
                string ConsultaNV = "INSERT INTO Remito_NotaVenta(Nota_Venta_CodNot,Nro_Remito,Cliente_CodCli,Fecha) " + "VALUES(@CodNot,'0',@CodCli,GETDATE())" + " SELECT SCOPE_IDENTITY()";

                var Cmd = new SqlCommand(ConsultaNV, Cnn);
                Cmd.Parameters.AddWithValue("@CodNot", CodNot);
                Cmd.Parameters.AddWithValue("@CodCli", CodCli);
                RENV.CodRemito = Conversions.ToInteger(Cmd.ExecuteScalar());
                string ConsultaDetNV = "SELECT Producto_CodProd,Cantidad" + " FROM Detalle_NotaVenta WHERE Nota_Venta_CodNot=@Param1";
                var CmdDetalle = new SqlCommand(ConsultaDetNV, Cnn);
                CmdDetalle.Parameters.AddWithValue("@Param1", CodNot);
                var Lector = CmdDetalle.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaLinea = new DetalleEN();
                    UnaLinea.CodProd = Conversions.ToInteger(Lector[0]);
                    UnaLinea.Cantidad = Conversions.ToInteger(Lector[1]);
                    ListaDetalleNV.Add(UnaLinea);
                }

                foreach (DetalleEN Detalle in ListaDetalleNV)
                    Datos.NegocioAD.AltaLineaDetalle(RENV.CodRemito, Detalle);
            }
        }

        public static int ValidarRemitoNV(int CodNot)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param1";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodNot);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static int VerificarRemitoNV(string NroNota)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT CodNot FROM Nota_Venta WHERE Nro_Nota=@Param1";
                var Cmd = new SqlCommand(Consulta, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", NroNota);
                int CodNot = Conversions.ToInteger(Cmd.ExecuteScalar());
                string ConsultaExiste = "SELECT COUNT(*) FROM Remito_NotaVenta WHERE Nota_Venta_CodNot=@Param2";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param2", CodNot);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                return Resultado;
            }
        }
    }
}