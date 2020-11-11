using System;

namespace Excepciones
{
    public class CriticalException : Exception
    {
        public CriticalException(string mensaje) : base(mensaje)
        {
        }
    }
}