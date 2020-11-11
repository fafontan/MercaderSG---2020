using System.Data;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using Microsoft.VisualBasic.CompilerServices;
using Servicios;

namespace Negocios
{
    public class NVRemitoRN
    {
        public static void CargarRemitoNV(DataSet DS, string NroNota)
        {
            if (NVRemitoAD.VerificarRemitoNV(NroNota) > 0)
            {
                NVRemitoAD.CargarRemitoNV(DS, NroNota);
                foreach (DataRow row in DS.Tables["Cliente"].Rows)
                    row["Cuit"] = Seguridad.Desencriptar(Conversions.ToString(row["Cuit"]));
                foreach (DataRow row in DS.Tables["Producto"].Rows)
                    row["Nombre"] = Seguridad.Desencriptar(Conversions.ToString(row["Nombre"]));
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.RemitoNoExiste);
            }
        }

        public static void GenerarRemito(string NroNota)
        {
            int CodigoNota = NotaVentaAD.ObtenerIDNotaVenta(NroNota);
            var RENV = new NVRemitoEN();
            if (NVRemitoAD.ValidarRemitoNV(CodigoNota) > 0)
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.RemitoNVExiste);
            }
            else
            {
                NVRemitoAD.GenerarRemito(CodigoNota, RENV);
            }

            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Remito | Cod: " + RENV.CodRemito);
            Bitacora.Criticidad = 3.ToString();
            Bitacora.Usuario = UsuAut.UsuarioLogueado;
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.RemitoNVGenerado);
        }
    }
}