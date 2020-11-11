
namespace Entidades
{
    public class ErrorIntegridadEN
    {
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

        private string _tipo;

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        private bool _estadomensaje;

        public bool EstadoMensaje
        {
            get
            {
                return _estadomensaje;
            }

            set
            {
                _estadomensaje = value;
            }
        }
    }
}