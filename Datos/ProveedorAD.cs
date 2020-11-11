using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class ProveedorAD
    {
        /// <param name="Proveedor"></param>
        public static void AltaProveedor(ProveedorEN Proveedor)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaProveedor = "INSERT INTO Proveedor(Localidad_CodLoc,Cuit,RazonSocial," + "CorreoElectronico,Calle,Numero,Piso,Departamento,Activo)" + "VALUES(@Localidad_CodLoc,@Cuit,@RazonSocial," + "@CorreoElectronico,@Calle,@Numero,@Piso,@Departamento,1) " + "SELECT SCOPE_IDENTITY()";



                var Cmd = new SqlCommand(ConsultaProveedor, Cnn);
                Cmd.Parameters.AddWithValue("@Localidad_CodLoc", Proveedor.CodLoc);
                Cmd.Parameters.AddWithValue("@Cuit", Proveedor.Cuit);
                Cmd.Parameters.AddWithValue("@RazonSocial", Proveedor.RazonSocial);
                Cmd.Parameters.AddWithValue("@CorreoElectronico", Proveedor.CorreoElectronico);
                Cmd.Parameters.AddWithValue("@Calle", Proveedor.Calle);
                Cmd.Parameters.AddWithValue("@Numero", Proveedor.Numero);
                Cmd.Parameters.AddWithValue("@Piso", Proveedor.Piso);
                Cmd.Parameters.AddWithValue("@Departamento", Proveedor.Departamento);
                int CodProvNuevo = Conversions.ToInteger(Cmd.ExecuteScalar());
                Proveedor.CodProv = CodProvNuevo;
                foreach (TelefonoEN Telefono in Proveedor.Telefono)
                    Datos.NegocioAD.AltaTelefono(CodProvNuevo, Telefono, "Tel_Prov");
            }
        }

        /// <param name="Proveedor"></param>
        public static void BajaProveedor(ProveedorEN Proveedor)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Proveedor.CodProv);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProveedorEstaEliminado);
                }
                else
                {
                    string ConsultaBaja = "UPDATE Proveedor SET Activo=0 WHERE CodProv=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Proveedor.CodProv);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        /// <param name="campo"></param>
    /// <param name="valor"></param>
        public static List<ProveedorEN> BuscarProveedor(string campo, string valor)
        {
            var ListaProveedor = new List<ProveedorEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                switch (campo ?? "")
                {
                    case var @case when @case == (Datos.My.Resources.ArchivoIdioma.CMBCuit ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodProv,RazonSocial,Cuit,(Calle + ' ' + Numero) AS Direccion,Activo  " + "FROM Proveedor WHERE Cuit=@Param1 AND Activo=1";
                            break;
                        }

                    case var case1 when case1 == (Datos.My.Resources.ArchivoIdioma.CMBRazonSocial ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodProv,RazonSocial,Cuit,(Calle + ' ' + Numero) AS Direccion,Activo  " + "FROM Proveedor WHERE RazonSocial LIKE '%' + @Param1 + '%' AND Activo=1";
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", valor);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnProveedor = new ProveedorEN();
                    UnProveedor.CodProv = Conversions.ToInteger(Lector[0]);
                    UnProveedor.RazonSocial = Conversions.ToString(Lector[1]);
                    UnProveedor.Cuit = Conversions.ToString(Lector[2]);
                    UnProveedor.Direccion = Conversions.ToString(Lector[3]);
                    UnProveedor.Activo = Conversions.ToBoolean(Lector[4]);
                    ListaProveedor.Add(UnProveedor);
                }

                return ListaProveedor;
            }
        }

        public static List<ProveedorEN> CargarProveedor()
        {
            var ListaProveedor = new List<ProveedorEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodProv,RazonSocial,Cuit,CorreoElectronico,(Calle + ' ' + Numero) AS Direccion,Activo  " + "FROM Proveedor WHERE Activo=1";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnProveedor = new ProveedorEN();
                    UnProveedor.CodProv = Conversions.ToInteger(Lector[0]);
                    UnProveedor.RazonSocial = Conversions.ToString(Lector[1]);
                    UnProveedor.Cuit = Conversions.ToString(Lector[2]);
                    UnProveedor.CorreoElectronico = Conversions.ToString(Lector[3]);
                    UnProveedor.Direccion = Conversions.ToString(Lector[4]);
                    UnProveedor.Activo = Conversions.ToBoolean(Lector[5]);
                    ListaProveedor.Add(UnProveedor);
                }

                return ListaProveedor;
            }
        }

        public static void EliminarTelefonoProveedor(TelefonoEN UnTelefono)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidarTel = "SELECT COUNT(*) FROM Tel_Prov WHERE CodTel=@Param1 AND Proveedor_CodProv=@Param2";
                var CmdValidar = new SqlCommand(ConsultaValidarTel, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel);
                CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaEliminarTel = "DELETE FROM Tel_Prov WHERE CodTel=@Param1 AND Proveedor_CodProv=@Param2";
                    var Cmd = new SqlCommand(ConsultaEliminarTel, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", UnTelefono.CodTel);
                    Cmd.Parameters.AddWithValue("@Param2", UnTelefono.CodEn);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.NumeroTelefonoNoExiste);
                }
            }
        }

        /// <param name="Proveedor"></param>
        public static void ModificarProveedor(ProveedorEN Proveedor)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                int CodProv = Proveedor.CodProv;
                string ConsultaExiste = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CodProv);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProveedorDadoBaja);
                }
                else
                {
                    string ConsultaModificar = "UPDATE Proveedor SET Localidad_CodLoc=@CodLoc,RazonSocial=@RazonSocial," + "Cuit=@Cuit,CorreoElectronico=@Correo,Calle=@Calle,Numero=@Numero,Piso=@Piso,Departamento=@Dpto " + "WHERE CodProv=@CodProv";

                    var Cmd = new SqlCommand(ConsultaModificar, Cnn);
                    Cmd.Parameters.AddWithValue("@CodLoc", Proveedor.CodLoc);
                    Cmd.Parameters.AddWithValue("@RazonSocial", Proveedor.RazonSocial);
                    Cmd.Parameters.AddWithValue("@Cuit", Proveedor.Cuit);
                    Cmd.Parameters.AddWithValue("@Correo", Proveedor.CorreoElectronico);
                    Cmd.Parameters.AddWithValue("@Calle", Proveedor.Calle);
                    Cmd.Parameters.AddWithValue("@Numero", Proveedor.Numero);
                    Cmd.Parameters.AddWithValue("@Piso", Proveedor.Piso);
                    Cmd.Parameters.AddWithValue("@Dpto", Proveedor.Departamento);
                    Cmd.Parameters.AddWithValue("@CodProv", CodProv);
                    Cmd.ExecuteNonQuery();
                    foreach (TelefonoEN Telefono in Proveedor.Telefono)
                        Datos.NegocioAD.ModificarTelefono(CodProv, Telefono, "Tel_Prov");
                }
            }
        }

        /// <param name="CUIT"></param>
        public static int ObtenerIDProveedor(string CUIT)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND Cuit=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CUIT);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProveedorDadoBaja);
                }
                else
                {
                    string ConsultaID = "SELECT CodProv FROM Proveedor WHERE Cuit=@Param1 AND Activo=1";
                    var Cmd = new SqlCommand(ConsultaID, Cnn);
                    Cmd.Parameters.AddWithValue("Param1", CUIT);
                    int CodPRov = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return CodPRov;
                }
            }
        }

        public static ProveedorEN ObtenerProveedor(int CodProv)
        {
            var Proveedor = new ProveedorEN();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CodProv);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProveedorDadoBaja);
                }
                else
                {
                    string ConsultaCarga = "SELECT CodProv,Localidad_CodLoc,Cuit,RazonSocial,CorreoElectronico," + "Calle,Numero,Piso,Departamento FROM Proveedor WHERE CodProv=@Param1";
                    var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", CodProv);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        Proveedor.CodProv = Conversions.ToInteger(Lector[0]);
                        Proveedor.CodLoc = Conversions.ToInteger(Lector[1]);
                        Proveedor.Cuit = Conversions.ToString(Lector[2]);
                        Proveedor.RazonSocial = Conversions.ToString(Lector[3]);
                        Proveedor.CorreoElectronico = Conversions.ToString(Lector[4]);
                        Proveedor.Calle = Conversions.ToString(Lector[5]);
                        Proveedor.Numero = Conversions.ToString(Lector[6]);
                        Proveedor.Piso = Conversions.ToString(Lector[7]);
                        Proveedor.Departamento = Conversions.ToString(Lector[8]);
                    }

                    return Proveedor;
                }
            }
        }

        public static List<TelefonoEN> ObtenerTelefonoProveedor(int CodProv)
        {
            var ListaTelefonos = new List<TelefonoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Proveedor WHERE Activo=1 AND CodProv=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", CodProv);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.ProveedorDadoBaja);
                }
                else
                {
                    string ConsultaTelProveeor = "SELECT CodTel,Proveedor_CodProv,Numero " + "FROM Tel_Prov WHERE Proveedor_CodProv = @Param1";
                    var Cmd = new SqlCommand(ConsultaTelProveeor, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", CodProv);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        var UnTelefono = new TelefonoEN();
                        UnTelefono.CodTel = Conversions.ToInteger(Lector[0]);
                        UnTelefono.CodEn = Conversions.ToInteger(Lector[1]);
                        UnTelefono.Numero = Conversions.ToString(Lector[2]);
                        ListaTelefonos.Add(UnTelefono);
                    }

                    return ListaTelefonos;
                }
            }
        }

        /// <param name="Cuit"></param>
        public static int ValidarProveedor(string Cuit)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExisteProv = "SELECT COUNT(*) FROM Proveedor WHERE Cuit=@Param1 AND Activo=1";
                var Cmd = new SqlCommand(ConsultaExisteProv, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Cuit);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }
    }
} // ProveedorAD