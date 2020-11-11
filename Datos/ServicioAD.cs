using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class ServicioAD
    {
        public static string CalcularDVH(DVHEN DVH)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                string Cadena;
                var ListaCodigos = new List<int>();
                switch (DVH.Tabla ?? "")
                {
                    case "Usuario":
                        {
                            string CadenaUsuarioDV = "SELECT Usuario+Contraseña+CAST(CII AS VARCHAR(1))+CAST(Bloqueado AS VARCHAR(1))+CAST(Activo AS VARCHAR(1)) " + "FROM Usuario " + "WHERE CodUsu=@Param1";

                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaUsuarioDV;
                            break;
                        }

                    case "Usu_Fam":
                        {
                            Cadena = DVH.CodReg.ToString() + DVH.CodAux.ToString();
                            return Cadena;
                        }

                    case "Fam_Pat":
                        {
                            Cadena = DVH.CodReg.ToString() + DVH.CodAux.ToString();
                            return Cadena;
                        }

                    case "Usu_Pat":
                        {
                            string ConsultaPat = "SELECT CAST(Activo AS VARCHAR(1)) FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaPat;
                            Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            string Resultado = Conversions.ToString(Cmd.ExecuteScalar());
                            Cadena = DVH.CodReg.ToString() + DVH.CodAux.ToString() + Resultado;
                            return Cadena;
                        }

                    case "Bitacora":
                        {
                            string CadenaBitacoraDV = "SELECT CAST(Fecha AS VARCHAR(100))+Descripcion+Criticidad+Usuario FROM Bitacora WHERE CodBit=@Param1";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaBitacoraDV;
                            break;
                        }

                    case "Cliente":
                        {
                            string CadenaClienteDV = "SELECT Cuit+Calle+Numero+CAST(Activo AS VARCHAR(10)) FROM Cliente WHERE CodCli=@Param1";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaClienteDV;
                            break;
                        }

                    case "Producto":
                        {
                            string CadenaProductoDV = "SELECT Nombre+CAST(Cantidad AS VARCHAR(100))+CAST(Activo AS VARCHAR(10)) " + "FROM Producto " + "WHERE CodProd=@Param1";

                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaProductoDV;
                            break;
                        }

                    case "Historico_Precio":
                        {
                            string CadenaHist_PrecioDV = "SELECT CAST(Producto_CodProd AS VARCHAR(100))+CAST(Precio AS VARCHAR(100))+CAST(FechaDesde AS VARCHAR(100)) " + "FROM Historico_Precio " + "WHERE CodHist=@Param1";

                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaHist_PrecioDV;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg);
                Cadena = Conversions.ToString(Cmd.ExecuteScalar());
                return Cadena;
            }
        }

        public static int CalcularDVV(DVHEN DVH)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaCantReg = "SELECT COUNT(*) FROM " + DVH.Tabla;
                var CmdCant = new SqlCommand(ConsultaCantReg, cnn);
                int Cantidad = Conversions.ToInteger(CmdCant.ExecuteScalar());
                if (Cantidad > 0)
                {
                    string ConsultaGralDVH = "SELECT SUM(DVH) FROM " + DVH.Tabla;
                    var CmdDVH = new SqlCommand(ConsultaGralDVH, cnn);
                    int SumaDVH = Conversions.ToInteger(CmdDVH.ExecuteScalar());
                    return SumaDVH;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static int DetectarIdioma(int IDUsuario)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaIdiomaUsu = "SELECT Idioma_CodIdioma FROM Usuario U " + "WHERE U.CodUsu=@Param1";
                var Cmd = new SqlCommand(ConsultaIdiomaUsu, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", IDUsuario);
                int CodIdioma = Conversions.ToInteger(Cmd.ExecuteScalar());
                return CodIdioma;
            }
        }

        public static List<string> EjecutarBackup(string Destino, int volumen)
        {
            int Resultado;
            var ListaArchivos = new List<string>();
            string CadenaArchivos;
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BDMaster"].ToString()))
            {
                Cnn.Open();
                var FechaActual = DateAndTime.Today.Date;
                string FechaStr;
                FechaStr = "Fecha" + FechaActual.ToString("dd-MM-yyyy");
                string ConsultaBack;
                if (volumen == 1)
                {
                    ConsultaBack = "BACKUP DATABASE Mercader TO DISK = '" + Destino + @"\Mercader" + FechaStr + ".bak'";
                    CadenaArchivos = Destino + @"\Mercader" + FechaStr + ".bak";
                    ListaArchivos.Add(CadenaArchivos);
                }
                else
                {
                    ConsultaBack = "BACKUP DATABASE Mercader TO DISK = '" + Destino + @"\MercaderParte01" + FechaStr + ".bak'";
                    CadenaArchivos = Destino + @"\MercaderParte01" + FechaStr + ".bak";
                    ListaArchivos.Add(CadenaArchivos);
                    for (int i = 1, loopTo = volumen - 1; i <= loopTo; i++)
                    {
                        string Parte = "Parte" + (i + 1).ToString("00");
                        ConsultaBack += string.Concat(", DISK = '" + Destino + @"\Mercader" + Parte + "." + FechaStr + ".bak'");
                        CadenaArchivos = Destino + @"\Mercader" + Parte + "." + FechaStr + ".bak";
                        ListaArchivos.Add(CadenaArchivos);
                    }
                }

                var Cmd = new SqlCommand(ConsultaBack, Cnn);
                Resultado = Cmd.ExecuteNonQuery();
                if (Resultado < 0)
                {
                    return ListaArchivos;
                }
                else
                {
                    return ListaArchivos;
                }
            }
        }

        public static bool EjecutarRestore(List<string> Origen)
        {
            int Resultado;
            SqlConnection.ClearAllPools();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BDMaster"].ToString()))
            {
                Cnn.Open();
                string ConsultaRestore;
                if (Origen.Count == 1)
                {
                    ConsultaRestore = "IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Mercader') " + "CREATE DATABASE [Mercader] " + "USE master " + "ALTER DATABASE Mercader SET SINGLE_USER WITH ROLLBACK IMMEDIATE " + "RESTORE DATABASE Mercader FROM DISK='" + Origen[0] + "' WITH REPLACE " + "ALTER DATABASE Mercader SET MULTI_USER";




                }
                else
                {
                    ConsultaRestore = "IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Mercader') " + "CREATE DATABASE [Mercader] " + "USE master " + "ALTER DATABASE Mercader SET SINGLE_USER WITH ROLLBACK IMMEDIATE " + "RESTORE DATABASE Mercader FROM DISK='" + Origen[0] + "'";



                    foreach (string ruta in Origen)
                    {
                        if (!((ruta ?? "") == (Origen[0] ?? "")))
                        {
                            ConsultaRestore += string.Concat(", DISK = '" + ruta + "'");
                        }
                    }

                    ConsultaRestore += string.Concat(" WITH REPLACE " + "ALTER DATABASE Mercader SET MULTI_USER");
                }

                var Cmd = new SqlCommand(ConsultaRestore, Cnn);
                Resultado = Cmd.ExecuteNonQuery();
                if (Resultado < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int GrabarDVH(DVHEN DVH, int ValorDVH)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                var Cmd = new SqlCommand();
                var ListaCodigos = new List<int>();
                int DVHAntiguo = 0;
                switch (DVH.Tabla ?? "")
                {
                    case "Usuario":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Usuario WHERE CodUsu=@Param1";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string CadenaUsuarioDV = "UPDATE Usuario SET DVH=@Param1 WHERE CodUsu=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaUsuarioDV;
                            break;
                        }

                    case "Usu_Fam":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string ConsultaUpdate = "UPDATE Usu_Fam SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Familia_CodFam=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux);
                            break;
                        }

                    case "Fam_Pat":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string ConsultaUpdate = "UPDATE Fam_Pat SET DVH=@Param1 WHERE Familia_CodFam=@Param2 AND Patente_CodPat=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux);
                            break;
                        }

                    case "Usu_Pat":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string ConsultaUpdate = "UPDATE Usu_Pat SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Patente_CodPat=@Param3";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", DVH.CodAux);
                            break;
                        }

                    case "Bitacora":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Bitacora WHERE CodBit=@Param1";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string CadenaBitacoraDV = "UPDATE Bitacora SET DVH=@Param1 WHERE CodBit=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaBitacoraDV;
                            break;
                        }

                    case "Cliente":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Cliente WHERE CodCli=@Param1";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string CadenaClienteDV = "UPDATE Cliente SET DVH=@Param1 WHERE CodCli=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaClienteDV;
                            break;
                        }

                    case "Producto":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Producto WHERE CodProd=@Param1";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string CadenaProductoDV = "UPDATE Producto SET DVH=@Param1 WHERE CodProd=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaProductoDV;
                            break;
                        }

                    case "Historico_Precio":
                        {
                            string ConsultaDVHAnterior = "SELECT DVH FROM Historico_Precio WHERE Producto_CodProd=@Param1";
                            var CmdDVHAnterior = new SqlCommand(ConsultaDVHAnterior, Cnn);
                            CmdDVHAnterior.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            DVHAntiguo = Conversions.ToInteger(CmdDVHAnterior.ExecuteScalar());
                            string CadenaHist_PrecioDV = "UPDATE Historico_Precio SET DVH=@Param1 WHERE CodHist=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = CadenaHist_PrecioDV;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", ValorDVH);
                Cmd.Parameters.AddWithValue("@Param2", DVH.CodReg);
                Cmd.ExecuteNonQuery();
                return DVHAntiguo;
            }
        }

        public static List<IdiomaEN> ListarIdiomas()
        {
            var ListaIdiomas = new List<IdiomaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaIdioma = "SELECT * FROM Idioma";
                var Cmd = new SqlCommand(ConsultaIdioma, Cnn);
                SqlDataReader Lector;
                Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnIdioma = new IdiomaEN();
                    UnIdioma.CodIdioma = Conversions.ToInteger(Lector[0]);
                    UnIdioma.Descripcion = Conversions.ToString(Lector[1]);
                    ListaIdiomas.Add(UnIdioma);
                }
            }

            return ListaIdiomas;
        }

        public static List<DVHEN> ObtenerRegistros(DVHEN DVV)
        {
            var ListaRegTablas = new List<DVHEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                switch (DVV.Tabla ?? "")
                {
                    case "Usu_Fam":
                        {
                            string ConsultaRegUsuFam = "SELECT Usuario_CodUsu,Familia_CodFam FROM Usu_fam";
                            var CmdUsuFam = new SqlCommand(ConsultaRegUsuFam, Cnn);
                            var LectorUsuFam = CmdUsuFam.ExecuteReader();
                            while (LectorUsuFam.Read())
                            {
                                var FilaUsuFam = new DVHEN();
                                FilaUsuFam.CodReg = Conversions.ToInteger(LectorUsuFam[0]);
                                FilaUsuFam.CodAux = Conversions.ToInteger(LectorUsuFam[1]);
                                ListaRegTablas.Add(FilaUsuFam);
                            }

                            return ListaRegTablas;
                        }

                    case "Fam_Pat":
                        {
                            string ConsultaRegFam_Pat = "SELECT Familia_CodFam,Patente_CodPat FROM Fam_Pat";
                            var CmdFamPat = new SqlCommand(ConsultaRegFam_Pat, Cnn);
                            var LectorFamPat = CmdFamPat.ExecuteReader();
                            while (LectorFamPat.Read())
                            {
                                var FilaFamPat = new DVHEN();
                                FilaFamPat.CodReg = Conversions.ToInteger(LectorFamPat[0]);
                                FilaFamPat.CodAux = Conversions.ToInteger(LectorFamPat[1]);
                                ListaRegTablas.Add(FilaFamPat);
                            }

                            return ListaRegTablas;
                        }

                    case "Usu_Pat":
                        {
                            string ConsultaRegUsuPat = "SELECT Usuario_CodUsu,Patente_CodPat,CAST(Activo AS VARCHAR(1)) FROM Usu_Pat";
                            var CmdUsuPat = new SqlCommand(ConsultaRegUsuPat, Cnn);
                            var LectorUsuPat = CmdUsuPat.ExecuteReader();
                            while (LectorUsuPat.Read())
                            {
                                var FilaUsuPat = new DVHEN();
                                FilaUsuPat.CodReg = Conversions.ToInteger(LectorUsuPat[0]);
                                FilaUsuPat.CodAux = Conversions.ToInteger(LectorUsuPat[1]);
                                ListaRegTablas.Add(FilaUsuPat);
                            }

                            return ListaRegTablas;
                        }
                }

                string ConsultaRegistros = "SELECT " + DVV.Columna + " FROM " + DVV.Tabla;
                var Cmd = new SqlCommand(ConsultaRegistros, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var CodReg = new DVHEN();
                    CodReg.CodReg = Conversions.ToInteger(Lector[0]);
                    ListaRegTablas.Add(CodReg);
                }
            }

            return ListaRegTablas;
        }

        public static int ObtenerDVHRegistro(DVHEN DVH)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaDVH;
                var Cmd = new SqlCommand();
                int ValorDVH;
                switch (DVH.Tabla ?? "")
                {
                    case "Usu_Fam":
                        {
                            ConsultaDVH = "SELECT DVH FROM Usu_Fam WHERE Usuario_CodUsu=@Param1 AND Familia_CodFam=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaDVH;
                            Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            ValorDVH = Conversions.ToInteger(Cmd.ExecuteScalar());
                            return ValorDVH;
                        }

                    case "Fam_Pat":
                        {
                            ConsultaDVH = "SELECT DVH FROM Fam_Pat WHERE Familia_CodFam=@Param1 AND Patente_CodPat=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaDVH;
                            Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            ValorDVH = Conversions.ToInteger(Cmd.ExecuteScalar());
                            return ValorDVH;
                        }

                    case "Usu_Pat":
                        {
                            ConsultaDVH = "SELECT DVH FROM Usu_Pat WHERE Usuario_CodUsu=@Param1 AND Patente_CodPat=@Param2";
                            Cmd.Connection = Cnn;
                            Cmd.CommandText = ConsultaDVH;
                            Cmd.Parameters.AddWithValue("@Param1", DVH.CodReg);
                            Cmd.Parameters.AddWithValue("@Param2", DVH.CodAux);
                            ValorDVH = Conversions.ToInteger(Cmd.ExecuteScalar());
                            return ValorDVH;
                        }
                }

                ConsultaDVH = "SELECT DVH FROM " + DVH.Tabla + " WHERE " + DVH.Columna + " = " + DVH.CodReg;
                Cmd.Connection = Cnn;
                Cmd.CommandText = ConsultaDVH;
                ValorDVH = Conversions.ToInteger(Cmd.ExecuteScalar());
                return ValorDVH;
            }
        }

        public static bool ExisteRegistroIntegridad(string Cadena)
        {
            int Resultado;
            var FechaActual = DateTime.Now;
            string FechaStr;
            FechaStr = FechaActual.ToString("dd/MM/yyyy");
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string Consulta = "SELECT COUNT(*) FROM Bitacora WHERE Descripcion=@Param1 AND CONVERT(VARCHAR(10),Fecha,103) LIKE @Param2";
                var Cmd = new SqlCommand(Consulta, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Cadena);
                Cmd.Parameters.AddWithValue("@Param2", FechaStr);
                Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
            }

            if (Resultado > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GrabarDVV(DVVEN DVVDatosBitacora)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                switch (DVVDatosBitacora.TipoAccion ?? "")
                {
                    case "Alta":
                        {
                            string ConsultaDVV = "UPDATE DVV SET DVV+=@Param1 WHERE Tabla=@Param2";
                            var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                            CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH);
                            CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla);
                            CmdDVV.ExecuteNonQuery();
                            break;
                        }

                    case "Baja Modificar":
                        {
                            // Restarle DVV
                            string ConsultaDVVMenos = "UPDATE DVV SET DVV-=@Param1 WHERE Tabla=@Param2";
                            var CmdDVVMenos = new SqlCommand(ConsultaDVVMenos, cnn);
                            CmdDVVMenos.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVHAntiguo);
                            CmdDVVMenos.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla);
                            CmdDVVMenos.ExecuteNonQuery();

                            // NuevoDVV
                            string ConsultaDVV = "UPDATE DVV SET DVV+=@Param1 WHERE Tabla=@Param2";
                            var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                            CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH);
                            CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla);
                            CmdDVV.ExecuteNonQuery();
                            break;
                        }

                    case "Eliminar":
                        {
                            string ConsultaDVV = "UPDATE DVV SET DVV-=@Param1 WHERE Tabla=@Param2";
                            var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                            CmdDVV.Parameters.AddWithValue("@Param1", DVVDatosBitacora.ValorDVH);
                            CmdDVV.Parameters.AddWithValue("@Param2", DVVDatosBitacora.Tabla);
                            CmdDVV.ExecuteNonQuery();
                            break;
                        }
                }
            }
        }

        public static int ObtenerDVVTabla(DVHEN DVHDatos)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaDVV = "SELECT DVV FROM DVV WHERE Tabla=@Param1";
                var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                CmdDVV.Parameters.AddWithValue("@Param1", DVHDatos.Tabla);
                int Resultado = Conversions.ToInteger(CmdDVV.ExecuteScalar());
                return Resultado;
            }
        }

        public static void RecalcularDVV(string Tabla)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                string ConsultaCantReg = "SELECT COUNT(*) FROM " + Tabla;
                var CmdCant = new SqlCommand(ConsultaCantReg, cnn);
                int Cantidad = Conversions.ToInteger(CmdCant.ExecuteScalar());
                if (Cantidad > 0)
                {
                    string ConsultaSum = "SELECT SUM(DVH) FROM " + Tabla;
                    var CmdSum = new SqlCommand(ConsultaSum, cnn);
                    int ValorSum = Conversions.ToInteger(CmdSum.ExecuteScalar());
                    string ConsultaDVV = "UPDATE DVV SET DVV=@Param1 WHERE Tabla=@Param2";
                    var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                    CmdDVV.Parameters.AddWithValue("@Param1", ValorSum);
                    CmdDVV.Parameters.AddWithValue("@Param2", Tabla);
                    CmdDVV.ExecuteNonQuery();
                }
                else
                {
                    string ConsultaDVV = "UPDATE DVV SET DVV=0 WHERE Tabla=@Param1";
                    var CmdDVV = new SqlCommand(ConsultaDVV, cnn);
                    CmdDVV.Parameters.AddWithValue("@Param1", Tabla);
                    CmdDVV.ExecuteNonQuery();
                }
            }
        }

        public static void RecalcularDVH(string Tabla, int CodReg, int CodAux, int DVH)
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                cnn.Open();
                var Cmd = new SqlCommand();
                switch (Tabla ?? "")
                {
                    case "Usuario":
                        {
                            string CadenaUsuarioDV = "UPDATE Usuario SET DVH=@Param1 WHERE CodUsu=@Param2";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = CadenaUsuarioDV;
                            break;
                        }

                    case "Usu_Fam":
                        {
                            string ConsultaUpdate = "UPDATE Usu_Fam SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Familia_CodFam=@Param3";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", CodAux);
                            break;
                        }

                    case "Fam_Pat":
                        {
                            string ConsultaUpdate = "UPDATE Fam_Pat SET DVH=@Param1 WHERE Familia_CodFam=@Param2 AND Patente_CodPat=@Param3";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", CodAux);
                            break;
                        }

                    case "Usu_Pat":
                        {
                            string ConsultaUpdate = "UPDATE Usu_Pat SET DVH=@Param1 WHERE Usuario_CodUsu=@Param2 AND Patente_CodPat=@Param3";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = ConsultaUpdate;
                            Cmd.Parameters.AddWithValue("@Param3", CodAux);
                            break;
                        }

                    case "Bitacora":
                        {
                            string CadenaBitacoraDV = "UPDATE Bitacora SET DVH=@Param1 WHERE CodBit=@Param2";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = CadenaBitacoraDV;
                            break;
                        }

                    case "Cliente":
                        {
                            string CadenaClienteDV = "UPDATE Cliente SET DVH=@Param1 WHERE CodCli=@Param2";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = CadenaClienteDV;
                            break;
                        }

                    case "Producto":
                        {
                            string CadenaProductoDV = "UPDATE Producto SET DVH=@Param1 WHERE CodProd=@Param2";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = CadenaProductoDV;
                            break;
                        }

                    case "Historico_Precio":
                        {
                            string CadenaHist_PrecioDV = "UPDATE Historico_Precio SET DVH=@Param1 WHERE CodHist=@Param2";
                            Cmd.Connection = cnn;
                            Cmd.CommandText = CadenaHist_PrecioDV;
                            break;
                        }
                }

                Cmd.Parameters.AddWithValue("@Param1", DVH);
                Cmd.Parameters.AddWithValue("@Param2", CodReg);
                Cmd.ExecuteNonQuery();
            }
        }

        public static bool ExisteBD()
        {
            using (var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BDMaster"].ToString()))
            {
                cnn.Open();
                string ConsultaBD = "SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = N'Mercader'";
                var Cmd = new SqlCommand(ConsultaBD, cnn);
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
}