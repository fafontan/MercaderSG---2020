using System.Collections.Generic;
using System.Data;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using Microsoft.VisualBasic.CompilerServices;
using ServiciosC;

namespace NegociosC
{
    public class UsuarioRN
    {
        public static void AltaPatenteUsuario(string UsuEnc, UsuarioEN PatUsu)
        {
            int CodUsu = UsuarioAD.ObtenerIDUsuario(UsuEnc);
            var UsuAut = Autenticar.Instancia();
            foreach (PatUsuEN item in PatUsu.UsuPatL)
            {
                var UnaPatUsu = new PatUsuEN();
                UnaPatUsu.CodPat = item.CodPat;
                if (UsuarioAD.ValidarUsuario(UsuEnc) > 0)
                {
                    if (UsuarioAD.AltaPatenteUsuario(CodUsu, UnaPatUsu) == true)
                    {
                        var DVHDatos = new DVHEN();
                        DVHDatos.Tabla = "Usu_Pat";
                        DVHDatos.CodReg = CodUsu;
                        DVHDatos.CodAux = UnaPatUsu.CodPat;
                        int DVHUsu_Pat = Integridad.CalcularDVH(DVHDatos);
                        int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVHUsu_Pat);
                        var DVVDatos = new DVVEN();
                        DVVDatos.Tabla = "Usu_Pat";
                        DVVDatos.TipoAccion = "Alta";
                        DVVDatos.ValorDVH = DVHUsu_Pat;
                        Integridad.GrabarDVV(DVVDatos);
                        var BitacoraUsu_Pat = new BitacoraEN();
                        BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Alta Patente - Usuario | Cod.Usu: " + CodUsu + " y Cod.Pat: " + UnaPatUsu.CodPat);
                        BitacoraUsu_Pat.Criticidad = 3.ToString();
                        BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado;
                        BitacoraAD.GrabarBitacora(BitacoraUsu_Pat);
                        var DVHDatosBitacora = new DVHEN();
                        DVHDatosBitacora.Tabla = "Bitacora";
                        DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit;
                        int DVHBitacoraUsu_Pat = Integridad.CalcularDVH(DVHDatosBitacora);
                        int ValorDVHAntiguoBit = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacoraUsu_Pat);
                        var DVVDatosBitacora = new DVVEN();
                        DVVDatosBitacora.Tabla = "Bitacora";
                        DVVDatosBitacora.ValorDVH = DVHBitacoraUsu_Pat;
                        DVVDatosBitacora.TipoAccion = "Alta";
                        Integridad.GrabarDVV(DVVDatosBitacora);
                    }
                    else
                    {
                        var DVHDatoFalso = new DVHEN();
                        DVHDatoFalso.Tabla = "Usu_Pat";
                        DVHDatoFalso.CodReg = CodUsu;
                        DVHDatoFalso.CodAux = UnaPatUsu.CodPat;
                        int DVHUsu_PatFalso = Integridad.CalcularDVH(DVHDatoFalso);
                        int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatoFalso, DVHUsu_PatFalso);
                        var DVVDatos = new DVVEN();
                        DVVDatos.Tabla = "Usu_Pat";
                        DVVDatos.TipoAccion = "Baja Modificar";
                        DVVDatos.ValorDVH = DVHUsu_PatFalso;
                        DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                        Integridad.GrabarDVV(DVVDatos);
                        var BitacoraUsu_Pat = new BitacoraEN();
                        BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Se asigno la Cod.Pat: " + UnaPatUsu.CodPat + " al Cod.Usu: " + CodUsu);
                        BitacoraUsu_Pat.Criticidad = 3.ToString();
                        BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado;
                        BitacoraAD.GrabarBitacora(BitacoraUsu_Pat);
                        var DVHDatosBitacora = new DVHEN();
                        DVHDatosBitacora.Tabla = "Bitacora";
                        DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit;
                        int DVHBitacoraUsu_Pat = Integridad.CalcularDVH(DVHDatosBitacora);
                        int ValorDVHAntiguoBit = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacoraUsu_Pat);
                        var DVVDatosBitacora = new DVVEN();
                        DVVDatosBitacora.Tabla = "Bitacora";
                        DVVDatosBitacora.ValorDVH = DVHBitacoraUsu_Pat;
                        DVVDatosBitacora.TipoAccion = "Alta";
                        Integridad.GrabarDVV(DVVDatosBitacora);
                    }
                }
                else
                {
                    throw new WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                    //throw new WarningException(NegociosC.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                }
            }
        }

        public static void AltaUsuario(UsuarioEN Usuario)
        {
            string UsuarioDesencriptado = Usuario.Usuario;
            Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario);
            Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña);
            if (UsuarioAD.ValidarUsuario(Usuario.Usuario) > 0)
            {
                throw new WarningException(My.Resources.ArchivoIdioma.UsuarioExistente);
                //throw new WarningException(NegociosC.My.Resources.ArchivoIdioma.UsuarioExistente);
                return;
            }
            else
            {
                var ListaTelefonoEncriptada = new List<TelefonoEN>();
                foreach (TelefonoEN item in Usuario.Telefono)
                {
                    var unTelefono = new TelefonoEN();
                    unTelefono.Numero = Seguridad.Encriptar(item.Numero);
                    ListaTelefonoEncriptada.Add(unTelefono);
                }

                Usuario.Telefono = ListaTelefonoEncriptada;
                UsuarioAD.AltaUsuario(Usuario);
                var UsuAut = Autenticar.Instancia();
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Usuario";
                DVHDatos.CodReg = Usuario.CodUsu;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Usuario";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatos);
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de usuario: " + UsuarioDesencriptado);
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
                throw new InformationException(My.Resources.ArchivoIdioma.AltaUsuario);
                //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaUsuario);
            }
        }

        public static void AltaUsuarioFamilia(string Usuario, UsuarioEN UsuFam)
        {
            var ListaMensajes = new List<UsuFamEN>();
            var UsuAut = Autenticar.Instancia();
            if (UsuarioAD.ValidarUsuario(Usuario) > 0)
            {
                int CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario);
                foreach (UsuFamEN item in UsuFam.UsuFamL)
                {
                    var UnUsuFam = new UsuFamEN();
                    UnUsuFam.CodFam = item.CodFam;
                    UnUsuFam.DescFam = item.DescFam;
                    if (UsuarioAD.ValidarUsuFam(CodUsu, UnUsuFam) > 0)
                    {
                        ListaMensajes.Add(UnUsuFam);
                    }
                    else if (UsuarioAD.AltaUsuarioFamilia(CodUsu, UnUsuFam) == true)
                    {
                        var DVHDatosFam = new DVHEN();
                        DVHDatosFam.Tabla = "Usu_Fam";
                        DVHDatosFam.CodReg = CodUsu;
                        DVHDatosFam.CodAux = UnUsuFam.CodFam;
                        int DVH = Integridad.CalcularDVH(DVHDatosFam);
                        int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatosFam, DVH);
                        var DVVDatos = new DVVEN();
                        DVVDatos.Tabla = "Usu_Fam";
                        DVVDatos.ValorDVH = DVH;
                        DVVDatos.TipoAccion = "Alta";
                        Integridad.GrabarDVV(DVVDatos);
                        var Bitacora = new BitacoraEN();
                        Bitacora.Descripcion = Seguridad.Encriptar("Alta Usuario - Familia | Cod.Usu: " + CodUsu + " y Cod.Fam: " + UnUsuFam.CodFam);
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
                    }
                }
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
            }

            if (ListaMensajes.Count > 0)
            {
                throw new WarningException(ListaMensajes);
            }
        }

        public static void BajaUsuario(UsuarioEN Usuario)
        {
            var UsuAut = Autenticar.Instancia();
            DataTable DTPatentesUsuario;
            DTPatentesUsuario = PatenteAD.ObtenerPatenteUsuario(Usuario.CodUsu);
            bool EstadoPat = true;
            foreach (DataRow Row in DTPatentesUsuario.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 22, false)))
                {
                    if (UsuarioAD.VerificarPatentesUsuario(22))
                    {
                        EstadoPat = true;
                        continue;
                    }
                    else
                    {
                        EstadoPat = false;
                        break;
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 29, false)))
                {
                    if (UsuarioAD.VerificarPatentesUsuario(29))
                    {
                        EstadoPat = true;
                        continue;
                    }
                    else
                    {
                        EstadoPat = false;
                        break;
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 37, false)))
                {
                    if (UsuarioAD.VerificarPatentesUsuario(37))
                    {
                        EstadoPat = true;
                        continue;
                    }
                    else
                    {
                        EstadoPat = false;
                        break;
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 39, false)))
                {
                    if (UsuarioAD.VerificarPatentesUsuario(39))
                    {
                        EstadoPat = true;
                        continue;
                    }
                    else
                    {
                        EstadoPat = false;
                        break;
                    }
                }
            }

            if (EstadoPat)
            {

                // UsuFam
                var ListaUsuFam = new List<UsuFamEN>();
                ListaUsuFam = FamiliaAD.ObtenerFamiliaUsuario(Usuario.CodUsu);
                foreach (UsuFamEN item in ListaUsuFam)
                {
                    var UnaUsuFam = new UsuFamEN();
                    UnaUsuFam.CodUsu = item.CodUsu;
                    UnaUsuFam.CodFam = item.CodFam;
                    var DVHDatosUsuFam = new DVHEN();
                    DVHDatosUsuFam.Tabla = "Usu_Fam";
                    DVHDatosUsuFam.CodReg = UnaUsuFam.CodUsu;
                    DVHDatosUsuFam.CodAux = UnaUsuFam.CodFam;
                    int DVHUsuFam = Integridad.ObtenerDVHRegistro(DVHDatosUsuFam);
                    FamiliaAD.EliminarUsuarioFamilia(UnaUsuFam);
                    var DVVDatosUsuFam = new DVVEN();
                    DVVDatosUsuFam.Tabla = "Usu_Fam";
                    DVVDatosUsuFam.ValorDVH = DVHUsuFam;
                    DVVDatosUsuFam.TipoAccion = "Eliminar";
                    Integridad.GrabarDVV(DVVDatosUsuFam);
                }

                // UsuPat
                var ListaPatUsu = new List<PatUsuEN>();
                ListaPatUsu = UsuarioAD.ObtenerPatentesUsuario(Usuario.CodUsu);
                foreach (PatUsuEN item in ListaPatUsu)
                {
                    var UnaPatUsu = new PatUsuEN();
                    UnaPatUsu.CodUsu = item.CodUsu;
                    UnaPatUsu.CodPat = item.CodPat;
                    var DVHDatosPatUsu = new DVHEN();
                    DVHDatosPatUsu.Tabla = "Usu_Pat";
                    DVHDatosPatUsu.CodReg = UnaPatUsu.CodUsu;
                    DVHDatosPatUsu.CodAux = UnaPatUsu.CodPat;
                    int DVHPatUsu = Integridad.ObtenerDVHRegistro(DVHDatosPatUsu);
                    UsuarioAD.EliminarPatentesUsuario(UnaPatUsu);
                    var DVVDatosPatUsu = new DVVEN();
                    DVVDatosPatUsu.Tabla = "Usu_Pat";
                    DVVDatosPatUsu.ValorDVH = DVHPatUsu;
                    DVVDatosPatUsu.TipoAccion = "Eliminar";
                    Integridad.GrabarDVV(DVVDatosPatUsu);
                }

                UsuarioAD.BajaUsuario(Usuario);
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Usuario";
                DVHDatos.CodReg = Usuario.CodUsu;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguoUsu = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Usuario";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Baja Modificar";
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguoUsu;
                Integridad.GrabarDVV(DVVDatos);
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Baja de usuario: " + Usuario.Usuario);
                Bitacora.Criticidad = 2.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBitBit = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosBitacora);
                throw new InformationException(My.Resources.ArchivoIdioma.BajaUsuario);
                //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaUsuario);
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.PrivilegiosUsuario);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.PrivilegiosUsuario);
                return;
            }
        }

        public static List<UsuarioEN> BuscarUsuario(string campo, string texto)
        {
            var ListaUsuarios = new List<UsuarioEN>();
            var ListaUsuProcesada = new List<UsuarioEN>();
            var Seguridad = new Seguridad();
            if ((campo ?? "") == (My.Resources.ArchivoIdioma.CMBUsuario ?? ""))
            //if ((campo ?? "") == (Negocios.My.Resources.ArchivoIdioma.CMBUsuario ?? ""))
            {
                texto = ServiciosC.Seguridad.Encriptar(texto);
            }

            ListaUsuarios = UsuarioAD.BuscarUsuario(campo, texto);
            foreach (UsuarioEN item in ListaUsuarios)
            {
                var UnUsuario = new UsuarioEN();
                UnUsuario.CodUsu = item.CodUsu;
                UnUsuario.Usuario = ServiciosC.Seguridad.Desencriptar(item.Usuario);
                UnUsuario.Apellido = item.Apellido;
                UnUsuario.Nombre = item.Nombre;
                UnUsuario.CorreoElectronico = item.CorreoElectronico;
                UnUsuario.Edad = item.Edad;
                ListaUsuProcesada.Add(UnUsuario);
            }

            return ListaUsuProcesada;
        }

        public static void CambiarContraseña(string UsuarioLogueado, string ContraseñaAnterior, string NuevaContraseña)
        {
            string UsuEnc = Seguridad.Encriptar(UsuarioLogueado);
            string ConAntEnc = Seguridad.EncriptarMD5(ContraseñaAnterior);
            string NuevaCon = Seguridad.EncriptarMD5(NuevaContraseña);
            if (UsuarioAD.ValidarContraseña(UsuEnc, ConAntEnc) > 0)
            {
                UsuarioAD.CambiarContraseña(UsuEnc, NuevaCon);
                var UsuAut = Autenticar.Instancia();
                var DVHDatos = new DVHEN();
                DVHDatos.Tabla = "Usuario";
                DVHDatos.CodReg = UsuAut.CodUsuLogueado;
                int DVH = Integridad.CalcularDVH(DVHDatos);
                int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                var DVVDatos = new DVVEN();
                DVVDatos.Tabla = "Usuario";
                DVVDatos.ValorDVH = DVH;
                DVVDatos.TipoAccion = "Baja Modificar";
                DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                Integridad.GrabarDVV(DVVDatos);
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Cambio su contraseña");
                Bitacora.Criticidad = 3.ToString();
                Bitacora.Usuario = UsuarioLogueado;
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
                throw new InformationException(My.Resources.ArchivoIdioma.ContraseñaCambiada);
                //throw new InformationException(NegociosC.My.Resources.ArchivoIdioma.ContraseñaCambiada);
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.ContraseñaInvalida);
                //throw new WarningException(NegociosC.My.Resources.ArchivoIdioma.ContraseñaInvalida);
            }
        }

        public static List<UsuarioEN> CargarUsuario()
        {
            var ListaUsuarios = new List<UsuarioEN>();
            var ListaUsuProcesada = new List<UsuarioEN>();
            ListaUsuarios = UsuarioAD.CargarUsuario();
            foreach (UsuarioEN item in ListaUsuarios)
            {
                var UnUsuario = new UsuarioEN();
                UnUsuario.CodUsu = item.CodUsu;
                UnUsuario.Usuario = Seguridad.Desencriptar(item.Usuario);
                UnUsuario.Apellido = item.Apellido;
                UnUsuario.Nombre = item.Nombre;
                UnUsuario.CorreoElectronico = item.CorreoElectronico;
                UnUsuario.Edad = item.Edad;
                UnUsuario.Bloqueado = item.Bloqueado;
                ListaUsuProcesada.Add(UnUsuario);
            }

            return ListaUsuProcesada;
        }

        public static void DenegarPatenteUsuario(string UsuEnc, UsuarioEN PatUsu)
        {
            int CodUsu = UsuarioAD.ObtenerIDUsuario(UsuEnc);
            var UsuAut = Autenticar.Instancia();
            foreach (PatUsuEN item in PatUsu.UsuPatL)
            {
                var UnaPatUsu = new PatUsuEN();
                UnaPatUsu.CodPat = item.CodPat;
                bool EstadoPat = true;
                if (item.CodPat == 22)
                {
                    if (UsuarioAD.VerificarPatentesUsuario(22))
                    {
                        EstadoPat = true;
                    }
                    else
                    {
                        EstadoPat = false;
                    }
                }

                if (item.CodPat == 29)
                {
                    if (UsuarioAD.VerificarPatentesUsuario(29))
                    {
                        EstadoPat = true;
                    }
                    else
                    {
                        EstadoPat = false;
                    }
                }

                if (item.CodPat == 37)
                {
                    if (UsuarioAD.VerificarPatentesUsuario(37))
                    {
                        EstadoPat = true;
                    }
                    else
                    {
                        EstadoPat = false;
                    }
                }

                if (item.CodPat == 39)
                {
                    if (UsuarioAD.VerificarPatentesUsuario(39))
                    {
                        EstadoPat = true;
                    }
                    else
                    {
                        EstadoPat = false;
                    }
                }

                if (EstadoPat)
                {
                    UsuarioAD.DenegarPatenteUsuario(CodUsu, UnaPatUsu);
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usu_Pat";
                    DVHDatos.CodReg = CodUsu;
                    DVHDatos.CodAux = UnaPatUsu.CodPat;
                    int DVHUsu_Pat = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVHUsu_Pat);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usu_Pat";
                    DVVDatos.ValorDVH = DVHUsu_Pat;
                    DVVDatos.TipoAccion = "Baja Modificar";
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                    Integridad.GrabarDVV(DVVDatos);
                    var BitacoraUsu_Pat = new BitacoraEN();
                    BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Denego Patente - Usuario | Cod.Pat: " + UnaPatUsu.CodPat + " del Cod.Usu: " + CodUsu);
                    BitacoraUsu_Pat.Criticidad = 2.ToString();
                    BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado;
                    BitacoraAD.GrabarBitacora(BitacoraUsu_Pat);
                    var DVHDatosBitacora = new DVHEN();
                    DVHDatosBitacora.Tabla = "Bitacora";
                    DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit;
                    int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                    int ValorDVHAntiguoBit = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                    var DVVDatosBitacora = new DVVEN();
                    DVVDatosBitacora.Tabla = "Bitacora";
                    DVVDatosBitacora.ValorDVH = DVHBitacora;
                    DVVDatosBitacora.TipoAccion = "Alta";
                    Integridad.GrabarDVV(DVVDatosBitacora);
                }
                else
                {
                    continue;
                }
            }
        }

        public static void DesbloquearUsuario(string Usuario)
        {
            string UsuarioDesencriptado = Usuario;
            Usuario = Seguridad.Encriptar(Usuario);
            int CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario);
            UsuarioAD.DesbloquearUsuario(Usuario);
            var UsuAut = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Usuario";
            DVHDatos.CodReg = CodUsu;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Usuario";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            DVVDatos.TipoAccion = "Baja Modificar";
            Integridad.GrabarDVV(DVVDatos);
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Desbloqueo al usuario: " + UsuarioDesencriptado);
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
            throw new InformationException(My.Resources.ArchivoIdioma.DesbloquearUsuario);
            //throw new InformationException(NegociosC.My.Resources.ArchivoIdioma.DesbloquearUsuario);
        }

        public static void EliminarTelefonoUsuario(TelefonoEN UnTelefono)
        {
            var Bitacora = new BitacoraEN();
            UsuarioAD.EliminarTelefonoUsuario(UnTelefono);
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
            throw new InformationException(My.Resources.ArchivoIdioma.EliminarTelefono);
            //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.EliminarTelefono);
        }

        public static bool Logueo(UsuarioEN Usuario)
        {
            var Bitacora = new BitacoraEN();
            string UsuarioDesencriptado = Usuario.Usuario;
            Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario);
            Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña);
            int CodUsu;
            if (UsuarioAD.ObtenerCIIUsuario(Usuario.Usuario) < 3)
            {
                CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario.Usuario);
                Usuario.CodUsu = CodUsu;
                if (UsuarioAD.Logueo(Usuario) == false)
                {
                    UsuarioAD.ModificarCIIUsuario(Usuario.Usuario);
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usuario";
                    DVHDatos.CodReg = Usuario.CodUsu;
                    int DVH = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usuario";
                    DVVDatos.TipoAccion = "Baja Modificar";
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                    DVVDatos.ValorDVH = DVH;
                    Integridad.GrabarDVV(DVVDatos);
                    Bitacora.Descripcion = Seguridad.Encriptar("Error al ingresar al sistema");
                    Bitacora.Criticidad = 2.ToString();
                    Bitacora.Usuario = UsuarioDesencriptado;
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
                    return false;
                }
                else
                {
                    UsuarioAD.ResetearCII(Usuario.Usuario);
                    var UsuAut = Autenticar.Instancia();
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usuario";
                    DVHDatos.CodReg = Usuario.CodUsu;
                    int DVH = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usuario";
                    DVVDatos.TipoAccion = "Baja Modificar";
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                    DVVDatos.ValorDVH = DVH;
                    Integridad.GrabarDVV(DVVDatos);
                    UsuAut.UsuarioLogueado = Seguridad.Desencriptar(Usuario.Usuario);
                    UsuAut.CodUsuLogueado = Usuario.CodUsu;
                    Bitacora.Descripcion = Seguridad.Encriptar("Ingresó al sistema");
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
                    return true;
                }
            }
            else
            {
                CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario.Usuario);
                Usuario.CodUsu = CodUsu;
                DataTable DTPatentesUsuario;
                DTPatentesUsuario = PatenteAD.ObtenerPatenteUsuario(Usuario.CodUsu);
                bool EstadoPat = true;
                foreach (DataRow Row in DTPatentesUsuario.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 22, false)))
                    {
                        if (UsuarioAD.VerificarPatentesUsuario(22))
                        {
                            EstadoPat = true;
                            continue;
                        }
                        else
                        {
                            EstadoPat = false;
                            break;
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 29, false)))
                    {
                        if (UsuarioAD.VerificarPatentesUsuario(29))
                        {
                            EstadoPat = true;
                            continue;
                        }
                        else
                        {
                            EstadoPat = false;
                            break;
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 37, false)))
                    {
                        if (UsuarioAD.VerificarPatentesUsuario(37))
                        {
                            EstadoPat = true;
                            continue;
                        }
                        else
                        {
                            EstadoPat = false;
                            break;
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Row["CodPat"], 39, false)))
                    {
                        if (UsuarioAD.VerificarPatentesUsuario(39))
                        {
                            EstadoPat = true;
                            continue;
                        }
                        else
                        {
                            EstadoPat = false;
                            break;
                        }
                    }
                }

                if (EstadoPat)
                {
                    UsuarioAD.BloquearUsuario(Usuario.Usuario);
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usuario";
                    DVHDatos.CodReg = Usuario.CodUsu;
                    int DVH = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usuario";
                    DVVDatos.ValorDVH = DVH;
                    DVVDatos.TipoAccion = "Baja Modificar";
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                    Integridad.GrabarDVV(DVVDatos);
                    Bitacora.Descripcion = Seguridad.Encriptar("Se ha bloqueado al usuario");
                    Bitacora.Criticidad = 2.ToString();
                    Bitacora.Usuario = UsuarioDesencriptado;
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
                    throw new CriticalException(My.Resources.ArchivoIdioma.UsuarioBloqueado);
                    //throw new CriticalException(Negocios.My.Resources.ArchivoIdioma.UsuarioBloqueado);
                }
                else
                {
                    UsuarioAD.ResetearCII(Usuario.Usuario);
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usuario";
                    DVHDatos.CodReg = Usuario.CodUsu;
                    int DVH = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usuario";
                    DVVDatos.ValorDVH = DVH;
                    DVVDatos.TipoAccion = "Baja Modificar";
                    DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
                    Integridad.GrabarDVV(DVVDatos);
                    throw new WarningException(My.Resources.ArchivoIdioma.UsuarioRevision);
                    //throw new WarningException(NegociosC.My.Resources.ArchivoIdioma.UsuarioRevision);
                }
            }
        }

        public static void ModificarUsuario(UsuarioEN Usuario)
        {
            var ListaTelefonoEncriptada = new List<TelefonoEN>();
            string UsuarioDesencriptado = Usuario.Usuario;
            Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario);
            foreach (TelefonoEN item in Usuario.Telefono)
            {
                var UnTelefono = new TelefonoEN();
                UnTelefono.CodTel = item.CodTel;
                UnTelefono.CodEn = item.CodEn;
                UnTelefono.Numero = Seguridad.Encriptar(item.Numero);
                ListaTelefonoEncriptada.Add(UnTelefono);
            }

            Usuario.Telefono = ListaTelefonoEncriptada;
            UsuarioAD.ModificarUsuario(Usuario);
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Usuario";
            DVHDatos.CodReg = Usuario.CodUsu;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Usuario";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            Integridad.GrabarDVV(DVVDatos);
            var UsuAut = Autenticar.Instancia();
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos del usuario: " + UsuarioDesencriptado);
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
            throw new InformationException(My.Resources.ArchivoIdioma.ModificarUsuario);
            //throw new InformationException(NegociosC.My.Resources.ArchivoIdioma.ModificarUsuario);
        }

        public static List<TelefonoEN> ObtenerTelefonoUsuario(int CodUsuario)
        {
            var ListaTelProcesada = new List<TelefonoEN>();
            var ListaTelefonos = new List<TelefonoEN>();
            ListaTelefonos = UsuarioAD.ObtenerTelefonoUsuario(CodUsuario);
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

        public static UsuarioEN ObtenerUsuario(string Usuario)
        {
            UsuarioEN UsuarioProcesado;
            int CodigoUsuario = UsuarioAD.ObtenerIDUsuario(Usuario);
            UsuarioProcesado = UsuarioAD.ObtenerUsuario(CodigoUsuario);
            UsuarioProcesado.Usuario = Seguridad.Desencriptar(UsuarioProcesado.Usuario);
            return UsuarioProcesado;
        }

        public static void ResetearContraseña(UsuarioEN Usuario)
        {
            string UsuarioDesencriptado = Usuario.Usuario;
            Usuario.Usuario = Seguridad.Encriptar(Usuario.Usuario);
            Usuario.Contraseña = Seguridad.EncriptarMD5(Usuario.Contraseña);
            UsuarioAD.ResetearContraseña(Usuario);
            var UsuAut = Autenticar.Instancia();
            var DVHDatos = new DVHEN();
            DVHDatos.Tabla = "Usuario";
            DVHDatos.CodReg = Usuario.CodUsu;
            int DVH = Integridad.CalcularDVH(DVHDatos);
            int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
            var DVVDatos = new DVVEN();
            DVVDatos.Tabla = "Usuario";
            DVVDatos.ValorDVH = DVH;
            DVVDatos.TipoAccion = "Baja Modificar";
            DVVDatos.ValorDVHAntiguo = ValorDVHAntiguo;
            Integridad.GrabarDVV(DVVDatos);
            if (Usuario.TipoAccion == false)
            {
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Cambió la contraseña de: " + UsuarioDesencriptado);
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
            }
            throw new InformationException(My.Resources.ArchivoIdioma.ResetContrasena);
            //throw new InformationException(Negocios.My.Resources.ArchivoIdioma.ResetContrasena);
        }

        public static List<string> ObtenerUsuariosErrorIntegridad()
        {
            var ListaUsuarios = new List<string>();
            var ListaUsuariosDesencriptada = new List<string>();
            ListaUsuarios = UsuarioAD.ObtenerUsuariosErrorIntegridad();
            foreach (string item in ListaUsuarios)
            {
                string UsuDesencriptado;
                UsuDesencriptado = Seguridad.Desencriptar(item);
                ListaUsuariosDesencriptada.Add(UsuDesencriptado);
            }

            return ListaUsuariosDesencriptada;
        }
    }
}