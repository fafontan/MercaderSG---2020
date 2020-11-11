using System.Collections.Generic;
using Datos;
using Entidades;

namespace Servicios
{
    public class Restore
    {


        /// <param name="Origen"></param>
        public static bool EjecutarRestore(List<string> Origen)
        {
            if (ServicioAD.EjecutarRestore(Origen))
            {
                var Bitacora = new BitacoraEN();
                var UsuAut = Servicios.Autenticar.Instancia();
                Bitacora.Descripcion = Servicios.Seguridad.Encriptar("Restauro la base de datos");
                Bitacora.Criticidad = 1.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = Servicios.Integridad.CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBit = Servicios.Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                Servicios.Integridad.GrabarDVV(DVVDatosBitacora);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
} // Restore