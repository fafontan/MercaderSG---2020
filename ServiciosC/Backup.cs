using System.Collections.Generic;
using DatosC;
using EntidadesC;
using ExcepcionesC;

namespace ServiciosC
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
                    var UsuAut = ServiciosC.Autenticar.Instancia();
                    Bitacora.Descripcion = ServiciosC.Seguridad.Encriptar("Realizó una copia de seguridad en " + Volumen + " parte/s");
                    Bitacora.Criticidad = 2.ToString();
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
                    return ListaArchivos;
                }
                else
                {
                    return ListaArchivos;
                }
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.BDNoExiste);
                //ESTO LO SAQUE YOthrow new WarningException(ServiciosC.My.Resources.ArchivoIdioma.BDNoExiste);
            }
        }
    }
} // Backup