using System.Collections.Generic;

namespace EntidadesC
{
    public class NotaVentaEN
    {
        private int _codnot;

        public int CodNot
        {
            get
            {
                return _codnot;
            }

            set
            {
                _codnot = value;
            }
        }

        private string _nronota;

        public string NroNota
        {
            get
            {
                return _nronota;
            }

            set
            {
                _nronota = value;
            }
        }

        private int _codcli;

        public int CodCli
        {
            get
            {
                return _codcli;
            }

            set
            {
                _codcli = value;
            }
        }

        private string _fecha;

        public string Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
            }
        }

        private string _activo;

        public string Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                _activo = value;
            }
        }

        private List<Entidades.DetalleEN> _detalle;

        public List<Entidades.DetalleEN> Detalle
        {
            get
            {
                return _detalle;
            }

            set
            {
                _detalle = value;
            }
        }
    }
}