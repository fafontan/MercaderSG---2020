using System.Collections.Generic;
using DatosC;
using EntidadesC;

namespace ServiciosC
{
    public class Restore
    {


        /// <param name="Origen"></param>
        public static bool EjecutarRestore(List<string> Origen)
        {
            if (ServicioAD.EjecutarRestore(Origen))
            {
                var Bitacora = new BitacoraEN();
                var UsuAut = ServiciosC.Autenticar.Instancia();
                Bitacora.Descripcion = ServiciosC.Seguridad.Encriptar("Restauro la base de datos");
                Bitacora.Criticidad = 1.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = ServiciosC.Integridad.CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBit = ServiciosC.Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                ServiciosC.Integridad.GrabarDVV(DVVDatosBitacora);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
} // Restore