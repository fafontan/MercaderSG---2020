using System.Collections.Generic;
using Datos;
using Entidades;
using Excepciones;
using Servicios;

namespace Negocios
{
    public class ProveedorRN
    {


        /// <param name="Proveedor"></param>
        public static void AltaProveedor(ProveedorEN Proveedor)
        {
            string CuitDesencriptado = Proveedor.Cuit;
            Proveedor.Cuit = Seguridad.Encriptar(Proveedor.Cuit);
            if (ProveedorAD.ValidarProveedor(Proveedor.Cuit) > 0)
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.ProveedorExistente);
                return;
            }
            else
            {
                var ListaTelEncriptada = new List<TelefonoEN>();
                foreach (TelefonoEN item in Proveedor.Telefono)
                {
                    var UnTelefono = new TelefonoEN();
                    UnTelefono.Numero = Seguridad.Encriptar(item.Numero);
                    ListaTelEncriptada.Add(UnTelefono);
                }

                Proveedor.Telefono = ListaTelEncriptada;
                ProveedorAD.AltaProveedor(Proveedor);
                var Bitacora = new BitacoraEN();
                var UsuAut = Autenticar.Instancia();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de Proveedor: " + CuitDesencriptado);
                Bitacora.Criticidad = 3.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosBitacora);
                throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaProveedor);
            }
        }

        /// <param name="Proveedor"></param>
        public static void BajaProveedor(ProveedorEN Proveedor)
        {
            ProveedorAD.BajaProveedor(Proveedor);
            var Bitacora = new BitacoraEN();
            var UsuLog = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de proveedor: " + Proveedor.RazonSocial);
            Bitacora.Criticidad = 2.ToString();
            Bitacora.Usuario = UsuLog.UsuarioLogueado;
            var DVHDatosBitacora = new DVHEN();
            DVHDatosBitacora.Tabla = "Bitacora";
            DVHDatosBitacora.CodReg = Bitacora.CodBit;
            int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
            var DVVDatosBitacora = new DVVEN();
            DVVDatosBitacora.Tabla = "Bitacora";
            DVVDatosBitacora.ValorDVH = DVHBitacora;
            DVVDatosBitacora.TipoAccion = "Alta";
            Integridad.GrabarDVV(DVVDatosBitacora);
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaProveedor);
        }

        /// <param name="campo"></param>
	/// <param name="valor"></param>
        public static List<ProveedorEN> BuscarProveedor(string campo, string valor)
        {
            var ListaProveedor = new List<ProveedorEN>();
            var ListaProvProcesada = new List<ProveedorEN>();
            if ((campo ?? "") == (Negocios.My.Resources.ArchivoIdioma.CMBCuit ?? ""))
            {
                valor = Seguridad.Encriptar(valor);
            }

            ListaProveedor = ProveedorAD.BuscarProveedor(campo, valor);
            foreach (ProveedorEN item in ListaProveedor)
            {
                var UnProveedor = new ProveedorEN();
                UnProveedor.CodProv = item.CodProv;
                UnProveedor.RazonSocial = item.RazonSocial;
                UnProveedor.Cuit = Seguridad.Desencriptar(item.Cuit);
                UnProveedor.Direccion = item.Direccion;
                UnProveedor.Activo = item.Activo;
                ListaProvProcesada.Add(UnProveedor);
            }

            return ListaProvProcesada;
        }

        public static List<ProveedorEN> CargarProveedor()
        {
            var ListaProveedor = new List<ProveedorEN>();
            var ListaProvProcesada = new List<ProveedorEN>();
            ListaProveedor = ProveedorAD.CargarProveedor();
            foreach (ProveedorEN item in ListaProveedor)
            {
                var UnProveedor = new ProveedorEN();
                UnProveedor.CodProv = item.CodProv;
                UnProveedor.RazonSocial = item.RazonSocial;
                UnProveedor.Cuit = Seguridad.Desencriptar(item.Cuit);
                UnProveedor.CorreoElectronico = item.CorreoElectronico;
                UnProveedor.Direccion = item.Direccion;
                UnProveedor.Activo = item.Activo;
                ListaProvProcesada.Add(UnProveedor);
            }

            return ListaProvProcesada;
        }

        public static void EliminarTelefonoProveedor(TelefonoEN UnTelefono)
        {
            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            ProveedorAD.EliminarTelefonoProveedor(UnTelefono);
            Bitacora.Descripcion = Seguridad.Encriptar("Eliminó el telefono: " + UnTelefono.Numero);
            Bitacora.Criticidad = 3.ToString();
            Bitacora.Usuario = UsuAut.UsuarioLogueado;
            BitacoraAD.GrabarBitacora(Bitacora);
            var DVHDatosBitacora = new DVHEN();
            DVHDatosBitacora.Tabla = "Bitacora";
            DVHDatosBitacora.CodReg = Bitacora.CodBit;
            int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
            var DVVDatosBitacora = new DVVEN();
            DVVDatosBitacora.Tabla = "Bitacora";
            DVVDatosBitacora.ValorDVH = DVHBitacora;
            DVVDatosBitacora.TipoAccion = "Alta";
            Integridad.GrabarDVV(DVVDatosBitacora);
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.EliminarTelefono);
        }

        /// <param name="Proveedor"></param>
        public static void ModificarProveedor(ProveedorEN Proveedor)
        {
            var ListaTelefonoEncriptada = new List<TelefonoEN>();
            string CuitDesencriptado = Proveedor.Cuit;
            Proveedor.Cuit = Seguridad.Encriptar(Proveedor.Cuit);
            foreach (TelefonoEN item in Proveedor.Telefono)
            {
                var UnTelefono = new TelefonoEN();
                UnTelefono.CodTel = item.CodTel;
                UnTelefono.CodEn = item.CodEn;
                UnTelefono.Numero = Seguridad.Encriptar(item.Numero);
                ListaTelefonoEncriptada.Add(UnTelefono);
            }

            Proveedor.Telefono = ListaTelefonoEncriptada;
            ProveedorAD.ModificarProveedor(Proveedor);
            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del proveedor: " + CuitDesencriptado);
            Bitacora.Criticidad = 3.ToString();
            Bitacora.Usuario = UsuAut.UsuarioLogueado;
            BitacoraAD.GrabarBitacora(Bitacora);
            var DVHDatosBitacora = new DVHEN();
            DVHDatosBitacora.Tabla = "Bitacora";
            DVHDatosBitacora.CodReg = Bitacora.CodBit;
            int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
            var DVVDatosBitacora = new DVVEN();
            DVVDatosBitacora.Tabla = "Bitacora";
            DVVDatosBitacora.ValorDVH = DVHBitacora;
            DVVDatosBitacora.TipoAccion = "Alta";
            Integridad.GrabarDVV(DVVDatosBitacora);
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.ModificarProveedor);
        }

        /// <param name="Cuit"></param>
        public static ProveedorEN ObtenerProveedor(string Cuit)
        {
            var ProvProcesado = new ProveedorEN();
            int CodPRov = ProveedorAD.ObtenerIDProveedor(Cuit);
            ProvProcesado = ProveedorAD.ObtenerProveedor(CodPRov);
            ProvProcesado.Cuit = Seguridad.Desencriptar(ProvProcesado.Cuit);
            return ProvProcesado;
        }

        public static List<TelefonoEN> ObtenerTelefonoProveedor(int CodProv)
        {
            var ListaTelProcesada = new List<TelefonoEN>();
            var ListaTelefonos = new List<TelefonoEN>();
            ListaTelefonos = ProveedorAD.ObtenerTelefonoProveedor(CodProv);
            foreach (TelefonoEN item in ListaTelefonos)
            {
                var UnTelefono = new TelefonoEN();
                UnTelefono.CodTel = item.CodTel;
                UnTelefono.CodEn = item.CodEn;
                UnTelefono.Numero = Seguridad.Desencriptar(item.Numero);
                ListaTelProcesada.Add(UnTelefono);
            }

            return ListaTelProcesada;
        }
    }
} // ProveedorRN