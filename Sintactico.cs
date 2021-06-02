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
        static private List<token> errores;
        private token tokenActual;
        private Nodo raiz = null;
        private String tokenResultado;
        private int i = 0;
        public Sintactico(List<token> lista)
        {
            listaTokens = lista;
            errores = new List<token> ();
        }
        
        public Nodo arbolSintactico()
        {
            tokenActual = listaTokens.ElementAt(i);
            raiz = programa();
            return raiz;
        }
        public String erroresSintacticos()
        {
            for (int i = 0; i < errores.Count; i++)
            {
                token actual = errores.ElementAt(i);
                tokenResultado += "[Lexema: " + actual.getLexema() + ",Token: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]" + Environment.NewLine;
            }
            return tokenResultado;
        }

        public void comprobar(String lex)
        {
            if (lex == tokenActual.getLexema())
            {
                i++;
                if(i<listaTokens.Count)
                    tokenActual = listaTokens.ElementAt(i);
                while(tokenActual.getIdToken() == "Comentario" || tokenActual.getIdToken() == "Comentario /**/")
                {
                    i++;
                    if (i < listaTokens.Count)
                        tokenActual = listaTokens.ElementAt(i);
                }

            }
            else if (lex == tokenActual.getIdToken())
            {
                i++;
                if (i < listaTokens.Count)
                    tokenActual = listaTokens.ElementAt(i);
                while (tokenActual.getIdToken() == "Comentario" || tokenActual.getIdToken() == "Comentario/**/")
                {
                    i++;
                    if (i < listaTokens.Count)
                        tokenActual = listaTokens.ElementAt(i);
                }
            }
            else
            {
                //Hubo un error
                errores.Add(tokenActual);
            }
        }

        public Nodo programa()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("program");
            comprobar("{");
            temp.hijos[0] = listaDeclaracion();
            temp.hijos[1] = listaSentencia();
            comprobar("}");
            return temp;
        }

        public Nodo listaDeclaracion()
        {
            Nodo inicio = null;
            Nodo sig = null;
            while ((tokenActual.getLexema()=="int") || (tokenActual.getLexema() == "float")
                || (tokenActual.getLexema() == "bool"))
            {
                if(inicio == null)
                {
                    inicio = declaracion();
                    sig = inicio;
                }
                else
                {
                    Nodo nuevo = declaracion();
                    sig.hermano = nuevo;
                    sig = nuevo;
                }
            }
            return inicio;
        }

        public Nodo declaracion()
        {
            Nodo temp = tipo();
            temp.hijos[0] = listaId();
            return temp;
        }

        public Nodo tipo()
        {
            Nodo temp = new Nodo(tokenActual);
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
                default:
                    //error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo listaId()
        {
            Nodo inicio = new Nodo(tokenActual);
            Nodo sig = inicio;
            int aux = 0;
            comprobar("ID");
            while (tokenActual.getLexema() == ",")
            {
                comprobar(",");
                Nodo nuevo = new Nodo(tokenActual);
                comprobar("ID");
                
                sig.hermano = nuevo;
                sig = nuevo;
                /*
                inicio.hijos[aux] = nuevo;
                aux++;*/
            }
            comprobar(";");
         
            return inicio;
        }

        public Nodo listaSentencia()
        {
            Nodo inicio = null;
            Nodo sig = null;
            while ((tokenActual.getLexema()=="if")|| (tokenActual.getLexema() == "while") || (tokenActual.getLexema() == "do")
                || (tokenActual.getLexema() == "read")|| (tokenActual.getLexema() == "write")|| (tokenActual.getLexema() == "{")
                || (tokenActual.getIdToken() == "ID"))
            {
                if(inicio == null)
                {
                    inicio = sentencia();
                    sig = inicio;
                }
                else
                {
                    Nodo nuevo = sentencia();
                    sig.hermano = nuevo;
                    sig = nuevo;
                }
            }
            return inicio;
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
                default:
                    if (tokenActual.getIdToken() == "ID")
                        temp = asignacion();
                    else
                       // Console.WriteLine("Error");
                       errores.Add(tokenActual);
                    //error
                    break;
            }

            

            return temp;
        }

        public Nodo seleccion()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("if");
            comprobar("(");
            temp.hijos[0] = bexpresion();
            comprobar(")");
            comprobar("then");
            temp.hijos[1] = bloque();
            if (tokenActual.getLexema() == "else")
            {
                comprobar("else");
                temp.hijos[2] = bloque();
            }
            comprobar("fi");
            return temp;
        }

        public Nodo iteracion()
        {
            Nodo  temp = new Nodo(tokenActual);
            comprobar("while");
            comprobar("(");
            temp.hijos[0] = bexpresion();
            comprobar(")");
            temp.hijos[1] = bloque();
            return temp;
        }

        public Nodo repeticion()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("do");
            temp.hijos[0] = bloque();
            comprobar("until");
            comprobar("(");
            temp.hijos[1] = bexpresion();
            comprobar(")");
            comprobar(";");
            return temp;
        }

        public Nodo sentRead()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("read");
            temp.hijos[0] = new Nodo(tokenActual);
            comprobar("ID");
            comprobar(";");
            return temp;
        }

        public Nodo sentWrite()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("write");
            temp.hijos[0] = bexpresion();
            comprobar(";");
            return temp;
        }

        public Nodo bloque()
        {
            comprobar("{");
            Nodo temp = listaSentencia();
            comprobar("}");
            return temp;
        }

        public Nodo asignacion()
        {
            Nodo temp = new Nodo();
            temp.valor = "asignacion";
            temp.linea = tokenActual.getLinea();
            temp.hijos[0] = new Nodo(tokenActual);
            comprobar("ID");
            comprobar("=");
            temp.hijos[1] = bexpresion();
            comprobar(";");
            return temp;
        }
       
        public Nodo bexpresion()
        {
            Nodo temp = bterm();
            while (tokenActual.getLexema() == "or")
            {
                Nodo nuevo = new Nodo(tokenActual);
                comprobar(tokenActual.getLexema());
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = bterm();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo bterm()
        {
            Nodo temp = notfactor();
            while (tokenActual.getLexema() == "and")
            {
                Nodo nuevo = new Nodo(tokenActual);
                comprobar(tokenActual.getLexema());
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = notfactor();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo notfactor()
        {
            Nodo temp = null;
            if(tokenActual.getLexema() == "not")
            {
                temp = new Nodo(tokenActual);
                comprobar("not");
                temp.hijos[0] = bfactor();
            }
            else
            {
                temp = bfactor();
            }
            return temp;
        }

        public Nodo bfactor()
        {
            Nodo temp = null;
            if((tokenActual.getLexema() == "true") || (tokenActual.getLexema() == "false"))
            {
                temp = new Nodo(tokenActual);
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
                Nodo nuevo = relOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = expresion();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo relOp()
        {
            Nodo temp = new Nodo(tokenActual);
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
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo expresion()
        {
            Nodo temp = termino();
            while ((tokenActual.getLexema() == "+") || (tokenActual.getLexema() == "-"))
            {
                Nodo nuevo = sumaOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = termino();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo sumaOp()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getLexema())
            {
                case "+":
                    comprobar("+");
                    break;
                case "-":
                    comprobar("-");
                    break;
                default:
                    //error
                    errores.Add(tokenActual);
                    break;
            }
            return temp;
        }

        public Nodo termino()
        {
            Nodo temp = signoFactor();
            while ((tokenActual.getLexema() == "*") || (tokenActual.getLexema() == "/"))
            {
                Nodo nuevo = multOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = signoFactor();
                temp = nuevo;
            }
            return temp;
        }

        public Nodo multOp()
        {
            Nodo temp = new Nodo(tokenActual);
            switch (tokenActual.getLexema())
            {
                case "*":
                    comprobar("*");
                    break;
                case "/":
                    comprobar("/");
                    break;
                default:
                    //error
                    errores.Add(tokenActual);
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
                temp.hijos[0] = factor();
            }
            else
            {
                temp = factor();
            }
            return temp;
        }

        public Nodo factor()
        {
            Nodo temp = new Nodo();
          
            switch (tokenActual.getIdToken())
            {
                case "(":
                    comprobar("(");
                    temp = bexpresion();
                    comprobar(")");
                    break;
                case "ID":
                    temp = new Nodo(tokenActual);
                    comprobar("ID");
                    break;
                case "NUM":
                    temp = new Nodo(tokenActual);
                    comprobar("NUM");
                    break;
                default:
                    if (tokenActual.getLexema() == "(")
                    {
                        comprobar("(");
                        temp = bexpresion();
                        comprobar(")");
                    }
                    else
                        //Console.WriteLine("Error");
                        errores.Add(tokenActual);
                    //Error
                    break;
            }
            return temp;
        }
    }
}
