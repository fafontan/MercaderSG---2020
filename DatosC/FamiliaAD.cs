using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using EntidadesC;
using ExcepcionesC;
using Microsoft.VisualBasic.CompilerServices;

namespace DatosC
{
    public class FamiliaAD
    {
        public static void AltaFamilia(FamiliaEN Familia)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaAlta = "INSERT INTO Familia(Descripcion)VALUES(@Descripcion)";
                var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                Cmd.Parameters.AddWithValue("@Descripcion", Familia.Descripcion);
                Cmd.ExecuteNonQuery();
            }
        }

        /// <param name="FamiliaPatente"></param>
        public static void AltaFamiliaPatente(FamPatEN FamiliaPatente)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", FamiliaPatente.CodFam);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaAlta = "INSERT INTO Fam_Pat(Familia_CodFam,Patente_CodPat,DVH)" + "VALUES(@Param1,@Param2,0)";
                    var Cmd = new SqlCommand(ConsultaAlta, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", FamiliaPatente.CodFam);
                    Cmd.Parameters.AddWithValue("@Param2", FamiliaPatente.CodPat);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                    throw new WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                }
            }
        }

        /// <param name="Familia"></param>
        public static void BajaFamilia(FamiliaEN Familia)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Familia.CodFam);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaBaja = "DELETE FROM Familia WHERE CodFam=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Familia.CodFam);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                }
            }
        }

        public static List<FamiliaEN> CargarFamilia()
        {
            var ListaFamilia = new List<FamiliaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodFam,Descripcion FROM Familia";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaFamilia = new FamiliaEN();
                    UnaFamilia.CodFam = Conversions.ToInteger(Lector[0]);
                    UnaFamilia.Descripcion = Conversions.ToString(Lector[1]);
                    ListaFamilia.Add(UnaFamilia);
                }
            }

            return ListaFamilia;
        }

        public static List<FamiliaEN> CargarFamiliaConPatentes()
        {
            var ListaFamilia = new List<FamiliaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT DISTINCT CodFam,Descripcion " + "FROM Familia " + "INNER JOIN Fam_Pat ON Familia.CodFam = Fam_Pat.Familia_CodFam";

                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaFamilia = new FamiliaEN();
                    UnaFamilia.CodFam = Conversions.ToInteger(Lector[0]);
                    UnaFamilia.Descripcion = Conversions.ToString(Lector[1]);
                    ListaFamilia.Add(UnaFamilia);
                }
            }

            return ListaFamilia;
        }

        public static void ModificarFamilia(FamiliaEN Familia)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Familia.CodFam);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaModificar = "UPDATE Familia SET Descripcion=@Param1 WHERE CodFam=@Param2";
                    var Cmd = new SqlCommand(ConsultaModificar, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Familia.Descripcion);
                    Cmd.Parameters.AddWithValue("@Param2", Familia.CodFam);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                }
            }
        }

        public static FamiliaEN ObtenerFamilia(string Descripcion)
        {
            var Familia = new FamiliaEN();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaExiste = "SELECT COUNT(*) FROM Familia WHERE Descripcion=@Param1";
                var CmdExiste = new SqlCommand(ConsultaExiste, Cnn);
                CmdExiste.Parameters.AddWithValue("@Param1", Descripcion);
                int Resultado = Conversions.ToInteger(CmdExiste.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaIDFam = "SELECT CodFam FROM Familia WHERE Descripcion=@Param1";
                    var Cmd = new SqlCommand(ConsultaIDFam, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", Descripcion);
                    var Lector = Cmd.ExecuteReader();
                    while (Lector.Read())
                        Familia.CodFam = Conversions.ToInteger(Lector[0]);
                    Familia.Descripcion = Descripcion;
                }
                else
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                   // throw new WarningException(Datos.My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                }
            }

            return Familia;
        }

        public static int ValidarPatente(FamPatEN FamPat)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", FamPat.CodFam);
                Cmd.Parameters.AddWithValue("@Param2", FamPat.CodPat);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        /// <param name="Descripcion"></param>
        public static int ValidarFamilia(string Descripcion)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Familia WHERE Descripcion=@Param1";
                var Cmd = new SqlCommand(ConsultaValidar, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Descripcion);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static int ObtenerIDFamilia(string Fam)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaFamilia = "SELECT CodFam FROM Familia WHERE Descripcion=@Param1";
                var Cmd = new SqlCommand(ConsultaFamilia, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Fam);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static void BajaFamiliaPatente(int CodFam, FamPatEN UnaFamPat)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaValidar = "SELECT COUNT(*) FROM Familia WHERE CodFam=@Param1";
                var CmdValidar = new SqlCommand(ConsultaValidar, Cnn);
                CmdValidar.Parameters.AddWithValue("@Param1", CodFam);
                int Resultado = Conversions.ToInteger(CmdValidar.ExecuteScalar());
                if (Resultado > 0)
                {
                    string ConsultaBaja = "DELETE FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", CodFam);
                    Cmd.Parameters.AddWithValue("@Param2", UnaFamPat.CodPat);
                    Cmd.ExecuteNonQuery();
                }
                else
                {
                    //throw new WarningException(Datos.My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                    throw new WarningException(My.Resources.ArchivoIdioma.FamiliaDadaBaja);
                }
            }
        }

        public static int VerificarPatentesFamilia(int CodFam, int CodPat)
        {
            int Resultado;
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaPatFam = "WITH Patentes AS ( " + "	SELECT P.CodPat, UP.Activo " + "	FROM Patente P, Usuario U, Usu_Pat UP " + "	WHERE P.CodPat=UP.Patente_CodPat AND P.CodPat=@Param1 " + "	AND UP.Usuario_CodUsu=U.CodUsu " + ") " + "SELECT " + "(SELECT COUNT(*) " + "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " + "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " + "	AND UF.Familia_CodFam=F.CodFam AND UF.Usuario_CodUsu = U.CodUsu " + "	AND P.CodPat NOT IN (SELECT CodPat FROM Patentes WHERE Activo = 0) " + "	AND P.CodPat=@Param1  AND F.CodFam <>  @Param2 " + ") " + "+ " + "(SELECT COUNT(*) FROM Patentes WHERE Activo <> 0) " + "AS Total";















                var Cmd = new SqlCommand(ConsultaPatFam, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodPat);
                Cmd.Parameters.AddWithValue("@Param2", CodFam);
                Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
            }

            return Resultado;
        }

        public static List<FamPatEN> ObtenerFamiliaPatente(int CodFam)
        {
            var ListaFamPat = new List<FamPatEN>();
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaFamPat = "SELECT Patente_CodPat FROM Fam_Pat WHERE Familia_CodFam=@Param1";
                var CmdFamPat = new SqlCommand(ConsultaFamPat, cnn);
                CmdFamPat.Parameters.AddWithValue("@Param1", CodFam);
                var Lector = CmdFamPat.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaFamPat = new FamPatEN();
                    UnaFamPat.CodFam = CodFam;
                    UnaFamPat.CodPat = Conversions.ToInteger(Lector[0]);
                    ListaFamPat.Add(UnaFamPat);
                }

                return ListaFamPat;
            }
        }

        public static void EliminarFamiliaPatente(FamPatEN UnaFamPat)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaFam_Pat = "DELETE FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2";
                var CmdFamPat = new SqlCommand(ConsultaFam_Pat, cnn);
                CmdFamPat.Parameters.AddWithValue("@Param1", UnaFamPat.CodFam);
                CmdFamPat.Parameters.AddWithValue("@Param2", UnaFamPat.CodPat);
                CmdFamPat.ExecuteNonQuery();
            }
        }

        public static List<UsuFamEN> ObtenerUsuarioFamilia(int CodFam)
        {
            var ListaUsuFam = new List<UsuFamEN>();
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaUsuFam = "SELECT Usuario_CodUsu FROM Usu_Fam WHERE Familia_CodFam=@Param1";
                var CmdUsuFam = new SqlCommand(ConsultaUsuFam, cnn);
                CmdUsuFam.Parameters.AddWithValue("@Param1", CodFam);
                var Lector = CmdUsuFam.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaUsuFam = new UsuFamEN();
                    UnaUsuFam.CodUsu = Conversions.ToInteger(Lector[0]);
                    UnaUsuFam.CodFam = CodFam;
                    ListaUsuFam.Add(UnaUsuFam);
                }

                return ListaUsuFam;
            }
        }

        public static void EliminarUsuarioFamilia(UsuFamEN UnaUsuFam)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaUsu_Fam = "DELETE FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2";
                var CmdUsuFam = new SqlCommand(ConsultaUsu_Fam, cnn);
                CmdUsuFam.Parameters.AddWithValue("@Param1", UnaUsuFam.CodUsu);
                CmdUsuFam.Parameters.AddWithValue("@Param2", UnaUsuFam.CodFam);
                CmdUsuFam.ExecuteNonQuery();
            }
        }

        public static List<UsuFamEN> ObtenerFamiliaUsuario(int CodUsu)
        {
            var ListaUsuFam = new List<UsuFamEN>();
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaUsuFam = "SELECT Familia_CodFam FROM Usu_Fam WHERE Usuario_CodUsu=@Param1";
                var CmdUsuFam = new SqlCommand(ConsultaUsuFam, cnn);
                CmdUsuFam.Parameters.AddWithValue("@Param1", CodUsu);
                var Lector = CmdUsuFam.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaUsuFam = new UsuFamEN();
                    UnaUsuFam.CodUsu = CodUsu;
                    UnaUsuFam.CodFam = Conversions.ToInteger(Lector[0]);
                    ListaUsuFam.Add(UnaUsuFam);
                }

                return ListaUsuFam;
            }
        }
    }
} // FamiliaAD