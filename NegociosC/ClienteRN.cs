using System.Collections.Generic;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using ServiciosC;

namespace NegociosC
{
    public class ClienteRN
    {
        public static void AltaCliente(ClienteEN Cliente)
        {
            string CuitDesencriptado = Cliente.Cuit;
            Cliente.Cuit = Seguridad.Encriptar(Cliente.Cuit);
            if (ClienteAD.ValidarCliente(Cliente.Cuit) > 0)
            {
                throw new WarningException(My.Resources.ArchivoIdioma.ClienteExistente);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.ClienteExistente);
                return;
            }
            else
            {
                var ListaTelefonoEncriptada = new List<TelefonoEN>();
                foreach (TelefonoEN item in Cliente.Telefono)
                {
                    var UnTelefono = new TelefonoEN();
                    UnTelefono.Numero = Seguridad.Encriptar(item.Numero);
                    ListaTelefonoEncriptada.Add(UnTelefono);
                }

                Cliente.Telefono = ListaTelefonoEncriptada;
                ClienteAD.AltaCliente(Cliente);
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Cliente";
                DVHDatos.CodReg = Cliente.CodCli;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatosCliente = new DVVEN();
                DVVDatosCliente.Tabla = "Cliente";
                DVVDatosCliente.TipoAccion = "Alta";
                DVVDatosCliente.ValorDVH = DVH;
                Integridad.GrabarDVV(DVVDatosCliente);
                var Bitacora = new BitacoraEN();
                var UsuAut = Autenticar.Instancia();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de cliente con CUIT: " + CuitDesencriptado);
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
                throw new InformationException(My.Resources.ArchivoIdioma.AltaCliente);
                //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaCliente);
            }
        }

        /// <param name="Cliente"></param>
        public static void BajaCliente(ClienteEN Cliente)
        {
            ClienteAD.BajaCliente(Cliente);
            var UsuLog = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Cliente";
            DVHDatos.CodReg = Cliente.CodCli;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatosCliente = new DVVEN();
            DVVDatosCliente.Tabla = "Cliente";
            DVVDatosCliente.ValorDVHAntiguo = ValorDVHAntiguo;
            DVVDatosCliente.TipoAccion = "Baja Modificar";
            DVVDatosCliente.ValorDVH = DVH;
            Integridad.GrabarDVV(DVVDatosCliente);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Baja de cliente con CUIT: " + Cliente.Cuit);
            Bitacora.Criticidad = 2.ToString();
            Bitacora.Usuario = UsuLog.UsuarioLogueado;
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
            throw new InformationException(My.Resources.ArchivoIdioma.BajaCliente);
            //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaCliente);
        }

        public static List<ClienteEN> BuscarCliente(string campo, string valor)
        {
            var ListaCliente = new List<ClienteEN>();
            var ListaCliProcesada = new List<ClienteEN>();
            if ((campo ?? "") == (My.Resources.ArchivoIdioma.CMBCuit ?? ""))
                //if ((campo ?? "") == (Negocios.My.Resources.ArchivoIdioma.CMBCuit ?? ""))
            {
                valor = Seguridad.Encriptar(valor);
            }

            ListaCliente = ClienteAD.BuscarCliente(campo, valor);
            foreach (ClienteEN item in ListaCliente)
            {
                var UnCliente = new ClienteEN();
                UnCliente.CodCli = item.CodCli;
                UnCliente.RazonSocial = item.RazonSocial;
                UnCliente.Cuit = Seguridad.Desencriptar(item.Cuit);
                UnCliente.Direccion = item.Direccion;
                UnCliente.Activo = item.Activo;
                UnCliente.Localidad = item.Localidad;
                ListaCliProcesada.Add(UnCliente);
            }

            return ListaCliProcesada;
        }

        public static List<ClienteEN> CargarCliente()
        {
            var ListaCliente = new List<ClienteEN>();
            var ListaCliProcesada = new List<ClienteEN>();
            ListaCliente = ClienteAD.CargarCliente();
            foreach (ClienteEN item in ListaCliente)
            {
                var UnCliente = new ClienteEN();
                UnCliente.CodCli = item.CodCli;
                UnCliente.RazonSocial = item.RazonSocial;
                UnCliente.Cuit = Seguridad.Desencriptar(item.Cuit);
                UnCliente.Direccion = item.Direccion;
                UnCliente.Activo = item.Activo;
                UnCliente.Localidad = item.Localidad;
                ListaCliProcesada.Add(UnCliente);
            }

            return ListaCliProcesada;
        }

        public static void EliminarTelefonoCliente(TelefonoEN UnTelefono)
        {
            var Bitacora = new BitacoraEN();
            ClienteAD.EliminarTelefonoCliente(UnTelefono);
            var UsuAut = Autenticar.Instancia();
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
           // throw new InformationException(Negocios.My.Resources.ArchivoIdioma.EliminarTelefono);
            throw new InformationException(My.Resources.ArchivoIdioma.EliminarTelefono);
        }

        /// <param name="Cliente"></param>
        public static void ModificarCliente(ClienteEN Cliente)
        {
            var ListaTelEncriptada = new List<TelefonoEN>();
            foreach (TelefonoEN item in Cliente.Telefono)
            {
                var UnTelefono = new TelefonoEN();
                UnTelefono.CodTel = item.CodTel;
                UnTelefono.CodEn = item.CodEn;
                UnTelefono.Numero = Seguridad.Encriptar(item.Numero);
                ListaTelEncriptada.Add(UnTelefono);
            }

            Cliente.Telefono = ListaTelEncriptada;
            ClienteAD.ModificarCliente(Cliente);
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Cliente";
            DVHDatos.CodReg = Cliente.CodCli;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatosCliente = new DVVEN();
            DVVDatosCliente.Tabla = "Cliente";
            DVVDatosCliente.TipoAccion = "Baja Modificar";
            DVVDatosCliente.ValorDVHAntiguo = ValorDVHAntiguo;
            DVVDatosCliente.ValorDVH = DVH;
            Integridad.GrabarDVV(DVVDatosCliente);
            var Bitacora = new BitacoraEN();
            var UsuAut = Autenticar.Instancia();
            Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del cliente: " + Cliente.RazonSocial);
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
            throw new InformationException(My.Resources.ArchivoIdioma.ModificarCliente);
            //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.ModificarCliente);
        }

        public static ClienteEN ObtenerCliente(string CUIT)
        {
            ClienteEN ClienteProcesado;
            int CodigoCliente = ClienteAD.ObtenerIDCliente(CUIT);
            ClienteProcesado = ClienteAD.ObtenerCliente(CodigoCliente);
            ClienteProcesado.Cuit = Seguridad.Desencriptar(ClienteProcesado.Cuit);
            return ClienteProcesado;
        }

        public static List<TelefonoEN> ObtenerTelefonoCliente(int CodCli)
        {
            var ListaTelProcesada = new List<TelefonoEN>();
            var Listatel = new List<TelefonoEN>();
            Listatel = ClienteAD.ObtenerTelefonoCliente(CodCli);
            foreach (TelefonoEN item in Listatel)
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
} // ClienteRN