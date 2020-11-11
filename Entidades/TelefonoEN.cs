
namespace Entidades
{
    public class TelefonoEN
    {
        private int _codtel;

        public int CodTel
        {
            get
            {
                return _codtel;
            }

            set
            {
                _codtel = value;
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

        private string _numero;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }
    }
}