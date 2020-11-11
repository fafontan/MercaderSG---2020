using System.Data;

namespace Entidades
{
    public class DVHEN
    {
        public DVHEN()
        {
        }

        public DVHEN(string TablaM, string ColumnaM)
        {
            _tabla = TablaM;
            _columna = ColumnaM;
        }

        private string _tabla;

        public string Tabla
        {
            get
            {
                return _tabla;
            }

            set
            {
                _tabla = value;
            }
        }

        private int _codreg;

        public int CodReg
        {
            get
            {
                return _codreg;
            }

            set
            {
                _codreg = value;
            }
        }

        private int _codaux;

        public int CodAux
        {
            get
            {
                return _codaux;
            }

            set
            {
                _codaux = value;
            }
        }

        private string _colactivo;

        public string ColActivo
        {
            get
            {
                return _colactivo;
            }

            set
            {
                _colactivo = value;
            }
        }

        private string _columna;

        public string Columna
        {
            get
            {
                return _columna;
            }

            set
            {
                _columna = value;
            }
        }

        private string _cadena;

        public string Cadena
        {
            get
            {
                return _cadena;
            }

            set
            {
                _cadena = value;
            }
        }

        private bool _estado;

        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        private DataTable _dtintegridad;

        public DataTable DtIntegridad
        {
            get
            {
                return _dtintegridad;
            }

            set
            {
                _dtintegridad = value;
            }
        }

        private DataTable _dtintegridaddvv;

        public DataTable DtIntegridadDVV
        {
            get
            {
                return _dtintegridaddvv;
            }

            set
            {
                _dtintegridaddvv = value;
            }
        }
    }
}