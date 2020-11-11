using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Microsoft.VisualBasic.CompilerServices;
using Negocios;

namespace MercaderSG
{
    public partial class BuscarProveedor
    {
        public BuscarProveedor()
        {
            InitializeComponent();
            _ProveedorDG.Name = "ProveedorDG";
            _RecargarBtn.Name = "RecargarBtn";
            _BuscarBtn.Name = "BuscarBtn";
        }

        private List<ProveedorEN> ListaProv = new List<ProveedorEN>();
        private List<ProveedorEN> ListaProvTemp = new List<ProveedorEN>();
        private List<ProveedorEN> ListaProvTempGral = new List<ProveedorEN>();
        private int NroPag = 0;
        private ProveedorEN _provsel;

        public ProveedorEN ProvSel
        {
            get
            {
                return _provsel;
            }

            set
            {
                _provsel = value;
            }
        }

        private void BuscarProveedor_Load(object sender, EventArgs e)
        {
            this.BGW.WorkerReportsProgress = true;
            this.BGW.WorkerSupportsCancellation = true;
            this.BGW.RunWorkerAsync();
            MercaderSG.My.MyProject.Forms.BarraProgreso.ShowDialog();
            CargarTT();
            AplicarIdioma();
            this.CargarFoco(this.ProveedorGB);
            this.BuscarCmb.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.CMBCuit);
            this.BuscarCmb.Items.Add(MercaderSG.My.Resources.ArchivoIdioma.CMBRazonSocial);
            this.BuscarCmb.SelectedIndex = 0;
            ListaProvTempGral.AddRange(ListaProv);
        }

        private void BGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ListaProv = ProveedorRN.CargarProveedor();
            for (int i = 0, loopTo = ListaProv.Count - 1; i <= loopTo; i++)
            {
                if (this.BGW.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    this.BGW.ReportProgress((int)(100 * i / (double)ListaProv.Count));
                }
            }
        }

        private void BGW_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            MercaderSG.My.MyProject.Forms.BarraProgreso.ProgressBar1.Value = e.ProgressPercentage;
        }

        private void BGW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.ProveedorDG.AutoGenerateColumns = false;
            this.ProveedorDG.DataSource = PaginaSig(NroPag);
            MercaderSG.My.MyProject.Forms.BarraProgreso.ProgressBar1.Value = 0;
            MercaderSG.My.MyProject.Forms.BarraProgreso.Close();
        }

        public List<ProveedorEN> PaginaSig(int NroPagActual)
        {
            var ListaAux = new List<ProveedorEN>();
            foreach (ProveedorEN item in ListaProv.Paginacion(NroPag))
            {
                var UnProveedor = new ProveedorEN();
                UnProveedor.CodProv = item.CodProv;
                UnProveedor.RazonSocial = item.RazonSocial;
                UnProveedor.Cuit = item.Cuit;
                UnProveedor.Direccion = item.Direccion;
                UnProveedor.CorreoElectronico = item.CorreoElectronico;
                UnProveedor.Activo = item.Activo;
                ListaAux.Add(UnProveedor);
            }

            return ListaAux;
        }

        private void RecargarBtn_Click(object sender, EventArgs e)
        {
            ListaProv.Clear();
            ListaProv.AddRange(ListaProvTempGral);
            NroPag = 0;
            this.ProveedorDG.DataSource = null;
            this.ProveedorDG.DataSource = PaginaSig(NroPag);
        }

        private void BuscarBtn_Click(object sender, EventArgs e)
        {
            NroPag = 0;
            ListaProvTemp.Clear();
            ListaProvTemp.AddRange(ListaProv);
            ListaProv.Clear();
            try
            {
                ListaProv = ProveedorRN.BuscarProveedor(Conversions.ToString(this.BuscarCmb.SelectedItem), this.BusquedaTxt.Text);
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BusquedaTxt.Clear();
                ListaProv.Clear();
                ListaProv.AddRange(ListaProvTempGral);
                NroPag = 0;
                this.ProveedorDG.DataSource = null;
                this.ProveedorDG.DataSource = PaginaSig(NroPag);
            }

            this.ProveedorDG.DataSource = null;
            this.ProveedorDG.AutoGenerateColumns = false;
            this.ProveedorDG.DataSource = PaginaSig(NroPag);
            if (this.ProveedorDG.Rows.Count == 0)
            {
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.NoExisteProvBusqueda, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BusquedaTxt.Clear();
                ListaProv.Clear();
                ListaProv.AddRange(ListaProvTempGral);
                NroPag = 0;
                this.ProveedorDG.DataSource = null;
                this.ProveedorDG.DataSource = PaginaSig(NroPag);
            }
        }

        private void ProveedorDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _provsel = (ProveedorEN)this.ProveedorDG.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool ConsistenciaDatos()
        {
            bool Resultado = true;
            if (string.IsNullOrEmpty(this.BusquedaTxt.Text))
            {
                this.MensajeTT.Show(MercaderSG.My.Resources.ArchivoIdioma.BusquedaVacia, this.BusquedaTxt);
                this.BusquedaTxt.Clear();
                this.BusquedaTxt.Focus();
                Resultado = false;
            }

            switch (this.BuscarCmb.SelectedItem)
            {
                case var @case when Operators.ConditionalCompareObjectEqual(@case, MercaderSG.My.Resources.ArchivoIdioma.CMBCuit, false):
                    {
                        switch (this.BusquedaTxt.Text.Length)
                        {
                            case var case1 when case1 > 13:
                                {
                                    this.MensajeTT.Show(MercaderSG.My.Resources.ArchivoIdioma.Contener13Carac, this.BusquedaTxt);
                                    this.BusquedaTxt.Focus();
                                    Resultado = false;
                                    break;
                                }

                            case var case2 when 1 <= case2 && case2 <= 13:
                                {
                                    var Cuit = new Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})");
                                    if (!Cuit.IsMatch(this.BusquedaTxt.Text))
                                    {
                                        this.MensajeTT.Show(MercaderSG.My.Resources.ArchivoIdioma.FormatoCUIT, this.BusquedaTxt);
                                        this.BusquedaTxt.Focus();
                                        Resultado = false;
                                    }

                                    break;
                                }

                            case var case3 when case3 == 13:
                                {
                                    var Cuit = new Regex("([0-9]{2})[-]([0-9]{8})[-]([0-9]{1})");
                                    if (!Cuit.IsMatch(this.BusquedaTxt.Text))
                                    {
                                        this.MensajeTT.Show(MercaderSG.My.Resources.ArchivoIdioma.FormatoCUIT, this.BusquedaTxt);
                                        this.BusquedaTxt.Focus();
                                        Resultado = false;
                                    }

                                    break;
                                }
                        }

                        break;
                    }

                case var case4 when Operators.ConditionalCompareObjectEqual(case4, MercaderSG.My.Resources.ArchivoIdioma.CMBRazonSocial, false):
                    {
                        if (this.BusquedaTxt.Text.Length > 50)
                        {
                            this.MensajeTT.Show(MercaderSG.My.Resources.ArchivoIdioma.Contener50Carac, this.BusquedaTxt);
                            this.BusquedaTxt.Focus();
                            Resultado = false;
                        }

                        break;
                    }
            }

            return Resultado;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void AplicarIdioma()
        {
            this.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarProveedorFrm;
            this.ProveedorGB.Text = MercaderSG.My.Resources.ArchivoIdioma.SeleccionarProv;
            this.BuscarPorLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarPorLbl;
            this.IgualLbl.Text = MercaderSG.My.Resources.ArchivoIdioma.IgualALbl;
            this.BuscarBtn.Text = MercaderSG.My.Resources.ArchivoIdioma.BuscarBtn;
            this.CodProvCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CodigoCAB;
            this.RazonSocialCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.RazonSocialGral;
            this.CuitCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.CuitGral;
            this.DireccionCAB.HeaderText = MercaderSG.My.Resources.ArchivoIdioma.DireccionCAB;
        }

        private void CargarTT()
        {
            this.ControlesTP.SetToolTip(this.BusquedaTxt, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarProvTxt);
            this.ControlesTP.SetToolTip(this.BuscarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTBuscarProv);
            this.ControlesTP.SetToolTip(this.RecargarBtn, MercaderSG.My.Resources.ArchivoIdioma.TTRecargarBtn);
            this.ControlesTP.SetToolTip(this.ProveedorDG, MercaderSG.My.Resources.ArchivoIdioma.TTListaProveedor);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void TieneFoco(object sender, EventArgs e)
        {
            TextBox MiTextBox = (TextBox)sender;
            MiTextBox.BackColor = Color.WhiteSmoke;
        }

        private void PierdeFoco(object sender, EventArgs e)
        {
            TextBox MiTextBox = (TextBox)sender;
            MiTextBox.BackColor = Color.White;
        }

        public void CargarFoco(GroupBox Grupo)
        {
            foreach (Control Ctrl in Grupo.Controls)
            {
                if (Ctrl is TextBox)
                {
                    TextBox MiTextBox = (TextBox)Ctrl;
                    if (MiTextBox.ReadOnly == false)
                    {
                        MiTextBox.GotFocus += TieneFoco;
                        MiTextBox.LostFocus += PierdeFoco;
                    }
                }
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void ProveedorDG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _provsel = (ProveedorEN)this.ProveedorDG.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}