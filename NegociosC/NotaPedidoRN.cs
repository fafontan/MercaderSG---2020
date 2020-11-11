using System.Collections.Generic;
using System.Data;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using Microsoft.VisualBasic.CompilerServices;
using ServiciosC;

namespace NegociosC
{
    public class NotaPedidoRN
    {


        /// <param name="NotaPedido"></param>
        public static void BajaNotaPedido(NotaPedidoEN NotaPedido)
        {
            NotaPedidoAD.BajaNotaPedido(NotaPedido);
            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de la Nota de Pedido con Nro: " + NotaPedido.NroNota);
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
            throw new InformationException(My.Resources.ArchivoIdioma.BajaNotaVenta);
            //throw new InformationException(NegociosC.My.Resources.ArchivoIdioma.BajaNotaVenta);
        }

        public static List<NotaPedidoEN> CargarNotaPedido()
        {
            return NotaPedidoAD.CargarNotaPedido();
        }

        public static void CargarNotaPedido(DataSet DS, string NroNota)
        {
            if (NotaPedidoAD.ValidarNotaPedido(NroNota) > 0)
            {
                NotaPedidoAD.CargarNotaPedido(DS, NroNota);
                foreach (DataRow row in DS.Tables["Proveedor"].Rows)
                    row["Cuit"] = Seguridad.Desencriptar(Conversions.ToString(row["Cuit"]));
                foreach (DataRow row in DS.Tables["Producto"].Rows)
                    row["Nombre"] = Seguridad.Desencriptar(Conversions.ToString(row["Nombre"]));
                foreach (DataRow row in DS.Tables["Detalle_NotaPedido"].Rows)
                    row["Precio"] = Seguridad.Desencriptar(Conversions.ToString(row["Precio"]));
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.NotaPedidoNoExiste);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.NotaPedidoNoExiste);
            }
        }

        public static void CargarUltimaNotaPedido(DataSet DS)
        {
            NotaPedidoAD.CargarUltimaNotaPedido(DS);
            foreach (DataRow row in DS.Tables["Proveedor"].Rows)
                row["Cuit"] = Seguridad.Desencriptar(Conversions.ToString(row["Cuit"]));
            foreach (DataRow row in DS.Tables["Producto"].Rows)
                row["Nombre"] = Seguridad.Desencriptar(Conversions.ToString(row["Nombre"]));
            foreach (DataRow row in DS.Tables["Detalle_NotaPedido"].Rows)
                row["Precio"] = Seguridad.Desencriptar(Conversions.ToString(row["Precio"]));
        }

        /// <param name="NotaPedido"></param>
        public static void CrearNotaPedido(NotaPedidoEN NotaPedido)
        {
            var ListaDetalle = new List<DetalleEN>();
            foreach (DetalleEN item in NotaPedido.Detalle)
            {
                var Linea = new DetalleEN();
                Linea.CodProd = item.CodProd;
                Linea.NombreProducto = item.NombreProducto;
                Linea.Precio = Seguridad.Encriptar(item.Precio);
                Linea.Cantidad = item.Cantidad;
                ListaDetalle.Add(Linea);
            }

            NotaPedido.Detalle = ListaDetalle;
            NotaPedidoAD.CrearNotaPedido(NotaPedido);
            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Alta de Nota de Pedido | Cod: " + NotaPedido.CodNot);
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
            throw new InformationException(My.Resources.ArchivoIdioma.AltaNotaPedido);
            //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaNotaPedido);
        }

        public static List<NotaPedidoEN> BuscarNotaPedido(string NroNota)
        {
            return NotaPedidoAD.BuscarNotaPedido(NroNota);
        }
    }
} // NotaPedidoRN