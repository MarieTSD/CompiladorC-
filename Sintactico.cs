using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores_IDE
{
    class Sintactico
    {
        static private List<token> listaTokens;
        private token tokenActual;
        private Nodo raiz = null;
        private int i = 0;
        public Sintactico(List<token> lista)
        {
            listaTokens = lista;
        }
        public Nodo arbolSintactico()
        {
            Nodo temp = null;
            tokenActual = listaTokens.ElementAt(i);
            temp = programa();
            return raiz;
        }
        public void comprobar(String lex)
        {
            if (lex == tokenActual.getLexema())
            {
                i++;
                tokenActual = listaTokens.ElementAt(i);
            }
            else if (lex == tokenActual.getIdToken())
            {
                i++;
                tokenActual = listaTokens.ElementAt(i);
            }
            else
            {
                //Hubo un error
            }
        }
        public Nodo programa()
        {
            Nodo temp = null;
            comprobar("program");
            comprobar("{");
            temp = listaDeclaracion();
            temp = listaSentencia();
            comprobar("}");
            return temp;
        }
        public Nodo listaDeclaracion()
        {
            Nodo temp = null;
            while ((tokenActual.getLexema()=="int") || (tokenActual.getLexema() == "float")
                || (tokenActual.getLexema() == "bool"))
            {
                temp = declaracion();
            }
            return temp;
        }
        public Nodo declaracion()
        {
            Nodo temp = tipo();
            temp = listaId();
            return temp;
        }
        public Nodo tipo()
        {
            Nodo temp = null;
            switch (tokenActual.getLexema())
            {
                case "int":
                    comprobar("int");
                    break;
                case "float":
                    comprobar("float");
                    break;
                case "bool":
                    comprobar("bool");
                    break;
            }
            return temp;
        }
        public Nodo listaId()
        {
            Nodo temp = null;
            comprobar("ID");
            while (tokenActual.getLexema() == ",")
            {
                comprobar(",");
                comprobar("ID");
            }
            return temp;
        }
        public Nodo listaSentencia()
        {
            Nodo temp = null;
            while ((tokenActual.getLexema()=="if")|| (tokenActual.getLexema() == "while") || (tokenActual.getLexema() == "do")
                || (tokenActual.getLexema() == "read")|| (tokenActual.getLexema() == "write")|| (tokenActual.getLexema() == "{")
                || (tokenActual.getLexema() == "ID"))
            {
                temp = sentencia();
            }
            return temp;
        }
        public Nodo sentencia()
        {
            Nodo temp = null;
            switch (tokenActual.getLexema())
            {
                case "if":
                    temp = seleccion();
                    break;
                case "while":
                    temp = iteracion();
                    break;
                case "do":
                    temp = repeticion();
                    break;
                case "read":
                    temp = sentRead();
                    break;
                case "write":
                    temp = sentWrite();
                    break;
                case "{":
                    temp = bloque();
                    break;
                case "ID":
                    temp = asignacion();
                    break;
            }
            return temp;
        }
        public Nodo seleccion()
        {
            Nodo temp = null;
            comprobar("if");
            comprobar("(");
            temp = bexpresion();
            comprobar("then");
            temp = bloque();
            if (tokenActual.getLexema() == "else")
            {
                comprobar("else");
                temp = bloque();
            }
            comprobar("fi");
            return temp;
        }
        public Nodo iteracion()
        {
            Nodo  temp = null;
            comprobar("while");
            comprobar("(");
            temp = bexpresion();
            comprobar(")");
            temp = bloque();
            return temp;
        }
        public Nodo repeticion()
        {
            Nodo temp = null;
            comprobar("do");
            temp = bloque();
            comprobar("until");
            comprobar("(");
            temp = bexpresion();
            comprobar(")");
            comprobar(";");
            return temp;
        }
        public Nodo sentRead()
        {
            Nodo temp = null;
            comprobar("read");
            comprobar("ID");
            comprobar(";");
            return temp;
        }
        public Nodo sentWrite()
        {
            Nodo temp = null;
            comprobar("write");
            temp = bexpresion();
            comprobar(";");
            return temp;
        }
        public Nodo bloque()
        {
            Nodo temp = null;
            comprobar("{");
            temp = listaSentencia();
            comprobar("}");
            return temp;
        }
        public Nodo asignacion()
        {
            Nodo temp = null;
            comprobar("ID");
            comprobar("=");
            temp = bexpresion();
            comprobar(";");
            return temp;
        }
       
        public Nodo bexpresion()
        {
            Nodo temp = null;
            temp = bterm();
            while ((tokenActual.getLexema() == "OR") || (tokenActual.getLexema() == "or"))
            {
                comprobar(tokenActual.getLexema());
                temp = bterm();
            }
            return temp;
        }
        public Nodo bterm()
        {
            Nodo temp = notfactor();
            while ((tokenActual.getLexema() == "AND") || (tokenActual.getLexema() == "and"))
            {
                comprobar(tokenActual.getLexema());
                temp = notfactor();
            }
            return temp;
        }
        public Nodo notfactor()
        {
            Nodo temp = null;
            if(tokenActual.getLexema() == "not")
            {
                comprobar("not");
            }
            temp = bfactor();
            return temp;
        }
        public Nodo bfactor()
        {
            Nodo temp = null;
            if((tokenActual.getLexema() == "true") || (tokenActual.getLexema() == "false"))
            {
                if(tokenActual.getLexema() == "true")
                {
                    comprobar("true");
                }
                else
                {
                    comprobar("false");
                }
            }
            else
            {
                temp = relacion();
            }
            return temp;
        }
        public Nodo relacion()
        {
            Nodo temp = expresion();
            if((tokenActual.getLexema()=="<=") || (tokenActual.getLexema() == "<") || (tokenActual.getLexema() == ">")
                || (tokenActual.getLexema() == ">=") || (tokenActual.getLexema() == "==") || (tokenActual.getLexema() == "!="))
            {
                //Aqui tiene que ir uno para nodo iz y otro para derecho
                temp = relOp();
                temp = expresion();
            }
            return temp;
        }
        public Nodo relOp()
        {
            Nodo temp = null;
            switch (tokenActual.getLexema())
            {
                case "<=":
                    comprobar("<=");
                    break;
                case "<":
                    comprobar("<");
                    break;
                case ">":
                    comprobar(">");
                    break;
                case ">=":
                    comprobar(">=");
                    break;
                case "==":
                    comprobar("==");
                    break;
                case "!=":
                    comprobar("!=");
                    break;
                default:
                    //Marcar error
                    break;
            }
            return temp;
        }
        public Nodo expresion()
        {
            Nodo temp = expresion();
            while ((tokenActual.getLexema() == "+") || (tokenActual.getLexema() == "-"))
            {
                comprobar(tokenActual.getLexema());
                temp = termino();
            }
            return temp;
        }
        public Nodo sumaOp()
        {
            Nodo temp = null;
            switch (tokenActual.getLexema())
            {
                case "+":
                    comprobar("+");
                    break;
                case "-":
                    comprobar("-");
                    break;
            }
            return temp;
        }
        public Nodo termino()
        {
            Nodo temp = null;
            temp = signoFactor();
            while ((tokenActual.getLexema() == "*") || (tokenActual.getLexema() == "/"))
            {
                comprobar(tokenActual.getLexema());
                temp = signoFactor();
            }
            return temp;
        }
        public Nodo multOp()
        {
            Nodo temp = null;
            switch (tokenActual.getLexema())
            {
                case "*":
                    comprobar("*");
                    break;
                case "/":
                    comprobar("/");
                    break;
            }
            return temp;
        }
        public Nodo signoFactor()
        {
            Nodo temp = null;
            if ((tokenActual.getLexema() == "+") || (tokenActual.getLexema() == "-"))
            {
                temp = sumaOp();
            }
            temp = factor();
            return temp;
        }
        public Nodo factor()
        {
            Nodo temp = null;
          
            switch (tokenActual.getIdToken())
            {
                case "(":
                    temp = bexpresion();
                    comprobar(")");
                    break;
                case "ID":
                    temp.valor = tokenActual.getLexema();
                    comprobar("ID");
                    break;
                case "NUM":
                    temp.valor = tokenActual.getLexema();
                    comprobar("NUM");
                    break;
                default:

                    //Error
                    break;
            }
            return temp;
        }
    }
}
