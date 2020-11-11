using System.Collections.Generic;
using DatosC;
using EntidadesC;
using ExcepcionesC;
using ServiciosC;

namespace NegociosC
{
    public class FamiliaRN
    {
        public static void AltaFamilia(FamiliaEN Familia)
        {
            string FamiliaDesencriptada = Familia.Descripcion;
            Familia.Descripcion = Seguridad.Encriptar(Familia.Descripcion);
            if (FamiliaAD.ValidarFamilia(Familia.Descripcion) > 0)
            {
                throw new WarningException(NegociosC.My.Resources.ArchivoIdioma.FamiliaExistente);
                return;
            }
            else
            {
                FamiliaAD.AltaFamilia(Familia);
                var UsuAut = Autenticar.Instancia();
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Alta de Familia: " + FamiliaDesencriptada);
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
                throw new InformationException(Negocios.My.Resources.ArchivoIdioma.AltaFamilia);
            }
        }

        /// <param name="FamiliaPatente"></param>
        public static void AltaFamiliaPatente(FamiliaEN FamiliaPatente)
        {
            var UsuAut = Autenticar.Instancia();
            foreach (FamPatEN item in FamiliaPatente.FamPatL)
            {
                var UnaFamPat = new FamPatEN();
                UnaFamPat.CodFam = item.CodFam;
                UnaFamPat.CodPat = item.CodPat;
                UnaFamPat.DescPat = item.DescPat;
                if (!(FamiliaAD.ValidarPatente(UnaFamPat) > 0))
                {
                    FamiliaAD.AltaFamiliaPatente(UnaFamPat);
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Fam_Pat";
                    DVHDatos.CodReg = UnaFamPat.CodFam;
                    DVHDatos.CodAux = UnaFamPat.CodPat;
                    int DVH = Integridad.CalcularDVH(DVHDatos);
                    int ValorDVHAntiguo = Integridad.GrabarDVH(DVHDatos, DVH);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Fam_Pat";
                    DVVDatos.TipoAccion = "Alta";
                    DVVDatos.ValorDVH = DVH;
                    Integridad.GrabarDVV(DVVDatos);
                    var Bitacora = new BitacoraEN();
                    Bitacora.Descripcion = Seguridad.Encriptar("Alta de Patente - Familia | Cod.Fam: " + UnaFamPat.CodFam + " y Cod.Pat: " + UnaFamPat.CodPat);
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

        /// <param name="Familia"></param>
        public static void BajaFamilia(FamiliaEN Familia)
        {
            var UsuAut = Autenticar.Instancia();
            if (SePuedeEliminarFamilia(Familia.CodFam) == true)
            {

                // FamPat
                var ListaFamPat = new List<FamPatEN>();
                ListaFamPat = FamiliaAD.ObtenerFamiliaPatente(Familia.CodFam);
                foreach (FamPatEN item in ListaFamPat)
                {
                    var UnaFamPat = new FamPatEN();
                    UnaFamPat.CodFam = item.CodFam;
                    UnaFamPat.CodPat = item.CodPat;
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Fam_Pat";
                    DVHDatos.CodReg = UnaFamPat.CodFam;
                    DVHDatos.CodAux = UnaFamPat.CodPat;
                    int DVHFamPat = Integridad.ObtenerDVHRegistro(DVHDatos);
                    FamiliaAD.EliminarFamiliaPatente(UnaFamPat);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Fam_Pat";
                    DVVDatos.ValorDVH = DVHFamPat;
                    DVVDatos.TipoAccion = "Eliminar";
                    Integridad.GrabarDVV(DVVDatos);
                }

                // UsuFam
                var ListaUsuFam = new List<UsuFamEN>();
                ListaUsuFam = FamiliaAD.ObtenerUsuarioFamilia(Familia.CodFam);
                foreach (UsuFamEN item in ListaUsuFam)
                {
                    var UnaUsuFam = new UsuFamEN();
                    UnaUsuFam.CodUsu = item.CodUsu;
                    UnaUsuFam.CodFam = item.CodFam;
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Usu_Fam";
                    DVHDatos.CodReg = UnaUsuFam.CodUsu;
                    DVHDatos.CodAux = UnaUsuFam.CodFam;
                    int DVHFamPat = Integridad.ObtenerDVHRegistro(DVHDatos);
                    FamiliaAD.EliminarUsuarioFamilia(UnaUsuFam);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Usu_Fam";
                    DVVDatos.ValorDVH = DVHFamPat;
                    DVVDatos.TipoAccion = "Eliminar";
                    Integridad.GrabarDVV(DVVDatos);
                }

                FamiliaAD.BajaFamilia(Familia);
                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = Seguridad.Encriptar("Baja de familia: " + Familia.Descripcion);
                Bitacora.Criticidad = 2.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                Integridad.GrabarDVV(DVVDatosBitacora);
                throw new InformationException(Negocios.My.Resources.ArchivoIdioma.BajaFamilia);
            }
            else
            {
                throw new WarningException(Negocios.My.Resources.ArchivoIdioma.PrivilegiosFamilia);
                return;
            }
        }

        public static bool SePuedeEliminarFamilia(int CodFam)
        {
            foreach (int i in new[] { 22, 29, 37, 39 })
            {
                if (FamiliaAD.VerificarPatentesFamilia(CodFam, i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<FamiliaEN> CargarFamilia()
        {
            var ListaFamilia = new List<FamiliaEN>();
            var ListaFamiliaProcesada = new List<FamiliaEN>();
            ListaFamilia = FamiliaAD.CargarFamilia();
            foreach (FamiliaEN item in ListaFamilia)
            {
                var UnaFamilia = new FamiliaEN();
                UnaFamilia.CodFam = item.CodFam;
                UnaFamilia.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                ListaFamiliaProcesada.Add(UnaFamilia);
            }

            return ListaFamiliaProcesada;
        }

        public static List<FamiliaEN> CargarFamiliaConPatentes()
        {
            var ListaFamilia = new List<FamiliaEN>();
            var ListaFamiliaProcesada = new List<FamiliaEN>();
            ListaFamilia = FamiliaAD.CargarFamiliaConPatentes();
            foreach (FamiliaEN item in ListaFamilia)
            {
                var UnaFamilia = new FamiliaEN();
                UnaFamilia.CodFam = item.CodFam;
                UnaFamilia.Descripcion = Seguridad.Desencriptar(item.Descripcion);
                ListaFamiliaProcesada.Add(UnaFamilia);
            }

            return ListaFamiliaProcesada;
        }

        public static void ModificarFamilia(FamiliaEN Familia)
        {
            string FamiliaDesencriptada = Familia.Descripcion;
            Familia.Descripcion = Seguridad.Encriptar(Familia.Descripcion);
            FamiliaAD.ModificarFamilia(Familia);
            var UsuAut = Autenticar.Instancia();
            var Bitacora = new BitacoraEN();
            Bitacora.Descripcion = Seguridad.Encriptar("Actualizó los datos de la familia: " + FamiliaDesencriptada);
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
            throw new InformationException(Negocios.My.Resources.ArchivoIdioma.ModificarFamilia);
        }

        public static FamiliaEN ObtenerFamilia(string Descripcion)
        {
            var FamiliaProcesada = new FamiliaEN();
            FamiliaProcesada = FamiliaAD.ObtenerFamilia(Descripcion);
            FamiliaProcesada.Descripcion = Seguridad.Desencriptar(FamiliaProcesada.Descripcion);
            return FamiliaProcesada;
        }

        public static void BajaFamiliaPatente(string Fam, FamiliaEN BajaFamPat)
        {
            var UsuAut = Autenticar.Instancia();
            Fam = Seguridad.Encriptar(Fam);
            int CodFam = FamiliaAD.ObtenerIDFamilia(Fam);
            foreach (FamPatEN item in BajaFamPat.FamPatL)
            {
                var UnaFamPat = new FamPatEN();
                UnaFamPat.CodPat = item.CodPat;
                if (SePuedeQuitarPatente(CodFam))
                {
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = "Fam_Pat";
                    DVHDatos.CodReg = CodFam;
                    DVHDatos.CodAux = UnaFamPat.CodPat;
                    int DVHFamPat = Integridad.ObtenerDVHRegistro(DVHDatos);
                    FamiliaAD.BajaFamiliaPatente(CodFam, UnaFamPat);
                    var DVVDatos = new DVVEN();
                    DVVDatos.Tabla = "Fam_Pat";
                    DVVDatos.ValorDVH = DVHFamPat;
                    DVVDatos.TipoAccion = "Eliminar";
                    Integridad.GrabarDVV(DVVDatos);
                    var BitacoraUsu_Pat = new BitacoraEN();
                    BitacoraUsu_Pat.Descripcion = Seguridad.Encriptar("Eliminó Patente - Familia | Cod.Fam: " + CodFam + " y Cod.Pat: " + UnaFamPat.CodPat);
                    BitacoraUsu_Pat.Criticidad = 2.ToString();
                    BitacoraUsu_Pat.Usuario = UsuAut.UsuarioLogueado;
                    BitacoraAD.GrabarBitacora(BitacoraUsu_Pat);
                    var DVHDatosBitacora = new DVHEN();
                    DVHDatosBitacora.Tabla = "Bitacora";
                    DVHDatosBitacora.CodReg = BitacoraUsu_Pat.CodBit;
                    int DVHBitacora = Integridad.CalcularDVH(DVHDatosBitacora);
                    int DVHBitacoraInt = Integridad.GrabarDVH(DVHDatosBitacora, DVHBitacora);
                    var DVVDatosBitacora = new DVVEN();
                    DVVDatosBitacora.Tabla = "Bitacora";
                    DVVDatosBitacora.ValorDVH = DVHBitacora;
                    DVVDatosBitacora.TipoAccion = "Alta";
                    Integridad.GrabarDVV(DVVDatosBitacora);
                }
            }
        }

        public static bool SePuedeQuitarPatente(int CodFam)
        {
            foreach (int i in new[] { 22, 29, 37, 39 })
            {
                if (FamiliaAD.VerificarPatentesFamilia(CodFam, i) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
} // FamiliaRN