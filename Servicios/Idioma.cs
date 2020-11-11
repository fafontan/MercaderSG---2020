using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Datos;
using Entidades;

namespace Servicios
{
    public class Idioma
    {
        public static void AplicarIdioma(string IdiomaUsuario)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(IdiomaUsuario);
        }

        public static int DetectarIdioma(int IDUsuario)
        {
            return ServicioAD.DetectarIdioma(IDUsuario);
        }

        public static List<IdiomaEN> ListarIdiomas()
        {
            return ServicioAD.ListarIdiomas();
        }
    }
} // Idioma