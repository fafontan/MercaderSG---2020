
namespace Entidades
{
    public class DVVEN
    {
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

        private int _coden;

        public int CodEn
        {
            get
            {
                return _coden;
            }

            set
            {
                _coden = value;
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

        private int _valordvh;

        public int ValorDVH
        {
            get
            {
                return _valordvh;
            }

            set
            {
                _valordvh = value;
            }
        }

        private int _valordvhantiguo;

        public int ValorDVHAntiguo
        {
            get
            {
                return _valordvhantiguo;
            }

            set
            {
                _valordvhantiguo = value;
            }
        }

        private string _tipoaccion;

        public string TipoAccion
        {
            get
            {
                return _tipoaccion;
            }

            set
            {
                _tipoaccion = value;
            }
        }
    }
}