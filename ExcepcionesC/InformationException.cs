﻿using System;
using System.Collections.Generic;

namespace ExcepcionesC
{
    public class InformationException : Exception
    {
        public List<string> ListaMensajes { get; set; }

        public InformationException(string mensaje) : base(mensaje)
        {
        }

        public InformationException(List<string> Mensajes)
        {
            ListaMensajes = Mensajes;
        }
    }
}