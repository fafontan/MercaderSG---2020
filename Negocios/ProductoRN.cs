using System.Collections.Generic;
using Datos;
using Entidades;
using Excepciones;
using Servicios;

namespace Negocios
{
    public class ProductoRN
    {
        public static void ActualizarStock(int CodProd, int Cantidad)
        {
            ProductoAD.ActualizarStock(CodProd, Cantidad);
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Producto";
            DVHDatos.CodReg = CodProd;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Producto";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            Integridad.GrabarDVV(DVVDatos);
        }

        /// <param name="Producto"></param>
        public static void AltaProducto(ProductoEN Producto)
        {
            string ProductoDesencriptado = Producto.Nombre;
            string PrecioDesencriptado = Producto.Precio;
            Producto.Nombre = Seguridad.Encriptar(Producto.Nombre);
            Producto.Precio = Seguridad.Encriptar(Producto.Precio);
            if (ProductoAD.ValidarProducto(Producto.Nombre) > 0)
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.ProductoExistente);
                return;
            }
            else
            {
                ProductoAD.AltaProducto(Producto);
                var UsuAut = Autenticar.Instancia();

                // Producto
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Producto";
                DVHDatos.CodReg = Producto.CodProd;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Producto";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatos);
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de Producto: " + ProductoDesencriptado);
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

                // Historico_Precio
                var DVHDatosHP = new DVHEN();
                DVHDatosHP.Tabla = "Historico_Precio";
                DVHDatosHP.CodReg = Producto.CodHistorico;
                int DVHHP = Integridad.CalcularDVH(DVHDatosHP);
                int ValorDVHAntiguoHP = Integridad.GrabarDVH(DVHDatosHP, DVHHP);
                var DVVDatosHP = new DVVEN();
                DVVDatosHP.Tabla = "Historico_Precio";
                DVVDatosHP.ValorDVH = DVHHP;
                DVVDatosHP.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosHP);
                var BitacoraHP = new BitacoraEN();
                BitacoraHP.Descripcion = Seguridad.Encriptar("Alta de Precio: " + PrecioDesencriptado + " del Cod.Prod: " + Producto.CodProd);
                BitacoraHP.Criticidad = 3.ToString();
                BitacoraHP.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(BitacoraHP);
                var DVHDatosBitacoraHP = new DVHEN();
                DVHDatosBitacoraHP.Tabla = "Bitacora";
                DVHDatosBitacoraHP.CodReg = BitacoraHP.CodBit;
                int DVHBitacoraHP = Integridad.CalcularDVH(DVHDatosBitacoraHP);
                int ValorDVHAntiguoHPBit = Integridad.GrabarDVH(DVHDatosBitacoraHP, DVHBitacoraHP);
                var DVVDatosBitacoraHP = new DVVEN();
                DVVDatosBitacoraHP.Tabla = "Bitacora";
                DVVDatosBitacoraHP.ValorDVH = DVHBitacoraHP;
                DVVDatosBitacoraHP.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosBitacoraHP);
                throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaProducto);
            }
        }

        /// <param name="Producto"></param>
        public static void BajaProducto(ProductoEN Producto)
        {
            ProductoAD.BajaProducto(Producto);
            var UsuAut = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Producto";
            DVHDatos.CodReg = Producto.CodProd;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Producto";
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            DVVDatos.ValorDVH = DVH;
            Integridad.GrabarDVV(DVVDatos);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de Producto: " + Producto.Nombre);
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaProducto);
        }

        /// <param name="campo"></param>
	/// <param name="valor"></param>
        public static List<ProductoEN> BuscarProducto(string Campo, string Valor)
        {
            var ListaProductos = new List<ProductoEN>();
            var ListaProductosProc = new List<ProductoEN>();
            if ((Campo ?? "") == (Negocios.My.Resources.ArchivoIdioma.CMBNombre ?? ""))
            {
                Valor = Seguridad.Encriptar(Valor);
            }

            ListaProductos = ProductoAD.BuscarProducto(Campo, Valor);
            foreach (ProductoEN item in ListaProductos)
            {
                var UnProducto = new ProductoEN();
                UnProducto.CodProd = item.CodProd;
                UnProducto.Nombre = Seguridad.Desencriptar(item.Nombre);
                UnProducto.Sector = item.Sector;
                UnProducto.Cantidad = item.Cantidad;
                UnProducto.Precio = Seguridad.Desencriptar(item.Precio);
                UnProducto.Descripcion = item.Descripcion;
                ListaProductosProc.Add(UnProducto);
            }

            return ListaProductosProc;
        }

        public static List<ProductoEN> CargarProducto()
        {
            var ListaProducto = new List<ProductoEN>();
            var ListaProductoProc = new List<ProductoEN>();
            ListaProducto = ProductoAD.CargarProducto();
            foreach (ProductoEN item in ListaProducto)
            {
                var UnProducto = new ProductoEN();
                UnProducto.CodProd = item.CodProd;
                UnProducto.Nombre = Seguridad.Desencriptar(item.Nombre);
                UnProducto.Sector = item.Sector;
                UnProducto.Cantidad = item.Cantidad;
                UnProducto.Precio = Seguridad.Desencriptar(item.Precio);
                UnProducto.Descripcion = item.Descripcion;
                ListaProductoProc.Add(UnProducto);
            }

            return ListaProductoProc;
        }

        public static void ModificarPrecioProducto(ProductoEN Producto)
        {
            string PrecioDesencriptado = Producto.Precio;
            Producto.Precio = Seguridad.Encriptar(Producto.Precio);
            ProductoAD.ModificarPrecioProducto(Producto);
            var UsuAut = Autenticar.Instancia();
            var DVHDatosHP = new DVHEN();
            DVHDatosHP.Tabla = "Historico_Precio";
            DVHDatosHP.CodReg = Producto.CodHistorico;
            int DVHHP = Integridad.CalcularDVH(DVHDatosHP);
            int ValorDVHAntiguoHP = Integridad.GrabarDVH(DVHDatosHP, DVHHP);
            var DVVDatosHP = new DVVEN();
            DVVDatosHP.Tabla = "Historico_Precio";
            DVVDatosHP.TipoAccion = "Baja Modificar";
            DVVDatosHP.ValorDVHAntiguo = ValorDVHAntiguoHP;
            DVVDatosHP.ValorDVH = DVHHP;
            Integridad.GrabarDVV(DVVDatosHP);
            var BitacoraHP = new BitacoraEN();
            BitacoraHP.Descripcion = Seguridad.Encriptar("Alta de Precio: " + PrecioDesencriptado + " del Cod.Prod: " + Producto.CodProd);
            BitacoraHP.Criticidad = 2.ToString();
            BitacoraHP.Usuario = UsuAut.UsuarioLogueado;
            BitacoraAD.GrabarBitacora(BitacoraHP);
            var DVHDatosBitacoraHP = new DVHEN();
            DVHDatosBitacoraHP.Tabla = "Bitacora";
            DVHDatosBitacoraHP.CodReg = BitacoraHP.CodBit;
            int DVHBitacoraHP = Integridad.CalcularDVH(DVHDatosBitacoraHP);
            int ValorDVHAntiguoHPBit = Integridad.GrabarDVH(DVHDatosBitacoraHP, DVHBitacoraHP);
            var DVVDatosBitacora = new DVVEN();
            DVVDatosBitacora.Tabla = "Bitacora";
            DVVDatosBitacora.ValorDVH = DVHBitacoraHP;
            DVVDatosBitacora.TipoAccion = "Alta";
            Integridad.GrabarDVV(DVVDatosBitacora);
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaPrecio);
        }

        /// <param name="Producto"></param>
        public static void ModificarProducto(ProductoEN Producto)
        {
            Producto.Nombre = Seguridad.Encriptar(Producto.Nombre);
            ProductoAD.ModificarProducto(Producto);
            var UsuAut = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Producto";
            DVHDatos.CodReg = Producto.CodProd;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Producto";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            Integridad.GrabarDVV(DVVDatos);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Se modificó el Producto: " + Producto.Nombre);
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.ModificarProducto);
        }

        public static void ModificarStockProducto(ProductoEN Producto)
        {
            ProductoAD.ModificarStockProducto(Producto);
            var UsuAut = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Producto";
            DVHDatos.CodReg = Producto.CodProd;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Producto";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            Integridad.GrabarDVV(DVVDatos);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Se agrego " + Producto.Cantidad + " unidades al stock del producto: " + Producto.CodProd + "||" + Producto.Nombre);
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaStock);
        }

        /// <param name="Nombre"></param>
        public static ProductoEN ObtenerProducto(string Nombre)
        {
            int CodProd = ProductoAD.ObtenerIDProducto(Nombre);
            var UnProducto = new ProductoEN();
            UnProducto = ProductoAD.ObtenerProducto(CodProd);
            UnProducto.Nombre = Seguridad.Desencriptar(UnProducto.Nombre);
            UnProducto.Precio = Seguridad.Desencriptar(UnProducto.Precio);
            return UnProducto;
        }

        /// <param name="Codprod"></param>
        public static int StockIDProd(int CodProd)
        {
            return ProductoAD.StockIDProd(CodProd);
        }
    }
} // ProductoRN