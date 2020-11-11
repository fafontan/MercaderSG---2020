
namespace Entidades
{
    public class PatenteEN
    {
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

        private string _descripcion;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }
    }
}