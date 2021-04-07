using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class token
    {
        private String idToken;
        private String lexema;
        private int indice;
        private int linea;


        public token(String idToken, String lexema, int linea, int indice)
        {
            this.idToken = idToken;
            this.lexema = lexema;
            this.indice = indice;
            this.linea = linea;
        }

        public int getIndice()
        {
            return this.indice;
        }
        public String getLexema()
        {
            return this.lexema;
        }
        public String getIdToken()
        {
            return this.idToken;
        }
        public int getLinea()
        {
            return this.linea;
        }
    }
}
