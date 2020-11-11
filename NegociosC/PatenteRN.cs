using System.Collections.Generic;
using System.Data;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using ServiciosC;

namespace NegociosC
{
    public class PatenteRN
    {
        public static List<PatenteEN> CargarPatente()
        {
            var ListaPatentes = new List<PatenteEN>();
            ListaPatentes = PatenteAD.CargarPatente();
            return ListaPatentes;
        }

        public static List<PatenteEN> CargarPatente(string Usuario)
        {
            int CodUsu;
            var ListaPatente = new List<PatenteEN>();
            var ListaPatenteProcesada = new List<PatenteEN>();
            if (UsuarioAD.ValidarUsuario(Usuario) > 0)
            {
                CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario);
                ListaPatente = PatenteAD.CargarPatente(CodUsu);
                foreach (PatenteEN item in ListaPatente)
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = item.CodPat;
                    UnaPatente.Descripcion = item.Descripcion;
                    ListaPatenteProcesada.Add(UnaPatente);
                }
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
            }

            return ListaPatenteProcesada;
        }

        public static DataTable ObtenerPatenteUsuario(int CodUsu)
        {
            return PatenteAD.ObtenerPatenteUsuario(CodUsu);
        }

        public static List<PatenteEN> CargarPatenteUsuario(string Usuario)
        {
            int CodUsu;
            var ListaPatente = new List<PatenteEN>();
            var ListaPatenteProcesada = new List<PatenteEN>();
            if (UsuarioAD.ValidarUsuario(Usuario) > 0)
            {
                CodUsu = UsuarioAD.ObtenerIDUsuario(Usuario);
                ListaPatente = PatenteAD.CargarPatenteUsuario(CodUsu);
                foreach (PatenteEN item in ListaPatente)
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = item.CodPat;
                    UnaPatente.Descripcion = item.Descripcion;
                    ListaPatenteProcesada.Add(UnaPatente);
                }
            }
            else
            {
                throw new WarningException(My.Resources.ArchivoIdioma.UsuarioDadoBaja);
                //throw new WarningException(Negocios.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
            }

            return ListaPatenteProcesada;
        }

        public static List<PatenteEN> CargarPatentesFamilia(string Fam)
        {
            int CodFam;
            Fam = Seguridad.Encriptar(Fam);
            var ListaPatente = new List<PatenteEN>();
            var ListaPatenteProcesada = new List<PatenteEN>();
            if (FamiliaAD.ValidarFamilia(Fam) > 0)
            {
                CodFam = FamiliaAD.ObtenerIDFamilia(Fam);
                ListaPatente = PatenteAD.CargarPatentesFamilia(CodFam);
                foreach (PatenteEN item in ListaPatente)
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = item.CodPat;
                    UnaPatente.Descripcion = item.Descripcion;
                    ListaPatenteProcesada.Add(UnaPatente);
                }
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.FamiliaInexistente);
            }

            return ListaPatenteProcesada;
        }

        public static List<PatenteEN> CargarNoPatentesFamilia(string Fam)
        {
            int CodFam;
            Fam = Seguridad.Encriptar(Fam);
            var ListaPatente = new List<PatenteEN>();
            var ListaPatenteProcesada = new List<PatenteEN>();
            if (FamiliaAD.ValidarFamilia(Fam) > 0)
            {
                CodFam = FamiliaAD.ObtenerIDFamilia(Fam);
                ListaPatente = PatenteAD.CargarNoPatentesFamilia(CodFam);
                foreach (PatenteEN item in ListaPatente)
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = item.CodPat;
                    UnaPatente.Descripcion = item.Descripcion;
                    ListaPatenteProcesada.Add(UnaPatente);
                }
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.FamiliaInexistente);
            }

            return ListaPatenteProcesada;
        }

        public static List<PatenteEN> CargarPatentesDenegadasUsuario(string UsuEnc)
        {
            int CodUsu;
            var ListaPatente = new List<PatenteEN>();
            var ListaPatenteProcesada = new List<PatenteEN>();
            if (UsuarioAD.ValidarUsuario(UsuEnc) > 0)
            {
                CodUsu = UsuarioAD.ObtenerIDUsuario(UsuEnc);
                ListaPatente = PatenteAD.CargarPatenteDenegadasUsuario(CodUsu);
                foreach (PatenteEN item in ListaPatente)
                {
                    var UnaPatente = new PatenteEN();
                    UnaPatente.CodPat = item.CodPat;
                    UnaPatente.Descripcion = item.Descripcion;
                    ListaPatenteProcesada.Add(UnaPatente);
                }
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.UsuarioDadoBaja);
            }

            return ListaPatenteProcesada;
        }

        public static bool ObtenerPatentesFamilia(int CodFam)
        {
            return PatenteAD.ObtenerPatentesFamilia(CodFam);
        }
    }
} // PatenteRN