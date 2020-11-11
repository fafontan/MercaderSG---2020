using System;
using System.Collections.Generic;

namespace Entidades
{
    public class NVRemitoEN
    {
        private int _codremito;

        public int CodRemito
        {
            get
            {
                return _codremito;
            }

            set
            {
                _codremito = value;
            }
        }

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

        private int _nroremito;

        public int NroRemito
        {
            get
            {
                return _nroremito;
            }

            set
            {
                _nroremito = value;
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

        private List<Entidades.DetalleEN> _detalle;

        public List<Entidades.DetalleEN> Detalle
        {
            get
            {
                return _detalle;
            }

            set
            {
                _detalle = value;
            }
        }
    }
}