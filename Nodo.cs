using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Nodo
    {
        public Nodo [] hijos = new Nodo[6];
        public Nodo hermano;
        public string valor;
        public int linea;
        public Nodo()
        {
            hijos[0] = null;
            hijos[1] = null;
            hijos[2] = null;
            hijos[3] = null;
            hijos[4] = null;
            hijos[5] = null;
            hermano = null;
            valor = "";
            linea = 0;
        }

        public Nodo(token token)
        {
            hijos[0] = null;
            hijos[1] = null;
            hijos[2] = null;
            hijos[3] = null;
            hijos[4] = null;
            hijos[5] = null;
            hermano = null;
            valor = token.getLexema();
            linea = token.getLinea();
        }
    }
}
