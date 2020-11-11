using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Microsoft.VisualBasic.CompilerServices;
using Servicios;

namespace MercaderSG
{
    public partial class Principal
    {
        public Principal()
        {
            InitializeComponent();
            _GestionClienteSMI.Name = "GestionClienteSMI";
            _GestionProductoSMI.Name = "GestionProductoSMI";
            _GestionProveedorSMI.Name = "GestionProveedorSMI";
            _GestionNVSMI.Name = "GestionNVSMI";
            _GenerarNVSMI.Name = "GenerarNVSMI";
            _GestionNPSMI.Name = "GestionNPSMI";
            _GenerarNPSMI.Name = "GenerarNPSMI";
            _GestionUsuarioSMI.Name = "GestionUsuarioSMI";
            _GestionFamiliaSMI.Name = "GestionFamiliaSMI";
            _DesbloquearUsuarioSMI.Name = "DesbloquearUsuarioSMI";
            _ResetearContrasenaSMI.Name = "ResetearContrasenaSMI";
            _BackupSMI.Name = "BackupSMI";
            _RestoreSMI.Name = "RestoreSMI";
            _BitacoraSMI.Name = "BitacoraSMI";
            _PatFamSMI.Name = "PatFamSMI";
            _UsuFamSMI.Name = "UsuFamSMI";
            _PatUsuSMI.Name = "PatUsuSMI";
            _RecalcularDVSMI.Name = "RecalcularDVSMI";
            _EspanolSMI.Name = "EspanolSMI";
            _InglesSMI.Name = "InglesSMI";
            _CambiarContrasenaSMI.Name = "CambiarContrasenaSMI";
            _SalirSMI.Name = "SalirSMI";
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static List<ErrorIntegridadEN> ListaErrorInt = new List<ErrorIntegridadEN>();
        public static DataTable DtErrorIntegridad;
        public static DataTable DtErrorIntegridadDVV;
        private Autenticar UsuAut = Autenticar.Instancia();
        private StringBuilder CadenaTablas = new StringBuilder();
        private bool EstadoIntegridad = false;
        private List<string> ListaFormsNombres = new List<string>();
        private List<string> ListaFormsNombresTT = new List<string>();
        private MercaderSG.GestionCliente GestionCliFrm = new MercaderSG.GestionCliente();
        private MercaderSG.GestionProveedor GestionProvFrm = new MercaderSG.GestionProveedor();
        private MercaderSG.GestionProducto GestionProdFrm = new MercaderSG.GestionProducto();
        private MercaderSG.GestionNV GestionNVFrm = new MercaderSG.GestionNV();
        private MercaderSG.NotaVenta NVFrm = new MercaderSG.NotaVenta();
        private MercaderSG.GestionNP GestionNPFrm = new MercaderSG.GestionNP();
        private MercaderSG.NotaPedido NPFrm = new MercaderSG.NotaPedido();
        private MercaderSG.GestionUsuario GestionUsuFrm = new MercaderSG.GestionUsuario();
        private MercaderSG.GestionFamilia GestionFamFrm = new MercaderSG.GestionFamilia();
        private MercaderSG.DesbloquearUsuario DesbloquearUsuFrm = new MercaderSG.DesbloquearUsuario();
        private MercaderSG.ResetearContrasena ResetearPassFrm = new MercaderSG.ResetearContrasena();
        private MercaderSG.Backup BackUpFrm = new MercaderSG.Backup();
        private MercaderSG.Restore RestoreFrm = new MercaderSG.Restore();
        private MercaderSG.Bitacora BitacoraFrm = new MercaderSG.Bitacora();
        private MercaderSG.FamiliaPatente PatFamFrm = new MercaderSG.FamiliaPatente();
        private MercaderSG.UsuarioFamilia UsuFamFrm = new MercaderSG.UsuarioFamilia();
        private MercaderSG.UsuarioPatente UsuPatFrm = new MercaderSG.UsuarioPatente();
        private MercaderSG.CambiarContrasena CambiarPass = new MercaderSG.CambiarContrasena();
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void CargarPermisos()
        {
            this.GenerarNVSMI.Enabled = PermisoOK(18);
            this.GenerarNPSMI.Enabled = PermisoOK(21);
            this.DesbloquearUsuarioSMI.Enabled = PermisoOK(29);
            this.ResetearContrasenaSMI.Enabled = PermisoOK(30);
            this.BackupSMI.Enabled = PermisoOK(31);
            this.RestoreSMI.Enabled = PermisoOK(32);
            this.BitacoraSMI.Enabled = PermisoOK(33);
            this.UsuFamSMI.Enabled = PermisoOK(36);
            EstadoIntegridad = PermisoOK(39);
        }

        private void HabilitarBotones()
        {
            int Contador = 1;
            var ListaGestion = new List<int>();

            // GestionCli
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 1, false), Operators.ConditionalCompareObjectEqual(fila[0], 2, false)), Operators.ConditionalCompareObjectEqual(fila[0], 3, false)), Operators.ConditionalCompareObjectEqual(fila[0], 4, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionClienteSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionProd
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 5, false), Operators.ConditionalCompareObjectEqual(fila[0], 6, false)), Operators.ConditionalCompareObjectEqual(fila[0], 7, false)), Operators.ConditionalCompareObjectEqual(fila[0], 8, false)), Operators.ConditionalCompareObjectEqual(fila[0], 9, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionProductoSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionProv
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 10, false), Operators.ConditionalCompareObjectEqual(fila[0], 11, false)), Operators.ConditionalCompareObjectEqual(fila[0], 12, false)), Operators.ConditionalCompareObjectEqual(fila[0], 13, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionProveedorSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionNV

            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 14, false), Operators.ConditionalCompareObjectEqual(fila[0], 15, false)), Operators.ConditionalCompareObjectEqual(fila[0], 16, false)), Operators.ConditionalCompareObjectEqual(fila[0], 17, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionNVSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionNP
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 19, false), Operators.ConditionalCompareObjectEqual(fila[0], 20, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionNPSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionUsu

            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 22, false), Operators.ConditionalCompareObjectEqual(fila[0], 23, false)), Operators.ConditionalCompareObjectEqual(fila[0], 24, false)), Operators.ConditionalCompareObjectEqual(fila[0], 25, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionUsuarioSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // GestionFam
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 26, false), Operators.ConditionalCompareObjectEqual(fila[0], 27, false)), Operators.ConditionalCompareObjectEqual(fila[0], 28, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.GestionFamiliaSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // Patente-Familia
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 34, false), Operators.ConditionalCompareObjectEqual(fila[0], 35, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.PatFamSMI.Enabled = false;
            }

            ListaGestion.Clear();

            // Patente-Usuario
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.OrObject(Operators.ConditionalCompareObjectEqual(fila[0], 37, false), Operators.ConditionalCompareObjectEqual(fila[0], 38, false))))
                {
                    ListaGestion.Add(Contador);
                }
            }

            if (ListaGestion.Count == 0)
            {
                this.PatUsuSMI.Enabled = false;
            }

            ListaGestion.Clear();
            if (this.GenerarNVSMI.Enabled == false & this.GestionNVSMI.Enabled == false)
            {
                this.NotaVentaSMI.Enabled = false;
            }

            if (this.GenerarNPSMI.Enabled == false & this.GestionNPSMI.Enabled == false)
            {
                this.NotaPedidoSMI.Enabled = false;
            }
        }

        private bool PermisoOK(int CodPat)
        {
            foreach (DataRow fila in UsuAut.dtPatUsu.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(fila[0], CodPat, false)))
                {
                    return true;
                }
            }

            return false;
        }

        private void ControlarIntegridad()
        {
            if (ListaErrorInt.Count > 0)
            {
                if (EstadoIntegridad == true)
                {
                    this.RecalcularDVSMI.Enabled = true;
                }
                else
                {
                    this.RecalcularDVSMI.Enabled = false;
                }

                CadenaTablas.Append(MercaderSG.My.Resources.ArchivoIdioma.DeshabiltarForms + Environment.NewLine + Environment.NewLine);
                int Contador = 1;
                bool EstadoSistema = false;
                bool EstadoMensaje = false;
                foreach (ErrorIntegridadEN item in ListaErrorInt)
                {
                    if (item.Tabla == "Cliente")
                    {
                        if (this.GestionClienteSMI.Enabled == true)
                        {
                            this.GestionClienteSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.GestionClienteFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        if (this.GenerarNVSMI.Enabled == true)
                        {
                            this.GenerarNVSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.AltaNotaVentaFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        continue;
                    }

                    if (item.Tabla == "Producto" | item.Tabla == "Historico_Precio")
                    {
                        if (this.GestionProductoSMI.Enabled == true)
                        {
                            this.GestionProductoSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.GestionProductosFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        if (this.GenerarNPSMI.Enabled == true)
                        {
                            this.GenerarNPSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.AltaNotaPedidoFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        if (this.GenerarNVSMI.Enabled == true)
                        {
                            this.GenerarNVSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.AltaNotaVentaFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        continue;
                    }

                    if (item.Tabla == "Bitacora")
                    {
                        if (this.BitacoraSMI.Enabled == true)
                        {
                            this.BitacoraSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.BitacoraFrm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        continue;
                    }

                    if (item.Tabla == "Usuario")
                    {
                        if (this.GestionUsuarioSMI.Enabled == true)
                        {
                            this.GestionUsuarioSMI.Enabled = false;
                            CadenaTablas.Append(Contador + ") " + MercaderSG.My.Resources.ArchivoIdioma.GestionUsuarioForm + Environment.NewLine);
                            EstadoMensaje = true;
                            Contador += 1;
                        }

                        continue;
                    }

                    if (item.Tabla == "Usu_Pat" | item.Tabla == "Usu_Fam" | item.Tabla == "Fam_Pat")
                    {
                        if (this.PatUsuSMI.Enabled == true)
                        {
                            this.PatUsuSMI.Enabled = false;
                        }

                        if (this.PatFamSMI.Enabled == true)
                        {
                            this.PatFamSMI.Enabled = false;
                        }

                        if (this.UsuFamSMI.Enabled == true)
                        {
                            this.UsuFamSMI.Enabled = false;
                        }

                        EstadoMensaje = false;
                        EstadoSistema = true;
                        CadenaTablas.Clear();
                        CadenaTablas.Append(MercaderSG.My.Resources.ArchivoIdioma.SistemaBloqueadoCompleto + Environment.NewLine + MercaderSG.My.Resources.ArchivoIdioma.SistemaBloqueadoCompleto2);
                        BloquearSistema();
                        break;
                    }
                }

                if (EstadoSistema == true)
                {
                    // CadenaTablas.Append(Environment.NewLine & My.Resources.ArchivoIdioma.ErrorIntegridadSistema)
                    MessageBox.Show(CadenaTablas.ToString(), MercaderSG.My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (EstadoMensaje == true)
                {
                    MessageBox.Show(CadenaTablas.ToString(), MercaderSG.My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // If EstadoMensaje = False Then
            // MessageBox.Show(My.Resources.ArchivoIdioma.HayErrorIntegridad, My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error)
            // If RecalcularDVSMI.Enabled = True Then
            // RecalcularDVSMI.PerformClick()
            // End If
            // End If
            else
            {
                this.RecalcularDVSMI.Enabled = false;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void Principal_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is MdiClient)
                {
                    item.BackColor = Color.WhiteSmoke;
                }
            }

            AplicarIdioma(true, ListaFormsNombres);
            if (UsuAut.dtPatUsu.Rows.Count == 0)
            {
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.ElUsuario + UsuAut.UsuarioLogueado + MercaderSG.My.Resources.ArchivoIdioma.NoPermisosLogin, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BloquearSistema();
            }
            else
            {
                CargarPermisos();
                HabilitarBotones();
                ControlarIntegridad();
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void AplicarIdioma(bool Estado, List<string> ListaForms)
        {
            if (Estado)
            {
                // Principal
                this.Text = MercaderSG.My.Resources.ArchivoIdioma.PrincipalForm;
                this.GestionSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                this.GestionClienteSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ClientePFrm;
                this.GestionProductoSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ProductoPFrm;
                this.GestionProveedorSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ProveedorPFrm;
                this.ComercialSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ComercialPFrm;
                this.NotaPedidoSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.NPPFrm;
                this.NotaVentaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.NVPfrm;
                this.GenerarNPSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                this.GestionNPSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                this.GenerarNVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                this.GestionNVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                this.SistemaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SistemaPFrm;
                this.GestionUsuarioSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionUsuPfrm;
                this.GestionFamiliaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionFamPfrm;
                this.DesbloquearUsuarioSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.DesbloquearPfrm;
                this.ResetearContrasenaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ResetearPfrm;
                this.SeguridadSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SeguridadPfrm;
                this.BackupSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.BackupPfrm;
                this.RestoreSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.RestorePfrm;
                this.BitacoraSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.BitacoraPfrm;
                this.PatFamSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PatFamPfrm;
                this.UsuFamSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuFamPfrm;
                this.PatUsuSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PatUsuPfrm;
                this.RecalcularDVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.RecalcularPfrm;
                this.PanelSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PanelPfrm;
                this.IdiomaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.IdiomaPfrm;
                this.EspanolSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.EspanolPfrm;
                this.InglesSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.InglesPfrm;
                this.CambiarContrasenaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.CambiarPassPfrm;
                this.SalirSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SalirPfrm;
            }
            else
            {
                foreach (string item in ListaForms)
                {
                    if (item == "Principal")
                    {
                        this.Text = MercaderSG.My.Resources.ArchivoIdioma.PrincipalForm;
                        this.GestionSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                        this.GestionClienteSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ClientePFrm;
                        this.GestionProductoSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ProductoPFrm;
                        this.GestionProveedorSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ProveedorPFrm;
                        this.ComercialSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ComercialPFrm;
                        this.NotaPedidoSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.NPPFrm;
                        this.NotaVentaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.NVPfrm;
                        this.GenerarNPSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                        this.GestionNPSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                        this.GenerarNVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                        this.GestionNVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionPFrm;
                        this.SistemaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SistemaPFrm;
                        this.GestionUsuarioSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionUsuPfrm;
                        this.GestionFamiliaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionFamPfrm;
                        this.DesbloquearUsuarioSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.DesbloquearPfrm;
                        this.ResetearContrasenaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.ResetearPfrm;
                        this.SeguridadSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SeguridadPfrm;
                        this.BackupSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.BackupPfrm;
                        this.RestoreSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.RestorePfrm;
                        this.BitacoraSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.BitacoraPfrm;
                        this.PatFamSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PatFamPfrm;
                        this.UsuFamSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuFamPfrm;
                        this.PatUsuSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PatUsuPfrm;
                        this.RecalcularDVSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.RecalcularPfrm;
                        this.PanelSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.PanelPfrm;
                        this.IdiomaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.IdiomaPfrm;
                        this.EspanolSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.EspanolPfrm;
                        this.InglesSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.InglesPfrm;
                        this.CambiarContrasenaSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.CambiarPassPfrm;
                        this.SalirSMI.Text = MercaderSG.My.Resources.ArchivoIdioma.SalirPfrm;
                        continue;
                    }

                    if (item == "GestionCliente")
                    {
                        if (!GestionCliFrm.IsHandleCreated)
                        {
                            GestionCliFrm = new MercaderSG.GestionCliente();
                        }

                        GestionCliFrm.GestionClientesGB.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionClienteGB;
                        GestionCliFrm.BuscarPorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarPorLbl;
                        GestionCliFrm.BuscarCmb.Items[0] = MercaderSG.My.Resources.ArchivoIdioma.CMBCuit;
                        GestionCliFrm.BuscarCmb.Items[1] = MercaderSG.My.Resources.ArchivoIdioma.CMBRazonSocial;
                        GestionCliFrm.IgualLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.IgualALbl;
                        GestionCliFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionCliFrm.OperacionGB.Text = MercaderSG.My.Resources.ArchivoIdioma.OperacionesGB;
                        GestionCliFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarCliBtn;
                        GestionCliFrm.ModificarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarCliBtn;
                        GestionCliFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarCliBtn;
                        GestionCliFrm.EliminarTelBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarTelBtn;
                        GestionCliFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        GestionCliFrm.CodCliCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        GestionCliFrm.RazonSocialCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.RazonSocialGral;
                        GestionCliFrm.CuitCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CuitGral;
                        GestionCliFrm.DireccionCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DireccionCAB;
                        GestionCliFrm.LocalidadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.LocalidadLbl;
                        GestionCliFrm.PaginaNro = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaPag;
                        GestionCliFrm.PaginaDe = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaDe;
                        GestionCliFrm.PaginaRegistros = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaReg;
                        if (GestionCliFrm.ClienteDG.Rows.Count == 0)
                        {
                            GestionCliFrm.InfoPagina(0);
                        }
                        else
                        {
                            GestionCliFrm.InfoPagina(GestionCliFrm.NroPag);
                        }

                        continue;
                    }

                    if (item == "GestionProducto")
                    {
                        if (!GestionProdFrm.IsHandleCreated)
                        {
                            GestionProdFrm = new MercaderSG.GestionProducto();
                        }

                        GestionProdFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionProductosFrm;
                        GestionProdFrm.GestionProductosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionProductosGB;
                        GestionProdFrm.BuscarPorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarPorLbl;
                        GestionProdFrm.BuscarCmb.Items[0] = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        GestionProdFrm.BuscarCmb.Items[1] = MercaderSG.My.Resources.ArchivoIdioma.CMBSector;
                        GestionProdFrm.IgualLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.IgualALbl;
                        GestionProdFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionProdFrm.OperacionGB.Text = MercaderSG.My.Resources.ArchivoIdioma.OperacionesGB;
                        GestionProdFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarProdBtn;
                        GestionProdFrm.ModificarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarProdBtn;
                        GestionProdFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarProdBtn;
                        GestionProdFrm.MasBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.MasOpcionesBtn;
                        GestionProdFrm.ModificarStockBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarStockBtn;
                        GestionProdFrm.ModificarPrecioBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarPrecioBtn;
                        GestionProdFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        GestionProdFrm.CodProdCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        GestionProdFrm.NombreCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        GestionProdFrm.PrecioUnitarioCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Precio;
                        GestionProdFrm.CantidadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Cantidad;
                        GestionProdFrm.SectorCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CMBSector;
                        GestionProdFrm.PaginaNro = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaPag;
                        GestionProdFrm.PaginaDe = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaDe;
                        GestionProdFrm.PaginaRegistros = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaReg;
                        if (GestionProdFrm.ProductosDG.Rows.Count == 0)
                        {
                            GestionProdFrm.InfoPagina(0);
                        }
                        else
                        {
                            GestionProdFrm.InfoPagina(GestionProdFrm.NroPag);
                        }

                        continue;
                    }

                    if (item == "GestionProveedor")
                    {
                        if (!GestionProvFrm.IsHandleCreated)
                        {
                            GestionProvFrm = new MercaderSG.GestionProveedor();
                        }

                        GestionProvFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionProveedorFrm;
                        GestionProvFrm.GestionProveedoresGB.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionProveedorGB;
                        GestionProvFrm.BuscarPorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarPorLbl;
                        GestionProvFrm.BuscarCmb.Items[0] = MercaderSG.My.Resources.ArchivoIdioma.CMBCuit;
                        GestionProvFrm.BuscarCmb.Items[1] = MercaderSG.My.Resources.ArchivoIdioma.CMBRazonSocial;
                        GestionProvFrm.IgualLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.IgualALbl;
                        GestionProvFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionProvFrm.OperacionGB.Text = MercaderSG.My.Resources.ArchivoIdioma.OperacionesGB;
                        GestionProvFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarProvBtn;
                        GestionProvFrm.ModificarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarProvBtn;
                        GestionProvFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarProvBtn;
                        GestionProvFrm.EliminarTelBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarTelBtn;
                        GestionProvFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        GestionProvFrm.CodProvCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        GestionProvFrm.RazonSocialCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.RazonSocialGral;
                        GestionProvFrm.CuitCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CuitGral;
                        GestionProvFrm.CorreoElectronicoCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CorreoElectronicoGral;
                        GestionProvFrm.DireccionCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DireccionCAB;
                        GestionProvFrm.PaginaNro = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaPag;
                        GestionProvFrm.PaginaDe = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaDe;
                        GestionProvFrm.PaginaRegistros = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaReg;
                        if (GestionProvFrm.ProveedorDG.Rows.Count == 0)
                        {
                            GestionProvFrm.InfoPagina(0);
                        }
                        else
                        {
                            GestionProvFrm.InfoPagina(GestionProvFrm.NroPag);
                        }

                        continue;
                    }

                    if (item == "GestionNV")
                    {
                        if (!GestionNVFrm.IsHandleCreated)
                        {
                            GestionNVFrm = new MercaderSG.GestionNV();
                        }

                        GestionNVFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionNVFrm;
                        GestionNVFrm.AccionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.AccionLbl;
                        GestionNVFrm.AccionCMB.Items.Clear();
                        if (GestionNVFrm.ConsultarNota == true)
                        {
                            GestionNVFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.ConsultarNV);
                        }

                        if (GestionNVFrm.ConsultaRemitoNV == true)
                        {
                            GestionNVFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.ConsultarRemNV);
                        }

                        if (GestionNVFrm.GenerarRemitoNV == true)
                        {
                            GestionNVFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.GenerarRemito);
                        }

                        if (GestionNVFrm.BajaNV == true)
                        {
                            GestionNVFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.BajaNotaVenta);
                        }

                        GestionNVFrm.AccionCMB.SelectedIndex = 0;
                        GestionNVFrm.NroNotaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.NumeroNota;
                        GestionNVFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionNVFrm.NotaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.NotaVentaGB;
                        GestionNVFrm.NroNotaCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.NroNotaCAB;
                        GestionNVFrm.FechaCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.FechaLbl;
                        GestionNVFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        GestionNVFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "NotaVenta")
                    {
                        if (!NVFrm.IsHandleCreated)
                        {
                            NVFrm = new MercaderSG.NotaVenta();
                        }

                        NVFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.AltaNotaVentaFrm;
                        NVFrm.ClienteGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DatosClienteGB;
                        NVFrm.CodCliLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NVFrm.CuitLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CuitGral;
                        NVFrm.DireccionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DireccionCAB;
                        NVFrm.RazonSocialLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.RazonSocialGral;
                        NVFrm.ActivoLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ActivoLbl;
                        NVFrm.FechaEmiLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaEmiForm;
                        NVFrm.ProductoGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DatosProductoGB;
                        NVFrm.CodProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NVFrm.NombreProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        NVFrm.DescProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DescripcionLbl;
                        NVFrm.PrecioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.Precio;
                        NVFrm.CantidadLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.Cantidad;
                        NVFrm.NotaVentaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DetalleNotaVenta;
                        NVFrm.CodProdCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NVFrm.NombreCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        NVFrm.PrecioCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Precio;
                        NVFrm.CantidadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Cantidad;
                        NVFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarGral;
                        NVFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarGral;
                        NVFrm.NuevoBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.NuevoGral;
                        NVFrm.TotalLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.TotalLbl;
                        NVFrm.GenerarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                        continue;
                    }

                    if (item == "GestionNP")
                    {
                        if (!GestionNPFrm.IsHandleCreated)
                        {
                            GestionNPFrm = new MercaderSG.GestionNP();
                        }

                        GestionNPFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionNPFrm;
                        GestionNPFrm.AccionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.AccionLbl;
                        GestionNPFrm.AccionCMB.Items.Clear();
                        if (GestionNPFrm.ConsultarNota == true)
                        {
                            GestionNPFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.ConsultarNP);
                        }

                        if (GestionNPFrm.BajaNP == true)
                        {
                            GestionNPFrm.AccionCMB.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.BajaNotaPed);
                        }

                        GestionNPFrm.AccionCMB.SelectedIndex = 0;
                        GestionNPFrm.NroNotaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.NumeroNota;
                        GestionNPFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionNPFrm.NotaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.NotaPedidoGB;
                        GestionNPFrm.NroNotaCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.NroNotaCAB;
                        GestionNPFrm.FechaCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.FechaLbl;
                        GestionNPFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        GestionNPFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "NotaPedido")
                    {
                        if (!NPFrm.IsHandleCreated)
                        {
                            NPFrm = new MercaderSG.NotaPedido();
                        }

                        NPFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.AltaNotaPedidoFrm;
                        NPFrm.ProveedorGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DatosProveedorGB;
                        NPFrm.CodProvLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NPFrm.CuitLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CuitGral;
                        NPFrm.DireccionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DireccionCAB;
                        NPFrm.RazonSocialLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.RazonSocialGral;
                        NPFrm.ActivoLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ActivoLbl;
                        NPFrm.FechaEmiLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaEmiForm;
                        NPFrm.ProductoGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DatosProductoGB;
                        NPFrm.CodProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NPFrm.NombreProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        NPFrm.DescProdLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DescripcionLbl;
                        NPFrm.PrecioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.Precio;
                        NPFrm.CantidadLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.Cantidad;
                        NPFrm.NotaVentaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.DetalleNotaVenta;
                        NPFrm.CodProdCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        NPFrm.NombreCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        NPFrm.PrecioCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Precio;
                        NPFrm.CantidadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.Cantidad;
                        NPFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarGral;
                        NPFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarGral;
                        NPFrm.NuevoBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.NuevoGral;
                        NPFrm.TotalLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.TotalLbl;
                        NPFrm.GenerarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.GenerarNotasPFrm;
                        continue;
                    }

                    if (item == "GestionUsuario")
                    {
                        if (!GestionUsuFrm.IsHandleCreated)
                        {
                            GestionUsuFrm = new MercaderSG.GestionUsuario();
                        }

                        GestionUsuFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionUsuarioForm;
                        GestionUsuFrm.GestionUsuariosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionUsuariosGB;
                        GestionUsuFrm.BuscarPorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarPorLbl;
                        GestionUsuFrm.BuscarCmb.Items[0] = MercaderSG.My.Resources.ArchivoIdioma.CMBUsuario;
                        GestionUsuFrm.BuscarCmb.Items[1] = MercaderSG.My.Resources.ArchivoIdioma.CMBApellido;
                        GestionUsuFrm.BuscarCmb.Items[2] = MercaderSG.My.Resources.ArchivoIdioma.CMBNombre;
                        GestionUsuFrm.IgualLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.IgualALbl;
                        GestionUsuFrm.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        GestionUsuFrm.OperacionGB.Text = MercaderSG.My.Resources.ArchivoIdioma.OperacionesGB;
                        GestionUsuFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AgregarUsuBtn;
                        GestionUsuFrm.ModificarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarUsuBtn;
                        GestionUsuFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarUsuBtn;
                        GestionUsuFrm.EliminarTelBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarTelBtn;
                        GestionUsuFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        GestionUsuFrm.CodUsuCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DGGestionUsuarioCodigoCAB;
                        GestionUsuFrm.UsuarioCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DGGestionUsuarioUsuarioCAB;
                        GestionUsuFrm.ApellidoCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DGGestionUsuarioApellidoCAB;
                        GestionUsuFrm.NombreCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DGGestionUsuarioNombreCAB;
                        GestionUsuFrm.CorreoCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CorreoElectronicoGral;
                        GestionUsuFrm.EdadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DGGestionUsuarioEdadCAB;
                        GestionUsuFrm.PaginaNro = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaPag;
                        GestionUsuFrm.PaginaDe = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaDe;
                        GestionUsuFrm.PaginaRegistros = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaReg;
                        if (GestionUsuFrm.UsuarioDG.Rows.Count == 0)
                        {
                            GestionUsuFrm.InfoPagina(0);
                        }
                        else
                        {
                            GestionUsuFrm.InfoPagina(GestionUsuFrm.NroPag);
                        }

                        continue;
                    }

                    if (item == "GestionFamilia")
                    {
                        if (!GestionFamFrm.IsHandleCreated)
                        {
                            GestionFamFrm = new MercaderSG.GestionFamilia();
                        }

                        GestionFamFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.GestionFamiliaFrm;
                        GestionFamFrm.OperacionGB.Text = MercaderSG.My.Resources.ArchivoIdioma.OperacionesGB;
                        GestionFamFrm.AgregarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AltaFamBtn;
                        GestionFamFrm.ModificarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.ModificarFamBtn;
                        GestionFamFrm.EliminarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.EliminarFamBtn;
                        GestionFamFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        GestionFamFrm.CodCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        GestionFamFrm.DescripcionCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DescripcionLbl;
                        continue;
                    }

                    if (item == "DesbloquearUsuario")
                    {
                        if (!DesbloquearUsuFrm.IsHandleCreated)
                        {
                            DesbloquearUsuFrm = new MercaderSG.DesbloquearUsuario();
                        }

                        DesbloquearUsuFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.DesbloquearUsuarioFrm;
                        DesbloquearUsuFrm.UsuarioGB.Text = MercaderSG.My.Resources.ArchivoIdioma.SeleccionarUsuarioGB;
                        DesbloquearUsuFrm.UsuarioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        DesbloquearUsuFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        DesbloquearUsuFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "ResetearContrasena")
                    {
                        if (!ResetearPassFrm.IsHandleCreated)
                        {
                            ResetearPassFrm = new MercaderSG.ResetearContrasena();
                        }

                        ResetearPassFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.ResetearContraseñaFrm;
                        ResetearPassFrm.UsuarioGB.Text = MercaderSG.My.Resources.ArchivoIdioma.SeleccionarUsuarioGB;
                        ResetearPassFrm.UsuarioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        ResetearPassFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        ResetearPassFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "Backup")
                    {
                        if (!BackUpFrm.IsHandleCreated)
                        {
                            BackUpFrm = new MercaderSG.Backup();
                        }

                        BackUpFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.BackupFrm;
                        BackUpFrm.BackupGB.Text = MercaderSG.My.Resources.ArchivoIdioma.Backup;
                        BackUpFrm.DestinoLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DestinoLbl;
                        BackUpFrm.VolumenLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.VolumenLbl;
                        BackUpFrm.NombreZipLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.NombreZip;
                        BackUpFrm.ContraseñaZipLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ContraseñaZip;
                        BackUpFrm.ReContraseñaZipLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ReContraseñaZip;
                        BackUpFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        BackUpFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "Restore")
                    {
                        if (!RestoreFrm.IsHandleCreated)
                        {
                            RestoreFrm = new MercaderSG.Restore();
                        }

                        RestoreFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.RestoreFrm;
                        RestoreFrm.RestaurarGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RestoreGB;
                        RestoreFrm.DestinoLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.DestinoRestoreLbl;
                        RestoreFrm.ContraseñaZipLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ContraseñaZip;
                        RestoreFrm.ReContraseñaZipLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ReContraseñaZip;
                        RestoreFrm.NuevoBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.NuevoGral;
                        RestoreFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        RestoreFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        continue;
                    }

                    if (item == "Bitacora")
                    {
                        if (!BitacoraFrm.IsHandleCreated)
                        {
                            BitacoraFrm = new MercaderSG.Bitacora();
                        }

                        BitacoraFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.BitacoraFrm;
                        BitacoraFrm.FiltroLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FiltroLbl;
                        BitacoraFrm.FiltroCMB.Items[0] = MercaderSG.My.Resources.ArchivoIdioma.CompletoLbl;
                        BitacoraFrm.FiltroCMB.Items[1] = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        BitacoraFrm.FiltroCMB.Items[2] = MercaderSG.My.Resources.ArchivoIdioma.CriticidadLbl;
                        BitacoraFrm.FiltroCMB.Items[3] = MercaderSG.My.Resources.ArchivoIdioma.FechaLbl;
                        BitacoraFrm.RegistrosGB.Text = MercaderSG.My.Resources.ArchivoIdioma.RegistrosGB;
                        BitacoraFrm.CodBitCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
                        BitacoraFrm.FechaCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.FechaLbl;
                        BitacoraFrm.DescripcionCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DescripcionLbl;
                        BitacoraFrm.CriticidadCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CriticidadLbl;
                        BitacoraFrm.UsuarioCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        BitacoraFrm.DepurarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.DepurarBitacora;
                        BitacoraFrm.PaginaNro = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaPag;
                        BitacoraFrm.PaginaDe = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaDe;
                        BitacoraFrm.PaginaRegistros = MercaderSG.My.Resources.ArchivoIdioma.InfoPaginaReg;
                        if (BitacoraFrm.BitacoraDG.Rows.Count == 0)
                        {
                            BitacoraFrm.InfoPagina(0);
                        }
                        else
                        {
                            BitacoraFrm.InfoPagina(BitacoraFrm.NroPag);
                        }

                        // FiltroCompleto
                        BitacoraFrm.FC.CompletoGB.Text = MercaderSG.My.Resources.ArchivoIdioma.FCompletoGB;
                        BitacoraFrm.FC.DesdeComLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaDesdeLbl;
                        BitacoraFrm.FC.HastaComLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaHastaLbl;
                        BitacoraFrm.FC.UsuComLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        BitacoraFrm.FC.CritiComLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CriticidadLbl;
                        BitacoraFrm.FC.BuscarComBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        BitacoraFrm.FC.CriticidadCMB.DataSource = null;
                        BitacoraFrm.FC.CriticidadCMB.DataSource = BitacoraFrm.CargarComboCriticidad();
                        BitacoraFrm.FC.CriticidadCMB.DisplayMember = "Descripcion";
                        BitacoraFrm.FC.CriticidadCMB.ValueMember = "CodCriti";

                        // FiltroCriticidad
                        BitacoraFrm.FCriti.CriticidadGB.Text = MercaderSG.My.Resources.ArchivoIdioma.CriticidadGB;
                        BitacoraFrm.FCriti.CriticidadLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.CriticidadLbl;
                        BitacoraFrm.FCriti.BuscarCritiBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        BitacoraFrm.FCriti.CriticidadCMB.DataSource = null;
                        BitacoraFrm.FCriti.CriticidadCMB.DataSource = BitacoraFrm.CargarComboCriticidad();
                        BitacoraFrm.FCriti.CriticidadCMB.DisplayMember = "Descripcion";
                        BitacoraFrm.FCriti.CriticidadCMB.ValueMember = "CodCriti";


                        // FiltroUsuario
                        BitacoraFrm.FU.UsuarioGB.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioGBBit;
                        BitacoraFrm.FU.UsuarioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        BitacoraFrm.FU.BuscarUsuBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;

                        // FiltroFechas
                        BitacoraFrm.FF.FechasGB.Text = MercaderSG.My.Resources.ArchivoIdioma.FechasGB;
                        BitacoraFrm.FF.DesdeLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaDesdeLbl;
                        BitacoraFrm.FF.HastaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FechaHastaLbl;
                        BitacoraFrm.FF.BuscarFechaBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
                        continue;
                    }

                    if (item == "FamiliaPatente")
                    {
                        if (!PatFamFrm.IsHandleCreated)
                        {
                            PatFamFrm = new MercaderSG.FamiliaPatente();
                        }

                        PatFamFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.PatenteFamiliaFrm;
                        PatFamFrm.FamiliaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.FamiliaLbl;
                        PatFamFrm.PatentesNoGB.Text = MercaderSG.My.Resources.ArchivoIdioma.PatentesNoFamLbl;
                        PatFamFrm.PatentesGB.Text = MercaderSG.My.Resources.ArchivoIdioma.PatentesFamLbl;
                        PatFamFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        PatFamFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        PatFamFrm.InformacionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ResultadoOperacion;
                        continue;
                    }

                    if (item == "UsuarioFamilia")
                    {
                        if (!UsuFamFrm.IsHandleCreated)
                        {
                            UsuFamFrm = new MercaderSG.UsuarioFamilia();
                        }

                        UsuFamFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioFamiliaFrm;
                        UsuFamFrm.UsuarioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        UsuFamFrm.FamiliaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.FamiliasGBTiene;
                        UsuFamFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        UsuFamFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        UsuFamFrm.InformacionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ResultadoOperacion;
                        continue;
                    }

                    if (item == "UsuarioPatente")
                    {
                        if (!UsuPatFrm.IsHandleCreated)
                        {
                            UsuPatFrm = new MercaderSG.UsuarioPatente();
                        }

                        UsuPatFrm.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioPatenteFrm;
                        UsuPatFrm.UsuarioLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.UsuarioLbl;
                        UsuPatFrm.PatentesGB.Text = MercaderSG.My.Resources.ArchivoIdioma.PatentesUsuLbl;
                        UsuPatFrm.PatDenegadasGB.Text = MercaderSG.My.Resources.ArchivoIdioma.PatentesDenegadasUsu;
                        UsuPatFrm.DenPatentesGB.Text = MercaderSG.My.Resources.ArchivoIdioma.PatentesNoUsuLbl;
                        UsuPatFrm.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        UsuPatFrm.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                        UsuPatFrm.InformacionLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ResultadoOperacion;
                        continue;
                    }

                    if (item == "CambiarContrasena")
                    {
                        if (!CambiarPass.IsHandleCreated)
                        {
                            CambiarPass = new MercaderSG.CambiarContrasena();
                        }

                        CambiarPass.Text = MercaderSG.My.Resources.ArchivoIdioma.CambiarContraseñaFrm;
                        CambiarPass.ContrasenaGB.Text = MercaderSG.My.Resources.ArchivoIdioma.CambiarContraseña;
                        CambiarPass.ConAnteriorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ConAnteriorLbl;
                        CambiarPass.NuevaContraseñaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.NuevaConLbl;
                        CambiarPass.ReNuevaContraseñaLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.ReNuevaConLbl;
                        CambiarPass.AceptarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.AceptarBtn;
                        CambiarPass.CancelarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.CancelarBtn;
                    }
                }
            }
        }

        private void CargarTT(List<string> ListaFormsNombreTT)
        {
            foreach (string item in ListaFormsNombreTT)
            {
                if (item == "GestionCliente")
                {
                    if (!GestionCliFrm.IsHandleCreated)
                    {
                        GestionCliFrm = new MercaderSG.GestionCliente();
                    }

                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTClienteAltaBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.ModificarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTClienteModificarBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTClienteEliminarBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.EliminarTelBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarTelBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.SiguienteBtn, MercaderSG.My.Resources.ArchivoIdioma.TTSiguienteBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.AnteriorBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAnteriorBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.UltimoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUltimoBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.PrimeroBtn, MercaderSG.My.Resources.ArchivoIdioma.TTPrimeraBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
                    GestionCliFrm.ControlesTP.SetToolTip(GestionCliFrm.ClienteDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaClientes);
                    continue;
                }

                if (item == "GestionProducto")
                {
                    if (!GestionProdFrm.IsHandleCreated)
                    {
                        GestionProdFrm = new MercaderSG.GestionProducto();
                    }

                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProductoAltaBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.ModificarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProductoModificarBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProductoEliminarBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.MasBtn, MercaderSG.My.Resources.ArchivoIdioma.TTMasOpciones);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.SiguienteBtn, MercaderSG.My.Resources.ArchivoIdioma.TTSiguienteBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.AnteriorBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAnteriorBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.UltimoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUltimoBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.PrimeroBtn, MercaderSG.My.Resources.ArchivoIdioma.TTPrimeraBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
                    GestionProdFrm.ControlesTP.SetToolTip(GestionProdFrm.ProductosDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaProducto);
                    continue;
                }

                if (item == "GestionProveedor")
                {
                    if (!GestionProvFrm.IsHandleCreated)
                    {
                        GestionProvFrm = new MercaderSG.GestionProveedor();
                    }

                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProveedorAltaBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.ModificarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProveedorModificarBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTProveedorEliminarBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.EliminarTelBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarTelBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.SiguienteBtn, MercaderSG.My.Resources.ArchivoIdioma.TTSiguienteBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.AnteriorBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAnteriorBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.UltimoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUltimoBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.PrimeroBtn, MercaderSG.My.Resources.ArchivoIdioma.TTPrimeraBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
                    GestionProvFrm.ControlesTP.SetToolTip(GestionProvFrm.ProveedorDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaProveedor);
                    continue;
                }

                if (item == "GestionNV")
                {
                    if (!GestionNVFrm.IsHandleCreated)
                    {
                        GestionNVFrm = new MercaderSG.GestionNV();
                    }

                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.AccionCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaAcciones);
                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.NroNotaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNroNotaVenta);
                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarNotaVenta);
                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.NotaVentaDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaNotaVenta);
                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRealizarAccion);
                    GestionNVFrm.ControlesTP.SetToolTip(GestionNVFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "NotaVenta")
                {
                    if (!NVFrm.IsHandleCreated)
                    {
                        NVFrm = new MercaderSG.NotaVenta();
                    }

                    NVFrm.ControlesTP.SetToolTip(NVFrm.CodCliTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCodCli);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.BuscarProdBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarCliNotas);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.CuitTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCuit);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.DireccionTxt, MercaderSG.My.Resources.ArchivoIdioma.TTDireccionCli);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.RazonSocialTxt, MercaderSG.My.Resources.ArchivoIdioma.TTRazonSocial);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.FechaDTP, MercaderSG.My.Resources.ArchivoIdioma.TTFechaEmisionNota);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.CodProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCodProd);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.BuscarProdBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarProdNota);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.NombreProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNombreProd);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.DescProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTDescrProd);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.PrecioTxt, MercaderSG.My.Resources.ArchivoIdioma.TTPrecioProd);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.CantidadTxt, MercaderSG.My.Resources.ArchivoIdioma.TTIngreseCantidad);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.DetalleDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaProductoNV);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAgregarDetalle);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarDetalle);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.NuevoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTNuevoDetalle);
                    NVFrm.ControlesTP.SetToolTip(NVFrm.GenerarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTGenerarNotaVenta);
                    continue;
                }

                if (item == "GestionNP")
                {
                    if (!GestionNPFrm.IsHandleCreated)
                    {
                        GestionNPFrm = new MercaderSG.GestionNP();
                    }

                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.AccionCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaAcciones);
                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.NroNotaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNroNotaPedido);
                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarNotaPedido);
                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.NotaPedidoDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaNotaPedido);
                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRealizarAccion);
                    GestionNPFrm.ControlesTP.SetToolTip(GestionNPFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "NotaPedido")
                {
                    if (!NPFrm.IsHandleCreated)
                    {
                        NPFrm = new MercaderSG.NotaPedido();
                    }

                    NPFrm.ControlesTP.SetToolTip(NPFrm.CodProvTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCodProv);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.BuscarProdBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarProvNotas);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.CuitTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCuit);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.DireccionTxt, MercaderSG.My.Resources.ArchivoIdioma.TTDireccionProv);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.RazonSocialTxt, MercaderSG.My.Resources.ArchivoIdioma.TTRazonSocial);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.FechaDTP, MercaderSG.My.Resources.ArchivoIdioma.TTFechaEmisionNP);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.CodProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTCodProd);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.BuscarProdBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarProdNota);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.NombreProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNombreProd);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.DescProdTxt, MercaderSG.My.Resources.ArchivoIdioma.TTDescrProd);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.PrecioTxt, MercaderSG.My.Resources.ArchivoIdioma.TTPrecioProd);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.CantidadTxt, MercaderSG.My.Resources.ArchivoIdioma.TTIngreseCantidad);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.DetalleDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaProductoNP);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAgregarDetalle);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarDetalle);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.NuevoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTNuevoDetalle);
                    NPFrm.ControlesTP.SetToolTip(NPFrm.GenerarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTGenerarNotaPedido);
                    continue;
                }

                if (item == "GestionUsuario")
                {
                    if (!GestionUsuFrm.IsHandleCreated)
                    {
                        GestionUsuFrm = new MercaderSG.GestionUsuario();
                    }

                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUsuarioAltaBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.ModificarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUsuarioModificarBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUsuarioEliminarBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.EliminarTelBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarTelBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.SiguienteBtn, MercaderSG.My.Resources.ArchivoIdioma.TTSiguienteBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.AnteriorBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAnteriorBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.UltimoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUltimoBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.PrimeroBtn, MercaderSG.My.Resources.ArchivoIdioma.TTPrimeraBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
                    GestionUsuFrm.ControlesTP.SetToolTip(GestionUsuFrm.UsuarioDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaUsuarios);
                    continue;
                }

                if (item == "GestionFamilia")
                {
                    if (!GestionFamFrm.IsHandleCreated)
                    {
                        GestionFamFrm = new MercaderSG.GestionFamilia();
                    }

                    GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.AgregarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAgregarFam);
                    GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.ModificarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTModificarFam);
                    GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.EliminarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTEliminarFam);
                    GestionFamFrm.ControlesTP.SetToolTip(GestionFamFrm.FamiliaDG, MercaderSG.My.Resources.ArchivoIdioma.TTlistaFamilias);
                    continue;
                }

                if (item == "DesbloquearUsuario")
                {
                    if (!DesbloquearUsuFrm.IsHandleCreated)
                    {
                        DesbloquearUsuFrm = new MercaderSG.DesbloquearUsuario();
                    }

                    DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.UsuarioCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaUsuBloqueados);
                    DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAceptarDesbloquearUsu);
                    DesbloquearUsuFrm.ControlesTP.SetToolTip(DesbloquearUsuFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "ResetearContrasena")
                {
                    if (!ResetearPassFrm.IsHandleCreated)
                    {
                        ResetearPassFrm = new MercaderSG.ResetearContrasena();
                    }

                    ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.UsuarioCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaUsuarios);
                    ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAceptarResetearContraseña);
                    ResetearPassFrm.ControlesTP.SetToolTip(ResetearPassFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "Backup")
                {
                    if (!BackUpFrm.IsHandleCreated)
                    {
                        BackUpFrm = new MercaderSG.Backup();
                    }

                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.RutaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTRuta);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarRutaBK);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.VolumenNUD, MercaderSG.My.Resources.ArchivoIdioma.TTVolumenes);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.NombreZipTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNombreZip);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.ContraseñaZipTxt, MercaderSG.My.Resources.ArchivoIdioma.TTContraseñaZip);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.ReContraseñaZipTxt, MercaderSG.My.Resources.ArchivoIdioma.TTReContraseñaZip);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTGenerarBackup);
                    BackUpFrm.ControlesTP.SetToolTip(BackUpFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "Restore")
                {
                    if (!RestoreFrm.IsHandleCreated)
                    {
                        RestoreFrm = new MercaderSG.Restore();
                    }

                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarBAK);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ArchivosLB, MercaderSG.My.Resources.ArchivoIdioma.TTArchivosBAKR);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ContraseñaZipTxt, MercaderSG.My.Resources.ArchivoIdioma.TTContraseñaZip);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.ReContraseñaZipTxt, MercaderSG.My.Resources.ArchivoIdioma.TTReContraseñaZip);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.NuevoBtn, MercaderSG.My.Resources.ArchivoIdioma.NuevoRestoreLimpiar);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTGenerarRestore);
                    RestoreFrm.ControlesTP.SetToolTip(RestoreFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "Bitacora")
                {
                    if (!BitacoraFrm.IsHandleCreated)
                    {
                        BitacoraFrm = new MercaderSG.Bitacora();
                    }

                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.FiltroCMB, MercaderSG.My.Resources.ArchivoIdioma.TTFiltroBitacora);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.SiguienteBtn, MercaderSG.My.Resources.ArchivoIdioma.TTSiguienteBtn);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.AnteriorBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAnteriorBtn);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.UltimoBtn, MercaderSG.My.Resources.ArchivoIdioma.TTUltimoBtn);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.PrimeroBtn, MercaderSG.My.Resources.ArchivoIdioma.TTPrimeraBtn);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
                    BitacoraFrm.ControlesTP.SetToolTip(BitacoraFrm.BitacoraDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaBitacora);

                    // FiltroCompleto
                    BitacoraFrm.FC.ControlesTP.SetToolTip(BitacoraFrm.FC.BuscarComBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarCompleto);

                    // FiltroCriticidad
                    BitacoraFrm.FCriti.ControlesTP.SetToolTip(BitacoraFrm.FCriti.BuscarCritiBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarCriticidad);

                    // FiltroUsuario
                    BitacoraFrm.FU.ControlesTP.SetToolTip(BitacoraFrm.FU.BuscarUsuBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarUsuarios);

                    // FiltroFechas
                    BitacoraFrm.FF.ControlesTP.SetToolTip(BitacoraFrm.FF.BuscarFechaBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarFechas);
                    continue;
                }

                if (item == "FamiliaPatente")
                {
                    if (!PatFamFrm.IsHandleCreated)
                    {
                        PatFamFrm = new MercaderSG.FamiliaPatente();
                    }

                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.FamiliaCMB, MercaderSG.My.Resources.ArchivoIdioma.TTFamiliaCMB);
                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarFam);
                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.PatentesCLB, MercaderSG.My.Resources.ArchivoIdioma.TTPatentesNoFam);
                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.DenPatentesCLB, MercaderSG.My.Resources.ArchivoIdioma.TTPatentesFam);
                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAltaBajaPatFam);
                    PatFamFrm.ControlesTP.SetToolTip(PatFamFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "UsuarioFamilia")
                {
                    if (!UsuFamFrm.IsHandleCreated)
                    {
                        UsuFamFrm = new MercaderSG.UsuarioFamilia();
                    }

                    UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.UsuarioCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaUsuarios);
                    UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.FamiliaCLB, MercaderSG.My.Resources.ArchivoIdioma.TTlistaFamilias);
                    UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAltaUsuFam);
                    UsuFamFrm.ControlesTP.SetToolTip(UsuFamFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "UsuarioPatente")
                {
                    if (!UsuPatFrm.IsHandleCreated)
                    {
                        UsuPatFrm = new MercaderSG.UsuarioPatente();
                    }

                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.UsuariosCMB, MercaderSG.My.Resources.ArchivoIdioma.TTListaUsuarios);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarUsuariosPat);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.DenPatentesCLB, MercaderSG.My.Resources.ArchivoIdioma.TTPatentesNoUsu);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.PatDenegadasCLB, MercaderSG.My.Resources.ArchivoIdioma.TTPatDenegadasUsu);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.PatentesCLB, MercaderSG.My.Resources.ArchivoIdioma.TTPatentesUsu);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTAltaBajaPatUsu);
                    UsuPatFrm.ControlesTP.SetToolTip(UsuPatFrm.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                    continue;
                }

                if (item == "CambiarContrasena")
                {
                    if (!CambiarPass.IsHandleCreated)
                    {
                        CambiarPass = new MercaderSG.CambiarContrasena();
                    }

                    CambiarPass.ControlesTP.SetToolTip(CambiarPass.ConAnteriorTxt, MercaderSG.My.Resources.ArchivoIdioma.TTConAnterior);
                    CambiarPass.ControlesTP.SetToolTip(CambiarPass.NuevaContraseñaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTNuevaCon);
                    CambiarPass.ControlesTP.SetToolTip(CambiarPass.ReNuevaContraseñaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTConfirmarCon);
                    CambiarPass.ControlesTP.SetToolTip(CambiarPass.AceptarBtn, MercaderSG.My.Resources.ArchivoIdioma.CambiarContraseña);
                    CambiarPass.ControlesTP.SetToolTip(CambiarPass.CancelarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTCancelarBtn);
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void GestionClienteSMI_Click(object sender, EventArgs e)
        {
            if (!GestionCliFrm.IsHandleCreated)
            {
                GestionCliFrm = new MercaderSG.GestionCliente();
            }

            GestionCliFrm.MdiParent = this;
            GestionCliFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionCliFrm.Show();
            this.GestionClienteSMI.Enabled = false;
        }

        private void GestionProveedorSMI_Click(object sender, EventArgs e)
        {
            if (!GestionProvFrm.IsHandleCreated)
            {
                GestionProvFrm = new MercaderSG.GestionProveedor();
            }

            GestionProvFrm.MdiParent = this;
            GestionProvFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionProvFrm.Show();
            this.GestionProveedorSMI.Enabled = false;
        }

        private void GestionProductoSMI_Click(object sender, EventArgs e)
        {
            if (!GestionProdFrm.IsHandleCreated)
            {
                GestionProdFrm = new MercaderSG.GestionProducto();
            }

            GestionProdFrm.MdiParent = this;
            GestionProdFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionProdFrm.Show();
            this.GestionProductoSMI.Enabled = false;
        }

        private void GestionNVSMI_Click(object sender, EventArgs e)
        {
            if (!GestionNVFrm.IsHandleCreated)
            {
                GestionNVFrm = new MercaderSG.GestionNV();
            }

            GestionNVFrm.MdiParent = this;
            GestionNVFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionNVFrm.Show();
            this.GestionNVSMI.Enabled = false;
        }

        private void GenerarNVSMI_Click(object sender, EventArgs e)
        {
            if (!NVFrm.IsHandleCreated)
            {
                NVFrm = new MercaderSG.NotaVenta();
            }

            NVFrm.MdiParent = this;
            NVFrm.StartPosition = FormStartPosition.CenterScreen;
            NVFrm.Show();
            this.GenerarNVSMI.Enabled = false;
        }

        private void GestionNPSMI_Click(object sender, EventArgs e)
        {
            if (!GestionNPFrm.IsHandleCreated)
            {
                GestionNPFrm = new MercaderSG.GestionNP();
            }

            GestionNPFrm.MdiParent = this;
            GestionNPFrm.StartPosition = FormStartPosition.CenterParent;
            GestionNPFrm.Show();
            this.GestionNPSMI.Enabled = false;
        }

        private void GenerarNPSMI_Click(object sender, EventArgs e)
        {
            if (!NPFrm.IsHandleCreated)
            {
                NPFrm = new MercaderSG.NotaPedido();
            }

            NPFrm.MdiParent = this;
            NPFrm.StartPosition = FormStartPosition.CenterScreen;
            NPFrm.Show();
            this.GenerarNPSMI.Enabled = false;
        }

        private void GestionUsuarioSMI_Click(object sender, EventArgs e)
        {
            if (!GestionUsuFrm.IsHandleCreated)
            {
                GestionUsuFrm = new MercaderSG.GestionUsuario();
            }

            GestionUsuFrm.MdiParent = this;
            GestionUsuFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionUsuFrm.Show();
            this.GestionUsuarioSMI.Enabled = false;
        }

        private void GestionFamiliaSMI_Click(object sender, EventArgs e)
        {
            if (!GestionFamFrm.IsHandleCreated)
            {
                GestionFamFrm = new MercaderSG.GestionFamilia();
            }

            GestionFamFrm.MdiParent = this;
            GestionFamFrm.StartPosition = FormStartPosition.CenterScreen;
            GestionFamFrm.Show();
            this.GestionFamiliaSMI.Enabled = false;
        }

        private void DesbloquearUsuarioSMI_Click(object sender, EventArgs e)
        {
            if (!DesbloquearUsuFrm.IsHandleCreated)
            {
                DesbloquearUsuFrm = new MercaderSG.DesbloquearUsuario();
            }

            DesbloquearUsuFrm.MdiParent = this;
            DesbloquearUsuFrm.StartPosition = FormStartPosition.CenterScreen;
            DesbloquearUsuFrm.Show();
            if (DesbloquearUsuFrm.UsuarioCMB.Items.Count == 0)
            {
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.NoUsuBloqueados, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DesbloquearUsuFrm.Close();
                this.DesbloquearUsuarioSMI.Enabled = true;
                return;
            }

            this.DesbloquearUsuarioSMI.Enabled = false;
        }

        private void ResetearContrasenaSMI_Click(object sender, EventArgs e)
        {
            if (!ResetearPassFrm.IsHandleCreated)
            {
                ResetearPassFrm = new MercaderSG.ResetearContrasena();
            }

            ResetearPassFrm.MdiParent = this;
            ResetearPassFrm.StartPosition = FormStartPosition.CenterScreen;
            ResetearPassFrm.Show();
            this.ResetearContrasenaSMI.Enabled = false;
        }

        private void BackupSMI_Click(object sender, EventArgs e)
        {
            if (!BackUpFrm.IsHandleCreated)
            {
                BackUpFrm = new MercaderSG.Backup();
            }

            BackUpFrm.MdiParent = this;
            BackUpFrm.StartPosition = FormStartPosition.CenterScreen;
            BackUpFrm.Show();
            this.BackupSMI.Enabled = false;
        }

        private void RestoreSMI_Click(object sender, EventArgs e)
        {
            if (!RestoreFrm.IsHandleCreated)
            {
                RestoreFrm = new MercaderSG.Restore();
            }

            RestoreFrm.MdiParent = this;
            RestoreFrm.StartPosition = FormStartPosition.CenterScreen;
            RestoreFrm.Show();
            this.RestoreSMI.Enabled = false;
        }

        private void BitacoraSMI_Click(object sender, EventArgs e)
        {
            if (!BitacoraFrm.IsHandleCreated)
            {
                BitacoraFrm = new MercaderSG.Bitacora();
            }

            BitacoraFrm.MdiParent = this;
            BitacoraFrm.StartPosition = FormStartPosition.CenterScreen;
            BitacoraFrm.Show();
            this.BitacoraSMI.Enabled = false;
        }

        private void PatFamSMI_Click(object sender, EventArgs e)
        {
            if (!PatFamFrm.IsHandleCreated)
            {
                PatFamFrm = new MercaderSG.FamiliaPatente();
            }

            PatFamFrm.MdiParent = this;
            PatFamFrm.StartPosition = FormStartPosition.CenterScreen;
            PatFamFrm.Show();
            this.PatFamSMI.Enabled = false;
        }

        private void UsuFamSMI_Click(object sender, EventArgs e)
        {
            if (!UsuFamFrm.IsHandleCreated)
            {
                UsuFamFrm = new MercaderSG.UsuarioFamilia();
            }

            UsuFamFrm.MdiParent = this;
            UsuFamFrm.StartPosition = FormStartPosition.CenterScreen;
            UsuFamFrm.Show();
            this.UsuFamSMI.Enabled = false;
        }

        private void PatUsuSMI_Click(object sender, EventArgs e)
        {
            if (!UsuPatFrm.IsHandleCreated)
            {
                UsuPatFrm = new MercaderSG.UsuarioPatente();
            }

            UsuPatFrm.MdiParent = this;
            UsuPatFrm.StartPosition = FormStartPosition.CenterScreen;
            UsuPatFrm.Show();
            this.PatUsuSMI.Enabled = false;
        }

        private void RecalcularDVSMI_Click(object sender, EventArgs e)
        {
            var Resultado = MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.PregDV, MercaderSG.My.Resources.ArchivoIdioma.PreguntaTituDV, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Resultado == DialogResult.OK)
            {

                // DVH
                Integridad.RecalcularDVH(DtErrorIntegridad);
                // DVV
                Integridad.RecalcularDVV(DtErrorIntegridadDVV);
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.VerificoIntegridad, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxInformacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.RecalcularDVSMI.Enabled = false;
            }
            else
            {
                return;
            }
        }

        private void EspanolSMI_Click(object sender, EventArgs e)
        {
            var Resultado = MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.CambiarIdiomaESP, MercaderSG.My.Resources.ArchivoIdioma.CambiarIdioma, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Resultado == DialogResult.OK)
            {
                this.EspanolSMI.Enabled = false;
                this.InglesSMI.Enabled = true;
                ListaFormsNombres.Clear();
                ListaFormsNombresTT.Clear();
                foreach (Form f in Application.OpenForms)
                {
                    ListaFormsNombres.Add(f.Name);
                    ListaFormsNombresTT.Add(f.Name);
                }

                Idioma.AplicarIdioma("es-AR");
                AplicarIdioma(false, ListaFormsNombres);
                CargarTT(ListaFormsNombresTT);
            }
            else
            {
                return;
            }
        }

        private void InglesSMI_Click(object sender, EventArgs e)
        {
            var Resultado = MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.CambiarIdiomaUS, MercaderSG.My.Resources.ArchivoIdioma.CambiarIdioma, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Resultado == DialogResult.OK)
            {
                this.EspanolSMI.Enabled = true;
                this.InglesSMI.Enabled = false;
                ListaFormsNombres.Clear();
                ListaFormsNombresTT.Clear();
                foreach (Form f in Application.OpenForms)
                {
                    ListaFormsNombres.Add(f.Name);
                    ListaFormsNombresTT.Add(f.Name);
                }

                Idioma.AplicarIdioma("en-US");
                AplicarIdioma(false, ListaFormsNombres);
                CargarTT(ListaFormsNombresTT);
            }
            else
            {
                return;
            }
        }

        private void CambiarContrasenaSMI_Click(object sender, EventArgs e)
        {
            if (!CambiarPass.IsHandleCreated)
            {
                CambiarPass = new MercaderSG.CambiarContrasena();
            }

            CambiarPass.MdiParent = this;
            CambiarPass.StartPosition = FormStartPosition.CenterScreen;
            CambiarPass.Show();
            this.CambiarContrasenaSMI.Enabled = false;
        }

        private void SalirSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count - 1 != 0)
            {
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.FormulariosAbiertos, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                var UsuAut = Autenticar.Instancia();
                LogOut.CerrarSesion(UsuAut.UsuarioLogueado);
                Application.Exit();
                // Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-AR")

                // Dim frm As New LogIn
                // frm.Show()
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void BloquearSistema()
        {
            this.GestionSMI.Enabled = false;
            this.ComercialSMI.Enabled = false;
            if (EstadoIntegridad == true)
            {
                this.BackupSMI.Enabled = false;
                this.RestoreSMI.Enabled = false;
                this.BitacoraSMI.Enabled = false;
                this.PatFamSMI.Enabled = false;
                this.PatUsuSMI.Enabled = false;
                this.UsuFamSMI.Enabled = false;
                this.RecalcularDVSMI.Enabled = true;
            }
            else
            {
                this.SeguridadSMI.Enabled = false;
            }

            this.SistemaSMI.Enabled = false;
            this.IdiomaSMI.Enabled = false;
            this.CambiarContrasenaSMI.Enabled = false;
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if ((int)e.KeyData == (int)Keys.Control + (int)Keys.G & !(this.GestionSMI.Enabled == false))
            {
                this.GestionSMI.ShowDropDown();
            }

            if ((int)e.KeyData == (int)Keys.Control + (int)Keys.C & !(this.ComercialSMI.Enabled == false))
            {
                this.ComercialSMI.ShowDropDown();
            }

            if ((int)e.KeyData == (int)Keys.Control + (int)Keys.S & !(this.SistemaSMI.Enabled == false))
            {
                this.SistemaSMI.ShowDropDown();
            }

            if ((int)e.KeyData == (int)Keys.Control + (int)Keys.Alt + (int)Keys.S & !(this.SeguridadSMI.Enabled == false))
            {
                this.SeguridadSMI.ShowDropDown();
            }

            if ((int)e.KeyData == (int)Keys.Control + (int)Keys.P & !(this.PanelSMI.Enabled == false))
            {
                this.PanelSMI.ShowDropDown();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}