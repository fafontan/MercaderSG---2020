using System;

namespace Entidades
{
    public class BitacoraEN
    {
        private int _codbit;

        public int CodBit
        {
            get
            {
                return _codbit;
            }

            set
            {
                _codbit = value;
            }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
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

        private string _criticidad;

        public string Criticidad
        {
            get
            {
                return _criticidad;
            }

            set
            {
                _criticidad = value;
            }
        }

        private string _usuario;

        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
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