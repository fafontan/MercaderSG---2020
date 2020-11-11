using System;
using System.Collections.Generic;
using Entidades;

namespace Excepciones
{
    public class WarningException : Exception
    {
        public List<string> ListaMensajes { get; set; }
        public List<FamPatEN> MensajesFamPat { get; set; }
        public List<UsuFamEN> MensajesUsuFam { get; set; }

        public WarningException(string mensaje) : base(mensaje)
        {
        }

        public WarningException(List<FamPatEN> Mensajes)
        {
            MensajesFamPat = Mensajes;
        }

        public WarningException(List<UsuFamEN> Mensajes)
        {
            MensajesUsuFam = Mensajes;
        }
    }
}