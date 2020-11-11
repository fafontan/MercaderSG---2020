
namespace Entidades
{
    public class PatUsuEN
    {
        private int _codusu;

        public int CodUsu
        {
            get
            {
                return _codusu;
            }

            set
            {
                _codusu = value;
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

        private string _usuariopat;

        public string UsuarioPat
        {
            get
            {
                return _usuariopat;
            }

            set
            {
                _usuariopat = value;
            }
        }

        private string _descpat;

        public string DescPat
        {
            get
            {
                return _descpat;
            }

            set
            {
                _descpat = value;
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
    }
}