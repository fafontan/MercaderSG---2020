using System.Collections.Generic;

namespace EntidadesC
{
    public class ClienteEN
    {
        private int _codcli;

        public int CodCli
        {
            get
            {
                return _codcli;
            }

            set
            {
                _codcli = value;
            }
        }

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

        private string _cuit;

        public string Cuit
        {
            get
            {
                return _cuit;
            }

            set
            {
                _cuit = value;
            }
        }

        private string _razonsocial;

        public string RazonSocial
        {
            get
            {
                return _razonsocial;
            }

            set
            {
                _razonsocial = value;
            }
        }

        private string _calle;

        public string Calle
        {
            get
            {
                return _calle;
            }

            set
            {
                _calle = value;
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

        private string _piso;

        public string Piso
        {
            get
            {
                return _piso;
            }

            set
            {
                _piso = value;
            }
        }

        private string _departamento;

        public string Departamento
        {
            get
            {
                return _departamento;
            }

            set
            {
                _departamento = value;
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

        private string _direccion;

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        private string _localidad;

        public string Localidad
        {
            get
            {
                return _localidad;
            }

            set
            {
                _localidad = value;
            }
        }

        private List<Entidades.TelefonoEN> _telefono;

        public List<Entidades.TelefonoEN> Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }
    }
}
