using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class UsuarioAD
    {
        public static bool AltaPatenteUsuario(int CodUsu, PatUsuEN PatUsu)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidarActivo = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1" + " AND Patente_CodPat=@Param2 AND Activo=0";
                var CmdValidar = new SqlCommand(ConsultaValidarActivo, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", CodUsu);
                CmdValidar.Parameters.AddWithValue("@Param2", PatUsu.CodPat);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaModificar = "UPDATE Usu_Pat SET Activo=1 WHERE Usuario_CodUsu=@Param1" + " AND Patente_CodPat=@Param2";
                    var CmdModificar = new SqlCommand(ConsultaModificar, Cnn);
                    CmdModificar.Parameters.AddWithValue("@Param1", CodUsu);
                    CmdModificar.Parameters.AddWithValue("@Param2", PatUsu.CodPat);
                    CmdModificar.ExecuteNonQuery();
                    return false;
                }
                else
                {
                    string ConsultaAlta = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" + "VALUES(@CodUsu,@CodPat,1,0)";
                    var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                    Cmd.Parameters.AddWithValue("@CodUsu", CodUsu);
                    Cmd.Parameters.AddWithValue("@CodPat", PatUsu.CodPat);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static void AltaUsuario(UsuarioEN Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaUsuario = "INSERT INTO Usuario(Idioma_CodIdioma," + "Usuario,Contraseña,Apellido,Nombre,CorreoElectronico," + "FechaNacimiento,CII,Activo,Bloqueado,DVH)" + "VALUES(@Idioma_CodIdioma,@Usuario,@Contraseña" + ",@Apellido,@Nombre,@CorreoElectronico,@FechaNacimiento" + ",0,1,0,0) " + "SELECT SCOPE_IDENTITY()";





                var Cmd = new SqlCommand(ConsultaUsuario, Cnn);
                Cmd.Parameters.AddWithValue("@Idioma_CodIdioma", Usuario.CodIdioma);
                Cmd.Parameters.AddWithValue("@Usuario", Usuario.Usuario);
                Cmd.Parameters.AddWithValue("@Contraseña", Usuario.Contraseña);
                Cmd.Parameters.AddWithValue("@Apellido", Usuario.Apellido);
                Cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                Cmd.Parameters.AddWithValue("@CorreoElectronico", Usuario.CorreoElectronico);
                Cmd.Parameters.AddWithValue("@FechaNacimiento", Usuario.FechaNacimiento);
                int CodigoUsuarioNuevo = Conversions.ToInteger(Cmd.ExecuteScalar());
                Usuario.CodUsu = CodigoUsuarioNuevo;
                foreach (TelefonoEN Telefono in Usuario.Telefono)
                    Datos.NegocioAD.AltaTelefono(CodigoUsuarioNuevo, Telefono, "Tel_Usu");
            }
        }

        public static bool AltaUsuarioFamilia(int Codigo, UsuFamEN UsuarioFamilia)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExistePat = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExistePat, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", UsuarioFamilia.CodFam);
                int Existe = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Existe > 0)
                {
                    string ConsultaAlta = "INSERT INTO Usu_Fam(Usuario_CodUsu,Familia_CodFam,DVH)" + "VALUES(@Param1,@Param2,0)";
                    var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Codigo);
                    Cmd.Parameters.AddWithValue("@Param2", UsuarioFamilia.CodFam);
                    Cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool AltaPatUsuDesdeFam(int CodUsu, int CodPat)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodUsu);
                Cmd.Parameters.AddWithValue("@Param2", CodPat);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                if (Resultado > 0)
                {
                    return false;
                }
                else
                {
                    string ConsultaAltaPer = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" + "VALUES(@Param1,@Param2,1,0)";
                    var CmdAltaPer = new SqlCommand(ConsultaAltaPer, Cnn);
                    CmdAltaPer.Parameters.AddWithValue("@Param1", CodUsu);
                    CmdAltaPer.Parameters.AddWithValue("@Param2", CodPat);
                    CmdAltaPer.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static void BajaUsuario(UsuarioEN Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();

                // Consultar SI Existe
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario.CodUsu);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    // Baja de Usuario
                    string ConsultaBaja = "UPDATE Usuario SET Activo=0 WHERE CodUsu=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Usuario.CodUsu);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static void BloquearUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaUsuario = "UPDATE Usuario SET Bloqueado=1 WHERE Usuario=@Param1";
                var Cmd = new SqlCommand(ConsultaUsuario, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.ExecuteNonQuery();
            }
        }

        public static List<UsuarioEN> BuscarUsuario(string campo, string texto)
        {
            var ListaUsuarios = new List<UsuarioEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                switch (campo ?? "")
                {
                    case var @case when @case == (Datos.My.Resources.ArchivoIdioma.CMBUsuario ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " + "FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                            break;
                        }

                    case var case1 when case1 == (Datos.My.Resources.ArchivoIdioma.CMBApellido ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " + "FROM Usuario WHERE Apellido LIKE '%' + @Param1 + '%' AND Activo=1";
                            break;
                        }

                    case var case2 when case2 == (Datos.My.Resources.ArchivoIdioma.CMBNombre ?? ""):
                        {
                            Cmd.CommandText = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT) " + "FROM Usuario WHERE Nombre LIKE '%' + @Param1 + '%' AND Activo=1";
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", texto);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnUsuario = new UsuarioEN();
                    UnUsuario.CodUsu = Conversions.ToInteger(Lector[0]);
                    UnUsuario.Usuario = Conversions.ToString(Lector[1]);
                    UnUsuario.Apellido = Conversions.ToString(Lector[2]);
                    UnUsuario.Nombre = Conversions.ToString(Lector[3]);
                    UnUsuario.CorreoElectronico = Conversions.ToString(Lector[4]);
                    UnUsuario.Edad = Conversions.ToInteger(Lector[5]);
                    ListaUsuarios.Add(UnUsuario);
                }
            }

            return ListaUsuarios;
        }

        public static void CambiarContraseña(string Usuario, string NuevaContraseña)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaContraseña = "UPDATE Usuario SET Contraseña=@Param1 WHERE Usuario=@Param2";
                    var Cmd = new SqlCommand(ConsultaContraseña, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", NuevaContraseña);
                    Cmd.Parameters.AddWithValue("@Param2", Usuario);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<UsuarioEN> CargarUsuario()
        {
            var ListaUsuarios = new List<UsuarioEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaUsuarios = "SELECT CodUsu,Usuario,Apellido,Nombre,CorreoElectronico,CAST(DATEDIFF(dd,CONVERT(VARCHAR(20),FechaNacimiento),CONVERT(date,GETDATE())) / 365.25 AS INT),Bloqueado" + " FROM Usuario WHERE Activo=1";
                var Cmd = new SqlCommand(ConsultaUsuarios, Cnn);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnUsuario = new UsuarioEN();
                    UnUsuario.CodUsu = Conversions.ToInteger(Lector[0]);
                    UnUsuario.Usuario = Conversions.ToString(Lector[1]);
                    UnUsuario.Apellido = Conversions.ToString(Lector[2]);
                    UnUsuario.Nombre = Conversions.ToString(Lector[3]);
                    UnUsuario.CorreoElectronico = Conversions.ToString(Lector[4]);
                    UnUsuario.Edad = Conversions.ToInteger(Lector[5]);
                    UnUsuario.Bloqueado = Conversions.ToBoolean(Lector[6]);
                    ListaUsuarios.Add(UnUsuario);
                }
            }

            return ListaUsuarios;
        }

        public static void DenegarPatenteUsuario(int Codigo, PatUsuEN PatUsu)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", Codigo);
                CmdValidar.Parameters.AddWithValue("@Param2", PatUsu.CodPat);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaBaja = "UPDATE Usu_Pat SET Activo=0 WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Codigo);
                    Cmd.Parameters.AddWithValue("@Param2", PatUsu.CodPat);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    string ConsultaAlta = "INSERT INTO Usu_Pat(Usuario_CodUsu,Patente_CodPat,Activo,DVH)" + "VALUES(@CodUsu,@CodPat,0,0)";
                    var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                    Cmd.Parameters.AddWithValue("@CodUsu", Codigo);
                    Cmd.Parameters.AddWithValue("@CodPat", PatUsu.CodPat);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DesbloquearUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaValidarActivo = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Bloqueado=1";
                    var CmdValidar = new SqlCommand(ConsultaValidarActivo, Cnn);
                    CmdValidar.Parameters.AddWithValue("@Param1", Usuario);
                    int ResultadoValidar = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                    if (ResultadoValidar > 0)
                    {
                        string ConsultaDesbloquear = "UPDATE Usuario SET Bloqueado=0,CII=0 WHERE Usuario=@Param1";
                        var Cmd = new SqlCommand(ConsultaDesbloquear, Cnn);
                        Cmd.Parameters.AddWithValue("@Param1", Usuario);
                        Cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioNoBloqueado);
                    }
                }
            }
        }

        public static void EliminarTelefonoUsuario(TelefonoEN UnTelefono)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidarTel = "SELECT COUNT(*) FROM Tel_Usu WHERE CodTel=@Param1 AND Usuario_CodUsu=@Param2";
                var CmdValidar = new SqlCommand(ConsultaValidarTel, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", UnTelefono.CodTel);
                CmdValidar.Parameters.AddWithValue("@Param2", UnTelefono.CodEn);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaEliminarTel = "DELETE FROM Tel_Usu WHERE CodTel=@Param1 AND Usuario_CodUsu=@Param2";
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

        public static bool Logueo(UsuarioEN Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaLogueo = "SELECT COUNT(*) FROM Usuario " + "WHERE Usuario=@Param1 AND Contraseña=@Param2";
                var Cmd = new SqlCommand(ConsultaLogueo, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario.Usuario);
                Cmd.Parameters.AddWithValue("@Param2", Usuario.Contraseña);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                if (Resultado > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void ModificarCIIUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCII = "UPDATE Usuario SET CII +=1 WHERE Usuario=@Param1";
                var Cmd = new SqlCommand(ConsultaCII, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.ExecuteNonQuery();
            }
        }

        public static void ModificarUsuario(UsuarioEN Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaIDUsuario = "SELECT CodUsu FROM Usuario WHERE Usuario=@Usuario";
                    var CmdIDUsuario = new SqlCommand(ConsultaIDUsuario, Cnn);
                    CmdIDUsuario.Parameters.AddWithValue("@Usuario", Usuario.Usuario);
                    int CodigoUsuario = Conversions.ToInteger(CmdIDUsuario.ExecuteScalar());
                    string ConsultaModificar = "UPDATE Usuario SET Idioma_CodIdioma=@Param1,Apellido=@Param2," + "Nombre=@Param3, FechaNacimiento=@Param6 WHERE Usuario=@Param4 AND CodUsu=@Param5";
                    var Cmd = new SqlCommand(ConsultaModificar, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Usuario.CodIdioma);
                    Cmd.Parameters.AddWithValue("@Param2", Usuario.Apellido);
                    Cmd.Parameters.AddWithValue("@Param3", Usuario.Nombre);
                    Cmd.Parameters.AddWithValue("@Param4", Usuario.Usuario);
                    Cmd.Parameters.AddWithValue("@Param5", CodigoUsuario);
                    Cmd.Parameters.AddWithValue("@Param6", Usuario.FechaNacimiento);
                    Cmd.ExecuteNonQuery();
                    foreach (TelefonoEN Telefono in Usuario.Telefono)
                        Datos.NegocioAD.ModificarTelefono(CodigoUsuario, Telefono, "Tel_Usu");
                }
            }
        }

        public static int ObtenerCIIUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExisUsuariosBD = "SELECT COUNT(*) FROM Usuario";
                var CmdExisteUsuariosBD = new SqlCommand(ConsultaExisUsuariosBD, Cnn);
                int ResultadoBD = Conversions.ToInteger(CmdExisteUsuariosBD.ExecuteScalar());
                if (ResultadoBD > 0)
                {
                    string ConsultaExisteUsuario = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1";
                    var Cmd = new SqlCommand(ConsultaExisteUsuario, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Usuario);
                    int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                    if (Resultado > 0)
                    {
                        string ConsultaBloqueadoUsuario = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param2 AND Bloqueado=1";
                        var CmdBloqueado = new SqlCommand(ConsultaBloqueadoUsuario, Cnn);
                        CmdBloqueado.Parameters.AddWithValue("@Param2", Usuario);
                        int ResultadoBloqueado = Conversions.ToInteger(CmdBloqueado.ExecuteScalar());
                        if (ResultadoBloqueado > 0)
                        {
                            throw new CriticalException(Datos.My.Resources.ArchivoIdioma.UsuarioBloqueado);
                        }
                        else
                        {
                            string ConsultaCII = "SELECT CII FROM Usuario WHERE Usuario=@Param3";
                            var CmdCii = new SqlCommand(ConsultaCII, Cnn);
                            CmdCii.Parameters.AddWithValue("@Param3", Usuario);
                            int CII = Conversions.ToInteger(CmdCii.ExecuteScalar());
                            return CII;
                        }
                    }
                    else
                    {
                        throw new CriticalException(Datos.My.Resources.ArchivoIdioma.UsuarioNoExiste);
                    }
                }
                else
                {
                    throw new CriticalException(Datos.My.Resources.ArchivoIdioma.NoExistenUsuariosBD);
                }
            }
        }

        public static int ObtenerIDUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaUsuario = "SELECT CodUsu FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                    var Cmd = new SqlCommand(ConsultaUsuario, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Usuario);
                    int Codigo = Conversions.ToInteger(Cmd.ExecuteScalar());
                    return Codigo;
                }
            }
        }

        public static List<TelefonoEN> ObtenerTelefonoUsuario(int Codigo)
        {
            var ListaTelefonos = new List<TelefonoEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Codigo);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaTelUsuario = "SELECT CodTel,Usuario_CodUsu,Numero " + "FROM Tel_Usu WHERE Usuario_CodUsu = @Param1";
                    var Cmd = new SqlCommand(ConsultaTelUsuario, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Codigo);
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

        public static UsuarioEN ObtenerUsuario(int Codigo)
        {
            var Usuario = new UsuarioEN();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Activo=1 AND CodUsu=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Codigo);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado == 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string ConsultaUsuario = "SELECT CodUsu,Idioma_CodIdioma,Usuario,Apellido,Nombre,CorreoElectronico,FechaNacimiento,Activo " + "FROM Usuario WHERE CodUsu=@Param1";
                    var Cmd = new SqlCommand(ConsultaUsuario, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Codigo);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                    {
                        Usuario.CodUsu = Conversions.ToInteger(Lector[0]);
                        Usuario.CodIdioma = Conversions.ToInteger(Lector[1]);
                        Usuario.Usuario = Conversions.ToString(Lector[2]);
                        Usuario.Apellido = Conversions.ToString(Lector[3]);
                        Usuario.Nombre = Conversions.ToString(Lector[4]);
                        Usuario.CorreoElectronico = Conversions.ToString(Lector[5]);
                        Usuario.FechaNacimiento = Conversions.ToDate(Lector[6]);
                        Usuario.Activo = Conversions.ToBoolean(Lector[7]);
                    }

                    return Usuario;
                }
            }
        }

        public static void ResetearCII(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCII = "UPDATE Usuario SET CII = 0 WHERE Usuario=@Param1";
                var Cmd = new SqlCommand(ConsultaCII, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.ExecuteNonQuery();
            }
        }

        public static int ValidarContraseña(string Usuario, string ContraseñaAnterior)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Contraseña=@Param2";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.Parameters.AddWithValue("@Param2", ContraseñaAnterior);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static int ValidarUsuario(string Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExisteUsuario = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=1";
                var Cmd = new SqlCommand(ConsultaExisteUsuario, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static int ValidarUsuFam(int Codigo, UsuFamEN UsuFam)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Codigo);
                Cmd.Parameters.AddWithValue("@Param2", UsuFam.CodFam);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static void ResetearContraseña(UsuarioEN Usuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Usuario WHERE Usuario=@Param1 AND Activo=0";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Usuario.Usuario);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado > 0)
                {
                    throw new WarningException(Datos.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
                else
                {
                    string Consulta = "UPDATE Usuario SET Contraseña=@Param1 WHERE Usuario=@Param2";
                    var Cmd = new SqlCommand(Consulta, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Usuario.Contraseña);
                    Cmd.Parameters.AddWithValue("@Param2", Usuario.Usuario);
                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool VerificarPatentesUsuario(int CodPat)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT COUNT(*) AS CNT " + "FROM ( " + " " + "SELECT U.CodUsu " + "FROM Usuario AS U INNER JOIN Usu_Pat AS UP ON U.CodUsu = UP.Usuario_CodUsu " + "WHERE UP.Patente_CodPat = @Param1 and UP.Activo = 1 " + " " + "UNION " + " " + "SELECT UF.Usuario_CodUsu AS CodUsu " + "FROM Usu_Fam AS UF inner join Familia AS F ON UF.Familia_CodFam = F.CodFam " + "INNER JOIN Fam_Pat AS FP ON FP.Familia_CodFam = f.CodFam " + "WHERE FP.Patente_CodPat = @Param1 " + " " + ") AS T ";













                var Cmd = new SqlCommand(Consulta, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodPat);
                int CantidadUsuarios = Conversions.ToInteger(Cmd.ExecuteScalar());
                if (CantidadUsuarios > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<string> ObtenerUsuariosErrorIntegridad()
        {
            var ListaUsuarios = new List<string>();
            string Usuario;
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT DISTINCT U.Usuario " + "FROM Usuario U " + "INNER JOIN Usu_Pat UP ON U.CodUsu = UP.Usuario_CodUsu " + "WHERE U.Usuario IN (SELECT U1.Usuario From Usuario U1 INNER JOIN Usu_Pat UP1 ON U1.CodUsu = UP1.Usuario_CodUsu WHERE UP1.Activo=1 AND (UP1.Patente_CodPat = 32 OR UP1.Patente_CodPat = 39))";


                var Cmd = new SqlCommand(Consulta, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    Usuario = Conversions.ToString(Lector[0]);
                    ListaUsuarios.Add(Usuario);
                }
            }

            return ListaUsuarios;
        }

        public static List<PatUsuEN> ObtenerPatentesUsuario(int CodUsu)
        {
            var ListaPatUsu = new List<PatUsuEN>();
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaUsuFam = "SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1";
                var CmdUsuFam = new SqlCommand(ConsultaUsuFam, cnn);
                CmdUsuFam.Parameters.AddWithValue("@Param1", CodUsu);
                var Lector = CmdUsuFam.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatUsu = new PatUsuEN();
                    UnaPatUsu.CodUsu = CodUsu;
                    UnaPatUsu.CodPat = Conversions.ToInteger(Lector[0]);
                    ListaPatUsu.Add(UnaPatUsu);
                }

                return ListaPatUsu;
            }
        }

        public static void EliminarPatentesUsuario(PatUsuEN UnaPatUsu)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaPatUsu = "DELETE FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                var CmdUsuPat = new SqlCommand(ConsultaPatUsu, cnn);
                CmdUsuPat.Parameters.AddWithValue("@Param1", UnaPatUsu.CodUsu);
                CmdUsuPat.Parameters.AddWithValue("@Param2", UnaPatUsu.CodPat);
                CmdUsuPat.ExecuteNonQuery();
            }
        }
    }
} // UsuarioAD