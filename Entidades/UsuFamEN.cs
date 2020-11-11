using System.Collections.Generic;

namespace Entidades
{
    public class UsuFamEN
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

        private List<int> _listapatentes;

        public List<int> ListaPatentes
        {
            get
            {
                return _listapatentes;
            }

            set
            {
                _listapatentes = value;
            }
        }

        private string _usuariofam;

        public string UsuarioFam
        {
            get
            {
                return _usuariofam;
            }

            set
            {
                _usuariofam = value;
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

        private bool _notienepat;

        public bool NoTienePat
        {
            get
            {
                return _notienepat;
            }

            set
            {
                _notienepat = value;
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