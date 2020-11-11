using System;
using System.Collections.Generic;

namespace Entidades
{
    public class UsuarioEN
    {
        private int _codusu;

        public int CodUsu
        {
            get
            {
                return _codusu;
            }

            set
            {
                _codusu = value;
            }
        }

        private int _codidioma;

        public int CodIdioma
        {
            get
            {
                return _codidioma;
            }

            set
            {
                _codidioma = value;
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

        private string _contraseña;

        public string Contraseña
        {
            get
            {
                return _contraseña;
            }

            set
            {
                _contraseña = value;
            }
        }

        private string _apellido;

        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = value;
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

        private string _correo;

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        private string _correoelectronico;

        public string CorreoElectronico
        {
            get
            {
                return _correoelectronico;
            }

            set
            {
                _correoelectronico = value;
            }
        }

        private DateTime _fechanacimiento;

        public DateTime FechaNacimiento
        {
            get
            {
                return _fechanacimiento;
            }

            set
            {
                _fechanacimiento = value;
            }
        }

        private int _edad;

        public int Edad
        {
            get
            {
                return _edad;
            }

            set
            {
                _edad = value;
            }
        }

        private int _cii;

        public int CII
        {
            get
            {
                return _cii;
            }

            set
            {
                _cii = value;
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

        private bool _bloqueado;

        public bool Bloqueado
        {
            get
            {
                return _bloqueado;
            }

            set
            {
                _bloqueado = value;
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

        private List<Entidades.UsuFamEN> _usufamL;

        public List<Entidades.UsuFamEN> UsuFamL
        {
            get
            {
                return _usufamL;
            }

            set
            {
                _usufamL = value;
            }
        }

        private List<Entidades.PatUsuEN> _usupatL;

        public List<Entidades.PatUsuEN> UsuPatL
        {
            get
            {
                return _usupatL;
            }

            set
            {
                _usupatL = value;
            }
        }

        private bool _tipoaccion;

        public bool TipoAccion
        {
            get
            {
                return _tipoaccion;
            }

            set
            {
                _tipoaccion = value;
            }
        }
    }
}