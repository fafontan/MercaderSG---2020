
namespace Entidades
{
    public class LocalidadEN
    {
        private int _codloc;

        public int CodLoc
        {
            get
            {
                return _codloc;
            }

            set
            {
                _codloc = value;
            }
        }

        private int _codprovincia;

        public int CodProvincia
        {
            get
            {
                return _codprovincia;
            }

            set
            {
                _codprovincia = value;
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

        private string _codigopostal;

        public string CodigoPostal
        {
            get
            {
                return _codigopostal;
            }

            set
            {
                _codigopostal = value;
            }
        }
    }
}