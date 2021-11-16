using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Nodo: token
    {
        public Nodo[] hijos;
        public Nodo hermano;
        public string label;

        public Nodo(): base()
        {
            hijos = new Nodo[3];
            hermano = null;
            label = null;
        }

        public Nodo(token token) : base(token)
        {
            hijos = new Nodo[3];
            hermano = null;
            label = null;
        }
    }
}
