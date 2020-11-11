
namespace Entidades
{
    public class FamPatEN
    {
        private int _codfam;

        public int CodFam
        {
            get
            {
                return _codfam;
            }

            set
            {
                _codfam = value;
            }
        }

        private int _codpat;

        public int CodPat
        {
            get
            {
                return _codpat;
            }

            set
            {
                _codpat = value;
            }
        }

        private string _descfam;

        public string DescFam
        {
            get
            {
                return _descfam;
            }

            set
            {
                _descfam = value;
            }
        }

        private string _descPat;

        public string DescPat
        {
            get
            {
                return _descPat;
            }

            set
            {
                _descPat = value;
            }
        }

        private int _dvh;

        public int DVH
        {
            get
            {
                return _dvh;
            }

            set
            {
                _dvh = value;
            }
        }

        private bool _activo;

        public bool Activo
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
    }
}