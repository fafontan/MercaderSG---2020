using System.Collections.Generic;
using Datos;
using Entidades;
using Excepciones;

namespace Servicios
{
    public class Backup
    {


        /// <param name="Destino"></param>
    /// <param name="volumen"></param>
        public static List<string> EjecutarBackup(string Destino, int Volumen)
        {
            if (ServicioAD.ExisteBD())
            {
                var ListaArchivos = new List<string>();
                ListaArchivos = ServicioAD.EjecutarBackup(Destino, Volumen);
                if (ListaArchivos.Count > 0)
                {
                    var Bitacora = new BitacoraEN();
                    var UsuAut = Servicios.Autenticar.Instancia();
                    Bitacora.Descripcion = Servicios.Seguridad.Encriptar("Realizó una copia de seguridad en " + Volumen + " parte/s");
                    Bitacora.Criticidad = 2.ToString();
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
                    return ListaArchivos;
                }
                else
                {
                    return ListaArchivos;
                }
            }
            else
            {
                throw new WarningException(Servicios.My.Resources.ArchivoIdioma.BDNoExiste);
            }
        }
    }
} // Backup