using System;

namespace ExcepcionesC
{
    public class CriticalException : Exception
    {
        public CriticalException(string mensaje) : base(mensaje)
        {
        }
    }
}