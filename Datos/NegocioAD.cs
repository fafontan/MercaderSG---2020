using System.Configuration;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class NegocioAD
    {
        public static void AltaLineaDetalle(int CodNota, DetalleEN Detalle, string Tabla)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                switch (Tabla ?? "")
                {
                    case "Detalle_NotaVenta":
                        {
                            string ConsultaDNV = "INSERT INTO Detalle_NotaVenta(Nota_Venta_CodNot,Producto_CodProd,Precio,Cantidad)" + "VALUES(@CodNota,@CodProd,@Precio,@Cantidad)";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaDNV;
                            break;
                        }

                    case "Detalle_NotaPedido":
                        {
                            string ConsultaDNV = "INSERT INTO Detalle_NotaPedido(Nota_Pedido_CodNot,Producto_CodProd,Precio,Cantidad)" + "VALUES(@CodNota,@CodProd,@Precio,@Cantidad)";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaDNV;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@CodNota", CodNota);
                Cmd.Parameters.AddWithValue("@CodProd", Detalle.CodProd);
                Cmd.Parameters.AddWithValue("@Cantidad", Detalle.Cantidad);
                Cmd.Parameters.AddWithValue("@Precio", Detalle.Precio);
                Cmd.ExecuteNonQuery();
            }
        }

        public static void AltaLineaDetalle(int CodDet, DetalleEN Detalle)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaDet = "INSERT INTO Detalle_RemitoNV(Remito_NotaVenta_CodRemito,Producto_CodProd,Cantidad)" + "VALUES(@CodNot,@CodProd,@Cantidad)";
                var Cmd = new SqlCommand(ConsultaDet, Cnn);
                Cmd.Parameters.AddWithValue("@CodNot", CodDet);
                Cmd.Parameters.AddWithValue("@CodProd", Detalle.CodProd);
                Cmd.Parameters.AddWithValue("@Cantidad", Detalle.Cantidad);
                Cmd.ExecuteNonQuery();
            }
        }

        public static void AltaTelefono(int Codigo, TelefonoEN Telefono, string tabla)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                switch (tabla ?? "")
                {
                    case "Tel_Usu":
                        {
                            string TelefonoUsuarioAlta = "INSERT INTO Tel_Usu VALUES(@Codigo,@Numero)";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoUsuarioAlta;
                            break;
                        }

                    case "Tel_Cli":
                        {
                            string TelefonoClienteAlta = "INSERT INTO Tel_Cli VALUES(@Codigo,@Numero)";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoClienteAlta;
                            break;
                        }

                    case "Tel_Prov":
                        {
                            string TelefonoProvAlta = "INSERT INTO Tel_Prov VALUES(@Codigo,@Numero)";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoProvAlta;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Codigo", Codigo);
                Cmd.Parameters.AddWithValue("@Numero", Telefono.Numero);
                Cmd.ExecuteNonQuery();
            }
        }

        public static void ModificarTelefono(int codigo, TelefonoEN Telefono, string tabla)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                switch (tabla ?? "")
                {
                    case "Tel_Usu":
                        {
                            string TelefonoUsuarioMod = "UPDATE Tel_Usu SET Numero=@Param1 WHERE CodTel=@Param2 AND Usuario_CodUsu=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoUsuarioMod;
                            break;
                        }

                    case "Tel_Cli":
                        {
                            string TelefonoClienteMod = "UPDATE Tel_Cli SET Numero=@Param1 WHERE CodTel=@Param2 AND Cliente_CodCli=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoClienteMod;
                            break;
                        }

                    case "Tel_Prov":
                        {
                            string TelefonoProvMod = "UPDATE Tel_Prov SET Numero=@Param1 WHERE CodTel=@Param2 AND Proveedor_CodProv=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = TelefonoProvMod;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", Telefono.Numero);
                Cmd.Parameters.AddWithValue("@Param2", Telefono.CodTel);
                Cmd.Parameters.AddWithValue("@Param3", Telefono.CodEn);
                Cmd.ExecuteNonQuery();
            }
        }
    }
}