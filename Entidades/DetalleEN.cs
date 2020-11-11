
namespace Entidades
{
    public class DetalleEN
    {
        private int _codnot;

        public int CodNot
        {
            get
            {
                return _codnot;
            }

            set
            {
                _codnot = value;
            }
        }

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

        private string _nombreproducto;

        public string NombreProducto
        {
            get
            {
                return _nombreproducto;
            }

            set
            {
                _nombreproducto = value;
            }
        }
    }
}