using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EntidadesC;
using ExcepcionesC;
using Microsoft.VisualBasic.CompilerServices;

namespace DatosC
{
    public class ClienteAD
    {

        /// <param name="Cliente"></param>
        public static void AltaCliente(ClienteEN Cliente)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCli = "INSERT INTO Cliente(Localidad_CodLoc,Cuit," + "RazonSocial,Calle,Numero,Piso,Departamento,Activo,DVH)VALUES(" + "@Localidad_CodLoc,@Cuit,@RazonSocial,@Calle,@Numero,@Piso," + "@Departamento,1,0) " + "SELECT SCOPE_IDENTITY()";



                var Cmd = new SqlCommand(ConsultaCli, Cnn);
                Cmd.Parameters.AddWithValue("@Localidad_CodLoc", Cliente.CodLoc);
                Cmd.Parameters.AddWithValue("@Cuit", Cliente.Cuit);
                Cmd.Parameters.AddWithValue("@RazonSocial", Cliente.RazonSocial);
                Cmd.Parameters.AddWithValue("@Calle", Cliente.Calle);
                Cmd.Parameters.AddWithValue("@Numero", Cliente.Numero);
                Cmd.Parameters.AddWithValue("@Piso", Cliente.Piso);
                Cmd.Parameters.AddWithValue("@Departamento", Cliente.Departamento);
                int CodigoCli = Conversions.ToInteger(Cmd.ExecuteScalar());
                Cliente.CodCli = CodigoCli;
                foreach (TelefonoEN Telefono in Cliente.Telefono)
                    DatosC.NegocioAD.AltaTelefono(CodigoCli, Telefono, "Tel_Cli");
            }
        }

        /// <param name="Cliente"></param>
        public static void BajaCliente(ClienteEN Cliente)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Cliente.CodCli);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.ClienteEstaEliminado);
                    //throw new WarningException(Datosc.My.Resources.ArchivoIdioma.ClienteEstaEliminado);
                }
                else
                {
                    string ConsultaBaja = "UPDATE Cliente SET Activo=0 WHERE CodCli=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Cliente.CodCli);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        /// <param name="campo"></param>
        /// <param name="valor"></param>
        public static List<ClienteEN> BuscarCliente(string campo, string valor)
        {
            var ListaCliente = new List<ClienteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                switch (campo ?? "")
                {
                    case var @case when @case == (My.Resources.ArchivoIdioma.CMBCuit ?? ""):
                    //case var @case when @case == (DatosC.My.Resources.ArchivoIdioma.CMBCuit ?? ""):
                        {
                            Cmd.CommandText = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " + "FROM Cliente C, Localidad L " + "WHERE C.Localidad_CodLoc= L.CodLoc AND C.Cuit=@Param1 AND C.Activo=1";

                            break;
                        }

                    case var case1 when case1 == (My.Resources.ArchivoIdioma.CMBRazonSocial ?? ""):
                    //case var case1 when case1 == (DatosC.My.Resources.ArchivoIdioma.CMBRazonSocial ?? ""):
                        {
                            Cmd.CommandText = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " + "FROM Cliente C, Localidad L " + "WHERE C.Localidad_CodLoc= L.CodLoc AND C.RazonSocial LIKE '%' + @Param1 + '%' AND C.Activo=1";

                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", valor);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnCliente = new ClienteEN();
                    UnCliente.CodCli = Conversions.ToInteger(Lector[0]);
                    UnCliente.RazonSocial = Conversions.ToString(Lector[1]);
                    UnCliente.Cuit = Conversions.ToString(Lector[2]);
                    UnCliente.Direccion = Conversions.ToString(Lector[3]);
                    UnCliente.Activo = Conversions.ToBoolean(Lector[4]);
                    UnCliente.Localidad = Conversions.ToString(Lector[5]);
                    ListaCliente.Add(UnCliente);
                }

                return ListaCliente;
            }
        }

        public static List<ClienteEN> CargarCliente()
        {
            var ListaClientes = new List<ClienteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT C.CodCli,C.RazonSocial,C.Cuit,(C.Calle + ' ' + C.Numero) AS Direccion,C.Activo,L.Descripcion " + "FROM Cliente C, Localidad L " + "WHERE C.Localidad_CodLoc= L.CodLoc AND C.Activo=1";

                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnCliente = new ClienteEN();
                    UnCliente.CodCli = Conversions.ToInteger(Lector[0]);
                    UnCliente.RazonSocial = Conversions.ToString(Lector[1]);
                    UnCliente.Cuit = Conversions.ToString(Lector[2]);
                    UnCliente.Direccion = Conversions.ToString(Lector[3]);
                    UnCliente.Activo = Conversions.ToBoolean(Lector[4]);
                    UnCliente.Localidad = Conversions.ToString(Lector[5]);
                    ListaClientes.Add(UnCliente);
                }

                return ListaClientes;
            }
        }

        public static void EliminarTelefonoCliente(TelefonoEN UnTelefono)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidarTel = "SELECT COUNT(*) FROM Tel_Cli WHERE CodTel=@Param1 AND Cliente_CodCli=@Param2";
                var CmdValidar = new SqlCommand(ConsultaValidarTel, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel);
                CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaEliminarTel = "DELETE FROM Tel_Cli WHERE CodTel=@Param1 AND Cliente_CodCli=@Param2";
                    var Cmd = new SqlCommand(ConsultaEliminarTel, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", UnTelefono.CodTel);
                    Cmd.Parameters.AddWithValue("@Param2", UnTelefono.CodEn);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.NumeroTelefonoNoExiste);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.NumeroTelefonoNoExiste);
                }
            }
        }

        /// <param name="Cliente"></param>
        public static void ModificarCliente(ClienteEN Cliente)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                int CodigoCliente = Cliente.CodCli;
                string ConsultaExiste = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CodigoCliente);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.ClienteDadoBaja);
                }
                else
                {
                    string ConsultaModificar = "UPDATE Cliente SET Localidad_CodLoc=@CodLoc,Cuit=@Cuit,RazonSocial=@RazonSocial," + "Calle=@Calle,Numero=@Numero,Piso=@Piso,Departamento=@Dpto FROM Cliente WHERE CodCli=@CodCli";
                    var Cmd = new SqlCommand(ConsultaModificar, Cnn);
                    Cmd.Parameters.AddWithValue("@CodLoc", Cliente.CodLoc);
                    Cmd.Parameters.AddWithValue("@Cuit", Cliente.Cuit);
                    Cmd.Parameters.AddWithValue("@RazonSocial", Cliente.RazonSocial);
                    Cmd.Parameters.AddWithValue("@Calle", Cliente.Calle);
                    Cmd.Parameters.AddWithValue("@Numero", Cliente.Numero);
                    Cmd.Parameters.AddWithValue("@Piso", Cliente.Piso);
                    Cmd.Parameters.AddWithValue("@Dpto", Cliente.Departamento);
                    Cliente.CodCli = CodigoCliente;
                    Cmd.Parameters.AddWithValue("@CodCli", Cliente.CodCli);
                    Cmd.ExecuteNonQuery();
                    foreach (TelefonoEN Telefono in Cliente.Telefono)
                        DatosC.NegocioAD.ModificarTelefono(CodigoCliente, Telefono, "Tel_Cli");
                }
            }
        }

        /// <param name="Codigo"></param>
        public static ClienteEN ObtenerCliente(int Codigo)
        {
            var Cliente = new ClienteEN();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Codigo);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.ClienteDadoBaja);
                }
                else
                {
                    string ConsultaCliente = "SELECT CodCli,Localidad_CodLoc,RazonSocial,Cuit,Calle,Numero,Piso,Departamento" + " FROM Cliente WHERE CodCli=@Param1";
                    var Cmd = new SqlCommand(ConsultaCliente, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Codigo);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        Cliente.CodCli = Conversions.ToInteger(Lector[0]);
                        Cliente.CodLoc = Conversions.ToInteger(Lector[1]);
                        Cliente.RazonSocial = Conversions.ToString(Lector[2]);
                        Cliente.Cuit = Conversions.ToString(Lector[3]);
                        Cliente.Calle = Conversions.ToString(Lector[4]);
                        Cliente.Numero = Conversions.ToString(Lector[5]);
                        Cliente.Piso = Conversions.ToString(Lector[6]);
                        Cliente.Departamento = Conversions.ToString(Lector[7]);
                    }

                    return Cliente;
                }
            }
        }

        public static int ObtenerIDCliente(string Cuit)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND Cuit=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Cuit);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.ClienteDadoBaja);
                }
                else
                {
                    string ConsultaId = "SELECT CodCli FROM Cliente WHERE Cuit=@Param1 AND Activo=1";
                    var Cmd = new SqlCommand(ConsultaId, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Cuit);
                    int CodigoCliente = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return CodigoCliente;
                }
            }
        }

        public static List<TelefonoEN> ObtenerTelefonoCliente(int CodCli)
        {
            var ListaTel = new List<TelefonoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Cliente WHERE Activo=1 AND CodCli=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CodCli);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.ClienteDadoBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.ClienteDadoBaja);
                }
                else
                {
                    string ConsultaTel = "SELECT CodTel,Cliente_CodCli,Numero FROM Tel_Cli WHERE Cliente_CodCli=@Param1";
                    var Cmd = new SqlCommand(ConsultaTel, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", CodCli);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        var UnTelefono = new TelefonoEN();
                        UnTelefono.CodTel = Conversions.ToInteger(Lector[0]);
                        UnTelefono.CodEn = Conversions.ToInteger(Lector[1]);
                        UnTelefono.Numero = Conversions.ToString(Lector[2]);
                        ListaTel.Add(UnTelefono);
                    }

                    return ListaTel;
                }
            }
        }

        public static int ValidarCliente(string Cuit)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCli = "SELECT COUNT(*) FROM Cliente WHERE Cuit=@Param1 AND Activo=1";
                var Cmd = new SqlCommand(ConsultaCli, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Cuit);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }
    }
} // ClienteAD