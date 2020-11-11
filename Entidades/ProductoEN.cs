
namespace Entidades
{
    public class ProductoEN
    {
        private int _codprod;

        public int CodProd
        {
            get
            {
                return _codprod;
            }

            set
            {
                _codprod = value;
            }
        }

        private int _codhistorico;

        public int CodHistorico
        {
            get
            {
                return _codhistorico;
            }

            set
            {
                _codhistorico = value;
            }
        }

        private string _nombre;

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
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

        private int _cantidad;

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;
            }
        }

        private string _precio;

        public string Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }

        private string _sector;

        public string Sector
        {
            get
            {
                return _sector;
            }

            set
            {
                _sector = value;
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