using DatosC;
using EntidadesC;

namespace ServiciosC
{
    public class LogOut
    {
        public static void CerrarSesion(string Usuario)
        {
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = ServiciosC.Seguridad.Encriptar("Cerró Sesión");
            Bitacora.Criticidad = 3.ToString();
            Bitacora.Usuario = Usuario;
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
        }
    }
} // LogOut