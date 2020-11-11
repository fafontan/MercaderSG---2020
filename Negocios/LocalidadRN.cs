using System.Collections.Generic;
using Datos;
using Entidades;
using Excepciones;
using Servicios;

namespace Negocios
{
    public class LocalidadRN
    {
        public static void AltaLocalidad(LocalidadEN Localidad)
        {
            if (LocalidadAD.ValidarLocalidad(Localidad.Descripcion) > 0)
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.LocalidadExistente);
                return;
            }
            else
            {
                var Bitacora = new BitacoraEN();
                var UsuLog = Autenticar.Instancia();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de localidad: " + Localidad.Descripcion);
                Bitacora.Criticidad = 3.ToString();
                Bitacora.Usuario = UsuLog.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBit = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosBitacora);
                LocalidadAD.AltaLocalidad(Localidad);
                throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaLocalidad);
            }
        }

        public static List<ProvinciaEN> CargarProvincia()
        {
            return LocalidadAD.CargarProvincia();
        }

        public static List<LocalidadEN> CargarLocalidad()
        {
            return LocalidadAD.CargarLocalidad();
        }
    }
}