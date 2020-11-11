using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class PatenteAD
    {
        public static List<PatenteEN> CargarPatente()
        {
            var ListaPatentes = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaPatentes = "SELECT CodPat,Descripcion FROM Patente";
                var Cmd = new SqlCommand(ConsultaPatentes, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatentes.Add(UnaPatente);
                }
            }

            return ListaPatentes;
        }

        public static List<PatenteEN> CargarPatente(int CodUsu)
        {
            var ListaPatente = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodPat, Descripcion " + "FROM Patente " + "WHERE CodPat NOT IN (SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1) " + "AND CodPat NOT IN (SELECT Patente_CodPat FROM Fam_Pat FP INNER JOIN Usu_Fam UF ON FP.Familia_CodFam=UF.Familia_CodFam AND UF.Usuario_CodUsu=@Param1)";


                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodUsu);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatente.Add(UnaPatente);
                }
            }

            return ListaPatente;
        }

        public static DataTable ObtenerPatenteUsuario(int CodUsu)
        {
            var dtPatUsu = new DataTable();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaPatenteUsuario = "WITH Patentes AS ( " + "	SELECT P.CodPat, P.Descripcion, UP.Activo " + "	FROM Patente P, Usuario U, Usu_Pat UP " + "	WHERE P.CodPat=UP.Patente_CodPat AND U.CodUsu=UP.Usuario_CodUsu " + "	AND U.CodUsu=@Param1 " + ") " + "SELECT P.CodPat, P.Descripcion, 1 AS Activo " + "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " + "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " + "	AND UF.Usuario_CodUsu=U.CodUsu AND UF.Familia_CodFam=F.CodFam " + "	AND U.CodUsu=@Param1 AND P.CodPat NOT IN (SELECT CodPat FROM Patentes) " + "UNION " + "SELECT * FROM Patentes WHERE Activo <> 0 ORDER BY CodPat ASC";











                var Cmd = new SqlCommand(ConsultaPatenteUsuario, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodUsu);
                var da = new SqlDataAdapter(Cmd);
                da.Fill(dtPatUsu);
                return dtPatUsu;
            }
        }

        public static List<PatenteEN> CargarPatenteUsuario(int CodUsu)
        {
            var ListaPatente = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "WITH Patentes AS ( " + "	SELECT P.CodPat, P.Descripcion, UP.Activo " + "	FROM Patente P, Usuario U, Usu_Pat UP " + "	WHERE P.CodPat=UP.Patente_CodPat AND U.CodUsu=UP.Usuario_CodUsu " + "	AND U.CodUsu=@Param1 " + ") " + "SELECT P.CodPat, P.Descripcion, 1 AS Activo " + "FROM Usuario U, Usu_Fam UF, Familia F, Fam_Pat FP, Patente P " + "WHERE FP.Familia_CodFam=F.CodFam AND FP.Patente_CodPat=P.CodPat " + "	AND UF.Usuario_CodUsu=U.CodUsu AND UF.Familia_CodFam=F.CodFam " + "	AND U.CodUsu=@Param1 AND P.CodPat NOT IN (SELECT CodPat FROM Patentes) " + "UNION " + "SELECT * FROM Patentes WHERE Activo <> 0";











                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodUsu);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatente.Add(UnaPatente);
                }
            }

            return ListaPatente;
        }

        public static List<PatenteEN> CargarPatentesFamilia(int CodFam)
        {
            var ListaPatente = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT P.CodPat,P.Descripcion FROM Patente P INNER JOIN Fam_Pat FP ON P.CodPat=FP.Patente_CodPat WHERE FP.Familia_CodFam=@Param1";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodFam);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatente.Add(UnaPatente);
                }
            }

            return ListaPatente;
        }

        public static List<PatenteEN> CargarNoPatentesFamilia(int CodFam)
        {
            var ListaPatente = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodPat, Descripcion FROM Patente WHERE CodPat NOT IN (SELECT Patente_CodPat FROM Fam_Pat WHERE Familia_CodFam=@Param1)";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodFam);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatente.Add(UnaPatente);
                }
            }

            return ListaPatente;
        }

        public static List<PatenteEN> CargarPatenteDenegadasUsuario(int CodUsu)
        {
            var ListaPatente = new List<PatenteEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodPat, Descripcion FROM Patente WHERE CodPat IN (SELECT Patente_CodPat FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Activo=0)";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodUsu);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = Conversions.ToInteger(Lector[0]);
                    UnaPatente.Descripcion = Conversions.ToString(Lector[1]);
                    ListaPatente.Add(UnaPatente);
                }
            }

            return ListaPatente;
        }

        public static bool ObtenerPatentesFamilia(int CodFam)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaPat = "SELECT COUNT(*) FROM Fam_Pat WHERE Familia_CodFam=@Param1";
                var Cmd = new SqlCommand(ConsultaPat, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", CodFam);
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
    }
} // PatenteAD