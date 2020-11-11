using System.Data;

namespace Servicios
{
    public class Autenticar
    {
        private static Autenticar Aut;

        public Autenticar()
        {
        }

        public static Autenticar Instancia()
        {
            if (Aut is null)
            {
                Aut = new Autenticar();
            }

            return Aut;
        }

        private string _usuariologueado;

        public string UsuarioLogueado
        {
            get
            {
                return _usuariologueado;
            }

            set
            {
                _usuariologueado = value;
            }
        }

        private int _codusulogueado;

        public int CodUsuLogueado
        {
            get
            {
                return _codusulogueado;
            }

            set
            {
                _codusulogueado = value;
            }
        }

        private DataTable _dtpatusu;

        public DataTable dtPatUsu
        {
            get
            {
                return _dtpatusu;
            }

            set
            {
                _dtpatusu = value;
            }
        }
    }
}