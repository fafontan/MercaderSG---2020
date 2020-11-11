using System.Collections.Generic;

namespace EntidadesC
{
    public class FamiliaEN
    {
        private int _codfam;

        public int CodFam
        {
            get
            {
                return _codfam;
            }

            set
            {
                _codfam = value;
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

        private List<EntidadesC.FamPatEN> _fampatL;

        public List<EntidadesC.FamPatEN> FamPatL
        {
            get
            {
                return _fampatL;
            }

            set
            {
                _fampatL = value;
            }
        }
    }
}