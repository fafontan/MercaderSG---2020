using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Servicios
{
    public class Integridad
    {
        public static int CalcularDVH(DVHEN DVH)
        {
            string Cadena;
            Cadena = ServicioAD.CalcularDVH(DVH);
            int Sumatoria = 0;
            int e = 1;
            Cadena = Strings.StrReverse(Cadena);
            for (int i = 0, loopTo = Cadena.Length - 1; i <= loopTo; i++)
            {
                e += 1;
                if (e == 8)
                {
                    e = 2;
                }

                if (Information.IsNumeric(Cadena[i]))
                {
                    Sumatoria += Conversion.Val(Cadena[i]) * e;
                }
                else
                {
                    Sumatoria += Strings.Asc(Cadena[i]) * e;
                }
            }

            double M11;
            M11 = Sumatoria / 11d;
            int M11Entero = (int)Conversion.Int(M11);
            int ResultadoM11;
            ResultadoM11 = M11Entero * 11;
            int Resto = Sumatoria - ResultadoM11;
            return Resto;
        }

        public static int GrabarDVH(DVHEN DVH, int ValorDVH)
        {
            return ServicioAD.GrabarDVH(DVH, ValorDVH);
        }

        public static ErrorIntegridadEN VerificarIntegridad(DVHEN DatosDVHParam)
        {
            try
            {
                var ListaCod = new List<DVHEN>();
                var ErrorInt = new ErrorIntegridadEN();
                var DVHGral = new DVHEN();
                DVHGral.Tabla = DatosDVHParam.Tabla;
                ListaCod = ServicioAD.ObtenerRegistros(DatosDVHParam);
                foreach (DVHEN item in ListaCod)
                {
                    var DVHDatos = new DVHEN();
                    DVHDatos.Tabla = DatosDVHParam.Tabla;
                    DVHDatos.CodReg = item.CodReg;
                    DVHDatos.Columna = DatosDVHParam.Columna;
                    if (DatosDVHParam.Tabla == "Fam_Pat" | DatosDVHParam.Tabla == "Usu_Pat" | DatosDVHParam.Tabla == "Usu_Fam")
                    {
                        DVHDatos.CodAux = item.CodAux;
                    }

                    int DVHComparar = CalcularDVH(DVHDatos);
                    int DVHActual = ServicioAD.ObtenerDVHRegistro(DVHDatos);
                    if (DVHActual != DVHComparar)
                    {
                        if (!((ErrorInt.Tabla ?? "") == (DVHDatos.Tabla ?? "")))
                        {
                            ErrorInt.CodEn = DVHDatos.CodReg;
                            ErrorInt.Tabla = DVHDatos.Tabla;
                            ErrorInt.Tipo = "DVH";
                            ErrorInt.EstadoMensaje = true;
                        }

                        // DataTable
                        DatosDVHParam.DtIntegridad.Rows.Add(DatosDVHParam.Tabla, DVHDatos.CodReg, DVHDatos.CodAux, DVHComparar);
                        DatosDVHParam.DtIntegridadDVV.Rows.Add(DatosDVHParam.Tabla);
                        string CadenaFamPat = "";
                        string CadenaUsuFam = "";
                        string CadenaUsuPat = "";
                        string CadenaEntidad = "";
                        switch (DatosDVHParam.Tabla ?? "")
                        {
                            case "Fam_Pat":
                                {
                                    CadenaFamPat = Servicios.Seguridad.Encriptar("Error de integridad DVH. Tabla: Fam_Pat || CodFam: " + DVHDatos.CodReg + " - CodPat: " + DVHDatos.CodAux);
                                    if (ServicioAD.ExisteRegistroIntegridad(CadenaFamPat))
                                    {
                                        continue;
                                    }

                                    break;
                                }

                            case "Usu_Fam":
                                {
                                    CadenaUsuFam = Servicios.Seguridad.Encriptar("Error de integridad DVH. Tabla: Usu_Fam || CodUsu: " + DVHDatos.CodReg + " - CodFam: " + DVHDatos.CodAux);
                                    if (ServicioAD.ExisteRegistroIntegridad(CadenaUsuFam))
                                    {
                                        continue;
                                    }

                                    break;
                                }

                            case "Usu_Pat":
                                {
                                    CadenaUsuPat = Servicios.Seguridad.Encriptar("Error de integridad DVH. Tabla: Usu_Pat || CodUsu: " + DVHDatos.CodReg + " - CodPat: " + DVHDatos.CodAux);
                                    if (ServicioAD.ExisteRegistroIntegridad(CadenaUsuPat))
                                    {
                                        continue;
                                    }

                                    break;
                                }

                            default:
                                {
                                    CadenaEntidad = Servicios.Seguridad.Encriptar("Error de integridad DVH. Tabla: " + DVHDatos.Tabla + " en el registro nro: " + DVHDatos.CodReg + " de la columna " + DVHDatos.Columna);
                                    if (ServicioAD.ExisteRegistroIntegridad(CadenaEntidad))
                                    {
                                        continue;
                                    }

                                    break;
                                }
                        }

                        var Bitacora = new BitacoraEN();
                        switch (DatosDVHParam.Tabla ?? "")
                        {
                            case "Fam_Pat":
                                {
                                    Bitacora.Descripcion = CadenaFamPat;
                                    break;
                                }

                            case "Usu_Fam":
                                {
                                    Bitacora.Descripcion = CadenaUsuFam;
                                    break;
                                }

                            case "Usu_Pat":
                                {
                                    Bitacora.Descripcion = CadenaUsuPat;
                                    break;
                                }

                            default:
                                {
                                    Bitacora.Descripcion = CadenaEntidad;
                                    break;
                                }
                        }

                        Bitacora.Criticidad = 1.ToString();
                        Bitacora.Usuario = "Sistema";
                        BitacoraAD.GrabarBitacora(Bitacora);
                        var DVHDatosBitacora = new DVHEN();
                        DVHDatosBitacora.Tabla = "Bitacora";
                        DVHDatosBitacora.CodReg = Bitacora.CodBit;
                        int DVHBitacora = CalcularDVH(DVHDatosBitacora);
                        int ValorDVHAntiguoBit = GrabarDVH(DVHDatosBitacora, DVHBitacora);
                        var DVVDatosBitacora = new DVVEN();
                        DVVDatosBitacora.Tabla = "Bitacora";
                        DVVDatosBitacora.ValorDVH = DVHBitacora;
                        DVVDatosBitacora.TipoAccion = "Alta";
                        GrabarDVV(DVVDatosBitacora);
                    }
                }

                // DVV
                int DVVComparar = ServicioAD.CalcularDVV(DVHGral);
                int DVVActual = ServicioAD.ObtenerDVVTabla(DVHGral);
                if (DVVActual != DVVComparar)
                {
                    ErrorInt.Tabla = DVHGral.Tabla;
                    if (ErrorInt.EstadoMensaje == false)
                    {
                        ErrorInt.Tipo = "DVV";
                    }
                    else
                    {
                        string CadenaDVV = " & DVV";
                        ErrorInt.Tipo = ErrorInt.Tipo + CadenaDVV;
                    }

                    bool ExisteTablaDT = false;
                    foreach (DataRow row in DatosDVHParam.DtIntegridadDVV.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Tabla"], DVHGral.Tabla, false)))
                        {
                            ExisteTablaDT = true;
                            break;
                        }
                    }

                    if (ExisteTablaDT == false)
                    {
                        DatosDVHParam.DtIntegridadDVV.Rows.Add(DVHGral.Tabla);
                    }

                    string CadenaEntidad = Servicios.Seguridad.Encriptar("Error de integridad DVV. Tabla: " + DVHGral.Tabla);
                    if (!ServicioAD.ExisteRegistroIntegridad(CadenaEntidad))
                    {
                        var Bitacora = new BitacoraEN();
                        Bitacora.Descripcion = CadenaEntidad;
                        Bitacora.Criticidad = 1.ToString();
                        Bitacora.Usuario = "Sistema";
                        BitacoraAD.GrabarBitacora(Bitacora);
                        var DVHDatosBitacora = new DVHEN();
                        DVHDatosBitacora.Tabla = "Bitacora";
                        DVHDatosBitacora.CodReg = Bitacora.CodBit;
                        int DVHBitacora = CalcularDVH(DVHDatosBitacora);
                        int ValorDVHAntiguoBit = GrabarDVH(DVHDatosBitacora, DVHBitacora);
                        var DVVDatosBitacora = new DVVEN();
                        DVVDatosBitacora.Tabla = "Bitacora";
                        DVVDatosBitacora.ValorDVH = DVHBitacora;
                        DVVDatosBitacora.TipoAccion = "Alta";
                        GrabarDVV(DVVDatosBitacora);
                    }
                }

                return ErrorInt;
            }
            catch (SqlException ex)
            {
                throw new CriticalException(ex.Message);
            }
        }

        public static void GrabarDVV(DVVEN DVVDatosBitacora)
        {
            ServicioAD.GrabarDVV(DVVDatosBitacora);
        }

        public static void RecalcularDVH(DataTable DtErrorIntegridad)
        {
            var UsuAut = Servicios.Autenticar.Instancia();
            foreach (DataRow row in DtErrorIntegridad.Rows)
            {
                ServicioAD.RecalcularDVH(Conversions.ToString(row["Tabla"]), Conversions.ToInteger(row["CodReg"]), Conversions.ToInteger(row["CodAux"]), Conversions.ToInteger(row["ValorDVH"]));
                string CadenaEntidad = "";
                switch (row["Tabla"])
                {
                    case "Fam_Pat":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodFam: "), row["CodReg"]), " | CodPat: "), row["CodAux"])));
                            break;
                        }

                    case "Usu_Fam":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodUsu: "), row["CodReg"]), " | CodFam: "), row["CodAux"])));
                            break;
                        }

                    case "Usu_Pat":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodUsu: "), row["CodReg"]), " | CodPat: "), row["CodAux"])));
                            break;
                        }

                    case "Cliente":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodCli: "), row["CodReg"])));
                            break;
                        }

                    case "Bitacora":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodBit: "), row["CodReg"])));
                            break;
                        }

                    case "Producto":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodProd: "), row["CodReg"])));
                            break;
                        }

                    case "Historico_Precio":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodHist: "), row["CodReg"])));
                            break;
                        }

                    case "Usuario":
                        {
                            CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Recalculó DVH. Tabla: ", row["Tabla"]), " | CodUsu: "), row["CodReg"])));
                            break;
                        }
                }

                if (ServicioAD.ExisteRegistroIntegridad(CadenaEntidad))
                {
                    continue;
                }

                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = CadenaEntidad;
                Bitacora.Criticidad = 1.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBit = GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                GrabarDVV(DVVDatosBitacora);
            }
        }

        public static void RecalcularDVV(DataTable DtErrorIntegridadDVV)
        {
            var UsuAut = Servicios.Autenticar.Instancia();
            foreach (DataRow row in DtErrorIntegridadDVV.Rows)
            {
                ServicioAD.RecalcularDVV(Conversions.ToString(row["Tabla"]));
                string CadenaEntidad;
                CadenaEntidad = Servicios.Seguridad.Encriptar(Conversions.ToString(Operators.ConcatenateObject("Recalculó DVV. Tabla: ", row["Tabla"])));
                if (ServicioAD.ExisteRegistroIntegridad(CadenaEntidad))
                {
                    continue;
                }

                var Bitacora = new BitacoraEN();
                Bitacora.Descripcion = CadenaEntidad;
                Bitacora.Criticidad = 1.ToString();
                Bitacora.Usuario = UsuAut.UsuarioLogueado;
                BitacoraAD.GrabarBitacora(Bitacora);
                var DVHDatosBitacora = new DVHEN();
                DVHDatosBitacora.Tabla = "Bitacora";
                DVHDatosBitacora.CodReg = Bitacora.CodBit;
                int DVHBitacora = CalcularDVH(DVHDatosBitacora);
                int ValorDVHAntiguoBit = GrabarDVH(DVHDatosBitacora, DVHBitacora);
                var DVVDatosBitacora = new DVVEN();
                DVVDatosBitacora.Tabla = "Bitacora";
                DVVDatosBitacora.ValorDVH = DVHBitacora;
                DVVDatosBitacora.TipoAccion = "Alta";
                GrabarDVV(DVVDatosBitacora);
            }
        }

        public static int ObtenerDVHRegistro(DVHEN DVH)
        {
            return ServicioAD.ObtenerDVHRegistro(DVH);
        }
    }
} // Integridad