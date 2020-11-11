using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Servicios;

namespace MercaderSG
{
    internal class SubMain
    {
        [STAThread()]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            var ListaTablas = new List<DVHEN>();
            var ListaErrorInt = new List<ErrorIntegridadEN>();
            var DtErrorInt = new DataTable();
            DtErrorInt.Columns.Add("Tabla", typeof(string));
            DtErrorInt.Columns.Add("CodReg", typeof(int));
            DtErrorInt.Columns.Add("CodAux", typeof(int));
            DtErrorInt.Columns.Add("ValorDVH", typeof(int));
            var DtErrorIntDVV = new DataTable();
            DtErrorIntDVV.Columns.Add("Tabla", typeof(string));
            var TablaBit = new DVHEN("Bitacora", "CodBit");
            ListaTablas.Add(TablaBit);
            var TablaCli = new DVHEN("Cliente", "CodCli");
            ListaTablas.Add(TablaCli);
            var TablaFamPat = new DVHEN("Fam_Pat", "Familia_CodFam");
            ListaTablas.Add(TablaFamPat);
            var TablaHP = new DVHEN("Historico_Precio", "CodHist");
            ListaTablas.Add(TablaHP);
            var TablaProd = new DVHEN("Producto", "CodProd");
            ListaTablas.Add(TablaProd);
            var TablaUsuFam = new DVHEN("Usu_Fam", "Usuario_CodUsu");
            ListaTablas.Add(TablaUsuFam);
            var TablaUsuPat = new DVHEN("Usu_Pat", "Usuario_CodUsu");
            ListaTablas.Add(TablaUsuPat);
            var TablaUsuario = new DVHEN("Usuario", "CodUsu");
            ListaTablas.Add(TablaUsuario);
            var DatosTabla = new DVHEN();
            DatosTabla.DtIntegridad = DtErrorInt;
            DatosTabla.DtIntegridadDVV = DtErrorIntDVV;
            foreach (DVHEN item in ListaTablas)
            {
                DatosTabla.Tabla = item.Tabla;
                DatosTabla.Columna = item.Columna;
                try
                {
                    var ErrorInt = new ErrorIntegridadEN();
                    ErrorInt = Integridad.VerificarIntegridad(DatosTabla);
                    if (!string.IsNullOrEmpty(ErrorInt.Tabla))
                    {
                        ListaErrorInt.Add(ErrorInt);
                    }
                }
                catch (CriticalException ex)
                {
                    MessageBox.Show(ex.Message, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (ListaErrorInt.Count > 0)
            {
                MessageBox.Show(MercaderSG.My.Resources.ArchivoIdioma.ErrorIntegridad, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var frm = new MercaderSG.LogIn();
            frm.ListaErrorInt = ListaErrorInt;
            frm.DtErrorIntegridad = DatosTabla.DtIntegridad;
            frm.DtErrorIntegridadDVV = DatosTabla.DtIntegridadDVV;
            frm.ShowDialog();
            Application.Run();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            var FS = new FileStream("InformeErrores.txt", FileMode.Append);
            var SW = new StreamWriter(FS);
            SW.WriteLine("-----------------------------------------------------");
            SW.WriteLine("");
            SW.WriteLine("Fecha: " + DateTime.Now);
            SW.WriteLine("Mensaje: " + e.Exception.Message);
            SW.WriteLine("Pila de llamadas: " + e.Exception.StackTrace);
            SW.WriteLine("Aplicación:" + e.Exception.Source);
            SW.WriteLine("");
            SW.Close();
            FS.Close();
            MessageBox.Show(e.Exception.Message, MercaderSG.My.Resources.ArchivoIdioma.MsgBoxCritico, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}