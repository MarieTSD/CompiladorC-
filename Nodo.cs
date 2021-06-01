using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Nodo
    {
        public Nodo [] hijos;
        public Nodo hermano;
        public string valor;
        public int linea;
        public Nodo()
        {
            hijos = null;
            hermano = null;
            valor = "";
            linea = 0;
        }

        public Nodo(token token)
        {
            hijos = null;
            hermano = null;
            valor = token.getLexema();
            linea = token.getLinea();
        }
    }
}
