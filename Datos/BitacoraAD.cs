using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class BitacoraAD
    {

        /// <summary>
    /// Obtiene los eventos realizados en el sistema.
    /// </summary>
    /// <returns>List(Of BitacoraEN)</returns>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora()
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        /// <summary>
    /// Obtiene los eventos realizados en el sistema por un usuario.
    /// </summary>
    /// <param name="Usuario">Usuario</param>
    /// <returns>List(Of BitacoraEN)</returns>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora(string Usuario)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE Usuario=@Param1";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        /// <summary>
    /// Obtiene los eventos realizados en el sistema por un nivel de criticidad.
    /// </summary>
    /// <param name="Criticidad">Criticidad</param>
    /// <returns>List(Of BitacoraEN)</returns>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora(int Criticidad)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE Criticidad=@Param1";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Criticidad);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        /// <summary>
    /// Obtiene los eventos realizados en el sistema dentro de un rango de fechas.
    /// </summary>
    /// <param name="FechaDesde">Fecha Desde</param>
    /// <param name="FechaHasta">Fecha Hasta</param>
    /// <returns>List(Of BitacoraEN)</returns>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora(DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param1 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param2";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", FechaDesde);
                Cmd.Parameters.AddWithValue("@Param2", FechaHasta);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        /// <summary>
    /// Obtiene los eventos realizados en el sistema por filtro completo.
    /// </summary>
    /// <param name="Usuario">Usuario</param>
    /// <param name="Criticidad">Criticidad</param>
    /// <param name="FechaDesde">Fecha Desde</param>
    /// <param name="FechaHasta">Fecha Hasta</param>
    /// <returns>List(Of BitacoraEN)</returns>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora(string Usuario, int Criticidad, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE Usuario=@Param1 AND Criticidad=@Param2 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param3 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param4";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.Parameters.AddWithValue("@Param2", Criticidad);
                Cmd.Parameters.AddWithValue("@Param3", FechaDesde);
                Cmd.Parameters.AddWithValue("@Param4", FechaHasta);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        /// <summary>
    /// Graba en la base de datos un evento realizado en el sistema.
    /// </summary>
    /// <param name="Bitacora">Entidad Bitacora</param>
    /// <history>Federico Fontan - Diploma 2016</history>
        public static void GrabarBitacora(BitacoraEN Bitacora)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaBitacora = "INSERT INTO Bitacora(Fecha,Descripcion,Criticidad," + "Usuario,DVH) VALUES (GETDATE(),@Descripcion,@Criticidad," + "@Usuario,0) SELECT SCOPE_IDENTITY()";

                var Cmd = new SqlCommand(ConsultaBitacora, Cnn);
                Cmd.Parameters.AddWithValue("@Descripcion", Bitacora.Descripcion);
                Cmd.Parameters.AddWithValue("@Criticidad", Bitacora.Criticidad);
                Cmd.Parameters.AddWithValue("@Usuario", Bitacora.Usuario);
                Bitacora.CodBit = Conversions.ToInteger(Cmd.ExecuteScalar());
            }
        }

        public static List<BitacoraEN> CargarBitacora(string Usuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE Usuario=@Param1 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param2 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param3";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Usuario);
                Cmd.Parameters.AddWithValue("@Param2", FechaDesde);
                Cmd.Parameters.AddWithValue("@Param3", FechaHasta);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        public static List<BitacoraEN> CargarBitacora(int Criticidad, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaCarga = "SELECT CodBit,Fecha,Descripcion,Criticidad,Usuario " + "FROM Bitacora WHERE Criticidad=@Param1 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) >= @Param2 " + "AND CONVERT(smalldatetime, CONVERT(char(10), Fecha, 103), 103) <= @Param3";
                var Cmd = new SqlCommand(ConsultaCarga, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Criticidad);
                Cmd.Parameters.AddWithValue("@Param2", FechaDesde);
                Cmd.Parameters.AddWithValue("@Param3", FechaHasta);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnEvento = new BitacoraEN();
                    UnEvento.CodBit = Conversions.ToInteger(Lector[0]);
                    UnEvento.Fecha = Conversions.ToDate(Lector[1]);
                    UnEvento.Descripcion = Conversions.ToString(Lector[2]);
                    UnEvento.Criticidad = Conversions.ToString(Lector[3]);
                    UnEvento.Usuario = Conversions.ToString(Lector[4]);
                    ListaBitacora.Add(UnEvento);
                }
            }

            return ListaBitacora;
        }

        public static int DepurarBitacora(List<BitacoraEN> ListaRegistros)
        {
            var TotalDVH = default(int);
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                foreach (BitacoraEN item in ListaRegistros)
                {
                    string ConsultaAlta = "INSERT INTO Historico_Bitacora(CodBitacora,Fecha,Descripcion,Criticidad," + "Usuario) VALUES (@Param1,@Param2,@Param3," + "@Param4,@Param5)";

                    var CmdAlta = new SqlCommand(ConsultaAlta, Cnn);
                    CmdAlta.Parameters.AddWithValue("@Param1", item.CodBit);
                    CmdAlta.Parameters.AddWithValue("@Param2", item.Fecha);
                    CmdAlta.Parameters.AddWithValue("@Param3", item.Descripcion);
                    CmdAlta.Parameters.AddWithValue("@Param4", item.Criticidad);
                    CmdAlta.Parameters.AddWithValue("@Param5", item.Usuario);
                    CmdAlta.ExecuteNonQuery();
                }

                foreach (BitacoraEN item in ListaRegistros)
                {
                    string ConsultaDVH = "SELECT DVH FROM Bitacora WHERE CodBit=@Param1";
                    var CmdDVH = new SqlCommand(ConsultaDVH, Cnn);
                    CmdDVH.Parameters.AddWithValue("@Param1", item.CodBit);
                    TotalDVH += Conversions.ToInteger(CmdDVH.ExecuteScalar());
                    string ConsultaBaja = "DELETE FROM Bitacora WHERE CodBit=@Param1";
                    var Cmd = new SqlCommand(ConsultaBaja, Cnn);
                    Cmd.Parameters.AddWithValue("@Param1", item.CodBit);
                    Cmd.ExecuteNonQuery();
                }
            }

            return TotalDVH;
        }
    }
} // BitacoraAD