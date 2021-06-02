using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores_IDE
{
    class Sintactico
    {
        static private List<token> listaTokens;
        private token tokenActual;
        private Nodo raiz = null;
        private TreeNode Arbol1;
        private int i = 0;
        public Sintactico(List<token> lista)
        {
            listaTokens = lista;
        }
        
        public Nodo arbolSintactico()
        {
            tokenActual = listaTokens.ElementAt(i);
            raiz = programa();
            return raiz;
        }
       

        public void comprobar(String lex)
        {
            if (i < listaTokens.Count) { 
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
        }
        public TreeNode arbolSintactico2()
        {
            tokenActual = listaTokens.ElementAt(i);
            Arbol1 = new TreeNode();
            Arbol1 = programa2();
            return Arbol1;
        }
        public TreeNode programa2()
        {
            //Nodo temp = new Nodo(tokenActual);
            //TreeNode tempo2 = new TreeNode();
            Arbol1.Nodes.Add(tokenActual.getLexema());
            comprobar("program");
            comprobar("{");
            Arbol1.Nodes[0].Nodes.Add(listaDeclaracion());
            Arbol1.Nodes[0].Nodes.Add(listaSentencia());
            comprobar("}");
            return Arbol1;
        }
      
        public Nodo programa()
        {
            Nodo temp = new Nodo(tokenActual);
            comprobar("program");
            comprobar("{");
           // temp.hijos[0] = listaDeclaracion();
            //temp.hijos[1] = listaSentencia();
            comprobar("}");
            return temp;
        }

        public TreeNode listaDeclaracion()
        {
            //Nodo inicio = null;
            //Nodo sig = null;
            TreeNode inicio = new TreeNode();
            //TreeNode sig = new TreeNode();
            int l = 0;
            //tempo2.Nodes.Add("Programa");
            while ((tokenActual.getLexema()=="int") || (tokenActual.getLexema() == "float")
                || (tokenActual.getLexema() == "bool"))
            {
                inicio.Nodes.Add(declaracion());
                l++;
                /*
                if (inicio == null)
                {
                    inicio = declaracion();
                    sig = inicio;
                }
                else
                {
                    TreeNode nuevo = new TreeNode();
                    nuevo = declaracion();
                    sig.hermano = nuevo;
                    sig = nuevo;
                }*/
            }
            return inicio;
        }

        public TreeNode declaracion()
        {
            TreeNode temp = new TreeNode();
            //temp = tipo();
            temp.Nodes.Add(tipo());
            temp.Nodes[0].Nodes.Add(listaId());
            //temp.hijos[0] = listaId();
            return temp;
        }

        public TreeNode tipo()
        {
            // Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
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
                    break;
            }
            return temp;
        }

        public TreeNode listaId()
        {
            //Nodo inicio = new Nodo(tokenActual);
            //Nodo sig = inicio;
            TreeNode inicio = new TreeNode();
            inicio.Nodes.Add(tokenActual.getLexema());
            comprobar("ID");
            while (tokenActual.getLexema() == ",")
            {
                comprobar(",");
                inicio.Nodes.Add(tokenActual.getLexema());
                comprobar("ID");
            }
            comprobar(";");
            return inicio;
        }

        public TreeNode listaSentencia()
        {
            TreeNode inicio = new TreeNode();
            while ((tokenActual.getLexema()=="if")|| (tokenActual.getLexema() == "while") || (tokenActual.getLexema() == "do")
                || (tokenActual.getLexema() == "read")|| (tokenActual.getLexema() == "write")|| (tokenActual.getLexema() == "{")
                || (tokenActual.getIdToken() == "ID"))
            {
                
                inicio.Nodes.Add(sentencia());
            }
            return inicio;
        }

        public TreeNode sentencia()
        {
            TreeNode temp = new TreeNode();
            switch (tokenActual.getLexema())
            {
                case "if":
                    temp.Nodes.Add(seleccion());
                    
                    break;
                case "while":
                    temp.Nodes.Add(iteracion());
                    break;
                case "do":
                    temp.Nodes.Add(repeticion());
                    break;
                case "read":
                    temp.Nodes.Add(sentRead());
                    break;
                case "write":
                    temp.Nodes.Add(sentWrite());
                    break;
                case "{":
                    temp.Nodes.Add(bloque());
                    break;
                default:
                    //error
                    break;
            }
            if (tokenActual.getIdToken() == "ID")
            {
                temp.Nodes.Add(asignacion());
            }
            return temp;
        }

        public TreeNode seleccion()
        {
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
            //Nodo temp = new Nodo(tokenActual);
            comprobar("if");
            comprobar("(");
            temp.Nodes[0].Nodes.Add(bexpresion());
           // temp.hijos[0] = bexpresion();
            comprobar("then");
            temp.Nodes[0].Nodes.Add(bloque());
            //temp.hijos[1] = bloque();
            if (tokenActual.getLexema() == "else")
            {
                comprobar("else");
                temp.Nodes[0].Nodes.Add(bloque());
                //temp.hijos[2] = bloque();
            }
            comprobar("fi");
            return temp;
        }

        public TreeNode iteracion()
        {
            //Nodo  temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
            comprobar("while");
            comprobar("(");
            temp.Nodes[0].Nodes.Add(bexpresion());
            //temp.hijos[0] = bexpresion();
            comprobar(")");
            temp.Nodes[1].Nodes.Add(bloque());
            //temp.hijos[1] = bloque();
            return temp;
        }

        public TreeNode repeticion()
        {
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
            // Nodo temp = new Nodo(tokenActual);
            comprobar("do");
            temp.Nodes[0].Nodes.Add(bloque());
            //temp.hijos[0] = bloque();
            comprobar("until");
            comprobar("(");
            temp.Nodes[0].Nodes.Add(bexpresion());
            //temp.hijos[1] = bexpresion();
            comprobar(")");
            comprobar(";");
            return temp;
        }

        public TreeNode sentRead()
        {
            //Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
            comprobar("read");
            temp.Nodes[0].Nodes.Add(tokenActual.getLexema());
            // temp.hijos[0] = new Nodo(tokenActual);
            comprobar("ID");
            comprobar(";");
            return temp;
        }

        public TreeNode sentWrite()
        {
            //Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
            comprobar("write");
            temp.Nodes[0].Nodes.Add(bexpresion());
           // temp.hijos[0] = bexpresion();
            comprobar(";");
            return temp;
        }

        public TreeNode bloque()
        {
            comprobar("{");
            //Nodo temp = listaSentencia();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(listaSentencia());
            comprobar("}");
            return temp;
        }

        public TreeNode asignacion()
        {
            //Nodo temp = new Nodo();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add("asignacion");
            //temp.valor = "asignacion";
            //temp.linea = tokenActual.getLinea();
            temp.Nodes[0].Nodes.Add(tokenActual.getLexema());
            //temp.hijos[0] = new Nodo(tokenActual);
            comprobar("ID");
            comprobar("=");
            temp.Nodes[0].Nodes.Add(bexpresion());
            //temp.hijos[1] = bexpresion();
            comprobar(";");
            return temp;
        }
       
        public TreeNode bexpresion()
        {
            TreeNode temp = new TreeNode();
              temp.Nodes.Add(bterm());
            //Nodo temp = bterm();
             int l = 0;
            while (tokenActual.getLexema() == "or")
            {
                /*
                Nodo nuevo = new Nodo(tokenActual);
                comprobar(tokenActual.getLexema());
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = bterm();
                temp = nuevo;*/
                TreeNode nuevo = new TreeNode();
                nuevo.Nodes.Add(tokenActual.getLexema());
                nuevo.Nodes[0].Nodes.Add(bterm());
                temp.Nodes[l].Nodes.Add(nuevo);
            }
            return temp;
        }

        public TreeNode bterm()
        {
            //Nodo temp = notfactor();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(notfactor());
            int l = 0;
            while (tokenActual.getLexema() == "and")
            {
                /*Nodo nuevo = new Nodo(tokenActual);
                comprobar(tokenActual.getLexema());
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = notfactor();
                temp = nuevo;*/
                TreeNode nuevo = new TreeNode();
                nuevo.Nodes.Add(tokenActual.getLexema());
                nuevo.Nodes[0].Nodes.Add(bterm());
                temp.Nodes[l].Nodes.Add(nuevo);
            }
            return temp;
        }

        public TreeNode notfactor()
        {
            //Nodo temp = null;
            TreeNode temp = new TreeNode();
            
            if (tokenActual.getLexema() == "not")
            {
                //temp = new Nodo(tokenActual);
                temp.Nodes.Add(tokenActual.getLexema());
                comprobar("not");
                temp.Nodes[0].Nodes.Add(bfactor());
                //temp.hijos[0] = bfactor();
            }
            else
            {
                temp.Nodes.Add(bfactor());
                //temp = bfactor();
            }
            return temp;
        }

        public TreeNode bfactor()
        {
            TreeNode temp = new TreeNode();
            if((tokenActual.getLexema() == "true") || (tokenActual.getLexema() == "false"))
            {
                temp.Nodes.Add(tokenActual.getLexema());
                if (tokenActual.getLexema() == "true")
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
                temp.Nodes.Add(relacion());
             //   temp = relacion();
            }
            return temp;
        }

        public TreeNode relacion()
        {
            //Nodo temp = expresion();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(expresion());
            if ((tokenActual.getLexema()=="<=") || (tokenActual.getLexema() == "<") || (tokenActual.getLexema() == ">")
                || (tokenActual.getLexema() == ">=") || (tokenActual.getLexema() == "==") || (tokenActual.getLexema() == "!="))
            {
                /*Nodo nuevo = relOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = expresion();
                temp = nuevo;*/
                TreeNode nuevo = new TreeNode();
                nuevo.Nodes.Add(relOp());
                nuevo.Nodes[0].Nodes.Add(expresion());
                temp.Nodes[0].Nodes.Add(nuevo);
            }
            return temp;
        }

        public TreeNode relOp()
        {
            //Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode(); 
            temp.Nodes.Add(tokenActual.getLexema());
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

        public TreeNode expresion()
        {
            //Nodo temp = termino();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(termino());
            int l = 0;
            while ((tokenActual.getLexema() == "+") || (tokenActual.getLexema() == "-"))
            {
                /*Nodo nuevo = sumaOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = termino();
                temp = nuevo;*/
                TreeNode nuevo = new TreeNode();
                nuevo.Nodes.Add(sumaOp());
                nuevo.Nodes[0].Nodes.Add(termino());
                temp.Nodes[l].Nodes.Add(nuevo);
            }
            return temp;
        }

        public TreeNode sumaOp()
        {
            //Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
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
                    break;
            }
            return temp;
        }

        public TreeNode termino()
        {
            //Nodo temp = signoFactor();
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(signoFactor());
            int l = 0;
            while ((tokenActual.getLexema() == "*") || (tokenActual.getLexema() == "/"))
            {
                /*Nodo nuevo = multOp();
                nuevo.hijos[0] = temp;
                nuevo.hijos[1] = signoFactor();
                temp = nuevo;*/
                TreeNode nuevo = new TreeNode();
                nuevo.Nodes.Add(multOp());
                nuevo.Nodes[0].Nodes.Add(signoFactor());
                temp.Nodes[l].Nodes.Add(nuevo);
            }
            return temp;
        }

        public TreeNode multOp()
        {
            //Nodo temp = new Nodo(tokenActual);
            TreeNode temp = new TreeNode();
            temp.Nodes.Add(tokenActual.getLexema());
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
                    break;
            }
            return temp;
        }

        public TreeNode signoFactor()
        {
           // Nodo temp = null;
            TreeNode temp = new TreeNode();
          
            if ((tokenActual.getLexema() == "+") || (tokenActual.getLexema() == "-"))
            {
               // temp = sumaOp();
                temp.Nodes.Add(sumaOp());
                temp.Nodes[0].Nodes.Add(factor());
                //temp.hijos[0] = factor();
            }
            else
            {
               // temp = factor();
                temp.Nodes.Add(factor());
            }
            return temp;
        }

        public TreeNode factor()
        {
            //Nodo temp = null;
            TreeNode temp = new TreeNode();
            switch (tokenActual.getIdToken())
            {
                case "(":
                    //temp = bexpresion();
                    comprobar("(");
                    temp.Nodes.Add(bexpresion());
                    comprobar(")");
                    break;
                case "ID":
                    //temp = new Nodo(tokenActual);
                    temp.Nodes.Add(tokenActual.getLexema());
                    
                    comprobar("ID");
                    break;
                case "NUM":
                    //temp = new Nodo(tokenActual);
                    temp.Nodes.Add(tokenActual.getLexema());
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
