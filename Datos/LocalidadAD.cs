using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Microsoft.VisualBasic.CompilerServices;

namespace Datos
{
    public class LocalidadAD
    {
        public static void AltaLocalidad(LocalidadEN Localidad)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaLoc = "INSERT INTO Localidad(Provincia_CodProvincia,Descripcion,CodigoPostal) VALUES" + "(@CodProv,@Descripcion,@CodigoPostal)";
                var Cmd = new SqlCommand(ConsultaLoc, Cnn);
                Cmd.Parameters.AddWithValue("@CodProv", Localidad.CodProvincia);
                Cmd.Parameters.AddWithValue("@Descripcion", Localidad.Descripcion);
                Cmd.Parameters.AddWithValue("@CodigoPostal", Localidad.CodigoPostal);
                Cmd.ExecuteNonQuery();
            }
        }

        public static List<ProvinciaEN> CargarProvincia()
        {
            var ListaProv = new List<ProvinciaEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaProv = "SELECT CodProvincia,Descripcion FROM Provincia";
                var Cmd = new SqlCommand(ConsultaProv, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaProv = new ProvinciaEN();
                    UnaProv.CodProvincia = Conversions.ToInteger(Lector[0]);
                    UnaProv.Descripcion = Conversions.ToString(Lector[1]);
                    ListaProv.Add(UnaProv);
                }

                return ListaProv;
            }
        }

        public static int ValidarLocalidad(string Nombre)
        {
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaLoc = "SELECT COUNT(*) FROM Localidad WHERE Descripcion=@Param1";
                var Cmd = new SqlCommand(ConsultaLoc, Cnn);
                Cmd.Parameters.AddWithValue("@Param1", Nombre);
                int Resultado = Conversions.ToInteger(Cmd.ExecuteScalar());
                return Resultado;
            }
        }

        public static List<LocalidadEN> CargarLocalidad()
        {
            var ListaLoc = new List<LocalidadEN>();
            using (var Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mercader"].ToString()))
            {
                Cnn.Open();
                string ConsultaLoc = "SELECT CodLoc,Provincia_CodProvincia,Descripcion,CodigoPostal FROM Localidad";
                var Cmd = new SqlCommand(ConsultaLoc, Cnn);
                var Lector = Cmd.ExecuteReader();
                while (Lector.Read())
                {
                    var UnaLocalidad = new LocalidadEN();
                    UnaLocalidad.CodLoc = Conversions.ToInteger(Lector[0]);
                    UnaLocalidad.CodProvincia = Conversions.ToInteger(Lector[1]);
                    UnaLocalidad.Descripcion = Conversions.ToString(Lector[2]);
                    UnaLocalidad.CodigoPostal = Conversions.ToString(Lector[3]);
                    ListaLoc.Add(UnaLocalidad);
                }

                return ListaLoc;
            }
        }
    }
}