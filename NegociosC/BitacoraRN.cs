using DatosC;
using EntidadesC;
using ServiciosC;
using System;
using System.Collections.Generic;

namespace NegociosC
{
    public class BitacoraRN
    {

        /// <summary>
        /// Obtiene los eventos realizados en el sistema.
        /// </summary>
        /// <remarks>En este método se desencripta la descripción de cada evento.</remarks>
        /// <returns>List(Of BitacoraEN)</returns>
        /// <history>Federico Fontan - Diploma 2016</history>
        public static List<BitacoraEN> CargarBitacora()
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora();
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        public static List<BitacoraEN> CargarBitacora(string Usuario)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(Usuario);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        /// <param name="criticidad"></param>
        public static List<BitacoraEN> CargarBitacora(int Criticidad)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(Criticidad);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        public static List<BitacoraEN> CargarBitacora(DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(FechaDesde, FechaHasta);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        /// <param name="usuario"></param>
        /// <param name="criticidad"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        public static List<BitacoraEN> CargarBitacora(string Usuario, int Criticidad, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(Usuario, Criticidad, FechaDesde, FechaHasta);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        public static List<BitacoraEN> CargarBitacora(string Usuario, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(Usuario, FechaDesde, FechaHasta);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        public static List<BitacoraEN> CargarBitacora(int Criticidad, DateTime FechaDesde, DateTime FechaHasta)
        {
            var ListaBitacora = new List<BitacoraEN>();
            var ListaBitacoraProcesada = new List<BitacoraEN>();
            ListaBitacora = BitacoraAD.CargarBitacora(Criticidad, FechaDesde, FechaHasta);
            foreach (BitacoraEN item in ListaBitacora)
            {
                var UnEvento = new BitacoraEN();
                UnEvento.CodBit = item.CodBit;
                UnEvento.Fecha = item.Fecha;
                UnEvento.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                UnEvento.Criticidad = item.Criticidad;
                UnEvento.Usuario = item.Usuario;
                ListaBitacoraProcesada.Add(UnEvento);
            }

            return ListaBitacoraProcesada;
        }

        public static void DepurarBitacora(List<BitacoraEN> ListaRegistros)
        {
            int ValorDVHTotal = BitacoraAD.DepurarBitacora(ListaRegistros);
            var UsuAut = Autenticar.Instancia();
            var DVVDatosCliente = new DVVEN();
            DVVDatosCliente.Tabla = "Bitacora";
            DVVDatosCliente.TipoAccion = "Eliminar";
            DVVDatosCliente.ValorDVH = ValorDVHTotal;
            Integridad.GrabarDVV(DVVDatosCliente);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Depuró la Bitácora con un total de " + ListaRegistros.Count + " registro/s.");
            Bitacora.Criticidad = 2.ToString();
            Bitacora.Usuario = UsuAut.UsuarioLogueado;
            BitacoraAD.GrabarBitacora(Bitacora);
            var DVHDatosBitacora = new DVHEN();
            DVHDatosBitacora.Tabla = "Bitacora";
            DVHDatosBitacora.CodReg = Bitacora.CodBit;
            int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
            int DVHAntiguo = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
            var DVVDatosBitacora = new DVVEN();
            DVVDatosBitacora.Tabla = "Bitacora";
            DVVDatosBitacora.ValorDVH = DVHBitacora;
            DVVDatosBitacora.TipoAccion = "Alta";
            Integridad.GrabarDVV(DVVDatosBitacora);
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.DepurarBitacora);
        }
    }
} // BitacoraRN