using Datos;
using Entidades;

namespace Servicios
{
    public class LogOut
    {
        public static void CerrarSesion(string Usuario)
        {
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Servicios.Seguridad.Encriptar("Cerró Sesión");
            Bitacora.Criticidad = 3.ToString();
            Bitacora.Usuario = Usuario;
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
        }
    }
} // LogOut