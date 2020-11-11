using System.Collections.Generic;
using System.Data;
using Datos;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;
using Servicios;

namespace Negocios
{
    public class NotaVentaRN
    {


        /// <param name="NotaVenta"></param>
        public static void BajaNotaVenta(NotaVentaEN NotaVenta)
        {
            NotaVentaAD.BajaNotaVenta(NotaVenta);
            int CodNot = NotaVentaAD.ObtenerIDNotaVenta(NotaVenta.NroNota);
            var ListaDetalle = new List<DetalleEN>();
            ListaDetalle = NotaVentaAD.ObtenerDetalleNV(CodNot);
            foreach (DetalleEN item in ListaDetalle)
            {
                var Detalle = new DetalleEN();
                Detalle.CodProd = item.CodProd;
                Detalle.Cantidad = item.Cantidad;
                NotaVentaAD.ActualizarCantidadProducto(Detalle);
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Producto";
                DVHDatos.CodReg = item.CodProd;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Producto";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Baja Modificar";
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                Integridad.GrabarDVV(DVVDatos);
            }

            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de la Nota de Venta con Nro: " + NotaVenta.NroNota);
            Bitacora.Criticidad = 2.ToString();
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaNotaVenta);
        }

        public static List<NotaVentaEN> CargarNotaVenta()
        {
            return NotaVentaAD.CargarNotaVenta();
        }

        public static List<NotaVentaEN> BuscarNotaVenta(string NroNota)
        {
            return NotaVentaAD.BuscarNotaVenta(NroNota);
        }

        /// <param name="NroNota"></param>
        public static void CargarNotaVenta(DataSet DS, string NroNota)
        {
            if (NotaVentaAD.ValidarNotaVenta(NroNota) > 0)
            {
                NotaVentaAD.CargarNotaVenta(DS, NroNota);
                foreach (DataRow row in DS.Tables["Cliente"].Rows)
                    row["Cuit"] = Seguridad.Desencriptar(Conversions.ToString(row["Cuit"]));
                foreach (DataRow row in DS.Tables["Producto"].Rows)
                    row["Nombre"] = Seguridad.Desencriptar(Conversions.ToString(row["Nombre"]));
                foreach (DataRow row in DS.Tables["Detalle_NotaVenta"].Rows)
                    row["Precio"] = Seguridad.Desencriptar(Conversions.ToString(row["Precio"]));
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.NotaVentaNoExiste);
            }
        }

        public static void CargarUltimaNotaVenta(DataSet DS)
        {
            NotaVentaAD.CargarUltimaNotaVenta(DS);
            foreach (DataRow row in DS.Tables["Cliente"].Rows)
                row["Cuit"] = Seguridad.Desencriptar(Conversions.ToString(row["Cuit"]));
            foreach (DataRow row in DS.Tables["Producto"].Rows)
                row["Nombre"] = Seguridad.Desencriptar(Conversions.ToString(row["Nombre"]));
            foreach (DataRow row in DS.Tables["Detalle_NotaVenta"].Rows)
                row["Precio"] = Seguridad.Desencriptar(Conversions.ToString(row["Precio"]));
        }

        /// <param name="NotaVenta"></param>
        public static void CrearNotaVenta(NotaVentaEN NotaVenta)
        {
            var ListaDetalle = new List<DetalleEN>();
            foreach (DetalleEN item in NotaVenta.Detalle)
            {
                var Linea = new DetalleEN();
                Linea.CodProd = item.CodProd;
                Linea.NombreProducto = item.NombreProducto;
                Linea.Precio = Seguridad.Encriptar(item.Precio);
                Linea.Cantidad = item.Cantidad;
                ListaDetalle.Add(Linea);
            }

            NotaVenta.Detalle = ListaDetalle;
            NotaVentaAD.CrearNotaVenta(NotaVenta);
            foreach (DetalleEN item in NotaVenta.Detalle)
            {
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Producto";
                DVHDatos.CodReg = item.CodProd;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Producto";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Baja Modificar";
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                Integridad.GrabarDVV(DVVDatos);
            }

            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Nota de Venta | Cod: " + NotaVenta.CodNot);
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaNotaVenta);
        }
    }
} // NotaVentaRN